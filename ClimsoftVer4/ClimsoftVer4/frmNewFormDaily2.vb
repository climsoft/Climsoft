Public Class frmNewFormDaily2
    Private bFirstLoad As Boolean = True
    Dim FldName As New dataEntryGlobalRoutines

    Private Sub frmNewFormDaily2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Disable Delete & upload button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" OrElse userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If

        ' Run InitaliseDialog only if its first load
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
        txtSequencer.Text = "seq_daily_element"
        chkEnableSequencer.Checked = True

        'Sets values for the units combobox
        ucrTempUnits.SetPossibleValues("temperatureUnits", GetType(String), {"Deg C", "Deg F"})
        ucrTempUnits.SetDisplayAndValueMember("temperatureUnits")
        ucrTempUnits.bValidate = False

        ucrCloudheightUnits.SetPossibleValues("cloudHeightUnits", GetType(String), {"feet", "metres"})
        ucrCloudheightUnits.SetDisplayAndValueMember("cloudHeightUnits")
        ucrCloudheightUnits.bValidate = False

        ucrPrecipUnits.SetPossibleValues("precipUnits", GetType(String), {"mm", "inches"})
        ucrPrecipUnits.SetDisplayAndValueMember("precipUnits")
        ucrPrecipUnits.bValidate = False

        ucrVisibilityUnits.SetPossibleValues("visUnits", GetType(String), {"metres", "yards"})
        ucrVisibilityUnits.SetDisplayAndValueMember("visUnits")
        ucrVisibilityUnits.bValidate = False

        'add the units link  
        ucrFormDaily.AddUnitslink("visUnits", ucrVisibilityUnits)
        ucrFormDaily.AddUnitslink("cloudHeightUnits", ucrCloudheightUnits)
        ucrFormDaily.AddUnitslink("precipUnits", ucrPrecipUnits)
        ucrFormDaily.AddUnitslink("temperatureUnits", ucrTempUnits)

        ucrFormDaily.SetKeyControls(ucrStationSelector, ucrElementSelector, ucrYearSelector, ucrMonth, ucrHour, ucrDaiy2Navigation)

        ucrDaiy2Navigation.PopulateControl()
        SaveEnable()

    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        ucrFormDaily.SetSameValueToAllObsElements(ucrInputValue.GetValue())
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        If chkEnableSequencer.Checked Then
            ' temporary until we know how to get all fields from table without specifying names
            dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))
            ucrDaiy2Navigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrMonth}), ucrYear:=ucrYearSelector)
        End If

        ucrFormDaily.Focus()

        'Get the Station from the last record by the current login user
        Dim usrStn As New dataEntryGlobalRoutines
        usrStn.GetCurrentStation("form_daily2", ucrStationSelector.cboValues.Text)

    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrFormDaily.SaveRecord()
                ucrDaiy2Navigation.GoToNewRecord()
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

            If Not chkRepeatEntry.Checked Then
                If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    ucrFormDaily.SaveRecord()
                    MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            ' When in double entry mode just skip update action. Values have been updated on entry
            If chkRepeatEntry.Checked Then
                Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

                'temporary until we know how to get all fields from table without specifying names
                dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
                dctSequencerFields.Add("dd", New List(Of String)({"dd"}))
                dctSequencerFields.Add("hh", New List(Of String)({"hh"}))
                ucrDaiy2Navigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrMonth}), ucrYear:=ucrYearSelector)
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

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ucrFormDaily.DeleteRecord()
                ucrDaiy2Navigation.RemoveRecord()
                SaveEnable()
                MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of datatable
        ucrDaiy2Navigation.MoveFirst()
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

        If ucrDaiy2Navigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnCommit.Enabled = True
        ElseIf ucrDaiy2Navigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    'TODO
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_daily2"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
        Else
            sql = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_daily2")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If MessageBox.Show("Are you sure you want to upload these records?", "Upload Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ucrFormDaily.UploadAllRecords()
            'MessageBox.Show("Records have been uploaded sucessfully", "Upload Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        If Not ucrYearSelector.ValidateValue Then
            MessageBox.Show("Invalid Year", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrYearSelector.Focus()
            Return False
        End If

        If Not ucrMonth.ValidateValue Then
            MessageBox.Show("Invalid Month", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrMonth.Focus()
            Return False
        End If

        If Not ucrHour.ValidateValue Then
            MessageBox.Show("Invalid Hour", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        'Check if all values are empty. There should be atleast one observation value
        If ucrFormDaily.IsValuesEmpty() Then
            MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ucrFormDaily.Focus()
            Return False
        End If

        If Not ucrFormDaily.ValidateValue Then
            Return False
        End If

        If bCheckTotal Then
            If Not ucrFormDaily.checkTotal() Then
                ucrFormDaily.ucrInputTotal.Focus()
                Return False
            End If
        End If

        Return True

    End Function

    Private Sub AllControls_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrStationSelector.evtKeyDown, ucrElementSelector.evtKeyDown, ucrYearSelector.evtKeyDown, ucrMonth.evtKeyDown, ucrHour.evtKeyDown, ucrFormDaily.evtKeyDown
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

    Private Sub UnitsControls_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrTempUnits.evtKeyDown, ucrPrecipUnits.evtKeyDown, ucrCloudheightUnits.evtKeyDown, ucrVisibilityUnits.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If sender Is ucrVisibilityUnits Then
                ucrFormDaily.Focus()
            Else
                Me.SelectNextControl(sender, True, True, True, True)
            End If
            'this handles the noise on  return key down
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ucrFormDaily_evtValueChanged(sender As Object, e As EventArgs) Handles ucrFormDaily.evtValueChanged
        If ucrFormDaily.bUpdating Then
            SaveEnable()
        Else
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnCommit.Enabled = True
        End If
    End Sub

    Private Sub chkEnableSequencer_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSequencer.CheckedChanged
        txtSequencer.Text = If(chkEnableSequencer.Checked, "seq_daily_element", "")
    End Sub

    'Function GetCurrentStation(frm As String, ByRef stn As String) As Boolean
    '    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    '    Dim daLastDataRecord As MySql.Data.MySqlClient.MySqlDataAdapter
    '    Dim strConnString, SQL_last_record As String
    '    Dim dsLastDataRecord As New DataSet
    '    Dim recs As Long

    '    Try
    '        strConnString = frmLogin.txtusrpwd.Text
    '        conn.ConnectionString = strConnString
    '        conn.Open()

    '        SQL_last_record = "select form_daily2.stationId,stationName, entryDatetime from " & frm & " form_daily2 INNER JOIN station ON form_daily2.stationId = station.stationId where signature ='" & frmLogin.txtUsername.Text & "' order by entryDatetime;"
    '        dsLastDataRecord.Clear()
    '        daLastDataRecord = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL_last_record, conn)
    '        ' Set to unlimited timeout period
    '        daLastDataRecord.SelectCommand.CommandTimeout = 0
    '        daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

    '        conn.Close()

    '        recs = dsLastDataRecord.Tables("lastDataRecord").Rows.Count

    '        If recs > 0 Then
    '            stn = dsLastDataRecord.Tables("lastDataRecord").Rows(recs - 1).Item("StationName")
    '        Else
    '            Return False
    '        End If

    '        GetCurrentStation = True
    '    Catch ex As Exception
    '        Return False
    '        MsgBox(ex.Message)
    '    End Try

    'End Function
End Class