Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Dim selectAllHours As Boolean
    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
        selectAllHours = False
    End Sub
    Private Sub InitaliseDialog()
        Dim dctNavigationFields As New Dictionary(Of String, List(Of String))
        Dim dctNavigationKeyControls As New Dictionary(Of String, ucrBaseDataLink)

        ucrHourly.SetYearMonthAndDayLink(ucrYearSelector, ucrMonth, ucrDay)
        AssignLinkToKeyField(ucrHourly)
        ucrHourly.PopulateControl()

        dctNavigationFields.Add("stationId", New List(Of String)({"stationId"}))
        dctNavigationFields.Add("elementId", New List(Of String)({"elementId"}))
        dctNavigationFields.Add("yyyy", New List(Of String)({"yyyy"}))
        dctNavigationFields.Add("mm", New List(Of String)({"mm"}))
        dctNavigationFields.Add("dd", New List(Of String)({"dd"}))
        ucrNavigation.SetFields(dctNavigationFields)
        ucrNavigation.SetTableName("form_hourly")

        dctNavigationKeyControls.Add("stationId", ucrStationSelector)
        dctNavigationKeyControls.Add("elementId", ucrElementSelector)
        dctNavigationKeyControls.Add("yyyy", ucrYearSelector)
        dctNavigationKeyControls.Add("mm", ucrMonth)
        dctNavigationKeyControls.Add("dd", ucrDay)
        ucrNavigation.SetKeyControls(dctNavigationKeyControls)
        ucrNavigation.PopulateControl()
        SaveEnable()
    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)

    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        For Each ctl In ucrHourly.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                ctrltemp.ucrValue.SetValue(ucrInputValue.GetValue())
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrHourly.Clear()
        ucrNavigation.ResetControls()
        SaveEnable()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrHourly.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_hourly.Add(ucrHourly.fhRecord)
        End If
        clsDataConnection.SaveUpdate()
        SaveEnable()
        ucrNavigation.ResetControls()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_hourly.Attach(ucrHourly.fhRecord)
                clsDataConnection.db.form_hourly.Remove(ucrHourly.fhRecord)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrNavigation.RemoveRecord()
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
        SaveEnable()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        dsSourceTableName = "form_hourly"
        userName = frmLogin.txtUsername.Text
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_hourly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_hourly ORDER by stationId,elementId,yyyy,mm,dd;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Modified
                clsDataConnection.db.SaveChanges()

                MessageBox.Show(Me, "Record updated successfully!", "Update Record", MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        ucrNavigation.MoveLast()
        ucrNavigation.SetControlsForNewRecord()
        ucrHourly.Clear()
        ucrHourly.bUpdating = False
        ucrHourly.fhRecord = New form_hourly

        If ucrYearSelector.isLeapYear Then
            txtSequencer.Text = "seq_month_day_leap_yr"
        Else
            txtSequencer.Text = "seq_month_day"
        End If

        'change the year based on the month and the day
        If ucrMonth.GetValue = 12 AndAlso ucrDay.GetValue = 31 Then
            ucrYearSelector.SetValue(Val(ucrYearSelector.GetValue) + 1)
        End If
        ucrHourly.UcrValueFlagPeriod0.Focus()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        If ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click

        If selectAllHours Then
            selectAllHours = False
            btnHourSelection.Text = "Enable synoptic hours only"
            For Each ctrVFP As ucrValueFlagPeriod In {ucrHourly.ucrValueFlagPeriod3, ucrHourly.ucrValueFlagPeriod6, ucrHourly.ucrValueFlagPeriod9, ucrHourly.UcrValueFlagPeriod12, ucrHourly.UcrValueFlagPeriod15, ucrHourly.UcrValueFlagPeriod18, ucrHourly.UcrValueFlagPeriod21}
                ctrVFP.ucrFlag.Enabled = True
                ctrVFP.ucrValue.Enabled = True
                ctrVFP.ucrFlag.SetBackColor(Color.White)
                ctrVFP.ucrValue.SetBackColor(Color.White)
            Next
        Else
            selectAllHours = True
            btnHourSelection.Text = "Enable all hours"
            For Each ctrVFP As ucrValueFlagPeriod In {ucrHourly.ucrValueFlagPeriod3, ucrHourly.ucrValueFlagPeriod6, ucrHourly.ucrValueFlagPeriod9, ucrHourly.UcrValueFlagPeriod12, ucrHourly.UcrValueFlagPeriod15, ucrHourly.UcrValueFlagPeriod18, ucrHourly.UcrValueFlagPeriod21}
                ctrVFP.ucrFlag.Enabled = False
                ctrVFP.ucrValue.Enabled = False
                ctrVFP.ucrFlag.SetBackColor(Color.LightYellow)
                ctrVFP.ucrValue.SetBackColor(Color.LightYellow)
            Next
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub
End Class