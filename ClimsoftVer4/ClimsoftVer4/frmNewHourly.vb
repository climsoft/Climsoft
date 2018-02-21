Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
        End If
    End Sub
    Private Sub InitaliseDialog()
        Dim dtbVis, dtbCld, dtbPrec, dtbTemp As New DataTable
        Dim d As New Dictionary(Of String, List(Of String))

        UcrHourly1.SetYearAndMonthLink(ucrYearSelector, ucrMonth)
        AssignLinkToKeyField(UcrHourly1)


        d.Add("stationId", New List(Of String)({"stationId"}))
        d.Add("elementId", New List(Of String)({"elementId"}))
        d.Add("yyyy", New List(Of String)({"yyyy"}))
        d.Add("mm", New List(Of String)({"mm"}))
        d.Add("hh", New List(Of String)({"hh"}))

        UcrNavigation1.SetFields(d)
        UcrNavigation1.SetTableName("form_daily2")

        ucrStationSelector.AddLinkedControlFilters(UcrNavigation1, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrElementSelector.AddLinkedControlFilters(UcrNavigation1, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrYearSelector.AddLinkedControlFilters(UcrNavigation1, "Year", "==", strLinkedFieldName:="yyyy", bForceValuesAsString:=False)
        ucrMonth.AddLinkedControlFilters(UcrNavigation1, "MonthId", "==", strLinkedFieldName:="mm", bForceValuesAsString:=False)


        UcrNavigation1.PopulateControl()
        UcrHourly1.PopulateControl()

    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)

    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        For Each ctl In UcrHourly1.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                ctrltemp.ucrValue.TextboxValue = ucrInputValue.TextboxValue
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        UcrHourly1.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If UcrHourly1.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_hourly.Add(UcrHourly1.fhRecord)
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
End Class