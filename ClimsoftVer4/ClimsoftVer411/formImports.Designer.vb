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
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmHelp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.DataGridView1.Location = New System.Drawing.Point(29, 64)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(487, 357)
        Me.DataGridView1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdReset)
        Me.Panel1.Controls.Add(Me.cmHelp)
        Me.Panel1.Controls.Add(Me.cmdClose)
        Me.Panel1.Controls.Add(Me.cmdProcess)
        Me.Panel1.Controls.Add(Me.cmdStart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 428)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(911, 34)
        Me.Panel1.TabIndex = 4
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(207, 2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(94, 32)
        Me.cmdReset.TabIndex = 8
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmHelp
        '
        Me.cmHelp.Location = New System.Drawing.Point(378, 2)
        Me.cmHelp.Name = "cmHelp"
        Me.cmHelp.Size = New System.Drawing.Size(65, 32)
        Me.cmHelp.TabIndex = 7
        Me.cmHelp.Text = "Help"
        Me.cmHelp.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(307, 1)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(65, 33)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(116, 2)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(87, 32)
        Me.cmdProcess.TabIndex = 5
        Me.cmdProcess.Text = "Import"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(19, 2)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(91, 29)
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "Open File"
        Me.cmdStart.UseVisualStyleBackColor = True
        Me.cmdStart.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdCSV)
        Me.GroupBox1.Controls.Add(Me.txtCSV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(29, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(487, 42)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Text File (CSV)"
        '
        'cmdCSV
        '
        Me.cmdCSV.BackgroundImage = CType(resources.GetObject("cmdCSV.BackgroundImage"), System.Drawing.Image)
        Me.cmdCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCSV.Location = New System.Drawing.Point(445, 9)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(36, 29)
        Me.cmdCSV.TabIndex = 5
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(87, 14)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.Size = New System.Drawing.Size(358, 20)
        Me.txtCSV.TabIndex = 4
        '
        'OpenFileImport
        '
        Me.OpenFileImport.FileName = "imports"
        '
        'listErrors
        '
        Me.listErrors.FormattingEnabled = True
        Me.listErrors.Location = New System.Drawing.Point(522, 69)
        Me.listErrors.Name = "listErrors"
        Me.listErrors.Size = New System.Drawing.Size(361, 329)
        Me.listErrors.TabIndex = 6
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(663, 49)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(80, 13)
        Me.lblErrors.TabIndex = 7
        Me.lblErrors.Text = "Error Messages"
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.BackColor = System.Drawing.SystemColors.Control
        Me.lblSummary.Location = New System.Drawing.Point(526, 405)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(0, 13)
        Me.lblSummary.TabIndex = 8
        '
        'formImports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 462)
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents listErrors As System.Windows.Forms.ListBox
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents lblSummary As System.Windows.Forms.Label
End Class
