Public Class frmMsg
    Dim minHeight As Integer = 160
    Dim maxHeight As Integer = 300

    ''' <summary>Reset the message box dialog to its initial state</summary>
    Public Sub Reset()
        Height = minHeight
        cmdDetails.Text = "▼  Details"
        rtfMessage.Text = ""
        rtfDetails.Text = ""
        Me.Text = "Climsoft"
        picIcon.Image = SystemIcons.Information.ToBitmap
    End Sub

    Private Sub cmdDetails_Click(sender As Object, e As EventArgs) Handles cmdDetails.Click
        If Height = maxHeight Then
            Height = minHeight
            cmdDetails.Text = "▼  Details"
        Else
            Height = maxHeight
            cmdDetails.Text = "▲  Details"
        End If
    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        Me.Close()
    End Sub
End Class

Module MsgBoxDetailsModule
    ''' <summary>Displays a message in a dialog box with an expandable section for extra details.</summary>
    ''' <param name="message">Required. String expression displayed as the message in the dialog box.</param>
    ''' <param name="details">Optional. Additional text to display in the details section. If omitted a standard message box is shown.</param>
    ''' <param name="title">Optional. String expression displayed in the title bar of the dialog box. If you omit Title, the application name is placed in the title bar.</param>
    Sub Msg(message As String, Optional details As String = "", Optional title As String = Nothing)
        frmMsg.Reset()
        frmMsg.rtfMessage.Text = message
        frmMsg.rtfDetails.Text = details
        If Not String.IsNullOrEmpty(title) Then
            frmMsg.Text = title
        End If
        frmMsg.ShowDialog()
    End Sub
End Module