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
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
        Me.ucrDay = New ClimsoftVer4.ucrDay()
        Me.ucrSynopticDataForManyElements = New ClimsoftVer4.ucrSynopticRA1()
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
        lblYear.Location = New System.Drawing.Point(338, 19)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 205
        lblYear.Text = "Year:"
        '
        'lblStationSelector
        '
        Me.lblStationSelector.AutoSize = True
        Me.lblStationSelector.Location = New System.Drawing.Point(55, 18)
        Me.lblStationSelector.Name = "lblStationSelector"
        Me.lblStationSelector.Size = New System.Drawing.Size(86, 13)
        Me.lblStationSelector.TabIndex = 209
        Me.lblStationSelector.Text = "Station Identifier:"
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(693, 19)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(33, 13)
        Me.lblHour.TabIndex = 208
        Me.lblHour.Text = "Hour:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(597, 19)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 207
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(448, 19)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 206
        Me.lblMonth.Text = "Month:"
        '
        'btnTDCF
        '
        Me.btnTDCF.Location = New System.Drawing.Point(541, 567)
        Me.btnTDCF.Name = "btnTDCF"
        Me.btnTDCF.Size = New System.Drawing.Size(64, 23)
        Me.btnTDCF.TabIndex = 679
        Me.btnTDCF.Text = "TDCF"
        Me.btnTDCF.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(465, 567)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(64, 23)
        Me.btnView.TabIndex = 678
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(682, 596)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 677
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(289, 602)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 676
        Me.Label5.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(354, 599)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(175, 20)
        Me.txtSequencer.TabIndex = 675
        Me.txtSequencer.Text = "seq_month_day_synoptime"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(693, 567)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(64, 23)
        Me.btnHelp.TabIndex = 669
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(389, 567)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(64, 23)
        Me.btnClear.TabIndex = 667
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(161, 567)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(64, 23)
        Me.btnCommit.TabIndex = 663
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(313, 567)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(64, 23)
        Me.btnDelete.TabIndex = 666
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(85, 567)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(64, 23)
        Me.btnAddNew.TabIndex = 665
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(237, 567)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(64, 23)
        Me.btnUpdate.TabIndex = 664
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(617, 567)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 23)
        Me.btnClose.TabIndex = 668
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(253, 537)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigation.TabIndex = 680
        '
        'ucrDay
        '
        Me.ucrDay.Location = New System.Drawing.Point(629, 14)
        Me.ucrDay.Name = "ucrDay"
        Me.ucrDay.Size = New System.Drawing.Size(51, 24)
        Me.ucrDay.TabIndex = 215
        '
        'ucrSynopticDataForManyElements
        '
        Me.ucrSynopticDataForManyElements.Location = New System.Drawing.Point(10, 44)
        Me.ucrSynopticDataForManyElements.Name = "ucrSynopticDataForManyElements"
        Me.ucrSynopticDataForManyElements.Size = New System.Drawing.Size(820, 485)
        Me.ucrSynopticDataForManyElements.TabIndex = 214
        '
        'ucrHour
        '
        Me.ucrHour.Location = New System.Drawing.Point(729, 14)
        Me.ucrHour.Name = "ucrHour"
        Me.ucrHour.Size = New System.Drawing.Size(59, 24)
        Me.ucrHour.TabIndex = 213
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(491, 14)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(100, 24)
        Me.ucrMonth.TabIndex = 212
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(373, 14)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(69, 24)
        Me.ucrYearSelector.TabIndex = 211
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(144, 14)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(184, 24)
        Me.ucrStationSelector.TabIndex = 210
        '
        'frmNewSynopticRA1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 631)
        Me.Controls.Add(Me.ucrNavigation)
        Me.Controls.Add(Me.btnTDCF)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrDay)
        Me.Controls.Add(Me.ucrSynopticDataForManyElements)
        Me.Controls.Add(Me.ucrHour)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblStationSelector)
        Me.Controls.Add(Me.lblHour)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(lblYear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
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
    Friend WithEvents ucrSynopticDataForManyElements As ucrSynopticRA1
    Friend WithEvents ucrDay As ucrDay
    Friend WithEvents btnTDCF As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCommit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents ucrNavigation As ucrNavigation
End Class
