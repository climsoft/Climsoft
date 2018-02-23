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
        Dim cust As New form_daily2
        cust.yyyy = "2018"
        cust.stationId = "67755030"
        cust.elementId = "2"
        cust.mm = "2"
        cust.hh = "1"
        clsDataConnection.db.form_daily2.Attach(cust)
        clsDataConnection.db.form_daily2.Remove(cust)
        clsDataConnection.db.SaveChanges()
        MsgBox("deleted")
    End Sub

    Private Sub UcrHourly1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        formDataView.DataGridView.DataSource = ucrHourly.fhRecord
        formDataView.DataGridView.Refresh()
        formDataView.DataGridView.Dock = DockStyle.Top
    End Sub
End Class