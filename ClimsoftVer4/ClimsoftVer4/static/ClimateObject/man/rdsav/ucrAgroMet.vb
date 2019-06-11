Public Class ucrAgroMet
    Private strValueFieldName As String = "val_Elem"
    Private strFlagFieldName As String = "flag"

    Private Sub ucrAgroMet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.ucrPeriod.Visible = False
                    ucrVFP.setInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_agro1")

            AddLinkedControlFilters(ucrAgrometStationSelector, ucrAgrometStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrAgrometYearSelector, ucrAgrometYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrAgrometMonthSelector, ucrAgrometMonthSelector.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrAgrometDaySelector, ucrAgrometDaySelector.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)

            ucrAgrometNavigation.SetTableEntryAndKeyControls(Me)
            bFirstLoad = False
            ucrAgrometNavigation.PopulateControl()
            SaveEnable()
        End If
    End Sub
End Class
