Public Class frmKeyEntry

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String


    Private Sub frmKeyEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"

        'TODO: This line of code loads data into the 'Dataforms.data_forms' table

        ListView1.Columns.Add("Form Name", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Form Details", 600, HorizontalAlignment.Left)

        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM data_forms"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "data_forms")
            conn.Close()
            'MsgBox("Dataset Field !", MsgBoxStyle.Information)

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("data_forms").Rows.Count

        Dim str(2) As String
        Dim itm As ListViewItem
        Dim kount As Integer

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("data_forms").Rows(kount).Item("table_name")
            str(1) = ds.Tables("data_forms").Rows(kount).Item("description")
            itm = New ListViewItem(str)
            ListView1.Items.Add(itm)
        Next



    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class