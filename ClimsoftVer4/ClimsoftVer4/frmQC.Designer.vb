<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQC
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
        Me.components = New System.ComponentModel.Container()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource4 = New System.Windows.Forms.BindingSource(Me.components)
        Me.BindingSource5 = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlAdvanced.SuspendLayout()
        Me.pnlQcStandard.SuspendLayout()
        Me.pnlQCTypes.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(195, 435)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(73, 23)
        Me.cmdApply.TabIndex = 7
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        Me.cmdApply.Visible = False
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(126, 435)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(63, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        Me.cmdOk.Visible = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(151, 435)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(73, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(288, 435)
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
        Me.pnlAdvanced.Location = New System.Drawing.Point(693, 38)
        Me.pnlAdvanced.Name = "pnlAdvanced"
        Me.pnlAdvanced.Size = New System.Drawing.Size(100, 25)
        Me.pnlAdvanced.TabIndex = 9
        Me.pnlAdvanced.Visible = False
        '
        'lblQcAdvanced
        '
        Me.lblQcAdvanced.AutoSize = True
        Me.lblQcAdvanced.Location = New System.Drawing.Point(3, 0)
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
        Me.pnlQcStandard.Size = New System.Drawing.Size(255, 63)
        Me.pnlQcStandard.TabIndex = 8
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(206, 34)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 10
        Me.txtEndMonth.Text = "12"
        Me.txtEndMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(206, 6)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBeginMonth.TabIndex = 9
        Me.txtBeginMonth.Text = "01"
        Me.txtBeginMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(68, 36)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(44, 20)
        Me.txtEndYear.TabIndex = 8
        Me.txtEndYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(68, 8)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(44, 20)
        Me.txtBeginYear.TabIndex = 7
        Me.txtBeginYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(133, 38)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 6
        Me.lblEndMonth.Text = "End Month"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(133, 10)
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
        Me.btnUpdate.Location = New System.Drawing.Point(537, 428)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(137, 30)
        Me.btnUpdate.TabIndex = 11
        Me.btnUpdate.Text = "Update With QC Report"
        Me.btnUpdate.UseVisualStyleBackColor = False
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.Location = New System.Drawing.Point(264, 27)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(295, 357)
        Me.LstViewStations.TabIndex = 14
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'lstViewElements
        '
        Me.lstViewElements.CheckBoxes = True
        Me.lstViewElements.FullRowSelect = True
        Me.lstViewElements.GridLines = True
        Me.lstViewElements.Location = New System.Drawing.Point(565, 25)
        Me.lstViewElements.Name = "lstViewElements"
        Me.lstViewElements.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstViewElements.RightToLeftLayout = True
        Me.lstViewElements.Size = New System.Drawing.Size(276, 359)
        Me.lstViewElements.TabIndex = 15
        Me.lstViewElements.UseCompatibleStateImageBehavior = False
        Me.lstViewElements.View = System.Windows.Forms.View.Details
        '
        'chkAllStations
        '
        Me.chkAllStations.AutoSize = True
        Me.chkAllStations.Location = New System.Drawing.Point(267, 384)
        Me.chkAllStations.Name = "chkAllStations"
        Me.chkAllStations.Size = New System.Drawing.Size(111, 17)
        Me.chkAllStations.TabIndex = 16
        Me.chkAllStations.Text = "Select All Stations"
        Me.chkAllStations.UseVisualStyleBackColor = True
        '
        'chkAllElements
        '
        Me.chkAllElements.AutoSize = True
        Me.chkAllElements.Location = New System.Drawing.Point(568, 385)
        Me.chkAllElements.Name = "chkAllElements"
        Me.chkAllElements.Size = New System.Drawing.Size(116, 17)
        Me.chkAllElements.TabIndex = 17
        Me.chkAllElements.Text = "Select All Elements"
        Me.chkAllElements.UseVisualStyleBackColor = True
        '
        'cmdPerformQC
        '
        Me.cmdPerformQC.Location = New System.Drawing.Point(14, 435)
        Me.cmdPerformQC.Name = "cmdPerformQC"
        Me.cmdPerformQC.Size = New System.Drawing.Size(73, 23)
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
        Me.pnlQCTypes.Size = New System.Drawing.Size(257, 259)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(67, 303)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Select Time Range"
        '
        'BindingSource3
        '
        '
        'frmQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(848, 461)
        Me.Controls.Add(Me.Label1)
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
        Me.Controls.Add(Me.pnlAdvanced)
        Me.Controls.Add(Me.pnlQcStandard)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdApply)
        Me.Name = "frmQC"
        Me.Text = "Quality Control Checks"
        Me.pnlAdvanced.ResumeLayout(False)
        Me.pnlAdvanced.PerformLayout()
        Me.pnlQcStandard.ResumeLayout(False)
        Me.pnlQcStandard.PerformLayout()
        Me.pnlQCTypes.ResumeLayout(False)
        Me.pnlQCTypes.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents BindingSource2 As BindingSource
    Friend WithEvents BindingSource3 As BindingSource
    Friend WithEvents BindingSource4 As BindingSource
    Friend WithEvents BindingSource5 As BindingSource
End Class
