Public Class frmInventoryChart
    Private Sub CmdClose_Click(sender As Object, e As EventArgs) Handles CmdClose.Click
        Me.Close()
    End Sub

    Private Sub frmInventoryChart_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim c As New MySql.Data.MySqlClient.MySqlConnection
        Dim MyCStr As String
        Dim a As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim s As New DataSet

        Dim sql As String

        Try
            Me.Cursor = Cursors.WaitCursor
            MyCStr = frmLogin.txtusrpwd.Text
            c.ConnectionString = MyCStr
            c.Open()

            sql = "Select TT as YY, count(TT) as STATIONS from (select year(obsdatetime) as TT, recordedFrom as ST from observationfinal group by TT, ST) as T group by TT;"

            a = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, c)
            a.SelectCommand.CommandTimeout = 0
            s.Clear()
            a.Fill(s, "inventory")

            With chartInventory

                'Define Series
                .Series.Add(s.Tables("inventory").Columns.Item(1).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Column
                .Series(0).Color = Color.Red

                'For i = 3 To s.Tables("inventory").Columns.Count - 1
                '    .Series.Add(s.Tables("inventory").Columns.Item(i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                'Next

                ' Add data to series
                For i = 0 To s.Tables("inventory").Rows.Count - 1
                    'For j = 3 To 5
                    'Series(ds.Tables("charts").Columns.Item(flds - j).ToString).Points.AddXY(dttime, ds.Tables("charts").Rows(i).Item(flds - j))
                    .Series(s.Tables("inventory").Columns.Item(1).ToString).Points.AddXY(s.Tables("inventory").Rows(i).Item(0), s.Tables("inventory").Rows(i).Item(1))
                    'Next
                Next

                .ChartAreas("ChartArea1").AxisX.Interval = 2
                '.ChartAreas("ChartArea1").AxisY.Interval = 10
                '.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = True
                '.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
                .ChartAreas("ChartArea1").AxisY.MinorGrid.Enabled = True

                ' Add titles
                .Titles.Add(ClsTranslations.GetTranslation("Annual Reporting Stations")).Alignment = ContentAlignment.TopCenter
                .ChartAreas("ChartArea1").AxisX.Title = ClsTranslations.GetTranslation("Years")
                .ChartAreas("ChartArea1").AxisY.Title = ClsTranslations.GetTranslation("Number of Stations")
                .Show()

                With lstSeries
                    .Items.Clear()
                    For i = 0 To chartInventory.Series.Count - 1
                        .Items.Add(chartInventory.Series(i).Name)
                    Next
                End With

                Me.Cursor = Cursors.Default
            End With

            c.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            c.Close()
            Me.Cursor = Cursors.Default
        End Try

        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub comdSave_Click(sender As Object, e As EventArgs) Handles comdSave.Click
        Dim SVchart As New frmCharts

        SVchart.SaveImageFormat(chartInventory)


    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        chartInventory.Printing.Print(True)
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#inventoryChart")
    End Sub

    Private Sub lstSeries_Click(sender As Object, e As EventArgs) Handles lstSeries.Click
        Dim cl As Color

        frmCharts.clrdlg.ShowDialog()
        cl = frmCharts.clrdlg.Color
        chartInventory.Series(lstSeries.SelectedIndex).Color = cl
    End Sub

    Private Sub butXinterval_Click(sender As Object, e As EventArgs) Handles butXinterval.Click
        If Val(txtXinterval.Text) <> 0 Then chartInventory.ChartAreas("ChartArea1").AxisX.Interval = CInt(txtXinterval.Text)

    End Sub

    Private Sub butYinterval_Click(sender As Object, e As EventArgs) Handles butYinterval.Click
        If Val(txtYinterval.Text) <> 0 Then chartInventory.ChartAreas("ChartArea1").AxisY.Interval = CInt(txtYinterval.Text)
    End Sub
End Class