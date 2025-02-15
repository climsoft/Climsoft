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
    Private bArrayOperator As Boolean = False
    Private lstValues As List(Of String)
    Private objValue As Object
    Public bValuesAsString As Boolean
    Private clsDataCallValues As DataCall

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

    Public Function Clone() As TableFilter
        Dim tblFilter As New TableFilter

        tblFilter.SetOperator(strOperator)
        If IsCombinedFilter() Then
            tblFilter.SetLeftAndRightFilter(clsLeftFilter.Clone(), clsRightFilter.Clone())
        Else
            tblFilter.SetField(strField)
            If IsArrayOperator() Then
                If IsValuesFromDataCall() Then
                    tblFilter.SetDataCallValues(clsDataCallValues.Clone())
                Else
                    tblFilter.SetValues(lstValues, bClone:=True)
                End If
            Else
                tblFilter.SetValue(objValue)
            End If
        End If

        tblFilter.SetIsPositiveCondition(IsPositiveCondition())
        tblFilter.bValuesAsString = bValuesAsString

        Return tblFilter
    End Function

    Private Sub SetIsValuesFromDataCall(bNewValuesFromDataCall As Boolean)
        bValuesFromDataCall = bNewValuesFromDataCall
    End Sub

    Public Function IsValuesFromDataCall() As Boolean
        Return bValuesFromDataCall
    End Function

    Private Sub SetIsArrayOperator(bNewArrayOperator As Boolean)
        bArrayOperator = bNewArrayOperator
    End Sub

    Public Function IsArrayOperator() As Boolean
        Return bArrayOperator
    End Function

    Private Sub SetIsCombinedFilter(bNewIsCombinedFilter As Boolean)
        bIsCombinedFilter = bNewIsCombinedFilter
    End Sub

    Public Function IsCombinedFilter() As Boolean
        Return bIsCombinedFilter
    End Function

    Public Sub New()

    End Sub

    Public Sub New(strNewField As String, strNewOperator As String, Optional objNewValue As Object = Nothing, Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetFieldCondition(strNewField:=strNewField, strNewOperator:=strNewOperator, objNewValue:=objNewValue, bNewIsPositiveCondition:=bNewIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
    End Sub

    Public Sub New(strNewField As String, strNewOperator As String, Optional strNewValue As String = "", Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetFieldCondition(strNewField:=strNewField, strNewOperator:=strNewOperator, objNewValue:=strNewValue, bNewIsPositiveCondition:=bNewIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
    End Sub

    Public Sub New(strNewField As String, strNewOperator As String, Optional lstNewValue As List(Of String) = Nothing, Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetFieldCondition(strNewField:=strNewField, strNewOperator:=strNewOperator, lstNewValues:=lstNewValue, bNewIsPositiveCondition:=bNewIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
    End Sub

    Public Sub New(clsNewLeftFilter As TableFilter, clsNewRightFilter As TableFilter)
        SetLeftFilter(clsNewLeftFilter:=clsNewLeftFilter)
        SetRightFilter(clsNewRightFilter:=clsNewRightFilter)
        SetOperator("AND")
    End Sub

    Public Sub New(lstTblFilters As IEnumerable(Of TableFilter), Optional strOperator As String = "AND")
        SetFilters(lstTblFilters, strFiltersCombination:=strOperator)
    End Sub

    Public Sub SetField(strNewField As String)
        strField = strNewField
        bIsCombinedFilter = False
    End Sub

    Public Function GetField() As String
        If bIsCombinedFilter Then
            Return ""
        Else
            Return strField
        End If
    End Function

    Public Function GetFields() As List(Of String)
        Dim lstRet As New List(Of String)

        If bIsCombinedFilter Then
            lstRet.AddRange(clsLeftFilter.GetFields)
            lstRet.AddRange(clsRightFilter.GetFields)
        Else
            lstRet.Add(strField)
        End If
        Return lstRet

    End Function

    Public Sub SetOperator(strNewOperator As String)
        strOperator = strNewOperator
    End Sub

    Public Sub SetValues(lstNewValues As List(Of String), Optional bClone As Boolean = False)
        If bClone Then
            lstValues = ClsCloneFunctions.GetClonedList(lstNewValues)
        Else
            lstValues = lstNewValues
        End If

        bValuesFromDataCall = False
        bIsCombinedFilter = False
        SetIsArrayOperator(True)
    End Sub



    Public Sub SetValue(objNewValue As Object)
        objValue = objNewValue
        bValuesFromDataCall = False
        bIsCombinedFilter = False
        SetIsArrayOperator(False)
    End Sub

    Public Sub SetDataCallValues(clsNewDataCall As DataCall)
        clsDataCallValues = clsNewDataCall
        bValuesFromDataCall = True
        bIsCombinedFilter = False
        SetIsArrayOperator(True)
    End Sub

    Public Sub SetIsPositiveCondition(bNewIsPositiveCondition As Boolean)
        bIsPositiveCondition = bNewIsPositiveCondition
    End Sub

    Public Function IsPositiveCondition() As Boolean
        Return bIsPositiveCondition
    End Function

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, lstNewValues As List(Of String), Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetField(strNewField:=strNewField)
        SetOperator(strNewOperator:=strNewOperator)
        SetValues(lstNewValues:=lstNewValues)
        SetIsPositiveCondition(bNewIsPositiveCondition:=bNewIsPositiveCondition)
        bValuesAsString = bForceValuesAsString
    End Sub

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, objNewValue As Object, Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetField(strNewField:=strNewField)
        SetOperator(strNewOperator:=strNewOperator)
        SetValue(objNewValue:=objNewValue)
        SetIsPositiveCondition(bNewIsPositiveCondition:=bNewIsPositiveCondition)
        bValuesAsString = bForceValuesAsString
    End Sub

    Public Sub SetFieldCondition(strNewField As String, strNewOperator As String, clsNewDataCall As DataCall, Optional bNewIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        SetField(strNewField:=strNewField)
        SetOperator(strNewOperator:=strNewOperator)
        SetDataCallValues(clsNewDataCall:=clsNewDataCall)
        SetIsPositiveCondition(bNewIsPositiveCondition:=bNewIsPositiveCondition)
        bValuesAsString = bForceValuesAsString
    End Sub

    Public Sub SetLeftFilter(clsNewLeftFilter As TableFilter)
        clsLeftFilter = clsNewLeftFilter
        bIsCombinedFilter = True
    End Sub

    Public Function GetLeftFilter() As TableFilter
        Return clsLeftFilter
    End Function

    Public Sub SetRightFilter(clsNewRightFilter As TableFilter)
        clsRightFilter = clsNewRightFilter
        bIsCombinedFilter = True
    End Sub

    Public Function GetRightFilter() As TableFilter
        Return clsRightFilter
    End Function

    Public Sub SetLeftAndRightFilter(clsNewLeftFilter As TableFilter, clsNewRightFilter As TableFilter)
        SetLeftFilter(clsNewLeftFilter:=clsNewLeftFilter)
        SetRightFilter(clsNewRightFilter:=clsNewRightFilter)
    End Sub

    ''' <summary>
    ''' Will combine the list of filters into one filter
    ''' </summary>
    ''' <param name="lstTblFilters"></param>
    ''' <param name="strFiltersCombination"></param>
    Public Sub SetFilters(lstTblFilters As IEnumerable(Of TableFilter), Optional strFiltersCombination As String = "AND")
        Dim max As Integer = lstTblFilters.Count - 1
        For i As Integer = 0 To max
            If i = 0 Then
                Me.SetLeftFilter(lstTblFilters(i))
            Else
                Me.SetLeftFilter(Me.Clone())
            End If

            If i <= max - 1 Then
                Me.SetRightFilter(lstTblFilters(i + 1))
                Me.SetOperator(strFiltersCombination)
                If i + 1 = max Then
                    Exit For
                End If
            End If

        Next

    End Sub

    'Public Function GetLinqExpression() As Func(Of Entity.DbSet, Boolean)
    '    ' e.g. x.stationId = "67774010"
    '    Return Function(x) CallByName(x, "stationId", CallType.Get) = "67774010"
    'End Function

    'Public Function GetLinqExpression() As String
    '    Dim strExpression As String

    '    If bIsCombinedFilter Then
    '        strExpression = clsLeftFilter.GetLinqExpression() & " " & strOperator & " " & clsRightFilter.GetLinqExpression()
    '    Else
    '        strExpression = strField
    '        If bArrayOperator Then
    '            If bValuesFromDataCall Then
    '                strExpression = strExpression & "[" & clsDataCallValues.GetValuesAsString() & "]"
    '            Else
    '                strExpression = strExpression & "[" & String.Join(",", lstValues) & "]"
    '            End If
    '        Else
    '            If bValuesAsString Then
    '                strExpression = strExpression & " " & strOperator & " " & Chr(34) & objValue & Chr(34)
    '            Else
    '                strExpression = strExpression & " " & strOperator & " " & objValue
    '            End If
    '        End If
    '    End If
    '    strExpression = "(" & strExpression & ")"
    '    If Not bIsPositiveCondition Then
    '        strExpression = "not " & strExpression
    '    End If
    '    Return strExpression
    'End Function

    Public Function GetSqlExpression() As String
        Dim strExpression As String

        If bIsCombinedFilter Then
            strExpression = clsLeftFilter.GetSqlExpression() & " " & strOperator & " " & clsRightFilter.GetSqlExpression()
        Else
            strExpression = strField
            If bArrayOperator Then
                If bValuesFromDataCall Then
                    'strExpression = strExpression & "[" & clsDataCallValues.GetValuesAsString() & "]"
                Else
                    'strExpression = strExpression & "[" & String.Join(",", lstValues) & "]"
                End If
            Else
                If bValuesAsString Then
                    strExpression = strExpression & " " & strOperator & " '" & objValue & "'"
                Else
                    strExpression = strExpression & " " & strOperator & " " & objValue
                End If
            End If
        End If
        strExpression = "(" & strExpression & ")"
        If Not bIsPositiveCondition Then
            strExpression = "!= " & strExpression
        End If
        Return strExpression
    End Function

    Public Function GetSqlParameterisedExpression() As String
        Dim strExpression As String

        If bIsCombinedFilter Then
            strExpression = clsLeftFilter.GetSqlParameterisedExpression() & " " & strOperator & " " & clsRightFilter.GetSqlParameterisedExpression()
        Else
            strExpression = strField
            If bArrayOperator Then
                If bValuesFromDataCall Then
                    'strExpression = strExpression & "[" & clsDataCallValues.GetValuesAsString() & "]"
                Else
                    'strExpression = strExpression & "[" & String.Join(",", lstValues) & "]"
                End If
            Else
                If bValuesAsString Then
                    strExpression = strExpression & " " & strOperator & " @" & strExpression
                Else
                    strExpression = strExpression & " " & strOperator & " @" & strExpression

                End If
            End If
        End If
        strExpression = "(" & strExpression & ")"
        If Not bIsPositiveCondition Then
            'strExpression = "!= " & strExpression
        End If
        Return strExpression
    End Function

    Public Sub SetParameters(cmd As MySql.Data.MySqlClient.MySqlCommand)


        Dim strExpression As String

        If bIsCombinedFilter Then
            'strExpression = clsLeftFilter.GetLinqExpression() & " " & strOperator & " " & clsRightFilter.GetLinqExpression()
            clsLeftFilter.SetParameters(cmd)
            clsRightFilter.SetParameters(cmd)
        Else
            strExpression = strField
            If bArrayOperator Then
                If bValuesFromDataCall Then
                    'strExpression = strExpression & "[" & clsDataCallValues.GetValuesAsString() & "]"
                Else
                    'strExpression = strExpression & "[" & String.Join(",", lstValues) & "]"
                End If
            Else
                If bValuesAsString Then

                    'TODO. Retain its type
                    'objValue = strValue
                    'strExpression = strExpression & " " & strOperator & " @" & strExpression
                    cmd.Parameters.AddWithValue("@" & strExpression, objValue)
                Else
                    'TODO. Retain its type
                    'objValue = strValue
                    ' strExpression = strExpression & " " & strOperator & " @" & strExpression
                    cmd.Parameters.AddWithValue("@" & strExpression, objValue)
                End If


            End If
        End If
        ' strExpression = "(" & strExpression & ")"
        If Not bIsPositiveCondition Then
            'strExpression = "!= " & strExpression
        End If
        'Return strExpression
    End Sub

    Public Sub AddToSqlcommand(cmd As MySql.Data.MySqlClient.MySqlCommand)
        cmd.CommandText = cmd.CommandText & " WHERE " & GetSqlParameterisedExpression()
        SetParameters(cmd)
    End Sub

End Class