Public Class frmNewMonthly
    Private bFirstLoad As Boolean = True
    Private Sub frmNewMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrMonthlydata.setYearLink(ucrYearControl:=ucrYearSelector)
        AssignLinkToKeyField(ucrMonthlydata)
        ucrMonthlydata.PopulateControl()
    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
    End Sub
End Class