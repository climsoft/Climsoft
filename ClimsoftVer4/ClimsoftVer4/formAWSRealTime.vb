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
    Dim BufrSection4 As String
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
    Dim datt, flprefix, stn1 As String

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

        'Indicators_Populate(dbconn)

        ShowPanel(pnlProcessing, "Process Settings")
        Me.Text = "AWS Real Time"
        load_PressingParameters("txtlFill")
        load_Indicators()
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

    Private Sub cmdBstSave_Click(sender As Object, e As EventArgs) Handles cmdBstSave.Click
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
        ' Remove timeout requirement
        da.SelectCommand.CommandTimeout = 0

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
        ' Remove timeout requirement
        da.SelectCommand.CommandTimeout = 0

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
                lstFolders.SelectedItem = ds.Tables("aws_mss").Rows(num).Item("foldertype")

            Case "sites"
                txtSiteID.Text = ds.Tables("aws_sites").Rows(num).Item("SiteID")
                txtSiteName.Text = ds.Tables("aws_sites").Rows(num).Item("SiteName")
                txtInFile.Text = ds.Tables("aws_sites").Rows(num).Item("InputFile")
                txtDataStructure.Text = ds.Tables("aws_sites").Rows(num).Item("DataStructure")
                txtFlag.Text = ds.Tables("aws_sites").Rows(num).Item("MissingDataFlag")
                txtIP.Text = ds.Tables("aws_sites").Rows(num).Item("awsServerIp")
                chkPrefix.Checked = ds.Tables("aws_sites").Rows(num).Item("chkPrefix")
                chkOperational.Checked = ds.Tables("aws_sites").Rows(num).Item("OperationalStatus")
                chkGTSEncode.Checked = ds.Tables("aws_sites").Rows(num).Item("GTSEncode")
                If Not IsDBNull(ds.Tables("aws_sites").Rows(num).Item("GTSHeader")) Then
                    txtGTSHeader.Text = ds.Tables("aws_sites").Rows(num).Item("GTSHeader")
                Else
                    txtGTSHeader.Text = ""
                End If
                If Not IsDBNull(ds.Tables("aws_sites").Rows(num).Item("FilePrefix")) Then
                    txtfilePrefix.Text = ds.Tables("aws_sites").Rows(num).Item("FilePrefix")
                Else
                    txtfilePrefix.Text = ""
                End If

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
                ds.Tables(tbl).Rows(num).Item("foldertype") = lstFolders.SelectedItem

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
        'MsgBox(1)
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
                txtGTSHeader.Text = ""
                txtfilePrefix.Text = ""
                chkPrefix.Checked = False
        End Select
    End Sub

    Private Sub cmdmssReset_Click(sender As Object, e As EventArgs) Handles cmdMssReset.Click
        FormReset("mss")
    End Sub

    Private Sub cmdMSSAddNew_Click(sender As Object, e As EventArgs) Handles cmdMssSave.Click

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try
            dsNewRow = ds.Tables("aws_mss").NewRow
            dsNewRow.Item("ftpId") = txtMSSAddress.Text
            dsNewRow.Item("inputFolder") = txtMSSFolder.Text
            dsNewRow.Item("ftpMode") = txtBasestationFTPMode.Text
            dsNewRow.Item("userName") = txtmssUser.Text
            dsNewRow.Item("password") = txtMSSPW.Text
            dsNewRow.Item("foldertype") = lstFolders.SelectedItem

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

        Catch Err As Exception
            MsgBox(Err.Message)
            'MsgBox(Err.Number & " : " & Err.Description)
        End Try

    End Sub

    Private Sub cmdMSSUpdate_Click(sender As Object, e As EventArgs) Handles cmdMssUpdate.Click
        RecordUpdate("aws_mss", "mss", rec, "update")
    End Sub

    Private Sub cmdmssRefresh_Click(sender As Object, e As EventArgs) Handles cmdMssRefresh.Click
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

    Private Sub cmdMSSDelete_Click(sender As Object, e As EventArgs) Handles cmdMssDelete.Click
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

    Private Sub GroupBox11_Enter(sender As Object, e As EventArgs) Handles grpSites.Enter

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
        dsNewRow.Item("GTSHeader") = txtGTSHeader.Text
        dsNewRow.Item("FilePrefix") = txtfilePrefix.Text
        If chkOperational.Checked Then
            dsNewRow.Item("OperationalStatus") = 1
        Else
            dsNewRow.Item("OperationalStatus") = 0
        End If
        If chkGTSEncode.Checked Then
            dsNewRow.Item("GTSEncode") = 1
        Else
            dsNewRow.Item("GTSEncode") = 0
        End If
        If chkPrefix.Checked Then
            dsNewRow.Item("chkPrefix") = 1
        Else
            dsNewRow.Item("chkPrefix") = 0
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
        'On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines
        Try
            'Dim comm As New MySql.Data.MySqlClient.MySqlCommand
            'Dim sql0, Id, Nme, infl, str, flg, ip, hdr, Fpfx, chkGTS
            'Dim opsts, chkPrfx

            'Id = txtSiteID.Text
            'Nme = txtSiteName.Text
            'infl = txtInFile.Text
            'str = txtDataStructure.Text
            'flg = txtFlag.Text
            'ip = txtIP.Text
            'hdr = txtGTSHeader.Text
            'Fpfx = txtfilePrefix.Text
            'If chkOperational.Checked Then
            '    opsts = 1
            'Else
            '    opsts = 0
            'End If
            'If chkGTSEncode.Checked Then
            '    chkGTS = 1
            'Else
            '    chkGTS = 0
            'End If
            'If chkPrefix.Checked Then
            '    chkPrfx = 1
            'Else
            '    chkPrfx = 0
            'End If
            'MsgBox(rec)
            'MsgBox(ds.Tables("aws_sites").Rows(rec).Item("SiteID"))
            'MsgBox(stn1)
            'sql0 = "UPDATE `aws_sites` SET `SiteID`='" & Id & " ', `SiteName`='" & Nme & "', `InputFile`='" & infl & "', `FilePrefix`='" & Fpfx & "', `DataStructure`='" & str & "', `MissingDataFlag`=' " & flg & "', `awsServerIP`='" & ip & "', `OperationalStatus`=' " & opsts & "', `GTSEncode`='" & chkGTS & "', `GTSHeader`='" & hdr & "' WHERE  `SiteID`='" & stn1 & "';"

            'comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
            'comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
            'comm.ExecuteNonQuery()   ' Execute the query

            ds.Tables("aws_sites").Rows(rec).Item("SiteID") = txtSiteID.Text
            ds.Tables("aws_sites").Rows(rec).Item("SiteName") = txtSiteName.Text
            ds.Tables("aws_sites").Rows(rec).Item("InputFile") = txtInFile.Text
            ds.Tables("aws_sites").Rows(rec).Item("DataStructure") = txtDataStructure.Text
            ds.Tables("aws_sites").Rows(rec).Item("MissingDataFlag") = txtFlag.Text
            ds.Tables("aws_sites").Rows(rec).Item("awsServerIp") = txtIP.Text
            ds.Tables("aws_sites").Rows(rec).Item("GTSHeader") = txtGTSHeader.Text
            ds.Tables("aws_sites").Rows(rec).Item("FilePrefix") = txtfilePrefix.Text
            If chkOperational.Checked Then
                ds.Tables("aws_sites").Rows(rec).Item("OperationalStatus") = 1
            Else
                ds.Tables("aws_sites").Rows(rec).Item("OperationalStatus") = 0
            End If
            If chkGTSEncode.Checked Then
                ds.Tables("aws_sites").Rows(rec).Item("GTSEncode") = 1
            Else
                ds.Tables("aws_sites").Rows(rec).Item("GTSEncode") = 0
            End If
            If chkPrefix.Checked Then
                ds.Tables("aws_sites").Rows(rec).Item("chkPrefix") = 1
            Else
                ds.Tables("aws_sites").Rows(rec).Item("chkPrefix") = 0
            End If

            'Add a new record to the data source table
            'If cmdtype = "add" Then ds.Tables("station").Rows.Add(dsNewRow)

            da.Update(ds, "aws_sites")

            recUpdate.messageBoxRecordedUpdated()
            'ClearStationForm()
        Catch ex As Exception
            MsgBox("Update Failure")
        End Try
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
        'On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim str As New DataSet
        'Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand

        ' Create the structure details record in aws_structures table
        If Len(txtStrName.Text) = 0 Or Len(txtDelimiter.Text) = 0 Or Len(txtHeaders.Text) = 0 Then
            MsgBox("Values for Structure Name, Delimiter Type and Total Header Rows must all be provided!")
            Exit Sub
        End If

        Try
            comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
            'sql0 = "INSERT INTO `mysql_climsoft_db_v4`.`aws_structures` (`strName`, `data_delimiter`, `hdrRows`, `txtQualifier`)" & " VALUES ('" & txtStrName.Text & "', '" & txtDelimiter.Text & "', '" & txtHeaders.Text & "', '" & txtQualifier.Text & "');"
            sql0 = "INSERT INTO `aws_structures` (`strName`, `data_delimiter`, `hdrRows`, `txtQualifier`)" & " VALUES ('" & txtStrName.Text & "', '" & txtDelimiter.Text & "', '" & txtHeaders.Text & "', '" & txtQualifier.Text & "');"

            comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
            comm.ExecuteNonQuery()   ' Execute the query

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        ' Create a table for the new structure
        Dim tbl As String = txtStrName.Text

        Try

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

            comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
            comm.ExecuteNonQuery()   ' Execute the query

            ' Display the created table on the DataGrid

            DataGridFill(txtStrName.Text)
            FillList(cmbExistingStructures, "aws_structures", "strName")
            cmbExistingStructures.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        MsgBox("The data structure: " & txtStrName.Text & " successfully created")
        '        Exit Sub
        'Err:
        '        MsgBox(Err.Number & " : " & Err.Description)
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
        Try
            If Not IsNumeric(Strings.Right(lblRecords.Text, 1)) Then ' No data structure selected
                MsgBox("Nothing to delete")
                Exit Sub
            End If
            If MsgBox("The data structure " & txtStrName.Text & " will be deleted.", MsgBoxStyle.OkCancel) = MsgBoxResult.Cancel Then Exit Sub
            DeleteRecord("aws_structures", Int(Strings.Right(lblRecords.Text, Len(lblRecords.Text) - 5)) - 1)
            FillList(cmbExistingStructures, "aws_structures", "strName")
            ' Clear text boxes
            txtStrName.Text = ""
            txtDelimiter.Text = ""
            txtHeaders.Text = ""
            txtQualifier.Text = ""
            cmbExistingStructures.Text = ""
            ' Hide Data grid view
            DataGridViewStructures.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DataGridFill(tbl As String)
        On Error GoTo Err

        Dim dg As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        dg = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        ' Remove timeout requirement
        dg.SelectCommand.CommandTimeout = 0

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
        'On Error GoTo Err
        Dim dbpconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim dpa As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        Dim dps As New DataSet
        Dim sqlp As String

        Dim recUpdate As New dataEntryGlobalRoutines

        Try

            sqlp = "SELECT * FROM aws_process_parameters"
            dpa = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlp, dbconn)
            ' Remove timeout requirement
            dpa.SelectCommand.CommandTimeout = 0

            dps.Clear()
            dpa.Fill(dps, "aws_process_parameters")

            '' Insert default values if table is empty
            'If dps.Tables("aws_process_parameters").Rows.Count = 0 Then
            '    sqlp = "INSERT INTO `" & mndb & "`.`aws_process_parameters` (`RetrievePeriod`, `RetrieveTimeout`, `DelinputFile`, `UTCDiff`) VALUES (2, 10, 0, 0);"

            '    qry = New MySql.Data.MySqlClient.MySqlCommand(sqlp, dbconn)
            '    'Execute query
            '    qry.ExecuteNonQuery()
            'End If

            Select Case LoadType
                Case "txtlFill"
                    txtInterval.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveInterval")
                    txtOffset.Text = dps.Tables("aws_process_parameters").Rows(0).Item("HourOffset")
                    txtPeriod.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrievePeriod")
                    txtTimeout.Text = dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveTimeout")
                    txtGMTDiff.Text = dps.Tables("aws_process_parameters").Rows(0).Item("UTCDiff")
                    chkDeleteFile.Checked = dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile")

                Case "dpupdate"
                    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(dpa)

                    dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveInterval") = txtInterval.Text
                    dps.Tables("aws_process_parameters").Rows(0).Item("HourOffset") = txtOffset.Text
                    dps.Tables("aws_process_parameters").Rows(0).Item("RetrievePeriod") = txtPeriod.Text
                    dps.Tables("aws_process_parameters").Rows(0).Item("RetrieveTimeout") = txtTimeout.Text
                    dps.Tables("aws_process_parameters").Rows(0).Item("UTCDiff") = txtGMTDiff.Text

                    If chkDeleteFile.Checked = True Then
                        dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile") = 1
                    Else
                        dps.Tables("aws_process_parameters").Rows(0).Item("DelinputFile") = 0
                    End If

                    dpa.Update(dps, "aws_process_parameters")

                    recUpdate.messageBoxRecordedUpdated()

            End Select
        Catch ex As Exception
            'Exit Sub
            'Err:
            'MsgBox(Err.Description)
            'Log_Errors(Err.Description)
            Log_Errors(ex.Message)
        End Try
    End Sub
    Sub load_Indicators(Optional Tmpt As String = "")

        Dim iconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim dai As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsi As New DataSet
        Try

            'dbConnectionString = frmLogin.txtusrpwd.Text
            iconn.ConnectionString = dbConnectionString
            iconn.Open()

            ' Populate Template Combo box
            sql = "SELECT * FROM bufr_indicators;"
            dai = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, iconn)
            ' Remove timeout requirement
            dai.SelectCommand.CommandTimeout = 0
            dsi.Clear()
            dai.Fill(dsi, "indicators")
            iconn.Close()

            With dsi.Tables("indicators")
                txtTemplate.Items.Clear()
                For i = 0 To .Rows.Count - 1
                    txtTemplate.Items.Add(.Rows(i).Item("Tmplate"))
                Next

                ' Populate with AWS Template TM_307091
                'sql = "SELECT * FROM bufr_indicators where Tmplate = 'TM_307091';"
                If Len(Tmpt) = 0 Then
                    sql = "SELECT * FROM bufr_indicators where defaultTemplate = True;"
                Else
                    sql = "SELECT * FROM bufr_indicators where Tmplate = '" & Tmpt & "';"
                End If
                dai = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
                ' Remove timeout requirement
                dai.SelectCommand.CommandTimeout = 0

                dsi.Clear()
                dai.Fill(dsi, "indicators")

                If dsi.Tables("indicators").Rows.Count > 0 Then
                    txtTemplate.Text = .Rows(0).Item("Tmplate")
                    txtMsgHeader.Text = .Rows(0).Item("Msg_Header")
                    txtBufrEdition.Text = .Rows(0).Item("BUFR_Edition")
                    txtOriginatingCentre.Text = .Rows(0).Item("Originating_Centre")
                    txtOriginatingSubcentre.Text = .Rows(0).Item("Originating_SubCentre")
                    txtUpdateSequence.Text = .Rows(0).Item("Update_Sequence")
                    chkOptionalSection.Checked = .Rows(0).Item("Optional_Section")
                    txtDataCategory.Text = .Rows(0).Item("Data_Category")
                    txtInternationalSubcategory.Text = .Rows(0).Item("Intenational_Data_SubCategory")
                    txtLocalSubcategory.Text = .Rows(0).Item("Local_Data_SubCategory")
                    txtMastertableVersion.Text = .Rows(0).Item("Master_table")
                    txtLocaltableVersion.Text = .Rows(0).Item("Local_Table")
                    If .Rows(0).Item("Optional_Section") = 0 Then
                        chkOptionalSection.Checked = False
                    Else
                        chkOptionalSection.Checked = True
                    End If
                End If
            End With

            ' Populate with Code and Flags
            sql = "SELECT FXY as Element, Description as Name, Bufr_Unit as Unit, Bufr_Value as Value FROM code_flag;"
            dai = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, iconn)
            ' Remove timeout requirement
            dai.SelectCommand.CommandTimeout = 0

            dsi.Clear()
            dai.Fill(dsi, "code_flag")
            dgrdCodeFlag.DataSource = dsi.Tables("code_flag")
        Catch ex As Exception
            iconn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        'Log_Errors("Error Testing")
        ' Save Changes made on Processing parameters
        load_PressingParameters("dpupdate")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error GoTo Err


        Ltime.Text = Now()
        txtDateTime.Text = Ltime.Text

        txtDateTime.Refresh()
        ' Set the next encoding time
        'If Len(txtNxtProcess.Text) = 0 Then
        '    'MsgBox(0)
        '    txtNxtProcess.Text = DateAdd("n", Val(txtOffset.Text) - Val(Minute(Ltime.Text)), Ltime.Text)
        '    'txtNxtProcess.Text = DateAdd("n", Val(txtOffset.Text) - Val(Minute(Now())), Now())
        '    'optStart.Checked = True
        'End If

        If optStart.Checked = True Then
            'Log_Errors(DateDiff("n", txtDateTime.Text, txtNxtProcess.Text))
            'If DateDiff("n", txtDateTime.Text, txtNxtProcess.Text) <= 0 Then
            If DateDiff("n", Now(), txtNxtProcess.Text) <= 0 Then
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
        'errdir = System.IO.Path.GetFullPath(Application.StartupPath) & "\data"
        errdir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"

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
        lstInputFiles.Refresh()
        lstOutputFiles.Items.Clear()
        lstOutputFiles.Refresh()
        txtInputServer.Text = ""
        txtInputServer.Refresh()
        txtInputfolder.Text = ""
        txtInputfolder.Refresh()
        txtOutputServer.Text = ""
        txtOutputServer.Refresh()
        txtOutputFolder.Text = ""
        txtOutputFolder.Refresh()

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
            'Exit Sub
        End If
        '  Locate and processs aws input data files
        Me.Cursor = Cursors.WaitCursor

        ' Compute the Template descriptor to Bianry form
        'If Not Compute_Descriptors(Desc_Bits) Then
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'End If
        Bufr_Subst = 0
        BUFR_Subsets_Data = ""
        BufrSection4 = ""
        'Get full path for the Subsets Output file file and create the file
        Refresh_Folder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\")
        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_subsets.csv"

        FileOpen(30, fl, OpenMode.Output)
        FileClose(30)
        FileOpen(30, fl, OpenMode.Append)
        'WriteLine(1, "Testing")
        'FileClose(1)

        Dim i As Integer

        With ds.Tables("aws_sites")

            For i = 0 To .Rows.Count - 1 'Kount - 1

                If IsDBNull(.Rows(i).Item("InputFile")) Or .Rows(i).Item("OperationalStatus") = 0 Then Continue For ' Data for site not in a state to be processed
                'Log_Errors(.Rows(i).Item("FilePrefix"))
                ' Get station data details
                nat_id = .Rows(i).Item("SiteID")

                ' Get message header for the station if exist. It has 11 characters. Otherwise use National bulletin header
                If Not IsDBNull(.Rows(i).Item("GTSHeader")) And Len(.Rows(i).Item("GTSHeader")) = 11 Then
                    msg_header = .Rows(i).Item("GTSHeader")
                Else
                    msg_header = txtMsgHeader.Text
                End If

                flg = ""
                If Not IsDBNull(.Rows(i).Item("MissingDataFlag")) Then
                    If Len(.Rows(i).Item("MissingDataFlag")) <> 0 Then flg = .Rows(i).Item("MissingDataFlag") 'Get the missing data flag
                End If

                AWSsite = .Rows(i).Item("DataStructure")
                Get_Station_Settings(AWSsite, delmtr, hdrows, txtqlfr, rs)

                ftp_host = .Rows(i).Item("awsServerIp")

                ' Get files prefix status
                flprefix = ""
                'MsgBox(.Rows(i).Item("chkPrefix"))
                If Not IsDBNull(.Rows(i).Item("FilePrefix")) And .Rows(i).Item("chkPrefix") = True Then
                    flprefix = .Rows(i).Item("FilePrefix") '
                    If Len(flprefix) > 0 Then
                        flprefix = Compute_Prefix(flprefix)
                    End If
                End If

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
                    Continue For ' If FTP call failed
                End If

                ' Assign a variable to an input file with header rows. txtinputfile  variable has been assisgned at FTP_Call function
                aws_input_file = txtinputfile

                ' Check if the input data file was retrieved
                If Not File.Exists(aws_input_file) Then
                    Log_Errors(" Could not find " & aws_input_file)
                    Continue For
                End If

                FileClose(1)
                txtStatus.Text = "Organising the input file"

                ' Assign a variable to an output file without header rows
                aws_input_file_flds = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\aws_input.txt" 'fso.GetParentFolderName(App.Path) & "\data\aws_input.txt"

                FileOpen(10, aws_input_file, OpenMode.Input)
                FileOpen(11, aws_input_file_flds, OpenMode.Output)

                ' Skip header Records if present
                If Val(hdrows) > 0 Then 'Retrieve header rows from station parameters
                    For j = 0 To Val(hdrows) - 1
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
                Dim colmn, dtCol As Integer
                Dim rws As Long
                Dim x, dtFmt As String
                'ChrW(delimiter_ascii)

                ' Convert the input file to a data table for ease of referencing the records therein.
                dTable = Text_To_DataTable(aws_input_file_flds, ChrW(delimiter_ascii), 0, colmn, rws)

                For k = 0 To rws - 2
                    Process_Status("Processing input record " & k + 1 & " of " & rws)
                    ' Get date and time for the current record
                    datestring = Get_DateStamp(AWSsite, dTable, k)
                    'MsgBox(datestring)
                    'Skip older records
                    If InStr(datestring, txtqlfr) > 0 And Len(txtqlfr) > 0 Then datestring = Strings.Mid(datestring, 2, Len(datestring) - 2) ' Text qualifier character exits. It must be excluded from the time stamp data

                    'Skip records with invalid date stamp
                    If IsDate(datestring) Then
                        'Log_Errors(datestring)
                        ' Compare current time with time stamp on hourly basis. Skip records outside the time range
                        If DateDiff("h", datestring, txtDateTime.Text) > Val(txtPeriod.Text) And Val(txtPeriod.Text) <> 999 Then Continue For

                        Process_Status("Processing AWS Record " & k + 1 & " of " & rws - 1)

                        ' Update obsv value column in the data structure
                        For j = 0 To colmn - 1
                            If Not IsDBNull(dTable.Rows(k).Item(j)) Then
                                x = dTable.Rows(k).Item(j)
                                'Log_Errors(x)
                                If InStr(x, txtqlfr) > 0 And Len(txtqlfr) > 0 Then
                                    x = Strings.Mid(x, 2, Len(x) - 2)
                                End If

                                AwsRecord_Update(x, j, flg, AWSsite)
                            Else
                                Continue For
                            End If
                        Next j

                        ' Analyse the datetime string and process the data if the encoding time interval matches datetime value
                        Dim sqlv As String
                        sqlv = "SELECT * FROM " & AWSsite & " order by Cols"
                        rs = GetDataSet(AWSsite, sqlv)

                        'Don't process the record if having invalid datestamp
                        'If IsDate(datestring) Then

                        'Update the record into the database
                        If Val(txtPeriod.Text) = 999 Then

                            ' Process the entire input file irespective of time difference
                            Process_Input_Record(AWSsite, datestring)
                        Else
                            ' Process records for the last selected hours
                            If DateDiff("h", datestring, txtDateTime.Text) <= Val(txtPeriod.Text - 1) Then
                                Process_Input_Record(AWSsite, datestring)
                            End If
                        End If
                        'End If
                    End If
                Next k

                ' Delete input file from base station server if so selected
                If chkDeleteFile.Checked Then
                    If Not FTP_Delete_InputFile(infile) Then
                        Log_Errors("Can't Delete Input File") 'MsgBox "Can't Delete Input File"
                    End If
                End If

            Next i
        End With

        ' Encode and compose the BUFR Bulletins
        FileClose(30)

        ' Open the output file containing the encoded BUFR Subsets data
        fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_subsets.csv"

        FileOpen(30, fl, OpenMode.Input)

        Dim dts(1000), subs(1000), Tdone, Tsubs, subst, yy, mm, dd, hh,mn As String

        ' Load the subsets records from an output file into arrays
        Kount = 0
        Do While EOF(30) = False
            Input(30, dts(Kount))
            Input(30, subs(Kount))
            'MsgBox(dts(Kount) & "-" & subs(Kount))
            Kount = Kount + 1
        Loop

        'Compute the UTC datetime for YYGGgg

        'Dim YYGGgg As Date
        'YYGGgg = DateAndTime.DateAdd("h", -1 * CDbl(txtGMTDiff.Text), Now())
        'yy = String.Format("{0:00}", DateAndTime.Year(YYGGgg))
        'mm = String.Format("{0:00}", DateAndTime.Month(YYGGgg))
        'dd = String.Format("{0:00}", DateAndTime.Day(YYGGgg))
        'hh = String.Format("{0:00}", DateAndTime.Hour(YYGGgg))
        'mn = "00"

        If Kount = 1 Then ' Only one substest existing
            If Len(subs(0)) <> 0 Then  'Check whether encoded data exists
                yy = String.Format("{0:00}", DateAndTime.Year(dts(0)))
                mm = String.Format("{0:00}", DateAndTime.Month(dts(0)))
                dd = String.Format("{0:00}", DateAndTime.Day(dts(0)))
                hh = String.Format("{0:00}", DateAndTime.Hour(dts(0)))
                mn = String.Format("{0:00}", DateAndTime.Minute(dts(0)))
                BUFR_header = msg_header & " " & dd & hh & mn '& " " & txtBBB
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

                'msg_header = txtMsgHeader.Text ' National Message Header

                ' Compile a bulletin for the located same hour subsets
                If Len(subst) <> 0 Then
                    'Compute the observation datetime in UTC
                    yy = String.Format("{0:00}", DateAndTime.Year(dts(i)))
                    mm = String.Format("{0:00}", DateAndTime.Month(dts(i)))
                    hh = String.Format("{0:00}", DateAndTime.Hour(dts(i)))
                    dd = String.Format("{0:00}", DateAndTime.Day(dts(i)))
                    hh = String.Format("{0:00}", DateAndTime.Hour(dts(i)))
                    mn = String.Format("{0:00}", DateAndTime.Minute(dts(i)))

                    BUFR_header = msg_header & " " & dd & hh & mn '& " " & txtBBB
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
        'If Err.Number = 13 Then Resume Next
        'If Err.Number = 62 Or Err.Number = 9 Then
        If Err.Number = 62 Then
            Log_Errors(Err.Description & " Can't retrieve data from " & infile)
            'list_errors.Refresh()

            'GoTo Continues
            Resume Next
        End If
        'If Err.Number = 3349 Then Resume Next
        ''   MsgBox Err.Number & " " & Err.description
        'MsgBox("Process_input_data")
        'Log_Errors(Err.Number & ": " & Err.Description & " at process_input_data")
        Me.Cursor = Cursors.Default
        FileClose(1)
        FileClose(10)
        FileClose(11)
        FileClose(30)
        FileClose(31)
    End Sub
    'Sub Next_Encoding_Time()

    'End Sub
    Function Compute_Descriptors(tt_aws As String, ByRef Desc_Bits As String) As Boolean
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

        'sql = "SELECT Nos, Bufr_Template, CREX_Template, Sequence_Descriptor1, Sequence_Descriptor0, Bufr_Element, Crex_Element, Climsoft_Element, Element_Name, Crex_Unit, Crex_Scale, Crex_DataWidth, Bufr_Unit, Bufr_Scale, Bufr_RefValue, Bufr_DataWidth_Bits, Observation, Crex_Data, Bufr_Data " &
        '      "FROM TM_307091 WHERE (((Sequence_Descriptor1) Is Not Null)) ORDER BY Nos;"

        sql = "SELECT Nos, Bufr_Template, CREX_Template, Sequence_Descriptor1, Sequence_Descriptor0, Bufr_Element, Crex_Element, Climsoft_Element, Element_Name, Crex_Unit, Crex_Scale, Crex_DataWidth, Bufr_Unit, Bufr_Scale, Bufr_RefValue, Bufr_DataWidth_Bits, Observation, Crex_Data, Bufr_Data " &
              "FROM " & tt_aws & " WHERE (((Sequence_Descriptor1) Is Not Null)) ORDER BY Nos;"
        'Log_Errors(sql)
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        ' Remove timeout requirement
        da.SelectCommand.CommandTimeout = 0

        dr.Clear()
        da.Fill(dr, "tm_307091")

        maxrecs = dr.Tables("tm_307091").Rows.Count
        Seq_Desc = ""
        descrfil = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\descriptors.txt"
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

        Dim r As Integer
        Dim s As Integer
        Dim x As String
        Dim binstr As String

        x = DecN
        binstr = 0

        Try
            ' Build a Zeros bitstring to the size of data width. Binary converted data will replace the Zoreos from right side 
            For i = 2 To bts
                binstr = binstr & "0"
            Next

            s = 0 ' Initialize the bits counter
            Do While bts > s
                r = DecN Mod 2

                ' Replace the Zero bit with the remainder value from division by 2
                Mid(binstr, bts - s, 1) = r

                If r = 1 Then
                    DecN = DecN / 2 - 0.5
                Else
                    DecN = DecN / 2
                End If
                s = s + 1
            Loop

            Return binstr

        Catch ex As Exception
            Log_Errors(ex.Message)
            Return binstr
        End Try
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
        'Log_Errors(ftpfile & " " & ftpmethod)
        'MsgBox(ftpfile & " " & ftpmethod)
        FTP_Call = True

        Dim ftpscript As String
        Dim ftpbatch As String
        Dim Drive1 As String
        Dim local_folder As String
        Dim out_folder As String

        Dim usr As String
        Dim pwd As String
        Dim flder, fldr As String
        Dim ftpmode As String

        Try
            If Not Get_ftp_details(ftpmethod, ftp_host, flder, ftpmode, usr, pwd) Then
                Log_Errors("Host server " & ftp_host & " Not found")
                Return False
            End If
            'MsgBox(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)
            FileClose(1)
            local_folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            'Refresh_Folder(local_folder)
            Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
            Drive1 = Strings.Left(Drive1, Len(Drive1) - 1)
            ftpscript = local_folder & "\ftp_aws.txt"

            'FileOpen(1, ftpscript, OpenMode.Output)
            ftpfile = flder & ftpfile
            txtinputfile = local_folder & "\" & System.IO.Path.GetFileName(ftpfile)
            Select Case ftpmethod
                Case "get"

                    'MsgBox(ftpmode & " " & txtinputfile)
                    FileClose(1)
                    FileOpen(1, ftpscript, OpenMode.Output)
                    If ftpmode = "psftp" Then Print(1, "cd " & flder & Chr(13) & Chr(10)) 'Print #1, "cd " & in_folder
                    If ftpmode = "FTP" Then
                        Print(1, "open " & ftp_host & Chr(13) & Chr(10))
                        Print(1, usr & Chr(13) & Chr(10))
                        Print(1, pwd & Chr(13) & Chr(10))
                        Print(1, "cd " & flder & Chr(13) & Chr(10))
                        Print(1, "asc" & Chr(13) & Chr(10))
                    End If
                    ' Where file prefix is used
                    If Len(flprefix) = 0 Then
                        Print(1, ftpmethod & " " & ftpfile & Chr(13) & Chr(10))
                    Else
                        ' Get input files path

                        'fldr = flder & ftpfile
                        'fldr = (IO.Path.GetDirectoryName(fldr))

                        fldr = (IO.Path.GetDirectoryName(ftpfile))

                        fldr = Strings.Replace(fldr, "\", "/") ' Convert file path dlimiters to FTP structure
                        'fldr = FTP_FilePath(fldr)

                        'Log_Errors(fldr)
                        'Log_Errors(txtfilePrefix.Text)
                        Print(1, "cd " & fldr & Chr(13) & Chr(10))
                        'Print(1, "mget *" & flprefix & "*.*" & Chr(13) & Chr(10))
                        Print(1, "quote PASV" & Chr(13) & Chr(10))
                        Print(1, "mget *" & flprefix & "*" & Chr(13) & Chr(10))
                    End If
                    Print(1, "bye" & Chr(13) & Chr(10))
                    FileClose(1)
                Case "put"
                    FileClose(1)
                    FileOpen(2, ftpscript, OpenMode.Output)
                    If ftpmode = "psftp" Then Print(2, "cd " & flder & Chr(13) & Chr(10))
                    If ftpmode = "FTP" Then
                        Print(2, "open " & ftp_host & Chr(13) & Chr(10))
                        Print(2, usr & Chr(13) & Chr(10))
                        Print(2, pwd & Chr(13) & Chr(10))
                        Print(2, "cd " & flder & Chr(13) & Chr(10))
                        Print(2, "bin" & Chr(13) & Chr(10))
                    End If
                    Print(2, "quote PASV" & Chr(13) & Chr(10))
                    Print(2, ftpmethod & " " & ftpfile & Chr(13) & Chr(10))
                    Print(2, "bye" & Chr(13) & Chr(10))
                    FileClose(2)
            End Select
            FileClose(1)
            FileClose(3)
            '        ' Create batch file to execute FTP script
            ftpbatch = local_folder & "\ftp_tdcf.bat"

            FileOpen(3, ftpbatch, OpenMode.Output)

            Print(3, "echo off" & Chr(13) & Chr(10))
            Print(3, Drive1 & Chr(13) & Chr(10))
            Print(3, "CD " & local_folder & Chr(13) & Chr(10))

            If ftpmethod = "get" Then
                If ftpmode = "FTP" Then Print(3, ftpmode & " -i -s:ftp_aws.txt" & Chr(13) & Chr(10))
                If ftpmode = "PSFTP" Then Print(3, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
            Else
                'If ftpmode = "FTP" Then Print(3, ftpmode & " -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
                ''If ftpmode = "FTP" Then Print(1, ftpmode & "s -a -v -s:ftp_aws.txt" & Chr(13) & Chr(10))
                'If ftpmode = "PSFTP" Then Print(3, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_aws.txt" & Chr(13) & Chr(10))
            End If

            Print(3, "echo on" & Chr(13) & Chr(10))
            Print(3, "EXIT" & Chr(13) & Chr(10))
            FileClose(3)

            ' Execute the batch file to transfer the aws data file from aws server to a local folder
            Dim Twait As Long

            If txtTimeout.Text = "999" Then
                Twait = -1 ' No timeout period
            Else
                Twait = Val(txtTimeout.Text) * 1000 ' Time out period in millisecond
            End If
            'Shell(ftpbatch, vbMinimizedNoFocus)
            Interaction.Shell(ftpbatch, vbMinimizedNoFocus, Wait:=True, Timeout:=Twait)

            If ftpmethod = "get" Then
                '' Cause some delay to allow ftp file transfer before the processing starts.
                'Dim Cdate1 As Date
                'Dim tot As Integer
                'Dim timeout As Integer
                Dim dat As String

                'Cdate1 = Now() '& " " & Time
                'tot = 0
                'timeout = CLng(txtTimeout.Text)
                'With ProgressBar1
                '    .Visible = True
                '    .Maximum = timeout ' 60
                '    Do While tot < timeout
                '        tot = DateDiff("s", Cdate1, Now())
                '        .Value = tot
                '    Loop
                '    .Visible = False
                'End With

                If Len(flprefix) > 0 Then

                    Dim fd As New DirectoryInfo(local_folder)
                    Dim aryFl As FileInfo() = fd.GetFiles("*.*")
                    Dim fl As FileInfo

                    FileOpen(100, txtinputfile, OpenMode.Output)
                    For Each fl In aryFl
                        If InStr(fl.Name, flprefix) > 0 Then
                            FileOpen(200, local_folder & "\" & fl.Name, OpenMode.Input)
                            Do While EOF(200) = False
                                dat = LineInput(200)
                                PrintLine(100, dat)
                            Loop
                            FileClose(200)
                            File.Delete(local_folder & "\" & fl.Name)
                        End If
                    Next fl
                    FileClose(100)

                End If

                txtInputServer.Text = ftp_host
                txtInputfolder.Text = flder

                ' List the input file
                lstInputFiles.Items.Add(System.IO.Path.GetFileName(ftpfile))
                lstInputFiles.Refresh()
                txtInputServer.Refresh()


            Else
                'txtOutputServer.Text = ftp_host
                'txtOutputFolder.Text = flder

                '' List the processed output file
                'lstOutputFiles.Items.Add(System.IO.Path.GetFileName(ftpfile))
                'txtOutputServer.Refresh()
                'txtOutputFolder.Refresh()
                'lstOutputFiles.Refresh()
            End If
            FileClose(1)

            If System.IO.Path.GetFileName(ftpfile).Length = 0 Then Exit Function

            'Log_Errors(ftpmethod & " " & ftp_host & " " & flder & " " & ftpmode & " " & usr & " " & pwd)

        Catch ex As Exception
            FileClose(1)
            FileClose(3)
            FileClose(100)
            FileClose(200)
            Log_Errors(ex.Message & " at FTP_Call")
            FTP_Call = False
        End Try
    End Function
    Sub Refresh_Folder(flder As String)
        Dim fd As New DirectoryInfo(flder)
        Dim aryFl As FileInfo() = fd.GetFiles("*.*")
        Dim fl As FileInfo
        'MsgBox(flder)
        If aryFl.Count > 0 Then
            For Each fl In aryFl
                fl.Delete()
            Next
        End If
    End Sub
    Function Get_ftp_details(ftpmethod As String, aws_ftp As String, ByRef flder As String, ByRef ftpmode As String, ByRef usr As String, ByRef pwd As String) As Boolean

        Dim sql As String
        Dim rf As New DataSet
        Dim num As Integer
        Try
            Get_ftp_details = True
            'MsgBox(aws_ftp)
            Select Case ftpmethod
                Case "get"
                    sql = "SELECT * FROM aws_basestation"

                    rf = GetDataSet("aws_basestation", sql)

                    num = rf.Tables("aws_basestation").Rows.Count

                    For i = 0 To num - 1 ' Get Ftp details for the current site
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
                    'sql = "SELECT * FROM aws_mss"

                    ' Code changed to allow inclusion separate folders for binary and alphanumeric data
                    sql = "SELECT * FROM aws_mss where foldertype = 'binary';"

                    rf = GetDataSet("aws_mss", sql)
                    If rf.Tables("aws_mss").Rows.Count = 0 Then
                        Log_Errors("No Message Switch available")
                        Return False
                    Else
                        With rf.Tables("aws_mss") ' Only one message switch. Get its details

                            ftp_host = .Rows(0).Item("ftpId")
                            flder = .Rows(0).Item("inputFolder")
                            ftpmode = .Rows(0).Item("ftpMode")
                            usr = .Rows(0).Item("userName")
                            pwd = .Rows(0).Item("password")
                            'Log_Errors(flder)
                        End With
                    End If
            End Select

        Catch ex As Exception
            Log_Errors(ex.Message)
            Return False
        End Try

    End Function

    Function FTP_Put(fl As String) As Boolean
        Dim Lflder, Rflder, Drv, ftpmode, usr, pwd, ftpscript, ftpbatch, binFile As String
        Dim rf As DataSet

        Try
            Lflder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
            Drv = System.IO.Path.GetPathRoot(Application.StartupPath)
            Drv = Strings.Left(Drv, Len(Drv) - 1)

            ftpscript = Lflder & "\ftp_put.txt"
            'ftpscript = "ftp_put.txt"

            'sql = "SELECT * FROM aws_mss"
            sql = "SELECT * FROM aws_mss where foldertype = 'binary';"

            rf = GetDataSet("aws_mss", sql)
            If rf.Tables("aws_mss").Rows.Count = 0 Then
                Log_Errors("No Message Switch available")
                'Return False
            Else
                With rf.Tables("aws_mss") ' Only one message switch. Get its details
                    ftp_host = .Rows(0).Item("ftpId")
                    Rflder = .Rows(0).Item("inputFolder")
                    ftpmode = .Rows(0).Item("ftpMode")
                    usr = .Rows(0).Item("userName")
                    pwd = .Rows(0).Item("password")
                End With
            End If
            binFile = Strings.Replace(fl, "tmp", "f") ' Create temporary binary file for convinience of uploading to MSS
            FileOpen(111, ftpscript, OpenMode.Output)
            If ftpmode = "psftp" Then Print(2, "cd " & Rflder & Chr(13) & Chr(10))
            If ftpmode = "FTP" Then
                Print(111, "open " & ftp_host & Chr(13) & Chr(10))
                Print(111, usr & Chr(13) & Chr(10))
                Print(111, pwd & Chr(13) & Chr(10))
                Print(111, "cd " & Rflder & Chr(13) & Chr(10))
                Print(111, "bin" & Chr(13) & Chr(10))
            End If
            Print(111, "quote PASV" & Chr(13) & Chr(10))
            'Print(111, "put" & " " & tmp & Chr(13) & Chr(10))
            Print(111, "put" & " " & fl & Chr(13) & Chr(10))
            Print(111, "rename" & " " & fl & " " & binFile & Chr(13) & Chr(10))
            Print(111, "bye" & Chr(13) & Chr(10))
            FileClose(111)

            '        ' Create batch file to execute FTP script
            ftpbatch = Lflder & "\ftp_put.bat"

            FileOpen(112, ftpbatch, OpenMode.Output)

            Print(112, "echo off" & Chr(13) & Chr(10))
            Print(112, Drv & Chr(13) & Chr(10))
            Print(112, "CD " & Lflder & Chr(13) & Chr(10))
            If ftpmode = "FTP" Then Print(112, ftpmode & " -v -s:ftp_put.txt" & Chr(13) & Chr(10))
            If ftpmode = "PSFTP" Then Print(112, ftpmode & " " & usr & "@" & ftp_host & " -pw " & pwd & " -b ftp_put.txt" & Chr(13) & Chr(10))
            Print(112, "echo on" & Chr(13) & Chr(10))
            Print(112, "EXIT" & Chr(13) & Chr(10))

            FileClose(112)

            ' Execute the batch file to transfer the aws data file from aws server to a local folder
            'Shell(ftpbatch, vbMinimizedNoFocus)
            Interaction.Shell(ftpbatch, vbMinimizedNoFocus, Wait:=True)

            txtOutputServer.Text = ftp_host
            txtOutputFolder.Text = Rflder

            ' List the processed output file
            'lstOutputFiles.Items.Add(System.IO.Path.GetFileName(fl))
            lstOutputFiles.Items.Add(System.IO.Path.GetFileName(binFile))
            txtOutputServer.Refresh()
            txtOutputFolder.Refresh()
            lstOutputFiles.Refresh()

            Return True

            'Dim oScript As Object
            'FileOpen(111, scriptfl, OpenMode.Output)

            'If ftpmode = "psftp" Then PrintLine(111, "cd " & Lflder)
            'If ftpmode = "FTP" Then
            '    PrintLine(111, "open " & ftp_host & Chr(13) & Chr(10))
            '    PrintLine(111, usr)
            '    PrintLine(111, pwd)
            '    PrintLine(111, "cd " & Rflder)
            '    PrintLine(111, "bin")
            'End If
            'PrintLine(111, "put" & " " & fl)
            'PrintLine(111, "bye")
            'FileClose(111)
            'Dim strCMD As String
            'strCMD = "ftp.exe -i -s: " & scriptfl ' C:\ftpCommand.ftp"
            '' create the temperory file to store the output generated after executing the FTP command 
            'Dim strTempFile As String
            'strTempFile = Lflder & "\ftpOutput.txt" '"C:\ftpOutput.txt"
            '' call the command promt control to execute the delete operation

            'Call Shell("cmd.exe /c " & strCMD & " > " & strTempFile, 0, True)

        Catch ex As Exception
            Log_Errors(ex.Message & " at FTP_put")
            FileClose(111)
            FileClose(112)
            Return False
        End Try

    End Function
    Sub Process_Input_Record(aws_rs As String, datestring As String)
        Dim str As DataSet
        Dim sql2 As String
        Dim GMTDiff As Integer
        Dim Date_Time As Date
        Try
            'sql2 = "SELECT * FROM station"
            sql2 = "select * from station where stationId = '" & nat_id & "';"

            str = GetDataSet("station", sql2)

            'Initialize station details with blanks
            stn_name = ""
            lat = ""
            lon = ""
            elv = ""
            wmo_id = ""

            With str.Tables("station")
                If .Rows.Count <> 0 Then
                    If Not IsDBNull(.Rows(0).Item("stationName")) Then stn_name = .Rows(0).Item("stationName")
                    If Not IsDBNull(.Rows(0).Item("latitude")) Then lat = .Rows(0).Item("latitude")
                    If Not IsDBNull(.Rows(0).Item("longitude")) Then lon = .Rows(0).Item("longitude")
                    If Not IsDBNull(.Rows(0).Item("elevation")) Then elv = .Rows(0).Item("elevation")
                    If Not IsDBNull(.Rows(0).Item("wmoid")) Then wmo_id = .Rows(0).Item("wmoid")
                Else
                    Log_Errors(nat_id & " ot found in Stations metadata")
                End If
            End With

            update_main_db(aws_rs, datestring, nat_id)

            'If Val(txtInterval.Text) = 0 Or Val(txtInterval.Text) > 60 Then ' Not a valid Encoding interval set
            '    Log_Errors(txtInterval.Text & " Not a valid Encoding time interval")
            '    Exit Sub
            'End If

            Dim ET, Rmd As Integer

            '' Compute Encoding time
            'ET = CDbl(Minute(datestring)) / CDbl(Val(txtInterval.Text))
            'If ET <> 0 And ET <> 1 Then Exit Sub ' Not an encoding time interval

            If Val(txtPeriod.Text) = 999 Or Not GTSEncode(nat_id) Then Exit Sub ' No processing of messages if entire file processing is selected or the site is NOT set for encoding GTS message

            If IsDate(datestring) Then
                ' Convert time to UTC
                GMTDiff = CDbl(txtGMTDiff.Text)
                Date_Time = DateAdd("h", -1 * GMTDiff, datestring)

                ' Compute Encoding interval hours 
                ET = Math.Round(Val(txtInterval.Text) / 60)
                Rmd = DateAndTime.Hour(Date_Time) Mod ET

                ' Update the Template Table and Process the messages for transmission at the scheduled time
                If Val(DateAndTime.Hour(Date_Time)) Mod ET = 0 Then update_tbltemplate(aws_rs, Date_Time)
            End If
            txtLastProcess.Text = datestring

            Exit Sub
        Catch Err As Exception
            Log_Errors(Err.HResult & ": " & Err.Message & " at Process_Input_Record")

        End Try
    End Sub
    Function GTSEncode(nat_id As String) As Boolean
        Dim grs As DataSet
        GTSEncode = False
        Try
            sql = "Select * from aws_sites where siteID ='" & nat_id & "';"
            grs = GetDataSet("aws_sites", sql)
            With grs.Tables("aws_sites")
                If .Rows.Count <> 0 Then
                    If .Rows(0).Item("GTSEncode") = 1 Or .Rows(0).Item("GTSEncode") Then Return True
                End If
            End With
        Catch ex As Exception
            Log_Errors(ex.Message)
            Return False
        End Try
    End Function
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

                    If Not IsDBNull(.Rows(i).Item("lower_limit")) And Not IsDBNull(.Rows(i).Item("upper_limit")) And Len(obs) <> 0 Then
                        'If Len(.Rows(i).Item("lower_limit")) <> 0 And Len(.Rows(i).Item("upper_limit")) <> 0 And Len(obs) <> 0 Then
                        If QC_Limits(stn, .Rows(i).Item("Climsoft_Element"), datestr, obs, .Rows(i).Item("lower_limit"), .Rows(i).Item("upper_limit")) Then
                            Continue For
                        End If

                    End If

                    If Not IsDBNull(.Rows(i).Item("unit")) Then
                        units = .Rows(i).Item("unit")
                        If units = "knots" Then obs = Val(obs) / 2
                        If units = "HPa" Then obs = Val(obs) * 100
                    End If

                    sql = "INSERT INTO observationfinal " &
                        "(recordedFrom, describedBy, obsDatetime, obsLevel, obsValue,flag) " &
                        "SELECT '" & stn & "', '" & .Rows(i).Item("Climsoft_Element") & "', '" & mysqldate & "','surface','" & obs & "','" & flgs & "';"

                    'Log_Errors(sql)
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                End If
            Next
        End With

        Exit Sub
Err:
        'If Err.Number = 3421 Then Exit Sub
        'If Err.Number = 3022 Then Resume Next
        'If Err.Number = 3146 Then Resume Next
        If Err.Number = 5 Then Resume Next
        'MsgBox(" Update_main_db")
        Log_Errors(Err.Number & ":" & Err.Description & "  at Update_main_db")
    End Sub
    Function QC_Limits(stn As String, elms As String, dts As String, obs As String, L_limit As String, U_limit As String) As Boolean
        QC_Limits = False
        Try

            If Val(obs) < Val(L_limit) Or Val(obs) > U_limit Then
                QC_Limits = True
                Dim errdata, limittype As String
                'Get full path for the Subsets Output file file and create the file
                fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\aws_qc_errors.csv"
                FileOpen(21, fl, OpenMode.Append)

                If Val(obs) < Val(L_limit) Then limittype = "Lower Limit"
                If Val(obs) > Val(U_limit) Then limittype = "Upper Limit"

                errdata = stn & "," & elms & "," & dts & "," & obs & "," & limittype

                PrintLine(21, errdata)
                FileClose(21)

                txtQC.Text = "QC Errors saved in file: " & fl
                txtQC.Refresh()

                'Log_Errors("QC Errors saved in file: " & fl)
            End If
            'End If
        Catch ex As Exception
            FileClose(21)
            'Log_Errors(ex.HResult & ":" & ex.Message & "  at QC_Limits")
        End Try

    End Function
    Sub update_tbltemplate(aws_struct As String, Date_Time As String)
        Dim qry As MySql.Data.MySqlClient.MySqlCommand
        Dim dbconw As New MySql.Data.MySqlClient.MySqlConnection
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        Dim trs As New DataSet
        Dim sql, yy, mm, dd, hh, min, ss, Seq_Desc, tt_aws, InitValue As String
        Dim stn_typ As Integer
        'Dim obsv, hdr As String

        Try
            'cmd.Connection = Dim dbconw

            tt_aws = txtTemplate.Text

            sql = "DROP TABLE IF EXISTS bufr_crex_data; CREATE TABLE bufr_crex_data AS SELECT " & tt_aws & ".Nos, " & tt_aws & ".Bufr_Template, " & tt_aws & ".Crex_Template, " & tt_aws & ".Sequence_Descriptor1," & tt_aws & ".Sequence_Descriptor0," & tt_aws & ".Bufr_Element, " & tt_aws & ".Crex_Element, " & tt_aws & ".Climsoft_Element, " & tt_aws & ".Element_Name, bufr_crex_master.Crex_Unit, bufr_crex_master.Crex_Scale, bufr_crex_master.Crex_DataWidth, bufr_crex_master.Bufr_Unit, bufr_crex_master.Bufr_Scale, bufr_crex_master.Bufr_RefValue, bufr_crex_master.Bufr_DataWidth_Bits, " & tt_aws & ".selected, bufr_crex_master.Observation, bufr_crex_master.Crex_Data, bufr_crex_master.Bufr_Data FROM " & tt_aws & " INNER JOIN bufr_crex_master ON " & tt_aws & ".Bufr_Element = bufr_crex_master.Bufr_FXY ORDER BY " & tt_aws & ".Nos; " &
                "ALTER TABLE `bufr_crex_data` ADD PRIMARY KEY (`Nos`);"

            ' Create query Command for creating a new table 'bufr_crex_data'

            dbconw.ConnectionString = frmLogin.txtusrpwd.Text

            dbconw.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconw)

            'Execute query
            qry.ExecuteNonQuery()


            tt_aws = "bufr_crex_data"

            sql = "SELECT * FROM " & tt_aws & " ORDER BY Nos"

            'trs = GetDataSet(tt_aws, sql)
            'trs = GetDataSet("bufr_crex_data", sql)

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconw)
            ' Remove timeout requirement
            da.SelectCommand.CommandTimeout = 0

            trs.Clear()
            da.Fill(trs, tt_aws)

            yy = DateAndTime.Year(Date_Time)
            mm = DateAndTime.Month(Date_Time)
            dd = DateAndTime.Day(Date_Time)
            hh = DateAndTime.Hour(Date_Time)
            'hh = Val(DateAndTime.Hour(Date_Time)) - Int(txtGMTDiff.Text)
            min = DateAndTime.Minute(Date_Time)
            ss = DateAndTime.Second(Date_Time)
            stn_typ = 0 ' Code for AWS

            'msg_header = MsgHeaber_ByHour(hh)

            'BUFR_header = msg_header & " " & Format(dd, "00") & Format(hh, "00") & Format(min, "00") '& " " & txtBBB
            BUFR_header = msg_header & " " & dd & hh & min '& " " & txtBBB

            Process_Status("Updating TDCF Template with observations ")

            Seq_Desc = ""

            With trs.Tables(tt_aws)

                'Initialize the templatate
                For i = 0 To .Rows.Count - 1
                    Initialize_Template(tt_aws)
                Next

                For i = 0 To .Rows.Count - 1
                    ' If Len(.Fields("Sequence_Descriptor1")) <> 0 Then Seq_Desc = Seq_Desc & .Fields("Sequence_Descriptor1")
                    'If Len(Initialize_CodeFlag(trs, i)) <> 0 Then MsgBox(Initialize_CodeFlag(trs, i))

                    Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                    Dim recUpdate As New dataEntryGlobalRoutines

                    ' Initialize Bufr data with missing value i.e. all 1s
                    If Strings.Left(.Rows(i).Item("Bufr_Element"), 1) = 0 And .Rows(i).Item("Bufr_Element") <> "031000" And .Rows(i).Item("Bufr_Element") <> "004025" Then ' Element Descriptors only but not Delayed replication factor factor. It is preset
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
                    If .Rows(i).Item("Bufr_Element") = "002001" Then .Rows(i).Item("Observation") = stn_typ
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

            If txtTemplate.Text = "TM_307080" Then ' Use the Synoptic data template

                'Initialize Cloud Replications
                'Delayed replication of cloud layers above station level 4 descriptors for a maximum of 4 layers
                Initialize_Cloud_Replications(dbconw, trs, qry, "cloud_rep1", 4)

                'Delayed replication of cloud layers below station level 5 descriptors for a maximum of 4 layers
                Initialize_Cloud_Replications(dbconw, trs, qry, "cloud_rep2", 5)

                'Update_Instruments_Details()
                Update_Time_Periods(dbconw, qry, hh)
                Update_observations(dbconw, qry, aws_struct)
                ' Update with accumulated observations
                ' Precipitation accumulation
                'Select recordedFrom As ID, sum(obsValue) As Total from observationfinal where recordedFrom ='GZ008074' and describedBy='892' and (obsdatetime between '2020-09-10 08:01:00' and '2020-09-11 08:00:00') group by ID;

                Update_specificPeriod_Observations(dbconw, Date_Time, nat_id)
                'Log_Errors("Start Encoding")
                ' 3 Hour observations
                ' Tmax and Tmin values

                TDCF_Encode(dbconw, qry, trs, tt_aws)

                'Output_Data_Code(dbconn, i + 1)
                'Data_Description_Section = Data_Description_Section & Bufr_Section4(dbconn)
            Else ' Use the AWS Template

                ' Initialize Code and Flag Tables
                Initialize_CodeFlag(trs, tt_aws, dbconw)

                ' Update Template with AWS observation values
                sql = "UPDATE " & aws_struct & " INNER JOIN " & tt_aws & " ON " & aws_struct & ".Bufr_Element = " & tt_aws & ".Bufr_Element SET " & tt_aws & ".Observation = " & aws_struct & ".obsv where " & aws_struct & ".Bufr_Element = " & tt_aws & ".Bufr_Element;"

                cmd.Connection = dbconw
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()

                '    ' Update Template with Replicated Values
                Replicate_SoilTemp(trs, aws_struct, tt_aws)
                Replicate_MaxGust(trs, aws_struct, tt_aws)
                'End If

                '    ' Encode observations in the template into TDCF-BUFR
                'TDCF_Encode(trs, tt_aws)
                TDCF_Encode(dbconw, qry, trs, "bufr_crex_data")

                ' Compose data for BUFR Section 4 - Data Section
                'sql = "Select TM_307091.Rec, TM_307091.Bufr_Template, TM_307091.CREX_Template, TM_307091.Sequence_Descriptor1, TM_307091.Sequence_Descriptor0, TM_307091.Bufr_Element, TM_307091.Crex_Element, TM_307091.Climsoft_Element, TM_307091.Element_Name, TM_307091.Crex_Unit, TM_307091.Crex_Scale, TM_307091.Crex_DataWidth, TM_307091.Bufr_Unit, TM_307091.Bufr_Scale, TM_307091.Bufr_RefValue, TM_307091.Bufr_DataWidth_Bits, TM_307091.Selected, TM_307091.Observation, TM_307091.Crex_Data, TM_307091.Bufr_Data " &
                '      "From TM_307091 Where (((TM_307091.Selected) = True)) ORDER BY TM_307091.Rec;"
            End If

            sql = "Select bufr_crex_data.Nos, bufr_crex_data.Bufr_Template, bufr_crex_data.CREX_Template, bufr_crex_data.Sequence_Descriptor1, bufr_crex_data.Sequence_Descriptor0, bufr_crex_data.Bufr_Element, bufr_crex_data.Crex_Element, bufr_crex_data.Climsoft_Element, bufr_crex_data.Element_Name, bufr_crex_data.Crex_Unit, bufr_crex_data.Crex_Scale, bufr_crex_data.Crex_DataWidth, bufr_crex_data.Bufr_Unit, bufr_crex_data.Bufr_Scale, bufr_crex_data.Bufr_RefValue, bufr_crex_data.Bufr_DataWidth_Bits, bufr_crex_data.Selected, bufr_crex_data.Observation, bufr_crex_data.Crex_Data, bufr_crex_data.Bufr_Data " &
                  "From bufr_crex_data Where (((bufr_crex_data.Selected) = True)) ORDER BY bufr_crex_data.Nos;"

            ' Compute the Template descriptor to Bianry form
            If Not Compute_Descriptors(tt_aws, Desc_Bits) Then
                Log_Errors("Can't compute descriptors")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            'Bufr_Subst = 0
            'BUFR_Subsets_Data = ""
            'Get full path for the Subsets Output file file and create the file
            'Refresh_Folder(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\")
            'fl = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_subsets.csv"

            'FileOpen(30, fl, OpenMode.Append)

            'MsgBox(sql)
            'BufrSection4 = ""
            'If Not AWS_Bufr_Section4(sql, BufrSection4, tt_aws) Then
            If Not AWS_Bufr_Section4(sql, BufrSection4, "bufr_crex_data") Then
                Log_Errors("Cant' Compute Bufr Data Section")  'MsgBox "Cant' Compute Bufr Data Section"
            Else
                ' Update Subset Number
                Bufr_Subst = Bufr_Subst + 1
                ' Append Data in Section 4 with the data computed from current subset
                BUFR_Subsets_Data = BUFR_Subsets_Data + BufrSection4
                ' Output substet binary data
                'MsgBox(BUFR_Subsets_Data)
                'Write(30, Date_Time, BufrSection4 & Chr(13) & Chr(10))
                PrintLine(30, Date_Time & "," & BufrSection4)
            End If
            dbconw.Close()
            ' ' Compose the complete AWS BUFR message
            ' Below code has been commented so that encoding is not done on individual stations but as a bulletin handle at the end of function process_input_data
            'If Not AWS_BUFR_Code(msg_header, yy, mm, dd, hh, min, ss, BufrSection4) Then Log_Errors("Can't Encode Data") ' MsgBox "Can't Encode Data"
            'Log_Errors(Len(BufrSection4))

        Catch Err As Exception
            dbconw.Close()
            Log_Errors(Err.Message & " at update_tbltemplate")

        End Try
    End Sub
    Sub Update_Time_Periods(conw As MySql.Data.MySqlClient.MySqlConnection, qry As MySql.Data.MySqlClient.MySqlCommand, hr As String)
        Dim Tprd As String
        Try
            If CLng(hr) Mod 6 = 0 Then
                Tprd = "-6"
            Else
                Tprd = "-3"
            End If
            Update_data(conw, qry, Tprd, "ww_TP") ' Time Period for Past and Present Weather
            Update_data(conw, qry, Tprd, "tempc_t")  ' Time Period for Past and Present Weather 2
            Update_data(conw, qry, "-6", "tR_TP1") ' Time Period for precipitation replication 1
            Update_data(conw, qry, "-1", "tR_TP2") ' Time Period for precipitation replication 2
            Update_data(conw, qry, "-24", "evap_TP") ' Time Period for evaporation
            Update_data(conw, qry, "-24", "SSS_TP") ' Time Period for sunshine replication 1
            Update_data(conw, qry, "-1", "SS_TP") ' Time Period for sunshine replication 2
            Update_data(conw, qry, "-12", "xt_TP") ' Time Period for maximum temperature
            Update_data(conw, qry, "0", "xt0_TP") ' Time Period for maximum temperature ending at nominal time of the report
            Update_data(conw, qry, "-12", "nt_TP") ' Time Period for minimum teperature
            Update_data(conw, qry, "0", "nt0_TP") ' Time Period for minimum teperature ending at nominal time of the report
            Update_data(conw, qry, "2", "w_TS") ' Time Significance for wind
            Update_data(conw, qry, "-10", "w_TP") ' Time Period for wind
            Update_data(conw, qry, "-10", "w1_TP") ' Time Period for wind gust
            Update_data(conw, qry, "-10", "w2_TP") ' Time Period for wind gust
            Update_data(conw, qry, "-1", "rad1_TP") ' Time Period for radiation replication 1
            Update_data(conw, qry, "-24", "rad2_TP") ' Time Period for radiation replication 2
        Catch ex As Exception
            MsgBox(ex.Message & " at Update_Time_Periods")
        End Try
    End Sub
    Sub Update_data(conw As MySql.Data.MySqlClient.MySqlConnection, qry As MySql.Data.MySqlClient.MySqlCommand, data As String, element As String)

        sql = "update bufr_crex_data set observation = '" & data & "' where Climsoft_Element='" & element & "';"
        ' Create the Command for executing query and set its properties
        'MsgBox(sql)
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conw)
            'Execute query
            qry.ExecuteNonQuery()
            'MsgBox(typ)
        Catch ex As Exception
            MsgBox(ex.Message & " at update_data")
        End Try
    End Sub
    Sub Update_observations(conw As MySql.Data.MySqlClient.MySqlConnection, qry As MySql.Data.MySqlClient.MySqlCommand, aws_struct As String)
        ' Update Template with AWS observation values
        sql = "UPDATE " & aws_struct & " INNER JOIN bufr_crex_data ON " & aws_struct & ".Bufr_Element = bufr_crex_data.Bufr_Element SET bufr_crex_data.Observation = " & aws_struct & ".obsv where " & aws_struct & ".Bufr_Element = bufr_crex_data.Bufr_Element;"
        'sql = "update aws_inam1 INNER JOIN bufr_crex_data ON aws_inam1.Bufr_Element = bufr_crex_data.Bufr_Element SET bufr_crex_data.Observation = aws_inam1.obsv where aws_inam1.Bufr_Element = bufr_crex_data.Bufr_Element;"
        qry.Connection = conw
        qry.CommandText = sql
        qry.ExecuteNonQuery()
    End Sub
    Sub Update_specificPeriod_Observations(conw As MySql.Data.MySqlClient.MySqlConnection, Date_Time As String, nat_id As String)

        Dim comm As New MySql.Data.MySqlClient.MySqlCommand
        Dim dap As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim drp As New DataSet

        Dim DTfrom, DTto As Date
        Dim obsv As Double
        Dim stPD, endPD As String

        Try
            ' Update Template with 24HR pricipitation total
            DTto = Date_Time

            ' Convert from GMT to local observation time
            DTto = DateAdd("h", Val(txtGMTDiff.Text), DTto)
            DTfrom = DateAdd("h", -24, DTto)

            ' Convert Dates to SQL struncture
            endPD = DateAndTime.Year(DTto) & "-" & Format(DateAndTime.Month(DTto), "00") & "-" & Format(DateAndTime.Day(DTto), "00") & " " & Format(DateAndTime.Hour(DTto), "00") & ":" & Format(DateAndTime.Minute(DTto), "00") & ":00"
            stPD = DateAndTime.Year(DTfrom) & "-" & Format(DateAndTime.Month(DTfrom), "00") & "-" & Format(DateAndTime.Day(DTfrom), "00") & " " & Format(DateAndTime.Hour(DTfrom), "00") & ":" & Format(DateAndTime.Minute(DTfrom), "00") & ":00"

            sql = "Select sum(obsValue) As Total from observationfinal where recordedFrom = '" & nat_id & "' and describedBy='892' and (obsdatetime between '" & stPD & "' and '" & endPD & "');"
            dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conw)
            ' Remove timeout requirement
            dap.SelectCommand.CommandTimeout = 0
            drp.Clear()
            dap.Fill(drp, "Tprecip")
            'Log_Errors(sql)
            obsv = 0
            If Not IsDBNull(drp.Tables("Tprecip").Rows(0).Item(0)) Then obsv = drp.Tables("Tprecip").Rows(0).Item(0)
            sql = "Update bufr_crex_data set observation = " & obsv & " where Bufr_Element = 013023;"
            comm = New MySql.Data.MySqlClient.MySqlCommand(sql, conw)
            'Execute query
            comm.ExecuteNonQuery()

            ' Update Template with Regional agreed period
            ' Cancel by setting value for first replication to ''
            sql = "update bufr_crex_data set observation = '' where Bufr_Element = 013011 and Climsoft_Element <> '174';"
            comm = New MySql.Data.MySqlClient.MySqlCommand(sql, conw)
            'Execute query
            comm.ExecuteNonQuery()

            ' Update Xtreme temperatures
            DTfrom = DateAdd("h", -12, DTto)
            stPD = SQL_Datetime(DTfrom)

            Select Case Int(Hour(Date_Time))
                Case 18 ' Update Tmax
                    sql = "Select Max(obsValue) As Tmax from observationfinal where recordedFrom = '" & nat_id & "' and describedBy='881' and (obsdatetime between '" & stPD & "' and '" & endPD & "');"
                    dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conw)
                    drp.Clear()
                    dap.Fill(drp, "Tmax")
                    obsv = 0
                    If Not IsDBNull(drp.Tables("Tmax").Rows(0).Item(0)) Then obsv = drp.Tables("Tmax").Rows(0).Item(0)
                    sql = "Update bufr_crex_data set observation = " & obsv & " where Bufr_Element = '012111';"
                    comm = New MySql.Data.MySqlClient.MySqlCommand(sql, conw)
                    comm.ExecuteNonQuery()
                    'Log_Errors(sql)
                Case 6 ' Update Tmin
                    sql = "Select Min(obsValue) As Tmin from observationfinal where recordedFrom = '" & nat_id & "' and describedBy='881' and (obsdatetime between '" & stPD & "' and '" & endPD & "');"
                    dap = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conw)
                    drp.Clear()
                    dap.Fill(drp, "Tmin")
                    obsv = 0
                    If Not IsDBNull(drp.Tables("Tmin").Rows(0).Item(0)) Then obsv = drp.Tables("Tmin").Rows(0).Item(0)
                    sql = "Update bufr_crex_data set observation = " & obsv & " where Bufr_Element = '012112';"
                    comm = New MySql.Data.MySqlClient.MySqlCommand(sql, conw)
                    comm.ExecuteNonQuery()

                    'Log_Errors(sql)
            End Select


        Catch ex As Exception
            MsgBox(ex.Message & " Update_Precip")
        End Try
    End Sub

    Function SQL_Datetime(dtt As String) As String
        Try
            Return DateAndTime.Year(dtt) & "-" & Format(DateAndTime.Month(dtt), "00") & "-" & Format(DateAndTime.Day(dtt), "00") & " " & Format(DateAndTime.Hour(dtt), "00") & ":" & Format(DateAndTime.Minute(dtt), "00") & ":00"
        Catch ex As Exception
            MsgBox(ex.Message)
            Return dtt
        End Try

    End Function

    Sub Initialize_Template(ttb As String)
        Dim sql1 As String
        Dim con1 As New MySql.Data.MySqlClient.MySqlConnection
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            con1.ConnectionString = frmLogin.txtusrpwd.Text
            con1.Open()

            'sql1 = "update " & ttb & " set observation = '', Bufr_Data = '', Crex_Data ='' where observation is not NULL and Bufr_Unit <> 'Code table';"
            sql1 = "update " & ttb & " set observation = '', Bufr_Data = '', Crex_Data ='' where observation is not NULL;" ' and Bufr_Unit <> 'Code table';"
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql1, con1)
            'Execute query
            qry.ExecuteNonQuery()
            con1.Close()

        Catch ex As Exception
            con1.Close()
            Log_Errors(ex.Message)
        End Try
    End Sub

    Sub Initialize_Cloud_Replications(dbconw As MySql.Data.MySqlClient.MySqlConnection, trs As DataSet, qry As MySql.Data.MySqlClient.MySqlCommand, RepType As String, descrp As Integer)
        Dim RecNo As Integer

        With trs

            For i = 0 To .Tables("bufr_crex_data").Rows.Count - 1
                If .Tables("bufr_crex_data").Rows(i).Item("Climsoft_Element") = RepType Then
                    RecNo = .Tables("bufr_crex_data").Rows(i).Item("Nos")
                    For j = RecNo To (RecNo + descrp * 4)
                        If j = RecNo Then
                            sql = "update bufr_crex_data set Observation ='0', selected = '1' where Nos = '" & j & "';"
                        Else
                            sql = "update bufr_crex_data set selected = '0' where Nos = '" & j & "';"
                        End If
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, dbconw)
                        qry.ExecuteNonQuery()
                    Next
                    Exit For
                End If
            Next
        End With

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

    Function Initialize_CodeFlag(cfrs As DataSet, tt_aws As String, dbconw As MySql.Data.MySqlClient.MySqlConnection) As String
        On Error GoTo Err

        Dim bitstream As String

        Dim flgrs As New DataSet
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        flgrs = GetDataSet("flagtable", "SELECT * FROM flagtable")
        Initialize_CodeFlag = ""
        cmd.Connection = dbconw

        ' Initialize with missing values
        'With cfrs.Tables(txtTemplate.Text)
        With cfrs.Tables(tt_aws)
            For i = 0 To .Rows.Count - 1

                bitstream = ""
                If .Rows(i).Item("Bufr_Unit") = "Flag table" Then
                    bitstream = ""
                    For j = 1 To CInt(.Rows(i).Item("Bufr_DataWidth_Bits"))
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
                    sql = "Update " & tt_aws & " SET Bufr_Data = " & bitstream & " where Nos = " & i + 1 & ";"
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
        ' Set to unlimited timeout period
        daws.SelectCommand.CommandTimeout = 0

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
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & obsvs & "' WHERE Bufr_Element = '007061';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()
                End If
            Next
        End With

        Exit Sub
