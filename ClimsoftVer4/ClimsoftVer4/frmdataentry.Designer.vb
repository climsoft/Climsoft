<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKeyEntry))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.lblDb = New System.Windows.Forms.Label()
        Me.lblSep1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmdHelp = New System.Windows.Forms.ToolStripButton()
        Me.lblSep = New System.Windows.Forms.ToolStripLabel()
        Me.lblSep2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmdOk = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.AllowDrop = True
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HideSelection = False
        Me.ListView1.HoverSelection = True
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(0, 28)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.RightToLeftLayout = True
        Me.ListView1.Size = New System.Drawing.Size(717, 347)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "climsoft4.chm"
        '
        'lblDb
        '
        Me.lblDb.AutoSize = True
        Me.lblDb.Location = New System.Drawing.Point(3, 3)
        Me.lblDb.Name = "lblDb"
        Me.lblDb.Size = New System.Drawing.Size(22, 13)
        Me.lblDb.TabIndex = 3
        Me.lblDb.Text = "     "
        '
        'lblSep1
        '
        Me.lblSep1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(16, 22)
        Me.lblSep1.Text = "   "
        '
        'cmdHelp
        '
        Me.cmdHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(36, 22)
        Me.cmdHelp.Text = "&Help"
        '
        'lblSep
        '
        Me.lblSep.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep.Name = "lblSep"
        Me.lblSep.Size = New System.Drawing.Size(13, 22)
        Me.lblSep.Text = "  "
        '
        'lblSep2
        '
        Me.lblSep2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblSep2.Image = CType(resources.GetObject("lblSep2.Image"), System.Drawing.Image)
        Me.lblSep2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(13, 22)
        Me.lblSep2.Text = "  "
        '
        'cmdOk
        '
        Me.cmdOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdOk.Image = CType(resources.GetObject("cmdOk.Image"), System.Drawing.Image)
        Me.cmdOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(27, 22)
        Me.cmdOk.Text = "&OK"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSep1, Me.cmdHelp, Me.lblSep, Me.cmdClose, Me.lblSep2, Me.cmdOk})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 378)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(717, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdClose
        '
        Me.cmdClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(47, 22)
        Me.cmdClose.Text = "&Cancel"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdClose.ToolTipText = "Cancel"
        '
        'frmKeyEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 403)
        Me.Controls.Add(Me.lblDb)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListView1)
        Me.HelpProvider1.SetHelpKeyword(Me, "dataentryforms.htm")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me, "topic2")
        Me.KeyPreview = True
        Me.Name = "frmKeyEntry"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Data Key Entry Forms"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents lblDb As System.Windows.Forms.Label
    Friend WithEvents lblSep1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSep As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblSep2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdOk As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cmdClose As System.Windows.Forms.ToolStripButton
End Class
