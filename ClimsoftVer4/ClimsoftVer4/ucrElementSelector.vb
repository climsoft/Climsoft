Public Class ucrElementSelector
    Private bFirstLoad As Boolean = True
    Private strElementTableName As String = "obselements"
    Private strElementName As String = "elementName"
    Private strElementID As String = "elementId"
    Private strIDsAndElements As String = "ids_elements"
    Private objElements As New Object
    Private dtbElements As New DataTable

    Private Sub PopulateElementList()
        ' Example of defining a filter for the data call
        'clsDataDefinition.SetFilter(strelementID, "==", Chr(34) & "67774010" & Chr(34))
        dtbElements = clsDataDefinition.GetDataTable()
        'dtbElements = New DataTable()
        'dtbElements.Columns.Add(strElementName, GetType(String))
        'dtbElements.Columns.Add(strelementID, GetType(String))
        'dtbElements.Columns.Add(strIDsAndElements, GetType(String))

        'For Each elemItem As obselement In objElements
        '    dtbElements.Rows.Add(elemItem.elementName, elemItem.elementId, elemItem.elementId & " " & elemItem.elementName)
        'Next
        If dtbElements.Rows.Count > 0 Then
            cboValues.DataSource = dtbElements
            ' May need ValueMember to be different in different instances e.g. if station name is needed as return value
            cboValues.ValueMember = strElementID
            If bFirstLoad Then
                SetViewTypeAsElements()
            End If
        Else
            cboValues.DataSource = Nothing
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
            Case strElementID
                '        tsmIDs.Checked = True
                cboValues.DisplayMember = strElementID
            Case strIDsAndElements
                '        tsmIDsAndStations.Checked = True
                cboValues.DisplayMember = strIDsAndElements
        End Select
    End Sub

    Public Sub SetViewTypeAsElements()
        SetViewType(strElementName)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetViewType(strElementID)
    End Sub

    Public Sub SetViewTypeAsIDsAndElements()
        SetViewType(strIDsAndElements)
    End Sub

    Private Sub ucrElemSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim d As New Dictionary(Of String, List(Of String))

        If bFirstLoad Then
            'InitialiseStationDataTable()
            'SortByStationName()
            SetTable(strElementTableName)
            d.Add(strElementName, New List(Of String)({strElementName}))
            d.Add(strElementID, New List(Of String)({strElementID}))
            d.Add(strIDsAndElements, New List(Of String)({strElementID, strElementName}))
            SetFields(d)
            PopulateElementList()
            cboValues.ContextMenuStrip = cmsElement
            bFirstLoad = False
        End If
    End Sub

    Private Sub cmsElementsNames_Click(sender As Object, e As EventArgs) Handles cmsElementsNames.Click
        SetViewTypeAsElements()
    End Sub

    Private Sub cmsElementIDs_Click(sender As Object, e As EventArgs) Handles cmsElementIDs.Click
        SetViewTypeAsIDs()
    End Sub

    Private Sub cmsElemntIDName_Click(sender As Object, e As EventArgs) Handles cmsElemntIDName.Click
        SetViewTypeAsIDsAndElements()
    End Sub

    Public Overrides Function ValidateSelection() As Boolean
        Return cboValues.Items.Contains(cboValues.Text)
    End Function

    Private Sub tsmSortByID_Click(sender As Object, e As EventArgs) Handles cmsElementSortByID.Click
        SortByID()
    End Sub

    Private Sub SortByID()
        If dtbElements IsNot Nothing Then
            dtbElements.DefaultView.Sort = strElementID & " ASC"
            cmsElementSortByID.Checked = True
            cmsElementSortyByName.Checked = False
            PopulateElementList()
        End If
    End Sub

    Private Sub cmsElementSortyByName_Click(sender As Object, e As EventArgs) Handles cmsElementSortyByName.Click
        SortByElementName()
    End Sub

    Private Sub SortByElementName()
        dtbElements.DefaultView.Sort = strElementName & " ASC"
        cmsElementSortByID.Checked = False
        cmsElementSortyByName.Checked = True
        PopulateElementList()
    End Sub

    Private Sub tsmFilterStations_Click(sender As Object, e As EventArgs) Handles cmsElementsFilter.Click
        ' TODOD SetDataTable() in sdgFilter needs to be created
        'sdgFilter.SetDataTable(dtbElements)
        sdgFilter.ShowDialog()
        PopulateElementList()
    End Sub
End Class

