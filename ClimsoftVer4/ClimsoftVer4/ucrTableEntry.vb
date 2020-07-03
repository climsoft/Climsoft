Public Class ucrTableEntry
    'Boolean to check if control is loading for first time
    Protected bFirstLoad As Boolean = True
    'Stores fields for the table entry
    Protected lstFields As New List(Of String)
    Public bUpdating As Boolean = True    'Boolean Flag to check if record is updating. Set to True by default
    Public bPopulating As Boolean = False
    Protected ucrTableEntryNavigator As ucrNavigation
    Protected dctBaseControls As New Dictionary(Of String, Button) 'holds the add,save,update,delete,clear,cancel etc controls
    Public Event GoingToNextChildControl(sender As Object)
    Public Overrides Sub PopulateControl()
        If clsDataConnection.IsInDesignMode() Then
            Exit Sub ' temporary code to remove the bugs thrown during design time
        End If
        If Not bFirstLoad Then
            bPopulating = True

            MyBase.PopulateControl()

            bUpdating = dtbRecords.Rows.Count > 0

            'check whether to permit data entry based on date entry values
            ValidateDataEntryPermission()

            'set the validation of the controls
            SetValuesValidation()

            'TODO. What to do if the were already set values if this was already new record
            If Not bUpdating Then
                dtbRecords.Rows.Add(dtbRecords.NewRow())
            End If

            'set the values to the input controls
            Dim ucr As ucrValueView
            For Each ctr As Control In Me.Controls
                If TypeOf ctr Is ucrValueView Then
                    ucr = DirectCast(ctr, ucrValueView)
                    If bUpdating Then
                        'key controls don't need to reread the values from the databale
                        If Not ucr.KeyControl Then
                            ucr.SetValueFromDataTable(dtbRecords)
                        End If
                    Else
                        If ucr.KeyControl Then
                            ucr.SetValueToDataTable(dtbRecords) ' For new record then let the key controls write to the new empty datatable
                        Else
                            If ucr.HasDefaultValue() Then
                                ucr.SelectDefaultValue() 'use the default value for new record
                                ucr.SetValueToDataTable(dtbRecords)
                            Else
                                ucr.SetValueFromDataTable(dtbRecords) 'this just clears the existing value in the control
                            End If
                        End If
                    End If

                    'key controls don't need to reread the values from the databale
                    'If Not ucr.KeyControl Then
                    '    ucr.SetValueFromDataTable(dtbRecords)
                    'ElseIf Not bUpdating AndAlso ucr.KeyControl Then
                    '    ucr.SetValueToDataTable(dtbRecords) ' For new record then let the key controls write to the new empty datatable
                    'End If

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
                AddHandler ucrCtrValueView.evtKeyDown, AddressOf OnGoToNextChildControl
                If ucrCtrValueView.KeyControl Then
                    AddKeyField(ucrCtrValueView.FieldName)
                End If
            ElseIf TypeOf ctr Is ucrNavigation Then
                ucrTableEntryNavigator = DirectCast(ctr, ucrNavigation)
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

    Private Sub OnGoToNextChildControl(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If TypeOf sender Is ucrValueView Then
                'on enter only go next if what has been typed in is valid
                If DirectCast(sender, ucrValueView).ValidateValue() Then
                    RaiseEvent GoingToNextChildControl(sender)
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
                                                  ucrTableEntryNavigator.GoToNewRecord()
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

                                          If ucrTableEntryNavigator.iCurrRow < 0 OrElse ucrTableEntryNavigator.iMaxRows < 1 Then
                                              Exit Sub
                                          End If

                                          If MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                              If DeleteRecord() Then
                                                  ucrTableEntryNavigator.RemoveRecord()
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
                                      ucrTableEntryNavigator.MoveFirst()
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

        If ucrTableEntryNavigator.iCurrRow = -1 Then
            dctBaseControls.Item("save").Enabled = True
            dctBaseControls.Item("clear").Enabled = True
            dctBaseControls.Item("add").Enabled = False
            dctBaseControls.Item("cancel").Enabled = True
            dctBaseControls.Item("delete").Enabled = False
            dctBaseControls.Item("update").Enabled = False
        ElseIf ucrTableEntryNavigator.iMaxRows = 0 Then
            dctBaseControls.Item("add").Enabled = False
            dctBaseControls.Item("save").Enabled = True
        ElseIf ucrTableEntryNavigator.iMaxRows > 0 Then
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
