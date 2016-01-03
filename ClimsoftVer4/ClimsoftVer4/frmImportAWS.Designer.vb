<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportAWS
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
        Me.btnBrowseSchemaFile = New System.Windows.Forms.Button()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.lblSchemaFile = New System.Windows.Forms.Label()
        Me.txtSchemaFile = New System.Windows.Forms.TextBox()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBrowseSchemaFile
        '
        Me.btnBrowseSchemaFile.Location = New System.Drawing.Point(531, 110)
        Me.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile"
        Me.btnBrowseSchemaFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseSchemaFile.TabIndex = 21
        Me.btnBrowseSchemaFile.Text = "Browse"
        Me.btnBrowseSchemaFile.UseVisualStyleBackColor = True
        '
        'btnBrowseDataFile
        '
        Me.btnBrowseDataFile.Location = New System.Drawing.Point(531, 76)
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFile.TabIndex = 20
        Me.btnBrowseDataFile.Text = "Browse"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'lblSchemaFile
        '
        Me.lblSchemaFile.AutoSize = True
        Me.lblSchemaFile.Location = New System.Drawing.Point(54, 116)
        Me.lblSchemaFile.Name = "lblSchemaFile"
        Me.lblSchemaFile.Size = New System.Drawing.Size(65, 13)
        Me.lblSchemaFile.TabIndex = 19
        Me.lblSchemaFile.Text = "Schema File"
        '
        'txtSchemaFile
        '
        Me.txtSchemaFile.Location = New System.Drawing.Point(157, 113)
        Me.txtSchemaFile.Name = "txtSchemaFile"
        Me.txtSchemaFile.Size = New System.Drawing.Size(355, 20)
        Me.txtSchemaFile.TabIndex = 18
        '
        'lblDataFile
        '
        Me.lblDataFile.AutoSize = True
        Me.lblDataFile.Location = New System.Drawing.Point(54, 79)
        Me.lblDataFile.Name = "lblDataFile"
        Me.lblDataFile.Size = New System.Drawing.Size(49, 13)
        Me.lblDataFile.TabIndex = 17
        Me.lblDataFile.Text = "Data File"
        '
        'txtDataFile
        '
        Me.txtDataFile.Location = New System.Drawing.Point(157, 76)
        Me.txtDataFile.Name = "txtDataFile"
        Me.txtDataFile.Size = New System.Drawing.Size(355, 20)
        Me.txtDataFile.TabIndex = 16
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(437, 163)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 15
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(338, 163)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(239, 163)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmImportAWS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 219)
        Me.Controls.Add(Me.btnBrowseSchemaFile)
        Me.Controls.Add(Me.btnBrowseDataFile)
        Me.Controls.Add(Me.lblSchemaFile)
        Me.Controls.Add(Me.txtSchemaFile)
        Me.Controls.Add(Me.lblDataFile)
        Me.Controls.Add(Me.txtDataFile)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportAWS"
        Me.Text = "frmImportAWS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseSchemaFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents lblSchemaFile As System.Windows.Forms.Label
    Friend WithEvents txtSchemaFile As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