Err:
        'MsgBox("Soil Replication")
        'MsgBox(sql)
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
                    RecNo = .Rows(i - 1).Item("Nos") ' Update Maximum Wind Gust Direction Time displacement
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & Tperiod(counts) & "' WHERE Nos = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    RecNo = .Rows(i).Item("Nos") ' Update Maximum Wind Gust Direction
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & MxGustD(counts) & "' WHERE Nos = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    RecNo = .Rows(i + 1).Item("Nos") ' Update Maximum Wind Gust Speed
                    sql = "UPDATE " & tt_aws & " SET Observation = '" & MxGustS(counts) & "' WHERE Nos = '" & RecNo & "';"
                    cmd.CommandText = sql
                    cmd.ExecuteNonQuery()

                    counts = counts + 1

                    ' Initialize Time Period with -10 Minutes
                    If counts = 2 Then
                        RecNo = .Rows(i + 2).Item("Nos")
                        sql = "UPDATE " & tt_aws & " SET Observation = '-10' WHERE Nos = '" & RecNo & "';"
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
    Sub TDCF_Encode(dbconw As MySql.Data.MySqlClient.MySqlConnection, qry As MySql.Data.MySqlClient.MySqlCommand, trs As DataSet, tt_aws As String)

        Dim bufrdata As String
        Dim sql As String
        Dim RecNo As String

        sql = "SELECT * FROM " & tt_aws & " ORDER BY Nos"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconw)
        trs.Clear()
        da.Fill(trs, tt_aws)
        qry.Connection = dbconn
        'Log_Errors(1)
        Try

            With trs.Tables(tt_aws)
                For i = 0 To .Rows.Count - 1
                    RecNo = .Rows(i).Item("Nos")
                    'Log_Errors(RecNo & " - " & i & " - " & .Rows(i).Item("Observation"))
                    If Not IsDBNull(.Rows(i).Item("Observation")) Then
                        If Len(.Rows(i).Item("Observation")) > 0 Then
                            bufrdata = Bufr_Data(.Rows(i).Item("Bufr_Unit"), .Rows(i).Item("Bufr_Scale"), .Rows(i).Item("Bufr_RefValue"), .Rows(i).Item("Bufr_DataWidth_Bits"), .Rows(i).Item("Observation"), .Rows(i).Item("Bufr_Data"))
                            'Log_Errors(RecNo & "-" & .Rows(i).Item("Observation") & "=" & bufrdata)
                            sql = "UPDATE " & tt_aws & " SET Bufr_Data = '" & bufrdata & "' WHERE Nos = '" & RecNo & "';"
                            qry.CommandText = sql
                            qry.ExecuteNonQuery()
                        End If
                    End If
                Next
            End With
            'Log_Errors(2)
        Catch Err As Exception
            Log_Errors(Err.Message)
        End Try
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

        ' Add leading zeroes to short data strings
        CCITT_Binary = ""
        binstr = ""
        If Len(dat) < DataWidth / 8 Then
            For kount = 1 To DataWidth - Len(dat) * 8
                binstr = binstr & "0"
            Next kount
        Else
            dat = Strings.Left(dat, DataWidth / 8)
        End If

        ' Loop the entire data string
        'Log_Errors(dat)
        For kount = 1 To Len(dat)

            With rs0.Tables("ccitt")

                For i = 0 To .Rows.Count - 1
                    dat1 = Mid(dat, kount, 1)
                    If dat1 = " " Then dat1 = "SP"
                    If dat1 = .Rows(i).Item("Characters") Then
                        chr1 = .Rows(i).Item("MostSignificant")
                        chr2 = .Rows(i).Item("LeastSignificant")
                        binstr = binstr & Decimal_Binary(Val(chr1), 4) & Decimal_Binary(Val(chr2), 4)
                        'Log_Errors(dat1 & " " & chr1 & "-" & chr2 & " " & binstr)
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
                'Log_Errors(i & "," & .Rows(i).Item("Bufr_Data") & "," & .Rows(i).Item("Bufr_DataWidth_Bits"))
                'Log_Errors(i & "," & .Rows(i).Item("Element_Name") & "," & .Rows(i).Item("Climsoft_Element") & "," & .Rows(i).Item("Bufr_Data"))
                bufr_subset = bufr_subset & .Rows(i).Item("Bufr_Data")
            Next
        End With

        binary_data = bufr_subset 'binary_data & bufr_subset
        'Log_Errors(Len(binary_data))
        Exit Function
