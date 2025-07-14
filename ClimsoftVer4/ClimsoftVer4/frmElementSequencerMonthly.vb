Public Class frmElementSequencerMonthly
    Dim conn As New MySqlConnector.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySqlConnector.MySqlDataAdapter
    Dim sql As String

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.dataGridView1.Rows.Remove(dataGridView1.SelectedRows(0))
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "seqMonthlyElement")
            MsgBox("Record Deleted!", MsgBoxStyle.Information)
            dataGridView1.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmElementSequencerMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        sql = "select * from seq_monthly_element"
        da = New MySqlConnector.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "seqMonthlyElement")
        Me.dataGridView1.DataSource = ds.Tables(0)
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "seqMonthlyElement")
            MsgBox("Sequencer table updated successfully!", MsgBoxStyle.Information)
            Me.dataGridView1.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "monthlydata.htm")
    End Sub
End Class