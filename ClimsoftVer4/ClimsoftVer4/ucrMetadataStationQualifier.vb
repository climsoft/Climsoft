Public Class ucrMetadataStationQualifier

    Private Sub ucrMetadataStationQualifier_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("stationqualifier")

            ucrTextBoxQualifier.SetTableNameAndField("stationqualifier", "qualifier")
            ucrTextBoxQualifier.PopulateControl()
            ucrTextBoxQualifier.SetValue("qualifier")
            ucrTextBoxQualifier.bValidate = False

            AddLinkedControlFilters(ucrTextBoxQualifier, ucrTextBoxQualifier.FieldName, "=", strLinkedFieldName:=ucrTextBoxQualifier.FieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationQualifier.SetTableEntry(Me)
            ucrNavigationStationQualifier.AddKeyControls(ucrTextBoxQualifier)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationQualifier.PopulateControl()

        End If
    End Sub
End Class
