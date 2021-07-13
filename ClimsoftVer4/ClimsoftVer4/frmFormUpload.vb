Imports System.ComponentModel

Public Class frmFormUpload
    Dim sql As String, conns As New MySql.Data.MySqlClient.MySqlConnection
    Dim daa As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dss As New DataSet
    Dim frm_tbl As String
    Dim rgKey As New dataEntryGlobalRoutines

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        'MsgBox("Data successfully uploaded !", MsgBoxStyle.Information)

    End Sub

    Private Sub frmDataTransferProgress_Load(sender As Object, e As EventArgs) Handles Me.Load
        frmUploadgroundWorker.WorkerReportsProgress = True
        frmUploadgroundWorker.WorkerSupportsCancellation = True

        lblDataTransferProgress.Refresh()
        'Initialize Stations List Views
        LstViewStations.Columns.Clear()
        LstViewStations.Columns.Add("Station Id", 100, HorizontalAlignment.Left)
        LstViewStations.Columns.Add("Station Name", 200, HorizontalAlignment.Left)


        Try
            conns.ConnectionString = frmLogin.txtusrpwd.Text
            conns.Open()

            sql = "select " & lblFormName.Text & ".stationId, stationName from " & lblFormName.Text & " inner join station on " & lblFormName.Text & ".stationId=station.stationId group by " & lblFormName.Text & ".stationId;"
            'MsgBox(sql)
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
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
        Dim strSQL, stnlist, code_loc, yyyy, mm, dd, hh, capturedBy, stnId, obsDatetime, obsVal, obsFlag, obsLevel, dataForm As String
        Dim stnselected As Boolean


        frm_tbl = lblFormName.Text
        lblDataTransferProgress.ForeColor = DefaultForeColor 'Color.Black
        lblDataTransferProgress.Text = ""
        txtDataTransferProgress1.Text = ""
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
        Else ' When All stations are selected
            stnselected = True
            If frm_tbl = "form_monthly" Then
                sql = "select * from " & frm_tbl & " where (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "');"
            Else
                sql = "select * from " & frm_tbl & " where (yyyy between '" & txtBeginYear.Text & "' and '" & txtEndYear.Text & "') and (mm between '" & txtBeginMonth.Text & "' and '" & txtEndMonth.Text & "');"
            End If
        End If
            Try
            conns.ConnectionString = frmLogin.txtusrpwd.Text
            conns.Open()

            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0
            dss.Clear()
            daa.Fill(dss, frm_tbl)
            'conns.Close()
            maxRows = dss.Tables(frm_tbl).Rows.Count

            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            dataForm = lblFormName.Text
            code_loc = ""

            If Not Data_Fields(dataForm, st, ed, code_loc) Then Exit Sub
            'conns.Close()
            'MsgBox(st & " " & ed & " " & code_loc)
            flds = (ed - st) + 1 ' Total fields for the observation values

            'Loop through all records in dataset
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

                'obsVal = ""
                'obsFlag = ""
                'obsperiod = vbNull

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
                    'If dss.Tables(frm_tbl).Rows(n).Item(m) = "" Then obsFlag = "M"

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


                            'If Len(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) > 0 Then obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then
                                'obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                                If IsNumeric(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then obsperiod = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                            Else
                                'obsperiod = ""
                                'obsFlag = "M"
                            End If

                        Case "form_agro1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            yyyy = dss.Tables(frm_tbl).Rows(n).Item("yyyy")
                            mm = dss.Tables(frm_tbl).Rows(n).Item("mm")
                            dd = dss.Tables(frm_tbl).Rows(n).Item("dd")
                            hh = rgKey.RegkeyValue("key01")

                        Case "form_upperair1"
                            elemCode = Strings.Right(dss.Tables(frm_tbl).Columns(m).ColumnName, 3)
                            'MsgBox(m & " " & elemCode)
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

                        Case "form_synoptic2_tdcf"
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
                                     "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," & obsperiod & "," & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conns)

                            Try
                                objCmd.ExecuteNonQuery()
                            Catch x As Exception
                                MsgBox(x.Message)
                            End Try
                            'Get Wind Speed values
                            elemCode = "111"

                            If Not IsDBNull(dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))) Then
                                obsVal = dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2))
                                If dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2)) = "" Then obsFlag = "M"
                            Else
                                obsVal = ""
                                obsFlag = "M"
                            End If
                            ''If dss.Tables(frm_tbl).Rows(n).Item(m + (flds * 2)) = "" Then obsFlag = "M"

                            datetimeGTS(obsDatetime)

                            strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,capturedBy,dataForm) " &
                                     "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," & obsperiod & "," & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conns)

                            Try
                                objCmd.ExecuteNonQuery()
                            Catch x As Exception
                                MsgBox(x.Message)
                            End Try
                            Continue For

                        Case Else
                            MsgBox("No table found")
                            conns.Close()
                            Exit Sub
                    End Select

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    datetimeGTS(obsDatetime)

                    'Generate SQL string for inserting data into observationinitial table
                    strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,capturedBy,dataForm) " &
                        "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," & obsperiod & "," _
                        & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"
                    'MsgBox(strSQL)
                    ' Create the Command for executing query and set its properties
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conns)

                    Try
                        objCmd.ExecuteNonQuery()
                    Catch x As Exception
                        'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                        'MsgBox(x.Message)
                        lblDataTransferProgress.Text = "Record No.: " & n + 1 & " skipped due to some errors"
                    End Try

                Next m
                'Move to next record in dataset
            Next n

            If maxRows = 0 Then
                txtDataTransferProgress1.Text = " No data found "
            Else
                lblDataTransferProgress.ForeColor = Color.Red
                lblDataTransferProgress.Text = "Data transfer complete !"
                txtDataTransferProgress1.Text = ""
            End If
            conns.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            lblDataTransferProgress.ForeColor = Color.Red
            lblDataTransferProgress.Text = "Data transfer Failure !"
            'MsgBox("Check and confirm selections")
            'MsgBox(ex.Message)
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
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
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

    Private Sub lblDiff_Click(sender As Object, e As EventArgs) Handles lblDiff.Click

    End Sub

    Private Sub txtTdiff_TextChanged(sender As Object, e As EventArgs) Handles txtTdiff.TextChanged

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
End Class