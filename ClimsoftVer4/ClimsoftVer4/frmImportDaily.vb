Public Class frmImportDaily
    Dim dbcon As New MySql.Data.MySqlClient.MySqlConnection
    Dim recCommit As New dataEntryGlobalRoutines
    Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dbConnectionString, dat, flg As String
    Dim ds1 As New DataSet
    Dim dsNewRow As DataRow
    Dim sql, currentRow(), delimit, cprd As String
    Dim lin, rec, col, kount, prd As Integer



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

            ' Append a Blank Line to the import file to control the EOF code
            FileOpen(200, txtImportFile.Text, OpenMode.Append)
            PrintLine(200, Chr(10) & Chr(13))
            FileClose(200)

        Catch ex As Exception
            MsgBox(ex.HResult & " " & Err.Description)
            Me.Cursor = Cursors.Default
        End Try
        If DataGridView1.RowCount > 0 Then
            cmdLoadData.Enabled = True

            ' CLICOM imports have fixed structure hence the panel for header specifications should not be used hence it's not enabled
            If InStr(Text, "CLICOM") < 1 Then pnlHeaders.Enabled = True
        Else
            cmdLoadData.Enabled = False
            pnlHeaders.Enabled = False
        End If
        Me.Cursor = Cursors.Default
        lstStations.Items.Clear()
        lstElements.Items.Clear()
        pnlErrors.Visible = False
    End Sub

    Sub List_AWSFields()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            cmbFields.Items.Add("element_code")
            cmbFields.Items.Add("date_time")
            cmbFields.Items.Add("date")
            cmbFields.Items.Add("time")
            cmbFields.Items.Add("value")
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
            cmbFields.Items.Add("NA")
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
        lstStations.Items.Clear()
        lstElements.Items.Clear()
        pnlErrors.Visible = False
        lstStations.Visible = False
        lstElements.Visible = False
        cmdSaveErrors.Visible = False
        lblStnEror.Visible = False
        lblElmeror.Visible = False
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
            'If Not IO.Directory.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data") Then
            If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data") Then
                'IO.Directory.CreateDirectory(Application.StartupPath & "\data")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data")
            End If
            'fl1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_sql.csv"
            fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_sql.csv"
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

            ' Determine data category from selected menu
            If lblType.Text = "AWS" Then
                DataCat = "AWS"
            ElseIf lblType.Text = "Multiple Elements" Then
                DataCat = "ColElms"
            ElseIf lblType.Text = "Hourly" Then
                DataCat = "Hourly"
            ElseIf lblType.Text = "Daily" Then
                DataCat = "Daily2"
            ElseIf lblType.Text = "CLICOMdaily" Then
                DataCat = "CLICOMDLY"
            ElseIf lblType.Text = "CLICOMsynop" Then
                DataCat = "CLICOMSYP"
            ElseIf lblType.Text = "CLICOMhourly" Then
                DataCat = "CLICOMHLY"
            ElseIf lblType.Text = "Monthly" Then
                DataCat = "Monthly"
            Else
                ' Other future data categories
                'DataCat = Get_DataCat()
            End If

            ' Check for Daily1, Hourly1 and AWS_special file type
            'For i = 0 To DataGridView1.Columns.Count - 1
            '    If DataGridView1.Columns(i).Name = "value" And lblType.Text = "Daily" Then
            '        DataCat = "Daily1"
            '        Exit For
            '    ElseIf DataGridView1.Columns(i).Name = "value" And lblType.Text = "AWS" Then
            '        DataCat = "AWS_special"
            '        Exit For
            '    End If
            'Next

            ' Determine special data categories from files header
            ' Check for Daily1, Hourly1 and AWS_special file types
            For i = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Columns(i).Name = "value" Then
                    Select Case lblType.Text
                        Case "Daily"
                            DataCat = "Daily1"
                        Case "Hourly"
                            DataCat = "Daily1"
                        Case "AWS"
                            DataCat = "AWS_special"
                    End Select
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
                Case "AWS_special"
                    Load_Aws_special()
                Case "ColElms"
                    Load_ColumnElems()
                Case "CLICOMDLY"
                    Load_CLICOM("daily")
                Case "CLICOMSYP"
                    Load_CLICOM("synop")
                Case "CLICOMHLY"
                    Load_CLICOM("hourly")
                Case "Monthly"
                    Load_Monthly()
            End Select

            FileClose(101)
            ' load data into observationinitial table

            ' Create sql query
            sql0 = "LOAD DATA local INFILE '" & fl2 & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,acquisitionType);"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql0, dbcon)

            'Execute query
            objCmd.CommandTimeout = 0
            objCmd.ExecuteNonQuery()

            lblRecords.Text = "Data import process completed"

            dbcon.Close()
            Me.Cursor = Cursors.Default

            ' Output stations and elements errors into a file
            'pnlErrors.Visible = False


            If lstStations.Items.Count > 0 Then
                pnlErrors.Visible = True
                lblStnEror.Visible = True
                lstStations.Visible = True
                cmdSaveErrors.Visible = True
            End If

            If lstElements.Items.Count > 0 Then
                pnlErrors.Visible = True
                lblElmeror.Visible = True
                lstElements.Visible = True
                cmdSaveErrors.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            lblRecords.Text = "Data Import Failed!, Check if the Staion Id exists in metadata"
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
        Dim acquisitiontype As Integer

        Me.Cursor = Cursors.WaitCursor
        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False

                    'While Not MyReader.EndOfData
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        st = txtStn.Text
                        acquisitiontype = 6
                        h = txtObsHour.Text
                        cod = txtElmCode.Text
                        For Each currentField In currentRow

                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then
                                    'If col = 3 Then MsgBox(dat)
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
                                    ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                        'Do nothing
                                    Else ' Data column encountered

                                        flg = ""
                                        If IsNumeric(hd) Then

                                            dttime = y & "-" & m & "-" & hd & " " & h & ":00"

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then

                                                If IsDate(dttime) Then
                                                    If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype) Then Exit For
                                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                    lblRecords.Refresh()
                                                    col = col + 1
                                                End If
                                                Continue For
                                            End If


                                            If IsNumeric(dat) Then
                                                    prd = 0 ' initialize data period counter
                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                                Else
                                                    Get_Value_Flag(cod, dat, flg)
                                                End If

                                                ' Process Dekadal data if any
                                                If optDekadal.Checked = True Then
                                                    cprd = GetDekadPeriod(dttime)
                                                    If IsNumeric(dat) Then flg = "C"
                                                End If

                                                If Station_Element(st, cod) Then
                                                    If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype) Then Exit For 'Sub
                                                End If
                                            End If
                                        End If
                                    ' Show upload progress
                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
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
                Dim acquisitiontype As Integer

                Do While MyReader.EndOfData = False

                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Initialize values
                        col = 0
                        st = txtStn.Text
                        h = txtObsHour.Text
                        cod = txtElmCode.Text

                        acquisitiontype = 6

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

                                ' Check for missing flag data values 
                                If dat = txtMissingFlag.Text Then
                                    If IsDate(dttime) Then
                                        If Station_Element(st, cod) Then Add_Record(st, cod, dttime, "", "M", acquisitiontype)
                                        lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                        lblRecords.Refresh()
                                        col = col + 1
                                    End If
                                    Continue For
                                End If


                                If IsNumeric(dat) Then
                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                Else
                                    Get_Value_Flag(cod, dat, flg)
                                End If
                                If IsDate(dttime) And IsDate(DateSerial(y, m, h)) Then
                                    If Station_Element(st, cod) Then
                                        If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype) Then Exit For
                                    End If
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
        Dim acquisitiontype As Integer
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
                        cod = txtElmCode.Text
                        acquisitiontype = 6

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
                                    ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                        'Do nothing
                                    Else ' Data column found
                                        ' Process data
                                        If IsNumeric(hd) Then
                                            'h = hd
                                            dttime = y & "-" & m & "-" & d & " " & hd & ":00"

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then

                                                If IsDate(dttime) Then
                                                    If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype) Then Exit For
                                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                    lblRecords.Refresh()
                                                    col = col + 1
                                                End If
                                                Continue For
                                            End If

                                            flg = ""
                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If
                                            If Station_Element(st, cod) Then
                                                If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype) Then Exit For 'Sub
                                            End If
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
        Dim acquisitiontype As Integer

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
                        acquisitiontype = 3
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

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then

                                                If IsDate(dttim) Then
                                                    If Not Add_Record(st, cod, dttim, "", "M", acquisitiontype) Then Exit For
                                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                    lblRecords.Refresh()
                                                    col = col + 1
                                                End If
                                                Continue For
                                            End If

                                            flg = ""
                                            If IsNumeric(dat) Then
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                ' Treat string data values as missing data
                                                flg = "M"
                                                dat = ""
                                            End If

                                            If Station_Element(st, cod) Then Add_Record(st, cod, dttim, dat, flg, acquisitiontype)

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
    Sub Load_Aws_special()
        'MsgBox(1)
        Dim st, cod, dttim, d, tt, dt, dat, hd, flg As String
        Dim dt_tm As Boolean
        Dim acquisitiontype As Integer
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
                        cod = txtElmCode.Text
                        acquisitiontype = 3
                        dt_tm = False

                        'h = txtObsHour.Text

                        For Each currentField In currentRow
                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then
                                    If .Columns(col).Name = "station_id" Then ' Station column found
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then ' Station column found
                                        cod = dat
                                    ElseIf .Columns(col).Name = "date_time" Then ' Combined Date and Timme column found
                                        dt_tm = True
                                        dttim = dat
                                    ElseIf .Columns(col).Name = "date" Then ' Separate Date column found 
                                        dt = dat
                                    ElseIf .Columns(col).Name = "time" Then ' Separate Time column found 
                                        tt = dat
                                    ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                        'Do nothing
                                    End If
                                End If
                            End With
                            If hd = "value" Then
                                flg = "" ' Initialize the flag
                                If dt_tm = False Then dttim = dt & " " & tt

                                'dttime = y & "-" & m & "-" & d & " " & h & ":00"
                                If IsNumeric(dat) Then
                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                Else
                                    Get_Value_Flag(cod, dat, flg)
                                End If
                                If IsDate(dttim) Then
                                    dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & Format(DateAndTime.Hour(dttim), "00") & ":" & Format(DateAndTime.Minute(dttim), "00") & ":" & Format(DateAndTime.Second(dttim), "00")

                                    ' Check for missing flag data values 
                                    If dat = txtMissingFlag.Text Then

                                        If IsDate(dttim) Then
                                            If Not Add_Record(st, cod, dttim, "", "M", acquisitiontype) Then Exit For
                                            lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                            lblRecords.Refresh()
                                            col = col + 1
                                        End If
                                        Continue For
                                    End If

                                    If Station_Element(st, cod) Then
                                        If Not Add_Record(st, cod, dttim, dat, flg, acquisitiontype) Then Exit For
                                    End If

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

    Sub Load_ColumnElems()
        Dim st, cod, y, m, d, h, dt_tm, hd, dat, dttcom, flg As String
        Dim acquisitiontype As Integer

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
                            cod = txtElmCode.Text
                            acquisitiontype = 6
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

                                            ' Days For Monthly accumulated data if any
                                            If optMonthly.Checked = True Then d = DateTime.DaysInMonth(y, m)


                                            If dttcom <> 3 And optMonthly.Checked = False Then
                                                MsgBox("Column headers yyyy, mm, dd Not found")
                                                Exit Sub
                                            Else 'compute datetime value
                                                dt_tm = y & "-" & m & "-" & d & " " & h & ":00:00"
                                            End If

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then
                                                If IsDate(dt_tm) Then
                                                    If Station_Element(st, cod) Then Add_Record(st, cod, dt_tm, "", "M", acquisitiontype)
                                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                    lblRecords.Refresh()
                                                    col = col + 1
                                                End If
                                                Continue For
                                            End If

                                            ' Process data
                                            cod = hd
                                            dat = currentField
                                            flg = ""

                                            If IsNumeric(dat) Then
                                                prd = 0
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If

                                            ' Process Dekadal data if any
                                            If optDekadal.Checked = True Then
                                                cprd = GetDekadPeriod(dt_tm)
                                                If IsNumeric(dat) Then flg = "C"
                                            End If

                                            ' Period and Flag Days For Monthly accumulated data if any
                                            If optMonthly.Checked = True Then
                                                cprd = DateTime.DaysInMonth(y, m)
                                                If IsNumeric(dat) Then flg = "C"
                                            End If

                                            If Station_Element(st, cod) Then Add_Record(st, cod, dt_tm, dat, flg, acquisitiontype)
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

    Sub Load_CLICOM(typ As String)
        Dim col, acquisitiontype As Integer
        Dim st, cod, dt, tm, dttime, hd, obsv, dat, flg As String
        Dim maxrows As Long

        ' Populate Gridview with column headers

        'Label the rows descriptors
        cmdLoadData.Enabled = True
        DataGridView1.Columns(0).Name = "Seq"
        DataGridView1.Columns(1).Name = "station_id"
        DataGridView1.Columns(2).Name = "element_code"
        DataGridView1.Columns(3).Name = "NA"
        DataGridView1.Columns(4).Name = "Date"

        ' Label the data and flag columns according to the CLICOM data type
        Select Case typ
            Case "daily"
                For i = 5 To 65 Step 2
                    col = (i - 1) / 2 - 1
                    DataGridView1.Columns(i).Name = col
                    DataGridView1.Columns(i + 1).Name = "FLAG"
                Next
            Case "synop"
                For i = 5 To 19 Step 2
                    col = i - (15 - i) / 2
                    DataGridView1.Columns(i).Name = col
                    DataGridView1.Columns(i + 1).Name = "FLAG"
                Next
            Case "hourly"
                For i = 5 To 51 Step 2
                    col = (i - 5) / 2
                    DataGridView1.Columns(i).Name = col
                    DataGridView1.Columns(i + 1).Name = "FLAG"
                Next
        End Select

        DataGridView1.Refresh()

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
                        tm = txtObsHour.Text
                        'flg = ""
                        acquisitiontype = 2

                        For Each currentField In currentRow

                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then
                                    If .Columns(col).Name = "station_id" Then
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then
                                        cod = dat
                                    ElseIf .Columns(col).Name = "Date" Then
                                        dt = dat
                                    Else ' Data or Flag column encountered

                                        If IsNumeric(hd) Then ' Data column only
                                            obsv = dat
                                            ' Construct the datetime string according to CLICOM data type
                                            Select Case typ
                                                Case "daily"

                                                    'dttime = dt & "-" & hd & " " & txtObsHour.Text & ":00"

                                                    dttime = Strings.Left(dt, 4) & "-" & Strings.Right(dt, 2) & "-" & hd & " " & txtObsHour.Text & ":00"
                                                Case "synop"
                                                    dttime = dt & " " & hd & ":00"
                                                Case "hourly"
                                                    dttime = dt & " " & hd & ":00"
                                            End Select

                                            If IsNumeric(dat) Then
                                                If dat = -99999 Then
                                                    obsv = ""
                                                Else
                                                    If chkScale.Checked = True Then Scale_Data(cod, obsv)
                                                End If
                                            End If
                                        Else
                                            If hd = "FLAG" Then
                                                flg = dat
                                                If Station_Element(st, cod) And IsDate(dttime) Then ' Exit For
                                                    If Not Add_Record(st, cod, dttime, obsv, flg, acquisitiontype) Then Exit For
                                                End If
                                            End If
                                        End If
                                    End If
                                    col = col + 1
                                End If
                            End With
                        Next
                        ' Show upload progress
                        lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text
                        lblRecords.Refresh()
                    End If
                Loop
            End Using
        Catch ex As Exception
            If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        End Try

    End Sub
    Sub Load_Monthly()

        Dim dt, st, cod, y, m, d, h, dttime, hd, dat, flg As String
        Dim acquisitiontype As Integer

        Me.Cursor = Cursors.WaitCursor
        Try

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False

                    'While Not MyReader.EndOfData
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        st = txtStn.Text
                        acquisitiontype = 6
                        h = txtObsHour.Text
                        cod = txtElmCode.Text
                        For Each currentField In currentRow

                            hd = DataGridView1.Columns(col).Name
                            dat = currentField

                            With DataGridView1
                                If col < .ColumnCount Then
                                    'If col = 3 Then MsgBox(dat)
                                    If .Columns(col).Name = "station_id" Then
                                        st = dat
                                    ElseIf .Columns(col).Name = "element_code" Then
                                        cod = dat
                                    ElseIf .Columns(col).Name = "yyyy" Then
                                        y = dat

                                    Else ' Data column encountered

                                        flg = ""
                                        If IsNumeric(hd) Then
                                            d = DateTime.DaysInMonth(y, hd)
                                            dttime = y & "-" & hd & "-" & d & " " & h & ":00"

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then
                                                If IsDate(dttime) Then
                                                    If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype) Then Exit For
                                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                    lblRecords.Refresh()
                                                    col = col + 1
                                                End If
                                                Continue For
                                            End If

                                                cprd = d
                                                flg = "C"

                                                If IsNumeric(dat) Then
                                                    'prd = 0 ' initialize data period counter
                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                                Else
                                                    Get_Value_Flag(cod, dat, flg)
                                                End If

                                                If Station_Element(st, cod) Then
                                                    If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype) Then Exit For 'Sub
                                                End If
                                            End If
                                        End If
                                    ' Show upload progress
                                    lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
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
    Sub Get_Value_Flag(code As String, ByRef dat As String, ByRef flg As String)
        'MsgBox("Flag")
        Dim datstr, flgchr As String
        Try

            If Len(dat) = 0 Then
                dat = ""
                flg = "M"
                prd = prd + 1 ' Update observation period counter
            Else
                datstr = Strings.Left(dat, Len(dat) - 1)
                flgchr = Strings.Right(dat, 1)
                If Not IsNumeric(datstr) Or IsNumeric(flgchr) Then
                    dat = ""
                    flg = "M"
                Else
                    If Strings.UCase(flgchr) = "C" Then
                        'Compute Total period for accummulated data
                        cprd = prd + 1
                        prd = 0
                        flgchr = ""
                    End If

                    dat = datstr
                    If chkScale.Checked = True Then Scale_Data(code, dat)
                    flg = Strings.UCase(flgchr)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
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
    Function GetDekadPeriod(ByRef dtm As String) As Integer
        Dim y1, m1, d1, h1 As String
        Try
            y1 = DateAndTime.Year(dtm)
            m1 = DateAndTime.Month(dtm)
            d1 = DateAndTime.Day(dtm)
            h1 = DateAndTime.Hour(dtm)

            If DateAndTime.Day(dtm) < 3 Then
                GetDekadPeriod = 10
                d1 = Val(d1) * 10
            Else
                GetDekadPeriod = Val(DateTime.DaysInMonth(DateAndTime.Year(dtm), DateAndTime.Month(dtm))) - 20
                d1 = 20 + GetDekadPeriod
            End If

            dtm = y1 & "-" & m1 & "-" & d1 & " " & h1 & ":00"
        Catch ex As Exception
            MsgBox(ex.Message)
            GetDekadPeriod = 10
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
        Add_Record("8535004", "2", "2004-2-1 9:00", "0.1", "", "0")
    End Sub


    Function Add_Record(stn As String, code As String, datetime As String, obsVal As String, flg As String, acqTyp As Integer) As Boolean
        Dim dat As String

        Try
            If Val(cprd) < 1 Then cprd = "NULL" ' No cummulative values

            dat = stn & ", " & code & ", " & datetime & ", surface ," & obsVal & ", " & flg & ", " & cprd & ", " & acqTyp

            Print(101, dat)
            PrintLine(101)

            cprd = "" ' Initialize Cummulative period value
            Return True
        Catch ex As Exception
            dbcon.Close()
            If ex.HResult <> -2147024882 And ex.HResult <> -2146232969 And ex.HResult <> -2146233079 Then
                If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Return False
            End If
            Return False
        End Try

    End Function

    Private Sub BindingSource2_CurrentChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtOther_TextChanged(sender As Object, e As EventArgs) Handles txtOther.TextChanged

    End Sub

    Private Sub cmbFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFields.SelectedIndexChanged
        Dim Colhd As String
        Dim x As Integer
        Try

            kount = InStr(cmbFields.Text, "-")

            'If InStr(cmbFields.Text, "-") > 0 Then
            If kount > 1 Then
                Colhd = ""
                x = 0
                For Each C As Char In cmbFields.Text
                    x = x + 1
                    If x < kount Then If IsNumeric(C) Then Colhd = Colhd & C
                Next
                'For Each C As Char In cmbFields.Text
                '        If IsNumeric(C) Then Colhd = Colhd & C
                'Next
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
            'MsgBox(sql)
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

    Private Sub cmdSaveErrors_Click(sender As Object, e As EventArgs)
        Dim errfile As String
        Try
            dlgSaveSchema.Filter = "Errors file|*.txt"
            dlgSaveSchema.Title = "Upload Errors"
            dlgSaveSchema.ShowDialog()

            errfile = dlgSaveSchema.FileName
            FileOpen(111, errfile, OpenMode.Output)

            If lstStations.Items.Count Then
                PrintLine(111, "Station Errors")
                For i = 0 To lstStations.Items.Count - 1
                    PrintLine(111, lstStations.Items(i))
                Next
            End If
            PrintLine(111)

            If lstElements.Items.Count Then
                PrintLine(111, "Elements Errors")
                For i = 0 To lstElements.Items.Count - 1
                    PrintLine(111, lstElements.Items(i))
                Next
            End If
            FileClose(111)

        Catch ex As Exception
            FileClose(111)
        End Try

    End Sub

    Private Sub FontDialog1_Apply(sender As Object, e As EventArgs)

    End Sub

    Function Station_Element(stn_id As String, elm_code As String) As Boolean
        Dim stn, elm, itm As Boolean

        stn = True
        elm = True
        Station_Element = True
        Try
            ' Check if Station exist
            sql = "select stationId from station where stationId like '" & stn_id & "';"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "station")

            If ds1.Tables("station").Rows.Count = 0 Then
                itm = False
                For i = 0 To lstStations.Items.Count - 1
                    If lstStations.Items(i) = stn_id Then
                        itm = True
                    End If
                Next
                ''lblStnEror.Text = "Station " & stn_id & " Not Found"
                'lblStnEror.Visible = True
                'lstStations.Visible = True
                If itm = False Then lstStations.Items.Add(stn_id)
                stn = False
            End If

            ' Check if Element exist
            sql = "select elementId from obselement where elementId = '" & elm_code & "';"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "element")

            If ds1.Tables("element").Rows.Count = 0 Then
                itm = False
                For i = 0 To lstElements.Items.Count - 1
                    If lstElements.Items(i) = elm_code Then
                        itm = True
                    End If
                Next
                ''lblElmeror.Text = "Element " & elm_code & " Not Found"
                'lblElmeror.Visible = True
                'lstElements.Visible = True
                If itm = False Then lstElements.Items.Add(elm_code)
                elm = False
            End If

            If stn = False Or elm = False Then
                Return False
            Else
                Return True

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

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
        Dim hdr, schemafile, dlt, strw, obshr, scal, id, code, flg As String
        'Dim configFilename As String = Application.StartupPath & "\schema.sch"
        Try
            dlgSaveSchema.Filter = "Schema file|*.sch"
            dlgSaveSchema.Title = "Save Schema"
            dlgSaveSchema.ShowDialog()
            schemafile = dlgSaveSchema.FileName
            FileOpen(100, schemafile, OpenMode.Output)

            'Get column headers
            hdr = DataGridView1.Columns(0).Name
            For i = 1 To DataGridView1.Columns.Count - 1
                hdr = hdr & "," & DataGridView1.Columns(i).Name
            Next

            PrintLine(100, hdr)
            ' Get data descriptions
            If optComma.Checked = True Then
                dlt = "Comma"
            ElseIf OptTAB.Checked = True Then
                dlt = "TAB"
            ElseIf OptOthers.Checked = True Then
                dlt = txtOther.Text
            End If

            strw = txtStartRow.Text
            obshr = txtObsHour.Text
            scal = chkScale.Checked
            id = txtStn.Text
            code = txtElmCode.Text
            flg = txtMissingFlag.Text
            PrintLine(100, dlt & "," & strw & "," & obshr & "," & scal & "," & id & "," & code & "," & flg)
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
                hdr = MyReader.ReadFields()
                'If hdr(0) = vbNull Then MsgBox("No Descriptiions")
                'MsgBox(Len(hdr))
                If Len(hdr(0)) > 0 Then
                    ' Populate descriptions

                    Select Case hdr(0)
                        Case "Comma"
                            optComma.Checked = True
                        Case "TAB"
                            OptTAB.Checked = True
                        Case Else
                            OptOthers.Checked = True
                            txtOther.Text = hdr(0)
                    End Select
                    txtStartRow.Text = hdr(1)
                    txtObsHour.Text = hdr(2)
                    chkScale.Checked = hdr(3)
                    txtStn.Text = hdr(4)
                    txtElmCode.Text = hdr(5)
                    ' The following code added to cater for the added object for missing data flag text box
                    If hdr.Count > 6 Then
                        txtMissingFlag.Text = hdr(6)
                    Else
                        txtMissingFlag.Text = ""
                    End If
                End If
            End Using
        Catch ex As Exception
            If ex.HResult <> -2147467261 Then MsgBox(ex.Message)
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
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "aws.htm")
        ElseIf Text = "CLICOM Daily" Or Text = "CLICOM Synop" Or Text = "CLICOM Hourly" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "clicom.htm")
        ElseIf Text = "Hourly Data Import" Or Text = "Daily Data Import" Or Text = "Multiple Columns Data Import" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#DailyHourly")
        Else
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#procedures")
        End If
    End Sub

    Private Sub txtOther_GotFocus(sender As Object, e As EventArgs) Handles txtOther.GotFocus
        OptOthers.Checked = True
    End Sub

    Private Sub frmImportDaily_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Len(recCommit.RegkeyValue("key01")) <> 0 Then txtObsHour.Text = recCommit.RegkeyValue("key01")

        If Text = "CLICOM Daily" Or Text = "CLICOM Synop" Or Text = "CLICOM Hourly" Then
            lblMissingFlag.Visible = False
            txtMissingFlag.Visible = False
        End If
    End Sub
End Class