Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourlywind"
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private strTotalFieldName As String = "total"

    Private bSelectAllHours As Boolean
    Private lstFields As New List(Of String)
    Public fhourlyWindRecord As form_hourlywind
    Public bUpdating As Boolean = False

    Public Overrides Sub PopulateControl()
        Dim clsCurrentFilter As TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fhourlyWindRecord Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                Dim y = clsDataConnection.db.form_hourlywind.Where(clsCurrentFilter.GetLinqExpression())
                If y.Count() = 1 Then
                    fhourlyWindRecord = y.FirstOrDefault()
                    bUpdating = True
                Else
                    fhourlyWindRecord = New form_hourlywind
                    bUpdating = False
                End If
            End If

            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ctr.SetValue(New List(Of Object)({GetValue(strDirectionFieldName & ctr.Tag), GetValue(strSpeedFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    ctr.SetValue(GetValue(strTotalFieldName))
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
            ctr = sender
            CallByName(fhourlyWindRecord, sender.GetField, CallType.Set, sender.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        'TODO 
        'SHOULD BE ABLE TO IDENTIFY THE PARTICULAR TEXTBOX AS A SENDER
        Dim ctr As Control
        Dim ctrDDFFFlag As ucrDirectionSpeedFlag

        If TypeOf sender Is ucrDirectionSpeedFlag Then
            ctrDDFFFlag = sender
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    'TODO 
                    'needs modification here. for hour selection functionality
                    If Val(ctr.Tag) = Val(ctrDDFFFlag.Tag) + 1 Then
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
        fhourlyWindRecord = Nothing
        MyBase.LinkedControls_evtValueChanged()


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
            CallByName(fhourlyWindRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next

    End Sub

    Public Sub SetHourSelection(bNewSelectAllHours As Boolean)
        bSelectAllHours = bNewSelectAllHours
        If bSelectAllHours Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ctr.enabled = True
                    ctr.SetBackColor(Color.White)
                End If
            Next
        Else
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableName("form_hourly_time_selection")
            clsDataDefinition.SetFields(New List(Of String)({"hh", "hh_selection"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing Then
                For Each ctr In Me.Controls
                    If TypeOf ctr Is ucrDirectionSpeedFlag Then
                        iTagVal = Val(Strings.Right(ctr.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ctr.enabled = False
                            ctr.SetBackColor(Color.LightYellow)
                        End If
                        'SIMILAR IMPLEMENTATION WOULD AS ABOVE WOULD BE AS COMMENTED BELOW
                        'For Each rTemp As DataRow In dtbl.Rows
                        '    If Val(rTemp("hh")) = iTagVal AndAlso Val(rTemp("hh_selection")) = 0 Then
                        '        ctr.enabled = False
                        '        ctr.SetBackColor(Color.LightYellow)
                        '        Exit For
                        '    End If
                        'Next
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub SetDirectionValidation(elementId As Integer)
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ctr.SetDirectionValidation(elementId)
            End If
        Next
    End Sub

    Public Sub SetSpeedValidation(elementId As Integer)
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ctr.SetSpeedValidation(elementId)
            End If
        Next
    End Sub

    Public Overrides Sub Clear()
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ctr.Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                ctr.Clear()
            End If
        Next
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

    Public Sub checkTotal()

    End Sub
End Class

