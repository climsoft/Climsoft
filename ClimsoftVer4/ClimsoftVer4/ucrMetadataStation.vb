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

            AddKeyField(ucrStationIDcombobox.FieldName)

            'set up the navigation control
            ucrNavigationStation.SetTableEntry(Me)
            ucrNavigationStation.AddKeyControls(ucrStationIDcombobox)

            bFirstLoad = False

            'populate the values
            ucrNavigationStation.PopulateControl()

        End If

    End Sub

    Private Sub cmdUpdateStation_Click(sender As Object, e As EventArgs) Handles cmdUpdateStation.Click
        UpdateRecord()
    End Sub

    Private Sub cmdDeleteInstrumentStation_Click(sender As Object, e As EventArgs) Handles cmdDeleteStation.Click
        DeleteRecord()
    End Sub
End Class
