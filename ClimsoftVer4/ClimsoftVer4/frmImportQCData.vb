Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmImportQCData

    Private Sub frmImportQCData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGridFileContents.Visible = False
        lblFileSelection.Visible = True
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using dlgOpen As New OpenFileDialog
            dlgOpen.Filter = "Comma separated files|*.csv"
            dlgOpen.Multiselect = False
            dlgOpen.Title = "Open Data From File"
            If DialogResult.OK = dlgOpen.ShowDialog() Then
                txtFilePath.Text = dlgOpen.FileName
                Dim dtbQCData As DataTable = GetQCFileDataTableDefinition()
                FillQCFileDataFromCSV(dlgOpen.FileName, dtbQCData)
                If dtbQCData.Rows.Count = 0 Then
                    dataGridFileContents.Visible = False
                    lblFileSelection.Visible = True
                Else
                    dataGridFileContents.Visible = True
                    dataGridFileContents.DataSource = dtbQCData
                End If
            End If
        End Using
    End Sub

    Private Sub FillDataGridView(dtbQCData As DataTable)
        dataGridFileContents.DataSource = dtbQCData
        'dataGridFileContents.Refresh()
    End Sub


    Private Sub FillQCFileDataFromCSV(strFilePath As String, dtbQCData As DataTable)
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

        Dim strQCLog As String
        Dim strFlag As String
        Dim strValue As String

        Dim iCurrentQCStatus As Integer
        Dim strCurrentFlag As String
        Dim strCurrentValue As String
        Dim bRecordChanged As Integer

        Dim dtbInitialData As DataTable
        Dim rowInitialToUse As DataRow
        Dim clsDataCall As New DataCall
        clsDataCall.SetTableName("observationInitial")
        clsDataCall.SetFields({"recordedFrom", "describedBy", "obsDatetime", "acquisitionType", "qcStatus", "obsLevel", "period", "capturedBy", "dataForm", "mark", "temperatureUnits", "precipitationUnits", "cloudHeightUnits", "visUnits", "qcTypeLog", "flag", "obsValue"})
        clsDataCall.SetKeyFields({"recordedFrom", "describedBy", "obsDatetime", "acquisitionType", "qcStatus"})
        'important to order by qc status
        clsDataCall.SetOrderByFields({"qcStatus"})

        For Each row As DataRow In dtbQCData.Rows


            'change the data call filter to get new record(s)
            clsDataCall.SetFilter(New TableFilter({New TableFilter("recordedFrom", "=", objNewValue:=row.Field(Of String)("station_id")),
                                                  New TableFilter("describedBy", "=", objNewValue:=row.Field(Of Integer)("element_id")),
                                                  New TableFilter("obsDatetime", "=", objNewValue:=row.Field(Of Date)("date_time")),
                                                  New TableFilter("acquisitionType", "=", objNewValue:=row.Field(Of String)("acquisition_type"))
                                                  }))
            dtbInitialData = clsDataCall.GetDataTable()

            If dtbInitialData.Rows.Count = 0 Then
                'records not found
                Continue For
            End If

            strQCLog = row.Field(Of String)("qc_log")
            strFlag = row.Field(Of String)("flag")
            strValue = row.Field(Of String)("value")

            'use the last row
            rowInitialToUse = dtbInitialData.Rows(dtbInitialData.Rows.Count - 1)

            iCurrentQCStatus = rowInitialToUse.Field(Of Integer)("qcStatus")
            strCurrentValue = If(IsDBNull(rowInitialToUse.Field(Of String)("obsValue")) OrElse String.IsNullOrEmpty(rowInitialToUse.Field(Of String)("obsValue")), "", rowInitialToUse.Field(Of String)("obsValue"))
            strCurrentFlag = If(IsDBNull(rowInitialToUse.Field(Of String)("flag")) OrElse String.IsNullOrEmpty(rowInitialToUse.Field(Of String)("flag")), "", rowInitialToUse.Field(Of String)("flag"))

            bRecordChanged = strCurrentValue <> strValue OrElse strCurrentFlag <> strFlag

            If iCurrentQCStatus = 0 AndAlso Not bRecordChanged Then
                'update the record with qc status 1 and it's qc log if it's there
                rowInitialToUse.SetField(Of Integer)("qcStatus", 1)
            ElseIf iCurrentQCStatus = 1 AndAlso Not bRecordChanged Then
                'do nothing
            ElseIf iCurrentQCStatus = 2 AndAlso Not bRecordChanged Then
                'do nothing
            ElseIf iCurrentQCStatus = 1 AndAlso bRecordChanged Then
                'add new record with QC status 2  and the new updated values
                Dim newRow As DataRow = dtbInitialData.NewRow
                newRow.ItemArray = rowInitialToUse.ItemArray
                newRow.SetField(Of Integer)("qcStatus", 2)
                newRow.SetField(Of String)("flag", strFlag)
                newRow.SetField(Of String)("obsValue", strValue)
                dtbInitialData.Rows.Add(newRow)
            ElseIf iCurrentQCStatus = 2 AndAlso bRecordChanged Then
                'update the record with qc status 2 and the new updated values
                rowInitialToUse.SetField(Of Integer)("qcStatus", 2)
                rowInitialToUse.SetField(Of String)("flag", strFlag)
                rowInitialToUse.SetField(Of String)("obsValue", strValue)
                rowInitialToUse.SetField(Of String)("qcTypeLog", strQCLog)
            End If

            rowInitialToUse.SetField(Of String)("qcTypeLog", strQCLog)

            clsDataCall.Save(dtbInitialData)

        Next
    End Sub


End Class