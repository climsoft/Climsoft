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
        Me.chkAllElements = New System.Windows.Forms.CheckBox()
        Me.chkAllStations = New System.Windows.Forms.CheckBox()
        Me.lstViewElements = New System.Windows.Forms.ListView()
        Me.LstViewStations = New System.Windows.Forms.ListView()
        Me.cmdUploadData = New System.Windows.Forms.Button()
        Me.txtDataTransferProgress = New System.Windows.Forms.TextBox()
        Me.lblTableRecords = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblProcessingStatus
        '
        Me.lblProcessingStatus.AutoSize = True
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Location = New System.Drawing.Point(83, 439)
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        Me.lblProcessingStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessingStatus.TabIndex = 25
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(498, 429)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 23
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(399, 429)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(613, 426)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Visible = False
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(142, 436)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 20
        Me.lblEndMonth.Text = "End Month"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(142, 410)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(70, 13)
        Me.lblBeginMonth.TabIndex = 19
        Me.lblBeginMonth.Text = "Begin Month:"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(12, 436)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(54, 13)
        Me.lblEndYear.TabIndex = 18
        Me.lblEndYear.Text = "End Year:"
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(12, 410)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(62, 13)
        Me.lblBeginYear.TabIndex = 17
        Me.lblBeginYear.Text = "Begin Year:"
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(218, 432)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 3
        Me.txtEndMonth.Text = "12"
        Me.txtEndMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(218, 406)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBeginMonth.TabIndex = 2
        Me.txtBeginMonth.Text = "1"
        Me.txtBeginMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(80, 432)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(48, 20)
        Me.txtEndYear.TabIndex = 1
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(80, 406)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(48, 20)
        Me.txtBeginYear.TabIndex = 0
        '
        'chkAllElements
        '
        Me.chkAllElements.AutoSize = True
        Me.chkAllElements.Location = New System.Drawing.Point(386, 357)
        Me.chkAllElements.Name = "chkAllElements"
        Me.chkAllElements.Size = New System.Drawing.Size(116, 17)
        Me.chkAllElements.TabIndex = 29
        Me.chkAllElements.Text = "Select All Elements"
        Me.chkAllElements.UseVisualStyleBackColor = True
        '
        'chkAllStations
        '
        Me.chkAllStations.AutoSize = True
        Me.chkAllStations.Location = New System.Drawing.Point(12, 358)
        Me.chkAllStations.Name = "chkAllStations"
        Me.chkAllStations.Size = New System.Drawing.Size(111, 17)
        Me.chkAllStations.TabIndex = 28
        Me.chkAllStations.Text = "Select All Stations"
        Me.chkAllStations.UseVisualStyleBackColor = True
        '
        'lstViewElements
        '
        Me.lstViewElements.CheckBoxes = True
        Me.lstViewElements.FullRowSelect = True
        Me.lstViewElements.GridLines = True
        Me.lstViewElements.Location = New System.Drawing.Point(386, 12)
        Me.lstViewElements.Name = "lstViewElements"
        Me.lstViewElements.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViewElements.RightToLeftLayout = True
        Me.lstViewElements.Size = New System.Drawing.Size(350, 340)
        Me.lstViewElements.TabIndex = 27
        Me.lstViewElements.UseCompatibleStateImageBehavior = False
        Me.lstViewElements.View = System.Windows.Forms.View.Details
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.Location = New System.Drawing.Point(12, 12)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(350, 340)
        Me.LstViewStations.TabIndex = 26
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'cmdUploadData
        '
        Me.cmdUploadData.Location = New System.Drawing.Point(288, 429)
        Me.cmdUploadData.Name = "cmdUploadData"
        Me.cmdUploadData.Size = New System.Drawing.Size(73, 23)
        Me.cmdUploadData.TabIndex = 30
        Me.cmdUploadData.Text = "Upload"
        Me.cmdUploadData.UseVisualStyleBackColor = True
        '
        'txtDataTransferProgress
        '
        Me.txtDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.txtDataTransferProgress.Location = New System.Drawing.Point(456, 380)
        Me.txtDataTransferProgress.Name = "txtDataTransferProgress"
        Me.txtDataTransferProgress.Size = New System.Drawing.Size(280, 20)
        Me.txtDataTransferProgress.TabIndex = 31
        Me.txtDataTransferProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTableRecords
        '
        Me.lblTableRecords.AutoSize = True
        Me.lblTableRecords.ForeColor = System.Drawing.Color.Black
        Me.lblTableRecords.Location = New System.Drawing.Point(519, 403)
        Me.lblTableRecords.Name = "lblTableRecords"
        Me.lblTableRecords.Size = New System.Drawing.Size(122, 13)
        Me.lblTableRecords.TabIndex = 32
        Me.lblTableRecords.Text = "Data transfer in progress"
        '
        'frmUploadToObsFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 463)
        Me.Controls.Add(Me.lblTableRecords)
        Me.Controls.Add(Me.txtDataTransferProgress)
        Me.Controls.Add(Me.cmdUploadData)
        Me.Controls.Add(Me.chkAllElements)
        Me.Controls.Add(Me.chkAllStations)
        Me.Controls.Add(Me.lstViewElements)
        Me.Controls.Add(Me.LstViewStations)
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
    Friend WithEvents chkAllElements As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllStations As System.Windows.Forms.CheckBox
    Public WithEvents lstViewElements As System.Windows.Forms.ListView
    Public WithEvents LstViewStations As System.Windows.Forms.ListView
    Friend WithEvents cmdUploadData As System.Windows.Forms.Button
    Friend WithEvents txtDataTransferProgress As System.Windows.Forms.TextBox
    Friend WithEvents lblTableRecords As System.Windows.Forms.Label
End Class
