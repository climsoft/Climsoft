Public Class clsDataConnection
    Private Shared ReadOnly conn As New MySqlConnector.MySqlConnection

    Public Shared Function GetOpenedConnection() As MySqlConnector.MySqlConnection
        If conn.State <> ConnectionState.Open Then
            conn.Open()
        End If
        Return conn
    End Function

    Public Shared Function GetDatabaseName() As String
        Return conn.Database
    End Function

    Public Shared Sub OpenConnection(ConnectionString As String)
        Try

            conn.ConnectionString = ConnectionString
            conn.Open()

        Catch ex As Exception
            'MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Public Shared Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Shared Function GetConnectionString() As String
        Return conn.ConnectionString
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
