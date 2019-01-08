Public Class ucrDataLinkCombobox
    Protected bFirstLoad As Boolean = True
    Public bFillFromDataBase As Boolean = True
    Public bValidate As Boolean = True
    Public bValidateSilently As Boolean = True
    Public bValidateEmpty As Boolean = False
    Private objDefaultValue As Object = Nothing
    Private bValidColor As Color = Color.White

    Public Overrides Sub PopulateControl()
        If bFillFromDataBase Then
            MyBase.PopulateControl()
        End If
        cboValues.DataSource = dtbRecords
    End Sub

    Public Sub SetPossibleValues(dtbNewRecords As DataTable)
        dtbRecords = dtbNewRecords
        bFillFromDataBase = False
    End Sub

    Public Sub SetPossibleValues(strColumnName As String, tColumnType As Type, lstValues As IEnumerable(Of Object))
        SetPossibleValues(New DataTable)
        dtbRecords.Columns.Add(strColumnName, tColumnType)
        For Each objVal In lstValues
            dtbRecords.Rows.Add(objVal)
        Next
        PopulateControl()
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'TODO
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim strCol As String
        Dim bValueFound As Boolean = False
        'MyBase.SetValue(objNewValue)
        strCol = cboValues.ValueMember
        If IsDBNull(objNewValue) OrElse String.IsNullOrEmpty(objNewValue) Then
            cboValues.Text = ""
        Else
            For Each rTemp As DataRow In dtbRecords.Rows
                'Calling ToString to prevent invalid casting
                If rTemp.Item(strCol).ToString = objNewValue.ToString Then
                    'set the text using the display column
                    cboValues.Text = rTemp.Item(cboValues.DisplayMember)
                    'cboValues.SelectedValue = objNewValue
                    bValueFound = True
                    Exit For
                End If
            Next

            If Not bValueFound Then
                cboValues.Text = objNewValue
            End If

        End If


        OnevtValueChanged(Me, Nothing)
    End Sub

    ''' <summary>
    ''' Gets the set or selected value of the combobox. if strFieldName is not empty the value of the passed field will be returned
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <returns></returns>
    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        Dim strCol As String
        strCol = cboValues.DisplayMember
        For Each rTemp As DataRow In dtbRecords.Rows
            If rTemp.Item(strCol).ToString = cboValues.Text Then
                If strFieldName = "" Then
                    'Return cboValues.SelectedValue
                    'get the value from the value column
                    Return rTemp.Item(cboValues.ValueMember)
                Else
                    Return rTemp.Item(strFieldName)
                End If
            End If
        Next
        Return cboValues.Text
    End Function

    Public Sub setDefaultValue(objNewValue As Object)
        objDefaultValue = objNewValue
    End Sub

    Public Sub SelectDefault()
        If objDefaultValue IsNot Nothing AndAlso dtbRecords IsNot Nothing AndAlso dtbRecords.Rows.Count > 0 Then
            SetValue(objDefaultValue)
        Else
            SelectFirst()
        End If
    End Sub

    Public Sub SelectFirst()
        If dtbRecords IsNot Nothing AndAlso dtbRecords.Rows.Count > 0 Then
            SetValue(dtbRecords.Rows.Item(0).Item(cboValues.ValueMember))
        End If
    End Sub

    Public Sub SelectLast()
        If dtbRecords IsNot Nothing AndAlso dtbRecords.Rows.Count > 0 Then
            SetValue(dtbRecords.Rows.Item(dtbRecords.Rows.Count - 1).Item(cboValues.ValueMember))
        End If
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean = False
        Dim strCol As String = cboValues.DisplayMember
        For Each rTemp As DataRow In dtbRecords.Rows
            If rTemp.Item(strCol).ToString = cboValues.Text Then
                bValid = True
                Exit For
            End If
        Next
        SetBackColor(If(bValid, Color.White, Color.Red))
        Return bValid
    End Function

    ''' <summary>
    ''' Sets the back colour of the control
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Sub SetBackColor(backColor As Color)
        cboValues.BackColor = backColor
    End Sub

    ''' <summary>
    ''' Sets the default back color for when this control has a valid value
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Sub SetValidColor(backColor As Color)
        bValidColor = backColor
    End Sub

    Public Sub SetDisplayMember(strDisplay As String)
        If dtbRecords.Columns.Contains(strDisplay) Then
            cboValues.DisplayMember = strDisplay
        End If
    End Sub

    Public Sub SetValueMember(strValue As String)
        If dtbRecords.Columns.Contains(strValue) Then
            cboValues.ValueMember = strValue
        End If
    End Sub

    Public Sub SetDisplayAndValueMember(strDisplay As String, strValue As String)
        SetDisplayMember(strDisplay)
        SetValueMember(strValue)
    End Sub

    Public Sub SetDisplayAndValueMember(strDisplayAndValue As String)
        SetDisplayAndValueMember(strDisplayAndValue, strDisplayAndValue)
    End Sub

    ''' <summary>
    ''' Sorts the datatable in ascending order based on the c
    ''' column specified as the parameter. This in turn sorts
    ''' the combobox values
    ''' </summary>
    ''' <param name="strCol"></param>
    Public Sub SortBy(strCol As String)
        If dtbRecords IsNot Nothing Then
            'Datatable Sorting affects cboValues.SelectedValue
            'thus SuppressChange And retain previous cboValues.SelectedValue 
            Dim prevSelected = GetValue()
            bSuppressChangedEvents = True
            dtbRecords.DefaultView.Sort = strCol & " ASC"
            SetValue(prevSelected)
            bSuppressChangedEvents = False
        End If
    End Sub

    Protected Sub SetComboBoxSelectorProperties(Optional comboBoxStyle As ComboBoxStyle = ComboBoxStyle.DropDown, Optional autoCompletSource As AutoCompleteSource = AutoCompleteSource.ListItems, Optional autoCompleteMode As AutoCompleteMode = AutoCompleteMode.SuggestAppend)
        cboValues.DropDownStyle = comboBoxStyle
        cboValues.AutoCompleteSource = autoCompletSource
        cboValues.AutoCompleteMode = autoCompleteMode
    End Sub

    Protected Overridable Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

    Private Sub cboValues_KeyDown(sender As Object, e As KeyEventArgs) Handles cboValues.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub cboValues_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboValues.SelectedValueChanged
        OnevtValueChanged(Me, e)
    End Sub

    Private Sub cboValues_TextChanged(sender As Object, e As EventArgs) Handles cboValues.TextChanged
        OnevtTextChanged(Me, e)
    End Sub

    Private Sub cboValues_Leave(sender As Object, e As EventArgs) Handles cboValues.Leave
        'check if value is valid
        If bValidate Then
            ValidateValue()
        End If
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub Clear()
        bValidate = False
        SetValue("")
        SetBackColor(bValidColor)
        bValidate = True
    End Sub

End Class
