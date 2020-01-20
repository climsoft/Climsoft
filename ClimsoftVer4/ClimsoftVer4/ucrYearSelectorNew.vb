Public Class ucrYearSelectorNew
    Private strYear As String = "Year"
    Private strShortYear As String = "ShortYear"
    Private dtbRecords As DataTable
    Public Sub PopulateControl()
        'MyBase.PopulateControl()
        Dim endYear As Integer = Date.Now.Year

        dtbRecords = New DataTable
        dtbRecords.Columns.Add(strYear, GetType(Integer))
        dtbRecords.Columns.Add(strShortYear, GetType(Integer))

        For i As Integer = endYear To endYear - 5 Step -1
            dtbRecords.Rows.Add(i, CInt(Strings.Right(i, 2)))
        Next

        bSuppressChangedEvents = True
        dtbRecords.DefaultView.Sort = strYear & " DESC"
        cboValues.DataSource = dtbRecords
        cboValues.ValueMember = strYear
        If bFirstLoad Then
            SetViewTypeAsYear()
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Public Function IsLeapYear() As Boolean
        Return Date.IsLeapYear(GetValue)
    End Function

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean = False
        Dim strCol As String
        Dim iYear As Integer
        bValid = MyBase.ValidateValue()
        If Not bValid Then
            strCol = cboValues.DisplayMember
            'check if its an integer first
            If Integer.TryParse(cboValues.Text, iYear) Then
                Select Case strCol
                    Case strYear
                        If cboValues.Text.Length = 4 AndAlso iYear <= Date.Now.Year Then
                            bValid = True
                        End If
                    Case strShortYear
                        'TODO
                        'check validity of short years
                End Select
            End If
            SetBackColor(If(bValid, clValidColor, clInValidColor))
        End If

        Return bValid
    End Function

    Protected Overrides Sub ucrCombobox_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            cboValues.ContextMenuStrip = cmsYear
            'bValidateEmpty = True
            'strValidationType = "numeric"
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

    Public Sub SetViewTypeAsYear()
        SetDisplayMember(strYear)
    End Sub

    Public Sub SetViewTypeAsShortYear()
        SetDisplayMember(strShortYear)
    End Sub

    Private Sub cmsYearViewLongYear_Click(sender As Object, e As EventArgs) Handles cmsYearViewLongYear.Click
        SetViewTypeAsYear()
        cmsYearViewShortYear.Checked = False
        cmsYearViewLongYear.Checked = True
    End Sub

    Private Sub cmsYearViewShortYear_Click(sender As Object, e As EventArgs) Handles cmsYearViewShortYear.Click
        SetViewTypeAsShortYear()
        cmsYearViewShortYear.Checked = True
        cmsYearViewLongYear.Checked = False
    End Sub
End Class
