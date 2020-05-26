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

Public Class formProductsSelectCriteria
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim maxRows, maxColumns As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim kounts As Integer
    Dim stnlist, elmlist, elmcolmn, sdate, edate, sql As String
    Dim SumAvg, SummaryType As String
    Public CPTstart, CPTend As String
    Dim cmd As MySql.Data.MySqlClient.MySqlCommand
    Dim ItmExist As Boolean

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

        'Set Header for Elements list view
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'Set Header for Stations list view
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)


        MyConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT * FROM station ORDER BY stationName"
            'sql = "SELECT recordedFrom, stationName from observationfinal INNER JOIN station ON recordedFrom = stationId group by recordedFrom  ORDER BY stationName;"

            'sql = "SELECT prCategory FROM tblProducts GROUP BY prCategory"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "station")
            'conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("station").Rows.Count
        'MsgBox(maxRows)
        For kount = 0 To maxRows - 1 Step 1

            cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))

        Next

        ds.Clear()

        sql = "SELECT * FROM obselement where selected = '1' ORDER BY description"
        'sql = "select describedBy, description from observationfinal INNER JOIN obselement on describedBy = elementId group by describedBy  order by description;"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.SelectCommand.CommandTimeout = 0
        da.Fill(ds, "obselement")

        maxRows = ds.Tables("obselement").Rows.Count
        For kount = 0 To maxRows - 1 Step 1
            cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("description"))
        Next

        conn.Close()
    End Sub


    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim prod As String

        prod = cmbstation.Text

        'lstvStations.Clear()
        'lstvStations.Columns.Clear()
        'lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        'lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
        'sql = "SELECT stationId, stationName FROM station WHERE stationName=""" & prod & """"
        sql = "SELECT stationId, stationName FROM station WHERE stationName='" & prod & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        maxRows = (ds.Tables("station").Rows.Count)
        If maxRows > 0 Then cmbstation.BackColor = Color.White

        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("station").Rows(kount).Item("stationId")
                str(1) = ds.Tables("station").Rows(kount).Item("stationName")
                itm = New ListViewItem(str)

                ItmExist = False
                If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvStations.Items.Add(itm)
                Else
                    For j = 0 To lstvStations.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvStations.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvStations.Items.Add(itm)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElement.SelectedIndexChanged
        Dim prod As String
        'On Error GoTo Err
        Try
            prod = cmbElement.Text

            'lstvElements.Columns.Clear()
            'lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            'lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
            'lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

            'sql = "SELECT productName, prDetails FROM tblProducts WHERE prCategory=""" & prod & """"
            'sql = "SELECT elementId, abbreviation, description FROM obselement WHERE description=""" & prod & """"
            sql = "SELECT elementId, abbreviation, description FROM obselement WHERE description='" & prod & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            If maxRows > 0 Then cmbElement.BackColor = Color.White

            Dim str(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("obselement").Rows(kount).Item("elementId")
                str(1) = ds.Tables("obselement").Rows(kount).Item("abbreviation")
                str(2) = ds.Tables("obselement").Rows(kount).Item("description")
                itm = New ListViewItem(str)

                ItmExist = False
                If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvElements.Items.Add(itm)
                Else
                    For j = 0 To lstvElements.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvElements.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvElements.Items.Add(itm)
                End If
            Next


            'lstvElements.Items.Add(itm)
            'Next
        Catch err As Exception
            ' Exit Sub
            'Err:
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub chkAdvancedSelection_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdvancedSelection.CheckedChanged
        If chkAdvancedSelection.Checked = True Then
            pnlStation.Visible = True
        Else
            pnlStation.Visible = False
        End If

    End Sub


    Private Sub cmdExtract_Click(sender As Object, e As EventArgs) Handles cmdExtract.Click
        'MsgBox(Me.lblProductType.Text)


        Dim ProductsPath, xpivot, threshValue As String
        SumAvg = ""
        SummaryType = ""
        xpivot = ""
        Me.Cursor = Cursors.WaitCursor
        ' Define the products application path
        Try

            'MsgBox(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))
            'MsgBox(IO.Path.Combine(Application.CommonAppDataPath, "Climsoft4"))

            ProductsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\"
            'ProductsPath = IO.Path.GetFullPath(Application.StartupPath) & "\data"


            If Not IO.Directory.Exists(ProductsPath) Then
                IO.Directory.CreateDirectory(ProductsPath)
            End If

            If pnlSummary.Enabled And optTotal.Checked Then
                SummaryType = "Sum(obsValue) AS Total"
                SumAvg = "SUM"
            Else
                SummaryType = "Avg(obsValue) AS Mean"
                SumAvg = "AVG"
            End If

            'xpivot = SumAvg
            'For i = 1 To 12
            '    If i = 1 Then xpivot = ""
            '    xpivot = xpivot & "," & SumAvg & "(IF(month(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
            'Next

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
            sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & DateAndTime.Day(dateFrom.Text) & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
            'edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"
            edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & DateAndTime.Day(dateTo.Text) & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"

            ' Contrust a SQL statement for creating a query for the selected data product

            'sql0 = "SELECT recordedFrom as StationId,obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = '67774010' or '100000') AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '2005-01-01 00:00:00' and '2010-12-31 23:00:00') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"
            Select Case Me.lblProductType.Text
                Case "WindRose"
                    'sql = "SELECT recordedFrom as StationID,describedBy as Code, obsDatetime,SUM(IF(describedBy = '111', value, NULL)) AS '111',SUM(IF(describedBy = '112', value, NULL)) AS '112' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                    'WindRoseData(sql)
                    WRPlot(stnlist, sdate, edate)

                Case "Minutes"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) As Month,day(obsDatetime) as Day,hour(obsDatetime) as Hour,minute(obsDatetime) as Minute," & elmcolmn & " FROM (SELECT recordedFrom,stationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                           "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime), hour(obsDatetime), minute(obsDatetime);"

                    DataProducts(sql, lblProductType.Text)

                Case "Hourly"

                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) As Month,day(obsDatetime) as Day,hour(obsDatetime) as Hour," & elmcolmn & " FROM (SELECT recordedFrom, StationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                           "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime), hour(obsDatetime);"

                    'Transpose values when the option is selected
                    If chkTranspose.Checked = True Then
                        xpivot = SumAvg
                        For i = 0 To 23
                            If i = 0 Then xpivot = ""
                            xpivot = xpivot & "," & SumAvg & "(IF(hour(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                        Next

                        sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Year, Month(obsDatetime) As Month, Month(obsDatetime) As Day " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                              "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,Year,Month, Day;"

                    End If


                    DataProducts(sql, lblProductType.Text)

                Case "Daily"
                    sql = "SELECT recordedFrom as StationId,stationName as Station_Name,latitude as Lat, longitude as Lon,elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day," & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, StationName, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime);"

                    'Transpose values when the option is selected
                    If chkTranspose.Checked = True Then
                        xpivot = SumAvg
                        For i = 1 To 31
                            If i = 1 Then xpivot = ""
                            xpivot = xpivot & "," & SumAvg & "(IF(day(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                        Next

                        sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Year, Month(obsDatetime) As Month " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                              "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,Year,Month;"
                    End If

                    'MsgBox(sql)
                    DataProducts(sql, lblProductType.Text)

                'Case "Histograms"
                '    Dim myInterface As New clsRInterface()
                '    myInterface.productHistogramExample()

                Case "Monthly"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation,describedBy, stationName, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                           "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Year, Month;"

                    ' Transpose products if so selected
                    If chkTranspose.Checked = True Then
                        xpivot = SumAvg
                        For i = 1 To 12
                            If i = 1 Then xpivot = ""
                            xpivot = xpivot & "," & SumAvg & "(IF(month(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                        Next

                        sql = "SELECT recordedFrom as StationID, stationName as Station_Name, describedBy as Code, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year" & xpivot & " FROM (SELECT recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                               "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,Year;"
                    End If

                    DataProducts(sql, lblProductType.Text)

                Case "Dekadal"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, " & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude,elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                        "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,DEKAD;"

                    ' Transpose products if so selected
                    'If chkTranspose.Checked = True Then
                    '    xpivot = SumAvg
                    '    For i = 1 To 3
                    '        If i = 1 Then xpivot = ""
                    '        xpivot = xpivot & "," & SumAvg & "(IF(round(Day(obsDatetime) / 10.5 + 0.5, 0)) = '" & i & "', value, NULL)) AS '" & i & "'"
                    '    Next

                    '    sql = "SELECT recordedFrom as StationID, describedBy as Code, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month" & xpivot & " FROM (SELECT recordedFrom, describedBy, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                    '          "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, Year, Month;"
                    'End If

                    DataProducts(sql, lblProductType.Text)

                Case "Pentad"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat,longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/5.5 + 0.5,0) as  PENTAD, " & elmcolmn & " FROM (SELECT recordedFrom,stationName,latitude,longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                        "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,PENTAD;"

                    DataProducts(sql, lblProductType.Text)

                Case "Annual"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year," & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " & _
                         "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' And '" & edate & "') ORDER BY recordedFrom, year(obsDatetime)) t GROUP BY StationId,Year;"

                    DataProducts(sql, lblProductType.Text)

                Case "Means"
                    'sql = "SELECT recordedFrom as StationID, stationName as Station_Name,latitude as Lat, longitude as Lon, elevation as Elev, month(obsDatetime) as Month, " & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    ' "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, Month;"
                    'DataProducts(sql, lblProductType.Text)

                    'Create output file
                    Dim fl As String

                    'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\means.csv"
                    fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\means.csv"
                    'MsgBox(fl)
                    ' Clear any existing data in the output file and close it
                    FileOpen(11, fl, OpenMode.Output)
                    FileClose(11)

                    ' Re-open the file in Append mode
                    FileOpen(11, fl, OpenMode.Append)


                    For i = 0 To lstvElements.Items.Count - 1
                        SumAvg = "AVG"
                        If lstvElements.Items(i).Text = 5 Or lstvElements.Items(i).Text = 18 Then SumAvg = "SUM"

                        sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, describedBy as Code, year(obsDatetime) as Years,month(obsDatetime) as Months, " & SumAvg & "(value) As Value FROM (SELECT recordedFrom, latitude, longitude, elevation,describedBy, stationName, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                          "WHERE  (RecordedFrom = " & stnlist & ") AND (describedBy ='" & lstvElements.Items(i).Text & "') AND (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Years, Months;"
                        'MsgBox(sql)
                        MeansProducts(sql, fl)
                    Next
                    FileClose(11)
                    'CommonModules.ViewFile(fl)
                    MonthlyNormals()

                Case "Extremes"

                    If btnLowHigh.Checked = True Then
                        sql = "SELECT RecordedFrom, describedBy, stationId, stationName, abbreviation, latitude, longitude, elevation, Min(obsValue) AS Min, Max(obsValue) AS Max FROM station INNER JOIN (obselement INNER JOIN observationfinal ON elementId = describedBy) ON stationId = recordedFrom GROUP BY stationName, abbreviation, latitude, longitude, elevation, elementId " & _
                              "HAVING ((RecordedFrom=" & stnlist & ") AND (describedBy=" & elmlist & "));"
                        XtremesWithoutDates(sql)
                    ElseIf btnMaxDate.Checked = True Then
                        XtremesWithDates("MaxValue", "max", sdate, edate)
                    ElseIf btnMinDate.Checked = True Then
                        XtremesWithDates("MinValue", "min", sdate, edate)
                    End If

                Case "GeoCLIM Monthly"
                    GeoCLIMMonthlyProducts(stnlist, sdate, edate)
                Case "Inventory"
                    'sql = "SELECT recordedFrom as StationID, latitude, longitude, elevation,year(obsDatetime),month(obsDatetime),day(obsDatetime),hour(obsDatetime)," & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    '    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                    'sql = "SELECT recordedFrom as StationID, latitude, longitude, elevation,year(obsDatetime),month(obsDatetime),day(obsDatetime),hour(obsDatetime),describedBy FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                    'Set for daily inventory
                    xpivot = SumAvg
                    For i = 1 To 31
                        If i = 1 Then xpivot = ""
                        xpivot = xpivot & "," & SumAvg & "(IF(day(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                    Next

                    sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Year, Month(obsDatetime) As Month " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                          "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,Year,Month;"

                    'MsgBox(sql)

                    InventoryProducts(sql, "Inventory")
                Case "CPT"
                    'Dim myInterface As New clsRInterface()
                    'myInterface.productCDTExample()
                    frmCPTSeason.ShowDialog()

                    If Len(CPTstart) > 0 And Len(CPTend) > 0 Then CPTProducts(CPTstart, CPTend)
                Case "Instat"
                    'sql = "SELECT recordedFrom as StationId,dayofyear(obsdatetime) as YearDay,SUM(IF(year(obsDatetime) ='2000', value, NULL)) AS '2000', SUM(IF(year(obsDatetime) ='2009', value, NULL)) AS '2009' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, YearDay;"
                    'DataProducts(sql, lblProductType.Text)
                    InstatProduct(sdate, edate, lblProductType.Text)
                Case "Missing Data"
                    'RefreshStatsCache()
                    RefreshMissingCache()
                    GatherStats()
                    'findmissing()
                    frmPlotter.Show()

                Case "Rclimdex"
                    RclimdexProducts(sdate, edate, lblProductType.Text)
                Case "TimeSeries"
                    frmCharts.stns = stnlist
                    frmCharts.elmlist = elmlist
                    frmCharts.elmcolmn = elmcolmn
                    frmCharts.sdt = sdate
                    frmCharts.edt = edate
                    frmCharts.SumAvg = SumAvg
                    frmCharts.SummaryType = SummaryType
                    frmCharts.graphType = "TimeSeries"
                    frmCharts.Show()
                    'MSCharts(stnlist, elmlist, elmcolmn, sdate, edate, SumAvg, SummaryType, "TimeSeries")
                Case "Histograms"
                    frmCharts.stns = stnlist
                    frmCharts.elmlist = elmlist
                    frmCharts.elmcolmn = elmcolmn
                    frmCharts.sdt = sdate
                    frmCharts.edt = edate
                    frmCharts.SumAvg = SumAvg
                    frmCharts.SummaryType = SummaryType
                    frmCharts.graphType = "Histograms"
                    frmCharts.Show()
                    'MSCharts(stnlist, elmlist, elmcolmn, sdate, edate, SumAvg, SummaryType, "Histograms")
                Case "CDT Dekadal"
                    sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & "01" & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
                    edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"

                    CDT_Dekadal(sdate, edate)
                Case "CDT Daily"
                    sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & "01" & " " & txtHourStart.Text & ":" & txtMinuteStart.Text & ":00"
                    edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & "31" & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text & ":00"

                    CDT_Daily(sdate, edate)
                Case "Dekadal Counts"
                    threshValue = InputBox("Enter Threshold value in mm", "Threshold amount for Dekadal Rainy Days", "0.03")
                    sql = "select recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as DEKAD, count(round(day(obsDatetime)/10.5 + 0.5,0)) AS Days
                          from station INNER JOIN observationfinal ON stationId = recordedFrom
                          where describedBy= '5'  and obsValue >= " & threshValue & "  and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                          Group by recordedFrom, year(obsDatetime), Month(obsDatetime), round(day(obsDatetime)/10.5 + 0.5,0)
                          Order by recordedFrom, year(obsDatetime), Month(obsDatetime), round(day(obsDatetime)/10.5 + 0.5,0);"

                    DataProducts(sql, lblProductType.Text)
                Case "Monthly Counts"
                    threshValue = InputBox("Enter Threshold value in mm", "Threshold amount for Monthly Rainy Days", "0.03")
                    sql = "select recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, month(obsDatetime) as Month, Count(month(obsDatetime)) as Days
                           from station INNER JOIN observationfinal ON stationId = recordedFrom
                           where describedBy= '5' and obsValue >= " & threshValue & " and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           Group by recordedFrom, year(obsDatetime), month(obsDatetime)
                           Order by recordedFrom, year(obsDatetime), month(obsDatetime);"

                    DataProducts(sql, lblProductType.Text)
                Case "Annual Counts"
                    threshValue = InputBox("Enter Threshold value in mm", "Threshold amount for Annual Rainy Days", "0.03")
                    sql = "select recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, Count(year(obsDatetime)) as Days
                           from station INNER JOIN observationfinal ON stationId = recordedFrom
                           where describedBy= '5' and obsValue >= " & threshValue & "  and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           Group by recordedFrom, year(obsDatetime)
                           Order by recordedFrom, year(obsDatetime);"

                    DataProducts(sql, lblProductType.Text)
                Case Else
                    MsgBox("No Product found for Selection made", MsgBoxStyle.Information)
                    'Me.Cursor = Cursors.Default
                    'Exit Sub
            End Select

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Sub WindRoseData(sql As String)
        On Error GoTo Err
        'MsgBox(sql)
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
    Sub WRPlot(stns As String, sdt As String, edt As String)

        Dim fl, WRpro, wl, WrplotAPP, WrplotAppPath, datval As String
        Dim pro As Integer
        Dim ox As Object
        'Dim WDSP, WDDR As Integer

        Try
            WrplotAppPath = ""
            ' Locate the installation path for the windrose plot application
            If GetWRplotPath(WrplotAppPath) Then
                WrplotAPP = WrplotAppPath & "WRPLOT_View.exe"
            Else
                MsgBox("WRPlot Application not found")
                Exit Sub
            End If

            ' SQL statement for the selecting data for windrose plotting
            'sql = "SELECT recordedFrom as STNID,year(obsDatetime) as YY,month(obsDatetime) as MM,day(obsDatetime) as DD,hour(obsDatetime) as HH,AVG(IF(describedBy = '112', value, NULL)) AS 'DIR',AVG(IF(describedBy = '111', value, NULL)) AS 'WSPD' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stns & ") AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '" & sdt & "' and '" & edt & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY STNID, YY, MM, DD, HH;"
            If MsgBox("Is the wind data from AWS?", vbYesNo, "Wind Data Observation Type") = vbYes Then
                'MsgBox("AWS")
                sql = "SELECT recordedFrom as STNID,year(obsDatetime) as YY,month(obsDatetime) as MM,day(obsDatetime) as DD,hour(obsDatetime) as HH,AVG(IF(describedBy = '895', value, NULL)) AS 'DIR',AVG(IF(describedBy = '897', value, NULL)) AS 'WSPD' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " &
                "WHERE (RecordedFrom = " & stns & ") AND (describedBy = '897' OR describedBy = '895') and (year(obsDatetime) between '" & Year(sdt) & "' and '" & Year(edt) & "') and (month(obsDatetime) between '" & Month(sdt) & "' and '" & Month(edt) & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY STNID, YY, MM, DD, HH;"
            Else
                'MsgBox("Manual")
                sql = "SELECT recordedFrom as STNID,year(obsDatetime) as YY,month(obsDatetime) as MM,day(obsDatetime) as DD,hour(obsDatetime) as HH,AVG(IF(describedBy = '112', value, NULL)) AS 'DIR',AVG(IF(describedBy = '111', value, NULL)) AS 'WSPD' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " &
                "WHERE (RecordedFrom = " & stns & ") AND (describedBy = '111' OR describedBy = '112') and (year(obsDatetime) between '" & Year(sdt) & "' and '" & Year(edt) & "') and (month(obsDatetime) between '" & Month(sdt) & "' and '" & Month(edt) & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY STNID, YY, MM, DD, HH;"
            End If

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count
            If maxRows = 0 Then
                MsgBox("No wind speed and direction data found")
                Exit Sub
            End If

            ' Create output file
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Wrose.txt"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Wrose.txt"

            FileOpen(11, fl, OpenMode.Output)

            ' Output output format description
            Print(11, "LAKES FORMAT")
            PrintLine(11)

            ' Output data values
            For k = 0 To maxRows - 1

                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then

                        datval = ds.Tables("observationfinal").Rows(k).Item(i)

                        ' Round the value to while numbers except the Station ID 
                        If i > 0 Then
                            datval = Math.Round(Val(ds.Tables("observationfinal").Rows(k).Item(i)), 0)
                        End If

                        ' Multiply by factor of 10 where wind direction is in 2 digits
                        If i = ds.Tables("observationfinal").Columns.Count - 2 And Int(RegkeyValue("key05")) = 2 Then
                            datval = Val(datval) * 10
                        End If

                        Print(11, datval & Chr(9))
                    End If
                Next
                PrintLine(11)
            Next
            FileClose(11)

            'WRpro = "C:\Program Files (x86)\Lakes\WRPLOT View\WRPLOT_View.exe " & Chr(34) & "C:\Climsoft Project\Climsoft V4\Climsoft\ClimsoftVer4\ClimsoftVer4\bin\Debug\data\Wrose.txt" & Chr(34)

            WRpro = WrplotAPP & " " & Chr(34) & fl & Chr(34)
            'MsgBox(WRpro)
            Shell(WRpro, AppWinStyle.MaximizedFocus)

        Catch ex As Exception
            'If Err.Number = 5 Then On Error Resume Next
            MsgBox(ex.HResult & " : " & ex.Message)
        End Try
    End Sub
    Sub MSCharts(stns As String, elmlist As String, elmcolmn As String, sdt As String, edt As String, SumAvg As String, SummaryType As String, graphType As String)
        'Dim recmx As Long
        'Dim flds As Integer
        'Dim sql1 As New frmCharts
        ' Daily Summary
        sql = "SELECT recordedFrom as StationId,stationName as Station_Name,latitude as Lat, longitude as Lon,elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day," & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, StationName, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " &
              "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime);"
        'frmCharts.sql = sql

        frmCharts.stns = stns
        frmCharts.elmlist = elmlist
        frmCharts.elmcolmn = elmcolmn
        frmCharts.sdt = sdt
        frmCharts.edt = stns
        frmCharts.SumAvg = SumAvg
        frmCharts.SummaryType = SummaryType
        frmCharts.graphType = graphType
        'Try
        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ds.Clear()
        '    da.Fill(ds, "charts")
        '    recmx = ds.Tables("charts").Rows.Count

        '    'To develop code for determining the data fields
        '    Dim dcl As Integer
        '    Dim hdr, hdrs, dttime As String

        '    hdrs = "StationIdStation_NameLatLonElevYearMonthDEKADDayHourMinute"
        '    dcl = 0

        '    For i = 0 To ds.Tables("charts").Columns.Count - 1
        '        hdr = ds.Tables("charts").Columns.Item(i).ToString

        '        If InStr(hdrs, hdr) = 0 Then
        '            dcl = dcl + 1
        '        End If
        '    Next

        '    ' Define Series
        '    frmCharts.MSChart1.Series.Clear()
        '    flds = ds.Tables("charts").Columns.Count

        '    For i = 1 To dcl
        '        frmCharts.MSChart1.Series.Add(ds.Tables("charts").Columns.Item(flds - i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
        '        'frmCharts.MSChart1.Series(ds.Tables("charts").Columns.Item(flds - i).ToString).Color = Color.DarkBlue
        '    Next

        '    ' Add data to series
        '    For i = 0 To ds.Tables("charts").Rows.Count - 1

        '        ' Compute datetime value for each record
        '        dttime = ""
        '        For j = 0 To ds.Tables("charts").Columns.Count - 1
        '            If ds.Tables("charts").Columns.Item(j).ToString = "Year" Then dttime = ds.Tables("charts").Rows(i).Item(j)

        '            If InStr("MonthDayHourMinute", ds.Tables("charts").Columns.Item(j).ToString) <> 0 Then
        '                dttime = dttime & "/" & ds.Tables("charts").Rows(i).Item(j)
        '            End If
        '        Next

        '        For j = 1 To dcl
        '            frmCharts.MSChart1.Series(ds.Tables("charts").Columns.Item(flds - j).ToString).Points.AddXY(dttime, ds.Tables("charts").Rows(i).Item(flds - j))
        '        Next
        '    Next

        '    frmCharts.MSChart1.ChartAreas("ChartArea1").AxisX.Title = "Time"
        '    frmCharts.MSChart1.ChartAreas("ChartArea1").AxisY.Title = "Values"
        '    frmCharts.MSChart1.Titles.Add("Summary").Alignment = ContentAlignment.TopCenter

        '    frmCharts.Show()
        '    frmCharts.MSChart1.Show()
        '    frmCharts.Refresh()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Sub DataProducts(sql As String, typ As String)

        Dim dap As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsp As New DataSet
        Dim conp As New MySql.Data.MySqlClient.MySqlConnection
        Dim fl As String

        Try
            conp.ConnectionString = MyConnectionString
            conp.Open()
            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conp)
            dap.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            dap.Fill(dsp, "observationfinal")
            conp.Close()
            'MsgBox(dsp.Tables("observationfinal").Columns.Count)

            maxRows = dsp.Tables("observationfinal").Rows.Count
            'MsgBox(maxRows)
            ' Create output file

            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_products.csv"
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Output the column headers
            For j = 0 To dsp.Tables("observationfinal").Columns.Count - 1
                Write(11, dsp.Tables("observationfinal").Columns(j).ColumnName)
            Next

            PrintLine(11)

            ' Output data values
            For k = 0 To maxRows - 1
                For i = 0 To dsp.Tables("observationfinal").Columns.Count - 1
                    FormattedOutput(11, k, i, dsp)
                Next
                PrintLine(11)
            Next

            FileClose(11)
            CommonModules.ViewFile(fl)
            'flds1 = """" & lstvElements.Items(0).Text & """"
            'flds2 = """" & lstvElements.Items(1).Text & """"
            'flds3 = """" & lstvElements.Items(2).Text & """"

        Catch ex As Exception
            MsgBox(ex.Message)
            'If Err.Number = 13 Or Err.Number = 5 Then Resume Next
            MsgBox("No data found. Check and confirm selections")
            FileClose(11)
            conp.Close()
        End Try

    End Sub
    Sub MeansProducts(sql As String, fl As String)
        Dim Kount As Long

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "observationfinal")

            Kount = ds.Tables("observationfinal").Rows.Count

            If FileLen(fl) = 0 Then
                ' Output the column headers
                For j = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    Write(11, ds.Tables("observationfinal").Columns(j).ColumnName)
                Next
                PrintLine(11)
            End If

            ' Output data values
            For k = 0 To Kount - 1
                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    'If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then FormattedOutput(11, k, i)
                    FormattedOutput(11, k, i, ds)
                Next
                PrintLine(11)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub MonthlyNormals()
        'strFolderPath = System.IO.Path.GetDirectoryName(txtQCReportOriginal.Text)
        Dim fld, fl, connString, sql As String
        Dim dss As New DataSet
        Dim daa As OleDb.OleDbDataAdapter
        Dim conn1 As New OleDb.OleDbConnection
        Dim kount As Long

        'fld = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
        fld = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"

        connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fld & ";Extended Properties=Text;"


        Try
            conn1.ConnectionString = connString
            conn1.Open()

            'sql = "SELECT * FROM [" & "means.csv" & "]"
            'sql = "SELECT StationId,Station_Name, Months, AVG(IF(Code = '2', Value, NULL)) AS 'Tmax', AVG(IF(Code ='5', Value, NULL)) AS 'Precip' FROM [" & "means.csv" & "]  GROUP BY StationId, Months;"

            sql = "SELECT StationID,Months,Code,AVG(Value) as MEAN FROM [" & "means.csv" & "] GROUP BY StationId,Months,Code"

            daa = New OleDb.OleDbDataAdapter(sql, conn1)
            dss.Clear()
            daa.Fill(dss, "observationfinal")
            conn1.Close()

            kount = dss.Tables("observationfinal").Rows.Count
            'MsgBox(kount)
            ' Create output file

            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_products.csv"

            FileOpen(101, fl, OpenMode.Output)

            ' Output the column headers
            For j = 0 To dss.Tables("observationfinal").Columns.Count - 1
                Write(101, dss.Tables("observationfinal").Columns(j).ColumnName)
            Next

            PrintLine(101)

            ' Output data values
            For k = 0 To kount - 1
                For i = 0 To dss.Tables("observationfinal").Columns.Count - 1
                    'Write(101, dss.Tables("observationfinal").Rows(k).Item(i))

                    If IsDBNull(dss.Tables("observationfinal").Rows(k).Item(i)) Then
                        Write(101, "")
                    ElseIf InStr(dss.Tables("observationfinal").Rows(k).Item(i), ".") <> 0 Then ' Decimal values to be rounded to 2 decimal places
                        Write(101, Format(dss.Tables("observationfinal").Rows(k).Item(i), "0.00"))
                    Else
                        Write(101, dss.Tables("observationfinal").Rows(k).Item(i))
                    End If

                Next
                PrintLine(101)
            Next

            FileClose(101)
            'CommonModules.ViewFile(fl)
            Normals_Transpose(conn1, daa, dss, connString)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn1.Close()
        End Try
    End Sub
    Sub Normals_Transpose(conn1 As OleDb.OleDbConnection, daa As OleDb.OleDbDataAdapter, dss As DataSet, connString As String)
        Dim fl, hdr As String
        Dim sql, stnId, stnNm, elm, mn, dat As String
        Dim kount, tx As Long

        Try

            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Normals.csv"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Normals.csv"
            FileOpen(102, fl, OpenMode.Output)

            sql = "SELECT StationID,Months,Code,MEAN FROM [" & "data_products.csv" & "] ORDER BY StationId,Months" 'GROUP BY StationId,Code,Months, MEAN"

            conn1.Open()

            daa = New OleDb.OleDbDataAdapter(sql, conn1)
            dss.Clear()
            daa.Fill(dss, "observationfinal")
            conn1.Close()

            kount = dss.Tables("observationfinal").Rows.Count

            'MsgBox(kount)

            tx = lstvElements.Items.Count
            Dim vals(tx) As String

            ' Output Headers
            hdr = "Station_Id,Station_Name,Month"
            For i = 0 To lstvElements.Items.Count - 1
                hdr = hdr & "," & lstvElements.Items(i).SubItems(1).Text
            Next
            PrintLine(102, hdr)

            For i = 0 To lstvStations.Items.Count - 1
                stnId = lstvStations.Items(i).SubItems(0).Text
                stnNm = lstvStations.Items(i).SubItems(1).Text
                For m = 1 To 12
                    ' Initialize Transpose values on every month
                    For j = 0 To tx - 1
                        vals(j) = ""
                    Next

                    ' Get data for every selected element
                    For j = 0 To lstvElements.Items.Count - 1
                        elm = lstvElements.Items(j).SubItems(0).Text
                        With dss.Tables("observationfinal")
                            For k = 0 To kount - 1
                                If .Rows(k).Item(0) = stnId And .Rows(k).Item(1) = m And .Rows(k).Item(2) = elm Then
                                    vals(j) = .Rows(k).Item(3)
                                End If
                            Next k
                        End With
                    Next j
                    dat = ""
                    For j = 0 To tx - 1
                        dat = dat & ", " & vals(j)
                    Next j

                    ' Output Normals into text CSV file
                    PrintLine(102, stnId & "," & stnNm & "," & m & dat)
                Next m
            Next i
            FileClose(102)
            'MsgBox(fl)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            conn1.Close()
        End Try
    End Sub
    Sub GeoCLIMMonthlyProducts(stns As String, sdate As String, edate As String)

        On Error GoTo Err
        Dim sql, codes, abbrev, fl As String
        Dim kount, elems As Integer

        For elems = 0 To lstvElements.Items.Count - 1
            codes = lstvElements.Items(elems).SubItems(0).Text
            abbrev = lstvElements.Items(elems).SubItems(1).Text

            ' Totals for precipitation and Averages for others
            If codes = 5 Then
                sql = "SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " & _
                       "SUM(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', SUM(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', SUM(IF(month(obsDatetime) ='3', value, NULL)) As Mar, SUM(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', SUM(IF(month(obsDatetime) ='5', value, NULL)) As 'May', SUM(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', SUM(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', SUM(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', SUM(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', SUM(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , SUM(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', SUM(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " & _
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " & _
                       "station INNER JOIN observationfinal ON stationId = recordedFrom WHERE (RecordedFrom = " & stns & ") AND (describedBy ='" & codes & "') and (year(obsDatetime) between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID, Year;"
            Else
                sql = "SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " & _
                       "AVG(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', AVG(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', AVG(IF(month(obsDatetime) ='3', value, NULL)) As Mar, AVG(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', AVG(IF(month(obsDatetime) ='5', value, NULL)) As 'May', AVG(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', AVG(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', AVG(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', AVG(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', AVG(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , AVG(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', AVG(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " & _
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " & _
                       "station INNER JOIN observationfinal ON stationId = recordedFrom WHERE (RecordedFrom = " & stns & ") AND (describedBy ='" & codes & "') and (year(obsDatetime) between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID, Year;"

            End If

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

            ds.Clear()
            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count
            ' Create a file for each type of observation element
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\GEOCLM-" & abbrev & ".csv"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\GEOCLM-" & abbrev & ".csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Write the element headers as abbreviation
            For kount = 0 To ds.Tables("observationfinal").Columns.Count - 1
                Write(11, ds.Tables("observationfinal").Columns.Item(kount).ColumnName)
            Next

            PrintLine(11)

            For k = 0 To maxRows - 1

                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    If IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then
                        Write(11, "-999")
                    Else
                        Write(11, Format("{0:0.00}", ds.Tables("observationfinal").Rows(k).Item(i)))
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
        'MsgBox(st & " " & ed)
        On Error GoTo Err
        stnscolmn = ""

        ' ''If pnlSummary.Enabled And optTotal.Checked Then
        ' ''    SummaryType = "Sum(obsValue) AS Total"
        ' ''    SumAvg = "SUM"
        ' ''Else
        ' ''    SummaryType = "Avg(obsValue) AS Mean"
        ' ''    SumAvg = "AVG"
        ' ''End If

        ' Process CPT value for each selected Element
        For k = 0 To lstvElements.Items.Count - 1
            ' Get the stations list
            ' Compute the CPT Summary type depending on the element type
            ' Totals for Prcipitation, Evaporation and Sunshine hourd
            If lstvElements.Items(k).SubItems(0).Text = 5 Or lstvElements.Items(k).SubItems(0).Text = 18 Or lstvElements.Items(k).SubItems(0).Text = 892 Then
                SummaryType = "Sum(obsValue) AS Total"
                SumAvg = "SUM"
            Else ' Avarages for other elements
                SummaryType = "Avg(obsValue) AS Mean"
                SumAvg = "AVG"
            End If

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

            sql = "SELECT year(obsDatetime) as YY," & stnscolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " & _
                "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & lstvElements.Items(k).Text & ") and (year(obsDatetime) between '" & DateAndTime.Year(sdate) & "' And '" & DateAndTime.Year(edate) & "') and (month(obsDatetime) between '" & st & "' And '" & ed & "') ORDER BY year(obsDatetime)) t GROUP BY YY;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count

            'f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\CPT-" & lstvElements.Items(k).SubItems(1).Text & "-" & MonthName(Int(st), True) & "-" & MonthName(Int(ed), True) & ".txt"  'data_products.csv"
            f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\CPT-" & lstvElements.Items(k).SubItems(1).Text & "-" & MonthName(Int(st), True) & "-" & MonthName(Int(ed), True) & ".txt"

            FileOpen(11, f1, OpenMode.Output)

            ' Get station locations 
            sql1 = "SELECT * FROM station"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            dstn.Clear()
            da.Fill(dstn, "station")
            ''MsgBox(1)
            '' Output Station Ids
            'For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
            '    'MsgBox(ds.Tables("observationfinal").Columns(i).ColumnName)
            '    'If ds.Tables("observationfinal").Columns(i).ColumnName = "stationId" Then

            '    '    Print(11, "STN" & Chr(9))
            '    '    Print(11, ds.Tables("observationfinal").Columns(i).ColumnName & Chr(9))
            '    'End If
            '    If i = 0 Then
            '        Print(11, "STN" & Chr(9))
            '    Else
            '        Print(11, ds.Tables("observationfinal").Columns(i).ColumnName & Chr(9))
            '    End If
            'Next
            'PrintLine(11)
            ''MsgBox(2)
            ' Output Latitudes
            'Print(11, "LAT" & Chr(9))
            For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                stn = ds.Tables("observationfinal").Columns(i).ColumnName
                For n = 0 To dstn.Tables("station").Rows.Count - 1
                    If dstn.Tables("station").Rows(n).Item(0) = stn Then

                        For l = 0 To dstn.Tables("station").Columns.Count - 1
                            If dstn.Tables("station").Columns(l).ColumnName = "stationId" Then
                                Print(11, "STN" & Chr(9) & dstn.Tables("station").Rows(n).Item("stationName") & Chr(13) & Chr(10))
                                Print(11, "LAT" & Chr(9) & dstn.Tables("station").Rows(n).Item("latitude") & Chr(13) & Chr(10))
                                Print(11, "LON" & Chr(9) & dstn.Tables("station").Rows(n).Item("longitude") & Chr(13) & Chr(10))
                                'Print(11, dstn.Tables("station").Rows(n).Item(2) & Chr(9))
                                'Print(11, String.Format("{0:0.00}", Val(dstn.Tables("station").Rows(n).Item(2))) & Chr(9))
                                Exit For
                            End If
                        Next
                        Exit For
                    End If
                Next
            Next
            'PrintLine(11)
            ''MsgBox(3)
            '' Output Latitudes
            'Print(11, "LON" & Chr(9))
            'For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
            '    stn = ds.Tables("observationfinal").Columns(i).ColumnName
            '    For n = 0 To dstn.Tables("station").Rows.Count - 1
            '        If dstn.Tables("station").Rows(n).Item(0) = stn Then
            '            Print(11, dstn.Tables("station").Rows(n).Item(3) & Chr(9))
            '            'Print(11, String.Format("{0:0.00}", Val(dstn.Tables("station").Rows(n).Item(3))) & Chr(9))
            '            Exit For
            '        End If
            '    Next
            'Next
            'PrintLine(11)
            ''MsgBox(4)
            For l = 0 To maxRows - 1
                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    ' Write the value in the outputfile with the convenient format e.g. string, integer and decimal with 2 decimal places
                    If IsDBNull(ds.Tables("observationfinal").Rows(l).Item(i)) Then
                        Print(11, "-999.0" & Chr(9))
                    Else
                        If i = 0 Then 'Year has no decimal point
                            Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & Chr(9))
                        Else
                            'Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & Chr(9))
                            Print(11, String.Format("{0:0.00}", Val(ds.Tables("observationfinal").Rows(l).Item(i))) & Chr(9))
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
        Exit Sub
