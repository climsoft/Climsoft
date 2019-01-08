Public Class ucrMetadataElement

    Private Sub ucrMetadataElement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("obselement")

            ucrDataLinkID.SetTableNameAndField("obselement", "elementId")
            ucrDataLinkID.PopulateControl()
            ucrDataLinkID.SetDisplayAndValueMember("elementId")
            ucrDataLinkID.bValidate = False

            AddLinkedControlFilters(ucrDataLinkID, ucrDataLinkID.FieldName(), "=", strLinkedFieldName:=ucrDataLinkID.FieldName(), bForceValuesAsString:=True)

            AddKeyField(ucrDataLinkID.FieldName)

            'set up the navigation control
            ucrNavigationElement.SetTableEntry(Me)
            ucrNavigationElement.AddKeyControls(ucrDataLinkID)

            bFirstLoad = False

            'populate the values
            ucrNavigationElement.PopulateControl()

        End If
    End Sub

    Private Sub cmdUpdateElement_Click(sender As Object, e As EventArgs) Handles cmdUpdateElement.Click
        UpdateRecord()
    End Sub

    Private Sub cmdDeleteElement_Click(sender As Object, e As EventArgs) Handles cmdDeleteElement.Click
        DeleteRecord()
    End Sub
End Class
