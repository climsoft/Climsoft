Public Class frmEntryForms

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

    Private Sub frmEntryForms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SimpleTranslateTool.translateForm(Me)

        Dim col(1) As String
        Dim itm As New ListViewItem

        MyConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = MyConnectionString


        lstvForms.Clear()
        lstvForms.Columns.Clear()

        lstvForms.Columns.Add("Check to select  forms to emepty", 503, HorizontalAlignment.Left)

        Try

            conn.Open()

            sql = "SELECT selected,table_name, description, entry_mode FROM data_forms where Selected ='1';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            For i = 0 To ds.Tables("data_forms").Rows.Count - 1
                col(0) = ds.Tables("data_forms").Rows(i).Item(2)
                itm = New ListViewItem(col)
                lstvForms.Items.Add(itm)
            Next
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub optSelectRecords_CheckedChanged(sender As Object, e As EventArgs) Handles optSelectRecords.CheckedChanged
        If optSelectRecords.Checked = False Then
            txtBYear.Text = ""
            txtEYear.Text = ""
            txtBmonth.Text = 1
            TxtEMonth.Text = 12
            GroupSelections.Enabled = False
        Else
            GroupSelections.Enabled = True
        End If
    End Sub

    Private Sub ToolStripReset_Click(sender As Object, e As EventArgs) Handles ToolStripReset.Click
        ' set selected options to default
        optAllRecords.Checked = True
        optSelectRecords.Checked = False
        chkSkipUploaded.Checked = True

        ' Unselect all forms
        For i = 0 To lstvForms.Items.Count - 1
            lstvForms.Items(i).Checked = False
            lstvForms.Items(i).Selected = False
        Next
    End Sub

    Private Sub ToolStripApply_Click(sender As Object, e As EventArgs) Handles ToolStripApply.Click
        For i = 0 To lstvForms.Items.Count - 1
            If lstvForms.Items(i).Checked = True Then

                If Empty_Table(Table_Name(lstvForms.Items(i).Text)) = False Then
                    MsgBox("Table " & lstvForms.Items(i).Text & " not deleted!")
                Else
                    MsgBox(lstvForms.Items(i).Text & " <---- Done")
                End If
            End If
        Next
    End Sub

    Function Table_Name(descr As String) As String

        With ds.Tables("data_forms")
            For i = 0 To .Rows.Count - 1
                'MsgBox(.Rows(i).Item(1))
                If .Rows(i).Item(2) = descr Then
                    Return .Rows(i).Item(1)
                    Exit For
                End If
            Next
            Return ""
        End With
    End Function

    Function Empty_Table(tbl) As Boolean
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Empty_Table = True

        Try
            If chkSkipUploaded.Checked = False Then

                If optAllRecords.Checked = True Then
                    sql = "Delete from " & tbl & ";"
                ElseIf optSelectRecords.Checked = True Then
                    sql = "delete from " & tbl & " where (yyyy between '" & txtBYear.Text & "' and '" & txtEYear.Text & "') and (mm between '" & txtBmonth.Text & "' and '" & TxtEMonth.Text & "');"
                End If
            Else
                ' Skip Uploaded records
                ' Any record that does not exist in either observationinitial or observationfinal will be skipped

                If optAllRecords.Checked = True Then
                    Delete_Uploaded(tbl, "All")
                ElseIf optSelectRecords.Checked = True Then
                    Delete_Uploaded(tbl, "Selected")
                End If

            End If

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            Empty_Table = False
        End Try

    End Function

    Function Record_Uploaded(sqli As String, sqlf As String) As Boolean
        Dim da2 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds2 As New DataSet
        Dim tbl_initial, tbl_final As Boolean
        Record_Uploaded = False
        tbl_initial = False
        tbl_final = False

        Try
            ' Check if records uploaded into the table observationinitial
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sqli, conn)
            ds2.Clear()
            da2.Fill(ds2, "initial_uploaded")

            If ds2.Tables("initial_uploaded").Rows.Count > 0 Then
                tbl_initial = True
            End If

            ' Check if records uploaded into the table observationfinal
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlf, conn)
            ds2.Clear()
            da2.Fill(ds2, "final_uploaded")

            If ds2.Tables("final_uploaded").Rows.Count > 0 Then
                tbl_final = True
            End If

            If tbl_initial = True Or tbl_final = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Sub Delete_Uploaded(tbl As String, typ As String)
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds1 As New DataSet
        Dim sql1, sql2, stn, elm, yr, mn As String

        Try
            If tbl = "form_daily2" Or tbl = "form_hourly" Then

                If typ = "All" Then sql = "select stationId, ElementId,yyyy, mm from " & tbl
                If typ = "Selected" Then sql = "select stationId, ElementId,yyyy, mm from " & tbl & " where (yyyy between '" & txtBYear.Text & "' and '" & txtEYear.Text & "') and (mm between '" & txtBmonth.Text & "' and '" & TxtEMonth.Text & "');"
                da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds1.Clear()
                da1.Fill(ds1, tbl)
                With ds1.Tables(tbl)
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        elm = .Rows(i).Item(1)
                        yr = .Rows(i).Item(2)
                        mn = .Rows(i).Item(3)

                        sql1 = "SELECT * from observationinitial where recordedFrom = '" & stn & "' and describedBy = '" & elm & "' And year(obsdateTime) = '" & yr & "' and month(obsdateTime) = '" & mn & "' and dataForm = '" & tbl & "';"
                        sql2 = "SELECT * from observationfinal where recordedFrom = '" & stn & "' and describedBy = '" & elm & "' And year(obsdateTime) = '" & yr & "' and month(obsdateTime) = '" & mn & "' and dataForm = '" & tbl & "';"
                        If Record_Uploaded(sql1, sql2) Then
                            sql = "DELETE from " & tbl & " where stationId = '" & stn & "' and ElementId = '" & elm & "' and yyyy = '" & yr & "' and mm = '" & mn & "';"
                            Delete_Record(sql)
                        End If
                    Next
                End With

            ElseIf tbl = "form_hourlywind" Or tbl = "form_agro1" Or tbl = "form_synoptic_2_ra1" Then
                If typ = "All" Then sql = "select stationId,yyyy, mm from " & tbl
                If typ = "Selected" Then sql = "select stationId, yyyy, mm from " & tbl & " where (yyyy between '" & txtBYear.Text & "' and '" & txtEYear.Text & "') and (mm between '" & txtBmonth.Text & "' and '" & TxtEMonth.Text & "');"
                da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds1.Clear()
                da1.Fill(ds1, tbl)
                With ds1.Tables(tbl)
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        yr = .Rows(i).Item(1)
                        mn = .Rows(i).Item(2)

                        sql1 = "SELECT * from observationinitial where recordedFrom = '" & stn & "' and year(obsdateTime) = '" & yr & "' and month(obsdateTime) = '" & mn & "' and dataForm = '" & tbl & "';"
                        sql2 = "SELECT * from observationfinal where recordedFrom = '" & stn & "' and year(obsdateTime) = '" & yr & "' and month(obsdateTime) = '" & mn & "' and dataForm = '" & tbl & "';"

                        If Record_Uploaded(sql1, sql2) Then
                            sql = "DELETE from " & tbl & " where stationId = '" & stn & "' and yyyy = '" & yr & "' and mm = '" & mn & "';"
                            Delete_Record(sql)
                        End If
                    Next
                End With
            ElseIf tbl = "form_monthly" Then
                If typ = "All" Then sql = "select stationId, ElementId,yyyy from " & tbl
                If typ = "Selected" Then sql = "select stationId, ElementId,yyyy from " & tbl & " where (yyyy between '" & txtBYear.Text & "' and '" & txtEYear.Text & "');"
                da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds1.Clear()
                da1.Fill(ds1, tbl)
                With ds1.Tables(tbl)
                    For i = 0 To .Rows.Count - 1
                        stn = .Rows(i).Item(0)
                        elm = .Rows(i).Item(1)
                        yr = .Rows(i).Item(2)
                        sql1 = "SELECT * from observationinitial where recordedFrom = '" & stn & "' and describedBy = '" & elm & "' And year(obsdateTime) = '" & yr & "';"
                        sql2 = "SELECT * from observationfinal where recordedFrom = '" & stn & "' and describedBy = '" & elm & "' And year(obsdateTime) = '" & yr & "';"
                        If Record_Uploaded(sql1, sql2) Then
                            sql = "DELETE from " & tbl & " where stationId = '" & stn & "' and ElementId = '" & elm & "' and yyyy = '" & yr & "';"
                            Delete_Record(sql)
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Delete_Record(sql As String) As Boolean
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Delete_Record = True

        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "emptykeyentrytables.htm")
    End Sub
End Class