Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Dim selectAllHours As Boolean = True
    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If

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
        formDataView.DataGridView.DataSource = ucrHourly.fhRecord
        formDataView.DataGridView.Refresh()
        formDataView.DataGridView.Dock = DockStyle.Top
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try

                If ucrHourly.bUpdating Then
                    clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Modified
                    clsDataConnection.db.SaveChanges()
                Else
                    clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Added
                    clsDataConnection.db.SaveChanges()
                End If

                MessageBox.Show(Me, "Record updated successfully!", "Update Record", MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxIcon.Error)
            End Try
        End If

        'If clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Modified Then
        '    Try
        '        clsDataConnection.db.form_hourly.Add(ucrHourly.fhRecord)
        '        clsDataConnection.db.SaveChanges()
        '        MessageBox.Show("Record has been updated", "Updating Record")
        '    Catch
        '        MessageBox.Show("Record has not been updated", "Updating Record")
        '    End Try
        'Else
        '    MessageBox.Show("No values have been update, can not update this record", "Updating Record")
        'End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        ucrNavigation.MoveLast()
        ucrHourly.Clear()
        ucrNavigation.SetControlsForNewRecord()

        If ucrYearSelector.isLeapYear Then
            txtSequencer.Text = "seq_month_day_leap_yr"
        Else
            txtSequencer.Text = "seq_month_day"
        End If

        'change the year based on the month and the day
        If ucrMonth.GetValue = 12 AndAlso ucrDay.GetValue = 31 Then
            ucrYearSelector.SetValue(Val(ucrYearSelector.GetValue) + 1)
        End If

        'TODO
        'CHANGE THE MONTH AND DAY VALUES BASED ON THE SEQUENCER AND LAST RECORD VALUES

        ucrHourly.UcrValueFlagPeriod0.Focus()


    End Sub

    Private Sub SaveEnable()
        'btnAddNew.Enabled = True
        'btnCommit.Enabled = False
        'btnClear.Enabled = False
        'If ucrNavigation.iMaxRows > 0 Then
        '    btnDelete.Enabled = True
        '    btnUpdate.Enabled = True
        'End If
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
                'ctrVFP.BackColor = Color.White
            Next
        Else
            selectAllHours = True
            btnHourSelection.Text = "Enable all hours"
            For Each ctrVFP As ucrValueFlagPeriod In {ucrHourly.ucrValueFlagPeriod3, ucrHourly.ucrValueFlagPeriod6, ucrHourly.ucrValueFlagPeriod9, ucrHourly.UcrValueFlagPeriod12, ucrHourly.UcrValueFlagPeriod15, ucrHourly.UcrValueFlagPeriod18, ucrHourly.UcrValueFlagPeriod21}
                ctrVFP.ucrFlag.Enabled = False
                ctrVFP.ucrValue.Enabled = False
                ctrVFP.ucrFlag.SetBackColor(Color.LightYellow)
                ctrVFP.ucrValue.SetBackColor(Color.LightYellow)
                ctrVFP.BackColor = Color.LightYellow
            Next
        End If
    End Sub
End Class