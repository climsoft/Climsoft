Imports System.Globalization
Imports System.Threading
Imports ClimsoftVer4.Translations

Public Class frmLanguage
    Dim cultureSelected As String = Thread.CurrentThread.CurrentUICulture.ToString

    Private Sub frmLanguage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autoTranslate(Me)
    End Sub

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
        autoTranslate(Me)
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureSelected)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultureSelected)
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class