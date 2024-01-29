<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFormDaily2
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
        Me.ucrFormDaily = New ClimsoftVer4.ucrFormDaily2()
        Me.SuspendLayout()
        '
        'ucrFormDaily
        '
        Me.ucrFormDaily.Location = New System.Drawing.Point(8, 7)
        Me.ucrFormDaily.Name = "ucrFormDaily"
        Me.ucrFormDaily.Size = New System.Drawing.Size(762, 612)
        Me.ucrFormDaily.TabIndex = 5
        '
        'frmNewFormDaily2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 631)
        Me.Controls.Add(Me.ucrFormDaily)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewFormDaily2"
        Me.Text = "Daily data for the whole month"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrFormDaily As ucrFormDaily2
End Class
