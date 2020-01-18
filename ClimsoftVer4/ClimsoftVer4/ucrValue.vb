Public Class ucrValue
    Protected bFirstLoad As Boolean = True
    Public Event evtKeyDown(sender As Object, e As KeyEventArgs)
    Public Event evtTextChanged(sender As Object, e As EventArgs)
    Public Event evtValueChanged(sender As Object, e As EventArgs)

    ' When True, ValueChanged and TextChanged etc. events will not be raised
    ' Used when wanting to update several controls without linked controls updating inbetween.
    Public bSuppressChangedEvents As Boolean = False

    Protected clValidColor As Color = Color.White 'used to set the default back color to show when the value input is  valid 
    Protected clInValidColor As Color = Color.Red 'used to set the default back color to show when the value input is invalid 
    Public bValidate As Boolean = True 'switches the validation on and off
    Public bValidateSilently As Boolean = True 'this will inhibit showing message boxes when invalid values are written 


    Private Sub ucrValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub SetDataIdentifier(objDataIdentifier As Object)
        'specifies the identifier that would be usd by the datastructure to get the data 
        'the identifier will have a field name
    End Sub

    Public Overridable Sub SetValueFromDataStructure()
        'todo. reads value from the datastructure
    End Sub

    Public Overridable Sub GetValidationParametersFromDataStructure()
        'todo. gets the validation parameters from the datastructure
    End Sub

    'this will be the event handler that listens to changes to record in the datastructure
    Private Sub ChangesToRecordInDataStructure(sender As Object, e As EventArgs)
        SetValueFromDataStructure()
    End Sub

    Public Overridable Sub SetValueToDataStructure()
        'todo. writes value to the datastructure
    End Sub

    Public Overridable Sub SetValue(objNewValue As Object)
    End Sub

    Public Overridable Function GetValue(Optional objSpecification As Object = Nothing) As Object
        'gets the value of the control.
        'Possibly pass in a parameter that specifies the value to get incase the control has more than one value
        Return Nothing
    End Function

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

    Public Overridable Sub SetContextMenuStrip(contextMenuStrip As ContextMenuStrip)
        'sets the context menu of the control
    End Sub

    Public Overridable Sub GetFocus()

    End Sub

    Public Overridable Sub Clear()

    End Sub

    Public Overridable Function ValidateValue() As Boolean
        Return True
    End Function

    Public Overridable Function IsValid() As Boolean
        Return True
    End Function

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

End Class
