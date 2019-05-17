
﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>

Partial Class frmCharts
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.

    <System.Diagnostics.DebuggerNonUserCode()>

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()

        Me.Frame6 = New System.Windows.Forms.GroupBox()
        Me.txtchY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtchX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtchtitle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MSChart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.grpSummary = New System.Windows.Forms.GroupBox()
        Me.optAnnual = New System.Windows.Forms.RadioButton()
        Me.optMonthly = New System.Windows.Forms.RadioButton()
        Me.optDekadal = New System.Windows.Forms.RadioButton()
        Me.optDaily = New System.Windows.Forms.RadioButton()
        Me.cmdPlot = New System.Windows.Forms.Button()
        Me.comdSave = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.dlgChart = New System.Windows.Forms.SaveFileDialog()

    
        Me.cmdview = New System.Windows.Forms.Button()

        Me.Frame6.SuspendLayout()
        CType(Me.MSChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame1.SuspendLayout()
        Me.grpSummary.SuspendLayout()

        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()
        '
        'Frame6
        '
        Me.Frame6.Controls.Add(Me.txtchY)
        Me.Frame6.Controls.Add(Me.Label4)
        Me.Frame6.Controls.Add(Me.txtchX)
        Me.Frame6.Controls.Add(Me.Label3)
        Me.Frame6.Controls.Add(Me.txtchtitle)
        Me.Frame6.Controls.Add(Me.Label2)
        Me.Frame6.Location = New System.Drawing.Point(388, 17)
        Me.Frame6.Name = "Frame6"
        Me.Frame6.Size = New System.Drawing.Size(511, 110)
        Me.Frame6.TabIndex = 1
        Me.Frame6.TabStop = False
        Me.Frame6.Text = "Labels"
        '
        'txtchY
        '
        Me.txtchY.Location = New System.Drawing.Point(84, 74)
        Me.txtchY.Name = "txtchY"
        Me.txtchY.Size = New System.Drawing.Size(403, 20)
        Me.txtchY.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Y Axis Title"
        '
        'txtchX
        '
        Me.txtchX.Location = New System.Drawing.Point(84, 45)
        Me.txtchX.Name = "txtchX"
        Me.txtchX.Size = New System.Drawing.Size(403, 20)
        Me.txtchX.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "X Axis Title"
        '
        'txtchtitle
        '
        Me.txtchtitle.Location = New System.Drawing.Point(84, 19)
        Me.txtchtitle.Name = "txtchtitle"
        Me.txtchtitle.Size = New System.Drawing.Size(403, 20)
        Me.txtchtitle.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Chart Title"
        '
        'MSChart1
        '

        ChartArea2.Name = "ChartArea1"
        Me.MSChart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.MSChart1.Legends.Add(Legend2)
        Me.MSChart1.Location = New System.Drawing.Point(12, 3)
        Me.MSChart1.Name = "MSChart1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Single]
        Me.MSChart1.Series.Add(Series2)

        Me.MSChart1.Size = New System.Drawing.Size(959, 407)
        Me.MSChart1.TabIndex = 0
        Me.MSChart1.Text = "Chart1"
        '
        'Frame1
        '
        Me.Frame1.Controls.Add(Me.grpSummary)
        Me.Frame1.Controls.Add(Me.Frame6)
        Me.Frame1.Location = New System.Drawing.Point(12, 428)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Size = New System.Drawing.Size(942, 118)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Chart Options"
        '
        'grpSummary
        '
        Me.grpSummary.Controls.Add(Me.optAnnual)
        Me.grpSummary.Controls.Add(Me.optMonthly)
        Me.grpSummary.Controls.Add(Me.optDekadal)
        Me.grpSummary.Controls.Add(Me.optDaily)
        Me.grpSummary.Location = New System.Drawing.Point(47, 24)
        Me.grpSummary.Name = "grpSummary"
        Me.grpSummary.Size = New System.Drawing.Size(289, 87)
        Me.grpSummary.TabIndex = 2
        Me.grpSummary.TabStop = False
        Me.grpSummary.Text = "Data Summary Type"
        '
        'optAnnual
        '
        Me.optAnnual.AutoSize = True
        Me.optAnnual.Location = New System.Drawing.Point(118, 51)
        Me.optAnnual.Name = "optAnnual"
        Me.optAnnual.Size = New System.Drawing.Size(58, 17)
        Me.optAnnual.TabIndex = 3
        Me.optAnnual.Text = "Annual"
        Me.optAnnual.UseVisualStyleBackColor = True
        '
        'optMonthly
        '
        Me.optMonthly.AutoSize = True
        Me.optMonthly.Location = New System.Drawing.Point(118, 28)
        Me.optMonthly.Name = "optMonthly"
        Me.optMonthly.Size = New System.Drawing.Size(62, 17)
        Me.optMonthly.TabIndex = 2
        Me.optMonthly.Text = "Monthly"
        Me.optMonthly.UseVisualStyleBackColor = True
        '
        'optDekadal
        '
        Me.optDekadal.AutoSize = True
        Me.optDekadal.Location = New System.Drawing.Point(22, 51)
        Me.optDekadal.Name = "optDekadal"
        Me.optDekadal.Size = New System.Drawing.Size(65, 17)
        Me.optDekadal.TabIndex = 1
        Me.optDekadal.Text = "Dekadal"
        Me.optDekadal.UseVisualStyleBackColor = True
        '
        'optDaily
        '
        Me.optDaily.AutoSize = True
        Me.optDaily.Checked = True
        Me.optDaily.Location = New System.Drawing.Point(22, 28)
        Me.optDaily.Name = "optDaily"
        Me.optDaily.Size = New System.Drawing.Size(48, 17)
        Me.optDaily.TabIndex = 0
        Me.optDaily.TabStop = True
        Me.optDaily.Text = "Daily"
        Me.optDaily.UseVisualStyleBackColor = True
        '
        'cmdPlot
        '

        Me.cmdPlot.Location = New System.Drawing.Point(207, 557)

        Me.cmdPlot.Name = "cmdPlot"
        Me.cmdPlot.Size = New System.Drawing.Size(56, 24)
        Me.cmdPlot.TabIndex = 3
        Me.cmdPlot.Text = "Plot"
        Me.cmdPlot.UseVisualStyleBackColor = True
        '
        'comdSave
        '

        Me.comdSave.Location = New System.Drawing.Point(306, 557)

        Me.comdSave.Name = "comdSave"
        Me.comdSave.Size = New System.Drawing.Size(50, 24)
        Me.comdSave.TabIndex = 4
        Me.comdSave.Text = "Save"
        Me.comdSave.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '

        Me.cmdPrint.Location = New System.Drawing.Point(399, 557)

        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(50, 24)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'CmdClose
        '

        Me.CmdClose.Location = New System.Drawing.Point(492, 557)

        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(50, 24)
        Me.CmdClose.TabIndex = 6
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '

        Me.cmdHelp.Location = New System.Drawing.Point(701, 557)

        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(50, 24)
        Me.cmdHelp.TabIndex = 7
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '

        'cmdview
        '
        Me.cmdview.Enabled = False
        Me.cmdview.Location = New System.Drawing.Point(585, 557)
        Me.cmdview.Name = "cmdview"
        Me.cmdview.Size = New System.Drawing.Size(73, 24)
        Me.cmdview.TabIndex = 8
        Me.cmdview.Text = "Viewd Data"
        Me.cmdview.UseVisualStyleBackColor = True
        '

        'frmCharts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 590)

        Me.Controls.Add(Me.cmdview)

        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.comdSave)
        Me.Controls.Add(Me.cmdPlot)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.MSChart1)
        Me.Name = "frmCharts"
        Me.Text = "Graphic Charts"
        Me.Frame6.ResumeLayout(False)
        Me.Frame6.PerformLayout()
        CType(Me.MSChart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame1.ResumeLayout(False)
        Me.grpSummary.ResumeLayout(False)
        Me.grpSummary.PerformLayout()

        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Frame6 As GroupBox
    Friend WithEvents txtchY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtchX As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtchtitle As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents MSChart1 As DataVisualization.Charting.Chart
    Friend WithEvents Frame1 As GroupBox
    Friend WithEvents cmdPlot As Button
    Friend WithEvents grpSummary As GroupBox
    Friend WithEvents optAnnual As RadioButton
    Friend WithEvents optMonthly As RadioButton
    Friend WithEvents optDekadal As RadioButton
    Friend WithEvents optDaily As RadioButton
    Friend WithEvents comdSave As Button
    Friend WithEvents cmdPrint As Button
    Friend WithEvents CmdClose As Button
    Friend WithEvents cmdHelp As Button
    Friend WithEvents dlgChart As SaveFileDialog

    Friend WithEvents cmdview As Button

End Class
