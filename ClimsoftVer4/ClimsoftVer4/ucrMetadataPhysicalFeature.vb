Public Class ucrMetadataPhysicalFeature
    Private strassociatedWith As String = "associatedWith"

    Protected Overrides Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "physicalfeature"

            'ucrTableEntry_Load fills in the lstFields
            MyBase.ucrTableEntry_Load(sender, e)

            AddLinkedControlFilters(ucrStationSelector, strassociatedWith, "=", strLinkedFieldName:=strassociatedWith, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationPhysicalFeature.SetTableNameAndFields(strTableName, (New List(Of String)({strassociatedWith})))
            ucrNavigationPhysicalFeature.SetKeyControls(strassociatedWith, ucrStationSelector)

            bFirstLoad = False

            'populate the values
            ucrNavigationPhysicalFeature.PopulateControl()
        End If
    End Sub
End Class
