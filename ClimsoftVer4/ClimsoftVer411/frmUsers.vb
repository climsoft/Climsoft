Public Class frmUsers
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim connStr As String, Sql As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    ' Dim sql As String
    
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        conn.Close()
        Me.Close()
    End Sub
    Private Sub populateDataGrid()
        Sql = "select * from climsoftusers"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        da.Fill(ds, "climsoftusers")
        Me.DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        populateDataGrid()
        ' ''Sql = "select * from climsoftusers"
        ' ''da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        ' ''da.Fill(ds, "climsoftusers")
        ' ''Me.DataGridView1.DataSource = ds.Tables(0)
        'connStr = frmLogin.txtusrpwd.Text

        'conn.ConnectionString = connStr
        'conn.Open()
        conn.Close()

    End Sub

    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click

        connStr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = connStr
        'Open connection to database
        conn.Open()
        If Strings.Len(txtUserPwd.Text) >= 6 Then
            If txtUserPwd.Text = txtPasswordConfirmation.Text Then
                
                'Try
                'add new user to [climsoftusers] table
                Sql = "INSERT INTO climsoftusers(userName,userRole) VALUES ('" & txtUserName.Text & "','" & cboUserType.Text & "'" & ")"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                objCmd.ExecuteNonQuery()

                'Create new user in [mysql.user] table
                Sql = "CREATE USER '" & txtUserName.Text & "'@'localhost' IDENTIFIED BY '" & txtUserPwd.Text & "';"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                'execute command
                objCmd.ExecuteNonQuery()
                'Create new user in [mysql.user] table
                Sql = "CREATE USER '" & txtUserName.Text & "'@'%' IDENTIFIED BY '" & txtUserPwd.Text & "';"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                'execute Command
                objCmd.ExecuteNonQuery()

                'Grant role to new user
                Sql = "GRANT " & cboUserType.Text & " TO '" & txtUserName.Text & "';"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                'execute command
                objCmd.ExecuteNonQuery()

                'Set default role to new user
                Sql = "SET DEFAULT ROLE " & cboUserType.Text & " FOR '" & txtUserName.Text & "'@'localhost';"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                'execute command
                objCmd.ExecuteNonQuery()

                'Flush privileges
                Sql = "FLUSH PRIVILEGES;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                'execute command
                objCmd.ExecuteNonQuery()

                ds.Tables.Clear()
                populateDataGrid()
                ' ''Sql = "select * from climsoftusers"
                ' ''da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
                ' ''da.Fill(ds, "climsoftusers")
                ' ''Me.DataGridView1.DataSource = ds.Tables(0)

                MsgBox("New user created successfully!", MsgBoxStyle.Information)

                'Catch ex As Exception
                ''Dispaly Exception error message 
                'MsgBox(ex.Message)
                conn.Close()
                ' End Try
            Else
                MsgBox("Wrong confirmation of password!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Password length must be >=6", MsgBoxStyle.Information)
        End If

        'Close connection
        conn.Close()
    End Sub
End Class