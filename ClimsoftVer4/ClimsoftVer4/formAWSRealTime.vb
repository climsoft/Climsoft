Imports System.IO
Imports System.Net

Public Class formAWSRealTime

    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim recEdit As New dataEntryGlobalRoutines
    Dim Desc_Bits As String
    Dim BUFR_Subsets_Data As String
    Dim Bufr_Subst As Integer
    Dim dr, fl As String
    Dim ftp_host As String
    Dim txtinputfile As String

    Dim nat_id As String
    Dim wmo_id As String
    Dim stn_name As String
    Dim lat As String
    Dim lon As String
    Dim elv As String


    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        'pnlProcessing.Visible = True
        'pnlProcessing.Dock = DockStyle.Right
        'pnlServers.Visible = False
        'pnlSites.Visible = False
        'pnlDataStructures.Visible = False
        'pnlMessagesEncoding.Visible = False
        'Me.Text = "Process Settings"
        pnlControl.Dock = DockStyle.Left
        ShowPanel(pnlProcessing, "Process Settings")
        load_PressingParameters("txtlFill")

    End Sub

    Private Sub formAWSRealTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlProcessing.Dock = DockStyle.Right
        pnlProcessing.Visible = True
        ' database Connect
        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()
        ShowPanel(pnlProcessing, "Process Settings")
        load_PressingParameters("txtlFill")
        'Timer1.Start()
        'Timer2.Start()

    End Sub

    Private Sub cmdServers_Click(sender As Object, e As EventArgs) Handles cmdServers.Click
        'pnlServers.Dock = DockStyle.Top
        'pnlServers.Visible = True
        'pnlProcessing.Visible = False
        'Me.Text = "Servers Settings"
        ShowPanel(pnlServers, "Servers Settings")
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Sub ShowPanel(pnl As Object, topic As String)
        pnlControl.Dock = DockStyle.Left
        pnlProcessing.Visible = False
        pnlServers.Visible = False
        pnlSites.Visible = False
        pnlDataStructures.Visible = False
        pnlMsgEncoding.Visible = False
        Me.Text = topic
        pnl.Visible = True
        pnl.Dock = DockStyle.Left

    End Sub

    Private Sub cmdSites_Click(sender As Object, e As EventArgs) Handles cmdSites.Click
        ShowPanel(pnlSites, "Site Settings")
        SetDataSet("aws_sites")
        rec = 0

        PopulateForm("sites", txtSitesNavigator, rec)
        FillList(txtDataStructure, "aws_structures", "strName")
    End Sub

    Private Sub cmdDataStructures_Click(sender As Object, e As EventArgs) Handles cmdDataStructures.Click

        ShowPanel(pnlDataStructures, "Data Structures Settings")
        FillList(cmbExistingStructures, "aws_structures", "strName")
    End Sub

    Private Sub cmdMessages_Click(sender As Object, e As EventArgs) Handles cmdMessages.Click
        ShowPanel(pnlMsgEncoding, "Message Coding Settings")
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub cmdBaseStation_Click(sender As Object, e As EventArgs) Handles cmdBaseStation.Click
        pnlMSS.Visible = False
        pnlBaseStation.Visible = True
        pnlBaseStation.Enabled = True
        pnlMSS.Visible = False
        SetDataSet("aws_basestation")
        rec = 0
        PopulateForm("bss", txtbssNavigator, rec)
    End Sub

    Private Sub cmdMSS_Click(sender As Object, e As EventArgs) Handles cmdMSS.Click
        pnlBaseStation.Visible = False
        pnlMSS.Visible = True
        pnlMSS.Enabled = True
        SetDataSet("aws_mss")
        rec = 0
        PopulateForm("mss", txtmssNavigator, rec)
    End Sub

    Private Sub cmdBstAddNew_Click(sender As Object, e As EventArgs) Handles cmdBstAddNew.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("aws_basestation").NewRow
        dsNewRow.Item("ftpId") = txtBaseStationAddress.Text
        dsNewRow.Item("inputFolder") = txtBaseStationFolder.Text
        dsNewRow.Item("ftpMode") = txtBasestationFTPMode.Text
        dsNewRow.Item("userName") = txtBaseStationUser.Text
        dsNewRow.Item("password") = txtbaseStationPW.Text

        ' Confirm Password
        If txtbaseStationPW.Text <> txtbaseStationPWConfirm.Text Then
            MsgBox("Confirm Password")
            txtbaseStationPW.Clear()
            txtbaseStationPWConfirm.Clear()
            Exit Sub
        End If

        'Add a new record to the data source table
        ds.Tables("aws_basestation").Rows.Add(dsNewRow)
        da.Update(ds, "aws_basestation")
        MsgBox("Server Record Added")

        'Clear TextBoxes
        FormReset("bss")

        'txtBaseStationAddress.Text = ""
        'txtBaseStationFolder.Text = ""
        'txtBasestationFTPMode.Text = ""
        'txtBaseStationUser.Text = ""
        'txtbaseStationPW.Text = ""
        'txtbaseStationPWConfirm.Text = ""
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Sub SetDataSet(tabl As String)
        On Error GoTo Err
        Dim sql As String
        sql = "SELECT * FROM " & tabl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        ds.Clear()
        da.Fill(ds, tabl)

        rec = 0
        Kount = ds.Tables(tabl).Rows.Count
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub
    Function GetDataSet(tabl As String, sql As String) As DataSet
        On Error GoTo Err
        Dim s As New DataSet

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        s.Clear()
        da.Fill(s, tabl)

        GetDataSet = s
        Exit Function
