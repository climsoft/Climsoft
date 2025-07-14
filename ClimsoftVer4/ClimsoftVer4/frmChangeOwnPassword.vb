Public Class frmChangeOwnPassword
    Dim conn As New MySqlConnector.MySqlConnection
    Dim connStr As String, Sql As String
    Dim objCmd As MySqlConnector.MySqlCommand
    Dim msgNotYetImplemented As String
    Dim msgWrongPasswordConfirmation As String
    Dim msgPasswordTooShort As String
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmChangeOwnPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        msgNotYetImplemented = "Not yet implemented!"
        msgWrongPasswordConfirmation = "Wrong confirmation of password!"
        msgPasswordTooShort = "Password length must be >=6 characters!"
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        connStr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = connStr
        'Open connection to database
        conn.Open()
        If Strings.Len(txtNewPassword.Text) >= 6 Then
            If txtNewPassword.Text = txtConfirmPassword.Text Then
                Try
                    'Set new password
                    Sql = "SET PASSWORD  = PASSWORD('" & txtNewPassword.Text & "');"
                    objCmd = New MySqlConnector.MySqlCommand(Sql, conn)
                    objCmd.ExecuteNonQuery()
                    MsgBox("Your new password has been set!", MsgBoxStyle.Information)
                Catch ex As Exception
                    ''Dispaly Exception error message 
                    MsgBox(ex.Message)
                    conn.Close()
                End Try
            Else
                MsgBox(msgWrongPasswordConfirmation, MsgBoxStyle.Information)
            End If
        Else
            MsgBox(msgPasswordTooShort, MsgBoxStyle.Information)
        End If
        'Close connection
        conn.Close()
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If Strings.Len(txtConfirmPassword.Text) > 0 And Strings.Len(txtNewPassword.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "changepassword.htm#ownpassword")
    End Sub
End Class