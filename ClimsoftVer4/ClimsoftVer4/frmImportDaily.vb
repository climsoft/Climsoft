Public Class frmImportDaily
    Dim dbcon As New MySql.Data.MySqlClient.MySqlConnection
    Dim recCommit As New dataEntryGlobalRoutines
    Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dbConnectionString, dat, flg As String
    Dim ds1 As New DataSet
    Dim dsNewRow As DataRow
    Dim sql, currentRow(), delimit As String
    Dim lin, rec, col, kount As Integer


    Private Sub cmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        dlgOpenImportFile.Filter = "Comma Delimited|*.csv;*.txt"
        dlgOpenImportFile.Title = "Open Import Text File"
        dlgOpenImportFile.ShowDialog()

        txtImportFile.Text = dlgOpenImportFile.FileName

    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click

        Dim rec As Integer
        Dim currentRow As String()
        Dim currentField As String

        'Dim delimit As String
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

                ' Fill the DataGrid with 25 records for the file structure to be understood
                rec = 0
                Do While MyReader.EndOfData = False
                    currentRow = MyReader.ReadFields()
                    If rec > 25 Then Exit Do
                    DataGridView1.Rows.Add(currentRow)
                    rec = rec + 1
                Loop
                DataGridView1.Refresh()

                'Get Total Records Number
                lblTRecords.Text = IO.File.ReadAllLines(txtImportFile.Text).Length
            End Using


            ' In case of AWS files
            If Text = "AWS Data Import" Then List_AWSFields()
            If Text = "Multiple Columns Data Import" Then List_ObsFields()
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
            lblRecords.Text = ""
            If Not IO.Directory.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data") Then
                IO.Directory.CreateDirectory(Application.StartupPath & "\data")

            End If
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
            If lblType.Text = "AWS" Then
                DataCat = "AWS"
            ElseIf lblType.Text = "Multiple Elements" Then
                DataCat = "ColElms"
            ElseIf lblType.Text = "Hourly" Then
                DataCat = "Hourly"
            ElseIf lblType.Text = "Daily" Then
                DataCat = "Daily2"
            Else
                ' Other data categories
                'DataCat = Get_DataCat()
            End If

            ' Check for Daily1 file type
            For i = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Columns(i).Name = "value" Then
                    DataCat = "Daily1"
                    Exit For
                End If
            Next

            lblRecords.Text = ""
            'MsgBox(DataCat)
            Select Case DataCat
                Case "Daily1"
                    Load_Daily1()
                Case "Daily2"
                    Load_Daily2()
                Case "Hourly"
                    Load_Hourly()
                Case "AWS"
                    Load_Aws()
                Case "ColElms"
                    Load_ColumnElems()
            End Select

            FileClose(101)
            ' load data into observationinitial table

            ' Create sql query
            sql0 = "LOAD DATA local INFILE '" & fl2 & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag);"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql0, dbcon)

            'Execute query
            objCmd.CommandTimeout = 0
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

    Sub Load_Daily2()

        Dim dt, st, cod, y, m, d, h, dttime, hd, dat, flg As String

        Me.Cursor = Cursors.WaitCursor
        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        st = txtStn.Text
                        h = txtObsHour.Text
                        For Each currentField In currentRow

                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then

                                    If .Columns(col).Name = "station_id" Then
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then
                                        cod = dat
                                    ElseIf .Columns(col).Name = "yyyy" Then
                                        y = dat
                                    ElseIf .Columns(col).Name = "mm" Then
                                        m = dat

                                    ElseIf .Columns(col).Name = "hh" Then
                                        h = dat
                                    Else ' Data column encountered

                                        flg = ""
                                        If IsNumeric(hd) Then
                                            dttime = y & "-" & m & "-" & hd & " " & h & ":00"

                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If
                                            If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg) Then Exit For 'Sub
                                        End If
                                    End If
                                    ' Show upload progress
                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                    lblRecords.Refresh()
                                    col = col + 1
                                End If
                            End With
                        Next
                    End If
                Loop
            End Using

        Catch ex As Exception
            If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        End Try

    End Sub
   
    Sub Load_Daily1()
   
        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Dim st, cod, y, m, d, h, dttime, hd, dat, flg As String

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Initialize values
                        col = 0
                        st = txtStn.Text
                        h = txtObsHour.Text

                        For Each currentField In currentRow
                            hd = DataGridView1.Columns(col).Name
                            dat = currentField
                            With DataGridView1
                                If col < .ColumnCount Then
                                    If .Columns(col).Name = "station_id" Then
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then
                                        cod = dat
                                    ElseIf .Columns(col).Name = "yyyy" Then
                                        y = dat
                                    ElseIf .Columns(col).Name = "mm" Then
                                        m = dat
                                    ElseIf .Columns(col).Name = "dd" Then
                                        d = dat
                                    ElseIf .Columns(col).Name = "hh" Then
                                        h = dat
                                    End If
                                End If
                            End With

                            If hd = "value" Then
                                flg = "" ' Initialize the flag
                                dttime = y & "-" & m & "-" & d & " " & h & ":00"
                                If IsNumeric(dat) Then
                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                Else
                                    Get_Value_Flag(cod, dat, flg)
                                End If
                                If IsDate(dttime) And IsDate(DateSerial(y, m, h)) Then
                                    If Not Add_Record(st, cod, dttime, dat, flg) Then Exit For
                                End If

                                ' Show upload progress
                                lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                lblRecords.Refresh()

                            End If
                            col = col + 1
                        Next

                    End If
                Loop
            End Using
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try

    End Sub


    Sub Load_Hourly()
        'MsgBox("form_hourly")
        Dim st, cod, y, m, d, dttime, hd, dat, flg As String

        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                'MsgBox("Daily")

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        col = 0
                        st = txtStn.Text
                        For Each currentField In currentRow
                            hd = DataGridView1.Columns(col).Name()
                            dat = currentField
                            With DataGridView1
                                If col < .ColumnCount Then
                                    If .Columns(col).Name = "station_id" Then
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then
                                        cod = dat
                                    ElseIf .Columns(col).Name = "yyyy" Then
                                        y = dat
                                    ElseIf .Columns(col).Name = "mm" Then
                                        m = dat
                                    ElseIf .Columns(col).Name = "dd" Then
                                        d = dat
                                    Else ' Data column found
                                        ' Process data
                                        If IsNumeric(hd) Then
                                            'h = hd
                                            dttime = y & "-" & m & "-" & d & " " & hd & ":00"
                                            flg = ""
                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If
                                            If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg) Then Exit For 'Sub
                                        End If
                                    End If ' Last DataGridView which is equivalent to End data columns 

                                    ' Show upload progress
                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                    lblRecords.Refresh()
                                    col = col + 1
                                End If ' DatagridView1 column condition
                            End With ' DatagridView1
                        Next ' Next Data field
                    End If ' Record number greater than start row
                Loop ' Next Data row
            End Using ' MyReader

        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub

    Sub Load_Aws()
        'MsgBox("Aws")
        Dim st, cod, dttim, d, tt, dt, dat, hd, flg As String
        Dim dt_tm As Boolean

        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        ' Initialize values
                        col = 0
                        st = txtStn.Text
                        dt_tm = False

                        'h = txtObsHour.Text

                        For Each currentField In currentRow
                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then
                                    If .Columns(col).Name = "station_id" Then ' Station column found
                                        st = dat
                                    ElseIf .Columns(col).Name = "date_time" Then ' Combined Date and Timme column found
                                        dttim = dat
                                        dt_tm = True
                                    ElseIf .Columns(col).Name = "date" Then ' Separate Date column found 
                                        dt = dat
                                    ElseIf .Columns(col).Name = "time" Then ' Separate Time column found 
                                        tt = dat
                                    ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                        'Do nothing
                                    Else ' Data Column found

                                        cod = .Columns(col).Name
                                        '    dat = .Rows(i).Cells(j).Value
                                        If dt_tm = False Then dttim = dt & " " & tt

                                        If IsDate(dttim) Then

                                            dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & Format(DateAndTime.Hour(dttim), "00") & ":" & Format(DateAndTime.Minute(dttim), "00") & ":" & Format(DateAndTime.Second(dttim), "00")

                                            flg = ""
                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                ' Treat string data values as missing data
                                                flg = "M"
                                                dat = ""
                                            End If

                                            Add_Record(st, cod, dttim, dat, flg)
                                        End If
                                    End If
                                End If
                            End With
                            col = col + 1
                            ' Show upload progress
                            lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                            lblRecords.Refresh()

                        Next
                    End If
                Loop
            End Using
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub
    Sub Load_ColumnElems()
        'MsgBox("Column Elements")
        'Dim stn, code, yr, mn, dy, hr, dt_tm, dat, flg As String
        'Dim i, j As Integer
        Dim st, cod, y, m, d, h, dt_tm, hd, dat, dttcom, flg As String


        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        If MyReader.LineNumber > Val(txtStartRow.Text) Then

                            st = txtStn.Text
                            h = txtObsHour.Text
                            dttcom = 0
                            col = 0
                            For Each currentField In currentRow
                                hd = DataGridView1.Columns(col).Name
                                dat = currentField
                                With DataGridView1
                                    If col < .ColumnCount Then
                                        If .Columns(col).Name = "station_id" Then ' Station column found
                                            st = dat
                                        ElseIf .Columns(col).Name = "yyyy" Then  ' Year column found
                                            y = dat
                                            dttcom = dttcom + 1
                                        ElseIf .Columns(col).Name = "mm" Then ' Month column found
                                            m = dat
                                            dttcom = dttcom + 1
                                        ElseIf .Columns(col).Name = "dd" Then ' Day column found
                                            d = dat
                                            dttcom = dttcom + 1
                                        ElseIf .Columns(col).Name = "hh" Then ' Hour column found
                                            h = dat
                                        ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                            'Column labeled NA will be skipped
                                        Else

                                            ' Data column follows
                                            If dttcom <> 3 Then
                                                MsgBox("Column headers yyyy, mm, dd Not found")
                                                Exit Sub
                                            Else 'compute datetime value
                                                dt_tm = y & "-" & m & "-" & d & " " & h & ":00:00"
                                            End If

                                            ' Process data
                                            cod = hd
                                            dat = currentField
                                            flg = ""
                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If
                                            Add_Record(st, cod, dt_tm, dat, flg)
                                        End If
                                    End If
                                End With

                                ' Show upload progress
                                lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                lblRecords.Refresh()
                                col = col + 1
                            Next
                        End If
                    End If
                Loop
            End Using

        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try
    End Sub
    Sub Get_Value_Flag(code As String, ByRef dat As String, ByRef flg As String)
        Dim datstr, flgchr As String

        If Len(dat) = 0 Then
            dat = ""
            flg = "M"
        Else
            datstr = Strings.Left(dat, Len(dat) - 1)
            flgchr = Strings.Right(dat, 1)
            If Not IsNumeric(datstr) Or IsNumeric(flgchr) Then
                dat = ""
                flg = "M"
            Else
                dat = datstr
                If chkScale.Checked = True Then Scale_Data(code, dat)
                flg = Strings.UCase(flgchr)
            End If
        End If


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
                hh = txtObsHour.Text
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
    Sub Update_database(stn As String, code As String, datetime As String, dat As String, flg As String)
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
            dsNewRow.Item("flag") = flg
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
        Add_Record("8535004", "2", "2004-2-1 9:00", "0.1", "")
    End Sub


    Function Add_Record(stn As String, code As String, datetime As String, obsVal As String, flg As String) As Boolean
        'MsgBox(stn & " " & datetime)
        Dim dat As String

        Try
            dat = stn & ", " & code & ", " & datetime & ", surface ," & obsVal & ", " & flg

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

                If hdr.Count <> DataGridView1.Columns.Count Then
                    MsgBox("Header Specs don't match data columms. Selected specs file not loaded")
                    Exit Sub
                End If

                For Each currentField In hdr
                    DataGridView1.Columns(num).Name = currentField
                    num = num + 1
                Next
                DataGridView1.Refresh()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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