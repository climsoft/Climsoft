Public Class frmRestore
    Dim strBackupFolder As String, strBackupFolderUnixStyle As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Import data by station
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        Dim sql As String, sql2 As String, stnId As String, i As Integer

        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds As New DataSet
        Dim maxRows As Integer
        Dim RestorePath As String, stnBackupFile As String

        connStr = frmLogin.txtusrpwd.Text

        conn.ConnectionString = connStr
        conn.Open()

        sql = "SELECT stationId FROM station"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        da.Fill(ds, "station")
        maxRows = ds.Tables("station").Rows.Count

        conn.Close()

        For i = 0 To maxRows - 1
        stnId = ds.Tables("station").Rows(i).Item("stationId")
        stnBackupFile = stnId & "_backup.csv"
        RestorePath = System.IO.Path.Combine(strBackupFolder, stnBackupFile) 'combines the saveDirectory and the filename to get a fully qualified path.

            If System.IO.File.Exists(RestorePath) Then
                conn.Open()

                sql2 = "LOAD DATA INFILE '" & strBackupFolderUnixStyle & "/" & stnBackupFile & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedfrom,describedby,obsdatetime,obslevel,obsvalue,flag,qcstatus,acquisitiontype);"
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql2, conn)
                Try
                    lblDataIngestionProgress.Text = ClsTranslations.GetTranslation("Importing backup data for station") & " [" & stnId & "]"
                    lblDataIngestionProgress.Refresh()
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    conn.Close()
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                End Try
            End If

        Next i
        conn.Close()
        MsgBox(ClsTranslations.GetTranslation("Observation data imported successfully!"))

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#restore")
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        dialog.SelectedPath = "C:\"
        dialog.Description = ClsTranslations.GetTranslation("Select Path for backup files")
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strBackupFolder = dialog.SelectedPath
            txtBackupFolder.Text = strBackupFolder
            'Search and replace backslash "\" in folder path with forward slash "/"
            strBackupFolderUnixStyle = strBackupFolder.Replace("\", "/")
            'MsgBox(strBackupFolderUnixStyle)
        End If
    End Sub

    Private Sub frmRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub txtBackupFolder_TextChanged(sender As Object, e As EventArgs) Handles txtBackupFolder.TextChanged
        If Strings.Len(txtBackupFolder.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub
End Class