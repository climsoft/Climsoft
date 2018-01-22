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
Imports System.Data.Entity

Public Class DataCall
    ' The table in the database to call values from
    Private dbsTable As DbSet
    ' The fields in the table which the values will be from
    ' The keys are the names of fields in the data base
    ' The values are how the field should be displayed to the user
    Private dctFields As Dictionary(Of String, String)

    Private objFields As Object = New Dynamic.ExpandoObject

    ' A TableFilter object which defines the rows in the table the values will be from
    Private clsFilter As New TableFilter

    Public Sub SetTable(dbsNewTable As DbSet)
        dbsTable = dbsNewTable
    End Sub

    Public Sub SetFields(dctNewFields As Dictionary(Of String, String))
        dctFields = dctNewFields
    End Sub

    Private Sub SetFieldsObject(emp)
        objFields = New Dynamic.ExpandoObject

        objFields.test = Function(x)

                         End Function
        For Each strField As String In dctFields.Keys
            CallByName(objFields, strField, CallType.Set, dctFields(strField))
        Next
    End Sub

    Public Sub SetFields(lstNewFields As List(Of String))
        Dim dctNewFields As New Dictionary(Of String, String)
        For Each strTemp As String In lstNewFields
            dctNewFields.Add(strTemp, strTemp)
        Next
        SetFields(dctNewFields:=dctNewFields)
    End Sub

    Public Sub SetField(strNewField As String)
        SetFields(New List(Of String)({strNewField}))
    End Sub

    Public Sub SetTableAndFields(dbsNewTable As DbSet, lstNewFields As List(Of String))
        SetTable(dbsNewTable:=dbsNewTable)
        SetFields(lstNewFields:=lstNewFields)
    End Sub

    Public Sub SetTableAndField(dbsNewTable As DbSet, strNewField As String)
        SetTable(dbsNewTable:=dbsNewTable)
        SetField(strNewField:=strNewField)
    End Sub

    Public Sub SetFilter(clsNewFilter As TableFilter)
        clsFilter = clsNewFilter
    End Sub

    Public Function GetValues() As List(Of String)
        Dim lstValues As New List(Of String)

        Return lstValues
    End Function

    Public Function GetFields() As Dictionary(Of String, String)
        Return dctFields
    End Function

    Public Function GetDataTable() As Object
        Dim db As New mariadb_climsoft_test_db_v4Entities

        Dim q = From emp In db.stations Select New Dynamic.ExpandoObject
        'Dim q = From emp In db.stations Select New With {.stationId = emp.stationId, .stationName = emp.stationName, .stations_ids = emp.stationId + " - " + emp.stationName}
        ' if DBQuery() contains NULL dates then the connection string must have "Convert Zero Datetime=True"

        Return q.ToList
        Return db.stations.Local.ToBindingList()
        Return db.stations.Local.Where(Function(x) x.stationId = "67774010")
        Return db.stations.Local.Where(clsFilter.GetLinqExpression())
    End Function
End Class