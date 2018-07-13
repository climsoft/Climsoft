Imports System.Linq.Dynamic

Public Class ucrFormDaily2
    'Boolean to check if control is loading for first time
    Private bFirstLoad As Boolean = True
    'sets table name assocaited with this user control
    Private strTableName As String = "form_daily2"
    'These store field names for value, flag and period
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private strTotalFieldName As String = "total"
    Private bTotalRequired As Boolean
    'Stores fields for the value flag and period
    Private lstFields As New List(Of String)
    'Stores the record assocaited with this control
    Public fd2Record As form_daily2
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True
    'stores a list containing all fields of this control
    Private lstAllFields As New List(Of String)

    'These store instances of linked controls
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedYear As ucrYearSelector
    Private dctLinkedUnits As New Dictionary(Of String, ucrDataLinkCombobox)
    Private ucrLinkedHour As ucrHour
    Private ucrLinkedNavigation As ucrNavigation
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedElement As ucrElementSelector

    Dim vfpContextMenuStrip As ContextMenuStrip

    ''' <summary>
    ''' Sets the values of the controls to the coresponding record values in the database with the current key
    ''' </summary>
    Public Overrides Sub PopulateControl()
        Dim clsCurrentFilter As TableFilter
        Dim tempRecord As form_daily2

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'try to get the record based on the given filter
            clsCurrentFilter = GetLinkedControlsFilter()
            tempRecord = clsDataConnection.db.form_daily2.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()

            'if this was already a new record (Is Nothing AndAlso Not bUpdating) 
            'then just do validation of values based on the new key controls values and exit the sub
            If tempRecord Is Nothing AndAlso Not bUpdating Then
                ValidateDataEntryPermission()
                SetValueValidation()
                ValidateValue()
                Exit Sub
            End If

            fd2Record = tempRecord
            If fd2Record Is Nothing Then
                fd2Record = New form_daily2
                bUpdating = False
            Else
                'Detach this from the EF context to prevent it from tracking the changes made to it
                clsDataConnection.db.Entry(fd2Record).State = Entity.EntityState.Detached
                bUpdating = True
            End If

            'check whether to permit data entry based on date entry values
            ValidateDataEntryPermission()

            'set the validation of the controls
            SetValueValidation()

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetValue(strValueFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag), GetValue(strPeriodFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrTextBox).SetValue(GetValue(strTotalFieldName))
                End If
            Next

            'set values for the units
            If bUpdating Then
                For Each kvpTemp As KeyValuePair(Of String, ucrDataLinkCombobox) In dctLinkedUnits
                    kvpTemp.Value.SetValue(GetValue(kvpTemp.Key))
                Next
            Else
                For Each ucrCombobox As ucrDataLinkCombobox In dctLinkedUnits.Values
                    ucrCombobox.SelectFirst()
                Next
            End If

            OnevtValueChanged(Me, Nothing)

        End If
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ucrVFP As ucrValueFlagPeriod
        Dim ucrTotal As ucrTextBox

        If bFirstLoad Then
            Me.vfpContextMenuStrip = SetUpContextMenuStrip()

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & ucrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ucrVFP.Tag)
                    lstFields.Add(strPeriodFieldName & ucrVFP.Tag)

                    ucrVFP.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName:=strValueFieldName & ucrVFP.Tag, strFlagFieldName:=strFlagFieldName & ucrVFP.Tag, strPeriodFieldName:=strPeriodFieldName & ucrVFP.Tag)

                    AddHandler ucrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrPeriod.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl

                    ucrVFP.SetContextMenuStrip(Me.vfpContextMenuStrip)

                ElseIf TypeOf ctr Is ucrTextBox Then
                    ucrTotal = DirectCast(ctr, ucrTextBox)
                    ucrTotal.SetTableNameAndField(strTableName, strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ucrTotal.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next

            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If

    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrText As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrText = DirectCast(sender, ucrTextBox)
            CallByName(fd2Record, ucrText.GetField, CallType.Set, ucrText.GetValue)
        ElseIf TypeOf sender Is ucrDataLinkCombobox Then
            For Each kvpTemp As KeyValuePair(Of String, ucrDataLinkCombobox) In dctLinkedUnits
                'overwrite the specific unit value
                If sender Is kvpTemp.Value Then
                    CallByName(fd2Record, kvpTemp.Key, CallType.Set, kvpTemp.Value.GetValue)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As KeyEventArgs)
        'Dim ctr As Control
        'Dim ctrVFP As New ucrValueFlagPeriod

        'If TypeOf sender Is ucrValueFlagPeriod Then
        '    ctrVFP = sender
        '    For Each ctr In Me.Controls
        '        If TypeOf ctr Is ucrValueFlagPeriod Then
        '            If ctr.Tag = ctrVFP.Tag + 1 Then
        '                If ctr.Enabled Then
        '                    ctr.Focus()
        '                End If
        '            End If
        '            If ctrVFP.Tag = iMonthLength Then
        '                ucrInputTotal.GetFocus()
        '            End If
        '        End If
        '    Next
        'End If

        SelectNextControl(sender, True, True, True, True)
        'this handles the "noise" on enter  
        e.SuppressKeyPress = True
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If checkTotal() Then
                Me.FindForm.SelectNextControl(sender, True, True, True, True)
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        Dim bValidValues As Boolean = True

        'validate the values of the linked key filter controls
        For Each key As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If Not key.ValidateValue() Then
                bValidValues = False
                Exit For
            End If
        Next

        If bValidValues Then
            'fd2Record = Nothing
            MyBase.LinkedControls_evtValueChanged()

            For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
                CallByName(fd2Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            Next
            ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. DISABLE??
            'Me.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Sets the  filed name and the control for the liked units
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <param name="ucrComboBox"></param>
    Public Sub AddUnitslink(strFieldName As String, ucrComboBox As ucrDataLinkCombobox)
        If dctLinkedUnits.ContainsKey(strFieldName) Then
            MessageBox.Show("Developer error: This field is already linked.", caption:="Developer error")
        Else
            dctLinkedUnits.Add(strFieldName, ucrComboBox)
            AddHandler ucrComboBox.evtValueChanged, AddressOf InnerControlValueChanged
            'add the field
            If Not lstFields.Contains(strFieldName) Then
                lstFields.Add(strFieldName)
                SetFields(lstFields)
            End If
        End If
    End Sub

    Public Sub SaveRecord()
        'This is determined by the current user not set from the form
        fd2Record.signature = frmLogin.txtUsername.Text

        If bUpdating Then
            clsDataConnection.db.Entry(fd2Record).State = Entity.EntityState.Modified
        Else
            clsDataConnection.db.Entry(fd2Record).State = Entity.EntityState.Added
        End If

        clsDataConnection.db.SaveChanges()
        'detach the record to prevent caching of records on the EF
        clsDataConnection.db.Entry(fd2Record).State = Entity.EntityState.Detached
    End Sub

    Public Sub DeleteRecord()
        clsDataConnection.db.form_daily2.Attach(fd2Record)
        clsDataConnection.db.form_daily2.Remove(fd2Record)
        clsDataConnection.db.SaveChanges()
    End Sub

    ''' <summary>
    ''' Clears all the text In the ucrValueFlagPeriod controls 
    ''' </summary>
    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrValueFlagPeriod).Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                DirectCast(ctr, ucrTextBox).Clear()
            End If
        Next
    End Sub

    Public Sub SetSameValueToAllObsElements(bNewValue As String)
        Dim ucrVFP As ucrValueFlagPeriod
        'Adds values to only enabled controls of the ucrHourly
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If ctr.Enabled Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetElementValue(bNewValue)
                    If Not ucrVFP.ValidateValue() Then
                        Exit Sub
                    End If
                End If
            End If
        Next
    End Sub

    Public Function IsValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If Not DirectCast(ctr, ucrValueFlagPeriod).IsElementValueEmpty() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' checks if all the ucrValueFlagPeriod controls have a Valid value.
    ''' Returns true if they are all valid and false if any has Invalid value
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        Dim bValidValues As Boolean = True
        Dim ucrVFP As ucrValueFlagPeriod = Nothing

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                If Not ucrVFP.ValidateValue() Then
                    bValidValues = False
                End If
            End If
        Next

        If ucrVFP IsNot Nothing Then
            ucrVFP.Focus()
        End If

        Return bValidValues
    End Function

    Public Function checkTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Integer = 0
        Dim expectedTotal As Integer

        If bTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsValuesEmpty() Then
                MessageBox.Show("Please enter the Total Value in the [Total] textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Red)
                bValueCorrect = False
            Else
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrValueFlagPeriod).GetElementValue)
                    End If
                Next
                bValueCorrect = (elemTotal = expectedTotal)
                If Not bValueCorrect Then
                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                End If
            End If
        Else
            bValueCorrect = True
        End If

        Return bValueCorrect
    End Function

    ''' <summary>
    ''' Sets upper and lower limits validation curent element
    ''' </summary>
    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselements", New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrLinkedElement.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = dtbl.Rows(0).Item("lowerLimit")
            strUpperLimit = dtbl.Rows(0).Item("upperLimit")
            bTotalRequired = If(dtbl.Rows(0).Item("qcTotalRequired") <> "" AndAlso Val(dtbl.Rows(0).Item("qcTotalRequired")) <> 0, True, False)
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)

                If String.IsNullOrEmpty(strLowerLimit) Then
                    ucrVFP.SetElementValueLowerLimit(Decimal.MinValue)
                Else
                    ucrVFP.SetElementValueLowerLimit(Val(strLowerLimit))
                End If

                If String.IsNullOrEmpty(strUpperLimit) Then
                    ucrVFP.SetElementValueHigherLimit(Decimal.MaxValue)
                Else
                    ucrVFP.SetElementValueHigherLimit(Val(strUpperLimit))
                End If

            End If
        Next
    End Sub

    ''' <summary>
    ''' Sets the key controls
    ''' </summary>
    ''' <param name="ucrNewStation"></param>
    ''' <param name="ucrNewElement"></param>
    ''' <param name="ucrNewYear"></param>
    ''' <param name="ucrNewMonth"></param>
    ''' <param name="ucrNewHour"></param>
    ''' <param name="ucrNewNavigation"></param> 
    ''' 
    Public Sub SetKeyControls(ucrNewStation As ucrStationSelector, ucrNewElement As ucrElementSelector, ucrNewYear As ucrYearSelector, ucrNewMonth As ucrMonth, ucrNewHour As ucrHour, ucrNewNavigation As ucrNavigation)
        ucrLinkedStation = ucrNewStation
        ucrLinkedElement = ucrNewElement
        ucrLinkedYear = ucrNewYear
        ucrLinkedMonth = ucrNewMonth
        ucrLinkedHour = ucrNewHour
        ucrLinkedNavigation = ucrNewNavigation

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedElement, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)

        'Sets key controls for the navigation
        'TODO. EntryDateTime field to be added and sorting field to be set too
        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "hh"})))
        'ucrLinkedNavigation.SetSortBy("entryDatetime")
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("elementId", ucrLinkedElement)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("hh", ucrLinkedHour)

    End Sub

    Private Sub ValidateDataEntryPermission()
        Dim iMonthLength As Integer
        Dim todaysDate As Date
        Dim ctr As Control

        If ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing Then
            Me.Enabled = False
        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue Then
            todaysDate = Date.Now
            iMonthLength = Date.DaysInMonth(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue())

            If ucrLinkedYear.GetValue > todaysDate.Year OrElse (ucrLinkedYear.GetValue = todaysDate.Year AndAlso ucrLinkedMonth.GetValue > todaysDate.Month) Then
                Me.Enabled = False
            Else
                Me.Enabled = True
                If ucrLinkedYear.GetValue = todaysDate.Year AndAlso ucrLinkedMonth.GetValue = todaysDate.Month Then
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag) >= todaysDate.Day, False, True)
                        End If
                    Next
                Else
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag > iMonthLength), False, True)
                        End If
                    Next
                End If

            End If
        Else
            Me.Enabled = False
        End If
    End Sub

    Public Sub UploadAllRecords()
        Dim clsAllRecordsCall As New DataCall
        Dim dtbAllRecords As DataTable
        Dim rcdObservationInitial As observationinitial
        Dim strCurrTag As String
        Dim dtObsDateTime As Date
        Dim strStationId As String
        Dim lElementId As Long
        Dim iPeriod As Integer
        Dim lstAllFields As New List(Of String)
        Dim bNewRecord As Boolean

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        For Each row As DataRow In dtbAllRecords.Rows
            For i As Integer = 1 To 31
                If i < 10 Then
                    strCurrTag = "0" & i
                Else
                    strCurrTag = i
                End If

                If Not IsDBNull(row.Item("day" & strCurrTag)) AndAlso Not String.IsNullOrEmpty(row.Item("day" & strCurrTag)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                    strStationId = row.Item("stationId")
                    dtObsDateTime = New Date(year:=row.Item("yyyy"), month:=row.Item("mm"), day:=i, hour:=row.Item("hh"), minute:=0, second:=0)

                    rcdObservationInitial = clsDataConnection.db.observationinitials.Where("recordedFrom  == @0  And describedBy == @1 AND obsDatetime  == @2  AND qcStatus  == @3 AND acquisitionType  == @4",
                                                                         {strStationId, lElementId, dtObsDateTime, 0, 1}).FirstOrDefault()
                    If rcdObservationInitial Is Nothing Then
                        bNewRecord = True
                        rcdObservationInitial = New observationinitial
                    Else
                        bNewRecord = False
                    End If

                    rcdObservationInitial.recordedFrom = strStationId
                    rcdObservationInitial.describedBy = lElementId
                    rcdObservationInitial.obsDatetime = dtObsDateTime
                    rcdObservationInitial.obsLevel = "surface"
                    rcdObservationInitial.qcStatus = 0
                    rcdObservationInitial.acquisitionType = 1
                    rcdObservationInitial.dataForm = strTableName

                    rcdObservationInitial.obsValue = row.Item("day" & strCurrTag)
                    rcdObservationInitial.flag = row.Item("flag" & strCurrTag)
                    If Integer.TryParse(row.Item("period" & strCurrTag), iPeriod) Then
                        rcdObservationInitial.period = iPeriod
                    End If

                    If Not IsDBNull(row.Item("signature")) Then
                        rcdObservationInitial.capturedBy = row.Item("signature")
                    End If
                    If Not IsDBNull(row.Item("temperatureUnits")) Then
                        rcdObservationInitial.temperatureUnits = row.Item("temperatureUnits")
                    End If
                    If Not IsDBNull(row.Item("precipUnits")) Then
                        rcdObservationInitial.precipitationUnits = row.Item("precipUnits")
                    End If
                    If Not IsDBNull(row.Item("cloudHeightUnits")) Then
                        rcdObservationInitial.cloudHeightUnits = row.Item("cloudHeightUnits")
                    End If
                    If Not IsDBNull(row.Item("visUnits")) Then
                        rcdObservationInitial.visUnits = row.Item("visUnits")
                    End If

                    If bNewRecord Then
                        clsDataConnection.db.observationinitials.Add(rcdObservationInitial)
                    End If
                    'save the Observation record
                    clsDataConnection.db.SaveChanges()

                End If
            Next
        Next

        'TODO? because of the detachment
        PopulateControl()

    End Sub

    Private Function SetUpContextMenuStrip() As ContextMenuStrip
        Dim vfpContextMenuStrip As New ContextMenuStrip
        Dim menuItemShiftUpwards As New ToolStripMenuItem("Shift Upwards")
        Dim menuItemShiftDownwards As New ToolStripMenuItem("Shift Downwards")

        vfpContextMenuStrip.Items.Add(menuItemShiftUpwards)
        vfpContextMenuStrip.Items.Add(menuItemShiftDownwards)

        'Add functionality for ToolStripMenuItem1 (Maximize) click
        AddHandler menuItemShiftUpwards.Click, AddressOf menuItemShiftUpwards_Click

        'Add functionality for ToolStripMenuItem2 (Exit) click
        AddHandler menuItemShiftDownwards.Click, AddressOf menuItemShiftDownwards_Click

        Return vfpContextMenuStrip
    End Function

    Private Sub menuItemShiftUpwards_Click(ByVal sender As Object, ByVal e As EventArgs)
        'TODO
        If TypeOf Me.vfpContextMenuStrip.SourceControl Is TextBox Then
            Dim vfpControl = Me.vfpContextMenuStrip.SourceControl.Parent.Parent

            If TypeOf vfpControl Is ucrValueFlagPeriod Then
                'TODO Start the shifting

            End If

        End If

    End Sub

    Private Sub menuItemShiftDownwards_Click(ByVal sender As Object, ByVal e As EventArgs)
        'TODO
    End Sub

End Class
