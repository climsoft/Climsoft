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
    Dim BUFR_header As String
    Dim msg_header, msg_file As String
    Dim datt As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand


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
        Timer1.Start()
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
        'SetDataSet("aws_sites")

        FillList(txtDataStructure, "aws_structures", "strName")
        FillList(txtSiteID, "station", "stationId")
        FillList(txtSiteName, "station", "stationName")
        FillList(txtIP, "aws_basestation", "ftpId")

        'PopulateForm("sites", txtsitesNav, rec)
        DataGridViewSites.Visible = False
        SetDataSet("aws_sites")
        rec = 0
        PopulateForm("sites", txtSitesNavigator, rec)
        'rec = 0
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

        rec = 0
        SetDataSet("aws_basestation")
        PopulateForm("bss", txtbssNavigator, rec)

    End Sub

    Private Sub cmdMSS_Click(sender As Object, e As EventArgs) Handles cmdMSS.Click
        pnlBaseStation.Visible = False
        pnlMSS.Visible = True
        pnlMSS.Enabled = True

        rec = 0
        SetDataSet("aws_mss")
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
        Log_Errors(Err.Description & " SetDataset")
        'MsgBox(Err.Description)
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
                txtSiteID.Text = ds.Tables("aws_sites").Rows(num).Item("SiteID")
                txtSiteName.Text = ds.Tables("aws_sites").Rows(num).Item("SiteName")
                txtInFile.Text = ds.Tables("aws_sites").Rows(num).Item("InputFile")
                txtDataStructure.Text = ds.Tables("aws_sites").Rows(num).Item("DataStructure")
                txtFlag.Text = ds.Tables("aws_sites").Rows(num).Item("MissingDataFlag")
                txtIP.Text = ds.Tables("aws_sites").Rows(num).Item("awsServerIp")
                chkOperational.Checked = ds.Tables("aws_sites").Rows(num).Item("OperationalStatus")

            Case "pnlDataStructures"


        End Select

        navbar.Text = ""
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
                txtSiteID.Text = ""
                txtSiteName.Text = ""
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

            MsgBox("Confirm Password" & " " & txtMSSConfirm.Text)
            'txtMSSConfirm.Clear()
            'txtMSSPW.Clear()
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

        'sql = "SELECT * FROM aws_sites"
        'ds = GetDataSet("aws_sites", sql)

        dsNewRow = ds.Tables("aws_sites").NewRow
        dsNewRow.Item("SiteID") = txtSiteID.Text
        dsNewRow.Item("SiteName") = txtSiteName.Text
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

        ds.Tables("aws_sites").Rows(rec).Item("SiteID") = txtSiteID.Text
        ds.Tables("aws_sites").Rows(rec).Item("SiteName") = txtSiteName.Text
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

        dstn = GetDataSet(tbl, sql)
        lst.Items.Clear()

        For i = 0 To dstn.Tables(tbl).Rows.Count - 1
            lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(lstfld))
        Next
        lst.Refresh()
    End Sub

    Private Sub cmbExistingStructures_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbExistingStructures.SelectedIndexChanged
        Try
            SetDataSet("aws_structures")

            For i = 0 To Kount - 1
                If cmbExistingStructures.Text = ds.Tables("aws_structures").Rows(i).Item("strName") Then
                    If Not IsDBNull(ds.Tables("aws_structures").Rows(i).Item("strName")) Then txtStrName.Text = ds.Tables("aws_structures").Rows(i).Item("strName")
                    If Not IsDBNull(ds.Tables("aws_structures").Rows(i).Item("strName")) Then txtDelimiter.Text = ds.Tables("aws_structures").Rows(i).Item("data_delimiter")
                    If Not IsDBNull(ds.Tables("aws_structures").Rows(i).Item("hdrRows")) Then txtHeaders.Text = ds.Tables("aws_structures").Rows(i).Item("hdrRows")
                    If Not IsDBNull(ds.Tables("aws_structures").Rows(i).Item("txtQualifier")) Then txtQualifier.Text = ds.Tables("aws_structures").Rows(i).Item("txtQualifier")
                    lblRecords.Text = "Rec: " & i + 1
                End If
            Next
            DataGridFill(txtStrName.Text)
        Catch ex As Exception
            DataGridViewStructures.Visible = False
            MsgBox(ex.Message)
        End Try
        'Err:
        '        MsgBox(Err.Description)
        '        DataGridViewStructures.Visible = False
        '        If Err.Number = 13 Then Exit Sub
        '        MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdCreate_Click(sender As Object, e As EventArgs) Handles cmdCreate.Click
        On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim str As New DataSet
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand

        'str = GetDataSet("aws_structures", "Select * from aws_structures")

        'dsNewRow = str.Tables("aws_structures").NewRow
        'dsNewRow.Item("strName") = txtStrName.Text
        'dsNewRow.Item("data_delimiter") = txtDelimiter.Text
        'dsNewRow.Item("hdrRows") = txtHeaders.Text
        'dsNewRow.Item("txtQualifier") = txtQualifier.Text

        ''Add a new record to the data source table
        'str.Tables("aws_structures").Rows.Add(dsNewRow)
        'da.Update(str, "aws_structures")

        'recEdit.messageBoxCommit()

        comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
        'sql0 = "INSERT INTO `mysql_climsoft_db_v4`.`aws_structures` (`strName`, `data_delimiter`, `hdrRows`, `txtQualifier`)" & " VALUES ('" & txtStrName.Text & "', '" & txtDelimiter.Text & "', '" & txtHeaders.Text & "', '" & txtQualifier.Text & "');"
        sql0 = "INSERT INTO `aws_structures` (`strName`, `data_delimiter`, `hdrRows`, `txtQualifier`)" & " VALUES ('" & txtStrName.Text & "', '" & txtDelimiter.Text & "', '" & txtHeaders.Text & "', '" & txtQualifier.Text & "');"

        comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
        comm.ExecuteNonQuery()   ' Execute the query


        '' Create a table for the new structure

        '        CREATE TABLE `aws_rwanda4` (
        '	`Cols` INT(11) NOT NULL,
        '	`Element_Name` VARCHAR(20) NULL DEFAULT NULL,
        '	`Element_Abbreviation` VARCHAR(20) NULL DEFAULT NULL,
        '	`Element_Details` VARCHAR(25) NULL DEFAULT NULL,
        '	`Climsoft_Element` VARCHAR(6) NULL DEFAULT NULL,
        '	`Bufr_Element` VARCHAR(6) NULL DEFAULT NULL,
        '	`unit` VARCHAR(15) NULL DEFAULT NULL,
        '	`lower_limit` VARCHAR(10) NULL DEFAULT NULL,
        '	`upper_limit` VARCHAR(10) NULL DEFAULT NULL,
        '	`obsv` VARCHAR(25) NULL DEFAULT NULL,
        '	PRIMARY KEY (`Cols`)
        ')
        'COLLATE='utf8_general_ci'
        '        ENGINE = InnoDB
        ';
        Dim tbl As String = txtStrName.Text
        'sql0 = "CREATE TABLE `mysql_climsoft_db_v4`.`" & txtStrName.Text & "` " & _
        sql0 = "CREATE TABLE `" & txtStrName.Text & "` " & _
               "( " & _
                "`Cols` INT NOT NULL, " & _
                "`Element_abbreviation` VARCHAR(20) NULL DEFAULT NULL, " & _
                "`Element_Name` VARCHAR(20) NULL DEFAULT NULL, " & _
                "`Element_Details` VARCHAR(25) NULL DEFAULT NULL, " & _
                "`Climsoft_Element` VARCHAR(6) NULL DEFAULT NULL, " & _
                "`Bufr_Element` VARCHAR(6) NULL DEFAULT NULL, " & _
                "`unit` VARCHAR(15) NULL DEFAULT NULL, " & _
                "`lower_limit` VARCHAR(10) NULL DEFAULT NULL, " & _
                "`upper_limit` VARCHAR(10) NULL DEFAULT NULL, " & _
                "`obsv` VARCHAR(25) NULL DEFAULT NULL, " & _
                "UNIQUE KEY `identification` (`Cols`) " & _
             ") COLLATE='utf8_general_ci';"
        'MsgBox(sql0)



        comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
        comm.ExecuteNonQuery()   ' Execute the query

        ' Display the created table on the DataGrid

        DataGridFill(txtStrName.Text)
        FillList(cmbExistingStructures, "aws_structures", "strName")
        cmbExistingStructures.Refresh()
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        'MsgBox(Strings.Right(txtRecNo.Text, 1))
        Try
            Dim recs As Integer
            recs = Int(Strings.Right(lblRecords.Text, 1)) - 1 ' Record number for the selected structure in the aws_structures table
            RecordUpdate("aws_structures", "pnlDataStructures", recs, "update")
            FillList(cmbExistingStructures, "aws_structures", "strName")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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
        DataGridViewStructures.Visible = True
        DataGridViewStructures.Height = 100 + DataGridViewStructures.RowCount * 17
        If DataGridViewStructures.Height > 320 Then DataGridViewStructures.Height = 320
        'DataGridViewStructures.Height = 330
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
        On Error GoTo Err


        Ltime.Text = Now
        txtDateTime.Text = Ltime.Text

        ' Set the next encoding time
        If Len(txtNxtProcess.Text) = 0 Then
            'MsgBox(0)
            txtNxtProcess.Text = DateAdd("n", Val(txtOffset.Text) - Val(Minute(Ltime.Text)), Ltime.Text)
            'optStart.Checked = True
        End If

        If optStart.Checked = True Then
            'Log_Errors(DateDiff("n", txtDateTime.Text, txtNxtProcess.Text))
            If DateDiff("n", txtDateTime.Text, txtNxtProcess.Text) <= 0 Then
                Start_Process()
            End If
        End If

        Exit Sub
