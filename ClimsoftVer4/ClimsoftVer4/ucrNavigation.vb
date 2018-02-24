Public Class ucrNavigation
    Private bFirstLoad As Boolean = True
    Public iMaxRows As Integer
    Public iCurrRow As Integer
    Private dctKeyControls As Dictionary(Of String, ucrBaseDataLink)

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        iCurrRow = 0
        iMaxRows = dtbRecords.Rows.Count
        displayRecordNumber()
        UpdateKeyControls()
    End Sub

    'Not sure whether it's necessary to override this
    'and if it's to be overriden what value should it return and in what format

    'Public Overrides Function GetValue() As Object
    '    Return Nothing
    'End Function

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object

        If strFieldName = "" Then
            Return Nothing
        End If

        If dtbRecords.Rows.Count > 0 Then
            Return dtbRecords.Rows(iCurrRow).Field(Of Object)(strFieldName)
        Else
            Return ""
        End If

    End Function

    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        If iMaxRows = 0 Then
            txtRecNum.Text = "Record 0 of 0"
        Else
            txtRecNum.Text = "Record " & iCurrRow + 1 & " of " & iMaxRows
        End If

    End Sub

    Protected Overridable Sub ucrNavigation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            bFirstLoad = False
        End If
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        iCurrRow = 0
        'we always want to have the record number displayed 
        displayRecordNumber()
        OnevtValueChanged(sender, e)

    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click

        If iCurrRow > 0 Then
            iCurrRow = iCurrRow - 1
            displayRecordNumber()
            OnevtValueChanged(sender, e)
        Else
            MsgBox("No more previous record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click

        If iCurrRow < (iMaxRows - 1) Then
            iCurrRow = iCurrRow + 1
            displayRecordNumber()
            OnevtValueChanged(sender, e)
        Else
            MsgBox("No more next record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        iCurrRow = iMaxRows - 1
        displayRecordNumber()
        OnevtValueChanged(sender, e)

    End Sub

    Public Sub SetKeyControls(dctNewKeyControls As Dictionary(Of String, ucrBaseDataLink))
        dctKeyControls = dctNewKeyControls
    End Sub

    Private Sub UpdateKeyControls()
        If dctKeyControls IsNot Nothing Then
            For i As Integer = 0 To dctKeyControls.Count - 1
                ' Suppress events being raised while changing value of each key control
                dctKeyControls.Values(i).bSuppressChangedEvents = True
                dctKeyControls.Values(i).SetValue(dtbRecords.Rows(iCurrRow)(dctKeyControls.Keys(i)))
                dctKeyControls.Values(i).bSuppressChangedEvents = False
            Next
            ' All key controls are linked to the same controls so can just trigger
            ' events for one control after all updated
            dctKeyControls.Values(dctKeyControls.Count - 1).OnevtValueChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub ucrNavigation_evtValueChanged(sender As Object, e As EventArgs) Handles Me.evtValueChanged
        UpdateKeyControls()
    End Sub
End Class


