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
    'Public xy As String
    Private dataTable As DataTable

    Private Sub formProductsSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'todo. this function is meant to update the products table everytime it's run
        ProductsTable_Update()

        'set up the products data table
        Dim clsDataCall As New DataCall
        clsDataCall.SetTableName("tblProducts")
        clsDataCall.SetFields({"productName", "prDetails", "prCategory"})
        dataTable = clsDataCall.GetDataTable()

        'set up the combobox data source
        Dim dctProductCategories As New Dictionary(Of String, String)
        For Each row As DataRow In dataTable.Rows
            'prCategory is duplicated in the databas, so only get unique values
            If Not dctProductCategories.ContainsKey(row.Field(Of String)("prCategory")) Then
                dctProductCategories.Add(
                    row.Field(Of String)("prCategory"),
                    ClsTranslations.GetTranslation(row.Field(Of String)("prCategory")))
            End If
        Next

        'initialise DisplayMember and ValueMember of the combobox to be filled with dictionary values
        'set the untranslated product category as the display member
        cboProductsCategory.ValueMember = "Key"
        'set the translated product category as the display member
        cboProductsCategory.DisplayMember = "Value"

        'bind the combobox to dictionary 
        cboProductsCategory.DataSource = New BindingSource(dctProductCategories, Nothing)

        cboProductsCategory.SelectedIndex = -1

        'translate form controls
        ClsTranslations.TranslateForm(Me)

    End Sub

    Private Sub cmbProductsCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProductsCategory.SelectedIndexChanged
        'clear list view rows
        lstViewProducts.Items.Clear()

        'get products of the selected category
        Dim dataRows() As DataRow = dataTable.Select("prCategory = '" & cboProductsCategory.SelectedValue & "'")

        If dataRows Is Nothing Then
            Exit Sub
        End If

        'add them to the list view
        For Each row As DataRow In dataRows
            'add product and prodcut details. List view has 2 columns
            lstViewProducts.Items.Add(New ListViewItem({row.Field(Of String)("productName"),
                                                 ClsTranslations.GetTranslation(row.Field(Of String)("prDetails"))})
                                                 )
        Next

    End Sub

    Private Sub lstvProducts_Click(sender As Object, e As EventArgs) Handles lstViewProducts.Click

        If lstViewProducts.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        Dim selectedProductName As String = lstViewProducts.SelectedItems.Item(0).Text
        Dim str(3), Ecode As String
        Dim itm = New ListViewItem

        Select Case selectedProductName
            Case "Stations Records"
                frmInventoryChart.Show()
            Case "CLIMAT"
                frmCLIMAT.Show()

                'Case Else
                'MsgBox(selectedProductName)
                'todo. refactor formProductsSelectCriteria to not use product type label
                'the label should show translated text

            Case "Daily Wind Speed"
                Ecode = InputBox(ClsTranslations.GetTranslation("Element Code?"), ClsTranslations.GetTranslation("Daily Wind Totalizer Element Code"))

                If Ecode = "" Or Not IsNumeric(Ecode) Then Exit Sub
                'If InputBox("Element Code?", "Daily Wind Totalizer Element Code") = "" Then Exit Sub
                'str(0) = CInt(InputBox("Element Code?", "Daily Wind Totalizer Element Code")) 'CInt(Ecode)

                str(0) = Ecode
                str(1) = "WINDTOT"
                str(2) = ClsTranslations.GetTranslation("Wind Totalizer")
                itm = New ListViewItem(str)
                formProductsSelectCriteria.lstvElements.Items.Clear()
                formProductsSelectCriteria.lstvElements.Items.Add(itm)
                formProductsSelectCriteria.lblProductType.Text = selectedProductName
                formProductsSelectCriteria.Show()

            Case "Hourly Wind Speed"
                Ecode = InputBox(ClsTranslations.GetTranslation("Element Code?"), ClsTranslations.GetTranslation("Hourly Wind Totalizer Element Code"))

                If Ecode = "" Or Not IsNumeric(Ecode) Then Exit Sub

                str(0) = Ecode
                str(1) = "WINDTOT"
                str(2) = ClsTranslations.GetTranslation("Wind Totalizer")
                itm = New ListViewItem(str)
                formProductsSelectCriteria.lstvElements.Items.Clear()
                formProductsSelectCriteria.lstvElements.Items.Add(itm)
                formProductsSelectCriteria.lblProductType.Text = selectedProductName
                formProductsSelectCriteria.Show()
            Case Else
                formProductsSelectCriteria.lblProductType.Text = selectedProductName
                formProductsSelectCriteria.Show()
        End Select

    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click, ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#products")
    End Sub

    'todo. should this always be called?? and is this the right place to call it
    'this should be done as part of the scripts update
    Private Sub ProductsTable_Update()
        Dim currDB As String = ""
        Dim sql0 As String
        Dim qry0 As MySql.Data.MySqlClient.MySqlCommand
        Dim MyConnectionString As String

        MyConnectionString = frmLogin.txtusrpwd.Text
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
               ('04', 'Pentad', '5 Days Summaries', 'Data'),  
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
               ('33', 'Monthly Levels', 'Monthly Summaries', 'Upper Air'),
               ('34', 'Annual Levels', 'Annual Summaries', 'Upper Air'),
               ('35', 'Seasonal Monthly', 'Monthly Seasonal Summaries', 'Data'),
               ('36', 'Daily Wind Speed', 'Wind Speed from Daily Wind Run Total', 'Data'),
               ('37', 'Hourly Wind Speed', 'Wind Speed from Hourly Wind Run Total', 'Data'),
               ('38', 'Climate Station', 'Data for Climate Station Tool', 'Output for other Applications'),
               ('39', 'Daily Mean Water Level', 'Hydrological Daily Mean Water Level', 'Special Products'),
               ('40', 'Monthly Mean Water Level', 'Hydrological Monthly Mean Water Level', 'Special Products'),
               ('41', 'Annual Mean Water Level', 'Hydrological Annual Mean Water Level', 'Special Products');"
        Try
            Me.Cursor = Cursors.WaitCursor
            qry0 = New MySql.Data.MySqlClient.MySqlCommand(sql0, clsDataConnection.GetOpenedConnection)
            qry0.CommandTimeout = 0
            qry0.ExecuteNonQuery()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class