Err:
        Log_Errors(Err.Description)
        If Err.Number = 13 Then
            Resume Next
        Else
            Log_Errors(Err.Number & ":" & Err.Description)
            'Log_Errors "Err.description"  'MsgBox Err.Number & ":" & Err.description
        End If
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
        Next_Encoding_Time()
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
        Dim dTable As DataTable


        ' Open the data set for the AWS sites and stations
        SetDataSet("aws_sites")

        If ds.Tables("aws_sites").Rows.Count = 0 Then
            Log_Errors("No AWS sites defined. Refer to the Manuals then use the Tab 'Sites' to define the installed AWS sites")
            Me.Cursor = Cursors.Default
            optStop.Checked = True
            Exit Sub
        End If

        '  Locate and processs aws input data files
        Me.Cursor = Cursors.WaitCursor

        ' Compute the Template descriptor to Bianry form
        If Not Compute_Descriptors(Desc_Bits) Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        Bufr_Subst = 0
        BUFR_Subsets_Data = ""

        'Get full path for the Subsets Output file file and create the file
        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_subsets.csv"

        FileOpen(30, fl, OpenMode.Output)

        'WriteLine(1, "Testing")
        'FileClose(1)


        Dim i As Integer

        With ds.Tables("aws_sites")
            For i = 0 To .Rows.Count - 1 'Kount - 1

                'MsgBox(.Rows(i).Item("InputFile"))

                If Not IsDBNull(.Rows(i).Item("InputFile")) And .Rows(i).Item("OperationalStatus") = 1 Then
                    'Log_Errors(.Rows(i).Item("InputFile"))
                    'MsgBox(.Rows(i).Item("InputFile"))
                    ' Get station data details
                    nat_id = .Rows(i).Item("SiteID")

                    'MsgBox(nat_id)
                    'msg_header = .Rows(i).Item("aws_msg")
                    'MsgBox(msg_header)
                    flg = ""
                    If Len(.Rows(i).Item("MissingDataFlag")) <> 0 Then flg = .Rows(i).Item("MissingDataFlag") 'flg = "M"
                    'End If
                    AWSsite = .Rows(i).Item("DataStructure")
                    Get_Station_Settings(AWSsite, delmtr, hdrows, txtqlfr, rs)

                    ftp_host = .Rows(i).Item("awsServerIp")

                    'MsgBox(ftp_host)
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
                    'MsgBox(i & infile)
                    Process_Status("Seeking input data - " & infile)
                    txtStatus.Refresh()

                    If Not FTP_Call(infile, "get") Then
                        Log_Errors("Can't retrieve data from input file " & infile)
                        'list_errors.Refresh()
                        'GoTo Continues
                    End If

                    'Log_Errors(rs.Tables(.Rows(i).Item("DataStructure")).Rows(0).Item("Element_Abbreviation"))
                    'Log_Errors(infile
                    ''End If

                    ' ''Next

                    ''End With

                    FileClose(1)
                    txtStatus.Text = "Organising the input file"

                    ' Assign a variable to an input file with header rows
                    aws_input_file = txtinputfile

                    ' Assign a variable to an output file without header rows
                    aws_input_file_flds = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\aws_input.txt" 'fso.GetParentFolderName(App.Path) & "\data\aws_input.txt"

                    FileOpen(10, aws_input_file, OpenMode.Input)
                    FileOpen(11, aws_input_file_flds, OpenMode.Output)

                    ' Skip header Records if present

                    'Retrieve header rows from station parameters
                    If Val(hdrows) > 0 Then
                        For j = 0 To Val(hdrows) - 1
                            aws_data = LineInput(10)
                            'MsgBox(aws_data)
                        Next
                    End If

                    ' Output the data rows
                    Do While EOF(10) = False
                        aws_data = LineInput(10)
                        PrintLine(11, aws_data)
                    Loop

                    FileClose(10)
                    FileClose(11)
                    Dim colmn As Integer
                    Dim rws As Long
                    Dim x As String

                    'MsgBox(aws_input_file)
                    'ChrW(delimiter_ascii)
                    dTable = Text_To_DataTable(aws_input_file_flds, ChrW(delimiter_ascii), 0, colmn, rws)


                    For k = 0 To rws - 2

                        'Skip older records
                        datestring = dTable.Rows(k).Item(0)

                        If InStr(datestring, txtqlfr) > 0 And Len(txtqlfr) > 0 Then datestring = Strings.Mid(datestring, 2, Len(datestring) - 2)
                        'MsgBox(DateAndTime.Year(datestring))
                        If DateDiff("h", datestring, txtDateTime.Text) > Val(txtPeriod.Text) And Val(txtPeriod.Text) <> 999 Then Continue For
                        'Log_Errors(datestring & " " & DateDiff("h", datestring, txtDateTime.Text) & " " & Val(txtPeriod.Text))

                        Process_Status("Processing AWS Record " & k & " of " & rws)

                        For j = 0 To colmn - 1
                            x = dTable.Rows(k).Item(j)
                            If InStr(x, txtqlfr) > 0 And Len(txtqlfr) > 0 Then
                                x = Strings.Mid(x, 2, Len(x) - 2)
                            End If
                            'MsgBox(x)
                            AwsRecord_Update(x, j, flg, AWSsite)
                            'MsgBox(x)
                        Next

                        ' Analyse the datetime string and process the data if the encoding time interval matches datetime value
                        Dim sqlv As String
                        sqlv = "SELECT * FROM " & AWSsite & " order by Cols"
                        rs = GetDataSet(AWSsite, sqlv)

                        'Get the date value
                        datestring = rs.Tables(AWSsite).Rows(0).Item("obsv")

                        'Sametimes Date and Time values are separately listed in the 1st and 2nd fields respectively. In such cases they are combined
                        If Len(datestring) < 12 Then
                            datestring = rs.Tables(AWSsite).Rows(0).Item("obsv") & " " & rs.Tables(AWSsite).Rows(1).Item("obsv")
                        End If

                        'Don't process the record if having invalid datestamp
                        If Not IsDate(datestring) Then
                            Log_Errors(datestring)
                        End If

                        'Update the record into the database
                        If Val(txtPeriod.Text) = 999 Then
                            ' Process the entire input file irespective of time difference
                            Process_Input_Record(AWSsite, datestring)
                        Else
                            'Process_Input_Record(AWSsite, datestring)
                            'Log_Errors(DateDiff("h", datestring, txtDateTime.Text) & "<= " & Val(txtPeriod.Text - 1))
                            If DateDiff("h", datestring, txtDateTime.Text) <= Val(txtPeriod.Text - 1) Then
                                Process_Input_Record(AWSsite, datestring) 'Process_Input_Record(datestring)
                            End If
                        End If

                    Next


                    'FileClose(11)
                    '  Close #11

                    ' Delete input file from base station server if so selected
                    If chkDeleteFile.Checked Then
                        If Not FTP_Delete_InputFile(infile) Then Log_Errors("Can't Delete Input File") 'MsgBox "Can't Delete Input File"
                    End If

                End If

                'Continues:
                ' Next Input file
                '' Refresh form

                'frm_realtime.Refresh()
                '.MoveNext()

                'Loop

            Next i
        End With

Continues:
        ' Compose the BUFR Bulletins
        FileClose(30)

        ' Open the output file containing the encoded BUFR Subsets data
        fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\bufr_subsets.csv"

        FileOpen(30, fl, OpenMode.Input)

        Dim dts(1000) As String
        Dim subs(1000) As String
        Dim Tsubs As Integer
        'Dim kount As Integer
        Dim Tdone As String
        Dim subst As String

        ' Load the subsets records from an output file into arrays
        Kount = 0
        Do While EOF(30) = False
            Input(30, dts(Kount))
            Input(30, subs(Kount))
            'MsgBox(dts(Kount) & "-" & subs(Kount))
            Kount = Kount + 1
        Loop

        If Kount = 1 Then ' Only one substest existing
            If Len(subs(0)) <> 0 Then
                BUFR_header = msg_header & " " & Format(DateAndTime.Day(dts(0)), "00") & Format(DateAndTime.Hour(dts(0)), "00") & Format(DateAndTime.Minute(dts(0)), "00") '& " " & txtBBB
                AWS_BUFR_Code(BUFR_header, DateAndTime.Year(dts(0)), DateAndTime.Month(dts(0)), DateAndTime.Day(dts(0)), DateAndTime.Hour(dts(0)), DateAndTime.Minute(dts(0)), DateAndTime.Second(dts(0)), subs(0))
            End If
        End If

        If Kount > 1 Then ' More than one Subset exists

            ' Initialize the datetime for the compiled BUFR bulletin
            Tdone = "00/00/0000 00:00:00"

            ' Combine the Subsets for the same hour into a single bulletin
            For i = 0 To Kount - 1

                subst = ""
                Bufr_Subst = 0
                For j = 0 To Kount - 1
                    If dts(j) = dts(i) And InStr(Tdone, dts(j)) = 0 Then
                        Bufr_Subst = Bufr_Subst + 1
                        subst = subst + subs(j)
                    End If
                Next

                ' Compile a bulletin for the located same hour subsets
                If Len(subst) <> 0 Then
                    BUFR_header = msg_header & " " & Format(DateAndTime.Day(dts(i)), "00") & Format(DateAndTime.Hour(dts(i)), "00") & Format(DateAndTime.Minute(dts(i)), "00") '& " " & txtBBB
                    AWS_BUFR_Code(BUFR_header, DateAndTime.Year(dts(i)), DateAndTime.Month(dts(i)), DateAndTime.Day(dts(i)), DateAndTime.Hour(dts(i)), DateAndTime.Minute(dts(i)), DateAndTime.Second(dts(i)), subst)
                End If
                Tdone = Tdone & dts(i)
            Next
        End If

        FileClose(31)
        FileClose(30)
        Me.Cursor = Cursors.Default
        Exit Sub

