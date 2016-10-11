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
        MsgBox(TabMetadata.SelectedIndex)
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
            da.Fill(ds, tbl)
            Kount = ds.Tables(tbl).Rows.Count
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TabStation_Click(sender As Object, e As EventArgs) Handles TabStation.Click
        MsgBox("Station")
    End Sub

    Private Sub TabMetadata_Click(sender As Object, e As EventArgs) Handles TabMetadata.Click
        'MsgBox(TabMetadata.SelectedIndex)
        ActiveTab = TabMetadata.SelectedIndex
        Select Case TabMetadata.SelectedIndex
            Case 0 ' Station
                SetDataSet("station")
                rec = 0
                populateStations("station", rec, Kount)

                'populateSearchStation()
            Case 1 ' obselement
                SetDataSet("obselement")
                rec = 0
                populateElementMetadata("obselement", rec, Kount)
            Case 2 ' StationElement
                FillList(txtStation, "station", "stationId")
                FillList(txtElement, "obselement", "elementId")
                FillList(txtImstrument, "instrument", "instrumentId")

                SetDataSet("stationelement")
                rec = 0
                populateStationElement("stationelement", rec, Kount)
            Case 3 ' Instrument
                FillList(txtInstrStn, "station", "stationId")
                SetDataSet("instrument")
                rec = 0
                'populateInstrumentForm("instrument", rec, Kount)
            Case 4 ' Station Location History
                FillList(txtlocStn, "station", "stationId")
                FillList(txtInstrStn, "station", "stationId")
                SetDataSet("stationlocationhistory")
                rec = 0
                'populateHistorytForm("stationlocationhistory", rec, Kount)
            Case 5 ' Station Qualifier
                FillList(txtQualifierStation, "station", "stationId")
                SetDataSet("stationqualifier")
                rec = 0
                'populateQualifierForm("stationqualifier", rec, Kount)
            Case 6 ' Schedule Class
                FillList(txtClassStation, "station", "stationId")
                SetDataSet("obsscheduleclass")
                rec = 0
                'populateScheduleForm("scheduleclass", rec, Kount)
            Case 7 ' Physical Feature
                FillList(txtFeatureStation, "station", "stationId")
                SetDataSet("physicalfeature")
                rec = 0
                'populateFeatureForm("physicalfeature", rec, Kount)
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

        txtRecNumber.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows


    End Sub
    Sub populateElementMetadata(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next

        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementId")) Then txtId.Text = ds.Tables(frm).Rows(num).Item("elementId")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("abbreviation")) Then txtAbbreviation.Text = ds.Tables(frm).Rows(num).Item("abbreviation")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementName")) Then txtName.Text = ds.Tables(frm).Rows(num).Item("elementName")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("description")) Then txtDescription.Text = ds.Tables(frm).Rows(num).Item("description")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementScale")) Then txtScale.Text = ds.Tables(frm).Rows(num).Item("elementScale")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("upperLimit")) Then txtUpperLimit.Text = ds.Tables(frm).Rows(num).Item("upperLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("lowerLimit")) Then txtLowerLimit.Text = ds.Tables(frm).Rows(num).Item("lowerLimit")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("units")) Then txtUnit.Text = ds.Tables(frm).Rows(num).Item("units")
        If Not IsDBNull(ds.Tables(frm).Rows(num).Item("elementtype")) Then txtType.Text = ds.Tables(frm).Rows(num).Item("elementtype")

        txtElementNavigator.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows

    End Sub
    Sub populateStationElement(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next

        txtStation.Text = ds.Tables(frm).Rows(num).Item("recordedFrom")
        txtElement.Text = ds.Tables(frm).Rows(num).Item("describedBy")
        txtImstrument.Text = ds.Tables(frm).Rows(num).Item("recordedWith")
        txtScheduleClass.Text = ds.Tables(frm).Rows(num).Item("scheduledFor")
        txtHeight.Text = ds.Tables(frm).Rows(num).Item("height")
        txtBeginDate.Text = ds.Tables(frm).Rows(num).Item("beginDate")
        txtEndate.Text = ds.Tables(frm).Rows(num).Item("endDate")

        If maxRows > 0 Then txtNavigator1.Text = rec + 1 & " of " & maxRows - 1 '"Record 1 of " & maxRows
    End Sub
    Sub populatePaperArchiveDefinition(frm As String, num As Integer, maxRows As Integer)
        On Error Resume Next

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
        If rec < Kount Then
            rec = rec + 1
            populateStations("station", rec, Kount)
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click

        rec = Kount - 2
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
            dsNewRow.Item("openingDatetime") = txtOpenDate.Value
            If IsDate(txtClosingDate.Text) Then dsNewRow.Item("closingDatetime") = txtClosingDate.Text
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
        rec = Kount - 2
        populateElementMetadata("obselement", rec, Kount)
    End Sub

    Private Sub cmdPrevoius_Click(sender As Object, e As EventArgs) Handles cmdPrevoius.Click
        If rec > 0 Then
            rec = rec - 1
            populateElementMetadata("obselement", rec, Kount)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If rec < Kount Then
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

        'If cmdtype = "update" Then recUpdate.messageBoxRecordedUpdated()
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
        If DeleteRecord("paperarchive efinition", rec) Then

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
End Class