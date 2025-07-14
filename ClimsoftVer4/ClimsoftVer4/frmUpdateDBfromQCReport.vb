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

Public Class frmUpdateDBfromQCReport
    Dim msgTxtUpdatedQCReportFileName As String
    Dim msgTxtQCReportsMismatch, stnId1, stnId2 As String
    Dim strFolderPath As String, strFileName1 As String, strFileName2 As String, rec As Integer
    Dim sql As String, sql1 As String, strConnString As String
    Dim ds As New DataSet(), ds1 As New DataSet()
    Dim da As OleDb.OleDbDataAdapter, da1 As OleDb.OleDbDataAdapter
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim elemId1 As Integer, yyyy1 As String, mm1 As String, dd1 As String, hh1 As String, obsVal1 As String, qcStatus1 As String

    Private Sub frmUpdateDBfromQCReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'translate form controls
        ClsTranslations.TranslateForm(Me)
    End Sub

    Dim elemId2 As Integer, yyyy2 As String, mm2 As String, dd2 As String, hh2 As String, obsVal2 As String, qcStatus2 As String
    Dim m As Integer, n As Integer, obsValue As String, qcStatus As Integer
    Dim strSQL As String, stnId As String, elemCode As String, obsDatetime As String, obsLevel As String, obsVal As String, obsFlag As String, _
        acquisitionType As String, capturedBy As String, dataForm As String
    Dim msgTxtInterelementChangesUpdated As String
    Dim msgTxtLimitsChecksChangesUpdated As String

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim objCmd As MySqlConnector.MySqlCommand
        Dim conn As New MySqlConnector.MySqlConnection

        strFileName1 = System.IO.Path.GetFileName(txtQCReportOriginal.Text)
        strFileName2 = System.IO.Path.GetFileName(txtQCReportUpdated.Text)
        strFolderPath = System.IO.Path.GetDirectoryName(txtQCReportOriginal.Text)
        strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderPath & ";Extended Properties=Text;"
        Dim conn1 As New OleDb.OleDbConnection

        ' Set busy Cursor pointer
        lblProcessStatus.Text = "Uploading ...........   Please wait"
        lblProcessStatus.Refresh()

        Me.Cursor = Cursors.WaitCursor

        Try
            conn1.ConnectionString = strConnString
            conn1.Open()

            sql = "SELECT * FROM [" & strFileName1 & "]"

            da = New OleDb.OleDbDataAdapter(sql, conn1)
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "QCReportOriginal")

            sql1 = "SELECT * FROM [" & strFileName2 & "]"

            da1 = New OleDb.OleDbDataAdapter(sql1, conn1)
            da1.Fill(ds1, "QCReportUpdated")

            'MsgBox("Datasets filled!")
            conn1.Close()
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message & " at btnOK")
            Me.Cursor = Cursors.Default
            lblProcessStatus.Text = "Stopped"
        End Try

        'Try
        strConnString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = strConnString
        conn.Open()
        'Catch ex As Exception
        'Dispaly error message if it is different from the one trapped in 'Catch' execption above
        'MsgBox(ex.Message)
        ' End Try

        msgTxtQCReportsMismatch = "Mismatch between original and updated QC reports file names"
        msgTxtUpdatedQCReportFileName = "File name for updated QC report must end with [_updated.csv]"

        If Strings.Right(txtQCReportUpdated.Text, 12) <> "_updated.csv" Then
            MsgBox(msgTxtUpdatedQCReportFileName, MsgBoxStyle.Exclamation)
            Me.Cursor = Cursors.Default
            lblProcessStatus.Text = "Wrong file name...uploading aborted"
            Exit Sub
        End If
        If Strings.Left(txtQCReportOriginal.Text, Len(txtQCReportOriginal.Text) - 4) <>
            Strings.Left(txtQCReportUpdated.Text, Len(txtQCReportUpdated.Text) - 12) Then
            MsgBox(msgTxtQCReportsMismatch, MsgBoxStyle.Exclamation)
            lblProcessStatus.Text = "Wrong file name...uploading aborted"
            Exit Sub
        End If

        m = ds.Tables("QCReportOriginal").Rows.Count - 1
        n = ds1.Tables("QCReportUpdated").Rows.Count - 1
        Dim i As Integer, j As Integer

        'if interelement report
        If Strings.Left(strFileName1, 15) = "qc_interelement" Then
            '-----------------------
            'Check for changes on first element
            'Loop through all records in dataset [QCReportOriginal]
            Try
                For i = 0 To m
                    stnId1 = ds.Tables("QCReportOriginal").Rows(i).Item("StationId")
                    elemId1 = ds.Tables("QCReportOriginal").Rows(i).Item("elementId_1")
                    yyyy1 = ds.Tables("QCReportOriginal").Rows(i).Item("yyyy")
                    mm1 = ds.Tables("QCReportOriginal").Rows(i).Item("mm")
                    dd1 = ds.Tables("QCReportOriginal").Rows(i).Item("dd")
                    hh1 = ds.Tables("QCReportOriginal").Rows(i).Item("hh_1")

                    'obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_1")
                    'MsgBox(obsVal1)
                    If Not IsDBNull(ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_1")) Then
                        obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_1")
                    Else
                        obsVal1 = ""
                    End If

                    'Loop through all records on dataset [QCReportUpdated]
                    For j = 0 To n
                        stnId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("StationId")
                        elemId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("elementId_1")
                        yyyy2 = ds1.Tables("QCReportUpdated").Rows(j).Item("yyyy")
                        mm2 = ds1.Tables("QCReportUpdated").Rows(j).Item("mm")
                        dd2 = ds1.Tables("QCReportUpdated").Rows(j).Item("dd")
                        hh2 = ds1.Tables("QCReportUpdated").Rows(j).Item("hh_1")

                        'obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_1")

                        If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_1")) Then
                            obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_1")
                        Else
                            obsVal2 = ""
                            obsFlag = "M"
                        End If

                        qcStatus2 = ds1.Tables("QCReportUpdated").Rows(j).Item("qcStatus_2")
                        If stnId1 = stnId2 And elemId1 = elemId2 And yyyy1 = yyyy2 And mm1 = mm2 And dd1 = dd2 And hh1 = hh2 Then

                            If obsVal1 <> obsVal2 Then

                                stnId = stnId2
                                elemCode = elemId2
                                If Strings.Len(mm2) = 1 Then mm2 = "0" & mm2
                                If Strings.Len(dd2) = 1 Then dd2 = "0" & dd2
                                If Strings.Len(hh2) = 1 Then hh2 = "0" & hh2
                                obsDatetime = yyyy2 & "-" & mm2 & "-" & dd2 & " " & hh2 & ":00:00"
                                obsLevel = ds1.Tables("QCReportUpdated").Rows(j).Item("obsLevel_2")
                                'Get "obsVal2" as updated value for appending to obsvertionInitial table
                                obsVal = obsVal2

                                'obsFlag = ""
                                'Increment "qcStatus2" by 1

                                qcStatus = qcStatus2 + 1

                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType_2")) Then acquisitionType = ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType_2")
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(i).Item("capturedBy_2")) Then capturedBy = ds1.Tables("QCReportUpdated").Rows(i).Item("capturedBy_2")
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(i).Item("capturedBy_2")) Then dataForm = ds1.Tables("QCReportUpdated").Rows(i).Item("dataForm_2")
                                'Generate new SQL string for appending modified record to observationInitial table
                                strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                               "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                               & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                                ' Create the Command for executing query and set its properties
                                objCmd = New MySqlConnector.MySqlCommand(strSQL, conn)

                                Try
                                    'Execute query
                                    objCmd.ExecuteNonQuery()
                                    'Catch ex As MySqlConnector.MySqlException
                                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                                    Me.Cursor = Cursors.Default
                                    lblProcessStatus.Text = "Stopped"
                                Catch ex As Exception
                                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                    MsgBox(ex.Message)
                                    Me.Cursor = Cursors.Default
                                End Try
                            End If

                        End If
                    Next j
                Next i
                'End of checks for changes intelement 1 for interelement checks
                '-------------------------
                'Check for changes in element2 for interelement checks
                'Loop through all records in dataset [QCReportOriginal]
                For i = 0 To m
                    stnId1 = ds.Tables("QCReportOriginal").Rows(i).Item("StationId")
                    elemId1 = ds.Tables("QCReportOriginal").Rows(i).Item("elementId_2")
                    yyyy1 = ds.Tables("QCReportOriginal").Rows(i).Item("yyyy")
                    mm1 = ds.Tables("QCReportOriginal").Rows(i).Item("mm")
                    dd1 = ds.Tables("QCReportOriginal").Rows(i).Item("dd")
                    hh1 = ds.Tables("QCReportOriginal").Rows(i).Item("hh_2")

                    'obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_2")

                    If Not IsDBNull(ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_2")) Then
                        obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue_2")
                    Else
                        obsVal1 = ""
                    End If

                    'Loop through all records on dataset [QCReportUpdated]
                    For j = 0 To n
                        stnId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("StationId")
                        elemId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("elementId_2")
                        yyyy2 = ds1.Tables("QCReportUpdated").Rows(j).Item("yyyy")
                        mm2 = ds1.Tables("QCReportUpdated").Rows(j).Item("mm")
                        dd2 = ds1.Tables("QCReportUpdated").Rows(j).Item("dd")
                        hh2 = ds1.Tables("QCReportUpdated").Rows(j).Item("hh_2")
                        qcStatus2 = ds1.Tables("QCReportUpdated").Rows(j).Item("qcStatus_2")

                        'obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_2")
                        ' Set NULL values to missing data
                        If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_2")) Then
                            obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue_2")
                            obsFlag = ""
                        Else
                            obsVal2 = ""
                            obsFlag = "M"
                        End If

                        If stnId1 = stnId2 And elemId1 = elemId2 And yyyy1 = yyyy2 And mm1 = mm2 And dd1 = dd2 And hh1 = hh2 Then
                            If obsVal1 <> obsVal2 Then
                                stnId = stnId2
                                elemCode = elemId2
                                If Strings.Len(mm2) = 1 Then mm2 = "0" & mm2
                                If Strings.Len(dd2) = 1 Then dd2 = "0" & dd2
                                If Strings.Len(hh2) = 1 Then hh2 = "0" & hh2
                                obsDatetime = yyyy2 & "-" & mm2 & "-" & dd2 & " " & hh2 & ":00:00"

                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("obsLevel_2")) Then obsLevel = ds1.Tables("QCReportUpdated").Rows(j).Item("obsLevel_2")

                                'Get "obsVal2" as updated value for appending to obsvertionInitial table
                                obsVal = obsVal2
                                'obsFlag = ""

                                'Increment "qcStatus" by 1
                                qcStatus = qcStatus2 + 1
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType_2")) Then acquisitionType = ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType_2")
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(i).Item("capturedBy_2")) Then capturedBy = ds1.Tables("QCReportUpdated").Rows(i).Item("capturedBy_2")
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(i).Item("dataForm_2")) Then dataForm = ds1.Tables("QCReportUpdated").Rows(i).Item("dataForm_2")
                                'Generate new SQL string for appending modified record to observationInitial table
                                strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                               "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                               & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                                ' Create the Command for executing query and set its properties
                                objCmd = New MySqlConnector.MySqlCommand(strSQL, conn)

                                Try
                                    'Execute query
                                    objCmd.CommandTimeout = 0
                                    objCmd.ExecuteNonQuery()
                                    'Catch ex As MySqlConnector.MySqlException
                                    'Ignore expected error i.e. error of Duplicates in MySqlException

                                Catch ex As Exception
                                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                    MsgBox(ex.Message)
                                    Me.Cursor = Cursors.Default
                                    lblProcessStatus.Text = "Stopped"
                                End Try
                            End If
                        End If
                    Next j
                Next i
                'End of checks for changes on element 2 for interelement checks
                'msgTxtInterelementChangesUpdated = "Changed records for interelement checks have been updated successfully!"
                'MsgBox(msgTxtInterelementChangesUpdated, MsgBoxStyle.Information)
                lblProcessStatus.Text = "Changed records for interelement checks have been updated successfully!"
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
                lblProcessStatus.Text = "Stopped"
            End Try
            'Check for changes in values for limits checks
        ElseIf Strings.Left(strFileName1, 20) = "qc_report_lowerlimit" Or Strings.Left(strFileName1, 20) = "qc_report_upperlimit" Or Strings.Left(strFileName1, 22) = "qc_report_diurnalRange" Or Strings.Left(strFileName1, 25) = "qc_report_consecutivedays" Or Strings.Left(strFileName1, 26) = "qc_report_consecutivehours" Then

            'Loop through all records in dataset [QCReportOriginal]
            Try
                For i = 0 To m
                    If Not IsDBNull(ds.Tables("QCReportOriginal").Rows(i).Item("StationId")) Then
                        stnId1 = ds.Tables("QCReportOriginal").Rows(i).Item("StationId")
                    Else
                        Continue For
                    End If

                    elemId1 = ds.Tables("QCReportOriginal").Rows(i).Item("elementId")
                    yyyy1 = ds.Tables("QCReportOriginal").Rows(i).Item("yyyy")
                    mm1 = ds.Tables("QCReportOriginal").Rows(i).Item("mm")
                    dd1 = ds.Tables("QCReportOriginal").Rows(i).Item("dd")
                    hh1 = ds.Tables("QCReportOriginal").Rows(i).Item("hh")

                    If Not IsDBNull(ds.Tables("QCReportOriginal").Rows(i).Item("obsValue")) Then
                        obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue")
                    Else
                        obsVal1 = ""
                    End If
                    'obsVal1 = ds.Tables("QCReportOriginal").Rows(i).Item("obsValue")

                    'Loop through all records on dataset [QCReportUpdated]
                    For j = 0 To n
                        stnId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("StationId")
                        elemId2 = ds1.Tables("QCReportUpdated").Rows(j).Item("elementId")
                        yyyy2 = ds1.Tables("QCReportUpdated").Rows(j).Item("yyyy")
                        mm2 = ds1.Tables("QCReportUpdated").Rows(j).Item("mm")
                        dd2 = ds1.Tables("QCReportUpdated").Rows(j).Item("dd")
                        hh2 = ds1.Tables("QCReportUpdated").Rows(j).Item("hh")

                        'obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue")
                        ' Set NULL values to missing data
                        If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue")) Then
                            obsVal2 = ds1.Tables("QCReportUpdated").Rows(j).Item("obsValue")
                            obsFlag = ""
                        Else
                            obsVal2 = ""
                            obsFlag = "M"
                        End If
                        'qcStatus2 = ds1.Tables("QCReportUpdated").Rows(j).Item("qcStatus_2")

                        If stnId1 = stnId2 And elemId1 = elemId2 And yyyy1 = yyyy2 And mm1 = mm2 And dd1 = dd2 And hh1 = hh2 Then
                            If obsVal1 <> obsVal2 Then
                                stnId = stnId2
                                elemCode = elemId2
                                If Strings.Len(mm2) = 1 Then mm2 = "0" & mm2
                                If Strings.Len(dd2) = 1 Then dd2 = "0" & dd2
                                If Strings.Len(hh2) = 1 Then hh2 = "0" & hh2
                                obsDatetime = yyyy2 & "-" & mm2 & "-" & dd2 & " " & hh2 & ":00:00"
                                obsLevel = ds1.Tables("QCReportUpdated").Rows(j).Item("obsLevel")
                                'Get "obsVal2" as updated value for appending to obsvertionInitial table
                                obsVal = obsVal2
                                'obsFlag = ""
                                'Increment "qcStatus" by 1
                                qcStatus = 2

                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType")) Then acquisitionType = ds1.Tables("QCReportUpdated").Rows(j).Item("acquisitionType")

                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("capturedBy")) Then capturedBy = ds1.Tables("QCReportUpdated").Rows(j).Item("capturedBy")
                                If Not IsDBNull(ds1.Tables("QCReportUpdated").Rows(j).Item("dataForm")) Then dataForm = ds1.Tables("QCReportUpdated").Rows(j).Item("dataForm")

                                'Generate new SQL string for appending modified record to observationInitial table
                                strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                               "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                               & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                                ' Create the Command for executing query and set its properties
                                objCmd = New MySqlConnector.MySqlCommand(strSQL, conn)
                                objCmd.CommandTimeout = 0
                                Try
                                    'Execute query
                                    objCmd.ExecuteNonQuery()
                                    'Catch ex As MySqlConnector.MySqlException
                                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                                Catch ex As Exception
                                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                    MsgBox(ex.Message)
                                    Me.Cursor = Cursors.Default
                                    lblProcessStatus.Text = "Stopped"
                                End Try
                            End If
                        End If
                    Next j
                Next i
                'msgTxtLimitsChecksChangesUpdated = "Changed records for limits checks have been updated successfully!"
                'MsgBox(msgTxtLimitsChecksChangesUpdated, MsgBoxStyle.Information)
                lblProcessStatus.Text = "Changed records for limits checks have been updated successfully!"
            Catch ex As Exception
                MsgBox(ex.Message & " at btnOK1")
                Me.Cursor = Cursors.Default
                lblProcessStatus.Text = "Stopped"
                conn.Close()
            End Try
        Else
            MsgBox(Strings.Left(strFileName1, 15))
        End If
        conn.Close()
        ' Set busy Cursor pointer
        Me.Cursor = Cursors.Default

    End Sub


    Private Sub btnBrowseQCOriginal_Click(sender As Object, e As EventArgs) Handles btnBrowseQCOriginal.Click
        '
        fd.Title = "Open File Dialog"
        'fd.InitialDirectory = "D:\data\QCReports"
        fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "CSV files (*.csv)|*.csv|CSV files (*.csv)|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtQCReportOriginal.Text = fd.FileName
        End If
    End Sub

    Private Sub btnQCUpdated_Click(sender As Object, e As EventArgs) Handles btnQCUpdated.Click
        '
        fd.Title = "Open File Dialog"
        'fd.InitialDirectory = "D:\data\QCReports"
        fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "CSV files (*.csv)|*.csv|CSV files (*.csv)|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtQCReportUpdated.Text = fd.FileName
        End If
    End Sub

    Private Sub txtQCReportUpdated_TextChanged(sender As Object, e As EventArgs) Handles txtQCReportUpdated.TextChanged
        If Strings.Len(txtQCReportUpdated.Text) > 0 And Strings.Len(txtQCReportOriginal.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "qcchecks.htm#update_qcreport")
    End Sub
End Class