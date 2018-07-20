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
Imports System.Linq.Dynamic

Public Class DataCall

    ' The table in the database to call values from
    Private dbsTable As DbSet
    Private strTable As String
    ' The fields in the table which the values will be from
    ' The keys are the names of fields in the data base
    ' The values are how the field should be displayed to the user
    Private dctFields As Dictionary(Of String, List(Of String))

    'Private objFields As Object = New Dynamic.ExpandoObject

    ' A TableFilter object which defines the rows in the table the values will be from
    Private clsFilter As TableFilter

    Public Function Clone() As DataCall
        Dim clsdatacall As New DataCall
        'dbTable is not being cloned because we want to point to the same table in the entity framework
        clsdatacall.SetTable(dbsTable)

        clsdatacall.SetTableName(strTable)
        clsdatacall.SetFields(ClsCloneFunctions.GetClonedDict(dctFields))
        clsdatacall.SetFilter(clsFilter.Clone())

        Return clsdatacall
    End Function

    Public Sub SetTable(dbsNewTable As DbSet)
        dbsTable = dbsNewTable
    End Sub

    Public Sub SetTableName(strNewTable As String)
        strTable = strNewTable
    End Sub

    Public Sub SetFields(dctNewFields As Dictionary(Of String, List(Of String)))
        dctFields = dctNewFields
    End Sub

    Public Sub SetFields(lstNewFields As List(Of String))
        Dim dctNewFields As New Dictionary(Of String, List(Of String))
        For Each strTemp As String In lstNewFields
            dctNewFields.Add(strTemp, New List(Of String)({strTemp}))
        Next
        SetFields(dctNewFields:=dctNewFields)
    End Sub

    Public Sub SetField(strNewField As String)
        SetFields(New List(Of String)({strNewField}))
    End Sub

    Public Sub SetTableNameAndFields(strNewTable As String, dctNewFields As Dictionary(Of String, List(Of String)))
        SetTableName(strNewTable)
        SetFields(dctNewFields)
    End Sub

    Public Sub SetTableNameAndFields(strNewTable As String, lstNewFields As List(Of String))
        SetTableName(strNewTable)
        SetFields(lstNewFields)
    End Sub

    Public Sub SetTableNameAndField(strNewTable As String, strNewField As String)
        SetTableName(strNewTable)
        SetField(strNewField)
    End Sub

    Public Sub SetTableAndFields(dbsNewTable As DbSet, lstNewFields As List(Of String))
        SetTable(dbsNewTable:=dbsNewTable)
        SetFields(lstNewFields:=lstNewFields)
    End Sub

    Public Sub SetTableAndField(dbsNewTable As DbSet, strNewField As String)
        SetTable(dbsNewTable:=dbsNewTable)
        SetField(strNewField:=strNewField)
    End Sub
    Public Function GetFilter() As TableFilter
        Return clsFilter
    End Function

    Public Sub SetFilter(clsNewFilter As TableFilter)
        clsFilter = clsNewFilter
    End Sub

    Public Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        Dim clsNewFilter As New TableFilter

        clsNewFilter.SetFieldCondition(strNewField:=strField, strNewOperator:=strOperator, strNewValue:=strValue, bNewIsPositiveCondition:=bIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
        SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Function GetValues() As List(Of String)
        Dim lstValues As New List(Of String)
        Dim objData As Object

        objData = GetDataTable()
        For Each entItem In objData
            lstValues.Add(CallByName(entItem, dctFields.Keys(0), CallType.Get))
        Next
        Return lstValues
    End Function

    'PLEASE NOTE THIS IS MY QUICK FIX OF THE ABOVE GETVALUES.
    Public Function GetValues(Optional clsAdditionalFilter As TableFilter = Nothing) As List(Of String)
        Dim lstValues As New List(Of String)
        Dim objData As DataTable

        objData = GetDataTable(clsAdditionalFilter)
        For Each entItem As DataRow In objData.Rows
            lstValues.Add(entItem.Field(Of String)(0))
        Next
        Return lstValues
    End Function

    Public Function GetValuesAsString(Optional strSep As String = ",") As String
        Return String.Join(strSep, GetValues())
    End Function

    Public Function GetFields() As Dictionary(Of String, List(Of String))
        Return dctFields
    End Function

    Public Function GetField() As String
        If dctFields.Count = 1 Then
            Return dctFields.First.Key
        Else
            Return ""
        End If
    End Function

    Public Function GetDataTable(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
        Dim objData As Object
        Dim dtbFields As DataTable

        objData = GetDataObject(clsAdditionalFilter)
        dtbFields = New DataTable()
        If Not dctFields Is Nothing Then
            For Each strFieldDisplay As String In dctFields.Keys
                dtbFields.Columns.Add(strFieldDisplay, GetType(String))
            Next
            If objData IsNot Nothing Then
                For Each Item As Object In objData
                    dtbFields.Rows.Add(GetFieldsArray(Item))
                Next
            End If
        End If
        Return dtbFields
    End Function

    Public Function GetFieldsArray(Item As Object, Optional strSep As String = " ") As Object()
        Dim objFields As New List(Of Object)
        Dim lstFields As List(Of String)
        Dim lstCombine As List(Of String)

        If Item IsNot Nothing Then
            For Each strFieldDisplay As String In dctFields.Keys
                lstFields = dctFields(strFieldDisplay)
                If lstFields.Count = 1 Then
                    objFields.Add(CallByName(Item, lstFields(0), CallType.Get))
                Else
                    lstCombine = New List(Of String)
                    For Each strField In lstFields
                        lstCombine.Add(CallByName(Item, strField, CallType.Get))
                    Next
                    objFields.Add(String.Join(strSep, lstCombine))
                End If
            Next
            Return objFields.ToArray()
        Else
            Return Nothing
        End If
    End Function

    Public Function GetDataObject(Optional clsAdditionalFilter As TableFilter = Nothing) As Object
        Dim clsCurrentFilter As TableFilter

        If Not IsNothing(clsAdditionalFilter) Then
            If IsNothing(clsFilter) Then
                clsCurrentFilter = clsAdditionalFilter
            Else
                clsCurrentFilter = New TableFilter(clsFilter, clsAdditionalFilter)
            End If
        Else
            clsCurrentFilter = clsFilter
        End If

            Try
            If strTable <> "" Then
                Dim x = CallByName(clsDataConnection.db, strTable, CallType.Get)
                Dim y = TryCast(x, IQueryable(Of Object))

                If clsCurrentFilter IsNot Nothing Then
                    y = y.Where(clsCurrentFilter.GetLinqExpression())
                End If
                Return y.ToList()
            Else
                MessageBox.Show("Developer error: Table name must be set before data can be retrieved. No data will be returned.", caption:="Developer error")
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

        'If strTable = "stations" Then
        '    ' e.g. .Where("stationId == " & Chr(34) & "67774010" & Chr(34))
        '    If clsFilter IsNot Nothing Then
        '        Return db.stations.Where(clsFilter.GetLinqExpression()).ToList()
        '    Else
        '        Return db.stations.ToList()
        '    End If
        '    'If dctFields IsNot Nothing AndAlso dctFields.Count > 0 Then
        '    '    Return q.ToList
        '    'End If
        '    'q = x.Select(GetSelectLinqExpression())
        'End If
        '.Select("new(stationId as stationId, stationName, stationId+" - "+stationName As station_ids)")

        'Dim q = From emp In db.stations Select New Dynamic.ExpandoObject
        'Dim q = From emp In db.stations Select New With {.stationId = emp.stationId, .stationName = emp.stationName, .stations_ids = emp.stationId + " - " + emp.stationName}
        ' if DBQuery() contains NULL dates then the connection string must have "Convert Zero Datetime=True"

        'Return db.stations.Local.ToBindingList()
        'Return db.stations.Local.Where(Function(x) x.stationId = "67774010")
        'Return db.stations.Local.Where(clsFilter.GetLinqExpression())
    End Function

    'TODO This should return the Linq expression that goes in the Select method
    Public Function GetSelectLinqExpression() As String
        Return ""
    End Function
End Class