Public Class ucrMetadataElementNew
    Private Sub ucrMetadataElementNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            SetUpButtonAddNew(btnAddNew)
            SetUpButtonCancel(btnCancel)
        End If
    End Sub
End Class
