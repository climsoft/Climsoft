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

Public Class ucrValueFlagPeriod
    Private bFirstLoad As Boolean = True
    Private strTableName As String = ""

    Public Sub setTableName(strTableName As String)
        Me.strTableName = strTableName
        ucrValue.SetTableName(strTableName)
        ucrFlag.SetTableName(strTableName)
        ucrPeriod.SetTableName(strTableName)
    End Sub
    Public Sub setFieldNames(Optional strValueFieldName As String = "", Optional strFlagFieldName As String = "", Optional strPeriodFieldName As String = "")
        If strValueFieldName.Trim.Length > 0 Then
            ucrValue.SetFieldName(strValueFieldName)
        End If
        If strFlagFieldName.Trim.Length > 0 Then
            ucrFlag.SetFieldName(strFlagFieldName)
        End If
        If strPeriodFieldName.Trim.Length > 0 Then
            ucrPeriod.SetFieldName(strPeriodFieldName)
        End If
    End Sub
    Public Sub setValueFieldName(strValueFieldName As String)
        setFieldNames(strValueFieldName:=strValueFieldName)
    End Sub
    Public Sub setFlagFieldName(strFlagFieldName As String)
        setFieldNames(strFlagFieldName:=strFlagFieldName)
    End Sub
    Public Sub setPeriodFieldName(strPeriodFieldName As String)
        setFieldNames(strPeriodFieldName:=strPeriodFieldName)
    End Sub

    Public Overrides Sub SetFilter(clsNewFilter As TableFilter)
        MyBase.SetFilter(clsNewFilter)
        ucrValue.SetFilter(clsNewFilter:=clsNewFilter)
        ucrFlag.SetFilter(clsNewFilter:=clsNewFilter)
        ucrPeriod.SetFilter(clsNewFilter:=clsNewFilter)
    End Sub
    Public Sub PopulateValueFlagPeriod()
        PopulateValue()
        PopulateFlag()
        PopulatePeriod()
    End Sub
    Public Sub PopulateValue()
        ucrValue.PopulateTextBox()
    End Sub
    Public Sub PopulateFlag()
        ucrFlag.PopulateTextBox()
    End Sub
    Public Sub PopulatePeriod()
        ucrPeriod.PopulateTextBox()
    End Sub
    Public Sub Clear()
        ClearValue()
        ClearFlag()
        ClearPeriod()
    End Sub
    Public Sub ClearValue()
        ucrValue.Clear()
    End Sub
    Public Sub ClearFlag()
        ucrFlag.Clear()
    End Sub
    Public Sub ClearPeriod()
        ucrPeriod.Clear()
    End Sub

    Private Sub ucrValueFlagPeriod_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            'InitialiseStationDataTable()
            'clsDataDefinition.SetFilter(strStationID, "==", Chr(34) & "67774010" & Chr(34))

            ' Access Rows property on DataTable.
            'For Each row As DataRow In dtbl.Rows
            ' Write value of first Integer.
            'Console.WriteLine(row.Field(Of Integer)(0))
            'Next

            ucrFlag.SetTextToUpper()

            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrControl_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ucrControl_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then

        End If
    End Sub

    Private Sub ucrControl_Enter(sender As Object, e As EventArgs)

    End Sub

    Public Sub setValue()

    End Sub





    Public Function IsEmpty() As Boolean
        Return True
    End Function

    Public Sub SetColor()
        ' txtValue.BackColor = Color.Aqua
    End Sub

    Public Sub RemoveColor()
        'txtValue.BackColor = Color.White
    End Sub

    Private Sub ucrValue_KeyDownEvent(e As KeyEventArgs) Handles ucrValue.KeyDownEvent
        'If {ENTER} key is pressed
        If e.KeyCode = Keys.Enter Then
            If Not IsNumeric(Strings.Right(ucrValue.TextInput, 1)) Then
                'Get observation flag from the texbox and convert it to Uppercase. Flag is a single letter added as the last character
                'to the value string in the textbox.
                ucrFlag.TextInput = Strings.Right(ucrValue.TextInput, 1)

                'Get the observation value by leaving out the last character from the string entered in the textbox
                ucrValue.TextInput = Strings.Left(ucrValue.TextInput, ucrValue.TextInput.Length - 1)

            End If

            'Check that numeric value has been entered for observation value
            If IsNumeric(ucrValue.TextInput) Then
                ucrValue.RemoveBackColor()
                'ucrValue.SetBackColor(Color.White)
                ' My.Computer.Keyboard.SendKeys("{TAB}")
                'tabNext = True
            Else
                ucrValue.SetBackColor(Color.Red)
                ucrValue.GetFocus()

                'tabNext = False
                'MsgBox("Number expected!", MsgBoxStyle.Critical)
            End If

        End If

    End Sub


End Class
