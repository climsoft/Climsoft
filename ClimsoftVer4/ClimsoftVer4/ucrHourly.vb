Public Class ucrHourly
    Private strValueFieldName As String = "hh_"
    Private strFlagFieldName As String = "flag"
    Private bTotalRequired As Boolean

    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                    ucrVFP.setInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_hourly")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrElementSelector, ucrElementSelector.FieldName, "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonthSelector, ucrMonthSelector.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDaySelector, ucrDaySelector.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)

            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)
            ucrDaySelector.setYearAndMonthLink(ucrYearSelector, ucrMonthSelector)


            bFirstLoad = False

            'ucrNavigation.SetSortBy("entryDatetime")
            ucrNavigation.PopulateControl() 'populate the values

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"elementId", "mm", "dd"}, {ucrDaySelector, ucrMonthSelector}, ucrYearSelector)
            ' ucrNavigation.NewRecord() 'temporary
            SaveEnable()
            UcrValueFlagPeriod0.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        dsSourceTableName = "form_hourly"
        userName = frmLogin.txtUsername.Text
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_hourly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_hourly ORDER by stationId,elementId,yyyy,mm,dd;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnAssignSameValue_Click(sender As Object, e As EventArgs) Handles btnAssignSameValue.Click
        Dim strNewValue As String = ucrInputSameValue.GetValue
        Dim ucrVFP As ucrValueFlagPeriod
        'Adds values to only enabled controls of the ucrHourly
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If ctr.Enabled Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetElementValue(strNewValue)
                    If Not ucrVFP.ValidateValue() Then
                        Exit Sub
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        Dim ctrVFP As ucrValueFlagPeriod

        If btnHourSelection.Text = "Enable all hours" Then
            btnHourSelection.Text = "Enable synoptic hours only"
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.Enabled = True
                    ctrVFP.SetBackColor(Color.White)
                End If
            Next
        Else
            btnHourSelection.Text = "Enable all hours"
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableNameAndFields("form_hourly_time_selection", {"hh", "hh_selection"})
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                        iTagVal = Val(Strings.Right(ctrVFP.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ctrVFP.Enabled = False
                            ctrVFP.SetBackColor(Color.LightYellow)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ucrYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrYearSelector.evtValueChanged
        If ucrYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrYearSelector.IsLeapYear(), "seq_month_day_element_leap_yr", "seq_month_day_element")
        End If
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If Not CheckTotal() Then
                ucrInputTotal.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean

        bValid = MyBase.ValidateValue()

        If bValid Then
            Dim bValueExists As Boolean = False
            'Check if all values are empty. There should be atleast one observation value
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod AndAlso Not DirectCast(ctr, ucrValueFlagPeriod).IsElementValueEmpty() Then
                    bValueExists = True
                    Exit For
                End If
            Next

            If Not bValueExists Then
                MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            'check computed total vs input total
            If Not CheckTotal() Then
                ucrInputTotal.Focus()
                Return False
            End If

        End If

        Return bValid
    End Function

    Private Function CheckTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Decimal = 0
        Dim expectedTotal As Decimal

        If bTotalRequired Then
            If ucrInputTotal.IsEmpty Then
                MessageBox.Show("Please enter the Total Value in the [Total] textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Red)
                bValueCorrect = False
            Else
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrValueFlagPeriod).GetElementValue)
                    End If
                Next

                bValueCorrect = (elemTotal = expectedTotal)
                If Not bValueCorrect Then
                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                End If

            End If
        Else
            bValueCorrect = True
        End If

        Return bValueCorrect
    End Function


    ''' <summary>
    ''' Sets upper and lower limits validation curent selected element and sets if the checking total is requred
    ''' </summary>
    Protected Overrides Sub SetValuesValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""
        bTotalRequired = False

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", {"lowerLimit", "upperLimit", "qcTotalRequired"})
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrElementSelector.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        'get upper and lower limits
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
            'qcTotalRequired is a nullable integer in the EF model
            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
                bTotalRequired = If(Val(dtbl.Rows(0).Item("qcTotalRequired")) <> 0, True, False)
            End If
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)

                If String.IsNullOrEmpty(strLowerLimit) Then
                    ucrVFP.SetElementValueLowerLimit(Decimal.MinValue)
                Else
                    ucrVFP.SetElementValueLowerLimit(Val(strLowerLimit))
                End If

                If String.IsNullOrEmpty(strUpperLimit) Then
                    ucrVFP.SetElementValueHigherLimit(Decimal.MaxValue)
                Else
                    ucrVFP.SetElementValueHigherLimit(Val(strUpperLimit))
                End If

            End If
        Next
    End Sub

    Protected Overrides Sub ValidateDataEntryPermission()
        Dim bEnabled As Boolean = False
        'if its an update or any of the linked year,month and day selector is nothing then just enable the control
        If ucrYearSelector.ValidateValue AndAlso ucrMonthSelector.ValidateValue AndAlso ucrDaySelector.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values. Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrYearSelector.GetValue, ucrMonthSelector.GetValue, ucrDaySelector.GetValue)

            'if selectedDate is earlier than todayDate (<0) enable control
            'if it is same time (0) or later than (>0) disable control
            bEnabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
        Else
            bEnabled = False
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                ctr.Enabled = bEnabled
            End If
        Next

    End Sub

End Class
