Public Class ucrMetadataStationLocationHistory
    'Boolean to check if control is loading for first time
    Private bFirstLoad As Boolean = True
    'sets table name assocaited with this user control
    Private strTableName As String = "stationlocationhistory"
    'Stores fields for the value flag and period
    Private lstFields As New List(Of String)
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True

    Private Sub ucrMetadataStationLocationHistory_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            'Set up the control fields
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrTextBox OrElse TypeOf ctr Is ucrDatePicker Then
                    lstFields.Add(ctr.Tag)
                    AddHandler DirectCast(ctr, ucrBaseDataLink).evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next

            SetTableNameAndFields(strTableName, lstFields)

            AddLinkedControlFilters(ucrStationSelector, "belongsTo", "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationStationLocationHistory.SetTableNameAndFields(strTableName, (New List(Of String)({"belongsTo"})))
            ucrNavigationStationLocationHistory.SetKeyControls("belongsTo", ucrStationSelector)

            bFirstLoad = False

            'populate the values
            ucrNavigationStationLocationHistory.PopulateControl()

            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'TODO. Might not be need anymore
            bUpdating = dtbRecords.Rows.Count > 0

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrTextBox OrElse TypeOf ctr Is ucrDatePicker Then
                    DirectCast(ctr, ucrBaseDataLink).SetValue(GetValue(ctr.Tag))
                End If
            Next

            'raise an event value changed event
            OnevtValueChanged(Me, Nothing)
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
