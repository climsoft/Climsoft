'Imports MySql.Data.MySqlClient
Imports MySqlConnector
Public Class frmDataForms
    Private dataCall As New DataCall
    Private dataTable As DataTable
    Dim conb As New MySqlConnector.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySqlConnector.MySqlCommand
    Dim sql As String
    Private Sub frmDataForms_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Dim conn As New MySqlConnector.MySqlConnection
        'Dim MyConnectionString As String
        'Dim cmd As New MySqlConnector.MySqlCommand
        'MyConnectionString = frmLogin.txtusrpwd.Text
        'conn.ConnectionString = MyConnectionString

        ' Add a record for key entry mode if not exists
        'Try
        '    Dim qry As MySqlConnector.MySqlCommand
        '    sql = "ALTER TABLE `data_forms` ADD COLUMN `entry_mode` TINYINT(2) NOT NULL DEFAULT '0' AFTER `sequencer`;"
        '    conn.Open()
        '    qry = New MySqlConnector.MySqlCommand(sql, conn)
        '    qry.CommandTimeout = 0
        '    qry.ExecuteNonQuery()

        '    conn.Close()
        'Catch ex As Exception
        '    If ex.HResult <> -2147467259 Then 'Existing record
        '        MsgBox(ex.HResult & " " & ex.Message)
        '    End If
        '    conn.Close()
        'End Try

        Try
            Dim itm As ListViewItem
            lstViewForms.Items.Clear()
            'set the database name and columns, set the key field for updating, then add the retrieved data to the listview
            dataCall.SetTableNameAndFields("data_forms", {"form_name", "description", "selected"})
            dataCall.AddKeyField("form_name")
            dataTable = dataCall.GetDataTable()
            For Each row As DataRow In dataTable.Rows
                itm = New ListViewItem({row.Item("form_name"), row.Item("description")})
                lstViewForms.Items.Add(itm)

                If row.Item("selected") = 1 Then
                    itm.Checked = True
                End If
            Next

            ClsTranslations.TranslateForm(Me)

            'TODO. in future this will be done automatically by TranslateForms(Me)
            ClsTranslations.TranslateComponent(lstViewForms, False)

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click

        Try
            Apply_Changes()
            Exit Sub
            'update the datatable
            For i = 0 To lstViewForms.Items.Count - 1
                dataTable.Rows(i).Item("selected") = If(lstViewForms.Items(i).Checked, 1, 0)
            Next
            'save the changes in the datatable
            dataCall.Save(dataTable)
            MessageBox.Show(ClsTranslations.GetTranslation("Form selection updated successfully"))
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
    End Sub


    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "settingupkeyentryformlist.htm")
    End Sub

    Sub Apply_Changes()
        MyConnectionString = frmLogin.txtusrpwd.Text
        conb.ConnectionString = MyConnectionString

        Try
            conb.Open()

            With lstViewForms
                sql = ""

                ' Build the query string
                For i = 0 To .Items.Count - 1
                    sql = sql & "update data_forms set selected = " & Int(.Items(i).Checked) & " where form_name = '" & .Items(i).SubItems(0).Text & "';"
                Next

                ' Execute the query
                cmd = New MySqlConnector.MySqlCommand(sql, conb)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()
                MessageBox.Show(ClsTranslations.GetTranslation("Form selection updated successfully"))
            End With

            conb.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conb.Close()
        End Try

    End Sub

End Class