Public Class formProductsSelectCriteria
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Private Sub pnlStationsElements_Paint(sender As Object, e As PaintEventArgs) Handles pnlStationsElements.Paint

    End Sub

    'Private Sub formProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Dim prtyp As New clsProducts

    '    MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"

    '    'TODO: This line of code loads data into the 'Dataforms.data_forms' table

    '    lstvProducts.Columns.Add("Product Name", 100, HorizontalAlignment.Left)
    '    lstvProducts.Columns.Add("Product Details", 500, HorizontalAlignment.Left)

    '    Try
    '        conn.ConnectionString = MyConnectionString
    '        conn.Open()

    '        'MsgBox("Connection Successful !", MsgBoxStyle.Information)

    '        sql = "SELECT * FROM tblproducts"
    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        da.Fill(ds, "tblproducts")
    '        conn.Close()
    '        'MsgBox("Dataset Field !", MsgBoxStyle.Information)

    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        MessageBox.Show(ex.Message)
    '    End Try

    '    maxRows = ds.Tables("tblproducts").Rows.Count

    '    Dim str(2) As String
    '    Dim itm As ListViewItem

    '    For kount = 0 To maxRows - 1 Step 1
    '        'MsgBox(ds.Tables("data_forms").Rows(kount).Item("selected"))
    '        'If ds.Tables("data_forms").Rows(kount).Item("selected") = 1 Then
    '        str(0) = ds.Tables("tblproducts").Rows(kount).Item("productName")
    '        str(1) = ds.Tables("tblproducts").Rows(kount).Item("prDetails")
    '        itm = New ListViewItem(str)
    '        lstvProducts.Items.Add(itm)
    '        ' End If
    '    Next
    '    ' MsgBox(ListView1.Items.Count)
    '    'MsgBox((ListView1.Height - 46) / ListView1.Items.Count)
    '    lstvProducts.Height = 46 + 23 * (lstvProducts.Items.Count - 1)
    'End Sub

    Private Sub formProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mysql_climsoft_db_v4"

        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT * FROM station"
            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "station")
            ' conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("station").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1

            cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))

        Next

        ds.Clear()
        sql = "SELECT * FROM obselement"
            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "obselement")
            ' conn.Close()

        maxRows = ds.Tables("obselement").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1
            cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("description"))
        Next
    End Sub

    Private Sub lstvProducts_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim prod As String

        prod = cmbstation.Text

        'lstvStations.Clear()
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        sql = "SELECT stationId, stationName FROM station WHERE stationName=""" & prod & """"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        maxRows = (ds.Tables("station").Rows.Count)
        Dim str(2) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("station").Rows(kount).Item("stationId")
            str(1) = ds.Tables("station").Rows(kount).Item("stationName")
            itm = New ListViewItem(str)
            lstvStations.Items.Add(itm)
        Next
    End Sub

    Private Sub cmbElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElement.SelectedIndexChanged
        Dim prod As String

        prod = cmbElement.Text
        ' MsgBox(prod)
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        sql = "SELECT code, description FROM obselement WHERE description=""" & prod & """"
               da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "obselement")

        maxRows = (ds.Tables("obselement").Rows.Count)
        Dim str(2) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("obselement").Rows(kount).Item("code")
            str(1) = ds.Tables("obselement").Rows(kount).Item("description")
            itm = New ListViewItem(str)
            lstvElements.Items.Add(itm)
        Next
    End Sub

    Private Sub chkAdvancedSelection_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvancedSelection.CheckedChanged
        If chkAdvancedSelection.Checked = True Then
            pnlStation.Visible = True
        Else
            pnlStation.Visible = False
        End If

    End Sub

    Private Sub dateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dateFrom.ValueChanged


    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim stnlist, elmlist, sdate, edate, sql, sql1 As String


        ' Get the stations list
        stnlist = ""
        If lstvStations.Items.Count > 0 Then
            stnlist = lstvStations.Items(0).Text
            For i = 1 To lstvStations.Items.Count - 1
                '  MsgBox(lstvStations.Items(i).Text)
                stnlist = stnlist & " OR " & lstvStations.Items(i).Text
            Next
        End If

        ' Get the Elements list
        elmlist = ""
        If lstvElements.Items.Count > 0 Then
            elmlist = "" & lstvElements.Items(0).Text & """"
            For i = 1 To lstvElements.Items.Count - 1
                ' MsgBox(lstvElements.Items(i).Text)
                elmlist = elmlist & " OR describedBy = """ & lstvElements.Items(i).Text & """"
            Next
        End If
        sql = "SELECT recordedFrom, describedBy, obsDatetime, obsValue FROM observationfinal WHERE describedBy=""" & elmlist

        sdate = DateValue(dateFrom.Text) & " " & txtHourStart.Text & ":" & txtMinuteStart.Text
        edate = DateValue(dateTo.Text) & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text
        sql1 = stnlist & " " & elmlist
        'MsgBox(stnlist & "   " & elmlist)
        'MsgBox(sdate)
        'MsgBox(edate)
        WindRose(sql)
    End Sub
    Sub WindRose(sql As String)
        'MsgBox(sql)
     
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "observationfinal")
        maxRows = ds.Tables("observationfinal").Rows.Count
        MsgBox(maxRows)
        MsgBox(ds.Tables("observationfinal").Rows(0).Item("obsValue"))

    End Sub
    Private Sub cmdDelStation_Click(sender As Object, e As EventArgs) Handles cmdDelStation.Click
        For i = 0 To lstvStations.Items.Count - 1
            If lstvStations.Items(i).Selected Then
                'Delete_Selection(lstvStations, i)
                lstvStations.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub chksatation_CheckedChanged(sender As Object, e As EventArgs) Handles chksatation.CheckedChanged
        lstvStations.Clear()
    End Sub

    'Sub Delete_Selection(lstv As ListView, itm As Integer)
    '    lstvStations.Items(itm).Remove()
    'End Sub

    Private Sub cmdDelElement_Click(sender As Object, e As EventArgs) Handles cmdDelElement.Click
        For i = 0 To lstvElements.Items.Count - 1
            If lstvElements.Items(i).Selected Then
                'Delete_Selection(lstvStations, i)
                lstvElements.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub chkelement_CheckedChanged(sender As Object, e As EventArgs) Handles chkelement.CheckedChanged
        lstvElements.Clear()
    End Sub
End Class