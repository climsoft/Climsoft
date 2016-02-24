
Public Class frmProductsClimateObj
    Dim rInterface As New clsRInterface
    Dim sql As String
    Dim PosterPath As String = "C:\\"
    Private Sub btnMissingValues_Click(sender As Object, e As EventArgs) Handles btnMissingValues.Click
        Try
            'rInterface.createClimateObjectFromSQL(sql)
            rInterface.engine.Evaluate("CO$plot_missing_values_rain()")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnBoxplotAmounts_Click(sender As Object, e As EventArgs) Handles btnBoxplotAmounts.Click
        Try
            rInterface.engine.Evaluate(" CO$boxplot_method(interest_var = rain_label)")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDailySummary_Click(sender As Object, e As EventArgs) Handles btnDailySummary.Click
        Try
            rInterface.engine.Evaluate("CO$daily_summary_plot()")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnYearlySummary_Click(sender As Object, e As EventArgs) Handles btnYearlySummary.Click
        Try
            rInterface.engine.Evaluate("CO$plot_yearly_summary()")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRainDays_Click(sender As Object, e As EventArgs) Handles btnRainDays.Click
        Try
            rInterface.engine.Evaluate("CO$plot_yearly_rain_count()")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRainfallTotals_Click(sender As Object, e As EventArgs) Handles btnRainfallTotals.Click
        Try
            rInterface.engine.Evaluate("CO$plot_yearly_summary(interest_var = " & Chr(34) & "Total Rain" & Chr(34) & ")")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnThreeSummaries_Click(sender As Object, e As EventArgs) 
        Try
            rInterface.engine.Evaluate(" ")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRaindaysBoxplot_Click(sender As Object, e As EventArgs) Handles btnRaindaysBoxplot.Click
        Try
            'rInterface.engine.Evaluate(" CO$box_jitter(var = " & Chr(34) & "Number Of Rainy Days" & Chr(34) & ")")
            rInterface.engine.Evaluate("CO$box_jitter(var =" & Chr(34) & "Number of Rainy Days" & Chr(34) & ")")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdPoster_Click(sender As Object, e As EventArgs) Handles cmdPoster.Click
        'Try
        '    rInterface.engine.Evaluate("Sweave(" & Chr(34) & PosterPath & "ral.Rnw" & Chr(34) & ")")
        '    rInterface.engine.Evaluate("tools : :texi2pdf(" & Chr(34) & PosterPath & " ral.tex" & Chr(34) & ")")
        '    rInterface.engine.Evaluate("dev.copy2pdf(file = " & Chr(34) & PosterPath & " ral.pdf" & Chr(34) & ")")
        '    'rInterface.engine.Evaluate(" CO$box_jitter(var = " & Chr(34) & "Number Of Rainy Days" & Chr(34))
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
End Class