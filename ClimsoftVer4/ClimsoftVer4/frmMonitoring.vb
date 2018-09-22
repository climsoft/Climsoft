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
        conn.Open()
        Try
            ' Get Users
            sql = "Select * from climsoftusers;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Users")

            For kount = 0 To ds.Tables("Users").Rows.Count - 1
                cboUser.Items.Add(ds.Tables("Users").Rows(kount).Item(0))
            Next
            cboUser.Items.Add("root")
            cboUser.Refresh()

            ' Get Key Entry forms
            sql = "Select * from data_forms where selected =1;"

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

        Catch ex As Exception
            If ex.HResult = -2147467259 Then
                Me.Close()
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        Dim dts, dte As String

        Me.Cursor = Cursors.WaitCursor
        ListViewRecs.Clear()
        lblTrecs.Text = 0

        dts = DateAndTime.Year(DateTimeStart.Text) & "-" & DateAndTime.Month(DateTimeStart.Text) & "-" & DateAndTime.Day(DateTimeStart.Text) & " 00:00:00"
        dte = DateAndTime.Year(DateTimeEnd.Text) & "-" & DateAndTime.Month(DateTimeEnd.Text) & "-" & DateAndTime.Day(DateTimeEnd.Text) & " 23:59:59"
        Dim Rec(6) As String

        Try
            'Initialize List View

            ListViewRecs.Clear()
            ListViewRecs.Columns.Clear()
            ListViewRecs.Columns.Add("Login", 120, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Station", 80, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Year", 60, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Month/Code", 80, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Form", 150, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Entry DateTime", 200, HorizontalAlignment.Left)

            For i = 0 To cboForms.Items.Count - 1

                If optUsers.Checked Then
                    sql = "SELECT signature as Login, stationId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                         "GROUP BY signature, stationId, yyyy, mm, entryDatetime " &
                        "HAVING signature= '" & cboUser.Text & "' AND entryDatetime Between '" & dts & "' And '" & dte & "' " &
                        "ORDER BY entryDatetime;"

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

                    ' form_monthly is a pecial case since it has no mm field
                    If cboForms.Items(i) = "form_monthly" Then
                        sql = "SELECT signature as Login, stationId, yyyy as Year, elementId as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " &
                       "GROUP BY signature, stationId, yyyy, entryDatetime " &
                       "HAVING entryDatetime Between '" & dts & "' And '" & dte & "' " &
                       "ORDER BY entryDatetime;"
                    End If

                End If

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "Records")

                For kount = 0 To ds.Tables("Records").Rows.Count - 1
                    Rec(0) = ds.Tables("Records").Rows(kount).Item("Login")
                    Rec(1) = ds.Tables("Records").Rows(kount).Item("StationID")
                    Rec(2) = ds.Tables("Records").Rows(kount).Item("Year")
                    Rec(3) = ds.Tables("Records").Rows(kount).Item("Month")
                    Rec(4) = cboForms.Items(i)
                    Rec(5) = ds.Tables("Records").Rows(kount).Item("Entry_DateTime")

                    Dim itms = New ListViewItem(Rec)
                    ListViewRecs.Items.Add(itms)
                Next kount
            Next i
            lblTrecs.Text = ListViewRecs.Items.Count
            lblTrecs.Refresh()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdRetrieve_Click(sender As Object, e As EventArgs) Handles cmdRetrieve.Click
        Dim dtf, dtt As String
        Dim kt As Long

        Me.Cursor = Cursors.WaitCursor
        ListViewRecs.Clear()
        lblTrecs.Text = 0

        dtf = DateAndTime.Year(dtFrom.Text) & "-" & DateAndTime.Month(dtFrom.Text) & "-" & DateAndTime.Day(dtFrom.Text) & " 00:00:00"
        dtt = DateAndTime.Year(dtTo.Text) & "-" & DateAndTime.Month(dtTo.Text) & "-" & DateAndTime.Day(dtTo.Text) & " 23:59:59"

        Try
            kt = 0
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
                        If ds.Tables("UserRecords").Rows(j).Item(0) = cboUser.Items(i) Then
                            kount = kount + 1
                        End If
                    Next j
                Next k
                kt = kt + kount
                ' Update user record
                sql = "UPDATE userrecords set recsdone = " & kount & " where username ='" & cboUser.Items(i) & "';"
                'MsgBox(sql)
                qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qwry.CommandTimeout = 0
                qwry.ExecuteNonQuery()
            Next i
            lblTrecs.Text = kt 'kount()

        Catch x As Exception
            MsgBox(x.Message)
            Me.Cursor = Cursors.Default
        End Try

        Dim Rec(4) As String

        Try
            ' Initialize List View

            ListViewRecs.Clear()
            ListViewRecs.Columns.Clear()
            ListViewRecs.Columns.Add("User", 120, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Records", 100, HorizontalAlignment.Right)
            ListViewRecs.Columns.Add("Target", 100, HorizontalAlignment.Right)
            ListViewRecs.Columns.Add("Performance % ", 150, HorizontalAlignment.Right)

            'sql = "Select * from userrecords"
            sql = "select username as Login, recsdone as Records,recsexpt as Target, round(recsdone/recsexpt * 100, 1) as performance from userrecords;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Performs")

            For i = 0 To ds.Tables("Performs").Rows.Count - 1
                Rec(0) = ds.Tables("Performs").Rows(i).Item(0)
                Rec(1) = ds.Tables("Performs").Rows(i).Item(1)
                Rec(2) = ds.Tables("Performs").Rows(i).Item(2)
                Rec(3) = ds.Tables("Performs").Rows(i).Item(3)

                'perf = (ds.Tables("Records").Rows(i).Item(1) / ds.Tables("Records").Rows(i).Item(2)) * 100
                'Rec(3) = Format(perf, "0.0") 'ds.Tables("Records").Rows(i).Item(3)

                Dim itms = New ListViewItem(Rec)
                ListViewRecs.Items.Add(itms)
            Next i
            lblTrecs.Text = ds.Tables("Performs").Rows.Count
            Me.Cursor = Cursors.Default
        Catch x As Exception
            MsgBox(x.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cmdSave1_Click(sender As Object, e As EventArgs) Handles cmdSave1.Click
        Dim fl, datarow, datahdr As String
        Me.Cursor = Cursors.WaitCursor

        Try
            fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Performance.csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Print Header Rows
            PrintLine(11, "Performance Report")

            If OptMonthly.Checked Then
                datahdr = "Period: " & MonthName(Val(cboMonth.Text)) & "   " & txtYear.Text
            Else
                datahdr = "Period: From  " & dtFrom.Text & "  To  " & dtTo.Text
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

        Me.Cursor = Cursors.WaitCursor

        ' Add a record for key entry mode if not exists
        Try
            Dim qry As MySql.Data.MySqlClient.MySqlCommand
            sql = "ALTER TABLE `data_forms` ADD COLUMN `entry_mode` TINYINT(2) NOT NULL DEFAULT '0' AFTER `sequencer`;"
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()
        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'Existing record
                MsgBox(ex.HResult & " " & ex.Message)
            End If
        End Try

        ListViewRecs.Clear()
        lblTrecs.Text = 0

        Try
            If optTargets.Checked Then
                sql = "SELECT username as User,recsexpt as Target_Records FROM userrecords;"
               
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "settings")
                DataGridSettings.DataSource = ds.Tables("settings")
                DataGridSettings.Refresh()
            Else
                sql = "SELECT form_name,description, entry_mode FROM data_forms where selected ='1';"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "forms")
                DataGridSettings.DataSource = ds.Tables("forms")
                DataGridSettings.Refresh()
            End If
            Me.Cursor = Cursors.Default
            lblTrecs.Text = DataGridSettings.Rows.Count
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim usr, expt As String
        Dim entrymode As Integer
        Try
            With DataGridSettings
                If .Rows.Count = 0 Then
                    MsgBox("No ecords retrieved yet!")
                    Exit Sub
                End If
                If optTargets.Checked Then ' Targets Settings
                    For i = 0 To .Rows.Count - 1
                        usr = .Rows(i).Cells(0).Value
                        expt = .Rows(i).Cells(1).Value
                        ' Update user record
                        sql = "UPDATE userrecords set recsexpt = '" & expt & "' where username ='" & usr & "';"
                        qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        qwry.CommandTimeout = 0
                        qwry.ExecuteNonQuery()
                    Next
                Else    ' Key Entry Mode Settings
                    For i = 0 To .Rows.Count - 1
                        entrymode = Val(.Rows(i).Cells(2).Value)
                        ' Update user record
                        sql = "UPDATE data_forms set entry_mode = '" & entrymode & "' where form_name ='" & .Rows(i).Cells(0).Value & "';"
                        qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        qwry.CommandTimeout = 0
                        qwry.ExecuteNonQuery()
                    Next
                End If
                MsgBox("Update Successful")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdExtarct_Click(sender As Object, e As EventArgs) Handles cmdExtarct.Click
        Dim Rec(6), MarkType As String

        Try
            Me.Cursor = Cursors.WaitCursor
            ListViewRecs.Clear()
            lblTrecs.Text = 0

            'Set selections
            If optVerified.Checked Then
                MarkType = "mark = 1"
            Else
                MarkType = "(mark is null or mark <> 1)"
            End If

            If optKeyEntryForm.Checked Then
                sql = "select recordedFrom as StationID, DescribedBy As Code, Year(obsDatetime) As Year, month(obsDatetime) as Month, dataForm as Form, capturedBy as Login from observationinitial " & _
                      "where " & MarkType & " and dataForm ='" & cboForms.Text & "' and Year(obsDatetime) between '" & Val(txtYear1.Text) & "' and '" & Val(txtYear2.Text) & "' and Month(obsDatetime) between '" & Val(txtMonth1.Text) & "' and '" & txtMonth2.Text & "';"
            Else
                sql = "select recordedFrom as StationID, DescribedBy As Code, Year(obsDatetime) As Year, month(obsDatetime) as Month, dataForm as Form, capturedBy as Login from observationinitial " & _
                      "where " & MarkType & " and Year(obsDatetime) between '" & Val(txtYear1.Text) & "' and '" & Val(txtYear2.Text) & "' and Month(obsDatetime) between '" & Val(txtMonth1.Text) & "' and '" & txtMonth2.Text & "';"

            End If

            ' Extract data
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "verified")

            ' Initialize List View
            ListViewRecs.Clear()
            ListViewRecs.Columns.Clear()
            ListViewRecs.Columns.Add("Station", 120, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Element", 100, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Year", 50, HorizontalAlignment.Right)
            ListViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Right)
            ListViewRecs.Columns.Add("Form", 150, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Login", 150, HorizontalAlignment.Left)

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
                ListViewRecs.Items.Add(itms)
            Next i
            lblTrecs.Text = ListViewRecs.Items.Count
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Dim savefile As String

        If optVerified.Checked Then
            savefile = "Verified_records"
        Else
            savefile = "Unverified_records"
        End If

        If Not Save_Output("verified", savefile) Then MsgBox("Can't output file")
        
    End Sub

    Function Save_Output(tbl As String, flnm As String) As Boolean

        Dim fl, datarow, datahdr As String

        Try
            fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & flnm & ".csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Print Header Row
            datahdr = ds.Tables(tbl).Columns(0).ColumnName
            For k = 1 To ds.Tables(tbl).Columns.Count - 1
                datahdr = datahdr & "," & ds.Tables(tbl).Columns(k).ColumnName
            Next
            PrintLine(11, datahdr)

            ' Output data records
            For i = 0 To ds.Tables(tbl).Rows.Count - 1
                datarow = ds.Tables(tbl).Rows(i).Item(0)
                For j = 1 To ds.Tables(tbl).Columns.Count - 1
                    datarow = datarow & "," & ds.Tables(tbl).Rows(i).Item(j)
                Next j
                PrintLine(11, datarow)
            Next i
            FileClose(11)
            If Not CommonModules.ViewFile(fl) Then MsgBox("Can't Open File")
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


    Private Sub optTargets_CheckedChanged(sender As Object, e As EventArgs) Handles optTargets.CheckedChanged
        DataGridSettings.DataSource = ""
        DataGridSettings.Refresh()
        lblTrecs.Text = 0
    End Sub
End Class