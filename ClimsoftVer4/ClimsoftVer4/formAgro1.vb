Public Class formAgro1
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
    Dim FldName As New dataEntryGlobalRoutines
    Private Sub formAgro1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal As String, obsFlag As String, ctrl As Control, flagtextBoxSuffix As String, flagIndexDiff As Integer
        ' Dim obsValColIndex As Integer, flagColIndex As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = 34

        Try
            'If {ENTER} key is pressed
            If e.KeyCode = Keys.Enter Then

                ' Check for conflicts if Double key entry mode is set
                If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False

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


    Private Sub formAgro1_Load(sender As Object, e As EventArgs) Handles Me.Load

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


            sql = "SELECT * FROM form_agro1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "formAgro1")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Try
            maxRows = ds.Tables("formAgro1").Rows.Count

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

            'Initialize header information for data-entry form

            If maxRows > 0 Then
                cboStation.SelectedValue = ds.Tables("formAgro1").Rows(inc).Item("stationId")
                txtYear.Text = ds.Tables("formAgro1").Rows(inc).Item("yyyy")
                cboMonth.Text = ds.Tables("formAgro1").Rows(inc).Item("mm")
                cboDay.Text = ds.Tables("formAgro1").Rows(inc).Item("dd")
                
                'Initialize textboxes for observation values
                'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
                For m = 4 To 37
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("formAgro1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("formAgro1").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                'Initialize textboxes for observation flags
                'Observation flags range from column 54 i.e. column index 5 to column 103 i.e. column index 102
                For m = 38 To 71
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("formAgro1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("formAgro1").Rows(inc).Item(m)
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

        Catch ex As Exception
            If ex.HResult = "-2146233086" Then
                MsgBox("No Element Selected!   >>> Select them at the Metadata form")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
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
        'cboStation.Text = ""
        'Dim stnIdentifier As String

        'Dim Sql As String
        'Dim seqRecCount As Integer
        Dim dataFormRecCount As Integer
        Dim strYear As String
        Dim strMonth As String
        Dim strDay As String

        Try
            dataFormRecCount = ds.Tables("formAgro1").Rows.Count

            If dataFormRecCount > 0 Then
                cboStation.SelectedValue = ds.Tables("formAgro1").Rows(dataFormRecCount - 1).Item("stationId")
                strYear = ds.Tables("formAgro1").Rows(dataFormRecCount - 1).Item("yyyy")
                strMonth = ds.Tables("formAgro1").Rows(dataFormRecCount - 1).Item("mm")
                strDay = ds.Tables("formAgro1").Rows(dataFormRecCount - 1).Item("dd")
                'strHour = ds.Tables("formAgro1").Rows(dataFormRecCount - 1).Item("hh")
            Else
                cboStation.SelectedValue = cboStation.SelectedValue
                strYear = txtYear.Text
                strMonth = cboMonth.Text
                strDay = cboDay.Text

            End If

            Dim m As Integer
            Dim ctl As Control
            'Clear textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 4 To 37
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Clear textboxes for observation values
            'Observation flags range from column 55 i.e. column index 54 to column 103 i.e. column index 102
            For m = 38 To 71
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            ' Set the next data entry time to the next synoptic hour
            Dim Datehdr As DateTime

            Datehdr = DateSerial(strYear, strMonth, strDay) & " 06:00"
            Datehdr = DateAdd("h", 3, Datehdr)

            txtYear.Text = DateAndTime.Year(Datehdr)
            cboMonth.Text = DateAndTime.Month(Datehdr)
            cboDay.Text = DateAndTime.Day(Datehdr)

            'Set record index to last record
            inc = maxRows

            'Display record position in record navigation Text Box
            recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

            ''Set focus to texbox for station level pressure
            'txtVal_Elem106Field005.Focus()
            ''----------------------------------------
            ' '' ''Set SQL string for populating "regData" table
            '' ''regSQL = "SELECT keyName,keyValue FROM regkeys"     '
            '' ''daReg = New MySql.Data.MySqlClient.MySqlDataAdapter(regSQL, conn)
            '' ''daReg.Fill(dsReg, "regData")

            ''----------------------------------------
            ''Get the value for station level pressure
            'txtVal_Elem301Field010.Text = dsReg.Tables("regData").Rows(0).Item("keyValue")

            'Dim tmaxHour1 As String, tmaxHour2 As String, gminStartMonth As String, gminEndMonth As String

            ''Get first hour for reading tmax, tmin and precip 
            'tmaxHour1 = dsReg.Tables("regData").Rows(1).Item("keyValue")
            ''Get second hour for reading tmax
            'tmaxHour2 = dsReg.Tables("regData").Rows(2).Item("keyValue")
            'gminStartMonth = dsReg.Tables("regData").Rows(3).Item("keyValue")
            '' Get Month for starting recording of Gmin
            'gminEndMonth = dsReg.Tables("regData").Rows(4).Item("keyValue")

            ''MsgBox(tmaxHour1)

            ''Check if Tmax is required
            'Dim tmaxCheck As New dataEntryGlobalRoutines
            'If tmaxCheck.checkTmaxRequired(cboHour.Text, tmaxHour1, tmaxHour2) = True Then
            '    txtVal_Elem002Field045.Enabled = True
            '    txtVal_Elem002Field045.BackColor = Color.White
            '    txtFlag002Field094.Enabled = True
            '    txtFlag002Field094.BackColor = Color.White
            'Else
            '    txtVal_Elem002Field045.Enabled = False
            '    txtVal_Elem002Field045.BackColor = Color.LightGray
            '    txtFlag002Field094.Enabled = False
            '    txtFlag002Field094.BackColor = Color.LightGray
            'End If
            ''check if Tmin is required and change properties accordingly. This also applies to 24Hr precipitation and 24Hr sunshine
            'Dim tminCheck As New dataEntryGlobalRoutines
            'If tminCheck.checkTminRequired(cboHour.Text, tmaxHour1) = True Then
            '    'Apply required action to Tmin
            '    txtVal_Elem003Field046.Enabled = True
            '    txtVal_Elem003Field046.BackColor = Color.White
            '    txtFlag003Field095.Enabled = True
            '    txtFlag003Field095.BackColor = Color.White
            '    'Apply same action to 24Hr precip
            '    txtVal_Elem005Field051.Enabled = True
            '    txtVal_Elem005Field051.BackColor = Color.White
            '    txtFlag005Field100.Enabled = True
            '    txtFlag005Field100.BackColor = Color.White
            '    'Apply same action to evaporation
            '    txtVal_Elem018Field048.Enabled = True
            '    txtVal_Elem018Field048.BackColor = Color.White
            '    txtFlag018Field097.Enabled = True
            '    txtFlag018Field097.BackColor = Color.White
            '    'Apply same action to 24Hr sunshine
            '    txtVal_Elem084Field049.Enabled = True
            '    txtVal_Elem084Field049.BackColor = Color.White
            '    txtFlag084Field098.Enabled = True
            '    txtFlag084Field098.BackColor = Color.White
            '    'Apply same action to 24Hr radiation
            '    txtVal_Elem046Field053.Enabled = True
            '    txtVal_Elem046Field053.BackColor = Color.White
            '    txtFlag046Field102.Enabled = True
            '    txtFlag046Field102.BackColor = Color.White
            'Else
            '    txtVal_Elem003Field046.Enabled = False
            '    txtVal_Elem003Field046.BackColor = Color.LightGray
            '    txtFlag003Field095.Enabled = False
            '    txtFlag003Field095.BackColor = Color.LightGray
            '    'Apply same action to 24Hr precip
            '    txtVal_Elem005Field051.Enabled = False
            '    txtVal_Elem005Field051.BackColor = Color.LightGray
            '    txtFlag005Field100.Enabled = False
            '    txtFlag005Field100.BackColor = Color.LightGray
            '    'Apply same action to evaporation
            '    txtVal_Elem018Field048.Enabled = False
            '    txtVal_Elem018Field048.BackColor = Color.LightGray
            '    txtFlag018Field097.Enabled = False
            '    txtFlag018Field097.BackColor = Color.LightGray
            '    'Apply same action to 24Hr sunshine
            '    txtVal_Elem084Field049.Enabled = False
            '    txtVal_Elem084Field049.BackColor = Color.LightGray
            '    txtFlag084Field098.Enabled = False
            '    txtFlag084Field098.BackColor = Color.LightGray
            '    'Apply same action to 24Hr radiation
            '    txtVal_Elem046Field053.Enabled = False
            '    txtVal_Elem046Field053.BackColor = Color.LightGray
            '    txtFlag046Field102.Enabled = False
            '    txtFlag046Field102.BackColor = Color.LightGray
            'End If
            ''Check if Gmin is required
            'Dim gminCheck As New dataEntryGlobalRoutines
            'If gminCheck.checkGminRequired(cboMonth.Text, gminStartMonth, gminEndMonth, cboHour.Text) = True Then
            '    txtVal_Elem099Field047.Enabled = True
            '    txtVal_Elem099Field047.BackColor = Color.White
            '    txtFlag099Field096.Enabled = True
            '    txtFlag099Field096.BackColor = Color.White
            'Else
            '    txtVal_Elem099Field047.Enabled = False
            '    txtVal_Elem099Field047.BackColor = Color.LightGray
            '    txtFlag099Field096.Enabled = False
            '    txtFlag099Field096.BackColor = Color.LightGray
            'End If
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
        stn = ds.Tables("formAgro1").Rows(inc).Item("stationId")
        cboStation.SelectedValue = stn
        '--------------------------
        'No need to assign text value to station combobox after assigning the "SelectedValue as above. This way, the displayed value
        'will be the station name according to the "DisplayMember in the texbox attribute, hence the line below has been commented out."

        txtYear.Text = ds.Tables("formAgro1").Rows(inc).Item("yyyy")
        cboMonth.Text = ds.Tables("formAgro1").Rows(inc).Item("mm")
        cboDay.Text = ds.Tables("formAgro1").Rows(inc).Item("dd")

        Dim m As Integer
        Dim ctl As Control

        'Display observation values in coressponding textboxes
        'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("formAgro1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("formAgro1").Rows(inc).Item(m)
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
                    If Not IsDBNull(ds.Tables("formAgro1").Rows(inc).Item(m)) Then
                        ctl.Text = ds.Tables("formAgro1").Rows(inc).Item(m)
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

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()
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
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

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
            dsNewRow = ds.Tables("formAgro1").NewRow
            'Add a new record to the data source table
            ds.Tables("formAgro1").Rows.Add(dsNewRow)
            'Commit observation header information to database
            ds.Tables("formAgro1").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ds.Tables("formAgro1").Rows(inc).Item("yyyy") = txtYear.Text
            ds.Tables("formAgro1").Rows(inc).Item("mm") = cboMonth.Text
            ds.Tables("formAgro1").Rows(inc).Item("dd") = cboDay.Text
            
            ' txtSignature.Text = frmLogin.txtUser.Text
            ds.Tables("formAgro1").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

            'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
            ds.Tables("formAgro1").Rows(inc).Item("entryDatetime") = Now()

            'Commit observation values to database
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To 53
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("formAgro1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'Commit observation flags to database
            'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
            For m = 54 To 102
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("formAgro1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            da.Update(ds, "formAgro1")

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

            maxRows = ds.Tables("formAgro1").Rows.Count
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database
        ds.Tables("formAgro1").Rows(inc).Item("stationId") = cboStation.SelectedValue
        ds.Tables("formAgro1").Rows(inc).Item("yyyy") = txtYear.Text
        ds.Tables("formAgro1").Rows(inc).Item("mm") = cboMonth.Text
        ds.Tables("formAgro1").Rows(inc).Item("dd") = cboDay.Text

        'Update observation values in database
        'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("formAgro1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'Update observation flags in database
        'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
        For m = 54 To 102
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    ds.Tables("formAgro1").Rows(inc).Item(m) = ctl.Text
                End If
            Next ctl
        Next m

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "formAgro1")

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

        ds.Tables("formAgro1").Rows(inc).Delete()
        da.Update(ds, "formAgro1")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
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
        If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(txtYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

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

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_agro1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_agro1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_agro1 ORDER by stationId,yyyy,mm,dd"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_agro1")
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
            maxRows = ds.Tables("formAgro1").Rows.Count
            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            obsVal = ""
            obsFlag = ""
            dataForm = "formAgro1"

            'Loop through all records in dataset
            For n = 0 To maxRows - 1
                'Display progress of data transfer
                frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                frmDataTransferProgress.txtDataTransferProgress1.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table

                For m = 4 To 37

                    stnId = ds.Tables("formAgro1").Rows(n).Item(0)
                    yyyy = ds.Tables("formAgro1").Rows(n).Item(1)
                    mm = ds.Tables("formAgro1").Rows(n).Item(2)
                    dd = ds.Tables("formAgro1").Rows(n).Item(3)
                    'hh = ds.Tables("formAgro1").Rows(n).Item(4)
                    If Not IsDBNull(ds.Tables("formAgro1").Rows(n).Item("signature")) Then capturedBy = ds.Tables("formAgro1").Rows(n).Item("signature")

                    If Val(mm) < 10 Then mm = "0" & mm
                    If Val(dd) < 10 Then dd = "0" & dd
                    'If Val(hh) < 10 Then hh = "0" & hh

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " 06:00:00"

                    If Not IsDBNull(ds.Tables("formAgro1").Rows(n).Item(m)) Then obsVal = ds.Tables("formAgro1").Rows(n).Item(m)
                    If Not IsDBNull(ds.Tables("formAgro1").Rows(n).Item(m + 34)) Then obsFlag = ds.Tables("formAgro1").Rows(n).Item(m + 34)
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
End Class