﻿Public Class frmDataMigration

    Dim da, da1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds, ds1 As New DataSet
    Dim sql, bkpfile, fchar As String
    Dim conn, conn1 As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    Dim ReplaceIgnore As String
    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        Dim sql_stn, sql_elm, sql_obsv, dbstr3, dbstr4, sql_scale As String
        'Dim obsv_tmpbkpfile, stn_tmpbkpfile, elm_tmpbkpfile As String
        lstMsgs.Items.Clear()

        Try
            'Dim sql_obsv, dbstr, tmpbkpfile, sql_scale As String
            sql_obsv = ""

            ' Export CLIMSOFT 3 Mysql db to text (CSV) backup
            lstMsgs.Items.Clear()

            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()

            Dim DataPath As String

            ' Define the products application path
            DataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\data"

            If Not IO.Directory.Exists(DataPath) Then
                IO.Directory.CreateDirectory(DataPath)
            End If

            ' Set busy Cursor pointer
            Me.Cursor = Cursors.WaitCursor

            dbstr4 = txtV4db.Text
            dbstr3 = txtV3db.Text

            ' Set the Records Replace (i.e. overwrite) or Ignore (i.e. skip) duplicate records mode
            ReplaceIgnore = "IGNORE"
            If chkboxReplace.Checked = True Then ReplaceIgnore = "REPLACE"

            If optV3MysqlDb.Checked = True Then
                Dim obsv_tmpbkpfile, stn_tmpbkpfile, elm_tmpbkpfile As String

                ' Get a string for the full path for temporary backup file.
                obsv_tmpbkpfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\obsv_backup.csv"
                stn_tmpbkpfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\stn_backup.csv"
                elm_tmpbkpfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\elm_backup.csv"

                ' Delete previous backup filees if they are there
                If System.IO.File.Exists(obsv_tmpbkpfile) Then System.IO.File.Delete(obsv_tmpbkpfile)
                If System.IO.File.Exists(stn_tmpbkpfile) Then System.IO.File.Delete(stn_tmpbkpfile)
                If System.IO.File.Exists(elm_tmpbkpfile) Then System.IO.File.Delete(elm_tmpbkpfile)

                'Restructure file path according the mysql path formart
                obsv_tmpbkpfile = Mysql_FilePath(obsv_tmpbkpfile)
                stn_tmpbkpfile = Mysql_FilePath(stn_tmpbkpfile)
                elm_tmpbkpfile = Mysql_FilePath(elm_tmpbkpfile)

                If optEntireDb.Checked = True Then
                    sql_obsv = "use " & dbstr3 & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status,qc_type_log,acquisition_type,data_form,captured_by,mark from observation into outfile '" & obsv_tmpbkpfile & "' fields terminated by ',';"
                ElseIf optSeletedRecords.Checked = True Then
                    sql_obsv = "use " & dbstr3 & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status,qc_type_log,acquisition_type, data_form, captured_by,mark from observation where year(recorded_at) between '" & txtByear.Text & "' and '" & txtEyear.Text & "' into outfile '" & obsv_tmpbkpfile & "' fields terminated by ',';"
                End If

                ' Create observations backup file
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                ' Create stations backup file
                sql_stn = "use " & dbstr3 & ";select id,station_name,qualifier,country,authority from station into outfile '" & stn_tmpbkpfile & "' fields terminated by ',';"
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_stn, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                ' Create elements observations backup file
                sql_elm = "use " & dbstr3 & ";select code,abbreviation,element_name,description,element_scale,upper_limit,lower_limit,units,element_type,total,selected from obs_element into outfile '" & elm_tmpbkpfile & "' fields terminated by ',';"
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_elm, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                bkpfile = obsv_tmpbkpfile

                ' Update station metadata of migrated database
                sql_stn = "use " & dbstr4 & ";LOAD DATA LOCAL INFILE '" & stn_tmpbkpfile & "' IGNORE INTO TABLE station FIELDS TERMINATED BY ',' (stationId,stationName,qualifier,country,authority);"
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_stn, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                lstMsgs.Items.Add(ClsTranslations.GetTranslation("Station metadata updated"))

                ' Update elements metadata
                sql_elm = "use " & dbstr4 & ";LOAD DATA LOCAL INFILE '" & elm_tmpbkpfile & "' IGNORE INTO TABLE obselement FIELDS TERMINATED BY ',' (elementId,abbreviation,elementName,description,elementScale,upperLimit,lowerLimit,units,elementtype,qcTotalRequired,selected);"
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_elm, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                lstMsgs.Items.Add(ClsTranslations.GetTranslation("Element metadata updated"))
            End If

            ' Import from CLIMSOFT V3 backup file to CLIMSOFT V4 db
            If optV3Backup.Checked = True Then

                If Len(txtBkpFile.Text) = 0 Then
                    lstMsgs.Items.Add(ClsTranslations.GetTranslation("No backup fle selected"))
                    Me.Cursor = Cursors.Default
                    conn.Close()
                    Exit Sub
                End If
                ' Update station metadata
                sql_stn = "LOAD DATA LOCAL INFILE '" & bkpfile & "' IGNORE INTO TABLE station FIELDS TERMINATED BY ',' (stationId);"

                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_stn, conn)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                '' Update elements metadata
                ''sql_elm = "LOAD DATA LOCAL INFILE '" & bkpfile & "' IGNORE INTO TABLE obselement FIELDS TERMINATED BY ',' (@col1,@col2,@col3,@col4,@col5,@col6,@col7,@col8,@col9,@col10,@col11,@col12,@col13) set elementId=@col2;"
                'sql_elm = "LOAD DATA LOCAL INFILE '" & bkpfile & "' IGNORE INTO TABLE obselement FIELDS TERMINATED BY ',' (@col1,elementId,@col3,@col4,@col5,@col6,@col7,@col8,@col9,@col10,@col11);"

                '    cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_elm, conn)
                '    cmd.CommandTimeout = 0
                '    cmd.ExecuteNonQueryAsync()

                ' Create SQL query for observation update
                sql_obsv = "LOAD DATA LOCAL INFILE '" & bkpfile & "' " & ReplaceIgnore & " INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark);"
            Else
                sql_obsv = "use " & dbstr4 & ";LOAD DATA LOCAL INFILE '" & bkpfile & "' " & ReplaceIgnore & " INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark);"
            End If

            'Execute query for migrating data to V4 db
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            lstMsgs.Items.Add(ClsTranslations.GetTranslation("Observations updated"))

            sql_scale = "UPDATE IGNORE observationinitial INNER JOIN obselement ON describedBy = elementId SET obsValue = obsValue/elementScale, mark =71 where obsValue <> '' and elementScale > 0 and (mark is null or mark <> 71);"

            'Execute query for observation vlaues scaling
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_scale, conn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            lstMsgs.Items.Add(ClsTranslations.GetTranslation("Observations scaling removed"))

            lstMsgs.Items.Add(ClsTranslations.GetTranslation("CLIMSOFT V3 migration completed"))
            Me.Cursor = Cursors.Default
            conn.Close()
        Catch ex As Exception
            lstMsgs.Items.Add(Err.Description)
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try

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
        'On Error GoTo Err
        Dim bkpfolder, bkpfilename, bkpConnStr, dt, val, obsvdata As String
        Dim rws, flds As Integer
        Dim dap As OleDb.OleDbDataAdapter
        Dim DataPath, dat As String
        Dim nums, lin As Integer
        Dim rows As String()
        Dim currentRow As String()

        lstMsgs.Items.Clear()

        Try
            Me.Cursor = Cursors.WaitCursor
            ' Define the text files application path
            'DataPath = IO.Path.GetFullPath(Application.StartupPath) & "\data"
            DataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            If Not IO.Directory.Exists(DataPath) Then
                IO.Directory.CreateDirectory(DataPath)
            End If

            OpenFileBackup.Filter = ClsTranslations.GetTranslation("Comma Delimited") & "|*.csv"
            OpenFileBackup.Title = ClsTranslations.GetTranslation("Open Import Text File")
            OpenFileBackup.ShowDialog()

            bkpfile = OpenFileBackup.FileName

            ' Display the selected backup file
            txtBkpFile.Text = bkpfile

            'Get the folder for the backup file
            bkpfolder = IO.Directory.GetParent(bkpfile).FullName

            'Get the backup file name excluding the file path
            bkpfilename = Strings.Mid(bkpfile, Len(bkpfolder) + 2, Len(bkpfile) - Len(bkpfolder))

            ' Create a text file for the output of CLIMSOFT backup import file 
            bkpfile = DataPath & "\ClimsoftBackup.csv"

            FileOpen(1, bkpfile, OpenMode.Output)

            ' Convert the file path for the import backup to mysql format
            bkpfile = Mysql_FilePath(bkpfile)

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtBkpFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")

                Do While MyReader.EndOfData = False

                    lin = MyReader.LineNumber()

                    currentRow = MyReader.ReadFields()

                    If lin > 1 Then
                        nums = 0

                        For Each currentField In currentRow
                            rows = New String() {currentField}

                            If nums = 0 Then dat = rows(0)

                            ' Convert datetime structure into MySQL format
                            If nums = 2 Then
                                dt = rows(0)
                                val = DateAndTime.Year(dt) & "-" & Format(DateAndTime.Month(dt), "00") & "-" & Format(DateAndTime.Day(dt), "00") & " " & Format(DateAndTime.Hour(dt), "00") & ":" & Format(DateAndTime.Minute(dt), "00") & ":00"
                                dat = dat & "," & val
                            ElseIf nums <> 0 Then
                                dat = dat & "," & rows(0)
                            End If

                            If nums = 11 Then Exit For
                            nums = nums + 1
                        Next
                        Print(1, dat & ",9") ' Set value for the field Mark to 9. This allows selection of values that required requires scaling
                        PrintLine(1)
                    End If
                Loop

            End Using

            FileClose(1)
            Me.Cursor = Cursors.Default
            lstMsgs.Items.Add(ClsTranslations.GetTranslation("CLIMSOFT 3 Backup converted to CLIMSOFT 4 Structure"))

            Me.Cursor = Cursors.Default
            'Exit Sub
        Catch Err As Exception
            lstMsgs.Items.Add(Err.Message)
            'MsgBox(lstMsgs.Items.Add(Err.Description))
            Me.Cursor = Cursors.Default
        End Try
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

    Private Sub lblV3_Click(sender As Object, e As EventArgs) Handles lblV3.Click

    End Sub

    Private Sub frmDataMigration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtV4db.Text = frmDBUtilities.Current_db
        txtEyear.Text = DateAndTime.Year(Now())

        conn1.ConnectionString = frmLogin.txtusrpwd.Text
        conn1.Open()

        'Sql = "SELECT * FROM station"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM station", conn1)
        da1.Fill(ds1, "station")

        conn1.Close()

        ClsTranslations.TranslateForm(Me)

    End Sub

    Sub v4Backup(bkpfile As String)
        On Error GoTo Err
        Dim nums, lin As Integer
        Dim rows As String()
        Dim currentRow As String()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtBkpFile.Text)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            FileOpen(10, bkpfile, OpenMode.Output)
            Do While MyReader.EndOfData = False
                lin = MyReader.LineNumber()

                currentRow = MyReader.ReadFields()

                If lin > 1 Then
                    nums = 0

                    For Each currentField In currentRow
                        rows = New String() {currentField}
                        Print(10, rows)
                        If nums = 7 Then Exit For
                        Print(10, ",")
                        nums = nums + 1

                    Next
                    PrintLine(10)
                End If
            Loop
            'MsgBox("V4 Backup Made")
            lstMsgs.Items.Add(ClsTranslations.GetTranslation("CLIMSOFT 3 Backup converted to CLIMSOFT 4 Structure"))
        End Using
        FileClose(10)
        Exit Sub
