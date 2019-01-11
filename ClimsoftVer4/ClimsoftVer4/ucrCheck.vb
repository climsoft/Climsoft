Public Class ucrCheck
    Public Property CheckBoxText() As String
        Get
            Return chkCheck.Text
        End Get
        Set(value As String)
            chkCheck.Text = value
        End Set
    End Property
End Class
