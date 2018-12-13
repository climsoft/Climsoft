Public Class ucrMetadataInstrument

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("instrument")

            ucrDataLinkInstrumentID.SetTableNameAndField("instrument", "instrumentId")
            ucrDataLinkInstrumentID.PopulateControl()
            ucrDataLinkInstrumentID.SetDisplayAndValueMember("instrumentId")
            ucrDataLinkInstrumentID.bValidate = False


            AddLinkedControlFilters(ucrDataLinkInstrumentID, ucrDataLinkInstrumentID.FieldName, "=", strLinkedFieldName:=ucrDataLinkInstrumentID.FieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationInstrument.SetTableEntry(Me)
            ucrNavigationInstrument.AddKeyControls(ucrDataLinkInstrumentID)

            bFirstLoad = False

            'populate the values
            ucrNavigationInstrument.PopulateControl()

        End If
    End Sub
End Class
