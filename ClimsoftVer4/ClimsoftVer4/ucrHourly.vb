'Imports System.Linq.Dynamic

'Public Class ucrHourly
'    Private bFirstLoad As Boolean = True
'    Private strTableName As String = "form_hourly"
'    Private strValueFieldName As String = "hh_"
'    Private strFlagFieldName As String = "flag"
'    Private strTotalFieldName As String = "total"
'    Private lstFields As New List(Of String)
'    Public fhRecord As form_hourly
'    'Set to True by default
'    Public bUpdating As Boolean = True
'    Private ucrLinkedNavigation As ucrNavigation
'    Private bTotalRequired As Boolean
'    Private ucrLinkedYear As ucrYearSelector
'    Private ucrLinkedMonth As ucrMonth
'    Private ucrLinkedDay As ucrDay
'    Private ucrLinkedStation As ucrStationSelector
'    Private ucrlinkedElement As ucrElementSelector

'    ''' <summary>
'    ''' Sets the values of the controls to the coresponding record values in the database with the current key
'    ''' </summary>
'    Public Overrides Sub PopulateControl()
'        Dim clsCurrentFilter As New TableFilter
'        Dim tempRecord As form_hourly

'        If Not bFirstLoad Then
'            MyBase.PopulateControl()

'            'TODO. Might not be need anymore
'            bUpdating = dtbRecords.Rows.Count > 0

'            'check whether to permit data entry based on date entry values
'            ValidateDataEntryPermission()

'            'set the validation of the controls
'            SetValueValidation()

'            For Each ctr As Control In Me.Controls
'                If TypeOf ctr Is ucrValueFlagPeriod Then
'                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetFieldValue(strValueFieldName & ctr.Tag), GetFieldValue(strFlagFieldName & ctr.Tag)}))
'                ElseIf TypeOf ctr Is ucrTextBox Then
'                    DirectCast(ctr, ucrTextBox).SetValue(GetFieldValue(strTotalFieldName))
'                End If
'            Next

'            'OnevtValueChanged(Me, Nothing)

'        End If

'        ' Set conditions for double key entry
'        If frmNewHourly.chkRepeatEntry.Checked Then
'            Me.Clear()
'            Me.UcrValueFlagPeriod0.ucrValue.GetFocus()
'            With frmNewHourly
'                .btnAddNew.Enabled = False
'                .btnCommit.Enabled = False
'                .btnUpdate.Enabled = True
'            End With
'        End If
'    End Sub

'    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Dim ucrVFP As ucrValueFlagPeriod
'        Dim ucrText As ucrTextBox
'        Dim vfpContextMenuStrip As ContextMenuStrip

'        If bFirstLoad Then
'            vfpContextMenuStrip = SetUpContextMenuStrip()

'            For Each ctr As Control In Me.Controls
'                If TypeOf ctr Is ucrValueFlagPeriod Then
'                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
'                    lstFields.Add(strValueFieldName & ucrVFP.Tag)
'                    lstFields.Add(strFlagFieldName & ucrVFP.Tag)
'                    ucrVFP.ucrPeriod.Visible = False
'                    ucrVFP.SetTableNameAndValueFlagFields(strTableName, strValueFieldName & ucrVFP.Tag, strFlagFieldName & ucrVFP.Tag)
'                    AddHandler ucrVFP.ucrValue.evtValueChanged, AddressOf InnerControlValueChanged
'                    AddHandler ucrVFP.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
'                    AddHandler ucrVFP.evtGoToNextVFPControl, AddressOf GoToNextVFPControl

'                    ucrVFP.SetContextMenuStrip(vfpContextMenuStrip)

'                ElseIf TypeOf ctr Is ucrTextBox Then
'                    ucrText = DirectCast(ctr, ucrTextBox)
'                    ucrText.SetTableNameAndField(strTableName, strTotalFieldName)
'                    lstFields.Add(strTotalFieldName)
'                    AddHandler ucrText.evtValueChanged, AddressOf InnerControlValueChanged
'                End If
'            Next
'            SetTableNameAndFields(strTableName, lstFields)
'            bFirstLoad = False
'        End If
'    End Sub


