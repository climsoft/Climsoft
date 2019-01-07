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


            'set filter control used in the where clause of the select statement
            AddLinkedControlFilters(ucrDataLinkInstrumentID, ucrDataLinkInstrumentID.FieldName, "=", strLinkedFieldName:=ucrDataLinkInstrumentID.FieldName, bForceValuesAsString:=True)

            'set filter field name used in the where clause of update and delete statement
            AddKeyField(ucrDataLinkInstrumentID.FieldName)

            'set up the navigation control
            ucrNavigationInstrument.SetTableEntry(Me) 'bind the tableEntry control
            ucrNavigationInstrument.AddKeyControls(ucrDataLinkInstrumentID) 'bind (Biderectional) the key control

            bFirstLoad = False

            'populate the values
            ucrNavigationInstrument.PopulateControl()

        End If
    End Sub
End Class
