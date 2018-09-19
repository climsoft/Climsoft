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

        MyConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = MyConnectionString

        ' Add a record for key entry mode if not exists
        Try
            Dim qry As MySql.Data.MySqlClient.MySqlCommand
            sql = "ALTER TABLE `data_forms` ADD COLUMN `entry_mode` TINYINT(2) NOT NULL DEFAULT '0' AFTER `sequencer`;"
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            If ex.HResult <> -2147467259 Then 'Existing record
                MsgBox(ex.HResult & " " & ex.Message)
            End If
            conn.Close()
        End Try



        lstvForms.Clear()
        lstvForms.Columns.Clear()

        lstvForms.Columns.Add("Form Name", 150, HorizontalAlignment.Left)
        lstvForms.Columns.Add("Form Details", 400, HorizontalAlignment.Left)
        'lstvForms.Columns.Add("Mode", 50, HorizontalAlignment.Center)

        Try

            conn.Open()

            'sql = "SELECT selected,form_name, description, entry_mode FROM data_forms;"
            sql = "SELECT selected,form_name, description, entry_mode FROM data_forms;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            For i = 0 To ds.Tables("data_forms").Rows.Count - 1
                col(0) = ds.Tables("data_forms").Rows(i).Item(1)
                col(1) = ds.Tables("data_forms").Rows(i).Item(2)
                'col(3) = ds.Tables("data_forms").Rows(i).Item(3)
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

        On Error GoTo Err

        For i = 0 To lstvForms.Items.Count - 1
            If lstvForms.Items(i).Checked = True Then
                sql = "UPDATE data_forms SET selected = 1 WHERE form_name = '" & lstvForms.Items(i).SubItems(0).Text & "';"
            Else
                sql = "UPDATE data_forms set SELECTED = 0 WHERE form_name = '" & lstvForms.Items(i).SubItems(0).Text & "';"
            End If

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()
        Next

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

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