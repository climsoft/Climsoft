<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDatabaseConnect
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
        Me.ServerIP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.userName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDatabaseConnect = New System.Windows.Forms.Button()
        Me.passWord = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.databaseName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ServerIP
        '
        Me.ServerIP.Location = New System.Drawing.Point(160, 26)
        Me.ServerIP.Name = "ServerIP"
        Me.ServerIP.Size = New System.Drawing.Size(162, 20)
        Me.ServerIP.TabIndex = 7
        Me.ServerIP.Text = "localhost"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database Server"
        '
        'userName
        '
        Me.userName.Location = New System.Drawing.Point(160, 114)
        Me.userName.Name = "userName"
        Me.userName.Size = New System.Drawing.Size(162, 20)
        Me.userName.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Username"
        '
        'btnDatabaseConnect
        '
        Me.btnDatabaseConnect.Location = New System.Drawing.Point(160, 208)
        Me.btnDatabaseConnect.Name = "btnDatabaseConnect"
        Me.btnDatabaseConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnDatabaseConnect.TabIndex = 4
        Me.btnDatabaseConnect.Text = "Connect"
        Me.btnDatabaseConnect.UseVisualStyleBackColor = True
        '
        'passWord
        '
        Me.passWord.Location = New System.Drawing.Point(160, 157)
        Me.passWord.Name = "passWord"
        Me.passWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passWord.Size = New System.Drawing.Size(162, 20)
        Me.passWord.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(246, 208)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'databaseName
        '
        Me.databaseName.Location = New System.Drawing.Point(160, 72)
        Me.databaseName.Name = "databaseName"
        Me.databaseName.Size = New System.Drawing.Size(161, 20)
        Me.databaseName.TabIndex = 8
        Me.databaseName.Text = "mysql_climsoft_db_v4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Database Name"
        '
        'formDatabaseConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 259)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.databaseName)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.passWord)
        Me.Controls.Add(Me.btnDatabaseConnect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.userName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ServerIP)
        Me.MaximizeBox = False
        Me.Name = "formDatabaseConnect"
        Me.Text = "Connection to MySQL Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ServerIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents userName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDatabaseConnect As System.Windows.Forms.Button
    Friend WithEvents passWord As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents databaseName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
