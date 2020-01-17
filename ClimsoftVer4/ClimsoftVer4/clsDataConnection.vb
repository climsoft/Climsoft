Public Class clsDataConnection
    Private Shared ReadOnly conn As New MySql.Data.MySqlClient.MySqlConnection
    Public Shared databaseName As String = "mariadb_climsoft_test_db_v4"

    Public Shared ReadOnly Property OpenedConnection As MySql.Data.MySqlClient.MySqlConnection
        Get
            OpenConnection()
            Return conn
        End Get
    End Property

    Public Shared Sub OpenConnection()
        If Not (conn.State = ConnectionState.Open) Then
            conn.ConnectionString = frmLogin.txtusrpwd.Text 'temporary connection string. This should come from somewhere else
            conn.Open()
        End If
    End Sub

    Public Shared Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Shared Function GetConnectionString() As String
        Return OpenedConnection.ConnectionString
    End Function

    'temporary code for visual studio design time
    Public Shared Function IsInDesignMode() As Boolean
        'temporary for developers to prevent visual studio from executing code during design mode
        Dim process As System.Diagnostics.Process = System.Diagnostics.Process.GetCurrentProcess()
        If process.ProcessName = "devenv" Then
            process.Dispose()
            Return True
        End If
        Return False
    End Function

End Class
