Public Class ucrMetadataInstrument

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'Set up the table name and the field names
            SetUpTableEntry("instrument")

            'set up the key control
            ucrDataLinkInstrumentID.SetTableNameAndField("instrument", "instrumentId")
            ucrDataLinkInstrumentID.PopulateControl()
            ucrDataLinkInstrumentID.SetDisplayAndValueMember("instrumentId")
            ucrDataLinkInstrumentID.bValidate = False ' TODO build in the extra validation


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

    Private Sub cmdUpdateInstrument_Click(sender As Object, e As EventArgs) Handles cmdUpdateInstrument.Click
        If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If UpdateRecord() Then
                MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub cmdDeleteInstrument_Click(sender As Object, e As EventArgs) Handles cmdDeleteInstrument.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeleteRecord() Then
                    ucrNavigationInstrument.RemoveRecord()
                    'SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdAddInstrument_Click(sender As Object, e As EventArgs) Handles cmdAddInstrument.Click
        Try
            If Not ValidateValues() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrNavigationInstrument.GoToNewRecord()
                    'SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cmdClear2_Click(sender As Object, e As EventArgs) Handles cmdClear2.Click

        'TODO what should be done on click Add new

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView Then
                DirectCast(ctr, ucrValueView).Clear()
            End If
        Next

        ucrDataLinkInstrumentID.Clear()
    End Sub


    Private Function ValidateValues() As Boolean
        Return True
    End Function


End Class
