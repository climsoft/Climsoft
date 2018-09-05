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

Imports ClimsoftVer4.Translations


Public Class frmLogin
    Public HTMLHelp As New clsHelp
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
        'regDataInit()
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

            'Added Convert Zero Datetime=True" to connection string to resolve error message _
            '"Unable to convert MySQL date/time value to System.DateTime ASM 20160124"
            connectstr = line & "uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";Convert Zero Datetime=True"

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
            regDataInit()

            languageTableInit()
            climsoftuserRoles()
        Catch e As Exception
            'MsgBox("Login failure")
            MsgBox(e.Message, MsgBoxStyle.Exclamation)
        End Try
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

    ' End Module
    Sub Server_db_port(svrdbstr As String)
        Dim Ssvr, Esvr, Sdb, Edb As Integer
        Dim Svr_db_port, svrstr, dbstr, portstr As String
        ' server=127.0.0.1;database=mysql_climsoft_db_v4;port=3306;
        Ssvr = 8
        Esvr = InStr(svrdbstr, ";database=")
        Sdb = Esvr + 10
        Edb = InStr(svrdbstr, ";port")
        portstr = Mid(svrdbstr, Edb + 6, 4)
        svrstr = Mid(svrdbstr, Ssvr, Esvr - Ssvr)
        dbstr = Mid(svrdbstr, Sdb, Edb - Sdb)
        Svr_db_port = svrstr & "\\" & dbstr
        'MsgBox(svrstr & " " & dbstr & " " & portstr)
        frmLaunchPad.txtServer.Text = svrstr
        frmLaunchPad.txtDatabase.Text = dbstr
        frmLaunchPad.txtPort.Text = portstr
        frmLaunchPad.Show()
        frmLaunchPad.lblConection.Text = svrdbstr & "uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";Convert Zero Datetime=True"

    End Sub
    'Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    'End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        '-------Code for translation added 20160207,ASM
        'Translate text for controls on login form.
        'Other Translation after successful login will come from language translation table stored in database

        msgKeyentryFormsListUpdated = "List of key-entry forms updated!"
        msgStationInformationNotFound = "Station information not found. Please add station information and try again!"

        Dim lanCulture As String
        lanCulture = System.Globalization.CultureInfo.CurrentCulture.Name
        If Strings.Left(lanCulture, 2) = "en" Then
            ' MsgBox("Current language is: English-UK")
            Me.Text = "Login"
            lblUsername.Text = "User name:"
            lblPassword.Text = "Password:"
            lblDbdetails.Text = "Show and Configure Database Connection....."
            OK.Text = "OK"
            Cancel.Text = "Cancel"
        ElseIf Strings.Left(lanCulture, 2) = "fr" Then
            Me.Text = "s'identifier"
            lblUsername.Text = "Nom d'utilisateur:"
            lblPassword.Text = "Mot de passe:"
            lblDbdetails.Text = "Afficher et configurer la base de données de connexion....."
            OK.Text = "OK"
            Cancel.Text = "Annuler"
        ElseIf Strings.Left(lanCulture, 2) = "de" Then
            Me.Text = "Anmeldung"
            lblUsername.Text = "Benutzername:"
            lblPassword.Text = "Passwort:"
            lblDbdetails.Text = "Anzeige und Konfiguration der Verbindungsdatenbank....."
            OK.Text = "OK"
            Cancel.Text = "Stornieren"
        ElseIf Strings.Left(lanCulture, 2) = "pt" Then
            Me.Text = "Entrar"
            lblUsername.Text = "Nome de usuário:"
            lblPassword.Text = "Senha:"
            lblDbdetails.Text = "Mostrar e configurar o banco de dados de conexão....."
            OK.Text = "OK"
            Cancel.Text = "Cancelar"
        End If
        '------------------
        ' If the user's machine is set to an alternative language then this alternative will be used if available
        'autoTranslate(Me)

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
        'MsgBox(line)
        cmbDatabases.Items.Add(line)

        cmbDatabases.Text = cmbDatabases.Items.Item(0)
        'MsgBox(cmbDatabases.Text)
        sr.Close()

    End Sub


    Private Sub lblDbdetails_Click(sender As Object, e As EventArgs) Handles lblDbdetails.Click
        If lblDbdetails.Text = "Show and Configure Database Connection........" Then
            'cmbDatabases.Visible = True
            'sr.Close()
            line = cmbDatabases.Text
            Server_db_port(line)
            'lblDbdetails.Text = "Hide Database Details........"
        Else
            frmLaunchPad.Close()
            cmbDatabases.Visible = False
            lblDbdetails.Text = "Show and Configure Database Connection........"
        End If
    End Sub

    Private Sub cmbDatabases_Click(sender As Object, e As EventArgs) Handles cmbDatabases.Click

    End Sub


    Private Sub cmbDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatabases.SelectedIndexChanged

    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        'HTMLHelp.HelpPage = "login.htm"
        'Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "login.htm")

    End Sub
End Class
