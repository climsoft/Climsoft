﻿Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourlywind"
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private strTotalFieldName As String = "total"
    Private iDirectionElementId As Integer
    Private iSpeedElementId As Integer
    Private bSpeedTotalRequired As Boolean
    Private lstFields As New List(Of String)
    Public fhourlyWindRecord As form_hourlywind
    Public bUpdating As Boolean = False
    Private ucrLinkedNavigation As ucrNavigation
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay

    Private Sub ucrHourlyWind_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim ucrText As ucrTextBox

        If bFirstLoad Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrDSF.SetTableNameAndDirectionSpeedFlagFields(strTableName, strDirectionFieldName & ucrDSF.Tag, strSpeedFieldName & ucrDSF.Tag, strFlagFieldName & ucrDSF.Tag)
                    lstFields.Add(strDirectionFieldName & ucrDSF.Tag)
                    lstFields.Add(strSpeedFieldName & ucrDSF.Tag)
                    lstFields.Add(strFlagFieldName & ucrDSF.Tag)
                    AddHandler ucrDSF.ucrDirection.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrSpeed.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.evtGoToNextDSFControl, AddressOf GoToNextDSFControl
                ElseIf TypeOf ctr Is ucrTextBox Then
                    ucrText = DirectCast(ctr, ucrTextBox)
                    ucrText.SetTableNameAndField(strTableName, strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ucrText.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim clsCurrentFilter As TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fhourlyWindRecord Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                fhourlyWindRecord = clsDataConnection.db.form_hourlywind.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fhourlyWindRecord Is Nothing Then
                    fhourlyWindRecord = New form_hourlywind
                    bUpdating = False
                Else
                    clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Detached
                    bUpdating = True
                End If
                'enable or disable textboxes based on year month day
                ValidateDataEntryPermission()
            End If

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    DirectCast(ctr, ucrDirectionSpeedFlag).SetValue(New List(Of Object)({GetValue(strDirectionFieldName & ctr.Tag), GetValue(strSpeedFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrTextBox).SetValue(GetValue(strTotalFieldName))
                End If
            Next

        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrTextbox As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrTextbox = DirectCast(sender, ucrTextBox)
            CallByName(fhourlyWindRecord, ucrTextbox.GetField, CallType.Set, ucrTextbox.GetValue)
        End If
    End Sub

    Private Sub GoToNextDSFControl(sender As Object, e As KeyEventArgs)
        'TODO 
        'SHOULD BE ABLE TO IDENTIFY THE PARTICULAR TEXTBOX AS A SENDER
        'Dim ucrDSF As ucrDirectionSpeedFlag

        'If TypeOf sender Is ucrDirectionSpeedFlag Then
        '    ucrDSF = DirectCast(sender, ucrDirectionSpeedFlag)
        '    For Each ctr As Control In Me.Controls
        '        If TypeOf ctr Is ucrDirectionSpeedFlag Then
        '            'TODO 
        '            'needs modification here. for hour selection functionality
        '            If Val(ctr.Tag) = Val(ucrDSF.Tag) + 1 Then
        '                If ctr.Enabled Then
        '                    ctr.Focus()
        '                End If
        '            End If
        '        End If
        '    Next
        'End If

        SelectNextControl(sender, True, True, True, True)
        'this handles the "noise" on enter key down
        e.SuppressKeyPress = True
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If checkSpeedTotal() Then
                Me.FindForm.SelectNextControl(Me, True, True, True, True)
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkSpeedTotal()
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        Dim bValidValues As Boolean = True

        'validate the values of the linked controls
        For Each key As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If Not key.ValidateValue() Then
                bValidValues = False
                Exit For
            End If
        Next

        If bValidValues Then
            fhourlyWindRecord = Nothing
            MyBase.LinkedControls_evtValueChanged()
            For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
                CallByName(fhourlyWindRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            Next
            ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. Disable??
            'Me.Enabled = False
        End If
    End Sub

    Public Sub SaveRecord()
        'This is determined by the current user not set from the form
        fhourlyWindRecord.signature = frmLogin.txtUsername.Text

        'THIS CAN NOW BE PUSHED TO clsDataConnection CLASS
        If bUpdating Then
            'clsDataConnection.db.form_hourlywind.Add(fhourlyWindRecord)
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Modified
        Else
            'clsDataConnection.db.form_hourlywind.Add(fhourlyWindRecord)
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Added
        End If

        clsDataConnection.db.SaveChanges()
    End Sub

    Public Sub DeleteRecord()
        'clsDataConnection.db.Entry(fhourlyWindRecord)
        clsDataConnection.db.form_hourlywind.Attach(fhourlyWindRecord)
        clsDataConnection.db.form_hourlywind.Remove(fhourlyWindRecord)
        clsDataConnection.db.SaveChanges()
    End Sub

    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                DirectCast(ctr, ucrTextBox).Clear()
            End If
        Next
    End Sub

    Public Sub SetHourSelection(bNewSelectAllHours As Boolean)
        Dim ucrDSF As ucrDirectionSpeedFlag
        If bNewSelectAllHours Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrDSF.Enabled = True
                    ucrDSF.SetBackColor(Color.White)
                End If
            Next
        Else
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableName("form_hourly_time_selection")
            clsDataDefinition.SetFields(New List(Of String)({"hh", "hh_selection"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrDirectionSpeedFlag Then
                        ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                        iTagVal = Val(Strings.Right(ucrDSF.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ucrDSF.Enabled = False
                            ucrDSF.SetBackColor(Color.LightYellow)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub SetDirectionDigits(iNewDirectionDigits As Integer)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).SetElementDirectionDigits(iNewDirectionDigits)
            End If
        Next
    End Sub

    Public Sub SetSpeedDigits(iNewSpeedDigits As Integer)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).SetElementSpeedDigits(iNewSpeedDigits)
            End If
        Next
    End Sub

    Public Sub SetDirectionValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        iDirectionElementId = elementId
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))
        clsDataDefinition.SetFilter("elementId", "=", elementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    If dtbl.Rows(0).Item("lowerLimit") <> "" Then
                        ucrDSF.SetElementDirectionValidation(iLowerLimit:=Val(dtbl.Rows(0).Item("lowerLimit")))
                    End If
                    If dtbl.Rows(0).Item("upperLimit") <> "" Then
                        ucrDSF.SetElementDirectionValidation(iUpperLimit:=Val(dtbl.Rows(0).Item("upperLimit")))
                    End If
                End If
            Next
        End If
    End Sub

    Public Sub SetSpeedValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        iSpeedElementId = elementId
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", elementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    If dtbl.Rows(0).Item("lowerLimit") <> "" Then
                        ucrDSF.SetElementSpeedValidation(iLowerLimit:=Val(dtbl.Rows(0).Item("lowerLimit")))
                    End If
                    If dtbl.Rows(0).Item("upperLimit") <> "" Then
                        ucrDSF.SetElementSpeedValidation(iUpperLimit:=Val(dtbl.Rows(0).Item("upperLimit")))
                    End If
                End If
            Next
            bSpeedTotalRequired = If(dtbl.Rows(0).Item("qcTotalRequired") <> "" AndAlso Val(dtbl.Rows(0).Item("qcTotalRequired") <> 0), True, False)
        End If
    End Sub

    ''' <summary>
    ''' Returns true if all the direction values are empty and false if ANY has a value set
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDirectionValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).IsElementDirectionEmpty() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Returns true if all the speed values are empty and false if ANY has a value set
    ''' </summary>
    ''' <returns></returns>
    Public Function IsSpeedValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).IsElementSpeedEmpty Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function


    ''' <summary>
    ''' returns true if all direction values are valid and false if any of them is not valid
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).ValidateValue Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' will check the expected total if its indicated as required in the obselements table
    ''' returns true if the expected total speed value = computed total speed value or when the speed total is not required
    ''' </summary>
    ''' <returns></returns>
    Public Function checkSpeedTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Integer = 0
        Dim expectedTotal As Integer

        If bSpeedTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsSpeedValuesEmpty() Then
                MessageBox.Show("Please enter the Total Value in the (Total [ff]) textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Red)
                bValueCorrect = False
            Else
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrDirectionSpeedFlag Then
                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrDirectionSpeedFlag).GetElementSpeedValue)
                    End If
                Next
                bValueCorrect = (elemTotal = expectedTotal)
                If Not bValueCorrect Then
                    MessageBox.Show("Value in (Total [ff]) textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                End If
            End If
        Else
            bValueCorrect = True
        End If

        Return bValueCorrect
    End Function

    ''' <summary>
    ''' Sets the controls used by this control station,year,month,day and ucrNavigation controls 
    ''' </summary>
    ''' <param name="ucrStationControl"></param>
    ''' <param name="ucrYearControl"></param>
    ''' <param name="ucrMonthControl"></param>
    ''' <param name="ucrDayControl"></param>
    ''' <param name="ucrNavigationControl"></param>
    Public Sub SetKeyControls(ucrStationControl As ucrStationSelector, ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth, ucrDayControl As ucrDay, ucrNavigationControl As ucrNavigation)
        ucrLinkedStation = ucrStationControl
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        ucrLinkedDay = ucrDayControl
        ucrLinkedNavigation = ucrNavigationControl

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)

        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "yyyy", "mm", "dd"})))
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("dd", ucrLinkedDay)
    End Sub

    ''' <summary>
    ''' checks the selected year month day to permit entry or not.
    ''' this prevents data entry of current and future dates
    ''' </summary>
    Private Sub ValidateDataEntryPermission()
        'if its an update or any of the linked year,month and day selector is nothing then just exit the sub
        If bUpdating OrElse ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
            Me.Enabled = True
        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue AndAlso ucrLinkedDay.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values to Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

            'if selectedDate  is earlier than todayDate (<0)  then its a valid date for data entry
            'if it is same time (0) or later than (>0) then its invalid, disable control
            Me.Enabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
        Else
            Me.Enabled = False
        End If
    End Sub

    Public Sub UploadAllRecords()
        Dim clsAllRecordsCall As New DataCall
        Dim dtbAllRecords As DataTable
        Dim rcdObservationInitial As observationinitial
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strTag As String
        Dim iElementId As Long
        Dim lstAllFields As New List(Of String)

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        For Each row As DataRow In dtbAllRecords.Rows
            For Each strFieldName As String In lstFields
                'if its not an observation direction or speed value field then skip the loop
                If strFieldName.StartsWith(Me.strDirectionFieldName) Then
                    iElementId = iDirectionElementId
                    strTag = strFieldName.Substring(Me.strDirectionFieldName.Length)
                ElseIf strFieldName.StartsWith(Me.strSpeedFieldName) Then
                    iElementId = iSpeedElementId
                    strTag = strFieldName.Substring(Me.strSpeedFieldName.Length)
                Else
                    Continue For
                End If

                strValueColumn = strFieldName
                strFlagColumn = lstFields.Find(Function(x As String)
                                                   Return x.Equals(Me.strFlagFieldName & strTag)
                                               End Function)

                'set the record
                If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) Then
                    rcdObservationInitial = New observationinitial
                    rcdObservationInitial.recordedFrom = row.Item("stationId")
                    rcdObservationInitial.describedBy = iElementId
                    Try
                        rcdObservationInitial.obsDatetime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), row.Item("hh"), 0, 0)
                    Catch ex As Exception
                    End Try
                    rcdObservationInitial.obsLevel = "surface"
                    rcdObservationInitial.obsValue = row.Item(strValueColumn)
                    rcdObservationInitial.flag = row.Item(strFlagColumn)
                    rcdObservationInitial.qcStatus = 0
                    rcdObservationInitial.acquisitionType = 1
                    rcdObservationInitial.dataForm = strTableName

                    If Not IsDBNull(row.Item("signature")) Then
                        rcdObservationInitial.capturedBy = row.Item("signature")
                    End If

                    clsDataConnection.db.observationinitials.Add(rcdObservationInitial)
                End If
            Next
        Next

        'save the Observation record
        clsDataConnection.SaveUpdate()
    End Sub

End Class