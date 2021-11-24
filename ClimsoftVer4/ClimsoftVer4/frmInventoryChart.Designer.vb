<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryChart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.chartInventory = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.cmdview = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.cmdPrint = New System.Windows.Forms.Button()
        Me.comdSave = New System.Windows.Forms.Button()
        Me.grpColors = New System.Windows.Forms.GroupBox()
        Me.lstSeries = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblYinterval = New System.Windows.Forms.Label()
        Me.butYinterval = New System.Windows.Forms.Button()
        Me.txtYinterval = New System.Windows.Forms.TextBox()
        Me.lblXinterval = New System.Windows.Forms.Label()
        Me.butXinterval = New System.Windows.Forms.Button()
        Me.txtXinterval = New System.Windows.Forms.TextBox()
        Me.lblSettings = New System.Windows.Forms.Label()
        CType(Me.chartInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpColors.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chartInventory
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartInventory.ChartAreas.Add(ChartArea1)
        Legend1.AutoFitMinFontSize = 6
        Legend1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Legend1.TitleAlignment = System.Drawing.StringAlignment.Far
        Me.chartInventory.Legends.Add(Legend1)
        Me.chartInventory.Location = New System.Drawing.Point(12, 12)
        Me.chartInventory.Name = "chartInventory"
        Me.chartInventory.Size = New System.Drawing.Size(1029, 380)
        Me.chartInventory.TabIndex = 0
        '
        'cmdview
        '
        Me.cmdview.Enabled = False
        Me.cmdview.Location = New System.Drawing.Point(529, 438)
        Me.cmdview.Name = "cmdview"
        Me.cmdview.Size = New System.Drawing.Size(73, 24)
        Me.cmdview.TabIndex = 13
        Me.cmdview.Text = "View Data"
        Me.cmdview.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(636, 438)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(50, 24)
        Me.cmdHelp.TabIndex = 12
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'CmdClose
        '
        Me.CmdClose.Location = New System.Drawing.Point(720, 438)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(50, 24)
        Me.CmdClose.TabIndex = 11
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(445, 438)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(50, 24)
        Me.cmdPrint.TabIndex = 10
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'comdSave
        '
        Me.comdSave.Location = New System.Drawing.Point(361, 438)
        Me.comdSave.Name = "comdSave"
        Me.comdSave.Size = New System.Drawing.Size(51, 24)
        Me.comdSave.TabIndex = 9
        Me.comdSave.Text = "Save"
        Me.comdSave.UseVisualStyleBackColor = True
        '
        'grpColors
        '
        Me.grpColors.Controls.Add(Me.lstSeries)
        Me.grpColors.Location = New System.Drawing.Point(1059, 280)
        Me.grpColors.Name = "grpColors"
        Me.grpColors.Size = New System.Drawing.Size(107, 119)
        Me.grpColors.TabIndex = 14
        Me.grpColors.TabStop = False
        Me.grpColors.Text = "Series Colours"
        '
        'lstSeries
        '
        Me.lstSeries.FormattingEnabled = True
        Me.lstSeries.Location = New System.Drawing.Point(4, 17)
        Me.lstSeries.Name = "lstSeries"
        Me.lstSeries.Size = New System.Drawing.Size(101, 95)
        Me.lstSeries.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.lblYinterval)
        Me.GroupBox1.Controls.Add(Me.butYinterval)
        Me.GroupBox1.Controls.Add(Me.txtYinterval)
        Me.GroupBox1.Controls.Add(Me.lblXinterval)
        Me.GroupBox1.Controls.Add(Me.butXinterval)
        Me.GroupBox1.Controls.Add(Me.txtXinterval)
        Me.GroupBox1.Location = New System.Drawing.Point(1066, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(99, 147)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Axis Intervals"
        '
        'lblYinterval
        '
        Me.lblYinterval.AutoSize = True
        Me.lblYinterval.Location = New System.Drawing.Point(12, 91)
        Me.lblYinterval.Name = "lblYinterval"
        Me.lblYinterval.Size = New System.Drawing.Size(36, 13)
        Me.lblYinterval.TabIndex = 5
        Me.lblYinterval.Text = "Y Axis"
        '
        'butYinterval
        '
        Me.butYinterval.Location = New System.Drawing.Point(52, 107)
        Me.butYinterval.Name = "butYinterval"
        Me.butYinterval.Size = New System.Drawing.Size(38, 22)
        Me.butYinterval.TabIndex = 4
        Me.butYinterval.Text = "Set"
        Me.butYinterval.UseVisualStyleBackColor = True
        '
        'txtYinterval
        '
        Me.txtYinterval.Location = New System.Drawing.Point(9, 108)
        Me.txtYinterval.Name = "txtYinterval"
        Me.txtYinterval.Size = New System.Drawing.Size(47, 20)
        Me.txtYinterval.TabIndex = 3
        '
        'lblXinterval
        '
        Me.lblXinterval.AutoSize = True
        Me.lblXinterval.Location = New System.Drawing.Point(11, 23)
        Me.lblXinterval.Name = "lblXinterval"
        Me.lblXinterval.Size = New System.Drawing.Size(36, 13)
        Me.lblXinterval.TabIndex = 2
        Me.lblXinterval.Text = "X Axis"
        '
        'butXinterval
        '
        Me.butXinterval.Location = New System.Drawing.Point(51, 39)
        Me.butXinterval.Name = "butXinterval"
        Me.butXinterval.Size = New System.Drawing.Size(38, 22)
        Me.butXinterval.TabIndex = 1
        Me.butXinterval.Text = "Set"
        Me.butXinterval.UseVisualStyleBackColor = True
        '
        'txtXinterval
        '
        Me.txtXinterval.Location = New System.Drawing.Point(8, 40)
        Me.txtXinterval.Name = "txtXinterval"
        Me.txtXinterval.Size = New System.Drawing.Size(47, 20)
        Me.txtXinterval.TabIndex = 0
        '
        'lblSettings
        '
        Me.lblSettings.AutoSize = True
        Me.lblSettings.Location = New System.Drawing.Point(1066, 42)
        Me.lblSettings.Name = "lblSettings"
        Me.lblSettings.Size = New System.Drawing.Size(98, 13)
        Me.lblSettings.TabIndex = 16
        Me.lblSettings.Text = "Chart Area Settings"
        '
        'frmInventoryChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 467)
        Me.Controls.Add(Me.lblSettings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpColors)
        Me.Controls.Add(Me.cmdview)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.CmdClose)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.comdSave)
        Me.Controls.Add(Me.chartInventory)
        Me.Name = "frmInventoryChart"
        Me.Text = "Inventory Chart"
        CType(Me.chartInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpColors.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chartInventory As DataVisualization.Charting.Chart
    Friend WithEvents cmdview As Button
    Friend WithEvents cmdHelp As Button
    Friend WithEvents CmdClose As Button
    Friend WithEvents cmdPrint As Button
    Friend WithEvents comdSave As Button
    Friend WithEvents grpColors As GroupBox
    Friend WithEvents lstSeries As ListBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblYinterval As Label
    Friend WithEvents butYinterval As Button
    Friend WithEvents txtYinterval As TextBox
    Friend WithEvents lblXinterval As Label
    Friend WithEvents butXinterval As Button
    Friend WithEvents txtXinterval As TextBox
    Friend WithEvents lblSettings As Label
End Class
