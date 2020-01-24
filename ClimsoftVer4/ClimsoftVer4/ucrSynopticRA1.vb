
Public Class ucrSynopticRA1

    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"

    'Stores Morning time for recording tmax
    Private iTmaxMorningHour As Integer
    'Stores Afternoon time for recording tmax
    Private iTmaxAfternoonHour As Integer
    'Stores Month for starting recording of Gmin
    Private iGminStartMonth As Integer
    'Stores Month for ending recording Gmin
    Private iGminEndMonth As Integer
    'Stores default Geopotential standard pressure level
    Private iStandardPressureLevel As Integer
    Private bAutoFillValues As Boolean = True

    Private Sub ucrSynopticRA1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)

            'set up the value flag period first
            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_synoptic_2_ra1")
            AddField("signature")
            AddField("entryDatetime")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonthSelector, ucrMonthSelector.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDaySelector, ucrDaySelector.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrHourSelector, ucrHourSelector.FieldName, "=", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)

            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)
            GetRegKeys()

            bFirstLoad = False

            'populate the values
            ucrNavigation.SetSortBy("entryDatetime")
            ucrNavigation.PopulateControl()

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"mm", "dd", "hh"}, {ucrMonthSelector, ucrDaySelector, ucrHourSelector}, ucrYearSelector)
            ' ucrNavigation.NewRecord() 'temporary
            'SaveEnable()
            ucrVFPStationLevelPressure.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnSaveAndUpdate_Click(sender As Object, e As EventArgs) Handles btnSave.Click, btnUpdate.Click
        'Change the signature(user) and the DATETIME first before saving 
        GetTable.Rows(0).Item("signature") = frmLogin.txtUsername.Text
        GetTable.Rows(0).Item("entryDatetime") = Date.Now
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_synoptic_2_ra1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_synoptic_2_ra1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
        Else
            sql = "SELECT * FROM form_synoptic_2_ra1 ORDER by stationId,yyyy,mm,dd,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_synopticRA1")
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmFormUpload.lblFormName.Text = "form_synoptic_2_ra1"
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName.Text

        frmFormUpload.Show()
        Exit Sub

        'upload code in the background thread
        Dim frm As New frmNewComputationProgress
        frm.SetHeader("Uploading " & ucrNavigation.iMaxRows & " records")
        frm.SetProgressMaximum(ucrNavigation.iMaxRows)
        frm.ShowNumbers(True)
        frm.ShowResultMessage(True)
        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

        frm.backgroundWorker.RunWorkerAsync()
        frm.Show()
    End Sub

    Private Sub chkAutoFillValues_CheckedChanged(sender As Object, e As EventArgs) Handles chkAutoFillValues.CheckedChanged
        bAutoFillValues = chkAutoFillValues.Checked
    End Sub

    Private Sub ucrYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrYearSelector.evtValueChanged
        If ucrYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrYearSelector.IsLeapYear(), "seq_month_day_synoptime_leap_yr", "seq_month_day_synoptime")
        End If
    End Sub

    Private Sub btnTDCF_Click(sender As Object, e As EventArgs) Handles btnTDCF.Click
        Try
            frmSynopTDCF.Show()
            frmSynopTDCF.cboTemplate.Text = "TM_307081"
            ' Subset Observations
            'TODO. Copied from Samuel's code


            Dim clsDataDefinition As New DataCall
            Dim dtbl As DataTable
            clsDataDefinition.SetTableNameAndFields("form_synoptic_2_ra1", {"stationId", "yyyy", "mm", "dd", "hh"})

            Dim yearFilter As TableFilter = New TableFilter(strNewField:="yyyy", strNewOperator:="=", objNewValue:=ucrYearSelector.GetValue, bNewIsPositiveCondition:=True, bForceValuesAsString:=True)
            Dim monthFilter As TableFilter = New TableFilter(strNewField:="mm", strNewOperator:="=", objNewValue:=ucrMonthSelector.GetValue, bNewIsPositiveCondition:=True, bForceValuesAsString:=True)
            Dim dayFilter As TableFilter = New TableFilter(strNewField:="dd", strNewOperator:="=", objNewValue:=ucrDaySelector.GetValue, bNewIsPositiveCondition:=True, bForceValuesAsString:=True)
            Dim hourFilter As TableFilter = New TableFilter(strNewField:="hh", strNewOperator:="=", objNewValue:=ucrHourSelector.GetValue, bNewIsPositiveCondition:=True, bForceValuesAsString:=True)


            clsDataDefinition.SetFilter(New TableFilter({yearFilter, monthFilter, dayFilter, hourFilter}))
            dtbl = clsDataDefinition.GetDataTable()

            frmSynopTDCF.cboStation.Text = ucrStationSelector.GetValue
            frmSynopTDCF.txtYear.Text = ucrYearSelector.GetValue
            frmSynopTDCF.cboMonth.Text = ucrMonthSelector.GetValue
            frmSynopTDCF.cboDay.Text = ucrDaySelector.GetValue
            frmSynopTDCF.cboHour.Text = ucrHourSelector.GetValue
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                ' Populate the station combo box with the stations for the subset
                For Each row As DataRow In dtbl.Rows
                    frmSynopTDCF.cboStation.Items.Add(row.Item("stationId"))
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "TDCF", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Protected Overrides Sub SetValuesValidation()
        SetValuesLimits()
        'Check if Tmax is required and change properties accordingly
        SetTmaxRequired(IsTmaxRequired())

        'check if Tmin is required and change properties accordingly. 
        'This also applies to 24Hr precipitation And 24Hr sunshine
        SetTminAndRelatedElementsRequired(IsTminRequired())

        'Check if Gmin is required and change properties accordingly
        SetGminRequired(IsGminRequired())

        If Not bUpdating AndAlso bAutoFillValues Then
            SetDefaultStandardPressureLevel()
        End If

    End Sub

    Private Sub SetValuesLimits()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow
        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", {"elementId", "lowerLimit", "upperLimit"})
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    row = dtbl.Select("elementId = '" & ucrVFP.Tag & "'").FirstOrDefault()
                    If row IsNot Nothing Then
                        If IsDBNull(row.Item("lowerLimit")) OrElse String.IsNullOrEmpty(row.Item("lowerLimit")) Then
                            ucrVFP.SetElementValueLowerLimit(Decimal.MinValue)
                        Else
                            ucrVFP.SetElementValueLowerLimit(Val(row.Item("lowerLimit")))
                        End If

                        If IsDBNull(row.Item("upperLimit")) OrElse String.IsNullOrEmpty(row.Item("upperLimit")) Then
                            ucrVFP.SetElementValueHigherLimit(Decimal.MaxValue)
                        Else
                            ucrVFP.SetElementValueHigherLimit(Val(row.Item("upperLimit")))
                        End If

                    End If
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' This sets the iTmaxHour1,iTmaxHour2,iGminStartMonth,iGminEndMonth variables
    ''' by getting the values from the regkeys database table
    ''' </summary>
    Private Sub GetRegKeys()
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("regkeys", {"keyName", "keyValue"})
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            'Get Geopotential standard pressure level
            row = dtbl.Select("keyName = 'key00'").FirstOrDefault()
            iStandardPressureLevel = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get morning time for recording tmax 
            row = dtbl.Select("keyName = 'key01'").FirstOrDefault()
            iTmaxMorningHour = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get afternoon time for recording tmax 
            row = dtbl.Select("keyName = 'key02'").FirstOrDefault()
            iTmaxAfternoonHour = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get the month for starting record of Gmin
            row = dtbl.Select("keyName = 'key03'").FirstOrDefault()
            iGminStartMonth = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get the month for ending record of Gmin
            row = dtbl.Select("keyName = 'key04'").FirstOrDefault()
            iGminEndMonth = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPTmax control based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetTmaxRequired(bRequired As Boolean)
        If bRequired Then
            'Apply required action to Tmax
            ucrVFPTmax.Enabled = True
            ucrVFPTmax.SetBackColor(Color.White)
        Else
            ucrVFPTmax.Enabled = False
            ucrVFPTmax.SetBackColor(Color.LightGray)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPTmin,ucrVFPEvaporation,ucrVFPSss24Hr,ucrVFPPrecip24Hr and ucrVFPInsolation controls based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetTminAndRelatedElementsRequired(bRequired As Boolean)
        If bRequired Then
            'Apply required action to Tmin
            ucrVFPTmin.Enabled = True
            ucrVFPTmin.SetBackColor(Color.White)

            'Apply same action to evaporation
            ucrVFPEvaporation.Enabled = True
            ucrVFPEvaporation.SetBackColor(Color.White)

            'Apply same action to 24Hr sunshine
            ucrVFPSss24Hr.Enabled = True
            ucrVFPSss24Hr.SetBackColor(Color.White)

            'Apply same action to 24Hr precip
            ucrVFPPrecip24Hr.Enabled = True
            ucrVFPPrecip24Hr.SetBackColor(Color.White)

            'Apply same action to 24Hr radiation (Insolation)
            ucrVFPInsolation.Enabled = True
            ucrVFPInsolation.SetBackColor(Color.White)

        Else
            ucrVFPTmin.Enabled = False
            ucrVFPTmin.SetBackColor(Color.LightGray)

            ucrVFPEvaporation.Enabled = False
            ucrVFPEvaporation.SetBackColor(Color.LightGray)

            ucrVFPSss24Hr.Enabled = False
            ucrVFPSss24Hr.SetBackColor(Color.LightGray)

            ucrVFPPrecip24Hr.Enabled = False
            ucrVFPPrecip24Hr.SetBackColor(Color.LightGray)

            ucrVFPInsolation.Enabled = False
            ucrVFPInsolation.SetBackColor(Color.LightGray)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPGrassMinTemp control based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetGminRequired(bRequired As Boolean)
        If bRequired Then
            ucrVFPGrassMinTemp.Enabled = True
            ucrVFPGrassMinTemp.SetBackColor(Color.White)
        Else
            ucrVFPGrassMinTemp.Enabled = False
            ucrVFPGrassMinTemp.SetBackColor(Color.LightGray)
        End If
    End Sub

    Private Function IsTmaxRequired() As Boolean
        Dim iHour As Integer
        'get the hour value
        iHour = ucrHourSelector.GetValue
        Return (iHour = iTmaxMorningHour OrElse iHour = iTmaxAfternoonHour)
    End Function

    Private Function IsTminRequired() As Boolean
        Dim iHour As Integer
        'get the hour value
        iHour = ucrHourSelector.GetValue
        'iTmaxMorningHour is the tmin
        Return (iHour = iTmaxMorningHour)
    End Function

    Private Function IsGminRequired() As Boolean
        Dim iMonth As Integer
        Dim iHour As Integer
        'get the month and the hour value
        iMonth = ucrMonthSelector.GetValue
        iHour = ucrHourSelector.GetValue
        Return (iMonth >= iGminStartMonth AndAlso iMonth < iGminEndMonth AndAlso iHour = 6)
    End Function

    Private Sub SetDefaultStandardPressureLevel()
        ucrVFPStandardPressureLevel.SetElementValue(iStandardPressureLevel)
    End Sub

    Private Sub ucrVFPWetBulbTemp_Leave(sender As Object, e As EventArgs) Handles ucrVFPWetBulbTemp.Leave
        Try
            If Not bAutoFillValues Then
                Exit Sub
            End If

            If Val(ucrVFPDryBulbTemp.GetElementValue) < Val(ucrVFPWetBulbTemp.GetElementValue) Then
                ucrVFPWetBulbTemp.ucrValue.SetBackColor(Color.Cyan)
                ucrVFPDryBulbTemp.ucrValue.SetBackColor(Color.Cyan)
                ucrVFPWetBulbTemp.ucrValue.GetFocus()
                MessageBox.Show("Drybulb must be greater or equal to Wetbulb!", "Wetbulb", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                ucrVFPWetBulbTemp.ucrValue.SetBackColor(Color.White)
                ucrVFPDryBulbTemp.ucrValue.SetBackColor(Color.White)

                Dim dryBulb, wetBulb, dwPoint, ppp, gpm, stationElevation As Decimal

                'Apply element scale factor to drybulb and wetbulb 
                'before calling function to calculate dewpoint
                dryBulb = Val(ucrVFPDryBulbTemp.GetElementValue) / 10
                wetBulb = Val(ucrVFPWetBulbTemp.GetElementValue) / 10
                dwPoint = calculateDewpoint(dryBulb, wetBulb) * 10

                ucrVFPDewPointTemp.SetElementValue(dwPoint)

                ppp = Val(ucrVFPStationLevelPressure.GetElementValue) / 10
                gpm = Val(ucrVFPStandardPressureLevel.GetElementValue)

                'do a datacall to get station elevation
                stationElevation = GetStationElevation()

                If stationElevation <> 0 AndAlso Not ucrVFPStationLevelPressure.IsElementValueEmpty AndAlso Not ucrVFPDryBulbTemp.IsElementValueEmpty Then
                    'Calculate and set geopotential 
                    ucrVFPGeopotentialHeight.SetElementValue(CalculateGeopotential(ppp, dryBulb, stationElevation, gpm))
                    'calculate and set MSL pressure 
                    ucrVFPPressureReduced.SetElementValue(CalculateMSLppp(ppp, dryBulb, stationElevation))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UcrVFPDewPointTemp_Leave(sender As Object, e As EventArgs) Handles ucrVFPDewPointTemp.Leave
        If Not bAutoFillValues Then
            Exit Sub
        End If

        Dim dryBulb, dewPoint As Decimal
        'Apply element scale factor to drybulb and wetbulb before calling the function to calculate relative humidty
        dryBulb = Val(ucrVFPDryBulbTemp.GetElementValue) / 10
        dewPoint = Val(ucrVFPDewPointTemp.GetElementValue) / 10
        ucrVFPRelativeHumidity.SetElementValue(CalculateRelativeHumidity(dewPoint, dryBulb))
    End Sub

    Private Function calculateDewpoint(ByVal dryBulb As Decimal, ByVal wetBulb As Decimal) As Decimal
        'Td in this case is Temperature drybulb,
        'Tw wetBulb And Tp Is dewpoint temperature
        'E is saturation vapour pressure(s.v.p.), 
        'hence Ed Is s.v.p.over drybulb And Ew s.v.p. over wetbulb, 
        'Ea actual s.v.p.
        Dim Td_Fahrenheit, Ed, Tw_Fahrenheit, Ew, Ea, Tp_Fahrenheit, Tp_Celcius As Decimal

        Td_Fahrenheit = ((9 / 5) * dryBulb) + 32
        '2.71828183 is natural number (e)
        Ed = 6.1078 * 2.71828183 ^ (((9.5939 * Td_Fahrenheit) - 307.004) / ((0.556 * Td_Fahrenheit) + 219.522))
        Tw_Fahrenheit = ((9 / 5) * wetBulb) + 32
        Ew = 6.1078 * 2.71828183 ^ (((9.5939 * Tw_Fahrenheit) - 307.004) / ((0.556 * Tw_Fahrenheit) + 219.522))
        Ea = Ew - 0.35 * (Td_Fahrenheit - Tw_Fahrenheit)
        Tp_Fahrenheit = -1 * ((Math.Log(Ea / 6.1078) * 219.522) + 307.004) / ((Math.Log(Ea / 6.1078) * 0.556) - 9.59539)
        Tp_Celcius = (5 / 9) * (Tp_Fahrenheit - 32)
        Tp_Celcius = Math.Round(Tp_Celcius, 0)

        Return Tp_Celcius
    End Function

    ''' <summary>
    ''' gets the elevation value of the currently selected station
    ''' </summary>
    ''' <returns></returns>
    Private Function GetStationElevation() As Double
        Dim elevation As Double
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim stationId As String

        'get the the current selected station id
        stationId = ucrStationSelector.GetValue()

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("station", {"stationId", "elevation"})
        clsDataDefinition.SetFilter("stationId", "=", stationId, bIsPositiveCondition:=True, bForceValuesAsString:=True)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            elevation = Val(dtbl.Rows(0).Item("elevation"))
        End If
        Return elevation
    End Function

    'TODO. SAMUEL IS USING VariantType WHICH TRUNCATES VALUES AND PRECISION IS LOST. WHEN DECIMALS ARE USED THE CALCULATION RESULTS CHANGES
    Private Function CalculateGeopotential(ppp As Decimal, dryBulb As Decimal, elevation As Decimal, gpmStdLevel As Decimal) As Decimal
        Dim gravity, gasConstant, gamma, K As Decimal
        gamma = 0.0065  '0.0065 is dry adiabatic lapse rate
        gravity = 9.80665  '9.80665 is acceleration due to gravity
        gasConstant = 287.04 '287.04 is universal gas constant
        K = dryBulb + 273.15  '273.15 is zero Kelvin 
        Return Math.Round((elevation + (gasConstant / gravity) * Math.Log(ppp / gpmStdLevel) * (K + ((gamma / 2) * elevation))) / (1 + (gasConstant / gravity) * Math.Log(ppp / gpmStdLevel) * (gamma / 2)))
    End Function

    Private Function CalculateMSLppp(ppp As Decimal, dryBulb As Decimal, elevation As Decimal) As Decimal
        '0.0065 is dry adiabatic lapse rate 
        Return Math.Round((ppp * (1 - 0.0065 * elevation / (dryBulb + 0.0065 * elevation + 273.15)) ^ -5.257) * 10)
    End Function

    Private Function CalculateRelativeHumidity(ByVal dewPoint As Decimal, ByVal dryBulb As Decimal) As Decimal
        'svp means saturation vapour pressure
        Dim svp1, svp2 As Decimal
        'Relative Humidity = svp(dewpoint)/svp(drybulb)
        svp1 = 6.11 * 10 ^ (7.5 * dewPoint / (237.3 + dewPoint))
        svp2 = 6.11 * 10 ^ (7.5 * dryBulb / (237.3 + dryBulb))
        Return Math.Round((svp1 / svp2) * 100, 0)
    End Function

    ''' <summary>
    ''' checks the selected year month day to permit entry or not.
    ''' this prevents data entry of current and future dates
    ''' </summary>
    Protected Overrides Sub ValidateDataEntryPermission()
        Dim bEnabled As Boolean
        'if its an update or any of the linked year,month and day selector is nothing then just enable the control
        If ucrYearSelector.ValidateValue AndAlso ucrMonthSelector.ValidateValue AndAlso ucrDaySelector.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date
            'initialise the dates with ONLY year month and day values. Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrYearSelector.GetValue, ucrMonthSelector.GetValue, ucrDaySelector.GetValue)

            'if selectedDate is earlier than todayDate (<0) enable control
            'if it is same time (0) or later than (>0) disable control
            bEnabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
        Else
            bEnabled = False
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                ctr.Enabled = bEnabled
            End If
        Next
    End Sub


    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim dtbAllRecords As New DataTable
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strElementCode As String
        Dim strStationId As String
        Dim lElementId As Long
        Dim dtObsDateTime As Date
        Dim lstAllFields As New List(Of String)
        Dim bUpdateRecord As Boolean
        Dim strSql As String
        Dim strSignature As String
        Dim pos As Integer = 0
        Dim iUpdatesNum As Integer = 0
        Dim iInsertsNum As Integer = 0
        Dim invalidRecord As Boolean = False
        Dim strResult As String = ""
        Dim strTableName As String

        Try

            strTableName = GetTableName()

            'Get all the records from the table
            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand("Select * FROM " & GetTableName() & " ORDER BY entryDatetime", clsDataConnection.OpenedConnection)
                Using da As New MySql.Data.MySqlClient.MySqlDataAdapter(cmdSelect)
                    da.Fill(dtbAllRecords)
                End Using
            End Using

            'Save the records to observable initial table
            For Each row As DataRow In dtbAllRecords.Rows
                If backgroundWorker.CancellationPending Then
                    e.Result = strResult & "Cancelling upload"
                    e.Cancel = True
                    Exit For
                End If

                For Each strFieldName As String In lstFields
                    'if its not an observation value field then skip the loop
                    If Not strFieldName.StartsWith(Me.strValueFieldName) Then
                        Continue For
                    End If

                    strElementCode = strFieldName.Substring(Me.strValueFieldName.Length)
                    strValueColumn = strFieldName
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strElementCode)
                                                   End Function)

                    'set the record
                    If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(strElementCode, lElementId) Then

                        strStationId = row.Item("stationId")

                        Try
                            dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), row.Item("hh"), 0, 0)
                        Catch ex As Exception
                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record" &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Day: " & row.Item("dd") & ", Hour: " & row.Item("hh") &
                                ". This row will be skipped" & Environment.NewLine
                            Exit For
                        End Try

                        bUpdateRecord = False
                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.OpenedConnection)
                            cmd.Parameters.AddWithValue("@stationId", strStationId)
                            cmd.Parameters.AddWithValue("@elemCode", lElementId)
                            cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                            cmd.Parameters.AddWithValue("@qcStatus", 0)
                            cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                            cmd.Parameters.AddWithValue("@dataForm", GetTableName)
                            Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                                bUpdateRecord = reader.HasRows
                            End Using
                        End Using

                        strSignature = ""

                        If Not IsDBNull(row.Item("signature")) Then
                            strSignature = row.Item("signature")
                        End If

                        If bUpdateRecord Then
                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm " &
                                " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Else
                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@qcStatus,@acquisitiontype,@capturedBy,@dataForm)"
                        End If

                        Try
                            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.OpenedConnection)
                                cmd.Parameters.AddWithValue("@stationId", strStationId)
                                cmd.Parameters.AddWithValue("@elemCode", lElementId)
                                cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                                cmd.Parameters.AddWithValue("@obsLevel", "surface")
                                cmd.Parameters.AddWithValue("@obsVal", row.Item(strValueColumn))
                                cmd.Parameters.AddWithValue("@obsFlag", row.Item(strFlagColumn))
                                cmd.Parameters.AddWithValue("@qcStatus", 0)
                                cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                                cmd.Parameters.AddWithValue("@capturedBy", strSignature)
                                cmd.Parameters.AddWithValue("@dataForm", GetTableName)
                                cmd.ExecuteNonQuery()
                            End Using
                            If bUpdateRecord Then
                                iUpdatesNum += 1
                            Else
                                iInsertsNum += 1
                            End If
                        Catch ex As Exception
                            'MsgBox("Invalid record detected. Record number " & pos & " could not be uploaded. This record will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid record detected. Record number " & pos & " could not be uploaded" &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Day: " & row.Item("dd") & ", Hour: " & row.Item("hh") & ", Date: " & dtObsDateTime &
                                ". This record was skipped" & Environment.NewLine
                            Exit For
                        End Try

                    End If
                Next

                'Display progress of data transfer
                pos += 1
                backgroundWorker.ReportProgress(pos)
            Next

            If Not invalidRecord Then
                strResult = "All Records have been uploaded sucessfully "
            End If

            e.Result = strResult & Environment.NewLine & "Total New Records: " & iInsertsNum & Environment.NewLine & "Total Updates: " & iUpdatesNum

        Catch ex As Exception
            e.Result = "Error " & ex.Message
        End Try
    End Sub


End Class