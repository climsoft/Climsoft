<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCPTSeason
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
        Me.grpCommands = New System.Windows.Forms.GroupBox()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblStartMonth = New System.Windows.Forms.Label()
        Me.cmbStartMonth = New System.Windows.Forms.ComboBox()
        Me.cmbEndMonth = New System.Windows.Forms.ComboBox()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.grpCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCommands
        '
        Me.grpCommands.Controls.Add(Me.cmdHelp)
        Me.grpCommands.Controls.Add(Me.cmdCancel)
        Me.grpCommands.Controls.Add(Me.cmdOK)
        Me.grpCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpCommands.Location = New System.Drawing.Point(0, 103)
        Me.grpCommands.Name = "grpCommands"
        Me.grpCommands.Size = New System.Drawing.Size(526, 30)
        Me.grpCommands.TabIndex = 0
        Me.grpCommands.TabStop = False
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(349, 5)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(60, 25)
        Me.cmdHelp.TabIndex = 3
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(239, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(60, 25)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(131, 5)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(60, 25)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblStartMonth
        '
        Me.lblStartMonth.AutoSize = True
        Me.lblStartMonth.Location = New System.Drawing.Point(36, 49)
        Me.lblStartMonth.Name = "lblStartMonth"
        Me.lblStartMonth.Size = New System.Drawing.Size(62, 13)
        Me.lblStartMonth.TabIndex = 2
        Me.lblStartMonth.Text = "Start Month"
        '
        'cmbStartMonth
        '
        Me.cmbStartMonth.FormattingEnabled = True
        Me.cmbStartMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbStartMonth.Location = New System.Drawing.Point(104, 45)
        Me.cmbStartMonth.Name = "cmbStartMonth"
        Me.cmbStartMonth.Size = New System.Drawing.Size(49, 21)
        Me.cmbStartMonth.TabIndex = 3
        Me.cmbStartMonth.Text = "3"
        '
        'cmbEndMonth
        '
        Me.cmbEndMonth.FormattingEnabled = True
        Me.cmbEndMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cmbEndMonth.Location = New System.Drawing.Point(381, 45)
        Me.cmbEndMonth.Name = "cmbEndMonth"
        Me.cmbEndMonth.Size = New System.Drawing.Size(49, 21)
        Me.cmbEndMonth.TabIndex = 5
        Me.cmbEndMonth.Text = "5"
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(313, 49)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(62, 13)
        Me.lblEndMonth.TabIndex = 4
        Me.lblEndMonth.Text = "Start Month"
        '
        'frmCPTSeason
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 133)
        Me.Controls.Add(Me.cmbEndMonth)
        Me.Controls.Add(Me.lblEndMonth)
        Me.Controls.Add(Me.cmbStartMonth)
        Me.Controls.Add(Me.lblStartMonth)
        Me.Controls.Add(Me.grpCommands)
        Me.Name = "frmCPTSeason"
        Me.Text = "CPT Season Months"
        Me.grpCommands.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpCommands As System.Windows.Forms.GroupBox
    Friend WithEvents lblStartMonth As System.Windows.Forms.Label
    Friend WithEvents cmbStartMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEndMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
