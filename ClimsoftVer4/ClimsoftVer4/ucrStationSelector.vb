Public Class ucrStationSelector
    Private bFirstLoad As Boolean = True
    Private strStationsTableName As String = "stations"
    Private strStationName As String = "stationName"
    Private strStationID As String = "stationId"
    Private strIDsAndStations As String = "ids_stations"
    Private objStations As New Object
    Private dtbStations As New DataTable

    Private Sub PopulateStationList()
        ' Example of defining a filter for the data call
        'clsDataDefinition.SetFilter(strStationID, "==", Chr(34) & "67774010" & Chr(34))
        objStations = clsDataDefinition.GetDataTable()
        dtbStations = New DataTable()
        dtbStations.Columns.Add(strStationName, GetType(String))
        dtbStations.Columns.Add(strStationID, GetType(String))
        dtbStations.Columns.Add(strIDsAndStations, GetType(String))

        For Each stnItem As station In objStations
            dtbStations.Rows.Add(stnItem.stationName, stnItem.stationId, stnItem.stationId & " " & stnItem.stationName)
        Next
        cboValues.DataSource = dtbStations
        ' May need ValueMember to be different in different instances e.g. if station name is needed as return value
        cboValues.ValueMember = strStationID
        If bFirstLoad Then
            SetViewTypeAsStations()
        End If
    End Sub

    Private Sub SetViewType(strViewType As String)
        'tsmStationNames.Checked = False
        'tsmIDs.Checked = False
        'tsmIDsAndStations.Checked = False
        Select Case strViewType
            Case strStationName
                '        tsmStationNames.Checked = True
                cboValues.DisplayMember = strStationName
            Case strStationID
                '        tsmIDs.Checked = True
                cboValues.DisplayMember = strStationID
            Case strIDsAndStations
                '        tsmIDsAndStations.Checked = True
                cboValues.DisplayMember = strIDsAndStations
        End Select
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

    Private Sub ucrStationSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'InitialiseStationDataTable()
            'SortByStationName()
            SetTable(strStationsTableName)
            SetFields(New List(Of String)({strStationID, strStationName}))
            PopulateStationList()
            bFirstLoad = False
        End If
    End Sub

    Private Sub tsmStations_Click(sender As Object, e As EventArgs)
        SetViewTypeAsStations()
    End Sub

    Private Sub tsmIDs_Click(sender As Object, e As EventArgs)
        SetViewTypeAsIDs()
    End Sub

    Private Sub tsmStationsAndIDs_Click(sender As Object, e As EventArgs)
        SetViewTypeAsIDsAndStations()
    End Sub

    Public Overrides Function ValidateSelection() As Boolean
        Return cboValues.Items.Contains(cboValues.Text)
    End Function

    Private Sub tsmFilterStations_Click(sender As Object, e As EventArgs)
        'dlgFilterStations.SetDataTable(dtbStations)
        'dlgFilterStations.ShowDialog()
        'PopulateStationList()
    End Sub
End Class