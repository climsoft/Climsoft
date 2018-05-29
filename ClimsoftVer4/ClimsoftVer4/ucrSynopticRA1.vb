Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrSynopticRA1
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_synoptic_2_RA1"
    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"
    Public bUpdating As Boolean = False
    Public fs2ra1Record As form_synoptic_2_ra1


    Private lstFields As New List(Of String)
    Private ucrLinkedNavigation As ucrNavigation
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay
    Private ucrLinkedHour As ucrHour

    'Stores Morning time for recording tmax
    Private iTmaxHour1 As Integer
    'Stores Afternoon time for recording tmax
    Private iTmaxHour2 As Integer
    'Stores Month for starting recording of Gmin
    Private iGminStartMonth As Integer
    'Stores Month for ending recording Gmin
    Private iGminEndMonth As Integer
    'Stores default Geopotential standard pressure level
    Private iStandardPressureLevel As Integer

    Private Sub ucrSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrVFP As ucrValueFlagPeriod

        If bFirstLoad Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName:=strValueFieldName & ctrVFP.Tag, strFlagFieldName:=strFlagFieldName & ctrVFP.Tag)
                    lstFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ctrVFP.Tag)
                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            'Get the Reg Keys to determine the Tmax,Tmin,gmin
            GetRegKeys()
            'Set the validation for the elements(the value textboxes)
            SetValueValidation()
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fs2ra1Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                fs2ra1Record = clsDataConnection.db.form_synoptic_2_ra1.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fs2ra1Record Is Nothing Then
                    fs2ra1Record = New form_synoptic_2_ra1
                    bUpdating = False
                Else
                    bUpdating = True
                End If
                'enable or disable textboxes based on year month day
                ValidateDataEntryPermission()
            End If
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
                End If
            Next

            'Check if Tmax is required and change properties accordingly
            SetTmaxRequired(IsTmaxRequired())

            'check if Tmin is required and change properties accordingly. 
            'This also applies to 24Hr precipitation And 24Hr sunshine
            SetTminRequired(IsTminRequired())

            'Check if Gmin is required and change properties accordingly
            SetGminRequired(IsGminRequired())

            If Not bUpdating Then
                SetDefaultStandardPressureLevel()
            End If

        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrTextbox As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrTextbox = DirectCast(sender, ucrTextBox)
            CallByName(fs2ra1Record, ucrTextbox.GetField, CallType.Set, ucrTextbox.GetValue)
        End If
    End Sub

    'TODO
    'THE NEXT FOCUS NEEDS TO BE REDONE DIFFERENTLY
    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        'Dim ctr As Control
        Dim ctrVFP As ucrValueFlagPeriod

        If TypeOf sender Is ucrValueFlagPeriod Then
            ctrVFP = DirectCast(sender, ucrValueFlagPeriod)
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    If ctr.Tag = ctrVFP.Tag + 1 Then
                        If ctr.Enabled Then
                            ctr.Focus()
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        fs2ra1Record = Nothing
        MyBase.LinkedControls_evtValueChanged()

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            CallByName(fs2ra1Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next
        ucrLinkedNavigation.UpdateNavigationByKeyControls()
    End Sub

    Public Overrides Sub Clear()
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrValueFlagPeriod).Clear()
            End If
        Next
    End Sub

    Public Sub SaveRecord()
        If bUpdating Then
            'clsDataConnection.db.fs2ra1Record.Add(fs2ra1Record)
            clsDataConnection.db.Entry(fs2ra1Record).State = Entity.EntityState.Modified
        Else
            'clsDataConnection.db.fs2ra1Record.Add(fs2ra1Record)
            clsDataConnection.db.Entry(fs2ra1Record).State = Entity.EntityState.Added
        End If

        clsDataConnection.db.SaveChanges()

    End Sub

    Public Sub DeleteRecord()
        'clsDataConnection.db.Entry(fs2ra1Record)
        clsDataConnection.db.form_synoptic_2_ra1.Attach(fs2ra1Record)
        clsDataConnection.db.form_synoptic_2_ra1.Remove(fs2ra1Record)
        clsDataConnection.db.SaveChanges()
    End Sub

    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"elementId", "lowerLimit", "upperLimit"}))
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    row = dtbl.Select("elementId = '" & ucrVFP.Tag & "'").FirstOrDefault()
                    If row IsNot Nothing Then
                        If Val(row.Item("lowerLimit")) <> 0 Then
                            ucrVFP.SetElementValueValidation(iLowerLimit:=Val(row.Item("lowerLimit")))
                        End If

                        If Val(row.Item("upperLimit")) <> 0 Then
                            ucrVFP.SetElementValueValidation(iUpperLimit:=Val(row.Item("upperLimit")))
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' checks if all the ucrValueFlagPeriod controls have a value.
    ''' Returns true if they are all empty and false if otherwise
    ''' </summary>
    ''' <returns></returns>
    Public Function IsValuesEmpty() As Boolean
        Dim ucrVFP As ucrValueFlagPeriod
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                If (Not ucrVFP.IsElementValueEmpty()) AndAlso IsNumeric(ucrVFP.GetElementValue) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' This sets the iTmaxHour1,iTmaxHour2,iGminStartMonth,iGminEndMonth variables
    ''' by getting the values from the regkeys database table
    ''' </summary>
    Private Sub GetRegKeys()
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableName("regkeys")
        clsDataDefinition.SetFields(New List(Of String)({"keyName", "keyValue"}))
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then

            'Get Geopotential standard pressure level
            row = dtbl.Select("keyName = 'key00'").FirstOrDefault()
            iStandardPressureLevel = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get morning time for recording tmax 
            row = dtbl.Select("keyName = 'key01'").FirstOrDefault()
            iTmaxHour1 = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get afternoon time for recording tmax 
            row = dtbl.Select("keyName = 'key02'").FirstOrDefault()
            iTmaxHour2 = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

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
    Private Sub SetTminRequired(bRequired As Boolean)
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
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
                Exit For
            End If
        Next

        Return (iHour = iTmaxHour1 OrElse iHour = iTmaxHour2)
    End Function

    Private Function IsTminRequired() As Boolean
        Dim iHour As Integer
        'get the hour value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
                Exit For
            End If
        Next

        'tmaxHour1 is the tmin
        Return (iHour = iTmaxHour1)
    End Function

    Private Function IsGminRequired() As Boolean
        Dim iMonth As Integer
        Dim iHour As Integer
        'get the month and the hour value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrMonth Then
                iMonth = Val(ucrKeyControl.GetValue)
            ElseIf TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
            End If
        Next

        Return (iMonth >= iGminStartMonth AndAlso iMonth < iGminEndMonth AndAlso iHour = 6)
    End Function

    Public Sub SetDefaultStandardPressureLevel()
        ucrVFPStandardPressureLevel.SetValue(New List(Of Object)({iStandardPressureLevel.ToString}))
        'ucrVFPStandardPressureLevel.ucrValue.SetValue(iStandardPressureLevel.ToString)
    End Sub

    'TODO
    'THIS IS NOT YET COMPLETED
    Private Sub ucrVFPWetBulbTemp_Leave(sender As Object, e As EventArgs) Handles ucrVFPWetBulbTemp.Leave
        Try
            'If wetbulb > dewpoint both elements are flagged because either of them could be wrong.
            'i.e. wetbulb > the correct value or drybulb < correct value.
            If Val(ucrVFPWetBulbTemp.GetElementValue) > Val(ucrVFPDryBulbTemp.GetElementValue) Then
                ucrVFPWetBulbTemp.ucrValue.SetBackColor(Color.Cyan)
                ucrVFPDryBulbTemp.ucrValue.SetBackColor(Color.Cyan)
                'ucrVFPWetBulbTemp.Focus()
                ucrVFPWetBulbTemp.ucrValue.GetFocus()
                MsgBox("Drybulb must be greater or equal to Wetbulb!", MsgBoxStyle.Exclamation)
            Else
                ucrVFPWetBulbTemp.ucrValue.SetBackColor(Color.White)
                ucrVFPDryBulbTemp.ucrValue.SetBackColor(Color.White)

                'Apply element scale factor to drybulb and wetbulb 
                'before calling function to calculate dewpoint
                Dim dryBulb = Val(ucrVFPDryBulbTemp.GetElementValue) / 10
                Dim wetBulb = Val(ucrVFPWetBulbTemp.GetElementValue) / 10
                Dim dwPoint = calculateDewpoint(dryBulb, wetBulb) * 10
                ucrVFPDewPointTemp.SetValue(New List(Of Object)({dwPoint.ToString}))

                Dim ppp = Val(ucrVFPStationLevelPressure.GetElementValue) / 10
                Dim gpm = Val(ucrVFPStandardPressureLevel.GetElementValue)

                'do a datacall to get station elevation
                Dim stnElevation = GetStationElevation()

                If stnElevation <> "" AndAlso Not ucrVFPStationLevelPressure.IsElementValueEmpty AndAlso Not ucrVFPDryBulbTemp.IsElementValueEmpty Then
                    'Calculate geopotential
                    Dim geoPotentialHeight = CalculateGeopotential(ppp, dryBulb, Val(stnElevation), gpm)
                    ucrVFPGeopotentialHeight.SetValue(New List(Of Object)({geoPotentialHeight.ToString}))
                    'calculate MSL pressure
                    Dim mslpp = CalculateMSLppp(ppp, dryBulb, Val(stnElevation))
                    ucrVFPPressureReduced.SetValue(New List(Of Object)({mslpp.ToString}))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UcrVFPWetBulbTemp_LostFocus(sender As Object, e As EventArgs) Handles ucrVFPWetBulbTemp.LostFocus

    End Sub

    Public Function calculateDewpoint(ByVal dryBulb As Decimal, ByVal wetBulb As Decimal) As Decimal
        'Td in this case is Temperature drybulb,
        'Tw wetBulb And Tp Is dewpoint temperature
        'E is saturation vapour pressure(s.v.p.), 
        'hence Ed Is s.v.p.over drybulb And Ew s.v.p. over wetbulb, 
        'Ea actual s.v.p.
        Dim Td_Fahrenheit As Decimal
        Dim Ed As Decimal
        Dim Tw_Fahrenheit As Decimal
        Dim Ew As Decimal
        Dim Ea As Decimal
        Dim Tp_Fahrenheit As Decimal
        Dim Tp_Celcius As Decimal

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

    Private Function GetStationElevation() As String
        Dim elevation As String = ""
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable

        Dim stationValue As String = ""
        'get the station value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrStationSelector Then
                stationValue = ucrKeyControl.GetValue
                Exit For
            End If
        Next

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableName("stations")
        clsDataDefinition.SetFields(New List(Of String)({"stationId", "elevation"}))
        clsDataDefinition.SetFilter("stationId", "=", stationValue, bIsPositiveCondition:=True, bForceValuesAsString:=True)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            elevation = dtbl.Rows(0).Item("elevation")
        End If
        Return elevation
    End Function

    'TODO
    'SAMUEL IS USING VariantType WHICH TRUNCATES VALUES AND PRECISION
    'IS LOST. WHEN DECIMALS ARE USED THE CALCULATION RESULTS CHANGES
    'ANY SUGGESTION ON THE WAY FORWARD
    Private Function CalculateGeopotential(ppp As Decimal, dryBulb As Decimal, elevation As Decimal, gpmStdLevel As Decimal) As Decimal
        Dim geoPotential As Decimal
        Dim g As VariantType, R As VariantType, gamma As VariantType, K As VariantType
        'Dim g As Decimal
        'Dim R As Decimal
        'Dim gamma As Decimal
        'Dim K As Decimal

        '0.0065 is dry adiabatic lapse rate
        '9.80665 is acceleration due to gravity
        '287.04 is universal gas constant
        '273.15 is zero Kelvin
        gamma = 0.0065
        g = 9.80665
        R = 287.04
        K = dryBulb + 273.15
        geoPotential = Math.Round((elevation + (R / g) * Math.Log(ppp / gpmStdLevel) * (K + ((gamma / 2) * elevation))) / (1 + (R / g) * Math.Log(ppp / gpmStdLevel) * (gamma / 2)))

        Return geoPotential
    End Function

    Private Function CalculateMSLppp(ppp As Decimal, dryBulb As Decimal, elevation As Decimal) As Decimal
        Dim MSLppp As Decimal

        MSLppp = (ppp * (1 - 0.0065 * elevation / (dryBulb + 0.0065 * elevation + 273.15)) ^ -5.257) * 10
        '0.0065 is dry adiabatic lapse rate
        MSLppp = Math.Round(MSLppp)
        Return MSLppp
    End Function

    Private Sub UcrVFPDewPointTemp_LostFocus(sender As Object, e As EventArgs) Handles ucrVFPDewPointTemp.LostFocus
        Dim dryBulb As Decimal
        Dim dewPoint As Decimal
        Dim rh As Decimal

        dryBulb = Val(ucrVFPDryBulbTemp.GetElementValue) / 10
        dewPoint = Val(ucrVFPDewPointTemp.GetElementValue) / 10
        'TODO SAMUEL IS USING THE DEWPOINT AND THE DRYBULB VALUES TO CALCULATE
        'THE RELATIVE HUMIDITY. I'M NOT SURE IF THOSE ARE THE CORRECT VALUES
        'FOR CALCULATING THAT. JUST DUPLICATED HIS
        rh = CalculateRH(dewPoint, dryBulb)
        ucrVFPRelativeHumidity.SetValue(New List(Of Object)({rh.ToString}))
    End Sub

    Private Function CalculateRH(ByVal dewPoint As Decimal, ByVal dryBulb As Decimal) As Decimal
        Dim RH As Decimal
        Dim svp1 As Decimal
        Dim svp2 As Decimal
        'svp => saturation vapour pressure
        'RH= svp(dewpoint)/svp(drybulb)

        svp1 = 6.11 * 10 ^ (7.5 * dewPoint / (237.3 + dewPoint))
        svp2 = 6.11 * 10 ^ (7.5 * dryBulb / (237.3 + dryBulb))
        RH = Math.Round((svp1 / svp2) * 100, 0)
        Return RH
    End Function

    ''' <summary>
    ''' Sets the controls used by this control station,year,month,day and ucrNavigation controls 
    ''' </summary>
    ''' <param name="ucrStationControl"></param>
    ''' <param name="ucrYearControl"></param>
    ''' <param name="ucrMonthControl"></param>
    ''' <param name="ucrDayControl"></param>
    ''' <param name="ucrHourControl"></param>
    ''' <param name="ucrNavigationControl"></param>
    Public Sub SetKeyControls(ucrStationControl As ucrStationSelector, ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth, ucrDayControl As ucrDay, ucrHourControl As ucrHour, ucrNavigationControl As ucrNavigation)

        ucrLinkedStation = ucrStationControl
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        ucrLinkedDay = ucrDayControl
        ucrLinkedHour = ucrHourControl
        ucrLinkedNavigation = ucrNavigationControl

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)

        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "yyyy", "mm", "dd", "hh"})))
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("dd", ucrLinkedDay)
        ucrLinkedNavigation.SetKeyControls("hh", ucrLinkedHour)

    End Sub

    ''' <summary>
    ''' checks the selected year month day to permit entry or not.
    ''' this prevents data entry of current and future dates
    ''' </summary>
    Private Sub ValidateDataEntryPermission()
        'if its an update or any of the linked year,month and day selector is nothing then just exit the sub
        If bUpdating OrElse ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
            Exit Sub
        End If

        Dim todayDate As Date
        Dim selectedDate As Date

        'initialise the dates with ONLY year month and day values. 
        'Neglect the time factor
        todayDate = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        selectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

        'if selectedDate is earlier than todayDate enable control
        If DateTime.Compare(selectedDate, todayDate) < 0 Then
            Me.Enabled = True
        Else
            'if it is same time (0) or later than (>0) disable control
            Me.Enabled = False
        End If
    End Sub
End Class
