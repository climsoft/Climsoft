Public Class ucrDay
    'Private strDaysTableName As String = "days"
    Private strDay As String = "Day"
    'TODO
    'Is it necessary to have 4 datatables for this control?
    Private dtb28 As DataTable
    Private dtb29 As DataTable
    Private dtb30 As DataTable
    Private dtb31 As DataTable
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth

    Public Sub InitialiseControl()
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
    End Sub

    Public Overrides Sub PopulateControl()
        If bFirstLoad Then
            InitialiseControl()
        End If

        Dim lstShortMonths As New List(Of String)({4, 6, 9, 11})
        Dim iMonth As Integer

        iMonth = If(ucrLinkedMonth Is Nothing, 1, ucrLinkedMonth.GetValue)
        If iMonth = 2 Then
            dtbRecords = If(ucrLinkedYear Is Nothing, dtb29, (If(DateTime.IsLeapYear(ucrLinkedYear.GetValue), dtb29, dtb28)))
        Else
            dtbRecords = If(lstShortMonths.Contains(iMonth), dtb30, dtb31)
        End If

        bSuppressChangedEvents = True
        dtbRecords.DefaultView.Sort = strDay & " ASC"
        cboValues.DataSource = dtbRecords
        cboValues.ValueMember = strDay
        If bFirstLoad Then
            SetViewTypeAsDay()
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Public Sub SetViewTypeAsDay()
        SetDisplayMember(strDay)
    End Sub

    ''' <summary>
    ''' links this control to the year and month control
    ''' </summary>
    ''' <param name="ucrYearControl"></param>
    ''' <param name="ucrMonthControl"></param>
    Public Sub setYearAndMonthLink(ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth)
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        'add event handler for the 2 controls
        AddHandler ucrLinkedYear.evtValueChanged, AddressOf YearMonthEvtValueChanged
        AddHandler ucrLinkedMonth.evtValueChanged, AddressOf YearMonthEvtValueChanged
    End Sub

    ''' <summary>
    ''' this gets called when the linked year or month controls change their values
    ''' </summary>
    Private Sub YearMonthEvtValueChanged()
        If ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue Then
            Dim iCurrentSelectedDay As Integer
            'store the current selected value to retain it after repopulating the control
            If Integer.TryParse(GetValue(strDay), iCurrentSelectedDay) Then
                PopulateControl()
                If dtbRecords IsNot Nothing AndAlso dtbRecords.Rows.Count < iCurrentSelectedDay Then
                    iCurrentSelectedDay = dtbRecords.Rows.Count
                End If
                SetValue(iCurrentSelectedDay)
            Else
                PopulateControl()
            End If
        End If
    End Sub


End Class
