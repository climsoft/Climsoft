<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMsg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMsg))
        Me.rtfDetails = New System.Windows.Forms.RichTextBox()
        Me.rtfMessage = New System.Windows.Forms.RichTextBox()
        Me.cmdDetails = New System.Windows.Forms.Button()
        Me.picIcon = New System.Windows.Forms.PictureBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rtfDetails
        '
        Me.rtfDetails.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.rtfDetails, "rtfDetails")
        Me.rtfDetails.Name = "rtfDetails"
        Me.rtfDetails.ReadOnly = True
        '
        'rtfMessage
        '
        Me.rtfMessage.BackColor = System.Drawing.SystemColors.Control
        Me.rtfMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.rtfMessage, "rtfMessage")
        Me.rtfMessage.Name = "rtfMessage"
        Me.rtfMessage.ReadOnly = True
        '
        'cmdDetails
        '
        resources.ApplyResources(Me.cmdDetails, "cmdDetails")
        Me.cmdDetails.Name = "cmdDetails"
        Me.cmdDetails.UseVisualStyleBackColor = True
        '
        'picIcon
        '
        Me.picIcon.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.picIcon, "picIcon")
        Me.picIcon.Name = "picIcon"
        Me.picIcon.TabStop = False
        '
        'cmdOK
        '
        resources.ApplyResources(Me.cmdOK, "cmdOK")
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmMsg
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.rtfDetails)
        Me.Controls.Add(Me.rtfMessage)
        Me.Controls.Add(Me.cmdDetails)
        Me.Controls.Add(Me.picIcon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMsg"
        CType(Me.picIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rtfDetails As RichTextBox
    Friend WithEvents rtfMessage As RichTextBox
    Friend WithEvents cmdDetails As Button
    Friend WithEvents picIcon As PictureBox
    Friend WithEvents cmdOK As Button
End Class
