Public Class ucrMetadataStationLocationHistory
    Private strbelongsTo As String = "belongsTo"

    Protected Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then


            'setUpTableEntry_Load fills in the lstFields
            SetUpTableEntry("stationlocationhistory")

            AddLinkedControlFilters(, strbelongsTo, "=", strLinkedFieldName:=strbelongsTo, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationLocationHistory.SetTableEntry(Me)
            ucrNavigationStationLocationHistory.AddKeyControls(ucrDataLinkCombobox)

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

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            'TODO 

        Next
        ucrNavigationStationLocationHistory.UpdateNavigationByKeyControls()

    End Sub



End Class
