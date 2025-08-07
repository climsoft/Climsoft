' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class formDaily1

    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim da, daSequencer, daValueLimits As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds, dsSequencer, dsValueLimits As New DataSet
    Dim sql, obsValue, elemCode, sqlValueLimits, valUpperLimit, valLowerLimit As String
    Dim FldName As New dataEntryGlobalRoutines
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
    Dim inc, maxrows, valueFldsTotal As Integer
    Dim objKeyPress As New dataEntryGlobalRoutines

    Private Sub formDaily1_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Create and load Values and Flags text boxes
        If Not load_Controls() Then
            Me.Close()
            Exit Sub
        End If

        ' Populate the Year Combobox with the last 5 years from the current
        For i = 0 To 5
            cboYear.Items.Add(DateAndTime.Year(Now()) - i)
        Next

        'Populate the form with data from the first record if there is any
        tabNext = True

        'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            btnDelete.Enabled = False
            btnUpload.Enabled = False
        End If

        ' Retrieve Keyentry mode information and mark on the checkbox
        If FldName.Key_Entry_Mode(Me.Text) = "Double" Then chkRepeatEntry.Checked = True

        'Set the record index counter to the first row
        inc = 0
        myConnectionString = frmLogin.txtusrpwd.Text

        Try
            conn.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
            conn.Open()

            sql = "SELECT * FROM form_daily1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "form_daily1")

            maxrows = ds.Tables("form_daily1").Rows.Count

            '--------------------------------
            'Fill ComboBox for station identifier with station list from station table
            Dim m As Integer
            Dim ctl As Control
            Dim ds1 As New DataSet
            Dim sql1 As String
            Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter

            sql1 = "SELECT stationId,stationName FROM station"
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, conn)

            da1.Fill(ds1, "station")
            If ds1.Tables("station").Rows.Count > 0 Then
                With cboStation
                    .DataSource = ds1.Tables("station")
                    .DisplayMember = "stationName"
                    .ValueMember = "stationId"
                    .SelectedIndex = 0
                End With
            Else
                MsgBox(msgStationInformationNotFound, MsgBoxStyle.Exclamation)
            End If

            'Initialize header information for data-entry form

            If maxrows > 0 Then
                cboStation.SelectedValue = ds.Tables("form_daily1").Rows(inc).Item("stationId")
                cboYear.Text = ds.Tables("form_daily1").Rows(inc).Item("yyyy")
                cboMonth.Text = ds.Tables("form_daily1").Rows(inc).Item("mm")
                cboDay.Text = ds.Tables("form_daily1").Rows(inc).Item("dd")
                cboHour.Text = ds.Tables("form_daily1").Rows(inc).Item("hh")

                'Initialize textboxes for observation values
                ' But not for Repeat Entry mode
                If chkRepeatEntry.Checked Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnClear.Enabled = False
                    btnMoveFirst.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMovePrevious.Enabled = False
                    btnMoveLast.Enabled = False
                    Exit Sub
                End If

                'Observation values range from column 6 i.e. column index 5 to max field columns
                For m = 5 To (valueFldsTotal + 4)
                    For Each ctl In Me.Controls

                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_daily1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_daily1").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                'Initialize textboxes for observation flags
                'Observation flags range from column 39 i.e. column index 38 to field max field column
                For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            If Not IsDBNull(ds.Tables("form_daily1").Rows(inc).Item(m)) Then
                                ctl.Text = ds.Tables("form_daily1").Rows(inc).Item(m)
                            End If
                        End If
                    Next ctl
                Next m

                displayRecordNumber()
            Else
                'If this is the first record
                btnAddNew.Enabled = False
                btnCommit.Enabled = True
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
                btnClear.Enabled = True
                btnMoveFirst.Enabled = False
                btnMoveNext.Enabled = False
                btnMovePrevious.Enabled = False
                btnMoveLast.Enabled = False

                recNumberTextBox.Text = "Record 1 of 1"
            End If

            '' Retrieve Keyentry mode information and mark on the checkbox
            ''MsgBox(FldName.Key_Entry_Mode(Me.Name))
            'If FldName.Key_Entry_Mode(Me.Text) = "Double" Then chkRepeatEntry.Checked = True

        Catch ex As Exception
            If ex.HResult = "-2146233086" Then
                MsgBox("No Element Selected!   >>> Select them from Metadata form")
            Else
                MessageBox.Show(ex.Message)
            End If
        End Try

        ' Poplate the Hour text box with the value from registry
        Try

            Dim dsrg As New DataSet
            Dim sqlg As String
            Dim darg As MySql.Data.MySqlClient.MySqlDataAdapter

            sqlg = "Select keyvalue from regkeys where keyname = 'key01';"
            darg = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlg, conn)
            dsrg.Clear()
            darg.Fill(dsrg, "Keys")

            If dsrg.Tables("Keys").Rows.Count > 0 Then
                cboHour.Text = dsrg.Tables("Keys").Rows(0).Item(0)
            End If

            Me.CenterToScreen()
            conn.Close()
        Catch ex As Exception
            conn.Close()
            MessageBox.Show(ex.Message)

        End Try


        ClsTranslations.TranslateForm(Me)

    End Sub

    Function load_Controls() As Boolean

        Dim eName As String
        Dim eCode, txtX, flgX, lblX, posY1, edx, fldsValue, colmn, fldNo As Integer
        Dim txtvalue As TextBox = Nothing
        Dim txtflag As TextBox = Nothing
        Dim lblvalue, lblVheader, lblFheader As Label

        myConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
        conn.Open()

        Try
            sql = "SELECT * FROM form_daily1"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "form_daily1")

            edx = 0
            fldsValue = 0
            colmn = 0
            fldNo = 5
            With ds.Tables("form_daily1")

                ' Get the total value fields

                For i = 0 To .Columns.Count - 1
                    If InStr(.Columns(i).ColumnName, "Val_Elem") <> 0 Then valueFldsTotal = valueFldsTotal + 1
                Next

                For i = 0 To .Columns.Count - 1
                    'posY1 = 127
                    posY1 = 137
                    eName = Strings.Left(.Columns(i).ColumnName, 8)
                    If eName = "Val_Elem" Then

                        colmn = Int(fldsValue / 16)
                        txtX = 271 + 243 * colmn
                        flgX = 323 + 243 * colmn
                        lblX = 124 + 243 * colmn

                        If fldsValue Mod 16 = 0 Then
                            edx = 0
                            posY1 = 137

                            ' Draw Values Column header
                            lblVheader = New Windows.Forms.Label
                            lblVheader.Name = "lblValue" & colmn
                            lblVheader.Text = "Value"
                            lblVheader.Location = New System.Drawing.Point(277 + 243 * colmn, 119)
                            lblVheader.Size = New System.Drawing.Size(34, 13)
                            Me.Controls.Add(lblVheader)

                            ' Draw Flags Column header
                            lblFheader = New Windows.Forms.Label
                            lblFheader.Name = "lblFlag" & colmn
                            lblFheader.Text = "Flag"
                            lblFheader.Location = New System.Drawing.Point(322 + 243 * colmn, 119)
                            lblFheader.Size = New System.Drawing.Size(27, 13)
                            Me.Controls.Add(lblFheader)
                        End If
                        fldsValue = fldsValue + 1
                        '.Text.PadLeft(3, "0"c)
                        eCode = Strings.Right(.Columns(i).ColumnName, 3)
                        posY1 = posY1 + edx * 25

                        ' Draw Value text box
                        txtvalue = New Windows.Forms.TextBox
                        txtvalue.Name = "txtVal_Elem" & eCode.ToString.PadLeft(3, "0"c) & "Field" & fldNo.ToString.PadLeft(3, "0"c)
                        txtvalue.Location = New System.Drawing.Point(txtX, posY1)
                        txtvalue.Size = New System.Drawing.Size(48, 20)
                        txtvalue.TabIndex = i '+ 5
                        Me.Controls.Add(txtvalue)

                        'Draw Flag text box
                        txtflag = New Windows.Forms.TextBox
                        txtflag.Name = "txtFlag" & eCode.ToString.PadLeft(3, "0"c) & "Field" & (fldNo + valueFldsTotal).ToString.PadLeft(3, "0"c)
                        txtflag.Location = New System.Drawing.Point(flgX, posY1)
                        txtflag.Size = New System.Drawing.Size(23, 20)
                        txtflag.TabIndex = i + .Columns.Count
                        txtflag.Enabled = False
                        Me.Controls.Add(txtflag)

                        ' Draw text box Label
                        lblvalue = New Windows.Forms.Label
                        lblvalue.Name = "lbl" & eCode
                        lblvalue.Text = ElementName(eCode)
                        lblvalue.Location = New System.Drawing.Point(lblX, posY1)
                        lblvalue.Size = New System.Drawing.Size(141, 13)
                        lblvalue.TabIndex = i + .Columns.Count * 2 '(i + 5) + .Columns.Count * 2
                        Me.Controls.Add(lblvalue)
                        edx = edx + 1
                        fldNo = fldNo + 1
                    End If
                Next
            End With
            'compute Form height
            If fldsValue > 16 Then
                Me.Height = 300 + 16 * 25 'Maximum height attained
            Else
                Me.Height = 300 + fldsValue * 25
            End If

            'compute Form width
            If colmn > 1 Then
                Me.Width = 740 + 243 * (colmn - 1)
            Else
                Me.Width = 740        ' Minimum width at 2 columns only
            End If
            conn.Close()
            Return True
        Catch ex As Exception
            'MsgBox(ex.HResult & " " & ex.Message)
            If ex.HResult = -2147467259 Then
                MsgBox("Table for the selected form does not exist. Climsoft Administrator should first create the table through the menu 'Administration' => 'Create/Modify Key Entry Form'.")
            Else
                MsgBox(ex.Message)
            End If
            conn.Close()
            Return False
        End Try

    End Function



    Function ElementName(code As Integer) As String
        ElementName = ""

        sql = "SELECT * FROM obselement"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "element")

        With ds.Tables("element")

            For i = 0 To .Rows.Count - 1
                If .Rows(i).Item(0) = code Then
                    Return .Rows(i).Item("elementName")
                End If
            Next
        End With
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        conn.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
        conn.Open()

        sql = "SELECT * FROM form_daily1;"
        'where stationId ='" & cboStation.SelectedValue & "' and yyyy = " & txtYear.Text & " and mm = " & cboMonth.Text & " and dd = " & cboDay.Text & ";"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "form_daily1")


        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines

        Try
            'Update header fields for form in database
            ds.Tables("form_daily1").Rows(inc).Item("stationId") = cboStation.SelectedValue
            ds.Tables("form_daily1").Rows(inc).Item("yyyy") = cboYear.Text
            ds.Tables("form_daily1").Rows(inc).Item("mm") = cboMonth.Text
            ds.Tables("form_daily1").Rows(inc).Item("dd") = cboDay.Text

            'Update observation values in database
            'Observation values range from column 6 i.e. column index 5 to column 54 i.e. column index 53
            For m = 5 To (valueFldsTotal + 4) 'm = 5 To 53
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_daily1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'Update observation flags in database
            'Observation values range from column 55 i.e. column index 54 to column 103 i.e. column index 102
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4 'm = 54 To 102
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ds.Tables("form_daily1").Rows(inc).Item(m) = ctl.Text
                    End If
                Next ctl
            Next m

            'The data adapter is used to update the record in the data source table
            da.Update(ds, "form_daily1")

            'Show message for successful updating or record.
            recUpdate.messageBoxRecordedUpdated()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        Try
            If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

                'Display message to show that delete operation has been cancelled
                recDelete.messageBoxOperationCancelled()
                Exit Sub
            End If

            'MsgBox(inc)

            ds.Tables("form_daily1").Rows(inc).Delete()
            da.Update(ds, "form_daily1")
            MsgBox("Record Successfully Deleted!")
            maxrows = maxrows - 1

            If ds.Tables("form_daily1").Rows.Count > 0 Then
                inc = inc - 1
                If inc < 0 Then inc = 0
            Else
                formPopulate()
                Exit Sub
            End If

            'Call subroutine for records navigation
            navigateRecords()

        Catch ex As Exception
            MsgBox("Deleted Record Failed!. Close and reopen the form. Then browse for the desired record. Repeat the Delete action")
        End Try

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearTboxes()

        'Dim n As Integer, ctl As Control
        'n = 0
        'For Each ctl In Me.Controls
        '    'Check if some observation values have been entered
        '    'If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
        '    If Strings.Left(ctl.Name, 6) = "txtVal" Then n = 1
        'Next ctl

        ''Check if header information is complete. If the header information is complete and there is at least on obs value then,
        ''carry out the next actions, otherwise bring up message showing that there is insufficient data
        'If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(cboYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

        '    'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
        '    'to undo the AddNew button process before the record can be committed to the datasource table linked to the DataSet.
        '    'So all the buttons that were disabled after the AddNew button was clicked should be enabled back again and the Commit button
        '    'disabled until the AddNew button is clicked

        '    btnAddNew.Enabled = True
        '    btnCommit.Enabled = False
        '    btnDelete.Enabled = True
        '    btnUpdate.Enabled = True
        '    btnMoveFirst.Enabled = True
        '    btnMoveLast.Enabled = True
        '    btnMoveNext.Enabled = True
        '    btnMovePrevious.Enabled = True

        '    'Set Record position index to first record
        '    inc = 0

        '    'Call subroutine for record navigation
        '    navigateRecords()
        'Else
        '    MsgBox("Incomplete header information and insufficient observation data!", MsgBoxStyle.Exclamation)
        'End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        userName = frmLogin.txtUsername.Text
        dsSourceTableName = "form_daily1"
        If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
            sql = "SELECT * FROM form_daily1 where signature ='" & userName & "' ORDER by stationId,yyyy,mm,dd;"
        Else
            sql = "SELECT * FROM form_daily1 ORDER by stationId,yyyy,mm,dd"
        End If
        viewRecords.viewTableRecords(sql)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "keyentryoperations.htm#form_daily1")
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        'Open form for displaying data transfer progress

        frmFormUpload.lblFormName1.Text = "form_daily1"
        frmFormUpload.Show()
        frmFormUpload.Text = frmFormUpload.Text & " for " & frmFormUpload.lblFormName1.Text

        Exit Sub

        frmDataTransferProgress.Show()
        'Upload data to observationInitial table
        Dim strSQL As String, m As Integer, n As Integer, maxRows As Integer, yyyy As String, mm As String,
            dd As String, hh As String, ctl As Control, capturedBy As String
        Dim stnId As String, elemCode As Integer, obsDatetime As String, obsVal As String, obsFlag As String,
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, dataForm As String

        Try
            myConnectionString = frmLogin.txtusrpwd.Text

            conn.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
            conn.Open()
            '
            maxRows = ds.Tables("form_daily1").Rows.Count
            qcStatus = 0
            acquisitionType = 1
            obsLevel = "surface"
            obsVal = ""
            obsFlag = ""
            dataForm = "form_daily1"

            'Loop through all records in dataset
            For n = 0 To maxRows - 1
                'Display progress of data transfer
                frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
                frmDataTransferProgress.txtDataTransferProgress1.Refresh()
                'Loop through all observation fields adding observation records to observationInitial table

                For m = 5 To (valueFldsTotal + 4)

                    stnId = ds.Tables("form_daily1").Rows(n).Item(0)
                    yyyy = ds.Tables("form_daily1").Rows(n).Item(1)
                    mm = ds.Tables("form_daily1").Rows(n).Item(2)
                    dd = ds.Tables("form_daily1").Rows(n).Item(3)
                    hh = ds.Tables("form_daily1").Rows(n).Item(4)

                    If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item("signature")) Then capturedBy = ds.Tables("form_daily1").Rows(n).Item("signature")

                    If Val(mm) < 10 Then mm = "0" & mm
                    If Val(dd) < 10 Then dd = "0" & dd
                    If Val(hh) < 10 Then hh = "0" & hh

                    obsDatetime = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"

                    If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item(m)) Then obsVal = ds.Tables("form_daily1").Rows(n).Item(m)
                    If Not IsDBNull(ds.Tables("form_daily1").Rows(n).Item(m + 34)) Then obsFlag = ds.Tables("form_daily1").Rows(n).Item(m + 34)
                    'Get the element code from the control name corresponding to column index
                    For Each ctl In Me.Controls
                        If Val(Strings.Right(ctl.Name, 3)) = m Then
                            elemCode = Val(Strings.Mid(ctl.Name, 12, 3))
                        End If
                    Next ctl

                    'Generate SQL string for inserting data into observationinitial table
                    If Strings.Len(obsVal) > 0 Then
                        strSQL = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,capturedBy,dataForm) " &
                            "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDatetime & "','" & obsLevel & "','" & obsVal & "','" & obsFlag & "'," _
                            & qcStatus & "," & acquisitionType & ",'" & capturedBy & "','" & dataForm & "')"

                        ' Create the Command for executing query and set its properties
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

                        Try
                            'Execute query
                            objCmd.ExecuteNonQuery()
                            'Catch ex As MySql.Data.MySqlClient.MySqlException
                            '    'Ignore expected error i.e. error of Duplicates in MySqlException
                        Catch ex As Exception
                            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                            MsgBox(ex.Message)
                        End Try
                    End If
                    'Move to next observation value in current record of the dataset

                Next m
                'Move to next record in dataset
            Next n
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
    End Sub

    Private Sub btnPush_Click(sender As Object, e As EventArgs) Handles btnPush.Click
        Me.Cursor = Cursors.WaitCursor
        If FldName.DataPush("form_daily1") Then
            MsgBox("Data Pushed to remote server successfully")
        Else
            MsgBox("Data Push Failed!")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtYear_TextChanged(sender As Object, e As EventArgs)
        'formPopulate()
    End Sub

    Private Sub formDaily1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Enter Then My.Computer.Keyboard.SendKeys("{TAB}")

        Dim objKeyPress As New dataEntryGlobalRoutines
        Dim obsVal, obsFlag, flagtextBoxSuffix As String
        Dim flagIndexDiff As Integer

        'Initialize string variables
        obsVal = ""
        obsFlag = ""
        flagtextBoxSuffix = ""
        flagIndexDiff = valueFldsTotal

        'MsgBox(e.KeyCode)
        Try
            'If {ENTER} key is pressed
            If e.KeyCode = Keys.Enter Then

                'Check for conflicts if Double key entry mode is set

                If chkRepeatEntry.Checked And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    chkRepeatEntry.Checked = True

                    Dim elmcode As String
                    elmcode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    If Not objKeyPress.Entry_Verification(conn, Me, cboStation.SelectedValue, elmcode, cboYear.Text, cboMonth.Text, cboDay.Text, "06") Then
                        MsgBox("Can't derify data")
                    End If
                End If

                If Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" And Strings.Len(Me.ActiveControl.Text) > 0 Then

                    ' If a flag exists then separate the flag from the value and place the flag in the corresponding flag field.
                    If Not IsNumeric(Strings.Right(Me.ActiveControl.Text, 1)) Then
                        'Get observation flag from the texbox and convert it to Uppercase. Flag is a single letter added as the last character
                        'to the value string in the textbox.
                        obsFlag = Strings.Right(Me.ActiveControl.Text, 1).ToUpper
                        'Get the observation value by leaving out the last character from the string entered in the textbox
                        obsVal = Strings.Left(Me.ActiveControl.Text, Strings.Len(Me.ActiveControl.Text) - 1)

                        Me.ActiveControl.Text = obsVal

                    End If
                    'Now assign obsFlag to correct texbox on the form
                    For Each ctrl In Me.Controls
                        'Loop through all controls on form
                        'Locate the textbox for the flag field by calling the Function "getFlagTexboxSuffix"
                        If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                            ctrl.Text = obsFlag
                        End If
                    Next ctrl

                    'Check that numeric value has been entered for observation value
                    objKeyPress.checkIsNumeric(Me.ActiveControl.Text, Me.ActiveControl)

                    'Get the element limits for QC checking

                    ' This code was included on 21/09/2022 to cater for the local (station's) limits where they exist. Otherwise the global limits will be used
                    obsValue = Me.ActiveControl.Text
                    elemCode = Strings.Mid(Me.ActiveControl.Name, 12, 3)
                    'MsgBox(obsValue & " " & cboStation.SelectedValue & " " & elemCode)
                    objKeyPress.GetQCLimits(cboStation.SelectedValue, elemCode, valUpperLimit, valLowerLimit)
                    'MsgBox(cboStation.SelectedValue & " " & elemCode & " " & valUpperLimit & " " & valLowerLimit)

                    If objKeyPress.GetQCLimits(cboStation.SelectedValue, elemCode, valUpperLimit, valLowerLimit) Then
                        'Check lower limit
                        If obsValue <> "" And valLowerLimit <> "" And tabNext = True Then
                            objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit)
                        End If
                        'Check upper limit
                        If obsValue <> "" And valUpperLimit <> "" And tabNext = True Then
                            objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit)
                        End If

                    End If

                    'sqlValueLimits = "Select elementId, upperLimit, lowerLimit FROM obselement WHERE elementId=" & elemCode
                    ''MsgBox(cboStation.SelectedValue & " " & elemCode)

                    'daValueLimits = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlValueLimits, conn)
                    ''Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                    'dsValueLimits.Clear()
                    ''Add row for element code associated with active control
                    'daValueLimits.Fill(dsValueLimits, "obselement")

                    'obsValue = Me.ActiveControl.Text
                    'If dsValueLimits.Tables("obselement").Rows.Count > 0 Then ' Limits record available
                    '    'Get element lower limit

                    '    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                    '        valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
                    '    Else
                    '        valLowerLimit = ""
                    '    End If
                    '    'Get element upper limit
                    '    If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                    '        valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
                    '    Else
                    '        valUpperLimit = ""
                    '    End If

                    '    'Check lower limit
                    '    If obsValue <> "" And valLowerLimit <> "" And tabNext = True Then
                    '        objKeyPress.checkLowerLimit(Me.ActiveControl, obsValue, valLowerLimit)
                    '    End If
                    '    'Check upper limit
                    '    If obsValue <> "" And valUpperLimit <> "" And tabNext = True Then
                    '        objKeyPress.checkUpperLimit(Me.ActiveControl, obsValue, valUpperLimit)
                    '    End If
                    'End If

                ElseIf Me.ActiveControl.Name = "cboYear" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboYear.Text, cboYear)
                    'Check valid year
                    If tabNext = True Then
                        objKeyPress.checkValidYear(cboYear.Text, cboYear)
                    End If
                ElseIf Me.ActiveControl.Name = "cboMonth" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboMonth.Text, cboMonth)
                    'Check valid month
                    objKeyPress.checkValidMonth(cboMonth.Text, cboMonth)
                ElseIf Me.ActiveControl.Name = "cboDay" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboDay.Text, cboDay)
                    'Check valid day
                    If tabNext = True Then
                        objKeyPress.checkValidDay(cboDay.Text, cboDay)
                    End If
                    If tabNext = True Then
                        objKeyPress.checkValidDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay)
                    End If
                    If tabNext = True Then
                        objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay)
                    End If
                ElseIf Me.ActiveControl.Name = "cboHour" Then
                    'Check for numeric
                    objKeyPress.checkIsNumeric(cboHour.Text, cboHour)
                    'Check valid Hour
                    If tabNext = True Then
                        objKeyPress.checkValidHour(cboHour.Text, cboHour)
                    End If
                ElseIf Me.ActiveControl.Name = "cboStation" Then
                    Dim itemFound As Boolean
                    If Len(cboStation.SelectedValue) > 1 Then
                        itemFound = True
                    Else
                        itemFound = False
                        If FldName.Valid_Stn(cboStation) Then itemFound = True
                    End If
                    objKeyPress.checkExists(itemFound, cboStation)
                Else

                    ' Generate flag M for missing data for blank values
                    For Each ctrl In Me.Controls
                        If Strings.Right(ctrl.Name, 3) = objKeyPress.getFlagTexboxSuffix(Me.ActiveControl.Text, Me.ActiveControl, flagIndexDiff) Then
                            ctrl.Text = "M" 'obsFlag
                            Exit For
                        End If
                    Next ctrl
                End If

                ' Compute the next text box to get focus or set focus to the Save button if the last text box is the active control 
                If tabNext = True Then
                    If Me.ActiveControl.TabIndex = valueFldsTotal + 4 Then
                        btnCommit.Focus()
                    Else
                        My.Computer.Keyboard.SendKeys("{TAB}")
                    End If
                End If

            ElseIf (e.KeyCode = 33 Or e.KeyCode = 34) And Strings.Left(Me.ActiveControl.Name, 6) = "txtVal" Then
                'shiftEntries(e.KeyCode)
                FldName.shiftEntries(e.KeyCode, Me, "form_daily1")
                'MsgBox(Me.ActiveControl.Name)
            End If

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    'Private Sub cboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged
    '    formPopulate()
    'End Sub

    'Private Sub cboStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedIndexChanged
    '    formPopulate()
    'End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        Dim dataFormRecCount As Integer
        Dim strStation, strYear, strMonth, strDay, Sql As String

        strStation = cboStation.SelectedValue
        Try
            dataFormRecCount = ds.Tables("form_daily1").Rows.Count
            'MsgBox(dataFormRecCount & " " & inc)
            'MsgBox(ds.Tables("form_daily1").Rows(dataFormRecCount - 1).Item("stationId"))
            If dataFormRecCount > 0 Then
                cboStation.SelectedValue = ds.Tables("form_daily1").Rows(dataFormRecCount - 1).Item("stationId")
                strYear = ds.Tables("form_daily1").Rows(dataFormRecCount - 1).Item("yyyy")
                strMonth = ds.Tables("form_daily1").Rows(dataFormRecCount - 1).Item("mm")
                strDay = ds.Tables("form_daily1").Rows(dataFormRecCount - 1).Item("dd")

            Else
                cboStation.SelectedValue = cboStation.SelectedValue
                strYear = cboYear.Text
                strMonth = cboMonth.Text
                strDay = cboDay.Text
            End If

            Dim ctl As Control

            'Clear textboxes for observation values
            'Observation values range from column 5 i.e. column index 4 to column 38 i.e. column index 37
            For m = 5 To (valueFldsTotal + 4)
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Clear textboxes for observation values
            'Observation flags range from column 39 i.e. column index 38 to column 73 i.e. column index 72
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            ' Don't use Sequencer to fill the form header text boxes if in Double Key Entry i.e. Repeat Entry Mode
            If chkRepeatEntry.Checked Then
                Dim recdate As Date
                ' Enable AddNew button and Diable Save button
                btnAddNew.Enabled = True
                btnCommit.Enabled = False
                btnClear.Enabled = False
                ' Compute the new header entries for the next record
                cboStation.SelectedValue = strStation
                recdate = DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text)
                recdate = DateAdd("d", 1, recdate)
                cboYear.Text = DateAndTime.Year(recdate)
                cboMonth.Text = DateAndTime.Month(recdate)
                cboDay.Text = DateAndTime.Day(recdate)
                'txtVal_Elem101Field004.Focus()
                txtbox1Focus()
                Exit Sub
            End If

            Dim dsLastDataRecord As New DataSet
            Dim daLastDataRecord As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim SQL_last_record, lastRecYear, lastRecMonth, lastRecDay, stn As String
            Dim lastRec, nextRec As Date

            SQL_last_record = "Select stationId, yyyy, mm, dd, Signature, entryDatetime from form_daily1 WHERE signature='" & frmLogin.txtUsername.Text & "' AND entryDatetime=(SELECT MAX(entryDatetime) FROM form_daily1);"

            dsLastDataRecord.Clear()
            daLastDataRecord = New MySql.Data.MySqlClient.MySqlDataAdapter(SQL_last_record, conn)
            daLastDataRecord.Fill(dsLastDataRecord, "lastDataRecord")

            'Initialize header fields required for sequencer
            stn = cboStation.SelectedValue
            cboStation.SelectedValue = stn
            lastRecDay = cboDay.Text
            lastRecMonth = cboMonth.Text
            lastRecYear = cboYear.Text

            If dsLastDataRecord.Tables("lastDataRecord").Rows.Count > 0 Then
                stn = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("stationId")
                cboStation.SelectedValue = stn
                lastRecDay = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("dd")
                lastRecMonth = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("mm")
                lastRecYear = dsLastDataRecord.Tables("lastDataRecord").Rows(0).Item("yyyy")
            End If

            ' Sequence the records for next entry by selecting the next day

            lastRec = DateSerial(lastRecYear, lastRecMonth, lastRecDay)
            nextRec = DateAdd("d", 1, lastRec)

            cboYear.Text = DateAndTime.Year(nextRec)
            cboMonth.Text = DateAndTime.Month(nextRec)
            cboDay.Text = DateAndTime.Day(nextRec)



            '' Sequencer code Ends there

            ''Clear textboxes for observation values
            ''Observation values range from column 6 i.e. column index 5 to column 29 i.e. column index 28
            'For m = 5 To (valueFldsTotal + 4)
            '    For Each ctl In Me.Controls
            '        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
            '            ctl.Text = ""
            '        End If
            '    Next ctl
            'Next m

            'Clear textboxes for observation flags
            'Observation flags range from column 30 i.e. column index 29 to column 53 i.e. column index 52
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        ctl.Text = ""
                    End If
                Next ctl
            Next m

            'Set record index to last record
            inc = maxrows

            formPopulate()


            ''Display record position in record navigation Text Box
            'recNumberTextBox.Text = "Record " & maxrows + 1 & " of " & maxrows + 1
            ''txtVal_Elem101Field004.Focus()
            ''formPopulate()
            txtbox1Focus()
            'recNumberTextBox.Text = "New Record"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noPreviousRec As New dataEntryGlobalRoutines

        If inc > 0 Then
            inc = inc - 1
            navigateRecords()
        Else
            'If the record Index is equal to zero an error message must be displayed to show that there is no more previous record.
            'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
            'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noPreviousRec.messageBoxNoPreviousRecord()
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noNextRec As New dataEntryGlobalRoutines
        If inc < (maxrows - 1) Then
            inc = inc + 1
            'Call subroutine for record navigation
            navigateRecords()
        Else
            'If the record Index is equal to maximum number of rows minus one, an error message must be displayed to show that
            'there is no more next record.The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class
            'hence the need to instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noNextRec.messageBoxNoNextRecord()
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxrows - 1

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxrows
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click

        ' Confirm the validaty of the observation date
        If Not IsDate(cboDay.Text & "/" & cboMonth.Text & "/" & cboYear.Text) Or Not objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay) Then
            MsgBox("Confirm observation date")
            cboYear.Focus()
            Exit Sub
        End If

        Dim n As Integer, ctl As Control, msgTxtInsufficientData As String
        n = 0
        Try
            For Each ctl In Me.Controls
                'Check if some observation values have been entered
                If Strings.Left(ctl.Name, 6) = "txtVal" And IsNumeric(ctl.Text) Then n = 1
            Next ctl

            'Check if header information is complete. If the header information is complete and there is at least one obs value then,
            'carry out the next actions, otherwise bring up message showing that there is insufficient data
            If n = 1 And Strings.Len(cboStation.Text) > 0 And Strings.Len(cboYear.Text) > 0 And Strings.Len(cboMonth.Text) And Strings.Len(cboDay.Text) > 0 Then

                '-----------------------------------------
                'Carry out QC checks before saving data
                'Dim objKeyPress As New dataEntryGlobalRoutines

                'Check item exists
                For Each ctl In Me.Controls
                    If ctl.Name = "cboStation" Then
                        If Not objKeyPress.checkExists(True, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check for numeric
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboYear" Or ctl.Name = "cboMonth" Or ctl.Name = "cboDay" Or ctl.Name = "cboHour" _
                        Or (Strings.Left(ctl.Name, 6) = "txtVal" And Strings.Len(ctl.Text)) > 0 Then
                        If Not objKeyPress.checkIsNumeric(obsValue, Me.ActiveControl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid year
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboYear" Then
                        If Not objKeyPress.checkValidYear(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid month
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboMonth" Then
                        If Not objKeyPress.checkValidMonth(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid day
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboDay" Then
                        If Not objKeyPress.checkValidDay(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check valid hour
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If ctl.Name = "cboHour" Then
                        If Not objKeyPress.checkValidHour(obsValue, ctl) Then
                            ctl.Focus()
                        End If
                    End If
                Next ctl

                'Check future date
                If Not objKeyPress.checkFutureDate(cboDay.Text, cboMonth.Text, cboYear.Text, cboDay) Then
                    cboDay.Focus()
                End If

                'Check limits
                'Dim elemCode As Integer
                For Each ctl In Me.Controls
                    obsValue = ctl.Text
                    If Strings.Left(ctl.Name, 6) = "txtVal" Then


                        elemCode = Val(Strings.Mid(ctl.Name, 12, 3))

                        sqlValueLimits = "SELECT elementId,upperLimit,lowerLimit FROM obselement WHERE elementId=" & elemCode

                        daValueLimits = New MySql.Data.MySqlClient.MySqlDataAdapter(sqlValueLimits, conn)
                        'Clear all rows in dataset before filling dataset with new row record for element code associated with active control
                        dsValueLimits.Clear()
                        'Add row for element code associated with active control
                        daValueLimits.Fill(dsValueLimits, "obselement")

                        'Get element upper limit
                        If dsValueLimits.Tables("obselement").Rows.Count < 0 Then
                            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")) Then
                                valUpperLimit = dsValueLimits.Tables("obselement").Rows(0).Item("upperlimit")
                            Else
                                valUpperLimit = ""
                            End If

                            'Get element lower limit
                            If Not IsDBNull(dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")) Then
                                valLowerLimit = dsValueLimits.Tables("obselement").Rows(0).Item("lowerlimit")
                            Else
                                valLowerLimit = ""
                            End If

                            'Check upper limit
                            If ctl.Text <> "" And valUpperLimit <> "" Then
                                If Not objKeyPress.checkUpperLimit(ctl, obsValue, valUpperLimit) Then
                                    ctl.Focus()
                                End If
                            End If

                            'Check lower limit
                            If ctl.Text <> "" And valLowerLimit <> "" Then
                                If Not objKeyPress.checkLowerLimit(ctl, obsValue, valLowerLimit) Then
                                    ctl.Focus()
                                End If
                            End If
                        End If
                    End If
                Next ctl

                '---------------------------------------
                'Confirm if you want to continue and save data from key-entry form to database table
                Dim msgTxtContinue As String
                msgTxtContinue = "Do you want to continue and commit to database table?"
                If MsgBox(msgTxtContinue, MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

                'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
                'must be declared for the Update method to work.
                Dim m As Integer

                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                Dim dsNewRow As DataRow
                'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
                Dim recCommit As New dataEntryGlobalRoutines

                dsNewRow = ds.Tables("form_daily1").NewRow
                'Add a new record to the data source table
                ds.Tables("form_daily1").Rows.Add(dsNewRow)

                maxrows = ds.Tables("form_daily1").Rows.Count
                inc = maxrows - 1

                'Commit observation header information to database
                ds.Tables("form_daily1").Rows(inc).Item("stationId") = cboStation.SelectedValue
                ds.Tables("form_daily1").Rows(inc).Item("yyyy") = cboYear.Text
                ds.Tables("form_daily1").Rows(inc).Item("mm") = cboMonth.Text
                ds.Tables("form_daily1").Rows(inc).Item("dd") = cboDay.Text
                ds.Tables("form_daily1").Rows(inc).Item("hh") = cboHour.Text

                ' txtSignature.Text = frmLogin.txtUser.Text
                ds.Tables("form_daily1").Rows(inc).Item("signature") = frmLogin.txtUsername.Text

                'Added field for timestamp to allow recording when data was entered. 20160419, ASM.
                ds.Tables("form_daily1").Rows(inc).Item("entryDatetime") = Now()

                'Commit observation values to database
                'Observation values range from column 5 i.e. column index 4 to column 38 i.e. column index 37
                For m = 5 To (valueFldsTotal + 4) 'm = 4 To 38
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            ds.Tables("form_daily1").Rows(inc).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                'Commit observation flags to database
                'Observation Flags range from column 39 i.e. column index 38 to column 72 i.e. column index 71
                For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4 'm = 39 To 71
                    For Each ctl In Me.Controls
                        If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                            ds.Tables("form_daily1").Rows(inc).Item(m) = ctl.Text
                        End If
                    Next ctl
                Next m

                da.Update(ds, "form_daily1")

                'Display message for successful record commit to table
                recCommit.messageBoxCommit()

                btnAddNew.Enabled = True
                btnClear.Enabled = False
                btnCommit.Enabled = False
                btnDelete.Enabled = True
                btnUpdate.Enabled = True
                btnMoveFirst.Enabled = True
                btnMoveLast.Enabled = True
                btnMoveNext.Enabled = True
                btnMovePrevious.Enabled = True

                'Disable Delete button for ClimsoftOperator and ClimsoftRainfall
                If userGroup = "ClimsoftOperator" Or userGroup = "ClimsoftRainfall" Then
                    btnDelete.Enabled = False
                End If

                maxrows = ds.Tables("form_daily1").Rows.Count
                inc = maxrows - 1

                navigateRecords()
                btnAddNew.Focus()
            Else
                msgTxtInsufficientData = "Incomplete header information or insufficient observation data!"
                MsgBox(msgTxtInsufficientData, MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " at btnCommit")
        End Try
    End Sub

    Private Sub navigateRecords()


        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        '--------------------------
        Try
            Dim stn As String

            stn = ds.Tables("form_daily1").Rows(inc).Item("stationId")
            cboStation.SelectedValue = stn
            '--------------------------
            'No need to assign text value to station combobox after assigning the "SelectedValue as above. This way, the displayed value
            'will be the station name according to the "DisplayMember in the texbox attribute, hence the line below has been commented out."

            'cboStation.SelectedValue = ds.Tables("form_daily1").Rows(inc).Item("stationId")
            cboYear.Text = ds.Tables("form_daily1").Rows(inc).Item("yyyy")
            cboMonth.Text = ds.Tables("form_daily1").Rows(inc).Item("mm")
            cboDay.Text = ds.Tables("form_daily1").Rows(inc).Item("dd")
            cboHour.Text = ds.Tables("form_daily1").Rows(inc).Item("hh")

            Dim m As Integer
            Dim ctl As Control

            'Display observation values in coressponding textboxes
            'Observation values start in column 6 i.e. column index 5, and end in column 54 i.e. column Index 53
            For m = 5 To (valueFldsTotal + 4)
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 6) = "txtVal" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily1").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily1").Rows(inc).Item(m)
                        Else
                            ctl.Text = ""
                        End If

                    End If
                Next ctl
            Next m

            'Display observation flags in coressponding textboxes
            'Observation values start in column 55 i.e. column index 54, and end in column 103 i.e. column Index 102
            For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                For Each ctl In Me.Controls
                    If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                        If Not IsDBNull(ds.Tables("form_daily1").Rows(inc).Item(m)) Then
                            ctl.Text = ds.Tables("form_daily1").Rows(inc).Item(m)
                        Else
                            ctl.Text = ""
                        End If

                    End If
                Next ctl
            Next m
            displayRecordNumber()
        Catch ex As Exception
            MsgBox(ex.Message & " at navigateRecord")
        End Try
    End Sub

    Sub txtbox1Focus()
        'MsgBox(1)
        Dim txtl As Control
        For Each txtl In Me.Controls
            'MsgBox(txtl.Name & " " & txtl.TabIndex)
            If txtl.TabIndex = 5 Then
                'MsgBox(txtl.Name)
                txtl.Focus()
                Exit For
            End If
        Next
    End Sub

    Sub formPopulate()
        Dim Ctrl As Control
        Dim dattime, dtt As String

        Try

            dattime = DateSerial(cboYear.Text, cboMonth.Text, cboDay.Text) & " " & cboHour.Text.PadLeft(2, "0") & ":00:00"
            dtt = cboYear.Text & "-" & cboMonth.Text & "-" & cboDay.Text & " " & cboHour.Text.PadLeft(2, "0") & ":00:00"

            If DateDiff("h", Now(), dattime) >= 0 Or Not IsDate(dtt) Then

                'MsgBox("Observations for future date not allowed")

                ' dissable text boxes
                DisableTboxes()
                lblInvaliDate.Text = "Invalid Date Entry! Check Values"
                lblInvaliDate.ForeColor = Color.Red
                cboYear.Focus()
                Exit Sub
            Else
                ' enable text boxes
                lblInvaliDate.Text = ""
                EnablableTboxes()
            End If

            Dim conn1 As New MySql.Data.MySqlClient.MySqlConnection
            Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds1 As New DataSet


            conn1.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
            conn1.Open()
            sql = "select * from form_daily1 where stationId ='" & cboStation.SelectedValue & "' and yyyy = " & cboYear.Text & " and mm = " & cboMonth.Text & " and dd = " & cboDay.Text & " and hh = " & cboHour.Text & ";"

            ds1.Clear()
            da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn1)
            da1.Fill(ds1, "form_daily1")
            conn1.Close()


            With ds1.Tables("form_daily1")
                If .Rows.Count = 0 Then

                    btnAddNew.Enabled = True
                    btnCommit.Enabled = True
                    btnUpdate.Enabled = False
                    btnDelete.Enabled = False
                    btnClear.Enabled = True
                    btnMoveFirst.Enabled = False
                    btnMoveNext.Enabled = False
                    btnMovePrevious.Enabled = False
                    btnMoveLast.Enabled = False
                    recNumberTextBox.Text = "New Record"

                Else
                    btnAddNew.Enabled = True
                    btnCommit.Enabled = False
                    btnUpdate.Enabled = True
                    btnDelete.Enabled = True
                    btnClear.Enabled = False
                    btnMoveFirst.Enabled = True
                    btnMoveNext.Enabled = True
                    btnMovePrevious.Enabled = True
                    btnMoveLast.Enabled = True
                    GetRecordNo(cboStation.SelectedValue, cboYear.Text, cboMonth.Text, cboDay.Text, cboHour.Text)
                End If

                If .Rows.Count > 0 Then
                    ' Populate Values
                    For i = 5 To .Columns.Count - 1
                        For Each Ctrl In Me.Controls
                            If Strings.Left(Ctrl.Name, 6) = "txtVal" And Val(Strings.Right(Ctrl.Name, 3)) = i Then
                                If Not IsDBNull(.Rows(0).Item(i)) Then
                                    Ctrl.Text = .Rows(0).Item(i)
                                Else
                                    Ctrl.Text = ""
                                End If

                            End If
                        Next
                    Next
                    ' Populate Flags
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                        For Each ctl In Me.Controls
                            If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                If Not IsDBNull(.Rows(0).Item(m)) Then
                                    ctl.Text = .Rows(0).Item(m)
                                Else
                                    ctl.Text = ""
                                End If
                            End If
                        Next ctl
                    Next m
                Else
                    ' Clear Values
                    For i = 5 To .Columns.Count - 1
                        For Each Ctrl In Me.Controls
                            If Strings.Left(Ctrl.Name, 6) = "txtVal" And Val(Strings.Right(Ctrl.Name, 3)) = i Then
                                Ctrl.Text = ""
                            End If
                        Next
                    Next

                    ' Clear Flags
                    For m = (valueFldsTotal + 5) To valueFldsTotal * 2 + 4
                        For Each ctl In Me.Controls
                            If Strings.Left(ctl.Name, 7) = "txtFlag" And Val(Strings.Right(ctl.Name, 3)) = m Then
                                ctl.Text = ""
                            End If
                        Next ctl
                    Next m
                End If
            End With

        Catch ex As Exception
            'MsgBox(ex.Message)
            'conn1.Close()
        End Try
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        formPopulate()
    End Sub


    Private Sub cboMonth_TextChanged(sender As Object, e As EventArgs) Handles cboMonth.TextChanged
        formPopulate()
    End Sub



    'Private Sub cboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged

    'End Sub

    Private Sub cboDay_TextChanged(sender As Object, e As EventArgs) Handles cboDay.TextChanged
        formPopulate()
    End Sub

    Private Sub cboStation_TextChanged(sender As Object, e As EventArgs) Handles cboStation.TextChanged
        formPopulate()
    End Sub

    Private Sub cboStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStation.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) 
        frmFormsExport.Show()
    End Sub


    'Private Sub cboDay_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedValueChanged
    '    formPopulate()
    'End Sub

    Sub GetRecordNo(stn As String, yyyy As Long, mm As Integer, dd As Integer, hh As Integer)
        Dim conn2 As New MySql.Data.MySqlClient.MySqlConnection
        Dim da2 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim ds2 As New DataSet

        Try
            conn2.ConnectionString = myConnectionString & ";Convert Zero Datetime=True;AllowLoadLocalInfile=true"
            conn2.Open()

            sql = "SELECT * FROM form_daily1"
            da2 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn2)
            ds2.Clear()
            da2.Fill(ds2, "records")
            conn2.Close()

            With ds2.Tables("records")
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("stationId") = stn And .Rows(i).Item("yyyy") = yyyy And .Rows(i).Item("mm") = mm And .Rows(i).Item("dd") = dd And .Rows(i).Item("dd") = dd Then
                        inc = i
                        'recNumberTextBox.Text = "Record " & inc + 1 & " of " & .Rows.Count + 1
                        displayRecordNumber()
                        'MsgBox(inc)
                        Exit For
                    End If
                Next
            End With

        Catch ex As Exception
            conn2.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub cboHour_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHour.SelectedIndexChanged
    '    formPopulate()
    'End Sub

    Private Sub cboHour_TextChanged(sender As Object, e As EventArgs) Handles cboHour.TextChanged
        formPopulate()
    End Sub

    'Private Sub cboHour_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboHour.SelectedValueChanged
    '    formPopulate()
    'End Sub

    Sub DisableTboxes()
        Dim Ctl As Control

        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Text = ""
                Ctl.Enabled = False
            End If
        Next

        btnAddNew.Enabled = False
        btnCommit.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnClear.Enabled = False

        recNumberTextBox.Text = ""

    End Sub

    Sub EnablableTboxes()
        Dim Ctl As Control
        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Enabled = True
            End If
        Next
    End Sub

    Private Sub cboYear_TextChanged(sender As Object, e As EventArgs) Handles cboYear.TextChanged
        formPopulate()
    End Sub

    Private Sub cboYear_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedValueChanged
        formPopulate()
    End Sub

    Sub ClearTboxes()
        Dim Ctl As Control
        For Each Ctl In Me.Controls
            If Strings.Left(Ctl.Name, 6) = "txtVal" Or Strings.Left(Ctl.Name, 7) = "txtFlag" Then
                Ctl.Text = ""
            End If
        Next
    End Sub

    Private Sub cboMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMonth.SelectedValueChanged
        formPopulate()
    End Sub

    Private Sub cboDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedIndexChanged
        formPopulate()
    End Sub

    Private Sub cboDay_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboDay.SelectedValueChanged
        formPopulate()
    End Sub

    'Private Sub cboDay_LostFocus(sender As Object, e As EventArgs) Handles cboDay.LostFocus
    '    If txtYear.Text <> "" And cboMonth.Text <> "" And cboDay.Text <> "" Then
    '        'MsgBox(Me.Height)
    '        'MsgBox(cboDay.Text)
    '        formPopulate()
    '    End If
    'End Sub

    'Sub shiftFlags()
    '    Dim flagIndexDiff As Integer
    '    Dim ctls As Control
    '    Dim txt, flg As String

    '    If Not totalCTLS(flagIndexDiff) Then Exit Sub
    '    For Each ctls In Me.Controls
    '        If Strings.Left(ctls.Name, 6) = "txtVal" Then
    '            txt = ctls.Text
    '            flg = "txt" & "Flag" & Strings.Mid(ctls.Name, 12, 3) & "Field" & Format(Val(Strings.Right(ctls.Name, 3)) + flagIndexDiff, "000")
    '            FlagValue(ctls, txt, flg)
    '        End If
    '    Next
    'End Sub

    'Sub FlagValue(txtCTL As Control, txt As String, flg As String)
    '    Dim flgCTL As Control

    '    For Each flgCTL In Me.Controls
    '        If flgCTL.Name = flg Then
    '            If txt = "" Then
    '                If txtCTL.Enabled Then flgCTL.Text = "M"
    '            Else
    '                flgCTL.Text = ""
    '            End If
    '        End If
    '    Next

    'End Sub
    'Sub shiftEntries(kycode As Integer)
    '    Select Case kycode
    '        Case 34 ' Insert
    '            insertValues()
    '            shiftFlags()
    '        Case 33 ' Delete
    '            deleteValues()
    '            shiftFlags()
    '    End Select

    'End Sub
    'Sub insertValues()
    '    Dim ActvCTL, nxtCTL As Control
    '    Dim kount As Integer
    '    Dim txt1, txt2 As String

    '    ActvCTL = Me.ActiveControl
    '    txt1 = ActvCTL.Text
    '    If totalCTLS(kount) Then
    '        ActvCTL.Text = ""
    '        For i = 0 To kount - 2
    '            nxtCTL = GetNextControl(ActvCTL, True)
    '            If nxtCTL.Enabled = True Then
    '                txt2 = nxtCTL.Text
    '                nxtCTL.Text = txt1
    '                If Strings.Left(nxtCTL.Name, 6) <> "txtVal" Then Exit For
    '                txt1 = txt2
    '            End If
    '            'MsgBox(nxtCTL.Name)
    '            ActvCTL = nxtCTL
    '        Next
    '    End If
    'End Sub
    'Sub deleteValues()
    '    Dim ActvCTL, nxtCTL As Control
    '    Dim kount As Integer

    '    ActvCTL = Me.ActiveControl

    '    If totalCTLS(kount) Then
    '        For i = 0 To kount - 1
    '            nxtCTL = GetNextControl(ActvCTL, True)
    '            Do While nxtCTL.Enabled = False
    '                nxtCTL = GetNextControl(nxtCTL, True)
    '            Loop

    '            If Strings.Left(nxtCTL.Name, 6) <> "txtVal" Then
    '                ActvCTL.Text = ""
    '                Exit For
    '            Else
    '                ActvCTL.Text = nxtCTL.Text
    '                ActvCTL = nxtCTL
    '            End If

    '        Next
    '    End If
    'End Sub
    'Function totalCTLS(ByRef kount As Integer) As Boolean
    '    kount = 0

    '    sql = "select * from form_daily1;"

    '    Try
    '        conn.Open()
    '        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
    '        ds.Clear()
    '        da3.Fill(ds, "flds")
    '        conn.Close()

    '        With ds.Tables("flds")
    '            For i = 5 To .Columns.Count - 1
    '                If Strings.Left(.Columns(i).ColumnName, 8) = "Val_Elem" Then
    '                    kount = kount + 1
    '                End If
    '            Next
    '        End With
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

End Class