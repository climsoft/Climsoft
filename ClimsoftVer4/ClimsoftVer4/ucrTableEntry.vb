Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'Stores fields for the table entry
    Protected lstFields As New List(Of String)
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()


            bUpdating = dtbRecords.Rows.Count > 0

            If Not bUpdating Then
                dtbRecords.Rows.Add(dtbRecords.NewRow())
            End If

            'TODO What should happen for new records

            If bUpdating Then
                'set the values to the input controls
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueView Then
                        DirectCast(ctr, ucrValueView).SetValueFromDataTable(dtbRecords)
                    End If
                Next
            Else
                'set the values to the input controls
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueView Then
                        DirectCast(ctr, ucrValueView).SetValueToDataTable(dtbRecords)
                    End If
                Next
            End If


        End If
    End Sub

    Protected Overridable Sub SetUpTableEntry(strNewTableName As String)
        Dim ucrCtrValueView As ucrValueView

        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucrCtrValueView = DirectCast(ctr, ucrValueView)
                ucrCtrValueView.SetUpControlInParent(lstFields, AddressOf InnerControlValueChanged)
            End If
        Next
        SetTableNameAndFields(strNewTableName, lstFields)
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        'TODO update the user entered value to the data table

        If TypeOf sender Is ucrValueView Then

            DirectCast(sender, ucrValueView).SetValueToDataTable(dtbRecords)

            ' Dim ucr As ucrValueView = DirectCast(sender, ucrValueView)
            'If dtbRecords.Rows.Count = 1 Then
            '    dtbRecords.Rows(0).Item(ucr.FieldName) = ucr.GetValue
            'ElseIf dtbRecords.Rows.Count > 1 Then
            '    'TODO
            'Else
            '    'TODO
            'End If
        End If

    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'Do nothing. Overriden to prevent any default action from being taken by the parent
    End Sub

    Public Function InsertRecord() As Boolean
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Function UpdateRecord() As Boolean
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Function DeleteRecord() As Boolean
        If dtbRecords.Rows.Count = 1 Then
            dtbRecords.Rows(0).Delete()
        ElseIf dtbRecords.Rows.Count > 1 Then
            For index As Integer = 0 To dtbRecords.Rows.Count - 1
                dtbRecords.Rows(index).Delete()
            Next
        Else
            'TODO?
        End If
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Overridable Function GetFieldValue(strFieldName As String) As Object
        Dim lstTemp As New List(Of Object)

        If strFieldName = "" Then
            Return Nothing
        End If
        If dtbRecords.Rows.Count = 1 Then
            Return dtbRecords.Rows(0).Item(strFieldName)
        ElseIf dtbRecords.Rows.Count > 1 Then
            For Each tempRow As DataRow In dtbRecords.Rows
                lstTemp.Add(tempRow.Item(strFieldName))
            Next
            Return lstTemp
        Else
            Return Nothing
        End If
    End Function


End Class
