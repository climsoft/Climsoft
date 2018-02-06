Public Class ucrYearSelector
    'Private strYearsTableName As String = "years"
    Private strYear As String = "Year"
    Private strShortYear As String = "ShortYear"

    Public Overrides Sub PopulateControl()
        'MyBase.PopulateControl()

        Dim endYear As Integer = DateAndTime.Year(DateTime.Today)

        dtbRecords = New DataTable
        dtbRecords.Columns.Add(strYear, GetType(Integer))
        dtbRecords.Columns.Add(strShortYear, GetType(Integer))

        For i As Integer = endYear To endYear - 5 Step -1
            dtbRecords.Rows.Add(i, CInt(Strings.Right(i, 2)))
        Next

        cboValues.DataSource = dtbRecords
        dtbRecords.DefaultView.Sort = strYear & " DESC"

        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = strYear
            If bFirstLoad Then
                SetViewTypeAsYear()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
    End Sub

    Public Sub SetViewTypeAsYear()
        SetViewType(strYear)
    End Sub

    Public Sub SetViewTypeAsShortYear()
        SetViewType(strShortYear)
    End Sub

End Class
