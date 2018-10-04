Imports System.Linq.Dynamic

Public Class ucrHourlyWind
    Private bFirstLoad As Boolean = True
    Private strTableName As String = "form_hourlywind"
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private strTotalFieldName As String = "total"
    Private iDirectionElementId As Integer
    Private iSpeedElementId As Integer
    Private bSpeedTotalRequired As Boolean
    Private lstFields As New List(Of String)
    Public fhourlyWindRecord As form_hourlywind
    'Set to True by default
    Public bUpdating As Boolean = True
    Private ucrLinkedNavigation As ucrNavigation
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedYear As ucrYearSelector
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedDay As ucrDay

    Private Sub ucrHourlyWind_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim ucrText As ucrTextBox
        Dim vfpContextMenuStrip As ContextMenuStrip

        If bFirstLoad Then
            vfpContextMenuStrip = SetUpContextMenuStrip()

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrDSF.SetTableNameAndDirectionSpeedFlagFields(strTableName, strDirectionFieldName & ucrDSF.Tag, strSpeedFieldName & ucrDSF.Tag, strFlagFieldName & ucrDSF.Tag)
                    lstFields.Add(strDirectionFieldName & ucrDSF.Tag)
                    lstFields.Add(strSpeedFieldName & ucrDSF.Tag)
                    lstFields.Add(strFlagFieldName & ucrDSF.Tag)
                    AddHandler ucrDSF.ucrDirection.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrSpeed.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.ucrFlag.evtValueChanged, AddressOf InnerControlValueChanged
                    AddHandler ucrDSF.evtGoToNextDSFControl, AddressOf GoToNextDSFControl

                    ucrDSF.SetContextMenuStrip(vfpContextMenuStrip)

                ElseIf TypeOf ctr Is ucrTextBox Then
                    ucrText = DirectCast(ctr, ucrTextBox)
                    ucrText.SetTableNameAndField(strTableName, strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ucrText.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next
            SetTableNameAndFields(strTableName, lstFields)
            bFirstLoad = False
        End If
    End Sub

    Public Overrides Sub PopulateControl()
        Dim clsCurrentFilter As TableFilter
        Dim tempRecord As form_hourlywind

        If Not bFirstLoad Then
            MyBase.PopulateControl()

            'try to get the record based on the given filter
            clsCurrentFilter = GetLinkedControlsFilter()
            tempRecord = clsDataConnection.db.form_hourlywind.Where(clsCurrentFilter.GetLinqExpression()).FirstOrDefault()

            'if this was already a new record (tempFd2Record Is Nothing AndAlso Not bUpdating) 
            'then just do validation of values based on the new key controls values and exit the sub
            If tempRecord Is Nothing AndAlso Not bUpdating Then
                ValidateDataEntryPermission()
                ValidateValue()
                Exit Sub
            End If

            fhourlyWindRecord = tempRecord
            If fhourlyWindRecord Is Nothing Then
                fhourlyWindRecord = New form_hourlywind
                bUpdating = False
            Else
                clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Detached
                bUpdating = True
            End If

            'enable or disable textboxes based on year month day
            ValidateDataEntryPermission()

            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    DirectCast(ctr, ucrDirectionSpeedFlag).SetValue(New List(Of Object)({GetValue(strDirectionFieldName & ctr.Tag), GetValue(strSpeedFieldName & ctr.Tag), GetValue(strFlagFieldName & ctr.Tag)}))
                    'DirectCast(ctr, ucrDirectionSpeedFlag).SetValue(New List(Of Object)({GetValue(strDirectionFieldName & ctr.Tag), GetValue(strSpeedFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrTextBox).SetValue(GetValue(strTotalFieldName))
                End If
            Next

            OnevtValueChanged(Me, Nothing)
        End If

        ' Set conditions for double key entry
        If frmNewHourlyWind.chkRepeatEntry.Checked Then
            Me.Clear()
            Me.ucrDirectionSpeedFlag0.ucrDDFF.GetFocus()
            With frmNewHourlyWind
                .btnAddNew.Enabled = False
                .btnSave.Enabled = False
                .btnUpdate.Enabled = True
            End With
        End If

    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrTextbox As ucrTextBox
        If TypeOf sender Is ucrTextBox Then
            ucrTextbox = DirectCast(sender, ucrTextBox)
            CallByName(fhourlyWindRecord, ucrTextbox.GetField, CallType.Set, ucrTextbox.GetValue)
        End If
    End Sub

    Private Sub GoToNextDSFControl(sender As Object, e As KeyEventArgs)
        'TODO 
        'SHOULD BE ABLE TO IDENTIFY THE PARTICULAR TEXTBOX AS A SENDER
        'Dim ucrDSF As ucrDirectionSpeedFlag

        'If TypeOf sender Is ucrDirectionSpeedFlag Then
        '    ucrDSF = DirectCast(sender, ucrDirectionSpeedFlag)
        '    For Each ctr As Control In Me.Controls
        '        If TypeOf ctr Is ucrDirectionSpeedFlag Then
        '            'TODO 
        '            'needs modification here. for hour selection functionality
        '            If Val(ctr.Tag) = Val(ucrDSF.Tag) + 1 Then
        '                If ctr.Enabled Then
        '                    ctr.Focus()
        '                End If
        '            End If
        '        End If
        '    Next
        'End If

        SelectNextControl(sender, True, True, True, True)
        'this handles the "noise" on enter key down
        e.SuppressKeyPress = True
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If checkSpeedTotal() Then
                Me.FindForm.SelectNextControl(Me, True, True, True, True)
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkSpeedTotal()
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        Dim bValidValues As Boolean = True

        'validate the values of the linked controls
        For Each key As ucrBaseDataLink In dctLinkedControlsFilters.Keys
            If Not key.ValidateValue() Then
                bValidValues = False
                Exit For
            End If
        Next

        If bValidValues Then
            'fhourlyWindRecord = Nothing
            MyBase.LinkedControls_evtValueChanged()
            For Each kvpTemp As KeyValuePair(Of ucrBaseDataLink, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
                CallByName(fhourlyWindRecord, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            Next
            ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. Disable??
            'Me.Enabled = False
        End If
    End Sub

    Public Sub SaveRecord()
        If bUpdating Then
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Modified
        Else
            'This is determined by the current user not set from the form
            fhourlyWindRecord.signature = frmLogin.txtUsername.Text
            fhourlyWindRecord.entryDatetime = Date.Now()
            clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Added
        End If

        clsDataConnection.db.SaveChanges()
        'detach the record to prevent caching of records on the EF
        clsDataConnection.db.Entry(fhourlyWindRecord).State = Entity.EntityState.Detached
    End Sub

    Public Sub DeleteRecord()
        clsDataConnection.db.form_hourlywind.Attach(fhourlyWindRecord)
        clsDataConnection.db.form_hourlywind.Remove(fhourlyWindRecord)
        clsDataConnection.db.SaveChanges()
    End Sub

    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                DirectCast(ctr, ucrTextBox).Clear()
            End If
        Next
    End Sub

    Public Sub SetHourSelection(bNewSelectAllHours As Boolean)
        Dim ucrDSF As ucrDirectionSpeedFlag
        If bNewSelectAllHours Then
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrDSF.Enabled = True
                    ucrDSF.SetBackColor(Color.White)
                End If
            Next
        Else
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableName("form_hourly_time_selection")
            clsDataDefinition.SetFields(New List(Of String)({"hh", "hh_selection"}))
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrDirectionSpeedFlag Then
                        ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                        iTagVal = Val(Strings.Right(ucrDSF.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ucrDSF.Enabled = False
                            ucrDSF.SetBackColor(Color.LightYellow)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub SetDirectionDigits(iNewDirectionDigits As Integer)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).SetElementDirectionDigits(iNewDirectionDigits)
            End If
        Next
    End Sub

    Public Sub SetSpeedDigits(iNewSpeedDigits As Integer)
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                DirectCast(ctr, ucrDirectionSpeedFlag).SetElementSpeedDigits(iNewSpeedDigits)
            End If
        Next
    End Sub

    Public Sub SetDirectionValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""

        iDirectionElementId = elementId
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))
        clsDataDefinition.SetFilter("elementId", "=", iDirectionElementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = dtbl.Rows(0).Item("lowerLimit")
            strUpperLimit = dtbl.Rows(0).Item("upperLimit")
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)

                If String.IsNullOrEmpty(strLowerLimit) Then
                    ucrDSF.SetElementDirectionLowerLimit(Decimal.MinValue)
                Else
                    ucrDSF.SetElementDirectionLowerLimit(Val(strLowerLimit))
                End If

                If String.IsNullOrEmpty(strUpperLimit) Then
                    ucrDSF.SetElementDirectionHigherLimit(Decimal.MaxValue)
                Else
                    ucrDSF.SetElementDirectionHigherLimit(Val(strUpperLimit))
                End If
            End If
        Next
    End Sub

    Public Sub SetSpeedValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""
        bSpeedTotalRequired = False

        iSpeedElementId = elementId
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", iSpeedElementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
                bSpeedTotalRequired = If(dtbl.Rows(0).Item("qcTotalRequired") <> "" AndAlso Val(dtbl.Rows(0).Item("qcTotalRequired") <> 0), True, False)
            End If
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)

                If String.IsNullOrEmpty(strLowerLimit) Then
                    ucrDSF.SetElementSpeedLowerLimit(Decimal.MinValue)
                Else
                    ucrDSF.SetElementSpeedLowerLimit(Val(strLowerLimit))
                End If

                If String.IsNullOrEmpty(strUpperLimit) Then
                    ucrDSF.SetElementSpeedHigherLimit(Decimal.MaxValue)
                Else
                    ucrDSF.SetElementSpeedHigherLimit(Val(strUpperLimit))
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Returns true if all the direction values are empty and false if ANY has a value set
    ''' </summary>
    ''' <returns></returns>
    Public Function IsDirectionValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).IsElementDirectionEmpty() Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Returns true if all the speed values are empty and false if ANY has a value set
    ''' </summary>
    ''' <returns></returns>
    Public Function IsSpeedValuesEmpty() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).IsElementSpeedEmpty Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function


    ''' <summary>
    ''' returns true if all direction values are valid and false if any of them is not valid
    ''' </summary>
    ''' <returns></returns>
    Public Overrides Function ValidateValue() As Boolean
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                If Not DirectCast(ctr, ucrDirectionSpeedFlag).ValidateValue Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' will check the expected total if its indicated as required in the obselements table
    ''' returns true if the expected total speed value = computed total speed value or when the speed total is not required
    ''' </summary>
    ''' <returns></returns>
    Public Function checkSpeedTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Decimal = 0
        Dim expectedTotal As Decimal

        If bSpeedTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsSpeedValuesEmpty() Then
                MessageBox.Show("Please enter the Total Value in the (Total [ff]) textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Red)
                bValueCorrect = False
            Else
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrDirectionSpeedFlag Then
                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrDirectionSpeedFlag).GetElementSpeedValue)
                    End If
                Next
                bValueCorrect = (elemTotal = expectedTotal)
                If Not bValueCorrect Then
                    MessageBox.Show("Value in (Total [ff]) textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                End If
            End If
        Else
            bValueCorrect = True
        End If

        Return bValueCorrect
    End Function

    ''' <summary>
    ''' Sets the controls used by this control station,year,month,day and ucrNavigation controls 
    ''' </summary>
    ''' <param name="ucrStationControl"></param>
    ''' <param name="ucrYearControl"></param>
    ''' <param name="ucrMonthControl"></param>
    ''' <param name="ucrDayControl"></param>
    ''' <param name="ucrNavigationControl"></param>
    Public Sub SetKeyControls(ucrStationControl As ucrStationSelector, ucrYearControl As ucrYearSelector, ucrMonthControl As ucrMonth, ucrDayControl As ucrDay, ucrNavigationControl As ucrNavigation)
        ucrLinkedStation = ucrStationControl
        ucrLinkedYear = ucrYearControl
        ucrLinkedMonth = ucrMonthControl
        ucrLinkedDay = ucrDayControl
        ucrLinkedNavigation = ucrNavigationControl

        AddLinkedControlFilters(ucrLinkedStation, "stationId", "==", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedYear, "yyyy", "==", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, "mm", "==", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedDay, "dd", "==", strLinkedFieldName:="day", bForceValuesAsString:=False)

        ucrLinkedNavigation.SetTableNameAndFields(strTableName, (New List(Of String)({"stationId", "yyyy", "mm", "dd"})))
        ucrLinkedNavigation.SetKeyControls("stationId", ucrLinkedStation)
        ucrLinkedNavigation.SetKeyControls("yyyy", ucrLinkedYear)
        ucrLinkedNavigation.SetKeyControls("mm", ucrLinkedMonth)
        ucrLinkedNavigation.SetKeyControls("dd", ucrLinkedDay)
        ucrLinkedNavigation.SetSortBy("entryDatetime")
    End Sub

    ''' <summary>
    ''' checks the selected year month day to permit entry or not.
    ''' this prevents data entry of current and future dates
    ''' </summary>
    Private Sub ValidateDataEntryPermission()
        'if its an update or any of the linked year,month and day selector is nothing then just exit the sub
        If ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing OrElse ucrLinkedDay Is Nothing Then
            Me.Enabled = False
        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue AndAlso ucrLinkedDay.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values to Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue, ucrLinkedDay.GetValue)

            'if selectedDate  is earlier than todayDate (<0)  then its a valid date for data entry
            'if it is same time (0) or later than (>0) then its invalid, disable control
            Me.Enabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
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
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strTag As String
        Dim strStationId As String
        Dim lElementId As Long
        Dim hh As Integer
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
                    'if its not an observation direction or speed value field then skip the loop
                    If strFieldName.StartsWith(Me.strDirectionFieldName) Then
                        lElementId = iDirectionElementId
                        strTag = strFieldName.Substring(Me.strDirectionFieldName.Length)
                    ElseIf strFieldName.StartsWith(Me.strSpeedFieldName) Then
                        lElementId = iSpeedElementId
                        strTag = strFieldName.Substring(Me.strSpeedFieldName.Length)
                    Else
                        Continue For
                    End If

                    strValueColumn = strFieldName
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strTag)
                                                   End Function)

                    'set the record
                    If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) Then

                        strStationId = row.Item("stationId")
                        hh = Integer.Parse(strTag)
                        dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)

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

                        strSignature = ""

                        If Not IsDBNull(row.Item("signature")) Then
                            strSignature = row.Item("signature")
                        End If

                        If bUpdateRecord Then
                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm " &
                                    " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Else
                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                                "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@qcStatus,@acquisitiontype,@capturedBy,@dataForm)"
                        End If

                        cmd = New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
                        cmd.Parameters.AddWithValue("@stationId", strStationId)
                        cmd.Parameters.AddWithValue("@elemCode", lElementId)
                        cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                        cmd.Parameters.AddWithValue("@obsLevel", "surface")
                        cmd.Parameters.AddWithValue("@obsVal", row.Item(strValueColumn))
                        cmd.Parameters.AddWithValue("@obsFlag", row.Item(strFlagColumn))
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
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strTag As String
        Dim strStationId As String
        Dim lElementId As Long
        Dim hh As Integer
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
                'if its not an observation direction or speed value field then skip the loop
                If strFieldName.StartsWith(Me.strDirectionFieldName) Then
                    lElementId = iDirectionElementId
                    strTag = strFieldName.Substring(Me.strDirectionFieldName.Length)
                ElseIf strFieldName.StartsWith(Me.strSpeedFieldName) Then
                    lElementId = iSpeedElementId
                    strTag = strFieldName.Substring(Me.strSpeedFieldName.Length)
                Else
                    Continue For
                End If

                strValueColumn = strFieldName
                strFlagColumn = lstFields.Find(Function(x As String)
                                                   Return x.Equals(Me.strFlagFieldName & strTag)
                                               End Function)

                'set the record
                If Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) Then

                    strStationId = row.Item("stationId")
                    hh = Integer.Parse(strTag)
                    dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)

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
        Dim allDF = From udf In Me.Controls.OfType(Of ucrDirectionSpeedFlag)() Order By udf.TabIndex
        Return New ClsShiftCells(allDF).GetVFPContextMenu()
    End Function

End Class