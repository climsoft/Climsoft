Public Class ucrFormDaily2

    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_daily2"
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private strStationName As String
    Private strStationID As String
    Private strIDsAndStations As String

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim ctrTotal As New ucrTextBox

        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctr = ctrVFP
                ctrVFP.ucrValue.PopulateControl()
                ctrVFP.ucrFlag.PopulateControl()
                ctrVFP.ucrPeriod.PopulateControl()

            ElseIf TypeOf ctr Is ucrTextBox Then
                ctr = ctrTotal
                ctrTotal.PopulateControl()
            End If
        Next
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim d As New Dictionary(Of String, List(Of String))
        Dim ctrValue As Integer
        Dim ctr As Control
        Dim ctrtemp As New ucrValueFlagPeriod

        'Dim lstUcrValueFlagPeriod As New List(Of ucrValueFlagPeriod)

        If bFirstLoad Then
            'lstUcrValueFlagPeriod.AddRange({ucrValueFlagPeriod1, ucrValueFlagPeriod2, ucrValueFlagPeriod3, ucrValueFlagPeriod4, ucrValueFlagPeriod5})
            'For ctrValue = 0 To lstUcrValueFlagPeriod.Count - 1
            'If ctrValue < 10 Then
            '        ctrValue = "0" & ctrValue + 1
            '    Else
            '        ctrValue = ctrValue + 1
            '    End If
            '    ctrtemp.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName & ctrValue, strFlagFieldName & ctrValue, strPeriodFieldName & ctrValue)
            'Next

            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctr = ctrtemp
                    ctrtemp.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName & ctrValue, strFlagFieldName & ctrValue, strPeriodFieldName & ctrValue)
                End If
            Next

            bFirstLoad = False
            PopulateControl()
        End If
    End Sub

    Private Sub SetCtrlTableName(strTable As String)
        SetTableName(strTable)
    End Sub

    Private Sub SetCtrStationName(strStation As String)
        strStationName = strStation

    End Sub
End Class
