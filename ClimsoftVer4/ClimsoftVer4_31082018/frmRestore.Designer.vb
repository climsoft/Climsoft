<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestore
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
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblBackupFolder = New System.Windows.Forms.Label()
        Me.txtBackupFolder = New System.Windows.Forms.TextBox()
        Me.lblDataIngestionProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(316, 134)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 15
        Me.btnHelp.Tag = "btnHelp"
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(221, 134)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(126, 134)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Tag = "btnOk"
        Me.btnOK.Text = "Restore"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(407, 81)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(65, 23)
        Me.btnBrowse.TabIndex = 12
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblBackupFolder
        '
        Me.lblBackupFolder.AutoSize = True
        Me.lblBackupFolder.Location = New System.Drawing.Point(41, 86)
        Me.lblBackupFolder.Name = "lblBackupFolder"
        Me.lblBackupFolder.Size = New System.Drawing.Size(79, 13)
        Me.lblBackupFolder.TabIndex = 11
        Me.lblBackupFolder.Text = "Backup Folder:"
        '
        'txtBackupFolder
        '
        Me.txtBackupFolder.Location = New System.Drawing.Point(126, 83)
        Me.txtBackupFolder.Name = "txtBackupFolder"
        Me.txtBackupFolder.Size = New System.Drawing.Size(266, 20)
        Me.txtBackupFolder.TabIndex = 10
        '
        'lblDataIngestionProgress
        '
        Me.lblDataIngestionProgress.AutoSize = True
        Me.lblDataIngestionProgress.ForeColor = System.Drawing.Color.Red
        Me.lblDataIngestionProgress.Location = New System.Drawing.Point(126, 31)
        Me.lblDataIngestionProgress.Name = "lblDataIngestionProgress"
        Me.lblDataIngestionProgress.Size = New System.Drawing.Size(224, 13)
        Me.lblDataIngestionProgress.TabIndex = 16
        Me.lblDataIngestionProgress.Text = "Import data from individual station backup files"
        '
        'frmRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 182)
        Me.Controls.Add(Me.lblDataIngestionProgress)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblBackupFolder)
        Me.Controls.Add(Me.txtBackupFolder)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRestore"
        Me.Text = "Restore from CSV backup files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblBackupFolder As System.Windows.Forms.Label
    Friend WithEvents txtBackupFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblDataIngestionProgress As System.Windows.Forms.Label
End Class
