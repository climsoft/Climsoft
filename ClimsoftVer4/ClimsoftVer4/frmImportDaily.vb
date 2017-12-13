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

            ' In case of AWS files
            If Text = "AWS Data Import" Then List_AWSFields()
            If Text = "Observations in Multiple Columns" Then List_ObsFields()
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

    Sub List_AWSFields()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            cmbFields.Items.Add("date_time")
            cmbFields.Items.Add("date")
            cmbFields.Items.Add("time")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where elementId > 880 ;"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            kount = ds1.Tables("obselement").Rows.Count

            If kount = 0 Then Exit Sub

            For i = 0 To kount - 1
                cmbFields.Items.Add(ds1.Tables("obselement").Rows(i).Item("elementId") & "-" & ds1.Tables("obselement").Rows(i).Item("abbreviation"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        dbcon.Close()
    End Sub
    Sub List_ObsFields()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            cmbFields.Items.Add("yyyy")
            cmbFields.Items.Add("mm")
            cmbFields.Items.Add("dd")
            cmbFields.Items.Add("hh")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where elementId < 881;"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            kount = ds1.Tables("obselement").Rows.Count

            If kount = 0 Then Exit Sub

            For i = 0 To kount - 1
                cmbFields.Items.Add(ds1.Tables("obselement").Rows(i).Item("elementId") & "-" & ds1.Tables("obselement").Rows(i).Item("abbreviation"))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            dbcon.Close()
        End Try
        dbcon.Close()
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
        Dim DataCat, fl1, fl2, cr, sql0 As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        Try
            ' Set busy Cursor pointer
            Me.Cursor = Cursors.WaitCursor

            fl1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_sql.csv"
            FileOpen(101, fl1, OpenMode.Output)

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            ' Contruct the SQL path structure for the output file
            fl2 = ""
            For i = 1 To Len(fl1)
                cr = Strings.Mid(fl1, i, 1)
                If cr = "\" Then cr = "/"
                fl2 = fl2 & cr
            Next

            ' AWS data category
            If lblType.Text = "aws" Then
                DataCat = "aws"
            ElseIf lblType.Text = "Multiple Elements" Then
                DataCat = "ColElms"
            Else
                ' Other data categories
                DataCat = Get_DataCat()
            End If

            lblRecords.Text = ""

            Select Case DataCat
                Case "daily1"
                    Load_Daily1()
                Case "daily2"
                    Load_Daily2()
                Case "hourly"
                    Load_Hourly()
                Case "aws"
                    Load_Aws()
                Case "ColElms"
                    Load_ColumnElems()
            End Select

            FileClose(101)
            ' load data into observationinitial table

            ' Create sql query
            sql0 = "LOAD DATA local INFILE '" & fl2 & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue);"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql0, dbcon)

            'Execute query
            objCmd.ExecuteNonQuery()

            lblRecords.Text = "Data import process completed"

            dbcon.Close()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            lblRecords.Text = "AWS Import Failed!, Check if the Staion Id exists in metadata"
            dbcon.Close()
            FileClose(101)
            Me.Cursor = Cursors.Default
        End Try

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

                    ' Show upload progress
                    lblRecords.Text = "Loading: " & i & " of " & .RowCount - Val(txtStartRow.Text) '1
                    lblRecords.Refresh()

                    If Get_RecordIdx(i, stn, code, yy, mm, dd, hh) Then
                        If hh = "" Then hh = txtObsHour.Text
                        datetime = yy & "-" & mm & "-" & dd & " " & hh & ":00"

                    End If

                    For j = 0 To .Columns.Count - 1
                        If .Columns(j).Name = "value" Then
                            dat = .Rows(i).Cells(j).Value
 
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

        Dim dt, st, cod, y, m, d, h, dttime, hd, dat As String
        Dim i, j As Integer

        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '1

                    ' Show upload progress
                    lblRecords.Text = "Loading: " & i & " of " & .RowCount - Val(txtStartRow.Text) '1
                    lblRecords.Refresh()
                    If Get_RecordIdx(i, st, cod, y, m, d, h) Then
                        If h = "" Then h = txtObsHour.Text
                    End If

                    For j = 0 To .Columns.Count - 1
                        hd = .Columns(j).Name
                        dat = .Rows(i).Cells(j).Value
                        If IsNumeric(hd) Then
                            dttime = y & "-" & m & "-" & hd & " " & h & ":00"
                            If chkScale.Checked = True Then Scale_Data(cod, dat)
                            If IsDate(dttime) And IsDate(DateSerial(y, m, hd)) Then If Not Add_Record(st, cod, dttime, dat) Then Exit For 'Sub
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

                    ' Show upload progress
                    lblRecords.Text = "Loading: " & i & " of " & .RowCount - Val(txtStartRow.Text) '1
                    lblRecords.Refresh()

                    Get_RecordIdx(i, st, cod, y, m, d, h)

                    For j = 0 To .Columns.Count - 1
                        dat = .Rows(i).Cells(j).Value
                        hd = .Columns(j).Name
                        If chkScale.Checked = True Then Scale_Data(cod, dat)
                        If IsNumeric(hd) Then
                            dttime = y & "-" & m & "-" & d & " " & hd & ":00"
                            If IsDate(dttime) And IsDate(DateSerial(y, m, d)) Then If Not Add_Record(st, cod, dttime, dat) Then Exit For 'Sub
                        End If
                    Next
                Next

            End With
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub

    Sub Load_Aws()
        'MsgBox("Aws")
        Dim stn, code, dttim, dt, tt, dat As String
        Dim i, j As Integer
        Dim dt_tm As Boolean

        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '- 1

                    ' Show upload progress
                    lblRecords.Text = "Loading: " & i & " of " & .RowCount - Val(txtStartRow.Text) '1
                    lblRecords.Refresh()
                    stn = txtStn.Text

                    With DataGridView1
                        dt_tm = False
                        For j = 0 To .Columns.Count - 1
                            If .Columns(j).Name = "station_id" Then ' Station column found
                                stn = .Rows(i).Cells(j).Value
                            ElseIf .Columns(j).Name = "date_time" Then ' Combined Date and Timme column found
                                dttim = .Rows(i).Cells(j).Value
                                dt_tm = True
                            ElseIf .Columns(j).Name = "date" Then ' Separate Date column found 
                                dt = .Rows(i).Cells(j).Value
                            ElseIf .Columns(j).Name = "time" Then ' Separate Time column found 
                                tt = .Rows(i).Cells(j).Value
                            Else ' Data Column found

                                code = .Columns(j).Name
                                dat = .Rows(i).Cells(j).Value
                                If dt_tm = False Then dttim = dt & " " & tt
                                If IsDate(dttim) Then
                                    dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & Format(DateAndTime.Hour(dttim), "00") & ":" & Format(DateAndTime.Minute(dttim), "00") & ":" & Format(DateAndTime.Second(dttim), "00")
                                    'If stn = "" Then stn = txtStn.Text
                                    If Get_Code_Scale(code, dat) Then
                                        Add_Record(stn, code, dttim, dat)
                                    End If
                                End If
                            End If
                        Next
                    End With
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub
    Sub Load_ColumnElems()
        'MsgBox("Column Elements")
        Dim stn, code, yr, mn, dy, hr, dt_tm, dat As String
        Dim i, j, dttcom As Integer

        Try
            With DataGridView1
                For i = CLng(txtStartRow.Text) - 1 To .RowCount - Val(txtStartRow.Text) '- 1

                    ' Show upload progress
                    lblRecords.Text = "Loading: " & i & " of " & .RowCount - Val(txtStartRow.Text) '1
                    lblRecords.Refresh()
                    dttcom = 0
                    hr = Val(txtObsHour.Text)
                    stn = txtStn.Text

                    'With DataGridView1

                    For j = 0 To .Columns.Count - 1
                        If .Columns(j).Name = "station_id" Then ' Station column found
                            stn = .Rows(i).Cells(j).Value
                        ElseIf .Columns(j).Name = "yyyy" Then ' Combined Date and Timme column found
                            yr = .Rows(i).Cells(j).Value
                            dttcom = dttcom + 1
                        ElseIf .Columns(j).Name = "mm" Then ' Separate Date column found 
                            mn = .Rows(i).Cells(j).Value
                            dttcom = dttcom + 1
                        ElseIf .Columns(j).Name = "dd" Then ' Separate Time column found 
                            dy = .Rows(i).Cells(j).Value
                            dttcom = dttcom + 1
                        ElseIf .Columns(j).Name = "hh" Then ' Separate Time column found 
                            hr = .Rows(i).Cells(j).Value

                        Else ' Data Column found

                            'compute datetime value
                            If dttcom <> 3 Then
                                MsgBox("Column headers yyyy, mm, dd Not found")
                                Exit Sub
                            Else
                                dt_tm = yr & "-" & mn & "-" & dy & " " & hr & ":00:00"
                            End If

                            code = .Columns(j).Name
                            dat = .Rows(i).Cells(j).Value

                            If Get_Code_Scale(code, dat) Then
                                Add_Record(stn, code, dt_tm, dat)
                            End If

                        End If
                    Next j
                Next i
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
                stn = txtStn.Text
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

            sql = "SELECT * FROM observationinitial"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "observationinitial")
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
        'MsgBox(stn & " " & datetime)
        Dim dat As String

        Try
            dat = stn & ", " & code & ", " & datetime & ", surface ," & obsVal

            Print(101, dat)
            PrintLine(101)

            Return True
        Catch ex As Exception
            dbcon.Close()
            If ex.HResult <> -2147024882 And ex.HResult <> -2146232969 And ex.HResult <> -2146233079 Then
                If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Return False
            End If
            Return False
        End Try

    End Function

    Private Sub cmbFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFields.SelectedIndexChanged
        Dim Colhd As String

        Try

            If InStr(cmbFields.Text, "-") > 0 Then
                Colhd = ""
                For Each C As Char In cmbFields.Text
                    If IsNumeric(C) Then Colhd = Colhd & C
                Next
            Else
                Colhd = cmbFields.Text
            End If
            DataGridView1.Columns(CInt(lstColumn.Text) - 1).Name = Colhd 'cmbFields.Text
            DataGridView1.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Scale_Data(code As String, ByRef obsv As String)

        Dim scales As Decimal

        Try
            sql = "select elementId, elementScale from obselement where elementId like " & code & ";"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            If ds1.Tables("obselement").Rows.Count = 0 Then Exit Sub

            If Not IsDBNull(ds1.Tables("obselement").Rows(0).Item("elementScale")) Then
                scales = Val(ds1.Tables("obselement").Rows(0).Item("elementScale"))
                If scales > 0 Then obsv = Math.Round(Val(obsv) / scales, 0)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Function Get_Code_Scale(code As String, ByRef obsv As String) As Boolean
        'MsgBox(code & " " & obsv)
        Dim scales As Decimal
        Try

            Get_Code_Scale = True

            'sql = "SELECT * FROM " & "obselement"
            sql = "select elementId, elementScale from obselement where elementId like " & Val(code) & ";"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            If ds1.Tables("obselement").Rows.Count = 0 Then
                Return False
            Else
                obsv = obsv
                If chkScale.Checked = True Then ' Remove the scale if set so
                    If Not IsDBNull(ds1.Tables("obselement").Rows(0).Item("elementScale")) Then
                        scales = Val(ds1.Tables("obselement").Rows(0).Item("elementScale"))
                        If scales > 0 Then obsv = Math.Round(Val(obsv) / scales, 0)
                        'Return True
                    End If
                End If
            End If

            'With ds1.Tables("obselement")
            '    kount = .Rows.Count
            '    For i = 0 To kount - 1
            '        If .Rows(i).Item("elementId") = Val(code) Then
            '            If chkScale.Checked = True Then ' Remove the scale if set so
            '                scales = Val(.Rows(i).Item("elementScale"))
            '                If scales > 0 Then obsv = Math.Round(Val(obsv) / scales, 0)
            '            End If
            '            Get_Code_Scale = True
            '            Exit For
            '        End If
            '    Next
            'End With

        Catch ex As Exception
            Get_Code_Scale = False
            MsgBox(ex.Message)
        End Try

    End Function
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


    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        If Text = "AWS Data Import" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#aws")
        Else

            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#procedures")
        End If
    End Sub
End Class