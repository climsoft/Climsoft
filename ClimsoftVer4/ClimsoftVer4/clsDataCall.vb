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

    'Data Adapater to retrieve data from the database
    Public da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private strTable As String
    ' The fields in the table which the values will be from
    ' The keys are the names of fields in the data base
    ' The values are how the field should be displayed to the user
    Private dctFields As Dictionary(Of String, List(Of String))

    Private lstKeyFieldNames As New List(Of String)

    'Private objFields As Object = New Dynamic.ExpandoObject

    ' A TableFilter object which defines the rows in the table the values will be from
    Private clsFilter As TableFilter

    Public Function Clone() As DataCall
        Dim clsNewDataCall As New DataCall

        clsNewDataCall.SetDataAdapter(DirectCast(DirectCast(da, ICloneable).Clone(), MySql.Data.MySqlClient.MySqlDataAdapter))
        clsNewDataCall.SetTableName(strTable)
        clsNewDataCall.SetFields(ClsCloneFunctions.GetClonedDict(dctFields))
        clsNewDataCall.SetKeyFields(ClsCloneFunctions.GetClonedList(lstKeyFieldNames))
        clsNewDataCall.SetFilter(clsFilter.Clone())

        Return clsNewDataCall
    End Function

    Public Sub SetDataAdapter(daNew As MySql.Data.MySqlClient.MySqlDataAdapter)
        da = daNew
    End Sub

    Public Sub SetTableName(strNewTable As String)
        strTable = strNewTable
    End Sub

    Public Function GetTableName() As String
        Return strTable
    End Function

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

    Public Sub AddField(strNewField As String)
        If dctFields Is Nothing Then
            SetFields(New Dictionary(Of String, List(Of String)))
        End If
        dctFields.Add(strNewField, New List(Of String)({strNewField}))
    End Sub

    Public Sub SetKeyFields(lstNewKeyFields As List(Of String))
        lstKeyFieldNames = lstNewKeyFields
    End Sub

    Public Sub AddKeyField(strNewKeyField As String)
        lstKeyFieldNames.Add(strNewKeyField)
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

    Private Sub UpdateDataAdapter(Optional clsAdditionalFilter As TableFilter = Nothing)
        Dim clsCurrentFilter As TableFilter
        Dim strSqlFieldNames As String
        Dim strSqlFieldParameters As String
        Dim cmdSelect As MySql.Data.MySqlClient.MySqlCommand
        Dim strSelectCommand As String
        Dim strKeysWhereCommand As String
        Dim cmdInsert As MySql.Data.MySqlClient.MySqlCommand
        Dim strInsertCommand As String
        Dim cmdUpdate As MySql.Data.MySqlClient.MySqlCommand
        Dim strUpdateCommand As String
        Dim strUpdateSetCommand As String
        Dim cmdDelete As MySql.Data.MySqlClient.MySqlCommand
        Dim strDeleteCommand As String
        Dim lstTempFieldNames As New List(Of String)
        Dim lstTempFieldParameters As New List(Of String)
        Dim dtbSchema As DataTable
        Dim type As MySql.Data.MySqlClient.MySqlDbType
        Dim iSize As Integer
        Dim parameterPlaceHolder As String

        Try
            If IsNothing(clsAdditionalFilter) Then
                clsCurrentFilter = clsFilter
            Else
                If IsNothing(clsFilter) Then
                    clsCurrentFilter = clsAdditionalFilter
                Else
                    clsCurrentFilter = New TableFilter(clsFilter, clsAdditionalFilter)
                End If
            End If

            cmdSelect = New MySql.Data.MySqlClient.MySqlCommand()
            cmdInsert = New MySql.Data.MySqlClient.MySqlCommand()
            cmdUpdate = New MySql.Data.MySqlClient.MySqlCommand()
            cmdDelete = New MySql.Data.MySqlClient.MySqlCommand()

            dtbSchema = GetTableSchema(strTable)

            'Get the field names and parameter placeholders
            For Each lstFieldNames As List(Of String) In dctFields.Values
                lstTempFieldNames.AddRange(lstFieldNames)
            Next

            lstTempFieldNames = lstTempFieldNames.Distinct().ToList

            For Each strName As String In lstTempFieldNames

                type = GetFieldMySqlDbType(strName, dtbSchema)
                iSize = GetFieldMySqlDbLength(strName, dtbSchema)

                parameterPlaceHolder = "@" & strName

                lstTempFieldParameters.Add(parameterPlaceHolder)

                'TODO change the size parameter for dates
                cmdInsert.Parameters.Add(parameterPlaceHolder, type, iSize, strName)
            Next

            strSqlFieldNames = String.Join(",", lstTempFieldNames.ToArray)
            strSqlFieldParameters = String.Join(",", lstTempFieldParameters.ToArray)

            'SELECT statement
            If lstTempFieldNames.Count > 0 Then
                strSelectCommand = "SELECT " & strSqlFieldNames & " FROM " & strTable
            Else
                strSelectCommand = "SELECT * FROM " & strTable
            End If

            cmdSelect.Connection = clsDataConnection.conn
            cmdSelect.CommandText = strSelectCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.SelectCommand = cmdSelect
            If clsCurrentFilter IsNot Nothing Then
                'contsruct the filter statement
                clsCurrentFilter.AddToSqlcommand(cmdSelect)
            End If

            'INSERT statement
            strInsertCommand = "INSERT INTO " & strTable & " (" & strSqlFieldNames & ") " & "VALUES (" & strSqlFieldParameters & ")"

            cmdInsert.Connection = clsDataConnection.conn
            cmdInsert.CommandText = strInsertCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.InsertCommand = cmdInsert

            'Where clause parameters
            strKeysWhereCommand = ""
            For Each strTempKeyField As String In lstKeyFieldNames
                parameterPlaceHolder = "@_" & strTempKeyField & "_"
                If strKeysWhereCommand = "" Then
                    strKeysWhereCommand = strTempKeyField & " = " & parameterPlaceHolder
                Else
                    strKeysWhereCommand = strKeysWhereCommand & " AND " & strTempKeyField & " = " & parameterPlaceHolder
                End If

                Dim paramUpdate As MySql.Data.MySqlClient.MySqlParameter
                Dim paramDelete As MySql.Data.MySqlClient.MySqlParameter

                type = GetFieldMySqlDbType(strTempKeyField, dtbSchema)
                iSize = GetFieldMySqlDbLength(strTempKeyField, dtbSchema)

                'TODO change the size parameter for dates
                paramUpdate = New MySql.Data.MySqlClient.MySqlParameter(parameterPlaceHolder, type, iSize, strTempKeyField)
                paramUpdate.SourceVersion = DataRowVersion.Original
                cmdUpdate.Parameters.Add(paramUpdate)
                paramDelete = New MySql.Data.MySqlClient.MySqlParameter(parameterPlaceHolder, type, iSize, strTempKeyField)
                paramDelete.SourceVersion = DataRowVersion.Original
                cmdDelete.Parameters.Add(paramDelete)
            Next

            'update set 
            strUpdateSetCommand = ""
            For Each strTempField In lstTempFieldNames
                parameterPlaceHolder = "@" & strTempField
                If strUpdateSetCommand = "" Then
                    strUpdateSetCommand = strTempField & " = " & strTempField
                Else
                    strUpdateSetCommand = strUpdateSetCommand & " , " & strTempField & " = " & parameterPlaceHolder
                End If


                type = GetFieldMySqlDbType(strTempField, dtbSchema)
                iSize = GetFieldMySqlDbLength(strTempField, dtbSchema)

                'TODO change the size parameter for dates
                cmdUpdate.Parameters.Add(parameterPlaceHolder, type, iSize, strTempField)
            Next

            'UPDATE statement
            strUpdateCommand = "UPDATE " & strTable & " SET " & strUpdateSetCommand & " WHERE " & strKeysWhereCommand
            cmdUpdate.Connection = clsDataConnection.conn
            cmdUpdate.CommandText = strUpdateCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.UpdateCommand = cmdUpdate

            'DELETE statement
            strDeleteCommand = "DELETE FROM " & strTable & " WHERE " & strKeysWhereCommand
            cmdDelete.Connection = clsDataConnection.conn
            cmdDelete.CommandText = strDeleteCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.DeleteCommand = cmdDelete

        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        Finally
            'conn.Close()
        End Try
    End Sub

    Private Function GetSourceDataTable(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
        Dim dtb As New DataTable

        UpdateDataAdapter(clsAdditionalFilter)
        da.Fill(dtb)
        Return dtb
    End Function

    Public Function GetDataTable(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
        Dim dtb As DataTable
        Dim lstFields As List(Of String)
        Dim lstCombine As List(Of String)
        Dim strSep As String = " "

        dtb = GetSourceDataTable(clsAdditionalFilter)
        If dtb.Columns.Count > 0 Then
            For Each strFieldDisplay As String In dctFields.Keys
                lstFields = dctFields.Item(strFieldDisplay)
                'if field = 1 just rename the database column name, if not create a sigle column from the fields and combine the values into the single column
                If lstFields.Count = 1 Then
                    'TODO Probably create the Display column if it does not exist?
                    'dtb.Columns.Item(lstFields(0)).ColumnName = strFieldDisplay
                Else
                    'create the column
                    dtb.Columns.Add(strFieldDisplay, GetType(String))

                    For Each row As DataRow In dtb.Rows
                        'get the values of all the needed columns/fields in this row then combine them into the new coulmn
                        lstCombine = New List(Of String)
                        For Each strField As String In lstFields
                            lstCombine.Add(row.Item(strField))
                        Next
                        'set the column with the combined values
                        row.Item(strFieldDisplay) = String.Join(strSep, lstCombine)
                    Next

                End If
            Next
        End If

        Return dtb
    End Function

    Public Function Save(dtb As DataTable) As Boolean
        Try
            da.Update(dtb)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error in saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'TODO. Delete this function later
    Private Function GetDataTableOLD(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
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

    'TODO. Delete this fucntion
    Private Function GetFieldsArray(Item As Object, Optional strSep As String = " ") As Object()
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

    'TODO. Delete this function
    Private Function GetDataObject(Optional clsAdditionalFilter As TableFilter = Nothing) As Object
        Dim clsCurrentFilter As TableFilter

        'TODO. This code is repeated somewhere else. Push it to a function
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
    End Function

    'TODO This should return the Linq expression that goes in the Select method
    Public Function GetSelectLinqExpression() As String
        Return ""
    End Function

    Public Function TableCount(Optional clsAdditionalFilter As TableFilter = Nothing) As Integer
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim iCount As Integer
        Dim clsCurrentFilter As TableFilter

        'TODO. This code is repeated somewhere else. Push it to a function
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

            cmd = New MySql.Data.MySqlClient.MySqlCommand()
            cmd.Connection = clsDataConnection.conn
            cmd.CommandText = "SELECT COUNT(*) AS num FROM " & strTable
            If clsCurrentFilter IsNot Nothing Then
                clsCurrentFilter.AddToSqlcommand(cmd)
            End If

            Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    While reader.Read
                        iCount = reader.Item("num")
                    End While
                End If
            End Using

        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        Finally
            'conn.Close()
        End Try

        Return iCount
    End Function

    Private Function GetTableSchema(strSchemaTable As String) As DataTable
        'Dim daTemp As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dtbSchema As New DataTable

        Using daTemp As New MySql.Data.MySqlClient.MySqlDataAdapter(
            "SELECT COLUMN_NAME, COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & strSchemaTable & "' AND TABLE_SCHEMA = '" & clsDataConnection.databaseName & "'", clsDataConnection.conn)
            daTemp.Fill(dtbSchema)
        End Using
        Return dtbSchema
    End Function

    Private Function GetFieldMySqlDbType(strField As String, dtbSchema As DataTable) As MySql.Data.MySqlClient.MySqlDbType
        Dim type As MySql.Data.MySqlClient.MySqlDbType
        Dim strType As String
        Dim iBracketStart As Integer

        strType = dtbSchema.Select("COLUMN_NAME = '" & strField & "'").FirstOrDefault().Item("COLUMN_TYPE")
        If strType.EndsWith(")") Then
            iBracketStart = strType.IndexOf("(")
            strType = strType.Substring(0, iBracketStart)
        End If
        Select Case strType
            Case "varchar"
                type = MySql.Data.MySqlClient.MySqlDbType.VarChar
            Case "int"
                type = MySql.Data.MySqlClient.MySqlDbType.Int32
            Case "bigint"
                type = MySql.Data.MySqlClient.MySqlDbType.Int64
            Case "double"
                type = MySql.Data.MySqlClient.MySqlDbType.Double
            Case "date"
                type = MySql.Data.MySqlClient.MySqlDbType.Date
            Case "datetime"
                type = MySql.Data.MySqlClient.MySqlDbType.DateTime
            Case "timestamp"
                type = MySql.Data.MySqlClient.MySqlDbType.Timestamp
            Case "smallint"
                type = MySql.Data.MySqlClient.MySqlDbType.Int24
            Case "tinyint"
                type = MySql.Data.MySqlClient.MySqlDbType.Int16
            Case "float"
                type = MySql.Data.MySqlClient.MySqlDbType.Float
            Case "decimal"
                type = MySql.Data.MySqlClient.MySqlDbType.Decimal
            Case "char"
                type = MySql.Data.MySqlClient.MySqlDbType.VarChar 'TODO char is not supported

                'TODO Add all the other types
        End Select
        Return type
    End Function

    Private Function GetFieldMySqlDbLength(strField As String, dtbSchema As DataTable) As Integer
        Dim iLength As Integer = -1
        Dim strType As String
        Dim iBracketStart As Integer

        strType = dtbSchema.Select("COLUMN_NAME = '" & strField & "'").FirstOrDefault().Item("COLUMN_TYPE")
        If strType.EndsWith(")") Then
            iBracketStart = strType.IndexOf("(")
            Integer.TryParse(strType.Substring(iBracketStart + 1, strType.Length - 2 - iBracketStart), iLength)
        End If
        Return iLength
    End Function
End Class