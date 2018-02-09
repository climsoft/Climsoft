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
        Me.Label30 = New System.Windows.Forms.Label()
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
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkEnableSequencer = New System.Windows.Forms.CheckBox()
        Me.ucrInputSequncer = New ClimsoftVer4.ucrTextBox()
        Me.ucrInputValue = New ClimsoftVer4.ucrTextBox()
        Me.ucrHour = New ClimsoftVer4.ucrHour()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrFormDaily = New ClimsoftVer4.ucrFormDaily2()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.grpUnits.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(12, 20)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station:"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(280, 20)
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
        Me.cmdAssignSameValue.TabIndex = 8
        Me.cmdAssignSameValue.Text = "Assign same value to all obs"
        Me.cmdAssignSameValue.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(537, 77)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Value="
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
        Me.lblVisibility.Location = New System.Drawing.Point(447, 20)
        Me.lblVisibility.Name = "lblVisibility"
        Me.lblVisibility.Size = New System.Drawing.Size(46, 13)
        Me.lblVisibility.TabIndex = 7
        Me.lblVisibility.Text = "Visibility:"
        '
        'LblCloudheight
        '
        Me.LblCloudheight.AutoSize = True
        Me.LblCloudheight.Location = New System.Drawing.Point(283, 20)
        Me.LblCloudheight.Name = "LblCloudheight"
        Me.LblCloudheight.Size = New System.Drawing.Size(69, 13)
        Me.LblCloudheight.TabIndex = 6
        Me.LblCloudheight.Text = "Cloud height:"
        '
        'lblPrecip
        '
        Me.lblPrecip.AutoSize = True
        Me.lblPrecip.Location = New System.Drawing.Point(166, 20)
        Me.lblPrecip.Name = "lblPrecip"
        Me.lblPrecip.Size = New System.Drawing.Size(40, 13)
        Me.lblPrecip.TabIndex = 5
        Me.lblPrecip.Text = "Precip:"
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Location = New System.Drawing.Point(6, 20)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(70, 13)
        Me.lblTemperature.TabIndex = 4
        Me.lblTemperature.Text = "Temperature:"
        '
        'ucrVisibilityUnits
        '
        Me.ucrVisibilityUnits.Location = New System.Drawing.Point(499, 20)
        Me.ucrVisibilityUnits.Name = "ucrVisibilityUnits"
        Me.ucrVisibilityUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrVisibilityUnits.TabIndex = 3
        '
        'ucrCloudheightUnits
        '
        Me.ucrCloudheightUnits.Location = New System.Drawing.Point(359, 19)
        Me.ucrCloudheightUnits.Name = "ucrCloudheightUnits"
        Me.ucrCloudheightUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrCloudheightUnits.TabIndex = 2
        '
        'ucrPrecipUnits
        '
        Me.ucrPrecipUnits.Location = New System.Drawing.Point(215, 20)
        Me.ucrPrecipUnits.Name = "ucrPrecipUnits"
        Me.ucrPrecipUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrPrecipUnits.TabIndex = 1
        '
        'ucrTempUnits
        '
        Me.ucrTempUnits.Location = New System.Drawing.Point(95, 20)
        Me.ucrTempUnits.Name = "ucrTempUnits"
        Me.ucrTempUnits.Size = New System.Drawing.Size(62, 21)
        Me.ucrTempUnits.TabIndex = 0
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(444, 555)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 673
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(618, 555)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 667
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(357, 555)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 665
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(96, 555)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 662
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(270, 555)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 664
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(9, 555)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 661
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(183, 555)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 663
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(252, 526)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 672
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(205, 526)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 671
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(495, 526)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 670
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(304, 528)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 669
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(451, 526)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 668
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(531, 555)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 666
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(618, 596)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 676
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(215, 606)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 675
        Me.Label5.Text = "Sequencer"
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
        Me.chkEnableSequencer.TabIndex = 677
        Me.chkEnableSequencer.Text = "Enable Element Sequencer"
        Me.chkEnableSequencer.UseVisualStyleBackColor = True
        '
        'ucrInputSequncer
        '
        Me.ucrInputSequncer.Location = New System.Drawing.Point(281, 596)
        Me.ucrInputSequncer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrInputSequncer.Name = "ucrInputSequncer"
        Me.ucrInputSequncer.Size = New System.Drawing.Size(150, 26)
        Me.ucrInputSequncer.TabIndex = 678
        Me.ucrInputSequncer.TextboxValue = ""
        '
        'ucrInputValue
        '
        Me.ucrInputValue.Location = New System.Drawing.Point(577, 71)
        Me.ucrInputValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrInputValue.Name = "ucrInputValue"
        Me.ucrInputValue.Size = New System.Drawing.Size(58, 26)
        Me.ucrInputValue.TabIndex = 9
        Me.ucrInputValue.TextboxValue = ""
        '
        'ucrHour
        '
        Me.ucrHour.Location = New System.Drawing.Point(277, 74)
        Me.ucrHour.Name = "ucrHour"
        Me.ucrHour.Size = New System.Drawing.Size(65, 21)
        Me.ucrHour.TabIndex = 7
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(155, 73)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(98, 21)
        Me.ucrMonth.TabIndex = 6
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(68, 74)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(59, 21)
        Me.ucrYearSelector.TabIndex = 4
        '
        'ucrFormDaily
        '
        Me.ucrFormDaily.Location = New System.Drawing.Point(14, 159)
        Me.ucrFormDaily.Name = "ucrFormDaily"
        Me.ucrFormDaily.Size = New System.Drawing.Size(712, 356)
        Me.ucrFormDaily.TabIndex = 3
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.Location = New System.Drawing.Point(326, 20)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(178, 21)
        Me.ucrElementSelector.TabIndex = 2
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(69, 20)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(175, 24)
        Me.ucrStationSelector.TabIndex = 0
        '
        'frmNewFormDaily2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 631)
        Me.Controls.Add(Me.ucrInputSequncer)
        Me.Controls.Add(Me.chkEnableSequencer)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnMovePrevious)
        Me.Controls.Add(Me.btnMoveFirst)
        Me.Controls.Add(Me.btnMoveLast)
        Me.Controls.Add(Me.recNumberTextBox)
        Me.Controls.Add(Me.btnMoveNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpUnits)
        Me.Controls.Add(Me.Label30)
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
        Me.Text = "frmNewFormDaily2"
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
    Friend WithEvents Label30 As Label
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
    Friend WithEvents btnMovePrevious As Button
    Friend WithEvents btnMoveFirst As Button
    Friend WithEvents btnMoveLast As Button
    Friend WithEvents recNumberTextBox As TextBox
    Friend WithEvents btnMoveNext As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents chkEnableSequencer As CheckBox
    Friend WithEvents ucrInputSequncer As ucrTextBox
End Class
