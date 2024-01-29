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
Public Class frmLanguage

    Private Sub frmLanguage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dctLanguages As New Dictionary(Of String, String)
        dctLanguages.Add("en", "English")
        dctLanguages.Add("fr", "Français")
        dctLanguages.Add("pt", "Portuguese")

        cboLanguage.DataSource = New BindingSource(dctLanguages, Nothing)
        cboLanguage.ValueMember = "Key"
        cboLanguage.DisplayMember = "Value"

        cboLanguage.SelectedValue = My.Settings.languageCode
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        My.Settings.languageCode = cboLanguage.SelectedValue
        My.Settings.languageName = cboLanguage.Text
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class