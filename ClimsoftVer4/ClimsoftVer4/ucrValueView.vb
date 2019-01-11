Public Class ucrValueView
    Public Event evtKeyDown(sender As Object, e As KeyEventArgs)
    Public Event evtTextChanged(sender As Object, e As EventArgs)
    Public Event evtValueChanged(sender As Object, e As EventArgs)

    ' When True, ValueChanged and TextChanged etc. events will not be raised
    ' Used when wanting to update several controls without linked controls updating inbetween.
    Public bSuppressChangedEvents As Boolean = False

    Public Property FieldName() As String
        Get
            Return Tag
        End Get
        Set(value As String)
            Tag = value
        End Set
    End Property


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

        If FieldName = "" Then
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

        If FieldName = "" Then
            'TODO?
        Else
            If dtbValues.Rows.Count = 1 Then
                dtbValues.Rows(0).Item(FieldName) = GetValue()
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
        lstFields.Add(FieldName)
    End Sub

    Public Overridable Sub AddEventValueChangedHandle(ehSub As evtValueChangedEventHandler)
        AddHandler evtValueChanged, ehSub
    End Sub

    Public Sub SetUpControlInParent(lstFields As List(Of String), ehSub As evtValueChangedEventHandler)
        AddFieldstoList(lstFields)
        AddEventValueChangedHandle(ehSub)
    End Sub

End Class
