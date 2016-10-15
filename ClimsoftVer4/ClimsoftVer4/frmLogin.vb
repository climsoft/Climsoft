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

            'Added connection to remote server for data synchronization. 20160726 ASM
            'Get IP address of remote server
            remoteSvr = dsReg.Tables("regData").Rows(13).Item("keyValue")
            'Add connectionString to remote server. 
            connStrRemoteSvr = "server=" & remoteSvr & ";database=mariadb_climsoft_db_v4;port=3308;" & "uid=" & txtUsername.Text & _
                ";pwd=" & txtPassword.Text & ";Convert Zero Datetime=True"

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
    Sub pushKeyEntryDataToRemote(tableName As String)
        'Added to allow pushing key-entry data from local to remote. 20160726 ASM
        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds As New DataSet
        Dim sql As String

        conn.Close()

        Dim myConnectionString As String
        myConnectionString = txtusrpwd.Text
        ' MsgBox(myConnectionString)
        conn.ConnectionString = myConnectionString
        conn.Open()

        sql = "SELECT * FROM " & tableName
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, tableName)

        ' MsgBox("Connection local successful!")
        Dim strSQL As String
        Dim strBackupFileLocal As String, strBackupFolderLocal As String, strBackupFolderUnixStyleLocal As String
        Dim strBackupFileRemote As String, strBackupFolderRemote As String, strBackupFolderUnixStyleRemote As String
        Dim backupFileLocalMapped As String, backupFolderLocalMapped As String

        strBackupFolderLocal = dsReg.Tables("regData").Rows(14).Item("keyValue")
        backupFolderLocalMapped = dsReg.Tables("regData").Rows(16).Item("keyValue")

        strBackupFileLocal = tableName & "_backup_" & txtUsername.Text & ".csv"
        'Search and replace backslash "\" in folder path with forward slash "/"
        strBackupFolderUnixStyleLocal = strBackupFolderLocal.Replace("\", "/")
        strBackupFileLocal = strBackupFolderUnixStyleLocal & "/" & strBackupFileLocal

        ' Delete previous backup file
        If System.IO.File.Exists(strBackupFileLocal) Then System.IO.File.Delete(strBackupFileLocal)
        strSQL = "SELECT * FROM " & tableName & " INTO OUTFILE '" & strBackupFileLocal & "' FIELDS TERMINATED BY ',';"

        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        Try
            'Execute query
            objCmd.ExecuteNonQuery()
            '' MsgBox("Data exported successfully!")
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try
        conn.Close()

        strBackupFileLocal = strBackupFolderLocal & "\" & tableName & "_backup_" & txtUsername.Text & ".csv"
        backupFileLocalMapped = backupFolderLocalMapped & "\" & tableName & "_backup_" & txtUsername.Text & ".csv"

        'Copy backup file to mapped drive folder and overwrite existing file
        My.Computer.FileSystem.CopyFile(strBackupFileLocal, backupFileLocalMapped, True)

        strBackupFileRemote = tableName & "_backup_" & txtUsername.Text & ".csv"
        strBackupFolderRemote = dsReg.Tables("regData").Rows(15).Item("keyValue")
        'Search and replace backslash "\" in folder path with forward slash "/"
        strBackupFolderUnixStyleRemote = strBackupFolderRemote.Replace("\", "/")
        strBackupFileRemote = strBackupFolderUnixStyleRemote & "/" & strBackupFileRemote

        'Load data from backup file
        Dim ColumnCount As Integer, i As Integer, valueList As String
        ColumnCount = ds.Tables(tableName).Columns.Count
        'MsgBox("Number of columns=" & ColumnCount)
        valueList = ds.Tables(tableName).Columns.Item(0).ColumnName
        For i = 1 To ColumnCount - 1
            valueList = valueList & "," & ds.Tables(tableName).Columns.Item(i).ColumnName
        Next i
        'MsgBox(valueList)

        myConnectionString = connStrRemoteSvr
        ' MsgBox(myConnectionString)
        conn.ConnectionString = myConnectionString
        conn.Open()
        ' MsgBox("Connection to remote database server successful!")

        strSQL = "LOAD DATA INFILE '" & strBackupFileRemote & "' IGNORE INTO TABLE " & tableName & " FIELDS TERMINATED BY ',' (" & valueList & ");"
        'Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        Try
            'Execute query
            objCmd.ExecuteNonQuery()
            msgDataPushtoRemote = "Data pushed to remote database server successfully! " & Now()
            MsgBox(msgDataPushtoRemote)
            'strDataPushMessage = msgDataPushtoRemote
            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            msgDataPushtoRemote = "Data pushed to remote database server unsuccessful! " & Now()
            MsgBox(msgDataPushtoRemote)
            'strDataPushMessage = msgDataPushtoRemote
        End Try

        conn.Close()
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
        cmbDatabases.Items.Add(line)

        cmbDatabases.Text = cmbDatabases.Items.Item(0)
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
