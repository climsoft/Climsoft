<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewHourly
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
        Me.ucrHourly = New ClimsoftVer4.ucrHourly()
        Me.SuspendLayout()
        '
        'ucrHourly
        '
        Me.ucrHourly.Location = New System.Drawing.Point(143, 172)
        Me.ucrHourly.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.ucrHourly.Name = "ucrHourly"
        Me.ucrHourly.Size = New System.Drawing.Size(882, 781)
        Me.ucrHourly.TabIndex = 5
        '
        'frmNewHourly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 794)
        Me.Controls.Add(Me.ucrHourly)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmNewHourly"
        Me.Text = "Hourly Data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrHourly As ucrHourly
End Class
