Imports System.Data.SqlClient
Imports System.Linq.Dynamic

Public Class ucrFormDaily2

    Dim strTableName As String
    'These store field names for value, flag and period
    Private strValueFieldName As String = "day"
    Private strFlagFieldName As String = "flag"
    Private strPeriodFieldName As String = "period"
    Private strTotalFieldName As String = "total"
    Private bTotalRequired As Boolean
    'stores a list containing all fields of this control
    Private lstAllFields As New List(Of String)

    'These store instances of linked controls
    Private ucrLinkedMonth As ucrMonth
    Private ucrLinkedYear As ucrYearSelector
    Private dctLinkedUnits As New Dictionary(Of String, ucrDataLinkCombobox)
    Private ucrLinkedHour As ucrHour
    Private ucrLinkedNavigation As ucrNavigation
    Private ucrLinkedStation As ucrStationSelector
    Private ucrLinkedElement As ucrElementSelector


    ''' <summary>
    ''' Sets the values of the controls to the coresponding record values in the database with the current key
    ''' </summary>
    Public Overrides Sub PopulateControl()
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
                    DirectCast(ctr, ucrValueFlagPeriod).SetValue(New List(Of Object)({GetFieldValue(strValueFieldName & ctr.Tag), GetFieldValue(strFlagFieldName & ctr.Tag), GetFieldValue(strPeriodFieldName & ctr.Tag)}))
                ElseIf TypeOf ctr Is ucrTextBox Then
                    DirectCast(ctr, ucrTextBox).SetValue(GetFieldValue(strTotalFieldName))
                End If
            Next

            'set values for the units
            If bUpdating Then
                For Each kvpTemp As KeyValuePair(Of String, ucrDataLinkCombobox) In dctLinkedUnits
                    kvpTemp.Value.SetValue(GetFieldValue(kvpTemp.Key))
                Next
            Else
                For Each ucrCombobox As ucrDataLinkCombobox In dctLinkedUnits.Values
                    ucrCombobox.SelectDefault()
                Next
            End If

            'OnevtValueChanged(Me, Nothing)
        End If

        ' Set conditions for double key entry
        If frmNewFormDaily2.chkRepeatEntry.Checked Then
            Me.Clear()
            ucrValueFlagPeriod1.ucrValue.GetFocus()
            With frmNewFormDaily2
                .btnAddNew.Enabled = False
                .btnCommit.Enabled = False
                .btnUpdate.Enabled = True
            End With
        End If
    End Sub

    Private Sub ucrFormDaily2_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ucrVFP As ucrValueFlagPeriod
        Dim ucrTotal As ucrTextBox
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

                ElseIf TypeOf ctr Is ucrTextBox Then
                    ucrTotal = DirectCast(ctr, ucrTextBox)
                    ucrTotal.SetTableNameAndField(strTableName, strTotalFieldName)
                    lstFields.Add(strTotalFieldName)
                    AddHandler ucrTotal.evtValueChanged, AddressOf InnerControlValueChanged
                End If
            Next

            strTableName = "form_daily2"
            'crTableEntry_Load fills in the lstFields 
            'SetUpTableEntry()
            SetTableNameAndFields(strTableName, lstFields)

            bFirstLoad = False

        End If
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrValueView, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        If Not lstFields.Contains(tblFilter.GetField) Then
            lstFields.Add(tblFilter.GetField)
            SetFields(lstFields)
        End If
    End Sub

    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucrText As ucrTextBox
        'If fd2Record IsNot Nothing Then
        If TypeOf sender Is ucrTextBox Then
                ucrText = DirectCast(sender, ucrTextBox)
                'TODO Replace this with a call to update the datatable

                'CallByName(fd2Record, ucrText.GetField, CallType.Set, ucrText.GetValue)
            ElseIf TypeOf sender Is ucrDataLinkCombobox Then
                For Each kvpTemp As KeyValuePair(Of String, ucrDataLinkCombobox) In dctLinkedUnits
                    'overwrite the specific unit value
                    If sender Is kvpTemp.Value Then
                        'TODO Replace this with a call to update the datatable

                        'CallByName(fd2Record, kvpTemp.Key, CallType.Set, kvpTemp.Value.GetValue)
                        Exit For
                    End If
                Next
            End If
        'End If
    End Sub

    Private Sub GoToNextVFPControl(sender As Object, e As KeyEventArgs)
        SelectNextControl(sender, True, True, True, True)
        'this handles the "noise" on enter  
        e.SuppressKeyPress = True
    End Sub

    Private Sub ucrInputTotal_evtKeyDown(sender As Object, e As KeyEventArgs) Handles ucrInputTotal.evtKeyDown
        If e.KeyCode = Keys.Enter Then
            If checkTotal() Then
                Me.FindForm.SelectNextControl(sender, True, True, True, True)
                e.SuppressKeyPress = True
            End If
        End If
    End Sub

    Private Sub ucrInputTotal_Leave(sender As Object, e As EventArgs) Handles ucrInputTotal.Leave
        checkTotal()
    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        Dim bValidValues As Boolean = True

        'validate the values of the linked key filter controls
        'For Each key As ucrValueView In dctLinkedControlsFilters.Keys
        ' If Not key.ValidateValue() Then
        'bValidValues = False
        'Exit For
        ' End If
        'Next

        If bValidValues Then
            'will populate the datatable based on the new key values
            'MyBase.LinkedControls_evtValueChanged()

            'For Each kvpTemp As KeyValuePair(Of ucrValueView, KeyValuePair(Of String, TableFilter)) In dctLinkedControlsFilters
            'TODO Replace this with a call to update the datatable
            'CallByName(fd2Record, kvpTemp.Value.Value.GetField(), CallType.Set, kvpTemp.Key.GetValue)
            ' Next
            ' ucrLinkedNavigation.UpdateNavigationByKeyControls()
        Else
            'TODO. DISABLE??
            'Me.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Sets the  filed name and the control for the liked units
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <param name="ucrComboBox"></param>
    Public Sub AddUnitslink(strFieldName As String, ucrComboBox As ucrDataLinkCombobox)
        If dctLinkedUnits.ContainsKey(strFieldName) Then
            MessageBox.Show("Developer error: This field is already linked.", caption:="Developer error")
        Else
            dctLinkedUnits.Add(strFieldName, ucrComboBox)
            AddHandler ucrComboBox.evtValueChanged, AddressOf InnerControlValueChanged
            'add the field
            If Not lstFields.Contains(strFieldName) Then
                lstFields.Add(strFieldName)
                SetFields(lstFields)
            End If
        End If
    End Sub

    Public Sub SaveRecord()
        'TODO Replace this with a call to update or insert record the datatable and the datasorce
        If bUpdating Then
        Else
        End If

        TEMPCODE()

        If 1 = 1 Then
            Return
        End If

        Dim conn As New MySql.Data.MySqlClient.MySqlConnection

        Try

            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()

            Dim dataAdpater As MySql.Data.MySqlClient.MySqlDataAdapter

            dataAdpater = New MySql.Data.MySqlClient.MySqlDataAdapter(
                "SELECT elementId, elementName FROM obselement", conn)

            dataAdpater.UpdateCommand = New MySql.Data.MySqlClient.MySqlCommand(
           "UPDATE obselement SET elementName = @elementName WHERE elementId = @elementId", conn)

            dataAdpater.UpdateCommand.Parameters.Add("@elementName", MySql.Data.MySqlClient.MySqlDbType.VarChar, 255, "elementName")


            Dim param1 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@elementId", MySql.Data.MySqlClient.MySqlDbType.Int64, 20)
            param1.SourceColumn = "elementId"
            param1.SourceVersion = DataRowVersion.Original


            Dim dailyTable As New DataTable

            dataAdpater.Fill(dailyTable)

            Dim row As DataRow
            row = dailyTable.Rows(0)
            row("elementName") = "my element"

            dataAdpater.Update(dailyTable)



        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            'MsgBox("Error : " & ex.Message)
        Finally
            conn.Close()
        End Try



    End Sub

    Private Sub TEMPCODE()
        Dim conn As MySql.Data.MySqlClient.MySqlConnection

        Try

            conn = clsDataConnection.conn

            'conn.ConnectionString = frmLogin.txtusrpwd.Text
            'conn.Open()

            Dim dataAdpater As MySql.Data.MySqlClient.MySqlDataAdapter

            dataAdpater = New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT stationId, elementId, yyyy, mm, hh, day01 FROM form_daily2", conn)

            'setup delete command
            dataAdpater.DeleteCommand = New MySql.Data.MySqlClient.MySqlCommand(
            "DELETE FROM form_daily2 WHERE stationId = @stationId AND elementId = @elementId AND yyyy = @yyyy AND mm = @mm AND hh = @hh", conn)

            Dim param11 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.DeleteCommand.Parameters.Add("@stationId", MySql.Data.MySqlClient.MySqlDbType.VarChar, 50)
            param11.SourceColumn = "stationId"
            param11.SourceVersion = DataRowVersion.Original

            Dim param21 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.DeleteCommand.Parameters.Add("@elementId", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param21.SourceColumn = "elementId"
            param21.SourceVersion = DataRowVersion.Original


            Dim param31 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.DeleteCommand.Parameters.Add("@yyyy", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param31.SourceColumn = "yyyy"
            param31.SourceVersion = DataRowVersion.Original

            Dim param41 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.DeleteCommand.Parameters.Add("@mm", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param41.SourceColumn = "mm"
            param41.SourceVersion = DataRowVersion.Original

            Dim param51 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.DeleteCommand.Parameters.Add("@hh", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param51.SourceColumn = "hh"
            param51.SourceVersion = DataRowVersion.Original

            'setup insert command
            dataAdpater.InsertCommand = New MySql.Data.MySqlClient.MySqlCommand(
            "INSERT INTO form_daily2 (stationId,elementId,yyyy,mm,hh,day01) VALUES (@stationId,@elementId,@yyyy,@mm,@hh,@day01)", conn)

            dataAdpater.InsertCommand.Parameters.Add("@stationId", MySql.Data.MySqlClient.MySqlDbType.VarChar, 50, "stationId")
            dataAdpater.InsertCommand.Parameters.Add("@elementId", MySql.Data.MySqlClient.MySqlDbType.Int32, 11, "elementId")
            dataAdpater.InsertCommand.Parameters.Add("@yyyy", MySql.Data.MySqlClient.MySqlDbType.Int32, 11, "yyyy")
            dataAdpater.InsertCommand.Parameters.Add("@mm", MySql.Data.MySqlClient.MySqlDbType.Int32, 11, "mm")
            dataAdpater.InsertCommand.Parameters.Add("@hh", MySql.Data.MySqlClient.MySqlDbType.Int32, 11, "hh")
            dataAdpater.InsertCommand.Parameters.Add("@day01", MySql.Data.MySqlClient.MySqlDbType.VarChar, 45, "day01")


            'set up update command
            dataAdpater.UpdateCommand = New MySql.Data.MySqlClient.MySqlCommand(
            "UPDATE form_daily2 SET yyyy = @yyyy2 , day01 = @day01 WHERE stationId = @stationId AND elementId = @elementId AND yyyy = @yyyy AND mm = @mm AND hh = @hh", conn)


            dataAdpater.UpdateCommand.Parameters.Add("@yyyy2", MySql.Data.MySqlClient.MySqlDbType.Int32, 11, "yyyy")
            dataAdpater.UpdateCommand.Parameters.Add("@day01", MySql.Data.MySqlClient.MySqlDbType.VarChar, 45, "day01")


            Dim param1 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@stationId", MySql.Data.MySqlClient.MySqlDbType.VarChar, 50)
            param1.SourceColumn = "stationId"
            param1.SourceVersion = DataRowVersion.Original

            Dim param2 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@elementId", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param2.SourceColumn = "elementId"
            param2.SourceVersion = DataRowVersion.Original


            Dim param3 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@yyyy", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param3.SourceColumn = "yyyy"
            param3.SourceVersion = DataRowVersion.Original


            Dim param4 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@mm", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param4.SourceColumn = "mm"
            param4.SourceVersion = DataRowVersion.Original

            Dim param5 As MySql.Data.MySqlClient.MySqlParameter = dataAdpater.UpdateCommand.Parameters.Add("@hh", MySql.Data.MySqlClient.MySqlDbType.Int32, 11)
            param5.SourceColumn = "hh"
            param5.SourceVersion = DataRowVersion.Original

            Dim dailyTable As New DataTable

            dataAdpater.Fill(dailyTable)

            Dim row As DataRow
            row = dailyTable.Rows(0)

            Dim row2 As DataRow
            row2 = dailyTable.NewRow()
            row2("stationId") = row("stationId")
            row2("elementId") = row("elementId")
            row2("yyyy") = row("yyyy")
            row2("mm") = row("mm")
            row2("hh") = row("hh")
            row2("day01") = "9999"

            dailyTable.Rows(0).Delete()
            dailyTable.Rows.Add(row2)


            dataAdpater.Update(dailyTable)

            'dataAdpater.Update(dailyTable.Select(Nothing, Nothing, DataViewRowState.Deleted))
            'dataAdpater.Update(dailyTable.Select(Nothing, Nothing, DataViewRowState.Added))
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
            'MsgBox("Error : " & ex.Message)
        Finally
            'conn.Close()
        End Try
    End Sub

    Public Sub DeleteRecord()
        'TODO Replace this with a call to delete the record from the datatable and the datasorce
    End Sub

    ''' <summary>
    ''' Clears all the text In the ucrValueFlagPeriod controls 
    ''' </summary>
    Public Overrides Sub Clear()
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                DirectCast(ctr, ucrValueFlagPeriod).Clear()
            ElseIf TypeOf ctr Is ucrTextBox Then
                DirectCast(ctr, ucrTextBox).Clear()
            End If
        Next
    End Sub

    Public Sub SetSameValueToAllObsElements(bNewValue As String)
        Dim ucrVFP As ucrValueFlagPeriod
        'Adds values to only enabled controls of the ucrHourly
        For Each ctr As Control In Me.Controls
            If TypeOf ctr Is ucrValueFlagPeriod Then
                If ctr.Enabled Then
                    ucrVFP = DirectCast(ctr, ucrValueFlagPeriod)
                    ucrVFP.SetElementValue(bNewValue)
                    If Not ucrVFP.ValidateValue() Then
                        Exit Sub
                    End If
                End If
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
    Public Function ValidateValue() As Boolean
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

    Public Function checkTotal() As Boolean
        Dim bValueCorrect As Boolean = False
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

    ''' <summary>
    ''' Sets upper and lower limits validation curent element
    ''' </summary>
    Public Sub SetValueValidation()
        Dim ucrVFP As ucrValueFlagPeriod
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        Dim strLowerLimit As String = ""
        Dim strUpperLimit As String = ""
        bTotalRequired = False

        clsDataDefinition = New DataCall
        clsDataDefinition.SetTableNameAndFields("obselement", New List(Of String)({"lowerLimit", "upperLimit", "qcTotalRequired"}))
        clsDataDefinition.SetFilter("elementId", "=", Val(ucrLinkedElement.GetValue), bIsPositiveCondition:=True, bForceValuesAsString:=False)
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

    ''' <summary>
    ''' Sets the key controls
    ''' </summary>
    ''' <param name="ucrNewStation"></param>
    ''' <param name="ucrNewElement"></param>
    ''' <param name="ucrNewYear"></param>
    ''' <param name="ucrNewMonth"></param>
    ''' <param name="ucrNewHour"></param>
    ''' <param name="ucrNewNavigation"></param> 
    ''' 
    Public Sub SetKeyControls(ucrNewStation As ucrStationSelector, ucrNewElement As ucrElementSelector, ucrNewYear As ucrYearSelector, ucrNewMonth As ucrMonth, ucrNewHour As ucrHour, ucrNewNavigation As ucrNavigation)
        ucrLinkedStation = ucrNewStation
        ucrLinkedElement = ucrNewElement
        ucrLinkedYear = ucrNewYear
        ucrLinkedMonth = ucrNewMonth
        ucrLinkedHour = ucrNewHour
        ucrLinkedNavigation = ucrNewNavigation

        ucrLinkedHour.setDefaultValue(6)

        AddLinkedControlFilters(ucrLinkedStation, ucrLinkedStation.FieldName, "=", strLinkedFieldName:="stationId", bForceValuesAsString:=True)
        AddLinkedControlFilters(ucrLinkedElement, ucrLinkedStation.FieldName, "=", strLinkedFieldName:="elementId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedYear, ucrLinkedStation.FieldName, "=", strLinkedFieldName:="Year", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedMonth, ucrLinkedStation.FieldName, "=", strLinkedFieldName:="MonthId", bForceValuesAsString:=False)
        AddLinkedControlFilters(ucrLinkedHour, ucrLinkedStation.FieldName, "=", strLinkedFieldName:="24Hrs", bForceValuesAsString:=False)

        'Sets key controls for the navigation
        ucrLinkedNavigation.SetTableEntry(Me)
        ucrLinkedNavigation.AddKeyControls(ucrLinkedStation)
        ucrLinkedNavigation.AddKeyControls(ucrLinkedElement)
        ucrLinkedNavigation.AddKeyControls(ucrLinkedYear)
        ucrLinkedNavigation.AddKeyControls(ucrLinkedMonth)
        ucrLinkedNavigation.AddKeyControls(ucrLinkedHour)
        ucrLinkedNavigation.SetSortBy("entryDatetime")

    End Sub

    Private Sub ValidateDataEntryPermission()
        Dim iMonthLength As Integer
        Dim todaysDate As Date
        Dim ctr As Control

        If ucrLinkedYear Is Nothing OrElse ucrLinkedMonth Is Nothing Then
            Me.Enabled = False
        ElseIf ucrLinkedYear.ValidateValue AndAlso ucrLinkedMonth.ValidateValue Then
            todaysDate = Date.Now
            iMonthLength = Date.DaysInMonth(ucrLinkedYear.GetValue, ucrLinkedMonth.GetValue())

            If ucrLinkedYear.GetValue > todaysDate.Year OrElse (ucrLinkedYear.GetValue = todaysDate.Year AndAlso ucrLinkedMonth.GetValue > todaysDate.Month) Then
                Me.Enabled = False
            Else
                Me.Enabled = True
                If ucrLinkedYear.GetValue = todaysDate.Year AndAlso ucrLinkedMonth.GetValue = todaysDate.Month Then
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag) >= todaysDate.Day, False, True)
                        End If
                    Next
                Else
                    For Each ctr In Me.Controls
                        If TypeOf ctr Is ucrValueFlagPeriod Then
                            ctr.Enabled = If(Val(ctr.Tag > iMonthLength), False, True)
                        End If
                    Next
                End If

            End If
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
        'frm.SetPretextProgress("Uploading")
        frm.ShowNumbers(True)
        AddHandler frm.backgroundWorker.DoWork, AddressOf DoUpload

        'TODO. temporary. Pass the connection string . The current connection properties are being stored in control
        'Once this is fixed, the argument can be removed
        frm.backgroundWorker.RunWorkerAsync(frmLogin.txtusrpwd.Text)

        frm.Show()
    End Sub

    Private Sub DoUpload(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        Dim backgroundWorker As System.ComponentModel.BackgroundWorker = DirectCast(sender, System.ComponentModel.BackgroundWorker)

        'Dim clsAllRecordsCall As New DataCall
        Dim dtbAllRecords As New DataTable
        Dim strCurrTag As String
        Dim dtObsDateTime As Date
        Dim strStationId As String
        Dim lElementId As Long
        Dim iPeriod As Integer
        Dim lstAllFields As New List(Of String)
        Dim bUpdateRecord As Boolean
        Dim strSql As String
        Dim strSignature As String
        Dim strTempUnits As String
        Dim strPrecipUnits As String
        Dim strCloudHeightUnits As String
        Dim strVisUnits As String
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim pos As Integer = 0
        Dim invalidRecord As Boolean = False
        Dim strResult As String = ""

        'get the observation values fields
        'lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        'lstAllFields.AddRange({"signature"})

        'clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        'dtbAllRecords = clsAllRecordsCall.GetDataTable()

        Try

            'Temporary.The current connection properties are being stored in control, this line can be removed in future
            conn.ConnectionString = e.Argument
            conn.Open()
            'Get all the records from the table
            Using cmdSelect As New MySql.Data.MySqlClient.MySqlCommand("Select * FROM " & strTableName & " ORDER BY entryDatetime", conn)
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

                    If Not IsDBNull(row.Item("day" & strCurrTag)) AndAlso Not String.IsNullOrEmpty(row.Item("day" & strCurrTag)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                        strStationId = row.Item("stationId")

                        Try
                            dtObsDateTime = New Date(year:=row.Item("yyyy"), month:=row.Item("mm"), day:=i, hour:=row.Item("hh"), minute:=0, second:=0)

                        Catch ex As Exception
                            Dim k = True
                            Continue For
                        End Try


                        Try
                            dtObsDateTime = New Date(year:=row.Item("yyyy"), month:=row.Item("mm"), day:=i, hour:=row.Item("hh"), minute:=0, second:=0)
                        Catch ex As Exception
                            'MsgBox("Invalid date detected. Record number " & pos & " has invalid record. This row will be skipped")
                            invalidRecord = True
                            strResult = strResult & "Invalid date detected. Record number " & pos & " has invalid record" &
                                " Station: " & strStationId & ", Element: " & lElementId &
                                ", Year: " & row.Item("yyyy") & ", Month: " & row.Item("mm") & ", Hour: " & row.Item("hh") &
                                ". This row was skipped" & Environment.NewLine
                            Exit For
                        End Try

                        bUpdateRecord = False
                        'check if record exists
                        strSql = "SELECT * FROM observationInitial WHERE recordedFrom=@stationId AND describedBy=@elemCode AND obsDatetime=@obsDatetime AND qcStatus=@qcStatus AND acquisitionType=@acquisitiontype AND dataForm=@dataForm"
                        Using cmd As New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
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

                        Integer.TryParse(row.Item("period" & strCurrTag), iPeriod)

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
                            Using cmdSave As New MySql.Data.MySqlClient.MySqlCommand(strSql, conn)
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
                                cmdSave.Parameters.AddWithValue("@dataForm", strTableName)
                                cmdSave.Parameters.AddWithValue("@temperatureUnits", strTempUnits)
                                cmdSave.Parameters.AddWithValue("@precipUnits", strPrecipUnits)
                                cmdSave.Parameters.AddWithValue("@cloudHeightUnits", strCloudHeightUnits)
                                cmdSave.Parameters.AddWithValue("@visUnits", strVisUnits)
                                'cmd.ExecuteScalar().ToString()
                                cmdSave.ExecuteNonQuery()
                            End Using
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
                pos = pos + 1
                backgroundWorker.ReportProgress(pos)

            Next

            If Not invalidRecord Then
                e.Result = "Records have been uploaded sucessfully"
            Else
                e.Result = strResult
            End If

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
        Dim strCurrTag As String
        Dim dtObsDateTime As Date
        Dim strStationId As String
        Dim lElementId As Long
        Dim iPeriod As Integer
        Dim lstAllFields As New List(Of String)
        Dim bNewRecord As Boolean

        'get the observation values fields
        lstAllFields.AddRange(lstFields)
        'TODO "entryDatetime" should be here as well once entity model has been updated.
        lstAllFields.AddRange({"signature"})

        clsAllRecordsCall.SetTableNameAndFields(strTableName, lstAllFields)
        dtbAllRecords = clsAllRecordsCall.GetDataTable()

        For Each row As DataRow In dtbAllRecords.Rows
            For i As Integer = 1 To 31
                If i < 10 Then
                    strCurrTag = "0" & i
                Else
                    strCurrTag = i
                End If

                If Not IsDBNull(row.Item("day" & strCurrTag)) AndAlso Not String.IsNullOrEmpty(row.Item("day" & strCurrTag)) AndAlso Long.TryParse(row.Item("elementId"), lElementId) Then

                    strStationId = row.Item("stationId")
                    dtObsDateTime = New Date(year:=row.Item("yyyy"), month:=row.Item("mm"), day:=i, hour:=row.Item("hh"), minute:=0, second:=0)

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
                    rcdObservationInitial.qcStatus = 0
                    rcdObservationInitial.acquisitionType = 1
                    rcdObservationInitial.dataForm = strTableName

                    rcdObservationInitial.obsValue = row.Item("day" & strCurrTag)
                    rcdObservationInitial.flag = row.Item("flag" & strCurrTag)
                    If Integer.TryParse(row.Item("period" & strCurrTag), iPeriod) Then
                        rcdObservationInitial.period = iPeriod
                    End If

                    If Not IsDBNull(row.Item("signature")) Then
                        rcdObservationInitial.capturedBy = row.Item("signature")
                    End If
                    If Not IsDBNull(row.Item("temperatureUnits")) Then
                        rcdObservationInitial.temperatureUnits = row.Item("temperatureUnits")
                    End If
                    If Not IsDBNull(row.Item("precipUnits")) Then
                        rcdObservationInitial.precipitationUnits = row.Item("precipUnits")
                    End If
                    If Not IsDBNull(row.Item("cloudHeightUnits")) Then
                        rcdObservationInitial.cloudHeightUnits = row.Item("cloudHeightUnits")
                    End If
                    If Not IsDBNull(row.Item("visUnits")) Then
                        rcdObservationInitial.visUnits = row.Item("visUnits")
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
        Return New ClsShiftCells(allVFP).GetVFPContextMenu()
    End Function


End Class