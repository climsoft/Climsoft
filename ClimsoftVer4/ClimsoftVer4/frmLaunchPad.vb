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

Public Class frmLaunchPad

    Private Sub btnStationInformation_Click(sender As Object, e As EventArgs) Handles btnStationInformation.Click
        formStation.Show()
    End Sub

    Private Sub btnSynopticData_Click(sender As Object, e As EventArgs)
        formSynopRA1.Show()
    End Sub

    Private Sub btnElementInformation_Click(sender As Object, e As EventArgs) Handles btnElementInformation.Click
        formElement.Show()

    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim configFilename As String = Application.StartupPath & "\config.inf"
            Dim dbconnectstr As String
            'MsgBox(configFilename)
            FileOpen(12, configFilename, OpenMode.Output)
            'MsgBox(configFilename)
            'frmLaunchPad.lblConection.Text = svrdbstr & "uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";Convert Zero Datetime=True"
            dbconnectstr = "server=" & txtServer.Text & ";database=" & txtDatabase.Text & ";port=" & txtPort.Text & ";"

            PrintLine(12, dbconnectstr)
            FileClose(12)
            frmLogin.cmbDatabases.Text = dbconnectstr
            frmLogin.cmbDatabases.Refresh()
            MsgBox("Database Details Updated", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmLaunchPad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class