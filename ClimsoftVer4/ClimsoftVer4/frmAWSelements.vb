Public Class frmAWSelements

    Dim conn As New MySqlConnector.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySqlConnector.MySqlDataAdapter
    Dim sql As String

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "AWSelements")
            MsgBox("Record Deleted!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmElementSequencerDaily_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        sql = "select * from aws_elements"
        da = New MySqlConnector.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "AWSelements")
        Me.DataGridView1.DataSource = ds.Tables(0)

        'translate form controls
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "AWSelements")
            MsgBox("Table updated successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'MsgBox("Not yet implemented!", MsgBoxStyle.Information)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#AWSelements")
    End Sub
End Class