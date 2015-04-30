Public Class frmAction

    Public Overridable Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

    End Sub

    Public Overridable Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Public Overridable Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click

    End Sub

    Public Overridable Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        MsgBox("Help does not currently exist for this window", MsgBoxStyle.Information)
    End Sub

End Class