Public Class ucrMonthlydata
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_monthly"
    Private strValueFieldName As String = "mm_"
    Private strFlagFieldName As String = "Flag"
    Private strPeriodFieldName As String = "Period"
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedElement As ucrElementSelector
    Private ucrLinkedYear As ucrYearSelector

    Public Overrides Sub PopulateControl()
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        MyBase.PopulateControl()
        If Not bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.PopulateControl()
                End If
            Next
        End If
    End Sub

    Private Sub ucrMonthlydata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod
        Dim lstTempFields As New List(Of String)

        If bFirstLoad Then
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = ctr
                    ctrVFP.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName & ctrVFP.Tag, strFlagFieldName & ctrVFP.Tag, strPeriodFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strFlagFieldName & ctrVFP.Tag)
                    lstTempFields.Add(strPeriodFieldName & ctrVFP.Tag)
                End If
            Next
            SetTableName(strTableName)
            SetFields(lstTempFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        Dim ctr As Control
        Dim ctrVFP As New ucrValueFlagPeriod

        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
            End If
        Next
    End Sub

    Public Sub setStationElementYearLink(ucrStationControl As ucrStationSelector, ucrElementControl As ucrElementSelector, ucrYearControl As ucrYearSelector)
        ucrLinkedStation = ucrStationControl
        ucrLinkedElement = ucrElementControl
        ucrLinkedYear = ucrYearControl
    End Sub

    Public Sub Clear()
        Dim ctr As Control
        Dim ctrVFP As ucrValueFlagPeriod

        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ctrVFP = ctr
                ctrVFP.Clear()
            End If
        Next
    End Sub
End Class
