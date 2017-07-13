' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
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

'Imports ClimsoftVer4.GlobalVariables
Public Class frmQC

    Public HTMLHelp As New clsHelp
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cmdOk.Text = lang("OK")
        'cmdCancel.Text = lang("Cancel")
        'cmdApply.Text = lang("Apply")
        'cmdHelp.Text = lang("Help")
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        'Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "qcchecks.htm")
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        'If optAbsoluteLimits.Checked = True Then
        frmQCdatesSelection.Show()
        'End If
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdateDBfromQCReport.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        frmUpdateDBfromQCReport.Show()
    End Sub
End Class