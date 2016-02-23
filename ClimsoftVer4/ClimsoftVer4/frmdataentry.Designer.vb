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
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'HelpProvider1
        '
        resources.ApplyResources(Me.HelpProvider1, "HelpProvider1")
        '
        'lblDb
        '
        resources.ApplyResources(Me.lblDb, "lblDb")
        Me.lblDb.Name = "lblDb"
        '
        'lblSep1
        '
        Me.lblSep1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep1.Name = "lblSep1"
        resources.ApplyResources(Me.lblSep1, "lblSep1")
        '
        'cmdHelp
        '
        Me.cmdHelp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdHelp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        '
        'lblSep
        '
        Me.lblSep.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep.Name = "lblSep"
        resources.ApplyResources(Me.lblSep, "lblSep")
        '
        'lblSep2
        '
        Me.lblSep2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblSep2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.lblSep2, "lblSep2")
        Me.lblSep2.Name = "lblSep2"
        '
        'cmdOk
        '
        Me.cmdOk.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdOk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdOk.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblSep1, Me.cmdHelp, Me.lblSep, Me.cmdClose, Me.lblSep2, Me.cmdOk})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'cmdClose
        '
        Me.cmdClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cmdClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Name = "cmdClose"
        '
        'frmKeyEntry
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblDb)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ListView1)
        Me.HelpProvider1.SetHelpKeyword(Me, resources.GetString("$this.HelpKeyword"))
        Me.HelpProvider1.SetHelpNavigator(Me, CType(resources.GetObject("$this.HelpNavigator"), System.Windows.Forms.HelpNavigator))
        Me.HelpProvider1.SetHelpString(Me, resources.GetString("$this.HelpString"))
        Me.KeyPreview = True
        Me.Name = "frmKeyEntry"
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
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
