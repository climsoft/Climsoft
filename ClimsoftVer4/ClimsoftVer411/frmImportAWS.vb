' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class frmImportAWS
    Dim strFolderPath As String, strFileName As String, rec As Integer
    Dim sql As String, sql2 As String, sql3 As String
    Dim ds As New DataSet()
    Dim da As OleDb.OleDbDataAdapter
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim strDataFile As String, strSchemaFile As String, strAWSDataFolder As String
    Sub importAWS()
        Try
            Dim strConnString, AWSPath As String
            Dim maxDataRows As Integer, stnId As String, elemCode As String, obsYear As String, obsMonth As String, obsDate As String, obsDay As String, obsHour As String, _
                obsLevel As String, obsVal As String, obsFlag As String, qcStatus As Integer, acquisitionType As Integer, n As Integer, _
                j As Integer, i As Integer, obsMinute As String, elemFound As Boolean

            'Added to make provision for adjusting time in data file to local time. 20160716 ASM
            Dim InputDataDateTime As Date, dbStorageDateTime As Date, hourAdjustment As Integer

            stnId = ""
            elemCode = 0
            obsVal = ""
            obsFlag = ""

            'AWSPath = IO.Path.GetFullPath(Application.StartupPath) & "\data\aws_data"
            AWSPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\aws_data"

            If Not IO.Directory.Exists(AWSPath) Then
                IO.Directory.CreateDirectory(AWSPath)
            End If

            strDataFile = AWSPath & "\aws_data.csv"
            strSchemaFile = AWSPath & "\schema.ini"

            ''strFolderPath = txtFolderName.Text
            ''strFileName = txtFileName.Text

            ''strDataFile = System.IO.Path.GetFileName(txtDataFile.Text)
            '' strSchemaFile = System.IO.Path.GetFileName(txtSchemaFile.Text)
            '' strFolderPath = System.IO.Path.GetDirectoryName(txtDataFile.Text)

            'strDataFile = strAWSDataFolder & "\aws_data.csv"
            'strSchemaFile = strAWSDataFolder & "\schema.ini"

            'Copy Data file to CLICOM folder and rename the files to [clicom_daily.csv] and [schema.ini] and overwrite existing file
            My.Computer.FileSystem.CopyFile(txtDataFile.Text, strDataFile, True)

            'Copy schema file to CLICOM folder and rename the files to [schema.ini] and [schema.ini] and overwrite existing file
            My.Computer.FileSystem.CopyFile(txtSchemaFile.Text, strSchemaFile, True)

            '   MsgBox("Files copied successfully!")

            ''strFolderPath = System.IO.Path.GetDirectoryName(txtQCReportOriginal.Text)
            'strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strAWSDataFolder & ";Extended Properties=Text;"

            strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AWSPath & ";Extended Properties=Text;"
            Dim conn1 As New OleDb.OleDbConnection
            'rec = -1

            'Try
            conn1.ConnectionString = strConnString
            conn1.Open()

            ds.Clear()
            sql = "SELECT * FROM [" & "aws_data.csv" & "]"

            da = New OleDb.OleDbDataAdapter(sql, conn1)
            da.Fill(ds, "awsData")
            conn1.Close()

            maxDataRows = ds.Tables("awsData").Rows.Count
            'MsgBox("Number of rows: " & maxDataRows)
            Dim conn As New MySql.Data.MySqlClient.MySqlConnection
            Dim connStr As String
            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

            connStr = frmLogin.txtusrpwd.Text

            conn.ConnectionString = connStr
            conn.Open()

            Dim ds1 As New DataSet
            Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter

            Dim ds2 As New DataSet
            Dim da2 As MySql.Data.MySqlClient.MySqlDataAdapter

            Dim ds3 As New DataSet
            Dim da3 As MySql.Data.MySqlClient.MySqlDataAdapter

            Dim stnMaxRows As Integer, awsElemMaxRows As Integer, awsDataMaxCols, k As Integer, _
                stnAwsId As String, awsElemAbbrev As String

            sql = "SELECT elementId,elementScale FROM obselement"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da1.Fill(ds1, "elemScale")

            sql2 = "SELECT * FROM aws_stations"
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql2, conn)
            da2.Fill(ds2, "awsStations")

            stnMaxRows = ds2.Tables("awsStations").Rows.Count

            sql3 = "SELECT * FROM aws_elements"
            da3 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql3, conn)
            da3.Fill(ds3, "awsElements")

            awsElemMaxRows = ds3.Tables("awsElements").Rows.Count
            awsDataMaxCols = ds.Tables("awsData").Columns.Count

            Dim colStn, colDate, colTime, colValStart As Integer

            colStn = Val(txtStationColumn.Text)
            colDate = Val(txtDateColumn.Text)
            colTime = Val(txtTimeColumn.Text)
            colValStart = Val(txtValStartColumn.Text)

            'Open form for displaying data transfer progress
            frmDataTransferProgress.Show()

            'Loop through all rows in the input data file
            For n = 0 To maxDataRows - 1
                'Display progress of data transfer
                frmDataTransferProgress.txtDataTransferProgress1.Text = " Transferring record: " & n + 1 & " of " & maxDataRows
                frmDataTransferProgress.txtDataTransferProgress1.Refresh()

                'Check if first colum is a valid date. If the data file is a merged file there would be field names of 
                'header rows mixed with obs records

                For i = colValStart To awsDataMaxCols - 1
                    awsElemAbbrev = ds.Tables("awsdata").Columns.Item(i).ColumnName

                    If IsDate(ds.Tables("awsData").Rows(n).Item(colDate)) Then
                        '
                        If colTime = -1 Then
                            'colStn = 1
                            'colValStart = 2
                            obsYear = Year(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsMonth = Month(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsDay = DateAndTime.Day(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsHour = Hour(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsMinute = Minute(ds.Tables("awsData").Rows(n).Item(colDate))
                            stnAwsId = ds.Tables("awsData").Rows(n).Item(colStn)

                        Else
                            obsYear = Year(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsMonth = Month(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsDay = DateAndTime.Day(ds.Tables("awsData").Rows(n).Item(colDate))
                            obsHour = Strings.Left(ds.Tables("awsData").Rows(n).Item(colTime), 2)
                            obsMinute = Strings.Mid(ds.Tables("awsData").Rows(n).Item(colTime), 4, 2)
                            stnAwsId = ds.Tables("awsData").Rows(n).Item(colStn)
                            '
                        End If

                        '------------------
                        'This block of code added to make provision for adjusting time in data file to local time or vice versa.
                        'This would be required in cases where the time zone in the AWS data file is different from the time zone
                        'adopted for use in database (2016,ASM)

                        Dim obsYYY As Integer, obsMM As Integer, obsDD As Integer, obsHH As Integer, obsMin As Integer
                        obsYYY = Val(obsYear)
                        obsMM = Val(obsMonth)
                        obsDD = Val(obsDay)
                        obsHH = Val(obsHour)
                        obsMin = Val(obsMinute)

                        InputDataDateTime = New DateTime(obsYYY, obsMM, obsDD, obsHH, obsMin, 0)
                        hourAdjustment = Val(txtHourAdjustment.Text)
                        dbStorageDateTime = InputDataDateTime.AddHours(hourAdjustment)

                        obsYear = Year(dbStorageDateTime)
                        obsMonth = Month(dbStorageDateTime)
                        obsDay = DateAndTime.Day(dbStorageDateTime)
                        obsHour = Hour(dbStorageDateTime)
                        obsMinute = Minute(dbStorageDateTime)
                        '------------------
                        '
                        If Val(obsMonth) < 10 Then obsMonth = "0" & obsMonth
                        If Val(obsDay) < 10 Then obsDay = "0" & obsDay
                        If Val(obsHour) < 10 Then obsHour = "0" & obsHour
                        If Val(obsMinute) < 10 Then obsMinute = "0" & obsMinute

                        obsDate = obsYear & "-" & obsMonth & "-" & obsDay & " " & obsHour & ":" & obsMinute & ":00"

                        If colStn = -1 Then
                            stnAwsId = System.IO.Path.GetFileNameWithoutExtension(txtDataFile.Text)
                        End If


                        'Loop through the aws_stations table to get the stationId
                        For j = 0 To stnMaxRows - 1
                            If stnAwsId = ds2.Tables("awsStations").Rows(j).Item(0) Then
                                stnId = ds2.Tables("awsStations").Rows(j).Item(1)
                            End If
                        Next j

                        elemFound = False
                        'Loop through the aws_elements table to get the element code
                        For k = 0 To awsElemMaxRows - 1
                            If awsElemAbbrev = ds3.Tables("awsElements").Rows(k).Item(0) Then
                                elemFound = True
                                elemCode = ds3.Tables("awsElements").Rows(k).Item(1)
                                If Not IsDBNull(ds.Tables("awsData").Rows(n).Item(i)) Then
                                    obsVal = ds.Tables("awsData").Rows(n).Item(i)
                                End If
                            End If
                        Next k
                        obsLevel = "surface"

                        qcStatus = 1
                        acquisitionType = 3

                        If elemFound = True And IsNumeric(obsVal) Then

                            'Generate SQL string for inserting data into observationinitial table
                            sql = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                                qcStatus & "," & acquisitionType & ")"

                            ' Create the Command for executing query and set its properties
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            Try
                                'Execute query
                                objCmd.ExecuteNonQuery()
                                ' Catch ex As MySql.Data.MySqlClient.MySqlException
                                'Ignore expected error i.e. error of Duplicates in MySqlException
                            Catch ex As Exception
                                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                MsgBox(ex.Message)
                            End Try
                        End If
                        'Move to next record in dataset
                    End If
                Next i
            Next n
            
            conn.Close()
            frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
            frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

            'MsgBox("Data successfully uploaded !", MsgBoxStyle.Information)
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmImportAWS_Load(sender As Object, e As EventArgs) Handles Me.Load
        strAWSDataFolder = dsReg.Tables("regData").Rows(10).Item("keyValue")

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        importAWS()
    End Sub

    Private Sub btnBrowseDataFile_Click(sender As Object, e As EventArgs) Handles btnBrowseDataFile.Click
        '
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C\*.*"
        'fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "CSV files (*.csv)|*.csv|CSV files (*.csv)|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtDataFile.Text = fd.FileName
            strDataFile = txtDataFile.Text
        End If
        'Load_aws()

    End Sub

    'Sub Load_aws()
    '    Dim lin As Integer
    '    Dim currentRow As String()
    '    Dim currentField As String
    '    Dim row As String()
    '    Dim delimit As String
    '    'Set cursor to busy mood
    '    Me.Cursor = Cursors.WaitCursor

    '    Try
    '        ''Assign delimiter for the text file
    '        '' Comma delimited
    '        'If optComma.Checked Then
    '        '    delimit = ","
    '        '    'Tab delimited
    '        'ElseIf OptTAB.Checked Then
    '        '    ' Characters delimited
    '        '    delimit = vbTab
    '        'ElseIf OptOthers.Checked Then
    '        '    delimit = txtOther.Text
    '        'End If
    '        'DataGridView1.Columns.Clear()
    '        delimit = txtDelimiter.Text

    '        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtDataFile.Text)
    '            MyReader.TextFieldType = FileIO.FieldType.Delimited
    '            MyReader.SetDelimiters(delimit)

    '            Dim num As Integer

    '            lin = MyReader.LineNumber()

    '            currentRow = MyReader.ReadFields()

    '            If lin = 1 Then ' The header row
    '                ' Compute the total columns
    '                num = 0
    '                For Each currentField In currentRow
    '                    'MsgBox(currentField)
    '                    num = num + 1
    '                Next

    '                '    DataGridView1.ColumnCount = num

    '                '    'Number the column headers starting with digit 1
    '                '    num = 0
    '                '    lstColumn.Items.Clear()
    '                '    For Each currentField In currentRow
    '                '        DataGridView1.Columns(num).Name = num + 1
    '                '        num = num + 1
    '                '        lstColumn.Items.Add(num)
    '                '    Next
    '                '    DataGridView1.Refresh()
    '            End If

    '            'DataGridView1.Rows.Add(currentRow)
    '            Do While MyReader.EndOfData = False

    '                'DataGridView1.Rows.Add(currentRow)
    '            Loop
    '            'DataGridView1.Refresh()
    '        End Using

    '        ''Populate the datagridview with data from the file
    '        'For Each THisLine In My.Computer.FileSystem.ReadAllText(txtImportFile.Text).Split(Environment.NewLine)
    '        '    DataGridView1.Rows.Add(THisLine.Split(delimit))
    '        'Next
    '        'DataGridView1.Refresh()
    '    Catch ex As Exception
    '        MsgBox(ex.HResult & " " & Err.Description)
    '        Me.Cursor = Cursors.Default
    '    End Try
    '    'If DataGridView1.RowCount > 0 Then
    '    '    cmdLoadData.Enabled = True
    '    '    pnlHeaders.Enabled = True
    '    'Else
    '    '    cmdLoadData.Enabled = False
    '    '    pnlHeaders.Enabled = False
    '    'End If
    '    Me.Cursor = Cursors.Default

    'End Sub

    Private Sub btnBrowseSchemaFile_Click(sender As Object, e As EventArgs) Handles btnBrowseSchemaFile.Click
        '
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\*.*"
        'fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "Schema files (*.ini)|*.ini|Schema files (*.ini)|*.ini"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtSchemaFile.Text = fd.FileName
            strSchemaFile = txtSchemaFile.Text
        End If
    End Sub

    Private Sub txtSchemaFile_TextChanged(sender As Object, e As EventArgs) Handles txtSchemaFile.TextChanged
        If Strings.Right(txtSchemaFile.Text, 4) = ".ini" And Strings.Right(txtDataFile.Text, 4) = ".csv" Then
            btnOK.Enabled = True
            btnSetSchedule.Enabled = True
        End If
    End Sub

    Private Sub btnSetSchedule_Click(sender As Object, e As EventArgs) Handles btnSetSchedule.Click
        btnOK.Enabled = False
        btnSetSchedule.Text = "Timer Activated"
        btnSetSchedule.Enabled = False
        btnSetSchedule.Refresh()
        
        'Enable timer
        Timer1.Enabled = True
        lblTimerActivationStatus.Text = "Timer activated!"
        ''txtTimerStartHour.Text = Hour(Now())
        ''txtTimerStartHour.Refresh()
        ''txtTimerStartMinute.Text = Minute(Now())
        ''txtTimerStartMinute.Refresh()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hourNow As Integer, minuteNow As Integer, secondNow As Integer
        
        hourNow = Hour(Now)
        minuteNow = Minute(Now)
        secondNow = Second(Now())

        ''txtTimerStartHour.Text = hourNow
        ''txtTimerStartHour.Refresh()

        'Start processing a minute from the time the schedule is set i.e. a minute after the "schedule" button is clicked.
        'At that time the value of the variable "minute_now" will be a minute after the schedule is set.
        'The value of the minute in the "minute texbox remains the same. It will be after an hour when the value of the variable
        '"minute_now" will be equal to the value in the "minute" texbox plus 1. So the processing is repeated every hour

        'If minuteNow = Val(txtTimerStartMinute.Text) + 1 Then
        If minuteNow = Val(txtTimerStartMinute.Text) And secondNow = 0 Then
            frmDataTransferProgress.lblDataTransferProgress.Text = "Data ingestion in progress!"
            frmDataTransferProgress.lblDataTransferProgress.Refresh()
            ' Show caption indicating start of processing
            lblTimerActivationStatus.Text = "Processing.....please wait.....!!"
            lblTimerActivationStatus.Refresh()

            'call subroutine for compiling and ingesting AWS data
            'compile_aws_data
            importAWS()

            ' Update caption indicating start of processing
            lblTimerActivationStatus.Text = "Last data ingestion: " & Now
            lblTimerActivationStatus.Refresh()
        End If

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#from_AWS")
    End Sub
End Class