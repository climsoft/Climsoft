
Public Class frmMonitoring
    Public ds As New DataSet
    Public da As MySql.Data.MySqlClient.MySqlDataAdapter
    Public conn As New MySql.Data.MySqlClient.MySqlConnection
    Public constr, sql As String
    Public kount As Long
    Public qwry As MySql.Data.MySqlClient.MySqlCommand

    Private Sub optUsers_CheckedChanged(sender As Object, e As EventArgs) Handles optUsers.CheckedChanged
        If optUsers.Checked Then
            cboUser.Enabled = True
        Else
            cboUser.Enabled = False
        End If
    End Sub

    Private Sub frmMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim kount As Long
        constr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = constr

        Try
            ' Get Users
            sql = "Select * from climsoftusers;"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Users")
            'conn.Close()
            For kount = 0 To ds.Tables("Users").Rows.Count - 1
                cboUser.Items.Add(ds.Tables("Users").Rows(kount).Item(0))
            Next
            cboUser.Items.Add("root")
            cboUser.Refresh()

            ' Get Key Entry forms
            sql = "Select * from data_forms where selected =1;"
            'conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "KeyEntryForms")

            For kount = 0 To ds.Tables("KeyEntryForms").Rows.Count - 1
                cboForms.Items.Add(ds.Tables("KeyEntryForms").Rows(kount).Item(2))
            Next
            cboForms.Refresh()
            ' Table for Users records
            'sql = "Drop TABLE IF EXISTS `UserRecords`; " & _

            sql = "CREATE TABLE IF NOT EXISTS `userrecords` ( " &
                  "`username` varchar(255) NOT NULL DEFAULT '', " &
                  "`recsdone` int(11) DEFAULT NULL, " &
                  "`recsexpt` int(11) DEFAULT NULL, " &
                  "`perform` int(11) DEFAULT NULL, " &
                  "PRIMARY KEY (`username`));"

            qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qwry.CommandTimeout = 0
            qwry.ExecuteNonQuery()

            ' Populate the table with users
            sql = "INSERT IGNORE INTO userrecords ( userName ) SELECT climsoftusers.userName FROM climsoftusers;"
            qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qwry.CommandTimeout = 0
            qwry.ExecuteNonQuery()

            ' Add root user
            sql = "INSERT IGNORE INTO `userrecords` (`username`) VALUES ('root');"
            qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qwry.CommandTimeout = 0
            qwry.ExecuteNonQuery()
            conn.Close()

            ClsTranslations.TranslateForm(Me)

        Catch ex As Exception
            conn.Close()
            If ex.HResult = -2147467259 Then
                Me.Close()
            Else
                MsgBox(ex.Message & " at frmMonitoring Load")
            End If
        End Try
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        Dim dts, dte As String

        Me.Cursor = Cursors.WaitCursor
        listViewRecs.Clear()
        lblTrecs.Text = 0

        dts = DateAndTime.Year(dtpStartDate.Text) & "-" & DateAndTime.Month(dtpStartDate.Text) & "-" & DateAndTime.Day(dtpStartDate.Text) & " 00:00:00"
        dte = DateAndTime.Year(dtpEndDate.Text) & "-" & DateAndTime.Month(dtpEndDate.Text) & "-" & DateAndTime.Day(dtpEndDate.Text) & " 23:59:59"
        Dim Rec(6) As String

        Try
            'Initialize List View

            listViewRecs.Clear()
            listViewRecs.Columns.Clear()
            listViewRecs.Columns.Add("Login", 120, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Station", 80, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Year", 60, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Month/Code", 80, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Form", 150, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Entry DateTime", 200, HorizontalAlignment.Left)

            For i = 0 To cboForms.Items.Count - 1

                If optUsers.Checked Then
                    sql = "SELECT signature as Login, stationId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                         "GROUP BY signature, stationId, yyyy, mm, entryDatetime " &
                        "HAVING signature= '" & cboUser.Text & "' AND entryDatetime Between '" & dts & "' And '" & dte & "' " &
                        "ORDER BY entryDatetime;"

                    '' form_daily2 handled separately so as to include Element Id
                    'If cboForms.Items(i) = "form_daily2" Then
                    '    sql = "SELECT signature as Login, stationId, elementId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                    '     "GROUP BY signature, stationId, yyyy, mm, entryDatetime " &
                    '    "HAVING signature= '" & cboUser.Text & "' AND entryDatetime Between '" & dts & "' And '" & dte & "' " &
                    '    "ORDER BY entryDatetime;"
                    'End If

                    ' form_monthly is a pecial case since it has no mm field
                    If cboForms.Items(i) = "form_monthly" Then
                        sql = "SELECT signature as Login, stationId, yyyy as Year, elementId as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                             "GROUP BY signature, stationId, yyyy, entryDatetime " &
                            "HAVING signature= '" & cboUser.Text & "' AND entryDatetime Between '" & dts & "' And '" & dte & "' " &
                            "ORDER BY entryDatetime;"
                    End If

                Else
                    cboUser.Text = ""
                    sql = "SELECT signature as Login, stationId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                       "GROUP BY signature, stationId, yyyy, mm, entryDatetime " &
                       "HAVING entryDatetime Between '" & dts & "' And '" & dte & "' " &
                       "ORDER BY entryDatetime;"

                    '' form_monthly is a pecial case since it has no mm field
                    'If cboForms.Items(i) = "form_daily2" Then
                    '    sql = "SELECT signature as Login, stationId, elementId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                    '   "GROUP BY signature, stationId, yyyy, mm, entryDatetime " &
                    '   "HAVING entryDatetime Between '" & dts & "' And '" & dte & "' " &
                    '   "ORDER BY entryDatetime;"
                    'End If

                    ' form_monthly is a pecial case since it has no mm field
                    If cboForms.Items(i) = "form_monthly" Then
                        sql = "SELECT signature as Login, stationId, yyyy as Year, elementId as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                       "GROUP BY signature, stationId, yyyy, entryDatetime " &
                       "HAVING entryDatetime Between '" & dts & "' And '" & dte & "' " &
                       "ORDER BY entryDatetime;"
                    End If

                End If

                conn.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "Records")
                conn.Close()

                For kount = 0 To ds.Tables("Records").Rows.Count - 1
                    Rec(0) = ds.Tables("Records").Rows(kount).Item("Login")
                    Rec(1) = ds.Tables("Records").Rows(kount).Item("StationID")
                    Rec(2) = ds.Tables("Records").Rows(kount).Item("Year")
                    Rec(3) = ds.Tables("Records").Rows(kount).Item("Month")
                    Rec(4) = cboForms.Items(i)
                    Rec(5) = ds.Tables("Records").Rows(kount).Item("Entry_DateTime")

                    Dim itms = New ListViewItem(Rec)
                    listViewRecs.Items.Add(itms)
                Next kount
            Next i

            lblTrecs.Text = listViewRecs.Items.Count
            lblTrecs.Refresh()
            If Val(lblTrecs.Text) > 0 Then
                cmdSave2.Enabled = True
            Else
                cmdSave2.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Private Sub cmdRetrieve_Click(sender As Object, e As EventArgs) Handles cmdRetrieve.Click
        Dim dtf, dtt As String
        Dim kt As Long

        Me.Cursor = Cursors.WaitCursor
        listViewRecs.Clear()
        lblTrecs.Text = 0

        dtf = DateAndTime.Year(dtpFrom.Text) & "-" & DateAndTime.Month(dtpFrom.Text) & "-" & DateAndTime.Day(dtpFrom.Text) & " 00:00:00"
        dtt = DateAndTime.Year(dtpTo.Text) & "-" & DateAndTime.Month(dtpTo.Text) & "-" & DateAndTime.Day(dtpTo.Text) & " 23:59:59"

        Try
            kt = 0
            conn.Open()
            For i = 0 To cboUser.Items.Count - 1
                kount = 0
                For k = 0 To cboForms.Items.Count - 1

                    If OptMonthly.Checked Then
                        sql = "SELECT signature, entryDatetime FROM " & cboForms.Items(k) & " WHERE month(entryDatetime) = '" & cboMonth.Text & "' and year(entryDatetime) = '" & txtYear.Text & "';"
                    Else
                        sql = "SELECT signature, entryDatetime FROM " & cboForms.Items(k) & " WHERE entryDatetime Between '" & dtf & "' and '" & dtt & "';"
                    End If

                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                    da.SelectCommand.CommandTimeout = 0
                    ds.Clear()
                    da.Fill(ds, "UserRecords")

                    'MsgBox(ds.Tables("UserRecords").Rows.Count)
                    For j = 0 To ds.Tables("UserRecords").Rows.Count - 1
                        'MsgBox(ds.Tables("UserRecords").Rows(j).Item(0))
                        If Not IsDBNull(ds.Tables("UserRecords").Rows(j).Item(0)) Then
                            If ds.Tables("UserRecords").Rows(j).Item(0) = cboUser.Items(i) Then
                                kount = kount + 1
                            End If
                        End If
                    Next j
                Next k
                kt = kt + kount
                'MsgBox(kt)
                ' Update user record
                sql = "UPDATE userrecords set recsdone = " & kount & " where username ='" & cboUser.Items(i) & "';"
                qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qwry.CommandTimeout = 0
                qwry.ExecuteNonQuery()
            Next i
            lblTrecs.Text = kt 'kount()
            conn.Close()
        Catch x As Exception
            MsgBox(x.Message)
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try

        Dim Rec(4) As String

        Try
            ' Initialize List View

            listViewRecs.Clear()
            listViewRecs.Columns.Clear()
            listViewRecs.Columns.Add("User", 120, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Records", 100, HorizontalAlignment.Right)
            listViewRecs.Columns.Add("Target", 100, HorizontalAlignment.Right)
            listViewRecs.Columns.Add("Performance % ", 150, HorizontalAlignment.Right)

            'sql = "Select * from userrecords"
            sql = "SELECT username as Login, recsdone as Records,recsexpt as Target, round(recsdone/recsexpt * 100, 1) as performance FROM userrecords WHERE recsexpt IS NOT NULL;"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Performs")
            conn.Close()
            For i = 0 To ds.Tables("Performs").Rows.Count - 1
                If IsDBNull(ds.Tables("Performs").Rows(i).Item(0)) Or IsDBNull(ds.Tables("Performs").Rows(i).Item(1)) Or IsDBNull(ds.Tables("Performs").Rows(i).Item(2)) Or IsDBNull(ds.Tables("Performs").Rows(i).Item(3)) Then Continue For

                Rec(0) = ds.Tables("Performs").Rows(i).Item(0)
                Rec(1) = ds.Tables("Performs").Rows(i).Item(1)

                ' Get the target value if is set
                Rec(2) = ds.Tables("Performs").Rows(i).Item(2)
                Rec(3) = ds.Tables("Performs").Rows(i).Item(3)
                'Else
                'Continue For
                'MsgBox("Target value not set. Please check the Settings")
                ''Exit For
                'End If
                'If Not IsDBNull(ds.Tables("Performs").Rows(i).Item(3)) Then Rec(3) = ds.Tables("Performs").Rows(i).Item(3)

                'perf = (ds.Tables("Records").Rows(i).Item(1) / ds.Tables("Records").Rows(i).Item(2)) * 100
                'Rec(3) = Format(perf, "0.0") 'ds.Tables("Records").Rows(i).Item(3)

                Dim itms = New ListViewItem(Rec)
                listViewRecs.Items.Add(itms)
            Next i

            lblTrecs.Text = ds.Tables("Performs").Rows.Count
            Me.Cursor = Cursors.Default
        Catch x As Exception
            MsgBox(x.Message & " at cmdRetrieve Click")
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cmdSave1_Click(sender As Object, e As EventArgs) Handles cmdSave1.Click
        Dim fl, datarow, datahdr As String
        Me.Cursor = Cursors.WaitCursor

        Try
            ' Create output path if it is not there
            If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data") Then
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data")
            End If

            ' Open output file
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Performance.csv"
            FileOpen(11, fl, OpenMode.Output)

            ' Print Header Rows
            PrintLine(11, "Performance Report")

            If OptMonthly.Checked Then
                datahdr = "Period: " & MonthName(Val(cboMonth.Text)) & "   " & txtYear.Text
            Else
                datahdr = "Period: From  " & dtpFrom.Text & "  To  " & dtpTo.Text
            End If

            PrintLine(11, datahdr)

            datahdr = ds.Tables("Performs").Columns(0).ColumnName
            For k = 1 To ds.Tables("Performs").Columns.Count - 1
                datahdr = datahdr & "," & ds.Tables("Performs").Columns(k).ColumnName
            Next
            PrintLine(11, datahdr)

            ' Output data records
            For i = 0 To ds.Tables("Performs").Rows.Count - 1
                datarow = ds.Tables("Performs").Rows(i).Item(0)
                For j = 1 To ds.Tables("Performs").Columns.Count - 1
                    datarow = datarow & "," & ds.Tables("Performs").Rows(i).Item(j)
                Next j
                PrintLine(11, datarow)
            Next i
            FileClose(11)
            If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdretrieve1_Click(sender As Object, e As EventArgs) Handles cmdretrieve1.Click
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        Me.Cursor = Cursors.WaitCursor

        Try
            conn.Open()
            ' Add a record for key entry mode if not exists
            sql = "ALTER TABLE `data_forms` ADD COLUMN `entry_mode` TINYINT(2) NOT NULL DEFAULT '0' AFTER `sequencer`;"
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'Existing record
                MsgBox(ex.HResult & " " & ex.Message)
            End If
        End Try

        ' Add a record for users entry status if not exists
        Try
            sql = "ALTER TABLE `climsoftusers` ADD COLUMN `entry_status` TINYINT(2) NOT NULL DEFAULT '0' AFTER `userRole`;"
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()
        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'Existing record
                MsgBox(ex.HResult & " " & ex.Message)
            End If
        End Try

        listViewRecs.Clear()
        lblTrecs.Text = 0

        Try
            If optTargets.Checked Then
                sql = "SELECT username as User,recsexpt as Target_Records FROM userrecords;"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "settings")
                dataGridSettings.DataSource = ds.Tables("settings")
                dataGridSettings.Refresh()
            ElseIf optEntryMode.Checked Then
                sql = "SELECT form_name,description, entry_mode FROM data_forms where selected ='1';"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "forms")
                dataGridSettings.DataSource = ds.Tables("forms")
                dataGridSettings.Refresh()
            ElseIf optUsersStatus.Checked Then
                sql = "SELECT username as User,entry_status as Entry_Status FROM climsoftusers;"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "EntryStatus")
                dataGridSettings.DataSource = ds.Tables("EntryStatus")
                dataGridSettings.Refresh()
            End If
            Me.Cursor = Cursors.Default
            lblTrecs.Text = dataGridSettings.Rows.Count
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim usr, expt As String
        Dim entrymode, entrystatus As Integer
        Try
            conn.Open()

            With dataGridSettings
                If .Rows.Count = 0 Then
                    MsgBox("No records retrieved yet!. Click View")
                    Exit Sub
                End If
                If optTargets.Checked Then ' Targets Settings
                    For i = 0 To .Rows.Count - 1
                        usr = .Rows(i).Cells(0).Value
                        If Not IsDBNull(.Rows(i).Cells(1).Value) And IsNumeric(.Rows(i).Cells(1).Value) Then
                            expt = .Rows(i).Cells(1).Value
                            sql = "UPDATE userrecords set recsexpt = '" & Int(expt) & "' where username ='" & usr & "';"
                        Else
                            sql = "UPDATE userrecords set recsexpt = NULL where username ='" & usr & "';"
                        End If

                        ' Update user record
                        qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        qwry.CommandTimeout = 0
                        qwry.ExecuteNonQuery()
                    Next
                ElseIf optEntryMode.Checked Then   ' Key Entry Mode Settings
                    For i = 0 To .Rows.Count - 1
                        entrymode = Val(.Rows(i).Cells(2).Value)
                        ' Update user record
                        sql = "UPDATE data_forms set entry_mode = '" & entrymode & "' where form_name ='" & .Rows(i).Cells(0).Value & "';"
                        qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        qwry.CommandTimeout = 0
                        qwry.ExecuteNonQuery()
                    Next

                ElseIf optUsersStatus.Checked Then   ' Users Key Entry Status

                    Dim getdb As New frmUserManagement
                    Dim db As String

                    ' Get the current database name
                    getdb.CurrentDB(constr, db)

                    For i = 0 To .Rows.Count - 1
                        usr = .Rows(i).Cells(0).Value
                        entrystatus = Val(.Rows(i).Cells(1).Value)
                        If entrystatus = 1 Then
                            sql = "GRANT SELECT,UPDATE ON " & db & ".observationinitial TO '" & usr & "';"
                        Else
                            sql = "REVOKE SELECT,UPDATE ON " & db & ".observationinitial FROM '" & usr & "';"
                        End If

                        'Grant or Revoke Select and Update privileges in observationfinal table for the user
                        Try
                            qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            qwry.CommandTimeout = 0
                            qwry.ExecuteNonQuery()

                        Catch prvlg As Exception
                            If prvlg.HResult = -2147467259 Then Continue For
                        End Try

                        ' Update user entry status
                        sql = "UPDATE climsoftusers set entry_status = '" & entrystatus & "' where userName ='" & usr & "';"
                        qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        qwry.CommandTimeout = 0
                        qwry.ExecuteNonQuery()
                    Next

                End If
                MsgBox("Update Successful")
            End With
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub cmdExtarct_Click(sender As Object, e As EventArgs) Handles cmdExtarct.Click
        Dim Rec(6), MarkType As String

        Try
            Me.Cursor = Cursors.WaitCursor
            listViewRecs.Clear()
            lblTrecs.Text = 0

            If optNotEntered.Checked Then
                'MsgBox(1)
                skippedRecords()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            'Set selections
            If optVerified.Checked Then
                MarkType = "mark = 1"
            Else
                MarkType = "(mark is null or mark <> 1)"
            End If

            If optKeyEntryForm.Checked Then
                sql = "select recordedFrom as StationID, DescribedBy As Code, Year(obsDatetime) As Year, month(obsDatetime) as Month, dataForm as Form, capturedBy as Login from observationinitial " &
                      "where " & MarkType & " and dataForm ='" & cboForms.Text & "' and Year(obsDatetime) between '" & Val(txtYear1.Text) & "' and '" & Val(txtYear2.Text) & "' and Month(obsDatetime) between '" & Val(txtMonth1.Text) & "' and '" & txtMonth2.Text & "';"
            ElseIf optVerified.Checked Then
                sql = "select recordedFrom as StationID, DescribedBy As Code, Year(obsDatetime) As Year, month(obsDatetime) as Month, dataForm as Form, capturedBy as Login from observationinitial " &
                      "where " & MarkType & " and Year(obsDatetime) between '" & Val(txtYear1.Text) & "' and '" & Val(txtYear2.Text) & "' and Month(obsDatetime) between '" & Val(txtMonth1.Text) & "' and '" & txtMonth2.Text & "';"
            ElseIf optNotEntered.Checked Then
                'MsgBox(1)
                'skippedRecords()
                'Me.Cursor = Cursors.Default
                'Exit Sub
            End If

            ' Extract data
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "verified")

            ' Initialize List View
            listViewRecs.Clear()
            listViewRecs.Columns.Clear()
            listViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Element", 100, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
            listViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)
            listViewRecs.Columns.Add("Form", 150, HorizontalAlignment.Left)
            listViewRecs.Columns.Add("Login", 150, HorizontalAlignment.Left)

            For i = 0 To ds.Tables("verified").Rows.Count - 1
                Rec(0) = ds.Tables("verified").Rows(i).Item(0)
                Rec(1) = ds.Tables("verified").Rows(i).Item(1)
                Rec(2) = ds.Tables("verified").Rows(i).Item(2)
                Rec(3) = ds.Tables("verified").Rows(i).Item(3)
                If Not IsDBNull(ds.Tables("verified").Rows(i).Item(4)) Then
                    Rec(4) = ds.Tables("verified").Rows(i).Item(4)
                Else
                    Rec(4) = "UNKOWN"
                End If

                If IsDBNull(ds.Tables("verified").Rows(i).Item(5)) Then
                    Rec(5) = "UNKOWN"
                ElseIf Len(ds.Tables("verified").Rows(i).Item(5)) = 0 Then
                    Rec(5) = "UNKOWN"
                Else
                    Rec(5) = ds.Tables("verified").Rows(i).Item(5)
                End If

                Dim itms = New ListViewItem(Rec)
                listViewRecs.Items.Add(itms)
            Next i
            lblTrecs.Text = listViewRecs.Items.Count
            Me.Cursor = Cursors.Default
            conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            conn.Close()
        End Try
    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        If Not Save_Output1() Then MsgBox("Can't output file")

        'Dim savefile As String

        'If optVerified.Checked Then
        '    savefile = "Verified_records"
        'Else
        '    savefile = "Unverified_records"
        'End If

        'If Not Save_Output("verified", savefile) Then MsgBox("Can't output file")

    End Sub

    Function Save_Output1() As Boolean

        Dim fl, datarow, datahdr As String

        Try
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\RecordsNotEntered.csv"
            FileOpen(11, fl, OpenMode.Output)

            If listViewRecs.Items.Count > 0 Then

                ' Get and print Header Row
                datahdr = listViewRecs.Columns(0).Text
                For k = 1 To listViewRecs.Columns.Count - 1
                    datahdr = datahdr & "," & listViewRecs.Columns(k).Text
                Next
                PrintLine(11, datahdr)

                ' Output data records
                For i = 0 To listViewRecs.Items.Count - 1
                    datarow = listViewRecs.Items(i).SubItems(0).Text
                    For j = 1 To listViewRecs.Columns.Count - 1
                        datarow = datarow & "," & listViewRecs.Items(i).SubItems(j).Text
                    Next
                    PrintLine(11, datarow)
                Next

                FileClose(11)
                MsgBox("Output saved in " & fl)
                If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
            End If

            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
            Return False
        End Try

    End Function
    Function Save_Output(tbl As String, flnm As String) As Boolean


        Dim fl, datarow, datahdr As String

        Try
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & flnm & ".csv"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & flnm & ".csv"
            FileOpen(11, fl, OpenMode.Output)

            If listViewRecs.Items.Count > 0 Then

                ' Get and print Header Row
                datahdr = listViewRecs.Columns(0).Name
                For k = 1 To listViewRecs.Columns.Count - 1
                    datahdr = datahdr & "," & listViewRecs.Columns(k).Name
                Next
                PrintLine(11, datahdr)

                ' Output data records
                For i = 0 To listViewRecs.Items.Count - 1
                    datarow = listViewRecs.Items(i).SubItems(0).Text
                    For j = 1 To listViewRecs.Columns.Count - 1
                        datarow = datarow & "," & listViewRecs.Items(i).SubItems(j).Text
                    Next
                    PrintLine(11, datarow)
                Next

                FileClose(11)
                MsgBox("Output save in " & fl)
                If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
            End If

            '    ' Print Header Row
            '    datahdr = ds.Tables(tbl).Columns(0).ColumnName
            '    For k = 1 To ds.Tables(tbl).Columns.Count - 1
            '        datahdr = datahdr & "," & ds.Tables(tbl).Columns(k).ColumnName
            '    Next
            '    PrintLine(11, datahdr)

            '    ' Output data records
            '    For i = 0 To ds.Tables(tbl).Rows.Count - 1
            '        datarow = ds.Tables(tbl).Rows(i).Item(0)
            '        For j = 1 To ds.Tables(tbl).Columns.Count - 1
            '            datarow = datarow & "," & ds.Tables(tbl).Rows(i).Item(j)
            '        Next j
            '        PrintLine(11, datarow)
            '    Next i
            '    FileClose(11)
            '    MsgBox("Output save in " & fl)
            '    If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
            Return True

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
            Return False
        End Try

    End Function

    Private Sub cmdSave0_Click(sender As Object, e As EventArgs)
        Save_Output("Records", "Users Records")
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Select Case TabMonitoring.SelectedIndex
            Case 0
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "userrecords.htm")
            Case 1
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "performancemonitoring.htm")
            Case 2
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "doublekeyentryverification.htm")
            Case 3
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "settings.htm")
        End Select
    End Sub

    Private Sub cmdSave2_Click(sender As Object, e As EventArgs) Handles cmdSave2.Click
        Dim fl, datarow, datahdr As String
        Me.Cursor = Cursors.WaitCursor

        Try
            ' Create output path if it is not there
            If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data") Then
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data")
            End If

            'Open the output file
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\userRecord.csv"
            FileOpen(21, fl, OpenMode.Output)
            With listViewRecs
                ' Output headers titls
                datahdr = .Columns(0).Text
                For j = 1 To .Columns.Count - 1
                    datahdr = datahdr & "," & .Columns(j).Text
                Next
                PrintLine(21, datahdr)

                ' Output user records
                For i = 0 To .Items.Count - 1
                    datarow = .Items(i).SubItems(0).Text
                    For j = 1 To .Columns.Count - 1
                        datarow = datarow & "," & .Items(i).SubItems(j).Text
                    Next
                    PrintLine(21, datarow)
                Next

            End With
            FileClose(21)
            If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(21)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub optTargets_CheckedChanged(sender As Object, e As EventArgs) Handles optTargets.CheckedChanged
        dataGridSettings.DataSource = ""
        dataGridSettings.Refresh()
        lblTrecs.Text = 0
    End Sub

    Private Sub optAllForms_CheckedChanged(sender As Object, e As EventArgs) Handles optAllForms.CheckedChanged
        If optAllForms.Checked Then
            optNotEntered.Enabled = False
        Else
            optNotEntered.Enabled = True
        End If
    End Sub

    Sub skippedRecords()
        Dim stn, elm, fl As String
        Dim ds1 As New DataSet

        Try
            'fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\MissingRecords.csv"
            'FileOpen(44, fl, OpenMode.Output)

            If cboForms.Text = "" Then
                MsgBox("A key entry form must be selected")
                Exit Sub
            ElseIf cboForms.Text = "form_daily2" Then
                ' Initialize List View
                Dim Rec(4) As String
                listViewRecs.Clear()
                listViewRecs.Columns.Clear()
                listViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Element", 50, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)

                conn.Open()
                sql = "select stationId, elementId from form_daily2 group by stationId, elementId;"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds1.Clear()
                da.Fill(ds1, "GrpRecords")

                With ds1.Tables("GrpRecords")
                    'PrintLine(44, "StationId" & "," & "ElementCode" & "," & "Year" & "," & "Month")
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        elm = .Rows(i).Item(1)
                        For j = Val(txtYear1.Text) To Val(txtYear2.Text)
                            For k = 1 To 12
                                sql = "select stationId, elementid, yyyy,mm from (select stationId, elementId, yyyy, mm from form_daily2 where (yyyy between " & Val(txtYear1.Text) & " and  " & Val(txtYear2.Text) & " ) and (mm between 1 and 12)) t
                                       where stationId = '" & stn & "' and elementId = '" & elm & "' and yyyy = " & j & " and mm = " & k & ";"
                                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                                da.SelectCommand.CommandTimeout = 0
                                ds.Clear()
                                da.Fill(ds, "MissRecords")
                                If ds.Tables("MissRecords").Rows.Count = 0 Then
                                    'PrintLine(44, stn & "," & elm & "," & j & "," & k)
                                    Rec(0) = stn
                                    Rec(1) = elm
                                    Rec(2) = j
                                    Rec(3) = k

                                    Dim itms = New ListViewItem(Rec)
                                    listViewRecs.Items.Add(itms)
                                    lblTrecs.Text = listViewRecs.Items.Count
                                End If
                            Next
                        Next
                    Next
                End With
            ElseIf cboForms.Text = "form_hourly" Then
                ' Initialize List View
                Dim Rec(5) As String
                listViewRecs.Clear()
                listViewRecs.Columns.Clear()
                listViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Element", 50, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Day", 50, HorizontalAlignment.Right)

                conn.Open()
                sql = "select stationId, elementId from form_hourly group by stationId, elementId;"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds1.Clear()
                da.Fill(ds1, "GrpRecords")

                With ds1.Tables("GrpRecords")
                    'PrintLine(44, "StationId" & "," & "ElementCode" & "," & "Year" & "," & "Month" & "," & "Day")
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        elm = .Rows(i).Item(1)
                        For j = Val(txtYear1.Text) To Val(txtYear2.Text)
                            For k = 1 To 12
                                For l = 1 To 31
                                    If Not IsDate(l & "/" & k & "/" & j) Then Continue For
                                    sql = "select stationId, elementid, yyyy,mm, dd from (select stationId, elementId, yyyy, mm, dd from form_hourly where (yyyy between " & Val(txtYear1.Text) & " and  " & Val(txtYear2.Text) & " ) and (mm between 1 and 12)) t
                                               where stationId = '" & stn & "' and elementId = '" & elm & "' and yyyy = " & j & " and mm = " & k & " and dd = " & l & ";"
                                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                                    da.SelectCommand.CommandTimeout = 0
                                    ds.Clear()
                                    da.Fill(ds, "MissRecords")
                                    If ds.Tables("MissRecords").Rows.Count = 0 Then
                                        'PrintLine(44, stn & "," & elm & "," & j & "," & k & "," & l)
                                        Rec(0) = stn
                                        Rec(1) = elm
                                        Rec(2) = j
                                        Rec(3) = k
                                        Rec(4) = l

                                        Dim itms = New ListViewItem(Rec)
                                        listViewRecs.Items.Add(itms)
                                        lblTrecs.Text = listViewRecs.Items.Count
                                    End If
                                Next
                            Next
                        Next
                    Next
                End With
            ElseIf cboForms.Text = "form_agro1" Or cboForms.Text = "form_daily1" Or cboForms.Text = "form_hourlywind" Then
                ' Initialize List View
                Dim Rec(4) As String
                listViewRecs.Clear()
                listViewRecs.Columns.Clear()
                listViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Day", 50, HorizontalAlignment.Right)

                conn.Open()
                sql = "select stationId from " & cboForms.Text & " group by stationId;"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds1.Clear()
                da.Fill(ds1, "GrpRecords")

                With ds1.Tables("GrpRecords")
                    'PrintLine(44, "StationId" & "," & "Year" & "," & "Month" & "," & "Day")
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        For j = Val(txtYear1.Text) To Val(txtYear2.Text)
                            For k = 1 To 12
                                For l = 1 To 31
                                    If Not IsDate(l & "/" & k & "/" & j) Then Continue For
                                    sql = "select stationId, yyyy,mm, dd from (select stationId, yyyy, mm, dd from " & cboForms.Text & " where (yyyy between " & Val(txtYear1.Text) & " and  " & Val(txtYear2.Text) & " ) and (mm between 1 and 12)) t
                                               where stationId = '" & stn & "' and yyyy = " & j & " and mm = " & k & " and dd = " & l & ";"
                                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                                    da.SelectCommand.CommandTimeout = 0
                                    ds.Clear()
                                    da.Fill(ds, "MissRecords")
                                    If ds.Tables("MissRecords").Rows.Count = 0 Then
                                        'PrintLine(44, stn & "," & j & "," & k & "," & l)
                                        Rec(0) = stn
                                        Rec(1) = j
                                        Rec(2) = k
                                        Rec(3) = l

                                        Dim itms = New ListViewItem(Rec)
                                        listViewRecs.Items.Add(itms)
                                        lblTrecs.Text = listViewRecs.Items.Count
                                    End If
                                Next
                            Next
                        Next
                    Next
                End With
            ElseIf cboForms.Text = "form_synoptic_2_ra1" Or cboForms.Text = "form_synoptic2_TDCF" Or cboForms.Text = "form_synoptic2_caribbean" Then
                ' Initialize List View
                Dim Rec(4) As String
                listViewRecs.Clear()
                listViewRecs.Columns.Clear()
                listViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
                listViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Day", 50, HorizontalAlignment.Right)
                listViewRecs.Columns.Add("Hour", 50, HorizontalAlignment.Right)

                conn.Open()
                sql = "select stationId from " & cboForms.Text & " group by stationId;"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds1.Clear()
                da.Fill(ds1, "GrpRecords")

                With ds1.Tables("GrpRecords")
                    'PrintLine(44, "StationId" & "," & "Year" & "," & "Month" & "," & "Day" & "," & "Hour")
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        For j = Val(txtYear1.Text) To Val(txtYear2.Text)
                            For k = 1 To 12
                                For l = 1 To 31
                                    If Not IsDate(l & "/" & k & "/" & j) Then Continue For
                                    For m = 0 To 21 Step 3
                                        sql = "select stationId, yyyy,mm, dd, hh from (select stationId, yyyy, mm, dd, hh from " & cboForms.Text & " where (yyyy between " & Val(txtYear1.Text) & " and  " & Val(txtYear2.Text) & " ) and (mm between 1 and 12)) t
                                               where stationId = '" & stn & "' and yyyy = " & j & " and mm = " & k & " and dd = " & l & " and hh = " & m & ";"
                                        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                                        da.SelectCommand.CommandTimeout = 0
                                        ds.Clear()
                                        da.Fill(ds, "MissRecords")
                                        If ds.Tables("MissRecords").Rows.Count = 0 Then
                                            'PrintLine(44, stn & "," & j & "," & k & "," & l & "," & m)
                                            Rec(0) = stn
                                            Rec(1) = j
                                            Rec(2) = k
                                            Rec(3) = l
                                            Rec(4) = m

                                            Dim itms = New ListViewItem(Rec)
                                            listViewRecs.Items.Add(itms)
                                            lblTrecs.Text = listViewRecs.Items.Count
                                        End If
                                    Next
                                Next
                            Next
                        Next
                    Next
                End With
            Else
                MsgBox("Form " & cboForms.Text & " not implemented")
            End If
            conn.Close()
            'FileClose(44)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            'FileClose(44)
        End Try
    End Sub
End Class

