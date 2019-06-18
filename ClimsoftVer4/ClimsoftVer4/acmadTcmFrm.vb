Imports System.Drawing.Drawing2D


Public Class acmadTcmFrm
    Private Sub acmadTcmFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(TabPage2)
        dgvDirectionVentTcm.Rows.Add()
        dgvTemperationSaisie.Rows.Add()
        dgvTemperatureM.Rows().Add()
        'dgvPrecipitation.Rows().Add()
        dgvTempPresion.Rows().Add()
        dgvNebulosite.Rows().Add()
        dgvVapeurHumidite.Rows().Add()
        dgvDirectionVent.Rows().Add()
        dgvResume.Rows().Add()
        dgvSynSaisie.Rows().Add()
        loadSynData()
        loadPrecipitation()
        loadtemperature()
        loadtemperatureM()
        loadTempPression()
        loadVent()
        loadResume()
        loadNebulosite()
        loadHumidite()
        loadCombobox("SELECT stationId,stationName FROM station ORDER by stationName;", cboStation, "stationName", "stationId")

    End Sub

    Private Sub cboStation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStation.SelectedIndexChanged
        Dim sqlStation As String
        sqlStation = "SELECT * FROM station  where stationId='" & cboStation.SelectedItem(0) & "' ORDER by stationName;"
        Dim dt As DataTable = reload(sqlStation)
        If dt IsNot Nothing Then
            If dt.Rows.Count > 0 Then
                txtLatitude.Text = dt.Rows(0)(2).ToString
                txtLongitude.Text = dt.Rows(0)(3).ToString
                txtElevation.Text = dt.Rows(0)(4).ToString
            End If
        End If
    End Sub
    Private Sub btnPrecipitValid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrecipitValid.Click
        If cmbJours.SelectedItem Is Nothing Or txtVal_6h_18h.Text = "" Or txtVal_matin_soir.Text = "" Or txtVal_matin_soir.Text = "" Or txtVal_piche_1.Text = "" Or txtVal_bac1_1.Text = "" Or txtVal_bac2_1.Text = "" Or txtVal_description_1.Text = "" Then
            MsgBox("Please fill in all textBox")
        Else
            Dim strSQL As String = "INSERT INTO `acmad_precipitations_evaporations` (`id`, `tcm_id`, `month`,`year`,`day`, `6h_18h`, `0h_24h`, `matin_soir`, `soir_lendmatin`, `total_24h`, `piche`, `bac1`, `bac2`, `description`, `image`) " & _
             " VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cmbJours.SelectedItem(0) & ", " & txtVal_6h_18h.Text & ", " & txtVal_0h_24h.Text & ", " & txtVal_matin_soir.Text & ", " & txtVal_soir_lendmatin.Text & ", " & txtVal_total_24h.Text & ", " & txtVal_piche_1.Text & ", " & txtVal_bac1_1.Text & ", " & txtVal_bac2_1.Text & ", '" & txtVal_description_1.Text & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"

            ' MsgBox(strSQL)
            create(strSQL, "data added successful", "Error")
            txtVal_6h_18h.Text = ""
            txtVal_0h_24h.Text = ""
            txtVal_matin_soir.Text = ""
            txtVal_soir_lendmatin.Text = ""
            txtVal_total_24h.Text = ""
            txtVal_piche_1.Text = ""
            txtVal_bac1_1.Text = ""
            txtVal_bac2_1.Text = ""
            txtVal_description_1.Text = ""
            cmbJours.SelectedIndex = -1
            loadPrecipitation()
        End If
    End Sub
    Private Sub loadPrecipitation()
        Dim strSqlPrecipitation As String = "SELECT `id`,  `day` as 'Jours',`6h_18h`, `0h_24h`, `matin_soir`, `soir_lendmatin`, `total_24h`, `piche` as 'Piche', `bac1` as 'BAC m/m et 1/10', `bac2` as 'BAC Vent et Hm', `description` as 'Observation' FROM `acmad_precipitations_evaporations`"
        reloadDataDvgrid(strSqlPrecipitation, dgvPrecipitation)
    End Sub
    Private Sub btnValidTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidTemperature.Click
        If cbJourTemperature.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvTemperationSaisie.Rows(0).Cells(14).Value Is Nothing) Then
                ' MsgBox(dgvTemperationSaisie.Rows(0).Cells(10).Value & " " & dgvTemperationSaisie.Rows(0).Cells(11).Value)
                Dim strSql As String = "INSERT INTO `acmad_tempurters` (`id`, `station_id`,`month`,`year`, `day`, `00`, `03`, `06`,`09`, `12`, `15`, `18`, `21`, `type`, `total`, `moyenne`,`min`, `Hmin`, `max`, `Hmax`, `image`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbJourTemperature.SelectedItem(0) & ", '" & Me.dgvTemperationSaisie.Rows(0).Cells(0).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(1).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(2).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(3).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(4).Value & "','" & Me.dgvTemperationSaisie.Rows(0).Cells(5).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(6).Value & "','" & Me.dgvTemperationSaisie.Rows(0).Cells(7).Value & "', 1, '" & Me.dgvTemperationSaisie.Rows(0).Cells(8).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(9).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(10).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(11).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(12).Value & "', '" & Me.dgvTemperationSaisie.Rows(0).Cells(13).Value & "','" & _
                    System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_tempurters` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourTemperature.SelectedItem(0) & ",  `00`='" & Me.dgvTemperationSaisie.Rows(0).Cells(0).Value & "',  `03`='" & Me.dgvTemperationSaisie.Rows(0).Cells(1).Value & "',  `06`='" & Me.dgvTemperationSaisie.Rows(0).Cells(2).Value & "', `09`='" & Me.dgvTemperationSaisie.Rows(0).Cells(3).Value & "',  `12`='" & Me.dgvTemperationSaisie.Rows(0).Cells(4).Value & "',  `15` ='" & Me.dgvTemperationSaisie.Rows(0).Cells(5).Value & "',  `18` ='" & Me.dgvTemperationSaisie.Rows(0).Cells(6).Value & "',  `21` ='" & Me.dgvTemperationSaisie.Rows(0).Cells(7).Value & "',  `total`='" & Me.dgvTemperationSaisie.Rows(0).Cells(8).Value & "', `moyenne`='" & Me.dgvTemperationSaisie.Rows(0).Cells(9).Value & "',  `min`='" & Me.dgvTemperationSaisie.Rows(0).Cells(10).Value & "', `Hmin`='" & Me.dgvTemperationSaisie.Rows(0).Cells(11).Value & "', `max`='" & Me.dgvTemperationSaisie.Rows(0).Cells(11).Value & "', `hmax`='" & Me.dgvTemperationSaisie.Rows(0).Cells(11).Value & _
                    "' WHERE `id` =" & dgvTemperationList.SelectedRows(0).Cells(0).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadtemperature()
            TotalTemperature()
            dgvTemperationSaisie.Rows().Remove(dgvTemperationSaisie.Rows(0))
            dgvTemperationSaisie.Rows().Add()
        End If
    End Sub
    Private Sub loadtemperature()
        Dim strSql As String = "SELECT  `id`,`day` as 'Jour', `00`, `03`, `06`,`09`, `12`, `15`, `18`, `21`, `total` as 'Total', `moyenne` as 'Moyenne', `min` as 'Min', `hmin` as 'H(m)', `max` as 'Max', `hmax` as 'H(Mx)', `image` as 'Image' FROM `acmad_tempurters` WHERE `type`=1 order by day;"
        ' reloadDataDvgrid(strSql, dgvTemperationList)
        reloadDataTableWithTotal(strSql, dgvTemperationList)
    End Sub

    Private Sub btnValidTemperatureM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidTemperatureM.Click
        If cbJourTemperature.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvTemperatureM.Rows(0).Cells(8).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_tempurters` (`id`, `station_id`,`month`,`year`, `day`, `00`, `03`, `06`,`09`, `12`, `15`, `18`, `21`, `type`,`image`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & "," & cbJourTemperature.SelectedItem(0) & ", '" & Me.dgvTemperatureM.Rows(0).Cells(0).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(1).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(2).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(3).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(4).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(5).Value & "', '" & Me.dgvTemperatureM.Rows(0).Cells(6).Value & "','" & Me.dgvTemperatureM.Rows(0).Cells(7).Value & "', 2,'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_tempurters` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourTemperature.SelectedItem(0) & ",  `00`='" & Me.dgvTemperatureM.Rows(0).Cells(0).Value & "',  `03`='" & Me.dgvTemperatureM.Rows(0).Cells(1).Value & "',  `06`='" & Me.dgvTemperatureM.Rows(0).Cells(2).Value & "', `09`='" & Me.dgvTemperatureM.Rows(0).Cells(3).Value & "',  `12`='" & Me.dgvTemperatureM.Rows(0).Cells(4).Value & "',  `15` ='" & Me.dgvTemperatureM.Rows(0).Cells(5).Value & "',  `18` ='" & Me.dgvTemperatureM.Rows(0).Cells(6).Value & "',  `21` ='" & Me.dgvTemperatureM.Rows(0).Cells(7).Value & _
                    "' WHERE `id` =" & dgvTemperatureM.Rows(0).Cells(8).Value
                updates(strSql, "data updated successful", "Error")
            End If
            loadtemperatureM()
            dgvTemperatureM.Rows().Remove(dgvTemperatureM.Rows(0))
            dgvTemperatureM.Rows().Add()
        End If
    End Sub
    Private Sub loadtemperatureM()
        Dim strSql As String = "SELECT  `id`,`day` as 'Jour', `00`, `03`, `06`,`09`, `12`, `15`, `18`, `21`, `image` as 'Image' FROM `acmad_tempurters` WHERE `type`=2"
        reloadDataDvgrid(strSql, dgvTemperatureMList)
    End Sub
    Private Sub loadHumidite()
        Dim strSql As String = "SELECT   `id`,`day` as 'Jour', `00`, `03`, `06`,`09`, `12`, `15`, `18`, `21`,`total`,`moyenne` as 'Moy.', `min`, `heur_min`, `max`, `heur_max`, `00h`, `06h`, `12h`, `18h`,`total1` as 'Total_',`moyenne1` as 'Moy..', `image` FROM `acmad_vapeur_humid_pression`"
        'reloadDataDvgrid(strSql, dgvVapeurHumiditeList)
        reloadDataTableWithTotal(strSql, dgvVapeurHumiditeList)
    End Sub

    Private Sub btnValideHumidite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValideHumidite.Click
        If cbJourHumidite.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvVapeurHumidite.Rows(0).Cells(20).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_vapeur_humid_pression` (`id`, `station_id`,`month`,`year`, `day`, `00`, `03`, `06`,  `09`,`12`, `15`, `18`, `21`, `total`, `moyenne`, `min`, `heur_min`, `max`, `heur_max`, `00h`, `06h`, `12h`, `18h`, `total1`, `moyenne1`,`image`) " & _
                   "VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & " , " & cbJourHumidite.SelectedItem(0) & ", '" & Me.dgvVapeurHumidite.Rows(0).Cells(0).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(1).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(2).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(3).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(4).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(5).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(6).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(7).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(8).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(9).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(10).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(11).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(12).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(13).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(14).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(15).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(16).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(17).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(18).Value & "', '" & Me.dgvVapeurHumidite.Rows(0).Cells(19).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_vapeur_humid_pression` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourHumidite.SelectedItem(0) & ",  `00`='" & Me.dgvVapeurHumidite.Rows(0).Cells(0).Value & "',  `03`='" & Me.dgvVapeurHumidite.Rows(0).Cells(1).Value & "',  `06`='" & Me.dgvVapeurHumidite.Rows(0).Cells(2).Value & "', `09`='" & Me.dgvVapeurHumidite.Rows(0).Cells(3).Value & "',  `12`='" & Me.dgvVapeurHumidite.Rows(0).Cells(4).Value & "',  `15` ='" & Me.dgvVapeurHumidite.Rows(0).Cells(5).Value & "',  `18` ='" & Me.dgvVapeurHumidite.Rows(0).Cells(6).Value & "',  `21` ='" & Me.dgvVapeurHumidite.Rows(0).Cells(7).Value & "',  `total` ='" & Me.dgvVapeurHumidite.Rows(0).Cells(7).Value & "',  `min`='" & Me.dgvVapeurHumidite.Rows(0).Cells(9).Value & "', `heur_min`='" & Me.dgvVapeurHumidite.Rows(0).Cells(10).Value & "', `max`='" & Me.dgvVapeurHumidite.Rows(0).Cells(10).Value & _
                        "', `00h`='" & Me.dgvVapeurHumidite.Rows(0).Cells(11).Value & "', `06h`='" & Me.dgvVapeurHumidite.Rows(0).Cells(12).Value & "', `12h`='" & Me.dgvVapeurHumidite.Rows(0).Cells(13).Value & "', `18h`='" & Me.dgvVapeurHumidite.Rows(0).Cells(14).Value & "', `heur_max`='" & Me.dgvVapeurHumidite.Rows(0).Cells(10).Value & _
                    "' WHERE `id` =" & dgvVapeurHumidite.Rows(0).Cells(20).Value

                ' MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadHumidite()
            TotalVapeurHumidite()
            dgvVapeurHumidite.Rows().Remove(dgvVapeurHumidite.Rows(0))
            dgvVapeurHumidite.Rows().Add()
        End If
    End Sub

    Private Sub btnNebulosite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNebulosite.Click
        If cbNebulosite.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvNebulosite.Rows(0).Cells(12).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_total_nebulosity` (`id`, `station_id`,`month`,`year`, `day`, `0h`, `3h`, `6h`, `9h`, `12h`, `15h`, `18h`, `21h`, `av.midi`, `ap.midi`, `total`, `actinometrie`,`image`) " & _
                    "VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & " , " & cbNebulosite.SelectedItem(0) & ", '" & Me.dgvNebulosite.Rows(0).Cells(0).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(1).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(2).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(3).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(4).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(5).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(6).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(7).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(8).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(9).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(10).Value & "', '" & Me.dgvNebulosite.Rows(0).Cells(11).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_total_nebulosity` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourHumidite.SelectedItem(0) & ",  `0h`='" & Me.dgvNebulosite.Rows(0).Cells(0).Value & "',  `3h`='" & Me.dgvNebulosite.Rows(0).Cells(1).Value & "',  `6h`='" & Me.dgvNebulosite.Rows(0).Cells(2).Value & "', `9h`='" & Me.dgvNebulosite.Rows(0).Cells(3).Value & "',  `12h`='" & Me.dgvNebulosite.Rows(0).Cells(4).Value & "',  `15h` ='" & Me.dgvNebulosite.Rows(0).Cells(5).Value & "',  `18h` ='" & Me.dgvNebulosite.Rows(0).Cells(6).Value & "',  `21h` ='" & Me.dgvNebulosite.Rows(0).Cells(7).Value & "',  `av.midi`='" & Me.dgvNebulosite.Rows(0).Cells(9).Value & "', `ap.midi`='" & Me.dgvNebulosite.Rows(0).Cells(10).Value & "', `total`='" & Me.dgvNebulosite.Rows(0).Cells(10).Value & "', `actinometrie`='" & Me.dgvNebulosite.Rows(0).Cells(11).Value & _
                    "' WHERE `id` =" & dgvNebulosite.Rows(0).Cells(15).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadNebulosite()
            Total()
            dgvNebulosite.Rows().Remove(dgvNebulosite.Rows(0))
            dgvNebulosite.Rows().Add()
        End If
    End Sub
    Private Sub loadNebulosite()
        Dim strSql As String = "SELECT   `id`,  `day` as Jour, `0h`, `3h`, `6h`, `9h`, `12h`, `15h`, `18h`, `21h`, `av.midi`, `ap.midi`, `total`, `actinometrie`, `image` FROM `acmad_total_nebulosity`"
        reloadDataTableWithTotal(strSql, dgvNebulositeList)
        ' Me.dgvNebulositeList.Columns(1).Visible = False
        ' Me.dgvNebulositeList.Columns(2).Visible = False
        
    End Sub


    Private Sub btnValider_tmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValider_tmp.Click
        If cbNebulosite.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvTempPresion.Rows(0).Cells(13).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_tmpr_pression` (`id`, `station_id`,`month`,`year`, `day`, `min_dsus_sol`, `max_dsus_sol`, `6h_ds`, `12h_ds`, `18h_ds`, `12h_20`, `12h_50`, `00h`, `06h`, `12h`, `18h`, `total`, `moyenne`,`image`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & "," & cbNebulosite.SelectedItem(0) & ", '" & Me.dgvTempPresion.Rows(0).Cells(0).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(1).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(2).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(3).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(4).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(5).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(6).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(7).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(8).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(9).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(10).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(11).Value & "', '" & Me.dgvTempPresion.Rows(0).Cells(12).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_tmpr_pression` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbNebulosite.SelectedItem(0) & ",  `min_dsus_sol`='" & Me.dgvTempPresion.Rows(0).Cells(0).Value & "',  `max_dsus_sol`='" & Me.dgvTempPresion.Rows(0).Cells(1).Value & "',  `6h_ds`='" & Me.dgvTempPresion.Rows(0).Cells(2).Value & "', `12h_ds`='" & Me.dgvTempPresion.Rows(0).Cells(3).Value & "',  `18h_ds`='" & Me.dgvTempPresion.Rows(0).Cells(4).Value & "',  `12h_20` ='" & Me.dgvTempPresion.Rows(0).Cells(5).Value & "',  `12h_50` ='" & Me.dgvTempPresion.Rows(0).Cells(6).Value & "',  `00h` ='" & Me.dgvTempPresion.Rows(0).Cells(7).Value & "',  `06h`='" & Me.dgvTempPresion.Rows(0).Cells(9).Value & "', `12h`='" & Me.dgvTempPresion.Rows(0).Cells(10).Value & "', `18h`='" & Me.dgvTempPresion.Rows(0).Cells(10).Value & "', `total`='" & Me.dgvTempPresion.Rows(0).Cells(11).Value & "', `moyenne`='" & Me.dgvTempPresion.Rows(0).Cells(12).Value & _
                    "' WHERE `id` =" & dgvTempPresion.Rows(0).Cells(11).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadTempPression()
            Total1()
            dgvTempPresion.Rows().Remove(dgvTempPresion.Rows(0))
            dgvTempPresion.Rows().Add()
        End If
    End Sub
    Private Sub loadTempPression()
        Dim strSql As String = "SELECT   `id`, `day`, `min_dsus_sol` as 'Min', `max_dsus_sol` as 'Max', `6h_ds` as '6h', `12h_ds` as '12h', `18h_ds` as '18h', `12h_20` as '12h(20cm)', `12h_50` as '12h(50cm)', `00h`, `06h`, `12h` as '12h_', `18h` as '18h_', `total`, `Moyenne`, `image`  FROM `acmad_tmpr_pression`"
        reloadDataTableWithTotal(strSql, dgvTempPresionList)
    End Sub

    Private Sub btnValiderVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderVent.Click
        If cbDirectionVentJours.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvDirectionVent.Rows(0).Cells(21).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_direction_vent` (`id`, `station_id`,`month`,`year`, `day`, `00_dir`, `00_vit`, `03_dir`, `03_vit`, `06_dir`, `06_vit`, `09_dir`, `09_vit`, `12_dir`, `12_vit`, `15_dir`, `15_vit`, `18_dir`, `18_vit`, `21_dir`, `21_vit`,`total`,`moyenne`, `dir`, `vit`, `hh`,`image`) VALUES ( NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbDirectionVentJours.SelectedItem(0) & ", '" & Me.dgvDirectionVent.Rows(0).Cells(0).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(1).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(2).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(3).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(4).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(5).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(6).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(7).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(8).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(9).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(10).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(11).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(12).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(13).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(14).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(15).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(16).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(17).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(18).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(19).Value & "', '" & Me.dgvDirectionVent.Rows(0).Cells(20).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_direction_vent` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbDirectionVentJours.SelectedItem(0) & ",  `00_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(0).Value & "',  `00_vit`='" & Me.dgvDirectionVent.Rows(0).Cells(1).Value & "',  `03_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(2).Value & "', `03_vit`='" & Me.dgvDirectionVent.Rows(0).Cells(3).Value & "',  `06_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(4).Value & "',  `06_vit` ='" & Me.dgvDirectionVent.Rows(0).Cells(5).Value & "',  `12_dir` ='" & Me.dgvDirectionVent.Rows(0).Cells(6).Value & "',  `12_vit` ='" & Me.dgvDirectionVent.Rows(0).Cells(7).Value & "',  `15_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(8).Value & "', `15_vit`='" & Me.dgvDirectionVent.Rows(0).Cells(9).Value & "', `18_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(10).Value & _
                 "', `18_vit`='" & Me.dgvDirectionVent.Rows(0).Cells(11).Value & "', `21_dir`='" & Me.dgvDirectionVent.Rows(0).Cells(12).Value & "', `21_vit`='" & Me.dgvDirectionVent.Rows(0).Cells(13).Value & "', `total`='" & Me.dgvDirectionVent.Rows(0).Cells(14).Value & "', `moyenne`='" & Me.dgvDirectionVent.Rows(0).Cells(15).Value & "', `dir`='" & Me.dgvDirectionVent.Rows(0).Cells(16).Value & "', `vit`='" & Me.dgvDirectionVent.Rows(0).Cells(17).Value & "', `hh`='" & Me.dgvDirectionVent.Rows(0).Cells(18).Value & "' WHERE `id` =" & dgvDirectionVent.Rows(0).Cells(20).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadVent()
            TotalDirectionVent()
            dgvDirectionVent.Rows().Remove(dgvDirectionVent.Rows(0))
            dgvDirectionVent.Rows().Add()
        End If
    End Sub
    Private Sub loadVent()
        Dim strSql As String = "SELECT `id`, `day`, `00_dir`, `00_vit`, `03_dir`, `03_vit`, `06_dir`, `06_vit`, `09_dir`, `09_vit`, `12_dir`, `12_vit`, `15_dir`, `15_vit`, `18_dir`, `18_vit`, `21_dir`, `21_vit`, `dir`, `vit`, `hh`, `total`, `Moyenne`, `dir`, `vit`, `hh`, `image` FROM `acmad_direction_vent`"
        'reloadDataDvgrid(strSql, dgvDirectionVentList)
        reloadDataTableWithTotal(strSql, dgvDirectionVentList)
    End Sub
    Private Sub btnValidResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidResume.Click
        If cbResumeJour.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvDirectionVent.Rows(0).Cells(19).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_resume` (`id`, `station_id`,`month`,`year`, `day`, `desc`, `symbol1`, `symbol2`,`image`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", '" & cbResumeJour.SelectedItem(0) & "', '" & Me.dgvResume.Rows(0).Cells(0).Value & "', '" & Me.dgvResume.Rows(0).Cells(1).Value & "', '" & Me.dgvResume.Rows(0).Cells(2).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_resume` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbResumeJour.SelectedItem(0) & ",  `desc`='" & Me.dgvResume.Rows(0).Cells(0).Value & "',  `symbol1`='" & Me.dgvResume.Rows(0).Cells(1).Value & "',  `symbol2`='" & Me.dgvResume.Rows(0).Cells(2).Value & _
                 "' WHERE `id` =" & dgvResume.Rows(0).Cells(19).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadResume()
            dgvResume.Rows().Remove(dgvResume.Rows(0))
            dgvResume.Rows().Add()
        End If
    End Sub
    Private Sub loadResume()
        Dim strSql As String = "SELECT `id`, `day`, `desc`, `symbol1`, `symbol2` FROM `acmad_resume`"
        reloadDataDvgrid(strSql, dgvResumeList)
    End Sub
    Private Sub cmdCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCSV.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbPrecipitation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImage.Text = OpenFileImport.FileName
        pbPrecipitation.Load(OpenFileImport.FileName)

        'Copie du fichier vers le dossier archive
        'System.IO.Path.GetExtension(fileName)
        'My.Computer.FileSystem.CopyFile(
        'txtImage.Text, "C:\PaperArchive\Images\")
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie

    End Sub
    Private Sub btnImgTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgTemperature.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbtemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImgTemperature.Text = OpenFileImport.FileName
        pbtemperature.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnTension_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTension.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbTension.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtTension.Text = OpenFileImport.FileName
        pbTension.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnnebilosite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnebilosite.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbnebilosite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtnebilosite.Text = OpenFileImport.FileName
        pbnebilosite.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnpbDirection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpbDirection.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtDirection.Text = OpenFileImport.FileName
        pbDirection.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnResume_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResume.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbResume.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtResume.Text = OpenFileImport.FileName
        pbResume.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim numberFormatInfo As Globalization.NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim decimalSeparator As String = numberFormatInfo.NumberDecimalSeparator
        Dim groupSeparator As String = numberFormatInfo.NumberGroupSeparator
        Dim negativeSign As String = numberFormatInfo.NegativeSign

        Dim keyInput As String = e.KeyChar.ToString()

        If [Char].IsDigit(e.KeyChar) Then
            ' Digits are OK
        ElseIf keyInput.Equals(decimalSeparator) OrElse keyInput.Equals(groupSeparator) OrElse keyInput.Equals(negativeSign) Then
            ' Decimal separator is OK
        ElseIf e.KeyChar = vbBack Then
            ' Backspace key is OK
            '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            '    {
            '     // Let the edit control handle control and alt key combinations
            '    }
            'ElseIf sender.SpaceOK AndAlso e.KeyChar = " "c Then

        Else
            ' Consume this invalid key and beep.
            e.Handled = True
        End If
    End Sub


    Private Sub btnRotationPrecipitation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotationPrecipitation.Click
        pbPrecipitation.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbPrecipitation.Refresh()
    End Sub
    Public Function PictureBoxZoom(ByVal img As Image, ByVal size As Size) As Image
        Dim bm As Bitmap = New Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height))
        Dim grap As Graphics = Graphics.FromImage(bm)
        grap.InterpolationMode = InterpolationMode.HighQualityBicubic
        Return bm
    End Function
    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        pbPrecipitation.Height = pbPrecipitation.Height + 2
        pbPrecipitation.Width = pbPrecipitation.Width + 2
    End Sub

    Private Sub btnzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomout.Click
        pbPrecipitation.Height = pbPrecipitation.Height - 2
        pbPrecipitation.Width = pbPrecipitation.Width - 2
    End Sub


    Private Sub dgvTemperationSaisie_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemperationSaisie.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvTemperationSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvTemperationSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvTemperationSaisie.CurrentCell = dgvTemperationSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvTemperationSaisie.CurrentCell.Selected = True
        '        dgvTemperationSaisie.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub

    Private Sub btnzoomtrmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomtrmp.Click
        pbtemperature.Height = pbtemperature.Height + 2
        pbtemperature.Width = pbtemperature.Width + 2
    End Sub

    Private Sub btnzoomouttrmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomouttrmp.Click
        pbtemperature.Height = pbtemperature.Height - 2
        pbtemperature.Width = pbtemperature.Width - 2
    End Sub

    Private Sub btnrottrmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrottrmp.Click
        pbtemperature.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbtemperature.Refresh()
    End Sub

    Private Sub btntensionzoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntensionzoom.Click
        pbTension.Height = pbTension.Height + 2
        pbTension.Width = pbTension.Width + 2
    End Sub

    Private Sub btntensionzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntensionzoomout.Click
        pbTension.Height = pbTension.Height - 2
        pbTension.Width = pbTension.Width - 2
    End Sub

    Private Sub btntensionrot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntensionrot.Click
        pbTension.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbTension.Refresh()
    End Sub

    Private Sub btnnebzoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnebzoom.Click
        pbnebilosite.Height = pbnebilosite.Height + 2
        pbnebilosite.Width = pbnebilosite.Width + 2
    End Sub

    Private Sub btnnebzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnebzoomout.Click
        pbnebilosite.Height = pbnebilosite.Height - 2
        pbnebilosite.Width = pbnebilosite.Width - 2
    End Sub

    Private Sub btnnebrot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnebrot.Click
        pbnebilosite.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbnebilosite.Refresh()
    End Sub

    Private Sub btndireczoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndireczoom.Click
        pbDirection.Height = pbDirection.Height + 2
        pbDirection.Width = pbDirection.Width + 2
    End Sub

    Private Sub btndireczoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndireczoomout.Click
        pbDirection.Height = pbDirection.Height - 2
        pbDirection.Width = pbDirection.Width - 2
    End Sub

    Private Sub btndirecrot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndirecrot.Click
        pbDirection.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbDirection.Refresh()
    End Sub

    Private Sub btnreszoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreszoom.Click
        pbResume.Height = pbResume.Height + 2
        pbResume.Width = pbResume.Width + 2
    End Sub

    Private Sub btnreszoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreszoomout.Click
        pbResume.Height = pbResume.Height - 2
        pbResume.Width = pbResume.Width - 2
    End Sub

    Private Sub btnresrot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnresrot.Click
        pbResume.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbResume.Refresh()
    End Sub

    Private Sub dgvTemperatureM_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemperatureM.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvTemperatureM.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvTemperatureM.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvTemperatureM.CurrentCell = dgvTemperatureM.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvTemperatureM.CurrentCell.Selected = True
        '        dgvTemperatureM.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub

    Private Sub dgvNebulosite_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNebulosite.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvNebulosite.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvNebulosite.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvNebulosite.CurrentCell = dgvNebulosite.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvNebulosite.CurrentCell.Selected = True
        '        dgvNebulosite.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub


    Private Sub dgvVapeurHumidite_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVapeurHumidite.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvVapeurHumidite.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvVapeurHumidite.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvVapeurHumidite.CurrentCell = dgvVapeurHumidite.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvVapeurHumidite.CurrentCell.Selected = True
        '        dgvVapeurHumidite.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub

    Private Sub dgvTempPresion_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTempPresion.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvTempPresion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvTempPresion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvTempPresion.CurrentCell = dgvTempPresion.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvTempPresion.CurrentCell.Selected = True
        '        dgvTempPresion.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub

    Private Sub dgvDirectionVent_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDirectionVent.CellEndEdit
        'If (e.ColumnIndex = 0) Then   ' Checking numeric value for Column1 only
        'Dim value As String = dgvDirectionVent.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvDirectionVent.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvDirectionVent.CurrentCell = dgvDirectionVent.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvDirectionVent.CurrentCell.Selected = True
        '        dgvDirectionVent.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
        'End If
    End Sub
    Private Sub cbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMenu.SelectedIndexChanged
        TabControl1.TabPages.Clear()
        Select Case cbMenu.SelectedIndex
            Case 0
                TabControl1.TabPages.Add(TabPage2)
            Case 1
                TabControl1.TabPages.Add(TabPage3)
                TotalTemperature()
            Case 2
                TabControl1.TabPages.Add(TabPage4)
                TotalVapeurHumidite()
            Case 3
                TabControl1.TabPages.Add(TabPage5)
                Total()
                Total1()
            Case 4
                TabControl1.TabPages.Add(TabPage6)
                TotalDirectionVent()
            Case 5
                TabControl1.TabPages.Add(TabPage7)
            Case 6
                TabControl1.TabPages.Add(Tcm)
            Case 7
                TabControl1.TabPages.Add(TabPage1)
            Case Else
                TabControl1.TabPages.Add(TabPage2)
        End Select

        'TabControl1.TabPages.Add(TabPage2)
        'myTabControl.TabPages()
    End Sub

    Private Sub btnSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSyn.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbSyn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImgSyn.Text = OpenFileImport.FileName
        pbSyn.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnZoomSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomSyn.Click
        pbSyn.Height = pbSyn.Height + 4
        pbSyn.Width = pbSyn.Width + 4
    End Sub

    Private Sub btnZoonOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoonOut.Click
        pbSyn.Height = pbSyn.Height - 4
        pbSyn.Width = pbSyn.Width - 4
    End Sub

    Private Sub btnRotSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotSyn.Click
        pbSyn.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbSyn.Refresh()
    End Sub

    Private Sub btnValideSyn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValideSyn.Click
        If cbjourSyn.SelectedItem Is Nothing Then
            MsgBox("Please Select day")
        Else
            If (dgvSynSaisie.Rows(0).Cells(23).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acamd_tableau_synoptique_precipi` (`id`, `station_id`, `month`, `year`, `day`, `1`, `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `11`, `12`, `13`, `14`, `15`, `16`, `17`, `18`, `19`, `20`, `21`, `22`, `23`, `image`) " & _
    " VALUES (NULL,  " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbjourSyn.SelectedItem(0) & ", '" & Me.dgvSynSaisie.Rows(0).Cells(0).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(1).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(2).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(3).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(4).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(5).Value & "',' " & Me.dgvSynSaisie.Rows(0).Cells(6).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(7).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(8).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(9).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(10).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(11).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(12).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(13).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(14).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(15).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(16).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(17).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(18).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(19).Value & "',' " & Me.dgvSynSaisie.Rows(0).Cells(20).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(21).Value & "', '" & Me.dgvSynSaisie.Rows(0).Cells(22).Value & "','" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                MsgBox(strSql)
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acamd_tableau_synoptique_precipi` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbjourSyn.SelectedItem(0) & ",  `1`=" & Me.dgvSynSaisie.Rows(0).Cells(0).Value & ",  `2`=" & Me.dgvSynSaisie.Rows(0).Cells(1).Value & ",  `3`=" & Me.dgvSynSaisie.Rows(0).Cells(2).Value & ",  `4`=" & Me.dgvSynSaisie.Rows(0).Cells(3).Value & ",  `5`=" & Me.dgvSynSaisie.Rows(0).Cells(4).Value & ",  `6`=" & Me.dgvSynSaisie.Rows(0).Cells(5).Value & ",  `7`=" & Me.dgvSynSaisie.Rows(0).Cells(6).Value & ",  `8`=" & Me.dgvSynSaisie.Rows(0).Cells(7).Value & ",  `9`=" & Me.dgvSynSaisie.Rows(0).Cells(8).Value & ",  `10`=" & Me.dgvSynSaisie.Rows(0).Cells(9).Value & ",  `11`=" & Me.dgvSynSaisie.Rows(0).Cells(10).Value & ",  `12`=" & Me.dgvSynSaisie.Rows(0).Cells(11).Value & ",  `13`=" & Me.dgvSynSaisie.Rows(0).Cells(12).Value & ",  `14`=" & Me.dgvSynSaisie.Rows(0).Cells(13).Value & ",  `15`=" & Me.dgvSynSaisie.Rows(0).Cells(14).Value & ",  `16`=" & Me.dgvSynSaisie.Rows(0).Cells(15).Value & ",  `17`=" & Me.dgvSynSaisie.Rows(0).Cells(16).Value & ",  `18`=" & Me.dgvSynSaisie.Rows(0).Cells(17).Value & ",  `19`=" & Me.dgvSynSaisie.Rows(0).Cells(18).Value & ",  `20`=" & Me.dgvSynSaisie.Rows(0).Cells(19).Value & ",  `21`=" & Me.dgvSynSaisie.Rows(0).Cells(20).Value & ",  `22`=" & Me.dgvSynSaisie.Rows(0).Cells(21).Value & ",  `23`=" & Me.dgvSynSaisie.Rows(0).Cells(22).Value & _
                 " WHERE `id` =" & dgvSynSaisie.Rows(0).Cells(23).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadSynData()
            dgvSynSaisie.Rows().Remove(dgvSynSaisie.Rows(0))
            dgvSynSaisie.Rows().Add()
        End If


    End Sub
    Private Sub loadSynData()
        Dim strSql As String = "SELECT* FROM `acamd_tableau_synoptique_precipi`"
        reloadDataDvgrid(strSql, dgvSynList)
    End Sub

    Private Sub dgvSynSaisie_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSynSaisie.CellEndEdit
        'Dim value As String = dgvSynSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvSynSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvSynSaisie.CurrentCell = dgvSynSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvSynSaisie.CurrentCell.Selected = True
        '        dgvSynSaisie.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
    End Sub


    Private Sub btnImgTcm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgTcm.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbtcm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImgTcm.Text = OpenFileImport.FileName
        pbtcm.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub
    Private Sub ModifierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierToolStripMenuItem.Click
        'MsgBox("modifier" & dgvTemperationList.SelectedRows(0).Cells(0).Value)
        cbJourTemperature.SelectedIndex = cbJourTemperature.FindString(dgvTemperationList.SelectedRows(0).Cells(1).Value.ToString)
        dgvTemperationSaisie.Rows(0).Cells(0).Value = dgvTemperationList.SelectedRows(0).Cells(2).Value
        dgvTemperationSaisie.Rows(0).Cells(1).Value = dgvTemperationList.SelectedRows(0).Cells(3).Value
        dgvTemperationSaisie.Rows(0).Cells(2).Value = dgvTemperationList.SelectedRows(0).Cells(4).Value
        dgvTemperationSaisie.Rows(0).Cells(3).Value = dgvTemperationList.SelectedRows(0).Cells(5).Value
        dgvTemperationSaisie.Rows(0).Cells(4).Value = dgvTemperationList.SelectedRows(0).Cells(6).Value
        dgvTemperationSaisie.Rows(0).Cells(5).Value = dgvTemperationList.SelectedRows(0).Cells(7).Value
        dgvTemperationSaisie.Rows(0).Cells(6).Value = dgvTemperationList.SelectedRows(0).Cells(8).Value
        dgvTemperationSaisie.Rows(0).Cells(7).Value = dgvTemperationList.SelectedRows(0).Cells(9).Value
        dgvTemperationSaisie.Rows(0).Cells(9).Value = dgvTemperationList.SelectedRows(0).Cells(10).Value
        dgvTemperationSaisie.Rows(0).Cells(10).Value = dgvTemperationList.SelectedRows(0).Cells(11).Value
        dgvTemperationSaisie.Rows(0).Cells(11).Value = dgvTemperationList.SelectedRows(0).Cells(0).Value
        'Dim strSql As String = "Update `acmad_tempurters` `day`, set `00`=" & Me.dgvTemperationSaisie.Rows(0).Cells(0).Value & ", set `03`=" & Me.dgvTemperationSaisie.Rows(0).Cells(1).Value & ", set `06`=" & Me.dgvTemperationSaisie.Rows(0).Cells(2).Value & ",set `09`=" & Me.dgvTemperationSaisie.Rows(0).Cells(3).Value & ", set `12`=" & Me.dgvTemperationSaisie.Rows(0).Cells(4).Value & ", set `15` =" & Me.dgvTemperationSaisie.Rows(0).Cells(5).Value & ", set `18` =" & Me.dgvTemperationSaisie.Rows(0).Cells(6).Value & ", set `21` =" & Me.dgvTemperationSaisie.Rows(0).Cells(7).Value & ", set `type` =" & Me.dgvTemperationSaisie.Rows(0).Cells(8).Value & ", set `min`=" & Me.dgvTemperationSaisie.Rows(0).Cells(9).Value & ", set`max`=" & Me.dgvTemperationSaisie.Rows(0).Cells(10).Value & _
        '    " WHERE `id` =" & dgvTemperationList.SelectedRows(0).Cells(0).Value
        'updates(strSql, "data updated successful", "Error")
        'loadtemperature()
        txtImgTemperature.Text = "C:\PaperArchive\Images\" & dgvTemperationList.SelectedRows(0).Cells(12).Value 'OpenFileImport.FileName
        Me.pbtemperature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbtemperature.Load("C:\PaperArchive\Images\" & dgvTemperationList.SelectedRows(0).Cells(12).Value)
    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        'MsgBox("supprimer")
        Dim strSql As String = "DELETE FROM `acmad_tempurters` WHERE `id` =" & dgvTemperationList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadtemperature()
    End Sub


    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'supprimer
        Dim strSql As String = "DELETE FROM `acmad_tempurters` WHERE `id` =" & dgvTemperatureMList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadtemperatureM()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'modifier
        'dgvTemperatureMList
        'dgvTemperatureM
        dgvTemperatureM.Rows(0).Cells(0).Value = dgvTemperatureMList.SelectedRows(0).Cells(2).Value
        dgvTemperatureM.Rows(0).Cells(1).Value = dgvTemperatureMList.SelectedRows(0).Cells(3).Value
        dgvTemperatureM.Rows(0).Cells(2).Value = dgvTemperatureMList.SelectedRows(0).Cells(4).Value
        dgvTemperatureM.Rows(0).Cells(3).Value = dgvTemperatureMList.SelectedRows(0).Cells(5).Value
        dgvTemperatureM.Rows(0).Cells(4).Value = dgvTemperatureMList.SelectedRows(0).Cells(6).Value
        dgvTemperatureM.Rows(0).Cells(5).Value = dgvTemperatureMList.SelectedRows(0).Cells(7).Value
        dgvTemperatureM.Rows(0).Cells(6).Value = dgvTemperatureMList.SelectedRows(0).Cells(8).Value
        dgvTemperatureM.Rows(0).Cells(7).Value = dgvTemperatureMList.SelectedRows(0).Cells(9).Value
        dgvTemperatureM.Rows(0).Cells(8).Value = dgvTemperatureMList.SelectedRows(0).Cells(0).Value
        
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        cbJourHumidite.SelectedIndex = cbJourHumidite.FindString(dgvVapeurHumiditeList.SelectedRows(0).Cells(1).Value.ToString)

        'modifier hum dgvVapeurHumidite
        dgvVapeurHumidite.Rows(0).Cells(0).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(2).Value
        dgvVapeurHumidite.Rows(0).Cells(1).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(3).Value
        dgvVapeurHumidite.Rows(0).Cells(2).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(4).Value
        dgvVapeurHumidite.Rows(0).Cells(3).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(5).Value
        dgvVapeurHumidite.Rows(0).Cells(4).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(6).Value
        dgvVapeurHumidite.Rows(0).Cells(5).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(7).Value
        dgvVapeurHumidite.Rows(0).Cells(6).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(8).Value
        dgvVapeurHumidite.Rows(0).Cells(7).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(9).Value
        dgvVapeurHumidite.Rows(0).Cells(8).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(10).Value
        dgvVapeurHumidite.Rows(0).Cells(9).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(11).Value
        dgvVapeurHumidite.Rows(0).Cells(10).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(12).Value
        dgvVapeurHumidite.Rows(0).Cells(11).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(13).Value
        dgvVapeurHumidite.Rows(0).Cells(12).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(14).Value
        dgvVapeurHumidite.Rows(0).Cells(13).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(15).Value
        dgvVapeurHumidite.Rows(0).Cells(14).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(16).Value
        dgvVapeurHumidite.Rows(0).Cells(15).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(17).Value
        dgvVapeurHumidite.Rows(0).Cells(1).Value = dgvVapeurHumiditeList.SelectedRows(0).Cells(0).Value
        txtTension.Text = "C:\PaperArchive\Images\" & dgvVapeurHumiditeList.SelectedRows(0).Cells(18).Value 'OpenFileImport.FileName
        Me.pbTension.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbTension.Load("C:\PaperArchive\Images\" & dgvVapeurHumiditeList.SelectedRows(0).Cells(18).Value)

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        'Supprimer hum
        Dim strSql As String = "DELETE FROM `acmad_vapeur_humid_pression` WHERE `id` =" & dgvVapeurHumiditeList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadHumidite()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        cbNebulosite.SelectedIndex = cbNebulosite.FindString(dgvNebulositeList.SelectedRows(0).Cells(1).Value.ToString)

        'dgvNebulositeList modifier dgvNebulosite
        dgvNebulosite.Rows(0).Cells(0).Value = dgvNebulositeList.SelectedRows(0).Cells(2).Value
        dgvNebulosite.Rows(0).Cells(1).Value = dgvNebulositeList.SelectedRows(0).Cells(3).Value
        dgvNebulosite.Rows(0).Cells(2).Value = dgvNebulositeList.SelectedRows(0).Cells(4).Value
        dgvNebulosite.Rows(0).Cells(3).Value = dgvNebulositeList.SelectedRows(0).Cells(5).Value
        dgvNebulosite.Rows(0).Cells(4).Value = dgvNebulositeList.SelectedRows(0).Cells(6).Value
        dgvNebulosite.Rows(0).Cells(5).Value = dgvNebulositeList.SelectedRows(0).Cells(7).Value
        dgvNebulosite.Rows(0).Cells(6).Value = dgvNebulositeList.SelectedRows(0).Cells(8).Value
        dgvNebulosite.Rows(0).Cells(7).Value = dgvNebulositeList.SelectedRows(0).Cells(9).Value
        dgvNebulosite.Rows(0).Cells(8).Value = dgvNebulositeList.SelectedRows(0).Cells(10).Value
        dgvNebulosite.Rows(0).Cells(9).Value = dgvNebulositeList.SelectedRows(0).Cells(11).Value
        dgvNebulosite.Rows(0).Cells(10).Value = dgvNebulositeList.SelectedRows(0).Cells(12).Value
        dgvNebulosite.Rows(0).Cells(11).Value = dgvNebulositeList.SelectedRows(0).Cells(0).Value
        txtnebilosite.Text = "C:\PaperArchive\Images\" & dgvNebulositeList.SelectedRows(0).Cells(13).Value 'OpenFileImport.FileName
        Me.pbnebilosite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbnebilosite.Load("C:\PaperArchive\Images\" & dgvNebulositeList.SelectedRows(0).Cells(13).Value)

    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'dgvNebulositeList supprimer
        Dim strSql As String = "DELETE FROM `acmad_total_nebulosity` WHERE `id` =" & dgvNebulositeList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadNebulosite()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        cbNebulosite.SelectedIndex = cbNebulosite.FindString(dgvTempPresionList.SelectedRows(0).Cells(1).Value.ToString)

        'modifier dgvTempPresionList dgvTempPresion
        dgvTempPresion.Rows(0).Cells(0).Value = dgvTempPresionList.SelectedRows(0).Cells(2).Value
        dgvTempPresion.Rows(0).Cells(1).Value = dgvTempPresionList.SelectedRows(0).Cells(3).Value
        dgvTempPresion.Rows(0).Cells(2).Value = dgvTempPresionList.SelectedRows(0).Cells(4).Value
        dgvTempPresion.Rows(0).Cells(3).Value = dgvTempPresionList.SelectedRows(0).Cells(5).Value
        dgvTempPresion.Rows(0).Cells(4).Value = dgvTempPresionList.SelectedRows(0).Cells(6).Value
        dgvTempPresion.Rows(0).Cells(5).Value = dgvTempPresionList.SelectedRows(0).Cells(7).Value
        dgvTempPresion.Rows(0).Cells(6).Value = dgvTempPresionList.SelectedRows(0).Cells(8).Value
        dgvTempPresion.Rows(0).Cells(7).Value = dgvTempPresionList.SelectedRows(0).Cells(9).Value
        dgvTempPresion.Rows(0).Cells(8).Value = dgvTempPresionList.SelectedRows(0).Cells(10).Value
        dgvTempPresion.Rows(0).Cells(9).Value = dgvTempPresionList.SelectedRows(0).Cells(11).Value
        dgvTempPresion.Rows(0).Cells(10).Value = dgvTempPresionList.SelectedRows(0).Cells(12).Value
        dgvTempPresion.Rows(0).Cells(11).Value = dgvTempPresionList.SelectedRows(0).Cells(0).Value
        txtnebilosite.Text = "C:\PaperArchive\Images\" & dgvTempPresionList.SelectedRows(0).Cells(13).Value 'OpenFileImport.FileName
        Me.pbnebilosite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbnebilosite.Load("C:\PaperArchive\Images\" & dgvTempPresionList.SelectedRows(0).Cells(13).Value)
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        'supprimer dgvTempPresionList
        Dim strSql As String = "DELETE FROM `acmad_tmpr_pression` WHERE `id` =" & dgvTempPresionList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadTempPression()
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        'modifier dgvDirectionVentList
        cbDirectionVentJours.SelectedIndex = cbDirectionVentJours.FindString(dgvDirectionVentList.SelectedRows(0).Cells(1).Value.ToString)
        dgvDirectionVent.Rows(0).Cells(0).Value = dgvDirectionVentList.SelectedRows(0).Cells(2).Value
        dgvDirectionVent.Rows(0).Cells(1).Value = dgvDirectionVentList.SelectedRows(0).Cells(3).Value
        dgvDirectionVent.Rows(0).Cells(2).Value = dgvDirectionVentList.SelectedRows(0).Cells(4).Value
        dgvDirectionVent.Rows(0).Cells(3).Value = dgvDirectionVentList.SelectedRows(0).Cells(5).Value
        dgvDirectionVent.Rows(0).Cells(4).Value = dgvDirectionVentList.SelectedRows(0).Cells(6).Value
        dgvDirectionVent.Rows(0).Cells(5).Value = dgvDirectionVentList.SelectedRows(0).Cells(7).Value
        dgvDirectionVent.Rows(0).Cells(6).Value = dgvDirectionVentList.SelectedRows(0).Cells(8).Value
        dgvDirectionVent.Rows(0).Cells(7).Value = dgvDirectionVentList.SelectedRows(0).Cells(9).Value
        dgvDirectionVent.Rows(0).Cells(8).Value = dgvDirectionVentList.SelectedRows(0).Cells(10).Value
        dgvDirectionVent.Rows(0).Cells(9).Value = dgvDirectionVentList.SelectedRows(0).Cells(11).Value
        dgvDirectionVent.Rows(0).Cells(10).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(11).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(12).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(13).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(14).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(15).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(16).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(17).Value = dgvDirectionVentList.SelectedRows(0).Cells(12).Value
        dgvDirectionVent.Rows(0).Cells(18).Value = dgvDirectionVentList.SelectedRows(0).Cells(0).Value
        txtDirection.Text = "C:\PaperArchive\Images\" & dgvDirectionVentList.SelectedRows(0).Cells(21).Value 'OpenFileImport.FileName
        Me.pbDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbDirection.Load("C:\PaperArchive\Images\" & dgvDirectionVentList.SelectedRows(0).Cells(21).Value)
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        'supprimer dgvDirectionVentList
        Dim strSql As String = "DELETE FROM `acmad_direction_vent` WHERE `id` =" & dgvDirectionVentList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadVent()
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        'modifier dgvResumeList
        dgvResume.Rows(0).Cells(0).Value = dgvResumeList.SelectedRows(0).Cells(2).Value
        dgvResume.Rows(0).Cells(1).Value = dgvResumeList.SelectedRows(0).Cells(3).Value
        dgvResume.Rows(0).Cells(2).Value = dgvResumeList.SelectedRows(0).Cells(4).Value
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        'supprimer dgvResumeList
        Dim strSql As String = "DELETE FROM `acmad_resume` WHERE `id` =" & dgvResumeList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadResume()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        'modifier dgvSynList
        dgvSynSaisie.Rows(0).Cells(0).Value = dgvSynList.SelectedRows(0).Cells(2).Value
        dgvSynSaisie.Rows(0).Cells(1).Value = dgvSynList.SelectedRows(0).Cells(3).Value
        dgvSynSaisie.Rows(0).Cells(2).Value = dgvSynList.SelectedRows(0).Cells(4).Value
        dgvSynSaisie.Rows(0).Cells(3).Value = dgvSynList.SelectedRows(0).Cells(5).Value
        dgvSynSaisie.Rows(0).Cells(4).Value = dgvSynList.SelectedRows(0).Cells(6).Value
        dgvSynSaisie.Rows(0).Cells(5).Value = dgvSynList.SelectedRows(0).Cells(7).Value
        dgvSynSaisie.Rows(0).Cells(6).Value = dgvSynList.SelectedRows(0).Cells(8).Value
        dgvSynSaisie.Rows(0).Cells(7).Value = dgvSynList.SelectedRows(0).Cells(9).Value
        dgvSynSaisie.Rows(0).Cells(8).Value = dgvSynList.SelectedRows(0).Cells(10).Value
        dgvSynSaisie.Rows(0).Cells(9).Value = dgvSynList.SelectedRows(0).Cells(11).Value
        dgvSynSaisie.Rows(0).Cells(10).Value = dgvSynList.SelectedRows(0).Cells(12).Value
        dgvSynSaisie.Rows(0).Cells(11).Value = dgvSynList.SelectedRows(0).Cells(13).Value
        dgvSynSaisie.Rows(0).Cells(12).Value = dgvSynList.SelectedRows(0).Cells(14).Value
        dgvSynSaisie.Rows(0).Cells(13).Value = dgvSynList.SelectedRows(0).Cells(15).Value
        dgvSynSaisie.Rows(0).Cells(14).Value = dgvSynList.SelectedRows(0).Cells(16).Value
        dgvSynSaisie.Rows(0).Cells(15).Value = dgvSynList.SelectedRows(0).Cells(17).Value
        dgvSynSaisie.Rows(0).Cells(16).Value = dgvSynList.SelectedRows(0).Cells(18).Value
        dgvSynSaisie.Rows(0).Cells(17).Value = dgvSynList.SelectedRows(0).Cells(19).Value
        dgvSynSaisie.Rows(0).Cells(18).Value = dgvSynList.SelectedRows(0).Cells(20).Value
        dgvSynSaisie.Rows(0).Cells(19).Value = dgvSynList.SelectedRows(0).Cells(21).Value
        dgvSynSaisie.Rows(0).Cells(20).Value = dgvSynList.SelectedRows(0).Cells(22).Value
        dgvSynSaisie.Rows(0).Cells(21).Value = dgvSynList.SelectedRows(0).Cells(23).Value
        dgvSynSaisie.Rows(0).Cells(22).Value = dgvSynList.SelectedRows(0).Cells(24).Value
        dgvSynSaisie.Rows(0).Cells(23).Value = dgvSynList.SelectedRows(0).Cells(0).Value
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        'supprimer dgvSynList
        Dim strSql As String = "DELETE FROM `acamd_tableau_synoptique_precipi` WHERE `id` =" & dgvSynList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadSynData()
    End Sub

    


    Private Sub dgvNebulosite_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNebulosite.CellValidated
        Dim somme, col1, col2 As Decimal
        col1 = dgvNebulosite.Rows(0).Cells(8).Value
        col2 = dgvNebulosite.Rows(0).Cells(9).Value
        somme = col1 + col2
        dgvNebulosite.Rows(0).Cells(10).Value = somme
        'somme = dgvVapeurHumidite.Item(9, 0).Value + dgvVapeurHumidite.Item(8, 0).Value
        ' MsgBox(col1)
    End Sub

    Private Sub dgvTempPresion_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTempPresion.CellValidated
        Dim somme, col1, col2, col3, col4 As Decimal
        col1 = dgvTempPresion.Rows(0).Cells(10).Value
        col2 = dgvTempPresion.Rows(0).Cells(9).Value
        col3 = dgvTempPresion.Rows(0).Cells(8).Value
        col4 = dgvTempPresion.Rows(0).Cells(7).Value
        somme = col1 + col2 + col3 + col4
        dgvTempPresion.Rows(0).Cells(11).Value = somme
        dgvTempPresion.Rows(0).Cells(12).Value = somme / 4
    End Sub

    Private Sub dgvNebulositeList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvNebulositeList.CellPainting


        If (e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 14) Then
            Me.dgvNebulositeList.Columns(e.ColumnIndex).Visible = False
        End If
        If (e.ColumnIndex = 13) Then
            Me.dgvNebulositeList.Columns(e.ColumnIndex).Width = 100
        Else
            Me.dgvNebulositeList.Columns(e.ColumnIndex).Width = 40
        End If
        'Dim i As Integer = 0
        'For i = 0 To dgvNebulositeList.Columns.Count - 1
        '    Me.dgvNebulositeList.Columns(1).Visible = False
        '    Me.dgvNebulositeList.Columns(2).Visible = False
        '    Me.dgvNebulositeList.Columns(i).Width = 40
        '    Me.dgvNebulositeList.Columns(13).Width = 100
        'Next
    End Sub
    Private Sub Total()
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvNebulositeList.Columns.Count - 1
            If (dgvNebulositeList.Columns("image").Index = i Or dgvNebulositeList.Columns("actinometrie").Index = i) Then
            Else

                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvNebulositeList.Rows.Count - 3
                    If (dgvNebulositeList.Rows(j).Cells(i).Value.ToString = "" Or dgvNebulositeList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvNebulositeList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvNebulositeList.Rows.Count > 2) Then
                    dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 1).Cells(i).Value = somme / (dgvNebulositeList.Rows.Count - 2)
                End If
            End If
        Next
        dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 2).DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 207, 46)
        dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238)
       
    End Sub
    Private Sub Total1()
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvTempPresionList.Columns.Count - 1
            If (dgvTempPresionList.Columns("image").Index = i) Then
            Else

                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvTempPresionList.Rows.Count - 3
                    If (dgvTempPresionList.Rows(j).Cells(i).Value.ToString = "" Or dgvTempPresionList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvTempPresionList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvTempPresionList.Rows(dgvTempPresionList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvTempPresionList.Rows.Count > 2) Then
                    dgvTempPresionList.Rows(dgvTempPresionList.Rows.Count - 1).Cells(i).Value = somme / (dgvTempPresionList.Rows.Count - 2)
                End If
            End If
        Next
        dgvTempPresionList.Rows(dgvTempPresionList.Rows.Count - 2).DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 207, 46)
        dgvTempPresionList.Rows(dgvTempPresionList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvNebulositeList.Columns.Count - 1
            If (dgvNebulositeList.Columns("image").Index = i Or dgvNebulositeList.Columns("actinometrie").Index = i) Then
            Else

                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvNebulositeList.Rows.Count - 3
                    If (dgvNebulositeList.Rows(j).Cells(i).Value.ToString = "" Or dgvNebulositeList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvNebulositeList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvNebulositeList.Rows.Count > 2) Then
                    dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 1).Cells(i).Value = somme / (dgvNebulositeList.Rows.Count - 2)
                End If
            End If
        Next
    End Sub

    Private Sub dgvTempPresionList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvTempPresionList.CellPainting

        If (e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 20) Then 'Or e.ColumnIndex = 14
            Me.dgvTempPresionList.Columns(e.ColumnIndex).Visible = False
        End If
        'If (e.ColumnIndex = 13) Then
        '    Me.dgvNebulositeList.Columns(e.ColumnIndex).Width = 100
        'Else
        '    Me.dgvNebulositeList.Columns(e.ColumnIndex).Width = 40
        'End If
        Me.dgvTempPresionList.Columns(e.ColumnIndex).Width = 40
        'Dim i As Integer = 0
        'For i = 0 To dgvNebulositeList.Columns.Count - 1
        '    Me.dgvNebulositeList.Columns(1).Visible = False
        '    Me.dgvNebulositeList.Columns(2).Visible = False
        '    Me.dgvNebulositeList.Columns(i).Width = 40
        '    Me.dgvNebulositeList.Columns(13).Width = 100
        'Next
    End Sub

    Private Sub dgvDirectionVentList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvDirectionVentList.CellPainting
        If (e.ColumnIndex = 0 Or e.ColumnIndex = 1 Or e.ColumnIndex = 23) Then 'Or e.ColumnIndex = 14
            Me.dgvDirectionVentList.Columns(e.ColumnIndex).Visible = False
        End If
        Me.dgvDirectionVentList.Columns(e.ColumnIndex).Width = 40
    End Sub

    
    Private Sub dgvDirectionVent_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDirectionVent.CellValidated
        Dim i, j As Integer
        Dim somme, val As Decimal
        i = j = 0
        For i = 0 To dgvDirectionVent.Columns.Count - 6

            If i Mod 2 <> 0 Then
                val = dgvDirectionVent.Rows(0).Cells(i).Value
                somme = somme + val
            End If

        Next

        'Dim col1, col2, col3, col4 As Integer
        'col1 = dgvDirectionVent.Rows(0).Cells(10).Value
        'col2 = dgvDirectionVent.Rows(0).Cells(9).Value
        'col3 = dgvDirectionVent.Rows(0).Cells(8).Value
        'col4 = dgvDirectionVent.Rows(0).Cells(7).Value
        'somme = col1 + col2 + col3 + col4
        dgvDirectionVent.Rows(0).Cells(16).Value = somme
        dgvDirectionVent.Rows(0).Cells(17).Value = somme / 8
    End Sub

  
    Private Sub btnAddLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLigne.Click
        dgvDirectionVentTcm.Rows.Add()
    End Sub

    Private Sub dgvTemperationSaisie_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTemperationSaisie.CellValidated
        Dim somme, col1 As Decimal
        Dim i As Integer
        For i = 0 To 7
            col1 = dgvTemperationSaisie.Rows(0).Cells(i).Value
            somme = somme + col1
        Next
        dgvTemperationSaisie.Rows(0).Cells(8).Value = somme
        dgvTemperationSaisie.Rows(0).Cells(9).Value = somme / 8
    End Sub

    Private Sub dgvTemperationList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvTemperationList.CellPainting
        If (e.ColumnIndex = 0 Or e.ColumnIndex = 16) Then
            Me.dgvTemperationList.Columns(e.ColumnIndex).Visible = False
        End If
        'If (e.ColumnIndex = 13) Then
        '    Me.dgvTemperationList.Columns(e.ColumnIndex).Width = 100
        'Else
        Me.dgvTemperationList.Columns(e.ColumnIndex).Width = 40
        'End If
    End Sub

    Private Sub dgvTemperatureMList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvTemperatureMList.CellPainting
        If (e.ColumnIndex = 0 Or e.ColumnIndex = 10) Then
            Me.dgvTemperatureMList.Columns(e.ColumnIndex).Visible = False
        End If
        'If (e.ColumnIndex = 13) Then
        '    Me.dgvTemperationList.Columns(e.ColumnIndex).Width = 100
        'Else
        Me.dgvTemperatureMList.Columns(e.ColumnIndex).Width = 40
        'End If
    End Sub
    Private Sub TotalTemperature()
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvTemperationList.Columns.Count - 1
            If (dgvTemperationList.Columns("image").Index = i) Then
            Else

                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvTemperationList.Rows.Count - 3
                    If (dgvTemperationList.Rows(j).Cells(i).Value.ToString = "" Or dgvTemperationList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvTemperationList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvTemperationList.Rows(dgvTemperationList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvTemperationList.Rows.Count > 2) Then
                    dgvTemperationList.Rows(dgvTemperationList.Rows.Count - 1).Cells(i).Value = somme / (dgvTemperationList.Rows.Count - 2)
                End If
            End If
        Next
        dgvTemperationList.Rows(dgvTemperationList.Rows.Count - 2).DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 207, 46)
        dgvTemperationList.Rows(dgvTemperationList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238)

    End Sub
    Private Sub TotalDirectionVent()
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvDirectionVent.Columns.Count - 4
            If i Mod 2 <> 0 Then
                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvDirectionVentList.Rows.Count - 3
                    If (dgvDirectionVentList.Rows(j).Cells(i).Value.ToString = "" Or dgvDirectionVentList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvDirectionVentList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvDirectionVentList.Rows(dgvDirectionVentList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvDirectionVentList.Rows.Count > 2) Then
                    dgvDirectionVentList.Rows(dgvDirectionVentList.Rows.Count - 1).Cells(i).Value = somme / (dgvDirectionVentList.Rows.Count - 2)
                End If
            End If
        Next
        dgvDirectionVentList.Rows(dgvDirectionVentList.Rows.Count - 2).DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 207, 46)
        dgvDirectionVentList.Rows(dgvDirectionVentList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238)

    End Sub

    Private Sub dgvVapeurHumiditeList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvVapeurHumiditeList.CellPainting
        If (e.ColumnIndex = 0 Or e.ColumnIndex = 22) Then
            Me.dgvVapeurHumiditeList.Columns(e.ColumnIndex).Visible = False
        End If
        'If (e.ColumnIndex = 13) Then
        '    Me.dgvTemperationList.Columns(e.ColumnIndex).Width = 100
        'Else
        Me.dgvVapeurHumiditeList.Columns(e.ColumnIndex).Width = 40
        'End If
    End Sub

    Private Sub dgvVapeurHumidite_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVapeurHumidite.CellValidated
        Dim somme, col1 As Decimal
        Dim i As Integer
        For i = 0 To 7
            col1 = Convert.ToDecimal(dgvVapeurHumidite.Rows(0).Cells(i).Value)
            somme = somme + col1
        Next
        dgvVapeurHumidite.Rows(0).Cells(8).Value = somme
        dgvVapeurHumidite.Rows(0).Cells(9).Value = somme / 8

        somme = 0

        For i = 14 To 17
            col1 = Convert.ToDecimal(dgvVapeurHumidite.Rows(0).Cells(i).Value)
            somme = somme + col1
        Next
        dgvVapeurHumidite.Rows(0).Cells(18).Value = somme
        dgvVapeurHumidite.Rows(0).Cells(19).Value = somme / 4

    End Sub

    Private Sub TotalVapeurHumidite()
        Dim i, j As Integer
        i = 0
        j = 0

        For i = 0 To dgvVapeurHumiditeList.Columns.Count - 1
            If (dgvVapeurHumiditeList.Columns("image").Index = i) Then
            Else

                Dim somme As Decimal = 0
                Dim val As Decimal = 0
                For j = 0 To dgvVapeurHumiditeList.Rows.Count - 3
                    If (dgvVapeurHumiditeList.Rows(j).Cells(i).Value.ToString = "" Or dgvVapeurHumiditeList.Rows(j).Cells(i).Value.ToString = String.Empty) Then
                        val = 0
                    Else
                        val = dgvVapeurHumiditeList.Rows(j).Cells(i).Value
                    End If
                    somme = somme + val
                Next
                dgvVapeurHumiditeList.Rows(dgvVapeurHumiditeList.Rows.Count - 2).Cells(i).Value = somme
                If (dgvVapeurHumiditeList.Rows.Count > 2) Then
                    dgvVapeurHumiditeList.Rows(dgvVapeurHumiditeList.Rows.Count - 1).Cells(i).Value = somme / (dgvVapeurHumiditeList.Rows.Count - 2)
                End If
            End If
        Next
        dgvVapeurHumiditeList.Rows(dgvVapeurHumiditeList.Rows.Count - 2).DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 207, 46)
        dgvVapeurHumiditeList.Rows(dgvVapeurHumiditeList.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238)

    End Sub

    Private Sub btnValidePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidePage.Click
        Dim strSQL As String = "INSERT INTO `acmad_tcm_page` (`id`, `station_id`, `month`, `year`,  `temp1`, `temp2`, `temp3`, `temp4`, `temp5`, `temp6`, `temp7`, `temp8`, `temp9`, `temp10`,`temp11`, `precip1`, `precip2`, `precip3`, `precip4`, `precip5`, `evap1`, `evap2`, `isolation`, `vitessemax`, `vitessemaxdate`, `caracteristique`, `bnp1`, `bnp2`, `bnp3`, `bnp4`, `bnp5`, `bnp6`, `bnp7`, `bnp8`, `bnp9`, `bnp10`, `bnp11`, `bnp12`, `bnp13`, `bnp14`, `bnp15`, `bnp16`, `bnp17`, `bnp18`, `bnp19`, `bnp20`, `bnp21`, `bnp22`, `bnp23`, `bnp24`, `bnp25`) " & _
       " VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", '" & TextBox19.Text & "','" & TextBox20.Text & "','" & TextBox21.Text & "','" & TextBox22.Text & "','" & TextBox23.Text & "','" & TextBox24.Text & "','" & TextBox25.Text & "','" & TextBox26.Text & "', '" & cbDateMinabsolu.SelectedItem(0) & "', '" & cbDateMaxabsolu.SelectedItem(0) & "', '" & cbDateMoyQuotidienne.SelectedItem(0) & "', '" & ComboBox1.SelectedItem(0) & "', '" & _
       TextBox27.Text & "','" & TextBox28.Text & "','" & TextBox29.Text & "','" & cbHmax24.SelectedItem(0) & "','" & TextBox30.Text & "','" & txtBac.Text & "','" & TextBox31.Text & "','" & TextBox32.Text & "','" & cbVMax.SelectedItem(0) & "','" & TextBox60.Text & "','" & TextBox33.Text & "','" & TextBox34.Text & "','" & TextBox35.Text & "','" & TextBox36.Text & "','" & TextBox39.Text & "','" & TextBox38.Text & "','" & TextBox37.Text & "','" & TextBox40.Text & "','" & TextBox41.Text & "','" & TextBox42.Text & "','" & TextBox43.Text & "','" & TextBox45.Text & "','" & TextBox44.Text & "','" & TextBox46.Text & "','" & TextBox47.Text & "','" & TextBox48.Text & "','" & TextBox49.Text & "','" & TextBox50.Text & "','" & TextBox51.Text & "','" & TextBox52.Text & _
      "','" & TextBox53.Text & "','" & TextBox54.Text & "','" & TextBox55.Text & "','" & TextBox56.Text & "','" & TextBox59.Text & "');"
        create(strSQL, "data added successful", "Error")
        'insert  details information
        Dim id As Integer = getLstId("select max(id) As id from acmad_tcm_page")
        Dim j As Integer
        For j = 0 To dgvDirectionVentTcm.Rows.Count - 1
            Dim strSQLs As String = ""
            strSQL = "INSERT INTO `acmad_tcm_page_details` (`id`, `tcm_page_id`, `vitesse`, `2`, `4`, `6`, `8`, `10`, `12`, `14`, `16`, `18`, `20`, `22`, `24`, `26`, `28`, `30`, `32`, `34`, `36`, `total`) " & _
            "VALUES (NULL," & id & ", '" & dgvDirectionVentTcm.Rows(j).Cells(0).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(1).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(1).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(2).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(3).Value & _
            "', '" & dgvDirectionVentTcm.Rows(j).Cells(4).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(5).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(6).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(7).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(8).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(9).Value & _
             "', '" & dgvDirectionVentTcm.Rows(j).Cells(10).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(11).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(12).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(13).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(14).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(15).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(16).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(17).Value & "', '" & dgvDirectionVentTcm.Rows(j).Cells(18).Value & "');"
            create(strSQL, "data added successful", "Error")
        Next
    End Sub
End Class