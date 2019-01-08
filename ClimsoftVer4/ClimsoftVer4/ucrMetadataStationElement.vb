Public Class ucrMetadataStationElement

    Private Sub ucrMetadataStationElement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("stationelement")

            ucrDataLinkElementID.SetTableNameAndField("stationelement", "describedBy")
            ucrDataLinkElementID.PopulateControl()
            ucrDataLinkElementID.SetDisplayAndValueMember("describedBy")
            ucrDataLinkElementID.bValidate = False

            AddLinkedControlFilters(ucrDataLinkElementID, ucrDataLinkElementID.FieldName(), "=", strLinkedFieldName:=ucrDataLinkElementID.FieldName(), bForceValuesAsString:=True)

            'set FILTER field name used in the where clause of UPDATE and DELETE statement
            AddKeyField(ucrStationSelector.FieldName)

            'set up the navigation control
            ucrNavigationStationElement.SetTableEntry(Me)
            ucrNavigationStationElement.AddKeyControls(ucrDataLinkElementID)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationElement.PopulateControl()

        End If
    End Sub

    Private Sub cmdUpdateStationElement_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        UpdateRecord()
    End Sub

    Private Sub cmdDeleteStationElement_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        DeleteRecord()
    End Sub
End Class

