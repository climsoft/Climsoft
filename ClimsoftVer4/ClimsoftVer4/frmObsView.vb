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

            sql = "SELECT * FROM station where stationName IS NOT NULL ORDER BY stationName"

            'sql = "SELECT recordedFrom, stationName from observationfinal INNER JOIN station ON recordedFrom = stationId group by recordedFrom  ORDER BY stationName;"

            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "station")
            'conn.Close()

            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    MessageBox.Show(ex.Message)
            'End Try

            maxRows = ds.Tables("station").Rows.Count
            'MsgBox(maxRows)
            For kount = 0 To maxRows - 1 Step 1
                If Len(ds.Tables("station").Rows(kount).Item("stationName")) > 0 Then cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))
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

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
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
            txtQualifier.Visible = True
        Else
            txtQualifier.Visible = False
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


    Private Sub chkQaulifier_CheckedChanged(sender As Object, e As EventArgs) Handles chkQaulifier.CheckedChanged
        If chkQaulifier.Checked And lstQualifier.Items.Count > 0 Then
            lstQualifier.Enabled = True
        Else
            lstQualifier.Enabled = False
            chkQaulifier.Checked = False
        End If
    End Sub

    Private Sub chkDbasin_CheckedChanged(sender As Object, e As EventArgs) Handles chkDbasin.CheckedChanged
        If chkDbasin.Checked And lstDBasin.Items.Count > 0 Then
            lstDBasin.Enabled = True
        Else
            lstDBasin.Enabled = False
            chkDbasin.Checked = False
        End If

    End Sub

    Private Sub chkCountry_CheckedChanged(sender As Object, e As EventArgs) Handles chkCountry.CheckedChanged
        If chkCountry.Checked Then
            lstCountry.Enabled = True
            ListStationMetadata("country")
        Else
            lstCountry.Enabled = False
            lstCountry.Items.Clear()
        End If
    End Sub

    Private Sub chkAuthority_CheckedChanged(sender As Object, e As EventArgs) Handles chkAuthority.CheckedChanged
        If chkAuthority.Checked And lstAuthority.Items.Count > 0 Then
            lstAuthority.Enabled = True
        Else
            lstAuthority.Enabled = False
            chkAuthority.Checked = False
        End If
    End Sub

    Private Sub chkAdmin1_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdmin1.CheckedChanged
        If chkAdmin1.Checked And lstAdmin1.Items.Count > 0 Then
            lstAdmin1.Enabled = True
        Else
            lstAdmin1.Enabled = False
            chkAdmin1.Checked = False
        End If
    End Sub

    Private Sub chkAdmin2_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdmin2.CheckedChanged
        If chkAdmin2.Checked And lstAdmin2.Items.Count > 0 Then
            lstAdmin2.Enabled = True
        Else
            lstAdmin2.Enabled = False
            chkAdmin2.Checked = False
        End If
    End Sub

    Private Sub chkAdmin3_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdmin3.CheckedChanged
        If chkAdmin3.Checked And lstAdmin3.Items.Count > 0 Then
            lstAdmin3.Enabled = True
        Else
            lstAdmin3.Enabled = False
            chkAdmin3.Checked = False
        End If
    End Sub

    Private Sub chkAdmin4_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdmin4.CheckedChanged
        If chkAdmin4.Checked And lstAdmin4.Items.Count > 0 Then
            lstAdmin4.Enabled = True
        Else
            lstAdmin4.Enabled = False
            chkAdmin4.Checked = False
        End If
    End Sub

    Private Sub lstCountry_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCountry.SelectedIndexChanged
        PopulateMetadataItem("authority", lstAuthority, chkAuthority) ' Authority
        PopulateMetadataItem("qualifier", lstQualifier, chkQaulifier)  ' Qualifier
        PopulateMetadataItem("drainageBasin", lstDBasin, chkDbasin)  ' Drainage Basin
        PopulateMetadataItem("adminRegion", lstAdmin1, chkAdmin1)  ' Admin Region1
        PopulateMetadataItem("adminRegion2", lstAdmin2, chkAdmin2)  ' Admin Region2
        PopulateMetadataItem("adminRegion3", lstAdmin3, chkAdmin3)  ' Admin Region3
        PopulateMetadataItem("adminRegion4", lstAdmin4, chkAdmin4)  ' Admin Region4

        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 ORDER BY  StationName;"

        PopulateStations(sql)
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        'viewRecords()

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

    Private Sub lstAuthority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAuthority.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) and authority = '" & lstAuthority.SelectedItem & "' > 0 ORDER BY authority;"

        PopulateStations(sql)
    End Sub

    Private Sub lstQualifier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstQualifier.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and qualifier = '" & lstQualifier.SelectedItem & "' ORDER BY qualifier;"
        PopulateStations(sql)
    End Sub

    Private Sub lstDBasin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDBasin.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and drainageBasin = '" & lstDBasin.SelectedItem & "' ORDER BY drainageBasin;"
        PopulateStations(sql)
    End Sub

    Private Sub lstAdmin1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAdmin1.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and AdminRegion = '" & lstAdmin1.SelectedItem & "' ORDER BY AdminRegion;"
        PopulateStations(sql)

    End Sub

    Private Sub lstAdmin2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAdmin2.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and AdminRegion2 = '" & lstAdmin2.SelectedItem & "' ORDER BY AdminRegion2;"
        PopulateStations(sql)
    End Sub

    Private Sub lstAdmin3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAdmin3.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and AdminRegion3 = '" & lstAdmin3.SelectedItem & "' ORDER BY AdminRegion3;"
        PopulateStations(sql)
    End Sub

    Private Sub lstAdmin4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAdmin4.SelectedIndexChanged
        sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and AdminRegion4 = '" & lstAdmin4.SelectedItem & "' ORDER BY AdminRegion4;"
        PopulateStations(sql)
    End Sub

    Private Sub chkFlags_CheckedChanged(sender As Object, e As EventArgs) Handles chkFlags.CheckedChanged
        If chkFlags.Checked Then
            lstBoxFlags.Enabled = True
        Else
            lstBoxFlags.Enabled = False
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        SelectRecords()

        ' Backup stations
        sql = "SELECT * FROM station;"
        If Not BackupRecords("station", sql) Then
            MsgBox("Backup Failure")
            Exit Sub
        Else
            'MsgBox("Backup of stations Successfully Completed")
        End If

        ' Backup elements
        sql = "SELECT * FROM obselement;"
        If Not BackupRecords("obselement", sql) Then
            MsgBox("Backup Failure")
            Exit Sub
        Else
            'MsgBox("Backup of Elements Successfully Completed")
        End If

        ' Backup observations
        sql = "SELECT * From " & tblName & " WHERE " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"
        If Not BackupRecords(tblName, sql) Then
            MsgBox("Backup Failure")
        Else
            'MsgBox("Backup of observations Successfully Completed")
            MsgBox("Backup Successfully Completed")
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

            sql = "SELECT recordedFrom, stationName FROM " & tblName & " INNER JOIN station ON stationId = recordedFrom GROUP BY recordedFrom;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "stations")

            maxRows = (ds.Tables("stations").Rows.Count)

            Dim strs(2) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                With ds.Tables("stations").Rows(kount)
                    If IsDBNull(.Item("recordedFrom")) Or IsDBNull(.Item("stationName")) Then Continue For ' Skip station with NULL values
                    strs(0) = .Item("recordedFrom")
                    strs(1) = .Item("stationName")
                End With
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


            sql = "SELECT describedBy, elementName,description  FROM " & tblName & " INNER JOIN obselement ON elementId = describedBy GROUP BY describedBy;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "Elements")

            maxRows = (ds.Tables("Elements").Rows.Count)

            Dim strs(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                With ds.Tables("Elements").Rows(kount)
                    If IsDBNull(.Item("describedBy")) Or IsDBNull(.Item("elementName")) Or IsDBNull(.Item("description")) Then Continue For ' Skip element with NULL values
                    strs(0) = .Item("describedBy")
                    strs(1) = .Item("elementName")
                    strs(2) = .Item("description")
                End With
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
            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "station")

            maxRows = (ds.Tables("station").Rows.Count)
            'MsgBox(maxRows)
            'MsgBox(ds.Tables("station").Rows(0).Item("stationId") & " " & ds.Tables("station").Rows(0).Item("stationName"))

            If maxRows > 0 Then
                'cmbstation.Text = ""
                cmbstation.BackColor = Color.White
                'MsgBox(ds.Tables("station").Rows(0).Item("stationId") & " " & ds.Tables("station").Rows(0).Item("stationName"))
            Else
                cmbstation.BackColor = Color.Red
                Exit Sub
            End If

            str(0) = ds.Tables("station").Rows(0).Item("stationId")
            str(1) = ds.Tables("station").Rows(0).Item("stationName")

            'MsgBox(str(0) & " " & str(1))
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
            cmbstation.Text = ""
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

                ' Select stations grouping
                ' Check if country is selected
                'If lstCountry.SelectedItem <> String.Empty Then
                '    advcSelect = advcSelect & " AND country = '" & lstCountry.SelectedItem & "'"
                'End If

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
    Sub SelectRecords()
        'With TabObservations.SelectedTab
        '    If .TabIndex = 1 Then

        sdate = Year(dtpDateFrom.Text) & "-" & Month(dtpDateFrom.Text) & "-" & DateAndTime.Day(dtpDateFrom.Text) & " " & cboHourStart.Text & ":" & cboMinuteStart.Text & ":00"
                edate = Year(dtpDateTo.Text) & "-" & Month(dtpDateTo.Text) & "-" & DateAndTime.Day(dtpDateTo.Text) & " " & cboHourEnd.Text & ":" & cboMinuteEnd.Text & ":00"


                stnlist = ""
                If lstvStations.Items.Count > 0 Then
                    stnlist = "recordedFrom = '" & lstvStations.Items(0).Text & "'"
                    For i = 1 To lstvStations.Items.Count - 1
                        stnlist = stnlist & " OR RecordedFrom = " & "'" & lstvStations.Items(i).Text & "'"
                    Next
                End If
                stnlist = "(" & stnlist & ")"

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

                sql = sql & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') "
        'MsgBox(sql)
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

        'MsgBox(advcSelect)


    End Sub

    Function showRecords() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            'sql1 = sql1 & ";"
            Selectflds = "select recordedFrom as Station_id,describedBy as Element_code,year(obsDatetime) as 'Year',month(obsDatetime) as 'Month',day(obsDatetime) as 'Day',time(obsDatetime) as 'Time',obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone"
            sql = Selectflds & " From " & tblName & " INNER JOIN station ON recordedFrom = stationId WHERE " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"

            'sql = "Select * From " & tblName & " Where " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"

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
            If ex.HResult = -2147467259 Then
                MsgBox("Check Selections")
            Else
                MsgBox(ex.Message & "showRecords")
            End If

            Me.Cursor = Cursors.Default
            Return False
        End Try
    End Function
    Function BackupRecords(tbl As String, sql As String) As Boolean
        Dim con0 As New MySql.Data.MySqlClient.MySqlConnection
        Dim a As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim s As New DataSet
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        Dim outDataDir, outDataFile, connstr, dat, xt As String
        Dim objcommon As New dataEntryGlobalRoutines

        Try
            Me.Cursor = Cursors.WaitCursor

            outDataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            ' Create the directory if not existing
            If Not IO.Directory.Exists(outDataDir) Then
                IO.Directory.CreateDirectory(outDataDir)
            End If
            outDataFile = outDataDir & "\" & tbl & ".csv"

            If IO.File.Exists(outDataFile) Then
                IO.File.Delete(outDataFile)
            End If
            FileOpen(17, outDataFile, OpenMode.Output)

            connstr = frmLogin.txtusrpwd.Text
            con0.ConnectionString = connstr
            con0.Open()

            'sql = "SELECT * From " & tbl & " WHERE " & stnlist & " And " & elmlist & " And " & dttPeriod & advcSelect & ";"
            'MsgBox(sql)

            a = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, con0)
            a.SelectCommand.CommandTimeout = 0
            s.Clear()
            a.Fill(s, "backup")
            con0.Close()

            If s.Tables("backup").Rows.Count = 0 Then ' No records to backup
                Me.Cursor = Cursors.Default
                MsgBox("No data found to backup")
                FileClose(17)
                Return False
            End If

            'MsgBox(s.Tables("backup").Rows.Count)

            With s.Tables("backup")
                For i = 0 To .Rows.Count - 1
                    dat = .Rows(i).Item(0)

                    For j = 1 To .Columns.Count - 1
                        If IsDBNull(.Rows(i).Item(j)) Then
                            xt = "\N"
                        Else
                            xt = .Rows(i).Item(j)
                        End If
                        If .Columns(j).ColumnName = "obsDatetime" And IsDate(xt) Then xt = DateAndTime.Year(xt) & "-" & DateAndTime.Month(xt) & "-" & DateAndTime.Day(xt) & " " & DateAndTime.TimeValue(xt)
                        dat = dat & "," & xt
                    Next
                    PrintLine(17, dat)
                Next
            End With
            FileClose(17)
            Me.Cursor = Cursors.Default
            'Return True

        Catch ex As Exception
            FileClose(17)
            con0.Close()
            MsgBox("Check Selections!")
            Me.Cursor = Cursors.Default
            Return False
        End Try

        ' Connect to remote server and backup the selected data
        Dim conn0 As New MySql.Data.MySqlClient.MySqlConnection
        Dim builder As New Common.DbConnectionStringBuilder()

        Try
            ' Build the connection to the remote server
            builder.ConnectionString = ""
            builder("server") = objcommon.RegkeyValue("key13") '"localhost"
            builder("database") = "mariadb_climsoft_db_v4"
            builder("port") = objcommon.RegkeyValue("key18") '"3308"
            builder("uid") = frmLogin.txtUsername.Text
            builder("pwd") = frmLogin.txtPassword.Text

            connstr = builder.ConnectionString & ";Convert Zero Datetime=True"
            'MsgBox(connstr)
            conn0.ConnectionString = connstr
            conn0.Open()

            outDataFile = Strings.Replace(outDataFile, "\", "/")

            If tbl = tblName Then
                sql = "LOAD DATA LOCAL INFILE '" & outDataFile & "' REPLACE INTO TABLE " & tbl & " FIELDS TERMINATED BY ',';" ' (" & flds & ");"
                'MsgBox(sql)
            Else
                sql = "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
                   /*!40101 SET NAMES utf8mb4 */;
                   /*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
                   /*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
                   /*!40000 ALTER TABLE `" & tbl & "` DISABLE KEYS */;
                   LOAD DATA LOCAL INFILE '" & outDataFile & "' REPLACE INTO TABLE " & tbl & " FIELDS TERMINATED BY ',';
                   /*!40000 ALTER TABLE `" & tbl & "` ENABLE KEYS */;
                   /*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
                   /*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
                   /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"
            End If

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn0)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn0.Close()

        Catch ex As Exception
            conn0.Close()
            MsgBox(ex.Message & " at BackupRecords")
            Return False
        End Try
        Return True

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
    Function ListStationMetadata(lstn As String) As Boolean

        Try
            sql = "SELECT country FROM station WHERE country IS NOT NULL AND LENGTH(country) > 0 GROUP BY country order BY country ;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "stations")

            With ds.Tables("stations")
                For i = 0 To .Rows.Count
                    If .Rows(i).Item(0) <> String.Empty Then lstCountry.Items.Add(.Rows(i).Item(0))
                Next

            End With

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function PopulateMetadataItem(itm As String, lst As ListBox, chk As CheckBox) As Boolean

        Try

            sql = "SELECT " & itm & " FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND " & itm & " IS NOT NULL AND LENGTH( " & itm & ") > 0 GROUP BY  " & itm & " ORDER BY  " & itm & ";"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "stations")


            lst.Items.Clear()

            With ds.Tables("stations")

                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item(itm) <> String.Empty Then lst.Items.Add(.Rows(i).Item(itm))
                Next
                lst.Refresh()
                If .Rows.Count = 0 Then
                    chk.Checked = False
                End If

            End With

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Sub lstCountry_Click(sender As Object, e As EventArgs) Handles lstCountry.Click
        'PopulateMetadataItem("authority", lstCountry.SelectedItem, lstAuthority)
    End Sub

    Sub PopulateStations(sql As String)
        Dim Str(2) As String
        Dim itm = New ListViewItem
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "metadata")

            With ds.Tables("metadata")
                lstvStations.Items.Clear()
                If .Rows.Count > 0 Then
                    For i = 0 To .Rows.Count - 1
                        Str(0) = ds.Tables("metadata").Rows(i).Item("stationId")
                        Str(1) = ds.Tables("metadata").Rows(i).Item("stationName")
                        itm = New ListViewItem(Str)

                        ItmExist = False
                        If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                            lstvStations.Items.Add(itm)
                        Else
                            For j = 0 To lstvStations.Items.Count - 1
                                ' Check if the item has been added in the list and skip it if so
                                If Str(0) = lstvStations.Items(j).Text Then
                                    ItmExist = True
                                    Exit For
                                End If
                            Next
                            If Not ItmExist Then lstvStations.Items.Add(itm)
                        End If
                    Next
                End If
            End With
        Catch ex As Exception

        End Try

    End Sub

    'Private Sub lstQualifier_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstQualifier.SelectedValueChanged
    '    sql = "SELECT stationId, stationName FROM station WHERE country ='" & lstCountry.SelectedItem & "' AND StationName IS NOT NULL AND LENGTH(StationName) > 0 and qualifier = '" & lstQualifier.SelectedItem & "' ORDER BY qualifier;"
    '    PopulateStations(sql)
    'End Sub


    'Sub viewRecords()

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

End Class