Err:
        'MsgBox(Err.Number & " " & Err.Description)
        'If Err.Number = 9 Then Resume Next
        ''MsgBox(datt & " " & datestring)
        If Err.Number = 62 Or Err.Number = 9 Then
            'Log_Errors("Can't retrieve data from " & infile)
            'list_errors.Refresh()
            GoTo Continues

        End If
        'If Err.Number = 3349 Then Resume Next
        ''   MsgBox Err.Number & " " & Err.description
        'MsgBox("Process_input_data")
        Log_Errors(Err.Number & ": " & Err.Description & " at process_input_data")
        Me.Cursor = Cursors.Default
        FileClose(10)
        FileClose(11)
        FileClose(30)
        FileClose(31)
    End Sub
    'Sub Next_Encoding_Time()

    'End Sub
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

        'sql = "use mysql_climsoft_db_v4; SELECT Rec, Bufr_Template, CREX_Template, Sequence_Descriptor1, Sequence_Descriptor0, Bufr_Element, Crex_Element, Climsoft_Element, Element_Name, Crex_Unit, Crex_Scale, Crex_DataWidth, Bufr_Unit, Bufr_Scale, Bufr_RefValue, Bufr_DataWidth_Bits, Observation, Crex_Data, Bufr_Data " & _
        sql = "SELECT Rec, Bufr_Template, CREX_Template, Sequence_Descriptor1, Sequence_Descriptor0, Bufr_Element, Crex_Element, Climsoft_Element, Element_Name, Crex_Unit, Crex_Scale, Crex_DataWidth, Bufr_Unit, Bufr_Scale, Bufr_RefValue, Bufr_DataWidth_Bits, Observation, Crex_Data, Bufr_Data " & _
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
        On Error GoTo Err 'Resume Next
        Dim r As Integer
        Dim s As Integer
        Dim num As Integer
        'MsgBox(DecN & " " & bts)
        Decimal_Binary = "0"

        For num = 2 To bts
            Decimal_Binary = Decimal_Binary & "0"
        Next num

        s = 0
        If DecN > 1 Then
            ' Binary conversion for Deimal numbers greater than 1
            Do While DecN > 1
                r = DecN Mod 2
                Mid(Decimal_Binary, bts - s, 1) = r
                If r = 1 Then
                    DecN = DecN / 2 - 0.5
                Else
                    DecN = DecN / 2
                End If
                s = s + 1
            Loop
            ' Binary conversion for Decimal numbers 1 or 0
        Else
            Mid(Decimal_Binary, bts, 1) = DecN
            'MsgBox(DecN & " " & bts & " " & Decimal_Binary)
        End If


        Exit Function
