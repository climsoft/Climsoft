Public Class acmadMicrofiche
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String = My.Settings.defaultDatabase
    Private Sub acmadMicrofiche_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dgvSaisie.Rows().Add()

        Dim dsStation As New DataSet
        Dim sqlStation As String ', myConnectionString As String
        Dim daStation As MySql.Data.MySqlClient.MySqlDataAdapter
        sqlStation = "SELECT stationId,stationName FROM station ORDER by stationName;"
        myConnectionString = My.Settings.defaultDatabase


        'System.Configuration.ConfigurationManager.ConnectionStrings("My_ConnectionString").ConnectionString
        'frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()
            daStation = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlStation, conn)
            daStation.Fill(dsStation, "station")
            'dsStation.Tables("station").Rows(0).Item(0).ToString
            If dsStation.Tables("station").Rows.Count > 0 Then
                'Populate station combobox
                With cboStation
                    .DataSource = dsStation.Tables("station")
                    .DisplayMember = "stationName"
                    .ValueMember = "stationId"
                    .SelectedIndex = 0
                End With
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

        loadData()
    End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStation.SelectedIndexChanged
        Dim dsStation As New DataSet
        Dim sqlStation As String ', myConnectionString As String
        Dim daStation As MySql.Data.MySqlClient.MySqlDataAdapter
        sqlStation = "SELECT * FROM station  where stationId='" & cboStation.SelectedItem(0) & "' ORDER by stationName;"

        'frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()
            daStation = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlStation, conn)
            daStation.Fill(dsStation, "station")
            'dsStation.Tables("station").Rows(0).Item(0).ToString
            If dsStation.Tables("station").Rows.Count > 0 Then
                'Populate station combobox
                'With cboStation
                '    .DataSource = dsStation.Tables("station")
                '    .DisplayMember = "stationName"
                '    .ValueMember = "stationId"
                '    .SelectedIndex = 0
                'End With
                txtLatitude.Text = dsStation.Tables("station").Rows(0).Item(2).ToString
                txtLongitude.Text = dsStation.Tables("station").Rows(0).Item(3).ToString
                txtElevation.Text = dsStation.Tables("station").Rows(0).Item(4).ToString
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub btnValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValider.Click
        Dim strSql As String = "INSERT INTO `acmad_microfiche_data_inventory` (`id`, `station_id`, `parameter_code`, `begin_month_year`, `end_month_year`, `no_of_images`, `microfiche_ref`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", '" & Me.dgvSaisie.Rows(0).Cells(0).Value & "', '" & Me.dgvSaisie.Rows(0).Cells(1).Value & "', '" & Me.dgvSaisie.Rows(0).Cells(2).Value & "', " & Me.dgvSaisie.Rows(0).Cells(3).Value & ", '" & Me.dgvSaisie.Rows(0).Cells(4).Value & "');"
        MsgBox(strSql)

        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand = New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()
            objCmd.ExecuteNonQuery()
            loadData()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub
    Private Sub loadData()
        Dim ds As New DataSet
        Dim i As Int16 = 0
        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim strSql As String = "SELECT  `id`, `station_id`, `parameter_code`, `begin_month_year`, `end_month_year`, `no_of_images`, `microfiche_ref` FROM `acmad_microfiche_data_inventory` "
        myConnectionString = My.Settings.defaultDatabase

        Try
            'conn.ConnectionString = myConnectionString
            conn.Open()

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(strSql, conn)
            da.Fill(ds, "datas")
            dgvList.DataSource = ds.Tables("datas")
            'For i = 0 To 11
            '    dgvList.Columns(i).Width = 40
            'Next
            dgvList.Columns(0).Visible = False
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub
End Class