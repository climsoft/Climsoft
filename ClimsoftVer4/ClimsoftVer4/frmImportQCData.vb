Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmImportQCData

    'Private dtbQCFileData As DataTable

    Private Sub frmImportQCData_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub fillDataGridView(dtbQCData As DataTable)
        dataGridFileContents.DataSource = dtbQCData
        'dataGridFileContents.Refresh()
    End Sub


    Private Sub GetQCFileDataFromCSV(strFilePath As String)

        Dim dtbQCData As DataTable = GetQCFileDataTableDefinition()

        Using fileReader As New FileIO.TextFieldParser(strFilePath)
            fileReader.TextFieldType = FileIO.FieldType.Delimited
            fileReader.SetDelimiters(",")


            'read the first line, get usable column names from it's fields 
            'dictionary of; mapped datatable column name and mapped field index
            Dim dctUsableColNames As Dictionary(Of String, Integer) = ValidateAndGetUsableFileColumns(fileReader.ReadFields(), dtbQCData)

            'if no usable column names then just exit
            If dctUsableColNames Is Nothing Then
                Exit Sub
            End If

            Dim currentRow As String()
            While Not fileReader.EndOfData
                Try
                    'get data table row definitial
                    Dim dataRow As DataRow = dtbQCData.NewRow
                    'get file row fields
                    currentRow = fileReader.ReadFields()

                    'loop through usable columns while using the mapped field index to get the file field value from the file row
                    'add the file field values in the data row
                    For Each usableCol As KeyValuePair(Of String, Integer) In dctUsableColNames
                        Dim fileFieldValue As String = currentRow(usableCol.Value)

                        'todo. validate values
                        Select Case usableCol.Key
                            Case "station_id"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "element_id"
                                dataRow.SetField(Of Integer)(usableCol.Key, Integer.Parse(fileFieldValue))
                            Case "acquisition_type"
                                dataRow.SetField(Of Integer)(usableCol.Key, Integer.Parse(fileFieldValue))
                            Case "date_time"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "qc_log"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "flag"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "value"
                                dataRow.SetField(Of Integer)(usableCol.Key, Integer.Parse(fileFieldValue))
                            Case Else
                                Continue For
                        End Select
                    Next

                    'dataRow.RowError

                    dtbQCData.Rows.Add(dataRow)

                Catch ex As FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is not valid and will be skipped.")
                Catch ex As Exception
                    MsgBox("Error " & ex.Message & ". Exiting.")
                End Try
            End While
        End Using
    End Sub

    Private Function GetQCFileDataTableDefinition() As DataTable
        Dim dtbQCFileData As New DataTable

        'data record identifier values
        '--------------------------------------------
        dtbQCFileData.Columns.Add("station_id", GetType(String))
        dtbQCFileData.Columns.Add("element_id", GetType(Integer))
        dtbQCFileData.Columns.Add("acquisition_type", GetType(Integer))
        dtbQCFileData.Columns.Add("date_time", GetType(Date))
        '--------------------------------------------

        'expected data record changes
        '--------------------------------------------
        dtbQCFileData.Columns.Add("qc_log", GetType(String))
        dtbQCFileData.Columns.Add("flag", GetType(String))
        dtbQCFileData.Columns.Add("value", GetType(String))
        '--------------------------------------------

        'PS note, intentionally
        'ignore capturedBy, dataForm because they are entered by a climsoft application
        'ignore period, obsLevel because no QC changes is expected and they don't define the record

        Return dtbQCFileData

    End Function


    Private Function ValidateAndGetUsableFileColumns(arrFileColNames As String(), dtb As DataTable) As Dictionary(Of String, Integer)
        Dim dctUsableColNames As New Dictionary(Of String, Integer)

        For fileColNameIndex As Integer = 0 To fileColNameIndex < arrFileColNames.Length
            For Each column As DataColumn In dtb.Columns
                If column.ColumnName = arrFileColNames(fileColNameIndex) Then
                    'column names from the file should be unique
                    If dctUsableColNames.ContainsKey(column.ColumnName) Then
                        MsgBox("Duplicate " & column.ColumnName & " detected")
                    Else
                        dctUsableColNames.Add(column.ColumnName, fileColNameIndex)
                    End If
                End If
            Next
        Next

        'validate column number
        If dctUsableColNames.Count <> dtb.Columns.Count Then
            MsgBox("Minimum of " & dtb.Columns.Count & " columns expected")
            Return Nothing
        End If


        Return dctUsableColNames
    End Function



    Private Sub SaveQCData(dtbQCData As DataTable)
        Dim strSql As String


        Dim strStationId As String
        Dim iElementId As Integer
        Dim iAcquisitionType As Integer
        Dim dtObsDateTime As Date
        Dim strQCLog As String
        Dim strFlag As String
        Dim strValue As String

        Dim iCurrentQCStatus As Integer
        Dim strCurrentFlag As String
        Dim strCurrentValue As String
        Dim strCurrentPeriod As String
        Dim strCurrentCapturedBy As String
        Dim strCurrentTempUnits As String
        Dim strCurrentPrecipUnits As String
        Dim strCurrentCloudHeightUnits As String
        Dim strCurrentVisUnits As String
        Dim bRecordChanged As Integer

        For Each row As DataRow In dtbQCData.Rows

            strStationId = row.Field(Of String)("station_id")
            iElementId = row.Field(Of Integer)("element_id")
            iAcquisitionType = row.Field(Of String)("acquisition_type")
            dtObsDateTime = row.Field(Of Date)("date_time")
            strQCLog = row.Field(Of String)("qc_log")
            strFlag = row.Field(Of String)("flag")
            strValue = row.Field(Of String)("value")

            'get the record ordered by QC status. Important to order by QC status
            strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elementId AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype ORDER BY qcStatus"
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
                cmd.Parameters.AddWithValue("@stationId", strStationId)
                cmd.Parameters.AddWithValue("@elementId", iElementId)
                cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                cmd.Parameters.AddWithValue("@acquisitiontype", iAcquisitionType)

                Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                    If reader.HasRows Then
                        'go through the records in initial and get it's last updated qc status
                        While reader.Read()
                            iCurrentQCStatus = reader.GetInt32("qcStatus")
                            strCurrentValue = If(String.IsNullOrEmpty(reader.GetString("obsValue")), "", reader.GetString("obsValue"))
                            strCurrentFlag = If(String.IsNullOrEmpty(reader.GetString("flag")), "", reader.GetString("flag"))
                            bRecordChanged = strCurrentValue <> strValue OrElse strCurrentFlag <> strFlag
                        End While
                    Else
                        Continue For
                    End If

                End Using
            End Using

            Dim clsDataCall As New DataCall
            clsDataCall.SetTableName("observationInitial")
            clsDataCall.SetKeyFields({"recordedFrom", "describedBy", "obsDatetime", "qcStatus", "acquisitionType"})
            'clsDataCall.Set


            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim dtb As New DataTable

            Dim cmdSelect As New MySql.Data.MySqlClient.MySqlCommand()
            Dim cmdInsert As New MySql.Data.MySqlClient.MySqlCommand()
            Dim cmdUpdate As New MySql.Data.MySqlClient.MySqlCommand()

            cmdSelect.Connection = clsDataConnection.GetOpenedConnection
            'important to order by QC status
            cmdSelect.CommandText = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elementId AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype ORDER BY qcStatus"

            cmdInsert.Connection = clsDataConnection.GetOpenedConnection
            cmdInsert.CommandText = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,capturedBy,dataForm,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits) " &
                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@obsPeriod,@qcStatus,@acquisitiontype,@capturedBy,@dataForm,@temperatureUnits,@precipUnits,@cloudHeightUnits,@visUnits)"

            cmdUpdate.Connection = clsDataConnection.GetOpenedConnection
            cmdUpdate.CommandText = "UPDATE observationInitial SET obsValue=@obsVal,flag=@obsFlag,period=@obsPeriod,qcStatus=@qcStatus,capturedBy=@capturedBy " &
                                " WHERE recordedFrom=@stationId And describedBy=@elementId AND acquisitionType=@acquisitiontype AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus"


            da.SelectCommand = cmdSelect
            da.InsertCommand = cmdInsert
            da.UpdateCommand = cmdUpdate



            da.Fill(dtb)

            Dim strDatabaseAction As String
            strDatabaseAction = ""

            If iCurrentQCStatus = 0 AndAlso Not bRecordChanged Then
                'update the record with qc status 1 and it's qc log if it's there
                strDatabaseAction = "update"
            ElseIf iCurrentQCStatus = 1 AndAlso Not bRecordChanged Then
                'do nothing
            ElseIf iCurrentQCStatus = 2 AndAlso Not bRecordChanged Then
                'do nothing
            ElseIf iCurrentQCStatus = 1 AndAlso bRecordChanged Then
                'add new record with QC status 2  and the new updated values
                strDatabaseAction = "insert"
            ElseIf iCurrentQCStatus = 2 AndAlso bRecordChanged Then
                'update the record with qc status 2 and the new updated values
                strDatabaseAction = "update"
            End If




        Next
    End Sub



End Class