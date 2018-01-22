Public Class ucrStationSelector
    Private bFirstLoad As Boolean = True
    Private strTypeStations As String = "stationName"
    Private strTypeIDs As String = "stationId"
    Private strTypeIDsAndStations As String = "stations_ids"
    Private dtbStations As New DataTable

    Private Sub PopulateStationList()
        If dtbStations IsNot Nothing Then
            cboValues.DataSource = dtbStations.DefaultView.ToTable()
            ' May need ValueMember to be different in different instances e.g. if station name is needed as return value
            cboValues.ValueMember = strTypeIDs
            If bFirstLoad Then
                SetViewTypeAsStations()
            End If
        End If
    End Sub

    Private Sub SetViewType(strViewType As String)
        'tsmStationNames.Checked = False
        'tsmIDs.Checked = False
        'tsmIDsAndStations.Checked = False
        'Select Case strViewType
        '    Case strTypeStations
        '        tsmStationNames.Checked = True
        '        cboValues.DisplayMember = strTypeStations
        '    Case strTypeIDs
        '        tsmIDs.Checked = True
        '        cboValues.DisplayMember = strTypeIDs
        '    Case strTypeIDsAndStations
        '        tsmIDsAndStations.Checked = True
        '        cboValues.DisplayMember = strTypeIDsAndStations
        'End Select
    End Sub

    Public Sub SetViewTypeAsStations()
        SetViewType(strTypeStations)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetViewType(strTypeIDs)
    End Sub

    Public Sub SetViewTypeAsStationsAndIDs()
        SetViewType(strTypeIDsAndStations)
    End Sub

    Private Sub ucrStationSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseStationDataTable()
            'SortByStationName()
            PopulateStationList()
            bFirstLoad = False
        End If
    End Sub

    Private Sub InitialiseStationDataTable()
        Dim dataAdapter As New MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds As New DataSet
        Dim item As New ListViewItem
        Dim sql As String

        Try
            sql = "SELECT * FROM station;"
            dataAdapter = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, frmLogin.txtusrpwd.Text)
            dataAdapter.Fill(ds, "station")
            dtbStations = ds.Tables("station")
            dtbStations.Columns.Add(strTypeIDsAndStations, GetType(String))
            For i = 0 To dtbStations.Rows.Count - 1
                dtbStations.Rows(i).Item(strTypeIDsAndStations) = dtbStations.Rows(i).Item(strTypeIDs) & " " & dtbStations.Rows(i).Item(strTypeStations)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            dtbStations = Nothing
        End Try
    End Sub

    Private Sub tsmStations_Click(sender As Object, e As EventArgs)
        SetViewTypeAsStations()
    End Sub

    Private Sub tsmIDs_Click(sender As Object, e As EventArgs)
        SetViewTypeAsIDs()
    End Sub

    Private Sub tsmStationsAndIDs_Click(sender As Object, e As EventArgs)
        SetViewTypeAsStationsAndIDs()
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