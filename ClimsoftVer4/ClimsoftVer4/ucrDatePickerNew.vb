Public Class ucrDatePickerNew



    Public Overrides Function IsEmpty() As Boolean
        Return True 'to be overidden by the child controls
    End Function

    Public Overrides Sub Clear()

    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Return True
    End Function
    Public Overrides Sub GetFocus()

    End Sub

    Public Overrides Sub GetValidationParametersFromDataStructure()
        'todo. gets the validation parameters from the datastructure
    End Sub

    Public Overrides Sub SetValueFromDataStructure()
        'todo. reads value from the datastructure
    End Sub

    Public Overrides Sub SetValueToDataStructure()
        'todo. writes value to the datastructure
    End Sub


    Public Overrides Sub SetBackColor(backColor As Color)
    End Sub

    Public Overrides Function GetValue(Optional objSpecification As Object = Nothing) As Object
        'gets the value of the control.
        'Possibly pass in a parameter that specifies the value to get incase the control has more than one value
        Return Nothing
    End Function
End Class
