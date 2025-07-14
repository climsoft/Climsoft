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

Public Class formDatabaseConnect
    Dim conn As New MySqlConnector.MySqlConnection
    Dim myConnectionString As String


    Private Sub btnDatabaseConnect_Click(sender As Object, e As EventArgs) Handles btnDatabaseConnect.Click

        myConnectionString = txtDbParameters.Text & "uid=" & userName.Text & ";pwd=" & passWord.Text & ";"

        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' MsgBox("Connection Successful !", MsgBoxStyle.Information)
            Me.Hide()
            frmLaunchPad.Show()
        Catch ex As MySqlConnector.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'inc = inc + 1
        ' maxRows = ds.Tables("station").Rows.Count
        'txtStationId.Text = ds.Tables("station").Rows(inc).Item("stationId")
        'txtStationName.Text = ds.Tables("station").Rows(inc).Item("stationName")
        ' txtRecNumber.Text = "Record " & inc + 1 & " of " & maxRows
        'txtRecNumber.Refresh()
        'txtStationId.Refresh()
        'txtStationName.Refresh()
    End Sub

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim configFilename As String = "c:\config\dbconfig.inf"
        'Dim configFilename As String = Application.StartupPath & "\config.inf"
        Dim configFilename As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\config.inf"
        'MsgBox(configFilename)
        Dim objTextReader As New System.IO.StreamReader(configFilename)
        txtDbParameters.Text = objTextReader.ReadLine
    End Sub
End Class