Err:
        Log_Errors(Err.Description)
        'MsgBox(Err.Description)
    End Function
    Sub PopulateForm(pnl As String, navbar As TextBox, num As Integer)
        On Error Resume Next
        Dim navs As String
        'If Kount = 0 Then Exit Sub
        Select Case pnl
            Case "bss"
                txtBaseStationAddress.Text = ds.Tables("aws_basestation").Rows(num).Item("ftpId")
                txtBaseStationFolder.Text = ds.Tables("aws_basestation").Rows(num).Item("inputFolder")
                txtBasestationFTPMode.Text = ds.Tables("aws_basestation").Rows(num).Item("ftpMode")
                txtBaseStationUser.Text = ds.Tables("aws_basestation").Rows(num).Item("userName")
                txtbaseStationPW.Text = ds.Tables("aws_basestation").Rows(num).Item("password")

            Case "mss"
                txtMSSAddress.Text = ds.Tables("aws_mss").Rows(num).Item("ftpId")
                txtMSSFolder.Text = ds.Tables("aws_mss").Rows(num).Item("inputFolder")
                txtmssFTPMode.Text = ds.Tables("aws_mss").Rows(num).Item("ftpMode")
                txtmssUser.Text = ds.Tables("aws_mss").Rows(num).Item("userName")
                txtMSSPW.Text = ds.Tables("aws_mss").Rows(num).Item("password")

            Case "sites"
                txtStation.Text = ds.Tables("aws_sites").Rows(num).Item("SiteID")
                txtInFile.Text = ds.Tables("aws_sites").Rows(num).Item("InputFile")
                txtDataStructure.Text = ds.Tables("aws_sites").Rows(num).Item("DataStructure")
                txtFlag.Text = ds.Tables("aws_sites").Rows(num).Item("MissingDataFlag")
                txtIP.Text = ds.Tables("aws_sites").Rows(num).Item("awsServerIp")
                chkOperational.Checked = ds.Tables("aws_sites").Rows(num).Item("OperationalStatus")

            Case "pnlDataStructures"


        End Select


        If num < 0 Then num = 0
        If Kount > 0 Then navbar.Text = num + 1 & "of" & Kount
    End Sub

    Function RecordUpdate(tbl As String, pnl As String, num As Integer, cmdtype As String) As Boolean
        RecordUpdate = True

        On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        Select Case pnl
            Case "bss"
                ds.Tables(tbl).Rows(num).Item("ftpId") = txtBaseStationAddress.Text
                ds.Tables(tbl).Rows(num).Item("inputFolder") = txtBaseStationFolder.Text
                ds.Tables(tbl).Rows(num).Item("ftpMode") = txtBasestationFTPMode.Text
                ds.Tables(tbl).Rows(num).Item("userName") = txtBaseStationUser.Text
                ds.Tables(tbl).Rows(num).Item("password") = txtbaseStationPW.Text

            Case "mss"
                ds.Tables(tbl).Rows(num).Item("ftpId") = txtMSSAddress.Text
                ds.Tables(tbl).Rows(num).Item("inputFolder") = txtMSSFolder.Text
                ds.Tables(tbl).Rows(num).Item("ftpMode") = txtmssFTPMode.Text
                ds.Tables(tbl).Rows(num).Item("userName") = txtmssUser.Text
                ds.Tables(tbl).Rows(num).Item("password") = txtMSSPW.Text

            Case "pnlDataStructures"
                'ds.Tables(tbl).Rows(num).Item("strName") = txtStrName.Text
                ds.Tables(tbl).Rows(num).Item("data_delimiter") = txtDelimiter.Text
                ds.Tables(tbl).Rows(num).Item("hdrRows") = txtHeaders.Text
                ds.Tables(tbl).Rows(num).Item("txtQualifier") = txtQualifier.Text


        End Select



        'Add a new record to the data source table
        'If cmdtype = "add" Then ds.Tables("station").Rows.Add(dsNewRow)

        da.Update(ds, tbl)

        If cmdtype = "update" Then recUpdate.messageBoxRecordedUpdated()
        'ClearStationForm()

        Exit Function

Err:
        MsgBox(Err.Description)
        RecordUpdate = False
    End Function

    Private Sub cmdBsstUpdate_Click(sender As Object, e As EventArgs) Handles cmdBsstUpdate.Click
        RecordUpdate("aws_basestation", "bss", rec, "update")

        'If txtBaseStationAddress.Text = "" Then
        '    MsgBox("No record Selected")
        'Else
        '    BssUpdate(rec, "update")
        'End If

    End Sub

    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        FormReset("bss")

    End Sub

    Private Sub cmdFirstRecord_Click(sender As Object, e As EventArgs) Handles cmdFirstRecord.Click
        rec = 0
        PopulateForm("bss", txtbssNavigator, rec)
    End Sub

    Private Sub cmdPrevRecord_Click(sender As Object, e As EventArgs) Handles cmdPrevRecord.Click
        If rec > 0 Then
            rec = rec - 1
            PopulateForm("bss", txtbssNavigator, rec)
        End If
    End Sub

    Private Sub cmdNextRecord_Click(sender As Object, e As EventArgs) Handles cmdNextRecord.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            PopulateForm("bss", txtbssNavigator, rec)
        End If
    End Sub

    Private Sub cmdLastRecord_Click(sender As Object, e As EventArgs) Handles cmdLastRecord.Click
        rec = Kount - 1
        PopulateForm("bss", txtbssNavigator, rec)
    End Sub


    Function DeleteRecord(tbl As String, recs As Integer) As Boolean
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        DeleteRecord = True
        On Error GoTo Err

        ds.Tables(tbl).Rows(recs).Delete()
        da.Update(ds, tbl)

        MsgBox("Record Deleted")
        Exit Function
