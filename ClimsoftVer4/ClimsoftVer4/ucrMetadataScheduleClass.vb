Public Class ucrMetadataScheduleClass
    Private strscheduleClass As String = "scheduleClass"

    Protected Overrides Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            strTableName = "obsscheduleclass"

            'ucrTableEntry_Load fills in the lstFields
            MyBase.ucrTableEntry_Load(sender, e)

            AddLinkedControlFilters(ucrTextBoxClass, strscheduleClass, "=", strLinkedFieldName:=strscheduleClass, bForceValuesAsString:=True)

            'set up the navigation control
            ucrNavigationScheduleClass.SetTableNameAndFields(strTableName, (New List(Of String)({strscheduleClass})))
            ucrNavigationScheduleClass.SetKeyControls(strscheduleClass, ucrTextBoxClass)

            bFirstLoad = False

            'populate the values
            ucrNavigationScheduleClass.PopulateControl()
        End If
    End Sub
End Class