Public Class ucrAgroMet
    Private strValueFieldName As String = "val_"
    Private strFlagFieldName As String = "flag"

    Private Sub ucrAgroMet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.setInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            'SetUpTableEntry("form_agro1")

            ucrAgrometStationSelector.SetTableNameAndField("station", "stationId")
            ucrAgrometStationSelector.PopulateControl()

            ucrAgrometStationSelector.SetDisplayAndValueMember("stationId")
            ucrAgrometStationSelector.SetValidationTypeAsNumeric()

            AddLinkedControlFilters(ucrAgrometStationSelector, ucrAgrometStationSelector.FieldName(), "=", strLinkedFieldName:=ucrAgrometStationSelector.FieldName(), bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrAgrometYearSelector, ucrAgrometYearSelector.FieldName(), "=", strLinkedFieldName:=ucrAgrometYearSelector.FieldName(), bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrAgrometMonthSelector, ucrAgrometMonthSelector.FieldName(), "=", strLinkedFieldName:=ucrAgrometMonthSelector.FieldName(), bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrAgrometDaySelector, ucrAgrometDaySelector.FieldName(), "=", strLinkedFieldName:=ucrAgrometDaySelector.FieldName(), bForceValuesAsString:=False)


            ucrAgrometNavigation.SetTableEntryAndKeyControls(Me)

            bFirstLoad = False
            ucrAgrometNavigation.PopulateControl()
            SaveEnable()
        End If
    End Sub
    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrAgrometNavigation.iCurrRow = -1 Then
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrAgrometNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrAgrometNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrAgrometStationSelector.PopulateControl()
                    ucrAgrometNavigation.GoToNewRecord()
                    SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If UpdateRecord() Then
                    MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    ucrAgrometNavigation.RemoveRecord()
                    SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ucrAgrometNavigation.MoveFirst()
        SaveEnable()
    End Sub
End Class
