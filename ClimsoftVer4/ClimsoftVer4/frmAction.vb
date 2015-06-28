Imports ClimsoftVer4.GlobalVariables

Public Class frmAction
    Public HTMLHelp As New ClassHelp
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmdOk.Text = lang("OK")
        cmdCancel.Text = lang("Cancel")
        cmdApply.Text = lang("Apply")
        cmdHelp.Text = lang("Help")
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

    End Sub
End Class