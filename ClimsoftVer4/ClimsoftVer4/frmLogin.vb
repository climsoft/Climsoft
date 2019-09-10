' CLIMSOFT - Climate Database Management System
' Copyright (C) 2019
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
    Public HTMLHelp As New clsHelp
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()
        Dim connectionString As String
        Dim dbChoice As String
        Dim password As String
        Dim subKey As String
        Dim username As String

        username = txtUsername.Text
        password = txtPassword.Text

        ' Ensure username and password are not empty
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MsgBox("Please enter a username and password")
            Exit Sub
        End If

        updateRememberedUsername()

        dbChoice = cmbDatabases.SelectedItem
        If String.IsNullOrEmpty(dbChoice) Then
            MsgBox("Please select a database from the list, or manage database connections")
            Exit Sub
        Else
            subKey = "db_" & dbChoice
            connectionString = My.Computer.Registry.GetValue(
                    "HKEY_LOCAL_MACHINE\Software\Climsoft4", subKey, Nothing)
            If String.IsNullOrEmpty(connectionString) Then
                MsgBox("Unable to read connection information. Please select ""Manage database connections"" " &
                       "to check and amend connection details")
                Exit Sub
            End If
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
        End Try

        regDataInit()
        languageTableInit()
        clsDataConnection.OpenConnection()
        climsoftuserRoles()
        frmSplashScreen.Show()
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Sub climsoftuserRoles()
        'Set SQL for populating user roles
        rolesSQL = "SELECT * from climsoftusers"
        daClimsoftUserRoles = New MySql.Data.MySqlClient.MySqlDataAdapter(rolesSQL, conn)
        daClimsoftUserRoles.Fill(dsClimsoftUserRoles, "userRoles")
    End Sub

    Sub languageTableInit()
        'Set SQL string for populating "regData" dataset
        languageTableSQL = "SELECT * from language_translation"     '
        daLanguageTable = New MySql.Data.MySqlClient.MySqlDataAdapter(languageTableSQL, conn)
        daLanguageTable.Fill(dsLanguageTable, "languageTranslation")
    End Sub

    Sub regDataInit()
        'Set SQL string for populating "regData" dataset
        regSQL = "SELECT keyName,keyValue FROM regkeys"     '
        daReg = New MySql.Data.MySqlClient.MySqlDataAdapter(regSQL, conn)
        daReg.Fill(dsReg, "regData")
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
        Dim connection As String
        Dim key As Microsoft.Win32.RegistryKey
        Dim remember_username As String
        Dim username As String

        ' Clear and then populate Database combobox
        cmbDatabases.Items.Clear()
        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Climsoft4")

        If key IsNot Nothing Then
            For Each subKey As String In key.GetValueNames
                If subKey.StartsWith("db_") Then
                    connection = Mid(subKey, 4)
                    cmbDatabases.Items.Add(connection)
                End If
            Next
            cmbDatabases.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '-------Code for translation added 20160207,ASM
        'Translate text for controls on login form.
        'Other Translation after successful login will come from language translation table stored in database

        msgKeyentryFormsListUpdated = "List of key-entry forms updated!"
        msgStationInformationNotFound = "Station information Not found. Please add station information And try again!"

        Dim lanCulture As String
        lanCulture = System.Globalization.CultureInfo.CurrentCulture.Name
        If Strings.Left(lanCulture, 2) = "en" Then
            ' MsgBox("Current language Is: English-UK")
            Me.Text = "Login"
            lblUsername.Text = "User name:"
            lblPassword.Text = "Password:"
            'lblDbdetails.Text = "Show and Configure Database Connection....."
            OK.Text = "OK"
            Cancel.Text = "Cancel"
        ElseIf Strings.Left(lanCulture, 2) = "fr" Then
            Me.Text = "s'identifier"
            lblUsername.Text = "Nom d'utilisateur:"
            lblPassword.Text = "Mot de passe:"
            'lblDbdetails.Text = "Afficher et configurer la base de données de connexion....."
            OK.Text = "OK"
            Cancel.Text = "Annuler"
        ElseIf Strings.Left(lanCulture, 2) = "de" Then
            Me.Text = "Anmeldung"
            lblUsername.Text = "Benutzername:"
            lblPassword.Text = "Passwort:"
            'lblDbdetails.Text = "Anzeige und Konfiguration der Verbindungsdatenbank....."
            OK.Text = "OK"
            Cancel.Text = "Stornieren"
        ElseIf Strings.Left(lanCulture, 2) = "pt" Then
            Me.Text = "Entrar"
            lblUsername.Text = "Nome de usuário:"
            lblPassword.Text = "Senha:"
            'lblDbdetails.Text = "Mostrar e configurar o banco de dados de conexão....."
            OK.Text = "OK"
            Cancel.Text = "Cancelar"
        End If

        If My.Settings.rememberUsername Then
            chkRememberUsername.Checked = True
            txtUsername.Text = My.Settings.rememberedUsername
            ' When loading, we have to show the form before we can give password the focus
            Me.Show()
            txtPassword.Focus()
        End If

        refreshDatabases()
    End Sub

    Private Sub LoginForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        updateRememberedUsername()
    End Sub

    Private Sub lblDbdetails_Click(sender As Object, e As EventArgs) Handles lblDbdetails.Click
        If Not My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            MsgBox("You must be an Administrator in order to manage database connections. When starting the program, right-click on the Climsoft icon and choose ""Run as administrator""")
            ' It's useful to refresh the databases here so that you don't need to restart if reg has been updated externally
            refreshDatabases()
        Else
            frmDatabaseConnections.ShowDialog()
        End If
    End Sub

    Private Sub cmbDatabases_Click(sender As Object, e As EventArgs) Handles cmbDatabases.Click

    End Sub


    Private Sub cmbDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatabases.SelectedIndexChanged

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
End Class
