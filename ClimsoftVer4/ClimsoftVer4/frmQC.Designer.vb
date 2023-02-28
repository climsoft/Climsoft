<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQC
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
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.pnlAdvanced = New System.Windows.Forms.Panel()
        Me.lblQcAdvanced = New System.Windows.Forms.Label()
        Me.pnlQcStandard = New System.Windows.Forms.Panel()
        Me.txtEndMonth = New System.Windows.Forms.TextBox()
        Me.txtBeginMonth = New System.Windows.Forms.TextBox()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtBeginYear = New System.Windows.Forms.TextBox()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.lblBeginMonth = New System.Windows.Forms.Label()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.lblBeginYear = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.LstViewStations = New System.Windows.Forms.ListView()
        Me.lstViewElements = New System.Windows.Forms.ListView()
        Me.chkAllStations = New System.Windows.Forms.CheckBox()
        Me.chkAllElements = New System.Windows.Forms.CheckBox()
        Me.cmdPerformQC = New System.Windows.Forms.Button()
        Me.lblQCtype = New System.Windows.Forms.Label()
        Me.lblDataTransferProgress = New System.Windows.Forms.Label()
        Me.pnlQCTypes = New System.Windows.Forms.Panel()
        Me.optInterElement = New System.Windows.Forms.RadioButton()
        Me.optAbsoluteLimits = New System.Windows.Forms.RadioButton()
        Me.lblStationsElementsList = New System.Windows.Forms.Label()
        Me.lblSelectTimeRange = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.txtProgress = New System.Windows.Forms.TextBox()
        Me.pnlAdvanced.SuspendLayout()
        Me.pnlQcStandard.SuspendLayout()
        Me.pnlQCTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(195, 471)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 23)
        Me.cmdApply.TabIndex = 7
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        Me.cmdApply.Visible = False
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(126, 471)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(63, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        Me.cmdOk.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(151, 471)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(73, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(288, 471)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(73, 23)
        Me.cmdHelp.TabIndex = 4
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'pnlAdvanced
        '
        Me.pnlAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAdvanced.Controls.Add(Me.lblQcAdvanced)
        Me.pnlAdvanced.Location = New System.Drawing.Point(623, 32)
        Me.pnlAdvanced.Name = "pnlAdvanced"
        Me.pnlAdvanced.Size = New System.Drawing.Size(100, 25)
        Me.pnlAdvanced.TabIndex = 9
        Me.pnlAdvanced.Visible = False
        '
        'lblQcAdvanced
        '
        Me.lblQcAdvanced.AutoSize = True
        Me.lblQcAdvanced.Location = New System.Drawing.Point(4, 0)
        Me.lblQcAdvanced.Name = "lblQcAdvanced"
        Me.lblQcAdvanced.Size = New System.Drawing.Size(74, 13)
        Me.lblQcAdvanced.TabIndex = 0
        Me.lblQcAdvanced.Text = "Advanced QC"
        '
        'pnlQcStandard
        '
        Me.pnlQcStandard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQcStandard.Controls.Add(Me.txtEndMonth)
        Me.pnlQcStandard.Controls.Add(Me.txtBeginMonth)
        Me.pnlQcStandard.Controls.Add(Me.txtEndYear)
        Me.pnlQcStandard.Controls.Add(Me.txtBeginYear)
        Me.pnlQcStandard.Controls.Add(Me.lblEndMonth)
        Me.pnlQcStandard.Controls.Add(Me.lblBeginMonth)
        Me.pnlQcStandard.Controls.Add(Me.lblEndYear)
        Me.pnlQcStandard.Controls.Add(Me.lblBeginYear)
        Me.pnlQcStandard.Location = New System.Drawing.Point(3, 319)
        Me.pnlQcStandard.Name = "pnlQcStandard"
        Me.pnlQcStandard.Size = New System.Drawing.Size(302, 63)
        Me.pnlQcStandard.TabIndex = 8
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(258, 34)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 10
        Me.txtEndMonth.Text = "12"
        Me.txtEndMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(258, 6)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBeginMonth.TabIndex = 9
        Me.txtBeginMonth.Text = "01"
        Me.txtBeginMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(94, 36)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(44, 20)
        Me.txtEndYear.TabIndex = 8
        Me.txtEndYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(94, 8)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(44, 20)
        Me.txtBeginYear.TabIndex = 7
        Me.txtBeginYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(159, 38)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 6
        Me.lblEndMonth.Text = "End Month"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(159, 10)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(67, 13)
        Me.lblBeginMonth.TabIndex = 5
        Me.lblBeginMonth.Text = "Begin Month"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(6, 40)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(51, 13)
        Me.lblEndYear.TabIndex = 4
        Me.lblEndYear.Text = "End Year"
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(6, 12)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(59, 13)
        Me.lblBeginYear.TabIndex = 3
        Me.lblBeginYear.Text = "Begin Year"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnUpdate.Location = New System.Drawing.Point(496, 448)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(180, 30)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "Update With QC Report"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.HideSelection = False
        Me.LstViewStations.Location = New System.Drawing.Point(311, 81)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(295, 323)
        Me.LstViewStations.TabIndex = 14
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'lstViewElements
        '
        Me.lstViewElements.CheckBoxes = True
        Me.lstViewElements.FullRowSelect = True
        Me.lstViewElements.GridLines = True
        Me.lstViewElements.HideSelection = False
        Me.lstViewElements.Location = New System.Drawing.Point(622, 84)
        Me.lstViewElements.Name = "lstViewElements"
        Me.lstViewElements.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViewElements.RightToLeftLayout = True
        Me.lstViewElements.Size = New System.Drawing.Size(276, 320)
        Me.lstViewElements.TabIndex = 15
        Me.lstViewElements.UseCompatibleStateImageBehavior = False
        Me.lstViewElements.View = System.Windows.Forms.View.Details
        '
        'chkAllStations
        '
        Me.chkAllStations.AutoSize = True
        Me.chkAllStations.Location = New System.Drawing.Point(314, 411)
        Me.chkAllStations.Name = "chkAllStations"
        Me.chkAllStations.Size = New System.Drawing.Size(111, 17)
        Me.chkAllStations.TabIndex = 16
        Me.chkAllStations.Text = "Select All Stations"
        Me.chkAllStations.UseVisualStyleBackColor = True
        '
        'chkAllElements
        '
        Me.chkAllElements.AutoSize = True
        Me.chkAllElements.Location = New System.Drawing.Point(623, 416)
        Me.chkAllElements.Name = "chkAllElements"
        Me.chkAllElements.Size = New System.Drawing.Size(116, 17)
        Me.chkAllElements.TabIndex = 17
        Me.chkAllElements.Text = "Select All Elements"
        Me.chkAllElements.UseVisualStyleBackColor = True
        '
        'cmdPerformQC
        '
        Me.cmdPerformQC.Location = New System.Drawing.Point(14, 471)
        Me.cmdPerformQC.Name = "cmdPerformQC"
        Me.cmdPerformQC.Size = New System.Drawing.Size(93, 23)
        Me.cmdPerformQC.TabIndex = 18
        Me.cmdPerformQC.Text = "Perform QC"
        Me.cmdPerformQC.UseVisualStyleBackColor = True
        '
        'lblQCtype
        '
        Me.lblQCtype.AutoSize = True
        Me.lblQCtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQCtype.ForeColor = System.Drawing.Color.Black
        Me.lblQCtype.Location = New System.Drawing.Point(69, 11)
        Me.lblQCtype.Name = "lblQCtype"
        Me.lblQCtype.Size = New System.Drawing.Size(156, 13)
        Me.lblQCtype.TabIndex = 21
        Me.lblQCtype.Text = "Select Option for QC Type"
        '
        'lblDataTransferProgress
        '
        Me.lblDataTransferProgress.AutoSize = True
        Me.lblDataTransferProgress.ForeColor = System.Drawing.Color.Red
        Me.lblDataTransferProgress.Location = New System.Drawing.Point(37, 394)
        Me.lblDataTransferProgress.Name = "lblDataTransferProgress"
        Me.lblDataTransferProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblDataTransferProgress.TabIndex = 22
        '
        'pnlQCTypes
        '
        Me.pnlQCTypes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQCTypes.Controls.Add(Me.optInterElement)
        Me.pnlQCTypes.Controls.Add(Me.optAbsoluteLimits)
        Me.pnlQCTypes.Location = New System.Drawing.Point(3, 27)
        Me.pnlQCTypes.Name = "pnlQCTypes"
        Me.pnlQCTypes.Size = New System.Drawing.Size(302, 259)
        Me.pnlQCTypes.TabIndex = 23
        '
        'optInterElement
        '
        Me.optInterElement.AutoSize = True
        Me.optInterElement.Location = New System.Drawing.Point(8, 56)
        Me.optInterElement.Name = "optInterElement"
        Me.optInterElement.Size = New System.Drawing.Size(181, 17)
        Me.optInterElement.TabIndex = 22
        Me.optInterElement.Text = "Inter-element comparison checks"
        Me.optInterElement.UseVisualStyleBackColor = True
        '
        'optAbsoluteLimits
        '
        Me.optAbsoluteLimits.AutoSize = True
        Me.optAbsoluteLimits.Checked = True
        Me.optAbsoluteLimits.Location = New System.Drawing.Point(8, 21)
        Me.optAbsoluteLimits.Name = "optAbsoluteLimits"
        Me.optAbsoluteLimits.Size = New System.Drawing.Size(129, 17)
        Me.optAbsoluteLimits.TabIndex = 21
        Me.optAbsoluteLimits.TabStop = True
        Me.optAbsoluteLimits.Text = "Absolute limits checks"
        Me.optAbsoluteLimits.UseVisualStyleBackColor = True
        '
        'lblStationsElementsList
        '
        Me.lblStationsElementsList.AutoSize = True
        Me.lblStationsElementsList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationsElementsList.ForeColor = System.Drawing.Color.Black
        Me.lblStationsElementsList.Location = New System.Drawing.Point(471, 10)
        Me.lblStationsElementsList.Name = "lblStationsElementsList"
        Me.lblStationsElementsList.Size = New System.Drawing.Size(268, 13)
        Me.lblStationsElementsList.TabIndex = 24
        Me.lblStationsElementsList.Text = "Check to Select Stations and Elements for QC"
        '
        'lblSelectTimeRange
        '
        Me.lblSelectTimeRange.AutoSize = True
        Me.lblSelectTimeRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTimeRange.ForeColor = System.Drawing.Color.Black
        Me.lblSelectTimeRange.Location = New System.Drawing.Point(67, 303)
        Me.lblSelectTimeRange.Name = "lblSelectTimeRange"
        Me.lblSelectTimeRange.Size = New System.Drawing.Size(115, 13)
        Me.lblSelectTimeRange.TabIndex = 25
        Me.lblSelectTimeRange.Text = "Select Time Range"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(313, 37)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 27
        Me.lblStation.Text = "Select Station"
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(311, 57)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(221, 21)
        Me.cmbstation.TabIndex = 26
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(629, 36)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 29
        Me.lblElement.Text = "Select Element"
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(622, 57)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(200, 21)
        Me.cmbElement.TabIndex = 28
        '
        'txtProgress
        '
        Me.txtProgress.Location = New System.Drawing.Point(8, 431)
        Me.txtProgress.Name = "txtProgress"
        Me.txtProgress.Size = New System.Drawing.Size(297, 20)
        Me.txtProgress.TabIndex = 30
        Me.txtProgress.Visible = False
        '
        'frmQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 506)
        Me.Controls.Add(Me.txtProgress)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.cmbElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cmbstation)
        Me.Controls.Add(Me.lblSelectTimeRange)
        Me.Controls.Add(Me.lblStationsElementsList)
        Me.Controls.Add(Me.pnlQCTypes)
        Me.Controls.Add(Me.lblDataTransferProgress)
        Me.Controls.Add(Me.lblQCtype)
        Me.Controls.Add(Me.cmdPerformQC)
        Me.Controls.Add(Me.chkAllElements)
        Me.Controls.Add(Me.chkAllStations)
        Me.Controls.Add(Me.lstViewElements)
        Me.Controls.Add(Me.LstViewStations)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.pnlQcStandard)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.pnlAdvanced)
        Me.Name = "frmQC"
        Me.Text = "Quality Control Checks"
        Me.pnlAdvanced.ResumeLayout(False)
        Me.pnlAdvanced.PerformLayout()
        Me.pnlQcStandard.ResumeLayout(False)
        Me.pnlQcStandard.PerformLayout()
        Me.pnlQCTypes.ResumeLayout(False)
        Me.pnlQCTypes.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents pnlAdvanced As System.Windows.Forms.Panel
    Friend WithEvents lblQcAdvanced As System.Windows.Forms.Label
    Friend WithEvents pnlQcStandard As System.Windows.Forms.Panel
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Public WithEvents LstViewStations As System.Windows.Forms.ListView
    Public WithEvents lstViewElements As System.Windows.Forms.ListView
    Friend WithEvents txtEndMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtBeginMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEndYear As System.Windows.Forms.TextBox
    Friend WithEvents txtBeginYear As System.Windows.Forms.TextBox
    Friend WithEvents lblEndMonth As System.Windows.Forms.Label
    Friend WithEvents lblBeginMonth As System.Windows.Forms.Label
    Friend WithEvents lblEndYear As System.Windows.Forms.Label
    Friend WithEvents lblBeginYear As System.Windows.Forms.Label
    Friend WithEvents chkAllStations As System.Windows.Forms.CheckBox
    Friend WithEvents chkAllElements As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPerformQC As System.Windows.Forms.Button
    Friend WithEvents lblQCtype As System.Windows.Forms.Label
    Friend WithEvents lblDataTransferProgress As System.Windows.Forms.Label
    Friend WithEvents pnlQCTypes As System.Windows.Forms.Panel
    Friend WithEvents optInterElement As System.Windows.Forms.RadioButton
    Friend WithEvents optAbsoluteLimits As System.Windows.Forms.RadioButton
    Friend WithEvents lblStationsElementsList As System.Windows.Forms.Label
    Friend WithEvents lblSelectTimeRange As System.Windows.Forms.Label
    Friend WithEvents lblStation As Label
    Friend WithEvents cmbstation As ComboBox
    Friend WithEvents lblElement As Label
    Friend WithEvents cmbElement As ComboBox
    Friend WithEvents txtProgress As TextBox
End Class
