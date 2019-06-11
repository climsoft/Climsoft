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

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_agro1")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_agro1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_agro1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_agro1 ORDER by stationId,yyyy,mm,dd"
        End If
        viewRecords.viewTableRecords(sql)

    End Sub

    Private Sub ucrAgrometYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrAgrometYearSelector.evtValueChanged
        If ucrAgrometYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrAgrometYearSelector.IsLeapYear(), "seq_month_day_element_leap_yr", "seq_month_day_element")
        End If
    End Sub
End Class
