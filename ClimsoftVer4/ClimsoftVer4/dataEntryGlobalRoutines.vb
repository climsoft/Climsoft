Public Class dataEntryGlobalRoutines
   
    Public Sub messageBoxNoPreviousRecord()
        MsgBox("No more previous record!", MsgBoxStyle.Exclamation)
    End Sub
    Public Sub messageBoxNoNextRecord()
        MsgBox("No more next record!", MsgBoxStyle.Exclamation)
    End Sub
    Public Sub messageBoxOperationCancelled()
        MsgBox("Operation cancelled!", MsgBoxStyle.Information)
    End Sub
    Public Sub messageBoxRecordedUpdated()
        MsgBox("Record updated successfully!", MsgBoxStyle.Information)
    End Sub
    Public Sub messageBoxCommit()
        MsgBox("New record added to database table!", MsgBoxStyle.Information)
    End Sub
   
    End Class
