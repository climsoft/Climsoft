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
Public Class ucrBaseDataLink
    Protected clsDataDefinition As New DataCall

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

    Public Sub SetTable(dbsNewTable As Entity.DbSet)
        CreateDataDefinition()
        clsDataDefinition.SetTable(dbsNewTable:=dbsNewTable)
    End Sub

    Public Sub SetFields(dctNewFields As Dictionary(Of String, String))
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

    Public Sub SetFilter(clsNewFilter As TableFilter)
        CreateDataDefinition()
        clsDataDefinition.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Sub SetSortByItems()
        tsSortBy.DropDownItems.Clear()
        For Each kvpField As KeyValuePair(Of String, String) In clsDataDefinition.GetFields()
            tsSortBy.DropDownItems.Add(kvpField.Value)
            tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Tag = kvpField.Key
            AddHandler tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Click, AddressOf Sort
        Next
    End Sub

    Protected Overridable Sub Sort()
        For Each tsField As ToolStripMenuItem In tsSortBy.DropDownItems
            If tsField.Checked Then
                ' dtbStations.DefaultView.Sort = tsField.Tag & " ASC"
                ' refresh display
            End If
        Next
    End Sub

    Public Overridable Function ValidateSelection() As Boolean
        Return True
    End Function
End Class