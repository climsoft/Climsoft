Public Class ucrMetadataStationLocationHistory
    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("stationlocationhistory")

            ucrStationSelector.SetTableNameAndField("stationlocationhistory", "belongsTo")
            ucrStationSelector.PopulateControl()
            ucrStationSelector.SetDisplayAndValueMember("belongsTo")
            ucrStationSelector.bValidate = False


            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:=ucrStationSelector.FieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationLocationHistory.SetTableEntry(Me)
            ucrNavigationStationLocationHistory.AddKeyControls(ucrStationSelector)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationLocationHistory.PopulateControl()

        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        'TODO
    End Sub


    Protected Overrides Sub LinkedControls_evtValueChanged()
        'will populate the datatable based on the new key values
        MyBase.LinkedControls_evtValueChanged()

        'TODO check whether these are needed
        'For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
        '    'TODO 

        'Next
        'ucrNavigationStationLocationHistory.UpdateNavigationByKeyControls()

    End Sub



End Class
