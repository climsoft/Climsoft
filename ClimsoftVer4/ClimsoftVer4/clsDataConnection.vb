Public Class clsDataConnection
    Private Shared ReadOnly conn As New MySql.Data.MySqlClient.MySqlConnection

    Public Shared Function GetOpenedConnection() As MySql.Data.MySqlClient.MySqlConnection
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
        Return conn
    End Function

    Public Shared Sub OpenConnection(ConnectionString As String)
        conn.ConnectionString = ConnectionString
        conn.Open()
    End Sub

    Public Shared Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Shared Function GetConnectionString() As String
        Return conn.ConnectionString
    End Function

    Public Shared Function GetDatabaseName() As String
        Return conn.Database
    End Function

    Public Shared Function GetUserName() As String
        Dim builder As New Common.DbConnectionStringBuilder With {
            .ConnectionString = GetConnectionString()
        }
        Return builder("user id")
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
