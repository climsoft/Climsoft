<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserManagement
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
        Me.linkAddNewUser = New System.Windows.Forms.LinkLabel()
        Me.linkUpdateUser = New System.Windows.Forms.LinkLabel()
        Me.linkDeleteUser = New System.Windows.Forms.LinkLabel()
        Me.linkHelp = New System.Windows.Forms.LinkLabel()
        Me.lstViewUsers = New System.Windows.Forms.ListView()
        Me.userName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.userRole = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.linkClose = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'linkAddNewUser
        '
        Me.linkAddNewUser.AutoSize = True
        Me.linkAddNewUser.Location = New System.Drawing.Point(316, 17)
        Me.linkAddNewUser.Name = "linkAddNewUser"
        Me.linkAddNewUser.Size = New System.Drawing.Size(72, 13)
        Me.linkAddNewUser.TabIndex = 16
        Me.linkAddNewUser.TabStop = True
        Me.linkAddNewUser.Text = "Add new user"
        '
        'linkUpdateUser
        '
        Me.linkUpdateUser.AutoSize = True
        Me.linkUpdateUser.Location = New System.Drawing.Point(316, 46)
        Me.linkUpdateUser.Name = "linkUpdateUser"
        Me.linkUpdateUser.Size = New System.Drawing.Size(108, 13)
        Me.linkUpdateUser.TabIndex = 17
        Me.linkUpdateUser.TabStop = True
        Me.linkUpdateUser.Text = "Update selected user"
        '
        'linkDeleteUser
        '
        Me.linkDeleteUser.AutoSize = True
        Me.linkDeleteUser.Location = New System.Drawing.Point(316, 75)
        Me.linkDeleteUser.Name = "linkDeleteUser"
        Me.linkDeleteUser.Size = New System.Drawing.Size(115, 13)
        Me.linkDeleteUser.TabIndex = 18
        Me.linkDeleteUser.TabStop = True
        Me.linkDeleteUser.Text = "Delete selected user(s)"
        '
        'linkHelp
        '
        Me.linkHelp.AutoSize = True
        Me.linkHelp.Location = New System.Drawing.Point(316, 107)
        Me.linkHelp.Name = "linkHelp"
        Me.linkHelp.Size = New System.Drawing.Size(29, 13)
        Me.linkHelp.TabIndex = 19
        Me.linkHelp.TabStop = True
        Me.linkHelp.Text = "Help"
        '
        'lstViewUsers
        '
        Me.lstViewUsers.AllowColumnReorder = True
        Me.lstViewUsers.AllowDrop = True
        Me.lstViewUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.userName, Me.userRole})
        Me.lstViewUsers.FullRowSelect = True
        Me.lstViewUsers.GridLines = True
        Me.lstViewUsers.HideSelection = False
        Me.lstViewUsers.Location = New System.Drawing.Point(6, 7)
        Me.lstViewUsers.Name = "lstViewUsers"
        Me.lstViewUsers.RightToLeftLayout = True
        Me.lstViewUsers.Scrollable = False
        Me.lstViewUsers.Size = New System.Drawing.Size(302, 235)
        Me.lstViewUsers.TabIndex = 20
        Me.lstViewUsers.UseCompatibleStateImageBehavior = False
        Me.lstViewUsers.View = System.Windows.Forms.View.Details
        '
        'userName
        '
        Me.userName.Text = "Username"
        Me.userName.Width = 148
        '
        'userRole
        '
        Me.userRole.Text = "User Role"
        Me.userRole.Width = 500
        '
        'linkClose
        '
        Me.linkClose.AutoSize = True
        Me.linkClose.Location = New System.Drawing.Point(316, 139)
        Me.linkClose.Name = "linkClose"
        Me.linkClose.Size = New System.Drawing.Size(33, 13)
        Me.linkClose.TabIndex = 21
        Me.linkClose.TabStop = True
        Me.linkClose.Text = "Close"
        '
        'frmUserManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 246)
        Me.Controls.Add(Me.linkClose)
        Me.Controls.Add(Me.lstViewUsers)
        Me.Controls.Add(Me.linkHelp)
        Me.Controls.Add(Me.linkDeleteUser)
        Me.Controls.Add(Me.linkUpdateUser)
        Me.Controls.Add(Me.linkAddNewUser)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserManagement"
        Me.Text = "User Management"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents linkAddNewUser As LinkLabel
    Friend WithEvents linkUpdateUser As LinkLabel
    Friend WithEvents linkDeleteUser As LinkLabel
    Friend WithEvents linkHelp As LinkLabel
    Public WithEvents lstViewUsers As ListView
    Friend WithEvents userName As ColumnHeader
    Friend WithEvents userRole As ColumnHeader
    Friend WithEvents linkClose As LinkLabel
End Class
