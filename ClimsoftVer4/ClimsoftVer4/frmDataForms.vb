Public Class frmDataForms

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

    Private Sub frmDataForms_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim col(2) As String
        Dim itm As New ListViewItem

        lstvForms.Clear()
        lstvForms.Columns.Clear()

        lstvForms.Columns.Add("Form Name", 150, HorizontalAlignment.Left)
        lstvForms.Columns.Add("Form Details", 600, HorizontalAlignment.Left)
        Try
            MyConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT selected,form_name, description FROM data_forms;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            For i = 0 To ds.Tables("data_forms").Rows.Count - 1
                col(0) = ds.Tables("data_forms").Rows(i).Item(1)
                col(1) = ds.Tables("data_forms").Rows(i).Item(2)
                itm = New ListViewItem(col)
                lstvForms.Items.Add(itm)
                If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then lstvForms.Items(i).Checked = True
            Next
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click

        cmd.Connection = conn

        On Error GoTo err
        For i = 0 To lstvForms.Items.Count - 1
            If lstvForms.Items(i).Checked = True Then

                sql = "UPDATE data_forms SET selected = 1 WHERE form_name = '" & lstvForms.Items(i).Text & "';"
            Else
                sql = "UPDATE data_forms set SELECTED = 0 WHERE form_name = '" & lstvForms.Items(i).Text & "';"
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

        Next
        MsgBox(msgKeyentryFormsListUpdated, MsgBoxStyle.Information)
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "settingupkeyentryformlist.htm")
    End Sub
End Class