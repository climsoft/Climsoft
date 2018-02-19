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

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        ucrValue.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
        ucrPeriod.SetTableName(strNewTable)
    End Sub

    Public Sub SetValueFlagPeriodFields(strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        SetFields(New List(Of String)({strValueFieldName, strFlagFieldName, strPeriodFieldName}))
        SetValueField(strValueFieldName)
        SetFlagField(strFlagFieldName)
        SetPeriodField(strPeriodFieldName)
    End Sub

    Public Sub SetTableNameAndValueFlagPeriodFields(strNewTable As String, strValueFieldName As String, strFlagFieldName As String, strPeriodFieldName As String)
        SetTableName(strNewTable)
        SetValueFlagPeriodFields(strValueFieldName, strFlagFieldName, strPeriodFieldName)
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
        ucrPeriod.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overrides Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        MyBase.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrValue.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFlag.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrPeriod.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrValue.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFlag.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrPeriod.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            ucrValue.PopulateControl()
            ucrFlag.PopulateControl()
            ucrPeriod.PopulateControl()
        End If
    End Sub

    Public Sub Clear()
        ucrValue.Clear()
        ucrFlag.Clear()
        ucrPeriod.Clear()
    End Sub

    Private Sub ucrValueFlagPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            ucrValue.SetValidationTypeAsNumeric()
            ucrFlag.SetTextToUpper()
            bFirstLoad = False
        End If

    End Sub

    Private Sub ucrValueFlagPeriod_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrValue.evtKeyDown, ucrFlag.evtKeyDown, ucrPeriod.evtKeyDown

        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            'My.Computer.Keyboard.SendKeys("{TAB}")
            ucrValue.TextHandling(sender, e)
            RaiseEvent evtGoToNextVFPControl(Me, e)
        End If

    End Sub

    Private Sub ucrValue_TextChanged(sender As Object, e As EventArgs) Handles ucrValue.evtTextChanged

        If Not ucrValue.IsEmpty AndAlso Not IsNumeric(Strings.Right(ucrValue.TextboxValue, 1)) Then
            'Get observation flag from the texbox and convert it to Uppercase. Flag is a single letter added as the last character
            'to the value string in the textbox.
            ucrFlag.TextboxValue = Strings.Right(ucrValue.TextboxValue, 1)

            'Get the observation value by leaving out the last character from the string entered in the textbox
            ucrValue.TextboxValue = Strings.Left(ucrValue.TextboxValue, ucrValue.TextboxValue.Length - 1)

            'Check that numeric value has been entered for observation value
            If Not IsNumeric(ucrValue.TextboxValue) Then
                'tabNext = False
                If Not ucrValue.IsEmpty Then
                    MsgBox("Number expected!", MsgBoxStyle.Critical)
                End If
            End If
            ucrFlag.GetFocus()
        End If
        If ucrValue.IsEmpty AndAlso ucrValue.bValidate Then
            If Not ucrFlag.TextboxValue = "M" Then
                If ucrFlag.IsEmpty Then
                    ucrFlag.TextboxValue = "M"
                    ucrFlag.GetFocus()
                Else
                    MsgBox("M is the expected flag for a missing value", MsgBoxStyle.Critical)
                End If
            End If
        End If

    End Sub

End Class
