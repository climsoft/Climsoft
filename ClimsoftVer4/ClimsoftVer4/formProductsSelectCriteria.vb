' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
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

Public Class formProductsSelectCriteria
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim maxRows As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Dim stnlist, elmlist, elmcolmn, sdate, edate, sql As String
    Dim SumAvg, SummaryType As String
    Public CPTstart, CPTend As String

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
        'MyConnectionString = "server=127.0.0.1; uid=root; pwd=admin; database=mariadb_climsoft_db_v4"
        MyConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT * FROM station ORDER BY stationName"
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
        sql = "SELECT * FROM obselement ORDER BY description"
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
        On Error GoTo Err
        prod = cmbElement.Text
        ' MsgBox(prod)
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        sql = "SELECT elementId, abbreviation, description FROM obselement WHERE description=""" & prod & """"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "obselement")

        maxRows = (ds.Tables("obselement").Rows.Count)
        Dim str(3) As String
        Dim itm = New ListViewItem

        For kount = 0 To maxRows - 1 Step 1
            str(0) = ds.Tables("obselement").Rows(kount).Item("elementId")
            str(1) = ds.Tables("obselement").Rows(kount).Item("abbreviation")
            str(2) = ds.Tables("obselement").Rows(kount).Item("description")
            itm = New ListViewItem(str)
            lstvElements.Items.Add(itm)
        Next
        Exit Sub
Err:
        MsgBox(Err.Description)
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

        'Dim SumAvg, SummaryType As String
        'Dim flds As Integer
        'MsgBox(lblProductType.Text)


        If pnlSummary.Enabled And optTotal.Checked Then
            SummaryType = "Sum(obsValue) AS Total"
            SumAvg = "SUM"
        Else
            SummaryType = "Avg(obsValue) AS Mean"
            SumAvg = "AVG"
        End If

        ' Get the stations list
        stnlist = ""
        If lstvStations.Items.Count > 0 Then
            stnlist = "'" & lstvStations.Items(0).Text & "'"
            For i = 1 To lstvStations.Items.Count - 1
                '  MsgBox(lstvStations.Items(i).Text)
                stnlist = stnlist & " OR RecordedFrom = " & "'" & lstvStations.Items(i).Text & "'"
            Next
        End If

        ' Get the Element list
        elmlist = ""
        elmcolmn = ""


        If lstvElements.Items.Count > 0 Then
            elmlist = "'" & lstvElements.Items(0).Text & "'" '""""
            'elmcolmn = " " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(0).Text & "', value, NULL)) AS '" & lstvElements.Items(0).Text & "'"
            elmcolmn = " " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(0).Text & "', value, NULL)) AS '" & lstvElements.Items(0).SubItems(1).Text & "'"

            'elmcolmn = " AVG(IF(describedBy = '" & lstvElements.Items(0).Text & "', value, NULL)) AS '" & lstvElements.Items(0).Text & "'"

            For i = 1 To lstvElements.Items.Count - 1
                ' MsgBox(lstvElements.Items(i).Text)
                elmlist = elmlist & " OR  describedBy = " & "'" & lstvElements.Items(i).Text & "'"  ' """ & lstvElements.Items(i).Text & """"
                'elmcolmn = elmcolmn & ", AVG(IF(describedBy = '" & lstvElements.Items(i).Text & "', value, NULL)) AS '" & lstvElements.Items(i).Text & "'"
                elmcolmn = elmcolmn & ", " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(i).Text & "', value, NULL)) AS '" & lstvElements.Items(i).SubItems(1).Text & "'"
            Next
        End If

        'MsgBox(elmlist)
        'Exit Sub
        sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & "01" & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
        edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"


        ' Contrust a SQL statement for creating a query for the selected data product

        'sql0 = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationId,obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = '67774010' or '100000') AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '2005-01-01 00:00:00' and '2010-12-31 23:00:00') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
        Select Case Me.lblProductType.Text
            Case "WindRose"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID,describedBy as Code, obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
                WindRoseData(sql)
            Case "Hourly"
   
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) As Month,day(obsDatetime) as Day,hour(obsDatetime) as Hour," & elmcolmn & " FROM (SELECT recordedFrom,latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                       "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                DataProducts(sql, lblProductType.Text)

            Case "Daily"
                     sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationId,latitude as Lat, longitude as Lon,elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day," & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                      "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                DataProducts(sql, lblProductType.Text)

            Case "Histograms"
                Dim myInterface As New clsRInterface()
                myInterface.productHistogramExample()

            Case "Monthly"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation,describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                       "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Year, Month;"
                DataProducts(sql, lblProductType.Text)

            Case "Dekadal"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, " & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude,elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,DEKAD;"
                DataProducts(sql, lblProductType.Text)

            Case "Pentad"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat,longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/5.5 + 0.5,0) as  PENTAD, " & elmcolmn & " FROM (SELECT recordedFrom,latitude,longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,PENTAD;"
                DataProducts(sql, lblProductType.Text)

            Case "Annual"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                     "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' And '" & edate & "') ORDER BY recordedFrom, year(obsDatetime)) t GROUP BY StationId,Year;"
                DataProducts(sql, lblProductType.Text)

            Case "Means"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev, month(obsDatetime) as Month, " & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                 "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, Month;"
                DataProducts(sql, lblProductType.Text)

            Case "Extremes"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude as Lat, longitude as Lon, elevation as Elev, describedBy as Code, min(obsValue) AS Lowest, Max(obsValue) AS Highest FROM station INNER JOIN observationfinal ON stationId = recordedFrom GROUP BY recordedFrom, describedBy " & _
                      "HAVING ((recordedFrom= " & stnlist & ") AND (describedBy=" & elmlist & "));"
                DataProducts(sql, lblProductType.Text)

            Case "GeoCLIM"
                GeoCLIMProducts(stnlist, sdate, edate)
            Case "Inventory"
                sql = "use mariadb_climsoft_db_v4; SELECT recordedFrom as StationID, latitude, longitude, elevation,year(obsDatetime),month(obsDatetime),day(obsDatetime),hour(obsDatetime)," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
                InventoryProducts(sql, "Inventory")
            Case "CPT"
                'Dim myInterface As New clsRInterface()
                'myInterface.productCDTExample()
                frmCPTSeason.ShowDialog()

                If Len(CPTstart) > 0 And Len(CPTend) > 0 Then CPTProducts(CPTstart, CPTend)

            Case Else
                MsgBox("No Product Selected")
                Exit Sub
        End Select


    End Sub
    Sub WindRoseData(sql As String)
        On Error GoTo Err

        Dim clmnstr As String


        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")
        maxRows = ds.Tables("observationfinal").Rows.Count

        MsgBox("Data For Wind Rose Plot; Records Extracted= " & maxRows)

        ' Contruct coulumn headers
        clmnstr = ""

        With ds.Tables("observationfinal") ' First 5 rows
            For i = 0 To 5
                MsgBox(.Rows(i).Item("StationId") & " " & .Rows(i).Item("obsDatetime") & " " & .Rows(i).Item("111") & " " & .Rows(i).Item("112"))
            Next
        End With
        formWindRose.Show()
        Exit Sub
Err:
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Sub DataProducts(sql As String, typ As String)
        On Error GoTo Err
        Dim flds1, flds2, flds3 As String
        Dim fl As String

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count

        ' Create output file
        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

        FileOpen(11, fl, OpenMode.Output)

        ' Output the column headers
        For j = 0 To ds.Tables("observationfinal").Columns.Count - 1
            Write(11, ds.Tables("observationfinal").Columns(j).ColumnName)

        Next

        PrintLine(11)

        ' Output data values
        For k = 0 To maxRows - 1
            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                FormattedOutput(11, k, i)
            Next
            PrintLine(11)
        Next
        FileClose(11)
        CommonModules.ViewFile(fl)
        flds1 = """" & lstvElements.Items(0).Text & """"
        flds2 = """" & lstvElements.Items(1).Text & """"
        flds3 = """" & lstvElements.Items(2).Text & """"

        Exit Sub
Err:
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub
    '    Sub SummaryProducts(sql As String, typ As String)
    '        On Error GoTo Err
    '        Dim flds1, flds2, flds3 As String
    '        Dim fl As String

    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        ds.Clear()
    '        da.Fill(ds, "observationfinal")

    '        maxRows = ds.Tables("observationfinal").Rows.Count

    '        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

    '        FileOpen(11, fl, OpenMode.Output)

    '        ' Write Column Headers
    '        Write(11, "Station")
    '        Write(11, "Lat")
    '        Write(11, "Lon")
    '        Write(11, "Elev")
    '        Select Case typ
    '            Case "Hourly"
    '                Write(11, "Year")
    '                Write(11, "Month")
    '                Write(11, "Day")
    '                Write(11, "Hour")
    '            Case "Daily"
    '                Write(11, "Year")
    '                Write(11, "Month")
    '                Write(11, "Day")
    '            Case "Monthly"
    '                Write(11, "Year")
    '                Write(11, "Month")
    '            Case "Annual"
    '                Write(11, "Year")
    '            Case "Dekadal"
    '                Write(11, "Year")
    '                Write(11, "Month")
    '                Write(11, "Dekad")
    '            Case "Pentad"
    '                Write(11, "Year")
    '                Write(11, "Month")
    '                Write(11, "Pentad")
    '            Case "Means"
    '                Write(11, "Month")
    '            Case "Extremes"
    '                Write(11, "Code")
    '                Write(11, "Lowest")
    '                Write(11, "Highest")

    '        End Select

    '        ' Column headers from table field names
    '        For j = 0 To lstvElements.Items.Count - 1
    '            If typ <> "Extremes" Then Write(11, lstvElements.Items(j).SubItems(1).Text)
    '            'Write(11, lstvElements.Items(j).Text)


    '        Next

    '        ' End header row
    '        PrintLine(11)

    '        For k = 0 To maxRows - 1

    '            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
    '                ' Write the value in the outputfile with the convenient format e.g. string, integer and decimal with 2 decimal places
    '                FormattedOutput(11, k, i)
    '            Next
    '            ' New line for another record
    '            PrintLine(11)
    '        Next

    '        FileClose(11)

    '        CommonModules.ViewFile(fl)

    '        flds1 = """" & lstvElements.Items(0).Text & """"
    '        flds2 = """" & lstvElements.Items(1).Text & """"
    '        flds3 = """" & lstvElements.Items(2).Text & """"

    '        Exit Sub
    'Err:
    '        'MsgBox(Err.Description)
    '        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
    '        MsgBox(Err.Number & " " & Err.Description)

    'End Sub

    '    Sub MonthlyProducts(sql As String, typ As String)
    '        On Error GoTo Err
    '        Dim flds1, flds2, flds3 As String
    '        Dim fl As String
    '        'MsgBox(sql)
    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

    '        ds.Clear()
    '        da.Fill(ds, "observationfinal")

    '        maxRows = ds.Tables("observationfinal").Rows.Count
    '        'MsgBox(maxRows)

    '        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

    '        FileOpen(11, fl, OpenMode.Output)
    '        Write(11, "Station")
    '        Write(11, "Year")
    '        Write(11, "Month")

    '        For j = 0 To lstvElements.Items.Count - 1
    '            'Write(11, lstvElements.Items(j).Text)
    '            Write(11, lstvElements.Items(j).SubItems(1).Text)
    '        Next
    '        PrintLine(11)

    '        For k = 0 To maxRows - 1

    '            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
    '                Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
    '                'If i = 1 Then ' Output Datatime data
    '                '    Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
    '                '    Write(11, DateAndTime.Month(ds.Tables("observationfinal").Rows(k).Item(i)))
    '                '    Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
    '                'End If

    '            Next
    '            PrintLine(11)
    '        Next
    '        MsgBox(3)
    '        FileClose(11)
    '        CommonModules.ViewFile(fl)
    '        flds1 = """" & lstvElements.Items(0).Text & """"
    '        flds2 = """" & lstvElements.Items(1).Text & """"
    '        flds3 = """" & lstvElements.Items(2).Text & """"

    '        Exit Sub
    'Err:
    '        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
    '        MsgBox(Err.Number & " " & Err.Description)

    '    End Sub

    Sub GeoCLIMProducts(stns As String, sdate As String, edate As String)

        On Error GoTo Err
        Dim sql, codes, abbrev, fl As String
        Dim kount, elems As Integer

        For elems = 0 To lstvElements.Items.Count - 1
            codes = lstvElements.Items(elems).SubItems(0).Text
            abbrev = lstvElements.Items(elems).SubItems(1).Text

            ' Totals for precipitation and Averages for others
            If codes = 5 Then
                sql = "use mariadb_climsoft_db_v4; SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " & _
                       "SUM(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', SUM(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', SUM(IF(month(obsDatetime) ='3', value, NULL)) As Mar, SUM(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', SUM(IF(month(obsDatetime) ='5', value, NULL)) As 'May', SUM(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', SUM(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', SUM(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', SUM(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', SUM(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , SUM(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', SUM(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " & _
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " & _
                       "station INNER JOIN observationfinal ON stationId = recordedFrom WHERE (RecordedFrom = " & stns & ") AND (describedBy ='" & codes & "') and (year(obsDatetime) between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID, Year;"
            Else
                sql = "use mariadb_climsoft_db_v4; SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " & _
                       "AVG(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', AVG(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', AVG(IF(month(obsDatetime) ='3', value, NULL)) As Mar, AVG(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', AVG(IF(month(obsDatetime) ='5', value, NULL)) As 'May', AVG(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', AVG(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', AVG(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', AVG(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', AVG(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , AVG(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', AVG(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " & _
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " & _
                       "station INNER JOIN observationfinal ON stationId = recordedFrom WHERE (RecordedFrom = " & stns & ") AND (describedBy ='" & codes & "') and (year(obsDatetime) between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID, Year;"

            End If

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

            ds.Clear()
            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count
            ' Create a file for each type of observation element
            fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & abbrev & ".csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Write the lement headers as abbreviation
            For kount = 0 To ds.Tables("observationfinal").Columns.Count - 1
                Write(11, ds.Tables("observationfinal").Columns.Item(kount).ColumnName)
            Next

            PrintLine(11)

            For k = 0 To maxRows - 1

                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    If IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then
                        Write(11, "-999")
                    Else
                        Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
                    End If
                Next
                PrintLine(11)
            Next

            FileClose(11)
            CommonModules.ViewFile(fl)
        Next

        Exit Sub
Err:
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Sub CPTProducts(st As String, ed As String)
        Dim stnscolmn, f1, sql1, stn As String
        Dim dstn As New DataSet
        'frmCPTSeason.Hide()


        If pnlSummary.Enabled And optTotal.Checked Then
            SummaryType = "Sum(obsValue) AS Total"
            SumAvg = "SUM"
        Else
            SummaryType = "Avg(obsValue) AS Mean"
            SumAvg = "AVG"
        End If

        ' Process CPT value for each selected Element
        For k = 0 To lstvElements.Items.Count - 1
            ' Get the stations list
            stnlist = ""
            If lstvStations.Items.Count > 0 Then
                stnlist = "'" & lstvStations.Items(0).Text & "'"
                stnscolmn = " " & SumAvg & "(IF(RecordedFrom = '" & lstvStations.Items(0).Text & "', value, NULL)) AS '" & lstvStations.Items(0).Text & "'"
                For i = 1 To lstvStations.Items.Count - 1
                    '  MsgBox(lstvStations.Items(i).Text)
                    stnlist = stnlist & " OR RecordedFrom = " & "'" & lstvStations.Items(i).Text & "'"
                    stnscolmn = stnscolmn & ", " & SumAvg & "(IF(RecordedFrom = '" & lstvStations.Items(i).Text & "', value, NULL)) AS '" & lstvStations.Items(i).Text & "'"
                Next
            End If

            ' Get start date and end date

            sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & "01" & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
            edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"

            sql = "use mariadb_climsoft_db_v4; SELECT year(obsDatetime) as YY," & stnscolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " & _
                "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & lstvElements.Items(k).Text & ") and (year(obsDatetime) between '" & DateAndTime.Year(sdate) & "' And '" & DateAndTime.Year(edate) & "') and (month(obsDatetime) between '" & st & "' And '" & ed & "') ORDER BY year(obsDatetime)) t GROUP BY YY;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count

            f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & "CPT-" & lstvElements.Items(k).SubItems(1).Text & "-" & MonthName(Int(st), True) & "-" & MonthName(Int(ed), True) & ".txt"  'data_products.csv"

            FileOpen(11, f1, OpenMode.Output)

            ' Get station locations 
            sql1 = "SELECT * FROM station"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            dstn.Clear()
            da.Fill(dstn, "station")

            'MsgBox(dstn.Tables("station").Columns(0).ColumnName & " " & dstn.Tables("station").Columns(1).ColumnName & " " & dstn.Tables("station").Columns(2).ColumnName)

            ' Output Station Ids
            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                If i = 0 Then
                    'Write(11, "STN")
                    Print(11, "STN" & Chr(9))
                Else
                    'Write(11, ds.Tables("observationfinal").Columns(i).ColumnName)
                    Print(11, ds.Tables("observationfinal").Columns(i).ColumnName & Chr(9))
                End If
            Next
            PrintLine(11)

            ' Output Latitudes
            'Write(11, "LAT")
            Print(11, "LAT" & Chr(9))
            For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                stn = ds.Tables("observationfinal").Columns(i).ColumnName
                For n = 0 To dstn.Tables("station").Rows.Count - 1
                    If dstn.Tables("station").Rows(n).Item(0) = stn Then
                        'Write(11, dstn.Tables("station").Rows(n).Item(2))
                        Print(11, String.Format("{0:0.00}", Val(dstn.Tables("station").Rows(n).Item(2))) & Chr(9))
                        Exit For
                    End If
                Next
            Next
            PrintLine(11)

            ' Output Latitudes
            'Write(11, "LON")
            Print(11, "LON" & Chr(9))
            For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                stn = ds.Tables("observationfinal").Columns(i).ColumnName
                For n = 0 To dstn.Tables("station").Rows.Count - 1
                    If dstn.Tables("station").Rows(n).Item(0) = stn Then
                        'MsgBox(stn & " " & dstn.Tables("station").Rows(n).Item(2))
                        'Write(11, dstn.Tables("station").Rows(n).Item(3))
                        Print(11, String.Format("{0:0.00}", Val(dstn.Tables("station").Rows(n).Item(3))) & Chr(9))
                        Exit For
                    End If
                Next
            Next
            PrintLine(11)

            For l = 0 To maxRows - 1

                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    ' Write the value in the outputfile with the convenient format e.g. string, integer and decimal with 2 decimal places
                    'Write(11, ds.Tables("observationfinal").Rows(l).Item(i))
                    If IsDBNull(ds.Tables("observationfinal").Rows(l).Item(i)) Then
                        Print(11, "-999.0" & Chr(9))
                    Else
                        If i = 0 Then 'Year has no decimal point
                            Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & Chr(9))
                        Else
                            Print(11, String.Format("{0:0.0}", Val(ds.Tables("observationfinal").Rows(l).Item(i))) & Chr(9))
                        End If
                    End If

                Next
                ' New line for another record
                PrintLine(11)
            Next


            FileClose(11)
            CommonModules.ViewFile(f1)
            'MsgBox(st & " " & ed)
        Next

    End Sub
    Sub InventoryProducts(sql As String, typ As String)
        On Error GoTo Err
        Dim flds1, flds2, flds3 As String
        Dim fl As String

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count

        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

        FileOpen(11, fl, OpenMode.Output)

        ' Write Column Headers
        Write(11, "Station")
        Write(11, "Lat")
        Write(11, "Lon")
        Write(11, "Elev")

        Write(11, "Year")
        Write(11, "Month")
        Write(11, "Day")
        Write(11, "Hour")


        ' Column headers from table field names
        For j = 0 To lstvElements.Items.Count - 1
            Write(11, lstvElements.Items(j).SubItems(1).Text)
        Next

        ' End header row
        PrintLine(11)

        For k = 0 To maxRows - 1

            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                ' Write the row headers befor the Invetory descriptors
                If i < 8 Then
                    Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
                Else
                    If InStr(ds.Tables("observationfinal").Rows(k).Item(i), "NULL") <> 0 Then 'Missing Values to represented as blanks
                        Write(11, "")
                    Else
                        Write(11, "X")
                    End If

                End If



            Next
            ' New line for another record
            PrintLine(11)
        Next

        FileClose(11)

        CommonModules.ViewFile(fl)

        flds1 = """" & lstvElements.Items(0).Text & """"
        flds2 = """" & lstvElements.Items(1).Text & """"
        flds3 = """" & lstvElements.Items(2).Text & """"

        Exit Sub
