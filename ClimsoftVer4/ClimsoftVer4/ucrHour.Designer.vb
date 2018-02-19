<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrHour
    Inherits ClimsoftVer4.ucrDataLinkCombobox

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmsHour = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsHour24 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsHour12 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsHour.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsHour
        '
        Me.cmsHour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsHour24, Me.cmsHour12})
        Me.cmsHour.Name = "cmsYear"
        Me.cmsHour.Size = New System.Drawing.Size(158, 48)
        '
        'cmsHour24
        '
        Me.cmsHour24.Checked = True
        Me.cmsHour24.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmsHour24.Name = "cmsHour24"
        Me.cmsHour24.Size = New System.Drawing.Size(157, 22)
        Me.cmsHour24.Text = "View in 24hours"
        '
        'cmsHour12
        '
        Me.cmsHour12.Name = "cmsHour12"
        Me.cmsHour12.Size = New System.Drawing.Size(157, 22)
        Me.cmsHour12.Text = "View in 12hrs"
        '
        'ucrHour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ucrHour"
        Me.Size = New System.Drawing.Size(139, 25)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsHour.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsHour As ContextMenuStrip
    Friend WithEvents cmsHour24 As ToolStripMenuItem
    Friend WithEvents cmsHour12 As ToolStripMenuItem
End Class
