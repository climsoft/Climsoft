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

Public Class frmGeneral
    Public HTMLHelp As New clsHelp

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