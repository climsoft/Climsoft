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
Imports MySql.Data.MySqlClient

Public Class DataCall

    'Data Adapater to retrieve data from the database
    Public da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private strTableName As String

    'holds field names of the database table which the values will be from
    'keys are how the fields should be added in the datatable 
    'values are the names of fields in the database 
    'todo. change this to a normal list at this level, this structure won't support inserts, update and deletes
    Private dctFieldNames As Dictionary(Of String, List(Of String))

    'fields that will be used for select, insert, update and delete commands
    Private lstKeyFieldNames As New List(Of String)

    Private lstOrderByFieldNames As New List(Of String)
    Private strSortOrder As String = ""

    'defines the select filter statement 
    Private clsFilter As TableFilter

    Public Function Clone() As DataCall
        Dim clsNewDataCall As New DataCall

        clsNewDataCall.SetDataAdapter(DirectCast(DirectCast(da, ICloneable).Clone(), MySql.Data.MySqlClient.MySqlDataAdapter))
        clsNewDataCall.SetTableName(strTableName)
        clsNewDataCall.SetFields(ClsCloneFunctions.GetClonedDict(dctFieldNames))
        clsNewDataCall.SetKeyFields(ClsCloneFunctions.GetClonedList(lstKeyFieldNames))
        clsNewDataCall.SetFilter(clsFilter.Clone())

        Return clsNewDataCall
    End Function

    Public Sub SetDataAdapter(daNew As MySql.Data.MySqlClient.MySqlDataAdapter)
        da = daNew
    End Sub

    Public Sub SetTableName(strNewTable As String)
        strTableName = strNewTable
    End Sub

    Public Function GetTableName() As String
        Return strTableName
    End Function

    Public Sub SetFields(dctNewFields As Dictionary(Of String, List(Of String)))
        dctFieldNames = dctNewFields
    End Sub

    Public Sub SetFields(iEnumerableNewFields As IEnumerable(Of String))
        Dim dctNewFields As New Dictionary(Of String, List(Of String))
        For Each strTemp As String In iEnumerableNewFields
            dctNewFields.Add(strTemp, New List(Of String)({strTemp}))
        Next
        SetFields(dctNewFields)
    End Sub

    Public Sub AddField(strNewField As String)
        If dctFieldNames Is Nothing Then
            SetFields(New Dictionary(Of String, List(Of String)))
        End If
        dctFieldNames.Add(strNewField, New List(Of String)({strNewField}))
    End Sub

    Public Sub SetKeyFields(enumerableNewKeyFields As IEnumerable(Of String))
        lstKeyFieldNames = enumerableNewKeyFields.ToList()
    End Sub

    Public Sub AddKeyField(strNewKeyField As String)
        lstKeyFieldNames.Add(strNewKeyField)
    End Sub

    Public Sub SetOrderByFields(enumerableNewFields As IEnumerable(Of String), Optional strNewSortOrder As String = "")
        lstOrderByFieldNames = enumerableNewFields.ToList()
        'ASC or DESC or ""
        strSortOrder = strNewSortOrder
    End Sub

    Public Sub SetTableNameAndFields(strNewTable As String, lstNewFields As IEnumerable(Of String))
        SetTableName(strNewTable)
        SetFields(lstNewFields)
    End Sub

    Public Function GetFilter() As TableFilter
        Return clsFilter
    End Function

    Public Sub SetFilter(clsNewFilter As TableFilter)
        clsFilter = clsNewFilter
    End Sub

    Public Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True, Optional bForceValuesAsString As Boolean = False)
        Dim clsNewFilter As New TableFilter

        clsNewFilter.SetFieldCondition(strNewField:=strField, strNewOperator:=strOperator, objNewValue:=strValue, bNewIsPositiveCondition:=bIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString)
        SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Function GetFields() As Dictionary(Of String, List(Of String))
        Return dctFieldNames
    End Function

    Private Sub UpdateDataAdapter(Optional clsAdditionalFilter As TableFilter = Nothing)


        Try
            Dim clsCurrentFilter As TableFilter
            Dim strSqlFieldNames As String
            Dim strSqlFieldParameters As String
            Dim cmdSelect As New MySqlCommand
            Dim strSelectCommand As String
            Dim strUpdateAndDeleteConditionsParams As String
            Dim cmdInsert As New MySqlCommand
            Dim strInsertCommand As String
            Dim cmdUpdate As New MySqlCommand
            Dim strUpdateCommand As String
            Dim strUpdateSetCommand As String
            Dim cmdDelete As New MySqlCommand
            Dim strDeleteCommand As String
            Dim lstTempFieldNames As New List(Of String)
            Dim lstTempFieldParameters As New List(Of String)
            Dim dtbSchema As DataTable
            Dim type As MySqlDbType
            Dim iSize As Integer
            Dim parameterPlaceHolder As String

            If IsNothing(clsAdditionalFilter) Then
                clsCurrentFilter = clsFilter
            Else
                If IsNothing(clsFilter) Then
                    clsCurrentFilter = clsAdditionalFilter
                Else
                    clsCurrentFilter = New TableFilter(clsFilter, clsAdditionalFilter)
                End If
            End If


            'get the table schema
            dtbSchema = GetTableSchema(strTableName)

            'Get distinct field names and construct their parameter placeholders
            For Each lstFieldNames As List(Of String) In dctFieldNames.Values
                lstTempFieldNames.AddRange(lstFieldNames)
            Next
            lstTempFieldNames = lstTempFieldNames.Distinct().ToList

            For Each strName As String In lstTempFieldNames

                Type = GetFieldMySqlDbType(strName, dtbSchema)
                iSize = GetFieldMySqlDbLength(strName, dtbSchema)

                parameterPlaceHolder = "@" & strName

                lstTempFieldParameters.Add(parameterPlaceHolder)

                'TODO change the size parameter for dates
                cmdInsert.Parameters.Add(parameterPlaceHolder, Type, iSize, strName)
            Next

            strSqlFieldNames = String.Join(",", lstTempFieldNames.ToArray)
            strSqlFieldParameters = String.Join(",", lstTempFieldParameters.ToArray)


            'SELECT statement
            '--------------------------------------------
            If lstTempFieldNames.Count > 0 Then
                strSelectCommand = "SELECT " & strSqlFieldNames & " FROM " & strTableName
            Else
                strSelectCommand = "SELECT * FROM " & strTableName
            End If

            cmdSelect.Connection = clsDataConnection.GetOpenedConnection
            cmdSelect.CommandText = strSelectCommand
            da.SelectCommand = cmdSelect
            If clsCurrentFilter IsNot Nothing Then
                'contsruct the filter statement
                clsCurrentFilter.AddToSqlcommand(cmdSelect)
            End If

            If lstOrderByFieldNames.Count > 0 Then
                cmdSelect.CommandText = cmdSelect.CommandText & " ORDER BY " & String.Join(",", lstOrderByFieldNames.ToArray) & " " & strSortOrder
            End If
            '--------------------------------------------

            '--------------------------------------------
            'INSERT statement
            strInsertCommand = "INSERT INTO " & strTableName & " (" & strSqlFieldNames & ") " & "VALUES (" & strSqlFieldParameters & ")"
            cmdInsert.Connection = clsDataConnection.GetOpenedConnection
            cmdInsert.CommandText = strInsertCommand
            da.InsertCommand = cmdInsert
            '--------------------------------------------

            'Where clause parameters for update and delete statements
            strUpdateAndDeleteConditionsParams = ""
            For Each strTempKeyField As String In lstKeyFieldNames
                parameterPlaceHolder = "@_" & strTempKeyField & "_"
                If strUpdateAndDeleteConditionsParams = "" Then
                    strUpdateAndDeleteConditionsParams = strTempKeyField & " = " & parameterPlaceHolder
                Else
                    strUpdateAndDeleteConditionsParams = strUpdateAndDeleteConditionsParams & " AND " & strTempKeyField & " = " & parameterPlaceHolder
                End If

                Dim paramUpdate As MySqlParameter
                Dim paramDelete As MySqlParameter

                Type = GetFieldMySqlDbType(strTempKeyField, dtbSchema)
                iSize = GetFieldMySqlDbLength(strTempKeyField, dtbSchema)

                'TODO change the size parameter for dates
                paramUpdate = New MySqlParameter(parameterPlaceHolder, Type, iSize, strTempKeyField) With {
                    .SourceVersion = DataRowVersion.Original
                }
                cmdUpdate.Parameters.Add(paramUpdate)
                paramDelete = New MySqlParameter(parameterPlaceHolder, Type, iSize, strTempKeyField) With {
                    .SourceVersion = DataRowVersion.Original
                }
                cmdDelete.Parameters.Add(paramDelete)
            Next

            'update set command parameters 
            strUpdateSetCommand = ""
            For Each strTempField In lstTempFieldNames
                parameterPlaceHolder = "@" & strTempField
                If strUpdateSetCommand = "" Then
                    strUpdateSetCommand = strTempField & " = " & strTempField
                Else
                    strUpdateSetCommand = strUpdateSetCommand & " , " & strTempField & " = " & parameterPlaceHolder
                End If


                Type = GetFieldMySqlDbType(strTempField, dtbSchema)
                iSize = GetFieldMySqlDbLength(strTempField, dtbSchema)

                'TODO change the size parameter for dates
                cmdUpdate.Parameters.Add(parameterPlaceHolder, Type, iSize, strTempField)
            Next

            'UPDATE statement
            strUpdateCommand = "UPDATE " & strTableName & " SET " & strUpdateSetCommand & " WHERE " & strUpdateAndDeleteConditionsParams
            cmdUpdate.Connection = clsDataConnection.GetOpenedConnection
            cmdUpdate.CommandText = strUpdateCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.UpdateCommand = cmdUpdate

            'DELETE statement
            strDeleteCommand = "DELETE FROM " & strTableName & " WHERE " & strUpdateAndDeleteConditionsParams
            cmdDelete.Connection = clsDataConnection.GetOpenedConnection
            cmdDelete.CommandText = strDeleteCommand 'To confirm that this is the best approach to creating the paramatised Querie
            da.DeleteCommand = cmdDelete

        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
    End Sub

    Private Function GetSourceDataTable(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
        Dim dtb As New DataTable

        Try
            UpdateDataAdapter(clsAdditionalFilter)
            da.Fill(dtb)
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

        Return dtb
    End Function

    'todo. rename to RefreshDatatable()
    Public Function GetDataTable(Optional clsAdditionalFilter As TableFilter = Nothing) As DataTable
        Dim dtb As DataTable
        Dim lstFields As List(Of String)
        Dim lstCombine As List(Of String)
        Dim strSep As String = " "

        dtb = GetSourceDataTable(clsAdditionalFilter)
        If dtb.Columns.Count > 0 Then
            For Each strFieldDisplay As String In dctFieldNames.Keys
                lstFields = dctFieldNames.Item(strFieldDisplay)
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
                            lstCombine.Add(If(IsDBNull(row.Item(strField)), "", row.Item(strField)))
                        Next
                        'set the column with the combined values
                        row.Item(strFieldDisplay) = String.Join(strSep, lstCombine)
                    Next

                End If
            Next
        End If

        Return dtb
    End Function

    'todo. datacall should not accept a data table that it doesn't know it's definitions
    'this parameter is a potential logical bug
    Public Function Save(dtb As DataTable) As Boolean
        Try
            da.Update(dtb)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error in saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function TableCount(Optional clsAdditionalFilter As TableFilter = Nothing) As Integer
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
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand("SELECT COUNT(*) AS colnum FROM " & strTableName, clsDataConnection.GetOpenedConnection)
                If clsCurrentFilter IsNot Nothing Then
                    clsCurrentFilter.AddToSqlcommand(cmd)
                End If
                Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        While reader.Read
                            iCount = reader.Item("colnum")
                        End While
                    End If
                End Using
            End Using


        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try

        Return iCount
    End Function

    Private Function GetTableSchema(strSchemaTable As String) As DataTable
        Return GetDataTableFromQuery("SELECT COLUMN_NAME, COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" & strSchemaTable & "' AND TABLE_SCHEMA = '" & clsDataConnection.GetDatabaseName & "'")
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
            Case "text"
                type = MySql.Data.MySqlClient.MySqlDbType.Text

                'TODO. Add all the other types
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

    ''' <summary>
    ''' To be used for complex queries
    ''' </summary>
    ''' <param name="strSql"></param>
    ''' <returns></returns>
    Public Function GetDataTableFromQuery(strSql As String) As DataTable
        Dim dtb As New DataTable
        Using daTemp As New MySql.Data.MySqlClient.MySqlDataAdapter(strSql, clsDataConnection.GetOpenedConnection)
            daTemp.Fill(dtb)
        End Using
        Return dtb
    End Function

End Class