'    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrValueView, tblFilter As TableFilter, Optional strFieldName As String = "")
'        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
'        If Not lstFields.Contains(tblFilter.GetField) Then
'            lstFields.Add(tblFilter.GetField)
'            SetFields(lstFields)
'        End If
'    End Sub

'    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
'        Dim ucrText As ucrTextBox
'        If TypeOf sender Is ucrTextBox Then
'            ucrText = DirectCast(sender, ucrTextBox)
'            'CallByName(fhRecord, ucrText.GetField, CallType.Set, ucrText.GetValue)
'        End If
'    End Sub

'    Private Sub GoToNextVFPControl(sender As Object, e As KeyEventArgs)
'        SelectNextControl(sender, True, True, True, True)
'        'this handles the "noise" on enter  
'        e.SuppressKeyPress = True
'    End Sub

'    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
'        If e.KeyCode = Keys.Enter Then
'            If checkTotal() Then
'                Me.FindForm.SelectNextControl(sender, True, True, True, True)
'                e.SuppressKeyPress = True
'            End If
'        End If
'    End Sub

'    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
'        checkTotal()
'    End Sub

'    Protected Overrides Sub LinkedControls_evtValueChanged()
'        Dim bValidValues As Boolean = True

'        'validate the values of the linked controls
'        For Each key As ucrValueView In dctLinkedControlsFilters.Keys
'            If Not key.ValidateValue() Then
'                bValidValues = False
'                Exit For
'            End If
'        Next

