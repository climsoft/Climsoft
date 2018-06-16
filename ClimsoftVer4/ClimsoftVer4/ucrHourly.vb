Imports System.Linq.Dynamic

Public Class ucrHourly
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourly"
    Private strValueFieldName As String = "hh_"
    Private strFlagFieldName As String = "flag"
    Private strTotalFieldName As String = "total"
    Private lstFields As New List(Of String)
    Public fhRecord As form_hourly
    Public bUpdating As Boolean = False
    Private ucrLinkedNavigation As ucrNavigation
    Private bTotalRequired As Boolean
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay
    Private ucrLinkedStation As ucrStationSelector
    Private ucrlinkedElement As ucrElementSelector

    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ucrVFP As ucrValueFlagPeriod
        Dim ucrText As ucrTextBox

        If bFirstLoad Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & ucrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ucrVFP.Tag)
                    ucrVFP.ucrPeriod.Visible = False
                    ucrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & ucrVFP.Tag, strFlagFieldName & ucrVFP.Tag)
                    AddHandler ucrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
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
    ''' <summary>
    ''' Sets the values of the controls to the coresponding record values in the database with the current key
    ''' </summary>
    Public Overrides Sub PopulateControl()
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()
            If fhRecord Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                fhRecord = clsDataConnection.db.form_hourly.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fhRecord Is Nothing Then
                    fhRecord = New form_hourly
                    bUpdating = False
                Else
                    bUpdating = True
                End If
                'enable or disable textboxes based on year month day
                ValidateDataEntryPermission()
            End If

            'change the validation of the controls
            SetValueValidation()

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetValue(strValueFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrTextBox).SetValue(GetValue(strTotalFieldName))
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

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrText As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrText = DirectCast(sender, ucrTextBox)
            CallByName(fhRecord, ucrText.GetField, CallType.Set, ucrText.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As KeyEventArgs)
        'Dim ctrVFP As ucrValueFlagPeriod

        'If TypeOf sender Is ucrValueFlagPeriod Then
        '    ctrVFP = sender
        '    For Each ctr As Control In Me.Controls
        '        If TypeOf ctr Is ucrValueFlagPeriod Then
        '            If ctr.Tag = ctrVFP.Tag + 1 Then
        '                If ctr.Enabled Then
        '                    ctr.Focus()
        '                End If
        '            End If
        '        End If
        '    Next
        'End If
        'Dim ctrTemp As Control
        'Dim i As Integer = 0
        'ctrTemp = sender
        'While i < Me.Controls.Count
        '    ctrTemp = GetNextControl(ctrTemp, True)
        '    i = i + 1
        '    If TypeOf ctrTemp Is ucrValueFlagPeriod OrElse TypeOf ctrTemp Is ucrTextBox Then
        '        If ctrTemp.Enabled Then
        '            'ctrTemp.Focus()
        '        Else

        '        End If
        '        If TypeOf ctrTemp Is ucrValueFlagPeriod Then
        '            SelectNextControl(ActiveControl, True, True, True, True)
        '        End If
        '        Exit While
        '    End If
        'End While

        'Dim ctrTemp As Control
        'Dim i As Integer = 0
        'ctrTemp = sender
        'ctrTemp = GetNextControl(ctrTemp, True)

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

        'validate the values of the linked controls
        For Each key As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If Not key.ValidateValue() Then
                bValidValues = False
                Exit For
            End If
        Next

        If bValidValues Then
            fhRecord = Nothing
            MyBase.LinkedControls_evtValueChanged()

            For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
                CallByName(fhRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            Next
            ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. DISABLE??
            'Me.Enabled = False
        End If
    End Sub

    Public Sub SaveRecord()
        'This is determined by the current user not set from the form
        fhRecord.signature = frmLogin.txtUsername.Text

        If bUpdating Then
            clsDataConnection.db.Entry(fhRecord).State = Entity.EntityState.Modified
        Else
            clsDataConnection.db.Entry(fhRecord).State = Entity.EntityState.Added
        End If
        clsDataConnection.db.SaveChanges()
    End Sub

    Public Sub DeleteRecord()
        'clsDataConnection.db.Entry(fhRecord)
        clsDataConnection.db.form_hourly.Attach(fhRecord)
        clsDataConnection.db.form_hourly.Remove(fhRecord)
        clsDataConnection.db.SaveChanges()
    End Sub

    ''' <summary>
    ''' Clears all the text In the ucrValueFlagPeriod controls 
    ''' </summary>
    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrDirectionSpeedFlag).Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                DirectCast(ctr, ucrTextBox).Clear()
            End If
        Next
    End Sub

    Public Sub SetSynopticHourSelectionOnly(bNewSelectAllHours As Boolean)
        Dim ctrVFP As ucrValueFlagPeriod
        If bNewSelectAllHours Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.Enabled = True
                    ctrVFP.SetBackColor(Color.White)
                End If
            Next
        Else
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableNameAndFields("form_hourly_time_selection", New List(Of String)({"hh", "hh_selection"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                        iTagVal = Val(Strings.Right(ctrVFP.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ctrVFP.Enabled = False
                            ctrVFP.SetBackColor(Color.LightYellow)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub SetSameValueToAllObsElements(bNewValue As String)
        Dim ucrVFP As ucrValueFlagPeriod
        'Adds values to only enabled controls of the ucrHourly
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If ctr.Enabled Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetElementValue(bNewValue)
                    If Not ucrVFP.IsValuesValid() Then
                        Exit Sub
                    End If
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Sets upper and lower limits validation curent selected element and sets if the checking total is requred
    ''' </summary>
    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim iElementId As Integer

        iElementId = ucrlinkedElement.GetValue
        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", iElementId, bIsPositiveCondition:=True, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    If dtbl.Rows(0).Item("lowerLimit") <> "" Then
                        ucrVFP.SetElementValueValidation(iLowerLimit:=Val(dtbl.Rows(0).Item("lowerLimit")))
                    End If
                    If dtbl.Rows(0).Item("upperLimit") <> "" Then
                        ucrVFP.SetElementValueValidation(iUpperLimit:=Val(dtbl.Rows(0).Item("upperLimit")))
                    End If
                End If
            Next
            bTotalRequired = If(dtbl.Rows(0).Item("qcTotalRequired") <> "" AndAlso Val(dtbl.Rows(0).Item("qcTotalRequired") <> 0), True, False)
        End If
    End Sub

    ''' <summary>
    ''' checks if all the ucrValueFlagPeriod controls have a value.
    ''' Returns true if they are all empty and false if otherwise
    ''' </summary>
    ''' <returns></returns>
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
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If Not DirectCast(ctr, ucrValueFlagPeriod).IsValuesValid Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Checks if total for current element is required
    ''' Checks if the computed total is same as the user entered total.
    ''' </summary>
    Public Function checkTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Integer = 0
        Dim expectedTotal As Integer

        If bTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsValuesEmpty() Then
                MessageBox.Show("Please enter the Total Value in the [Total] textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Cyan)
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
    ''' Sets the Key controls
    ''' </summary>
    ''' <param name="ucrYear"></param>
    ''' <param name="ucrMonth"></param>
    ''' <param name="ucrDay"></param>
    Public Sub SetKeyControls(ucrStation As ucrStationSelector, ucrElement As ucrElementSelector, ucrYear As ucrYearSelector, ucrMonth As ucrMonth, ucrDay As ucrDay, ucrNavigation As ucrNavigation)
        ucrLinkedYear = ucrYear
        ucrLinkedMonth = ucrMonth
        ucrLinkedDay = ucrDay
        ucrLinkedStation = ucrStation
        ucrlinkedElement = ucrElement
        ucrLinkedNavigation = ucrNavigation

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrlinkedElement, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)

        'setting the key contols for the Navigation control 
        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "dd"})))
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("elementId", ucrlinkedElement)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("dd", ucrLinkedDay)
    End Sub

    Private Sub ValidateDataEntryPermission()
        'if its an update or any of the linked year,month and day selector is nothing then just enable the control
        If bUpdating OrElse ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
            Me.Enabled = True
        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue AndAlso ucrLinkedDay.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values. Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

            'if selectedDate is earlier than todayDate (<0) enable control
            'if it is same time (0) or later than (>0) disable control
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
        Dim hh As Integer
        Dim lstAllFields As New List(Of String)

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        For Each row As DataRow In dtbAllRecords.Rows
            For Each strFieldName As String In lstFields
                'if its not an observation value field then skip the loop
                If Not strFieldName.StartsWith(Me.strValueFieldName) Then
                    Continue For
                End If

                strValueColumn = strFieldName
                'set the record
                If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(row.Item("elementId"), iElementId) Then

                    strTag = strFieldName.Substring(Me.strValueFieldName.Length)
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strTag)
                                                   End Function)

                    rcdObservationInitial = New observationinitial
                    rcdObservationInitial.recordedFrom = row.Item("stationId")
                    rcdObservationInitial.describedBy = iElementId

                    Try
                        hh = Integer.Parse(strTag)
                        rcdObservationInitial.obsDatetime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)
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

