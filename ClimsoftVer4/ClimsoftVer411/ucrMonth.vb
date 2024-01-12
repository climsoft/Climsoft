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

        bSuppressChangedEvents = True
        dtbRecords.DefaultView.Sort = strMonthId & " ASC"
        cboValues.DataSource = dtbRecords
        cboValues.ValueMember = strMonthId
        If bFirstLoad Then
            SetViewTypeAsMonthIds()
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub

    Private Sub ucrMonth_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboValues.ContextMenuStrip = cmsMonth
    End Sub

    Public Sub SetViewTypeAsMonthsNames()
        SetDisplayMember(strMonthName)
    End Sub

    Public Sub SetViewTypeAsMonthIds()
        SetDisplayMember(strMonthId)
    End Sub

    Public Sub SetViewTypeAsShortMonthName()
        SetDisplayMember(strShortMonthName)
    End Sub

    Private Sub cmsMonthIDs_Click(sender As Object, e As EventArgs) Handles cmsMonthIDs.Click
        SetViewTypeAsMonthIds()
        cmsMonthIDs.Checked = True
        cmsMonthNames.Checked = False
        cmsMonthShortMonthNames.Checked = False
    End Sub

    Private Sub cmsMonthNames_Click(sender As Object, e As EventArgs) Handles cmsMonthNames.Click
        SetViewTypeAsMonthsNames()
        cmsMonthIDs.Checked = False
        cmsMonthNames.Checked = True
        cmsMonthShortMonthNames.Checked = False
    End Sub

    Private Sub cmsMonthShortMonthNames_Click(sender As Object, e As EventArgs) Handles cmsMonthShortMonthNames.Click
        SetViewTypeAsShortMonthName()
        cmsMonthIDs.Checked = False
        cmsMonthNames.Checked = False
        cmsMonthShortMonthNames.Checked = True
    End Sub

    Protected Overrides Sub ucrComboBoxSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            bValidateEmpty = True
            strValidationType = "exists"
            PopulateControl()
            bFirstLoad = False
        End If
    End Sub

End Class