Err:
        Log_Errors(Err.Description)
        AWS_Bufr_Section4 = False

    End Function

    Function FTP_Delete_InputFile(ftpfile As String) As Boolean
        FTP_Delete_InputFile = False
        On Error GoTo Err
        Dim local_folder, backup_folder As String

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
        'MsgBox(usr & " " & pwd)
        FileClose(1) ' Close the file if ever it exist

        ' Define the file and path
        local_folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data"
        backup_folder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\backup"

        Drive1 = System.IO.Path.GetPathRoot(Application.StartupPath)
        ftpscript = local_folder & "\ftp_file_delete.txt"
        FileOpen(1, ftpscript, OpenMode.Output)

        ' Create FTP Script file
        Print(1, "open " & ftp_host & Chr(13) & Chr(10))
        Print(1, usr & Chr(13) & Chr(10))
        Print(1, pwd & Chr(13) & Chr(10))
        Print(1, "cd " & flder & Chr(13) & Chr(10))
        'Print(1, "mget *.*" & Chr(13) & Chr(10))
        Print(1, "mdel *.*" & Chr(13) & Chr(10))
        'Print(1, "del" & " " & ftpfile & Chr(13) & Chr(10))
        Print(1, "bye" & Chr(13) & Chr(10))

        FileClose(1)

        ' Create batch file to execute FTP script

        ftpbatch = local_folder & "\ftp_file_delete.bat"
        FileOpen(1, ftpbatch, OpenMode.Output)

        Print(1, "echo off" & Chr(13) & Chr(10))
        Print(1, Drive1 & Chr(13) & Chr(10))
        Print(1, "CD " & local_folder & Chr(13) & Chr(10))
        'Print(1, "CD " & backup_folder & Chr(13) & Chr(10))
        Print(1, "ftp -i -s:ftp_file_delete.txt" & Chr(13) & Chr(10))
        Print(1, "echo on" & Chr(13) & Chr(10))
        Print(1, "EXIT" & Chr(13) & Chr(10))
        FileClose(1)

        ' Execute the batch file to delete the input file
        Shell(ftpbatch, vbMinimizedNoFocus)
        Interaction.Shell(ftpbatch, vbMinimizedNoFocus)

        FTP_Delete_InputFile = True

        Exit Function
