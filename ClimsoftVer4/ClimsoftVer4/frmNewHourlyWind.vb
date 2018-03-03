Public Class frmNewHourlyWind
    Private bFirstLoad As Boolean = True

    Private Sub frmNewHourlyWind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        ucrHourlyWind.SetSpeedDigits(Val(txtSpeedDigits.Text))
        ucrHourlyWind.SetDirectionDigits(Val(txtDirectionDigits.Text))
        ucrHourlyWind.SetDirectionValidation(112)
        ucrHourlyWind.SetSpeedValidation(111)
        AssignLinkToKeyField(ucrHourlyWind)

        ucrNavigation.SetTableNameAndFields("form_hourlywind", (New List(Of String)({"stationId", "yyyy", "mm", "dd"})))
        ucrNavigation.SetKeyControls("stationId", ucrStationSelector)
        ucrNavigation.SetKeyControls("yyyy", ucrYearSelector)
        ucrNavigation.SetKeyControls("mm", ucrMonth)
        ucrNavigation.SetKeyControls("dd", ucrDay)

        ucrNavigation.PopulateControl()

    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        If btnHourSelection.Text = "Enable all hours" Then
            ucrHourlyWind.SetHourSelection(True)
            btnHourSelection.Text = "Enable synoptic hours only"
        Else
            ucrHourlyWind.SetHourSelection(False)
            btnHourSelection.Text = "Enable all hours"
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        ucrHourlyWind.Clear()
        ucrNavigation.SetControlsForNewRecord()

        'TODO
        'change the sequencer


        ucrHourlyWind.ucrDirectionSpeedFlag0.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                ucrHourlyWind.SaveRecord()
                MessageBox.Show("New record added to database table!", "Update Record")
                'ucrNavigation.MoveNext(sender, e)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                ucrHourlyWind.SaveRecord()
                MessageBox.Show("Record updated successfully!", "Update Record")
                'ucrNavigation.MoveNext(sender, e)
            Catch
                MessageBox.Show("Record has not been updated", "Update Record")
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                ucrHourlyWind.DeleteRecord()
                MessageBox.Show("Record has been deleted", "Delete Record")
                'ucrNavigation.MoveNext(sender, e)
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'SAMUEL IS DOING THIS AND I'M NOT SURE WHY BUT I DID IT TO HAVE
        'A SIMILAR IMPLEMENTATION, THE CHECKING OF HEADER INFORMATION
        'COULD BE REMOVED IF ITS NOT NECESSARY
        'Check if header information is complete. If the header information is complete and there is at least on obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        If (Not ucrHourlyWind.IsDirectionValuesEmpty) And Strings.Len(ucrStationSelector.GetValue) > 0 And Strings.Len(ucrYearSelector.GetValue) > 0 And Strings.Len(ucrMonth.GetValue) And Strings.Len(ucrDay.GetValue) > 0 Then
            btnAddNew.Enabled = True
            btnSave.Enabled = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            ucrHourlyWind.Clear()
            ucrNavigation.ResetControls()
        Else
            MessageBox.Show("Incomplete header information and insufficient observation data!", "Clear Record")
        End If

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        'TODO
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
