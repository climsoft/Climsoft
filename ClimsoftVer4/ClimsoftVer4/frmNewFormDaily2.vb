
Public Class frmNewFormDaily2
    Private bFirstLoad As Boolean = True

    Private Sub frmNewFormDaily2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        'Dim dtbVis, dtbCld, dtbPrec, dtbTemp As New DataTable
        'Dim dctNavigationFields As New Dictionary(Of String, List(Of String))
        'Dim dctNavigationKeyControls As New Dictionary(Of String, ucrBaseDataLink)

        ucrFormDaily.SetYearAndMonthLink(ucrYearSelector, ucrMonth)
        AssignLinkToKeyField(ucrFormDaily)

        'ucrVisibilityUnits.SetField("visUnits")
        'ucrVisibilityUnits.SetTableName("form_daily2")
        'ucrVisibilityUnits.bFillFromDataBase = False
        'dtbVis.Columns.Add("visUnits", GetType(String))
        'dtbVis.Rows.Add("metres")
        'dtbVis.Rows.Add("yards")
        'ucrVisibilityUnits.SetPossibleValues(dtbVis)

        ucrVisibilityUnits.SetTableNameAndField("form_daily2", "visUnits")
        ucrVisibilityUnits.SetPossibleValues("visUnits", GetType(String), {"metres", "yards"})

        AssignLinkToKeyField(ucrVisibilityUnits)
        ucrVisibilityUnits.PopulateControl()
        ucrVisibilityUnits.SetViewType("visUnits")

        'ucrCloudheightUnits.SetField("cloudHeightUnits")
        'ucrCloudheightUnits.SetTableName("form_daily2")
        'ucrCloudheightUnits.bFillFromDataBase = False
        'dtbCld.Columns.Add("cloudHeightUnits", GetType(String))
        'dtbCld.Rows.Add("metres")
        'dtbCld.Rows.Add("feet")
        'ucrCloudheightUnits.SetPossibleValues(dtbCld)

        ucrCloudheightUnits.SetTableNameAndField("form_daily2", "cloudHeightUnits")
        ucrCloudheightUnits.SetPossibleValues("cloudHeightUnits", GetType(String), {"metres", "feet"})
        AssignLinkToKeyField(ucrCloudheightUnits)
        ucrCloudheightUnits.PopulateControl()
        ucrCloudheightUnits.SetViewType("cloudHeightUnits")

        'ucrPrecipUnits.SetField("precipUnits")
        'ucrPrecipUnits.SetTableName("form_daily2")
        'ucrPrecipUnits.bFillFromDataBase = False
        'dtbPrec.Columns.Add("precipUnits", GetType(String))
        'dtbPrec.Rows.Add("mm")
        'dtbPrec.Rows.Add("inches")
        'ucrPrecipUnits.SetPossibleValues(dtbPrec)
        ucrPrecipUnits.SetTableNameAndField("form_daily2", "precipUnits")
        ucrPrecipUnits.SetPossibleValues("precipUnits", GetType(String), {"mm", "inches"})
        AssignLinkToKeyField(ucrPrecipUnits)
        ucrPrecipUnits.PopulateControl()
        ucrPrecipUnits.SetViewType("precipUnits")

        'ucrTempUnits.SetField("temperatureUnits")
        'ucrTempUnits.SetTableName("form_daily2")
        'ucrTempUnits.bFillFromDataBase = False
        'dtbTemp.Columns.Add("temperatureUnits", GetType(String))
        'dtbTemp.Rows.Add("Deg C")
        'dtbTemp.Rows.Add("Deg F")
        'ucrTempUnits.SetPossibleValues(dtbTemp)
        ucrTempUnits.SetTableNameAndField("form_daily2", "temperatureUnits")
        ucrTempUnits.SetPossibleValues("temperatureUnits", GetType(String), {"Deg C", "Deg F"})
        AssignLinkToKeyField(ucrTempUnits)
        ucrTempUnits.PopulateControl()
        ucrTempUnits.SetViewType("temperatureUnits")

        'ucrInputSequncer.SetTableName("seq_daily_element")
        'ucrInputSequncer.SetField("seq")
        'ucrInputSequncer.SetTableNameAndField("seq_daily_element", "seq")
        'ucrInputSequncer.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)


        'dctNavigationFields.Add("stationId", New List(Of String)({"stationId"}))
        'dctNavigationFields.Add("elementId", New List(Of String)({"elementId"}))
        'dctNavigationFields.Add("yyyy", New List(Of String)({"yyyy"}))
        'dctNavigationFields.Add("mm", New List(Of String)({"mm"}))
        'dctNavigationFields.Add("hh", New List(Of String)({"hh"}))

        'ucrDaiy2Navigation.SetFields(dctNavigationFields)
        'ucrDaiy2Navigation.SetTableName("form_daily2")

        ucrDaiy2Navigation.SetTableNameAndFields("form_daily2", (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "hh"})))

        'dctNavigationKeyControls.Add("stationId", ucrStationSelector)
        'dctNavigationKeyControls.Add("elementId", ucrElementSelector)
        'dctNavigationKeyControls.Add("yyyy", ucrYearSelector)
        'dctNavigationKeyControls.Add("mm", ucrMonth)
        'dctNavigationKeyControls.Add("hh", ucrHour)

        'ucrDaiy2Navigation.SetKeyControls(dctNavigationKeyControls)
        ucrDaiy2Navigation.SetKeyControls("stationId", ucrStationSelector)
        ucrDaiy2Navigation.SetKeyControls("elementId", ucrElementSelector)
        ucrDaiy2Navigation.SetKeyControls("yyyy", ucrYearSelector)
        ucrDaiy2Navigation.SetKeyControls("mm", ucrMonth)
        ucrDaiy2Navigation.SetKeyControls("hh", ucrHour)

        ucrFormDaily.SetLinkedNavigation(ucrDaiy2Navigation)
        ucrDaiy2Navigation.PopulateControl()
        SaveEnable()
        'ucrFormDaily.PopulateControl()
    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)
    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        For Each ctl In ucrFormDaily.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                ctrltemp.ucrValue.SetValue(ucrInputValue.GetValue())
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrFormDaily.Clear()
        ucrDaiy2Navigation.ResetControls()
        SaveEnable()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        'Confirm if you want to continue and save data from key-entry form to database table
        Dim dlgResponse As DialogResult
            dlgResponse = MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgResponse = DialogResult.Yes Then

            If ucrFormDaily.bUpdating Then
                'Possibly we should be cloning and then updating here
            Else
                clsDataConnection.db.form_daily2.Add(ucrFormDaily.fd2Record)
            End If
            clsDataConnection.SaveUpdate()
            SaveEnable()
        Else
                MessageBox.Show("Record not Saved?", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_daily2.Attach(ucrFormDaily.fd2Record)
                clsDataConnection.db.form_daily2.Remove(ucrFormDaily.fd2Record)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrDaiy2Navigation.RemoveRecord()
                SaveEnable()
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
    End Sub

    Private Sub SetNewRecord(strSequencertext As String)
        'Set key controls to next new record based on sequencer text

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True


        SetNewRecord(txtSequencer.Text)

        'May want to change sequencer when year changes but not here

        'If ucrYearSelector.isLeapYear Then
        '    txtSequencer.Text = "seq_month_day_leap_yr"
        'Else
        '    txtSequencer.Text = "seq_month_day"
        'End If
        ucrFormDaily.ucrValueFlagPeriod1.Focus()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        If ucrDaiy2Navigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                clsDataConnection.db.Entry(ucrFormDaily.fd2Record).State = Entity.EntityState.Modified
                clsDataConnection.db.SaveChanges()

                MessageBox.Show(Me, "Record updated successfully!", "Update Record", MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_daily2"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
        Else
            sql = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_daily2")
    End Sub
End Class