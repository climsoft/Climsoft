

Public Class ucrHourlyWind
    Private strDirectionFieldName As String = "elem_112_"
    Private strSpeedFieldName As String = "elem_111_"
    Private strFlagFieldName As String = "ddflag"
    Private iDirectionElementId As Integer
    Private iSpeedElementId As Integer
    Private bSpeedTotalRequired As Boolean

    Private Sub ucrHourlyWind_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrDirectionSpeedFlag)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)

            'set up the value flag period first
            Dim ucrDSF As ucrDirectionSpeedFlag
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucrDSF = DirectCast(ctr, ucrDirectionSpeedFlag)
                    ucrDSF.SetInnerControlsFieldNames(strDirectionFieldName & ucrDSF.FieldName, strSpeedFieldName & ucrDSF.FieldName, strFlagFieldName & ucrDSF.FieldName)
                End If
            Next

            SetUpTableEntry("form_hourlywind")
            AddField("signature")
            AddField("entryDatetime")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonth, ucrMonth.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrDay, ucrDay.FieldName, "=", strLinkedFieldName:="Day", bForceValuesAsString:=False)


            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)

            bFirstLoad = False

            SetDirectionValidation(112)
            SetSpeedValidation(111)
            SetDirectionAndSpeedDigitsValidationFromDB()

            'populate the values
            ucrNavigation.SetSortBy("entryDatetime")
            ucrNavigation.PopulateControl()


        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"mm", "dd"}, {ucrMonth, ucrDay}, ucrYear:=ucrYearSelector)
            'SaveEnable()
            ucrDirectionSpeedFlag0.Focus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnSaveAndUpdate_Click(sender As Object, e As EventArgs) Handles btnSave.Click, btnUpdate.Click
        'Change the signature(user) and the DATETIME first before saving 
        GetTable.Rows(0).Item("signature") = frmLogin.txtUsername.Text
        GetTable.Rows(0).Item("entryDatetime") = Date.Now
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql As String
        Dim userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_hourlywind"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_hourlywind where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_hourlywind ORDER by stationId,yyyy,mm,dd;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_hourlywind")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
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

    Private Sub btnHourSelection_Click(sender As Object, e As EventArgs) Handles btnHourSelection.Click
        Try
            Dim bNewSelectAllHours As Boolean
            If btnHourSelection.Text = "Enable all hours" Then
                bNewSelectAllHours = True
                btnHourSelection.Text = "Enable synoptic hours only"
            Else
                bNewSelectAllHours = False
                btnHourSelection.Text = "Enable all hours"
            End If

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
                Dim clsDataDefinition As New DataCall
                Dim dtbl As DataTable
                Dim iTagVal As Integer
                Dim row As DataRow
                clsDataDefinition.SetTableNameAndFields("form_hourly_time_selection", {"hh", "hh_selection"})
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
        Catch ex As Exception
            MessageBox.Show(" Error: " & ex.Message, "Digits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDirectionSpeedDigits_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirectionDigits.KeyDown, txtSpeedDigits.KeyDown
        Try
            Dim iDirectionDigits As Integer = Integer.Parse(txtDirectionDigits.Text)
            Dim iSpeedDigits As Integer = Integer.Parse(txtSpeedDigits.Text)
            SetDirectionAndSpeedDigitsValidation(iDirectionDigits, iSpeedDigits)
        Catch ex As Exception
            MessageBox.Show(" Error: " & ex.Message, "Digits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        'checkSpeedTotal()
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If Not CheckSpeedTotal() Then
                ucrInputTotal.Focus()
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean

        bValid = MyBase.ValidateValue()

        If bValid Then
            Dim ucr As ucrDirectionSpeedFlag
            Dim bValueExists As Boolean = False
            'Check if all values are empty. There should be atleast one observation value
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrDirectionSpeedFlag Then
                    ucr = DirectCast(ctr, ucrDirectionSpeedFlag)
                    If Not ucr.IsElementDirectionEmpty() OrElse Not ucr.IsElementSpeedEmpty() Then
                        bValueExists = True
                        Exit For
                    End If
                End If
            Next

            If Not bValueExists Then
                MessageBox.Show("Insufficient observation data!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            'check computed total vs input total
            If Not CheckSpeedTotal() Then
                ucrInputTotal.Focus()
                Return False
            End If

        End If

        Return bValid
    End Function

    Protected Overrides Sub ValidateDataEntryPermission()
        Dim bEnabled As Boolean
        'if its an update or any of the linked year,month and day selector is nothing then just exit the sub
        If ucrYearSelector.ValidateValue AndAlso ucrMonth.ValidateValue AndAlso ucrDay.ValidateValue Then
            Dim todayDate As Date = Date.Now
            Dim selectedDate As Date

            'initialise the dates with ONLY year month and day values to Neglect the time factor
            todayDate = New Date(todayDate.Year, todayDate.Month, todayDate.Day)
            selectedDate = New Date(ucrYearSelector.GetValue, ucrMonth.GetValue, ucrDay.GetValue)

            'if selectedDate  is earlier than todayDate (<0)  then its a valid date for data entry
            'if it is same time (0) or later than (>0) then its invalid, disable control
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

    ''' <summary>
    ''' This sets the direction and speed digits from the database 
    ''' by getting the values from the regkeys database table
    ''' </summary>
    Private Sub SetDirectionAndSpeedDigitsValidationFromDB()
        Try
            Dim clsDataDefinition As New DataCall
            Dim dtbl As DataTable
            Dim row As DataRow
            Dim iDirectionDigits As Integer
            Dim iSpeedDigits As Integer

            clsDataDefinition.SetTableNameAndFields("regkeys", {"keyName", "keyValue"})
            dtbl = clsDataDefinition.GetDataTable()
            If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
                'get direction digits
                row = dtbl.Select("keyName = 'key05'").FirstOrDefault()
                iDirectionDigits = If(row IsNot Nothing, Integer.Parse(row.Item("keyValue")), 0)

                'get speed digits
                row = dtbl.Select("keyName = 'key06'").FirstOrDefault()
                iSpeedDigits = If(row IsNot Nothing, Integer.Parse(row.Item("keyValue")), 0)
            End If

            txtDirectionDigits.Text = iDirectionDigits
            txtSpeedDigits.Text = iSpeedDigits

            SetDirectionAndSpeedDigitsValidation(iDirectionDigits, iSpeedDigits)

        Catch ex As Exception
            MessageBox.Show("Error in getting direction and speed digits in the database . Error: " & ex.Message, "Digits", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetDirectionAndSpeedDigitsValidation(iNewDirectionDigits As Integer, iNewSpeedDigits As Integer)
        Dim ucr As ucrDirectionSpeedFlag
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrDirectionSpeedFlag Then
                ucr = DirectCast(ctr, ucrDirectionSpeedFlag)
                ucr.SetElementDirectionDigits(iNewDirectionDigits)
                ucr.SetElementSpeedDigits(iNewSpeedDigits)
            End If
        Next
    End Sub

    Private Sub SetDirectionValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As New DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""

        iDirectionElementId = elementId
        clsDataDefinition.SetTableNameAndFields("obselement", {"lowerLimit", "upperLimit"})
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

    Private Sub SetSpeedValidation(elementId As Integer)
        Dim ucrDSF As ucrDirectionSpeedFlag
        Dim clsDataDefinition As New DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""
        bSpeedTotalRequired = False

        iSpeedElementId = elementId
        clsDataDefinition.SetTableNameAndFields("obselement", {"lowerLimit", "upperLimit", "qcTotalRequired"})
        clsDataDefinition.SetFilter("elementId", "=", iSpeedElementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
                bSpeedTotalRequired = If(Val(dtbl.Rows(0).Item("qcTotalRequired") <> 0), True, False)
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

    Private Function CheckSpeedTotal() As Boolean
        Dim bValueCorrect As Boolean = False
        Dim elemTotal As Decimal = 0
        Dim expectedTotal As Decimal

        If bSpeedTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsSpeedValuesEmpty() Then
                MessageBox.Show("Please enter the Total Value in the (Total [ff]) textbox.", "Error in total", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                End If
            End If
        Else
            bValueCorrect = True
        End If

        If Not bValueCorrect Then
            ucrInputTotal.SetBackColor(Color.Red)
        End If

        Return bValueCorrect
    End Function

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


    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim clsAllRecordsCall As New DataCall
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
        Dim strSignature As String
        Dim pos As Integer = 0
        Dim iUpdatesNum As Integer = 0
        Dim iInsertsNum As Integer = 0
        Dim invalidRecord As Boolean = False
        Dim strResult As String = ""
        Dim strTableName As String

        Try
            strTableName = GetTableName()

            'Get all the records from the table
            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand("Select * FROM " & strTableName & " ORDER BY entryDatetime", clsDataConnection.OpenedConnection)
                Using da As New MySql.Data.MySqlClient.MySqlDataAdapter(cmdSelect)
                    da.Fill(dtbAllRecords)
                End Using
            End Using

            For Each row As DataRow In dtbAllRecords.Rows
                If backgroundWorker.CancellationPending = True Then
                    e.Cancel = True
                    Exit For
                End If
                'Display progress of data transfer
                pos += 1
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

                        Try
                            dtObsDateTime = New Date(row.Item("yyyy"), row.Item("mm"), row.Item("dd"), hh, 0, 0)
                        Catch ex As Exception
                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record | " &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Day: " & row.Item("dd") & ", Hour: " & hh &
                                ". This row was skipped" & Environment.NewLine
                            Exit For
                        End Try

                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.OpenedConnection)
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
                            Using cmdSave As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.OpenedConnection)
                                cmdSave.Parameters.AddWithValue("@stationId", strStationId)
                                cmdSave.Parameters.AddWithValue("@elemCode", lElementId)
                                cmdSave.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                                cmdSave.Parameters.AddWithValue("@obsLevel", "surface")
                                cmdSave.Parameters.AddWithValue("@obsVal", row.Item(strValueColumn))
                                cmdSave.Parameters.AddWithValue("@obsFlag", row.Item(strFlagColumn))
                                cmdSave.Parameters.AddWithValue("@qcStatus", 0)
                                cmdSave.Parameters.AddWithValue("@acquisitiontype", 1)
                                cmdSave.Parameters.AddWithValue("@capturedBy", strSignature)
                                cmdSave.Parameters.AddWithValue("@dataForm", strTableName)

                                cmdSave.ExecuteNonQuery()
                            End Using
                            If bUpdateRecord Then
                                iUpdatesNum += 1
                            Else
                                iInsertsNum += 1
                            End If
                        Catch ex As Exception
                            'MsgBox("Invalid record detected. Record number " & pos & " could not be uploaded. This record will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid record detected. Record number " & pos & " could not be uploaded" &
                              " Station: " & strStationId & ", Element: " & lElementId &
                              ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Hour: " & row.Item("hh") & ", Date: " & dtObsDateTime &
                               ". This record was skipped" & Environment.NewLine
                            Exit For
                        End Try

                    End If
                Next
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