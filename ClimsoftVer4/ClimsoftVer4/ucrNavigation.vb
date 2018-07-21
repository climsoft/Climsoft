Public Class ucrNavigation
    Private bFirstLoad As Boolean = True
    'Stores the number of the maximum rows in a data table
    Public iMaxRows As Integer
    'Stores the current row
    Public iCurrRow As Integer
    'Stores the sort by querry
    Public strSortCol As String = ""
    'Stors the dictonary of key controls and their fields
    Private dctKeyControls As Dictionary(Of String, ucrBaseDataLink)

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        iCurrRow = 0
        iMaxRows = dtbRecords.Rows.Count
        If strSortCol <> "" AndAlso dtbRecords.Columns.Contains(strSortCol) Then
            dtbRecords.DefaultView.Sort = strSortCol & " ASC"
        End If
        displayRecordNumber()
        UpdateKeyControls()
    End Sub
    ''' <summary>
    ''' Gets the value of the specified column(strFieldName) at the current row 
    ''' Returns empty string or nothing if no rows found or strFieldName is not specified
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <returns></returns>
    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        If strFieldName = "" Then
            Return Nothing
        End If

        If dtbRecords.Rows.Count > 0 Then
            Return dtbRecords.Rows(iCurrRow).Item(strFieldName)
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
            txtRecNum.Text = "New Record"
            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iMaxRows = 0 Then
            txtRecNum.Text = "No Records"
            'disable navigation buttons
            EnableNavigationButtons(False)
        ElseIf iCurrRow >= 0 AndAlso iCurrRow < iMaxRows Then
            txtRecNum.Text = "Record " & iCurrRow + 1 & " of " & iMaxRows
            'enable navigation buttons
            EnableNavigationButtons(True)
        Else
            txtRecNum.Text = "New Record"
            'disable navigation buttons
            EnableNavigationButtons(False)
        End If

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
    End Sub

    Public Sub SetKeyControls(dctNewKeyControls As Dictionary(Of String, ucrBaseDataLink))
        dctKeyControls = dctNewKeyControls
    End Sub
    'TODO
    'NOT SURE WHETHER TO CALL THIS AddKeyControls or SetKeyControls
    ''' <summary>
    ''' Sets the key controls and their key field. 
    ''' The field must be unique. If the field is found, the old ucrKeyControl is discarded
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <param name="ucrKeyControl"></param>
    Public Sub SetKeyControls(strFieldName As String, ucrKeyControl As ucrBaseDataLink)
        If dctKeyControls Is Nothing Then
            SetKeyControls(New Dictionary(Of String, ucrBaseDataLink))
        End If

        If dctKeyControls.ContainsKey(strFieldName) Then
            If dctKeyControls.Item(strFieldName) Is ucrKeyControl Then
                MessageBox.Show("Developer error: Attempt to set key control twice detected : " & ucrKeyControl.Name, caption:="Developer error")
            Else
                dctKeyControls.Item(strFieldName) = ucrKeyControl
            End If
        Else
            dctKeyControls.Add(strFieldName, ucrKeyControl)
        End If
    End Sub
    ''' <summary>
    ''' Updates the key controls by key values of the current record on the navigation
    ''' </summary>
    Private Sub UpdateKeyControls()
        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 Then
            If iMaxRows > 0 Then
                For Each kvp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeyControls
                    'Suppress events being raised while changing value of each key control
                    kvp.Value.bSuppressChangedEvents = True
                    kvp.Value.SetValue(dtbRecords.Rows(iCurrRow).Item(kvp.Key))
                    kvp.Value.bSuppressChangedEvents = False
                Next
            End If

            'A key control eventvalue changed should always be raised regardless of whether iMaxRows > 0 or not
            ' All key controls are linked to the same controls so can just trigger
            ' events for one control after all updated
            dctKeyControls.Values(dctKeyControls.Count - 1).OnevtValueChanged(dctKeyControls.Values(dctKeyControls.Count - 1), Nothing)

        End If
    End Sub
    ''' <summary>
    ''' Updates Navigation control to the recored with selected key
    ''' </summary>
    Public Sub UpdateNavigationByKeyControls()
        Dim dctFieldvalue As New Dictionary(Of String, String)
        Dim bRowExists As Boolean
        Dim row As DataRow

        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 AndAlso iMaxRows > 0 Then
            iCurrRow = -1
            For Each kvp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeyControls
                dctFieldvalue.Add(kvp.Key, kvp.Value.GetValue)
            Next

            For i As Integer = 0 To dtbRecords.Rows.Count - 1
                row = dtbRecords.Rows(i)
                bRowExists = True
                For Each kvp As KeyValuePair(Of String, String) In dctFieldvalue

                    If Not (row(kvp.Key) = kvp.Value) Then
                        bRowExists = False
                        Exit For
                    End If
                Next
                If bRowExists Then
                    iCurrRow = i
                    Exit For
                End If
            Next
            displayRecordNumber()
        End If
    End Sub

    Private Sub ucrNavigation_evtValueChanged(sender As Object, e As EventArgs) Handles Me.evtValueChanged
        'UpdateKeyControls()
    End Sub

    Private Sub ucrNavigation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            txtRecNum.ReadOnly = True
            txtRecNum.TextAlign = HorizontalAlignment.Center
            bFirstLoad = False
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

    Public Sub NewSequencerRecord(strSequencer As String, dctFields As Dictionary(Of String, List(Of String)), Optional lstDateIncrementControls As List(Of ucrDataLinkCombobox) = Nothing, Optional ucrYear As ucrYearSelector = Nothing)
        Dim clsSeqDataCall As New DataCall
        Dim dtbSequencer As DataTable
        Dim dctKeySequencerControls As New Dictionary(Of String, ucrBaseDataLink)
        Dim strSelectStatement As String = ""
        Dim rowsFitered As DataRow()
        Dim iCurrRow As Integer
        Dim rowNext As DataRow
        Dim ucrTemp As ucrDataLinkCombobox
        Dim bIncrementYear As Boolean = False

        MoveLast()

        If String.IsNullOrEmpty(strSequencer) Then
            Exit Sub
        End If

        clsSeqDataCall.SetTableNameAndFields(strSequencer, dctFields)
        dtbSequencer = clsSeqDataCall.GetDataTable()

        For Each kvpTemp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeyControls
            If dtbSequencer.Columns.Contains(kvpTemp.Key) Then
                dctKeySequencerControls.Add(kvpTemp.Key, kvpTemp.Value)
                If strSelectStatement <> "" Then
                    strSelectStatement = strSelectStatement & " AND "
                End If
                strSelectStatement = strSelectStatement & kvpTemp.Key & " = " & Chr(39) & kvpTemp.Value.GetValue() & Chr(39)
            End If
        Next
        rowsFitered = dtbSequencer.Select(strSelectStatement)
        If rowsFitered.Count > 0 Then
            'TODO take first row or last row?
            iCurrRow = dtbSequencer.Rows.IndexOf(rowsFitered(0))
            If iCurrRow < dtbSequencer.Rows.Count - 1 Then
                rowNext = dtbSequencer.Rows(iCurrRow + 1)
            Else
                rowNext = dtbSequencer.Rows(0)
                If lstDateIncrementControls IsNot Nothing AndAlso lstDateIncrementControls.Count > 0 Then
                    For j As Integer = 0 To lstDateIncrementControls.Count - 1
                        ucrTemp = lstDateIncrementControls(j)
                        If ucrTemp.cboValues.SelectedIndex < ucrTemp.cboValues.Items.Count - 1 Then
                            'TODO do this through SetValue() instead
                            ucrTemp.cboValues.SelectedIndex = ucrTemp.cboValues.SelectedIndex + 1
                            Exit For
                        Else
                            ucrTemp.cboValues.SelectedIndex = 0
                            If j = lstDateIncrementControls.Count - 1 Then
                                bIncrementYear = True
                            End If
                        End If
                    Next
                    If bIncrementYear Then
                        ucrYear.SetValue(ucrYear.GetValue() + 1)
                    End If
                End If
            End If
            For Each kvpTemp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeySequencerControls
                kvpTemp.Value.SetValue(rowNext.Item(kvpTemp.Key))
            Next
        Else
            'First item in sequencer?
        End If

    End Sub

End Class