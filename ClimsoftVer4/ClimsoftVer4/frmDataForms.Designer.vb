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
        Me.lstViewForms = New System.Windows.Forms.ListView()
        Me.formName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.formDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstViewForms
        '
        Me.lstViewForms.AllowDrop = True
        Me.lstViewForms.CheckBoxes = True
        Me.lstViewForms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.formName, Me.formDescription})
        Me.lstViewForms.FullRowSelect = True
        Me.lstViewForms.HideSelection = False
        Me.lstViewForms.Location = New System.Drawing.Point(4, 27)
        Me.lstViewForms.Name = "lstViewForms"
        Me.lstViewForms.Size = New System.Drawing.Size(554, 238)
        Me.lstViewForms.TabIndex = 0
        Me.lstViewForms.UseCompatibleStateImageBehavior = False
        Me.lstViewForms.View = System.Windows.Forms.View.Details
        '
        'formName
        '
        Me.formName.Text = "Form Name"
        Me.formName.Width = 150
        '
        'formDescription
        '
        Me.formDescription.Text = "Description"
        Me.formDescription.Width = 400
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(338, 271)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(69, 27)
        Me.btnApply.TabIndex = 1
        Me.btnApply.Text = "Apply"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(488, 271)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(69, 27)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(413, 271)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 27)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Location = New System.Drawing.Point(1, 8)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(139, 13)
        Me.lblSelect.TabIndex = 4
        Me.lblSelect.Text = "Select the forms to activate:"
        '
        'frmDataForms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 301)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.lstViewForms)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDataForms"
        Me.Text = "Data Key Entry Forms"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lstViewForms As System.Windows.Forms.ListView
    Friend WithEvents formName As ColumnHeader
    Friend WithEvents formDescription As ColumnHeader
    Friend WithEvents lblSelect As Label
End Class
