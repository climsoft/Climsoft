<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMonth
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
        Me.cmsMonth = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsMonthIDs = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsMonthNames = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsMonthShortMonthNames = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMonth.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsMonth
        '
        Me.cmsMonth.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsMonthIDs, Me.cmsMonthNames, Me.cmsMonthShortMonthNames})
        Me.cmsMonth.Name = "cmsYear"
        Me.cmsMonth.Size = New System.Drawing.Size(210, 70)
        '
        'cmsMonthIDs
        '
        Me.cmsMonthIDs.Checked = True
        Me.cmsMonthIDs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmsMonthIDs.Name = "cmsMonthIDs"
        Me.cmsMonthIDs.Size = New System.Drawing.Size(209, 22)
        Me.cmsMonthIDs.Text = "View Month IDs"
        '
        'cmsMonthNames
        '
        Me.cmsMonthNames.Name = "cmsMonthNames"
        Me.cmsMonthNames.Size = New System.Drawing.Size(209, 22)
        Me.cmsMonthNames.Text = "View Month Names"
        '
        'cmsMonthShortMonthNames
        '
        Me.cmsMonthShortMonthNames.Name = "cmsMonthShortMonthNames"
        Me.cmsMonthShortMonthNames.Size = New System.Drawing.Size(209, 22)
        Me.cmsMonthShortMonthNames.Text = "View Short Month Names"
        '
        'ucrMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ucrMonth"
        Me.Size = New System.Drawing.Size(676, 473)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMonth.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsMonth As ContextMenuStrip
    Friend WithEvents cmsMonthNames As ToolStripMenuItem
    Friend WithEvents cmsMonthIDs As ToolStripMenuItem
    Friend WithEvents cmsMonthShortMonthNames As ToolStripMenuItem
End Class
