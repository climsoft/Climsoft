Public Class frmHourlyTimeSelection
    Dim conn As New MySqlConnector.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySqlConnector.MySqlDataAdapter
    Dim sql As String

    Private Sub frmHourlyTimeSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()
            sql = "select * from form_hourly_time_selection"
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "hourlyTimeSelection")
            Me.DataGridView1.DataSource = ds.Tables(0)
            ClsTranslations.TranslateForm(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "hourlyTimeSelection")
            MsgBox("Database table updated successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "hourlydata.htm")
    End Sub
    
End Class