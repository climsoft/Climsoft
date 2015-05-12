Public Class formDatabaseConnect
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    

    Private Sub btnDatabaseConnect_Click(sender As Object, e As EventArgs) Handles btnDatabaseConnect.Click
       
        myConnectionString = txtDbParameters.Text & "uid=" & userName.Text & ";pwd=" & passWord.Text & ";"
        
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' MsgBox("Connection Successful !", MsgBoxStyle.Information)
            Me.Hide()
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
        'Dim configFilename As String = "c:\config\dbconfig.inf"
        Dim configFilename As String = Application.StartupPath & "\config.inf"
        'MsgBox(configFilename)
        Dim objTextReader As New System.IO.StreamReader(configFilename)
        txtDbParameters.Text = objTextReader.ReadLine
    End Sub
End Class
