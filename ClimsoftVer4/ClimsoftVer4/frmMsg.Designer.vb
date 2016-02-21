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
        Me.rtfDetails.Location = New System.Drawing.Point(12, 135)
        Me.rtfDetails.Name = "rtfDetails"
        Me.rtfDetails.ReadOnly = True
        Me.rtfDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtfDetails.Size = New System.Drawing.Size(323, 128)
        Me.rtfDetails.TabIndex = 13
        Me.rtfDetails.Text = ""
        '
        'rtfMessage
        '
        Me.rtfMessage.BackColor = System.Drawing.SystemColors.Control
        Me.rtfMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtfMessage.Location = New System.Drawing.Point(85, 12)
        Me.rtfMessage.Name = "rtfMessage"
        Me.rtfMessage.ReadOnly = True
        Me.rtfMessage.Size = New System.Drawing.Size(250, 86)
        Me.rtfMessage.TabIndex = 12
        Me.rtfMessage.Text = ""
        '
        'cmdDetails
        '
        Me.cmdDetails.Location = New System.Drawing.Point(12, 104)
        Me.cmdDetails.Name = "cmdDetails"
        Me.cmdDetails.Size = New System.Drawing.Size(88, 23)
        Me.cmdDetails.TabIndex = 11
        Me.cmdDetails.Text = "Details"
        Me.cmdDetails.UseVisualStyleBackColor = True
        '
        'picIcon
        '
        Me.picIcon.BackColor = System.Drawing.Color.Transparent
        Me.picIcon.Location = New System.Drawing.Point(12, 12)
        Me.picIcon.Name = "picIcon"
        Me.picIcon.Size = New System.Drawing.Size(55, 50)
        Me.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picIcon.TabIndex = 10
        Me.picIcon.TabStop = False
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(260, 104)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 14
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 273)
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
