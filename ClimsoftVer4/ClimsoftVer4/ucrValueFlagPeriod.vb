Public Class ucrValueFlagPeriod
    Private bFirstLoad As Boolean = True
    Public Event evtGoToNextVFPControl(sender As Object, e As KeyEventArgs)
    Private bIncludePeriod As Boolean = True
    Public objKeyPress As New dataEntryGlobalRoutines

    Public Property IncludePeriod() As Boolean
        Get
            Return bIncludePeriod
        End Get
        Set(value As Boolean)
            bIncludePeriod = value
            ucrPeriod.Visible = value
        End Set
    End Property

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        ucrValue.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
        If IncludePeriod Then
            ucrPeriod.SetTableName(strNewTable)
        End If
    End Sub

    Public Sub SetValueFlagPeriodFields(strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        SetFields(New List(Of String)({strValueFieldName, strFlagFieldName, strPeriodFieldName}))
        SetValueField(strValueFieldName)
        SetFlagField(strFlagFieldName)
        SetPeriodField(strPeriodFieldName)
        IncludePeriod = True
    End Sub

    'added this to set value and flag field
    Public Sub SetValueFlagFields(strValueFieldName As String, strFlagFieldName As String)
        SetFields(New List(Of String)({strValueFieldName, strFlagFieldName}))
        SetValueField(strValueFieldName)
        SetFlagField(strFlagFieldName)
        IncludePeriod = False
    End Sub

    Public Sub SetTableNameAndValueFlagPeriodFields(strNewTable As String, strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        SetTableName(strNewTable)
        SetValueFlagPeriodFields(strValueFieldName, strFlagFieldName, strPeriodFieldName)
    End Sub

    'added this to set table name and value flag field
    Public Sub SetTableNameAndValueFlagFields(strNewTable As String, strValueFieldName As String, strFlagFieldName As String)
        SetTableName(strNewTable)
        SetValueFlagFields(strValueFieldName, strFlagFieldName)
    End Sub

    Public Sub SetValueField(strValueFieldName As String)
        ucrValue.SetField(strValueFieldName)
    End Sub

    Public Sub SetFlagField(strFlagFieldName As String)
        ucrFlag.SetField(strFlagFieldName)
    End Sub

    Public Sub SetPeriodField(strPeriodFieldName As String)
        ucrPeriod.SetField(strPeriodFieldName)
    End Sub

    Public Overrides Sub SetFilter(clsNewFilter As TableFilter)
        MyBase.SetFilter(clsNewFilter)
        ucrValue.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFlag.SetFilter(clsNewFilter:=clsNewFilter)
        If bIncludePeriod Then
            ucrPeriod.SetFilter(clsNewFilter:=clsNewFilter)
        End If
    End Sub

    Public Overrides Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        MyBase.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrValue.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFlag.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        If bIncludePeriod Then
            ucrPeriod.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrValueView, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrValue.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFlag.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If bIncludePeriod Then
            ucrPeriod.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            ucrValue.PopulateControl()
            ucrFlag.PopulateControl()
            If bIncludePeriod Then
                ucrPeriod.PopulateControl()
            End If
        End If
    End Sub

    Public Overrides Sub Clear()
        ucrValue.Clear()
        ucrFlag.Clear()
        If bIncludePeriod Then
            ucrPeriod.Clear()
        End If
    End Sub

    Public Overrides Sub SetBackColor(backColor As Color)
        ucrValue.SetBackColor(backColor)
        ucrFlag.SetBackColor(backColor)
        If bIncludePeriod Then
            ucrPeriod.SetBackColor(backColor)
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim lstValueFlagPeriod As List(Of Object)

        'MyBase.SetValue(objNewValue)
        lstValueFlagPeriod = TryCast(objNewValue, List(Of Object))

        If IsNothing(lstValueFlagPeriod) Then
            SetElementValue(Nothing)
            SetElementFlagValue(Nothing)
            If bIncludePeriod Then
                SetElementPeriodValue(Nothing)
            End If
        ElseIf lstValueFlagPeriod.Count = 3 Then
            SetElementValue(lstValueFlagPeriod(0))
            SetElementFlagValue(lstValueFlagPeriod(1))
            If bIncludePeriod Then
                SetElementPeriodValue(lstValueFlagPeriod(2))
            End If
        ElseIf lstValueFlagPeriod.Count = 2 Then
            SetElementValue(lstValueFlagPeriod(0))
            SetElementFlagValue(lstValueFlagPeriod(1))
        ElseIf lstValueFlagPeriod.Count = 1 Then
            SetElementValue(lstValueFlagPeriod(0))
        End If
    End Sub

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        Dim lstValueFlagPeriod As New List(Of Object)

        lstValueFlagPeriod.Add(GetElementValue())
        lstValueFlagPeriod.Add(GetElementFlagValue())
        If bIncludePeriod Then
            lstValueFlagPeriod.Add(GetElementPeriodValue())
        End If
        Return lstValueFlagPeriod
    End Function

    Public Sub SetElementValue(strValue As String)
        ucrValue.SetValue(strValue)
    End Sub

    ''' <summary>
    ''' Gets the value for ucrValue control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetElementValue() As String
        Return ucrValue.GetValue
    End Function

    Public Sub SetElementFlagValue(strValue As String)
        ucrFlag.SetValue(strValue)
    End Sub

    Public Function GetElementFlagValue() As String
        Return ucrFlag.GetValue
    End Function

    Public Function GetElementPeriodValue() As String
        Return ucrPeriod.GetValue
    End Function

    Public Sub SetElementPeriodValue(strValue As String)
        ucrPeriod.SetValue(strValue)
    End Sub

    Public Function IsEmpty() As Boolean
        Return IsElementValueEmpty() AndAlso IsElementFlagEmpty() AndAlso IsElementPeriodEmpty()
    End Function

    Public Function IsElementValueEmpty() As Boolean
        Return ucrValue.IsEmpty()
    End Function

    Public Function IsElementFlagEmpty() As Boolean
        Return ucrFlag.IsEmpty()
    End Function

    Public Function IsElementPeriodEmpty() As Boolean
        If bIncludePeriod Then
            Return ucrPeriod.IsEmpty()
        Else
            Return True
        End If
    End Function

    Public Sub SetElementValueLimit(iLowerLimit As Decimal, iUpperLimit As Decimal)
        SetElementValueLowerLimit(iLowerLimit)
        SetElementValueHigherLimit(iUpperLimit)
    End Sub

    Public Sub SetElementValueLowerLimit(iLowerLimit As Decimal)
        ucrValue.SetMinimumValue(iLowerLimit)
    End Sub

    Public Sub SetElementValueHigherLimit(iUpperLimit As Decimal)
        ucrValue.SetMaximumValue(iUpperLimit)
    End Sub

    ''' <summary>
    ''' checks if the values of all the controls are valid.
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        Return IsElementValueValid() AndAlso IsElementPeriodValid() 'ommitted IsElementFlagValid() intentionally
    End Function

    Public Function IsElementValueValid() As Boolean
        Return ValidateText(ucrValue.GetValue)
    End Function

    Public Function IsElementFlagValid() As Boolean
        Dim bValuesCorrect As Boolean = True

        'if value is empty then set flag as M else remove the M
        If Not ucrFlag.ValidateValue Then
            bValuesCorrect = False
        ElseIf ucrValue.IsEmpty Then
            If Not ucrFlag.IsEmpty AndAlso ucrFlag.GetValue <> "M" Then
                MessageBox.Show("M is the expected flag for a missing value", "Flag Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucrFlag.SetBackColor(Color.Cyan)
                bValuesCorrect = False
            End If
        Else
            If ucrFlag.GetValue = "M" Then
                MessageBox.Show("M is the expected flag for a missing value", "Flag Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ucrFlag.SetBackColor(Color.Cyan)
                bValuesCorrect = False
            End If
        End If
        Return bValuesCorrect
    End Function

    Public Function IsElementPeriodValid() As Boolean
        Return If(IncludePeriod, ucrPeriod.ValidateValue, True)
    End Function

    Private Sub ucrValueFlagPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            ucrValue.bValidateSilently = True
            ucrValue.SetValidationTypeAsNumeric()

            ucrFlag.SetTextToUpper()
            ucrFlag.SetAsReadOnly()
            ucrFlag.bValidateSilently = True
            ucrFlag.SetValidationTypeAsFlag()
            ucrFlag.SetValidColor(SystemColors.Control) 'ucrFlag being a readonly. This makes its back color to be just like that of readonly when it has a valid value
            SetTextBoxSize()
            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrValueFlagPeriod_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrValue.evtKeyDown, ucrFlag.evtKeyDown, ucrPeriod.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If ucrValue.IsEmpty Then
                ucrFlag.SetValue("M")
            End If

            If Not DoQCForValue(False) Then
                Exit Sub
            End If

        End If

        OnevtKeyDown(Me, e)
    End Sub

    Private Sub ucrValue_TextChanged(sender As Object, e As EventArgs) Handles ucrValue.evtTextChanged
        OnevtTextChanged(Me, e)
    End Sub

    Private Sub ucrValue_evtValueChanged(sender As Object, e As EventArgs) Handles ucrValue.evtValueChanged
        ucrValue.bSuppressChangedEvents = True
        DoQCForValue(True)
        ucrValue.bSuppressChangedEvents = False
        OnevtValueChanged(Me, e) 'this is where there is the problem. Its being called twice
    End Sub

    Private Function DoQCForValue(bSetValuesIfValid As Boolean) As Boolean
        Dim bValuesCorrect As Boolean
        Dim bValueValid As Boolean
        Dim bFlagValid As Boolean

        Dim strValue As String
        Dim strFlag As String


        strValue = ucrValue.GetValue
        strFlag = ucrFlag.GetValue
        If String.IsNullOrEmpty(strValue) Then
            bValuesCorrect = True
            If Not String.IsNullOrEmpty(strFlag) AndAlso strFlag <> "M" Then
                strFlag = "" 'remove the flag 
            End If
        Else
            'Check for an observation flag in the ucrValue.
            'If a flag exists then separate and place it in the  ucrValueFlag 
            If Not IsNumeric(Strings.Right(strValue, 1)) AndAlso IsNumeric(Strings.Left(strValue, Strings.Len(strValue) - 1)) Then
                'Get observation flag from the ucrValue (the last character). If its an "M" just set flag as empty text
                strFlag = If(Strings.Right(strValue, 1) = "M", "", Strings.Right(strValue, 1))
                If ucrFlag.ValidateText(strFlag, bValidateSilently:=True) Then
                    'Get the observation value by leaving out the last character   
                    strValue = Strings.Left(strValue, Strings.Len(strValue) - 1)
                End If

            Else
                strFlag = ""
            End If

            'validate values loudly  

            bValueValid = ValidateText(strValue) OrElse ucrValue.ValidateText(strValue, bValidateSilently:=False)
            bFlagValid = ucrFlag.ValidateText(strFlag, bValidateSilently:=False)

            bValuesCorrect = (bValueValid AndAlso bFlagValid)

            ucrValue.SetBackColor(If(bValuesCorrect, clValidColor, clInValidColor))

            'todo. temporary addition to fix limits violations
            If ucrValue.GetValidationCode(strValue) = 2 Then
                ucrValue.SetBackColor(Color.Cyan)
            End If

        End If
        If bSetValuesIfValid AndAlso bValuesCorrect Then
            ucrValue.SetValue(strValue)
            ucrFlag.SetValue(strFlag)
        End If
        Return bValuesCorrect
    End Function

    Private Function DoQCForValueDEPRECATED() As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim bValueValid As Boolean = False
        Dim bFlagValid As Boolean = False
        Dim bValidateSilently As Boolean
        Dim bNewSuppressChangedEvents As Boolean
        Dim strVF As String
        strVF = ucrValue.GetValue
        If String.IsNullOrEmpty(strVF) Then
            bValuesCorrect = True
            If Not ucrFlag.IsEmpty AndAlso ucrFlag.GetValue <> "M" Then
                ucrFlag.SetValue("") 'remove the flag
            End If
        Else
            'Check for an observation flag in the ucrValue.
            'If a flag exists then separate and place it in the  ucrValueFlag 
            If Not IsNumeric(Strings.Right(strVF, 1)) AndAlso IsNumeric(Strings.Left(strVF, Strings.Len(strVF) - 1)) Then
                'Get observation flag from the ucrValue (the last character). If its an "M" just set flag as empty text
                ucrFlag.SetValue(If(Strings.Right(ucrValue.GetValue, 1) = "M", "", Strings.Right(ucrValue.GetValue, 1)))

                If ucrFlag.ValidateValue() Then
                    'Get the observation value by leaving out the last character  
                    bNewSuppressChangedEvents = ucrValue.bSuppressChangedEvents
                    ucrValue.bSuppressChangedEvents = True
                    ucrValue.SetValue(Strings.Left(strVF, Strings.Len(strVF) - 1))
                    ucrValue.bSuppressChangedEvents = bNewSuppressChangedEvents
                End If

            Else
                ucrFlag.SetValue("")
            End If

            'validate values loudly  
            bValidateSilently = ucrValue.bValidateSilently
            ucrValue.bValidateSilently = False
            bValueValid = ucrValue.ValidateValue()
            ucrValue.bValidateSilently = bValidateSilently


            bValidateSilently = ucrFlag.bValidateSilently
            ucrFlag.bValidateSilently = False
            bFlagValid = ucrFlag.ValidateValue()
            ucrFlag.bValidateSilently = bValidateSilently

            'If ucrFlag.GetValue = "M" Then
            '    bFlagValid = False
            '    MsgBox("M is the expected flag for a missing value", MsgBoxStyle.Critical)
            '    ucrFlag.SetBackColor(Color.Cyan)
            'End If
            bValuesCorrect = (bValueValid AndAlso bFlagValid)
            ucrValue.SetBackColor(If(bValuesCorrect, clValidColor, clInValidColor))
        End If
        Return bValuesCorrect
    End Function

    ''' <summary>
    ''' checks if the value input in the ucrValue will be a valid value or not 
    ''' when Quality Control is applied to the passed value.
    ''' </summary>
    ''' <returns></returns>
    Public Function ValidateText(strNewValue As String) As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim strValue As String = strNewValue

        If strValue = "" Then
            bValuesCorrect = True
        Else
            'Check for an observation flag in the value If a flag exists then separate and get it 
            If Not IsNumeric(Strings.Right(strValue, 1)) AndAlso IsNumeric(Strings.Left(strValue, Strings.Len(strValue) - 1)) Then
                strValue = Strings.Left(strValue, Strings.Len(strValue) - 1)
            Else
                'if the value is just an M, ignore it and interpret it as a user's intention to put missing value
                'If strValue = "M" Then
                '    strValue = ""
                'End If
            End If

            'check if the result is a valid value 
            bValuesCorrect = ucrValue.ValidateText(strValue)

            'todo. temporary addition to fix limits violations. todo. use validateNumeric
            'just set the invalid colours for limits violation but assume it's a valid value
            If Not bValuesCorrect AndAlso ucrValue.GetValidationCode(strValue) = 2 Then
                bValuesCorrect = True
            End If

        End If
        Return bValuesCorrect
    End Function

    Private Sub SetTextBoxSize()
        ucrValue.SetSize(New Size(51, 20))
        ucrFlag.SetSize(New Size(27, 20))
        If IncludePeriod Then
            ucrPeriod.SetSize(New Size(33, 20))
        End If
    End Sub

    Public Overrides Sub SetContextMenuStrip(contextMenuStrip As ContextMenuStrip)
        ucrValue.SetContextMenuStrip(contextMenuStrip)
        ucrFlag.SetContextMenuStrip(contextMenuStrip)
        If IncludePeriod Then
            ucrPeriod.SetContextMenuStrip(contextMenuStrip)
        End If

    End Sub

    Public Sub SetInnerControlsFieldNames(strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        ucrValue.FieldName = strValueFieldName
        ucrFlag.FieldName = strFlagFieldName
        ucrPeriod.FieldName = strPeriodFieldName
        IncludePeriod = True
    End Sub

    Public Sub SetInnerControlsFieldNames(strValueFieldName As String, strFlagFieldName As String)
        ucrValue.FieldName = strValueFieldName
        ucrFlag.FieldName = strFlagFieldName
        ucrPeriod.FieldName = "" 'removes the default period field to avoid addition of it to a list of fields of its table entry control
        IncludePeriod = False
    End Sub

    Public Overrides Sub AddFieldstoList(lstFields As List(Of String))
        ucrValue.AddFieldstoList(lstFields)
        ucrFlag.AddFieldstoList(lstFields)
        If IncludePeriod Then
            ucrPeriod.AddFieldstoList(lstFields)
        End If

    End Sub

    Public Overrides Sub AddEventValueChangedHandle(ehSub As evtValueChangedEventHandler)
        'ucrValue.AddEventValueChangedHandle(ehSub)
        'ucrFlag.AddEventValueChangedHandle(ehSub)
        'ucrPeriod.AddEventValueChangedHandle(ehSub)
        MyBase.AddEventValueChangedHandle(ehSub)
        ' AddHandler evtValueChanged, ehSub
    End Sub

    Public Overrides Sub SetValueFromDataTable(dtbValues As DataTable)
        Dim tempRow As DataRow
        Dim lstValues As New List(Of Object)
        Dim lstDistinct As New List(Of Object)
        Dim dtbTemp As DataTable
        Dim strIdentifyField As String = FieldName

        ucrValue.SetValueFromDataTable(dtbValues)
        ucrFlag.SetValueFromDataTable(dtbValues)
        If IncludePeriod Then
            ucrPeriod.SetValueFromDataTable(dtbValues)
        End If
        'todo.OR??
        'lstValues.Add(dtbValues.Rows(0).Item(ucrValue.FieldName))
        'lstValues.Add(dtbValues.Rows(0).Item(ucrFlag.FieldName))
        'If bIncludePeriod Then
        '    lstValues.Add(dtbValues.Rows(0).Item(ucrPeriod.FieldName))
        'End If
        'SetValue(lstValues)

        If 1 = 1 Then
            Return
        End If
        'the below code is not working with the current model

        If String.IsNullOrEmpty(strIdentifyField) Then
            SetValue(Nothing)
        Else
            dtbTemp = dtbValues.Clone()
            For Each tempRow In dtbValues.Rows
                If tempRow(strIdentifyField) = FieldName Then
                    dtbTemp.Rows.Add(tempRow)
                End If
            Next

            If dtbTemp.Rows.Count = 1 Then
                lstValues.Add(dtbTemp.Rows(0)(ucrValue.FieldName))
                lstValues.Add(dtbTemp.Rows(0)(ucrFlag.FieldName))
                lstValues.Add(dtbTemp.Rows(0)(ucrPeriod.FieldName))
                SetValue(lstValues)
            ElseIf dtbTemp.Rows.Count = 0 Then
                SetValue(Nothing)
            Else
                'TODO Should we give an error in this case?
                SetValue(Nothing)
                End If
            End If
    End Sub

    Public Overrides Sub SetValueToDataTable(dtbValues As DataTable)
        ucrValue.SetValueToDataTable(dtbValues)
        ucrFlag.SetValueToDataTable(dtbValues)
        If IncludePeriod Then
            ucrPeriod.SetValueToDataTable(dtbValues)
        End If
    End Sub


    ''code commented out temprarily
    'Sub Compare_Entry(obsv As String)
    '    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    '    Dim constr As String
    '    Dim frm, stn, elm, yy, mm, dd, hh, dttime, obsv1, C1, cpVal As String
    '    Dim Conflict As Boolean

    '    constr = frmLogin.txtusrpwd.Text
    '    conn.ConnectionString = constr
    '    conn.Open()


    '    With frmKeyEntry.ListView1
    '        For i = 0 To .Items.Count - 1
    '            If .Items(i).Selected = True Then
    '                frm = .Items(i).SubItems(0).Text
    '                Exit For
    '            End If
    '        Next

    '        Select Case frm
    '            Case "form_synoptic_2_ra1"
    '                Try
    '                    With frmNewSynopticRA1
    '                        If Not .chkRepeatEntry.Checked Then
    '                            Exit Sub
    '                        End If
    '                        stn = .ucrStationSelector.cboValues.SelectedValue
    '                        elm = .ucrSynopticRA1.ActiveControl.Tag
    '                        yy = .ucrYearSelector.cboValues.SelectedValue
    '                        mm = .ucrMonth.cboValues.SelectedValue
    '                        dd = .ucrDay.cboValues.SelectedValue
    '                        hh = .ucrHour.cboValues.SelectedValue
    '                    End With
    '                    If Not objKeyPress.Entered_Value(conn, stn, elm, yy, mm, dd, hh, obsv1) Then
    '                        MsgBox("Can't Verify: Record does not exist")
    '                        Exit Sub
    '                    Else
    '                        ' Start Verification process
    '                        Validate_Entry(obsv, obsv1, stn, elm, yy, mm, dd, hh)
    '                    End If
    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                End Try
    '            Case "form_daily2"
    '                Try
    '                    With frmNewFormDaily2
    '                        If Not .chkRepeatEntry.Checked Then
    '                            Exit Sub
    '                        End If
    '                        stn = .ucrStationSelector.cboValues.SelectedValue
    '                        elm = .ucrElementSelector.cboValues.SelectedValue
    '                        yy = .ucrYearSelector.cboValues.SelectedValue
    '                        mm = .ucrMonth.cboValues.SelectedValue
    '                        dd = Mid(.ucrFormDaily.ActiveControl.Name, 19, Len(.ucrFormDaily.ActiveControl.Name) - 18)
    '                        hh = .ucrHour.cboValues.SelectedValue
    '                    End With
    '                    If Not objKeyPress.Entered_Value(conn, stn, elm, yy, mm, dd, hh, obsv1) Then
    '                        MsgBox("Can't Verify: Record does not exist")
    '                        Exit Sub
    '                    Else
    '                        Validate_Entry(obsv, obsv1, stn, elm, yy, mm, dd, hh)
    '                    End If
    '                    'MsgBox(stn & " " & elm & " " & yy & " " & mm & " " & dd & " " & hh & " " & obsv1)
    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                End Try
    '            Case "form_hourly"
    '                Try
    '                    With frmNewHourly
    '                        If Not .chkRepeatEntry.Checked Then
    '                            Exit Sub
    '                        End If
    '                        stn = .ucrStationSelector.cboValues.SelectedValue
    '                        elm = .ucrElementSelector.cboValues.SelectedValue
    '                        yy = .ucrYearSelector.cboValues.SelectedValue
    '                        mm = .ucrMonth.cboValues.SelectedValue
    '                        dd = .ucrDay.cboValues.SelectedValue
    '                        hh = Strings.Mid(.ucrHourly.ActiveControl.Name, 19, Len(.ucrHourly.ActiveControl.Name) - 18)
    '                        'MsgBox(stn & " " & elm & " " & yy & " " & mm & " " & dd & " " & hh)
    '                    End With

    '                    If Not objKeyPress.Entered_Value(conn, stn, elm, yy, mm, dd, hh, obsv1) Then
    '                        MsgBox("Can't Verify: Record does not exist")
    '                        Exit Sub
    '                    Else
    '                        'MsgBox(obsv1)
    '                        Validate_Entry(obsv, obsv1, stn, elm, yy, mm, dd, hh)
    '                    End If
    '                Catch ex As Exception
    '                    MsgBox(ex.Message)
    '                End Try
    '            Case "form_monthly"
    '        End Select
    '    End With


    'End Sub

    'commented temporarily
    'Sub Validate_Entry(obsv As String, obsv1 As String, stnid As String, elmcode As String, yy As String, mm As String, dd As String, hh As String)
    '    Dim Conflict As Boolean
    '    Dim C1, cpVal As String

    '    Conflict = False
    '    If obsv <> obsv1 Then
    '        MsgBox("Conflicting Values")
    '        ucrValue.BackColor = Color.Yellow
    '        cpVal = ucrValue.TextboxValue
    '        Conflict = True
    '        ucrValue.TextboxValue = ""

    '        Do While Conflict = True
    '            C1 = InputBox("Reapeat Entry Please!", "Key Entry Verification")
    '            If C1 <> cpVal Then
    '                cpVal = C1
    '                Conflict = True
    '                MsgBox("Re Entry Conflict! Try Again")
    '            Else
    '                ucrValue.TextboxValue = C1
    '                Conflict = False
    '                'Update database with the verified value
    '                If MsgBox("Update Conflicting Value?", vbYesNo, "Confirm Update") = MsgBoxResult.Yes Then
    '                    If Not objKeyPress.Db_Update_Conflicts(stnid, elmcode, yy, mm, dd, hh, C1) Then
    '                        MsgBox("Update Failure")
    '                    End If
    '                Else
    '                    MsgBox("Update Cancelled by operator")
    '                    ucrValue.TextboxValue = ""
    '                End If
    '                ucrValue.BackColor = Color.White
    '            End If
    '        Loop
    '    End If
    'End Sub


End Class
