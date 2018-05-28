
Public Class frmNewFormDaily2
    Private bFirstLoad As Boolean = True

    Private Sub frmNewFormDaily2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run InitaliseDialog only if its first load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrFormDaily.SetKeyControls(ucrNewYear:=ucrYearSelector, ucrNewMonth:=ucrMonth, ucrNewHour:=ucrHour, ucrNewStation:=ucrStationSelector, ucrNewElement:=ucrElementSelector, ucrNewNavigation:=ucrDaiy2Navigation, ucrNewVisibilityUnits:=ucrVisibilityUnits, ucrNewCloudheightUnits:=ucrCloudheightUnits, ucrNewPrecipUnits:=ucrPrecipUnits, ucrNewTempUnits:=ucrTempUnits)
        ' Currently only works with this sequencer table so textbox disabled
        txtSequencer.Text = "seq_daily_element"
        txtSequencer.Enabled = False
        chkEnableSequencer.Checked = True

        'Sets the linked year and month controls to enable appropraite field for different months
        ' ucrFormDaily.SetYearAndMonthLink(ucrYearSelector, ucrMonth)

        'Sets values for the units combobox
        ucrVisibilityUnits.SetPossibleValues("visUnits", GetType(String), {"metres", "yards"})
        ucrVisibilityUnits.SetDisplayAndValueMember("visUnits")

        ucrCloudheightUnits.SetPossibleValues("cloudHeightUnits", GetType(String), {"metres", "feet"})
        ucrCloudheightUnits.SetDisplayAndValueMember("cloudHeightUnits")

        ucrPrecipUnits.SetPossibleValues("precipUnits", GetType(String), {"mm", "inches"})
        ucrPrecipUnits.SetDisplayAndValueMember("precipUnits")

        ucrTempUnits.SetPossibleValues("temperatureUnits", GetType(String), {"Deg C", "Deg F"})
        ucrTempUnits.SetDisplayAndValueMember("temperatureUnits")

        ucrDaiy2Navigation.PopulateControl()
        SaveEnable()

    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        'Loops through the value inputs textboxes and sets same value for all observations
        For Each ctl In ucrFormDaily.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                ctrltemp.ucrValue.SetValue(ucrInputValue.GetValue())
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of datatable
        ucrDaiy2Navigation.MoveFirst()
        'Enable appropriate base buttons
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
            ucrDaiy2Navigation.ResetControls()
            SaveEnable()
        Else
            MessageBox.Show("Record not Saved", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        'Prompts the user if they really want to delete a record
        dlgResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            'Deletes the selected record
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

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        ' temporary until we know how to get all fields from table without specifying names
        dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))

        ucrDaiy2Navigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrMonth}), ucrYear:=ucrYearSelector)

        'May want to change sequencer when year changes but not here

        'If ucrYearSelector.isLeapYear Then
        '    txtSequencer.Text = "seq_month_day_leap_yr"
        'Else
        '    txtSequencer.Text = "seq_month_day"
        'End If
        ucrFormDaily.ucrValueFlagPeriod1.Focus()
    End Sub
    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear and on dialog load
    ''' </summary>
    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        If ucrDaiy2Navigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        Else
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                clsDataConnection.db.Entry(ucrFormDaily.fd2Record).State = Entity.EntityState.Modified
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    'This is as is as Samuels view button
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

    Private Sub chkEnableSequencer_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSequencer.CheckedChanged
        If chkEnableSequencer.Checked Then
            txtSequencer.Text = "seq_daily_element"
        Else
            txtSequencer.Text = ""
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        ucrFormDaily.UploadAllRecords()
    End Sub
End Class