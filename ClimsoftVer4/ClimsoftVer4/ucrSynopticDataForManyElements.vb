Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrSynopticDataManyElements
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_synoptic_2_RA1"
    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"
    Private ucrLinkedMonth As New ucrMonth
    Private ucrLinkedDay As ucrDay
    Private ucrLinkedHour As ucrHour
    Private ucrLinkedYear As ucrYearSelector
    Public bUpdating As Boolean = False
    Public fs2Record As form_synoptic_2_ra1

    Public Overrides Sub PopulateControl()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        MyBase.PopulateControl()
        If Not bFirstLoad Then
            If fs2Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_synoptic_2_ra1.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fs2Record = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fs2Record = New form_synoptic_2_ra1
                    bUpdating = False
                End If
            End If
        End If
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.PopulateControl()
            End If
        Next

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            ctr = sender
            CallByName(fs2Record, ctr.GetField, CallType.Set, ctr.GetValue)
        End If
    End Sub

    Private Sub ucrSynopticDataManyElements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox
        Dim lstTempFields As New List(Of String)

        If bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strFlagFieldName & ctrVFP.Tag)

                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged

                End If
            Next
            SetTableName(strTableName)
            SetFields(lstTempFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod

        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
            End If
        Next
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        fs2Record = Nothing
        MyBase.LinkedControls_evtValueChanged()

        For Each kvp In dctLinkedControlsFilters
            CallByName(fs2Record, kvp.Value.Value.GetField, CallType.Set, kvp.Key.GetValue)
        Next
    End Sub

    Public Sub setYearMonthDayHourLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth, ucrDayControl As ucrDay, ucrHourControl As ucrHour)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        ucrLinkedDay = ucrDayControl
        ucrLinkedHour = ucrHourControl
    End Sub

    Public Sub Clear()

        Dim ctr As Control
        Dim ctrVFP As ucrValueFlagPeriod

        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.Clear()
            End If
        Next
    End Sub
End Class
