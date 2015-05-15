Public Class frmProducts
    Public xy As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Dim SelectedProduct
    Private Sub formProductsSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"
        MyConnectionString = LoginForm.txtusrpwd.Text
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
        lstvProducts.Columns.Add("Products Name", 100, HorizontalAlignment.Left)
        lstvProducts.Columns.Add("Products Details", 500, HorizontalAlignment.Left)

        sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "tblProducts")

        maxRows = (ds.Tables("tblProducts").Rows.Count)
        Dim str(2) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("tblProducts").Rows(kount).Item("productName")
            str(1) = ds.Tables("tblProducts").Rows(kount).Item("prDetails")
            itm = New ListViewItem(str)
            lstvProducts.Items.Add(itm)
        Next
    End Sub

    Private Sub lstvProducts_Click(sender As Object, e As EventArgs) Handles lstvProducts.Click
        Dim prtyp As New ClassHelp
        'Dim formcaption As String

        For i = 0 To lstvProducts.Items.Count - 1
            If (lstvProducts.Items(i).Selected) Then
                prtyp.ProductType = lstvProducts.Items(i).Text
                Exit For
            End If
        Next

        formProductsSelectCriteria.lblProductType.Text = prtyp.ProductType

        ' Set Options for Wind Rose Selections
        'If prtyp.ProductType = "WindRose" Then
        '    formProductsSelectCriteria.pnlWindrose.Visible = True
        'Else
        '    formProductsSelectCriteria.pnlWindrose.Visible = False
        'End If

        'formcaption = ""
        'formcaption = formProductsSelectCriteria.Text & " For " & prtyp.ProductType
        'formProductsSelectCriteria.Text = formcaption
        'MsgBox(prtyp.ProductType)

        formProductsSelectCriteria.Show()

    End Sub

    'Public Function SelectProducts() As Boolean
    '    Dim prtyp As New ClassHelp

    '    For i = 0 To lstvProducts.Items.Count - 1
    '        If (lstvProducts.Items(i).Selected) Then
    '            prtyp.ProductType = lstvProducts.Items(i).Text
    '            MsgBox(prtyp.ProductType)
    '            formProductsSelectCriteria.Show()
    '            ' MsgBox(SelectedProduct)
    '            SelectProducts = True
    '        End If
    '    Next
    'End Function

    Private Sub lstvProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvProducts.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class