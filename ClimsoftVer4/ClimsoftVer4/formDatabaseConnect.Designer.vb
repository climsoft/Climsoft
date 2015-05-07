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
        Me.userName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnDatabaseConnect = New System.Windows.Forms.Button()
        Me.passWord = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtDbParameters = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'userName
        '
        Me.userName.Location = New System.Drawing.Point(160, 49)
        Me.userName.Name = "userName"
        Me.userName.Size = New System.Drawing.Size(162, 20)
        Me.userName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Username"
        '
        'btnDatabaseConnect
        '
        Me.btnDatabaseConnect.Location = New System.Drawing.Point(160, 127)
        Me.btnDatabaseConnect.Name = "btnDatabaseConnect"
        Me.btnDatabaseConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnDatabaseConnect.TabIndex = 4
        Me.btnDatabaseConnect.Text = "Connect"
        Me.btnDatabaseConnect.UseVisualStyleBackColor = True
        '
        'passWord
        '
        Me.passWord.Location = New System.Drawing.Point(160, 92)
        Me.passWord.Name = "passWord"
        Me.passWord.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.passWord.Size = New System.Drawing.Size(162, 20)
        Me.passWord.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(52, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Password"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(246, 127)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtDbParameters
        '
        Me.txtDbParameters.Location = New System.Drawing.Point(160, 12)
        Me.txtDbParameters.Name = "txtDbParameters"
        Me.txtDbParameters.Size = New System.Drawing.Size(162, 20)
        Me.txtDbParameters.TabIndex = 12
        Me.txtDbParameters.Visible = False
        '
        'formDatabaseConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 172)
        Me.Controls.Add(Me.txtDbParameters)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.passWord)
        Me.Controls.Add(Me.btnDatabaseConnect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.userName)
        Me.MaximizeBox = False
        Me.Name = "formDatabaseConnect"
        Me.Text = "Connection to MySQL Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents userName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDatabaseConnect As System.Windows.Forms.Button
    Friend WithEvents passWord As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtDbParameters As System.Windows.Forms.TextBox

End Class
