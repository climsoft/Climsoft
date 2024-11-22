<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdateDBfromQCReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.txtQCReportOriginal = New System.Windows.Forms.TextBox()
        Me.lblQCReportOriginal = New System.Windows.Forms.Label()
        Me.txtQCReportUpdated = New System.Windows.Forms.TextBox()
        Me.lblQCReportUpdated = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBrowseQCOriginal = New System.Windows.Forms.Button()
        Me.btnQCUpdated = New System.Windows.Forms.Button()
        Me.lblProcessStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtQCReportOriginal
        '
        Me.txtQCReportOriginal.Location = New System.Drawing.Point(212, 47)
        Me.txtQCReportOriginal.Name = "txtQCReportOriginal"
        Me.txtQCReportOriginal.Size = New System.Drawing.Size(310, 20)
        Me.txtQCReportOriginal.TabIndex = 0
        '
        'lblQCReportOriginal
        '
        Me.lblQCReportOriginal.AutoSize = True
        Me.lblQCReportOriginal.Location = New System.Drawing.Point(32, 50)
        Me.lblQCReportOriginal.Name = "lblQCReportOriginal"
        Me.lblQCReportOriginal.Size = New System.Drawing.Size(95, 13)
        Me.lblQCReportOriginal.TabIndex = 1
        Me.lblQCReportOriginal.Text = "Original QC Report"
        '
        'txtQCReportUpdated
        '
        Me.txtQCReportUpdated.Location = New System.Drawing.Point(212, 94)
        Me.txtQCReportUpdated.Name = "txtQCReportUpdated"
        Me.txtQCReportUpdated.Size = New System.Drawing.Size(310, 20)
        Me.txtQCReportUpdated.TabIndex = 1
        '
        'lblQCReportUpdated
        '
        Me.lblQCReportUpdated.AutoSize = True
        Me.lblQCReportUpdated.Location = New System.Drawing.Point(32, 97)
        Me.lblQCReportUpdated.Name = "lblQCReportUpdated"
        Me.lblQCReportUpdated.Size = New System.Drawing.Size(101, 13)
        Me.lblQCReportUpdated.TabIndex = 3
        Me.lblQCReportUpdated.Text = "Updated QC Report"
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(210, 148)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Update"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(308, 148)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(406, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Help"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBrowseQCOriginal
        '
        Me.btnBrowseQCOriginal.Location = New System.Drawing.Point(528, 45)
        Me.btnBrowseQCOriginal.Name = "btnBrowseQCOriginal"
        Me.btnBrowseQCOriginal.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseQCOriginal.TabIndex = 10
        Me.btnBrowseQCOriginal.Text = "Browse"
        Me.btnBrowseQCOriginal.UseVisualStyleBackColor = True
        '
        'btnQCUpdated
        '
        Me.btnQCUpdated.Location = New System.Drawing.Point(528, 92)
        Me.btnQCUpdated.Name = "btnQCUpdated"
        Me.btnQCUpdated.Size = New System.Drawing.Size(75, 23)
        Me.btnQCUpdated.TabIndex = 11
        Me.btnQCUpdated.Text = "Browse"
        Me.btnQCUpdated.UseVisualStyleBackColor = True
        '
        'lblProcessStatus
        '
        Me.lblProcessStatus.AutoSize = True
        Me.lblProcessStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessStatus.Location = New System.Drawing.Point(179, 21)
        Me.lblProcessStatus.Name = "lblProcessStatus"
        Me.lblProcessStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessStatus.TabIndex = 12
        '
        'frmUpdateDBfromQCReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 200)
        Me.Controls.Add(Me.lblProcessStatus)
        Me.Controls.Add(Me.btnQCUpdated)
        Me.Controls.Add(Me.btnBrowseQCOriginal)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblQCReportUpdated)
        Me.Controls.Add(Me.txtQCReportUpdated)
        Me.Controls.Add(Me.lblQCReportOriginal)
        Me.Controls.Add(Me.txtQCReportOriginal)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateDBfromQCReport"
        Me.Text = "Update ObservationInitial from QC Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtQCReportOriginal As System.Windows.Forms.TextBox
    Friend WithEvents lblQCReportOriginal As System.Windows.Forms.Label
    Friend WithEvents txtQCReportUpdated As System.Windows.Forms.TextBox
    Friend WithEvents lblQCReportUpdated As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnBrowseQCOriginal As System.Windows.Forms.Button
    Friend WithEvents btnQCUpdated As System.Windows.Forms.Button
    Friend WithEvents lblProcessStatus As System.Windows.Forms.Label
End Class
