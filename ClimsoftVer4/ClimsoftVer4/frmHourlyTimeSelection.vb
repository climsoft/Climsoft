Public Class frmHourlyTimeSelection
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim sql As String

    Private Sub frmHourlyTimeSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo Err
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        sql = "select * from form_hourly_time_selection"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "hourlyTimeSelection")
        Me.DataGridView1.DataSource = ds.Tables(0)
        'Me.DataGridView1.
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "hourlyTimeSelection")
            MsgBox("Database table updated successfully!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Not yet implemented!", MsgBoxStyle.Information)
    End Sub
    
End Class