Public Class ucrFormDaily2

    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_daily2"
    Private strValueFieldName As String
    Private strFlagFieldName As String
    Private strPeriodFieldName As String

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        ' Example of defining a filter for the data call
        'clsDataDefinition.SetFilter(strStationID, "==", Chr(34) & "67774010" & Chr(34))

        If dtbRecords.Rows.Count > 0 Then
            ' May need ValueMember to be different in different instances e.g. if station name is needed as return value
            '.ValueMember = strStationID
            If bFirstLoad Then
                'SetViewTypeAsStations()
                SetTableName(strTableName)
                'For Each ctrtemp As ucrValueFlagPeriod In ucrFormDaily2
                '    ctrtemp.SetValueFlagPeriodFields(strValueFieldName, strFlagFieldName, strPeriodFieldName)
                'Next
            End If
        Else
            'cboValues.DataSource = Nothing
        End If
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim d As New Dictionary(Of String, List(Of String))
        If bFirstLoad Then
            'InitialiseStationDataTable()
            'SortByStationName()
            'SetTableName(strStationsTableName)
            'd.Add(strStationName, New List(Of String)({strStationName}))
            'd.Add(strStationID, New List(Of String)({strStationID}))
            'd.Add(strIDsAndStations, New List(Of String)({strStationName, strStationID}))
            SetFields(d)
            PopulateControl()
            ' cboValues.ContextMenuStrip = cmsStation
            bFirstLoad = False
        End If
    End Sub
End Class
