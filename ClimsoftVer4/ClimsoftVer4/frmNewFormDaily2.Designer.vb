<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFormDaily2
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
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.cmdAssignSameValue = New System.Windows.Forms.Button()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.grpUnits = New System.Windows.Forms.GroupBox()
        Me.lblVisibility = New System.Windows.Forms.Label()
        Me.LblCloudheight = New System.Windows.Forms.Label()
        Me.lblPrecip = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.ucrVisibilityUnits = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrCloudheightUnits = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrPrecipUnits = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrTempUnits = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.chkEnableSequencer = New System.Windows.Forms.CheckBox()
        Me.ucrInputValue = New ClimsoftVer4.ucrTextBox()
        Me.ucrHour = New ClimsoftVer4.ucrHour()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrFormDaily = New ClimsoftVer4.ucrFormDaily2()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrDaiy2Navigation = New ClimsoftVer4.ucrNavigation()
        Me.lblSequencer = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.grpUnits.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(23, 20)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station:"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(272, 20)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(48, 13)
        Me.lblElement.TabIndex = 1
        Me.lblElement.Text = "Element:"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(68, 55)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 5
        Me.lblYear.Text = "Year:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(152, 57)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 5
        Me.lblMonth.Text = "Month:"
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(275, 58)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(33, 13)
        Me.lblHour.TabIndex = 5
        Me.lblHour.Text = "Hour:"
        '
        'cmdAssignSameValue
        '
        Me.cmdAssignSameValue.ForeColor = System.Drawing.Color.Blue
        Me.cmdAssignSameValue.Location = New System.Drawing.Point(362, 71)
        Me.cmdAssignSameValue.Name = "cmdAssignSameValue"
        Me.cmdAssignSameValue.Size = New System.Drawing.Size(169, 23)
        Me.cmdAssignSameValue.TabIndex = 16
        Me.cmdAssignSameValue.Text = "Assign same value to all obs"
        Me.cmdAssignSameValue.UseVisualStyleBackColor = True
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.ForeColor = System.Drawing.Color.Blue
        Me.lblValue.Location = New System.Drawing.Point(535, 73)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(40, 13)
        Me.lblValue.TabIndex = 10
        Me.lblValue.Text = "Value="
        '
        'grpUnits
        '
        Me.grpUnits.Controls.Add(Me.lblVisibility)
        Me.grpUnits.Controls.Add(Me.LblCloudheight)
        Me.grpUnits.Controls.Add(Me.lblPrecip)
        Me.grpUnits.Controls.Add(Me.lblTemperature)
        Me.grpUnits.Controls.Add(Me.ucrVisibilityUnits)
        Me.grpUnits.Controls.Add(Me.ucrCloudheightUnits)
        Me.grpUnits.Controls.Add(Me.ucrPrecipUnits)
        Me.grpUnits.Controls.Add(Me.ucrTempUnits)
        Me.grpUnits.Location = New System.Drawing.Point(68, 106)
        Me.grpUnits.Name = "grpUnits"
        Me.grpUnits.Size = New System.Drawing.Size(567, 54)
        Me.grpUnits.TabIndex = 11
        Me.grpUnits.TabStop = False
        Me.grpUnits.Text = "Units"
        '
        'lblVisibility
        '
        Me.lblVisibility.AutoSize = True
        Me.lblVisibility.Location = New System.Drawing.Point(450, 22)
        Me.lblVisibility.Name = "lblVisibility"
        Me.lblVisibility.Size = New System.Drawing.Size(46, 13)
        Me.lblVisibility.TabIndex = 7
        Me.lblVisibility.Text = "Visibility:"
        '
        'LblCloudheight
        '
        Me.LblCloudheight.AutoSize = True
        Me.LblCloudheight.Location = New System.Drawing.Point(288, 22)
        Me.LblCloudheight.Name = "LblCloudheight"
        Me.LblCloudheight.Size = New System.Drawing.Size(69, 13)
        Me.LblCloudheight.TabIndex = 6
        Me.LblCloudheight.Text = "Cloud height:"
        '
        'lblPrecip
        '
        Me.lblPrecip.AutoSize = True
        Me.lblPrecip.Location = New System.Drawing.Point(179, 22)
        Me.lblPrecip.Name = "lblPrecip"
        Me.lblPrecip.Size = New System.Drawing.Size(40, 13)
        Me.lblPrecip.TabIndex = 5
        Me.lblPrecip.Text = "Precip:"
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Location = New System.Drawing.Point(22, 22)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(70, 13)
        Me.lblTemperature.TabIndex = 4
        Me.lblTemperature.Text = "Temperature:"
        '
        'ucrVisibilityUnits
        '
        Me.ucrVisibilityUnits.Location = New System.Drawing.Point(498, 19)
        Me.ucrVisibilityUnits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrVisibilityUnits.Name = "ucrVisibilityUnits"
        Me.ucrVisibilityUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrVisibilityUnits.TabIndex = 22
        '
        'ucrCloudheightUnits
        '
        Me.ucrCloudheightUnits.Location = New System.Drawing.Point(359, 19)
        Me.ucrCloudheightUnits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrCloudheightUnits.Name = "ucrCloudheightUnits"
        Me.ucrCloudheightUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrCloudheightUnits.TabIndex = 21
        '
        'ucrPrecipUnits
        '
        Me.ucrPrecipUnits.Location = New System.Drawing.Point(221, 19)
        Me.ucrPrecipUnits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrPrecipUnits.Name = "ucrPrecipUnits"
        Me.ucrPrecipUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrPrecipUnits.TabIndex = 20
        '
        'ucrTempUnits
        '
        Me.ucrTempUnits.Location = New System.Drawing.Point(94, 19)
        Me.ucrTempUnits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTempUnits.Name = "ucrTempUnits"
        Me.ucrTempUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrTempUnits.TabIndex = 19
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(444, 555)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(618, 555)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 13
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(357, 555)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(96, 555)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 6
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(270, 555)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(9, 555)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 8
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(183, 555)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 7
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(531, 555)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Enabled = False
        Me.btnUpload.Location = New System.Drawing.Point(618, 596)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 14
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'chkEnableSequencer
        '
        Me.chkEnableSequencer.AutoSize = True
        Me.chkEnableSequencer.Checked = True
        Me.chkEnableSequencer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnableSequencer.ForeColor = System.Drawing.Color.Red
        Me.chkEnableSequencer.Location = New System.Drawing.Point(531, 20)
        Me.chkEnableSequencer.Name = "chkEnableSequencer"
        Me.chkEnableSequencer.Size = New System.Drawing.Size(155, 17)
        Me.chkEnableSequencer.TabIndex = 18
        Me.chkEnableSequencer.Text = "Enable Element Sequencer"
        Me.chkEnableSequencer.UseVisualStyleBackColor = True
        '
        'ucrInputValue
        '
        Me.ucrInputValue.Location = New System.Drawing.Point(577, 71)
        Me.ucrInputValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrInputValue.Name = "ucrInputValue"
        Me.ucrInputValue.Size = New System.Drawing.Size(58, 26)
        Me.ucrInputValue.TabIndex = 17
        Me.ucrInputValue.TextboxValue = ""
        '
        'ucrHour
        '
        Me.ucrHour.Location = New System.Drawing.Point(277, 74)
        Me.ucrHour.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrHour.Name = "ucrHour"
        Me.ucrHour.Size = New System.Drawing.Size(65, 21)
        Me.ucrHour.TabIndex = 4
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(155, 73)
        Me.ucrMonth.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(98, 21)
        Me.ucrMonth.TabIndex = 3
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(68, 74)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(59, 21)
        Me.ucrYearSelector.TabIndex = 2
        '
        'ucrFormDaily
        '
        Me.ucrFormDaily.Location = New System.Drawing.Point(15, 160)
        Me.ucrFormDaily.Name = "ucrFormDaily"
        Me.ucrFormDaily.Size = New System.Drawing.Size(619, 353)
        Me.ucrFormDaily.TabIndex = 5
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.Location = New System.Drawing.Point(322, 17)
        Me.ucrElementSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(178, 21)
        Me.ucrElementSelector.TabIndex = 1
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(68, 17)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(175, 24)
        Me.ucrStationSelector.TabIndex = 0
        '
        'ucrDaiy2Navigation
        '
        Me.ucrDaiy2Navigation.Location = New System.Drawing.Point(105, 523)
        Me.ucrDaiy2Navigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDaiy2Navigation.Name = "ucrDaiy2Navigation"
        Me.ucrDaiy2Navigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrDaiy2Navigation.TabIndex = 15
        '
        'lblSequencer
        '
        Me.lblSequencer.AutoSize = True
        Me.lblSequencer.Location = New System.Drawing.Point(212, 602)
        Me.lblSequencer.Name = "lblSequencer"
        Me.lblSequencer.Size = New System.Drawing.Size(59, 13)
        Me.lblSequencer.TabIndex = 681
        Me.lblSequencer.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(277, 599)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 680
        Me.txtSequencer.Text = "seq_daily_element"
        '
        'frmNewFormDaily2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 631)
        Me.Controls.Add(Me.lblSequencer)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.ucrDaiy2Navigation)
        Me.Controls.Add(Me.chkEnableSequencer)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpUnits)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.ucrInputValue)
        Me.Controls.Add(Me.cmdAssignSameValue)
        Me.Controls.Add(Me.ucrHour)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.lblHour)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrFormDaily)
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Name = "frmNewFormDaily2"
        Me.Text = "Daily data for the whole month"
        Me.grpUnits.ResumeLayout(False)
        Me.grpUnits.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents lblStation As Label
    Friend WithEvents lblElement As Label
    Friend WithEvents ucrElementSelector As ucrElementSelector
    Friend WithEvents ucrFormDaily As ucrFormDaily2
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents lblYear As Label
    Friend WithEvents ucrMonth As ucrMonth
    Friend WithEvents lblMonth As Label
    Friend WithEvents ucrHour As ucrHour
    Friend WithEvents lblHour As Label
    Friend WithEvents cmdAssignSameValue As Button
    Friend WithEvents ucrInputValue As ucrTextBox
    Friend WithEvents lblValue As Label
    Friend WithEvents grpUnits As GroupBox
    Friend WithEvents ucrVisibilityUnits As ucrDataLinkCombobox
    Friend WithEvents ucrCloudheightUnits As ucrDataLinkCombobox
    Friend WithEvents ucrPrecipUnits As ucrDataLinkCombobox
    Friend WithEvents ucrTempUnits As ucrDataLinkCombobox
    Friend WithEvents lblVisibility As Label
    Friend WithEvents LblCloudheight As Label
    Friend WithEvents lblPrecip As Label
    Friend WithEvents lblTemperature As Label
    Friend WithEvents btnView As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCommit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents chkEnableSequencer As CheckBox
    Friend WithEvents ucrDaiy2Navigation As ucrNavigation
    Friend WithEvents lblSequencer As Label
    Friend WithEvents txtSequencer As TextBox
End Class
