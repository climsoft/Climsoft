Public Class ucrElementSelector
    Private strElementTableName As String = "obselements"
    Private strElementName As String = "elementName"
    Private strElementId As String = "elementId"
    Private strIDsAndElements As String = "ids_elements"

    Public Overrides Sub PopulateControl()
        bSuppressChangedEvents = True
        MyBase.PopulateControl()
        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = strElementId
            'TODO 
            'what if there were no records on the first load. 
            'Then there are records later
            If bFirstLoad Then
                SetViewTypeAsElements()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean
        bValid = MyBase.ValidateValue()

        If Not bValid Then
            Dim strCol As String
            strCol = cboValues.ValueMember
            For Each rTemp As DataRow In dtbRecords.Rows
                If rTemp.Item(strCol).ToString = cboValues.Text Then
                    bValid = True
                    Exit For
                End If
            Next
            SetBackColor(If(bValid, Color.White, Color.Red))
        End If

        Return bValid
    End Function

    Public Sub SetViewTypeAsElements()
        SetDisplayMember(strElementName)
    End Sub

    Public Sub SetViewTypeAsIDs()
        SetDisplayMember(strElementId)
    End Sub

    Public Sub SetViewTypeAsIDsAndElements()
        SetDisplayMember(strIDsAndElements)
    End Sub

    Private Sub SortByID()
        SortBy(strElementId)
        cmsElementSortByID.Checked = True
        cmsElementSortyByName.Checked = False
    End Sub

    Private Sub SortByElementName()
        SortBy(strElementName)
        cmsElementSortByID.Checked = False
        cmsElementSortyByName.Checked = True
    End Sub

    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dct As New Dictionary(Of String, List(Of String))
        If bFirstLoad Then
            'SortByStationName()
            SetTableName(strElementTableName)
            dct.Add(strElementName, New List(Of String)({strElementName}))
            dct.Add(strElementId, New List(Of String)({strElementId}))
            dct.Add(strIDsAndElements, New List(Of String)({strElementId, strElementName}))
            SetFields(dct)
            PopulateControl()
            cboValues.ContextMenuStrip = cmsElement
            SetComboBoxSelectorProperties()
            bFirstLoad = False
        End If
    End Sub

    Private Sub cboValues_Leave(sender As Object, e As EventArgs) Handles cboValues.Leave
        If Not cboValues.DisplayMember = strElementId Then
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

    Private Sub cmsElementsNames_Click(sender As Object, e As EventArgs) Handles cmsElementsNames.Click
        SetViewTypeAsElements()
    End Sub

    Private Sub cmsElementIDs_Click(sender As Object, e As EventArgs) Handles cmsElementIDs.Click
        SetViewTypeAsIDs()
    End Sub

    Private Sub cmsElemntIDName_Click(sender As Object, e As EventArgs) Handles cmsElemntIDName.Click
        SetViewTypeAsIDsAndElements()
    End Sub

    Private Sub tsmSortByID_Click(sender As Object, e As EventArgs) Handles cmsElementSortByID.Click
        SortByID()
    End Sub

    Private Sub cmsElementSortyByName_Click(sender As Object, e As EventArgs) Handles cmsElementSortyByName.Click
        SortByElementName()
    End Sub

    Private Sub cmsElementsFilter_Click(sender As Object, e As EventArgs) Handles cmsElementsFilter.Click
        ' TODOD SetDataTable() in sdgFilter needs to be created
        'sdgFilter.SetDataTable(dtbElements)
        sdgFilter.ShowDialog()
        PopulateControl()
    End Sub
End Class

