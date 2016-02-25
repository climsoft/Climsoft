<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadToObsFinal
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
        Me.lblProcessingStatus = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.lblBeginMonth = New System.Windows.Forms.Label()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.lblBeginYear = New System.Windows.Forms.Label()
        Me.txtEndMonth = New System.Windows.Forms.TextBox()
        Me.txtBeginMonth = New System.Windows.Forms.TextBox()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtBeginYear = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblProcessingStatus
        '
        Me.lblProcessingStatus.AutoSize = True
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Location = New System.Drawing.Point(118, 214)
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        Me.lblProcessingStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessingStatus.TabIndex = 25
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(257, 184)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 23
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(163, 184)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(69, 184)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(145, 149)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 20
        Me.lblEndMonth.Text = "End Month"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(145, 109)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(70, 13)
        Me.lblBeginMonth.TabIndex = 19
        Me.lblBeginMonth.Text = "Begin Month:"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(145, 69)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(54, 13)
        Me.lblEndYear.TabIndex = 18
        Me.lblEndYear.Text = "End Year:"
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(145, 32)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(62, 13)
        Me.lblBeginYear.TabIndex = 17
        Me.lblBeginYear.Text = "Begin Year:"
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(232, 149)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(100, 20)
        Me.txtEndMonth.TabIndex = 3
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(232, 109)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(100, 20)
        Me.txtBeginMonth.TabIndex = 2
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(232, 69)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(100, 20)
        Me.txtEndYear.TabIndex = 1
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(232, 29)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(100, 20)
        Me.txtBeginYear.TabIndex = 0
        '
        'frmUploadToObsFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 234)
        Me.Controls.Add(Me.lblProcessingStatus)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblEndMonth)
        Me.Controls.Add(Me.lblBeginMonth)
        Me.Controls.Add(Me.lblEndYear)
        Me.Controls.Add(Me.lblBeginYear)
        Me.Controls.Add(Me.txtEndMonth)
        Me.Controls.Add(Me.txtBeginMonth)
        Me.Controls.Add(Me.txtEndYear)
        Me.Controls.Add(Me.txtBeginYear)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUploadToObsFinal"
        Me.Text = "Upload to ObservationFinal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProcessingStatus As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents lblBeginMonth As System.Windows.Forms.Label
    Friend WithEvents lblEndYear As System.Windows.Forms.Label
    Friend WithEvents lblBeginYear As System.Windows.Forms.Label
    Friend WithEvents txtEndMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtBeginMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents txtBeginYear As System.Windows.Forms.TextBox
End Class
