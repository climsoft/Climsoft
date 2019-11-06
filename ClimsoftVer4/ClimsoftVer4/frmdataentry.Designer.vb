<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKeyEntry
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
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lstViewForms
        '
        Me.lstViewForms.AllowColumnReorder = True
        Me.lstViewForms.AllowDrop = True
        Me.lstViewForms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.formName, Me.formDescription})
        Me.lstViewForms.FullRowSelect = True
        Me.lstViewForms.GridLines = True
        Me.lstViewForms.HideSelection = False
        Me.lstViewForms.HoverSelection = True
        Me.lstViewForms.Location = New System.Drawing.Point(4, 27)
        Me.lstViewForms.Name = "lstViewForms"
        Me.lstViewForms.RightToLeftLayout = True
        Me.lstViewForms.Scrollable = False
        Me.lstViewForms.Size = New System.Drawing.Size(659, 235)
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
        Me.formDescription.Text = "Form Description"
        Me.formDescription.Width = 500
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "climsoft4.chm"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(521, 265)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 27)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHelp.Location = New System.Drawing.Point(596, 265)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(69, 27)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(446, 265)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(69, 27)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "Open"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'lblSelection
        '
        Me.lblSelection.AutoSize = True
        Me.lblSelection.Location = New System.Drawing.Point(4, 8)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(146, 13)
        Me.lblSelection.TabIndex = 7
        Me.lblSelection.Text = "Select the entry form to open:"
        '
        'frmKeyEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 295)
        Me.Controls.Add(Me.lblSelection)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lstViewForms)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.HelpProvider1.SetHelpKeyword(Me, "dataentryforms.htm")
        Me.HelpProvider1.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.HelpProvider1.SetHelpString(Me, "topic2")
        Me.KeyPreview = True
        Me.Name = "frmKeyEntry"
        Me.HelpProvider1.SetShowHelp(Me, True)
        Me.Text = "Data Key Entry Forms"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lstViewForms As System.Windows.Forms.ListView
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents formName As ColumnHeader
    Friend WithEvents formDescription As ColumnHeader
    Friend WithEvents lblSelection As Label
End Class
