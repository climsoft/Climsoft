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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataTransferProgress))
        Me.txtDataTransferProgress = New System.Windows.Forms.TextBox()
        Me.lblDataTransferProgress = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTableRecords = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDataTransferProgress
        '
        Me.txtDataTransferProgress.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.txtDataTransferProgress, "txtDataTransferProgress")
        Me.txtDataTransferProgress.Name = "txtDataTransferProgress"
        '
        'lblDataTransferProgress
        '
        resources.ApplyResources(Me.lblDataTransferProgress, "lblDataTransferProgress")
        Me.lblDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.lblDataTransferProgress.Name = "lblDataTransferProgress"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTableRecords
        '
        resources.ApplyResources(Me.lblTableRecords, "lblTableRecords")
        Me.lblTableRecords.Name = "lblTableRecords"
        '
        'frmDataTransferProgress
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblTableRecords)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblDataTransferProgress)
        Me.Controls.Add(Me.txtDataTransferProgress)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDataTransferProgress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataTransferProgress As System.Windows.Forms.TextBox
    Friend WithEvents lblDataTransferProgress As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblTableRecords As System.Windows.Forms.Label
End Class
