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

    Private Sub ucrMonth_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboValues.ContextMenuStrip = cmsMonth
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
End Class
