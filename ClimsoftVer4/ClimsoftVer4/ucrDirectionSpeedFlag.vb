' R- Instat
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
            'ucrDDFF.SetValue(lstValues(0) + lstValues(1))
            ucrDDFF.SetValue("")
            SetElementDirectionValue(lstValues(0))
            SetElementSpeedValue(lstValues(1))
            SetElementFlagValue(lstValues(2))
        End If
    End Sub

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

    Public Sub SetElementDirectionValidation(Optional iLowerLimit As Decimal = Decimal.MinValue, Optional iUpperLimit As Decimal = Decimal.MaxValue)
        ucrDirection.SetValidationTypeAsNumeric(dcmMin:=iLowerLimit, dcmMax:=iUpperLimit)
    End Sub

    Public Sub SetElementSpeedValidation(Optional iLowerLimit As Decimal = Decimal.MinValue, Optional iUpperLimit As Decimal = Decimal.MaxValue)
        ucrSpeed.SetValidationTypeAsNumeric(dcmMin:=iLowerLimit, dcmMax:=iUpperLimit)
    End Sub

    Public Sub SetElementDirectionDigits(iNewDirectionDigits As Integer)
        iDirectionDigits = iNewDirectionDigits
    End Sub

    Public Sub SetElementSpeedDigits(iNewSpeedDigits As Integer)
        iSpeedDigits = iNewSpeedDigits
    End Sub

    Public Function IsValuesValid() As Boolean
        Return IsElementDirectionValueValid() AndAlso IsElementSpeedValueValid() AndAlso IsElementFlagValueValid()
    End Function

    Public Function IsElementDirectionValueValid() As Boolean
        Return DoQcForDirection()
    End Function

    Public Function IsElementSpeedValueValid() As Boolean
        Return DoQcForSpeed()
    End Function

    Public Function IsElementFlagValueValid() As Boolean
        Return DoQcForFlag()
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
            ucrDirection.bValidateSilently = False
            ucrSpeed.bValidateSilently = False
            ucrDirection.SetValidationTypeAsNumeric()
            ucrSpeed.SetValidationTypeAsNumeric()
            ucrFlag.SetTextToUpper()
            ucrFlag.SetAsReadOnly()
            bFirstLoad = False
        End If
    End Sub

    'Todo remove flag event
    Private Sub ucrDirectionSpeedFlag_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrDDFF.evtKeyDown, ucrDirection.evtKeyDown, ucrSpeed.evtKeyDown
        'TODO
        'FIND AWAY OF PASSING ME AND THE SENDER TO THE evtGoToNextVFPControl
        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            If DoInputQCCheck(sender) Then
                RaiseEvent evtGoToNextDSFControl(Me, e)
            End If
        End If
    End Sub

    'TODO. Do this in the event value changed?
    Private Sub ucrDDFF_Leave(sender As Object, e As EventArgs) Handles ucrDDFF.Leave, ucrDirection.Leave, ucrSpeed.Leave
        DoInputQCCheck(sender)
    End Sub
    ''' <summary>
    ''' this function checks does quality control based on the user input. 
    ''' It gets the user input from the passed sender object.
    ''' Returns true if the input is valid and false otherwise
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <returns></returns>
    Private Function DoInputQCCheck(sender As Object) As Boolean
        Dim bValuesCorrect As Boolean = False

        If sender Is ucrDDFF.txtBox Then
            If DoQCForUcrDDFFUserInput() Then
                bValuesCorrect = True
            End If
        ElseIf sender Is ucrDirection.txtBox Then
            If DoQcForDirection() Then
                If Not ucrDirection.IsEmpty AndAlso ucrFlag.GetValue = "M" Then
                    ucrFlag.SetValue("")
                End If
                bValuesCorrect = DoQcForFlag()
            End If
        ElseIf sender Is ucrSpeed.txtBox Then
            If DoQcForSpeed() Then
                If Not ucrSpeed.IsEmpty AndAlso ucrFlag.GetValue = "M" Then
                    ucrFlag.SetValue("")
                End If
                bValuesCorrect = DoQcForFlag()
            End If
        End If
        Return bValuesCorrect
    End Function

    Private Function DoQCForUcrDDFFUserInput() As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim bValidateSilently As Boolean

        If ucrDDFF.IsEmpty() Then
            'empty ucrDDFF is a valid value
            bValuesCorrect = True
        Else
            'check for an observation flag. Must be the last character if it's included
            If Not IsNumeric(Strings.Right(ucrDDFF.GetValue, 1)) AndAlso IsNumeric(Strings.Left(ucrDDFF.GetValue, ucrDDFF.GetValue.Length - 1)) Then
                'Get observation flag (last character) and set it to ucrFlag
                ucrFlag.SetValue(Strings.Right(ucrDDFF.GetValue, 1))
                'Remove the last character and set the result as the new DDFF value 
                ucrDDFF.SetValue(Strings.Left(ucrDDFF.GetValue, ucrDDFF.GetValue.Length - 1))
            End If

            If IsNumeric(ucrDDFF.GetValue) Then
                'check the length of DDFF matches with direction and speed digits
                If ucrDDFF.GetValue.Length = iDirectionDigits + iSpeedDigits Then
                    'If number of digits is correct then separate dd and ff
                    'switch of validation notification temprary then restore
                    bValidateSilently = ucrSpeed.bValidateSilently
                    ucrSpeed.bValidateSilently = True
                    ucrSpeed.SetValue(Strings.Right(ucrDDFF.GetValue, iSpeedDigits))
                    ucrSpeed.bValidateSilently = bValidateSilently

                    bValidateSilently = ucrDirection.bValidateSilently
                    ucrDirection.bValidateSilently = True
                    ucrDirection.SetValue(Strings.Left(ucrDDFF.GetValue, iDirectionDigits))
                    ucrDirection.bValidateSilently = bValidateSilently

                    'proceed to do QC checks for direction and speed
                    If DoQcForDirection() AndAlso DoQcForSpeed() Then
                        ucrDDFF.SetBackColor(Color.White)
                        bValuesCorrect = True
                    Else
                        ucrDDFF.SetBackColor(Color.Cyan)
                        bValuesCorrect = False
                    End If

                Else
                    ucrDDFF.SetBackColor(Color.Cyan)
                    bValuesCorrect = False
                    MsgBox("Wrong number of digits for ddff!", MsgBoxStyle.Exclamation)
                End If

            Else
                ucrDDFF.SetBackColor(Color.Red)
                MsgBox("Number expected!", MsgBoxStyle.Critical)
                bValuesCorrect = False
            End If
        End If

        If bValuesCorrect Then
            'if values are empty then set flag as M else remove the M if its the currently set flag
            If ucrDDFF.IsEmpty AndAlso ucrDirection.IsEmpty AndAlso ucrSpeed.IsEmpty Then
                ucrFlag.SetValue("M")
            ElseIf ucrFlag.GetValue = "M"
                ucrFlag.SetValue("")
            End If

            'then do QC for flag
            bValuesCorrect = DoQcForFlag()
        End If

        Return bValuesCorrect
    End Function

    'QC checks for  direction
    Private Function DoQcForDirection() As Boolean
        'TODO. Should we check ucrDirection.GetValue.Length = iDirectionDigits ?
        Return ucrDirection.ValidateValue()
    End Function

    'QC checks for speed
    Public Function DoQcForSpeed() As Boolean
        'TODO. Should we check ucrSpeed.GetValue.Length = iSpeedDigits ?
        Return ucrSpeed.ValidateValue()
    End Function

    'QC checks for flag
    Private Function DoQcForFlag() As Boolean
        Dim bValuesCorrect As Boolean = True

        'if value is empty then set flag as M else remove the M
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

    Private Sub ucrFlag_evtValueChanged(sender As Object, e As EventArgs) Handles ucrFlag.evtValueChanged
        'ucrFlag should is set as readonly. That changes its back color to the one given below
        'for consistency we are rienforcing this color everytime a value is changed on this control
        'to override the white color being set on textbox validation subroutine
        ucrFlag.SetBackColor(SystemColors.Control)
    End Sub

End Class

