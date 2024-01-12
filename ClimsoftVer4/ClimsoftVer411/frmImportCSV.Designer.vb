<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportCSV
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtSchemaFile = New System.Windows.Forms.TextBox()
        Me.lblSchemaFile = New System.Windows.Forms.Label()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.btnBrowseSchemaFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(210, 140)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Tag = "btnOk"
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(309, 140)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Tag = "btnCancel"
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(408, 140)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 6
        Me.btnHelp.Tag = "btnHelp"
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'txtDataFile
        '
        Me.txtDataFile.Location = New System.Drawing.Point(128, 53)
        Me.txtDataFile.Name = "txtDataFile"
        Me.txtDataFile.Size = New System.Drawing.Size(355, 20)
        Me.txtDataFile.TabIndex = 7
        '
        'lblDataFile
        '
        Me.lblDataFile.AutoSize = True
        Me.lblDataFile.Location = New System.Drawing.Point(25, 56)
        Me.lblDataFile.Name = "lblDataFile"
        Me.lblDataFile.Size = New System.Drawing.Size(49, 13)
        Me.lblDataFile.TabIndex = 8
        Me.lblDataFile.Tag = "lblDataFile"
        Me.lblDataFile.Text = "Data File"
        '
        'txtSchemaFile
        '
        Me.txtSchemaFile.Location = New System.Drawing.Point(128, 90)
        Me.txtSchemaFile.Name = "txtSchemaFile"
        Me.txtSchemaFile.Size = New System.Drawing.Size(355, 20)
        Me.txtSchemaFile.TabIndex = 9
        '
        'lblSchemaFile
        '
        Me.lblSchemaFile.AutoSize = True
        Me.lblSchemaFile.Location = New System.Drawing.Point(25, 93)
        Me.lblSchemaFile.Name = "lblSchemaFile"
        Me.lblSchemaFile.Size = New System.Drawing.Size(65, 13)
        Me.lblSchemaFile.TabIndex = 10
        Me.lblSchemaFile.Tag = "lblSchemaFile"
        Me.lblSchemaFile.Text = "Schema File"
        '
        'btnBrowseDataFile
        '
        Me.btnBrowseDataFile.Location = New System.Drawing.Point(502, 50)
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFile.TabIndex = 11
        Me.btnBrowseDataFile.Tag = "btnBrowse"
        Me.btnBrowseDataFile.Text = "Browse"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'btnBrowseSchemaFile
        '
        Me.btnBrowseSchemaFile.Location = New System.Drawing.Point(502, 87)
        Me.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile"
        Me.btnBrowseSchemaFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseSchemaFile.TabIndex = 12
        Me.btnBrowseSchemaFile.Tag = "btnBrowse"
        Me.btnBrowseSchemaFile.Text = "Browse"
        Me.btnBrowseSchemaFile.UseVisualStyleBackColor = True
        '
        'frmImportCSV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 190)
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
        Me.Name = "frmImportCSV"
        Me.Tag = "titleFormImportCSV"
        Me.Text = "Import from CSV"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtSchemaFile As System.Windows.Forms.TextBox
    Friend WithEvents lblSchemaFile As System.Windows.Forms.Label
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseSchemaFile As System.Windows.Forms.Button
End Class
