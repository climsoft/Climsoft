Public Class frmNewHourly
    Private bFirstLoad As Boolean = True
    Dim selectAllHours As Boolean

    Private Sub frmNewHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
        selectAllHours = False
    End Sub

    Private Sub InitaliseDialog()
        txtSequencer.Text = "seq_month_day"
        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)
        ucrHourly.SetKeyControls(ucrElement:=ucrElementSelector, ucrYear:=ucrYearSelector, ucrMonth:=ucrMonth, ucrDay:=ucrDay, ucrStation:=ucrStationSelector, ucrNavigation:=ucrHourlyNavigation)
        ucrHourlyNavigation.PopulateControl()
        SaveEnable()
    End Sub

    Private Sub cmdAssignSameValue_Click(sender As Object, e As EventArgs) Handles cmdAssignSameValue.Click
        Dim ctl As Control
        Dim ctrltemp As ucrValueFlagPeriod

        'Adds values to only enabled controls of the ucrHourly
        For Each ctl In ucrHourly.Controls
            If TypeOf ctl Is ucrValueFlagPeriod Then
                ctrltemp = ctl
                If ctrltemp.ucrValue.Enabled Then
                    ctrltemp.ucrValue.SetValue(ucrInputValue.GetValue())
                End If
            End If
        Next
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'On clear, navigation moves to first record
        ucrHourlyNavigation.MoveFirst()
        SaveEnable()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If Not ValidateValues() Then
            Exit Sub
        End If

        'Confirm if you want to continue and save data from key-entry form to database table
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then

            If ucrHourly.bUpdating Then
                'Possibly we should be cloning and then updating here
            Else
                clsDataConnection.db.form_hourly.Add(ucrHourly.fhRecord)
            End If
            clsDataConnection.SaveUpdate()
            ucrHourlyNavigation.ResetControls()
            ucrHourlyNavigation.GoToNewRecord()
            SaveEnable()
        Else
            MessageBox.Show("Record not Saved", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim dlgResponse As DialogResult
        dlgResponse = MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_hourly.Attach(ucrHourly.fhRecord)
                clsDataConnection.db.form_hourly.Remove(ucrHourly.fhRecord)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrHourlyNavigation.RemoveRecord()
            Catch
                'message box?
            End Try
        Else
            MsgBox("Operation cancelled!", MsgBoxStyle.Information)
        End If
        ucrHourlyNavigation.MoveFirst()
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim dlgResponse As DialogResult
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            dlgResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dlgResponse = DialogResult.Yes Then
                clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Modified
                clsDataConnection.db.SaveChanges()
                MsgBox("Record updated successfully!", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        If ucrYearSelector.isLeapYear Then
            txtSequencer.Text = "seq_month_day_leap_yr"
        Else
            txtSequencer.Text = "seq_month_day"
        End If

        dctSequencerFields.Add("mm", New List(Of String)({"mm"}))
        dctSequencerFields.Add("dd", New List(Of String)({"dd"}))
        ucrHourlyNavigation.NewSequencerRecord(strSequencer:=txtSequencer.Text, dctFields:=dctSequencerFields, lstDateIncrementControls:=New List(Of ucrDataLinkCombobox)({ucrDay, ucrMonth}), ucrYear:=ucrYearSelector)

        ucrHourly.UcrValueFlagPeriod0.Focus()
        ucrHourlyNavigation.MoveLast()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        If ucrHourlyNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        Else
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
        End If
    End Sub

    'Changes the date entry fields betwen synoptc hours and all hours
    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click

        Dim ctrVFP As ucrValueFlagPeriod
        If selectAllHours Then
            selectAllHours = False
            btnHourSelection.Text = "Enable synoptic hours only"
            For Each ctr As Control In ucrHourly.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.Enabled = True
                    ctrVFP.SetBackColor(Color.White)
                End If
            Next
        Else
            selectAllHours = True
            btnHourSelection.Text = "Enable all hours"
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableName("form_hourly_time_selection")
            clsDataDefinition.SetFields(New List(Of String)({"hh", "hh_selection"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In ucrHourly.Controls
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

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub

    Private Function ValidateValues() As Boolean
        If Not ucrStationSelector.ValidateValue Then
            MsgBox("Invalid Station", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Not ucrElementSelector.ValidateValue Then
            MsgBox("Invalid Element", MsgBoxStyle.Exclamation)
                Return False
            End If

            If Not ucrMonth.ValidateValue Then
            MsgBox("Invalid Element", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Not ucrYearSelector.ValidateValue Then
            MsgBox("Invalid Year", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Not ucrDay.ValidateValue Then
            MsgBox("Invalid Day", MsgBoxStyle.Exclamation)
            Return False
        End If

        If Not ucrHourly.checkTotal Then
            Return False
        End If

        Return True
    End Function
End Class