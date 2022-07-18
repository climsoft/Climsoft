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
        Me.chkUpdateRecs = New System.Windows.Forms.CheckBox()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblProcessingStatus
        '
        Me.lblProcessingStatus.AutoSize = True
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Location = New System.Drawing.Point(83, 491)
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        Me.lblProcessingStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessingStatus.TabIndex = 25
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(547, 480)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 23
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(448, 480)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(662, 480)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        Me.btnOK.Visible = False
        '
        'lblEndMonth
        '
        Me.lblEndMonth.Location = New System.Drawing.Point(170, 485)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(95, 13)
        Me.lblEndMonth.TabIndex = 20
        Me.lblEndMonth.Text = "End Month"
        Me.lblEndMonth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.Location = New System.Drawing.Point(170, 452)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(95, 13)
        Me.lblBeginMonth.TabIndex = 19
        Me.lblBeginMonth.Text = "Begin Month:"
        Me.lblBeginMonth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEndYear
        '
        Me.lblEndYear.Location = New System.Drawing.Point(12, 485)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(86, 13)
        Me.lblEndYear.TabIndex = 18
        Me.lblEndYear.Text = "End Year:"
        Me.lblEndYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblBeginYear
        '
        Me.lblBeginYear.Location = New System.Drawing.Point(12, 452)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(86, 13)
        Me.lblBeginYear.TabIndex = 17
        Me.lblBeginYear.Text = "Begin Year:"
        Me.lblBeginYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(271, 481)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 3
        Me.txtEndMonth.Text = "12"
        Me.txtEndMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(271, 448)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBeginMonth.TabIndex = 2
        Me.txtBeginMonth.Text = "1"
        Me.txtBeginMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(104, 481)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(48, 20)
        Me.txtEndYear.TabIndex = 1
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(104, 449)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(48, 20)
        Me.txtBeginYear.TabIndex = 0
        '
        'chkAllElements
        '
        Me.chkAllElements.AutoSize = True
        Me.chkAllElements.Location = New System.Drawing.Point(380, 394)
        Me.chkAllElements.Name = "chkAllElements"
        Me.chkAllElements.Size = New System.Drawing.Size(116, 17)
        Me.chkAllElements.TabIndex = 29
        Me.chkAllElements.Text = "Select All Elements"
        Me.chkAllElements.UseVisualStyleBackColor = True
        '
        'chkAllStations
        '
        Me.chkAllStations.AutoSize = True
        Me.chkAllStations.Location = New System.Drawing.Point(12, 394)
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
        Me.lstViewElements.HideSelection = False
        Me.lstViewElements.Location = New System.Drawing.Point(377, 39)
        Me.lstViewElements.Name = "lstViewElements"
        Me.lstViewElements.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViewElements.RightToLeftLayout = True
        Me.lstViewElements.Size = New System.Drawing.Size(359, 352)
        Me.lstViewElements.TabIndex = 27
        Me.lstViewElements.UseCompatibleStateImageBehavior = False
        Me.lstViewElements.View = System.Windows.Forms.View.Details
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.HideSelection = False
        Me.LstViewStations.Location = New System.Drawing.Point(12, 39)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(359, 352)
        Me.LstViewStations.TabIndex = 26
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'cmdUploadData
        '
        Me.cmdUploadData.Location = New System.Drawing.Point(337, 480)
        Me.cmdUploadData.Name = "cmdUploadData"
        Me.cmdUploadData.Size = New System.Drawing.Size(73, 23)
        Me.cmdUploadData.TabIndex = 30
        Me.cmdUploadData.Text = "Upload"
        Me.cmdUploadData.UseVisualStyleBackColor = True
        '
        'txtDataTransferProgress
        '
        Me.txtDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.txtDataTransferProgress.Location = New System.Drawing.Point(456, 428)
        Me.txtDataTransferProgress.Name = "txtDataTransferProgress"
        Me.txtDataTransferProgress.Size = New System.Drawing.Size(280, 20)
        Me.txtDataTransferProgress.TabIndex = 31
        Me.txtDataTransferProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTableRecords
        '
        Me.lblTableRecords.AutoSize = True
        Me.lblTableRecords.ForeColor = System.Drawing.Color.Black
        Me.lblTableRecords.Location = New System.Drawing.Point(519, 451)
        Me.lblTableRecords.Name = "lblTableRecords"
        Me.lblTableRecords.Size = New System.Drawing.Size(122, 13)
        Me.lblTableRecords.TabIndex = 32
        Me.lblTableRecords.Text = "Data transfer in progress"
        '
        'chkUpdateRecs
        '
        Me.chkUpdateRecs.AutoSize = True
        Me.chkUpdateRecs.Location = New System.Drawing.Point(594, 394)
        Me.chkUpdateRecs.Name = "chkUpdateRecs"
        Me.chkUpdateRecs.Size = New System.Drawing.Size(137, 17)
        Me.chkUpdateRecs.TabIndex = 33
        Me.chkUpdateRecs.Text = "Update existing records"
        Me.chkUpdateRecs.UseVisualStyleBackColor = True
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(380, 21)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 41
        Me.lblElement.Text = "Select Element"
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(514, 17)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(222, 21)
        Me.cmbElement.TabIndex = 40
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(14, 21)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 39
        Me.lblStation.Text = "Select Station"
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(161, 17)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(210, 21)
        Me.cmbstation.TabIndex = 38
        '
        'frmUploadToObsFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 512)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.cmbElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cmbstation)
        Me.Controls.Add(Me.chkUpdateRecs)
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
    Friend WithEvents chkUpdateRecs As CheckBox
    Friend WithEvents lblElement As Label
    Friend WithEvents cmbElement As ComboBox
    Friend WithEvents lblStation As Label
    Friend WithEvents cmbstation As ComboBox
End Class
