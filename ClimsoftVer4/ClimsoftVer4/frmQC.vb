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


    Private Sub optInterElement_CheckedChanged(sender As Object, e As EventArgs) Handles optInterElement.CheckedChanged
        ' Disable selection of elements since the list is set in database for the elements to be compared.
        If optInterElement.Checked = True Then
            lstViewElements.Enabled = False
            chkAllElements.Enabled = False
            chkAllElements.Checked = False
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = False
            Next
        Else
            lstViewElements.Enabled = True
            chkAllElements.Enabled = True
        End If
    End Sub

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
        lblDataTransferProgress.Text = ""
        txtBeginYear.Text = ""
        txtEndYear.Text = ""
        chkAllStations.Checked = False
        chkAllElements.Checked = False

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
                    cmbstation.Items.Add(stn(1))
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
                    cmbElement.Items.Add(elm(1))
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

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        'MsgBox(LstViewStations.Items(0).SubItems(1).Text & " " & cmbstation.Text)

        'For i = 0 To LstViewStations.Items.Count - 1
        '    If LstViewStations.Items(i).SubItems(1).Text = cmbstation.Text Then
        '        LstViewStations.Items(i).Checked = True
        '    End If

        'Next
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
            chkAllStations.Checked = True
            'LstViewStations.Enabled = False
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
            chkAllElements.Checked = True
            'lstViewElements.Enabled = False
        End If
    End Sub

    Private Sub cmdPerformQC_Click(sender As Object, e As EventArgs) Handles cmdPerformQC.Click

        Dim m As Integer, n As Integer, elem1 As Integer, elem2 As Integer
        Dim stnid, elmcode, stnlist, elmlist, stnelm_selected, QcReportFile As String
        Dim stnselected, elmselected As Boolean

        Me.Cursor = Cursors.WaitCursor

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
        Else ' When All Elements are selected
            elmselected = True
        End If

        If optInterElement.Checked = True Then elmselected = True

        ' Contruct the Stations and Elements selction criteria string
        If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
        If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

        ' Set the stations and elements selection conditions
        If stnselected = False Or elmselected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
            MsgBox(" Selections not properly done. Check values!", MsgBoxStyle.Exclamation, "Selection Error")
            Me.Cursor = Cursors.Default
            Exit Sub
        Else
            If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = elmlist & " and "
            If chkAllElements.Checked = True And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and "
            If chkAllElements.Checked = True And chkAllStations.Checked = True Then stnelm_selected = ""
            If chkAllElements.Checked = False And chkAllStations.Checked = False Then
                stnelm_selected = stnlist & " and " & elmlist & " and "
                If optInterElement.Checked = True Then stnelm_selected = stnlist & " and "
            End If
            'If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = ""

        End If

        myConnectionString = frmLogin.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString

            conn.Open()

            '' The following code was commented because its role was not clear and it was cause timeout error when the observationinitial table became big

            'sql = "SELECT * FROM observationInitial where year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth
            'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            'da.Fill(ds, "obsInitial")

            'Get required data for QC interelement comparison
            sql1 = "SELECT * from qc_interelement_relationship_definition"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

            ' Set timeout period to unlimited
            da1.SelectCommand.CommandTimeout = 0

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

            objCmd.CommandTimeout = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            objCmd.CommandTimeout = 0
            objCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message & " Can't create QC Output limits table")
            Me.Cursor = Cursors.Default
        End Try

        'Update QC status for selected date range from 0 to 1 for Absolute Limits check
        If optAbsoluteLimits.Checked = True Then
            strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

        End If

        'MsgBox(strSQL)
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        Try

            'Execute query
            objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
            objCmd.ExecuteNonQuery()
            'MsgBox("QC status updated!", MsgBoxStyle.Information)
        Catch ex As MySql.Data.MySqlClient.MySqlException
            'Ignore expected error i.e. error of Duplicates in MySqlException

        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above

            If ex.HResult = "-2147467259" Then
                'MsgBox("Repeat QC encountered on some records")
            Else
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
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
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
            '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
            '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
            '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
            '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
            '   "upperLimit <> '' and cast(obsValue as INT) > cast(upperlimit as INT) " & _
            '   "into outfile '" & qcReportsFolderUnix & "/qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

            strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                     "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "from observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
                     "upperlimit <> '' and cast(obsValue as SIGNED) > cast(upperlimit as SIGNED);"

            ''"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()
                ' Output QC Report
                'OutputQCReport(210, qcReportsFolderWindows & "\qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv")
                OutputQCReport(210, QcReportFile)
                FileClose(210)
                'msgTxtQCReportsOutUpperLimits = "QC upper limits report saved to: "
                'MsgBox(msgTxtQCReportsOutUpperLimits & QcReportFile, MsgBoxStyle.Information)


            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default

            End Try

            'Lower limits checks

            QcReportFile = qcReportsFolderWindows & "\qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

            'Delete the file for lower limit Qc report if already there
            If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

            ' Empty the QC values table
            Try
                strSQL = "TRUNCATE qcabslimits;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
            '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
            '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
            '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
            '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
            '   "lowerLimit <> '' and cast(obsValue as INT) < cast(lowerlimit as INT) " & _
            '   "into outfile '" & qcReportsFolderUnix & "/qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

            strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                      "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "From observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
                      "lowerLimit <> '' and cast(obsValue as SIGNED) < cast(lowerlimit as SIGNED);"

            '"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

                ' Output QC Report
                OutputQCReport(211, QcReportFile)
                FileClose(211)
                'msgTxtQCReportsOutLowerLimits = "QC lower limits report saved to: "
                ''MsgBox(msgTxtQCReportsOutLowerLimits & qcReportsFolderWindows & "\qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)
                'MsgBox(msgTxtQCReportsOutLowerLimits & QcReportFile, MsgBoxStyle.Information)


                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            'Interelement comparison checks
        ElseIf optInterElement.Checked = True Then

            'MsgBox(strSQL)
            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


            'Loop through the combination of elements in the [qc_interelement_relationship_definition] table
            For m = 0 To n - 1
                elem1 = ds1.Tables("interElement").Rows(m).Item("elementId_1")
                elem2 = ds1.Tables("interElement").Rows(m).Item("elementId_2")
                'MsgBox("Element1=" & elem1 & "  Element2=" & elem2)

                'Update QC status for selected date range from 0 to 1 for InterElement check
                'strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnlist & " and describedBy = " & Year(obsdatetime) between " & beginYear & " And " & endYear & " And month(obsdatetime) between " & beginMonth & " And " & endMonth & ";"
                strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnlist & " and (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
                If chkAllStations.Checked Then strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
                    objCmd.ExecuteNonQuery()
                Catch x As Exception
                    If x.HResult = "-2147467259" Then
                        'MsgBox("Repeat QC encountered on some records")
                    Else
                        MsgBox(x.Message)
                        Me.Cursor = Cursors.Default
                    End If
                End Try


                'Select element 1 for inter-eleent comparison
                'strSQL = "DELETE from qc_interelement_1"
                strSQL = "TRUNCATE qc_interelement_1"

                QcReportFile = qcReportsFolderWindows & "\qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv"

                'Delete the Qc report file if already there
                If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

                ' Create the Command for executing query and set its properties
                objCmd.CommandTimeout = 0
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0

                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_1 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                End Try

                If stnselected = True Then
                    strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
                    "Select recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
                    "WHERE obsvalue <> '' and describedby=" & elem1 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth

                    ' When all stations are selected, stations list will not be appear in the query so as to include all of them
                    If chkAllStations.Checked = True Then
                        strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
                        "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
                        "WHERE obsvalue <> '' and describedby=" & elem1 & " and year(obsdatetime) between " & beginYear & " and " & endYear &
                        " and month(obsdatetime) between " & beginMonth & " and " & endMonth
                    End If

                Else
                    strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
                    "WHERE obsvalue <> '' and describedby=" & elem1 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth
                End If
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query

                    objCmd.CommandTimeout = 0
                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_1 created!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    ''MsgBox(ex.Message)
                    'MsgBox(strSQL)
                    Me.Cursor = Cursors.Default
                End Try

                'Select element 2 for inter-eleent comparison
                'strSQL = "DELETE from qc_interelement_2"
                strSQL = "TRUNCATE qc_interelement_2"

                ' Create the Command for executing query and set its properties
                objCmd.CommandTimeout = 0
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0
                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_2 cleared!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                End Try
                If stnselected = True Then

                    strSQL = "INSERT IGNORE INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2) " &
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
                    "WHERE obsvalue <> '' and describedby=" & elem2 & "  and year(obsdatetime) between " & beginYear & " and " & endYear &
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ""

                Else
                    strSQL = "INSERT IGNORE INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2) " &
                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
                    "WHERE obsvalue <> '' and describedby=" & elem2 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ""
                End If
                ' Create the Command for executing query and set its properties
                objCmd.CommandTimeout = 0
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0
                    objCmd.ExecuteNonQuery()
                    'MsgBox("Table qc_interelement_2 created!")
                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above

                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                End Try

                'Carry out interelement comparison
                If (elem1 = 2 And elem2 = 3) Or (elem1 = 101 And elem2 = 102) Or (elem1 = 102 And elem2 = 103) Then
                    'strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                    '    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                    '    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 " &
                    '    "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                    '"'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                        "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                        "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 and cast(obsValue_1 as SIGNED) < cast(obsValue_2 as SIGNED);"

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
                    'strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                    '    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                    '    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " &
                    '    "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " &
                    '    "and day(obsDatetime_1)=day(obsDatetime_2) " &
                    '    "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
                    '"'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                           "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                           "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " &
                           "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " &
                           "and day(obsDatetime_1)=day(obsDatetime_2) And cast(obsValue_1 As SIGNED) < cast(obsValue_2 As SIGNED);"
                End If

                '' Create the Command for executing query and set its properties
                'objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


                Try
                    ''Execute query
                    'objCmd.CommandTimeout = 0
                    'objCmd.ExecuteNonQuery()

                    OutputQcInterElementReport(QcReportFile, strSQL, elem1, elem2)


                    'MsgBox("QC inter-element report( send To: d:/data/qc_values_interelement_set2_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

                    'Catch ex As MySql.Data.MySqlClient.MySqlException
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above

                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                End Try

            Next m

            'msgTxtQCReportsOutInterelement = "Inter-element reports sent to "
            'MsgBox(msgTxtQCReportsOutInterelement & qcReportsFolderWindows, MsgBoxStyle.Information)
        End If
        lblDataTransferProgress.Text = "Processing complete!"
        Me.Cursor = Cursors.Default
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
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "qcabslimits")
            x = ds.Tables("qcabslimits").Rows.Count

            ' Not to proceed if no QC data to output
            If x = 0 Then
                MsgBox("No QC errors found")
                Exit Sub
            End If

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

                '' Insert text qualifier ito the stationid field to ensure that it is saved as a character string in QC output text file
                'dat = """" & dat & """"

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

    Sub OutputQcInterElementReport(fl As String, sql1 As String, elm1 As String, elm2 As String)
        Dim t As Long
        Dim dt As String

        'MsgBox(fl)

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
        da.SelectCommand.CommandTimeout = 0
        ds.Clear()
        da.Fill(ds, "qcInterElements")
        t = ds.Tables("qcInterElements").Rows.Count

        Try
            If t > 1 Then

                FileOpen(111, fl, OpenMode.Output)
                ' Outputv data values
                For i = 0 To t - 1
                    dt = ds.Tables("qcInterElements").Rows(i).Item(0)
                    For j = 1 To ds.Tables("qcInterElements").Columns.Count - 1
                        dt = dt & "," & ds.Tables("qcInterElements").Rows(i).Item(j)
                    Next
                    Print(111, dt)
                    PrintLine(111)
                Next
                msgTxtQCReportsOutInterelement = "QC report for comparison of Elements " & elm1 & " and " & elm2 & " sent to "
                MsgBox(msgTxtQCReportsOutInterelement & qcReportsFolderWindows, MsgBoxStyle.Information)
            Else
                MsgBox("No QC errors found for comparison of Elements " & elm1 & " and " & elm2)
            End If

            FileClose(111)

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(111)
        End Try

    End Sub

    Private Sub lstViewElements_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lstViewElements.ItemChecked
        'If lstViewElements.CheckedItems.Count < lstViewElements.Items.Count Then
        '    chkAllElements.Checked = False
        '    chkAllElements.Text = "Select All Elements"
        'Else
        '    chkAllElements.Checked = True
        '    chkAllElements.Text = "Unselect All Elements"
        'End If
    End Sub

    Private Sub LstViewStations_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LstViewStations.ItemChecked
        '    If LstViewStations.CheckedItems.Count < LstViewStations.Items.Count Then
        '        chkAllStations.Checked = False
        '        chkAllStations.Text = "Select All Stations"
        '    Else
        '        chkAllStations.Checked = True
        '        chkAllStations.Text = "Unselect All Stations"
        '    End If
    End Sub

    Private Sub LstViewStations_Click(sender As Object, e As EventArgs) Handles LstViewStations.Click
        'If LstViewStations.CheckedItems.Count < LstViewStations.Items.Count Then
        '    chkAllStations.Checked = False
        '    chkAllStations.Text = "Select All Stations"
        'Else
        '    chkAllStations.Checked = True
        '    chkAllStations.Text = "Unselect All Stations"
        'End If
    End Sub

    Private Sub cmbstation_Click(sender As Object, e As EventArgs) Handles cmbstation.Click
        For i = 0 To LstViewStations.Items.Count - 1
            If LstViewStations.Items(i).SubItems(1).Text = cmbstation.Text Then
                LstViewStations.Items(i).Checked = True
                Exit For
            End If
        Next
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            For i = 0 To LstViewStations.Items.Count - 1
                If LstViewStations.Items(i).SubItems(0).Text = cmbstation.Text Then
                    LstViewStations.Items(i).Checked = True
                    cmbstation.Text = ""
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbElement_Click(sender As Object, e As EventArgs) Handles cmbElement.Click
        For i = 0 To lstViewElements.Items.Count - 1
            If lstViewElements.Items(i).SubItems(1).Text = cmbElement.Text Then
                lstViewElements.Items(i).Checked = True
                Exit For
            End If
        Next
    End Sub

    Private Sub cmbElement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbElement.KeyPress
        If Asc(e.KeyChar) = 13 Then
            For i = 0 To lstViewElements.Items.Count - 1
                If lstViewElements.Items(i).SubItems(0).Text = cmbElement.Text Then
                    lstViewElements.Items(i).Checked = True
                    cmbElement.Text = ""
                    Exit For
                End If
            Next
        End If
    End Sub
End Class