<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLanguage
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
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.lblLanguage = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboLanguage
        '
        Me.cboLanguage.FormattingEnabled = True
        Me.cboLanguage.Items.AddRange(New Object() {"English", "Français", "Deutsch"})
        Me.cboLanguage.Location = New System.Drawing.Point(226, 52)
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Size = New System.Drawing.Size(196, 21)
        Me.cboLanguage.TabIndex = 0
        '
        'lblLanguage
        '
        Me.lblLanguage.AutoSize = True
        Me.lblLanguage.Location = New System.Drawing.Point(67, 55)
        Me.lblLanguage.Name = "lblLanguage"
        Me.lblLanguage.Size = New System.Drawing.Size(88, 13)
        Me.lblLanguage.TabIndex = 1
        Me.lblLanguage.Tag = "Select_Language"
        Me.lblLanguage.Text = "Select Language"
        Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(431, 185)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(94, 23)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Tag = "Cancel"
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(328, 185)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(94, 23)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Tag = "OK"
        Me.cmdOK.Text = "&OK"
        '
        'frmLanguage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 220)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblLanguage)
        Me.Controls.Add(Me.cboLanguage)
        Me.Name = "frmLanguage"
        Me.Tag = "Select_Language"
        Me.Text = "Select Language"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboLanguage As ComboBox
    Friend WithEvents lblLanguage As Label
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOK As Button
End Class
