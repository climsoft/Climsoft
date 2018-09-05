<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeOwnPassword
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
        Me.lblConfirmNewPassword = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(290, 131)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(66, 23)
        Me.btnHelp.TabIndex = 17
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(218, 131)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(146, 131)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(66, 23)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblConfirmNewPassword
        '
        Me.lblConfirmNewPassword.AutoSize = True
        Me.lblConfirmNewPassword.Location = New System.Drawing.Point(44, 97)
        Me.lblConfirmNewPassword.Name = "lblConfirmNewPassword"
        Me.lblConfirmNewPassword.Size = New System.Drawing.Size(122, 13)
        Me.lblConfirmNewPassword.TabIndex = 14
        Me.lblConfirmNewPassword.Text = "Re-enter New Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(189, 94)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(164, 20)
        Me.txtConfirmPassword.TabIndex = 13
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(44, 53)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(78, 13)
        Me.lblNewPassword.TabIndex = 12
        Me.lblNewPassword.Text = "New Password"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(189, 50)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(164, 20)
        Me.txtNewPassword.TabIndex = 11
        '
        'frmChangeOwnPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 188)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblConfirmNewPassword)
        Me.Controls.Add(Me.txtConfirmPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.Controls.Add(Me.txtNewPassword)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeOwnPassword"
        Me.Text = "Change your own password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblConfirmNewPassword As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
End Class
