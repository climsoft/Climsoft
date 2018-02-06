Public Class ucrDay
    'Private strDaysTableName As String = "days"
    Private strDay As String = "day"
    Private dtb28 As DataTable
    Private dtb29 As DataTable
    Private dtb30 As DataTable
    Private dtb31 As DataTable
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth

    Public Sub InitialiseControl()
        'MyBase.PopulateControl()

        dtbRecords = New DataTable
        dtbRecords.Columns.Add(strDay, GetType(Integer))

        For i As Integer = 1 To 31
            dtb31.Rows.Add(i)
            If i <= 30 Then
                dtb30.Rows.Add(i)
            End If
            If i <= 29 Then
                dtb29.Rows.Add(i)
            End If
            If i <= 28 Then
                dtb28.Rows.Add(i)
            End If
        Next

        dtbRecords = dtb31
        cboValues.DataSource = dtbRecords


        PopulateControl()

    End Sub

    Public Overrides Sub PopulateControl()
        Dim lstLongMonths As New List(Of String)({1, 3, 5, 7, 8, 10, 12})
        'MyBase.PopulateControl()

        If ucrLinkedMonth.GetValue = 2 Then
            If Not DateTime.IsLeapYear(ucrLinkedYear.GetValue) Then
                dtbRecords = dtb28
            Else
                dtbRecords = dtb29
            End If
        Else
            If Not lstLongMonths.Contains(ucrLinkedMonth.GetValue) Then
                dtbRecords = dtb30
            Else
                dtbRecords = dtb31
            End If
        End If

        dtbRecords.DefaultView.Sort = strDay & " ASC"

        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = strDay
            If bFirstLoad Then
                SetViewTypeAsDay()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
    End Sub

    Public Sub SetViewTypeAsDay()
        SetViewType(strDay)
    End Sub

    Public Sub setYearAndMonthLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
    End Sub

End Class
