Public Class frmNewSynopticRA1
    Private bFirstLoad As Boolean = True

    Private Sub frmNewSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        AssignLinkToKeyField(ucrSynopticRA1)

        ucrDay.setYearAndMonthLink(ucrYearSelector, ucrMonth)

        ucrNavigation.SetTableNameAndFields("form_synoptic_2_ra1", (New List(Of String)({"stationId", "yyyy", "mm", "dd", "hh"})))
        ucrNavigation.SetKeyControls("stationId", ucrStationSelector)
        ucrNavigation.SetKeyControls("yyyy", ucrYearSelector)
        ucrNavigation.SetKeyControls("mm", ucrMonth)
        ucrNavigation.SetKeyControls("dd", ucrDay)
        ucrNavigation.SetKeyControls("hh", ucrHour)

        ucrSynopticRA1.SetLinkedNavigation(ucrNavigation)

        ucrNavigation.PopulateControl()
        SaveEnable()

    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnSave.Enabled = True

        ucrSynopticRA1.ucrVFPStationLevelPressure.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If ucrSynopticRA1.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_synoptic_2_ra1.Add(ucrSynopticRA1.fs2ra1Record)
        End If
        clsDataConnection.SaveUpdate()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim msgBoxResponse As DialogResult
        msgBoxResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgBoxResponse = DialogResult.Yes Then
            Try

                If ucrSynopticRA1.bUpdating Then
                    clsDataConnection.db.Entry(ucrSynopticRA1.fs2ra1Record).State = Entity.EntityState.Modified
                    clsDataConnection.db.SaveChanges()
                Else
                    clsDataConnection.db.Entry(ucrSynopticRA1.fs2ra1Record).State = Entity.EntityState.Added
                    clsDataConnection.db.SaveChanges()
                End If

                MessageBox.Show(Me, "Record updated successfully!", "Update Record", MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim msgBoxResponse As DialogResult
        msgBoxResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgBoxResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_synoptic_2_ra1.Attach(ucrSynopticRA1.fs2ra1Record)
                clsDataConnection.db.form_synoptic_2_ra1.Remove(ucrSynopticRA1.fs2ra1Record)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrNavigation.RemoveRecord()
                SaveEnable()
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
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
        End If
    End Sub
End Class