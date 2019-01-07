Public Class ucrDatePicker
    Private bFirstLoad As Boolean = True
    Public bValidate As Boolean = True
    Public bValidateSilently As Boolean = True
    Public bValidateEmpty As Boolean = False
    'used to set the default back color to show when the value input is a valid one
    Private bValidColor As Color = Color.White
    Protected Overridable Sub ucrTextBox_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'dtpDate.Format = DateFormat.LongDate
            dtpDate.Value = Date.Today
            bFirstLoad = False
        End If
    End Sub

    Private Sub dtpDate_CloseUp(sender As Object, e As EventArgs) Handles dtpDate.CloseUp
        SetValue(dtpDate.Value)
    End Sub

    Private Sub txtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        'TODO validate the value and respond accordingly
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        If objNewValue Is Nothing OrElse (TypeOf objNewValue Is String AndAlso String.IsNullOrWhiteSpace(objNewValue)) Then
            txtDate.Text = ""
        Else
            Try
                'TODO try creating a date object from the string value?
                dtpDate.Value = objNewValue
                txtDate.Text = dtpDate.Value
            Catch ex As Exception
                txtDate.Text = ""
            End Try
        End If

        OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        If txtDate.Text.Trim = "" Then
            Return Nothing
        Else
            Return dtpDate.Value
        End If
    End Function

    Public Overrides Function ValidateValue() As Boolean
        'TODO
        Return True
    End Function

    Public Overrides Sub Clear()
        bValidate = False
        SetValue("") 'TODO
        SetBackColor(bValidColor)
        bValidate = True
    End Sub

    Public Sub SetBackColor(backColor As Color)
        txtDate.BackColor = backColor
    End Sub


End Class
