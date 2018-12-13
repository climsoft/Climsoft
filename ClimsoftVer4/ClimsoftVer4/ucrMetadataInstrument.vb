Public Class ucrMetadataInstrument

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("instrument")

            AddLinkedControlFilters(ucrDataLinkInstrumentID, ucrDataLinkInstrumentID.GetField(), "=", strLinkedFieldName:=ucrDataLinkInstrumentID.GetField(), bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationInstrument.SetTableEntry(Me)
            ucrNavigationInstrument.AddKeyControls(ucrDataLinkInstrumentID)

            bFirstLoad = False

            'populate the values
            ucrNavigationInstrument.PopulateControl()

        End If
    End Sub
End Class
