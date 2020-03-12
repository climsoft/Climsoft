''' <summary>
''' </summary>
''' <remarks>
''' The <c>DataStructure</c> will keep data in the same structure/table as in the database.
''' </remarks>
Public Class DataStructure
    ' TODO
    ' 1. Do we allow choice of fields to get? If writing then all fields needed,
    '    but reading only may not need all fields.
    '    Most tables have few fields so might not be needed.
    ' 2. Where should SQL statement construction functions live?

    ''' <summary>
    ''' A string, the name of the table in the database this DataStructure links.
    ''' </summary>
    Private strTableName As String

    ''' <summary>
    ''' A string, how the "id" column is stored in the database in all tables it appears in.
    ''' This could be moved to a separate class of constants.
    ''' </summary>
    Private strId As String = "id"

    ''' <summary>
    ''' A string, how the "current/current best" column is stored in <c>strTableName</c>.
    ''' This is "current_best" by default and can either be "current" or "current_best".
    ''' </summary>
    Private strCurrent As String = "current_best"

    ''' <summary>
    ''' A list of strings, the names of the fields in <c>strTableName</c> which uniquely define a row.
    ''' In most tables and by default this is <c>{strId, strVersionNumber}</c> but it is not in all and can be changed.
    ''' </summary>
    Private lstKeyFieldNames As List(Of String) = New List(Of String)({strId, GlobalVariables.strVersionNumber})

    ''' <summary>
    ''' A list of strings, the names of the fields in <c>strTableName</c> which do not relate to primary key of auditting i.e. all columns apart from: <c>strID</c>, <c>GlobalVariables.strVersionNumber</c> and <c>strCurrent</c>.
    ''' </summary>
    ''' <remarks>
    ''' This is used when adding a new record. To add a new record, a value must be specified for each of <c>lstValueFields</c>.
    ''' </remarks>
    Private lstValueFields As List(Of String)

    ''' <summary>
    ''' A <c>DataTable</c> storing the data read from the database.
    ''' This remains static once fetched from the database.
    ''' </summary>
    Private dtbReadTable As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing the new data to be written to the database. 
    ''' This builds up as controls change.
    ''' </summary>
    Private dtbWriteTable As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing new comments associated to <c>strTableName</c>. 
    ''' </summary>
    Private dtbComments As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing new events associated to <c>strTableName</c>. 
    ''' </summary>
    Private dtbEvents As DataTable

    ''' <summary>
    ''' A list of linked <c>DataStructure</c>s that relate to required linked tables in the database.
    ''' </summary>
    ''' <remarks>
    ''' This will included <c>DataStructure</c>s for existing comments and events associated to <c>strTableName</c>.
    ''' </remarks>
    Private lstLinkedDataStructures As List(Of DataStructure)

    ''' <summary>
    ''' This event is raised when <c>dtbReadTable</c> changes.
    ''' The navigator and page control will listen for this and update their values when this event is raised.
    ''' </summary>
    Public Event DataChanged()

    ''' <summary>Field name for "version old" when constructing <c>dtbUpdateTable</c>.</summary>
    Private strVOld As String = ".v_old"

    ''' <summary>Field name for "update type" when constructing <c>dtbUpdateTable</c>.</summary>
    Private strUpdateType As String = ".update_type"

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Set the name of the table in the database this DataStructure links to. </summary>
    '''
    ''' <param name="strNewTableName">  A string, the name of the table in the database. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub SetTableName(strNewTableName As String)
        strTableName = strNewTableName
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Set the names of the fields in <c>strTableName</c> which do not relate to primary key of auditting 
    ''' i.e. all columns apart from: <c>strID</c>, <c>GlobalVariables.strVersionNumber</c> and <c>strCurrent</c>.
    ''' </summary>
    '''
    ''' <param name="iEnumerableNewKeyFields">  The list of names of the key fields for <c>strTableName</c>.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub SetKeyFields(iEnumerableNewKeyFields As IEnumerable(Of String))
        lstKeyFieldNames = iEnumerableNewKeyFields.ToList()
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Set the names of the fields in <c>strTableName</c> which uniquely define a row. This is
    ''' needed when updating records. In most tables and by default this is <c>{strId,
    ''' strVersionNumber}</c>. This method should only be used if it is different to the default.
    ''' </summary>
    '''
    ''' <param name="iEnumerableNewValueFields">  The list of names of the value fields for <c>strTableName</c>.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub SetValueFields(iEnumerableNewValueFields As IEnumerable(Of String))
        lstValueFields = iEnumerableNewValueFields.ToList()
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Initialises <c>dtbWriteTable</c> as a clone of <c>dtbReadTable</c>. This should be called
    ''' once <c>dtbReadTable</c> has been set.
    ''' </summary>
    '''
    ''' <remarks> <c>.Clone</c> copies the structure but not the data of a <c>DataTable</c>. </remarks>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub InitialiseWriteTable()
        If dtbReadTable IsNot Nothing Then
            dtbWriteTable = dtbReadTable.Clone()
            dtbWriteTable.Columns.Add(strVOld, GetType(Integer))
            dtbWriteTable.Columns.Add(strUpdateType, GetType(Integer))
        End If
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Sets the comments associated with <c>strTableName</c> and stores them in <c>dtbComments</c>.
    ''' This may be called when getting the main data, or may only be called on demand.
    ''' </summary>
    '''
    ''' <param name="bAllVersions"> (Optional) Boolean, if  <c>True</c> all versions returned, if
    '''                             <c>False</c> only the current comment for each id is returned. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub SetCommentsTable(Optional bAllVersions As Boolean = False)
        ' SQL command, all versions:
        ' SELECT * FROM c5_comments WHERE table_id=@strTableName

        ' From here: https://stackoverflow.com/questions/612231/how-can-i-select-rows-with-maxcolumn-value-distinct-by-another-column-in-sql
        ' SQL command, current only:
        ' Select Case m.* From c5_comment m
        ' INNER Join(SELECT id, MAX(current) As max_current FROM c5_comment GROUP BY id) m_group
        ' ON m.id=m_group.id
        ' AND m.current=m_group.max_current AND m.table_id=@strTableName

        ' alternative.......

        ' SELECT m.*
        ' FROM c5_comment m
        ' LEFT JOIN c5_comment b
        ' ON m.id = b.id
        ' AND m.current < b.current
        ' WHERE b.current Is NULL AND m.table_id=@strTableName
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Gets the events associated with <c>strTableName</c> and stores them in <c>dtbEvents</c>. This
    ''' may be called when getting the main data, or may only be called on demand.
    ''' </summary>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub SetEventsTable()
        ' SQL command, current only:
        ' 
        ' SELECT * FROM (SELECT m.*
        ' 					FROM c5_event_effect m
        '     					LEFT JOIN c5_event_effect b
        '        					ON m.id = b.id
        '        					AND m.current < b.current
        '							WHERE b.current IS NULL AND m.table_id=@strTableName) e_e
        ' INNER JOIN (SELECT m.*
        '				FROM c5_event m
        '    				LEFT JOIN c5_event b
        '        				ON m.id = b.id
        '        				AND m.current < b.current
        '						WHERE b.current IS NULL) e
        ' ON e_e.event_id=e.id
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Constructs an SQL query to get only the current versions from a table. (Could be moved to a
    ''' separate class for query construction)
    ''' </summary>
    '''
    ''' <param name="strTable"> A string, the name of the table to query. </param>
    '''
    ''' <returns>   The current versions query. </returns>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function GetCurrentVersionsQuery(strTable As String) As String
        ' From here: https://stackoverflow.com/questions/612231/how-can-i-select-rows-with-maxcolumn-value-distinct-by-another-column-in-sql

        ' Option 1:
        ' #########
        ' Select Case m.* From @strTable m
        ' INNER Join(SELECT id, MAX(@strCurrent) As max_current FROM @strTable GROUP BY id) m_group
        ' ON m.id=m_group.id
        ' AND m.@strCurrent=m_group.max_current

        ' Option 2:
        ' #########
        ' SELECT m.*
        ' FROM @strTable m
        ' LEFT JOIN @strTable b
        ' ON m.id = b.id
        ' AND m.@strCurrent < b.@strCurrent
        ' WHERE b.@strCurrent Is NULL
    End Function

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Constructs an SQL query to get only the versions equal to <c>iVersion</c> from a table.
    ''' (Could be moved to a separate class for query construction)
    ''' </summary>
    '''
    ''' <remarks>   Danny, 12/03/2020. </remarks>
    '''
    ''' <param name="strTable"> A string, the name of the table to query. </param>
    ''' <param name="iVersion"> An integer, the version numbers to extract for each id. </param>
    '''
    ''' <returns> An SQL query string. </returns>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function GetVersionNumberQuery(strTable As String, iVersion As Integer) As String

    End Function

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary> Creates a new action in the action table and returns its Action ID. </summary>
    '''
    ''' <param name="iActionTypeID">    Identifier for the action type. </param>
    ''' <param name="strOperatorID">    Identifier for the operator. </param>
    '''
    ''' <returns> The Action ID for the new action added. </returns>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function NewAction(iActionTypeID As Integer, strOperatorID As String) As Integer
        Dim iActionID As Integer
        ' create new entry in action table using iActionTypeID, strOperatorID and current date-time
        ' get back action ID for new entry created
        Return iActionID
    End Function

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Updates <c>dtbUpdateTable</c> to add a new record to <c>strTableName</c>.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoAddRecord(dctValues As Dictionary(Of String, Object))
        Dim lstValues As New List(Of Object)
        Dim objTemp As Object = Nothing

        For Each strField As String In lstValueFields
            If dctValues.TryGetValue(strField, objTemp) Then
                lstValues.Add(objTemp)
            Else
                MsgBox("Developer error in clsDataStructure:DoAddRecord. No value specified for field: " & strField & " when attempting to add a record.")
                Exit Sub
            End If
        Next

        ' This adds a row for the fields named: 
        ' strId, strVersionNumber, lstValueFields, strCurrent, strVOld, strUpdateType
        ' The value for strId is DBNull.Value since this will be auto incremented in the database.
        ' The order is important.
        ' TODO: If audit table will also use this then it will be to be adapted as it does not have the same id, version number, current
        dtbWriteTable.Rows.Add(DBNull.Value, 1, lstValueFields.ToArray, 1, DBNull.Value, GlobalVariables.UpdateType.NewRecord)
        'TODO Need to get back ID added for audit table then correct it in dtbWriteTable
        ' Possible using IDENTITY https://www.sqlservertutorial.net/sql-server-basics/sql-server-identity/
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Executes the action operation. </summary>
    '''
    ''' <param name="iActionTypeID">    The ID of the action type by run. </param>
    ''' <param name="strOperatorID">    The ID of the operator performing the action. </param>
    ''' <param name="DataStruct">       The <c>DataStructure</c> containing changes that form the action. </param>
    ''' <param name="strActionComment"> (Optional) An comment on the action. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoAction(iActionTypeID As Integer, strOperatorID As String, DataStruct As DataStructure, Optional strActionComment As String = "")
        Dim iActionID As Integer

        ' create new entry in action table using iActionTypeID, strOperatorID and current date-time
        ' get back action ID for new entry created
        iActionID = NewAction(iActionTypeID, strOperatorID)
        ' create comment for action comment and add to comment table

        DataStruct.UpdateTable(iActionTypeID)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Test for update table. </summary>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub TestUpdateTable()
        dtbReadTable = New DataTable
        dtbReadTable.Columns.Add(strId, GetType(Integer))
        dtbReadTable.Columns.Add(GlobalVariables.strVersionNumber, GetType(Integer))
        dtbReadTable.Columns.Add("value", GetType(String))
        dtbReadTable.Columns.Add(strCurrent, GetType(Integer))

        dtbReadTable.Rows.Add(1, 1, "a", 1)
        dtbReadTable.Rows.Add(2, 1, "b", 1)
        dtbReadTable.Rows.Add(3, 1, "c", 1)
        dtbReadTable.Rows.Add(4, 1, "dd", 1)
        dtbReadTable.Rows.Add(4, 2, "ddd", 2)
        dtbReadTable.Rows.Add(5, 1, "e", 1)

        dtbWriteTable = dtbReadTable.Clone()
        dtbWriteTable.Columns.Add(strVOld, GetType(Integer))
        dtbWriteTable.Columns.Add(strUpdateType, GetType(Integer))

        dtbWriteTable.Rows.Add(1, 1, "a", DBNull.Value, 1, GlobalVariables.UpdateType.Correction)
        dtbWriteTable.Rows.Add(1, 2, "A", 1, 1, GlobalVariables.UpdateType.Correction)
        dtbWriteTable.Rows.Add(2, 2, "bb", 2, 1, GlobalVariables.UpdateType.EventChange)
        dtbWriteTable.Rows.Add(3, 1, "c", DBNull.Value, 1, GlobalVariables.UpdateType.Delete)
        dtbWriteTable.Rows.Add(4, 3, "d", 1, DBNull.Value, GlobalVariables.UpdateType.EventChange)
        dtbWriteTable.Rows.Add(4, 1, "dd", 2, 1, GlobalVariables.UpdateType.EventChange)
        dtbWriteTable.Rows.Add(4, 2, "ddd", 3, 1, GlobalVariables.UpdateType.EventChange)
        UpdateTable(1)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Performs the updates to the tables in this <c>DataStructure</c> associated with the action with id <c>iActionID</c>. </summary>
    '''
    ''' <param name="iActionID"> The ID of the action being performed. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub UpdateTable(iActionID As Integer)
        Dim dtbUpdateTable As DataTable
        Dim dtbAuditTable As DataTable
        Dim iUpdateType As Integer
        Dim dtbWriteTableCopy As DataTable
        Dim rowNewWrite As DataRow
        Dim strSelectExp As String
        Dim drowsReadRows() As DataRow
        Dim rowReadRow As DataRow
        Dim rowUpdateReadRow As DataRow

        ' produce table from the read and write table that will corresponds to the 'add's and 'update's of that table
        ' STEPS
        ' 1. Make the update table as a Clone() of the read table
        dtbUpdateTable = dtbReadTable.Clone()

        dtbWriteTableCopy = dtbWriteTable.Copy()
        dtbWriteTableCopy.Columns.Remove(strVOld)
        dtbWriteTableCopy.Columns.Remove(strUpdateType)
        ' 2. Make a blank audit table to add entries to
        dtbAuditTable = GlobalVariables.dtbEmptyAuditTable
        ' 3. Loop through the write table and:
        For i As Integer = 0 To dtbWriteTable.Rows.Count - 1
            ' a) read the update type from the write table
            iUpdateType = dtbWriteTable.Rows(i).Field(Of Integer)(strUpdateType)
            ' b) add a row for each row to the update table
            '    (current value should be correct in dtbWriteTable at this point)
            '    for a delete, current value will be NULL so the "new" row is actually an update to an existing row
            dtbUpdateTable.ImportRow(dtbWriteTableCopy.Rows(i))
            rowNewWrite = dtbUpdateTable.Rows(dtbUpdateTable.Rows.Count - 1)
            ' c) add a row for an edit to the read table if neccessary
            ' (a change for a delete is in the write table already)
            Select Case iUpdateType
                Case GlobalVariables.UpdateType.NewRecord
                    'TODO How will we know the "id" of a new record
                    GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, , Nothing, 1)
                Case GlobalVariables.UpdateType.Correction, GlobalVariables.UpdateType.EventChange
                    strSelectExp = strId & " = " & dtbWriteTable.Rows(i).Field(Of Integer)(strId) & " and " & GlobalVariables.strVersionNumber & " = " & dtbWriteTable.Rows(i).Field(Of Integer)(strVOld)
                    drowsReadRows = dtbReadTable.Select(strSelectExp)
                    If drowsReadRows.Count = 1 Then
                        rowReadRow = drowsReadRows(0)
                        dtbUpdateTable.ImportRow(rowReadRow)
                        rowUpdateReadRow = dtbUpdateTable.Rows(dtbUpdateTable.Rows.Count - 1)
                        If iUpdateType = GlobalVariables.UpdateType.Correction Then
                            rowUpdateReadRow.Item(strCurrent) = DBNull.Value
                        ElseIf iUpdateType = GlobalVariables.UpdateType.EventChange Then
                            rowUpdateReadRow.Item(strCurrent) = rowUpdateReadRow.Field(Of Integer)(strCurrent) + 1
                        End If
                        GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, dtbWriteTable.Rows(i).Field(Of Integer)(strId), dtbWriteTable.Rows(i).Field(Of Integer)(strVOld), dtbWriteTable.Rows(i).Field(Of Integer)(GlobalVariables.strVersionNumber))
                    Else
                        ' Error? Should always be 1 row because id and version number form a key
                    End If
            End Select
            If iUpdateType = GlobalVariables.UpdateType.Correction Then
            End If
            ' d) produce the audit record to be added to the audit write table
        Next

        ' 4. Write: update table, audit table, comments table, events table
        ' 5. Call UpdateTable for each lstLinkedDataStructures
        For Each clsLinkedStruc As DataStructure In lstLinkedDataStructures
            clsLinkedStruc.UpdateTable(iActionID)
        Next
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Takes <c>dtbReadTable</c> and <c>dtbWriteTable</c> and produces a <c>DataTable</c> with the
    ''' correct updates and inserts to be added to the database.
    ''' </summary>
    '''
    ''' <returns> A <c>DataTable</c> with. </returns>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Function GenerateTableForUpdate() As DataTable

    End Function

    ' UpdateData() adds, updates and deletes data

End Class
