Public Class ucrHourly
    Private strValueFieldName As String = "hh_"
    Private strFlagFieldName As String = "flag"
    Private bTotalRequired As Boolean

    Private Sub UcrHourly_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)

            'set up the value flag period first
            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_hourly")
            AddField("signature")
            AddField("entryDatetime")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrElementSelector, ucrElementSelector.FieldName, "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonthSelector, ucrMonthSelector.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDaySelector, ucrDaySelector.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)

            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)
            ucrDaySelector.setYearAndMonthLink(ucrYearSelector, ucrMonthSelector)


            bFirstLoad = False

            ucrNavigation.SetSortBy("entryDatetime")
            ucrNavigation.PopulateControl() 'populate the values

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"elementId", "mm", "dd"}, {ucrDaySelector, ucrMonthSelector}, ucrYearSelector)
            ' ucrNavigation.NewRecord() 'temporary
            SaveEnable()
            UcrValueFlagPeriod0.Focus()

            'Get the Station from the last record by the current login user
            Dim usrStn As New dataEntryGlobalRoutines
            usrStn.GetCurrentStation("form_hourly", ucrStationSelector.cboValues.Text)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnSaveAndUpdate_Click(sender As Object, e As EventArgs) Handles btnSave.Click, btnUpdate.Click
        Try
            'Change the signature(user) and the DATETIME first before saving 
            GetTable.Rows(0).Item("signature") = frmLogin.txtUsername.Text
            GetTable.Rows(0).Item("entryDatetime") = Date.Now
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmFormUpload.lblFormName.Text = "form_hourly"
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName.Text

        frmFormUpload.Show()
        Exit Sub


        'upload code in the background thread
        Dim frm As New frmNewComputationProgress
        frm.SetHeader("Uploading " & ucrNavigation.iMaxRows & " records")
        frm.SetProgressMaximum(ucrNavigation.iMaxRows)
        frm.ShowNumbers(True)
        frm.ShowResultMessage(True)
        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

        frm.backgroundWorker.RunWorkerAsync()
        frm.Show()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourly")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        dsSourceTableName = "form_hourly"
        userName = frmLogin.txtUsername.Text
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_hourly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_hourly ORDER by stationId,elementId,yyyy,mm,dd;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnAssignSameValue_Click(sender As Object, e As EventArgs) Handles btnAssignSameValue.Click
        Dim strNewValue As String = ucrInputSameValue.GetValue
        Dim ucrVFP As ucrValueFlagPeriod
        'Adds values to only enabled controls of the ucrHourly
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If ctr.Enabled Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetElementValue(strNewValue)
                    If Not ucrVFP.ValidateValue() Then
                        Exit Sub
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        Dim ctrVFP As ucrValueFlagPeriod

        If btnHourSelection.Text = "Enable all hours" Then
            btnHourSelection.Text = "Enable synoptic hours only"
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ctrVFP.Enabled = True
                    ctrVFP.SetBackColor(Color.White)
                End If
            Next
        Else
            btnHourSelection.Text = "Enable all hours"
            Dim clsDataDefinition As DataCall
            Dim dtbl As DataTable
            Dim iTagVal As Integer
            Dim row As DataRow
            clsDataDefinition = New DataCall
            clsDataDefinition.SetTableNameAndFields("form_hourly_time_selection", {"hh", "hh_selection"})
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        ctrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                        iTagVal = Val(Strings.Right(ctrVFP.Tag, 2))
                        row = dtbl.Select("hh = '" & iTagVal & "' AND hh_selection = '0'").FirstOrDefault()
                        If row IsNot Nothing Then
                            ctrVFP.Enabled = False
                            ctrVFP.SetBackColor(Color.LightYellow)
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ucrYearSelector_evtValueChanged(sender As Object, e As EventArgs) Handles ucrYearSelector.evtValueChanged
        If ucrYearSelector.ValidateValue() Then
            txtSequencer.Text = If(ucrYearSelector.IsLeapYear(), "seq_month_day_element_leap_yr", "seq_month_day_element")
        End If
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If Not CheckTotal() Then
                ucrInputTotal.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean

        bValid = MyBase.ValidateValue()

        If bValid Then
            Dim bValueExists As Boolean = False
            'Check if all values are empty. There should be atleast one observation value
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod AndAlso Not DirectCast(ctr, ucrValueFlagPeriod).IsElementValueEmpty() Then
                    bValueExists = True
                    Exit For
                End If
            Next

            If Not bValueExists Then
                MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            'check computed total vs input total
            If Not CheckTotal() Then
                ucrInputTotal.Focus()
                Return False
            End If

        End If

        Return bValid
    End Function

    Private Function CheckTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Decimal = 0
        Dim expectedTotal As Decimal

        If bTotalRequired Then
            If ucrInputTotal.IsEmpty Then
                MessageBox.Show("Please enter the Total Value in the [Total] textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ucrInputTotal.SetBackColor(Color.Red)
                bValueCorrect = False
            Else
                expectedTotal = Val(ucrInputTotal.GetValue)
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueFlagPeriod Then
                        elemTotal = elemTotal + Val(DirectCast(ctr, ucrValueFlagPeriod).GetElementValue)
                    End If
                Next

                bValueCorrect = (elemTotal = expectedTotal)
                If Not bValueCorrect Then
                    MessageBox.Show("Value in [Total] textbox is different from that calculated by computer! The computed total is " & elemTotal, "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ucrInputTotal.SetBackColor(Color.Red)
                End If

            End If
        Else
            bValueCorrect = True
        End If

        Return bValueCorrect
    End Function


    ''' <summary>
    ''' Sets upper and lower limits validation curent selected element and sets if the checking total is requred
    ''' </summary>
    Protected Overrides Sub SetValuesValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""
        bTotalRequired = False

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", {"lowerLimit", "upperLimit", "qcTotalRequired"})
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrElementSelector.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        'get upper and lower limits
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
            'qcTotalRequired is a nullable integer in the EF model
            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
                bTotalRequired = If(Val(dtbl.Rows(0).Item("qcTotalRequired")) <> 0, True, False)
            End If
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

    Protected Overrides Sub ValidateDataEntryPermission()
        Dim bEnabled As Boolean
        'if its an update or any of the linked year,month and day selector is nothing then just enable the control
        If ucrYearSelector.ValidateValue AndAlso ucrMonthSelector.ValidateValue AndAlso ucrDaySelector.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values. Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrYearSelector.GetValue, ucrMonthSelector.GetValue, ucrDaySelector.GetValue)

            'if selectedDate is earlier than todayDate (<0) enable control
            'if it is same time (0) or later than (>0) disable control
            bEnabled = If(Date.Compare(selectedDate, todayDate) < 0, True, False)
        Else
            bEnabled = False
        End If

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                ctr.Enabled = bEnabled
            End If
        Next

    End Sub




    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim dtbAllRecords As New DataTable
        Dim strValueColumn As String
        Dim strFlagColumn As String
        Dim strTag As String
        Dim strStationId As String
        Dim lElementId As Long
        Dim hh As Integer
        Dim dtObsDateTime As Date
        Dim bUpdateRecord As Boolean
        Dim strSql As String
        Dim pos As Integer = 0
        Dim invalidRecord As Boolean = False
        Dim strResult As String = ""
        Dim iUpdatesNum As Integer = 0
        Dim iInsertsNum As Integer = 0
        Dim strTableName As String
        Dim strSignature As String

        Try
            strTableName = GetTableName()

            'Get all the records from the table
            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand(
                "Select * FROM " & strTableName & " ORDER BY entryDatetime",
                clsDataConnection.GetOpenedConnection)
                Using da As New MySql.Data.MySqlClient.MySqlDataAdapter(cmdSelect)
                    da.Fill(dtbAllRecords)
                End Using
            End Using

            'Save the records to observable initial table
            For Each row As DataRow In dtbAllRecords.Rows
                If backgroundWorker.CancellationPending Then
                    e.Result = strResult & "Cancelling upload"
                    e.Cancel = True
                    Exit For
                End If

                For Each strFieldName As String In lstFields
                    'if its not an observation value field then skip the loop
                    If Not strFieldName.StartsWith(Me.strValueFieldName) Then
                        Continue For
                    End If

                    strValueColumn = strFieldName
                    strTag = strFieldName.Substring(Me.strValueFieldName.Length)
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strTag)
                                                   End Function)
                    'set the record
                    If ((Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn))) OrElse (Not IsDBNull(row.Item(strFlagColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strFlagColumn)))) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                        strStationId = row.Item("stationId")
                        hh = Integer.Parse(strTag)

                        Try
                            dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)
                        Catch ex As Exception
                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record" &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Day: " & row.Item("dd") &
                                ". This row was skipped" & Environment.NewLine
                            Exit For
                        End Try
                        bUpdateRecord = False

                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
                            cmd.Parameters.AddWithValue("@stationId", strStationId)
                            cmd.Parameters.AddWithValue("@elemCode", lElementId)
                            cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                            cmd.Parameters.AddWithValue("@qcStatus", 0)
                            cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                            cmd.Parameters.AddWithValue("@dataForm", strTableName)
                            Using reader As MySql.Data.MySqlClient.MySqlDataReader = cmd.ExecuteReader()
                                bUpdateRecord = reader.HasRows
                            End Using
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

                        Try
                            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
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
                            End Using
                            If bUpdateRecord Then
                                iUpdatesNum += 1
                            Else
                                iInsertsNum += 1
                            End If
                        Catch ex As Exception
                            'MsgBox("Invalid record detected. Record number " & pos & " could not be uploaded. This record will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid record detected. Record number " & pos & " could not be uploaded | " &
                                 " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Date: " & dtObsDateTime &
                                ". This record was skipped" & Environment.NewLine
                            Exit For
                        End Try
                    End If
                Next

                'Display progress of data transfer
                pos += 1
                backgroundWorker.ReportProgress(pos)
            Next

            If Not invalidRecord Then
                strResult = "All Records have been uploaded sucessfully "
            End If

            e.Result = strResult & Environment.NewLine & "Total New Records: " & iInsertsNum & Environment.NewLine & "Total Updates: " & iUpdatesNum

        Catch ex As Exception
            e.Result = "Error " & ex.Message
        End Try


    End Sub


End Class
