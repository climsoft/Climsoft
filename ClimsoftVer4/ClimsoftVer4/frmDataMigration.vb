Public Class frmDataMigration
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql, bkpfile, fchar As String
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        On Error GoTo Err
        Dim sql_obsv, dbstr, svrstr, prtusrpwd, myconnectstr, tmpbkpfile As String

        ' Export CLIMSOFT 3 Mysql db to text (CSV) backup
        lstMsgs.Items.Clear()

        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()

        If optV3MysqlDb.Checked = True Then
            ' Get a string for the full path for backup file and restructure it according the mysql path formart
            tmpbkpfile = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\backup.csv"
            bkpfile = Mysql_FilePath(tmpbkpfile)

            dbstr = txtV3db.Text

            If optEntireDb.Checked = True Then
                'sql_obsv = "use " & dbstr & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status,qc_type_log,acquisition_type,data_form,captured_by,mark from observation into outfile '" & bkpfile & "' fields terminated by ',';"
                sql_obsv = "use " & dbstr & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status from observation into outfile '" & bkpfile & "' fields terminated by ',';"
            ElseIf optSeletedRecords.Checked = True Then
                'sql_obsv = "use " & dbstr & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status,qc_type_log,acquisition_type,data_form,captured_by,mark from observation where year(recorded_at) between '" & txtByear.Text & "' and '" & txtEyear.Text & "' into outfile '" & bkpfile & "' fields terminated by ',';"
                sql_obsv = "use " & dbstr & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status from observation where year(recorded_at) between '" & txtByear.Text & "' and '" & txtEyear.Text & "' into outfile '" & bkpfile & "' fields terminated by ',';"
            End If

            ' Delete previous backup file
            If System.IO.File.Exists(tmpbkpfile) Then System.IO.File.Delete(tmpbkpfile)

            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)

            'Execute query for making a V3 db backup
            cmd.ExecuteNonQuery()

            lstMsgs.Items.Add("CLIMSOFT V3 backup created")
        End If

        ' Import from CLIMSOFT V3 backup file to CLIMSOFT V4 db
        dbstr = txtV4db.Text

        If optV3Backup.Checked = True Then
            sql_obsv = "use " & dbstr & "; LOAD DATA INFILE '" & bkpfile & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus);"
        Else
            'sql_obsv = "use " & dbstr & "; LOAD DATA INFILE '" & bkpfile & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark);"
            sql_obsv = "use " & dbstr & "; LOAD DATA INFILE '" & bkpfile & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus);"
        End If

        'Execute query for migrating data to V4 db
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)
        cmd.ExecuteNonQuery()

        lstMsgs.Items.Add("CLIMSOFT V3 migration completed")

        conn.Close()
        Exit Sub
Err:
        lstMsgs.Items.Add(Err.Description)

    End Sub


    Private Sub optV3Backup_CheckedChanged(sender As Object, e As EventArgs) Handles optV3Backup.CheckedChanged
        If optV3Backup.Checked = True Then
            grpV3Backup.Enabled = True
            grpV3MysqlDb.Enabled = False
        Else
            grpV3MysqlDb.Enabled = True
            grpV3Backup.Enabled = False
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdCSV_Click(sender As Object, e As EventArgs) Handles cmdCSV.Click
        On Error GoTo Err
        Dim bkpfolder, bkpfilename, bkpConnStr, dt, val, obsvdata As String
        Dim rws, flds As Integer
        Dim dap As OleDb.OleDbDataAdapter

        OpenFileBackup.Filter = "Comma Delimited|*.csv"
        OpenFileBackup.Title = "Open Import Text File"
        OpenFileBackup.ShowDialog()

        bkpfile = OpenFileBackup.FileName

        ' Display the selected backup file
        txtBkpFile.Text = bkpfile

        'Get the folder for the backup file
        bkpfolder = IO.Directory.GetParent(bkpfile).FullName

        'Get the backup file name excluding the file path
        bkpfilename = Strings.Mid(bkpfile, Len(bkpfolder) + 2, Len(bkpfile) - Len(bkpfolder))

        ' Create a text file for the output of CLIMSOFT backup import file 
        bkpfile = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\ClimsoftBackup.csv"
        FileOpen(1, bkpfile, OpenMode.Output)

        ' Convert the file path for the import backup to mysql format
        bkpfile = Mysql_FilePath(bkpfile)

        ' Create a connection to the selected backup file
        bkpConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & bkpfolder & ";Extended Properties=Text;"
        Dim conn1 As New OleDb.OleDbConnection

        conn1.ConnectionString = bkpConnStr
        conn1.Open()

        sql = "SELECT * FROM [" & bkpfilename & "]"

        dap = New OleDb.OleDbDataAdapter(sql, conn1)
        ds.Clear()
        dap.Fill(ds, "BackupFile")
        conn1.Close()

        rws = ds.Tables("BackupFile").Rows.Count
        flds = ds.Tables("BackupFile").Columns.Count

        ' Get Records from the selected backup file into the import file
        For i = 0 To rws - 1
            For j = 0 To 7
                If Not IsDBNull(ds.Tables("BackupFile").Rows(i).Item(j)) Then
                    val = ds.Tables("BackupFile").Rows(i).Item(j)
                Else
                    val = ""
                End If

                If ds.Tables("BackupFile").Columns(j).ColumnName = "recorded_at" Then
                    dt = ds.Tables("BackupFile").Rows(i).Item(j)
                    val = DateAndTime.Year(dt) & "-" & Format(DateAndTime.Month(dt), "00") & "-" & Format(DateAndTime.Day(dt), "00") & " " & Format(DateAndTime.Hour(dt), "00") & ":" & Format(DateAndTime.Minute(dt), "00") & ":00"
                End If
                If j = 0 Then
                    obsvdata = val
                Else
                    obsvdata = obsvdata & "," & val
                End If
            Next
            PrintLine(1, obsvdata)
        Next
        FileClose(1)
        lstMsgs.Items.Add("CLIMSOFT 3 Backup converted to CLIMSOFT 4 Structure")
        Exit Sub
Err:
        MsgBox(lstMsgs.Items.Add(Err.Description))
    End Sub

    Function Mysql_FilePath(flpath As String) As String
        Dim fchar As String

        Mysql_FilePath = ""
        For i = 1 To Len(flpath)
            fchar = Strings.Mid(flpath, i, 1)
            If fchar = "\" Then fchar = "/"
            Mysql_FilePath = Mysql_FilePath & fchar
        Next
    End Function

    Private Sub frmDataMigration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtV4db.Text = frmDBUtilities.Current_db
        txtEyear.Text = DateAndTime.Year(Now())
    End Sub
End Class