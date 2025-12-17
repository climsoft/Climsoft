<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formImports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formImports))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmHelp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.optOther = New System.Windows.Forms.RadioButton()
        Me.optsemicolon = New System.Windows.Forms.RadioButton()
        Me.optTab = New System.Windows.Forms.RadioButton()
        Me.lbldelmt = New System.Windows.Forms.Label()
        Me.optcomma = New System.Windows.Forms.RadioButton()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.cmdCSV = New System.Windows.Forms.Button()
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.OpenFileImport = New System.Windows.Forms.OpenFileDialog()
        Me.listErrors = New System.Windows.Forms.ListBox()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.lblSummary = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Snow
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 78)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(441, 367)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.cmdReset)
        Me.Panel1.Controls.Add(Me.cmHelp)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Controls.Add(Me.cmdProcess)
        Me.Panel1.Controls.Add(Me.cmdStart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 469)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(911, 34)
        Me.Panel1.TabIndex = 4
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(654, 2)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(106, 32)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(298, 2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(106, 32)
        Me.cmdReset.TabIndex = 8
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmHelp
        '
        Me.cmHelp.Location = New System.Drawing.Point(533, 2)
        Me.cmHelp.Name = "cmHelp"
        Me.cmHelp.Size = New System.Drawing.Size(106, 32)
        Me.cmHelp.TabIndex = 7
        Me.cmHelp.Text = "Help"
        Me.cmHelp.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(415, 1)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(106, 32)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(182, 2)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(106, 32)
        Me.cmdProcess.TabIndex = 5
        Me.cmdProcess.Text = "Import"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(63, 2)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(106, 32)
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "Open File"
        Me.cmdStart.UseVisualStyleBackColor = True
        Me.cmdStart.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtOther)
        Me.GroupBox1.Controls.Add(Me.optOther)
        Me.GroupBox1.Controls.Add(Me.optsemicolon)
        Me.GroupBox1.Controls.Add(Me.optTab)
        Me.GroupBox1.Controls.Add(Me.lbldelmt)
        Me.GroupBox1.Controls.Add(Me.optcomma)
        Me.GroupBox1.Controls.Add(Me.lblFile)
        Me.GroupBox1.Controls.Add(Me.cmdCSV)
        Me.GroupBox1.Controls.Add(Me.txtCSV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(546, 71)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(409, 12)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(25, 20)
        Me.txtOther.TabIndex = 12
        Me.txtOther.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'optOther
        '
        Me.optOther.AutoSize = True
        Me.optOther.Location = New System.Drawing.Point(355, 14)
        Me.optOther.Name = "optOther"
        Me.optOther.Size = New System.Drawing.Size(51, 17)
        Me.optOther.TabIndex = 11
        Me.optOther.Text = "Other"
        Me.optOther.UseVisualStyleBackColor = True
        '
        'optsemicolon
        '
        Me.optsemicolon.AutoSize = True
        Me.optsemicolon.Location = New System.Drawing.Point(219, 14)
        Me.optsemicolon.Name = "optsemicolon"
        Me.optsemicolon.Size = New System.Drawing.Size(74, 17)
        Me.optsemicolon.TabIndex = 10
        Me.optsemicolon.Text = "Semicolon"
        Me.optsemicolon.UseVisualStyleBackColor = True
        '
        'optTab
        '
        Me.optTab.AutoSize = True
        Me.optTab.Location = New System.Drawing.Point(302, 14)
        Me.optTab.Name = "optTab"
        Me.optTab.Size = New System.Drawing.Size(44, 17)
        Me.optTab.TabIndex = 9
        Me.optTab.Text = "Tab"
        Me.optTab.UseVisualStyleBackColor = True
        '
        'lbldelmt
        '
        Me.lbldelmt.AutoSize = True
        Me.lbldelmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldelmt.Location = New System.Drawing.Point(6, 16)
        Me.lbldelmt.Name = "lbldelmt"
        Me.lbldelmt.Size = New System.Drawing.Size(98, 13)
        Me.lbldelmt.TabIndex = 8
        Me.lbldelmt.Text = "Select file delimeter"
        '
        'optcomma
        '
        Me.optcomma.AutoSize = True
        Me.optcomma.Checked = True
        Me.optcomma.Location = New System.Drawing.Point(150, 14)
        Me.optcomma.Name = "optcomma"
        Me.optcomma.Size = New System.Drawing.Size(60, 17)
        Me.optcomma.TabIndex = 7
        Me.optcomma.TabStop = True
        Me.optcomma.Text = "Comma"
        Me.optcomma.UseVisualStyleBackColor = True
        '
        'lblFile
        '
        Me.lblFile.AutoSize = True
        Me.lblFile.Location = New System.Drawing.Point(6, 41)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(134, 13)
        Me.lblFile.TabIndex = 6
        Me.lblFile.Text = "Text File (station metadata)"
        '
        'cmdCSV
        '
        Me.cmdCSV.BackgroundImage = CType(resources.GetObject("cmdCSV.BackgroundImage"), System.Drawing.Image)
        Me.cmdCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCSV.Location = New System.Drawing.Point(501, 32)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(36, 29)
        Me.cmdCSV.TabIndex = 5
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(146, 37)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.Size = New System.Drawing.Size(358, 20)
        Me.txtCSV.TabIndex = 4
        '
        'listErrors
        '
        Me.listErrors.FormattingEnabled = True
        Me.listErrors.HorizontalScrollbar = True
        Me.listErrors.Location = New System.Drawing.Point(462, 77)
        Me.listErrors.Name = "listErrors"
        Me.listErrors.ScrollAlwaysVisible = True
        Me.listErrors.Size = New System.Drawing.Size(435, 368)
        Me.listErrors.TabIndex = 6
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(681, 63)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(80, 13)
        Me.lblErrors.TabIndex = 7
        Me.lblErrors.Text = "Error Messages"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.BackColor = System.Drawing.SystemColors.Control
        Me.lblSummary.Location = New System.Drawing.Point(470, 450)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(0, 13)
        Me.lblSummary.TabIndex = 8
        '
        'formImports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 503)
        Me.Controls.Add(Me.lblSummary)
        Me.Controls.Add(Me.lblErrors)
        Me.Controls.Add(Me.listErrors)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "formImports"
        Me.Text = "Metadata Imports"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCSV As System.Windows.Forms.Button
    Friend WithEvents txtCSV As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileImport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmHelp As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents listErrors As System.Windows.Forms.ListBox
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents lbldelmt As Label
    Friend WithEvents optcomma As RadioButton
    Friend WithEvents txtOther As TextBox
    Friend WithEvents optOther As RadioButton
    Friend WithEvents optsemicolon As RadioButton
    Friend WithEvents optTab As RadioButton
End Class
