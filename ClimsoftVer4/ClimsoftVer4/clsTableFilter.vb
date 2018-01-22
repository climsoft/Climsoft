' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
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

' A TableFilter object defines a filter on a table in the data base. 
' This Is usually to be able to set a subset of records from a table for display.

Public Class TableFilter
    ' If a TableFilter is not a Combined Filter (bIsCombinedFilter = False) then it consists of 
    ' a) a field in a table to filter on e.g. "Element"
    ' b) values to compare with the field's values e.g. "Rain" (values could also come from clsValues)
    ' c) an operation (in SQL language?) between field and values e.g. "IN"
    ' These are then combined to filter the table e.g. 'Element IN "Rain"'
    Private strField As String
    Private strOperator As String

    ' The values for the filter can either be a static list of values or from a DataCall object which gets values from a calculation on the database
    ' If using static values, bValuesFromDataCall = False, otherwise bValuesFromDataCall = True 
    Private bValuesFromDataCall As Boolean = False
    Private lstValues As List(Of String)
    Private clsValues As DataCall

    ' A TableFilter could also be a combination of two TableFilter objects e.g. Element IN "Rain" AND Station IN "Maseno"
    ' In this case bIsCombinedFilter = True
    ' Instead of using strField and lstValues/clsValues there will be a left and right TableFilter
    ' strOperation defines how the filters are combined, usually AND or OR.
    ' TODO How do we do NOT?
    Private bIsCombinedFilter As Boolean = False
    Private clsLeftFilter As TableFilter
    Private clsRightFilter As TableFilter

    ' If False then the filter will have NOT at the start of the condition
    Private bIsPositiveCondition As Boolean = True

    Public Sub SetField(strNewField As String)
        strField = strNewField
        bIsCombinedFilter = False
    End Sub

    Public Sub SetOperator(strNewOperator As String)
        strOperator = strNewOperator
        bIsCombinedFilter = False
    End Sub

    Public Sub SetValues(lstNewValues As List(Of String))
        lstValues = lstNewValues
        bValuesFromDataCall = False
        bIsCombinedFilter = False
    End Sub

    Public Sub SetValue(strNewValue As String)
        SetValues(New List(Of String)({strNewValue}))
    End Sub

    Public Sub SetValues(clsNewDataCall As DataCall)
        clsValues = clsNewDataCall
        bValuesFromDataCall = True
        bIsCombinedFilter = False
    End Sub

    Public Sub SetPositiveCondition(bNewIsPositiveCondition As Boolean)
        bIsPositiveCondition = bNewIsPositiveCondition
    End Sub

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, lstNewValues As List(Of String), Optional bNewIsPositiveCondition As Boolean = True)
        SetField(strNewField:=strNewField)
        SetOperator(strNewOperator:=strNewOperator)
        SetValues(lstNewValues:=lstNewValues)
        SetPositiveCondition(bNewIsPositiveCondition:=bNewIsPositiveCondition)
    End Sub

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, strNewValue As String, Optional bNewIsPositiveCondition As Boolean = True)
        SetFieldCondition(strNewField:=strNewField, strNewOperator:=strNewOperator, lstNewValues:=New List(Of String)({strNewValue}), bNewIsPositiveCondition:=bNewIsPositiveCondition)
    End Sub

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, clsNewDataCall As DataCall, Optional bNewIsPositiveCondition As Boolean = True)
        SetField(strNewField:=strNewField)
        SetOperator(strNewOperator:=strNewOperator)
        SetValues(clsNewDataCall:=clsNewDataCall)
        SetPositiveCondition(bNewIsPositiveCondition:=bNewIsPositiveCondition)
    End Sub

    Public Sub SetLeftFilter(clsNewLeftFilter As TableFilter)
        clsLeftFilter = clsNewLeftFilter
        bIsCombinedFilter = True
    End Sub

    Public Sub SetRightFilter(clsNewRightFilter As TableFilter)
        clsRightFilter = clsNewRightFilter
        bIsCombinedFilter = True
    End Sub

    Public Sub SetLeftAndRightFilter(clsNewLeftFilter As TableFilter, clsNewRightFilter As TableFilter)
        SetLeftFilter(clsNewLeftFilter:=clsNewLeftFilter)
        SetRightFilter(clsNewRightFilter:=clsNewRightFilter)
    End Sub
End Class