Public Class ucrCheckboxNew
    Public Property CheckBoxText() As String
        Get
            Return chkCheck.Text
        End Get
        Set(value As String)
            chkCheck.Text = value
        End Set
    End Property

    Private Sub ucrCheckboxNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub chkCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles chkCheck.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub chkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheck.CheckedChanged
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Function GetValue(Optional objSpecification As Object = Nothing) As Object
        'gets the value of the control.
        'Possibly pass in a parameter that specifies the value to get incase the control has more than one value
        Return Nothing
    End Function

    Public Overrides Sub SetValue(objNewValue As Object)
        'todo. Set the value top the control then write it to the datasctrure
    End Sub

    Public Overrides Sub SetValueToDataStructure()
        'todo. writes value to the datastructure
    End Sub

    Public Overrides Sub SetValueFromDataStructure()
        'todo. reads value from the datastructure
    End Sub

    Public Overrides Sub Clear()
        'todo. set to false?
    End Sub

End Class
