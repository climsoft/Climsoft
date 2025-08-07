Public Class frmBackupRestore
    Dim bkprst, sql As String
    Dim conn1 As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    Private Sub cmdCSV_Click(sender As Object, e As EventArgs) Handles cmdCSV.Click
        On Error GoTo Err
        Dim dbTable As String

        If frmDBUtilities.cmbDb.Text = "Initial" Then
            dbTable = "observationinitial"
        Else
            dbTable = "observationfinal"
        End If

        Select Case Me.Text
            Case "Backup to Text File"
                dlgBackup.Filter = "Comma Delimited|*.csv"
                dlgBackup.Title = "Open Backup File"
                dlgBackup.ShowDialog()

                bkprst = dlgBackup.FileName
                bkprst = frmDataMigration.Mysql_FilePath(bkprst)
                sql = "use " & txtDb.Text & ";select recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark from " & dbTable & " where year(obsDatetime) between '" & txtByear.Text & "' and '" & txtEyear.Text & "' into outfile '" & bkprst & "' fields terminated by ',';"
            Case "Restore Backup File"
                dlgRestore.Filter = "Comma Delimited|*.csv"
                dlgRestore.Title = "Open Backup File"
                dlgRestore.ShowDialog()

                bkprst = dlgRestore.FileName
                bkprst = frmDataMigration.Mysql_FilePath(bkprst)
                sql = "use " & txtDb.Text & "; LOAD DATA INFILE '" & bkprst & "' IGNORE INTO TABLE " & dbTable & " FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark);"
        End Select

        txtFile.Text = bkprst
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        On Error GoTo Err

        'Execute query for migrating data to V4 db
        conn1.ConnectionString = frmLogin.txtusrpwd.Text & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
        conn1.Open()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
        cmd.ExecuteNonQuery()

        conn1.Close()
        MsgBox(Me.Text & " Complete")
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub frmBackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDb.Text = frmDBUtilities.Current_db
        txtEyear.Text = DateAndTime.Year(Now())
    End Sub
End Class