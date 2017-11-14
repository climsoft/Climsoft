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

'Imports ClimsoftVer4.GlobalVariables
Public Class frmQC
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer, sql As String, strSQL As String
    Dim ds As New DataSet, da As MySql.Data.MySqlClient.MySqlDataAdapter, beginYearMonth As String, endYearMonth As String
    Dim ds1 As New DataSet, da1 As MySql.Data.MySqlClient.MySqlDataAdapter, sql1 As String
    Dim qcReportsFolderWindows As String, qcReportsFolderUnix As String
    Dim msgTxtQCReportsOutLowerLimits As String
    Dim msgTxtQCReportsOutUpperLimits As String
    Dim msgTxtQCReportsOutInterelement As String



    Public HTMLHelp As New clsHelp
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conns As New MySql.Data.MySqlClient.MySqlConnection
        Dim dss As New DataSet, daa As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim sql As String


        'cmdOk.Text = lang("OK")
        'cmdCancel.Text = lang("Cancel")
        'cmdApply.Text = lang("Apply")
        'cmdHelp.Text = lang("Help")

        'Initialize Stations List Views
        LstViewStations.Columns.Clear()

        LstViewStations.Columns.Add("Station Id", 100, HorizontalAlignment.Left)
        LstViewStations.Columns.Add("Station Name", 200, HorizontalAlignment.Left)

        'Initialize Elements List Views
        lstViewElements.Columns.Clear()
        lstViewElements.Columns.Add("Element Code", 100, HorizontalAlignment.Left)
        lstViewElements.Columns.Add("Element Details", 200, HorizontalAlignment.Left)

        Try
            conns.ConnectionString = frmLogin.txtusrpwd.Text
            conns.Open()

            Sql = "SELECT * FROM station ORDER BY stationId"
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            dss.Clear()

            daa.Fill(dss, "station")

            Dim stn(2), elm(2) As String
            Dim itms = New ListViewItem

            LstViewStations.Items.Clear()
            For i = 0 To dss.Tables("station").Rows.Count - 1
                stn(0) = dss.Tables("station").Rows(i).Item("stationId") '"0123456789"
                If Not IsDBNull(dss.Tables("station").Rows(i).Item("stationName")) Then
                    stn(1) = dss.Tables("station").Rows(i).Item("stationName")
                Else
                    stn(1) = ""
                End If

                itms = New ListViewItem(stn)

                LstViewStations.Items.Add(itms)
            Next

            sql = "SELECT * FROM obselement ORDER BY elementId"
            daa = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conns)
            dss.Clear()
            daa.Fill(dss, "element")
            lstViewElements.Items.Clear()
            For i = 0 To dss.Tables("element").Rows.Count - 1
                elm(0) = dss.Tables("element").Rows(i).Item("elementId")
                If Not IsDBNull(dss.Tables("element").Rows(i).Item("description")) Then
                    elm(1) = dss.Tables("element").Rows(i).Item("description")
                Else ' When Elent Description is empty
                    elm(1) = ""
                End If

                itms = New ListViewItem(elm)
                lstViewElements.Items.Add(itms)
            Next

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MsgBox(ex.Message)
            conns.Close()
        End Try
        conns.Close()
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        'Help.ShowHelp(Me, Application.StartupPath & "\" & HelpProvider1.HelpNamespace, HTMLHelp.HelpPage)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "qcchecks.htm")
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        'If optAbsoluteLimits.Checked = True Then
        frmQCdatesSelection.Show()
        'End If
    End Sub



    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdateDBfromQCReport.Show()
    End Sub


    Private Sub chkAllStations_Click(sender As Object, e As EventArgs) Handles chkAllStations.Click
        If chkAllStations.Checked = False Then
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = False
            Next
            chkAllStations.Text = "Select All Stations"
            LstViewStations.Enabled = True
        Else
            For i = 0 To LstViewStations.Items.Count - 1
                LstViewStations.Items(i).Checked = True
            Next
            chkAllStations.Text = "Unselect All Stations"
            LstViewStations.Enabled = False
        End If
    End Sub



    Private Sub chkAllElements_Click(sender As Object, e As EventArgs) Handles chkAllElements.Click
        If chkAllElements.Checked = False Then
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = False
            Next
            chkAllElements.Text = "Select All Elements"
            lstViewElements.Enabled = True
        Else
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = True
            Next
            chkAllElements.Text = "Unselect All Elements"
            lstViewElements.Enabled = False
        End If
    End Sub

    Private Sub cmdPerformQC_Click(sender As Object, e As EventArgs) Handles cmdPerformQC.Click

        Dim m As Integer, n As Integer, elem1 As Integer, elem2 As Integer
        Dim stnid, elmcode, stnlist, elmlist, stnelm_selected, QcReportFile As String
        Dim stnselected, elmselected As Boolean

        lblDataTransferProgress.Text = "Processing....Please wait!"

        ' List the selected stations
        stnlist = ""
        elmlist = ""
        stnselected = False
        elmselected = False

        ' List the selected stations
        If chkAllStations.Checked = False Then ' When NOT all stations are selected
            For i = 0 To LstViewStations.Items.Count - 1
                If LstViewStations.Items(i).Checked = True Then
                    stnid = LstViewStations.Items(i).SubItems(0).Text
                    stnselected = True
                    If Len(stnlist) = 0 Then
                        stnlist = "RecordedFrom = " & " '" & stnid & "'" 'stnid
                    Else
                        stnlist = stnlist & " OR RecordedFrom = " & "'" & stnid & "'"
                    End If
                    'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                End If
            Next
        Else ' When All stations are selected
            stnselected = True
        End If

        ' List the selected Elements
        If chkAllElements.Checked = False Then ' When NOT all stations are selected
            For i = 0 To lstViewElements.Items.Count - 1
                If lstViewElements.Items(i).Checked = True Then
                    elmcode = lstViewElements.Items(i).SubItems(0).Text
                    elmselected = True
                    If Len(elmlist) = 0 Then
                        elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
                    Else
                        elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
                    End If
                    'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                End If
            Next
        Else ' When All stations are selected
            elmselected = True
        End If

        ' Contruct the Stations and Elements selction criteria string
        If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
        If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

        ' Set the stations and elements selection conditions
        If stnselected = False Or elmselected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
            MsgBox(" Selections not properly done. Check values!", MsgBoxStyle.Exclamation, "Selection Error")
            Exit Sub
        Else
            If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = elmlist & " and "
            If chkAllElements.Checked = True And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and "
            If chkAllElements.Checked = True And chkAllStations.Checked = True Then stnelm_selected = ""
            If chkAllElements.Checked = False And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and " & elmlist & " and "
        End If

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM observationInitial where year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "obsInitial")

            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'Get required data for QC interelement comparison
            sql1 = "SELECT * from qc_interelement_relationship_definition"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            da1.Fill(ds1, "interElement")
            n = ds1.Tables("interElement").Rows.Count
            conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

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


        ' Get folder for the QC reports
        Try
            qcReportsFolderWindows = dsReg.Tables("regData").Rows(7).Item("keyValue")

            'Create qc reports folder if it does not exist
            If Not IO.Directory.Exists(qcReportsFolderWindows) Then IO.Directory.CreateDirectory(qcReportsFolderWindows)

            qcReportsFolderUnix = dsReg.Tables("regData").Rows(8).Item("keyValue")

            ''If Not IO.Directory.Exists(qcReportsFolderUnix) Then IO.Directory.CreateDirectory(qcReportsFolderUnix)
            'QcReportFile = qcReportsFolderWindows & "/qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & "'.csv'"
            'MsgBox(QcReportFile)

            ''Delete the QC Report file if already there
            'If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

            If beginMonth < 10 Then beginYearMonth = beginYear & "0" & beginMonth
            If endMonth < 10 Then endYearMonth = endYear & "0" & beginMonth

            ' create the QC output table if not existing
            'strSQL = "CREATE TABLE IF NOT EXISTS `qcAbsLimits` (`StationId` varchar(15) NOT NULL,`ElementId` bigint(10) DEFAULT NULL,`Datetime` datetime DEFAULT NULL,`YYYY` int(11),`mm` tinyint(4),`dd` tinyint(4),`hh` tinyint(4),`obsValue` varchar(10),`limitValue` varchar(10),`limitType` varchar(10) DEFAULT NULL,`qcStatus` int(11) DEFAULT NULL,`acquisitionType` int(11) DEFAULT NULL,`obsLevel` varchar(255) DEFAULT NULL,`capturedBy` varchar(255) DEFAULT NULL,`dataForm` varchar(255) DEFAULT NULL,UNIQUE KEY `obsInitialIdentification` (`StationId`,`ElementId`,`Datetime`,`limitType`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
            strSQL = "CREATE TABLE IF NOT EXISTS `qcAbsLimits` (`StationId` varchar(15) NOT NULL,`ElementId` bigint(10) DEFAULT NULL,`Datetime` datetime DEFAULT NULL,`YYYY` int(11),`mm` tinyint(4),`dd` tinyint(4),`hh` tinyint(4),`obsValue` varchar(10),`limitValue` varchar(10),`qcStatus` int(11) DEFAULT NULL,`acquisitionType` int(11) DEFAULT NULL,`obsLevel` varchar(255) DEFAULT NULL,`capturedBy` varchar(255) DEFAULT NULL,`dataForm` varchar(255) DEFAULT NULL,UNIQUE KEY `obsInitialIdentification` (`StationId`,`ElementId`,`Datetime`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
            Try
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message & " Can't create QC Output limits table")
            End Try

            'Update QC status for selected date range from 0 to 1
            strSQL = "update observationinitial set qcstatus=1 where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            'Try

            'Execute query
            objCmd.ExecuteNonQuery()
            ' MsgBox("QC status updated!", MsgBoxStyle.Information)
            'Catch ex As MySql.Data.MySqlClient.MySqlException
            '    'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above

            If ex.HResult = "-2147467259" Then
                MsgBox("Repeat QC encountered on some records")
            Else
                MsgBox(ex.Message)
            End If
        End Try

        If optAbsoluteLimits.Checked = True Then

            'Upper limits checks
            QcReportFile = qcReportsFolderWindows & "\qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

            'Delete the file for upper limit Qc report if already there
            If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

            ' Empty the QC values table
            Try
                strSQL = "TRUNCATE qcabslimits;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
            '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
            '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
            '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
            '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
            '   "upperLimit <> '' and cast(obsValue as INT) > cast(upperlimit as INT) " & _
            '   "into outfile '" & qcReportsFolderUnix & "/qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

            strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " & _
                     "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " & _
                     "from observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
                     "upperlimit <> '' and cast(obsValue as INT) > cast(upperlimit as INT);"

            ''"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()

                ' Output QC Report
                'OutputQCReport(210, qcReportsFolderWindows & "\qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv")
                OutputQCReport(210, QcReportFile)

                msgTxtQCReportsOutUpperLimits = "QC upper limits report saved to: "
                MsgBox(msgTxtQCReportsOutUpperLimits & QcReportFile, MsgBoxStyle.Information)


            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)

            End Try

            'Lower limits checks

            QcReportFile = qcReportsFolderWindows & "\qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

            'Delete the file for lower limit Qc report if already there
            If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

            ' Empty the QC values table
            Try
                strSQL = "TRUNCATE qcabslimits;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
            '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
            '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
            '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
            '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
            '   "lowerLimit <> '' and cast(obsValue as INT) < cast(lowerlimit as INT) " & _
            '   "into outfile '" & qcReportsFolderUnix & "/qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

            strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " & _
                      "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " & _
                     "From observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
                      "lowerLimit <> '' and cast(obsValue as INT) < cast(lowerlimit as INT);"

            '"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()

                ' Output QC Report
                OutputQCReport(211, QcReportFile)

                msgTxtQCReportsOutLowerLimits = "QC lower limits report saved to: "
                'MsgBox(msgTxtQCReportsOutLowerLimits & qcReportsFolderWindows & "\qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)
                MsgBox(msgTxtQCReportsOutLowerLimits & QcReportFile, MsgBoxStyle.Information)


                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
            End Try

            'Interelement comparison checks
        ElseIf optInterElement.Checked = True Then
            'Loop through the combination of elements in the [qc_interelement_relationship_definition] table
            For m = 0 To n - 1
                elem1 = ds1.Tables("interElement").Rows(m).Item("elementId_1")
                elem2 = ds1.Tables("interElement").Rows(m).Item("elementId_2")
                'MsgBox("Element1=" & elem1 & "  Element2=" & elem2)

                'Select element 1 for inter-eleent comparison
                'strSQL = "DELETE from qc_interelement_1"
                strSQL = "TRUNCATE qc_interelement_1"

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

                strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " & _
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " & _
                    "WHERE describedby=" & elem1 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear & _
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
                'strSQL = "DELETE from qc_interelement_2"
                strSQL = "TRUNCATE qc_interelement_2"

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
                strSQL = "INSERT IGNORE INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2) " & _
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " & _
                    "WHERE describedby=" & elem2 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear & _
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
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " & _
                        "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                        "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 " &
                        "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                        "'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

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
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " & _
                        "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                        "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " & _
                        "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " & _
                        "and day(obsDatetime_1)=day(obsDatetime_2) " &
                        "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                        "'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

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

            msgTxtQCReportsOutInterelement = "Inter-element reports sent to "
            MsgBox(msgTxtQCReportsOutInterelement & qcReportsFolderWindows, MsgBoxStyle.Information)
        End If
        lblDataTransferProgress.Text = "Processing complete!"

        conn.Close()
    End Sub
    Sub OutputQCReport(fp As Integer, fl As String)
        Dim x As Long
        Dim dat, hder As String
        'conn.ConnectionString = myConnectionString
        'conn.Open()

        Try
            FileOpen(fp, fl, OpenMode.Output)

            sql = "SELECT * FROM qcabslimits;"
            ds.Clear()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "qcabslimits")
            x = ds.Tables("qcabslimits").Rows.Count

            ' Output Headers
            hder = ds.Tables("qcabslimits").Columns(0).ColumnName
            For j = 1 To ds.Tables("qcabslimits").Columns.Count - 1
                hder = hder & "," & ds.Tables("qcabslimits").Columns(j).ColumnName
            Next

            Print(fp, hder)
            PrintLine(fp)
            ' Outputv data values
            For i = 0 To x - 1
                dat = ds.Tables("qcabslimits").Rows(i).Item(0)
                For j = 1 To ds.Tables("qcabslimits").Columns.Count - 1
                    dat = dat & "," & ds.Tables("qcabslimits").Rows(i).Item(j)
                Next
                Print(fp, dat)
                PrintLine(fp)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(fp)
        End Try
        'conn.Close()
        FileClose(fp)
        CommonModules.ViewFile(fl)
    End Sub

    Private Sub chkAllElements_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllElements.CheckedChanged

    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click

    End Sub
End Class