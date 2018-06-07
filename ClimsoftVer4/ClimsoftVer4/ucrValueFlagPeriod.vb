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

        'If {ENTER} key is pressed
        'If e.KeyCode = Keys.Enter Then
        ''My.Computer.Keyboard.SendKeys("{TAB}")
        'ucrValue.TextHandling(sender, e)
        'RaiseEvent evtGoToNextVFPControl(Me, e)
        'End If

        If e.KeyCode = Keys.Enter Then

            If sender Is ucrValue.txtBox Then
                'do QC for ucrValue first
                If QCForValue() Then
                    'if value is empty then set flag as M else remove the M
                    If ucrValue.IsEmpty Then
                        ucrFlag.SetValue("M")
                    ElseIf ucrFlag.GetValue = "M"
                        ucrFlag.SetValue("")
                    End If

                    'then do QC for flag
                    If QcForFlag() Then
                        'My.Computer.Keyboard.SendKeys("{TAB}")
                        RaiseEvent evtGoToNextVFPControl(Me, e)
                    End If
                End If
            ElseIf sender Is ucrFlag.txtBox Then
                If QcForFlag() Then
                    'My.Computer.Keyboard.SendKeys("{TAB}")
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                End If
            End If
        End If

    End Sub

    Private Sub ucrValue_evtValueChanged(sender As Object, e As EventArgs) Handles ucrValue.evtValueChanged

        QCForValue()

        'Remove the missing value flag for non empty
        If Not ucrValue.IsEmpty AndAlso ucrFlag.GetValue = "M" Then
            ucrFlag.SetValue("")
        End If

        QcForFlag()

    End Sub

    Private Function QCForValue() As Boolean
        Dim bValuesCorrect As Boolean = False
        Dim bValidateSilently As Boolean
        Dim bSuppressChangedEvents As Boolean

        If ucrValue.IsEmpty Then
            'empty ucrValue is a valid value
            bValuesCorrect = True
        Else
            'Check for an observation flag in the ucrValue.
            'If a flag exists then separate and place it in the  ucrValueFlag 
            If Not IsNumeric(Strings.Right(ucrValue.GetValue, 1)) AndAlso IsNumeric(Strings.Left(ucrValue.GetValue, Strings.Len(ucrValue.GetValue) - 1)) Then
                'Get observation flag from the ucrValue (the last character). 
                ucrFlag.SetValue(Strings.Right(ucrValue.GetValue, 1))

                'Get the observation value by leaving out the last character  
                bSuppressChangedEvents = ucrValue.bSuppressChangedEvents
                ucrValue.bSuppressChangedEvents = True
                ucrValue.SetValue(Strings.Left(ucrValue.GetValue, Strings.Len(ucrValue.GetValue) - 1))
                ucrValue.bSuppressChangedEvents = bSuppressChangedEvents
            End If

            'validate value loudly  
            bValidateSilently = ucrValue.bValidateSilently
            ucrValue.bValidateSilently = False
            bValuesCorrect = ucrValue.ValidateValue()
            ucrValue.bValidateSilently = bValidateSilently
        End If

        'If bValuesCorrect Then
        '    'if value is empty then set flag as M else remove the M
        '    If ucrValue.IsEmpty Then
        '        ucrFlag.SetValue("M")
        '    ElseIf ucrFlag.GetValue = "M"
        '        ucrFlag.SetValue("")
        '    End If

        '    'do QC for flag
        '    bValuesCorrect = QcForFlag()
        'End If

        Return bValuesCorrect
    End Function

    'QC checks for flag
    Public Function QcForFlag() As Boolean
        Dim bValuesCorrect As Boolean = True

        'if value is empty then set flag as M else remove the M
        If ucrValue.IsEmpty Then
            If ucrFlag.GetValue = "M" OrElse ucrFlag.IsEmpty Then
                bValuesCorrect = True
            Else
                MsgBox("M is the expected flag for a missing value", MsgBoxStyle.Critical)
                ucrFlag.SetBackColor(Color.Cyan)
                ucrFlag.GetFocus()
                bValuesCorrect = False
            End If
        Else
            If ucrFlag.GetValue = "M" Then
                'MsgBox("M is the expected flag for a missing value", MsgBoxStyle.Critical)
                ucrFlag.SetBackColor(Color.Cyan)
                ucrFlag.GetFocus()
                bValuesCorrect = False
            Else
                bValuesCorrect = True
            End If
        End If

        Return bValuesCorrect
    End Function

    Private Sub SetTextBoxSize()
        ucrValue.SetElementValueSize(New Size(51, 20))
        ucrFlag.SetElementValueSize(New Size(27, 20))
        ucrPeriod.SetElementValueSize(New Size(33, 20))
    End Sub

    Private Sub ucrFlag_evtValueChanged(sender As Object, e As EventArgs) Handles ucrFlag.evtValueChanged
        'ucrFlag should is set as readonly. That changes its back color to the one given below
        'for consistency we are rienforcing this color everytime a value is changed on this control
        'to override the white color being set on textbox validation subroutine
        ucrFlag.SetBackColor(SystemColors.Control)
    End Sub


End Class
