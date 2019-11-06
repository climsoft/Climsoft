<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.txtusrpwd = New System.Windows.Forms.TextBox()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmbDatabases = New System.Windows.Forms.ComboBox()
        Me.lblDbdetails = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkRememberUsername = New System.Windows.Forms.CheckBox()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(199, 251)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(218, 11)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(55, 13)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Tag = "Username"
        Me.lblUsername.Text = "&Username"
        Me.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(218, 61)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 2
        Me.lblPassword.Tag = "Password"
        Me.lblPassword.Text = "&Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(220, 31)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(220, 20)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Tag = ""
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(220, 81)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(220, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.Tag = ""
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(239, 219)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(67, 23)
        Me.OK.TabIndex = 4
        Me.OK.Tag = "OK"
        Me.OK.Text = "&OK"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(342, 219)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(67, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Tag = "Cancel"
        Me.Cancel.Text = "&Cancel"
        '
        'txtusrpwd
        '
        Me.txtusrpwd.Location = New System.Drawing.Point(223, 32)
        Me.txtusrpwd.Name = "txtusrpwd"
        Me.txtusrpwd.Size = New System.Drawing.Size(177, 20)
        Me.txtusrpwd.TabIndex = 6
        Me.txtusrpwd.Visible = False
        '
        'cmdHelp
        '
        Me.cmdHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdHelp.Location = New System.Drawing.Point(445, 219)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(67, 23)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Tag = "Help"
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.Visible = False
        '
        'cmbDatabases
        '
        Me.cmbDatabases.BackColor = System.Drawing.SystemColors.Menu
        Me.cmbDatabases.FormattingEnabled = True
        Me.cmbDatabases.Location = New System.Drawing.Point(218, 162)
        Me.cmbDatabases.Name = "cmbDatabases"
        Me.cmbDatabases.Size = New System.Drawing.Size(222, 21)
        Me.cmbDatabases.TabIndex = 7
        '
        'lblDbdetails
        '
        Me.lblDbdetails.AutoSize = True
        Me.lblDbdetails.ForeColor = System.Drawing.Color.Blue
        Me.lblDbdetails.Location = New System.Drawing.Point(218, 187)
        Me.lblDbdetails.Name = "lblDbdetails"
        Me.lblDbdetails.Size = New System.Drawing.Size(154, 13)
        Me.lblDbdetails.TabIndex = 8
        Me.lblDbdetails.Tag = ""
        Me.lblDbdetails.Text = "Manage database connections"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(218, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Tag = "Password"
        Me.Label1.Text = "&Database"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkRememberUsername
        '
        Me.chkRememberUsername.AutoSize = True
        Me.chkRememberUsername.Location = New System.Drawing.Point(220, 113)
        Me.chkRememberUsername.Name = "chkRememberUsername"
        Me.chkRememberUsername.Size = New System.Drawing.Size(126, 17)
        Me.chkRememberUsername.TabIndex = 11
        Me.chkRememberUsername.Text = "Remember username"
        Me.chkRememberUsername.UseVisualStyleBackColor = True
        '
        'frmLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(539, 251)
        Me.Controls.Add(Me.chkRememberUsername)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.lblDbdetails)
        Me.Controls.Add(Me.cmbDatabases)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.txtusrpwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Login"
        Me.Text = "Login"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtusrpwd As System.Windows.Forms.TextBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents cmbDatabases As ComboBox
    Friend WithEvents lblDbdetails As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkRememberUsername As CheckBox
End Class
