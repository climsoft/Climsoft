Public Class frmCPTSeason

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click

        Me.Close()

    End Sub

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click

        formProductsSelectCriteria.CPTstart = cmbStartMonth.Text
        formProductsSelectCriteria.CPTend = cmbEndMonth.Text
        Me.Hide()
    End Sub
End Class