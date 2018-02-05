﻿' CLIMSOFT - Climate Database Management System
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
Public Class ucrBaseDataLink
    Protected clsDataDefinition As DataCall
    Protected dtbRecords As DataTable
    Protected dctLinkedControlsFilters As Dictionary(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter))


    Public Event evtKeyDown(sender As Object, e As KeyEventArgs)
    Public Event evtValueChanged()

    ' ucrBaseDataLink is a base control for a control to connect to the database
    ' Infomation about how the control connects to the database will be here
    ' Including: reading/writing, which tables/fields/records to connect to

    ' Inherited controls:
    ' textbox, nud, checkbox, combobox, listbox etc.

    ' Inherited from these can be controls for common fields:
    ' station selector, element selector, tmax entry etc.

    Public Sub SetDataDefinition(clsNewDataDefinition As DataCall)
        clsDataDefinition = clsNewDataDefinition
    End Sub

    Private Sub CreateDataDefinition()
        If clsDataDefinition Is Nothing Then
            clsDataDefinition = New DataCall
        End If
    End Sub

    Public Overridable Sub SetTableName(strNewTable As String)
        CreateDataDefinition()
        clsDataDefinition.SetTableName(strNewTable:=strNewTable)
    End Sub

    Public Sub SetTable(dbsNewTable As Entity.DbSet)
        CreateDataDefinition()
        clsDataDefinition.SetTable(dbsNewTable:=dbsNewTable)
    End Sub

    Public Sub SetFields(dctNewFields As Dictionary(Of String, List(Of String)))
        CreateDataDefinition()
        clsDataDefinition.SetFields(dctNewFields:=dctNewFields)
        SetSortByItems()
    End Sub

    Public Sub SetFields(lstNewFields As List(Of String))
        CreateDataDefinition()
        clsDataDefinition.SetFields(lstNewFields:=lstNewFields)
        SetSortByItems()
    End Sub

    Public Sub SetField(strNewField As String)
        CreateDataDefinition()
        clsDataDefinition.SetFields(lstNewFields:=New List(Of String)({strNewField}))
        SetSortByItems()
    End Sub

    Public Sub SetTableAndFields(dbsNewTable As Entity.DbSet, lstNewFields As List(Of String))
        CreateDataDefinition()
        clsDataDefinition.SetTableAndFields(dbsNewTable:=dbsNewTable, lstNewFields:=lstNewFields)
        SetSortByItems()
    End Sub

    Public Sub SetTableAndField(dbsNewTable As Entity.DbSet, strNewField As String)
        CreateDataDefinition()
        clsDataDefinition.SetTableAndField(dbsNewTable:=dbsNewTable, strNewField:=strNewField)
        SetSortByItems()
    End Sub

    Public Overridable Sub SetFilter(clsNewFilter As TableFilter)
        CreateDataDefinition()
        clsDataDefinition.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overridable Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        CreateDataDefinition()
        clsDataDefinition.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Sub SetSortByItems()
        '    tsSortBy.DropDownItems.Clear()
        '    For Each kvpField As KeyValuePair(Of String, String) In clsDataDefinition.GetFields()
        '        tsSortBy.DropDownItems.Add(kvpField.Value)
        '        tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Tag = kvpField.Key
        '        AddHandler tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Click, AddressOf Sort
        '    Next
    End Sub

    Protected Overridable Sub Sort()
        For Each tsField As ToolStripMenuItem In tsSortBy.DropDownItems
            If tsField.Checked Then
                ' dtbStations.DefaultView.Sort = tsField.Tag & " ASC"
                ' refresh display
            End If
        Next
    End Sub

    Public Overridable Function ValidateValue() As Boolean
        Return True
    End Function

    Public Sub UpdateDataTable()
        dtbRecords = clsDataDefinition.GetDataTable(GetLinkedControlsFilter())
    End Sub

    Public Overridable Sub PopulateControl()
        UpdateDataTable()
    End Sub

    Public Sub OnevtKeyDown(sender As Object, e As KeyEventArgs)
        RaiseEvent evtKeyDown(sender, e)
    End Sub

    Public Overridable Function GetValue() As Object
        Return Nothing
    End Function

    Public Overridable Function GetValue(strFieldName As String) As Object
        Dim tempRow As DataRow
        Dim lstTemp As New List(Of String)

        If dtbRecords.Rows.Count = 1 Then
            Return dtbRecords.Rows(0).Field(Of String)(strFieldName)
        ElseIf dtbRecords.Rows.Count > 1 Then
            For Each tempRow In dtbRecords.Rows
                lstTemp.Add(tempRow.Field(Of String)(strFieldName))
            Next
            Return lstTemp
        Else
            Return Nothing
        End If

    End Function

    'Private Sub AddLinkedControls(dctNewDataLinkControls As Dictionary(Of String, ucrBaseDataLink))
    '    For Each kvpTemp As KeyValuePair(Of String, ucrBaseDataLink) In dctNewDataLinkControls
    '        dctLinkedControls.Add(kvpTemp.Key, kvpTemp.Value)
    '        AddHandler kvpTemp.Value.evtValueChanged, AddressOf LinkedControls_evtValueChanged
    '    Next
    'End Sub

    Public Sub AddLinkedControl(ucrLinkedDataControl As ucrBaseDataLink, strNewField As String, strNewOperator As String, Optional bNewIsPositiveCondition As Boolean = True)
        dctLinkedControlsFilters.Add(ucrLinkedDataControl, New TableFilter(strNewField:=strNewField, strNewOperator:=strNewOperator, bNewIsPositiveCondition:=bNewIsPositiveCondition))
        AddHandler ucrLinkedDataControl.evtValueChanged, AddressOf LinkedControls_evtValueChanged
    End Sub

    Private Sub LinkedControls_evtValueChanged()
        UpdateDataTable()
    End Sub

    Protected Sub UpdateDctLinkedControlsFilters()
        Dim tempTableFilter As TableFilter
        Dim strTempFieldName As String

        For Each ucrTemp As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            tempTableFilter = dctLinkedControlsFilters(ucrTemp).Value
            strTempFieldName = dctLinkedControlsFilters(ucrTemp).Key

            If tempTableFilter.IsCombinedFilter Then
                tempTableFilter.SetLeftAndRightFilter(tempTableFilter.GetLeftFilter, tempTableFilter.GetRightFilter)
            Else
                If tempTableFilter.IsArrayOperator Then
                    If tempTableFilter.IsValuesFromDataCall Then
                        tempTableFilter.SetDataCallValues(ucrTemp.GetLinkingDataCall())
                    Else
                        tempTableFilter.SetValues(ucrTemp.GetValue(strTempFieldName))
                    End If
                Else
                    tempTableFilter.SetValue(ucrTemp.GetValue(strTempFieldName))
                End If
            End If
            'dctLinkedControlsFilters(ucrTemp).SetValue(ucrTemp.GetValue())
        Next
    End Sub

    Public Function GetLinkedControlsFilter() As TableFilter
        Dim clsOveralControlsFilter As TableFilter

        UpdateDctLinkedControlsFilters()

        If dctLinkedControlsFilters.Count = 0 Then
            clsOveralControlsFilter = Nothing
        ElseIf dctLinkedControlsFilters.Count > 1 Then
            clsOveralControlsFilter = New TableFilter
            For i = 0 To dctLinkedControlsFilters.Count - 2
                If i = 0 Then
                    clsOveralControlsFilter.SetLeftFilter(dctLinkedControlsFilters.Values(i).Clone())
                    clsOveralControlsFilter.SetRightFilter(dctLinkedControlsFilters.Values(i + 1).Clone())
                    clsOveralControlsFilter.SetOperator("AND")
                Else
                    clsOveralControlsFilter.SetLeftFilter(clsOveralControlsFilter.clone())
                    clsOveralControlsFilter.SetRightFilter(dctLinkedControlsFilters.Values(i + 1).Clone())
                End If
            Next
        Else
            clsOveralControlsFilter = dctLinkedControlsFilters.Values(0).clone()
        End If
        Return clsOveralControlsFilter
    End Function

    Public Overridable Function GetLinkingDataCall() As DataCall
        MessageBox.Show("Developer error: The Linking Datacall of " & Me.Name & " has not been overriden ", caption:="Developer error")
        Return Nothing
    End Function
End Class