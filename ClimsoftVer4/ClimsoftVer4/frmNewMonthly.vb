Public Class frmNewMonthly
    Private bFirstLoad As Boolean = True

    Private Sub frmNewMonthly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Disable Delete & upload button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" OrElse userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If

        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If

    End Sub

    Private Sub InitaliseDialog()
        txtSequencer.ReadOnly = True
        txtSequencer.Text = "seq_monthly_element"

        ucrMonthlydata.SetKeyControls(ucrStationSelector, ucrElementSelector, ucrYearSelector, ucrNavigation)

        ucrNavigation.PopulateControl()
        SaveEnable()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))
        ucrNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields)
        ucrMonthlydata.Focus()

        'Get the Station from the last record by the current login user
        Dim usrStn As New dataEntryGlobalRoutines
        usrStn.GetCurrentStation("form_monthly", ucrStationSelector.cboValues.Text)
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrMonthlydata.SaveRecord()
                ucrNavigation.GoToNewRecord()
                SaveEnable()
                MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnAddNew.Focus() 'temporary
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

            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrMonthlydata.SaveRecord()
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrMonthlydata.DeleteRecord()
                ucrNavigation.RemoveRecord()
                SaveEnable()
                MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of datatable
        ucrNavigation.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear and on dialog load
    ''' </summary>
    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnCommit.Enabled = True
        ElseIf ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    'TODO
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql As String
        Dim userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_monthly"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy;"
        Else
            sql = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_monthly")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If MessageBox.Show("Are you sure you want to upload these records?", "Upload Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ucrMonthlydata.UploadAllRecords()
            'MessageBox.Show("Records have been uploaded sucessfully", "Upload Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Function ValidateValues() As Boolean
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

        If Not ucrYearSelector.ValidateValue Then
            MessageBox.Show("Invalid Year", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrYearSelector.Focus()
            Return False
        End If

        'Check if all values are empty. There should be atleast one observation value
        If ucrMonthlydata.IsValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrMonthlydata.Focus()
            Return False
        End If

        If Not ucrMonthlydata.ValidateValue Then
            Return False
        End If

        Return True

    End Function

    Private Sub AllControls_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrStationSelector.evtKeyDown, ucrElementSelector.evtKeyDown, ucrYearSelector.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrBaseDataLink Then
                If DirectCast(sender, ucrBaseDataLink).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the noise on  return key down
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrFormDaily_evtValueChanged(sender As Object, e As EventArgs) Handles ucrMonthlydata.evtValueChanged
        If ucrMonthlydata.bUpdating Then
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