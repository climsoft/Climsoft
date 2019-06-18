Public Class acmadHyFrm

    Private Sub acmadHyFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dvDataMsaisie.Rows().Add()
        loadDataM()
        loadData()
        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(TabPage3)
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

    Private Sub loadData()
        Dim strSql As String = "SELECT * FROM `acmad_fh_day`"
        reloadDataDvgrid(strSql, dgvData)
    End Sub

    Private Sub btnValidData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidData.Click
        If cbJour.SelectedItem Is Nothing Or txtriviere.Text = "" Or txtObservateur.Text = "" Or txtHmatin.Text = "" Or txtHsoir.Text = "" Or txtObservation.Text = "" Then
            MsgBox("Please fill in all textBox")
        Else
            Dim strSQL As String = "INSERT INTO `acmad_fh_day` (`id`, `station_id`, `month`, `year`, `day`, `observator`, `Hmorning`, `Hafternoon`, `observations`) VALUES (NULL, " & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbJour.SelectedItem(0) & ", '" & txtObservateur.Text & "', '" & txtHmatin.Text & "', '" & txtHsoir.Text & "', '" & txtObservation.Text & "');"
            create(strSQL, "data added successful", "Error")
            loadData()
        End If
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

    Private Sub btnRotation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotation.Click
        pbData.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbData.Refresh()
    End Sub

    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        pbData.Height = pbData.Height + 4
        pbData.Width = pbData.Width + 4
    End Sub

    Private Sub btnzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomout.Click
        pbData.Height = pbData.Height - 4
        pbData.Width = pbData.Width - 4
    End Sub

    Private Sub btnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImg.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbData.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImg.Text = OpenFileImport.FileName
        pbData.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie

    End Sub

    Private Sub btnDataMRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMRot.Click
        pbDataM.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbDataM.Refresh()
    End Sub

    Private Sub btnDataMZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMZoom.Click
        pbDataM.Height = pbDataM.Height + 4
        pbDataM.Width = pbDataM.Width + 4
    End Sub

    Private Sub btnDataMZoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataMZoomout.Click
        pbDataM.Height = pbDataM.Height - 4
        pbDataM.Width = pbDataM.Width - 4
    End Sub

    Private Sub btnValiderM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderM.Click
        If (dvDataMsaisie.Rows(0).Cells(25).Value Is Nothing) Then
            Dim strSQL As String = "INSERT INTO `acmad_hy_mo` (`id`, `station_id`, `year`, `day`, `j_h`, `j_q`, `f_h`, `f_q`, `m_h`, `m_q`, `a_h`, `a_q`, `mai_h`, `mai_q`, `jun_h`, `jun_q`, `juillet_h`, `juillet_q`, `aout_h`, `aout_q`, `s_h`, `s_q`, `o_h`, `o_q`, `n_h`, `n_q`, `d_h`, `d_q`, `image`) " & _
    " VALUES (NULL,  " & cboStation.SelectedItem(0) & ", " & txtYear.Text & ", " & cbJourM.SelectedItem(0) & ", " & Me.dvDataMsaisie.Rows(0).Cells(0).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(1).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(2).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(3).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(4).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(5).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(6).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(7).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(8).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(9).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(10).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(11).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(12).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(13).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(14).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(15).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(16).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(17).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(18).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(19).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(20).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(21).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(22).Value & ", " & Me.dvDataMsaisie.Rows(0).Cells(23).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
            create(strSQL, "data added successful", "Error")
        Else
            Dim strSql As String = "Update `acmad_hy_mo` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourM.SelectedItem(0) & ",  `year`=" & txtYear.Text & ",  `j_h`=" & Me.dvDataMsaisie.Rows(0).Cells(1).Value & ",  `j_q`=" & Me.dvDataMsaisie.Rows(0).Cells(2).Value & ", `f_h`=" & Me.dvDataMsaisie.Rows(0).Cells(3).Value & ",  `f_q`=" & Me.dvDataMsaisie.Rows(0).Cells(4).Value & ",  `m_h` =" & Me.dvDataMsaisie.Rows(0).Cells(5).Value & ",  `m_q` =" & Me.dvDataMsaisie.Rows(0).Cells(6).Value & ",  `a_h` =" & Me.dvDataMsaisie.Rows(0).Cells(7).Value & ",  `a_q` =" & Me.dvDataMsaisie.Rows(0).Cells(8).Value & ",  `mai_h` =" & Me.dvDataMsaisie.Rows(0).Cells(9).Value & ",  `mai_q` =" & Me.dvDataMsaisie.Rows(0).Cells(10).Value & ",  `juin_h` =" & Me.dvDataMsaisie.Rows(0).Cells(11).Value & ",  `juin_q` =" & Me.dvDataMsaisie.Rows(0).Cells(12).Value & _
            ",  `juillet_h` =" & Me.dvDataMsaisie.Rows(0).Cells(13).Value & ",  `juillet_q` =" & Me.dvDataMsaisie.Rows(0).Cells(14).Value & ",  `aout_h` =" & Me.dvDataMsaisie.Rows(0).Cells(15).Value & ",  `aout_q` =" & Me.dvDataMsaisie.Rows(0).Cells(16).Value & ",  `s_h` =" & Me.dvDataMsaisie.Rows(0).Cells(17).Value & ",  `s_q` =" & Me.dvDataMsaisie.Rows(0).Cells(18).Value & ",  `o_h` =" & Me.dvDataMsaisie.Rows(0).Cells(19).Value & ",  `o_q` =" & Me.dvDataMsaisie.Rows(0).Cells(20).Value & ",  `n_h` =" & Me.dvDataMsaisie.Rows(0).Cells(21).Value & ",  `n_q` =" & Me.dvDataMsaisie.Rows(0).Cells(22).Value & ",  `d_h` =" & Me.dvDataMsaisie.Rows(0).Cells(23).Value & ",  `d_q` =" & Me.dvDataMsaisie.Rows(0).Cells(24).Value & _
            " WHERE `id` =" & dvDataMsaisie.Rows(0).Cells(25).Value
            'MsgBox(strSql)
            updates(strSql, "data updated successful", "Error")
        End If
        loadDataM()
    End Sub
    Private Sub loadDataM()
        Dim strSql As String = "SELECT * FROM `acmad_hy_mo`"
        reloadDataDvgrid(strSql, dgvDataMList)
    End Sub

    Private Sub dvDataMsaisie_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvDataMsaisie.CellEndEdit
        Dim value As String = dvDataMsaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        For Each c As Char In value
            If Not Char.IsDigit(c) Then
                MsgBox("Please enter numeric value.")
                dvDataMsaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
                dvDataMsaisie.CurrentCell = dvDataMsaisie.Rows(e.RowIndex).Cells(e.ColumnIndex)
                dvDataMsaisie.CurrentCell.Selected = True
                dvDataMsaisie.BeginEdit(True)
                Exit Sub
            End If
        Next
    End Sub

    Private Sub btnImgDataM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgDataM.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbDataM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImageM.Text = OpenFileImport.FileName
        pbDataM.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        'modifier dgvDataMList
        dvDataMsaisie.Rows(0).Cells(0).Value = dgvDataMList.SelectedRows(0).Cells(2).Value
        dvDataMsaisie.Rows(0).Cells(1).Value = dgvDataMList.SelectedRows(0).Cells(3).Value
        dvDataMsaisie.Rows(0).Cells(2).Value = dgvDataMList.SelectedRows(0).Cells(4).Value
        dvDataMsaisie.Rows(0).Cells(3).Value = dgvDataMList.SelectedRows(0).Cells(5).Value
        dvDataMsaisie.Rows(0).Cells(4).Value = dgvDataMList.SelectedRows(0).Cells(6).Value
        dvDataMsaisie.Rows(0).Cells(5).Value = dgvDataMList.SelectedRows(0).Cells(7).Value
        dvDataMsaisie.Rows(0).Cells(6).Value = dgvDataMList.SelectedRows(0).Cells(8).Value
        dvDataMsaisie.Rows(0).Cells(7).Value = dgvDataMList.SelectedRows(0).Cells(9).Value
        dvDataMsaisie.Rows(0).Cells(8).Value = dgvDataMList.SelectedRows(0).Cells(10).Value
        dvDataMsaisie.Rows(0).Cells(9).Value = dgvDataMList.SelectedRows(0).Cells(11).Value
        dvDataMsaisie.Rows(0).Cells(10).Value = dgvDataMList.SelectedRows(0).Cells(12).Value
        dvDataMsaisie.Rows(0).Cells(11).Value = dgvDataMList.SelectedRows(0).Cells(13).Value
        dvDataMsaisie.Rows(0).Cells(12).Value = dgvDataMList.SelectedRows(0).Cells(14).Value
        dvDataMsaisie.Rows(0).Cells(13).Value = dgvDataMList.SelectedRows(0).Cells(15).Value
        dvDataMsaisie.Rows(0).Cells(14).Value = dgvDataMList.SelectedRows(0).Cells(16).Value
        dvDataMsaisie.Rows(0).Cells(15).Value = dgvDataMList.SelectedRows(0).Cells(17).Value
        dvDataMsaisie.Rows(0).Cells(16).Value = dgvDataMList.SelectedRows(0).Cells(18).Value
        dvDataMsaisie.Rows(0).Cells(17).Value = dgvDataMList.SelectedRows(0).Cells(19).Value
        dvDataMsaisie.Rows(0).Cells(18).Value = dgvDataMList.SelectedRows(0).Cells(20).Value
        dvDataMsaisie.Rows(0).Cells(19).Value = dgvDataMList.SelectedRows(0).Cells(21).Value
        dvDataMsaisie.Rows(0).Cells(20).Value = dgvDataMList.SelectedRows(0).Cells(22).Value
        dvDataMsaisie.Rows(0).Cells(21).Value = dgvDataMList.SelectedRows(0).Cells(23).Value
        dvDataMsaisie.Rows(0).Cells(22).Value = dgvDataMList.SelectedRows(0).Cells(24).Value
        dvDataMsaisie.Rows(0).Cells(23).Value = dgvDataMList.SelectedRows(0).Cells(0).Value
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'supprimer dgvDataMList
        Dim strSql As String = "DELETE FROM `acmad_hy_mo` WHERE `id` =" & dgvDataMList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadDataM()
    End Sub
End Class