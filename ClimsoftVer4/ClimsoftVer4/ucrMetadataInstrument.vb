Public Class ucrMetadataInstrument
    Private strInstrumentFieldName As String = "instrumentId"

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "instrument"

            'SetUpTableEntry 
            SetUpTableEntry()

            AddLinkedControlFilters(ucrDataLinkInstrumentID, strInstrumentFieldName, "=", strLinkedFieldName:=strInstrumentFieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationInstrument.SetTableNameAndFields(strTableName, (New List(Of String)({strInstrumentFieldName})))
            ucrNavigationInstrument.SetKeyControls(strInstrumentFieldName, ucrDataLinkInstrumentID)

            bFirstLoad = False

            'populate the values
            ucrNavigationInstrument.PopulateControl()
        End If
    End Sub


    Protected Overrides Sub LinkedControls_evtValueChanged()
        'will populate the datatable based on the new key values
        MyBase.LinkedControls_evtValueChanged()

        For Each kvpTemp As KeyValuePair(Of ucrValueView, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            'TODO 

        Next
        ucrNavigationInstrument.UpdateNavigationByKeyControls()

    End Sub

End Class
