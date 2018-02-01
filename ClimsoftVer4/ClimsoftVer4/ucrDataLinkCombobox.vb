Public Class ucrDataLinkCombobox
    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        cboValues.DataSource = dtbRecords
    End Sub
End Class
