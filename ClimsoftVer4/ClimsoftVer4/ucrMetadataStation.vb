Public Class ucrMetadataStation
    Private Sub ucrMetadataStation_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("station")

            ucrStationIDcombobox.SetTableNameAndField("station", "stationId")
            ucrStationIDcombobox.PopulateControl()
            ucrStationIDcombobox.SetDisplayAndValueMember("stationId")
            ucrStationIDcombobox.bValidate = False

            AddLinkedControlFilters(ucrStationIDcombobox, ucrStationIDcombobox.FieldName(), "=", strLinkedFieldName:=ucrStationIDcombobox.FieldName(), bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStation.SetTableEntry(Me)
            ucrNavigationStation.AddKeyControls(ucrStationIDcombobox)

            bFirstLoad = False

            'populate the values
            ucrNavigationStation.PopulateControl()

        End If

    End Sub
End Class
