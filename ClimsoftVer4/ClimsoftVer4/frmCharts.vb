Public Class frmCharts
    Public stns, elmlist, elmcolmn, sdt, edt, SumAvg, SummaryType, graphType As String

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim con As New MySql.Data.MySqlClient.MySqlConnection
    Dim sql, MyConnectionString As String


    Private Sub chtitle_TextChanged(sender As Object, e As EventArgs) Handles txtchtitle.TextChanged
        MSChart1.Titles.Clear()
        MSChart1.Titles.Add(txtchtitle.Text).Alignment = ContentAlignment.TopCenter
        MSChart1.Show()
    End Sub

    Private Sub chY_TextChanged(sender As Object, e As EventArgs) Handles txtchY.TextChanged
        MSChart1.ChartAreas("ChartArea1").AxisY.Title = txtchY.Text
    End Sub

    Private Sub cmdview_Click(sender As Object, e As EventArgs) Handles cmdview.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Me.Cursor = Cursors.WaitCursor
        Try
            With formDataView
                .grpSearch.Enabled = False
                .btnDelete.Enabled = False
                .btnHelp.Enabled = False
                .btnUpdate.Enabled = False
                .cmdEdit.Enabled = False
                .cmdExport.Enabled = False
            End With

            viewRecords.viewTableRecords(sql)
            Me.Cursor = Cursors.Default

            grpSummary.Enabled = False

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Can't view data. Check data selections")
        End Try
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs)
        Dim SaveData As New formProductsSelectCriteria
        Me.Cursor = Cursors.WaitCursor
        SaveData.DataProducts(sql, "")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub txtFootNote_TextChanged(sender As Object, e As EventArgs)
        'create the header And footer titles

        'MSChart1.Titles.Add(txtFootNote.Text).Alignment = ContentAlignment.BottomLeft

    End Sub

    Private Sub comdSave_Click(sender As Object, e As EventArgs) Handles comdSave.Click
        Dim Chartfile, ChartfileExt As String
        dlgChart.FilterIndex = 2
        dlgChart.Filter = "PNG|*.png|JPEG|*.jpeg|JIF|*.gif|TIF|*.tif|BMP|*.bmp|WMF|*.wmf"

        dlgChart.AddExtension = True
        'dlgChart.CheckFileExists = True

        dlgChart.Title = "Save Chart"
        dlgChart.ShowDialog()

        Chartfile = dlgChart.FileName
        ChartfileExt = IO.Path.GetExtension(Chartfile).ToLower
        Try

            ' Set the image file format according to fileextension selected
            Select Case ChartfileExt
                Case ".png"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Png)
                Case ".jpeg"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Jpeg)
                Case ".gif"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Gif)
                Case ".tif"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Tiff)
                Case ".bmp"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Bmp)
                Case ".wmf"
                    MSChart1.SaveImage(Chartfile, System.Drawing.Imaging.ImageFormat.Wmf)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'MSChart1.SaveImage("C:\data\Charts.png", System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        MSChart1.Printing.Print(True)
    End Sub


    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#Charts")
    End Sub


    Private Sub chX_TextChanged(sender As Object, e As EventArgs) Handles txtchX.TextChanged
        MSChart1.ChartAreas("ChartArea1").AxisX.Title = txtchX.Text

    End Sub

    Private Sub frmCharts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MSChart1.Series.Clear()

    End Sub


    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim con As New MySql.Data.MySqlClient.MySqlConnection
    Dim sql, MyConnectionString As String

    Private Sub cmdPlot_Click(sender As Object, e As EventArgs) Handles cmdPlot.Click
        Dim recmx As Long
        Dim flds As Integer
        Dim ChTile As String

        Try
            Me.Cursor = Cursors.WaitCursor
            MyConnectionString = frmLogin.txtusrpwd.Text
            con.ConnectionString = MyConnectionString
            con.Open() '

            If optDaily.Checked Then

                Sql = "SELECT recordedFrom as StationId,stationName as Station_Name,latitude as Lat, longitude as Lon,elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day," & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, StationName, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " &
              "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdt & "' and '" & edt & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime);"
                ChTile = "Daily Summaries"
            ElseIf optDekadal.Checked Then
                Sql = "SELECT recordedFrom as StationId, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, " & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude,elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                   "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdt & "' and '" & edt & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,DEKAD;"
                ChTile = "Dekadal Summaries"
            ElseIf optMonthly.Checked Then
                Sql = "SELECT recordedFrom as StationId, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation,describedBy, stationName, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                   "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdt & "' and '" & edt & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Year, Month;"
                ChTile = "Monthly Summaries"
            ElseIf optAnnual.Checked Then
                Sql = "SELECT recordedFrom as StationId, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year," & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &

                   "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdt & "' And '" & edt & "') ORDER BY recordedFrom, year(obsDatetime)) t GROUP BY StationId,Year;"
                ChTile = "Annual Summaries"
            End If



            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, con)

            ds.Clear()
            da.Fill(ds, "charts")
            recmx = ds.Tables("charts").Rows.Count
            con.Close()

            Me.Refresh()

            MSChart1.Series.Clear()

            'To develop code for determining the data fields
            Dim dcl As Integer
            Dim hdr, hdrs, dttime As String

            hdrs = "StationIdStation_NameLatLonElevYearMonthDayDEKADHourMinute"
            dcl = 0

            For i = 0 To ds.Tables("charts").Columns.Count - 1
                hdr = ds.Tables("charts").Columns.Item(i).ToString

                If InStr(hdrs, hdr) = 0 Then
                    dcl = dcl + 1
                End If
            Next

            ' Define Series

            flds = ds.Tables("charts").Columns.Count

            For i = 1 To dcl
                If graphType = "TimeSeries" Then
                    MSChart1.Series.Add(ds.Tables("charts").Columns.Item(flds - i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                ElseIf graphType = "Histograms" Then
                    MSChart1.Series.Add(ds.Tables("charts").Columns.Item(flds - i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Column
                End If
                'frmCharts.MSChart1.Series(ds.Tables("charts").Columns.Item(flds - i).ToString).Color = Color.DarkBlue
            Next

            ' Add data to series
            For i = 0 To ds.Tables("charts").Rows.Count - 1

                ' Compute datetime value for each record
                dttime = ""
                For j = 0 To ds.Tables("charts").Columns.Count - 1
                    If ds.Tables("charts").Columns.Item(j).ToString = "Year" Then dttime = ds.Tables("charts").Rows(i).Item(j)

                    If InStr("MonthDayDEKADHourMinute", ds.Tables("charts").Columns.Item(j).ToString) <> 0 Then
                        dttime = dttime & "/" & ds.Tables("charts").Rows(i).Item(j)
                    End If
                Next

                For j = 1 To dcl
                    MSChart1.Series(ds.Tables("charts").Columns.Item(flds - j).ToString).Points.AddXY(dttime, ds.Tables("charts").Rows(i).Item(flds - j))
                Next
            Next

            MSChart1.ChartAreas("ChartArea1").AxisX.Title = "Time"
            MSChart1.ChartAreas("ChartArea1").AxisY.Title = "Values"
            MSChart1.Titles.Clear()
            MSChart1.Titles.Add(ChTile).Alignment = ContentAlignment.TopCenter

            MSChart1.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = True
            MSChart1.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
            MSChart1.Show()

            Me.Cursor = Cursors.Default
            grpSummary.Enabled = False

            cmdview.Enabled = True


        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Can't Plot Chart. Check data selections")
        End Try
    End Sub
End Class