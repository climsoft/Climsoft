<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSynopticRA1
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ucrSynopticRA1 = New ClimsoftVer4.ucrSynopticRA1()
        Me.SuspendLayout()
        '
        'ucrSynopticRA1
        '
        Me.ucrSynopticRA1.Location = New System.Drawing.Point(7, 6)
        Me.ucrSynopticRA1.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrSynopticRA1.Name = "ucrSynopticRA1"
        Me.ucrSynopticRA1.Size = New System.Drawing.Size(842, 660)
        Me.ucrSynopticRA1.TabIndex = 5
        '
        'frmNewSynopticRA1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 674)
        Me.Controls.Add(Me.ucrSynopticRA1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewSynopticRA1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Synoptic data for input into TDCF form for RA1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrSynopticRA1 As ucrSynopticRA1
End Class
