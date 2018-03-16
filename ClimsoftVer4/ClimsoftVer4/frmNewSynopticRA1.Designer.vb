<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewSynopticRA1
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
        Dim lblYear As System.Windows.Forms.Label
        Me.lblStationSelector = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.btnTDCF = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
        Me.ucrDay = New ClimsoftVer4.ucrDay()
        Me.ucrSynopticRA1 = New ClimsoftVer4.ucrSynopticRA1()
        Me.ucrHour = New ClimsoftVer4.ucrHour()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(507, 29)
        lblYear.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(47, 20)
        lblYear.TabIndex = 205
        lblYear.Text = "Year:"
        '
        'lblStationSelector
        '
        Me.lblStationSelector.AutoSize = True
        Me.lblStationSelector.Location = New System.Drawing.Point(82, 28)
        Me.lblStationSelector.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationSelector.Name = "lblStationSelector"
        Me.lblStationSelector.Size = New System.Drawing.Size(130, 20)
        Me.lblStationSelector.TabIndex = 209
        Me.lblStationSelector.Text = "Station Identifier:"
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(1040, 29)
        Me.lblHour.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(48, 20)
        Me.lblHour.TabIndex = 208
        Me.lblHour.Text = "Hour:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(896, 29)
        Me.lblDay.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(41, 20)
        Me.lblDay.TabIndex = 207
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(672, 29)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(58, 20)
        Me.lblMonth.TabIndex = 206
        Me.lblMonth.Text = "Month:"
        '
        'btnTDCF
        '
        Me.btnTDCF.Location = New System.Drawing.Point(812, 872)
        Me.btnTDCF.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnTDCF.Name = "btnTDCF"
        Me.btnTDCF.Size = New System.Drawing.Size(96, 35)
        Me.btnTDCF.TabIndex = 679
        Me.btnTDCF.Text = "TDCF"
        Me.btnTDCF.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(698, 872)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(96, 35)
        Me.btnView.TabIndex = 678
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(1023, 917)
        Me.btnUpload.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(112, 35)
        Me.btnUpload.TabIndex = 677
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(434, 926)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 676
        Me.Label5.Text = "Sequencer"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(1040, 872)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(96, 35)
        Me.btnHelp.TabIndex = 669
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(584, 872)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(96, 35)
        Me.btnClear.TabIndex = 667
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(242, 872)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 35)
        Me.btnSave.TabIndex = 663
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(470, 872)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 35)
        Me.btnDelete.TabIndex = 666
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(128, 872)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(96, 35)
        Me.btnAddNew.TabIndex = 665
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(356, 872)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(96, 35)
        Me.btnUpdate.TabIndex = 664
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(926, 872)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(96, 35)
        Me.btnClose.TabIndex = 668
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(529, 923)
        Me.txtSequencer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(260, 26)
        Me.txtSequencer.TabIndex = 681
        Me.txtSequencer.Text = "seq_month_day_synoptime"
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(380, 826)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(504, 38)
        Me.ucrNavigation.TabIndex = 680
        '
        'ucrDay
        '
        Me.ucrDay.Location = New System.Drawing.Point(944, 22)
        Me.ucrDay.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrDay.Name = "ucrDay"
        Me.ucrDay.Size = New System.Drawing.Size(76, 37)
        Me.ucrDay.TabIndex = 215
        '
        'ucrSynopticRA1
        '
        Me.ucrSynopticRA1.Location = New System.Drawing.Point(15, 68)
        Me.ucrSynopticRA1.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrSynopticRA1.Name = "ucrSynopticRA1"
        Me.ucrSynopticRA1.Size = New System.Drawing.Size(1230, 746)
        Me.ucrSynopticRA1.TabIndex = 214
        '
        'ucrHour
        '
        Me.ucrHour.Location = New System.Drawing.Point(1094, 22)
        Me.ucrHour.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrHour.Name = "ucrHour"
        Me.ucrHour.Size = New System.Drawing.Size(88, 37)
        Me.ucrHour.TabIndex = 213
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(736, 22)
        Me.ucrMonth.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(150, 37)
        Me.ucrMonth.TabIndex = 212
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(560, 22)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(104, 37)
        Me.ucrYearSelector.TabIndex = 211
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(216, 22)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(14, 18, 14, 18)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(276, 37)
        Me.ucrStationSelector.TabIndex = 210
        '
        'frmNewSynopticRA1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1263, 971)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.ucrNavigation)
        Me.Controls.Add(Me.btnTDCF)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrDay)
        Me.Controls.Add(Me.ucrSynopticRA1)
        Me.Controls.Add(Me.ucrHour)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblStationSelector)
        Me.Controls.Add(Me.lblHour)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(lblYear)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewSynopticRA1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Synoptic Data For Many Elements For WMO - RA1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStationSelector As Label
    Friend WithEvents lblHour As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents ucrMonth As ucrMonth
    Friend WithEvents ucrHour As ucrHour
    Friend WithEvents ucrSynopticRA1 As ucrSynopticRA1
    Friend WithEvents ucrDay As ucrDay
    Friend WithEvents btnTDCF As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents ucrNavigation As ucrNavigation
    Friend WithEvents txtSequencer As TextBox
End Class
