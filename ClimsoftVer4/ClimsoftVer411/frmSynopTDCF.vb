Public Class frmSynopTDCF
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim recUpdate As New dataEntryGlobalRoutines
    Dim TDCF As New tdcfRoutines
    Dim ds As New DataSet
    Dim sql, msg_header, msg_file, mmm, Data_Description_Section, descriptors_file As String
    Dim rec, Kount As Integer


    Private Sub frmSynopTDCF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql = "CREATE TABLE IF NOT EXISTS `bufr_indicators` (`BUFR_Edition` int(11) DEFAULT '0',`Originating_Centre` int(11) DEFAULT '0',`Originating_SubCentre` int(11) DEFAULT '0',`Update_Sequence` int(11) DEFAULT '0',`Optional_Section` int(11) DEFAULT '0',`Data_Category` int(11) DEFAULT '0',`Intenational_Data_SubCategory` int(11) DEFAULT '0',`Local_Data_SubCategory` int(11) DEFAULT '0',`Master_table` int(11) DEFAULT '0',`Local_Table` int(11) DEFAULT '0') ENGINE=InnoDB DEFAULT CHARSET=latin1;"
        PopulateForms()
        ClsTranslations.TranslateForm(Me)
    End Sub

    Sub PopulateForms()
        Try
            ' Populate Settings
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            sql = "SELECT * FROM bufr_indicators"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "bufr_indicators")
            Kount = ds.Tables("bufr_indicators").Rows.Count

            ' Pulate the template list
            cboTemplate.Items.Clear()
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

            ' Select the default Template
            For i = 0 To Kount - 1
                If ds.Tables("bufr_indicators").Rows(i).Item("defaultTemplate") = 1 Then
                    cboTemplate.Text = ds.Tables("bufr_indicators").Rows(i).Item("Tmplate")
                    Exit For
                End If

            Next

            ' Populate with MSS details
            sql = "SELECT * FROM aws_mss"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

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
            'PopulateForms()
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
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

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
        Dim tmplate, wsi_desc, stn_wsi_data As String
        PopulateForms()

        Me.Cursor = Cursors.WaitCursor
        Try

            If cboStation.Text = "" Or txtYear.Text = "" Or cboMonth.Text = "" Or cboDay.Text = "" Or cboHour.Text = "" Then
                MsgBox("One or more values not entered, Please Confirm.", vbInformation, "Missing Value(s)")
                Exit Sub
            End If

            tmplate = cboTemplate.Text
            sql = "DROP TABLE IF EXISTS bufr_crex_data; CREATE TABLE bufr_crex_data AS SELECT " & tmplate & ".nos, " & tmplate & ".Bufr_Template, " & tmplate & ".Crex_Template, " & tmplate & ".Sequence_Descriptor1," & tmplate & ".Sequence_Descriptor0," & tmplate & ".Bufr_Element, " & tmplate & ".Crex_Element, " & tmplate & ".Climsoft_Element, " & tmplate & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & tmplate & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data FROM " & tmplate & " INNER JOIN bufr_crex_master ON " & tmplate & ".Bufr_Element = bufr_crex_master.Bufr_FXY ORDER BY " & tmplate & ".Nos;"

            ' Create query Command for creating a new table 'bufr_crex_data'
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()

            'Bufr_Crex_Initialize(dbconn)  'Set all values to missing

            'Set data set
            sql = "Select * from bufr_crex_data"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "bufr_crex_data")

            ' Get the number of subsets
            Dim substs, sss, wsi_sss As Integer
            Dim subset_data, wsi_subset_data, Section4_Data, fl2 As String

            substs = cboStation.Items.Count
            sss = 0 ' Strings.Format(substs, "000")
            wsi_sss = 0

            'MsgBox("Total subsets = " & substs & " > " & subsets)
            'sss = subsets 'Format(substs, "000")
            'MsgBox(sss)
            ' Create folder for output files if not there
            If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data") Then
                IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data")
            End If

            'Create file for subset's data
            fl2 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_subsets.txt"
            FileOpen(20, fl2, OpenMode.Output)

            'Create file to output observations and their encoded binary data
            descriptors_file = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.csv"
            FileOpen(111, descriptors_file, OpenMode.Output)

            FileClose(111)

            'Loop through the subsets
            Section4_Data = ""
            subset_data = ""
            wsi_subset_data = ""
            sss = 0
            wsi_sss = 0

            For i = 0 To cboStation.Items.Count - 1
                Bufr_Crex_Initialize(dbconn)  'Set all values to missing
                Set_Replications(dbconn, cboStation.Items(i))
                Update_Station_Details(dbconn, cboStation.Items(i))
                Update_Instruments_Details(dbconn, cboStation.Items(i))
                Update_Time_Periods(dbconn)
                Update_Observation_data(dbconn, cboStation.Items(i), txtYear.Text, cboMonth.Text, cboDay.Text, cboHour.Text)
                Encode_Bufr(dbconn)
                If Bufr_Section4(dbconn, Section4_Data) Then
                    stn_wsi_data = ""
                    If TDCF.WSI_data(cboStation.Items(i), stn_wsi_data) Then
                        ' Subset data for station with WSI identification
                        wsi_subset_data = stn_wsi_data & wsi_subset_data & Section4_Data
                        wsi_sss = wsi_sss + 1
                    Else
                        subset_data = subset_data & Section4_Data
                        sss = sss + 1
                    End If
                    Output_Data_Code(dbconn, i + 1)
                Else
                    Continue For
                End If
            Next i

            ' Output Bufr coded data if subsets exist

            msg_header = txtMsgHeader.Text & " " & cboDay.Text.PadLeft(2, "0"c) & cboHour.Text.PadLeft(2, "0"c) & "00"

            ' Include BBB if present
            If cboBBB.Text <> "" Then msg_header = msg_header & " " & cboBBB.Text

            ' Structure the output file name in format CCCCNNNNNNNN.ext
            msg_file = Strings.Right(txtMsgHeader.Text, 4) & cboDay.Text.PadLeft(2, "0"c) & cboHour.Text.PadLeft(2, "0"c) & "00" & "00"

            'If Int(sss) > 0 Then
            '    If Not Compute_Descriptors() Or Not BUFR_Code(dbconn, subset_data, sss) Then
            '        MsgBox("Encoding Error")
            '    End If
            'End If

            ' Encode BUFR for stations without WSI identifications
            If Int(sss) > 0 Then
                If Not Compute_Descriptors() Or Not BUFR_Code(dbconn, subset_data, sss) Then
                    MsgBox("Encoding Error")
                End If
            End If

            ' Encode BUFR for stations with WSI
            If Int(wsi_sss) > 0 Then
                If Not Compute_Descriptors(True) Or Not BUFR_Code(dbconn, wsi_subset_data, wsi_sss, True) Then
                    MsgBox("Encoding Error")
                End If
            End If

            dbconn.Close()

            FileClose(20)
            MsgBox("Finished Encoding")
        Catch ex As Exception
            dbconn.Close()
            MsgBox(ex.Message & " " & " cmdEncode")
            Me.Cursor = Cursors.Default
            FileClose(20)
        End Try
        Me.Cursor = Cursors.Default

    End Sub
    Sub Output_Data_Code(conn1 As MySql.Data.MySqlClient.MySqlConnection, sbst As Integer)

        ' Output expanded decsriptors into a CSV file

        'descriptors_file = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv"

        descriptors_file = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.csv"
        FileOpen(2, descriptors_file, OpenMode.Append)

        Dim counts As Integer
        Dim obsv As String

        counts = 1
        sql = "select * from bufr_crex_data where selected =1 order by nos;"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0

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
            'If IO.File.Exists(System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv") Then
            '    IO.File.Delete(System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.csv")

            'End If
            If IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.csv") Then
                IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.csv")
            End If

            sql = "Select * from bufr_crex_data"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

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
            MsgBox(ex.Message & " Bufr_Crex_Initialize")
        End Try
    End Sub
    Sub Set_Replications(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)

        sql = "Select * from bufr_crex_data"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0

        ds.Clear()
        da.Fill(ds, "bufr_crex_data")

        Initialize_Cloud_Replications(conn1, ds, 4, "119", "cloud_rep1") 'Delayed replication of cloud layers above station level 4 times for a maximum of 4 layers

        Initialize_Cloud_Replications(conn1, ds, 5, "611", "cloud_rep2") 'Delayed replication of cloud layers below station level 4 times for a maximum of 5 layers

        ' Set the replicated cloud layers to TRUE if observations made
        Dim flds As Integer

        sql = "Select * from " & srcTable.Text & " where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "' and stationId = '" & stn & "';"

        'sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic_2_ra1 where yyyy = '" & txtYear.Text & "' and mm = '" & cboMonth.Text & "' and dd = '" & cboDay.Text & "' and hh = '" & cboHour.Text & "';"
        'MsgBox(sql)
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0

        ds.Clear()
        da.Fill(ds, "from form_synoptic_2_ra1")

        ' Initialize cloud layers by setting them to FALSE so that they are not selected if observations not made
        Kount = ds.Tables("from form_synoptic_2_ra1").Rows.Count

        flds = ds.Tables("from form_synoptic_2_ra1").Columns.Count

        With ds.Tables("from form_synoptic_2_ra1")
            'For i = 0 To Kount - 1

            ' Replications for clounds above the station
            If Not IsDBNull(.Rows(0).Item("Val_Elem119")) And Len(.Rows(0).Item("Val_Elem119")) <> 0 Then Select_Descriptor(conn1, "119", "cloud_rep1")

            If Not IsDBNull(.Rows(0).Item("Val_Elem123")) And Len(.Rows(0).Item("Val_Elem123")) <> 0 Then Select_Descriptor(conn1, "123", "cloud_rep1")

            If Not IsDBNull(.Rows(0).Item("Val_Elem127")) And Len(.Rows(0).Item("Val_Elem127")) <> 0 Then Select_Descriptor(conn1, "127", "cloud_rep1")

            If Not IsDBNull(.Rows(0).Item("Val_Elem131")) And Len(.Rows(0).Item("Val_Elem131")) <> 0 Then Select_Descriptor(conn1, "131", "cloud_rep1")

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
        Dim station_name, wmo_block, wmo_No, lat, lon, elev, qualifier, typ As String

        sql = "select stationName, wmoid, latitude, longitude, elevation from station where stationId = '" & stn & "';"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "stations")

            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("stationName")) Then station_name = ds.Tables("stations").Rows(0).Item("stationName")
            If Len(station_name) > 20 Then station_name = Strings.Left(station_name, 20) 'Truncate station name to the madatory maximum of 20 characters
            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("wmoid")) Then wmo_block = Strings.Left(ds.Tables("stations").Rows(0).Item("wmoid"), 2)
            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("wmoid")) Then wmo_No = Strings.Right(ds.Tables("stations").Rows(0).Item("wmoid"), 3)
            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("latitude")) Then lat = ds.Tables("stations").Rows(0).Item("latitude")
            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("longitude")) Then lon = ds.Tables("stations").Rows(0).Item("longitude")
            If Not IsDBNull(ds.Tables("stations").Rows(0).Item("elevation")) Then elev = ds.Tables("stations").Rows(0).Item("elevation")
            'qualifier = ds.Tables("stations").Rows(0).Item("qualifier")

            qualifier = Strings.UCase(Get_StationQualifier(conn1, stn))

            If qualifier = "MISSING" Then
                typ = 3 ' Station type not indicated
            ElseIf (qualifier = "HYBRID") Or Len(qualifier) > 3 And InStr(qualifier, "AWS") > 0 Then
                typ = 2 'Both auto and manual station
            ElseIf qualifier = "AWS" Then
                typ = 0 ' Automatic station
            Else
                typ = 1  ' Manual station
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

            ' Get WSI if available
            ' stn_wsi_data = ""
            'If wsi_data(stn,wsi_data) Then
            ' stn_wsi_data = wsi_data 
            'End If

        Catch ex As Exception
            MsgBox(ex.Message & " Update_Station_Details")
        End Try
    End Sub
    Function Get_StationQualifier(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String) As String
        'sql = "select qualifier,belongsTo from stationqualifier where belongsTo = '" & stn & "';"
        sql = "SELECT qualifier from station WHERE stationId ='" & stn & "';"
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "qualifiers")

            With ds.Tables("qualifiers")
                If .Rows.Count > 0 Then
                    If IsDBNull(.Rows(0).Item("qualifier")) Then Return "MISSING"
                    If Len(.Rows(0).Item("qualifier")) = 0 Then Return "MISSING"
                Else
                        Get_StationQualifier = "MISSING"
                End If
                Return .Rows(0).Item("qualifier")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "MISSING"
        End Try
    End Function
    Sub Update_Instruments_Details(conn1 As MySql.Data.MySqlClient.MySqlConnection, stn As String)
        sql = "select describedby as code,instrumentcode,height from stationelement where recordedfrom = '" & stn & "';"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

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
        sql = "select * from " & srcTable.Text & " where stationid = '" & stn & " ' and yyyy= '" & yr & " ' and mm = '" & mm & " ' and dd= '" & dd & " '  and hh = '" & hh & "';"
        'MsgBox(sql)
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "synoptic")
            If ds.Tables("synoptic").Rows.Count <> 0 Then
                rep1 = 0
                rep2 = 0
                With ds.Tables("synoptic")

                    For i = 5 To 53 '.Columns.Count - 1
                        dat = ""
                        fld = .Columns(i).ColumnName
                        'MsgBox(2 & " _" & fld)
                        'If Len(fld) = 11 And IsNumeric(Int(Strings.Mid(fld, 9, 3))) Then ' Fields for data values
                        code = Int(Strings.Mid(fld, 9, 3))
                            'MsgBox(code)
                            If Not IsDBNull(.Rows(0).Item(i)) Then dat = .Rows(0).Item(i)
                            'MsgBox(dat)
                            If Len(dat) <> 0 Then
                                'MsgBox(0)
                                ' Compute observations with special conditions
                                ' Scale Radiation and Pressure
                                If code = 133 Then
                                    dat = dat & "0000"
                                ElseIf code = 106 Or code = 107 Or code = 399 Or code = 301 Or code = 400 Then ' Scale Pressure
                                    dat = CLng(dat) * 100
                                    'ElseIf code = "506" Then ' Time of beginning or end of precipitation
                                    '    dat = 9
                                ElseIf code = 114 Then ' Convert OKTAS to %
                                    dat = CLng(dat) * 12.5
                                ElseIf code = 132 Then ' Convert hours of Sunshine to minutes
                                    dat = CLng(dat) * 60
                                End If

                                ' Convert Non SI units observation from formSynoptic2
                                With formSynoptic2
                                    If .cboCloudheightUnits.Text = "feet" And (code = 192 Or code = 118 Or code = 122 Or code = 126 Or code = 130) Then
                                        dat = CLng(dat) * 0.3048
                                    End If

                                    If .cboWindSpdUnits.Text = "knots" And code = 111 Then
                                        dat = CLng(dat) * 0.51
                                    End If

                                    If .cboPrecipUnits.Text = "inches" And code = 5 Then
                                        dat = CLng(dat) * 25.4
                                    End If

                                    If .cboTempUnits.Text = "Deg F" And (code = 2 Or code = 3 Or code = 99 Or code = 101 Or code = 102) Then
                                        'dat = CLng(dat) * 0.3048
                                        dat = (CLng(dat) - 32) * (5 / 9)
                                    End If
                                End With

                                'If code = 814 Then MsgBox(dat)
                                Update_Observation(conn1, dat, code)

                                ' Compute cloud layers replications
                                'Clouds above station level
                                If code = 116 Or code = 120 Or code = 124 Or code = 128 Then rep1 = rep1 + 1
                                'Clouds below station level
                                If code = 612 Or code = 622 Or code = 632 Or code = 642 Then rep2 = rep2 + 1
                            End If
                            'MsgBox(1)
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
                            'End If
                            'MsgBox(2)
                            ' Compute value for TRACE precipitation if present
                            If fld = "Flag005" And Not IsDBNull(.Rows(0).Item(i)) Then
                            If .Rows(0).Item(i) = "T" Then Update_Observation(conn1, -1, 5) '24Hr Precipitation
                        End If
                        If fld = "Flag174" And Not IsDBNull(.Rows(0).Item(i)) Then
                            If .Rows(0).Item(i) = "T" Then Update_Observation(conn1, -1, 174) '24Hr Precipitation
                        End If

                        '' Compute Character and Intensity of precipitation in Templat TM307081
                        If cboTemplate.Text = "TM_307081" Then
                            If fld = "Val_Elem005" Then
                                If Not IsDBNull(.Rows(0).Item(i)) Then
                                    ChrR = Precip_Characteristic(.Rows(0).Item(i))
                                Else
                                    ChrR = "15"
                                End If
                                Update_Observation(conn1, ChrR, "506")
                                Update_Observation(conn1, "15", "507") ' Time of beginning or end of precipitation - Set to missing
                            End If
                        End If
                        'MsgBox(3)
                    Next

                    ' Update Cloud Replications
                    'MsgBox(rep1 & " " & rep2)
                    Update_Observation(conn1, rep1, "cloud_rep1")
                    Update_Observation(conn1, rep2, "cloud_rep2")
                End With
            End If
        Catch ex As Exception
            MsgBox(fld & " " & ex.Message)
            If ex.HResult <> -2147467262 Then MsgBox(ex.Message & " Update_Observation_data")
            'MsgBox(sql)
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
        Else
            Precip_Characteristic = 15
        End If

        Return Precip_Characteristic
    End Function

    Sub Update_Observation(conn1 As MySql.Data.MySqlClient.MySqlConnection, data As String, element As String)

        sql = "update bufr_crex_data set observation = '" & data & "' where Climsoft_Element='" & element & "';"

        Try
            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
            'Execute query
            objCmd.ExecuteNonQuery()

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
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds1.Clear()
            da.Fill(ds1, "bufr_crex_data")
            kount1 = ds1.Tables("bufr_crex_data").Rows.Count

            'Select replication factors
            For i = 0 To kount1 - 1
                ' Set the relication descriptor as TRUE
                sql = "update bufr_crex_data Set Selected = '1' where Climsoft_Element = '" & rep_type & "';"
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

        'For i = 0 To Kount - 1
        '    If dsa.Tables("bufr_crex_data").Rows(i).Item("Climsoft_Element") = rep_type Then
        '        For j = i + 3 To i + 3 + (rep_factor * 4) '17
        '            sql = "update bufr_crex_data set selected = '0' where nos = '" & j & "';"
        '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
        '            'Execute query
        '            objCmd.ExecuteNonQuery()
        '        Next
        '        Exit For
        '    End If
        'Next

        Dim RecNo As Integer

        With dsa

            For i = 0 To .Tables("bufr_crex_data").Rows.Count - 1
                If .Tables("bufr_crex_data").Rows(i).Item("Climsoft_Element") = rep_type Then
                    RecNo = .Tables("bufr_crex_data").Rows(i).Item("Nos")
                    For j = RecNo To (RecNo + rep_factor * 4)
                        If j = RecNo Then
                            sql = "update bufr_crex_data set Observation ='0', selected = '1' where Nos = '" & j & "';"
                        Else
                            sql = "update bufr_crex_data set selected = '0' where Nos = '" & j & "';"
                        End If
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn1)
                        objCmd.ExecuteNonQuery()
                    Next
                    Exit For
                End If
            Next
        End With
        'MsgBox("Cloud Replication Initialized")
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
        Try
            'sql = "Select * from bufr_crex_data"
            sql = "SELECT * FROM bufr_crex_data where selected = 1 ORDER BY Nos;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds1.Clear()
            da.Fill(ds1, "bufr_crex_data")
            Kount = ds1.Tables("bufr_crex_data").Rows.Count

            For i = 0 To Kount - 1
                With ds1.Tables("bufr_crex_data").Rows(i)

                    If Len(.Item("observation")) <> 0 Then

                        climsoft_element_scale = ScaleFactor(conn1, .Item("climsoft_element"))
                        'MsgBox(.Item("climsoft_element") & " - " & climsoft_element_scale)
                        bufr_str = Bufr_Data(conn1, .Item("Bufr_Unit"), .Item("Bufr_Scale"), .Item("Bufr_RefValue"), .Item("Bufr_DataWidth_Bits"), .Item("observation"), climsoft_element_scale)

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


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Function ScaleFactor(conn1 As MySql.Data.MySqlClient.MySqlConnection, code As String) As String

        ScaleFactor = 1
        If Not IsNumeric(code) Then Return ScaleFactor
        Try
            sql = "Select elementId, elementScale from obselement where elementId = '" & Val(code) & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

                ds.Clear()
            da.Fill(ds, "obselement")
            Kount = ds.Tables("obselement").Rows.Count

            If Kount <> 0 Then
                If Len(ds.Tables("obselement").Rows(0).Item("elementScale")) <> 0 Then ScaleFactor = ds.Tables("obselement").Rows(0).Item("elementScale")
                'ScaleFactor = 1
            End If
            'If Not IsNumeric(ScaleFactor) = 1 Then MsgBox(code)
        Catch ex As Exception
            MsgBox(ex.Message & " at Scale Factor")
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
            'MsgBox(0)
            Bufr_Data = ""
            If Bufr_Unit = "CCITT IA5" Then
                'Bufr_Data = CCITT_Binary(conn1, dat, Bufr_DataWidth)
                Bufr_Data = TDCF.CCITT_Binary(dat, Bufr_DataWidth)
                Exit Function
            End If
            'MsgBox(1)
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
            MsgBox(ex.Message & " at Bufr_Data")

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
            MsgBox(ex.Message & " Decimal_Binary")
            'MsgBox(DecN & " " & bts & " " & Decimal_Binary)
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

    Function Bufr_Section4(conn1 As MySql.Data.MySqlClient.MySqlConnection, ByRef subset_section4 As String) As Boolean

        'Dim bufr_subset As String
        Try

            sql = "select * from bufr_crex_data where selected =1 order by nos;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

            ds.Clear()
            da.Fill(ds, "bufr_coded")
            Kount = ds.Tables("bufr_coded").Rows.Count

            If Kount > 0 Then
                ' Get the binary data stream for the Subset
                subset_section4 = ""
                For i = 0 To Kount - 1
                    subset_section4 = subset_section4 & ds.Tables("bufr_coded").Rows(i).Item("Bufr_Data")
                Next

                PrintLine(20, subset_section4)
                'Bufr_Section4 = bufr_subset
                Return True
            Else
                Return False
            End If

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
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0

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
            MsgBox(ex.Message & " at CCITT_Binary")
            CCITT_Binary = ""
        End Try
    End Function


    Function BUFR_Code(conn1 As MySql.Data.MySqlClient.MySqlConnection, binary_data As String, subsets As Integer, Optional WSId As Boolean = False) As Boolean

        'MsgBox(subsets)
        BUFR_Code = False

        Try
            Dim octets, Octtets As String
            Dim section0, section1, section2, section3, section4, section5, substs, Dat_Sec As String

            substs = ""
            'Dat_Sec = Data_Description_Section
            'Data_Description_Section = ""

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
            ' Section 3 details to be computed in the code below
            ' Octet 1 - 3. Length of section in octets
            ' Octet 4. Reserved (Set to Zero)
            ' Octet 7. Type of data. Bit 1, = 1 observed = 0 Other. Bit 2 = 1 Compressed, = 0 non-compressed. Bit 3-8 reserved (set to zero)
            ' Octet 8 Onwards - Collection of describtors occupying 2 octets each. 1 Octet to be added to make the total even.

            ' Initialize Section3 string
            section3 = ""

            'Octet 1 - 3. Length of section

            'section3 = section3 & Decimal_Binary(10, 24)

            Octtets = 7 + Len(Data_Description_Section) / 8

            If Octtets Mod 2 <> 0 Then Octtets = Octtets + 1
            section3 = section3 & Decimal_Binary(Octtets, 24)

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
            section3 = section3 & Data_Description_Section
            'MsgBox(Len(Data_Description_Section))
            ' Octet 10. An extra octet to make total octets even
            section3 = section3 & "00000000"

            'Compute Section 4 - Data Section
            Dim xtrbits As Integer
            Dim siz As Integer

            'Dim binary_data As String

            section4 = ""
            'MsgBox(Len(binary_data))
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

            'txtbufr = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr.txt"
            txtbufr = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.txt"
            FileOpen(2, txtbufr, OpenMode.Output)

            Print(2, BUFR_Message) ' Put the BUFR binary digit message into a text file

            FileClose(2)

            'Construct and open Bufr output text file based on the message header
            'bufr_file = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & msg_file & ".f"
            If WSId Then msg_file = msg_file & "_WSI"
            bufr_file = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & msg_file & ".tmp"
            FileOpen(2, bufr_file, OpenMode.Binary)

            'octsfl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_octets.txt"
            octsfl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_octets.txt"
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

        Try
            If TDCF.FTP_Put(txtMsgbFile.Text) Then
                MsgBox("File Sent")
            Else
                MsgBox("FTP Failure")
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

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

            'local_folder = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
            local_folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\data"

            'Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
            Drive1 = System.IO.Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))

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
                'If ftpmode = "FTP" Then Print(1, "open ftp://" & usr & ":" & pwd & "@" & ftp_host & Chr(13) & Chr(10))
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


    'Private Sub cboTemplate_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    '    If Len(cboTemplate.Text) > 0 Then
    '        sql = "SELECT * FROM bufr_indicators where Tmplate = '" & cboTemplate.Text & "';"
    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)

    '        ds.Clear()
    '        da.Fill(ds, "bufr_indicators")

    '        txtMsgHeader.Text = ds.Tables("bufr_indicators").Rows(0).Item("Msg_Header")
    '        txtBUFREditionNumber.Text = ds.Tables("bufr_indicators").Rows(0).Item("BUFR_Edition")
    '        txtOriginatingGeneratingCentre.Text = ds.Tables("bufr_indicators").Rows(0).Item("Originating_Centre")
    '        txtOriginatingGeneratingSubCentre.Text = ds.Tables("bufr_indicators").Rows(0).Item("Originating_SubCentre")
    '        txtUpdateSequenceNumber.Text = ds.Tables("bufr_indicators").Rows(0).Item("Update_Sequence")
    '        chkOptionalSectionInclusion.Checked = ds.Tables("bufr_indicators").Rows(0).Item("Optional_Section")
    '        'If ds.Tables("bufr_indicators").Rows(0).Item("Optional_Section") = 1 Then
    '        '    chkOptionalSectionInclusion.Checked() = True
    '        'Else
    '        '    chkOptionalSectionInclusion.Checked() = False
    '        'End If
    '        txtDataCategory.Text = ds.Tables("bufr_indicators").Rows(0).Item("Data_Category")
    '        txtInternationalDataSubCategory.Text = ds.Tables("bufr_indicators").Rows(0).Item("Intenational_Data_SubCategory")
    '        txtLocalDataSubCategory.Text = ds.Tables("bufr_indicators").Rows(0).Item("Local_Data_SubCategory")
    '        txtMastersTableVersionNumber.Text = ds.Tables("bufr_indicators").Rows(0).Item("Master_table")
    '        txtLocalTableVersionNumber.Text = ds.Tables("bufr_indicators").Rows(0).Item("Local_Table")
    '    End If
    'End Sub



    Private Sub cboTemplate_TextChanged1(sender As Object, e As EventArgs) Handles cboTemplate.TextChanged

        sql = "SELECT * FROM bufr_indicators where Tmplate = '" & cboTemplate.Text & "';"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        ' Set to unlimited timeout period
        da.SelectCommand.CommandTimeout = 0

        ds.Clear()
        da.Fill(ds, "bufr_indicators")
        With ds.Tables("bufr_indicators")
            If .Rows.Count > 0 Then
                txtMsgHeader.Text = .Rows(0).Item("Msg_Header")
                txtBUFREditionNumber.Text = .Rows(0).Item("BUFR_Edition")
                txtOriginatingGeneratingCentre.Text = .Rows(0).Item("Originating_Centre")
                txtOriginatingGeneratingSubCentre.Text = .Rows(0).Item("Originating_SubCentre")
                txtUpdateSequenceNumber.Text = .Rows(0).Item("Update_Sequence")
                chkOptionalSectionInclusion.Checked = .Rows(0).Item("Optional_Section")
                txtDataCategory.Text = .Rows(0).Item("Data_Category")
                txtInternationalDataSubCategory.Text = .Rows(0).Item("Intenational_Data_SubCategory")
                txtLocalDataSubCategory.Text = .Rows(0).Item("Local_Data_SubCategory")
                txtMastersTableVersionNumber.Text = .Rows(0).Item("Master_table")
                txtLocalTableVersionNumber.Text = .Rows(0).Item("Local_Table")
            Else
                txtMsgHeader.Text = ""
                txtBUFREditionNumber.Text = ""
                txtOriginatingGeneratingCentre.Text = ""
                txtOriginatingGeneratingSubCentre.Text = ""
                txtUpdateSequenceNumber.Text = ""
                chkOptionalSectionInclusion.Checked = 0
                txtDataCategory.Text = ""
                txtInternationalDataSubCategory.Text = ""
                txtLocalDataSubCategory.Text = ""
                txtMastersTableVersionNumber.Text = ""
                txtLocalTableVersionNumber.Text = ""
            End If

        End With

    End Sub
    Function Compute_Descriptors(Optional WSId As Boolean = False) As Boolean
        Dim descriptor_data, wsi_descriptor, f, x, y As String

        Try
            Data_Description_Section = ""
            wsi_descriptor = " "
            descriptor_data = Strings.Right(cboTemplate.Text, 6)            'TM_307081

            f = Decimal_Binary(Strings.Left(descriptor_data, 1), 2)    ' Descriptor type
            x = Decimal_Binary(Strings.Mid(descriptor_data, 2, 2), 6) ' Descriptor Class
            y = Decimal_Binary(Strings.Mid(descriptor_data, 4, 3), 8) ' Entry in Class X

            Data_Description_Section = f & x & y     ' Complete Descriptor in binary

            If Not WSId Then Return True

            If TDCF.WSI_Sequence(wsi_descriptor) Then
                Data_Description_Section = wsi_descriptor & Data_Description_Section
                'MsgBox(wsi_descriptor & Chr(10) & Chr(13) & Data_Description_Section & Chr(10) & Chr(13) & wsi_descriptor & Data_Description_Section)
            End If
            'MsgBox(descriptor_data & " " & Data_Description_Section)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class