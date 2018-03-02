' R- Instat
' Copyright (C) 2015-2017
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

Public Class ucrDirectionSpeedFlag
    Private bFirstLoad As Boolean = True
    Private iDirectionDigits As Integer = 2
    Private iSpeedDigits As Integer = 2
    Public Event evtGoToNextVFPControl(sender As Object, e As KeyEventArgs)

    Public Overrides Sub SetTableName(strNewTable As String)
        MyBase.SetTableName(strNewTable)
        'ucrDirectionSpeed.SetTableName(strNewTable)
        ucrDirection.SetTableName(strNewTable)
        ucrSpeed.SetTableName(strNewTable)
        ucrFlag.SetTableName(strNewTable)
    End Sub

    Public Sub SetDirectionSpeedFlagFields(strDirectionFieldName As String, strSpeedFieldName As String, strFlagFieldName As String)
        SetFields(New List(Of String)({strDirectionFieldName, strSpeedFieldName, strFlagFieldName}))
        'SetDirectionSpeedField(strDirectionFieldName, strSpeedFieldName)
        SetDirectionField(strDirectionFieldName)
        SetSpeedField(strSpeedFieldName)
        SetFlagField(strFlagFieldName)
    End Sub

    Public Sub SetTableNameAndDirectionSpeedFlagFields(strTableName As String, strDirectionFieldName As String, strSpeedFieldName As String, strFlagFieldName As String)
        SetTableName(strTableName)
        SetDirectionSpeedFlagFields(strDirectionFieldName, strSpeedFieldName, strFlagFieldName)
    End Sub

    'Public Sub SetDirectionSpeedField(strDirectionFieldName As String, strSpeedFieldName As String)

    'Dim dctNewFields As New Dictionary(Of String, List(Of String))
    'dctNewFields.Add(strDirectionFieldName, New List(Of String)({strDirectionFieldName, strSpeedFieldName}))
    'ucrDirectionSpeed.SetFields(dctNewFields)
    'End Sub

    Public Sub SetDirectionField(strFieldName As String)
        ucrDirection.SetField(strFieldName)
    End Sub

    Public Sub SetSpeedField(strFieldName As String)
        ucrSpeed.SetField(strFieldName)
    End Sub

    Public Sub SetFlagField(strFieldName As String)
        ucrFlag.SetField(strFieldName)
    End Sub

    Public Overrides Sub SetFilter(clsNewFilter As TableFilter)
        MyBase.SetFilter(clsNewFilter)
        'ucrDirectionSpeed.SetFilter(clsNewFilter:=clsNewFilter)
        ucrDirection.SetFilter(clsNewFilter:=clsNewFilter)
        ucrSpeed.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFlag.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub

    Public Overrides Sub SetFilter(strField As String, strOperator As String, strValue As String, Optional bIsPositiveCondition As Boolean = True)
        MyBase.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        'ucrDirectionSpeed.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrDirection.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrSpeed.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
        ucrFlag.SetFilter(strField:=strField, strOperator:=strOperator, strValue:=strValue, bIsPositiveCondition:=bIsPositiveCondition)
    End Sub

    Public Overrides Sub AddLinkedControlFilters(ucrLinkedDataControl As ucrBaseDataLink, tblFilter As TableFilter, Optional strFieldName As String = "")
        MyBase.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        'ucrDirectionSpeed.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrDirection.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrSpeed.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
        ucrFlag.AddLinkedControlFilters(ucrLinkedDataControl, tblFilter, strFieldName)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            'ucrDirectionSpeed.PopulateControl()
            ucrDirection.PopulateControl()
            ucrSpeed.PopulateControl()
            ucrFlag.PopulateControl()
        End If
    End Sub

    Public Overrides Sub Clear()
        ucrDDFF.Clear()
        ucrDirection.Clear()
        ucrSpeed.Clear()
        ucrFlag.Clear()
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim lstValues As List(Of Object)

        MyBase.SetValue(objNewValue)
        lstValues = TryCast(objNewValue, List(Of Object))
        If lstValues.Count = 3 Then
            'ucrDirectionSpeed.SetValue(lstValues(0) + lstValues(1))
            ucrDirection.SetValue(lstValues(0))
            ucrSpeed.SetValue(lstValues(1))
            ucrFlag.SetValue(lstValues(2))
        End If
    End Sub

    Public Sub SetBackColor(backColor As Color)
        ucrDDFF.SetBackColor(backColor)
        ucrDirection.SetBackColor(backColor)
        ucrSpeed.SetBackColor(backColor)
        ucrFlag.SetBackColor(backColor)
    End Sub

    Private Sub ucrDirectionSpeedFlag_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            ucrFlag.SetTextToUpper()
            bFirstLoad = False
        End If
    End Sub

    Public Sub SetDirectionValidation(elementId As Integer)
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))
        clsDataDefinition.SetFilter("elementId", "=", elementId, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            ucrDirection.SetValidationTypeAsNumeric(dcmMin:=dtbl.Rows(0).Item("lowerLimit"), dcmMax:=dtbl.Rows(0).Item("upperLimit"))
        End If
    End Sub

    Public Sub SetSpeedValidation(elemCode As Integer)
        Dim clsDataDefinition As DataCall
        Dim dtbl As DataTable
        clsDataDefinition = New DataCall
        'PLEASE NOTE THIS TABLE IS CALLED obselement IN THE DATABASE BUT
        'THE GENERATED ENTITY MODEL HAS NAMED IT AS obselements
        clsDataDefinition.SetTableName("obselements")
        clsDataDefinition.SetFields(New List(Of String)({"lowerLimit", "upperLimit"}))
        clsDataDefinition.SetFilter("elementId", "=", elemCode, bForceValuesAsString:=False)
        dtbl = clsDataDefinition.GetDataTable()
        If dtbl IsNot Nothing AndAlso dtbl.Rows.Count > 0 Then
            ucrSpeed.SetValidationTypeAsNumeric(dcmMin:=dtbl.Rows(0).Item("lowerLimit"), dcmMax:=dtbl.Rows(0).Item("upperLimit"))
        End If
    End Sub

    Private Sub ucrDirectionSpeedFlag_KeyDown(sender As Object, e As KeyEventArgs) Handles ucrDDFF.evtKeyDown, ucrDirection.evtKeyDown, ucrSpeed.evtKeyDown, ucrFlag.evtKeyDown
        'TODO
        'FIND AWAY OF PASSING ME AND THE SENDER TO THE evtGoToNextVFPControl
        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            If sender Is ucrDDFF.txtBox Then
                If ucrDDFFEnter() Then
                    'My.Computer.Keyboard.SendKeys("{TAB}")
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                End If
            ElseIf sender Is ucrDirection.txtBox Then
                If QcForDirection() Then
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                End If
            ElseIf sender Is ucrSpeed.txtBox Then
                If QcForSpeed() Then
                    RaiseEvent evtGoToNextVFPControl(Me, e)
                End If
            ElseIf sender Is ucrFlag.txtBox Then
                RaiseEvent evtGoToNextVFPControl(Me, e)
            End If
        End If
    End Sub

    Private Sub ucrDDFF_TextChanged(sender As Object, e As EventArgs) Handles ucrDDFF.evtTextChanged


    End Sub

    Private Function ucrDDFFEnter() As Boolean
        Dim bValuesCorrect As Boolean = False
        If Not ucrDDFF.IsEmpty() Then
            'Check for an observation flag in the texbox for observation value.
            'If a flag exists then separate the flag from the value and place the flag in the corresponding flag field.
            If IsNumeric(Strings.Right(ucrDDFF.GetValue, 1)) Then
                'Then Flag must be blank
                ucrFlag.SetValue("")
            Else
                'Get observation flag from the texbox 
                'flag Is a single letter added as the last character 
                'assign obsFlag to correct texbox on the form
                ucrFlag.SetValue(Strings.Right(ucrDDFF.GetValue, 1))
                'Get the observation value by leaving out the last character from the string entered in the textbox
                ucrDDFF.SetValue(Strings.Left(ucrDDFF.GetValue, ucrDDFF.GetValue.Length - 1))
            End If

            'Check that ddff is numeric
            If IsNumeric(ucrDDFF.GetValue) Then
                If ucrDDFF.GetValue.Length = iDirectionDigits + iSpeedDigits Then
                    ucrDDFF.SetBackColor(Color.White)
                    bValuesCorrect = True
                    'If number of digits is correct then separate dd and ff
                    ucrSpeed.SetValue(Strings.Right(ucrDDFF.GetValue, iSpeedDigits))
                    ucrDirection.SetValue(Strings.Left(ucrDDFF.GetValue, iDirectionDigits))
                Else
                    ucrDDFF.SetBackColor(Color.Cyan)
                    ucrDDFF.Focus()
                    bValuesCorrect = False
                    MsgBox("Wrong number of digits for ddff!", MsgBoxStyle.Exclamation)
                End If
            Else
                ucrDDFF.SetBackColor(Color.Red)
                ucrDDFF.Focus()
                bValuesCorrect = False
                MsgBox("Number expected!", MsgBoxStyle.Critical)
            End If
            If bValuesCorrect Then
                If QcForDirection() AndAlso QcForSpeed() Then
                    bValuesCorrect = True
                Else
                    ucrDDFF.SetBackColor(Color.Cyan)
                    ucrDDFF.Focus()
                    bValuesCorrect = False
                End If
            End If
        Else
            bValuesCorrect = True
        End If
        Return bValuesCorrect
    End Function

    Private Function QcForDirection() As Boolean
        'THE VALIDATION DONE HERE CAN BE PUSHED INTO THE UCRTEXTBOX
        'I HAVE DONE IT HERE TEMPORARILY TO SHOW THE CONTROL FUNCTIONALITY
        Dim bValuesCorrect As Boolean = False
        Dim iType As Integer
        'QC checks for  direction
        If Not ucrDirection.IsEmpty() Then
            iType = ucrDirection.ValidateNumeric(ucrDirection.GetValue)
            If iType = 0 Then
                ucrDirection.SetBackColor(Color.White)
                bValuesCorrect = True
            ElseIf iType = 1
                ucrDirection.SetBackColor(Color.Red)
                ucrDirection.Focus()
                bValuesCorrect = False
                MsgBox("Number expected!", MsgBoxStyle.Critical)
            ElseIf iType = 2
                'for out of range
                'check if it was lower limit violation and display appropriate message
                If ucrDirection.GetDcmMinimum <= Val(ucrDirection.GetValue) Then
                    ucrDirection.SetBackColor(Color.White)
                    bValuesCorrect = True
                Else
                    ucrDirection.SetBackColor(Color.Cyan)
                    ucrDirection.Focus()
                    bValuesCorrect = False
                    MsgBox("Value lower than lowerlimit of: " & ucrDirection.GetDcmMinimum, MsgBoxStyle.Exclamation)
                End If

                'check if it was upper limit violation
                If ucrDirection.GetDcmMaximum >= Val(ucrDirection.GetValue) Then
                    ucrDirection.SetBackColor(Color.White)
                    bValuesCorrect = True
                Else
                    ucrDirection.SetBackColor(Color.Cyan)
                    ucrDirection.Focus()
                    bValuesCorrect = False
                    MsgBox("Value higher than upperlimit of: " & ucrDirection.GetDcmMaximum, MsgBoxStyle.Exclamation)
                End If
            End If
        End If
        Return bValuesCorrect
    End Function

    Private Function QcForSpeed() As Boolean
        'THE VALIDATION DONE HERE CAN BE PUSHED INTO THE UCRTEXTBOX
        'I HAVE DONE IT HERE TEMPORARILY TO SHOW THE CONTROL FUNCTIONALITY
        Dim bValuesCorrect As Boolean = False
        Dim iType As Integer
        'QC checks for  direction
        If Not ucrSpeed.IsEmpty() Then
            iType = ucrSpeed.ValidateNumeric(ucrSpeed.GetValue)
            If iType = 0 Then
                ucrSpeed.SetBackColor(Color.White)
                bValuesCorrect = True
            ElseIf iType = 1
                ucrSpeed.SetBackColor(Color.Red)
                ucrSpeed.Focus()
                bValuesCorrect = False
                MsgBox("Number expected!", MsgBoxStyle.Critical)
            ElseIf iType = 2
                'for out of range
                'check if it was lower limit violation and display appropriate message
                If ucrSpeed.GetDcmMinimum <= Val(ucrSpeed.GetValue) Then
                    ucrSpeed.SetBackColor(Color.White)
                    bValuesCorrect = True
                Else
                    ucrSpeed.SetBackColor(Color.Cyan)
                    ucrSpeed.Focus()
                    bValuesCorrect = False
                    MsgBox("Value lower than lowerlimit of: " & ucrSpeed.GetDcmMinimum, MsgBoxStyle.Exclamation)
                End If

                'check if it was upper limit violation
                If ucrSpeed.GetDcmMaximum >= Val(ucrSpeed.GetValue) Then
                    ucrSpeed.SetBackColor(Color.White)
                    bValuesCorrect = True
                Else
                    ucrSpeed.SetBackColor(Color.Cyan)
                    ucrSpeed.Focus()
                    bValuesCorrect = False
                    MsgBox("Value higher than upperlimit of: " & ucrSpeed.GetDcmMaximum, MsgBoxStyle.Exclamation)
                End If
            End If
        End If
        Return bValuesCorrect
    End Function

End Class

