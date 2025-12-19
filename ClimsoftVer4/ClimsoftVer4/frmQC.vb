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

Imports System.IO
Imports System.Security.Cryptography
Imports Mysqlx
Imports Org.BouncyCastle.Crypto.Prng

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

            Me.Cursor = Cursors.WaitCursor

            conns.ConnectionString = frmLogin.txtusrpwd.Text
            conns.Open()

            'sql = "SELECT * FROM station ORDER BY stationId"
            sql = "SELECT stationId, stationName FROM station INNER JOIN observationinitial ON stationId = recordedFrom
                   GROUP BY stationId ORDER BY stationId;"
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

            'sql = "SELECT * FROM obselement ORDER BY elementId"
            sql = "SELECT elementId, description FROM obselement INNER JOIN observationinitial ON elementId = describedBy
                   GROUP BY elementId ORDER BY elementId;"
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
            Me.Cursor = Cursors.Default
        Catch ex As MySql.Data.MySqlClient.MySqlException
            Me.Cursor = Cursors.Default
            MsgBox(ex.Message)
            conns.Close()
        End Try
        conns.Close()

        'translate form controls
        ClsTranslations.TranslateForm(Me)
        'todo in future this will be done automatically by TranslateForms(Me)
        ClsTranslations.TranslateComponent(LstViewStations, True)
        ClsTranslations.TranslateComponent(lstViewElements, True)
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
            chkAllElements.Text = ClsTranslations.GetTranslation("Select All Elements")
            lstViewElements.Enabled = True
        Else
            For i = 0 To lstViewElements.Items.Count - 1
                lstViewElements.Items(i).Checked = True
            Next
            chkAllElements.Text = ClsTranslations.GetTranslation("Unselect All Elements")
            chkAllElements.Checked = True
            'lstViewElements.Enabled = False
        End If
    End Sub


    'Private Sub cmdPerformQC_Click(sender As Object, e As EventArgs) Handles cmdPerformQC.Click

    '    Dim m As Integer, n As Integer, elem1 As Integer, elem2 As Integer
    '    Dim stnid, elmcode, stnlist, elmlist, stnelm_selected, QcReportFile As String
    '    Dim stnselected, obsv_nameelected As Boolean

    '    Me.Cursor = Cursors.WaitCursor

    '    lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing....Please wait!")

    '    ' List the selected stations
    '    stnlist = ""
    '    elmlist = ""
    '    stnselected = False
    '    obsv_nameelected = False


    '    ' List the selected stations
    '    If chkAllStations.Checked = False Then ' When NOT all stations are selected
    '        For i = 0 To LstViewStations.Items.Count - 1
    '            If LstViewStations.Items(i).Checked = True Then
    '                stnid = LstViewStations.Items(i).SubItems(0).Text
    '                stnselected = True
    '                If Len(stnlist) = 0 Then
    '                    stnlist = "RecordedFrom = " & " '" & stnid & "'" 'stnid
    '                Else
    '                    stnlist = stnlist & " OR RecordedFrom = " & "'" & stnid & "'"
    '                End If
    '                'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
    '            End If
    '        Next
    '    Else ' When All stations are selected
    '        stnselected = True
    '    End If

    '    ' List the selected Elements
    '    If chkAllElements.Checked = False Then ' When NOT all stations are selected
    '        For i = 0 To lstViewElements.Items.Count - 1
    '            If lstViewElements.Items(i).Checked = True Then
    '                elmcode = lstViewElements.Items(i).SubItems(0).Text
    '                obsv_nameelected = True
    '                If Len(elmlist) = 0 Then
    '                    elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
    '                Else
    '                    elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
    '                End If
    '                'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
    '            End If
    '        Next
    '    Else ' When All Elements are selected
    '        obsv_nameelected = True
    '    End If

    '    If optInterElement.Checked = True Then obsv_nameelected = True

    '    ' Contruct the Stations and Elements selction criteria string
    '    If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
    '    If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

    '    ' Set the stations and elements selection conditions
    '    If stnselected = False Or obsv_nameelected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
    '        MsgBox(ClsTranslations.GetTranslation(" Selections not properly done. Check values!"), MsgBoxStyle.Exclamation, ClsTranslations.GetTranslation("Selection Error"))
    '        Me.Cursor = Cursors.Default
    '        Exit Sub
    '    Else
    '        If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = elmlist & " and "
    '        If chkAllElements.Checked = True And chkAllStations.Checked = False Then stnelm_selected = stnlist & " and "
    '        If chkAllElements.Checked = True And chkAllStations.Checked = True Then stnelm_selected = ""
    '        If chkAllElements.Checked = False And chkAllStations.Checked = False Then
    '            stnelm_selected = stnlist & " and " & elmlist & " and "
    '            If optInterElement.Checked = True Then stnelm_selected = stnlist & " and "
    '        End If
    '        'If chkAllElements.Checked = False And chkAllStations.Checked = True Then stnelm_selected = ""

    '    End If

    '    myConnectionString = frmLogin.txtusrpwd.Text
    '    Try
    '        conn.ConnectionString = myConnectionString

    '        conn.Open()

    '        '' The following code was commented because its role was not clear and it was cause timeout error when the observationinitial table became big

    '        'sql = "SELECT * FROM observationInitial where year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth
    '        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        'da.Fill(ds, "obsInitial")

    '        'Get required data for QC interelement comparison
    '        sql1 = "SELECT * from qc_interelement_relationship_definition"
    '        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

    '        ' Set timeout period to unlimited
    '        da1.SelectCommand.CommandTimeout = 0

    '        da1.Fill(ds1, "interElement")
    '        n = ds1.Tables("interElement").Rows.Count
    '        conn.Close()

    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        MessageBox.Show(ex.Message)
    '        conn.Close()
    '    End Try

    '    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

    '    myConnectionString = frmLogin.txtusrpwd.Text

    '    conn.ConnectionString = myConnectionString
    '    conn.Open()

    '    beginYear = Val(txtBeginYear.Text)
    '    endYear = Val(txtEndYear.Text)
    '    beginMonth = Val(txtBeginMonth.Text)
    '    endMonth = Val(txtEndMonth.Text)

    '    beginYearMonth = beginYear & beginMonth
    '    endYearMonth = endYear & endMonth


    '    ' Get folder for the QC reports

    '    Try
    '        qcReportsFolderWindows = dsReg.Tables("regData").Rows(7).Item("keyValue")

    '        'Create qc reports folder if it does not exist
    '        If Not IO.Directory.Exists(qcReportsFolderWindows) Then IO.Directory.CreateDirectory(qcReportsFolderWindows)

    '        qcReportsFolderUnix = dsReg.Tables("regData").Rows(8).Item("keyValue")

    '        ''If Not IO.Directory.Exists(qcReportsFolderUnix) Then IO.Directory.CreateDirectory(qcReportsFolderUnix)
    '        'QcReportFile = qcReportsFolderWindows & "/qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & "'.csv'"
    '        'MsgBox(QcReportFile)

    '        ''Delete the QC Report file if already there
    '        'If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

    '        If beginMonth < 10 Then beginYearMonth = beginYear & "0" & beginMonth
    '        If endMonth < 10 Then endYearMonth = endYear & "0" & beginMonth

    '        ' create the QC output table if not existing
    '        'strSQL = "CREATE TABLE IF NOT EXISTS `qcAbsLimits` (`StationId` varchar(15) NOT NULL,`ElementId` bigint(10) DEFAULT NULL,`Datetime` datetime DEFAULT NULL,`YYYY` int(11),`mm` tinyint(4),`dd` tinyint(4),`hh` tinyint(4),`obsValue` varchar(10),`limitValue` varchar(10),`limitType` varchar(10) DEFAULT NULL,`qcStatus` int(11) DEFAULT NULL,`acquisitionType` int(11) DEFAULT NULL,`obsLevel` varchar(255) DEFAULT NULL,`capturedBy` varchar(255) DEFAULT NULL,`dataForm` varchar(255) DEFAULT NULL,UNIQUE KEY `obsInitialIdentification` (`StationId`,`ElementId`,`Datetime`,`limitType`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"
    '        strSQL = "CREATE TABLE IF NOT EXISTS `qcAbsLimits` (`StationId` varchar(15) NOT NULL,`ElementId` bigint(10) DEFAULT NULL,`Datetime` datetime DEFAULT NULL,`YYYY` int(11),`mm` tinyint(4),`dd` tinyint(4),`hh` tinyint(4),`obsValue` varchar(10),`limitValue` varchar(10),`qcStatus` int(11) DEFAULT NULL,`acquisitionType` int(11) DEFAULT NULL,`obsLevel` varchar(255) DEFAULT NULL,`capturedBy` varchar(255) DEFAULT NULL,`dataForm` varchar(255) DEFAULT NULL,UNIQUE KEY `obsInitialIdentification` (`StationId`,`ElementId`,`Datetime`)) ENGINE=InnoDB DEFAULT CHARSET=latin1;"

    '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '        objCmd.CommandTimeout = 0
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Try
    '        objCmd.CommandTimeout = 0
    '        objCmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message & ClsTranslations.GetTranslation(" Can't create QC Output limits table"))
    '        Me.Cursor = Cursors.Default
    '    End Try

    '    'Update QC status for selected date range from 0 to 1 for Absolute Limits check
    '    If optAbsoluteLimits.Checked = True Then
    '        strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

    '    End If

    '    'MsgBox(strSQL)
    '    ' Create the Command for executing query and set its properties
    '    objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '    Try

    '        'Execute query
    '        objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
    '        objCmd.ExecuteNonQuery()
    '        'MsgBox("QC status updated!", MsgBoxStyle.Information)
    '    Catch ex As MySql.Data.MySqlClient.MySqlException
    '        'Ignore expected error i.e. error of Duplicates in MySqlException

    '    Catch ex As Exception
    '        'Dispaly error message if it is different from the one trapped in 'Catch' execption above

    '        If ex.HResult = "-2147467259" Then
    '            'MsgBox("Repeat QC encountered on some records")
    '        Else
    '            MsgBox(ex.Message)
    '            Me.Cursor = Cursors.Default
    '        End If
    '    End Try

    '    If optAbsoluteLimits.Checked = True Then

    '        'Upper limits checks
    '        QcReportFile = qcReportsFolderWindows & "\qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

    '        'Delete the file for upper limit Qc report if already there
    '        If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

    '        ' Empty the QC values table
    '        Try
    '            strSQL = "TRUNCATE qcabslimits;"
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
    '            objCmd.CommandTimeout = 0
    '            objCmd.ExecuteNonQuery()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Me.Cursor = Cursors.Default
    '        End Try

    '        'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
    '        '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
    '        '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
    '        '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
    '        '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
    '        '   "upperLimit <> '' and cast(obsValue as INT) > cast(upperlimit as INT) " & _
    '        '   "into outfile '" & qcReportsFolderUnix & "/qc_report_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

    '        strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
    '                 "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
    '                 "from observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
    '                 "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
    '                 "upperlimit <> '' and cast(obsValue as SIGNED) > cast(upperlimit as SIGNED);"

    '        ''"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','upperlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

    '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '        Try
    '            'Execute query
    '            objCmd.CommandTimeout = 0
    '            objCmd.ExecuteNonQuery()
    '            ' Output QC Report
    '            'OutputQCReport(210, qcReportsFolderWindows & "\qc_values_upperlimit_" & beginYearMonth & "_" & endYearMonth & ".csv")
    '            OutputQCReport(210, QcReportFile)
    '            FileClose(210)
    '            'msgTxtQCReportsOutUpperLimits = "QC upper limits report saved to: "
    '            'MsgBox(msgTxtQCReportsOutUpperLimits & QcReportFile, MsgBoxStyle.Information)


    '        Catch ex As Exception
    '            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '            MsgBox(ex.Message)
    '            Me.Cursor = Cursors.Default

    '        End Try

    '        'Lower limits checks

    '        QcReportFile = qcReportsFolderWindows & "\qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

    '        'Delete the file for lower limit Qc report if already there
    '        If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

    '        ' Empty the QC values table
    '        Try
    '            strSQL = "TRUNCATE qcabslimits;"
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
    '            objCmd.CommandTimeout = 0
    '            objCmd.ExecuteNonQuery()
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            Me.Cursor = Cursors.Default
    '        End Try

    '        'strSQL = "select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _
    '        '  "union all select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm, " & _
    '        '   "day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm from " & _
    '        '   "observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " & _
    '        '   "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " & _
    '        '   "lowerLimit <> '' and cast(obsValue as INT) < cast(lowerlimit as INT) " & _
    '        '   "into outfile '" & qcReportsFolderUnix & "/qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

    '        strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
    '                  "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
    '                 "From observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
    '                 "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
    '                  "lowerLimit <> '' and cast(obsValue as SIGNED) < cast(lowerlimit as SIGNED);"

    '        '"union all select 'StationId','ElementId','DateTime','yyyy','mm','dd','hh','ObsValue','lowerlimit','qcStatus','acquisitionType','obsLevel','capturedBy','dataForm' " & _

    '        ' Create the Command for executing query and set its properties
    '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '        Try
    '            'Execute query
    '            objCmd.CommandTimeout = 0
    '            objCmd.ExecuteNonQuery()

    '            ' Output QC Report
    '            OutputQCReport(211, QcReportFile)
    '            FileClose(211)
    '            'msgTxtQCReportsOutLowerLimits = "QC lower limits report saved to: "
    '            ''MsgBox(msgTxtQCReportsOutLowerLimits & qcReportsFolderWindows & "\qc_values_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)
    '            'MsgBox(msgTxtQCReportsOutLowerLimits & QcReportFile, MsgBoxStyle.Information)


    '            'Catch ex As MySql.Data.MySqlClient.MySqlException
    '            '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '        Catch ex As Exception
    '            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '            MsgBox(ex.Message)
    '            Me.Cursor = Cursors.Default
    '        End Try

    '        'Interelement comparison checks
    '    ElseIf optInterElement.Checked = True Then

    '        'MsgBox(strSQL)
    '        ' Create the Command for executing query and set its properties
    '        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


    '        'Loop through the combination of elements in the [qc_interelement_relationship_definition] table
    '        For m = 0 To n - 1
    '            elem1 = ds1.Tables("interElement").Rows(m).Item("elementId_1")
    '            elem2 = ds1.Tables("interElement").Rows(m).Item("elementId_2")
    '            'MsgBox("Element1=" & elem1 & "  Element2=" & elem2)

    '            'Update QC status for selected date range from 0 to 1 for InterElement check
    '            'strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnlist & " and describedBy = " & Year(obsdatetime) between " & beginYear & " And " & endYear & " And month(obsdatetime) between " & beginMonth & " And " & endMonth & ";"
    '            strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnlist & " and (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
    '            If chkAllStations.Checked Then strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '            Try
    '                objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
    '                objCmd.ExecuteNonQuery()
    '            Catch x As Exception
    '                If x.HResult = "-2147467259" Then
    '                    'MsgBox("Repeat QC encountered on some records")
    '                Else
    '                    MsgBox(x.Message)
    '                    Me.Cursor = Cursors.Default
    '                End If
    '            End Try


    '            'Select element 1 for inter-eleent comparison
    '            'strSQL = "DELETE from qc_interelement_1"
    '            strSQL = "TRUNCATE qc_interelement_1"

    '            QcReportFile = qcReportsFolderWindows & "\qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv"

    '            'Delete the Qc report file if already there
    '            If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

    '            ' Create the Command for executing query and set its properties
    '            objCmd.CommandTimeout = 0
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '            Try
    '                'Execute query
    '                objCmd.CommandTimeout = 0

    '                objCmd.ExecuteNonQuery()
    '                'MsgBox("Table qc_interelement_1 cleared!")
    '                'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '            Catch ex As Exception
    '                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '                MsgBox(ex.Message)
    '                Me.Cursor = Cursors.Default
    '            End Try

    '            If stnselected = True Then
    '                strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
    '                "Select recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
    '                "WHERE obsvalue <> '' and describedby=" & elem1 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
    '                " and month(obsdatetime) between " & beginMonth & " and " & endMonth

    '                ' When all stations are selected, stations list will not be appear in the query so as to include all of them
    '                If chkAllStations.Checked = True Then
    '                    strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
    '                    "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
    '                    "WHERE obsvalue <> '' and describedby=" & elem1 & " and year(obsdatetime) between " & beginYear & " and " & endYear &
    '                    " and month(obsdatetime) between " & beginMonth & " and " & endMonth
    '                End If

    '            Else
    '                strSQL = "INSERT IGNORE INTO qc_interelement_1(stationId_1,elementId_1,obsDatetime_1,obsValue_1,qcStatus_1,acquisitionType_1,obsLevel_1,capturedBy_1,dataForm_1) " &
    '                "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
    '                "WHERE obsvalue <> '' and describedby=" & elem1 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
    '                " and month(obsdatetime) between " & beginMonth & " and " & endMonth
    '            End If
    '            ' Create the Command for executing query and set its properties
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '            Try
    '                'Execute query

    '                objCmd.CommandTimeout = 0
    '                objCmd.ExecuteNonQuery()
    '                'MsgBox("Table qc_interelement_1 created!")
    '                'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '            Catch ex As Exception
    '                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '                ''MsgBox(ex.Message)
    '                'MsgBox(strSQL)
    '                Me.Cursor = Cursors.Default
    '            End Try

    '            'Select element 2 for inter-eleent comparison
    '            'strSQL = "DELETE from qc_interelement_2"
    '            strSQL = "TRUNCATE qc_interelement_2"

    '            ' Create the Command for executing query and set its properties
    '            objCmd.CommandTimeout = 0
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '            Try
    '                'Execute query
    '                objCmd.CommandTimeout = 0
    '                objCmd.ExecuteNonQuery()
    '                'MsgBox("Table qc_interelement_2 cleared!")
    '                'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '            Catch ex As Exception
    '                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '                MsgBox(ex.Message)
    '                Me.Cursor = Cursors.Default
    '            End Try
    '            If stnselected = True Then

    '                strSQL = "INSERT IGNORE INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2) " &
    '                "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
    '                "WHERE obsvalue <> '' and describedby=" & elem2 & "  and year(obsdatetime) between " & beginYear & " and " & endYear &
    '                " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ""

    '            Else
    '                strSQL = "INSERT IGNORE INTO qc_interelement_2(stationId_2,elementId_2,obsDatetime_2,obsValue_2,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2) " &
    '                "SELECT recordedfrom,describedby,obsdatetime,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm FROM observationinitial " &
    '                "WHERE obsvalue <> '' and describedby=" & elem2 & " and " & stnlist & " and year(obsdatetime) between " & beginYear & " and " & endYear &
    '                " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ""
    '            End If
    '            ' Create the Command for executing query and set its properties
    '            objCmd.CommandTimeout = 0
    '            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

    '            Try
    '                'Execute query
    '                objCmd.CommandTimeout = 0
    '                objCmd.ExecuteNonQuery()
    '                'MsgBox("Table qc_interelement_2 created!")
    '                'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '            Catch ex As Exception
    '                'Dispaly error message if it is different from the one trapped in 'Catch' execption above

    '                MsgBox(ex.Message)
    '                Me.Cursor = Cursors.Default
    '            End Try

    '            'Carry out interelement comparison
    '            If (elem1 = 2 And elem2 = 3) Or (elem1 = 101 And elem2 = 102) Or (elem1 = 102 And elem2 = 103) Then
    '                'strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
    '                '    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
    '                '    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 " &
    '                '    "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
    '                '"'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

    '                strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
    '                    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
    '                    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 and cast(obsValue_1 as SIGNED) < cast(obsValue_2 as SIGNED);"

    '                ' '' Create the Command for executing query and set its properties
    '                ''objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
    '                ''Try
    '                ''    'Execute query
    '                ''    objCmd.ExecuteNonQuery()
    '                ''    MsgBox("QC inter-element report(1) send to: d:/data/qc_values_interelement_set1_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

    '                ''    'MsgBox("Table qc_interelement_2 cleared!")
    '                ''    'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                ''    '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '                ''Catch ex As Exception
    '                ''    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
    '                ''    MsgBox(ex.Message)
    '                ''End Try

    '            ElseIf (elem1 = 2 And elem2 = 101) Or (elem1 = 101 And elem2 = 3) Then
    '                'strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
    '                '    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
    '                '    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " &
    '                '    "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " &
    '                '    "and day(obsDatetime_1)=day(obsDatetime_2) " &
    '                '    "and cast(obsValue_1 as INT) < cast(obsValue_2 as INT) into outfile " &
    '                '"'" & qcReportsFolderUnix & "/qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv' fields terminated by',';"

    '                strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
    '                       "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
    '                       "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and " &
    '                       "year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) " &
    '                       "and day(obsDatetime_1)=day(obsDatetime_2) And cast(obsValue_1 As SIGNED) < cast(obsValue_2 As SIGNED);"
    '            End If

    '            '' Create the Command for executing query and set its properties
    '            'objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


    '            Try
    '                ''Execute query
    '                'objCmd.CommandTimeout = 0
    '                'objCmd.ExecuteNonQuery()

    '                OutputQcInterElementReport(QcReportFile, strSQL, elem1, elem2)


    '                'MsgBox("QC inter-element report( send To: d:/data/qc_values_interelement_set2_" & beginYearMonth & "_" & endYearMonth & ".csv'", MsgBoxStyle.Information)

    '                'Catch ex As MySql.Data.MySqlClient.MySqlException
    '                '    'Ignore expected error i.e. error of Duplicates in MySqlException
    '            Catch ex As Exception
    '                'Dispaly error message if it is different from the one trapped in 'Catch' execption above

    '                MsgBox(ex.Message)
    '                Me.Cursor = Cursors.Default
    '            End Try

    '        Next m

    '        'msgTxtQCReportsOutInterelement = "Inter-element reports sent to "
    '        'MsgBox(msgTxtQCReportsOutInterelement & qcReportsFolderWindows, MsgBoxStyle.Information)
    '    End If
    '    lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing complete!")
    '    Me.Cursor = Cursors.Default
    '    conn.Close()
    'End Sub


    Private Sub cmdPerformQC_Click(sender As Object, e As EventArgs) Handles cmdPerformQC.Click
        If optMissObstime.Checked Then
            UpdateObsDatetime()
            Exit Sub
        End If

        Dim m, n, elem1, elem2 As Integer
        Dim stnid, elmcode, stnlist, elmlist, stnelm_selected, stnelm_local, QcReportFile, strSQLog, qcLog As String
        Dim stnselected, obsv_nameelected As Boolean

        Me.Cursor = Cursors.WaitCursor

        lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing....Please wait!")
        lblDataTransferProgress.Refresh()
        ' List the selected stations
        stnlist = ""
        elmlist = ""
        stnselected = False
        obsv_nameelected = False


        ' List the selected stations
        If chkAllStations.Checked = False Then ' When NOT all stations are selected
            For i = 0 To LstViewStations.Items.Count - 1
                If LstViewStations.Items(i).Checked = True Then
                    stnid = LstViewStations.Items(i).SubItems(0).Text
                    stnselected = True
                    If Len(stnlist) = 0 Then
                        stnlist = "recordedFrom = " & " '" & stnid & "'" 'stnid
                    Else
                        stnlist = stnlist & " OR recordedFrom = " & "'" & stnid & "'"
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
                    obsv_nameelected = True
                    If Len(elmlist) = 0 Then
                        elmlist = "describedBy = " & " '" & elmcode & "'" 'stnid
                    Else
                        elmlist = elmlist & " OR describedBy = " & "'" & elmcode & "'"
                    End If
                    'stnlist = stnlist & " or recordedFrom = " & LstViewStations.Items(i).SubItems(0).Text
                End If
            Next
        Else ' When All Elements are selected
            obsv_nameelected = True
        End If

        If optInterElement.Checked = True Then obsv_nameelected = True

        ' Construct the Stations and Elements selction criteria string
        If Len(stnlist) > 0 Then stnlist = "(" & stnlist & ")"
        If Len(elmlist) > 0 Then elmlist = "(" & elmlist & ")"

        ' Set the stations and elements selection conditions
        If stnselected = False Or obsv_nameelected = False Or Len(txtBeginYear.Text) <> 4 Or Len(txtEndYear.Text) <> 4 Then
            MsgBox(ClsTranslations.GetTranslation(" Selections not properly done. Check values!"), MsgBoxStyle.Exclamation, ClsTranslations.GetTranslation("Selection Error"))
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
        conn.ConnectionString = myConnectionString
        conn.Open()

        Try
            'Get required data for QC interelement comparison
            sql1 = "SELECT * from qc_interelement_relationship_definition"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

            ' Set timeout period to unlimited
            da.SelectCommand.CommandTimeout = 0

            da.Fill(ds, "interElement")
            n = ds.Tables("interElement").Rows.Count
            'conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            'conn.Close()
        End Try

        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        'myConnectionString = frmLogin.txtusrpwd.Text

        'conn.ConnectionString = myConnectionString
        'conn.Open()

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


            ''Delete the QC Report file if already there

            If beginMonth < 10 Then beginYearMonth = beginYear & "0" & beginMonth
            If endMonth < 10 Then endYearMonth = endYear & "0" & beginMonth

            ' create the QC output table if not existing
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
            MsgBox(ex.Message & ClsTranslations.GetTranslation(" Can't create QC Output limits table"))
            Me.Cursor = Cursors.Default
        End Try

        'Update QC status and QC Log for selected date range from 0 to 1 for Absolute Limits check which is mandatory
        If optAbsoluteLimits.Checked = True Then
            strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                      UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '1') WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                      UPDATE observationinitial Set qcTypeLog = '1' WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " AND qcTypeLog is NULL;"

            '' Update QC Type Log
            'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
            'UpdateqcLog(strSQLog, 1)

        End If

        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

        Try
            'Execute query
            objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
            objCmd.ExecuteNonQuery()

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

            Try
                'Delete the file for upper limit Qc report if already there
                If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

                ' Empty the QC values table

                strSQL = "TRUNCATE qcabslimits;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            stnelm_local = stnelm_selected.Replace("recordedFrom", "stationelement.recordedFrom")
            stnelm_local = stnelm_local.Replace("describedBy", "stationelement.describedBy")

            Try
                'QC check for local (station's) limits
                strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                     "select stationelement.recordedfrom,stationelement.describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "From observationinitial, stationelement " &
                     "Where observationinitial.recordedfrom = stationelement.recordedfrom And observationinitial.describedBy = stationelement.describedBy And " & stnelm_local & " year(obsdatetime) " &
                     "between " & beginYear & " And " & endYear & " And month(obsdatetime) between " & beginMonth & " And " & endMonth & " And  " &
                     "upperlimit <> '' and cast(obsValue as SIGNED) > cast(upperlimit as SIGNED);"

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            Try
                'QC check for global limits
                strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                         "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,upperlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                         "from observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
                         "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
                         "upperlimit <> '' and cast(obsValue as SIGNED) > cast(upperlimit as SIGNED);"

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            ' Output QC Report for Upper Limits

            Try

                OutputQCReport(210, QcReportFile, "Upper Limit")
                FileClose(210)

                'Do QC for Lower limits checks
                QcReportFile = qcReportsFolderWindows & "\qc_report_lowerlimit_" & beginYearMonth & "_" & endYearMonth & ".csv"

                'Delete the file for lower limit Qc report if already there
                If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

                ' Empty the QC values table

                strSQL = "TRUNCATE qcabslimits;"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            ' QC for local limits
            Try
                strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                     "select stationelement.recordedfrom,stationelement.describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "From observationinitial, stationelement " &
                     "Where observationinitial.recordedfrom = stationelement.recordedfrom And observationinitial.describedBy = stationelement.describedBy And " & stnelm_local & " year(obsdatetime) " &
                     "between " & beginYear & " And " & endYear & " And month(obsdatetime) between " & beginMonth & " And " & endMonth & " And  " &
                     "lowerLimit <> '' and cast(obsValue as SIGNED) < cast(lowerlimit as SIGNED);"

                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)
                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            ' QC for global limits
            Try
                strSQL = "INSERT IGNORE INTO qcabslimits(StationId,ElementId,DateTime,yyyy,mm,dd,hh,ObsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm) " &
                      "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd, hour(obsdatetime) as hh,obsvalue,lowerlimit,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "From observationinitial,obselement where describedBy=elementId and " & stnelm_selected & " year(obsdatetime) " &
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and  " &
                      "lowerLimit <> '' and cast(obsValue as SIGNED) < cast(lowerlimit as SIGNED);"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                'Execute query
                objCmd.CommandTimeout = 0
                objCmd.ExecuteNonQuery()

            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
                Me.Cursor = Cursors.Default
            End Try

            ' Do QC for Lower limits checks
            OutputQCReport(211, QcReportFile, "Lower Limit")
            FileClose(211)

            'Interelement comparison checks
        ElseIf optInterElement.Checked = True Then
            txtProgress.Visible = True

            '' Update QC Status and QC Type Log
            'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
            'UpdateqcLog(strSQLog, 2)

            'Loop through the combination of elements in the [qc_interelement_relationship_definition] table
            sql1 = "SELECT * from qc_interelement_relationship_definition"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)
            da1.SelectCommand.CommandTimeout = 0
            ds1.Clear()
            da1.Fill(ds1, "interElement")
            For m = 0 To ds1.Tables("interElement").Rows.Count - 1 ' n - 1
                elem1 = ds1.Tables("interElement").Rows(m).Item("elementId_1")
                elem2 = ds1.Tables("interElement").Rows(m).Item("elementId_2")
                'MsgBox("Element1=" & elem1 & "  Element2=" & elem2)

                strSQL = "UPDATE IGNORE observationinitial set qcstatus=1 where " & stnlist & " and (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                          UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '2') WHERE " & stnlist & " and (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                          Update observationinitial Set qcTypeLog = '2'  WHERE " & stnlist & " and (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " AND qcTypeLog is NULL;"

                If chkAllStations.Checked Then
                    strSQL = "UPDATE observationinitial set qcstatus=1 WHERE (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                              UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '2') WHERE (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & ";
                              UPDATE observationinitial Set qcTypeLog = '2' WHERE (describedBy = '" & elem1 & "' or describedBy = '" & elem2 & "' ) and Year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " AND qcTypeLog is NULL;"
                End If

                txtProgress.Text = "Updating QC Status to 1......"
                txtProgress.Refresh()

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
                strSQL = "TRUNCATE qc_interelement_1;TRUNCATE qc_interelement_2 "

                QcReportFile = qcReportsFolderWindows & "\qc_interelement_" & elem1 & "_" & elem2 & "_" & beginYearMonth & "_" & endYearMonth & ".csv"

                Try
                    'Delete the Qc report file if already there
                    If IO.File.Exists(QcReportFile) Then IO.File.Delete(QcReportFile)

                    ' Create the Command for executing query and set its properties
                    objCmd.CommandTimeout = 0
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


                    'Execute query
                    txtProgress.Text = "Refreshing QC interlement tables......"
                    txtProgress.Refresh()
                    objCmd.CommandTimeout = 0

                    objCmd.ExecuteNonQuery()
                    '    'Ignore expected error i.e. error of Duplicates in MySqlException
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                    txtProgress.Visible = False
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

                    txtProgress.Text = "Obtaining values for Element " & elem1 & " ......"
                    txtProgress.Refresh()

                    objCmd.CommandTimeout = 0
                    objCmd.ExecuteNonQuery()

                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    txtProgress.Visible = False
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
                txtProgress.Text = "Obtaining values for Element " & elem2 & " ......"
                txtProgress.Refresh()

                objCmd.CommandTimeout = 0
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0
                    objCmd.ExecuteNonQuery()
                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                    txtProgress.Visible = False
                End Try

                'Carry out interelement comparison
                ' Compare Hourly elements

                If (elem1 = 2 And elem2 = 3) Or (elem1 = 101 And elem2 = 102) Or (elem1 = 102 And elem2 = 103) Then
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime1','obsdatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                    "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                    "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and obsDatetime_1=obsDatetime_2 and cast(obsValue_1 as SIGNED) < cast(obsValue_2 as SIGNED);"

                    ' compare Daily and Hourly Elements
                ElseIf (elem1 = 2 And elem2 = 101) Or (elem1 = 101 And elem2 = 3) Then
                    strSQL = "SELECT 'stationId','elementId_1','elementId_2','obsDatetime_1','obsDatetime_2','yyyy','mm','dd','hh_1','hh_2','obsValue_1','obsValue_2','qcStatus_1','qcStatus_2','acquisitionType_2','obsLevel_2','capturedBy_2','dataForm_2' " &
                           "union all SELECT stationId_1,elementId_1,elementId_2,obsDatetime_1,obsDatetime_2,year(obsDatetime_1) as yyyy, month(obsDatetime_1) as mm, day(obsDatetime_1) as dd, hour(obsDatetime_1) as hh_1, hour(obsDatetime_2) as hh_2,obsValue_1,obsValue_2,qcStatus_1,qcStatus_2,acquisitionType_2,obsLevel_2,capturedBy_2,dataForm_2 " &
                           "from qc_interelement_1,qc_interelement_2 WHERE stationId_1=stationId_2 and year(obsDatetime_1)=year(obsDatetime_2) and month(obsDatetime_1)=month(obsDatetime_2) and day(obsDatetime_1)=day(obsDatetime_2) And cast(obsValue_1 As SIGNED) < cast(obsValue_2 As SIGNED);"
                End If

                Try
                    txtProgress.Text = "Comparing Elements " & elem1 & " and " & elem2 & " ......"
                    txtProgress.Refresh()

                    OutputQcInterElementReport(QcReportFile, strSQL, elem1, elem2)

                Catch ex As Exception
                    'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                    MsgBox(ex.Message)
                    Me.Cursor = Cursors.Default
                    'txtProgress.Visible = False
                End Try
                'txtProgress.Visible = False
            Next m

        ElseIf optdiurnalrange.Checked = True Then
            txtProgress.Visible = False

            strSQL = "select recordedfrom,describedby,obsdatetime,year(obsdatetime) as yyyy, month(obsdatetime) as mm,day(obsdatetime) as dd,hour(obsdatetime) as hh,obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm " &
                     "from observationinitial where " & stnelm_selected & " year(obsdatetime) " &
                     "between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " and qcStatus = 1 ;"

            ' Empty Qc Limits table
            sql = "DELETE from qcabslimits"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
            objCmd.ExecuteNonQuery()

            qcDiurnalRange(strSQL)

            '' Update QC Type Log
            'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
            'UpdateqcLog(strSQLog, 3)
            strSQL = "UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '3') WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                      UPDATE observationinitial Set qcTypeLog = '3' WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " AND qcTypeLog is NULL;"
            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
                objCmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            '' Update QC Type Log
            'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
            'UpdateqcLog(strSQLog, 1)


            'End If


        ElseIf optdaysconsistency.Checked = True Or opthrsconsistency.Checked Then
            txtProgress.Visible = False

            Dim QcFile, obsInterval As String

            If optdaysconsistency.Checked Then
                strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

                'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
                'UpdateqcLog(strSQLog, 4)
                ' Update QC Status and QC Log
                strSQL = "UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '4') WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                         UPDATE observationinitial Set qcTypeLog = '4' WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " AND qcTypeLog is NULL;"
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
                    objCmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                QcFile = qcReportsFolderWindows & "\qc_report_consecutivedays_" & beginYearMonth & "_" & endYearMonth & ".csv"
                obsInterval = "Day"
            Else
                strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

                '' Update QC Type Log
                'strSQLog = "SELECT recordedFrom,describedBy,obsDatetime,qcTypelog FROM observationinitial where " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"
                'UpdateqcLog(strSQLog, 5)

                ' Update QC Status and QC Log
                strSQL = "UPDATE observationinitial Set qcTypeLog = CONCAT(qcTypeLog, '5') WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";
                         UPDATE observationinitial Set qcTypeLog = '5' WHERE " & stnelm_selected & " year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & " AND qcTypeLog is NULL;"
                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                Try
                    'Execute query
                    objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
                    objCmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                QcFile = qcReportsFolderWindows & "\qc_report_consecutivehours_" & beginYearMonth & "_" & endYearMonth & ".csv"
                obsInterval = "Hour"
            End If

            ' Empty Qc Limits table
            Try
                sql = "DELETE from qcabslimits"
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                objCmd.CommandTimeout = 0 'Assign sufficient time out period to allow execution the update query to completion
                objCmd.ExecuteNonQuery()

                ' Open QC output report file
                FileOpen(212, QcFile, OpenMode.Output)
                ' Print header
                PrintLine(212, "StationId,ElementId,Datetime,YYYY,mm,dd,hh,obsValue,obsPrev" & obsInterval & ",qcStatus,acquisitionType,obsLevel,capturedBy,dataForm")

                For i = 0 To LstViewStations.Items.Count - 1
                    If LstViewStations.Items(i).Checked = True Then
                        stnid = LstViewStations.Items(i).SubItems(0).Text
                        For j = 0 To lstViewElements.Items.Count - 1
                            If lstViewElements.Items(j).Checked = True Then
                                elmcode = lstViewElements.Items(j).SubItems(0).Text
                                strSQL = "SELECT recordedFrom AS STN, describedBy AS COD, obsDatetime AS DT,Year(obsDatetime) as YY, Month(obsDatetime) AS MM, Day(obsDatetime) AS DD, Hour(obsDatetime) AS HH, obsvalue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm AS Val FROM observationinitial " &
                                          "where recordedFrom = " & stnid & " and describedBy ='" & elmcode & "' and year(obsdatetime) between " & beginYear & " and " & endYear & " and month(obsdatetime) between " & beginMonth & " and " & endMonth & ";"

                                If optdaysconsistency.Checked Then
                                    qcConsecutiveObs(strSQL, "d", 4)
                                Else
                                    qcConsecutiveObs(strSQL, "h", 5)
                                End If

                            End If
                        Next
                    End If
                Next

                FileClose(212)
                CommonModules.ViewFile(QcFile)
                Me.Cursor = Cursors.Default
                conn.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
                FileClose(212)
                Me.Cursor = Cursors.Default
                conn.Close()
                lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing Failed!")
            End Try

            Exit Sub

        End If
        lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing complete!")
        'txtProgress.Visible = False
        Me.Cursor = Cursors.Default
        conn.Close()
    End Sub
    Sub OutputQCReport(fp As Integer, fl As String, limitType As String)
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
                MsgBox(ClsTranslations.GetTranslation("No QC errors found for " & limitType))
                Exit Sub
            End If

            With ds.Tables("qcabslimits")
                ' Output Headers
                hder = .Columns(0).ColumnName
                For j = 1 To .Columns.Count - 1
                    hder = hder & "," & .Columns(j).ColumnName
                Next

                PrintLine(fp, hder)
                'PrintLine(fp)
                ' Outputv data values
                For i = 0 To x - 1
                    'If Not IsNumeric(ds.Tables("qcabslimits").Rows(i).Item("limitValue")) Then Continue For
                    dat = .Rows(i).Item(0)

                    '' Insert text qualifier ito the stationid field to ensure that it is saved as a character string in QC output text file
                    'dat = """" & dat & """"

                    For j = 1 To .Columns.Count - 1
                        'dat = dat & "," & ds.Tables("qcabslimits").Rows(i).Item(j)
                        If j = 8 And Not IsNumeric(.Rows(i).Item("limitValue")) Then
                            dat = dat & ","
                        Else
                            dat = dat & "," & .Rows(i).Item(j)
                        End If
                        ' Update the QC Type Log

                    Next

                    Print(fp, dat & Chr(10))
                    'PrintLine(fp, dat)
                    'PrintLine(fp)
                Next
            End With
            FileClose(fp)
            CommonModules.ViewFile(fl)

        Catch ex As Exception
            MsgBox(ex.Message)
            FileClose(fp)
        End Try

    End Sub

    Sub OutputQcInterElementReport(fl As String, sql1 As String, elm1 As String, elm2 As String)
        Dim t As Long
        Dim dt As String

        'MsgBox(fl)
        txtProgress.Text = "Preparing QC output for " & elm1 & " and " & elm2 & " ......"
        txtProgress.Refresh()

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

                    Print(111, dt & Chr(10))
                    'Print(111, dt)
                    'PrintLine(111)
                Next
                msgTxtQCReportsOutInterelement = ClsTranslations.GetTranslation("QC report for comparison of Elements ") & " " & elm1 & ClsTranslations.GetTranslation(" and ") & " " & elm2 & " " & ClsTranslations.GetTranslation(" sent to ")
                MsgBox(msgTxtQCReportsOutInterelement & qcReportsFolderWindows, MsgBoxStyle.Information)
                'txtProgress.Text = msgTxtQCReportsOutInterelement
                txtProgress.Refresh()
            Else
                txtProgress.Text = ClsTranslations.GetTranslation("No QC errors found for comparison of Elements ") & " " & elm1 & " " & ClsTranslations.GetTranslation(" and ") & " " & elm2
                txtProgress.Refresh()
                'MsgBox(ClsTranslations.GetTranslation("No QC errors found for comparison of Elements") & " " & elm1 & " " & ClsTranslations.GetTranslation("and") & " " & elm2)
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

    Private Sub optMissObstime_CheckedChanged(sender As Object, e As EventArgs) Handles optMissObstime.CheckedChanged
        If optMissObstime.Checked Then
            pnlQcStandard.Enabled = False
            LstViewStations.Enabled = False
            lstViewElements.Enabled = False
            cmbstation.Enabled = False
            cmbElement.Enabled = False
            chkAllStations.Enabled = False
            chkAllElements.Enabled = False
        Else
            pnlQcStandard.Enabled = True
            LstViewStations.Enabled = True
            lstViewElements.Enabled = True
            cmbstation.Enabled = True
            cmbElement.Enabled = True
            chkAllStations.Enabled = True
            chkAllElements.Enabled = True
        End If
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

    Sub qcDiurnalRange(sql As String)
        Dim mean, stdev, errRec, QcFile As String
        'Dim code, yy, mm As Integer
        Dim dev, limitValue, stdevDiff As Double

        Try
            'txtProgress.Text = sql
            'MsgBox(sql)

            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da1.SelectCommand.CommandTimeout = 0
            ds1.Clear()
            da1.Fill(ds1, "dailyobs")

            QcFile = qcReportsFolderWindows & "\qc_report_diurnalRange_" & beginYearMonth & "_" & endYearMonth & ".csv"

            'Delete the QC report file for upper limit Qc report if already there
            If IO.File.Exists(QcFile) Then IO.File.Delete(QcFile)

            FileOpen(212, QcFile, OpenMode.Output)
            ' Print headline
            PrintLine(212, "StationId,ElementId,Datetime,YYYY,mm,dd,hh,obsValue,limitValue,qcStatus,acquisitionType,obsLevel,capturedBy,dataForm")

            With ds1.Tables("dailyobs")

                'Compute Statistics
                For i = 0 To .Rows.Count - 1
                    'qcLogUpdate(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), 3)
                    'Compute monthly statistical change
                    statitical_change(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), .Rows(i).Item(7), .Rows(i).Item(7))
                Next

                For i = 0 To .Rows.Count - 1
                    errRec = ""
                    'Monthly_MEAN_STDEV(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(3), .Rows(i).Item(4), mean, stdev)
                    If Len(.Rows(i).Item(7)) = 0 Then Continue For
                    Statistic_limits(.Rows(i).Item(0), .Rows(i).Item(1), DateAndTime.Year(.Rows(i).Item(2)), DateAndTime.Month(.Rows(i).Item(2)), DateAndTime.Day(.Rows(i).Item(2)), mean, stdev, "d")

                    If Math.Abs(Val(.Rows(i).Item(7) - mean)) > stdev * 2 Then
                        stdevDiff = Math.Abs(Val(.Rows(i).Item(7)) - Val(mean)) - Val(stdev)
                        dev = Val(.Rows(i).Item(7)) - Val(mean)
                        If dev > 0 Then
                            limitValue = Val(mean) + stdev
                        Else
                            limitValue = Val(mean) - stdev
                        End If
                        limitValue = Math.Round(limitValue, 0)
                        errRec = .Rows(i).Item(0) & "," & .Rows(i).Item(1) & "," & .Rows(i).Item(2) & "," & .Rows(i).Item(3) & "," & .Rows(i).Item(4) & "," & .Rows(i).Item(5) & "," & .Rows(i).Item(6) & "," & .Rows(i).Item(7) & "," & Math.Round(limitValue, 0) & "," & .Rows(i).Item(8) & "," & .Rows(i).Item(9) & "," & .Rows(i).Item(10) & "," & .Rows(i).Item(11) & "," & .Rows(i).Item(12)
                        PrintLine(212, errRec)
                    End If

                Next

                lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing complete!")
            End With
            'conn.Close()
            FileClose(212)
            CommonModules.ViewFile(QcFile)
        Catch x As Exception
            MsgBox(x.Message & " qcDiurnalRange")
            'conn.Close()
            FileClose(212)
            lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing failed!")
        End Try
    End Sub
    Sub qcConsecutiveObs(sql As String, period As String, qcType As Integer)
        Dim ds2 As New DataSet, da2 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim prevobs, prevDate, errRec As String
        Dim maxrows As Long
        Dim obsDiff, stsDiff, mean, stdev As Double

        Try
            'MsgBox(sql)
            'conn.Open()
            'txtProgress.Visible = True
            'txtProgress.Text = sql
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da2.SelectCommand.CommandTimeout = 0
            ds2.Clear()
            da2.Fill(ds2, "dailyobs")
            maxrows = ds2.Tables("dailyobs").Rows.Count
            Dim diffValues(maxrows) As String

            If ds2.Tables("dailyobs").Rows.Count > 0 Then

                With ds2.Tables("dailyobs")

                    ' Compute Statistics
                    For i = 0 To .Rows.Count - 1

                        If Len(.Rows(i).Item(7)) = 0 Then Continue For

                        prevDate = DateAdd(period, -1, .Rows(i).Item(2))
                        prevDate = DateAndTime.Year(prevDate) & "-" & DateAndTime.Month(prevDate) & "-" & DateAndTime.Day(prevDate) & " " & DateAndTime.Hour(prevDate) & ":" & DateAndTime.Minute(prevDate) & ":" & DateAndTime.Second(prevDate)

                        prevobs = ""
                        dailyObs(.Rows(i).Item(0), .Rows(i).Item(1), prevDate, prevobs)
                        If prevobs = "" Then Continue For
                        'If Len(.Rows(i).Item(7)) = 0 Or Len(prevobs) = 0 Then Continue For
                        obsDiff = Val(.Rows(i).Item(7)) - Val((prevobs))

                        ' Compute monthly statistical change
                        statitical_change(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), .Rows(i).Item(7), Math.Abs(obsDiff))
                    Next

                    ' Compute Consistency QC
                    For i = 0 To .Rows.Count - 1
                        If Len(.Rows(i).Item(7)) = 0 Then Continue For
                        prevDate = DateAdd(period, -1, .Rows(i).Item(2))
                        prevDate = DateAndTime.Year(prevDate) & "-" & DateAndTime.Month(prevDate) & "-" & DateAndTime.Day(prevDate) & " " & DateAndTime.Hour(prevDate) & ":" & DateAndTime.Minute(prevDate) & ":" & DateAndTime.Second(prevDate)
                        prevobs = ""

                        dailyObs(.Rows(i).Item(0), .Rows(i).Item(1), prevDate, prevobs)
                        If prevobs = "" Then Continue For
                        If Len(.Rows(i).Item(7)) = 0 Or Len(prevobs) = 0 Then Continue For

                        obsDiff = Val(.Rows(i).Item(7)) - Val((prevobs))
                        'stsDiff = ""
                        Statistic_limits(.Rows(i).Item(0), .Rows(i).Item(1), DateAndTime.Year(.Rows(i).Item(2)), DateAndTime.Month(.Rows(i).Item(2)), DateAndTime.Day(.Rows(i).Item(2)), mean, stdev, period)

                        'If Len(.Rows(i).Item(7)) > 0 And Len(prevobs) > 0 And Val(stsDiff) <> 0 And Math.Abs(obsDiff) > stsDiff + 20 Then
                        If Math.Abs(obsDiff) > (mean + stdev * 3) Then
                            errRec = .Rows(i).Item(0)
                            For j = 1 To 12
                                If j = 7 Then
                                    errRec = errRec & "," & .Rows(i).Item(j) & "," & prevobs
                                Else
                                    errRec = errRec & "," & .Rows(i).Item(j)
                                End If
                            Next
                            'qcLogUpdate(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), qcType)
                            PrintLine(212, errRec)
                        End If
                        'qcLogUpdate(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), qcType)
                    Next

                    lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing complete!")
                End With
            End If
            'conn.Close()
        Catch x As Exception
            MsgBox(x.Message & " at qcConsecutiveObs")
            'conn.Close()
            lblDataTransferProgress.Text = ClsTranslations.GetTranslation("Processing failed!")
        End Try
    End Sub
    Sub Monthly_MEAN_STDEV(stn As String, elm As String, yy As Integer, mm As Integer, ByRef MEAN As String, ByRef STD As String)
        Dim dsv As New DataSet
        Dim dav As MySql.Data.MySqlClient.MySqlDataAdapter

        sql = "SELECT AVG(obsvalue) As MEAN, STD(obsValue) As STDEV From observationinitial " &
               "Where RecordedFrom = '" & stn & "' AND describedBy = '" & elm & "' and Year(obsDatetime) = " & yy & " and Month(obsDatetime) = " & mm & " GROUP by Year(obsDatetime), Month(obsDatetime);"
        'txtProgress.Text = sql

        Try

            dav = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dav.SelectCommand.CommandTimeout = 0
            dsv.Clear()
            dav.Fill(dsv, "MEANSTDEV")

            MEAN = dsv.Tables("MEANSTDEV").Rows(0).Item(0)
            STD = dsv.Tables("MEANSTDEV").Rows(0).Item(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub dailyObs(stn As String, elm As String, dt As String, ByRef prevObs As String)
        Dim dsf As New DataSet
        Dim daf As MySql.Data.MySqlClient.MySqlDataAdapter

        sql = "SELECT recordedFrom AS STN, describedBy AS COD, obsDatetime AS DT,Year(obsDatetime) YY, Month(obsDatetime) AS MM, Day(obsDatetime) AS DD, obsvalue AS Val FROM observationinitial " &
               "WHERE recordedFrom = '" & stn & "' AND describedBy = '" & elm & "' AND obsDatetime = '" & dt & "';"
        'txtProgress.Text = sql

        Try

            daf = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            daf.SelectCommand.CommandTimeout = 0
            dsf.Clear()
            daf.Fill(dsf, "dailyobs")

            If dsf.Tables("dailyobs").Rows.Count <> 0 Then
                prevObs = dsf.Tables("dailyobs").Rows(0).Item(6)
            Else
                prevObs = ""
            End If
            'STD = dsv.Tables("MEANSTDEV").Rows(0).Item(1)
        Catch ex As Exception
            MsgBox(ex.Message & " at dailyObs")
        End Try
    End Sub

    Sub UpdateqcLog(sqclog As String, qcLogType As String)

        Dim dslog As New DataSet, dalog As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim qcLog As String

        Try
            dalog = New MySql.Data.MySqlClient.MySqlDataAdapter(sqclog, conn)
            ' Set timeout period to unlimited
            dalog.SelectCommand.CommandTimeout = 0
            dslog.Clear()
            dalog.Fill(dslog, "qcLogs")
            With dslog.Tables("qcLogs")
                For i = 0 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(i).Item(3)) Then
                        qcLog = .Rows(i).Item(3) & qcLogType
                    Else
                        qcLog = qcLogType
                    End If

                    qcLogUpdate(.Rows(i).Item(0), .Rows(i).Item(1), .Rows(i).Item(2), qcLog)
                Next
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub qcLogUpdate(id As String, code As Integer, dtTime As String, qcType As String)

        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        dtTime = DateAndTime.Year(dtTime) & "-" & DateAndTime.Month(dtTime) & "-" & DateAndTime.Day(dtTime) & " " & DateAndTime.Hour(dtTime) & ":" & DateAndTime.Minute(dtTime) & ":" & DateAndTime.Second(dtTime)

        ' Update when no Null values exist in qcTypeLog column
        Try
            'sql = "UPDATE observationinitial SET qcTypeLog = Concat(qcTypeLog, '" & qcType & "') WHERE recordedFrom = '" & id & "' and describedBy = '" & code & "' AND obsDatetime = '" & dtTime & "';"

            sql = "UPDATE observationinitial SET qcTypeLog = '" & qcType & "' WHERE recordedFrom = '" & id & "' and describedBy = '" & code & "' AND obsDatetime = '" & dtTime & "';"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            'Execute query
            qry.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ' Update when Null values exist in qcTypeLog column
        Try
            sql1 = "Update observationinitial SET qcTypeLog = '" & qcType & "' WHERE  recordedFrom = '" & id & "' and describedBy = '" & code & "' AND obsDatetime = '" & dtTime & "' AND qcTypeLog IS NULL;"
            'txtProgress.Text = sql1
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql1, conn)
            qry.CommandTimeout = 0
            'Execute query
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub statitical_change(id As String, code As Integer, dttime As String, obs As String, obsDiff As String)

        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        Try
            dttime = DateAndTime.Year(dttime) & "-" & DateAndTime.Month(dttime) & "-" & DateAndTime.Day(dttime) & " " & DateAndTime.Hour(dttime) & ":" & DateAndTime.Minute(dttime) & ":" & DateAndTime.Second(dttime)

            sql = "INSERT IGNORE INTO `qcabslimits` (`StationId`, `ElementId`, `Datetime`, `obsValue`, `limitValue`) VALUES ('" & id & "', '" & code & "', '" & dttime & "', '" & obs & "', '" & obsDiff & "');"
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Statistic_limits(id As String, cod As Integer, yy As Integer, mm As Integer, dd As Integer, ByRef avg As Double, ByRef stdev As Double, period As String)
        Dim dst As New DataSet
        Dim dat As MySql.Data.MySqlClient.MySqlDataAdapter

        Try
            Select Case period
                Case "d"
                    sql = "SELECT id, cod, YY, MM, mean,stdv AS dev FROM (SELECT stationid AS id,Elementid AS cod, YEAR(DATETIME) as YY, Month(DATETIME) as MM, AVG(limitValue) AS mean , STD(limitValue) as stdv FROM qcabslimits
                   GROUP BY stationid,Elementid, YEAR(DATETIME),Month(DATETIME))t
                   where id = '" & id & "' AND cod = '" & cod & "' AND YY = " & yy & " AND MM = " & mm & ";"
                Case "h"
                    sql = "SELECT id, cod, YY, MM, DD, mean,stdv AS dev FROM (SELECT stationid AS id,Elementid AS cod, YEAR(DATETIME) as YY, Month(DATETIME) as MM, Day(DATETIME) as DD, AVG(limitValue) AS mean , STD(limitValue) as stdv FROM qcabslimits
                   GROUP BY stationid,Elementid, YEAR(DATETIME),Month(DATETIME),Day(DATETIME))t
                   where id = '" & id & "' AND cod = '" & cod & "' AND YY = " & yy & " AND MM = " & mm & " AND DD = " & dd & ";"
            End Select

            'txtProgress.Text = sql
            dat = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dat.SelectCommand.CommandTimeout = 0
            dst.Clear()
            dat.Fill(dst, "limits")
            With dst.Tables("limits")
                If .Rows.Count = 1 Then
                    avg = .Rows(0).Item(4)
                    stdev = .Rows(0).Item(5)
                Else
                    avg = ""
                    stdev = ""
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub UpdateObsDatetime()
        Dim obshh, maxRecs As Integer
        Dim dttm, dlydttm, qclog As String
        Dim dsrg As New DataSet
        Dim conh As New MySql.Data.MySqlClient.MySqlConnection
        'Dim darg As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim cmd As New MySql.Data.MySqlClient.MySqlCommand

        Try

            Dim errdir, duplfile As String

            txtProgress.Clear()

            'Get full path for the errors output file
            errdir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\QC"

            ' Create the directory if not existing
            If Not Directory.Exists(errdir) Then
                Directory.CreateDirectory(errdir)
            End If
            ' Create error file
            duplfile = errdir & "\qc_misshrs.csv"
            FileOpen(55, duplfile, OpenMode.Output)

            ' Output headers
            PrintLine(55, "obs_datetime,station_id,element_code, obs_value,obs_table")
            myConnectionString = frmLogin.txtusrpwd.Text
            conh.ConnectionString = myConnectionString

            ' Obtain the daily observation hour from registry
            sql = "SELECT keyValue FROM regkeys WHERE keyName = 'key01';"
            dsrg = MSdataset(sql)
            obshh = dsrg.Tables("recs").Rows(0).Item(0)

            Dim obstbls(1), tbl As String
            Dim tblConfirm(1) As Boolean

            ' Initialize the tables options
            obstbls(0) = "observationfinal"
            obstbls(1) = "observationinitial"

            tblConfirm(0) = False
            tblConfirm(1) = False

            For k = 0 To obstbls.Count - 1
                If MsgBox("Adjust records with the misplaced observation time for table " & obstbls(k) & "?", MsgBoxStyle.YesNo, obstbls(k)) = MsgBoxResult.Yes Then
                    tblConfirm(k) = True

                    ' Delete records with invalid date
                    sql = "DELETE FROM " & obstbls(k) & " WHERE obsDatetime = '0000-00-00 00:00:00';"
                    conh.Open()
                    cmd.Connection = conh
                    cmd.CommandTimeout = 0
                    cmd.CommandText = sql  ' Assign the SQL statement to the Mysql command variable
                    cmd.ExecuteNonQuery()
                    conh.Close()
                End If
            Next

            For j = 0 To obstbls.Count - 1
                If Not tblConfirm(j) Then Continue For
                tbl = obstbls(j)

                ' Extract records with misplaced daily hour
                sql = "SELECT recordedFrom as id, describedBy as code, obsdatetime as dtt," & obshh & "- HOUR(obsdatetime) AS diff,obsvalue,qcTypeLog FROM " & tbl & " INNER JOIN obselement ON describedBy = elementId
                       WHERE " & obshh & " - HOUR(obsdatetime) !=0 AND (Lcase(LEFT(elementtype,5)) = 'daily' OR describedBy < 101);"

                    dsrg = MSdataset(sql)

                With dsrg.Tables("recs")

                    maxRecs = .Rows.Count

                    If maxRecs = 0 Then
                        Continue For
                    Else
                        For i = 0 To maxRecs - 1

                            dttm = .Rows(i).Item("dtt")

                            'dttm = DateAndTime.Year(dttm) & "-" & DateAndTime.Month(dttm) & "-" & DateAndTime.Day(dttm) & " " & DateAndTime.Hour(dttm) & ":00:00"
                            'dlydttm = DateAndTime.Year(dttm) & "-" & DateAndTime.Month(dttm) & "-" & DateAndTime.Day(dttm) & " " & obshh & ":00:00"

                            dttm = DateAndTime.Year(dttm) & "-" & DateAndTime.Month(dttm) & "-" & DateAndTime.Day(dttm) & " " & DateAndTime.Hour(dttm) & ":" & DateAndTime.Minute(dttm) & ":" & DateAndTime.Second(dttm)
                            dlydttm = DateAdd("h", .Rows(i).Item("diff"), dttm)
                            dlydttm = DateAndTime.Year(dlydttm) & "-" & DateAndTime.Month(dlydttm) & "-" & DateAndTime.Day(dlydttm) & " " & DateAndTime.Hour(dlydttm) & ":" & DateAndTime.Minute(dlydttm) & ":" & DateAndTime.Second(dlydttm)

                            If IsDBNull(.Rows(i).Item("qcTypeLog")) Then
                                qclog = 6
                            ElseIf Not IsNumeric(.Rows(i).Item("qcTypeLog")) Then
                                qclog = 6
                            Else
                                qclog = .Rows(i).Item("qcTypeLog") & 6
                            End If

                            Try
                                sql = "UPDATE " & tbl & " SET obsdatetime = DATE_ADD(obsdatetime,INTERVAL " & .Rows(i).Item("diff") & " HOUR),qcTypeLog = '" & qclog & "'
                                       WHERE recordedFrom = '" & .Rows(i).Item("id") & "' AND describedBy= " & .Rows(i).Item("code") & " AND obsdatetime='" & dttm & "';"

                                conh.Open()
                                cmd.Connection = conh
                                cmd.CommandTimeout = 0
                                cmd.CommandText = sql  ' Assign the SQL statement to the Mysql command variable
                                cmd.ExecuteNonQuery()   ' Execute the query

                            Catch x As Exception
                                If x.HResult = -2147467259 Then ' Causes duplications
                                    outPutDublicates(conh, .Rows(i).Item("id"), .Rows(i).Item("code"), dttm, dlydttm, tbl)
                                Else
                                    'MsgBox(x.HResult & ": " & x.Message & "On update records @ UpdateObsDatetime")
                                    txtProgress.Text = x.Message & "On update records @ UpdateObsDatetime"
                                    txtProgress.Refresh()
                                End If
                            End Try
                            conh.Close()
                            txtProgress.Text = "Processing record: " & i + 1 & " of " & maxRecs
                            txtProgress.Refresh()
                        Next i

                    End If

                End With
            Next j

            txtProgress.Text = "Process Completed!"
            FileClose(55)
            Me.Cursor = Cursors.Default
            Dim siz = New FileInfo(duplfile)

            If siz.Length > 59 Then CommonModules.ViewFile(duplfile)
        Catch ex As Exception
            FileClose(55)
            conh.Close()
            Me.Cursor = Cursors.Default
            txtProgress.Text = ex.Message & " @ UpdateObsDatetime" 'MsgBox(x.HResult & ": " & x.Message)
            txtProgress.Refresh()
        End Try
    End Sub

    Sub outPutDublicates(conh As MySql.Data.MySqlClient.MySqlConnection, id As String, cod As Integer, obsdtt As String, dlyobsdtt As String, tbls As String, Optional lvl As String = "surface")

        Dim dsr As New DataSet
        Dim dar As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim cmdpl As New MySql.Data.MySqlClient.MySqlCommand

        Try
            sql = "SELECT obsDatetime,recordedFrom, describedBy,obsValue FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND (obsDatetime = '" & dlyobsdtt & "' OR obsDatetime = '" & obsdtt & "');" 'UNION
            'SELECT obsDatetime,recordedFrom, describedBy,obsValue FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"

            dar = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conh)
            dsr.Clear()
            dar.Fill(dsr, "obs")


            With dsr.Tables("obs")

                If .Rows.Count < 2 Then ' Non duplicate error
                    If .Rows.Count = 0 Then
                        Exit Sub
                    Else
                        PrintLine(55, dlyobsdtt & "," & .Rows(0).Item("recordedFrom") & "," & .Rows(0).Item("describedBy") & "," & .Rows(0).Item("obsValue") & "," & tbls)
                        sql = "DELETE FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"
                    End If
                    ' Duplicate errors
                ElseIf IsDBNull(.Rows(0).Item("obsValue")) And IsDBNull(.Rows(1).Item("obsValue")) Then
                    ' Delete NULL record with wrong observation hour
                    sql = "DELETE FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"

                ElseIf IsDBNull(.Rows(0).Item("obsValue")) Or IsDBNull(.Rows(1).Item("obsValue")) Then
                    ' Output but NULL and non NULL record into a files
                    PrintLine(55, dlyobsdtt & "," & .Rows(0).Item("recordedFrom") & "," & .Rows(0).Item("describedBy") & "," & .Rows(0).Item("obsValue") & "," & tbls)
                    PrintLine(55, obsdtt & "," & .Rows(1).Item("recordedFrom") & "," & .Rows(1).Item("describedBy") & "," & .Rows(1).Item("obsValue") & "," & tbls)
                    ' Delete both records from database
                    sql = "DELETE FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & dlyobsdtt & "';
                          DELETE From " & tbls & " Where recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"

                ElseIf .Rows(0).Item("obsValue") = .Rows(1).Item("obsValue") Then
                    ' Delete record with wrong observation hour
                    sql = "DELETE FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"

                ElseIf .Rows(0).Item("obsValue") <> .Rows(1).Item("obsValue") Then
                    ' Output both records into a files
                    PrintLine(55, dlyobsdtt & "," & .Rows(0).Item("recordedFrom") & "," & .Rows(0).Item("describedBy") & "," & .Rows(0).Item("obsValue") & "," & tbls)
                    PrintLine(55, obsdtt & "," & .Rows(1).Item("recordedFrom") & "," & .Rows(1).Item("describedBy") & "," & .Rows(1).Item("obsValue") & "," & tbls)
                    ' Delete both records from database
                    sql = "DELETE FROM " & tbls & " WHERE recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & dlyobsdtt & "';
                       DELETE From " & tbls & " Where recordedFrom = '" & id & "' AND describedBy=" & cod & " AND obsDatetime = '" & obsdtt & "';"

                End If

                cmdpl.Connection = conh
                cmdpl.CommandTimeout = 0
                cmdpl.CommandText = sql  ' Assign the SQL statement to the Mysql command variable
                cmdpl.ExecuteNonQuery()
            End With
        Catch ex As Exception
            txtProgress.Text = ex.Message & " @ outPutDublicates"
            txtProgress.Refresh()
            'MsgBox(ex.Message & " @ outPutDublicates")
        End Try
    End Sub

    Function MSdataset(sqls As String) As DataSet

        Dim conns As New MySql.Data.MySqlClient.MySqlConnection
        Dim dsr As New DataSet
        Dim dar As New MySql.Data.MySqlClient.MySqlDataAdapter

        myConnectionString = frmLogin.txtusrpwd.Text
        conns.ConnectionString = myConnectionString
        conns.Open()
        Try

            dar = New MySql.Data.MySqlClient.MySqlDataAdapter(sqls, conns)
            dar.SelectCommand.CommandTimeout = 0
            dsr.Clear()
            dar.Fill(dsr, "recs")
            conns.Close()

            Return dsr
        Catch ex As Exception
            'MsgBox("Can't create dataset")
            txtProgress.Text = "Can't create dataset"
            txtProgress.Refresh()
            conns.Close()
            Return Nothing
        End Try
    End Function
End Class