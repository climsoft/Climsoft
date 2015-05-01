Public Class frmGeneralForm

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        'Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TopicId, "C:\Climsoft Project\Climsoft V4\Climsoft\ClimsoftVer4\ClimsoftVer4\bin\Debug\climsoft4.chm")

        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TopicId, Me.HelpProvider1.GetHelpKeyword(Me))
    End Sub

    Private Sub frmGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class