Err:
        MsgBox(Err.Description)
        DeleteRecord = False
    End Function

    Private Sub cmdBstDelete_Click(sender As Object, e As EventArgs) Handles cmdBstDelete.Click
        DeleteRecord("aws_basestation", "bss", txtbssNavigator)
        'If DeleteRecord("aws_basestation", rec) Then

        '    If Kount > 0 Then
        '        Kount = Kount - 1
        '        PopulateForm("bss", txtmssNavigator, rec - 1)
        '    End If
        'End If
    End Sub

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        SetDataSet("aws_basestation")
        rec = 0
        PopulateForm("bss", txtbssNavigator, rec)
        txtbaseStationPWConfirm.Visible = False
        lblConfirmInputPW.Visible = False
    End Sub
    Sub FormReset(pannel As String)

        Select Case pannel
            Case "bss"
                txtBaseStationAddress.Clear()
                txtBaseStationFolder.Clear()
                'txtBasestationFTPMode.Text = ""
                txtBaseStationUser.Clear()
                txtBasestationFTPMode.Text = "FTP"
                txtbaseStationPW.Clear()
                txtbaseStationPWConfirm.Clear()
                txtbaseStationPWConfirm.Visible = True
                lblConfirmInputPW.Visible = True
                txtbssNavigator.Clear()

            Case "mss"
                txtMSSAddress.Clear()
                txtMSSFolder.Clear()
                txtmssUser.Clear()
                txtmssFTPMode.Text = "FTP"
                txtMSSPW.Clear()
                txtMSSConfirm.Clear()
                txtMSSConfirm.Visible = True
                lblmssConfirmPassword.Visible = True
                txtmssNavigator.Clear()

            Case "sites"
                txtStation.Text = ""
                txtInFile.Clear()
                txtDataStructure.Text = ""
                txtFlag.Clear()
                chkOperational.Checked = True
                txtIP.Text = ""
        End Select
    End Sub

    Private Sub cmdmssReset_Click(sender As Object, e As EventArgs) Handles cmdmssReset.Click
        FormReset("mss")
    End Sub

    Private Sub cmdMSSAddNew_Click(sender As Object, e As EventArgs) Handles cmdMSSAddNew.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("aws_mss").NewRow
        dsNewRow.Item("ftpId") = txtMSSAddress.Text
        dsNewRow.Item("inputFolder") = txtMSSFolder.Text
        dsNewRow.Item("ftpMode") = txtBasestationFTPMode.Text
        dsNewRow.Item("userName") = txtmssUser.Text
        dsNewRow.Item("password") = txtMSSPW.Text

        ' Confirm Password
        If txtMSSPW.Text <> txtMSSConfirm.Text Then
            MsgBox("Confirm Password")
            txtMSSConfirm.Clear()
            txtMSSPW.Clear()
            Exit Sub
        End If

        'Add a new record to the data source table
        ds.Tables("aws_mss").Rows.Add(dsNewRow)
        da.Update(ds, "aws_mss")
        MsgBox("Server Record Added")

        FormReset("mss")

        ''Clear TextBoxes
        'txtMSSAddress.Clear()
        'txtMSSFolder.Clear()
        'txtBasestationFTPMode.Clear()
        'txtmssUser.Clear()
        'txtMSSPW.Clear()
        'txtMSSConfirm.Clear()

        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Private Sub cmdMSSUpdate_Click(sender As Object, e As EventArgs) Handles cmdMSSUpdate.Click
        RecordUpdate("aws_mss", "mss", rec, "update")
    End Sub

    Private Sub cmdmssRefresh_Click(sender As Object, e As EventArgs) Handles cmdmssRefresh.Click
        SetDataSet("aws_mss")
        rec = 0
        PopulateForm("mss", txtmssNavigator, rec)
        txtMSSConfirm.Visible = False
        lblmssConfirmPassword.Visible = False
    End Sub
    Sub DeleteRecord(tbl As String, pnl As String, Navbar As TextBox)
        If DeleteRecord(tbl, rec) Then

            If Kount > 0 Then
                Kount = Kount - 1
                PopulateForm(pnl, Navbar, rec - 1)
            End If
        End If
    End Sub

    Private Sub cmdMSSDelete_Click(sender As Object, e As EventArgs) Handles cmdMSSDelete.Click
        DeleteRecord("aws_mss", "mss", txtmssNavigator)
    End Sub

    Private Sub cmdmssfirst_Click(sender As Object, e As EventArgs) Handles cmdmssfirst.Click
        rec = 0
        PopulateForm("mss", txtmssNavigator, rec)
    End Sub

    Private Sub cmdmssPrev_Click(sender As Object, e As EventArgs) Handles cmdmssPrev.Click
        If rec > 0 Then
            rec = rec - 1
            PopulateForm("mss", txtmssNavigator, rec)
        End If
    End Sub

    Private Sub cmdmssNext_Click(sender As Object, e As EventArgs) Handles cmdmssNext.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            PopulateForm("mss", txtmssNavigator, rec)
        End If
    End Sub

    Private Sub cmdmssLast_Click(sender As Object, e As EventArgs) Handles cmdmssLast.Click
        rec = Kount - 1
        PopulateForm("mss", txtmssNavigator, rec)
    End Sub

    Private Sub pnlDataStructures_Paint(sender As Object, e As PaintEventArgs) Handles pnlDataStructures.Paint

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles grpStructures1.Enter

    End Sub

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles GroupBox11.Enter

    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        rec = 0
        PopulateForm("sites", txtSitesNavigator, rec)
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        rec = Kount - 1
        PopulateForm("sites", txtSitesNavigator, rec)

    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        If rec > 0 Then
            rec = rec - 1
            PopulateForm("sites", txtSitesNavigator, rec)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            PopulateForm("sites", txtSitesNavigator, rec)
        End If
    End Sub

    Private Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("aws_sites").NewRow
        dsNewRow.Item("SiteID") = txtStation.Text
        dsNewRow.Item("InputFile") = txtInFile.Text
        dsNewRow.Item("DataStructure") = txtDataStructure.Text
        dsNewRow.Item("MissingDataFlag") = txtFlag.Text
        dsNewRow.Item("awsServerIp") = txtIP.Text
        If chkOperational.Checked Then
            dsNewRow.Item("OperationalStatus") = 1
        Else
            dsNewRow.Item("OperationalStatus") = 0
        End If
        'Add a new record to the data source table
        ds.Tables("aws_sites").Rows.Add(dsNewRow)
        da.Update(ds, "aws_sites")
        FormReset("sites")
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        FormReset("sites")
        txtSitesNavigator.Clear()
    End Sub

    Private Sub cmdDel_Click(sender As Object, e As EventArgs) Handles cmdDel.Click
        If DeleteRecord("aws_sites", rec) Then
            Kount = Kount - 1
            If rec > 0 Then rec = rec - 1
            If Kount = 0 Then
                FormReset("sites")
                txtSitesNavigator.Clear()
            End If

            If rec < Kount Then
                PopulateForm("sites", txtSitesNavigator, rec)
            Else
                PopulateForm("sites", txtSitesNavigator, rec)
            End If
        End If
    End Sub

    Private Sub cmdUpdateSites_Click(sender As Object, e As EventArgs) Handles cmdUpdateSites.Click
        On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        ds.Tables("aws_sites").Rows(rec).Item("SiteID") = txtStation.Text
        ds.Tables("aws_sites").Rows(rec).Item("InputFile") = txtInFile.Text
        ds.Tables("aws_sites").Rows(rec).Item("DataStructure") = txtDataStructure.Text
        ds.Tables("aws_sites").Rows(rec).Item("MissingDataFlag") = txtFlag.Text
        ds.Tables("aws_sites").Rows(rec).Item("awsServerIp") = txtIP.Text
        If chkOperational.Checked Then
            ds.Tables("aws_sites").Rows(rec).Item("OperationalStatus") = 1
        Else
            ds.Tables("aws_sites").Rows(rec).Item("OperationalStatus") = 0
        End If

        'Add a new record to the data source table
        'If cmdtype = "add" Then ds.Tables("station").Rows.Add(dsNewRow)

        da.Update(ds, "aws_sites")

        recUpdate.messageBoxRecordedUpdated()
        'ClearStationForm()
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Sub FillList(ByRef lst As ComboBox, tbl As String, lstfld As String)
        Dim dlst As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        dlst = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()
        dlst.Fill(dstn, tbl)
        lst.Items.Clear()
        For i = 0 To dstn.Tables(tbl).Rows.Count - 1
            lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(lstfld))
        Next
    End Sub

    Private Sub cmbExistingStructures_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExistingStructures.SelectedIndexChanged
        SetDataSet("aws_structures")

        For i = 0 To Kount - 1
            If cmbExistingStructures.Text = ds.Tables("aws_structures").Rows(i).Item("strName") Then
                txtStrName.Text = ds.Tables("aws_structures").Rows(i).Item("strName")
                txtDelimiter.Text = ds.Tables("aws_structures").Rows(i).Item("data_delimiter")
                txtHeaders.Text = ds.Tables("aws_structures").Rows(i).Item("hdrRows")
                txtQualifier.Text = ds.Tables("aws_structures").Rows(i).Item("txtQualifier")
                lblRecords.Text = "Rec: " & i + 1
            End If
        Next
        DataGridFill(txtStrName.Text)
    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("aws_structures").NewRow
        dsNewRow.Item("strName") = txtStrName.Text
        dsNewRow.Item("data_delimiter") = txtDelimiter.Text
        dsNewRow.Item("hdrRows") = txtHeaders.Text
        dsNewRow.Item("txtQualifier") = txtQualifier.Text

        'Add a new record to the data source table
        ds.Tables("aws_structures").Rows.Add(dsNewRow)
        da.Update(ds, "aws_structures")

        recEdit.messageBoxCommit()

        ' Create a table for the new structure
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand
        Dim tbl As String = txtStrName.Text

        sql0 = "CREATE TABLE `mysql_climsoft_db_v4`.`" & txtStrName.Text & "` " & _
               "( " & _
                "`No` INT NOT NULL, " & _
                "`Element_abbreviation` TEXT NOT NULL, " & _
                "`Element_Name` TEXT NOT NULL, " & _
                "`Element_Details` TEXT NOT NULL, " & _
                "`Climsoft_Element` TEXT NOT NULL, " & _
                "`Bufr_Element` TEXT NOT NULL, " & _
                "`unit` TEXT NOT NULL, " & _
                "`lower_limit` TEXT NOT NULL, " & _
                "`upper_limit` TEXT NOT NULL, " & _
                "`obsv` TEXT NOT NULL, " & _
                "UNIQUE KEY `identification` (`No`) " & _
             ");"
        'MsgBox(sql0)
        comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
        comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
        comm.ExecuteNonQuery()   ' Execute the query

        ' Display the created table on the DataGrid

        DataGridFill(txtStrName.Text)
        FillList(cmbExistingStructures, "aws_structures", "strName")
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        'MsgBox(Strings.Right(txtRecNo.Text, 1))
        Dim recs As Integer
        recs = Int(Strings.Right(lblRecords.Text, 1)) - 1
        RecordUpdate("aws_structures", "pnlDataStructures", recs, "update")
        FillList(cmbExistingStructures, "aws_structures", "strName")
    End Sub

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        DeleteRecord("aws_structures", Int(Strings.Right(lblRecords.Text, 1)) - 1)
        FillList(cmbExistingStructures, "aws_structures", "strName")
    End Sub

    Sub DataGridFill(tbl As String)
        On Error GoTo Err

        Dim dg As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        dg = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()

        dg.Fill(dstn, tbl)

        DataGridViewStructures.DataSource = dstn
        DataGridViewStructures.DataMember = tbl
        DataGridViewStructures.Refresh()
        Exit Sub
