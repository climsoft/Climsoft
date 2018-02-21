Public Class ucrNavigation
    Private bFirstLoad As Boolean = True
    Public maxRows As Integer
    Public currRow As Integer

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        currRow = 0
        maxRows = dtbRecords.Rows.Count
        displayRecordNumber()
    End Sub

    'Not sure whether it's necessary to override this
    'and if it's to be overriden what value should it return and in what format

    'Public Overrides Function GetValue() As Object
    '    Return Nothing
    'End Function

    Public Overrides Function GetValue(strFieldName As String) As Object

        If strFieldName = "" Then
            Return GetValue()
        End If

        If dtbRecords.Rows.Count > 0 Then
            Return dtbRecords.Rows(currRow).Field(Of Object)(strFieldName)
        Else
            Return ""
        End If

    End Function

    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        If maxRows = 0 Then
            txtRecNum.Text = "Record " & 0 & " of " & 0
        Else
            txtRecNum.Text = "Record " & currRow + 1 & " of " & maxRows
        End If

    End Sub

    Protected Overridable Sub ucrNavigation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            bFirstLoad = False
        End If
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        currRow = 0
        'we always want to have the record number displayed 
        displayRecordNumber()
        OnevtValueChanged(sender, e)

    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click

        If currRow > 0 Then
            currRow = currRow - 1
            displayRecordNumber()
            OnevtValueChanged(sender, e)
        Else
            MsgBox("No more previous record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click

        If currRow < (maxRows - 1) Then
            currRow = currRow + 1
            displayRecordNumber()
            OnevtValueChanged(sender, e)
        Else
            MsgBox("No more next record!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        currRow = maxRows - 1
        displayRecordNumber()
        OnevtValueChanged(sender, e)
    End Sub
End Class


