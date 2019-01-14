Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'Stores fields for the table entry
    Protected lstFields As New List(Of String)
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True
    Public bPopulating As Boolean = False

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            bPopulating = True

            MyBase.PopulateControl()

            bUpdating = dtbRecords.Rows.Count > 0

            If Not bUpdating Then
                dtbRecords.Rows.Add(dtbRecords.NewRow())
            End If

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueView Then
                    DirectCast(ctr, ucrValueView).SetValueFromDataTable(dtbRecords)
                End If
            Next
            bPopulating = False
        End If
    End Sub

    Protected Overridable Sub SetUpTableEntry(strNewTableName As String)
        Dim ucrCtrValueView As ucrValueView

        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucrCtrValueView = DirectCast(ctr, ucrValueView)
                ucrCtrValueView.SetUpControlInParent(lstFields, AddressOf InnerControlValueChanged)
                AddHandler ucrCtrValueView.evtKeyDown, AddressOf GoToNextChildControl
            End If
        Next
        SetTableNameAndFields(strNewTableName, lstFields)
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucr As ucrValueView
        If TypeOf sender Is ucrValueView Then
            If Not bPopulating Then
                ucr = DirectCast(sender, ucrValueView)
                If ucr.ValidateValue() Then
                    ucr.SetValueToDataTable(dtbRecords)
                End If
            End If

        End If

    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'Do nothing. Overriden to prevent any default action from being taken by the parent
    End Sub

    Private Sub GoToNextChildControl(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrValueView Then
                If DirectCast(sender, ucrValueView).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the "noise" on  return key down
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim ucr As ucrValueView
        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucr = DirectCast(ctr, ucrValueView)
                If Not String.IsNullOrEmpty(ucr.FieldName) AndAlso Not ucr.ValidateValue() Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

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
