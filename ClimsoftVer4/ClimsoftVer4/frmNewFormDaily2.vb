
Public Class frmNewFormDaily2
    Private bFirstLoad As Boolean = True

    Private Sub frmNewFormDaily2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If bFirstLoad Then
            InitaliseDialog()
        End If
    End Sub

    Private Sub InitaliseDialog()
        Dim dtbVis, dtbCld, dtbPrec, dtbTemp As New DataTable

        ucrFormDaily.setYearAndMonthLink(ucrYearSelector, ucrMonth)
        AssignLinkToKeyField(ucrFormDaily)

        ucrFormDaily.PopulateControl()

        ucrVisibilityUnits.SetField("visUnits")
        ucrVisibilityUnits.SetTableName("form_daily2")
        ucrVisibilityUnits.bFillFromDataBase = False
        dtbVis.Columns.Add("visUnits", GetType(String))
        dtbVis.Rows.Add("metres")
        dtbVis.Rows.Add("yards")
        ucrVisibilityUnits.SetPossibleValues(dtbVis)
        AssignLinkToKeyField(ucrVisibilityUnits)
        ucrVisibilityUnits.PopulateControl()
        ucrVisibilityUnits.SetViewType("visUnits")

        ucrCloudheightUnits.SetField("cloudHeightUnits")
        ucrCloudheightUnits.SetTableName("form_daily2")
        ucrCloudheightUnits.bFillFromDataBase = False
        dtbCld.Columns.Add("cloudHeightUnits", GetType(String))
        dtbCld.Rows.Add("metres")
        dtbCld.Rows.Add("feet")
        ucrCloudheightUnits.SetPossibleValues(dtbCld)
        AssignLinkToKeyField(ucrCloudheightUnits)
        ucrCloudheightUnits.PopulateControl()
        ucrCloudheightUnits.SetViewType("cloudHeightUnits")


        ucrPrecipUnits.SetField("precipUnits")
        ucrPrecipUnits.SetTableName("form_daily2")
        ucrPrecipUnits.bFillFromDataBase = False
        dtbPrec.Columns.Add("precipUnits", GetType(String))
        dtbPrec.Rows.Add("mm")
        dtbPrec.Rows.Add("inches")
        ucrPrecipUnits.SetPossibleValues(dtbPrec)
        AssignLinkToKeyField(ucrPrecipUnits)
        ucrPrecipUnits.PopulateControl()
        ucrPrecipUnits.SetViewType("precipUnits")

        ucrTempUnits.SetField("temperatureUnits")
        ucrTempUnits.SetTableName("form_daily2")
        ucrTempUnits.bFillFromDataBase = False
        dtbTemp.Columns.Add("temperatureUnits", GetType(String))
        dtbTemp.Rows.Add("Deg C")
        dtbTemp.Rows.Add("Deg F")
        ucrTempUnits.SetPossibleValues(dtbTemp)
        AssignLinkToKeyField(ucrTempUnits)
        ucrTempUnits.PopulateControl()
        ucrTempUnits.SetViewType("temperatureUnits")


        ucrInputSequncer.SetTableName("seq_daily_element")
        ucrInputSequncer.SetField("seq")
        ucrInputSequncer.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)

    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)
    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        For Each ctl In Me.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                ctrltemp.ucrValue.txtBox.Text = ucrInputValue.txtBox.Text
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrFormDaily.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        clsDataConnection.db.form_daily2.Add(ucrFormDaily.fd2Record)
        clsDataConnection.db.SaveChanges()
    End Sub
End Class