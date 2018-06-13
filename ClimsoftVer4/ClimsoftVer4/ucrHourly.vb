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
    Private ucrLinkedNavigation As ucrNavigation
    Private bTotalRequired As Boolean
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay
    Private ucrLinkedStation As ucrStationSelector
    Private ucrlinkedElement As ucrElementSelector
    Private cmdSave As Button

    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ucrVFP As ucrValueFlagPeriod
        Dim ucrText As ucrTextBox

        If bFirstLoad Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & "_" & ucrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ucrVFP.Tag)
                    ucrVFP.ucrPeriod.Visible = False
                    ucrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & "_" & ucrVFP.Tag, strFlagFieldName & ucrVFP.Tag)
                    AddHandler ucrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl

                ElseIf TypeOf ctr Is ucrTextBox Then
                    ucrText = ctr
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
                ValidateDataEntryPermision()
            End If

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetValue(strValueFieldName & "_" & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag)}))
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
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            ctr = sender
            CallByName(fhRecord, ctr.GetField, CallType.Set, ctr.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
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

        If TypeOf sender Is ucrTextBox Then
            cmdSave.Focus()
        Else
            SelectNextControl(sender, True, True, True, True)
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
        'change the validation of the controls
        SetValueValidation()
    End Sub

    Public Sub SaveRecord()
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
    Public Function IsValuesValid() As Boolean
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

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

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
                If elemTotal = expectedTotal Then
                    bValueCorrect = True
                Else
                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                    ucrInputTotal.GetFocus()
                    bValueCorrect = False
                End If
                'bValueCorrect = (elemTotal = expectedTotal)
                'If Not bValueCorrect Then
                '    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    ucrInputTotal.SetBackColor(Color.Cyan)
                'End If

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

    Public Sub SetSaveButton(cmdNewSave As Button)
        cmdSave = cmdNewSave
    End Sub
End Class

