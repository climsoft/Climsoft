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
        Me.CLIMSOFTV3ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.cmbDb = New System.Windows.Forms.ToolStripComboBox()
        Me.Dbtpanel1 = New System.Windows.Forms.Panel()
        Me.grpbxUpload = New System.Windows.Forms.GroupBox()
        Me.cmdUpload = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
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
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObsInitialToFinalToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        resources.ApplyResources(Me.ImportToolStripMenuItem, "ImportToolStripMenuItem")
        '
        'ObsInitialToFinalToolStripMenuItem
        '
        Me.ObsInitialToFinalToolStripMenuItem.Name = "ObsInitialToFinalToolStripMenuItem"
        resources.ApplyResources(Me.ObsInitialToFinalToolStripMenuItem, "ObsInitialToFinalToolStripMenuItem")
        '
        'GenerateValuesToolStripMenuItem
        '
        Me.GenerateValuesToolStripMenuItem.Name = "GenerateValuesToolStripMenuItem"
        resources.ApplyResources(Me.GenerateValuesToolStripMenuItem, "GenerateValuesToolStripMenuItem")
        '
        'ExternalDataToolStripMenuItem
        '
        Me.ExternalDataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLICOMDailyToolStripMenuItem, Me.AWSToolStripMenuItem, Me.NOAAGTSToolStripMenuItem, Me.CLIMSOFTV3ToolStripMenuItem})
        Me.ExternalDataToolStripMenuItem.Name = "ExternalDataToolStripMenuItem"
        resources.ApplyResources(Me.ExternalDataToolStripMenuItem, "ExternalDataToolStripMenuItem")
        '
        'CLICOMDailyToolStripMenuItem
        '
        Me.CLICOMDailyToolStripMenuItem.Name = "CLICOMDailyToolStripMenuItem"
        resources.ApplyResources(Me.CLICOMDailyToolStripMenuItem, "CLICOMDailyToolStripMenuItem")
        '
        'AWSToolStripMenuItem
        '
        Me.AWSToolStripMenuItem.Name = "AWSToolStripMenuItem"
        resources.ApplyResources(Me.AWSToolStripMenuItem, "AWSToolStripMenuItem")
        '
        'NOAAGTSToolStripMenuItem
        '
        Me.NOAAGTSToolStripMenuItem.Name = "NOAAGTSToolStripMenuItem"
        resources.ApplyResources(Me.NOAAGTSToolStripMenuItem, "NOAAGTSToolStripMenuItem")
        '
        'CLIMSOFTV3ToolStripMenuItem
        '
        Me.CLIMSOFTV3ToolStripMenuItem.Name = "CLIMSOFTV3ToolStripMenuItem"
        resources.ApplyResources(Me.CLIMSOFTV3ToolStripMenuItem, "CLIMSOFTV3ToolStripMenuItem")
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        resources.ApplyResources(Me.BackupToolStripMenuItem, "BackupToolStripMenuItem")
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        resources.ApplyResources(Me.RestoreToolStripMenuItem, "RestoreToolStripMenuItem")
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        resources.ApplyResources(Me.OptionsToolStripMenuItem, "OptionsToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        '
        'Dbtpanel2
        '
        Me.Dbtpanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dbtpanel2.Controls.Add(Me.ProgressBarDb)
        resources.ApplyResources(Me.Dbtpanel2, "Dbtpanel2")
        Me.Dbtpanel2.Name = "Dbtpanel2"
        '
        'ProgressBarDb
        '
        resources.ApplyResources(Me.ProgressBarDb, "ProgressBarDb")
        Me.ProgressBarDb.Name = "ProgressBarDb"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbDb})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        resources.ApplyResources(Me.ToolStripLabel1, "ToolStripLabel1")
        '
        'cmbDb
        '
        Me.cmbDb.Items.AddRange(New Object() {resources.GetString("cmbDb.Items"), resources.GetString("cmbDb.Items1")})
        Me.cmbDb.Name = "cmbDb"
        resources.ApplyResources(Me.cmbDb, "cmbDb")
        '
        'Dbtpanel1
        '
        Me.Dbtpanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dbtpanel1.Controls.Add(Me.grpbxUpload)
        Me.Dbtpanel1.Controls.Add(Me.ListViewDbUtil)
        resources.ApplyResources(Me.Dbtpanel1, "Dbtpanel1")
        Me.Dbtpanel1.Name = "Dbtpanel1"
        '
        'grpbxUpload
        '
        Me.grpbxUpload.Controls.Add(Me.cmdUpload)
        Me.grpbxUpload.Controls.Add(Me.ListView1)
        resources.ApplyResources(Me.grpbxUpload, "grpbxUpload")
        Me.grpbxUpload.Name = "grpbxUpload"
        Me.grpbxUpload.TabStop = False
        '
        'cmdUpload
        '
        resources.ApplyResources(Me.cmdUpload, "cmdUpload")
        Me.cmdUpload.Name = "cmdUpload"
        Me.cmdUpload.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.AllowDrop = True
        Me.ListView1.CheckBoxes = True
        Me.ListView1.GridLines = True
        Me.ListView1.LabelEdit = True
        resources.ApplyResources(Me.ListView1, "ListView1")
        Me.ListView1.Name = "ListView1"
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ListViewDbUtil
        '
        Me.ListViewDbUtil.AllowColumnReorder = True
        Me.ListViewDbUtil.AllowDrop = True
        Me.ListViewDbUtil.CheckBoxes = True
        Me.ListViewDbUtil.GridLines = True
        Me.ListViewDbUtil.LabelEdit = True
        resources.ApplyResources(Me.ListViewDbUtil, "ListViewDbUtil")
        Me.ListViewDbUtil.Name = "ListViewDbUtil"
        Me.ListViewDbUtil.UseCompatibleStateImageBehavior = False
        Me.ListViewDbUtil.View = System.Windows.Forms.View.Details
        '
        'frmDBUtilities
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Dbtpanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Dbtpanel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDBUtilities"
        Me.ShowInTaskbar = False
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
    Friend WithEvents cmbDb As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Dbtpanel1 As System.Windows.Forms.Panel
    Public WithEvents ListViewDbUtil As System.Windows.Forms.ListView
    Friend WithEvents grpbxUpload As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpload As System.Windows.Forms.Button
    Friend WithEvents CLICOMDailyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObsInitialToFinalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOAAGTSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents CLIMSOFTV3ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
