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

    Private Sub frmImportAWS_Load(sender As Object, e As EventArgs) Handles Me.Load
        strAWSDataFolder = dsReg.Tables("regData").Rows(10).Item("keyValue")
        ''Dim strConnString As String
        ''strFolderPath = txtFolderName.Text
        ''strFileName = txtFileName.Text
        ''strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderPath & ";Extended Properties=Text;"
        ''Dim conn1 As New OleDb.OleDbConnection
        ''rec = -1

        ' ''Try
        ''conn1.ConnectionString = strConnString
        ''conn1.Open()

        ''sql = "SELECT * FROM [" & strFileName & "]"

        ''da = New OleDb.OleDbDataAdapter(sql, conn1)
        ''da.Fill(ds, "clicomDaily")
        ''conn1.Close()
        ''MsgBox("CSV data imported into dataset !", MsgBoxStyle.Information)

        ' Catch ex As OleDb.OleDbException
        'MessageBox.Show(ex.Message)
        ' End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim strConnString As String
        Dim maxDataRows As Integer, stnId As String, elemCode As String, obsYear As String, obsMonth As String, obsDate As String, obsDay As String, obsHour As String, _
            obsLevel As String, obsVal As String, obsFlag As String, qcStatus As Integer, acquisitionType As Integer, n As Integer, _
            j As Integer, i As Integer, obsMinute As String, elemFound As Boolean

        stnId = ""
        elemCode = 0
        obsVal = ""
        obsFlag = ""

        'strFolderPath = txtFolderName.Text
        'strFileName = txtFileName.Text

        'strDataFile = System.IO.Path.GetFileName(txtDataFile.Text)
        ' strSchemaFile = System.IO.Path.GetFileName(txtSchemaFile.Text)
        ' strFolderPath = System.IO.Path.GetDirectoryName(txtDataFile.Text)

        strDataFile = strAWSDataFolder & "\aws_data.csv"
        strSchemaFile = strAWSDataFolder & "\schema.ini"

        'Copy Data file to CLICOM folder and rename the files to [clicom_daily.csv] and [schema.ini] and overwrite existing file
        My.Computer.FileSystem.CopyFile(txtDataFile.Text, strDataFile, True)

        'Copy schema file to CLICOM folder and rename the files to [schema.ini] and [schema.ini] and overwrite existing file
        My.Computer.FileSystem.CopyFile(txtSchemaFile.Text, strSchemaFile, True)

        '   MsgBox("Files copied successfully!")

        'strFolderPath = System.IO.Path.GetDirectoryName(txtQCReportOriginal.Text)
        strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strAWSDataFolder & ";Extended Properties=Text;"
        Dim conn1 As New OleDb.OleDbConnection
        'rec = -1

        'Try
        conn1.ConnectionString = strConnString
        conn1.Open()

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

        'elemMaxRows = ds1.Tables("elemScale").Rows.Count

        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'First get the AWS element abbreviation

        'MsgBox("Number of data columns=" & awsDataMaxCols)

        ''For i = 2 To awsDataMaxCols - 1
        ''    awsElemAbbrev = ds.Tables("awsdata").Columns.Item(i).ColumnName

        ' MsgBox(awsElemAbbrev)

        'Loop through all rows in the input data file
        For n = 0 To maxDataRows - 1
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress.Text = " Transferring record: " & n + 1 & " of " & maxDataRows
            frmDataTransferProgress.txtDataTransferProgress.Refresh()

            'Check if first colum is a valid date. If the data file is a merged file there would be fields names of 
            'header rows mixed with obs records

            For i = 2 To awsDataMaxCols - 1
                awsElemAbbrev = ds.Tables("awsdata").Columns.Item(i).ColumnName

                If IsDate(ds.Tables("awsData").Rows(n).Item(0)) Then
                    obsYear = Year(ds.Tables("awsData").Rows(n).Item(0))
                    obsMonth = Month(ds.Tables("awsData").Rows(n).Item(0))
                    obsDay = DateAndTime.Day(ds.Tables("awsData").Rows(n).Item(0))
                    obsHour = Hour(ds.Tables("awsData").Rows(n).Item(0))
                    obsMinute = Minute(ds.Tables("awsData").Rows(n).Item(0))
                    stnAwsId = ds.Tables("awsData").Rows(n).Item(1)

                    If Val(obsMonth) < 10 Then obsMonth = "0" & obsMonth
                    If Val(obsDay) < 10 Then obsDay = "0" & obsDay
                    If Val(obsHour) < 10 Then obsHour = "0" & obsHour
                    If Val(obsMinute) < 10 Then obsMinute = "0" & obsMinute

                    obsDate = obsYear & "-" & obsMonth & "-" & obsDay & " " & obsHour & ":" & obsMinute & ":00"



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
        '' Next i

        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
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
    End Sub

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
        End If
    End Sub
End Class