'        If bValidValues Then
'            'fhRecord = Nothing
'            MyBase.LinkedControls_evtValueChanged()
'            For Each kvpTemp As KeyValuePair(Of ucrValueView, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
'                'CallByName(fhRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
'            Next
'            ' ucrLinkedNavigation.UpdateNavigationByKeyControls()
'        Else
'            'TODO. DISABLE??
'            'Me.Enabled = False
'        End If
'    End Sub

'    Public Sub SaveRecord()
'        'If bUpdating Then
'        '    clsDataConnection.db.Entry(fhRecord).State = Entity.EntityState.Modified
'        'Else
'        '    'This is determined by the current user not set from the form
'        '    fhRecord.signature = frmLogin.txtUsername.Text
'        '    fhRecord.EntryDatetime = Date.Now()
'        '    clsDataConnection.db.Entry(fhRecord).State = Entity.EntityState.Added
'        'End If

'        'clsDataConnection.db.SaveChanges()
'        ''detach the record to prevent caching of records on the EF
'        'clsDataConnection.db.Entry(fhRecord).State = Entity.EntityState.Detached
'    End Sub

'    Public Sub DeleteRecord()
'        'clsDataConnection.db.form_hourly.Attach(fhRecord)
'        'clsDataConnection.db.form_hourly.Remove(fhRecord)
'        'clsDataConnection.db.SaveChanges()
'    End Sub

'    ''' <summary>
'    ''' Clears all the text In the ucrValueFlagPeriod controls 
'    ''' </summary>
'    Public Overrides Sub Clear()
'        For Each ctr As Control In Me.Controls
'            If TypeOf ctr Is ucrValueFlagPeriod Then
'                'DirectCast(ctr, ucrDirectionSpeedFlag).Clear()
'            ElseIf TypeOf ctr Is ucrTextBox Then
'                DirectCast(ctr, ucrTextBox).Clear()
'            End If
'        Next
'    End Sub

'    Public Sub SetSynopticHourSelectionOnly(bNewSelectAllHours As Boolean)
'        Dim ctrVFP As ucrValueFlagPeriod
'        If bNewSelectAllHours Then
'            For Each ctr As Control In Me.Controls
'                If TypeOf ctr Is ucrValueFlagPeriod Then
'                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
'                    ctrVFP.Enabled = True
'                    ctrVFP.SetBackColor(Color.White)
'                End If
'            Next
'        Else
'            Dim clsDataDefinition As DataCall
'            Dim dtbl As DataTable
'            Dim iTagVal As Integer
'            Dim row As DataRow
'            clsDataDefinition = New DataCall
'            clsDataDefinition.SetTableNameAndFields("form_hourly_time_selection", New List(Of String)({"hh", "hh_selection"}))
'            dtbl = clsDataDefinition.GetDataTable()
'            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
'                For Each ctr As Control In Me.Controls
'                    If TypeOf ctr Is ucrValueFlagPeriod Then
'                        ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
'                        iTagVal = Val(Strings.Right(ctrVFP.Tag, 2))
'                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
'                        If row IsNot Nothing Then
'                            ctrVFP.Enabled = False
'                            ctrVFP.SetBackColor(Color.LightYellow)
'                        End If
'                    End If
'                Next
'            End If
'        End If
'    End Sub

'    Public Sub SetSameValueToAllObsElements(bNewValue As String)
'        Dim ucrVFP As ucrValueFlagPeriod
'        'Adds values to only enabled controls of the ucrHourly
'        For Each ctr As Control In Me.Controls
'            If TypeOf ctr Is ucrValueFlagPeriod Then
'                If ctr.Enabled Then
'                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
'                    ucrVFP.SetElementValue(bNewValue)
'                    If Not ucrVFP.ValidateValue() Then
'                        Exit Sub
'                    End If
'                End If
'            End If
'        Next
'    End Sub

'    ''' <summary>
'    ''' Sets upper and lower limits validation curent selected element and sets if the checking total is requred
'    ''' </summary>
'    Public Sub SetValueValidation()
'        Dim ucrVFP As ucrValueFlagPeriod
'        Dim clsDataDefinition As DataCall
'        Dim dtbl As DataTable
'        Dim strLowerLimit As String = ""
'        Dim strUpperLimit As String = ""
'        bTotalRequired = False

'        clsDataDefinition = New DataCall
'        clsDataDefinition.SetTableName("obselement")
'        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
'        clsDataDefinition.SetFilter("elementId", "=", Val(ucrlinkedElement.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
'        dtbl = clsDataDefinition.GetDataTable()
'        'get upper and lower limits
'        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
'            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
'            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
'            'qcTotalRequired is a nullable integer in the EF model
'            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
'                bTotalRequired = If(Val(dtbl.Rows(0).Item("qcTotalRequired")) <> 0, True, False)
'            End If
'        End If

'        For Each ctr As Control In Me.Controls
'            If TypeOf ctr Is ucrValueFlagPeriod Then
'                ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)

'                If String.IsNullOrEmpty(strLowerLimit) Then
'                    ucrVFP.SetElementValueLowerLimit(Decimal.MinValue)
'                Else
'                    ucrVFP.SetElementValueLowerLimit(Val(strLowerLimit))
'                End If

'                If String.IsNullOrEmpty(strUpperLimit) Then
'                    ucrVFP.SetElementValueHigherLimit(Decimal.MaxValue)
'                Else
'                    ucrVFP.SetElementValueHigherLimit(Val(strUpperLimit))
'                End If

'            End If
'        Next
'    End Sub

'    ''' <summary>
'    ''' checks if all the ucrValueFlagPeriod controls have a value.
'    ''' Returns true if they are all empty and false if otherwise
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function IsValuesEmpty() As Boolean
'        For Each ctr As Control In Me.Controls
'            If TypeOf ctr Is ucrValueFlagPeriod Then
'                If Not DirectCast(ctr, ucrValueFlagPeriod).IsElementValueEmpty() Then
'                    Return False
'                End If
'            End If
'        Next
'        Return True
'    End Function

'    ''' <summary>
'    ''' checks if all the ucrValueFlagPeriod controls have a Valid value.
'    ''' Returns true if they are all valid and false if any has Invalid value
'    ''' </summary>
'    ''' <returns></returns>
'    Public Function ValidateValue() As Boolean
'        For Each ctr As Control In Me.Controls
'            If TypeOf ctr Is ucrValueFlagPeriod Then
'                If Not DirectCast(ctr, ucrValueFlagPeriod).ValidateValue Then
'                    ctr.Focus()
'                    Return False
'                End If
'            End If
'        Next
'        Return True
'    End Function

'    ''' <summary>
'    ''' Checks if total for current element is required
'    ''' Checks if the computed total is same as the user entered total.
'    ''' </summary>
'    Public Function checkTotal() As Boolean
'        Dim bValueCorrect As Boolean = False
'        Dim elemTotal As Decimal = 0
'        Dim expectedTotal As Decimal

'        If bTotalRequired Then
'            If ucrInputTotal.IsEmpty AndAlso Not IsValuesEmpty() Then
'                MessageBox.Show("Please enter the Total Value in the [Total] textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                ucrInputTotal.SetBackColor(Color.Red)
'                bValueCorrect = False
'            Else
'                expectedTotal = Val(ucrInputTotal.GetValue)
'                For Each ctr As Control In Me.Controls
'                    If TypeOf ctr Is ucrValueFlagPeriod Then
'                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrValueFlagPeriod).GetElementValue)
'                    End If
'                Next

'                bValueCorrect = (elemTotal = expectedTotal)
'                If Not bValueCorrect Then
'                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
'                    ucrInputTotal.SetBackColor(Color.Red)
'                End If

'            End If
'        Else
'            bValueCorrect = True
'        End If

'        Return bValueCorrect
'    End Function

'    ''' <summary>
'    ''' Sets the Key controls
'    ''' </summary>
'    ''' <param name="ucrYear"></param>
'    ''' <param name="ucrMonth"></param>
'    ''' <param name="ucrDay"></param>
'    Public Sub SetKeyControls(ucrStation As ucrStationSelector, ucrElement As ucrElementSelector, ucrYear As ucrYearSelector, ucrMonth As ucrMonth, ucrDay As ucrDay, ucrNavigation As ucrNavigation)
'        ucrLinkedYear = ucrYear
'        ucrLinkedMonth = ucrMonth
'        ucrLinkedDay = ucrDay
'        ucrLinkedStation = ucrStation
'        ucrlinkedElement = ucrElement
'        ucrLinkedNavigation = ucrNavigation

'        AddLinkedControlFilters(ucrLinkedStation, "stationId", "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
'        AddLinkedControlFilters(ucrlinkedElement, "elementId", "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
'        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
'        AddLinkedControlFilters(ucrLinkedMonth, "mm", "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
'        AddLinkedControlFilters(ucrLinkedDay, "dd", "=", strLinkedFieldName:="day", bForceValuesAsString:=False)

'        'setting the key contols for the Navigation control 
'        'ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "elementId", "yyyy", "mm", "dd"})))
'        ucrLinkedNavigation.SetTableEntry(Me)
'        ucrLinkedNavigation.AddKeyControls(ucrLinkedStation)
'        ucrLinkedNavigation.AddKeyControls(ucrlinkedElement)
'        ucrLinkedNavigation.AddKeyControls(ucrLinkedYear)
'        ucrLinkedNavigation.AddKeyControls(ucrLinkedMonth)
'        ucrLinkedNavigation.AddKeyControls(ucrLinkedDay)
'        ucrLinkedNavigation.SetSortBy("entryDatetime")
'    End Sub

