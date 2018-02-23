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
        Me.btnCommit = New System.Windows.Forms.Button()
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
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
        Me.ucrDay = New ClimsoftVer4.ucrDay()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrHourlyWind = New ClimsoftVer4.ucrHourlyWind()
        lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(323, 21)
        lblYear.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(47, 20)
        lblYear.TabIndex = 216
        lblYear.Text = "Year:"
        '
        'lblStationSelector
        '
        Me.lblStationSelector.AutoSize = True
        Me.lblStationSelector.Location = New System.Drawing.Point(14, 23)
        Me.lblStationSelector.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationSelector.Name = "lblStationSelector"
        Me.lblStationSelector.Size = New System.Drawing.Size(64, 20)
        Me.lblStationSelector.TabIndex = 220
        Me.lblStationSelector.Text = "Station:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(644, 20)
        Me.lblDay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(41, 20)
        Me.lblDay.TabIndex = 218
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(452, 21)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(58, 20)
        Me.lblMonth.TabIndex = 217
        Me.lblMonth.Text = "Month:"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(622, 877)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(112, 35)
        Me.btnView.TabIndex = 670
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(866, 929)
        Me.btnUpload.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 35)
        Me.btnUpload.TabIndex = 669
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(866, 877)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(112, 35)
        Me.btnHelp.TabIndex = 668
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(501, 877)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 666
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(136, 877)
        Me.btnCommit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(112, 35)
        Me.btnCommit.TabIndex = 662
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(380, 877)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 665
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(15, 877)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 35)
        Me.btnAddNew.TabIndex = 663
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(258, 877)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(112, 35)
        Me.btnUpdate.TabIndex = 664
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(744, 877)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 35)
        Me.btnClose.TabIndex = 667
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSpeedDigits
        '
        Me.txtSpeedDigits.Enabled = False
        Me.txtSpeedDigits.Location = New System.Drawing.Point(754, 108)
        Me.txtSpeedDigits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSpeedDigits.Name = "txtSpeedDigits"
        Me.txtSpeedDigits.Size = New System.Drawing.Size(42, 26)
        Me.txtSpeedDigits.TabIndex = 675
        Me.txtSpeedDigits.Text = "2"
        '
        'txtDirectionDigits
        '
        Me.txtDirectionDigits.Enabled = False
        Me.txtDirectionDigits.Location = New System.Drawing.Point(494, 106)
        Me.txtDirectionDigits.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDirectionDigits.Name = "txtDirectionDigits"
        Me.txtDirectionDigits.Size = New System.Drawing.Size(42, 26)
        Me.txtDirectionDigits.TabIndex = 674
        Me.txtDirectionDigits.Text = "2"
        '
        'lblSpeedDigits
        '
        Me.lblSpeedDigits.AutoSize = True
        Me.lblSpeedDigits.ForeColor = System.Drawing.Color.Blue
        Me.lblSpeedDigits.Location = New System.Drawing.Point(565, 111)
        Me.lblSpeedDigits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpeedDigits.Name = "lblSpeedDigits"
        Me.lblSpeedDigits.Size = New System.Drawing.Size(181, 20)
        Me.lblSpeedDigits.TabIndex = 673
        Me.lblSpeedDigits.Text = "Number of digits:- speed"
        '
        'lblDirectionDigits
        '
        Me.lblDirectionDigits.AutoSize = True
        Me.lblDirectionDigits.ForeColor = System.Drawing.Color.Blue
        Me.lblDirectionDigits.Location = New System.Drawing.Point(291, 111)
        Me.lblDirectionDigits.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDirectionDigits.Name = "lblDirectionDigits"
        Me.lblDirectionDigits.Size = New System.Drawing.Size(197, 20)
        Me.lblDirectionDigits.TabIndex = 672
        Me.lblDirectionDigits.Text = "Number of digits:- direction"
        '
        'btnHourSelection
        '
        Me.btnHourSelection.ForeColor = System.Drawing.Color.Blue
        Me.btnHourSelection.Location = New System.Drawing.Point(17, 103)
        Me.btnHourSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHourSelection.Name = "btnHourSelection"
        Me.btnHourSelection.Size = New System.Drawing.Size(231, 35)
        Me.btnHourSelection.TabIndex = 671
        Me.btnHourSelection.Text = "Enable synoptic hours only"
        Me.btnHourSelection.UseVisualStyleBackColor = True
        '
        'lblSequencer
        '
        Me.lblSequencer.AutoSize = True
        Me.lblSequencer.Location = New System.Drawing.Point(283, 944)
        Me.lblSequencer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSequencer.Name = "lblSequencer"
        Me.lblSequencer.Size = New System.Drawing.Size(87, 20)
        Me.lblSequencer.TabIndex = 677
        Me.lblSequencer.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(381, 939)
        Me.txtSequencer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(298, 26)
        Me.txtSequencer.TabIndex = 676
        Me.txtSequencer.Text = "seq_month_day"
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(175, 786)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(504, 38)
        Me.ucrNavigation.TabIndex = 465
        '
        'ucrDay
        '
        Me.ucrDay.Location = New System.Drawing.Point(634, 43)
        Me.ucrDay.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrDay.Name = "ucrDay"
        Me.ucrDay.Size = New System.Drawing.Size(76, 37)
        Me.ucrDay.TabIndex = 225
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(456, 43)
        Me.ucrMonth.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(150, 37)
        Me.ucrMonth.TabIndex = 223
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(324, 43)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(104, 37)
        Me.ucrYearSelector.TabIndex = 222
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(18, 43)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(276, 37)
        Me.ucrStationSelector.TabIndex = 221
        '
        'ucrHourlyWind
        '
        Me.ucrHourlyWind.Location = New System.Drawing.Point(11, 165)
        Me.ucrHourlyWind.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrHourlyWind.Name = "ucrHourlyWind"
        Me.ucrHourlyWind.Size = New System.Drawing.Size(963, 598)
        Me.ucrHourlyWind.TabIndex = 678
        '
        'frmNewHourlyWind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 992)
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
        Me.Controls.Add(Me.btnCommit)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmNewHourlyWind"
        Me.Text = "s"
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
    Friend WithEvents btnCommit As Button
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
