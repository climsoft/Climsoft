Public Class ucrElementSelector
    Private strElementTableName As String = "obselement"
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
                SetViewTypeAsIDsAndElements()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        'validate by display member 
        Dim bValid As Boolean = MyBase.ValidateValue()
        'if not valid, validate by value member
        If Not bValid Then
            If Not String.IsNullOrEmpty(cboValues.ValueMember) Then
                For Each rTemp As DataRow In dtbRecords.Rows
                    If rTemp.Item(cboValues.ValueMember).ToString = cboValues.Text Then
                        bValid = True
                        Exit For
                    End If
                Next
            End If

            SetBackColor(If(bValid, clValidColor, clInValidColor))
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
        If clsDataConnection.IsInDesignMode() Then
            Exit Sub ' temporary code to remove the bugs thrown during design time
        End If

        Dim dct As New Dictionary(Of String, List(Of String))
        If bFirstLoad Then

            cboValues.ContextMenuStrip = cmsElement
            SetComboBoxSelectorProperties()
            bValidateEmpty = True
            strValidationType = "exists"

            dct.Add(strElementName, New List(Of String)({strElementName}))
            dct.Add(strElementId, New List(Of String)({strElementId}))
            dct.Add(strIDsAndElements, New List(Of String)({strElementId, strElementName}))
            SetTableNameAndFields(strElementTableName, dct)
            SetFilter("selected", "=", "1", bIsPositiveCondition:=True)
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

    Private Sub cboValues_Leave(sender As Object, e As EventArgs) Handles cboValues.Leave
        If ValidateValue() Then
            Dim bChangedEvents As Boolean = Me.bSuppressChangedEvents
            bSuppressChangedEvents = True
            SetValue(cboValues.Text)
            bSuppressChangedEvents = bChangedEvents
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
