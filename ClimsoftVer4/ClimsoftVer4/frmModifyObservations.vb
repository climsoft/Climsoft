Public Class frmModifyObservations
    Dim sql, db, dbstr, rw, stn, elm, dt, qc, aq As String
    Dim recs As New DataSet
    Dim das As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dbc As New MySql.Data.MySqlClient.MySqlConnection

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "modifyobservations.htm")
    End Sub

    Private Sub frmModifyObservations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleTranslateTool.translateForm(Me)
    End Sub

    Dim qry As New MySql.Data.MySqlClient.MySqlCommand

    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        rw = -1
        Refresh_Table()

        Try
            'dbstr = frmLogin.txtusrpwd.Text
            'dbc.ConnectionString = dbstr
            'dbc.Open()

            '' Get the selected database
            'Selected_db(db)
            'rw = -1
            '' Select records
            'sql = "select recordedFrom as Station, describedBy as Element, year(obsdatetime) as Year, month(obsdatetime) as Month, day(obsdatetime) as Day, right(obsdatetime,8) as Time, obsvalue as Value, obslevel as Level, flag as Flag, period as Period, qcstatus as QcStatus, acquisitiontype as AcquisitionType from " & db & " WHERE " & _
            '    "recordedFrom = '" & txtStation.Text & "' and describedBy='" & txtElement.Text & "' and (year(obsdatetime) between " & txtStartYear.Text & " and " & txtEndYear.Text & ") and (month(obsdatetime) between " & txtStartMonth.Text & " and " & txtEndMonth.Text & ") and (day(obsdatetime) between 1 and 31);"
            'das = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbc)
            '' Set to unlimited timeout period
            'das.SelectCommand.CommandTimeout = 0

            'recs.Clear()

            'das.Fill(recs, "obsvs")
            'If recs.Tables("obsvs").Rows.Count = 0 Then
            '    MsgBox("No records found")
            '    Exit Sub
            'End If
            'lblrecords.Text = recs.Tables("obsvs").Rows.Count & " Records Found"
            ''MsgBox(tblRecords.Tables("recordsView").Rows.Count)
            'DataGridViewObservations.DataSource = recs.Tables(0)

            DataGridViewObservations.Refresh()

            dbc.Close()
        Catch ex As Exception
            MsgBox("Not data found. Check Selections")
            dbc.Close()
        End Try
    End Sub

    Sub Refresh_Table()

        Try
            dbstr = frmLogin.txtusrpwd.Text
            dbc.ConnectionString = dbstr
            dbc.Open()

            ' Get the selected database
            Selected_db(db)
            rw = -1
            ' Select records
            sql = "select recordedFrom as Station, describedBy as Element, year(obsdatetime) as Year, month(obsdatetime) as Month, day(obsdatetime) as Day, right(obsdatetime,8) as Time, obsvalue as Value, obslevel as Level, flag as Flag, period as Period, qcstatus as QcStatus, acquisitiontype as AcquisitionType from " & db & " WHERE " & _
                  "recordedFrom = '" & txtStation.Text & "' and describedBy='" & txtElement.Text & "' and (year(obsdatetime) between '" & txtStartYear.Text & "' and '" & txtEndYear.Text & "') and (month(obsdatetime) between '" & txtStartMonth.Text & "' and '" & txtEndMonth.Text & "') and (day(obsdatetime) between '" & txtStartDay.Text & "' and '" & txtEndDay.Text & "') and (hour(obsdatetime) between '" & txtStartHour.Text & "' and '" & txtEndHour.Text & "');"
            'MsgBox(sql)
            das = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbc)
            ' Set to unlimited timeout period
            das.SelectCommand.CommandTimeout = 0

            recs.Clear()

            das.Fill(recs, "obsvs")
            If recs.Tables("obsvs").Rows.Count = 0 Then
                MsgBox("Not data found. Check Selections")
                lblrecords.Text = recs.Tables("obsvs").Rows.Count & " Records Selected"
                'Disable commands
                cmdUpade.Enabled = False
                cmdDelete.Enabled = False
                Exit Sub
            End If
            lblrecords.Text = recs.Tables("obsvs").Rows.Count & " Records Selected"
            'MsgBox(tblRecords.Tables("recordsView").Rows.Count)
            DataGridViewObservations.DataSource = recs.Tables(0)
            dbc.Close()
            DataGridViewObservations.Refresh()

            'Enable commands
            cmdUpade.Enabled = True
            cmdDelete.Enabled = True
        Catch ex As Exception
            DataGridViewObservations.Refresh()
            'MsgBox("Not data found. Check Selections")
            MsgBox(ex.Message)
            dbc.Close()
        End Try

    End Sub

    Private Sub cmdUpade_Click(sender As Object, e As EventArgs) Handles cmdUpade.Click
        Dim dttime As String
        Dim Period As String

        Try
            dbstr = frmLogin.txtusrpwd.Text
            dbc.ConnectionString = dbstr
            dbc.Open()

            Selected_db(db)

            DataGridViewObservations.CurrentRow.Selected = True

            If MsgBox("Update the Selected record?", vbYesNo) = MsgBoxResult.No Then Exit Sub
            'MsgBox(rw & " " & stn & " " & elm & " " & dt)

            With DataGridViewObservations
                Me.Cursor = Cursors.WaitCursor
                'For i = 0 To .Rows.Count - 1
                '    If .Rows(i).Selected Then

                dttime = .Rows(rw).Cells(2).Value & "-" & Format(.Rows(rw).Cells(3).Value, "00") & "-" & Format(.Rows(rw).Cells(4).Value, "00") & " " & .Rows(rw).Cells(5).Value
                ' Check for NULL for Period
                If IsDBNull(.Rows(rw).Cells(9).Value) Then
                    Period = "NULL"
                Else
                    Period = Val(.Rows(rw).Cells(9).Value)
                End If

                If db = "observationinitial" Then
                    sql = "Update observationinitial set recordedFrom ='" & .Rows(rw).Cells(0).Value & "' ,describedBy ='" & .Rows(rw).Cells(1).Value & "' ,obsdatetime ='" & dttime & "' ,obsvalue ='" & .Rows(rw).Cells(6).Value & "',obslevel ='" & .Rows(rw).Cells(7).Value & "' ,flag ='" & .Rows(rw).Cells(8).Value & "' ,period =" & Period & ", qcstatus ='" & .Rows(rw).Cells(10).Value & "', acquisitiontype ='" & .Rows(rw).Cells(11).Value & "' " & _
                          "WHERE recordedFrom = '" & stn & "' and describedBy='" & elm & "' and obsdatetime ='" & dt & "' and qcStatus='" & qc & "' and acquisitionType='" & aq & "';"
                Else ' observationfinal
                    sql = "Update observationfinal set recordedFrom ='" & .Rows(rw).Cells(0).Value & "' ,describedBy ='" & .Rows(rw).Cells(1).Value & "' ,obsdatetime ='" & dttime & "' ,obsvalue ='" & .Rows(rw).Cells(6).Value & "',obslevel ='" & .Rows(rw).Cells(7).Value & "' ,flag ='" & .Rows(rw).Cells(8).Value & "' ,period =" & Period & ", qcstatus ='" & .Rows(rw).Cells(10).Value & "', acquisitiontype ='" & .Rows(rw).Cells(11).Value & "' " & _
                          "WHERE recordedFrom = '" & stn & "' and describedBy='" & elm & "' and obsdatetime ='" & dt & "';"
                End If
                'MsgBox(sql)
                qry.Connection = dbc ' Connect command query to the database
                qry.CommandTimeout = 0
                qry.CommandText = sql  ' Assign the SQL statement to the Mysql command variable
                qry.ExecuteNonQuery()   ' Execute the query
                'MsgBox(dttime)

                '    End If
                'Next

            End With
            dbc.Close()
            Me.Cursor = Cursors.Default
            Refresh_Table()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbc.Close()
            Refresh_Table()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Sub Selected_db(ByRef dbase As String)
        If optInitial.Checked Then
            dbase = "observationinitial"
        Else
            dbase = "observationfinal"
        End If
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub DataGridViewObservations_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewObservations.CellBeginEdit

        ' Capture the inique fields value for the current record. The will be used in identify the required record for updating

        If rw <> DataGridViewObservations.CurrentRow.Index Then
            rw = DataGridViewObservations.CurrentRow.Index
            With DataGridViewObservations.CurrentRow
                stn = .Cells(0).Value
                elm = .Cells(1).Value
                dt = .Cells(2).Value & "-" & Format(.Cells(3).Value, "00") & "-" & Format(.Cells(4).Value, "00") & " " & .Cells(5).Value
                qc = .Cells(10).Value
                aq = .Cells(11).Value
                'MsgBox(rw & " " & stn & " " & elm & " " & dt)
            End With
        End If
    End Sub



    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click

        If MsgBox("Delete the Selected Records?", vbYesNo) = MsgBoxResult.No Then Exit Sub

        Try

            dbstr = frmLogin.txtusrpwd.Text
            dbc.ConnectionString = dbstr
            dbc.Open()

            Selected_db(db)

            With DataGridViewObservations
                Me.Cursor = Cursors.WaitCursor

                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Selected Then

                        dt = .Rows(i).Cells(2).Value & "-" & Format(.Rows(i).Cells(3).Value, "00") & "-" & Format(.Rows(i).Cells(4).Value, "00") & " " & .Rows(i).Cells(5).Value

                        If db = "observationinitial" Then
                            sql = "DELETE from observationinitial WHERE recordedFrom = '" & .Rows(i).Cells(0).Value & "' and describedBy='" & .Rows(i).Cells(1).Value & "' and obsdatetime ='" & dt & "' and qcStatus='" & .Rows(i).Cells(10).Value & "' and acquisitiontype ='" & .Rows(i).Cells(11).Value & "';"
                        Else ' observationfinal
                            sql = "DELETE from observationfinal WHERE recordedFrom = '" & .Rows(i).Cells(0).Value & "' and describedBy='" & .Rows(i).Cells(1).Value & "' and obsdatetime ='" & dt & "';"
                        End If
                          'MsgBox(sql)
                        qry.Connection = dbc ' Connect command query to the database
                        qry.CommandTimeout = 0
                        qry.CommandText = sql  ' Assign the SQL statement to the Mysql command variable
                        qry.ExecuteNonQuery()   ' Execute the query
                        'MsgBox(dttime)

                    End If
                Next

            End With
            dbc.Close()
            Me.Cursor = Cursors.Default
            Refresh_Table()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbc.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class