Public Class ucrNavigation
    Private bFirstLoad As Boolean = True
    Public iMaxRows As Integer
    Public iCurrRow As Integer
    Public strSortCol As String = ""
    Private dctKeyControls As Dictionary(Of String, ucrBaseDataLink)

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        iCurrRow = 0
        iMaxRows = dtbRecords.Rows.Count
        If strSortCol <> "" AndAlso dtbRecords.Rows.Count > 0 AndAlso dtbRecords.Columns.Contains(strSortCol) Then
            dtbRecords.DefaultView.Sort = strSortCol & " ASC"
        End If
        displayRecordNumber()
        UpdateKeyControls()
    End Sub

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        If strFieldName = "" Then
            Return Nothing
        End If

        If dtbRecords.Rows.Count > 0 Then
            'Return dtbRecords.Rows(iCurrRow).Field(Of Object)(strFieldName)
            Return dtbRecords.Rows(iCurrRow).Item(strFieldName)
        Else
            Return ""
        End If
    End Function

    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        If iMaxRows = 0 Then
            txtRecNum.Text = "No Records"
        ElseIf iCurrRow >= 0 AndAlso iCurrRow < iMaxRows Then
            txtRecNum.Text = "Record " & iCurrRow + 1 & " of " & iMaxRows
        Else
            txtRecNum.Text = "New Record"
            SetControlsForNewRecord()
        End If

    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        iCurrRow = 0
        displayRecordNumber()
        'OnevtValueChanged(sender, e)
        UpdateKeyControls()
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        MovePrevious()
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        If iCurrRow < (iMaxRows - 1) Then
            iCurrRow = iCurrRow + 1
            displayRecordNumber()
            'OnevtValueChanged(sender, e)
            UpdateKeyControls()
        Else
            MsgBox("No more next record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        MoveLast()
    End Sub

    Public Sub MovePrevious()
        If iCurrRow > 0 Then
            iCurrRow = iCurrRow - 1
            displayRecordNumber()
            'OnevtValueChanged(sender, e)
            UpdateKeyControls()
        Else
            MsgBox("No more previous record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub MoveLast()
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        iCurrRow = iMaxRows - 1
        displayRecordNumber()
        'OnevtValueChanged(sender, e)
        UpdateKeyControls()
    End Sub

    Public Sub SetKeyControls(dctNewKeyControls As Dictionary(Of String, ucrBaseDataLink))
        dctKeyControls = dctNewKeyControls
    End Sub

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

    Private Sub UpdateKeyControls()
        If dctKeyControls IsNot Nothing AndAlso dctKeyControls.Count > 0 AndAlso iMaxRows > 0 Then
            'For i As Integer = 0 To dctKeyControls.Count - 1
            '    ' Suppress events being raised while changing value of each key control
            '    dctKeyControls.Values(i).bSuppressChangedEvents = True
            '    dctKeyControls.Values(i).SetValue(dtbRecords.Rows(iCurrRow)(dctKeyControls.Keys(i)))
            '    dctKeyControls.Values(i).bSuppressChangedEvents = False
            'Next
            For Each kvp As KeyValuePair(Of String, ucrBaseDataLink) In dctKeyControls
                'Suppress events being raised while changing value of each key control
                kvp.Value.bSuppressChangedEvents = True
                kvp.Value.SetValue(dtbRecords.Rows(iCurrRow).Item(kvp.Key))
                kvp.Value.bSuppressChangedEvents = False
            Next

            ' All key controls are linked to the same controls so can just trigger
            ' events for one control after all updated
            dctKeyControls.Values(dctKeyControls.Count - 1).OnevtValueChanged(Nothing, Nothing)
        End If
    End Sub

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
        UpdateKeyControls()
    End Sub

    Private Sub ucrNavigation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            txtRecNum.ReadOnly = True
            txtRecNum.TextAlign = HorizontalAlignment.Center
            bFirstLoad = False
        End If
    End Sub

    Public Sub SetControlsForNewRecord()
        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
    End Sub

    Public Sub ResetControls()
        btnMoveFirst.Enabled = True
        btnMoveLast.Enabled = True
        btnMoveNext.Enabled = True
        btnMovePrevious.Enabled = True
        displayRecordNumber()
        UpdateKeyControls()
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
        MovePrevious()

        'ALTERNATIVELY WE COULD JUST REMOVE RECORD IN THE DATATABLE WITH VALUES
        'FROM OUR KEY SELECTORS. HOWEVER, I DIDN'T IMPLEMENT IT THAT
        'WAY BECAUSE IF DATAENTRY IS BEING DONE BY MORE THAN ONE PERSON
        'SIMULTANEOUSLY WE MIGHT WANT THEM TO SEE THE CORRECT 
        'RECORD COUNT ON DELETE

    End Sub

    Public Sub SetSortBy(strNewSortCol As String)
        strSortCol = strNewSortCol
    End Sub

End Class


