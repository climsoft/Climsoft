Public Class frmNewHourlyWind
    Private bFirstLoad As Boolean = True

    Private Sub frmNewHourlyWind_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If bFirstLoad Then
            btnClear.Enabled = True
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrHourlyWind.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrHourlyWind.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_hourlywind.Add(ucrHourlyWind.fhourlyWindRecord)
        End If
        clsDataConnection.SaveUpdate()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_hourlywind.Attach(ucrHourlyWind.fhourlyWindRecord)
                clsDataConnection.db.form_hourlywind.Remove(ucrHourlyWind.fhourlyWindRecord)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrNavigation.MoveNext(sender, e)
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
    End Sub

End Class