Public Class ucrMetadataPaperArchiveNew
    Private Sub ucrMetadataPaperArchiveNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            SetUpButtonAddNew(btnAddNew)
            SetUpButtonSave(btnSave)
            SetUpButtonUpdate(btnUpdate)
            SetUpButtonDelete(btnDelete)
            SetUpButtonClear(btnClear)
            SetUpButtonView(btnView)

            'todo pass in the data identifier here in place of nothing.
            'This will be used by the data definition
            SetDataIdentifier(Nothing)
            SetValueControlProperties()
            SetUpValueControls()
            InitialiseDatastructure()

            bFirstLoad = False
        End If
    End Sub
End Class
