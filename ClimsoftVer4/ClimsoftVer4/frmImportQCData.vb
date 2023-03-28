Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmImportQCData

    Private Sub frmImportQCData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dataGridFileContents.Visible = False
        lblFileSelection.Visible = True
        btnSave.Enabled = False
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using dlgOpen As New OpenFileDialog
            dlgOpen.Filter = "Comma separated files|*.csv"
            dlgOpen.Multiselect = False
            dlgOpen.Title = "Open QC File"
            If DialogResult.OK = dlgOpen.ShowDialog() Then
                txtFilePath.Text = dlgOpen.FileName
                Dim dtbQCData As DataTable = GetQCFileDataTableDefinition()
                FillQCFileDataFromCSV(dlgOpen.FileName, dtbQCData)
                If dtbQCData.Rows.Count = 0 Then
                    btnSave.Enabled = False
                    lblFileSelection.Visible = True
                    dataGridFileContents.Visible = False
                    dataGridFileContents.DataSource = Nothing
                Else
                    btnSave.Enabled = True
                    lblFileSelection.Visible = False
                    dataGridFileContents.Visible = True
                    dataGridFileContents.DataSource = dtbQCData

                    For Each col As DataGridViewColumn In dataGridFileContents.Columns
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    Next
                    dataGridFileContents.Columns("date_time").DefaultCellStyle = New DataGridViewCellStyle With {
                        .Format = "yyyy-MM-dd hh:mm:ss"
                    }
                End If
            End If
        End Using
    End Sub

    'Private Sub dataGridFileContents_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dataGridFileContents.RowPrePaint
    '    Dim dataGrid As DataGridView = DirectCast(sender, DataGridView)
    '    If e.RowIndex <> dataGrid.NewRowIndex Then
    '        Dim row As DataGridViewRow = dataGrid.Rows(e.RowIndex)
    '        row.HeaderCell.Value = e.RowIndex
    '    End If
    'End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dataGridFileContents.DataSource IsNot Nothing Then
            SaveQCData(dataGridFileContents.DataSource)
        End If
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

            Dim iFileRow As Integer = 1 'start at 1 because of column names
            Dim currentRow As String()
            Dim dataRow As DataRow
            While Not fileReader.EndOfData
                Try

                    iFileRow = iFileRow + 1
                    'get file row fields
                    currentRow = fileReader.ReadFields()
                    'get data table row definitial
                    dataRow = dtbQCData.NewRow

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
                                dataRow.SetField(Of Date)(usableCol.Key,
                                                      Date.ParseExact(fileFieldValue, "yyyy-MM-dd hh:mm:ss",
                                                                      System.Globalization.DateTimeFormatInfo.InvariantInfo))
                            Case "qc_log"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "flag"
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case "value"
                                If String.IsNullOrEmpty(fileFieldValue) Then
                                ElseIf Not IsNumeric(fileFieldValue) Then
                                    AddText("Row " & iFileRow & " has a non numeric value. Row has been skipped.")
                                    Continue While
                                ElseIf fileFieldValue.Contains(".") Then
                                    AddText("Row " & iFileRow & " has a scaled value. Row has been skipped.")
                                    Continue While
                                End If
                                dataRow.SetField(Of String)(usableCol.Key, fileFieldValue)
                            Case Else
                                Continue For
                        End Select
                    Next

                    dtbQCData.Rows.Add(dataRow)

                Catch ex As FileIO.MalformedLineException
                    AddText("Row " & iFileRow & " is NOT valid and has been skipped. Error: " & ex.Message)
                Catch ex As Exception
                    AddText("Row " & iFileRow & " is NOT valid and has been skipped. Error: " & ex.Message)
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

        'PS note, intentionally
        'ignore capturedBy, dataForm because they are entered by a climsoft application
        'ignore period, obsLevel because no QC changes is expected and they don't define the record

        '--------------------------------------------

        Return dtbQCFileData

    End Function

    Private Function ValidateAndGetUsableFileColumns(arrFileColNames As String(), dtb As DataTable) As Dictionary(Of String, Integer)
        Dim dctUsableColNames As New Dictionary(Of String, Integer)

        For Each column As DataColumn In dtb.Columns
            'find column from file column names array
            For fileColNameIndex As Integer = 0 To arrFileColNames.Length - 1
                If column.ColumnName = arrFileColNames(fileColNameIndex) Then
                    dctUsableColNames.Add(column.ColumnName, fileColNameIndex)
                    Exit For
                End If
            Next
        Next

        'validate column number
        If dctUsableColNames.Count <> dtb.Columns.Count Then
            AddText("Minimum of " & dtb.Columns.Count & " columns expected.")
            AddText("Expected columns station_id, element_id, acquisition_type, date_time, qc_log, flag and value.")
            Return Nothing
        End If

        Return dctUsableColNames
    End Function

    Private Sub AddText(strText)
        rtfSummaryReport.AppendText(strText)

    End Sub

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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'dispose contents
        dataGridFileContents.DataSource = Nothing
        txtFilePath.Text = ""
        rtfSummaryReport.Clear()
        Me.Close()
    End Sub
End Class