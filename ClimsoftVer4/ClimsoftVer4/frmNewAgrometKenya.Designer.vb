<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewAgrometKenya
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
        Me.UcrKenyaAgromet1 = New ClimsoftVer4.ucrKenyaAgromet()
        Me.SuspendLayout()
        '
        'UcrKenyaAgromet1
        '
        Me.UcrKenyaAgromet1.Location = New System.Drawing.Point(7, 8)
        Me.UcrKenyaAgromet1.Name = "UcrKenyaAgromet1"
        Me.UcrKenyaAgromet1.Size = New System.Drawing.Size(910, 579)
        Me.UcrKenyaAgromet1.TabIndex = 0
        '
        'frmNewAgrometKenya
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 598)
        Me.Controls.Add(Me.UcrKenyaAgromet1)
        Me.MaximizeBox = False
        Me.Name = "frmNewAgrometKenya"
        Me.Text = "Agromet Kenya"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcrKenyaAgromet1 As ucrKenyaAgromet
End Class
