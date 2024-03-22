Public Class frmHourly2Sequencer
    Private clsDataCall As New DataCall
    Private dtbl As DataTable

    Private Sub frmHourly2Sequencer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetUpDialog()
    End Sub

    Private Sub dataGridViewHours_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridViewHours.CellContentClick
        ' Change the selection state
        dataGridViewHours.Rows.Item(e.RowIndex).Cells(1).Value = Not dataGridViewHours.Rows.Item(e.RowIndex).Cells(1).Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ' Delete all hours present if they are there
        If dtbl.Rows.Count > 0 Then
            For index As Integer = 0 To dtbl.Rows.Count - 1
                dtbl.Rows(index).Delete()
            Next

            If Not clsDataCall.Save(dtbl) Then
                MessageBox.Show(Me, "Could Not delete previous Hourly2 Sequencers", "Hourly2 Sequencer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                SetUpDialog()
                'if not successful exit 
                Exit Sub
            End If
        End If

        ' Save the new hours
        For index As Integer = 0 To dataGridViewHours.Rows.Count - 1
            If dataGridViewHours.Rows.Item(index).Cells(1).Value Then
                dtbl.Rows.Add({dataGridViewHours.Rows.Item(index).Cells(0).Value})
            End If
        Next

        If clsDataCall.Save(dtbl) Then
            MessageBox.Show(Me, "Hourly2 Sequencer Saved Successfully", "Hourly2 Sequencer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show(Me, "Hourly2 Sequencer NOT Saved", "Hourly2 Sequencer", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        SetUpDialog()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SetUpDialog()

        clsDataCall.SetTableNameAndFields("seq_hour", {"hh"})
        clsDataCall.SetKeyFields({"hh"})
        dtbl = clsDataCall.GetDataTable()

        dataGridViewHours.Rows.Clear()

        ' Set all hours
        Dim iRowIndex As Integer
        For iHour As Integer = 0 To 23
            iRowIndex = dataGridViewHours.Rows.Add()
            dataGridViewHours.Rows.Item(iRowIndex).Cells(0).Value = iHour

            Dim row As DataRow = dtbl.Select("hh = '" & iHour & "'").FirstOrDefault()
            dataGridViewHours.Rows.Item(iRowIndex).Cells(1).Value = row IsNot Nothing
        Next
    End Sub

End Class