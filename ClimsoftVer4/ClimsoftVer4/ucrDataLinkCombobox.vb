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

    Public Overrides Function GetValue(strFieldName As String) As Object

        If strFieldName = "" Then
            Return GetValue()
        End If

        If dtbRecords.Rows.Count > 0 Then
            Return dtbRecords.Rows(cboValues.SelectedIndex).Field(Of String)(strFieldName)
        Else
            Return ""
        End If
    End Function

End Class
