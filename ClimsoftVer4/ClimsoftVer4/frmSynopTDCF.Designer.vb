<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynopTDCF
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
        Me.TabProcessing = New System.Windows.Forms.TabControl()
        Me.TabProcess = New System.Windows.Forms.TabPage()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdViewDecsriptors = New System.Windows.Forms.Button()
        Me.cmdEncode = New System.Windows.Forms.Button()
        Me.TabSettings = New System.Windows.Forms.TabPage()
        Me.TabHelp = New System.Windows.Forms.TabPage()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.TabProcessing.SuspendLayout()
        Me.TabProcess.SuspendLayout()
        Me.TabSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabProcessing
        '
        Me.TabProcessing.Controls.Add(Me.TabProcess)
        Me.TabProcessing.Controls.Add(Me.TabSettings)
        Me.TabProcessing.Controls.Add(Me.TabHelp)
        Me.TabProcessing.Location = New System.Drawing.Point(3, 2)
        Me.TabProcessing.Name = "TabProcessing"
        Me.TabProcessing.SelectedIndex = 0
        Me.TabProcessing.Size = New System.Drawing.Size(752, 437)
        Me.TabProcessing.TabIndex = 0
        '
        'TabProcess
        '
        Me.TabProcess.Controls.Add(Me.cmdClose)
        Me.TabProcess.Controls.Add(Me.cmdViewDecsriptors)
        Me.TabProcess.Controls.Add(Me.cmdEncode)
        Me.TabProcess.Location = New System.Drawing.Point(4, 22)
        Me.TabProcess.Name = "TabProcess"
        Me.TabProcess.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProcess.Size = New System.Drawing.Size(744, 411)
        Me.TabProcess.TabIndex = 0
        Me.TabProcess.Text = "Processing"
        Me.TabProcess.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(316, 384)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(72, 23)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdViewDecsriptors
        '
        Me.cmdViewDecsriptors.Location = New System.Drawing.Point(182, 386)
        Me.cmdViewDecsriptors.Name = "cmdViewDecsriptors"
        Me.cmdViewDecsriptors.Size = New System.Drawing.Size(106, 23)
        Me.cmdViewDecsriptors.TabIndex = 1
        Me.cmdViewDecsriptors.Text = "View Descriptors"
        Me.cmdViewDecsriptors.UseVisualStyleBackColor = True
        '
        'cmdEncode
        '
        Me.cmdEncode.Location = New System.Drawing.Point(66, 386)
        Me.cmdEncode.Name = "cmdEncode"
        Me.cmdEncode.Size = New System.Drawing.Size(81, 23)
        Me.cmdEncode.TabIndex = 0
        Me.cmdEncode.Text = "Encode"
        Me.cmdEncode.UseVisualStyleBackColor = True
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.cmdCancel)
        Me.TabSettings.Controls.Add(Me.cmdSave)
        Me.TabSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettings.Size = New System.Drawing.Size(744, 411)
        Me.TabSettings.TabIndex = 1
        Me.TabSettings.Text = "Settings"
        Me.TabSettings.UseVisualStyleBackColor = True
        '
        'TabHelp
        '
        Me.TabHelp.Location = New System.Drawing.Point(4, 22)
        Me.TabHelp.Name = "TabHelp"
        Me.TabHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHelp.Size = New System.Drawing.Size(744, 411)
        Me.TabHelp.TabIndex = 2
        Me.TabHelp.Text = "Help"
        Me.TabHelp.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(29, 390)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(72, 20)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(125, 390)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 20)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmSynopTDCF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 451)
        Me.Controls.Add(Me.TabProcessing)
        Me.Name = "frmSynopTDCF"
        Me.Text = "TDCF BUFR Encoding"
        Me.TabProcessing.ResumeLayout(False)
        Me.TabProcess.ResumeLayout(False)
        Me.TabSettings.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabProcessing As System.Windows.Forms.TabControl
    Friend WithEvents TabProcess As System.Windows.Forms.TabPage
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdViewDecsriptors As System.Windows.Forms.Button
    Friend WithEvents cmdEncode As System.Windows.Forms.Button
    Friend WithEvents TabSettings As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents TabHelp As System.Windows.Forms.TabPage
End Class
