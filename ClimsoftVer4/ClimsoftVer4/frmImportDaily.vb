Public Class frmImportDaily
    Dim dbcon As New MySql.Data.MySqlClient.MySqlConnection
    Dim recCommit As New dataEntryGlobalRoutines
    Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dbConnectionString As String
    Dim ds1 As New DataSet
    Dim dsNewRow As DataRow
    Dim sql As String
    Dim kount As Integer

    Private Sub cmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        dlgOpenImportFile.Filter = "Comma Delimited|*.csv;*.txt"
        dlgOpenImportFile.Title = "Open Import Text File"
        dlgOpenImportFile.ShowDialog()

        txtImportFile.Text = dlgOpenImportFile.FileName

    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        Dim lin As Integer
        Dim currentRow As String()
        Dim currentField As String
        Dim row As String()
        Dim delimit As String
        'Set cursor to busy mood
        Me.Cursor = Cursors.WaitCursor

        Try
            'Assign delimiter for the text file
            ' Comma delimited
            If optComma.Checked Then
                delimit = ","
                'Tab delimited
            ElseIf OptTAB.Checked Then
                ' Characters delimited
                delimit = vbTab
            ElseIf OptOthers.Checked Then
                delimit = txtOther.Text
            End If
            DataGridView1.Columns.Clear()
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Dim num As Integer

                lin = MyReader.LineNumber()
                currentRow = MyReader.ReadFields()

                If lin = 1 Then ' The header row
                    ' Compute the total columns
                    num = 0
                    For Each currentField In currentRow
                        'MsgBox(currentField)
                        num = num + 1
                    Next

                    DataGridView1.ColumnCount = num

                    'Number the column headers starting with digit 1
                    num = 0
                    lstColumn.Items.Clear()
                    For Each currentField In currentRow
                        DataGridView1.Columns(num).Name = num + 1
                        num = num + 1
                        lstColumn.Items.Add(num)
                    Next
                    DataGridView1.Refresh()
                End If

                DataGridView1.Rows.Add(currentRow)
                Do While MyReader.EndOfData = False
                    currentRow = MyReader.ReadFields()
                    DataGridView1.Rows.Add(currentRow)
                Loop
                DataGridView1.Refresh()
            End Using

            ''Populate the datagridview with data from the file
            'For Each THisLine In My.Computer.FileSystem.ReadAllText(txtImportFile.Text).Split(Environment.NewLine)
            '    DataGridView1.Rows.Add(THisLine.Split(delimit))
            'Next
            DataGridView1.Refresh()
        Catch ex As Exception
            MsgBox(ex.HResult & " " & Err.Description)
            Me.Cursor = Cursors.Default
        End Try
        If DataGridView1.RowCount > 0 Then
            cmdLoadData.Enabled = True
            pnlHeaders.Enabled = True
        Else
            cmdLoadData.Enabled = False
            pnlHeaders.Enabled = False
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        'DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.Refresh()
        cmdLoadData.Enabled = False
        pnlHeaders.Enabled = False
    End Sub

    Private Sub cmdRename_Click(sender As Object, e As EventArgs) Handles cmdRename.Click
        'MsgBox(lstColumn.Text)
        DataGridView1.Columns(CInt(lstColumn.Text) - 1).Name = cmbFields.Text
        DataGridView1.Refresh()
    End Sub

    Private Sub cmdLoadData_Click(sender As Object, e As EventArgs) Handles cmdLoadData.Click
        Dim DataCat As String
        ' Set busy Cursor pointer
        Me.Cursor = Cursors.WaitCursor
        DataCat = Get_DataCat()
        Select Case DataCat
            Case "daily1"
                Load_Daily1()
            Case "daily2"
                Load_Daily2()
            Case "hourly"
                Load_Hourly()
        End Select
        Me.Cursor = Cursors.Default
        MsgBox("Data import process completed")
    End Sub

    Function Get_DataCat() As String
        Dim dd, obsv, hly, dly As Boolean
        dd = False
        obsv = False

        Get_DataCat = ""
        hly = False
        dly = False
        With DataGridView1
            For i = 0 To .Columns.Count - 1
                If .Columns(i).Name = "dd" Then dd = True
                If .Columns(i).Name = "value" Then obsv = True
                If .Columns(.Columns.Count - 1).Name = "23" Then hly = True 'Get_DataCat = "hourly"
                If .Columns(.Columns.Count - 1).Name = "31" Then dly = True 'Get_DataCat = "daily2"
            Next
        End With
        If dd = True And obsv = True Then Get_DataCat = "daily1"
        If dly Then Get_DataCat = "daily2"
        If hly And Not dly Then Get_DataCat = "hourly"
    End Function
    Sub Load_Daily1()
        Dim dat, stn, code, yy, mm, dd, hh, datetime As String
        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '1
                    If Get_RecordIdx(i, stn, code, yy, mm, dd, hh) Then
                        If hh = "" Then hh = txtObsHour.Text
                        datetime = yy & "-" & mm & "-" & dd & " " & hh & ":00"
                        'MsgBox(stn & code & yy & mm & dd & hh & " " & datetime)
                        ' ''Exit For
                    End If

                    For j = 0 To .Columns.Count - 1
                        If .Columns(j).Name = "value" Then
                            dat = .Rows(i).Cells(j).Value
                            'MsgBox(stn & " " & code & " " & datetime & " " & dat)
                            'Update_database(stn, code, datetime, dat)
                            If chkScale.Checked = True Then
                                Scale_Data(code, dat)
                                'MsgBox(dat)
                            End If
                            If IsDate(datetime) Then If Not Add_Record(stn, code, datetime, dat) Then Exit Sub

                            Exit For
                            'Exit Sub
                        End If

                    Next
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try

    End Sub
    Sub Load_Daily2()
        'MsgBox("formDaily2")
        Dim dt, st, cod, y, m, d, h, dttime, hd, dat As String
        Dim i, j As Integer
        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '1

                    If Get_RecordIdx(i, st, cod, y, m, d, h) Then
                        If h = "" Then h = txtObsHour.Text
                    End If

                    For j = 0 To .Columns.Count - 1
                        hd = .Columns(j).Name
                        dat = .Rows(i).Cells(j).Value
                        If IsNumeric(hd) Then
                            dttime = y & "-" & m & "-" & hd & " " & h & ":00"

                            If chkScale.Checked = True Then Scale_Data(cod, dat)
                            If IsDate(dttime) And IsDate(DateSerial(y, m, hd)) Then If Not Add_Record(st, cod, dttime, dat) Then Exit Sub

                        End If
                    Next
                Next

            End With
        Catch ex As Exception
            If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        End Try

    End Sub

    Sub Load_Hourly()
        'MsgBox("form_hourly")
        Dim dt, st, cod, y, m, d, h, dttime, hd, dat As String
        Dim i, j As Integer
        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '- 1
                    Get_RecordIdx(i, st, cod, y, m, d, h)

                    For j = 0 To .Columns.Count - 1
                        dat = .Rows(i).Cells(j).Value
                        hd = .Columns(j).Name
                        If chkScale.Checked = True Then Scale_Data(cod, dat)
                        If IsNumeric(hd) Then
                            dttime = y & "-" & m & "-" & d & " " & hd & ":00"

                            If IsDate(dttime) And IsDate(DateSerial(y, m, d)) Then If Not Add_Record(st, cod, dttime, dat) Then Exit Sub
                        End If
                    Next
                Next

            End With
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub
    'Function Get_Station(rw As Long) As String
    '    Get_Station = ""
    '    With DataGridView1
    '        For i = 0 To .Columns.Count - 1
    '            If .Columns(i).Name = "station_id" Then
    '                Get_Station = .Rows(rw).Cells(i).Value
    '                Exit For
    '            End If
    '        Next
    '    End With
    'End Function
    Function Get_RecordIdx(rw As Long, ByRef stn As String, ByRef code As String, ByRef yy As String, ByRef mm As String, ByRef dd As String, ByRef hh As String) As String
        Get_RecordIdx = True
        Try
            With DataGridView1
                For i = 0 To .Columns.Count - 1
                    If .Columns(i).Name = "station_id" Then
                        stn = .Rows(rw).Cells(i).Value
                    ElseIf .Columns(i).Name = "element_code" Then
                        code = .Rows(rw).Cells(i).Value
                    ElseIf .Columns(i).Name = "yyyy" Then
                        yy = .Rows(rw).Cells(i).Value
                    ElseIf .Columns(i).Name = "mm" Then
                        mm = .Rows(rw).Cells(i).Value
                    ElseIf .Columns(i).Name = "dd" Then
                        dd = .Rows(rw).Cells(i).Value
                    ElseIf .Columns(i).Name = "hh" Then
                        hh = .Rows(rw).Cells(i).Value
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            Get_RecordIdx = False
        End Try
    End Function

    Private Sub cmbFields_Click(sender As Object, e As EventArgs) Handles cmbFields.Click
        'DataGridView1.Columns(CInt(lstColumn.Text) - 1).Name = cmbFields.Text
        'DataGridView1.Refresh()
    End Sub
    Sub Update_database(stn As String, code As String, datetime As String, dat As String)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()
            'formMetadata.SetDataSet("observationinitial")
            sql = "SELECT * FROM observationinitial"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "observationinitial")
            'kount = ds1.Tables("observationinitial").Rows.Count
            'MsgBox(kount)
            dsNewRow = ds1.Tables("observationinitial").NewRow
            dsNewRow.Item("recordedFrom") = stn
            dsNewRow.Item("describedBy") = code
            dsNewRow.Item("obsDatetime") = datetime
            dsNewRow.Item("obsLevel") = "surface"
            dsNewRow.Item("obsValue") = dat
            dsNewRow.Item("qcStatus") = 0
            dsNewRow.Item("acquisitionType") = 0
            ds1.Tables("observationinitial").Rows.Add(dsNewRow)
            da1.Update(ds1, "observationinitial")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmdtest_Click(sender As Object, e As EventArgs) Handles cmdtest.Click
        'Update_database("8535004", "5", "2004-02-01 00:00", "0.1")
        Add_Record("8535004", "2", "2004-2-1 9:00", "0.1")
    End Sub


    Function Add_Record(stn As String, code As String, datetime As String, obsVal As String) As Boolean
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da1)
        Dim recCommit As New dataEntryGlobalRoutines
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand
        'MsgBox(Len(stn) & " " & Strings.Left(stn, 2) & " " & stn & " " & obsVal)
        Add_Record = True
        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "SELECT * FROM " & "observationinitial"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            da1.Fill(ds1, "observationinitial")

            'stn = Strings.Mid(stn, 2, Len(stn) - 1)
            comm.Connection = dbcon  ' Assign the already defined and asigned connection string to the Mysql command variable'
            sql0 = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue) Values(" & stn & ", '" & code & "', '" & datetime & "','surface','" & obsVal & "' );"
            'MsgBox(sql0)
            comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
            comm.ExecuteNonQuery()   ' Execute the query
            dbcon.Close()
            Return True
        Catch ex As Exception
            dbcon.Close()
            'MsgBox(stn & " " & code & " " & datetime & " " & obsVal)
            If ex.HResult <> -2147024882 Then
                'MsgBox(ex.HResult & ": " & ex.Message)
                If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Return False
            End If
        End Try
    End Function

    Private Sub cmbFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFields.SelectedIndexChanged
        DataGridView1.Columns(CInt(lstColumn.Text) - 1).Name = cmbFields.Text
        DataGridView1.Refresh()
    End Sub

    Sub Scale_Data(code As String, ByRef obsv As String)
        Dim scales As Decimal
        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "SELECT * FROM " & "obselement"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            da1.Fill(ds1, "obselement")
            With ds1.Tables("obselement")
                kount = .Rows.Count
                'MsgBox(kount)
                For i = 0 To kount - 1
                    If .Rows(i).Item("elementId") = code Then
                        scales = Val(.Rows(i).Item("elementScale"))
                        If scales > 0 Then obsv = Val(obsv) / scales
                        Exit For
                    End If
                Next
            End With
            dbcon.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
            dbcon.Close()
        End Try

    End Sub

    Private Sub cmdSaveSpecs_Click(sender As Object, e As EventArgs) Handles cmdSaveSpecs.Click
        Dim hdr, schemafile As String
        'Dim configFilename As String = Application.StartupPath & "\schema.sch"
        Try
            dlgSaveSchema.Filter = "Schema file|*.sch"
            dlgSaveSchema.Title = "Save Schema"
            dlgSaveSchema.ShowDialog()
            schemafile = dlgSaveSchema.FileName
            FileOpen(100, schemafile, OpenMode.Output)

            hdr = DataGridView1.Columns(0).Name
            For i = 1 To DataGridView1.Columns.Count - 1
                hdr = hdr & "," & DataGridView1.Columns(i).Name
            Next

            PrintLine(100, hdr)
        Catch ex As Exception
            FileClose(100)
        End Try
        FileClose(100)
    End Sub

    Private Sub cmdLoadSpecs_Click(sender As Object, e As EventArgs) Handles cmdLoadSpecs.Click
        Dim sch, hdr() As String
        dlgOpenImportFile.Filter = "Schema Files|*.sch"
        dlgOpenImportFile.Title = "Schema File"
        dlgOpenImportFile.ShowDialog()
        sch = dlgOpenImportFile.FileName
        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(sch)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")

                Dim num As Integer

                num = 0
                hdr = MyReader.ReadFields()
                For Each currentField In hdr
                    DataGridView1.Columns(num).Name = currentField
                    num = num + 1
                Next
                DataGridView1.Refresh()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'FileOpen(100, sch, OpenMode.Input)
        'hdr = LineInput(100)
        'MsgBox(hdr)
        'FileClose(100)

    End Sub

    Private Sub txtImportFile_TextChanged(sender As Object, e As EventArgs) Handles txtImportFile.TextChanged
        If IO.File.Exists(txtImportFile.Text) Then
            cmdView.Enabled = True
            'pnlHeaders.Enabled = True
        Else
            cmdView.Enabled = False
            'pnlHeaders.Enabled = False
        End If

    End Sub



    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class