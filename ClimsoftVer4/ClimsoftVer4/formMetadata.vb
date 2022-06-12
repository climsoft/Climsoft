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

Public Class formMetadata
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim ActiveTab As Integer
    Dim metadfrm As New MetadataVariables
    'Dim maxRows As Integer

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub formMetadata_Click(sender As Object, e As EventArgs) Handles Me.Click
        'MsgBox(TabMetadata.SelectedIndex)
    End Sub

    Private Sub formMetadata_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

    End Sub

    Private Sub formMetadata_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If Asc(e.KeyChar) = 13 Then SendKeys.Send("{TAB}")
    End Sub

    Private Sub formMetadata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        SetDataSet("station")
        rec = 0

        populateStations("station", 9, Kount)
        populateSearchStation()
        populateSearchElement()

    End Sub

    Sub SetDataSet(tbl As String)
        Dim sql As String
        Try
            sql = "SELECT * FROM " & tbl
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, tbl)
            Kount = ds.Tables(tbl).Rows.Count
            'MsgBox(Kount)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub TabStation_Click(sender As Object, e As EventArgs) Handles TabStation.Click
    '    MsgBox("Station")
    'End Sub

    Private Sub TabMetadata_Click(sender As Object, e As EventArgs) Handles TabMetadata.Click
        'MsgBox(TabMetadata.SelectedIndex)
        ActiveTab = TabMetadata.SelectedIndex
        Select Case TabMetadata.SelectedIndex
            Case 0 ' Station
                SetDataSet("station")
                rec = 0
                populateStations("station", rec, Kount)

            Case 1 ' obselement
                SetDataSet("obselement")
                rec = 0

                populateElementMetadata("obselement", rec, Kount)
            Case 2 ' StationElement
                FillList(txtStation, "station", "stationId")
                FillList(txtElement, "obselement", "elementId")
                FillList(txtInstrument, "instrument", "instrumentId")
                FillList(txtScheduleClass, "obsscheduleclass", "scheduleClass")

                SetDataSet("stationelement")
                rec = 0

                populateStationElement("stationelement", rec, Kount)
            Case 3 ' Instrument
                FillList(txtInstrStn, "station", "stationId")
                SetDataSet("instrument")
                rec = 0
                'populatePaperArchiveDefinition("instrument", rec, Kount)

                'SetDataSet("instrument")
                'rec = 0
                populateInstrument("instrument", rec, Kount)
            Case 4 ' Station Location History
                FillList(txtlocStn, "station", "stationId")
                SetDataSet("stationlocationhistory")
                rec = 0
                populateStationHistory("stationlocationhistory", rec, Kount)
            Case 5 ' Station Qualifier
                FillList(txtQualifierStation, "station", "stationId")
                SetDataSet("stationqualifier")
                rec = 0
                populateStationQualifier("stationqualifier", rec, Kount)
            Case 6 ' Schedule Class
                FillList(txtClassStation, "station", "stationId")
                SetDataSet("obsscheduleclass")
                rec = 0
                populateScheduleClass("obsscheduleclass", rec, Kount)
            Case 7 ' Physical Feature
                FillList(txtFeatureStation, "station", "stationId")
                SetDataSet("physicalfeature")
                rec = 0

                populatePhysicalFeature("physicalfeature", rec, Kount)
            Case 8 ' Paper Archive
                SetDataSet("paperarchivedefinition")
                rec = 0
                populatePaperArchiveDefinition("paperarchivedefinition", rec, Kount)
        End Select
    End Sub

    Private Sub BindingNavigator1_RefreshItems(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs)

    End Sub


    Sub populateStations(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub

        SetDataSet(frm)

        txtstationId.Text = ds.Tables("station").Rows(num).Item("stationId")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("stationName")) Then txtStationName.Text = ds.Tables("station").Rows(num).Item("stationName")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("wmoid")) Then txtwmoid.Text = ds.Tables("station").Rows(num).Item("wmoid")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("icaoid")) Then txticaoid.Text = ds.Tables("station").Rows(num).Item("icaoid")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("country")) Then txtCountry.Text = ds.Tables("station").Rows(num).Item("country")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("latitude")) Then txtLatitude.Text = ds.Tables("station").Rows(num).Item("latitude")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("longitude")) Then txtLongitude.Text = ds.Tables("station").Rows(num).Item("longitude")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("elevation")) Then txtElevation.Text = ds.Tables("station").Rows(num).Item("elevation")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("authority")) Then txtAuthority.Text = ds.Tables("station").Rows(num).Item("authority")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("adminregion")) Then txtAdminRegion.Text = ds.Tables("station").Rows(num).Item("adminregion")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("drainagebasin")) Then txtDrainageBasin.Text = ds.Tables("station").Rows(num).Item("drainagebasin")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("geolocationmethod")) Then txtgeoMethod.Text = ds.Tables("station").Rows(num).Item("geolocationmethod")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("geolocationaccuracy")) Then txtgeoAccuracy.Text = ds.Tables("station").Rows(num).Item("geolocationaccuracy")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("stationoperational")) Then txtStationOperation.CheckState = ds.Tables("station").Rows(num).Item("stationoperational")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("qualifier")) Then txtStationType.Text = ds.Tables("station").Rows(num).Item("qualifier")

        If Not IsDBNull(ds.Tables("station").Rows(num).Item("openingdatetime")) Then
            txtOpeningDate.Text = ds.Tables("station").Rows(num).Item("openingdatetime")
        Else
            txtOpeningDate.Text = ""
        End If
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("closingdatetime")) Then
            txtClosingDate.Text = ds.Tables("station").Rows(num).Item("closingdatetime")
        Else
            txtClosingDate.Text = ""
        End If

        txtRecNumber.Text = rec + 1 & " of " & maxRows '"Record 1 of " & maxRows

    End Sub
    Sub populateElementMetadata(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        ClearElementForm()
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementId")) Then txtId.Text = ds.Tables(frm).Rows(num).Item("elementId")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("abbreviation")) Then txtAbbreviation.Text = ds.Tables(frm).Rows(num).Item("abbreviation")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementName")) Then txtName.Text = ds.Tables(frm).Rows(num).Item("elementName")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("description")) Then txtDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementScale")) Then txtScale.Text = ds.Tables(frm).Rows(num).Item("elementScale")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("upperLimit")) Then txtUpperLimit.Text = ds.Tables(frm).Rows(num).Item("upperLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("lowerLimit")) Then txtLowerLimit.Text = ds.Tables(frm).Rows(num).Item("lowerLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("units")) Then txtUnit.Text = ds.Tables(frm).Rows(num).Item("units")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementtype")) Then txtType.Text = ds.Tables(frm).Rows(num).Item("elementtype")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("selected")) Then
            If ds.Tables(frm).Rows(num).Item("selected") = 1 Then
                chkESelected.Checked = True
            Else
                chkESelected.Checked = False
            End If
        End If
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("qcTotalRequired")) Then
            If ds.Tables(frm).Rows(num).Item("qcTotalRequired") = 1 Then
                chkqcTotal.Checked = True
            Else
                chkqcTotal.Checked = False
            End If
        End If

        txtElementNavigator.Text = rec + 1 & " of " & maxRows '"Record 1 of " & maxRows

    End Sub
    Sub populateStationElement(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        'MsgBox(num & " " & maxRows)
        ClearStationElementForm()
        txtStation.Text = ds.Tables(frm).Rows(num).Item("recordedFrom")
        txtElement.Text = ds.Tables(frm).Rows(num).Item("describedBy")
        txtInstrument.Text = ds.Tables(frm).Rows(num).Item("recordedWith")
        txtInstrumentCode.Text = ds.Tables(frm).Rows(num).Item("instrumentcode")
        txtScheduleClass.Text = ds.Tables(frm).Rows(num).Item("scheduledFor")
        txtHeight.Text = ds.Tables(frm).Rows(num).Item("height")
        txtBeginDate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtEndate.Text = ds.Tables(frm).Rows(num).Item("endDate")

        metadfrm.seStn = txtStation.Text
        metadfrm.Eecode = txtElement.Text
        metadfrm.Iecode = txtInstrument.Text
        metadfrm.sebdate = txtBeginDate.Text

        If maxRows > 0 Then txtNavigator1.Text = rec + 1 & " of " & maxRows ' - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateInstrument(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        'MsgBox(num & " " & maxRows)
        ClearInstrumentForm()
        txtInstrumentId.Text = ds.Tables(frm).Rows(num).Item("instrumentId")
        txtInstName.Text = ds.Tables(frm).Rows(num).Item("instrumentName")
        txtAbbrev.Text = ds.Tables(frm).Rows(num).Item("abbreviation")
        txtInstrStn.Text = ds.Tables(frm).Rows(num).Item("installedAt")
        txtSerial.Text = ds.Tables(frm).Rows(num).Item("serialNumber")
        txtModel.Text = ds.Tables(frm).Rows(num).Item("model")
        txtManufacturer.Text = ds.Tables(frm).Rows(num).Item("manufacturer")
        txtUncertainity.Text = ds.Tables(frm).Rows(num).Item("instrumentUncertainty")
        txtInstallDate.Text = ds.Tables(frm).Rows(num).Item("installationDatetime")
        txtDeinstallDate.Text = ds.Tables(frm).Rows(num).Item("deinstallationDatetime")
        txthgt.Text = ds.Tables(frm).Rows(num).Item("height")
        txtInstrumentPicFile.Text = ds.Tables(frm).Rows(num).Item("instrumentPicture")

        If maxRows > 0 Then txtNavigator2.Text = rec + 1 & " of " & maxRows ' - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateStationHistory(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        ClearStationHistoryForm()
        txtlocStn.Text = ds.Tables(frm).Rows(num).Item("belongsTo")
        txtStnType.Text = ds.Tables(frm).Rows(num).Item("stationType")
        txtMethod.Text = ds.Tables(frm).Rows(num).Item("geoLocationMethod")
        txtAccuracy.Text = ds.Tables(frm).Rows(num).Item("geoLocationAccuracy")
        txtOpDate.Text = ds.Tables(frm).Rows(num).Item("openingDatetime")
        txtClosDate.Text = ds.Tables(frm).Rows(num).Item("closingDatetime")
        txtLat.Text = ds.Tables(frm).Rows(num).Item("latitude")
        txtLon.Text = ds.Tables(frm).Rows(num).Item("longitude")
        txtElev.Text = ds.Tables(frm).Rows(num).Item("elevation")
        txtAuth.Text = ds.Tables(frm).Rows(num).Item("authority")
        txtAdmin.Text = ds.Tables(frm).Rows(num).Item("adminRegion")
        txtDrgBasin.Text = ds.Tables(frm).Rows(num).Item("drainageBasin")

        If maxRows > 0 Then txtNav2.Text = rec + 1 & " of " & maxRows ' - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateStationQualifier(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        ClearStationQualifierForm()
        txtqualifier.Text = ds.Tables(frm).Rows(num).Item("qualifier")
        txtQualifierStation.Text = ds.Tables(frm).Rows(num).Item("belongsTo")
        txtBDate.Text = ds.Tables(frm).Rows(num).Item("qualifierBeginDate")
        txtEndDate.Text = ds.Tables(frm).Rows(num).Item("qualifierEndDate")
        txtTZone.Text = ds.Tables(frm).Rows(num).Item("stationTimeZone")
        txtNetwork.Text = ds.Tables(frm).Rows(num).Item("stationNetworkType")

        metadfrm.qlfr = txtqualifier.Text
        metadfrm.bdate = txtBDate.Text
        metadfrm.edate = txtEndDate.Text
        metadfrm.stn = txtQualifierStation.Text

        If maxRows > 0 Then txtNav4.Text = rec + 1 & " of " & maxRows
    End Sub
    Sub populateScheduleClass(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        ClearFormScheduleClass()
        txtClass.Text = ds.Tables(frm).Rows(num).Item("scheduleClass")
        txtClassStation.Text = ds.Tables(frm).Rows(num).Item("refersTo")
        txtClassDescription.Text = ds.Tables(frm).Rows(num).Item("description")

        If maxRows > 0 Then txtNav5.Text = rec + 1 & " of " & maxRows
    End Sub
    Sub populatePhysicalFeature(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        ClearPhysicalFeatureForm()

        txtFeatureStation.Text = ds.Tables(frm).Rows(num).Item("associatedWith")
        txtFeatureBdate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtFeatureEdate.Text = ds.Tables(frm).Rows(num).Item("endDate")
        txtFeatureDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        txtFeatureClass.Text = ds.Tables(frm).Rows(num).Item("classifiedInto")
        txtImageFile.Text = ds.Tables(frm).Rows(num).Item("image")

        metadfrm.pstn = ds.Tables(frm).Rows(num).Item("associatedWith")
        metadfrm.pbdate = ds.Tables(frm).Rows(num).Item("beginDate")
        metadfrm.pedate = ds.Tables(frm).Rows(num).Item("endDate")
        metadfrm.pfeature = ds.Tables(frm).Rows(num).Item("description")

        SetDataSet("physicalfeatureclass")

        ' Reset the maximum records to physicalfeature table
        Kount = maxRows

        txtFeatureClassDescription.Text = ds.Tables("physicalfeatureclass").Rows(1).Item("description")

        If maxRows > 0 Then txtNav6.Text = rec + 1 & " of " & maxRows

        'pstn, pbdate, pedate, pfeature, pclass, pfile


        metadfrm.pclass = txtFeatureClass.Text
        metadfrm.pfile = txtImageFile.Text


    End Sub
    Sub populatePaperArchiveDefinition(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)

        txtFormId.Text = ds.Tables(frm).Rows(num).Item("formId")
        txtFormDescription.Text = ds.Tables(frm).Rows(num).Item("description")

        If maxRows > 0 Then PaperArchiveNavigation.Text = rec + 1 & " of " & maxRows '"Record 1 of " & maxRows
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        rec = 0
        populateStations("station", rec, Kount)
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        If rec > 0 Then
            rec = rec - 1
            populateStations("station", rec, Kount)
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateStations("station", rec, Kount)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        rec = Kount - 1
        populateStations("station", rec, Kount)
    End Sub

    Private Sub cmdAddNew_Click_1(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        SetDataSet("station")
        Try
            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines

            dsNewRow = ds.Tables("station").NewRow
            dsNewRow.Item("stationId") = txtstationId.Text
            dsNewRow.Item("wmoid") = txtwmoid.Text
            dsNewRow.Item("icaoid") = txticaoid.Text
            dsNewRow.Item("stationName") = txtStationName.Text
            dsNewRow.Item("country") = txtCountry.Text
            If IsNumeric(txtLatitude.Text) Then dsNewRow.Item("latitude") = Val(txtLatitude.Text)
            If IsNumeric(txtLongitude.Text) Then dsNewRow.Item("longitude") = Val(txtLongitude.Text)
            If IsNumeric(txtElevation.Text) Then dsNewRow.Item("elevation") = Val(txtElevation.Text)
            dsNewRow.Item("adminRegion") = txtAdminRegion.Text
            dsNewRow.Item("drainageBasin") = txtDrainageBasin.Text
            dsNewRow.Item("authority") = txtAuthority.Text
            dsNewRow.Item("qualifier") = txtStationType.Text
            If IsNumeric(txtgeoAccuracy.Text) Then dsNewRow.Item("geolocationAccuracy") = Val(txtgeoAccuracy.Text)
            If IsNumeric(txtgeoMethod.Text) Then dsNewRow.Item("geolocationMethod") = Val(txtgeoMethod.Text)

            dsNewRow.Item("openingDatetime") = txtOpeningDate.Text
            dsNewRow.Item("closingDatetime") = txtClosingDate.Text

            If IsDate(txtOpeningDate.Text) Then
                ' Opening date can only be in the past
                If DateDiff(DateInterval.Day, DateValue(txtOpeningDate.Text), Now) < 0 Then
                    dsNewRow.Item("openingDatetime") = ""
                    MsgBox("Not Valid Opening date")
                End If

            End If

            If IsDate(txtClosingDate.Text) Then
                ' Closing date can only be in the past
                If DateDiff(DateInterval.Day, DateValue(txtClosingDate.Text), Now) < 0 Then
                    dsNewRow.Item("closingDatetime") = ""
                    MsgBox("Not Valid Closing date date")
                End If

            End If

            dsNewRow.Item("stationoperational") = txtStationOperation.CheckState

            'Add a new record to the data source table
            ds.Tables("station").Rows.Add(dsNewRow)
            da.Update(ds, "station")
            MsgBox("New station added successfully")
            ClearStationForm()
        Catch ex As Exception
            MsgBox(ex.Message)
            ds.Clear()
        End Try


    End Sub
    Sub ClearStationForm()

        'For Each ctrl As Object In Me.Controls
        '    'typ = ctrl.CType=
        '    MsgBox(ctrl.Name)
        '    If Strings.Left(ctrl.Name, 3) = "txt" Then

        '        ctrl.Text = ""
        '    End If
        'Next

        txtstationId.Text = ""
        combSearchStation.Text = ""
        txtStationName.Clear()
        txtwmoid.Clear()
        txticaoid.Clear()
        txtCountry.Clear()
        txtAuthority.Clear()
        txtLatitude.Clear()
        txtLongitude.Clear()
        txtElevation.Clear()
        txtAdminRegion.Clear()
        txtDrainageBasin.Clear()
        txtgeoAccuracy.Clear()
        txtgeoMethod.Clear()
        'OpenDate.Text = ""
        'ClosingDate.Text = ""
        txtOpeningDate.Text = ""
        txtClosingDate.Text = ""
        txtStationType.Text = ""
        txtStationOperation.CheckState = CheckState.Unchecked
        txtRecNumber.Clear()
        txtDegreesLat.Text = ""
        txtMinutesLat.Text = ""
        txtSecondsLat.Text = ""
        lstNS.Text = ""
        txtDegreesLon.Text = ""
        txtMinutesLon.Text = ""
        txtSecondsLon.Text = ""
        lstEW.Text = ""
        txtstationId.Focus()

    End Sub

    Sub ClearElementForm()

        txtId.Text = ""
        txtAbbreviation.Clear()
        txtName.Clear()
        txtDescription.Clear()
        txtScale.Clear()
        txtUpperLimit.Clear()
        txtLowerLimit.Clear()
        txtUnit.Clear()
        txtType.Text = ""
        chkESelected.Checked = False
        chkqcTotal.Checked = False
        txtElementNavigator.Clear()
        txtId.Focus()
    End Sub
    Sub ClearStationElementForm()
        txtStation.Text = ""
        txtElement.Text = ""
        txtInstrument.Text = ""
        txtInstrumentCode.Text = ""
        txtScheduleClass.Text = ""
        txtHeight.Text = ""
        txtBeginDate.Text = ""
        txtEndate.Text = ""
        txtStation.Focus()
    End Sub
    Sub ClearInstrumentForm()
        txtInstrumentId.Text = ""
        txtInstName.Text = ""
        txtSerial.Text = ""
        txtAbbrev.Text = ""
        txtModel.Text = ""
        txtManufacturer.Text = ""
        txtUncertainity.Text = 0
        txtInstallDate.Text = ""
        txtDeinstallDate.Text = ""
        txthgt.Text = ""
        txtInstrumentPicFile.Text = ""
        txtInstrStn.Text = ""
        txtInstrumentId.Focus()
    End Sub
    Sub ClearStationHistoryForm()
        txtlocStn.Text = ""
        txtStnType.Text = ""
        txtMethod.Text = ""
        txtAccuracy.Text = ""
        txtOpDate.Text = ""
        txtClosDate.Text = ""
        txtLat.Text = ""
        txtLon.Text = ""
        txtElev.Text = ""
        txtAuth.Text = ""
        txtAdmin.Text = ""
        txtDrgBasin.Text = ""
        txtlocStn.Focus()
    End Sub
    Sub ClearStationQualifierForm()
        txtqualifier.Text = ""
        txtQualifierStation.Text = ""
        txtBDate.Text = ""
        txtEndDate.Text = ""
        txtTZone.Text = ""
        txtNetwork.Text = ""
        txtqualifier.Focus()
    End Sub
    Sub ClearFormScheduleClass()
        txtClass.Text = ""
        txtClassStation.Text = ""
        txtClassDescription.Text = ""
        txtClass.Focus()
    End Sub
    Sub ClearPhysicalFeatureForm()
        txtFeatureClass.Text = ""
        txtFeatureStation.Text = ""
        txtImageFile.Text = ""
        txtFeatureStation.Text = ""
        txtFeatureBdate.Text = ""
        txtFeatureEdate.Text = ""
        txtImageFile.Text = ""
        txtFeatureDescription.Text = ""
        txtFeatureClass.Text = ""
        txtFeatureClassDescription.Text = ""
        txtFeatureStation.Focus()
    End Sub
    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Dim oper As Integer
        Dim lat, lon As String

        If txtStationOperation.Checked Then
            oper = 1
        Else
            oper = 0
        End If

        If txtstationId.Text = "" Then
            MsgBox("No record Selected")
        Else
            ' Set blank numerical values to NULL
            lat = txtLatitude.Text
            If Not IsNumeric(txtLatitude.Text) Then lat = "NULL"

            lon = txtLongitude.Text
            If Not IsNumeric(txtLongitude.Text) Then lon = "NULL"

            'TableUpdate(rec, "update")

            'sql = "UPDATE station SET stationId = '" & txtstationId.Text & "', stationName = '" & txtStationName.Text & "',wmoid = '" & txtwmoid.Text & "', icaoid = '" & txticaoid.Text & "', latitude = '" & txtLatitude.Text & "', qualifier = '" & txtStationType.Text & "', longitude = '" & txtLongitude.Text & "', elevation = '" & txtElevation.Text & "', geoLocationMethod = '" & txtgeoMethod.Text & "', geoLocationAccuracy = '" & Val(txtgeoAccuracy.Text) & "', openingDatetime = '" & txtOpeningDate.Text & "', closingDatetime = '" & txtClosingDate.Text & "', country = '" & txtCountry.Text & "', authority = '" & txtAuthority.Text & "'" &
            '    ", adminRegion = '" & txtAuthority.Text & "', drainageBasin = '" & txtDrainageBasin.Text & "', stationOperational = '" & oper & "' where stationId = '" & txtstationId.Text & "';"

            sql = "UPDATE station SET stationId = '" & txtstationId.Text & "', stationName = '" & txtStationName.Text & "',wmoid = '" & txtwmoid.Text & "', icaoid = '" & txticaoid.Text & "', latitude = " & lat & ", qualifier = '" & txtStationType.Text & "', longitude = " & lon & " , elevation = '" & txtElevation.Text & "', geoLocationMethod = '" & txtgeoMethod.Text & "', geoLocationAccuracy = '" & Val(txtgeoAccuracy.Text) & "', openingDatetime = '" & txtOpeningDate.Text & "', closingDatetime = '" & txtClosingDate.Text & "', country = '" & txtCountry.Text & "', authority = '" & txtAuthority.Text & "'" &
                ", adminRegion = '" & txtAdminRegion.Text & "', drainageBasin = '" & txtDrainageBasin.Text & "', stationOperational = '" & oper & "' where stationId = '" & txtstationId.Text & "';"

            'MsgBox(sql)
            If Not Update_Rec(sql) Then
                MsgBox("Update Failed")
            Else
                MsgBox("Update Successful")
            End If

        End If

    End Sub
    Function TableUpdate(recs As Integer, cmdtype As String) As Boolean
        TableUpdate = True

        Try

            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim recUpdate As New dataEntryGlobalRoutines

            'MsgBox(ds.Tables("station").Rows.Count)

            ds.Tables("station").Rows(recs).Item("stationId") = txtstationId.Text
            ds.Tables("station").Rows(recs).Item("stationName") = txtStationName.Text
            ds.Tables("station").Rows(recs).Item("wmoid") = txtwmoid.Text
            ds.Tables("station").Rows(recs).Item("icaoid") = txticaoid.Text
            ds.Tables("station").Rows(recs).Item("country") = txtCountry.Text
            ds.Tables("station").Rows(recs).Item("openingDatetime") = txtOpeningDate.Text
            ds.Tables("station").Rows(recs).Item("closingDatetime") = txtClosingDate.Text
            If IsNumeric(txtLatitude.Text) Then ds.Tables("station").Rows(recs).Item("latitude") = Val(txtLatitude.Text)
            If IsNumeric(txtLongitude.Text) Then ds.Tables("station").Rows(recs).Item("longitude") = Val(txtLongitude.Text)
            If IsNumeric(txtElevation.Text) Then ds.Tables("station").Rows(recs).Item("elevation") = Val(txtElevation.Text)
            ds.Tables("station").Rows(recs).Item("adminRegion") = txtAdminRegion.Text
            ds.Tables("station").Rows(recs).Item("drainageBasin") = txtDrainageBasin.Text
            ds.Tables("station").Rows(recs).Item("authority") = txtAuthority.Text
            If IsNumeric(txtgeoAccuracy.Text) Then ds.Tables("station").Rows(recs).Item("geolocationAccuracy") = Val(txtgeoAccuracy.Text)
            If IsNumeric(txtgeoMethod.Text) Then ds.Tables("station").Rows(recs).Item("geolocationMethod") = Val(txtgeoMethod.Text)

            '' Update Opening date
            'If IsDate(txtOpeningDate.Text) Then
            '    ds.Tables("station").Rows(recs).Item("openingDatetime") = txtOpeningDate.Text
            'Else
            '    'ds.Tables("station").Rows(recs).Item("openingDatetime") = vbNull
            'End If

            '' Update Closing date
            'If IsDate(txtClosingDate.Text) Then
            '    ds.Tables("station").Rows(recs).Item("closingDatetime") = txtClosingDate.Text
            'Else
            '    'ds.Tables("station").Rows(recs).Item("closingDatetime") = vbNull
            'End If

            ds.Tables("station").Rows(recs).Item("stationoperational") = txtStationOperation.CheckState



            'Update the record in the data source table
            da.Update(ds, "station")

            If cmdtype = "update" Then recUpdate.messageBoxRecordedUpdated()

        Catch ex As Exception
            MsgBox(ex.Message)
            TableUpdate = False
            ds.Clear()
        End Try

    End Function


    Function DeleteRecord(tbl As String, recs As Integer) As Boolean
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        DeleteRecord = True
        Try
            'MsgBox(ds.Tables(tbl).Rows(recs).Item("drainageBasin"))
            If MsgBox("Please Confirm. Undelete Not Possible!!", vbYesNo, "Delete Record") = vbYes Then
                ds.Tables(tbl).Rows(recs).Delete()
                da.Update(ds, tbl)

                MsgBox("Record Successfully Deleted")
            Else
                MsgBox("Delete Cancelled")
            End If

            'If rec < Kount - 1 Then
            '    populateStations("station", rec + 1, Kount)
            'Else
            '    populateStations("station", rec, Kount)
            'End If

        Catch ex As Exception
            MsgBox(Err.Description)
            DeleteRecord = False
        End Try

    End Function

    Private Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        If DeleteRecord("station", rec) Then
            If rec < Kount - 1 Then
                populateStations("station", rec + 1, Kount)
            Else
                populateStations("station", rec, Kount)
            End If
        End If
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        ClearStationForm()
    End Sub



    Private Sub cmdFirstRecord_Click(sender As Object, e As EventArgs) Handles cmdFirstRecord.Click
        rec = 0
        populateElementMetadata("obselement", rec, Kount)
    End Sub

    Private Sub cmdLastRecord_Click(sender As Object, e As EventArgs) Handles cmdLastRecord.Click
        rec = Kount - 1
        populateElementMetadata("obselement", rec, Kount)
    End Sub

    Private Sub cmdPrevoius_Click(sender As Object, e As EventArgs) Handles cmdPrevoius.Click
        If rec > 0 Then
            rec = rec - 1
            populateElementMetadata("obselement", rec, Kount)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateElementMetadata("obselement", rec, Kount)
        End If
    End Sub

    Private Sub cmdAddElement_Click(sender As Object, e As EventArgs) Handles cmdAddElement.Click

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try

            dsNewRow = ds.Tables("obselement").NewRow
            dsNewRow.Item("elementId") = txtId.Text
            dsNewRow.Item("abbreviation") = txtAbbreviation.Text
            dsNewRow.Item("elementName") = txtName.Text
            dsNewRow.Item("description") = txtDescription.Text
            dsNewRow.Item("elementScale") = txtScale.Text
            dsNewRow.Item("upperLimit") = txtUpperLimit.Text
            dsNewRow.Item("lowerLimit") = txtLowerLimit.Text
            dsNewRow.Item("units") = txtUnit.Text
            dsNewRow.Item("elementtype") = txtType.Text
            If chkESelected.Checked = True Then
                dsNewRow.Item("selected") = 1
            Else
                dsNewRow.Item("selected") = 0
            End If

            If chkqcTotal.Checked = True Then
                dsNewRow.Item("qcTotalRequired") = 1
            Else
                dsNewRow.Item("qcTotalRequired") = 0
            End If

            'Add a new record to the data source table
            ds.Tables("obselement").Rows.Add(dsNewRow)
            da.Update(ds, "obselement")
            MsgBox("New element added successfully")
            ClearElementForm()
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("Invalid Entries; Check values")
                Exit Sub
            End If
            MsgBox(Err.Number & " : " & Err.Description)
        End Try
    End Sub

    Private Sub cmdUpdateElement_Click(sender As Object, e As EventArgs) Handles cmdUpdateElement.Click
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        If txtId.Text = "" Then
            MsgBox("No record Selected")
            Exit Sub
        End If

        ds.Tables("obselement").Rows(rec).Item("elementId") = txtId.Text
        ds.Tables("obselement").Rows(rec).Item("elementName") = txtName.Text
        ds.Tables("obselement").Rows(rec).Item("abbreviation") = txtAbbreviation.Text
        ds.Tables("obselement").Rows(rec).Item("description") = txtDescription.Text
        ds.Tables("obselement").Rows(rec).Item("elementScale") = txtScale.Text
        ds.Tables("obselement").Rows(rec).Item("upperLimit") = txtUpperLimit.Text
        ds.Tables("obselement").Rows(rec).Item("lowerLimit") = txtLowerLimit.Text
        ds.Tables("obselement").Rows(rec).Item("units") = txtUnit.Text
        ds.Tables("obselement").Rows(rec).Item("elementtype") = txtType.Text
        If chkESelected.Checked = True Then
            ds.Tables("obselement").Rows(rec).Item("selected") = 1
        Else
            ds.Tables("obselement").Rows(rec).Item("selected") = 0
        End If
        If chkqcTotal.Checked = True Then
            ds.Tables("obselement").Rows(rec).Item("qcTotalRequired") = 1
        Else
            ds.Tables("obselement").Rows(rec).Item("qcTotalRequired") = 0
        End If

        da.Update(ds, "obselement")
        recUpdate.messageBoxRecordedUpdated()

        ClearElementForm()

        Exit Sub

Err:

        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Private Sub cmdDeleteElement_Click(sender As Object, e As EventArgs) Handles cmdDeleteElement.Click
        If DeleteRecord("obselement", rec) Then
            If rec < Kount - 1 Then
                populateElementMetadata("obselement", rec + 1, Kount)
            Else
                populateElementMetadata("obselement", rec, Kount)
            End If
        End If
    End Sub


    Private Sub cmdClearElement_Click(sender As Object, e As EventArgs) Handles cmdClearElement.Click
        ClearElementForm()
    End Sub
    'Sub FillStationList(lst As ComboBox)
    '    Dim dstn As New DataSet
    '    ListDataSet(tbl As String, ByRef dstn As DataSet)
    '    lst.Items.Add("1")
    'End Sub

    Sub FillList(ByRef lst As ComboBox, tbl As String, idxfld As String)
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            dstn.Clear()
            da.Fill(dstn, tbl)

            lst.Items.Clear()

            For i = 0 To dstn.Tables(tbl).Rows.Count - 1
                lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(idxfld))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub cmdAddStElement_Click(sender As Object, e As EventArgs) Handles cmdAddStElement.Click

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try
            dsNewRow = ds.Tables("stationelement").NewRow

            dsNewRow.Item("recordedFrom") = txtStation.Text
            dsNewRow.Item("describedBy") = txtElement.Text
            dsNewRow.Item("recordedWith") = txtInstrument.Text
            dsNewRow.Item("instrumentcode") = txtInstrumentCode.Text
            dsNewRow.Item("scheduledFor") = txtScheduleClass.Text
            dsNewRow.Item("height") = txtHeight.Text
            dsNewRow.Item("beginDate") = txtBeginDate.Text
            dsNewRow.Item("endDate") = txtEndate.Text

            'Add a new record to the data source table
            ds.Tables("stationelement").Rows.Add(dsNewRow)
            da.Update(ds, "stationelement")
            MsgBox("New record added successfully")
            ClearStationElementForm()
        Catch ex As Exception

            If ex.HResult = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If

        End Try
        'Err:
        '        If Err.Number = 5 Then
        '            MsgBox("Invalid Entries; Check values")
        '            Exit Sub
        '        End If
        '        MsgBox(Err.Number & " : " & Err.Description)
    End Sub


    Private Sub cmdAddArchiveDef_Click(sender As Object, e As EventArgs) Handles cmdAddArchiveDef.Click
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

        dsNewRow = ds.Tables("paperarchivedefinition").NewRow

        dsNewRow.Item("formId") = txtFormId.Text
        dsNewRow.Item("description") = txtFormDescription.Text
        ds.Tables("paperarchivedefinition").Rows.Add(dsNewRow)
        da.Update(ds, "paperarchivedefinition")
        MsgBox("New record added successfully")
        ' Clear Text boxes
        txtFormId.Text = ""
        txtFormDescription.Text = ""
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)
    End Sub

    Private Sub cmdDeleteArchiveDef_Click(sender As Object, e As EventArgs) Handles cmdDeleteArchiveDef.Click
        If DeleteRecord("paperarchivedefinition", rec) Then
            SetDataSet("paperarchivedefinition")
            populatePaperArchiveDefinition("paperarchivedefinition", 0, Kount)
        End If
    End Sub

    Private Sub cmdViewStation_Click(sender As Object, e As EventArgs) Handles cmdViewStation.Click
        dsSourceTableName = "station"
        RecordsView("station")

    End Sub
    Sub RecordsView(tbl As String)

        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()

        da.Fill(dstn, tbl)

        formDataView.Show()
        formDataView.DataGridView.DataSource = dstn
        formDataView.DataGridView.DataMember = tbl
        formDataView.DataGridView.Refresh()
        formDataView.grpSearch.Visible = False
        formDataView.DataGridView.Dock = DockStyle.Top

    End Sub


    Private Sub cmdViewElements_Click(sender As Object, e As EventArgs) Handles cmdViewElements.Click
        dsSourceTableName = "obselement"
        RecordsView("obselement")
    End Sub

    Private Sub cmdViewStElement_Click(sender As Object, e As EventArgs) Handles cmdViewStElement.Click
        dsSourceTableName = "stationelement"
        RecordsView("stationelement")
    End Sub

    Private Sub cmdViewInstrument_Click(sender As Object, e As EventArgs) Handles cmdViewInstrument.Click
        dsSourceTableName = "instrument"
        RecordsView("instrument")
    End Sub

    Private Sub cmdViewHistory_Click(sender As Object, e As EventArgs) Handles cmdViewHistory.Click
        dsSourceTableName = "stationlocationhistory"
        RecordsView("stationlocationhistory")
    End Sub

    Private Sub cmdDeleteView_Click(sender As Object, e As EventArgs) Handles cmdDeleteView.Click
        dsSourceTableName = "stationqualifier"
        RecordsView("stationqualifier")
    End Sub

    Private Sub cmdViewScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdViewScheduleClass.Click
        dsSourceTableName = "obsscheduleclass"
        RecordsView("obsscheduleclass")
    End Sub

    Private Sub cmdViewFeature_Click(sender As Object, e As EventArgs) Handles cmdViewFeature.Click
        dsSourceTableName = "physicalfeature"
        RecordsView("physicalfeature")
    End Sub

    Private Sub cmdViewPaperArchive_Click(sender As Object, e As EventArgs) Handles cmdViewPaperArchive.Click
        dsSourceTableName = "paperarchivedefinition"
        RecordsView("paperarchivedefinition")
    End Sub

    Private Sub cmdImport_Click(sender As Object, e As EventArgs) Handles cmdImport.Click
        'On Error GoTo err
        'Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\Climsoft Project\Climsoft V4\Data\stations.txt")
        '    MyReader.TextFieldType = FileIO.FieldType.Delimited
        '    MyReader.SetDelimiters(",")
        '    Dim num As Integer = 1
        '    Dim lin As Integer
        '    Dim currentRow As String()
        '    Dim currentField As String
        '    Dim row As String()

        '    ' Define the Data GridView Columns
        '    formImports.DataGridView1.ColumnCount = 2
        '    formImports.DataGridView1.Columns(0).Name = "Import Field No"
        '    formImports.DataGridView1.Columns(1).Name = "Import Field Name"

        '    ' Populate the Data GridView with column headers from the import station text file

        '    lin = MyReader.LineNumber()
        '    currentRow = MyReader.ReadFields()

        '    If lin = 1 Then ' The header row
        '        For Each currentField In currentRow
        '            row = New String() {num, currentField}
        '            formImports.DataGridView1.Rows.Add(row)
        '            num = num + 1
        '        Next
        '    End If

        '    'Do While MyReader.EndOfData = False
        '    '    lin = MyReader.LineNumber()
        '    '    currentRow = MyReader.ReadFields()
        '    '    For Each currentField In currentRow
        '    '        If lin = 1 Then ' The header row
        '    '            row = New String() {num, currentField}
        '    '            formImports.DataGridView1.Rows.Add(row)
        '    '            num = num + 1
        '    '        Else
        '    '            ' Transfer Data
        '    '        End If

        '    '    Next
        '    'Loop

        '    'End Using

        '    ' Populate the Data GridView with column headers from the db station table
        '    SetDataSet("station")
        '    Dim maxfields As Integer
        '    maxfields = ds.Tables("station").Columns.Count

        '    ' Define the new column
        '    Dim cmb As New DataGridViewComboBoxColumn()
        '    cmb.HeaderText = "Select Fields"
        '    cmb.Name = "cmb"
        '    cmb.MaxDropDownItems = maxfields

        '    ' Add ComboList and populate it
        '    cmb.Items.Add("")
        '    For i = 0 To maxfields - 1
        '        cmb.Items.Add(ds.Tables("station").Columns(i).ColumnName)
        '    Next
        '    formImports.DataGridView1.Columns.Add(cmb)
        '    formImports.DataGridView1.Refresh()



        formImports.Show()
        'End Using
        'For i = 0 To maxfields - 2
        '    MsgBox(formDataView.DataGridView.Rows(i).Cells(0).Value & " " & formDataView.DataGridView.Rows(i).Cells(1).Value & " " & formDataView.DataGridView.Rows(i).Cells(2).Value)
        'Next



        Exit Sub
Err:
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Sub DataGridColumns()
        formDataView.DataGridView.ColumnCount = 2
        formDataView.DataGridView.Columns(0).Name = "No"
        formDataView.DataGridView.Columns(1).Name = "Import Fields"
        'formDataView.DataGridView.Columns(2).Name = "Product_Price"

        Dim row As String() = New String() {"1", "StationId"}
        formDataView.DataGridView.Rows.Add(row)
        row = New String() {"2", "StationName"}
        formDataView.DataGridView.Rows.Add(row)
        row = New String() {"3", "Country"}
        formDataView.DataGridView.Rows.Add(row)
        row = New String() {"4", "District"}
        formDataView.DataGridView.Rows.Add(row)

        'Dim cmb As New DataGridViewComboBoxColumn()
        'cmb.HeaderText = "Db Fields"
        'cmb.Name = "cmb"
        'cmb.MaxDropDownItems = 4
        'cmb.Items.Add("id")
        'cmb.Items.Add("name")
        'cmb.Items.Add("country")
        'cmb.Items.Add("district")
        'formDataView.DataGridView.Columns.Add(cmb)
        formDataView.DataGridView.Refresh()
        formDataView.Show()
    End Sub

    Sub populateSearchStation()

        Dim maxRows As Long

        Try
            dbconn.Close()
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()
            sql = "SELECT stationId, stationName FROM station ORDER BY stationId"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            combSearchStation.Items.Clear()
            da.Fill(ds, "station")
            dbconn.Close()
            maxRows = ds.Tables("station").Rows.Count
            For i = 0 To maxRows - 1 Step 1
                combSearchStation.Items.Add(ds.Tables("station").Rows(i).Item("stationName"))
                txtstationId.Items.Add(ds.Tables("station").Rows(i).Item("stationId"))
            Next

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub populateSearchElement()

        Dim maxRows As Long
        Dim sql As String

        Try
            dbconn.Close()
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()
            sql = "SELECT elementName FROM obselement where elementName <> '' ORDER BY elementName"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            combSearchElement.Items.Clear()
            da.Fill(ds, "obselement")
            maxRows = ds.Tables("obselement").Rows.Count
            For i = 0 To maxRows - 1 Step 1
                combSearchElement.Items.Add(ds.Tables("obselement").Rows(i).Item("elementName"))
            Next

            sql = "SELECT elementId FROM obselement ORDER BY elementId"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            txtId.Items.Clear()
            da.Fill(ds, "obselement")
            For i = 0 To maxRows - 1 Step 1
                txtId.Items.Add(ds.Tables("obselement").Rows(i).Item("elementId"))
            Next

            dbconn.Close()


        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub combSearchStation_Click(sender As Object, e As EventArgs) Handles combSearchStation.Click

    End Sub

    Sub Locate_Station(fldnm As String, datval As String)
        Dim maxRows As Long
        Dim nx As String
        Try
            sql = "SELECT * FROM station ORDER BY stationId"

            dbconn.Close()
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "station")
            maxRows = ds.Tables("station").Rows.Count

            dbconn.Close()
            If ds.Tables("station").Rows.Count > 0 Then
                ClearStationForm()
                For i = 0 To maxRows - 1
                    If fldnm = "stationId" Then
                        nx = ds.Tables("station").Rows(i).Item("stationId")
                    Else
                        nx = ""
                        If Not IsDBNull(ds.Tables("station").Rows(i).Item("stationName")) Then nx = ds.Tables("station").Rows(i).Item("stationName")
                    End If

                    If nx = datval Then
                        rec = i
                        populateStations("station", i, maxRows + 1)
                        Exit Sub
                    End If

                Next
            End If

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Locate_Element(fldnm As String, dataVal As String)
        Dim maxRows As Long
        Dim sql, nx As String

        Try
            dbconn.Close()
            dbConnectionString = frmLogin.txtusrpwd.Text
            dbconn.ConnectionString = dbConnectionString
            dbconn.Open()

            sql = "SELECT * FROM obselement"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()

            da.Fill(ds, "obselement")
            maxRows = ds.Tables("obselement").Rows.Count
            For i = 0 To maxRows - 1 Step 1
                If fldnm = "Nm" Then
                    nx = ""
                    If Not IsDBNull(ds.Tables("obselement").Rows(i).Item("elementName")) Then nx = ds.Tables("obselement").Rows(i).Item("elementName")
                Else
                    nx = ds.Tables("obselement").Rows(i).Item("elementId")
                End If

                If nx = dataVal Then
                    'If fldnm = "Nm" And nx = dataVal Then
                    'MsgBox(i & " " & maxRows)
                    rec = i
                    populateElementMetadata("obselement", i, maxRows + 1)
                    Exit For
                End If
                'combSearchElement.Items.Add(ds.Tables("obselement").Rows(i).Item("elementName")) Then
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub combSearchStation_SelectedValueChanged(sender As Object, e As EventArgs) Handles combSearchStation.SelectedValueChanged
        Locate_Station("stationName", combSearchStation.Text)
    End Sub

    Private Sub txtstationId_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtstationId.SelectedValueChanged
        Locate_Station("stationId", txtstationId.Text)
    End Sub


    Private Sub combSearchStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combSearchStation.SelectedIndexChanged

    End Sub

    Private Sub combSearchElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combSearchElement.SelectedIndexChanged

    End Sub

    Private Sub combSearchElement_SelectedValueChanged(sender As Object, e As EventArgs) Handles combSearchElement.SelectedValueChanged
        Locate_Element("Nm", combSearchElement.Text)
    End Sub

    Private Sub txtId_SelectedValueChanged(sender As Object, e As EventArgs) Handles txtId.SelectedValueChanged
        Locate_Element("Id", txtId.Text)
    End Sub


    Private Sub TabPaperArchive_Click(sender As Object, e As EventArgs) Handles TabPaperArchive.Click

    End Sub

    Private Sub nav8Left_Click(sender As Object, e As EventArgs) Handles nav8Left.Click
        If rec > 0 Then
            rec = rec - 1
            populatePaperArchiveDefinition("paperarchivedefinition", rec, Kount)
        End If
    End Sub

    Private Sub nav8First_Click(sender As Object, e As EventArgs) Handles nav8First.Click
        rec = 0
        populatePaperArchiveDefinition("paperarchivedefinition", rec, Kount)
    End Sub

    Private Sub nav8Last_Click(sender As Object, e As EventArgs) Handles nav8Last.Click
        'rec = Kount - 2
        rec = Kount - 1
        populatePaperArchiveDefinition("paperarchivedefinition", rec, Kount)
    End Sub

    Private Sub nav8Righ_Click(sender As Object, e As EventArgs) Handles nav8Right.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populatePaperArchiveDefinition("paperarchivedefinition", rec, Kount)
        End If
    End Sub


    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        'MsgBox(ActiveTab)
        If ActiveTab = 0 Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "stationsmetadata.htm")
        ElseIf ActiveTab = 1 Then
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "elementsmetadata.htm")
        Else
            Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "metadatamanagement.htm")
        End If
    End Sub



    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        txtFormId.Text = ""
        txtFormDescription.Text = ""
        txtFormId.Focus()
    End Sub



    Private Sub cmdDeleteStElement_Click(sender As Object, e As EventArgs) Handles cmdDeleteStElement.Click
        If DeleteRecord("stationelement", rec) Then
            SetDataSet("stationelement")
            populatePaperArchiveDefinition("stationelement", 0, Kount)
        End If
    End Sub

    Private Sub cmdAddInstrument_Click(sender As Object, e As EventArgs) Handles cmdAddInstrument.Click

        'On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try

            dsNewRow = ds.Tables("instrument").NewRow

            dsNewRow.Item("instrumentName") = txtInstName.Text
            dsNewRow.Item("instrumentId") = txtInstrumentId.Text
            dsNewRow.Item("serialNumber") = txtSerial.Text
            dsNewRow.Item("abbreviation") = txtAbbrev.Text
            dsNewRow.Item("model") = txtModel.Text
            dsNewRow.Item("manufacturer") = txtManufacturer.Text
            dsNewRow.Item("instrumentUncertainty") = txtUncertainity.Text
            dsNewRow.Item("installationDatetime") = txtInstallDate.Text
            dsNewRow.Item("deinstallationDatetime") = txtDeinstallDate.Text
            dsNewRow.Item("height") = txthgt.Text
            'dsNewRow.Item("instrumentPicture") = picInstrument.Image
            dsNewRow.Item("installedAt") = txtInstrStn.Text

            'Add a new record to the data source table
            ds.Tables("instrument").Rows.Add(dsNewRow)
            da.Update(ds, "instrument")
            MsgBox("New instrument added successfully")
            ClearInstrumentForm()

        Catch ex As Exception
            MsgBox(ex.Message)
            If Err.Number = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If
        End Try
        '        Exit Sub
        'Err:
        '        MsgBox(Err.Number & " : " & Err.Description)
        '        If Err.Number = 5 Then
        '            MsgBox("Invalid Entries; Check values")
        '            Exit Sub
        '        End If

    End Sub

    Private Sub cmdAddHistory_Click(sender As Object, e As EventArgs) Handles cmdAddHistory.Click
        'On Error GoTo Err

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try

            dsNewRow = ds.Tables("stationlocationhistory").NewRow

            dsNewRow.Item("belongsTo") = txtlocStn.Text
            dsNewRow.Item("stationType") = txtStnType.Text
            dsNewRow.Item("geoLocationMethod") = txtMethod.Text
            dsNewRow.Item("geoLocationAccuracy") = txtAccuracy.Text
            dsNewRow.Item("openingDatetime") = txtOpDate.Text
            dsNewRow.Item("closingDatetime") = txtClosDate.Text
            dsNewRow.Item("latitude") = txtLat.Text
            dsNewRow.Item("longitude") = txtLon.Text
            dsNewRow.Item("elevation") = txtElev.Text
            dsNewRow.Item("authority") = txtAuth.Text
            dsNewRow.Item("adminRegion") = txtAdmin.Text
            dsNewRow.Item("drainageBasin") = txtDrgBasin.Text

            'Add a new record to the data source table
            ds.Tables("stationlocationhistory").Rows.Add(dsNewRow)
            da.Update(ds, "stationlocationhistory")
            MsgBox("New record added successfully")
            ClearStationHistoryForm()

        Catch ex As Exception
            If ex.HResult = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub cmdAddQualier_Click(sender As Object, e As EventArgs) Handles cmdAddQualier.Click
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try

            dsNewRow = ds.Tables("stationqualifier").NewRow

            dsNewRow.Item("qualifier") = txtqualifier.Text
            dsNewRow.Item("belongsTo") = txtQualifierStation.Text
            dsNewRow.Item("qualifierBeginDate") = txtdBDate.Text
            dsNewRow.Item("qualifierEndDate") = txtdEndDate.Text
            dsNewRow.Item("stationTimeZone") = txtTZone.Text
            dsNewRow.Item("stationNetworkType") = txtNetwork.Text


            'Add a new record to the data source table
            ds.Tables("stationqualifier").Rows.Add(dsNewRow)
            da.Update(ds, "stationqualifier")
            MsgBox("New record added successfully")
            ClearStationQualifierForm()

        Catch ex As Exception
            If ex.HResult = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub cmdAddScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdAddScheduleClass.Click
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        Try

            dsNewRow = ds.Tables("obsscheduleclass").NewRow

            dsNewRow.Item("scheduleClass") = txtClass.Text
            dsNewRow.Item("refersTo") = txtClassStation.Text
            dsNewRow.Item("description") = txtClassDescription.Text

            'Add a new record to the data source table
            ds.Tables("obsscheduleclass").Rows.Add(dsNewRow)
            da.Update(ds, "obsscheduleclass")
            MsgBox("New record added successfully")
            ClearFormScheduleClass()

        Catch ex As Exception
            If ex.HResult = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub cmdAddFeature_Click(sender As Object, e As EventArgs) Handles cmdAddFeature.Click

        Try
            ' Update Feature Class
            ' Set the feature Class definition
            SetDataSet("physicalfeatureclass")
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow
            Dim recCommit As New dataEntryGlobalRoutines
            dsNewRow = ds.Tables("physicalfeatureclass").NewRow

            dsNewRow.Item("featureClass") = txtFeatureClass.Text
            dsNewRow.Item("refersTo") = txtFeatureStation.Text
            dsNewRow.Item("description") = txtFeatureClassDescription.Text

            ds.Tables("physicalfeatureclass").Rows.Add(dsNewRow)
            da.Update(ds, "physicalfeatureclass")

            ' Update Physical Feature
            ' Set the feature Class definition
            SetDataSet("physicalfeature")
            Dim cp As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRowp As DataRow
            Dim recCommitp As New dataEntryGlobalRoutines

            dsNewRowp = ds.Tables("physicalfeature").NewRow

            dsNewRowp.Item("associatedWith") = txtFeatureStation.Text
            dsNewRowp.Item("beginDate") = txtFeaturedBdate.Text
            dsNewRowp.Item("endDate") = txtFeaturedEdate.Text
            dsNewRowp.Item("image") = txtImageFile.Text
            dsNewRowp.Item("description") = txtFeatureDescription.Text
            dsNewRowp.Item("classifiedInto") = txtFeatureClass.Text

            'Add a new record to the data source table
            ds.Tables("physicalfeature").Rows.Add(dsNewRowp)
            da.Update(ds, "physicalfeature")
            MsgBox("New record added successfully")
            ClearPhysicalFeatureForm()

        Catch ex As Exception
            If ex.HResult = 5 Then
                MsgBox("Invalid Entries; Check values")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub

    Private Sub cmdUpdateInstrument_Click(sender As Object, e As EventArgs) Handles cmdUpdateInstrument.Click


        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines
        Try
            'If txtId.Text = "" Then
            '    MsgBox("No record Selected")
            '    Exit Sub
            'End If

            ds.Tables("instrument").Rows(rec).Item("instrumentId") = txtInstrumentId.Text
            ds.Tables("instrument").Rows(rec).Item("instrumentName") = txtInstName.Text
            ds.Tables("instrument").Rows(rec).Item("serialNumber") = txtSerial.Text
            ds.Tables("instrument").Rows(rec).Item("abbreviation") = txtAbbrev.Text
            ds.Tables("instrument").Rows(rec).Item("model") = txtModel.Text
            ds.Tables("instrument").Rows(rec).Item("manufacturer") = txtManufacturer.Text
            ds.Tables("instrument").Rows(rec).Item("instrumentUncertainty") = txtUncertainity.Text
            ds.Tables("instrument").Rows(rec).Item("installationDatetime") = txtInstallDate.Text
            ds.Tables("instrument").Rows(rec).Item("deinstallationDatetime") = txtDeinstallDate.Text
            ds.Tables("instrument").Rows(rec).Item("height") = txthgt.Text
            ds.Tables("instrument").Rows(rec).Item("installedAt") = txtInstrStn.Text
            ds.Tables("instrument").Rows(rec).Item("instrumentPicture") = txtInstrumentPicFile.Text
            'dsNewRow.Item("instrumentPicture") = picInstrument.Image

            da.Update(ds, "instrument")
            recUpdate.messageBoxRecordedUpdated()

            'ClearInstrumentForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdUpdateStElement_Click(sender As Object, e As EventArgs) Handles cmdUpdateStElement.Click

        Dim stn, ecode, icode, bdate As String
        Dim stn0, ecode0, icode0, bdate0 As String

        Try

            stn = "= '" & metadfrm.seStn & "'"
            ecode = "= '" & metadfrm.Eecode & "'"
            icode = "= '" & metadfrm.Iecode & "'"
            bdate = "= '" & metadfrm.sebdate & "'"

            ' Check for NULLs from the previous record
            If Len(metadfrm.seStn) = 0 Then stn = "IS NULL"
            If Len(metadfrm.Iecode) = 0 Then icode = "IS NULL"
            If Len(metadfrm.Eecode) = 0 Then ecode = "IS NULL"
            If Len(metadfrm.sebdate) = 0 Then bdate = "IS NULL"

            ' Format for NULLs in the new values
            If Len(txtStation.Text) = 0 Then
                stn0 = "NULL"
            Else
                stn0 = "'" & txtStation.Text & "'"
            End If

            If Len(txtElement.Text) = 0 Then
                ecode0 = "NULL"
            Else
                ecode0 = "'" & txtElement.Text & "'"
            End If

            If Len(txtInstrument.Text) = 0 Then
                icode0 = "NULL"
            Else
                icode0 = "'" & txtInstrument.Text & "'"
            End If

            If Len(txtBeginDate.Text) = 0 Then
                bdate0 = "NULL"
            Else
                bdate0 = "'" & txtBeginDate.Text & "'"
            End If

            sql = "Update stationelement set recordedFrom = " & stn0 & ",describedBy=" & ecode0 & ", recordedWith =" & icode0 & ", instrumentcode='" & txtInstrumentCode.Text & "', scheduledFor='" & txtScheduleClass.Text & "', height='" & txtHeight.Text & "', beginDate=" & bdate0 & ", endDate='" & txtEndate.Text & "' " &
                 "where recordedFrom " & stn & "  AND describedBy " & ecode & "  AND recordedWith " & icode & "  AND beginDate " & bdate & ";"

            'MsgBox(sql)

            If Not Update_Rec(sql) Then
                MsgBox("Update Failed")
            Else
                MsgBox("Update Successful")
            End If
            'ClearStationElementForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdClearStationElement_Click(sender As Object, e As EventArgs) Handles cmdClearStationElement.Click
        ClearStationElementForm()
    End Sub

    Private Sub cmdClear2_Click(sender As Object, e As EventArgs) Handles cmdClear2.Click
        ClearInstrumentForm()
    End Sub

    Private Sub cmdClearHistory_Click(sender As Object, e As EventArgs) Handles cmdClearHistory.Click
        ClearStationHistoryForm()
    End Sub

    Private Sub cmdClearQualifier_Click(sender As Object, e As EventArgs) Handles cmdClearQualifier.Click
        ClearStationQualifierForm()
    End Sub

    Private Sub cmdClearClass_Click(sender As Object, e As EventArgs) Handles cmdClearClass.Click
        ClearFormScheduleClass()
    End Sub

    Private Sub cmdClearFeature_Click(sender As Object, e As EventArgs) Handles cmdClearFeature.Click
        ClearPhysicalFeatureForm()
    End Sub

    Private Sub cmdfiratRec1_Click(sender As Object, e As EventArgs) Handles cmdfiratRec1.Click
        rec = 0
        populateStationElement("stationelement", rec, Kount)
    End Sub

    Private Sub cmdPrev1_Click(sender As Object, e As EventArgs) Handles cmdPrev1.Click
        If rec > 0 Then
            rec = rec - 1
            populateStationElement("stationelement", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext1_Click(sender As Object, e As EventArgs) Handles cmdNext1.Click

        If rec < Kount - 1 Then
            rec = rec + 1
            populateStationElement("stationelement", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast1_Click(sender As Object, e As EventArgs) Handles cmdLast1.Click
        rec = Kount - 1
        populateStationElement("stationelement", rec, Kount)
    End Sub

    Private Sub cmdFirst1_Click(sender As Object, e As EventArgs) Handles cmdFirst1.Click
        rec = 0
        populateInstrument("instrument", rec, Kount)
    End Sub

    Private Sub cmdPrev2_Click(sender As Object, e As EventArgs) Handles cmdPrev2.Click
        If rec > 0 Then
            rec = rec - 1
            populateInstrument("instrument", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext2_Click_1(sender As Object, e As EventArgs) Handles cmdNext2.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateInstrument("instrument", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast2_Click_1(sender As Object, e As EventArgs) Handles cmdLast2.Click
        rec = Kount - 1
        populateInstrument("instrument", rec, Kount)
    End Sub

    Private Sub cmdfirst3_Click(sender As Object, e As EventArgs) Handles cmdfirst3.Click
        rec = 0
        populateStationHistory("stationlocationhistory", rec, Kount)
    End Sub

    Private Sub cmdprev3_Click(sender As Object, e As EventArgs) Handles cmdprev3.Click
        If rec > 0 Then
            rec = rec - 1
            populateStationHistory("stationlocationhistory", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext3_Click(sender As Object, e As EventArgs) Handles cmdNext3.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateStationHistory("stationlocationhistory", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast3_Click(sender As Object, e As EventArgs) Handles cmdLast3.Click
        rec = Kount - 1
        populateStationHistory("stationlocationhistory", rec, Kount)
    End Sub

    Private Sub cmdFirst4_Click(sender As Object, e As EventArgs) Handles cmdFirst4.Click
        rec = 0
        populateStationQualifier("stationqualifier", rec, Kount)
    End Sub

    Private Sub cmdPrev4_Click(sender As Object, e As EventArgs) Handles cmdPrev4.Click
        If rec > 0 Then
            rec = rec - 1
            populateStationQualifier("stationqualifier", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext4_Click(sender As Object, e As EventArgs) Handles cmdNext4.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateStationQualifier("stationqualifier", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast4_Click(sender As Object, e As EventArgs) Handles cmdLast4.Click
        rec = Kount - 1
        populateStationQualifier("stationqualifier", rec, Kount)
    End Sub

    Private Sub cmdFirst5_Click(sender As Object, e As EventArgs) Handles cmdFirst5.Click
        rec = 0
        populateScheduleClass("obsscheduleclass", rec, Kount)
    End Sub

    Private Sub cmdPrev5_Click(sender As Object, e As EventArgs) Handles cmdPrev5.Click
        If rec > 0 Then
            rec = rec - 1
            populateScheduleClass("obsscheduleclass", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext5_Click(sender As Object, e As EventArgs) Handles cmdNext5.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            populateScheduleClass("obsscheduleclass", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast5_Click(sender As Object, e As EventArgs) Handles cmdLast5.Click
        rec = Kount - 1
        populateScheduleClass("obsscheduleclass", rec, Kount)
    End Sub

    Private Sub cmdFirst6_Click(sender As Object, e As EventArgs) Handles cmdFirst6.Click
        rec = Kount - 1
        populatePhysicalFeature("physicalfeature", rec, Kount)
    End Sub

    Private Sub cmdPrev6_Click(sender As Object, e As EventArgs) Handles cmdPrev6.Click
        If rec > 0 Then
            rec = rec - 1
            populatePhysicalFeature("physicalfeature", rec, Kount)
        End If
    End Sub

    Private Sub cmdNext6_Click(sender As Object, e As EventArgs) Handles cmdNext6.Click

        If rec < Kount - 1 Then
            rec = rec + 1
            populatePhysicalFeature("physicalfeature", rec, Kount)
        End If
    End Sub

    Private Sub cmdLast6_Click(sender As Object, e As EventArgs) Handles cmdLast6.Click
        rec = Kount - 1
        populatePhysicalFeature("physicalfeature", rec, Kount)
    End Sub

    Private Sub cmdUpdateArchiveDef_Click(sender As Object, e As EventArgs) Handles cmdUpdateArchiveDef.Click
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        ds.Tables("paperarchivedefinition").Rows(rec).Item("formId") = txtFormId.Text
        ds.Tables("paperarchivedefinition").Rows(rec).Item("description") = txtFormDescription.Text

        da.Update(ds, "paperarchivedefinition")
        recUpdate.messageBoxRecordedUpdated()
        txtFormId.Text = ""
        txtFormDescription.Text = ""

        Exit Sub
Err:
        MsgBox(Err.Number & " " & Err.Description)

    End Sub

    Private Sub cmdUpdateHistory_Click(sender As Object, e As EventArgs) Handles cmdUpdateHistory.Click

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        Try
            Dim G_accuracy As String

            G_accuracy = ",geoLocationAccuracy= '" & txtAccuracy.Text & "'"

            'Geographical accuracy field can only be umeric or Null
            If Not IsNumeric(txtAccuracy.Text) Then G_accuracy = ",geoLocationAccuracy= Null"

            sql = "Update stationlocationhistory set " &
                   "belongsTo = '" & txtlocStn.Text & "',stationType= '" & txtStnType.Text & "',geoLocationMethod= '" & txtMethod.Text & "'" & G_accuracy & ",openingDatetime='" & txtOpDate.Text & "',closingDatetime='" & txtClosDate.Text & "',latitude = '" & txtLat.Text & "',longitude = '" & txtLon.Text & "',elevation = '" & txtElev.Text & "',authority= '" & txtAuth.Text & "',adminRegion= '" & txtAdmin.Text & "',drainageBasin= '" & txtDrgBasin.Text & "'" &
                  " where belongsTo = '" & txtlocStn.Text & "' and openingDatetime = '" & txtOpDate.Text & "';"
            'MsgBox(sql)

            If Not Update_Rec(sql) Then
                MsgBox("Update Failed")
            Else
                MsgBox("Update Successful")
            End If

            'ClearStationHistoryForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdUpdateQualier_Click(sender As Object, e As EventArgs) Handles cmdUpdateQualier.Click

        Dim qlfr, bdate, edate, stn, ntwk, dateb, datee As String
        Dim stationTimeZone As Long

        Try
            qlfr = "= '" & metadfrm.qlfr & "'"
            bdate = "= '" & metadfrm.bdate & "'"
            edate = "= '" & metadfrm.edate & "'"
            stn = "= '" & metadfrm.stn & "'"

            ' Check for NULLs from the previous record
            If Len(metadfrm.qlfr) = 0 Then qlfr = "IS NULL"
            If Len(metadfrm.bdate) = 0 Then bdate = "IS NULL"
            If Len(metadfrm.edate) = 0 Then edate = "IS NULL"
            If Len(metadfrm.stn) = 0 Then stn = "IS NULL"

            ' Format for NULLs in the new values
            If Len(txtBDate.Text) = 0 Then
                dateb = "NULL"
            Else
                dateb = "'" & txtBDate.Text & "'"
            End If

            If Len(txtEndDate.Text) = 0 Then
                datee = "NULL"
            Else
                datee = "'" & txtEndDate.Text & "'"
            End If

            ntwk = txtNetwork.Text
            stationTimeZone = Val(txtTZone.Text)

            sql = "UPDATE `stationqualifier` SET `belongsTo`='" & txtQualifierStation.Text & "',`qualifier`='" & txtqualifier.Text & "',`qualifierBeginDate`= " & dateb & " , `qualifierEndDate`= " & datee & " , `stationTimeZone`='" & stationTimeZone & "', `stationNetworkType`='" & ntwk & "' WHERE  `qualifier`" & qlfr & " AND `qualifierBeginDate` " & bdate & " AND `qualifierEndDate` " & edate & " AND `belongsTo`" & stn & ";"

            'MsgBox(sql)

            If Not Update_Rec(sql) Then
                MsgBox("Update Failed")
            Else
                MsgBox("Update Successful")
            End If

            'ClearStationHistoryForm()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdUpdateScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdUpdateScheduleClass.Click

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        Try

            ds.Tables("obsscheduleclass").Rows(rec).Item("scheduleClass") = txtClass.Text
            ds.Tables("obsscheduleclass").Rows(rec).Item("refersTo") = txtClassStation.Text
            ds.Tables("obsscheduleclass").Rows(rec).Item("description") = txtClassDescription.Text

            da.Update(ds, "obsscheduleclass")
            recUpdate.messageBoxRecordedUpdated()
            'ClearFormScheduleClass()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub cmdUpdateFeature_Click(sender As Object, e As EventArgs) Handles cmdUpdateFeature.Click

        'Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Dim recUpdate As New dataEntryGlobalRoutines
        Dim img As String

        Try

            'ds.Tables("physicalfeature").Rows(rec).Item("associatedWith") = txtFeatureStation.Text
            'ds.Tables("physicalfeature").Rows(rec).Item("beginDate") = txtFeaturedBdate.Text
            'ds.Tables("physicalfeature").Rows(rec).Item("endDate") = txtFeaturedEdate.Text
            'ds.Tables("physicalfeature").Rows(rec).Item("image") = txtfeaturepic.Image
            'ds.Tables("physicalfeature").Rows(rec).Item("description") = txtFeatureDescription.Text
            'ds.Tables("physicalfeature").Rows(rec).Item("classifiedInto") = txtFeatureClass.Text

            'da.Update(ds, "physicalfeature")
            'recUpdate.messageBoxRecordedUpdated()
            'ClearPhysicalFeatureForm()

            Dim stn, bdat, bdate, edate, ftr, cls As String

            stn = "= '" & metadfrm.pstn & "'"
            bdat = "= '" & metadfrm.pbdate & "'"
            ftr = "= '" & metadfrm.pfeature & "'"
            cls = "= '" & metadfrm.pclass & "'"

            ' Check for NULLs from the previous record
            If Len(metadfrm.pstn) = 0 Then stn = "IS NULL"
            If Len(metadfrm.pbdate) = 0 Then bdat = "IS NULL"
            If Len(metadfrm.pfeature) = 0 Then ftr = "IS NULL"
            If Len(metadfrm.pclass) = 0 Then cls = "IS NULL"

            ' Format for NULLs in the new values whose corresponding database fields are in indexed unique key
            If Len(txtFeatureBdate.Text) = 0 Then
                bdate = "= NULL"
            Else
                bdate = "='" & txtFeatureBdate.Text & "'"
            End If

            If Len(txtFeatureEdate.Text) = 0 Then
                edate = "= NULL"
            Else
                edate = "='" & txtFeatureEdate.Text & "'"
            End If

            'sql = "UPDATE `physicalfeature` SET `associatedWith`='8534002' ,`beginDate`='20/01/2018' ,`endDate`= '20/01/2015' ,`image`='climate.jpg' ,`description`='1', `classifiedInto`='1' WHERE  `description`='1' AND `beginDate`='20/01/2018' AND `classifiedInto`='1' AND `associatedWith`='8534002';"
            img = txtImageFile.Text
            sql = "UPDATE `physicalfeature` SET `associatedWith`='" & txtFeatureStation.Text & "' ,`beginDate`" & bdate & " ,`endDate`" & edate & ", `image`='" & img & "' ,`description`='" & txtFeatureDescription.Text & "', `classifiedInto`='" & txtFeatureClass.Text & "' WHERE  `description`" & ftr & " AND `beginDate` " & bdat & " AND `classifiedInto` " & cls & " AND `associatedWith`" & stn & ";"

            'MsgBox(sql)

            If Not Update_Rec(sql) Then
                MsgBox("Update Failed")
            Else
                MsgBox("Update Successful")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdDeleteInstrument_Click(sender As Object, e As EventArgs) Handles cmdDeleteInstrument.Click
        If DeleteRecord("instrument", rec) Then
            If rec < Kount - 1 Then
                populateInstrument("instrument", rec + 1, Kount)
            Else
                populateInstrument("instrument", rec, Kount)
            End If
        End If
    End Sub

    Private Sub cmdDeleteHistory_Click(sender As Object, e As EventArgs) Handles cmdDeleteHistory.Click
        sql = "Delete from stationlocationhistory where belongsTo ='" & txtlocStn.Text & "' and openingDatetime='" & txtOpDate.Text & "';"

        If Not Update_Rec(sql) Then
            MsgBox("Delete Failed")
        Else
            MsgBox("Record Deleted")
            ' Refresh records
            cmdLast3.PerformClick()
            cmdfirst3.PerformClick()
        End If

    End Sub

    Private Sub cmdDeleteQualier_Click(sender As Object, e As EventArgs) Handles cmdDeleteQualier.Click
        If DeleteRecord("stationqualifier", rec) Then
            SetDataSet("stationqualifier")
            populateStationQualifier("stationqualifier", 0, Kount)
        End If
    End Sub

    Private Sub cmdDeleteScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdDeleteScheduleClass.Click
        If DeleteRecord("obsscheduleclass", rec) Then
            SetDataSet("obsscheduleclass")
            populateScheduleClass("obsscheduleclass", 0, Kount)
        End If
    End Sub

    Private Sub cmdDeleteFeature_Click(sender As Object, e As EventArgs) Handles cmdDeleteFeature.Click
        If DeleteRecord("physicalfeature", rec) Then
            SetDataSet("physicalfeature")
            populatePhysicalFeature("physicalfeature", 0, Kount)
        End If
    End Sub

    Private Sub OpenDate_TextChanged(sender As Object, e As EventArgs) Handles OpenDate.TextChanged
        txtOpeningDate.Text = OpenDate.Text
    End Sub

    Private Sub ClosingDate_TextChanged(sender As Object, e As EventArgs) Handles ClosingDate.TextChanged
        If DateValue(ClosingDate.Text) <> DateValue(Now()) Then txtClosingDate.Text = ClosingDate.Text
    End Sub

    Private Function DMSToDD(Direction As Char, Deg As String, Min As String, Sec As String) As String
        ' Convert value in Degrees, Minutes and Seconds (DMS) to Decimal Degrees (DD)
        ' Direction must be N, S, E or W
        If IsNumeric(Deg) And IsNumeric(Min) And IsNumeric(Sec) And Not Direction = vbNullChar Then
            Dim multiplier As Integer = 1
            Dim decimalDegrees As Double
            If Direction = "S" OrElse Direction = "W" Then
                multiplier = -1
            End If
            decimalDegrees = multiplier * (Val(Deg) + Val(Min) / 60 + Val(Sec) / 3600)
            Return Math.Round(decimalDegrees, 2).ToString()
        Else
            Return ""
        End If
    End Function
    Private Sub lstNS_Click(sender As Object, e As EventArgs) Handles lstNS.SelectedIndexChanged
        txtLatitude.Text = DMSToDD(lstNS.SelectedItem, txtDegreesLat.Text, txtMinutesLat.Text, txtSecondsLat.Text)
    End Sub

    Private Sub lstEW_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEW.SelectedIndexChanged
        txtLongitude.Text = DMSToDD(lstEW.SelectedItem, txtDegreesLon.Text, txtMinutesLon.Text, txtSecondsLon.Text)
    End Sub

    Private Sub txtDegreesLat_TextChanged(sender As Object, e As EventArgs) Handles txtDegreesLat.TextChanged
        txtLatitude.Text = DMSToDD(lstNS.SelectedItem, txtDegreesLat.Text, txtMinutesLat.Text, txtSecondsLat.Text)
    End Sub

    Private Sub txtMinutesLat_TextChanged(sender As Object, e As EventArgs) Handles txtMinutesLat.TextChanged
        txtLatitude.Text = DMSToDD(lstNS.SelectedItem, txtDegreesLat.Text, txtMinutesLat.Text, txtSecondsLat.Text)
    End Sub

    Private Sub txtSecondsLat_TextChanged(sender As Object, e As EventArgs) Handles txtSecondsLat.TextChanged
        txtLatitude.Text = DMSToDD(lstNS.SelectedItem, txtDegreesLat.Text, txtMinutesLat.Text, txtSecondsLat.Text)
    End Sub

    Private Sub txtDegreesLon_TextChanged(sender As Object, e As EventArgs) Handles txtDegreesLon.TextChanged
        txtLongitude.Text = DMSToDD(lstEW.SelectedItem, txtDegreesLon.Text, txtMinutesLon.Text, txtSecondsLon.Text)
    End Sub

    Private Sub txtMinutesLon_TextChanged(sender As Object, e As EventArgs) Handles txtMinutesLon.TextChanged
        txtLongitude.Text = DMSToDD(lstEW.SelectedItem, txtDegreesLon.Text, txtMinutesLon.Text, txtSecondsLon.Text)
    End Sub

    Private Sub txtSecondsLon_TextChanged(sender As Object, e As EventArgs) Handles txtSecondsLon.TextChanged
        txtLongitude.Text = DMSToDD(lstEW.SelectedItem, txtDegreesLon.Text, txtMinutesLon.Text, txtSecondsLon.Text)
    End Sub

    'Private Sub ClosingDate_ValueChanged(sender As Object, e As EventArgs) Handles ClosingDate.ValueChanged
    '    txtClosingDate.Text = ClosingDate.Text
    'End Sub

    'Private Sub OpenDate_ValueChanged(sender As Object, e As EventArgs) Handles OpenDate.ValueChanged
    '    txtOpeningDate.Text = OpenDate.Text
    'End Sub

    Private Sub InstallDate_ValueChanged(sender As Object, e As EventArgs) Handles InstallDate.ValueChanged
        txtInstallDate.Text = InstallDate.Text
    End Sub


    Private Sub DeinstallDate_ValueChanged(sender As Object, e As EventArgs) Handles DeinstallDate.ValueChanged
        txtDeinstallDate.Text = DeinstallDate.Text
    End Sub

    Private Sub BeginDate_ValueChanged(sender As Object, e As EventArgs) Handles BeginDate.ValueChanged
        txtBeginDate.Text = BeginDate.Text
    End Sub

    Private Sub Endate_ValueChanged(sender As Object, e As EventArgs) Handles Endate.ValueChanged
        txtEndate.Text = Endate.Text
    End Sub


    Private Sub txtdOpDate_ValueChanged(sender As Object, e As EventArgs) Handles txtdOpDate.ValueChanged
        txtOpDate.Text = txtdOpDate.Text
    End Sub

    Private Sub txtdClosDate_ValueChanged(sender As Object, e As EventArgs) Handles txtdClosDate.ValueChanged
        txtClosDate.Text = txtdClosDate.Text
    End Sub

    Function Update_Rec(sq As String) As Boolean
        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        Try
            Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sq, dbconn)

            'Execute query
            objCmd.ExecuteNonQuery()
            'MsgBox("Record Successfully Updated")

            dbconn.Close()
            Update_Rec = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Update_Rec = False
            dbconn.Close()
        End Try
    End Function


    Private Sub txtdBDate_ValueChanged(sender As Object, e As EventArgs) Handles txtdBDate.ValueChanged
        txtBDate.Text = txtdBDate.Text
    End Sub

    Private Sub txtdEndDate_ValueChanged(sender As Object, e As EventArgs) Handles txtdEndDate.ValueChanged
        txtEndDate.Text = txtdEndDate.Text
    End Sub

    Private Sub txtFeaturedBdate_ValueChanged(sender As Object, e As EventArgs) Handles txtFeaturedBdate.ValueChanged
        txtFeatureBdate.Text = txtFeaturedBdate.Text
    End Sub

    Private Sub txtFeaturedEdate_ValueChanged(sender As Object, e As EventArgs) Handles txtFeaturedEdate.ValueChanged
        txtFeatureEdate.Text = txtFeaturedEdate.Text
    End Sub


    Private Sub txtfeaturepic_Click(sender As Object, e As EventArgs) Handles txtfeaturepic.Click

    End Sub

    Private Sub txtImageFile_TextChanged(sender As Object, e As EventArgs) Handles txtImageFile.TextChanged
        txtfeaturepic.ImageLocation = txtImageFile.Text
        txtfeaturepic.Refresh()
    End Sub

    Private Sub cmdOpenFile_Click(sender As Object, e As EventArgs) Handles cmdOpenFile.Click
        Dim img, fl As String

        fl = ""
        MetadataFileDialog.Filter = "Image files|*.jpg;*.emf;*.jpeg;*.gif;*.tif;*.bmp;*.png"
        MetadataFileDialog.ShowDialog()
        img = MetadataFileDialog.FileName

        For i = 1 To Len(img)
            If Strings.Mid(img, i, 1) = "\" Then
                fl = fl & "/"
            Else
                fl = fl & Strings.Mid(img, i, 1)
            End If
        Next

        'MsgBox(fl)
        txtImageFile.Text = fl
        txtImageFile.Refresh()

    End Sub

    Private Sub cmdInstrument_Click(sender As Object, e As EventArgs) Handles cmdInstrument.Click
        Dim img, fl As String

        fl = ""
        MetadataFileDialog.Filter = "Image files|*.jpg;*.emf;*.jpeg;*.gif;*.tif;*.bmp;*.png"
        MetadataFileDialog.ShowDialog()
        img = MetadataFileDialog.FileName

        For i = 1 To Len(img)
            If Strings.Mid(img, i, 1) = "\" Then
                fl = fl & "/"
            Else
                fl = fl & Strings.Mid(img, i, 1)
            End If
        Next

        'MsgBox(fl)
        txtInstrumentPicFile.Text = fl
        txtInstrumentPicFile.Refresh()
    End Sub

    Private Sub txtInstrumentPicFile_TextChanged(sender As Object, e As EventArgs) Handles txtInstrumentPicFile.TextChanged
        picInstrument.ImageLocation = txtInstrumentPicFile.Text
        picInstrument.Refresh()
    End Sub

End Class
Class MetadataVariables
    Public seStn, sebdate, Eecode, Iecode As String 'Variables for Station Element
    Public qlfr, bdate, edate, stn As String 'Variables for Station Qualifier
    Public pstn, pbdate, pedate, pfeature, pclass, pfile As String 'Valiables for Physical Feature
End Class