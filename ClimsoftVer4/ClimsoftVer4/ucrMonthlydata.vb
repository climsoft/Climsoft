Public Class ucrMonthlyData
    Private strValueFieldName As String = "mm_"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private Sub ucrMonthlyData_Load(sender As Object, e As EventArgs) Handles Me.Load

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
                    ucrVFP.SetInnerControlsFieldNames(strValueFieldName & ucrVFP.FieldName, strFlagFieldName & ucrVFP.FieldName, strPeriodFieldName & ucrVFP.FieldName)
                End If
            Next

            SetUpTableEntry("form_monthly")

            AddField("signature")
            AddField("entryDatetime")

            AddLinkedControlFilters(ucrStationSelector, ucrStationSelector.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
            AddLinkedControlFilters(ucrElementSelector, ucrElementSelector.FieldName, "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
            AddLinkedControlFilters(ucrYearSelector, ucrYearSelector.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)

            'set up the navigation control
            ucrNavigation.SetTableEntryAndKeyControls(Me)

            bFirstLoad = False

            'add extra filters for none admin users
            If Not (userGroup = "ClimsoftAdmin" OrElse userGroup = "ClimsoftOperatorSupervisor") Then
                AddExtraFilters("signature", frmLogin.txtUsername.Text, "=", bForceValuesAsString:=True)
            End If

            ucrNavigation.SetSortBy("entryDatetime")
            'populate the values
            ucrNavigation.PopulateControl()

        End If
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            ucrNavigation.NewSequencerRecord(txtSequencer.Text, {"elementId"}, ucrYear:=ucrYearSelector)
            'SaveEnable()
            UcrValueFlagPeriod1.Focus()
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

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql As String
        Dim userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_monthly"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_monthly where signature ='" & userName & "' ORDER by stationId,elementId,yyyy;"
        Else
            sql = "SELECT * FROM form_monthly ORDER by stationId,elementId,yyyy;"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_monthly")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If MessageBox.Show("Are you sure you want to upload these records?", "Upload Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Upload through a dialog that allows records selection
            frmFormUpload.lblFormName1.Text = "form_monthly"
            frmFormUpload.Show()
            frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName1.Text

            Exit Sub
            UploadAllRecords()
            'MessageBox.Show("Records have been uploaded sucessfully", "Upload Records", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        End If

        Return bValid
    End Function

    Protected Overrides Sub SetValuesValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", {"lowerLimit", "upperLimit", "qcTotalRequired"})
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrElementSelector.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
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

    'TODO. Push this to the table entry level
    Protected Overrides Sub ValidateDataEntryPermission()
        Dim iSelectedYear As Integer = If(ucrYearSelector.ValidateValue, ucrYearSelector.GetValue, -1)
        Dim iCurrentYear As Integer = Date.Now.Year
        Dim iCurrentMonth As Integer = Date.Now.Month

        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueView AndAlso Not DirectCast(ctr, ucrValueView).KeyControl Then
                If iSelectedYear = -1 Then
                    ctr.Enabled = False
                ElseIf iSelectedYear < iCurrentYear Then
                    ctr.Enabled = True
                ElseIf iSelectedYear = iCurrentYear AndAlso IsNumeric(ctr.Tag) Then
                    ctr.Enabled = If(Integer.Parse(ctr.Tag) <= iCurrentMonth, True, False)
                Else
                    ctr.Enabled = False
                End If
            End If
        Next

    End Sub

    Private Sub ucrMonthlyData_GoingToNextChildControl(sender As Object) Handles Me.GoingToNextChildControl
        'set the number of days in the month as the period if the following conditions are true
        If TypeOf sender Is ucrValueFlagPeriod AndAlso ucrYearSelector.ValidateValue Then
            Dim ucr As ucrValueFlagPeriod = DirectCast(sender, ucrValueFlagPeriod)
            If IsNumeric(ucr.Tag) Then
                ucr.SetElementPeriodValue(Date.DaysInMonth(ucrYearSelector.GetValue, Integer.Parse(ucr.Tag)))
            End If
        End If
    End Sub

    'upload code in the background thread
    Private Sub UploadAllRecords()
        Dim frm As New frmNewComputationProgress
        frm.SetHeader("Uploading " & ucrNavigation.iMaxRows & " records")
        frm.SetProgressMaximum(ucrNavigation.iMaxRows)
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
        Dim pos As Integer = 0

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(GetTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        Try

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

                    strTag = strFieldName.Substring(Me.strValueFieldName.Length)
                    strFlagColumn = lstFields.Find(Function(x As String)
                                                       Return x.Equals(Me.strFlagFieldName & strTag)
                                                   End Function)
                    'set the record
                    If (Not IsDBNull(row.Item(strValueColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strValueColumn)) OrElse (Not IsDBNull(row.Item(strFlagColumn)) AndAlso Not String.IsNullOrEmpty(row.Item(strFlagColumn)))) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then
                        strStationId = row.Item("stationId")
                        strPeriodColumn = lstFields.Find(Function(x As String)
                                                             Return x.Equals(Me.strPeriodFieldName & strTag)
                                                         End Function)


                        dtObsDateTime = New Date(row.Item("yyyy"), Val(strTag), Date.DaysInMonth(row.Item("yyyy"), Integer.Parse(Val(strTag))), 6, 0, 0)
                        bUpdateRecord = False
                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Using cmd As New MySqlConnector.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
                            cmd.Parameters.AddWithValue("@stationId", strStationId)
                            cmd.Parameters.AddWithValue("@elemCode", lElementId)
                            cmd.Parameters.AddWithValue("@obsDatetime", dtObsDateTime)
                            cmd.Parameters.AddWithValue("@qcStatus", 0)
                            cmd.Parameters.AddWithValue("@acquisitiontype", 1)
                            cmd.Parameters.AddWithValue("@dataForm", GetTableName)
                            Using reader As MySqlConnector.MySqlDataReader = cmd.ExecuteReader()
                                bUpdateRecord = reader.HasRows
                            End Using
                        End Using

                        iPeriod = 0 'reinitialise period. Then try to set if valid value is present
                        If Not IsDBNull(row.Item(strPeriodColumn)) Then
                            Integer.TryParse(row.Item(strPeriodColumn), iPeriod)
                        End If

                        strSignature = If(IsDBNull(row.Item("signature")), "", row.Item("signature"))

                        If bUpdateRecord Then
                            strSql = "UPDATE observationInitial SET recordedFrom=@stationId,describedBy=@elemCode,obsDatetime=@obsDatetime,obsLevel=@obsLevel,obsValue=@obsVal,flag=@obsFlag,period=@obsPeriod,qcStatus=@qcStatus,acquisitionType=@acquisitiontype,capturedBy=@capturedBy,dataForm=@dataForm " &
                                " WHERE recordedFrom=@stationId And describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Else
                            strSql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,flag,period,qcStatus,acquisitionType,capturedBy,dataForm) " &
                            "VALUES (@stationId,@elemCode,@obsDatetime,@obsLevel,@obsVal,@obsFlag,@obsPeriod,@qcStatus,@acquisitiontype,@capturedBy,@dataForm)"
                        End If

                        Using cmd As New MySqlConnector.MySqlCommand(strSql, clsDataConnection.GetOpenedConnection)
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
                            cmd.Parameters.AddWithValue("@dataForm", GetTableName)
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
            Next

            e.Result = "Records have been uploaded sucessfully"
        Catch ex As Exception
            e.Result = "Error " & ex.Message
        End Try


        'TODO? because of the detachment
        'PopulateControl()

    End Sub


    Private Sub btnPush_Click(sender As Object, e As EventArgs) Handles btnPush.Click
        Dim TblName As New dataEntryGlobalRoutines
        Me.Cursor = Cursors.WaitCursor
        If TblName.DataPush("form_monthly") Then
            MsgBox("Data Pushed to remote server successfully")
        Else
            MsgBox("Data Push Failed!")
        End If
        Me.Cursor = Cursors.Default
    End Sub
End Class