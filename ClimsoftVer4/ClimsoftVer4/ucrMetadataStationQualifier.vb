Public Class ucrMetadataStationQualifier
    Private strqualifier As String = "qualifier"

    Protected Overrides Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "stationqualifier"

            'ucrTableEntry_Load fills in the lstFields
            MyBase.ucrTableEntry_Load(sender, e)

            AddLinkedControlFilters(ucrTextBoxQualifier, strqualifier, "=", strLinkedFieldName:=strqualifier, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationQualifier.SetTableNameAndFields(strTableName, (New List(Of String)({strqualifier})))
            ucrNavigationStationQualifier.SetKeyControls(strqualifier, ucrTextBoxQualifier)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationQualifier.PopulateControl()
        End If
    End Sub
End Class