'    Private Sub ValidateDataEntryPermission()
'        'if its an update or any of the linked year,month and day selector is nothing then just enable the control
'        If bUpdating OrElse ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
'            Me.Enabled = True
'        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue AndAlso ucrLinkedDay.ValidateValue Then
'            Dim todayDate As Date = Date.Now
'            Dim selectedDate As Date

'            'initialise the dates with ONLY year month and day values. Neglect the time factor
'            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
'            selectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

'            'if selectedDate is earlier than todayDate (<0) enable control
'            'if it is same time (0) or later than (>0) disable control
'            Me.Enabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
'        Else
'            Me.Enabled = False
'        End If
'    End Sub

'    'upload code in the background thread
'    Public Sub UploadAllRecords()
'        Dim frm As New frmNewComputationProgress
'        frm.SetHeader("Uploading " & ucrLinkedNavigation.iMaxRows & " records")
'        frm.SetProgressMaximum(ucrLinkedNavigation.iMaxRows)
'        frm.ShowNumbers(True)
'        frm.ShowResultMessage(True)
'        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

'        'TODO. temporary. Pass the connection string . The current connection properties are being stored in control
'        'Once this is fixed, the argument can be removed
'        frm.backgroundWorker.RunWorkerAsync(frmLogin.txtusrpwd.Text)

