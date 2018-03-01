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
        ucrHourlyWind.HourSelection(True)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrHourlyWind.Clear()
    End Sub
End Class