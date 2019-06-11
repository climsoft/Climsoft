Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'Stores fields for the table entry
    Protected lstFields As New List(Of String)
    Public bUpdating As Boolean = True    'Boolean Flag to check if record is updating. Set to True by default
    Public bPopulating As Boolean = False
    Protected ucrNavigator As ucrNavigation
    Protected dctBaseControls As New Dictionary(Of String, Button) 'holds the add,save,update,delete,clear,cancel etc controls

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            bPopulating = True

            MyBase.PopulateControl()

            bUpdating = dtbRecords.Rows.Count > 0

            'check whether to permit data entry based on date entry values
            ValidateDataEntryPermission()

            'set the validation of the controls
            SetValuesValidation()

            If Not bUpdating Then
                dtbRecords.Rows.Add(dtbRecords.NewRow())
            End If

            'set the values to the input controls
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueView Then
                    DirectCast(ctr, ucrValueView).SetValueFromDataTable(dtbRecords)
                End If
            Next

            'change the base buttons state
            SaveEnable()

            bPopulating = False
        End If
    End Sub

    Protected Overridable Sub SetUpTableEntry(strNewTableName As String)
        Dim ucrCtrValueView As ucrValueView
        lstFields.Clear()

        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucrCtrValueView = DirectCast(ctr, ucrValueView)
                ucrCtrValueView.SetUpControlInParent(lstFields, AddressOf InnerControlValueChanged)
                AddHandler ucrCtrValueView.evtKeyDown, AddressOf GoToNextChildControl
                If ucrCtrValueView.KeyControl Then
                    AddKeyField(ucrCtrValueView.FieldName)
                End If
            ElseIf TypeOf ctr Is ucrNavigation Then
                ucrNavigator = DirectCast(ctr, ucrNavigation)
            ElseIf TypeOf ctr Is Button Then
                SetupBaseControl(ctr.Tag, DirectCast(ctr, Button))
            End If

        Next
        SetTableNameAndFields(strNewTableName, lstFields)


    End Sub


    Private Sub InnerControlValueChanged(sender As Object, e As EventArgs)
        Dim ucr As ucrValueView
        If TypeOf sender Is ucrValueView Then
            If Not bPopulating Then
                ucr = DirectCast(sender, ucrValueView)
                'If ucr.ValidateValue() Then
                '    ucr.SetValueToDataTable(dtbRecords)
                'End If
                ucr.SetValueToDataTable(dtbRecords)
            End If

        End If

    End Sub

    Protected Overrides Sub LinkedControls_evtValueChanged()
        'Do nothing. Overriden to prevent any default action from being taken by the parent
    End Sub

    Private Sub GoToNextChildControl(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrValueView Then
                'on enter only go next if what has been typed in is valid
                If DirectCast(sender, ucrValueView).ValidateValue() Then
                    Me.SelectNextControl(sender, True, True, True, True)
                End If
                'this handles the "noise" on  return key down
                e.SuppressKeyPress = True
            End If
        End If

    End Sub

    Public Overrides Function ValidateValue() As Boolean
        Dim ucr As ucrValueView
        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucr = DirectCast(ctr, ucrValueView)
                'TODO. What should we do for controls without field names
                If Not String.IsNullOrEmpty(ucr.FieldName) AndAlso Not ucr.ValidateValue() Then
                    ctr.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Public Function InsertRecord() As Boolean
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Function UpdateRecord() As Boolean
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Function DeleteRecord() As Boolean
        If dtbRecords.Rows.Count = 1 Then
            dtbRecords.Rows(0).Delete()
        ElseIf dtbRecords.Rows.Count > 1 Then
            For index As Integer = 0 To dtbRecords.Rows.Count - 1
                dtbRecords.Rows(index).Delete()
            Next
        Else
            'TODO?
        End If
        Return clsDataDefinition.Save(dtbRecords)
    End Function

    Public Overridable Function GetFieldValue(strFieldName As String) As Object
        Dim lstTemp As New List(Of Object)

        If strFieldName = "" Then
            Return Nothing
        End If
        If dtbRecords.Rows.Count = 1 Then
            Return dtbRecords.Rows(0).Item(strFieldName)
        ElseIf dtbRecords.Rows.Count > 1 Then
            For Each tempRow As DataRow In dtbRecords.Rows
                lstTemp.Add(tempRow.Item(strFieldName))
            Next
            Return lstTemp
        Else
            Return Nothing
        End If
    End Function

    Protected Sub SetupBaseControl(strControlName As String, btn As Button)
        If String.IsNullOrEmpty(strControlName) Then
            Exit Sub
        ElseIf dctBaseControls.ContainsKey(strControlName) Then
            dctBaseControls.Item(strControlName) = btn
        Else
            dctBaseControls.Add(strControlName, btn)
        End If

        If strControlName = "add" Then
            AddHandler btn.Click, Sub()
                                      'todo?
                                  End Sub
        ElseIf strControlName = "save" Then
            AddHandler btn.Click, Sub()
                                      Try

                                          If Not ValidateValue() Then
                                              Exit Sub
                                          End If

                                          'Confirm if you want to continue and save data from key-entry form to database table
                                          If MessageBox.Show("Do you want to continue and commit to database table?", "Save Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                              If InsertRecord() Then
                                                  ucrNavigator.GoToNewRecord()
                                                  SaveEnable()
                                                  MessageBox.Show("New record added to database table!", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              Else
                                                  MessageBox.Show("Record not Saved", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                              End If
                                          End If
                                      Catch ex As Exception
                                          MessageBox.Show("New Record has NOT been added to database table. Error: " & ex.Message, "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                      End Try
                                  End Sub
        ElseIf strControlName = "update" Then
            AddHandler btn.Click, Sub()
                                      Try
                                          If Not ValidateValue() Then
                                              Exit Sub
                                          End If

                                          If MessageBox.Show("Are you sure you want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                              If UpdateRecord() Then
                                                  MessageBox.Show("Record updated successfully!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              Else
                                                  MessageBox.Show("Record not updated", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                              End If
                                          End If
                                      Catch ex As Exception
                                          MessageBox.Show("Record has NOT been updated. Error: " & ex.Message, "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                      End Try
                                  End Sub
        ElseIf strControlName = "delete" Then
            'Disable Delete & upload button for ClimsoftOperator and ClimsoftRainfall
            If userGroup = "ClimsoftOperator" OrElse userGroup = "ClimsoftRainfall" Then
                btn.Enabled = False
            End If

            AddHandler btn.Click, Sub()
                                      Try

                                          If Not ValidateValue() Then
                                              Exit Sub
                                          End If

                                          If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                              If DeleteRecord() Then
                                                  ucrNavigator.RemoveRecord()
                                                  SaveEnable()
                                                  MessageBox.Show("Record has been deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              Else
                                                  MessageBox.Show("Record NOT Deleted", "Save Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              End If
                                          End If
                                      Catch ex As Exception
                                          MessageBox.Show("Record has NOT been deleted. Error: " & ex.Message, "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                      End Try
                                  End Sub
        ElseIf strControlName = "clear" Then
            AddHandler btn.Click, Sub()
                                      Clear()
                                  End Sub
        ElseIf strControlName = "cancel" Then
            AddHandler btn.Click, Sub()
                                      ucrNavigator.MoveFirst()
                                      SaveEnable()
                                  End Sub
        ElseIf strControlName = "close" Then
            AddHandler btn.Click, Sub()
                                      FindForm.Close()
                                  End Sub
        ElseIf strControlName = "upload" Then
            'Disable Delete & upload button for ClimsoftOperator and ClimsoftRainfall
            If userGroup = "ClimsoftOperator" OrElse userGroup = "ClimsoftRainfall" Then
                btn.Enabled = False
            End If
        End If


    End Sub

    ''' <summary>
    ''' Enables appropriately the base buttons on Delete, Save, Add New, Clear, Cancel and on dialog load
    ''' </summary>
    Protected Sub SaveEnable()

        If dctBaseControls.Count = 0 Then
            Exit Sub
        End If

        dctBaseControls.Item("add").Enabled = True
        dctBaseControls.Item("save").Enabled = False
        dctBaseControls.Item("update").Enabled = False
        dctBaseControls.Item("delete").Enabled = False
        dctBaseControls.Item("clear").Enabled = False
        dctBaseControls.Item("cancel").Enabled = False

        If ucrNavigator.iCurrRow = -1 Then
            dctBaseControls.Item("save").Enabled = True
            dctBaseControls.Item("clear").Enabled = True
            dctBaseControls.Item("add").Enabled = False
            dctBaseControls.Item("cancel").Enabled = True
            dctBaseControls.Item("delete").Enabled = False
            dctBaseControls.Item("update").Enabled = False
        ElseIf ucrNavigator.iMaxRows = 0 Then
            dctBaseControls.Item("add").Enabled = False
            dctBaseControls.Item("save").Enabled = True
        ElseIf ucrNavigator.iMaxRows > 0 Then
            dctBaseControls.Item("delete").Enabled = True
            dctBaseControls.Item("update").Enabled = True
        End If

        'Disable Delete & upload button for ClimsoftOperator and ClimsoftRainfall
        If userGroup = "ClimsoftOperator" OrElse userGroup = "ClimsoftRainfall" Then
            dctBaseControls.Item("delete").Enabled = True
        End If
    End Sub

    Public Overrides Sub Clear()
        Dim ucr As ucrValueView
        For Each ctr As Control In Controls
            If TypeOf ctr Is ucrValueView Then
                ucr = DirectCast(ctr, ucrValueView)
                'Don't clear key controls
                If Not ucr.KeyControl Then
                    ucr.Clear()
                End If
            End If
        Next
    End Sub

    'To be ovverriden by chikd controls that need it
    Protected Overridable Sub ValidateDataEntryPermission()
    End Sub

    'To be overriden by chikd controls that need it
    Protected Overridable Sub SetValuesValidation()
    End Sub

End Class
