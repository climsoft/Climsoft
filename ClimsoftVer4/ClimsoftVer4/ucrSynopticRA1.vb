Public Class ucrSynopticRA1
    Private Sub ucrSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            SetUpTableEntry("form_synoptic_2_ra1")

            'validations
            ucrYearSelector.SetValidationTypeAsNumeric()
            ucrMonth.SetValidationTypeAsNumeric()
            ucrDay.SetValidationTypeAsNumeric()
            ucrHour.SetValidationTypeAsNumeric()
            'TODO complete validations for the remaining fields

            'Set up the navigation control
            ucrNavigation.SetTableEntry(Me)
            ucrNavigation.AddKeyControls(ucrStationSelector)
            ucrNavigation.AddKeyControls(ucrYearSelector)
            ucrNavigation.AddKeyControls(ucrMonth)
            ucrNavigation.AddKeyControls(ucrDay)
            ucrNavigation.AddKeyControls(ucrHour)

            bFirstLoad = False

            'populate the values
            ucrNavigation.PopulateControl()
            SaveEnable()
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ucrNavigation.NewRecord()
        SaveEnable()
        ucrStationSelector.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If
            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrStationSelector.PopulateControl()
                    'ucrStationSelector.GoToNewRecord()
                    SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to update this record?", "update record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If UpdateRecord() Then
                    MessageBox.Show("Record updated successfully!", "Update record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeleteRecord() Then
                    ucrNavigation.RemoveRecord()
                    SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of the datatable
        ucrNavigation.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigation.iCurrRow = -1 Then
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub
    Private Sub ucrNavigation_evtValueChanged(sender As Object, e As EventArgs) Handles ucrNavigation.evtValueChanged
    End Sub

    Private Sub btnTDCF_Click(sender As Object, e As EventArgs) Handles btnTDCF.Click
        'TODO
        frmSynopTDCF.Show()
        frmSynopTDCF.cboTemplate.Text = "TM_307081"
        'Subset Observations
        SubsetObservations()
    End Sub
End Class
