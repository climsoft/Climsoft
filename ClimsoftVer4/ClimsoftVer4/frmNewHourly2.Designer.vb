<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewHourly2
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
        Me.ucrFormHourly2 = New ClimsoftVer4.ucrFormHourly2()
        Me.SuspendLayout()
        '
        'ucrFormHourly2
        '
        Me.ucrFormHourly2.Location = New System.Drawing.Point(8, 7)
        Me.ucrFormHourly2.Margin = New System.Windows.Forms.Padding(4)
        Me.ucrFormHourly2.Name = "ucrFormHourly2"
        Me.ucrFormHourly2.Size = New System.Drawing.Size(803, 598)
        Me.ucrFormHourly2.TabIndex = 0
        '
        'frmNewHourly2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(816, 612)
        Me.Controls.Add(Me.ucrFormHourly2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewHourly2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Hourly data for the whole month"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrFormHourly2 As ucrFormHourly2
End Class
