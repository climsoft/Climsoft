
Public Class ucrFormDaily2

    'These store field names for value, flag and period
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private bTotalRequired As Boolean
    Dim FldName As New dataEntryGlobalRoutines

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then

            'Sets values for the units combobox
            ucrTempUnits.SetPossibleValues("temperatureUnits", GetType(String), {"Deg C", "Deg F"})
            ucrTempUnits.SetDisplayAndValueMember("temperatureUnits")
            ucrTempUnits.SetDefaultValue("Deg C")
            ucrTempUnits.bValidate = False

            ucrCloudheightUnits.SetPossibleValues("cloudHeightUnits", GetType(String), {"feet", "metres"})
            ucrCloudheightUnits.SetDisplayAndValueMember("cloudHeightUnits")
            ucrCloudheightUnits.SetDefaultValue("feet")
            ucrCloudheightUnits.bValidate = False

            ucrPrecipUnits.SetPossibleValues("precipUnits", GetType(String), {"mm", "inches"})
            ucrPrecipUnits.SetDisplayAndValueMember("precipUnits")
            ucrPrecipUnits.SetDefaultValue("mm")
            ucrPrecipUnits.bValidate = False

            ucrVisibilityUnits.SetPossibleValues("visUnits", GetType(String), {"metres", "yards"})
            ucrVisibilityUnits.SetDisplayAndValueMember("visUnits")
            ucrVisibilityUnits.SetDefaultValue("metres")
            ucrVisibilityUnits.bValidate = False



            ucrHour.SetDefaultValue(GetDefaultHourValue())


            'the alternative of this would be to select the first control (in the designer), click Send to Back, and repeat.
            Dim allVFP = From vfp In Me.Controls.OfType(Of ucrValueFlagPeriod)() Order By vfp.TabIndex
            Dim shiftCells As New ClsShiftCells()
            shiftCells.SetUpShiftCellsMenuStrips(New ContextMenuStrip, allVFP)
            'set up the value flag peruiod first
            Dim ucrVFP As ucrValueFlagPeriod
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueFlagPeriod Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName, strPeriodFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_daily2")

            'this is placed here to add onto the keydown event set in the SetUpTableEntry() subroutine
            AddHandler ucrInputTotal.evtKeyDown, Sub(sender1 As Object, e1 As KeyEventArgs)
                                                     If e1.KeyCode = Keys.Enter Then
                                                         If Not CheckTotal() Then
                                                             ucrInputTotal.Focus()
                                                             e1.SuppressKeyPress = True
                                                         End If
                                                     End If
                                                 End Sub

            AddField("signature")
            AddField("entryDatetime")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrElementSelector, ucrElementSelector.FieldName, "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrMonth, ucrMonth.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrHour, ucrHour.FieldName, "=", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)

            'set up the navigation control
            ucrDaily2Navigation.SetTableEntryAndKeyControls(Me)

            bFirstLoad = False

            'populate the values
            ucrDaily2Navigation.SetSortBy("entryDatetime")
            ucrDaily2Navigation.PopulateControl()

            ' Check for key entry mode and indicate on the form
            If FldName.Key_Entry_Mode(frmNewFormDaily2.Text) = "Double" Then chkRepeatEntry.Checked = True
        End If

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Dim usrStn As New dataEntryGlobalRoutines
        Dim txtElementCode As String

        txtElementCode = ucrElementSelector.cboValues.SelectedValue

        If chkEnableSequencer.Checked Then
            ' temporary until we know how to get all fields from table without specifying names

            ' The following code has been disabled because it is found not to work well
            'ucrDaily2Navigation.NewSequencerRecord(txtSequencer.Text, {"elementId"}, {ucrMonth}, ucrYearSelector)
            SaveEnable()
            ucrValueFlagPeriod1.Focus()

            'Get the Station from the last record by the current login user
            usrStn.GetCurrentStation("form_daily2", ucrStationSelector.cboValues.Text)

            ' Sequence the element the date
            Seq_Element(txtElementCode)
            ucrElementSelector.cboValues.SelectedValue = txtElementCode

        End If

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
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_daily2"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_daily2 where signature ='" & userName & "' ORDER by stationId,elementId,yyyy,mm,hh;"
        Else
            sql = "SELECT * FROM form_daily2 ORDER by stationId,elementId,yyyy,mm,hh;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_daily2")
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

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress
        frmFormUpload.lblFormName.Text = "form_daily2"
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName.Text

        frmFormUpload.Show()
        Exit Sub


        'upload code in the background thread
        Dim frm As New frmNewComputationProgress
        frm.SetHeader("Uploading " & ucrDaily2Navigation.iMaxRows & " records")
        frm.SetProgressMaximum(ucrDaily2Navigation.iMaxRows)
        frm.ShowNumbers(True)
        frm.ShowResultMessage(True)
        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

        frm.backgroundWorker.RunWorkerAsync()
        frm.Show()
    End Sub

    Private Sub chkEnableSequencer_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnableSequencer.CheckedChanged
        txtSequencer.Text = If(chkEnableSequencer.Checked, "seq_daily_element", "")
    End Sub

    Private Function IsValuesEmpty() As Boolean
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
        Dim bValueCorrect As Boolean
        Dim elemTotal As Decimal = 0
        Dim expectedTotal As Decimal

        If bTotalRequired Then
            If ucrInputTotal.IsEmpty AndAlso Not IsValuesEmpty() Then
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

    'Get the default hour settings from the database
    Private Function GetDefaultHourValue() As Integer
        Dim iDefaultHourValue As Integer = 0
        Dim clsDataDefinition As New DataCall
        Dim dtbl As DataTable

        clsDataDefinition.SetTableNameAndFields("regkeys", {"keyName", "keyValue"})
        clsDataDefinition.SetFilter("keyName", "=", "key01", bIsPositiveCondition:=True, bForceValuesAsString:=True)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            Integer.TryParse(dtbl.Rows(0).Item("keyValue"), iDefaultHourValue)
        End If

        Return iDefaultHourValue

    End Function

    ''' <summary>
    ''' Sets upper and lower limits validation curent element
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
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            strLowerLimit = If(IsDBNull(dtbl.Rows(0).Item("lowerLimit")), "", dtbl.Rows(0).Item("lowerLimit"))
            strUpperLimit = If(IsDBNull(dtbl.Rows(0).Item("upperLimit")), "", dtbl.Rows(0).Item("upperLimit"))
            'qcTotalRequired is a nullable integer in the EF model
            If Not IsDBNull(dtbl.Rows(0).Item("qcTotalRequired")) Then
                bTotalRequired = (Val(dtbl.Rows(0).Item("qcTotalRequired")) <> 0)
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
        Dim iMonthLength As Integer
        Dim todaysDate As Date
        todaysDate = Date.Now

        If ucrYearSelector.ValidateValue AndAlso ucrMonth.ValidateValue Then
            If ucrYearSelector.GetValue > todaysDate.Year OrElse (ucrYearSelector.GetValue = todaysDate.Year AndAlso ucrMonth.GetValue > todaysDate.Month) Then
                For Each ctr As Control In Me.Controls
                    If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                        ctr.Enabled = False
                    End If
                Next

            Else
                If ucrYearSelector.GetValue = todaysDate.Year AndAlso ucrMonth.GetValue = todaysDate.Month Then
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag) >= todaysDate.Day, False, True)
                        End If
                    Next
                Else
                    iMonthLength = Date.DaysInMonth(ucrYearSelector.GetValue, ucrMonth.GetValue())
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag > iMonthLength), False, True)
                        End If
                    Next
                End If

            End If
        Else
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                    ctr.Enabled = False
                End If
            Next
        End If


    End Sub

    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        Dim dtbAllRecords As New DataTable
        Dim strCurrTag As String
        Dim dtObsDateTime As Date
        Dim strStationId As String
        Dim lElementId As Long
        Dim iPeriod As Integer
        Dim bUpdateRecord As Boolean
        Dim strSql As String
        Dim strSignature As String
        Dim strTempUnits As String
        Dim strPrecipUnits As String
        Dim strCloudHeightUnits As String
        Dim strVisUnits As String
        Dim pos As Integer = 0
        Dim iUpdatesNum As Integer = 0
        Dim iInsertsNum As Integer = 0
        Dim invalidRecord As Boolean = False
        Dim strResult As String = ""
        Dim strTableName As String

        Try

            strTableName = GetTableName()

            'Get all the records from the table
            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand("Select * FROM " & strTableName & " ORDER BY entryDatetime", clsDataConnection.GetOpenedConnection)
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

                For i As Integer = 1 To 31
                    If i < 10 Then
                        strCurrTag = "0" & i
                    Else
                        strCurrTag = i
                    End If

                    If ((Not IsDBNull(row.Item("day" & strCurrTag)) AndAlso Not String.IsNullOrEmpty(row.Item("day" & strCurrTag))) OrElse (Not IsDBNull(row.Item("flag" & strCurrTag)) AndAlso Not String.IsNullOrEmpty(row.Item("flag" & strCurrTag)))) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                        strStationId = row.Item("stationId")
                        Try
                            dtObsDateTime = New Date(year:=row.Item("yyyy"), month:=row.Item("mm"), day:=i, hour:=row.Item("hh"), minute:=0, second:=0)
                        Catch ex As Exception
                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record | " &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Hour: " & row.Item("hh") &
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

                        iPeriod = 0
                        strSignature = ""
                        strTempUnits = ""
                        strPrecipUnits = ""
                        strCloudHeightUnits = ""
                        strVisUnits = ""

                        If Not IsDBNull(row.Item("period" & strCurrTag)) Then
                            Integer.TryParse(row.Item("period" & strCurrTag), iPeriod)
                        End If


                        If Not IsDBNull(row.Item("signature")) Then
                            strSignature = row.Item("signature")
                        End If
                        If Not IsDBNull(row.Item("temperatureUnits")) Then
                            strTempUnits = row.Item("temperatureUnits")
                        End If
                        If Not IsDBNull(row.Item("precipUnits")) Then
                            strPrecipUnits = row.Item("precipUnits")
                        End If
                        If Not IsDBNull(row.Item("cloudHeightUnits")) Then
                            strCloudHeightUnits = row.Item("cloudHeightUnits")
                        End If
                        If Not IsDBNull(row.Item("visUnits")) Then
                            strVisUnits = row.Item("visUnits")
                        End If


                        If bUpdateRecord Then
                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,period=@obsPeriod,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm,temperatureUnits=@temperatureUnits,precipitationUnits=@precipUnits,cloudHeightUnits=@cloudHeightUnits,visUnits=@visUnits " &
                                " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Else
                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,capturedBy,dataForm,temperatureUnits,precipitationUnits,cloudHeightUnits,visUnits) " &
                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@obsPeriod,@qcStatus,@acquisitiontype,@capturedBy,@dataForm,@temperatureUnits,@precipUnits,@cloudHeightUnits,@visUnits)"
                        End If

                        Try
                            Using cmdSave As New MySql.Data.MySqlClient.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
                                'cmd.Parameters.Add("@stationId", SqlDbType.VarChar, 255).Value = strStationId
                                cmdSave.Parameters.AddWithValue("@stationId", strStationId)
                                cmdSave.Parameters.AddWithValue("@elemCode", lElementId)
                                cmdSave.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                                cmdSave.Parameters.AddWithValue("@obsLevel", "surface")
                                cmdSave.Parameters.AddWithValue("@obsVal", row.Item("day" & strCurrTag))
                                cmdSave.Parameters.AddWithValue("@obsFlag", row.Item("flag" & strCurrTag))
                                cmdSave.Parameters.AddWithValue("@obsPeriod", If(iPeriod > 0, iPeriod, DBNull.Value))
                                cmdSave.Parameters.AddWithValue("@qcStatus", 0)
                                cmdSave.Parameters.AddWithValue("@acquisitiontype", 1)
                                cmdSave.Parameters.AddWithValue("@capturedBy", strSignature)
                                cmdSave.Parameters.AddWithValue("@dataForm", GetTableName)
                                cmdSave.Parameters.AddWithValue("@temperatureUnits", strTempUnits)
                                cmdSave.Parameters.AddWithValue("@precipUnits", strPrecipUnits)
                                cmdSave.Parameters.AddWithValue("@cloudHeightUnits", strCloudHeightUnits)
                                cmdSave.Parameters.AddWithValue("@visUnits", strVisUnits)
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

    Function Seq_Element(ByRef eCode As String) As Boolean

        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim da_seq As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim strConnString, sql_seq, elm As String
        Dim ds_seq As New DataSet
        Dim kount As Integer
        Dim yy, mm, dt As String

        Try
            strConnString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = strConnString
            conn.Open()

            sql_seq = "select elementId from seq_daily_element order by seq;"

            da_seq = New MySql.Data.MySqlClient.MySqlDataAdapter(sql_seq, conn)
            ds_seq.Clear()
            da_seq.SelectCommand.CommandTimeout = 0
            da_seq.Fill(ds_seq, "Sequence")

            'conn.Close()

            With ds_seq.Tables("Sequence")

                If .Rows.Count > 0 Then
                    kount = 0
                    elm = .Rows(0).Item("elementId")
                    For i = 0 To .Rows.Count - 1
                        If eCode = .Rows(i).Item("elementId") Then
                            If i < .Rows.Count - 1 Then
                                elm = .Rows(i + 1).Item("elementId")
                            Else
                                If seqDate() Then eCode = .Rows(0).Item("elementId")
                            End If
                            Exit For
                        End If
                        kount = kount + 1
                    Next

                    eCode = elm

                    ' Check for months to record GrassMin Temp
                    If eCode = 99 And skipGroundMin(conn) Then
                        If kount < .Rows.Count - 2 Then
                            eCode = .Rows(kount + 2).Item("elementId")
                        ElseIf kount = .Rows.Count - 2 Then
                            If seqDate() Then eCode = .Rows(0).Item("elementId")
                        ElseIf kount = .Rows.Count - 1 Then
                            eCode = .Rows(1).Item("elementId")
                        End If
                    End If
                End If
            End With
            conn.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
            Return False
        End Try
    End Function
    Function seqDate() As Boolean
        Dim yy, mm, dt As String
        Try
            'sequence the date by 1 month increment
            yy = ucrYearSelector.cboValues.Text
            mm = ucrMonth.cboValues.Text
            dt = DateSerial(yy, mm, 1)
            dt = DateAdd("m", 1, dt)
            ucrYearSelector.cboValues.Text = DateAndTime.Year(dt)
            ucrMonth.cboValues.Text = DateAndTime.Month(dt)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Function skipGroundMin(conn As MySql.Data.MySqlClient.MySqlConnection) As Boolean
        Dim daq As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsq As New DataSet
        Dim sql As String
        Dim st_month, ed_month, rec_month As Integer

        sql = "select keyName,keyValue from regkeys where keyName = 'key03' or keyName = 'key04';"
        Try
            daq = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dsq.Clear()
            daq.SelectCommand.CommandTimeout = 0
            daq.Fill(dsq, "months")

            rec_month = CInt(ucrMonth.cboValues.Text)

            With dsq.Tables("months")
                If .Rows.Count < 2 Then Return False ' Period not defined in Registry
                st_month = .Rows(0).Item("keyValue")
                ed_month = .Rows(1).Item("keyValue")
            End With

            If ed_month > st_month Then ' Period within same year
                If rec_month >= st_month And rec_month <= ed_month Then
                    Return False
                Else
                    Return True
                End If
            Else ' Period crosses the year
                If (rec_month >= st_month And rec_month <= 12) Or (rec_month >= 1 And rec_month <= ed_month) Then
                    Return False
                Else
                    Return True
                End If
            End If

            Return True
        Catch ex As Exception
            Return True
        End Try
    End Function

End Class