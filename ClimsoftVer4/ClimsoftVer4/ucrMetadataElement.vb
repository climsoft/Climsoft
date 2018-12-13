Public Class ucrMetadataElement

    Private Sub ucrMetadataElement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("obselement")

            AddLinkedControlFilters(ucrDataLinkID, ucrDataLinkID.FieldName(), "=", strLinkedFieldName:=ucrDataLinkID.FieldName(), bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationElement.SetTableEntry(Me)
            ucrNavigationElement.AddKeyControls(ucrDataLinkID)

            bFirstLoad = False

            'populate the values
            ucrNavigationElement.PopulateControl()

        End If
    End Sub
End Class
