Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrHourly
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourly"
    Private strValueFieldName As String = "hh"
    Private strFlagFieldName As String = "flag"
    Private strTotalFieldName As String = "total"
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedday As ucrDay
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedUnits As New Dictionary(Of String, ucrDataLinkCombobox)
    Private lstTempFields As New List(Of String)
    Public fhRecord As form_hourly
    Public bUpdating As Boolean = False

    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        If bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & "_" & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strValueFieldName & "_" & ctrVFP.Tag)
                    lstTempFields.Add(strFlagFieldName & ctrVFP.Tag)

                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged


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
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim ctr As Control
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

        For Each kvp In dctLinkedControlsFilters
            CallByName(fhRecord, kvp.Value.Value.GetField, CallType.Set, kvp.Key.GetValue)
        Next

    End Sub

    Public Sub SetYearMonthAndDayLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth, ucrDayControl As ucrDay)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        ucrLinkedday = ucrDayControl
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

    Private Sub UcrValueFlagPeriod131_Load(sender As Object, e As EventArgs) Handles UcrValueFlagPeriod21.Load

    End Sub
End Class

