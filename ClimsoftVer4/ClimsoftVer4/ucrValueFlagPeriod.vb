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

Public Class ucrValueFlagPeriod
    Private bFirstLoad As Boolean = True
    Public Event evtGoToNextVFPControl(sender As Object, e As KeyEventArgs)
    Private bIncludePeriod As Boolean = True

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        ucrValue.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
        If bIncludePeriod Then
            ucrPeriod.SetTableName(strNewTable)
        End If
    End Sub

    Public Sub SetValueFlagPeriodFields(strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        SetFields(New List(Of String)({strValueFieldName, strFlagFieldName, strPeriodFieldName}))
        SetValueField(strValueFieldName)
        SetFlagField(strFlagFieldName)
        SetPeriodField(strPeriodFieldName)
        bIncludePeriod = True
    End Sub
    'added this to set value and flag field
    Public Sub SetValueFlagFields(strValueFieldName As String, strFlagFieldName As String)
        SetFields(New List(Of String)({strValueFieldName, strFlagFieldName}))
        SetValueField(strValueFieldName)
        SetFlagField(strFlagFieldName)
        bIncludePeriod = False
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

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
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

    Public Sub SetBackColor(backColor As Color)
        ucrValue.SetBackColor(backColor)
        ucrFlag.SetBackColor(backColor)
        If bIncludePeriod Then
            ucrPeriod.SetBackColor(backColor)
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim lstValueFlagPeriod As List(Of Object)

        MyBase.SetValue(objNewValue)
        lstValueFlagPeriod = TryCast(objNewValue, List(Of Object))
        'TODO
        'Not sure about this check. Not certain about whether we should force the
        'developer to always pass a list with a min of 2 values for Value and flag
        If lstValueFlagPeriod.Count = 3 Then
            ucrValue.SetValue(lstValueFlagPeriod(0))
            ucrFlag.SetValue(lstValueFlagPeriod(1))
            If bIncludePeriod Then
                ucrPeriod.SetValue(lstValueFlagPeriod(2))
            End If
        ElseIf lstValueFlagPeriod.Count = 2 Then
            ucrValue.SetValue(lstValueFlagPeriod(0))
            ucrFlag.SetValue(lstValueFlagPeriod(1))
        ElseIf lstValueFlagPeriod.Count = 1 Then
            ucrValue.SetValue(lstValueFlagPeriod(0))
        End If
    End Sub

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

    Public Function IsElementValueEmpty() As Boolean
        Return ucrValue.IsEmpty()
    End Function

    Public Function IsElementFlagEmpty() As Boolean
        Return ucrFlag.IsEmpty()
    End Function

    Public Function IsElementPeriodEmpty() As Boolean
        Return ucrPeriod.IsEmpty()
    End Function

    Public Sub SetElementValueValidation(Optional iLowerLimit As Decimal = Decimal.MinValue, Optional iUpperLimit As Decimal = Decimal.MaxValue)
        ucrValue.SetValidationTypeAsNumeric(dcmMin:=iLowerLimit, dcmMax:=iUpperLimit)
    End Sub

    Public Function IsValuesValid() As Boolean
        Return IsElementValueValid() AndAlso IsElementFlagValid() AndAlso IsElementPeriodValid()
    End Function

    Public Function IsElementValueValid() As Boolean
        Return ucrValue.ValidateValue
    End Function

    Public Function IsElementFlagValid() As Boolean
        Dim bValuesCorrect As Boolean = True

        'if value is empty then set flag as M else remove the M
        If ucrValue.IsEmpty Then
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
        Return If(bIncludePeriod, ucrPeriod.ValidateValue, True)
    End Function

    Private Sub ucrValueFlagPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            ucrValue.bValidateSilently = True
            ucrValue.SetValidationTypeAsNumeric()
            ucrFlag.SetTextToUpper()
            ucrFlag.SetAsReadOnly()
            SetTextBoxSize()
            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrValueFlagPeriod_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrValue.evtKeyDown, ucrFlag.evtKeyDown, ucrPeriod.evtKeyDown

        If e.KeyCode = Keys.Enter Then
            If sender Is ucrValue.txtBox Then
                'check ucrValue input. if value is empty then set flag as M else remove the M
                If ucrValue.IsEmpty Then
                    ucrFlag.SetValue("M")
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                ElseIf PreValidateValue() Then
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                ElseIf ucrValue.GetValue = "M"
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                Else
                    DoQCForValue()
                End If
            ElseIf sender Is ucrFlag.txtBox Then
                If IsElementFlagValid() Then
                    'My.Computer.Keyboard.SendKeys("{TAB}")
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                End If
            End If
        End If

        OnevtKeyDown(sender, e)
    End Sub

    Private Sub ucrValue_TextChanged(sender As Object, e As EventArgs) Handles ucrValue.evtTextChanged
        OnevtTextChanged(sender, e)
    End Sub

    Private Sub ucrValue_evtValueChanged(sender As Object, e As EventArgs) Handles ucrValue.evtValueChanged
        DoQCForValue()
        IsElementFlagValid()
        OnevtValueChanged(sender, e)
    End Sub

    Private Function DoQCForValue() As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim bValidateSilently As Boolean
        Dim bSuppressChangedEvents As Boolean

        If ucrValue.IsEmpty Then
            bValuesCorrect = True
            If Not ucrFlag.IsEmpty AndAlso ucrFlag.GetValue <> "M" Then
                'remove the flag
                ucrFlag.SetValue("")
            End If
        Else
            'Check for an observation flag in the ucrValue.
            'If a flag exists then separate and place it in the  ucrValueFlag 
            If Not IsNumeric(Strings.Right(ucrValue.GetValue, 1)) AndAlso IsNumeric(Strings.Left(ucrValue.GetValue, Strings.Len(ucrValue.GetValue) - 1)) Then
                'Get observation flag from the ucrValue (the last character). If its an "M" just set flag as empty text
                ucrFlag.SetValue(If(Strings.Right(ucrValue.GetValue, 1) = "M", "", Strings.Right(ucrValue.GetValue, 1)))

                'Get the observation value by leaving out the last character  
                bSuppressChangedEvents = ucrValue.bSuppressChangedEvents
                ucrValue.bSuppressChangedEvents = True
                ucrValue.SetValue(Strings.Left(ucrValue.GetValue, Strings.Len(ucrValue.GetValue) - 1))
                ucrValue.bSuppressChangedEvents = bSuppressChangedEvents
            Else
                'if the value is just an M, then interpret it as a user's intention to put missing value
                If ucrValue.GetValue = "M" Then
                    ucrFlag.SetValue("M")
                    ucrValue.SetValue("")
                Else
                    'remove the flag
                    ucrFlag.SetValue("")
                End If
            End If

            'validate value loudly  
            bValidateSilently = ucrValue.bValidateSilently
            ucrValue.bValidateSilently = False
            bValuesCorrect = ucrValue.ValidateValue()
            ucrValue.bValidateSilently = bValidateSilently
        End If
        Return bValuesCorrect
    End Function

    ''' <summary>
    ''' checks if the value input in the ucrValue will be a valid value or not 
    ''' when Quality Control is applied to the input
    ''' </summary>
    ''' <returns></returns>
    Public Function PreValidateValue() As Boolean
        If ucrValue.ValidateText(ucrValue.GetValue) OrElse ucrValue.ValidateText(Strings.Left(ucrValue.GetValue, Strings.Len(ucrValue.GetValue) - 1)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SetTextBoxSize()
        ucrValue.SetElementValueSize(New Size(51, 20))
        ucrFlag.SetElementValueSize(New Size(27, 20))
        ucrPeriod.SetElementValueSize(New Size(33, 20))
    End Sub

    'This is temporary
    Private Sub ucrFlag_evtValueChanged(sender As Object, e As EventArgs) Handles ucrFlag.evtValueChanged
        'ucrFlag should is set as readonly. That changes its back color to the one given below
        'for consistency we are rienforcing this color everytime a value is changed on this control
        'to override the white color being set on textbox validation subroutine
        ucrFlag.SetBackColor(SystemColors.Control)
    End Sub

End Class
