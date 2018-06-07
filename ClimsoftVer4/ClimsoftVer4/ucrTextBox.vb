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
    Public bValidate As Boolean = True
    Public bValidateSilently As Boolean = True
    Public bValidateEmpty As Boolean = False

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            If dtbRecords.Rows.Count > 1 Then
                MessageBox.Show("Developer error: More than one value found for: " & Me.Name & ". A textbox should be linked to a single record. " & dtbRecords.Rows.Count & " records found.", caption:="Developer error")
            ElseIf dtbRecords.Columns.Count <> 1 Then
                MessageBox.Show("Developer error: A textbox must have exactly one field set. Control: " & Me.Name & "has " & dtbRecords.Columns.Count & " fields.", caption:="Developer error")
            Else
                bValidate = False
                If dtbRecords.Rows.Count = 0 Then
                    TextboxValue = ""
                Else
                    TextboxValue = dtbRecords.Rows(0).Field(Of String)(columnIndex:=0)
                End If
                TextHandling(Me, New EventArgs)
                bValidate = True
            End If
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        Dim strNewValue As String

        strNewValue = TryCast(objNewValue, String)
        TextboxValue = strNewValue
        OnevtValueChanged(Me, Nothing)
    End Sub

    ' TODO This shouldn't be used. We should be use the general SetValue() method.
    ' This can be kept but made private if needed.
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
    ''' <summary>
    ''' Sets validation of the textbox to none
    ''' </summary>
    Public Sub SetValidationTypeAsNone()
        strValidationType = "none"
    End Sub
    ''' <summary>
    ''' Sets validation of the textbox to numeric
    ''' </summary>
    ''' <param name="dcmMin"></param>
    ''' <param name="bIncludeMin"></param>
    ''' <param name="dcmMax"></param>
    ''' <param name="bIncludeMax"></param>
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
        Else
            iType = 1
        End If
        Return iType
    End Function

    'Public Overrides Function ValidateValue() As Boolean
    '    Return (GetValidationCode(TextboxValue) = 0)
    'End Function

    Public Overrides Function ValidateValue() As Boolean
        Dim iType As Integer

        If Not bValidateEmpty AndAlso IsEmpty() Then
            SetBackColor(Color.White)
            Return True
        End If

        iType = GetValidationCode(GetValue)
        If iType = 0 Then
            SetBackColor(Color.White)
        ElseIf iType = 1
            SetBackColor(Color.Red)
            If Not bValidateSilently Then
                MsgBox("Number expected!", MsgBoxStyle.Critical)
            End If
        ElseIf iType = 2
            'check if it was lower and upper limit violation
            If Not (GetDcmMinimum() <= Val(GetValue)) Then
                SetBackColor(Color.Cyan)
                If Not bValidateSilently Then
                    MsgBox("Value lower than lowerlimit of: " & GetDcmMinimum(), MsgBoxStyle.Exclamation)
                End If
            ElseIf Not (GetDcmMaximum() >= Val(GetValue))
                SetBackColor(Color.Cyan)
                If Not bValidateSilently Then
                    MsgBox("Value higher than upperlimit of: " & GetDcmMaximum(), MsgBoxStyle.Exclamation)
                End If
            End If
        End If
        Return (iType = 0)
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
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="strText"></param>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Returns the numeric range for the control
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Returns the minimum decimal number for the control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDcmMinimum() As Decimal
        Return dcmMinimum
    End Function
    ''' <summary>
    ''' Returns the maximum decimal number for the control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetDcmMaximum() As Decimal
        Return dcmMaximum
    End Function

    Protected Overridable Sub ucrTextBox_Load(sender As Object, e As EventArgs) Handles Me.Load

        If bFirstLoad Then
            bFirstLoad = False
        End If
    End Sub

    Private Sub ucrTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBox.KeyDown
        OnevtKeyDown(sender, e)
    End Sub

    Private Sub ucrTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtBox.TextChanged

        TextHandling(sender, e)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub TextHandling(sender As Object, e As EventArgs)

        'check if value is or not new
        'If dtbRecords.Rows.Count = 1 Then
        'If TextboxValue = dtbRecords.Rows(0).Field(Of String)(columnIndex:=0) Then
        'value same as original
        ' SetBackColor(Color.LightGreen)
        ' Else
        'value different from the original
        ''SetBackColor(Color.Orange)
        'End If
        ' Else
        'new value
        'SetBackColor(Color.White)
        ' End If

        'check if value is valid
        'If bValidate AndAlso Not ValidateValue() Then
        '  SetBackColor(Color.Red)
        'End If

        'check if value is valid
        If bValidate Then
            ValidateValue()
        End If

        'change the case appropriately
        ChangeCase()

        'raise event
        OnevtTextChanged(sender, e)

    End Sub
    ''' <summary>
    ''' Sets the focus to the control 
    ''' </summary>
    Public Sub GetFocus()
        txtBox.Focus()
    End Sub
    ''' <summary>
    ''' Checks if a textbox is empty
    ''' Returns true when text box is empty
    ''' </summary>
    ''' <returns></returns>
    Public Function IsEmpty() As Boolean
        If TextboxValue.Length > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    ''' <summary>
    ''' Clears contents of the textbox
    ''' </summary>
    Public Overrides Sub Clear()
        bValidate = False
        TextboxValue = ""
        SetBackColor(Color.White)
        bValidate = True
    End Sub
    ''' <summary>
    ''' Sets the back colour of the control
    ''' </summary>
    ''' <param name="backColor"></param>
    Public Sub SetBackColor(backColor As Color)
        txtBox.BackColor = backColor
    End Sub
    ''' <summary>
    ''' Returns converted text either to lower or upper case
    ''' </summary>
    Public Sub ChangeCase()
        If bToLower Then
            TextboxValue = TextboxValue.ToLower()
        ElseIf bToUpper Then
            TextboxValue = TextboxValue.ToUpper()
        End If
    End Sub
    ''' <summary>
    ''' Returns the value of the textbox
    ''' </summary>
    ''' <param name="strFieldName"></param>
    ''' <returns></returns>
    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        Return TextboxValue
    End Function

    Public Overrides Sub UpdateInputValueToDataTable()
        If dtbRecords.Rows.Count = 0 Then
            dtbRecords.Rows.Add(TextboxValue)
        Else
            dtbRecords.Rows(0).Item(0) = TextboxValue
        End If

    End Sub

    Private Sub ucrTextBox_Leave(sender As Object, e As EventArgs) Handles txtBox.Leave
        OnevtValueChanged(Me, e)
    End Sub
    ''' <summary>
    '''Sets the textbox as a read only 
    ''' </summary>
    Public Sub SetAsReadOnly()
        txtBox.ReadOnly = True
    End Sub
    ''' <summary>
    ''' Sets the size of the texbox in the control
    ''' </summary>
    ''' <param name="Size"></param>
    Public Sub SetElementValueSize(Size As Point)
        txtBox.Size = New Size(Size)
    End Sub
End Class
