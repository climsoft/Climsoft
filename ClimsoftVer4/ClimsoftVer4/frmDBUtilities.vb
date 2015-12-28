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
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString As String
    Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
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

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub formDbUtilities_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        Dim col As String
        Dim itm As New ListViewItem

        ListViewDbUtil.Visible = True
        cmdUpload.Visible = True
        conn.Close()
        ListViewDbUtil.Clear()
        ListViewDbUtil.Columns.Clear()

        'ListViewDbUtil.Columns.Add("Form Name", 100, HorizontalAlignment.Left)
        ListViewDbUtil.Columns.Add("Select or Check Form to upload", 600, HorizontalAlignment.Left)
        Try
            MyConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT selected,form_name, description FROM data_forms;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            For i = 0 To ds.Tables("data_forms").Rows.Count - 1

                If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then
                    'col(0) = ds.Tables("data_forms").Rows(i).Item(1)
                    col = ds.Tables("data_forms").Rows(i).Item(2)
                    itm = New ListViewItem(col)
                    ListViewDbUtil.Items.Add(itm)
                End If
                'If ds.Tables("data_forms").Rows(i).Item(0) = 1 Then lstvForms.Items(i).Checked = True
            Next
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdUpload_Click(sender As Object, e As EventArgs) Handles cmdUpload.Click

        For i = 0 To ListViewDbUtil.Items.Count - 1
            If ListViewDbUtil.Items(i).Selected Or ListViewDbUtil.Items(i).Checked Then
                'MsgBox(ListViewDbUtil.Items(i).Text)
                Select Case ListViewDbUtil.Items(i).Text
                    Case "Synoptic data for many elements for one  observation time - TDCF"
                        Upload_FormSynoptic_RA1()
                End Select
            End If

        Next
    End Sub

    Function Upload_FormSynoptic_RA1() As Boolean
        Upload_FormSynoptic_RA1 = True
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String, _
            dd As String, hh As String, ctl As Control, capturedBy As String
        Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String, _
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        Try
            sql = "SELECT * FROM form_synoptic_2_RA1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic_2_RA1")

            maxRows = ds.Tables("form_synoptic_2_RA1").Rows.Count
            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            obsVal = ""
            obsFlag = ""
            dataForm = "form_synoptic_2_ra1"

            'Loop through all records in dataset
            For n = 0 To maxRows - 1
                'Display progress of data transfer
                frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                frmDataTransferProgress.txtDataTransferProgress.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table
                For m = 5 To 53
                    stnId = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(0)
                    yyyy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(1)
                    mm = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(2)
                    dd = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(3)
                    hh = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(4)
                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item("signature")) Then
                        capturedBy = ds.Tables("form_synoptic_2_RA1").Rows(n).Item("signature")
                    End If

                    If Val(mm) < 10 Then mm = "0" & mm
                    If Val(dd) < 10 Then dd = "0" & dd
                    If Val(hh) < 10 Then hh = "0" & hh

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)) Then obsVal = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m)
                    If Not IsDBNull(ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)) Then obsFlag = ds.Tables("form_synoptic_2_RA1").Rows(n).Item(m + 49)
                    'Get the element code from the control name corresponding to column index
                    For Each ctl In formSynopRA1.Controls
                        If Val(Strings.Right(ctl.Name, 3)) = m Then
                            elemCode = Val(Strings.Mid(ctl.Name, 12, 3))
                        End If
                    Next ctl
                    'Generate SQL string for inserting data into observationinitial table
                    If Strings.Len(obsVal) > 0 Then
                        strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " & _
                            "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                            & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                        ' Create the Command for executing query and set its properties
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                        'Execute query
                        objCmd.ExecuteNonQuery()

                    End If
                    'Move to next observation value in current record of the dataset
                Next m
                'Move to next record in dataset
            Next n

        Catch ex As Exception
            ''Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        'conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Function

    Private Sub CLICOMDailyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CLICOMDailyToolStripMenuItem.Click
        frmImportCSV.Show()
    End Sub

    Private Sub ObsInitialToFinalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObsInitialToFinalToolStripMenuItem.Click
        frmUploadToObsFinal.Show()
    End Sub

    Private Sub AWSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AWSToolStripMenuItem.Click
        frmImportAWS.Show()
    End Sub
End Class
