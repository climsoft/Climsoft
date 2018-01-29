Public Class ucrElemSelector
    Private bFirstLoad As Boolean = True
    Private strElementTableName As String = "obsElem"
    Private strElementName As String = "elementName"
    Private strelementID As String = "elementId"
    Private strIDsAndElements As String = "ids_elements"
    Private objElements As New Object
    Private dtbElements As New DataTable

    Private Sub PopulateElementList()
        ' Example of defining a filter for the data call
        'clsDataDefinition.SetFilter(strelementID, "==", Chr(34) & "67774010" & Chr(34))
        objElements = clsDataDefinition.GetDataTable()
        dtbElements = New DataTable()
        dtbElements.Columns.Add(strElementName, GetType(String))
        dtbElements.Columns.Add(strelementID, GetType(String))
        dtbElements.Columns.Add(strIDsAndElements, GetType(String))

        For Each elemItem As obselement In objElements
            dtbElements.Rows.Add(elemItem.elementName, elemItem.elementId, elemItem.elementId & " " & elemItem.elementName)
        Next
        cboValues.DataSource = dtbElements
        ' May need ValueMember to be different in different instances e.g. if station name is needed as return value
        cboValues.ValueMember = strelementID
        If bFirstLoad Then
            SetViewTypeAsElements()
        End If
    End Sub

    Private Sub SetViewType(strViewType As String)
        'tsmStationNames.Checked = False
        'tsmIDs.Checked = False
        'tsmIDsAndStations.Checked = False
        Select Case strViewType
            Case strElementName
                '        tsmStationNames.Checked = True
                cboValues.DisplayMember = strElementName
            Case strelementID
                '        tsmIDs.Checked = True
                cboValues.DisplayMember = strelementID
            Case strIDsAndElements
                '        tsmIDsAndStations.Checked = True
                cboValues.DisplayMember = strIDsAndElements
        End Select
    End Sub

    Public Sub SetViewTypeAsElements()
        SetViewType(strElementName)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetViewType(strelementID)
    End Sub

    Public Sub SetViewTypeAsIDsAndElements()
        SetViewType(strIDsAndElements)
    End Sub

    Private Sub ucrElemSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'InitialiseStationDataTable()
            'SortByStationName()
            SetTable(strElementTableName)
            SetFields(New List(Of String)({strelementID, strElementName}))
            PopulateElementList()
            bFirstLoad = False
        End If
    End Sub

    'Private Sub tsmStations_Click(sender As Object, e As EventArgs)
    '    SetViewTypeAsElements()
    'End Sub

    'Private Sub tsmIDs_Click(sender As Object, e As EventArgs)
    '    SetViewTypeAsIDs()
    'End Sub

    'Private Sub tsmStationsAndIDs_Click(sender As Object, e As EventArgs)
    '    SetViewTypeAsIDsAndElements()
    'End Sub

    Public Overrides Function ValidateSelection() As Boolean
        Return cboValues.Items.Contains(cboValues.Text)
    End Function

    'Private Sub tsmFilterStations_Click(sender As Object, e As EventArgs)
    '    'dlgFilterStations.SetDataTable(dtbElements)
    '    'dlgFilterStations.ShowDialog()
    '    'PopulateStationList()
    'End Sub
End Class