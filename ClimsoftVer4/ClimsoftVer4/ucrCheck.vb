Public Class ucrCheck
    Private bFirstLoad As Boolean = True

    Private Sub ucrCheck_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub chkCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles chkCheck.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub chkCheck_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheck.CheckedChanged
        OnevtValueChanged(Me, e)
    End Sub

    Public Property CheckBoxText() As String
        Get
            Return chkCheck.Text
        End Get
        Set(value As String)
            chkCheck.Text = value
        End Set
    End Property

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            'TODO
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        If IsDBNull(objNewValue) OrElse IsNothing(objNewValue) Then
            chkCheck.Checked = False
        Else
            If IsNumeric(objNewValue) Then
                If Val(objNewValue) = 0 Then
                    chkCheck.Checked = False
                Else
                    chkCheck.Checked = True
                End If
            Else
                MessageBox.Show("Developer error: Checkbox can only accept true,false(booleans) or 0,1. Control: " & Me.Name, caption:="Developer error")
            End If
        End If
        OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Sub Clear()
        Dim bPrevValidate As Boolean = bValidate
        bValidate = False
        SetValue(False)
        bValidate = bPrevValidate
    End Sub

    Public Overrides Sub GetFocus()
        chkCheck.Focus()
    End Sub


End Class
