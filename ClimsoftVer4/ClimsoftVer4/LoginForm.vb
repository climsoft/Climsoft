Public Class LoginForm
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim line As String

    Dim sr As New System.IO.StreamReader(Application.StartupPath.Replace("\bin\Debug", "\config.inf"))


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
            SplashScreen.Show()
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
        line = sr.ReadLine()
        cmbDatabases.Items.Add(line)

    End Sub


    Private Sub lblDbdetails_Click(sender As Object, e As EventArgs) Handles lblDbdetails.Click
        If lblDbdetails.Text = "Show Database Details........" Then
            cmbDatabases.Visible = True
            lblDbdetails.Text = "Hide Database Details........"
            cmbDatabases.SelectedText = line
        Else
            cmbDatabases.Visible = False
            lblDbdetails.Text = "Show Database Details........"
        End If
    End Sub

    Private Sub cmbDatabases_MouseHover(sender As Object, e As EventArgs) Handles cmbDatabases.MouseHover

    End Sub

    Private Sub cmbDatabases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDatabases.SelectedIndexChanged

    End Sub
End Class
