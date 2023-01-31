<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntryForms
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEntryForms))
        Me.lstViewForms = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStriptxtSpace = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripApply = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripReset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdHelp = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupSelections = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtEMonth = New System.Windows.Forms.TextBox()
        Me.txtEYear = New System.Windows.Forms.TextBox()
        Me.txtBmonth = New System.Windows.Forms.TextBox()
        Me.txtBYear = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkSkipUploaded = New System.Windows.Forms.CheckBox()
        Me.optSelectRecords = New System.Windows.Forms.RadioButton()
        Me.optAllRecords = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupSelections.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstViewForms
        '
        Me.lstViewForms.AllowColumnReorder = True
        Me.lstViewForms.AllowDrop = True
        Me.lstViewForms.CheckBoxes = True
        Me.lstViewForms.FullRowSelect = True
        Me.lstViewForms.GridLines = True
        Me.lstViewForms.HideSelection = False
        Me.lstViewForms.LabelEdit = True
        Me.lstViewForms.Location = New System.Drawing.Point(14, 12)
        Me.lstViewForms.Name = "lstViewForms"
        Me.lstViewForms.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lstViewForms.Size = New System.Drawing.Size(503, 237)
        Me.lstViewForms.TabIndex = 4
        Me.lstViewForms.UseCompatibleStateImageBehavior = False
        Me.lstViewForms.View = System.Windows.Forms.View.Details
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStriptxtSpace, Me.ToolStripApply, Me.ToolStripSeparator4, Me.ToolStripSeparator1, Me.ToolStripReset, Me.ToolStripSeparator3, Me.ToolStripSeparator2, Me.cmdClose, Me.ToolStripSeparator6, Me.ToolStripSeparator7, Me.cmdHelp})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 436)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(537, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStriptxtSpace
        '
        Me.ToolStriptxtSpace.AutoSize = False
        Me.ToolStriptxtSpace.Name = "ToolStriptxtSpace"
        Me.ToolStriptxtSpace.Size = New System.Drawing.Size(140, 22)
        '
        'ToolStripApply
        '
        Me.ToolStripApply.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripApply.Image = CType(resources.GetObject("ToolStripApply.Image"), System.Drawing.Image)
        Me.ToolStripApply.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.ToolStripApply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripApply.Name = "ToolStripApply"
        Me.ToolStripApply.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripApply.RightToLeftAutoMirrorImage = True
        Me.ToolStripApply.Size = New System.Drawing.Size(27, 22)
        Me.ToolStripApply.Text = "OK"
        Me.ToolStripApply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripReset
        '
        Me.ToolStripReset.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripReset.Image = CType(resources.GetObject("ToolStripReset.Image"), System.Drawing.Image)
        Me.ToolStripReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripReset.Name = "ToolStripReset"
        Me.ToolStripReset.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripReset.Text = "Reset"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(40, 22)
        Me.cmdClose.Text = "Close"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmdHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdHelp.Image = CType(resources.GetObject("cmdHelp.Image"), System.Drawing.Image)
        Me.cmdHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(36, 22)
        Me.cmdHelp.Text = "Help"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupSelections)
        Me.GroupBox1.Controls.Add(Me.chkSkipUploaded)
        Me.GroupBox1.Controls.Add(Me.optSelectRecords)
        Me.GroupBox1.Controls.Add(Me.optAllRecords)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 264)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(500, 157)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Records to Delete"
        '
        'GroupSelections
        '
        Me.GroupSelections.Controls.Add(Me.Label6)
        Me.GroupSelections.Controls.Add(Me.Label5)
        Me.GroupSelections.Controls.Add(Me.TxtEMonth)
        Me.GroupSelections.Controls.Add(Me.txtEYear)
        Me.GroupSelections.Controls.Add(Me.txtBmonth)
        Me.GroupSelections.Controls.Add(Me.txtBYear)
        Me.GroupSelections.Controls.Add(Me.Label3)
        Me.GroupSelections.Controls.Add(Me.Label2)
        Me.GroupSelections.Enabled = False
        Me.GroupSelections.Location = New System.Drawing.Point(164, 46)
        Me.GroupSelections.Name = "GroupSelections"
        Me.GroupSelections.Size = New System.Drawing.Size(286, 65)
        Me.GroupSelections.TabIndex = 13
        Me.GroupSelections.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(158, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "End Month"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(158, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "End Year"
        '
        'TxtEMonth
        '
        Me.TxtEMonth.Location = New System.Drawing.Point(230, 39)
        Me.TxtEMonth.Name = "TxtEMonth"
        Me.TxtEMonth.Size = New System.Drawing.Size(33, 20)
        Me.TxtEMonth.TabIndex = 17
        Me.TxtEMonth.Text = "12"
        Me.TxtEMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEYear
        '
        Me.txtEYear.Location = New System.Drawing.Point(230, 10)
        Me.txtEYear.Name = "txtEYear"
        Me.txtEYear.Size = New System.Drawing.Size(46, 20)
        Me.txtEYear.TabIndex = 16
        Me.txtEYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBmonth
        '
        Me.txtBmonth.Location = New System.Drawing.Point(96, 38)
        Me.txtBmonth.Name = "txtBmonth"
        Me.txtBmonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBmonth.TabIndex = 15
        Me.txtBmonth.Text = "1"
        Me.txtBmonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBYear
        '
        Me.txtBYear.Location = New System.Drawing.Point(96, 9)
        Me.txtBYear.Name = "txtBYear"
        Me.txtBYear.Size = New System.Drawing.Size(46, 20)
        Me.txtBYear.TabIndex = 14
        Me.txtBYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Start Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Start Year"
        '
        'chkSkipUploaded
        '
        Me.chkSkipUploaded.AutoSize = True
        Me.chkSkipUploaded.Checked = True
        Me.chkSkipUploaded.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSkipUploaded.Location = New System.Drawing.Point(21, 125)
        Me.chkSkipUploaded.Name = "chkSkipUploaded"
        Me.chkSkipUploaded.Size = New System.Drawing.Size(159, 17)
        Me.chkSkipUploaded.TabIndex = 12
        Me.chkSkipUploaded.Text = "Skip Records Not Uploaded"
        Me.chkSkipUploaded.UseVisualStyleBackColor = True
        '
        'optSelectRecords
        '
        Me.optSelectRecords.AutoSize = True
        Me.optSelectRecords.Location = New System.Drawing.Point(149, 28)
        Me.optSelectRecords.Name = "optSelectRecords"
        Me.optSelectRecords.Size = New System.Drawing.Size(98, 17)
        Me.optSelectRecords.TabIndex = 1
        Me.optSelectRecords.Text = "Select Records"
        Me.optSelectRecords.UseVisualStyleBackColor = True
        '
        'optAllRecords
        '
        Me.optAllRecords.AutoSize = True
        Me.optAllRecords.Checked = True
        Me.optAllRecords.Location = New System.Drawing.Point(21, 28)
        Me.optAllRecords.Name = "optAllRecords"
        Me.optAllRecords.Size = New System.Drawing.Size(79, 17)
        Me.optAllRecords.TabIndex = 0
        Me.optAllRecords.TabStop = True
        Me.optAllRecords.Text = "All Records"
        Me.optAllRecords.UseVisualStyleBackColor = True
        '
        'frmEntryForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 461)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lstViewForms)
        Me.Name = "frmEntryForms"
        Me.Text = "Empty Key Entry Forms"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupSelections.ResumeLayout(False)
        Me.GroupSelections.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstViewForms As ListView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripApply As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripReset As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdClose As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents cmdHelp As ToolStripButton
    Friend WithEvents ToolStriptxtSpace As ToolStripLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkSkipUploaded As CheckBox
    Friend WithEvents optSelectRecords As RadioButton
    Friend WithEvents optAllRecords As RadioButton
    Friend WithEvents GroupSelections As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtEMonth As TextBox
    Friend WithEvents txtEYear As TextBox
    Friend WithEvents txtBmonth As TextBox
    Friend WithEvents txtBYear As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
