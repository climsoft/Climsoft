﻿' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class ucrDirectionSpeedFlag
    Private bFirstLoad As Boolean = True
    Private iDirectionDigits As Integer
    Private iSpeedDigits As Integer
    Public Event evtGoToNextDSFControl(sender As Object, e As KeyEventArgs)
    Public objKeyPress As New dataEntryGlobalRoutines

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        'ucrDDFF.SetTableName(strNewTable)
        ucrDirection.SetTableName(strNewTable)
        ucrSpeed.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
    End Sub

    Public Sub SetDirectionSpeedFlagFields(strDirectionFieldName As String, strSpeedFieldName As String, strFlagFieldName As String)
        SetFields(New List(Of String)({strDirectionFieldName, strSpeedFieldName, strFlagFieldName}))
        'SetDDFFField(strDirectionFieldName, strSpeedFieldName)
        SetElementDirectionField(strDirectionFieldName)
        SetElementSpeedField(strSpeedFieldName)
        SetElementFlagField(strFlagFieldName)
    End Sub

    Public Sub SetTableNameAndDirectionSpeedFlagFields(strTableName As String, strDirectionFieldName As String, strSpeedFieldName As String, strFlagFieldName As String)
        SetTableName(strTableName)
        SetDirectionSpeedFlagFields(strDirectionFieldName, strSpeedFieldName, strFlagFieldName)
    End Sub

    Public Sub SetElementDirectionField(strFieldName As String)
        ucrDirection.SetField(strFieldName)
    End Sub

    Public Sub SetElementSpeedField(strFieldName As String)
        ucrSpeed.SetField(strFieldName)
    End Sub

    Public Sub SetElementFlagField(strFieldName As String)
        ucrFlag.SetField(strFieldName)
    End Sub

    Public Overrides Sub SetFilter(clsNewFilter As TableFilter)
        MyBase.SetFilter(clsNewFilter)
        'ucrDDFF.SetFilter(clsNewFilter:=clsNewFilter)
        ucrDirection.SetFilter(clsNewFilter:=clsNewFilter)
        ucrSpeed.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFlag.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overrides Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        MyBase.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        'ucrDDFF.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrDirection.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrSpeed.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFlag.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        'ucrDDFF.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrDirection.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrSpeed.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFlag.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            'ucrDDFF.PopulateControl()
            ucrDirection.PopulateControl()
            ucrSpeed.PopulateControl()
            ucrFlag.PopulateControl()
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim lstValues As List(Of Object)

        MyBase.SetValue(objNewValue)
        lstValues = TryCast(objNewValue, List(Of Object))
        If lstValues.Count = 3 Then
            ucrDDFF.SetValue(lstValues(0) + "" + lstValues(1) + "" + lstValues(2))
            'ucrDDFF.SetValue("")
            SetElementDirectionValue(lstValues(0))
            SetElementSpeedValue(lstValues(1))
            SetElementFlagValue(lstValues(2))
        ElseIf lstValues.Count = 2 Then
            ucrDDFF.SetValue(lstValues(0) + "" + lstValues(1))
            'ucrDDFF.SetValue("")
            SetElementDirectionValue(lstValues(0))
            SetElementSpeedValue(lstValues(1))
        End If
    End Sub

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        Dim lstValueDDFFFlag As New List(Of Object)
        lstValueDDFFFlag.Add(GetElementDirectionValue())
        lstValueDDFFFlag.Add(GetElementSpeedValue())
        lstValueDDFFFlag.Add(GetElementFlagValue())
        Return lstValueDDFFFlag
    End Function

    Public Sub SetElementDirectionValue(strValue As String)
        ucrDirection.SetValue(strValue)
    End Sub

    Public Sub SetElementSpeedValue(strValue As String)
        ucrSpeed.SetValue(strValue)
    End Sub

    Public Sub SetElementFlagValue(strValue As String)
        ucrFlag.SetValue(strValue)
    End Sub

    Public Function GetElementDirectionValue() As String
        Return ucrDirection.GetValue
    End Function

    Public Function GetElementSpeedValue() As String
        Return ucrSpeed.GetValue
    End Function

    Public Function GetElementFlagValue() As String
        Return ucrFlag.GetValue
    End Function

    Public Function IsElementDirectionEmpty() As Boolean
        Return ucrDirection.IsEmpty()
    End Function

    Public Function IsElementSpeedEmpty() As Boolean
        Return ucrSpeed.IsEmpty()
    End Function

    Public Function IsElementFlagEmpty() As Boolean
        Return ucrFlag.IsEmpty()
    End Function

    Public Sub SetElementDirectionLimit(iLowerLimit As Decimal, iUpperLimit As Decimal)
        SetElementDirectionLowerLimit(iLowerLimit)
        SetElementDirectionHigherLimit(iUpperLimit)
    End Sub

    Public Sub SetElementDirectionLowerLimit(iLowerLimit As Decimal)
        ucrDirection.SetMinimumValue(iLowerLimit)
    End Sub

    Public Sub SetElementDirectionHigherLimit(iUpperLimit As Decimal)
        ucrDirection.SetMaximumValue(iUpperLimit)
    End Sub

    Public Sub SetElementSpeedLimit(iLowerLimit As Decimal, iUpperLimit As Decimal)
        SetElementSpeedLowerLimit(iLowerLimit)
        SetElementSpeedHigherLimit(iUpperLimit)
    End Sub

    Public Sub SetElementSpeedLowerLimit(iLowerLimit As Decimal)
        ucrSpeed.SetMinimumValue(iLowerLimit)
    End Sub

    Public Sub SetElementSpeedHigherLimit(iUpperLimit As Decimal)
        ucrSpeed.SetMaximumValue(iUpperLimit)
    End Sub

    Public Sub SetElementDirectionDigits(iNewDirectionDigits As Integer)
        iDirectionDigits = iNewDirectionDigits
    End Sub

    Public Sub SetElementSpeedDigits(iNewSpeedDigits As Integer)
        iSpeedDigits = iNewSpeedDigits
    End Sub

    ''' <summary>
    ''' checks if the already Quality Control processed values are valid or not for all the controls
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        Return IsElementDirectionValueValid() AndAlso IsElementSpeedValueValid() AndAlso IsElementFlagValueValid()
    End Function

    Public Function IsElementDirectionValueValid() As Boolean
        Return ucrDirection.ValidateValue()
    End Function

    Public Function IsElementSpeedValueValid() As Boolean
        Return ucrSpeed.ValidateValue()
    End Function

    Public Function IsElementFlagValueValid() As Boolean
        Dim bValuesCorrect As Boolean = True

        'if any value is empty then set flag as M else remove the M
        If ucrDirection.IsEmpty OrElse ucrSpeed.IsEmpty Then
            If ucrFlag.GetValue = "M" OrElse ucrFlag.IsEmpty Then
                bValuesCorrect = True
            Else
                MsgBox("M is the expected flag for a missing value", MsgBoxStyle.Critical)
                ucrFlag.SetBackColor(Color.Cyan)
                bValuesCorrect = False
            End If
        Else
            If ucrFlag.GetValue = "M" Then
                ucrFlag.SetBackColor(Color.Cyan)
                bValuesCorrect = False
            Else
                bValuesCorrect = True
            End If
        End If

        Return bValuesCorrect
    End Function

    Public Overrides Sub Clear()
        ucrDDFF.Clear()
        ucrDirection.Clear()
        ucrSpeed.Clear()
        ucrFlag.Clear()
    End Sub

    Public Sub SetBackColor(backColor As Color)
        ucrDDFF.SetBackColor(backColor)
        ucrDirection.SetBackColor(backColor)
        ucrSpeed.SetBackColor(backColor)
        ucrFlag.SetBackColor(backColor)
    End Sub

    Private Sub ucrDirectionSpeedFlag_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            ucrDDFF.SetValidationTypeAsNone()
            ucrDDFF.SetTextToUpper()

            ucrDirection.bValidateSilently = True
            ucrDirection.SetValidationTypeAsNumeric()
            ucrDirection.SetAsReadOnly()
            'ucrDirection being a readonly. Makes back color to be like that of readonly when it has a valid value
            ucrDirection.SetValidColor(SystemColors.Control)

            ucrSpeed.bValidateSilently = True
            ucrSpeed.SetValidationTypeAsNumeric()
            ucrSpeed.SetAsReadOnly()
            ucrSpeed.SetValidColor(SystemColors.Control)

            ucrFlag.SetTextToUpper()
            ucrFlag.SetAsReadOnly()
            ucrFlag.SetValidColor(SystemColors.Control)

            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrDirectionSpeedFlag_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrDDFF.evtKeyDown
        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            If sender Is ucrDDFF Then

                ' Check if the opened form is in double key entry mode and compare the current entry with the uploaded one
                Compare_Entry(ucrDDFF.TextboxValue)

                'check ucrValue input. if value is empty then set flag as M else remove the M
                If ucrDDFF.IsEmpty Then
                    ucrFlag.SetValue("M")
                    RaiseEvent evtGoToNextDSFControl(Me, e)
                ElseIf ValidateText(ucrDDFF.GetValue) Then
                    RaiseEvent evtGoToNextDSFControl(Me, e)
                    'ElseIf ucrDDFF.GetValue = "M"
                    '    RaiseEvent evtGoToNextDSFControl(Me, e)
                Else
                    DoQCForUcrDDFFInput()
                End If
            End If
        End If

        OnevtKeyDown(Me, e)
    End Sub

    Private Sub ucrDDFF_ValueChanged(sender As Object, e As EventArgs) Handles ucrDDFF.evtValueChanged
        DoQCForUcrDDFFInput()
        IsElementFlagValueValid()
        OnevtValueChanged(Me, e)
    End Sub

    Private Function DoQCForUcrDDFFInput() As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim bValidateSilently As Boolean
        Dim bSuppressChangedEvents As Boolean

        If ucrDDFF.IsEmpty() Then
            'empty ucrDDFF is a valid value
            bValuesCorrect = True
            ucrDirection.SetValue("")
            ucrSpeed.SetValue("")
            If Not ucrFlag.IsEmpty AndAlso ucrFlag.GetValue <> "M" Then
                'remove the flag
                ucrFlag.SetValue("")
            End If
        Else
            'check for an observation flag. Must be the last character if it's included
            If Not IsNumeric(Strings.Right(ucrDDFF.GetValue, 1)) AndAlso IsNumeric(Strings.Left(ucrDDFF.GetValue, Strings.Len(ucrDDFF.GetValue) - 1)) Then
                'Get observation flag (last character) and set it to ucrFlag
                ucrFlag.SetValue(If(Strings.Right(ucrDDFF.GetValue, 1) = "M", "", Strings.Right(ucrDDFF.GetValue, 1)))

                'Remove the last character and set the result as the new DDFF value 
                bSuppressChangedEvents = ucrDDFF.bSuppressChangedEvents
                ucrDDFF.bSuppressChangedEvents = True
                ucrDDFF.SetValue(Strings.Left(ucrDDFF.GetValue, Strings.Len(ucrDDFF.GetValue) - 1))
                ucrDDFF.bSuppressChangedEvents = bSuppressChangedEvents
            Else
                'remove the flag
                ucrFlag.SetValue("")
            End If

            If IsNumeric(ucrDDFF.GetValue) Then
                'check the length of DDFF matches with direction and speed digits
                If ucrDDFF.GetValue.Length = iDirectionDigits + iSpeedDigits Then
                    Dim bDirectionValid As Boolean
                    Dim bSpeedValid As Boolean

                    'separate dd and ff 
                    ucrDirection.SetValue(Strings.Left(ucrDDFF.GetValue, iDirectionDigits))
                    ucrSpeed.SetValue(Strings.Right(ucrDDFF.GetValue, iSpeedDigits))

                    'validate the direction and speed values
                    bValidateSilently = ucrDirection.bValidateSilently
                    ucrDirection.bValidateSilently = False
                    bDirectionValid = ucrDirection.ValidateValue()
                    ucrDirection.bValidateSilently = bValidateSilently

                    bValidateSilently = ucrSpeed.bValidateSilently
                    ucrSpeed.bValidateSilently = False
                    bSpeedValid = ucrSpeed.ValidateValue()
                    ucrSpeed.bValidateSilently = bValidateSilently

                    bValuesCorrect = (bDirectionValid AndAlso bSpeedValid)
                    ucrDDFF.SetBackColor(If(bValuesCorrect, Color.White, Color.Red))

                Else
                    bValuesCorrect = False
                    ucrDDFF.SetBackColor(Color.Cyan)
                    MessageBox.Show("Wrong number of digits for ddff!", "DDFF Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else

                'if the value is just an M, then interpret it as a user's intention to put missing value
                If ucrDDFF.GetValue = "M" Then
                    ucrFlag.SetValue("M")
                    ucrDDFF.SetValue("")
                    bValuesCorrect = True
                    ucrDDFF.SetBackColor(Color.White)
                Else
                    bValuesCorrect = False
                    ucrDDFF.SetBackColor(Color.Red)
                    MessageBox.Show("Number expected!", "DDFF Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

                'bValuesCorrect = False
                'ucrDDFF.SetBackColor(Color.Red)
                'MessageBox.Show("Number expected!", "DDFF Entry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If
        End If

        Return bValuesCorrect
    End Function

    ''' <summary>
    ''' checks if the value of the DD and FF input in the ucrDDFF will be a valid value or not 
    ''' when Quality Control is applied to the passed value
    ''' </summary>
    ''' <returns></returns>
    Public Function ValidateText(strNewVal As String) As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim strVal As String = strNewVal

        If strVal = "" Then
            bValuesCorrect = True
        Else
            'if initial value is not a number, strip out the flag
            If Not IsNumeric(Strings.Right(strVal, 1)) AndAlso IsNumeric(Strings.Left(strVal, strVal.Length - 1)) Then
                strVal = Strings.Left(strVal, Strings.Len(strVal) - 1)
            End If

            If IsNumeric(strVal) AndAlso strVal.Length = (iDirectionDigits + iSpeedDigits) Then
                'separate dd and ff check validity of direction and speed values
                bValuesCorrect = (ucrDirection.ValidateText(Strings.Left(strVal, iDirectionDigits)) AndAlso ucrSpeed.ValidateText(Strings.Right(strVal, iSpeedDigits)))
            End If
        End If
        Return bValuesCorrect
    End Function

    Public Sub SetContextMenuStrip(contextMenuStrip As ContextMenuStrip)
        ucrDDFF.SetContextMenuStrip(contextMenuStrip)
        ucrDirection.SetContextMenuStrip(contextMenuStrip)
        ucrSpeed.SetContextMenuStrip(contextMenuStrip)
        ucrFlag.SetContextMenuStrip(contextMenuStrip)
    End Sub

    Sub Compare_Entry(obsv As String)
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim constr As String
        Dim frm, stn, elm, yy, mm, dd, hh, wdspd, wddir, obsv1 As String
        'Dim Conflict As Boolean

        constr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = constr
        conn.Open()
        'MsgBox(CurrentEntryValue)

        'MsgBox(frmNewSynopticRA1.ucrStationSelector.cboValues.SelectedValue)

        With frmKeyEntry.ListView1
            For i = 0 To .Items.Count - 1
                If .Items(i).Selected = True Then
                    frm = .Items(i).SubItems(0).Text
                    Exit For
                End If
            Next
        End With
        'MsgBox(frm & " " & obsv)

        Try
            With frmNewHourlyWind
                If Not .chkRepeatEntry.Checked Then
                    Exit Sub
                End If
                stn = .ucrStationSelector.cboValues.SelectedValue
                elm = "111"
                yy = .ucrYearSelector.cboValues.SelectedValue
                mm = .ucrMonth.cboValues.SelectedValue
                dd = .ucrDay.cboValues.SelectedValue
                hh = Strings.Mid(.ucrHourlyWind.ActiveControl.Name, 22, Len(.ucrHourlyWind.ActiveControl.Name) - 21)
            End With
            'MsgBox(stn & " " & yy & " " & mm & " " & dd & " " & hh)

            ' Get speed component of the wind wind data entry
            If Not objKeyPress.Entered_Value(conn, stn, 111, yy, mm, dd, hh, obsv1) Then
                MsgBox("Can't Verify: Wind speed record does not exist")
                Exit Sub
            Else
                ' wind speed exits
                wdspd = obsv1
            End If
            ' get direction component of wind data entry

            If Not objKeyPress.Entered_Value(conn, stn, 112, yy, mm, dd, hh, obsv1) Then
                MsgBox("Can't Verify: Wind direction Record does not exist")
                Exit Sub
            Else
                ' Wind direction exists
                wddir = obsv1
            End If
            'MsgBox(wddir & wdspd)

            Validate_Entry(obsv, wddir & wdspd, stn, elm, yy, mm, dd, hh)
        Catch ex As Exception
                MsgBox(ex.Message)
            End Try

    End Sub

    Sub Validate_Entry(obsv As String, obsv1 As String, stnid As String, elmcode As String, yy As String, mm As String, dd As String, hh As String)
        Dim Conflict As Boolean
        Dim C1, cpVal, dir, spd As String

        Conflict = False
        If obsv <> obsv1 Then
            MsgBox("Conflicting Values")
            ucrDDFF.BackColor = Color.Yellow
            cpVal = ucrDDFF.TextboxValue
            Conflict = True
            ucrDDFF.TextboxValue = ""

            Do While Conflict = True
                C1 = InputBox("Reapeat Entry Please!", "Key Entry Verification")
                If C1 <> cpVal Then
                    cpVal = C1
                    Conflict = True
                    MsgBox("Re Entry Conflict! Try Again")
                Else
                    ucrDDFF.TextboxValue = C1
                    Conflict = False
                    dir = Strings.Left(C1, Int(frmNewHourlyWind.txtDirectionDigits.Text))
                    spd = Strings.Right(C1, Int(frmNewHourlyWind.txtSpeedDigits.Text))

                    'MsgBox(dir & spd)
                    'Update database with the verified value
                    If MsgBox("Update Conflicting Value?", vbYesNo, "Confirm Update") = MsgBoxResult.Yes Then
                        ' Update Direction value
                        If Not objKeyPress.Db_Update_Conflicts(stnid, 112, yy, mm, dd, hh, dir) Then
                            MsgBox("Direction Update Failure")
                        End If

                        ' Update Speed value
                        If Not objKeyPress.Db_Update_Conflicts(stnid, 111, yy, mm, dd, hh, spd) Then
                            MsgBox("Direction Update Failure")
                        End If
                    Else
                        MsgBox("Update Cancelled by operator")
                        ucrDDFF.TextboxValue = ""
                    End If
                    ucrDDFF.BackColor = Color.White
                End If
            Loop
        End If
    End Sub
End Class

