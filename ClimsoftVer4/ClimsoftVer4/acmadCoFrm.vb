Imports MySql.Data.MySqlClient

Public Class acmadCoFrm


    Private Sub acmadCoFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(TabPage3)
        dgvNuagesSaisie.Rows.Add()
        dvTemp.Rows.Add()
        dvTourSaisie.Rows.Add()
        dvTourSaisieObSup.Rows.Add()
        dvPression.Rows.Add()

        loadNuage()
        loadPressions()
        loadTemps()
        loadTours()
        loadCombobox("SELECT stationId,stationName FROM station ORDER by stationName;", cboStation, "stationName", "stationId")
    End Sub

    Private Sub btnValidTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidTemperature.Click
        If cbJourNuage.SelectedItem Is Nothing Then
            MsgBox("Please fill in all textBox")
        Else
            If (dgvNuagesSaisie.Rows(0).Cells(8).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_co_nuage` (`id`, `station_id`, `month`, `year`, `day`, `hh`, `15`, `16`, `17`, `18`, `19`, `20`, `21`, `22`,`image`) VALUES (NULL," & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbJourNuage.SelectedItem(0) & ", " & cbohh.SelectedItem(0) & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(0).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(1).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(2).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(3).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(4).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(5).Value & ", " & Me.dgvNuagesSaisie.Rows(0).Cells(6).Value & "," & Me.dgvNuagesSaisie.Rows(0).Cells(7).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_co_nuage` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourNuage.SelectedItem(0) & ",  `hh`=" & Me.dgvNuagesSaisie.Rows(0).Cells(0).Value & ",  `15`=" & Me.dgvNuagesSaisie.Rows(0).Cells(1).Value & ",  `16`=" & Me.dgvNuagesSaisie.Rows(0).Cells(2).Value & ", `17`=" & Me.dgvNuagesSaisie.Rows(0).Cells(3).Value & ",  `18`=" & Me.dgvNuagesSaisie.Rows(0).Cells(4).Value & ",  `19` =" & Me.dgvNuagesSaisie.Rows(0).Cells(5).Value & ",  `20` =" & Me.dgvNuagesSaisie.Rows(0).Cells(6).Value & ",  `22` =" & Me.dgvNuagesSaisie.Rows(0).Cells(7).Value & _
                      " WHERE `id` =" & dgvNuagesSaisie.Rows(0).Cells(8).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadNuage()
        End If
    End Sub
    Private Sub loadNuage()
        Dim strSql As String = "SELECT `id`,`day`, `hh`, `15`, `16`, `17`, `18`, `19`, `20`, `21`, `22`, `image` FROM `acmad_co_nuage`"
       
        reloadDataDvgrid(strSql, dgvNuagesList)
    End Sub

    Private Sub btnImgTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgTemperature.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbNuages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImgNuages.Text = OpenFileImport.FileName
        pbNuages.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        pbNuages.Height = pbNuages.Height + 2
        pbNuages.Width = pbNuages.Width + 2
    End Sub

    Private Sub btnzoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnzoomout.Click
        pbNuages.Height = pbNuages.Height - 2
        pbNuages.Width = pbNuages.Width - 2
    End Sub

    Private Sub btnRotationPrecipitation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotationPrecipitation.Click
        pbNuages.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbNuages.Refresh()
    End Sub


    Private Sub btnValiderTour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderTour.Click
        If cbJourTour.SelectedItem Is Nothing Then
            MsgBox("Please fill in all textBox")
        Else
            If (dvTourSaisie.Rows(0).Cells(14).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_co_tour` (`id`, `station_id`, `month`, `year`, `day`, `hh`,  `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `11`, `12`, `13`, `14`,`image`) VALUES (NULL," & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & "," & cbJourTour.SelectedItem(0) & ", " & Me.dvTourSaisie.Rows(0).Cells(0).Value & ", '" & Me.dvTourSaisie.Rows(0).Cells(1).Value & "', " & Me.dvTourSaisie.Rows(0).Cells(2).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(3).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(4).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(5).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(6).Value & ",'" & Me.dvTourSaisie.Rows(0).Cells(7).Value & "', " & Me.dvTourSaisie.Rows(0).Cells(8).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(9).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(10).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(11).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(12).Value & ", " & Me.dvTourSaisie.Rows(0).Cells(13).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                'MsgBox(strSql)
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_co_tour` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourTour.SelectedItem(0) & ",  `hh`=" & Me.dvTourSaisie.Rows(0).Cells(0).Value & ",  `1`=" & Me.dvTourSaisie.Rows(0).Cells(1).Value & ",  `2`=" & Me.dvTourSaisie.Rows(0).Cells(2).Value & ", `3`=" & Me.dvTourSaisie.Rows(0).Cells(3).Value & ",  `4`=" & Me.dvTourSaisie.Rows(0).Cells(4).Value & ",  `5` =" & Me.dvTourSaisie.Rows(0).Cells(5).Value & ",  `6` =" & Me.dvTourSaisie.Rows(0).Cells(6).Value & ",  `7` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `8` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `9` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `10` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `11` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `12` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & ",  `14` =" & Me.dvTourSaisie.Rows(0).Cells(7).Value & _
                      " WHERE `id` =" & dvTourSaisie.Rows(0).Cells(14).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadTours()
        End If
    End Sub
    Private Sub loadTours()
        Dim strSql As String = "SELECT  `hh`,  `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `11`, `12`, `13`, `14`,`id` FROM `acmad_co_tour`"
        reloadDataDvgrid(strSql, dvTourList)
        Dim i As Integer
        Dim j As Integer

        For j = 0 To dvTourList.Columns.Count - 1
            Me.dvTourList.Columns(j).Width = 10
        Next j


        'Dim data As DataTable = reloadDataTable(strSql)
        'For Each r As DataRow In data.Rows
        '    dvTourList.Rows.Add(r.Table.Rows)
        'Next
    End Sub

    Private Sub btnTour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTour.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbTour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImageTour.Text = OpenFileImport.FileName
        pbTour.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnTourRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTourRot.Click
        pbTour.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbTour.Refresh()
    End Sub

    Private Sub btnTourZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTourZoom.Click
        pbTour.Height = pbNuages.Height + 2
        pbTour.Width = pbNuages.Width + 2
    End Sub

    Private Sub btnTourZoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTourZoomout.Click
        pbTour.Height = pbNuages.Height - 2
        pbTour.Width = pbNuages.Width - 2
    End Sub


    Private Sub btnValidatePression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidatePression.Click
        If cbPression.SelectedItem Is Nothing Then
            MsgBox("Please fill in all textBox")

        Else
            If (dvPression.Rows(0).Cells(12).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_co_pression` (`id`, `station_id`, `month`, `year`, `day`, `hh`, `57`, `58`, `59`, `60`, `61`, `62`, `63`, `64`, `65`, `66`, `67`, `image`) VALUES (NULL," & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbPression.SelectedItem(0) & ", " & Me.dvPression.Rows(0).Cells(0).Value & ", " & Me.dvPression.Rows(0).Cells(1).Value & ", " & Me.dvPression.Rows(0).Cells(2).Value & ", " & Me.dvPression.Rows(0).Cells(3).Value & ", " & Me.dvPression.Rows(0).Cells(4).Value & ", " & Me.dvPression.Rows(0).Cells(5).Value & ", " & Me.dvPression.Rows(0).Cells(6).Value & "," & Me.dvPression.Rows(0).Cells(7).Value & ", " & Me.dvPression.Rows(0).Cells(8).Value & ", " & Me.dvPression.Rows(0).Cells(9).Value & ", " & Me.dvPression.Rows(0).Cells(10).Value & ", " & Me.dvPression.Rows(0).Cells(11).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                MsgBox(strSql)
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_co_tour` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbPression.SelectedItem(0) & ",  `hh`=" & Me.dvPression.Rows(0).Cells(0).Value & ",  `57`=" & Me.dvPression.Rows(0).Cells(1).Value & ",  `58`=" & Me.dvPression.Rows(0).Cells(2).Value & ", `59`=" & Me.dvPression.Rows(0).Cells(3).Value & ",  `60`=" & Me.dvPression.Rows(0).Cells(4).Value & ",  `61` =" & Me.dvPression.Rows(0).Cells(5).Value & ",  `62` =" & Me.dvPression.Rows(0).Cells(6).Value & ",  `63` =" & Me.dvPression.Rows(0).Cells(7).Value & ",  `64` =" & Me.dvPression.Rows(0).Cells(7).Value & ",  `65` =" & Me.dvPression.Rows(0).Cells(7).Value & ",  `66` =" & Me.dvPression.Rows(0).Cells(7).Value & ",  `67` =" & Me.dvPression.Rows(0).Cells(7).Value & _
                      " WHERE `id` =" & dvPression.Rows(0).Cells(11).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadPressions()
        End If
    End Sub

    Private Sub btnRotPression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotPression.Click
        pbPression.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbPression.Refresh()
    End Sub

    Private Sub btnZoomPression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomPression.Click
        pbPression.Height = pbNuages.Height + 2
        pbPression.Width = pbNuages.Width + 2
    End Sub

    Private Sub btnPressionZoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPressionZoomout.Click
        pbPression.Height = pbNuages.Height - 2
        pbPression.Width = pbNuages.Width - 2
    End Sub

    Private Sub btnTpRot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTpRot.Click
        pbtemp.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
        pbtemp.Refresh()
    End Sub

    Private Sub btnTpZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTpZoom.Click
        pbtemp.Height = pbtemp.Height + 2
        pbtemp.Width = pbtemp.Width + 2
    End Sub

    Private Sub btnTpZoomout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTpZoomout.Click
        pbtemp.Height = pbtemp.Height - 2
        pbtemp.Width = pbtemp.Width - 2
    End Sub

    Private Sub btnCalidationTemp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalidationTemp.Click
        If cbTempr.SelectedItem Is Nothing Then
            MsgBox("Please fill in all textBox")
        Else
            If (dvTemp.Rows(0).Cells(12).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_co_precipitation` (`id`, `station_id`, `month`, `year`, `day`, `hh`, `46`, `47`, `48`, `49`, `50`, `51`, `52`, `53`, `54`, `55`, `56`,`image`) VALUES (NULL," & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & ", " & cbTempr.SelectedItem(0) & ", " & Me.dvTemp.Rows(0).Cells(0).Value & ", " & Me.dvTemp.Rows(0).Cells(1).Value & ", " & Me.dvTemp.Rows(0).Cells(2).Value & ", " & Me.dvTemp.Rows(0).Cells(3).Value & ", " & Me.dvTemp.Rows(0).Cells(4).Value & ", " & Me.dvTemp.Rows(0).Cells(5).Value & ", " & Me.dvTemp.Rows(0).Cells(6).Value & "," & Me.dvTemp.Rows(0).Cells(7).Value & ", " & Me.dvTemp.Rows(0).Cells(8).Value & ", " & Me.dvTemp.Rows(0).Cells(9).Value & ", " & Me.dvTemp.Rows(0).Cells(10).Value & ", " & Me.dvTemp.Rows(0).Cells(11).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                MsgBox(strSql)
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_co_tour` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbPression.SelectedItem(0) & ",  `hh`=" & Me.dvTemp.Rows(0).Cells(0).Value & ",  `46`=" & Me.dvTemp.Rows(0).Cells(1).Value & ",  `47`=" & Me.dvTemp.Rows(0).Cells(2).Value & ", `48`=" & Me.dvTemp.Rows(0).Cells(3).Value & ",  `49`=" & Me.dvTemp.Rows(0).Cells(4).Value & ",  `50` =" & Me.dvTemp.Rows(0).Cells(5).Value & ",  `51` =" & Me.dvTemp.Rows(0).Cells(6).Value & ",  `52` =" & Me.dvTemp.Rows(0).Cells(7).Value & ",  `53` =" & Me.dvTemp.Rows(0).Cells(7).Value & ",  `54` =" & Me.dvTemp.Rows(0).Cells(7).Value & ",  `55` =" & Me.dvTemp.Rows(0).Cells(7).Value & ",  `56` =" & Me.dvTemp.Rows(0).Cells(7).Value & _
                      " WHERE `id` =" & dvTemp.Rows(0).Cells(12).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
            loadTemps()
        End If
    End Sub

    Private Sub btnPression_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPression.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbPression.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImagPression.Text = OpenFileImport.FileName
        pbPression.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub

    Private Sub btnTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTemperature.Click
        OpenFileImport.Filter = "Comma Delimited|*.*" '"Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()
        Me.pbtemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        txtImgTemp.Text = OpenFileImport.FileName
        pbtemp.Load(OpenFileImport.FileName)
        ''copie vers le repertoir archive
        My.Computer.FileSystem.CopyFile(
    OpenFileImport.FileName,
    "C:\PaperArchive\Images\" & System.IO.Path.GetFileName(OpenFileImport.FileName),
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        ''fin de la copie
    End Sub
    Private Sub loadPressions()
        Dim strSql As String = "SELECT *  FROM `acmad_co_pression`"
        reloadDataDvgrid(strSql, dvPressionList)
    End Sub
    Private Sub loadTemps()
        Dim strSql As String = "SELECT *  FROM `acmad_co_precipitation`"
        reloadDataDvgrid(strSql, dvTempList)
    End Sub

    Private Sub dgvNuagesSaisie_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuagesSaisie.CellEndEdit
        'Dim value As String = dgvNuagesSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dgvNuagesSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dgvNuagesSaisie.CurrentCell = dgvNuagesSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dgvNuagesSaisie.CurrentCell.Selected = True
        '        dgvNuagesSaisie.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
    End Sub

    Private Sub dvTourSaisie_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'Dim value As String = dvTourSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dvTourSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dvTourSaisie.CurrentCell = dvTourSaisie.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dvTourSaisie.CurrentCell.Selected = True
        '        dvTourSaisie.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
    End Sub

    Private Sub dvPression_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvPression.CellEndEdit
        'Dim value As String = dvPression.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dvPression.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dvPression.CurrentCell = dvPression.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dvPression.CurrentCell.Selected = True
        '        dvPression.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
    End Sub

    Private Sub dvTemp_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dvTemp.CellEndEdit
        'Dim value As String = dvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
        'For Each c As Char In value
        '    If Not Char.IsDigit(c) Then
        '        MsgBox("Please enter numeric value.")
        '        dvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = String.Empty
        '        dvTemp.CurrentCell = dvTemp.Rows(e.RowIndex).Cells(e.ColumnIndex)
        '        dvTemp.CurrentCell.Selected = True
        '        dvTemp.BeginEdit(True)
        '        Exit Sub
        '    End If
        'Next
    End Sub

    Private Sub cbMenu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMenu.SelectedIndexChanged
        TabControl1.TabPages.Clear()
        Select Case cbMenu.SelectedIndex
            Case 0
                TabControl1.TabPages.Add(TabPage3)
            Case 1
                TabControl1.TabPages.Add(TabPage4)
            Case 2
                TabControl1.TabPages.Add(TabPage5)
            Case 3
                TabControl1.TabPages.Add(TabPage6)
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


    Private Sub ModifierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifierToolStripMenuItem.Click
        'modifer dgvNuagesList
        'dgvNuagesSaisie.Rows(0).Cells(0).Value = dgvNuagesList.SelectedRows(0).Cells(1).Value 'date 
        cbJourNuage.SelectedIndex = cbJourNuage.FindString(dgvNuagesList.SelectedRows(0).Cells(1).Value.ToString)
        'dgvNuagesSaisie.Rows(0).Cells(0).Value = dgvNuagesList.SelectedRows(0).Cells(2).Value  'heure
        cbohh.SelectedIndex = cbohh.FindString(dgvNuagesList.SelectedRows(0).Cells(2).Value.ToString)
        dgvNuagesSaisie.Rows(0).Cells(0).Value = dgvNuagesList.SelectedRows(0).Cells(3).Value
        dgvNuagesSaisie.Rows(0).Cells(1).Value = dgvNuagesList.SelectedRows(0).Cells(4).Value
        dgvNuagesSaisie.Rows(0).Cells(2).Value = dgvNuagesList.SelectedRows(0).Cells(5).Value
        dgvNuagesSaisie.Rows(0).Cells(3).Value = dgvNuagesList.SelectedRows(0).Cells(6).Value
        dgvNuagesSaisie.Rows(0).Cells(4).Value = dgvNuagesList.SelectedRows(0).Cells(7).Value
        dgvNuagesSaisie.Rows(0).Cells(5).Value = dgvNuagesList.SelectedRows(0).Cells(8).Value
        dgvNuagesSaisie.Rows(0).Cells(6).Value = dgvNuagesList.SelectedRows(0).Cells(9).Value
        dgvNuagesSaisie.Rows(0).Cells(7).Value = dgvNuagesList.SelectedRows(0).Cells(10).Value
        dgvNuagesSaisie.Rows(0).Cells(8).Value = dgvNuagesList.SelectedRows(0).Cells(0).Value
        'apercu image
        'dgvNuagesList.SelectedRows(0).Cells(10).Value

        txtImgNuages.Text = "C:\PaperArchive\Images\" & dgvNuagesList.SelectedRows(0).Cells(11).Value 'OpenFileImport.FileName
        Me.pbNuages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbNuages.Load("C:\PaperArchive\Images\" & dgvNuagesList.SelectedRows(0).Cells(11).Value)

    End Sub

    Private Sub SupprimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupprimerToolStripMenuItem.Click
        'supprimer dgvNuagesList
        Dim strSql As String = "DELETE FROM `acmad_co_nuage` WHERE `id` =" & dgvNuagesList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadNuage()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        cbJourTour.SelectedIndex = cbJourTour.FindString(dvTourList.SelectedRows(0).Cells(1).Value.ToString)
        'modifier TourList
        dvTourSaisie.Rows(0).Cells(0).Value = dvTourList.SelectedRows(0).Cells(2).Value
        dvTourSaisie.Rows(0).Cells(1).Value = dvTourList.SelectedRows(0).Cells(3).Value
        dvTourSaisie.Rows(0).Cells(2).Value = dvTourList.SelectedRows(0).Cells(4).Value
        dvTourSaisie.Rows(0).Cells(3).Value = dvTourList.SelectedRows(0).Cells(5).Value
        dvTourSaisie.Rows(0).Cells(4).Value = dvTourList.SelectedRows(0).Cells(6).Value
        dvTourSaisie.Rows(0).Cells(5).Value = dvTourList.SelectedRows(0).Cells(7).Value
        dvTourSaisie.Rows(0).Cells(6).Value = dvTourList.SelectedRows(0).Cells(8).Value
        dvTourSaisie.Rows(0).Cells(7).Value = dvTourList.SelectedRows(0).Cells(9).Value
        dvTourSaisie.Rows(0).Cells(8).Value = dvTourList.SelectedRows(0).Cells(10).Value
        dvTourSaisie.Rows(0).Cells(9).Value = dvTourList.SelectedRows(0).Cells(11).Value
        dvTourSaisie.Rows(0).Cells(10).Value = dvTourList.SelectedRows(0).Cells(12).Value
        dvTourSaisie.Rows(0).Cells(11).Value = dvTourList.SelectedRows(0).Cells(13).Value
        dvTourSaisie.Rows(0).Cells(12).Value = dvTourList.SelectedRows(0).Cells(14).Value
        dvTourSaisie.Rows(0).Cells(13).Value = dvTourList.SelectedRows(0).Cells(0).Value

        'apercu image
        'dgvNuagesList.SelectedRows(0).Cells(10).Value

        txtImgNuages.Text = "C:\PaperArchive\Images\" & dvTourList.SelectedRows(0).Cells(16).Value 'OpenFileImport.FileName
        Me.pbTour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbTour.Load("C:\PaperArchive\Images\" & dvTourList.SelectedRows(0).Cells(16).Value)

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        'supprimer TourList
        Dim strSql As String = "DELETE FROM `acmad_co_tour` WHERE `id` =" & dvTourList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadTours()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        cbPression.SelectedIndex = cbPression.FindString(dvPressionList.SelectedRows(0).Cells(4).Value.ToString)

        'modifer dvPressionList
        dvPression.Rows(0).Cells(0).Value = dvPressionList.SelectedRows(0).Cells(5).Value
        dvPression.Rows(0).Cells(1).Value = dvPressionList.SelectedRows(0).Cells(6).Value
        dvPression.Rows(0).Cells(2).Value = dvPressionList.SelectedRows(0).Cells(7).Value
        dvPression.Rows(0).Cells(3).Value = dvPressionList.SelectedRows(0).Cells(8).Value
        dvPression.Rows(0).Cells(4).Value = dvPressionList.SelectedRows(0).Cells(9).Value
        dvPression.Rows(0).Cells(5).Value = dvPressionList.SelectedRows(0).Cells(10).Value
        dvPression.Rows(0).Cells(6).Value = dvPressionList.SelectedRows(0).Cells(11).Value
        dvPression.Rows(0).Cells(7).Value = dvPressionList.SelectedRows(0).Cells(12).Value
        dvPression.Rows(0).Cells(8).Value = dvPressionList.SelectedRows(0).Cells(13).Value
        dvPression.Rows(0).Cells(9).Value = dvPressionList.SelectedRows(0).Cells(14).Value
        dvPression.Rows(0).Cells(10).Value = dvPressionList.SelectedRows(0).Cells(15).Value
        dvPression.Rows(0).Cells(11).Value = dvPressionList.SelectedRows(0).Cells(16).Value
        dvPression.Rows(0).Cells(12).Value = dvPressionList.SelectedRows(0).Cells(0).Value
        'apercu image


        txtImgNuages.Text = "C:\PaperArchive\Images\" & dvPressionList.SelectedRows(0).Cells(17).Value 'OpenFileImport.FileName
        Me.pbPression.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbPression.Load("C:\PaperArchive\Images\" & dvPressionList.SelectedRows(0).Cells(17).Value)

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        'supprimer dvPressionList
        Dim strSql As String = "DELETE FROM `acmad_co_pression` WHERE `id` =" & dvPressionList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadPressions()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click

        cbTempr.SelectedIndex = cbTempr.FindString(dvTempList.SelectedRows(0).Cells(4).Value.ToString)

        'modifer dvTempList
        dvTemp.Rows(0).Cells(0).Value = dvTempList.SelectedRows(0).Cells(5).Value
        dvTemp.Rows(0).Cells(1).Value = dvTempList.SelectedRows(0).Cells(6).Value
        dvTemp.Rows(0).Cells(2).Value = dvTempList.SelectedRows(0).Cells(7).Value
        dvTemp.Rows(0).Cells(3).Value = dvTempList.SelectedRows(0).Cells(8).Value
        dvTemp.Rows(0).Cells(4).Value = dvTempList.SelectedRows(0).Cells(9).Value
        dvTemp.Rows(0).Cells(5).Value = dvTempList.SelectedRows(0).Cells(10).Value
        dvTemp.Rows(0).Cells(6).Value = dvTempList.SelectedRows(0).Cells(11).Value
        dvTemp.Rows(0).Cells(7).Value = dvTempList.SelectedRows(0).Cells(12).Value
        dvTemp.Rows(0).Cells(8).Value = dvTempList.SelectedRows(0).Cells(13).Value
        dvTemp.Rows(0).Cells(9).Value = dvTempList.SelectedRows(0).Cells(14).Value
        dvTemp.Rows(0).Cells(10).Value = dvTempList.SelectedRows(0).Cells(15).Value
        dvTemp.Rows(0).Cells(11).Value = dvTempList.SelectedRows(0).Cells(16).Value
        dvTemp.Rows(0).Cells(12).Value = dvTempList.SelectedRows(0).Cells(0).Value

        txtImgNuages.Text = "C:\PaperArchive\Images\" & dvTempList.SelectedRows(0).Cells(17).Value 'OpenFileImport.FileName
        Me.pbtemp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        pbtemp.Load("C:\PaperArchive\Images\" & dvTempList.SelectedRows(0).Cells(17).Value)


    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        'supprimer dvTempList
        Dim strSql As String = "DELETE FROM `acmad_co_precipitation` WHERE `id` =" & dvTempList.SelectedRows(0).Cells(0).Value
        delete(strSql, "data deleted successful", "Error")
        loadTemps()
    End Sub


    Private Sub dgvNuagesSaisie_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvNuagesSaisie.CellPainting
        If e.RowIndex = -1 Then ' AndAlso e.ColumnIndex = 1 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
        Me.dvTourSaisie.ColumnHeadersHeight() = 175
    End Sub

    Private Sub dvTemp_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dvTemp.CellPainting
        If e.RowIndex = -1 Then ' AndAlso e.ColumnIndex = 1 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
        Me.dvTourSaisie.ColumnHeadersHeight() = 175
    End Sub

    Private Sub dvTourSaisie_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dvTourSaisie.CellPainting
        If e.RowIndex = -1 Then ' AndAlso e.ColumnIndex = 1 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
        Me.dvTourSaisie.ColumnHeadersHeight() = 175
    End Sub

    Private Sub dvTourSaisieObSup_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dvTourSaisieObSup.CellPainting
        If e.RowIndex = -1 Then ' AndAlso e.ColumnIndex = 1 Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.FormattedValue, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
        Me.dvTourSaisieObSup.ColumnHeadersHeight() = 175
    End Sub


    Private Sub btnValiderTourObs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValiderTourObs.Click
        If cbJourTour.SelectedItem Is Nothing Then
            MsgBox("Please fill in all textBox")
        Else
            If (dvTourSaisieObSup.Rows(0).Cells(14).Value Is Nothing) Then
                Dim strSql As String = "INSERT INTO `acmad_co_tour` (`id`, `station_id`, `month`, `year`, `day`, `hh`,  `2`, `3`, `4`, `5`, `6`, `7`, `8`, `9`, `10`, `11`, `12`, `13`, `14`,`image`) VALUES (NULL," & cboStation.SelectedItem(0) & ", " & cboMonth.SelectedItem(0) & ", " & txtYear.Text & "," & cbJourTour.SelectedItem(0) & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(0).Value & ", '" & Me.dvTourSaisieObSup.Rows(0).Cells(1).Value & "', " & Me.dvTourSaisieObSup.Rows(0).Cells(2).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(3).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(4).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(5).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(6).Value & ",'" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & "', " & Me.dvTourSaisieObSup.Rows(0).Cells(8).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(9).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(10).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(11).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(12).Value & ", " & Me.dvTourSaisieObSup.Rows(0).Cells(13).Value & ",'" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "');"
                'MsgBox(strSql)
                create(strSql, "data added successful", "Error")
            Else
                Dim strSql As String = "Update `acmad_co_tour` set image='" & System.IO.Path.GetFileName(OpenFileImport.FileName) & "', `day`=" & cbJourTour.SelectedItem(0) & ",  `hh`=" & Me.dvTourSaisieObSup.Rows(0).Cells(0).Value & ",  `1`=" & Me.dvTourSaisieObSup.Rows(0).Cells(1).Value & ",  `2`=" & Me.dvTourSaisieObSup.Rows(0).Cells(2).Value & ", `3`=" & Me.dvTourSaisieObSup.Rows(0).Cells(3).Value & ",  `4`=" & Me.dvTourSaisieObSup.Rows(0).Cells(4).Value & ",  `5` =" & Me.dvTourSaisieObSup.Rows(0).Cells(5).Value & ",  `6` =" & Me.dvTourSaisieObSup.Rows(0).Cells(6).Value & ",  `7` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `8` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `9` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `10` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `11` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `12` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & ",  `14` =" & Me.dvTourSaisieObSup.Rows(0).Cells(7).Value & _
                      " WHERE `id` =" & dvTourSaisieObSup.Rows(0).Cells(14).Value
                'MsgBox(strSql)
                updates(strSql, "data updated successful", "Error")
            End If
        End If
    End Sub


End Class