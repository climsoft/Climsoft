Public Class ucrDatePicker
    Private bFirstLoad As Boolean = True
    Private strValueReturnType As String 'default is string. supports only 2 return types String and Date
    Private strDateFormat As String  'default is no format. Other e.g dd/mm/yyyy , mm/dd/yyyy, yyyy-MM-dd , yyyy-MM-dd HH:mm tt

    Protected Overridable Sub ucrDatePicker_Load(sender As Object, e As EventArgs) Handles Me.Load
        If bFirstLoad Then
            SetDateFormat("") 'Default is not format (empty).
            SetValueReturnTypeAsString() 'Default is getvalue return type is string.
            'TODO determine the default date format?
            'dtpDate.Format = DateFormat.LongDate
            'dtpDate.Value = Date.Today 
            bFirstLoad = False
        End If
    End Sub

    Private Sub dtpDate_CloseUp(sender As Object, e As EventArgs) Handles dtpDate.CloseUp
        SetValue(dtpDate.Value)
    End Sub

    Private Sub dtpDatetxtDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown, txtDate.KeyDown
        OnevtKeyDown(Me, e)
    End Sub

    Private Sub txtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        If ValidateValue() Then
            SetValue(txtDate.Text)
        End If
        OnevtValueChanged(Me, e)
    End Sub

    Public Overrides Sub PopulateControl()
        If Not bFirstLoad Then
            MyBase.PopulateControl()
            'TODO
        End If
    End Sub

    Public Overrides Sub SetValue(objNewValue As Object)
        If IsDBNull(objNewValue) OrElse IsNothing(objNewValue) OrElse (TypeOf objNewValue Is String AndAlso String.IsNullOrWhiteSpace(objNewValue)) Then
            txtDate.Text = ""
        Else
            Try
                If TypeOf objNewValue Is DateTime Then
                    dtpDate.Value = objNewValue
                    txtDate.Text = If(strDateFormat = "", dtpDate.Value, dtpDate.Value.ToString(strDateFormat))
                Else
                    If strDateFormat = "" Then
                        'will use the systems default date format
                        dtpDate.Value = DateTime.Parse(objNewValue)
                        txtDate.Text = dtpDate.Value
                    Else
                        'use specified date format
                        dtpDate.Value = DateTime.ParseExact(objNewValue, strDateFormat, Nothing)
                        txtDate.Text = dtpDate.Value.ToString(strDateFormat)
                    End If
                End If
            Catch ex As Exception
                txtDate.Text = ""
            End Try
        End If

        OnevtValueChanged(Me, Nothing)
    End Sub

    Public Overrides Function GetValue(Optional strFieldName As String = "") As Object
        If String.IsNullOrWhiteSpace(txtDate.Text) Then
            Return Nothing
        Else
            If strValueReturnType = "date" Then
                If strDateFormat = "" Then
                    Return DateTime.Parse(txtDate.Text)
                Else
                    Return DateTime.ParseExact(txtDate.Text, strDateFormat, Nothing)
                End If
                'Return dtpDate.Value
            Else
                'return date in string format
                Return txtDate.Text
            End If
        End If
    End Function

    Public Overrides Function ValidateValue() As Boolean
        Dim bValid As Boolean = False

        If bValidate Then
            'if set to not validate empty values and textbox is empty then don't proceed with validation
            If Not bValidateEmpty AndAlso IsEmpty() Then
                SetBackColor(bValidColor)
                Return True
            End If

            Try
                Dim dte As DateTime
                If strDateFormat = "" Then
                    dte = DateTime.Parse(txtDate.Text)
                Else
                    dte = DateTime.ParseExact(txtDate.Text, strDateFormat, Nothing)
                End If
                bValid = True
            Catch ex As Exception
                bValid = False
            End Try
        Else
            bValid = True
        End If

        SetBackColor(If(bValid, bValidColor, bInValidColor))
        Return bValid
    End Function

    Public Function ValidateText(strText As String, Optional bValidateSilently As Boolean = True) As Boolean
        Dim bValid As Boolean = False

        If bValidate Then
            'if set to not validate empty values and string is empty then don't proceed with validation
            If Not bValidateEmpty AndAlso String.IsNullOrEmpty(strText) Then
                Return True
            End If

            Try
                Dim dte As DateTime
                If strDateFormat = "" Then
                    dte = DateTime.Parse(strText)
                Else
                    dte = DateTime.ParseExact(strText, strDateFormat, Nothing)
                End If
                bValid = True
            Catch ex As Exception
                bValid = False
            End Try
        Else
            bValid = True
        End If
        Return bValid
    End Function

    Public Overrides Sub Clear()
        'Dim bPrevValidate As Boolean = bValidate
        'bValidate = False
        SetValue("") 'TODO
        SetBackColor(bValidColor)
        'bValidate = bPrevValidate
    End Sub

    Public Overrides Sub SetBackColor(backColor As Color)
        txtDate.BackColor = backColor
    End Sub

    Public Function IsEmpty() As Boolean
        Return String.IsNullOrEmpty(txtDate.Text)
    End Function

    Public Sub SetDateFormat(strNewDateFormat As String)
        strDateFormat = strNewDateFormat
    End Sub

    Public Sub SetValueReturnTypeAsString()
        strValueReturnType = "string"
    End Sub

    Public Sub SetValueReturnTypeAsDate()
        strValueReturnType = "date"
    End Sub


End Class
