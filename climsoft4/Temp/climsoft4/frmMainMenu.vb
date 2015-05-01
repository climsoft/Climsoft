Public Class frmMainMenu

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        End
    End Sub

    Private Sub cmdkeyentry_Click(sender As Object, e As EventArgs) Handles cmdkeyentry.Click
        frmKeyEntry.Show()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click

    End Sub

    Private Sub AboutCLIMSOFT4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutCLIMSOFT4ToolStripMenuItem.Click
        Help.ShowHelp(Me, "C:\Climsoft Project\Climsoft V4\Help\climsoft4.chm")
    End Sub
End Class
