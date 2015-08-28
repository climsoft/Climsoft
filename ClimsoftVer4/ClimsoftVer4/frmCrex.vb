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
        Dim connectionPath As String = My.Settings.defaultDatabase
        Dim sqlConnection As MySqlConnection
        Dim command As MySqlCommand
        Dim READER As MySqlDataReader
        Dim Query As String

        Try
            MsgBox(connectionPath)
            sqlConnection = New MySqlConnection() 'new instance of mysqlconnection
            sqlConnection.ConnectionString = connectionPath
            sqlConnection.Open()

            Query = "SELECT * FROM station ORDER BY stationName"
            command = New MySqlCommand(Query, sqlConnection)
            READER = command.ExecuteReader

            While READER.Read
                Dim stationid = READER.GetString("stationName")
                cboStation.Items.Add(stationid)
            End While
            sqlConnection.Close()

        Catch ex As MySqlException
            MsgBox(ex.Message)

        End Try
    End Sub

End Class
