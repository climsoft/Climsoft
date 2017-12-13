Public Class frmSynopTDCF
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim recUpdate As New dataEntryGlobalRoutines

    Dim ds As New DataSet
    Dim sql, msg_header, mmm As String
    Dim rec As Integer
    Dim Kount As Integer

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
        Dim tmplate As String

        Me.Cursor = Cursors.WaitCursor
        Try
            'cboHour_TextChanged()

            '        ' All data must be provided

            If cboStation.Text = "" Or txtYear.Text = "" Or cboMonth.Text = "" Or cboDay.Text = "" Or cboHour.Text = "" Then
                MsgBox("One or more values not entered, Please Confirm.", vbInformation, "Missing Value(s)")
                Exit Sub
            End If

            '        'On Error Resume Next 'GoTo Err
            '        Dim dbase As String
            '        Dim qry As QueryDefx
            '        Dim db As dao.Database
            '        Dim rs As dao.Recordset
            '        Dim rsbx As dao.Recordset
            '        Dim rsbx1 As dao.Recordset
            '        Dim vals As String
            '        Dim sql As String
            '        Dim rep1 As Integer
            '        Dim rep2 As Integer
            '        Dim Bufr_DataSection As String

            '        'dbase = frm_keyentry.datafile

            '        If Not clicom.read_registry("key05", dbase) Then Exit Sub

            '        db = dao.OpenDatabase(dbase)


            '        If Not clicom.table_exist(txttemplate, dbase) Then
            '            MsgBox("Template " & txttemplate & " not found")
            '            Exit Sub
            '        End If

            '        'sql = "SELECT " & txttemplate & ".order, " & txttemplate & ".Crex_Descriptor0, " & txttemplate & ".Crex_Descriptor1, " & txttemplate & ".Crex_Descriptor, " & txttemplate & ".Crex_Element, " & txttemplate & ".Climsoft_Element, " & txttemplate & ".Element_Description, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & txttemplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data INTO bufr_crex_data FROM " & txttemplate & " INNER JOIN bufr_crex_master ON " & txttemplate & ".Crex_Element = bufr_crex_master.Crex_Fxxyyy ORDER BY " & txttemplate & ".order;"
            '        'sql = "SELECT " & "TM_307081.order, TM_307081.Bufr_Template, TM_307081.Crex_Template, TM_307081.Sequence_Descriptor1, TM_307081.Sequence_Descriptor0, TM_307081.Bufr_Element, TM_307081.Crex_Element, TM_307081.Climsoft_Element, TM_307081.Element_Description, TM_307081.synop_code, TM_307081.unit, TM_307081.scale, TM_307081.width, TM_307081.units_length_scale, TM_307081.data_type, TM_307081.selected, TM_307081.observation, TM_307081.Crex_Data, TM_307081.Bufr_Data from TM_307081 ORDER BY TM_307081.order;"
            tmplate = cboTemplate.Text
            'sql = "SELECT " & cboTemplate.Text & ".order, " & tmplate & ".Bufr_Template, " & tmplate & ".Crex_Template, " & tmplate & ".Sequence_Descriptor1," & tmplate & ".Sequence_Descriptor0," & tmplate & ".Bufr_Element, " & tmplate & ".Crex_Element, " & tmplate & ".Climsoft_Element, " & tmplate & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & tmplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data INTO bufr_crex_data FROM " & tmplate & " INNER JOIN bufr_crex_master ON " & tmplate & ".Crex_Element = bufr_crex_master.Crex_Fxxyyy ORDER BY " & tmplate & ".order;"
            sql = "DROP TABLE IF EXISTS bufr_crex_data; CREATE TABLE bufr_crex_data AS SELECT " & tmplate & ".nos, " & tmplate & ".Bufr_Template, " & tmplate & ".Crex_Template, " & tmplate & ".Sequence_Descriptor1," & tmplate & ".Sequence_Descriptor0," & tmplate & ".Bufr_Element, " & tmplate & ".Crex_Element, " & tmplate & ".Climsoft_Element, " & tmplate & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & tmplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data FROM " & tmplate & " INNER JOIN bufr_crex_master ON " & tmplate & ".Bufr_Element = bufr_crex_master.Bufr_FXY ORDER BY " & tmplate & ".nos;"

            'MsgBox(sql)

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
            Dim subsets, sss, fl1, fl2 As String

            substs = Val(cboStation.Items.Count)

            subsets = Format(substs, "000")
            sss = subsets 'Format(substs, "000")
            '       

            '        rs.MoveFirst()


            fl1 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\crex_subsets.txt"
            fl2 = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_subsets.txt"

            FileOpen(10, fl1, OpenMode.Append)
            FileOpen(20, fl2, OpenMode.Output)


            '        ' Loop through the subsets
            For i = 0 To cboStation.Items.Count - 1
                '        Do While rs.EOF = False
                substs = substs - 1

                ' Set the replicated elements according to observations per subset

                Set_Replications(dbconn)

                '  Update Station name to enable retrieval of the station details from the station table
                sql = "update bufr_crex_data set Observation = '" & cboStation.Items.Item(i) & "' where Climsoft_Element = 'station_name';"

                'Create and Execute query to update station name
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

                objCmd.ExecuteNonQuery()

                sql = "select wmoid, latitude, longitude, elevation,qualifier from station where stationName = 'DAGORETTI CORNER METEOROLOGICAL STATION';"



                '            sql = "SELECT lookup_station.id, lookup_station.station_name AS observation, Left([id_alias],2) AS block, Right([id_alias],3) AS [number], IIf([qualifier]=""AUTOMATIC"",2 Or [qualifier]<>""AUTOMATIC"",1) AS type, lookup_location.latitude AS lat, lookup_location.longitude AS lon, lookup_location.elevation AS height FROM (lookup_station INNER JOIN lookup_stationid_alias ON lookup_station.id = lookup_stationid_alias.refers_to) INNER JOIN lookup_location ON lookup_station.id = lookup_location.occupied_by " & _
                '                  "WHERE (((lookup_station.station_name)=""" & rs.Fields("station_name") & """) AND ((lookup_stationid_alias.belongs_to)=""wmo_id""));"

                '            If clicom.query_exist("qry_crex_location", dbase) Then db.QueryDefs.Delete("qry_crex_location")
                '            qry = db.CreateQueryDef("qry_crex_location", sql)

                '            ' Set the recordset to the location query
                '            rsbx1 = db.OpenRecordset("qry_crex_location")

                '            'The following statement helps to skip a record without location. But it has been found to work similarly with resume next on empty record error
                '            'If rsbx1.RecordCount = 0 Then GoTo NextSubset

                '            ' Determine whether it a is sysnoptic station
                '            If IsNull(rsbx1.Fields("block")) Then
                '                MsgBox("Can't Code. WMO Station Number not found")
                '                Exit Sub
                '                ' If MsgBox("Not a Synoptic station. Continue?", vbYesNo, "Synop Crex") = vbNo Then Exit Sub
                '            End If

                '            'Update Data with the synop_crex form
                '            With rsbx
                '                .MoveFirst()
                '                Do While .EOF = False
                '                    ' Update Station Name, Observation times and Instrument parameters from the synop interface form
                '                    .Edit()
                '                    Select Case .Fields("Climsoft_Element")
                '                        '        Case "station_WMO_bloc"
                '                        '           .Fields("Observation") = rsbx1.Fields("bloc")
                '                        '        Case "station_WMO_number"
                '                        '           .Fields("Observation") = rsbx1.Fields("number")
                '                        Case "station_name"
                '                            .Fields("Observation") = rs.Fields("station_name") 'txtstation
                '                        Case "datetime_year"
                '                            .Fields("observation") = Format(rs.Fields("yyyy"), "0000") 'Format(txtyear, "0000")
                '                        Case "datetime_month"
                '                            .Fields("observation") = Format(rs.Fields("mm"), "00") 'Format(txtmonth, "00")
                '                        Case "datetime_day"
                '                            .Fields("observation") = Format(rs.Fields("dd"), "00") 'Format(txtday, "00")
                '                        Case "datetime_hour"
                '                            .Fields("observation") = Format(rs.Fields("hh"), "00") 'Format(txthour, "00")
                '                        Case "datetime_minute"
                '                            .Fields("observation") = Format(txtminute, "00")
                '                            '        Case "5"
                '                        Case "Temp_SH" ' Sensor height for temperature measurement
                '                            If txtth = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level")  'txtth
                '                            End If
                '                        Case "Vis_SH" ' Sensor height for visibility measurement
                '                            If txtvh = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "VISIB_I", "instal_level") 'txtvh
                '                            End If
                '                        Case "R24_SH" ' Sensor height for precipitation measurement
                '                            If txtrh = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
                '                            End If
                '                        Case "xt_SH" ' Sensor height for extreme temperature measurement
                '                            If txtth = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "TEMP_I", "instal_level") 'txtth
                '                            End If
                '                        Case "w_SH" ' Sensor height for wind measurement
                '                            If txtwh = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instal_level") 'txtwh
                '                            End If
                '                        Case "ww_TP" ' Time Period for Past and Present Weather
                '                            If CLng(Hour(txthour)) Mod 6 = 0 Then
                '                                .Fields("observation") = -6
                '                            Else
                '                                .Fields("observation") = -3
                '                            End If
                '                        Case "tR_TP" ' Time Period for precipitation replication 1
                '                            .Fields("observation") = Rain_Diplacement(CInt(Left(txthour, 2))) '-24
                '                        Case "tr_TP"  ' Time Period for precipitation replication 2
                '                            .Fields("observation") = -3
                '                        Case "evap_TP" ' Time Period for evaporation
                '                            .Fields("observation") = -24
                '                        Case "evap_I"
                '                            .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "EVAP_I", "instrument_type") 'txtit
                '                        Case "SSS_TP" ' Time Period for sunshine replication 1
                '                            .Fields("observation") = -24
                '                        Case "SS_TP" ' Time Period for sunshine replication 2
                '                            .Fields("observation") = -1
                '                        Case "RR_SH" ' Sensor height for precipitation for the replications
                '                            If txtrh = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "PRECIP_I", "instal_level") 'txtrh
                '                            End If
                '                            '        Case "w_SH"
                '                            '           .Fields("observation") = txtwh
                '                        Case "w_I"
                '                            .Fields("observation") = Get_Instrument("station_instrument", rs.Fields("station_id"), "WIND_I", "instrument_type") ' txtwi  Get_Instrument("station_instrument", rs, "BARO_I", "instal_level")
                '                        Case "xt_TP" ' Time Period for maximum temperature
                '                            .Fields("observation") = -12
                '                        Case "xt0_TP" ' Time Period for maximum temperature ending at nominal time of the report
                '                            .Fields("observation") = 0
                '                        Case "nt_TP" ' Time Period for minimum teperature
                '                            .Fields("observation") = -12
                '                        Case "nt0_TP" ' Time Period for minimum teperature ending at nominal time of the report
                '                            .Fields("observation") = -0
                '                        Case "w_TS" ' Time Significance for wind
                '                            .Fields("observation") = 2
                '                        Case "w_TP" ' Time Period for wind
                '                            .Fields("observation") = -10
                '                        Case "evap_SH" ' Sensor height for Evaporation/Evatranspiration
                '                            If txtrh = "" Then
                '                                .Fields("observation") = "/"
                '                            Else
                '                                .Fields("observation") = txtrh
                '                            End If
                '                        Case "rad1_TP"
                '                            .Fields("observation") = -1
                '                        Case "rad2_TP"
                '                            .Fields("observation") = -24
                '                        Case "tempc_t" ' Time Period for Past and Present Weather
                '                            If CLng(Hour(txthour)) Mod 6 = 0 Then
                '                                .Fields("observation") = -6
                '                            Else
                '                                .Fields("observation") = -3
                '                            End If
                '                    End Select
                '                    .Update()

                '                    ' Update with entered observations for each subset
                '                    For i = 0 To rs.Fields.count - 1
                '                        obsv = ""
                '                        If rs.Fields(i).name = rsbx.Fields("Climsoft_Element") Then
                '                            obsv = rs.Fields(i)

                '                            ' Scaling pressure and Radiation values
                '                            If rs.Fields(i).name = "137" And obsv <> "" Then obsv = obsv & "000000"
                '                            If rs.Fields(i).name = "106" Or rs.Fields(i).name = "107" Or rs.Fields(i).name = "399" Or rs.Fields(i).name = "301" Or rs.Fields(i).name = "400" Then
                '                                If obsv <> "" Then
                '                                    obsv = CLng(rs.Fields(i)) * 100
                '                                End If
                '                            End If

                '                            .Edit()
                '                            .Fields("observation") = obsv
                '                            .Update()
                '                        End If
                'Nexxt:
                '                    Next i

                '                    .MoveNext()
                '                Loop

                '                ' Compute cloud layers replication factor
                '                rep1 = 0
                '                rp2 = 0
                '                .MoveFirst()
                '                Do While .EOF = False
                '                    Select Case .Fields("Climsoft_Element")
                '                        ' Cloud layers above station level
                '                        Case "116"  'Cloud amount; first layer present
                '                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
                '                        Case "120"  'Cloud amount; second second layer present
                '                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
                '                        Case "124"  'Cloud amount; third layer present
                '                            If .Fields("observation") <> "" Then rep1 = rep1 + 1
                '                        Case "128"  'Cloud amount; fourth layer present
                '                            If .Fields("observation") <> "" Then rep1 = rep1 + 1

                '                            ' Cloud layers below station level
                '                        Case "612"  'Cloud amount; first layer present
                '                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
                '                        Case "622"  'Cloud amount; second second layer present
                '                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
                '                        Case "632"  'Cloud amount; third layer present
                '                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
                '                        Case "642"  'Cloud amount; fourth layer present
                '                            If .Fields("observation") <> "" Then rep2 = rep2 + 1
                '                    End Select
                '                    .MoveNext()
                '                Loop

                '                ' Update station location, elevation, pressure change characteristic and clouds replication factors
                '                Dim vertical_sig As String
                '                .MoveFirst()
                '                rsbx1.MoveFirst()
                '                Do While .EOF = False
                '                    vertical_sig = ""
                '                    .Edit()
                '                    Select Case .Fields("Climsoft_Element")
                '                        Case "station_WMO_bloc"
                '                            .Fields("observation") = rsbx1.Fields("block")
                '                        Case "station_WMO_number"
                '                            .Fields("observation") = rsbx1.Fields("number")
                '                        Case "station_qualifier"
                '                            .Fields("observation") = rsbx1.Fields("type")
                '                        Case "station_deglatitude"
                '                            .Fields("observation") = rsbx1.Fields("lat")
                '                        Case "station_deglongitude"
                '                            .Fields("observation") = rsbx1.Fields("lon")
                '                        Case "station_elevation"
                '                            .Fields("observation") = rsbx1.Fields("height")
                '                        Case "station_pressure_height"
                '                            .Fields("observation") = Val(rsbx1.Fields("height")) + Val(Get_Instrument("station_instrument", rs.Fields("station_id"), "BARO_I", "instal_level")) 'CInt(txtbr)
                '                        Case "cloud_rep1"
                '                            .Fields("observation") = rep1
                '                        Case "cloud_rep2"
                '                            .Fields("observation") = rep2
                '                        Case "532"
                '                            If Not IsNull(.Fields("observation")) Then .Fields("observation") = CInt(.Fields("observation")) * 60 'Sunshine minutes
                '                        Case "114"
                '                            If Not IsNull(.Fields("observation")) Then .Fields("observation") = Val(.Fields("observation")) * 12.5 'Total Cloud Cover
                '                    End Select
                '                    .Update()
                '                    .MoveNext()
                '                Loop

                '                ' Format for Trace rainfall if it exist

                '                ' Trace for 24 Hour Precipation
                '                .MoveFirst()
                '                Do While .EOF = False
                '                    If .Fields("Climsoft_Element") = "5" And Trace24hr = True Then
                '                        .Edit()
                '                        .Fields("observation") = -1
                '                        .Update()
                '                    End If
                '                    .MoveNext()
                '                Loop

                '                ' Trace for 3 Hour Precipation
                '                .MoveFirst()
                '                Do While .EOF = False
                '                    If .Fields("Climsoft_Element") = "174" And Trace3hr = True Then
                '                        .Edit()
                '                        .Fields("observation") = -1
                '                        .Update()
                '                    End If
                '                    .MoveNext()
                '                Loop

                '                ' Update Precipitation characteristic
                '                Dim ChrR As String

                '                ChrR = Precip_Char(rsbx)
                '                .MoveFirst()
                '                Do While .EOF = False
                '                    .Edit()
                '                    If .Fields("Climsoft_Element") = "505" Then
                '                        .Fields("observation") = ChrR
                '                        .Update()
                '                    ElseIf .Fields("Climsoft_Element") = "506" Then
                '                        .Fields("observation") = 9
                '                        .Update()
                '                    End If
                '                    .MoveNext()
                '                Loop

                '                ' Encode data ////////////////////////////////////////////////

                '                .MoveFirst()

                '                Dim miss As Boolean
                '                Dim dats As String


                '                Do While .EOF = False
                '                    If .Fields("observation") <> "" Then
                '                        .Edit()
                '                        .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db))
                '                        .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), .Fields("Observation"), ScaleFactor(.Fields("Climsoft_Element"), db), db)
                '                        .Update()
                '                    End If
                '                    .MoveNext()
                '                Loop

                '                ' Convert Special Cloud data to CREX code
                '                .MoveFirst()

                '                Dim N As String
                '                Dim cl As String
                '                Dim CM As String
                '                Dim CH As String

                '                Do While .EOF = False
                '                    .Edit()
                '                    Select Case .Fields("Climsoft_Element")
                '                        '    Case "114" ' N
                '                        '      If .Fields("observation") <> "" Then N = .Fields("observation")
                '                        '      If .Fields("observation") <> "/" And .Fields("observation") <> "" Then .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CDbl(.Fields("observation")) * 12.5, ScaleFactor(.Fields("Climsoft_Element"), db))  'val (.Fields("observation")) * 12.5
                '                        Case "169" 'Cloud type CL
                '                            If .Fields("observation") <> "" Then
                '                                cl = .Fields("observation")
                '                                If N = "0" Then
                '                                    cl = 30
                '                                ElseIf N = "9" Or N = "/" Or cl = "/" Or cl = "" Then
                '                                    cl = 62
                '                                Else 'ElseIf CH <> "/" And CH <> "" Then
                '                                    cl = CDbl(.Fields("observation")) ' + 30
                '                                End If
                '                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), cl, ScaleFactor(.Fields("Climsoft_Element"), db))
                '                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), cl, ScaleFactor(.Fields("Climsoft_Element"), db), db)
                '                            End If
                '                        Case "170" 'Cloud type CM
                '                            If .Fields("observation") <> "" Then
                '                                CM = .Fields("observation")
                '                                If N = "0" Then
                '                                    CM = 20
                '                                ElseIf N = "9" Or N = "/" Or CM = "/" Or CM = "" Then
                '                                    CM = 61
                '                                Else 'ElseIf CH <> "/" And CH <> "" Then
                '                                    CM = CDbl(.Fields("observation")) '+ 20
                '                                End If
                '                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CM, ScaleFactor(.Fields("Climsoft_Element"), db))
                '                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CM, ScaleFactor(.Fields("Climsoft_Element"), db), db)
                '                            End If
                '                        Case "171" 'Cloud type CH
                '                            If .Fields("observation") <> "" Then
                '                                CH = .Fields("observation")
                '                                If N = "0" Then
                '                                    CH = 10
                '                                ElseIf N = "9" Or N = "/" Or CH = "/" Or CH = "" Then
                '                                    CH = 60
                '                                Else 'ElseIf CH <> "/" And CH <> "" Then
                '                                    CH = CDbl(.Fields("observation")) ' + 10
                '                                End If
                '                                .Fields("Crex_Data") = Crex_Data(.Fields("Crex_Scale"), .Fields("Crex_DataWidth"), CH, ScaleFactor(.Fields("Climsoft_Element"), db))
                '                                .Fields("Bufr_Data") = Bufr_Data(.Fields("Bufr_Unit"), .Fields("Bufr_Scale"), .Fields("Bufr_RefValue"), .Fields("Bufr_DataWidth_Bits"), CH, ScaleFactor(.Fields("Climsoft_Element"), db), db)
                '                            End If
                '                    End Select
                '                    .Update()
                '                    .MoveNext()
                '                Loop
                '            End With

                '            ' Coded message output

                '            Dim message_header As String

                '            sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
                '                  "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"

                '            message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00")  '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

                '            ' Include BBB if present
                '            If txtBBB <> "" Then message_header = msg_header & " " & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)

                '            ' Structure the output file name in format CCCCNNNNNNNN.ext
                '            msg_file = Right(msg_header, 4) & Format(txtday, "00") & Format(txthour, "00") & Format(txtminute, "00") & Format(txtsecond, "00")

                '            Select Case Me.Caption
                '                Case "CREX Synop"
                '                    If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox("CREX Coding error")
                '                Case "BUFR Synop"
                '                    If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox("Error in encoding Data Section")
                '            End Select


                '            ' Coded message output

                '            'Dim message_header As String
                '            '
                '            'sql = "SELECT bufr_crex_data.order, bufr_crex_data.Bufr_Template, bufr_crex_data.Crex_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data FROM bufr_crex_data " & _
                '            '      "WHERE ((bufr_crex_data.selected)=True) ORDER BY bufr_crex_data.order;"
                '            '
                '            'message_header = msg_header & " " & Format(day(Date), "00") & Format(txthour, "00") & Format(txtminute, "00") & " " & txtBBB '& Format(Hour(Time) & "00") & "00" ' & Format(Minute(Time), "00")  'Format(txtday, "00") & Left(txthour, 2) & Right(txthour, 2)
                '            '
                '            'Select Case Me.Caption
                '            ' Case "CREX Synop"
                '            '   If Not CREX_Code(sql, message_header, crex_indicators, check_digit.value, substs) Then MsgBox "CREX Coding error"
                '            ' Case "BUFR Synop"
                '            '   If Not Bufr_Section4(sql, Bufr_DataSection) Then MsgBox "Error in encoding Data Section"
                '            'End Select
                '            '
                'NextSubset:
                '            rs.MoveNext()
                '        Loop
            Next i




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
            '                    If Not BUFR_Code(sql, message_header, Me, db, Bufr_DataSection) Then MsgBox("BUFR Coding error")
            '                End If
            '        End Select

            'Close #10
            'Close #20

            '        Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
        'Close #10
        'Close #20
        '        Screen.MousePointer = vbDefault
        'MsgBox("Finished")
        Me.Cursor = Cursors.Default

    End Sub
    Sub Bufr_Crex_Initialize(conn1 As MySql.Data.MySqlClient.MySqlConnection)

        Dim sql As String

        Try

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
    Sub Set_Replications(conn1 As MySql.Data.MySqlClient.MySqlConnection)

        sql = "Select * from bufr_crex_data"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "bufr_crex_data")

        Initialize_Cloud_Replications(conn1, ds, 4, "119", "cloud_rep1") 'Delayed replication of cloud layers above station level 4 times for a maximum of 4 layers

        Initialize_Cloud_Replications(conn1, ds, 5, "611", "cloud_rep2") 'Delayed replication of cloud layers below station level 4 times for a maximum of 5 layers

        ' Set the replicated cloud layers to TRUE if observations made
        Dim flds As Integer

        sql = "Select * from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

        'sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "from form_synoptic_2_ra1")

        ' Initialize cloud layers by setting them to FALSE so that they are not selected if observations not made
        Kount = ds.Tables("from form_synoptic_2_ra1").Rows.Count
        flds = ds.Tables("from form_synoptic_2_ra1").Columns.Count

        With ds.Tables("from form_synoptic_2_ra1")
            For i = 0 To Kount - 1
                ' Replications for clounds above the station
                If Len(.Rows(i).Item("Val_Elem119")) > 0 Then Select_Descriptor(conn1, "119", "cloud_rep1")
                If Len(.Rows(i).Item("Val_Elem123")) > 0 Then Select_Descriptor(conn1, "123", "cloud_rep1")
                If Len(.Rows(i).Item("Val_Elem127")) > 0 Then Select_Descriptor(conn1, "127", "cloud_rep1")
                If Len(.Rows(i).Item("Val_Elem131")) > 0 Then Select_Descriptor(conn1, "131", "cloud_rep1")

                ' Replications for clounds below the station
                'If Len(.Rows(i).Item("Val_Elem611")) > 0 Then Select_Descriptor(conn1, "611", "cloud_rep2")
                'If Len(.Rows(i).Item("Val_Elem621")) > 0 Then Select_Descriptor(conn1, "621", "cloud_rep2")
                'If Len(.Rows(i).Item("Val_Elem631")) > 0 Then Select_Descriptor(conn1, "631", "cloud_rep2")
                'If Len(.Rows(i).Item("Val_Elem641")) > 0 Then Select_Descriptor(conn1, "641", "cloud_rep2")
            Next
        End With
    End Sub
    Sub Update_Station_Details(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)
        Dim wmo_block, wmo_No, lat, lon, elev, typ As String
        sql = "select wmoid, latitude, longitude, elevation, qualifier from station where stationName = '" & stn & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ds.Clear()
        da.Fill(ds, "stations")

        wmo_block = Strings.Left(ds.Tables("stations").Rows(0).Item("wmoid"), 2)
        wmo_No = Strings.Right(ds.Tables("stations").Rows(0).Item("wmoid"), 3)
        lat = ds.Tables("stations").Rows(0).Item("latitude")
        lon = ds.Tables("stations").Rows(0).Item("longitude")
        elev = ds.Tables("stations").Rows(0).Item(" elevation")
        typ = ds.Tables("stations").Rows(0).Item("qualifier")

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

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub


End Class