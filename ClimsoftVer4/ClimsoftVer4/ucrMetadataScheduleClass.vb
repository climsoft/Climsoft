Public Class ucrMetadataScheduleClass

    Private Sub ucrMetadataScheduleClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetUpTableEntry("obsscheduleclass")

            ucrTextBoxClass.SetTableNameAndField("obsscheduleclass", "scheduleClass")
            ucrTextBoxClass.PopulateControl()
            ucrTextBoxClass.SetValue("scheduleClass")
            ucrTextBoxClass.bValidate = False

            AddLinkedControlFilters(ucrTextBoxClass, ucrTextBoxClass.FieldName, "=", strLinkedFieldName:=ucrTextBoxClass.FieldName, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationScheduleClass.SetTableEntry(Me)
            ucrNavigationScheduleClass.AddKeyControls(ucrTextBoxClass)

            bFirstLoad = False

            'populate the values
            ucrNavigationScheduleClass.PopulateControl()

        End If
    End Sub
End Class