﻿'CLIMSOFT - Climate Database Management System
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

Public Class formMonthly

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
    Dim selectAllHours As Boolean
    Dim daSequencer As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsSequencer As New DataSet

    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        Dim stn As String, elem As String
        'cboStation.Text = ds.Tables("form_monthly").Rows(inc).Item("stationId")
        stn = ds.Tables("form_monthly").Rows(inc).Item("stationId")
        elem = ds.Tables("form_monthly").Rows(inc).Item("elementId")
        cboStation.SelectedValue = stn
        cboElement.SelectedValue = elem
        'cboElement.Text = ds.Tables("form_monthly").Rows(inc).Item("elementId")
        txtYear.Text = ds.Tables("form_monthly").Rows(inc).Item("yyyy")
       
        Dim m As Integer
        Dim ctl As Control

        'Display observation values in coressponding textboxes
        'Observation values start in column 4 i.e. column index 3, and end in column 15 i.e. column Index 14
        For m = 3 To 14
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_monthly").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_monthly").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        'Display observation flags in coressponding textboxes
        'Observation values start in column 16 i.e. column index 14, and end in column 27 i.e. column Index 26
        For m = 15 To 26
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_monthly").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_monthly").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        displayRecordNumber()
    End Sub
    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formHourly_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal As String, obsFlag As String, ctrl As Control, flagtextBoxSuffix As String, flagIndexDiff As Integer
        ' Dim obsValColIndex As Integer, flagColIndex As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = 12

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
            
            ElseIf Me.ActiveControl.Name = "cboStation" Then
                Dim itemFound As Boolean
                If Len(cboStation.SelectedValue) > 1 Then
                    itemFound = True
                Else
                    itemFound = False
                End If
                objKeyPress.checkExists(itemFound, cboStation)
            ElseIf Me.ActiveControl.Name = "cboElement" Then
                Dim itemFound As Boolean
                If Len(cboElement.SelectedValue) > 1 Then
                    itemFound = True
                Else
                    itemFound = False
                End If
                objKeyPress.checkExists(itemFound, cboElement)
            End If
            'if TAB next is true Activate [TAB]
            If tabNext = True Then
                My.Computer.Keyboard.SendKeys("{TAB}")
            End If
        End If

    End Sub

    Private Sub formMonthly_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim loggedInUser As String
        'loggedInUser = frmLogin.txtUser.Text

        'MsgBox(loggedInUser)

        'Set TAB next to true
        tabNext = True
        selectAllHours = False
        'Set the record index counter to the first row
        inc = 0

        'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM form_monthly"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_monthly")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("form_monthly").Rows.Count

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


        sql1 = "SELECT stationId,stationName FROM station"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

        sql3 = "SELECT elementID,elementName FROM obselement WHERE elementId BETWEEN 200 AND 299"
        da3 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql3, conn)

        da1.Fill(ds1, "station")
        'Populate station combobox
        With cboStation
            .DataSource = ds1.Tables("station")
            .DisplayMember = "stationName"
            .ValueMember = "stationId"
            .SelectedIndex = 0
        End With

        da3.Fill(ds3, "obsElem")
        'Populate station combobox
        With cboElement
            .DataSource = ds3.Tables("obsElem")
            .DisplayMember = "elementName"
            .ValueMember = "elementId"
            .SelectedIndex = 0
        End With


        'Populate dataForms
        sql2 = "SELECT val_start_position,val_end_position FROM data_forms WHERE table_name='form_monthly'"
        da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql2, conn)
        da2.Fill(ds2, "dataForms")

        i = ds2.Tables("dataForms").Rows(0).Item("val_start_position")
        j = ds2.Tables("dataForms").Rows(0).Item("val_end_position")

        'MsgBox("Value start position: " & i & " Value end position: " & j)
        '---------------------------------
        'Initialize header information for data-entry form

        If maxRows > 0 Then
            'StationIdTextBox.Text = ds.Tables("form_monthly").Rows(inc).Item("stationId")
            'cboStation.Text = ds.Tables("form_monthly").Rows(inc).Item("stationId")
            cboStation.SelectedValue = ds.Tables("form_monthly").Rows(inc).Item("stationId")

            txtYear.Text = ds.Tables("form_monthly").Rows(inc).Item("yyyy")

            'Initialize textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
            For m = i To j
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_monthly").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_monthly").Rows(inc).Item(m)
                        End If
                    End If
                Next ctl
            Next m

            'Initialize textboxes for observation flags
            'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
            For m = j + 1 To (j + 1) + 11
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_monthly").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_monthly").Rows(inc).Item(m)
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
            btnClear.Enabled = False
            btnMoveFirst.Enabled = False
            btnMoveNext.Enabled = False
            btnMovePrevious.Enabled = False
            btnMoveLast.Enabled = False

            recNumberTextBox.Text = "Record 1 of 1"
        End If

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
        navigateRecords()

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
        Dim strYear As String, k As Integer, j As Integer, stn As String, ctrl As Control

        dataFormRecCount = ds.Tables("form_monthly").Rows.Count

        ' ''If dataFormRecCount > 0 Then
        ' ''    cboStation.SelectedValue = ds.Tables("form_monthly").Rows(dataFormRecCount - 1).Item("stationId")
        ' ''    strYear = ds.Tables("form_monthly").Rows(dataFormRecCount - 1).Item("yyyy")
        ' ''    strMonth = ds.Tables("form_monthly").Rows(dataFormRecCount - 1).Item("mm")
        ' ''    strHour = ds.Tables("form_monthly").Rows(dataFormRecCount - 1).Item("hh")
        ' ''Else
        ' ''    cboStation.SelectedValue = cboStation.SelectedValue
        strYear = txtYear.Text
       

        'Clear the texboxes and comboboxes of any background colors from previous Qc operation

        For Each ctrl In Me.Controls
            If Strings.Left(ctrl.Name, 6) = "txtVal" Or ctrl.Name = "txtYear" Or ctrl.Name = "cboElement" Or ctrl.Name = "cboStation" Then
                ctrl.BackColor = Color.White
            End If
        Next ctrl

        stn = cboStation.SelectedValue
        'Assign station identifier to that of current record
        cboStation.SelectedValue = stn

        txtYear.Text = Val(txtYear.Text) + 1

        Dim m As Integer
        Dim ctl As Control
        'Clear textboxes for observation values
        'Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
        For m = 3 To 14
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ctl.Text = ""
                End If
            Next ctl
        Next m

        'Clear textboxes for observation flags
        'Observation flags range from column 30 i.e. column index 29 to column 53 i.e. column index 52
        For m = 15 To 26
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
        txtVal_01Field003.Focus()
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
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 Then

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
                If ctl.Name = "txtYear" Or (Strings.Left(ctl.Name, 6) = "txtVal" And Strings.Len(ctl.Text)) > 0 Then
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
            '===========================
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
            '===========================

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
            dsNewRow = ds.Tables("form_monthly").NewRow
            'Add a new record to the data source table
            ds.Tables("form_monthly").Rows.Add(dsNewRow)
            'Commit observation header information to database
            ds.Tables("form_monthly").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ds.Tables("form_monthly").Rows(inc).Item("elementId") = cboElement.SelectedValue
            ds.Tables("form_monthly").Rows(inc).Item("yyyy") = txtYear.Text

            ' txtSignature.Text = frmLogin.txtUser.Text
            ds.Tables("form_monthly").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

            'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
            ds.Tables("form_monthly").Rows(inc).Item("entryDatetime") = Now()

            'Commit observation values to database
            'Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
            For m = 3 To 14
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_monthly").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'Commit observation flags to database
            'Observation values range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = 15 To 28
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_monthly").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            da.Update(ds, "form_monthly")

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

            maxRows = ds.Tables("form_monthly").Rows.Count
            inc = maxRows - 1

            'Call subroutine for record navigation
            navigateRecords()
            ''Catch ex As Exception
            ''    MessageBox.Show(ex.Message)
            ''End Try
        Else
            msgTxtInsufficientData = "Incomplete header information and insufficient observation data!"
            MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
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
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 Then

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

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database
        ds.Tables("form_monthly").Rows(inc).Item("stationId") = cboStation.SelectedValue
        ds.Tables("form_monthly").Rows(inc).Item("elementid") = cboElement.SelectedValue
        ds.Tables("form_monthly").Rows(inc).Item("yyyy") = txtYear.Text
       
        'Update observation values in database
        'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
        For m = 3 To 14
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_monthly").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'Update observation flags in database
        'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
        For m = 15 To 26
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_monthly").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m
        
        'The data adapter is used to update the record in the data source table
        da.Update(ds, "form_monthly")

        'Show message for successful updating or record.
        recUpdate.messageBoxRecordedUpdated()
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

        ds.Tables("form_monthly").Rows(inc).Delete()
        da.Update(ds, "form_monthly")
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
            dd As String, hh As String, ctl As Control, capturedBy As String
        Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String, _
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String

        myConnectionString = frmLogin.txtusrpwd.Text

        conn.ConnectionString = myConnectionString
        conn.Open()
        '
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        maxRows = ds.Tables("form_monthly").Rows.Count
        qcStatus = 0
        acquisitionType = 1
        obsLevel = "surface"
        obsVal = ""
        obsFlag = ""
        dataForm = "form_monthly"

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
            frmDataTransferProgress.txtDataTransferProgress.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table
            For m = 3 To 14
                stnId = ds.Tables("form_monthly").Rows(n).Item("stationId")
                elemCode = ds.Tables("form_monthly").Rows(n).Item("elementId")
                yyyy = ds.Tables("form_monthly").Rows(n).Item("yyyy")
                mm = m - 2
                dd = 1
                hh = 6
                capturedBy = ds.Tables("form_monthly").Rows(n).Item("signature")
                If Val(mm) < 10 Then mm = "0" & mm
                If Val(dd) < 10 Then dd = "0" & dd
                If Val(hh) < 10 Then hh = "0" & hh

                obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                If Not IsDBNull(ds.Tables("form_monthly").Rows(n).Item(m)) Then obsVal = ds.Tables("form_monthly").Rows(n).Item(m)
                If Not IsDBNull(ds.Tables("form_monthly").Rows(n).Item(m + 12)) Then obsFlag = ds.Tables("form_monthly").Rows(n).Item(m + 12)

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
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_monthly"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyy;"
        Else
            sql = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnPush_Click(sender As Object, e As EventArgs) Handles btnPush.Click
        Dim tableName As String
        tableName = "form_monthly"
        frmLogin.pushKeyEntryDataToRemote(tableName)
        lblDataPushMessage.Text = msgDataPushtoRemote
        lblDataPushMessage.Refresh()
    End Sub

    Private Sub btnSetSchedule_Click(sender As Object, e As EventArgs) Handles btnSetSchedule.Click

        ' btnOK.Enabled = False
        btnSetSchedule.Text = "Timer Activated"
        btnSetSchedule.Enabled = False
        btnSetSchedule.Refresh()

        'Enable timer
        Timer1.Enabled = True
        lblTimerActivationStatus.Text = "Timer activated!"
        lblTimerActivationStatus.Refresh()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim hourNow As Integer, minuteNow As Integer, secondNow As Integer

        hourNow = Hour(Now)
        minuteNow = Minute(Now)
        secondNow = Second(Now())

        'Start processing a minute from the time the schedule is set i.e. a minute after the "schedule" button is clicked.
        'At that time the value of the variable "minute_now" will be a minute after the schedule is set.
        'The value of the minute in the "minute texbox remains the same. It will be after an hour when the value of the variable
        '"minute_now" will be equal to the value in the "minute" texbox plus 1. So the processing is repeated every hour

        'If minuteNow = Val(txtTimerStartMinute.Text) + 1 Then
        If minuteNow = Val(txtTimerStartMinute.Text) And secondNow = 0 Then
            'call subroutine for compiling and ingesting AWS data
            'compile_aws_data
            frmLogin.pushKeyEntryDataToRemote("form_monthly")
            lblDataPushMessage.Text = msgDataPushtoRemote
            lblDataPushMessage.Refresh()
        End If
    End Sub
End Class