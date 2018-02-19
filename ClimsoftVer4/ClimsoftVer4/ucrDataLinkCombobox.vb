Public Class ucrDataLinkCombobox
    Protected bFirstLoad As Boolean = True
    Public bFillFromDataBase As Boolean = True

    Public Overrides Sub PopulateControl()
        If bFillFromDataBase Then
            MyBase.PopulateControl()
        End If
        cboValues.DataSource = dtbRecords
    End Sub

    Public Sub SetPossibleValues(dtbNewRecords As DataTable)
        dtbRecords = dtbNewRecords
    End Sub

    Protected Overridable Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            PopulateControl()
            bFirstLoad = False
        End If
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
            Return dtbRecords.Rows(cboValues.SelectedIndex).Field(Of Object)(strFieldName)
        Else
            Return ""
        End If

    End Function

    Public Sub SetViewType(strViewType As String)

        Dim col As DataColumn
        For Each col In dtbRecords.Columns
            If strViewType = col.ColumnName Then
                cboValues.DisplayMember = strViewType
                Exit For
            End If
        Next

    End Sub

    Private Sub cboValues_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboValues.SelectedValueChanged
        OnevtValueChanged(sender, e)
    End Sub
End Class
