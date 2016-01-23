' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
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

Imports System.Windows.Forms

Public Class frmDBUtilities
    'Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    'Dim ds As New DataSet
    'Dim sql As String
    'Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    'Dim MyConnectionString As String
    'Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
    'Public Curr_db As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ToolStripContainer1_TopToolStripPanel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles cmbDb.Click

    End Sub

    Private Sub formDbUtilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        '    Dim col As String
        '    Dim itm As New ListViewItem

        '    ListViewDbUtil.Visible = True
        '    cmdUpload.Visible = True
        '    conn.Close()
        '    ListViewDbUtil.Clear()
        '    ListViewDbUtil.Columns.Clear()

        '    'ListViewDbUtil.Columns.Add("Form Name", 100, HorizontalAlignment.Left)
        '    ListViewDbUtil.Columns.Add("Select or Check Form to upload", 600, HorizontalAlignment.Left)
        '    Try
        '        MyConnectionString = frmLogin.txtusrpwd.Text
        '        conn.ConnectionString = MyConnectionString
        '        conn.Open()

        '        sql = "SELECT selected,form_name, description FROM data_forms;"
        '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '        ds.Clear()
        '        da.Fill(ds, "data_forms")

        '        For i = 0 To ds.Tables("data_forms").Rows.Count - 1

        '            If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then
        '                'col(0) = ds.Tables("data_forms").Rows(i).Item(1)
        '                col = ds.Tables("data_forms").Rows(i).Item(2)
        '                itm = New ListViewItem(col)
        '                ListViewDbUtil.Items.Add(itm)
        '            End If
        '            'If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then lstvForms.Items(i).Checked = True
        '        Next
        '    Catch ex As MySql.Data.MySqlClient.MySqlException
        '        MessageBox.Show(ex.Message)
        '    End Try
        'End Sub

        'Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click

        '    For i = 0 To ListViewDbUtil.Items.Count - 1
        '        If ListViewDbUtil.Items(i).Selected Or ListViewDbUtil.Items(i).Checked Then
        '            'MsgBox(ListViewDbUtil.Items(i).Text)
        '            Select Case ListViewDbUtil.Items(i).Text
        '                Case "Synoptic data for many elements for one  observation time - TDCF"
        '                    Upload_FormSynoptic_RA1()
        '            End Select
        '        End If

        '    Next
    End Sub

    Function Upload_FormSynoptic_RA1() As Boolean
        'Upload_FormSynoptic_RA1 = True
        ''Open form for displaying data transfer progress
        'frmDataTransferProgress.Show()

        ''Upload data to observationInitial table
        'Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String, _
        '    dd As String, hh As String, ctl As Control, capturedBy As String
        'Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String, _
        '    qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String
        'Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        'Try
        '    sql = "SELECT * FROM form_synoptic_2_RA1"
        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ds.Clear()
        '    da.Fill(ds, "form_synoptic_2_RA1")

        '    maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
        '    qcStatus = 0
        '    acquisitionType = 1
        '    obsLevel = "surface"
        '    obsVal = ""
        '    obsFlag = ""
        '    dataForm = "form_synoptic_2_ra1"

        '    'Loop through all records in dataset
        '    For n = 0 To maxRows - 1
        '        'Display progress of data transfer
        '        frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
        '        frmDataTransferProgress.txtDataTransferProgress.Refresh()
        '        'Loop through all observation fields adding observation records to observationInitial table
        '        For m = 5 To 53
        '            stnId = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(0)
        '            yyyy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(1)
        '            mm = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(2)
        '            dd = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(3)
        '            hh = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(4)
        '            If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item("signature")) Then
        '                capturedBy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item("signature")
        '            End If

        '            If Val(mm) < 10 Then mm = "0" & mm
        '            If Val(dd) < 10 Then dd = "0" & dd
        '            If Val(hh) < 10 Then hh = "0" & hh

        '            obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

        '            If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)) Then obsVal = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)
        '            If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)) Then obsFlag = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)
        '            'Get the element code from the control name corresponding to column index
        '            For Each ctl In formSynopRA1.Controls
        '                If Val(Strings.Right(ctl.Name, 3)) = m Then
        '                    elemCode = Val(Strings.Mid(ctl.Name, 12, 3))
        '                End If
        '            Next ctl
        '            'Generate SQL string for inserting data into observationinitial table
        '            If Strings.Len(obsVal) > 0 Then
        '                strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " & _
        '                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
        '                    & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

        '                ' Create the Command for executing query and set its properties
        '                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        '                'Execute query
        '                objCmd.ExecuteNonQuery()

        '            End If
        '            'Move to next observation value in current record of the dataset
        '        Next m
        '        'Move to next record in dataset
        '    Next n

        'Catch ex As Exception
        '    ''Dispaly error message if it is different from the one trapped in 'Catch' execption above
        '    MsgBox(ex.Message)
        'End Try

        ''conn.Close()
        'frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        'frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Function

    Private Sub CLICOMDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLICOMDailyToolStripMenuItem.Click
        frmImportCSV.Show()
    End Sub

    Private Sub ObsInitialToFinalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObsInitialToFinalToolStripMenuItem.Click
        frmUploadToObsFinal.Show()
    End Sub

    'Private Sub AWSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AWSToolStripMenuItem.Click
    '    frmImportAWS.Show()
    'End Sub

    Private Sub NOAAGTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NOAAGTSToolStripMenuItem.Click
        frmGTSNOAA.Show()
    End Sub

    Private Sub CLIMSOFTV3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLIMSOFTV3ToolStripMenuItem.Click
        frmDataMigration.Show()
        '        On Error GoTo Err
        '        Dim sql_obsv, dbstr, svrstr, prtusrpwd, myconnectstr, tmpbkpfile, bkpfile, fchar As String
        '        Dim Cmd As MySql.Data.MySqlClient.MySqlCommand

        '        ' Export CLIMSOFT 4 Mysql db to text (CSV) backup
        '        dbstr = "mysql_main_climsoft_database_v3"

        '        ' Get a string for the full path for backup file and restructure it according the mysql path formart
        '        tmpbkpfile = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\backup.csv"

        '        If System.IO.File.Exists(tmpbkpfile) Then System.IO.File.Delete(tmpbkpfile)
        '        bkpfile = ""
        '        For i = 1 To Len(tmpbkpfile)
        '            fchar = Strings.Mid(tmpbkpfile, i, 1)
        '            If fchar = "\" Then fchar = "/"
        '            bkpfile = bkpfile & fchar
        '        Next

        '        'MsgBox(bkpfile)

        '        sql_obsv = "use " & dbstr & ";select recorded_from,described_by,recorded_at,made_at,obs_value,flag,period,qc_status,qc_type_log,acquisition_type,data_form,captured_by,mark from observation where recorded_from=67774010 into outfile '" & bkpfile & "' fields terminated by ',';"

        '        conn.ConnectionString = frmLogin.txtusrpwd.Text
        '        conn.Open()

        '        Cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)

        '        'Execute query for making a V3 db backup
        '        Cmd.ExecuteNonQuery()
        '        MsgBox("CLIMSOFT V3 backup created")

        '        ' Import from CLIMSOFT V3 backup file to CLIMSOFT V4 db
        '        dbstr = "mysql_climsoft_db_v4"
        '        sql_obsv = "use " & dbstr & "; LOAD DATA INFILE '" & bkpfile & "' IGNORE INTO TABLE observationinitial FIELDS TERMINATED BY ',' (recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,qcTypeLog,acquisitionType,dataForm,capturedBy,mark);"

        '        'Execute query for migrating data to V4 db
        '        Cmd = New MySql.Data.MySqlClient.MySqlCommand(sql_obsv, conn)
        '        Cmd.ExecuteNonQuery()

        '        MsgBox("CLIMSOFT V3 migration completed")
        '        conn.Close()
        '        Exit Sub
        'Err:
        '        MsgBox(Err.Description)
    End Sub

    Private Sub AWSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AWSToolStripMenuItem.Click
        frmImportAWS.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupToolStripMenuItem.Click
        frmBackupRestore.Text = "Backup to Text File"
        frmBackupRestore.Show()

    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        frmBackupRestore.Text = "Restore Backup File"
        frmBackupRestore.Show()
    End Sub

    Function Current_db() As String
        ' Extract the current database name from the db login string
        Dim k As Integer = InStr(frmLogin.txtusrpwd.Text, ";port") - InStr(frmLogin.txtusrpwd.Text, "database") - (Len("database") + 1)
        Current_db = Strings.Mid(frmLogin.txtusrpwd.Text, InStr(frmLogin.txtusrpwd.Text, "database") + (Len("database") + 1), k)
    End Function



End Class
