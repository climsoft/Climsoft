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
Public Class frmQCdatesSelection

    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer, sql As String, strSQL As String
    Dim ds As New DataSet, da As MySql.Data.MySqlClient.MySqlDataAdapter, beginYearMonth As String, endYearMonth As String
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand


        myConnectionString = frmLogin.txtusrpwd.Text

        conn.ConnectionString = myConnectionString
        conn.Open()

        beginYear = Val(txtBeginYear.Text)
        endYear = Val(txtEndYear.Text)
        beginMonth = Val(txtBeginMonth.Text)
        endMonth = Val(txtEndMonth.Text)

        beginYearMonth = beginYear & beginMonth
        endYearMonth = endYear & endMonth

        If beginMonth < 10 Then beginYearMonth = beginYear & "0" & beginMonth
        If endMonth < 10 Then endYearMonth = endYear & "0" & beginMonth

        'Update QC status for selected date range from 0 to 1
        strSQL = "update observationinitial set qcstatus=1 where year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        Try
            'Execute query
            objCmd.ExecuteNonQuery()
            ' MsgBox("QC status updated!", MsgBoxStyle.Information)
            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        'Upper limits checks
        strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus' " & _
          "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
           "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus from " & _
           "observationinitial,obselement where describedBy=elementId and year(obsdatetime) " & _
           "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
           "upperLimit <> '' and cast(obsValue as INT) > cast(upperlimit as INT) " & _
           "into outfile 'd:/data/qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

               Try
            'Execute query
            objCmd.ExecuteNonQuery()
            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        'Lower limits checks
        strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus' " & _
          "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
           "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus from " & _
           "observationinitial,obselement where describedBy=elementId and year(obsdatetime) " & _
           "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
           "lowerLimit <> '' and cast(obsValue as INT) < cast(lowerlimit as INT) " & _
           "into outfile 'd:/data/qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
            'Execute query
            objCmd.ExecuteNonQuery()

            MsgBox("QC lower limits report send to: d:/data/qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)
            MsgBox("QC upper limits report send to: d:/data/qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmQCdatesSelection_Load(sender As Object, e As EventArgs) Handles Me.Load

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM observationInitial"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "obsInitial")
            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Not yet implemented")
    End Sub
End Class