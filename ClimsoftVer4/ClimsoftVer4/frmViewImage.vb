Public Class frmViewImage

 
    Private Sub frmViewImage_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        picView.Width = Me.Width * 0.97
        picView.Height = Me.Height * 0.9

    End Sub


End Class