<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.cboUserRole = New System.Windows.Forms.ComboBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.ucrUserPasswordConfirm = New ClimsoftVer4.ucrPassword()
        Me.ucrUserPasswordNew = New ClimsoftVer4.ucrPassword()
        Me.SuspendLayout()
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(275, 213)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(66, 23)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(203, 213)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(66, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(131, 213)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(66, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblConfirmNewPassword
        '
        Me.lblConfirmNewPassword.AutoSize = True
        Me.lblConfirmNewPassword.Location = New System.Drawing.Point(12, 161)
        Me.lblConfirmNewPassword.Name = "lblConfirmNewPassword"
        Me.lblConfirmNewPassword.Size = New System.Drawing.Size(94, 13)
        Me.lblConfirmNewPassword.TabIndex = 23
        Me.lblConfirmNewPassword.Text = "Confirm Password:"
        '
        'lblNewPassword
        '
        Me.lblNewPassword.AutoSize = True
        Me.lblNewPassword.Location = New System.Drawing.Point(12, 111)
        Me.lblNewPassword.Name = "lblNewPassword"
        Me.lblNewPassword.Size = New System.Drawing.Size(78, 13)
        Me.lblNewPassword.TabIndex = 22
        Me.lblNewPassword.Text = "New Password"
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.Location = New System.Drawing.Point(12, 61)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(57, 13)
        Me.lblUserRole.TabIndex = 32
        Me.lblUserRole.Text = "User Role:"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(12, 20)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(58, 13)
        Me.lblUserName.TabIndex = 31
        Me.lblUserName.Text = "Username:"
        '
        'cboUserRole
        '
        Me.cboUserRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUserRole.FormattingEnabled = True
        Me.cboUserRole.Items.AddRange(New Object() {"ClimsoftAdmin", "ClimsoftDeveloper", "ClimsoftMetadata", "ClimsoftOperator", "ClimsoftOperatorSupervisor", "ClimsoftProducts", "ClimsoftQC", "ClimsoftRainfall", "ClimsoftTranslator"})
        Me.cboUserRole.Location = New System.Drawing.Point(141, 54)
        Me.cboUserRole.Name = "cboUserRole"
        Me.cboUserRole.Size = New System.Drawing.Size(137, 21)
        Me.cboUserRole.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(141, 16)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(137, 20)
        Me.txtUserName.TabIndex = 1
        '
        'ucrUserPasswordConfirm
        '
        Me.ucrUserPasswordConfirm.FieldName = Nothing
        Me.ucrUserPasswordConfirm.KeyControl = False
        Me.ucrUserPasswordConfirm.Location = New System.Drawing.Point(144, 139)
        Me.ucrUserPasswordConfirm.Name = "ucrUserPasswordConfirm"
        Me.ucrUserPasswordConfirm.Size = New System.Drawing.Size(207, 35)
        Me.ucrUserPasswordConfirm.TabIndex = 5
        Me.ucrUserPasswordConfirm.ValidPassword = False
        '
        'ucrUserPasswordNew
        '
        Me.ucrUserPasswordNew.FieldName = Nothing
        Me.ucrUserPasswordNew.KeyControl = False
        Me.ucrUserPasswordNew.Location = New System.Drawing.Point(142, 89)
        Me.ucrUserPasswordNew.Name = "ucrUserPasswordNew"
        Me.ucrUserPasswordNew.Size = New System.Drawing.Size(207, 35)
        Me.ucrUserPasswordNew.TabIndex = 4
        Me.ucrUserPasswordNew.ValidPassword = False
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 245)
        Me.Controls.Add(Me.lblUserRole)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.cboUserRole)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.ucrUserPasswordConfirm)
        Me.Controls.Add(Me.ucrUserPasswordNew)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblConfirmNewPassword)
        Me.Controls.Add(Me.lblNewPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add/Edit User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrUserPasswordConfirm As ucrPassword
    Friend WithEvents ucrUserPasswordNew As ucrPassword
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblConfirmNewPassword As Label
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents lblUserRole As Label
    Friend WithEvents lblUserName As Label
    Friend WithEvents cboUserRole As ComboBox
    Friend WithEvents txtUserName As TextBox
End Class
