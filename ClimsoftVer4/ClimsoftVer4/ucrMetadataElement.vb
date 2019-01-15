Public Class ucrMetadataElement

    Private Sub ucrMetadataElement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("obselement")

            ucrDataLinkElementID.SetTableNameAndField("obselement", "elementId")
            ucrDataLinkElementID.PopulateControl()
            ucrDataLinkElementID.SetDisplayAndValueMember("elementId")
            ucrDataLinkElementID.SetValidationTypeAsNumeric(dcmMin:=1)

            ucrDataLinkType.SetPossibleValues("elementtypes", GetType(String), {"Daily", "Hourly", "Monthly", "AWS"})
            ucrDataLinkType.SetDisplayAndValueMember("elementtypes")
            ucrDataLinkType.bValidateEmpty = False

            ucrElementSelectorSearch.bValidate = False

            ucrTextBoxScale.SetValidationTypeAsNumeric()
            ucrTextBoxUpperLimit.SetValidationTypeAsNumeric()
            ucrTextBoxUpperLimit.bValidateEmpty = False
            ucrTextBoxLowerLimit.SetValidationTypeAsNumeric()
            ucrTextBoxLowerLimit.bValidateEmpty = False

            AddLinkedControlFilters(ucrDataLinkElementID, ucrDataLinkElementID.FieldName(), "=", strLinkedFieldName:=ucrDataLinkElementID.FieldName(), bForceValuesAsString:=True)

            AddKeyField(ucrDataLinkElementID.FieldName)

            'set up the navigation control
            ucrNavigationElement.SetTableEntry(Me)
            ucrNavigationElement.AddKeyControls(ucrDataLinkElementID)

            bFirstLoad = False

            'populate the values
            ucrNavigationElement.PopulateControl()
            SaveEnable()
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ucrNavigationElement.NewRecord()
        SaveEnable()
        ucrDataLinkElementID.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrNavigationElement.GoToNewRecord()
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
                    ucrNavigationElement.RemoveRecord()
                    SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of datatable
        ucrNavigationElement.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigationElement.iCurrRow = -1 Then
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigationElement.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigationElement.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub
End Class
