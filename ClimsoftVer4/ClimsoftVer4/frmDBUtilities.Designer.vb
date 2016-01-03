<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBUtilities
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDBUtilities))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObsInitialToFinalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerateValuesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExternalDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLICOMDailyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NOAAGTSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Dbtpanel2 = New System.Windows.Forms.Panel()
        Me.ProgressBarDb = New System.Windows.Forms.ProgressBar()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.Dbtpanel1 = New System.Windows.Forms.Panel()
        Me.grpbxUpload = New System.Windows.Forms.GroupBox()
        Me.cmdUpload = New System.Windows.Forms.Button()
        Me.ListViewDbUtil = New System.Windows.Forms.ListView()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Dbtpanel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Dbtpanel1.SuspendLayout()
        Me.grpbxUpload.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripMenuItem, Me.GenerateValuesToolStripMenuItem, Me.ExternalDataToolStripMenuItem, Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(852, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObsInitialToFinalToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ImportToolStripMenuItem.Text = "Upload"
        '
        'ObsInitialToFinalToolStripMenuItem
        '
        Me.ObsInitialToFinalToolStripMenuItem.Name = "ObsInitialToFinalToolStripMenuItem"
        Me.ObsInitialToFinalToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ObsInitialToFinalToolStripMenuItem.Text = "Obs Initial to Final"
        '
        'GenerateValuesToolStripMenuItem
        '
        Me.GenerateValuesToolStripMenuItem.Name = "GenerateValuesToolStripMenuItem"
        Me.GenerateValuesToolStripMenuItem.Size = New System.Drawing.Size(103, 20)
        Me.GenerateValuesToolStripMenuItem.Text = "Generate Values"
        '
        'ExternalDataToolStripMenuItem
        '
        Me.ExternalDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLICOMDailyToolStripMenuItem, Me.AWSToolStripMenuItem, Me.NOAAGTSToolStripMenuItem})
        Me.ExternalDataToolStripMenuItem.Name = "ExternalDataToolStripMenuItem"
        Me.ExternalDataToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ExternalDataToolStripMenuItem.Text = "External Data"
        '
        'CLICOMDailyToolStripMenuItem
        '
        Me.CLICOMDailyToolStripMenuItem.Name = "CLICOMDailyToolStripMenuItem"
        Me.CLICOMDailyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CLICOMDailyToolStripMenuItem.Text = "CLICOM Daily"
        '
        'AWSToolStripMenuItem
        '
        Me.AWSToolStripMenuItem.Name = "AWSToolStripMenuItem"
        Me.AWSToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AWSToolStripMenuItem.Text = "AWS "
        '
        'NOAAGTSToolStripMenuItem
        '
        Me.NOAAGTSToolStripMenuItem.Name = "NOAAGTSToolStripMenuItem"
        Me.NOAAGTSToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NOAAGTSToolStripMenuItem.Text = "NOAA GTS"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 396)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(852, 27)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(305, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(67, 27)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "OK"
        '
        'Dbtpanel2
        '
        Me.Dbtpanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dbtpanel2.Controls.Add(Me.ProgressBarDb)
        Me.Dbtpanel2.Location = New System.Drawing.Point(444, 52)
        Me.Dbtpanel2.Name = "Dbtpanel2"
        Me.Dbtpanel2.Padding = New System.Windows.Forms.Padding(2)
        Me.Dbtpanel2.Size = New System.Drawing.Size(396, 338)
        Me.Dbtpanel2.TabIndex = 5
        '
        'ProgressBarDb
        '
        Me.ProgressBarDb.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBarDb.Location = New System.Drawing.Point(2, 311)
        Me.ProgressBarDb.Name = "ProgressBarDb"
        Me.ProgressBarDb.Size = New System.Drawing.Size(388, 21)
        Me.ProgressBarDb.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripComboBox1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 25)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripLabel1.Text = "Database"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"Initial", "Final"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
        '
        'Dbtpanel1
        '
        Me.Dbtpanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dbtpanel1.Controls.Add(Me.grpbxUpload)
        Me.Dbtpanel1.Controls.Add(Me.ListViewDbUtil)
        Me.Dbtpanel1.Location = New System.Drawing.Point(12, 52)
        Me.Dbtpanel1.Name = "Dbtpanel1"
        Me.Dbtpanel1.Padding = New System.Windows.Forms.Padding(2)
        Me.Dbtpanel1.Size = New System.Drawing.Size(426, 338)
        Me.Dbtpanel1.TabIndex = 7
        '
        'grpbxUpload
        '
        Me.grpbxUpload.Controls.Add(Me.cmdUpload)
        Me.grpbxUpload.Location = New System.Drawing.Point(2, 311)
        Me.grpbxUpload.Name = "grpbxUpload"
        Me.grpbxUpload.Size = New System.Drawing.Size(421, 24)
        Me.grpbxUpload.TabIndex = 7
        Me.grpbxUpload.TabStop = False
        '
        'cmdUpload
        '
        Me.cmdUpload.Location = New System.Drawing.Point(167, 6)
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.Size = New System.Drawing.Size(87, 19)
        Me.cmdUpload.TabIndex = 7
        Me.cmdUpload.Text = "Start Upload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        Me.cmdUpload.Visible = False
        '
        'ListViewDbUtil
        '
        Me.ListViewDbUtil.AllowColumnReorder = True
        Me.ListViewDbUtil.AllowDrop = True
        Me.ListViewDbUtil.CheckBoxes = True
        Me.ListViewDbUtil.GridLines = True
        Me.ListViewDbUtil.LabelEdit = True
        Me.ListViewDbUtil.Location = New System.Drawing.Point(5, 5)
        Me.ListViewDbUtil.Name = "ListViewDbUtil"
        Me.ListViewDbUtil.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListViewDbUtil.Size = New System.Drawing.Size(412, 305)
        Me.ListViewDbUtil.TabIndex = 5
        Me.ListViewDbUtil.UseCompatibleStateImageBehavior = False
        Me.ListViewDbUtil.View = System.Windows.Forms.View.Details
        Me.ListViewDbUtil.Visible = False
        '
        'frmDBUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 423)
        Me.Controls.Add(Me.Dbtpanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Dbtpanel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDBUtilities"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Database Utilities"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Dbtpanel2.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Dbtpanel1.ResumeLayout(False)
        Me.grpbxUpload.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerateValuesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExternalDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Dbtpanel2 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBarDb As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Dbtpanel1 As System.Windows.Forms.Panel
    Public WithEvents ListViewDbUtil As System.Windows.Forms.ListView
    Friend WithEvents grpbxUpload As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents CLICOMDailyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObsInitialToFinalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOAAGTSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
