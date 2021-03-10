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

Public Class form_upperair1

    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim elemCode As String
    Dim dsValueLimits As New DataSet
    Dim sqlValueLimits As String
    Dim daValueLimits As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim valUpperLimit As String, valLowerLimit As String, stnElevation As String
    Dim obsValue As String
    Dim FldName As New dataEntryGlobalRoutines
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub form_upperair1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dbnme As String

        tabNext = True

        'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If
        'Set the record index counter to the first row
        inc = 0
        Try
            myConnectionString = frmLogin.txtusrpwd.Text

            conn.ConnectionString = myConnectionString
            conn.Open()

            sql = "SELECT * From form_upperair1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_upperair1")
            conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException

            If ex.HResult = -2147467259 Then
                ' Table does not exit
                MsgBox("Table will be created. Re-open the form")

                ' Get the current database
                frmUserManagement.CurrentDB(myConnectionString, dbnme)

                If Create_form_upperair1_table(dbnme) And Create_form_upperair1_table("mariadb_climsoft_test_db_v4") Then

                    ' Grant table access permission to the users for the created table
                    Grant_Permissions(dbnme)

                End If
            Else
                MessageBox.Show(ex.Message)
            End If
            Me.Close()
            Exit Sub

            MessageBox.Show(ex.Message)
        End Try

        Try
            maxRows = ds.Tables("form_upperair1").Rows.Count

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
                'MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If

            '---------------------------------
            'Initialize header information for data-entry form

            If maxRows > 0 Then
                cboStation.SelectedValue = ds.Tables("form_upperair1").Rows(inc).Item("stationId")

                txtYear.Text = ds.Tables("form_upperair1").Rows(inc).Item("yyyy")
                cboMonth.Text = ds.Tables("form_upperair1").Rows(inc).Item("mm")
                cboDay.Text = ds.Tables("form_upperair1").Rows(inc).Item("dd")
                cboHour.Text = ds.Tables("form_upperair1").Rows(inc).Item("hh")
                cboLevel.Text = ds.Tables("form_upperair1").Rows(inc).Item("levelName")
                'Initialize textboxes for observation values
                'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
                For m = 6 To 17
                    For Each ctl In grpData.Controls 'Me.Controls
                        'MsgBox(ctl.Name)
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_upperair1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_upperair1").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                'Initialize textboxes for observation flags
                'Observation flags range from column 54 i.e. column index 5 to column 103 i.e. column index 102
                For m = 18 To 29
                    For Each ctl In grpData.Controls ' Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_upperair1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_upperair1").Rows(inc).Item(m)
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
            'MsgBox(Me.Name)
            If FldName.Key_Entry_Mode(Me.Text) = "Double" Then chkRepeatEntry.Checked = True

        Catch ex As Exception
            If ex.HResult = "-2146233086" Then
                'MsgBox("No Element Selected!   >>> Select them at the Metadata form")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Private Sub form_upperair1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then My.Computer.Keyboard.SendKeys("{TAB}")

        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal As String, obsFlag As String, ctrl As Control, flagtextBoxSuffix As String, flagIndexDiff As Integer
        ' Dim obsValColIndex As Integer, flagColIndex As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = 12

        Try

            If e.KeyCode = Keys.Enter Then

                'Check for conflicts if Double key entry mode is set
                'objKeyPress.Key_Entry_Mode = "Double" And 

                If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    'If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    chkRepeatEntry.Checked = True

                    Dim elmcode As String
                    elmcode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    If Not objKeyPress.Entry_Verification(conn, Me, cboStation.SelectedValue, elmcode, txtYear.Text, cboMonth.Text, cboDay.Text, "06") Then
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
                    For Each ctrl In grpData.Controls 'Me.Controls
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
                    If dsValueLimits.Tables("obselement").Rows.Count > 0 Then ' Limits record available
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
                    End If

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
                    'Check valid Hour
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
                ElseIf Me.ActiveControl.Name = "cboLevel" Then
                    If Len(cboLevel.Text) = 0 Then
                        MsgBox("Level Required")
                        Exit Sub
                    End If
                Else

                    ' Generate flag M for missing data for blank values
                    For Each ctrl In grpData.Controls 'Me.Controls
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
        Catch ex As Exception
            'MsgBox(tabNext)
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Create_form_upperair1_table(db As String) As Boolean
        Dim sql As String
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Me.Cursor = Cursors.WaitCursor

        ' Create Table for upperair data is one doesn't exist
        sql = "USE `" & db & "`;  
               CREATE TABLE IF NOT EXISTS `form_upperair1` (
              `stationId` varchar(50) NOT NULL DEFAULT '',
              `yyyy` int(11) NOT NULL,
              `mm` int(11) NOT NULL,
              `dd` int(11) NOT NULL,
              `hh` int(11) NOT NULL,
              `levelName` varchar(10) NOT NULL DEFAULT '',
              `Val_Elem311` varchar(6) DEFAULT NULL,
              `Val_Elem309` varchar(6) DEFAULT NULL,
              `Val_Elem310` varchar(6) DEFAULT NULL,
              `Val_Elem301` varchar(6) DEFAULT NULL,
              `Val_Elem302` varchar(6) DEFAULT NULL,
              `Val_Elem303` varchar(6) DEFAULT NULL,
              `Val_Elem304` varchar(6) DEFAULT NULL,
              `Val_Elem305` varchar(6) DEFAULT NULL,
              `Val_Elem306` varchar(6) DEFAULT NULL,
              `Val_Elem307` varchar(6) DEFAULT NULL,
              `Val_Elem308` varchar(6) DEFAULT NULL,
              `Val_Elem312` varchar(6) DEFAULT NULL,
              `Flag311` varchar(1) DEFAULT NULL,
              `Flag309` varchar(1) DEFAULT NULL,
              `Flag310` varchar(1) DEFAULT NULL,
              `Flag301` varchar(1) DEFAULT NULL,
              `Flag302` varchar(1) DEFAULT NULL,
              `Flag303` varchar(1) DEFAULT NULL,
              `Flag304` varchar(1) DEFAULT NULL,
              `Flag305` varchar(1) DEFAULT NULL,
              `Flag306` varchar(1) DEFAULT NULL,
              `Flag307` varchar(1) DEFAULT NULL,
              `Flag308` varchar(1) DEFAULT NULL,
              `Flag312` varchar(1) DEFAULT NULL,
              `signature` varchar(45) DEFAULT NULL,
              `entryDatetime` datetime DEFAULT NULL,
              PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`,`levelName`)
            );"
        Try
            ' Create the table form_upperair1'

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()
        Catch ex As Exception
            If ex.HResult = -2147467259 Then
                MsgBox("You may not have sufficient privileges to create the table 'form_upperair1'. Please restart Climsoft as 'root'")
            Else
                MsgBox(ex.Message & " Check user privileges")
            End If
            Me.Cursor = Cursors.Default
            Return False
        End Try

        ' Modify to include level in the unique key of the observation tables

        ' Modify in current database
        sql = "USE `" & db & "`;
                   ALTER TABLE `observationinitial`
	               DROP INDEX `obsInitialIdentification`,
	               ADD UNIQUE INDEX `obsInitialIdentification` (`recordedFrom`, `describedBy`, `obsDatetime`, `qcStatus`, `acquisitionType`, `obsLevel`);"
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message & ". Failed to include obsLevel in the index in observationinitial of current database. You may do it manually ")
            Me.Cursor = Cursors.Default
            'Return False
        End Try

        ' Modify in observationinitial table of current database
        sql = "USE `" & db & "`;
                   ALTER TABLE `observationfinal`
	               DROP INDEX `obsFinalIdentification`,
	               ADD UNIQUE INDEX `obsFinalIdentification` (`recordedFrom`, `describedBy`, `obsDatetime`, `qcStatus`, `acquisitionType`, `obsLevel`);"
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message & ". Failed to include obsLevel in the index in observationfinal of current database. You may do it manually")
            Me.Cursor = Cursors.Default
            'Return False
        End Try

        ' Modify in test database
        sql = "USE `mariadb_climsoft_test_db_v4`;
                   ALTER TABLE `observationinitial`
	               DROP INDEX `obsInitialIdentification`,
	               ADD UNIQUE INDEX `obsInitialIdentification` (`recordedFrom`, `describedBy`, `obsDatetime`, `qcStatus`, `acquisitionType`, `obsLevel`);"
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message & ". Failed to include obsLevel in the index in observationinitial of test database. You may do it manually ")
            Me.Cursor = Cursors.Default
            'Return False
        End Try

        ' Modify in observationinitial table of current database
        sql = "USE `mariadb_climsoft_test_db_v4`;
                   ALTER TABLE `observationfinal`
	               DROP INDEX `obsFinalIdentification`,
	               ADD UNIQUE INDEX `obsFinalIdentification` (`recordedFrom`, `describedBy`, `obsDatetime`, `qcStatus`, `acquisitionType`, `obsLevel`);"
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message & ". Failed to include obsLevel in the index of observationfinal of test database. You may do it manually")
            Me.Cursor = Cursors.Default
            'Return False
        End Try
        Me.Cursor = Cursors.Default

        Return True
    End Function
    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
    Sub Grant_Permissions(dbnme As String)

        Dim sql, usr, usrl As String
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            sql = "use " & dbnme & "; Select userName, userRole from climsoftusers;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "ClimsoftUsers")

            With ds.Tables("ClimsoftUsers")
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1

                        usr = .Rows(i).Item(0)
                        usrl = .Rows(i).Item(1)
                        If usrl = "ClimsoftAdmin" Or usrl = "ClimsoftOperator" Or usrl = "ClimsoftRainfall" Or usrl = "ClimsoftOperatorSupervisor" Or usrl = "ClimsoftQC" Then

                            sql = "GRANT DELETE,Select,INSERT,UPDATE, CREATE On " & dbnme & ".form_upperair1 To '" & usr & "';"
                            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            'execute command
                            qry.ExecuteNonQuery()

                            sql = "GRANT DELETE,Select,INSERT,UPDATE On mariadb_climsoft_test_db_v4.form_upperair1 To  '" & usr & "';"
                            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            'execute command
                            qry.ExecuteNonQuery()
                        End If
                    Next

                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation
        navigateRecords()
    End Sub
    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        '--------------------------
        Dim stn As String
        'cboStation.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
        stn = ds.Tables("form_upperair1").Rows(inc).Item("stationId")
        cboStation.SelectedValue = stn
        '--------------------------
        'No need to assign text value to station combobox after assigning the "SelectedValue as above. This way, the displayed value
        'will be the station name according to the "DisplayMember in the texbox attribute, hence the line below has been commented out."

        txtYear.Text = ds.Tables("form_upperair1").Rows(inc).Item("yyyy")
        cboMonth.Text = ds.Tables("form_upperair1").Rows(inc).Item("mm")
        cboDay.Text = ds.Tables("form_upperair1").Rows(inc).Item("dd")
        cboHour.Text = ds.Tables("form_upperair1").Rows(inc).Item("hh")
        cboLevel.Text = ds.Tables("form_upperair1").Rows(inc).Item("levelName")

        Dim m As Integer
        Dim ctl As Control

        'Display observation values in coressponding textboxes
        'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
        For m = 6 To 17
            For Each ctl In grpData.Controls ' Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_upperair1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_upperair1").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        'Display observation flags in coressponding textboxes
        'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
        For m = 18 To 29
            For Each ctl In grpData.Controls ' Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_upperair1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("form_upperair1").Rows(inc).Item(m)
                    Else
                        ctl.Text = ""
                    End If

                End If
            Next ctl
        Next m

        displayRecordNumber()
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
        Dim strStation, strYear, strMonth, strDay, Sql As String
        Dim levlidx As Integer
        strStation = cboStation.SelectedValue
        Try
            dataFormRecCount = ds.Tables("form_upperair1").Rows.Count

            If dataFormRecCount > 0 Then
                cboStation.SelectedValue = ds.Tables("form_upperair1").Rows(dataFormRecCount - 1).Item("stationId")
                strYear = ds.Tables("form_upperair1").Rows(dataFormRecCount - 1).Item("yyyy")
                strMonth = ds.Tables("form_upperair1").Rows(dataFormRecCount - 1).Item("mm")
                strDay = ds.Tables("form_upperair1").Rows(dataFormRecCount - 1).Item("dd")
            Else
                cboStation.SelectedValue = cboStation.SelectedValue
                strYear = txtYear.Text
                strMonth = cboMonth.Text
                strDay = cboDay.Text
            End If

            Dim ctl As Control

            'Clear textboxes for observation values
            'Observation values range from column 5 i.e. column index 4 to column 38 i.e. column index 37
            For m = 6 To 17
                For Each ctl In grpData.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Clear textboxes for observation values
            'Observation flags range from column 39 i.e. column index 38 to column 73 i.e. column index 72
            For m = 18 To 29
                For Each ctl In grpData.Controls
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
                recdate = DateSerial(txtYear.Text, cboMonth.Text, cboDay.Text)
                recdate = DateAdd("d", 1, recdate)
                txtYear.Text = DateAndTime.Year(recdate)
                cboMonth.Text = DateAndTime.Month(recdate)
                cboDay.Text = DateAndTime.Day(recdate)
                txtVal_Elem311Field006.Focus()
                Exit Sub
            End If

            ' Sequencer code Ends there
            Dim dsLastDataRecord As New DataSet
            Dim daLastDataRecord As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim SQL_last_record, lastRecYear, lastRecMonth, lastRecDay, stn, lastLevel As String
            Dim nextRecDate As Date

            SQL_last_record = "SELECT stationId,yyyy,mm,dd,levelName,signature,entryDatetime from form_upperair1 WHERE signature='" & frmLogin.txtUsername.Text & "' AND entryDatetime=(SELECT MAX(entryDatetime) FROM form_upperair1);"
            dsLastDataRecord.Clear()
            daLastDataRecord = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL_last_record, conn)
            daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

            'Initialize header fields required for sequencer
            stn = cboStation.SelectedValue
            cboStation.SelectedValue = stn
            lastRecDay = cboDay.Text
            lastRecMonth = cboMonth.Text
            lastRecYear = txtYear.Text

            If dsLastDataRecord.Tables("lastDataRecord").Rows.Count > 0 Then
                stn = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("stationId")
                cboStation.SelectedValue = stn

                lastRecDay = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("dd")
                lastRecMonth = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("mm")
                lastRecYear = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("yyyy")
                lastLevel = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("levelName")

                nextRecDate = DateAdd("d", 1, DateSerial(lastRecYear, lastRecMonth, lastRecDay))

                ' Sequencing Level
                For i = 0 To cboLevel.Items.Count - 1
                    If cboLevel.Items(i) = lastLevel Then
                        levlidx = i
                        Exit For
                    End If
                Next

                If levlidx = cboLevel.Items.Count - 1 Then
                    levlidx = 0
                    txtYear.Text = DateAndTime.Year(nextRecDate)
                    cboMonth.Text = DateAndTime.Month(nextRecDate)
                    cboDay.Text = DateAndTime.Day(nextRecDate)
                Else
                    levlidx = levlidx + 1
                End If
                cboLevel.SelectedIndex = levlidx
            End If

            'Clear textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
            For m = 6 To 17
                For Each ctl In grpData.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Clear textboxes for observation flags
            'Observation flags range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = 18 To 29
                For Each ctl In grpData.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Set record index to last record
            inc = maxRows

            'Display record position in record navigation Text Box
            recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1
            txtVal_Elem311Field006.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_upperair1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * form_upperair1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_upperair1 ORDER by stationId,yyyy,mm,dd"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database
        ds.Tables("form_upperair1").Rows(inc).Item("stationId") = cboStation.SelectedValue
        ds.Tables("form_upperair1").Rows(inc).Item("yyyy") = txtYear.Text
        ds.Tables("form_upperair1").Rows(inc).Item("mm") = cboMonth.Text
        ds.Tables("form_upperair1").Rows(inc).Item("dd") = cboDay.Text

        'Update observation values in database
        'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
        For m = 6 To 17
            For Each ctl In grpData.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_upperair1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'Update observation flags in database
        'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
        For m = 18 To 29
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("form_upperair1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "form_upperair1")

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

        ds.Tables("form_upperair1").Rows(inc).Delete()
        da.Update(ds, "form_upperair1")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim n As Integer, ctl As Control
        n = 0
        For Each ctl In grpData.Controls
            'Check if some observation values have been entered
            If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
        Next ctl

        'Check if header information is complete. If the header information is complete and there is at least on obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

            'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
            'to undo the AddNew button process before the record can be committed to the datasource table linked to the DataSet.
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

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_upperair1")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmFormUpload.lblFormName.Text = "form_upperair1"
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName.Text

        frmFormUpload.Show()

    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Dim n As Integer, ctl As Control, msgTxtInsufficientData As String
        n = 0
        Try
            For Each ctl In grpData.Controls ' Me.Controls
                'Check if some observation values have been entered
                If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
            Next ctl

            'Check if header information is complete. If the header information is complete and there is at least one obs value then,
            'carry out the next actions, otherwise bring up message showing that there is insufficient data
            If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

                '-----------------------------------------
                'Carry out QC checks before saving data
                Dim objKeyPress As New dataEntryGlobalRoutines

                'Check item exists
                For Each ctl In grpHeaders.Controls ' Me.Controls
                    If ctl.Name = "cboStation" Then
                        If Not objKeyPress.checkExists(True, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check for numeric
                For Each ctl In grpHeaders.Controls ' Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "txtYear" Or ctl.Name = "cboMonth" Or ctl.Name = "cboDay" Or ctl.Name = "cboHour" _
                        Or (Strings.Left(ctl.Name, 6) = "txtVal" And Strings.Len(ctl.Text)) > 0 Then
                        If Not objKeyPress.checkIsNumeric(obsValue, Me.ActiveControl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid year
                For Each ctl In grpHeaders.Controls ' Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "txtYear" Then
                        If Not objKeyPress.checkValidYear(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid month
                For Each ctl In grpHeaders.Controls ' In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboMonth" Then
                        If Not objKeyPress.checkValidMonth(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid day
                For Each ctl In grpHeaders.Controls ' Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboDay" Then
                        If Not objKeyPress.checkValidDay(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid hour
                For Each ctl In grpHeaders.Controls ' Me.Controls
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
                For Each ctl In grpData.Controls ' Me.Controls
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
                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                Dim dsNewRow As DataRow
                'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
                Dim recCommit As New dataEntryGlobalRoutines
                'Try
                dsNewRow = ds.Tables("form_upperair1").NewRow
                'Add a new record to the data source table
                ds.Tables("form_upperair1").Rows.Add(dsNewRow)
                'Commit observation header information to database
                ds.Tables("form_upperair1").Rows(inc).Item("stationId") = cboStation.SelectedValue
                ds.Tables("form_upperair1").Rows(inc).Item("yyyy") = txtYear.Text
                ds.Tables("form_upperair1").Rows(inc).Item("mm") = cboMonth.Text
                ds.Tables("form_upperair1").Rows(inc).Item("dd") = cboDay.Text
                ds.Tables("form_upperair1").Rows(inc).Item("hh") = cboHour.Text
                ds.Tables("form_upperair1").Rows(inc).Item("levelName") = cboLevel.Text

                ' txtSignature.Text = frmLogin.txtUser.Text
                ds.Tables("form_upperair1").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

                'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
                ds.Tables("form_upperair1").Rows(inc).Item("entryDatetime") = Now()

                'Commit observation values to database
                'Observation values range from column 5 i.e. column index 4 to column 38 i.e. column index 37
                For m = 6 To 17
                    For Each ctl In grpData.Controls 'Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            ds.Tables("form_upperair1").Rows(inc).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                'Commit observation flags to database
                'Observation Flags range from column 39 i.e. column index 38 to column 72 i.e. column index 71
                For m = 18 To 29
                    For Each ctl In grpData.Controls ' Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            ds.Tables("form_upperair1").Rows(inc).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                da.Update(ds, "form_upperair1")

                ''Display message for successful record commit to table
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

                maxRows = ds.Tables("form_upperair1").Rows.Count
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

End Class