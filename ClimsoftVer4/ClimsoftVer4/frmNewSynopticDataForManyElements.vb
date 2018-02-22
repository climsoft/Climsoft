Public Class frmNewSynopticDataForManyElements
    Private bFirstLoad As Boolean = True

    Private Sub frmNewSynopticDataForManyElements_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrSynopticDataForManyElements.setYearMonthDayHourLink(ucrYearControl:=ucrYearSelector, ucrMonthControl:=ucrMonth, ucrDayControl:=ucrDay, ucrHourControl:=ucrHour)
        AssignLinkToKeyField(ucrSynopticDataForManyElements)
        ucrSynopticDataForManyElements.PopulateControl()

    End Sub


    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrSynopticDataForManyElements.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrSynopticDataForManyElements.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_synoptic_2_ra1.Add(ucrSynopticDataForManyElements.fs2Record)
        End If
        clsDataConnection.SaveUpdate()
    End Sub
End Class