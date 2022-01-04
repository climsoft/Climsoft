Public Class frmChangeOwnPassword

    Private Sub frmChangeOwnPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSave.Enabled = False
        ucrPasswordNew.SetValidPasswordLength(6)
        ucrPasswordNew.SetErorMessage("Password length must be >=6 characters!")
        ucrPasswordConfirm.SetErorMessage("Password must match!")

        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub ucrPassword_evtPasswordTextChanged(sender As Object, e As EventArgs) Handles ucrPasswordNew.evtPasswordTextChanged, ucrPasswordConfirm.evtPasswordTextChanged
        If sender Is ucrPasswordNew Then
            ucrPasswordConfirm.SetValidPasswordText(ucrPasswordNew.GetPasswordText)
        End If
        btnSave.Enabled = ucrPasswordNew.ValidPassword AndAlso ucrPasswordConfirm.ValidPassword
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If DialogResult.Yes = MessageBox.Show(Me,
                               ClsTranslations.GetTranslation("Your current password will be changed to the new password entered, do you still wish to proceed"),
                               ClsTranslations.GetTranslation("Password Change"),
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                'Set new password
                Dim sqlCommand As String = "SET PASSWORD FOR '" & clsDataConnection.GetUserName & "'@'%' = '" & ucrPasswordNew.GetPasswordText & "'"
                Using objCmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCommand, clsDataConnection.GetOpenedConnection)
                    objCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show(Me, ClsTranslations.GetTranslation("Your new password has been set!"),
                                   ClsTranslations.GetTranslation("Password Change"),
                                   MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(Me, ClsTranslations.GetTranslation("Error") & ": " & ex.Message,
                            ClsTranslations.GetTranslation("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "changepassword.htm#ownpassword")
    End Sub

    Private Sub ucrPasswordNew_evtPasswordTextChanged(sender As Object, e As EventArgs)

    End Sub
End Class