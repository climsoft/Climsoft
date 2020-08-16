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

    ''' <summary>
    ''' A string, the name of the table in the database this DataStructure links.
    ''' </summary>
    Private strTableName As String

    ''' <summary>
    ''' A string, how the "id" column is stored in the database in all tables it appears in.
    ''' This could be moved to a separate class of constants.
    ''' </summary>
    Protected strId As String = "id"

    ''' <summary>
    ''' A string, how the "current"/"current best" column is stored in <c>strTableName</c>.
    ''' This is "current_best" by default and expected to be either be "current" or "current_best".
    ''' </summary>
    Private strCurrent As String = "current_best"

    ''' <summary>
    ''' A list of strings, the names of the fields in <c>strTableName</c> which uniquely define a row.
    ''' In most tables and by default this is <c>{strId, GlobalVariables.strVersionNumber}</c> but it is not in all and can be changed.
    ''' </summary>
    Private lstKeyFieldNames As List(Of String) = New List(Of String)({strId, GlobalVariables.strVersionNumber})

    ''' <summary>
    ''' A list of strings, the names of the fields in <c>strTableName</c> which do not relate to primary key or auditting 
    ''' i.e. in most cases all columns apart from: <c>strID</c>, <c>GlobalVariables.strVersionNumber</c> and <c>strCurrent</c>.
    ''' </summary>
    ''' <remarks>
    ''' This is used when adding a new record. To add a new record, a value must be specified for each of <c>lstValueFields</c>.
    ''' </remarks>
    Private lstValueFields As List(Of String)

    ' A TableFilter object which defines the rows in the table the values will be from
    Private clsFilter As TableFilter

    ''' <summary>
    ''' A <c>DataTable</c> storing the data read from the database.
    ''' This remains static once fetched from the database.
    ''' </summary>
    Private dtbReadTable As DataTable

    ''' <summary>
    ''' A <c>DataTable</c> storing the new data to be written to the database. 
    ''' This builds up as controls change. It is a clone of <c>dtbReadTable</c> 
    ''' with two extra columns: v_old and update_type
    ''' </summary>
    Private dtbUpdateTable As DataTable

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
    Private lstLinkedDataStructures As New List(Of DataStructure)

    ''' <summary>
    ''' This event is raised when <c>dtbReadTable</c> changes.
    ''' The navigator and page control will listen for this and update their values when this event is raised.
    ''' </summary>
    Public Event DataChanged()

    ''' <summary>Field name for "version old" when constructing <c>dtbUpdateTable</c>.</summary>
    Private strVOld As String = ".v_old"

    ''' <summary>Field name for "update type" when constructing <c>dtbUpdateTable</c>.</summary>
    Private strUpdateType As String = ".update_type"

    Public Sub New()

    End Sub

    Public Sub New(strNewTableName As String)
        SetTableName(strTableName)
    End Sub

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
    ''' Set the names of the fields in <c>strTableName</c> which uniquely define a row. This is
    ''' needed when updating records. In most tables and by default this is <c>{strId,
    ''' strVersionNumber}</c>. This method should only be used if it is different to the default.
    ''' </summary>
    '''
    ''' <param name="iEnumerableNewKeyFields">  The list of names of the key fields for <c>strTableName</c>.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub SetKeyFields(iEnumerableNewKeyFields As IEnumerable(Of String))
        lstKeyFieldNames = iEnumerableNewKeyFields.ToList()
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Set the names of the fields in <c>strTableName</c> which do not relate to primary key of auditting 
    ''' i.e. in most cases all columns apart from: <c>strID</c>, <c>GlobalVariables.strVersionNumber</c> and <c>strCurrent</c>.
    ''' </summary>
    '''
    ''' <param name="iEnumerableNewValueFields">  The list of names of the value fields for <c>strTableName</c>.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub SetValueFields(iEnumerableNewValueFields As IEnumerable(Of String))
        lstValueFields = iEnumerableNewValueFields.ToList()
    End Sub

    ' Set the TableFilter
    Public Sub SetFilter(clsNewFilter As TableFilter)
        clsFilter = clsNewFilter
    End Sub

    ' Alternative method to set the TableFilter
    Public Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        Dim clsNewFilter As New TableFilter

        clsNewFilter.SetFieldCondition(strNewField:=strField, strNewOperator:=strOperator, objNewValue:=strValue, bNewIsPositiveCondition:=bIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
        SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    ' Gets the data from database for strTableName and fills in dtbReadTable
    ' bIncludedLinked - should linked DataStructure's also update their dtbReadTable?
    Public Sub UpdateReadTable(Optional bIncludedLinked As Boolean = False)
        'TODO suspect this will be similar to DataCall.GetDataTable()

        If bIncludedLinked Then
            For Each clsLinkedStruc As DataStructure In lstLinkedDataStructures
                clsLinkedStruc.UpdateReadTable(bIncludedLinked)
            Next
        End If
    End Sub

    ' Returns dtbReadTable
    Public Function GetReadTable() As DataTable
        Return dtbReadTable
    End Function

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Initialises <c>dtbUpdateTable</c> as a clone of <c>dtbReadTable</c> with two extra columns. 
    ''' This should be called after <c>UpdateReadTable()</c> has been called.
    ''' </summary>
    '''
    ''' <remarks> <c>.Clone</c> copies the structure but not the data of a <c>DataTable</c>. </remarks>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Private Sub InitialiseUpdateTable()
        If dtbReadTable IsNot Nothing Then
            dtbUpdateTable = dtbReadTable.Clone()
            dtbUpdateTable.Columns.Add(strVOld, GetType(Integer))
            dtbUpdateTable.Columns.Add(strUpdateType, GetType(Integer))
        End If
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>
    ''' Sets the comments associated with <c>strTableName</c> and stores them in <c>dtbComments</c>.
    ''' This may be called when getting the main data, or may only be called on demand.
    ''' </summary>
    '''
    ''' <param name="bAllVersions"> (Optional) Boolean, if <c>True</c> all versions returned, if
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

    ' Sets the lstLinkedDataStructures list
    ' TODO Are there more useful ways to set this instead of passing in a list directly?
    Public Sub SetLinkedDataStructures(lstNewListedDataStructures As List(Of DataStructure))

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

        ' This adds a row for the fields: 
        ' strId, strVersionNumber, lstValueFields(), strCurrent, strVOld, strUpdateType
        ' The value for strId is DBNull.Value since this will be auto incremented in the database.
        ' The order is important.
        ' TODO: If this method will also be used for adding to the audit table then it will need to be adapted as it does not have the same id, version number, current structure
        dtbUpdateTable.Rows.Add(DBNull.Value, 1, lstValueFields.ToArray, 1, DBNull.Value, GlobalVariables.UpdateType.NewRecord)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Adds rows to <c>dtbUpdateTable</c> to indicate a new and/or change to an event which
    '''             causes records to change.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    ''' <param name="rcEventChanges">A collection of <c>DataRow</c>s for all event changes. These rows should
    '''                              have the same structure as <c>dtbReadTable</c>. 
    '''                              This may be nothing if there are no event changes.
    '''                              </param>
    ''' <param name="rowEventNew">A <c>DataRow</c> for a new event. This row should have the same structure 
    '''                           as <c>dtbReadTable</c>. This may be nothing if there is no new event.
    '''                           </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoEvent(Optional rcEventChanges() As DataRow = Nothing, Optional rowEventNew As DataRow = Nothing)
        Dim rowNew As DataRow

        ' Add the rows for the event changes.
        If rcEventChanges IsNot Nothing Then
            For Each rowCurrent As DataRow In rcEventChanges
                rowNew = dtbUpdateTable.NewRow()
                For i = 0 To rowCurrent.ItemArray.Count - 1
                    rowNew.Item(i) = rowCurrent.ItemArray(i)
                Next
                rowNew.Item(strVOld) = DBNull.Value
                rowNew.Item(strUpdateType) = GlobalVariables.UpdateType.EventChange
                dtbUpdateTable.Rows.Add(rowNew)
            Next
        End If

        ' Add a row for the new event
        If rowEventNew IsNot Nothing Then
            rowNew = dtbUpdateTable.NewRow()
            For i = 0 To rowEventNew.ItemArray.Count - 1
                rowNew.Item(i) = rowEventNew.ItemArray(i)
            Next
            rowNew.Item(strVOld) = DBNull.Value
            rowNew.Item(strUpdateType) = GlobalVariables.UpdateType.EventNew
            dtbUpdateTable.Rows.Add(rowNew)
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
        Dim lstNewRecordItems As New List(Of Object)

        ' Add the row for the correction to the existing row. The only change is current set to NULL.
        rowCurrentUpdate = dtbUpdateTable.NewRow()
        For i = 0 To rowCurrent.ItemArray.Count - 1
            rowCurrentUpdate.Item(i) = rowCurrent.ItemArray(i)
        Next
        rowCurrentUpdate.Item(strCurrent) = DBNull.Value
        rowCurrentUpdate.Item(strVOld) = rowCurrentUpdate.Item(GlobalVariables.strVersionNumber)
        rowCurrentUpdate.Item(strUpdateType) = GlobalVariables.UpdateType.CorrectionOld
        dtbUpdateTable.Rows.Add(rowCurrentUpdate)

        ' TODO Should be moved to separate function as duplicated elsewhere.
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
        lstNewRecordItems.Add(rowCurrent.Field(Of Integer)(strId))
        lstNewRecordItems.Add(rowCurrent.Field(Of Integer)(GlobalVariables.strVersionNumber) + 1)
        lstNewRecordItems.AddRange(lstValues.ToArray)
        lstNewRecordItems.Add(rowCurrent.Field(Of Integer)(strCurrent))
        lstNewRecordItems.Add(rowCurrent.Field(Of Integer)(GlobalVariables.strVersionNumber))
        lstNewRecordItems.Add(GlobalVariables.UpdateType.CorrectionNew)
        dtbUpdateTable.Rows.Add(lstNewRecordItems.ToArray)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   
    '''             Adds a rows to <c>dtbUpdateTable</c> to indicate a deleted record.
    '''             This is only sent to the database when <c>DoAction</c> is called.
    ''' </summary>
    ''' <param name="rowDelete">The <c>DataRow</c> to be deleted.</param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub DoDeleteRecord(rowDelete As DataRow)
        Dim lstValues As New List(Of Object)
        Dim rowDeleteUpdate As DataRow

        ' Add the row for the deletion.
        rowDeleteUpdate = dtbUpdateTable.NewRow()
        For i = 0 To rowDelete.ItemArray.Count - 1
            rowDeleteUpdate.Item(i) = rowDelete.ItemArray(i)
        Next
        rowDeleteUpdate.Item(strCurrent) = DBNull.Value
        rowDeleteUpdate.Item(strVOld) = rowDeleteUpdate.Item(GlobalVariables.strVersionNumber)
        rowDeleteUpdate.Item(strUpdateType) = GlobalVariables.UpdateType.Delete
        dtbUpdateTable.Rows.Add(rowDeleteUpdate)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary> Executes the action operation. </summary>
    ''' 
    ''' <remarks>This could be moved to a separate class?</remarks>
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
        ' TODO Create comment for action comment and add to comment table

        ' Sends changes from the update table to the database for DataStructures
        DataStruct.UpdateTable(iActionTypeID)
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Performs the updates to the tables in this <c>DataStructure</c> associated with 
    '''             the action with id <c>iActionID</c>. This including writing the audit, comments, 
    '''             and events.
    '''             </summary>
    '''
    ''' <param name="iActionID"> The ID of the action being performed. </param>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub UpdateTable(iActionID As Integer)
        Dim dtbAuditTable As DataTable
        Dim iUpdateType As Integer
        Dim dtbWriteTable As DataTable

        ' dtbWriteTable will write changes to the database. A copy of dtbUpdateTable with last two columns removed.
        dtbWriteTable = Me.dtbUpdateTable.Copy()
        dtbWriteTable.Columns.Remove(strVOld)
        dtbWriteTable.Columns.Remove(strUpdateType)

        ' Make a blank audit table to add entries to
        dtbAuditTable = GlobalVariables.dtbEmptyAuditTable

        ' Construct the audit table
        For i As Integer = 0 To Me.dtbUpdateTable.Rows.Count - 1
            iUpdateType = dtbUpdateTable.Rows(i).Field(Of Integer)(strUpdateType)
            Select Case iUpdateType
                Case GlobalVariables.UpdateType.NewRecord
                    'TODO Need to get the entry "id" of the new record to be added - replace 9999
                    GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, 9999, Nothing, 1)
                Case GlobalVariables.UpdateType.CorrectionOld
                    ' No audit entry to add
                Case GlobalVariables.UpdateType.CorrectionNew
                    GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, dtbUpdateTable.Rows(i).Field(Of Integer)(strId), dtbUpdateTable.Rows(i).Field(Of Integer)(strVOld), dtbUpdateTable.Rows(i).Field(Of Integer)(GlobalVariables.strVersionNumber))
                Case GlobalVariables.UpdateType.EventChange
                    ' No audit entry to add
                Case GlobalVariables.UpdateType.EventNew
                    GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, dtbUpdateTable.Rows(i).Field(Of Integer)(strId), Nothing, dtbUpdateTable.Rows(i).Field(Of Integer)(GlobalVariables.strVersionNumber))
                Case GlobalVariables.UpdateType.Delete
                    GlobalVariables.AddToAuditTable(dtbAuditTable, iActionID, strTableName, dtbUpdateTable.Rows(i).Field(Of Integer)(strId), dtbUpdateTable.Rows(i).Field(Of Integer)(GlobalVariables.strVersionNumber), Nothing)
            End Select
        Next

        ' Write: update table, audit table, comments table, events table
        ' TODO call methods to write to the database using the data adapter

        ' Call UpdateTable for each lstLinkedDataStructures
        For Each clsLinkedStruc As DataStructure In lstLinkedDataStructures
            clsLinkedStruc.UpdateTable(iActionID)
        Next
    End Sub

    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Test of updating values. </summary>
    '''
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Sub TestUpdateTable()
        Dim dctCorrectionValues As New Dictionary(Of String, Object)
        Dim dtbExpectedUpdateTable As DataTable
        Dim dtbTempReadTable As DataTable
        Dim rowTempEvent1 As DataRow
        Dim rowTempEvent2 As DataRow
        Dim rcTempEventChanges() As DataRow

        dtbReadTable = New DataTable
        dtbReadTable.Columns.Add(strId, GetType(Integer))
        dtbReadTable.Columns.Add(GlobalVariables.strVersionNumber, GetType(Integer))
        dtbReadTable.Columns.Add("value", GetType(String))
        dtbReadTable.Columns.Add(strCurrent, GetType(Integer))

        ' Temporary read table used to create new rows that are passed in to Do methods
        dtbTempReadTable = dtbReadTable.Clone()

        dtbReadTable.Rows.Add(1, 1, "a", 1)
        dtbReadTable.Rows.Add(2, 1, "b", 1)
        dtbReadTable.Rows.Add(3, 1, "c", 1)
        dtbReadTable.Rows.Add(4, 1, "dd", 1)
        dtbReadTable.Rows.Add(4, 2, "ddd", 2)
        dtbReadTable.Rows.Add(5, 1, "e", 1)

        InitialiseUpdateTable()

        SetValueFields({"value"})

        '' CHANGES
        ' Correction in id=1 from "a" to "A"
        dctCorrectionValues.Add("value", "A")
        DoCorrectionToRecord(dtbReadTable.Rows(0), dctCorrectionValues)

        ' Event change in id=2 "b" to "bb"
        ' New event added after existing event - no change to existing event
        dtbTempReadTable.ImportRow(dtbReadTable.Rows(1))
        rowTempEvent1 = dtbTempReadTable.Rows(dtbTempReadTable.Rows.Count - 1)
        rowTempEvent1.Item("value") = "bb"
        rowTempEvent1.Item(GlobalVariables.strVersionNumber) = rowTempEvent1.Field(Of Integer)(GlobalVariables.strVersionNumber) + 1
        rowTempEvent1.Item(strCurrent) = rowTempEvent1.Field(Of Integer)(strCurrent) + 1
        DoEvent(rowEventNew:=rowTempEvent1)

        ' Delete in id=3
        DoDeleteRecord(dtbReadTable.Rows(2))

        ' Event change in id=4
        ' New event added before existing two events, changes required to both existing events
        dtbTempReadTable.ImportRow(dtbReadTable.Rows(3))
        rowTempEvent2 = dtbTempReadTable.Rows(dtbTempReadTable.Rows.Count - 1)
        rowTempEvent2.Item("value") = "d"
        rowTempEvent2.Item(GlobalVariables.strVersionNumber) = 3
        rowTempEvent2.Item(strCurrent) = 1
        rcTempEventChanges = dtbReadTable.Select("id = 4")
        rcTempEventChanges(0).Item(strCurrent) = 2
        rcTempEventChanges(1).Item(strCurrent) = 3
        DoEvent(rcTempEventChanges, rowTempEvent2)

        dtbExpectedUpdateTable = dtbReadTable.Clone()
        dtbExpectedUpdateTable.Columns.Add(strVOld, GetType(Integer))
        dtbExpectedUpdateTable.Columns.Add(strUpdateType, GetType(Integer))
        dtbExpectedUpdateTable.Rows.Add(1, 1, "a", DBNull.Value, 1, GlobalVariables.UpdateType.CorrectionOld)
        dtbExpectedUpdateTable.Rows.Add(1, 2, "A", 1, 1, GlobalVariables.UpdateType.CorrectionNew)
        dtbExpectedUpdateTable.Rows.Add(2, 2, "bb", 2, DBNull.Value, GlobalVariables.UpdateType.EventNew)
        dtbExpectedUpdateTable.Rows.Add(3, 1, "c", DBNull.Value, 1, GlobalVariables.UpdateType.Delete)
        dtbExpectedUpdateTable.Rows.Add(4, 3, "d", 1, DBNull.Value, GlobalVariables.UpdateType.EventNew)
        dtbExpectedUpdateTable.Rows.Add(4, 1, "dd", 2, DBNull.Value, GlobalVariables.UpdateType.EventChange)
        dtbExpectedUpdateTable.Rows.Add(4, 2, "ddd", 3, DBNull.Value, GlobalVariables.UpdateType.EventChange)

        UpdateTable(1)
    End Sub
End Class
