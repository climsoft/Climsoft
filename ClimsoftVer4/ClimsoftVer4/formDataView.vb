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
    Dim Sql, Sql2, userName, id, cd, yr, mn, dy, hr As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection

    Private Sub formDataView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DataGridView.Top = 300
        'MsgBox(dsSourceTableName)
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
    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    '----------
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Not yet implemented", MsgBoxStyle.Information)
    End Sub

    Private Sub populateDataGrid(strSQL As String)
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(strSQL, conn)
        da.Fill(ds, "dataView")
        Me.DataGridView.DataSource = ds.Tables(0)
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Added June 2016. ASM
        userName = frmLogin.txtUsername.Text
        Sql = ""
        Select Case dsSourceTableName
            Case "form_hourly"
                Dim stnId As String, elemId, obsYear, obsMonth, obsDay As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsDay = Me.DataGridView.CurrentRow.Cells(4).Value

                Sql = "DELETE FROM form_hourly where stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND dd=" & obsDay & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql2 = "SELECT * FROM form_hourly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,dd;"
                Else
                    Sql2 = "SELECT * FROM form_hourly ORDER by stationId,elementId,yyyy,mm,dd;"
                End If
                ' 
            Case "form_daily2"
                Dim stnId As String, elemId, obsYear, obsMonth, obsHour As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsHour = Me.DataGridView.CurrentRow.Cells(4).Value

                Sql = "DELETE FROM form_daily2 where stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND hh=" & obsHour & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql2 = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
                Else
                    Sql2 = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
                End If
                ' 
            Case "form_hourlywind"
                Dim stnId As String, obsYear, obsMonth, obsDay As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(1).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(2).Value
                obsDay = Me.DataGridView.CurrentRow.Cells(3).Value

                Sql = "DELETE FROM form_hourlywind where stationId='" & stnId & "' AND yyyy=" & obsYear & " AND mm= " & _
                    obsMonth & " AND dd=" & obsDay & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql2 = "SELECT * FROM form_hourlywind where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
                Else
                    Sql2 = "SELECT * FROM form_hourlywind ORDER by stationId,yyyy,mm,dd;"
                End If
                ' 
            Case "form_synoptic_2_ra1"
                Dim stnId As String, obsYear, obsMonth, obsDay, obsHour As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(1).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(2).Value
                obsDay = Me.DataGridView.CurrentRow.Cells(3).Value
                obsHour = Me.DataGridView.CurrentRow.Cells(4).Value

                Sql = "DELETE FROM form_synoptic_2_RA1 where stationId='" & stnId & "' AND yyyy=" & obsYear & _
                    " AND mm= " & obsMonth & " AND dd= " & obsDay & " AND hh=" & obsHour & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql2 = "SELECT * FROM form_synoptic_2_RA1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
                Else
                    Sql2 = "SELECT * FROM form_synoptic_2_RA1 ORDER by stationId,yyyy,mm,dd,hh;"
                End If
                ' 
            Case "form_monthly"
                Dim stnId As String, elemId, obsYear As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value

                Sql = "DELETE FROM form_monthly where stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql2 = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyy;"
                Else
                    Sql2 = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
                End If
                ' 
        End Select

        If Strings.Len(Sql) > 0 Then
            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            'Open connection to database
            conn.Open()

            'Execute SQL command
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            objCmd.ExecuteNonQuery()

            MsgBox("Selected record has been deleted!", MsgBoxStyle.Information)

            populateDataGrid(Sql2)
            conn.Close()
        Else
            MsgBox("Deleting records not enabled for selected table datasheet!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ''Added June 2016. ASM
        Try
            Dim cellValue As String, cellColName As String, k As Integer
            'MsgBox("Source Table: " & dsSourceTableName)
            Sql = ""
            Select Case dsSourceTableName
                Case "form_hourly"
   
                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    'Generate SQL string for updating the selected value

                    Sql = "UPDATE form_hourly SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & id & "' AND elementId=" & cd & _
                        " AND yyyy=" & yr & " AND mm= " & mn & " AND dd=" & dy & ";"

                Case "form_hourlywind"

                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    'Generate SQL string for updating the selected value
                    'If k > 3 Then
                    Sql = "UPDATE form_hourlywind SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & id & "' AND yyyy='" & yr & "' AND mm= '" & mn & "' AND dd='" & dy & "';"
                    'End If
                    'MsgBox(Sql)
                Case "form_daily2"

                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    'Generate SQL string for updating the selected value
                     Sql = "UPDATE form_daily2 SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & id & "' AND elementId=" & cd & _
                        " AND yyyy=" & yr & " AND mm= " & mn & " AND hh=" & hr & ";"

                Case "form_synoptic_2_ra1"

                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    'Generate SQL string for updating the selected value

                    Sql = "UPDATE form_synoptic_2_ra1 SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & id & "' AND yyyy=" & yr & _
                        " AND mm= " & mn & " AND dd= " & dy & " AND hh=" & hr & ";"

                Case "form_monthly"

                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    'Generate SQL string for updating the selected value 

                    Sql = "UPDATE form_monthly SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & id & "' AND elementId=" & cd & _
                        " AND yyyy=" & yr & ";"

                Case "regkeys"
                    Dim keyNameValue As String
                    keyNameValue = Me.DataGridView.CurrentRow.Cells(0).Value
                    k = Me.DataGridView.CurrentCell.ColumnIndex
                    cellColName = Me.DataGridView.Columns(k).HeaderText
                    cellValue = Me.DataGridView.CurrentCell.Value

                    If k = 1 Then
                        'Check if there is a backslash "\" in the case of folder locations
                        If InStr(cellValue, "\") > 0 Then
                            'If string value contains a backslash "\" replace it with "\\". 
                            'This is done for MariaDB or MySQL to recognize the backslash.
                            cellValue = cellValue.Replace("\", "\\")
                        End If
                        'Generate SQL string for updating the selected value 
                        Sql = "UPDATE regkeys SET " & cellColName & "='" & cellValue & "' WHERE keyName='" & keyNameValue & "';"
                    End If
            End Select
   
            If Strings.Len(Sql) > 0 Then
                connStr = frmLogin.txtusrpwd.Text
                conn.ConnectionString = connStr
                'Open connection to database
                conn.Open()

                'Execute SQL command

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                objCmd.ExecuteNonQuery()
                '
                MsgBox("Selected value has been updated!", MsgBoxStyle.Information)
                '
                conn.Close()
            Else
                MsgBox("Updating of value not enabled for selected table datasheet or field, or field is part of a Primary Key!" & _
                       " You may try updating value in single record review mode after closing datasheet view.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim hdr, dat As String
        Dim ds1 As New DataSet
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter

        Try
            connStr = frmLogin.txtusrpwd.Text
            conn.ConnectionString = connStr
            conn.Open()

            hdr = DataGridView.Columns(0).Name

            For i = 1 To DataGridView.ColumnCount - 1
                hdr = hdr & "," & DataGridView.Columns(i).Name
            Next
            FileOpen(111, "dataexport.csv", OpenMode.Output)

            PrintLine(111, hdr)
            FileClose(111)

            Sql = "select * from " & dsSourceTableName & ";"

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)

            ds1.Clear()
            da1.Fill(ds1, dsSourceTableName)

            FileOpen(111, "dataexport.csv", OpenMode.Append)

            For i = 0 To ds1.Tables(dsSourceTableName).Rows.Count - 1
                dat = ds1.Tables(dsSourceTableName).Rows(i).Item(0)
                For j = 1 To ds1.Tables(dsSourceTableName).Columns.Count - 1
                    dat = dat & "," & ds1.Tables(dsSourceTableName).Rows(i).Item(j)
                Next

                PrintLine(111, dat)
            Next
            FileClose(111)
            conn.Close()
            CommonModules.ViewFile("dataexport.csv")
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

        sqlr = "Select * from " & dsSourceTableName & " where stationId ='" & txtStn.Text & "' and yyyy ='" & txtYY.Text & "' and mm ='" & txtMM.Text & "';"
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

        Select Case tbl
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
            Case "form_monthly"
                id = Me.DataGridView.CurrentRow.Cells(0).Value
                cd = Me.DataGridView.CurrentRow.Cells(1).Value
                yr = Me.DataGridView.CurrentRow.Cells(2).Value
        End Select
    End Sub
End Class