Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'sets table name assocaited with this user control
    Protected strTableName As String
    'Stores fields for the value flag and period
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
                If TypeOf ctr Is ucrTextBox OrElse TypeOf ctr Is ucrDatePicker Then
                    DirectCast(ctr, ucrBaseDataLink).SetValue(GetValue(ctr.Tag))
                End If
            Next

            'raise an event value changed event
            OnevtValueChanged(Me, Nothing)
        End If

    End Sub

    Protected Overridable Sub ucrTableEntry_Load(sender As Object, e As EventArgs) Handles Me.Load

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrTextBox OrElse TypeOf ctr Is ucrDatePicker Then
                lstFields.Add(ctr.Tag)
                AddHandler DirectCast(ctr, ucrBaseDataLink).evtValueChanged, AddressOf InnerControlValueChanged
            End If
        Next

        SetTableNameAndFields(strTableName, lstFields)

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        'TODO update the user entered value to the data table
    End Sub
End Class
