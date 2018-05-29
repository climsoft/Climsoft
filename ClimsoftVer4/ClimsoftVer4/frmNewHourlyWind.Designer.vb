<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewHourlyWind
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
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSpeedDigits = New System.Windows.Forms.TextBox()
        Me.txtDirectionDigits = New System.Windows.Forms.TextBox()
        Me.lblSpeedDigits = New System.Windows.Forms.Label()
        Me.lblDirectionDigits = New System.Windows.Forms.Label()
        Me.btnHourSelection = New System.Windows.Forms.Button()
        Me.lblSequencer = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.ucrHourlyWind = New ClimsoftVer4.ucrHourlyWind()
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
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
        lblYear.Location = New System.Drawing.Point(216, 7)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 216
        lblYear.Text = "Year:"
        '
        'lblStationSelector
        '
        Me.lblStationSelector.AutoSize = True
        Me.lblStationSelector.Location = New System.Drawing.Point(13, 7)
        Me.lblStationSelector.Name = "lblStationSelector"
        Me.lblStationSelector.Size = New System.Drawing.Size(43, 13)
        Me.lblStationSelector.TabIndex = 220
        Me.lblStationSelector.Text = "Station:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(422, 7)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 218
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(304, 7)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 217
        Me.lblMonth.Text = "Month:"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(410, 508)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 670
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(569, 532)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 669
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(573, 508)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 668
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(329, 508)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 666
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(86, 508)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 662
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(249, 508)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 665
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(5, 508)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 663
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(167, 508)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 664
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(491, 508)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 667
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSpeedDigits
        '
        Me.txtSpeedDigits.Enabled = False
        Me.txtSpeedDigits.Location = New System.Drawing.Point(503, 52)
        Me.txtSpeedDigits.Name = "txtSpeedDigits"
        Me.txtSpeedDigits.Size = New System.Drawing.Size(29, 20)
        Me.txtSpeedDigits.TabIndex = 675
        Me.txtSpeedDigits.Text = "2"
        '
        'txtDirectionDigits
        '
        Me.txtDirectionDigits.Enabled = False
        Me.txtDirectionDigits.Location = New System.Drawing.Point(330, 51)
        Me.txtDirectionDigits.Name = "txtDirectionDigits"
        Me.txtDirectionDigits.Size = New System.Drawing.Size(29, 20)
        Me.txtDirectionDigits.TabIndex = 674
        Me.txtDirectionDigits.Text = "2"
        '
        'lblSpeedDigits
        '
        Me.lblSpeedDigits.AutoSize = True
        Me.lblSpeedDigits.ForeColor = System.Drawing.Color.Blue
        Me.lblSpeedDigits.Location = New System.Drawing.Point(377, 54)
        Me.lblSpeedDigits.Name = "lblSpeedDigits"
        Me.lblSpeedDigits.Size = New System.Drawing.Size(121, 13)
        Me.lblSpeedDigits.TabIndex = 673
        Me.lblSpeedDigits.Text = "Number of digits:- speed"
        '
        'lblDirectionDigits
        '
        Me.lblDirectionDigits.AutoSize = True
        Me.lblDirectionDigits.ForeColor = System.Drawing.Color.Blue
        Me.lblDirectionDigits.Location = New System.Drawing.Point(195, 54)
        Me.lblDirectionDigits.Name = "lblDirectionDigits"
        Me.lblDirectionDigits.Size = New System.Drawing.Size(132, 13)
        Me.lblDirectionDigits.TabIndex = 672
        Me.lblDirectionDigits.Text = "Number of digits:- direction"
        '
        'btnHourSelection
        '
        Me.btnHourSelection.ForeColor = System.Drawing.Color.Blue
        Me.btnHourSelection.Location = New System.Drawing.Point(12, 49)
        Me.btnHourSelection.Name = "btnHourSelection"
        Me.btnHourSelection.Size = New System.Drawing.Size(154, 23)
        Me.btnHourSelection.TabIndex = 671
        Me.btnHourSelection.Text = "Enable synoptic hours only"
        Me.btnHourSelection.UseVisualStyleBackColor = True
        '
        'lblSequencer
        '
        Me.lblSequencer.AutoSize = True
        Me.lblSequencer.Location = New System.Drawing.Point(180, 542)
        Me.lblSequencer.Name = "lblSequencer"
        Me.lblSequencer.Size = New System.Drawing.Size(59, 13)
        Me.lblSequencer.TabIndex = 677
        Me.lblSequencer.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(245, 539)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 676
        Me.txtSequencer.Text = "seq_month_day"
        '
        'ucrHourlyWind
        '
        Me.ucrHourlyWind.Location = New System.Drawing.Point(4, 76)
        Me.ucrHourlyWind.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrHourlyWind.Name = "ucrHourlyWind"
        Me.ucrHourlyWind.Size = New System.Drawing.Size(642, 389)
        Me.ucrHourlyWind.TabIndex = 678
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(117, 475)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigation.TabIndex = 465
        '
        'ucrDay
        '
        Me.ucrDay.Location = New System.Drawing.Point(419, 22)
        Me.ucrDay.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDay.Name = "ucrDay"
        Me.ucrDay.Size = New System.Drawing.Size(51, 24)
        Me.ucrDay.TabIndex = 225
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(301, 22)
        Me.ucrMonth.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(100, 24)
        Me.ucrMonth.TabIndex = 223
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(213, 22)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(69, 24)
        Me.ucrYearSelector.TabIndex = 222
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(10, 22)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(184, 24)
        Me.ucrStationSelector.TabIndex = 221
        '
        'frmNewHourlyWind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 566)
        Me.Controls.Add(Me.ucrHourlyWind)
        Me.Controls.Add(Me.lblSequencer)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.txtSpeedDigits)
        Me.Controls.Add(Me.txtDirectionDigits)
        Me.Controls.Add(Me.lblSpeedDigits)
        Me.Controls.Add(Me.lblDirectionDigits)
        Me.Controls.Add(Me.btnHourSelection)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrNavigation)
        Me.Controls.Add(Me.ucrDay)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblStationSelector)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(lblYear)
        Me.Name = "frmNewHourlyWind"
        Me.Text = "Hourly Wind Data"
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
    Friend WithEvents ucrNavigation As ucrNavigation
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents txtSpeedDigits As TextBox
    Friend WithEvents txtDirectionDigits As TextBox
    Friend WithEvents lblSpeedDigits As Label
    Friend WithEvents lblDirectionDigits As Label
    Friend WithEvents btnHourSelection As Button
    Friend WithEvents lblSequencer As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents ucrHourlyWind As ucrHourlyWind
End Class