Err:
        MsgBox(Err.Number & ":" & Err.Description)
    End Sub

    Sub load_PressingParameters(LoadType As String)
        On Error GoTo Err
        Dim dbpconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim dpa As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dps As New DataSet
        Dim sqlp As String

        Dim recUpdate As New dataEntryGlobalRoutines

        sqlp = "SELECT * FROM aws_process_parameters"
        dpa = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlp, dbconn)
        dps.Clear()
        dpa.Fill(dps, "aws_process_parameters")


        Select Case LoadType
            Case "txtlFill"
                txtInterval.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveInterval")
                txtOffset.Text = dps.Tables("aws_process_parameters").Rows(0).Item("HourOffset")
                txtPeriod.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrievePeriod")
                txtTimeout.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveTimeout")
                chkDeleteFile.Checked = dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile")

            Case "dpupdate"
                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(dpa)

                dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveInterval") = txtInterval.Text
                dps.Tables("aws_process_parameters").Rows(0).Item("HourOffset") = txtOffset.Text
                dps.Tables("aws_process_parameters").Rows(0).Item("RetrievePeriod") = txtPeriod.Text
                dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveTimeout") = txtTimeout.Text
                If chkDeleteFile.Checked = True Then
                    dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile") = 1
                Else
                    dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile") = 0
                End If

                dpa.Update(dps, "aws_process_parameters")

                recUpdate.messageBoxRecordedUpdated()

        End Select
        Exit Sub
Err:
        'MsgBox(Err.Description)
        Log_Errors(Err.Description)
    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        'Log_Errors("Error Testing")
        ' Save Changes made on Processing parameters
        load_PressingParameters("dpupdate")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '        On Error GoTo Err

        '        Ltime.Text = Now

        '        ' Set the next encoding time
        '        If Len(txtLastProcess.Text) = 0 Then
        '            txtNxtProcess.Text = DateAdd("n", Val(txtOffset.Text) - Val(Minute(Ltime.Text)), Ltime.Text)
        '            optStart.Checked = True
        '        End If

        '        If optStart.Checked = True Then
        '            'If DateDiff("n", txtDateTime.Text, txtNxtProcess.Text) <= 0 Then

        '            Start_Process()

        '            'End If
        '        End If

        '        Exit Sub
        'Err:
        '        If Err.Number = 13 Then
        '            Resume Next
        '        Else
        '            Log_Errors(Err.Number & ":" & Err.Description)
        '            'Log_Errors "Err.description"  'MsgBox Err.Number & ":" & Err.description
        '        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        txtDateTime.Text = Now
    End Sub

    Sub Log_Errors(errr As String)
        On Error GoTo Err
        Dim errdir, errfile As String

        'Get full path for the errors output file
        errdir = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"

        ' Create the directory if not existing
        If Not Directory.Exists(errdir) Then
            Directory.CreateDirectory(errdir)
        End If

        'Assign the errors output file variable with append set to TRUE
        errfile = errdir & "\err.txt"
        Dim writeFile As System.IO.TextWriter = New StreamWriter(errfile, True)

        ' Create the error file if not existing
        If Not File.Exists(errfile) Then
            File.Create(errfile)
        End If

        list_errors.Items.Add(txtDateTime.Text & "  " & errr)
        list_errors.Refresh()

        writeFile.WriteLine(txtDateTime.Text & "  " & errr)
        writeFile.Close()

        Exit Sub
