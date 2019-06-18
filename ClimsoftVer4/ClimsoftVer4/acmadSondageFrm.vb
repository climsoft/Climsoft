Public Class acmadSondageFrm

    Private Sub acmadSondageFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvPilot.Rows().Add()
        dvRadio.Rows().Add()
        loadDataRadio()
        loadDataPilot()
        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(TabPage3)
        loadCombobox("SELECT stationId,stationName FROM station ORDER by stationName;", cboStation, "stationName", "stationId")

    End Sub
    Private Sub loadDataRadio()
        Dim strSql As String = "SELECT * FROM `acmad_radio_sondage`"
        reloadDataDvgrid(strSql, dvRadioList)
    End Sub
    Private Sub loadDataPilot()
        Dim strSql As String = "SELECT * FROM `acmad_pilot_sondage`"
        reloadDataDvgrid(strSql, dvPilotList)
    End Sub

    Private Sub btnRotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotation.Click
        pbRadio.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbRadio.Refresh()
    End Sub

    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        pbRadio.Height = pbRadio.Height + 4
        pbRadio.Width = pbRadio.Width + 4
    End Sub

    Private Sub btnzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomout.Click
        pbRadio.Height = pbRadio.Height - 4
        pbRadio.Width = pbRadio.Width - 4
    End Sub

    Private Sub btnValiderRadio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderRadio.Click
        If (dvRadio.Rows(0).Cells(8).Value Is Nothing) Then
            Dim strSQL As String = "INSERT INTO `acmad_radio_sondage` (`id`, `station_id`, `month`, `year`, `day`, `duree`, `vitesseBallon`, `pression`, `temperature`, `humidite`, `dewpoint`, `direction`, `vitesse`, `image`)" & _
    " VALUES (NULL,  " & cboStation.SelectedItem(0) & ", " & txtYear.Text & ", " & txtYear.Text & ", " & cbRadio.SelectedItem(0) & ", " & Me.dvRadio.Rows(0).Cells(0).Value & ", " & Me.dvRadioList.Rows(0).Cells(1).Value & ", " & Me.dvRadioList.Rows(0).Cells(2).Value & ", " & Me.dvRadioList.Rows(0).Cells(3).Value & ", " & Me.dvRadioList.Rows(0).Cells(4).Value & ", " & Me.dvRadioList.Rows(0).Cells(5).Value & ", " & Me.dvRadioList.Rows(0).Cells(6).Value & ", " & Me.dvRadioList.Rows(0).Cells(7).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
            create(strSQL, "data added successful", "Error")
        Else
            Dim strSql As String = "UPDATE `acmad_radio_sondage` SET `year` = '" & txtYear.Text & "', `day` = '" & cbRadio.SelectedItem(0) & "', `duree` = " & Me.dvRadio.Rows(0).Cells(0).Value & ", `vitesseBallon` = " & Me.dvRadio.Rows(0).Cells(1).Value & ", `pression` = " & Me.dvRadio.Rows(0).Cells(2).Value & ", `temperature` = " & Me.dvRadio.Rows(0).Cells(3).Value & ", `humidite` = " & Me.dvRadio.Rows(0).Cells(4).Value & ", `dewpoint` = " & Me.dvRadio.Rows(0).Cells(5).Value & ", `direction` = " & Me.dvRadio.Rows(0).Cells(6).Value & ", `vitesse` = " & Me.dvRadio.Rows(0).Cells(7).Value & ", `image` = '" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "' WHERE `acmad_radio_sondage`.`id` = " & Me.dvRadio.Rows(0).Cells(7).Value & ";"
            'MsgBox(strSql)
            updates(strSql, "data updated successful", "Error")
        End If
        loadDataRadio()
    End Sub

    Private Sub btnDataMRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMRot.Click
        pbPilot.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbPilot.Refresh()
    End Sub

    Private Sub btnDataMZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMZoom.Click
        pbPilot.Height = pbPilot.Height + 4
        pbPilot.Width = pbPilot.Width + 4
    End Sub

    Private Sub btnDataMZoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMZoomout.Click
        pbPilot.Height = pbPilot.Height - 4
        pbPilot.Width = pbPilot.Width - 4
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        'modifier radio
        dvRadio.Rows(0).Cells(0).Value = dvRadioList.SelectedRows(0).Cells(2).Value
        dvRadio.Rows(0).Cells(1).Value = dvRadioList.SelectedRows(0).Cells(3).Value
        dvRadio.Rows(0).Cells(2).Value = dvRadioList.SelectedRows(0).Cells(4).Value
        dvRadio.Rows(0).Cells(3).Value = dvRadioList.SelectedRows(0).Cells(5).Value
        dvRadio.Rows(0).Cells(4).Value = dvRadioList.SelectedRows(0).Cells(6).Value
        dvRadio.Rows(0).Cells(5).Value = dvRadioList.SelectedRows(0).Cells(7).Value
        dvRadio.Rows(0).Cells(6).Value = dvRadioList.SelectedRows(0).Cells(8).Value
        dvRadio.Rows(0).Cells(7).Value = dvRadioList.SelectedRows(0).Cells(0).Value
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'suprimer radio
        Dim strSql As String = "DELETE FROM `acmad_radio_sondage` WHERE `id` =" & dvRadioList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadDataRadio()
    End Sub

    Private Sub btnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImg.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbRadio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImg.Text = OpenFileImport.FileName
        pbRadio.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnImgDataM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgDataM.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbPilot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImageM.Text = OpenFileImport.FileName
        pbPilot.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnValiderM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderM.Click
        If (dvRadio.Rows(0).Cells(8).Value Is Nothing) Then
            Dim strSQL As String = "INSERT INTO `acmad_pilot_sondage` (`id`, `station_id`, `month`, `year`, `date`, `h_debut`, `couleur_balon`, `vitesse_ascentionnelle`, `hauteur`, `altitude`, `azimut`, `inclinaison`, `distance`, `vent_direction`, `vent_vitesse`, `codification`, `message`, `image`)" & _
    " VALUES (NULL,  " & cboStation.SelectedItem(0) & ", " & txtYear.Text & ", " & txtYear.Text & ", " & cbPilot.SelectedItem(0) & ", " & Me.dvRadio.Rows(0).Cells(0).Value & ", " & Me.dvPilot.Rows(0).Cells(1).Value & ", " & Me.dvPilot.Rows(0).Cells(2).Value & ", " & Me.dvPilot.Rows(0).Cells(3).Value & ", " & Me.dvPilot.Rows(0).Cells(4).Value & ", " & Me.dvPilot.Rows(0).Cells(5).Value & ", " & Me.dvPilot.Rows(0).Cells(6).Value & ", " & Me.dvPilot.Rows(0).Cells(7).Value & ", " & Me.dvPilot.Rows(0).Cells(8).Value & ", " & Me.dvPilot.Rows(0).Cells(9).Value & ", " & Me.dvPilot.Rows(0).Cells(10).Value & ", " & Me.dvPilot.Rows(0).Cells(11).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
            create(strSQL, "data added successful", "Error")
        Else
            Dim strSql As String = "UPDATE `acmad_pilot_sondage` SET `month` = '" & txtYear.Text & "', `year` = '" & txtYear.Text & "', `date` = '" & Me.dvRadio.Rows(0).Cells(0).Value & "', `h_debut` = " & Me.dvRadio.Rows(0).Cells(1).Value & ", `couleur_balon` = '" & Me.dvRadio.Rows(0).Cells(2).Value & "', `vitesse_ascentionnelle` = " & Me.dvRadio.Rows(0).Cells(3).Value & ", `hauteur` = " & Me.dvRadio.Rows(0).Cells(4).Value & ", `altitude` = " & Me.dvRadio.Rows(0).Cells(5).Value & ", `azimut` = " & Me.dvRadio.Rows(0).Cells(6).Value & ", `inclinaison` = " & Me.dvRadio.Rows(0).Cells(7).Value & ", `distance` = " & Me.dvRadio.Rows(0).Cells(8).Value & ", `vent_direction` = '" & Me.dvRadio.Rows(0).Cells(9).Value & "', `vent_vitesse` = " & Me.dvRadio.Rows(0).Cells(10).Value & ", `codification` = '2', `message` = '" & Me.dvRadio.Rows(0).Cells(11).Value & "', `image` = '" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "' WHERE `acmad_pilot_sondage`.`id` = " & Me.dvRadio.Rows(0).Cells(12).Value & ";"
            'MsgBox(strSql)
            updates(strSql, "data updated successful", "Error")
        End If
        loadDataRadio()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        'pilot modif
        dvPilot.Rows(0).Cells(0).Value = dvPilotList.SelectedRows(0).Cells(2).Value
        dvPilot.Rows(0).Cells(1).Value = dvPilotList.SelectedRows(0).Cells(3).Value
        dvPilot.Rows(0).Cells(2).Value = dvPilotList.SelectedRows(0).Cells(4).Value
        dvPilot.Rows(0).Cells(3).Value = dvPilotList.SelectedRows(0).Cells(5).Value
        dvPilot.Rows(0).Cells(4).Value = dvPilotList.SelectedRows(0).Cells(6).Value
        dvPilot.Rows(0).Cells(5).Value = dvPilotList.SelectedRows(0).Cells(7).Value
        dvPilot.Rows(0).Cells(6).Value = dvPilotList.SelectedRows(0).Cells(8).Value
        dvPilot.Rows(0).Cells(7).Value = dvPilotList.SelectedRows(0).Cells(9).Value
        dvPilot.Rows(0).Cells(8).Value = dvPilotList.SelectedRows(0).Cells(10).Value
        dvPilot.Rows(0).Cells(9).Value = dvPilotList.SelectedRows(0).Cells(11).Value
        dvPilot.Rows(0).Cells(10).Value = dvPilotList.SelectedRows(0).Cells(12).Value
        dvPilot.Rows(0).Cells(11).Value = dvPilotList.SelectedRows(0).Cells(0).Value
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'pilot supprimer
        Dim strSql As String = "DELETE FROM `acmad_pilot_sondage` WHERE `id` =" & dvPilotList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadDataPilot()
    End Sub

    Private Sub cbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMenu.SelectedIndexChanged
        TabControl1.TabPages.Clear()
        Select Case cbMenu.SelectedIndex
            Case 0
                TabControl1.TabPages.Add(TabPage3)
            Case 1
                TabControl1.TabPages.Add(TabPage4)
            Case Else
                TabControl1.TabPages.Add(TabPage3)
        End Select
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
End Class