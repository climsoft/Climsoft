
Public Class frmNewFormDaily2
    Private bFirstLoad As Boolean = True

    Private Sub frmNewFormDaily2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

        Else

        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrStationSelector.SetViewTypeAsStations()
        ucrElementSelector.SetViewTypeAsElements()
        ucrYearSelector.SetViewTypeAsYear()
        ucrHour.SetViewTypeAs24Hrs()

        ucrVisibilityUnits.SetField("visUnits")
        ucrVisibilityUnits.SetTableName("form_daily2")

        ucrCloudheightUnits.SetField("cloudHeightUnits")
        ucrCloudheightUnits.SetTableName("form_daily2")

        ucrPrecipUnits.SetField("precipUnits")
        ucrPrecipUnits.SetTableName("form_daily2")

        ucrTempUnits.SetField("temperatureUnits")
        ucrTempUnits.SetTableName("form_daily2")

    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        For Each ctl In Me.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctl = ctrltemp
                ctrltemp.ucrValue.txtBox.Text = ucrInputValue.txtBox.Text
            End If
        Next
    End Sub

    Private Sub ucrVisibilityUnits_Load(sender As Object, e As EventArgs) Handles ucrVisibilityUnits.Load

    End Sub
End Class