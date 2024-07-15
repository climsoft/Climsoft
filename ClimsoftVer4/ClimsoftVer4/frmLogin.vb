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
Imports System.IO
Imports System.Security.AccessControl
Imports System.Security.Principal
Imports ClimsoftVer4.Translations


Public Class frmLogin
    Public HTMLHelp As New clsHelp
    Public connectionDetails As New List(Of String)
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection

    ' Get Application Data folder to all users, e.g. C:\ProgramData
    ' Storing config.inf here ensures that it will still be available when Climsoft is updated
    Dim commonPath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
    Public directoryPath As String = IO.Path.Combine(commonPath, "Climsoft4")
    Public filePath As String = IO.Path.Combine(directoryPath, "config.inf")

    Sub readConnectionDetails()
        Dim builder As New Common.DbConnectionStringBuilder()

        ' Update Me.connectionDetails
        connectionDetails = New List(Of String)
        If IO.File.Exists(filePath) Then
            Using r As IO.StreamReader = New IO.StreamReader(filePath)
                Dim line As String
                line = r.ReadLine
                Do While (Not line Is Nothing)
                    ' A valid line should contain a connection name, a pipe character `|` and a connection string
                    Dim parts As String() = line.Split("|")
                    ' To be here, we know that line is not empty, therefore there must be a part(0)
                    Try
                        ' Attempt to offer the second part (if it exists) to a connection string builder
                        builder.ConnectionString = parts(1)
                        connectionDetails.Add(line)
                    Catch ex As Exception
                        ' If a line cannot be read for any reason then we skip it. It is invalid, therefore it will
                        ' not be displayed and it will not be written back to the file.
                    End Try
                    line = r.ReadLine
                Loop
            End Using
        ElseIf IO.File.Exists("config.inf") Then
            ' In the case where `filePath` does NOT exist, attempt to read legacy connection information
            ' from the folder Climsoft is installed in (in previous versoins this file was also called `config.inf`)
            Using r As IO.StreamReader = New IO.StreamReader("config.inf")
                Dim line As String
                line = r.ReadLine
                Try
                    builder.ConnectionString = line
                    connectionDetails.Add("Climsoft4|" & line)
                Catch ex As Exception
                    ' If a line cannot be read for any reason then we skip it. It is invalid, therefore it will
                    ' not be displayed and it will not be written back to the file.
                End Try
            End Using
        Else
            connectionDetails.Add("Default_database|" & My.Settings.defaultDatabase)
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim builder As New Common.DbConnectionStringBuilder()
        Dim connectionString, dbChoice, password, username As String
        'Dim dbChoice As String
        'Dim password As String
        'Dim username As String
        Dim parts As String()
        Dim usr As Boolean = False

        username = txtUsername.Text
        password = txtPassword.Text

        ' Ensure username and password are not empty
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MsgBox("Please enter a username and password")
            Exit Sub
        End If

        updateRememberedUsername()

        dbChoice = cboDatabases.SelectedItem
        connectionString = ""
        If String.IsNullOrEmpty(dbChoice) Then
            MsgBox("Please select a database from the list, or manage database connections")
            Exit Sub
        Else
            For Each connection As String In connectionDetails
                parts = connection.Split("|")
                If parts(0) = dbChoice Then
                    connectionString = parts(1)
                End If
            Next
        End If

        ' Check that the connection string, with username and password is accepted by the
        ' connection String builder (otherwise warn and stop)
        Try
            builder.ConnectionString = connectionString
            builder("uid") = username
            builder("pwd") = password

            ' The connection string has historically been stored in this control
            ' There are other locations in the software that may access this
            txtusrpwd.Text = builder.ConnectionString & ";Convert Zero Datetime=True"

        Catch ex As Exception
            MsgBox("Login failed: " & ex.Message)
            Exit Sub
        End Try

        conn.ConnectionString = txtusrpwd.Text
        Try
            conn.Open()
        Catch ex As Exception
            If ex.Message.IndexOf("Access denied for user") >= 0 Then
                MsgBox("Access denied. Please try again.")
                ' Move cursor to password box and clear password to encourage the user to try again
                txtPassword.Text = ""
                txtPassword.Select()
            ElseIf ex.Message.IndexOf("Unable to connect") >= 0 Then
                MsgBox("Unable to connect to database, please test database connection using " &
                       """Manage database connections""")
            Else
                MsgBox("Login failed: " & ex.Message)
            End If

            Exit Sub
        Finally
            conn.Close()
        End Try

        ' Check if the login is listed with roles in the current database except the root user
        climsoftuserRoles(usr)
        If Not usr And txtUsername.Text <> "root" Then
            MsgBox("Access denied. User not found in the current database")
            conn.Close()
            Exit Sub
        End If

        regDataInit()
        languageTableInit()
        conn.Close()
        clsDataConnection.OpenConnection(txtusrpwd.Text) 'todo. the connection string should come from somewhere else

        Path_Security()
        frmSplashScreen.Show()
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Sub climsoftuserRoles(ByRef lognusr As Boolean)
        Try
            'Set SQL for populating user roles
            rolesSQL = "SELECT * from climsoftusers"
            daClimsoftUserRoles = New MySql.Data.MySqlClient.MySqlDataAdapter(rolesSQL, conn)
            daClimsoftUserRoles.Fill(dsClimsoftUserRoles, "userRoles")

            With dsClimsoftUserRoles.Tables("userRoles")
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userName") = txtUsername.Text Then
                        lognusr = True
                    End If
                Next i
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub languageTableInit()
        'Set SQL string for populating "regData" dataset
        languageTableSQL = "SELECT * from language_translation"     '
        daLanguageTable = New MySql.Data.MySqlClient.MySqlDataAdapter(languageTableSQL, conn)
        daLanguageTable.Fill(dsLanguageTable, "languageTranslation")
    End Sub

    Sub regDataInit()
        Try
            'Set SQL string for populating "regData" dataset
            regSQL = "SELECT keyName,keyValue FROM regkeys"     '
            daReg = New MySql.Data.MySqlClient.MySqlDataAdapter(regSQL, conn)
            daReg.Fill(dsReg, "regData")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub updateRememberedUsername()
        ' Check whether the username should be saved for next time and update accordingly
        If chkRememberUsername.Checked Then
            My.Settings.rememberUsername = True
            My.Settings.rememberedUsername = txtUsername.Text
        Else
            My.Settings.rememberUsername = False
            My.Settings.rememberedUsername = ""
        End If
        My.Settings.Save()
    End Sub

    Sub refreshDatabases()
        Dim parts As String()

        ' Read the configuration file for the latest details
        readConnectionDetails()

        Try
            ' Clear and then populate Database combobox from connectionDetails
            cboDatabases.Items.Clear()
            For Each line As String In connectionDetails
                parts = line.Split("|")
                cboDatabases.Items.Add(parts(0))
            Next
            cboDatabases.SelectedIndex = 0
        Catch
            ' SelectedIndex = 0 will fail if no items are added to cmdDatabases
        End Try
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '-------Code for translation added 20160207,ASM
        'Translate text for controls on login form.
        'Other Translation after successful login will come from language translation table stored in database

        msgKeyentryFormsListUpdated = "List of key-entry forms updated!"
        msgStationInformationNotFound = "Station information Not found. Please add station information And try again!"

        If My.Settings.rememberUsername Then
            chkRememberUsername.Checked = True
            txtUsername.Text = My.Settings.rememberedUsername
            ' When loading, we have to show the form before we can give password the focus
            Me.Show()
            txtPassword.Focus()
        End If

        refreshDatabases()

        lblLanguage.Text = My.Settings.languageName
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        updateRememberedUsername()
    End Sub

    Private Sub lblDbdetails_Click(sender As Object, e As EventArgs) Handles lblDbdetails.Click
        'If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Or My.Computer.Keyboard.CtrlKeyDown Then
        '    frmDatabaseConnections.ShowDialog()
        'Else
        '    MsgBox("You must be an Administrator in order to manage database connections. When starting the program, right-click on the Climsoft icon and choose ""Run as administrator""")
        '    ' It's useful to refresh the databases here so that you don't need to restart if reg has been updated externally
        '    refreshDatabases()
        'End If
        frmDatabaseConnections.ShowDialog()
        refreshDatabases()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "login.htm")
    End Sub

    Private Sub chkRememberUsername_CheckedChanged(sender As Object, e As EventArgs) Handles chkRememberUsername.CheckedChanged
        If Not chkRememberUsername.Checked Then
            My.Settings.rememberUsername = False
            My.Settings.rememberedUsername = ""
            My.Settings.Save()
        End If
    End Sub

    Sub Path_Security()
        Dim dtpath As String

        dtpath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4"
        ' Create the path if it is not there
        If IO.Directory.Exists(dtpath) = False Then
            IO.Directory.CreateDirectory(dtpath)
        End If

        ' Grant full access on `filePath` for all users (allows any user to write to file)
        ' This is currently necessary because some Climsoft installers are not Windows Administrators
        Try
            Dim dInfo As IO.DirectoryInfo = New IO.DirectoryInfo(dtpath)
            Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

            dSecurity.AddAccessRule(New FileSystemAccessRule(
                New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing),
                FileSystemRights.FullControl,
                InheritanceFlags.ObjectInherit Or InheritanceFlags.ContainerInherit,
                PropagationFlags.NoPropagateInherit, AccessControlType.Allow
            ))

            dInfo.SetAccessControl(dSecurity)

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub linkLabelLanguage_Click(sender As Object, e As EventArgs) Handles linkLabelLanguage.Click
        frmLanguage.ShowDialog()
        lblLanguage.Text = My.Settings.languageName
        ClsTranslations.TranslateForm(Me)
    End Sub
End Class
