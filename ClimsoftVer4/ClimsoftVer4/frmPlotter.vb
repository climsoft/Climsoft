Public Class frmPlotter
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents invChart As DataVisualization.Charting.Chart

    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlotter))
        Me.invChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.invChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'invChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.invChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.invChart.Legends.Add(Legend1)
        Me.invChart.Location = New System.Drawing.Point(12, 12)
        Me.invChart.Name = "invChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.invChart.Series.Add(Series1)
        Me.invChart.Size = New System.Drawing.Size(757, 353)
        Me.invChart.TabIndex = 0
        Me.invChart.Text = "Chart1"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(155, 376)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Save Chart"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(278, 376)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(107, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Export Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(419, 376)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmPlotter
        '
        Me.ClientSize = New System.Drawing.Size(785, 408)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.invChart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPlotter"
        CType(Me.invChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private Sub frmPlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As MySql.Data.MySqlClient.MySqlConnection
        Dim conString As String
        Dim SQLDataString, SQLElementString As String

        conString = frmLogin.txtusrpwd.Text

        SQLElementString = "SELECT DISTINCT elementname, elementid FROM obselement, missing_stats WHERE obselement.elementId = missing_stats.ELEM"

        SQLDataString = "SELECT stationname,elementname,missing FROM missing_stats,obselement,station WHERE missing_stats.STN_ID=station.stationId AND obselement.elementId=missing_stats.ELEM"

        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = conString

        Try
            conn.Open()
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New System.Data.DataSet
            Dim i As Integer

            cmd.CommandText = SQLElementString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            da.SelectCommand = cmd
            da.Fill(ds, "MissingElements")

            cmd.CommandText = SQLDataString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            da.SelectCommand = cmd
            da.Fill(ds, "MissingData")

            'Preparing the graph
            invChart.Series.Clear()
            invChart.Titles.Add("Total Missing Records" & vbNewLine & "Per Station Per Element").Alignment = ContentAlignment.TopCenter
            invChart.ChartAreas("ChartArea1").AxisX.Title = "Station Name"
            invChart.ChartAreas("ChartArea1").AxisY.Title = "Total Missing"

            ' Preparing Series Name using Elements Name
            For i = 0 To ds.Tables("MissingElements").Rows.Count - 1
                invChart.Series.Add(ds.Tables("MissingElements").Rows(i).Item(0).ToString)
                invChart.Series(ds.Tables("MissingElements").Rows(0).Item(0).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Column
                'Assigning column color to daily max temp
                If ds.Tables("MissingElements").Rows(i).Item(1).ToString = 2 Then
                    invChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.Red
                End If

                'Assigning column color to Temp  Daily Min
                If ds.Tables("MissingElements").Rows(i).Item(1).ToString = 3 Then
                    invChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.LawnGreen
                End If

                'Assigning column color to Precip  Daily
                If ds.Tables("MissingElements").Rows(i).Item(1).ToString = 5 Then
                    invChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.Blue
                End If
            Next i
            i = 0

            'Fitting Data into Chart Area
            For i = 0 To ds.Tables("MissingData").Rows.Count - 1
                invChart.Series(ds.Tables("MissingData").Rows(i).Item(1).ToString).Points.AddXY(ds.Tables("MissingData").Rows(i).Item(0).ToString, ds.Tables("MissingData").Rows(i).Item(2).ToString)
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conn As MySql.Data.MySqlClient.MySqlConnection
        Dim conString As String
        Dim SQLDataString, SQLGAPSDATA, SQLGAPS As String

        Button2.Enabled = False

        conString = frmLogin.txtusrpwd.Text

        SQLDataString = "SELECT stn_id as Station, Elem as Element,opening_date AS StartDate,closing_date as EndDate From Missing_stats Where missing>0"
        SQLGAPSDATA = "SELECT * FROM gaps"
        SQLGAPS = "SELECT StationName, Description, Year(missing_date) Yr, Month(missing_date) Mm, Day(missing_date) Dd From gaps, station, obselement Where missing_stnid = stationid AND missing_elem = elementid"
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = conString

        Try
            conn.Open()
            Dim cmd, new_cmd As New MySql.Data.MySqlClient.MySqlCommand
            Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New System.Data.DataSet
            Dim i As Integer

            'Create Tables for Gaps
            cmd.Connection = conn
            cmd.CommandText = "refresh_gaps"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()

            'Read Missing Data
            cmd = New MySql.Data.MySqlClient.MySqlCommand
            cmd.CommandText = SQLDataString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            da.SelectCommand = cmd
            da.Fill(ds, "Gaps")

            'Insert Missing Data
            For i = 0 To ds.Tables("Gaps").Rows.Count - 1
                new_cmd = New MySql.Data.MySqlClient.MySqlCommand
                new_cmd.Connection = conn
                new_cmd.CommandText = "find_gaps"
                new_cmd.CommandType = CommandType.StoredProcedure
                new_cmd.CommandTimeout = 0
                new_cmd.Parameters.AddWithValue("Stn", ds.Tables("Gaps").Rows(i).Item(0).ToString)
                new_cmd.Parameters.AddWithValue("Elm", ds.Tables("Gaps").Rows(i).Item(1).ToString)
                new_cmd.Parameters.AddWithValue("Opening_Date", ds.Tables("Gaps").Rows(i).Item(2).ToString)
                new_cmd.Parameters.AddWithValue("Closing_Date", ds.Tables("Gaps").Rows(i).Item(3).ToString)
                new_cmd.ExecuteNonQuery()
                'MsgBox(Format(ds.Tables("Gaps").Rows(i).Item(2).ToString, "yyyy-mm-dd"))
            Next i

            'Open Excel File for Missing Data
            Dim fl As String
            'Read Missing Data
            cmd = New MySql.Data.MySqlClient.MySqlCommand
            cmd.CommandText = SQLGAPS
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            da.SelectCommand = cmd
            da.Fill(ds, "Miss")
            fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Gaps.csv"

            FileOpen(1, fl, OpenMode.Output)

            Write(1, "Station")
            Write(1, "Element")
            Write(1, "Year")
            Write(1, "Month")
            Write(1, "Day")
            PrintLine(1)

            For i = 0 To ds.Tables("Miss").Rows.Count - 1
                Write(1, ds.Tables("Miss").Rows(i).Item(0).ToString)
                Write(1, ds.Tables("Miss").Rows(i).Item(1).ToString)
                Write(1, ds.Tables("Miss").Rows(i).Item(2).ToString)
                Write(1, ds.Tables("Miss").Rows(i).Item(3).ToString)
                Write(1, ds.Tables("Miss").Rows(i).Item(4).ToString)
                PrintLine(1)
            Next i

            FileClose(1)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Button2.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim img As String

        img = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Gaps.Png"
        'img = "C:\Users\UNDP\Desktop\Gaps.Png"

        With invChart
            .Dock = DockStyle.None
            .SaveImage(img, System.Drawing.Imaging.ImageFormat.Png)
        End With
    End Sub
End Class