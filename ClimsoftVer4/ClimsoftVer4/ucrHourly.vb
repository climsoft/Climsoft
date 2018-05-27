Imports System.Linq.Dynamic

Public Class ucrHourly
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourly"
    Private strValueFieldName As String = "hh"
    Private strFlagFieldName As String = "flag"
    Private strTotalFieldName As String = "total"
    Private lstFields As New List(Of String)
    Public fhRecord As form_hourly
    Public bUpdating As Boolean = False
    Private lstValueFlagPeriodControls As List(Of ucrValueFlagPeriod)
    Private lstTextboxControls As List(Of ucrTextBox)
    Private ucrLinkedNavigation As ucrNavigation
    Private ElementId As Integer
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay
    Private ucrLinkedStation As ucrStationSelector
    Private ucrlinkedElement As ucrElementSelector

    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        If bFirstLoad Then
            lstValueFlagPeriodControls = New List(Of ucrValueFlagPeriod)
            lstTextboxControls = New List(Of ucrTextBox)
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then

                    lstValueFlagPeriodControls.Add(ctr)
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & "_" & ctrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ctrVFP.Tag)
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & "_" & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag)

                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl


                ElseIf TypeOf ctr Is ucrTextBox Then
                    lstTextboxControls.Add(ctr)
                    ctrTotal = ctr
                    ctrTotal.SetTableName(strTableName)
                    ctrTotal.SetField(strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ctrTotal.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next
            SetTableName(strTableName)
            SetFields(lstFields)
            bFirstLoad = False

            ctrVFP.ucrValue.SetValidationTypeAsNumeric()
            ctrVFP.ucrFlag.SetTextToUpper()
        End If
    End Sub
    ''' <summary>
    ''' Sets the values of the controls to the coresponding record values in the database with the current key
    ''' </summary>
    Public Overrides Sub PopulateControl()
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()
            If fhRecord Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_hourly.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fhRecord = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fhRecord = New form_hourly
                    bUpdating = False
                End If
                ValidateDataEntryPermision()
            End If
            For Each ucrVFP As ucrValueFlagPeriod In lstValueFlagPeriodControls
                ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & "_" & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
            Next
            For Each ucrText As ucrTextBox In lstTextboxControls
                ucrText.SetValue(GetValue(strTotalFieldName))
            Next
        End If
    End Sub

    '''' <summary>
    '''' Sets the linked navigation control 
    '''' </summary>
    '''' <param name="ucrNewNavigation"></param>
    'Public Sub SetLinkedNavigation(ucrNewNavigation As ucrNavigation)
    '    ucrLinkedNavigation = ucrNewNavigation
    'End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            ctr = sender
            CallByName(fhRecord, ctr.GetField, CallType.Set, ctr.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod

        If TypeOf sender Is ucrValueFlagPeriod Then
            ctrVFP = sender
            For Each ctr In Me.Controls
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

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'need an if statement that checks for changes 
        fhRecord = Nothing
        MyBase.LinkedControls_evtValueChanged()

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            CallByName(fhRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next
        ucrLinkedNavigation.UpdateNavigationByKeyControls()
        SetValueValidation()
    End Sub
    ''' <summary>
    ''' Clears all the text In the ucrValueFlagPeriod controls 
    ''' </summary>
    Public Overrides Sub Clear()
        Dim ctr As Control
        Dim ctrTotal As ucrTextBox
        Dim ctrVFP As New ucrValueFlagPeriod
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                ctrTotal = ctr
                ctrTotal.Clear()
            End If
        Next
    End Sub
    ''' <summary>
    ''' Checks if total for current element is required
    ''' Checks if the computed total is same as the user entered total.
    ''' </summary>
    Public Sub checkTotal()
        'Check total if required from obselements table from qcTotalRequired field
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim elemTotal As Integer = 0
        Dim expectedTotal As Integer
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", ElementId, bIsPositiveCondition:=True, bForceValuesAsString:=False)

        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            If dtbl.Rows(0).Item("qcTotalRequired") = 1 Then
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        ctrVFP = ctr
                        elemTotal = elemTotal + Val(ctrVFP.ucrValue.GetValue)
                    End If
                Next
                If elemTotal <> expectedTotal Then
                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer!", caption:="Error in total")
                    ucrInputTotal.GetFocus()
                    ucrInputTotal.SetBackColor(Color.Cyan)
                End If
            End If
        End If
    End Sub
    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub
    ''' <summary>
    ''' Sets upper and lower limits validation curent element
    ''' </summary>
    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        clsDataDefinition = New DataCall

        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))

        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrElementSelector Then
                ElementId = Val(ucrKeyControl.GetValue)
                Exit For
            End If
        Next
        clsDataDefinition.SetFilter("elementId", "=", ElementId, bIsPositiveCondition:=True, bForceValuesAsString:=False)

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
        End If
    End Sub
    ''' <summary>
    ''' Sets the Key controls
    ''' </summary>
    ''' <param name="ucrYear"></param>
    ''' <param name="ucrMonth"></param>
    ''' <param name="ucrDay"></param>
    Public Sub SetKeyControls(ucrYear As ucrYearSelector, ucrMonth As ucrMonth, ucrDay As ucrDay, ucrStation As ucrStationSelector, ucrElement As ucrElementSelector, ucrNavigation As ucrNavigation)
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
        ucrLinkedNavigation.SetTableNameAndFields("form_hourly", (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "dd"})))
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("elementId", ucrlinkedElement)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("dd", ucrLinkedDay)
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    Private Sub ValidateDataEntryPermision()
        Dim TodaysDate As Date
        Dim SelectedDate As Date

        If bUpdating OrElse ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
            Exit Sub
        End If

        TodaysDate = New Date(Date.Now.Year, Date.Now.Month, Date.Now.Day)
        SelectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

        If Date.Compare(SelectedDate, TodaysDate) < 0 Then
            Me.Enabled = True
        Else
            Me.Enabled = False
        End If
    End Sub

End Class

