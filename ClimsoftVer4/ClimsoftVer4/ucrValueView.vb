Public Class ucrValueView
    Public Event evtKeyDown(sender As Object, e As KeyEventArgs)
    Public Event evtTextChanged(sender As Object, e As EventArgs)
    Public Event evtValueChanged(sender As Object, e As EventArgs)

    ' When True, ValueChanged and TextChanged etc. events will not be raised
    ' Used when wanting to update several controls without linked controls updating inbetween.
    Public bSuppressChangedEvents As Boolean = False

    Protected clValidColor As Color = Color.White 'used to set the default back color to show when the value input is  valid 
    Protected clInValidColor As Color = Color.Red 'used to set the default back color to show when the value input is invalid 
    Public bValidate As Boolean = True
    Public bValidateSilently As Boolean = True
    Public bValidateEmpty As Boolean = False
    Protected strValidationType As String = "none"

    Protected objDefaultValue As Object = Nothing
    Public Property KeyControl() As Boolean = False

    Public Property FieldName() As String
        Get
            Return Me.Tag
        End Get
        Set(value As String)
            Me.Tag = value
        End Set
    End Property
    Public Overridable Sub SetDefaultValue(objNewValue As Object)
        objDefaultValue = objNewValue
    End Sub

    Public Overridable Function GetDefaultValue() As Object
        Return objDefaultValue
    End Function

    Public Function HasDefaultValue() As Boolean
        Return Not IsNothing(GetDefaultValue())
    End Function

    Public Overridable Sub SelectDefaultValue()
        SetValue(GetDefaultValue())
    End Sub

    Public Sub OnevtKeyDown(sender As Object, e As KeyEventArgs)
        RaiseEvent evtKeyDown(sender, e)
    End Sub

    Public Sub OnevtTextChanged(sender As Object, e As EventArgs)
        If Not bSuppressChangedEvents Then
            RaiseEvent evtTextChanged(sender, e)
        End If
    End Sub

    Public Sub OnevtValueChanged(sender As Object, e As EventArgs)
        If Not bSuppressChangedEvents Then
            RaiseEvent evtValueChanged(sender, e)
        End If
    End Sub

    Public Overridable Sub SetValue(objNewValue As Object)
    End Sub

    Public Overridable Sub SetValueFromDataTable(dtbValues As DataTable)
        Dim lstTemp As New List(Of Object)
        Dim lstDistinct As New List(Of Object)

        If String.IsNullOrEmpty(FieldName) Then
            SetValue(Nothing)
        Else
            If dtbValues.Rows.Count = 1 Then
                SetValue(dtbValues.Rows(0).Item(FieldName))
            ElseIf dtbValues.Rows.Count > 1 Then
                For Each tempRow As DataRow In dtbValues.Rows
                    lstTemp.Add(tempRow.Item(FieldName))
                Next
                lstDistinct = lstTemp.Distinct().ToList
                If lstDistinct.Count = 1 Then
                    SetValue(lstDistinct(0))
                Else
                    SetValue(lstTemp)
                End If
            Else
                SetValue(Nothing)
            End If
        End If
    End Sub

    Public Overridable Sub SetValueToDataTable(dtbValues As DataTable)
        Dim lstTemp As New List(Of Object)
        Dim lstDistinct As New List(Of Object)

        If String.IsNullOrEmpty(FieldName) Then
            'TODO?
        Else
            If dtbValues.Rows.Count = 1 Then
                If ValidateValue() Then
                    'dtbValues.Rows(0).Item(FieldName) = If(IsNothing(GetValue()), DBNull.Value, GetValue())
                    Try
                        dtbValues.Rows(0).Item(FieldName) = GetValue()
                    Catch ex As ArgumentException
                        dtbValues.Rows(0).Item(FieldName) = DBNull.Value
                    End Try
                Else
                    dtbValues.Rows(0).Item(FieldName) = DBNull.Value
                End If
            ElseIf dtbValues.Rows.Count > 1 Then
                'TODO
            Else
                'TODO
            End If
        End If
    End Sub

    Public Overridable Function GetValue(Optional strFieldName As String = "") As Object
        'Dim tempRow As DataRow
        'Dim lstTemp As New List(Of Object)

        'If strFieldName = "" Then
        '    Return Nothing
        'End If
        'UpdateInputValueToDataTable()
        'If dtbRecords.Rows.Count = 1 Then
        '    Return dtbRecords.Rows(0).Item(strFieldName)
        'ElseIf dtbRecords.Rows.Count > 1 Then
        '    For Each tempRow In dtbRecords.Rows
        '        lstTemp.Add(tempRow.Item(strFieldName))
        '    Next
        '    Return lstTemp
        'Else
        Return Nothing
        'End If

    End Function

    Public Overridable Sub AddFieldstoList(lstFields As List(Of String))
        If Not String.IsNullOrEmpty(FieldName) Then
            lstFields.Add(FieldName)
        End If
    End Sub

    Public Overridable Sub AddEventValueChangedHandle(ehSub As evtValueChangedEventHandler)
        If Not String.IsNullOrEmpty(FieldName) Then
            AddHandler evtValueChanged, ehSub
        End If
    End Sub

    Public Sub SetUpControlInParent(lstFields As List(Of String), ehSub As evtValueChangedEventHandler)
        AddFieldstoList(lstFields)
        AddEventValueChangedHandle(ehSub)
    End Sub

    ''' <summary>
    ''' Sets the back colour of the control
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Overridable Sub SetBackColor(backColor As Color)
    End Sub

    ''' <summary>
    ''' Sets the default back color for when this control has a valid value
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Sub SetValidColor(backColor As Color)
        clValidColor = backColor
    End Sub

    Public Function GetValidColor() As Color
        Return clValidColor
    End Function

    Public Sub SetInValidColor(backColor As Color)
        clInValidColor = backColor
    End Sub

    Public Function GetInValidColor() As Color
        Return clInValidColor
    End Function

    'TODO. Rethink how to override the Focus function
    Public Overridable Sub GetFocus()
        Me.Focus()
    End Sub

End Class
