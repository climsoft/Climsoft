<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrBaseDataLink
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.cmsViewOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsSortBy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsViewOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsViewOptions
        '
        Me.cmsViewOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSortBy})
        Me.cmsViewOptions.Name = "cmsStationOptions"
        Me.cmsViewOptions.Size = New System.Drawing.Size(115, 26)
        Me.cmsViewOptions.Text = "Station Names"
        '
        'tsSortBy
        '
        Me.tsSortBy.Name = "tsSortBy"
        Me.tsSortBy.Size = New System.Drawing.Size(114, 22)
        Me.tsSortBy.Text = "Sort By:"
        '
        'ucrBaseDataLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "ucrBaseDataLink"
        Me.cmsViewOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsViewOptions As ContextMenuStrip
    Friend WithEvents tsSortBy As ToolStripMenuItem
End Class
