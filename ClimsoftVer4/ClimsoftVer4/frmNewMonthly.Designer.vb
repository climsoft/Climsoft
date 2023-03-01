<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewMonthly
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
        Me.ucrMonthlydata = New ClimsoftVer4.ucrMonthlyData()
        Me.SuspendLayout()
        '
        'ucrMonthlydata
        '
        Me.ucrMonthlydata.Location = New System.Drawing.Point(3, 6)
        Me.ucrMonthlydata.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrMonthlydata.Name = "ucrMonthlydata"
        Me.ucrMonthlydata.Size = New System.Drawing.Size(751, 612)
        Me.ucrMonthlydata.TabIndex = 4
        '
        'frmNewMonthly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 624)
        Me.Controls.Add(Me.ucrMonthlydata)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewMonthly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monthly Data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrMonthlydata As ucrMonthlydata
End Class
