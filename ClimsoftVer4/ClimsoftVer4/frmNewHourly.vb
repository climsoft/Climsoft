﻿Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Dim FldName As New dataEntryGlobalRoutines

    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If

        ' Retrieve Keyentry mode information and mark on the checkbox
        If FldName.Key_Entry_Mode(Me.Text) = "Double" Then
            chkRepeatEntry.Checked = True
        End If
    End Sub

    Private Sub InitaliseDialog()
        txtSequencer.ReadOnly = True
        txtSequencer.Text = "seq_month_day_element"
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)
        ucrHourly.SetKeyControls(ucrStationSelector, ucrElementSelector, ucrYearSelector, ucrMonth, ucrDay, ucrHourlyNavigation)
        ucrHourlyNavigation.PopulateControl()
        SaveEnable()
    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        ucrHourly.SetSameValueToAllObsElements(ucrInputValue.GetValue())
    End Sub

    'Changes the date entry fields betwen synoptc hours and all hours
    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        If btnHourSelection.Text = "Enable all hours" Then
            ucrHourly.SetSynopticHourSelectionOnly(True)
            btnHourSelection.Text = "Enable synoptic hours only"
        Else
            ucrHourly.SetSynopticHourSelectionOnly(False)
            btnHourSelection.Text = "Enable all hours"
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))
        dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
        dctSequencerFields.Add("dd", New List(Of String)({"dd"}))
        ucrHourlyNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrDay, ucrMonth}), ucrYear:=ucrYearSelector)

        ucrHourly.Focus()

    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrHourly.SaveRecord()
                ucrHourlyNavigation.GoToNewRecord()
                SaveEnable()
                MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Record not Saved", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If Not chkRepeatEntry.Checked Then
                If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ucrHourly.SaveRecord()
                    MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            ' When in double entry mode just skip update action. Values have been updated on entry
            If chkRepeatEntry.Checked Then
                Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

                dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))
                dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
                dctSequencerFields.Add("dd", New List(Of String)({"dd"}))
                ucrHourlyNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrDay, ucrMonth}), ucrYear:=ucrYearSelector)
            End If

        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            If Not ValidateValues(False) Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrHourly.DeleteRecord()
                ucrHourlyNavigation.RemoveRecord()
                SaveEnable()
                MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrHourlyNavigation.MoveFirst()
        SaveEnable()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If MessageBox.Show("Are you sure you want to upload these records?", "Upload Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ucrHourly.UploadAllRecords()
            'MessageBox.Show("Records have been uploaded sucessfully", "Upload Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

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

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrHourlyNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnCommit.Enabled = True
        ElseIf ucrHourlyNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Function ValidateValues(Optional bCheckTotal As Boolean = True) As Boolean
        If Not ucrStationSelector.ValidateValue Then
            MessageBox.Show("Invalid Station", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrStationSelector.Focus()
            Return False
        End If

        If Not ucrElementSelector.ValidateValue Then
            MessageBox.Show("Invalid Element", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrElementSelector.Focus()
            Return False
        End If

        If Not ucrMonth.ValidateValue Then
            MessageBox.Show("Invalid Month", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrMonth.Focus()
            Return False
        End If

        If Not ucrYearSelector.ValidateValue Then
            MessageBox.Show("Invalid Day", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrYearSelector.Focus()
            Return False
        End If

        If Not ucrDay.ValidateValue Then
            MessageBox.Show("Invalid Day", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrDay.Focus()
            Return False
        End If

        'Check if all values are empty. There should be atleast one observation value
        If ucrHourly.IsValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrHourly.Focus()
            Return False
        End If

        'check if all values are valid
        If Not ucrHourly.ValidateValue() Then
            Return False
        End If

        If bCheckTotal Then
            'check computed total vs input total
            If Not ucrHourly.checkTotal() Then
                ucrHourly.ucrInputTotal.Focus()
                Return False
            End If
        End If


        Return True
    End Function

    Private Sub AllControls_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrYearSelector.evtKeyDown, ucrStationSelector.evtKeyDown, ucrMonth.evtKeyDown, ucrHourly.evtKeyDown, ucrElementSelector.evtKeyDown, ucrDay.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrBaseDataLink Then
                If DirectCast(sender, ucrBaseDataLink).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the "noise" on enter  
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrYearSelector.evtValueChanged
        If ucrYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrYearSelector.IsLeapYear(), "seq_month_day_element_leap_yr", "seq_month_day_element")
        End If
    End Sub

    Private Sub ucrHourly_evtValueChanged(sender As Object, e As EventArgs) Handles ucrHourly.evtValueChanged
        If ucrHourly.bUpdating Then
            SaveEnable()
        Else
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnCommit.Enabled = True
        End If
    End Sub

End Class