'        frm.Show()
'    End Sub

'    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
'        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

'        'Dim clsAllRecordsCall As New DataCall
'        Dim dtbAllRecords As New DataTable
'        Dim strValueColumn As String
'        Dim strFlagColumn As String
'        Dim strTag As String
'        Dim strStationId As String
'        Dim lElementId As Long
'        Dim hh As Integer
'        Dim dtObsDateTime As Date
'        Dim lstAllFields As New List(Of String)
'        Dim bUpdateRecord As Boolean
'        Dim strSql As String
'        Dim strSignature As String
'        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
'        Dim pos As Integer = 0
'        Dim invalidRecord As Boolean = False
'        Dim strResult As String = ""

'        'get the observation values fields
'        lstAllFields.AddRange(lstFields)
'        'TODO "entryDatetime" should be here as well once entity model has been updated.
'        lstAllFields.AddRange({"signature"})

'        'clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
'        'dtbAllRecords = clsAllRecordsCall.GetDataTable()


'        Try
'            'Temporary.The current connection properties are being stored in control, this line can be removed in future
'            conn.ConnectionString = e.Argument
'            conn.Open()
'            'Get all the records from the table
'            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand("Select * FROM " & strTableName & " ORDER BY entryDatetime", conn)
'                Using da As New MySql.Data.MySqlClient.MySqlDataAdapter(cmdSelect)
'                    da.Fill(dtbAllRecords)
'                End Using
'            End Using

'            'Save the records to observable initial table
'            For Each row As DataRow In dtbAllRecords.Rows
'                If backgroundWorker.CancellationPending Then
'                    e.Result = strResult & "Cancelling upload"
'                    e.Cancel = True
'                    Exit For
'                End If

'                For Each strFieldName As String In lstFields
'                    'if its not an observation value field then skip the loop
'                    If Not strFieldName.StartsWith(Me.strValueFieldName) Then
'                        Continue For
'                    End If

'                    strValueColumn = strFieldName
'                    'set the record
'                    If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

'                        strStationId = row.Item("stationId")
'                        strTag = strFieldName.Substring(Me.strValueFieldName.Length)
'                        strFlagColumn = lstFields.Find(Function(x As String)
'                                                           Return x.Equals(Me.strFlagFieldName & strTag)
'                                                       End Function)

'                        hh = Integer.Parse(strTag)

'                        Try
'                            dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)
'                        Catch ex As Exception
'                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
'                            invalidRecord = True
'                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record" &
'                                " Station: " & strStationId & ", Element: " & lElementId &
'                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Day: " & row.Item("dd") &
'                                ". This row was skipped" & Environment.NewLine
'                            Exit For
'                        End Try
'                        bUpdateRecord = False

'                        'check if record exists
'                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
'                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
'                            cmd.Parameters.AddWithValue("@stationId", strStationId)
'                            cmd.Parameters.AddWithValue("@elemCode", lElementId)
'                            cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
'                            cmd.Parameters.AddWithValue("@qcStatus", 0)
'                            cmd.Parameters.AddWithValue("@acquisitiontype", 1)
'                            cmd.Parameters.AddWithValue("@dataForm", strTableName)
'                            Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
'                                bUpdateRecord = reader.HasRows
'                            End Using
'                        End Using

'                        strSignature = ""
'                        If Not IsDBNull(row.Item("signature")) Then
'                            strSignature = row.Item("signature")
'                        End If

'                        If bUpdateRecord Then
'                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm " &
'                                " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
'                        Else
'                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
'                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@qcStatus,@acquisitiontype,@capturedBy,@dataForm)"
'                        End If

