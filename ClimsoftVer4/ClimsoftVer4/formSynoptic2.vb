Public Class formSynoptic2
    Dim conn As New MySqlConnector.MySqlConnection
    Dim myConnectionString As String
    Dim objCmd As MySqlConnector.MySqlCommand
    Dim da, daSequencer, daValueLimits As MySqlConnector.MySqlDataAdapter
    Dim ds, dsSequencer, dsValueLimits As New DataSet
    Dim sql, obsValue, elemCode, sqlValueLimits, valUpperLimit, valLowerLimit As String
    Dim FldName As New dataEntryGlobalRoutines
    Dim DBT, WBT, DPT, RH, PPP, GPM, ELV As String

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        'MsgBox(inc)
        ' Confirm the validaty of the observation date
        If Not IsDate(cboDay.Text & "/" & cboMonth.Text & "/" & cboYear.Text) Or Not objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay) Then
            MsgBox("Confirm observation date")
            cboYear.Focus()
            Exit Sub
        End If

        Dim n As Integer, ctl As Control, msgTxtInsufficientData As String
        n = 0
        Try
            For Each ctl In Me.Controls
                'Check if some observation values have been entered
                If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
            Next ctl

            'Check if header information is complete. If the header information is complete and there is at least one obs value then,
            'carry out the next actions, otherwise bring up message showing that there is insufficient data
            If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(cboYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 And Strings.Len(cboHour.Text) > 0 Then

                '-----------------------------------------
                'Carry out QC checks before saving data
                'Dim objKeyPress As New dataEntryGlobalRoutines

                'Check item exists
                For Each ctl In Me.Controls
                    If ctl.Name = "cboStation" Then
                        If Not objKeyPress.checkExists(True, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check for numeric
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "txtYear" Or ctl.Name = "cboMonth" Or ctl.Name = "cboDay" Or ctl.Name = "cboHour" _
                            Or (Strings.Left(ctl.Name, 6) = "txtVal" And Strings.Len(ctl.Text)) > 0 Then
                        If Not objKeyPress.checkIsNumeric(obsValue, Me.ActiveControl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid year
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "txtYear" Then
                        If Not objKeyPress.checkValidYear(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid month
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboMonth" Then
                        If Not objKeyPress.checkValidMonth(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid day
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboDay" Then
                        If Not objKeyPress.checkValidDay(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid hour
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboHour" Then
                        If Not objKeyPress.checkValidHour(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check future date
                If Not objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay) Then
                    cboDay.Focus()
                End If

                'Check limits
                'Dim elemCode As Integer
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If Strings.Left(ctl.Name, 6) = "txtVal" Then


                        elemCode = Val(Strings.Mid(ctl.Name, 12, 3))

                        sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit FROM obselement WHERE elementId=" & elemCode

                        daValueLimits = New MySqlConnector.MySqlDataAdapter(sqlValueLimits, conn)
                        'Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                        dsValueLimits.Clear()
                        'Add row for element code associated with active control
                        daValueLimits.Fill(dsValueLimits, "obselement")

                        'Get element upper limit
                        If dsValueLimits.Tables("obselement").Rows.Count < 0 Then
                            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                                valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
                            Else
                                valUpperLimit = ""
                            End If

                            'Get element lower limit
                            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                                valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
                            Else
                                valLowerLimit = ""
                            End If

                            'Check upper limit
                            If ctl.Text <> "" And valUpperLimit <> "" Then
                                If Not objKeyPress.checkUpperLimit(ctl, obsValue, valUpperLimit) Then
                                    ctl.Focus()
                                End If
                            End If

                            'Check lower limit
                            If ctl.Text <> "" And valLowerLimit <> "" Then
                                If Not objKeyPress.checkLowerLimit(ctl, obsValue, valLowerLimit) Then
                                    ctl.Focus()
                                End If
                            End If
                        End If
                    End If
                Next ctl

                '---------------------------------------
                'Confirm if you want to continue and save data from key-entry form to database table
                Dim msgTxtContinue As String
                msgTxtContinue = "Do you want to continue and commit to database table?"
                If MsgBox(msgTxtContinue, MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub


                'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
                'must be declared for the Update method to work.
                Dim m As Integer
                'Dim ctl As Control
                Dim conr As New MySqlConnector.MySqlConnection
                Dim dsr As New DataSet
                Dim dar As MySqlConnector.MySqlDataAdapter
                'Dim cb As New MySqlConnector.MySqlCommandBuilder(dar)

                'Try

                conr.ConnectionString = myConnectionString
                conr.Open()

                    sql = "SELECT * from form_synoptic2_TDCF;"
                dar = New MySqlConnector.MySqlDataAdapter(sql, conr)
                dsr.Clear()
                dar.Fill(dsr, "form_synoptic2_TDCF")
                conr.Close()

                With dsr.Tables("form_synoptic2_TDCF")
                    'inc = .Rows.Count
                    Dim dsNewRow As DataRow
                    Dim recCommit As New dataEntryGlobalRoutines
                    Dim cb As New MySqlConnector.MySqlCommandBuilder(dar)

                    dsNewRow = .NewRow
                    ''Add a new record to the data source table
                    .Rows.Add(dsNewRow)
                    inc = .Rows.Count - 1

                    'Commit observation header information to database
                    .Rows(inc).Item("stationId") = cboStation.SelectedValue
                    .Rows(inc).Item("yyyy") = cboYear.Text
                    .Rows(inc).Item("mm") = cboMonth.Text
                    .Rows(inc).Item("dd") = cboDay.Text
                    .Rows(inc).Item("hh") = cboHour.Text

                    ' txtSignature.Text = frmLogin.txtUser.Text
                    .Rows(inc).Item("signature") = frmLogin.txtUsername.Text

                    'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
                    .Rows(inc).Item("entryDatetime") = Now()

                    'Commit observation values to database
                    'Observation values range from column 5 i.e. column index 4 to column 38 i.e. column index 37
                    For m = 5 To (valueFldsTotal + 4) 'm = 4 To 38
                        For Each ctl In Me.Controls
                            If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                .Rows(inc).Item(m) = ctl.Text
                            End If
                        Next ctl
                    Next m

                    'Commit observation flags to database
                    'Observation Flags range from column 39 i.e. column index 38 to column 72 i.e. column index 71
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4 'm = 39 To 71
                        For Each ctl In Me.Controls
                            If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                .Rows(inc).Item(m) = ctl.Text
                            End If
                        Next ctl
                    Next m

                    'Commit observation units to database
                    .Rows(inc).Item("temperatureUnits") = cboTempUnits.Text
                    .Rows(inc).Item("precipUnits") = cboPrecipUnits.Text
                    .Rows(inc).Item("cloudHeightUnits") = cboCloudheightUnits.Text
                    .Rows(inc).Item("visUnits") = cboVisibilityUnits.Text
                    .Rows(inc).Item("windspdUnits") = cboWindSpdUnits.Text

                    dar.Update(dsr, "form_synoptic2_TDCF")

                    ''Display message for successful record commit to table
                    recCommit.messageBoxCommit()


                    btnAddNew.Enabled = True
                    btnClear.Enabled = False
                    btnCommit.Enabled = False
                    btnDelete.Enabled = True
                    btnUpdate.Enabled = True
                    btnMoveFirst.Enabled = True
                    btnMoveLast.Enabled = True
                    btnMoveNext.Enabled = True
                    btnMovePrevious.Enabled = True

                    'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        btnDelete.Enabled = False
                    End If

                    maxrows = .Rows.Count
                    inc = maxrows - 1


                    'Call subroutine for record navigation
                    'MsgBox(inc)

                    navigateRecords()
                    btnAddNew.Focus()
                    '    Catch ex As Exception
                    '    MessageBox.Show(ex.Message)
                    'End Try
                End With
            Else
                msgTxtInsufficientData = "Incomplete header information or insufficient observation data!"
            MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
        End If

        Catch ex As Exception
            MsgBox(ex.Message & " at btnComit")
        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        Dim dataFormRecCount As Integer
        Dim strStation, strYear, strMonth, strDay, strHour As String

        strStation = cboStation.SelectedValue
        Try
            With ds.Tables("form_synoptic2_TDCF")
                dataFormRecCount = .Rows.Count

                If dataFormRecCount > 0 Then
                    cboStation.SelectedValue = .Rows(dataFormRecCount - 1).Item("stationId")
                    strYear = .Rows(dataFormRecCount - 1).Item("yyyy")
                    strMonth = .Rows(dataFormRecCount - 1).Item("mm")
                    strDay = .Rows(dataFormRecCount - 1).Item("dd")
                    strHour = .Rows(dataFormRecCount - 1).Item("hh")

                Else
                    cboStation.SelectedValue = cboStation.SelectedValue
                    strYear = cboYear.Text
                    strMonth = cboMonth.Text
                    strDay = cboDay.Text
                    strHour = cboHour.Text
                End If
            End With

            Dim ctl As Control

            'Clear textboxes for observation values
            'Observation values range from column 5 i.e. column index 4 to column of last value field
            For m = 5 To (valueFldsTotal + 4)
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                    If ctl.Name = "txtVal_Elem301Field010" Then ctl.Text = FldName.RegkeyValue("key00")
                Next ctl
            Next m

            'Clear textboxes for observation flags
            'Observation flags range from column 39 i.e. column index 38 to column 73 i.e. column index 72
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            ' Don't use Sequencer to fill the form header text boxes if in Double Key Entry i.e. Repeat Entry Mode
            If chkRepeatEntry.Checked Then
                Dim recdate As Date
                ' Enable AddNew button and Diable Save button
                btnAddNew.Enabled = True
                btnCommit.Enabled = False
                btnClear.Enabled = False
                ' Compute the new header entries for the next record
                cboStation.SelectedValue = strStation
                recdate = DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text)
                recdate = DateAdd("d", 1, recdate)
                cboYear.Text = DateAndTime.Year(recdate)
                cboMonth.Text = DateAndTime.Month(recdate)
                cboDay.Text = DateAndTime.Day(recdate)
                'txtVal_Elem101Field004.Focus()
                txtbox1Focus()
                Exit Sub
            End If

            Dim dsLastDataRecord As New DataSet
            Dim daLastDataRecord As MySqlConnector.MySqlDataAdapter
            Dim SQL_last_record, lastRecYear, lastRecMonth, lastRecDay, lastRecHour, stn As String
            Dim lastRec, nextRec As Date
            Dim hh As Integer

            SQL_last_record = "SELECT stationId,yyyy,mm,dd,hh, signature,entryDatetime from form_synoptic2_TDCF WHERE signature='" & frmLogin.txtUsername.Text & "' AND entryDatetime=(SELECT MAX(entryDatetime) FROM form_synoptic2_TDCF);"
            dsLastDataRecord.Clear()
            daLastDataRecord = New MySqlConnector.MySqlDataAdapter(SQL_last_record, conn)
            daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

            'Initialize header fields required for sequencer
            stn = cboStation.SelectedValue
            cboStation.SelectedValue = stn
            lastRecHour = cboHour.Text
            lastRecDay = cboDay.Text
            lastRecMonth = cboMonth.Text
            lastRecYear = cboYear.Text

            If dsLastDataRecord.Tables("lastDataRecord").Rows.Count > 0 Then
                stn = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("stationId")
                cboStation.SelectedValue = stn
                lastRecHour = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("hh")
                lastRecDay = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("dd")
                lastRecMonth = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("mm")
                lastRecYear = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("yyyy")
            End If

            ' Sequence the records for next entry by selecting the next hour
            lastRec = DateSerial(lastRecYear, lastRecMonth, lastRecDay) & " " & lastRecHour & ":00:00"

            nextRec = lastRec
            If DateAdd_Hour(nextRec, hh) Then
                cboYear.Text = DateAndTime.Year(nextRec)
                cboMonth.Text = DateAndTime.Month(nextRec)
                cboDay.Text = DateAndTime.Day(nextRec)
                cboHour.Text = hh
            Else
                cboHour.Text = hh
            End If

            'inc = maxrows

            ''Display record position in record navigation Text Box
            'recNumberTextBox.Text = "Record " & maxrows + 1 & " of " & maxrows + 1
            'txtbox1Focus()

            'Clear textboxes for observation flags
            'Observation flags range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Set record index to last record
            inc = maxrows

            formPopulate()

            txtbox1Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim inc, maxrows, valueFldsTotal As Integer

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        ClearTboxes()


        'Dim n As Integer, ctl As Control
        'n = 0
        'For Each ctl In Me.Controls
        '    'Check if some observation values have been entered
        '    If Strings.Left(ctl.Name, 6) = "txtVal" Then n = 1
        'Next ctl

        ''Check if header information is complete. If the header information is complete and there is at least on obs value then,
        ''carry out the next actions, otherwise bring up message showing that there is insufficient data
        'If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(cboYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

        '    'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
        '    'to undo the AddNew button process before the record can be committed to the datasource table linked to the DataSet.
        '    'So all the buttons that were disabled after the AddNew button was clicked should be enabled back again and the Commit button
        '    'disabled until the AddNew button is clicked

        '    btnAddNew.Enabled = True
        '    btnCommit.Enabled = False
        '    btnDelete.Enabled = True
        '    btnUpdate.Enabled = True
        '    btnMoveFirst.Enabled = True
        '    btnMoveLast.Enabled = True
        '    btnMoveNext.Enabled = True
        '    btnMovePrevious.Enabled = True

        '    'Set Record position index to first record
        '    inc = 0

        '    'Call subroutine for record navigation
        '    navigateRecords()
        'Else
        '    MsgBox("Incomplete header information and insufficient observation data!", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_synoptic2_TDCF"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_synoptic2_TDCF where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
        Else
            sql = "SELECT * FROM form_synoptic2_TDCF ORDER by stationId,yyyy,mm,dd,hh"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noPreviousRec As New dataEntryGlobalRoutines

        If inc > 0 Then
            inc = inc - 1
            navigateRecords()
        Else
            'If the record Index is equal to zero an error message must be displayed to show that there is no more previous record.
            'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
            'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noPreviousRec.messageBoxNoPreviousRecord()
        End If


        ''Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        'Dim noPreviousRec As New dataEntryGlobalRoutines

        'If inc > 0 Then
        '    inc = inc - 1
        '    navigateRecords()
        'Else
        '    'If the record Index is equal to zero an error message must be displayed to show that there is no more previous record.
        '    'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
        '    'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
        '    noPreviousRec.messageBoxNoPreviousRecord()
        'End If
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click

        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation

        navigateRecords()

    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noNextRec As New dataEntryGlobalRoutines
        If inc < (maxrows - 1) Then
            inc = inc + 1
            'Call subroutine for record navigation
            navigateRecords()
        Else
            'If the record Index is equal to maximum number of rows minus one, an error message must be displayed to show that
            'there is no more next record.The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class
            'hence the need to instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noNextRec.messageBoxNoNextRecord()
        End If

    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxrows - 1

        'Call subroutine for record navigation
        navigateRecords()


    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_synoptic2_TDCF")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        'frmFormUpload.lblFormName.Text = "form_synoptic2_TDCF"

        'frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName1.Text
        frmFormUpload.lblFormName1.Text = "form_synoptic2_TDCF"
        frmFormUpload.Show()
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName1.Text
        'Exit Sub

        'frmDataTransferProgress.Show()
        ''Upload data to observationInitial table
        'Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String,
        '    dd As String, hh As String, ctl As Control, capturedBy As String
        'Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String,
        '    qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String

        'Try
        '    myConnectionString = frmLogin.txtusrpwd.Text

        '    conn.ConnectionString = myConnectionString
        '    conn.Open()
        '    '
        '    maxRows = ds.Tables("form_synoptic2_TDCF").Rows.Count
        '    qcStatus = 0
        '    acquisitionType = 1
        '    obsLevel = "surface"
        '    obsVal = ""
        '    obsFlag = ""
        '    dataForm = "form_synoptic2_TDCF"

        '    'Loop through all records in dataset
        '    For n = 0 To maxRows - 1
        '        'Display progress of data transfer
        '        frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
        '        frmDataTransferProgress.txtDataTransferProgress1.Refresh()
        '        'Loop through all observation fields adding observation records to observationInitial table

        '        For m = 5 To (valueFldsTotal + 4)

        '            stnId = ds.Tables("form_daily1").Rows(n).Item(0)
        '            yyyy = ds.Tables("form_daily1").Rows(n).Item(1)
        '            mm = ds.Tables("form_daily1").Rows(n).Item(2)
        '            dd = ds.Tables("form_daily1").Rows(n).Item(3)
        '            hh = ds.Tables("form_daily1").Rows(n).Item(4)

        '            If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item("signature")) Then capturedBy = ds.Tables("form_daily1").Rows(n).Item("signature")

        '            If Val(mm) < 10 Then mm = "0" & mm
        '            If Val(dd) < 10 Then dd = "0" & dd
        '            If Val(hh) < 10 Then hh = "0" & hh

        '            obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

        '            If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item(m)) Then obsVal = ds.Tables("form_daily1").Rows(n).Item(m)
        '            If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item(m + 34)) Then obsFlag = ds.Tables("form_daily1").Rows(n).Item(m + 34)
        '            'Get the element code from the control name corresponding to column index
        '            For Each ctl In Me.Controls
        '                If Val(Strings.Right(ctl.Name, 3)) = m Then
        '                    elemCode = Val(Strings.Mid(ctl.Name, 12, 3))
        '                End If
        '            Next ctl

        '            'Generate SQL string for inserting data into observationinitial table
        '            If Strings.Len(obsVal) > 0 Then
        '                strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
        '                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
        '                    & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

        '                ' Create the Command for executing query and set its properties
        '                objCmd = New MySqlConnector.MySqlCommand(strSQL, conn)

        '                Try
        '                    'Execute query
        '                    objCmd.ExecuteNonQuery()
        '                    'Catch ex As MySqlConnector.MySqlException
        '                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
        '                Catch ex As Exception
        '                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
        '                    MsgBox(ex.Message)
        '                End Try
        '            End If
        '            'Move to next observation value in current record of the dataset

        '        Next m
        '        'Move to next record in dataset
        '    Next n
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    conn.Close()
        'End Try
        'conn.Close()
        'frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        'frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines

        Try
            If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

                'Display message to show that delete operation has been cancelled
                recDelete.messageBoxOperationCancelled()
                Exit Sub
            End If


            ds.Tables("form_synoptic2_TDCF").Rows(inc).Delete()
            da.Update(ds, "form_synoptic2_TDCF")

            MsgBox("Record Successfully Deleted")
            maxrows = maxrows - 1

            If ds.Tables("form_synoptic2_TDCF").Rows.Count > 0 Then
                inc = inc - 1
                If inc < 0 Then inc = 0
            Else
                formPopulate()
                Exit Sub
            End If
            'inc = 0

            'Call subroutine for records navigation
            navigateRecords()

            'maxrows = maxrows - 1
            'inc = 0
        Catch ex As Exception
            MsgBox("Deleted Record Failed!. Close and reopen the form. Then browse for the desired record. Repeat the Delete action")
        End Try
        ''Call subroutine for record navigation
        'navigateRecords()
    End Sub


    Private Sub btnTDCF_Click(sender As Object, e As EventArgs) Handles btnTDCF.Click
        frmSynopTDCF.Show()
        frmSynopTDCF.srcTable.Text = "form_synoptic2_TDCF"
        'frmSynopTDCF.cboTemplate.Text = "TM_307081"
        ' Subset Observations
        SubsetObservations()
    End Sub

    Dim objKeyPress As New dataEntryGlobalRoutines
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formSynoptic2_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Create and load Values and Flags text boxes
        If Not load_Controls() Then
            Me.Close()
            Exit Sub
        End If

        ' Populate the Year Combobox with the last 5 years from the current
        For i = 0 To 5
            cboYear.Items.Add(DateAndTime.Year(Now()) - i)
        Next

        'Populate the form with data from the first record if there is any
        tabNext = True

        'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If

        ' Retrieve Keyentry mode information and mark on the checkbox
        If FldName.Key_Entry_Mode(Me.Text) = "Double" Then chkRepeatEntry.Checked = True

        'Set the record index counter to the first row
        inc = 0
        myConnectionString = frmLogin.txtusrpwd.Text


        'conn.ConnectionString = myConnectionString
        'conn.Open()

        'sql = "SELECT * FROM form_synoptic2_TDCF"
        'da = New MySqlConnector.MySqlDataAdapter(sql, conn)
        'da.Fill(ds, "form_synoptic2_TDCF")
        'conn.Close()

        'maxrows = ds.Tables("form_synoptic2_TDCF").Rows.Count

        '--------------------------------
        'Fill ComboBox for station identifier with station list from station table
        Try
                Dim m As Integer
                Dim ctl As Control
                Dim ds1 As New DataSet
                Dim sql1 As String
                Dim da1 As MySqlConnector.MySqlDataAdapter

                sql1 = "SELECT stationId,stationName FROM station"
                da1 = New MySqlConnector.MySqlDataAdapter(sql1, conn)

                conn.Close()

                da1.Fill(ds1, "station")
                If ds1.Tables("station").Rows.Count > 0 Then
                    With cboStation
                        .DataSource = ds1.Tables("station")
                        .DisplayMember = "stationName"
                        .ValueMember = "stationId"
                        .SelectedIndex = 0
                    End With
                Else
                    MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
                End If
            Catch x1 As Exception
                MsgBox(x1.Message)
            End Try

        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            sql = "SELECT * FROM form_synoptic2_TDCF"
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_synoptic2_TDCF")
            conn.Close()

            maxrows = ds.Tables("form_synoptic2_TDCF").Rows.Count
            'Initialize header information for data-entry form
            With ds.Tables("form_synoptic2_TDCF")
                If maxrows > 0 Then
                    cboStation.SelectedValue = .Rows(inc).Item("stationId")
                    cboYear.Text = .Rows(inc).Item("yyyy")
                    cboMonth.Text = .Rows(inc).Item("mm")
                    cboDay.Text = .Rows(inc).Item("dd")
                    cboHour.Text = .Rows(inc).Item("hh")

                    'Initialize textboxes for observation values
                    ' But not for Repeat Entry mode
                    If chkRepeatEntry.Checked Then
                        btnAddNew.Enabled = True
                        btnCommit.Enabled = False
                        btnUpdate.Enabled = False
                        btnDelete.Enabled = False
                        btnClear.Enabled = False
                        btnMoveFirst.Enabled = False
                        btnMoveNext.Enabled = False
                        btnMovePrevious.Enabled = False
                        btnMoveLast.Enabled = False
                        Exit Sub
                    End If

                    'Observation values range from column 6 i.e. column index 5 to max field columns
                    For m = 5 To (valueFldsTotal + 4)
                        For Each ctl In Me.Controls

                            If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                If Not IsDBNull(.Rows(inc).Item(m)) Then
                                    ctl.Text = .Rows(inc).Item(m)
                                End If
                            End If
                        Next ctl
                    Next m

                    'Initialize textboxes for observation flags
                    'Observation flags range from column 39 i.e. column index 38 to field max field column
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                        For Each ctl In Me.Controls
                            If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                If Not IsDBNull(.Rows(inc).Item(m)) Then
                                    ctl.Text = .Rows(inc).Item(m)
                                End If
                            End If
                        Next ctl
                    Next m

                    displayRecordNumber()
                Else
                    'If this is the first record
                    btnAddNew.Enabled = False
                    btnCommit.Enabled = True
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnClear.Enabled = True
                    btnMoveFirst.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMovePrevious.Enabled = False
                    btnMoveLast.Enabled = False

                    recNumberTextBox.Text = "Record 1 of 1"
                End If
            End With
            '' Retrieve Keyentry mode information and mark on the checkbox
            ''MsgBox(FldName.Key_Entry_Mode(Me.Name))
            'If FldName.Key_Entry_Mode(Me.Text) = "Double" Then chkRepeatEntry.Checked = True

            ClsTranslations.TranslateForm(Me)

        Catch ex As Exception
            If ex.HResult = "-2146233086" Then
                MsgBox("No Element Selected!   >>> Select them from Metadata form")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try

        ' Load units of measure to the appropriate boxes
        cboTempUnits.Text = "Deg C" 'FldName.RegkeyValue("key10")
        cboPrecipUnits.Text = "metres" ' FldName.RegkeyValue("key09")
        cboCloudheightUnits.Text = "feet" 'FldName.RegkeyValue("key11")
        cboVisibilityUnits.Text = "metres" ' FldName.RegkeyValue("key14")
        cboWindSpdUnits.Text = "knots" 'FldName.RegkeyValue("key13")

        '' Poplate the Hour text box with the value from registry
        'Try

        '    Dim dsrg As New DataSet
        '    Dim sqlg As String
        '    Dim darg As MySqlConnector.MySqlDataAdapter

        '    sqlg = "Select keyvalue from regkeys where keyname = 'key01';"
        '    darg = New MySqlConnector.MySqlDataAdapter(sqlg, conn)
        '    dsrg.Clear()
        '    darg.Fill(dsrg, "Keys")

        '    If dsrg.Tables("Keys").Rows.Count > 0 Then
        '        cboHour.Text = dsrg.Tables("Keys").Rows(0).Item(0)
        '    End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'conn.Close()
        'inc = 0

        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub formSynoptic2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then My.Computer.Keyboard.SendKeys("{TAB}")
        'MsgBox(e.KeyCode)
        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal, obsFlag, flagtextBoxSuffix As String
        Dim flagIndexDiff As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = valueFldsTotal

        Try
            'If {ENTER} key is pressed

            If e.KeyCode = Keys.Enter Then
                'MsgBox(Me.ActiveControl.Name)
                'Check for conflicts if Double key entry mode is set

                If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    chkRepeatEntry.Checked = True

                    Dim elmcode As String
                    elmcode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    If Not objKeyPress.Entry_Verification(conn, Me, cboStation.SelectedValue, elmcode, cboYear.Text, cboMonth.Text, cboDay.Text, "06") Then
                        MsgBox("Can't derify data")
                    End If
                End If

                If Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" And Strings.Len(Me.ActiveControl.Text) > 0 Then

                    ' If a flag exists then separate the flag from the value and place the flag in the corresponding flag field.
                    If Not IsNumeric(Strings.Right(Me.ActiveControl.Text, 1)) Then
                        'Get observation flag from the texbox and convert it to Uppercase. Flag is a single letter added as the last character
                        'to the value string in the textbox.
                        obsFlag = Strings.Right(Me.ActiveControl.Text, 1).ToUpper
                        'Get the observation value by leaving out the last character from the string entered in the textbox
                        obsVal = Strings.Left(Me.ActiveControl.Text, Strings.Len(Me.ActiveControl.Text) - 1)

                        Me.ActiveControl.Text = obsVal
                    End If

                    'Now assign obsFlag to correct texbox on the form
                    For Each ctrl In Me.Controls
                        'Loop through all controls on form
                        'Locate the textbox for the flag field by calling the Function "getFlagTexboxSuffix"
                        If Strings.Left(ctrl.Name, 7) = "txtFlag" Then
                            If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                                ctrl.Text = obsFlag
                            End If
                        End If
                    Next ctrl

                    'Check that numeric value has been entered for observation value
                    objKeyPress.checkIsNumeric(Me.ActiveControl.Text, Me.ActiveControl)

                    'Get the element limits

                    ' This code was included on 21/09/2022 to cater for the local (station's) limits where they exist. Otherwise the global limits will be used
                    obsValue = Me.ActiveControl.Text
                    elemCode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    objKeyPress.GetQCLimits(cboStation.SelectedValue, elemCode, valUpperLimit, valLowerLimit)

                    'Check lower limit
                    If obsValue <> "" And valLowerLimit <> "" And tabNext = True Then
                        objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit)
                    End If
                    'Check upper limit
                    If obsValue <> "" And valUpperLimit <> "" And tabNext = True Then
                        objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit)
                    End If


                    'elemCode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    'sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit FROM obselement WHERE elementId=" & elemCode
                    ''
                    'daValueLimits = New MySqlConnector.MySqlDataAdapter(sqlValueLimits, conn)
                    ''Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                    'dsValueLimits.Clear()
                    ''Add row for element code associated with active control
                    'daValueLimits.Fill(dsValueLimits, "obselement")

                    'obsValue = Me.ActiveControl.Text

                    'If dsValueLimits.Tables("obselement").Rows.Count > 0 Then ' Limits record available
                    '    'Get element lower limit

                    '    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                    '        valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
                    '    Else
                    '        valLowerLimit = ""
                    '    End If
                    '    'Get element upper limit
                    '    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                    '        valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
                    '    Else
                    '        valUpperLimit = ""
                    '    End If

                    '    'Check lower limit
                    '    If obsValue <> "" And valLowerLimit <> "" And tabNext = True Then
                    '        objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit)
                    '    End If
                    '    'Check upper limit
                    '    If obsValue <> "" And valUpperLimit <> "" And tabNext = True Then
                    '        objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit)
                    '    End If
                    'End If

                    If Strings.Left(Me.ActiveControl.Name, 14) = "txtVal_Elem101" Then DBT = Me.ActiveControl.Text
                    If Strings.Left(Me.ActiveControl.Name, 14) = "txtVal_Elem106" Then PPP = Me.ActiveControl.Text
                    If Strings.Left(Me.ActiveControl.Name, 14) = "txtVal_Elem102" Then
                        WBT = Me.ActiveControl.Text
                        For Each ctl In Me.Controls
                            If Strings.Left(Me.ActiveControl.Name, 14) = "txtVal_Elem101" Then DBT = Me.ActiveControl.Text
                            If Strings.Left(ctl.name, 14) = "txtVal_Elem103" Then
                                'Compute Dew point
                                If IsNumeric(DBT) And IsNumeric(WBT) Then
                                    DPT = FldName.calculateDewpoint(Val(DBT) / 10, Val(WBT) / 10)

                                    ' In case the computed DPT becomes higher than WBT the DPT text box is not populated 
                                    If DPT <= WBT / 10 Then
                                        ctl.text = Val(DPT) * 10
                                    Else
                                        ctl.text = ""
                                    End If

                                End If
                            ElseIf Strings.Left(ctl.name, 14) = "txtVal_Elem105" Then

                                'Compute Relative Humidity
                                If IsNumeric(DBT) And IsNumeric(DPT) Then
                                    If DPT <= WBT / 10 Then ' Compute RH only if WBT is higher DPT
                                        RH = FldName.calculateRH(DPT, Val(DBT) / 10)
                                        ctl.text = RH
                                    Else
                                        ctl.text = ""
                                    End If
                                End If

                            End If
                        Next
                    End If

                    ' Compute Geopopential Height
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 14) = "txtVal_Elem106" Then PPP = ctl.text

                        If Strings.Left(ctl.name, 14) = "txtVal_Elem101" Then
                            DBT = ctl.text

                            ELV = Station_Elv(cboStation.SelectedValue) ' Get Elevation

                            Dim ctlGPM As Control
                            For Each ctlGPM In Me.Controls
                                If Strings.Left(ctlGPM.Name, 14) = "txtVal_Elem185" Then
                                    If IsNumeric(DBT) And IsNumeric(PPP) And IsNumeric(ELV) Then
                                        GPM = FldName.calculateGeopotential(Val(PPP) / 10, Val(DBT) / 10, Val(ELV), 850)
                                        ctlGPM.Text = GPM
                                    Else
                                        ctlGPM.Text = ""
                                    End If
                                End If
                            Next

                            ' Clear M in flag box if captured
                            Dim flgctl As Control
                            For Each flgctl In Me.Controls
                                If Strings.Left(flgctl.Name, 10) = "txtFlag185" Then flgctl.Text = ""
                            Next
                        End If
                    Next

                ElseIf Me.ActiveControl.Name = "cboYear" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboYear.Text, cboYear)
                    'Check valid year
                    If tabNext = True Then
                        objKeyPress.checkValidYear(cboYear.Text, cboYear)
                    End If
                ElseIf Me.ActiveControl.Name = "cboMonth" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboMonth.Text, cboMonth)
                    'Check valid month
                    objKeyPress.checkValidMonth(cboMonth.Text, cboMonth)
                ElseIf Me.ActiveControl.Name = "cboDay" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboDay.Text, cboDay)
                    'Check valid day
                    If tabNext = True Then
                        objKeyPress.checkValidDay(cboDay.Text, cboDay)
                    End If
                    If tabNext = True Then
                        objKeyPress.checkValidDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay)
                    End If
                    If tabNext = True Then
                        objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay)
                    End If
                ElseIf Me.ActiveControl.Name = "cboHour" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboHour.Text, cboHour)
                    'Check valid Hour
                    If tabNext = True Then
                        objKeyPress.checkValidHour(cboHour.Text, cboHour)
                    End If
                ElseIf Me.ActiveControl.Name = "cboStation" Then
                    Dim itemFound As Boolean
                    If Len(cboStation.SelectedValue) > 1 Then
                        itemFound = True
                    Else
                        itemFound = False
                        If FldName.Valid_Stn(cboStation) Then itemFound = True
                    End If
                    objKeyPress.checkExists(itemFound, cboStation)
                Else

                    ' Generate flag M for missing data for blank values
                    For Each ctrl In Me.Controls
                        If Strings.Left(ctrl.Name, 7) = "txtFlag" Then
                            If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                                ctrl.Text = "M" 'obsFlag
                                Exit For
                            End If
                        End If
                    Next ctrl


                End If

                ' Compute the next text box to get focus or set focus to the Save button if the last text box is the active control 
                If tabNext = True Then
                    If Me.ActiveControl.TabIndex = valueFldsTotal + 4 Then
                        btnCommit.Focus()
                    Else
                        My.Computer.Keyboard.SendKeys("{TAB}")
                    End If
                End If
            ElseIf (e.KeyCode = 33 Or e.KeyCode = 34) And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                shiftEntries(e.KeyCode)
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Function load_Controls() As Boolean

        Dim eName As String
        Dim eCode, txtX, flgX, lblX, posY1, edx, fldsValue, colmn, fldNo As Integer
        Dim txtvalue As TextBox = Nothing
        Dim txtflag As TextBox = Nothing
        Dim lblvalue, lblVheader, lblFheader As Label

        myConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = myConnectionString
        conn.Open()

        Try
            sql = "SELECT * from form_synoptic2_TDCF;"
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic2_TDCF")
            conn.Close()

            edx = 0
            fldsValue = 0
            colmn = 0
            fldNo = 5
            With ds.Tables("form_synoptic2_TDCF")

                ' Get the total value fields
                valueFldsTotal = 0
                For i = 0 To .Columns.Count - 1
                    If InStr(.Columns(i).ColumnName, "Val_Elem") > 0 Then valueFldsTotal = valueFldsTotal + 1
                Next

                For i = 0 To .Columns.Count - 1
                    posY1 = 117 '127
                    eName = Strings.Left(.Columns(i).ColumnName, 8)
                    If eName = "Val_Elem" Then

                        colmn = Int(fldsValue / 19)
                        txtX = 271 + 243 * colmn
                        flgX = 323 + 243 * colmn
                        lblX = 124 + 243 * colmn

                        If fldsValue Mod 19 = 0 Then
                            edx = 0
                            posY1 = 117 ' 127

                            ' Draw Values Column header
                            lblVheader = New Windows.Forms.Label
                            lblVheader.Name = "lblValue" & colmn
                            lblVheader.Text = "Value"
                            lblVheader.Location = New System.Drawing.Point(277 + 243 * colmn, 103)
                            lblVheader.Size = New System.Drawing.Size(34, 13)
                            Me.Controls.Add(lblVheader)

                            ' Draw Flags Column header
                            lblFheader = New Windows.Forms.Label
                            lblFheader.Name = "lblFlag" & colmn
                            lblFheader.Text = "Flag"
                            lblFheader.Location = New System.Drawing.Point(322 + 243 * colmn, 103)
                            lblFheader.Size = New System.Drawing.Size(27, 13)
                            Me.Controls.Add(lblFheader)
                        End If
                        fldsValue = fldsValue + 1
                        eCode = Strings.Right(.Columns(i).ColumnName, 3)
                        posY1 = posY1 + edx * 23 '25

                        ' Draw Value text box
                        txtvalue = New Windows.Forms.TextBox
                        txtvalue.Name = "txtVal_Elem" & eCode.ToString.PadLeft(3, "0"c) & "Field" & fldNo.ToString.PadLeft(3, "0"c)
                        txtvalue.Location = New System.Drawing.Point(txtX, posY1)
                        txtvalue.Size = New System.Drawing.Size(48, 20)
                        txtvalue.TabIndex = i '+ 5

                        ' Populate form with the default standard pressure level 
                        If txtvalue.Name = "txtVal_Elem301Field010" Then
                            txtvalue.Text = FldName.RegkeyValue("key00")
                        End If

                        Me.Controls.Add(txtvalue)
                        ' Get Geoptential value from registry

                        txtvalue.BorderStyle = BorderStyle.FixedSingle

                        'Draw Flag text box
                        txtflag = New Windows.Forms.TextBox
                        txtflag.Name = "txtFlag" & eCode.ToString.PadLeft(3, "0"c) & "Field" & (fldNo + valueFldsTotal).ToString.PadLeft(3, "0"c)
                        txtflag.Location = New System.Drawing.Point(flgX, posY1)
                        txtflag.Size = New System.Drawing.Size(23, 20)
                        txtflag.TabIndex = i + .Columns.Count
                        Me.Controls.Add(txtflag)
                        txtflag.BorderStyle = BorderStyle.FixedSingle
                        txtflag.Enabled = False

                        'If eCode = 2 Or eCode = 3 Or eCode = 5 Or eCode = 18 Or eCode = 84 Or eCode = 99 Then
                        '    txtvalue.Enabled = False
                        'End If

                        If eCode <= 100 Then '2 Or eCode = 3 Or eCode = 5 Or eCode = 18 Or eCode = 84 Or eCode = 99 Then
                            txtvalue.Enabled = False
                        End If

                        ' Draw text box Label
                        lblvalue = New Windows.Forms.Label
                        lblvalue.Name = "lbl" & eCode
                        lblvalue.Text = ElementName(eCode)
                        lblvalue.Location = New System.Drawing.Point(lblX, posY1)
                        lblvalue.Size = New System.Drawing.Size(141, 13)
                        lblvalue.TabIndex = i + .Columns.Count * 2 '(i + 5) + .Columns.Count * 2
                        Me.Controls.Add(lblvalue)
                        edx = edx + 1
                        fldNo = fldNo + 1
                    End If
                Next
            End With
            'compute Form height
            If fldsValue > 19 Then
                Me.Height = 220 + 19 * 25 'Maximum height attained
            Else
                Me.Height = 220 + fldsValue * 25
            End If

            'compute Form width
            If colmn > 1 Then
                Me.Width = 640 + 243 * (colmn - 1)
            Else
                Me.Width = 640        ' Minimum width at 2 columns only
            End If
            Me.CenterToScreen()

            'conn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
            If ex.HResult = -2147467259 Then
                MsgBox("Table for the selected form does not exist. Climsoft Administrator should first create the table through the menu 'Administration' => 'Create/Modify Key Entry Form'.")
            Else
                MsgBox(ex.Message)
            End If
            'conn.Close()
            Return False
        End Try

    End Function
    Function ElementName(code As Integer) As String
        ElementName = ""

        sql = "SELECT * FROM obselement"
        da = New MySqlConnector.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "element")

        With ds.Tables("element")

            For i = 0 To .Rows.Count - 1
                If .Rows(i).Item(0) = code Then
                    Return .Rows(i).Item("elementName")
                End If
            Next
        End With
    End Function

    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox

        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxrows
    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs)
        'MsgBox(Xt)
        'Dim ctl As Control
        'Dim txt As String

        'For Each ctl In Me.Controls
        '    If (Strings.Left(Me.ActiveControl.Name, 6) = "txtVal") Then
        '        txt = Me.ActiveControl.Name
        '    End If
        'Next
    End Sub

    Private Sub navigateRecords()

        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        '--------------------------
        Try
            Dim stn As String
            'Dim danv As MySqlConnector.MySqlDataAdapter

            conn.Open()


            sql = "SELECT * from form_synoptic2_TDCF;"
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic2_TDCF")
            conn.Close()

            With ds.Tables("form_synoptic2_TDCF")

                'MsgBox(.Rows(inc).Item("stationId") & " " & .Rows(inc).Item("yyyy") & " " & .Rows(inc).Item("mm") & " " & .Rows(inc).Item("dd") & " " & .Rows(inc).Item("hh"))
                stn = .Rows(inc).Item("stationId")

                cboStation.SelectedValue = stn
                '--------------------------
                'No need to assign text value to station combobox after assigning the "SelectedValue as above. This way, the displayed value
                'will be the station name according to the "DisplayMember in the texbox attribute, hence the line below has been commented out."

                'cboStation.SelectedValue = ds.Tables("form_daily1").Rows(inc).Item("stationId")

                cboYear.Text = .Rows(inc).Item("yyyy")
                cboMonth.Text = .Rows(inc).Item("mm")
                cboDay.Text = .Rows(inc).Item("dd")
                cboHour.Text = .Rows(inc).Item("hh")

                'MsgBox(.Rows(inc).Item("stationId") & " " & .Rows(inc).Item("yyyy") & " " & .Rows(inc).Item("mm") & " " & .Rows(inc).Item("dd") & " " & .Rows(inc).Item("hh"))

                Dim m As Integer
                Dim ctl As Control

                'Display observation values in coressponding textboxes
                'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53

                For m = 5 To (valueFldsTotal + 4)
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(.Rows(inc).Item(m)) Then
                                ctl.Text = .Rows(inc).Item(m)
                            Else
                                ctl.Text = ""
                            End If

                        End If
                    Next ctl
                Next m

                'Display observation flags in coressponding textboxes
                'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
                For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(.Rows(inc).Item(m)) Then
                                ctl.Text = .Rows(inc).Item(m)
                            Else
                                ctl.Text = ""
                            End If

                        End If
                    Next ctl
                Next m
                'Display observation units to database
                cboTempUnits.Text = .Rows(inc).Item("temperatureUnits")
                cboPrecipUnits.Text = .Rows(inc).Item("precipUnits")
                cboCloudheightUnits.Text = .Rows(inc).Item("cloudHeightUnits")
                cboVisibilityUnits.Text = .Rows(inc).Item("visUnits")
                cboWindSpdUnits.Text = .Rows(inc).Item("windspdUnits")
            End With

            displayRecordNumber()
        Catch ex As Exception
            MsgBox(ex.Message & " at navigateRecords")
        End Try

    End Sub

    Sub txtbox1Focus()
        Dim txtl As Control
        For Each txtl In Me.Controls
            If txtl.TabIndex = 5 Then
                txtl.Focus()
                Exit For
            End If
        Next
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder

        Dim conu As New MySqlConnector.MySqlConnection
        Dim dsu As New DataSet
        Dim dau As MySqlConnector.MySqlDataAdapter
        'Dim cb As New MySqlConnector.MySqlCommandBuilder(dar)

        'Try

        myConnectionString = frmLogin.txtusrpwd.Text
        conu.ConnectionString = myConnectionString
        conu.Open()

        sql = "SELECT * from form_synoptic2_TDCF;"
        sql = "SELECT * from form_synoptic2_TDCF where yyyy = '" & cboYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

        dau = New MySqlConnector.MySqlDataAdapter(sql, conu)
        dsu.Clear()
        dau.Fill(dsu, "form_synoptic2_TDCF")
        conu.Close()

        'must be declared for the Update method to work.
        Dim cb As New MySqlConnector.MySqlCommandBuilder(dau)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database

        Try
            With dsu.Tables("form_synoptic2_TDCF")
                .Rows(.Rows.Count - 1).Item("stationId") = cboStation.SelectedValue
                .Rows(.Rows.Count - 1).Item("yyyy") = cboYear.Text
                .Rows(.Rows.Count - 1).Item("mm") = cboMonth.Text
                .Rows(.Rows.Count - 1).Item("dd") = cboDay.Text
                .Rows(.Rows.Count - 1).Item("hh") = cboHour.Text

                'Update observation values in database
                'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
                For m = 5 To (valueFldsTotal + 4) 'm = 5 To 53
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            .Rows(.Rows.Count - 1).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                'Update observation flags in database
                'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
                For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4 'm = 54 To 102
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            .Rows(.Rows.Count - 1).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                'Update observation units to database
                .Rows(.Rows.Count - 1).Item("temperatureUnits") = cboTempUnits.Text
                .Rows(.Rows.Count - 1).Item("precipUnits") = cboPrecipUnits.Text
                .Rows(.Rows.Count - 1).Item("cloudHeightUnits") = cboCloudheightUnits.Text
                .Rows(.Rows.Count - 1).Item("visUnits") = cboVisibilityUnits.Text
                .Rows(.Rows.Count - 1).Item("windspdUnits") = cboWindSpdUnits.Text

            End With
            'The data adapter is used to update the record in the data source table

            dau.Update(dsu, "form_synoptic2_TDCF")

            'Show message for successful updating or record.
            recUpdate.messageBoxRecordedUpdated()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboHour_TextChanged(sender As Object, e As EventArgs) Handles cboHour.TextChanged
        Dim ctl As Control
        Dim codi, hh As String
        'If RecordExist Then msgbox ("Record Exists")

        formPopulate()

        hh = cboHour.Text.PadLeft(2, "0")
        For Each ctl In Me.Controls
            codi = Strings.Mid(ctl.Name, 12, 3)

            ' The following code is temporary to cater for special case in Cape Verde where some parameters are recorded at specific hours
            ' Whene a universal method for doing is devised the code will be changed accordingly
            ' Extrememe Temperaturs

            ' Management of text boxes for daily observations that are entered through the synoptic form
            'If codi = "002" Or codi = "003" Then
            If Val(codi) <= 100 And Strings.Left(ctl.Name, 3) = "txtval" Then
                'hh = Val(FldName.RegkeyValue("key01"))
                If Val(hh) = Val(FldName.RegkeyValue("key01")) Then ' Or hh = "18" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If

                ' Evaporation
            ElseIf codi = "815" Or codi = "816" Then
                If hh = "06" Or hh = "10" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
                ' 18 - 23Z Precipitation
            ElseIf codi = "864" Then
                If hh = "00" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
                ' 0 - 06Z Precipitation
            ElseIf codi = "861" Then
                If hh = "06" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
                ' 06 - 12Z Precipitation
            ElseIf codi = "862" Then
                If hh = "12" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
                ' 12 - 18Z Precipitation
            ElseIf codi = "863" Then
                If hh = "18" Then
                    ctl.Enabled = True
                Else
                    ctl.Enabled = False
                End If
            End If



            'If codi = "Then003" Or codi = "003" Or codi = "005" Or codi = "018" Or codi = "084" Or codi = "099" Or codi = "133" Or codi = "816" Then
            '    If Val(cboHour.Text) = Val(FldName.RegkeyValue("key01")) Then
            '        ctl.Enabled = True
            '    Else
            '        ctl.Enabled = False
            '    End If
            'ElseIf codi = "002" Then
            '    If Val(cboHour.Text) = Val(FldName.RegkeyValue("key02")) Then
            '        ctl.Enabled = True
            '    Else
            '        ctl.Enabled = False
            '    End If
            'End If
        Next
        'formPopulate()
        '' Populate form if the record exist to avoid repeat entry
        'If RecordExist() Then Exit Sub
        'populateForm()
        'End If
    End Sub

    Sub SubsetObservations()
        Dim kount As Integer
        Try
            myConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' Get all stations with the same observation time to constitute the subset of stations for encoding
            sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic2_TDCF where yyyy = '" & cboYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

            'MsgBox(sql)
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic2_TDCF")
            kount = ds.Tables("form_synoptic2_TDCF").Rows.Count

            frmSynopTDCF.cboStation.Text = cboStation.Text
            frmSynopTDCF.txtYear.Text = cboYear.Text
            frmSynopTDCF.cboMonth.Text = cboMonth.Text
            frmSynopTDCF.cboDay.Text = cboDay.Text
            frmSynopTDCF.cboHour.Text = cboHour.Text

            ' Populate the station combo box with the stations for the subset
            For i = 0 To kount - 1
                frmSynopTDCF.cboStation.Items.Add(ds.Tables("form_synoptic2_TDCF").Rows(i).Item("stationId"))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub

    'Function RecordExist() As Boolean
    '    Dim stn, yr, mn, dy, hr, dattime, sqlrec As String
    '    Dim conr As New MySqlConnector.MySqlConnection
    '    Dim dar As MySqlConnector.MySqlDataAdapter
    '    Dim dsr As New DataSet

    '    Try
    '        dattime = DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text) & " " & cboHour.Text.PadLeft(2, "0") & ":00:00"

    '        If DateDiff("h", Now(), dattime) >= 0 Then
    '            MsgBox("Observations for future date not allowed")
    '            txtBoxesDisable()
    '            Return False
    '        Else
    '            txtBoxesEnable()
    '        End If

    '    Catch x1 As Exception
    '        Return False
    '    End Try

    '    Try
    '        myConnectionString = frmLogin.txtusrpwd.Text
    '        conr.ConnectionString = myConnectionString
    '        conr.Open()

    '        stn = cboStation.SelectedValue
    '        yr = cboYear.Text 'cboYear.Text
    '        mn = cboMonth.Text
    '        dy = cboDay.Text
    '        hr = cboHour.Text

    '        If Len(stn) > 0 And Len(yr) > 0 And Len(mn) > 0 And Len(dy) > 0 And Len(hr) > 0 Then
    '            sqlrec = "select * from form_synoptic2_TDCF where stationId = '" & stn & "' and yyyy = '" & yr & "' and mm = '" & mn & "' and dd ='" & dy & "' and hh ='" & hr & "';"

    '            dar = New MySqlConnector.MySqlDataAdapter(sqlrec, conn)
    '            dsr.Clear()
    '            dar.Fill(dsr, "Records")
    '            conr.Close()
    '            If dsr.Tables("Records").Rows.Count <> 0 Then
    '                PopulateForm(dsr)
    '                btnCommit.Enabled = False
    '                btnAddNew.Enabled = True
    '                btnUpdate.Enabled = True
    '                GetRecordNo(stn, yr, mn, dy, hr)

    '                Return True
    '            Else
    '                ClearValues()
    '                btnCommit.Enabled = True
    '                btnAddNew.Enabled = False
    '                btnUpdate.Enabled = False
    '                recNumberTextBox.Text = "New Record"
    '                Return False
    '            End If
    '            'MsgBox(stn & yr & mn & dy & hr)
    '        End If

    '        conr.Close()
    '        Return False

    '    Catch ex As Exception
    '        conr.Close()
    '        Return False
    '    End Try
    'End Function


    Private Sub btnPush_Click(sender As Object, e As EventArgs) Handles btnPush.Click

        Me.Cursor = Cursors.WaitCursor
        If FldName.DataPush("form_synoptic2_TDCF") Then
            MsgBox("Data Pushed to remote server successfully")
        Else
            MsgBox("Data Push Failed!")
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub cboStation_TextChanged(sender As Object, e As EventArgs) Handles cboStation.TextChanged
        'If RecordExist() Then MsgBox(cboStation.SelectedValue)
        'If RecordExist() Then Exit Sub
        formPopulate()
    End Sub


    'Sub PopulateForm(sr As DataSet)

    '    Try
    '        With sr.Tables("Records")

    '            Dim m As Integer
    '            Dim ctl As Control

    '            For m = 5 To (valueFldsTotal + 4)
    '                For Each ctl In Me.Controls
    '                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
    '                        If Not IsDBNull(.Rows(inc).Item(m)) Then
    '                            ctl.Text = .Rows(inc).Item(m)
    '                        Else
    '                            ctl.Text = ""
    '                        End If

    '                    End If
    '                Next ctl
    '            Next m

    '            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
    '                For Each ctl In Me.Controls
    '                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
    '                        If Not IsDBNull(.Rows(inc).Item(m)) Then
    '                            ctl.Text = .Rows(inc).Item(m)
    '                        Else
    '                            ctl.Text = ""
    '                        End If

    '                    End If
    '                Next ctl
    '            Next m

    '            'Display observation units to database
    '            cboTempUnits.Text = .Rows(inc).Item("temperatureUnits")
    '            cboPrecipUnits.Text = .Rows(inc).Item("precipUnits")
    '            cboCloudheightUnits.Text = .Rows(inc).Item("cloudHeightUnits")
    '            cboVisibilityUnits.Text = .Rows(inc).Item("visUnits")
    '            cboWindSpdUnits.Text = .Rows(inc).Item("windspdUnits")

    '        End With
    '        displayRecordNumber()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Sub ClearValues()
        Dim ctl As Control

        'Clear textboxes for observation values
        'Observation values range from column 5 i.e. column index 4 to column of last value field
        For m = 5 To (valueFldsTotal + 4)
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ctl.Text = ""
                End If
                If ctl.Name = "txtVal_Elem301Field010" Then ctl.Text = FldName.RegkeyValue("key00")
            Next ctl
        Next m

        'Clear textboxes for observation flags
        'Observation flags range from column 39 i.e. column index 38 to column 73 i.e. column index 72
        For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ctl.Text = ""
                End If
            Next ctl
        Next m

        'btnCommit.Enabled = True
        'btnAddNew.Enabled = False
        'btnUpdate.Enabled = False
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboHour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHour.SelectedIndexChanged
        formPopulate()
    End Sub


    Private Sub cboMonth_TextChanged(sender As Object, e As EventArgs) Handles cboMonth.TextChanged
        'If RecordExist() Then Exit Sub
        formPopulate()
    End Sub


    Private Sub cboDay_TextChanged(sender As Object, e As EventArgs) Handles cboDay.TextChanged
        'If RecordExist() Then Exit Sub
        formPopulate()
    End Sub

    Private Sub cboYear_TextChanged(sender As Object, e As EventArgs) Handles cboYear.TextChanged
        'If RecordExist() Then Exit Sub
        formPopulate()
    End Sub

    'Sub txtBoxesDisable()

    '    Dim ctl As Control

    '    'Disable textboxes for observation values
    '    For Each ctl In Me.Controls
    '        If Strings.Left(ctl.Name, 6) = "txtVal" Then
    '            ctl.Enabled = False
    '        End If
    '    Next ctl
    'End Sub
    'Sub txtBoxesEnable()

    '    Dim ctl As Control

    '    'Enable textboxes for observation values
    '    For Each ctl In Me.Controls
    '        If Strings.Left(ctl.Name, 6) = "txtVal" Then
    '            ctl.Enabled = True
    '        End If
    '    Next ctl
    'End Sub
    'Sub shiftEntries(kycode As Integer)
    '    Select Case kycode
    '        Case 34 ' Insert
    '            insertValues()
    '            shiftFlags()
    '        Case 33 ' Delete
    '            deleteValues()
    '            shiftFlags()
    '    End Select

    'End Sub
    'Sub shiftFlags()
    '    Dim flagIndexDiff As Integer
    '    Dim ctls As Control
    '    Dim txt, flg As String

    '    If Not totalCTLS(flagIndexDiff) Then Exit Sub
    '    For Each ctls In Me.Controls
    '        If Strings.Left(ctls.Name, 6) = "txtVal" Then
    '            txt = ctls.Text
    '            flg = "txt" & "Flag" & Strings.Mid(ctls.Name, 12, 3) & "Field" & Format(Val(Strings.Right(ctls.Name, 3)) + flagIndexDiff, "000")
    '            FlagValue(ctls, txt, flg)
    '        End If
    '    Next
    'End Sub
    Sub shiftEntries(kycode As Integer)
        Select Case kycode
            Case 34 ' Insert
                insertValues()
                shiftFlags()
            Case 33 ' Delete
                deleteValues()
                shiftFlags()
        End Select

    End Sub
    Sub shiftFlags()
        Dim flagIndexDiff As Integer
        Dim ctls As Control
        Dim txt, flg As String

        If Not totalCTLS(flagIndexDiff) Then Exit Sub
        For Each ctls In Me.Controls
            If Strings.Left(ctls.Name, 6) = "txtVal" Then
                txt = ctls.Text
                flg = "txt" & "Flag" & Strings.Mid(ctls.Name, 12, 3) & "Field" & Format(Val(Strings.Right(ctls.Name, 3)) + flagIndexDiff, "000")
                FlagValue(ctls, txt, flg)
            End If
        Next
    End Sub

    Sub FlagValue(txtCTL As Control, txt As String, flg As String)
        Dim flgCTL As Control

        For Each flgCTL In Me.Controls
            If flgCTL.Name = flg Then
                If txt = "" Then
                    If txtCTL.Enabled Then flgCTL.Text = "M"
                Else
                    flgCTL.Text = ""
                End If
            End If
        Next

    End Sub
    'Sub NextBox(bx As String, ByRef nxtbox As String)
    '    Dim kount As Integer
    '    sql = "select * from form_synoptic2_TDCF;"

    '    conn.Open()
    '    da = New MySqlConnector.MySqlDataAdapter(sql, conn)
    '    ds.Clear()
    '    da.Fill(ds, "flds")
    '    conn.Close()

    '    With ds.Tables("flds")
    '        For kount = 5 To .Columns.Count - 1
    '            If .Columns(kount).ColumnName = bx Then
    '                nxtbox = .Columns(kount + 1).ColumnName
    '                nxtbox = "txt" & nxtbox & "Field" & Strings.Format(kount + 1, "000")
    '                Exit For
    '            End If
    '        Next

    '    End With

    'End Sub

    Sub insertValues()
        Dim ActvCTL, nxtCTL As Control
        Dim kount As Integer
        Dim txt1, txt2 As String

        ActvCTL = Me.ActiveControl
        txt1 = ActvCTL.Text
        If totalCTLS(kount) Then
            ActvCTL.Text = ""
            For i = 0 To kount - 2
                nxtCTL = GetNextControl(ActvCTL, True)
                If nxtCTL.Enabled = True Then
                    txt2 = nxtCTL.Text
                    nxtCTL.Text = txt1
                    If Strings.Left(nxtCTL.Name, 6) <> "txtVal" Then Exit For
                    txt1 = txt2
                End If
                'MsgBox(nxtCTL.Name)
                ActvCTL = nxtCTL
            Next
        End If
    End Sub
    Sub deleteValues()
        Dim ActvCTL, nxtCTL As Control
        Dim kount As Integer

        ActvCTL = Me.ActiveControl

        If totalCTLS(kount) Then
            For i = 0 To kount - 1
                nxtCTL = GetNextControl(ActvCTL, True)
                Do While nxtCTL.Enabled = False
                    nxtCTL = GetNextControl(nxtCTL, True)
                Loop

                If Strings.Left(nxtCTL.Name, 6) <> "txtVal" Then
                    ActvCTL.Text = ""
                    Exit For
                Else
                    ActvCTL.Text = nxtCTL.Text
                    ActvCTL = nxtCTL
                End If

            Next
        End If
    End Sub
    Function totalCTLS(ByRef kount As Integer) As Boolean
        kount = 0

        sql = "select * from form_synoptic2_TDCF;"

        Try
            conn.Open()
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "flds")
            conn.Close()

            With ds.Tables("flds")
                For i = 5 To .Columns.Count - 1
                    If Strings.Left(.Columns(i).ColumnName, 8) = "Val_Elem" Then
                        kount = kount + 1
                    End If
                Next
            End With
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function Station_Elv(stnid As String) As String

        Try
            sql = "select elevation from station where stationId = '" & stnid & "';"
            conn.Open()
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "elevation")
            conn.Close()

            Return ds.Tables("elevation").Rows(0).Item(0)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Function DateAdd_Hour(ByRef nextRec As Date, ByRef hh As Integer) As Boolean
        Dim hr, SeqMax As Integer
        Try
            hr = Int(DateAndTime.Hour(nextRec))

            sql = "select hh from seq_hour;"
            conn.Open()
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "hours")
            conn.Close()

            With ds.Tables("hours")
                SeqMax = .Rows.Count

                If SeqMax = 0 Then
                    hh = Hour(nextRec)
                    nextRec = DateAdd("d", 1, nextRec)
                    Return True
                Else
                    For i = 0 To SeqMax - 1
                        If Int(.Rows(i).Item(0)) = hr Then
                            If i < SeqMax - 1 Then
                                hh = Int(.Rows(i + 1).Item(0))
                            Else
                                hh = Int(.Rows(0).Item(0))
                                nextRec = DateAdd("d", 1, nextRec)
                            End If
                            Exit For
                        End If
                    Next
                End If
            End With

            Return True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Sub DisableTboxes()
        Dim Ctl As Control

        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Text = ""
                Ctl.Enabled = False
            End If
        Next

        btnAddNew.Enabled = False
        btnCommit.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnClear.Enabled = False

        recNumberTextBox.Text = ""

    End Sub

    Sub EnablableTboxes()
        Dim Ctl As Control
        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Enabled = True
            End If
        Next
    End Sub
    Sub GetRecordNo(stn As String, yyyy As Long, mm As Integer, dd As Integer, hh As Integer)
        Dim conn2 As New MySqlConnector.MySqlConnection
        Dim da2 As MySqlConnector.MySqlDataAdapter
        Dim ds2 As New DataSet

        Try
            conn2.ConnectionString = myConnectionString
            conn2.Open()

            sql = "SELECT * FROM form_synoptic2_tdcf"
            da2 = New MySqlConnector.MySqlDataAdapter(sql, conn2)
            ds2.Clear()
            da2.Fill(ds2, "records")
            conn2.Close()

            With ds2.Tables("records")
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("stationId") = stn And .Rows(i).Item("yyyy") = yyyy And .Rows(i).Item("mm") = mm And .Rows(i).Item("dd") = dd And .Rows(i).Item("hh") = hh Then
                        inc = i
                        'recNumberTextBox.Text = "Record " & inc + 1 & " of " & .Rows.Count + 1
                        displayRecordNumber()
                        'MsgBox(inc)
                        Exit For
                    End If
                Next
            End With

        Catch ex As Exception
            conn2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub formPopulate()
        Dim Ctl As Control
        Dim dattime, dtt As String
        Dim conn1 As New MySqlConnector.MySqlConnection
        Dim da1 As MySqlConnector.MySqlDataAdapter
        Dim ds1 As New DataSet
        Dim m As Integer

        Try

            dattime = DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text) & " " & cboHour.Text.PadLeft(2, "0") & ":00:00"
            dtt = cboYear.Text & "-" & cboMonth.Text & "-" & cboDay.Text & " " & cboHour.Text.PadLeft(2, "0") & ":00:00"

            If DateDiff("h", Now(), dattime) >= 0 Or Not IsDate(dtt) Then

                'MsgBox("Observations for future date not allowed")
                ' dissable text boxes
                DisableTboxes()
                lblInvaliDate.Text = "Invalid Date Entry! Check Values"
                lblInvaliDate.ForeColor = Color.Red
                'txtYear.Focus()
                cboYear.Focus()
                Exit Sub

            Else
                EnablableTboxes()
                lblInvaliDate.Text = ""
                'txtBoxesEnable()
            End If

        Catch x1 As Exception
            If x1.HResult <> -2147467262 Then
                MsgBox(x1.Message)
            End If
            Exit Sub
        End Try



        Try
            conn1.ConnectionString = myConnectionString
            conn1.Open()
            sql = "select * from form_synoptic2_tdcf where stationId ='" & cboStation.SelectedValue & "' and yyyy = " & cboYear.Text & " and mm = " & cboMonth.Text & " and dd = " & cboDay.Text & " and hh = " & cboHour.Text & ";"

            ds1.Clear()
            da1 = New MySqlConnector.MySqlDataAdapter(sql, conn1)
            da1.Fill(ds1, "form_synoptic2_tdcf")
            conn1.Close()


            With ds1.Tables("form_synoptic2_tdcf")
                If .Rows.Count = 0 Then

                    btnAddNew.Enabled = True
                    btnCommit.Enabled = True
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnClear.Enabled = True
                    btnMoveFirst.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMovePrevious.Enabled = False
                    btnMoveLast.Enabled = False
                    recNumberTextBox.Text = "New Record"

                Else
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                    btnClear.Enabled = False
                    btnMoveFirst.Enabled = True
                    btnMoveNext.Enabled = True
                    btnMovePrevious.Enabled = True
                    btnMoveLast.Enabled = True
                    GetRecordNo(cboStation.SelectedValue, cboYear.Text, cboMonth.Text, cboDay.Text, cboHour.Text)
                End If

                If .Rows.Count > 0 Then

                    ' Populate Values
                    For m = 5 To (valueFldsTotal + 4)
                        For Each Ctl In Me.Controls
                            If Strings.Left(Ctl.Name, 6) = "txtVal" And Val(Strings.Right(Ctl.Name, 3)) = m Then
                                If Not IsDBNull(.Rows(0).Item(m)) Then
                                    Ctl.Text = .Rows(0).Item(m)
                                Else
                                    Ctl.Text = ""
                                End If

                            End If
                        Next Ctl
                    Next m

                    ' Populate Flags
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                        For Each Ctl In Me.Controls
                            If Strings.Left(Ctl.Name, 7) = "txtFlag" And Val(Strings.Right(Ctl.Name, 3)) = m Then
                                If Not IsDBNull(.Rows(0).Item(m)) Then
                                    Ctl.Text = .Rows(0).Item(m)
                                Else
                                    Ctl.Text = ""
                                End If

                            End If
                        Next Ctl
                    Next m

                    'Display observation units to database
                    cboTempUnits.Text = .Rows(inc).Item("temperatureUnits")
                    cboPrecipUnits.Text = .Rows(inc).Item("precipUnits")
                    cboCloudheightUnits.Text = .Rows(inc).Item("cloudHeightUnits")
                    cboVisibilityUnits.Text = .Rows(inc).Item("visUnits")
                    cboWindSpdUnits.Text = .Rows(inc).Item("windspdUnits")

                Else
                    ' Clear Values
                    For i = 5 To .Columns.Count - 1
                        For Each Ctrl In Me.Controls
                            If Strings.Left(Ctrl.Name, 6) = "txtVal" And Val(Strings.Right(Ctrl.Name, 3)) = i Then
                                Ctrl.Text = ""
                            End If
                        Next
                    Next

                    ' Clear Flags
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                        For Each Ctl In Me.Controls
                            If Strings.Left(Ctl.Name, 7) = "txtFlag" And Val(Strings.Right(Ctl.Name, 3)) = m Then
                                Ctl.Text = ""
                            End If
                        Next Ctl
                    Next m

                End If
            End With

        Catch ex As Exception
            'MsgBox(ex.Message)
            'conn1.Close()
        End Try
    End Sub

    Private Sub cboYear_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedValueChanged
        formPopulate()
    End Sub

    Private Sub cboStation_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedValueChanged
        formPopulate()
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedValueChanged
        formPopulate()
    End Sub

    Private Sub cboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboDay_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedValueChanged
        formPopulate()
    End Sub

    Private Sub cboHour_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboHour.SelectedValueChanged
        formPopulate()
    End Sub

    Sub ClearTboxes()
        Dim Ctl As Control
        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Text = ""
            End If
        Next
    End Sub
End Class