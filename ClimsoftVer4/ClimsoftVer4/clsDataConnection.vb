Public Class clsDataConnection
    Public Shared db As New mariadb_climsoft_test_db_v4Entities
    Public Shared ReadOnly conn As New MySql.Data.MySqlClient.MySqlConnection
    Public Shared databaseName As String = "mariadb_climsoft_test_db_v4"

    Public Shared Sub openConnection()
        If Not (conn.State = ConnectionState.Open) Then
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()
        End If
    End Sub

    Public Shared Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub


End Class
