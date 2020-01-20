Public Class ucrMetadataElementNew
    Private Sub ucrMetadataElementNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            SetUpButtonAddNew(btnAddNew)
            SetUpButtonSave(btnSave)
            SetUpButtonUpdate(btnUpdate)
            SetUpButtonDelete(btnDelete)
            SetUpButtonClear(btnClear)

        End If
    End Sub
End Class