Err:
        Log_Errors(" FTP " & ftpmethod & " error - " & Err.Description)
    End Function

    Function AWS_BUFR_Code(message_header As String, yy As String, mm As String, dd As String, hh As String, min As String, ss As String, binary_data As String) As Boolean

        ' Set message header according to the hour category 
        If Val(hh) Mod 6 = 0 Then
            Mid(message_header, 3, 1) = "M"
        ElseIf Val(hh) Mod 6 = 3 Then
            Mid(message_header, 3, 1) = "I"
        Else
            Mid(message_header, 3, 1) = "N"
        End If

        'msg_header = MsgHeaber_ByHour(hh)

        'Log_Errors(message_header & " " & hh)

        AWS_BUFR_Code = False
        'Log_Errors(binary_data)
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
        section1 = section1 & Decimal_Binary(Val(txtInternationalSubcategory.Text), 8)
        ' Octet 13. Local data sub-category (defined locally by ADP centers)
        section1 = section1 & Decimal_Binary(Val(txtLocalSubcategory.Text), 8)
        ' Octet 14. Version number of master table currently (Currently 12 for WMO BUFR FM 94 BUFR tables)
        section1 = section1 & Decimal_Binary(Val(txtMastertableVersion.Text), 8)
        ' Octet 15. Version number of local tables used to augment master table in use
        section1 = section1 & Decimal_Binary(Val(txtLocaltableVersion.Text), 8)
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
        'Log_Errors("7777 = " & section5)
        ' Compute the BUFR message less section 0
        Dim BUFR_Message As String
        BUFR_Message = section1 & section2 & section3 & section4 & section5

        ' Encode Section 0 - Indicator Section
        section0 = ""
        ' Octet 1 - 4.  "BUFR" (coded according to CCITT International Alphabet No. 5)
        section0 = section0 & CCITT_Binary(rs1, "BUFR", 32)
        'Log_Errors("BUFR = " & section0)
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
        'Log_Errors(message_header)
        comms_header = CCITT_Binary(rs1, message_header, Len(message_header) * 8)
        'Log_Errors(comms_header)
        'Case where Format Identifier 00 is used
        BUFR_Message = section0 & section1 & section2 & section3 & section4 & section5
        Bufr_Message_With_Controls = SOH & CR & CR & LF & nnn & CR & CR & LF & comms_header & CR & CR & LF & BUFR_Message & CR & CR & LF & ETX

        message_length = Format(Str(Len(Bufr_Message_With_Controls) / 8), "00000000")
        'Log_Errors("Old " & message_length)
        'mm = String.Format("{0:00}", DateAndTime.Month(Now()))
        message_length = String.Format("{0:00000000}", Strings.Len(Bufr_Message_With_Controls) / 8)
        'Log_Errors("New " & message_length)
        BUFR_Message = CCITT_Binary(rs1, message_length, 64) & Format_Id0 & Bufr_Message_With_Controls & dummy_msg
        'Log_Errors(BUFR_Message)


        'Delete the file to get rid of the previous data
        'If fso.FileExists(fso.GetParentFolderName(App.Path) & "\data\bufr.txt") Then fso.DeleteFile(fso.GetParentFolderName(App.Path) & "\data\bufr.txt")
        brfile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr.txt"

        If File.Exists(brfile) Then File.Delete(brfile)

        FileOpen(2, brfile, OpenMode.Output)

        'Open fso.GetParentFolderName(App.Path) & "\data\bufr.txt" For Output As #2

        'Print #2, BUFR_Message 
        PrintLine(2, BUFR_Message) ' Put the BUFR binary digit message into a text file
        FileClose(2)
        FileClose(1)
        'Close #1
        'Close #2

        'myString = myString.PadLeft(desiredLength, "0"c)
        'msg_file = Right(msg_header, 4) & Mid(message_header, 13, 2) & Mid(message_header, 15, 2) '& Format(min, "00") 'message_header
        msg_file = Strings.Right(msg_header, 4) & dy & hr & min ' Format(dy, "00") & Format(hr, "00")


        msg_file = Strings.Right(msg_header, 4) & dy.PadLeft(2, "0"c) & hr.PadLeft(2, "0"c) & min.PadLeft(2, "0"c)
        'Construct and open Bufr output text file based on the message header

        Dim fserial As Long
        Dim AWS_BUFR_File, BUFR_octet_File As String
        Dim ValidFile As Boolean
        fserial = 0
        ValidFile = False

        'AWS_BUFR_File = System.IO.Path.GetFullPath(Application.StartupPath & "\data\" & msg_file & Format(1, "0000") & ".f")
        'AWS_BUFR_File = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & msg_file & ".f"
        AWS_BUFR_File = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & msg_file & ".tmp"

        BUFR_octet_File = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\bufr_octets.txt"

        'Open fso.GetParentFolderName(App.Path) & "\data\bufr_octets.txt" For Output As #1
        FileOpen(1, BUFR_octet_File, OpenMode.Output)

        'WriteBytes(AWS_BUFR_File, BUFR_Message)
        If File.Exists(AWS_BUFR_File) Then File.Delete(AWS_BUFR_File)

        'Open AWS_BUFR_File For Binary As #2
        FileOpen(2, AWS_BUFR_File, OpenMode.Binary)

        'Output BUFR data into binary and text file
        Dim byt As Long
        Dim kounter As Long

        'Dim writeStream As FileStream
        'writeStream = New FileStream(AWS_BUFR_File, FileMode.Create)
        'Dim writeBinay As New BinaryWriter(writeStream)
        'writeBinay.Write(89)



        byt = 0
        kounter = 1
        ''MsgBox(kount)
        For i = 1 To Len(BUFR_Message) Step 8
            If Binary_Decimal(Strings.Mid(BUFR_Message, i, 8), byt) Then
                FilePut(2, byt, kounter)
            Else
                Log_Errors("Coding Error")
                'Exit Function
            End If
            'FilePut(2, Binary_Decimal(Strings.Mid(BUFR_Message, i, 8)), kounter)
            PrintLine(1, kounter & "," & Strings.Mid(BUFR_Message, i, 8))

            'Log_Errors(byt)

            kounter = kounter + 1

        Next
        'MsgBox(hh & ":" & min)
        'writeBinay.Close()

        FileClose(1)
        FileClose(2)

        'MsgBox(BUFR_Message)

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

        FileClose(1)

        'MsgBox msg_file
        Dim bufr_filename As String
        Process_Status("Transmitting message")

        bufr_filename = (System.IO.Path.GetFileName(AWS_BUFR_File)) ' Get the filename without path
        'Log_Errors(bufr_filename)

        'If Not FTP_Call(bufr_filename, "put") Then Exit Function

        If Not FTP_Put(bufr_filename) Then Exit Function

        AWS_BUFR_Code = True
        'WriteBytes(AWS_BUFR_File, BUFR_Message)
        Exit Function
