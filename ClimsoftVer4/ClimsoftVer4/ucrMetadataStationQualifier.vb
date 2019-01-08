Public Class ucrMetadataStationQualifier

    Private Sub ucrMetadataStationQualifier_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("stationqualifier")

            ucrTextBoxQualifier.SetTableNameAndField("stationqualifier", "qualifier")
            ucrTextBoxQualifier.PopulateControl()
            ucrTextBoxQualifier.SetValue("qualifier")
            ucrTextBoxQualifier.bValidate = False

            AddLinkedControlFilters(ucrTextBoxQualifier, ucrTextBoxQualifier.FieldName, "=", strLinkedFieldName:=ucrTextBoxQualifier.FieldName, bForceValuesAsString:=True)

            AddKeyField(ucrTextBoxQualifier.FieldName)

            'set up the navigation control
            ucrNavigationStationQualifier.SetTableEntry(Me)
            ucrNavigationStationQualifier.AddKeyControls(ucrTextBoxQualifier)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationQualifier.PopulateControl()

        End If
    End Sub

    Private Sub cmdUpdateStationQualifier_Click(sender As Object, e As EventArgs) Handles cmdUpdateQualifier.Click
        UpdateRecord()
    End Sub

    Private Sub cmdDeleteStationQualifier_Click(sender As Object, e As EventArgs) Handles cmdDeleteStationQualifier.Click
        DeleteRecord()
    End Sub
End Class
