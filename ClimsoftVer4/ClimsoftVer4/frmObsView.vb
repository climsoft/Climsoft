Public Class frmObsView

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim qry As New MySql.Data.MySqlClient.MySqlCommand
    Dim maxRows, maxColumns, qcStatus, acquisitionStatus As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString, Selectflds, rw, stn, elm, dt, qc, aq As String
    Dim ItmExist As Boolean
    Dim stnlist, elmlist, levlist, dttPeriod, sdate, edate, sql, tblName, flag, advcSelect, frm As String

    Private Sub frmObsView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        tblName = "observationinitial"

        'Set Header for Stations list view
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'Set Header for Elements list view
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

        MyConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            Sql = "SELECT * FROM station ORDER BY stationName"

            'sql = "SELECT recordedFrom, stationName from observationfinal INNER JOIN station ON recordedFrom = stationId group by recordedFrom  ORDER BY stationName;"

            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "station")
            'conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("station").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1

            cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))

        Next

        ds.Clear()

        Sql = "SELECT * FROM obselement where selected = '1' ORDER BY description"

        'sql = "select describedBy, description from observationfinal INNER JOIN obselement on describedBy = elementId group by describedBy  order by description;"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        da.SelectCommand.CommandTimeout = 0
        da.Fill(ds, "obselement")

        maxRows = ds.Tables("obselement").Rows.Count
        For kount = 0 To maxRows - 1 Step 1
            cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("description"))
        Next

        'populateFlags()
        populateForms()
        conn.Close()

        ClsTranslations.TranslateForm(Me)
    End Sub
    Sub populateForms()
        sql = "select table_name from data_forms where selected =1;"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "forms")

            With ds.Tables("forms")
                lstBoxForms.Items.Clear()
                For kount = 0 To .Rows.Count - 1
                    lstBoxForms.Items.Add(.Rows(kount).Item(0))
                Next
            End With

        Catch ex As Exception

        End Try
    End Sub
    Sub populateFlags()

        sql = "select characterSymbol,description as Typ from flags order by numSymbol;"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "flags")

            With ds.Tables("flags")
                lstBoxFlags.Items.Clear()
                For kount = 0 To .Rows.Count - 1
                    lstBoxFlags.Items.Add(.Rows(kount).Item(0) & " " & .Rows(kount).Item(1))
                Next
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged

        sql = "SELECT stationId, stationName FROM station WHERE stationName='" & cmbstation.Text & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        maxRows = (ds.Tables("station").Rows.Count)
        If maxRows > 0 Then cmbstation.BackColor = Color.White

        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("station").Rows(kount).Item("stationId")
                str(1) = ds.Tables("station").Rows(kount).Item("stationName")
                itm = New ListViewItem(str)

                ItmExist = False
                If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvStations.Items.Add(itm)
                Else
                    For j = 0 To lstvStations.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvStations.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvStations.Items.Add(itm)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElement.SelectedIndexChanged
        Try

            sql = "SELECT elementId, abbreviation, description FROM obselement WHERE description='" & cmbElement.Text & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            If maxRows > 0 Then cmbElement.BackColor = Color.White

            Dim str(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("obselement").Rows(kount).Item("elementId")
                str(1) = ds.Tables("obselement").Rows(kount).Item("abbreviation")
                str(2) = ds.Tables("obselement").Rows(kount).Item("description")
                itm = New ListViewItem(str)

                ItmExist = False
                If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvElements.Items.Add(itm)
                Else
                    For j = 0 To lstvElements.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvElements.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvElements.Items.Add(itm)
                End If
            Next

        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub frmObsView_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        'TabObservations.Width = Me.Width
        'TabObservations.Height = Me.Height
    End Sub

    Private Sub cmbElement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbElement.KeyPress
        If Asc(e.KeyChar) = 13 Then add_Element(cmbElement.Text)
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then

            cmdSelectAllStations.Enabled = True
            add_Station(cmbstation.Text)

        End If
    End Sub

    Sub add_Element(id As String)
        Dim str(3) As String
        Dim itm = New ListViewItem

        Try

            'sql = "SELECT SELECT elementId, abbreviation, description FROM obselement WHERE elementId = '" & id & "';"
            sql = "SELECT elementId, abbreviation, description FROM obselement WHERE selected = '1' and elementId = '" & id & "';"

            'sql = "SELECT elementId, abbreviation, description FROM obselement WHERE selected ='1' and description=""" & prod & """"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbElement.Text = ""
                cmbElement.BackColor = Color.White
            Else
                cmbElement.BackColor = Color.Red
                Exit Sub
            End If

            'For kount = 0 To maxRows - 1 Step 1

            str(0) = ds.Tables("obselement").Rows(0).Item("elementId")
            str(1) = ds.Tables("obselement").Rows(0).Item("abbreviation")
            str(2) = ds.Tables("obselement").Rows(0).Item("description")

            itm = New ListViewItem(str)

            ItmExist = False
            If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
                lstvElements.Items.Add(itm)
            Else
                For j = 0 To lstvElements.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstvElements.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                If Not ItmExist Then lstvElements.Items.Add(itm)
            End If
            'Next
        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkAdvancedSelection_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvancedSelection.CheckedChanged
        If chkAdvancedSelection.Checked = True Then
            pnlAdanced.Visible = True
        Else
            pnlAdanced.Visible = False
        End If
    End Sub

    Private Sub cmdDelStation_Click(sender As Object, e As EventArgs) Handles cmdDelStation.Click
        For i = 0 To lstvStations.Items.Count - 1
            If lstvStations.Items(i).Selected Then
                lstvStations.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim Period As String

        If MsgBox(" Continue to Update the Selected Record?", vbYesNo) = MsgBoxResult.No Then Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            conn.Open()
            dataGridViewRecord.CurrentRow.Selected = True
            'MsgBox(rw & " " & stn & " " & elm & " " & dt)

            With dataGridViewRecord
                'MsgBox(.Rows(rw).Cells(5).Value.ToString)
                'dt = DateAndTime.Year(.Rows(rw).Cells(2).Value) & "-" & DateAndTime.Month(.Rows(rw).Cells(2).Value) & "-" & DateAndTime.Day(.Rows(rw).Cells(2).Value) & " " & DateAndTime.TimeValue(.Rows(rw).Cells(2).Value)
                dt = .Rows(rw).Cells(2).Value & "-" & .Rows(rw).Cells(3).Value & "-" & .Rows(rw).Cells(4).Value & " " & .Rows(rw).Cells(5).Value.ToString
                'MsgBox(dt)
                ' Check for NULL for Period
                If IsDBNull(.Rows(rw).Cells(6).Value) Then
                    Period = "NULL"
                Else
                    Period = Val(.Rows(rw).Cells(6).Value)
                End If

                'sql = "Update " & tblName & " set recordedFrom ='" & .Rows(rw).Cells(0).Value & "' ,describedBy ='" & .Rows(rw).Cells(1).Value & "' ,obsdatetime ='" & dt & "' ,obsvalue ='" & .Rows(rw).Cells(4).Value & "',obslevel ='" & .Rows(rw).Cells(3).Value & "' ,flag ='" & .Rows(rw).Cells(5).Value & "' ,period =" & Period & ", qcstatus ='" & .Rows(rw).Cells(7).Value & "', acquisitiontype ='" & .Rows(rw).Cells(9).Value & "' " &
                '      "WHERE recordedFrom = '" & stn & "' and describedBy='" & elm & "' and obsdatetime ='" & dt & "' and qcStatus='" & qc & "' and acquisitionType='" & aq & "';"

                sql = "Update " & tblName & " set recordedFrom ='" & .Rows(rw).Cells(0).Value & "' ,describedBy ='" & .Rows(rw).Cells(1).Value & "' ,obsdatetime ='" & dt & "' ,obsvalue ='" & .Rows(rw).Cells(7).Value & "',obslevel ='" & .Rows(rw).Cells(6).Value & "' ,flag ='" & .Rows(rw).Cells(8).Value & "' ,period =" & .Rows(rw).Cells(9).Value & ", qcstatus ='" & .Rows(rw).Cells(10).Value & "', acquisitiontype ='" & .Rows(rw).Cells(12).Value & "' " &
                      "WHERE recordedFrom = '" & stn & "' and describedBy='" & elm & "' and obsdatetime ='" & dt & "' and qcStatus='" & qc & "' and acquisitionType='" & aq & "';"

                'MsgBox(sql)
                'cmbElement.Text = sql
                qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qry.CommandTimeout = 0
                'Execute query
                qry.ExecuteNonQuery()

                Me.Cursor = Cursors.Default
            End With

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If MsgBox(" Continue to Delete the Listed Records?", vbYesNo) = MsgBoxResult.No Then Exit Sub
        Try
            Me.Cursor = Cursors.WaitCursor
            conn.Open()
            dataGridViewRecord.CurrentRow.Selected = True

            With dataGridViewRecord

                sql = "DELETE FROM " & tblName & " Where " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"

                'MsgBox(sql)

                qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qry.CommandTimeout = 0
                'Execute query
                qry.ExecuteNonQuery()

                .Refresh()
                Me.Cursor = Cursors.Default
            End With

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub btnExpot_Click(sender As Object, e As EventArgs) Handles btnExpot.Click
        Dim dat, hdr, fl As String

        Try
            Me.Cursor = Cursors.WaitCursor
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            If Not IO.Directory.Exists(fl) Then IO.Directory.CreateDirectory(fl)

            fl = fl & "\obsUpdate.csv"

            FileOpen(101, fl, OpenMode.Output)

            With dataGridViewRecord
                hdr = .Columns(0).Name
                For i = 1 To .Columns.Count - 1
                    hdr = hdr & "," & .Columns(i).Name
                Next
                PrintLine(101, hdr)

                dat = .Columns(0).Name
                For i = 0 To .Rows.Count - 1
                    dat = .Rows(i).Cells(0).Value
                    For j = 1 To .Rows(i).Cells.Count - 1
                        dat = dat & "," & .Rows(i).Cells(j).Value.ToString
                    Next
                    PrintLine(101, dat)
                Next
            End With
            FileClose(101)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(101)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub optFinal_CheckedChanged(sender As Object, e As EventArgs) Handles optFinal.CheckedChanged
        If optFinal.Checked Then
            tblName = "observationfinal"
        Else
            tblName = "observationinitial"
        End If
    End Sub

    Private Sub chkForms_CheckedChanged(sender As Object, e As EventArgs) Handles chkForms.CheckedChanged
        If chkForms.Checked Then
            lstBoxForms.Enabled = True
        Else
            lstBoxForms.Enabled = False
        End If
    End Sub

    Private Sub pnlAdanced_Paint(sender As Object, e As PaintEventArgs) Handles pnlAdanced.Paint

    End Sub

    Private Sub cboMinuteEnd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMinuteEnd.SelectedIndexChanged

    End Sub

    Private Sub txtSminute_Click(sender As Object, e As EventArgs) Handles txtSminute.Click

    End Sub

    Private Sub lblHourEnd_Click(sender As Object, e As EventArgs) Handles lblHourEnd.Click

    End Sub

    Private Sub cboHourStart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHourStart.SelectedIndexChanged

    End Sub

    Private Sub cboHourEnd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHourEnd.SelectedIndexChanged

    End Sub

    Private Sub cboMinuteStart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMinuteStart.SelectedIndexChanged

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        viewRecords()
    End Sub

    Private Sub optInitial_CheckedChanged(sender As Object, e As EventArgs) Handles optInitial.CheckedChanged
        If optInitial.Checked Then
            tblName = "observationinitial"
        Else
            tblName = "observationfinal"
        End If
    End Sub

    Private Sub chkQCStatus_CheckedChanged(sender As Object, e As EventArgs) Handles chkQCStatus.CheckedChanged
        If chkQCStatus.Checked Then
            lstBoxQC.Enabled = True
        Else
            lstBoxQC.Enabled = False
        End If
    End Sub

    Private Sub chkFlags_CheckedChanged(sender As Object, e As EventArgs) Handles chkFlags.CheckedChanged
        If chkFlags.Checked Then
            lstBoxFlags.Enabled = True
        Else
            lstBoxFlags.Enabled = False
        End If
    End Sub


    Private Sub chkAcquisitionType_CheckedChanged(sender As Object, e As EventArgs) Handles chkAcquisitionType.CheckedChanged
        If chkAcquisitionType.Checked Then
            lstBoxAcquition.Enabled = True
        Else
            lstBoxAcquition.Enabled = False
        End If
    End Sub

    Private Sub cmdSelectAllStations_Click(sender As Object, e As EventArgs) Handles cmdSelectAllStations.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lstvStations.Clear()
            lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
            lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

            sql = "SELECT recordedFrom, stationName FROM observationfinal INNER JOIN station ON stationId = recordedFrom GROUP BY recordedFrom;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "stations")

            maxRows = (ds.Tables("stations").Rows.Count)

            Dim strs(2) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("stations").Rows(kount).Item("recordedFrom")
                strs(1) = ds.Tables("stations").Rows(kount).Item("stationName")
                itm = New ListViewItem(strs)
                lstvStations.Items.Add(itm)
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClearStations_Click(sender As Object, e As EventArgs) Handles cmdClearStations.Click
        lstvStations.Items.Clear()
    End Sub

    Private Sub cmdDelElement_Click(sender As Object, e As EventArgs) Handles cmdDelElement.Click
        For i = 0 To lstvElements.Items.Count - 1
            If lstvElements.Items(i).Selected Then
                lstvElements.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdSelectAllElements_Click(sender As Object, e As EventArgs) Handles cmdSelectAllElements.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lstvElements.Clear()
            lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

            sql = "SELECT describedBy, elementName,description  FROM observationfinal INNER JOIN obselement ON elementId = describedBy GROUP BY describedBy;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "Elements")

            maxRows = (ds.Tables("Elements").Rows.Count)

            Dim strs(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("Elements").Rows(kount).Item("describedBy")
                strs(1) = ds.Tables("Elements").Rows(kount).Item("elementName")
                strs(2) = ds.Tables("Elements").Rows(kount).Item("description")
                itm = New ListViewItem(strs)
                lstvElements.Items.Add(itm)
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClearElements_Click(sender As Object, e As EventArgs) Handles cmdClearElements.Click
        lstvElements.Items.Clear()
    End Sub

    Sub add_Station(id As String)
        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            sql = "SELECT stationId, stationName FROM station WHERE stationId= '" & id & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "station")

            maxRows = (ds.Tables("station").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbstation.Text = ""
                cmbstation.BackColor = Color.White
            Else
                cmbstation.BackColor = Color.Red
                Exit Sub
            End If

            str(0) = ds.Tables("station").Rows(0).Item("stationId")
            str(1) = ds.Tables("station").Rows(0).Item("stationName")

            itm = New ListViewItem(str)

            ItmExist = False
            If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                lstvStations.Items.Add(itm)
            Else
                For j = 0 To lstvStations.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstvStations.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                If Not ItmExist Then lstvStations.Items.Add(itm)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabObservations_Click(sender As Object, e As EventArgs) Handles TabObservations.Click

        With TabObservations.SelectedTab
            If .TabIndex = 1 Then

                sdate = Year(dtpDateFrom.Text) & "-" & Month(dtpDateFrom.Text) & "-" & DateAndTime.Day(dtpDateFrom.Text) & " " & cboHourStart.Text & ":" & cboMinuteStart.Text & ":00"
                edate = Year(dtpDateTo.Text) & "-" & Month(dtpDateTo.Text) & "-" & DateAndTime.Day(dtpDateTo.Text) & " " & cboHourEnd.Text & ":" & cboMinuteEnd.Text & ":00"


                stnlist = ""
                If lstvStations.Items.Count > 0 Then
                    stnlist = "recordedFrom = '" & lstvStations.Items(0).Text & "'"
                    For i = 1 To lstvStations.Items.Count - 1
                        '  MsgBox(lstvStations.Items(i).Text)
                        stnlist = stnlist & " OR RecordedFrom = " & "'" & lstvStations.Items(i).Text & "'"
                    Next
                End If
                stnlist = "(" & stnlist & ")"
                'MsgBox(stnlist)

                ' Get the Element list
                elmlist = ""
                If lstvElements.Items.Count > 0 Then
                    elmlist = "describedBy = " & lstvElements.Items(0).Text
                    For i = 1 To lstvElements.Items.Count - 1
                        elmlist = elmlist & " OR  describedBy = " & lstvElements.Items(i).Text
                    Next
                End If
                elmlist = "(" & elmlist & ")"

                dttPeriod = "(obsDatetime between '" & sdate & "' and '" & edate & "') "
                'sql = "Select * from " & tblName & " where " & stnlist & " AND " & elmlist

                sql = sql & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') "

                advcSelect = ""

                'Check if any QC status is selected
                If setQCstatus(qcStatus) Then
                    'sql = sql & " AND qcStatus = " & qcStatus
                    advcSelect = advcSelect & " And qcStatus = " & qcStatus
                End If

                'Check if any acquisitionStatus is selected
                If setAQstatus(acquisitionStatus) Then
                    'sql = sql & " AND acquisitionType = " & acquisitionStatus
                    advcSelect = advcSelect & " And acquisitionType = " & acquisitionStatus
                End If

                ' Check if any flag is selected
                If selectFlag(flag) Then
                    'sql = sql & " AND flag = " & flag
                    advcSelect = advcSelect & " And right(flag,1) = " & flag
                End If

                'Check if any key entry form is selected
                If selectForm(frm) Then
                    'sql = sql & " AND acquisitionType = " & acquisitionStatus
                    advcSelect = advcSelect & " And dataForm = " & frm
                End If

                If Not showRecords() Then
                    MsgBox("Can't show any record")
                    grpButtons.Enabled = False
                Else
                    grpButtons.Enabled = True
                End If
            End If
        End With
        ' Show records

    End Sub
    Function showRecords() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            'sql1 = sql1 & ";"
            Selectflds = "select recordedFrom as Station_id,describedBy as Element_code,year(obsDatetime) as 'Year',month(obsDatetime) as 'Month',day(obsDatetime) as 'Day',time(obsDatetime) as 'Time',obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone"
            sql = Selectflds & " From " & tblName & " Where " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"

            'sql = "Select * From " & tblName & " Where " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"

            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "records")

            If ds.Tables("records").Rows.Count = 0 Then ' No records to show
                Me.Cursor = Cursors.Default
                Return False
            End If

            dataGridViewRecord.DataMember = "records"
            dataGridViewRecord.DataSource = ds
            dataGridViewRecord.Refresh()
            Me.Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            'MsgBox(ex.Message & " " & ex.HResult)
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            Return False
        End Try
    End Function

    Function setQCstatus(ByRef qcStts As Integer) As Boolean
        Try
            If chkQCStatus.Checked Then
                qcStts = lstBoxQC.SelectedItem
                'MsgBox(qcStts)
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Function setAQstatus(ByRef acqStts As Integer) As Boolean
        Try
            If chkAcquisitionType.Checked Then
                acqStts = lstBoxAcquition.SelectedIndex
                'MsgBox(acqStts)
                Return True
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    'Function setEntrForm(ByRef efrms As Integer) As Boolean
    '    Try
    '        If chkForms.Checked Then
    '            efrms = lstForms.SelectedItem
    '            MsgBox(efrms)
    '            Return True
    '        End If
    '        Return False
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function
    Function selectFlag(ByRef flg As String) As Boolean
        Try
            If chkFlags.Checked Then
                If Len(txtOtherflag.Text) > 0 Then
                    flg = txtOtherflag.Text
                Else
                    flg = "'" & Strings.Left(lstBoxFlags.SelectedItem, 1) & "'"
                    'MsgBox(flg)
                End If
                Return True
            End If
            Return False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Function selectForm(ByRef frm As String) As Boolean
        Try
            If chkForms.Checked Then
                frm = "'" & lstBoxForms.SelectedItem & "'"
                'MsgBox(flg)
                Return True
            End If
            Return False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Sub DataGridView_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dataGridViewRecord.CellBeginEdit
        ' Capture the inique fields value for the current record. The will be used in identify the required record for updating
        With dataGridViewRecord.CurrentRow
            'MsgBox(rw)
            'If rw = "" Then

            rw = .Index
            stn = .Cells(0).Value
            elm = .Cells(1).Value
            'dt = .Cells(2).Value '& "-" & Format(.Cells(2).Value, "00") & "-" & Format(.Cells(2).Value, "00") & " " & .Cells(2).Value
            dt = .Cells(2).Value & "-" & .Cells(3).Value & "-" & .Cells(4).Value & " " & .Cells(5).Value.ToString
            qc = .Cells(10).Value
            aq = .Cells(12).Value
            'MsgBox(rw & " " & stn & " " & elm & " " & dt & " " & qc & " " & aq)
            'End If
        End With
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Sub viewRecords()

        'sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & DateAndTime.Day(dateFrom.Text) & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
        'edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & DateAndTime.Day(dateTo.Text) & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"


        'stnlist = ""
        'If lstvStations.Items.Count > 0 Then
        '    stnlist = "recordedFrom = '" & lstvStations.Items(0).Text & "'"
        '    For i = 1 To lstvStations.Items.Count - 1
        '        '  MsgBox(lstvStations.Items(i).Text)
        '        stnlist = stnlist & " OR RecordedFrom = " & "'" & lstvStations.Items(i).Text & "'"
        '    Next
        'End If
        'stnlist = "(" & stnlist & ")"
        ''MsgBox(stnlist)

        '' Get the Element list
        'elmlist = ""
        'If lstvElements.Items.Count > 0 Then
        '    elmlist = "describedBy = " & lstvElements.Items(0).Text
        '    For i = 1 To lstvElements.Items.Count - 1
        '        elmlist = elmlist & " OR  describedBy = " & lstvElements.Items(i).Text
        '    Next
        'End If
        'elmlist = "(" & elmlist & ")"

        'dttPeriod = "(obsDatetime between '" & sdate & "' and '" & edate & "') "
        ''sql = "Select * from " & tblName & " where " & stnlist & " AND " & elmlist

        'sql = sql & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') "

        'advcSelect = ""

        ''Check if any QC status is selected
        'If setQCstatus(qcStatus) Then
        '    'sql = sql & " AND qcStatus = " & qcStatus
        '    advcSelect = advcSelect & " And qcStatus = " & qcStatus
        'End If

        ''Check if any acquisitionStatus is selected
        'If setAQstatus(acquisitionStatus) Then
        '    'sql = sql & " AND acquisitionType = " & acquisitionStatus
        '    advcSelect = advcSelect & " And acquisitionType = " & acquisitionStatus
        'End If

        '' Check if any flag is selected
        'If selectFlag(flag) Then
        '    'sql = sql & " AND flag = " & flag
        '    advcSelect = advcSelect & " And right(flag,1) = " & flag
        'End If

        ''Check if any key entry form is selected
        'If selectForm(frm) Then
        '    'sql = sql & " AND acquisitionType = " & acquisitionStatus
        '    advcSelect = advcSelect & " And dataForm = " & frm
        'End If

        'If Not showRecords() Then
        '    MsgBox("Can't show any record")
        '    grpButtons.Enabled = False
        'Else
        '    grpButtons.Enabled = True
        'End If
    End Sub
End Class