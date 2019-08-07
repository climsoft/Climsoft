<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewHourlyWind
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
        Me.UcrHourlyWind1 = New ClimsoftVer4.ucrHourlyWind()
        Me.SuspendLayout()
        '
        'UcrHourlyWind1
        '
        Me.UcrHourlyWind1.Location = New System.Drawing.Point(9, 10)
        Me.UcrHourlyWind1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrHourlyWind1.Name = "UcrHourlyWind1"
        Me.UcrHourlyWind1.Size = New System.Drawing.Size(639, 579)
        Me.UcrHourlyWind1.TabIndex = 0
        '
        'frmNewHourlyWind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 596)
        Me.Controls.Add(Me.UcrHourlyWind1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewHourlyWind"
        Me.Text = "Hourly wind data"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UcrHourlyWind1 As ucrHourlyWind
End Class
