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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formDatabaseConnect))
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
        resources.ApplyResources(Me.userName, "userName")
        Me.userName.Name = "userName"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnDatabaseConnect
        '
        resources.ApplyResources(Me.btnDatabaseConnect, "btnDatabaseConnect")
        Me.btnDatabaseConnect.Name = "btnDatabaseConnect"
        Me.btnDatabaseConnect.UseVisualStyleBackColor = True
        '
        'passWord
        '
        resources.ApplyResources(Me.passWord, "passWord")
        Me.passWord.Name = "passWord"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtDbParameters
        '
        resources.ApplyResources(Me.txtDbParameters, "txtDbParameters")
        Me.txtDbParameters.Name = "txtDbParameters"
        '
        'formDatabaseConnect
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDbParameters)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.passWord)
        Me.Controls.Add(Me.btnDatabaseConnect)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.userName)
        Me.MaximizeBox = False
        Me.Name = "formDatabaseConnect"
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
