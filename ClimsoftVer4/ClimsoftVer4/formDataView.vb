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


Public Class formDataView
    Dim connStr As String
    Dim Sql, Sql2, userName, id, Nm, cd, yr, mn, dy, hr As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim ds, dsn, dsi, dsy, dsm As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub formDataView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                cmdExport.Enabled = False
                cmdImport.Enabled = False
            Else
                cmdExport.Enabled = True
                cmdImport.Enabled = True
            End If
            'DataGridView.Top = 300
            'MsgBox(dsSourceTableName)

            'Populate boxes for key entry forms
            If InStr(dsSourceTableName, "form") > 0 Then
                'Populate Station Names
                If Populate_Lists("stationName", dsn) Then
                    For i = 0 To dsn.Tables(dsSourceTableName).Rows.Count - 1
                        cboStName.Items.Add(dsn.Tables(dsSourceTableName).Rows(i).Item(0))
                        'frmFormsExport.cmbstation.Items.Add(dsn.Tables(dsSourceTableName).Rows(i).Item(0))
                    Next
                End If

                ''Populate Station IDs
                If Populate_Lists("stationId", dsi) Then
                    For i = 0 To dsi.Tables(dsSourceTableName).Rows.Count - 1
                        cboStnId.Items.Add(dsi.Tables(dsSourceTableName).Rows(i).Item(0).ToString)
                    Next
                End If

                '' Populate Element Names
                'If Populate_Lists("elementName", dsi) Then
                '    'MsgBox(dsi.Tables(dsSourceTableName).Rows.Count)
                '    For i = 0 To dsi.Tables(dsSourceTableName).Rows.Count - 1
                '        'MsgBox(dsi.Tables(dsSourceTableName).Rows(i).Item(0).ToString)
                '        frmFormsExport.cmbElement.Items.Add(dsi.Tables(dsSourceTableName).Rows(i).Item(0).ToString)
                '    Next
                'End If

                'Populate Station Years
                If Populate_Lists("yyyy", dsy) Then
                    For i = 0 To dsy.Tables(dsSourceTableName).Rows.Count - 1
                        cboYear.Items.Add((dsy.Tables(dsSourceTableName).Rows(i).Item(0)).ToString)
                    Next
                End If

                'Populate Station Months
                If Populate_Lists("mm", dsm) Then
                    For i = 0 To dsm.Tables(dsSourceTableName).Rows.Count - 1
                        cboMonth.Items.Add((dsm.Tables(dsSourceTableName).Rows(i).Item(0)).ToString)
                    Next
                End If

            End If
        Catch x As Exception
            MsgBox(x.Message)
        End Try

        'translate form controls
        ClsTranslations.TranslateForm(Me)
    End Sub
    'Sub ViewStation()
    '    Dim sql As String = "SELECT * FROM Authors"
    '    Dim connection As New SqlConnection(connectionString)
    '    Dim dataadapter As New SqlDataAdapter(sql, connection)
    '    Dim ds As New DataSet()
    '    connection.Open()
    '    dataadapter.Fill(ds, "Authors_table")
    '    connection.Close()
    '    DataGridView1.DataSource = ds
    '    DataGridView1.DataMember = "Authors_table"

    'End Sub
    '------------


    '----------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox(ClsTranslations.GetTranslation("Not yet implemented"), MsgBoxStyle.Information)
    End Sub

    Private Sub populateDataGrid(strSQL As String)
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(strSQL, conn)
            da.Fill(ds, "dataView")
            Me.DataGridView.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
        Dim tblhdr, x, importFile As String
        Try
            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()

            Sql = "SELECT * FROM " & dsSourceTableName & ";"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            ds.Clear()
            da.Fill(ds, "frmtbl")

            With ds.Tables("frmtbl")
                tblhdr = .Columns.Item(0).Caption
                For i = 1 To .Columns.Count - 1
                    tblhdr = tblhdr & "," & .Columns.Item(i).Caption
                Next
            End With
            'MsgBox(tblhdr)
            dlgImportFile.Filter = "Form Import file|*.*"
            dlgImportFile.Title = ClsTranslations.GetTranslation("Open Import File")
            dlgImportFile.FileName = dsSourceTableName
            dlgImportFile.ShowDialog()
            x = dlgImportFile.FileName

            If InStr(x, dsSourceTableName) = 0 Then
                MsgBox(ClsTranslations.GetTranslation("The selected import file name does not match the opened form: ") & dsSourceTableName & ClsTranslations.GetTranslation(". Please confirm!"))
                FileClose(111)
                conn.Close()
                Exit Sub
            End If

            'Convert Import file path seperators to SQL style
            importFile = Strings.Left(x, 1)
            For i = 2 To Len(x) - 1
                If Strings.Mid(x, i, 1) = "\" Then
                    importFile = importFile & "/"
                Else
                    importFile = importFile & Strings.Mid(x, i, 1)
                End If
            Next
            importFile = importFile & Strings.Right(x, 1)

            'MsgBox(importFile)
            Sql = "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
                   /*!40101 SET NAMES utf8mb4 */;
                   /*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
                   /*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
                   /*!40000 ALTER TABLE `" & dsSourceTableName & "` DISABLE KEYS */;
                   LOAD DATA LOCAL INFILE '" & importFile & "' REPLACE INTO TABLE " & dsSourceTableName & " FIELDS TERMINATED BY ',' (" & tblhdr & ");
                   /*!40000 ALTER TABLE `" & dsSourceTableName & "` ENABLE KEYS */;
                   /*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
                   /*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
                   /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"

            'Execute SQL command
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            objCmd.ExecuteNonQuery()

            Me.Refresh()
            DataGridView.Refresh()
            conn.Close()

            MsgBox("File '" & x & ClsTranslations.GetTranslation("' Successfully Imported"))

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click

        Dim RefreshRecords As New dataEntryGlobalRoutines

        'Sql = "Select * FROM  " & dsSourceTableName & ";"
        RefreshRecords.viewTableRecords("Select * FROM  " & dsSourceTableName & ";")

    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        frmFormsExport.Show()
    End Sub

    Private Sub cboStnId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStnId.SelectedIndexChanged
        Nm = String.Empty

        If Stn_Nm(cboStnId.SelectedItem, Nm) Then
            cboStName.Text = Nm
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Added June 2016. ASM
        userName = frmLogin.txtUsername.Text
        Sql = ""
        'MsgBox(dsSourceTableName)
        Try
            Select Case dsSourceTableName
                Case "form_hourly"
                    Sql = "DELETE FROM form_hourly where stationId='" & id & "' AND elementId=" & cd &
                    " AND yyyy=" & yr & " AND mm= " & mn & " AND dd=" & dy & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_hourly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,dd;"
                    Else
                        Sql2 = "SELECT * FROM form_hourly ORDER by stationId,elementId,yyyy,mm,dd;"
                    End If

                Case "form_daily1"
                    Sql = "DELETE FROM form_daily1 where stationId = '" & id & "'" & " AND yyyy = " & yr & " AND mm = " & mn & " AND dd = " & dy & ";"

                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_daily where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
                    Else
                        Sql2 = "SELECT * FROM form_daily1 ORDER by stationId,yyyy,mm,dd;"
                    End If
                     ' 
                Case "form_daily2"
                    Sql = "DELETE FROM form_daily2 where stationId='" & id & "' AND elementId=" & cd &
                    " AND yyyy=" & yr & " AND mm= " & mn & " AND hh=" & hr & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
                    Else
                        Sql2 = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
                    End If
                ' 
                Case "form_hourlywind"
                    Sql = "DELETE FROM form_hourlywind where stationId='" & id & "' AND yyyy=" & yr & " AND mm= " &
                    mn & " AND dd=" & dy & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_hourlywind where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
                    Else
                        Sql2 = "SELECT * FROM form_hourlywind ORDER by stationId,yyyy,mm,dd;"
                    End If
                ' 
                Case "form_synoptic_2_ra1"
                    Sql = "DELETE FROM form_synoptic_2_ra1 where stationId='" & id & "' AND yyyy=" & yr & " AND mm= " & mn & " AND dd= " & dy & " AND hh=" & hr & ";"
                    'MsgBox(Sql)
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_synoptic_2_ra1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
                    Else
                        Sql2 = "SELECT * FROM form_synoptic_2_ra1 ORDER by stationId,yyyy,mm,dd,hh;"
                    End If

                Case "form_synoptic2_tdcf"
                    Sql = "DELETE FROM form_synoptic2_tdcf where stationId='" & id & "' AND yyyy=" & yr & " AND mm= " & mn & " AND dd= " & dy & " AND hh=" & hr & ";"
                    'MsgBox(Sql)
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_synoptic2_tdcf where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
                    Else
                        Sql2 = "SELECT * FROM form_synoptic2_tdcf ORDER by stationId,yyyy,mm,dd,hh;"
                    End If
                    ' 
                Case "form_monthly"
                    Sql = "DELETE FROM form_monthly where stationId='" & id & "' AND elementId=" & cd &
                    " AND yyyy=" & yr & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyy;"
                    Else
                        Sql2 = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
                    End If
                Case "form_agro1"

                    Sql = "DELETE FROM form_agro1 where stationId='" & id & "' AND yyyy=" & yr & " AND mm= " &
                    mn & " AND dd=" & dy & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_agro1 where signature ='" & userName & "' ORDER by stationId,yyy,mm,dd;"
                    Else
                        Sql2 = "SELECT * FROM form_agro1 ORDER by stationId,yyyy,mm,dd;"
                    End If

                Case "form_hourly2"
                    Sql = "DELETE FROM form_hourly2 where stationId='" & id & "' AND elementId=" & cd &
                    " AND yyyy=" & yr & " AND mm= " & mn & " AND hh=" & hr & ";"
                    '
                    If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                        Sql2 = "SELECT * FROM form_hourly2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
                    Else
                        Sql2 = "SELECT * FROM form_hourly2 ORDER by stationId,elementId,yyyy,mm,hh;"
                    End If

            'Update metadata tables
                Case "station"
                    Sql = "DELETE FROM station where stationId ='" & Me.DataGridView.CurrentRow.Cells(0).Value & "';"
                    Sql2 = "SELECT * FROM station ORDER by stationId;"

                Case "obselement"
                    Sql = "DELETE FROM obselement where elementId ='" & Me.DataGridView.CurrentRow.Cells(0).Value & "';"
                    Sql2 = "SELECT * FROM obselement ORDER by elementId;"
            End Select

            If Strings.Len(Sql) > 0 Then
                connStr = frmLogin.txtusrpwd.Text
                conn.ConnectionString = connStr
                'Open connection to database
                conn.Open()

                'Execute SQL command
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                objCmd.ExecuteNonQuery()

                MsgBox(ClsTranslations.GetTranslation("Selected record has been deleted!"), MsgBoxStyle.Information)

                populateDataGrid(Sql2)
                conn.Close()
            Else
                MsgBox(ClsTranslations.GetTranslation("Deleting records not enabled for selected table datasheet!"), MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboStName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStName.SelectedIndexChanged
        Try
            'MsgBox(cboStName.SelectedItem)
            id = String.Empty
            If Stn_Id(cboStName.SelectedItem, id) Then
                cboStnId.Text = id
            Else
                MsgBox(cboStName.SelectedItem)
            End If
        Catch x As Exception
            MsgBox(x.Message)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''Added June 2016. ASM
        Dim cellValue, cellColName, updateStr As String, k, r As Integer

        Try

            r = Me.DataGridView.CurrentRow.Index

            If InStr(dsSourceTableName, "form") = 0 Then ' And Not Get_tblIDX(r) Then
                Exit Sub
            End If

            Get_RecordIdx(dsSourceTableName)

            Sql = ""
            updateStr = String.Empty
            For k = 0 To Me.DataGridView.Columns.Count - 1

                cellColName = Me.DataGridView.Columns(k).HeaderText

                If Not IsDBNull(Me.DataGridView.Rows(r).Cells(k).Value) Then
                    cellValue = Me.DataGridView.Rows(r).Cells(k).Value
                Else
                    'cellValue = vbNullString
                    cellValue = "\N"
                End If

                If cellColName = "signature" Or cellColName = "entryDatetime" Then Continue For

                ' Create the fields update string
                If k = 0 Then
                    updateStr = "SET " & cellColName & " ='" & cellValue & "'"
                Else
                    updateStr = updateStr & "," & cellColName & " ='" & cellValue & "'"
                End If

                'MsgBox(updateStr)
            Next

            Select Case dsSourceTableName
                    'Generate SQL string for updating the selected value
                Case "form_hourly"
                    Sql = "UPDATE form_hourly " & updateStr & " WHERE stationId='" & id & "' AND elementId=" & cd &
                            " AND yyyy=" & yr & " AND mm= " & mn & " AND dd=" & dy & ";"

                Case "form_hourlywind"
                    Sql = "UPDATE form_hourlywind " & updateStr & " WHERE stationId='" & id & "' AND yyyy='" & yr & "' AND mm= '" & mn & "' AND dd='" & dy & "';"

                Case "form_daily1"
                    Sql = "update form_daily1 " & updateStr & "  where stationId = '" & id &
                            "' and yyyy = '" & yr & "' and mm = '" & mn & "' and dd = '" & dy & "';"

                Case "form_daily2"

                    Sql = "UPDATE form_daily2 " & updateStr & " WHERE stationId='" & id & "' AND elementId=" & cd &
                           " AND yyyy=" & yr & " AND mm= " & mn & " AND hh=" & hr & ";"

                Case "form_synoptic_2_ra1"
                    Sql = "UPDATE form_synoptic_2_ra1 " & updateStr & "  WHERE stationId='" & id & "' AND yyyy=" & yr &
                            " AND mm= " & mn & " AND dd= " & dy & " AND hh=" & hr & ";"

                Case "form_synoptic2_tdcf"
                    Sql = "Update() form_synoptic2_tdcf " & updateStr & " WHERE stationId='" & id & "' AND yyyy=" & yr &
                            " AND mm= " & mn & " AND dd= " & dy & " AND hh=" & hr & ";"

                Case "form_monthly"
                    Sql = "UPDATE form_monthly " & updateStr & "  WHERE stationId='" & id & "' AND elementId=" & cd &
                            " AND yyyy=" & yr & ";"
                Case "form_agro1"
                    Sql = "UPDATE form_agro1 " & updateStr & " WHERE stationId='" & id & "' AND yyyy=" & yr &
                            " AND mm= " & mn & " AND dd= " & dy & ";"

                Case "form_hourly2"
                    Sql = "UPDATE form_hourly2 " & updateStr & " WHERE stationId='" & id & "' AND elementId=" & cd &
                           " AND yyyy=" & yr & " AND mm= " & mn & " AND hh=" & hr & ";"

                Case "regkeys"
                    Dim keyNameValue As String, reg As Integer
                    keyNameValue = Me.DataGridView.CurrentRow.Cells(0).Value
                    reg = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(reg).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value
                    If reg = 1 Then
                        'Check if there is a backslash "\" in the case of folder locations
                        If InStr(cellValue, "\") > 0 Then
                            'If string value contains a backslash "\" replace it with "\\". 
                            'This is done for MariaDB or MySQL to recognize the backslash.
                            cellValue = cellValue.Replace("\", "\\")
                        End If
                        'Generate SQL string for updating the selected value 
                    End If
                    Sql = "UPDATE regkeys " & updateStr & " WHERE keyName='" & keyNameValue & "';"
                ' Update metadata tables
                Case "station"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    Sql = "UPDATE station " & updateStr & " WHERE stationId='" & id & "';"

                    'MsgBox(Sql)
                Case "obselement"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    Sql = "UPDATE obselement " & updateStr & " WHERE elementId='" & id & "';"
                    'MsgBox(Sql)
            End Select


            If Strings.Len(Sql) > 0 Then
                connStr = frmLogin.txtusrpwd.Text
                conn.ConnectionString = connStr
                conn.Open()

                'Execute SQL command
                Sql = Strings.Replace(Sql, "'\N'", "\N")
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                objCmd.ExecuteNonQuery()
                conn.Close()           '
                MsgBox(ClsTranslations.GetTranslation("Selected value has been updated!"), MsgBoxStyle.Information)

            Else
                MsgBox(ClsTranslations.GetTranslation("Updating of value not enabled for selected table datasheet or field, or field is part of a Primary Key!") &
                       ClsTranslations.GetTranslation(" You may try updating value in single record review mode after closing datasheet view."), MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            conn.Close()
            If ex.HResult = -2147467261 Then Exit Sub
            MessageBox.Show(ex.HResult & " " & ex.Message)
        End Try

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim hdr, dat, exportfile, x, CellValue As String
        Dim ds1 As New DataSet
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter

        Try
            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()



            'MsgBox(System.IO.Path.GetFullPath(Application.CommonAppDataPath))
            'exportfile = System.IO.Path.GetFullPath(Application.StartupPath) & "\data\" & dsSourceTableName & ".csv"

            'exportfile = System.IO.Path.GetFullPath(Application.CommonAppDataPath) & "\" & dsSourceTableName & ".csv"

            dlgExportFile.Filter = "Form Export file|*.csv"
            dlgExportFile.Title = ClsTranslations.GetTranslation("Save Export File")
            dlgExportFile.FileName = dsSourceTableName
            dlgExportFile.ShowDialog()
            x = dlgExportFile.FileName

            If InStr(x, dsSourceTableName) = 0 Then
                MsgBox(ClsTranslations.GetTranslation("Improper filename. It Must contain the phrase: ") & dsSourceTableName)
                'FileClose(111)
                conn.Close()
                Exit Sub
            End If

            FileOpen(111, x, OpenMode.Output)

            hdr = DataGridView.Columns(0).Name

            For i = 1 To DataGridView.ColumnCount - 1
                hdr = hdr & "," & DataGridView.Columns(i).Name
            Next
            PrintLine(111, hdr)

            'FileClose(111)

            Sql = "Select * from " & dsSourceTableName & ";"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)

            ds1.Clear()
            da1.Fill(ds1, dsSourceTableName)

            'FileOpen(111, exportfile, OpenMode.Append)

            For i = 0 To ds1.Tables(dsSourceTableName).Rows.Count - 1
                dat = ds1.Tables(dsSourceTableName).Rows(i).Item(0)
                For j = 1 To ds1.Tables(dsSourceTableName).Columns.Count - 1
                    If IsDBNull(ds1.Tables(dsSourceTableName).Rows(i).Item(j)) Then
                        CellValue = "\N" '""
                        'dat = dat & "," & "\N"
                    Else
                        CellValue = ds1.Tables(dsSourceTableName).Rows(i).Item(j)

                        If IsDate(CellValue) And InStr(CellValue, ".") = 0 Then
                            CellValue = DateAndTime.Year(CellValue) & "-" & DateAndTime.Month(CellValue) & "-" & DateAndTime.Day(CellValue) & " " & DateAndTime.Hour(CellValue) & ":" & DateAndTime.Minute(CellValue) & ":" & DateAndTime.Second(CellValue)
                            'MsgBox(CellValue)
                        End If
                        ' Exclude escape characters that had been observe in some fields
                        If InStr(ds1.Tables(dsSourceTableName).Rows(i).Item(j), Chr(10)) > 0 Or InStr(ds1.Tables(dsSourceTableName).Rows(i).Item(j), Chr(13)) > 0 Then
                            CellValue = Strings.Left(ds1.Tables(dsSourceTableName).Rows(i).Item(j), Len(ds1.Tables(dsSourceTableName).Rows(i).Item(j)) - 1)
                        End If
                    End If

                    dat = dat & "," & CellValue
                Next
                Print(111, dat & Chr(10))
            Next
            FileClose(111)

            ''Convert Export file path seperators to SQL style
            'exportfile = Strings.Left(x, 1)
            'For i = 2 To Len(x) - 1
            '    If Strings.Mid(x, i, 1) = "\" Then
            '        exportfile = exportfile & "/"
            '    Else
            '        exportfile = exportfile & Strings.Mid(x, i, 1)
            '    End If
            'Next
            'exportfile = exportfile & Strings.Right(x, 1)

            ''MsgBox(exportfile)

            'Sql = "select * from " & dsSourceTableName & " into outfile '" & exportfile & "' fields terminated by ',';"

            ''Execute SQL command
            'objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            'objCmd.ExecuteNonQuery()

            conn.Close()

            MsgBox(ClsTranslations.GetTranslation("File") & " '" & x & "' " & ClsTranslations.GetTranslation("Successfully Exported"))
            'CommonModules.ViewFile(exportfile)
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            FileClose(111)
        End Try

    End Sub

    Private Sub cmdEdit_Click(sender As Object, e As EventArgs) Handles cmdEdit.Click
        If cmdEdit.Text = "Edit Mode" Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            cmdEdit.Text = "View Mode"
            'grpSearch.Visible = False
        Else
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            cmdEdit.Text = "Edit Mode"
            'grpSearch.Visible = True
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Dim showRecords As New dataEntryGlobalRoutines
        Dim sqlr As String

        sqlr = "Select * from " & dsSourceTableName & " where stationId ='" & cboStnId.Text & "' and yyyy ='" & cboYear.Text & "' and mm ='" & cboMonth.Text & "';"
        'MsgBox(sqlr)
        showRecords.viewTableRecords(sqlr)
    End Sub

    Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellClick
        Get_RecordIdx(dsSourceTableName)
    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick
        'MsgBox(DataGridView.CurrentRow.Cells(0).Value)
        Get_RecordIdx(dsSourceTableName)
    End Sub
    Sub Get_RecordIdx(tbl As String)
        'MsgBox(tbl & " " & DataGridView.CurrentRow.Cells(0).Value)
        'MsgBox(tbl)
        Try
            Select Case tbl

                Case "form_daily1"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    yr = Me.DataGridView.CurrentRow.Cells(1).Value
                    mn = Me.DataGridView.CurrentRow.Cells(2).Value
                    dy = Me.DataGridView.CurrentRow.Cells(3).Value
                Case "form_daily2"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    cd = Me.DataGridView.CurrentRow.Cells(1).Value
                    yr = Me.DataGridView.CurrentRow.Cells(2).Value
                    mn = Me.DataGridView.CurrentRow.Cells(3).Value
                    hr = Me.DataGridView.CurrentRow.Cells(4).Value
                Case "form_hourly"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    cd = Me.DataGridView.CurrentRow.Cells(1).Value
                    yr = Me.DataGridView.CurrentRow.Cells(2).Value
                    mn = Me.DataGridView.CurrentRow.Cells(3).Value
                    dy = Me.DataGridView.CurrentRow.Cells(4).Value
                Case "form_hourlywind"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    yr = Me.DataGridView.CurrentRow.Cells(1).Value
                    mn = Me.DataGridView.CurrentRow.Cells(2).Value
                    dy = Me.DataGridView.CurrentRow.Cells(3).Value
                Case "form_synoptic_2_ra1"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    yr = Me.DataGridView.CurrentRow.Cells(1).Value
                    mn = Me.DataGridView.CurrentRow.Cells(2).Value
                    dy = Me.DataGridView.CurrentRow.Cells(3).Value
                    hr = Me.DataGridView.CurrentRow.Cells(4).Value
                Case "form_synoptic2_tdcf"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    yr = Me.DataGridView.CurrentRow.Cells(1).Value
                    mn = Me.DataGridView.CurrentRow.Cells(2).Value
                    dy = Me.DataGridView.CurrentRow.Cells(3).Value
                    hr = Me.DataGridView.CurrentRow.Cells(4).Value
                Case "form_monthly"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    cd = Me.DataGridView.CurrentRow.Cells(1).Value
                    yr = Me.DataGridView.CurrentRow.Cells(2).Value
                Case "form_agro1"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    yr = Me.DataGridView.CurrentRow.Cells(1).Value
                    mn = Me.DataGridView.CurrentRow.Cells(2).Value
                    dy = Me.DataGridView.CurrentRow.Cells(3).Value
                Case "form_hourly2"
                    id = Me.DataGridView.CurrentRow.Cells(0).Value
                    cd = Me.DataGridView.CurrentRow.Cells(1).Value
                    yr = Me.DataGridView.CurrentRow.Cells(2).Value
                    mn = Me.DataGridView.CurrentRow.Cells(3).Value
                    hr = Me.DataGridView.CurrentRow.Cells(4).Value
            End Select
        Catch ex As Exception
            If ex.HResult = -2147467262 Then Exit Sub
            MsgBox(ex.Message)
        End Try
    End Sub
    'Function Get_tblIDX(recNo As Long) As Boolean
    '    Dim dsx As New DataSet
    '    Dim dax As MySql.Data.MySqlClient.MySqlDataAdapter

    '    Try
    '        Sql = "select * from " & dsSourceTableName & ";"

    '        'connStr = frmLogin.txtusrpwd.Text
    '        'conn.ConnectionString = connStr
    '        conn.Open()

    '        dax = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
    '        conn.Close()

    '        dsx.Clear()
    '        dax.Fill(dsx, dsSourceTableName)

    '        With dsx.Tables(dsSourceTableName)
    '            If .Rows.Count = 0 Then Return False
    '            Select Case dsSourceTableName
    '                Case "form_daily2"
    '                    id = .Rows(recNo).Item(0)
    '                    cd = .Rows(recNo).Item(1)
    '                    yr = .Rows(recNo).Item(2)
    '                    mn = .Rows(recNo).Item(3)
    '                    hr = .Rows(recNo).Item(4)
    '                Case "form_daily1"
    '                    id = .Rows(recNo).Item(0)
    '                    yr = .Rows(recNo).Item(1)
    '                    mn = .Rows(recNo).Item(2)
    '                    dy = .Rows(recNo).Item(3)
    '                Case "form_hourly"
    '                    id = .Rows(recNo).Item(0)
    '                    cd = .Rows(recNo).Item(1)
    '                    yr = .Rows(recNo).Item(2)
    '                    mn = .Rows(recNo).Item(3)
    '                    dy = .Rows(recNo).Item(4)
    '                Case "form_hourlywind"
    '                    id = .Rows(recNo).Item(0)
    '                    yr = .Rows(recNo).Item(1)
    '                    mn = .Rows(recNo).Item(2)
    '                    dy = .Rows(recNo).Item(3)
    '                Case "form_synoptic_2_ra1"
    '                    id = .Rows(recNo).Item(0)
    '                    yr = .Rows(recNo).Item(1)
    '                    mn = .Rows(recNo).Item(2)
    '                    dy = .Rows(recNo).Item(3)
    '                    hr = .Rows(recNo).Item(4)
    '                Case "form_synoptic2_tdcf"
    '                    id = .Rows(recNo).Item(0)
    '                    yr = .Rows(recNo).Item(1)
    '                    mn = .Rows(recNo).Item(2)
    '                    dy = .Rows(recNo).Item(3)
    '                    hr = .Rows(recNo).Item(4)
    '                Case "form_monthly"
    '                    id = .Rows(recNo).Item(0)
    '                    cd = .Rows(recNo).Item(1)
    '                    yr = .Rows(recNo).Item(2)
    '                Case "form_agro1"
    '                    id = .Rows(recNo).Item(0)
    '                    yr = .Rows(recNo).Item(1)
    '                    mn = .Rows(recNo).Item(2)
    '                    dy = .Rows(recNo).Item(3)
    '                Case "form_hourly2"
    '                    id = .Rows(recNo).Item(0)
    '                    cd = .Rows(recNo).Item(1)
    '                    yr = .Rows(recNo).Item(2)
    '                    mn = .Rows(recNo).Item(3)
    '                    hr = .Rows(recNo).Item(4)
    '                    'Case "station"
    '                    '    id = .Rows(recNo).Item(0)
    '                    'Case "regkeys"
    '                    '    id = .Rows(recNo).Item(0)
    '            End Select
    '        End With
    '        Return True
    '    Catch ex As Exception
    '        conn.Close()
    '        'If ex.HResult = -2147467262 Then Exit Sub
    '        MsgBox(ex.Message & " at Get_tblIDX")
    '        Return False
    '    End Try
    'End Function



    Function Populate_Lists(fld As String, ByRef dss As DataSet) As Boolean

        Try
            Sql = String.Empty
            Select Case fld
                Case "stationName"
                    Sql = "Select stationName FROM  " & dsSourceTableName & " INNER JOIN station On " & dsSourceTableName & ".stationId = station.stationId GROUP BY stationName ORDER BY stationName;"
                Case "stationId"
                    Sql = "SELECT stationId FROM  " & dsSourceTableName & " GROUP BY stationId ORDER BY stationId;"
                'Case "elementName"
                '    Sql = "SELECT elementName FROM " & dsSourceTableName & " INNER JOIN obselement ON obselement.elementId =  " & dsSourceTableName & ".elementId GROUP BY elementName order BY elementName;"
                Case "yyyy"
                    Sql = "SELECT yyyy FROM  " & dsSourceTableName & " GROUP BY yyyy ORDER BY yyyy;"
                Case "mm"
                    Sql = "SELECT mm FROM  " & dsSourceTableName & " GROUP BY mm ORDER BY mm;"
            End Select

            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()

            Dim daa = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            dss.Clear()
            daa.Fill(dss, dsSourceTableName)

            'MsgBox(dss.Tables(dsSourceTableName).Rows.Count)
            'MsgBox(dss.Tables(dsSourceTableName).Rows(0).Item(0))
            conn.Close()
            Return True

        Catch x As Exception
            conn.Close()
            'MsgBox(x.Message & " at Populate_Lists")
            Return False
        End Try
    End Function


    Function Stn_Id(stNm As String, ByRef stId As String) As Boolean
        Dim dsi As New DataSet
        Try
            Sql = "Select stationId FROM station WHERE stationName= '" & stNm & "';"

            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            dsi.Clear()
            da.Fill(dsi, "station")
            conn.Close()
            'MsgBox(ds.Tables("station").Rows(0).Item(0))
            If dsi.Tables("station").Rows.Count = 0 Then Return False
            If Not IsDBNull(dsi.Tables("station").Rows(0).Item(0)) Then stId = dsi.Tables("station").Rows(0).Item(0)

            Return True

        Catch x As Exception
            conn.Close()
            MsgBox(x.Message)
            Return False
        End Try
    End Function

    Function Stn_Nm(stnId As String, ByRef StnNm As String) As Boolean
        Dim dsn As New DataSet
        Try
            Sql = "Select stationName FROM station WHERE stationId = '" & stnId & "';"

            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
            dsn.Clear()
            da.Fill(dsn, "station")
            conn.Close()

            If dsn.Tables("station").Rows.Count = 0 Then Return False
            If Not IsDBNull(dsn.Tables("station").Rows(0).Item(0)) Then StnNm = dsn.Tables("station").Rows(0).Item(0)

            Return True

        Catch x As Exception
            conn.Close()
            MsgBox(x.Message)
            Return False
        End Try
    End Function

    'Private Sub DataGridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellValueChanged
    '    MsgBox(id & " " & yr & " " & mn & " " & Me.DataGridView.CurrentCell.Value)
    'End Sub
End Class