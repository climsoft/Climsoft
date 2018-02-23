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
    Public Event evtGoToNextVFPControl(sender As Object, e As KeyEventArgs)

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        ucrDDFF.SetTableName(strNewTable)
        ucrDD.SetTableName(strNewTable)
        ucrFF.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
    End Sub

    Public Sub SetDDFFFlagFields(strDDFieldName As String, strFFFieldName As String, strFlagFieldName As String)
        SetFields(New List(Of String)({strDDFieldName, strFFFieldName, strFlagFieldName}))
        SetDDField(strDDFieldName)
        SetFFField(strFFFieldName)
        SetFlagField(strFlagFieldName)
    End Sub

    Public Sub SetTableNameAndDDFFFlagFields(strNewTable As String, strDDFieldName As String, strFFFieldName As String, strFlagFieldName As String)
        SetTableName(strNewTable)
        SetDDFFFlagFields(strDDFieldName, strFFFieldName, strFlagFieldName)
    End Sub

    Public Sub SetDDField(strFieldName As String)
        ucrDD.SetField(strFieldName)
    End Sub

    Public Sub SetFFField(strFieldName As String)
        ucrFF.SetField(strFieldName)
    End Sub

    Public Sub SetFlagField(strFieldName As String)
        ucrFlag.SetField(strFieldName)
    End Sub

    Public Overrides Sub SetFilter(clsNewFilter As TableFilter)
        MyBase.SetFilter(clsNewFilter)
        ucrDDFF.SetFilter(clsNewFilter:=clsNewFilter)
        ucrDD.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFF.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFlag.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overrides Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        MyBase.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrDDFF.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrDD.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFF.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFlag.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrDDFF.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrDD.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFF.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFlag.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            ucrDDFF.PopulateControl()
            ucrDD.PopulateControl()
            ucrFF.PopulateControl()
            ucrFlag.PopulateControl()
        End If
    End Sub

    Public Overrides Sub Clear()
        ucrDDFF.Clear()
        ucrDD.Clear()
        ucrFF.Clear()
        ucrFlag.Clear()
    End Sub

    Private Sub ucrDirectionSpeedFlag_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            ucrDDFF.SetValidationTypeAsNumeric()
            ucrDD.SetValidationTypeAsNumeric()
            ucrFF.SetValidationTypeAsNumeric()
            ucrFlag.SetTextToUpper()
            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrDirectionSpeedFlag_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrDDFF.evtKeyDown, ucrDD.evtKeyDown, ucrFF.evtKeyDown, ucrFlag.evtKeyDown

        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            'My.Computer.Keyboard.SendKeys("{TAB}")
            If sender Is ucrDDFF Then
                ucrDDFF.TextHandling(sender, e)
            End If
            RaiseEvent evtGoToNextVFPControl(Me, e)
        End If

    End Sub

    Private Sub ucrDDFF_TextChanged(sender As Object, e As EventArgs) Handles ucrDDFF.evtTextChanged



    End Sub

End Class
