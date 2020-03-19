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
        ' This will be done manually initially: find max ActionId in the action table and increment.
        Return iActionID
    End Function

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Updates <c>dtbUpdateTable</c> to add a new record to <c>strTableName</c>.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    ''' 
    ''' <param name="dctValues"> A dictionary of values for the new record. The keys are the field names.
    '''                          This does not include the indentifiers and current fields. Their values are
    '''                          calculated automatically.
    ''' </param>
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
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Adds two rows to <c>dtbUpdateTable</c> to indicate a correction to a record.
    '''             One row is to modify the current of the existing row. The other is the new row for the
    '''             correction.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    ''' <param name="rcEventChanges">A collection of <c>DataRow</c>s for all event changes. These rows should
    '''                              have the same structure as <c>dtbReadTable</c>. 
    '''                              This may be nothing if there are no event changes.
    '''                              </param>
    ''' <param name="rowEventNew">A <c>DataRow</c> for a new event. This row should have the same structure 
    '''                           as <c>dtbReadTable</c>.This may be nothing if there is no new event.
    '''                           </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoEvent(Optional rcEventChanges As DataRowCollection = Nothing, Optional rowEventNew As DataRow = Nothing)
        Dim rowNew As DataRow

        ' Add the rows for the event changes.
        If rcEventChanges IsNot Nothing Then
            For Each rowCurrent As DataRow In rcEventChanges
                rowNew = dtbWriteTable.NewRow()
                For i = 0 To rowCurrent.ItemArray.Count - 1
                    rowNew.Item(i) = rowCurrent.ItemArray(i)
                Next
                rowNew.Item(strVOld) = DBNull.Value
                rowNew.Item(strUpdateType) = GlobalVariables.UpdateType.EventChange
            Next
        End If

        ' Add a row for the new event
        If rowEventNew IsNot Nothing Then
            rowNew = dtbWriteTable.NewRow()
            For i = 0 To rowEventNew.ItemArray.Count - 1
                rowNew.Item(i) = rowEventNew.ItemArray(i)
            Next
            rowNew.Item(strVOld) = DBNull.Value
            rowNew.Item(strUpdateType) = GlobalVariables.UpdateType.EventNew
        End If
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Adds two rows to <c>dtbUpdateTable</c> to indicate a correction to a record.
    '''             One row is to modify the current of the existing row. The other is the new row for the
    '''             correction.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    ''' <param name="rowCurrent">The <c>DataRow</c> to be corrected.</param>
    ''' <param name="dctValues"> A dictionary of values for the correction. The keys are the field names.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoCorrectionToRecord(rowCurrent As DataRow, dctValues As Dictionary(Of String, Object))
        Dim lstValues As New List(Of Object)
        Dim objTemp As Object = Nothing
        Dim rowCurrentUpdate As DataRow

        ' Add the row for the correction to the existing row. The only change is current set to NULL.
        rowCurrentUpdate = dtbWriteTable.NewRow()
        For i = 0 To rowCurrent.ItemArray.Count - 1
            rowCurrentUpdate.Item(i) = rowCurrent.ItemArray(i)
        Next
        rowCurrentUpdate.Item(strCurrent) = DBNull.Value
        rowCurrentUpdate.Item(strVOld) = rowCurrentUpdate.Item(GlobalVariables.strVersionNumber)
        rowCurrentUpdate.Item(strUpdateType) = GlobalVariables.UpdateType.Correction

        ' TODO Should be moved to separate function as duplicated.
        For Each strField As String In lstValueFields
            If dctValues.TryGetValue(strField, objTemp) Then
                lstValues.Add(objTemp)
            Else
                MsgBox("Developer error in clsDataStructure:DoAddRecord. No value specified for field: " & strField & " when attempting to add a record.")
                Exit Sub
            End If
        Next

        ' This adds a row for the correction.
        ' The fields are named: 
        ' strId, strVersionNumber, lstValueFields, strCurrent, strVOld, strUpdateType
        ' strId is the same as in rowCurrent.
        ' strVersionNumber is the existing version number + 1
        ' strCurrent is the existing current
        ' strVOld is the existing version number
        ' strUpdateType is Correction
        ' The order is important.
        dtbWriteTable.Rows.Add(rowCurrent.Field(Of Integer)(strId), rowCurrent.Field(Of Integer)(GlobalVariables.strVersionNumber) + 1, lstValueFields.ToArray, rowCurrent.Field(Of Integer)(strCurrent), rowCurrent.Field(Of Integer)(GlobalVariables.strVersionNumber), GlobalVariables.UpdateType.Correction)
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
                    'TODO Need to get the entry "id" of the new record to be added
                    'GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, , Nothing, 1)
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
End Class
