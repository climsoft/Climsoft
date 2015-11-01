Imports System.IO
Public Class formAWSRealTime

    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim recEdit As New dataEntryGlobalRoutines

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
        Timer2.Start()
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
        On Error GoTo Err

        Ltime.Text = Now

        ' Set the next encoding time
        If Len(txtLastProcess.Text) = 0 Then
            txtNxtProcess.Text = DateAdd("n", Val(txtOffset.Text) - Val(Minute(Ltime.Text)), Ltime.Text)
            optStart.Checked = True
        End If

        If optStart.Checked = True Then
            '  If DateDiff("n", Ltime, txtdate1) = 0 Then 'Or DateValue(txtdate1) <= DateValue(txttime) Then
            If DateDiff("n", txtDateTime.Text, txtNxtProcess.Text) <= 0 Then

                'Start_Process()
            End If
        End If

        Exit Sub
Err:
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

        'process_input_data()
        'Next_Encoding_Time()
    End Sub
    Sub process_input_data()
        On Error GoTo Err
        Dim datestring As String
        Dim Tlag As Integer
        Dim aws_input_file As String
        Dim aws_input_file_flds As String
        '        Dim rs As dao.Recordset
        '        Dim inrs As dao.Recordset
        '        Dim awsrs As dao.Recordset
        Dim infile As String
        Dim delmtr As String
        Dim delimiter_ascii As Object
        Dim hdrows As Integer
        Dim fldsrow As Integer
        Dim txtqlfr As String
        Dim flg As String
        Dim dt As Date

        '        ' Locate and processs aws input data files
        Me.Cursor = Cursors.WaitCursor
        'Me.Cursor = Cursors.Default



        '        inrs = db.OpenRecordset("aws_stations")

        '        ' Compute BUFR descriptors from the AWS Template
        '        If Not Compute_Descriptors(Desc_Bits) Then Exit Sub

        '        With inrs
        '            .MoveFirst()

        '            Bufr_Subst = 0
        '            BUFR_Subsets_Data = ""

        '            'Close #30
        '            ' Delete file for subsets data if it exist
        '            If fso.FileExists(fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.csv") Then fso.DeleteFile(fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.csv")

        ' Open fso.GetParentFolderName(App.Path) & "\data\bufr_subsets.csv" For Output As #30

        '            Do While .EOF = False
        '                If Len(.Fields("input_file")) <> 0 And .Fields("selected") = True Then
        '                    ' Get station data details
        '                    flg = ""
        '                    If Not IsNull(.Fields("Flag")) Then flg = .Fields("Flag")

        '  Get_Station_Settings .Fields("data_structure"), delmtr, hdrows, txtqlfr, rs

        '                    '  Get FTP address for the base station server and its data transfer command
        '                    ftp_host = .Fields("aws_server")

        '                    ' Update processing Interface
        '                    txtstructure = .Fields("data_structure")
        '                    txtstructure.Refresh()
        '                    txtheaderows = hdrows
        '                    txtheaderows.Refresh()
        '                    txtQualifier = txtqlfr
        '                    txtQualifier.Refresh()

        '                    ' Compute Delimiter ascii value
        '                    Select Case delmtr
        '                        Case "tab"
        '                            delimiter_ascii = 9
        '                            Optdelimiter(1).value = True
        '                        Case "comma"
        '                            delimiter_ascii = 44
        '                            Optdelimiter(0).value = True
        '                        Case "space"
        '                            delimiter_ascii = 32
        '                            Optdelimiter(2).value = True
        '                        Case "semicolon"
        '                            delimiter_ascii = 59
        '                            Optdelimiter(3).value = True
        '     Case Default
        '                            delimiter_ascii = Chr(delmtr)
        '                            otherdelimiter = delmtr
        '                            otherdelimiter.Refresh()
        '                    End Select
        '                    '  MsgBox delmtr & " " & hdrows & " " & fldsrow & " " & txtqlfr
        '                    '  GoTo Continues

        '                    '  If Len(.Fields("input_file")) <> 0 And .Fields("selected") = True Then
        '                    infile = .Fields("input_file")

        '                    '  get the input data file from aws server if it exist
        '                    Process_Status "Seeking input data - " & infile

        '                    '     ' Refresh form
        '                    '     frm_realtime.Refresh

        '                    If Not FTP_Call(infile, "get") Then
        '                        Log_Errors("Can't retrieve data from input file " & infile)
        '                        list_errors.Refresh()
        '                        GoTo Continues
        '                    End If

        '                    ' Assign a variable to an input file with header rows
        '                    aws_input_file = txtinputfile

        '                    ' Assign a variable to an output file without header rows
        '                    aws_input_file_flds = fso.GetParentFolderName(App.Path) & "\data\aws_input.txt"

        '    Open aws_input_file For Input As #10
        '    Open aws_input_file_flds For Output As #11

        '                    ' Skip header Records if present

        '                    'Retrieve header rows from station parameters
        '                    If Val(hdrows) > 0 Then
        '                        For i = 0 To Val(hdrows) - 1
        '       Line Input #10, C$
        '                        Next
        '                    End If

        '                    ' Output the data rows
        '                    Do While EOF(10) = False
        '      Line Input #10, C$
        '                        '      MsgBox C$ & "-" & Asc(Right(C$, 1))
        '      Print #11, C$
        '                    Loop
        '    Close #10
        '    Close #11


        '                    ' Open the output populated text file as an input file for the database
        '      Open aws_input_file_flds For Input As #11

        '                    ' Update the database and process the data one record at a time
        '                    Dim datastring As String
        '                    Dim endline As Boolean


        '                    Do While EOF(11) = False

        '     Line Input #11, C$
        '                        siz = Len(C$)
        '                        datastring = ""
        '                        endline = False
        '                        '     Tblrefresh rs
        '                        rs.MoveFirst()

        '                        For i = 1 To siz
        '                            If Asc(Mid(C$, i, 1)) = 10 Then
        '                                '         Tblrefresh rs
        '                                Process_SubRecord(rs, inrs, datastring)
        '                                endline = True
        '                            End If
        '                            If Asc(Mid(C$, i, 1)) <> delimiter_ascii And i < siz Then
        '                                If Mid(C$, i, 1) <> txtqlfr Then
        '                                    '             If Mid(C$, i, 1) = "T" Then  ' In case of ISO806 Data format
        '                                    '               datastring = datastring & " "
        '                                    '              Else
        '                                    If Not endline Then
        '                                        datastring = datastring & Mid(C$, i, 1)
        '                                    Else
        '                                        endline = False
        '                                    End If
        '                                    '             End If
        '                                End If
        '                            Else
        '                                If Not endline Then 'Len(datastring) > 0 Then
        '                                    If Asc(Mid(C$, i, 1)) <> delimiter_ascii Then datastring = datastring & Mid(C$, i, 1) ' The last data value before the Newline character
        '                                    rs.Edit()
        '                                    If InStr(datastring, flg) = 0 Or flg = "" Then
        '                                        rs.Fields("obsv") = datastring
        '                                        '             qc_limits rs.Fields("obsv"), rs
        '                                    Else
        '                                        rs.Fields("obsv") = Null
        '                                    End If
        '                                    rs.Update()
        '                                    rs.MoveNext()
        '                                End If
        '                                '         MsgBox datastring
        '                                datastring = ""
        '                                '         Exit For
        '                                '         endline = False
        '                            End If

        '                        Next

        '                        ' Analyse the datetime string and process the data if the encoding time interval matches datetime value

        '                        datestring = TimeStamp(rs)
        '                        If IsDate(datestring) Then dt = datestring

        '                        If Val(txtlag) = 999 Then
        '                            Process_Input_Record(rs, inrs, datestring) ' Process the entire input file irespective of time difference
        '                        Else
        '                            If DateDiff("h", datestring, txttime) <= Val(txtlag - 1) Then Process_Input_Record(rs, inrs, datestring)
        '                            '        If Val(Now() - dt) <= (Val(txtlag)) / 24 Then Process_Input_Record rs, inrs, datestring ' Extract Data for at least the last 1 Hour
        '                        End If

        '                    Loop
        '   Close #11

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
        '        Exit Sub

Err:
        If Err.Number = 62 Then
            Log_Errors("Can't retrieve data from " & infile)
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
End Class