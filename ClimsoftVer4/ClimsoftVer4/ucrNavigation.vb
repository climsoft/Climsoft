
Public Class ucrNavigation
    Public Event evtValueChanged(sender As Object, e As EventArgs)
    Private bFirstLoad As Boolean = True
    'Stores the number of the maximum rows in a data table
    Public iMaxRows As Integer
    'Stores the current row
    Public iCurrRow As Integer
    'Stores the sort by querry
    Public strSortCol As String = ""
    'Stores the dictonary of key controls and their fields
    Private dctKeyControls As New Dictionary(Of String, ucrValueView)
    Private ucrLinkedTableEntry As ucrTableEntry
    Public bSuppressKeyControlChanges As Boolean = False

    Private Sub ucrNavigation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            txtRecordNum.ReadOnly = True
            txtRecordNum.TextAlign = HorizontalAlignment.Center
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        If clsDataConnection.IsInDesignMode() Then
            Exit Sub ' temporary code to remove the bugs thrown during design time
        End If
        ' This is the cause of slow loading - getting all records into dtbRecords is slow.
        'MyBase.PopulateControl()
        If ucrLinkedTableEntry IsNot Nothing AndAlso ucrLinkedTableEntry.GetDataDefinition.GetFilter IsNot Nothing Then
            iMaxRows = clsDataDefinition.TableCount(ucrLinkedTableEntry.GetDataDefinition.GetFilter.Clone)
        Else
            iMaxRows = clsDataDefinition.TableCount()
        End If

        iCurrRow = 0
        currentRowDataPos = -1
        currentRowData = New Dictionary(Of String, String)
        'If strSortCol <> "" AndAlso dtbRecords.Columns.Contains(strSortCol) Then
        '    dtbRecords.DefaultView.Sort = strSortCol & " ASC"
        'End If
        displayRecordNumber()
        UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub
    ''' <summary>
    ''' Gets the value of the specified column (strFieldName) at the current row 
    ''' Returns empty string or nothing if no rows found or strFieldName is not specified
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <returns></returns>
    Public Function GetValue(Optional strFieldName As String = "") As Object
        If strFieldName = "" Then
            Return Nothing
        End If
        'If dtbRecords.Rows.Count > 0 Then
        '    Return dtbRecords.Rows(iCurrRow).Item(strFieldName)
        'Else
        '    Return ""
        'End If
        If iMaxRows > 0 Then
            Return GetValueFromRow(iCurrRow, strFieldName)
        Else
            Return ""
        End If
    End Function
    ''' <summary>
    ''' Displays the record number for the navigation control
    ''' Disables the navigation buttons if the selected row does not exist
    ''' </summary>
    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        If iCurrRow = -1 Then
            If CheckIfRowExistsInDb() Then
                txtRecordNum.Text = ClsTranslations.GetTranslation("Record Exists")
            Else
                txtRecordNum.Text = ClsTranslations.GetTranslation("New Record")
            End If

            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iMaxRows = 0 Then
            txtRecordNum.Text = ClsTranslations.GetTranslation("No Records")
            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iCurrRow >= 0 AndAlso iCurrRow < iMaxRows Then
            txtRecordNum.Text = ClsTranslations.GetTranslation("Record") & " " & iCurrRow + 1 & " " & ClsTranslations.GetTranslation("of") & " " & iMaxRows
            'enable navigation buttons
            EnableNavigationButtons(True)
        Else
            txtRecordNum.Text = ClsTranslations.GetTranslation("New Record")
            'disable navigation buttons
            EnableNavigationButtons(False)
        End If

    End Sub

    ''' <summary>
    ''' Enables or disables Navigation buttons 
    ''' </summary>
    Private Sub EnableNavigationButtons(bEnableState As Boolean)
        btnMoveFirst.Enabled = bEnableState
        btnMoveLast.Enabled = bEnableState
        btnMoveNext.Enabled = bEnableState
        btnMovePrevious.Enabled = bEnableState
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        MoveFirst()
    End Sub
    ''' <summary>
    ''' Moves to the first record of the current data table
    ''' </summary>
    Public Sub MoveFirst()
        iCurrRow = 0
        displayRecordNumber()
        UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        MovePrevious()
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        MoveNext()
    End Sub
    ''' <summary>
    ''' Moves to the next record of the current data table
    ''' </summary>
    Public Sub MoveNext()
        If iCurrRow < (iMaxRows - 1) Then
            iCurrRow = iCurrRow + 1
            displayRecordNumber()
            UpdateKeyControls()
            OnevtValueChanged(Me, Nothing)
        Else
            MessageBox.Show("No more next record!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        MoveLast()
    End Sub
    ''' <summary>
    ''' Moves to the previous record of the current data table
    ''' </summary>
    Public Sub MovePrevious()
        If iCurrRow > 0 Then
            iCurrRow = iCurrRow - 1
            displayRecordNumber()
            'OnevtValueChanged(sender, e)
            UpdateKeyControls()
            OnevtValueChanged(Me, Nothing)
        Else
            MessageBox.Show("No more previous record!", "Navigation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    ''' <summary>
    ''' Moves to the last record of the current data table
    ''' </summary>
    Public Sub MoveLast()
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        iCurrRow = iMaxRows - 1
        displayRecordNumber()
        UpdateKeyControls()
        OnevtValueChanged(Me, Nothing)
    End Sub


    Public Sub GoToNewRecord()
        'We could repopulate entirely or add a the last added record from the datatabase
        PopulateControl()
        MoveLast()


        'ALTERNATIVELY WE COULD JUST UPDATE THE DATATABLE WITH VALUES
        'FROM OUR KEY SELECTORS. HOWEVER, I DIDN'T IMPLEMENT IT THAT
        'WAY BECAUSE IF DATAENTRY IS BEING DONE BY MORE THAN ONE PERSON
        'SIMULTANEOUSLY WE MIGHT WANT THEM TO SEE THE CORRECT 
        'RECORD COUNT ON SAVE
    End Sub

    Public Sub RemoveRecord()
        PopulateControl()

        'ALTERNATIVELY WE COULD JUST REMOVE RECORD IN THE DATATABLE WITH VALUES
        'FROM OUR KEY SELECTORS. HOWEVER, I DIDN'T IMPLEMENT IT THAT
        'WAY BECAUSE IF DATAENTRY IS BEING DONE BY MORE THAN ONE PERSON
        'SIMULTANEOUSLY WE MIGHT WANT THEM TO SEE THE CORRECT 
        'RECORD COUNT ON DELETE
    End Sub

    ''' <summary>
    ''' Sets the column to be used in sorting. 
    ''' The passed column will be sorted in ascending order
    ''' </summary>
    ''' <param name="strNewSortCol"></param>
    Public Sub SetSortBy(strNewSortCol As String)
        strSortCol = strNewSortCol
    End Sub

    Public Sub SetTableEntry(ucrNewLinkedTableEntry As ucrTableEntry)
        ucrLinkedTableEntry = ucrNewLinkedTableEntry
        SetTableName(ucrLinkedTableEntry.GetTableName())
    End Sub

    ''' <summary>
    ''' this sets the table entry and the key controls(of the tabl entry control) to be controlled by the navigator
    ''' </summary>
    ''' <param name="ucrNewLinkedTableEntry"></param>
    Public Sub SetTableEntryAndKeyControls(ucrNewLinkedTableEntry As ucrTableEntry)
        'set the table entry control to be used by the navigator
        SetTableEntry(ucrNewLinkedTableEntry)
        'get the key controls to be used by the navigator from the table entry  
        Dim ucrCtrValueView As ucrValueView
        For Each ctr As Control In ucrNewLinkedTableEntry.Controls
            If TypeOf ctr Is ucrValueView Then
                ucrCtrValueView = DirectCast(ctr, ucrValueView)
                If (ucrCtrValueView.KeyControl) Then
                    AddKeyControls(ucrCtrValueView)
                End If
            End If
        Next
    End Sub
    Public Sub ClearKeyControls()
        dctKeyControls.Clear()
    End Sub

    Public Sub AddKeyControls(ucrKeyControl As ucrValueView)
        If dctKeyControls.ContainsKey(ucrKeyControl.FieldName) Then
            dctKeyControls.Item(ucrKeyControl.FieldName) = ucrKeyControl
        Else
            dctKeyControls.Add(ucrKeyControl.FieldName, ucrKeyControl)
            AddField(ucrKeyControl.FieldName)
        End If

        AddHandler ucrKeyControl.evtValueChanged, AddressOf KeyControls_evtValueChanged

    End Sub

    Private Sub KeyControls_evtValueChanged()
        'If Not bSuppressKeyControlChanges AndAlso iCurrRow <> -1 Then
        '    UpdateNavigationByKeyControls()
        'End If

        'this should always be called. The iCurrRow <> -1 check has been omitted because
        'of validation reasons. 
        If Not bSuppressKeyControlChanges Then
            UpdateNavigationByKeyControls()
        End If
    End Sub

    ''' <summary>
    ''' Updates the key controls by key values of the current record on the navigation
    ''' </summary>
    Private Sub UpdateKeyControls()
        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 Then
            bSuppressKeyControlChanges = True  'switch on suppressing of value changed events from key controls
            If iMaxRows > 0 Then
                For Each kvp As KeyValuePair(Of String, ucrValueView) In dctKeyControls

                    ' Use new GetValueFromRow method to get value from specific row since dtbRecords now nothing
                    kvp.Value.SetValue(GetValueFromRow(iCurrRow, kvp.Key))
                Next
            Else
                'To do set the defaults for the controls
                For Each kvp As KeyValuePair(Of String, ucrValueView) In dctKeyControls
                    If TypeOf kvp.Value Is ucrDataLinkCombobox Then
                        'Suppress events being raised while changing value of each key control
                        'kvp.Value.bSuppressChangedEvents = True
                        'Select the default value if there
                        DirectCast(kvp.Value, ucrDataLinkCombobox).SelectDefaultValue()
                        'kvp.Value.SetValue(dtbRecords.Rows(iCurrRow).Item(kvp.Key))
                        'kvp.Value.bSuppressChangedEvents = False
                    End If
                Next
            End If


            'Update the Table entry
            updateLinkedTableEntry()

            bSuppressKeyControlChanges = False  'switch off suppressing of value changed events from key controls
        End If
    End Sub


    ''' <summary>
    ''' Updates Navigation control to the recored with selected key
    ''' </summary>
    Private Sub UpdateNavigationByKeyControls()
        Dim dctFieldvalue As New Dictionary(Of String, String)
        Dim bRowExists As Boolean
        Dim row As Dictionary(Of String, String)

        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 AndAlso iMaxRows > 0 Then

            'check if its current row first before fetching from database
            bRowExists = True
            row = GetRow(iCurrRow)
            For Each kvp As KeyValuePair(Of String, ucrValueView) In dctKeyControls
                dctFieldvalue.Add(kvp.Key, kvp.Value.GetValue)
                If row.Count < 1 OrElse row.Item(kvp.Key) <> kvp.Value.GetValue Then
                    bRowExists = False
                End If
            Next

            'if its not the current row then fetch from the database
            If Not bRowExists Then
                'Returns -1 if no row found
                iCurrRow = GetRowPosition(dctFieldvalue)
            End If

            'if row already exists then try to notify the user
            If iCurrRow = -1 AndAlso CheckIfRowExistsInDb() Then
                'MsgBox("Record already entered. Saving it will not be permitted")
                MessageBox.Show(Me, "This record already exists. Saving it will not be permitted")
            End If

        End If

        bSuppressKeyControlChanges = True
        updateLinkedTableEntry()
        bSuppressKeyControlChanges = False
        displayRecordNumber()
    End Sub

    Private Sub updateLinkedTableEntry()
        If ucrLinkedTableEntry IsNot Nothing Then
            ucrLinkedTableEntry.PopulateControl()
        End If
    End Sub


    'TODO. Delete this subroutine
    'Public Sub UpdateNavigationByKeyControlsOLD()
    '    Dim dctFieldvalue As New Dictionary(Of String, String)
    '    Dim bRowExists As Boolean
    '    'Dim row As DataRow
    '    Dim row As Object

    '    If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 AndAlso iMaxRows > 0 Then
    '        iCurrRow = -1
    '        For Each kvp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeyControls
    '            dctFieldvalue.Add(kvp.Key, kvp.Value.GetValue)
    '        Next

    '        For i As Integer = 0 To iMaxRows - 1
    '            ' Here use GetRow() since we want multiple fields.
    '            row = GetRow(i)
    '            bRowExists = True
    '            For Each kvp As KeyValuePair(Of String, String) In dctFieldvalue

    '                'If Not (row(kvp.Key) = kvp.Value) Then
    '                If Not (CallByName(row, kvp.Key, CallType.Get) = kvp.Value) Then
    '                    bRowExists = False
    '                    Exit For
    '                End If
    '            Next
    '            If bRowExists Then
    '                iCurrRow = i
    '                Exit For
    '            End If
    '        Next
    '        displayRecordNumber()
    '    End If
    'End Sub


    'Private Sub ucrNavigation_evtValueChanged(sender As Object, e As EventArgs) Handles Me.evtValueChanged
    '    'UpdateKeyControls()
    'End Sub

    Public Sub NewRecord()
        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 Then
            bSuppressKeyControlChanges = True  'switch on suppressing of value changed events from key controls
            For Each kvp As KeyValuePair(Of String, ucrValueView) In dctKeyControls
                kvp.Value.Clear()
            Next

            'Update the Table entry
            updateLinkedTableEntry()

            iCurrRow = -1 'new record
            displayRecordNumber()

            bSuppressKeyControlChanges = False  'switch off suppressing of value changed events from key controls

        End If
    End Sub

    '----------------

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strSequencerTable"></param>
    ''' <param name="arrSequencerCols"></param>
    ''' <param name="dctSequencerColControls">
    ''' A dictionary of sequencer columns and it's correspondig controls.
    ''' key = Sequencer column. Must exist in the seqencer table
    ''' Value = Sequencer control. It's value is used for getting current sequencer position.
    ''' Also control will be set with the new sequencer value</param>
    ''' <param name="ucrYear"></param>
    ''' <param name="ucrMonth"></param>
    ''' <param name="ucrDay"></param>
    Public Sub NewSequencedRecord(strSequencerTable As String, arrSequencerCols() As String,
                                   dctSequencerColControls As Dictionary(Of String, ucrValueView),
                                    ucrYear As ucrYearSelector,
                                  Optional ucrMonth As ucrMonth = Nothing,
                                  Optional ucrDay As ucrDay = Nothing)


        If ucrLinkedTableEntry Is Nothing Then
            Exit Sub
        End If

        'move to the last record first
        MoveLast()

        'get all the sequencer values from the database
        Dim clsSeqDataCall As New DataCall
        Dim dtbSequencer As DataTable
        clsSeqDataCall.SetTableNameAndFields(strSequencerTable, arrSequencerCols)
        dtbSequencer = clsSeqDataCall.GetDataTable()

        'if there are elements sequencers
        If dtbSequencer.Rows.Count > 0 Then
            'create the select filter statement to be used for getting current sequencer row
            Dim strFilter As String = ""
            For Each kvpTemp As KeyValuePair(Of String, ucrValueView) In dctSequencerColControls
                If strFilter <> "" Then
                    strFilter = strFilter & " AND "
                End If
                strFilter = strFilter & kvpTemp.Key & " = " & Chr(39) & kvpTemp.Value.GetValue() & Chr(39)
            Next

            'get the current row index from the seqencer row and if exists then compute the next record
            Dim iCurrentSequencerRow As Integer = -1
            If strFilter <> "" Then
                iCurrentSequencerRow = dtbSequencer.Rows.IndexOf(dtbSequencer.Select(strFilter).FirstOrDefault)
            End If

            'if there is still another sequencer value then increment to it
            'change the sequencer control values to the first sequencer value
            Dim nextSequenceRowValues As DataRow
            If iCurrentSequencerRow > -1 AndAlso iCurrentSequencerRow < dtbSequencer.Rows.Count - 1 Then
                nextSequenceRowValues = dtbSequencer.Rows(iCurrentSequencerRow + 1)
            Else
                nextSequenceRowValues = dtbSequencer.Rows(0)
            End If
            IncrementSequencerColControlsValues(dctSequencerColControls, nextSequenceRowValues)
        End If

        'if still updating. try to increment the date controls
        If ucrLinkedTableEntry.bUpdating Then
            'change the sequencer control values to the first sequencer value
            'If dtbSequencer.Rows.Count > 0 Then
            'IncrementSequencerColControlsValues(dctSequencerColControls, dtbSequencer.Rows(0))
            'End If
            'increment date controls
            IncrementDateValues(ucrYear, ucrMonth, ucrDay)
        End If
    End Sub

    Private Sub IncrementSequencerColControlsValues(dctSequencerColControls As Dictionary(Of String, ucrValueView),
                                                   nextSequenceRowValues As DataRow)

        For Each kvpTemp As KeyValuePair(Of String, ucrValueView) In dctSequencerColControls
            kvpTemp.Value.bSuppressChangedEvents = True
            kvpTemp.Value.SetValue(nextSequenceRowValues.Item(kvpTemp.Key))
            kvpTemp.Value.bSuppressChangedEvents = False
        Next

        'only one control should trigger the event change
        dctSequencerColControls.Values(dctSequencerColControls.Count - 1).OnevtValueChanged(dctSequencerColControls.Values(dctSequencerColControls.Count - 1), Nothing)

    End Sub

    ''' <summary>
    ''' Increments the date controls.
    ''' This subroutine is recursive until 'Add New' state s achieved
    ''' </summary>
    ''' <param name="ucrYear">Null NOT allowed.</param>
    ''' <param name="ucrMonth">Null allowed. If null it's increment will be ignored</param>
    ''' <param name="ucrDay">Null allowed. If null it's increment will be ignored</param>
    Public Sub IncrementDateValues(ucrYear As ucrYearSelector, ucrMonth As ucrMonth, ucrDay As ucrDay)

        'try increment day value
        If ucrDay IsNot Nothing AndAlso ucrDay.cboValues.SelectedIndex < ucrDay.cboValues.Items.Count - 1 Then
            ucrDay.SetValue(ucrDay.GetValue + 1)
        ElseIf ucrMonth IsNot Nothing AndAlso ucrMonth.cboValues.SelectedIndex < ucrMonth.cboValues.Items.Count - 1 Then
            'set the date values in the following order. 
            'prevents unrepresentable date error
            If ucrDay IsNot Nothing Then
                ucrDay.SetValue(1)
            End If
            ucrMonth.SetValue(ucrMonth.GetValue + 1)
        Else
            'set the date values in the following order.
            'prevents unrepresentable date error
            If ucrDay IsNot Nothing Then
                ucrDay.SetValue(1)
            End If
            If ucrMonth IsNot Nothing Then
                ucrMonth.SetValue(1)
            End If
            ucrYear.SetValue(ucrYear.GetValue + 1)
        End If


        'if still updating. try to increment the date controls
        If ucrLinkedTableEntry.bUpdating Then
            IncrementDateValues(ucrYear, ucrMonth, ucrDay)
        End If

    End Sub


    '-----------------

    'todo. deprecated. delete
    Public Sub NewSequencerRecord(strSequencer As String, iEnumerableNewFields As IEnumerable(Of String), Optional iEnumerableDateIncrementControls As IEnumerable(Of ucrDataLinkCombobox) = Nothing, Optional ucrYear As ucrYearSelector = Nothing)
        Dim dctFields As New Dictionary(Of String, List(Of String))
        For Each strTemp As String In iEnumerableNewFields
            dctFields.Add(strTemp, New List(Of String)({strTemp}))
        Next
        'get the date controls; month and day
        Dim lstDateIncrementControls As List(Of ucrDataLinkCombobox) = Nothing
        If iEnumerableDateIncrementControls IsNot Nothing Then
            lstDateIncrementControls = iEnumerableDateIncrementControls.ToList
        End If

        NewSequencerRecord(strSequencer, dctFields, lstDateIncrementControls, ucrYear)

    End Sub

    'todo. deprecated. delete
    Public Sub NewSequencerRecord(strSequencerTable As String,
                                  dctTableFields As Dictionary(Of String, List(Of String)),
                                  Optional lstDateIncrementControls As List(Of ucrDataLinkCombobox) = Nothing,
                                  Optional ucrYear As ucrYearSelector = Nothing)
        Dim clsSeqDataCall As New DataCall
        Dim dtbSequencer As DataTable
        Dim dctKeySequencerControls As New Dictionary(Of String, ucrValueView)
        Dim strSelectStatement As String = ""
        Dim iCurrentSequencerRow As Integer

        MoveLast()

        If String.IsNullOrEmpty(strSequencerTable) OrElse
            ucrLinkedTableEntry Is Nothing OrElse
            dctKeyControls.Count < 1 Then
            Exit Sub
        End If

        'fill all the sequencer values from the database
        clsSeqDataCall.SetTableNameAndFields(strSequencerTable, dctTableFields)
        dtbSequencer = clsSeqDataCall.GetDataTable()

        'create the select filter statement to be used against the datatable
        For Each kvpTemp As KeyValuePair(Of String, ucrValueView) In dctKeyControls

            'todo. Later find a better solution
            'this check is temporary because of seq_element table that used element_code instead of elementid
            If kvpTemp.Key.ToLower.Contains("elementid") AndAlso dtbSequencer.Columns.Contains("element_code") Then
                dctKeySequencerControls.Add("element_code", kvpTemp.Value)
                If strSelectStatement <> "" Then
                    strSelectStatement = strSelectStatement & " AND "
                End If
                strSelectStatement = strSelectStatement & "element_code" &
                    " = " & Chr(39) & kvpTemp.Value.GetValue() & Chr(39)
                'important continue because above is temporary
                Continue For
            End If
            If dtbSequencer.Columns.Contains(kvpTemp.Key) Then
                dctKeySequencerControls.Add(kvpTemp.Key, kvpTemp.Value)
                If strSelectStatement <> "" Then
                    strSelectStatement = strSelectStatement & " AND "
                End If
                strSelectStatement = strSelectStatement & kvpTemp.Key & " = " & Chr(39) & kvpTemp.Value.GetValue() & Chr(39)
            End If
        Next

        'get the current row index from the seqencer row and if exists then compute the next record
        iCurrentSequencerRow = dtbSequencer.Rows.IndexOf(dtbSequencer.Select(strSelectStatement).FirstOrDefault)
        'If iCurrentSequencerRow > -1 Then
        'IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, iCurrentSequencerRow + 1, lstDateIncrementControls, ucrYear)
        'End If
        IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, iCurrentSequencerRow + 1, lstDateIncrementControls, ucrYear)

    End Sub

    'todo. deprecated. delete
    'Increments the sequncer values and tries to populate the table entry.
    Private Sub IncrementNextSequencerRowValues(dtbSequencer As DataTable,
                                                dctKeySequencerControls As Dictionary(Of String, ucrValueView), iSelectedSequencerRow As Integer, lstDateIncrementControls As List(Of ucrDataLinkCombobox), ucrYear As ucrYearSelector)
        If iSelectedSequencerRow >= 0 AndAlso
            iSelectedSequencerRow <= dtbSequencer.Rows.Count - 1 AndAlso
            dctKeySequencerControls.Count > 0 Then

            Dim rowNext As DataRow = dtbSequencer.Rows(iSelectedSequencerRow)
            For Each kvpTemp As KeyValuePair(Of String, ucrValueView) In dctKeySequencerControls
                kvpTemp.Value.bSuppressChangedEvents = True
                kvpTemp.Value.SetValue(rowNext.Item(kvpTemp.Key))
                kvpTemp.Value.bSuppressChangedEvents = False
            Next
            'only one control should trigger the event change
            dctKeySequencerControls.Values(dctKeySequencerControls.Count - 1).OnevtValueChanged(dctKeySequencerControls.Values(dctKeySequencerControls.Count - 1), Nothing)

            'if still updating
            If ucrLinkedTableEntry.bUpdating Then
                'go to the next sequencer values
                iSelectedSequencerRow = iSelectedSequencerRow + 1
                IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, iSelectedSequencerRow, lstDateIncrementControls, ucrYear)
            End If
        Else
            'try incrementing date values
            If lstDateIncrementControls IsNot Nothing AndAlso lstDateIncrementControls.Count > 0 Then
                Dim ucrTemp As ucrDataLinkCombobox
                Dim bIncrementYear As Boolean = False
                For j As Integer = 0 To lstDateIncrementControls.Count - 1
                    ucrTemp = lstDateIncrementControls(j)
                    If ucrTemp.cboValues.SelectedIndex < ucrTemp.cboValues.Items.Count - 1 Then
                        'TODO do this through SetValue() instead
                        'ucrTemp.cboValues.SelectedIndex = ucrTemp.cboValues.SelectedIndex + 1
                        ucrTemp.SetValue(ucrTemp.GetValue + 1) ' TODO. Test this 
                        Exit For
                    Else
                        'ucrTemp.cboValues.SelectedIndex = 0
                        ucrTemp.SelectDefaultValue() ' TODO. Test this 
                        If j = lstDateIncrementControls.Count - 1 Then
                            bIncrementYear = True
                        End If
                    End If
                Next

                If bIncrementYear Then
                    ucrYear.SetValue(ucrYear.GetValue() + 1)
                End If

                'if year is incremented the this will be false.
                If ucrLinkedTableEntry.bUpdating Then
                    If iSelectedSequencerRow <> -1 AndAlso dtbSequencer.Rows.Count > 0 Then
                        iSelectedSequencerRow = iSelectedSequencerRow + 1
                    End If
                    'go to the next sequencer value
                    IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, iSelectedSequencerRow, lstDateIncrementControls, ucrYear)
                Else
                    'go to the first sequencer value
                    If iSelectedSequencerRow <> -1 AndAlso dtbSequencer.Rows.Count > 0 AndAlso dctKeySequencerControls.Count > 0 Then
                        IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, 0, lstDateIncrementControls, ucrYear)
                    End If
                End If
            ElseIf ucrYear IsNot Nothing Then
                ucrYear.SetValue(ucrYear.GetValue() + 1)
                'if year is incremented the this will be false.
                If ucrLinkedTableEntry.bUpdating Then
                    'go to the first sequencer value
                    IncrementNextSequencerRowValues(dtbSequencer, dctKeySequencerControls, 0, lstDateIncrementControls, ucrYear)
                End If

            End If
        End If

    End Sub


    'get specific column value
    Private Function GetValueFromRow(iRow As Integer, strField As String) As String
        Dim dctRow As Dictionary(Of String, String) = GetRow(iRow)
        If dctRow.Count > 0 Then
            Return dctRow.Item(strField)
        Else
            Return Nothing
        End If
    End Function

    Private currentRowDataPos As Integer 'TODO probably these 2 can be merged in to key value pair? They have been used as to temporarily implement caching of values of current row.
    Private currentRowData As New Dictionary(Of String, String)

    'Gets the row details as dictionary of columns(fields) and value
    Private Function GetRow(iRow As Integer) As Dictionary(Of String, String)
        'holds column name(as key) and column value(as the value)
        Dim dctRow As New Dictionary(Of String, String)
        Dim strSql As String
        Dim strFields As String = ""

        'if its a negative just abort
        If iRow < 0 Then
            Return dctRow 'empty row
        End If

        'if iRow is still the current row then just return the current row data 
        If currentRowDataPos = iRow AndAlso currentRowData.Count > 0 Then
            Return currentRowData
        End If

        'get all the fields
        For Each str As String In clsDataDefinition.GetFields().Keys
            If strFields = "" Then
                strFields = str
            Else
                strFields = strFields & "," & str
            End If
        Next

        'construct the sql
        strSql = "SELECT " & strFields & " FROM " & clsDataDefinition.GetTableName()

        If ucrLinkedTableEntry IsNot Nothing AndAlso ucrLinkedTableEntry.GetDataDefinition.GetFilter IsNot Nothing Then
            strSql = strSql & " WHERE " & ucrLinkedTableEntry.GetDataDefinition.GetFilter.Clone.GetSqlExpression
        End If


        If strSortCol <> "" Then
            strSql = strSql & " ORDER BY " & strSortCol
        End If
        strSql = strSql & " LIMIT 1 OFFSET " & iRow


        Dim dtbl As DataTable = clsDataDefinition.GetDataTableFromQuery(strSql)
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each str As String In clsDataDefinition.GetFields().Keys
                dctRow.Add(str, dtbl.Rows(0).Item(str))
            Next
        End If

        currentRowDataPos = iRow
        currentRowData = dctRow
        Return dctRow
    End Function


    Private Function CheckIfRowExistsInDb() As Boolean
        Dim iRowsFound As Integer = -1
        Dim clsOverallControlsFilter As TableFilter = ucrLinkedTableEntry.GetLinkedControlsFilter

        If clsOverallControlsFilter IsNot Nothing Then
            iRowsFound = clsDataDefinition.TableCount(clsOverallControlsFilter.Clone)
        End If

        Return iRowsFound > 0
    End Function


    'TODO. Change how this is implemented
    'Gets the row position. The parameter is dictionary of column names and the values to fetch
    Private Function GetRowPosition(dctFieldvalue As Dictionary(Of String, String)) As Integer
        Dim rowPosition As Integer = -1 ' default row position
        Dim strSql As String
        Dim strFields As String = ""
        Dim i As Integer
        Dim bIsRowFetched As Boolean

        Try

            'get all the fields and their condition values
            For Each kvp As KeyValuePair(Of String, String) In dctFieldvalue
                If strFields = "" Then
                    strFields = kvp.Key
                Else
                    strFields = strFields & "," & kvp.Key
                End If
            Next

            strSql = "SELECT " & strFields & " FROM " & clsDataDefinition.GetTableName()

            If ucrLinkedTableEntry IsNot Nothing AndAlso ucrLinkedTableEntry.GetDataDefinition.GetFilter IsNot Nothing Then
                strSql = strSql & " WHERE " & ucrLinkedTableEntry.GetDataDefinition.GetFilter.Clone.GetSqlExpression
            End If

            If strSortCol <> "" Then
                strSql = strSql & " ORDER BY " & strSortCol
            End If

            'fetch the row positions
            'todo. in future a query like this could be used to get the row position instead of the reader
            'Select Case pos, SteamId FROM ( Select Case (@pos := @pos+1) pos , Map, Time, Date, SteamID
            'FROM `surf_times` S, (SELECT @pos := 0) p WHERE `Map` = "surf_mesa"  ORDER BY `Time` ) `surf_times` WHERE `SteamID` = "76561198065863390" ORDER BY pos LIMIT 1;

            i = 0
            Using Command As New MySqlConnector.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
                Using reader As MySqlConnector.MySqlDataReader = Command.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read()
                            bIsRowFetched = True
                            For Each kvp As KeyValuePair(Of String, String) In dctFieldvalue
                                If kvp.Value <> reader.GetString(kvp.Key) Then
                                    bIsRowFetched = False
                                    Exit For
                                End If
                            Next

                            If bIsRowFetched Then
                                rowPosition = i
                                Exit While
                            End If
                            i = i + 1
                        End While
                    End If

                End Using
            End Using


        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

        Return rowPosition
    End Function

    Public Sub OnevtValueChanged(sender As Object, e As EventArgs)
        ' If Not bSuppressChangedEvents Then
        RaiseEvent evtValueChanged(sender, e)
        'End If
    End Sub

End Class