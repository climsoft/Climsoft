<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductsClimateObj
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnBoxplotAmounts = New System.Windows.Forms.Button()
        Me.btnMissingValues = New System.Windows.Forms.Button()
        Me.btnDailySummary = New System.Windows.Forms.Button()
        Me.btnYearlySummary = New System.Windows.Forms.Button()
        Me.btnRainDays = New System.Windows.Forms.Button()
        Me.btnRainfallTotals = New System.Windows.Forms.Button()
        Me.btnRaindaysBoxplot = New System.Windows.Forms.Button()
        Me.cmdPoster = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBoxplotAmounts
        '
        Me.btnBoxplotAmounts.Location = New System.Drawing.Point(42, 13)
        Me.btnBoxplotAmounts.Name = "btnBoxplotAmounts"
        Me.btnBoxplotAmounts.Size = New System.Drawing.Size(173, 23)
        Me.btnBoxplotAmounts.TabIndex = 0
        Me.btnBoxplotAmounts.Tag = "Boxplot_Amounts"
        Me.btnBoxplotAmounts.Text = "Boxplot Amounts"
        Me.btnBoxplotAmounts.UseVisualStyleBackColor = True
        '
        'btnMissingValues
        '
        Me.btnMissingValues.Location = New System.Drawing.Point(42, 42)
        Me.btnMissingValues.Name = "btnMissingValues"
        Me.btnMissingValues.Size = New System.Drawing.Size(173, 23)
        Me.btnMissingValues.TabIndex = 1
        Me.btnMissingValues.Tag = "Missing_Values"
        Me.btnMissingValues.Text = "Missing Values "
        Me.btnMissingValues.UseVisualStyleBackColor = True
        '
        'btnDailySummary
        '
        Me.btnDailySummary.Location = New System.Drawing.Point(42, 71)
        Me.btnDailySummary.Name = "btnDailySummary"
        Me.btnDailySummary.Size = New System.Drawing.Size(173, 23)
        Me.btnDailySummary.TabIndex = 2
        Me.btnDailySummary.Tag = "Daily_Summary"
        Me.btnDailySummary.Text = "Daily Summary"
        Me.btnDailySummary.UseVisualStyleBackColor = True
        '
        'btnYearlySummary
        '
        Me.btnYearlySummary.Location = New System.Drawing.Point(42, 100)
        Me.btnYearlySummary.Name = "btnYearlySummary"
        Me.btnYearlySummary.Size = New System.Drawing.Size(173, 23)
        Me.btnYearlySummary.TabIndex = 3
        Me.btnYearlySummary.Tag = "Yearly_Summary"
        Me.btnYearlySummary.Text = "Yearly Summary"
        Me.btnYearlySummary.UseVisualStyleBackColor = True
        '
        'btnRainDays
        '
        Me.btnRainDays.Location = New System.Drawing.Point(42, 129)
        Me.btnRainDays.Name = "btnRainDays"
        Me.btnRainDays.Size = New System.Drawing.Size(173, 23)
        Me.btnRainDays.TabIndex = 4
        Me.btnRainDays.Tag = "Rain_Days"
        Me.btnRainDays.Text = "Rain Days"
        Me.btnRainDays.UseVisualStyleBackColor = True
        '
        'btnRainfallTotals
        '
        Me.btnRainfallTotals.Location = New System.Drawing.Point(42, 160)
        Me.btnRainfallTotals.Name = "btnRainfallTotals"
        Me.btnRainfallTotals.Size = New System.Drawing.Size(173, 23)
        Me.btnRainfallTotals.TabIndex = 5
        Me.btnRainfallTotals.Tag = "Rainfall_Totals"
        Me.btnRainfallTotals.Text = "Rainfall Totals"
        Me.btnRainfallTotals.UseVisualStyleBackColor = True
        '
        'btnRaindaysBoxplot
        '
        Me.btnRaindaysBoxplot.Location = New System.Drawing.Point(42, 189)
        Me.btnRaindaysBoxplot.Name = "btnRaindaysBoxplot"
        Me.btnRaindaysBoxplot.Size = New System.Drawing.Size(173, 23)
        Me.btnRaindaysBoxplot.TabIndex = 7
        Me.btnRaindaysBoxplot.Tag = "Raindays_Boxplot"
        Me.btnRaindaysBoxplot.Text = "Raindays Boxplot"
        Me.btnRaindaysBoxplot.UseVisualStyleBackColor = True
        '
        'cmdPoster
        '
        Me.cmdPoster.Location = New System.Drawing.Point(42, 218)
        Me.cmdPoster.Name = "cmdPoster"
        Me.cmdPoster.Size = New System.Drawing.Size(173, 23)
        Me.cmdPoster.TabIndex = 8
        Me.cmdPoster.Tag = "Poster"
        Me.cmdPoster.Text = "Poster"
        Me.cmdPoster.UseVisualStyleBackColor = True
        '
        'frmProductsClimateObj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 315)
        Me.Controls.Add(Me.cmdPoster)
        Me.Controls.Add(Me.btnRaindaysBoxplot)
        Me.Controls.Add(Me.btnRainfallTotals)
        Me.Controls.Add(Me.btnRainDays)
        Me.Controls.Add(Me.btnYearlySummary)
        Me.Controls.Add(Me.btnDailySummary)
        Me.Controls.Add(Me.btnMissingValues)
        Me.Controls.Add(Me.btnBoxplotAmounts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductsClimateObj"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "ProductsClimateObj"
        Me.Text = "Products ClimateObj"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBoxplotAmounts As Button
    Friend WithEvents btnMissingValues As Button
    Friend WithEvents btnDailySummary As Button
    Friend WithEvents btnYearlySummary As Button
    Friend WithEvents btnRainDays As Button
    Friend WithEvents btnRainfallTotals As Button
    Friend WithEvents btnRaindaysBoxplot As Button
    Friend WithEvents cmdPoster As Button
End Class
