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
    Public bValidate As Boolean = True
    Public bValidateSilently As Boolean = True
    Public bValidateEmpty As Boolean = False
    Protected strValidationType As String = "none"

    Protected objDefaultValue As Object = Nothing
    Public Property KeyControl() As Boolean = False


    Private Sub ucrValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


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

    Public Overridable Sub SetValueFromDataStructure()

    End Sub

    Public Overridable Sub SetValueToDataStructure(dtbValues As DataTable)

    End Sub

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

    End Sub

    Public Overridable Sub GetFocus()

    End Sub

    Public Overridable Sub Clear()

    End Sub

    Public Overridable Function ValidateValue() As Boolean
        Return True
    End Function

    Public Overridable Function GetValue(Optional strFieldName As String = "") As Object
        Return Nothing
    End Function

End Class
