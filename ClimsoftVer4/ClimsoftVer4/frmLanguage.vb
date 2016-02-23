Imports System.Globalization
Imports System.Threading

Public Class frmLanguage
    Dim cultureSelected As String = Thread.CurrentThread.CurrentUICulture.ToString

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        Dim language As String
        language = cboLanguage.Text

        Select Case language
            Case "English"
                cultureSelected = "en-GB"
            Case "Français"
                cultureSelected = "fr-FR"
            Case "Deutsch"
                cultureSelected = "de-DE"
        End Select
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureSelected)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultureSelected)
        frmMainMenu.Close()
        frmMainMenu.Show()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class