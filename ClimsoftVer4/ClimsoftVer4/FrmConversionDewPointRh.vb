Public Class FrmConversionDewPointRh


    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim TT As Double, Tw As Double, dew_point As Double, RH As Double
        'On Error GoTo errhandler

        If Len(TT) > 0 And Len(Tw) > 0 Then
            TT = Val(drybuld.Text) / 10
            Tw = Val(wetbulb.Text) / 10

            If TT >= Tw Then
                If Not generate_dewpoint_and_rh(TT, Tw, dew_point, RH) Then Exit Sub
                dewpoint.Text = dew_point * 10
                humidity.Text = Val(RH)
            Else
                dewpoint.Text = ""
                humidity.Text = ""
                MsgBox("Wetbulb must be less than or equal to Drybulb !", vbCritical)
            End If
        Else
            dewpoint.Text = ""
            humidity.Text = ""
            MsgBox("Blank input not allowed !", vbCritical)
        End If
    End Sub
    Private Function generate_dewpoint_and_rh(TT As String, Tw As String, dew_point As String, RH As String) As Double
        On Error GoTo errhandler
        Dim Td_Fahrenheit As Object
        Dim Ed As Object
        Dim Tw_Fahrenheit As Object
        Dim Ew As Object
        Dim Ea As Object
        Dim Tp As Object
        Dim Tp_Fahrenheit As Object
        Dim Tp_Celcius As Object
        Dim svp1 As Object
        Dim svp2 As Object
        Dim Relative_Humidity As Object
        Dim invalid_dewpoint As Boolean

        generate_dewpoint_and_rh = False
        invalid_dewpoint = False
        ''''If Not (Val(Td) > 0 And Val(Tw) > 0) Then
        ''''   invalid_dewpoint = True
        ''''   Exit Function
        ''''End If
        'If Val(td) >= Val(Tw) Then
        Td_Fahrenheit = 9 / 5 * TT + 32
        Ed = 6.1078 * Math.Exp((9.5939 * [Td_Fahrenheit] - 307.004) / (0.556 * [Td_Fahrenheit] + 219.522))
        Tw_Fahrenheit = 9 / 5 * Tw + 32
        Ew = 6.1078 * Math.Exp((9.5939 * [Tw_Fahrenheit] - 307.004) / (0.556 * [Tw_Fahrenheit] + 219.522))
        Ea = [Ew] - 0.35 * ([Td_Fahrenheit] - [Tw_Fahrenheit])
        Tp_Fahrenheit = -1 * (Math.Log([Ea] / 6.1078) * 219.522 + 307.004) / (Math.Log([Ea] / 6.1078) * 0.556 - 9.59539)
        Tp_Celcius = 5 / 9 * ([Tp_Fahrenheit] - 32)
        svp1 = 6.11 * 10 ^ (7.5 * [Tp_Celcius] / (237.3 + [Tp_Celcius]))
        svp2 = 6.11 * 10 ^ (7.5 * [TT] / (237.3 + [TT]))

        dewpoint.Text = Math.Round(Tp_Celcius * 10, 0)
        'dewpoint.Text = Math.Round(Tp_Celcius, 1)
        humidity.Text = Math.Round(svp1 / svp2 * 100, 0)
        Return Math.Round(Val(dewpoint.Text))
        Return Math.Round(Val(humidity.Text))
        'Return Math.Round(dew_point, 1)
        'Return Math.Round(RH, 0)
        'Else
        '   MsgBox "Wetbulb must be less than or equal to Drybulb!", vbCritical
        'End If
        generate_dewpoint_and_rh = True
        Exit Function
errhandler:
        invalid_dewpoint = True
        If Err.Number = 5 Then
            Resume Next
        Else
            MsgBox("generate_dewpoint_and_rh " & Err.Number, vbExclamation)
        End If
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class