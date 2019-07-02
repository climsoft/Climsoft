Public Class ucrKenyaAgromet
    Private strValueFieldName As String = "val_Elem"
    Private strFlagFieldName As String = "flag"

    Private Sub ucrKenyaAgromet_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)

            'set up the value flag period first
            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_agro1")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonthSelector, ucrMonthSelector.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDaySelector, ucrDaySelector.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)

            ucrNavigation.SetTableEntryAndKeyControls(Me)
            bFirstLoad = False
            ucrNavigation.PopulateControl()

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"mm", "dd"}, {ucrMonthSelector, ucrDaySelector}, ucrYearSelector)
            ' ucrNavigation.NewRecord() 'temporary
            'SaveEnable()
            ucrVFPElem101.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub ucrAgrometYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrYearSelector.evtValueChanged
        If ucrYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrYearSelector.IsLeapYear(), "seq_month_day_element_leap_yr", "seq_month_day_element")
        End If
    End Sub


End Class
