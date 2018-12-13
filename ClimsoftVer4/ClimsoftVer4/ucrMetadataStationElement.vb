Public Class ucrMetadataStationElement

    Private Sub ucrMetadataStationElement_Load(sender As Object, e As EventArgs) Handles Me.Load
            If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("stationelement")

            AddLinkedControlFilters(ucrDataLinkElementID, ucrDataLinkElementID.FieldName(), "=", strLinkedFieldName:=ucrDataLinkElementID.FieldName(), bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationElement.SetTableEntry(Me)
            ucrNavigationStationElement.AddKeyControls(ucrDataLinkElementID)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationElement.PopulateControl()

        End If
        End Sub
End Class