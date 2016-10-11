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
    Dim Sql, Sql2, userName As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection

    Private Sub formDataView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        '
        userName = frmLogin.txtUsername.Text

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

                Sql = "DELETE FROM form_hourlywind where stationId='" & stnId & "' AND elementId=" & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND hh=" & obsDay & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql = "SELECT * FROM form_hourlywind where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
                Else
                    Sql = "SELECT * FROM form_hourlywind ORDER by stationId,yyyy,mm,dd;"
                End If
                ' 
            Case "form_synoptic_2_ra1"
                Dim stnId As String, elemId, obsYear, obsMonth, obsHour As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsHour = Me.DataGridView.CurrentRow.Cells(4).Value

                Sql = "DELETE FROM form_synoptic_2_RA1 where stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND hh=" & obsHour & ";"
                '
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    Sql = "SELECT * FROM form_synoptic_2_RA1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
                Else
                    Sql = "SELECT * FROM form_synoptic_2_RA1 ORDER by stationId,yyyy,mm,dd,hh;"
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
                    Sql = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyy;"
                Else
                    Sql = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
                End If
                ' 
        End Select

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

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        '
        Dim cellValue As String, cellColName As String, k As Integer
        'MsgBox("Source Table: " & dsSourceTableName)
        Select Case dsSourceTableName
            Case "form_hourly"
                Dim stnId As String, elemId, obsYear, obsMonth, obsDay As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsDay = Me.DataGridView.CurrentRow.Cells(4).Value

                k = Me.DataGridView.CurrentCell.ColumnIndex
                cellColName = Me.DataGridView.Columns(k).HeaderText
                cellValue = Me.DataGridView.CurrentCell.Value

                'Generate SQL string for updating the selected value
                Sql = "UPDATE form_hourly SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND dd=" & obsDay & ";"

            Case "form_hourlywind"
                Dim stnId As String, obsYear, obsMonth, obsDay As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(1).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(2).Value
                obsDay = Me.DataGridView.CurrentRow.Cells(3).Value

                k = Me.DataGridView.CurrentCell.ColumnIndex
                cellColName = Me.DataGridView.Columns(k).HeaderText
                cellValue = Me.DataGridView.CurrentCell.Value

                'Generate SQL string for updating the selected value
                Sql = "UPDATE form_hourlywind SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & stnId & "' AND yyyy=" & obsYear & _
                    " AND mm= " & obsMonth & " AND dd=" & obsDay & ";"

            Case "form_daily2"
                Dim stnId As String, elemId, obsYear, obsMonth, obsHour As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsHour = Me.DataGridView.CurrentRow.Cells(4).Value

                k = Me.DataGridView.CurrentCell.ColumnIndex
                cellColName = Me.DataGridView.Columns(k).HeaderText
                cellValue = Me.DataGridView.CurrentCell.Value

                'Generate SQL string for updating the selected value
                Sql = "UPDATE form_daily2 SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND hh=" & obsHour & ";"

            Case "form_synoptic_2_ra1"
                Dim stnId As String, elemId, obsYear, obsMonth, obsHour As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value
                obsMonth = Me.DataGridView.CurrentRow.Cells(3).Value
                obsHour = Me.DataGridView.CurrentRow.Cells(4).Value

                k = Me.DataGridView.CurrentCell.ColumnIndex
                cellColName = Me.DataGridView.Columns(k).HeaderText
                cellValue = Me.DataGridView.CurrentCell.Value

                'Generate SQL string for updating the selected value
                Sql = "UPDATE form_synoptic_2_ra1 SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & obsMonth & " AND hh=" & obsHour & ";"

            Case "form_monthly"
                Dim stnId As String, elemId, obsYear As Integer
                stnId = Me.DataGridView.CurrentRow.Cells(0).Value
                elemId = Me.DataGridView.CurrentRow.Cells(1).Value
                obsYear = Me.DataGridView.CurrentRow.Cells(2).Value

                k = Me.DataGridView.CurrentCell.ColumnIndex
                cellColName = Me.DataGridView.Columns(k).HeaderText
                cellValue = Me.DataGridView.CurrentCell.Value

                'Generate SQL string for updating the selected value 
                Sql = "UPDATE form_monthly SET " & cellColName & "='" & cellValue & "' WHERE stationId='" & stnId & "' AND elementId=" & elemId & _
                    " AND yyyy=" & obsYear & " AND mm= " & ";"

        End Select
        '
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
    End Sub
End Class