Public Class frmNewHourlyWind
    Private bFirstLoad As Boolean = True
    Dim iDirectionDigits As Integer
    Dim iSpeedDigits As Integer

    Private Sub frmNewHourlyWind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
        'TODO. Remove this once btnUpload has beeen enabled in the designer
        btnUpload.Enabled = True
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        'get default database direction and speed digits, then set them to the controls
        SetDirectionAndSpeedDigits()
        txtDirectionDigits.Text = iDirectionDigits
        txtSpeedDigits.Text = iSpeedDigits

        ucrHourlyWind.SetDirectionDigits(iDirectionDigits)
        ucrHourlyWind.SetSpeedDigits(iSpeedDigits)

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
        ucrNavigation.MoveFirst()
        SaveEnable()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try
            'Open form for displaying data transfer progress
            frmDataTransferProgress.Show()
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring records... "
            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
            ucrHourlyWind.UploadAllRecords()
            frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
            frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
        Catch ex As Exception
            MessageBox.Show("Records has NOT been uploaded. Error: " & ex.Message, "Records Upload", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Function ValidateValues() As Boolean
        'Check valid station
        If Not ucrStationSelector.ValidateValue() Then
            MessageBox.Show("Invalid station", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrStationSelector.Focus()
            Return False
        End If

        'Check valid year
        If Not ucrYearSelector.ValidateValue() Then
            MessageBox.Show("Invalid year", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrYearSelector.Focus()
            Return False
        End If

        'Check valid month
        If Not ucrMonth.ValidateValue() Then
            MessageBox.Show("Invalid Month", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrMonth.Focus()
            Return False
        End If

        'Check valid Day
        If Not ucrDay.ValidateValue() Then
            MessageBox.Show("Invalid day", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrDay.Focus()
            Return False
        End If

        'Check if all values are empty. There should be atleast one observation value
        If ucrHourlyWind.IsDirectionValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrHourlyWind.Focus()
            Return False
        End If

        'check if values are valid.  
        If Not ucrHourlyWind.ValidateValue() Then
            Return False
        End If

        'check speed total required
        If Not ucrHourlyWind.checkSpeedTotal() Then
            ucrHourlyWind.ucrInputTotal.Focus()
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

    Private Sub AllControls_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrYearSelector.evtKeyDown, ucrStationSelector.evtKeyDown, ucrMonth.evtKeyDown, ucrHourlyWind.evtKeyDown, ucrDay.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrBaseDataLink Then
                If DirectCast(sender, ucrBaseDataLink).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the "noise" on enter key down
                e.SuppressKeyPress = True
            End If
        End If
    End Sub



End Class
