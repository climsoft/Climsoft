Imports MySql.Data.MySqlClient

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
            "FROM observationinitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear &
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
        sql = "SELECT elementId,elementScale FROM obselement"
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

                obsFlag = Strings.Replace(obsFlag, "\", "")

                'Generate SQL string for inserting data into observationFinal table
                strSQL = "INSERT IGNORE INTO observationfinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,mark) " &
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
            "FROM observationinitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear &
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

            obsFlag = Strings.Replace(obsFlag, "\", "")

            'Generate SQL string for replacing existing records of same Key with records with qcStatus 2
            strSQL = "REPLACE INTO observationfinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " &
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

            'sql = "SELECT * FROM station ORDER BY stationId"
            sql = "SELECT stationId, stationName FROM station INNER JOIN observationinitial ON stationId = recordedFrom
                   WHERE qcStatus > 0 GROUP BY stationId ORDER BY stationId;"
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
                    cmbstation.Items.Add(stn(1))
                Else
                    stn(1) = ""
                End If

                itms = New ListViewItem(stn)
                LstViewStations.Items.Add(itms)
            Next

            'sql = "SELECT * FROM obselement ORDER BY elementId"
            sql = "SELECT elementId, description FROM obselement INNER JOIN observationinitial ON elementId = describedBy
                   WHERE qcStatus > 0 GROUP BY elementId ORDER BY elementId;"
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            ' Set to unlimited timeout period
            daa.SelectCommand.CommandTimeout = 0

            daa.Fill(dss, "element")
            For i = 0 To dss.Tables("element").Rows.Count - 1
                elm(0) = dss.Tables("element").Rows(i).Item("elementId")
                If Not IsDBNull(dss.Tables("element").Rows(i).Item("description")) Then
                    elm(1) = dss.Tables("element").Rows(i).Item("description")
                    cmbElement.Items.Add(elm(1))
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

        ClsTranslations.TranslateForm(Me)
        'todo in future this will be done automatically by TranslateForms(Me)
        ClsTranslations.TranslateComponent(LstViewStations, True)
        ClsTranslations.TranslateComponent(lstViewElements, True)
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
            'LstViewStations.Enabled = False
        End If
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            For i = 0 To LstViewStations.Items.Count - 1
                If LstViewStations.Items(i).SubItems(0).Text = cmbstation.Text Then
                    LstViewStations.Items(i).Checked = True
                    cmbstation.Text = ""
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbElement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbElement.KeyPress
        If Asc(e.KeyChar) = 13 Then
            For i = 0 To lstViewElements.Items.Count - 1
                If lstViewElements.Items(i).SubItems(0).Text = cmbElement.Text Then
                    lstViewElements.Items(i).Checked = True
                    cmbElement.Text = ""
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbElement_Click(sender As Object, e As EventArgs) Handles cmbElement.Click
        For i = 0 To lstViewElements.Items.Count - 1
            If lstViewElements.Items(i).SubItems(1).Text = cmbElement.Text Then
                lstViewElements.Items(i).Checked = True
                Exit For
            End If
        Next
    End Sub

    Private Sub cmbstation_Click(sender As Object, e As EventArgs) Handles cmbstation.Click
        For i = 0 To LstViewStations.Items.Count - 1
            If LstViewStations.Items(i).SubItems(1).Text = cmbstation.Text Then
                LstViewStations.Items(i).Checked = True
                Exit For
            End If
        Next
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
            'lstViewElements.Enabled = False
        End If
    End Sub

    Private Sub cmdUploadData_Click(sender As Object, e As EventArgs) Handles cmdUploadData.Click

        '' Open Form for displaying data transfer progress
        'Dim m As Integer, n As Integer, elem1 As Integer, elem2, Trecs As Integer
        'Dim elmcode, stnlist, elmlist, stnelm_selected, fl1, rec As String
        'Dim stnselected, obsv_nameelected As Boolean

        ''Upload data to observationInitial table
        'Dim strSQL, stnId, elemCode, obsVal, obsFlag, period, mark1, qcStatus, obsLevel, obsDate, mm, dd, hh, mnt, ss As String

        '' Definition of other data fields
        'Dim qcTypeLog, acquisitionType, dataform, captBy, tmpUnits, precipUnits, cldUnits, visunits, datasrcTzone As String
        'Dim yyyy As Integer

        'Dim ds As New DataSet
        'Dim maxRows As Integer
        'Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer

        'Try
        '    fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\init_2_final_sql.csv"
        '    FileOpen(102, fl1, OpenMode.Output)

        '    ' Convert path separater to SQL format
        '    fl1 = Strings.Replace(fl1, "\", "/")

        '    ' List the selected stations
        '    stnlist = ""
        '    elmlist = ""
        '    stnselected = False
        '    obsv_nameelected = False

        '    'Set Cursor to busy mode
        '    Me.Cursor = Cursors.WaitCursor

        '    ' List the selected stations
        '    If chkAllStations.Checked = False Then ' When NOT all stations are selected
        '        For i = 0 To LstViewStations.Items.Count - 1
        '            If LstViewStations.Items(i).Checked = True Then
        '                stnId = LstViewStations.Items(i).SubItems(0).Text
        '                stnselected = True
        '                If Len(stnlist) = 0 Then
        '                    stnlist = "RecordedFrom = " & " '" & stnId & "'" 'stnid
        '                Else
        '                    stnlist = stnlist & " OR RecordedFrom = " & "'" & stnId & "'"
        '                End If
        '                'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
        '            End If
        '        Next
        '    Else ' When All stations are selected
        '        stnselected = True
        '    End If

        '    ' List the selected Elements
        '    If chkAllElements.Checked = False Then ' When NOT all stations are selected
        '        For i = 0 To lstViewElements.Items.Count - 1
        '            If lstViewElements.Items(i).Checked = True Then
        '                elmcode = lstViewElements.Items(i).SubItems(0).Text
        '                obsv_nameelected = True
        '                If Len(elmlist) = 0 Then
        '                    elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
        '                Else
        '                    elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
        '                End If
        '            End If
        '        Next
        '    Else ' When All stations are selected
        '        obsv_nameelected = True
        '    End If

        '    ' Contruct the Stations and Elements selction criteria string
        '    If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
        '    If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

        '    ' Set the stations and elements selection conditions
        '    If stnselected = False Or obsv_nameelected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
        '        Me.Cursor = Cursors.Default
        '        conn.Close()
        '        FileClose(102)
        '        MsgBox(" Selections not properly done. Check values!", MsgBoxStyle.Exclamation, "Selection Error")
        '        Exit Sub
        '    Else
        '        If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = elmlist & " and "
        '        If chkAllElements.Checked = True And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and "
        '        If chkAllElements.Checked = True And chkAllStations.Checked = True Then stnelm_selected = ""
        '        If chkAllElements.Checked = False And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and " & elmlist & " and "
        '    End If

        '    beginYear = Val(txtBeginYear.Text)
        '    endYear = Val(txtEndYear.Text)
        '    beginMonth = Val(txtBeginMonth.Text)
        '    endMonth = Val(txtEndMonth.Text)


        '    MyConnectionString = frmLogin.txtusrpwd.Text
        '    conn.ConnectionString = MyConnectionString & ";AllowLoadLocalInfile=true "
        '    conn.Open()

        '    'First upload records with QC status =1

        '    'sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,mark " &
        '    sql = "SELECT * " &
        '        "FROM observationInitial WHERE " & stnelm_selected & " year(obsDateTime) between " & beginYear & " AND " & endYear &
        '        " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=1;"

        '    Trecs = 0
        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ' Set to unlimited timeout period
        '    da.SelectCommand.CommandTimeout = 0
        '    ds.Clear()
        '    da.Fill(ds, "obsInitial")

        '    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        '    maxRows = ds.Tables("obsInitial").Rows.Count

        '    Trecs = Trecs + maxRows ' Total Records

        '    Dim ds1 As New DataSet
        '    Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        '    Dim elemMaxRows As Integer, k As Integer, valScale As Single
        '    sql = "SELECT elementId,elementScale FROM obselement"
        '    da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ' Set to unlimited timeout period
        '    da1.SelectCommand.CommandTimeout = 0
        '    ds1.Clear()
        '    da1.Fill(ds1, "elemScale")

        '    elemMaxRows = ds1.Tables("elemScale").Rows.Count
        '    'MsgBox("Number of elements: " & elemMaxRows)

        '    'Loop through all records in dataset
        '    For n = 0 To maxRows - 1

        '        lblTableRecords.Text = "Uploading records with qcStatus=1"
        '        lblTableRecords.Refresh()
        '        'Display progress of data transfer
        '        txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
        '        txtDataTransferProgress.Refresh()
        '        'Loop through all observation fields adding observation records to observationInitial table
        '        'Try
        '        dd = ""
        '        hh = ""
        '        yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

        '        If Val(mm) < 10 Then mm = "0" & mm
        '        If Val(dd) < 10 Then dd = "0" & dd
        '        If Val(hh) < 10 Then hh = "0" & hh

        '        dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        mnt = Minute(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        ss = Second(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

        '        obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

        '        stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
        '        elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("mark")) Then
        '            mark1 = ds.Tables("obsInitial").Rows(n).Item("mark")
        '        Else
        '            mark1 = 0
        '        End If


        '        'Get the element scale

        '        For k = 0 To elemMaxRows - 1
        '            If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
        '        Next k

        '        obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")

        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) Then
        '            period = ds.Tables("obsInitial").Rows(n).Item("period")
        '        Else
        '            period = "\N"
        '        End If

        '        'Types of bservation values
        '        If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
        '            obsVal = "\N"
        '            obsFlag = "M"
        '        ElseIf Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
        '            obsVal = "\N"
        '            obsFlag = "M"
        '        Else
        '            obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
        '            obsVal = obsVal * valScale
        '            obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
        '        End If

        '        'If obsFlag = "M" Then Continue For

        '        'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcStatus")) Then qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")
        '        'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) Then period = ds.Tables("obsInitial").Rows(n).Item("period")

        '        obsFlag = Strings.Replace(obsFlag, "\", "")

        '        ' Other data fields not commonly used. First initialize to NULL
        '        qcTypeLog = "\N"
        '        acquisitionType = "\N"
        '        dataform = "\N"
        '        captBy = "\N"
        '        tmpUnits = "\N"
        '        precipUnits = "\N"
        '        cldUnits = "\N"
        '        visunits = "\N"
        '        datasrcTzone = "\N"

        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcTypeLog")) Then qcTypeLog = ds.Tables("obsInitial").Rows(n).Item("qcTypeLog")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("dataForm")) Then dataform = ds.Tables("obsInitial").Rows(n).Item("dataForm")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("capturedBy")) Then captBy = ds.Tables("obsInitial").Rows(n).Item("capturedBy")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("temperatureUnits")) Then tmpUnits = ds.Tables("obsInitial").Rows(n).Item("temperatureUnits")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("precipitationUnits")) Then precipUnits = ds.Tables("obsInitial").Rows(n).Item("precipitationUnits")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("cloudHeightUnits")) Then cldUnits = ds.Tables("obsInitial").Rows(n).Item("cloudHeightUnits")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("visUnits")) Then visunits = ds.Tables("obsInitial").Rows(n).Item("visUnits")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("dataSourceTimeZone")) Then datasrcTzone = ds.Tables("obsInitial").Rows(n).Item("dataSourceTimeZone")

        '        'Generate SQL string for inserting data into observationFinal table
        '        If Not chkUpdateRecs.Checked Then
        '            'strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark) " &
        '            '"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
        '            'period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"

        '            'rec = stnId & "," & elemCode & "," & obsDate & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & period & "," & qcStatus & "," & acquisitionType & "," & mark1
        '            rec = stnId & "," & elemCode & "," & obsDate & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & period & "," & qcStatus & "," & acquisitionType & "," & mark1 & "," &
        '                   qcTypeLog & "," & acquisitionType & "," & dataform & "," & captBy & "," & tmpUnits & "," & precipUnits & "," & cldUnits & "," & visunits & "," & datasrcTzone

        '            PrintLine(102, rec & ",")
        '            'PrintLine(102)
        '        Else
        '            'strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period, qcStatus,acquisitionType,mark) " &
        '            '"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
        '            ' period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"

        '            strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period, qcStatus,acquisitionType,mark," &
        '                "qcTypeLog,dataForm,capturedBy,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone) " &
        '                "VALUES('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & period & "," & qcStatus & "," & acquisitionType & "," & mark1 & "," &
        '                qcTypeLog & ",'" & dataform & "','" & captBy & "'," & tmpUnits & "," & precipUnits & "," & cldUnits & "," & visunits & "," & datasrcTzone & ");"
        '            'MsgBox(strSQL)
        '            ' Upload with replacing existing records 
        '            ' Create the Command for executing query and set its properties
        '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
        '            objCmd.CommandTimeout = 0

        '            'Execute query
        '            objCmd.ExecuteNonQuery()
        '        End If

        '    Next n

        '    ' Update database with records from a file
        '    FileClose(102)
        '    If Not chkUpdateRecs.Checked Then
        '        txtDataTransferProgress.Refresh()
        '        txtDataTransferProgress.Text = "Updating Database from bufer ...... Please Wait!"
        '        txtDataTransferProgress.Refresh()

        '        ' Create sql query
        '        'strSQL = "LOAD DATA local INFILE '" & fl1 & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark)"
        '        strSQL = "LOAD DATA local INFILE '" & fl1 & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark, " &
        '                  "qcTypeLog,acquisitionType,dataForm,capturedBy,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone);"

        '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        '        'Execute query
        '        objCmd.CommandTimeout = 0
        '        objCmd.ExecuteNonQuery()

        '        txtDataTransferProgress.Text = ""
        '        txtDataTransferProgress.Refresh()
        '    End If

        '    'Next upload records with QC status =2
        '    conn.Close()
        '    ds.Clear()
        '    MyConnectionString = frmLogin.txtusrpwd.Text
        '    ' conn.Close()
        '    conn.ConnectionString = MyConnectionString
        '    conn.Open()
        '    'Try

        '    txtDataTransferProgress.Text = "Checking for records with QC status =2 ...... Please Wait!"
        '    txtDataTransferProgress.Refresh()

        '    sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType " &
        '        "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " And " & endYear &
        '        " And month(obsDatetime) between " & beginMonth & " And " & endMonth & " And qcStatus=2"

        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ' Set to unlimited timeout period
        '    da.SelectCommand.CommandTimeout = 0
        '    da.Fill(ds, "obsInitial")

        '    maxRows = ds.Tables("obsInitial").Rows.Count
        '    Trecs = Trecs + maxRows

        '    sql = "SELECT elementId,elementScale FROM obselement"
        '    da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ' Set to unlimited timeout period
        '    da1.SelectCommand.CommandTimeout = 0

        '    da1.Fill(ds1, "elemScale")
        '    elemMaxRows = ds1.Tables("elemScale").Rows.Count

        '    For n = 0 To maxRows - 1

        '        lblTableRecords.Text = "Uploading records with qcStatus=2"
        '        lblTableRecords.Refresh()

        '        'Display progress of data transfer
        '        txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
        '        txtDataTransferProgress.Refresh()

        '        'Loop through all observation fields adding observation records to observationInitial table
        '        dd = ""
        '        hh = ""
        '        yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        If Val(mm) < 10 Then mm = "0" & mm
        '        If Val(dd) < 10 Then dd = "0" & dd
        '        If Val(hh) < 10 Then hh = "0" & hh
        '        dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        mnt = Minute(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
        '        ss = Second(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

        '        obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

        '        stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
        '        elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")

        '        'Get the element scale
        '        For k = 0 To elemMaxRows - 1
        '            If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
        '        Next k

        '        'Types of observation values
        '        If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
        '            obsVal = "\N"
        '            obsFlag = "M"
        '        ElseIf Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
        '            obsVal = "\N"
        '            obsFlag = "M"
        '        Else
        '            obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
        '            obsVal = obsVal * valScale
        '        End If

        '        obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
        '        qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
        '        If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")

        '        'obsFlag = Strings.Replace(obsFlag, "\", "")

        '        ''Generate SQL string for replacing existing records of same Key with records with qcStatus 2
        '        'strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType) " &
        '        '    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "','" & period & "'," &
        '        '    qcStatus & "," & acquisitionType & ")"

        '        'Generate SQL string for replacing existing records of same Key with records with qcStatus 2
        '        ' Modified to only update values in the necessary fields in the record that have been changed 

        '        strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag, qcStatus) " &
        '            "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & qcStatus & ");"

        '        ' Create the Command for executing query and set its properties
        '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
        '        objCmd.CommandTimeout = 0

        '        'Execute query
        '        objCmd.ExecuteNonQuery()

        '    Next n

        '    conn.Close()

        '    lblTableRecords.ForeColor = Color.Red
        '    lblTableRecords.Text = "Data transfer complete !"
        '    txtDataTransferProgress.Text = Trecs & " Records Transferred!"

        '    'Set Cursor to busy mode
        '    Me.Cursor = Cursors.Default

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    lblTableRecords.ForeColor = Color.Red
        '    lblTableRecords.Text = "Data transfer failed !"
        '    conn.Close()
        '    FileClose(102)
        '    Me.Cursor = Cursors.Default
        'End Try






        '        'Open form for displaying data transfer progress
        Dim m As Integer, n As Integer, elem1 As Integer, elem2, Trecs As Integer
        Dim elmcode, stnlist, elmlist, stnelm_selected, fl1, rec As String
        Dim stnselected, obsv_nameelected As Boolean

        'Upload data to observationInitial table
        Dim strSQL, stnId, elemCode, obsVal, obsFlag, period, mark1, qcStatus, obsLevel, obsDate, mm, dd, hh, mnt, ss As String

        ' Definition of other data fields
        Dim qcTypeLog, acquisitionType, dataform, captBy, tmpUnits, precipUnits, cldUnits, visunits, datasrcTzone As String
        Dim yyyy As Integer

        Dim ds As New DataSet
        Dim maxRows As Integer
        Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer

        Try
            fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\init_2_final_sql.csv"
            FileOpen(102, fl1, OpenMode.Output)

            ' Convert path separater to SQL format
            fl1 = Strings.Replace(fl1, "\", "/")

            ' List the selected stations
            stnlist = ""
            elmlist = ""
            stnselected = False
            obsv_nameelected = False

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
                        obsv_nameelected = True
                        If Len(elmlist) = 0 Then
                            elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
                        Else
                            elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
                        End If
                    End If
                Next
            Else ' When All stations are selected
                obsv_nameelected = True
            End If

            ' Contruct the Stations and Elements selction criteria string
            If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
            If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

            ' Set the stations and elements selection conditions
            If stnselected = False Or obsv_nameelected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
                Me.Cursor = Cursors.Default
                conn.Close()
                FileClose(102)
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


            MyConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = MyConnectionString & ";AllowLoadLocalInfile=true"
            conn.Open()

            'First upload records with QC status =1

            'sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,mark " &
            sql = "SELECT * " &
                "FROM observationinitial WHERE " & stnelm_selected & " year(obsDateTime) between " & beginYear & " AND " & endYear &
                " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=1;"

            Trecs = 0
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "obsInitial")

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

                obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

                stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
                elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")
                'qcStatus = ds.Tables("obsInitial").Rows(n).Item("describedBy")
                acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")

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

                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) And IsNumeric(ds.Tables("obsInitial").Rows(n).Item("period")) Then
                    period = ds.Tables("obsInitial").Rows(n).Item("period")
                Else
                    period = 1 ' "\N"
                End If

                'Types of bservation values
                If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
                    obsVal = "\N"
                    obsFlag = "M"
                ElseIf Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
                    obsVal = "\N"
                    obsFlag = "M" ' "M"
                Else
                    obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                    obsVal = obsVal * valScale
                    obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                End If

                'If obsFlag = "M" Then Continue For

                'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcStatus")) Then qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
                'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")
                'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("period")) Then period = ds.Tables("obsInitial").Rows(n).Item("period")

                obsFlag = Strings.Replace(obsFlag, "\", "")

                ' Other data fields not commonly used. First initialize to NULL
                qcTypeLog = "\N"
                'acquisitionType = "\N"
                dataform = "\N"
                captBy = "\N"
                tmpUnits = "\N"
                precipUnits = "\N"
                cldUnits = "\N"
                visunits = "\N"
                datasrcTzone = "\N"

                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcTypeLog")) Then qcTypeLog = ds.Tables("obsInitial").Rows(n).Item("qcTypeLog")
                'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("dataForm")) Then dataform = ds.Tables("obsInitial").Rows(n).Item("dataForm")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("capturedBy")) Then captBy = ds.Tables("obsInitial").Rows(n).Item("capturedBy")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("temperatureUnits")) Then tmpUnits = ds.Tables("obsInitial").Rows(n).Item("temperatureUnits")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("precipitationUnits")) Then precipUnits = ds.Tables("obsInitial").Rows(n).Item("precipitationUnits")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("cloudHeightUnits")) Then cldUnits = ds.Tables("obsInitial").Rows(n).Item("cloudHeightUnits")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("visUnits")) Then visunits = ds.Tables("obsInitial").Rows(n).Item("visUnits")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("dataSourceTimeZone")) Then datasrcTzone = ds.Tables("obsInitial").Rows(n).Item("dataSourceTimeZone")

                'Generate SQL string for inserting data into observationFinal table
                If Not chkUpdateRecs.Checked Then
                    'strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark) " &
                    '"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                    'period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"

                    'rec = stnId & "," & elemCode & "," & obsDate & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & period & "," & qcStatus & "," & acquisitionType & "," & mark1
                    rec = stnId & "," & elemCode & "," & obsDate & "," & obsLevel & "," & obsVal & "," & obsFlag & "," & period & "," & qcStatus & "," & qcTypeLog & "," & acquisitionType & "," &
                           dataform & "," & captBy & "," & mark1 & "," & tmpUnits & "," & precipUnits & "," & cldUnits & "," & visunits & "," & datasrcTzone

                    PrintLine(102, rec & ",")
                    'PrintLine(102)
                Else
                    'strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period, qcStatus,acquisitionType,mark) " &
                    '"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," &
                    ' period & "," & qcStatus & "," & acquisitionType & "," & mark1 & ")"

                    'recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,qcTypeLog,acquisitionType, " &
                    '"dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone)
                    strSQL = "REPLACE INTO observationfinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,qcTypeLog,acquisitionType," &
                        "dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone) " &
                        "VALUES('" & stnId & "','" & elemCode & "','" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & period & "," & qcStatus & ",'" & qcTypeLog & "'," & acquisitionType & ",'" &
                        dataform & "','" & captBy & "'," & mark1 & ",'" & tmpUnits & "','" & precipUnits & "','" & cldUnits & "','" & visunits & "','" & datasrcTzone & "');"

                    'txtDataTransferProgress.Text = (strSQL)

                    ' Upload with replacing existing records 
                    ' Create the Command for executing query and set its properties
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                    objCmd.CommandTimeout = 0

                    'Execute query
                    objCmd.ExecuteNonQuery()
                End If

            Next n

            ' Update database with records from a file
            FileClose(102)
            If Not chkUpdateRecs.Checked Then
                txtDataTransferProgress.Refresh()
                txtDataTransferProgress.Text = "Updating Database from bufer ...... Please Wait!"
                txtDataTransferProgress.Refresh()

                ' Create sql query

                'Load_Files(fl1, "observationfinal", 0, ",")

                ''strSQL = "LOAD DATA local INFILE '" & fl1 & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType,mark)"
                strSQL = "LOAD DATA local INFILE '" & fl1 & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,qcTypeLog,acquisitionType, " &
                          "dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone);"

                ' dataform & "," & captBy & "," & mark1 & "," & tmpUnits & "," & precipUnits & "," & cldUnits & "," & visunits & "," & datasrcTzone

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

                txtDataTransferProgress.Text = ""
                txtDataTransferProgress.Refresh()
            End If



            'Next upload records with QC status = 2
            conn.Close()
            ds.Clear()
            MyConnectionString = frmLogin.txtusrpwd.Text
            ' conn.Close()
            conn.ConnectionString = MyConnectionString & ";AllowLoadLocalInfile=true"
            conn.Open()
            'Try

            txtDataTransferProgress.Text = "Checking for records with QC status =2 ...... Please Wait!"
            txtDataTransferProgress.Refresh()
            'recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,qcTypeLog,acquisitionType, " &
            '              "dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone

            sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType " &
                "dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone  " &
                "FROM observationinitial WHERE year(obsDateTime) between " & beginYear & " And " & endYear &
                " And month(obsDatetime) between " & beginMonth & " And " & endMonth & " And qcStatus=2"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "obsInitial")

            maxRows = ds.Tables("obsInitial").Rows.Count

            If maxRows > 0 Then

                Trecs = Trecs + maxRows

                sql = "SELECT elementId,elementScale FROM obselement"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da1.SelectCommand.CommandTimeout = 0

            da1.Fill(ds1, "elemScale")
            elemMaxRows = ds1.Tables("elemScale").Rows.Count

            For n = 0 To maxRows - 1

                lblTableRecords.Text = "Uploading records with qcStatus=2"
                lblTableRecords.Refresh()

                'Display progress of data transfer
                txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                txtDataTransferProgress.Refresh()

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
                mnt = Minute(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
                ss = Second(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))

                obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":" & mnt & ":" & ss

                stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
                elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")

                'Get the element scale
                For k = 0 To elemMaxRows - 1
                    If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
                Next k

                    'Types of observation values
                    'If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of NULL for obs values
                    '    'obsVal = "\N"
                    'obsFlag = "M"
                    'sql = "UPDATE observationfinal SET obsvalue = NULL, flag = 'M', qcStatus = 2 WHERE recordedfrom = '" & stnId & "' AND describedBy = " & elemCode & " AND obsdatetime = '" & obsDate & "';"

                    If IsDBNull(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Or Len(ds.Tables("obsInitial").Rows(n).Item("obsValue")) = 0 Or Not IsNumeric(ds.Tables("obsInitial").Rows(n).Item("obsValue")) Then ' In case of Blanks for obs values
                        'obsVal = "\N"
                        'obsFlag = "M"
                        sql = "UPDATE observationfinal SET obsvalue = NULL, flag = 'M', qcStatus = 2 WHERE recordedfrom = '" & stnId & "' AND describedBy = " & elemCode & " AND obsdatetime = '" & obsDate & "';"
                    Else
                    obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                    obsVal = obsVal * valScale
                        sql = "UPDATE observationfinal SET obsvalue = " & obsVal & ", flag = '', qcStatus = 2 WHERE recordedfrom = '" & stnId & "' AND describedBy = " & elemCode & " AND obsdatetime = '" & obsDate & "';"
                    End If


                    ' Create the Command for executing query and set its properties
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    objCmd.CommandTimeout = 0

                    'Execute query
                    objCmd.ExecuteNonQuery()

                    ' Replaced code

                    'obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
                    'qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
                    'If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")

                    ''obsFlag = Strings.Replace(obsFlag, "\", "")

                    ''Generate SQL string for replacing existing records of same Key with records with qcStatus 2
                    ''strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,period,qcStatus,acquisitionType) " &
                    ''    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "','" & period & "'," &
                    ''    qcStatus & "," & acquisitionType & ")"

                    ''Generate SQL string for replacing existing records of same Key with records with qcStatus 2
                    '' Modified to only update values in the necessary fields in the record that have been changed 

                    'strSQL = "REPLACE INTO observationfinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag, qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone ) " &
                    '         "VALUES('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & period & "," & qcStatus & "," & qcTypeLog & "," & acquisitionType & "," &
                    '        dataform & ",'" & captBy & "','" & mark1 & "'," & tmpUnits & "," & precipUnits & "," & cldUnits & "," & visunits & "," & datasrcTzone & ");"



                    ''"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & qcStatus & "'," & qcTypeLog & ");"

                    '' Create the Command for executing query and set its properties
                    'objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                    'objCmd.CommandTimeout = 0

                    ''Execute query
                    'objCmd.ExecuteNonQuery()

                Next n
            End If
            conn.Close()

            lblTableRecords.ForeColor = Color.Red
            lblTableRecords.Text = "Data transfer complete !"
            txtDataTransferProgress.Text = Trecs & " Records Transferred!"

            'Set Cursor to busy mode
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            lblTableRecords.ForeColor = Color.Red
            lblTableRecords.Text = "Data transfer failed !"
            conn.Close()
            FileClose(102)
            Me.Cursor = Cursors.Default
        End Try
    End Sub


End Class