Public Class frm_login

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ' Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        'Dim MyConnectionString As String

        ' MyConnectionString = "server=127.0.0.1;" _
        '& "uid=root;" _
        ' & "pwd=admin;" _
        ' & "database=mysql_climsoft_db_v4"
        'Try
        'conn.ConnectionString = MyConnectionString
        'conn.Open()
        'MessageBox.Show("Connection Successful")
        'Catch ex As MySql.Data.MySqlClient.MySqlException
        'MessageBox.Show(ex.Message)
        'End Try
        frm_main.Show()
        Me.Hide()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click

    End Sub

    Private Sub frm_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim MyConnectionString As String

        MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()
            'MessageBox.Show("Connection Successful")
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        ' Write the code for verifying the user logins

        conn.Close()

        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter ' SqlDataAdapter
        Dim dr As MySql.Data.MySqlClient.MySqlDataReader '  DataReader
        Dim ds As New DataSet

        'ds = da.SelectCommand.s

        'Using Adapter As New mysqldataadapter("select * from yourtable where yourcolumn = 'yourvalue'", dbConnection)
        '    Using Table As New DataTable
        '        Adapter.fill(Table)
        '        DataGridView.DataSource = Table
        '    End Using
        'End Using

    End Sub

    Private Sub frm_login_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged

    End Sub
End Class