Err:
        'MsgBox(Err.Description)
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub


    Sub FormattedOutput(fp As Integer, rw As Long, col As Integer)

        If InStr(ds.Tables("observationfinal").Rows(rw).Item(col), "NULL") <> 0 Then 'Missing Values to represented as blanks
            Write(fp, "")
        ElseIf InStr(ds.Tables("observationfinal").Rows(rw).Item(col), ".") <> 0 Then ' Decimal values to be rounded to 2 decimal places
            Write(fp, Format(ds.Tables("observationfinal").Rows(rw).Item(col), "0.00"))
        Else
            Write(fp, ds.Tables("observationfinal").Rows(rw).Item(col))
        End If
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



    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub lblProductType_TextChanged(sender As Object, e As EventArgs) Handles lblProductType.TextChanged

        If lblProductType.Text = "Monthly" Or lblProductType.Text = "Annual" Or lblProductType.Text = "Pentad" Or lblProductType.Text = "Dekadal" Or lblProductType.Text = "CPT" Then
            optMean.Enabled = True
            optTotal.Enabled = True
        Else
            optMean.Enabled = False
            optTotal.Enabled = False
        End If

    End Sub


    Private Sub lblProductType_Click(sender As Object, e As EventArgs) Handles lblProductType.Click

    End Sub
End Class