Public Class LoginForm
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection

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
            Using sr As New System.IO.StreamReader(Application.StartupPath.Replace("\bin\Debug", "\config.inf"))
                Dim line As String
                Dim connectstr As String

                ' Read from the configuration file
                line = sr.ReadLine()

                ' Contruct the connection string using the output the file
                connectstr = line & "uid=" & txtUsername.Text & ";pwd=" & txtPassword.Text & ";"

                'MsgBox(connectstr)
                txtusrpwd.Text = connectstr
                conn.ConnectionString = connectstr 'line
                conn.Open()
                sr.Close()
                ' Load Splash screen
                SplashScreen.Show()
                Me.Hide()
            End Using
        Catch e As Exception
            MsgBox("Login failure")
                  End Try
    End Sub

    ' End Module

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
