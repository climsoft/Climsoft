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
        bFillFromDataBase = False
    End Sub

    Public Sub SetPossibleValues(strColumnName As String, tColumnType As Type, lstValues As IEnumerable(Of Object))
        SetPossibleValues(New DataTable)
        dtbRecords.Columns.Add(strColumnName, tColumnType)
        For Each objVal In lstValues
            dtbRecords.Rows.Add(objVal)
        Next
    End Sub
    'NOT SURE ABOUT THIS BUT I SUSPECT IT NEEDS TO BE OVERRIDEN 
    'ALTERANITIVELY WE COULD OVERRIDE THE sub UpdateDataTable() 
    Protected Overrides Sub LinkedControls_evtValueChanged()
        If Not IsNothing(clsDataDefinition) Then
            Dim objData As List(Of String)
            Dim strDbValue As String
            objData = clsDataDefinition.GetValues(GetLinkedControlsFilter())
            If objData.Count > 0 Then
                strDbValue = objData(0)
                For index As Integer = 0 To dtbRecords.Rows.Count - 1
                    If dtbRecords.Rows(index).Field(Of String)(0) = strDbValue Then
                        cboValues.SelectedIndex = index
                    End If
                Next
            End If
        End If
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

        If dtbRecords IsNot Nothing AndAlso dtbRecords.Rows.Count > 0 Then
            If cboValues.SelectedIndex > -1 Then
                Return dtbRecords.Rows(cboValues.SelectedIndex).Field(Of Object)(strFieldName)
            Else
                Return Nothing
            End If

        Else
            Return Nothing
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