Err:
        Log_Errors(Err.Number & " " & Err.Description)
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
                    'msg_header = .Rows(i).Item("aws_msg")
                    If IsDBNull(.Rows(i).Item("txtQualifier")) Then
                        txtqlfr = ""
                    Else
                        txtqlfr = .Rows(i).Item("txtQualifier")
                    End If
                    'sql = "use mysql_climsoft_db_v4; SELECT * FROM " & struc & " order by Cols;"
                    sql = "SELECT * FROM " & struc & " order by Cols;"

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

        'MsgBox(ftpfile & " " & ftpmethod)
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
        'MsgBox(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)
        FileClose(1)
        local_folder = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
        Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
        Drive1 = Strings.Left(Drive1, Len(Drive1) - 1)
        ftpscript = local_folder & "\ftp_aws.txt"
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
            If ftpmode = "FTP" Then Print(1, ftpmode & " -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            'If ftpmode = "FTP" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            If ftpmode = "PSFTP" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
        Else
            If ftpmode = "FTP" Then Print(1, ftpmode & " -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            'If ftpmode = "FTP" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
            If ftpmode = "PSFTP" Then Print(1, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
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

        'MsgBox(aws_ftp)
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
        Dim str As DataSet
        Dim sql2 As String


        sql2 = "SELECT * FROM station"

        str = GetDataSet("station", sql2)
        'Log_Errors(str.Tables("station").Rows(0).Item("stationId"))
        With str.Tables("station")
            For i = 0 To .Rows.Count - 1
                If .Rows(i).Item("stationId") = nat_id Then
                    '    wmo_id = .Fields("wmo_id")
                    If Not IsDBNull(.Rows(i).Item("stationName")) Then stn_name = .Rows(i).Item("stationName")
                    If Not IsDBNull(.Rows(i).Item("latitude")) Then lat = .Rows(i).Item("latitude")
                    If Not IsDBNull(.Rows(i).Item("longitude")) Then lon = .Rows(i).Item("longitude")
                    If Not IsDBNull(.Rows(i).Item("elevation")) Then elv = .Rows(i).Item("elevation")
                    Exit For
                End If
            Next
        End With
        'Log_Errors(nat_id & " " & stn_name & " " & lat & " " & lon & " " & elv)


        'Process_Status(" Processing input record")

        ''  The code below can be skipped if updating to Climsoft main database update is not necessary but TDCF required
        update_main_db(aws_rs, datestring, nat_id)

        If Val(txtPeriod.Text) = 999 Then Exit Sub ' No processing of messages if entire file processing is selected

        If IsDate(datestring) Then
            ' Process the messages for transmission at the scheduled time
            ' Temporarily suspended
            'update_tbltemplate(aws_rs, datestring)

        End If
        txtLastProcess.Text = datestring
        'End If
        Exit Sub
Err:
        'If Err.Number = 94 Then Resume Next
        'MsgBox "Processing input record"
        'MsgBox("Process_input_record")
        Log_Errors(Err.Number & ": " & Err.Description & " at Process_Input_Record")
    End Sub

    Sub AwsRecord_Update(datastring As String, rec As Integer, flg As String, aws_struc As String)

        On Error GoTo Err
        Dim dts As Date
        Dim sql1 As String
        Dim awsr As DataSet
        Dim obsdata As String
        'Dim recUpdate As New dataEntryGlobalRoutines
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        cmd.Connection = dbconn

        'MsgBox(datastring & " " & rec & " " & flg & " " & aws_struc)

        txtStatus.Text = "Updating AWS Record"

        'Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'sql1 = "SELECT * FROM " & aws_struc

        'awsr = GetDataSet(aws_struc, sql1)

        'If InStr(datastring, flg) > 0 Or Len(flg) = 0 Then
        'If Len(flg) > 0 Then
        If datastring = flg Then
            obsdata = vbNullString
            'awsr.Tables(aws_struc).Rows(rec).Item("obsv") = vbNullString
        Else
            obsdata = datastring
            'awsr.Tables(aws_struc).Rows(rec).Item("obsv") = datastring
        End If

        sql1 = "UPDATE " & aws_struc & " SET obsv = '" & obsdata & "' where cols = '" & rec + 1 & "';"

        cmd.CommandText = sql1
        cmd.ExecuteNonQuery()

        ''MsgBox(datastring)
        'da.Update(awsr, aws_struc)
        'awsr.Clear()
        ''Log_Errors(rec)
        Exit Sub

Err:
        Log_Errors(Err.Number & " " & Err.Description & " at AwsRecord_Update")
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
        'If optStart.Checked = True Then Start_Process()
        Start_Process()
    End Sub
    Sub Process_Status(msg As String)
        On Error GoTo Err

        txtStatus.Text = msg
        txtStatus.Refresh()

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
        Dim sql, sql3 As String
        Dim obs, flgs, units As String
        Dim mysqldate As String

        sql3 = "SELECT * FROM " & rs_aws
        cmd.Connection = dbconn
        'SetDataSet(rs_aws)
        dsdb = GetDataSet(rs_aws, sql3)
        ' Construct datetime string from DateTime data value that conforms to Mysql datetime format
        mysqldate = DateAndTime.Year(datestr) & "/" & DateAndTime.Month(datestr) & "/" & DateAndTime.Day(datestr) & " " & DateAndTime.Hour(datestr) & ":" & DateAndTime.Minute(datestr) & ":" & DateAndTime.Second(datestr)


        With dsdb.Tables(rs_aws)
            'Process_Status("Updating Climsoft database with AWS data")

            For i = 0 To .Rows.Count - 1
                flgs = ""
                If Not IsDBNull(.Rows(i).Item("Climsoft_Element")) And Not IsDBNull(.Rows(i).Item("obsv")) Then
                    obs = .Rows(i).Item("obsv")
                    If Not IsDBNull(.Rows(i).Item("lower_limit")) And Not IsDBNull(.Rows(i).Item("upper_limit")) Then
                        QC_Limits(stn, .Rows(i).Item("Climsoft_Element"), obs, .Rows(i).Item("lower_limit"), .Rows(i).Item("upper_limit"))
                    End If

                    If Not IsDBNull(.Rows(i).Item("unit")) Then
                        units = .Rows(i).Item("unit")
                        If units = "knots" Then obs = Val(obs) / 2
                        If units = "HPa" Then obs = Val(obs) * 100
                    End If

                    'If Not IsDBNull(.Rows(i).Item("unit")) And .Rows(i).Item("unit") = "Knots" Then obs = Val(obs) / 2 ' Convert Values in Knots into M/s
                    'If Not IsDBNull(.Rows(i).Item("unit")) And .Rows(i).Item("unit") = "HPa" Then obs = Val(obs) * 100 ' Convert Values in Hpa into Pa
                    'sql = "use mysql_climsoft_db_v4; INSERT INTO observationfinal " & _
                    sql = "INSERT INTO observationfinal " & _
                        "(recordedFrom, describedBy, obsDatetime, obsLevel, obsValue,flag) " & _
                        "SELECT '" & stn & "', '" & .Rows(i).Item("Climsoft_Element") & "', '" & mysqldate & "','surface','" & obs & "','" & flgs & "';"

                    'Log_Errors(sql)
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                End If
            Next
        End With

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
        'If Err.Number = 3421 Then Exit Sub
        'If Err.Number = 3022 Then Resume Next
        'If Err.Number = 3146 Then Resume Next
        If Err.Number = 5 Then Resume Next
        'MsgBox(" Update_main_db")
        Log_Errors(Err.Number & ":" & Err.Description & "  at Update_main_db")
    End Sub
    Sub QC_Limits(stn As String, elms As String, obs As String, L_limit As String, U_limit As String)
    
        Try
 
            If Val(obs) < Val(L_limit) Or Val(obs) > U_limit Then
                Dim errdata, limittype As String
                'Get full path for the Subsets Output file file and create the file
                fl = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\aws_qc_errors.csv"
                FileOpen(21, fl, OpenMode.Append)

                If Val(obs) < Val(L_limit) Then limittype = "below limit"
                If Val(obs) > Val(U_limit) Then limittype = "above limit"

                errdata = stn & "," & elms & "," & obs & "," & limittype

                PrintLine(21, errdata)
                FileClose(21)
            End If
            'End If
        Catch ex As Exception
            FileClose(21)
            'Log_Errors(ex.HResult & ":" & ex.Message & "  at QC_Limits")
        End Try

    End Sub
    Sub update_tbltemplate(aws_struct As String, Date_Time As String)

        On Error GoTo Err

        Dim trs As DataSet
        Dim sql As String
        Dim yy, mm, dd, hh, min, ss As String
        Dim Seq_Desc As String
        Dim tt_aws As String
        Dim obsv As String
        Dim InitValue As String
        Dim BufrSection4 As String
        Dim hdr As String

        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
        cmd.Connection = dbconn

        tt_aws = txtTemplate.Text
        sql = "SELECT * FROM " & tt_aws & " ORDER BY Rec"
        trs = GetDataSet(tt_aws, sql)

        '    With trs
        '        '  .MoveFirst
        yy = DateAndTime.Year(Date_Time)
        mm = DateAndTime.Month(Date_Time)
        dd = DateAndTime.Day(Date_Time)
        hh = Val(DateAndTime.Hour(Date_Time)) - Int(txtGMTDiff.Text)
        min = DateAndTime.Minute(Date_Time)
        ss = DateAndTime.Second(Date_Time)
        wmo_id = 63999

        BUFR_header = msg_header & " " & Format(dd, "00") & Format(hh, "00") & Format(min, "00") '& " " & txtBBB

        Process_Status("Updating TDCF Template with observations ")

        'Initialize with missing values

        Seq_Desc = ""

        With trs.Tables(tt_aws)

            For i = 0 To .Rows.Count - 1
                ' If Len(.Fields("Sequence_Descriptor1")) <> 0 Then Seq_Desc = Seq_Desc & .Fields("Sequence_Descriptor1")
                'If Len(Initialize_CodeFlag(trs, i)) <> 0 Then MsgBox(Initialize_CodeFlag(trs, i))

                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                Dim recUpdate As New dataEntryGlobalRoutines

                If Strings.Left(.Rows(i).Item("Bufr_Element"), 1) = 0 And .Rows(i).Item("Bufr_Element") <> "031000" And .Rows(i).Item("Bufr_Element") <> "004025" Then ' Element Descriptors only but not Delayed factor. It is preset
                    InitValue = "1"
                    For j = 2 To Val(.Rows(i).Item("Bufr_DataWidth_Bits"))
                        InitValue = InitValue & "1"
                    Next j
                    .Rows(i).Item("Bufr_Data") = InitValue

                End If
                'If Len(Initialize_CodeFlag(trs, i)) <> 0 Then MsgBox(Initialize_CodeFlag(trs, i))

                If .Rows(i).Item("Bufr_Element") = "001001" Then .Rows(i).Item("Observation") = Strings.Left(wmo_id, 2)
                If .Rows(i).Item("Bufr_Element") = "001002" Then .Rows(i).Item("Observation") = Strings.Right(wmo_id, 3)
                If .Rows(i).Item("Bufr_Element") = "001015" Then .Rows(i).Item("Observation") = stn_name
                If .Rows(i).Item("Bufr_Element") = "005001" Then .Rows(i).Item("Observation") = lat
                If .Rows(i).Item("Bufr_Element") = "006001" Then .Rows(i).Item("Observation") = lon
                If .Rows(i).Item("Bufr_Element") = "007030" Then .Rows(i).Item("Observation") = elv

                If .Rows(i).Item("Bufr_Element") = "004001" Then .Rows(i).Item("Observation") = yy 'obsv = yy
                If .Rows(i).Item("Bufr_Element") = "004002" Then .Rows(i).Item("Observation") = mm 'obsv = mm
                If .Rows(i).Item("Bufr_Element") = "004003" Then .Rows(i).Item("Observation") = dd 'obsv = dd
                If .Rows(i).Item("Bufr_Element") = "004004" Then .Rows(i).Item("Observation") = hh 'obsv = hh
                If .Rows(i).Item("Bufr_Element") = "004005" Then .Rows(i).Item("Observation") = min 'obsv = min

                'MsgBox(.Rows(i).Item("Bufr_Data") & " " & .Rows(i).Item("Bufr_Element"))
                da.Update(trs, tt_aws)

            Next i
        End With

        ' Initialize Code and Flag Tables
        Initialize_CodeFlag(trs, tt_aws)

        ' Update Template with AWS observation values
        sql = "UPDATE " & aws_struct & " INNER JOIN " & tt_aws & " ON " & aws_struct & ".Bufr_Element = " & tt_aws & ".Bufr_Element SET " & tt_aws & ".Observation = " & aws_struct & ".obsv;"

        cmd.CommandText = sql
        cmd.ExecuteNonQuery()


        '    ' Update Template with Replicated Values
        Replicate_SoilTemp(trs, aws_struct, tt_aws)
        Replicate_MaxGust(trs, aws_struct, tt_aws)

        '    ' Encode observations in the template into TDCF-BUFR
        TDCF_Encode(trs, tt_aws)

        ' Compose data for BUFR Section 4 - Data Section
        sql = "SELECT TM_307091.Rec, TM_307091.Bufr_Template, TM_307091.CREX_Template, TM_307091.Sequence_Descriptor1, TM_307091.Sequence_Descriptor0, TM_307091.Bufr_Element, TM_307091.Crex_Element, TM_307091.Climsoft_Element, TM_307091.Element_Name, TM_307091.Crex_Unit, TM_307091.Crex_Scale, TM_307091.Crex_DataWidth, TM_307091.Bufr_Unit, TM_307091.Bufr_Scale, TM_307091.Bufr_RefValue, TM_307091.Bufr_DataWidth_Bits, TM_307091.Selected, TM_307091.Observation, TM_307091.Crex_Data, TM_307091.Bufr_Data " & _
              "From TM_307091 Where (((TM_307091.Selected) = True)) ORDER BY TM_307091.Rec;"
        'MsgBox(sql)
        BufrSection4 = ""
        If Not AWS_Bufr_Section4(sql, BufrSection4, tt_aws) Then
            Log_Errors("Cant' Compute Bufr Data Section")  'MsgBox "Cant' Compute Bufr Data Section"
        Else
            ' Update Subset Number
            Bufr_Subst = Bufr_Subst + 1
            ' Append Data in Section 4 with the data computed from current subset
            BUFR_Subsets_Data = BUFR_Subsets_Data + BufrSection4
            ' Output substet binary data
            'MsgBox(BUFR_Subsets_Data)
            Write(30, Date_Time, BufrSection4 & Chr(13))
        End If

        ' ' Compose the complete AWS BUFR message
        '
        ' If Not AWS_BUFR_Code(sql, header, yy, mm, dd, hh, min, ss, BufrSection4) Then Log_Errors "Can't Encode Data"  ' MsgBox "Can't Encode Data"

        Exit Sub
Err:

        Log_Errors(Err.Description)

        ' list_errors.AddItem txttime & "  " & Err.description
        ' MsgBox Err.Number & ": " & Err.description
    End Sub

    Function Compute_Header(hdr As String, hh As String) As String

        Select Case Val(hh) Mod 6
            Case 0
                Mid$(hdr, 3) = "M"
                Mid$(hdr, 5) = "0"
                Mid$(hdr, 6) = "1"
            Case 3
                Mid$(hdr, 3) = "I"
                Mid$(hdr, 5) = "2"
                Mid$(hdr, 6) = "0"
            Case Else
                Mid$(hdr, 3) = "N"
                Mid$(hdr, 5) = "4"
                Mid$(hdr, 6) = "0"
        End Select
        Compute_Header = hdr
    End Function

    Function Initialize_CodeFlag(cfrs As DataSet, tt_aws As String) As String
        On Error GoTo Err

        Dim bitstream As String

        Dim flgrs As New DataSet
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        flgrs = GetDataSet("flagtable", "SELECT * FROM flagtable")
        Initialize_CodeFlag = ""
        cmd.Connection = dbconn

        ' Initialize with missing values
        With cfrs.Tables(txtTemplate.Text)
            For i = 0 To .Rows.Count - 1

                bitstream = ""
                If .Rows(i).Item("Bufr_Unit") = "Flag table" Then
                    bitstream = ""
                    For j = 1 To .Rows(i).Item("Bufr_DataWidth_Bits")
                        bitstream = bitstream & "1"
                    Next

                End If

                If .Rows(i).Item("Bufr_Unit") = "Code table" Then

                    For k = 0 To flgrs.Tables("flagtable").Rows.Count - 1
                        If IsDBNull(flgrs.Tables("flagtable").Rows(k).Item("Bufr_Descriptor")) Then Exit For
                        If flgrs.Tables("flagtable").Rows(k).Item("Bufr_Descriptor") = .Rows(i).Item("Bufr_Element") Then
                            bitstream = Decimal_Binary(flgrs.Tables("flagtable").Rows(k).Item("Missing"), .Rows(i).Item("Bufr_DataWidth_Bits"))
                            Exit For
                        End If

                    Next
                End If

                If Len(bitstream) <> 0 Then
                    sql = "Update " & tt_aws & " SET Bufr_Data = " & bitstream & " where Rec = " & i + 1 & ";"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If

            Next
        End With

Continues:

        ' Initialize with code figures and flags of site values
        Dim C_sql As String
        Dim F_sql As String

        ' Construct SQL statements for Mysql Query
        C_sql = "UPDATE Code_Flag INNER JOIN TM_307091 ON Code_Flag.FXY = TM_307091.Bufr_Element SET TM_307091.Observation = Code_Flag.Bufr_Value WHERE (((TM_307091.Bufr_Unit)=" & "'code table'" & "));"
        F_sql = "UPDATE Code_Flag INNER JOIN TM_307091 ON Code_Flag.FXY = TM_307091.Bufr_Element SET TM_307091.Bufr_Data = Code_Flag.Bufr_Value WHERE (((TM_307091.Bufr_Unit)=" & "'Flag table'" & ") AND ((Code_Flag.Bufr_Value) Is Not Null Or (Code_Flag.Bufr_Value)<>""""));"

        ' Execute query
        cmd.CommandText = F_sql
        cmd.ExecuteNonQuery()

        Exit Function
Err:

        If Err.Number = 13 Then GoTo Continues
        Log_Errors(Err.Number & " " & Err.Description)

    End Function

    Sub Replicate_SoilTemp(srs As DataSet, aws_struct As String, tt_aws As String)
        On Error GoTo Err
        Dim levels(10) As String
        Dim Temps(10) As String
        Dim Rep As Integer
        Dim counts As Integer
        Dim obsvs As String
        Dim SoilTemp As Boolean
        Dim sql As String
        Dim rs1 As New DataSet
        Dim daws As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        cmd.Connection = dbconn

        sql = "SELECT * FROM " & aws_struct & " ORDER BY Cols;"

        daws = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        rs1.Clear()
        daws.Fill(rs1, aws_struct)

        ' Initialize Values
        Dim Cnull As String
        'Cnull = ''
        sql = "UPDATE " & tt_aws & " SET Observation = '' WHERE Bufr_Element = '007061' Or Bufr_Element = '012130';"


        cmd.CommandText = sql
        cmd.ExecuteNonQuery()

        ' Get data from the observed Levels
        Rep = 0
        With rs1.Tables(aws_struct)
            For i = 0 To .Rows.Count - 1

                If Not IsDBNull(.Rows(i).Item("Bufr_Element")) And Not IsDBNull(.Rows(i).Item("obsv")) Then
                    'Log_Errors(.Rows(i).Item("Bufr_Element") & " " & .Rows(i).Item("obsv"))
                    If .Rows(i).Item("Bufr_Element") = "012130" Then
                        Temps(Rep) = .Rows(i).Item("obsv")
                        If InStr(.Rows(i).Item("element_name"), "10") <> 0 Then levels(Rep) = "0.1"
                        If InStr(.Rows(i).Item("element_name"), "20") <> 0 Then levels(Rep) = "0.2"
                        If InStr(.Rows(i).Item("element_name"), "30") <> 0 Then levels(Rep) = "0.3"
                        If InStr(.Rows(i).Item("element_name"), "40") <> 0 Then levels(Rep) = "0.4"
                        If InStr(.Rows(i).Item("element_name"), "50") <> 0 Then levels(Rep) = "0.5"
                        If InStr(.Rows(i).Item("element_name"), "100") <> 0 Then levels(Rep) = "1"
                        Rep = Rep + 1
                    End If
                End If
            Next
        End With

        '' Update the Template with data from soil Temperature Depths

        With srs.Tables(tt_aws)
            counts = 0

            For i = 0 To .Rows.Count - 1
                If counts = Rep Then Exit For
                SoilTemp = False

                ' Locate Level

                If .Rows(i).Item("Bufr_Element") = "007061" Then
                    SoilTemp = True
                    obsvs = levels(counts)
                ElseIf .Rows(i).Item("Bufr_Element") = "012130" Then
                    SoilTemp = True
                    obsvs = Temps(counts)
                    counts = counts + 1
                End If

                ' Update if Level located
                If SoilTemp Then
                    sql = "UPDATE " & tt_aws & " SET Observation = " & obsvs & " WHERE Bufr_Element = '007061';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            Next
        End With

        Exit Sub
Err:
        MsgBox("Soil Reolication")
        Log_Errors(Err.Description)
        'list_errors.AddItem txttime & "  " & Err.description
        'MsgBox Err.description
    End Sub

    Sub Replicate_MaxGust(srs As DataSet, aws_struct As String, tt_aws As String)
        On Error GoTo Err
        Dim MxGustD(2) As String
        Dim MxGustS(2) As String
        Dim Tperiod(2) As String
        Dim Rep_D As Integer
        Dim Rep_S As Integer
        Dim counts As Integer
        Dim obsvs As String
        Dim MxGust As Boolean
        Dim rs1 As DataSet


        sql = "SELECT * FROM " & aws_struct & " ORDER BY Cols;"

        rs1 = GetDataSet(aws_struct, sql)

        ' Initialize Values Wind Gust values with missing data
        sql = "UPDATE " & tt_aws & " SET Observation = " & vbNull & " WHERE Bufr_Element = '011043' Or Bufr_Element = '011041';"
        cmd.Connection = dbconn
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()


        '   Get data from the observed Levels
        With rs1.Tables(aws_struct)

            Rep_S = 0
            Rep_D = 0

            For i = 0 To .Rows.Count - 1

                ' Maximum Wind Gust Speed
                If Not IsDBNull(.Rows(i).Item("Bufr_Element")) Then
                    If .Rows(i).Item("Bufr_Element") = "011043" And Not IsDBNull(.Rows(i).Item("obsv")) Then
                        If InStr(.Rows(i).Item("Element_Abbreviation"), "10") <> 0 Then MxGustD(Rep_D) = .Rows(i).Item("obsv")
                        If InStr(.Rows(i).Item("Element_Abbreviation"), "60") <> 0 Then MxGustD(Rep_D) = .Rows(i).Item("obsv")
                        Rep_D = Rep_D + 1
                    End If

                    If .Rows(i).Item("Bufr_Element") = "011041" And Not IsDBNull(.Rows(i).Item("obsv")) Then
                        If InStr(.Rows(i).Item("Element_Abbreviation"), "10") <> 0 Then MxGustS(Rep_S) = .Rows(i).Item("obsv")
                        If InStr(.Rows(i).Item("Element_Abbreviation"), "60") <> 0 Then MxGustS(Rep_S) = .Rows(i).Item("obsv")

                        ' Compute the Time Displacement data
                        If Rep_S = 0 Then Tperiod(0) = "-10"
                        If Rep_S = 1 Then Tperiod(1) = "-60"
                        Rep_S = Rep_S + 1
                    End If
                End If
            Next
        End With

        ' Update the Template with Maximum Wind gusts data
        Dim RecNo As Integer
        With srs.Tables(tt_aws)
            counts = 0

            For i = 0 To .Rows.Count - 1

                ' Locate the occurence of Maximum wind gust direction

                If .Rows(i).Item("Bufr_Element") = "011043" Then
                    RecNo = .Rows(i - 1).Item("Rec") ' Update Maximum Wind Gust Direction Time displacement
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & Tperiod(counts) & "' WHERE Rec = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    RecNo = .Rows(i).Item("Rec") ' Update Maximum Wind Gust Direction
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & MxGustD(counts) & "' WHERE Rec = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    RecNo = .Rows(i + 1).Item("Rec") ' Update Maximum Wind Gust Speed
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & MxGustS(counts) & "' WHERE Rec = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    counts = counts + 1

                    ' Initialize Time Period with -10 Minutes
                    If counts = 2 Then
                        RecNo = .Rows(i + 2).Item("Rec")
                        sql = "UPDATE " & tt_aws & " SET Observation = '-10' WHERE Rec = '" & RecNo & "';"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()

                        Exit For
                    End If
                End If

            Next

        End With

        Exit Sub
Err:
        Log_Errors(Err.Description)

    End Sub
    Sub TDCF_Encode(trs As DataSet, tt_aws As String)
        On Error GoTo Err
        Dim bufrdata As String
        Dim rounded As Object
        Dim bbit As Integer
        Dim sql As String
        Dim RecNo As String
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        cmd.Connection = dbconn

        'trs = GetDataSet(txtTemplate.Text, sql)

        With trs.Tables(tt_aws)

            For i = 0 To .Rows.Count - 1
                RecNo = .Rows(i).Item("Rec")
                If Not IsDBNull(.Rows(i).Item("Observation")) Then
                    If Len(.Rows(i).Item("Observation")) > 0 Then
                        bufrdata = Bufr_Data(.Rows(i).Item("Bufr_Unit"), .Rows(i).Item("Bufr_Scale"), .Rows(i).Item("Bufr_RefValue"), .Rows(i).Item("Bufr_DataWidth_Bits"), .Rows(i).Item("Observation"), .Rows(i).Item("Bufr_Data"))
                        '    'Log_Errors(bufrdata)
                        sql = "UPDATE " & tt_aws & " SET Bufr_Data = '" & bufrdata & "' WHERE Rec = '" & RecNo & "';"
                        cmd.CommandText = sql
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next

        End With
        Exit Sub
Err:
        Log_Errors(Err.Description)
    End Sub

    Function Bufr_Data(Bufr_Unit As String, Bufr_Scale As Integer, Bufr_RefValue As Long, Bufr_DataWidth As Integer, dat As String, missing_data As String) As String

        On Error GoTo Err

        Dim diff As Integer
        Dim num As Object
        Dim apd As String
        Dim datstr As String
        Dim count As Integer
        Dim rs As DataSet
        Dim sql As String

        datstr = missing_data
        If Bufr_Unit = "CCITT IA5" Then

            sql = "SELECT * FROM ccitt;"
            rs = GetDataSet("ccitt", sql)

            Bufr_Data = CCITT_Binary(rs, dat, Bufr_DataWidth)

            Exit Function
        End If


        If IsNumeric(dat) Then

            ' Apply the scaling for both Climsoft and Bufr
            num = Val(dat) * 10 ^ Val(Bufr_Scale)

            '    convert to Kelvin values where the Temperature bufr units are in Kelvin
            If Bufr_Unit = "K" Then num = num + 273.15 * 10 ^ Val(Bufr_Scale)

            '   ' Subtract the Reference Value
            num = num - Bufr_RefValue

            ' Binary conversion for positive Decimal numbers only
            If num >= 0 Then datstr = Decimal_Binary(num, Bufr_DataWidth)
            'Bufr_Data = datstr

        End If
        Bufr_Data = datstr

        Exit Function
Err:

        'If Err.Number = 5 Then Resume
        Log_Errors(Err.Number & " " & Err.Description)
    End Function

    Function CCITT_Binary(rs0 As DataSet, dat As String, DataWidth As Integer) As String

        Dim binstr As String
        Dim dat1 As String
        Dim chr1 As String
        Dim chr2 As String
        Dim kount As Integer

        ' Truncate long data strings to bufr data width
        binstr = ""
        If Len(dat) < DataWidth / 8 Then
            For kount = 1 To DataWidth - Len(dat) * 8
                binstr = binstr & "0"
            Next kount
        Else
            dat = Strings.Left(dat, DataWidth / 8)
        End If

        ' Loop the entire data string
        For kount = 1 To Len(dat)
            With rs0.Tables("ccitt")

                For i = 0 To .Rows.Count - 1
                    dat1 = Mid(dat, kount, 1)
                    If dat1 = " " Then dat1 = "SP"
                    If dat1 = .Rows(i).Item("Characters") Then
                        chr1 = .Rows(i).Item("MostSignificant")
                        chr2 = .Rows(i).Item("LeastSignificant")
                        binstr = binstr & Decimal_Binary(Val(chr1), 4) & Decimal_Binary(Val(chr2), 4)
                        Exit For
                    End If
                Next

            End With
        Next kount
        ' MsgBox kount & " " & DataWidth & " " & Len(binstr)
        CCITT_Binary = binstr
    End Function

    Function AWS_Bufr_Section4(sql As String, ByRef binary_data As String, tt_aws As String) As Boolean
        AWS_Bufr_Section4 = True
        On Error GoTo Err
        'Compute Section 4 - Data Section
        Dim xtrbits As Integer
        Dim siz As Long
        Dim bufr_subset As String
        Dim kount As Integer
        'Dim db1 As dao.Database
        Dim dbase As String
        'Dim qry As QueryDef
        Dim bufr As DataSet

        bufr = GetDataSet(tt_aws, sql)

        ' Get the total data length

        Process_Status("Encoding BUFR Section4 - Data Section")

        bufr_subset = ""
        With bufr.Tables(tt_aws)
            For i = 0 To .Rows.Count - 1
                bufr_subset = bufr_subset & .Rows(i).Item("Bufr_Data")
            Next
        End With

        binary_data = binary_data & bufr_subset

        Exit Function
Err:
        Log_Errors(Err.Description)
        AWS_Bufr_Section4 = False

    End Function

    Function FTP_Delete_InputFile(ftpfile As String) As Boolean
        FTP_Delete_InputFile = False
        On Error GoTo Err
        Dim local_folder As String

        Dim usr As String
        Dim pwd As String
        Dim flder As String
        Dim ftpmode As String
        Dim ftpmethod As String
        Dim Drive1 As String
        Dim ftpscript As String
        Dim ftpbatch As String

        ' Get the FTP details from the base station server
        Get_ftp_details("get", ftp_host, flder, ftpmode, usr, pwd)
        MsgBox(usr & " " & pwd)
        FileClose(1) ' Close the file if ever it exist

        ' Define the file and path
        local_folder = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
        Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
        ftpscript = local_folder & "\ftp_file_delete.txt"
        FileOpen(1, ftpscript, OpenMode.Output)

        ' Create FTP Script file
        Print(1, "open " & ftp_host & Chr(13) & Chr(10))
        Print(1, usr & Chr(13) & Chr(10))
        Print(1, pwd & Chr(13) & Chr(10))
        Print(1, "cd " & flder & Chr(13) & Chr(10))
        Print(1, "del" & " " & ftpfile & Chr(13) & Chr(10))
        Print(1, "bye" & Chr(13) & Chr(10))

        FileClose(1)

        ' Create batch file to execute FTP script

        ftpbatch = local_folder & "\ftp_file_delete.bat"
        FileOpen(1, ftpbatch, OpenMode.Output)

        Print(1, "echo off" & Chr(13) & Chr(10))
        Print(1, Drive1 & Chr(13) & Chr(10))
        Print(1, "CD " & local_folder & Chr(13) & Chr(10))
        Print(1, "ftp -v -s:ftp_file_delete.txt" & Chr(13) & Chr(10))
        Print(1, "echo on" & Chr(13) & Chr(10))
        Print(1, "EXIT" & Chr(13) & Chr(10))
        FileClose(1)

        ' Execute the batch file to delete the input file
        Shell(ftpbatch, vbMinimizedNoFocus)

        FTP_Delete_InputFile = True

        Exit Function
Err:
        Log_Errors(" FTP " & ftpmethod & " error - " & Err.Description)
    End Function

    Function AWS_BUFR_Code(message_header As String, yy As String, mm As String, dd As String, hh As String, min As String, ss As String, binary_data As String) As Boolean
        AWS_BUFR_Code = False

        On Error GoTo Err
        Dim octets As String
        Dim section0 As String
        Dim section1 As String
        Dim section2 As String
        Dim section3 As String
        Dim section4 As String
        Dim section5 As String
        Dim dbase As String
        'Dim sql As String
        Dim bufr As DataSet
        'Dim substs As String
        Dim Dat_Sec As String
        Dim rs1 As DataSet
        Dim kount As Integer
        Dim dy As String
        Dim hr As String

        dy = dd
        hr = hh

        Process_Status("Composing the BUFR message")

        'substs = ""
        'Dat_Sec = Data_Description_Section
        'Data_Description_Section = ""

        'dbase = frm_keyentry.datafile
        'If Not clicom.read_registry("key05", dbase) Then Exit Function
        rs1 = GetDataSet("ccitt", "SELECT * FROM ccitt")

        'bufr = GetDataSet(tt_aws, sql)

        'rs1 = db.OpenRecordset("CCITT")

        'If clicom.query_exist("qry_bufr_coded", dbase_path) Then db.QueryDefs.Delete "qry_bufr_coded"
        'Set qry = db.CreateQueryDef("qry_bufr_coded", sql)

        'Set bufr = db.OpenRecordset("qry_bufr_coded")

        ' Encode Section 1 - Identification Section
        section1 = ""
        octets = "00000000"
        ' Octet 1 through 3. Length of section 1 - . There are 24 octets as per version 12 onwards
        section1 = Decimal_Binary(24, 24)
        ' Octet 4. BURF Master table. It is Zero for Meteorology maintained by WMO
        section1 = section1 & Decimal_Binary(0, 8)
        ' Octet 5 - 6. Identification of originating centre / generating center (defined in common table C-11)
        section1 = section1 & Decimal_Binary(Val(txtOriginatingCentre.Text), 16)
        ' Octet 7 and 8. Identification of originating centre / generating sub_center (defined in common table C-12)
        section1 = section1 & Decimal_Binary(Val(txtOriginatingSubcentre.Text), 16)
        ' Octet 9. Update sequence number (Zero for original BUFR message; incremented for updates)
        section1 = section1 & Decimal_Binary(Val(txtUpdateSequence.Text), 8)
        ' Octet 10. Status for optional section. Bit 1=0 No option section; =1 Option section. Bit 2-8 set to zero (reserved)
        If chkOptionalSection.Checked = True Then
            section1 = section1 & "10000000"
        Else
            section1 = section1 & "00000000"
        End If

        ' Octet 11. Data category
        section1 = section1 & Decimal_Binary(Val(txtDataCategory.Text), 8)
        ' Octet 12. International data sub-category (defined in table C-13)
        section1 = section1 & Decimal_Binary(Val(InternationalSubcategory.Text), 8)
        ' Octet 13. Local data sub-category (defined locally by ADP centers)
        section1 = section1 & Decimal_Binary(Val(LocalSubcategory.Text), 8)
        ' Octet 14. Version number of master table currently (Currently 12 for WMO BUFR FM 94 BUFR tables)
        section1 = section1 & Decimal_Binary(Val(MastertableVersion.Text), 8)
        ' Octet 15. Version number of local tables used to augment master table in use
        section1 = section1 & Decimal_Binary(Val(LocaltableVersion.Text), 8)
        ' Octet 16 - 17. Year (4 digits)

        section1 = section1 & Decimal_Binary(yy, 16)

        ' Octet 18. Month
        section1 = section1 & Decimal_Binary(mm, 8)
        ' Octet 19. Day
        section1 = section1 & Decimal_Binary(dd, 8)
        ' Octet 20. Hour
        section1 = section1 & Decimal_Binary(hh, 8)
        ' Octet 21. Minute
        section1 = section1 & Decimal_Binary(min, 8)
        ' Octet 22. Second
        section1 = section1 & Decimal_Binary(ss, 8)
        ' Octet 23. Reserved for local use by ADP Centre
        section1 = section1 & Decimal_Binary(0, 8)
        ' Octet 24. Set to zero
        section1 = section1 & Decimal_Binary(0, 8)

        ' Compute Section 2 - Optional section if it exist
        section2 = ""
        ' Octet 1 - 3. Length of section
        ' Octet 4 Set to Zero (Reserved)
        ' Octet 5 onwards. Reserved for use by ADP centres

        ' Compute Section 3 - Data Description Section.
        Dim data_descriptors As String
        Dim Octtets As Integer
        ' Dim f As String
        ' Dim x As String
        ' Dim y As String

        section3 = ""
        ' C$ = Compute_Descriptors(descripts)
        ' MsgBox C$

        ' MsgBox seq_desc & " " & Len(seq_desc) / 6

        ' Convert Descriptors to binary - Descriptor for the Template used. 16 bits for a descriptor = 2 Octets
        ' data_descriptor = Right(cmbtemplate, 6)
        ' f = Decimal_Binary(Left(data_descriptor, 1), 2)    ' Descriptor type
        ' x = Decimal_Binary(Mid(data_descriptor, 2, 2), 6) ' Descriptor Class
        ' y = Decimal_Binary(Mid(data_descriptor, 4, 3), 8) ' Entry in Class X
        '
        ' data_descriptor = f & x & y     ' Complete Descriptor in binary
        data_descriptors = Desc_Bits
        Octtets = 7 + Len(data_descriptors) / 8
        'MsgBox Octtets
        If Octtets Mod 2 <> 0 Then Octtets = Octtets + 1

        ' Octet 1 - 3. Length of section. Total of 9 Octets. 1 Octet to be added to make them even
        ' section3 = section3 & Decimal_Binary(10, 24)

        section3 = section3 & Decimal_Binary(Octtets, 24)

        ' Octet 4. Reserved (Set to Zero)
        section3 = section3 & Decimal_Binary(0, 8)
        ' Octet 5 - 6. Number of Subsets
        ' section3 = section3 & Decimal_Binary(Val(subsets), 16)
        section3 = section3 & Decimal_Binary(Val(Bufr_Subst), 16)
        ' Octet 7. Type of data. Bit 1, = 1 observed = 0 Other. Bit 2 = 1 Compressed, = 0 non-compressed. Bit 3-8 reserved (set to zero)
        octets = "00000000"
        Mid(octets, 1) = 1
        Mid(octets, 2) = 0
        section3 = section3 & octets
        ' Octet 8 onwards
        section3 = section3 & data_descriptors
        ' Octet 10. An extra octet to make total octets even

        If Len(section3) / 8 Mod 2 <> 0 Then section3 = section3 & "00000000"

        'Compute Section 4 - Data Section
        Dim xtrbits As Integer
        Dim siz As Integer

        section4 = ""

        ' Compute the extra bits required to have complete octets
        xtrbits = Len(binary_data) Mod 8
        '
        If xtrbits = 0 Then
            siz = (Len(binary_data) - xtrbits) / 8
        Else
            For kount = 1 To 8 - xtrbits
                binary_data = binary_data & "0"
            Next kount
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
        section5 = ""
        ' Octet 1-4 "7777" (coded according to CCITT International Alphabet No. 5)
        section5 = section5 & CCITT_Binary(rs1, "7777", 32)

        ' Compute the BUFR message less section 0
        Dim BUFR_Message As String
        BUFR_Message = section1 & section2 & section3 & section4 & section5

        ' Encode Section 0 - Indicator Section
        section0 = ""
        ' Octet 1 - 4.  "BUFR" (coded according to CCITT International Alphabet No. 5)
        section0 = section0 & CCITT_Binary(rs1, "BUFR", 32)
        ' Octet 5-7 Total length of BUFR message, in octets (including Section 0). Section 0 has 8 octets
        siz = (Len(BUFR_Message) + 64) / 8
        section0 = section0 & Decimal_Binary(siz, 24)
        ' Octet 8 - Bufr edition number
        section0 = section0 & Decimal_Binary(Val(txtBufrEdition.Text), 8)

        ' Define communications controls for BUFR message in FTP GTS structure

        Dim nnn As String
        Dim SOH As String
        Dim CR As String
        Dim LF As String
        Dim SP As String
        Dim ETX As String
        Dim Format_Id0 As String
        Dim Format_Id1 As String
        Dim dummy_msg As String
        Dim nulls As String
        Dim brfile As String

        nnn = CCITT_Binary(rs1, "001", 24)

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

        comms_header = CCITT_Binary(rs1, message_header, Len(message_header) * 8)

        'Case where Format Identifier 00 is used
        BUFR_Message = section0 & section1 & section2 & section3 & section4 & section5
        Bufr_Message_With_Controls = SOH & CR & CR & LF & nnn & CR & CR & LF & comms_header & CR & CR & LF & BUFR_Message & CR & CR & LF & ETX

        message_length = Format(Str(Len(Bufr_Message_With_Controls) / 8), "00000000")
        BUFR_Message = CCITT_Binary(rs1, message_length, 64) & Format_Id0 & Bufr_Message_With_Controls & dummy_msg

        'frm.txt_message = BUFR_Message

        'Delete the file to get rid of the previous data
        'If fso.FileExists(fso.GetParentFolderName(App.Path) & "\data\bufr.txt") Then fso.DeleteFile(fso.GetParentFolderName(App.Path) & "\data\bufr.txt")
        brfile = System.IO.Path.GetFullPath(Application.StartupPath & "\data\bufr.txt")

        If File.Exists(brfile) Then File.Delete(brfile)

        FileOpen(2, brfile, OpenMode.Output)

        'Open fso.GetParentFolderName(App.Path) & "\data\bufr.txt" For Output As #2

        'Print #2, BUFR_Message 
        PrintLine(2, BUFR_Message) ' Put the BUFR binary digit message into a text file
        FileClose(2)
        FileClose(1)
        'Close #1
        'Close #2

        'msg_file = Right(msg_header, 4) & Mid(message_header, 13, 2) & Mid(message_header, 15, 2) '& Format(min, "00") 'message_header
        msg_file = Strings.Right(msg_header, 4) & Format(dy, "00") & Format(hr, "00")

        'Construct and open Bufr output text file based on the message header

        Dim fserial As Long
        Dim AWS_BUFR_File, BUFR_octet_File As String
        Dim ValidFile As Boolean
        fserial = 0
        ValidFile = False

        AWS_BUFR_File = System.IO.Path.GetFullPath(Application.StartupPath & "\data\" & msg_file & Format(1, "0000") & ".f")
        BUFR_octet_File = System.IO.Path.GetFullPath(Application.StartupPath & "\data\bufr_octets.txt")

        'Open fso.GetParentFolderName(App.Path) & "\data\bufr_octets.txt" For Output As #1
        FileOpen(1, BUFR_octet_File, OpenMode.Output)


        If File.Exists(AWS_BUFR_File) Then File.Delete(AWS_BUFR_File)

        'Open AWS_BUFR_File For Binary As #2
        FileOpen(2, AWS_BUFR_File, OpenMode.Binary)

        'Output BUFR data into binary and text file
        Dim byt As String
        Dim kounter As Long

        'Dim writeStream As FileStream
        'writeStream = New FileStream(AWS_BUFR_File, FileMode.Create)
        'Dim writeBinay As New BinaryWriter(writeStream)
        'writeBinay.Write(89)


        'byt = ""
        kounter = 1
        ''MsgBox(kount)
        For kount = 1 To Len(BUFR_Message) Step 8
            If Binary_Decimal(Mid(BUFR_Message, kount, 8), byt) Then
                'writeBinay.Write(byt)
                'writeBinay.Write(Binary_Decimal(Mid(BUFR_Message, kount, 8)))
                'Write(2, kounter, Binary_Decimal(Mid(BUFR_Message, kount, 8)))
                FilePut(2, byt, kounter)
                'FilePutObject(2, byt, kounter)
                'PrintLine(1, kounter & "," & Mid(BUFR_Message, kount, 8))
                kounter = kounter + 1
            End If
        Next kount

        'writeBinay.Close()
        FileClose(1)
        FileClose(2)

        ''Open AWS_BUFR_File For Input As #1
        'FileOpen(1, AWS_BUFR_File, OpenMode.Input)

        'Dim bin_out As String
        'Dim dat As String
        'bin_out = ""

        'Do While EOF(1) = False
        '    'Line Input #1, dat
        '    Input(1, dat)
        '    bin_out = bin_out & dat
        'Loop

        'FileClose(1)

        'MsgBox msg_file
        Dim bufr_filename As String
        Process_Status("Transmitting message")

        bufr_filename = (System.IO.Path.GetFileName(AWS_BUFR_File)) ' Get the filename without path
        If Not FTP_Call(bufr_filename, "put") Then Exit Function

        AWS_BUFR_Code = True

        Exit Function
Err:
        If Err.Description = "" Then
            Log_Errors("BUFR Coding Error")
            '  list_errors.AddItem txttime & "  " & "BUFR Coding Error"
            '  MsgBox "BUFR Coding Error"
        Else
            Log_Errors(Err.Number & ": " & Err.Description)
            '  list_errors.AddItem txttime & "  " & Err.description
            '  MsgBox Err.description
        End If
        FileClose(1)
        FileClose(2)
        'writeBinay.Close()
    End Function

    Function Binary_Decimal(BinN As String, ByRef BinD As Long) As Boolean
        On Error GoTo Err
        Dim siz As Integer
        Dim dgt As String
        Dim posval As Integer
        Dim kount As Integer

        siz = Len(BinN)
        'Binary_Decimal = 0
        Binary_Decimal = True
        BinD = 0
        For kount = 0 To siz - 1
            dgt = Mid(BinN, siz - kount, 1)
            If IsNumeric(dgt) Then
                posval = Int(dgt)
                'posval = Mid(BinN, siz - kount, 1)
                'Binary_Decimal= Binary_Decimal + posval * 2 ^ kount
                BinD = BinD + posval * 2 ^ kount
            End If

        Next kount

        Exit Function
Err:
        Log_Errors(Err.Number & " " & Err.Description)
        Binary_Decimal = False
    End Function

    Function Next_Encoding_Time() As Boolean
        Next_Encoding_Time = True
        On Error GoTo Err
        Dim mnt As Integer
        Dim ss As Integer

        txtNxtProcess.Text = Ltime.Text
        txtNxtProcess.Text = DateAdd("h", 1, txtNxtProcess.Text)

        mnt = CInt(DateAndTime.Minute(txtNxtProcess.Text))
        ss = CInt(DateAndTime.Second(txtNxtProcess.Text))
        mnt = -1 * mnt
        ss = -1 * ss

        txtNxtProcess.Text = DateAdd("n", mnt, txtNxtProcess.Text)
        txtNxtProcess.Text = DateAdd("s", ss, txtNxtProcess.Text)

        txtNxtProcess.Text = DateAdd("n", CLng(txtOffset.Text), txtNxtProcess.Text)

        Process_Status("Next Encoding Time -" & txtNxtProcess.Text)
        Process_Status("Next Encoding Time -" & Strings.Left(txtNxtProcess.Text, Len(txtNxtProcess.Text) - 3))
        Exit Function
Err:
        Next_Encoding_Time = False
        Log_Errors(Err.Description)
        ' list_errors.AddItem txttime & " " & Err.description
        ' MsgBox Err.description
    End Function

    Private Sub cmdfirstSite_Click(sender As Object, e As EventArgs)
        rec = 0
        'PopulateForm("sites", txtsitesNav, rec)
    End Sub


    Private Sub nextSite_Click(sender As Object, e As EventArgs)
        If rec < Kount - 1 Then
            rec = rec + 1
            'PopulateForm("sites", txtsitesNav, rec)
        End If
    End Sub

    Private Sub cmdsitesPrev_Click(sender As Object, e As EventArgs)
        If rec > 0 Then
            rec = rec - 1
            'PopulateForm("sites", txtsitesNav, rec)
        End If
    End Sub

    Private Sub cmdsitesLast_Click(sender As Object, e As EventArgs)
        rec = Kount - 1
        'PopulateForm("sites", txtsitesNav, rec)
    End Sub


    Private Sub cmdViewUpdate_Click(sender As Object, e As EventArgs) Handles cmdViewUpdate.Click

        DataGridViewSites.Visible = True
        DataGridViewSites.DataSource = ds
        DataGridViewSites.DataMember = "aws_sites"
        DataGridViewSites.Dock = DockStyle.Fill
        DataGridViewSites.Height = 190

    End Sub



    Private Sub DataGridViewStructures_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewStructures.CellEndEdit
        Dim col, rw As Integer
        Dim tbl, dat As String
        Dim recUpdate As New dataEntryGlobalRoutines
        Try
            col = DataGridViewStructures.CurrentCell.ColumnIndex
            rw = DataGridViewStructures.CurrentRow.Index
            If IsDBNull(DataGridViewStructures.CurrentRow.Cells(col).Value) Then
                dat = ""
            Else
                dat = DataGridViewStructures.CurrentRow.Cells(col).Value
            End If
            'MsgBox(dat)

            tbl = cmbExistingStructures.Text

            SetDataSet(tbl)
            Dim cw As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            If Len(dat) > 0 Then
                ds.Tables(tbl).Rows(rw).Item(col) = dat
            Else
                ds.Tables(tbl).Rows(rw).Item(col) = ""
            End If

            da.Update(ds, tbl)

            'recUpdate.messageBoxRecordedUpdated()
        Catch ex As Exception
            'MsgBox(ex.HResult & " " & ex.Message)
            If ex.HResult = -2146233080 Then
                'MsgBox(DataGridViewStructures.Rows.Count)
                'DataGridViewStructures.Rows.Add(1)
                'DataGridViewStructures.Refresh()
                CreateDataGridRow(ds, tbl, col, DataGridViewStructures.Rows.Count - 1)
                DataGridViewStructures.Refresh()
            End If
            'MsgBox(DataGridViewStructures.Rows.Count)
        End Try
    End Sub
    Sub CreateDataGridRow(dgr As DataSet, tbl As String, col As Integer, id As String)
        On Error GoTo Err
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = dgr.Tables(tbl).NewRow
        dsNewRow.Item(col) = id

        'Add a new record to the data source table
        dgr.Tables(tbl).Rows.Add(dsNewRow)
        da.Update(dgr, tbl)
        'MsgBox("Record Added")

        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)

    End Sub



    Private Sub DataGridViewStructures_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewStructures.KeyDown
        Dim tbl As String
        Dim recno As Integer
        Try
            If e.KeyCode = Keys.Delete And DataGridViewStructures.CurrentRow.Selected = True Then
                tbl = cmbExistingStructures.Text
                recno = DataGridViewStructures.CurrentRow.Index
                SetDataSet(tbl)
                Dim cw As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

                ds.Tables(tbl).Rows(recno).Delete()
                da.Update(ds, tbl)
                DataGridViewStructures.Refresh()
                'MsgBox("Record Deleted")
            End If
        Catch ex As Exception
            MsgBox(ex.HResult & ": " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridViewSites_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSites.CellEndEdit
        Dim col, rw As Integer
        Dim tbl, dat As String
        Dim recUpdate As New dataEntryGlobalRoutines
        Try
            col = DataGridViewSites.CurrentCell.ColumnIndex
            rw = DataGridViewSites.CurrentRow.Index
            If IsDBNull(DataGridViewSites.CurrentRow.Cells(col).Value) Then
                dat = ""
            Else
                dat = DataGridViewSites.CurrentRow.Cells(col).Value
            End If
            'MsgBox(dat)

            'tbl = cmbExistingStructures.Text
            tbl = "aws_sites"
            SetDataSet(tbl)
            Dim cw As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            If Len(dat) > 0 Then
                ds.Tables(tbl).Rows(rw).Item(col) = dat
            Else
                ds.Tables(tbl).Rows(rw).Item(col) = ""
            End If

            da.Update(ds, tbl)

            'recUpdate.messageBoxRecordedUpdated()
        Catch ex As Exception
            'MsgBox(ex.HResult & " " & ex.Message)
            If ex.HResult = -2146233080 Then
                'MsgBox(DataGridViewStructures.Rows.Count)
                'DataGridViewStructures.Rows.Add(1)
                'DataGridViewStructures.Refresh()
                CreateDataGridRow(ds, tbl, col, dat)
                'DataGridViewStructures.Refresh()
            End If
            'MsgBox(DataGridViewStructures.Rows.Count)
        End Try
    End Sub

    'Private Sub DataGridViewSites_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSites.CellEndEdit

    'End Sub

    Private Sub DataGridViewSites_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridViewSites.KeyDown
        Dim tbl As String
        Dim recno As Integer
        Try
            If e.KeyCode = Keys.Delete And DataGridViewSites.CurrentRow.Selected = True Then
                tbl = "aws_sites"
                recno = DataGridViewSites.CurrentRow.Index
                SetDataSet(tbl)
                Dim cw As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

                ds.Tables(tbl).Rows(recno).Delete()
                da.Update(ds, tbl)
                DataGridViewSites.Refresh()
                'MsgBox("Record Deleted")
            End If
        Catch ex As Exception
            MsgBox(ex.HResult & ": " & ex.Message)
        End Try
    End Sub

    Function Text_To_DataTable(ByVal path As String, ByVal delimitter As Char, ByVal hdrs As Integer, ByRef flds As Integer, ByRef recs As Long) As DataTable
        Dim source As String = String.Empty
        Dim dt As DataTable = New DataTable
        Try
            If IO.File.Exists(path) Then
                source = IO.File.ReadAllText(path)
            Else
                Throw New IO.FileNotFoundException("Could not find the file at " & path, path)
            End If

            Dim rows() As String = source.Split({Environment.NewLine}, StringSplitOptions.None)

            For i As Integer = 0 To rows(0).Split(delimitter).Length - 1
                Dim column As String = rows(0).Split(delimitter)(i)
                dt.Columns.Add(If(False, column, "column" & i + 1))
            Next
            'MsgBox(hdrs)
            For i As Integer = If(False, 1, 0) To rows.Length - 1
                Dim dr As DataRow = dt.NewRow

                For x As Integer = hdrs To rows(i).Split(delimitter).Length - 1
                    If x <= dt.Columns.Count - 1 Then
                        dr(x) = rows(i).Split(delimitter)(x)
                    Else
                        Throw New Exception("The number of columns on row " & i + If(False, 0, 1) & " is greater than the amount of columns in the " & If(False, "header.", "first row."))
                    End If
                Next

                dt.Rows.Add(dr)
            Next
            flds = dt.Columns.Count
            recs = dt.Rows.Count
            Text_To_DataTable = dt
            'MsgBox(dt.Rows(0).Item)
        Catch ex As Exception
            MsgBox(ex.Message)
            Text_To_DataTable = dt
        End Try
    End Function

    Private Sub optStop_CheckedChanged(sender As Object, e As EventArgs) Handles optStop.CheckedChanged
        Process_Status("Process Stopped")
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        'MsgBox(Me.Text)
        Select Case Me.Text
            Case "Process Settings"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "processsettings.htm")
            Case "Servers Settings"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "serverssettings.htm")
            Case "Site Settings"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "sitesettings.htm")
            Case "Data Structures Settings"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "structuressettings.htm")
            Case "Message Coding Settings"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "codingsettings.htm")
        End Select

    End Sub
End Class

Public Class FTP

    Dim ftpserver As FtpStatusCode

End Class