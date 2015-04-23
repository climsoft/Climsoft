Public Class formDatabaseConnect
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    'Dim inc As Integer
    'Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    ' Dim ds As New DataSet
    'Dim sql As String
    'Dim maxRows As Integer


    Private Sub btnDatabaseConnect_Click(sender As Object, e As EventArgs) Handles btnDatabaseConnect.Click

        usrName = userName.Text
        usrPwd = passWord.Text
        dbServer = ServerIP.Text
        dbName = databaseName.Text
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

            MsgBox("Connection Successful !", MsgBoxStyle.Information)

            '  sql = "SELECT * FROM station"
            ' da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            '  da.Fill(ds, "station")
            ' conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        'inc = inc + 1
        ' maxRows = ds.Tables("station").Rows.Count
        'txtStationId.Text = ds.Tables("station").Rows(inc).Item("stationId")
        'txtStationName.Text = ds.Tables("station").Rows(inc).Item("stationName")
        ' txtRecNumber.Text = "Record " & inc + 1 & " of " & maxRows
        'txtRecNumber.Refresh()
        'txtStationId.Refresh()
        'txtStationName.Refresh()
    End Sub

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles Me.Load
        'inc = -1
    End Sub
End Class
