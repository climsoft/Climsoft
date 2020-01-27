Public Class ucrMetadataStationNew
    Private Sub ucrMetadataStationNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstLoad Then

            SetUpButtonAddNew(btnAddNew)
            SetUpButtonSave(btnSave)
            SetUpButtonCancel(btnCancel)
            SetUpButtonClear(btnClear)
            SetUpButtonDelete(btnDelete)
            SetUpButtonUpdate(btnUpdate)
            SetUpButtonUpload(btnUpload)
            SetUpButtonView(btnView)
            SetUpNavigator(ucrNavigator)

            'todo pass in the data identifier here in place of nothing. 
            'This will be used by the data defination
            SetDataIdentifier(Nothing)
            'SetValueControlProperties()
            SetUpValueControls()
            InitialiseDatastructure()

            bFirstLoad = False
        End If
    End Sub

    Public Sub SetValueControlProperties()
        For Each ctr As ucrValue In lstUcrValues
            'set the properties that will be used as part of the data defination
            'todo. set up the properties of the child controls and the defination of the data structure
            'the properties will be field name... 
        Next
    End Sub


End Class