Err:
        If Err.Description = "" Then
            Log_Errors("BUFR Coding Error")
            '  list_errors.AddItem txttime & "  " & "BUFR Coding Error"
            '  MsgBox "BUFR Coding Error"
        Else
            Log_Errors(Err.Number & ": " & Err.Description & " at AWS_BUFR_Code")
            '  list_errors.AddItem txttime & "  " & Err.description
            '  MsgBox Err.description
        End If
        FileClose(1)
        FileClose(2)
        'writeBinay.Close()
    End Function

    Sub WriteBytes(fl As String, dat As String)

        'Dim myFileStream As FileStream
        'Dim bteWrite() As Byte
        'Dim intByte As Integer
        'Dim lngLoop As Long

        'Try
        '    'intByte = Encoding.ASCII.GetBytes("asdf").Length
        '    'ReDim bteWrite(intByte)
        '    'bteWrite = Encoding.ASCII.GetBytes("asdf")
        '    'myFileStream = File.OpenWrite("test.txt")
        '    myFileStream = File.OpenWrite("test.txt")
        '    'For lngLoop = 0 To intByte - 1
        '    'For i = 0 To 7
        '    myFileStream.WriteByte("1111111")
        '    'Next i
        '    'Next

        '    myFileStream.Close()
        'Catch ex As IOException
        '    Console.WriteLine(ex.Message)
        'End Try
        Dim byt As Long
        Const fileName As String = "Test#@@#.dat"

        ' Create random data to write to the file.
        Dim dataArray(8) As Byte
        'Dim dataArray(4) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(dataArray)
        'byt = ""
        'For i = 0 To 7
        '    byt = byt & dataArray(i)

        'MsgBox(byt)

        Dim fileStream As FileStream = _
            New FileStream(fileName, FileMode.Create)
        Try
            Dim kounts As Long
            byt = ""
            For kounts = 1 To Len(dat) Step 8
                If Binary_Decimal(Strings.Mid(dat, kounts, 8), byt) Then

                    If IsNumeric(byt) Then fileStream.WriteByte(byt)
                End If
            Next
        Catch ex As Exception
            MsgBox(byt)
        End Try
        'Try

        '    ' Write the data to the file, byte by byte.
        '    For i As Integer = 0 To dataArray.Length - 1
        '        fileStream.WriteByte(dataArray(i))
        '    Next i

        '    ' Set the stream position to the beginning of the stream.
        '    fileStream.Seek(0, SeekOrigin.Begin)

        '    ' Read and verify the data.
        '    For i As Integer = 0 To _
        '        CType(fileStream.Length, Integer) - 1

        '        If dataArray(i) <> fileStream.ReadByte() Then
        '            Console.WriteLine("Error writing data.")
        '            Return
        '        End If
        '    Next i
        '    Console.WriteLine("The data was written to {0} " & _
        '        "and verified.", fileStream.Name)
        'Finally
        '    fileStream.Close()
        'End Try

        fileStream.Close()

    End Sub


    Function Binary_Decimal(BinN As String, ByRef BinD As Long) As Boolean
        'Function Binary_Decimal(BinN As String) As Long

        Dim siz As Integer
        Dim dgt As String
        Dim posval As Integer
        Dim kount As Integer
        'Dim BinD As Long
        Binary_Decimal = True

        Try
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
        Catch ex As Exception
            Log_Errors(ex.HResult & " " & ex.Message)
            Binary_Decimal = False
        End Try
    End Function

    Function Next_Encoding_Time() As Boolean
        Next_Encoding_Time = True
        On Error GoTo Err
        Dim mnt, ss, EnInterval As Integer

        txtNxtProcess.Text = DateAdd("n", CLng(txtInterval.Text), Now())

        'txtNxtProcess.Text = Ltime.Text
        'txtNxtProcess.Text = DateAdd("h", 1, txtNxtProcess.Text)

        ' Set next encoding time with zero minute and zero second
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
            Case "AWS Real Time"
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "awsrealtimeoperations.htm")
        End Select

    End Sub

    Sub FTP_Protocal()
        Dim oScript, oFileSys, objFSO, fileSearchObj, fileNameList, fileName, fileNameArray
        Dim tempFileName As String
        Try

            '' set the FTP path and username/password fields

            Dim ftp_address As String = "ftp.XYZ.com" '---> ftp site address
            Dim ftp_username As String = "username" '---> user name 
            Dim ftp_password As String = "passwd" '---> password

            fileSearchObj = CreateObject("Scripting.FileSystemObject")
            ' Get all the files down loded to C:\ftpDownload folder
            fileNameArray = fileSearchObj.GetFolder("C:\ftpDownload\")
            fileNameList = fileNameArray.files

            For Each fileName In fileNameList
                tempFileName = fileName.name

                '1. Crate the temperory .ftp file (ftpCommand.ftp) which contain the FTP code 
                '2. Write the code for copying the file from FTP to Local folder
                '3. Write the code to delete the file from FTP after copy
                '4. Execute the file through command prompt

                Dim objTextFile
                Dim strFTPFileName As String = ""
                '-----------------------------------------------------------
                ' Step 1
                '-----------------------------------------------------------
                ' this file will be saved on the root folder (bydefault)
                strFTPFileName = "C:\ftpCommand.ftp"
                ' create the temporary on root folder 
                objTextFile = objFSO.CreateTextFile(strFTPFileName, True)

                '-----------------------------------------------------------
                ' Step 2
                '-----------------------------------------------------------
                ' write the ftp command line code to fetch files in the file test.ftp
                objTextFile.WriteLine("open " & ftp_address) '-------> open FTP site/location
                objTextFile.WriteLine(ftp_username) '--------------> ftp user name
                objTextFile.WriteLine(ftp_password) '--------------> ftp user password
                objTextFile.WriteLine("cd tempFolder") '-----------> cd tempFolder 
                ' tempFolder is the source folder on FTP site from where application will down load files
                ' Example- ftp:\\ftp.XYZ.com\tempFolder 
                objTextFile.WriteLine("lcd C:\ftpDownload") '--------> This is the working directory

                '-----------------------------------------------------------
                ' Step 3
                '-----------------------------------------------------------
                objTextFile.WriteLine("delete " & tempFileName) '----> delete 'filename' // to delete the same copied files from the FTP server
                objTextFile.WriteLine("y") '--------------> y //propmt message 'yes' to commit the copy operation
                objTextFile.WriteLine("bye") '--------------> bye //ftp command to come out of the ftp command promt

                ' close the stream for creating the new ftp file
                objTextFile.Close()
                objTextFile = Nothing

                '-----------------------------------------------------------
                ' Step 4
                '----------------------------------------------------------- ' create the FTP command promt syntax to execute the files
                Dim strCMD As String
                strCMD = "ftp.exe -i -s: C:\ftpCommand.ftp"
                ' create the temperory file to store the output generated after executing the FTP command 
                Dim strTempFile As String
                strTempFile = "C:\ftpOutput.txt"
                ' call the command promt control to execute the delete operation
                Call oScript.Run("cmd.exe /c " & strCMD & " > " & strTempFile, 0, True)

            Next

        Catch ex As Exception
            ' Some thing goes wrong
        End Try

    End Sub

    Private Sub txtSiteName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtSiteName.SelectedIndexChanged

    End Sub

    Private Sub chkPrefix_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrefix.CheckedChanged

        If chkPrefix.Checked = True Then
            txtfilePrefix.Visible = True
            'If Len(txtfilePrefix.Text) = 0 Then MsgBox("Enter prefix value for the input files")
        Else
            txtfilePrefix.Visible = False
        End If
    End Sub

    Private Sub cmdBstAddNew_Click(sender As Object, e As EventArgs) Handles cmdBstAddNew.Click

        txtBaseStationAddress.Text = ""
        txtBaseStationFolder.Text = ""
        txtBasestationFTPMode.Text = ""
        txtBaseStationUser.Text = ""
        txtbaseStationPW.Text = ""
    End Sub


    Private Sub txtSiteID_Click(sender As Object, e As EventArgs) Handles txtSiteID.Click
        'MsgBox(ds.Tables("aws_sites").Rows(num).Item("SiteID"))

        'For i = 0 To ds.Tables("aws_sites").Rows.Count - 1
        '    If txtSiteID.Text = ds.Tables("aws_sites").Rows(i).Item("SiteID") Then
        '        PopulateForm("sites", txtSitesNavigator, i)
        '    End If
        'Next
    End Sub

    Private Sub txtSiteID_TextChanged(sender As Object, e As EventArgs) Handles txtSiteID.TextChanged
        For i = 0 To ds.Tables("aws_sites").Rows.Count - 1
            If txtSiteID.Text = ds.Tables("aws_sites").Rows(i).Item("SiteID") Then
                PopulateForm("sites", txtSitesNavigator, i)
                'rec = i - 1
            End If
        Next

    End Sub

    Private Sub txtSiteName_TextChanged(sender As Object, e As EventArgs) Handles txtSiteName.TextChanged
        For i = 0 To ds.Tables("aws_sites").Rows.Count - 1
            If txtSiteName.Text = ds.Tables("aws_sites").Rows(i).Item("SiteName") Then
                PopulateForm("sites", txtSitesNavigator, i)
                'rec = i - 1
            End If
        Next

    End Sub



    'Private Sub txtSiteID_GotFocus(sender As Object, e As EventArgs) Handles txtSiteID.GotFocus

    '    stn1 = txtSiteID.Text
    'End Sub

    Function Get_DateStamp(AWSsite As String, dattable As DataTable, rw As Long) As String

        Dim dt, Date_s, Time_s, yyyy, mm, dd, nn, hh, ss As String

        Dim dbstr As New MySql.Data.MySqlClient.MySqlConnection
        Dim dastr As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsstr As New DataSet
        Dim sqlstr As String

        Try
            dbstr.ConnectionString = frmLogin.txtusrpwd.Text
            dbstr.Open()

            sqlstr = "SELECT * FROM " & AWSsite

            dastr = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlstr, dbstr)
            ' Remove timeout requirement
            dastr.SelectCommand.CommandTimeout = 0

            dsstr.Clear()
            dastr.Fill(dsstr, "struct")
            Date_s = ""
            Time_s = ""
            yyyy = ""
            mm = ""
            dd = ""
            hh = ""
            nn = ""

            With dsstr.Tables("struct")
                For i = 0 To .Rows.Count - 1
                    If IsDBNull(dattable.Rows(rw).Item(i)) Then Continue For
                    dt = dattable.Rows(rw).Item(i)
                    'Log_Errors(.Rows(i).Item("Element_abbreviation") & " " & dt)

                    Select Case .Rows(i).Item("Element_abbreviation")
                        Case "Date/time"
                            Return dt
                        Case "date/time"
                            Return dt
                        Case "yyyymmddhhmm"
                            Return DateSerial(Strings.Left(dt, 4), Strings.Mid(dt, 5, 2), Strings.Mid(dt, 7, 2)) & " " & TimeSerial(Strings.Mid(dt, 9, 2), Strings.Mid(dt, 11, 2), "00")
                        Case "ddmmyyyyhhmm"
                            Return DateSerial(Strings.Mid(dt, 5, 4), Strings.Mid(dt, 3, 2), Strings.Left(dt, 2)) & " " & TimeSerial(Strings.Mid(dt, 9, 2), Strings.Mid(dt, 11, 2), "00")
                        Case "Date"
                            Date_s = dt
                        Case "Time"
                            Time_s = dt
                        Case "yyyy"
                            yyyy = dt
                        Case "mm"
                            mm = dt
                        Case "dd"
                            dd = dt
                        Case "hh"
                            hh = dt
                        Case "nn"
                            nn = dt
                    End Select
                Next

                If IsDate(Date_s) And Time_s <> "" Then
                    Return Date_s & " " & Time_s
                End If

                If IsDate(DateSerial(yyyy, mm, dd)) And hh <> "" And nn <> "" Then
                    Return DateSerial(yyyy, mm, dd) & " " & TimeSerial(hh, nn, "00")
                End If
            End With

            dbstr.Close()
            Return ""
        Catch ex As Exception
            'Log_Errors(ex.Message & " at Get_DateStamp")
            dbstr.Close()
            Return ""
        End Try


    End Function

    Private Sub cmdNew_Click(sender As Object, e As EventArgs) Handles cmdNew.Click
        Dim ctl As Control

        txtTemplate.Text = ""
        txtMsgHeader.Text = ""
        chkOptionalSection.Checked = False
        For Each ctl In Me.grpIndicators.Controls
            If Strings.Left(ctl.Name, 3) = "txt" Then ctl.Text = ""
        Next
        txtTemplate.Select()
    End Sub

    Private Sub cmdSaves_Click(sender As Object, e As EventArgs) Handles cmdSaves.Click
        Dim sconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim optsection As Integer

        Try
            'dbConnectionString = frmLogin.txtusrpwd.Text
            sconn.ConnectionString = dbConnectionString
            sconn.Open()

            ' set value for the optional section
            If chkOptionalSection.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "INSERT IGNORE INTO bufr_indicators (Tmplate,Msg_Header,BUFR_Edition,Originating_Centre,Originating_SubCentre,Update_Sequence,Optional_Section,Data_Category,Intenational_Data_SubCategory,Local_Data_SubCategory,Master_table,Local_Table) VALUES('" & txtTemplate.Text & "','" & txtMsgHeader.Text & "','" & txtBufrEdition.Text & "','" & txtOriginatingCentre.Text & "','" & txtOriginatingSubcentre.Text & "','" & txtUpdateSequence.Text & "','" & optsection & "','" & txtDataCategory.Text & "','" & txtInternationalSubcategory.Text & "','" & txtLocalSubcategory.Text & "','" & txtMastertableVersion.Text & "','" & txtLocaltableVersion.Text & "');"

            ' Create the Command for executing query and set its properties
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, sconn)

            'Execute query
            cmd.ExecuteNonQuery()
            sconn.Close()
            MsgBox("New Record added")
        Catch ex As Exception
            MsgBox(ex.Message)
            sconn.Close()
        End Try
    End Sub

    Private Sub cmdDefault_Click(sender As Object, e As EventArgs) Handles cmdDefault.Click
        Dim sconn As New MySql.Data.MySqlClient.MySqlConnection

        Try

            sconn.ConnectionString = dbConnectionString
            sconn.Open()

            ' Select default Template
            sql = "Update bufr_indicators set defaultTemplate = 1 where Tmplate= '" & txtTemplate.Text & "';"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, sconn)
            cmd.ExecuteNonQuery()

            ' Deselect default Template from any other
            sql = "Update bufr_indicators set defaultTemplate = 0 where Tmplate != '" & txtTemplate.Text & "';"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, sconn)
            cmd.ExecuteNonQuery()

            sconn.Close()
            MsgBox(txtTemplate.Text & " Set to default")
        Catch ex As Exception
            MsgBox(ex.Message)
            sconn.Close()
        End Try
    End Sub

    Private Sub cmdUpadate_Click(sender As Object, e As EventArgs) Handles cmdUpadate.Click
        Dim sconn As New MySql.Data.MySqlClient.MySqlConnection
        Dim optsection As Integer

        Try

            sconn.ConnectionString = dbConnectionString
            sconn.Open()

            ' set value for the optional section
            If chkOptionalSection.Checked() = True Then
                optsection = 1
            Else
                optsection = 0
            End If

            sql = "Update bufr_indicators set Msg_Header= '" & txtMsgHeader.Text & "',BUFR_Edition= '" & txtBufrEdition.Text & "',Originating_Centre= '" & txtOriginatingCentre.Text & "',Originating_SubCentre= '" & txtOriginatingSubcentre.Text & "',Update_Sequence= '" & txtUpdateSequence.Text & "',Optional_Section= '" & optsection & "',Data_Category= '" & txtDataCategory.Text & "',Intenational_Data_SubCategory= '" & txtInternationalSubcategory.Text & "',Local_Data_SubCategory= '" & txtLocalSubcategory.Text & "',Master_table= '" & txtMastertableVersion.Text & "',Local_Table= '" & txtLocaltableVersion.Text &
                "' where tmplate= '" & txtTemplate.Text & "';"

            ' Create the Command for executing query and set its properties
            cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, sconn)

            'Execute query
            cmd.ExecuteNonQuery()
            sconn.Close()
            MsgBox("Record updated")
        Catch ex As Exception
            MsgBox(ex.Message)
            sconn.Close()
        End Try
    End Sub

    Sub Get_Datetime(AWSsite As String, ByRef dtCol As Integer, ByRef dtFmt As String)

        Dim dbstr As New MySql.Data.MySqlClient.MySqlConnection
        Dim dastr As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsstr As New DataSet
        Dim sqlstr As String

        Try
            dbstr.ConnectionString = frmLogin.txtusrpwd.Text
            dbstr.Open()

            sqlstr = "SELECT * FROM " & AWSsite

            dastr = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlstr, dbstr)
            ' Remove timeout requirement
            dastr.SelectCommand.CommandTimeout = 0

            dsstr.Clear()
            dastr.Fill(dsstr, "struct")

            With dsstr.Tables("struct")
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("Element_abbreviation") = "Date/time" Then
                        dtCol = i
                        dtFmt = .Rows(i).Item("Element_Name")
                        Exit For
                    End If
                Next
            End With
            dbstr.Close()

        Catch ex As Exception
            Log_Errors(ex.Message & " at Get_Datetime")
            dbstr.Close()
        End Try

    End Sub

    Private Sub cmdMssAddNew_Click_1(sender As Object, e As EventArgs) Handles cmdMssAddNew.Click
        txtMSSAddress.Text = ""
        txtMSSFolder.Text = ""
        txtmssFTPMode.Text = ""
        txtmssUser.Text = ""
        txtMSSPW.Text = ""
    End Sub

    Function Format_Datetime(dt As String, fmt As String) As String
        Dim ty, tm, td, tH, tmi As String

        Try
            Select Case fmt
                Case "yyyyMMddHHmm"
                    '201708110830
                    ty = Strings.Left(dt, 4)
                    tm = Strings.Mid(dt, 5, 2)
                    td = Strings.Mid(dt, 7, 2)
                    tH = Strings.Mid(dt, 9, 2)
                    tmi = Strings.Mid(dt, 11, 2)
                    Format_Datetime = DateSerial(ty, tm, td) & " " & TimeSerial(tH, tmi, "00")
                Case Else
                    Return dt
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
            Return dt
        End Try
    End Function

    Private Sub txtTemplate_Click(sender As Object, e As EventArgs) Handles txtTemplate.Click
        load_Indicators(txtTemplate.Text)
    End Sub

    Function Compute_Prefix(Prfx As String) As String
        Dim yyyy, mm, dd As String

        Try
            dd = String.Format("{0:00}", DateAndTime.Day(Now()))
            mm = String.Format("{0:00}", DateAndTime.Month(Now()))
            yyyy = DateAndTime.Year(Now())

            ' Compute Time bound prefixes
            Select Case Prfx
                Case "yyyymmdd"
                    Return yyyy & mm & dd
                Case "yyyy-mm-dd"
                    Return yyyy & "-" & mm & "-" & dd
                Case "ddmmyyyy"
                    Return dd & mm & yyyy
                Case "dd-mm-yyyy"
                    Return dd & "-" & mm & "-" & yyyy
                Case "yyyymm"
                    Return yyyy & mm
                Case "ddmm"
                    Return dd & mm
                Case "yyyy-mm"
                    Return yyyy & "-" & mm
                Case "mm-yyyy"
                    Return mm & "-" & yyyy
                Case Else ' Non Time bound
                    Return Prfx
            End Select

        Catch ex As Exception
            Log_Errors(ex.Message)
            Return Prfx
        End Try
    End Function
    Function MsgHeaber_ByHour(hh) As String
        Dim hr As Integer
        Dim hdr As String
        hr = Val(hh)
        hdr = txtMsgHeader.Text
        Try
            Select Case hr Mod 6
                Case 0
                    Mid(hdr, 3, 1) = "M"
                Case 3
                    Mid(hdr, 3, 1) = "I"
                Case Else
                    Mid(hdr, 3, 1) = "N"
            End Select
            'Log_Errors(hdr & " " & hh & "-" & hr Mod 6)
            MsgHeaber_ByHour = hdr
        Catch ex As Exception
            MsgBox(ex.Message)
            Return hdr
        End Try
    End Function

    'Function FTP_FilePath(flpath As String) As String
    '    'Dim fchar As String
    '    FTP_FilePath = Strings.Replace(flpath, "\", "/")
    '    'FTP_FilePath = ""
    '    'For i = 1 To Len(flpath)
    '    '    fchar = Strings.Mid(flpath, i, 1)
    '    '    If fchar = "\" Then fchar = "/"
    '    '    FTP_FilePath = FTP_FilePath & fchar
    '    'Next
    'End Function

End Class

Public Class FTP

    Dim ftpserver As FtpStatusCode

End Class