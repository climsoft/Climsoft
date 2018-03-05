Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrSynopticDataManyElements
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_synoptic_2_RA1"
    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"
    Public bUpdating As Boolean = False
    Public fs2ra1Record As form_synoptic_2_ra1
    Private lstValueFlagPeriodControls As List(Of ucrValueFlagPeriod)
    Private lstFields As New List(Of String)

    Public Overrides Sub PopulateControl()
        Dim ctr As New Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()
            If fs2ra1Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_synoptic_2_ra1.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fs2ra1Record = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fs2ra1Record = New form_synoptic_2_ra1
                    bUpdating = False
                End If
            End If
        End If
        For Each ucrVFP As ucrValueFlagPeriod In lstValueFlagPeriodControls
            ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
        Next
    End Sub

    Private Sub ucrSynopticDataManyElements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim lstTempFields As New List(Of String)

        If bFirstLoad Then
            lstValueFlagPeriodControls = New List(Of ucrValueFlagPeriod)
            For Each ctr In Me.Controls
                ctrVFP.ucrPeriod.Visible = False
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    lstValueFlagPeriodControls.Add(ctr)
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ctrVFP.Tag)
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName:=strValueFieldName & ctrVFP.Tag, strFlagFieldName:=strFlagFieldName & ctrVFP.Tag)
                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                End If
            Next
            SetTableName(strTableName)
            SetFields(lstTempFields)
            bFirstLoad = False
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            ctr = sender
            CallByName(fs2ra1Record, ctr.GetField, CallType.Set, ctr.GetValue)
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
    End Sub

    Public Overrides Sub Clear()
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
