Public Class frmDatabaseConnections

    Private Sub frmDatabaseConnections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()
        Dim connection As String
        Dim connectionString As String
        Dim key As Microsoft.Win32.RegistryKey
        Dim result As Integer
        Dim row As DataGridViewRow

        DataGridView1.Rows.Clear()
        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Climsoft4")

        If key IsNot Nothing Then
            For Each subKey As String In key.GetValueNames
                If subKey.StartsWith("db_") Then
                    connectionString = My.Computer.Registry.GetValue(
                    "HKEY_LOCAL_MACHINE\Software\Climsoft4", subKey, Nothing)
                    connection = Mid(subKey, 4)
                    Try
                        builder.ConnectionString = connectionString
                        DataGridView1.Rows.Add(connection, builder("server"), builder("database"), builder("port"))
                    Catch ex As Exception
                        result = MessageBox.Show(
                            "Unable to read connection details for """ & connection & """ from the " &
                            "Windows registry. Would you Like to clear the details for this connection " &
                            "to resolve the problem (this action cannot be undone)?" &
                            Environment.NewLine & Environment.NewLine & ex.Message,
                            "Climsoft Warning", MessageBoxButtons.YesNo)
                        If result = DialogResult.No Then
                            Exit Sub
                        ElseIf result = DialogResult.Yes Then
                            My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Climsoft4", True).DeleteValue(
                                "db_" & connection)
                        End If
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        ' In My Project/Compile, make sure that Target CPU is set to "AnyCPU" and uncheck "Prefer 32-bit"
        ' Otherwise the registry key can get 'redirected', e.g. into SOFTWARE\Wow6432Node
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()
        Dim connection As String
        Dim connectionString As String
        Dim database As String
        Dim key As Microsoft.Win32.RegistryKey
        Dim port As String
        Dim server As String

        For Each row As DataGridViewRow In DataGridView1.Rows
            builder = New System.Data.Common.DbConnectionStringBuilder()
            connection = row.Cells(0).Value
            server = row.Cells(1).Value
            database = row.Cells(2).Value
            port = row.Cells(3).Value

            ' Skip empty rows (and continue to process other rows)
            If String.IsNullOrEmpty(connection) And String.IsNullOrEmpty(server) And
                    String.IsNullOrEmpty(database) And String.IsNullOrEmpty(port) Then
                Continue For
            End If

            ' Connection name: must not be empty (abort save)
            If String.IsNullOrEmpty(connection) Then
                MsgBox("Unable to save connections. Please ensure that each connection has a connection name")
                Exit Sub
            End If

            ' Connection name: Match one or more letters, numbers or underscores (otherwise abort save)
            If Not System.Text.RegularExpressions.Regex.IsMatch(connection, "^[a-zA-Z0-9_]+$") Then
                MsgBox("Unable to save connection information due to connection """ & connection & """" &
                       Environment.NewLine & Environment.NewLine &
                       "The connection name must only contain letters, numbers and underscores")
                Exit Sub
            End If

            ' Server address: Match one or more letters, numbers or hyphen or
            '                 match numbers and period allowing IP addresses (otherwise abort save)
            If String.IsNullOrEmpty(server) OrElse
                Not System.Text.RegularExpressions.Regex.IsMatch(server, "^[a-zA-Z0-9-]+$") And
                Not System.Text.RegularExpressions.Regex.IsMatch(server, "^[0-9.]+$") Then

                MsgBox("Unable to save connection information due to connection """ & connection & """" &
                       Environment.NewLine & Environment.NewLine &
                       "The server address must only contain letters, numbers and hyphens (or numbers " &
                       "and periods for IP addresses, e.g. 127.0.0.1)")
                Exit Sub
            End If

            ' Database name: Match one or more letters, numbers or underscores (otherwise abort save)
            If String.IsNullOrEmpty(database) OrElse
                Not System.Text.RegularExpressions.Regex.IsMatch(database, "^[a-zA-Z0-9_]+$") Then

                MsgBox("Unable to save connection information due to connection """ & connection & """" &
                       Environment.NewLine & Environment.NewLine &
                       "The database name must only contain letters, numbers and underscores")
                Exit Sub
            End If

            ' Port number: Match one or more numbers (otherwise abort save)
            If String.IsNullOrEmpty(port) OrElse
                Not System.Text.RegularExpressions.Regex.IsMatch(port, "^[0-9]+$") Then

                MsgBox("Unable to save connection information due to connection """ & connection & """" &
                       Environment.NewLine & Environment.NewLine &
                       "The port number must be a whole number (e.g. 3306 or 3308)")
                Exit Sub
            End If
        Next

        ' All rows have now been validated remove all existing database connection settings from
        ' the Windows registry
        key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Climsoft4")

        If key Is Nothing Then
            key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\Climsoft4")
        End If

        For Each subKey As String In key.GetValueNames
            If subKey.StartsWith("db_") Then
                My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Climsoft4", True).DeleteValue(subKey)
            End If
        Next

        ' Loop over validated rows and add details from each row to the Windows registry
        For Each row As DataGridViewRow In DataGridView1.Rows
            builder = New System.Data.Common.DbConnectionStringBuilder()
            connection = row.Cells(0).Value
            server = row.Cells(1).Value
            database = row.Cells(2).Value
            port = row.Cells(3).Value

            ' Skip empty rows (and continue to save other rows to registry)
            If String.IsNullOrEmpty(connection) And String.IsNullOrEmpty(server) And
                String.IsNullOrEmpty(database) And String.IsNullOrEmpty(port) Then
                Continue For
            End If

            connectionString = "server=" & server & ";database=" & database & ";port=" & port

            ' Check that the connection string is accepted by the connection string builder (otherwise warn)
            Try
                builder.ConnectionString = connectionString
            Catch ex As Exception
                MsgBox("Unable to save connection information for connection """ & connection & """" &
                    Environment.NewLine & Environment.NewLine & ex.Message)
                Continue For
            End Try

            ' Only save to registry if the built connection string is not null/empty
            ' All connection names will have a prefix "db_"
            If Not String.IsNullOrEmpty(builder.ConnectionString) Then
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("Software\\Climsoft4")
                key.SetValue("db_" & connection, connectionString)
            End If
        Next

        frmLogin.refreshDatabases()
        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            If DataGridView1.CurrentCell.RowIndex + 1 = DataGridView1.Rows.Count Then
                grpCurrentSelection.Enabled = False
            Else
                grpCurrentSelection.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdMakeDefault_Click(sender As Object, e As EventArgs) Handles cmdMakeDefault.Click
        Dim colIndex As Integer
        Dim row As DataGridViewRow
        Try
            colIndex = DataGridView1.SelectedCells(0).OwningColumn.Index
            row = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex)
            DataGridView1.Rows.Remove(row)
            DataGridView1.Rows.Insert(0, row)
            DataGridView1.Refresh()
            DataGridView1.ClearSelection()
            DataGridView1.Rows(0).Cells(colIndex).Selected = True
        Catch ex As Exception

        End Try


        '        List<MyObj> foo = DGV.DataSource;
        'Int idx = DGV.SelectedRows[0].Index;
        'Int value = foo[idx];
        'foo.Remove(value);
        'foo.InsertAt(idx+1, value)
    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click

    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Try
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentCell.RowIndex)
            DataGridView1.Refresh()
        Catch ex As Exception

        End Try
    End Sub

End Class