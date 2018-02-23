
Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrFormDaily2

    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_daily2"
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private strTotalFieldName As String = "total"
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedUnits As New Dictionary(Of String, ucrDataLinkCombobox)
    Private lstTempFields As New List(Of String)
    Public fd2Record As form_daily2
    Public bUpdating As Boolean = False

    Public Overrides Sub PopulateControl()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox
        Dim clsCurrentFilter As TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()
            If fd2Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_daily2.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fd2Record = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fd2Record = New form_daily2
                    bUpdating = False
                End If
            End If
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.PopulateControl()
                ElseIf TypeOf ctr Is ucrTextBox Then
                    ctrTotal = ctr
                    ctrTotal.PopulateControl()
                End If
            Next
        End If
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        If bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag, strPeriodFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strFlagFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strPeriodFieldName & ctrVFP.Tag)

                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrPeriod.evtValueChanged, AddressOf InnerControlValueChanged

                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl

                ElseIf TypeOf ctr Is ucrTextBox Then
                    ctrTotal = ctr
                    ctrTotal.SetTableName(strTableName)
                    ctrTotal.SetField(strTotalFieldName)
                    lstTempFields.Add(strTotalFieldName)
                    AddHandler ctrTotal.evtValueChanged, AddressOf InnerControlValueChanged

                End If
            Next
            SetTableName(strTableName)
            SetFields(lstTempFields)
            bFirstLoad = False
            EnableDaysofMonth()
        End If

    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
            ElseIf TypeOf ctr Is ucrTextBox Then
                ctrTotal = ctr
                ctrTotal.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
            End If
        Next
        If Not lstTempFields.Contains(tblFilter.GetField) Then
            lstTempFields.Add(tblFilter.GetField)
            SetFields(lstTempFields)
        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            ctr = sender
            CallByName(fd2Record, ctr.GetField, CallType.Set, ctr.GetValue)
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
        fd2Record = Nothing
        MyBase.LinkedControls_evtValueChanged()
        EnableDaysofMonth()

        'Dim ctr As Control
        'Dim ctrVFP As New ucrValueFlagPeriod
        'Dim ctrTotal As New ucrTextBox
        'For Each ctr In Me.Controls
        '    If TypeOf ctr Is ucrValueFlagPeriod Then
        '        ctrVFP = ctr
        '        CallByName(fd2Record, strValueFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrValue.GetValue)
        '        CallByName(fd2Record, strFlagFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrFlag.GetValue)
        '        CallByName(fd2Record, strPeriodFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrPeriod.GetValue)
        '    ElseIf TypeOf ctr Is ucrTextBox Then
        '        ctrTotal = ctr
        '        CallByName(fd2Record, strTotalFieldName, CallType.Set, ctrTotal.GetValue)
        '    End If

        'Next

        For Each kvp In dctLinkedControlsFilters
            CallByName(fd2Record, kvp.Value.Value.GetField, CallType.Set, kvp.Key.GetValue)
        Next

    End Sub

    Private Sub EnableDaysofMonth()
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim lstShortMonths As New List(Of String)({4, 6, 9, 11})
        Dim iMonthLength As Integer
        Dim iMonth As Integer

        If ucrLinkedMonth Is Nothing Then
            iMonth = 1
        Else
            iMonth = ucrLinkedMonth.GetValue()
        End If

        If iMonth = 2 Then
            If Not DateTime.IsLeapYear(ucrLinkedYear.GetValue) Then
                iMonthLength = 28
            Else
                iMonthLength = 29
            End If
        Else
            If lstShortMonths.Contains(iMonth) Then
                iMonthLength = 30
            Else
                iMonthLength = 31
            End If
        End If

        For Each ctrVFP In {ucrValueFlagPeriod29, ucrValueFlagPeriod30, ucrValueFlagPeriod31}
            If ctrVFP.Tag <= iMonthLength Then
                ctrVFP.Enabled = True
            Else
                ctrVFP.Enabled = False
            End If
        Next
    End Sub

    Public Sub SetYearAndMonthLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
    End Sub

    Public Sub AddUnitslink(strFieldName As String, ucrComboBox As ucrDataLinkCombobox)

        If ucrLinkedUnits.ContainsKey(strFieldName) Then
            ucrLinkedUnits.Add(strFieldName, ucrComboBox)
        Else
            MessageBox.Show("Developer error: This field is already linked.", caption:="Developer error")
        End If

        If Not lstTempFields.Contains(strFieldName) Then
            lstTempFields.Add(strFieldName)
            SetFields(lstTempFields)
            PopulateControl()
        End If

        AddHandler ucrComboBox.evtValueChanged, AddressOf LinkedControls_evtValueChanged

    End Sub

    Public Sub Clear()

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

    Public Sub checkTotal()
        'Check total if required
        ' Am not sure how to get this value yet
        'If totalRequired = 1 Then

        Dim elemTotal As Integer = 0
        Dim expectedTotal As Integer
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod

        expectedTotal = ucrInputTotal.GetValue

        For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    elemTotal = elemTotal + ctrVFP.ucrValue.GetValue
                End If
            Next

        If elemTotal <> expectedTotal Then
            MessageBox.Show("Value in [Total] textbox is different from that calculated by computer!", caption:="Error in total")
            ucrInputTotal.txtBox.Focus()
            ucrInputTotal.txtBox.BackColor = Color.Cyan
        End If
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub
End Class
