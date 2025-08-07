Imports System.IO

Public Class frmBackup
    Dim strBackupFolder As String, strBackupFolderUnixStyle As String
    Private Sub frmBackup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Export data by station
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        Dim sql, sql2, sql3, stnId, rec As String
        Dim i As Integer

        Dim da, da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds, ds1 As New DataSet
        Dim maxRows As Integer

        connStr = frmLogin.txtusrpwd.Text & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"

        conn.ConnectionString = connStr
        conn.Open()


        sql = "SELECT stationId FROM station"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        da.Fill(ds, "station")
        maxRows = ds.Tables("station").Rows.Count
        'stnId = "67774010"
        For i = 0 To maxRows - 1
            Try
                stnId = ds.Tables("station").Rows(i).Item("stationId")
                ''Check if old backup file exists
                'If System.IO.File.Exists(System.IO.Path.Combine(strBackupFolder, stnId & "_backup.csv")) Then
                '    'If old backup file exists, delete the file
                '    'RestorePath = System.IO.Path.Combine(strBackupFolder, stnBackupFile) 
                '    My.Computer.FileSystem.DeleteFile(System.IO.Path.Combine(strBackupFolder, stnId & "_backup.csv"))
                'End If
                'sql2 = "SELECT recordedfrom,describedby,obsdatetime,obslevel,obsvalue,flag,qcstatus,acquisitiontype FROM observationfinal where recordedfrom='" & stnId & "' INTO  OUTFILE '" & strBackupFolderUnixStyle & "/" & stnId & "_backup.csv' FIELDS TERMINATED BY ','"
                sql3 = "SELECT recordedfrom,describedby,obsdatetime,obslevel,obsvalue,flag,qcstatus,qcTypeLog,acquisitiontype,dataForm,capturedBy FROM observationfinal where recordedfrom='" & stnId & "';"

                'fl1 = strBackupFolder & "\" & stnId & "_backup.csv"
                'File.Open(1, fl1)
                da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql3, conn)
            ds1.Clear()
            da1.Fill(ds1, "backup")

                FileOpen(133, strBackupFolder & "\" & stnId & "_backup.csv", OpenMode.Output)

                With ds1.Tables("backup")
                For j = 0 To .Rows.Count - 1
                        rec = .Rows(j).Item(0) & "," & .Rows(j).Item(1) & "," & DateAndTime.Year(.Rows(j).Item(2)) & "-" & DateAndTime.Month(.Rows(j).Item(2)) & "-" & DateAndTime.Day(.Rows(j).Item(2)) & " " & DateAndTime.Hour(.Rows(j).Item(2)) & ":" & DateAndTime.Minute(.Rows(j).Item(2)) & ":" & DateAndTime.Second(.Rows(j).Item(2))
                        For k = 3 To .Columns.Count - 1
                            rec = rec & "," & .Rows(j).Item(k)
                        Next
                        PrintLine(133, rec)
                Next
            End With
            FileClose(133)


                ' MsgBox(sql)
                ' Create the Command for executing query and set its properties
                'objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql2, conn)
                'Try
                '    lblBackupProgress.Text = ClsTranslations.GetTranslation("Backing up observation data for station") & " [" & stnId & "]"
                '    lblBackupProgress.Refresh()
                '    'Execute query
                '    objCmd.ExecuteNonQuery()

                '    ' Catch ex As MySql.Data.MySqlClient.MySqlException
                'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
            End Try
        Next i
        MsgBox(ClsTranslations.GetTranslation("Data exported successfully!"), MsgBoxStyle.Information)
        conn.Close()
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#backup")
    End Sub

    Private Sub txtBackupFolder_TextChanged(sender As Object, e As EventArgs) Handles txtBackupFolder.TextChanged
        If Strings.Len(txtBackupFolder.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub
End Class