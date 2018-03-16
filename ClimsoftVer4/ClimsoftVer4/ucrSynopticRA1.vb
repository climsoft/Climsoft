Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrSynopticRA1
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_synoptic_2_RA1"
    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"
    Public bUpdating As Boolean = False
    Public fs2ra1Record As form_synoptic_2_ra1
    'Private lstValueFlagPeriodControls As List(Of ucrValueFlagPeriod)

    Private lstFields As New List(Of String)
    Private ucrLinkedNavigation As ucrNavigation

    Private Sub ucrSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrVFP As ucrValueFlagPeriod

        If bFirstLoad Then
            'lstValueFlagPeriodControls = New List(Of ucrValueFlagPeriod) 
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName:=strValueFieldName & ctrVFP.Tag, strFlagFieldName:=strFlagFieldName & ctrVFP.Tag)
                    'lstValueFlagPeriodControls.Add(ctrVFP)
                    lstFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ctrVFP.Tag)
                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fs2ra1Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                fs2ra1Record = clsDataConnection.db.form_synoptic_2_ra1.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fs2ra1Record Is Nothing Then
                    fs2ra1Record = New form_synoptic_2_ra1
                    bUpdating = False
                Else
                    bUpdating = True
                End If
            End If
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
                End If
            Next
            'For Each ucrVFP In lstValueFlagPeriodControls
            '    ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
            'Next
        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrTextbox As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrTextbox = DirectCast(sender, ucrTextBox)
            CallByName(fs2ra1Record, ucrTextbox.GetField, CallType.Set, ucrTextbox.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        Dim ctr As Control
        Dim ctrVFP As ucrValueFlagPeriod

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
        ucrLinkedNavigation.UpdateNavigationByKeyControls()
    End Sub

    Public Sub SetLinkedNavigation(ucrNewNavigation As ucrNavigation)
        ucrLinkedNavigation = ucrNewNavigation
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
    'This is meant to check validation of ucrVFPStationLevelPressure, not sure if this is the correct way to do this.
    'There are other validations required for other ucrVFP's similar to this.
    'Private Sub ucrVFPStationLevelPressure_Leave(sender As Object, e As EventArgs) Handles ucrVFPStationLevelPressure.Leave
    '    Dim pval As String
    '    pval = ucrVFPStationLevelPressure.ucrValue.GetValue
    '    If pval Is Nothing Then
    '        If Val(pval) < 7000 Then
    '            MsgBox("Value Lower than lowerlimit of 7000.00", MsgBoxStyle.Exclamation)
    '            ucrVFPStationLevelPressure.ucrValue.SetBackColor(Color.Cyan)
    '            ucrVFPStationLevelPressure.ucrValue.Focus()
    '        Else
    '            Exit Sub
    '        End If
    '    End If
    'End Sub
End Class
