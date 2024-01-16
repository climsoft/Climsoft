Public Class ucrHour
    'Private strHoursTableName As String = "hours"
    Private str24Hrs As String = "24Hrs"
    Private str12Hrs As String = "12Hrs"
    'TODO
    'Add swahili time
    'Private strSwahiliHrs As String = "SwahiliHrs"

    Public Overrides Sub PopulateControl()
        'MyBase.PopulateControl()

        dtbRecords = New DataTable
        dtbRecords.Columns.Add(str24Hrs, GetType(Integer))
        dtbRecords.Columns.Add(str12Hrs, GetType(String))
        For i As Integer = 0 To 11
            dtbRecords.Rows.Add(i, i & " AM")
            dtbRecords.Rows.Add(i + 12, i & " PM")
        Next

        bSuppressChangedEvents = True
        dtbRecords.DefaultView.Sort = str24Hrs & " ASC"
        cboValues.DataSource = dtbRecords
        cboValues.ValueMember = str24Hrs
        If bFirstLoad Then
            SetViewTypeAs24Hrs()
        End If
        bSuppressChangedEvents = False
        'OnevtValueChanged(Me, Nothing)
    End Sub


    Private Sub ucrHour_Load(sender As Object, e As EventArgs) Handles Me.Load
        cboValues.ContextMenuStrip = cmsHour
    End Sub
    Public Sub SetViewTypeAs24Hrs()
        SetDisplayMember(str24Hrs)
    End Sub

    Public Sub SetViewTypeAs12Hrs()
        SetDisplayMember(str12Hrs)
    End Sub

    Private Sub cmsHour24_Click(sender As Object, e As EventArgs) Handles cmsHour24.Click
        SetViewTypeAs24Hrs()
        cmsHour24.Checked = True
        cmsHour12.Checked = False
    End Sub

    Private Sub cmsHour12_Click(sender As Object, e As EventArgs) Handles cmsHour12.Click
        SetViewTypeAs12Hrs()
        cmsHour24.Checked = False
        cmsHour12.Checked = True
    End Sub
End Class
