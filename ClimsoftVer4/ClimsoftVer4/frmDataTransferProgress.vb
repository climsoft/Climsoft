Public Class frmDataTransferProgress

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        'MsgBox("Data successfully uploaded !", MsgBoxStyle.Information)

    End Sub

    Private Sub frmDataTransferProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblDataTransferProgress.Refresh()
    End Sub
End Class