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
        AssignLinkToKeyField(ucrHourly)


        ucrHourlyNavigation.SetTableNameAndFields("form_hourly", (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "dd"})))

        ucrHourlyNavigation.SetKeyControls("stationId", ucrStationSelector)
        ucrHourlyNavigation.SetKeyControls("elementId", ucrElementSelector)
        ucrHourlyNavigation.SetKeyControls("yyyy", ucrYearSelector)
        ucrHourlyNavigation.SetKeyControls("mm", ucrMonth)
        ucrHourlyNavigation.SetKeyControls("dd", ucrDay)

        txtSequencer.Text = "seq_month_day_element"

        ucrHourly.SetLinkedNavigation(ucrHourlyNavigation)
        ucrHourlyNavigation.PopulateControl()
        SaveEnable()
    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrElementSelector, "elementId", "==", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)

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
        ucrHourlyNavigation.MoveFirst()
        SaveEnable()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrHourly.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_hourly.Add(ucrHourly.fhRecord)
        End If
        clsDataConnection.SaveUpdate()
        SaveEnable()
        ucrHourlyNavigation.ResetControls()
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
        dlgResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If dlgResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.Entry(ucrHourly.fhRecord).State = Entity.EntityState.Modified
                clsDataConnection.db.SaveChanges()
                MsgBox("Record updated successfully!", MsgBoxStyle.Information)
            Catch
                '?messagebox
            End Try
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim dctSequencerFields As New Dictionary(Of String, List(Of String))

        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        ' temporary until we know how to get all fields from table without specifying names
        dctSequencerFields.Add("elementId", New List(Of String)({"elementId"}))
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
        End If
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        Dim ctrVFP As ucrValueFlagPeriod
        Dim lstSynopticHourControls As New List(Of ucrValueFlagPeriod)
        lstSynopticHourControls.AddRange({ucrHourly.ucrValueFlagPeriod3, ucrHourly.ucrValueFlagPeriod6, ucrHourly.ucrValueFlagPeriod9, ucrHourly.UcrValueFlagPeriod12, ucrHourly.UcrValueFlagPeriod15, ucrHourly.UcrValueFlagPeriod18, ucrHourly.UcrValueFlagPeriod21})

        If selectAllHours Then
            selectAllHours = False
            btnHourSelection.Text = "Enable synoptic hours only"

            For Each ctr As Control In ucrHourly.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    If Not lstSynopticHourControls.Contains(ctrVFP) Then
                        ctrVFP.ucrFlag.Enabled = True
                        ctrVFP.ucrValue.Enabled = True
                        ctrVFP.ucrFlag.SetBackColor(Color.White)
                        ctrVFP.ucrValue.SetBackColor(Color.White)
                    End If
                End If
            Next

        Else
            selectAllHours = True
            btnHourSelection.Text = "Enable all hours"
            For Each ctr As Control In ucrHourly.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    If Not lstSynopticHourControls.Contains(ctrVFP) Then
                        ctrVFP.ucrFlag.Enabled = False
                        ctrVFP.ucrValue.Enabled = False
                        ctrVFP.ucrFlag.SetBackColor(Color.LightYellow)
                        ctrVFP.ucrValue.SetBackColor(Color.LightYellow)
                    End If
                End If
            Next

        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub
End Class