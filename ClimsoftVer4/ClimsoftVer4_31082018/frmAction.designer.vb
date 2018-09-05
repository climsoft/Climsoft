<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAction))
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.SuspendLayout()
        '
        'cmdHelp
        '
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        Me.HelpProvider1.SetShowHelp(Me.cmdHelp, CType(resources.GetObject("cmdHelp.ShowHelp"), Boolean))
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Name = "cmdCancel"
        Me.HelpProvider1.SetShowHelp(Me.cmdCancel, CType(resources.GetObject("cmdCancel.ShowHelp"), Boolean))
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.HelpProvider1.SetShowHelp(Me.cmdOk, CType(resources.GetObject("cmdOk.ShowHelp"), Boolean))
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.HelpProvider1.SetShowHelp(Me.cmdApply, CType(resources.GetObject("cmdApply.ShowHelp"), Boolean))
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'frmAction
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Name = "frmAction"
        Me.HelpProvider1.SetShowHelp(Me, CType(resources.GetObject("$this.ShowHelp"), Boolean))
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
End Class
