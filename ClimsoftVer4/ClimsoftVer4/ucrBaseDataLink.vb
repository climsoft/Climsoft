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
Public Class ucrBaseDataLink
    Protected clsDataDefinition As DataCall
    Protected dtbRecords As New DataTable
    Protected dctLinkedControlsFilters As New Dictionary(Of ucrValueView, KeyValuePair(Of String, TableFilter))
    Private strTableName As String


    ' ucrBaseDataLink is a base control for a control to connect to the database
    ' Infomation about how the control connects to the database will be here
    ' Including: reading/writing, which tables/fields/records to connect to

    ' Inherited controls:
    ' textbox, nud, checkbox, combobox, listbox etc.

    ' Inherited from these can be controls for common fields:
    ' station selector, element selector, tmax entry etc.

    Public Sub SetDataDefinition(clsNewDataDefinition As DataCall)
        clsDataDefinition = clsNewDataDefinition
    End Sub

    Public Function GetDataDefinition() As DataCall
        Return clsDataDefinition
    End Function

    Private Sub CreateDataDefinition()
        If clsDataDefinition Is Nothing Then
            clsDataDefinition = New DataCall
        End If
    End Sub

    Public Overridable Sub SetTableName(strNewTable As String)
        CreateDataDefinition()
        strTableName = strNewTable
        clsDataDefinition.SetTableName(strNewTable:=strNewTable)
    End Sub

    Public Function GetTableName() As String
        Return strTableName
    End Function

    Public Sub SetFields(dctNewFields As Dictionary(Of String, List(Of String)))
        CreateDataDefinition()
        clsDataDefinition.SetFields(dctNewFields:=dctNewFields)
        SetSortByItems()
    End Sub

    Public Sub SetFields(lstNewFields As List(Of String))
        CreateDataDefinition()
        clsDataDefinition.SetFields(lstNewFields:=lstNewFields)
        SetSortByItems()
    End Sub

    Public Sub SetField(strNewField As String)
        CreateDataDefinition()
        clsDataDefinition.SetField(strNewField)
        SetSortByItems()
    End Sub

    Public Sub AddField(strNewField As String)
        CreateDataDefinition()
        clsDataDefinition.AddField(strNewField)
        SetSortByItems()
    End Sub

    Public Overridable Sub SetTableNameAndField(strNewTable As String, strNewField As String)
        SetTableName(strNewTable)
        SetField(strNewField)
    End Sub
    ''' <summary>
    ''' Sets the table name and a dictionary of fields for a control
    ''' </summary>
    ''' <param name="strNewTable"></param>
    ''' <param name="dctNewFields"></param>
    Public Overridable Sub SetTableNameAndFields(strNewTable As String, dctNewFields As Dictionary(Of String, List(Of String)))
        SetTableName(strNewTable)
        SetFields(dctNewFields)
    End Sub
    ''' <summary>
    ''' Sets the table name and a list of fields for a control
    ''' </summary>
    ''' <param name="strNewTable"></param>
    ''' <param name="lstNewFields"></param>
    Public Overridable Sub SetTableNameAndFields(strNewTable As String, lstNewFields As List(Of String))
        SetTableName(strNewTable)
        SetFields(lstNewFields)
    End Sub

    Public Function GetDataField() As String
        Return clsDataDefinition.GetField
    End Function

    Public Overridable Sub SetFilter(clsNewFilter As TableFilter)
        CreateDataDefinition()
        clsDataDefinition.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overridable Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        CreateDataDefinition()
        clsDataDefinition.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Sub SetSortByItems()
        '    tsSortBy.DropDownItems.Clear()
        '    For Each kvpField As KeyValuePair(Of String, String) In clsDataDefinition.GetFields()
        '        tsSortBy.DropDownItems.Add(kvpField.Value)
        '        tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Tag = kvpField.Key
        '        AddHandler tsSortBy.DropDownItems.Item(tsSortBy.DropDownItems.Count - 1).Click, AddressOf Sort
        '    Next
    End Sub

    Protected Overridable Sub Sort()
        For Each tsField As ToolStripMenuItem In tsSortBy.DropDownItems
            If tsField.Checked Then
                ' dtbStations.DefaultView.Sort = tsField.Tag & " ASC"
                ' refresh display
            End If
        Next
    End Sub

    Public Sub UpdateDataTable()
        If Not IsNothing(clsDataDefinition) Then
            dtbRecords = clsDataDefinition.GetDataTable(GetLinkedControlsFilter())
        End If
    End Sub

    Public Overridable Sub PopulateControl()
        UpdateDataTable()
    End Sub

    Public Overridable Sub UpdateInputValueToDataTable()

    End Sub

    Public Overridable Function ValidateValue() As Boolean
        Return True
    End Function

    Public Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrValueView, strNewFieldName As String, strNewOperator As String, Optional bNewIsPositiveCondition As Boolean = True, Optional strLinkedFieldName As String = "", Optional bForceValuesAsString As Boolean = False)

        Dim temp As Object
        temp = ucrLinkedDataControl.GetValue(strLinkedFieldName)

        'TODO. This needs to be refined. For some reason TypeOf temp fails to work as expected. the type of fails to match hence we added the  
        'temp.GetType for redundancy
        If TypeOf temp Is String OrElse TypeOf temp Is Integer OrElse TypeOf temp Is Long OrElse temp.GetType Is GetType(String) OrElse temp.GetType Is GetType(Integer) OrElse temp.GetType Is GetType(Long) Then
            'temp = CStr(temp)
            AddLinkedControlFilters(ucrLinkedDataControl, New TableFilter(strNewField:=strNewFieldName, strNewOperator:=strNewOperator, strNewValue:=temp, bNewIsPositiveCondition:=bNewIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString), strLinkedFieldName)
        Else
            AddLinkedControlFilters(ucrLinkedDataControl, New TableFilter(strNewField:=strNewFieldName, strNewOperator:=strNewOperator, lstNewValue:=temp, bNewIsPositiveCondition:=bNewIsPositiveCondition, bForceValuesAsString:=bForceValuesAsString), strLinkedFieldName)
        End If

    End Sub

    Public Overridable Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrValueView, tblFilter As TableFilter, Optional strLinkedFieldName As String = "")
        Dim kvpTemp As New KeyValuePair(Of String, TableFilter)(strLinkedFieldName, tblFilter)

        If dctLinkedControlsFilters.ContainsKey(ucrLinkedDataControl) Then
            'TODO
            'THIS NEEDS TO BE CHANGED. This WON"T WORK
            'If Not dctLinkedControlsFilters.Contains(New KeyValuePair(Of ucrValueView, KeyValuePair(Of String, TableFilter))(ucrLinkedDataControl, kvpTemp)) Then
            dctLinkedControlsFilters.Item(ucrLinkedDataControl) = kvpTemp
            'End If

            'If dctLinkedControlsFilters.Item(ucrLinkedDataControl).Key = strLinkedFieldName Then
            '    dctLinkedControlsFilters.Item(ucrLinkedDataControl) = kvpTemp
            'End If
        Else
            dctLinkedControlsFilters.Add(ucrLinkedDataControl, kvpTemp)
        End If

        AddHandler ucrLinkedDataControl.evtValueChanged, AddressOf LinkedControls_evtValueChanged
    End Sub

    Protected Overridable Sub LinkedControls_evtValueChanged()
        PopulateControl()
    End Sub

    Public Sub RemoveLinkedControlsFilters(ucrLinkedDataControl As ucrBaseDataLink)
        dctLinkedControlsFilters.Remove(ucrLinkedDataControl)
    End Sub

    Protected Sub UpdateDctLinkedControlsFilters()
        Dim tempTableFilter As TableFilter
        Dim strTempFieldName As String

        For Each ucrTemp As ucrValueView In dctLinkedControlsFilters.Keys
            tempTableFilter = dctLinkedControlsFilters(ucrTemp).Value
            strTempFieldName = dctLinkedControlsFilters(ucrTemp).Key

            If tempTableFilter.IsCombinedFilter Then
                tempTableFilter.SetLeftAndRightFilter(tempTableFilter.GetLeftFilter, tempTableFilter.GetRightFilter)
            Else
                If tempTableFilter.IsArrayOperator Then
                    If tempTableFilter.IsValuesFromDataCall Then
                        tempTableFilter.SetDataCallValues(ucrTemp.GetLinkingDataCall())
                    Else
                        tempTableFilter.SetValues(ucrTemp.GetValue(strTempFieldName))
                    End If
                Else
                    tempTableFilter.SetValue(ucrTemp.GetValue(strTempFieldName))
                End If
            End If
            'dctLinkedControlsFilters(ucrTemp).SetValue(ucrTemp.GetValue())
        Next
    End Sub

    Public Function GetLinkedControlsFilter() As Object
        Dim clsOveralControlsFilter As TableFilter

        UpdateDctLinkedControlsFilters()

        If dctLinkedControlsFilters.Count = 0 Then
            Return Nothing
        ElseIf dctLinkedControlsFilters.Count > 1 Then
            clsOveralControlsFilter = New TableFilter
            For i = 0 To dctLinkedControlsFilters.Count - 2
                If i = 0 Then
                    clsOveralControlsFilter.SetLeftFilter(dctLinkedControlsFilters.Values(i).Value.Clone())
                    clsOveralControlsFilter.SetRightFilter(dctLinkedControlsFilters.Values(i + 1).Value.Clone())
                    clsOveralControlsFilter.SetOperator("AND")
                Else
                    clsOveralControlsFilter.SetLeftFilter(clsOveralControlsFilter.Clone())
                    clsOveralControlsFilter.SetRightFilter(dctLinkedControlsFilters.Values(i + 1).Value.Clone())
                End If
            Next
        Else
            clsOveralControlsFilter = dctLinkedControlsFilters.Values(0).Value.Clone()
        End If
        Return clsOveralControlsFilter
    End Function

    Public Overridable Function GetLinkingDataCall() As DataCall
        MessageBox.Show("Developer error: The Linking Datacall of " & Me.Name & " has not been overriden ", caption:="Developer error")
        Return Nothing
    End Function

    Public Overridable Sub Clear()

    End Sub

    Private Sub ucrBaseDataLink_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class