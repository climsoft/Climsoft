Public Class frmUploadToObsFinal
    Dim msgTxtNotYetImplemented As String
    Dim MyConnectionString As String, sql As String, conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'msgTxtNotYetImplemented = "Not yet implemented!"
        'MsgBox(msgTxtNotYetImplemented)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "qcchecks.htm#updateobsfinal")

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, stnId As String, elemCode As Integer, obsDate As String, obsVal As String, obsFlag, mark1 As String,
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, yyyy As Integer, mm As String, dd As String, hh As String

        Dim ds As New DataSet
        Dim maxRows As Integer
        Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer

        beginYear = Val(txtBeginYear.Text)
        endYear = Val(txtEndYear.Text)
        beginMonth = Val(txtBeginMonth.Text)
        endMonth = Val(txtEndMonth.Text)

        '------
        ds.Clear()
        MyConnectionString = frmLogin.txtusrpwd.Text
        ' conn.Close()
        conn.ConnectionString = MyConnectionString
        conn.Open()
        'First upload records with QC status =1
        sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType,mark " &
            "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear &
            " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=1"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0

        da.Fill(ds, "obsInitial")
        ''conn.Close() '
        ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter

        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        maxRows = ds.Tables("obsInitial").Rows.Count

        Dim ds1 As New DataSet
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim elemMaxRows As Integer, k As Integer, valScale As Single
        Sql = "SELECT elementId,elementScale FROM obselement"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ' Set to unlimited timeout period
        da1.SelectCommand.CommandTimeout = 0

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count
        'MsgBox("Number of elements: " & elemMaxRows)

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            frmDataTransferProgress.lblTableRecords.Text = "Uploading records with qcStatus=1"
            frmDataTransferProgress.lblTableRecords.Refresh()
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table

            dd = ""
            hh = ""
            yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            If Val(mm) < 10 Then mm = "0" & mm
            If Val(dd) < 10 Then dd = "0" & dd
            If Val(hh) < 10 Then hh = "0" & hh
            dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"
            stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
            elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")
            mark1 = ds.Tables("obsInitial").Rows(n).Item("mark")
            'Get the element scale
            Try
                For k = 0 To elemMaxRows - 1
                    If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
                Next k

                obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
                obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                obsVal = obsVal * valScale
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcStatus")) Then qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")

                'Generate SQL string for inserting data into observationFinal table
                strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,mark) " &
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                    qcStatus & "," & acquisitionType & "," & mark1 & ")"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception

                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)

            End Try

            'Move to next record in dataset
        Next n

        conn.Close()
        '------
        ds.Clear()
        MyConnectionString = frmLogin.txtusrpwd.Text
        ' conn.Close()
        conn.ConnectionString = MyConnectionString
        conn.Open()

        'Next upload records with QC status =2
        sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType " &
            "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear &
            " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=2"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0
        da.Fill(ds, "obsInitial")

        ''conn.Close() '
        ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter


        maxRows = ds.Tables("obsInitial").Rows.Count

        sql = "SELECT elementId,elementScale FROM obselement"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ' Set to unlimited timeout period
        da1.SelectCommand.CommandTimeout = 0

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count
        'MsgBox("Number of elements: " & elemMaxRows)

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            frmDataTransferProgress.lblTableRecords.Text = "Uploading records with qcStatus=2"
            frmDataTransferProgress.lblTableRecords.Refresh()
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows

            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table

            dd = ""
            hh = ""
            yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            If Val(mm) < 10 Then mm = "0" & mm
            If Val(dd) < 10 Then dd = "0" & dd
            If Val(hh) < 10 Then hh = "0" & hh
            dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"
            stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
            elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")

            'Get the element scale
            For k = 0 To elemMaxRows - 1
                If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
            Next k

            obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
            obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
            obsVal = obsVal * valScale
            obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
            qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
            acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")

            'Generate SQL string for replacing existing records of same Key with records with qcStatus 2
            strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " &
                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                qcStatus & "," & acquisitionType & ")"

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
            End Try

            'Move to next record in dataset
        Next n

        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Sub

    Private Sub txtEndMonth_TextChanged(sender As Object, e As EventArgs) Handles txtEndMonth.TextChanged
        If Strings.Len(txtBeginMonth.Text) > 0 And Strings.Len(txtBeginYear.Text) > 0 And Strings.Len(txtEndMonth.Text) > 0 And Strings.Len(txtEndYear.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub


    Private Sub frmUploadToObsFinal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conns As New MySql.Data.MySqlClient.MySqlConnection
        Dim dss As New DataSet, daa As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim sql As String


        'cmdOk.Text = lang("OK")
        'cmdCancel.Text = lang("Cancel")
        'cmdApply.Text = lang("Apply")
        'cmdHelp.Text = lang("Help")

        'Initialize Stations List Views
        LstViewStations.Columns.Clear()
        LstViewStations.Columns.Add("Station Id", 100, HorizontalAlignment.Left)
        LstViewStations.Columns.Add("Station Name", 200, HorizontalAlignment.Left)

        'Initialize Elements List Views
        lstViewElements.Columns.Clear()
        lstViewElements.Columns.Add("Element Code", 100, HorizontalAlignment.Left)
        lstViewElements.Columns.Add("Element Details", 200, HorizontalAlignment.Left)

        Try
            conns.ConnectionString = frmLogin.txtusrpwd.Text
            conns.Open()

            sql = "SELECT * FROM station ORDER BY stationId"
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0
            daa.Fill(dss, "station")

            Dim stn(2), elm(2) As String
            Dim itms = New ListViewItem

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

            sql = "SELECT * FROM obselement ORDER BY elementId"
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0

            daa.Fill(dss, "element")
            For i = 0 To dss.Tables("element").Rows.Count - 1
                elm(0) = dss.Tables("element").Rows(i).Item("elementId")
                If Not IsDBNull(dss.Tables("element").Rows(i).Item("description")) Then
                    elm(1) = dss.Tables("element").Rows(i).Item("description")
                Else ' When Elent Description is empty
                    elm(1) = ""
                End If

                itms = New ListViewItem(elm)
                lstViewElements.Items.Add(itms)
            Next

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox(ex.Message)
            conns.Close()
        End Try
        conns.Close()
    End Sub


    Private Sub chkAllStations_Click(sender As Object, e As EventArgs) Handles chkAllStations.Click
        If chkAllStations.Checked = False Then
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = False
            Next
            chkAllStations.Text = "Select All Stations"
            LstViewStations.Enabled = True
        Else
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = True
            Next
            chkAllStations.Text = "Unselect All Stations"
            LstViewStations.Enabled = False
        End If
    End Sub

    Private Sub chkAllElements_Click(sender As Object, e As EventArgs) Handles chkAllElements.Click
        If chkAllElements.Checked = False Then
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = False
            Next
            chkAllElements.Text = "Select All Elements"
            lstViewElements.Enabled = True
        Else
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = True
            Next
            chkAllElements.Text = "Unselect All Elements"
            lstViewElements.Enabled = False
        End If
    End Sub

    Private Sub cmdUploadData_Click(sender As Object, e As EventArgs) Handles cmdUploadData.Click
        'Open form for displaying data transfer progress
        Dim m As Integer, n As Integer, elem1 As Integer, elem2, Trecs As Integer
        Dim elmcode, stnlist, elmlist, stnelm_selected As String
        Dim stnselected, elmselected As Boolean

        'frmDataTransferProgress.Show()
        'lblTableRecords.Refresh()

        'Upload data to observationInitial table
        Dim strSQL, stnId, elemCode, obsVal, obsFlag, period, mark1, qcStatus, obsLevel, obsDate, mm, dd, hh, mnt, ss As String
        Dim acquisitionType, yyyy As Integer

        Dim ds As New DataSet
        Dim maxRows As Integer
        Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer

        Try

            ' List the selected stations
            stnlist = ""
            elmlist = ""
            stnselected = False
            elmselected = False

            'Set Cursor to busy mode
            Me.Cursor = Cursors.WaitCursor

            ' List the selected stations
            If chkAllStations.Checked = False Then ' When NOT all stations are selected
                For i = 0 To LstViewStations.Items.Count - 1
                    If LstViewStations.Items(i).Checked = True Then
                        stnId = LstViewStations.Items(i).SubItems(0).Text
                        stnselected = True
                        If Len(stnlist) = 0 Then
                            stnlist = "RecordedFrom = " & " '" & stnId & "'" 'stnid
                        Else
                            stnlist = stnlist & " OR RecordedFrom = " & "'" & stnId & "'"
                        End If
                        'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                    End If
                Next
            Else ' When All stations are selected
                stnselected = True
            End If

            ' List the selected Elements
            If chkAllElements.Checked = False Then ' When NOT all stations are selected
                For i = 0 To lstViewElements.Items.Count - 1
                    If lstViewElements.Items(i).Checked = True Then
                        elmcode = lstViewElements.Items(i).SubItems(0).Text
                        elmselected = True
                        If Len(elmlist) = 0 Then
                            elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
                        Else
                            elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
                        End If
                        'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                    End If
                Next
            Else ' When All stations are selected
                elmselected = True
            End If

            ' Contruct the Stations and Elements selction criteria string
            If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
            If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

            ' Set the stations and elements selection conditions
            If stnselected = False Or elmselected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
                Me.Cursor = Cursors.Default
                MsgBox(" Selections not properly done. Check values!", MsgBoxStyle.Exclamation, "Selection Error")
                Exit Sub
            Else
                If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = elmlist & " and "
                If chkAllElements.Checked = True And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and "
                If chkAllElements.Checked = True And chkAllStations.Checked = True Then stnelm_selected = ""
                If chkAllElements.Checked = False And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and " & elmlist & " and "
            End If

            beginYear = Val(txtBeginYear.Text)
            endYear = Val(txtEndYear.Text)
            beginMonth = Val(txtBeginMonth.Text)
            endMonth = Val(txtEndMonth.Text)


            '------
            'ds.Clear()
            MyConnectionString = frmLogin.txtusrpwd.Text
            ' conn.Close()
            conn.ConnectionString = MyConnectionString
            conn.Open()
            'First upload records with QC status =1

            sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,mark " &
                "FROM observationInitial WHERE " & stnelm_selected & " year(obsDateTime) between " & beginYear & " AND " & endYear &
                " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=1;"

            'MsgBox(sql)
            'Exit Sub
            'dadData.SelectCommand.CommandTimeout=120

            Trecs = 0
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "obsInitial")
            ''conn.Close() '
            ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter
            'Catch ex As Exception
            '    If ex.HResult <> -2147024882 Then MsgBox(ex.Message)
            'End Try

            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
            maxRows = ds.Tables("obsInitial").Rows.Count

            Trecs = Trecs + maxRows ' Total Records

            Dim ds1 As New DataSet
            Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim elemMaxRows As Integer, k As Integer, valScale As Single
            sql = "SELECT elementId,elementScale FROM obselement"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da1.SelectCommand.CommandTimeout = 0
            ds1.Clear()
            da1.Fill(ds1, "elemScale")

            elemMaxRows = ds1.Tables("elemScale").Rows.Count
            'MsgBox("Number of elements: " & elemMaxRows)

            'Loop through all records in dataset
            For n = 0 To maxRows - 1

                lblTableRecords.Text = "Uploading records with qcStatus=1"
                lblTableRecords.Refresh()
                'Display progress of data transfer
                txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                txtDataTransferProgress.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table
                'Try
                dd = ""
                hh = ""
                yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

                If Val(mm) < 10 Then mm = "0" & mm
                If Val(dd) < 10 Then dd = "0" & dd
                If Val(hh) < 10 Then hh = "0" & hh

                dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                mnt = Minute(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                ss = Second(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

                ''obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                ' Code improved to include minutes and seconds in the datetime string
                obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

                stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
                elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("mark")) Then
                    mark1 = ds.Tables("obsInitial").Rows(n).Item("mark")
                Else
                    mark1 = 0
                End If


                'Get the element scale

                For k = 0 To elemMaxRows - 1
                    If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
                Next k

                obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")

                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) Then
                    period = ds.Tables("obsInitial").Rows(n).Item("period")
                Else
                    period = "NULL"
                End If

                'period = ds.Tables("obsInitial").Rows(n).Item("period")

                'Types of bservation values
                If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
                    obsVal = "NULL"
                    obsFlag = "M"
                ElseIf Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
                    obsVal = "NULL"
                    obsFlag = "M"

                Else
                    obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                    obsVal = obsVal * valScale
                End If

                'If obsFlag = "M" Then Continue For

                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcStatus")) Then qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")
                'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) Then period = ds.Tables("obsInitial").Rows(n).Item("period")

                'Generate SQL string for inserting data into observationFinal table
                If Not chkUpdateRecs.Checked Then
                    strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark) " &
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                    period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"
                Else
                    strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period, qcStatus,acquisitionType,mark) " &
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                     period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"
                End If

                'strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                '    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                '    qcStatus & "," & acquisitionType & ")"
                'MsgBox(strSQL)
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.CommandTimeout = 0

                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
                'Catch ex As Exception
                '    If ex.HResult <> -2147024882 Then MsgBox(ex.Message)
                'End Try

                'Move to next record in dataset

            Next n

            conn.Close()
            '------
            ds.Clear()
            MyConnectionString = frmLogin.txtusrpwd.Text
            ' conn.Close()
            conn.ConnectionString = MyConnectionString
            conn.Open()
            'Try
            'Next upload records with QC status =2
            sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType " &
                "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear &
                " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=2"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "obsInitial")
            ''conn.Close() '
            ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter

            maxRows = ds.Tables("obsInitial").Rows.Count
            Trecs = Trecs + maxRows

            sql = "SELECT elementId,elementScale FROM obselement"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da1.SelectCommand.CommandTimeout = 0

            da1.Fill(ds1, "elemScale")
            elemMaxRows = ds1.Tables("elemScale").Rows.Count
            'MsgBox("Number of elements: " & elemMaxRows)

            'Loop through all records in dataset
            'Catch ex As Exception
            '    If ex.HResult <> -2147024882 Then MsgBox(ex.Message)
            'End Try
            'MsgBox(7)
            For n = 0 To maxRows - 1

                lblTableRecords.Text = "Uploading records with qcStatus=2"
                lblTableRecords.Refresh()

                'Display progress of data transfer

                'frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows

                'frmDataTransferProgress.txtDataTransferProgress.Refresh()

                txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                txtDataTransferProgress.Refresh()

                'Loop through all observation fields adding observation records to observationInitial table
                'Try
                dd = ""
                hh = ""
                yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                If Val(mm) < 10 Then mm = "0" & mm
                If Val(dd) < 10 Then dd = "0" & dd
                If Val(hh) < 10 Then hh = "0" & hh
                dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                mnt = Minute(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                ss = Second(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

                'obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                ' Code improved to include minutes and seconds in the datetime string
                obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

                stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
                elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")

                'Get the element scale
                For k = 0 To elemMaxRows - 1
                    If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
                Next k

                'Types of observation values
                If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
                    obsVal = "NULL"
                    obsFlag = "M"
                ElseIf Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
                    obsVal = "NULL"
                    obsFlag = "M"
                Else
                    obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                    obsVal = obsVal * valScale
                End If

                obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
                obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")

                ''Generate SQL string for replacing existing records of same Key with records with qcStatus 2
                'strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType) " &
                '    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "','" & period & "'," &
                '    qcStatus & "," & acquisitionType & ")"

                'Generate SQL string for replacing existing records of same Key with records with qcStatus 2
                ' Modified to only update values in the necessary fields in the record that have been changed 
                strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag, qcStatus) " &
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & qcStatus & ");"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.CommandTimeout = 0

                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
                'Catch ex As Exception

                '    If ex.HResult <> -2147024882 Then MsgBox(ex.Message)
                'End Try

                'Move to next record in dataset

            Next n

        Catch ex As Exception
            MsgBox(ex.Message)
            lblTableRecords.ForeColor = Color.Red
            lblTableRecords.Text = "Data transfer failed !"
            conn.Close()
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try


        conn.Close()
        'frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        'frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

        lblTableRecords.ForeColor = Color.Red
        lblTableRecords.Text = "Data transfer complete !"
        txtDataTransferProgress.Text = Trecs & " Records Transferred!"

        'Set Cursor to busy mode
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtBeginMonth_TextChanged(sender As Object, e As EventArgs) Handles txtBeginMonth.TextChanged

    End Sub

    Private Sub lblBeginMonth_Click(sender As Object, e As EventArgs) Handles lblBeginMonth.Click

    End Sub
End Class