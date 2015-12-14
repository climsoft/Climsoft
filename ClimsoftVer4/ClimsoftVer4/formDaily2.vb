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


Public Class formDaily2
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer
    'Declare datasets required for QC
    Dim elemCode As String
    Dim dsValueLimits As New DataSet
    Dim sqlValueLimits As String
    Dim daValueLimits As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim stationCode As String
    Dim dsStationElevation As New DataSet
    Dim sqlStationElevation As String
    Dim daStationElevation As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsStationId As New DataSet
    Dim sqlStationId As String
    Dim daStationId As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim valUpperLimit As String, valLowerLimit As String, stnElevation As String
    Dim obsValue As String
    Dim daSequencer As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim dsSequencer As New DataSet
    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        cboStation.Text = ds.Tables("form_daily2").Rows(inc).Item("stationId")
        txtYear.Text = ds.Tables("form_daily2").Rows(inc).Item("yyyy")
        cboMonth.Text = ds.Tables("form_daily2").Rows(inc).Item("mm")

        cboHour.Text = ds.Tables("form_daily2").Rows(inc).Item("hh")

        Dim m As Integer
        Dim ctl As Control

        'Display observation values in coressponding textboxes
        'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
        For m = 5 To 53
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                End If
            Next ctl
        Next m

        'Display observation flags in coressponding textboxes
        'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
        For m = 54 To 102
            For Each ctl In Me.Controls
                If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                    If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                End If
            Next ctl
        Next m

        displayRecordNumber()
    End Sub
    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim loggedInUser As String
        'loggedInUser = frmLogin.txtUser.Text

        'MsgBox(loggedInUser)

        'Set TAB next to true
        tabNext = True
        'Set the record index counter to the first row
        inc = 0

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM form_daily2"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_daily2")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

        maxRows = ds.Tables("form_daily2").Rows.Count

        '--------------------------------
        'Fill combobox for station identifier with station list from station table
        Dim m As Integer, i As Integer, j As Integer
        Dim ctl As Control
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim sql1 As String, sql2 As String
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim da2 As MySql.Data.MySqlClient.MySqlDataAdapter
        sql1 = "SELECT stationId,stationName FROM station"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

        da1.Fill(ds1, "station")
        'Populate station combobox
        With cboStation
            .DataSource = ds1.Tables("station")
            .DisplayMember = "stationName"
            .ValueMember = "stationId"
            .SelectedIndex = 0
        End With

        'Populate dataForms
        sql2 = "SELECT stationId,stationName FROM data_form WHERE table_name='form_daily2"
        da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql2, conn)
        da2.Fill(ds2, "datForms")
        i = ds.Tables("dataForms").Rows(0).Item("val_start_position")
        j = ds.Tables("dataForms").Rows(0).Item("val_end_position")

        MsgBox("Value start position: " & i & " Value end position: " & j)
        '---------------------------------
        'Initialize header information for data-entry form

        If maxRows > 0 Then
            'StationIdTextBox.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
            'cboStation.Text = ds.Tables("form_synoptic_2_RA1").Rows(inc).Item("stationId")
            cboStation.SelectedValue = ds.Tables("form_daily2").Rows(inc).Item("stationId")

            txtYear.Text = ds.Tables("form_daily2").Rows(inc).Item("yyyy")
            cboMonth.Text = ds.Tables("form_daily2").Rows(inc).Item("mm")
            cboHour.Text = ds.Tables("form_daily2").Rows(inc).Item("hh")

            'Initialize textboxes for observation values
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To 35
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                        End If
                    End If
                Next ctl
            Next m

            'Initialize textboxes for observation flags
            'Observation flags range from column 37 i.e. column index 36 to column 67 i.e. column index 66
            For m = 36 To 66
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily2").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily2").Rows(inc).Item(m)
                        End If
                    End If
                Next ctl
            Next m

            displayRecordNumber()
        Else
            'If this is the first record
            btnCommit.Enabled = True
        End If

    End Sub

End Class