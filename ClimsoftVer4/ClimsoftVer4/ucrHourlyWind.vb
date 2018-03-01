Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourlywind"
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private strTotalFieldName As String = "total"

    'Private ucrLinkedYear As ucrYearSelector
    'Private ucrLinkedMonth As ucrMonth
    Private lstFields As New List(Of String)
    Public fd2Record As form_hourlywind
    Public bUpdating As Boolean = False

    Public Overrides Sub PopulateControl()
        Dim ucrDDFFFlag As ucrDirectionSpeedFlag
        Dim ctrTotal As ucrTextBox
        Dim clsCurrentFilter As TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fd2Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_hourlywind.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fd2Record = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fd2Record = New form_hourlywind
                    bUpdating = False
                End If
            End If

            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDDFFFlag = ctr 'TODO remove this after testing
                    ucrDDFFFlag.SetValue(New List(Of Object)({GetValue(strDirectionFieldName & ucrDDFFFlag.Tag), GetValue(strSpeedFieldName & ucrDDFFFlag.Tag), GetValue(strFlagFieldName & ucrDDFFFlag.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    ctrTotal = ctr 'TODO remove this after testing
                    ctrTotal.SetValue(GetValue(strTotalFieldName))
                End If
            Next
        End If
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ctr As Control
        Dim ctrDDFFFlag As ucrDirectionSpeedFlag
        Dim ctrTotal As ucrTextBox

        If bFirstLoad Then
            'lstValueFlagPeriodControls = New List(Of ucrValueFlagPeriod)
            'lstTextboxControls = New List(Of ucrTextBox)
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    'lstValueFlagPeriodControls.Add(ctr)
                    'ctrVFP = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ctrDDFFFlag = ctr
                    lstFields.Add(strDirectionFieldName & ctrDDFFFlag.Tag)
                    lstFields.Add(strSpeedFieldName & ctrDDFFFlag.Tag)
                    lstFields.Add(strFlagFieldName & ctrDDFFFlag.Tag)

                    ctrDDFFFlag.SetTableNameAndDirectionSpeedFlagFields(strTableName, strDirectionFieldName & ctrDDFFFlag.Tag, strSpeedFieldName & ctrDDFFFlag.Tag, strFlagFieldName & ctrDDFFFlag.Tag)
                    AddHandler ctrDDFFFlag.ucrDirection.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrDDFFFlag.ucrSpeed.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrDDFFFlag.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrDDFFFlag.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                ElseIf TypeOf ctr Is ucrTextBox Then
                    'lstTextboxControls.Add(ctr)
                    ctrTotal = ctr
                    ctrTotal.SetTableNameAndField(strTableName, strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ctrTotal.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ctr As ucrTextBox

        If TypeOf sender Is ucrTextBox Then
            'ctr = DirectCast(sender, ucrTextBox)
            ctr = sender
            CallByName(fd2Record, ctr.GetField, CallType.Set, ctr.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        Dim ctr As Control
        Dim ctrDDFFFlag As ucrDirectionSpeedFlag

        If TypeOf sender Is ucrDirectionSpeedFlag Then
            ctrDDFFFlag = sender
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    'TODO needs modification here. for enable all months functionality
                    If ctr.Tag = ctrDDFFFlag.Tag + 1 Then
                        If ctr.Enabled Then
                            ctr.Focus()
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        'Dim ctr As Control
        'Dim ctrDDFFFlag As ucrDirectionSpeedFlag
        'Dim ctrTotal As ucrTextBox

        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If

    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'need an if statement that checks for changes 
        fd2Record = Nothing
        MyBase.LinkedControls_evtValueChanged()
        'EnableDaysofMonth()

        'Dim ctr As Control
        'Dim ctrDDFFFlag As  ucrDirectionSpeedFlag
        'Dim ctrTotal As  ucrTextBox
        'For Each ctr In Me.Controls
        '    If TypeOf ctr Is ucrDirectionSpeedFlag Then
        '        ctrVFP = ctr
        '        CallByName(fd2Record, strValueFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrValue.GetValue)
        '        CallByName(fd2Record, strFlagFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrFlag.GetValue)
        '        CallByName(fd2Record, strPeriodFieldName & ctrVFP.Tag, CallType.Set, ctrVFP.ucrPeriod.GetValue)
        '    ElseIf TypeOf ctr Is ucrTextBox Then
        '        ctrTotal = ctr
        '        CallByName(fd2Record, strTotalFieldName, CallType.Set, ctrTotal.GetValue)
        '    End If

        'Next

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            CallByName(fd2Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next

    End Sub

    Public Sub HourSelection(bselectAllHours As Boolean)
        If bselectAllHours Then

        End If
    End Sub

    Public Overrides Sub Clear()

        Dim ctr As Control 'TODO THIS COULD BE REMOVED AFTER TESTING
        Dim ctrTotal As ucrTextBox
        Dim ctrVFP As ucrValueFlagPeriod
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr 'TODO THIS COULD BE REMOVED AFTER TESTING
                ctrVFP.Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                ctrTotal = ctr 'TODO THIS COULD BE REMOVED AFTER TESTING
                ctrTotal.Clear()
            End If
        Next
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

    Public Sub checkTotal()

    End Sub
End Class

