' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports System.Globalization
Imports System.Threading
Imports ClimsoftVer4.Translations

Public Class frmLanguage
    Dim cultureSelected As String = Thread.CurrentThread.CurrentUICulture.ToString

    Private Sub frmLanguage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleTranslateTool.translateForm(Me)

        Dim found As AvailableLanguages

        If Not IO.File.Exists(My.Settings.localDatabase) Then
            MsgBox("Unable to change language. Translations file could not be found.")
            Me.Close()
            Return
        End If

        found = SimpleTranslateTool.listLanguages()
        cboLanguage.Items.Clear()
        cboLanguage.Items.AddRange(found.languages.ToArray)
        cboLanguage.SelectedIndex = found.selectedIndex

    End Sub

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        'Dim language As String
        'language = cboLanguage.Text

        'Select Case language
        '    Case "English"
        '        cultureSelected = "en-GB"
        '    Case "Français"
        '        cultureSelected = "fr-FR"
        '    Case "Deutsch"
        '        cultureSelected = "de-DE"
        'End Select
        'autoTranslate(Me)
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        ' Set the current culture to the selected option, when new forms are opened this will be queried
        'Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureSelected)
        'Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultureSelected)
        'MsgBox(Thread.CurrentThread.CurrentCulture.ToString)

        Dim selectedLanguage As String
        selectedLanguage = cboLanguage.GetItemText(cboLanguage.SelectedItem)
        My.Settings.currentLanguageCode = SimpleTranslateTool.translateOpenForms(selectedLanguage)
        frmLogin.lblLanguage.Text = My.Settings.currentLanguageCode
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        Dim selectedLanguage As String
        selectedLanguage = cboLanguage.GetItemText(cboLanguage.SelectedItem)
        My.Settings.currentLanguageCode = SimpleTranslateTool.translateOpenForms(selectedLanguage)
        frmLogin.lblLanguage.Text = My.Settings.currentLanguageCode
    End Sub
End Class