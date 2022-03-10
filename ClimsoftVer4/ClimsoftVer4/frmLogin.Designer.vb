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
    Friend WithEvents pictureBoxLogo As System.Windows.Forms.PictureBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.pictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.txtusrpwd = New System.Windows.Forms.TextBox()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cboDatabases = New System.Windows.Forms.ComboBox()
        Me.lblDbdetails = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkRememberUsername = New System.Windows.Forms.CheckBox()
        Me.linkLabelLanguage = New System.Windows.Forms.Label()
        Me.lblLanguage = New System.Windows.Forms.Label()
        CType(Me.pictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBoxLogo
        '
        Me.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBoxLogo.Image = CType(resources.GetObject("pictureBoxLogo.Image"), System.Drawing.Image)
        Me.pictureBoxLogo.Location = New System.Drawing.Point(0, 17)
        Me.pictureBoxLogo.Name = "pictureBoxLogo"
        Me.pictureBoxLogo.Size = New System.Drawing.Size(199, 251)
        Me.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxLogo.TabIndex = 0
        Me.pictureBoxLogo.TabStop = False
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
        Me.OK.Location = New System.Drawing.Point(219, 254)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(67, 23)
        Me.OK.TabIndex = 4
        Me.OK.Tag = "OK"
        Me.OK.Text = "&OK"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(322, 254)
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
        Me.cmdHelp.Location = New System.Drawing.Point(425, 254)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(67, 23)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Tag = "Help"
        Me.cmdHelp.Text = "&Help"
        Me.cmdHelp.Visible = False
        '
        'cboDatabases
        '
        Me.cboDatabases.BackColor = System.Drawing.SystemColors.Menu
        Me.cboDatabases.FormattingEnabled = True
        Me.cboDatabases.Location = New System.Drawing.Point(218, 162)
        Me.cboDatabases.Name = "cboDatabases"
        Me.cboDatabases.Size = New System.Drawing.Size(222, 21)
        Me.cboDatabases.TabIndex = 7
        '
        'lblDbdetails
        '
        Me.lblDbdetails.AutoSize = True
        Me.lblDbdetails.Cursor = System.Windows.Forms.Cursors.Hand
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
        'linkLabelLanguage
        '
        Me.linkLabelLanguage.AutoSize = True
        Me.linkLabelLanguage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.linkLabelLanguage.ForeColor = System.Drawing.Color.Blue
        Me.linkLabelLanguage.Location = New System.Drawing.Point(361, 214)
        Me.linkLabelLanguage.Name = "linkLabelLanguage"
        Me.linkLabelLanguage.Size = New System.Drawing.Size(55, 13)
        Me.linkLabelLanguage.TabIndex = 12
        Me.linkLabelLanguage.Tag = ""
        Me.linkLabelLanguage.Text = "Language"
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(218, 214)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(91, 13)
        Me.lblLanguage.TabIndex = 13
        Me.lblLanguage.Tag = "Password"
        Me.lblLanguage.Text = "Change language"
        Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmLogin
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(539, 287)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.linkLabelLanguage)
        Me.Controls.Add(Me.chkRememberUsername)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.lblDbdetails)
        Me.Controls.Add(Me.cboDatabases)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.pictureBoxLogo)
        Me.Controls.Add(Me.txtusrpwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Login"
        Me.Text = "Login"
        CType(Me.pictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtusrpwd As System.Windows.Forms.TextBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cboDatabases As ComboBox
    Friend WithEvents lblDbdetails As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkRememberUsername As CheckBox
    Friend WithEvents linkLabelLanguage As Label
    Friend WithEvents lblLanguage As Label
End Class
