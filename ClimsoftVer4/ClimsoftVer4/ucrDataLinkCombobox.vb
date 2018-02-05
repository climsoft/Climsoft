Public Class ucrDataLinkCombobox
    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        cboValues.DataSource = dtbRecords
    End Sub

    Private Sub cboValues_KeyDown(sender As Object, e As KeyEventArgs) Handles cboValues.KeyDown
        OnevtKeyDown(sender, e)
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Return cboValues.Items.Contains(cboValues.Text)
    End Function

    Public Overrides Function GetValue() As Object
        Return cboValues.SelectedValue
    End Function
End Class
