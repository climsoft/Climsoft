Public Class ucrFormDaily2

    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_daily2"
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private strTotalFieldName As String = "total"
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedUnits As List(Of KeyValuePair(Of String, ucrDataLinkCombobox))

    Public Overrides Sub PopulateControl()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        MyBase.PopulateControl()
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.PopulateControl()
            ElseIf TypeOf ctr Is ucrTextBox Then
                ctrTotal = ctr
                ctrTotal.PopulateControl()
            End If
        Next
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox
        Dim lstTempFields As New List(Of String)

        If bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag, strPeriodFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strFlagFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strPeriodFieldName & ctrVFP.Tag)
                ElseIf TypeOf ctr Is ucrTextBox Then
                    ctrTotal = ctr
                    ctrTotal.SetTableName(strTableName)
                    ctrTotal.SetField(strTotalFieldName)
                    lstTempFields.Add(strTotalFieldName)
                End If
            Next
            SetTableName(strTableName)
            SetFields(lstTempFields)
            bFirstLoad = False
            PopulateControl()
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
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()

        MyBase.LinkedControls_evtValueChanged()
        EnableDaysofMonth()

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

        Dim bNotContained As Boolean

        If ucrLinkedUnits Is Nothing Then
            ucrLinkedUnits = New List(Of KeyValuePair(Of String, ucrDataLinkCombobox))
        End If

        bNotContained = True
        For Each kvp As KeyValuePair(Of String, ucrDataLinkCombobox) In ucrLinkedUnits
            If kvp.Key = strFieldName AndAlso kvp.Value Is ucrComboBox Then
                bNotContained = False
                Exit For
            End If
        Next

        If bNotContained Then
            ucrLinkedUnits.Add(New KeyValuePair(Of String, ucrDataLinkCombobox)(strFieldName, ucrComboBox))
        End If

    End Sub

    Public Sub Clear()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.ucrValue.Clear()
                ctrVFP.ucrFlag.Clear()
                ctrVFP.ucrPeriod.Clear()
            End If
        Next
    End Sub
End Class
