Public Class frmCLIMAT
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim qry As MySql.Data.MySqlClient.MySqlCommand
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim frm As String
    Dim PRESST, PRESSL, GPM, TMPMN, TMPMAX, TMPMIN, VAPPSR, PRECIP, SUNSHN, SNWDEP, WNDSPD, VISBY, DYTHND, DYHAIL As Integer
    Private Sub butClose_Click(sender As Object, e As EventArgs) Handles butClose.Click
        Me.Close()
    End Sub

    Private Sub frmCLIMAT_Load(sender As Object, e As EventArgs) Handles Me.Load

        myConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = myConnectionString
        conn.Open()

        Try
            'Set Header for Stations list view
            lstvStations.Columns.Clear()
            lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
            lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

            sql = "select stationName from station where wmoid  <> '' and wmoid is not null;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "station")

            For kount = 0 To ds.Tables("station").Rows.Count - 1
                cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))
            Next

            ' Date for CLIMAT message
            Dim dateCLIMAT As Date
            dateCLIMAT = DateAdd("m", -1, Now())
            txtYear.Text = DateAndTime.Year(dateCLIMAT)
            txtMonth.Text = DateAndTime.Month(dateCLIMAT)
            txtBeginYear.Text = 1961
            txtEndYear.Text = 1990
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' Assign parameter codes from database
        Try

            sql = "select * from climat_parameters order by Nos;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "parameters")

            ' PRESST, PRESSL, GPM, TMPMN, TMPMAX, TMPMIN, VPPSR, PRECIP, SUNSHN, SNWDEP, WNDSPD, VISBY, DYTHND, DYHAIL
            Dim Abbrev, Ecode As String
            With ds.Tables("parameters")
                For i = 0 To .Rows.Count - 1
                    Abbrev = .Rows(i).Item("Element_Abbreviation")
                    Ecode = .Rows(i).Item("Element_Code")
                    Select Case Abbrev
                        Case "PRESST"
                            PRESST = Ecode
                        Case "PRESSL"
                            PRESSL = Ecode
                        Case "GPM"
                            GPM = Ecode
                        Case "TMPMN"
                            TMPMN = Ecode
                        Case "TMPMAX"
                            TMPMAX = Ecode
                        Case "TMPMIN"
                            TMPMIN = Ecode
                        Case "VAPPSR"
                            VAPPSR = Ecode
                        Case "PRECIP"
                            PRECIP = Ecode
                        Case "SUNSHN"
                            SUNSHN = Ecode
                        Case "SNWDEP"
                            SNWDEP = Ecode
                        Case "WNDSPD"
                            WNDSPD = Ecode
                        Case "VISBY"
                            VISBY = Ecode
                        Case "DYTHND"
                            DYTHND = Ecode
                        Case "DYHAIL"
                            DYHAIL = Ecode
                    End Select
                Next
            End With
        Catch ex As Exception
            'MsgBox(ex.HResult & " " & ex.Message)
            If ex.HResult = -2147467259 Then
                frmClimatSettings.Create_ParametersTable()
            Else
                MsgBox(ex.Message)
            End If

        End Try
        conn.Close()
    End Sub

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim ItmExist As Boolean
        sql = "select stationId, stationName from station where stationName  = '" & cmbstation.Text & "';"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        'maxRows = (ds.Tables("station").Rows.Count)
        'If maxRows > 0 Then cmbstation.BackColor = Color.White

        Dim str(2) As String
        Dim itm = New ListViewItem

        Try

            str(0) = ds.Tables("station").Rows(0).Item("stationId")
            str(1) = ds.Tables("station").Rows(0).Item("stationName")
            itm = New ListViewItem(str)

            If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                lstvStations.Items.Add(itm)
            Else
                ItmExist = False
                For j = 0 To lstvStations.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so in order to avoid duplicates
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

    Private Sub butClear_Click(sender As Object, e As EventArgs) Handles butClear.Click
        ' Clear selections made so far
        lstvStations.Items.Clear()
        txtYear.Clear()
        txtMonth.Clear()
        txtBeginYear.Clear()
        txtEndYear.Clear()
        lstMessages.Items.Clear()
        chk222.Checked = False
        chk333.Checked = False
        chk444.Checked = False
    End Sub

    Private Sub butStatistics_Click(sender As Object, e As EventArgs) Handles butStatistics.Click

        ' Construct query string for the selected stations for CLIMAT encoding e.g.
        'recordedFrom ='67774010' or recordedFrom ='1052' or recordedFrom ='1036' or recordedFrom ='1090'

        Dim stnlst As String
        stnlst = ""
        For i = 0 To lstvStations.Items.Count - 1
            If i = 0 Then
                stnlst = "recordedFrom = '" & lstvStations.Items(0).SubItems(0).Text & "'"
            Else
                stnlst = stnlst & " or recordedFrom = '" & lstvStations.Items(i).SubItems(0).Text & "'"
            End If
        Next

        ' Compute and tabulate Normals
        If txtBeginYear.Text <> "" And txtEndYear.Text <> "" And stnlst <> "" Then
            Compute_Normals(stnlst)
        Else
            MsgBox("All required input not provided")
        End If

    End Sub

    Sub Compute_Normals(lst As String)
        Me.Cursor = Cursors.WaitCursor
        lstMessages.Items.Clear()
        'Normals for elements that require Totals i.e Precipitation and Sunshine hours
        sql = "DROP TABLE IF EXISTS Normals_Totals;
               CREATE TABLE Normals_Totals select stn,code,
               AVG(IF(mm = 1, TOT, NULL)) AS '1', AVG(IF(mm = 2, TOT, NULL)) AS '2', AVG(IF(mm = 3, TOT, NULL)) AS '3',AVG(IF(mm = 4, TOT, NULL)) AS '4', AVG(IF(mm = 5, TOT, NULL)) AS '5', AVG(IF(mm = 6, TOT, NULL)) AS '6', AVG(IF(mm = 7, TOT, NULL)) AS '7',
               AVG(IF(mm = 8, TOT, NULL)) AS '8', AVG(IF(mm = 9, TOT, NULL)) AS '9', AVG(IF(mm = 10, TOT, NULL)) AS '10', AVG(IF(mm = 11, TOT, NULL)) AS '11',AVG(IF(mm = 12, TOT, NULL)) AS '12'
               from (select recordedFrom as stn, describedBy as code, year(obsDatetime) as yy, month(obsDatetime) as mm, sum(obsValue) as TOT from observationfinal
               where (describedBy = '" & PRECIP & "' or describedBy = '" & SUNSHN & "') and (" & lst & ") and (year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & ") Group by yy,mm,code) as TT
               Group by stn,code;"
        'sql ="select stn,code,Abbrev,
        'AVG(If(mm = 1, TOT, NULL)) As '1', AVG(IF(mm = 2, TOT, NULL)) AS '2', AVG(IF(mm = 3, TOT, NULL)) AS '3',AVG(IF(mm = 4, TOT, NULL)) AS '4', AVG(IF(mm = 5, TOT, NULL)) AS '5', AVG(IF(mm = 6, TOT, NULL)) AS '6', AVG(IF(mm = 7, TOT, NULL)) AS '7',
        'AVG(If(mm = 8, TOT, NULL)) As '8', AVG(IF(mm = 9, TOT, NULL)) AS '9', AVG(IF(mm = 10, TOT, NULL)) AS '10', AVG(IF(mm = 11, TOT, NULL)) AS '11',AVG(IF(mm = 12, TOT, NULL)) AS '12'
        'from(select recordedFrom as stn, describedBy As code, Element_Abbreviation As Abbrev, Year(obsDatetime) As yy, Month(obsDatetime) As mm, sum(obsValue) as TOT from observationfinal inner join climat_parameters on describedBy = Element_Code 
        'where(describedBy = '892' or describedBy = '881') and (recordedFrom = 'SF006085' ) and (year(obsDatetime) between 1992 and 2021) Group by yy,mm,code) as TT
        'Group by stn, code;"

        Try
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()
            'MsgBox("Normals for Precipitations And Sunshine hrs computed")
            lstMessages.Items.Add("Normals for Precipitations And Sunshine hrs computed")
            lstMessages.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

        'Normals for elements that require Averages i.e Temperature and Pressure
        sql = "DROP TABLE IF EXISTS Normals_Averages;
                CREATE TABLE Normals_Averages select recordedFrom as stn,describedBy as code,
                AVG(IF(month(obsDatetime) = 1, obsvalue, NULL)) AS '1', AVG(IF(month(obsDatetime) = 2, obsvalue, NULL)) AS '2', AVG(IF(month(obsDatetime) = 3, obsvalue, NULL)) AS '3',AVG(IF(month(obsDatetime) = 4, obsvalue, NULL)) AS '4', AVG(IF(month(obsDatetime) = 5, obsvalue, NULL)) AS '5', AVG(IF(month(obsDatetime) = 6, obsvalue, NULL)) AS '6',
                AVG(IF(month(obsDatetime) = 7, obsvalue, NULL)) AS '7',AVG(IF(month(obsDatetime) = 8, obsvalue, NULL)) AS '8', AVG(IF(month(obsDatetime) = 9, obsvalue, NULL)) AS '9', AVG(IF(month(obsDatetime) = 10, obsvalue, NULL)) AS '10', AVG(IF(month(obsDatetime) = 11, obsvalue, NULL)) AS '11',AVG(IF(month(obsDatetime) = 12, obsvalue, NULL)) AS '12'
                from observationfinal
                where (describedBy = '" & TMPMAX & "' or describedBy = '" & TMPMIN & "' or describedBy = '" & TMPMN & "' or describedBy = '" & PRESST & "' or describedBy = '" & VAPPSR & "' or describedBy = '" & PRESSL & "' or describedBy = '" & GPM & "') and (" & lst & ") and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " 
                Group by stn,code;"
        'MsgBox(sql)
        Try
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()
            'MsgBox("Normals for Temperatures, Pressures computed")
            lstMessages.Items.Add("Normals for Temperatures, Pressures computed")
            lstMessages.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

        ' Compute Precipitation Quintiles
        Try
            sql = "DROP TABLE IF EXISTS PrecipQuintiles;
                   CREATE TABLE PrecipQuintiles Select stn,mm,Total
                   From (select recordedFrom as stn, year(obsDatetime) as yy, month(obsDatetime) as mm,SUM(obsvalue) as Total from observationfinal
                   where (" & lst & ") and describedBy = '" & PRECIP & "' and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " group by stn,yy,mm order by stn,mm) as TT Order by stn, mm,Total;"
            'MsgBox(sql)
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()
            'MsgBox("Precipitation Quintiles computed")
            lstMessages.Items.Add("Precipitation Quintiles computed")
            lstMessages.Refresh()

            ''Compute years available to compute Normals
            'sql = "Select stn,
            '        COUNT(IF(code = 4, code, NULL)) AS 'yrsTmn',COUNT(IF(code = 2, code, NULL)) AS 'yrsXTemp',
            '        COUNT(IF(code = 106, code, NULL)) AS 'yrsPress', COUNT(IF(code = 166, code, NULL)) AS 'yrsVPress',
            '        COUNT(IF(code = 5, code, NULL)) AS 'YrsPrecip', COUNT(IF(code = 84, code, NULL)) AS 'yrsSUNhrs'
            '        from (select recordedFrom as stn,describedBy as code,year(obsDatetime) as yy,month(obsDatetime) as mm from observationfinal
            '        where (describedBy = '2' or describedBy = '4' or describedBy = '106' or describedBy = '166' or describedBy = '5' or describedBy = '84') and (" & lst & ")
            '        and month(obsDatetime) = " & txtMonth.Text & " and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " group by stn,code, yy) as TT
            '        group by stn;"


            'conn.Open()
            'qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            'qry.CommandTimeout = 0

            ''Execute query
            'qry.ExecuteNonQuery()
            'conn.Close()

            ''MsgBox("Total years for Normals computed")
            'lstMessages.Items.Add("Total years for Normals computed")
            'lstMessages.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub butEncode_Click(sender As Object, e As EventArgs) Handles butEncode.Click
        Dim stn, Section0, Section1_data, Section2_data, Section3_data, Section4_data As String

        ' Ensure all input is ok
        If txtMonth.Text = "" Or txtYear.Text = "" Or lstvStations.Items.Count = 0 Then
            MsgBox("All required input not provided")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            lstMessages.Items.Clear()
            With lstvStations
                Section0 = "CLIMAT " & txtMonth.Text.PadLeft(2, "0") & Strings.Right(txtYear.Text, 3)
                lstMessages.Items.Add(Section0)
                For i = 0 To .Items.Count - 1
                    stn = .Items(i).SubItems(0).Text

                    Section1(stn, Section1_data)
                    lstMessages.Items.Add(wmoId(stn) & " " & Section1_data)

                    If Section1_data = "NIL" Then Continue For ' Exclude all other sections when there's no data for Section 1 in missing in the same stion
                    Section2_data = Section2(stn)
                    Section3_data = Section3(stn)
                    Section4_data = Section4(stn)
                    If chk222.Checked And Section2_data <> "" Then lstMessages.Items.Add(Section2_data)
                    If chk333.Checked And Section3_data <> "" Then lstMessages.Items.Add("333" & Section3_data)
                    If chk444.Checked And Section4_data <> "" Then lstMessages.Items.Add("444" & Section4_data)
                Next
                lstMessages.Items.Add("=")

                ' output the message to a file
                Dim Fl As String
                Fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\climat" & txtMonth.Text.PadLeft(2, "0") & txtYear.Text & ".a"
                FileOpen(5, Fl, OpenMode.Output)
                For i = 0 To lstMessages.Items.Count - 1
                    PrintLine(5, lstMessages.Items(i))
                Next
                FileClose(5)
                txtCLIMAT.Text = Fl
            End With
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Function wmoId(stnId As String) As String

        sql = "select wmoid from station where stationId = '" & stnId & "';"

        Try
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "stnId")
            conn.Close()

            If ds.Tables("stnId").Rows.Count > 0 Then
                Return ds.Tables("stnId").Rows(0).Item("wmoId")
            Else
                Return ""
            End If

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return ""
        End Try

    End Function

    Sub Section1(stn As String, ByRef dat As String)
        Dim Group1, Group2, Group3, Group4, Group5, Group6, Group7, Group8, Group9 As String
        Try
            '            sql = "SELECT recordedFrom as StationId,year(obsDatetime) as YY,month(obsDatetime) as MM,
            'AVG(IF(describedBy = '4', value, NULL)) AS 'Tmn', COUNT(IF(describedBy = '4', value, NULL)) AS 'DysTmn', STD(IF(describedBy = '4', value, NULL)) AS 'STDTmn',
            'AVG(IF(describedBy = '2', value, NULL)) AS 'Tmax', COUNT(IF(describedBy = '2', value, NULL)) AS 'DysTmax',
            'AVG(IF(describedBy ='3', value, NULL)) AS 'Tmin', COUNT(IF(describedBy = '3', value, NULL)) AS 'DysTmin',
            'AVG(IF(describedBy ='106', value, NULL)) AS 'STPres', COUNT(IF(describedBy = '106', value, NULL)) AS 'DysPres',
            'AVG(IF(describedBy ='107', value, NULL)) AS 'MSL', AVG(IF(describedBy = '478', value, NULL)) AS 'GPM',
            'AVG(IF(describedBy ='166', value, NULL)) AS 'VPres', COUNT(IF(describedBy = '166', value, NULL)) AS 'DysVpres',
            'SUM(IF(describedBy ='5', value, NULL)) AS 'Precip', COUNT(IF(describedBy = '5', value, NULL)) AS 'DysPrecip',
            'SUM(IF(describedBy ='84', value, NULL)) AS 'SNHRS', COUNT(IF(describedBy = '84', value, NULL)) AS 'DysSNHRS'
            'FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal
            'WHERE (RecordedFrom = '" & stn & "') AND (describedBy ='4' OR describedBy ='2' OR describedBy ='3' OR describedBy ='5' OR describedBy ='84' OR describedBy ='106' OR describedBy ='107' OR describedBy ='166') and (year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & ") ORDER BY recordedFrom, obsDatetime) as tt 
            'GROUP BY StationId, MM;"

            sql = "SELECT recordedFrom as StationId,year(obsDatetime) as YY,month(obsDatetime) as MM,
AVG(IF(describedBy = '" & TMPMN & "', value, NULL)) AS 'Tmn', COUNT(IF(describedBy = '" & TMPMN & "', value, NULL)) AS 'DysTmn', STD(IF(describedBy = '" & TMPMN & "', value, NULL)) AS 'STDTmn',
AVG(IF(describedBy = '" & TMPMAX & "', value, NULL)) AS 'Tmax', COUNT(IF(describedBy = '" & TMPMAX & "', value, NULL)) AS 'DysTmax',
AVG(IF(describedBy = '" & TMPMIN & "', value, NULL)) AS 'Tmin', COUNT(IF(describedBy = '" & TMPMIN & "', value, NULL)) AS 'DysTmin',
AVG(IF(describedBy = '" & PRESST & "', value, NULL)) AS 'STPres', COUNT(IF(describedBy = '" & PRESSL & "', value, NULL)) AS 'DysPres',
AVG(IF(describedBy = '" & PRESSL & "', value, NULL)) AS 'MSL', AVG(IF(describedBy = '" & GPM & "', value, NULL)) AS 'GPM',
AVG(IF(describedBy = '" & VAPPSR & "', value, NULL)) AS 'VPres', COUNT(IF(describedBy = '" & VAPPSR & "', value, NULL)) AS 'DysVpres',
SUM(IF(describedBy = '" & PRECIP & "', value, NULL)) AS 'Precip', COUNT(IF(describedBy = '" & PRECIP & "', value, NULL)) AS 'DysPrecip',
SUM(IF(describedBy = '" & SUNSHN & "', value, NULL)) AS 'SNHRS', COUNT(IF(describedBy = '" & SUNSHN & "', value, NULL)) AS 'DysSNHRS'
FROM (SELECT recordedFrom, describedBy, obsDatetime, obsValue value FROM observationfinal
WHERE (RecordedFrom = '" & stn & "') AND (describedBy ='" & TMPMN & "' OR describedBy ='" & TMPMAX & "' OR describedBy ='" & TMPMIN & "' OR describedBy ='" & PRECIP & "' OR describedBy ='" & SUNSHN & "' OR describedBy ='" & PRESST & "' OR describedBy ='" & PRESSL & "' OR describedBy ='" & VAPPSR & "') and (year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & ") ORDER BY recordedFrom, obsDatetime) as tt 
GROUP BY StationId, MM;"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "values")
            conn.Close()
            'MsgBox(sql)
            'MsgBox(ds.Tables("values").Rows.Count)
            dat = ""
            Group1 = "111" & Section1_Group1(ds) ' Compute data for Group1
            Group2 = Section1_Group2(ds)
            Group3 = Section1_Group3(ds)
            Group4 = Section1_Group4(ds)
            Group5 = Section1_Group5(ds)
            Group6 = Section1_Group6(stn)
            Group7 = Section1_Group7(ds)
            Group8 = Section1_Group8(stn, ds)
            Group9 = Section1_Group9(stn, ds)
            dat = Group1 & Group2 & Group3 & Group4 & Group5 & Group6 & Group7 & Group8 & Group9

            If dat = "111" Then dat = "NIL"
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub


    Function Section1_Group1(rs As DataSet) As String
        Dim stnPRESS As String

        ' Compute Pressure at station
        stnPRESS = ""
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("STPres")) Then
                        stnPRESS = Math.Round(Val(.Rows(0).Item("STPres")), 1) * 10
                        If Len(stnPRESS) > 4 Then stnPRESS = Strings.Right(stnPRESS, 4)
                    Else
                        stnPRESS = ""
                    End If
                End If
            End With
            If stnPRESS = "" Then Return ""
            Return " 1" & stnPRESS
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group2(rs As DataSet) As String
        Dim dat As String

        ' Compute Mean Sea Level (MSL) ressure or the GPM whichever is available
        dat = ""
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("MSL")) Then
                        dat = Math.Round(Val(.Rows(0).Item("MSL")), 1) * 10
                        If Len(dat) > 4 Then dat = Strings.Right(dat, 4)
                    ElseIf Not IsDBNull(.Rows(0).Item("GPM")) Then
                        dat = Math.Round(Val(.Rows(0).Item("MSL")), 0)
                        dat = dat.PadLeft(4, "0")
                    End If
                Else
                    dat = ""
                End If
            End With
            If dat = "" Then Return ""
            Return " 2" & dat
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Function Section1_Group3(rs As DataSet) As String
        Dim Tmean, STDEV, sign As String

        ' Compute mean monthly temperature and standard deviation
        Tmean = "///"
        STDEV = "///"
        sign = "0"
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("Tmn")) Then
                        Tmean = Math.Round(Val(.Rows(0).Item("Tmn")), 1) * 10
                        Tmean = Tmean.PadLeft(3, "0")
                        If Val(Tmean) < 0 Then sign = "1"
                        Tmean = sign & Tmean
                    End If
                    If Not IsDBNull(.Rows(0).Item("STDTmn")) Then
                        STDEV = Math.Round(Val(.Rows(0).Item("STDTmn")), 1) * 10
                        STDEV = STDEV.PadLeft(3, "0")
                    End If
                End If

            End With
            If Tmean = "///" And STDEV = "///" Then Return ""
            Return " 3" & Tmean & STDEV
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group4(rs As DataSet) As String
        Dim Tmax, Tmin, Txsign, Tnsign As String
        Dim Txmiss, Tnmiss As Integer
        ' Compute Tmax and Tmin
        Tmax = "///"
        Tmin = "///"
        Txsign = "0"
        Tnsign = "0"
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("Tmax")) Then
                        Txmiss = DaysMissing(Val(.Rows(0).Item("DysTmax")))
                        If Txmiss < 10 Then  ' Less than days missing is acceptable
                            Tmax = Math.Round(Val(.Rows(0).Item("Tmax")), 1) * 10
                            Tmax = Tmax.PadLeft(3, "0")
                            If Val(Tmax) < 0 Then Txsign = "1"
                            Tmax = Txsign & Tmax
                        Else
                            Tmax = "////"
                        End If
                    End If

                    If Not IsDBNull(.Rows(0).Item("Tmin")) Then
                        Tnmiss = DaysMissing(Val(.Rows(0).Item("DysTmin")))
                        If Tnmiss < 10 Then  ' Less than days missing is acceptable
                            Tmin = Math.Round(Val(.Rows(0).Item("Tmin")), 1) * 10
                            Tmin = Tmin.PadLeft(3, "0")
                            If Val(Tmin) < 0 Then Txsign = "1"
                            Tmin = Tnsign & Tmin
                        Else
                            Tmin = "////"
                        End If
                    End If
                End If
            End With
            If Tmax = "///" And Tmin = "///" Then Return ""
            Return " 4" & Tmax & Tmin
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group5(rs As DataSet) As String
        Dim VPRESS As String

        ' Compute Vapour Pressure
        VPRESS = ""
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("VPres")) Then
                        VPRESS = Math.Round(Val(.Rows(0).Item("VPres")), 1) * 10
                        VPRESS = VPRESS.PadLeft(3, "0")
                    End If
                End If
            End With
            If VPRESS = "" Then Return ""
            Return " 5" & VPRESS
        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group6(stn As String) As String ' Precipitation data
        Dim MonVal, Total, Quintile, dys As String
        Dim Q As Integer
        Dim da6 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds6 As New DataSet

        Try
            ' Compute Precipitation equivalent for the month
            sql = "Select recordedFrom As stn, year(obsDatetime) As yy, month(obsDatetime) As mm, SUM(obsvalue) As Total from observationfinal
               where(recordedFrom = '" & stn & "') and describedBy = '" & PRECIP & "' and year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & " group by yy;"

            conn.Open()
            da6 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da6.SelectCommand.CommandTimeout = 0
            ds6.Clear()
            da6.Fill(ds6, "Precip")
            conn.Close()

            If ds6.Tables("Precip").Rows.Count > 0 Then
                MonVal = ds6.Tables("Precip").Rows(0).Item("Total")
                Total = Math.Round(Val(MonVal), 0)
                If Val(Total) >= 8899 Then Total = 8899
                If Val(Total) < 1 And Val(Total) > 0 Then Total = 9999
                Total = Total.PadLeft(4, "0")
            Else
                Return ""
            End If

            ' Compute the Quintile for the monthly value
            'sql = "Select stn,mm,Total From (select recordedFrom as stn, year(obsDatetime) as yy, month(obsDatetime) as mm,SUM(obsvalue) as Total from observationfinal
            '       where (recordedFrom = '" & stn & "') and describedBy = 5 and month(obsDatetime) =  " & txtMonth.Text & " and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " group by stn,yy,mm order by stn,mm) as TT Order by stn, mm,Total;"

            sql = "select * from PrecipQuintiles where stn = '" & stn & "' and mm = " & txtMonth.Text & ";"

            conn.Open()
            da6 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da6.SelectCommand.CommandTimeout = 0
            ds6.Clear()
            da6.Fill(ds6, "Quintile")
            conn.Close()

            If ds6.Tables("Quintile").Rows.Count >= 30 Then
                If Val(MonVal) > Val(ds6.Tables("Quintile").Rows(29).Item("Total")) Then
                    Q = 6
                ElseIf Val(MonVal) = 0 And Val(ds6.Tables("Quintile").Rows(29).Item("Total")) = 0 Then
                    Q = 6
                Else
                    Q = 0
                    For i = 0 To 29
                        If Val(ds6.Tables("Quintile").Rows(i).Item("Total")) > Val(MonVal) Then Exit For
                        Q = Int(i / 6) + 1
                    Next
                End If
                Quintile = Q
            Else
                Quintile = "/"
            End If


            ' Compute number of days with precipitation ≥1.0 mm
            sql = "select recordedFrom as stn, year(obsDatetime) as yy, month(obsDatetime) as mm, COUNT(obsvalue) as Days from observationfinal
               where (recordedFrom = '" & stn & "') and describedBy = '" & PRECIP & "' and obsvalue >= 1 and year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & " group by yy,mm;"

            conn.Open()
            da6 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da6.SelectCommand.CommandTimeout = 0
            ds6.Clear()
            da6.Fill(ds6, "Dys")
            conn.Close()

            If ds6.Tables("Dys").Rows.Count > 0 Then
                dys = ds6.Tables("Dys").Rows(0).Item("Days")
                dys = dys.PadLeft(2, "0")
            Else
                dys = "00"
            End If

            Return " 6" & Total & Quintile & dys
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group7(rs As DataSet) As String
        Dim SUNhrs, Perctg As String

        ' Compute Sunshine hours
        SUNhrs = "///"
        Perctg = "///"
        Try
            With rs.Tables("values")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("SNHRS")) Then
                        SUNhrs = Math.Round(Val(.Rows(0).Item("SNHRS")), 0)
                        SUNhrs = SUNhrs.PadLeft(3, "0")
                    End If
                End If
            End With
            If SUNhrs = "///" Then Return ""

            SNHRPercent(SUNhrs, Perctg)
            Return " 7" & SUNhrs & Perctg
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "" '& SUNhrs & Perctg
        End Try
    End Function
    Function Section1_Group8(stn As String, rs As DataSet) As String
        Dim Press, Tmean, Tmax, Tmin As String

        ' Compute Missing days for Pressure, Tmean, Tmax, Tmin
        'Press = "//"
        'Tmean = "//"
        'Tmax = "/"
        'Tmin = "/"

        Try

            Press = DaysMissing(DaysAvailable(stn, PRESST))
            Tmean = DaysMissing(DaysAvailable(stn, TMPMN))
            Tmax = DaysMissing(DaysAvailable(stn, TMPMAX))
            Tmin = DaysMissing(DaysAvailable(stn, TMPMIN))

            If Val(Tmax) > 8 Then Tmax = 9
            If Val(Tmin) > 8 Then Tmin = 9

            'If Press = "//" And Tmean = "//" And Tmax = "//" And Tmin = "//" Then Return ""
            Return " 8" & Press & Tmean & Tmax & Tmin

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function Section1_Group9(stn As String, rs As DataSet) As String
        Dim VPress, Precp, SunHrs As String

        ' Compute Missing days for Vapour Pressure, Tmean, Tmax, Tmin
        'VPress = "//"
        'Precip = "//"
        'SunHrs = "//"
        Try
            VPress = DaysMissing(DaysAvailable(stn, VAPPSR))
            Precp = DaysMissing(DaysAvailable(stn, PRECIP))
            SunHrs = DaysMissing(DaysAvailable(stn, SUNSHN))

            'If VPress = "//" And Precp = "//" And SunHrs = "//" Then Return ""
            Return " 9" & VPress & Precp & SunHrs

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function
    Function SNHRPercent(Vhrs As String, ByRef perc As String) As Boolean
        Dim da7 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds7 As New DataSet
        Dim mm As Integer
        Dim Nhrs As String

        Try
            sql = "select * from normals_Totals where code = " & SUNSHN & ";"

            conn.Open()
            da7 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da7.SelectCommand.CommandTimeout = 0
            ds7.Clear()
            da7.Fill(ds7, "SUNHRS")
            conn.Close()

            perc = "///"
            mm = CInt(txtMonth.Text) + 1
            With ds7.Tables("SUNHRS")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item(mm)) Then
                        Nhrs = .Rows(0).Item(mm)
                        If Val(Nhrs) <> 0 Then
                            perc = (Val(Vhrs) / Val(Nhrs)) * 100
                            perc = Math.Round(Val(perc), 0)
                            perc = perc.PadLeft(3, "0")
                        End If
                    End If
                End If
            End With
            Return True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Function DaysAvailable(stn As String, code As Integer) As Integer
        Dim daDys As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsDys As New DataSet

        sql = "Select stn,describedBy,yy,mm, COUNT(IF(describedBy = '" & code & "', value, NULL)) AS 'Dys'
                   From (SELECT recordedFrom as stn, describedBy, year(obsDatetime) as yy, month(obsDatetime) as mm, day(obsDatetime) as dd, AVG(obsValue) as value
                   FROM observationfinal
                   WHERE (RecordedFrom = '" & stn & "') AND describedBy ='" & code & "' and year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & "
                   group by yy,describedBy,mm,dd) as TT
                   Group by yy, mm;"
        Try
            conn.Open()
            daDys = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            daDys.SelectCommand.CommandTimeout = 0
            dsDys.Clear()
            daDys.Fill(dsDys, "AvlDys")
            conn.Close()

            With dsDys.Tables("AvlDys")
                If .Rows.Count > 0 Then
                    Return .Rows(0).Item("Dys")
                Else
                    Return 0
                End If
            End With

        Catch ex As Exception
            Return 0
        End Try

    End Function

    Function DaysMissing(AvalDays As Integer) As Integer
        Dim Tmissing As Integer
        Tmissing = 0

        Try
            Tmissing = DateTime.DaysInMonth(CInt(txtYear.Text), CInt(txtMonth.Text)) - AvalDays
            Return Tmissing

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Tmissing
        End Try
    End Function

    Function DaysMissHlyObs(stn As String, ByRef Press As String, ByRef Vpress As String) As Boolean
        Dim da0 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds0 As New DataSet

        sql = "Select stn, yy,mm,
                COUNT(IF(describedBy = '" & PRESST & "', value, NULL)) AS 'DysPres', 
                COUNT(IF(describedBy = '" & VAPPSR & "', value, NULL)) AS 'DysVpres'
                From (SELECT recordedFrom as stn, describedBy, year(obsDatetime) as yy, month(obsDatetime) as mm, day(obsDatetime) as dd, AVG(obsValue) as value
                FROM observationfinal
                WHERE (RecordedFrom = '" & stn & "') AND (describedBy ='" & PRESST & "' OR describedBy ='" & VAPPSR & "') and year(obsDatetime) = " & Val(txtYear.Text) & " and month(obsDatetime) = " & Val(txtMonth.Text) & " 
                group by yy,describedBy,mm,dd) as TT
                Group by yy, mm;"

        Try
            conn.Open()
            da0 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da0.SelectCommand.CommandTimeout = 0
            ds0.Clear()
            da0.Fill(ds0, "HlyMiss")
            conn.Close()

            With ds0.Tables("HlyMiss")
                If .Rows.Count > 0 Then

                    If Not IsDBNull(.Rows(0).Item("DysPres")) Then
                        Press = DaysMissing(Val(.Rows(0).Item("DysPres")))
                    Else
                        Press = DaysMissing(0)
                    End If
                    Press = Press.PadLeft(2, "0")

                    If Not IsDBNull(.Rows(0).Item("DysVpres")) Then
                        Vpress = DaysMissing(Val(.Rows(0).Item("DysVpres")))
                    Else
                        Vpress = DaysMissing(0)
                    End If
                    Vpress = Vpress.PadLeft(2, "0")

                End If
            End With

            Return True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message & " at DaysMissHlyObs")
            Return False
        End Try
    End Function

    Function Section2(stn As String) As String
        Dim nPress, nMSL, nTmn, nSTDTmn, nTmax, nTmin, nVPress, nPrecip, nDysPrecip, nSUNhrs, dat As String
        Dim yrsPress, yrsTmn, yrsTX, yrsVpress, yrsPrecip, yrsSUNhrs, mm As String
        Dim yrs As Integer

        'Section2_data = ""
        mm = CInt(txtMonth.Text) '+ 1
        yrs = Val(txtEndYear.Text) - Val(txtBeginYear.Text) + 1
        nPress = "////"
        nMSL = "////"
        nTmn = "///"
        nTmax = "///"
        nTmin = "///"
        nVPress = "///"
        nPrecip = "////"
        nSUNhrs = "///"

        If yrs < 30 Then
            MsgBox("Insuficient base period for Normal computations")
            Return ""
        End If


        ' Get Normals for those values that are averaged namely Pressure, Temperatures and Standard deviation
        sql = "select * from normals_averages where stn = '" & stn & "';"

        Try
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "AvgNormals")
            conn.Close()

            With ds.Tables("AvgNormals")
                For i = 0 To .Rows.Count - 1
                    If IsDBNull(.Rows(i).Item(mm)) Then Exit For
                    dat = .Rows(i).Item(mm)
                    If .Rows(i).Item("code") = PRESST Then nPress = dat
                    If .Rows(i).Item("code") = PRESSL Then nMSL = dat
                    If .Rows(i).Item("code") = VAPPSR Then nVPress = dat
                    If .Rows(i).Item("code") = TMPMN Then nTmn = dat
                    If .Rows(i).Item("code") = TMPMAX Then nTmax = dat
                    If .Rows(i).Item("code") = TMPMIN Then nTmin = dat
                Next
            End With

            ' Get Normals for those values that are summed up namely Precipitation and Sunshine hours
            sql = "select * from normals_Totals where stn = '" & stn & "';"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "SumNormals")
            conn.Close()

            With ds.Tables("SumNormals")
                For i = 0 To .Rows.Count - 1
                    If IsDBNull(.Rows(i).Item(mm)) Then Exit For
                    dat = .Rows(i).Item(mm)
                    If .Rows(i).Item("code") = PRECIP Then nPrecip = dat
                    If .Rows(i).Item("code") = SUNSHN Then nSUNhrs = dat
                Next
            End With

            'Get Normal Number of days per month with precipitation           '
            sql = "Select stn,mm, AVG(Days) As Total from
                    (select recordedFrom as stn, year(obsDatetime) as yy, month(obsDatetime) as mm, COUNT(obsvalue) as Days from observationfinal
                    where (recordedFrom = '" & stn & "') and describedBy = '" & PRECIP & "' and obsvalue >= 1 and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " and month(obsDatetime)= " & txtMonth.Text & " group by stn,yy,mm) as TT
                    group by stn,mm;"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "nDysPrecip")
            conn.Close()

            With ds.Tables("nDysPrecip")
                If .Rows.Count > 0 Then
                    nDysPrecip = .Rows(0).Item("Total")
                Else
                    nDysPrecip = "//"
                End If
            End With

            ' Get Years in Normal computations
            sql = "Select stn,
                    COUNT(IF(code = " & TMPMN & ", code, NULL)) AS 'yrsTmn',COUNT(IF(code = " & TMPMAX & ", code, NULL)) AS 'yrsXTemp',
                    COUNT(IF(code = " & PRESST & ", code, NULL)) AS 'yrsPress', COUNT(IF(code = " & VAPPSR & ", code, NULL)) AS 'yrsVPress',
                    COUNT(IF(code = " & PRECIP & ", code, NULL)) AS 'YrsPrecip', COUNT(IF(code = " & SUNSHN & ", code, NULL)) AS 'yrsSUNhrs'
                    from (select recordedFrom as stn,describedBy as code,year(obsDatetime) as yy,month(obsDatetime) as mm from observationfinal
                    where (describedBy = '" & TMPMAX & "' or describedBy = '" & TMPMN & "' or describedBy = '" & PRESST & "' or describedBy = '" & VAPPSR & "' or describedBy = '" & PRECIP & "' or describedBy = '" & SUNSHN & "') and recordedFrom ='" & stn & "'
                    and month(obsDatetime) = " & txtMonth.Text & " and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & " group by stn,code, yy) as TT
                    group by stn;"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "NormalsYears")
            conn.Close()

            With ds.Tables("NormalsYears")
                If .Rows.Count > 0 Then
                    yrsPress = yrs - Val(.Rows(0).Item("yrsPress"))
                    yrsTmn = yrs - Val(.Rows(0).Item("yrsTmn"))
                    yrsTX = yrs - Val(.Rows(0).Item("yrsXTemp"))
                    yrsVpress = yrs - Val(.Rows(0).Item("yrsVpress"))
                    yrsPrecip = yrs - Val(.Rows(0).Item("yrsPrecip"))
                    yrsSUNhrs = yrs - Val(.Rows(0).Item("yrsSUNhrs"))
                Else
                    yrsPress = "//"
                    yrsTmn = "//"
                    yrsTX = "//"
                    yrsVpress = "//"
                    yrsPrecip = "//"
                    yrsSUNhrs = "//"
                End If
            End With

            ' Get standard deviation for mean temperature
            sql = "Select recordedFrom As stn, describedBy As code,  month(obsDatetime) as mm, STD(If(describedBy = 4, obsvalue, NULL)) As stdev from observationfinal
                    where (recordedFrom ='" & stn & "') and describedBy = '" & TMPMN & "' and month(obsDatetime)= " & txtMonth.Text & " and year(obsDatetime) between " & txtBeginYear.Text & " and " & txtEndYear.Text & "
                    group by stn, code,mm;"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "TmnSTD")
            conn.Close()

            With ds.Tables("TmnSTD")
                If .Rows.Count > 0 Then
                    If Not IsDBNull(.Rows(0).Item("stdev")) Then nSTDTmn = .Rows(0).Item("stdev")
                    'nSTDTmn = .Rows(0).Item("stdev")
                Else
                    nSTDTmn = "///"
                End If
            End With

            ' Compile data for Section 2
            Dim sgn, Group0, Group1, Group2, Group3, Group4, Group5, Group6, Group7, Group8, Group9 As String

            'Group0
            Group0 = "0" & Strings.Right(txtBeginYear.Text, 2) & Strings.Right(txtEndYear.Text, 2)

            'Group1
            If IsNumeric(nPress) Then nPress = Math.Round(Val(nPress) * 10, 0)
            Group1 = " 1" & Strings.Right(nPress, 4)
            If nPress = "////" Then Group1 = ""

            'Group2
            If IsNumeric(nMSL) Then nMSL = Math.Round(Val(nMSL) * 10, 0)
            Group2 = " 2" & Strings.Right(nMSL, 4)
            If nMSL = "////" Then Group2 = ""

            'Group3
            sgn = "0"
            If IsNumeric(nTmn) Then
                nTmn = Math.Round(Val(nTmn) * 10, 0)
                If Val(nTmn) < 0 Then sgn = "1"
            Else
                sgn = "/"
            End If
            nTmn = nTmn.PadLeft(3, "0")

            nSTDTmn = Math.Round(Val(nSTDTmn) * 10, 0)
            nSTDTmn = nSTDTmn.PadLeft(3, "0")

            Group3 = " 3" & sgn & nTmn & nSTDTmn
            If nTmn = "///" Then Group3 = ""

            'Group4
            sgn = "0"
            If IsNumeric(nTmax) Then
                nTmax = Math.Round(Val(nTmax) * 10, 0)
                If Val(nTmax) < 0 Then sgn = "1"
            Else
                sgn = "/"
            End If
            nTmax = sgn & nTmax.PadLeft(3, "0")

            sgn = "0"
            If IsNumeric(nTmin) Then
                nTmin = Math.Round(Val(nTmin) * 10, 0)
                If Val(nTmin) < 0 Then sgn = "1"
            Else
                sgn = "/"
            End If
            nTmin = sgn & nTmin.PadLeft(3, "0")
            Group4 = " 4" & nTmax & nTmin
            If nTmax & nTmin = "////////" Then Group4 = ""

            'Group5
            If IsNumeric(nVPress) Then
                nVPress = Math.Round(Val(nVPress) * 10, 0)
                nVPress = nVPress.PadLeft(3, "0")
            End If
            Group5 = " 5" & nVPress.PadLeft(3, "0")
            If nVPress = "///" Then Group5 = ""

            'Group6
            If IsNumeric(nPrecip) Then
                nPrecip = Math.Round(Val(nPrecip), 0)
                nPrecip = nPrecip.PadLeft(4, "0")
            End If
            If Val(nPrecip) > 8898 Then nPrecip = "9999"

            If IsNumeric(nDysPrecip) Then
                nDysPrecip = Math.Round(Val(nDysPrecip), 0)
                nDysPrecip = nDysPrecip.PadLeft(2, "0")
            End If
            Group6 = " 6" & nPrecip & nDysPrecip
            If nPrecip = "////" Then Group6 = ""

            'Group7
            If IsNumeric(nSUNhrs) Then
                nSUNhrs = Math.Round(Val(nSUNhrs), 0)
                nSUNhrs = nSUNhrs.PadLeft(3, "0")
            End If
            Group7 = " 7" & nSUNhrs
            If nSUNhrs = "///" Then Group7 = ""

            'Group8
            yrsPress = yrsPress.PadLeft(2, "0")
            yrsTmn = yrsTmn.PadLeft(2, "0")
            yrsTX = yrsTX.PadLeft(2, "0")
            Group8 = " 8" & yrsPress & yrsTX & yrsTX
            If yrsPress & yrsTX & yrsTX = "//////" Then Group8 = ""

            'Group9
            yrsVpress = yrsVpress.PadLeft(2, "0")
            yrsPrecip = yrsPrecip.PadLeft(2, "0")
            yrsSUNhrs = yrsSUNhrs.PadLeft(2, "0")
            Group9 = " 9" & yrsVpress & yrsPrecip & yrsSUNhrs
            If yrsVpress & yrsPrecip & yrsSUNhrs = "//////" Then Group9 = ""

            dat = "222 " & Group0 & Group1 & Group2 & Group3 & Group4 & Group5 & Group6 & Group7 & Group8 & Group9
            If dat = "222 " Then Return ""

            Return dat

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Function Section3(stn As String) As String
        Dim dat, Group0, Group1, Group2, Group3, Group4, Group5, Group6, Group7, Group8, Group9 As String
        dat = ""
        Try
            Group0 = Days4ParamentersBeyond(stn, TMPMAX, ">= 25")
            Group0 = Group0 & Days4ParamentersBeyond(stn, TMPMAX, ">= 30")
            If Group0 <> "0000" Then dat = dat & " 0" & Group0

            Group1 = Days4ParamentersBeyond(stn, TMPMAX, ">= 35")
            Group1 = Group1 & Days4ParamentersBeyond(stn, TMPMAX, ">= 40")
            If Group1 <> "0000" Then dat = dat & " 1" & Group1

            Group2 = Days4ParamentersBeyond(stn, TMPMAX, "< 0")
            Group2 = Group2 & Days4ParamentersBeyond(stn, TMPMIN, "< 0")
            If Group2 <> "0000" Then dat = dat & " 3" & Group2

            Group3 = Days4ParamentersBeyond(stn, PRECIP, ">= 1")
            Group3 = Group3 & Days4ParamentersBeyond(stn, PRECIP, ">= 5")
            If Group3 <> "0000" Then dat = dat & " 3" & Group3

            Group4 = Days4ParamentersBeyond(stn, PRECIP, ">= 10")
            Group4 = Group4 & Days4ParamentersBeyond(stn, PRECIP, ">= 50")
            If Group4 <> "0000" Then dat = dat & " 4" & Group4

            Group5 = Days4ParamentersBeyond(stn, PRECIP, ">= 100")
            Group5 = Group5 & Days4ParamentersBeyond(stn, PRECIP, ">= 150")
            If Group5 <> "0000" Then dat = dat & " 5" & Group5

            Group6 = Days4ParamentersBeyond(stn, SNWDEP, "> 0")
            Group6 = Group6 & Days4ParamentersBeyond(stn, SNWDEP, ">= 1")
            If Group6 <> "0000" Then dat = dat & " 6" & Group6

            Group7 = Days4ParamentersBeyond(stn, SNWDEP, ">= 10")
            Group7 = Group7 & Days4ParamentersBeyond(stn, SNWDEP, ">= 50")
            If Group7 <> "0000" Then dat = dat & " 7" & Group7

            Group8 = Days4ParamentersBeyond(stn, WNDSPD, ">= 10")
            Group8 = Group8 & Days4ParamentersBeyond(stn, WNDSPD, ">= 20")
            Group8 = Group8 & Days4ParamentersBeyond(stn, WNDSPD, ">= 30")
            If Group8 <> "000000" Then dat = dat & " 8" & Group8

            Group9 = Days4ParamentersBeyond(stn, VISBY, "< 50")
            Group9 = Group9 & Days4ParamentersBeyond(stn, VISBY, "< 100")
            Group9 = Group9 & Days4ParamentersBeyond(stn, VISBY, "< 1000")
            If Group9 <> "000000" Then dat = dat & " 9" & Group9

            Return dat '" 0" & Group0 & " 1" & Group1

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return dat
        End Try

    End Function

    Function Section4(stn As String) As String
        Dim dat, sgn, Group0, Group1, Group2, Group3, Group4, Group5, Group6, Group7, xtval, dys As String

        dat = ""
        Try
            ' Compute Group0
            Group0 = ""
            sgn = 0
            If ValAndDay(stn, "desc", TMPMIN, xtval, dys) Then
                If Val(xtval) < 0 Then sgn = 1
                xtval = xtval.PadLeft(3, "0")
                Group0 = sgn & xtval & dys
            Else
                Group0 = ""
            End If
            If Group0 <> "" Then dat = dat & " 0" & Group0

            ' Compute Group1
            Group1 = ""
            sgn = 0
            If ValAndDay(stn, "asc", TMPMIN, xtval, dys) Then
                If Val(xtval) < 0 Then sgn = 1
                xtval = xtval.PadLeft(3, "0")
                Group1 = sgn & xtval & dys
            Else
                Group1 = ""
            End If
            If Group1 <> "" Then dat = dat & " 1" & Group1

            ' Compute Group2
            Group2 = ""
            sgn = 0
            If ValAndDay(stn, "desc", TMPMAX, xtval, dys) Then
                If Val(xtval) < 0 Then sgn = 1
                xtval = xtval.PadLeft(3, "0")
                Group2 = sgn & xtval & dys
            Else
                Group2 = ""
            End If
            If Group2 <> "" Then dat = dat & " 2" & Group2

            ' Compute Group1
            Group3 = ""
            sgn = 0
            If ValAndDay(stn, "asc", TMPMIN, xtval, dys) Then
                If Val(xtval) < 0 Then sgn = 1
                xtval = xtval.PadLeft(3, "0")
                Group3 = sgn & xtval & dys
            Else
                Group3 = ""
            End If
            If Group3 <> "" Then dat = dat & " 3" & Group3

            ' Compute Group4
            Group4 = ""
            If ValAndDay(stn, "desc", PRECIP, xtval, dys) Then
                'MsgBox(sql)
                xtval = xtval.PadLeft(4, "0")
                Group4 = xtval & dys
            Else
                Group4 = ""
            End If
            If Group4 <> "" Then dat = dat & " 4" & Group4

            ' Compute Group5
            Group5 = ""
            If ValAndDay(stn, "desc", WNDSPD, xtval, dys) Then
                xtval = xtval.PadLeft(3, "0")
                Group5 = xtval & dys
            Else
                Group5 = ""
            End If
            If Group5 <> "" Then dat = dat & " 5" & InfoSourceIndicator() & Group5

            ' Compute Group6
            Group6 = ThunderHail(stn)
            If Group6 <> "////" Then dat = dat & " 6" & Group6

            'Compute Group7
            Group7 = StnType(stn)
            If Group7 <> "" Then dat = dat & " 7" & Group7

            Return dat

        Catch ex As Exception
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Function Days4ParamentersBeyond(stn As String, code As Integer, eqtn As String) As String
        Dim dys As String

        dys = "00"

        Try
            sql = "select COUNT(obsvalue) as Days from observationfinal
                   where recordedFrom ='" & stn & "' and (describedBy = " & code & ") and year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & "
                   And obsvalue " & eqtn & ";"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Tdays")
            conn.Close()

            dys = ds.Tables("Tdays").Rows(0).Item("Days")
            Return dys.PadLeft(2, "0")

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return dys
        End Try

    End Function

    Function ValAndDay(stn As String, sortOrder As String, code As Integer, ByRef xtVal As String, ByRef dy As String) As Boolean

        Try
            sql = "select obsvalue as value, day(obsDatetime) as dd from observationfinal where recordedFrom ='" & stn & "' and describedBy = " & code & " and year(obsDatetime) = " & Val(txtYear.Text) & " and month(obsDatetime)= " & Val(txtMonth.Text) & " order by value " & sortOrder & ";"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "XTvalues")
            conn.Close()

            With ds.Tables("XTvalues")
                If .Rows.Count > 0 Then
                    xtVal = .Rows(0).Item("value")
                    dy = .Rows(0).Item("dd")
                    If .Rows(1).Item("value") = xtVal Then dy = Val(dy) + 50
                    If code = PRECIP And Val(xtVal) = 0 Then dy = "0"

                    xtVal = Math.Round(Val(xtVal) * 10, 0)
                    dy = dy.PadLeft(2, "0")

                Else
                    Return False
                End If

            End With

            Return True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Function InfoSourceIndicator() As String
        Dim dat, info As String

        info = "/"

        Try
            sql = "select units from obselement where elementId = '" & WNDSPD & "';"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "Source")
            conn.Close()

            If ds.Tables("Source").Rows.Count > 0 Then
                dat = Strings.LCase(ds.Tables("Source").Rows(0).Item(0))
                If InStr("m/s", dat) > 0 Then info = "1"
                If InStr(dat, "knots") > 0 Then info = "4"
            End If

            Return info
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return info
        End Try
    End Function

    Function ThunderHail(stn As String) As String
        Dim dat, thnd, hail As String

        dat = "////"
        Try
            sql = "select COUNT(IF(describedBy = '" & DYTHND & "', obsvalue, NULL)) AS 'THND', COUNT(IF(describedBy = '" & DYHAIL & "', obsvalue, NULL)) AS 'HAIL' from observationfinal
                   where recordedFrom = '" & stn & "' and (describedBy= '" & DYTHND & "' or describedBy = '" & DYHAIL & "') and obsvalue = 1 and year(obsDatetime) = " & txtYear.Text & " and month(obsDatetime) = " & txtMonth.Text & ";"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "ThunderHail")
            conn.Close()

            With ds.Tables("ThunderHail")
                If .Rows.Count > 0 Then
                    thnd = .Rows(0).Item("THND")
                    hail = .Rows(0).Item("HAIL")

                    dat = thnd.PadLeft(2, "0") & hail.PadLeft(2, "0")
                End If
            End With

            Return dat

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return dat
        End Try
    End Function

    Function StnType(stn As String) As String
        Dim typ, TMx, TMn, dat As String

        typ = "1"
        TMx = "//"
        TMn = "//"

        Try
            sql = "select qualifier from station where qualifier ='AWS' and stationId='" & stn & " ';"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "StationTyp")
            conn.Close()

            If ds.Tables("StationTyp").Rows.Count > 0 Then typ = 2

            sql = "select AVG(IF(keyName ='key02', keyvalue, NULL)) AS 'Tmax', AVG(IF(keyName ='key01', keyvalue, NULL)) AS 'Tmin' from regkeys where keyName ='key01' or keyName = 'key02';"

            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "dysTxn")
            conn.Close()

            If ds.Tables("dysTxn").Rows.Count > 0 Then
                TMx = ds.Tables("dysTxn").Rows(0).Item("Tmax")
                TMn = ds.Tables("dysTxn").Rows(0).Item("Tmin")
            End If
            If TMx & TMn = "////" Then Return ""
            dat = typ & TMx.PadLeft(2, "0") & TMn.PadLeft(2, "0")

            Return dat

        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub chk222_CheckedChanged(sender As Object, e As EventArgs) Handles chk222.CheckedChanged
        If chk222.Checked Then
            If txtBeginYear.Text = "" Or txtEndYear.Text = "" Then
                MsgBox("Climate statistics base period required")
                chk222.Checked = False
            ElseIf Val(txtEndYear.Text) - Val(txtBeginYear.Text) < 29 Then
                MsgBox("Recommended base period is 30 years")
            Else
                chk222.Checked = True
            End If
        End If
    End Sub

    Private Sub butHelp_Click(sender As Object, e As EventArgs) Handles butHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "climateproducts.htm#CLIMAT")
    End Sub

    Private Sub ParametersToolStripMenuItem_Click(sender As Object, e As EventArgs)

        sql = "select * from climat_parameters order by Nos;"

        Dim climatds As New DataSet
        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim dbConnectionString As String

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = dbConnectionString
            conn.Open()

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            climatds.Clear()
            da.Fill(climatds, "climat_parameters")
            conn.Close()

            formDataView.Show()
            formDataView.DataGridView.DataSource = climatds.Tables(0)
            formDataView.DataGridView.Refresh()

            'formDataView.DataGridView.Dock = DockStyle.Top

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub butSetting_Click(sender As Object, e As EventArgs) Handles butSetting.Click
        Try
            frmClimatSettings.Show()

        Catch ex As Exception
            MsgBox(ex.Message & " " & ex.HResult)
        End Try
    End Sub
End Class