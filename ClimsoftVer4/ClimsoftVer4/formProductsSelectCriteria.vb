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
    Dim kounts, code As Integer
    Dim stnlist, elmlist, levlist, elmcolmn, sdate, edate, sql, abbrev, WrunCode As String
    Dim SumAvg, SummaryType As String
    Public CPTstart, CPTend As String
    Dim cmd As MySql.Data.MySqlClient.MySqlCommand
    Dim ItmExist As Boolean

    Private Sub formProducts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Set Header for Stations list view
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'Set Header for Elements list view
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
        If lblProductType.Text = "Daily Levels" Or lblProductType.Text = "Monthly Levels" Or lblProductType.Text = "Annual Levels" Then
            sql = "select * from obsElement where elementId between 301 and 311 order by description;"
        End If
        'sql = "select describedBy, description from observationfinal INNER JOIN obselement on describedBy = elementId group by describedBy  order by description;"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.SelectCommand.CommandTimeout = 0
        da.Fill(ds, "obselement")
        conn.Close()

        maxRows = ds.Tables("obselement").Rows.Count
        For kount = 0 To maxRows - 1 Step 1
            cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("description"))
        Next

        ' When only one station is to be selected
        If lblProductType.Text = "Yearly Elements Observed" Then cmdSelectAllStations.Enabled = False

        ' Get the total number of monthly missing days allowed in computing the summaries
        txtMissingDays.Text = AllowedMissingDays()
        txtMissingDays.Refresh()

        'translate form controls
        Dim str As String = lblProductType.Text
        'ClsTranslations.TranslateForm(Me)
        'retain the untranslated text because it's use for selection
        lblProductType.Text = str


        ClsTranslations.TranslateComponent(lstvStations, bHeaderOnly:=True)
        ClsTranslations.TranslateComponent(lstvElements, bHeaderOnly:=True)
    End Sub
    Function AllowedMissingDays() As Integer
        Dim darg As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsrg As New DataSet

        Try
            MyConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = MyConnectionString
            conn.Open()
            sql = "SELECT keyvalue FROM regkeys WHERE keyName = 'key19';"

            darg = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dsrg.Clear()
            darg.Fill(dsrg, "Key")
            conn.Close()

            If dsrg.Tables("key").Rows.Count = 0 Then
                Return 0
            Else
                Return dsrg.Tables("key").Rows(0).Item("keyvalue")
            End If
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return 0
        End Try
    End Function

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim prod As String

        prod = cmbstation.Text

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

                ' When only one station required
                If lblProductType.Text = "Yearly Elements Observed" Then
                    lstvStations.Items.Clear()
                    lstvStations.Items.Add(itm)
                    Exit For
                End If

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

            ' Get the Level list
            levlist = ""
            For i = 0 To lstvLevels.Items.Count - 1
                If lstvLevels.Items(i).Checked Then
                    If levlist = "" Then
                        If lstvLevels.Items(i).Text = "surface" Then
                            levlist = "'" & lstvLevels.Items(i).Text & "'"
                        Else
                            levlist = lstvLevels.Items(i).Text
                        End If
                    Else
                        'levlist = levlist & " OR obsLevel = " & "'" & lstvLevels.Items(i).Text & "'"
                        levlist = levlist & " OR obsLevel = " & lstvLevels.Items(i).Text
                    End If
                End If
            Next

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
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) As Month,day(obsDatetime) as Day,hour(obsDatetime) as Hour,minute(obsDatetime) as Minute," & elmcolmn & " FROM (SELECT recordedFrom,stationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                           "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime), hour(obsDatetime), minute(obsDatetime);"

                    'Transpose values when the option is selected
                    If chkTranspose.Checked = True Then
                        xpivot = SumAvg
                        For i = 0 To 59
                            If i = 0 Then xpivot = ""
                            xpivot = xpivot & "," & SumAvg & "(IF(minute(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                        Next

                        sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Year, Month(obsDatetime) As Month, day(obsDatetime) As Day, Hour(obsDatetime) As Hour " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                              "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,Year,Month, Day;"
                    End If
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

                        sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Year, Month(obsDatetime) As Month, day(obsDatetime) As Day " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
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
                    ' Below code replaces the earlier one so that months with some missing days of observation is excluded from monthly summaries 
                    'TmpTable(stnlist, elmlist, sdate, edate, SumAvg)
                    'sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, MM, " & elmcolmn & " FROM(SELECT recordedFrom, latitude, longitude, elevation, describedBy, stationName, YY, MM, value, DF " &
                    '      "From station INNER Join tmpproducts On stationId = recordedFrom " &
                    '      "Where DF >= 0 Order By recordedFrom, YY, MM) t GROUP BY StationId,YY, MM;"

                    sql = "select StationID,station_Name,Lat, Lon, Elev,YY,MM," & elmcolmn & " from (Select recordedFrom As StationID, describedBy,stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                           From observationfinal inner Join station On stationId = recordedFrom
                           Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                           Order By recordedFrom, describedBy, YY, MM) As tt
                           where DF > 0 or abs(DF) <= " & CInt(txtMissingDays.Text) & "
                           group by StationID, YY, MM
                           order by StationID, YY, MM;"

                    '' The following code is special for KMD since most of the data doesn't have full month days hence may be unable to produce suffient summaries
                    'sql = "select StationID,station_Name,Lat, Lon, Elev,YY,MM," & elmcolmn & " from (Select recordedFrom As StationID, describedBy,stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                    '       From observationfinal inner Join station On stationId = recordedFrom
                    '       Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                    '       group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                    '       Order By recordedFrom, describedBy, YY, MM) As tt
                    '       group by StationID, YY, MM
                    '       order by StationID, YY, MM;"

                    ' Transpose products if so selected
                    If chkTranspose.Checked = True Then
                        xpivot = SumAvg
                        For i = 1 To 12
                            If i = 1 Then xpivot = ""
                            'xpivot = xpivot & "," & SumAvg & "(IF(month(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                            xpivot = xpivot & "," & SumAvg & "(IF(MM = '" & i & "', value, NULL)) AS '" & i & "'"
                        Next
                        'sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy as Element_Code, abbreviation as Element_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY" & xpivot & " FROM(SELECT recordedFrom, describedBy, stationName, abbreviation, latitude, longitude, elevation, YY, MM, value, DF " &
                        '  "From tmpproducts INNER Join station On stationId = recordedFrom INNER JOIN obselement On describedBy = elementId " &
                        '  "Where DF >= 0 Order By recordedFrom,describedBy,YY,MM) t GROUP BY StationId,recordedFrom,describedBy,YY;"

                        sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy as Element_Code, latitude As Lat, longitude As Lon, elevation As Elev, YY" & xpivot & " from (Select recordedFrom, describedBy,stationName, latitude, longitude, elevation, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                           From observationfinal inner Join station On stationId = recordedFrom
                           Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           group by StationID, describedBy,year(obsDatetime),month(obsDatetime)) as t Where DF > 0 or abs(DF) <= " & CInt(txtMissingDays.Text) & " 
                           group by StationID, Element_Code, YY order by StationID, Element_Code, YY;"

                        '' The following code is special for KMD since most of the data doesn't have full month days hence may be unable to produce suffient summaries
                        'sql = "Select recordedFrom As StationID, stationName As Station_Name, describedBy as Element_Code, latitude As Lat, longitude As Lon, elevation As Elev, YY" & xpivot & " from (Select recordedFrom, describedBy,stationName, latitude, longitude, elevation, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                        '   From observationfinal inner Join station On stationId = recordedFrom
                        '   Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                        '   group by StationID, describedBy,year(obsDatetime),month(obsDatetime)) as t 
                        '   group by StationID, Element_Code, YY order by StationID, Element_Code, YY;"

                    End If

                    DataProducts(sql, lblProductType.Text)

                Case "Dekadal"
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, " & elmcolmn & " FROM (SELECT recordedFrom, stationName, latitude, longitude,elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
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
                    sql = "SELECT recordedFrom as StationID, stationName as Station_Name, latitude as Lat,longitude as Lon, elevation as Elev,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/5.5 + 0.5,0) as  PENTAD, " & elmcolmn & " FROM (SELECT recordedFrom,stationName,latitude,longitude, elevation, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                        "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month,PENTAD;"

                    DataProducts(sql, lblProductType.Text)

                Case "Annual"
                    '' Below code replaces the earlier one so that months with some missing days of observation is excluded from monthly summaries 
                    'TmpTable(stnlist, elmlist, sdate, edate, SumAvg)
                    'TypTable(SumAvg)

                    'sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, " & elmcolmn & " FROM(SELECT recordedFrom, describedBy, stationName, latitude, longitude, elevation, YY, value, DDF " &
                    '      "From station INNER Join typroducts On stationId = recordedFrom " &
                    '      "Where DDF = 0 Order By recordedFrom, YY) t GROUP BY StationId,YY;"

                    sql = "Select StationID,Station_Name,Lat, Lon, Elev, YY, " & elmcolmn & " from(select StationID, Station_Name, describedBy, Lat, Lon, Elev, YY, Count(YY) As TM, " & SumAvg & "(value) As value from (Select StationID, Station_Name, describedBy, Lat, Lon, Elev, YY, MM, Value from (Select recordedFrom As StationID, stationName As Station_Name, describedBy, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                           From observationfinal inner Join station On stationId = recordedFrom
                           Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                           Order By recordedFrom, describedBy, YY, MM) As t
                           where DF> 0 or abs(DF) <= " & CInt(txtMissingDays.Text) & ") as tt
                           group by StationID, describedBy, YY) as ttt
                           where TM = 12 Group by StationID, YY;"

                    '' The following code is special for KMD since most of the data doesn't have full month days hence may be unable to produce suffient summaries
                    'sql = "Select StationID,Station_Name,Lat, Lon, Elev, YY, " & elmcolmn & " from(select StationID, Station_Name, describedBy, Lat, Lon, Elev, YY, Count(YY) As TM, " & SumAvg & "(value) As value from (Select StationID, Station_Name, describedBy, Lat, Lon, Elev, YY, MM, Value from (Select recordedFrom As StationID, stationName As Station_Name, describedBy, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                    '       From observationfinal inner Join station On stationId = recordedFrom
                    '       Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                    '       group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                    '       Order By recordedFrom, describedBy, YY, MM) As t) as tt
                    '       group by StationID, describedBy, YY) as ttt Group by StationID, YY;"

                    DataProducts(sql, lblProductType.Text)

                Case "Means"
                    'Dim cmd As MySql.Data.MySqlClient.MySqlCommand
                    'conn.ConnectionString = frmLogin.txtusrpwd.Text

                    elmcolmn = ""
                    If lstvElements.Items.Count > 0 Then
                        elmcolmn = " " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(0).Text & "', value, NULL)) AS '" & lstvElements.Items(0).SubItems(1).Text & "'"
                        For i = 0 To lstvElements.Items.Count - 1
                            SumAvg = "AVG"
                            If lstvElements.Items(i).Text = 5 Or lstvElements.Items(i).Text = 18 Then SumAvg = "SUM"
                            If i = 0 Then
                                elmcolmn = " " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(0).Text & "', value, NULL)) AS '" & lstvElements.Items(0).SubItems(1).Text & "'"
                            Else
                                elmcolmn = elmcolmn & ", " & SumAvg & "(IF(describedBy = '" & lstvElements.Items(i).Text & "', value, NULL)) AS '" & lstvElements.Items(i).SubItems(1).Text & "'"
                            End If
                        Next
                    End If

                    'sql = "DROP TABLE IF EXISTS LMeans; " &
                    '      "CREATE TABLE LMeans Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Years,month(obsDatetime) As Months, " & elmcolmn & " FROM(SELECT recordedFrom, latitude, longitude, elevation, describedBy, stationName, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    '      "WHERE(RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") AND (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Years, Months;"

                    'conn.Open()
                    'cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    'cmd.CommandTimeout = 0

                    ''Execute query
                    'cmd.ExecuteNonQuery()
                    'conn.Close()

                    ' Create SQL statement for the means output and call the function for creating the output file and display results.
                    Dim elmcolmn1 As String
                    If lstvElements.Items.Count > 0 Then
                        elmcolmn1 = ""
                        For i = 0 To lstvElements.Items.Count - 1
                            SumAvg = "AVG"
                            If i = 0 Then
                                elmcolmn1 = " " & SumAvg & "(" & lstvElements.Items(0).SubItems(1).Text & ") as " & lstvElements.Items(0).SubItems(1).Text
                            Else
                                elmcolmn1 = elmcolmn1 & ", " & SumAvg & "(" & lstvElements.Items(i).SubItems(1).Text & ") as " & lstvElements.Items(i).SubItems(1).Text
                            End If
                        Next

                        'sql = "select stationID, Station_Name, Lat, Lon, Elev, Months, " & elmcolmn & " from Lmeans " &
                        '  "Group by stationID,Months;"

                        sql = "select stationID, Station_Name, Lat, Lon, Elev, Months, " & elmcolmn1 & " from (Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As Years,month(obsDatetime) As Months, " & elmcolmn & " FROM(SELECT recordedFrom, latitude, longitude, elevation, describedBy, stationName, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom
                          WHERE(RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") AND (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, year(obsDatetime), month(obsDatetime)) t GROUP BY StationId,Years, Months) as tt
                          Group by stationID,Months;"

                        DataProducts(sql, Me.lblProductType.Text)
                    End If

                Case "Extremes"

                    If btnLowHigh.Checked = True Then


                        'sql = "DROP TABLE IF EXISTS obs_selected;
                        '       CREATE TABLE obs_selected
                        '       SELECT RecordedFrom as StationId, stationName, describedBy as elementId, abbreviation, obsDatetime, latitude, longitude, elevation, obsValue FROM observationfinal INNER JOIN obselement ON elementId = describedBy INNER JOIN station ON stationId = recordedFrom
                        '       Where ((RecordedFrom=" & stnlist & ") AND (describedBy=" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "'));"

                        sql = "SELECT RecordedFrom as StationId, stationName, describedBy as elementId, abbreviation, obsDatetime, latitude, longitude, elevation, obsValue FROM observationfinal INNER JOIN obselement ON elementId = describedBy INNER JOIN station ON stationId = recordedFrom
                               Where ((RecordedFrom=" & stnlist & ") AND (describedBy=" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "'))"

                        XtremesWithoutDates(sql)
                    ElseIf btnMaxDate.Checked = True Then
                        'XtremesWithDates("MaxValue", "max", sdate, edate)
                        XtremesWithDates("MaxValue", "max")
                    ElseIf btnMinDate.Checked = True Then
                        'XtremesWithDates("MinValue", "min", sdate, edate)
                        XtremesWithDates("MinValue", "min")
                    End If

                Case "GeoCLIM Monthly"
                    GeoCLIMMonthlyProducts(stnlist, sdate, edate)

                Case "GeoCLIM Dekadal"

                    For elems = 0 To lstvElements.Items.Count - 1
                        code = lstvElements.Items(elems).SubItems(0).Text
                        abbrev = lstvElements.Items(elems).SubItems(1).Text
                        GeoCLIMDekadalProducts(stnlist, code, abbrev, sdate, edate)
                    Next
                Case "GeoCLIM Daily"

                    ' Organise the daily values in horizontal structure i.e. 1..31
                    xpivot = SumAvg
                    For i = 1 To 31
                        If i = 1 Then xpivot = ""
                        xpivot = xpivot & "," & SumAvg & "(IF(day(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                    Next

                    ' Each element selected will be in a separate file with a prefix of element abbreviation
                    For elems = 0 To lstvElements.Items.Count - 1
                        code = lstvElements.Items(elems).SubItems(0).Text
                        abbrev = lstvElements.Items(elems).SubItems(1).Text
                        GeoCLIMDailyProducts(stnlist, code, abbrev, sdate, edate, xpivot)
                    Next

                Case "Inventory"

                    xpivot = SumAvg
                    For i = 1 To 31
                        If i = 1 Then xpivot = ""
                        xpivot = xpivot & "," & SumAvg & "(IF(day(obsDatetime) = '" & i & "', value, NULL)) AS '" & i & "'"
                    Next

                    sql = "DROP TABLE IF EXISTS inventory_output; CREATE TABLE inventory_output Select recordedFrom As StationID, stationName As Station_Name, describedBy As Code, latitude As Lat, longitude As Lon, elevation As Elev, year(obsDatetime) As YYYY, Month(obsDatetime) As MM " & xpivot & " FROM(Select recordedFrom, describedBy, stationName, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                                  "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Code,YYYY,MM;"

                    Inventory_Table(sql)

                Case "Yearly Elements Observed"

                    If lstvElements.Items.Count > 0 Then
                        elmcolmn = " " & "Count(IF(Code = '" & lstvElements.Items(0).Text & "', Code, NULL)) AS '" & lstvElements.Items(0).SubItems(1).Text & "'"
                        For i = 1 To lstvElements.Items.Count - 1
                            elmcolmn = elmcolmn & ", " & "Count(IF(Code = '" & lstvElements.Items(i).Text & "', Code, NULL)) AS '" & lstvElements.Items(i).SubItems(1).Text & "'"
                        Next
                    End If

                    sql = "select STN,YY, " & elmcolmn & " from (select recordedFrom as STN, year(obsDatetime) as YY, Month(ObsDatetime) as MM, describedBy as Code, obsvalue from observationfinal
                           WHERE (recordedFrom = '" & lstvStations.Items(0).Text & "') AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and (obsvalue is not NULL) order by STN,YY,MM,Code) as RR
                           group by STN,YY;"

                    'DataProducts(sql, lblProductType.Text)
                    Inventory_Chart(sql, lblProductType.Text)

                Case "Monthly Elements Observed"
                    elmcolmn = ""

                    If lstvElements.Items.Count > 0 Then
                        elmcolmn = " " & "Count(IF(Code = '" & lstvElements.Items(0).Text & "', Code, NULL)) AS '" & lstvElements.Items(0).SubItems(1).Text & "'"
                        For i = 1 To lstvElements.Items.Count - 1
                            elmcolmn = elmcolmn & ", " & "Count(IF(Code = '" & lstvElements.Items(i).Text & "', Code, NULL)) AS '" & lstvElements.Items(i).SubItems(1).Text & "'"
                        Next
                    End If

                    sql = "select STN,YY,MM, " & elmcolmn & " from (select recordedFrom as STN, year(obsDatetime) as YY, Month(ObsDatetime) as MM, describedBy as Code, obsvalue from observationfinal
                           WHERE (recordedFrom = '" & lstvStations.Items(0).Text & "') AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and (obsvalue is not NULL) order by STN,YY,MM,Code) as RR
                           group by STN,YY,MM;"

                    'DataProducts(sql, lblProductType.Text)
                    Inventory_Chart(sql, lblProductType.Text)
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
                          where describedBy= '5' and hour(obsDatetime) = " & RegkeyValue("key01") & " and obsValue >= " & threshValue & "  and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                          Group by recordedFrom, year(obsDatetime), Month(obsDatetime), round(day(obsDatetime)/10.5 + 0.5,0)
                          Order by recordedFrom, year(obsDatetime), Month(obsDatetime), round(day(obsDatetime)/10.5 + 0.5,0);"

                    DataProducts(sql, lblProductType.Text)
                Case "Monthly Counts"
                    'MsgBox(RegkeyValue("key01"))
                    threshValue = InputBox("Enter Threshold value in mm", "Threshold amount for Monthly Rainy Days", "0.03")
                    sql = "select recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, month(obsDatetime) as Month, Count(month(obsDatetime)) as Days
                           from station INNER JOIN observationfinal ON stationId = recordedFrom
                           where describedBy= '5' and hour(obsDatetime) = " & RegkeyValue("key01") & " and obsValue >= " & threshValue & " and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           Group by recordedFrom, year(obsDatetime), month(obsDatetime)
                           Order by recordedFrom, year(obsDatetime), month(obsDatetime);"

                    DataProducts(sql, lblProductType.Text)
                Case "Annual Counts"
                    threshValue = InputBox("Enter Threshold value in mm", "Threshold amount for Annual Rainy Days", "0.03")
                    sql = "select recordedFrom as StationID, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, Count(year(obsDatetime)) as Days
                           from station INNER JOIN observationfinal ON stationId = recordedFrom
                           where describedBy= '5' and hour(obsDatetime) = " & RegkeyValue("key01") & " and obsValue >= " & threshValue & "  and (recordedFrom = " & stnlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           Group by recordedFrom, year(obsDatetime)
                           Order by recordedFrom, year(obsDatetime);"


                    DataProducts(sql, lblProductType.Text)
                Case "Daily Extremes"
                    sql = "SELECT recordedFrom as StnID, stationName as Station_Name, describedBy as CODE, abbreviation as Abbrev,latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, month(obsDatetime) as Month, day(obsDatetime) as Day, Min(obsValue) as Lowest, Max(obsValue) as Highest " &
                                   "FROM  station INNER JOIN observationfinal ON stationId = recordedFrom INNER JOIN obselement ON elementId = describedBy " &
                                   "WHERE  (RecordedFrom = " & stnlist & ") And (describedBy =" & elmlist & ") And (obsDatetime between '" & sdate & "' and '" & edate & "') Group by StnID, Year, Month, Day,CODE;" 'Order by StnID,CODE,Year,Month,Day;"

                    DataProducts(sql, Me.lblProductType.Text)
                Case "Monthly Extremes"
                    sql = "SELECT recordedFrom as StnID, stationName as Station_Name, describedBy as CODE, abbreviation as Abbrev,latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month, Min(obsValue) as Lowest, Max(obsValue) as Highest " &
                                   "FROM  station INNER JOIN observationfinal ON stationId = recordedFrom INNER JOIN obselement ON elementId = describedBy " &
                                   "WHERE  (RecordedFrom = " & stnlist & ") And (describedBy =" & elmlist & ") And (obsDatetime between '" & sdate & "' and '" & edate & "') Group by StnID, Year, Month,CODE;"

                    DataProducts(sql, Me.lblProductType.Text)
                Case "Annual Extremes"
                    sql = "SELECT recordedFrom as StnID, stationName as Station_Name, describedBy as CODE, abbreviation as Abbrev, latitude as Lat, longitude as Lon, elevation as Elev, year(obsDatetime) as Year, Min(obsValue) as Lowest, Max(obsValue) as Highest" & "

                          FROM  station INNER JOIN observationfinal ON stationId = recordedFrom INNER JOIN obselement ON elementId = describedBy  
                          WHERE  (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") AND (obsDatetime between '" & sdate & "' and '" & edate & "') Group by StnID,Year,CODE;" ' Order by StnID,CODE,Year;"

                    DataProducts(sql, Me.lblProductType.Text)

                Case "Daily Levels"
                    If levlist = "" Then
                        MsgBox("No Level Selected")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    'sql = "SELECT recordedFrom as StationId,stationName as Station_Name, obsLevel as Levels, latitude as Lat, longitude as Lon,elevation as Elev, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day," & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, StationName, obsLevel, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    '"WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and (obsLevel = " & levlist & ") ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, year(obsDatetime), month(obsDatetime), day(obsDatetime),obsLevel;"

                    sql = "SELECT recordedFrom as StationId,stationName as Station_Name, latitude as Lat, longitude as Lon,elevation as Elev, obsLevel as Level, year(obsDatetime) as Year,month(obsDatetime) as Month,day(obsDatetime) as Day,CAST(time(obsDatetime) as CHAR) as Time, " & elmcolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, StationName, obsLevel, latitude, longitude,elevation, obsValue value FROM station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and (obsLevel = " & levlist & ") ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime,obsLevel;"

                    'MsgBox(sql)
                    DataProducts(sql, lblProductType.Text)

                Case "Monthly Levels"
                    If levlist = "" Then
                        MsgBox("No Level Selected")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    ' Compute for complete months only
                    'sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, MM, Level, " & elmcolmn & " FROM(SELECT recordedFrom, latitude, longitude, elevation, describedBy, stationName, CAST(obsLevel as CHAR) as Level, YY, MM, value, DF 
                    '      From station INNER Join (Select  recordedFrom, describedBy, obsLevel,Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF From observationfinal 
                    '      Where (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") AND (obsDatetime between '" & sdate & "' and '" & edate & "') AND (obsLevel =" & levlist & ") 
                    '      group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime), obsLevel) t
                    '      On stationId = recordedFrom) tt
                    '      Where DF =0
                    '      GROUP BY StationId,YY, MM, Level Order By recordedFrom, YY, MM, Level DESC;"

                    ' Compute even for non complete months
                    sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, MM, Level, " & elmcolmn & " FROM (SELECT recordedFrom, latitude, longitude, elevation, describedBy, stationName, CAST(obsLevel as INT) as Level, YY, MM, value, DF 
                          From station INNER Join (Select  recordedFrom, describedBy, obsLevel,Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF From observationfinal 
                          Where (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") AND (obsDatetime between '" & sdate & "' and '" & edate & "') AND (obsLevel =" & levlist & ") 
                          group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime), obsLevel) t
                          On stationId = recordedFrom) tt
                          GROUP BY StationId,YY, MM, Level Order By recordedFrom, YY, MM, Level DESC;"

                    DataProducts(sql, lblProductType.Text)
                    'cmbElement.Text = sql
                Case "Annual Levels"
                    If levlist = "" Then
                        MsgBox("No Level Selected")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    ' Compute for complete months only (i.e. DF=0)
                    'sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, Level, " & elmcolmn & " 
                    '      FROM (SELECT recordedFrom, describedBy, stationName, CAST(obsLevel as CHAR) as Level, latitude, longitude, elevation, YY, value 
                    '      FROM station INNER Join (select recordedFrom, describedBy, obsLevel,YY, " & SumAvg & "(Value) As value, SUM(DF) DDF from (Select  recordedFrom, describedBy, obsLevel,Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF 
                    '      FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") AND (obsDatetime between '" & sdate & "' AND '" & edate & "') AND (obsLevel =" & levlist & ") GROUP BY recordedFrom, describedBy,year(obsDatetime),month(obsDatetime), obsLevel ORDER BY recordedFrom, describedBy, YY, MM) t
                    '      WHERE DF=0 GROUP BY recordedFrom, describedBy, YY, obsLevel order by recordedFrom, describedBy, YY) tt ON stationId = recordedFrom) ttt                        
                    '      GROUP BY StationId,YY,Level ORDER BY recordedFrom, YY, Level DESC;"

                    ' Compute even for non complete month
                    sql = "Select recordedFrom As StationID, stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, YY, Level, " & elmcolmn & " 
                          FROM (SELECT recordedFrom, describedBy, stationName, CAST(obsLevel as INT) as Level, latitude, longitude, elevation, YY, value 
                          FROM station INNER Join (select recordedFrom, describedBy, obsLevel,YY, " & SumAvg & "(Value) As value, SUM(DF) DDF from (Select  recordedFrom, describedBy, obsLevel,Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF 
                          FROM observationfinal WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") AND (obsDatetime between '" & sdate & "' AND '" & edate & "') AND (obsLevel =" & levlist & ") GROUP BY recordedFrom, describedBy,year(obsDatetime),month(obsDatetime), obsLevel ORDER BY recordedFrom, describedBy, YY, MM) t
                          GROUP BY recordedFrom, describedBy, YY, obsLevel order by recordedFrom, describedBy, YY) tt ON stationId = recordedFrom) ttt                        
                          GROUP BY StationId,YY,Level ORDER BY recordedFrom, YY, Level DESC;"

                    DataProducts(sql, lblProductType.Text)
                Case "Seasonal Monthly"

                    Dim mm, startMonth, kount, yrs As Integer
                    Dim hdr, enddate As String
                    Dim endmonth As Date

                    startMonth = DateAndTime.Month(dateFrom.Text)

                    ' Compute the end seasonal date
                    yrs = DateAndTime.Year(dateTo.Text) - DateAndTime.Year(dateFrom.Text)
                    If yrs > 0 Then
                        enddate = DateAdd("yyyy", yrs, dateFrom.Text)
                        enddate = DateAdd("m", -1, enddate)
                        If DateAndTime.Month(dateFrom.Text) = 1 Then enddate = DateAdd("m", 12, enddate)
                        endmonth = enddate
                        'MsgBox(endmonth)
                        Do While endmonth.Month <> DateAndTime.Month(dateFrom.Text)
                            endmonth = DateAndTime.DateAdd("d", 1, endmonth)
                        Loop
                        edate = DateAndTime.DateAdd("d", -1, endmonth)
                        dateTo.Text = edate
                        dateTo.Refresh()

                        edate = DateAndTime.Year(edate) & "-" & DateAndTime.Month(edate) & "-" & DateAndTime.Day(edate) & " " & txtHourEnd.Text & ":" & txtMinuteEnd.Text
                        'MsgBox(edate)
                    End If

                    kount = 0
                    hdr = startMonth
                    For i = 0 To 11

                        kount = i + startMonth
                        If kount > 12 Then
                            mm = kount - 12
                        Else
                            mm = kount
                        End If
                        If i > 0 Then hdr = hdr & "," & mm
                    Next

                    'MsgBox("Seasonal Monthly - Start Month = " & hdr)
                    'sql = "select StationID,station_Name,describedBy,Lat, Lon, Elev,YY,MM," & elmcolmn & " from (Select recordedFrom As StationID, describedBy,stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                    '       From observationfinal inner Join station On stationId = recordedFrom
                    '       Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                    '       group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                    '       Order By recordedFrom, describedBy, YY, MM) As tt
                    '       where DF >= 0
                    '       group by StationID, YY, MM
                    '       order by StationID, YY, MM;"

                    sql = "select StationID,station_Name,describedBy,Lat, Lon, Elev,YY,MM, SUMMARY from (Select recordedFrom As StationID, describedBy,stationName As Station_Name, latitude As Lat, longitude As Lon, elevation As Elev, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & SumAvg & "(obsvalue) As SUMMARY, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF
                           From observationfinal inner Join station On stationId = recordedFrom
                           Where (RecordedFrom = " & stnlist & ") AND (describedBy = " & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "')
                           group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime)
                           Order By recordedFrom, describedBy, YY, MM) As tt
                           where DF >= 0
                           group by StationID,describedBy, YY, MM
                           order by StationID,describedBy, YY, MM;"

                    'txttest.Text = sql
                    SeasonalProducts(sql, lblProductType.Text, hdr)
                Case "Climate Station"

                    'sql = "SELECT 'recordedFrom', 'describedBy','obsDatetime', 'obsLevel', 'obsValue', 'flag', 'period', 'qcStatus', 'qcTypeLog', 'acquisitionType', 'dataForm', 'capturedBy', " &
                    '       "'mark', 'temperatureUnits', 'precipitationUnits','cloudHeightUnits', 'visUnits', 'dataSourceTimeZone' " &
                    '       "UNION Select * FROM observationfinal " &
                    '       "WHERE obsDatetime between '" & sdate & "' AND '" & edate & "';"

                    'sql = "SELECT * from observationfinal WHERE obsDatetime between '" & sdate & "' AND '" & edate & "';"

                    'Climate_Station(sql, lblProductType.Text, sdate, edate)
                    Climate_Station(sdate, edate)

                Case "Daily Wind Speed"

                    'sql = "SELECT recordedFrom as StationID, describedBy as Code, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, obsDatetime, obsvalue FROM (SELECT recordedFrom, StationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                    '       "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and hour(obsdatetime) = " & Int(RegkeyValue("key01")) & " ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                    Daily_WindSpeed(stnlist, elmlist, sdate, edate, "Daily Wind Speed")

                Case "Hourly Wind Speed"
                    sql = "SELECT recordedFrom as StationID, describedBy as Code, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, obsDatetime, obsvalue FROM (SELECT recordedFrom, StationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                           "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & elmlist & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') and hour(obsdatetime) = " & Int(RegkeyValue("key01")) & " ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

                    Hourly_WindSpeed(stnlist, elmlist, sdate, edate, "Hourly Wind Speed")
                    'WrunCode = InputBox("Enter Element Code?", "Hourly Wind Totalizer Element Code")
                    'If Len(WrunCode) > 0 Then MsgBox("Hourly " & WrunCode)

                Case "Daily Mean Water Level"

                    sql = "SELECT STN,COD,Dt1,Dt2, DATE_ADD(Dt1, INTERVAL 1 DAY) AS Dt3, MLVL FROM (SELECT recordedFrom AS STN, describedBy as COD, AVG(obsvalue) as MLVL, MIN(obsdatetime) AS Dt1,MAX(obsdatetime) AS Dt2 From observationfinal " &
                           "WHERE (recordedFrom =  " & stnlist & ") AND describedBy = " & elmlist & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') " &
                           "GROUP BY STN,COD,year(obsdatetime),month(obsdatetime),day(obsdatetime))t;"

                    MeanWaterLevel(sql, lblProductType.Text)

                Case "Monthly Mean Water Level"

                    sql = "SELECT STN,COD,Dt1,Dt2, DATE_ADD(Dt1, INTERVAL 1 DAY) AS Dt3, MLVL FROM (SELECT recordedFrom AS STN, describedBy as COD, AVG(obsvalue) as MLVL, MIN(obsdatetime) AS Dt1,MAX(obsdatetime) AS Dt2 From observationfinal " &
                           "WHERE (recordedFrom =  " & stnlist & ") AND describedBy = " & elmlist & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') " &
                           "GROUP BY STN,COD,year(obsdatetime),month(obsdatetime),day(obsdatetime))t;"

                    MeanWaterLevel(sql, lblProductType.Text)

                Case "Annual Mean Water Level"

                    'sql = "SELECT STN,NM,COD,LAT,LON,ALT,ELM,Dt1,Dt2, DATE_ADD(Dt1, INTERVAL 1 DAY) AS Dt3, MLVL FROM (SELECT recordedFrom AS STN, describedBy as COD, AVG(obsvalue) as MLVL, MIN(obsdatetime) AS Dt1,MAX(obsdatetime) AS Dt2, stationName as NM,latitude AS LAT, Longitude AS LON,elevation AS ALT,abbreviation AS ELM " &
                    '       "From observationfinal INNER JOIN station ON recordedfrom = stationId INNER JOIN obselement ON describedBy = elementId " &
                    '       "WHERE (recordedFrom = " & stnlist & ") AND describedBy= " & elmlist & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') " &
                    '       "GROUP BY year(obsdatetime),month(obsdatetime),day(obsdatetime))t;"

                    sql = "SELECT STN,COD,Dt1,Dt2, DATE_ADD(Dt1, INTERVAL 1 DAY) AS Dt3, MLVL FROM (SELECT recordedFrom AS STN, describedBy as COD, AVG(obsvalue) as MLVL, MIN(obsdatetime) AS Dt1,MAX(obsdatetime) AS Dt2 From observationfinal " &
                           "WHERE (recordedFrom =  " & stnlist & ") AND describedBy = " & elmlist & " AND (obsDatetime between '" & sdate & "' and '" & edate & "') " &
                           "GROUP BY STN,COD,year(obsdatetime),month(obsdatetime),day(obsdatetime))t;"

                    MeanWaterLevel(sql, lblProductType.Text)

                Case "AWS Precip Daily 06-06Z"
                    ' Compute start and end date for the daily reainfall period
                    sdate = Year(dateFrom.Text) & "-" & Month(dateFrom.Text) & "-" & DateAndTime.Day(dateFrom.Text) & " " & RegkeyValue("key01").PadLeft(2, "0") & ":00:00"
                    edate = Year(dateTo.Text) & "-" & Month(dateTo.Text) & "-" & DateAndTime.Day(dateTo.Text) & " " & RegkeyValue("key01").PadLeft(2, "0") & ":00:00"

                    edate = DateAndTime.DateAdd("s", -1, edate) ' Reduce end date by 1 second so as not toinclude precipitation for the following day
                    edate = Year(edate) & "-" & Month(edate) & "-" & DateAndTime.Day(edate) & " " & DateAndTime.Hour(edate) & ":" & DateAndTime.Minute(edate) & ":" & DateAndTime.Second(edate) ' convert date and time to SQL format

                    'MsgBox(sdate & " " & edate)
                    sql = "SELECT STN,stationName,latitude,longitude,elevation,min(Y) AS YYYY,min(M) AS MM,D as DD,sum(obsvalue) AS obsv FROM (SELECT recordedFrom AS STN, obsdatetime AS dtt, YEAR(obsDatetime) AS Y, MONTH(obsDatetime) AS M, DAY(obsDatetime) AS D, TIMESTAMPDIFF(DAY,'" & sdate & "',obsdatetime) AS dys,obsvalue
                           FROM observationfinal WHERE describedBy = " & elmlist & " AND (recordedFrom =  " & stnlist & ") AND (obsDatetime BETWEEN '" & sdate & "' AND '" & edate & "'))t
                           INNER JOIN station on STN = stationId
                           GROUP BY STN, dys;"

                    DataProducts(sql, lblProductType.Text)
                Case Else
                    MsgBox("No Product found For Selection made", MsgBoxStyle.Information)
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

        Dim fl, WRpro, WrplotAPP, WrplotAppPath, dat, datval As String
        'Dim pro As Integer
        'Dim ox As Object
        'Dim WDSP, WDDR As Integer

        Try
            WrplotAppPath = ""
            ' Locate the installation path for the windrose plot application
            If GetWRplotPath(WrplotAppPath) Then
                WrplotAPP = WrplotAppPath & "WRPLOT_View.exe"
            Else
                MsgBox("WRPlot Application Not found")
                Exit Sub
            End If

            ' SQL statement for the selecting data for windrose plotting
            'sql = "Select recordedFrom As STNID,year(obsDatetime) As YY,month(obsDatetime) As MM,day(obsDatetime) As DD,hour(obsDatetime) As HH,AVG(If(describedBy = '112', value, NULL)) AS 'DIR',AVG(IF(describedBy = '111', value, NULL)) AS 'WSPD' FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal WHERE (RecordedFrom = " & stns & ") AND (describedBy = '111' OR describedBy = '112') and (obsDatetime between '" & sdt & "' and '" & edt & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY STNID, YY, MM, DD, HH;"
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
                datval = ds.Tables("observationfinal").Rows(k).Item(0)
                For i = 1 To ds.Tables("observationfinal").Columns.Count - 1
                    If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then
                        dat = ds.Tables("observationfinal").Rows(k).Item(i)

                        ' Round the value to while numbers except the Station ID 
                        If i > 0 Then
                            dat = Math.Round(Val(ds.Tables("observationfinal").Rows(k).Item(i)), 0)
                        End If

                        ' Multiply by factor of 10 where wind direction is in 2 digits
                        If i = ds.Tables("observationfinal").Columns.Count - 2 And Int(RegkeyValue("key05")) = 2 Then
                            dat = Val(dat) * 10
                        End If
                        datval = datval & Chr(9) & dat
                    Else
                        datval = ""
                        Exit For
                    End If
                Next
                If datval <> "" Then PrintLine(11, datval)
            Next
            FileClose(11)

            'WRpro = "C:\Program Files (x86)\Lakes\WRPLOT View\WRPLOT_View.exe " & Chr(34) & "C:\Climsoft Project\Climsoft V4\Climsoft\ClimsoftVer4\ClimsoftVer4\bin\Debug\data\Wrose.txt" & Chr(34)

            WRpro = WrplotAPP & " " & Chr(34) & fl & Chr(34)
            'MsgBox(WRpro)
            Shell(WRpro, AppWinStyle.MaximizedFocus)

        Catch ex As Exception
            'If Err.Number = 5 Then On Error Resume Next
            MsgBox(ex.HResult & " : " & ex.Message)
            FileClose(11)
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
                    'MsgBox(dsp.Tables("observationfinal").Rows(k).Item(i))
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

    Sub Climate_Station(stDate As String, edDate As String)
        Dim fl_obsfinal, fl_station, fl_obselement, fldr As String
        Dim sqlm As String
        Try
            With formPaperArchive
                If .folderPaperArchive.ShowDialog <> 1 Then ' Other than OK button is clicked
                    MsgBox("Operation Cancelled")
                    Exit Sub
                End If
                fldr = .folderPaperArchive.SelectedPath
            End With

            fl_obsfinal = fldr & "\observationfinal.csv"
            FileOpen(11, fl_obsfinal, OpenMode.Output)

            ' Output Observation data
            'sqlm = "SELECT * FROM observationfinal INNER JOIN station ON recordedFrom = stationid " &
            '       "WHERE length(latitude) <> 0 and length(longitude) <> 0 AND obsDatetime BETWEEN '" & stDate & "' AND '" & edDate & "';"

            sqlm = "SELECT recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits,dataSourceTimeZone " &
                   "FROM observationfinal INNER JOIN station ON recordedFrom = stationid " &
                   "WHERE length(latitude) <> 0 and length(longitude) <> 0 AND obsDatetime BETWEEN '" & stDate & "' AND '" & edDate & "';"

            ClimateStationOutput(sqlm, 11, fl_obsfinal)
            FileClose(11)

            ' Output stations and elements metadata
            If chkOutputStations.Checked Then
                'sqlm = "SELECT stationId,stationName,latitude,longitude,elevation, qualifier,country,authority,adminRegion,drainagebasin,stationOperational FROM station;"
                sqlm = "SELECT stationId,stationName,latitude,longitude,elevation, qualifier,country,authority,adminRegion,drainagebasin,stationOperational FROM station " &
                       "INNER JOIN observationfinal ON recordedFrom = stationid " &
                       "WHERE length(latitude) <> 0 and length(longitude) <> 0 AND obsDatetime BETWEEN '" & stDate & "' AND '" & edDate & "' GROUP BY stationId ORDER BY stationId;"

                fl_station = fldr & "\station.csv"
                FileOpen(11, fl_station, OpenMode.Output)
                ClimateStationOutput(sqlm, 11, fl_station)
                FileClose(11)
            End If

            If chkOutputElements.Checked Then
                'sqlm = "SELECT * from obselement"
                sqlm = "SELECT elementId,abbreviation,elementName,description,elementScale,upperLimit,lowerLimit,units,elementtype,qcTotalRequired,Selected " &
                       "FROM obselement INNER JOIN observationfinal ON describedBy = elementId " &
                       "WHERE obsDatetime BETWEEN '" & stDate & "' AND '" & edDate & "' GROUP BY elementId ORDER BY elementId;"
                fl_obselement = fldr & "\obselement.csv"
                FileOpen(11, fl_obselement, OpenMode.Output)
                ClimateStationOutput(sqlm, 11, fl_obselement)
                FileClose(11)
            End If

            MsgBox("Data for Climate Station saved in " & fldr)
            'CommonModules.ViewFile(fl_obsfinal)

        Catch ex As Exception
            MsgBox(ex.Message & " at Climate_Station")
            'If Err.Number = 13 Or Err.Number = 5 Then Resume Next
            'MsgBox("No data found. Check and confirm selections")
            FileClose(11)
        End Try

    End Sub
    Sub ClimateStationOutput(sql As String, flNo As Integer, flNm As String)
        Dim dap As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsp As New DataSet
        Dim conp As New MySql.Data.MySqlClient.MySqlConnection
        Dim kount As Long

        Dim dat, rec As String
        Try
            conp.ConnectionString = MyConnectionString
            conp.Open()
            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conp)
            dap.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            dap.Fill(dsp, "data")
            conp.Close()

            ' Output the column headers
            rec = dsp.Tables("data").Columns(0).ColumnName
            For j = 1 To dsp.Tables("data").Columns.Count - 1
                rec = rec & "," & dsp.Tables("data").Columns(j).ColumnName
            Next
            PrintLine(flNo, rec)

            kount = dsp.Tables("data").Rows.Count

            ' Output data values
            For k = 0 To kount - 1
                rec = dsp.Tables("data").Rows(k).Item(0)
                For i = 1 To dsp.Tables("data").Columns.Count - 1
                    If IsDBNull(dsp.Tables("data").Rows(k).Item(i)) Then
                        dat = "\N"
                    Else
                        dat = dsp.Tables("data").Rows(k).Item(i)

                        ' Reconstruct datetime
                        If IsDate(dat) And InStr(dat, ".") = 0 Then
                            dat = DateAndTime.Year(dat) & "-" & DateAndTime.Month(dat) & "-" & DateAndTime.Day(dat) & " " & DateAndTime.Hour(dat) & ":" & DateAndTime.Minute(dat) & ":" & DateAndTime.Second(dat)
                        End If

                        ' Exclude escape characters that had been observe in some fields
                        If InStr(dsp.Tables("data").Rows(k).Item(i), Chr(10)) > 0 Then
                            dat = dat.Replace(Chr(10), "")
                        End If

                        If InStr(dsp.Tables("data").Rows(k).Item(i), Chr(13)) > 0 Then
                            dat = dat.Replace(Chr(13), "")
                        End If
                    End If

                    rec = rec & "," & dat
                Next
                PrintLine(flNo, rec)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            conp.Close()
            FileClose(flNo)
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
                sql = "SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " &
                       "SUM(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', SUM(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', SUM(IF(month(obsDatetime) ='3', value, NULL)) As Mar, SUM(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', SUM(IF(month(obsDatetime) ='5', value, NULL)) As 'May', SUM(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', SUM(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', SUM(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', SUM(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', SUM(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , SUM(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', SUM(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " &
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " &
                       "station INNER JOIN observationfinal ON stationId = recordedFrom WHERE (RecordedFrom = " & stns & ") AND (describedBy ='" & codes & "') and (year(obsDatetime) between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID, Year;"
            Else
                sql = "SELECT country as Country, stationName as Name, authority as Source,latitude As Latitude,longitude as Longitude,elevation as Elevation, recordedFrom as ID, year(obsDatetime) as Year, " &
                       "AVG(IF(month(obsDatetime) = '1', value, NULL)) AS 'Jan', AVG(IF(month(obsDatetime) ='2', value, NULL)) AS 'Feb', AVG(IF(month(obsDatetime) ='3', value, NULL)) As Mar, AVG(IF(month(obsDatetime) ='4', value, NULL)) AS 'Apr', AVG(IF(month(obsDatetime) ='5', value, NULL)) As 'May', AVG(IF(month(obsDatetime) ='6', value, NULL)) As 'Jun', AVG(IF(month(obsDatetime) ='7', value, NULL)) As 'Jul', AVG(IF(month(obsDatetime) ='8', value, NULL)) As 'Aug', AVG(IF(month(obsDatetime) ='9', value, NULL)) As 'Sep', AVG(IF(month(obsDatetime) ='10', value, NULL)) As 'Oct' , AVG(IF(month(obsDatetime) ='11', value, NULL)) As 'Nov', AVG(IF(month(obsDatetime) ='12', value, NULL)) As 'Dec' " &
                       "FROM (SELECT country, stationName, authority,latitude,longitude,elevation,recordedFrom, describedBy, obsDatetime, obsValue value FROM " &
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
                        'Write(11, Format("{0:0.00}", ds.Tables("observationfinal").Rows(k).Item(i)))
                        Write(11, Strings.Format(ds.Tables("observationfinal").Rows(k).Item(i), "0.00"))
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

    Sub GeoCLIMDekadalProducts(stnlist As String, codes As Integer, abbrev As String, sdate As String, edate As String)

        Dim dad As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsd As New DataSet
        Dim fl, yy, hdr, dat1, dat2, tst As String
        Dim k As Long
        Dim mm, mm1 As Integer

        sql = "SELECT country as Country,stationName as Station,authority as Source,latitude as LAT,longitude as LON, elevation as Elevation,wmoid as ID,year(obsDatetime) as Year,month(obsDatetime) as Month, round(day(obsDatetime)/10.5 + 0.5,0) as  DEKAD, AVG(IF(describedBy = " & codes & ", value, NULL)) AS '" & abbrev & "' FROM (SELECT country, stationName,authority, latitude, longitude,elevation,recordedFrom, wmoid, describedBy, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                        "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & codes & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY ID,Year,Month,DEKAD;"

        conn.Open()
        Try
            dad = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dsd.Clear()
            dad.Fill(dsd, "geodekadal")
            conn.Close()

            With dsd.Tables("geodekadal")
                yy = .Rows(0).Item(7)
                mm = .Rows(0).Item(8)
                mm1 = mm

                ' Create a file for each type of observation element

                fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\GEOCLMdekadal_" & abbrev & ".csv"

                FileOpen(11, fl, OpenMode.Output)

                ' Write the metadata headers
                hdr = .Columns.Item(0).ColumnName
                For kount = 1 To 7
                    hdr = hdr & "," & .Columns.Item(kount).ColumnName
                Next
                ' Write the dekadal headers
                For kount = 1 To 36
                    hdr = hdr & ",D" & kount
                Next
                PrintLine(11, hdr)

                k = 0
                Do While k < .Rows.Count - 1

                    mm = .Rows(k).Item(8)
                    mm1 = mm
                    dat1 = .Rows(k).Item(0)

                    For i = 1 To 7
                        dat1 = dat1 & "," & .Rows(k).Item(i)
                    Next

                    ' Dekadal values

                    ' If data months does not start in January
                    If mm > 1 Then
                        For i = 1 To mm - 1
                            mm1 = i
                            For j = 1 To 3
                                dat1 = dat1 & ",-9999"
                            Next
                        Next
                    End If
                    dat2 = dat1

                    Do While mm <= 12
                        For i = 1 To 3
                            Try ' Test if selected Data months is upto year end and fill the remaining months with missing data flags
                                tst = .Rows(k).Item(8)
                            Catch ex As Exception
                                If ex.HResult = -2146233080 Then
                                    For j = i To 3
                                        dat2 = dat2 & ",-9999"
                                    Next j
                                    mm = mm + 1
                                    Continue Do
                                End If
                            End Try

                            If .Rows(k).Item(8) = mm Then
                                If IsDBNull(.Rows(k).Item(10)) Then
                                    dat2 = dat2 & ",-9999"
                                Else
                                    dat2 = dat2 & "," & Strings.Format(.Rows(k).Item(10), "0.00")
                                End If
                                k = k + 1
                            Else ' Some data dekads missing
                                For j = i To 3
                                    dat2 = dat2 & ",-9999"
                                Next j
                                mm = mm + 1
                                Continue Do
                            End If
                        Next i
                        mm = mm + 1
                    Loop
                    PrintLine(11, dat2)
                Loop

            End With
            FileClose(11)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
        End Try
    End Sub
    Sub GeoCLIMDailyProducts(stnlist As String, codes As Integer, abbrev As String, sdate As String, edate As String, xpivot As String)

        Dim dad As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsd As New DataSet
        Dim fl As String
        Dim k As Long
        Dim dat As String

        sql = "SELECT country as Country,stationName as Station,authority as Source,latitude as LAT,longitude as LON, elevation as Elevation,wmoid as ID, year(obsDatetime) As Year, Month(obsDatetime) As Month " & xpivot & " FROM(Select recordedFrom, describedBy, stationId, stationName, country, authority, wmoid, latitude, longitude, elevation, obsDatetime, obsValue value FROM  station INNER JOIN observationfinal On stationId = recordedFrom " &
                              "WHERE (RecordedFrom = " & stnlist & ") AND (describedBy =" & codes & ") and (obsDatetime between '" & sdate & "' and '" & edate & "') ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId,Year,Month;"

        Try
            conn.Open()
            dad = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dsd.Clear()
            dad.Fill(dsd, "Geoclimdly")
            conn.Close()

            With dsd.Tables("Geoclimdly")

                ' Create a file for each type of observation element
                fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\GEOCLMdaily_" & abbrev & ".csv"

                FileOpen(11, fl, OpenMode.Output)

                ' Output the column headers
                dat = .Columns(0).ColumnName
                For j = 1 To .Columns.Count - 1
                    dat = dat & "," & .Columns(j).ColumnName
                Next

                PrintLine(11, dat)

                ' Output data values
                For k = 0 To .Rows.Count - 1
                    dat = .Rows(k).Item(0)
                    For i = 1 To .Columns.Count - 1

                        ' Assign a flag to missing data
                        If IsDBNull(.Rows(k).Item(i)) Then
                            dat = dat & "," & "-9999"
                        Else
                            ' Round the observation values to 2 decimal places
                            If IsNumeric(.Rows(k).Item(i)) And i > 8 Then
                                dat = dat & "," & Strings.Format(.Rows(k).Item(i), "0.00")
                            Else
                                dat = dat & "," & .Rows(k).Item(i)
                            End If
                        End If
                    Next
                    PrintLine(11, dat)
                Next
            End With
            FileClose(11)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
        End Try
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

            sql = "SELECT year(obsDatetime) as YY," & stnscolmn & " FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal " &
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
        ''On Error GoTo Err
        'Dim flds1, flds2, flds3 As String
        'Dim fl As String
        'Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try

            'conn.ConnectionString = frmLogin.txtusrpwd.Text
            'conn.Open()
            'qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            'qry.CommandTimeout = 0

            ''Execute query
            'qry.ExecuteNonQuery()
            'conn.Close()

            'sql = "select stationId,stationName, elementId, abbreviation, latitude, longitude, elevation, min(obsvalue) as Lowest, max(obsvalue) as Highest from  obs_selected
            '       Group by stationId,elementId
            '       Order by stationId,elementId;"

            sql = "select stationId,stationName, elementId, abbreviation, latitude, longitude, elevation, min(obsvalue) as Lowest, max(obsvalue) as Highest from (" & sql & ") as t
                   Group by stationId,elementId
                   Order by stationId,elementId;"

            DataProducts(sql, "Extremes")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub XtremesWithDates0(Xvalue As String, Xtype As String, st As String, ed As String)
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
                    sql = " select stationId,stationname,abbreviation as element,day(obsdatetime) as Day,month(obsdatetime) as Month,year(obsdatetime) as Year,obsvalue as max_val from station,obselement, observationfinal " &
                          "where stationId=recordedfrom and elementId=describedby and recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & " and obsvalue=(select " & Xtype & "(obsvalue) from observationfinal where recordedfrom='" & lstvStations.Items(stns).SubItems(0).Text & "' and describedby=" & lstvElements.Items(elms).Text & ");"

                    sql = "select stationId, stationName, elementId, abbreviation, latitude, longitude, elevation, year(obsDatetime) as Year, month(obsDatetime) as Month, day(obsDatetime) as Day, hour(obsDatetime) as Hour,obsvalue from obs_selected
                           WHERE obsvalue = (select " & Xtype & "(obsvalue) from obs_selected
                           Group by stationId, elementId
                           Having stationId ='" & lstvStations.Items(stns).SubItems(0).Text & "' and elementId =" & lstvElements.Items(elms).Text & ");"


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
            FileClose(11)
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub XtremesWithDates(Xvalue As String, Xtype As String)
        Dim f1 As String
        Dim stns, elms As Integer
        'Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()


            f1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\Xtremes.csv"

            FileOpen(11, f1, OpenMode.Output)

            Write(11, "Station_Id")
            Write(11, "Station_Name")
            Write(11, "Element")
            Write(11, "Abbreviation")
            Write(11, "Latitude")
            Write(11, "Longitude")
            Write(11, "Elevation")
            Write(11, "Year")
            Write(11, "Month")
            Write(11, "Day")
            Write(11, "Hour")
            Write(11, Xvalue)
            PrintLine(11)

            For stns = 0 To lstvStations.Items.Count - 1
                For elms = 0 To lstvElements.Items.Count - 1

                    'sql = "DROP TABLE IF EXISTS obs_selected;
                    '           CREATE TABLE obs_selected
                    '           SELECT RecordedFrom as StationId, stationName, describedBy as elementId, abbreviation, obsDatetime, latitude, longitude, elevation, obsValue FROM observationfinal INNER JOIN obselement ON elementId = describedBy INNER JOIN station ON stationId = recordedFrom
                    '           Where ((RecordedFrom='" & lstvStations.Items(stns).SubItems(0).Text & "') AND (describedBy=" & lstvElements.Items(elms).SubItems(0).Text & ") and (obsDatetime between '" & sdate & "' and '" & edate & "'));"


                    'qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    'qry.CommandTimeout = 0

                    ''Execute query
                    'qry.ExecuteNonQuery()

                    ' SQL statement to select data for extremes with dates computation
                    sql = "SELECT RecordedFrom as StationId, stationName, describedBy as elementId, abbreviation, obsDatetime, latitude, longitude, elevation, obsValue FROM observationfinal INNER JOIN obselement ON elementId = describedBy INNER JOIN station ON stationId = recordedFrom
                           Where ((RecordedFrom='" & lstvStations.Items(stns).SubItems(0).Text & "') AND (describedBy=" & lstvElements.Items(elms).SubItems(0).Text & ") and (obsDatetime between '" & sdate & "' and '" & edate & "'))"

                    ' SQL statement to select extremes values with their dates from the selected data
                    sql = "select stationId, stationName, elementId, abbreviation, latitude, longitude, elevation, year(obsDatetime) as Year, month(obsDatetime) as Month, day(obsDatetime) as Day, hour(obsDatetime) as Hour,obsvalue from (" & sql & ") as t
                           WHERE obsvalue = (select " & Xtype & "(obsvalue) from (" & sql & ") as tt
                           Group by stationId, elementId
                           Having stationId ='" & lstvStations.Items(stns).SubItems(0).Text & "' and elementId =" & lstvElements.Items(elms).SubItems(0).Text & ");"


                    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                    ds.Clear()
                    da.Fill(ds, "observationfinal")
                    maxRows = ds.Tables("observationfinal").Rows.Count

                    For k = 0 To maxRows - 1

                        For i = 0 To ds.Tables("observationfinal").Columns.Count - 1
                            'If Not IsDBNull(ds.Tables("observationfinal").Rows(k).Item(i)) Then FormattedOutput(11, k, i, ds)
                            FormattedOutput(11, k, i, ds)
                        Next
                        PrintLine(11)
                    Next
                Next
            Next
            conn.Close()
            FileClose(11)
            CommonModules.ViewFile(f1)
        Catch ex As Exception
            FileClose(11)
            conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub InventoryProducts(sql As String, typ As String)

        Dim fl, fi, flds1, flds2, flds3, datesr, hdr, dat, statis As String
        Dim X, M As Integer

        On Error GoTo Err
        Me.Cursor = Cursors.WaitCursor
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "observationfinal")

        maxRows = ds.Tables("observationfinal").Rows.Count


        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-products.csv"
        fi = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-statistics.csv"
        FileOpen(11, fl, OpenMode.Output)
        FileOpen(12, fi, OpenMode.Output)

        ' Column headers from table field names
        hdr = "Station_ID" & "," & "Station_Name" & "," & "Element_Code" & "," & "Lat" & "," & "Lon" & "," & "Elev" & "," & "Year" & "," & "Month"
        Print(11, hdr & ",")
        'Print(12, hdr & ",")

        ' Daily headers 
        For j = 1 To 31
            Write(11, j)
        Next
        ' Headers for total days with available and missing observations
        PrintLine(11, "Available" & "," & "Missing")
        'PrintLine(12, "Available" & "," & "Missing")

        With ds.Tables("observationfinal")
            For k = 0 To maxRows - 1
                X = 0
                M = 0
                dat = ""
                statis = ""
                For i = 0 To .Columns.Count - 1
                    ' Write the row headers before the Invetory descriptors
                    If i < 8 Then
                        If i = 0 Then
                            dat = .Rows(k).Item(0)
                            statis = dat
                        Else
                            dat = dat & "," & .Rows(k).Item(i)
                            statis = dat
                        End If
                    Else 'Missing observation to be represented as "M" and cell for non existent date to be blank
                        If InStr(.Rows(k).Item(i), "NULL") <> 0 Then

                            If i - 7 <= Date.DaysInMonth(.Rows(k).Item(6), .Rows(k).Item(7)) Then
                                M = M + 1
                                dat = dat & ",M"
                            Else   ' Output blank for non existent date
                                dat = dat & ","
                            End If
                        Else
                            X = X + 1
                            dat = dat & ",X"
                        End If

                    End If
                Next

                PrintLine(11, dat & "," & X & "," & M)
                PrintLine(12, statis & "," & X & "," & M)

            Next
        End With
        FileClose(11)
        FileClose(12)

        'Inventory Statistics in graphics
        'Inventory_Statistics()

        CommonModules.ViewFile(fl)

        flds1 = """" & lstvElements.Items(0).Text & """"
        flds2 = """" & lstvElements.Items(1).Text & """"
        flds3 = """" & lstvElements.Items(2).Text & """"

        ' Create a table for the total days with available and missing data 


        Me.Cursor = Cursors.Default

        Exit Sub
