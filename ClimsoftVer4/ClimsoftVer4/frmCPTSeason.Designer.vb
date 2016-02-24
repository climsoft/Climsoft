<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCPTSeason
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCPTSeason))
        Me.grpCommands = New System.Windows.Forms.GroupBox()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblStartMonth = New System.Windows.Forms.Label()
        Me.cmbStartMonth = New System.Windows.Forms.ComboBox()
        Me.cmbEndMonth = New System.Windows.Forms.ComboBox()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.grpCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCommands
        '
        Me.grpCommands.Controls.Add(Me.cmdHelp)
        Me.grpCommands.Controls.Add(Me.cmdCancel)
        Me.grpCommands.Controls.Add(Me.cmdOK)
        resources.ApplyResources(Me.grpCommands, "grpCommands")
        Me.grpCommands.Name = "grpCommands"
        Me.grpCommands.TabStop = False
        '
        'cmdHelp
        '
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        resources.ApplyResources(Me.cmdOK, "cmdOK")
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblStartMonth
        '
        resources.ApplyResources(Me.lblStartMonth, "lblStartMonth")
        Me.lblStartMonth.Name = "lblStartMonth"
        '
        'cmbStartMonth
        '
        Me.cmbStartMonth.FormattingEnabled = True
        Me.cmbStartMonth.Items.AddRange(New Object() {resources.GetString("cmbStartMonth.Items"), resources.GetString("cmbStartMonth.Items1"), resources.GetString("cmbStartMonth.Items2"), resources.GetString("cmbStartMonth.Items3"), resources.GetString("cmbStartMonth.Items4"), resources.GetString("cmbStartMonth.Items5"), resources.GetString("cmbStartMonth.Items6"), resources.GetString("cmbStartMonth.Items7"), resources.GetString("cmbStartMonth.Items8"), resources.GetString("cmbStartMonth.Items9"), resources.GetString("cmbStartMonth.Items10"), resources.GetString("cmbStartMonth.Items11")})
        resources.ApplyResources(Me.cmbStartMonth, "cmbStartMonth")
        Me.cmbStartMonth.Name = "cmbStartMonth"
        '
        'cmbEndMonth
        '
        Me.cmbEndMonth.FormattingEnabled = True
        Me.cmbEndMonth.Items.AddRange(New Object() {resources.GetString("cmbEndMonth.Items"), resources.GetString("cmbEndMonth.Items1"), resources.GetString("cmbEndMonth.Items2"), resources.GetString("cmbEndMonth.Items3"), resources.GetString("cmbEndMonth.Items4"), resources.GetString("cmbEndMonth.Items5"), resources.GetString("cmbEndMonth.Items6"), resources.GetString("cmbEndMonth.Items7"), resources.GetString("cmbEndMonth.Items8"), resources.GetString("cmbEndMonth.Items9"), resources.GetString("cmbEndMonth.Items10"), resources.GetString("cmbEndMonth.Items11")})
        resources.ApplyResources(Me.cmbEndMonth, "cmbEndMonth")
        Me.cmbEndMonth.Name = "cmbEndMonth"
        '
        'lblEndMonth
        '
        resources.ApplyResources(Me.lblEndMonth, "lblEndMonth")
        Me.lblEndMonth.Name = "lblEndMonth"
        '
        'frmCPTSeason
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbEndMonth)
        Me.Controls.Add(Me.lblEndMonth)
        Me.Controls.Add(Me.cmbStartMonth)
        Me.Controls.Add(Me.lblStartMonth)
        Me.Controls.Add(Me.grpCommands)
        Me.Name = "frmCPTSeason"
        Me.grpCommands.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpCommands As System.Windows.Forms.GroupBox
    Friend WithEvents lblStartMonth As System.Windows.Forms.Label
    Friend WithEvents cmbStartMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEndMonth As System.Windows.Forms.ComboBox
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
End Class
