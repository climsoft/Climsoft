Public Class frmNewSynopticRA1
    Private bFirstLoad As Boolean = True

    Private Sub frmNewSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            InitaliseDialog()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitaliseDialog()
        Dim dctNavigationFields As New Dictionary(Of String, List(Of String))
        Dim dctNavigationKeyControls As New Dictionary(Of String, ucrBaseDataLink)

        dctNavigationFields.Add("stationId", New List(Of String)({"stationId"}))
        dctNavigationFields.Add("yyyy", New List(Of String)({"yyyy"}))
        dctNavigationFields.Add("mm", New List(Of String)({"mm"}))
        dctNavigationFields.Add("dd", New List(Of String)({"dd"}))
        dctNavigationFields.Add("hh", New List(Of String)({"hh"}))

        ucrNavigation.SetFields(dctNavigationFields)
        ucrNavigation.SetTableName("form_synoptic_2_ra1")

        dctNavigationKeyControls.Add("stationId", ucrStationSelector)
        dctNavigationKeyControls.Add("yyyy", ucrYearSelector)
        dctNavigationKeyControls.Add("mm", ucrMonth)
        dctNavigationKeyControls.Add("dd", ucrDay)
        dctNavigationKeyControls.Add("hh", ucrHour)

        ucrNavigation.SetKeyControls(dctNavigationKeyControls)

        ucrNavigation.PopulateControl()
        AssignLinkToKeyField(ucrSynopticDataForManyElements)
        ucrSynopticDataForManyElements.PopulateControl()
    End Sub

    Private Sub AssignLinkToKeyField(ucrControl As ucrBaseDataLink)
        ucrControl.AddLinkedControlFilters(ucrStationSelector, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        ucrControl.AddLinkedControlFilters(ucrYearSelector, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)
        ucrControl.AddLinkedControlFilters(ucrHour, "hh", "==", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrSynopticDataForManyElements.Clear()
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        If ucrSynopticDataForManyElements.bUpdating Then
            'Possibly we should be cloning and then updating here
        Else
            clsDataConnection.db.form_synoptic_2_ra1.Add(ucrSynopticDataForManyElements.fs2ra1Record)
        End If
        clsDataConnection.SaveUpdate()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        If ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim msgBoxResponse As DialogResult
        msgBoxResponse = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgBoxResponse = DialogResult.Yes Then
            Try
                clsDataConnection.db.form_synoptic_2_ra1.Attach(ucrSynopticDataForManyElements.fs2ra1Record)
                clsDataConnection.db.form_synoptic_2_ra1.Remove(ucrSynopticDataForManyElements.fs2ra1Record)
                clsDataConnection.db.SaveChanges()
                MessageBox.Show("Record has been deleted", "Delete Record")
                ucrNavigation.RemoveRecord()
                SaveEnable()
            Catch
                MessageBox.Show("Record has not been deleted", "Delete Record")
            End Try
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        ucrNavigation.MoveLast()
        ucrSynopticDataForManyElements.Clear()
        ucrNavigation.SetControlsForNewRecord()
        ucrSynopticDataForManyElements.ucrVFPStationLevelPressure.Focus()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim msgBoxResponse As DialogResult
        msgBoxResponse = MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If msgBoxResponse = DialogResult.Yes Then
            Try

                If ucrSynopticDataForManyElements.bUpdating Then
                    clsDataConnection.db.Entry(ucrSynopticDataForManyElements.fs2ra1Record).State = Entity.EntityState.Modified
                    clsDataConnection.db.SaveChanges()
                Else
                    clsDataConnection.db.Entry(ucrSynopticDataForManyElements.fs2ra1Record).State = Entity.EntityState.Added
                    clsDataConnection.db.SaveChanges()
                End If

                MessageBox.Show(Me, "Record updated successfully!", "Update Record", MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, "Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class