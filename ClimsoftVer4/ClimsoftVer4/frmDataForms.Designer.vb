<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataForms
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
        Me.lstvForms = New System.Windows.Forms.ListView()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstvForms
        '
        Me.lstvForms.AllowColumnReorder = True
        Me.lstvForms.AllowDrop = True
        Me.lstvForms.CheckBoxes = True
        Me.lstvForms.FullRowSelect = True
        Me.lstvForms.GridLines = True
        Me.lstvForms.LabelEdit = True
        Me.lstvForms.Location = New System.Drawing.Point(12, 12)
        Me.lstvForms.Name = "lstvForms"
        Me.lstvForms.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lstvForms.Size = New System.Drawing.Size(685, 329)
        Me.lstvForms.TabIndex = 0
        Me.lstvForms.UseCompatibleStateImageBehavior = False
        Me.lstvForms.View = System.Windows.Forms.View.Details
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(422, 347)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(69, 27)
        Me.cmdApply.TabIndex = 1
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(614, 347)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(69, 27)
        Me.cmdHelp.TabIndex = 2
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(518, 347)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(69, 27)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmDataForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 385)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.lstvForms)
        Me.Name = "frmDataForms"
        Me.Text = "Data Forms"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lstvForms As System.Windows.Forms.ListView
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
End Class
