<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGTSNOAA
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
        Me.components = New System.ComponentModel.Container()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowseDataFile
        '
        Me.btnBrowseDataFile.Location = New System.Drawing.Point(488, 49)
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFile.TabIndex = 27
        Me.btnBrowseDataFile.Text = "Browse"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'lblDataFile
        '
        Me.lblDataFile.AutoSize = True
        Me.lblDataFile.Location = New System.Drawing.Point(11, 55)
        Me.lblDataFile.Name = "lblDataFile"
        Me.lblDataFile.Size = New System.Drawing.Size(49, 13)
        Me.lblDataFile.TabIndex = 26
        Me.lblDataFile.Text = "Data File"
        '
        'txtDataFile
        '
        Me.txtDataFile.Location = New System.Drawing.Point(114, 52)
        Me.txtDataFile.Name = "txtDataFile"
        Me.txtDataFile.Size = New System.Drawing.Size(355, 20)
        Me.txtDataFile.TabIndex = 25
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(394, 102)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 24
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(295, 102)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(196, 102)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Location = New System.Drawing.Point(196, 134)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(0, 13)
        Me.lblRecordCount.TabIndex = 28
        '
        'BindingSource1
        '
        '
        'frmGTSNOAA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 159)
        Me.Controls.Add(Me.lblRecordCount)
        Me.Controls.Add(Me.btnBrowseDataFile)
        Me.Controls.Add(Me.lblDataFile)
        Me.Controls.Add(Me.txtDataFile)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmGTSNOAA"
        Me.Text = "GTS-NOAA Data"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblRecordCount As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As BindingSource
End Class
