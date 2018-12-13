Public Class ucrMetadataPaperArchive
    Private Sub ucrMetadataInstrument_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'SetUpTableEntry 
            SetUpTableEntry("paperarchive")

            AddLinkedControlFilters(ucrTextBoxFormId, ucrTextBoxFormId.FieldName(), "=", strLinkedFieldName:=ucrTextBoxFormId.FieldName(), bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationPaperArchive.SetTableEntry(Me)
            ucrNavigationPaperArchive.AddKeyControls(ucrTextBoxFormId)

            bFirstLoad = False

            'populate the values
            ucrNavigationPaperArchive.PopulateControl()

        End If
    End Sub
End Class
