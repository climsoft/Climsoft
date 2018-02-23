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
        'MyBase.InitialiseControl()
        dtb31 = New DataTable
        dtb30 = New DataTable
        dtb29 = New DataTable
        dtb28 = New DataTable

        dtb31.Columns.Add(strDay, GetType(Integer))
        dtb30.Columns.Add(strDay, GetType(Integer))
        dtb29.Columns.Add(strDay, GetType(Integer))
        dtb28.Columns.Add(strDay, GetType(Integer))

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

    End Sub

    Public Overrides Sub PopulateControl()
        'MyBase.PopulateControl()
        Dim lstShortMonths As New List(Of String)({4, 6, 9, 11})
        Dim iMonth As Integer

        If ucrLinkedMonth Is Nothing Then
            iMonth = 1
        Else
            iMonth = ucrLinkedMonth.GetValue
        End If
        If iMonth = 2 Then
            If Not DateTime.IsLeapYear(ucrLinkedYear.GetValue) Then
                dtbRecords = dtb28
            Else
                dtbRecords = dtb29
            End If
        Else
            If lstShortMonths.Contains(iMonth) Then
                dtbRecords = dtb30
            Else
                dtbRecords = dtb31
            End If
        End If

        If dtbRecords IsNot Nothing Then
            dtbRecords.DefaultView.Sort = strDay & " ASC"
            If dtbRecords.Rows.Count > 0 Then
                cboValues.ValueMember = strDay
                If bFirstLoad Then
                    SetViewTypeAsDay()
                End If
            Else
                cboValues.DataSource = Nothing
            End If
        End If
    End Sub

    Public Sub SetViewTypeAsDay()
        SetViewType(strDay)
    End Sub

    Public Sub setYearAndMonthLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
    End Sub


    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseControl()
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

End Class
