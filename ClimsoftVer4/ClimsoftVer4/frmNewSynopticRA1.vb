Public Class frmNewSynopticRA1
    Private bFirstLoad As Boolean = True

    Private Sub frmNewSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
        'TODO. Remove this line once button upload is enabled in the designer
        btnUpload.Enabled = True
    End Sub

    Private Sub InitaliseDialog()
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        ucrSynopticRA1.SetKeyControls(ucrStationSelector, ucrYearSelector, ucrMonth, ucrDay, ucrHour, ucrNavigation)

        ucrNavigation.PopulateControl()

        SaveEnable()
        SetControlsKeyDownListners()
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
        ucrNavigation.MoveFirst()
        SaveEnable()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

        'Check if all values are valid. There should be atleast one observation value
        If Not ucrSynopticRA1.ValidateValue() Then
            MessageBox.Show("Invalid observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' sets key down listeners for the form controls
    ''' </summary>
    Private Sub SetControlsKeyDownListners()
        Dim synopticControl As ucrSynopticRA1

        For Each formCtr As Control In Me.Controls
            If TypeOf formCtr Is ucrBaseDataLink Then
                If TypeOf formCtr Is ucrSynopticRA1 Then
                    'for ucrSynopticRA1 controls
                    synopticControl = DirectCast(formCtr, ucrSynopticRA1)
                    For Each synopCtr As Control In synopticControl.Controls
                        If TypeOf synopCtr Is ucrValueFlagPeriod Then
                            AddHandler DirectCast(synopCtr, ucrValueFlagPeriod).evtKeyDown, AddressOf GoToNextControl
                        End If
                    Next
                Else
                    'for the other base controls e.g station, year, month, day, hour slectors
                    AddHandler DirectCast(formCtr, ucrBaseDataLink).evtKeyDown, AddressOf GoToNextControl
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' determines the next control to get focus on enter key  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GoToNextControl(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Dim bGoToNextControl As Boolean = False

            'do validations to determine whether to go to next control
            If TypeOf sender Is ucrValueFlagPeriod Then
                Dim ucrVFP As ucrValueFlagPeriod = DirectCast(sender, ucrValueFlagPeriod)
                If ucrVFP.ValidateText(ucrVFP.ucrValue.GetValue()) Then
                    bGoToNextControl = True
                End If
            ElseIf TypeOf sender Is ucrBaseDataLink Then
                'for the other base controls e.g station, year, month, day, hour slectors
                If DirectCast(sender, ucrBaseDataLink).ValidateValue() Then
                    bGoToNextControl = True
                End If
            End If

            If bGoToNextControl Then
                Me.SelectNextControl(sender, True, True, True, True)
            End If

            'to handle the "noise"
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Try
            'Open form for displaying data transfer progress
            frmDataTransferProgress.Show()
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring records... "
            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
            ucrSynopticRA1.UploadAllRecords()
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

    'TODO. This is from Samuel's code
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

    'TODO. Copied from Samuel's code
    Private Sub btnTDCF_Click(sender As Object, e As EventArgs) Handles btnTDCF.Click
        frmSynopTDCF.Show()
        frmSynopTDCF.cboTemplate.Text = "TM_307081"
        ' Subset Observations
        SubsetObservations()
    End Sub

    'TODO. Copied from Samuel's code
    Sub SubsetObservations()
        Dim kount As Integer
        Dim myConnectionString As String
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim sql As String
        Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds As New DataSet
        Try
            myConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' Get all stations with the same observation time to constitute the subset of stations for encoding
            sql = "SELECT stationId, yyyy, mm, dd, hh from form_synoptic_2_ra1 where yyyy = '" & ucrYearSelector.GetValue & "' and mm = '" & ucrMonth.GetValue & "' and dd = '" & ucrDay.GetValue & "' and hh = '" & ucrHour.GetValue & "';"

            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_synoptic_2_ra1")
            kount = ds.Tables("form_synoptic_2_ra1").Rows.Count

            frmSynopTDCF.cboStation.Text = ucrStationSelector.GetValue
            frmSynopTDCF.txtYear.Text = ucrYearSelector.GetValue
            frmSynopTDCF.cboMonth.Text = ucrMonth.GetValue
            frmSynopTDCF.cboDay.Text = ucrDay.GetValue
            frmSynopTDCF.cboHour.Text = ucrHour.GetValue

            ' Populate the station combo box with the stations for the subset
            For i = 0 To kount - 1
                'MsgBox(ds.Tables("form_synoptic_2_ra1").Rows(i).Item("stationId"))
                frmSynopTDCF.cboStation.Items.Add(ds.Tables("form_synoptic_2_ra1").Rows(i).Item("stationId"))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
    End Sub



End Class