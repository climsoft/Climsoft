Public Class frmNewHourlyWind
    Private bFirstLoad As Boolean = True

    Private Sub frmNewHourlyWind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        ucrHourlyWind.SetSpeedDigits(Val(txtSpeedDigits.Text))
        ucrHourlyWind.SetDirectionDigits(Val(txtDirectionDigits.Text))
        ucrHourlyWind.SetDirectionValidation(112)
        ucrHourlyWind.SetSpeedValidation(111)

        ucrHourlyWind.SetKeyControls(ucrStationSelector, ucrYearSelector, ucrMonth, ucrDay, ucrNavigation)

        ucrNavigation.PopulateControl()

        SaveEnable()
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        If btnHourSelection.Text = "Enable all hours" Then
            ucrHourlyWind.SetHourSelection(True)
            btnHourSelection.Text = "Enable synoptic hours only"
        Else
            ucrHourlyWind.SetHourSelection(False)
            btnHourSelection.Text = "Enable all hours"
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True
        'ucrNavigation.SetControlsForNewRecord()

        'change the sequencer
        If ucrYearSelector.isLeapYear Then
            txtSequencer.Text = "seq_month_day_leap_yr"
        Else
            txtSequencer.Text = "seq_month_day"
        End If

        ' temporary until we know how to get all fields from table without specifying names
        dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
        dctSequencerFields.Add("dd", New List(Of String)({"dd"}))

        ucrNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrMonth, ucrDay}), ucrYear:=ucrYearSelector)

        ucrHourlyWind.ucrDirectionSpeedFlag0.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If Not ValidateValues() Then
                Exit Sub
            End If

            'then go ahead and save to database
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrHourlyWind.SaveRecord()
                ucrNavigation.ResetControls()
                ucrNavigation.GoToNewRecord()
                SaveEnable()
                MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrHourlyWind.SaveRecord()
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrHourlyWind.DeleteRecord()
                ucrNavigation.RemoveRecord()
                SaveEnable()
                MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'SAMUEL IS DOING THIS AND I'M NOT SURE WHY BUT I DID IT TO HAVE
        'A SIMILAR IMPLEMENTATION, THE CHECKING OF HEADER INFORMATION
        'COULD BE REMOVED IF ITS NOT NECESSARY
        'Check if header information is complete. If the header information is complete and there is at least on obs value then,
        'carry out the next actions, otherwise bring up message showing that there is insufficient data
        'If (Not ucrHourlyWind.IsDirectionValuesEmpty) AndAlso Strings.Len(ucrStationSelector.GetValue) > 0 AndAlso Strings.Len(ucrYearSelector.GetValue) > 0 AndAlso Strings.Len(ucrMonth.GetValue) AndAlso Strings.Len(ucrDay.GetValue) > 0 Then
        ucrNavigation.ResetControls()
        ucrNavigation.MoveFirst()
        SaveEnable()
        'Else
        'MessageBox.Show("Incomplete header information and insufficient observation data!", "Clear Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    'This is from Samuel's code
    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_synopticRA1")
    End Sub

    'This is from Samuel's code
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_hourlywind"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_hourlywind where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_hourlywind ORDER by stationId,yyyy,mm,dd;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'TODO
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        If ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        Else
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        End If
    End Sub

    Private Function ValidateValues() As Boolean
        'Check valid station
        If Not ucrStationSelector.ValidateValue() Then
            MessageBox.Show("Invalid station", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Check valid year
        If Not ucrYearSelector.ValidateValue() Then
            MessageBox.Show("Invalid year", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Check valid month
        If Not ucrMonth.ValidateValue() Then
            MessageBox.Show("Invalid Month", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Check valid Day
        If Not ucrDay.ValidateValue() Then
            MessageBox.Show("Invalid day", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Check if all values are empty. There should be atleast one observation value
        If ucrHourlyWind.IsDirectionValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Then Do QC Checks. 
        'based on upper & lower limit for wind direction 
        If Not ucrHourlyWind.CheckQcForDirection() Then
            Return False
        End If
        'based on upper & lower limit for wind speed 
        If Not ucrHourlyWind.CheckQcForSpeed() Then
            Return False
        End If

        'check speed total required
        If Not ucrHourlyWind.checkSpeedTotal() Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' This sets the direction and speed digits from the database 
    ''' by getting the values from the regkeys database table
    ''' </summary>
    Private Sub SetDirectionAndSpeedDigits()
        Try
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim row As DataRow

            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableName("regkeys")
            clsDataDefinition.SetFields(New List(Of String)({"keyName", "keyValue"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                'get direction digits
                row = dtbl.Select("keyName = 'key05'").FirstOrDefault()
                iDirectionDigits = If(row IsNot Nothing, Integer.Parse(row.Item("keyValue")), 0)

                'get speed digits
                row = dtbl.Select("keyName = 'key06'").FirstOrDefault()
                iSpeedDigits = If(row IsNot Nothing, Integer.Parse(row.Item("keyValue")), 0)
            End If

        Catch ex As Exception
            MessageBox.Show("Error in getting direction and speed digits in the database . Error: " & ex.Message, "Digits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
