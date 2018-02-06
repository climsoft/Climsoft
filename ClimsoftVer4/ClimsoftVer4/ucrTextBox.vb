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

Public Class ucrTextBox
    Protected dcmMinimum As Decimal = Decimal.MinValue
    Protected dcmMaximum As Decimal = Decimal.MaxValue
    Protected bMinimumIncluded, bMaximumIncluded As Boolean
    Private bToUpper As Boolean = False
    Private bToLower As Boolean = False
    Private bFirstLoad As Boolean = True
    Protected bIsReadOnly As Boolean = False
    Protected strValidationType As String = "none"

    Public Overrides Sub PopulateControl()
        MyBase.PopulateControl()
        If dtbRecords.Rows.Count > 1 Then
            MessageBox.Show("Developer error: More than one value found for: " & Me.Name & ". A textbox should be linked to a single record. " & dtbRecords.Rows.Count & " records found.", caption:="Developer error")
        ElseIf dtbRecords.Columns.Count <> 1 Then
            MessageBox.Show("Developer error: A textbox must have exactly one field set. Control: " & Me.Name & "has " & dtbRecords.Columns.Count & " fields.", caption:="Developer error")
        Else
            If dtbRecords.Rows.Count = 0 Then
                TextboxValue = ""
            Else
                TextboxValue = dtbRecords.Rows(0).Field(Of String)(columnIndex:=0)
            End If
        End If
    End Sub

    Public Property TextboxValue() As String
        Get
            Return txtBox.Text
        End Get
        Set(ByVal strValue As String)
            txtBox.Text = strValue
        End Set
    End Property

    Public Sub SetTextToUpper()
        bToUpper = True
        bToLower = False
    End Sub

    Public Sub SetTextToLower()
        bToLower = True
        bToUpper = False
    End Sub

    Public Sub SetValidationTypeAsNone()
        strValidationType = "none"
    End Sub

    Public Sub SetValidationTypeAsNumeric(Optional dcmMin As Decimal = Decimal.MinValue, Optional bIncludeMin As Boolean = True, Optional dcmMax As Decimal = Decimal.MaxValue, Optional bIncludeMax As Boolean = True)
        strValidationType = "numeric"
        If dcmMin <> Decimal.MinValue Then
            dcmMinimum = dcmMin
            bMinimumIncluded = bIncludeMin
        End If
        If dcmMax <> Decimal.MaxValue Then
            dcmMaximum = dcmMax
            bMaximumIncluded = bIncludeMax
        End If
    End Sub

    'Returns integer as code for validation
    ' 0 : string is valid
    ' 1 : string is not numeric
    ' 2 : string is outside range
    Public Function ValidateNumeric(strText As String) As Integer
        Dim dcmText As Decimal
        Dim iType As Integer = 0

        If strText <> "" Then
            If Not IsNumeric(strText) Then
                iType = 1
            Else
                dcmText = Convert.ToDecimal(strText)
                If (dcmText < dcmMinimum) OrElse (dcmText > dcmMaximum) OrElse (Not bMinimumIncluded And dcmText <= dcmMinimum) OrElse (Not bMaximumIncluded And dcmText >= dcmMaximum) Then
                    iType = 2
                End If
            End If
        End If
        Return iType
    End Function

    Public Overrides Function ValidateValue() As Boolean
        Return (GetValidationCode(TextboxValue) = 0)
    End Function

    Public Function GetValidationCode(strText As String) As Integer
        Dim iType As Integer
        Select Case strValidationType
            Case "none"
                iType = 0
            Case "numeric"
                iType = ValidateNumeric(strText)
        End Select
        Return iType
    End Function

    Public Function ValidateText(strText As String) As Boolean
        Dim iValidationCode As Integer

        iValidationCode = GetValidationCode(strText)

        Select Case iValidationCode
            Case 0
                'this is for none. No validation
            Case 1
                Select Case strValidationType
                    Case "Numeric"
                        MsgBox("Entry must be numeric.", vbOKOnly)
                End Select
            Case 2
                Select Case strValidationType
                    Case "Numeric"
                        MsgBox("This number must be: " & GetNumericRange(), vbOKOnly)
                End Select


        End Select
        Return (iValidationCode = 0)

    End Function

    Public Function GetNumericRange() As String
        Dim strRange As String = ""
        If strValidationType = "numeric" Then
            If dcmMinimum <> Decimal.MinValue Then
                If bMinimumIncluded Then
                    strRange = ">= " & dcmMinimum.ToString()
                Else
                    strRange = "> " & dcmMinimum.ToString()
                End If
                If dcmMaximum <> Decimal.MaxValue Then
                    strRange = strRange & " and "
                End If
            End If
            If dcmMaximum <> Decimal.MaxValue Then
                If bMaximumIncluded Then
                    strRange = strRange & "<= " & dcmMaximum.ToString()
                Else
                    strRange = strRange & "< " & dcmMaximum.ToString()
                End If
            End If

        End If
        Return strRange
    End Function

    Private Sub ucrStationSelector_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then


            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged


      If bToLower Then
            TextboxValue = TextboxValue.ToLower()
        ElseIf bToUpper Then
            TextboxValue = TextboxValue.ToLower()
        End If
    End Sub

    Private Sub ucrTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBox.KeyDown
        OnevtKeyDown(sender, e)
    End Sub

    Private Sub ucrTextBox_Enter(sender As Object, e As EventArgs) Handles txtBox.Enter

    End Sub

    Public Sub GetFocus()
        txtBox.Focus()
    End Sub
    Public Function IsEmpty() As Boolean
        If TextboxValue.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub Clear()
        TextboxValue = ""
    End Sub


    Public Sub SetBackColor(backColor As Color)
        txtBox.BackColor = backColor
    End Sub

    Public Sub RemoveBackColor()
        txtBox.BackColor = Color.White
    End Sub

    Public Overrides Function GetValue() As Object
        Return TextboxValue
    End Function

    Public Overrides Sub UpdateInputValueToDataTable()
        If dtbRecords.Rows.Count = 0 Then
            dtbRecords.Rows.Add(TextboxValue)
        Else
            dtbRecords.Rows(0).Item(0) = TextboxValue
        End If

    End Sub
End Class
