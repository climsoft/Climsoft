Public Class ucrPassword
    Public Event evtPasswordTextChanged(sender As Object, e As EventArgs)
    Private iValidLength As Integer = 0
    Private strValidText As String = ""
    Public Property ValidPassword As Boolean

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        ValidatePassword()
        RaiseEvent evtPasswordTextChanged(Me, e)
    End Sub

    Private Sub chkShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShowPassword.Checked
    End Sub

    ''' <summary>
    ''' message to be shown to the user if the password input is not valid
    ''' </summary>
    ''' <param name="strErrorMessage"></param>
    Public Sub SetErorMessage(strErrorMessage As String)
        lblMessage.Text = strErrorMessage
        ValidatePassword()
    End Sub

    ''' <summary>
    ''' password input will be regarded as valid if >= to the iNewValidLength
    ''' </summary>
    ''' <param name="iNewValidLength"></param>
    Public Sub SetValidPasswordLength(iNewValidLength As Integer)
        iValidLength = iNewValidLength
        ValidatePassword()
    End Sub

    Public Sub SetValidPasswordText(iNewValidPasswordText As String)
        strValidText = iNewValidPasswordText
        ValidatePassword()
    End Sub

    Private Sub ValidatePassword()
        'validate the password based on the valid length if it was provided
        ValidPassword = iValidLength <= 0 OrElse txtPassword.Text.Length >= iValidLength
        'valiate the password based on the valid text if provided
        If ValidPassword AndAlso strValidText <> "" Then
            ValidPassword = (txtPassword.Text = strValidText)
        End If
        'show message feedback if password is input and not valid
        lblMessage.Visible = txtPassword.Text <> "" AndAlso Not ValidPassword
    End Sub

    Public Function GetPasswordText() As String
        Return txtPassword.Text
    End Function

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        Return GetPasswordText()
    End Function

    Public Overrides Sub Clear()
        txtPassword.Text = ""
    End Sub

    Public Sub SetPasswordText(strPassword As String)
        txtPassword.Text = strPassword
    End Sub

End Class
