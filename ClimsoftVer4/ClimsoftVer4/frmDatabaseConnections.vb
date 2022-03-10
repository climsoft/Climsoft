Imports System.Security.AccessControl
Imports System.Security.Principal


Public Class frmDatabaseConnections

    Private Sub frmDatabaseConnections_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim builder As New System.Data.Common.DbConnectionStringBuilder()
        Dim connection As String
        Dim connectionString As String
        Dim parts As String()

        dataGridViewConnections.Rows.Clear()

        For Each line As String In frmLogin.connectionDetails
            parts = line.Split("|")
            connection = parts(0)
            Try
                ' Attempt to offer the second part to the connection string builder
                connectionString = parts(1)
                builder.ConnectionString = connectionString
                dataGridViewConnections.Rows.Add(connection, builder("server"), builder("database"), builder("port"))
            Catch ex As Exception
                ' If a line fails for any reason then we skip it. It is invalid, therefore it will
                ' not be displayed and it will not be written back to the file.
            End Try
        Next

        ClsTranslations.TranslateForm(Me)
        'todo in future this will be done automatically by TranslateForms(Me)
        ClsTranslations.TranslateComponent(dataGridViewConnections, True)

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Dim builder As New Common.DbConnectionStringBuilder()
        Dim connection As String
        Dim connectionString As String
        Dim database As String
        Dim port As String
        Dim server As String

        For Each row As DataGridViewRow In dataGridViewConnections.Rows
            builder = New Common.DbConnectionStringBuilder()
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

        ' All rows have now been validated. 

        ' If `filePath` already exists then Create() will clear the current contents
        IO.Directory.CreateDirectory(frmLogin.directoryPath)
        IO.File.Create(frmLogin.filePath).Dispose()
        ' Grant full access on `filePath` for all users (allows any user to write to file)
        ' This is currently necessary because some Climsoft installers are not Windows Administrators
        Dim dInfo As IO.DirectoryInfo = New IO.DirectoryInfo(frmLogin.filePath)
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()
        dSecurity.AddAccessRule(New FileSystemAccessRule(
            New SecurityIdentifier(WellKnownSidType.WorldSid, Nothing),
            FileSystemRights.FullControl,
            InheritanceFlags.ObjectInherit Or InheritanceFlags.ContainerInherit,
            PropagationFlags.NoPropagateInherit, AccessControlType.Allow
        ))
        dInfo.SetAccessControl(dSecurity)

        ' Loop over validated rows and add details from each row to `filePath`
        Using writer As IO.StreamWriter = New IO.StreamWriter(frmLogin.filePath)
            For Each row As DataGridViewRow In dataGridViewConnections.Rows
                builder = New Common.DbConnectionStringBuilder()
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

                ' Check that the connection string is accepted by the connection string builder
                ' (otherwise warn and continue)
                Try
                    builder.ConnectionString = connectionString
                Catch ex As Exception
                    MsgBox("Unable to save connection information for connection """ & connection & """" &
                        Environment.NewLine & Environment.NewLine & ex.Message)
                    Continue For
                End Try

                ' Only save if the built connection string is not null/empty
                If Not String.IsNullOrEmpty(builder.ConnectionString) Then
                    writer.WriteLine(connection & "|" & builder.ConnectionString)
                End If
            Next
        End Using

        frmLogin.refreshDatabases()
        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles dataGridViewConnections.SelectionChanged
        Try
            If dataGridViewConnections.CurrentCell.RowIndex + 1 = dataGridViewConnections.Rows.Count Then
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
            colIndex = dataGridViewConnections.SelectedCells(0).OwningColumn.Index
            row = dataGridViewConnections.Rows(dataGridViewConnections.CurrentCell.RowIndex)
            dataGridViewConnections.Rows.Remove(row)
            dataGridViewConnections.Rows.Insert(0, row)
            dataGridViewConnections.Refresh()
            dataGridViewConnections.ClearSelection()
            dataGridViewConnections.Rows(0).Cells(colIndex).Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdTest_Click(sender As Object, e As EventArgs) Handles cmdTest.Click

    End Sub

    Private Sub cmdRemove_Click(sender As Object, e As EventArgs) Handles cmdRemove.Click
        Try
            dataGridViewConnections.Rows.RemoveAt(dataGridViewConnections.CurrentCell.RowIndex)
            dataGridViewConnections.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs)

    End Sub
End Class