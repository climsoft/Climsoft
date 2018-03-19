Imports System.Data.Entity
Imports System.Linq.Dynamic

Public Class ucrSynopticRA1
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_synoptic_2_RA1"
    Private strValueFieldName As String = "Val_Elem"
    Private strFlagFieldName As String = "Flag"
    Public bUpdating As Boolean = False
    Public fs2ra1Record As form_synoptic_2_ra1
    'Private lstValueFlagPeriodControls As List(Of ucrValueFlagPeriod)

    Private lstFields As New List(Of String)
    Private ucrLinkedNavigation As ucrNavigation

    'Stores Morning time for recording tmax
    Private iTmaxHour1 As Integer
    'Stores Afternoon time for recording tmax
    Private iTmaxHour2 As Integer
    'Stores Month for starting recording of Gmin
    Private iGminStartMonth As Integer
    'Stores Month for ending recording Gmin
    Private iGminEndMonth As Integer
    'Stores default Geopotential standard pressure level
    Private iStandardPressureLevel As Integer

    Private Sub ucrSynopticRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrVFP As ucrValueFlagPeriod

        If bFirstLoad Then
            'lstValueFlagPeriodControls = New List(Of ucrValueFlagPeriod) 
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.ucrPeriod.Visible = False
                    ctrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName:=strValueFieldName & ctrVFP.Tag, strFlagFieldName:=strFlagFieldName & ctrVFP.Tag)
                    'lstValueFlagPeriodControls.Add(ctrVFP)
                    lstFields.Add(strValueFieldName & ctrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ctrVFP.Tag)
                    AddHandler ctrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ctrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            'Get the Reg Keys to determine the Tmax,Tmin,gmin
            GetRegKeys()
            SetValueValidation()
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsCurrentFilter As New TableFilter

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            If fs2ra1Record Is Nothing Then
                clsCurrentFilter = GetLinkedControlsFilter()
                fs2ra1Record = clsDataConnection.db.form_synoptic_2_ra1.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()
                If fs2ra1Record Is Nothing Then
                    fs2ra1Record = New form_synoptic_2_ra1
                    bUpdating = False
                Else
                    bUpdating = True
                End If
            End If
            For Each ctr In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
                End If
            Next
            'For Each ucrVFP In lstValueFlagPeriodControls
            '    ucrVFP.SetValue(New List(Of Object)({GetValue(strValueFieldName & ucrVFP.Tag), GetValue(strFlagFieldName & ucrVFP.Tag)}))
            'Next

            'Check if Tmax is required and change properties accordingly
            SetTmaxRequired(IsTmaxRequired())

            'check if Tmin is required and change properties accordingly. This also applies to 24Hr precipitation and 24Hr sunshine
            SetTminRequired(IsTminRequired())

            'Check if Gmin is required and change properties accordingly
            SetGminRequired(IsGminRequired())

            If Not bUpdating Then
                SetDefaultStandardPressureLevel()
            End If

        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrTextbox As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrTextbox = DirectCast(sender, ucrTextBox)
            CallByName(fs2ra1Record, ucrTextbox.GetField, CallType.Set, ucrTextbox.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As EventArgs)
        'Dim ctr As Control
        Dim ctrVFP As ucrValueFlagPeriod

        If TypeOf sender Is ucrValueFlagPeriod Then
            ctrVFP = DirectCast(sender, ucrValueFlagPeriod)
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    If ctr.Tag = ctrVFP.Tag + 1 Then
                        If ctr.Enabled Then
                            ctr.Focus()
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        fs2ra1Record = Nothing
        MyBase.LinkedControls_evtValueChanged()

        For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            CallByName(fs2ra1Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
        Next
        ucrLinkedNavigation.UpdateNavigationByKeyControls()
    End Sub

    Public Sub SetLinkedNavigation(ucrNewNavigation As ucrNavigation)
        ucrLinkedNavigation = ucrNewNavigation
    End Sub

    Public Overrides Sub Clear()
        For Each ctr In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrValueFlagPeriod).Clear()
            End If
        Next
    End Sub

    Public Sub SaveRecord()
        'THIS CAN NOW BE PUSHED TO clsDataConnection CLASS
        If bUpdating Then
            'clsDataConnection.db.fs2ra1Record.Add(fs2ra1Record)
            clsDataConnection.db.Entry(fs2ra1Record).State = Entity.EntityState.Modified
        Else
            'clsDataConnection.db.fs2ra1Record.Add(fs2ra1Record)
            clsDataConnection.db.Entry(fs2ra1Record).State = Entity.EntityState.Added
        End If

        clsDataConnection.db.SaveChanges()

    End Sub

    Public Sub DeleteRecord()
        'clsDataConnection.db.Entry(fs2ra1Record)
        clsDataConnection.db.form_synoptic_2_ra1.Attach(fs2ra1Record)
        clsDataConnection.db.form_synoptic_2_ra1.Remove(fs2ra1Record)
        clsDataConnection.db.SaveChanges()
    End Sub

    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"elementId", "lowerLimit", "upperLimit"}))
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    row = dtbl.Select("elementId = '" & ucrVFP.Tag & "'").FirstOrDefault()
                    If row IsNot Nothing Then
                        If Val(row.Item("lowerLimit")) <> 0 Then
                            ucrVFP.SetValueValidation(iLowerLimit:=Val(row.Item("lowerLimit")))
                        End If

                        If Val(row.Item("upperLimit")) <> 0 Then
                            ucrVFP.SetValueValidation(iUpperLimit:=Val(row.Item("upperLimit")))
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' checks if all the ucrValueFlagPeriod controls have a value.
    ''' Returns true if they are all empty and false if otherwise
    ''' </summary>
    ''' <returns></returns>
    Public Function IsValuesEmpty() As Boolean
        Dim ucrVFP As ucrValueFlagPeriod
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                If (Not ucrVFP.IsValueValueEmpty()) AndAlso IsNumeric(ucrVFP.GetValueValue) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' This sets the iTmaxHour1,iTmaxHour2,iGminStartMonth,iGminEndMonth variables
    ''' by getting the values from the regkeys database table
    ''' </summary>
    Private Sub GetRegKeys()
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim row As DataRow

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableName("regkeys")
        clsDataDefinition.SetFields(New List(Of String)({"keyName", "keyValue"}))
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then

            'Get Geopotential standard pressure level
            row = dtbl.Select("keyName = 'key00'").FirstOrDefault()
            iStandardPressureLevel = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get morning time for recording tmax 
            row = dtbl.Select("keyName = 'key01'").FirstOrDefault()
            iTmaxHour1 = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get afternoon time for recording tmax 
            row = dtbl.Select("keyName = 'key02'").FirstOrDefault()
            iTmaxHour2 = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get the month for starting record of Gmin
            row = dtbl.Select("keyName = 'key03'").FirstOrDefault()
            iGminStartMonth = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)

            'Get the month for ending record of Gmin
            row = dtbl.Select("keyName = 'key04'").FirstOrDefault()
            iGminEndMonth = If(row IsNot Nothing, Val(row.Item("keyValue")), 0)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPTmax control based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetTmaxRequired(bRequired As Boolean)
        If bRequired Then
            'Apply required action to Tmax
            ucrVFPTmax.Enabled = True
            ucrVFPTmax.SetBackColor(Color.White)
        Else
            ucrVFPTmax.Enabled = False
            ucrVFPTmax.SetBackColor(Color.LightGray)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPTmin,ucrVFPEvaporation,ucrVFPSss24Hr,ucrVFPPrecip24Hr and ucrVFPInsolation controls based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetTminRequired(bRequired As Boolean)
        If bRequired Then
            'Apply required action to Tmin
            ucrVFPTmin.Enabled = True
            ucrVFPTmin.SetBackColor(Color.White)

            'Apply same action to evaporation
            ucrVFPEvaporation.Enabled = True
            ucrVFPEvaporation.SetBackColor(Color.White)

            'Apply same action to 24Hr sunshine
            ucrVFPSss24Hr.Enabled = True
            ucrVFPSss24Hr.SetBackColor(Color.White)

            'Apply same action to 24Hr precip
            ucrVFPPrecip24Hr.Enabled = True
            ucrVFPPrecip24Hr.SetBackColor(Color.White)

            'Apply same action to 24Hr radiation (Insolation)
            ucrVFPInsolation.Enabled = True
            ucrVFPInsolation.SetBackColor(Color.White)

        Else
            ucrVFPTmin.Enabled = False
            ucrVFPTmin.SetBackColor(Color.LightGray)

            ucrVFPEvaporation.Enabled = False
            ucrVFPEvaporation.SetBackColor(Color.LightGray)

            ucrVFPSss24Hr.Enabled = False
            ucrVFPSss24Hr.SetBackColor(Color.LightGray)

            ucrVFPPrecip24Hr.Enabled = False
            ucrVFPPrecip24Hr.SetBackColor(Color.LightGray)

            ucrVFPInsolation.Enabled = False
            ucrVFPInsolation.SetBackColor(Color.LightGray)
        End If
    End Sub

    ''' <summary>
    ''' Enables or disables the ucrVFPGrassMinTemp control based on
    ''' whether its required or not
    ''' </summary>
    ''' <param name="bRequired"></param>
    Private Sub SetGminRequired(bRequired As Boolean)
        If bRequired Then
            ucrVFPGrassMinTemp.Enabled = True
            ucrVFPGrassMinTemp.SetBackColor(Color.White)
        Else
            ucrVFPGrassMinTemp.Enabled = False
            ucrVFPGrassMinTemp.SetBackColor(Color.LightGray)
        End If
    End Sub

    Private Function IsTmaxRequired() As Boolean
        Dim iHour As Integer
        'get the hour value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
                Exit For
            End If
        Next

        Return (iHour = iTmaxHour1 OrElse iHour = iTmaxHour2)
    End Function

    Private Function IsTminRequired() As Boolean
        Dim iHour As Integer
        'get the hour value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
                Exit For
            End If
        Next

        'tmaxHour1 is the tmin
        Return (iHour = iTmaxHour1)
    End Function

    Private Function IsGminRequired() As Boolean
        Dim iMonth As Integer
        Dim iHour As Integer
        'get the month and the hour value
        For Each ucrKeyControl As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If TypeOf ucrKeyControl Is ucrMonth Then
                iMonth = Val(ucrKeyControl.GetValue)
            ElseIf TypeOf ucrKeyControl Is ucrHour Then
                iHour = Val(ucrKeyControl.GetValue)
            End If
        Next

        Return (iMonth >= iGminStartMonth AndAlso iMonth < iGminEndMonth AndAlso iHour = 6)
    End Function

    'I reached here
    Public Sub SetDefaultStandardPressureLevel()
        ucrVFPStandardPressureLevel.SetValue(New List(Of Object)({iStandardPressureLevel.ToString}))
        'ucrVFPStandardPressureLevel.ucrValue.SetValue(iStandardPressureLevel.ToString)

    End Sub
End Class
