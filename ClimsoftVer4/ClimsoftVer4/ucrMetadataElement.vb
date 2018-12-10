Public Class ucrMetadataElement
    Private strelementId As String = "elementid"

    Protected Overrides Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "obselement"

            'ucrTableEntry_Load fills in the lstFields
            MyBase.ucrTableEntry_Load(sender, e)

            AddLinkedControlFilters(ucrDataLinkID, strelementId, "=", strLinkedFieldName:=strelementId, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationElement.SetTableNameAndFields(strTableName, (New List(Of String)({strelementId})))
            ucrNavigationElement.SetKeyControls(strelementId, ucrDataLinkID)

            bFirstLoad = False

            'populate the values
            ucrNavigationElement.PopulateControl()
        End If
    End Sub
End Class
