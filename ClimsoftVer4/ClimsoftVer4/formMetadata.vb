Public Class formMetadata
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim ActiveTab As Integer
    'Dim maxRows As Integer

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub formMetadata_Click(sender As Object, e As EventArgs) Handles Me.Click
        'MsgBox(TabMetadata.SelectedIndex)
    End Sub

    Private Sub formMetadata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        SetDataSet("station")
        rec = 0
        populateStations("station", rec, Kount)
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
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("country")) Then txtCountry.Text = ds.Tables("station").Rows(num).Item("country")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("longitude")) Then txtLatitude.Text = ds.Tables("station").Rows(num).Item("latitude")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("openingdatetime")) Then txtLongitude.Text = ds.Tables("station").Rows(num).Item("longitude")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("elevation")) Then txtElevation.Text = ds.Tables("station").Rows(num).Item("elevation")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("openingdatetime")) Then txtOpenDate.Text = ds.Tables("station").Rows(num).Item("openingdatetime")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("closingdatetime")) Then txtClosingDate.Text = ds.Tables("station").Rows(num).Item("closingdatetime")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("authority")) Then txtAuthority.Text = ds.Tables("station").Rows(num).Item("authority")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("adminregion")) Then txtAdminRegion.Text = ds.Tables("station").Rows(num).Item("adminregion")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("drainagebasin")) Then txtDrainageBasin.Text = ds.Tables("station").Rows(num).Item("drainagebasin")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("geolocationmethod")) Then txtgeoMethod.Text = ds.Tables("station").Rows(num).Item("geolocationmethod")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("geolocationaccuracy")) Then txtgeoAccuracy.Text = ds.Tables("station").Rows(num).Item("geolocationaccuracy")
        If Not IsDBNull(ds.Tables("station").Rows(num).Item("stationoperational")) Then txtStationOperation.CheckState = ds.Tables("station").Rows(num).Item("stationoperational")

        txtRecNumber.Text = rec + 1 & " of " & maxRows '"Record 1 of " & maxRows


    End Sub
    Sub populateElementMetadata(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementId")) Then txtId.Text = ds.Tables(frm).Rows(num).Item("elementId")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("abbreviation")) Then txtAbbreviation.Text = ds.Tables(frm).Rows(num).Item("abbreviation")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementName")) Then txtName.Text = ds.Tables(frm).Rows(num).Item("elementName")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("description")) Then txtDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementScale")) Then txtScale.Text = ds.Tables(frm).Rows(num).Item("elementScale")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("upperLimit")) Then txtUpperLimit.Text = ds.Tables(frm).Rows(num).Item("upperLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("lowerLimit")) Then txtLowerLimit.Text = ds.Tables(frm).Rows(num).Item("lowerLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("units")) Then txtUnit.Text = ds.Tables(frm).Rows(num).Item("units")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementtype")) Then txtType.Text = ds.Tables(frm).Rows(num).Item("elementtype")

        txtElementNavigator.Text = rec + 1 & " of " & maxRows '"Record 1 of " & maxRows

    End Sub
    Sub populateStationElement(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        'MsgBox(num & " " & maxRows)
        txtStation.Text = ds.Tables(frm).Rows(num).Item("recordedFrom")
        txtElement.Text = ds.Tables(frm).Rows(num).Item("describedBy")
        txtInstrument.Text = ds.Tables(frm).Rows(num).Item("recordedWith")
        txtScheduleClass.Text = ds.Tables(frm).Rows(num).Item("scheduledFor")
        txtHeight.Text = ds.Tables(frm).Rows(num).Item("height")
        txtBeginDate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtEndate.Text = ds.Tables(frm).Rows(num).Item("endDate")

        If maxRows > 0 Then txtNavigator1.Text = rec + 1 & " of " & maxRows ' - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateInstrument(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        'MsgBox(num & " " & maxRows)
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
        picInstrument.Image = ds.Tables(frm).Rows(num).Item("instrumentPicture")

        If maxRows > 0 Then txtNavigator2.Text = rec + 1 & " of " & maxRows ' - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populateStationHistory(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
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
        txtqualifier.Text = ds.Tables(frm).Rows(num).Item("qualifier")
        txtQualifierStation.Text = ds.Tables(frm).Rows(num).Item("belongsTo")
        txtBDate.Text = ds.Tables(frm).Rows(num).Item("qualifierBeginDate")
        txtEndDate.Text = ds.Tables(frm).Rows(num).Item("qualifierEndDate")
        txtTZone.Text = ds.Tables(frm).Rows(num).Item("stationTimeZone")
        txtNetwork.Text = ds.Tables(frm).Rows(num).Item("stationNetworkType")

        If maxRows > 0 Then txtNav4.Text = rec + 1 & " of " & maxRows
    End Sub
    Sub populateScheduleClass(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        txtClass.Text = ds.Tables(frm).Rows(num).Item("scheduleClass")
        txtClassStation.Text = ds.Tables(frm).Rows(num).Item("refersTo")
        txtClassDescription.Text = ds.Tables(frm).Rows(num).Item("description")

        If maxRows > 0 Then txtNav5.Text = rec + 1 & " of " & maxRows
    End Sub
    Sub populatePhysicalFeature(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next
        If maxRows = 0 Then Exit Sub
        SetDataSet(frm)
        txtFeatureStation.Text = ds.Tables(frm).Rows(num).Item("associatedWith")
        txtFeatureBdate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtFeatureEdate.Text = ds.Tables(frm).Rows(num).Item("endDate")
        txtfeaturepic.Image = ds.Tables(frm).Rows(num).Item("image")
        txtFeatureDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        txtFeatureClass.Text = ds.Tables(frm).Rows(num).Item("classifiedInto")
        txtfeatureclassdescription.Text = ds.Tables(frm).Rows(num).Item("classifiedInto")

        If maxRows > 0 Then txtNav6.Text = rec + 1 & " of " & maxRows
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

        Try
            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines

            dsNewRow = ds.Tables("station").NewRow
            dsNewRow.Item("stationId") = txtstationId.Text
            dsNewRow.Item("stationName") = txtStationName.Text
            dsNewRow.Item("country") = txtCountry.Text
            If IsNumeric(txtLatitude.Text) Then dsNewRow.Item("latitude") = Val(txtLatitude.Text)
            If IsNumeric(txtLongitude.Text) Then dsNewRow.Item("longitude") = Val(txtLongitude.Text)
            If IsNumeric(txtElevation.Text) Then dsNewRow.Item("elevation") = Val(txtElevation.Text)
            dsNewRow.Item("adminRegion") = txtAdminRegion.Text
            dsNewRow.Item("drainageBasin") = txtDrainageBasin.Text
            dsNewRow.Item("authority") = txtAuthority.Text
            If IsNumeric(txtgeoAccuracy.Text) Then dsNewRow.Item("geolocationAccuracy") = Val(txtgeoAccuracy.Text)
            If IsNumeric(txtgeoMethod.Text) Then dsNewRow.Item("geolocationMethod") = Val(txtgeoMethod.Text)
            
            If IsDate(txtOpenDate.Text) Then
                ' Opening date can only be in the past
                If DateDiff(DateInterval.Day, DateValue(txtOpenDate.Text), Now) > 0 Then dsNewRow.Item("openingDatetime") = txtOpenDate.Text
            End If

            If IsDate(txtClosingDate.Text) Then
                ' Opening date can only be in the past
                If DateDiff(DateInterval.Day, DateValue(txtClosingDate.Text), Now) > 0 Then dsNewRow.Item("closingDatetime") = txtClosingDate.Text
            End If

            dsNewRow.Item("stationoperational") = txtStationOperation.CheckState

            'Add a new record to the data source table
            ds.Tables("station").Rows.Add(dsNewRow)
            da.Update(ds, "station")
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
        txtCountry.Clear()
        txtAuthority.Clear()
        txtLatitude.Clear()
        txtLongitude.Clear()
        txtElevation.Clear()
        txtAdminRegion.Clear()
        txtDrainageBasin.Clear()
        txtgeoAccuracy.Clear()
        txtgeoMethod.Clear()
        txtOpenDate.Text = ""
        txtClosingDate.Text = ""
        txtStationOperation.CheckState = CheckState.Unchecked
        txtRecNumber.Clear()

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
        txtElementNavigator.Clear()

    End Sub
    Sub ClearStationElementForm()
        txtStation.Text = ""
        txtElement.Text = ""
        txtInstrument.Text = ""
        txtScheduleClass.Text = ""
        txtHeight.Text = ""
        txtBeginDate.Text = ""
        txtEndate.Text = ""
    End Sub
    Sub ClearInstrumentForm()
        txtInstName.Text = ""
        txtInstrumentId.Text = ""
        txtSerial.Text = ""
        txtAbbrev.Text = ""
        txtModel.Text = ""
        txtManufacturer.Text = ""
        txtUncertainity.Text = ""
        txtInstallDate.Text = ""
        txtDeinstallDate.Text = ""
        txthgt.Text = ""
        'picInstrument.Image = ""
        txtInstrStn.Text = ""
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
    End Sub
    Sub ClearStationQualifierForm()
        txtqualifier.Text = ""
        txtQualifierStation.Text = ""
        txtBDate.Text = ""
        txtEndDate.Text = ""
        txtTZone.Text = ""
        txtNetwork.Text = ""
    End Sub
    Sub ClearFormScheduleClass()
        txtClass.Text = ""
        txtClassStation.Text = ""
        txtClassDescription.Text = ""
    End Sub
    Sub ClearPhysicalFeatureForm()
        txtFeatureClass.Text = ""
        txtFeatureStation.Text = ""
        txtfeatureclassdescription.Text = ""
        txtFeatureStation.Text = ""
        txtFeatureBdate.Text = ""
        txtFeatureEdate.Text = ""
        'txtfeaturepic.Image
        txtFeatureDescription.Text = ""
        txtFeatureClass.Text = ""
    End Sub
    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        If txtstationId.Text = "" Then
            MsgBox("No record Selected")
        Else
            TableUpdate(rec, "update")
        End If
    End Sub
    Function TableUpdate(recs As Integer, cmdtype As String) As Boolean
        TableUpdate = True

        Try

            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim recUpdate As New dataEntryGlobalRoutines

            ds.Tables("station").Rows(recs).Item("stationId") = txtstationId.Text
            ds.Tables("station").Rows(recs).Item("stationName") = txtStationName.Text
            ds.Tables("station").Rows(recs).Item("country") = txtCountry.Text
            If IsNumeric(txtLatitude.Text) Then ds.Tables("station").Rows(recs).Item("latitude") = Val(txtLatitude.Text)
            If IsNumeric(txtLongitude.Text) Then ds.Tables("station").Rows(recs).Item("longitude") = Val(txtLongitude.Text)
            If IsNumeric(txtElevation.Text) Then ds.Tables("station").Rows(recs).Item("elevation") = Val(txtElevation.Text)
            ds.Tables("station").Rows(recs).Item("adminRegion") = txtAdminRegion.Text
            ds.Tables("station").Rows(recs).Item("drainageBasin") = txtDrainageBasin.Text
            ds.Tables("station").Rows(recs).Item("authority") = txtAuthority.Text
            If IsNumeric(txtgeoAccuracy.Text) Then ds.Tables("station").Rows(recs).Item("geolocationAccuracy") = Val(txtgeoAccuracy.Text)
            If IsNumeric(txtgeoMethod.Text) Then ds.Tables("station").Rows(recs).Item("geolocationMethod") = Val(txtgeoMethod.Text)
            ds.Tables("station").Rows(recs).Item("openingDatetime") = txtOpenDate.Value
            If IsDate(txtClosingDate.Text) Then ds.Tables("station").Rows(recs).Item("closingDatetime") = txtClosingDate.Text
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
        On Error GoTo Err
        ds.Tables(tbl).Rows(recs).Delete()
        da.Update(ds, tbl)

        'If rec < Kount - 1 Then
        '    populateStations("station", rec + 1, Kount)
        'Else
        '    populateStations("station", rec, Kount)
        'End If

        Exit Function
Err:
        MsgBox(Err.Description)
        DeleteRecord = False
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
        On Error GoTo Err
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines

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

        'Add a new record to the data source table
        ds.Tables("obselement").Rows.Add(dsNewRow)
        da.Update(ds, "obselement")
        ClearElementForm()
        Exit Sub
Err:
        If Err.Number = 5 Then
            MsgBox("Invalid Entries; Check values")
            Exit Sub
        End If
        MsgBox(Err.Number & " : " & Err.Description)

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
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()
        da.Fill(dstn, tbl)

        For i = 0 To dstn.Tables(tbl).Rows.Count - 1
            lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(idxfld))
        Next
    End Sub

    Private Sub GroupBox2_Enter_1(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
    Private Sub txtElementNavigator_TextChanged(sender As Object, e As EventArgs) Handles txtElementNavigator.TextChanged

    End Sub
    Private Sub TabMetadata_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabMetadata.SelectedIndexChanged

    End Sub




    Private Sub GroupBox10_Enter(sender As Object, e As EventArgs) Handles GroupBox10.Enter

    End Sub
    Private Sub txtNav2_TextChanged(sender As Object, e As EventArgs) Handles txtNav2.TextChanged

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
            dsNewRow.Item("recordedWith") = txtinstrument.Text
            dsNewRow.Item("scheduledFor") = txtScheduleClass.Text
            dsNewRow.Item("height") = txtHeight.Text
            dsNewRow.Item("beginDate") = txtBeginDate.Text
            dsNewRow.Item("endDate") = txtEndate.Text

            'Add a new record to the data source table
            ds.Tables("stationelement").Rows.Add(dsNewRow)
            da.Update(ds, "stationelement")
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

        formDataView.DataGridView.Dock = DockStyle.Top

    End Sub


    Private Sub cmdViewElements_Click(sender As Object, e As EventArgs) Handles cmdViewElements.Click
        RecordsView("obselement")
    End Sub

    Private Sub cmdViewStElement_Click(sender As Object, e As EventArgs) Handles cmdViewStElement.Click
        RecordsView("stationelement")
    End Sub

    Private Sub cmdViewInstrument_Click(sender As Object, e As EventArgs) Handles cmdViewInstrument.Click
        RecordsView("instrument")
    End Sub

    Private Sub cmdViewHistory_Click(sender As Object, e As EventArgs) Handles cmdViewHistory.Click
        RecordsView("stationlocationhistory")
    End Sub

    Private Sub cmdDeleteView_Click(sender As Object, e As EventArgs) Handles cmdDeleteView.Click
        RecordsView("stationqualifier")
    End Sub

    Private Sub cmdViewScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdViewScheduleClass.Click
        RecordsView("obsscheduleclass")
    End Sub

    Private Sub cmdViewFeature_Click(sender As Object, e As EventArgs) Handles cmdViewFeature.Click
        RecordsView("physicalfeature")
    End Sub

    Private Sub cmdViewPaperArchive_Click(sender As Object, e As EventArgs) Handles cmdViewPaperArchive.Click
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


    Private Sub txtstationId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtstationId.SelectedIndexChanged

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

            ClearInstrumentForm()

        Catch ex As Exception
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
            dsNewRow.Item("qualifierBeginDate") = txtBDate.Text
            dsNewRow.Item("qualifierEndDate") = txtEndDate.Text
            dsNewRow.Item("stationTimeZone") = txtTZone.Text
            dsNewRow.Item("stationNetworkType") = txtNetwork.Text


            'Add a new record to the data source table
            ds.Tables("stationqualifier").Rows.Add(dsNewRow)
            da.Update(ds, "stationqualifier")

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
            dsNewRow.Item("description") = txtfeatureclassdescription.Text

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
            dsNewRowp.Item("beginDate") = txtFeatureBdate.Text
            dsNewRowp.Item("endDate") = txtFeatureEdate.Text
            dsNewRowp.Item("image") = txtfeaturepic.Image
            dsNewRowp.Item("description") = txtFeatureDescription.Text
            dsNewRowp.Item("classifiedInto") = txtFeatureClass.Text

            'Add a new record to the data source table
            ds.Tables("physicalfeature").Rows.Add(dsNewRowp)
            da.Update(ds, "physicalfeature")

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
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

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
        'dsNewRow.Item("instrumentPicture") = picInstrument.Image
        ds.Tables("instrument").Rows(rec).Item("installedAt") = txtInstrStn.Text


        da.Update(ds, "instrument")
        recUpdate.messageBoxRecordedUpdated()

        ClearInstrumentForm()

        Exit Sub

Err:
        'MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdUpdateStElement_Click(sender As Object, e As EventArgs) Handles cmdUpdateStElement.Click
        On Error Resume Next

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        'If txtId.Text = "" Then
        '    MsgBox("No record Selected")
        '    Exit Sub
        'End If

        'MsgBox(txtHeight.Text)
        ds.Tables("stationelement").Rows(rec).Item("recordedFrom") = txtStation.Text
        ds.Tables("stationelement").Rows(rec).Item("describedBy") = txtElement.Text
        ds.Tables("stationelement").Rows(rec).Item("recordedWith") = txtInstrument.Text
        ds.Tables("stationelement").Rows(rec).Item("scheduledFor") = txtScheduleClass.Text
        ds.Tables("stationelement").Rows(rec).Item("height") = txtHeight.Text
        ds.Tables("stationelement").Rows(rec).Item("beginDate") = txtBeginDate.Text
        ds.Tables("stationelement").Rows(rec).Item("endDate") = txtEndate.Text

        da.Update(ds, "stationelement")

        recUpdate.messageBoxRecordedUpdated()
        ClearStationElementForm()

        Exit Sub

Err:
        'MsgBox(Err.Number & " " & Err.Description)
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
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        'If txtId.Text = "" Then
        '    MsgBox("No record Selected")
        '    Exit Sub
        'End If

        ds.Tables("stationlocationhistory").Rows(rec).Item("belongsTo") = txtlocStn.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("stationType") = txtStnType.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("geoLocationMethod") = txtMethod.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("geoLocationAccuracy") = txtAccuracy.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("openingDatetime") = txtOpDate.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("closingDatetime") = txtClosDate.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("latitude") = txtLat.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("longitude") = txtLon.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("elevation") = txtElev.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("authority") = txtAuth.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("adminRegion") = txtAdmin.Text
        ds.Tables("stationlocationhistory").Rows(rec).Item("drainageBasin") = txtDrgBasin.Text

        da.Update(ds, "stationlocationhistory")

        recUpdate.messageBoxRecordedUpdated()

        ClearStationHistoryForm()
        Exit Sub

Err:

        'MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdUpdateQualier_Click(sender As Object, e As EventArgs) Handles cmdUpdateQualier.Click
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        'If txtId.Text = "" Then
        '    MsgBox("No record Selected")
        '    Exit Sub
        'End If
        ds.Tables("stationqualifier").Rows(rec).Item("belongsTo") = txtlocStn.Text
        ds.Tables("stationqualifier").Rows(rec).Item("qualifier") = txtqualifier.Text
        ds.Tables("stationqualifier").Rows(rec).Item("belongsTo") = txtQualifierStation.Text
        ds.Tables("stationqualifier").Rows(rec).Item("qualifierBeginDate") = txtBDate.Text
        ds.Tables("stationqualifier").Rows(rec).Item("qualifierEndDate") = txtEndDate.Text
        ds.Tables("stationqualifier").Rows(rec).Item("stationTimeZone") = txtTZone.Text
        ds.Tables("stationqualifier").Rows(rec).Item("stationNetworkType") = txtNetwork.Text

        da.Update(ds, "stationqualifier")

        recUpdate.messageBoxRecordedUpdated()

        ClearStationQualifierForm()
        Exit Sub

Err:
        'MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdUpdateScheduleClass_Click(sender As Object, e As EventArgs) Handles cmdUpdateScheduleClass.Click

        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        'If txtId.Text = "" Then
        '    MsgBox("No record Selected")
        '    Exit Sub
        'End If

        ds.Tables("obsscheduleclass").Rows(rec).Item("scheduleClass") = txtClass.Text
        ds.Tables("obsscheduleclass").Rows(rec).Item("refersTo") = txtClassStation.Text
        ds.Tables("obsscheduleclass").Rows(rec).Item("description") = txtClassDescription.Text

        da.Update(ds, "obsscheduleclass")
        recUpdate.messageBoxRecordedUpdated()
        ClearFormScheduleClass()

        Exit Sub

Err:
        'MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdUpdateFeature_Click(sender As Object, e As EventArgs) Handles cmdUpdateFeature.Click
        On Error GoTo Err

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recUpdate As New dataEntryGlobalRoutines

        'If txtId.Text = "" Then
        '    MsgBox("No record Selected")
        '    Exit Sub
        'End If

        ds.Tables("physicalfeature").Rows(rec).Item("associatedWith") = txtFeatureStation.Text
        ds.Tables("physicalfeature").Rows(rec).Item("beginDate") = txtFeatureBdate.Text
        ds.Tables("physicalfeature").Rows(rec).Item("endDate") = txtFeatureEdate.Text
        ds.Tables("physicalfeature").Rows(rec).Item("image") = txtfeaturepic.Image
        ds.Tables("physicalfeature").Rows(rec).Item("description") = txtFeatureDescription.Text
        ds.Tables("physicalfeature").Rows(rec).Item("classifiedInto") = txtFeatureClass.Text

        da.Update(ds, "physicalfeature")
        recUpdate.messageBoxRecordedUpdated()
        ClearPhysicalFeatureForm()

        Exit Sub
Err:
        'MsgBox(Err.Number & " " & Err.Description)
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
        If DeleteRecord("stationlocationhistory", rec) Then
            SetDataSet("stationlocationhistory")
            populateStationHistory("stationlocationhistory", 0, Kount)
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
    Private Function DMSToDD(Direction As Char, Deg As String, Min As String, Sec As String) As Double
        ' Convert value in Degrees, Minutes and Seconds (DMS) to Decimal Degrees (DD)
        ' Direction must be N, S, E or W
        'MsgBox(1)
        Dim multiplier As Integer = 1
        Dim decimalDegrees As Double
        If Direction = "S" OrElse Direction = "W" Then
            multiplier = -1
        End If
        decimalDegrees = multiplier * (Val(Deg) + Val(Min) / 60 + Val(Sec) / 3600)
        Return Math.Round(decimalDegrees, 2)
    End Function
    Private Sub lstNS_Click(sender As Object, e As EventArgs) Handles lstNS.SelectedIndexChanged
        If IsNumeric(txtDegreesLat.Text) And IsNumeric(txtMinutesLat.Text) And IsNumeric(txtSecondsLat.Text) Then
            txtLatitude.Text = DMSToDD(lstNS.SelectedItem, txtDegreesLat.Text, txtMinutesLat.Text, txtSecondsLat.Text)
        End If
    End Sub

    Private Sub lstEW_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEW.SelectedIndexChanged
        If IsNumeric(txtDegreesLon.Text) And IsNumeric(txtMinutesLon.Text) And IsNumeric(txtSecondsLon.Text) Then
            txtLongitude.Text = DMSToDD(lstEW.SelectedItem, txtDegreesLon.Text, txtMinutesLon.Text, txtSecondsLon.Text)
        End If
    End Sub
End Class