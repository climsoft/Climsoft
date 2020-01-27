Public Class ucrTextBoxNew

    Protected Overridable Sub ucrTextBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then

            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBox.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub ucrTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged
        'check if value is valid
        ValidateValue()
        'raise event
        OnevtTextChanged(Me, e)
    End Sub

    Private Sub ucrTextBox_Leave(sender As Object, e As EventArgs) Handles txtBox.Leave
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub SetValueFromDataStructure()
        'todo. reads value from the datastructure
    End Sub

    Public Overrides Sub SetValueToDataStructure()
        'todo. writes value to the datastructure
    End Sub

    Public Overrides Function GetValue(Optional objSpecification As Object = Nothing) As Object
        'todo. get the value of the control.
        'possibly always get this from the datastrure?
        Return Nothing
    End Function

    Public Overrides Sub SetValue(objNewValue As Object)
        If IsDBNull(objNewValue) OrElse IsNothing(objNewValue) Then
            txtBox.Text = ""
        Else
            txtBox.Text = objNewValue
        End If
        OnevtValueChanged(Me, Nothing)
    End Sub

    ' TODO This can now be removed once the forms using it in the deisigners have been fixed.
    Public Property TextboxValue() As String
        Get
            Return txtBox.Text
        End Get
        Set(ByVal strValue As String)
            txtBox.Text = strValue
        End Set
    End Property


    Public Overrides Function ValidateValue() As Boolean
        'todo. validate based on the parameters of validation from the datastructre
        Return True
    End Function


    Public Overrides Sub GetFocus()
        txtBox.Focus()
    End Sub


    Public Overrides Function IsEmpty() As Boolean
        Return String.IsNullOrEmpty(txtBox.Text)
    End Function

    ''' <summary>
    ''' Clears contents of the textbox
    ''' </summary>
    Public Overrides Sub Clear()
        'todo. clear the control ?
        SetValue("")
        SetBackColor(clValidColor)

    End Sub

    Public Overrides Sub SetBackColor(backColor As Color)
        txtBox.BackColor = backColor
    End Sub

    Public Overrides Sub SetAsReadOnly()
        txtBox.ReadOnly = True
    End Sub

    Public Sub SetSize(Size As Point)
        'txtBox.Size = New Size(Size)
        Me.Size = New Size(Size)
    End Sub

    Public Overrides Sub SetContextMenuStrip(contextMenuStrip As ContextMenuStrip)
        txtBox.ContextMenuStrip = contextMenuStrip
    End Sub
End Class