Err:
        list_errors.Items.Add(txtDateTime.Text & "  " & Err.Description)
        list_errors.Refresh()
    End Sub

    Sub Start_Process()
        ' Refresh input text boxes and list boxes
        txtLastProcess.Text = ""
        txtLastProcess.Refresh()
        list_errors.Items.Clear()
        list_errors.Refresh()

        lstInputFiles.Items.Clear()
        lstOutputFiles.Items.Clear()

        process_input_data()
        'Next_Encoding_Time()
    End Sub

    Sub process_input_data()
        On Error GoTo Err
        Dim datestring As String
        Dim Tlag As Integer
        Dim aws_input_file As String
        Dim aws_input_file_flds As String
        Dim infile As String
        Dim delmtr As String
        Dim delimiter_ascii As String
        Dim hdrows As Integer
        Dim fldsrow As Integer
        Dim txtqlfr As String
        Dim flg As String
        Dim rs As New DataSet
        Dim rss As New DataSet
        Dim dt As DateTime
        Dim fls As String
        Dim aws_data As String
        Dim siz As Integer
        Dim strRec As Integer
        Dim AWSsite As String
        Dim chr As String

        '  Locate and processs aws input data files
        Me.Cursor = Cursors.WaitCursor

        ' Compute the Template descriptor to Bianry form
        If Not Compute_Descriptors(Desc_Bits) Then Exit Sub

        Bufr_Subst = 0
        BUFR_Subsets_Data = ""

        'Get full path for the Subsets Output file file
        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_subsets.csv"

        FileOpen(1, fl, OpenMode.Output)

        'WriteLine(1, "Testing")
        FileClose(1)

        ' Open the data set for the AWS sites and stations
        SetDataSet("aws_sites")


        With ds.Tables("aws_sites")
            For i = 0 To Kount - 1
                If Len(.Rows(i).Item("InputFile")) <> 0 And .Rows(i).Item("OperationalStatus") = 1 Then
                    ' Get station data details
                    nat_id = .Rows(i).Item("SiteID")
                    flg = ""
                    If Len(.Rows(i).Item("MissingDataFlag")) <> 0 Then flg = .Rows(i).Item("MissingDataFlag")
                    'End If
                    AWSsite = .Rows(i).Item("DataStructure")
                    Get_Station_Settings(AWSsite, delmtr, hdrows, txtqlfr, rs)

                    ftp_host = .Rows(i).Item("awsServerIp")

                    ' Compute Delimiter ascii value

                    Select Case delmtr
                        Case "tab"
                            delimiter_ascii = 9
                        Case "comma"
                            delimiter_ascii = 44
                        Case "space"
                            delimiter_ascii = 32
                        Case "semicolon"
                            delimiter_ascii = 59
                        Case Else
                            delimiter_ascii = Asc(delmtr)
                    End Select

                    infile = .Rows(i).Item("InputFile")

                    txtStatus.Text = "Seeking input data - " & infile
                    txtStatus.Refresh()

                    If Not FTP_Call(infile, "get") Then
                        Log_Errors("Can't retrieve data from input file " & infile)
                        'list_errors.Refresh()
                        'GoTo Continues
                    End If

                    'Log_Errors(rs.Tables(.Rows(i).Item("DataStructure")).Rows(0).Item("Element_Abbreviation"))
                    'Log_Errors(infile
                End If
            Next
        End With

        FileClose(1)


        ' Assign a variable to an input file with header rows
        aws_input_file = txtinputfile

        ' Assign a variable to an output file without header rows
        aws_input_file_flds = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\aws_input.txt" 'fso.GetParentFolderName(App.Path) & "\data\aws_input.txt"



        FileOpen(10, aws_input_file, OpenMode.Input)
        FileOpen(11, aws_input_file_flds, OpenMode.Output)

        ' Skip header Records if present

        'Retrieve header rows from station parameters
        If Val(hdrows) > 0 Then
            For i = 0 To Val(hdrows) - 1
                aws_data = LineInput(10)
            Next
        End If

        ' Output the data rows
        Do While EOF(10) = False
            aws_data = LineInput(10)
            PrintLine(11, aws_data)
        Loop

        FileClose(10)
        FileClose(11)


        ' Open the output populated text file as an input file for the database
        FileOpen(11, aws_input_file_flds, OpenMode.Input)

        ' Update the database and process the data one record at a time
        Dim datastring As String
        Dim endline As Boolean

        Do While EOF(11) = False

            aws_data = LineInput(11)
            siz = Len(aws_data)
            datastring = ""
            endline = False
            strRec = 0

            For i = 1 To siz
                chr = Mid(aws_data, i, 1) ' Single character of the data line

                ' When the end of line is reached
                If i = siz Then
                    If chr <> txtqlfr Then datastring = datastring & chr ' Get the last data value on the line by appending the last character
                    endline = True
                End If

                ' Process the data value when the delimiter character is encountered or end of line reached
                If Asc(Mid(aws_data, i, 1)) = delimiter_ascii Or endline = True Then
                    AwsRecord_Update(datastring, strRec, flg, AWSsite)
                    strRec = strRec + 1
                    datastring = ""
                Else
                    If chr <> txtqlfr And i < siz Then
                        datastring = datastring & chr ' Accumulate the characters into a data string but skip text qualifier
                        endline = False
                    End If

                End If

            Next

            ' Analyse the datetime string and process the data if the encoding time interval matches datetime value

            datestring = ds.Tables(AWSsite).Rows(0).Item("obsv")

            'Sametimes Date and Time values are separately in the 1st and 2nd fields respectively. In such cases they are combined
            If Len(datestring) < 12 Then
                datestring = datastring & " " & ds.Tables(AWSsite).Rows(1).Item("obsv")
            End If

            'datestring = TimeStamp(rs)
            If Not IsDate(datestring) Then
                Log_Errors(datestring)
            End If

            Process_Input_Record(AWSsite, datestring)
            'Log_Errors(datestring)

            'If Val(txtPeriod.Text) = 999 Then
            '    Process_Input_Record(datestring) ' Process the entire input file irespective of time difference
            'Else
            '    If DateDiff("h", datestring, txtDateTime.Text) <= Val(txtPeriod.Text - 1) Then Process_Input_Record(datestring)
            '    ''        If Val(Now() - dt) <= (Val(txtlag)) / 24 Then Process_Input_Record rs, inrs, datestring ' Extract Data for at least the last 1 Hour
            'End If

        Loop
        FileClose(11)
        '  Close #11

        '                    ' Delete input file from base station server if so selected
        '                    If del_input.value = 1 Then
        '                        If Not FTP_Delete_InputFile(infile) Then Log_Errors("Can't Delete Input File") 'MsgBox "Can't Delete Input File"
        '                    End If
        '                End If

        'Continues:      ' Next Input file
        '                ' Refresh form
        '                frm_realtime.Refresh()
        '                .MoveNext()
        '            Loop
        '        End With

        '        '' ' Output for data from the AWS observations at interval of 30 minutes. This was a requirement by the Rwanda Meteorological Agency.
        '        '' ' This output will be improved in future to allow flexibility that will enable other users to benefit.
        '        ''
        '        '  If Val(txtlag) <> 999 Then Process_AWS_24hly

        '        ' Compose the complete AWS BUFR message

        '        'If Bufr_Subst > 0 Then
        '        'If Not AWS_BUFR_Code(BUFR_header, yy, mm, dd, hh, min, ss, BUFR_Subsets_Data) Then Log_Errors "Can't Encode Data"  ' MsgBox "Can't Encode Data"
        '        '    ' Reset subset number to 0
        '        '     Bufr_Subst = 0
        '        '     BUFR_Subsets_Data = ""
        '        ' End If

        '        ' Compose the BUFR Bulletins
        'Close #30

        '        ' Open the output file containing the encoded BUFR Subsets data
        'Open fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.csv" For Input As #31

        '        Dim dts(1000) As String
        '        Dim subs(1000) As String
        '        Dim Tsubs As Integer
        '        Dim kount As Integer
        '        Dim Tdone As String
        '        Dim subst As String

        '        ' Load the subsets records from an output file into arrays
        '        kount = 0
        '        Do While EOF(31) = False
        ' Input #31, dts(kount), subs(kount)
        '            kount = kount + 1
        '        Loop

        '        If kount = 1 Then ' Only one substest existing
        '            If Len(subs(0)) <> 0 Then
        '                BUFR_header = msg_header & " " & Format(Day(dts(0)), "00") & Format(Hour(dts(0)), "00") & Format(Minute(dts(0)), "00") & " " & txtBBB
        '                AWS_BUFR_Code(BUFR_header, Year(dts(0)), Month(dts(0)), Day(dts(0)), Hour(dts(0)), Minute(dts(0)), Second(dts(0)), subs(0))
        '            End If
        '        End If

        '        If kount > 1 Then ' More than one Subset exists

        '            ' Initialize the datetime for the compiled BUFR bulletin
        '            Tdone = "00/00/0000 00:00:00"

        '            ' Combine the Subsets for the same hour into a single bulletin
        '            For i = 0 To kount - 1
        '                subst = ""
        '                Bufr_Subst = 0
        '                For j = 0 To kount - 1
        '                    If dts(j) = dts(i) And InStr(Tdone, dts(j)) = 0 Then
        '                        Bufr_Subst = Bufr_Subst + 1
        '                        subst = subst + subs(j)
        '                    End If
        '                Next

        '                ' Compile a bulletin for the located same hour subsets
        '                If Len(subst) <> 0 Then
        '                    BUFR_header = msg_header & " " & Format(Day(dts(i)), "00") & Format(Hour(dts(i)), "00") & Format(Minute(dts(i)), "00") & " " & txtBBB
        '                    AWS_BUFR_Code(BUFR_header, Year(dts(i)), Month(dts(i)), Day(dts(i)), Hour(dts(i)), Minute(dts(i)), Second(dts(i)), subst)
        '                End If
        '                Tdone = Tdone & dts(i)
        '            Next
        '        End If

        'Close #31

        Me.Cursor = Cursors.Default
        Exit Sub

