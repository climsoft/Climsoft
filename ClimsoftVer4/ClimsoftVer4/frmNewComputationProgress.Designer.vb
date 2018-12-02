<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewComputationProgress
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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.progressBar = New System.Windows.Forms.ProgressBar()
        Me.backgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblResultMessage = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.ForeColor = System.Drawing.Color.Black
        Me.lblHeader.Location = New System.Drawing.Point(15, 9)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(96, 20)
        Me.lblHeader.TabIndex = 10
        Me.lblHeader.Text = "header label"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(363, 45)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(44, 29)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "x"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.ForeColor = System.Drawing.Color.Black
        Me.lblProgress.Location = New System.Drawing.Point(15, 54)
        Me.lblProgress.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(71, 20)
        Me.lblProgress.TabIndex = 8
        Me.lblProgress.Text = "progress"
        '
        'progressBar
        '
        Me.progressBar.Location = New System.Drawing.Point(10, 85)
        Me.progressBar.Name = "progressBar"
        Me.progressBar.Size = New System.Drawing.Size(406, 28)
        Me.progressBar.TabIndex = 7
        '
        'backgroundWorker
        '
        Me.backgroundWorker.WorkerReportsProgress = True
        Me.backgroundWorker.WorkerSupportsCancellation = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(333, 128)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 35)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblResultMessage
        '
        Me.lblResultMessage.AutoSize = True
        Me.lblResultMessage.ForeColor = System.Drawing.Color.Red
        Me.lblResultMessage.Location = New System.Drawing.Point(15, 128)
        Me.lblResultMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblResultMessage.Name = "lblResultMessage"
        Me.lblResultMessage.Size = New System.Drawing.Size(124, 20)
        Me.lblResultMessage.TabIndex = 11
        Me.lblResultMessage.Text = "Result Message"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(19, 171)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(326, 111)
        Me.TextBox1.TabIndex = 13
        '
        'frmNewComputationProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 337)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblResultMessage)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.progressBar)
        Me.Name = "frmNewComputationProgress"
        Me.Text = "Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblProgress As Label
    Friend WithEvents progressBar As ProgressBar
    Friend WithEvents backgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnClose As Button
    Friend WithEvents lblResultMessage As Label
    Friend WithEvents TextBox1 As TextBox
End Class