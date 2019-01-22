Public Class ucrMetadataStation
    Private Sub ucrMetadataStation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then

            SetUpTableEntry("station")

            ucrStationIDcombobox.SetTableNameAndField("station", "stationId")
            ucrStationIDcombobox.PopulateControl()
            ucrStationIDcombobox.SetDisplayAndValueMember("stationId")

            'validations
            ucrStationName.bValidateEmpty = True
            ucrTextBoxLatitude.SetValidationTypeAsNumeric()
            ucrTextBoxLongitude.SetValidationTypeAsNumeric()
            ucrTextBoxGeographicalAccuracy.SetValidationTypeAsNumeric()
            ucrSearchStationName.SetInValidColor(ucrSearchStationName.GetValidColor)

            ucrDataLinkComboboxNS.SetPossibleValues("direction", GetType(String), {"N", "S"})
            ucrDataLinkComboboxNS.SetDisplayAndValueMember("direction")
            ' ucrDataLinkComboboxNS.SelectFirst()
            ucrTextBoxDegreesLatitude.SetValidationTypeAsNumeric()
            ucrTextBoxMinutesLatitude.SetValidationTypeAsNumeric()
            ucrTextBoxSecondsLatitude.SetValidationTypeAsNumeric()

            ucrDataLinkComboboxEW.SetPossibleValues("direction", GetType(String), {"E", "W"})
            ucrDataLinkComboboxEW.SetDisplayAndValueMember("direction")
            ucrTextBoxDegreesLongitude.SetValidationTypeAsNumeric()
            ucrTextBoxMinutesLongitude.SetValidationTypeAsNumeric()
            ucrTextBoxSecondsLongitude.SetValidationTypeAsNumeric()


            AddLinkedControlFilters(ucrStationIDcombobox, ucrStationIDcombobox.FieldName(), "=", strLinkedFieldName:=ucrStationIDcombobox.FieldName(), bForceValuesAsString:=True)

            AddKeyField(ucrStationIDcombobox.FieldName)

            'set up the navigation control
            ucrNavigationStation.SetTableEntry(Me)
            ucrNavigationStation.AddKeyControls(ucrStationIDcombobox)

            bFirstLoad = False

            'populate the values
            ucrNavigationStation.PopulateControl()

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ucrNavigationStation.NewRecord()
        SaveEnable()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrStationIDcombobox.PopulateControl()
                    ucrNavigationStation.GoToNewRecord()
                    SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If UpdateRecord() Then
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeleteRecord() Then
                    ucrNavigationStation.RemoveRecord()
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
        ucrNavigationStation.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear and on dialog load
    ''' </summary>
    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigationStation.iCurrRow = -1 Then
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigationStation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnSave.Enabled = True
        ElseIf ucrNavigationStation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub ucrSearchStationName_evtValueChanged(sender As Object, e As EventArgs) Handles ucrSearchStationName.evtValueChanged
        If Not ucrStationIDcombobox.IsEmpty AndAlso ucrSearchStationName.ValidateValue Then
            ucrStationIDcombobox.SetValue(ucrSearchStationName.GetValue)
        End If
    End Sub

    Private Sub controlsDegreesLatitude_evtTextChanged(sender As Object, e As EventArgs) Handles ucrTextBoxDegreesLatitude.evtTextChanged, ucrTextBoxMinutesLatitude.evtTextChanged, ucrTextBoxSecondsLatitude.evtTextChanged, ucrDataLinkComboboxNS.evtTextChanged
        If ucrDataLinkComboboxNS.ValidateValue AndAlso ucrTextBoxDegreesLatitude.ValidateValue AndAlso ucrTextBoxMinutesLatitude.ValidateValue AndAlso ucrTextBoxSecondsLatitude.ValidateValue Then
            If IsNumeric(ucrTextBoxDegreesLatitude.GetValue) And IsNumeric(ucrTextBoxMinutesLatitude.GetValue) And IsNumeric(ucrTextBoxSecondsLatitude.GetValue) And Not String.IsNullOrWhiteSpace(ucrDataLinkComboboxNS.GetValue) Then
                ucrTextBoxLatitude.SetValue(GetDecimalDegrees(ucrDataLinkComboboxNS.GetValue, Val(ucrTextBoxDegreesLatitude.GetValue), Val(ucrTextBoxMinutesLatitude.GetValue), Val(ucrTextBoxSecondsLatitude.GetValue)))
            Else
                ucrTextBoxLatitude.SetValue(Nothing)
            End If
        End If
    End Sub

    Private Sub controlsDegreesLongitude_evtTextChanged(sender As Object, e As EventArgs) Handles ucrTextBoxDegreesLongitude.evtTextChanged, ucrTextBoxMinutesLongitude.evtTextChanged, ucrTextBoxSecondsLongitude.evtTextChanged, ucrDataLinkComboboxEW.evtTextChanged
        If ucrDataLinkComboboxEW.ValidateValue AndAlso ucrTextBoxDegreesLongitude.ValidateValue AndAlso ucrTextBoxMinutesLongitude.ValidateValue AndAlso ucrTextBoxSecondsLongitude.ValidateValue Then
            If IsNumeric(ucrTextBoxDegreesLongitude.GetValue) And IsNumeric(ucrTextBoxMinutesLongitude.GetValue) And IsNumeric(ucrTextBoxSecondsLongitude.GetValue) And Not String.IsNullOrWhiteSpace(ucrDataLinkComboboxEW.GetValue) Then
                ucrTextBoxLongitude.SetValue(GetDecimalDegrees(ucrDataLinkComboboxEW.GetValue, Val(ucrTextBoxDegreesLongitude.GetValue), Val(ucrTextBoxMinutesLongitude.GetValue), Val(ucrTextBoxSecondsLongitude.GetValue)))
            Else
                ucrTextBoxLongitude.SetValue(Nothing)
            End If
        End If
    End Sub

    Private Sub ucrNavigationStation_evtValueChanged(sender As Object, e As EventArgs) Handles ucrNavigationStation.evtValueChanged

    End Sub

    Private Function GetDecimalDegrees(strDirection As String, dDeg As Double, dMin As Double, dSec As Double) As Decimal
        ' Convert value in Degrees, Minutes and Seconds (DMS) to Decimal Degrees (DD)
        ' Direction must be N, S, E or W
        Dim multiplier As Integer = 1
        Dim decimalDegrees As Decimal
        If strDirection = "S" OrElse strDirection = "W" Then
            multiplier = -1
        End If
        decimalDegrees = multiplier * (dDeg + (dMin / 60) + (dSec / 3600))
        Return Math.Round(decimalDegrees, 2)
    End Function

End Class
