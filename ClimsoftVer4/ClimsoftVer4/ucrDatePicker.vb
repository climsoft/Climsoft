Public Class ucrDatePicker
    Private bFirstLoad As Boolean = True

    Protected Overridable Sub ucrDatePicker_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'TODO determine the default date format?
            'dtpDate.Format = DateFormat.LongDate
            dtpDate.Value = Date.Today
            bFirstLoad = False
        End If
    End Sub

    Private Sub dtpDate_CloseUp(sender As Object, e As EventArgs) Handles dtpDate.CloseUp
        SetValue(dtpDate.Value)
    End Sub

    Private Sub dtpDatetxtDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown, txtDate.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub txtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        'TODO validate the value and respond accordingly
        ValidateValue()
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            'TODO
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        If IsDBNull(objNewValue) OrElse IsNothing(objNewValue) OrElse (TypeOf objNewValue Is String AndAlso String.IsNullOrWhiteSpace(objNewValue)) Then
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
        If String.IsNullOrWhiteSpace(txtDate.Text) Then
            Return Nothing
        Else

            'TODO
            'Get the date value from the textbox not the datapicker
            'Also check on the required format?


            Return dtpDate.Value.ToShortDateString
        End If
    End Function

    Public Overrides Function ValidateValue() As Boolean
        'TODO
        Return True
    End Function

    Public Overrides Sub Clear()
        'Dim bPrevValidate As Boolean = bValidate
        'bValidate = False
        SetValue("") 'TODO
        SetBackColor(bValidColor)
        'bValidate = bPrevValidate
    End Sub

    Public Overrides Sub SetBackColor(backColor As Color)
        txtDate.BackColor = backColor
    End Sub

    Public Overrides Sub GetFocus()
        txtDate.Focus()
    End Sub


End Class
