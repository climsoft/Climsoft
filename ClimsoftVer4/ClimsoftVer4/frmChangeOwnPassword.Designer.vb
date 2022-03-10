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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblConfirmNewPassword = New System.Windows.Forms.Label()
        Me.lblNewPassword = New System.Windows.Forms.Label()
        Me.ucrPasswordNew = New ClimsoftVer4.ucrPassword()
        Me.ucrPasswordConfirm = New ClimsoftVer4.ucrPassword()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(298, 139)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(66, 23)
        Me.btnHelp.TabIndex = 17
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(226, 139)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 23)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(154, 139)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(66, 23)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblConfirmNewPassword
        '
        Me.lblConfirmNewPassword.AutoSize = True
        Me.lblConfirmNewPassword.Location = New System.Drawing.Point(40, 80)
        Me.lblConfirmNewPassword.Name = "lblConfirmNewPassword"
        Me.lblConfirmNewPassword.Size = New System.Drawing.Size(94, 13)
        Me.lblConfirmNewPassword.TabIndex = 14
        Me.lblConfirmNewPassword.Text = "Confirm Password:"
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(40, 26)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(81, 13)
        Me.lblNewPassword.TabIndex = 12
        Me.lblNewPassword.Text = "New Password:"
        '
        'ucrPasswordNew
        '
        Me.ucrPasswordNew.FieldName = Nothing
        Me.ucrPasswordNew.KeyControl = False
        Me.ucrPasswordNew.Location = New System.Drawing.Point(165, 7)
        Me.ucrPasswordNew.Name = "ucrPasswordNew"
        Me.ucrPasswordNew.Size = New System.Drawing.Size(207, 35)
        Me.ucrPasswordNew.TabIndex = 20
        Me.ucrPasswordNew.ValidPassword = False
        '
        'ucrPasswordConfirm
        '
        Me.ucrPasswordConfirm.FieldName = Nothing
        Me.ucrPasswordConfirm.KeyControl = False
        Me.ucrPasswordConfirm.Location = New System.Drawing.Point(167, 61)
        Me.ucrPasswordConfirm.Name = "ucrPasswordConfirm"
        Me.ucrPasswordConfirm.Size = New System.Drawing.Size(207, 35)
        Me.ucrPasswordConfirm.TabIndex = 21
        Me.ucrPasswordConfirm.ValidPassword = False
        '
        'frmChangeOwnPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 172)
        Me.Controls.Add(Me.ucrPasswordConfirm)
        Me.Controls.Add(Me.ucrPasswordNew)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblConfirmNewPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangeOwnPassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change your own password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblConfirmNewPassword As System.Windows.Forms.Label
    Friend WithEvents lblNewPassword As System.Windows.Forms.Label
    Friend WithEvents ucrPasswordNew As ucrPassword
    Friend WithEvents ucrPasswordConfirm As ucrPassword
End Class
