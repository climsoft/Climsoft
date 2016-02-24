<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCdatesSelection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQCdatesSelection))
        Me.txtBeginYear = New System.Windows.Forms.TextBox()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtBeginMonth = New System.Windows.Forms.TextBox()
        Me.txtEndMonth = New System.Windows.Forms.TextBox()
        Me.lblBeginYear = New System.Windows.Forms.Label()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.lblBeginMonth = New System.Windows.Forms.Label()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblQCtype = New System.Windows.Forms.Label()
        Me.lblProcessingStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtBeginYear
        '
        resources.ApplyResources(Me.txtBeginYear, "txtBeginYear")
        Me.txtBeginYear.Name = "txtBeginYear"
        '
        'txtEndYear
        '
        resources.ApplyResources(Me.txtEndYear, "txtEndYear")
        Me.txtEndYear.Name = "txtEndYear"
        '
        'txtBeginMonth
        '
        resources.ApplyResources(Me.txtBeginMonth, "txtBeginMonth")
        Me.txtBeginMonth.Name = "txtBeginMonth"
        '
        'txtEndMonth
        '
        resources.ApplyResources(Me.txtEndMonth, "txtEndMonth")
        Me.txtEndMonth.Name = "txtEndMonth"
        '
        'lblBeginYear
        '
        resources.ApplyResources(Me.lblBeginYear, "lblBeginYear")
        Me.lblBeginYear.Name = "lblBeginYear"
        '
        'lblEndYear
        '
        resources.ApplyResources(Me.lblEndYear, "lblEndYear")
        Me.lblEndYear.Name = "lblEndYear"
        '
        'lblBeginMonth
        '
        resources.ApplyResources(Me.lblBeginMonth, "lblBeginMonth")
        Me.lblBeginMonth.Name = "lblBeginMonth"
        '
        'lblEndMonth
        '
        resources.ApplyResources(Me.lblEndMonth, "lblEndMonth")
        Me.lblEndMonth.Name = "lblEndMonth"
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
        'btnHelp
        '
        resources.ApplyResources(Me.btnHelp, "btnHelp")
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lblQCtype
        '
        resources.ApplyResources(Me.lblQCtype, "lblQCtype")
        Me.lblQCtype.ForeColor = System.Drawing.Color.Red
        Me.lblQCtype.Name = "lblQCtype"
        '
        'lblProcessingStatus
        '
        resources.ApplyResources(Me.lblProcessingStatus, "lblProcessingStatus")
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        '
        'frmQCdatesSelection
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblProcessingStatus)
        Me.Controls.Add(Me.lblQCtype)
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
        Me.Name = "frmQCdatesSelection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBeginYear As System.Windows.Forms.TextBox
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents txtBeginMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEndMonth As System.Windows.Forms.TextBox
    Friend WithEvents lblBeginYear As System.Windows.Forms.Label
    Friend WithEvents lblEndYear As System.Windows.Forms.Label
    Friend WithEvents lblBeginMonth As System.Windows.Forms.Label
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents lblQCtype As System.Windows.Forms.Label
    Friend WithEvents lblProcessingStatus As System.Windows.Forms.Label
End Class
