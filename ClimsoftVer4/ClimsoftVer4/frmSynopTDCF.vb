Public Class frmSynopTDCF
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim recUpdate As New dataEntryGlobalRoutines

    Dim ds As New DataSet
    Dim sql, msg_header, msg_file, mmm, Data_Description_Section, descriptors_file As String
    Dim rec, Kount As Integer


    Private Sub frmSynopTDCF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "CREATE TABLE IF NOT EXISTS `bufr_indicators` (`BUFR_Edition` int(11) DEFAULT '0',`Originating_Centre` int(11) DEFAULT '0',`Originating_SubCentre` int(11) DEFAULT '0',`Update_Sequence` int(11) DEFAULT '0',`Optional_Section` int(11) DEFAULT '0',`Data_Category` int(11) DEFAULT '0',`Intenational_Data_SubCategory` int(11) DEFAULT '0',`Local_Data_SubCategory` int(11) DEFAULT '0',`Master_table` int(11) DEFAULT '0',`Local_Table` int(11) DEFAULT '0') ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    End Sub

    Sub PopulateForms()
        Try
            ' Populate Settings
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            sql = "SELECT * FROM bufr_indicators"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "bufr_indicators")
            Kount = ds.Tables("bufr_indicators").Rows.Count

            ' Pulate the template list
            For i = 0 To Kount - 1
                cboTemplate.Items.Add(ds.Tables("bufr_indicators").Rows(i).Item("Tmplate"))
            Next
            ' populate with BUFR Indicators
            For i = 0 To Kount - 1

                If ds.Tables("bufr_indicators").Rows(i).Item("Tmplate") = cboTemplate.Text Then
                    txtBUFREditionNumber.Text = ds.Tables("bufr_indicators").Rows(i).Item("BUFR_Edition")
                    txtOriginatingGeneratingCentre.Text = ds.Tables("bufr_indicators").Rows(i).Item("Originating_Centre")
                    txtOriginatingGeneratingSubCentre.Text = ds.Tables("bufr_indicators").Rows(i).Item("Originating_SubCentre")
                    txtUpdateSequenceNumber.Text = ds.Tables("bufr_indicators").Rows(i).Item("Update_Sequence")
                    If ds.Tables("bufr_indicators").Rows(i).Item("Optional_Section") = 1 Then
                        chkOptionalSectionInclusion.Checked() = True
                    Else
                        chkOptionalSectionInclusion.Checked() = False
                    End If
                    txtDataCategory.Text = ds.Tables("bufr_indicators").Rows(i).Item("Data_Category")
                    txtInternationalDataSubCategory.Text = ds.Tables("bufr_indicators").Rows(i).Item("Intenational_Data_SubCategory")
                    txtLocalDataSubCategory.Text = ds.Tables("bufr_indicators").Rows(i).Item("Local_Data_SubCategory")
                    txtMastersTableVersionNumber.Text = ds.Tables("bufr_indicators").Rows(i).Item("Master_table")
                    txtLocalTableVersionNumber.Text = ds.Tables("bufr_indicators").Rows(i).Item("Local_Table")
                    txtMsgHeader.Text = ds.Tables("bufr_indicators").Rows(i).Item("Msg_Header")
                End If
            Next

            ' Populate with MSS details
            sql = "SELECT * FROM aws_mss"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "aws_mss")
            Kount = ds.Tables("aws_mss").Rows.Count
            For i = 0 To Kount - 1
                txtServer.Text = ds.Tables("aws_mss").Rows(i).Item("ftpId")
                cboFTP.Text = ds.Tables("aws_mss").Rows(i).Item("ftpMode")
                txtFolder.Text = ds.Tables("aws_mss").Rows(i).Item("inputFolder")
                txtLogin.Text = ds.Tables("aws_mss").Rows(i).Item("userName")
                txtPassword.Text = ds.Tables("aws_mss").Rows(i).Item("password")
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdSave_Click_1(sender As Object, e As EventArgs) Handles cmdNew.Click

        Dim sql As String
        Dim optsection As Integer

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            ' set value for the optional section
            If chkOptionalSectionInclusion.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "INSERT INTO bufr_indicators (Tmplate,Msg_Header,BUFR_Edition,Originating_Centre,Originating_SubCentre,Update_Sequence,Optional_Section,Data_Category,Intenational_Data_SubCategory,Local_Data_SubCategory,Master_table,Local_Table) VALUES('" & cboTemplate.Text & "','" & txtMsgHeader.Text & "','" & txtBUFREditionNumber.Text & "','" & txtOriginatingGeneratingCentre.Text & "','" & txtOriginatingGeneratingSubCentre.Text & "','" & txtUpdateSequenceNumber.Text & "','" & optsection & "','" & txtDataCategory.Text & "','" & txtInternationalDataSubCategory.Text & "','" & txtLocalDataSubCategory.Text & "','" & txtMastersTableVersionNumber.Text & "','" & txtLocalTableVersionNumber.Text & "');"

            'MsgBox(sql)

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()

    End Sub


    Private Sub TabProcessing_Click(sender As Object, e As EventArgs) Handles TabProcessing.Click
        If TabProcessing.SelectedTab.Name = "TabSettings" Then
            PopulateForms()
        End If

    End Sub


    Private Sub cmdUpadate_Click(sender As Object, e As EventArgs) Handles cmdUpadate.Click

        Dim sql As String
        Dim optsection As Integer

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            ' set value for the optional section
            If chkOptionalSectionInclusion.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "Update bufr_indicators set Msg_Header= '" & txtMsgHeader.Text & "',BUFR_Edition= '" & txtBUFREditionNumber.Text & "',Originating_Centre= '" & txtOriginatingGeneratingCentre.Text & "',Originating_SubCentre= '" & txtOriginatingGeneratingSubCentre.Text & "',Update_Sequence= '" & txtUpdateSequenceNumber.Text & "',Optional_Section= '" & optsection & "',Data_Category= '" & txtDataCategory.Text & "',Intenational_Data_SubCategory= '" & txtInternationalDataSubCategory.Text & "',Local_Data_SubCategory= '" & txtLocalDataSubCategory.Text & "',Master_table= '" & txtMastersTableVersionNumber.Text & "',Local_Table= '" & txtLocalTableVersionNumber.Text & _
                "' where tmplate= '" & cboTemplate.Text & "';"
            'MsgBox(sql)

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim CurrentServer As String

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            sql = "SELECT * FROM aws_mss"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "aws_mss")

            If ds.Tables("aws_mss").Rows.Count > 0 Then

                ' Update server details
                CurrentServer = ds.Tables("aws_mss").Rows(0).Item("ftpId")

                sql = "Update aws_mss set ftpId= '" & txtServer.Text & "',ftpMode= '" & cboFTP.Text & "',inputFolder= '" & txtFolder.Text & "',userName= '" & txtLogin.Text & "',password= '" & txtPassword.Text & _
                    "' where ftpId= '" & CurrentServer & "';"
                'MsgBox(sql)

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

                'Execute query
                objCmd.ExecuteNonQuery()
            Else
                ' Add new server details

                If txtConfirmPassword.Text <> txtPassword.Text Then ' Check if the new password has been confirmed 
                    MsgBox("Password not Confirmed. Please try again")
                    dbconn.Close()
                    Exit Sub
                End If

                sql = "INSERT INTO aws_mss (ftpId,ftpMode,inputFolder,userName,password)  VALUES('" & txtServer.Text & "','" & cboFTP.Text & "','" & txtFolder.Text & "','" & txtLogin.Text & "','" & txtPassword.Text & "');"
                'MsgBox(sql)

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

                'Execute query
                objCmd.ExecuteNonQuery()

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()
    End Sub

    Private Sub cmdEncode_Click(sender As Object, e As EventArgs) Handles cmdEncode.Click
        Dim tmplate, hr As String
        PopulateForms()

        Me.Cursor = Cursors.WaitCursor
        Try

            If cboStation.Text = "" Or txtYear.Text = "" Or cboMonth.Text = "" Or cboDay.Text = "" Or cboHour.Text = "" Then
                MsgBox("One or more values not entered, Please Confirm.", vbInformation, "Missing Value(s)")
                Exit Sub
            End If

            tmplate = cboTemplate.Text
            sql = "DROP TABLE IF EXISTS bufr_crex_data; CREATE TABLE bufr_crex_data AS SELECT " & tmplate & ".nos, " & tmplate & ".Bufr_Template, " & tmplate & ".Crex_Template, " & tmplate & ".Sequence_Descriptor1," & tmplate & ".Sequence_Descriptor0," & tmplate & ".Bufr_Element, " & tmplate & ".Crex_Element, " & tmplate & ".Climsoft_Element, " & tmplate & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & tmplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data FROM " & tmplate & " INNER JOIN bufr_crex_master ON " & tmplate & ".Bufr_Element = bufr_crex_master.Bufr_FXY ORDER BY " & tmplate & ".nos;"

            ' Create query Command for creating a new table 'bufr_crex_data'
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()


            Bufr_Crex_Initialize(dbconn)  'Set all values to missing

            'Set data set
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "bufr_crex_data")

            ' Get the number of subsets

            Dim substs As Integer
            Dim subsets, sss, fl2 As String

            substs = Val(cboStation.Items.Count)
            subsets = Strings.Format(substs, "000")

            'MsgBox("Total subsets = " & substs & " > " & subsets)
            sss = subsets 'Format(substs, "000")

            If Not IO.Directory.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data") Then
                IO.Directory.CreateDirectory(System.IO.Path.GetFullPath(Application.StartupPath) & "\data")
            End If

            fl2 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_subsets.txt"

            FileOpen(20, fl2, OpenMode.Output)

            'Loop through the subsets
            Data_Description_Section = ""
            For i = 0 To cboStation.Items.Count - 1

                ' Set the replicated elements according to observations per subset
                Set_Replications(dbconn, cboStation.Items(i))

                Update_Station_Details(dbconn, cboStation.Items(i))
                Update_Instruments_Details(dbconn, cboStation.Items(i))
                Update_Time_Periods(dbconn)
                Update_Observation_data(dbconn, cboStation.Items(i), txtYear.Text, cboMonth.Text, cboDay.Text, cboHour.Text)
                Encode_Bufr(dbconn)
                Output_Data_Code(dbconn, i + 1)
                Data_Description_Section = Data_Description_Section & Bufr_Section4(dbconn)
            Next i

            ' Output Bufr coded data if subsets exist
            'MsgBox(txtMsgHeader.Text)
            'MsgBox(cboDay.Text)

            msg_header = txtMsgHeader.Text & " " & cboDay.Text.PadLeft(2, "0"c) & cboHour.Text.PadLeft(2, "0"c) & "00"

            ' Include BBB if present
            If cboBBB.Text <> "" Then msg_header = msg_header & " " & cboBBB.Text

            '            ' Structure the output file name in format CCCCNNNNNNNN.ext
            msg_file = txtMsgHeader.Text & cboDay.Text.PadLeft(2, "0"c) & cboHour.Text.PadLeft(2, "0"c) & "00" & "00"

            'MsgBox(msg_header & " " & msg_file)

            If Int(sss) > 0 Then
                If Not BUFR_Code(dbconn, Data_Description_Section, substs) Then
                    MsgBox("Encoding Error")
                End If
            End If



            '' Update with entered observations for each subset


            ''            sql = "SELECT lookup_station.id, lookup_station.station_name AS observation, Left([id_alias],2) AS block, Right([id_alias],3) AS [number], IIf([qualifier]=""AUTOMATIC"",2 Or [qualifier]<>""AUTOMATIC"",1) AS type, lookup_location.latitude AS lat, lookup_location.longitude AS lon, lookup_location.elevation AS height FROM (lookup_station INNER JOIN lookup_stationid_alias ON lookup_station.id = lookup_stationid_alias.refers_to) INNER JOIN lookup_location ON lookup_station.id = lookup_location.occupied_by " & _
            ''                  "WHERE (((lookup_station.station_name)=""" & rs.Fields("station_name") & """) AND ((lookup_stationid_alias.belongs_to)=""wmo_id""));"

            ''            If clicom.query_exist("qry_crex_location", dbase) Then db.QueryDefs.Delete("qry_crex_location")
            ''            qry = db.CreateQueryDef("qry_crex_location", sql)

            ''            ' Set the recordset to the location query
            ''            rsbx1 = db.OpenRecordset("qry_crex_location")

            ''            'The following statement helps to skip a record without location. But it has been found to work similarly with resume next on empty record error
            ''            'If rsbx1.RecordCount = 0 Then GoTo NextSubset

            ''            ' Determine whether it a is sysnoptic station
            ''            If IsNull(rsbx1.Fields("block")) Then
            ''                MsgBox("Can't Code. WMO Station Number not found")
            ''                Exit Sub
            ''                ' If MsgBox("Not a Synoptic station. Continue?", vbYesNo, "Synop Crex") = vbNo Then Exit Sub
            ''            End If


            ''            'Update Data with the synop_crex form
            ''            With rsbx
            ''                .MoveFirst()
            ''                Do While .EOF = False
            ''                    ' Update Station Name, Observation times and Instrument parameters from the synop interface form
            ''                    .Edit()
            ''                    Select Case .Fields("Climsoft_Element")
            ''                        '        Case "station_WMO_bloc"
            ''                        '           .Fields("Observation") = rsbx1.Fields("bloc")
            ''                        '        Case "station_WMO_number"
            ''                        '           .Fields("Observation") = rsbx1.Fields("number")
            ''                        Case "station_name"
            ''                            .Fields("Observation") = rs.Fields("station_name") 'txtstation
            ''                        Case "datetime_year"
            ''                            .Fields("observation") = Format(rs.Fields("yyyy"), "0000") 'Format(txtyear, "0000")
            ''                        Case "datetime_month"
            ''                            .Fields("observation") = Format(rs.Fields("mm"), "00") 'Format(txtmonth, "00")
            ''                        Case "datetime_day"
            ''                            .Fields("observation") = Format(rs.Fields("dd"), "00") 'Format(txtday, "00")
            ''                        Case "datetime_hour"
            ''                            .Fields("observation") = Format(rs.Fields("hh"), "00") 'Format(txthour, "00")
            ''                        Case "datetime_minute"
            ''                            .Fields("observation") = Format(txtminute, "00")
            ''                            '        Case "5"
            ''                        Case "Temp_SH" ' Sensor height for temperature measurement
            ''                            If txtth = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level")  'txtth
            ''                            End If
            ''                        Case "Vis_SH" ' Sensor height for visibility measurement
            ''                            If txtvh = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "VISIB_I", "instal_level") 'txtvh
            ''                            End If
            ''                        Case "R24_SH" ' Sensor height for precipitation measurement
            ''                            If txtrh = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
            ''                            End If
            ''                        Case "xt_SH" ' Sensor height for extreme temperature measurement
            ''                            If txtth = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level") 'txtth
            ''                            End If
            ''                        Case "w_SH" ' Sensor height for wind measurement
            ''                            If txtwh = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instal_level") 'txtwh
            ''                            End If
            ''                        Case "ww_TP" ' Time Period for Past and Present Weather
            ''                            If CLng(Hour(txthour)) Mod 6 = 0 Then
            ''                                .Fields("observation") = -6
            ''                            Else
            ''                                .Fields("observation") = -3
            ''                            End If
            ''                        Case "tR_TP" ' Time Period for precipitation replication 1
            ''                            .Fields("observation") = Rain_Diplacement(CInt(Left(txthour, 2))) '-24
            ''                        Case "tr_TP"  ' Time Period for precipitation replication 2
            ''                            .Fields("observation") = -3
            ''                        Case "evap_TP" ' Time Period for evaporation
            ''                            .Fields("observation") = -24
            ''                        Case "evap_I"
            ''                            .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "EVAP_I", "instrument_type") 'txtit
            ''                        Case "SSS_TP" ' Time Period for sunshine replication 1
            ''                            .Fields("observation") = -24
            ''                        Case "SS_TP" ' Time Period for sunshine replication 2
            ''                            .Fields("observation") = -1
            ''                        Case "RR_SH" ' Sensor height for precipitation for the replications
            ''                            If txtrh = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
            ''                            End If
            ''                            '        Case "w_SH"
            ''                            '           .Fields("observation") = txtwh
            ''                        Case "w_I"
            ''                            .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instrument_type") ' txtwi  Get_Instrument("station_instrument", rs, "BARO_I", "instal_level")
            ''                        Case "xt_TP" ' Time Period for maximum temperature
            ''                            .Fields("observation") = -12
            ''                        Case "xt0_TP" ' Time Period for maximum temperature ending at nominal time of the report
            ''                            .Fields("observation") = 0
            ''                        Case "nt_TP" ' Time Period for minimum teperature
            ''                            .Fields("observation") = -12
            ''                        Case "nt0_TP" ' Time Period for minimum teperature ending at nominal time of the report
            ''                            .Fields("observation") = -0
            ''                        Case "w_TS" ' Time Significance for wind
            ''                            .Fields("observation") = 2
            ''                        Case "w_TP" ' Time Period for wind
            ''                            .Fields("observation") = -10
            ''                        Case "evap_SH" ' Sensor height for Evaporation/Evatranspiration
            ''                            If txtrh = "" Then
            ''                                .Fields("observation") = "/"
            ''                            Else
            ''                                .Fields("observation") = txtrh
            ''                            End If
            ''                        Case "rad1_TP"
            ''                            .Fields("observation") = -1
            ''                        Case "rad2_TP"
            ''                            .Fields("observation") = -24
            ''                        Case "tempc_t" ' Time Period for Past and Present Weather
            ''                            If CLng(Hour(txthour)) Mod 6 = 0 Then
            ''                                .Fields("observation") = -6
            ''                            Else
            ''                                .Fields("observation") = -3
            ''                            End If
            ''                    End Select
            ''                    .Update()

            ''                    ' Update with entered observations for each subset
            ''                    For i = 0 To rs.Fields.count - 1
            ''                        obsv = ""
            ''                        If rs.Fields(i).name = rsbx.Fields("Climsoft_Element") Then
            ''                            obsv = rs.Fields(i)

            ''                            ' Scaling pressure and Radiation values
            ''                            If rs.Fields(i).name = "137" And obsv <> "" Then obsv = obsv & "000000"
            ''                            If rs.Fields(i).name = "106" Or rs.Fields(i).name = "107" Or rs.Fields(i).name = "399" Or rs.Fields(i).name = "301" Or rs.Fields(i).name = "400" Then
            ''                                If obsv <> "" Then
            ''                                    obsv = CLng(rs.Fields(i)) * 100
            ''                                End If
            ''                            End If

            ''                            .Edit()
            ''                            .Fields("observation") = obsv
            ''                            .Update()
            ''                        End If
            ''Nexxt:
            ''                    Next i

            ''                    .MoveNext()
            ''                Loop

            ''                ' Compute cloud layers replication factor
            ''                rep1 = 0
            ''                rp2 = 0
            ''                .MoveFirst()
            ''                Do While .EOF = False
            ''                    Select Case .Fields("Climsoft_Element")
            ''                        ' Cloud layers above station level
            ''                        Case "116"  'Cloud amount; first layer present
            ''                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
            ''                        Case "120"  'Cloud amount; second second layer present
            ''                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
            ''                        Case "124"  'Cloud amount; third layer present
            ''                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
            ''                        Case "128"  'Cloud amount; fourth layer present
            ''                            If .Fields("observation") <> "" Then rep1 = rep1 + 1

            ''                            ' Cloud layers below station level
            ''                        Case "612"  'Cloud amount; first layer present
            ''                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
            ''                        Case "622"  'Cloud amount; second second layer present
            ''                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
            ''                        Case "632"  'Cloud amount; third layer present
            ''                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
            ''                        Case "642"  'Cloud amount; fourth layer present
            ''                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
            ''                    End Select
            ''                    .MoveNext()
            ''                Loop

            ''                ' Update station location, elevation, pressure change characteristic and clouds replication factors
            ''                Dim vertical_sig As String
            ''                .MoveFirst()
            ''                rsbx1.MoveFirst()
            ''                Do While .EOF = False
            ''                    vertical_sig = ""
            ''                    .Edit()
            ''                    Select Case .Fields("Climsoft_Element")
            ''                        Case "station_WMO_bloc"
            ''                            .Fields("observation") = rsbx1.Fields("block")
            ''                        Case "station_WMO_number"
            ''                            .Fields("observation") = rsbx1.Fields("number")
            ''                        Case "station_qualifier"
            ''                            .Fields("observation") = rsbx1.Fields("type")
            ''                        Case "station_deglatitude"
            ''                            .Fields("observation") = rsbx1.Fields("lat")
            ''                        Case "station_deglongitude"
            ''                            .Fields("observation") = rsbx1.Fields("lon")
            ''                        Case "station_elevation"
            ''                            .Fields("observation") = rsbx1.Fields("height")
            ''                        Case "station_pressure_height"
            ''                            .Fields("observation") = Val(rsbx1.Fields("height")) + Val(Get_Instrument("station_instrument", rs.Fields("station_id"), "BARO_I", "instal_level")) 'CInt(txtbr)
            ''                        Case "cloud_rep1"
            ''                            .Fields("observation") = rep1
            ''                        Case "cloud_rep2"
            ''                            .Fields("observation") = rep2
            ''                        Case "532"
            ''                            If Not IsNull(.Fields("observation")) Then .Fields("observation") = CInt(.Fields("observation")) * 60 'Sunshine minutes
            ''                        Case "114"
            ''                            If Not IsNull(.Fields("observation")) Then .Fields("observation") = Val(.Fields("observation")) * 12.5 'Total Cloud Cover
            ''                    End Select
            ''                    .Update()
            ''                    .MoveNext()
            ''                Loop

            ''                ' Format for Trace rainfall if it exist

            ''                ' Trace for 24 Hour Precipation
            ''                .MoveFirst()
            ''                Do While .EOF = False
            ''                    If .Fields("Climsoft_Element") = "5" And Trace24hr = True Then
            ''                        .Edit()
            ''                        .Fields("observation") = -1
            ''                        .Update()
            ''                    End If
            ''                    .MoveNext()
            ''                Loop

            ''                ' Trace for 3 Hour Precipation
            ''                .MoveFirst()
            ''                Do While .EOF = False
            ''                    If .Fields("Climsoft_Element") = "174" And Trace3hr = True Then
            ''                        .Edit()
            ''                        .Fields("observation") = -1
            ''                        .Update()
            ''                    End If
            ''                    .MoveNext()
            ''                Loop

            ''                ' Update Precipitation characteristic
            ''                Dim ChrR As String

            ''                ChrR = Precip_Char(rsbx)
            ''                .MoveFirst()
            ''                Do While .EOF = False
            ''                    .Edit()
            ''                    If .Fields("Climsoft_Element") = "505" Then
            ''                        .Fields("observation") = ChrR
            ''                        .Update()
            ''                    ElseIf .Fields("Climsoft_Element") = "506" Then
            ''                        .Fields("observation") = 9
            ''                        .Update()
            ''                    End If
            ''                    .MoveNext()
            ''                Loop

            ' '' Encode data ////////////////////////////////////////////////

            ''.MoveFirst()

            ''Dim miss As Boolean
            ''Dim dats As String


            ''Do While .EOF = False
            ''    If .Fields("observation") <> "" Then
            ''        .Edit()
            '        .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db))
            ''        .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db), db)
            ''        .Update()
            ''    End If
            ''    .MoveNext()
            ''Loop

            ''                ' Convert Special Cloud data to CREX code
            ''                .MoveFirst()

            ''                Dim N As String
            ''                Dim cl As String
            ''                Dim CM As String
            ''                Dim CH As String

            ''                Do While .EOF = False
            ''                    .Edit()
            ''                    Select Case .Fields("Climsoft_Element")
            ''                        '    Case "114" ' N
            ''                        '      If .Fields("observation") <> "" Then N = .Fields("observation")
            ''                        '      If .Fields("observation") <> "/" And .Fields("observation") <> "" Then .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CDbl(.Fields("observation")) * 12.5, ScaleFactor(.Fields("Climsoft_Element"), db))  'val (.Fields("observation")) * 12.5
            ''                        Case "169" 'Cloud type CL
            ''                            If .Fields("observation") <> "" Then
            ''                                cl = .Fields("observation")
            ''                                If N = "0" Then
            ''                                    cl = 30
            ''                                ElseIf N = "9" Or N = "/" Or cl = "/" Or cl = "" Then
            ''                                    cl = 62
            ''                                Else 'ElseIf CH <> "/" And CH <> "" Then
            ''                                    cl = CDbl(.Fields("observation")) ' + 30
            ''                                End If
            '                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), cl, ScaleFactor(.Fields("Climsoft_Element"), db))
            ''                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), cl, ScaleFactor(.Fields("Climsoft_Element"), db), db)
            ''                            End If
            ''                        Case "170" 'Cloud type CM
            ''                            If .Fields("observation") <> "" Then
            ''                                CM = .Fields("observation")
            ''                                If N = "0" Then
            ''                                    CM = 20
            ''                                ElseIf N = "9" Or N = "/" Or CM = "/" Or CM = "" Then
            ''                                    CM = 61
            ''                                Else 'ElseIf CH <> "/" And CH <> "" Then
            ''                                    CM = CDbl(.Fields("observation")) '+ 20
            ''                                End If
            '                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CM, ScaleFactor(.Fields("Climsoft_Element"), db))
            ''                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CM, ScaleFactor(.Fields("Climsoft_Element"), db), db)
            ''                            End If
            ''                        Case "171" 'Cloud type CH
            ''                            If .Fields("observation") <> "" Then
            ''                                CH = .Fields("observation")
            ''                                If N = "0" Then
            ''                                    CH = 10
            ''                                ElseIf N = "9" Or N = "/" Or CH = "/" Or CH = "" Then
            ''                                    CH = 60
            ''                                Else 'ElseIf CH <> "/" And CH <> "" Then
            ''                                    CH = CDbl(.Fields("observation")) ' + 10
            ''                                End If
            ''                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CH, ScaleFactor(.Fields("Climsoft_Element"), db))
            ''                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CH, ScaleFactor(.Fields("Climsoft_Element"), db), db)
            ''                            End If
            ''                    End Select
            ''                    .Update()
            ''                    .MoveNext()
            ''                Loop
            ''            End With

            ''            ' Coded message output

            'Dim message_header As String

            ''            sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
            ''                  "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"

            ''            message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00")  '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

            ''            ' Include BBB if present
            ''            If txtBBB <> "" Then message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

            ''            ' Structure the output file name in format CCCCNNNNNNNN.ext
            ''            msg_file = Right(msg_header, 4) & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & Format(txtsecond, "00")

            ''            Select Case Me.Caption
            ''                Case "CREX Synop"
            '                    If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox("CREX Coding error")
            ''                Case "BUFR Synop"
            ''                    If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox("Error in encoding Data Section")
            ''            End Select


            ''                ' Coded message output

            ''                Dim message_header As String
            ''                
            ''                sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
            ''                      "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"
            ''                
            ''                message_header = msg_header & " " & Format(day(Date), "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)
            ''                
            ''                Select Case Me.Caption
            ''                 Case "CREX Synop"
            '                    If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox "CREX Coding error"
            ''                 Case "BUFR Synop"
            ''                   If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox "Error in encoding Data Section"
            ''                End Select
            ''                
            ''NextSubset:
            ''                rs.MoveNext()
            ''                        Loop





            '        ' Show encoded message
            '        Select Case Me.Caption
            '            Case "CREX Synop"
            '                Dim msg As String
            '                msg = ""
            '                '   MsgBox msg_file
            '   Open msg_file For Input As #1

            '                Do While EOF(1) = False
            '     Input #1, msg
            '                    txt_message = txt_message & msg & Chr(13) & Chr(10)
            '                Loop
            '                output_file = msg_file
            '   Close #1
            '            Case "BUFR Synop"

            '                If bufr_edition = 3 Then ' BUFR up to edition 3
            '                    If Not BUFR_Code_ver3(sql, message_header, Me, db, Bufr_DataSection) Then MsgBox("BUFR Coding error")
            '                Else ' BUFR up to edition 4
            'If Not BUFR_Code(dbconn, sql, message_header, Bufr_DataSection, substs) Then MsgBox("BUFR Coding error")
            '                End If
            '        End Select

            'Close #10

            FileClose(20)
            MsgBox("Finished Encoding")
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
            FileClose(20)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Sub Output_Data_Code(conn1 As MySql.Data.MySqlClient.MySqlConnection, sbst As Integer)

        ' Output expanded decsriptors into a CSV file

        descriptors_file = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv"
        FileOpen(2, descriptors_file, OpenMode.Append)

        Dim counts As Integer
        Dim obsv As String

        counts = 1
        sql = "select * from bufr_crex_data where selected =1 order by nos;"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "bufr_coded")


        With ds.Tables("bufr_coded")

            Print(2, "Subset " & sbst)
            PrintLine(2)
            Write(2, "NO", "ELEMENT DESCRIPTOR", "ELEMENT NAME", "UNIT", "SCALE", "REF VALUE", "WIDTH", "OBSERVATION", "BINARY DATA")
            PrintLine(2)
            For i = 0 To .Rows.Count - 1
                If Len(.Rows(i).Item("Observation")) = 0 Then
                    obsv = "MISSING"
                Else
                    obsv = .Rows(i).Item("Observation")
                End If

                Write(2, Format(counts, "000"), "'" & .Rows(i).Item("Bufr_Element") & "'", .Rows(i).Item("Element_Name"), .Rows(i).Item("Bufr_Unit"), .Rows(i).Item("Bufr_Scale"), .Rows(i).Item("Bufr_RefValue"), .Rows(i).Item("Bufr_DataWidth_Bits"), obsv, "'" & .Rows(i).Item("Bufr_Data") & "'")
                counts = counts + 1
                PrintLine(2)
            Next
            FileClose(2)
        End With

    End Sub

    Sub Bufr_Crex_Initialize(conn1 As MySql.Data.MySqlClient.MySqlConnection)

        Dim sql As String

        Try

            ' Initialize files by deleted output files used in previous sessions
            If IO.File.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv") Then
                IO.File.Delete(System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv")
            End If

            sql = "Select * from bufr_crex_data"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "bufr_crex_data")

            Kount = ds.Tables("bufr_crex_data").Rows.Count

            ' Clear previously encoded data
            sql = "update bufr_crex_data set bufr_data = '',crex_data = '' where bufr_data <> '' or crex_data <> '';"
            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)

            'Execute query
            objCmd.ExecuteNonQuery()

            'Initialized with missing data character
            Dim crex_siz, bufr_siz As Integer
            Dim crex_miss, bufr_miss As String

            With ds.Tables("bufr_crex_data")
                For i = 0 To Kount - 1
                    If .Rows(i).Item("Crex_DataWidth") <> "" Then crex_siz = Val(ds.Tables("bufr_crex_data").Rows(i).Item("Crex_DataWidth"))
                    If .Rows(i).Item("Bufr_DataWidth_Bits") <> "" Then bufr_siz = Val(ds.Tables("bufr_crex_data").Rows(i).Item("Bufr_DataWidth_Bits"))

                    '   Initialize crex data as missing
                    crex_miss = "/"
                    For j = 2 To crex_siz
                        crex_miss = crex_miss & "/"
                    Next j

                    bufr_miss = "1"
                    For j = 2 To bufr_siz
                        bufr_miss = bufr_miss & "1"
                    Next j

                    sql = "update bufr_crex_data set Crex_Data = '" & crex_miss & "', Bufr_Data = '" & bufr_miss & "' where nos = '" & i + 1 & "';"
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                    'Execute query
                    objCmd.ExecuteNonQuery()
                Next
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Set_Replications(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)

        sql = "Select * from bufr_crex_data"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "bufr_crex_data")

        Initialize_Cloud_Replications(conn1, ds, 4, "119", "cloud_rep1") 'Delayed replication of cloud layers above station level 4 times for a maximum of 4 layers

        Initialize_Cloud_Replications(conn1, ds, 5, "611", "cloud_rep2") 'Delayed replication of cloud layers below station level 4 times for a maximum of 5 layers

        ' Set the replicated cloud layers to TRUE if observations made
        Dim flds As Integer

        sql = "Select * from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "' and stationId = '" & stn & "';"

        'sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "from form_synoptic_2_ra1")

        ' Initialize cloud layers by setting them to FALSE so that they are not selected if observations not made
        Kount = ds.Tables("from form_synoptic_2_ra1").Rows.Count

        flds = ds.Tables("from form_synoptic_2_ra1").Columns.Count

        With ds.Tables("from form_synoptic_2_ra1")
            'For i = 0 To Kount - 1

            ' Replications for clounds above the station
            If Len(.Rows(0).Item("Val_Elem119")) > 0 Then Select_Descriptor(conn1, "119", "cloud_rep1")
            If Len(.Rows(0).Item("Val_Elem123")) > 0 Then Select_Descriptor(conn1, "123", "cloud_rep1")
            If Len(.Rows(0).Item("Val_Elem127")) > 0 Then Select_Descriptor(conn1, "127", "cloud_rep1")
            If Len(.Rows(0).Item("Val_Elem131")) > 0 Then Select_Descriptor(conn1, "131", "cloud_rep1")
            ' Replications for clounds below the station
            ' These observations are not recorded in this form. Hence the associated elements have been commented
            ' However the replication factor is set to Zero but Selected so that the decoders can retrieve the replication factor
            Select_Descriptor(conn1, "", "cloud_rep2")
            'If Len(.Rows(i).Item("Val_Elem611")) > 0 Then Select_Descriptor(conn1, "611", "cloud_rep2")
            'If Len(.Rows(i).Item("Val_Elem621")) > 0 Then Select_Descriptor(conn1, "621", "cloud_rep2")
            'If Len(.Rows(i).Item("Val_Elem631")) > 0 Then Select_Descriptor(conn1, "631", "cloud_rep2")
            'If Len(.Rows(i).Item("Val_Elem641")) > 0 Then Select_Descriptor(conn1, "641", "cloud_rep2")
            'Next
        End With
    End Sub
    Sub Update_Station_Details(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)
        'MsgBox(stn)
        Dim station_name, wmo_block, wmo_No, lat, lon, elev, qualifier, typ As String
        sql = "select stationName, wmoid, latitude, longitude, elevation, qualifier from station where stationId = '" & stn & "';"
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "stations")

            station_name = ds.Tables("stations").Rows(0).Item("stationName")
            If Len(station_name) > 20 Then station_name = Strings.Left(station_name, 20) 'Truncate station name to the madatory maximum of 20 characters
            wmo_block = Strings.Left(ds.Tables("stations").Rows(0).Item("wmoid"), 2)
            wmo_No = Strings.Right(ds.Tables("stations").Rows(0).Item("wmoid"), 3)
            lat = ds.Tables("stations").Rows(0).Item("latitude")
            lon = ds.Tables("stations").Rows(0).Item("longitude")
            elev = ds.Tables("stations").Rows(0).Item("elevation")
            qualifier = ds.Tables("stations").Rows(0).Item("qualifier")

            If qualifier = "SYNOPTIC" Then
                typ = 1 ' Manual stations only
            ElseIf qualifier = "AWS" Then
                typ = 2 ' Automatic station observations only
            ElseIf qualifier = "Hybrid" Then
                typ = 3 ' Both auto and manual observations used
            End If

            'Update the station details
            Update_Observation(conn1, station_name, "station_name")
            Update_Observation(conn1, wmo_block, "station_WMO_bloc")
            Update_Observation(conn1, wmo_No, "station_WMO_number")
            Update_Observation(conn1, lat, "station_deglatitude")
            Update_Observation(conn1, lon, "station_deglongitude")
            Update_Observation(conn1, elev, "station_elevation")
            Update_Observation(conn1, typ, "station_qualifier")

            'Update the datetime details
            Update_Observation(conn1, txtYear.Text, "datetime_year")
            Update_Observation(conn1, cboMonth.Text, "datetime_month")
            Update_Observation(conn1, cboDay.Text, "datetime_day")
            Update_Observation(conn1, cboHour.Text, "datetime_hour")
            Update_Observation(conn1, "00", "datetime_minute")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update_Instruments_Details(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)
        sql = "select describedby as code,instrumentcode,height from stationelement where recordedfrom = '" & stn & "';"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "instruments")
            With ds.Tables("instruments")
                For i = 0 To .Rows.Count - 1
                    Select Case .Rows(i).Item("code")
                        Case 5 ' Pecipitation Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "R24_SH") ' Height for 24 hr observation
                            Update_Observation(conn1, .Rows(i).Item("height"), "RR_SH") ' Height for 1 hr observation
                        Case 101  ' Temperature Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "Temp_SH")  ' Height
                        Case 2  ' Extreme Temperature Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "xt_SH")  ' Height
                        Case 111 ' Wind Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "w_SH") ' Height
                            Update_Observation(conn1, .Rows(i).Item("instrumentcode"), "w_I") ' Type
                        Case 110 ' Visibility Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "Vis_SH")  ' Height
                        Case 18 ' Evaporation Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "evap_SH") 'Height
                            Update_Observation(conn1, .Rows(i).Item("instrumentcode"), "evap_I") 'Type
                        Case 106 ' Pressure Instrument
                            Update_Observation(conn1, .Rows(i).Item("height"), "station_pressure_height") 'Height
                    End Select
                Next
            End With


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update_Time_Periods(conn1 As MySql.Data.MySqlClient.MySqlConnection)
        Dim Tprd As String

        If CLng(cboHour.Text) Mod 6 = 0 Then
            Tprd = "-6"
        Else
            Tprd = "-3"
        End If
        Update_Observation(conn1, Tprd, "ww_TP") ' Time Period for Past and Present Weather
        Update_Observation(conn1, Tprd, "tempc_t")  ' Time Period for Past and Present Weather 2
        Update_Observation(conn1, cboHour.Text, "tR_TP") ' Time Period for precipitation replication 1
        Update_Observation(conn1, "-3", "tR_TP") ' Time Period for precipitation replication 2
        Update_Observation(conn1, "-24", "evap_TP") ' Time Period for evaporation
        Update_Observation(conn1, "-24", "SSS_TP") ' Time Period for sunshine replication 1
        Update_Observation(conn1, "-1", "SS_TP") ' Time Period for sunshine replication 2
        Update_Observation(conn1, "-12", "xt_TP") ' Time Period for maximum temperature
        Update_Observation(conn1, "0", "xt0_TP") ' Time Period for maximum temperature ending at nominal time of the report
        Update_Observation(conn1, "-12", "nt_TP") ' Time Period for minimum teperature
        Update_Observation(conn1, "-0", "nt0_TP") ' Time Period for minimum teperature ending at nominal time of the report
        Update_Observation(conn1, "2", "w_TS") ' Time Significance for wind
        Update_Observation(conn1, "-10", "w_TP") ' Time Period for wind
        Update_Observation(conn1, "-1", "rad1_TP") ' Time Period for radiation replication 1
        Update_Observation(conn1, "-24", "rad2_TP") ' Time Period for radiation replication 2

    End Sub
    Sub Update_Observation_data(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String, yr As String, mm As String, dd As String, hh As String)
        Dim fld, dat, ChrR, N, CL, CM, CH As String
        Dim code, rep1, rep2 As Integer
        sql = "select * from form_synoptic_2_ra1 where stationid = '" & stn & " ' and yyyy= '" & yr & " ' and mm = '" & mm & " ' and dd= '" & dd & " '  and hh = '" & hh & "';"
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "synoptic")
            If ds.Tables("synoptic").Rows.Count <> 0 Then
                rep1 = 0
                rep2 = 0
                With ds.Tables("synoptic")
                    For i = 0 To .Columns.Count - 1
                        fld = .Columns(i).ColumnName

                        If Len(fld) = 11 Then
                            code = Int(Strings.Mid(fld, 9, 3))
                            dat = .Rows(0).Item(i)
                            If Len(dat) <> 0 Then
                                ' Compute observations with special conditions
                                If code = 46 Then ' Scale Radiation and Pressure 
                                    dat = dat & "000000"
                                ElseIf code = 106 Or code = 107 Or code = 399 Or code = 301 Or code = 400 Then ' Scale Pressure
                                    dat = CLng(dat) * 100
                                ElseIf code = "506" Then ' Time of beginning or end of precipitation
                                    dat = 9
                                ElseIf code = "114" Then ' Convert OKTAS to %
                                    dat = CLng(dat) * 12.5
                                ElseIf code = "84" Then ' Convert hours of Sunshine to minutes
                                    dat = CLng(dat) * 60
                                End If
                                Update_Observation(conn1, dat, code)

                                ' Compute cloud layers replications
                                'Clouds above station level
                                If code = 116 Or code = 120 Or code = 124 Or code = 128 Then rep1 = rep1 + 1
                                'Clouds below station level
                                If code = 612 Or code = 622 Or code = 632 Or code = 642 Then rep2 = rep2 + 1
                            End If

                            ' Convert Special Cloud type data
                            If code = "169" Or code = "170" Or code = "171" Then
                                If Len(dat) <> 0 Then
                                    Select Case code
                                        Case "169" 'Cloud type CL
                                            If dat = "0" Then dat = 30
                                            If dat = "9" Then dat = 62
                                        Case "170" 'Cloud type CM
                                            If dat = "0" Then dat = 20
                                            If dat = "9" Then dat = 61
                                        Case "171"  'Cloud type CM
                                            If dat = "0" Then dat = 10
                                            If dat = "9" Then dat = 60
                                    End Select
                                Else
                                    dat = "63"
                                End If
                                Update_Observation(conn1, dat, code)
                            End If
                        End If

                        ' Compute value for TRACE precipitation if present
                        If fld = "Flag005" And Not IsDBNull(.Rows(0).Item(i)) Then
                            If .Rows(0).Item(i) = "T" Then Update_Observation(conn1, -1, 5) '24Hr Precipitation
                        End If
                        If fld = "Flag174" And Not IsDBNull(.Rows(0).Item(i)) Then
                            If .Rows(0).Item(i) = "T" Then Update_Observation(conn1, -1, 174) '24Hr Precipitation
                        End If

                        ' Compute Character and Intensity of precipitation
                        If fld = "Val_Elem005" Then
                            ChrR = Precip_Characteristic(.Rows(0).Item(i))
                            Update_Observation(conn1, ChrR, "505")
                            Update_Observation(conn1, "9", "50")
                        End If

                    Next
                    ' Update Cloud Replications
                    Update_Observation(conn1, rep1, "cloud_rep1")
                    Update_Observation(conn1, rep2, "cloud_rep2")

                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function Precip_Characteristic(dat As String) As String

        If Len(dat) = 0 Then
            Precip_Characteristic = 15
        ElseIf dat = "0" Then
            Precip_Characteristic = 0
        ElseIf Val(dat) > 0 And Val(dat) <= 100 Then
            Precip_Characteristic = 1
        ElseIf Val(dat) > 100 And Val(dat) <= 500 Then
            Precip_Characteristic = 2
        ElseIf Val(dat) > 500 Then
            Precip_Characteristic = 3
        End If
        Return Precip_Characteristic
    End Function

    Sub Update_Observation(conn1 As MySql.Data.MySqlClient.MySqlConnection, data As String, element As String)
        sql = "update bufr_crex_data set observation = '" & data & "' where Climsoft_Element='" & element & "';"
        ' Create the Command for executing query and set its properties
        Try
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
            'Execute query
            objCmd.ExecuteNonQuery()
            'MsgBox(typ)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Select_Descriptor(conn1 As MySql.Data.MySqlClient.MySqlConnection, elm As String, rep_type As String)
        Dim ds1 As New DataSet
        Dim kount1, num As Integer

        Try
            sql = "Select * from bufr_crex_data"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds1.Clear()
            da.Fill(ds1, "bufr_crex_data")
            kount1 = ds1.Tables("bufr_crex_data").Rows.Count

            'Select replication factors
            For i = 0 To kount1 - 1
                ' Set the relication descriptor as TRUE
                sql = "update bufr_crex_data set Selected = '1' where Climsoft_Element = '" & rep_type & "';"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                objCmd.ExecuteNonQuery()

                ' Set the cloud details observed as TRUE
                With ds1.Tables("bufr_crex_data").Rows(i)
                    If .Item("Climsoft_Element") = elm Then
                        num = Val(ds1.Tables("bufr_crex_data").Rows(i).Item("nos")) - 1
                        For j = num To num + 4
                            sql = "update bufr_crex_data set Selected = '1' where nos = '" & j & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                            objCmd.ExecuteNonQuery()
                        Next
                        Exit For
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Initialize_Cloud_Replications(conn1 As MySql.Data.MySqlClient.MySqlConnection, dsa As DataSet, rep_factor As Integer, StartElement As String, rep_type As String)


        ' Initialize cloud layers by setting them to FALSE so that they are not selected if observations not made

        For i = 0 To Kount - 1
            If dsa.Tables("bufr_crex_data").Rows(i).Item("Climsoft_Element") = rep_type Then
                For j = i + 3 To i + 3 + (rep_factor * 4) '17
                    sql = "update bufr_crex_data set selected = '0' where nos = '" & j & "';"
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                    'Execute query
                    objCmd.ExecuteNonQuery()
                Next
                Exit For
            End If
        Next

    End Sub

    Private Sub cboHour_TextChanged(sender As Object, e As EventArgs) Handles cboHour.TextChanged

        'Dim msghd, hh As String
        'Dim hr As Integer

        'msghd = txtMsgHeader.Text
        'hh = Val(cboHour.Text)
        'hr = hh Mod 6

        'If cboHour.Text <> "" And hh <= 21 Then
        '    Select Case hr Mod 6
        '        Case 0
        '            '    Main Hour
        '            Mid(msghd, 1) = "I" ' = "ISMH40 HKNC"
        '            msg_header = msghd
        '            'mmm = "002"
        '        Case 3
        '            '    Intermediate Hour
        '            Mid(msghd, 1) = "I"
        '            Mid(msghd, 3) = "I"
        '            msg_header = msghd
        '            'mmm = "001"
        '        Case Else
        '            '    Other Hours
        '            Mid(msghd, 1) = "I"
        '            Mid(msghd, 3) = "N"
        '            msg_header = msghd
        '            'mmm = "000"
        '    End Select
        'End If
    End Sub
    Sub Encode_Bufr(conn1 As MySql.Data.MySqlClient.MySqlConnection)
        Dim ds1 As New DataSet
        Dim bufr_str, climsoft_element_scale As String
        'Try
        sql = "Select * from bufr_crex_data"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds1.Clear()
        da.Fill(ds1, "bufr_crex_data")
        Kount = ds1.Tables("bufr_crex_data").Rows.Count

        For i = 0 To Kount - 1
            With ds1.Tables("bufr_crex_data").Rows(i)

                If Len(.Item("observation")) <> 0 Then

                    climsoft_element_scale = ScaleFactor(conn1, .Item("climsoft_element"))

                    bufr_str = Bufr_Data(conn1, .Item("Bufr_Unit"), .Item("Bufr_Scale"), .Item("Bufr_RefValue"), .Item("Bufr_DataWidth_Bits"), .Item("observation"), climsoft_element_scale)

                    'MsgBox(bufr_str & " " & .Item("Bufr_Unit") & " " & .Item("Bufr_Scale") & " " & .Item("observation") & " " & climsoft_element_scale)

                Else ' Compute binary stream for missing data
                    bufr_str = "1"
                    For k = 2 To Int(.Item("Bufr_DataWidth_Bits"))
                        bufr_str = bufr_str & "1"
                    Next
                End If

                ' Update with bufr data
                sql = "update bufr_crex_data set Bufr_Data = '" & bufr_str & "' where Climsoft_Element = '" & .Item("climsoft_element") & "';"

                ' Create the Command for executing query to update with Bufr data
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                'Execute query
                objCmd.ExecuteNonQuery()
            End With
        Next


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Function ScaleFactor(conn1 As MySql.Data.MySqlClient.MySqlConnection, code As String) As String

        ScaleFactor = 1

        Try
            sql = "Select elementId, elementScale from obselement where elementId = '" & Val(code) & "';"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "obselement")
            Kount = ds.Tables("obselement").Rows.Count

            If Kount <> 0 Then
                If Len(ds.Tables("obselement").Rows(0).Item("elementScale")) <> 0 Then ScaleFactor = ds.Tables("obselement").Rows(0).Item("elementScale")
                'ScaleFactor = 1
            End If
            'If Not IsNumeric(ScaleFactor) = 1 Then MsgBox(code)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Function Bufr_Data(conn1 As MySql.Data.MySqlClient.MySqlConnection, Bufr_Unit As String, Bufr_Scale As Integer, Bufr_RefValue As Long, Bufr_DataWidth As Integer, dat As String, climfactor As String) As String

        'frm_synop_crex.lmsg = Bufr_Unit 'Bufr_Scale & " " & Bufr_DataWidth & " " & dat & " " & climfactor

        Try

            ' Dim diff As Integer
            Dim num As Integer
            'Dim apd As String
            Dim datstr As String
            'Dim count As Integer

            Bufr_Data = ""
            If Bufr_Unit = "CCITT IA5" Then

                Bufr_Data = CCITT_Binary(conn1, dat, Bufr_DataWidth)

                Exit Function
            End If

            If IsNumeric(dat) Then

                ' Apply the scaling for both Climsoft and Bufr
                num = Val(dat) * Val(climfactor) * 10 ^ Val(Bufr_Scale)

                'convert to Kelvin values where the Temperature bufr units are in Kelvin
                If Bufr_Unit = "K" Then num = num + 273.15 * 10 ^ Val(Bufr_Scale)

                ' Subtract the Reference Value
                num = num - Bufr_RefValue

                datstr = Decimal_Binary(num, Bufr_DataWidth)

                Bufr_Data = datstr
            End If

        Catch ex As Exception
            MsgBox(ex.Message)

            Bufr_Data = ""
        End Try
    End Function
    Function Decimal_Binary(DecN As Integer, bts As Integer) As String

        Dim r As Integer
        Dim s As Integer
        Dim x As String

        x = DecN
        Decimal_Binary = "0"
        Try

            For i = 2 To bts
                Decimal_Binary = Decimal_Binary & "0"
            Next

            s = 0
            Do While DecN > 0
                r = DecN Mod 2

                Mid(Decimal_Binary, bts - s, 1) = r

                If r = 1 Then
                    DecN = DecN / 2 - 0.5
                Else
                    DecN = DecN / 2
                End If
                s = s + 1
            Loop

            Return Decimal_Binary

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Decimal_Binary
        End Try

    End Function

    Function Binary_Decimal(BinN As String) As Long
        Dim siz, posval As Integer

        siz = Len(BinN)
        Binary_Decimal = 0

        For i = 0 To siz - 1
            posval = Mid(BinN, siz - i, 1)
            Binary_Decimal = Binary_Decimal + posval * 2 ^ i
        Next

    End Function

    Function Bufr_Section4(conn1 As MySql.Data.MySqlClient.MySqlConnection) As String
        Try
            Dim bufr_subset As String

            sql = "select * from bufr_crex_data where selected =1 order by nos;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "bufr_coded")
            Kount = ds.Tables("bufr_coded").Rows.Count

            ' Get the binary data stream for the Subset
            bufr_subset = ""
            For i = 0 To Kount - 1
                bufr_subset = bufr_subset & ds.Tables("bufr_coded").Rows(i).Item("Bufr_Data")
            Next

            PrintLine(20, bufr_subset)
            Bufr_Section4 = bufr_subset

        Catch ex As Exception
            MsgBox(ex.Message)
            Bufr_Section4 = ""
        End Try
    End Function

    Function CCITT_Binary(conn1 As MySql.Data.MySqlClient.MySqlConnection, dat As String, DataWidth As Integer) As String

        Dim binstr As String
        Dim dat1 As String
        Dim chr1 As String
        Dim chr2 As String
        Dim recs As Integer
        Try
            sql = "Select * from ccitt;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ds.Clear()
            da.Fill(ds, "ccitt")
            recs = ds.Tables("ccitt").Rows.Count

            CCITT_Binary = ""
            ' Truncate long data strings to bufr data width

            binstr = ""
            If Len(dat) < DataWidth / 8 Then
                For i = 1 To DataWidth - Len(dat) * 8
                    binstr = binstr & "0"
                Next
            Else
                dat = Strings.Left(dat, DataWidth / 8)
            End If
            ' Loop the entire data string
            With ds.Tables("ccitt")
                For i = 1 To Len(dat)
                    dat1 = Mid(dat, i, 1)
                    If dat1 = " " Then dat1 = "SP"
                    For j = 0 To recs
                        If dat1 = .Rows(j).Item("Characters") Then
                            chr1 = .Rows(j).Item("MostSignificant")
                            chr2 = .Rows(j).Item("LeastSignificant")
                            ' Convert the character string to binary code
                            binstr = binstr & Decimal_Binary(Val(chr1), 4) & Decimal_Binary(Val(chr2), 4)
                            Exit For
                        End If
                    Next
                Next
            End With
   
            CCITT_Binary = binstr
        Catch ex As Exception
            MsgBox(ex.Message)
            CCITT_Binary = ""
        End Try
    End Function

    Function BUFR_Code(conn1 As MySql.Data.MySqlClient.MySqlConnection, binary_data As String, subsets As Integer) As Boolean
        'MsgBox(subsets)
        BUFR_Code = False

        Try
            Dim octets As String
            Dim section0, section1, section2, section3, section4, section5, substs, Dat_Sec As String

            substs = ""
            Dat_Sec = Data_Description_Section
            Data_Description_Section = ""

            ' Encode Section 1 - Identification Section
            section1 = ""
            octets = "00000000"
            ' Octet 1 through 3. Length of section 1 - . There are 24 octets as per version 12 onwards
            section1 = Decimal_Binary(24, 24)
            ' Octet 4. BURF Master table. It is Zero for Meteorology maintained by WMO
            section1 = section1 & Decimal_Binary(0, 8)
            ' Octet 5 - 6. Identification of originating centre / generating center (defined in common table C-11)
            section1 = section1 & Decimal_Binary(Val(txtOriginatingGeneratingCentre.Text), 16)
            ' Octet 7 and 8. Identification of originating centre / generating sub_center (defined in common table C-12)
            section1 = section1 & Decimal_Binary(Val(txtOriginatingGeneratingSubCentre.Text), 16)
            ' Octet 9. Update sequence number (Zero for original BUFR message; incremented for updates)
            section1 = section1 & Decimal_Binary(Val(txtUpdateSequenceNumber.Text), 8)
            ' Octet 10. Status for optional section. Bit 1=0 No option section; =1 Option section. Bit 2-8 set to zero (reserved)
            If chkOptionalSectionInclusion.Checked = True Then
                section1 = section1 & "10000000"
            Else
                section1 = section1 & "00000000"
            End If

            ' Octet 11. Data category
            section1 = section1 & Decimal_Binary(Val(txtDataCategory.Text), 8)
            ' Octet 12. International data sub-category (defined in table C-13)
            section1 = section1 & Decimal_Binary(Val(txtInternationalDataSubCategory.Text), 8)
            ' Octet 13. Local data sub-category (defined locally by ADP centers)
            section1 = section1 & Decimal_Binary(Val(txtLocalDataSubCategory.Text), 8)
            ' Octet 14. Version number of master table currently (Currently 12 for WMO BUFR FM 94 BUFR tables)
            section1 = section1 & Decimal_Binary(Val(txtMastersTableVersionNumber.Text), 8)
            ' Octet 15. Version number of local tables used to augment master table in use
            section1 = section1 & Decimal_Binary(Val(txtLocalTableVersionNumber.Text), 8)
            ' Octet 16 - 17. Year (4 digits)
            section1 = section1 & Decimal_Binary(Val(txtYear.Text), 16)
            ' Octet 18. Month
            section1 = section1 & Decimal_Binary(Val(cboMonth.Text), 8)
            ' Octet 19. Day
            section1 = section1 & Decimal_Binary(Val(cboDay.Text), 8)
            ' Octet 20. Hour
            section1 = section1 & Decimal_Binary(Val(cboHour.Text), 8)
            ' Octet 21. Minute
            section1 = section1 & Decimal_Binary(0, 8)
            ' Octet 22. Second
            section1 = section1 & Decimal_Binary(0, 8)
            ' Octet 23. Reserved for local use by ADP Centre
            section1 = section1 & Decimal_Binary(0, 8)
            ' Octet 24. Set to zero
            section1 = section1 & Decimal_Binary(0, 8)
            ' Compute Section 2 - Option section if it exist
            section2 = ""
            ' Octet 1 - 3. Length of section
            ' Octet 4 Set to Zero (Reserved)
            ' Octet 5 onwards. Reserved for use by ADP centres

            ' Compute Section 3 - Data Description Section.
            Dim data_descriptor, f, x, y As String

            section3 = ""
            'Convert Descriptors to binary - Descriptor for the Template used. 16 bits for a descriptor = 2 Octets
            data_descriptor = Strings.Right(cboTemplate.Text, 6)            'TM_307081
            f = Decimal_Binary(Strings.Left(data_descriptor, 1), 2)    ' Descriptor type
            x = Decimal_Binary(Strings.Mid(data_descriptor, 2, 2), 6) ' Descriptor Class
            y = Decimal_Binary(Strings.Mid(data_descriptor, 4, 3), 8) ' Entry in Class X

            data_descriptor = f & x & y     ' Complete Descriptor in binary

            ' Octet 1 - 3. Length of section. Total of 9 Octets. 1 Octet to be added to make them even
            section3 = section3 & Decimal_Binary(10, 24)
            ' Octet 4. Reserved (Set to Zero)
            section3 = section3 & Decimal_Binary(0, 8)
            ' Octet 5 - 6. Number of Subsets

            section3 = section3 & Decimal_Binary(Val(subsets), 16)

            ' Octet 7. Type of data. Bit 1, = 1 observed = 0 Other. Bit 2 = 1 Compressed, = 0 non-compressed. Bit 3-8 reserved (set to zero)
            octets = "00000000"
            Mid(octets, 1) = 1
            Mid(octets, 2) = 0
            section3 = section3 & octets
            ' Octet 8 -9 data descriptors - 2 octets
            section3 = section3 & data_descriptor
            ' Octet 10. An extra octet to make total octets even
            section3 = section3 & "00000000"

            'Compute Section 4 - Data Section
            Dim xtrbits As Integer
            Dim siz As Integer

            'Dim binary_data As String

            section4 = ""

            ' Compute the extra bits required to have complete octets
            xtrbits = Len(binary_data) Mod 8

            If xtrbits = 0 Then ' No Extra bit required
                siz = (Len(binary_data) - xtrbits) / 8
            Else ' Append zeros to attain the extra bits required
                For i = 1 To 8 - xtrbits
                    binary_data = binary_data & "0"
                Next
                siz = Len(binary_data) / 8
            End If

            ' Complete the data section with even number of octets
            If siz Mod 2 <> 0 Then
                siz = siz + 1
                binary_data = binary_data & "00000000"
            End If

            ' Octet 1-3. Lenth of section - Octet 1, 2, 3, 4(reserved) and binary data stream
            section4 = section4 & Decimal_Binary(4 + siz, 24)
            ' Octet 4. Reserved (set to zero)
            section4 = section4 & "00000000"
            ' Octet 5 onwards
            section4 = section4 & binary_data

            ' Compute section 5 - End Section
            ' Octet 1-4 "7777" (coded according to CCITT International Alphabet No. 5)

            section5 = ""
            section5 = section5 & CCITT_Binary(conn1, "7777", 32)

            ' Compute the BUFR message less section 0
            Dim BUFR_Message As String
            BUFR_Message = section1 & section2 & section3 & section4 & section5

            ' Encode Section 0 - Indicator Section
            section0 = ""
            ' Octet 1 - 4.  "BUFR" (coded according to CCITT International Alphabet No. 5)
            section0 = section0 & CCITT_Binary(conn1, "BUFR", 32)
            ' Octet 5-7 Total length of BUFR message, in octets (including Section 0). Section 0 has 8 octets
            siz = (Len(BUFR_Message) + 64) / 8
            section0 = section0 & Decimal_Binary(siz, 24)
            ' Octet 8 - Bufr edition number
            section0 = section0 & Decimal_Binary(Val(txtBUFREditionNumber.Text), 8)


            ' Define communications controls for BUFR message in FTP GTS structure

            Dim nnn, SOH, CR, LF, SP, ETX, Format_Id0, Format_Id1, dummy_msg, nulls As String

            nnn = CCITT_Binary(conn1, "001", 24)

            SOH = "00000001" ' Start Of Header
            CR = "00001101" ' Carriage Return
            LF = "00001010" ' Line Feed
            SP = "00100000" ' SPace
            ETX = "00000011" ' End of TeXt
            Format_Id0 = "0011000000110000"
            Format_Id1 = "0011000000110001"
            dummy_msg = "0011000000110000001100000011000000110000001100000011000000110000"
            nulls = "00000000"

            ' Compute message communication header in CCITT A5
            Dim comms_header As String
            Dim message_length As String
            Dim Bufr_Message_With_Controls As String

            comms_header = CCITT_Binary(conn1, msg_header, Len(msg_header) * 8)

            'Case where Format Identifier 00 is used
            BUFR_Message = section0 & section1 & section2 & section3 & section4 & section5
            Bufr_Message_With_Controls = SOH & CR & CR & LF & nnn & CR & CR & LF & comms_header & CR & CR & LF & BUFR_Message & CR & CR & LF & ETX
            message_length = Strings.Format(Str(Len(Bufr_Message_With_Controls) / 8), "00000000")
            BUFR_Message = CCITT_Binary(conn1, message_length, 64) & Format_Id0 & Bufr_Message_With_Controls & dummy_msg

            ' Display binary digital data for viewing
            txtEncoded.Text = BUFR_Message

            ' Output to text files
            Dim txtbufr, octsfl, bufr_file As String

            txtbufr = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.txt"
            FileOpen(2, txtbufr, OpenMode.Output)

            Print(2, BUFR_Message) ' Put the BUFR binary digit message into a text file

            FileClose(2)

            'Construct and open Bufr output text file based on the message header
            bufr_file = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & msg_file & ".f"
            FileOpen(2, bufr_file, OpenMode.Binary)

            octsfl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_octets.txt"
            FileOpen(1, octsfl, OpenMode.Output)

            'Output BUFR data into a binary and a text file
            Dim byt As String
            Dim kounter As Long
            byt = ""
            kounter = 1
            For i = 1 To Len(BUFR_Message) Step 8
                FilePut(2, Binary_Decimal(Strings.Mid(BUFR_Message, i, 8)), kounter)
                PrintLine(1, kounter & "," & Strings.Mid(BUFR_Message, i, 8))
                kounter = kounter + 1
            Next

            FileClose(1)
            FileClose(2)

            'FileOpen(1, bufr_file, OpenMode.Input) ' For Input As #1
            'Dim bin_out, dat As String
            'bin_out = ""
            'Do While EOF(1) = False
            '    dat = LineInput(1)
            '    bin_out = bin_out & dat
            'Loop
            'frm.txt_coded = bin_out
            'FileClose(1)

            txtMsgbFile.Text = bufr_file
            txtEncoded.Text = BUFR_Message

            '' Output expanded decsriptors into a CSV file
            ''Dim fldscrpt As String
            'descriptors_file = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv"
            'FileOpen(2, descriptors_file, OpenMode.Append)

            'Dim counts As Integer
            'Dim obsv As String

            'counts = 1
            'sql = "select * from bufr_crex_data where selected =1 order by nos;"

            'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            'ds.Clear()
            'da.Fill(ds, "bufr_coded")


            'With ds.Tables("bufr_coded")

            '    Write(2, "NO", "ELEMENT DESCRIPTOR", "ELEMENT NAME", "UNIT", "SCALE", "REF VALUE", "WIDTH", "OBSERVATION", "BINARY DATA")
            '    PrintLine(2)
            '    For i = 0 To .Rows.Count - 1
            '        If Len(.Rows(i).Item("Observation")) = 0 Then
            '            obsv = "MISSING"
            '        Else
            '            obsv = .Rows(i).Item("Observation")
            '        End If

            '        Write(2, Format(counts, "000"), "'" & .Rows(i).Item("Bufr_Element") & "'", .Rows(i).Item("Element_Name"), .Rows(i).Item("Bufr_Unit"), .Rows(i).Item("Bufr_Scale"), .Rows(i).Item("Bufr_RefValue"), .Rows(i).Item("Bufr_DataWidth_Bits"), obsv, "'" & .Rows(i).Item("Bufr_Data") & "'")
            '        counts = counts + 1
            '        PrintLine(2)
            '    Next
            '    FileClose(2)
            'End With

            BUFR_Code = True

        Catch ex As Exception
            If ex.Message = "" Then
                MsgBox("BUFR Coding Error")
            Else
                MsgBox(ex.Message)
            End If
            FileClose(2)
        End Try

    End Function

    Private Sub cmdViewDecsriptors_Click(sender As Object, e As EventArgs) Handles cmdViewDecsriptors.Click
        If System.IO.File.Exists(descriptors_file) Then
            CommonModules.ViewFile(descriptors_file)
        Else
            MsgBox("Can't locate descriptors")
        End If
    End Sub

    Private Sub txtEncoded_TextChanged(sender As Object, e As EventArgs) Handles txtEncoded.TextChanged
        If Len(txtEncoded.Text) > 0 Then
            cmdViewDecsriptors.Enabled = True
        Else
            cmdViewDecsriptors.Enabled = False
        End If
    End Sub

    Private Sub cmdSend_Click(sender As Object, e As EventArgs) Handles cmdSend.Click

        Me.Cursor = Cursors.WaitCursor
        ' Get server details
        Try
            'dbConnectionString = frmLogin.txtusrpwd.Text
            'dbconn.ConnectionString = dbConnectionString
            'dbconn.Open()

            sql = "SELECT * FROM aws_mss"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "server")
            Kount = ds.Tables("server").Rows.Count
            'MsgBox(Kount)
            If Kount = 0 Then
                MsgBox("No server located")
                Exit Sub
            Else
                Dim bufr_file, url, login, pwd, foldr, fmode As String
                bufr_file = txtMsgbFile.Text
                url = ds.Tables("server").Rows(0).Item("ftpId")
                login = ds.Tables("server").Rows(0).Item("userName")
                pwd = ds.Tables("server").Rows(0).Item("password")
                foldr = ds.Tables("server").Rows(0).Item("inputFolder")
                fmode = ds.Tables("server").Rows(0).Item("ftpMode")

                If Not FTP_Execute(bufr_file, url, login, pwd, foldr, fmode, "put") Then
                    MsgBox("FTP Failure")
                Else
                    MsgBox("File Sent")
                End If

            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        ' FTP Access

    End Sub


    Function FTP_Execute(ftpfile As String, ftp_host As String, usr As String, pwd As String, flder As String, ftpmode As String, ftpmethod As String) As Boolean

        'MsgBox(ftpfile & " " & ftpmethod)
        FTP_Execute = True

        Dim ftpscript As String
        Dim txtinputfile, ftpbatch As String
        Dim Drive1 As String
        Dim local_folder As String
        Me.Cursor = Cursors.WaitCursor
        Try

            'MsgBox(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)

            local_folder = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
            Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
            Drive1 = Strings.Left(Drive1, Len(Drive1) - 1)
            ftpscript = local_folder & "\ftp_bufr.txt"
            FileOpen(1, ftpscript, OpenMode.Output)

            Select Case ftpmethod
                Case "get"

                    txtinputfile = local_folder & "\" & System.IO.Path.GetFileName(ftpfile)

                    'MsgBox(ftpmode & " " & txtinputfile)

                    If ftpmode = "psftp" Then Print(1, "cd " & flder & Chr(13) & Chr(10)) 'Print #1, "cd " & in_folder

                    If ftpmode = "FTP" Then
                        Print(1, "open " & ftp_host & Chr(13) & Chr(10))
                        Print(1, usr & Chr(13) & Chr(10))
                        Print(1, pwd & Chr(13) & Chr(10))
                        Print(1, "cd " & flder & Chr(13) & Chr(10))
                        Print(1, "bin" & Chr(13) & Chr(10))
                    End If
                    Print(1, ftpmethod & " " & ftpfile & Chr(13) & Chr(10))
                    Print(1, "bye" & Chr(13) & Chr(10))
                Case "put"
                    'MsgBox(ftpmode & " " & ftpfile)
                    If ftpmode = "psftp" Then Print(2, "cd " & flder & Chr(13) & Chr(10))
                    If ftpmode = "FTP" Then
                        Print(1, "open " & ftp_host & Chr(13) & Chr(10))
                        Print(1, usr & Chr(13) & Chr(10))
                        Print(1, pwd & Chr(13) & Chr(10))
                        Print(1, "cd " & flder & Chr(13) & Chr(10))
                        Print(1, "bin" & Chr(13) & Chr(10))
                    End If
                    Print(1, ftpmethod & " " & ftpfile & Chr(13) & Chr(10))
                    Print(1, "bye" & Chr(13) & Chr(10))
            End Select
            FileClose(1)

            '        ' Create batch file to execute FTP script
            ftpbatch = local_folder & "\ftp_tdcf.bat"

            FileOpen(1, ftpbatch, OpenMode.Output)

            Print(1, "echo off" & Chr(13) & Chr(10))
            Print(1, Drive1 & Chr(13) & Chr(10))
            Print(1, "CD " & local_folder & Chr(13) & Chr(10))

            If ftpmethod = "get" Then
                If ftpmode = "FTP" Then Print(1, ftpmode & " -v -s:ftp_bufr.txt" & Chr(13) & Chr(10))
                'If ftpmode = "FTP" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
                If ftpmode = "PSFTP" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_bufr.txt" & Chr(13) & Chr(10))
            Else
                If ftpmode = "FTP" Then Print(1, ftpmode & " -v -s:ftp_bufr.txt" & Chr(13) & Chr(10))
                'If ftpmode = "FTP" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
                If ftpmode = "PSFTP" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_bufr.txt" & Chr(13) & Chr(10))
            End If

            Print(1, "echo on" & Chr(13) & Chr(10))
            Print(1, "EXIT" & Chr(13) & Chr(10))
            FileClose(1)

            ' Execute the batch file to transfer the aws data file from aws server to a local folder

            Shell(ftpbatch, vbMinimizedNoFocus)

            'If System.IO.Path.GetFileName(ftpfile).Length = 0 Then Exit Function

            'Log_Errors(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
            FTP_Execute = False
            Me.Cursor = Cursors.Default
        End Try
    End Function
End Class