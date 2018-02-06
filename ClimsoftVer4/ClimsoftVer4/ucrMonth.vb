Public Class ucrMonth
    'Private strMonthsTableName As String = "months"
    Private strMonthName As String = "MonthName"
    Private strMonthId As String = "MonthId"
    Private strShortMonthName As String = "ShortMonthName"

    Public Overrides Sub PopulateControl()
        'MyBase.PopulateControl()

        dtbRecords = New DataTable
        dtbRecords.Columns.Add(strMonthId, GetType(Integer))
        dtbRecords.Columns.Add(strMonthName, GetType(String))
        dtbRecords.Columns.Add(strShortMonthName, GetType(String))
        For i As Integer = 1 To 12
            dtbRecords.Rows.Add(i, DateAndTime.MonthName(i, False), DateAndTime.MonthName(i, True))
        Next
        cboValues.DataSource = dtbRecords
        dtbRecords.DefaultView.Sort = strMonthId & " ASC"

        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = strMonthId
            If bFirstLoad Then
                SetViewTypeAsMonthIds()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
    End Sub

    Public Sub SetViewTypeAsMonthsNames()
        SetViewType(strMonthName)
    End Sub

    Public Sub SetViewTypeAsMonthIds()
        SetViewType(strMonthId)
    End Sub

    Public Sub SetViewTypeAsShortMonthName()
        SetViewType(strShortMonthName)
    End Sub

End Class
