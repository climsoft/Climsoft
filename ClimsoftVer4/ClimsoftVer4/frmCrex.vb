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


Imports MySql.Data.MySqlClient
Public Class frmCrex

    Private Sub frmCrex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionPath As String = "Server=localhost; User Id=root; Password=P@55w0rd; Database=mysql_climsoft_db_v4"
        Dim sqlConnection As MySqlConnection = New MySqlConnection
        Dim command As MySqlCommand

        sqlConnection = New MySqlConnection() 'new instance of mysqlconnection
        sqlConnection.ConnectionString = connectionPath
        Dim insertCommand As New MySqlCommand
        Dim READER As MySqlDataReader
        Try
            sqlConnection.Open()
            Dim Querry As String
            Querry = "select * from station"
            command = New MySqlCommand(Querry, sqlConnection)
            READER = command.ExecuteReader

            While READER.Read
                Dim stationid = READER.GetString("stationId")
                cboStation.Items.Add(stationid)
            End While
            sqlConnection.Close()

        Catch ex As MySqlException
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub btnEncode_Click(sender As Object, e As EventArgs) Handles btnEncode.Click

    End Sub

    Private Sub txtOriginatingGeneratingCenter_TextChanged(sender As Object, e As EventArgs) Handles txtOriginatingGeneratingCenter.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
