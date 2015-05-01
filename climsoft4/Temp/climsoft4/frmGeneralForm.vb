Public Class frmGeneralForm
    'Dim strHelpPath As String = System.IO.Path.Combine(Application.StartupPath, "C:\Climsoft Project\Climsoft V4\Help\climsoft4.chm")

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TopicId, Me.HelpProvider1.GetHelpKeyword(Me))
    End Sub

    Private Sub frmGeneralForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'HelpProvider1.HelpNamespace = strHelpPath
    End Sub
End Class