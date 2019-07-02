Public Class ucrDataLinkCombobox
    Protected bFirstLoad As Boolean = True
    Public bFillFromDataBase As Boolean = True
    Private objDefaultValue As Object = Nothing

    Protected dcmMinimum As Decimal = Decimal.MinValue
    Protected dcmMaximum As Decimal = Decimal.MaxValue
    Protected bMinimumIncluded, bMaximumIncluded As Boolean

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
        Dim strNewValueToSet As String = ""
        Dim bValueFound As Boolean = False


        If IsDBNull(objNewValue) OrElse String.IsNullOrEmpty(objNewValue) Then
            strNewValueToSet = ""
        Else
            For Each rTemp As DataRow In dtbRecords.Rows
                'Calling ToString to prevent invalid casting
                If rTemp.Item(cboValues.ValueMember).ToString = objNewValue.ToString Then
                    'set the text using the display column
                    'cboValues.Text = rTemp.Item(cboValues.DisplayMember)
                    strNewValueToSet =  rTemp.Item(cboValues.DisplayMember)
                    'cboValues.SelectedValue = objNewValue
                    bValueFound = True
                    Exit For
                End If
            Next

            If Not bValueFound Then
                'cboValues.Text = objNewValue
                strNewValueToSet = objNewValue
            End If

        End If

        If cboValues.Text <> strNewValueToSet Then
            cboValues.Text = strNewValueToSet
            OnevtValueChanged(Me, Nothing)
        End If

    End Sub

    ''' <summary>
    ''' Gets the set or selected value of the combobox. if strFieldName is not empty the value of the passed field will be returned
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <returns></returns>
    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        If Not String.IsNullOrEmpty(cboValues.DisplayMember) Then
            If Not String.IsNullOrEmpty(strFieldName) OrElse Not String.IsNullOrEmpty(cboValues.ValueMember) Then
                For Each rTemp As DataRow In dtbRecords.Rows
                    If rTemp.Item(cboValues.DisplayMember).ToString = cboValues.Text Then
                        If strFieldName = "" Then
                            'Return cboValues.SelectedValue
                            'get the value from the value column
                            Return rTemp.Item(cboValues.ValueMember)
                        Else
                            Return rTemp.Item(strFieldName)
                        End If
                    End If
                Next
            End If
        End If

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

    ''' <summary>
    ''' Sets the back colour of the control
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Overrides Sub SetBackColor(backColor As Color)
        cboValues.BackColor = backColor
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
        If clsDataConnection.IsInDesignMode() Then
            Exit Sub ' temporary code to remove the bugs thrown during design time
        End If

        If bFirstLoad Then
            bValidateEmpty = True
            strValidationType = "exists"
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
        ValidateValue()
        OnevtTextChanged(Me, e)
    End Sub

    Private Sub cboValues_Leave(sender As Object, e As EventArgs) Handles cboValues.Leave
        'ValidateValue()
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub Clear()
        'Dim bPrevValidate As Boolean = bValidate
        'bValidate = False
        SetValue("")
        SetBackColor(clValidColor)
        ' bValidate = bPrevValidate
    End Sub

    Public Sub SetValidationTypeAsMustExist()
        strValidationType = "exists"
    End Sub

    ''' <summary>
    ''' Sets validation of the combobox to any numeric
    ''' </summary>
    ''' <param name="dcmMin"></param>
    ''' <param name="bIncludeMin"></param>
    ''' <param name="dcmMax"></param>
    ''' <param name="bIncludeMax"></param>
    Public Sub SetValidationTypeAsNumeric(Optional dcmMin As Decimal = Decimal.MinValue, Optional bIncludeMin As Boolean = True, Optional dcmMax As Decimal = Decimal.MaxValue, Optional bIncludeMax As Boolean = True)
        strValidationType = "numeric"
        If dcmMin <> Decimal.MinValue Then
            dcmMinimum = dcmMin
            bMinimumIncluded = bIncludeMin
        End If
        If dcmMax <> Decimal.MaxValue Then
            dcmMaximum = dcmMax
            bMaximumIncluded = bIncludeMax
        End If
    End Sub

    Public Sub SetMinimumValue(dcmMin As Decimal)
        strValidationType = "numeric"
        dcmMinimum = dcmMin
        bMinimumIncluded = True
    End Sub

    Public Sub SetMaximumValue(dcmMax As Decimal)
        strValidationType = "numeric"
        dcmMaximum = dcmMax
        bMaximumIncluded = True
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean = False

        If bValidate Then
            'if set to not validate empty values and textbox is empty then don't proceed with validation
            If Not bValidateEmpty AndAlso IsEmpty() Then
                SetBackColor(clValidColor)
                Return True
            End If

            If strValidationType = "none" Then
                bValid = True
                SetBackColor(clValidColor)
            ElseIf strValidationType = "exists" Then
                bValid = False
                If cboValues.DisplayMember <> "" Then
                    For Each rTemp As DataRow In dtbRecords.Rows
                        If rTemp.Item(cboValues.DisplayMember).ToString = cboValues.Text Then
                            bValid = True
                            Exit For
                        End If
                    Next
                End If
                SetBackColor(If(bValid, clValidColor, clInValidColor))
            ElseIf strValidationType = "numeric" Then
                Dim iValidationCode As Integer = ValidateNumeric(cboValues.Text)
                Select Case iValidationCode
                    Case 0
                        bValid = True
                        SetBackColor(clValidColor)
                    Case 1
                        bValid = False
                        SetBackColor(clInValidColor)
                        If Not bValidateSilently Then
                            MessageBox.Show("Number expected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Case 2
                        bValid = False
                        'check if it was lower and upper limit violation
                        If Not (GetDcmMinimum() <= Val(cboValues.Text)) Then
                            SetBackColor(Color.Cyan)
                            If Not bValidateSilently Then
                                MessageBox.Show("Value lower than lowerlimit of: " & GetDcmMinimum(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        ElseIf Not (GetDcmMaximum() >= Val(cboValues.Text)) Then
                            SetBackColor(Color.Cyan)
                            If Not bValidateSilently Then
                                MessageBox.Show("Value higher than upperlimit of: " & GetDcmMaximum(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        End If
                End Select

            End If
        Else
            bValid = True
            SetBackColor(clValidColor)
        End If
        Return bValid
    End Function


    ''' <summary>
    ''' checks if the string passed can be a valid value for this control
    ''' </summary>
    ''' <param name="strText"></param>
    ''' <returns></returns>
    Public Function ValidateText(strText As String, Optional bValidateSilently As Boolean = True) As Boolean
        Dim bValid As Boolean = False
        Dim iValidationCode As Integer

        If bValidate Then
            'if set to not validate empty values and string is empty then don't proceed with validation
            If Not bValidateEmpty AndAlso String.IsNullOrEmpty(strText) Then
                Return True
            End If

            If strValidationType = "exists" Then
                If cboValues.DisplayMember <> "" Then
                    For Each rTemp As DataRow In dtbRecords.Rows
                        If rTemp.Item(cboValues.DisplayMember).ToString = cboValues.Text Then
                            bValid = True
                            Exit For
                        End If
                    Next
                End If
                Return False
            ElseIf strValidationType = "numeric" Then
                iValidationCode = ValidateNumeric(strText)
                Select Case iValidationCode
                    Case 1
                        If Not bValidateSilently Then
                            MessageBox.Show("Entry must be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Case 2
                        If Not bValidateSilently Then
                            MessageBox.Show("This number must be: " & GetNumericRange(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                End Select
                bValid = (iValidationCode = 0)
            End If

        Else
            bValid = True
        End If
        Return bValid
    End Function

    'Returns integer as code for validation
    ' 0 : string is valid
    ' 1 : string is not numeric
    ' 2 : string is outside range
    Private Function ValidateNumeric(strText As String) As Integer
        Dim dcmText As Decimal
        Dim iType As Integer = 0

        If strText <> "" Then
            If Not IsNumeric(strText) Then
                iType = 1
            Else
                dcmText = Convert.ToDecimal(strText)
                If (dcmText < dcmMinimum) OrElse (dcmText > dcmMaximum) OrElse (Not bMinimumIncluded And dcmText <= dcmMinimum) OrElse (Not bMaximumIncluded And dcmText >= dcmMaximum) Then
                    iType = 2
                End If
            End If
        Else
            iType = 1
        End If
        Return iType
    End Function


    ''' <summary>
    ''' Returns the numeric range for the control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetNumericRange() As String
        Dim strRange As String = ""
        If strValidationType = "numeric" Then
            If dcmMinimum <> Decimal.MinValue Then
                If bMinimumIncluded Then
                    strRange = ">= " & dcmMinimum.ToString()
                Else
                    strRange = "> " & dcmMinimum.ToString()
                End If
                If dcmMaximum <> Decimal.MaxValue Then
                    strRange = strRange & " and "
                End If
            End If
            If dcmMaximum <> Decimal.MaxValue Then
                If bMaximumIncluded Then
                    strRange = strRange & "<= " & dcmMaximum.ToString()
                Else
                    strRange = strRange & "< " & dcmMaximum.ToString()
                End If
            End If
        End If
        Return strRange
    End Function

    ''' <summary>
    ''' Returns the minimum decimal number for the control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDcmMinimum() As Decimal
        Return dcmMinimum
    End Function

    ''' <summary>
    ''' Returns the maximum decimal number for the control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDcmMaximum() As Decimal
        Return dcmMaximum
    End Function

    ''' <summary>
    ''' Checks if a textbox is empty
    ''' Returns true when text box is empty
    ''' </summary>
    ''' <returns></returns>
    Public Function IsEmpty() As Boolean
        Return String.IsNullOrEmpty(cboValues.Text)
    End Function

End Class
