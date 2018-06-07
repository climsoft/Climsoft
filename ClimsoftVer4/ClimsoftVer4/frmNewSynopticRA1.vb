Public Class frmNewSynopticRA1
    Private bFirstLoad As Boolean = True

    Private Sub frmNewSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        ucrSynopticRA1.SetKeyControls(ucrStationSelector, ucrYearSelector, ucrMonth, ucrDay, ucrHour, ucrNavigation)

        ucrNavigation.PopulateControl()

        SaveEnable()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True

        'change the sequencer
        If ucrYearSelector.isLeapYear Then
            txtSequencer.Text = "seq_month_day_synoptime_leap_yr"
        Else
            txtSequencer.Text = "seq_month_day_synoptime"
        End If

        'temporary until we know how to get all fields from table without specifying names
        dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
        dctSequencerFields.Add("dd", New List(Of String)({"dd"}))
        dctSequencerFields.Add("hh", New List(Of String)({"hh"}))

        ucrNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrMonth, ucrDay, ucrHour}), ucrYear:=ucrYearSelector)

        'Set focus of ucrSynopticRA1 first control 
        ucrSynopticRA1.ucrVFPStationLevelPressure.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'then go ahead and save to database
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrSynopticRA1.SaveRecord()
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
                ucrSynopticRA1.SaveRecord()
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrSynopticRA1.DeleteRecord()
                ucrNavigation.RemoveRecord()
                SaveEnable()
                MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrNavigation.ResetControls()
        ucrNavigation.MoveFirst()
        SaveEnable()
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
        dsSourceTableName = "form_synoptic_2_RA1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_synoptic_2_RA1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd,hh;"
        Else
            sql = "SELECT * FROM form_synoptic_2_RA1 ORDER by stationId,yyyy,mm,dd,hh;"
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
        If ucrSynopticRA1.IsValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'TODO. Validate the values entered

        'Then Do QC Checks. 
        'based on upper & lower limit for wind direction 
        'If Not ucrHourlyWind.CheckQcForDirection() Then
        '    Return False
        'End If




        Return True
    End Function

End Class