Public Class frmProductsSelect
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Private Sub formProductsSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"

        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            'sql = "SELECT * FROM tblproducts"
            sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "tblproducts")
            ' conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("tblproducts").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1

            cmbProductsCategory.Items.Add(ds.Tables("tblproducts").Rows(kount).Item("prCategory"))

        Next
    End Sub

    Private Sub cmbProductsCategory_Click(sender As Object, e As EventArgs) Handles cmbProductsCategory.Click

    End Sub

    Private Sub cmbProductsCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductsCategory.SelectedIndexChanged
        Dim prod As String

        prod = cmbProductsCategory.Text

        lstvProducts.Clear()
        lstvProducts.Columns.Clear()
        lstvProducts.Columns.Add("Products", 500, HorizontalAlignment.Left)

        sql = "SELECT prDetails FROM tblProducts WHERE prCategory=""" & prod & """"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "tblProducts")

        maxRows = (ds.Tables("tblProducts").Rows.Count)

        For kount = 0 To maxRows - 1 Step 1
            prod = ds.Tables("tblProducts").Rows(kount).Item("prDetails")
            lstvProducts.Items.Add(prod)

        Next
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lstvProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvProducts.SelectedIndexChanged

    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click

    End Sub
End Class