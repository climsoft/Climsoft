<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmModifyObservations
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
        Me.DataGridViewObservations = New System.Windows.Forms.DataGridView()
        Me.GrBxSelection = New System.Windows.Forms.GroupBox()
        Me.txtEndHour = New System.Windows.Forms.TextBox()
        Me.txtStartHour = New System.Windows.Forms.TextBox()
        Me.lblEndHour = New System.Windows.Forms.Label()
        Me.lblStartHour = New System.Windows.Forms.Label()
        Me.txtEndDay = New System.Windows.Forms.TextBox()
        Me.txtStartDay = New System.Windows.Forms.TextBox()
        Me.lblEndDay = New System.Windows.Forms.Label()
        Me.lblStartDay = New System.Windows.Forms.Label()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdUpade = New System.Windows.Forms.Button()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.GrBxDataBase = New System.Windows.Forms.GroupBox()
        Me.optFinal = New System.Windows.Forms.RadioButton()
        Me.optInitial = New System.Windows.Forms.RadioButton()
        Me.lblrecords = New System.Windows.Forms.Label()
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
        Me.DataGridViewObservations.Size = New System.Drawing.Size(1137, 501)
        Me.DataGridViewObservations.TabIndex = 0
        '
        'GrBxSelection
        '
        Me.GrBxSelection.Controls.Add(Me.txtEndHour)
        Me.GrBxSelection.Controls.Add(Me.txtStartHour)
        Me.GrBxSelection.Controls.Add(Me.lblEndHour)
        Me.GrBxSelection.Controls.Add(Me.lblStartHour)
        Me.GrBxSelection.Controls.Add(Me.txtEndDay)
        Me.GrBxSelection.Controls.Add(Me.txtStartDay)
        Me.GrBxSelection.Controls.Add(Me.lblEndDay)
        Me.GrBxSelection.Controls.Add(Me.lblStartDay)
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
        Me.GrBxSelection.Location = New System.Drawing.Point(147, 20)
        Me.GrBxSelection.Name = "GrBxSelection"
        Me.GrBxSelection.Size = New System.Drawing.Size(638, 78)
        Me.GrBxSelection.TabIndex = 4
        Me.GrBxSelection.TabStop = False
        Me.GrBxSelection.Text = "Records Selection"
        '
        'txtEndHour
        '
        Me.txtEndHour.Location = New System.Drawing.Point(596, 48)
        Me.txtEndHour.Name = "txtEndHour"
        Me.txtEndHour.Size = New System.Drawing.Size(30, 20)
        Me.txtEndHour.TabIndex = 19
        Me.txtEndHour.Text = "23"
        '
        'txtStartHour
        '
        Me.txtStartHour.Location = New System.Drawing.Point(596, 17)
        Me.txtStartHour.Name = "txtStartHour"
        Me.txtStartHour.Size = New System.Drawing.Size(30, 20)
        Me.txtStartHour.TabIndex = 18
        Me.txtStartHour.Text = "0"
        '
        'lblEndHour
        '
        Me.lblEndHour.AutoSize = True
        Me.lblEndHour.Location = New System.Drawing.Point(539, 52)
        Me.lblEndHour.Name = "lblEndHour"
        Me.lblEndHour.Size = New System.Drawing.Size(52, 13)
        Me.lblEndHour.TabIndex = 17
        Me.lblEndHour.Text = "End Hour"
        '
        'lblStartHour
        '
        Me.lblStartHour.AutoSize = True
        Me.lblStartHour.Location = New System.Drawing.Point(538, 21)
        Me.lblStartHour.Name = "lblStartHour"
        Me.lblStartHour.Size = New System.Drawing.Size(55, 13)
        Me.lblStartHour.TabIndex = 16
        Me.lblStartHour.Text = "Start Hour"
        '
        'txtEndDay
        '
        Me.txtEndDay.Location = New System.Drawing.Point(498, 48)
        Me.txtEndDay.Name = "txtEndDay"
        Me.txtEndDay.Size = New System.Drawing.Size(30, 20)
        Me.txtEndDay.TabIndex = 15
        Me.txtEndDay.Text = "31"
        '
        'txtStartDay
        '
        Me.txtStartDay.Location = New System.Drawing.Point(496, 17)
        Me.txtStartDay.Name = "txtStartDay"
        Me.txtStartDay.Size = New System.Drawing.Size(32, 20)
        Me.txtStartDay.TabIndex = 14
        Me.txtStartDay.Text = "1"
        '
        'lblEndDay
        '
        Me.lblEndDay.AutoSize = True
        Me.lblEndDay.Location = New System.Drawing.Point(444, 52)
        Me.lblEndDay.Name = "lblEndDay"
        Me.lblEndDay.Size = New System.Drawing.Size(48, 13)
        Me.lblEndDay.TabIndex = 13
        Me.lblEndDay.Text = "End Day"
        '
        'lblStartDay
        '
        Me.lblStartDay.AutoSize = True
        Me.lblStartDay.Location = New System.Drawing.Point(443, 21)
        Me.lblStartDay.Name = "lblStartDay"
        Me.lblStartDay.Size = New System.Drawing.Size(51, 13)
        Me.lblStartDay.TabIndex = 12
        Me.lblStartDay.Text = "Start Day"
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(405, 48)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(30, 20)
        Me.txtEndMonth.TabIndex = 11
        Me.txtEndMonth.Text = "12"
        '
        'txtStartMonth
        '
        Me.txtStartMonth.Location = New System.Drawing.Point(404, 17)
        Me.txtStartMonth.Name = "txtStartMonth"
        Me.txtStartMonth.Size = New System.Drawing.Size(31, 20)
        Me.txtStartMonth.TabIndex = 10
        Me.txtStartMonth.Text = "1"
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(291, 48)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(35, 20)
        Me.txtEndYear.TabIndex = 9
        '
        'txtStartYear
        '
        Me.txtStartYear.Location = New System.Drawing.Point(290, 17)
        Me.txtStartYear.Name = "txtStartYear"
        Me.txtStartYear.Size = New System.Drawing.Size(36, 20)
        Me.txtStartYear.TabIndex = 8
        '
        'txtElement
        '
        Me.txtElement.Location = New System.Drawing.Point(95, 48)
        Me.txtElement.Name = "txtElement"
        Me.txtElement.Size = New System.Drawing.Size(124, 20)
        Me.txtElement.TabIndex = 7
        '
        'txtStation
        '
        Me.txtStation.Location = New System.Drawing.Point(95, 17)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(124, 20)
        Me.txtStation.TabIndex = 6
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(341, 52)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 5
        Me.lblEndMonth.Text = "End Month"
        '
        'lblStartMonth
        '
        Me.lblStartMonth.AutoSize = True
        Me.lblStartMonth.Location = New System.Drawing.Point(341, 21)
        Me.lblStartMonth.Name = "lblStartMonth"
        Me.lblStartMonth.Size = New System.Drawing.Size(62, 13)
        Me.lblStartMonth.TabIndex = 4
        Me.lblStartMonth.Text = "Start Month"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(235, 52)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(51, 13)
        Me.lblEndYear.TabIndex = 3
        Me.lblEndYear.Text = "End Year"
        '
        'lblStartYear
        '
        Me.lblStartYear.AutoSize = True
        Me.lblStartYear.Location = New System.Drawing.Point(235, 21)
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
        Me.GrBxCommands.Location = New System.Drawing.Point(799, 30)
        Me.GrBxCommands.Name = "GrBxCommands"
        Me.GrBxCommands.Size = New System.Drawing.Size(344, 58)
        Me.GrBxCommands.TabIndex = 5
        Me.GrBxCommands.TabStop = False
        Me.GrBxCommands.Text = "Commands"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(280, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Help"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(212, 24)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(57, 23)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Enabled = False
        Me.cmdDelete.Location = New System.Drawing.Point(144, 24)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(57, 23)
        Me.cmdDelete.TabIndex = 2
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpade
        '
        Me.cmdUpade.Enabled = False
        Me.cmdUpade.Location = New System.Drawing.Point(76, 24)
        Me.cmdUpade.Name = "cmdUpade"
        Me.cmdUpade.Size = New System.Drawing.Size(57, 23)
        Me.cmdUpade.TabIndex = 1
        Me.cmdUpade.Text = "Update"
        Me.cmdUpade.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(8, 24)
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
        Me.GrBxDataBase.Location = New System.Drawing.Point(17, 20)
        Me.GrBxDataBase.Name = "GrBxDataBase"
        Me.GrBxDataBase.Size = New System.Drawing.Size(125, 78)
        Me.GrBxDataBase.TabIndex = 6
        Me.GrBxDataBase.TabStop = False
        Me.GrBxDataBase.Text = "Tables"
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
        'frmModifyObservations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 611)
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
    Friend WithEvents txtEndHour As System.Windows.Forms.TextBox
    Friend WithEvents txtStartHour As System.Windows.Forms.TextBox
    Friend WithEvents lblEndHour As System.Windows.Forms.Label
    Friend WithEvents lblStartHour As System.Windows.Forms.Label
    Friend WithEvents txtEndDay As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDay As System.Windows.Forms.TextBox
    Friend WithEvents lblEndDay As System.Windows.Forms.Label
    Friend WithEvents lblStartDay As System.Windows.Forms.Label
End Class
