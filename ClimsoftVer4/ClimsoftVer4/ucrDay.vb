Public Class ucrDay
    'Private strDaysTableName As String = "days"
    Private strDay As String = "day"
    'Private dtb28 As DataTable
    'Private dtb29 As DataTable
    'Private dtb30 As DataTable
    'Private dtb31 As DataTable
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth

    'Public Sub InitialiseControl()
    '    dtb31 = New DataTable
    '    dtb30 = New DataTable
    '    dtb29 = New DataTable
    '    dtb28 = New DataTable

    '    dtb31.Columns.Add(strDay, GetType(Integer))
    '    dtb30.Columns.Add(strDay, GetType(Integer))
    '    dtb29.Columns.Add(strDay, GetType(Integer))
    '    dtb28.Columns.Add(strDay, GetType(Integer))

    '    For i As Integer = 1 To 31
    '        dtb31.Rows.Add(i)
    '        If i <= 30 Then
    '            dtb30.Rows.Add(i)
    '        End If
    '        If i <= 29 Then
    '            dtb29.Rows.Add(i)
    '        End If
    '        If i <= 28 Then
    '            dtb28.Rows.Add(i)
    '        End If
    '    Next
    '    dtbRecords = dtb31
    'End Sub

    'Public Overrides Sub PopulateControl()
    '    'MyBase.PopulateControl()
    '    Dim lstShortMonths As New List(Of String)({4, 6, 9, 11})
    '    Dim iMonth As Integer

    '    iMonth = If(ucrLinkedMonth Is Nothing, 1, ucrLinkedMonth.GetValue)
    '    If iMonth = 2 Then
    '        dtbRecords = If(ucrLinkedYear Is Nothing, dtb29, (If(DateTime.IsLeapYear(ucrLinkedYear.GetValue), dtb29, dtb28)))
    '    Else
    '        dtbRecords = If(lstShortMonths.Contains(iMonth), dtb30, dtb31)
    '    End If

    '    If dtbRecords IsNot Nothing Then
    '        dtbRecords.DefaultView.Sort = strDay & " ASC"
    '        If dtbRecords.Rows.Count > 0 Then
    '            cboValues.DataSource = dtbRecords
    '            cboValues.ValueMember = strDay
    '            If bFirstLoad Then
    '                SetViewTypeAsDay()
    '            End If
    '        Else
    '            cboValues.DataSource = Nothing
    '        End If
    '    End If
    'End Sub

    ''' <summary>
    ''' sets up the datatable
    ''' </summary>
    Public Sub InitialiseControl()
        dtbRecords = New DataTable
        dtbRecords.Columns.Add(strDay, GetType(Integer))
    End Sub
    Public Overrides Sub PopulateControl()
        'MyBase.PopulateControl()
        Dim lstShortMonths As New List(Of String)({4, 6, 9, 11})
        Dim iMonth As Integer
        Dim iNumOfDays As Integer

        'get the correct number of days
        iMonth = If(ucrLinkedMonth Is Nothing, 1, ucrLinkedMonth.GetValue)
        If iMonth = 2 Then
            iNumOfDays = If(ucrLinkedYear Is Nothing, 29, (If(DateTime.IsLeapYear(ucrLinkedYear.GetValue), 29, 28)))
        Else
            iNumOfDays = If(lstShortMonths.Contains(iMonth), 30, 31)
        End If

        'set up the datatable. 
        'we redo this here to prevent errors that maybe cause during concurrency in GetValue
        InitialiseControl()

        'fill in the days to show
        For i As Integer = 1 To iNumOfDays
            dtbRecords.Rows.Add(i)
        Next

        dtbRecords.DefaultView.Sort = strDay & " ASC"
            If dtbRecords.Rows.Count > 0 Then
                cboValues.DataSource = dtbRecords
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
        'add event handler for the 2 controls
        AddHandler ucrLinkedYear.evtValueChanged, AddressOf YearMonthEvtValueChanged
        AddHandler ucrLinkedMonth.evtValueChanged, AddressOf YearMonthEvtValueChanged
    End Sub

    Private Sub YearMonthEvtValueChanged()
        PopulateControl()
    End Sub

    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            InitialiseControl()
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

End Class
