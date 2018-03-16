<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewHourly
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
        Dim lblYear As System.Windows.Forms.Label
        Me.lblStationSelector = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmdAssignSameValue = New System.Windows.Forms.Button()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.btnHourSelection = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblSequencer = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.ucrHourlyNavigation = New ClimsoftVer4.ucrNavigation()
        Me.ucrHourly = New ClimsoftVer4.ucrHourly()
        Me.ucrInputValue = New ClimsoftVer4.ucrTextBox()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrDay = New ClimsoftVer4.ucrDay()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(9, 45)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 216
        lblYear.Text = "Year:"
        '
        'lblStationSelector
        '
        Me.lblStationSelector.AutoSize = True
        Me.lblStationSelector.Location = New System.Drawing.Point(9, 15)
        Me.lblStationSelector.Name = "lblStationSelector"
        Me.lblStationSelector.Size = New System.Drawing.Size(43, 13)
        Me.lblStationSelector.TabIndex = 220
        Me.lblStationSelector.Text = "Station:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(284, 47)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 218
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(135, 47)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 217
        Me.lblMonth.Text = "Month:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(359, 94)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 230
        Me.Label30.Text = "Value="
        '
        'cmdAssignSameValue
        '
        Me.cmdAssignSameValue.ForeColor = System.Drawing.Color.Blue
        Me.cmdAssignSameValue.Location = New System.Drawing.Point(185, 91)
        Me.cmdAssignSameValue.Name = "cmdAssignSameValue"
        Me.cmdAssignSameValue.Size = New System.Drawing.Size(169, 23)
        Me.cmdAssignSameValue.TabIndex = 228
        Me.cmdAssignSameValue.Text = "Assign same value to all obs"
        Me.cmdAssignSameValue.UseVisualStyleBackColor = True
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(270, 12)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(48, 13)
        Me.lblElement.TabIndex = 226
        Me.lblElement.Text = "Element:"
        '
        'btnHourSelection
        '
        Me.btnHourSelection.ForeColor = System.Drawing.Color.Blue
        Me.btnHourSelection.Location = New System.Drawing.Point(12, 91)
        Me.btnHourSelection.Name = "btnHourSelection"
        Me.btnHourSelection.Size = New System.Drawing.Size(154, 23)
        Me.btnHourSelection.TabIndex = 463
        Me.btnHourSelection.Text = "Enable synoptic hours only"
        Me.btnHourSelection.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(415, 570)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 670
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(577, 604)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 669
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(577, 570)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 668
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(334, 570)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 666
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(91, 570)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 662
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(253, 570)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 665
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(10, 570)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 663
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(172, 570)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 664
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(496, 570)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 667
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblSequencer
        '
        Me.lblSequencer.AutoSize = True
        Me.lblSequencer.Location = New System.Drawing.Point(188, 616)
        Me.lblSequencer.Name = "lblSequencer"
        Me.lblSequencer.Size = New System.Drawing.Size(59, 13)
        Me.lblSequencer.TabIndex = 679
        Me.lblSequencer.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(253, 613)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 678
        Me.txtSequencer.Text = "seq_month_day_element"
        '
        'ucrHourlyNavigation
        '
        Me.ucrHourlyNavigation.Location = New System.Drawing.Point(121, 517)
        Me.ucrHourlyNavigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrHourlyNavigation.Name = "ucrHourlyNavigation"
        Me.ucrHourlyNavigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrHourlyNavigation.TabIndex = 465
        '
        'ucrHourly
        '
        Me.ucrHourly.Location = New System.Drawing.Point(104, 120)
        Me.ucrHourly.Name = "ucrHourly"
        Me.ucrHourly.Size = New System.Drawing.Size(445, 389)
        Me.ucrHourly.TabIndex = 464
        '
        'ucrInputValue
        '
        Me.ucrInputValue.Location = New System.Drawing.Point(399, 88)
        Me.ucrInputValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrInputValue.Name = "ucrInputValue"
        Me.ucrInputValue.Size = New System.Drawing.Size(58, 26)
        Me.ucrInputValue.TabIndex = 229
        Me.ucrInputValue.TextboxValue = ""
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.Location = New System.Drawing.Point(316, 12)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(178, 21)
        Me.ucrElementSelector.TabIndex = 227
        '
        'ucrDay
        '
        Me.ucrDay.Location = New System.Drawing.Point(316, 42)
        Me.ucrDay.Name = "ucrDay"
        Me.ucrDay.Size = New System.Drawing.Size(51, 24)
        Me.ucrDay.TabIndex = 225
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(178, 42)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(100, 24)
        Me.ucrMonth.TabIndex = 223
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(58, 42)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(69, 24)
        Me.ucrYearSelector.TabIndex = 222
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(58, 12)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(184, 24)
        Me.ucrStationSelector.TabIndex = 221
        '
        'frmNewHourly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 645)
        Me.Controls.Add(Me.lblSequencer)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrHourlyNavigation)
        Me.Controls.Add(Me.ucrHourly)
        Me.Controls.Add(Me.btnHourSelection)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.ucrInputValue)
        Me.Controls.Add(Me.cmdAssignSameValue)
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.ucrDay)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblStationSelector)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(lblYear)
        Me.Name = "frmNewHourly"
        Me.Text = "frmNewHourly"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrDay As ucrDay
    Friend WithEvents ucrMonth As ucrMonth
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents lblStationSelector As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents ucrInputValue As ucrTextBox
    Friend WithEvents cmdAssignSameValue As Button
    Friend WithEvents ucrElementSelector As ucrElementSelector
    Friend WithEvents lblElement As Label
    Friend WithEvents btnHourSelection As Button
    Friend WithEvents ucrHourly As ucrHourly
    Friend WithEvents ucrHourlyNavigation As ucrNavigation
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCommit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblSequencer As Label
    Friend WithEvents txtSequencer As TextBox
End Class