'                        Try
'                            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
'                                cmd.Parameters.AddWithValue("@stationId", strStationId)
'                                cmd.Parameters.AddWithValue("@elemCode", lElementId)
'                                cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
'                                cmd.Parameters.AddWithValue("@obsLevel", "surface")
'                                cmd.Parameters.AddWithValue("@obsVal", row.Item(strValueColumn))
'                                cmd.Parameters.AddWithValue("@obsFlag", row.Item(strFlagColumn))
'                                cmd.Parameters.AddWithValue("@qcStatus", 0)
'                                cmd.Parameters.AddWithValue("@acquisitiontype", 1)
'                                cmd.Parameters.AddWithValue("@capturedBy", strSignature)
'                                cmd.Parameters.AddWithValue("@dataForm", strTableName)
'                                cmd.ExecuteNonQuery()
'                            End Using
'                        Catch ex As Exception
'                            'MsgBox("Invalid record detected. Record number " & pos & " could not be uploaded. This record will be skipped")
'                            invalidRecord = True
'                            strResult = strResult & "Invalid record detected. Record number " & pos & " could not be uploaded" &
'                                 " Station: " & strStationId & ", Element: " & lElementId &
'                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Date: " & dtObsDateTime &
'                                ". This record was skipped" & Environment.NewLine
'                            Exit For
'                        End Try
'                    End If
'                Next

'                'Display progress of data transfer
'                pos = pos + 1
'                backgroundWorker.ReportProgress(pos)
'            Next

'            If Not invalidRecord Then
'                e.Result = "Records have been uploaded sucessfully"
'            Else
'                e.Result = strResult
'            End If

'        Catch ex As Exception
'            e.Result = "Error " & ex.Message
'        Finally
'            conn.Close()
'        End Try



'        'TODO? because of the detachment
'        'PopulateControl()

'    End Sub

'    'TODO. Can be used once the issue of ObservationInitial primary keys is fixed
'    Public Sub UploadAllRecordsEF()
'        Dim clsAllRecordsCall As New DataCall
'        Dim dtbAllRecords As DataTable
'        Dim rcdObservationInitial As observationinitial
'        Dim strValueColumn As String
'        Dim strFlagColumn As String
'        Dim strTag As String
'        Dim strStationId As String
'        Dim lElementId As Long
'        Dim hh As Integer
'        Dim dtObsDateTime As Date
'        Dim lstAllFields As New List(Of String)
'        Dim bNewRecord As Boolean

'        'get the observation values fields
'        lstAllFields.AddRange(lstFields)
'        'TODO "entryDatetime" should be here as well once entity model has been updated.
'        lstAllFields.AddRange({"signature"})

'        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
'        dtbAllRecords = clsAllRecordsCall.GetDataTable()

'        For Each row As DataRow In dtbAllRecords.Rows
'            For Each strFieldName As String In lstFields
'                'if its not an observation value field then skip the loop
'                If Not strFieldName.StartsWith(Me.strValueFieldName) Then
'                    Continue For
'                End If

'                strValueColumn = strFieldName
'                'set the record
'                If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

'                    strStationId = row.Item("stationId")
'                    strTag = strFieldName.Substring(Me.strValueFieldName.Length)
'                    strFlagColumn = lstFields.Find(Function(x As String)
'                                                       Return x.Equals(Me.strFlagFieldName & strTag)
'                                                   End Function)

'                    hh = Integer.Parse(strTag)
'                    dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)

'                    rcdObservationInitial = clsDataConnection.db.observationinitials.Where("recordedFrom  == @0  And describedBy == @1 AND obsDatetime  == @2  AND qcStatus  == @3 AND acquisitionType  == @4",
'                                                                         {strStationId, lElementId, dtObsDateTime, 0, 1}).FirstOrDefault()

'                    If rcdObservationInitial Is Nothing Then
'                        bNewRecord = True
'                        rcdObservationInitial = New observationinitial
'                    Else
'                        bNewRecord = False
'                    End If

'                    rcdObservationInitial.recordedFrom = strStationId
'                    rcdObservationInitial.describedBy = lElementId
'                    rcdObservationInitial.obsDatetime = dtObsDateTime
'                    rcdObservationInitial.obsLevel = "surface"
'                    rcdObservationInitial.obsValue = row.Item(strValueColumn)
'                    rcdObservationInitial.flag = row.Item(strFlagColumn)
'                    rcdObservationInitial.qcStatus = 0
'                    rcdObservationInitial.acquisitionType = 1
'                    rcdObservationInitial.dataForm = strTableName

'                    If Not IsDBNull(row.Item("signature")) Then
'                        rcdObservationInitial.capturedBy = row.Item("signature")
'                    End If

