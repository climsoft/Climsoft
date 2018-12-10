Public Class ucrMetadataPaperArchive

    Private strformId As String = "formId"

    Protected Overrides Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "paperarchivedefinition"

            'ucrTableEntry_Load fills in the lstFields
            MyBase.ucrTableEntry_Load(sender, e)

            AddLinkedControlFilters(ucrTextBoxFormId, strformId, "=", strLinkedFieldName:=strformId, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationPaperArchive.SetTableNameAndFields(strTableName, (New List(Of String)({strformId})))
            ucrNavigationPaperArchive.SetKeyControls(strformId, ucrTextBoxFormId)

            bFirstLoad = False

            'populate the values
            ucrNavigationPaperArchive.PopulateControl()
        End If
    End Sub
End Class
