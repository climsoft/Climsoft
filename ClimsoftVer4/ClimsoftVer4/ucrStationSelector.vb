﻿Public Class ucrStationSelector
    Private strStationsTableName As String = "stations"
    Private strStationName As String = "stationName"
    Private strStationId As String = "stationId"
    Private strIDsAndStations As String = "ids_stations"

    Public Overrides Sub PopulateControl()
        'Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        'Dim myConnectionString As String
        'Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
        'Dim ds As New DataSet
        'Dim sql As String

        'myConnectionString = frmLogin.txtusrpwd.Text
        'conn.ConnectionString = myConnectionString
        'conn.Open()

        ''MsgBox("Connection Successful !", MsgBoxStyle.Information)

        'sql = "SELECT stationId,stationName FROM station ORDER by stationName;"
        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        'da.Fill(ds, "station")

        'If ds.Tables("station").Rows.Count > 0 Then
        '    'Populate station combobox
        '    With cboValues
        '        .DataSource = ds.Tables("station")
        '        .DisplayMember = "stationName"
        '        .ValueMember = "stationId"
        '        .SelectedIndex = 0
        '    End With
        'Else
        '    MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
        'End If
        'conn.Close()

        bSuppressChangedEvents = True
        MyBase.PopulateControl()
        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = strStationId

            'TODO 
            'what if there were no records on the first load.Then there are records later
            If bFirstLoad Then
                SetViewTypeAsStations()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean = False
        bValid = MyBase.ValidateValue()

        If Not bValid Then
            Dim strCol As String = cboValues.ValueMember
            For Each rTemp As DataRow In dtbRecords.Rows
                If rTemp.Item(strCol).ToString = cboValues.Text Then
                    bValid = True
                    Exit For
                End If
            Next
        End If

        SetBackColor(If(bValid, Color.White, Color.Red))
        Return bValid
    End Function

    Public Sub SetViewTypeAsStations()
        SetDisplayMember(strStationName)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetDisplayMember(strStationId)
    End Sub

    Public Sub SetViewTypeAsIDsAndStations()
        SetDisplayMember(strIDsAndStations)
    End Sub

    Public Sub SortByID()
        SortBy(strStationId)
        cmsStationSortByID.Checked = True
        cmsStationSortyByName.Checked = False
    End Sub

    Public Sub SortByStationName()
        SortBy(strStationName)
        cmsStationSortByID.Checked = False
        cmsStationSortyByName.Checked = True
    End Sub

    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dct As Dictionary(Of String, List(Of String))
        If bFirstLoad Then
            'SortByStationName()
            dct = New Dictionary(Of String, List(Of String))
            dct.Add(strStationId, New List(Of String)({strStationId}))
            dct.Add(strStationName, New List(Of String)({strStationName}))
            dct.Add(strIDsAndStations, New List(Of String)({strStationId, strStationName}))
            SetTableNameAndFields(strStationsTableName, dct)
            PopulateControl()
            cboValues.ContextMenuStrip = cmsStation
            SetComboBoxSelectorProperties()
            bFirstLoad = False
        End If
    End Sub

    Private Sub cboValues_Leave(sender As Object, e As EventArgs) Handles cboValues.Leave
        If Not cboValues.DisplayMember = strStationId Then
            If IsNumeric(cboValues.Text) Then
                If ValidateValue() Then
                    Dim bChangedEvents As Boolean = Me.bSuppressChangedEvents
                    bSuppressChangedEvents = True
                    SetValue(cboValues.Text)
                    bSuppressChangedEvents = bChangedEvents
                End If
            End If
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