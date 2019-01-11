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
        ValidateValue()
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub Clear()
        Dim bPrevValidate As Boolean = bValidate
        bValidate = False
        SetValue("")
        SetBackColor(bValidColor)
        bValidate = bPrevValidate
    End Sub

    ''' <summary>
    ''' Sets validation of the textbox to numeric
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

        'Proceed from here.
        If bValidate Then
            If cboValues.DisplayMember <> "" Then
                For Each rTemp As DataRow In dtbRecords.Rows
                    If rTemp.Item(cboValues.DisplayMember).ToString = cboValues.Text Then
                        bValid = True
                        Exit For
                    End If
                Next
            End If
        Else
            bValid = True
        End If

        SetBackColor(If(bValid, Color.White, Color.Red))
        Return bValid
    End Function


    Public Function ValidateValueDelete1() As Boolean
        Dim iType As Integer

        If bValidate Then
            'if set to not validate empty values and textbox is empty then don't proceed with validation
            If Not bValidateEmpty AndAlso IsEmpty() Then
                SetBackColor(bValidColor)
                Return True
            End If

            iType = GetValidationCode(GetValue)
            If iType = 0 Then
                SetBackColor(bValidColor)
            ElseIf iType = 1 Then
                SetBackColor(Color.Red)
                If Not bValidateSilently Then
                    MessageBox.Show("Number expected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            ElseIf iType = 2 Then
                'check if it was lower and upper limit violation
                If Not (GetDcmMinimum() <= Val(GetValue)) Then
                    SetBackColor(Color.Cyan)
                    If Not bValidateSilently Then
                        MessageBox.Show("Value lower than lowerlimit of: " & GetDcmMinimum(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                ElseIf Not (GetDcmMaximum() >= Val(GetValue)) Then
                    SetBackColor(Color.Cyan)
                    If Not bValidateSilently Then
                        MessageBox.Show("Value higher than upperlimit of: " & GetDcmMaximum(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            End If
            Return (iType = 0)
        Else
            Return True
        End If

    End Function

    'TODO. CAN THE FUNCTION BELOW BE MERGED WITH FUNCTION ValidateValue()
    ''' <summary>
    ''' checks if the string passed can be a valid value for this control
    ''' </summary>
    ''' <param name="strText"></param>
    ''' <returns></returns>
    Public Function ValidateText(strText As String, Optional bValidateSilently As Boolean = True) As Boolean
        Dim iValidationCode As Integer

        'if set to not validate empty values and string is empty then don't proceed with validation
        If Not bValidateEmpty AndAlso String.IsNullOrEmpty(strText) Then
            Return True
        End If

        iValidationCode = GetValidationCode(strText)
        Select Case iValidationCode
            Case 0
                'this is for none. No validation
            Case 1
                Select Case strValidationType
                    Case "Numeric"
                        If Not bValidateSilently Then
                            MessageBox.Show("Entry must be numeric.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                End Select
            Case 2
                Select Case strValidationType
                    Case "Numeric"
                        If Not bValidateSilently Then
                            MessageBox.Show("This number must be: " & GetNumericRange(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                End Select

        End Select
        Return (iValidationCode = 0)
    End Function

    Public Function GetValidationCode(strText As String) As Integer
        Dim iType As Integer
        Select Case strValidationType
            Case "none"
                iType = 0
            Case "numeric"
                iType = ValidateNumeric(strText)
        End Select
        Return iType
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
        Return String.IsNullOrEmpty(GetValue())
    End Function

End Class
