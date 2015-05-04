Public Class frmGeneralForm
    Public HTMLHelp As New ClassHelp

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
    End Sub

    Private Sub frmGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HTMLHelp.HelpPage = "aboutclimsoft4.htm"
    End Sub
End Class