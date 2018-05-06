<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifyObservations
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
        Me.DataGridViewObservations = New System.Windows.Forms.DataGridView()
        Me.GrBxSelection = New System.Windows.Forms.GroupBox()
        Me.txtEndMonth = New System.Windows.Forms.TextBox()
        Me.txtStartMonth = New System.Windows.Forms.TextBox()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtStartYear = New System.Windows.Forms.TextBox()
        Me.txtElement = New System.Windows.Forms.TextBox()
        Me.txtStation = New System.Windows.Forms.TextBox()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.lblStartMonth = New System.Windows.Forms.Label()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.lblStartYear = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblSation = New System.Windows.Forms.Label()
        Me.GrBxCommands = New System.Windows.Forms.GroupBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdUpade = New System.Windows.Forms.Button()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.GrBxDataBase = New System.Windows.Forms.GroupBox()
        Me.optFinal = New System.Windows.Forms.RadioButton()
        Me.optInitial = New System.Windows.Forms.RadioButton()
        Me.lblrecords = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridViewObservations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrBxSelection.SuspendLayout()
        Me.GrBxCommands.SuspendLayout()
        Me.GrBxDataBase.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewObservations
        '
        Me.DataGridViewObservations.AllowDrop = True
        Me.DataGridViewObservations.AllowUserToAddRows = False
        Me.DataGridViewObservations.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridViewObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewObservations.Location = New System.Drawing.Point(12, 108)
        Me.DataGridViewObservations.Name = "DataGridViewObservations"
        Me.DataGridViewObservations.Size = New System.Drawing.Size(1104, 468)
        Me.DataGridViewObservations.TabIndex = 0
        '
        'GrBxSelection
        '
        Me.GrBxSelection.Controls.Add(Me.txtEndMonth)
        Me.GrBxSelection.Controls.Add(Me.txtStartMonth)
        Me.GrBxSelection.Controls.Add(Me.txtEndYear)
        Me.GrBxSelection.Controls.Add(Me.txtStartYear)
        Me.GrBxSelection.Controls.Add(Me.txtElement)
        Me.GrBxSelection.Controls.Add(Me.txtStation)
        Me.GrBxSelection.Controls.Add(Me.lblEndMonth)
        Me.GrBxSelection.Controls.Add(Me.lblStartMonth)
        Me.GrBxSelection.Controls.Add(Me.lblEndYear)
        Me.GrBxSelection.Controls.Add(Me.lblStartYear)
        Me.GrBxSelection.Controls.Add(Me.lblElement)
        Me.GrBxSelection.Controls.Add(Me.lblSation)
        Me.GrBxSelection.Location = New System.Drawing.Point(167, 20)
        Me.GrBxSelection.Name = "GrBxSelection"
        Me.GrBxSelection.Size = New System.Drawing.Size(529, 78)
        Me.GrBxSelection.TabIndex = 4
        Me.GrBxSelection.TabStop = False
        Me.GrBxSelection.Text = "Records Selection"
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(480, 48)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(30, 20)
        Me.txtEndMonth.TabIndex = 11
        Me.txtEndMonth.Text = "12"
        '
        'txtStartMonth
        '
        Me.txtStartMonth.Location = New System.Drawing.Point(480, 17)
        Me.txtStartMonth.Name = "txtStartMonth"
        Me.txtStartMonth.Size = New System.Drawing.Size(30, 20)
        Me.txtStartMonth.TabIndex = 10
        Me.txtStartMonth.Text = "1"
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(345, 48)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(46, 20)
        Me.txtEndYear.TabIndex = 9
        '
        'txtStartYear
        '
        Me.txtStartYear.Location = New System.Drawing.Point(345, 17)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(46, 20)
        Me.txtStartYear.TabIndex = 8
        '
        'txtElement
        '
        Me.txtElement.Location = New System.Drawing.Point(95, 48)
        Me.txtElement.Name = "txtElement"
        Me.txtElement.Size = New System.Drawing.Size(142, 20)
        Me.txtElement.TabIndex = 7
        '
        'txtStation
        '
        Me.txtStation.Location = New System.Drawing.Point(95, 17)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(142, 20)
        Me.txtStation.TabIndex = 6
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(412, 51)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 5
        Me.lblEndMonth.Text = "End Month"
        '
        'lblStartMonth
        '
        Me.lblStartMonth.AutoSize = True
        Me.lblStartMonth.Location = New System.Drawing.Point(412, 21)
        Me.lblStartMonth.Name = "lblStartMonth"
        Me.lblStartMonth.Size = New System.Drawing.Size(62, 13)
        Me.lblStartMonth.TabIndex = 4
        Me.lblStartMonth.Text = "Start Month"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(285, 52)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(51, 13)
        Me.lblEndYear.TabIndex = 3
        Me.lblEndYear.Text = "End Year"
        '
        'lblStartYear
        '
        Me.lblStartYear.AutoSize = True
        Me.lblStartYear.Location = New System.Drawing.Point(285, 21)
        Me.lblStartYear.Name = "lblStartYear"
        Me.lblStartYear.Size = New System.Drawing.Size(54, 13)
        Me.lblStartYear.TabIndex = 2
        Me.lblStartYear.Text = "Start Year"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(16, 52)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(73, 13)
        Me.lblElement.TabIndex = 1
        Me.lblElement.Text = "Element Code"
        '
        'lblSation
        '
        Me.lblSation.AutoSize = True
        Me.lblSation.Location = New System.Drawing.Point(16, 21)
        Me.lblSation.Name = "lblSation"
        Me.lblSation.Size = New System.Drawing.Size(52, 13)
        Me.lblSation.TabIndex = 0
        Me.lblSation.Text = "Station Id"
        '
        'GrBxCommands
        '
        Me.GrBxCommands.Controls.Add(Me.Button1)
        Me.GrBxCommands.Controls.Add(Me.cmdClose)
        Me.GrBxCommands.Controls.Add(Me.cmdDelete)
        Me.GrBxCommands.Controls.Add(Me.cmdUpade)
        Me.GrBxCommands.Controls.Add(Me.cmdView)
        Me.GrBxCommands.Location = New System.Drawing.Point(707, 30)
        Me.GrBxCommands.Name = "GrBxCommands"
        Me.GrBxCommands.Size = New System.Drawing.Size(368, 58)
        Me.GrBxCommands.TabIndex = 5
        Me.GrBxCommands.TabStop = False
        Me.GrBxCommands.Text = "Commands"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(219, 24)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(57, 23)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(151, 24)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(57, 23)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpade
        '
        Me.cmdUpade.Enabled = False
        Me.cmdUpade.Location = New System.Drawing.Point(83, 24)
        Me.cmdUpade.Name = "cmdUpade"
        Me.cmdUpade.Size = New System.Drawing.Size(57, 23)
        Me.cmdUpade.TabIndex = 1
        Me.cmdUpade.Text = "Update"
        Me.cmdUpade.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(15, 24)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(57, 23)
        Me.cmdView.TabIndex = 0
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'GrBxDataBase
        '
        Me.GrBxDataBase.Controls.Add(Me.optFinal)
        Me.GrBxDataBase.Controls.Add(Me.optInitial)
        Me.GrBxDataBase.Location = New System.Drawing.Point(29, 20)
        Me.GrBxDataBase.Name = "GrBxDataBase"
        Me.GrBxDataBase.Size = New System.Drawing.Size(125, 78)
        Me.GrBxDataBase.TabIndex = 6
        Me.GrBxDataBase.TabStop = False
        Me.GrBxDataBase.Text = "Databases"
        '
        'optFinal
        '
        Me.optFinal.AutoSize = True
        Me.optFinal.Location = New System.Drawing.Point(11, 46)
        Me.optFinal.Name = "optFinal"
        Me.optFinal.Size = New System.Drawing.Size(107, 17)
        Me.optFinal.TabIndex = 5
        Me.optFinal.Text = "Observation Final"
        Me.optFinal.UseVisualStyleBackColor = True
        '
        'optInitial
        '
        Me.optInitial.AutoSize = True
        Me.optInitial.Checked = True
        Me.optInitial.Location = New System.Drawing.Point(11, 23)
        Me.optInitial.Name = "optInitial"
        Me.optInitial.Size = New System.Drawing.Size(109, 17)
        Me.optInitial.TabIndex = 4
        Me.optInitial.TabStop = True
        Me.optInitial.Text = "Observation Initial"
        Me.optInitial.UseVisualStyleBackColor = True
        '
        'lblrecords
        '
        Me.lblrecords.AutoSize = True
        Me.lblrecords.Location = New System.Drawing.Point(518, 93)
        Me.lblrecords.Name = "lblrecords"
        Me.lblrecords.Size = New System.Drawing.Size(0, 13)
        Me.lblrecords.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(287, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Help"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmModifyObservations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1128, 588)
        Me.Controls.Add(Me.lblrecords)
        Me.Controls.Add(Me.GrBxDataBase)
        Me.Controls.Add(Me.GrBxCommands)
        Me.Controls.Add(Me.GrBxSelection)
        Me.Controls.Add(Me.DataGridViewObservations)
        Me.Name = "frmModifyObservations"
        Me.Text = "Update Observations"
        CType(Me.DataGridViewObservations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrBxSelection.ResumeLayout(False)
        Me.GrBxSelection.PerformLayout()
        Me.GrBxCommands.ResumeLayout(False)
        Me.GrBxDataBase.ResumeLayout(False)
        Me.GrBxDataBase.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewObservations As System.Windows.Forms.DataGridView
    Friend WithEvents GrBxSelection As System.Windows.Forms.GroupBox
    Friend WithEvents txtEndMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtStartMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents txtStartYear As System.Windows.Forms.TextBox
    Friend WithEvents txtElement As System.Windows.Forms.TextBox
    Friend WithEvents txtStation As System.Windows.Forms.TextBox
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents lblStartMonth As System.Windows.Forms.Label
    Friend WithEvents lblEndYear As System.Windows.Forms.Label
    Friend WithEvents lblStartYear As System.Windows.Forms.Label
    Friend WithEvents lblElement As System.Windows.Forms.Label
    Friend WithEvents lblSation As System.Windows.Forms.Label
    Friend WithEvents GrBxCommands As System.Windows.Forms.GroupBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdUpade As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents GrBxDataBase As System.Windows.Forms.GroupBox
    Friend WithEvents optFinal As System.Windows.Forms.RadioButton
    Friend WithEvents optInitial As System.Windows.Forms.RadioButton
    Friend WithEvents lblrecords As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
