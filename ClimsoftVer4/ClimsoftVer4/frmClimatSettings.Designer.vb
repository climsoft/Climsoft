<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClimatSettings
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
        Me.TabParameters = New System.Windows.Forms.TabControl()
        Me.Parameters = New System.Windows.Forms.TabPage()
        Me.grpParameters = New System.Windows.Forms.GroupBox()
        Me.butGrant = New System.Windows.Forms.Button()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.DataGridViewParameters = New System.Windows.Forms.DataGridView()
        Me.FTP = New System.Windows.Forms.TabPage()
        Me.grpHeaders = New System.Windows.Forms.GroupBox()
        Me.lblTTAAii = New System.Windows.Forms.Label()
        Me.lblUTCdiff = New System.Windows.Forms.Label()
        Me.txtGTSdiff = New System.Windows.Forms.TextBox()
        Me.txtMsgHeader = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpMsgSwitch = New System.Windows.Forms.GroupBox()
        Me.txtOriginatingGeneratingCentre = New System.Windows.Forms.TextBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.cboFTP = New System.Windows.Forms.ComboBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.lblTransferMode = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.btnUpdates = New System.Windows.Forms.Button()
        Me.butClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.TabParameters.SuspendLayout()
        Me.Parameters.SuspendLayout()
        Me.grpParameters.SuspendLayout()
        CType(Me.DataGridViewParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FTP.SuspendLayout()
        Me.grpHeaders.SuspendLayout()
        Me.grpMsgSwitch.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabParameters
        '
        Me.TabParameters.Controls.Add(Me.Parameters)
        Me.TabParameters.Controls.Add(Me.FTP)
        Me.TabParameters.Location = New System.Drawing.Point(12, 12)
        Me.TabParameters.Name = "TabParameters"
        Me.TabParameters.SelectedIndex = 0
        Me.TabParameters.Size = New System.Drawing.Size(751, 393)
        Me.TabParameters.TabIndex = 1
        '
        'Parameters
        '
        Me.Parameters.Controls.Add(Me.grpParameters)
        Me.Parameters.Controls.Add(Me.DataGridViewParameters)
        Me.Parameters.Location = New System.Drawing.Point(4, 22)
        Me.Parameters.Name = "Parameters"
        Me.Parameters.Padding = New System.Windows.Forms.Padding(3)
        Me.Parameters.Size = New System.Drawing.Size(743, 367)
        Me.Parameters.TabIndex = 0
        Me.Parameters.Text = "Parameters"
        Me.Parameters.UseVisualStyleBackColor = True
        '
        'grpParameters
        '
        Me.grpParameters.BackColor = System.Drawing.Color.LightGray
        Me.grpParameters.Controls.Add(Me.butGrant)
        Me.grpParameters.Controls.Add(Me.butUpdate)
        Me.grpParameters.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpParameters.Location = New System.Drawing.Point(3, 333)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(737, 31)
        Me.grpParameters.TabIndex = 1
        Me.grpParameters.TabStop = False
        '
        'butGrant
        '
        Me.butGrant.Location = New System.Drawing.Point(256, 5)
        Me.butGrant.Name = "butGrant"
        Me.butGrant.Size = New System.Drawing.Size(225, 23)
        Me.butGrant.TabIndex = 16
        Me.butGrant.Text = "Grant User Permissions "
        Me.butGrant.UseVisualStyleBackColor = True
        '
        'butUpdate
        '
        Me.butUpdate.Location = New System.Drawing.Point(294, 5)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(84, 23)
        Me.butUpdate.TabIndex = 0
        Me.butUpdate.Text = "Update"
        Me.butUpdate.UseVisualStyleBackColor = True
        Me.butUpdate.Visible = False
        '
        'DataGridViewParameters
        '
        Me.DataGridViewParameters.AllowDrop = True
        Me.DataGridViewParameters.AllowUserToAddRows = False
        Me.DataGridViewParameters.AllowUserToDeleteRows = False
        Me.DataGridViewParameters.AllowUserToResizeColumns = False
        Me.DataGridViewParameters.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.DataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewParameters.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewParameters.Name = "DataGridViewParameters"
        Me.DataGridViewParameters.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewParameters.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DataGridViewParameters.Size = New System.Drawing.Size(735, 350)
        Me.DataGridViewParameters.TabIndex = 0
        '
        'FTP
        '
        Me.FTP.Controls.Add(Me.grpHeaders)
        Me.FTP.Controls.Add(Me.grpMsgSwitch)
        Me.FTP.Location = New System.Drawing.Point(4, 22)
        Me.FTP.Name = "FTP"
        Me.FTP.Padding = New System.Windows.Forms.Padding(3)
        Me.FTP.Size = New System.Drawing.Size(743, 367)
        Me.FTP.TabIndex = 1
        Me.FTP.Text = "FTP"
        Me.FTP.UseVisualStyleBackColor = True
        '
        'grpHeaders
        '
        Me.grpHeaders.BackColor = System.Drawing.Color.Gainsboro
        Me.grpHeaders.Controls.Add(Me.lblTTAAii)
        Me.grpHeaders.Controls.Add(Me.lblUTCdiff)
        Me.grpHeaders.Controls.Add(Me.txtGTSdiff)
        Me.grpHeaders.Controls.Add(Me.txtMsgHeader)
        Me.grpHeaders.Controls.Add(Me.Label7)
        Me.grpHeaders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpHeaders.Location = New System.Drawing.Point(99, 24)
        Me.grpHeaders.Name = "grpHeaders"
        Me.grpHeaders.Size = New System.Drawing.Size(548, 44)
        Me.grpHeaders.TabIndex = 30
        Me.grpHeaders.TabStop = False
        Me.grpHeaders.Text = "Message Headers Details"
        '
        'lblTTAAii
        '
        Me.lblTTAAii.AutoSize = True
        Me.lblTTAAii.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTTAAii.Location = New System.Drawing.Point(16, 21)
        Me.lblTTAAii.Name = "lblTTAAii"
        Me.lblTTAAii.Size = New System.Drawing.Size(144, 13)
        Me.lblTTAAii.TabIndex = 17
        Me.lblTTAAii.Text = "Header (T1T2A1A2ii  CCCC )"
        '
        'lblUTCdiff
        '
        Me.lblUTCdiff.AutoSize = True
        Me.lblUTCdiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUTCdiff.Location = New System.Drawing.Point(353, 21)
        Me.lblUTCdiff.Name = "lblUTCdiff"
        Me.lblUTCdiff.Size = New System.Drawing.Size(107, 13)
        Me.lblUTCdiff.TabIndex = 18
        Me.lblUTCdiff.Text = "UTC Time Difference"
        '
        'txtGTSdiff
        '
        Me.txtGTSdiff.Location = New System.Drawing.Point(494, 17)
        Me.txtGTSdiff.Name = "txtGTSdiff"
        Me.txtGTSdiff.Size = New System.Drawing.Size(36, 20)
        Me.txtGTSdiff.TabIndex = 1
        Me.txtGTSdiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(182, 17)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(150, 20)
        Me.txtMsgHeader.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(988, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Tag = "Template"
        Me.Label7.Text = "Template"
        '
        'grpMsgSwitch
        '
        Me.grpMsgSwitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpMsgSwitch.Controls.Add(Me.txtOriginatingGeneratingCentre)
        Me.grpMsgSwitch.Controls.Add(Me.cmdUpdate)
        Me.grpMsgSwitch.Controls.Add(Me.txtConfirmPassword)
        Me.grpMsgSwitch.Controls.Add(Me.txtPassword)
        Me.grpMsgSwitch.Controls.Add(Me.txtLogin)
        Me.grpMsgSwitch.Controls.Add(Me.txtFolder)
        Me.grpMsgSwitch.Controls.Add(Me.cboFTP)
        Me.grpMsgSwitch.Controls.Add(Me.txtServer)
        Me.grpMsgSwitch.Controls.Add(Me.lblConfirmPassword)
        Me.grpMsgSwitch.Controls.Add(Me.lblPassword)
        Me.grpMsgSwitch.Controls.Add(Me.lblLogin)
        Me.grpMsgSwitch.Controls.Add(Me.lblFolder)
        Me.grpMsgSwitch.Controls.Add(Me.lblTransferMode)
        Me.grpMsgSwitch.Controls.Add(Me.lblServer)
        Me.grpMsgSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMsgSwitch.Location = New System.Drawing.Point(99, 74)
        Me.grpMsgSwitch.Name = "grpMsgSwitch"
        Me.grpMsgSwitch.Size = New System.Drawing.Size(548, 280)
        Me.grpMsgSwitch.TabIndex = 31
        Me.grpMsgSwitch.TabStop = False
        Me.grpMsgSwitch.Text = "Message Server Details"
        '
        'txtOriginatingGeneratingCentre
        '
        Me.txtOriginatingGeneratingCentre.Location = New System.Drawing.Point(626, 35)
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        Me.txtOriginatingGeneratingCentre.Size = New System.Drawing.Size(55, 20)
        Me.txtOriginatingGeneratingCentre.TabIndex = 16
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(313, 233)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 22)
        Me.cmdUpdate.TabIndex = 26
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        Me.cmdUpdate.Visible = False
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(262, 205)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtConfirmPassword.TabIndex = 7
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(261, 176)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtPassword.TabIndex = 6
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(262, 145)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(157, 20)
        Me.txtLogin.TabIndex = 5
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(262, 115)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(157, 20)
        Me.txtFolder.TabIndex = 4
        '
        'cboFTP
        '
        Me.cboFTP.FormattingEnabled = True
        Me.cboFTP.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.cboFTP.Location = New System.Drawing.Point(262, 84)
        Me.cboFTP.Name = "cboFTP"
        Me.cboFTP.Size = New System.Drawing.Size(114, 21)
        Me.cboFTP.TabIndex = 3
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(262, 54)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(156, 20)
        Me.txtServer.TabIndex = 2
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPassword.Location = New System.Drawing.Point(103, 209)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmPassword.TabIndex = 25
        Me.lblConfirmPassword.Text = "Confirm Password"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(103, 179)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 24
        Me.lblPassword.Text = "Password"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(103, 149)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(60, 13)
        Me.lblLogin.TabIndex = 23
        Me.lblLogin.Text = "User Name"
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder.Location = New System.Drawing.Point(103, 119)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(63, 13)
        Me.lblFolder.TabIndex = 22
        Me.lblFolder.Text = "Input Folder"
        '
        'lblTransferMode
        '
        Me.lblTransferMode.AutoSize = True
        Me.lblTransferMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferMode.Location = New System.Drawing.Point(103, 88)
        Me.lblTransferMode.Name = "lblTransferMode"
        Me.lblTransferMode.Size = New System.Drawing.Size(57, 13)
        Me.lblTransferMode.TabIndex = 21
        Me.lblTransferMode.Text = "FTP Mode"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServer.Location = New System.Drawing.Point(103, 58)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(112, 13)
        Me.lblServer.TabIndex = 20
        Me.lblServer.Text = "Server Address/Name"
        '
        'btnUpdates
        '
        Me.btnUpdates.Location = New System.Drawing.Point(289, 407)
        Me.btnUpdates.Name = "btnUpdates"
        Me.btnUpdates.Size = New System.Drawing.Size(88, 23)
        Me.btnUpdates.TabIndex = 8
        Me.btnUpdates.Text = "Update"
        Me.btnUpdates.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Location = New System.Drawing.Point(402, 407)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(75, 23)
        Me.butClose.TabIndex = 9
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(501, 407)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(72, 23)
        Me.btnHelp.TabIndex = 10
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(171, 407)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(100, 23)
        Me.btnAddNew.TabIndex = 11
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        Me.btnAddNew.Visible = False
        '
        'frmClimatSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 434)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.btnUpdates)
        Me.Controls.Add(Me.TabParameters)
        Me.Name = "frmClimatSettings"
        Me.Text = "Climat Settings"
        Me.TabParameters.ResumeLayout(False)
        Me.Parameters.ResumeLayout(False)
        Me.grpParameters.ResumeLayout(False)
        CType(Me.DataGridViewParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FTP.ResumeLayout(False)
        Me.grpHeaders.ResumeLayout(False)
        Me.grpHeaders.PerformLayout()
        Me.grpMsgSwitch.ResumeLayout(False)
        Me.grpMsgSwitch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabParameters As TabControl
    Friend WithEvents Parameters As TabPage
    Friend WithEvents DataGridViewParameters As DataGridView
    Friend WithEvents FTP As TabPage
    Friend WithEvents grpParameters As GroupBox
    Friend WithEvents grpMsgSwitch As GroupBox
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents txtConfirmPassword As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLogin As TextBox
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents cboFTP As ComboBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents lblConfirmPassword As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblLogin As Label
    Friend WithEvents lblFolder As Label
    Friend WithEvents lblTransferMode As Label
    Friend WithEvents lblServer As Label
    Friend WithEvents grpHeaders As GroupBox
    Friend WithEvents txtMsgHeader As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtOriginatingGeneratingCentre As TextBox
    Friend WithEvents lblTTAAii As Label
    Friend WithEvents lblUTCdiff As Label
    Friend WithEvents txtGTSdiff As TextBox
    Friend WithEvents butGrant As Button
    Friend WithEvents butUpdate As Button
    Friend WithEvents btnUpdates As Button
    Friend WithEvents butClose As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnAddNew As Button
End Class
