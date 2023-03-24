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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        CType(Me.dataGridFileContents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFileContents.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(116, 7)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(320, 20)
        Me.txtFilePath.TabIndex = 2
        '
        'lblSelectFile
        '
        Me.lblSelectFile.AutoSize = True
        Me.lblSelectFile.Location = New System.Drawing.Point(12, 14)
        Me.lblSelectFile.Name = "lblSelectFile"
        Me.lblSelectFile.Size = New System.Drawing.Size(59, 13)
        Me.lblSelectFile.TabIndex = 3
        Me.lblSelectFile.Text = "Select File:"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(442, 5)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'rtfSummaryReport
        '
        Me.rtfSummaryReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfSummaryReport.Location = New System.Drawing.Point(3, 16)
        Me.rtfSummaryReport.Name = "rtfSummaryReport"
        Me.rtfSummaryReport.Size = New System.Drawing.Size(282, 172)
        Me.rtfSummaryReport.TabIndex = 5
        Me.rtfSummaryReport.Text = ""
        '
        'dataGridFileContents
        '
        Me.dataGridFileContents.AllowUserToAddRows = False
        Me.dataGridFileContents.AllowUserToDeleteRows = False
        Me.dataGridFileContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridFileContents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridFileContents.Location = New System.Drawing.Point(3, 16)
        Me.dataGridFileContents.Name = "dataGridFileContents"
        Me.dataGridFileContents.ReadOnly = True
        Me.dataGridFileContents.Size = New System.Drawing.Size(504, 506)
        Me.dataGridFileContents.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(12, 583)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(93, 583)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(186, 583)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'grpFileContents
        '
        Me.grpFileContents.Controls.Add(Me.dataGridFileContents)
        Me.grpFileContents.Location = New System.Drawing.Point(7, 46)
        Me.grpFileContents.Name = "grpFileContents"
        Me.grpFileContents.Size = New System.Drawing.Size(510, 525)
        Me.grpFileContents.TabIndex = 11
        Me.grpFileContents.TabStop = False
        Me.grpFileContents.Text = "Slected File Contents"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rtfSummaryReport)
        Me.GroupBox1.Location = New System.Drawing.Point(523, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 191)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary Report"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RichTextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(523, 253)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(288, 318)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detailed Report"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.Location = New System.Drawing.Point(3, 16)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(282, 299)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'frmImportQCData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 612)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpFileContents)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblSelectFile)
        Me.Controls.Add(Me.txtFilePath)
        Me.Name = "frmImportQCData"
        Me.Text = "Import R-Instat Quality Controlled Data"
        CType(Me.dataGridFileContents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFileContents.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
