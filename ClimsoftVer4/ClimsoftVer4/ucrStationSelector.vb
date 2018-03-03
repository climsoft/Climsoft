Public Class ucrStationSelector
    Private strStationsTableName As String = "stations"
    Private strStationName As String = "stationName"
    Private strStationID As String = "stationId"
    Private strIDsAndStations As String = "ids_stations"

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        ' Example of defining a filter for the data call
        'clsDataDefinition.SetFilter(strStationID, "==", Chr(34) & "67774010" & Chr(34))

        If dtbRecords.Rows.Count > 0 Then
            'May need ValueMember to be different in different instances e.g. if station name is needed as return value
            'Done. It is now possible to pass the field name into get value. This comment can now be deleted
            cboValues.ValueMember = strStationID
            'TODO 
            'what if there were no records on the first load. 
            'Then there are records later
            If bFirstLoad Then
                SetViewTypeAsStations()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
    End Sub

    Public Sub SetViewTypeAsStations()
        SetViewType(strStationName)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetViewType(strStationID)
    End Sub

    Public Sub SetViewTypeAsIDsAndStations()
        SetViewType(strIDsAndStations)
    End Sub

    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            Dim dct As New Dictionary(Of String, List(Of String))
            'InitialiseStationDataTable()
            'SortByStationName()
            dct.Add(strStationName, New List(Of String)({strStationName}))
            dct.Add(strStationID, New List(Of String)({strStationID}))
            dct.Add(strIDsAndStations, New List(Of String)({strStationName, strStationID}))
            SetTableNameAndFields(strStationsTableName, dct)
            PopulateControl()
            cboValues.ContextMenuStrip = cmsStation
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Return cboValues.Items.Contains(cboValues.Text)
    End Function

    Public Sub SortByID()
        If dtbRecords IsNot Nothing Then
            'Datatable Sorting affects cboValues.SelectedValue
            'thus SuppressChange And retain previous cboValues.SelectedValue 
            Dim prevSelected = GetValue()
            bSuppressChangedEvents = True
            dtbRecords.DefaultView.Sort = strStationID & " ASC"
            cmsStationSortByID.Checked = True
            cmsStationSortyByName.Checked = False
            'PopulateControl()
            SetValue(prevSelected)
            bSuppressChangedEvents = False
        End If
    End Sub

    Public Sub SortByStationName()
        If dtbRecords IsNot Nothing Then
            'Datatable Sorting affects cboValues.SelectedValue
            'thus SuppressChange And retain previous cboValues.SelectedValue 
            Dim prevSelected = GetValue()
            bSuppressChangedEvents = True
            dtbRecords.DefaultView.Sort = strStationName & " ASC"
            cmsStationSortByID.Checked = False
            cmsStationSortyByName.Checked = True
            'PopulateControl()
            SetValue(prevSelected)
            bSuppressChangedEvents = False
        End If
    End Sub

    Private Sub cmsStationName_Click(sender As Object, e As EventArgs) Handles cmsStationNames.Click
        SetViewTypeAsStations()
    End Sub

    Private Sub cmsStationIDs_Click(sender As Object, e As EventArgs) Handles cmsStationIDs.Click
        SetViewTypeAsIDs()
    End Sub

    Private Sub cmsStationIDAndStation_Click(sender As Object, e As EventArgs) Handles cmsStationIDAndStation.Click
        SetViewTypeAsIDsAndStations()
    End Sub

    Private Sub cmsStationSortByID_Click(sender As Object, e As EventArgs) Handles cmsStationSortByID.Click
        SortByID()
    End Sub

    Private Sub cmsStationSortyByName_Click(sender As Object, e As EventArgs) Handles cmsStationSortyByName.Click
        SortByStationName()
    End Sub

    Private Sub cmsFilterStations_Click(sender As Object, e As EventArgs) Handles cmsFilterStations.Click
        ' TODOD SetDataTable() in sdgFilter needs to be created
        'sdgFilter.SetDataTable(dtbStations)
        sdgFilter.ShowDialog()
        PopulateControl()
    End Sub
End Class