Err:
        'If Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Function StationExist(stnid As String) As Boolean
        Dim recs As Long

        conn1.ConnectionString = frmLogin.txtusrpwd.Text
        conn1.Open()
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM station", conn1)
        da1.Fill(ds1, "station")
        conn1.Close()

        StationExist = False
        With ds1.Tables("station")
            recs = .Rows.Count
            For i = 0 To recs - 1
                If stnid = .Rows(i).Item("stationId") Then
                    StationExist = True
                    Exit For
                End If
            Next
        End With
    End Function

    Function ElementExist(id As String) As Boolean
        Dim recs As Long

        conn1.ConnectionString = frmLogin.txtusrpwd.Text
        conn1.Open()
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM obselement", conn1)
        da1.Fill(ds1, "obselement")
        conn1.Close()

        ElementExist = False
        With ds1.Tables("obselement")
            recs = .Rows.Count
            For i = 0 To recs - 1
                If id = .Rows(i).Item("elementId") Then
                    ElementExist = True
                    Exit For
                End If
            Next
        End With
    End Function
    'Sub linkTextFile()
    '    Dim das As OleDb.OleDbDataAdapter
    '    Dim strConnString As String
    '    Dim conn1 As New OleDb.OleDbConnection

    '    strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strClicomDataFolder & ";Extended Properties=Text;"

    '    'rec = -1

    '    'Try
    '    conn1.ConnectionString = strConnString
    '    conn1.Open()

    '    sql = "SELECT * FROM [" & "clicom_daily.csv" & "]"

    '    das = New OleDb.OleDbDataAdapter(sql, conn1)
    '    das.Fill(ds, "clicomDaily")
    '    conn1.Close()

    '    maxRows = ds.Tables("clicomDaily").Rows.Count
    '    ' MsgBox("Number of rows: " & maxRows)

    '        stnId = ds.Tables("clicomDaily").Rows(n).Item(1)
    '        elemCode = ds.Tables("clicomDaily").Rows(n).Item(2)

    'End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#from_v3mysqldb")
    End Sub
End Class