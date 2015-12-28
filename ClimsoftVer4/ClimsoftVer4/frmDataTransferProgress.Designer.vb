<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataTransferProgress
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
        Me.txtDataTransferProgress = New System.Windows.Forms.TextBox()
        Me.lblDataTransferProgress = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTableRecords = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDataTransferProgress
        '
        Me.txtDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.txtDataTransferProgress.Location = New System.Drawing.Point(70, 47)
        Me.txtDataTransferProgress.Name = "txtDataTransferProgress"
        Me.txtDataTransferProgress.Size = New System.Drawing.Size(273, 20)
        Me.txtDataTransferProgress.TabIndex = 0
        '
        'lblDataTransferProgress
        '
        Me.lblDataTransferProgress.AutoSize = True
        Me.lblDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.lblDataTransferProgress.Location = New System.Drawing.Point(93, 84)
        Me.lblDataTransferProgress.Name = "lblDataTransferProgress"
        Me.lblDataTransferProgress.Size = New System.Drawing.Size(122, 13)
        Me.lblDataTransferProgress.TabIndex = 2
        Me.lblDataTransferProgress.Text = "Data transfer in progress"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(287, 97)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(56, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTableRecords
        '
        Me.lblTableRecords.AutoSize = True
        Me.lblTableRecords.Location = New System.Drawing.Point(93, 20)
        Me.lblTableRecords.Name = "lblTableRecords"
        Me.lblTableRecords.Size = New System.Drawing.Size(0, 13)
        Me.lblTableRecords.TabIndex = 4
        '
        'frmDataTransferProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 132)
        Me.Controls.Add(Me.lblTableRecords)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblDataTransferProgress)
        Me.Controls.Add(Me.txtDataTransferProgress)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataTransferProgress"
        Me.Text = "Data Transfer Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataTransferProgress As System.Windows.Forms.TextBox
    Friend WithEvents lblDataTransferProgress As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblTableRecords As System.Windows.Forms.Label
End Class
