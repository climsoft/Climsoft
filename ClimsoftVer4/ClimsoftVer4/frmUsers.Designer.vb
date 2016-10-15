<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblPasswordConfirmation = New System.Windows.Forms.Label()
        Me.lblUserPwd = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.txtUserPwd = New System.Windows.Forms.TextBox()
        Me.txtPasswordConfirmation = New System.Windows.Forms.TextBox()
        Me.txtPassWord = New System.Windows.Forms.TextBox()
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.lblPasswordConfirmation)
        Me.GroupBox1.Controls.Add(Me.lblUserPwd)
        Me.GroupBox1.Controls.Add(Me.lblPassword)
        Me.GroupBox1.Controls.Add(Me.lblUserRole)
        Me.GroupBox1.Controls.Add(Me.lblUserName)
        Me.GroupBox1.Controls.Add(Me.cmdView)
        Me.GroupBox1.Controls.Add(Me.cmdDelete)
        Me.GroupBox1.Controls.Add(Me.cmdUpdate)
        Me.GroupBox1.Controls.Add(Me.cmdAddNew)
        Me.GroupBox1.Controls.Add(Me.txtUserPwd)
        Me.GroupBox1.Controls.Add(Me.txtPasswordConfirmation)
        Me.GroupBox1.Controls.Add(Me.txtPassWord)
        Me.GroupBox1.Controls.Add(Me.cboUserType)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox1.Location = New System.Drawing.Point(23, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6)
        Me.GroupBox1.Size = New System.Drawing.Size(436, 275)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "User Details"
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(151, 53)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(182, 20)
        Me.txtUserName.TabIndex = 0
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(347, 230)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(70, 24)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'lblPasswordConfirmation
        '
        Me.lblPasswordConfirmation.AutoSize = True
        Me.lblPasswordConfirmation.Location = New System.Drawing.Point(58, 167)
        Me.lblPasswordConfirmation.Name = "lblPasswordConfirmation"
        Me.lblPasswordConfirmation.Size = New System.Drawing.Size(91, 13)
        Me.lblPasswordConfirmation.TabIndex = 11
        Me.lblPasswordConfirmation.Text = "Password Confirm"
        '
        'lblUserPwd
        '
        Me.lblUserPwd.AutoSize = True
        Me.lblUserPwd.Location = New System.Drawing.Point(58, 132)
        Me.lblUserPwd.Name = "lblUserPwd"
        Me.lblUserPwd.Size = New System.Drawing.Size(59, 13)
        Me.lblUserPwd.TabIndex = 10
        Me.lblUserPwd.Text = "Pass Word"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(58, 132)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(59, 13)
        Me.lblPassword.TabIndex = 10
        Me.lblPassword.Text = "Pass Word"
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.Location = New System.Drawing.Point(58, 97)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(54, 13)
        Me.lblUserRole.TabIndex = 9
        Me.lblUserRole.Text = "User Role"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(58, 56)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(60, 13)
        Me.lblUserName.TabIndex = 8
        Me.lblUserName.Text = "User Name"
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(263, 230)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(70, 24)
        Me.cmdView.TabIndex = 7
        Me.cmdView.Text = "View"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(179, 230)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(70, 24)
        Me.cmdDelete.TabIndex = 6
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(95, 230)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(70, 24)
        Me.cmdUpdate.TabIndex = 5
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(11, 230)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(70, 24)
        Me.cmdAddNew.TabIndex = 4
        Me.cmdAddNew.Text = "AddNew"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'txtUserPwd
        '
        Me.txtUserPwd.Location = New System.Drawing.Point(151, 128)
        Me.txtUserPwd.Name = "txtUserPwd"
        Me.txtUserPwd.Size = New System.Drawing.Size(184, 20)
        Me.txtUserPwd.TabIndex = 2
        '
        'txtPasswordConfirmation
        '
        Me.txtPasswordConfirmation.Location = New System.Drawing.Point(151, 163)
        Me.txtPasswordConfirmation.Name = "txtPasswordConfirmation"
        Me.txtPasswordConfirmation.Size = New System.Drawing.Size(184, 20)
        Me.txtPasswordConfirmation.TabIndex = 3
        '
        'txtPassWord
        '
        Me.txtPassWord.Location = New System.Drawing.Point(151, 128)
        Me.txtPassWord.Name = "txtPassWord"
        Me.txtPassWord.Size = New System.Drawing.Size(184, 20)
        Me.txtPassWord.TabIndex = 2
        '
        'cboUserType
        '
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Items.AddRange(New Object() {"ClimsoftAdmin", "ClimsoftDeveloper", "ClimsoftMetadata", "ClimsoftOperator", "ClimsoftOperatorSupervisor", "ClimsoftQC", "ClimsoftRainfall", "ClimsoftTranslator"})
        Me.cboUserType.Location = New System.Drawing.Point(151, 93)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(184, 21)
        Me.cboUserType.TabIndex = 1
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(481, 32)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(317, 241)
        Me.DataGridView1.TabIndex = 21
        '
        'frmUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LavenderBlush
        Me.ClientSize = New System.Drawing.Size(838, 330)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmUsers"
        Me.Text = "User Adminstration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPasswordConfirmation As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserRole As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdAddNew As System.Windows.Forms.Button
    Friend WithEvents txtPasswordConfirmation As System.Windows.Forms.TextBox
    Friend WithEvents txtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents cboUserType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblUserPwd As System.Windows.Forms.Label
    Friend WithEvents txtUserPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