Err:
        'MsgBox(Err.Description)
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)
        FileClose(11)
        FileClose(12)
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
        FileClose(11)
        If Err.Number = 13 Or Err.Number = 5 Then Resume Next
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Sub Daily_WindSpeed(stns As String, elms As String, sdt As String, edt As String, typ As String)
        Dim Kount, yyyy, mm, dd As Long
        Dim fl2, nxtdyTot, dat, hdr As String
        Dim WR_Diff, WNDkh, WNDms, U_Limit As Double

        Try

            sql = "SELECT recordedFrom as StationID, describedBy as Code, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, obsDatetime, obsvalue FROM (SELECT recordedFrom, StationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                   "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elms & ") and (obsDatetime between '" & sdt & "' and '" & edt & "') and hour(obsdatetime) = " & Int(RegkeyValue("key01")) & " ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "observationfinal")

            Kount = ds.Tables("observationfinal").Rows.Count

            If Kount = 0 Then
                MsgBox("No data found")
                Exit Sub
            End If

            fl2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\windTot_products.csv"
            'fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\data_products.csv"

            FileOpen(102, fl2, OpenMode.Output)
            If FileLen(fl2) = 0 Then
                hdr = "ID,Name,Lat,Lon,Elev,Year,Month,Day,PrevWindTOT, CurrWindToT,Diff,m/s,km/h"
                '' Output the column headers
                PrintLine(102, hdr)
            End If

            ' Get current and next day daily Win Run Total values
            With ds.Tables("observationfinal")
                dat = .Rows(0).Item(0)
                For k = 0 To Kount - 1
                    nxtdyTot = ""
                    yyyy = DateAndTime.Year(.Rows(k).Item(6))
                    mm = DateAndTime.Month(.Rows(k).Item(6))
                    dd = DateAndTime.Day(.Rows(k).Item(6))
                    If windTot_Diff(.Rows(k).Item(0), .Rows(k).Item(1), .Rows(k).Item(6), "d", nxtdyTot) Then
                        WR_Diff = Val(nxtdyTot) - Val(.Rows(k).Item(7))

                        ' Compute wind run total after counter initialization
                        If WR_Diff < 0 Then
                            If WindValue_Limit(elms, U_Limit) Then
                                WR_Diff = (U_Limit - CDbl(.Rows(k).Item(7)) + CDbl(nxtdyTot))
                            Else
                                Continue For
                            End If
                        End If

                        WNDkh = WR_Diff / 24
                        WNDms = (WR_Diff * 1000) / (24 * 3600)

                        ' Check if wind speed value exceeds the upper limit
                        If WindValue_Limit(111, U_Limit) Then
                            'MsgBox(U_Limit)
                            If WNDms > U_Limit Then Continue For
                        Else
                            Continue For
                        End If

                        dat = .Rows(k).Item(0) & "," & .Rows(k).Item(2) & "," & .Rows(k).Item(3) & "," & .Rows(k).Item(4) & "," & .Rows(k).Item(5) & "," & yyyy & "," & mm & "," & dd & "," & .Rows(k).Item(7) & "," & nxtdyTot & "," & WR_Diff & "," & Math.Round(WNDms, 2) & "," & Math.Round(WNDkh, 2)

                        PrintLine(102, dat)
                    End If
                Next

            End With

            FileClose(102)
            CommonModules.ViewFile(fl2)
        Catch ex As Exception
            'MsgBox(ex.Message)
            FileClose(102)
        End Try
    End Sub

    Sub Hourly_WindSpeed(stns As String, elms As String, sdt As String, edt As String, typ As String)
        Dim Kount, yyyy, mm, dd, hh As Long
        Dim fl2, nxtdyTot, dat, hdr As String
        Dim WR_Diff, WNDkh, WNDms, U_Limit As Double

        Try

            sql = "SELECT recordedFrom as StationID, describedBy as Code, stationName as Station_Name, latitude as Lat, longitude as Lon, elevation as Elev, obsDatetime, obsvalue FROM (SELECT recordedFrom, StationName, latitude, longitude, elevation, describedBy, obsDatetime, obsValue FROM  station INNER JOIN observationfinal ON stationId = recordedFrom " &
                   "WHERE (RecordedFrom = " & stns & ") AND (describedBy =" & elms & ") and (obsDatetime between '" & sdt & "' and '" & edt & "')  ORDER BY recordedFrom, obsDatetime) t GROUP BY StationId, obsDatetime;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "observationfinal")

            Kount = ds.Tables("observationfinal").Rows.Count

            If Kount = 0 Then
                MsgBox("No data found")
                Exit Sub
            End If

            fl2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\windTot_products.csv"

            FileOpen(102, fl2, OpenMode.Output)
            If FileLen(fl2) = 0 Then
                hdr = "ID,Name,Lat,Lon,Elev,Year,Month,Day,hh,PrevWindTOT, CurrWindToT,Diff,m/s,km/h"
                '' Output the column headers
                PrintLine(102, hdr)
            End If

            ' Get current and next day daily Win Run Total values
            With ds.Tables("observationfinal")
                dat = .Rows(0).Item(0)
                For k = 0 To Kount - 1
                    nxtdyTot = ""
                    yyyy = DateAndTime.Year(.Rows(k).Item(6))
                    mm = DateAndTime.Month(.Rows(k).Item(6))
                    dd = DateAndTime.Day(.Rows(k).Item(6))
                    hh = DateAndTime.Hour(.Rows(k).Item(6))
                    If windTot_Diff(.Rows(k).Item(0), .Rows(k).Item(1), .Rows(k).Item(6), "h", nxtdyTot) Then
                        WR_Diff = Val(nxtdyTot) - Val(.Rows(k).Item(7))

                        ' Compute wind run total after counter initialization
                        If WR_Diff < 0 Then
                            If WindValue_Limit(elms, U_Limit) Then
                                WR_Diff = (U_Limit - CDbl(.Rows(k).Item(7)) + CDbl(nxtdyTot))
                            Else
                                Continue For
                            End If
                        End If

                        WNDkh = WR_Diff
                        WNDms = (WR_Diff * 1000) / 3600

                        ' Check if wind speed value exceeds the upper limit
                        If WindValue_Limit(111, U_Limit) Then
                            If WNDms > U_Limit Then Continue For
                        Else
                            Continue For
                        End If

                        dat = .Rows(k).Item(0) & "," & .Rows(k).Item(2) & "," & .Rows(k).Item(3) & "," & .Rows(k).Item(4) & "," & .Rows(k).Item(5) & "," & yyyy & "," & mm & "," & dd & "," & hh & "," & .Rows(k).Item(7) & "," & nxtdyTot & "," & WR_Diff & "," & Math.Round(WNDms, 2) & "," & Math.Round(WNDkh, 2)

                        PrintLine(102, dat)
                    End If

                Next

            End With

            FileClose(102)
            CommonModules.ViewFile(fl2)
        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(102)
        End Try
    End Sub

    Function windTot_Diff(id As String, code As Integer, dt As String, intvl As String, ByRef nxtdyValue As String) As Boolean
        Dim dap As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsp As New DataSet
        Dim sqlp, dt1 As String
        Try
            dt1 = DateAndTime.DateAdd(intvl, 1, dt)
            dt1 = DateAndTime.Year(dt1) & "-" & DateAndTime.Month(dt1) & "-" & DateAndTime.Day(dt1) & " " & DateAndTime.Hour(dt1) & ":00:00"
            sqlp = "Select obsvalue FROM observationfinal WHERE recordedFrom ='" & id & "' and describedBy = " & 187 & " AND obsdatetime = '" & dt1 & "';"

            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlp, conn)
            dap.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            dap.Fill(dsp, "observationfinal")

            If dsp.Tables("observationfinal").Rows.Count = 0 Then Return False

            nxtdyValue = dsp.Tables("observationfinal").Rows(0).Item(0)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function WindValue_Limit(Ecod As String, ByRef limitValue As Double) As Boolean
        Dim dal As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsl As New DataSet

        Try
            sql = "SELECT upperlimit * elementscale AS ULvalue FROM obselement WHERE elementId = " & Ecod & ";"
            dal = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dal.SelectCommand.CommandTimeout = 0
            dsl.Clear()
            dal.Fill(dsl, "obselement")

            If dsl.Tables("obselement").Rows.Count = 0 Or IsDBNull(dsl.Tables("obselement").Rows(0).Item(0)) Then
                limitValue = 30 ' Default wind speed upper limit value if set value is NULL
            Else
                limitValue = CDbl(dsl.Tables("obselement").Rows(0).Item(0))
                If limitValue = 0 Then limitValue = 30    ' Default wind speed upper limit value if db set value zero or not numeric
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Sub MeanWaterLevel(sql As String, typ As String)
        Dim dap As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsp As New DataSet
        Dim conp As New MySql.Data.MySqlClient.MySqlConnection
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        Dim dat, stn, cod, dtt, nxtDylvl, AVGlvl, AMlvl, PMlvl As String
        Dim wghtMean As Double
        'Dim nxtDylvl, AVGlvl, AMlvl, PMlvl, wghtMean As Double

        Try
            conp.ConnectionString = MyConnectionString
            conp.Open()
            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conp)
            dap.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            dap.Fill(dsp, "observationfinal")

            maxRows = dsp.Tables("observationfinal").Rows.Count

            If maxRows = 0 Then
                MsgBox("No data found")
                Exit Sub
            End If

            ' Create a temporary table for the daily water levels

            sql = "drop table if exists tmpproducts; " &
                   "create TABLE tmpproducts (ID VARCHAR(16),COD INT(4),YY INT(4),MM INT(2),DD INT(2),AMLevel DOUBLE(5,2), PMLevel double(5,2), Mean double(5,2));"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conp)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            ' Output data values
            With dsp.Tables("observationfinal")
                For k = 0 To maxRows - 1

                    stn = .Rows(k).Item(0)
                    cod = .Rows(k).Item(1)
                    dtt = .Rows(k).Item(2)
                    dtt = DateAndTime.Year(dtt) & "," & DateAndTime.Month(dtt) & "," & DateAndTime.Day(dtt)
                    AVGlvl = .Rows(k).Item(5)

                    AMlvl = AVGlvl
                    PMlvl = AVGlvl
                    wghtMean = AVGlvl

                    If .Rows(k).Item(2) = .Rows(k).Item(3) Then ' Only one daily reading available
                        'nxtDylvl = "NULL"
                        If DateAndTime.Hour(.Rows(k).Item(3)) < 12 Then
                            PMlvl = "NULL"
                            AMlvl = AVGlvl
                        Else
                            AMlvl = "NULL"
                            PMlvl = AVGlvl
                        End If
                    Else
                        'Try
                        waterLevel(stn, cod, .Rows(k).Item(2), AMlvl)
                            waterLevel(stn, cod, .Rows(k).Item(3), PMlvl)
                            waterLevel(stn, cod, .Rows(k).Item(4), nxtDylvl)
                            waterLevel_WeightedMean(AVGlvl, PMlvl, nxtDylvl, wghtMean)
                        'Catch y As Exception
                        '    MsgBox(nxtDylvl)
                        'End Try
                    End If

                    dat = stn & "," & cod & "," & dtt & "," & AMlvl & "," & PMlvl & "," & wghtMean

                    dat = Strings.Replace(dat, ",", "','")
                    dat = Strings.Replace(dat, "'NULL'", "NULL")

                    sql = "INSERT INTO `tmpproducts` VALUES('" & dat & "');"

                    qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conp)
                    qry.CommandTimeout = 0
                    qry.ExecuteNonQuery()

                Next
            End With
            conp.Close()

            Select Case typ
                Case "Daily Mean Water Level"
                    sql = "SELECT ID,StationName As NAME,abbreviation As Abbrev,latitude As Lat,longitude As Lon,elevation As Alt,YY,MM,DD,AMLevel,PMLevel,Mean FROM tmpproducts " &
                              "INNER Join station ON ID = stationId INNER JOIN obselement ON COD = elementId ORDER BY ID,YY,MM,DD;"
                    DataProducts(sql, typ)

                Case "Monthly Mean Water Level"

                    sql = "SELECT ID,StationName As NAME,abbreviation As Abbrev,latitude As Lat,longitude As Lon,elevation As Alt,YY,MM,AVG(AMLevel) as AMLevel,AVG(PMLevel) as PMLevel,AVG(Mean) as Mean FROM tmpproducts " &
                              "INNER Join station ON ID = stationId INNER JOIN obselement ON COD = elementId GROUP BY ID,YY,MM ORDER BY ID,YY,MM;"

                    DataProducts(sql, typ)
                Case "Annual Mean Water Level"
                    sql = "SELECT ID,StationName As NAME,abbreviation As Abbrev,latitude As Lat,longitude As Lon,elevation As Alt,YY,AVG(AMLevel) as AMLevel,AVG(PMLevel) as PMLevel,AVG(Mean) as Mean FROM tmpproducts " &
                              "INNER Join station ON ID = stationId INNER JOIN obselement ON COD = elementId GROUP BY ID,YY ORDER BY ID,YY;"

                    DataProducts(sql, typ)
                Case Else
                    MsgBox("Invalid Water Level Summary")
            End Select

        Catch ex As Exception
            'MsgBox(sql)
            MsgBox(ex.Message)
            MsgBox("No data found. Check And confirm selections")

            conp.Close()
        End Try

    End Sub


    Function waterLevel_WeightedMean(lvlAVG As Double, lvlPM As Double, lvlnxtAM As Double, ByRef wghtMean As Double) As Boolean
        Dim a, b As Double

        Try

            a = (lvlAVG) * 11
            b = ((lvlPM + lvlnxtAM) / 2) * 13
            wghtMean = Math.Round((a + b) / 24, 2)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    'Function waterLevel_nextDay(Stn As String, Ecod As String, dt As String, ByRef lvlValue As Double) As Boolean
    '    Dim dal As MySql.Data.MySqlClient.MySqlDataAdapter
    '    Dim dsl As New DataSet

    '    Try
    '        'dt = DateAdd("d", 1, dt)
    '        dt = DateAndTime.Year(dt) & "-" & DateAndTime.Month(dt) & "-" & DateAndTime.Day(dt) & " " & DateAndTime.Hour(dt) & ":" & DateAndTime.Minute(dt) & ":" & DateAndTime.Second(dt)

    '        sql = "SELECT obsvalue FROM observationfinal WHERE recordedFrom = '" & Stn & "' AND describedBy = '" & Ecod & "' AND obsdatetime ='" & dt & "';"
    '        'MsgBox(sql)
    '        dal = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        dal.SelectCommand.CommandTimeout = 0
    '        dsl.Clear()
    '        dal.Fill(dsl, "obs")

    '        If dsl.Tables("obs").Rows.Count > 0 Then
    '            lvlValue = dsl.Tables("obs").Rows(0).Item(0)
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function
    Sub waterLevel(Stn As String, Ecod As String, dtt As String, ByRef lvl As String)
        Dim dal As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsl As New DataSet

        Try

            dtt = DateAndTime.Year(dtt) & "-" & DateAndTime.Month(dtt) & "-" & DateAndTime.Day(dtt) & " " & DateAndTime.Hour(dtt) & ":" & DateAndTime.Minute(dtt) & ":" & DateAndTime.Second(dtt)

            sql = "SELECT obsvalue FROM observationfinal WHERE recordedFrom = '" & Stn & "' AND describedBy = '" & Ecod & "' AND obsdatetime ='" & dtt & "';"

            dal = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dal.SelectCommand.CommandTimeout = 0
            dsl.Clear()
            dal.Fill(dsl, "obs")

            If dsl.Tables("obs").Rows.Count = 0 Then Exit Sub ' Return False

            If IsDBNull(dsl.Tables("obs").Rows(0).Item(0)) Then
                Exit Sub ' Return False
            Else
                lvl = dsl.Tables("obs").Rows(0).Item(0)
                'Return True
            End If

            'If dsl.Tables("obs").Rows.Count = 1 Then Return dsl.Tables("obs").Rows(0).Item(0)

        Catch ex As Exception
            MsgBox(ex.Message)
            'Return False
        End Try
    End Sub
    Sub FormattedOutput(fp As Integer, rw As Long, col As Integer, dsf As DataSet)
        Try

            'If InStr(ds.Tables("observationfinal").Rows(rw).Item(col), "NULL") <> 0 Then 'Missing Values to be represented as blanks
            If IsDBNull(dsf.Tables("observationfinal").Rows(rw).Item(col)) Then
                Write(fp, "")
            ElseIf InStr(dsf.Tables("observationfinal").Rows(rw).Item(col), ".") <> 0 Then ' Decimal values to be rounded to 2 decimal places
                If IsNumeric(dsf.Tables("observationfinal").Rows(rw).Item(col)) Then
                    Write(fp, Strings.Format(dsf.Tables("observationfinal").Rows(rw).Item(col), "0.00"))
                Else
                    Write(fp, dsf.Tables("observationfinal").Rows(rw).Item(col))
                End If
            Else
                Write(fp, dsf.Tables("observationfinal").Rows(rw).Item(col))
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " at  FormattedOutput")
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


        If lblProductType.Text = "Hourly" Or lblProductType.Text = "Daily" Or lblProductType.Text = "Monthly" Or lblProductType.Text = "Annual" Or lblProductType.Text = "Pentad" Or lblProductType.Text = "Dekadal" Or lblProductType.Text = "Histograms" Or lblProductType.Text = "TimeSeries" Or lblProductType.Text = "Seasonal Monthly" Then
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
            pnlLevels.Visible = False
        Else
            pnlSummary.Visible = True
        End If

        If lblProductType.Text = "Daily Levels" Or lblProductType.Text = "Monthly Levels" Or lblProductType.Text = "Annual Levels" Then
            pnlLevels.Visible = True
            pnlSummary.Visible = False
            pnlExtremes.Visible = False
            lstvLevels.Items.Clear()
            lstvLevels.Columns.Clear()

            lstvLevels.Columns.Add("Levels", 130, HorizontalAlignment.Left)
            lstvLevels.Items.Add("surface")
            lstvLevels.Items.Add("1000")
            lstvLevels.Items.Add("925")
            lstvLevels.Items.Add("850")
            lstvLevels.Items.Add("700")
            lstvLevels.Items.Add("500")
            lstvLevels.Items.Add("400")
            lstvLevels.Items.Add("300")
            lstvLevels.Items.Add("250")
            lstvLevels.Items.Add("200")
            lstvLevels.Items.Add("150")
            lstvLevels.Items.Add("100")
            lstvLevels.Items.Add("70")
            lstvLevels.Items.Add("50")
            lstvLevels.Items.Add("30")
            lstvLevels.Items.Add("20")
            lstvLevels.Items.Add("10")
        End If

        If lblProductType.Text = "Monthly" Or lblProductType.Text = "Daily" Or lblProductType.Text = "Hourly" Or lblProductType.Text = "Minutes" Then 'Or lblProductType.Text = "Pentad" Or lblProductType.Text = "Dekadal" Then
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
            lstvElements.Items.Clear()
            lstvElements.Items.Add(itm)

            ' Set the relevant controls appropriately
            cmbElement.Enabled = False
            lstvElements.Enabled = False
            pnlSummary.Visible = False
            cmdDelElement.Enabled = False
            cmdSelectAllElements.Enabled = False
            cmdClearElements.Enabled = False

        End If

        If lblProductType.Text = "Monthly" Or lblProductType.Text = "Annual" Then
            txtMissingDays.Visible = True
            lblDaysMissing.Visible = True
        Else
            txtMissingDays.Visible = False
            lblDaysMissing.Visible = False
        End If

        If lblProductType.Text = "Climate Station" Then
            chkOutputStations.Visible = True
            chkOutputElements.Visible = True
            chkAdvancedSelection.Visible = False
            cmbstation.Enabled = False
            cmbElement.Enabled = False
            cmdSelectAllStations.Enabled = False
            cmdSelectAllElements.Enabled = False
        Else
            chkOutputStations.Visible = False
            chkOutputElements.Visible = False
            chkAdvancedSelection.Visible = True
            cmbstation.Enabled = True
            'cmbElement.Enabled = True
            cmdSelectAllStations.Enabled = True
            cmdSelectAllElements.Enabled = True
        End If

        'If lblProductType.Text = "Daily Wind Speed" Or lblProductType.Text = "Hourly Wind Speed" Then

        'Dim str(3) As String
        ''Dim Ecode As Integer

        'Dim itm = New ListViewItem

        ''WrunCode = InputBox("Element Code?", "Wind Totalizer Element Code")

        ''Ecode = CInt(WrunCode)

        'str(0) = CInt(InputBox("Element Code?", "Wind Totalizer Element Code")) 'CInt(Ecode)
        'str(1) = "WINDTOT"
        'str(2) = "Wind Totalizer"
        'itm = New ListViewItem(str)
        'lstvElements.Items.Clear()
        'lstvElements.Items.Add(itm)
        'End If


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
        conn.ConnectionString = constring
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
            'sql = "SELECT * FROM regkeys"
            sql = "SELECT keyValue FROM regkeys WHERE keyName = '" & keynm & "';"
            dar = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dar.Fill(dsr, "regkeys")

            If dsr.Tables("regkeys").Rows.Count = 1 Then
                RegkeyValue = dsr.Tables("regkeys").Rows(0).Item(0)
            Else
                RegkeyValue = vbNull
            End If

            'regmax = dsr.Tables("regkeys").Rows.Count
            'RegkeyValue = vbNull


            '' Check for the value for the selected key
            'For i = 0 To regmax - 1
            '    If dsr.Tables("regkeys").Rows(i).Item("keyName") = keynm Then
            '        RegkeyValue = dsr.Tables("regkeys").Rows(i).Item("keyValue")
            '        Exit For
            '    End If
            'Next

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
            Me.Cursor = Cursors.WaitCursor
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
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdSelectAllElements_Click(sender As Object, e As EventArgs) Handles cmdSelectAllElements.Click
        Try
            Me.Cursor = Cursors.WaitCursor
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
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
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
                da.SelectCommand.CommandTimeout = 0
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
                da.SelectCommand.CommandTimeout = 0
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
                da.SelectCommand.CommandTimeout = 0
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
                da.SelectCommand.CommandTimeout = 0
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
                ' Fill missing years
                FileClose(11)
                CommonModules.ViewFile(f1)

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(11)
        End Try
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ' When only one station required
            If lblProductType.Text = "Yearly Elements Observed" Or lblProductType.Text = "Monthly Elements Observed" Then
                lstvStations.Items.Clear()
                add_Station(cmbstation.Text)
            Else
                cmdSelectAllStations.Enabled = True
                add_Station(cmbstation.Text)
            End If
        End If
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

    Private Sub optqualifier_CheckedChanged(sender As Object, e As EventArgs) Handles optqualifier.CheckedChanged
        If optqualifier.Checked Then
            sql = "select qualifier from Station where not isnull(qualifier) group by qualifier;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "qualifier")

            If ds.Tables("qualifier").Rows.Count > 0 Then
                lstQualifier.BringToFront()
                lstQualifier.Size = New Drawing.Size(158, 50)

                For i = 0 To ds.Tables("qualifier").Rows.Count - 1
                    lstQualifier.Items.Add(ds.Tables("qualifier").Rows(i).Item(0))
                Next
            End If
        Else
            lstQualifier.Items.Clear()
            lstvStations.Items.Clear()
            lstQualifier.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub lstQualifier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstQualifier.SelectedIndexChanged

        If lstQualifier.SelectedItem <> "" Then

            sql = "select stationId, stationName from station where qualifier = '" & lstQualifier.SelectedItem & "';"
            Populate_StationsListView(sql)
        End If
    End Sub


    Sub Populate_StationsListView(sql As String)

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        ds.Clear()
        da.Fill(ds, "group")

        Dim str(2) As String
        Dim itm = New ListViewItem

        lstvStations.Items.Clear()
        If ds.Tables("group").Rows.Count > 0 Then
            For i = 0 To ds.Tables("group").Rows.Count - 1
                str(0) = ds.Tables("group").Rows(i).Item("stationId")
                str(1) = ds.Tables("group").Rows(i).Item("stationName")
                itm = New ListViewItem(str)
                lstvStations.Items.Add(itm)
            Next
        End If
    End Sub

    Private Sub lstAuthority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAuthority.SelectedIndexChanged
        'If lstAuthority.SelectedItem <> "" Then
        sql = "select stationId, stationName from station where authority = '" & lstAuthority.SelectedItem & "';"
        Populate_StationsListView(sql)
        'End If
    End Sub

    Private Sub optAuthority_CheckedChanged(sender As Object, e As EventArgs) Handles optAuthority.CheckedChanged

        If optAuthority.Checked Then
            sql = "select authority from Station where not isnull(authority) group by authority;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "authority")

            If ds.Tables("authority").Rows.Count > 0 Then
                lstAuthority.Size = New Drawing.Size(158, 50)
                lstAuthority.BringToFront()
                For i = 0 To ds.Tables("authority").Rows.Count - 1
                    lstAuthority.Items.Add(ds.Tables("authority").Rows(i).Item(0))
                Next
            End If
        Else
            lstAuthority.Items.Clear()
            lstvStations.Items.Clear()
            lstAuthority.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub optRegion_CheckedChanged(sender As Object, e As EventArgs) Handles optRegion.CheckedChanged
        If optRegion.Checked Then
            sql = "select adminRegion from Station where not isnull(adminRegion) group by adminRegion;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "adminRegion")

            If ds.Tables("adminRegion").Rows.Count > 0 Then
                lstRegion.Size = New Drawing.Size(158, 50)
                lstRegion.BringToFront()
                For i = 0 To ds.Tables("adminRegion").Rows.Count - 1
                    lstRegion.Items.Add(ds.Tables("adminRegion").Rows(i).Item(0))
                Next
            End If
        Else
            lstRegion.Items.Clear()
            lstvStations.Items.Clear()
            lstRegion.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub lstRegion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRegion.SelectedIndexChanged
        sql = "select stationId, stationName from Station where adminRegion ='" & lstRegion.SelectedItem & "';"
        Populate_StationsListView(sql)
    End Sub

    Private Sub optBasin_CheckedChanged(sender As Object, e As EventArgs) Handles optBasin.CheckedChanged
        If optBasin.Checked Then
            sql = "select drainageBasin from Station where not isnull(drainageBasin) group by drainageBasin;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "drainageBasin")

            If ds.Tables("drainageBasin").Rows.Count > 0 Then
                lstBasin.Size = New Drawing.Size(158, 50)
                lstBasin.BringToFront()
                For i = 0 To ds.Tables("drainageBasin").Rows.Count - 1
                    lstBasin.Items.Add(ds.Tables("drainageBasin").Rows(i).Item(0))
                Next
            End If
        Else
            lstBasin.Items.Clear()
            lstvStations.Items.Clear()
            lstBasin.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub lstBasin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBasin.SelectedIndexChanged
        sql = "select stationId, stationName from Station where drainageBasin ='" & lstBasin.SelectedItem & "';"
        Populate_StationsListView(sql)
    End Sub

    Private Sub optRegion2_CheckedChanged(sender As Object, e As EventArgs) Handles optRegion2.CheckedChanged
        If optRegion2.Checked Then
            sql = "select adminRegion2 from Station where not isnull(adminRegion2) group by adminRegion2;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "adminRegion2")

            If ds.Tables("adminRegion2").Rows.Count > 0 Then
                lstRegion2.Size = New Drawing.Size(158, 50)
                lstRegion2.BringToFront()
                For i = 0 To ds.Tables("adminRegion2").Rows.Count - 1
                    lstRegion2.Items.Add(ds.Tables("adminRegion2").Rows(i).Item(0))
                Next
            End If
        Else
            lstRegion2.Items.Clear()
            lstvStations.Items.Clear()
            lstRegion2.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub lstRegion2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRegion2.SelectedIndexChanged
        sql = "select stationId, stationName from Station where adminRegion2 ='" & lstRegion2.SelectedItem & "';"
        Populate_StationsListView(sql)
    End Sub

    Private Sub optRegion3_CheckedChanged(sender As Object, e As EventArgs) Handles optRegion3.CheckedChanged
        If optRegion3.Checked Then
            sql = "select adminRegion3 from Station where not isnull(adminRegion3) group by adminRegion3;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "adminRegion3")

            If ds.Tables("adminRegion3").Rows.Count > 0 Then
                lstRegion3.Size = New Drawing.Size(158, 50)
                lstRegion3.BringToFront()
                For i = 0 To ds.Tables("adminRegion3").Rows.Count - 1
                    lstRegion3.Items.Add(ds.Tables("adminRegion3").Rows(i).Item(0))
                Next
            End If
        Else
            lstRegion3.Items.Clear()
            lstvStations.Items.Clear()
            lstRegion3.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub OptGeography_CheckedChanged(sender As Object, e As EventArgs) Handles OptGeography.CheckedChanged
        If OptGeography.Checked Then
            txtLatitude.Enabled = True
            TxtLongitude.Enabled = True
            txtRadius.Enabled = True
        Else
            txtLatitude.Enabled = False
            TxtLongitude.Enabled = False
            txtRadius.Enabled = False
        End If


    End Sub


    Private Sub butFill_Click(sender As Object, e As EventArgs) Handles butFill.Click
        Dim lat, lon, radius, degRadius As Double
        lat = txtLatitude.Text
        lon = TxtLongitude.Text
        radius = txtRadius.Text

        If IsNumeric(lat) And IsNumeric(lon) And IsNumeric(radius) Then

            ' Compute the radius in degrees from distance in km
            degRadius = (Val(txtRadius.Text) * Val(txtRadius.Text)) / 2
            degRadius = Math.Sqrt(degRadius)
            degRadius = degRadius * 0.009

            sql = "select stationId, stationName from (SELECT stationId, StationName,latitude,abs(latitude-(" & lat & ")) as lat,longitude,abs(longitude-(" & lon & ")) as lon from station
                   WHERE latitude IS NOT NULL and longitude IS NOT NULL) as tt
                   where lat <= " & degRadius & " and lon <= " & degRadius & " order by stationId;"

            Populate_StationsListView(sql)

        Else
            MsgBox("Input must be numbers")
        End If
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

    Sub Inventory_Table(sql As String)
        Dim con As New MySql.Data.MySqlClient.MySqlConnection
        Dim constr As String
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        'MsgBox("Create Inventory Table")
        Try
            constr = frmLogin.txtusrpwd.Text
            con.ConnectionString = constr
            con.Open()

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, con)
            qry.CommandTimeout = 0

            'Execute query

            qry.ExecuteNonQuery()
            'MsgBox("inventory Table with Missing data created")
            Intialize_Inventory_Table(con)
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message) '& ": Update Failure!")
            con.Close()
        End Try

    End Sub

    Sub Intialize_Inventory_Table(cons As MySql.Data.MySqlClient.MySqlConnection)

        Dim sql0, stid, stnNm, elm, lat, lon, elev, fi, dat As String
        Dim yy, mm As Long
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try

            ' Modify inventory table for unique records and character fields for Latitude and Longitude to allow blank values

            sql0 = "ALTER TABLE `inventory_output` CHANGE COLUMN `Station_Name` `Station_Name` VARCHAR(255) NULL DEFAULT NULL AFTER `StationID`, CHANGE COLUMN `Lat` `Lat` VARCHAR(50) NULL AFTER `Code`, CHANGE COLUMN `Lon` `Lon` VARCHAR(50) NULL AFTER `Lat`, ADD PRIMARY KEY (`StationID`, `Code`, `YYYY`, `MM`);"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql0, cons)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            fi = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-table.csv"
            FileOpen(110, fi, OpenMode.Output)

            For s = 0 To lstvStations.Items.Count - 1
                stid = lstvStations.Items(s).SubItems(0).Text
                stnNm = lstvStations.Items(s).SubItems(1).Text

                Get_LatLon(cons, stid, lat, lon, elev)

                For e = 0 To lstvElements.Items.Count - 1
                    elm = lstvElements.Items(e).SubItems(0).Text
                    For y = Year(dateFrom.Text) To Year(dateTo.Text)
                        yy = y
                        For m = 1 To 12
                            mm = m

                            If DateSerial(yy, mm, 1) > Now() Or DateSerial(yy, mm, 1) > dateTo.Text Then Exit For

                            dat = stid & "," & stnNm & "," & elm & "," & lat & "," & lon & "," & elev & "," & yy & "," & mm

                            PrintLine(110, dat)
                            'PrintLine(110)
                        Next m
                    Next y
                Next e
            Next s
            FileClose(110)

            fi = Strings.Replace(fi, "\", "/") ' Convert file path to sql structure

            'sql0 = "LOAD DATA local INFILE 'C:/ProgramData/Climsoft4/data/inventory-table.csv' IGNORE INTO TABLE inventory_output FIELDS TERMINATED BY ',' (StationID, Station_Name, Code, Lat, Lon, Elev, YYYY, MM)"
            sql0 = "LOAD DATA local INFILE '" & fi & "' IGNORE INTO TABLE inventory_output FIELDS TERMINATED BY ',' (StationID, Station_Name, Code, Lat, Lon, Elev, YYYY, MM)"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql0, cons)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            sql0 = "select * from inventory_output order by stationID, Code, YYYY, MM;"
            InventoryProducts(sql0, "Inventory")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub Get_LatLon(conns As MySql.Data.MySqlClient.MySqlConnection, id As String, ByRef lat As String, ByRef lon As String, ByRef elev As String)

        sql = "SELECT stationId, latitude, longitude, elevation FROM station WHERE stationId = '" & id & "';"
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            ds.Clear()
            da.Fill(ds, "station")

            With ds.Tables("station")
                lat = ""
                lon = ""
                elev = ""
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("latitude")) Then lat = .Rows(0).Item("latitude")
                    If Not IsDBNull(.Rows(0).Item("longitude")) Then lon = .Rows(0).Item("longitude")
                    If Not IsDBNull(.Rows(0).Item("elevation")) Then elev = .Rows(0).Item("elevation")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message & " Attribute Get_LatLon")
        End Try
    End Sub
    Sub TmpTable(stns As String, elms As String, sdt As String, edt As String, summry As String, Optional Levels As String = "")
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        sql = "drop table if exists tmpproducts; " &
              "create table tmpproducts Select  recordedFrom, describedBy, Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & summry & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF " &
              "From observationfinal " &
              "Where (RecordedFrom = " & stns & ") AND (describedBy =" & elms & ") and (obsDatetime between '" & sdt & "' and '" & edt & "') " &
              "group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime) " &
              "Order By recordedFrom, describedBy, YY, MM;"

        If Levels <> "" Then
            sql = "drop table if exists tmpproducts; " &
                  "create table tmpproducts Select  recordedFrom, describedBy, obsLevel,Year(obsDatetime) As YY, Month(obsDatetime) As MM, " & summry & "(obsvalue) As value, Count(obsValue) As Days, Count(obsValue) - Day(Last_Day(obsDatetime)) as DF " &
                  "From observationfinal " &
                 "Where (RecordedFrom = " & stns & ") AND (describedBy =" & elms & ") AND (obsDatetime between '" & sdt & "' and '" & edt & "') AND (obsLevel =" & Levels & ") " &
                 "group by recordedFrom, describedBy,year(obsDatetime),month(obsDatetime), obsLevel " &
                 "Order By recordedFrom, describedBy, YY, MM;"
        End If


        'MsgBox(sql)
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        cmd.CommandTimeout = 0

        'Execute query
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    Sub TypTable(summry As String, Optional levels As String = "")
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        sql = "drop table if exists typroducts; " &
              "create table typroducts select recordedFrom, describedBy, YY, " & summry & "(Value) As value, SUM(DF) DDF from tmpproducts " &
              "group by recordedFrom, describedBy, YY order by recordedFrom, describedBy, YY;"

        If levels <> "" Then
            sql = "drop table if exists typroducts; " &
              "create table typroducts select recordedFrom, describedBy, obsLevel,YY, " & summry & "(Value) As value, SUM(DF) DDF from tmpproducts " &
              "group by recordedFrom, describedBy, YY, obsLevel order by recordedFrom, describedBy, YY;"
        End If
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        cmd.CommandTimeout = 0

        'Execute query
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Sub Inventory_Statistics()
        Dim fl, sql As String
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand

        Try
            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\inventory-statistics.csv"
            fl = Strings.Replace(fl, "\", "/")

            sql = "DROP TABLE IF EXISTS `invent_statics`;
                   CREATE TABLE IF NOT EXISTS `invent_statics` (
                  `StationID` VARCHAR(50) NOT NULL,
                  `Station_Name` VARCHAR(100) NULL DEFAULT NULL,
                  `Code` BIGINT(20) NOT NULL,
                   `Lat` VARCHAR(50) NULL DEFAULT NULL,
                  `Lon` VARCHAR(50) NULL DEFAULT NULL,
                  `Elev` VARCHAR(50) NULL DEFAULT NULL,
                  `YYYY` INT(4) NOT NULL,
                  `MM` INT(2) NOT NULL,
                  `AVailable` INT(2) NOT NULL,
                  `Missing` INT(2) NOT NULL
                  );
                LOAD DATA local INFILE '" & fl & "' IGNORE INTO TABLE invent_statics FIELDS TERMINATED BY ',' (StationID, Station_Name, Code, Lat, Lon, Elev, YYYY, MM, Available, Missing);"

            conn.Open()
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            'conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Exit Sub
        End Try

        ' Draw chart for missing data records
        Try
            'sql = "select StationID, Station_Name, code, YYYY,MM, Missing from invent_statics;"
            'sql = "select StationID, Station_Name, code, YYYY, sum(Available) as Tdays from invent_statics group by YYYY;"
            sql = "SELECT stationID, Station_Name, YYYY,SUM(IF(Code = '2', value, 0)) AS 'TMAX',SUM(IF(Code = '3', value, 0)) AS 'TMIN', SUM(IF(Code ='5', value, 0)) AS 'PRECIP' FROM (SELECT stationID, Station_Name, Code, YYYY, Available as value FROM invent_statics ORDER BY StationID, YYYY) t GROUP BY StationID, YYYY;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "inventory")


            ' Add data to series
            With frmInventoryChart.chartInventory

                'Define Series
                For i = 3 To ds.Tables("inventory").Columns.Count - 1
                    '.Series.Add(ds.Tables("inventory").Columns.Item(i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                    .Series.Add(ds.Tables("inventory").Columns.Item(i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Next

                For i = 0 To ds.Tables("inventory").Rows.Count - 1
                    For j = 3 To 5
                        'Series(ds.Tables("charts").Columns.Item(flds - j).ToString).Points.AddXY(dttime, ds.Tables("charts").Rows(i).Item(flds - j))
                        .Series(ds.Tables("inventory").Columns.Item(j).ToString).Points.AddXY(ds.Tables("inventory").Rows(i).Item(2), ds.Tables("inventory").Rows(i).Item(j))
                    Next
                Next

                frmInventoryChart.Show()
                .ChartAreas("ChartArea1").AxisX.Interval = 1
                .ChartAreas("ChartArea1").AxisY.Interval = 30
                '.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = True
                .ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True
                frmInventoryChart.chartInventory.Show()
            End With
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub

    Sub Inventory_Chart(sqc As String, prdType As String)
        Dim Xaxis, XTitle, ChTitle As String
        Dim series1 As Integer

        Select Case prdType
            Case "Yearly Elements Observed"
                series1 = 2
                ChTitle = "Yearly Observed Elements for " & lstvStations.Items(0).SubItems(1).Text
                XTitle = "Years"
            Case "Monthly Elements Observed"
                series1 = 3
                ChTitle = "Monthly Observed Elements for " & lstvStations.Items(0).SubItems(1).Text
                XTitle = "Months"
        End Select

        Try

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sqc, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "chart")

            ' Add data to series

            frmInventoryChart.Show()
            frmInventoryChart.chartInventory.Series.Clear()

            With frmInventoryChart.chartInventory

                'Define Series


                For i = series1 To ds.Tables("chart").Columns.Count - 1
                    '.Series.Add(ds.Tables("inventory").Columns.Item(i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                    .Series.Add(ds.Tables("chart").Columns.Item(i).ToString).ChartType = DataVisualization.Charting.SeriesChartType.Line
                Next

                For i = 0 To ds.Tables("chart").Rows.Count - 1
                    For j = series1 To ds.Tables("chart").Columns.Count - 1
                        '.Series(ds.Tables("chart").Columns.Item(j).ToString).Points.AddXY(ds.Tables("chart").Rows(i).Item(1), ds.Tables("chart").Rows(i).Item(j))
                        If prdType = "Yearly Elements Observed" Then
                            Xaxis = ds.Tables("chart").Rows(i).Item(1)
                        Else
                            Xaxis = ds.Tables("chart").Rows(i).Item(1) & ds.Tables("chart").Rows(i).Item(2).ToString.PadLeft(2, "0"c).ToString
                            'min.PadLeft(2, "0"c)
                        End If

                        .Series(ds.Tables("chart").Columns.Item(j).ToString).Points.AddXY(Xaxis, ds.Tables("chart").Rows(i).Item(j))
                    Next
                Next

                .ChartAreas("ChartArea1").AxisX.Interval = 1
                '.ChartAreas("ChartArea1").AxisY.Interval = 30
                '.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = True
                .ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = True

                ' Add titles
                .Titles.Clear()
                .Titles.Add(ChTitle).Alignment = ContentAlignment.TopCenter
                .ChartAreas("ChartArea1").AxisX.Title = XTitle
                .ChartAreas("ChartArea1").AxisY.Title = "Total Observations"


                With frmInventoryChart
                    '.chartInventory.Show()
                    .lstSeries.Items.Clear()
                    For i = 0 To .chartInventory.Series.Count - 1
                        .lstSeries.Items.Add(.chartInventory.Series(i).Name)
                    Next
                End With

                '.Show()
            End With

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

    End Sub
    Sub SeasonalProducts(sql As String, typ As String, months As String)

        Dim dap As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsp As New DataSet
        Dim conp As New MySql.Data.MySqlClient.MySqlConnection
        Dim fl, mms(), dat(), vals As String
        Dim yr, mr, yy, mm, rec, kount As Integer

        Try
            conp.ConnectionString = MyConnectionString
            conp.Open()
            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conp)
            dap.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            dap.Fill(dsp, "observationfinal")
            conp.Close()

            maxRows = dsp.Tables("observationfinal").Rows.Count

            fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\data_products.csv"

            FileOpen(11, fl, OpenMode.Output)

            ' Output the column headers
            For j = 0 To dsp.Tables("observationfinal").Columns.Count - 2
                If j <> 6 Then Write(11, dsp.Tables("observationfinal").Columns(j).ColumnName)
            Next
            ' Output Months columns
            mms = Strings.Split(months, ",")
            dat = Strings.Split(",,,,,,,,,,,", ",")

            For i = 0 To mms.Count - 1
                Write(11, mms(i))
            Next

            PrintLine(11)

            ' Output data values
            rec = 0
            kount = 0
            'mm = 0
            yr = dsp.Tables("observationfinal").Rows(0).Item(6)
            mr = dsp.Tables("observationfinal").Rows(0).Item(7)

            'dat(0) = dsp.Tables("observationfinal").Rows(rec).Item(7)
            'Do While rec < maxRows
            '    yr = dsp.Tables("observationfinal").Rows(rec).Item(5)
            '    mr = dsp.Tables("observationfinal").Rows(rec).Item(6)

            '    Do While mm < 11
            '        yy = dsp.Tables("observationfinal").Rows(rec).Item(5)
            '        mr = dsp.Tables("observationfinal").Rows(rec).Item(6)
            '        If mms(mm) = mr Then
            '            dat(mr) = dsp.Tables("observationfinal").Rows(rec).Item(7)
            '        End If
            '        mm = mm + 1
            '        rec = rec + 1
            '        If yy - yr > 2 Then Exit Do
            '    Loop
            '    For n = 0 To 5
            '        Write(11, dsp.Tables("observationfinal").Rows(rec).Item(n))
            '    Next
            '    For i = 0 To 11
            '        Write(11, dat(i))
            '        dat(i) = ""
            '    Next
            '    FileClose(11)
            '    CommonModules.ViewFile(fl)
            '    Exit Sub
            'Loop

            'MsgBox(yr & " " & maxRows)
            Do While rec <= maxRows - 1

                'kount = kount + 1
                yy = dsp.Tables("observationfinal").Rows(rec).Item(6)
                mm = dsp.Tables("observationfinal").Rows(rec).Item(7)
                'If (yy - yr) > 1 Then
                '    MsgBox(yr & " " & mm)
                'End If
                If (yy = yr And mm >= mms(0)) Or (yy = yr + 1 And mm < mms(0)) Then
                    'MsgBox(yy & " " & mm)
                    'If (dsp.Tables("observationfinal").Rows(k).Item(5) = yr + 1) Then
                    For i = 0 To mms.Count - 1
                        If mms(i) = dsp.Tables("observationfinal").Rows(rec).Item(7) Then
                            dat(i) = dsp.Tables("observationfinal").Rows(rec).Item(8)
                        End If
                    Next

                    rec = rec + 1
                Else

                    vals = ""
                    For m = 0 To 11
                        If Len(dat(m)) > 0 Then vals = vals & dat(m)
                        If m = 11 And Len(vals) = 0 Then
                            kount = kount + 1
                            rec = kount
                            Continue Do
                        End If
                    Next

                    ' Output metadata
                    For n = 0 To 6
                        If n < 6 Then
                            Write(11, dsp.Tables("observationfinal").Rows(rec - 1).Item(n))
                        Else
                            If mms(0) = 1 Then
                                Write(11, yr)
                            Else
                                Write(11, yr & "/" & yr + 1)
                            End If
                        End If
                    Next

                    ' Output data
                    For m = 0 To 11
                        If dat(m) = "" Then
                            Write(11, "")
                        Else
                            Write(11, Format(Val(dat(m)), "0.00"))
                        End If

                        dat(m) = ""
                    Next
                    PrintLine(11)
                    yr = dsp.Tables("observationfinal").Rows(rec).Item(6)

                End If

                ' The last record
                If rec = maxRows - 1 Then

                    For i = 0 To mms.Count - 1
                        If mms(i) = dsp.Tables("observationfinal").Rows(rec).Item(7) Then
                            dat(i) = dsp.Tables("observationfinal").Rows(rec).Item(8)
                        End If
                    Next

                    For n = 0 To 6
                        If n < 6 Then
                            Write(11, dsp.Tables("observationfinal").Rows(rec).Item(n))
                        Else
                            'Write(11, yr & "/" & yr + 1)
                            If mms(0) = 1 Then
                                Write(11, yr)
                            Else
                                Write(11, yr & "/" & yr + 1)
                            End If
                        End If
                    Next

                    For m = 0 To 11
                        If dat(m) = "" Then
                            Write(11, "")
                        Else
                            Write(11, Format(Val(dat(m)), "0.00"))
                        End If

                        'Write(11, Format(Val(dat(m)), "0.00"))
                        dat(m) = ""
                    Next
                    PrintLine(11, Chr(13))
                    yr = dsp.Tables("observationfinal").Rows(rec).Item(6)
                End If


                kount = kount + 1
            Loop


            'For i = 0 To dsp.Tables("observationfinal").Columns.Count - 1
            '    'MsgBox(dsp.Tables("observationfinal").Rows(k).Item(i))
            '    FormattedOutput(11, k, i, dsp)
            'Next
            'PrintLine(11)

            '' Output the column headers
            'For j = 0 To dsp.Tables("observationfinal").Columns.Count - 1
            '    Write(11, dsp.Tables("observationfinal").Columns(j).ColumnName)
            'Next
            'PrintLine(11)

            'For k = 0 To maxRows - 1
            '    For i = 0 To dsp.Tables("observationfinal").Columns.Count - 1
            '        'MsgBox(dsp.Tables("observationfinal").Rows(k).Item(i))
            '        FormattedOutput(11, k, i, dsp)
            '    Next
            '    PrintLine(11)
            'Next

            FileClose(11)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            'If Err.Number = 13 Or Err.Number = 5 Then Resume Next
            MsgBox("No data found. Check and confirm selections")
            FileClose(11)
            conp.Close()
        End Try

    End Sub

    Private Sub lstRegion3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRegion3.SelectedIndexChanged
        sql = "select stationId, stationName from Station where adminRegion3 ='" & lstRegion3.SelectedItem & "';"
        Populate_StationsListView(sql)
    End Sub

    Private Sub optRegion4_CheckedChanged(sender As Object, e As EventArgs) Handles optRegion4.CheckedChanged
        If optRegion4.Checked Then
            sql = "select adminRegion4 from Station where not isnull(adminRegion4) group by adminRegion4;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "adminRegion4")

            If ds.Tables("adminRegion4").Rows.Count > 0 Then
                lstRegion4.Size = New Drawing.Size(158, 50)
                lstRegion4.BringToFront()
                For i = 0 To ds.Tables("adminRegion4").Rows.Count - 1
                    lstRegion4.Items.Add(ds.Tables("adminRegion4").Rows(i).Item(0))
                Next
            End If
        Else
            lstRegion4.Items.Clear()
            lstvStations.Items.Clear()
            lstRegion4.Size = New Drawing.Size(158, 17)
        End If
    End Sub

    Private Sub lstRegion4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstRegion4.SelectedIndexChanged
        sql = "select stationId, stationName from Station where adminRegion4 ='" & lstRegion4.SelectedItem & "';"
        Populate_StationsListView(sql)
    End Sub
End Class
