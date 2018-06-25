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
            ds.Clear()
            da.Fill(ds, "KeyEntryForms")

            For kount = 0 To ds.Tables("KeyEntryForms").Rows.Count - 1
                cboForms.Items.Add(ds.Tables("KeyEntryForms").Rows(kount).Item(2))
            Next
            cboForms.Refresh()
            ' Table for Users records
            'sql = "Drop TABLE IF EXISTS `UserRecords`; " & _
            sql = "CREATE TABLE IF NOT EXISTS `UserRecords` ( " & _
                  "`username` varchar(255) NOT NULL DEFAULT '', " & _
                  "`recsdone` int(11) DEFAULT NULL, " & _
                  "`recsexpt` int(11) DEFAULT NULL, " & _
                  "`perform` int(11) DEFAULT NULL, " & _
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
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        Dim dts, dte As String

        dts = DateAndTime.Year(DateTimeStart.Text) & "-" & DateAndTime.Month(DateTimeStart.Text) & "-" & DateAndTime.Day(DateTimeStart.Text) & " 00:00:00"
        dte = DateAndTime.Year(DateTimeEnd.Text) & "-" & DateAndTime.Month(DateTimeEnd.Text) & "-" & DateAndTime.Day(DateTimeEnd.Text) & " 23:59:59"
        Dim Rec(6) As String

        Try
            ' Initialize List View

            ListViewRecs.Clear()
            ListViewRecs.Columns.Clear()
            ListViewRecs.Columns.Add("Login", 120, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Station", 80, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Year", 60, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Month", 50, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Form", 150, HorizontalAlignment.Left)
            ListViewRecs.Columns.Add("Entry DateTime", 200, HorizontalAlignment.Left)

            For i = 0 To cboForms.Items.Count - 1

                If optUsers.Checked Then
                    sql = "SELECT signature as Login, stationId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " & _
                         "GROUP BY signature, stationId, yyyy, mm, entryDatetime " & _
                        "HAVING signature= '" & cboUser.Text & "' AND entryDatetime Between '" & dts & "' And '" & dte & "' " & _
                        "ORDER BY entryDatetime;"
                Else
                    cboUser.Text = ""
                    sql = "SELECT signature as Login, stationId, yyyy as Year, mm as Month, entryDatetime as Entry_DateTime FROM " & cboForms.Items(i) & " " & _
                       "GROUP BY signature, stationId, yyyy, mm, entryDatetime " & _
                       "HAVING entryDatetime Between '" & dts & "' And '" & dte & "' " & _
                       "ORDER BY entryDatetime;"
                End If
                'MsgBox(sql)
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds.Clear()
                da.Fill(ds, "Records")
                'MsgBox(cboForms.Items(i))
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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdRetrieve_Click(sender As Object, e As EventArgs) Handles cmdRetrieve.Click
        Dim dtf, dtt As String
        Dim kt As Long

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

                    'MsgBox(sql)
                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
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

        Catch x As Exception
            MsgBox(x.Message)
        End Try
    End Sub


    Private Sub cmdSave1_Click(sender As Object, e As EventArgs) Handles cmdSave1.Click
        Dim fl, datarow, datahdr As String

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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdretrieve1_Click(sender As Object, e As EventArgs) Handles cmdretrieve1.Click
        ' Compute Performance
        sql = "SELECT username as User,recsexpt as Target_Records FROM userrecords;"
        'MsgBox(sql)
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "settings")
        DataGridSettings.DataSource = ds.Tables("settings")
        DataGridSettings.Refresh()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim usr, expt As String
        With DataGridSettings
            For i = 0 To .Rows.Count - 1
                usr = .Rows(i).Cells(0).Value
                expt = .Rows(i).Cells(1).Value

                ' Update user record
                sql = "UPDATE userrecords set recsexpt = '" & expt & "' where username ='" & usr & "';"
                'MsgBox(sql)
                qwry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qwry.CommandTimeout = 0
                qwry.ExecuteNonQuery()
            Next
        End With
    End Sub

    Private Sub cmdExtarct_Click(sender As Object, e As EventArgs) Handles cmdExtarct.Click

        Dim Rec(6), MarkType As String

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
        'MsgBox(sql)

        ' Extract data
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
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
            If Not IsDBNull(ds.Tables("verified").Rows(i).Item(5)) And Len(ds.Tables("verified").Rows(i).Item(5)) > 0 Then
                Rec(5) = ds.Tables("verified").Rows(i).Item(5)
            Else
                Rec(5) = "UNKOWN"
            End If

            Dim itms = New ListViewItem(Rec)
            ListViewRecs.Items.Add(itms)
        Next i
        lblTrecs.Text = ListViewRecs.Items.Count
    End Sub

    Private Sub optAllForms_CheckedChanged(sender As Object, e As EventArgs) Handles optAllForms.CheckedChanged

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
End Class