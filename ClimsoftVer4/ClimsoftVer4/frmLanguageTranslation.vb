Public Class frmLanguageTranslation
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim sql As String
    Private Sub frmLanguageTranslation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()
            sql = "select * from language_translation"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "languageTranslation")
            Me.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "languageTranslation")
            MsgBox("Database table updated successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'MsgBox("Not yet implemented!", MsgBoxStyle.Information)
    End Sub
End Class