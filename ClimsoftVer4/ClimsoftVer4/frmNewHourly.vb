Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub
    Private Sub InitaliseDialog()

        Dim d As New Dictionary(Of String, List(Of String))

        d.Add("stationId", New List(Of String)({"stationId"}))
        d.Add("elementId", New List(Of String)({"elementId"}))
        d.Add("yyyy", New List(Of String)({"yyyy"}))
        d.Add("mm", New List(Of String)({"mm"}))
        d.Add("dd", New List(Of String)({"dd"}))
        ucrNavigation.SetFields(d)
        ucrNavigation.SetTableName("form_hourly")


        ucrStationSelector.AddLinkedControlFilters(ucrNavigation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrElementSelector.AddLinkedControlFilters(ucrNavigation, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrYearSelector.AddLinkedControlFilters(ucrNavigation, "Year", "==", strLinkedFieldName:="yyyy", bForceValuesAsString:=False)
        ucrMonth.AddLinkedControlFilters(ucrNavigation, "MonthId", "==", strLinkedFieldName:="mm", bForceValuesAsString:=False)
        ucrDay.AddLinkedControlFilters(ucrNavigation, "day", "==", strLinkedFieldName:="dd", bForceValuesAsString:=False)

        ucrNavigation.PopulateControl()
        ucrHourly.SetYearMonthAndDayLink(ucrYearSelector, ucrMonth, ucrDay)
        AssignLinkToKeyField(ucrHourly)
        ucrHourly.PopulateControl()

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
                ctrltemp.ucrValue.TextboxValue = ucrInputValue.TextboxValue
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrHourly.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrHourly.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_hourly.Add(ucrHourly.fhRecord)
        End If
        clsDataConnection.SaveUpdate()
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
                ucrNavigation.MoveNext(sender, e)
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        formDataView.DataGridView.DataSource = ucrHourly.fhRecord
        formDataView.DataGridView.Refresh()
        formDataView.DataGridView.Dock = DockStyle.Top
    End Sub
End Class