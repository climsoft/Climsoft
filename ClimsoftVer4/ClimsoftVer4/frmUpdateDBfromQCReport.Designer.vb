<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateDBfromQCReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateDBfromQCReport))
        Me.txtQCReportOriginal = New System.Windows.Forms.TextBox()
        Me.lblQCReportOriginal = New System.Windows.Forms.Label()
        Me.txtQCReportUpdated = New System.Windows.Forms.TextBox()
        Me.lblQCReportUpdated = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnBrowseQCOriginal = New System.Windows.Forms.Button()
        Me.btnQCUpdated = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtQCReportOriginal
        '
        resources.ApplyResources(Me.txtQCReportOriginal, "txtQCReportOriginal")
        Me.txtQCReportOriginal.Name = "txtQCReportOriginal"
        '
        'lblQCReportOriginal
        '
        resources.ApplyResources(Me.lblQCReportOriginal, "lblQCReportOriginal")
        Me.lblQCReportOriginal.Name = "lblQCReportOriginal"
        '
        'txtQCReportUpdated
        '
        resources.ApplyResources(Me.txtQCReportUpdated, "txtQCReportUpdated")
        Me.txtQCReportUpdated.Name = "txtQCReportUpdated"
        '
        'lblQCReportUpdated
        '
        resources.ApplyResources(Me.lblQCReportUpdated, "lblQCReportUpdated")
        Me.lblQCReportUpdated.Name = "lblQCReportUpdated"
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnBrowseQCOriginal
        '
        resources.ApplyResources(Me.btnBrowseQCOriginal, "btnBrowseQCOriginal")
        Me.btnBrowseQCOriginal.Name = "btnBrowseQCOriginal"
        Me.btnBrowseQCOriginal.UseVisualStyleBackColor = True
        '
        'btnQCUpdated
        '
        resources.ApplyResources(Me.btnQCUpdated, "btnQCUpdated")
        Me.btnQCUpdated.Name = "btnQCUpdated"
        Me.btnQCUpdated.UseVisualStyleBackColor = True
        '
        'frmUpdateDBfromQCReport
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
End Class
