Imports System.Data.Entity
Imports System.Linq.Dynamic
Public Class ucrMonthlydata
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_monthly"
    Private strValueFieldName As String = "mm_"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    'Stores fields for the value flag and period
    Private lstFields As New List(Of String)
    'Stores the record assocaited with this control
    Public fmonthlyRecord As form_monthly
    'Boolean to check if record is updating
    'Set to True by default
    Public bUpdating As Boolean = True
    'stores a list containing all fields of this control
    Private lstAllFields As New List(Of String)

    'These store instances of linked controls
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedElement As ucrElementSelector
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedNavigation As ucrNavigation

    Public Overrides Sub PopulateControl()

        Dim clsCurrentFilter As TableFilter
        Dim tempRecord As form_monthly

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'TODO. Might not be need anymore
            bUpdating = dtbRecords.Rows.Count > 0

            'check whether to permit data entry based on date entry values
            ValidateDataEntryPermission()

            'set the validation of the controls
            SetValueValidation()

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetValue(strValueFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag), GetValue(strPeriodFieldName & ctr.Tag)}))
                End If
            Next

            OnevtValueChanged(Me, Nothing)

        End If
    End Sub

    Private Sub ucrMonthlydata_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ucrVFP As ucrValueFlagPeriod
        Dim vfpContextMenuStrip As ContextMenuStrip
        If bFirstLoad Then
            vfpContextMenuStrip = SetUpContextMenuStrip()

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    lstFields.Add(strValueFieldName & ucrVFP.Tag)
                    lstFields.Add(strFlagFieldName & ucrVFP.Tag)
                    lstFields.Add(strPeriodFieldName & ucrVFP.Tag)
                    ucrVFP.SetTableNameAndValueFlagPeriodFields(strTableName, strValueFieldName:=strValueFieldName & ucrVFP.Tag, strFlagFieldName:=strFlagFieldName & ucrVFP.Tag, strPeriodFieldName:=strPeriodFieldName & ucrVFP.Tag)

                    AddHandler ucrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.ucrPeriod.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl

                    ucrVFP.SetContextMenuStrip(vfpContextMenuStrip)

                End If
            Next

            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrText As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrText = DirectCast(sender, ucrTextBox)
            'CallByName(fmonthlyRecord, ucrText.GetField, CallType.Set, ucrText.GetValue)
        End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As KeyEventArgs)
        Dim ucrVFP As ucrValueFlagPeriod
        Dim iMonth As Integer = 0

        'for last control
        If TypeOf sender Is ucrValueFlagPeriod Then
            ucrVFP = DirectCast(sender, ucrValueFlagPeriod)
            iMonth = Val(ucrVFP.Tag)

            If ucrLinkedYear IsNot Nothing AndAlso ucrLinkedYear.ValidateValue() Then
                ucrVFP.SetElementPeriodValue(Date.DaysInMonth(ucrLinkedYear.GetValue, iMonth))
            End If
        End If

        If iMonth = 12 Then
            Me.FindForm.SelectNextControl(sender, True, True, True, True)
        Else
            SelectNextControl(sender, True, True, True, True)
        End If
        'this handles the "noise" on enter  
        e.SuppressKeyPress = True

    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        Dim bValidValues As Boolean = True

        'validate the values of the linked key filter controls
        For Each key As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If Not key.ValidateValue() Then
                bValidValues = False
                Exit For
            End If
        Next

        If bValidValues Then
            'fd2Record = Nothing
            MyBase.LinkedControls_evtValueChanged()

            For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
                'CallByName(fmonthlyRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            Next
            ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. DISABLE??
            'Me.Enabled = False
        End If
    End Sub

    Public Sub SaveRecord()
        'If bUpdating Then
        '    clsDataConnection.db.Entry(fmonthlyRecord).State = Entity.EntityState.Modified
        'Else
        '    'This is determined by the current user not set from the form
        '    fmonthlyRecord.signature = frmLogin.txtUsername.Text
        '    fmonthlyRecord.entryDatetime = Date.Now()
        '    clsDataConnection.db.Entry(fmonthlyRecord).State = Entity.EntityState.Added
        'End If

        'clsDataConnection.db.SaveChanges()
        ''detach the record to prevent caching of records on the EF
        'clsDataConnection.db.Entry(fmonthlyRecord).State = Entity.EntityState.Detached
    End Sub

    Public Sub DeleteRecord()
        'clsDataConnection.db.form_monthly.Attach(fmonthlyRecord)
        'clsDataConnection.db.form_monthly.Remove(fmonthlyRecord)
        'clsDataConnection.db.SaveChanges()
    End Sub

    ''' <summary>
    ''' Clears all the text In the ucrValueFlagPeriod controls 
    ''' </summary>
    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrValueFlagPeriod).Clear()
            End If
        Next
    End Sub

    Public Function IsValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If Not DirectCast(ctr, ucrValueFlagPeriod).IsElementValueEmpty() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' checks if all the ucrValueFlagPeriod controls have a Valid value.
    ''' Returns true if they are all valid and false if any has Invalid value
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If Not DirectCast(ctr, ucrValueFlagPeriod).ValidateValue Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Sets upper and lower limits validation curent element
    ''' </summary>
    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrLinkedElement.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = dtbl.Rows(0).Item("lowerLimit")
            strUpperLimit = dtbl.Rows(0).Item("upperLimit")
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)

                If String.IsNullOrEmpty(strLowerLimit) Then
                    ucrVFP.SetElementValueLowerLimit(Decimal.MinValue)
                Else
                    ucrVFP.SetElementValueLowerLimit(Val(strLowerLimit))
                End If

                If String.IsNullOrEmpty(strUpperLimit) Then
                    ucrVFP.SetElementValueHigherLimit(Decimal.MaxValue)
                Else
                    ucrVFP.SetElementValueHigherLimit(Val(strUpperLimit))
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Sets the key controls
    ''' </summary>
    ''' <param name="ucrNewStation"></param>
    ''' <param name="ucrNewElement"></param>
    ''' <param name="ucrNewYear"></param>
    ''' <param name="ucrNewNavigation"></param> 
    ''' 
    Public Sub SetKeyControls(ucrNewStation As ucrStationSelector, ucrNewElement As ucrElementSelector, ucrNewYear As ucrYearSelector, ucrNewNavigation As ucrNavigation)
        ucrLinkedStation = ucrNewStation
        ucrLinkedElement = ucrNewElement
        ucrLinkedYear = ucrNewYear
        ucrLinkedNavigation = ucrNewNavigation

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedElement, "elementId", "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)

        'Sets key controls for the navigation
        'TODO. EntryDateTime field to be added and sorting field to be set too
        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "elementId", "yyyy"})))
        'ucrLinkedNavigation.SetSortBy("entryDatetime")
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("elementId", ucrLinkedElement)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetSortBy("entryDatetime")
    End Sub

    Private Sub ValidateDataEntryPermission()
        If ucrLinkedYear IsNot Nothing AndAlso ucrLinkedYear.ValidateValue Then
            Me.Enabled = (ucrLinkedYear.GetValue <= Date.Now.Year)
        Else
            Me.Enabled = False
        End If
    End Sub

    'upload code in the background thread
    Public Sub UploadAllRecords()
        Dim frm As New frmNewComputationProgress
        frm.SetHeader("Uploading " & ucrLinkedNavigation.iMaxRows & " records")
        frm.SetProgressMaximum(ucrLinkedNavigation.iMaxRows)
        frm.ShowResultMessage(True)
        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

        'TODO. temporary. Pass the connection string . The current connection properties are being stored in control
        'Once this is fixed, the argument can be removed
        frm.backgroundWorker.RunWorkerAsync(frmLogin.txtusrpwd.Text)

        frm.Show()
    End Sub

    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim clsAllRecordsCall As New DataCall
        Dim dtbAllRecords As DataTable
        Dim strTag As String
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strPeriodColumn As String
        Dim iPeriod As Integer
        Dim strStationId As String
        Dim lElementId As Long
        Dim dtObsDateTime As Date
        Dim lstAllFields As New List(Of String)
        Dim bUpdateRecord As Boolean
        Dim strSql As String
        Dim strSignature As String
        Dim conn As MySql.Data.MySqlClient.MySqlConnection
        Dim cmd As MySql.Data.MySqlClient.MySqlCommand
        Dim pos As Integer = 0

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        conn = New MySql.Data.MySqlClient.MySqlConnection
        Try
            'Temporary.The current connection properties are being stored in control, this line can be removed in future
            conn.ConnectionString = e.Argument
            conn.Open()

            For Each row As DataRow In dtbAllRecords.Rows
                If backgroundWorker.CancellationPending = True Then
                    e.Cancel = True
                    Exit For
                End If
                'Display progress of data transfer
                pos = pos + 1
                backgroundWorker.ReportProgress(pos)


                For Each strFieldName As String In lstFields
                    'if its not an observation value field then skip the loop
                    If Not strFieldName.StartsWith(Me.strValueFieldName) Then
                        Continue For
                    End If

                    strValueColumn = strFieldName
                    'set the record
                    If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                        strStationId = row.Item("stationId")
                        strTag = strFieldName.Substring(Me.strValueFieldName.Length)
                        strFlagColumn = lstFields.Find(Function(x As String)
                                                           Return x.Equals(Me.strFlagFieldName & strTag)
                                                       End Function)
                        strPeriodColumn = lstFields.Find(Function(x As String)
                                                             Return x.Equals(Me.strPeriodFieldName & strTag)
                                                         End Function)
                        dtObsDateTime = New Date(row.Item("yyyy"), Val(strTag), 1, 6, 0, 0)

                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        cmd = New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
                        cmd.Parameters.AddWithValue("@stationId", strStationId)
                        cmd.Parameters.AddWithValue("@elemCode", lElementId)
                        cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                        cmd.Parameters.AddWithValue("@qcStatus", 0)
                        cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                        cmd.Parameters.AddWithValue("@dataForm", strTableName)

                        bUpdateRecord = False
                        Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                            bUpdateRecord = reader.HasRows
                        End Using

                        Integer.TryParse(row.Item(strPeriodColumn), iPeriod)

                        strSignature = ""

                        If Not IsDBNull(row.Item("signature")) Then
                            strSignature = row.Item("signature")
                        End If

                        If bUpdateRecord Then
                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,period=@obsPeriod,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm " &
                                " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Else
                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,capturedBy,dataForm) " &
                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@obsPeriod,@qcStatus,@acquisitiontype,@capturedBy,@dataForm)"
                        End If

                        cmd = New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
                        cmd.Parameters.AddWithValue("@stationId", strStationId)
                        cmd.Parameters.AddWithValue("@elemCode", lElementId)
                        cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                        cmd.Parameters.AddWithValue("@obsLevel", "surface")
                        cmd.Parameters.AddWithValue("@obsVal", row.Item(strValueColumn))
                        cmd.Parameters.AddWithValue("@obsFlag", row.Item(strFlagColumn))
                        cmd.Parameters.AddWithValue("@obsPeriod", If(iPeriod > 0, iPeriod, DBNull.Value))
                        cmd.Parameters.AddWithValue("@qcStatus", 0)
                        cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                        cmd.Parameters.AddWithValue("@capturedBy", strSignature)
                        cmd.Parameters.AddWithValue("@dataForm", strTableName)

                        cmd.ExecuteNonQuery()

                    End If
                Next
            Next

            e.Result = "Records have been uploaded sucessfully"
        Catch ex As Exception
            e.Result = "Error " & ex.Message
        Finally
            conn.Close()
        End Try


        'TODO? because of the detachment
        'PopulateControl()

    End Sub

    'TODO. Can be used once the issue of ObservationInitial primary keys is fixed
    Public Sub UploadAllRecordsEF()
        Dim clsAllRecordsCall As New DataCall
        Dim dtbAllRecords As DataTable
        Dim rcdObservationInitial As observationinitial
        Dim strTag As String
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strPeriodColumn As String
        Dim iPeriod As Integer
        Dim strStationId As String
        Dim lElementId As Long
        Dim dtObsDateTime As Date
        Dim lstAllFields As New List(Of String)
        Dim bNewRecord As Boolean

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        For Each row As DataRow In dtbAllRecords.Rows
            For Each strFieldName As String In lstFields
                'if its not an observation value field then skip the loop
                If Not strFieldName.StartsWith(Me.strValueFieldName) Then
                    Continue For
                End If

                strValueColumn = strFieldName
                'set the record
                If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                    strStationId = row.Item("stationId")
                    strTag = strFieldName.Substring(Me.strValueFieldName.Length)
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strTag)
                                                   End Function)
                    strPeriodColumn = lstFields.Find(Function(x As String)
                                                         Return x.Equals(Me.strPeriodFieldName & strTag)
                                                     End Function)
                    dtObsDateTime = New Date(row.Item("yyyy"), Val(strTag), 1, 6, 0, 0)

                    rcdObservationInitial = clsDataConnection.db.observationinitials.Where("recordedFrom  == @0  And describedBy == @1 AND obsDatetime  == @2  AND qcStatus  == @3 AND acquisitionType  == @4",
                                                                         {strStationId, lElementId, dtObsDateTime, 0, 1}).FirstOrDefault()

                    If rcdObservationInitial Is Nothing Then
                        bNewRecord = True
                        rcdObservationInitial = New observationinitial
                    Else
                        bNewRecord = False
                    End If

                    rcdObservationInitial.recordedFrom = strStationId
                    rcdObservationInitial.describedBy = lElementId
                    rcdObservationInitial.obsDatetime = dtObsDateTime
                    rcdObservationInitial.obsLevel = "surface"
                    rcdObservationInitial.obsValue = row.Item(strValueColumn)
                    rcdObservationInitial.flag = row.Item(strFlagColumn)
                    If Integer.TryParse(row.Item(strPeriodColumn), iPeriod) Then
                        rcdObservationInitial.period = iPeriod
                    End If
                    rcdObservationInitial.qcStatus = 0
                    rcdObservationInitial.acquisitionType = 1
                    rcdObservationInitial.dataForm = strTableName
                    If Not IsDBNull(row.Item("signature")) Then
                        rcdObservationInitial.capturedBy = row.Item("signature")
                    End If

                    If bNewRecord Then
                        clsDataConnection.db.observationinitials.Add(rcdObservationInitial)
                    End If
                    'save the Observation record
                    clsDataConnection.db.SaveChanges()

                End If
            Next
        Next

        'TODO? because of the detachment
        PopulateControl()

    End Sub

    Private Function SetUpContextMenuStrip() As ContextMenuStrip
        'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
        Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
        Dim shiftCells = New ClsShiftCells(allVFP)
        Return shiftCells.GetVFPContextMenu()
    End Function
End Class