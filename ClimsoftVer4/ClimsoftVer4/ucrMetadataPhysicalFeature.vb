Public Class ucrMetadataPhysicalFeature

    Private Sub ucrMetadataPhysicalFeature_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("physicalfeature")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:=ucrStationSelector.FieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationPhysicalFeature.SetTableEntry(Me)
            ucrNavigationPhysicalFeature.AddKeyControls(ucrStationSelector)

            bFirstLoad = False

            'populate the values
            ucrNavigationPhysicalFeature.PopulateControl()

        End If
    End Sub
End Class
