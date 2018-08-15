Public Class frmPlotter

    'Private Sub frmPlotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim conn As MySql.Data.MySqlClient.MySqlConnection
    '    'Dim conString, MySQLUserName, MySQLPW, MySQLDB, MySQLHost,
    '    Dim conString, SQLDataString, SQLElementString As String

    '    'MySQLUserName = "root"
    '    'MySQLPW = "admin"
    '    'MySQLDB = "mariadb_climsoft_db_v4"
    '    'MySQLHost = "localhost"

    '    conString = frmLogin.txtusrpwd.Text '"server=" + MySQLHost + ";port=3306;uid=" + MySQLUserName + ";pwd=" + MySQLPW + ";database=" + MySQLDB

    '    SQLElementString = "SELECT DISTINCT obselement.elementName " & _
    '                        "FROM obselement,missing_stats " & _
    '                        "WHERE obselement.elementId=missing_stats.Element"

    '    SQLDataString = "SELECT stationName, elementName, opening_record_date, closing_record_date, missing_amount " & _
    '                    "FROM missing_stats,obselement,station " & _
    '                    "WHERE missing_stats.Station=station.stationId " & _
    '                    "AND obselement.elementId=missing_stats.Element"

    '    conn = New MySql.Data.MySqlClient.MySqlConnection
    '    conn.ConnectionString = conString

    '    Try
    '        conn.Open()
    '        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    '        Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    '        Dim ds As New System.Data.DataSet
    '        Dim i As Integer

    '        cmd.CommandText = SQLElementString
    '        cmd.CommandType = CommandType.Text
    '        cmd.Connection = conn

    '        da.SelectCommand = cmd
    '        da.Fill(ds, "MissingElements")

    '        cmd.CommandText = SQLDataString
    '        cmd.CommandType = CommandType.Text
    '        cmd.Connection = conn

    '        da.SelectCommand = cmd
    '        da.Fill(ds, "MissingData")

    '        'Preparing the graph
    '        InvChart.Series.Clear()
    '        InvChart.Titles.Add("Total Missing Records" & vbNewLine & "Per Station Per Element").Alignment = ContentAlignment.TopCenter
    '        InvChart.ChartAreas("ChartArea1").AxisX.Title = "Station Name"
    '        InvChart.ChartAreas("ChartArea1").AxisY.Title = "Total Missing"

    '        ' Preparing Series Name using elements name
    '        For i = 0 To ds.Tables("MissingElements").Rows.Count - 1
    '            InvChart.Series.Add(ds.Tables("MissingElements").Rows(i).Item(0).ToString)
    '            'InvChart.Series(ds.Tables("MissingElements").Rows(0).Item(0).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Column

    '            'Assigning column color to daily max temp
    '            If ds.Tables("MissingElements").Rows(i).Item(0).ToString = "Temp  Daily Max" Then
    '                InvChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.Red
    '            End If

    '            'Assigning column color to Temp  Daily Min
    '            If ds.Tables("MissingElements").Rows(i).Item(0).ToString = "Temp  Daily Min" Then
    '                InvChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.LawnGreen
    '            End If

    '            'Assigning column color to Precip  Daily
    '            If ds.Tables("MissingElements").Rows(i).Item(0).ToString = "Precip  Daily" Then
    '                InvChart.Series(ds.Tables("MissingElements").Rows(i).Item(0).ToString).Color = Color.Blue
    '            End If
    '        Next i

    '        i = 0

    '        'Fitting Data into Chart Area
    '        For i = 0 To ds.Tables("MissingData").Rows.Count - 1
    '            InvChart.Series(ds.Tables("MissingData").Rows(i).Item(1).ToString).Points.AddXY(ds.Tables("MissingData").Rows(i).Item(0).ToString, ds.Tables("MissingData").Rows(i).Item(4).ToString)
    '        Next i
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub InvChart_DoubleClick(sender As Object, e As EventArgs) Handles InvChart.DoubleClick
    '    Me.Close()
    'End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmPlotter
        '
        Me.ClientSize = New System.Drawing.Size(740, 379)
        Me.Name = "frmPlotter"
        Me.ResumeLayout(False)

    End Sub
End Class