Err:
        If Err.Number = 62 Then
            'Log_Errors("Can't retrieve data from " & infile)
            list_errors.Refresh()
            '    GoTo Continues
            Resume Next
        End If
        If Err.Number = 3349 Then Resume Next
        '   MsgBox Err.Number & " " & Err.description
        Log_Errors(Err.Number & ": " & Err.Description)
        Me.Cursor = Cursors.Default
        '  Close #10
        '  Close #11
    End Sub
    Sub Next_Encoding_Time()

    End Sub
    Function Compute_Descriptors(ByRef Desc_Bits As String) As Boolean
        Compute_Descriptors = True
        On Error GoTo Err
        Dim octetts As Integer
        Dim descript As String
        Dim Seq_Desc As String
        Dim kount As Integer
        Dim f As String
        Dim X As String
        Dim Y As String
        Dim sql As String
        Dim dr As New DataSet
        Dim maxrecs As Integer
        Dim descrfil As String
        Dim C1 As String

        sql = "use mysql_climsoft_db_v4; SELECT Rec, Bufr_Template, CREX_Template, Sequence_Descriptor1, Sequence_Descriptor0, Bufr_Element, Crex_Element, Climsoft_Element, Element_Name, Crex_Unit, Crex_Scale, Crex_DataWidth, Bufr_Unit, Bufr_Scale, Bufr_RefValue, Bufr_DataWidth_Bits, Observation, Crex_Data, Bufr_Data " & _
              "FROM TM_307091 WHERE (((Sequence_Descriptor1) Is Not Null)) ORDER BY Rec;"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dr.Clear()
        da.Fill(dr, "tm_307091")

        maxrecs = dr.Tables("tm_307091").Rows.Count
        Seq_Desc = ""
        descrfil = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\descriptors.txt"
        Dim DscriptorFile As System.IO.TextWriter = New StreamWriter(descrfil)

        For i = 0 To maxrecs - 1
            If Len(dr.Tables("tm_307091").Rows(i).Item("Sequence_Descriptor1")) <> 0 Then
                Seq_Desc = Seq_Desc & dr.Tables("tm_307091").Rows(i).Item("Bufr_Template")
            End If
        Next

        octetts = Len(Seq_Desc)
        'MsgBox(octetts & " " & Seq_Desc)
        Desc_Bits = ""
        C1 = ""
        For kount = 1 To octetts Step 6 ' 1 Descriptor has 6 octets
            C1 = Mid(Seq_Desc, kount, 6)
            ' Perform binary conversion
            f = Decimal_Binary(Strings.Left(C1, 1), 2)
            X = Decimal_Binary(Strings.Mid(C1, 2, 2), 6)
            Y = Decimal_Binary(Strings.Mid(C1, 4, 3), 8)

            Desc_Bits = Desc_Bits & f & X & Y
        Next
        DscriptorFile.WriteLine(C1 & "," & f & X & Y)
        DscriptorFile.Close()
        Exit Function
Err:

        Compute_Descriptors = False
        Log_Errors(Err.Description)
    End Function
    Function Decimal_Binary(DecN As Integer, bts As Integer) As String
        On Error Resume Next
        Dim r As Integer
        Dim s As Integer
        Dim num As Integer

        Decimal_Binary = "0"

        For num = 2 To bts
            Decimal_Binary = Decimal_Binary & "0"
        Next num

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
        Exit Function
    End Function

    Sub Get_Station_Settings(struc As String, ByRef delmtr As String, ByRef hdrows As Integer, ByRef txtqlfr As String, ByRef rs As DataSet)
        Dim rss As DataSet
        Dim sql As String
        Dim tot As Integer
        On Error GoTo Err
        sql = "SELECT * FROM aws_structures"
        rss = GetDataSet("aws_structures", sql)
        tot = rss.Tables("aws_structures").Rows.Count

        With rss.Tables("aws_structures")
            For i = 0 To tot - 1

                If .Rows(i).Item("strName") = struc Then
                    delmtr = .Rows(i).Item("data_delimiter")
                    hdrows = .Rows(i).Item("hdrRows")
                    If IsDBNull(.Rows(i).Item("txtQualifier")) Then
                        txtqlfr = ""
                    Else
                        txtqlfr = .Rows(i).Item("txtQualifier")
                    End If
                    sql = "use mysql_climsoft_db_v4; SELECT * FROM " & struc & " order by Cols;"

                    rs = GetDataSet(struc, sql)
                    Exit For
                End If
            Next
        End With
        Exit Sub
Err:
        Log_Errors(Err.Number & ":" & Err.Description)
    End Sub
    Function FTP_Call(ftpfile As String, ftpmethod As String) As Boolean
        FTP_Call = True
        On Error GoTo Err
        Dim ftpscript As String
        Dim ftpbatch As String
        Dim Drive1 As String
        Dim local_folder As String
        Dim out_folder As String


        Dim usr As String
        Dim pwd As String
        Dim flder As String
        Dim ftpmode As String

        Get_ftp_details(ftpmethod, ftp_host, flder, ftpmode, usr, pwd)
        FileClose(1)
        local_folder = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
        Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
        ftpscript = local_folder & "\ftp_aws.txt"
        FileOpen(1, ftpscript, OpenMode.Output)

        Select Case ftpmethod
            Case "get"

                txtinputfile = local_folder & "\" & System.IO.Path.GetFileName(ftpfile)

                If ftpmode = "psftp" Then Print(1, "cd " & flder & Chr(13) & Chr(10)) 'Print #1, "cd " & in_folder

                If ftpmode = "ftp" Then
                    Print(1, "open " & ftp_host & Chr(13) & Chr(10))
                    Print(1, usr & Chr(13) & Chr(10))
                    Print(1, pwd & Chr(13) & Chr(10))
                    Print(1, "cd " & flder & Chr(13) & Chr(10))
                    Print(1, "asc" & Chr(13) & Chr(10))

                End If
                Print(1, ftpmethod & " " & ftpfile & Chr(13) & Chr(10))
                Print(1, "bye" & Chr(13) & Chr(10))
            Case "put"
                If ftpmode = "psftp" Then Print(2, "cd " & flder & Chr(13) & Chr(10))
                If ftpmode = "ftp" Then
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
            If ftpmode = "ftp" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            If ftpmode = "psftp" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
        Else
            If ftpmode = "ftp" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            If ftpmode = "psftp" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
        End If

        Print(1, "echo on" & Chr(13) & Chr(10))
        Print(1, "EXIT" & Chr(13) & Chr(10))
        FileClose(1)


        ' Execute the batch file to transfer the aws data file from aws server to a local folder
        Shell(ftpbatch, vbMinimizedNoFocus)

        If ftpmethod = "get" Then
            ' Cause some delay to allow ftp file transfer before the processing starts.
            Dim Cdate1 As Date
            Dim tot As Integer
            Dim timeout As Integer

            Cdate1 = Now() '& " " & Time
            tot = 0
            timeout = CLng(txtTimeout.Text)
            With ProgressBar1
                .Visible = True
                .Maximum = timeout ' 60
                Do While tot < timeout
                    tot = DateDiff("s", Cdate1, Now())
                    .Value = tot
                Loop
                .Visible = False
            End With

            txtInputServer.Text = ftp_host
            txtInputfolder.Text = flder

            ' List the input file
            lstInputFiles.Items.Add(System.IO.Path.GetFileName(ftpfile))
            lstInputFiles.Refresh()
            txtInputServer.Refresh()

        Else
            txtOutputServer.Text = ftp_host
            txtOutputFolder.Text = flder

            ' List the processed output file
            lstOutputFiles.Items.Add(System.IO.Path.GetFileName(ftpfile))
            txtOutputServer.Refresh()
            txtOutputFolder.Refresh()
            lstOutputFiles.Refresh()
        End If


        If System.IO.Path.GetFileName(ftpfile).Length = 0 Then Exit Function

        'Log_Errors(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)
        Exit Function
