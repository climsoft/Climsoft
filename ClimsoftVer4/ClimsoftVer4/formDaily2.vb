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


Public Class form_daily2
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    'Declare datasets required for QC
    Dim elemCode As String
    Dim dsValueLimits As New DataSet
    Dim sqlValueLimits As String
    Dim daValueLimits As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim stationCode As String
    Dim dsStationElevation As New DataSet
    Dim sqlStationElevation As String
    Dim daStationElevation As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsStationId As New DataSet
    Dim sqlStationId As String
    Dim daStationId As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim valUpperLimit As String, valLowerLimit As String, stnElevation As String, totalRequired As Integer
    Dim obsValue As String
    Dim daSequencer As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsSequencer As New DataSet
    Dim FldName As New dataEntryGlobalRoutines
    Dim objKeyPress As New dataEntryGlobalRoutines
    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        '----------------
        'Refill dataset before getting maxRows
        Try
            ds.Clear()
            sql = "SELECT * FROM form_daily2"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            da.Fill(ds, "form_daily2")

            maxRows = ds.Tables("form_daily2").Rows.Count
            ''''inc = maxRows - 1
            '----------------

            Dim stn As String, elem As String
            'cboStation.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
            stn = ds.Tables("form_daily2").Rows(inc).Item("stationId")
            elem = ds.Tables("form_daily2").Rows(inc).Item("elementId")
            cboStation.SelectedValue = stn
            cboElement.SelectedValue = elem
            'cboElement.Text = ds.Tables("form_daily2").Rows(inc).Item("elementId")
            txtYear.Text = ds.Tables("form_daily2").Rows(inc).Item("yyyy")
            cboMonth.Text = ds.Tables("form_daily2").Rows(inc).Item("mm")

            cboHour.Text = ds.Tables("form_daily2").Rows(inc).Item("hh")

            Dim m As Integer
            Dim ctl As Control

            'Display observation values in coressponding textboxes
            'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
            For m = 5 To 35
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                        Else
                            ctl.Text = ""
                        End If

                    End If
                Next ctl
            Next m

            'Display observation flags in coressponding textboxes
            'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
            For m = 36 To 66
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                        Else
                            ctl.Text = ""
                        End If

                    End If
                Next ctl
            Next m

            displayRecordNumber()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formDaily2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal As String, obsFlag As String, ctrl As Control, flagtextBoxSuffix As String, flagIndexDiff As Integer
        'Dim conflict As Boolean
        ' Dim obsValColIndex As Integer, flagColIndex As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = 31

        Try
            'If {ENTER} key is pressed
            If e.KeyCode = Keys.Enter Then

                '' Check for conflicts if Double key entry mode is set
                If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False

                    Dim dd, hh As String
                    dd = Strings.Mid(Me.ActiveControl.Name, 8, 2)
                    hh = cboHour.Text
                    If Not objKeyPress.Entry_Verification(conn, Me, cboStation.SelectedValue, cboElement.SelectedValue, txtYear.Text, cboMonth.Text, dd, hh) Then
                        MsgBox("Can't derify data")
                    End If
                End If

                If Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" And Strings.Len(Me.ActiveControl.Text) > 0 Then

                    'Check for an observation flag in the texbox for observation value.
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
                        If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                            ctrl.Text = obsFlag
                        End If
                    Next ctrl

                    'Check that numeric value has been entered for observation value
                    objKeyPress.checkIsNumeric(Me.ActiveControl.Text, Me.ActiveControl)

                    ''Get the element limits

                    elemCode = cboElement.SelectedValue
                    sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit,qcTotalRequired FROM obselement WHERE elementId=" & elemCode
                    '
                    daValueLimits = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlValueLimits, conn)
                    ' Set to unlimited timeout period
                    daValueLimits.SelectCommand.CommandTimeout = 0

                    'Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                    dsValueLimits.Clear()
                    'Add row for element code associated with active control
                    daValueLimits.Fill(dsValueLimits, "obselement")

                    obsValue = Me.ActiveControl.Text
                    'Get element lower limit
                    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                        valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
                    Else
                        valLowerLimit = ""
                    End If
                    'Get element upper limit
                    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                        valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
                    Else
                        valUpperLimit = ""
                    End If

                    'Get value for qcTotlRequired
                    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("qcTotalRequired")) Then
                        totalRequired = dsValueLimits.Tables("obselement").Rows(0).Item("qcTotalRequired")
                    Else
                        totalRequired = 0
                    End If

                    'Check lower limit
                    If obsValue <> "" And valLowerLimit <> "" And tabNext = True Then
                        objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit)
                    End If
                    'Check upper limit
                    If obsValue <> "" And valUpperLimit <> "" And tabNext = True Then
                        objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit)
                    End If
                    'MsgBox("Obs Value: " & obsValue & " Upper Limit: " & valUpperLimit & " Lower Limit: " & valLowerLimit)
                ElseIf Me.ActiveControl.Name = "txtYear" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(txtYear.Text, txtYear)
                    'Check valid year
                    If tabNext = True Then
                        objKeyPress.checkValidYear(txtYear.Text, txtYear)
                    End If
                ElseIf Me.ActiveControl.Name = "cboMonth" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboMonth.Text, cboMonth)
                    'Check valid month
                    objKeyPress.checkValidMonth(cboMonth.Text, cboMonth)
                ElseIf Me.ActiveControl.Name = "cboHour" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboHour.Text, cboHour)
                    'Check valid hour
                    objKeyPress.checkValidHour(cboHour.Text, cboHour)
                ElseIf Me.ActiveControl.Name = "cboStation" Then
                    Dim itemFound As Boolean
                    If Len(cboStation.SelectedValue) > 1 Then
                        itemFound = True
                    Else
                        itemFound = False
                        If FldName.Valid_Stn(cboStation) Then itemFound = True
                    End If
                    objKeyPress.checkExists(itemFound, cboStation)
                ElseIf Me.ActiveControl.Name = "cboElement" Then
                    Dim itemFound As Boolean
                    If Len(cboElement.SelectedValue) > 1 Then
                        itemFound = True
                    Else
                        itemFound = False
                        If FldName.Valid_Elm(cboElement) Then itemFound = True
                    End If
                    objKeyPress.checkExists(itemFound, cboElement)
                Else
                    ' Generate flag M for missing data for blank values
                    For Each ctrl In Me.Controls
                        If Strings.Mid(ctrl.Name, 4, 4) <> "Flag" Then Continue For
                        If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                            ctrl.Text = "M" 'obsFlag
                        End If
                    Next ctrl

                End If
                'if TAB next is true Activate [TAB]
                If tabNext = True Then
                    My.Computer.Keyboard.SendKeys("{TAB}")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub formDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim loggedInUser As String
        'loggedInUser = frmLogin.txtUser.Text

        'MsgBox(loggedInUser)

        'Set TAB next to true
        tabNext = True
        'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If
        'Set the record index counter to the first row
        inc = 0

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM form_daily2"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            da.Fill(ds, "form_daily2")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("form_daily2").Rows.Count

        Try
            '--------------------------------
            'Fill combobox for station identifier with station list from station table
            Dim m As Integer, i As Integer, j As Integer
            Dim ctl As Control
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet
            Dim ds3 As New DataSet
            Dim sql1 As String, sql2 As String, sql3 As String
            Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim da2 As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim da3 As MySql.Data.MySqlClient.MySqlDataAdapter

            sql1 = "SELECT stationId,stationName FROM station ORDER BY stationName;"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            ' Set to unlimited timeout period
            da1.SelectCommand.CommandTimeout = 0

            'sql3 = "SELECT elementID,elementName FROM obselement ORDER BY elementName;"
            sql3 = "SELECT elementID,elementName FROM obselement where Selected = '1' ORDER BY elementName;"
            da3 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql3, conn)
            ' Set to unlimited timeout period
            da3.SelectCommand.CommandTimeout = 0

            da1.Fill(ds1, "station")
            If ds1.Tables("station").Rows.Count > 0 Then
                'Populate station combobox
                With cboStation
                    .DataSource = ds1.Tables("station")
                    .DisplayMember = "stationName"
                    .ValueMember = "stationId"
                    .SelectedIndex = 0
                End With
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If
            da3.Fill(ds3, "obsElem")
            'Populate station combobox
            With cboElement
                .DataSource = ds3.Tables("obsElem")
                .DisplayMember = "elementName"
                .ValueMember = "elementId"
                .SelectedIndex = 0

            End With

            'Populate dataForms
            sql2 = "SELECT val_start_position,val_end_position FROM data_forms WHERE table_name='form_daily2'"
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql2, conn)
            ' Set to unlimited timeout period
            da2.SelectCommand.CommandTimeout = 0

            da2.Fill(ds2, "dataForms")
            i = ds2.Tables("dataForms").Rows(0).Item("val_start_position")
            j = ds2.Tables("dataForms").Rows(0).Item("val_end_position")

            'MsgBox("Value start position: " & i & " Value end position: " & j)
            '---------------------------------
            'Initialize header information for data-entry form

            If maxRows > 0 Then
                'StationIdTextBox.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
                'cboStation.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
                cboStation.SelectedValue = ds.Tables("form_daily2").Rows(inc).Item("stationId")

                txtYear.Text = ds.Tables("form_daily2").Rows(inc).Item("yyyy")
                cboMonth.Text = ds.Tables("form_daily2").Rows(inc).Item("mm")
                cboHour.Text = ds.Tables("form_daily2").Rows(inc).Item("hh")

                'Initialize textboxes for observation values
                'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
                For m = i To j
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                'Initialize textboxes for observation flags
                'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
                For m = j + 1 To (j + 1) + 30
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                'Initialize textboxes for observation periods
                'Observation flags range from column 68 i.e. column index 67 to column 98 i.e. column index 97
                For m = 67 To 97
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 9) = "txtPeriod" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
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

            ' Retrieve Keyentry mode information and mark on the checkbox
            If FldName.Key_Entry_Mode(Me.Name) = "Double" Then chkRepeatEntry.Checked = True

        Catch ex As Exception
            If ex.HResult = "-2146233086" Then
                MsgBox("No Element Selected!   >>> Select them at the Metadata form")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnAssignSameValue_Click(sender As Object, e As EventArgs) Handles btnAssignSameValue.Click
        Dim ctl As Control
        For Each ctl In Me.Controls
            If Strings.Left(ctl.Name, 6) = "txtVal" And ctl.Enabled = True Then
                ctl.Text = txtSameValue.Text
            End If
        Next ctl
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'The AddNew button is for the purpose of adding a new record to the DataSet and "NOT FOR ADDING A NEW RECORD TO THE DATASOURCE TABLE".
        'It is the job of the Commit button to add the new record to the datasource table.
        'On pressing the AddNew button, disable buttons for record navigation and also the buttons for deleting, updating
        'or committing a record. This means that these buttons are not required to operate at the time of adding a new record.
        'The addNew button itself should also become disabled soon after clicking it until after the newly added recorded is committed
        'to the data source table linked to the current dataset.
        'Only the Commit button should be enabled.

        'First move to the last record
        '
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation

        'navigateRecords()

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True
        'cboStation.Text = ""
        'Dim stnIdentifier As String

        Dim Sql As String
        Dim seqRecCount As Integer
        Dim dataFormRecCount As Integer
        Dim strYear As String, k As Integer, j As Integer
        Dim CurrentDate, NextDate As Date

        dataFormRecCount = ds.Tables("form_daily2").Rows.Count

        ' ''If dataFormRecCount > 0 Then
        ' ''    cboStation.SelectedValue = ds.Tables("form_daily2").Rows(dataFormRecCount - 1).Item("stationId")
        ' ''    strYear = ds.Tables("form_daily2").Rows(dataFormRecCount - 1).Item("yyyy")
        ' ''    strMonth = ds.Tables("form_daily2").Rows(dataFormRecCount - 1).Item("mm")
        ' ''    strHour = ds.Tables("form_daily2").Rows(dataFormRecCount - 1).Item("hh")
        ' ''Else
        ' ''    cboStation.SelectedValue = cboStation.SelectedValue
        strYear = txtYear.Text

        ' ''    strMonth = cboMonth.Text
        ' ''    strHour = cboHour.Text
        ' ''End If
        ' Don't use Sequencer to fill the form header text boxes if in Double Key Entry i.e. Repeat Entry Mode
        Try
            If chkRepeatEntry.Checked Then
                Dim recdate As Date
                ' Enable AddNew button and Diable Save button
                btnAddNew.Enabled = True
                btnCommit.Enabled = False
                ' Compute the new header entries for the next record
                recdate = DateSerial(txtYear.Text, cboMonth.Text, 1)
                recdate = DateAdd("m", 1, recdate)
                txtYear.Text = DateAndTime.Year(recdate)
                cboMonth.Text = DateAndTime.Month(recdate)
                'cboDay.Text = DateAndTime.Day(recdate)
                'Exit Sub
            Else

                'End If


                'Check if year in last observation record is a leap year
                Dim yearCheck As New dataEntryGlobalRoutines
                If yearCheck.checkIsLeapYear(strYear) = True And cboMonth.Text = 2 Then
                    'MsgBox("Leap year!")
                    txtVal_29Field033.Enabled = True
                    txtFlag29Field064.Enabled = True
                    txtPeriod29Field095.Enabled = True
                    txtVal_30Field034.Enabled = False
                    txtFlag30Field065.Enabled = False
                    txtPeriod30Field096.Enabled = False
                    txtVal_31Field035.Enabled = False
                    txtFlag31Field066.Enabled = False
                    txtPeriod31Field097.Enabled = False
                ElseIf yearCheck.checkIsLeapYear(strYear) = False And cboMonth.Text = 2 Then
                    'MsgBox("Non leap year!")
                    txtVal_29Field033.Enabled = False
                    txtFlag29Field064.Enabled = False
                    txtPeriod29Field095.Enabled = False
                    txtVal_30Field034.Enabled = False
                    txtFlag30Field065.Enabled = False
                    txtPeriod30Field096.Enabled = False
                    txtVal_31Field035.Enabled = False
                    txtFlag31Field066.Enabled = False
                    txtPeriod31Field097.Enabled = False
                ElseIf cboMonth.Text = 4 Or cboMonth.Text = 6 Or cboMonth.Text = 9 Or cboMonth.Text = 11 Then
                    txtVal_29Field033.Enabled = True
                    txtFlag29Field064.Enabled = True
                    txtPeriod29Field095.Enabled = True
                    txtVal_30Field034.Enabled = True
                    txtFlag30Field065.Enabled = True
                    txtPeriod30Field096.Enabled = True
                    txtVal_31Field035.Enabled = False
                    txtFlag31Field066.Enabled = False
                    txtPeriod31Field097.Enabled = False
                Else
                    txtVal_29Field033.Enabled = True
                    txtFlag29Field064.Enabled = True
                    txtPeriod29Field095.Enabled = True
                    txtVal_30Field034.Enabled = True
                    txtFlag30Field065.Enabled = True
                    txtPeriod30Field096.Enabled = True
                    txtVal_31Field035.Enabled = True
                    txtFlag31Field066.Enabled = True
                    txtPeriod31Field097.Enabled = True
                End If

                '----------------Code block added 20160419. ASM
                'Try
                Dim dsLastDataRecord As New DataSet
                Dim daLastDataRecord As MySql.Data.MySqlClient.MySqlDataAdapter
                Dim SQL_last_record As String, stn As String, lastRecElement As String

                SQL_last_record = "SELECT stationId,elementId,yyyy,mm,hh,signature,entryDatetime from form_daily2 WHERE signature='" & frmLogin.txtUsername.Text & "' AND entryDatetime=(SELECT MAX(entryDatetime) FROM form_daily2);"
                dsLastDataRecord.Clear()
                daLastDataRecord = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL_last_record, conn)
                ' Set to unlimited timeout period
                daLastDataRecord.SelectCommand.CommandTimeout = 0

                daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

                txtSameValue.Text = ""
                lastRecElement = cboElement.SelectedValue
                stn = cboStation.SelectedValue
                cboStation.SelectedValue = stn

                If dsLastDataRecord.Tables("lastDataRecord").Rows.Count > 0 Then
                    stn = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("stationId")
                    cboStation.SelectedValue = stn
                    lastRecElement = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("elementId")
                End If

                If chkEnableSequencer.Checked = True Then
                    Sql = "SELECT * FROM " & txtSequencer.Text
                    daSequencer = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
                    'Clear dataset of all records before filling it with new data, otherwise the dataset will keep on growing by the same number
                    'of records in the recordest table whenever the AddNew button is clicked
                    dsSequencer.Clear()
                    daSequencer.Fill(dsSequencer, "sequencer")

                    seqRecCount = dsSequencer.Tables("sequencer").Rows.Count

                    'j = cboElement.SelectedValue
                    ' MsgBox("Last rec: stn=" & stn & ",elem=" & lastRecElement)

                    For k = 0 To seqRecCount - 1
                        If dsSequencer.Tables("sequencer").Rows(k).Item("elementId") = lastRecElement Then
                            If (k + 1) <= seqRecCount - 1 Then
                                cboElement.SelectedValue = dsSequencer.Tables("sequencer").Rows(k + 1).Item("elementId")
                            Else
                                cboElement.SelectedValue = dsSequencer.Tables("sequencer").Rows(0).Item("elementId")

                                ' Sequence the next date for data entry
                                CurrentDate = "1/" & cboMonth.Text & "/" & txtYear.Text

                                NextDate = DateAdd("m", 1, CurrentDate)

                                ' Populate date text boxes with values for the next expected record
                                txtYear.Text = NextDate.Year
                                cboMonth.Text = NextDate.Month
                            End If
                        End If
                    Next k
                End If

            End If ' Sequencing

            Dim m As Integer
            Dim ctl As Control
            'Clear textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 36 i.e. column index 35
            For m = 5 To 35
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Clear textboxes for observation flags
            'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
            For m = 36 To 66
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m
            'Clear textboxes for observation periods
            'Observation flags range from column 68 i.e. column index 67 to column 98 i.e. column index 97
            For m = 67 To 97
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 9) = "txtPeriod" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m
            'Clear Total check box
            txtTotal.Text = ""
            txtTotal.BackColor = Color.White

            'Set record index to last record
            inc = maxRows


            'Display record position in record navigation Text Box
            recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

            'Set focus to texbox for station level pressure
            txtVal_01Field005.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '----------------------------------------
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Dim n As Integer, ctl As Control, msgTxtInsufficientData As String
        n = 0
        For Each ctl In Me.Controls
            'Check if some observation values have been entered
            If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
        Next ctl

        'Check if header information is complete. If the header information is complete and there is at least on obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboHour.Text) > 0 Then

            '-----------------------------------------
            'Carry out QC checks before saving data
            Dim objKeyPress As New dataEntryGlobalRoutines

            'Check item exists
            For Each ctl In Me.Controls
                If ctl.Name = "cboStation" Or ctl.Name = "cboElement" Then
                    If Not objKeyPress.checkExists(True, ctl) Then
                        ctl.Focus()
                    End If
                End If
            Next ctl

            'Check for numeric
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If ctl.Name = "txtYear" Or ctl.Name = "cboMonth" Or ctl.Name = "cboHour" Or (Strings.Left(ctl.Name, 6) = "txtVal" _
                   And Strings.Len(ctl.Text)) > 0 Then
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

            'Check valid hour
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If ctl.Name = "cboHour" Then
                    If Not objKeyPress.checkValidHour(obsValue, ctl) Then
                        ctl.Focus()
                    End If
                End If
            Next ctl
            '----------------------------
            ''Get the element limits

            elemCode = cboElement.SelectedValue
            sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit,qcTotalRequired FROM obselement WHERE elementId=" & elemCode
            '
            daValueLimits = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlValueLimits, conn)
            'Clear all rows in dataset before filling dataset with new row record for element code associated with active control
            dsValueLimits.Clear()
            'Add row for element code associated with active control
            daValueLimits.Fill(dsValueLimits, "obselement")

            obsValue = Me.ActiveControl.Text
            'Get element lower limit
            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
            Else
                valLowerLimit = ""
            End If
            'Get element upper limit
            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
            Else
                valUpperLimit = ""
            End If

            'Get value for qcTotlRequired
            totalRequired = dsValueLimits.Tables("obselement").Rows(0).Item("qcTotalRequired")
            '----------------------------
            'Check future date
            Dim obsDay As String
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If Strings.Left(ctl.Name, 6) = "txtVal" And ctl.Text <> "" Then
                    obsDay = Strings.Mid(ctl.Name, 8, 2)
                    If Not objKeyPress.checkFutureDate(obsDay, cboMonth.Text, txtYear.Text, ctl) Then
                        ctl.Focus()
                    End If
                End If
            Next ctl

            'Check upper limit
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If Strings.Left(ctl.Name, 6) = "txtVal" And ctl.Text <> "" And valUpperLimit <> "" Then
                    If Not objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit) Then
                        ctl.Focus()
                    End If
                End If
            Next ctl

            'Check lower limit
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If Strings.Left(ctl.Name, 6) = "txtVal" And ctl.Text <> "" And valLowerLimit <> "" Then

                    If Not objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit) Then
                        ctl.Focus()
                    End If
                End If
            Next ctl

            ' MsgBox("Total Required=" & totalRequired)

            'Check total if required
            If totalRequired = 1 Then
                Dim elemTotal As Integer, expectedTotal As Integer, msgTextWrongTotal As String
                expectedTotal = Val(txtTotal.Text)
                elemTotal = 0
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And ctl.Text <> "" Then
                        elemTotal = elemTotal + Val(ctl.Text)
                    End If
                Next ctl
                If elemTotal <> expectedTotal Then
                    msgTextWrongTotal = "Value in [Total] textbox is different from that calculated by computer! (" & elemTotal & ")"
                    txtTotal.Focus()
                    txtTotal.BackColor = Color.Cyan
                    MsgBox(msgTextWrongTotal, MsgBoxStyle.Exclamation)
                End If
            End If
            '---------------------------------------
            'Confirm if you want to continue and save data from key-entry form to database table
            Dim msgTxtContinue As String
            msgTxtContinue = "Do you want to continue and commit to database table?"
            If MsgBox(msgTxtContinue, MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            ''===============================================================
            'Dim m As Integer
            ''Dim ctl As Control
            'Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            'Dim dsNewRow As DataRow
            ''Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            'Dim recCommit As New dataEntryGlobalRoutines
            'Try
            '    dsNewRow = ds.Tables("form_daily2").NewRow
            '    'Add a new record to the data source table
            '    ds.Tables("form_daily2").Rows.Add(dsNewRow)
            '    'Commit observation header information to database
            '    ds.Tables("form_daily2").Rows(inc).Item("stationId") = cboStation.SelectedValue
            '    ds.Tables("form_daily2").Rows(inc).Item("elementId") = cboElement.SelectedValue
            '    ds.Tables("form_daily2").Rows(inc).Item("yyyy") = txtYear.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("mm") = cboMonth.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("hh") = cboHour.Text

            '    ' txtSignature.Text = frmLogin.txtUser.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

            '    'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
            '    ds.Tables("form_daily2").Rows(inc).Item("entryDatetime") = Now()

            '    'Commit units to data soure table
            '    ds.Tables("form_daily2").Rows(inc).Item("temperatureUnits") = cboTemperatureUnits.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("precipUnits") = cboPrecipUnits.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("cloudheightUnits") = cboCloudheightUnits.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("visUnits") = cboVisibilityUnits.Text

            '    'Commit observation values to database
            '    'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            '    For m = 5 To 35
            '        For Each ctl In Me.Controls
            '            If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
            '                ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
            '            End If
            '        Next ctl
            '    Next m

            '    'Commit observation flags to database
            '    'Observation values range from column 37 i.e. column index 36 to column 67 i.e. column index 66
            '    For m = 36 To 66
            '        For Each ctl In Me.Controls
            '            If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
            '                ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
            '            End If
            '        Next ctl
            '    Next m

            '    'Commit observation period to database
            '    'Observation values range from column 68 i.e. column index 67 to column 98 i.e. column index 97
            '    For m = 67 To 97
            '        For Each ctl In Me.Controls
            '            If Strings.Left(ctl.Name, 9) = "txtPeriod" And Val(Strings.Right(ctl.Name, 3)) = m Then
            '                ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
            '            End If
            '        Next ctl
            '    Next m

            '    da.Update(ds, "form_daily2")

            '    'Display message for successful record commit to table
            '    recCommit.messageBoxCommit()

            '    btnAddNew.Enabled = True
            '    btnClear.Enabled = False
            '    btnCommit.Enabled = False
            '    btnDelete.Enabled = True
            '    btnUpdate.Enabled = True
            '    btnMoveFirst.Enabled = True
            '    btnMoveLast.Enabled = True
            '    btnMoveNext.Enabled = True
            '    btnMovePrevious.Enabled = True

            '    'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
            '    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            '        btnDelete.Enabled = False
            '    End If

            '    maxRows = ds.Tables("form_daily2").Rows.Count
            '    inc = maxRows - 1

            '    'Call subroutine for record navigation
            '    navigateRecords()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try

            Dim m As Integer, i As Integer
            'Dim ctl As Control
            ''Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            ''Dim dsNewRow As DataRow

            myConnectionString = frmLogin.txtusrpwd.Text

            conn.ConnectionString = myConnectionString
            conn.Open()

            Dim strSQL As String, stnId As String, elemId As String, obsYear As String, obsMonth As String, obsHour As String, _
                obsVal(31) As String, obsFlag(31) As String, obsPeriod(31) As String, strSignature As String, strTimeStamp As String, _
                entryYear As String, entryMonth As String, entryDay As String, entryHour As String, entryMinute As String, entrySecond As String
            Dim temperatureUnits As String, precipUnits As String, visUnits As String, cloudHeightUnits As String
            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines
            'Try
            ''dsNewRow = ds.Tables("form_hourly").NewRow
            ' ''Add a new record to the data source table
            ''ds.Tables("form_hourly").Rows.Add(dsNewRow)
            ' ''Commit observation header information to database
            ''ds.Tables("form_hourly").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ''ds.Tables("form_hourly").Rows(inc).Item("elementId") = cboElement.SelectedValue
            ''ds.Tables("form_hourly").Rows(inc).Item("yyyy") = txtYear.Text
            ''ds.Tables("form_hourly").Rows(inc).Item("mm") = cboMonth.Text
            ''ds.Tables("form_hourly").Rows(inc).Item("dd") = cboDay.Text

            If Strings.Len(cboTemperatureUnits.Text) > 0 Then
                temperatureUnits = cboTemperatureUnits.Text
            Else
                temperatureUnits = ""
            End If
            '
            If Strings.Len(cboPrecipUnits.Text) > 0 Then
                precipUnits = cboPrecipUnits.Text
            Else
                precipUnits = ""
            End If
            '
            If Strings.Len(cboVisibilityUnits.Text) > 0 Then
                visUnits = cboVisibilityUnits.Text
            Else
                visUnits = ""
            End If
            '
            If Strings.Len(cboCloudheightUnits.Text) > 0 Then
                cloudHeightUnits = cboCloudheightUnits.Text
            Else
                cloudHeightUnits = ""
            End If

            stnId = cboStation.SelectedValue
            elemId = cboElement.SelectedValue
            obsYear = txtYear.Text
            obsMonth = cboMonth.Text
            obsHour = cboHour.Text
            strSignature = frmLogin.txtUsername.Text
            entryYear = Year(Now())
            entryMonth = Month(Now())
            If Val(entryMonth) < 10 Then entryMonth = "0" & entryMonth
            entryDay = DateAndTime.Day(Now())
            If Val(entryDay) < 10 Then entryDay = "0" & entryDay
            entryHour = Hour(Now())
            If Val(entryHour) < 10 Then entryHour = "0" & entryHour
            entryMinute = Minute(Now())
            If Val(entryMinute) < 10 Then entryMinute = "0" & entryMinute
            entrySecond = Second(Now())
            If Val(entrySecond) < 10 Then entrySecond = "0" & entrySecond

            strTimeStamp = entryYear & "-" & entryMonth & "-" & entryDay & " " & entryHour & ":" & entryMinute & ":" & entrySecond

            'MsgBox(strTimeStamp)

            ' '' txtSignature.Text = frmLogin.txtUser.Text
            ''ds.Tables("form_hourly").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

            ' ''Added field for timestamp to allow recording when data was entered. 20160419, ASM.
            ''ds.Tables("form_hourly").Rows(inc).Item("entryDatetime") = Now()

            'Commit observation values to database
            'Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
            For m = 5 To 35
                i = m - 5
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        'ds.Tables("form_hourly").Rows(inc).Item(m) = ctl.Text
                        If Strings.Len(ctl.Text) > 0 Then
                            obsVal(i) = ctl.Text
                        Else
                            obsVal(i) = ""
                        End If
                    End If
                Next ctl
            Next m

            'Commit observation flags to database
            'Observation values range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = 36 To 66
                i = m - 36
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        'ds.Tables("form_hourly").Rows(inc).Item(m) = ctl.Text
                        If Strings.Len(ctl.Text) > 0 Then
                            obsFlag(i) = ctl.Text
                        Else
                            obsFlag(i) = ""
                        End If
                    End If
                Next ctl
            Next m

            'Commit observation periods to database
            'Observation values range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = 67 To 97
                i = m - 67
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 9) = "txtPeriod" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        'ds.Tables("form_hourly").Rows(inc).Item(m) = ctl.Text
                        If Strings.Len(ctl.Text) > 0 Then
                            obsPeriod(i) = ctl.Text
                        Else
                            obsPeriod(i) = ""
                        End If
                    End If
                Next ctl
            Next m
            '================================
            'Generate SQL string for inserting data into observationinitial table
            '' If Strings.Len(obsVal) > 0 Then
            strSQL = "INSERT INTO form_daily2 (stationId,elementId,yyyy,mm,hh,day01,day02,day03,day04,day05,day06,day07,day08," & _
                "day09,day10,day11,day12,day13,day14,day15,day16,day17,day18,day19,day20,day21,day22,day23," & _
                "day24,day25,day26,day27,day28,day29,day30,day31,flag01,flag02,flag03,flag04,flag05,flag06,flag07,flag08," & _
                "flag09,flag10,flag11,flag12,flag13,flag14,flag15,flag16,flag17,flag18,flag19,flag20,flag21,flag22,flag23," & _
                "flag24,flag25,flag26,flag27,flag28,flag29,flag30,flag31,period01,period02,period03,period04,period05,period06," & _
                "period07,period08,period09,period10,period11,period12,period13,period14,period15,period16,period17,period18," & _
                "period19,period20,period21,period22,period23,period24,period25,period26,period27,period28,period29,period30," & _
                "period31,temperatureUnits,precipUnits,cloudHeightUnits,visUnits,signature,entryDatetime) " & _
                "VALUES ('" & stnId & "','" & elemId & "','" & obsYear & "','" & obsMonth & "','" & obsHour & "','" & obsVal(0) & _
                "','" & obsVal(1) & "','" & obsVal(2) & "','" & obsVal(3) & "','" & obsVal(4) & "','" & obsVal(5) & "','" & obsVal(6) & _
                "','" & obsVal(7) & "','" & obsVal(8) & "','" & obsVal(9) & "','" & obsVal(10) & "','" & obsVal(11) & _
                "','" & obsVal(12) & "','" & obsVal(13) & "','" & obsVal(14) & "','" & obsVal(15) & "','" & obsVal(16) & _
                "','" & obsVal(17) & "','" & obsVal(18) & "','" & obsVal(19) & "','" & obsVal(20) & "','" & obsVal(21) & _
                "','" & obsVal(22) & "','" & obsVal(23) & "','" & obsVal(24) & "','" & obsVal(25) & "','" & obsVal(26) & _
                "','" & obsVal(27) & "','" & obsVal(28) & "','" & obsVal(29) & "','" & obsVal(30) & _
                "','" & obsFlag(0) & "','" & obsFlag(1) & "','" & obsFlag(2) & _
                "','" & obsFlag(3) & "','" & obsFlag(4) & "','" & obsFlag(5) & "','" & obsFlag(6) & "','" & obsFlag(7) & _
                "','" & obsFlag(8) & "','" & obsFlag(9) & "','" & obsFlag(10) & "','" & obsFlag(11) & "','" & obsFlag(12) & _
                "','" & obsFlag(13) & "','" & obsFlag(14) & "','" & obsFlag(15) & "','" & obsFlag(16) & "','" & obsFlag(17) & _
                "','" & obsFlag(18) & "','" & obsFlag(19) & "','" & obsFlag(20) & "','" & obsFlag(21) & "','" & obsFlag(22) & _
                "','" & obsFlag(23) & "','" & obsFlag(24) & "','" & obsFlag(25) & "','" & obsFlag(26) & "','" & obsFlag(27) & _
                "','" & obsFlag(28) & "','" & obsFlag(29) & "','" & obsFlag(30) & _
                "','" & obsPeriod(0) & "','" & obsPeriod(1) & "','" & obsPeriod(2) & _
                "','" & obsPeriod(3) & "','" & obsPeriod(4) & "','" & obsPeriod(5) & "','" & obsPeriod(6) & "','" & obsPeriod(7) & _
                "','" & obsPeriod(8) & "','" & obsPeriod(9) & "','" & obsPeriod(10) & "','" & obsPeriod(11) & "','" & obsPeriod(12) & _
                "','" & obsPeriod(13) & "','" & obsPeriod(14) & "','" & obsPeriod(15) & "','" & obsPeriod(16) & "','" & obsPeriod(17) & _
                "','" & obsPeriod(18) & "','" & obsPeriod(19) & "','" & obsPeriod(20) & "','" & obsPeriod(21) & "','" & obsPeriod(22) & _
                "','" & obsPeriod(23) & "','" & obsPeriod(24) & "','" & obsPeriod(25) & "','" & obsPeriod(26) & "','" & obsPeriod(27) & _
                "','" & obsPeriod(28) & "','" & obsPeriod(29) & "','" & obsPeriod(30) & "','" & temperatureUnits & "','" & precipUnits & _
                "','" & cloudHeightUnits & "','" & visUnits & "','" & strSignature & "','" & strTimeStamp & "')"

            ' MsgBox(strSQL)

            ' ''  strSQL = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
            ' ''"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
            ' ''qcStatus & "," & acquisitionType & ")" & " ON DUPLICATE KEY UPDATE obsValue=" & obsVal

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()

                'Display message for successful record commit to table
                'recCommit.messageBoxCommit()

                'Catch ex As MySql.Data.MySqlClient.MySqlException
                'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                conn.Close()
                Exit Sub
            End Try

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

            '============================================
            '-------------
            'Else
            '    msgTxtInsufficientData = "Incomplete header information and insufficient observation data!"
            '    MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
            'End If
            '--------------
        ElseIf n = 0 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboHour.Text) > 0 Then
            'Confirm if you want to add blank record to database table
            Dim msgTxtAddBlankRecord As String
            msgTxtAddBlankRecord = "Are you sure you want to add blank record to database table?"
            If MsgBox(msgTxtAddBlankRecord, MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
            'Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            'Dim dsNewRow As DataRow
            ''Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            'Dim recCommit As New dataEntryGlobalRoutines
            'Try
            '    dsNewRow = ds.Tables("form_daily2").NewRow
            '    'Add a new record to the data source table
            '    ds.Tables("form_daily2").Rows.Add(dsNewRow)
            '    'Commit observation header information to database
            '    ds.Tables("form_daily2").Rows(inc).Item("stationId") = cboStation.SelectedValue
            '    ds.Tables("form_daily2").Rows(inc).Item("elementId") = cboElement.SelectedValue
            '    ds.Tables("form_daily2").Rows(inc).Item("yyyy") = txtYear.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("mm") = cboMonth.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("hh") = cboHour.Text

            '    ' txtSignature.Text = frmLogin.txtUser.Text
            '    ds.Tables("form_daily2").Rows(inc).Item("signature") = frmLogin.txtUsername.Text
            '    da.Update(ds, "form_daily2")

            '    'Display message for successful record commit to table
            '    recCommit.messageBoxCommit()

            '    btnAddNew.Enabled = True
            '    btnClear.Enabled = False
            '    btnCommit.Enabled = False
            '    btnDelete.Enabled = True
            '    btnUpdate.Enabled = True
            '    btnMoveFirst.Enabled = True
            '    btnMoveLast.Enabled = True
            '    btnMoveNext.Enabled = True
            '    btnMovePrevious.Enabled = True
            '    maxRows = ds.Tables("form_daily2").Rows.Count
            '    inc = maxRows - 1

            '    'Call subroutine for record navigation
            '    navigateRecords()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try
            'Dim m As Integer, i As Integer
            'Dim ctl As Control
            ''Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            ''Dim dsNewRow As DataRow

            myConnectionString = frmLogin.txtusrpwd.Text

            conn.ConnectionString = myConnectionString
            conn.Open()

            Dim strSQL As String, stnId As String, elemId As String, obsYear As String, obsMonth As String, obsHour As String, _
                strSignature As String, strTimeStamp As String, entryYear As String, _
                entryMonth As String, entryDay As String, entryHour As String, entryMinute As String, entrySecond As String
            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines
            'Try
            ''dsNewRow = ds.Tables("form_hourly").NewRow
            ' ''Add a new record to the data source table
            ''ds.Tables("form_hourly").Rows.Add(dsNewRow)
            ' ''Commit observation header information to database
            ''ds.Tables("form_hourly").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ''ds.Tables("form_hourly").Rows(inc).Item("elementId") = cboElement.SelectedValue
            ''ds.Tables("form_hourly").Rows(inc).Item("yyyy") = txtYear.Text
            ''ds.Tables("form_hourly").Rows(inc).Item("mm") = cboMonth.Text
            ''ds.Tables("form_hourly").Rows(inc).Item("dd") = cboDay.Text

            stnId = cboStation.SelectedValue
            elemId = cboElement.SelectedValue
            obsYear = txtYear.Text
            obsMonth = cboMonth.Text
            obsHour = cboHour.Text
            strSignature = frmLogin.txtUsername.Text
            entryYear = Year(Now())
            entryMonth = Month(Now())
            If Val(entryMonth) < 10 Then entryMonth = "0" & entryMonth
            entryDay = DateAndTime.Day(Now())
            If Val(entryDay) < 10 Then entryDay = "0" & entryDay
            entryHour = Hour(Now())
            If Val(entryHour) < 10 Then entryHour = "0" & entryHour
            entryMinute = Minute(Now())
            If Val(entryMinute) < 10 Then entryMinute = "0" & entryMinute
            entrySecond = Second(Now())
            If Val(entrySecond) < 10 Then entrySecond = "0" & entrySecond

            strTimeStamp = entryYear & "-" & entryMonth & "-" & entryDay & " " & entryHour & ":" & entryMinute & ":" & entrySecond

            'MsgBox(strTimeStamp)

            'Generate SQL string for inserting data into observationinitial table
            '' If Strings.Len(obsVal) > 0 Then
            strSQL = "INSERT INTO form_daily2 (stationId,elementId,yyyy,mm,hh,signature,entryDatetime) " & _
                "VALUES ('" & stnId & "','" & elemId & "','" & obsYear & "','" & obsMonth & "','" & obsHour & "','" & strSignature & "','" & strTimeStamp & "')"

            'MsgBox(strSQL)

            ' ''  strSQL = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
            ' ''"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
            ' ''qcStatus & "," & acquisitionType & ")" & " ON DUPLICATE KEY UPDATE obsValue=" & obsVal

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()

                'Display message for successful record commit to table
                'recCommit.messageBoxCommit()

                'Catch ex As MySql.Data.MySqlClient.MySqlException
                'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                conn.Close()
                Exit Sub
            End Try

            '' Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            '' Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            ''Dim recCommit As New dataEntryGlobalRoutines
            Try
                ''dsNewRow = ds.Tables("form_hourly").NewRow
                ' ''Add a new record to the data source table
                ''ds.Tables("form_hourly").Rows.Add(dsNewRow)
                ' ''Commit observation header information to database
                ''ds.Tables("form_hourly").Rows(inc).Item("stationId") = cboStation.SelectedValue
                ''ds.Tables("form_hourly").Rows(inc).Item("elementId") = cboElement.SelectedValue
                ''ds.Tables("form_hourly").Rows(inc).Item("yyyy") = txtYear.Text
                ''ds.Tables("form_hourly").Rows(inc).Item("mm") = cboMonth.Text
                ''ds.Tables("form_hourly").Rows(inc).Item("dd") = cboDay.Text

                ' '' txtSignature.Text = frmLogin.txtUser.Text
                ''ds.Tables("form_hourly").Rows(inc).Item("signature") = frmLogin.txtUsername.Text
                ''da.Update(ds, "form_hourly")

                'Display message for successful record commit to table
                'recCommit.messageBoxCommit()

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

                maxRows = ds.Tables("form_daily2").Rows.Count
                inc = maxRows - 1

                'Call subroutine for record navigation
                navigateRecords()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                conn.Close()
                Exit Sub
            End Try
        Else
            msgTxtInsufficientData = "Incomplete header information!"
            MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
        End If
        conn.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim n As Integer, ctl As Control
        n = 0
        For Each ctl In Me.Controls
            'Check if some observation values have been entered
            If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
        Next ctl

        'Check if header information is complete. If the header information is complete and there is at least on obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboHour.Text) > 0 Then

            'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
            'to undo the AddNew button process before the recorded can be committed to the datasource table linked to the DataSet.
            'So all the buttons that were disabled after the AddNew button was clicked should be enabled back again and the Commit button
            'disabled until the AddNew button is clicked

            btnAddNew.Enabled = True
            btnCommit.Enabled = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            btnMoveFirst.Enabled = True
            btnMoveLast.Enabled = True
            btnMoveNext.Enabled = True
            btnMovePrevious.Enabled = True

            'Set Record position index to first record
            inc = 0

            'Call subroutine for record navigation
            navigateRecords()
        Else
            MsgBox("Incomplete header information and insufficient observation data!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        Try
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recUpdate As New dataEntryGlobalRoutines
            'Update header fields for form in database
            ds.Tables("form_daily2").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ds.Tables("form_daily2").Rows(inc).Item("elementid") = cboElement.SelectedValue
            ds.Tables("form_daily2").Rows(inc).Item("yyyy") = txtYear.Text
            ds.Tables("form_daily2").Rows(inc).Item("mm") = cboMonth.Text
            ds.Tables("form_daily2").Rows(inc).Item("hh") = cboHour.Text

            'Update observation values in database
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To 35
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'Update observation flags in database
            'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
            For m = 36 To 66
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m
            'Update observation Periods in database
            'Observation flags range from column 68 i.e. column index 67 to column 98 i.e. column index 97
            For m = 67 To 97
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 9) = "txtPeriod" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_daily2").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m
            'The data adapter is used to update the record in the data source table
            da.Update(ds, "form_daily2")

            'Show message for successful updating or record.
            recUpdate.messageBoxRecordedUpdated()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

            'Display message to show that delete operation has been cancelled
            recDelete.messageBoxOperationCancelled()
            Exit Sub
        End If

        ds.Tables("form_daily2").Rows(inc).Delete()
        da.Update(ds, "form_daily2")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation
        navigateRecords()
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
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noNextRec As New dataEntryGlobalRoutines
        If inc < (maxRows - 1) Then
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
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String, _
            dd As String, hh As String, capturedBy As String
        Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String, _
            obsPeriod As Integer, qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String, _
            visUnits As String, temperatureUnits As String, precipUnits As String, cloudHeightUnits As String

        myConnectionString = frmLogin.txtusrpwd.Text

        conn.ConnectionString = myConnectionString
        conn.Open()
        '
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        maxRows = ds.Tables("form_daily2").Rows.Count
        qcStatus = 0
        obsPeriod = 1
        acquisitionType = 1
        obsLevel = "surface"
        obsVal = ""
        obsFlag = ""
        dataForm = "form_daily2"
        'Try
        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table
            For m = 5 To 35
                Try
                    stnId = ds.Tables("form_daily2").Rows(n).Item("stationId")
                    elemCode = ds.Tables("form_daily2").Rows(n).Item("elementId")
                    yyyy = ds.Tables("form_daily2").Rows(n).Item("yyyy")
                    mm = ds.Tables("form_daily2").Rows(n).Item("mm")

                    temperatureUnits = ds.Tables("form_daily2").Rows(n).Item("temperatureUnits")
                    precipUnits = ds.Tables("form_daily2").Rows(n).Item("precipUnits")
                    visUnits = ds.Tables("form_daily2").Rows(n).Item("visUnits")
                    cloudHeightUnits = ds.Tables("form_daily2").Rows(n).Item("cloudHeightUnits")

                    'dd = ds.Tables("form_daily2").Rows(n).Item(3)
                    dd = m - 4
                    hh = ds.Tables("form_daily2").Rows(n).Item("hh")
                    capturedBy = ds.Tables("form_daily2").Rows(n).Item("signature")
                    If Val(mm) < 10 Then mm = "0" & mm
                    If Val(dd) < 10 Then dd = "0" & dd
                    If Val(hh) < 10 Then hh = "0" & hh

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    If Not IsDBNull(ds.Tables("form_daily2").Rows(n).Item(m)) Then obsVal = ds.Tables("form_daily2").Rows(n).Item(m)
                    If Not IsDBNull(ds.Tables("form_daily2").Rows(n).Item(m + 31)) Then obsFlag = ds.Tables("form_daily2").Rows(n).Item(m + 31)
                    If Not IsDBNull(ds.Tables("form_daily2").Rows(n).Item(m + 62)) Then obsPeriod = Val(ds.Tables("form_daily2").Rows(n).Item(m + 62))

                    'Generate SQL string for inserting data into observationinitial table
                    If Strings.Len(obsVal) > 0 Then
                        strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits) " & _
                            "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                            & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "','" & temperatureUnits & "','" & precipUnits & "','" & cloudHeightUnits & "','" & visUnits & "')"

                        ' ''  strSQL = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                        ' ''"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                        ' ''qcStatus & "," & acquisitionType & ")" & " ON DUPLICATE KEY UPDATE obsValue=" & obsVal

                        ' Create the Command for executing query and set its properties
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                        'Try
                        'Execute query
                        objCmd.ExecuteNonQuery()
                        'Catch ex As MySql.Data.MySqlClient.MySqlException
                        '    'Ignore expected error i.e. error of Duplicates in MySqlException
                    End If
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    If ex.HResult = -2147467262 Then Continue For ' When NULL values are encountered
                    MsgBox(ex.HResult & " " & ex.Message)

                End Try
                'End If
                'Move to next observation value in current record of the dataset
            Next m
            'Move to next record in dataset
        Next n
        'Catch ex1 As Exception
        '    MsgBox(ex1.HResult & " " & ex1.Message)
        'End Try
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        Set_Month_Days()
        'Dim strYear As String
        ''Check if year in last observation record is a leap year
        'Dim yearCheck As New dataEntryGlobalRoutines
        'strYear = txtYear.Text
        'If yearCheck.checkIsLeapYear(strYear) = True And cboMonth.Text = 2 Then
        '    'MsgBox("Leap year!")
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = False
        '    txtFlag30Field065.Enabled = False
        '    txtPeriod30Field096.Enabled = False
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'ElseIf yearCheck.checkIsLeapYear(strYear) = False And cboMonth.Text = 2 Then
        '    'MsgBox("Non leap year!")
        '    txtVal_29Field033.Enabled = False
        '    txtFlag29Field064.Enabled = False
        '    txtPeriod29Field095.Enabled = False
        '    txtVal_30Field034.Enabled = False
        '    txtFlag30Field065.Enabled = False
        '    txtPeriod30Field096.Enabled = False
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'ElseIf cboMonth.Text = 4 Or cboMonth.Text = 6 Or cboMonth.Text = 9 Or cboMonth.Text = 11 Then
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = True
        '    txtFlag30Field065.Enabled = True
        '    txtPeriod30Field096.Enabled = True
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'Else
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = True
        '    txtFlag30Field065.Enabled = True
        '    txtPeriod30Field096.Enabled = True
        '    txtVal_31Field035.Enabled = True
        '    txtFlag31Field066.Enabled = True
        '    txtPeriod31Field097.Enabled = True
        'End If

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_daily2"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
        Else
            sql = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_daily2")
    End Sub

    Private Sub cboElement_KeyDown(sender As Object, e As KeyEventArgs) Handles cboElement.KeyDown
        If e.KeyCode = Keys.Enter Then
            'MsgBox("ENTER Key")
            'MsgBox(cboElement.SelectedText)
            'MsgBox(cboElement.ValueMember)
        End If

    End Sub


    Private Sub txtYear_TextChanged(sender As Object, e As EventArgs) Handles txtYear.TextChanged

        Set_Month_Days()
        'Dim strYear As String
        ''Check if year in last observation record is a leap year
        'Dim yearCheck As New dataEntryGlobalRoutines

        'Try
        '    strYear = txtYear.Text
        '    If yearCheck.checkIsLeapYear(strYear) = True And cboMonth.Text = 2 Then
        '        'MsgBox("Leap year!")
        '        txtVal_29Field033.Enabled = True
        '        txtFlag29Field064.Enabled = True
        '        txtPeriod29Field095.Enabled = True
        '        txtVal_30Field034.Enabled = False
        '        txtFlag30Field065.Enabled = False
        '        txtPeriod30Field096.Enabled = False
        '        txtVal_31Field035.Enabled = False
        '        txtFlag31Field066.Enabled = False
        '        txtPeriod31Field097.Enabled = False
        '    ElseIf yearCheck.checkIsLeapYear(strYear) = False And cboMonth.Text = 2 Then
        '        'MsgBox("Non leap year!")
        '        txtVal_29Field033.Enabled = False
        '        txtFlag29Field064.Enabled = False
        '        txtPeriod29Field095.Enabled = False
        '        txtVal_30Field034.Enabled = False
        '        txtFlag30Field065.Enabled = False
        '        txtPeriod30Field096.Enabled = False
        '        txtVal_31Field035.Enabled = False
        '        txtFlag31Field066.Enabled = False
        '        txtPeriod31Field097.Enabled = False
        '    ElseIf cboMonth.Text = 4 Or cboMonth.Text = 6 Or cboMonth.Text = 9 Or cboMonth.Text = 11 Then
        '        txtVal_29Field033.Enabled = True
        '        txtFlag29Field064.Enabled = True
        '        txtPeriod29Field095.Enabled = True
        '        txtVal_30Field034.Enabled = True
        '        txtFlag30Field065.Enabled = True
        '        txtPeriod30Field096.Enabled = True
        '        txtVal_31Field035.Enabled = False
        '        txtFlag31Field066.Enabled = False
        '        txtPeriod31Field097.Enabled = False
        '    Else
        '        txtVal_29Field033.Enabled = True
        '        txtFlag29Field064.Enabled = True
        '        txtPeriod29Field095.Enabled = True
        '        txtVal_30Field034.Enabled = True
        '        txtFlag30Field065.Enabled = True
        '        txtPeriod30Field096.Enabled = True
        '        txtVal_31Field035.Enabled = True
        '        txtFlag31Field066.Enabled = True
        '        txtPeriod31Field097.Enabled = True
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboMonth_TextChanged(sender As Object, e As EventArgs) Handles cboMonth.TextChanged
        Set_Month_Days()
        'Dim strYear As String
        ''Check if year in last observation record is a leap year
        'Dim yearCheck As New dataEntryGlobalRoutines
        'strYear = txtYear.Text
        'If yearCheck.checkIsLeapYear(strYear) = True And cboMonth.Text = 2 Then
        '    'MsgBox("Leap year!")
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = False
        '    txtFlag30Field065.Enabled = False
        '    txtPeriod30Field096.Enabled = False
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'ElseIf yearCheck.checkIsLeapYear(strYear) = False And cboMonth.Text = 2 Then
        '    'MsgBox("Non leap year!")
        '    txtVal_29Field033.Enabled = False
        '    txtFlag29Field064.Enabled = False
        '    txtPeriod29Field095.Enabled = False
        '    txtVal_30Field034.Enabled = False
        '    txtFlag30Field065.Enabled = False
        '    txtPeriod30Field096.Enabled = False
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'ElseIf cboMonth.Text = 4 Or cboMonth.Text = 6 Or cboMonth.Text = 9 Or cboMonth.Text = 11 Then
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = True
        '    txtFlag30Field065.Enabled = True
        '    txtPeriod30Field096.Enabled = True
        '    txtVal_31Field035.Enabled = False
        '    txtFlag31Field066.Enabled = False
        '    txtPeriod31Field097.Enabled = False
        'Else
        '    txtVal_29Field033.Enabled = True
        '    txtFlag29Field064.Enabled = True
        '    txtPeriod29Field095.Enabled = True
        '    txtVal_30Field034.Enabled = True
        '    txtFlag30Field065.Enabled = True
        '    txtPeriod30Field096.Enabled = True
        '    txtVal_31Field035.Enabled = True
        '    txtFlag31Field066.Enabled = True
        '    txtPeriod31Field097.Enabled = True
        'End If
    End Sub
    Sub Set_Month_Days()
        Dim strYear As String
        'Check if year in last observation record is a leap year
        Dim yearCheck As New dataEntryGlobalRoutines
        Try
            strYear = txtYear.Text
            If yearCheck.checkIsLeapYear(strYear) = True And cboMonth.Text = 2 Then
                'MsgBox("Leap year!")
                txtVal_29Field033.Enabled = True
                txtFlag29Field064.Enabled = True
                txtPeriod29Field095.Enabled = True
                txtVal_30Field034.Enabled = False
                txtFlag30Field065.Enabled = False
                txtPeriod30Field096.Enabled = False
                txtVal_31Field035.Enabled = False
                txtFlag31Field066.Enabled = False
                txtPeriod31Field097.Enabled = False
            ElseIf yearCheck.checkIsLeapYear(strYear) = False And cboMonth.Text = 2 Then
                'MsgBox("Non leap year!")
                txtVal_29Field033.Enabled = False
                txtFlag29Field064.Enabled = False
                txtPeriod29Field095.Enabled = False
                txtVal_30Field034.Enabled = False
                txtFlag30Field065.Enabled = False
                txtPeriod30Field096.Enabled = False
                txtVal_31Field035.Enabled = False
                txtFlag31Field066.Enabled = False
                txtPeriod31Field097.Enabled = False
            ElseIf cboMonth.Text = 4 Or cboMonth.Text = 6 Or cboMonth.Text = 9 Or cboMonth.Text = 11 Then
                txtVal_29Field033.Enabled = True
                txtFlag29Field064.Enabled = True
                txtPeriod29Field095.Enabled = True
                txtVal_30Field034.Enabled = True
                txtFlag30Field065.Enabled = True
                txtPeriod30Field096.Enabled = True
                txtVal_31Field035.Enabled = False
                txtFlag31Field066.Enabled = False
                txtPeriod31Field097.Enabled = False
            Else
                txtVal_29Field033.Enabled = True
                txtFlag29Field064.Enabled = True
                txtPeriod29Field095.Enabled = True
                txtVal_30Field034.Enabled = True
                txtFlag30Field065.Enabled = True
                txtPeriod30Field096.Enabled = True
                txtVal_31Field035.Enabled = True
                txtFlag31Field066.Enabled = True
                txtPeriod31Field097.Enabled = True
            End If
        Catch ex As Exception
            If ex.HResult <> -2147467262 Then
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

End Class