﻿Imports System.ComponentModel

Public Class frmFormUpload
    Dim sql As String, conns As New MySqlConnector.MySqlConnection
    Dim daa As New MySqlConnector.MySqlDataAdapter
    Dim dss As New DataSet
    Dim frm_tbl As String
    Dim rgKey As New dataEntryGlobalRoutines

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        'MsgBox("Data successfully uploaded !", MsgBoxStyle.Information)

    End Sub

    Private Sub frmDataTransferProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        'MsgBox(frmDataTransferProgress.Text)

        ' Close the form if the User has no previleges to Upload data
        If userGroup <> "ClimsoftAdmin" And userGroup <> "ClimsoftQC" And userGroup <> "ClimsoftOperatorSupervisor" And userGroup <> "ClimsoftDeveloper" And userGroup <> "" Then
            Me.Close()
            Exit Sub
        End If

        frmUploadgroundWorker.WorkerReportsProgress = True
        frmUploadgroundWorker.WorkerSupportsCancellation = True

        lblDataTransferProgress.Refresh()
        'Initialize Stations List Views
        LstViewStations.Columns.Clear()
        LstViewStations.Columns.Add("Station Id", 100, HorizontalAlignment.Left)
        LstViewStations.Columns.Add("Station Name", 200, HorizontalAlignment.Left)


        Try
            conns.ConnectionString = frmLogin.txtusrpwd.Text ' & ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
            conns.Open()

            sql = "select " & lblFormName1.Text & ".stationId, stationName from " & lblFormName1.Text & " inner join station on " & lblFormName1.Text & ".stationId=station.stationId group by " & lblFormName1.Text & ".stationId;"
            'MsgBox(sql)
            daa = New MySqlConnector.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0
            daa.Fill(dss, "station")
            conns.Close()

            Dim stn(2) As String
            Dim itms = New ListViewItem
            'LstViewStations.Items.Clear()

            For i = 0 To dss.Tables("station").Rows.Count - 1
                stn(0) = dss.Tables("station").Rows(i).Item("stationId") '"0123456789"

                If Not IsDBNull(dss.Tables("station").Rows(i).Item("stationName")) Then
                    stn(1) = dss.Tables("station").Rows(i).Item("stationName")
                Else
                    stn(1) = ""
                End If

                itms = New ListViewItem(stn)
                LstViewStations.Items.Add(itms)
            Next

        Catch x As Exception
            conns.Close()
            MsgBox(x.Message)
        End Try

        ClsTranslations.TranslateForm(Me)


    End Sub

    Private Sub chkAllStations_Click(sender As Object, e As EventArgs) Handles chkAllStations.Click
        If chkAllStations.Checked = False Then
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = False
            Next
            chkAllStations.Text = "Select All Stations"
            'LstViewStations.Enabled = True
        Else
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = True
            Next
            chkAllStations.Text = "Unselect All Stations"
            'LstViewStations.Enabled = False
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Dim m, n, maxRows, st, ed, flds, elemCode, acquisitionType, qcStatus, obsperiod As Integer
        Dim strSQL, stnlist, code_loc, yyyy, mm, dd, hh, capturedBy, stnId, obsDatetime, obsVal, obsFlag, obsLevel, dataForm, bdate, edate As String
        Dim stnselected As Boolean

        Try
            ' Check stations selections
            stnselected = False
            For i = 0 To LstViewStations.Items.Count - 1
                If LstViewStations.Items(i).Checked Then
                    stnselected = True
                    Exit For
                End If
            Next
            If Not stnselected Then
                MsgBox("No Station selected")
                Exit Sub
            End If

            ' Check period selections
            If Not chkEntrydate.Checked Then
                bdate = Val(txtBeginYear.Text) & "-" & Val(txtBeginMonth.Text) & "-1 00:00:00"
                edate = Val(txtEndYear.Text) & "-" & Val(txtEndMonth.Text) & "-1 00:00:00"

                If Not IsDate(bdate) Or Not IsDate(edate) Then
                    MsgBox("Period not properly selected")
                    Exit Sub
                End If
            End If

            frm_tbl = lblFormName1.Text
            lblDataTransferProgress.ForeColor = DefaultForeColor 'Color.Black
            lblDataTransferProgress.Text = ""
            txtDataTransferProgress1.Text = ""

            If chkEntrydate.Checked Then
                bdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & DateAndTime.Day(dateFrom.Text) & " 00:00:00"
                edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & DateAndTime.Day(dateTo.Text) & " 23:59:59"
            End If

            ' List the selected stations
            stnlist = ""
            stnselected = False
            If chkAllStations.Checked = False Then ' When NOT all stations are selected
                For i = 0 To LstViewStations.Items.Count - 1
                    If LstViewStations.Items(i).Checked = True Then
                        stnId = LstViewStations.Items(i).SubItems(0).Text
                        stnselected = True
                        If Len(stnlist) = 0 Then
                            stnlist = "stationId = " & " '" & stnId & "'" 'stnid
                        Else
                            stnlist = stnlist & " OR stationId = " & "'" & stnId & "'"
                        End If
                        'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                    End If
                Next
                If frm_tbl = "form_monthly" Then
                    sql = "select * from " & frm_tbl & " where (" & stnlist & ") and (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "')"
                Else
                    sql = "select * from " & frm_tbl & " where (" & stnlist & ") and (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "') and (mm between '" & txtBeginMonth.Text & "' and '" & txtEndMonth.Text & "');"
                End If

                If chkEntrydate.Checked Then sql = "select * from " & frm_tbl & " where (" & stnlist & ") and entrydatetime between '" & bdate & "' and '" & edate & "';"

            Else ' When All stations are selected
                stnselected = True
                If frm_tbl = "form_monthly" Then
                    sql = "select * from " & frm_tbl & " where (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "');"
                Else
                    sql = "select * from " & frm_tbl & " where (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "') and (mm between '" & txtBeginMonth.Text & "' and '" & txtEndMonth.Text & "');"
                End If

                If chkEntrydate.Checked Then sql = "select * from " & frm_tbl & " where entrydatetime between '" & bdate & "' and '" & edate & "';"

            End If

            'MsgBox(sql)

            'Create a path to save data into bufer to be uploaded later
            Dim fl, dataDir, frmrec As String

            ' Create folder 'Climsoft4\data' if it does not exist
            dataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"

            If Not IO.Directory.Exists(dataDir) Then
                IO.Directory.CreateDirectory(dataDir)
            End If

            fl = dataDir & "\form_2_initial_sql.csv"
            FileOpen(122, fl, OpenMode.Output)

            ' Convert path separater to SQL format
            fl = Strings.Replace(fl, "\", "/")

            conns.ConnectionString = frmLogin.txtusrpwd.Text ' & ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
            conns.Open()

            daa = New MySqlConnector.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0
            dss.Clear()
            daa.Fill(dss, frm_tbl)
            'conns.Close()
            maxRows = dss.Tables(frm_tbl).Rows.Count
            If maxRows = 0 Then
                txtDataTransferProgress1.Text = " No data found "
                FileClose(122)
                conns.Close()
                Exit Sub
            End If

            Dim objCmd As MySqlConnector.MySqlCommand

            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            dataForm = lblFormName1.Text
            code_loc = ""

            If Not Data_Fields(dataForm, st, ed, code_loc) Then
                FileClose(122)
                conns.Close()
                Exit Sub
            End If
            'conns.Close()
            'MsgBox(st & " " & ed & " " & code_loc)
            flds = (ed - st) + 1 ' Total fields for the observation values

            'Loop through all records in dataset
            stnId = ""
            For n = 0 To maxRows - 1
                'Display progress of data transfer

                txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                txtDataTransferProgress1.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table

                stnId = dss.Tables(frm_tbl).Rows(n).Item("stationId")
                If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item("signature")) Then
                    capturedBy = dss.Tables(frm_tbl).Rows(n).Item("signature")
                Else
                    capturedBy = ""
                End If

                If code_loc = "Vertical" Then elemCode = dss.Tables(frm_tbl).Rows(n).Item("elementId")

                For m = st To ed
                    obsVal = ""
                    obsFlag = ""
                    obsperiod = vbNull

                    If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m)) Then
                        obsVal = dss.Tables(frm_tbl).Rows(n).Item(m)
                        If dss.Tables(frm_tbl).Rows(n).Item(m) = "" Then obsFlag = "M"
                    Else
                        obsVal = ""
                        obsFlag = "M"
                    End If

                    If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + flds)) Then
                        obsFlag = dss.Tables(frm_tbl).Rows(n).Item(m + flds)
                    Else
                        obsFlag = ""
                    End If

                    Select Case dataForm
                        Case "form_synoptic_2_ra1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")

                        Case "form_synoptic2_caribbean"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")

                        Case "form_daily2"

                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = (m - st) + 1
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")

                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then
                                If IsNumeric(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                            Else
                                'obsperiod = ""
                                'obsFlag = "M"
                            End If

                        Case "form_hourly2"
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = (m - st) + 1
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")

                            'If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then
                            '    If IsNumeric(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                            'Else
                            '    'obsperiod = ""
                            '    'obsFlag = "M"
                            'End If

                        Case "form_agro1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = rgKey.RegkeyValue("key01")

                            ' Align the air temperaturs and RH hourly observations to the appriate element codes and observation hours e.g. RH@12H from elemCode 515 to 105 and hh to 12:00 respectively                   
                            Select Case elemCode
                                Case 515
                                    elemCode = 105
                                    hh = 12
                                Case 511
                                    elemCode = 101
                                    hh = 12
                                Case 512
                                    elemCode = 102
                                    hh = 12
                                Case 503
                                    elemCode = 103
                                    hh = 12
                            End Select

                            ' Soil Tempeartures @ 05H for all depths alignment
                            If elemCode = 72 Or elemCode = 73 Or elemCode = 74 Or elemCode = 554 Or elemCode = 75 Or elemCode = 76 Then hh = 5

                            ' Soil Tempeartures @ 09H for 5cm,10cm and 20cm alignment
                            If elemCode = 561 Or elemCode = 562 Or elemCode = 563 Then
                                elemCode = 72
                                hh = 9
                            End If

                            ' Soil Tempeartures @ 13H for 5cm,10cm and 20cm alignment
                            If elemCode = 564 Or elemCode = 565 Or elemCode = 565 Then
                                elemCode = 72
                                hh = 13
                            End If

                        Case "form_upperair1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")
                            obsLevel = dss.Tables(frm_tbl).Rows(n).Item("levelName")

                        Case "form_daily1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = rgKey.RegkeyValue("key01")

                        Case "form_synoptic2_TDCF"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = dss.Tables(frm_tbl).Rows(n).Item("hh")

                        Case "form_hourly"
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = (m - st)

                        Case "form_monthly"
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = m - 2
                            dd = dss.Tables(frm_tbl).Rows(n).Item(m + 24)
                            hh = rgKey.RegkeyValue("key01")
                            obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + 24)

                        Case "form_hourlywind"
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = (m - st)
                            obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                            'Get Wind Direction values
                            elemCode = "112"
                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m)) Then
                                obsVal = dss.Tables(frm_tbl).Rows(n).Item(m)
                                If dss.Tables(frm_tbl).Rows(n).Item(m) = "" Then obsFlag = "M"
                            Else
                                obsVal = ""
                                obsFlag = "M"
                            End If

                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + flds)) Then obsFlag = dss.Tables(frm_tbl).Rows(n).Item(m + flds)


                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m)) Then
                                If dss.Tables(frm_tbl).Rows(n).Item(m) = "" Then obsFlag = "M"
                            End If


                            datetimeGTS(obsDatetime)

                            strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,capturedBy,dataForm) " &
                                     "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," & obsperiod & "," & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "');"

                            ' First save data into a text file to be uploaded later
                            frmrec = stnId & "," & elemCode & "," & obsDatetime & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & obsperiod & "," & qcStatus & "," & acquisitionType & "," & capturedBy & "," & dataForm
                            PrintLine(122, frmrec & ",")
                            'PrintLine(122)

                            elemCode = "111"

                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then
                                obsVal = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                                If dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2)) = "" Then obsFlag = "M"
                            Else
                                obsVal = ""
                                obsFlag = "M"
                            End If


                            datetimeGTS(obsDatetime)

                            ''Generate SQL string for inserting data into observationinitial table

                            ' First save data into a text file to be uploaded later
                            frmrec = stnId & "," & elemCode & "," & obsDatetime & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & obsperiod & "," & qcStatus & "," & acquisitionType & "," & capturedBy & "," & dataForm
                            PrintLine(122, frmrec & ",")
                            'PrintLine(122)

                            Continue For

                        Case Else
                            MsgBox("No table found")
                            FileClose(122)
                            conns.Close()
                            Exit Sub
                    End Select

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    datetimeGTS(obsDatetime)

                    ' Skip records with blank observation values and without flags
                    If Len(obsVal) = 0 And Len(obsFlag) = 0 Then
                        Continue For
                    End If

                    frmrec = stnId & "," & elemCode & "," & obsDatetime & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & obsperiod & "," & qcStatus & "," & acquisitionType & "," & capturedBy & "," & dataForm
                    PrintLine(122, frmrec & ",")
                    'PrintLine(122)

                Next m
                'Move to next record in dataset
            Next n

            ' Upload form data saved into a text file
            FileClose(122)

            ' Remove the previously uploaded records that are among the selection 

            ' Create sql query

            strSQL = "LOAD DATA local INFILE '" & fl & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,capturedBy,dataForm);"

            objCmd = New MySqlConnector.MySqlCommand(strSQL, conns)

            'Execute query
            objCmd.CommandTimeout = 0
            objCmd.ExecuteNonQuery()

            'If maxRows = 0 Then
            '    txtDataTransferProgress1.Text = " No data found "
            'Else
            lblDataTransferProgress.ForeColor = Color.Red
                lblDataTransferProgress.Text = "Total " & maxRows & " Records Transfered" 'Data transfer complete !"
                txtDataTransferProgress1.Text = ""
            'End If
            conns.Close()
        Catch ex As Exception
            FileClose(122)
            MsgBox(ex.Message)
            lblDataTransferProgress.ForeColor = Color.Red
            lblDataTransferProgress.Text = "Data transfer Failure !"

            conns.Close()
        End Try

    End Sub

    Private Sub frmUploadgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles frmUploadgroundWorker.ProgressChanged
        'MsgBox(e.ProgressPercentage)
    End Sub

    Private Sub frmFormUpload_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'If frmUploadgroundWorker.IsBusy Then
        '    frmUploadgroundWorker.CancelAsync()
        'End If
    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs)

    End Sub

    Function Data_Fields(tbl As String, ByRef startFiled As Integer, ByRef endField As Integer, ByRef code_loc As String) As Boolean
        Dim dsf As New DataSet
        Try
            'conns.ConnectionString = frmLogin.txtusrpwd.Text
            'conns.Open()

            sql = "select val_start_position as St, val_end_position as Ed, elem_code_location as Loc from data_forms where table_name = '" & tbl & "';"
            'MsgBox(sql)
            daa = New MySqlConnector.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0
            dsf.Clear()
            daa.Fill(dsf, "dataForm")

            With dsf.Tables("dataForm")
                If .Rows.Count > 0 Then
                    startFiled = .Rows(0).Item("St")
                    endField = .Rows(0).Item("Ed")
                    code_loc = .Rows(0).Item("Loc")
                    Return True
                Else
                    Return False
                End If
            End With
            'conns.Close()
        Catch x As Exception
            conns.Close()
            MsgBox(x.Message)
            Return False
        End Try
    End Function

    Private Sub chkUTC_CheckedChanged(sender As Object, e As EventArgs) Handles chkUTC.CheckedChanged
        If chkUTC.Checked Then
            txtTdiff.Visible = True
            lblDiff.Visible = True
        Else
            txtTdiff.Visible = False
            lblDiff.Visible = False
        End If
    End Sub


    Function datetimeGTS(ByRef dttime As String) As Boolean
        Dim diff As Integer

        diff = Val(txtTdiff.Text)
        diff = -1 * diff
        Try
            dttime = DateAdd("h", diff, dttime)
            dttime = DateAndTime.Year(dttime) & "-" & DateAndTime.Month(dttime) & "-" & DateAndTime.Day(dttime) & " " & DateAndTime.Hour(dttime) & ":00:00"

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub chkEntrydate_Click(sender As Object, e As EventArgs) Handles chkEntrydate.Click
        If chkEntrydate.Checked Then
            Me.Width = 923
            txtBeginYear.Enabled = False
            txtEndYear.Enabled = False
            txtBeginMonth.Enabled = False
            txtEndMonth.Enabled = False
        Else
            Me.Width = 656
            txtBeginYear.Enabled = True
            txtEndYear.Enabled = True
            txtBeginMonth.Enabled = True
            txtEndMonth.Enabled = True
        End If
    End Sub
End Class