Err:
        Log_Errors(Err.Description)
        FTP_Call = False
    End Function

    Sub Get_ftp_details(ftpmethod As String, aws_ftp As String, ByRef flder As String, ByRef ftpmode As String, ByRef usr As String, ByRef pwd As String)
        On Error GoTo Err
        Dim sql As String
        Dim rf As New DataSet
        Dim num As Integer


        Select Case ftpmethod
            Case "get"
                sql = "SELECT * FROM aws_basestation"
                rf = GetDataSet("aws_basestation", sql)

                num = rf.Tables("aws_basestation").Rows.Count

                For i = 0 To num - 1
                    With rf.Tables("aws_basestation")
                        If aws_ftp = .Rows(i).Item("ftpId") Then
                            flder = .Rows(i).Item("inputFolder")
                            ftpmode = .Rows(i).Item("ftpMode")
                            usr = .Rows(i).Item("userName")
                            pwd = .Rows(i).Item("password")
                            Exit For
                        End If
                    End With
                Next
            Case "put"
                sql = "SELECT * FROM aws_mss"
                rf = GetDataSet("aws_mss", sql)
                num = rf.Tables("aws_mss").Rows.Count

                For i = 0 To num - 1
                    With rf.Tables("aws_mss")
                        If aws_ftp = .Rows(i).Item("ftpId") Then
                            flder = .Rows(i).Item("outputFolder")
                            ftpmode = .Rows(i).Item("ftpMode")
                            usr = .Rows(i).Item("userName")
                            pwd = .Rows(i).Item("password")
                            Exit For
                        End If
                    End With
                Next
        End Select

        'rss = db.OpenRecordset("aws_sever_settings")

        'With rss
        '.MoveFirst()
        'Do While .EOF = False
        '    If .Fields("aws_ftp") = aws_ftp Then
        '        in_usr = .Fields("aws_user")
        '        in_pwd = .Fields("aws_password")
        '        in_folder = .Fields("aws_folder")
        '        aws_comm = LCase(.Fields("aws_transfer_mode"))
        '        mss_ftp = .Fields("mss_ftp")
        '        out_usr = .Fields("mss_user")
        '        out_pwd = .Fields("mss_password")
        '        out_folder = .Fields("mss_folder")
        '        mss_comm = LCase(.Fields("mss_transfer_mode"))
        '        Exit Do
        '    End If
        '    .MoveNext()
        'Loop
        'End With
        Exit Sub

Err:
        Log_Errors(Err.Description)
    End Sub

    Sub Process_Input_Record(aws_rs As String, datestring As String)

        On Error GoTo Err

        SetDataSet("station")
        With ds.Tables("station")
            For i = 0 To ds.Tables("station").Rows.Count - 1
                If .Rows(i).Item("stationId") = nat_id Then
                    '    wmo_id = .Fields("wmo_id")
                    stn_name = .Rows(i).Item("stationName")
                    lat = .Rows(i).Item("latitude")
                    lon = .Rows(i).Item("longitude")
                    elv = .Rows(i).Item("elevation")
                    Exit For
                End If
            Next
        End With
        'Log_Errors(nat_id & " " & stn_name & " " & lat & " " & lon & " " & elv)


        Process_Status(" Input file found - Extracting data")

        ''  The code below can be skipped if updating to Climsoft main database update is not necessary but TDCF required
        update_main_db(aws_rs, datestring, nat_id)

        'If Val(txtlag) = 999 Then Exit Sub ' No processing of messages if entire file processing is selected
        ''
        ' ''    min = Minute(datestring)
        ''
        ''   ' Process data according to the set time interval
        ''
        ' ''    If Val(min) Mod Val(txtinterval) = 0 Then

        '' Process any record whose datetime value is within the specified minutes interval

        '' The following code was commented to allow processing of observations for all minutes interval within the hour
        '' If Val(Minute(datestring)) Mod Val(txtinterval) = 0 Then

        ''    ' The following code was commented to allow processing of observations for all minutes interval within the hour
        ''    If Abs(Val(txtoffset) - Val(DateDiff("n", datestring, txtdate1))) <= 15 Then

        '' Display the TimeStamp for the data to be processed

        ' ''      Tlag = Val(DateDiff("h", Ltime, datestring)) * -1

        ''      Tlag = Val(DateDiff("h", datestring, Ltime))

        ''      If Val(txtlag) >= Tlag And IsDate(datestring) Then
        'If IsDate(datestring) Then
        '    'txtdate = datestring
        '    'txtdate.Refresh

        '    ' Process the messages for transmission at the scheduled time
        '    Dim ph As Integer

        '    ' ph = Int(hour(datestring))

        '    ' The source code below can be commented if processlng of TDCF is found not necessary but the Climsoft database updating goes on
        '    '    If ph Mod 3 = Int(GMT_Diff) Then update_tbltemplate rs, datestring

        '    update_tbltemplate(rs, datestring)
        'End If
        'txtdate = datestring
        '' End If
        Exit Sub
Err:
        'If Err.Number = 94 Then Resume Next
        'MsgBox "Processing input record"
        Log_Errors(Err.Description)
    End Sub

    Sub AwsRecord_Update(datastring As String, rec As Integer, flg As String, aws_struc As String)
        On Error GoTo Err
        Dim dts As Date
        Dim recUpdate As New dataEntryGlobalRoutines

        SetDataSet(aws_struc)
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        If InStr(datastring, flg) > 0 Or Len(flg) = 0 Then
            ds.Tables(aws_struc).Rows(rec).Item("obsv") = vbNullString
        Else
            ds.Tables(aws_struc).Rows(rec).Item("obsv") = datastring
        End If

        da.Update(ds, aws_struc)

        Exit Sub
