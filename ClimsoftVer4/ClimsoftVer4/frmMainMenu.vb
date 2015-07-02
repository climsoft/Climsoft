Public Class frmMainMenu
 
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub cmdkeyentry_Click(sender As Object, e As EventArgs) Handles cmdkeyentry.Click
        frmKeyEntry.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        End
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles cmdMetadata.Click
        'formProductsSelectCriteria.Show()
        FormLaunchPad.Show()
    End Sub

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' LoginForm.Hide
        HTMLHelp.HelpPage = "welcome.htm"
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
    End Sub

    
    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        formDbUtilities.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles cmdProducts.Click
        frmProducts.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub KeyEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeyEntryToolStripMenuItem.Click
        frmKeyEntry.Show()
    End Sub

    Private Sub ProductsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductsToolStripMenuItem.Click
        frmProducts.Show()
    End Sub


    Private Sub cmdQC_Click(sender As Object, e As EventArgs) Handles cmdQC.Click
        frmQC.Show()
    End Sub

    Private Sub QCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QCToolStripMenuItem.Click
        frmQC.Show()
    End Sub
End Class
