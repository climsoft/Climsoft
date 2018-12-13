Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'sets table name assocaited with this user control
    Protected strTableName As String
    'Stores fields for the table entry
    Protected lstFields As New List(Of String)
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'TODO. Might not be need anymore
            bUpdating = dtbRecords.Rows.Count > 0

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueView Then
                    DirectCast(ctr, ucrValueView).SetValue(GetFieldValue(ctr.Tag))
                End If
            Next

            'raise an event value changed event
            'OnevtValueChanged(Me, Nothing)
        End If

    End Sub

    Protected Overridable Sub SetUpTableEntry()
        Dim ucrCtrValueView As ucrValueView

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView Then
                ucrCtrValueView = DirectCast(ctr, ucrValueView)
                ucrCtrValueView.SetUpControlInParent(lstFields, AddressOf InnerControlValueChanged)
            End If
        Next
        SetTableNameAndFields(strTableName, lstFields)
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        'TODO update the user entered value to the data table

    End Sub

    Public Overridable Function GetFieldValue(strFieldName As String) As Object
        Dim tempRow As DataRow
        Dim lstTemp As New List(Of Object)

        If strFieldName = "" Then
            Return Nothing
        End If
        If dtbRecords.Rows.Count = 1 Then
            Return dtbRecords.Rows(0).Item(strFieldName)
        ElseIf dtbRecords.Rows.Count > 1 Then
            For Each tempRow In dtbRecords.Rows
                lstTemp.Add(tempRow.Item(strFieldName))
            Next
            Return lstTemp
        Else
            Return Nothing
        End If

    End Function

End Class
