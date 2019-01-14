Public Class ucrCheck
    Private bFirstLoad As Boolean = True

    Private Sub ucrCheck_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then

            bFirstLoad = False
        End If
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

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        'TODO probably do a check to determine if a boolean is the one needed ?
        Return If(chkCheck.Checked, 1, 0)
    End Function

    Public Overrides Sub SetValue(objNewValue As Object)
        If IsDBNull(objNewValue) OrElse IsNothing(objNewValue) Then
            chkCheck.Checked = False
        ElseIf TypeOf objNewValue Is Boolean Then
            chkCheck.Checked = objNewValue
        ElseIf IsNumeric(objNewValue) Then
            chkCheck.Checked = Not (Val(objNewValue) = 0)
        Else
            MessageBox.Show("Developer error: Checkbox can only accept true,false(booleans) or 0,1. Control: " & Me.Name, caption:="Developer error")
        End If
        OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Sub Clear()
        'Dim bPrevValidate As Boolean = bValidate
        'bValidate = False
        SetValue(False)
        'bValidate = bPrevValidate
    End Sub

    Public Overrides Sub GetFocus()
        chkCheck.Focus()
    End Sub


End Class
