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
    Dim ds1 As New DataSet, da1 As MySql.Data.MySqlClient.MySqlDataAdapter, sql1 As String

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        lblProcessingStatus.Text = "Processing....Please wait!"
        Dim m As Integer, n As Integer, elem1 As Integer, elem2 As Integer
        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM observationInitial where year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "obsInitial")
            'conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'Get required data for QC interelement comparison
            sql1 = "SELECT * from qc_interelement_relationship_definition"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            da1.Fill(ds1, "interElement")

            n = ds1.Tables("interElement").Rows.Count
            
            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try


        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand


        ''myConnectionString = frmLogin.txtusrpwd.Text

        ''conn.ConnectionString = myConnectionString
        ''conn.Open()

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

        If frmQC.optAbsoluteLimits.Checked = True Then
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

                lblProcessingStatus.Text = "Processing complete!"

                MsgBox("QC lower limits report send to: d:/data/qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)
                MsgBox("QC upper limits report send to: d:/data/qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
            End Try

            'Interelement comparison checks
        ElseIf frmQC.optInterElement.Checked = True Then
            'Loop through the combination of elements in the [qc_interelement_relationship_definition] table
            For m = 0 To n - 1
                elem1 = ds1.Tables("interElement").Rows(m).Item("elementId_1")
                elem2 = ds1.Tables("interElement").Rows(m).Item("elementId_2")
                'MsgBox("Element1=" & elem1 & "  Element2=" & elem2)

                'Select element 1 for inter-eleent comparison
                strSQL = "DELETE from qc_interelement_1"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    ' MsgBox("Table qc_interelement_1 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                End Try

                '
                strSQL = "INSERT INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1) " & _
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus FROM observationinitial " & _
                    "WHERE describedby=" & elem1 & " and year(obsdatetime) between " & beginYear & " and " & endYear & _
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_2 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    ''MsgBox(ex.Message)
                End Try

                'Select element 2 for inter-eleent comparison
                strSQL = "DELETE from qc_interelement_2"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    ' MsgBox("Table qc_interelement_1 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                End Try

                '
                strSQL = "INSERT INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2) " & _
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus FROM observationinitial " & _
                    "WHERE describedby=" & elem2 & " and year(obsdatetime) between " & beginYear & " and " & endYear & _
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ""

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_2 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                End Try

                'Carry out interelement comparison
                If (elem1 = 2 And elem2 = 3) Or (elem1 = 101 And elem2 = 102) Or (elem1 = 102 And elem2 = 103) Then
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2' " & _
                        "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2 " &
                        "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 " &
                        "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                        "'d:/data/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

                    ' '' Create the Command for executing query and set its properties
                    ''objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                    ''Try
                    ''    'Execute query
                    ''    objCmd.ExecuteNonQuery()
                    ''    MsgBox("QC inter-element report(1) send to: d:/data/qc_values_interelement_set1_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

                    ''    'MsgBox("Table qc_interelement_2 cleared!")
                    ''    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    ''    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                    ''Catch ex As Exception
                    ''    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    ''    MsgBox(ex.Message)
                    ''End Try

                ElseIf (elem1 = 2 And elem2 = 101) Or (elem1 = 101 And elem2 = 3) Then
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2' " & _
                        "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2 " &
                        "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " & _
                        "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " & _
                        "and day(obsDatetime_1)=day(obsDatetime_2) " &
                        "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                        "'d:/data/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

                End If
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


                Try
                    'Execute query
                    objCmd.ExecuteNonQuery()
                    'MsgBox("QC inter-element report( send to: d:/data/qc_values_interelement_set2_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

                    'MsgBox("Table qc_interelement_2 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                End Try

            Next m
            lblProcessingStatus.Text = "Processing complete!"

            MsgBox("Inter-element reports sent to d:/data", MsgBoxStyle.Information)
        End If
        conn.Close()
    End Sub

    Private Sub frmQCdatesSelection_Load(sender As Object, e As EventArgs) Handles Me.Load

        If frmQC.optAbsoluteLimits.Checked = True Then
            lblQCtype.Text = "QC Limits checks"
        ElseIf frmQC.optInterElement.Checked = True Then
            lblQCtype.Text = "QC Inter-element checks"
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Not yet implemented")
    End Sub
End Class