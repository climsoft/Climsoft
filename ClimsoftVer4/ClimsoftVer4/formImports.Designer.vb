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
        Me.cmdACCESS = New System.Windows.Forms.Button()
        Me.txtACCESS = New System.Windows.Forms.TextBox()
        Me.cmdEXCEL = New System.Windows.Forms.Button()
        Me.txtEXCEL = New System.Windows.Forms.TextBox()
        Me.cmdCLIMSOFT3 = New System.Windows.Forms.Button()
        Me.txtCLIMSOFT3 = New System.Windows.Forms.TextBox()
        Me.cmdCSV = New System.Windows.Forms.Button()
        Me.txtCSV = New System.Windows.Forms.TextBox()
        Me.optCLIMSOFT3 = New System.Windows.Forms.RadioButton()
        Me.optACCESS = New System.Windows.Forms.RadioButton()
        Me.optEXCEL = New System.Windows.Forms.RadioButton()
        Me.optCSV = New System.Windows.Forms.RadioButton()
        Me.OpenFileImport = New System.Windows.Forms.OpenFileDialog()
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
        Me.DataGridView1.Location = New System.Drawing.Point(377, 31)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(380, 390)
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
        Me.Panel1.Size = New System.Drawing.Size(760, 34)
        Me.Panel1.TabIndex = 4
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(312, 2)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(80, 33)
        Me.cmdReset.TabIndex = 8
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmHelp
        '
        Me.cmHelp.Location = New System.Drawing.Point(560, 2)
        Me.cmHelp.Name = "cmHelp"
        Me.cmHelp.Size = New System.Drawing.Size(80, 33)
        Me.cmHelp.TabIndex = 7
        Me.cmHelp.Text = "Help"
        Me.cmHelp.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(436, 2)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 33)
        Me.cmdClose.TabIndex = 6
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdProcess
        '
        Me.cmdProcess.Location = New System.Drawing.Point(188, 2)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(80, 33)
        Me.cmdProcess.TabIndex = 5
        Me.cmdProcess.Text = "Import"
        Me.cmdProcess.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(64, 2)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(80, 33)
        Me.cmdStart.TabIndex = 4
        Me.cmdStart.Text = "Open File"
        Me.cmdStart.UseVisualStyleBackColor = True
        Me.cmdStart.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdACCESS)
        Me.GroupBox1.Controls.Add(Me.txtACCESS)
        Me.GroupBox1.Controls.Add(Me.cmdEXCEL)
        Me.GroupBox1.Controls.Add(Me.txtEXCEL)
        Me.GroupBox1.Controls.Add(Me.cmdCLIMSOFT3)
        Me.GroupBox1.Controls.Add(Me.txtCLIMSOFT3)
        Me.GroupBox1.Controls.Add(Me.cmdCSV)
        Me.GroupBox1.Controls.Add(Me.txtCSV)
        Me.GroupBox1.Controls.Add(Me.optCLIMSOFT3)
        Me.GroupBox1.Controls.Add(Me.optACCESS)
        Me.GroupBox1.Controls.Add(Me.optEXCEL)
        Me.GroupBox1.Controls.Add(Me.optCSV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 390)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import Types"
        '
        'cmdACCESS
        '
        Me.cmdACCESS.BackgroundImage = CType(resources.GetObject("cmdACCESS.BackgroundImage"), System.Drawing.Image)
        Me.cmdACCESS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdACCESS.Location = New System.Drawing.Point(326, 173)
        Me.cmdACCESS.Name = "cmdACCESS"
        Me.cmdACCESS.Size = New System.Drawing.Size(36, 29)
        Me.cmdACCESS.TabIndex = 11
        Me.cmdACCESS.UseVisualStyleBackColor = True
        '
        'txtACCESS
        '
        Me.txtACCESS.Location = New System.Drawing.Point(106, 177)
        Me.txtACCESS.Name = "txtACCESS"
        Me.txtACCESS.Size = New System.Drawing.Size(221, 20)
        Me.txtACCESS.TabIndex = 10
        '
        'cmdEXCEL
        '
        Me.cmdEXCEL.BackgroundImage = CType(resources.GetObject("cmdEXCEL.BackgroundImage"), System.Drawing.Image)
        Me.cmdEXCEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdEXCEL.Location = New System.Drawing.Point(326, 137)
        Me.cmdEXCEL.Name = "cmdEXCEL"
        Me.cmdEXCEL.Size = New System.Drawing.Size(36, 29)
        Me.cmdEXCEL.TabIndex = 9
        Me.cmdEXCEL.UseVisualStyleBackColor = True
        '
        'txtEXCEL
        '
        Me.txtEXCEL.Location = New System.Drawing.Point(106, 141)
        Me.txtEXCEL.Name = "txtEXCEL"
        Me.txtEXCEL.Size = New System.Drawing.Size(221, 20)
        Me.txtEXCEL.TabIndex = 8
        '
        'cmdCLIMSOFT3
        '
        Me.cmdCLIMSOFT3.BackgroundImage = CType(resources.GetObject("cmdCLIMSOFT3.BackgroundImage"), System.Drawing.Image)
        Me.cmdCLIMSOFT3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCLIMSOFT3.Location = New System.Drawing.Point(326, 98)
        Me.cmdCLIMSOFT3.Name = "cmdCLIMSOFT3"
        Me.cmdCLIMSOFT3.Size = New System.Drawing.Size(36, 29)
        Me.cmdCLIMSOFT3.TabIndex = 7
        Me.cmdCLIMSOFT3.UseVisualStyleBackColor = True
        '
        'txtCLIMSOFT3
        '
        Me.txtCLIMSOFT3.Location = New System.Drawing.Point(106, 102)
        Me.txtCLIMSOFT3.Name = "txtCLIMSOFT3"
        Me.txtCLIMSOFT3.Size = New System.Drawing.Size(221, 20)
        Me.txtCLIMSOFT3.TabIndex = 6
        '
        'cmdCSV
        '
        Me.cmdCSV.BackgroundImage = CType(resources.GetObject("cmdCSV.BackgroundImage"), System.Drawing.Image)
        Me.cmdCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCSV.Location = New System.Drawing.Point(326, 63)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(36, 29)
        Me.cmdCSV.TabIndex = 5
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'txtCSV
        '
        Me.txtCSV.Location = New System.Drawing.Point(106, 67)
        Me.txtCSV.Name = "txtCSV"
        Me.txtCSV.Size = New System.Drawing.Size(221, 20)
        Me.txtCSV.TabIndex = 4
        '
        'optCLIMSOFT3
        '
        Me.optCLIMSOFT3.AutoSize = True
        Me.optCLIMSOFT3.Location = New System.Drawing.Point(14, 105)
        Me.optCLIMSOFT3.Name = "optCLIMSOFT3"
        Me.optCLIMSOFT3.Size = New System.Drawing.Size(94, 17)
        Me.optCLIMSOFT3.TabIndex = 3
        Me.optCLIMSOFT3.TabStop = True
        Me.optCLIMSOFT3.Text = "CLIMSOFT V3"
        Me.optCLIMSOFT3.UseVisualStyleBackColor = True
        '
        'optACCESS
        '
        Me.optACCESS.AutoSize = True
        Me.optACCESS.Location = New System.Drawing.Point(13, 177)
        Me.optACCESS.Name = "optACCESS"
        Me.optACCESS.Size = New System.Drawing.Size(67, 17)
        Me.optACCESS.TabIndex = 2
        Me.optACCESS.TabStop = True
        Me.optACCESS.Text = "ACCESS"
        Me.optACCESS.UseVisualStyleBackColor = True
        '
        'optEXCEL
        '
        Me.optEXCEL.AutoSize = True
        Me.optEXCEL.Location = New System.Drawing.Point(13, 141)
        Me.optEXCEL.Name = "optEXCEL"
        Me.optEXCEL.Size = New System.Drawing.Size(59, 17)
        Me.optEXCEL.TabIndex = 1
        Me.optEXCEL.TabStop = True
        Me.optEXCEL.Text = "EXCEL"
        Me.optEXCEL.UseVisualStyleBackColor = True
        '
        'optCSV
        '
        Me.optCSV.AutoSize = True
        Me.optCSV.Location = New System.Drawing.Point(13, 69)
        Me.optCSV.Name = "optCSV"
        Me.optCSV.Size = New System.Drawing.Size(95, 17)
        Me.optCSV.TabIndex = 0
        Me.optCSV.TabStop = True
        Me.optCSV.Text = "Text File (CSV)"
        Me.optCSV.UseVisualStyleBackColor = True
        '
        'OpenFileImport
        '
        Me.OpenFileImport.FileName = "imports"
        '
        'formImports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 462)
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

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdACCESS As System.Windows.Forms.Button
    Friend WithEvents txtACCESS As System.Windows.Forms.TextBox
    Friend WithEvents cmdEXCEL As System.Windows.Forms.Button
    Friend WithEvents txtEXCEL As System.Windows.Forms.TextBox
    Friend WithEvents cmdCLIMSOFT3 As System.Windows.Forms.Button
    Friend WithEvents txtCLIMSOFT3 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCSV As System.Windows.Forms.Button
    Friend WithEvents txtCSV As System.Windows.Forms.TextBox
    Friend WithEvents optCLIMSOFT3 As System.Windows.Forms.RadioButton
    Friend WithEvents optACCESS As System.Windows.Forms.RadioButton
    Friend WithEvents optEXCEL As System.Windows.Forms.RadioButton
    Friend WithEvents optCSV As System.Windows.Forms.RadioButton
    Friend WithEvents OpenFileImport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmHelp As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
End Class
