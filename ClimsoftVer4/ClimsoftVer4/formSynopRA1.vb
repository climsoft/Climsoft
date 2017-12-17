' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
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

Module mainModule
    Public tabNext As Boolean
    Public regKeyName As String
    Public regKeyValue As String
    Public dsLanguageTable As New DataSet
    Public daLanguageTable As New MySql.Data.MySqlClient.MySqlDataAdapter
    Public languageTableSQL As String
    Public dsReg As New DataSet
    Public daReg As New MySql.Data.MySqlClient.MySqlDataAdapter
    Public regSQL As String
    Public dsClimsoftUserRoles As New DataSet
    Public daClimsoftUserRoles As New MySql.Data.MySqlClient.MySqlDataAdapter
    Public rolesSQL As String
    Public userGroup As String
    Public dsSourceTableName As String
    Public connStrRemoteSvr As String
    Public remoteSvr As String
    Public msgKeyentryFormsListUpdated As String
    Public msgStationInformationNotFound As String

End Module

Public Class formSynopRA1
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
    Dim valUpperLimit As String, valLowerLimit As String, stnElevation As String
    Dim obsValue As String
    Dim daSequencer As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsSequencer As New DataSet

    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        '--------------------------
        Dim stn As String
        'cboStation.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
        stn = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
        cboStation.SelectedValue = stn
        '--------------------------
        'No need to assign text value to station combobox after assigning the "SelectedValue as above. This way, the displayed value
        'will be the station name according to the "DisplayMember in the texbox attribute, hence the line below has been commented out."
        ' cboStation.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
        txtYear.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy")
        cboMonth.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
        cboDay.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
        cboHour.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")

        Dim m As Integer
        Dim ctl As Control

        'Display observation values in coressponding textboxes
        'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        'Display observation flags in coressponding textboxes
        'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
        For m = 54 To 102
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        displayRecordNumber()
    End Sub
    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId") = cboStation.SelectedValue
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy") = txtYear.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = cboMonth.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = cboDay.Text
        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = cboHour.Text

        'Update observation values in database
        'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'Update observation flags in database
        'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
        For m = 54 To 102
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "form_synoptic_2_RA1")

        'Show message for successful updating or record.
        recUpdate.messageBoxRecordedUpdated()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'The AddNew button is for the purpose of adding a new record to the DataSet and "NOT FOR ADDING A NEW RECORD TO THE DATASOURCE TABLE".
        'It is the job of the Commit button to add the new record to the datasource table.
        'On pressing the AddNew button, disable buttons for record navigation and also the buttons for deleting, updating
        'or committing a record. This means that these buttons are not required to operate at the time of adding a new record.
        'The addNew button itself should also become disabled soon after clicking it until after the newly added recorded is committed
        'to the data source table linked to the current dataset.
        'Only the Commit button should be enabled.

        ' ''First move to the last record
        ''inc = maxRows - 1
        ' ''Call subroutine for record navigation
        ''navigateRecords()

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
        Dim strYear As String
        Dim strMonth As String
        Dim strDay As String
        Dim strHour As String
        Dim k As Integer

        dataFormRecCount = ds.Tables("form_synoptic_2_RA1").Rows.Count

        If dataFormRecCount > 0 Then
            cboStation.SelectedValue = ds.Tables("form_synoptic_2_RA1").Rows(dataFormRecCount - 1).Item("stationId")
            strYear = ds.Tables("form_synoptic_2_RA1").Rows(dataFormRecCount - 1).Item("yyyy")
            strMonth = ds.Tables("form_synoptic_2_RA1").Rows(dataFormRecCount - 1).Item("mm")
            strDay = ds.Tables("form_synoptic_2_RA1").Rows(dataFormRecCount - 1).Item("dd")
            strHour = ds.Tables("form_synoptic_2_RA1").Rows(dataFormRecCount - 1).Item("hh")
        Else
            cboStation.SelectedValue = cboStation.SelectedValue
            strYear = txtYear.Text
            strMonth = cboMonth.Text
            strDay = cboDay.Text
            strHour = cboHour.Text
        End If
        'Check if year in last observation record is a leap year
        Dim yearCheck As New dataEntryGlobalRoutines
        If yearCheck.checkIsLeapYear(strYear) = True Then
            'MsgBox("Leap year!")
            Sql = "SELECT * FROM " & txtSequencer.Text & "_leap_yr"
        Else
            'MsgBox("Non leap year!")
            Sql = "SELECT * FROM " & txtSequencer.Text
        End If

        Dim dsLastDataRecord As New DataSet
        Dim daLastDataRecord As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim SQL_last_record As String, lastRecYear As String, lastRecMonth As String, lastRecHour As String, lastRecElement As String, stn As String

        SQL_last_record = "SELECT stationId,elementId,yyyy,mm,hh,signature,entryDatetime from form_synoptic_2_RA1 WHERE signature='" & frmLogin.txtUsername.Text & "' AND entryDatetime=(SELECT MAX(entryDatetime) FROM form_hourly);"
        dsLastDataRecord.Clear()
        daLastDataRecord = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL_last_record, conn)
        daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

        'Initialize header fields required for sequencer
        stn = cboStation.SelectedValue
        cboStation.SelectedValue = stn
        lastRecHour = cboDay.Text
        lastRecMonth = cboMonth.Text
        lastRecYear = txtYear.Text

        If dsLastDataRecord.Tables("lastDataRecord").Rows.Count > 0 Then
            stn = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("stationId")
            cboStation.SelectedValue = stn
            lastRecHour = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("hh")
            lastRecMonth = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("mm")
            lastRecYear = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("yyyy")
            lastRecElement = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("elementId")
        End If

        daSequencer = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        'Clear dataset of all records before filling it with new data, otherwise the dataset will keep on growing by the same number
        'of records in the recordest table whenever the AddNew button is clicked
        dsSequencer.Clear()
        daSequencer.Fill(dsSequencer, "sequencer")

        seqRecCount = dsSequencer.Tables("sequencer").Rows.Count

        'MsgBox("station: " & cboStation.SelectedValue & " yyyy: " & strYear & " mm: " & strMonth & " dd: " & strDay & " hh: " & strHour)

        For k = 0 To seqRecCount - 1
            If dsSequencer.Tables("sequencer").Rows(k).Item("mm") = lastRecMonth And dsSequencer.Tables("sequencer").Rows(k).Item("dd") = lastRecHour And _
               dsSequencer.Tables("sequencer").Rows(k).Item("hh") = lastRecHour Then
                'If it is the last day of the year and the last synoptic observation hour then increment the year by 1.
                If k = seqRecCount - 1 Then
                    'txtYear.Text = Val(txtYear.Text) + 1
                    txtYear.Text = Val(lastRecYear) + 1
                    'Check if the following is a leap year
                    If yearCheck.checkIsLeapYear(txtYear.Text) = True Then
                        txtSequencer.Text = "seq_month_day_synoptime_leap_yr"
                    Else
                        txtSequencer.Text = "seq_month_day_synoptime"
                    End If
                    cboMonth.Text = 1
                    cboDay.Text = 1
                    cboHour.Text = 0
                Else
                    txtYear.Text = strYear
                    cboMonth.Text = dsSequencer.Tables("sequencer").Rows(k + 1).Item("mm")
                    cboDay.Text = dsSequencer.Tables("sequencer").Rows(k + 1).Item("dd")
                    cboHour.Text = dsSequencer.Tables("sequencer").Rows(k + 1).Item("hh")
                End If
            End If
        Next k

        Dim m As Integer
        Dim ctl As Control
        'Clear textboxes for observation values
        'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ctl.Text = ""
                End If
            Next ctl
        Next m

        'Clear textboxes for observation values
        'Observation flags range from column 55 i.e. column index 54 to column 103 i.e. column index 102
        For m = 54 To 102
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ctl.Text = ""
                End If
            Next ctl
        Next m

        'Set record index to last record
        inc = maxRows

        'Display record position in record navigation Text Box
        recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

        'Set focus to texbox for station level pressure
        txtVal_Elem106Field005.Focus()
        '----------------------------------------
        '' ''Set SQL string for populating "regData" table
        ' ''regSQL = "SELECT keyName,keyValue FROM regkeys"     '
        ' ''daReg = New MySql.Data.MySqlClient.MySqlDataAdapter(regSQL, conn)
        ' ''daReg.Fill(dsReg, "regData")

        '----------------------------------------

        txtVal_Elem301Field010.Text = dsReg.Tables("regData").Rows(0).Item("keyValue")

        Dim tmaxHour1 As String, tmaxHour2 As String, gminStartMonth As String, gminEndMonth As String

        'Get first hour for reading tmax
        tmaxHour1 = dsReg.Tables("regData").Rows(1).Item("keyValue")
        'Get second hour for reading tmax
        tmaxHour2 = dsReg.Tables("regData").Rows(2).Item("keyValue")
        gminStartMonth = dsReg.Tables("regData").Rows(3).Item("keyValue")
        gminEndMonth = dsReg.Tables("regData").Rows(4).Item("keyValue")

        'MsgBox(tmaxHour1)

        'Check if Tmax is required
        Dim tmaxCheck As New dataEntryGlobalRoutines
        If tmaxCheck.checkTmaxRequired(cboHour.Text, tmaxHour1, tmaxHour2) = True Then
            txtVal_Elem002Field045.Enabled = True
            txtVal_Elem002Field045.BackColor = Color.White
            txtFlag002Field094.Enabled = True
            txtFlag002Field094.BackColor = Color.White
        Else
            txtVal_Elem002Field045.Enabled = False
            txtVal_Elem002Field045.BackColor = Color.LightGray
            txtFlag002Field094.Enabled = False
            txtFlag002Field094.BackColor = Color.LightGray
        End If
        'check if Tmin is required and change properties accordingly. This also applies to 24Hr precipitation and 24Hr sunshine
        Dim tminCheck As New dataEntryGlobalRoutines
        If tminCheck.checkTminRequired(cboHour.Text, tmaxHour1) = True Then
            'Apply required action to Tmin
            txtVal_Elem003Field046.Enabled = True
            txtVal_Elem003Field046.BackColor = Color.White
            txtFlag003Field095.Enabled = True
            txtFlag003Field095.BackColor = Color.White
            'Apply same action to 24Hr precip
            txtVal_Elem005Field051.Enabled = True
            txtVal_Elem005Field051.BackColor = Color.White
            txtFlag005Field100.Enabled = True
            txtFlag005Field100.BackColor = Color.White
            'Apply same action to evaporation
            txtVal_Elem018Field048.Enabled = True
            txtVal_Elem018Field048.BackColor = Color.White
            txtFlag018Field097.Enabled = True
            txtFlag018Field097.BackColor = Color.White
            'Apply same action to 24Hr sunshine
            txVal_Elem084Field049.Enabled = True
            txVal_Elem084Field049.BackColor = Color.White
            txtFlag084Field098.Enabled = True
            txtFlag084Field098.BackColor = Color.White
            'Apply same action to 24Hr radiation
            txtVal_Elem046Field053.Enabled = True
            txtVal_Elem046Field053.BackColor = Color.White
            txtFlag046Field102.Enabled = True
            txtVal_Elem046Field053.BackColor = Color.White
        Else
            txtVal_Elem003Field046.Enabled = False
            txtVal_Elem003Field046.BackColor = Color.LightGray
            txtFlag003Field095.Enabled = False
            txtFlag003Field095.BackColor = Color.LightGray
            'Apply same action to 24Hr precip
            txtVal_Elem005Field051.Enabled = False
            txtVal_Elem005Field051.BackColor = Color.LightGray
            txtFlag005Field100.Enabled = False
            txtFlag005Field100.BackColor = Color.LightGray
            'Apply same action to evaporation
            txtVal_Elem018Field048.Enabled = False
            txtVal_Elem018Field048.BackColor = Color.LightGray
            txtFlag018Field097.Enabled = False
            txtFlag018Field097.BackColor = Color.LightGray
            'Apply same action to 24Hr sunshine
            txVal_Elem084Field049.Enabled = False
            txVal_Elem084Field049.BackColor = Color.LightGray
            txtFlag084Field098.Enabled = False
            txtFlag084Field098.BackColor = Color.LightGray
            'Apply same action to 24Hr radiation
            txtVal_Elem046Field053.Enabled = False
            txtVal_Elem046Field053.BackColor = Color.LightGray
            txtFlag046Field102.Enabled = False
            txtFlag046Field102.BackColor = Color.LightGray
        End If
        'Check if Gmin is required
        Dim gminCheck As New dataEntryGlobalRoutines
        If gminCheck.checkGminRequired(cboMonth.Text, gminStartMonth, gminEndMonth, cboHour.Text) = True Then
            txtVal_Elem099Field047.Enabled = True
            txtVal_Elem099Field047.BackColor = Color.White
            txtFlag099Field096.Enabled = True
            txtFlag099Field096.BackColor = Color.White
        Else
            txtVal_Elem099Field047.Enabled = False
            txtVal_Elem099Field047.BackColor = Color.LightGray
            txtFlag099Field096.Enabled = False
            txtFlag099Field096.BackColor = Color.LightGray
        End If

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
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 _
            And Strings.Len(cboHour.Text) > 0 Then

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

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Dim n As Integer, ctl As Control, msgTxtInsufficientData As String
        n = 0
        For Each ctl In Me.Controls
            'Check if some observation values have been entered
            If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
        Next ctl

        'Check if header information is complete. If the header information is complete and there is at least one obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 _
            And Strings.Len(cboHour.Text) > 0 Then

            '-----------------------------------------
            'Carry out QC checks before saving data
            Dim objKeyPress As New dataEntryGlobalRoutines

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
            If Not objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, txtYear.Text, cboDay) Then
                cboDay.Focus()
            End If

            'Check limits
            'Dim elemCode As Integer
            For Each ctl In Me.Controls
                obsValue = ctl.Text
                If Strings.Left(ctl.Name, 6) = "txtVal" Then


                    elemCode = Val(Strings.Mid(ctl.Name, 12, 3))

                    sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit FROM obselement WHERE elementId=" & elemCode

                    daValueLimits = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlValueLimits, conn)
                    'Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                    dsValueLimits.Clear()
                    'Add row for element code associated with active control
                    daValueLimits.Fill(dsValueLimits, "obselement")

                    'Get element upper limit
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
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines
            'Try
            dsNewRow = ds.Tables("form_synoptic_2_RA1").NewRow
            'Add a new record to the data source table
            ds.Tables("form_synoptic_2_RA1").Rows.Add(dsNewRow)
            'Commit observation header information to database
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy") = txtYear.Text
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm") = cboMonth.Text
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd") = cboDay.Text
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh") = cboHour.Text

            ' txtSignature.Text = frmLogin.txtUser.Text
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

            'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
            ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("entryDatetime") = Now()

            'Commit observation values to database
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To 53
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'Commit observation flags to database
            'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
            For m = 54 To 102
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            da.Update(ds, "form_synoptic_2_RA1")

            'Display message for successful record commit to table
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

            maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
            inc = maxRows - 1

            'Call subroutine for record navigation
            navigateRecords()
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message)
            'End Try
        Else
            msgTxtInsufficientData = "Incomplete header information and insufficient observation data!"
            MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
        End If
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

        ds.Tables("form_synoptic_2_RA1").Rows(inc).Delete()
        da.Update(ds, "form_synoptic_2_RA1")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub formSynopRA1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal As String, obsFlag As String, ctrl As Control, flagtextBoxSuffix As String, flagIndexDiff As Integer
        ' Dim obsValColIndex As Integer, flagColIndex As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = 49

        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then

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

                elemCode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit FROM obselement WHERE elementId=" & elemCode
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
                ElseIf Me.ActiveControl.Name = "cboDay" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboDay.Text, cboDay)
                'Check valid day
                If tabNext = True Then
                    objKeyPress.checkValidDay(cboDay.Text, cboDay)
                End If
                If tabNext = True Then
                    objKeyPress.checkValidDate(cboDay.Text, cboMonth.Text, txtYear.Text, cboDay)
                End If
                If tabNext = True Then
                    objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, txtYear.Text, cboDay)
                End If
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
                    End If
                    objKeyPress.checkExists(itemFound, cboStation)
            Else
                ' Generate flag M for missing data for blank values
                For Each ctrl In Me.Controls
                    If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                        ctrl.Text = "M" 'obsFlag
                        Exit For
                    End If
                Next ctrl
            End If

            'if TAB next is true Activate [TAB]
            If tabNext = True Then
                My.Computer.Keyboard.SendKeys("{TAB}")
            End If

            End If

    End Sub


    Private Sub formSynopRA1_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            sql = "SELECT * FROM form_synoptic_2_RA1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_synoptic_2_RA1")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count

        '--------------------------------
        'Fill combobox for station identifier with station list from station table
        Dim m As Integer
        Dim ctl As Control
        Dim ds1 As New DataSet
        Dim sql1 As String
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        sql1 = "SELECT stationId,stationName FROM station"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

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

        ''sql1 = "SELECT stationId,stationName FROM station"
        ''da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

        '---------------------------------
        'Initialize header information for data-entry form

        If maxRows > 0 Then
            'StationIdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
            'cboStation.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
            cboStation.SelectedValue = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")

            txtYear.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("yyyy")
            cboMonth.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("mm")
            cboDay.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("dd")
            cboHour.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("hh")

            'Initialize textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To 53
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)
                        End If
                    End If
                Next ctl
            Next m

            'Initialize textboxes for observation flags
            'Observation flags range from column 54 i.e. column index 5 to column 103 i.e. column index 102
            For m = 54 To 102
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item(m)
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

    End Sub


    Private Sub txtYear_LostFocus(sender As Object, e As EventArgs) Handles txtYear.LostFocus

        ''Dim numericValueCheck As New dataEntryGlobalRoutines
        ' ''Check value is numeric
        ''numericValueCheck.checkIsNumeric(txtYear.Text, txtYear)
    End Sub

    Private Sub cboMonth_LostFocus(sender As Object, e As EventArgs) Handles cboMonth.LostFocus
        'Dim numericValueCheck As New dataEntryGlobalRoutines
        ''Check for numeric
        'numericValueCheck.checkIsNumeric(cboMonth.Text, cboMonth)

        'If IsNumeric(cboMonth.Text) And Val(cboMonth.Text) > 12 Then
        '    cboMonth.BackColor = Color.Red
        '    MsgBox("Month of or range !", MsgBoxStyle.Critical)
        'Else
        '    cboMonth.BackColor = Color.White
        'End If

    End Sub

    Private Sub Val_Elem106TextBox_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem106Field005.LostFocus

    End Sub

    Private Sub Val_Elem107TextBox_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem107Field006.LostFocus

    End Sub

    Private Sub Val_Elem003TextBox_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem003Field046.LostFocus
        ''If Val(txtVal_Elem003Field046.Text) > Val(txtVal_Elem002Field045.Text) Then
        ''    txtVal_Elem002Field045.BackColor = Color.Cyan
        ''    txtVal_Elem003Field046.BackColor = Color.Cyan
        ''    txtVal_Elem003Field046.Focus()
        ''    tabNext = False
        ''    MsgBox("Tmax must be greater or equal to Tmin!", MsgBoxStyle.Exclamation)
        ''Else
        ''    txtVal_Elem002Field045.BackColor = Color.White
        ''    txtVal_Elem003Field046.BackColor = Color.White
        ''    tabNext = True
        ''End If
    End Sub



    Private Sub Val_Elem102TextBox_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem102Field013.LostFocus
        Dim calculateValue As New dataEntryGlobalRoutines
        Dim dryBulb As String, wetBulb As String, ppp As String, gpm As String
        'Drybulb is element code 101 and wetbulb is element code 102
        Try
            If Val(txtVal_Elem102Field013.Text) > Val(txtVal_Elem101Field012.Text) Then
                'If wetbulb is greater than dewpoint both elements are flagged because either of them could be wrong.
                'i.e. wetbulb value could be higher than the correct value or drybulb could be lower than the correct value.
                txtVal_Elem101Field012.BackColor = Color.Cyan
                txtVal_Elem102Field013.BackColor = Color.Cyan
                txtVal_Elem102Field013.Focus()
                tabNext = False
                MsgBox("Drybulb must be greater or equal to Wetbulb!", MsgBoxStyle.Exclamation)
            Else
                txtVal_Elem101Field012.BackColor = Color.White
                txtVal_Elem102Field013.BackColor = Color.White
                tabNext = True
                'Apply element scale factor to drybulb and wetbulb before calling function to calculate dewpoint
                dryBulb = Val(txtVal_Elem101Field012.Text) / 10
                wetBulb = Val(txtVal_Elem102Field013.Text) / 10
                'Remove element scale factor from dewpoint
                txtVal_Elem103Field014.Text = calculateValue.calculateDewpoint(dryBulb, wetBulb) * 10

                stationCode = cboStation.SelectedValue
                ppp = Val(txtVal_Elem106Field005.Text) / 10
                ' dryBulb = Val(txtVal_Elem101Field012.Text) / 10
                gpm = txtVal_Elem301Field010.Text

                sqlStationElevation = "SELECT stationid,elevation from station WHERE stationid=" & stationCode
                daStationElevation = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlStationElevation, conn)
                'Clear all rows in dataset before filling dataset with new row record for active station
                dsStationElevation.Clear()
                'Add row for element code associated with active control
                daStationElevation.Fill(dsStationElevation, "station")
                stnElevation = dsStationElevation.Tables("station").Rows(0).Item("elevation")

                If stnElevation <> "" And txtVal_Elem106Field005.Text <> "" And txtVal_Elem101Field012.Text <> "" Then
                    'Calculate geopotential
                    txtVal_Elem196Field011.Text = calculateValue.calculateGeopotential(ppp, dryBulb, stnElevation, gpm)
                    'calculate MSL pressure
                    txtVal_Elem107Field006.Text = calculateValue.calculateMSLppp(ppp, dryBulb, stnElevation)
                End If

            End If
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try
        'dryBulb As String, 

    End Sub


    Private Sub txtVal_Elem103Field014_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem103Field014.LostFocus
        Dim RH As New dataEntryGlobalRoutines
        Dim dryBulb As String, dewPoint As String
        'Apply element scale factor to drybulb and wetbulb before calling function to calculate RH
        dryBulb = Val(txtVal_Elem101Field012.Text) / 10
        dewPoint = Val(txtVal_Elem103Field014.Text) / 10
        txtVal_Elem105Field015.Text = RH.calculateRH(dewPoint, dryBulb)
    End Sub

    Private Sub txtVal_Elem101Field012_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem101Field012.LostFocus
        ''Dim calculateGPMandMSLP As New dataEntryGlobalRoutines
        ''Dim ppp As String, dryBulb As String, gpm As String
        ''stationCode = cboStation.SelectedValue
        ''ppp = Val(txtVal_Elem106Field005.Text) / 10
        ''dryBulb = Val(txtVal_Elem101Field012.Text) / 10
        ''gpm = txtVal_Elem301Field010.Text

        ''sqlStationElevation = "SELECT stationid,elevation from station WHERE stationid=" & stationCode
        ''daStationElevation = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlStationElevation, conn)
        ' ''Clear all rows in dataset before filling dataset with new row record for active station
        ''dsStationElevation.Clear()
        ' ''Add row for element code associated with active control
        ''daStationElevation.Fill(dsStationElevation, "station")
        ''stnElevation = dsStationElevation.Tables("station").Rows(0).Item("elevation")

        ''If stnElevation <> "" And txtVal_Elem106Field005.Text <> "" And txtVal_Elem101Field012.Text <> "" Then
        ''    'Calculate geopotential
        ''    txtVal_Elem196Field011.Text = calculateGPMandMSLP.calculateGeopotential(ppp, dryBulb, stnElevation, gpm)
        ''    'calculate MSL pressure
        ''    txtVal_Elem107Field006.Text = calculateGPMandMSLP.calculateMSLppp(ppp, dryBulb, stnElevation)
        ''End If

    End Sub

    Private Sub cboDay_LostFocus(sender As Object, e As EventArgs) Handles cboDay.LostFocus

    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String, _
            dd As String, hh As String, ctl As Control, capturedBy As String
        Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String, _
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String

        Try
            myConnectionString = frmLogin.txtusrpwd.Text

            conn.ConnectionString = myConnectionString
            conn.Open()
            '
            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
            maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            obsVal = ""
            obsFlag = ""
            dataForm = "form_synoptic_2_ra1"

            'Loop through all records in dataset
            For n = 0 To maxRows - 1
                'Display progress of data transfer
                frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                frmDataTransferProgress.txtDataTransferProgress1.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table
                For m = 5 To 53
                    stnId = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(0)
                    yyyy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(1)
                    mm = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(2)
                    dd = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(3)
                    hh = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(4)
                    capturedBy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item("signature")
                    If Val(mm) < 10 Then mm = "0" & mm
                    If Val(dd) < 10 Then dd = "0" & dd
                    If Val(hh) < 10 Then hh = "0" & hh

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)) Then obsVal = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)
                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)) Then obsFlag = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)
                    'Get the element code from the control name corresponding to column index
                    For Each ctl In Me.Controls
                        If Val(Strings.Right(ctl.Name, 3)) = m Then
                            elemCode = Val(Strings.Mid(ctl.Name, 12, 3))
                        End If
                    Next ctl
                    'Generate SQL string for inserting data into observationinitial table
                    If Strings.Len(obsVal) > 0 Then
                        strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " & _
                            "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                            & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                        ' ''  strSQL = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                        ' ''"VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                        ' ''qcStatus & "," & acquisitionType & ")" & " ON DUPLICATE KEY UPDATE obsValue=" & obsVal

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
                    End If
                    'Move to next observation value in current record of the dataset
                Next m
                'Move to next record in dataset
            Next n
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Sub

    Private Sub btnUploadToMain_Click(sender As Object, e As EventArgs)
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, stnId As String, elemCode As Integer, obsDate As String, obsVal As String, obsFlag As String, _
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, yyyy As Integer, mm As String, dd As String, hh As String

        Dim ds As New DataSet
        ds.Clear()
        myConnectionString = frmLogin.txtusrpwd.Text

        conn.ConnectionString = myConnectionString
        conn.Open()

        sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType " & _
            "FROM observationInitial WHERE year(obsDateTime)=2000 AND month(obsDatetime)=1 AND day(obsDatetime)=1"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
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

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count
        'MsgBox("Number of elements: " & elemMaxRows)

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
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

            'Generate SQL string for inserting data into observationinitial table
            strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        frmImportCSV.Show()
    End Sub

    Private Sub txtVal_Elem002Field045_LostFocus(sender As Object, e As EventArgs) Handles txtVal_Elem002Field045.LostFocus

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_synoptic_2_RA1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_synoptic_2_RA1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
        Else
            sql = "SELECT * FROM form_synoptic_2_RA1 ORDER by stationId,yyyy,mm,dd,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_synopticRA1")
    End Sub

    Private Sub btnTDCF_Click(sender As Object, e As EventArgs) Handles btnTDCF.Click
        frmSynopTDCF.Show()
        frmSynopTDCF.cboTemplate.Text = "TM_307081"
        ' Subset Observations
        SubsetObservations()
    End Sub

    Sub SubsetObservations()
        Dim kount As Integer
        Try
            myConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' Get all with the same observation time to constitute the subset of stations for encoding
            sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic_2_ra1")
            kount = ds.Tables("form_synoptic_2_ra1").Rows.Count

            frmSynopTDCF.cboStation.Text = cboStation.Text
            frmSynopTDCF.txtYear.Text = txtYear.Text
            frmSynopTDCF.cboMonth.Text = cboMonth.Text
            frmSynopTDCF.cboDay.Text = cboDay.Text
            frmSynopTDCF.cboHour.Text = cboHour.Text

            ' Populate the station combo box with the stations for the subset
            For i = 0 To kount - 1
                'MsgBox(ds.Tables("form_synoptic_2_ra1").Rows(i).Item("stationId"))
                frmSynopTDCF.cboStation.Items.Add(ds.Tables("form_synoptic_2_ra1").Rows(i).Item("stationId"))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close
    End Sub
End Class
