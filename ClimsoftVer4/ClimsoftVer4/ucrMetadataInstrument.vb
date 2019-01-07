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


            'set FILTER control used in the WHERE clause of the SELECT statement
            AddLinkedControlFilters(ucrDataLinkInstrumentID, ucrDataLinkInstrumentID.FieldName, "=", strLinkedFieldName:=ucrDataLinkInstrumentID.FieldName, bForceValuesAsString:=True)

            'set FILTER field name used in the WHERE clause of UPDATE and DELETE statement
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
