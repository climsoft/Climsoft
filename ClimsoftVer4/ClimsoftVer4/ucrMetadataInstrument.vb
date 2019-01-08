Public Class ucrMetadataInstrument

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'Set up the table name and the field names
            SetUpTableEntry("instrument")

            'set up the key control
            ucrDataLinkInstrumentID.SetTableNameAndField("instrument", "instrumentId")
            ucrDataLinkInstrumentID.PopulateControl()
            ucrDataLinkInstrumentID.SetDisplayAndValueMember("instrumentId")
            ucrDataLinkInstrumentID.bValidate = False ' TODO build in the extra validation like accepting new valid value

            'set view type for the station selector to ID
            ucrStationSelector.SetViewTypeAsIDs()

            'set FILTER control used in the where clause of the SELECT statement
            AddLinkedControlFilters(ucrDataLinkInstrumentID, ucrDataLinkInstrumentID.FieldName, "=", strLinkedFieldName:=ucrDataLinkInstrumentID.FieldName, bForceValuesAsString:=True)

            'set FILTER field name used in the where clause of UPDATE and DELETE statement
            AddKeyField(ucrDataLinkInstrumentID.FieldName)

            'set up the navigation control
            ucrNavigationInstrument.SetTableEntry(Me) 'bind the tableEntry control
            ucrNavigationInstrument.AddKeyControls(ucrDataLinkInstrumentID) 'bind (Biderectional) the key control

            bFirstLoad = False

            'populate the values
            ucrNavigationInstrument.PopulateControl()

        End If
    End Sub

    Private Sub cmdAddNew_Click(sender As Object, e As EventArgs) Handles cmdAddNew.Click
        ucrNavigationInstrument.NewRecord()
        SaveEnable()
    End Sub

    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrNavigationInstrument.GoToNewRecord()
                    SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdUpdateInstrument_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If UpdateRecord() Then
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub cmdDeleteInstrument_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeleteRecord() Then
                    ucrNavigationInstrument.RemoveRecord()
                    SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        'Move to the first record of datatable
        ucrNavigationInstrument.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    Private Function ValidateValues() As Boolean
        Return True
    End Function

    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear and on dialog load
    ''' </summary>
    Private Sub SaveEnable()
        cmdAddNew.Enabled = True
        cmdSave.Enabled = False
        cmdClear.Enabled = False
        cmdDelete.Enabled = False
        cmdUpdate.Enabled = False

        If ucrNavigationInstrument.iCurrRow = -1 Then
            cmdAddNew.Enabled = False
            cmdClear.Enabled = True
            cmdDelete.Enabled = False
            cmdUpdate.Enabled = False
            cmdSave.Enabled = True
        ElseIf ucrNavigationInstrument.iMaxRows = 0 Then
            cmdAddNew.Enabled = False
            cmdSave.Enabled = True
        ElseIf ucrNavigationInstrument.iMaxRows > 0 Then
            cmdDelete.Enabled = True
            cmdUpdate.Enabled = True
        End If
    End Sub


End Class
