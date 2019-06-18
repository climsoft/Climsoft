Public Class acmad_dare_consult

    Private Sub acmad_dare_consult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCombobox("SELECT distinct country FROM station;", lbpays, "country", "country")
        loadCombobox("SELECT  `type`,`desc` FROM acmad_doc_type;", lbTypesdimages, "desc", "type")

    End Sub

    Private Sub btnrecherche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrecherche.Click

        Dim strSql As String = "SELECT  `station_id`,`image` FROM `" & lbTypesdimages.SelectedItem(0) & "`, `station`" & _
            "where `station`.stationId=`" & lbTypesdimages.SelectedItem(0) & "`.station_id and `station`.country='" & lbpays.SelectedItem(0) & "'"
        reloadDataDvgrid(strSql, dgvResultat)

    End Sub


    'Private Sub imageLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imageLink.Click
    ' imageLink.Link = "C:\PaperArchive\Images\" & dgvResultat.Rows(0).Cells(1).Value
    ' OpenFileDialog.FileName = "C:\PaperArchive\Images\" & dgvResultat.Rows(0).Cells(1).Value
    ' OpenFileDialog.ShowDialog()
    'End Sub

    Private Sub imageLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles imageLink.LinkClicked
        Process.Start("C:\PaperArchive\Images\" & dgvResultat.Rows(0).Cells(1).Value)
    End Sub
End Class