Err:
        MsgBox(Err.Description)
        FileClose(11)
    End Sub
    Sub InstatProduct(dt1 As String, dt2 As String, typ As String)
        On Error GoTo Err
        Dim yrcolmn, sql, abbrev, stns, codes, fl As String
        Dim kount, stn, elems, yr As Integer

        yrcolmn = " AVG(IF(year(obsDatetime) = '" & Int(DateAndTime.Year(dt1)) & "', value, NULL)) AS '" & Int(DateAndTime.Year(dt1)) & "'"

        For i = Int(DateAndTime.Year(dt1)) + 1 To Int(DateAndTime.Year(dt2))
            yrcolmn = yrcolmn & ", " & "AVG(IF(year(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
        Next

        For stn = 0 To lstvStations.Items.Count - 1
            stns = lstvStations.Items(stn).SubItems(0).Text
            For elems = 0 To lstvElements.Items.Count - 1
                codes = lstvElements.Items(elems).SubItems(0).Text
                abbrev = lstvElements.Items(elems).SubItems(1).Text

                sql = "SELECT recordedFrom as StationId,dayofyear(obsdatetime) as YearDay," & yrcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = '" & stns & "') AND (describedBy ='" & codes & "') and (obsDatetime between '" & dt1 & "' and '" & dt2 & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, YearDay;"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

                ds.Clear()
                da.Fill(ds, "observationfinal")

                ' Get the total records
                maxRows = ds.Tables("observationfinal").Rows.Count
                If maxRows = 0 Then
                    MsgBox("No Data Found for " & abbrev & " for " & stns)
                    Exit For
                End If
                ' Create a file for each type of observation element
                'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Instat_" & lstvStations.Items(stn).SubItems(0).Text & "_" & abbrev & ".csv"
                fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Instat_" & lstvStations.Items(stn).SubItems(0).Text & "_" & abbrev & ".csv"

                FileOpen(11, fl, OpenMode.Output)

                ' Write the column names as column headers
                For kount = 2 To ds.Tables("observationfinal").Columns.Count - 1
                    Write(11, "Y" & ds.Tables("observationfinal").Columns.Item(kount).ColumnName)
                Next


                PrintLine(11)

                For k = 0 To maxRows - 1
                    For i = 2 To ds.Tables("observationfinal").Columns.Count - 1
                        If k < 59 Then
                            If IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then ' Missing Data value before 29th Feb
                                Write(11, "-999")
                            Else
                                Write(11, ds.Tables("observationfinal").Rows(k).Item(i)) ' Data value before 29th Feb
                            End If
                        ElseIf k = 59 Then ' 29th Feb
                            'If i > 1 And Val(ds.Tables("observationfinal").Columns.Item(i).ColumnName) Mod 4 > 0 Then ' Non Leap Year
                            If Val(ds.Tables("observationfinal").Columns.Item(i).ColumnName) Mod 4 > 0 Then ' Non Leap Year
                                Write(11, "9988")
                            ElseIf IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then ' Missing Data value 29th Feb of Leap Year
                                Write(11, "-999")
                            Else
                                Write(11, ds.Tables("observationfinal").Rows(k).Item(i)) ' Data value for 29th Feb of Leap Year
                            End If

                        ElseIf k > 59 Then ' Non Leap Year after 29th Feb
                            If Val(ds.Tables("observationfinal").Columns.Item(i).ColumnName) Mod 4 > 0 Then
                                If IsDBNull(ds.Tables("observationfinal").Rows(k - 1).Item(i)) Then ' Missing Data value in Non Leap Year
                                    Write(11, "-999")
                                Else
                                    Write(11, ds.Tables("observationfinal").Rows(k - 1).Item(i)) ' Data value in Non Leap Year after 28th Feb
                                End If
                            Else
                                If IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then ' Missing Data value in Leap Year
                                    Write(11, "-999")
                                Else
                                    Write(11, ds.Tables("observationfinal").Rows(k).Item(i)) ' Data value in Leap Year after 29th Feb
                                End If
                            End If
                        End If
                    Next
                    PrintLine(11)
                Next
                FileClose(11)
                CommonModules.ViewFile(fl)
            Next
        Next


        'Next

        Exit Sub
Err:
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Sub RclimdexProducts(sd As String, ed As String, typ As String)
        Dim f1 As String
        Dim stns As Integer

        For stns = 0 To lstvStations.Items.Count - 1
            sql = "SELECT year(obsDatetime) as YY,month(obsDatetime) as MM,day(obsDatetime) as DD,SUM(IF(describedBy = '5', value, NULL)) AS 'Precip', SUM(IF(describedBy ='2', value, NULL)) AS 'Tmax', SUM(IF(describedBy ='3', value, NULL)) AS 'Tmin' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = '" & lstvStations.Items(stns).SubItems(0).Text & "') AND (describedBy ='5' OR describedBy ='2' OR describedBy ='3') and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY YY,MM,DD;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.Fill(ds, "observationfinal")

            maxRows = ds.Tables("observationfinal").Rows.Count

            'f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & lstvStations.Items(stns).SubItems(0).Text & "_Rclimdex.txt"  'data_products.csv"
            f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & lstvStations.Items(stns).SubItems(0).Text & "_Rclimdex.txt"  'data_products.csv"

            FileOpen(11, f1, OpenMode.Output)


            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "observationfinal")

            For k = 0 To maxRows - 1
                For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                    If IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then
                        Print(11, "-99.9" & Chr(9))
                    Else
                        Print(11, ds.Tables("observationfinal").Rows(k).Item(i) & Chr(9))
                    End If
                Next
                PrintLine(11)
            Next
            FileClose(11)
            CommonModules.ViewFile(f1)
        Next
    End Sub

    Sub XtremesWithoutDates(sql As String)
        On Error GoTo Err
        Dim flds1, flds2, flds3 As String
        Dim fl As String

        'MsgBox(sql)

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count

        ' Create output file
        'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"
        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_products.csv"

        FileOpen(11, fl, OpenMode.Output)

        ' Output the column headers

        Write(11, "Station_Id")
        Write(11, "Station_Name")
        Write(11, "Element")
        Write(11, "Lat")
        Write(11, "Lon")
        Write(11, "Elev")
        Write(11, "Lowest")
        Write(11, "Highest")

        PrintLine(11)

        ' Output data values
        For k = 0 To maxRows - 1
            For i = 2 To ds.Tables("observationfinal").Columns.Count - 1
                If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then FormattedOutput(11, k, i, ds)
                'FormattedOutput(11, k, i)
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
    Sub XtremesWithDates(Xvalue As String, Xtype As String, st As String, ed As String)
        Dim f1 As String
        Dim stns, elms As Integer
        Try

            'f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\Xtremes.csv"  'data_products.csv"
            f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Xtremes.csv"

            FileOpen(11, f1, OpenMode.Output)

            Write(11, "Station_Id")
            Write(11, "Station_Name")
            Write(11, "Element")
            Write(11, "Day")
            Write(11, "Month")
            Write(11, "Year")
            Write(11, Xvalue)
            PrintLine(11)

            For stns = 0 To lstvStations.Items.Count - 1
                For elms = 0 To lstvElements.Items.Count - 1
                    'sql = "select stationname,abbreviation as element,obsdatetime,obsvalue as max_val from station,obselement, observationfinal where stationId=recordedfrom and elementId=describedby and recordedfrom='9136164' and describedby=2 and obsvalue=(select max(obsvalue) from observationfinal where recordedfrom='9136164' and describedby=2);"
                    sql = " select stationId,stationname,abbreviation as element,day(obsdatetime) as Day,month(obsdatetime) as Month,year(obsdatetime) as Year,obsvalue as max_val from station,obselement, observationfinal " & _
                          "where stationId=recordedfrom and elementId=describedby and recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & " and obsvalue=(select " & Xtype & "(obsvalue) from observationfinal where recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & ");"
                    'sql = " select stationname,abbreviation as element,day(obsdatetime) as Day,month(obsdatetime) as Month,year(obsdatetime) as Year,obsvalue as max_val from station,obselement, observationfinal " & _
                    '      "where stationId=recordedfrom and elementId=describedby and recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & " and (year(obsDatetime) between '" & st & "' and '" & ed & "') and obsvalue=(select " & Xtype & "(obsvalue) from observationfinal where recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & ");"

                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                    ds.Clear()
                    da.Fill(ds, "observationfinal")
                    maxRows = ds.Tables("observationfinal").Rows.Count

                    For k = 0 To maxRows - 1
                        For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                            If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then FormattedOutput(11, k, i, ds)
                            'FormattedOutput(11, k, i)
                        Next
                        PrintLine(11)
                    Next
                Next
            Next
            FileClose(11)
            CommonModules.ViewFile(f1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub InventoryProducts(sql As String, typ As String)

        Dim flds1, flds2, flds3 As String
        Dim fl As String

        On Error GoTo Err
        Me.Cursor = Cursors.WaitCursor
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count
        'MsgBox(maxRows)
        'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\inventory-products.csv"
        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-products.csv"

        FileOpen(11, fl, OpenMode.Output)

        ' Write Column Headers
        Write(11, "Station_ID")
        Write(11, "Station_Name")
        Write(11, "Element_Code")
        Write(11, "Lat")
        Write(11, "Lon")
        Write(11, "Elev")

        Write(11, "Year")
        Write(11, "Month")
        'Write(11, "Day")
        'Write(11, "Hour")


        '' Column headers from table field names
        'For j = 0 To lstvElements.Items.Count - 1
        '    Write(11, lstvElements.Items(j).SubItems(1).Text)
        'Next

        ' Daily headers 
        For j = 1 To 31
            Write(11, j)
        Next

        ' End header row
        PrintLine(11)
        With ds.Tables("observationfinal")
            For k = 0 To maxRows - 1

                For i = 0 To .Columns.Count - 1
                    ' Write the row headers befor the Invetory descriptors
                    If i < 8 Then
                        Write(11, .Rows(k).Item(i))
                    Else
                        If InStr(.Rows(k).Item(i), "NULL") <> 0 Then 'Missing observation to be represented as "M"
                            Write(11, "M")
                        Else
                            Write(11, "X")  'Available observations to be represented as "X"
                        End If

                    End If
                Next
                ' New line for another record
                PrintLine(11)
            Next
        End With
        FileClose(11)

        CommonModules.ViewFile(fl)

        flds1 = """" & lstvElements.Items(0).Text & """"
        flds2 = """" & lstvElements.Items(1).Text & """"
        flds3 = """" & lstvElements.Items(2).Text & """"
        Me.Cursor = Cursors.Default
        Exit Sub
Err:
        'MsgBox(Err.Description)
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)
        FileClose(11)
        Me.Cursor = Cursors.WaitCursor
    End Sub

    Sub MonthlyProducts(sql As String, typ As String)

        On Error GoTo Err
        Dim flds1, flds2, flds3 As String
        Dim fl As String
        'MsgBox(sql)
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count
        'MsgBox(maxRows)

        'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"
        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_products.csv"

        FileOpen(11, fl, OpenMode.Output)
        Write(11, "Station")
        Write(11, "Year")
        Write(11, "Month")

        For j = 0 To lstvElements.Items.Count - 1
            Write(11, lstvElements.Items(j).Text)
        Next
        PrintLine(11)

        For k = 0 To maxRows - 1

            For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
                'If i = 1 Then ' Output Datatime data
                '    Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
                '    Write(11, DateAndTime.Month(ds.Tables("observationfinal").Rows(k).Item(i)))
                '    Write(11, ds.Tables("observationfinal").Rows(k).Item(i))
                'End If

            Next
            PrintLine(11)
        Next
        'MsgBox(3)
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
    Sub FormattedOutput(fp As Integer, rw As Long, col As Integer, dsf As DataSet)
        Try

            'If InStr(ds.Tables("observationfinal").Rows(rw).Item(col), "NULL") <> 0 Then 'Missing Values to be represented as blanks
            If IsDBNull(dsf.Tables("observationfinal").Rows(rw).Item(col)) Then
                Write(fp, "")
            ElseIf InStr(dsf.Tables("observationfinal").Rows(rw).Item(col), ".") <> 0 Then ' Decimal values to be rounded to 2 decimal places
                Write(fp, Format(dsf.Tables("observationfinal").Rows(rw).Item(col), "0.00"))
            Else
                Write(fp, dsf.Tables("observationfinal").Rows(rw).Item(col))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub chksatation_CheckedChanged(sender As Object, e As EventArgs)
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

    Private Sub chkelement_CheckedChanged(sender As Object, e As EventArgs)
        lstvElements.Clear()
    End Sub



    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub lblProductType_TextChanged(sender As Object, e As EventArgs) Handles lblProductType.TextChanged

        If lblProductType.Text = "Hourly" Or lblProductType.Text = "Daily" Or lblProductType.Text = "Monthly" Or lblProductType.Text = "Annual" Or lblProductType.Text = "Pentad" Or lblProductType.Text = "Dekadal" Or lblProductType.Text = "Histograms" Or lblProductType.Text = "TimeSeries" Then
            optMean.Enabled = True
            optTotal.Enabled = True
        Else
            optMean.Enabled = False
            optTotal.Enabled = False
        End If

        If lblProductType.Text = "Rclimdex" Or lblProductType.Text = "WindRose" Then
            cmbElement.Enabled = False
        Else
            cmbElement.Enabled = True
        End If

        If lblProductType.Text = "Extremes" Then
            pnlExtremes.Visible = True
            pnlSummary.Visible = False
        Else
            pnlSummary.Visible = True
        End If

        If lblProductType.Text = "Monthly" Or lblProductType.Text = "Daily" Or lblProductType.Text = "Hourly" Then 'Or lblProductType.Text = "Pentad" Or lblProductType.Text = "Dekadal" Then
            chkTranspose.Visible = True
        Else
            chkTranspose.Visible = False
        End If

        If lblProductType.Text = "Dekadal Counts" Or lblProductType.Text = "Monthly Counts" Or lblProductType.Text = "Annual Counts" Then
            Dim str(3) As String
            Dim itm = New ListViewItem

            ' Add Precipitation details in the Elements list view 
            str(0) = "5"
            str(1) = "PRECIP"
            str(2) = "Precipitation daily total"
            itm = New ListViewItem(str)
            lstvElements.Items.Add(itm)

            ' Set the relevant controls appropriately
            cmbElement.Enabled = False
            lstvElements.Enabled = False
            pnlSummary.Visible = False
            cmdDelElement.Enabled = False
            cmdSelectAllElements.Enabled = False
            cmdClearElements.Enabled = False

        End If
    End Sub



    Private Sub prgrbProducts_Click(sender As Object, e As EventArgs) Handles prgrbProducts.Click

    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    ' Missing data plotting modules by Victor

    Public Sub RefreshStatsCache()
        Dim constring As String

        constring = frmLogin.txtusrpwd.Text
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = constring
        conn.Open()
        cmd = New MySql.Data.MySqlClient.MySqlCommand

        Try
            cmd.Connection = conn
            cmd.CommandText = "refresh_stats"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch x As Exception
            MsgBox(x.Message)
            conn.Close()
        End Try

    End Sub

    Public Sub RefreshMissingCache()
        Dim constring As String

        constring = frmLogin.txtusrpwd.Text
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = conString
        conn.Open()
        Try
            cmd = New MySql.Data.MySqlClient.MySqlCommand
            cmd.Connection = conn
            cmd.CommandText = "REFRESH_data"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch x As Exception
            MsgBox(x.Message)
        conn.Close()
        End Try
    End Sub

    Public Sub GatherStats()
        Dim constring As String

        constring = frmLogin.txtusrpwd.Text
        conn = New MySql.Data.MySqlClient.MySqlConnection
        conn.ConnectionString = constring
        conn.Open()


        If lstvStations.Items.Count > 0 And lstvElements.Items.Count > 0 Then
            'MsgBox(lstvStations.Items.Count & " " & lstvElements.Items.Count)
            For i = 0 To lstvStations.Items.Count - 1
                For j = 0 To lstvElements.Items.Count - 1
                    cmd = New MySql.Data.MySqlClient.MySqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "gather_stats"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0
                    cmd.Parameters.AddWithValue("Stn", lstvStations.Items(i).Text)
                    cmd.Parameters.AddWithValue("Elm", lstvElements.Items(j).Text)
                    cmd.Parameters.AddWithValue("Opening_Date", sdate)
                    cmd.Parameters.AddWithValue("Closing_Date", edate)
                    cmd.ExecuteNonQuery()
                Next
            Next
        End If
        conn.Close()
    End Sub

    Private Sub pnlStationsElements_Paint(sender As Object, e As PaintEventArgs) Handles pnlStationsElements.Paint

    End Sub

    Public Sub findmissing()
        Dim fl As String

        If lstvStations.Items.Count > 0 And lstvElements.Items.Count > 0 Then
            For i = 0 To lstvStations.Items.Count - 1
                For j = 0 To lstvElements.Items.Count - 1
                    cmd = New MySql.Data.MySqlClient.MySqlCommand
                    cmd.Connection = conn
                    cmd.CommandText = "missing_data"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0
                    cmd.Parameters.AddWithValue("Stn", lstvStations.Items(i).Text)
                    cmd.Parameters.AddWithValue("ELEM", lstvElements.Items(j).Text)
                    cmd.Parameters.AddWithValue("STARTDATE", sdate)
                    cmd.Parameters.AddWithValue("ENDDATE", edate)
                    cmd.ExecuteNonQuery()
                Next
            Next
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\inventory-products-missing-records.csv"
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-products-missing-records.csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Write Column Headers
            Write(11, "Station")
            Write(11, "Latatitude")
            Write(11, "Longitude")
            Write(11, "Elevation")
            Write(11, "Element")
            Write(11, "Year")
            Write(11, "Month")
            Write(11, "Day")

            PrintLine(11)

            sql = "SELECT stationname Station,Latitude,Longitude,Elevation, elementname Element,YEAR(obs_date) 'Year',  MONTH(obs_date) 'Month',Day(obs_date) 'Day','xx.x' Missing " &
                  "FROM(missing_data, station, obselement) WHERE station.stationId = missing_data.STN_ID AND obselement.elementId=missing_data.ELEM"
            Try
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

                ds.Clear()
                da.Fill(ds, "missing")

                maxRows = ds.Tables("missing").Rows.Count
                maxColumns = ds.Tables("missing").Columns.Count

                For i = 0 To maxRows - 1
                    For j = 0 To maxColumns - 1
                        Write(11, ds.Tables("missing").Rows(i).Item(j))
                    Next
                    PrintLine(11)
                Next

                FileClose(11)

                CommonModules.ViewFile(fl)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub



    Function RegkeyValue(keynm As String) As String
        ' Get the image archiving folder
        Dim dar As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsr As New DataSet
        Dim regmax As Integer

        Try
            sql = "SELECT * FROM regkeys"
            dar = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dar.Fill(dsr, "regkeys")

            regmax = dsr.Tables("regkeys").Rows.Count
            RegkeyValue = vbNull
            ' Check for the value for the selected key
            For i = 0 To regmax - 1
                If dsr.Tables("regkeys").Rows(i).Item("keyName") = keynm Then
                    RegkeyValue = dsr.Tables("regkeys").Rows(i).Item("keyValue")
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            RegkeyValue = vbNull
        End Try
    End Function

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        If lblProductType.Text = "Inventory" Or lblProductType.Text = "Missing Data" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#inventory")
        ElseIf lblProductType.Text = "WindRose" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#windrose")
        ElseIf lblProductType.Text = "CPT" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#cpt")
        ElseIf lblProductType.Text = "Instat" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#instat")
        ElseIf lblProductType.Text = "Rclimdex" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#rclimdex")
        ElseIf lblProductType.Text = "GeoCLIM Monthly" Or lblProductType.Text = "GeoCLIM Dekadal" Or lblProductType.Text = "GeoCLIM Daily" Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#geoclim")
        Else
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#products")
        End If
    End Sub

    Private Sub cmdClearElements_Click(sender As Object, e As EventArgs) Handles cmdClearElements.Click
        lstvElements.Items.Clear()
    End Sub


    Private Sub cmdClearStations_Click(sender As Object, e As EventArgs) Handles cmdClearStations.Click
        lstvStations.Items.Clear()
    End Sub


    Private Sub cmdSelectAllStations_Click(sender As Object, e As EventArgs) Handles cmdSelectAllStations.Click
        Try
            lstvStations.Clear()
            lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
            lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

            sql = "SELECT recordedFrom, stationName FROM observationfinal INNER JOIN station ON stationId = recordedFrom GROUP BY recordedFrom;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "stations")

            maxRows = (ds.Tables("stations").Rows.Count)
            'MsgBox(maxRows)
            Dim strs(2) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("stations").Rows(kount).Item("recordedFrom")
                strs(1) = ds.Tables("stations").Rows(kount).Item("stationName")
                itm = New ListViewItem(strs)
                lstvStations.Items.Add(itm)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectAllElements_Click(sender As Object, e As EventArgs) Handles cmdSelectAllElements.Click
        Try
            'lstvElements.Columns.Clear()
            'lstvElements.Refresh()
            lstvElements.Clear()
            lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

            sql = "SELECT describedBy, elementName,description  FROM observationfinal INNER JOIN obselement ON elementId = describedBy GROUP BY describedBy;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "Elements")

            maxRows = (ds.Tables("Elements").Rows.Count)
            'MsgBox(maxRows)
            Dim strs(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("Elements").Rows(kount).Item("describedBy")
                strs(1) = ds.Tables("Elements").Rows(kount).Item("elementName")
                strs(2) = ds.Tables("Elements").Rows(kount).Item("description")
                itm = New ListViewItem(strs)
                lstvElements.Items.Add(itm)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CDT_Dekadal(st As String, ed As String)
        Dim stnscolmn, f1, stn, lat, lon, elev As String
        Dim dstn As New DataSet

        Try

            For k = 0 To lstvElements.Items.Count - 1
                If lstvElements.Items(k).SubItems(0).Text = 5 Or lstvElements.Items(k).SubItems(0).Text = 18 Or lstvElements.Items(k).SubItems(0).Text = 892 Then
                    SummaryType = "Sum(obsValue) AS Total"
                    SumAvg = "SUM"
                Else ' Avarages for other elements
                    SummaryType = "Avg(obsValue) AS Mean"
                    SumAvg = "AVG"
                End If

                stnlist = ""
                If lstvStations.Items.Count > 0 Then
                    stnscolmn = " " & SumAvg & "(IF(recordedFrom = '" & lstvStations.Items(0).SubItems(0).Text & "', value, NULL)) AS '" & lstvStations.Items(0).SubItems(0).Text & "'"

                    For i = 1 To lstvStations.Items.Count - 1
                        stnscolmn = stnscolmn & ", " & SumAvg & "(IF(recordedFrom = '" & lstvStations.Items(i).SubItems(0).Text & "', value, NULL)) AS '" & lstvStations.Items(i).SubItems(0).Text & "'"
                    Next
                End If

                'f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\CDT_" & lstvElements.Items(k).SubItems(1).Text & "-" & DateAndTime.Year(st) & "-" & DateAndTime.Year(ed) & ".csv"  'data_products.csv"
                f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\CDT_" & lstvElements.Items(k).SubItems(1).Text & "-" & DateAndTime.Year(st) & "-" & DateAndTime.Year(ed) & ".csv"

                FileOpen(11, f1, OpenMode.Output)

                ' Get station locations 
                sql = "SELECT stationId,longitude,latitude,elevation FROM station"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                dstn.Clear()
                da.Fill(dstn, "station")

                'For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                '    stn = ds.Tables("observationfinal").Columns(i).ColumnName
                '    For n = 0 To dstn.Tables("station").Rows.Count - 1
                '        If dstn.Tables("station").Rows(n).Item(0) = stn Then

                ' Print Stations
                stn = "Stations"
                lon = "LON"
                lat = "LAT"
                elev = "ELEV"
                For i = 0 To lstvStations.Items.Count - 1
                    'stn = lstvStations.Items(i).SubItems(0).Text
                    For j = 0 To dstn.Tables("station").Rows.Count - 1
                        If dstn.Tables("station").Rows(j).Item(0) = lstvStations.Items(i).SubItems(0).Text Then
                            stn = stn & "," & dstn.Tables("station").Rows(j).Item(0)

                            ' Stations Longitudes
                            If IsDBNull(dstn.Tables("station").Rows(j).Item(1)) Then
                                lon = lon & "," & "-9999"
                            Else
                                lon = lon & "," & dstn.Tables("station").Rows(j).Item(1)
                            End If
                            ' Stations Latitudes
                            If IsDBNull(dstn.Tables("station").Rows(j).Item(2)) Then
                                lat = lat & "," & "-9999"
                            Else
                                lat = lat & "," & dstn.Tables("station").Rows(j).Item(2)
                            End If
                            ' Stations Elevations

                            If IsDBNull(dstn.Tables("station").Rows(j).Item(3)) Then
                                elev = elev & "," & "-9999"
                            Else
                                elev = elev & "," & dstn.Tables("station").Rows(j).Item(3)
                            End If
                            Exit For
                        End If
                    Next j
                Next i

                PrintLine(11, stn)
                PrintLine(11, lon)
                PrintLine(11, lat)
                PrintLine(11, "DEKADAL\" & elev)


                sql = "SELECT year(obsDatetime) as YY,month(obsDatetime) as MM, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, " & stnscolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " &
                          "WHERE (describedBy = '" & lstvElements.Items(k).SubItems(0).Text & "') and (obsDatetime between '" & st & " ' and '" & ed & "') ORDER BY obsDatetime) t GROUP BY YY, MM,DEKAD;"

                'MsgBox(sql)
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds.Clear()

                da.Fill(ds, "observationfinal")

                maxRows = ds.Tables("observationfinal").Rows.Count

                For l = 0 To maxRows - 1
                    Print(11, ds.Tables("observationfinal").Rows(l).Item(0) & String.Format("{0:00}", ds.Tables("observationfinal").Rows(l).Item(1)) & ds.Tables("observationfinal").Rows(l).Item(2) & ",")
                    For i = 3 To ds.Tables("observationfinal").Columns.Count - 1
                        If IsDBNull(ds.Tables("observationfinal").Rows(l).Item(i)) Then
                            Print(11, "-9999" & ",") 'Chr(9))
                        Else
                            Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & ",") 'Chr(9))
                            'If i = 0 Then 'Year has no decimal point
                            '    Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & Chr(9))
                            'Else

                            '    Print(11, String.Format("{0:0.00}", Val(ds.Tables("observationfinal").Rows(l).Item(i))) & Chr(9))
                            'End If
                        End If

                    Next

                    PrintLine(11)
                Next

                FileClose(11)
                CommonModules.ViewFile(f1)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
        End Try
    End Sub
    Sub CDT_Daily(st As String, ed As String)
        Dim stnscolmn, f1, stn, lat, lon, elev As String
        Dim dstn As New DataSet

        Try

            For k = 0 To lstvElements.Items.Count - 1
                If lstvElements.Items(k).SubItems(0).Text = 5 Or lstvElements.Items(k).SubItems(0).Text = 18 Or lstvElements.Items(k).SubItems(0).Text = 892 Then
                    SummaryType = "Sum(obsValue) AS Total"
                    SumAvg = "SUM"
                Else ' Avarages for other elements
                    SummaryType = "Avg(obsValue) AS Mean"
                    SumAvg = "AVG"
                End If

                stnlist = ""
                If lstvStations.Items.Count > 0 Then
                    stnscolmn = " " & SumAvg & "(IF(recordedFrom = '" & lstvStations.Items(0).SubItems(0).Text & "', value, NULL)) AS '" & lstvStations.Items(0).SubItems(0).Text & "'"

                    For i = 1 To lstvStations.Items.Count - 1
                        stnscolmn = stnscolmn & ", " & SumAvg & "(IF(recordedFrom = '" & lstvStations.Items(i).SubItems(0).Text & "', value, NULL)) AS '" & lstvStations.Items(i).SubItems(0).Text & "'"
                    Next
                End If

                'f1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\CDT_" & lstvElements.Items(k).SubItems(1).Text & "-" & DateAndTime.Year(st) & "-" & DateAndTime.Year(ed) & ".csv"  'data_products.csv"
                f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\CDT_" & lstvElements.Items(k).SubItems(1).Text & "-" & DateAndTime.Year(st) & "-" & DateAndTime.Year(ed) & ".csv"

                FileOpen(11, f1, OpenMode.Output)

                ' Get station locations 
                sql = "SELECT stationId,longitude,latitude,elevation FROM station"

                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                dstn.Clear()
                da.Fill(dstn, "station")

                'For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                '    stn = ds.Tables("observationfinal").Columns(i).ColumnName
                '    For n = 0 To dstn.Tables("station").Rows.Count - 1
                '        If dstn.Tables("station").Rows(n).Item(0) = stn Then

                ' Print Stations
                stn = "Stations"
                lon = "LON"
                lat = "LAT"
                elev = "ELEV"
                For i = 0 To lstvStations.Items.Count - 1
                    'stn = lstvStations.Items(i).SubItems(0).Text
                    For j = 0 To dstn.Tables("station").Rows.Count - 1
                        If dstn.Tables("station").Rows(j).Item(0) = lstvStations.Items(i).SubItems(0).Text Then
                            stn = stn & "," & dstn.Tables("station").Rows(j).Item(0)

                            ' Stations Longitudes
                            If IsDBNull(dstn.Tables("station").Rows(j).Item(1)) Then
                                lon = lon & "," & "-9999"
                            Else
                                lon = lon & "," & dstn.Tables("station").Rows(j).Item(1)
                            End If
                            ' Stations Latitudes
                            If IsDBNull(dstn.Tables("station").Rows(j).Item(2)) Then
                                lat = lat & "," & "-9999"
                            Else
                                lat = lat & "," & dstn.Tables("station").Rows(j).Item(2)
                            End If
                            ' Stations Elevations

                            If IsDBNull(dstn.Tables("station").Rows(j).Item(3)) Then
                                elev = elev & "," & "-9999"
                            Else
                                elev = elev & "," & dstn.Tables("station").Rows(j).Item(3)
                            End If
                            Exit For
                        End If
                    Next j
                Next i

                PrintLine(11, stn)
                PrintLine(11, lon)
                PrintLine(11, lat)
                PrintLine(11, "DAY\" & elev)


                sql = "SELECT year(obsDatetime) as YY,month(obsDatetime) as MM, day(obsDatetime) as  DD, " & stnscolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " &
                          "WHERE (describedBy = '" & lstvElements.Items(k).SubItems(0).Text & "') and (obsDatetime between '" & st & " ' and '" & ed & "') ORDER BY obsDatetime) t GROUP BY YY, MM,DD;"

                'MsgBox(sql)
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds.Clear()

                da.Fill(ds, "observationfinal")

                maxRows = ds.Tables("observationfinal").Rows.Count

                For l = 0 To maxRows - 1
                    Print(11, ds.Tables("observationfinal").Rows(l).Item(0) & String.Format("{0:00}", ds.Tables("observationfinal").Rows(l).Item(1)) & String.Format("{0:00}", ds.Tables("observationfinal").Rows(l).Item(2)) & ",")
                    For i = 3 To ds.Tables("observationfinal").Columns.Count - 1
                        If IsDBNull(ds.Tables("observationfinal").Rows(l).Item(i)) Then
                            Print(11, "-9999" & ",") 'Chr(9))
                        Else
                            Print(11, ds.Tables("observationfinal").Rows(l).Item(i) & ",") 'Chr(9))
                        End If

                    Next

                    PrintLine(11)
                Next

                FileClose(11)
                CommonModules.ViewFile(f1)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
        End Try
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then add_Station(cmbstation.Text)

    End Sub
    Sub add_Station(id As String)
        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            sql = "SELECT stationId, stationName FROM station WHERE stationId= '" & id & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "station")

            maxRows = (ds.Tables("station").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbstation.Text = ""
                cmbstation.BackColor = Color.White
            Else
                cmbstation.BackColor = Color.Red
                Exit Sub
            End If

            str(0) = ds.Tables("station").Rows(0).Item("stationId")
            str(1) = ds.Tables("station").Rows(0).Item("stationName")

                itm = New ListViewItem(str)

                ItmExist = False
                If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvStations.Items.Add(itm)
                Else
                    For j = 0 To lstvStations.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvStations.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvStations.Items.Add(itm)
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmbElement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbElement.KeyPress
        If Asc(e.KeyChar) = 13 Then add_Element(cmbElement.Text)

    End Sub

    Sub add_Element(id As String)
        Dim str(3) As String
        Dim itm = New ListViewItem

        Try

            'sql = "SELECT SELECT elementId, abbreviation, description FROM obselement WHERE elementId = '" & id & "';"
            sql = "SELECT elementId, abbreviation, description FROM obselement WHERE selected = '1' and elementId = '" & id & "';"

            'sql = "SELECT elementId, abbreviation, description FROM obselement WHERE selected ='1' and description=""" & prod & """"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbElement.Text = ""
                cmbElement.BackColor = Color.White
            Else
                cmbElement.BackColor = Color.Red
                Exit Sub
            End If

            'For kount = 0 To maxRows - 1 Step 1

            str(0) = ds.Tables("obselement").Rows(0).Item("elementId")
            str(1) = ds.Tables("obselement").Rows(0).Item("abbreviation")
            str(2) = ds.Tables("obselement").Rows(0).Item("description")

            itm = New ListViewItem(str)

            ItmExist = False
            If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
                lstvElements.Items.Add(itm)
            Else
                For j = 0 To lstvElements.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstvElements.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                If Not ItmExist Then lstvElements.Items.Add(itm)
            End If
            'Next
        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class
