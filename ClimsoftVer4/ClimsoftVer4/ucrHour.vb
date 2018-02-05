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
        dtbRecords.Columns.Add(str24Hrs, GetType(String))
        dtbRecords.Columns.Add(str12Hrs, GetType(String))
        For i As Integer = 1 To 12

            dtbRecords.Rows.Add(CStr(i), i & " AM")
            dtbRecords.Rows.Add(CStr(i + 12), i & " PM")

        Next
        cboValues.DataSource = dtbRecords
        dtbRecords.DefaultView.Sort = str24Hrs & " ASC"

        If dtbRecords.Rows.Count > 0 Then
            cboValues.ValueMember = str24Hrs
            If bFirstLoad Then
                SetViewTypeAs24Hrs()
            End If
        Else
            cboValues.DataSource = Nothing
        End If
    End Sub

    Public Sub SetViewTypeAs24Hrs()
        SetViewType(str24Hrs)
    End Sub

    Public Sub SetViewTypeAs12Hrs()
        SetViewType(str12Hrs)
    End Sub

End Class
