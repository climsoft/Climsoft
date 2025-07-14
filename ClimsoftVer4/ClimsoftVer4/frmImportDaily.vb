Public Class frmImportDaily
    Dim dbcon As New MySqlConnector.MySqlConnection
    Dim recCommit As New dataEntryGlobalRoutines
    Dim da1 As MySqlConnector.MySqlDataAdapter
    Dim dbConnectionString, dat, flg As String
    Dim ds1 As New DataSet
    Dim dsNewRow As DataRow
    Dim sql, currentRow(), delimit, cprd As String
    Dim lin, rec, col, kount, prd As Integer
    Dim ImportFile As Boolean
    Dim loadFile As New dataEntryGlobalRoutines

    Public Enum ImportType
        Hourly
        Daily
        Monthly
        MultipleElements
        ClicomDaily
        ClicomSynop
        ClicomHourly
        Dekadal
        AWSData
        NOAAGTS
    End Enum

    Private _enumImportType As ImportType = ImportType.Daily

    Public Sub Setup(enumImportType As ImportType)

        Me._enumImportType = enumImportType

        Select Case _enumImportType
            Case ImportType.Hourly
                Text = ClsTranslations.GetTranslation("Hourly Data Import")
                lblType.Text = ClsTranslations.GetTranslation("Hourly")
                lblDefaultObsHour.Visible = False
                txtObsHour.Visible = False
                grpSummary.Visible = False
                chkUTC.Visible = True
            Case ImportType.Daily
                Text = ClsTranslations.GetTranslation("Daily Data Import")
                lblType.Text = ClsTranslations.GetTranslation("Daily")
            Case ImportType.Monthly
                Text = ClsTranslations.GetTranslation("Monthly Data")
                lblType.Text = ClsTranslations.GetTranslation("Monthly")
                txtStartRow.Text = 2
                chkScale.Checked = True
                cboStns.Enabled = True
                grpSummary.Visible = False
            Case ImportType.MultipleElements
                Text = ClsTranslations.GetTranslation("Multiple Columns Data Import")
                lblType.Text = ClsTranslations.GetTranslation("Multiple Elements")
                optMonthly.Enabled = True
                lblElmCode.Visible = False
                grpUpperAir.Visible = True
                cboElement.Visible = False
            Case ImportType.ClicomDaily
                Text = ClsTranslations.GetTranslation("CLICOM Daily")
                lblType.Text = ClsTranslations.GetTranslation("CLICOMdaily")
                txtStartRow.Text = 1
                chkScale.Checked = True
                cboStns.Enabled = False
                grpSummary.Visible = False
                lblElmCode.Visible = False
                cboElement.Visible = False
                lblMissingFlag.Visible = False
                txtMissingFlag.Visible = False
            Case ImportType.ClicomHourly
                Text = ClsTranslations.GetTranslation("CLICOM Hourly")
                lblType.Text = ClsTranslations.GetTranslation("CLICOMhourly")
                txtStartRow.Text = 1
                chkScale.Checked = True
                cboStns.Enabled = False
                grpSummary.Visible = False
                lblElmCode.Visible = False
                cboElement.Visible = False
                lblMissingFlag.Visible = False
                txtMissingFlag.Visible = False
            Case ImportType.ClicomSynop
                Text = ClsTranslations.GetTranslation("CLICOM Synop")
                lblType.Text = ClsTranslations.GetTranslation("CLICOMsynop")
                txtStartRow.Text = 1
                chkScale.Checked = True
                cboStns.Enabled = False
                grpSummary.Visible = False
                lblElmCode.Visible = False
                cboElement.Visible = False
                lblMissingFlag.Visible = False
                txtMissingFlag.Visible = False
            Case ImportType.Dekadal
                Text = ClsTranslations.GetTranslation("Dekadal Data Import")
                lblType.Text = ClsTranslations.GetTranslation("Dekadal")
                optDekadal.Checked = True
            Case ImportType.AWSData
                Text = ClsTranslations.GetTranslation("AWS Data Import")
                lblType.Visible = False
                lblType.Text = "AWS"
                lblDefaultObsHour.Visible = False
                txtObsHour.Visible = False
                chkScale.Visible = True
                chkScale.Checked = True
                txtObsHour.Visible = False
                lblStn.Visible = True
                lblElmCode.Visible = False
                cboElement.Visible = False
                grpSummary.Visible = False
            Case ImportType.NOAAGTS
                Text = ClsTranslations.GetTranslation("NOAA GTS Data Import")
                lblType.Visible = False
                lblType.Text = "NOAA_GTS"
                lblDefaultObsHour.Visible = False
                txtObsHour.Visible = False
                lblDefaultObsHour.Visible = True
                chkScale.Enabled = False
                chkScale.Checked = True
                txtObsHour.Visible = True
                lblStn.Visible = True
                lblElmCode.Visible = False
                cboElement.Visible = False
                grpSummary.Visible = False
        End Select
    End Sub


    Private Sub cmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        dlgOpenImportFile.Filter = "Comma Delimited|*.csv;*.txt;*.*"
        dlgOpenImportFile.Title = ClsTranslations.GetTranslation("Open Import Text File")
        dlgOpenImportFile.ShowDialog()

        txtImportFile.Text = dlgOpenImportFile.FileName
        lblSpecs.Text = ""
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click

        Dim rec, fld As Integer
        Dim currentRow As String()
        'Dim currentField As String

        'Dim delimit As String
        'Set cursor to busy mood
        Me.Cursor = Cursors.WaitCursor
        lblQCfile.Visible = False
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

                ' Fill the DataGrid with few records for the file structure to be understood
                rec = 0
                fld = 0
                Do While MyReader.EndOfData = False 'Or rec < 30
                    rec = rec + 1
                    Try
                        currentRow = MyReader.ReadFields()
                        'MsgBox(currentRow.Count)
                        If currentRow.Count > fld Then DataGridView1.ColumnCount = currentRow.Count
                        fld = currentRow.Count
                        DataGridView1.Rows.Add(currentRow)
                        'rec = rec + 1
                    Catch ex As Exception
                        If ex.HResult = -2147467261 Then
                            Exit Do
                        Else
                            MsgBox("The selected delimiter doesn't match the file")
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End Try
                    If rec > 99 Then Exit Do ' It's expected that with about 100 records on the Grid View the data structure will be well captured

                Loop
                'MsgBox(rec)
                ' Adjust the Columns list and the Data Grid View according to the current record fields
                lstColumn.Items.Clear()
                For i = 1 To DataGridView1.ColumnCount
                    DataGridView1.Columns(i - 1).Name = i
                    lstColumn.Items.Add(i)
                Next

                ''Get Total Records Number
                'lblTRecords.Text = IO.File.ReadAllLines(txtImportFile.Text).Length
                'lblTRecords.Refresh()
            End Using
            'Get Total Records Number
            lblTRecords.Text = IO.File.ReadAllLines(txtImportFile.Text).Length
            lblTRecords.Refresh()

        Catch x As Exception
            MsgBox(x.Message)
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Try
            ' Special file structures
            Select Case _enumImportType
                Case ImportType.AWSData
                    List_AWSFields()
                Case ImportType.NOAAGTS
                    List_NOAAGTSFields()
                Case ImportType.Monthly
                    List_Monthly()
                Case ImportType.MultipleElements
                    If chkUpperAir.Checked Then
                        List_UpperAirFields()
                    Else
                        List_ObsFields()
                    End If
                Case ImportType.ClicomDaily
                    cmdLoadData.Enabled = True
                Case ImportType.ClicomHourly
                    cmdLoadData.Enabled = True
                Case ImportType.ClicomSynop
                    cmdLoadData.Enabled = True
            End Select

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
            If ex.HResult <> -2147024891 Then
                MsgBox(ex.HResult & " " & Err.Description)
            End If
            Me.Cursor = Cursors.Default
        End Try

        Try
            If DataGridView1.RowCount > 0 Then
                'cmdLoadData.Enabled = True

                ' CLICOM imports have fixed structure hence the panel for header specifications should not be used hence it's not enabled
                If InStr(Text, ClsTranslations.GetTranslation("CLICOM")) < 1 Then pnlHeaders.Enabled = True
            Else
                cmdLoadData.Enabled = False
                pnlHeaders.Enabled = False
            End If
            Me.Cursor = Cursors.Default
            lstStations.Items.Clear()
            lstElements.Items.Clear()
            pnlErrors.Visible = False
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox(Ex.message)
        End Try
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
            cmbFields.Items.Add("hh")
            cmbFields.Items.Add("nn")
            cmbFields.Items.Add("ss")
            cmbFields.Items.Add("value")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where Selected = 1;" ' where elementId > 880 ;"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
    Sub List_UpperAirFields()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            'cmbFields.Items.Add("element_code")
            cmbFields.Items.Add("level")
            'cmbFields.Items.Add("date_time")
            'cmbFields.Items.Add("date")
            cmbFields.Items.Add("time_disp")
            'cmbFields.Items.Add("yyyy")
            'cmbFields.Items.Add("mm")
            'cmbFields.Items.Add("dd")
            'cmbFields.Items.Add("hh")
            'cmbFields.Items.Add("value")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where elementtype = 'Upper Air';"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
            cmbFields.Items.Add("date_time")
            cmbFields.Items.Add("date")
            cmbFields.Items.Add("time")
            cmbFields.Items.Add("yyyy")
            cmbFields.Items.Add("mm")
            cmbFields.Items.Add("dd")
            cmbFields.Items.Add("hh")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where selected = 1;" 'elementId < 881;"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
    Sub List_Monthly()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            cmbFields.Items.Add("element_code")
            cmbFields.Items.Add("yyyy")
            'cmbFields.Items.Add("value")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            For i = 1 To 12
                cmbFields.Items.Add(i)
            Next

            'sql = "select elementId, abbreviation from obselement where elementId > 880 ;"

            'da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
            'ds1.Clear()
            'da1.Fill(ds1, "obselement")

            'kount = ds1.Tables("obselement").Rows.Count

            'If kount = 0 Then Exit Sub

            'For i = 0 To kount - 1
            '    cmbFields.Items.Add(ds1.Tables("obselement").Rows(i).Item("elementId") & "-" & ds1.Tables("obselement").Rows(i).Item("abbreviation"))
            'Next

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
        lblQCfile.Visible = False
    End Sub

    Private Sub cmdRename_Click(sender As Object, e As EventArgs) Handles cmdRename.Click
        'MsgBox(lstColumn.Text)
        DataGridView1.Columns(CInt(lstColumn.Text) - 1).Name = cmbFields.Text
        DataGridView1.Refresh()
    End Sub

    Private Sub cmdLoadData_Click(sender As Object, e As EventArgs) Handles cmdLoadData.Click
        Dim DataCat, fl1, fl2, cr, sql0 As String
        Dim objCmd As MySqlConnector.MySqlCommand

        ImportFile = True
        pnlErrors.Visible = False
        Try

            ' Set busy Cursor pointer
            Me.Cursor = Cursors.WaitCursor
            lblRecords.Text = ""
            lblTRecords.Text = Val(lblTRecords.Text) - Val(txtStartRow.Text) + 1 ' Compute total data records from the input file
            'If Not IO.Directory.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data") Then
            If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data") Then
                'IO.Directory.CreateDirectory(Application.StartupPath & "\data")
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data")
            End If
            'fl1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_sql.csv"
            fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_sql.csv"
            FileOpen(101, fl1, OpenMode.Output)

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString ' & ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
            dbcon.Open()

            ' Contruct the SQL path structure for the output file
            fl2 = ""
            For i = 1 To Len(fl1)
                cr = Strings.Mid(fl1, i, 1)
                If cr = "\" Then cr = "/"
                fl2 = fl2 & cr
            Next

            ' Determine data category from selected menu

            Select Case _enumImportType
                Case ImportType.Hourly
                    DataCat = "Hourly"
                Case ImportType.Daily
                    DataCat = "Daily2"
                Case ImportType.Monthly
                    DataCat = "Monthly"
                Case ImportType.MultipleElements
                    DataCat = "ColElms"
                Case ImportType.ClicomDaily
                    DataCat = "CLICOMDLY"
                Case ImportType.ClicomHourly
                    DataCat = "CLICOMHLY"
                Case ImportType.ClicomSynop
                    DataCat = "CLICOMSYP"
                Case ImportType.AWSData
                    DataCat = "AWS"
                Case ImportType.NOAAGTS
                    DataCat = "NOAAGTS"
                Case Else
                    DataCat = ""
            End Select


            ' Determine special data categories from files header
            ' Check for Daily1, Hourly1 and AWS_special file types
            For i = 0 To DataGridView1.Columns.Count - 1
                If DataGridView1.Columns(i).Name = "value" Then
                    Select Case _enumImportType
                        Case ImportType.Daily
                            DataCat = "Daily1"
                        Case ImportType.Hourly
                            DataCat = "Daily1"
                        Case ImportType.AWSData
                            DataCat = "AWS_special"
                    End Select
                    Exit For
                End If
            Next

            lblRecords.Text = ""
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
                    If chkUpperAir.Checked Then
                        load_UpperAir()
                    Else
                        Load_ColumnElems()
                    End If
                Case "CLICOMDLY"
                    Load_CLICOM("daily")
                Case "CLICOMSYP"
                    Load_CLICOM("synop")
                Case "CLICOMHLY"
                    Load_CLICOM("hourly")
                Case "Monthly"
                    Load_Monthly()
                Case "NOAAGTS"
                    Load_NOAAGTS()
            End Select

            FileClose(101)

            ' Create sql query to upload data from SQL file

            If rbtnFinal.Checked Then ' load data into observationfinal table
                loadFile.Load_Files(fl2, "observationfinal", 0, ",")
                'sql0 = "LOAD DATA local INFILE '" & fl2 & "' IGNORE INTO TABLE observationfinal FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType);"
            Else ' load data into observationinitial table
                loadFile.Load_Files(fl2, "observationinitial", 0, ",")
                'sql0 = "LOAD DATA local INFILE '" & fl2 & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType);"
            End If

            'objCmd = New MySqlConnector.MySqlCommand(sql0, dbcon)

            ''Execute query
            'objCmd.CommandTimeout = 0
            'objCmd.ExecuteNonQuery()

            'If ImportFile Then
            '    lblRecords.Text = "Data import process successfully completed"
            'Else
            '    lblRecords.Text = "Data Import Failed!"
            'End If

            'dbcon.Close()
            'Me.Cursor = Cursors.Default

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
            lblRecords.Text = "Data import process successfully completed"
            Me.Cursor = Cursors.Default
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

        Dim dt, st, cod, y, m, d, h, dttime, hd, dat, flg, lvl As String
        Dim acquisitiontype As Integer

        Me.Cursor = Cursors.WaitCursor
        'Try

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    'While Not MyReader.EndOfData
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        acquisitiontype = 6
                        h = txtObsHour.Text
                        'cod = cboElement.Text
                        cod = cboElement.SelectedValue
                        'MsgBox(cod)

                        lvl = "surface"

                        For Each currentField In currentRow
                            Try
                                hd = DataGridView1.Columns(col).Name
                                dat = currentField

                                With DataGridView1
                                    If col < .ColumnCount Then
                                        'If col = 3 Then MsgBox(dat)
                                        If .Columns(col).Name = "station_id" Then
                                            st = dat
                                        ElseIf .Columns(col).Name = "element_code" Then
                                            cod = dat
                                        ElseIf .Columns(col).Name = "level" Then
                                            lvl = dat
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
                                                'dttime = DateAdd("h", 2, dttime)

                                                ' Check for missing flag data values 
                                                If dat = txtMissingFlag.Text Then
                                                    If dat = "" Then
                                                        col = col + 1
                                                        Continue For 'Blanks to be skipped
                                                    End If
                                                    If IsDate(dttime) Then
                                                        If Station_Element(st, cod) Then
                                                            'Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl)
                                                            If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl) Then Exit For
                                                        Else
                                                            If Not ImportFile Then Exit Sub
                                                        End If
                                                        lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
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
                                                    'MsgBox(y & "-" & m & "-" & hd & " " & h & ":00" & "  " & col & "  " & flg)
                                                End If

                                                ' Process Dekadal data if any
                                                If optDekadal.Checked = True Then
                                                    cprd = GetDekadPeriod(dttime)
                                                    If IsNumeric(dat) Then flg = "C"
                                                End If

                                                If Station_Element(st, cod) Then
                                                    If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype, lvl) Then Exit For 'Sub
                                                Else
                                                    If Not ImportFile Then Exit Sub
                                                End If
                                            End If
                                        End If
                                        ' Show upload progress
                                        lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                        lblRecords.Refresh()
                                        col = col + 1
                                    End If
                                End With
                            Catch ex As Exception
                                'MsgBox(ex.Message)
                                Continue For
                            End Try
                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using

        'Catch ex As Exception
        '    If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        'End Try

    End Sub
   
    Sub Load_Daily1()

        'Try
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Dim st, cod, y, m, d, h, dttime, hd, dat, flg, lvl As String
                Dim acquisitiontype As Integer

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Initialize values
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue

                        h = txtObsHour.Text
                        'cod = txtElmCode.Text
                        cod = cboElement.SelectedValue
                        If cboElement.Text = "" Then cod = ""
                        lvl = "surface"
                        acquisitiontype = 6
                        dttime = ""

                        For Each currentField In currentRow
                            Try
                                hd = DataGridView1.Columns(col).Name
                                dat = currentField
                                With DataGridView1
                                    If col < .ColumnCount Then
                                        If .Columns(col).Name = "station_id" Then
                                            st = dat
                                        ElseIf .Columns(col).Name = "element_code" Then
                                            cod = dat
                                        ElseIf .Columns(col).Name = "date_time" Then  ' Year column found
                                            dttime = DateAndTime.Year(dat) & "-" & DateAndTime.Month(dat) & "-" & DateAndTime.Day(dat) & " " & DateAndTime.Hour(dat) & ":" & DateAndTime.Minute(dat) & ":" & DateAndTime.Second(dat)
                                        ElseIf .Columns(col).Name = "date" Then  ' Year column found
                                            dttime = DateAndTime.Year(dat) & "-" & DateAndTime.Month(dat) & "-" & DateAndTime.Day(dat) & " " & h & ":00:00"
                                        ElseIf .Columns(col).Name = "level" Then
                                            lvl = dat
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
                                    'MsgBox(dttime)
                                    flg = "" ' Initialize the flag

                                    If dttime = "" Then
                                        dttime = y & "-" & m & "-" & d & " " & h & ":00"
                                    End If
                                    'MsgBox(dttime)
                                    'dttime = y & "-" & m & "-" & d & " " & h & ":00"


                                    ' Check for missing flag data values 
                                    If dat = txtMissingFlag.Text Then
                                        If dat = "" Then Continue For 'Blanks to be skipped
                                        If IsDate(dttime) Then
                                            If Station_Element(st, cod) Then
                                                Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl)
                                            Else
                                                If Not ImportFile Then Exit Sub
                                            End If
                                            lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
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
                                            If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype, lvl) Then Exit For
                                        Else
                                            If Not ImportFile Then Exit Sub
                                        End If
                                    End If

                                    ' Show upload progress
                                    lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                    lblRecords.Refresh()

                                End If
                                col = col + 1
                            Catch x As Exception
                                Continue For
                            End Try
                        Next

                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using
        'Catch ex As Exception
        '    MsgBox(ex.HResult & " " & ex.Message)
        'End Try

    End Sub


    Sub Load_Hourly()
        'MsgBox("form_hourly")
        Dim st, cod, y, m, d, dttime, UTC_dt, hd, dat, flg, lvl As String
        Dim nextDay As Date
        Dim acquisitiontype As Integer

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                'MsgBox("Daily")

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        'cod = txtElmCode.Text
                        cod = cboElement.SelectedValue
                        acquisitiontype = 6
                        lvl = "surface"
                        For Each currentField In currentRow
                            Try
                                hd = DataGridView1.Columns(col).Name()
                                dat = currentField
                                With DataGridView1
                                    If col < .ColumnCount Then
                                        If .Columns(col).Name = "station_id" Then
                                            st = dat
                                        ElseIf .Columns(col).Name = "element_code" Then
                                            cod = dat
                                        ElseIf .Columns(col).Name = "level" Then
                                            lvl = dat
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

                                                If hd = 24 Then
                                                    hd = "00"
                                                    dttime = y & "-" & m & "-" & d & " " & hd & ":00"
                                                    nextDay = DateAdd("d", 1, dttime)
                                                    dttime = DateAndTime.Year(nextDay) & "-" & DateAndTime.Month(nextDay) & "-" & DateAndTime.Day(nextDay) & " " & hd & ":00"
                                                End If

                                                ' Check for missing flag data values 
                                                If dat = txtMissingFlag.Text Then
                                                    If dat = "" Then Continue For 'Blanks to be skipped
                                                    If IsDate(dttime) Then
                                                        If Station_Element(st, cod) Then
                                                            If chkUTC.Checked Then
                                                                UTC_dt = UTC_Convert(dttime)
                                                                If Not Add_Record(st, cod, UTC_dt, "", "M", acquisitiontype, lvl) Then Exit For
                                                            Else
                                                                If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl) Then Exit For
                                                            End If
                                                        Else
                                                            If Not ImportFile Then Exit Sub
                                                        End If

                                                        lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                        lblRecords.Refresh()
                                                        col = col + 1
                                                    End If

                                                    'If chkUTC.Checked Then
                                                    '    UTC_dt = UTC_Convert(dttime)
                                                    '    If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl) Then Exit For
                                                    'Else
                                                    '    If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl) Then Exit For
                                                    'End If

                                                    'If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype, lvl) Then Exit For

                                                    Continue For
                                                End If

                                                flg = ""
                                                If IsNumeric(dat) Then
                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                                Else
                                                    Get_Value_Flag(cod, dat, flg)
                                                End If
                                                If Not Station_Element(st, cod) Then
                                                    If Not ImportFile Then Exit Sub
                                                Else
                                                    If IsDate(dttime) Then

                                                        If chkUTC.Checked Then
                                                            UTC_dt = UTC_Convert(dttime)
                                                            If Not Add_Record(st, cod, UTC_dt, dat, flg, acquisitiontype, lvl) Then Exit For
                                                        Else
                                                            If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype, lvl) Then Exit For
                                                        End If
                                                    End If

                                                End If
                                            End If
                                        End If ' Last DataGridView which is equivalent to End data columns 

                                        ' Show upload progress
                                        lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                        lblRecords.Refresh()
                                        col = col + 1
                                    End If ' DatagridView1 column condition
                                End With ' DatagridView1
                            Catch x As Exception
                                'MsgBox(x.Message)
                                Continue For
                            End Try
                        Next ' Next Data field
                    End If ' Record number greater than start row
                Catch ex As Exception
                    'MsgBox(ex.Message)
                    Continue Do
                End Try
            Loop ' Next Data row
            End Using ' MyReader

        'Catch ex As Exception
        '    MsgBox(ex.HResult & " " & ex.Message)
        'End Try
    End Sub

    Sub Load_Aws()

        Dim st, cod, dttim, h, n, s, tt, dt, dat, hd, flg, qc_folder, LimitErr, qcFile As String
        Dim dt_tm, tt_tm As Boolean
        Dim acquisitiontype, ErRecord As Integer


        'Create file for errors output in the QC folder as per the registry settings
        qc_folder = recCommit.RegkeyValue("key07")
        qcFile = qc_folder & "\qc_" & IO.Path.GetFileNameWithoutExtension(txtImportFile.Text) & ".csv"
        'MsgBox(fl)

        FileOpen(31, qcFile, OpenMode.Output)

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(delimit)

            ErRecord = 0
            Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        ' Initialize values
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        'MsgBox(st)
                        acquisitiontype = 3
                        dt_tm = False
                        tt_tm = False

                        'h = txtObsHour.Text

                        For Each currentField In currentRow
                            Try
                                hd = DataGridView1.Columns(col).Name
                                'Catch x As Exception
                                '    'MsgBox(col & " " & x.Message)
                                '    Exit For
                                'End Try

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
                                            tt_tm = True
                                        ElseIf .Columns(col).Name = "hh" Then ' Separate Time column found 
                                            h = dat
                                        ElseIf .Columns(col).Name = "nn" Then ' Separate Minut column found 
                                            n = dat
                                        ElseIf .Columns(col).Name = "ss" Then ' Separate Second column found 
                                            s = dat
                                        ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                            'Do nothing
                                        Else ' Data Column found

                                            cod = .Columns(col).Name
                                            '    dat = .Rows(i).Cells(j).Value
                                            If dt_tm = False Then ' Date and Time field does not exist
                                                If tt_tm = False Then ' Time field is not there
                                                    If Len(n) = 0 Then n = "00"
                                                    If Len(s) = 0 Then s = "00"
                                                    dttim = dt & " " & h & ":" & n & ":" & s
                                                Else
                                                    dttim = dt & " " & tt
                                                End If
                                            End If

                                            If InStr(dttim, " 24") <> 0 Then
                                                dttim = Strings.Replace(dttim, " 24", " 00")
                                                dttim = DateAndTime.DateAdd("d", 1, dttim)
                                                dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & DateAndTime.Hour(dttim) & ":" & DateAndTime.Minute(dttim) & ":" & DateAndTime.Second(dttim)
                                            End If

                                            If IsDate(dttim) Then

                                                dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & Format(DateAndTime.Hour(dttim), "00") & ":" & Format(DateAndTime.Minute(dttim), "00") & ":" & Format(DateAndTime.Second(dttim), "00")

                                                ' Check for missing flag data values 
                                                If dat = txtMissingFlag.Text Then
                                                    col = col + 1
                                                    If dat = "" Then Continue For 'Blanks to be skipped

                                                    If IsDate(dttim) Then
                                                        If Station_Element(st, cod) Then

                                                            If Not Add_Record(st, cod, dttim, "", "M", acquisitiontype) Then Exit For
                                                            lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                            lblRecords.Refresh()
                                                        End If
                                                    End If
                                                    Continue For
                                                End If

                                                flg = ""
                                                If IsNumeric(dat) Then
                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                                Else
                                                    ' Treat string data values as missing data
                                                    If dat = "" Then 'Blanks to be skipped
                                                        col = col + 1
                                                        Continue For
                                                    End If
                                                    flg = "M"
                                                    dat = ""
                                                End If

                                                If Station_Element(st, cod) Then
                                                    If rbtnFinal.Checked And QC_DataErr(cod, dat, LimitErr) Then
                                                        PrintLine(31, st & "," & cod & "," & dttim & "," & dat & "," & LimitErr)
                                                        ErRecord = ErRecord + 1
                                                        'col = col + 1
                                                        'Continue For
                                                    Else
                                                        Add_Record(st, cod, dttim, dat, flg, acquisitiontype)
                                                    End If
                                                Else
                                                    If Not ImportFile Then
                                                        FileClose(31)
                                                        Exit Sub
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End With

                                col = col + 1
                                ' Show upload progress
                                lblRecords.Text = LoadingCount(MyReader.LineNumber)
                                lblRecords.Refresh()
                            Catch x As Exception

                                Exit For
                            End Try
                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
        End Using
        FileClose(31)
        'MsgBox(ErRecord)
        If ErRecord > 0 Then
            lblQCfile.Visible = True
            lblQCfile.Text = ErRecord & "  QC errors saved in: " & qcFile

        End If
    End Sub
    Sub Load_Aws_special()
        'MsgBox(1)
        Dim st, cod, dttim, d, tt, dt, dat, hd, flg As String
        Dim dt_tm As Boolean
        Dim acquisitiontype As Integer
        'Try
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        ' Initialize values
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        'cod = txtElmCode.Text
                        cod = cboElement.SelectedValue
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
                                        If dat = "" Then Continue For 'Blanks to be skipped
                                        If IsDate(dttim) Then
                                            If Station_Element(st, cod) Then
                                                If Not Add_Record(st, cod, dttim, "", "M", acquisitiontype) Then Exit For
                                                lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                lblRecords.Refresh()
                                                col = col + 1
                                            End If
                                        End If
                                        Continue For
                                    End If

                                    If Not Station_Element(st, cod) Then
                                        If Not ImportFile Then Exit Sub
                                    Else
                                        If Not Add_Record(st, cod, dttim, dat, flg, acquisitiontype) Then Exit For
                                    End If

                                End If

                                ' Show upload progress
                                lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                lblRecords.Refresh()

                            End If
                            col = col + 1

                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using
        'Catch ex As Exception
        '    MsgBox(ex.HResult & " " & ex.Message)
        'End Try
    End Sub

    Sub Load_ColumnElems()
        Dim st, cod, y, m, d, h, dt_tm, hd, dat, dttcom, flg, lvl As String
        Dim acquisitiontype As Integer

        'Try
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        If MyReader.LineNumber > Val(txtStartRow.Text) Then

                            'st = txtStn.Text
                            st = cboStns.SelectedValue
                            h = Val(txtObsHour.Text)
                            'cod = txtElmCode.Text
                            cod = cboElement.SelectedValue
                            acquisitiontype = 6
                            dttcom = 0
                            col = 0
                            lvl = "surface"
                            dt_tm = ""

                            For Each currentField In currentRow
                                hd = DataGridView1.Columns(col).Name
                                'MsgBox(hd)
                                dat = currentField
                                With DataGridView1
                                    If col < .ColumnCount Then
                                        If .Columns(col).Name = "station_id" Then ' Station column found
                                            st = dat
                                        ElseIf .Columns(col).Name = "date_time" Then  ' Year column found
                                            dt_tm = DateAndTime.Year(dat) & "-" & DateAndTime.Month(dat) & "-" & DateAndTime.Day(dat) & " " & DateAndTime.Hour(dat) & ":" & DateAndTime.Minute(dat) & ":" & DateAndTime.Second(dat)
                                        ElseIf .Columns(col).Name = "date" Then  ' Year column found
                                            dt_tm = DateAndTime.Year(dat) & "-" & DateAndTime.Month(dat) & "-" & DateAndTime.Day(dat) & " " & h & ":00:00"

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
                                        ElseIf .Columns(col).Name = "level" Then ' Hour column found
                                            lvl = dat
                                        ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                            'Column labeled NA will be skipped
                                        Else

                                            ' Data column follows
                                            cod = hd

                                            ' Days For Monthly accumulated data if any
                                            If optMonthly.Checked = True Then d = DateTime.DaysInMonth(y, m)

                                            If Not IsDate(dt_tm) Then
                                                If dttcom <> 3 And optMonthly.Checked = False Then
                                                    MsgBox("Column headers yyyy, mm, dd Not found")
                                                    Exit Sub
                                                Else 'compute datetime value
                                                    dt_tm = y & "-" & m & "-" & d & " " & h & ":00:00"
                                                End If
                                            End If

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then
                                                'MsgBox(dt_tm & " " & dat)
                                                If dat = "" Then Continue For 'Blanks to be skipped
                                                If IsDate(dt_tm) Then

                                                    'MsgBox(st & " " & cod)
                                                    If Station_Element(st, cod) Then
                                                        Add_Record(st, cod, dt_tm, "", "M", acquisitiontype)
                                                        lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                        lblRecords.Refresh()
                                                        col = col + 1
                                                    Else
                                                        If ImportFile = False Then Exit Sub
                                                    End If
                                                End If
                                                Continue For
                                            End If

                                            ' Process data

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
                                                dt_tm = y & "-" & m & "-" & d & " " & h & ":00:00"
                                                cprd = GetDekadPeriod(dt_tm)
                                                If IsNumeric(dat) Then flg = "C"
                                            End If

                                            ' Period and Flag Days For Monthly accumulated data if any
                                            If optMonthly.Checked = True Then
                                                cprd = DateTime.DaysInMonth(y, m)
                                                If IsNumeric(dat) Then flg = "C"
                                            End If

                                            ''MsgBox(dt_tm & " " & DateAdd("h", -1 * Val(txtTdiff.Text), dt_tm))
                                            'If chkUTC.Checked Then
                                            '    UTC_dt = UTC_Convert(dt_tm)
                                            '    If Station_Element(st, cod) Then Add_Record(st, cod, UTC_dt, dat, flg, acquisitiontype, lvl)
                                            'Else
                                            '    If Station_Element(st, cod) Then Add_Record(st, cod, dt_tm, dat, flg, acquisitiontype, lvl)
                                            'End If
                                            'MsgBox(st & " " & dt_tm & " " & cod & " " & dat)
                                            If Station_Element(st, cod) Then
                                                'MsgBox(st & " " & dt_tm & " " & cod & " " & dat)
                                                Add_Record(st, cod, dt_tm, dat, flg, acquisitiontype, lvl)
                                                lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                                lblRecords.Refresh()
                                            Else
                                                If ImportFile = False Then Exit Sub
                                            End If
                                        End If

                                    End If
                                End With

                                ' Show upload progress
                                'lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                'lblRecords.Refresh()
                                col = col + 1
                            Next
                        End If
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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
        'Try

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
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
                                                If InStr(dat, "-99999") > 0 Then '= -99999.0 Then
                                                    obsv = ""
                                                Else
                                                    If chkScale.Checked = True Then
                                                        Scale_Data(cod, obsv)
                                                    End If

                                                End If
                                            End If
                                        Else
                                            If hd = "FLAG" Then
                                                flg = dat
                                                If Station_Element(st, cod) And IsDate(dttime) Then ' Exit For
                                                    If Not Add_Record(st, cod, dttime, obsv, flg, acquisitiontype) Then Exit For
                                                Else
                                                    If Not ImportFile Then Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                    col = col + 1
                                End If
                            End With
                        Next
                        ' Show upload progress
                        lblRecords.Text = ClsTranslations.GetTranslation("Loading:  ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text
                        lblRecords.Refresh()
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using
        'Catch ex As Exception
        '    If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        'End Try

    End Sub
    Sub Load_Monthly()
        'MsgBox(1)
        'MsgBox(cboElement.SelectedValue)
        Dim dt, st, cod, y, m, d, h, dttime, hd, dat, flg As String
        Dim acquisitiontype As Integer

        Me.Cursor = Cursors.WaitCursor
        'Try

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    'While Not MyReader.EndOfData
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then
                        ' Get the record index
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        acquisitiontype = 6
                        h = txtObsHour.Text
                        'cod = txtElmCode.Text
                        cod = cboElement.SelectedValue

                        For Each currentField In currentRow
                            Try
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
                                                cprd = d
                                                dttime = y & "-" & hd & "-" & d & " " & h & ":00"

                                                ' Check for missing flag data values 
                                                If dat = txtMissingFlag.Text Then
                                                    If dat = "" Then Continue For 'Blanks to be skipped
                                                    If Station_Element(st, cod) Then
                                                        If IsDate(dttime) Then
                                                            If Not Add_Record(st, cod, dttime, "", "M", acquisitiontype) Then Exit For
                                                            lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                            lblRecords.Refresh()
                                                            col = col + 1
                                                        End If
                                                    Else
                                                        If Not ImportFile Then Exit Sub
                                                    End If

                                                    Continue For
                                                End If

                                                'cprd = d
                                                flg = "C"

                                                If IsNumeric(dat) Then
                                                    'prd = 0 ' initialize data period counter
                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)
                                                Else
                                                    Get_Value_Flag(cod, dat, flg)
                                                End If

                                                If Station_Element(st, cod) Then
                                                    If IsDate(dttime) Then If Not Add_Record(st, cod, dttime, dat, flg, acquisitiontype) Then Exit For 'Sub
                                                Else
                                                    If Not ImportFile Then Exit Sub
                                                End If

                                            End If

                                        End If
                                        ' Show upload progress
                                        lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                        lblRecords.Refresh()
                                        col = col + 1
                                    End If
                                End With
                            Catch x As Exception
                                Continue For
                            End Try
                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop

            End Using

        'Catch ex As Exception
        'If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = vbCancel Then Exit Sub
        'End Try
    End Sub

    Sub load_UpperAir()
        'MsgBox(1)
        Dim st, cod, y, m, d, h, n, s, dt_tm, dat, dttcom, flg, lvl As String
        Dim acquisitiontype As Integer

        'Try
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()

                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        dt_tm = txtDatetime.Text
                        lvl = ""
                        If Not Get_DateTime(currentRow, dt_tm, lvl) Then Continue Do

                        'Compute date and time according to sql structure
                        y = DateAndTime.Year(dt_tm)
                        m = DateAndTime.Month(dt_tm)
                        d = DateAndTime.Day(dt_tm)
                        h = DateAndTime.Hour(dt_tm)
                        n = DateAndTime.Minute(dt_tm)
                        s = DateAndTime.Second(dt_tm)

                        dt_tm = y & "-" & m & "-" & d & " " & h & ":" & n & ":" & s
                        'MsgBox(dt_tm & " " & lvl)

                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        acquisitiontype = 6
                        dttcom = 0
                        col = 0

                        For Each currentField In currentRow
                            Try
                                cod = DataGridView1.Columns(col).Name
                                dat = currentField
                                With DataGridView1
                                    If col < .ColumnCount Then
                                        If .Columns(col).Name = "station_id" Then ' Station column found
                                            st = dat
                                        ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                            'Column labeled NA will be skipped
                                        ElseIf .Columns(col).Name = "level" Then
                                            'Level already computed
                                        ElseIf .Columns(col).Name = "time_disp" Then
                                            'Time displacement already compute
                                        Else

                                            ' Data column follows

                                            ' Check for missing flag data values 
                                            If dat = txtMissingFlag.Text Then
                                                If dat = "" Then Continue For 'Blanks to be skipped
                                                If Station_Element(st, cod) Then Add_Record(st, cod, dt_tm, "", "M", acquisitiontype, lvl)
                                                lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text ' & " " & '.RowCount - Val(txtStartRow.Text) '1
                                                lblRecords.Refresh()
                                                col = col + 1
                                                'End If
                                                Continue For
                                            End If

                                            flg = ""
                                            prd = 0

                                            If IsNumeric(dat) Then
                                                'prd = 0
                                                If chkScale.Checked = True Then Scale_Data(cod, dat)
                                            Else
                                                Get_Value_Flag(cod, dat, flg)
                                            End If

                                            If Station_Element(st, cod) Then
                                                Add_Record(st, cod, dt_tm, dat, flg, acquisitiontype, lvl)
                                            Else
                                                If Not ImportFile Then Exit Sub
                                            End If
                                        End If
                                    End If
                                End With

                                ' Show upload progress
                                lblRecords.Text = ClsTranslations.GetTranslation("Loading: ") & MyReader.LineNumber - 1 & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                lblRecords.Refresh()
                                col = col + 1
                            Catch x As Exception
                                Continue For
                            End Try
                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using

        'Catch ex As Exception
        '    MsgBox(ex.HResult & " " & ex.Message)
        'End Try

    End Sub
    Sub List_NOAAGTSFields()

        Try

            cmbFields.Items.Clear()
            ' Add station, date and time headers whichever exist
            cmbFields.Items.Add("station_id")
            cmbFields.Items.Add("date")
            cmbFields.Items.Add("date_time")
            'cmbFields.Items.Add("value")
            cmbFields.Items.Add("NA")
            ' Add the AWS element codes existing in obselement table

            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            sql = "select elementId, abbreviation from obselement where selected = 1;" 'elementId < 881 ;"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
    Sub Load_NOAAGTS()
        'MsgBox("Aws")
        Dim st, cod, dttim, y, m, d, h, tt, dt, dat, hd, flg As String
        Dim dt_tm As Boolean
        Dim acquisitiontype As Integer

        'Try
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtImportFile.Text)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(delimit)

                Do While MyReader.EndOfData = False
                Try
                    currentRow = MyReader.ReadFields()
                    If MyReader.LineNumber > Val(txtStartRow.Text) Then

                        ' Initialize values
                        col = 0
                        'st = txtStn.Text
                        st = cboStns.SelectedValue
                        acquisitiontype = 3
                        dt_tm = False
                        dt = ""
                        dttim = ""
                        h = txtObsHour.Text

                        For Each currentField In currentRow
                            Try
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
                                        ElseIf .Columns(col).Name = "NA" Then ' Not Required
                                            'Do nothing
                                        Else ' Data Column found
                                            cod = .Columns(col).Name
                                            '    dat = .Rows(i).Cells(j).Value
                                            If dt_tm = False Then dttim = dt & " " & h & ":00"

                                            dttim = DateAndTime.Year(dttim) & "-" & DateAndTime.Month(dttim) & "-" & DateAndTime.Day(dttim) & " " & Format(DateAndTime.Hour(dttim), "00") & ":" & Format(DateAndTime.Minute(dttim), "00") & ":" & Format(DateAndTime.Second(dttim), "00")

                                            If IsDate(dttim) Then

                                                ' Check for missing flag data values 
                                                If NOAA_MissingData(dat) Then
                                                    col = col + 1
                                                    Continue For
                                                End If

                                                'flg = ""
                                                If IsNumeric(dat) Then
                                                    ' Units coversions
                                                    If cod = 1 Or cod = 2 Or cod = 3 Or cod = 4 Or cod = 14 Or cod = 101 Or cod = 102 Or cod = 103 Then ' Temperatures - Fahreheit to Celsius
                                                        dat = 5 / 9 * (Val(dat) - 32)
                                                    ElseIf cod = 5 Or cod = 50 Then ' Precipitation/Snow Depth - inches to mm
                                                        dat = Val(dat) * 25.4
                                                    ElseIf cod = 110 Then ' Visibility - Miles to Metres
                                                        dat = Val(dat) * 1609.34
                                                    ElseIf cod = 56 Or cod = 57 Or cod = 58 Or cod = 60 Or cod = 111 Then ' Wind Speed - Knots to M/s
                                                        dat = Val(dat) * 0.514444
                                                    End If

                                                    If chkScale.Checked = True Then Scale_Data(cod, dat)

                                                End If

                                                If Station_Element(st, cod) Then
                                                    Add_Record(st, cod, dttim, dat, flg, acquisitiontype)
                                                Else
                                                    If Not ImportFile Then Exit Sub
                                                End If
                                            End If
                                        End If
                                    End If
                                End With

                                col = col + 1
                                ' Show upload progress
                                lblRecords.Text = "Loading: " & MyReader.LineNumber - 1 & " of " & lblTRecords.Text '.RowCount - Val(txtStartRow.Text) '1
                                lblRecords.Refresh()
                            Catch x As Exception
                                Continue For
                            End Try
                        Next
                    End If
                Catch ex As Exception
                    Continue Do
                End Try
            Loop
            End Using
        'Catch ex As Exception
        '    MsgBox(ex.HResult & " " & ex.Message)
        'End Try
    End Sub

    Function NOAA_MissingData(flg As String) As Boolean
        Try
            If flg = 999999 Or flg = 9999.9 Or flg = 999.9 Or flg = 99.99 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function Get_DateTime(datRow() As String, ByRef dtt As Date, ByRef lvl As String) As Boolean
        Dim datValue As String
        Dim itm As Integer
        Dim displ As Double
        Try
            itm = 0
            For Each datValue In datRow
                If DataGridView1.Columns(itm).Name = "time_disp" Then
                    displ = Math.Round(CDbl(datValue), 0)
                    dtt = DateAdd("s", displ, dtt)
                ElseIf DataGridView1.Columns(itm).Name = "level" Then
                    lvl = datValue
                End If
                itm = itm + 1
            Next

            Return True
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try

    End Function

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

                    'If Strings.UCase(flgchr) = "T" And Strings.Left(dat, 1) = "0" Then
                    '    'MsgBox(dat)
                    '    dat = "0"
                    '    flg = "T"
                    'End If

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
                'stn = txtStn.Text
                stn = cboStns.SelectedValue
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
            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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


    Function Add_Record(stn As String, code As String, datetime As String, obsVal As String, flg As String, acqTyp As Integer, Optional levels As String = "surface") As Boolean
        Dim dat, qcStatus, qcLog As String

        'If obsVal = "" Then Exit Function
        Try
            If chkAdjustHH.Checked And Val(txtHH.Text) <> 0 Then
                datetime = DateAdd("h", CInt(txtHH.Text), datetime)
                datetime = DateAndTime.Year(datetime) & "-" & DateAndTime.Month(datetime) & "-" & DateAndTime.Day(datetime) & " " & DateAndTime.Hour(datetime) & ":" & DateAndTime.Minute(datetime) & ":" & DateAndTime.Second(datetime)
            End If

            'If Val(cprd) < 1 Then cprd = "\N" ' No cummulative values
            If Val(cprd) < 1 Then cprd = "" ' No cummulative values

            If rbtnFinal.Checked Then ' Set for upload to observationfinal table
                qcStatus = 1
                qcLog = 1
            Else ' Set for upload to observationinitial table
                qcStatus = 0
                'qcLog = "\N"
                qcLog = ""
                'dat = stn & "," & code & "," & datetime & "," & levels & "," & obsVal & "," & flg & "," & cprd & "," & acqTyp
            End If

            'dat = stn & "," & code & "," & datetime & "," & levels & "," & obsVal & "," & flg & "," & cprd & "," & qcStatus & "," & qcLog & "," & acqTyp
            dat = stn & "," & code & "," & datetime & "," & levels & "," & obsVal & "," & flg & "," & cprd & "," & qcStatus & "," & qcLog & "," & acqTyp & ",,,,,,,,"

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
    Function Add_Record_NOAGTS(stn As String, code As String, datetime As String, obsVal As String, flg As String, acqTyp As Integer, Optional levels As String = "surface") As Boolean
        Dim dat As String

        Try
            If chkAdjustHH.Checked And Val(txtHH.Text) <> 0 Then
                datetime = DateAdd("h", CInt(txtHH.Text), datetime)
                datetime = DateAndTime.Year(datetime) & "-" & DateAndTime.Month(datetime) & "-" & DateAndTime.Day(datetime) & " " & DateAndTime.Hour(datetime) & ":" & DateAndTime.Minute(datetime) & ":" & DateAndTime.Second(datetime)
            End If

            If rbtnFinal.Checked Then
                dat = stn & "," & code & "," & datetime & "," & levels & "," & obsVal & "," & flg & ",1," & acqTyp
            Else
                dat = stn & "," & code & "," & datetime & "," & levels & "," & obsVal & "," & flg & ",0," & acqTyp
            End If

            Print(101, dat)
            PrintLine(101)

            Return True
        Catch ex As Exception
            'dbcon.Close()

            If ex.HResult <> -2147024882 And ex.HResult <> -2146232969 And ex.HResult <> -2146233079 Then
                'If MsgBox(ex.HResult & " " & ex.Message, MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Return False
            End If
            Return False
        End Try

    End Function
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
            'sql = "select elementId, elementScale from obselement where elementId like '" & Int(code) & "';"
            sql = "select elementId, elementScale from obselement where elementId = '" & code & "';"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            If ds1.Tables("obselement").Rows.Count = 0 Then Exit Sub

            If Not IsDBNull(ds1.Tables("obselement").Rows(0).Item("elementScale")) Then
                scales = Val(ds1.Tables("obselement").Rows(0).Item("elementScale"))
                If scales > 0 Then obsv = Math.Round(Val(obsv) / scales, 0)
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdSaveErrors_Click(sender As Object, e As EventArgs)
        Dim errfile As String
        Try
            dlgSaveSchema.Filter = ClsTranslations.GetTranslation("Errors file|*.txt")
            dlgSaveSchema.Title = ClsTranslations.GetTranslation("Upload Errors")
            dlgSaveSchema.ShowDialog()

            errfile = dlgSaveSchema.FileName
            FileOpen(111, errfile, OpenMode.Output)

            If lstStations.Items.Count Then
                PrintLine(111, ClsTranslations.GetTranslation("Station Errors"))
                For i = 0 To lstStations.Items.Count - 1
                    PrintLine(111, lstStations.Items(i))
                Next
            End If
            PrintLine(111)

            If lstElements.Items.Count Then
                PrintLine(111, ClsTranslations.GetTranslation("Elements Errors"))
                For i = 0 To lstElements.Items.Count - 1
                    PrintLine(111, lstElements.Items(i))
                Next
            End If
            FileClose(111)

        Catch ex As Exception
            FileClose(111)
        End Try

    End Sub

    Private Sub chkUpperAir_CheckedChanged(sender As Object, e As EventArgs) Handles chkUpperAir.CheckedChanged
        If chkUpperAir.Checked Then
            List_UpperAirFields()
            grpLaunched.Visible = True
        Else
            List_ObsFields()
            grpLaunched.Visible = False
        End If
    End Sub

    Private Sub chkUTC_CheckedChanged(sender As Object, e As EventArgs) Handles chkUTC.CheckedChanged
        If chkUTC.Checked Then
            txtTdiff.Visible = True
            lblDiff.Visible = True
        Else
            txtTdiff.Visible = False
            lblDiff.Visible = False
        End If
    End Sub

    Function Station_Element(stn_id As String, elm_code As String) As Boolean
        Dim stn, elm, itm As Boolean

        stn = True
        elm = True
        Station_Element = True
        Try
            'Check If Station exist
            sql = "select stationId from station where stationId like '" & stn_id & "';"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
                'ImportFile = False
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            'MsgBox("Missing Metadata")
            'ImportFile = False
            Return False
        End Try

    End Function



    Function Get_Code_Scale(code As String, ByRef obsv As String) As Boolean
        'MsgBox(code & " " & obsv)
        Dim scales As Decimal
        Try

            Get_Code_Scale = True

            'sql = "SELECT * FROM " & "obselement"
            sql = "select elementId, elementScale from obselement where elementId like " & Val(code) & ";"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
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
    Function QC_DataErr(code As String, obsv As String, ByRef Limittype As String) As Boolean

        Try

            If Not IsNumeric(obsv) Then Return False


            sql = "select elementScale,lowerLimit,upperLimit from obselement where elementId like " & Val(code) & ";"

            da1 = New MySqlConnector.MySqlDataAdapter(sql, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "obselement")

            With ds1.Tables("obselement")

                If ds1.Tables("obselement").Rows.Count = 0 Then
                    ' No Element found
                    Limittype = code & "," & Now() & "," & obsv & "," & "Element Not in Metadata"
                    Return True
                Else
                    If IsNumeric(.Rows(0).Item("lowerLimit")) And IsNumeric(.Rows(0).Item("upperLimit")) And IsNumeric(.Rows(0).Item("upperLimit")) And IsNumeric(.Rows(0).Item("upperLimit")) Then
                        obsv = obsv / Val(.Rows(0).Item("elementScale"))
                        If obsv < Val(.Rows(0).Item("lowerLimit")) Then
                            ' Lower Limit Error
                            Limittype = "lowerLimit"
                            Return True
                        ElseIf obsv > Val(.Rows(0).Item("upperLimit")) Then
                            '  Upper Limit Error
                            Limittype = "upperLimit"
                            Return True
                        End If
                    Else
                        ' Limit or Scale value missing
                        Limittype = "Limit or Scale value missing"
                        Return True
                    End If
                End If
            End With
            Return False
        Catch ex As Exception
            ' Unknown data error
            MsgBox(ex.Message)
            Limittype = "Unknown data error"
            Return True
        End Try

    End Function
    Private Sub cmdSaveSpecs_Click(sender As Object, e As EventArgs) Handles cmdSaveSpecs.Click
        Dim hdr, schemafile, dlt, strw, obshr, scal, id, code, flg, adjust As String
        'Dim configFilename As String = Application.StartupPath & "\schema.sch"
        Try
            dlgSaveSchema.Filter = ClsTranslations.GetTranslation("Schema file|*.sch")
            dlgSaveSchema.Title = ClsTranslations.GetTranslation("Save Schema")
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
            'id = txtStn.Text
            id = cboStns.SelectedValue
            'code = txtElmCode.Text
            code = cboElement.SelectedValue
            flg = txtMissingFlag.Text
            adjust = txtHH.Text
            PrintLine(100, dlt & "," & strw & "," & obshr & "," & scal & "," & id & "," & code & "," & flg & "," & adjust)
            lblSpecs.Text = schemafile
        Catch ex As Exception
            FileClose(100)
        End Try
        FileClose(100)
    End Sub

    Private Sub cmdLoadSpecs_Click(sender As Object, e As EventArgs) Handles cmdLoadSpecs.Click
        Dim sch, hdr() As String
        Dim Recs As New dataEntryGlobalRoutines
        dlgOpenImportFile.Filter = "Schema Files|*.sch;*.*"
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
                    MsgBox(ClsTranslations.GetTranslation("Header Specs don't match data columms. Selected specs file not loaded"))
                    lblSpecs.Text = ""
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
                    'txtStn.Text = hdr(4)
                    cboStns.Text = hdr(4)
                    Recs.Valid_Stn(cboStns)
                    'txtElmCode.Text = hdr(5)
                    cboElement.Text = hdr(5)
                    Recs.Valid_Elm(cboElement)
                    ' The following code added to cater for the added object for missing data flag text box
                    If hdr.Count > 6 Then
                        txtMissingFlag.Text = hdr(6)
                    Else
                        txtMissingFlag.Text = ""
                    End If
                    txtHH.Text = hdr(7)
                End If
            End Using
            lblSpecs.Text = sch
            cmdLoadData.Enabled = True
        Catch ex As Exception
            If ex.HResult <> -2147467261 Then MsgBox(ex.Message)
            lblSpecs.Text = ""
            cmdLoadData.Enabled = False
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

    Private Sub rbtnFinal_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnFinal.CheckedChanged
        If rbtnFinal.Checked = True Then
            chkScale.Checked = False
            chkScale.Enabled = False
            'chkScale.Checked = True
        Else
            chkScale.Checked = True
            chkScale.Enabled = True
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSaveErrors_Click_1(sender As Object, e As EventArgs) Handles cmdSaveErrors.Click
        Dim flerr As String
        ' Save Stations errors
        With lstStations.Items
            If .Count > 0 Then
                flerr = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\stationsErrors.csv"
                FileOpen(15, flerr, OpenMode.Output)

                For i = 0 To .Count - 1
                    PrintLine(15, .Item(i))
                Next
                FileClose(15)
                lblStnErr.Text = "Stations Errors Saved in '" & flerr & "'"
            End If
        End With

        ' Save Element errors
        With lstElements.Items
            If .Count > 0 Then
                flerr = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\ElementsErrors.csv"
                FileOpen(15, flerr, OpenMode.Output)

                For i = 0 To .Count - 1
                    PrintLine(15, .Item(i))
                Next
                FileClose(15)
                lblElmErr.Text = "Elements Errors Saved in '" & flerr & "'"
            End If
        End With
    End Sub

    Private Sub txtMissingFlag_TextChanged(sender As Object, e As EventArgs) Handles txtMissingFlag.TextChanged

    End Sub

    Private Sub lblMissingFlag_Click(sender As Object, e As EventArgs) Handles lblMissingFlag.Click

    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Select Case _enumImportType
            Case ImportType.Hourly, ImportType.Daily, ImportType.MultipleElements
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#DailyHourly")
            Case ImportType.ClicomHourly, ImportType.ClicomDaily, ImportType.ClicomSynop
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "clicom.htm")
            Case ImportType.AWSData
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "aws.htm")
            Case Else
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "textfileimport.htm#procedures")
        End Select
    End Sub

    Private Sub chkAdjustHH_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdjustHH.CheckedChanged
        If chkAdjustHH.Checked Then
            txtHH.Visible = True
        Else
            txtHH.Visible = False
        End If

    End Sub

    Private Sub txtOther_GotFocus(sender As Object, e As EventArgs) Handles txtOther.GotFocus
        OptOthers.Checked = True
    End Sub

    Private Sub frmImportDaily_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Len(recCommit.RegkeyValue("key01")) <> 0 Then txtObsHour.Text = recCommit.RegkeyValue("key01")



        ClsTranslations.TranslateForm(Me)

        Dim ds1, ds2 As New DataSet
        Dim sql1 As String
        Dim da1, da11 As MySqlConnector.MySqlDataAdapter
        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConnectionString
            dbcon.Open()

            ' Populate Stations
            sql1 = "SELECT stationId,stationName FROM station"
            da1 = New MySqlConnector.MySqlDataAdapter(sql1, dbcon)
            ds1.Clear()
            da1.Fill(ds1, "station")

            If ds1.Tables("station").Rows.Count > 0 Then
                With cboStns
                    .DataSource = ds1.Tables("station")
                    .DisplayMember = "stationName"
                    .ValueMember = "stationId"
                    .SelectedIndex = -1
                End With
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If

            ' Populate elements
            sql1 = "SELECT elementId,elementName FROM obselement"
            da11 = New MySqlConnector.MySqlDataAdapter(sql1, dbcon)
            ds2.Clear()
            da11.Fill(ds2, "element")

            If ds2.Tables("element").Rows.Count > 0 Then
                With cboElement
                    .DataSource = ds2.Tables("element")
                    .DisplayMember = "elementName"
                    .ValueMember = "elementId"
                    .SelectedIndex = -1
                End With
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If
            dbcon.Close()
        Catch ex As Exception
            dbcon.Close()
        End Try
    End Sub

    Function UTC_Convert(dttime As String) As String
        Dim UTC_dt As String
        Try

            UTC_dt = DateAdd("h", -1 * Val(txtTdiff.Text), dttime)
            UTC_dt = DateAndTime.Year(UTC_dt) & "-" & DateAndTime.Month(UTC_dt) & "-" & DateAndTime.Day(UTC_dt) & " " & DateAndTime.Hour(UTC_dt) & ":" & DateAndTime.Minute(UTC_dt) & ":" & DateAndTime.Second(UTC_dt)
            Return UTC_dt
        Catch ex As Exception
            Return dttime
        End Try
    End Function

    Private Sub txtStns_KeyDown(sender As Object, e As KeyEventArgs) Handles cboStns.KeyDown
        Dim Recs As New dataEntryGlobalRoutines

        If e.KeyValue = 13 Then
            'MsgBox(txtStns.SelectedValue)
            'txtStns.Text = txtStns.SelectedValue
            Recs.Valid_Stn(cboStns)
        End If
    End Sub

    Private Sub txtStns_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboStns.SelectedValueChanged
        'Try
        '    'MsgBox(txtStns.SelectedValue)
        '    txtStns.Text = txtStns.SelectedValue
        'Catch ex As Exception

        'End Try
    End Sub

    'Private Sub txtStns_TextChanged(sender As Object, e As EventArgs) Handles txtStns.TextChanged
    '    Try

    '        txtStns.Text = txtStns.SelectedValue
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub txtStns_Click(sender As Object, e As EventArgs) Handles cboStns.Click
        'Try

        '    txtStns.Text = txtStns.SelectedValue
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cboElement_KeyDown(sender As Object, e As KeyEventArgs) Handles cboElement.KeyDown
        Dim Recs As New dataEntryGlobalRoutines

        If e.KeyValue = 13 Then
            Recs.Valid_Elm(cboElement)
        End If
    End Sub

    Private Sub lblSpecs_TextChanged(sender As Object, e As EventArgs) Handles lblSpecs.TextChanged
        If Len(lblSpecs.Text) > 0 Then
            cmdLoadData.Enabled = True
        Else
            cmdLoadData.Enabled = False
        End If
    End Sub

    Function LoadingCount(ln As Long) As String
        Try
            Return ClsTranslations.GetTranslation("Loading: ") & ln - Val(txtStartRow.Text) & ClsTranslations.GetTranslation(" of ") & lblTRecords.Text
        Catch ex As Exception
            Return ""
        End Try
    End Function
    'Private Sub txtStns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtStns.SelectedIndexChanged
    '    Try
    '        MsgBox(txtStns.SelectedValue)
    '        txtStns.Text = ""
    '        'txtStns.Text = txtStns.SelectedValue
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class