'                    If bNewRecord Then
'                        clsDataConnection.db.observationinitials.Add(rcdObservationInitial)
'                    End If
'                    'save the Observation record
'                    clsDataConnection.db.SaveChanges()

'                End If
'            Next
'        Next


'        'TODO? because of the detachment
'        PopulateControl()

'    End Sub

'    Private Function SetUpContextMenuStrip() As ContextMenuStrip
'        'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
'        Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
'        Dim shiftCells = New ClsShiftCells(allVFP)
'        Return shiftCells.GetVFPContextMenu()
'    End Function

'    Private Sub UcrValueFlagPeriod0_GotFocus(sender As Object, e As EventArgs) Handles UcrValueFlagPeriod0.GotFocus

'    End Sub
'End Class

Public Class ucrHourly
    Private Sub ucrHourly_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then

            SetUpTableEntry("form_hourly")

            ucrStationSelector.SetTableNameAndField("form_hourly", "stationId")
            ucrStationSelector.PopulateControl()
            ucrStationSelector.SetDisplayAndValueMember("stationId")
            ucrStationSelector.SetValidationTypeAsNumeric()

            'validations
            ucrYearSelector.SetValidationTypeAsNumeric()
            ucrMonth.SetValidationTypeAsNumeric()
            ucrDay.SetValidationTypeAsNumeric()

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName(), "=", strLinkedFieldName:=ucrStationSelector.FieldName(), bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrElementSelector, ucrElementSelector.FieldName(), "=", strLinkedFieldName:=ucrElementSelector.FieldName(), bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName(), "=", strLinkedFieldName:=ucrYearSelector.FieldName(), bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonth, ucrMonth.FieldName(), "=", strLinkedFieldName:=ucrMonth.FieldName(), bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDay, ucrDay.FieldName(), "=", strLinkedFieldName:=ucrDay.FieldName(), bForceValuesAsString:=False)

            'TODO Set up the other key controls year, Month, Day and check whether lines 697 to 707 and also the possiblity of having multiple key controls

            AddKeyField(ucrStationSelector.FieldName)

            'set up the navigation control
            ucrNavigation.SetTableEntry(Me)
            ucrNavigation.AddKeyControls(ucrStationSelector)
            ucrNavigation.AddKeyControls(ucrElementSelector)
            ucrNavigation.AddKeyControls(ucrYearSelector)
            ucrNavigation.AddKeyControls(ucrMonth)
            ucrNavigation.AddKeyControls(ucrDay)

            bFirstLoad = False

            'populate the values
            ucrNavigation.PopulateControl()
            SaveEnable()
        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ucrNavigation.NewRecord()
        SaveEnable()
        ucrStationSelector.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            'Confirm if you want to continue and save data from key-entry form to database table
            If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If InsertRecord() Then
                    ucrStationSelector.PopulateControl()
                    'ucrStationSelector.GoToNewRecord()
                    SaveEnable()
                    MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If UpdateRecord() Then
                    MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If Not ValidateValue() Then
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If DeleteRecord() Then
                    ucrNavigation.RemoveRecord()
                    SaveEnable()
                    MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Move to the first record of datatable
        ucrNavigation.MoveFirst()
        'Enable appropriate base buttons
        SaveEnable()
    End Sub

    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear and on dialog load
    ''' </summary>
    Private Sub SaveEnable()
        btnAddNew.Enabled = True
        btnCommit.Enabled = False
        btnClear.Enabled = False
        btnDelete.Enabled = False
        btnUpdate.Enabled = False

        If ucrNavigation.iCurrRow = -1 Then
            btnAddNew.Enabled = False
            btnClear.Enabled = True
            btnDelete.Enabled = False
            btnUpdate.Enabled = False
            btnCommit.Enabled = True
        ElseIf ucrNavigation.iMaxRows = 0 Then
            btnAddNew.Enabled = False
            btnCommit.Enabled = True
        ElseIf ucrNavigation.iMaxRows > 0 Then
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
        End If
    End Sub

    Private Sub ucrNavigation_evtValueChanged(sender As Object, e As EventArgs) Handles ucrNavigation.evtValueChanged

    End Sub

End Class
