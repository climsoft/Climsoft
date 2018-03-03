Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourlywind"
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private strTotalFieldName As String = "total"
    Private iSpeedTotalRequired As Integer
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
                fhourlyWindRecord = clsDataConnection.db.form_hourlywind.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fhourlyWindRecord Is Nothing Then
                    fhourlyWindRecord = New form_hourlywind
                    bUpdating = False
                Else
                    bUpdating = True
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

    Private Sub ucrHourlyWind_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim ucrText As ucrTextBox

        If bFirstLoad Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    lstFields.Add(strDirectionFieldName & ucrDSF.Tag)
                    lstFields.Add(strSpeedFieldName & ucrDSF.Tag)
                    lstFields.Add(strFlagFieldName & ucrDSF.Tag)

                    ucrDSF.SetTableNameAndDirectionSpeedFlagFields(strTableName, strDirectionFieldName & ucrDSF.Tag, strSpeedFieldName & ucrDSF.Tag, strFlagFieldName & ucrDSF.Tag)
                    AddHandler ucrDSF.ucrDirection.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrSpeed.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                ElseIf TypeOf ctr Is ucrTextBox Then
                    'lstTextboxControls.Add(ctr)
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
        Dim ctrDDFFFlag As ucrDirectionSpeedFlag

        If TypeOf sender Is ucrDirectionSpeedFlag Then
            ctrDDFFFlag = sender
            For Each ctr As Control In Me.Controls
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
        Dim ucrDSF As ucrDirectionSpeedFlag
        bSelectAllHours = bNewSelectAllHours
        If bSelectAllHours Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    ucrDSF.Enabled = True
                    ucrDSF.SetBackColor(Color.White)
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
                        ucrDSF = ctr
                        iTagVal = Val(Strings.Right(ucrDSF.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ucrDSF.Enabled = False
                            ucrDSF.SetBackColor(Color.LightYellow)
                        End If
                        'SIMILAR IMPLEMENTATION WOULD AS ABOVE WOULD BE AS COMMENTED BELOW
                        'For Each rTemp As DataRow In dtbl.Rows
                        '    If Val(rTemp("hh")) = iTagVal AndAlso Val(rTemp("hh_selection")) = 0 Then
                        '        ucrDSF.enabled = False
                        '        ucrDSF.SetBackColor(Color.LightYellow)
                        '        Exit For
                        '    End If
                        'Next
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub SetDirectionDigits(iNewDirectionDigits As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                ucrDSF.SetDirectionDigits(iNewDirectionDigits)
            End If
        Next
    End Sub

    Public Sub SetSpeedDigits(iNewSpeedDigits As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                ucrDSF.SetSpeedDigits(iNewSpeedDigits)
            End If
        Next
    End Sub

    Public Sub SetDirectionValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))
        clsDataDefinition.SetFilter("elementId", "=", elementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    ucrDSF.SetDirectionValidation(dtbl.Rows(0).Item("lowerLimit"), dtbl.Rows(0).Item("upperLimit"))
                End If
            Next
        End If
    End Sub

    Public Sub SetSpeedValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit", "QCTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", elementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    ucrDSF.SetSpeedValidation(dtbl.Rows(0).Item("lowerLimit"), dtbl.Rows(0).Item("upperLimit"))
                    iSpeedTotalRequired = Val(dtbl.Rows(0).Item("QCTotalRequired"))
                End If
            Next
        End If
    End Sub

    Public Overrides Sub Clear()
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim ucrTxt As ucrTextBox
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                ucrDSF.Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                ucrTxt = ctr
                ucrTxt.Clear()
            End If
        Next
    End Sub

    Public Function IsDirectionValuesEmpty() As Boolean
        Dim ucrDSF As ucrDirectionSpeedFlag
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                If (Not ucrDSF.IsDirectionEmpty()) AndAlso IsNumeric(ucrDSF.GetDirectionValue) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function QcForDirection() As Boolean
        Dim ucrDSF As ucrDirectionSpeedFlag
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                If Not ucrDSF.QcForDirection() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function CheckQcForSpeed() As Boolean
        Dim ucrDSF As ucrDirectionSpeedFlag
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = ctr
                If Not ucrDSF.CheckQcForSpeed() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

    Public Function checkTotal() As Boolean
        If iSpeedTotalRequired = 1 Then
            Dim elemTotal As Integer = 0
            Dim expectedTotal As Integer
            Dim ucrDSF As ucrDirectionSpeedFlag

            expectedTotal = Val(ucrInputTotal.GetValue)

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = ctr
                    elemTotal = elemTotal + ucrDSF.GetFlagValue
                End If
            Next

            If elemTotal = expectedTotal Then
                Return True
            Else
                MessageBox.Show("Value in [Total] textbox is different from that calculated by computer!", "Error in total")
                ucrInputTotal.Focus()
                ucrInputTotal.SetBackColor(Color.Cyan)
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Public Sub SaveRecord()
        'THIS CAN NOW BE PUSHED TO clsDataConnection CLASS
        'AND bUpdating MIGHT NOT BE NECESSARY
        If bUpdating Then
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Modified
            clsDataConnection.db.SaveChanges()
        Else
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Added
            clsDataConnection.db.SaveChanges()
        End If
    End Sub

    Public Sub DeleteRecord()
        ' clsDataConnection.db.Entry(fhourlyWindRecord)
        clsDataConnection.db.form_hourlywind.Attach(fhourlyWindRecord)
        clsDataConnection.db.form_hourlywind.Remove(fhourlyWindRecord)
        clsDataConnection.db.SaveChanges()
    End Sub


End Class

