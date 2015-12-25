<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQC
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
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.pnlAdvanced = New System.Windows.Forms.Panel()
        Me.lblQcAdvanced = New System.Windows.Forms.Label()
        Me.pnlQcStandard = New System.Windows.Forms.Panel()
        Me.optAbsoluteLimits = New System.Windows.Forms.RadioButton()
        Me.lblPnl = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.optInterElement = New System.Windows.Forms.RadioButton()
        Me.pnlAdvanced.SuspendLayout()
        Me.pnlQcStandard.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(482, 344)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(75, 23)
        Me.cmdApply.TabIndex = 7
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(320, 344)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(401, 344)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(563, 344)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdHelp.TabIndex = 4
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'pnlAdvanced
        '
        Me.pnlAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAdvanced.Controls.Add(Me.lblQcAdvanced)
        Me.pnlAdvanced.Location = New System.Drawing.Point(363, 39)
        Me.pnlAdvanced.Name = "pnlAdvanced"
        Me.pnlAdvanced.Size = New System.Drawing.Size(280, 276)
        Me.pnlAdvanced.TabIndex = 9
        '
        'lblQcAdvanced
        '
        Me.lblQcAdvanced.AutoSize = True
        Me.lblQcAdvanced.Location = New System.Drawing.Point(3, 0)
        Me.lblQcAdvanced.Name = "lblQcAdvanced"
        Me.lblQcAdvanced.Size = New System.Drawing.Size(74, 13)
        Me.lblQcAdvanced.TabIndex = 0
        Me.lblQcAdvanced.Text = "Advanced QC"
        '
        'pnlQcStandard
        '
        Me.pnlQcStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQcStandard.Controls.Add(Me.optInterElement)
        Me.pnlQcStandard.Controls.Add(Me.optAbsoluteLimits)
        Me.pnlQcStandard.Controls.Add(Me.lblPnl)
        Me.pnlQcStandard.Location = New System.Drawing.Point(26, 40)
        Me.pnlQcStandard.Name = "pnlQcStandard"
        Me.pnlQcStandard.Size = New System.Drawing.Size(301, 275)
        Me.pnlQcStandard.TabIndex = 8
        '
        'optAbsoluteLimits
        '
        Me.optAbsoluteLimits.AutoSize = True
        Me.optAbsoluteLimits.Location = New System.Drawing.Point(22, 27)
        Me.optAbsoluteLimits.Name = "optAbsoluteLimits"
        Me.optAbsoluteLimits.Size = New System.Drawing.Size(129, 17)
        Me.optAbsoluteLimits.TabIndex = 1
        Me.optAbsoluteLimits.TabStop = True
        Me.optAbsoluteLimits.Text = "Absolute limits checks"
        Me.optAbsoluteLimits.UseVisualStyleBackColor = True
        '
        'lblPnl
        '
        Me.lblPnl.AutoSize = True
        Me.lblPnl.Location = New System.Drawing.Point(3, 0)
        Me.lblPnl.Name = "lblPnl"
        Me.lblPnl.Size = New System.Drawing.Size(68, 13)
        Me.lblPnl.TabIndex = 0
        Me.lblPnl.Text = "Standard QC"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(669, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'optInterElement
        '
        Me.optInterElement.AutoSize = True
        Me.optInterElement.Location = New System.Drawing.Point(22, 61)
        Me.optInterElement.Name = "optInterElement"
        Me.optInterElement.Size = New System.Drawing.Size(181, 17)
        Me.optInterElement.TabIndex = 2
        Me.optInterElement.TabStop = True
        Me.optInterElement.Text = "Inter-element comparison checks"
        Me.optInterElement.UseVisualStyleBackColor = True
        '
        'frmQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 389)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.pnlAdvanced)
        Me.Controls.Add(Me.pnlQcStandard)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Name = "frmQC"
        Me.Text = "Quality Control"
        Me.pnlAdvanced.ResumeLayout(False)
        Me.pnlAdvanced.PerformLayout()
        Me.pnlQcStandard.ResumeLayout(False)
        Me.pnlQcStandard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents pnlAdvanced As System.Windows.Forms.Panel
    Friend WithEvents lblQcAdvanced As System.Windows.Forms.Label
    Friend WithEvents pnlQcStandard As System.Windows.Forms.Panel
    Friend WithEvents lblPnl As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents optAbsoluteLimits As System.Windows.Forms.RadioButton
    Friend WithEvents optInterElement As System.Windows.Forms.RadioButton
End Class
