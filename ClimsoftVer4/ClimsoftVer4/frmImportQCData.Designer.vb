<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportQCData
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
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.lblSelectFile = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.rtfSummaryReport = New System.Windows.Forms.RichTextBox()
        Me.dataGridFileContents = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.grpFileContents = New System.Windows.Forms.GroupBox()
        Me.lblFileSelection = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.dataGridFileContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFileContents.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(171, 13)
        Me.txtFilePath.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(478, 26)
        Me.txtFilePath.TabIndex = 2
        '
        'lblSelectFile
        '
        Me.lblSelectFile.AutoSize = True
        Me.lblSelectFile.Location = New System.Drawing.Point(15, 17)
        Me.lblSelectFile.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelectFile.Name = "lblSelectFile"
        Me.lblSelectFile.Size = New System.Drawing.Size(87, 20)
        Me.lblSelectFile.TabIndex = 3
        Me.lblSelectFile.Text = "Select File:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(660, 8)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(112, 35)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'rtfSummaryReport
        '
        Me.rtfSummaryReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfSummaryReport.Location = New System.Drawing.Point(4, 24)
        Me.rtfSummaryReport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rtfSummaryReport.Name = "rtfSummaryReport"
        Me.rtfSummaryReport.Size = New System.Drawing.Size(416, 603)
        Me.rtfSummaryReport.TabIndex = 5
        Me.rtfSummaryReport.Text = ""
        '
        'dataGridFileContents
        '
        Me.dataGridFileContents.AllowUserToAddRows = False
        Me.dataGridFileContents.AllowUserToDeleteRows = False
        Me.dataGridFileContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridFileContents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridFileContents.Location = New System.Drawing.Point(4, 24)
        Me.dataGridFileContents.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dataGridFileContents.Name = "dataGridFileContents"
        Me.dataGridFileContents.ReadOnly = True
        Me.dataGridFileContents.RowHeadersVisible = False
        Me.dataGridFileContents.RowHeadersWidth = 62
        Me.dataGridFileContents.Size = New System.Drawing.Size(881, 603)
        Me.dataGridFileContents.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(284, 706)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(405, 706)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 35)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(531, 706)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(112, 35)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'grpFileContents
        '
        Me.grpFileContents.Controls.Add(Me.lblFileSelection)
        Me.grpFileContents.Controls.Add(Me.dataGridFileContents)
        Me.grpFileContents.Location = New System.Drawing.Point(9, 71)
        Me.grpFileContents.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpFileContents.Name = "grpFileContents"
        Me.grpFileContents.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpFileContents.Size = New System.Drawing.Size(889, 632)
        Me.grpFileContents.TabIndex = 11
        Me.grpFileContents.TabStop = False
        Me.grpFileContents.Text = "Selected File Contents"
        '
        'lblFileSelection
        '
        Me.lblFileSelection.AutoSize = True
        Me.lblFileSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileSelection.Location = New System.Drawing.Point(293, 220)
        Me.lblFileSelection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFileSelection.Name = "lblFileSelection"
        Me.lblFileSelection.Size = New System.Drawing.Size(297, 40)
        Me.lblFileSelection.TabIndex = 14
        Me.lblFileSelection.Text = "No File Selected"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtfSummaryReport)
        Me.GroupBox1.Location = New System.Drawing.Point(905, 71)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(424, 632)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Issues Report"
        '
        'frmImportQCData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 749)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpFileContents)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblSelectFile)
        Me.Controls.Add(Me.txtFilePath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmImportQCData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import R-Instat Quality Controlled Data"
        CType(Me.dataGridFileContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFileContents.ResumeLayout(False)
        Me.grpFileContents.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFilePath As TextBox
    Friend WithEvents lblSelectFile As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents rtfSummaryReport As RichTextBox
    Friend WithEvents dataGridFileContents As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents grpFileContents As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblFileSelection As Label
End Class