Err:
        Log_Errors(Err.Number & " " & Err.Description)
    End Sub

    Sub Process_SubRecord(datastring As String, rec As Integer, flg As String, aws_struc As String)
        On Error GoTo Err
        Dim dts As Date
        Dim recUpdate As New dataEntryGlobalRoutines


        'MsgBox(datastring & " " & rec & " " & aws_struc & " " & flg)
        SetDataSet(aws_struc)
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'ds.Tables(aws_struc).Rows(rec).Item("obsv") = datastring

        If InStr(datastring, flg) > 0 Or Len(flg) = 0 Then
            ds.Tables(aws_struc).Rows(rec).Item("obsv") = vbNullString
        Else
            ds.Tables(aws_struc).Rows(rec).Item("obsv") = datastring
        End If


        da.Update(ds, aws_struc)

        'recUpdate.messageBoxRecordedUpdated()


        'datestrings = TimeStamp(rs)
        'dts = datestrings

        'If Val(txtlag) = 999 Then
        '    Process_Input_Record(rs, inrs, datestrings) ' Process the entire input file irespective of time difference
        'Else
        '    If DateDiff("h", datestrings, txttime) <= Val(txtlag) Then Process_Input_Record(rs, inrs, datestrings)
        'End If

        'datastring = ""
        'rs.MoveFirst()
        '    Tblrefresh rs
        Exit Sub
Err:
        Log_Errors(Err.Number & " " & Err.Description)
    End Sub
    Function TimeStamp(rs As DataSet) As String
        On Error GoTo Err
        Dim Date_Time As Date
        TimeStamp = ""
        ' Get Date and Time values
        'Where Date and Time are in seperate fields

        'With rs
        '    rs.MoveFirst()

        '    Do While .EOF = False
        '        If .Fields("Element_Abbreviation") = "Date/time" Then
        '            TimeStamp = .Fields("obsv")
        '            '   txtdate = TimeStamp
        '            '   txtdate.Refresh
        '            Exit Do
        '        End If

        '        ' Get the date value where date and time are in separate fields
        '        If .Fields("Element_Abbreviation") = "Date" Then
        '            Date_Time = .Fields("obsv") ' Date_Time & " " & .Fields("obsv")
        '        End If

        '        ' Get the time value and compute the DateTime string where date and time are in separate fields
        '        If .Fields("Element_Abbreviation") = "Time" Then
        '            TimeStamp = Date_Time & " " & .Fields("obsv")
        '            Exit Do
        '        End If

        '        .MoveNext()
        '    Loop

        'End With
        Exit Function
Err:

        Log_Errors(" Invalid Observation DateTime value")

    End Function

    Private Sub optStart_CheckedChanged(sender As Object, e As EventArgs) Handles optStart.CheckedChanged
        'If optStart.Checked = True Then Start_Process()
    End Sub

    Private Sub optStart_Click(sender As Object, e As EventArgs) Handles optStart.Click
        If optStart.Checked = True Then Start_Process()
    End Sub
    Sub Process_Status(msg As String)
        On Error GoTo Err

        txtStatus.Text = msg
        txtstatus.Refresh()

        Exit Sub
Err:
        Log_Errors(Err.Description)
        ' list_errors.AddItem txttime & " " & Err.description
    End Sub

    Sub update_main_db(rs_aws As String, datestr As String, stn As String)
        On Error GoTo Err

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        Dim dsdb As New DataSet
        Dim sql As String
        
        cmd.Connection = dbconn
        SetDataSet(rs_aws)

        With ds.Tables(rs_aws)

            For i = 0 To .Rows.Count - 1
                If Not IsDBNull(.Rows(i).Item("Climsoft_Element")) Then

                    sql = "use mysql_climsoft_db_v4; INSERT INTO observationinitial " & _
                        "(recordedFrom, describedBy, obsDatetime, obsLevel, obsValue) " & _
                        "SELECT '" & stn & "', '" & .Rows(i).Item("Climsoft_Element") & "', '" & datestr & "','surface','" & .Rows(i).Item("obsv") & "';"

                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                End If

            Next
        End With

        'With rs_aws
        '    .MoveFirst()
        '    Do While .EOF = False
        '        'Process_Status "Updating Climsoft database with AWS data"
        '        If Not IsNull(.Fields("Climsoft_Element")) Then ' And Not IsNull(.Fields("obsv")) Then
        '            main_obsv.AddNew()
        '            main_obsv!recorded_at = dtstr
        '            main_obsv!recorded_from = stn
        '            main_obsv!described_by = .Fields("Climsoft_Element")
        '            main_obsv!made_at = "surface"
        '            main_obsv!acquisition_type = 4
        '            main_obsv!qc_status = 0
        '            If .Fields("obsv") = "" Or IsNull(.Fields("obsv")) Then 'Missing Value
        '                main_obsv!flag = "M"
        '            Else
        '                main_obsv!obs_value = Val(.Fields("obsv")) ' Round(Val(.Fields("obsv")) / Val(element_scale(.Fields("climsoft"), maindb)), 0)
        '                If Not IsNull(.Fields("lower_limit")) And Not IsNull(.Fields("upper_limit")) Then If QC_Limit_Err(.Fields("lower_limit"), .Fields("upper_limit"), .Fields("obsv")) Then main_obsv!flag = "D"
        '            End If
        '            main_obsv.Update()
        '        End If
        '        .MoveNext()
        '    Loop
        'End With

        '' Update QC values
        'Dim aws_qc As dao.Recordset
        'Dim qc_err As Boolean
        'qc_err = False
        'Set aws_qc = maindb.OpenRecordset("aws_qc_limits_check_output")
        '.MoveFirst
        'Do While .EOF = False
        ' If Not IsNull(.Fields("obsv")) Then
        '   ' Check for lower limit exceeding
        '   If Not IsNull(.Fields("lower_limit")) Then
        '      If Val(.Fields("lower_limit")) > Val(.Fields("obsv")) Then
        '       ' Update Lower limt QC values
        '       qc_err = True
        '       aws_qc.addnew
        '       aws_qc!val_limit_diff = Val(.Fields("obsv")) - Val(.Fields("lower_limit"))
        '       aws_qc!limit_type = "Lower_Limit"
        '      End If
        '   End If
        '  'Check for upper limit exceeding
        '    If Not IsNull(.Fields("upper_limit")) Then
        '      If Val(.Fields("lower_limit")) < Val(.Fields("obsv")) Then
        '       ' Update upper limt QC values
        '       aws_qc.addnew
        '       qc_err = True
        '       aws_qc.addnew
        '       aws_qc!val_limit_diff = Val(.Fields("obsv")) - Val(.Fields("upper_limit"))
        '       aws_qc!limit_type = "Upper_Limit"
        '      End If
        '   End If
        ' End If
        ' If qc_err = True Then ' Update if QC exists
        '   aws_qc!obsv_value = .Fields("obsv")
        '   aws_qc!obsv_level = "surface"
        '   aws_qc.update
        ' End If
        '
        '.MoveNext
        'Loop
        '
        'End With
        Exit Sub
Err:
        'MsgBox dtstr & " " & Err.Number & ":" & Err.description
        'If Err.Number = 3155 Then MsgBox dtstr & " " & stn & " " & rs_aws.Fields("climsoft") & " " & rs_aws.Fields("obsv")
        'If Err.Number = 3421 Then Exit Sub
        'If Err.Number = 3022 Then Resume Next
        'If Err.Number = 3146 Then Resume Next
        Log_Errors(Err.Number & ":" & Err.Description)
        'list_errors.AddItem txttime & "  " & Err.description
        'MsgBox Err.Number & " " & Err.description
    End Sub

End Class

Public Class FTP

    Dim ftpserver As FtpStatusCode

End Class