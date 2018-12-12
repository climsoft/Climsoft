Public Class ucrValueView
    Public Event evtKeyDown(sender As Object, e As KeyEventArgs)
    Public Event evtTextChanged(sender As Object, e As EventArgs)
    Public Event evtValueChanged(sender As Object, e As EventArgs)

    ' When True, ValueChanged and TextChanged etc. events will not be raised
    ' Used when wanting to update several controls without linked controls updating inbetween.
    Public bSuppressChangedEvents As Boolean = False

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




End Class
