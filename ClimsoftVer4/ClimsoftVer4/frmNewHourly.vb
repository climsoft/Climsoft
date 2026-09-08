Public Class frmNewHourly
    Public dat(24), currVal, prevVal As String
    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsTranslations.TranslateForm(Me)
    End Sub
End Class