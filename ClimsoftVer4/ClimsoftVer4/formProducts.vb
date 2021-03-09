' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

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
        MyConnectionString = frmLogin.txtusrpwd.Text

        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            ProductsTable_Update()
            'sql = "SELECT * FROM tblproducts"
            sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            cmbProductsCategory.Items.Clear()
            lstvProducts.Clear()
            da.Fill(ds, "tblproducts")
            conn.Close()
            '------MaxRows assignment statement and [kount loop] below moved from position below [End Try] block
            maxRows = ds.Tables("tblproducts").Rows.Count
            For kount = 0 To maxRows - 1 Step 1

                cmbProductsCategory.Items.Add(ds.Tables("tblproducts").Rows(kount).Item("prCategory"))

            Next
            '--------------
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        '' maxRows = ds.Tables("tblproducts").Rows.Count
        'MsgBox(maxRows)
        ''For kount = 0 To maxRows - 1 Step 1

        ''    cmbProductsCategory.Items.Add(ds.Tables("tblproducts").Rows(kount).Item("prCategory"))

        ''Next
        Exit Sub

    End Sub

    Private Sub cmbProductsCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductsCategory.SelectedIndexChanged
        Dim prod As String

        prod = cmbProductsCategory.Text

        'If prod = "Rain Days" Then ProductsTable_Update()
        'ProductsTable_Update()
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
        Dim prtyp As New clsHelp
        'Dim formcaption As String

        For i = 0 To lstvProducts.Items.Count - 1
            If (lstvProducts.Items(i).Selected) Then
                prtyp.ProductType = lstvProducts.Items(i).Text
                Exit For
            End If
        Next

        If prtyp.ProductType = "Stations Records" Then
            frmInventoryChart.Show()
            Exit Sub
        ElseIf prtyp.ProductType = "CLIMAT" Then
            frmCLIMAT.Show()
            Exit Sub
        End If


        formProductsSelectCriteria.lblProductType.Text = prtyp.ProductType

        'If prtyp.ProductType = "Histograms" Or prtyp.ProductType = "TimeSeires" Then formProductsSelectCriteria.pnlSummary.Enabled = True

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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub


    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#products")

    End Sub

    Sub ProductsTable_Update()
        Dim currDB, sql0 As String
        Dim qry0 As MySql.Data.MySqlClient.MySqlCommand

        frmUserManagement.CurrentDB(MyConnectionString, currDB)

        sql0 = "USE `" & currDB & "`;
                CREATE TABLE IF NOT EXISTS `tblproducts` (
                  `productId` varchar(10) NOT NULL,
                  `productName` varchar(50) DEFAULT NULL,
                  `prDetails` varchar(50) DEFAULT NULL,
                  `prCategory` varchar(50) DEFAULT NULL,
                  PRIMARY KEY (`productId`),
                  KEY `productId` (`productId`)
                ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
               DELETE FROM `tblproducts`;
               INSERT INTO `tblproducts` (`productId`, `productName`, `prDetails`, `prCategory`) VALUES
               ('0', 'Minutes', 'Minutes observations', 'Data'),  
               ('01', 'Inventory', 'Details of Data Records', 'Inventory'),  
               ('02', 'Hourly', 'Summaries of Hourly Observations', 'Data'),  
               ('03', 'Daily', 'Summaries of Daily Observation', 'Data'),  
               ('04', 'Pentad', '5 Days Summeries', 'Data'),  
               ('05', 'Dekadal', '10 Days Summaries', 'Data'),  
               ('06', 'Monthly', 'Monthly Summaries', 'Data'),  
               ('07', 'Annual', 'Annual Summaries', 'Data'),  
               ('08', 'Means', 'Long Term Means', 'Data'),  
               ('09', 'Extremes', 'Long Term', 'Data'),  
               ('10', 'WindRose', 'Wind Rose Picture', 'Graphics'),  
               ('11', 'TimeSeries', 'Time Series Chart', 'Graphics'),  
               ('12', 'Histograms', 'Histogram Chart', 'Graphics'),  
               ('13', 'Instat', 'Daily Data for Instat', 'Output for other Applications'),  
               ('14', 'Rclimdex', 'Daily Data for Rclimdex', 'Output for other Applications'),  
               ('15', 'CPT', 'Data for CPT', 'Output for other Applications'),  
               ('16', 'GeoCLIM Monthly', 'Monthly Data for GeoCLIM', 'Output for other Applications'),  
               ('17', 'GeoCLIM Dekadal', 'Dekadal Data for Geoclim', 'Output for other Applications'),  
               ('18', 'GeoCLIM Daily', 'Daily Data for Geoclim', 'Output for other Applications'),   
               ('19', 'CLIMAT', 'CLIMAT Messages', 'Messages'),  
               ('20', 'Missing Data', 'Inventory of Missing Data', 'Inventory'),  
               ('21', 'CDT Dekadal', 'Dekadal Data for CDT', 'Output for other Applications'),  
               ('22', 'CDT Daily', 'Daily Data for CDT', 'Output for other Applications'),  
               ('23', 'Dekadal Counts', 'Dekadal Rain Days', 'Rain Days'),  
               ('24', 'Monthly Counts', 'Monthly Rain Days', 'Rain Days'),  
               ('25', 'Annual Counts', 'Annual Rain Days', 'Rain Days'),
               ('26', 'Daily Extremes', 'Daily Lowest and Highest values', 'Data'),
               ('27', 'Monthly Extremes', 'Monthly Lowest and Highest daily values', 'Data'),
               ('28', 'Annual Extremes', 'Annual Lowest and Highest daily values', 'Data'),
               ('29', 'Stations Records', 'Time Series Chart for Observing Stations', 'Inventory'),
               ('30', 'Yearly Elements Observed', 'Yearly Time Series Chart per Station', 'Inventory'),
               ('31', 'Monthly Elements Observed', 'Monthly Time Series Chart per Station', 'Inventory'),
               ('32', 'Daily Levels', 'Daily Observations', 'Upper Air'),
               ('33', 'Monthly Levels', 'Monthly Summeries', 'Upper Air'),
               ('34', 'Annual Levels', 'Annual Summeries', 'Upper Air');"
        Try
            Me.Cursor = Cursors.WaitCursor
            qry0 = New MySql.Data.MySqlClient.MySqlCommand(sql0, conn)

            qry0.CommandTimeout = 0
            qry0.ExecuteNonQuery()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class