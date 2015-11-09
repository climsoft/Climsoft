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
Imports ClimsoftVer4.Translations


Public Class frmLogin
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim line As String

    Dim sr As IO.StreamReader


    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ConfigFile()
        'frmMainMenu.Show()
        'Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Sub ConfigFile()
        Try
            ' Create an instance of StreamReader to read from a file. 
            ' Then open the configuration file
            'MsgBox(Application.StartupPath.Replace("\bin\Debug", "\config.inf"))
            'Using sr As New System.IO.StreamReader(Application.StartupPath.Replace("\bin\Debug", "\config.inf"))

            ' Dim line As String
            Dim connectstr As String
            Dim caption As String

            ' Read from the configuration file
            'line = sr.ReadLine()

            'MsgBox(Server_db_port(line))

            ' Contruct the connection string using the output the file

            If cmbDatabases.Text <> "" Then line = cmbDatabases.Text ' Change the connection string to the selected database

            connectstr = line & "uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";"

            'MsgBox(connectstr)
            txtusrpwd.Text = connectstr
            conn.ConnectionString = connectstr 'line
            conn.Open()
            sr.Close()
            ' Load Splash screen
            caption = Mid(line, 1, Len(line) - 11)

            frmMainMenu.Text = frmMainMenu.Text & "          ...           " & caption
            frmSplashScreen.Show()
            Me.Hide()
            ' End Using
        Catch e As Exception
            MsgBox("Login failure")
        End Try
    End Sub

    ' End Module
    Function Server_db_port(svrdbstr As String) As String
        Dim Ssvr, Esvr, Sdb, Edb As Integer
        Dim svrstr, dbstr As String
        ' server=127.0.0.1;database=mysql_climsoft_db_v4;port=3306;
        Ssvr = 8
        Esvr = InStr(svrdbstr, ";database=")
        Sdb = Esvr + 10
        Edb = InStr(svrdbstr, ";port")
        svrstr = Mid(svrdbstr, Ssvr, Esvr - Ssvr)
        dbstr = Mid(svrdbstr, Sdb, Edb - Sdb)
        Server_db_port = svrstr & "\\" & dbstr

    End Function
    'Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub LoginForm_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged

    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' If the user's machine is set to an alternative language then this alternative will be used if available
        autoTranslate(Me)

        Try
            sr = New IO.StreamReader("config.inf")
        Catch ex As Exception
            If TypeOf ex Is System.IO.FileNotFoundException Then
                ' TODO: Log warning: "A required CLIMSOFT configuration file is missing. " & ex.Message
                ' Try to recover by using the default settings:
                ' My.MySettings.Default.defaultDatabase
            Else
                Throw
            End If
        End Try

        line = sr.ReadLine()
        cmbDatabases.Items.Add(line)

        cmbDatabases.Text = cmbDatabases.Items.Item(0)
    End Sub


    Private Sub lblDbdetails_Click(sender As Object, e As EventArgs) Handles lblDbdetails.Click
        If lblDbdetails.Text = "Show Database Details........" Then
            cmbDatabases.Visible = True
            lblDbdetails.Text = "Hide Database Details........"
        Else
            cmbDatabases.Visible = False
            lblDbdetails.Text = "Show Database Details........"
        End If
    End Sub

    Private Sub cmbDatabases_Click(sender As Object, e As EventArgs) Handles cmbDatabases.Click

    End Sub


    Private Sub cmbDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatabases.SelectedIndexChanged

    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click

    End Sub
End Class
