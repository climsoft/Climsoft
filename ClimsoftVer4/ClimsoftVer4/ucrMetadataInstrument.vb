Public Class ucrMetadataInstrument
    'Boolean to check if control is loading for first time
    Private bFirstLoad As Boolean = True
    'sets table name assocaited with this user control
    Private strTableName As String = "instrument"
    'Stores fields for the value flag and period
    Private lstFields As New List(Of String)
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True
    'stores a list containing all fields of this control
    Private lstAllFields As New List(Of String)

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'TODO. Might not be need anymore
            bUpdating = dtbRecords.Rows.Count > 0

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrBaseDataLink).SetValue(GetValue(ctr.Tag))
                End If
            Next

            'raise an event value changed event
            OnevtValueChanged(Me, Nothing)
        End If

    End Sub

    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then
            'setup the controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrTextBox Then
                    lstFields.Add(ctr.Tag)
                    AddHandler DirectCast(ctr, ucrBaseDataLink).evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            AddLinkedControlFilters(ucrDataLinkInstrumentID, "instrumentId", "=", strLinkedFieldName:="instrumentId", bForceValuesAsString:=True)

            ucrNavigationInstrument.SetTableNameAndFields(strTableName, (New List(Of String)({"instrumentId"})))
            ucrNavigationInstrument.SetKeyControls("instrumentId", ucrDataLinkInstrumentID)

            bFirstLoad = False

            'populate the values
            'PopulateControl()
            ucrNavigationInstrument.PopulateControl()
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        'TODO update the user entered value to the data table
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'populate
        'will populate the datatable based on the new key values
        MyBase.LinkedControls_evtValueChanged()

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            'TODO Replace this with a call to update the datatable
            'CallByName(fd2Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next
        ucrNavigationInstrument.UpdateNavigationByKeyControls()

    End Sub

End Class
