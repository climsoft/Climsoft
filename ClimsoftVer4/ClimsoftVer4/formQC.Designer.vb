<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formQC
    Inherits ClimsoftVer4.frmAction

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlQcStandard = New System.Windows.Forms.Panel()
        Me.lblPnl = New System.Windows.Forms.Label()
        Me.pnlAdvanced = New System.Windows.Forms.Panel()
        Me.lblQcAdvanced = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.pnlQcStandard.SuspendLayout()
        Me.pnlAdvanced.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlQcStandard
        '
        Me.pnlQcStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQcStandard.Controls.Add(Me.lblPnl)
        Me.pnlQcStandard.Location = New System.Drawing.Point(12, 38)
        Me.pnlQcStandard.Name = "pnlQcStandard"
        Me.pnlQcStandard.Size = New System.Drawing.Size(301, 275)
        Me.pnlQcStandard.TabIndex = 4
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
        'pnlAdvanced
        '
        Me.pnlAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAdvanced.Controls.Add(Me.lblQcAdvanced)
        Me.pnlAdvanced.Location = New System.Drawing.Point(349, 27)
        Me.pnlAdvanced.Name = "pnlAdvanced"
        Me.pnlAdvanced.Size = New System.Drawing.Size(280, 288)
        Me.pnlAdvanced.TabIndex = 5
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
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(663, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'formQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(663, 349)
        Me.Controls.Add(Me.pnlAdvanced)
        Me.Controls.Add(Me.pnlQcStandard)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "formQC"
        Me.Text = "Qaulity Control"
        Me.Controls.SetChildIndex(Me.MenuStrip1, 0)
        Me.Controls.SetChildIndex(Me.pnlQcStandard, 0)
        Me.Controls.SetChildIndex(Me.pnlAdvanced, 0)
        Me.pnlQcStandard.ResumeLayout(False)
        Me.pnlQcStandard.PerformLayout()
        Me.pnlAdvanced.ResumeLayout(False)
        Me.pnlAdvanced.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlQcStandard As System.Windows.Forms.Panel
    Friend WithEvents lblPnl As System.Windows.Forms.Label
    Friend WithEvents pnlAdvanced As System.Windows.Forms.Panel
    Friend WithEvents lblQcAdvanced As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip

End Class
