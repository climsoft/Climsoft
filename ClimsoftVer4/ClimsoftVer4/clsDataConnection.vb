Public Class clsDataConnection
    Public Shared db As New mariadb_climsoft_test_db_v4Entities
    Private Shared ReadOnly conn As New MySql.Data.MySqlClient.MySqlConnection
    Public Shared databaseName As String = "mariadb_climsoft_test_db_v4"

    Public Shared Sub openConnection()
        If Not (conn.State = ConnectionState.Open) Then
            conn.ConnectionString = frmLogin.txtusrpwd.Text 'temporary connection string. This should come from somewhere else
            conn.Open()
        End If
    End Sub

    Public Shared ReadOnly Property OpenedConnection As MySql.Data.MySqlClient.MySqlConnection
        Get
            openConnection()
            Return conn
        End Get
    End Property

    Public Shared Sub closeConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

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
