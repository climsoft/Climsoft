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
        Me.LstViewStations = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(213, 40)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(100, 20)
        Me.txtBeginYear.TabIndex = 0
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(213, 80)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(100, 20)
        Me.txtEndYear.TabIndex = 1
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(213, 120)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(100, 20)
        Me.txtBeginMonth.TabIndex = 2
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(213, 160)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(100, 20)
        Me.txtEndMonth.TabIndex = 3
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(126, 43)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(62, 13)
        Me.lblBeginYear.TabIndex = 4
        Me.lblBeginYear.Text = "Begin Year:"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(126, 80)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(54, 13)
        Me.lblEndYear.TabIndex = 5
        Me.lblEndYear.Text = "End Year:"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(126, 120)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(70, 13)
        Me.lblBeginMonth.TabIndex = 6
        Me.lblBeginMonth.Text = "Begin Month:"
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(126, 160)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 7
        Me.lblEndMonth.Text = "End Month"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(50, 195)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(144, 195)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(238, 195)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 10
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'lblQCtype
        '
        Me.lblQCtype.AutoSize = True
        Me.lblQCtype.ForeColor = System.Drawing.Color.Red
        Me.lblQCtype.Location = New System.Drawing.Point(26, 9)
        Me.lblQCtype.Name = "lblQCtype"
        Me.lblQCtype.Size = New System.Drawing.Size(99, 13)
        Me.lblQCtype.TabIndex = 11
        Me.lblQCtype.Text = "Type of QC checks"
        '
        'lblProcessingStatus
        '
        Me.lblProcessingStatus.AutoSize = True
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Location = New System.Drawing.Point(99, 225)
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        Me.lblProcessingStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessingStatus.TabIndex = 12
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.Location = New System.Drawing.Point(335, 19)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(321, 286)
        Me.LstViewStations.TabIndex = 13
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'frmQCdatesSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 317)
        Me.Controls.Add(Me.LstViewStations)
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
        Me.Text = "Specify range of dates for QC"
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
    Public WithEvents LstViewStations As System.Windows.Forms.ListView
End Class
