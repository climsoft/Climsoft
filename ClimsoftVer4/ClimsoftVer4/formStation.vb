Public Class formStation
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formStation_Load(sender As Object, e As EventArgs) Handles Me.Load

        inc = -1
        usrName = formDatabaseConnect.userName.Text
        usrPwd = formDatabaseConnect.passWord.Text
        dbServer = formDatabaseConnect.ServerIP.Text
        dbName = formDatabaseConnect.databaseName.Text

        ' myConnectionString = "server=127.0.0.1;" _
        '          & "uid=root;" _
        '          & "pwd=admin;" _
        '         & "database=mysql_climsoft_db_v4;"
        myConnectionString = "server=" & dbServer & ";" _
                & "uid=" & usrName & ";" _
                & "pwd=" & usrPwd & ";" _
                & "database=" & dbName & ";"
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM station"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "station")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        maxRows = ds.Tables("station").Rows.Count

        inc = 0

        StationIdTextBox.Text = ds.Tables("station").Rows(inc).Item("stationId")
        StationNameTextBox.Text = ds.Tables("station").Rows(inc).Item("stationName")
        CountryTextBox.Text = ds.Tables("station").Rows(inc).Item("country")
        LatitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("latitude")
        LongitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("longitude")
        ElevationTextBox.Text = ds.Tables("station").Rows(inc).Item("elevation")
        ' OpeningDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("openingdatetime")
        ' ClosingDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("closingdatetime")
        'AuthorityTextBox.Text = ds.Tables("station").Rows(inc).Item("authority")
        ' AdminRegionTextBox.Text = ds.Tables("station").Rows(inc).Item("adminregion")
        ' DrainageBasinTextBox.Text = ds.Tables("station").Rows(inc).Item("drainagebasin")
        ' GeoLocationMethodTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationmethod")
        'GeoLocationAccuracyTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationaccuracy")
        'CptSelectionTextBox.Text = ds.Tables("station").Rows(inc).Item("cptselection")
        'StationOperationalTextBox.Text = ds.Tables("station").Rows(inc).Item("stationoperational")
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows

    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        inc = inc + 1
        StationIdTextBox.Text = ds.Tables("station").Rows(inc).Item("stationId")
        StationNameTextBox.Text = ds.Tables("station").Rows(inc).Item("stationName")
        CountryTextBox.Text = ds.Tables("station").Rows(inc).Item("country")
        LatitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("latitude")
        LongitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("longitude")
        ElevationTextBox.Text = ds.Tables("station").Rows(inc).Item("elevation")
        ' OpeningDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("openingdatetime")
        ' ClosingDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("closingdatetime")
        'AuthorityTextBox.Text = ds.Tables("station").Rows(inc).Item("authority")
        ' AdminRegionTextBox.Text = ds.Tables("station").Rows(inc).Item("adminregion")
        ' DrainageBasinTextBox.Text = ds.Tables("station").Rows(inc).Item("drainagebasin")
        ' GeoLocationMethodTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationmethod")
        'GeoLocationAccuracyTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationaccuracy")
        'CptSelectionTextBox.Text = ds.Tables("station").Rows(inc).Item("cptselection")
        'StationOperationalTextBox.Text = ds.Tables("station").Rows(inc).Item("stationoperational")
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
End Class