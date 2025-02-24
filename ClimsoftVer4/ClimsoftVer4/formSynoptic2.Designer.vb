<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formSynoptic2
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
        Dim YyyyLabel As System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboHour = New System.Windows.Forms.ComboBox()
        Me.GroupBoxCommands = New System.Windows.Forms.GroupBox()
        Me.btnPush = New System.Windows.Forms.Button()
        Me.chkRepeatEntry = New System.Windows.Forms.CheckBox()
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
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpUnits = New System.Windows.Forms.GroupBox()
        Me.cboWindSpdUnits = New System.Windows.Forms.ComboBox()
        Me.cboVisibilityUnits = New System.Windows.Forms.ComboBox()
        Me.cboCloudheightUnits = New System.Windows.Forms.ComboBox()
        Me.cboPrecipUnits = New System.Windows.Forms.ComboBox()
        Me.cboTempUnits = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblVisibility = New System.Windows.Forms.Label()
        Me.LblCloudheight = New System.Windows.Forms.Label()
        Me.lblPrecip = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblInsDel = New System.Windows.Forms.Label()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.lblInvaliDate = New System.Windows.Forms.Label()
        YyyyLabel = New System.Windows.Forms.Label()
        Me.GroupBoxCommands.SuspendLayout()
        Me.grpUnits.SuspendLayout()
        Me.SuspendLayout()
        '
        'YyyyLabel
        '
        YyyyLabel.AutoSize = True
        YyyyLabel.Location = New System.Drawing.Point(132, 54)
        YyyyLabel.Name = "YyyyLabel"
        YyyyLabel.Size = New System.Drawing.Size(32, 13)
        YyyyLabel.TabIndex = 210
        YyyyLabel.Text = "Year:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 13)
        Me.Label4.TabIndex = 214
        Me.Label4.Text = "Station Identification"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Location = New System.Drawing.Point(153, 18)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(355, 21)
        Me.cboStation.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(426, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 213
        Me.Label3.Text = "Hour:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(346, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Day:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(241, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "Month:"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(287, 50)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(41, 21)
        Me.cboMonth.TabIndex = 2
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(381, 50)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(39, 21)
        Me.cboDay.TabIndex = 3
        '
        'cboHour
        '
        Me.cboHour.FormattingEnabled = True
        Me.cboHour.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", ""})
        Me.cboHour.Location = New System.Drawing.Point(469, 50)
        Me.cboHour.Name = "cboHour"
        Me.cboHour.Size = New System.Drawing.Size(39, 21)
        Me.cboHour.TabIndex = 4
        Me.cboHour.Text = "0"
        '
        'GroupBoxCommands
        '
        Me.GroupBoxCommands.Controls.Add(Me.btnPush)
        Me.GroupBoxCommands.Controls.Add(Me.chkRepeatEntry)
        Me.GroupBoxCommands.Controls.Add(Me.btnTDCF)
        Me.GroupBoxCommands.Controls.Add(Me.btnView)
        Me.GroupBoxCommands.Controls.Add(Me.btnUpload)
        Me.GroupBoxCommands.Controls.Add(Me.Label5)
        Me.GroupBoxCommands.Controls.Add(Me.txtSequencer)
        Me.GroupBoxCommands.Controls.Add(Me.btnHelp)
        Me.GroupBoxCommands.Controls.Add(Me.btnClear)
        Me.GroupBoxCommands.Controls.Add(Me.btnCommit)
        Me.GroupBoxCommands.Controls.Add(Me.btnDelete)
        Me.GroupBoxCommands.Controls.Add(Me.btnAddNew)
        Me.GroupBoxCommands.Controls.Add(Me.btnUpdate)
        Me.GroupBoxCommands.Controls.Add(Me.btnMovePrevious)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveFirst)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveLast)
        Me.GroupBoxCommands.Controls.Add(Me.recNumberTextBox)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveNext)
        Me.GroupBoxCommands.Controls.Add(Me.btnClose)
        Me.GroupBoxCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxCommands.Location = New System.Drawing.Point(0, 406)
        Me.GroupBoxCommands.Margin = New System.Windows.Forms.Padding(1)
        Me.GroupBoxCommands.Name = "GroupBoxCommands"
        Me.GroupBoxCommands.Size = New System.Drawing.Size(915, 95)
        Me.GroupBoxCommands.TabIndex = 1172
        Me.GroupBoxCommands.TabStop = False
        '
        'btnPush
        '
        Me.btnPush.Location = New System.Drawing.Point(621, 41)
        Me.btnPush.Name = "btnPush"
        Me.btnPush.Size = New System.Drawing.Size(73, 23)
        Me.btnPush.TabIndex = 700
        Me.btnPush.Text = "Push"
        Me.btnPush.UseVisualStyleBackColor = True
        '
        'chkRepeatEntry
        '
        Me.chkRepeatEntry.AutoSize = True
        Me.chkRepeatEntry.Enabled = False
        Me.chkRepeatEntry.Location = New System.Drawing.Point(101, 70)
        Me.chkRepeatEntry.Name = "chkRepeatEntry"
        Me.chkRepeatEntry.Size = New System.Drawing.Size(139, 17)
        Me.chkRepeatEntry.TabIndex = 699
        Me.chkRepeatEntry.Text = "Repeat Key Entry Mode"
        Me.chkRepeatEntry.UseVisualStyleBackColor = True
        '
        'btnTDCF
        '
        Me.btnTDCF.Location = New System.Drawing.Point(541, 41)
        Me.btnTDCF.Name = "btnTDCF"
        Me.btnTDCF.Size = New System.Drawing.Size(77, 23)
        Me.btnTDCF.TabIndex = 698
        Me.btnTDCF.Text = "TDCF"
        Me.btnTDCF.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(453, 41)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(82, 23)
        Me.btnView.TabIndex = 697
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(662, 72)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(85, 23)
        Me.btnUpload.TabIndex = 696
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(327, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 695
        Me.Label5.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(392, 68)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(67, 20)
        Me.txtSequencer.TabIndex = 694
        Me.txtSequencer.Text = "seq_hour"
        Me.txtSequencer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(774, 41)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(58, 23)
        Me.btnHelp.TabIndex = 688
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(376, 41)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(71, 23)
        Me.btnClear.TabIndex = 686
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(130, 41)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(69, 23)
        Me.btnCommit.TabIndex = 682
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(288, 41)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(82, 23)
        Me.btnDelete.TabIndex = 685
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(29, 41)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(95, 23)
        Me.btnAddNew.TabIndex = 684
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(205, 41)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(77, 23)
        Me.btnUpdate.TabIndex = 683
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(322, 15)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 693
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(264, 15)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 692
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(598, 15)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 691
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(380, 15)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 690
        Me.recNumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(543, 15)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 689
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(700, 41)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 23)
        Me.btnClose.TabIndex = 687
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpUnits
        '
        Me.grpUnits.Controls.Add(Me.cboWindSpdUnits)
        Me.grpUnits.Controls.Add(Me.cboVisibilityUnits)
        Me.grpUnits.Controls.Add(Me.cboCloudheightUnits)
        Me.grpUnits.Controls.Add(Me.cboPrecipUnits)
        Me.grpUnits.Controls.Add(Me.cboTempUnits)
        Me.grpUnits.Controls.Add(Me.Label6)
        Me.grpUnits.Controls.Add(Me.lblVisibility)
        Me.grpUnits.Controls.Add(Me.LblCloudheight)
        Me.grpUnits.Controls.Add(Me.lblPrecip)
        Me.grpUnits.Controls.Add(Me.lblTemperature)
        Me.grpUnits.Location = New System.Drawing.Point(514, 8)
        Me.grpUnits.Name = "grpUnits"
        Me.grpUnits.Size = New System.Drawing.Size(326, 63)
        Me.grpUnits.TabIndex = 1188
        Me.grpUnits.TabStop = False
        Me.grpUnits.Text = "Units"
        '
        'cboWindSpdUnits
        '
        Me.cboWindSpdUnits.FormattingEnabled = True
        Me.cboWindSpdUnits.Items.AddRange(New Object() {"knots", "m/s"})
        Me.cboWindSpdUnits.Location = New System.Drawing.Point(259, 32)
        Me.cboWindSpdUnits.Name = "cboWindSpdUnits"
        Me.cboWindSpdUnits.Size = New System.Drawing.Size(54, 21)
        Me.cboWindSpdUnits.TabIndex = 1197
        Me.cboWindSpdUnits.Text = "knots"
        '
        'cboVisibilityUnits
        '
        Me.cboVisibilityUnits.FormattingEnabled = True
        Me.cboVisibilityUnits.Items.AddRange(New Object() {"metres", "yards", "km", "miles"})
        Me.cboVisibilityUnits.Location = New System.Drawing.Point(199, 32)
        Me.cboVisibilityUnits.Name = "cboVisibilityUnits"
        Me.cboVisibilityUnits.Size = New System.Drawing.Size(54, 21)
        Me.cboVisibilityUnits.TabIndex = 1196
        Me.cboVisibilityUnits.Text = "meters"
        '
        'cboCloudheightUnits
        '
        Me.cboCloudheightUnits.FormattingEnabled = True
        Me.cboCloudheightUnits.Items.AddRange(New Object() {"metres", "feet"})
        Me.cboCloudheightUnits.Location = New System.Drawing.Point(117, 32)
        Me.cboCloudheightUnits.Name = "cboCloudheightUnits"
        Me.cboCloudheightUnits.Size = New System.Drawing.Size(76, 21)
        Me.cboCloudheightUnits.TabIndex = 1195
        Me.cboCloudheightUnits.Text = "meters"
        '
        'cboPrecipUnits
        '
        Me.cboPrecipUnits.FormattingEnabled = True
        Me.cboPrecipUnits.Items.AddRange(New Object() {"mm", "inches"})
        Me.cboPrecipUnits.Location = New System.Drawing.Point(61, 32)
        Me.cboPrecipUnits.Name = "cboPrecipUnits"
        Me.cboPrecipUnits.Size = New System.Drawing.Size(54, 21)
        Me.cboPrecipUnits.TabIndex = 1194
        Me.cboPrecipUnits.Text = "mm"
        '
        'cboTempUnits
        '
        Me.cboTempUnits.FormattingEnabled = True
        Me.cboTempUnits.Items.AddRange(New Object() {"Deg C", "Deg F"})
        Me.cboTempUnits.Location = New System.Drawing.Point(5, 32)
        Me.cboTempUnits.Name = "cboTempUnits"
        Me.cboTempUnits.Size = New System.Drawing.Size(54, 21)
        Me.cboTempUnits.TabIndex = 1193
        Me.cboTempUnits.Text = "deg C"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(259, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 1192
        Me.Label6.Text = "Wind Spd"
        '
        'lblVisibility
        '
        Me.lblVisibility.AutoSize = True
        Me.lblVisibility.Location = New System.Drawing.Point(204, 18)
        Me.lblVisibility.Name = "lblVisibility"
        Me.lblVisibility.Size = New System.Drawing.Size(43, 13)
        Me.lblVisibility.TabIndex = 1191
        Me.lblVisibility.Text = "Visibility"
        '
        'LblCloudheight
        '
        Me.LblCloudheight.AutoSize = True
        Me.LblCloudheight.Location = New System.Drawing.Point(120, 18)
        Me.LblCloudheight.Name = "LblCloudheight"
        Me.LblCloudheight.Size = New System.Drawing.Size(46, 13)
        Me.LblCloudheight.TabIndex = 1190
        Me.LblCloudheight.Text = "Cloud ht"
        '
        'lblPrecip
        '
        Me.lblPrecip.AutoSize = True
        Me.lblPrecip.Location = New System.Drawing.Point(67, 16)
        Me.lblPrecip.Name = "lblPrecip"
        Me.lblPrecip.Size = New System.Drawing.Size(37, 13)
        Me.lblPrecip.TabIndex = 1189
        Me.lblPrecip.Text = "Precip"
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Location = New System.Drawing.Point(11, 18)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(34, 13)
        Me.lblTemperature.TabIndex = 1188
        Me.lblTemperature.Text = "Temp"
        '
        'lblInsDel
        '
        Me.lblInsDel.AutoSize = True
        Me.lblInsDel.ForeColor = System.Drawing.Color.Blue
        Me.lblInsDel.Location = New System.Drawing.Point(511, 74)
        Me.lblInsDel.Name = "lblInsDel"
        Me.lblInsDel.Size = New System.Drawing.Size(241, 13)
        Me.lblInsDel.TabIndex = 701
        Me.lblInsDel.Text = "Press Pg Down to Insert Cell and Pg Up to Delete"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(175, 50)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(55, 21)
        Me.cboYear.TabIndex = 1
        '
        'lblInvaliDate
        '
        Me.lblInvaliDate.AutoSize = True
        Me.lblInvaliDate.BackColor = System.Drawing.Color.Transparent
        Me.lblInvaliDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvaliDate.Location = New System.Drawing.Point(193, 77)
        Me.lblInvaliDate.Name = "lblInvaliDate"
        Me.lblInvaliDate.Size = New System.Drawing.Size(0, 15)
        Me.lblInvaliDate.TabIndex = 1189
        '
        'formSynoptic2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 501)
        Me.Controls.Add(Me.lblInvaliDate)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.lblInsDel)
        Me.Controls.Add(Me.grpUnits)
        Me.Controls.Add(Me.GroupBoxCommands)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboStation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.cboHour)
        Me.Controls.Add(YyyyLabel)
        Me.KeyPreview = True
        Me.Name = "formSynoptic2"
        Me.RightToLeftLayout = True
        Me.Text = "Synoptic data for many elements for one  observation time - TDCF"
        Me.GroupBoxCommands.ResumeLayout(False)
        Me.GroupBoxCommands.PerformLayout()
        Me.grpUnits.ResumeLayout(False)
        Me.grpUnits.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents cboHour As ComboBox
    Friend WithEvents GroupBoxCommands As GroupBox
    Friend WithEvents chkRepeatEntry As CheckBox
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
    Friend WithEvents btnMovePrevious As Button
    Friend WithEvents btnMoveFirst As Button
    Friend WithEvents btnMoveLast As Button
    Friend WithEvents recNumberTextBox As TextBox
    Friend WithEvents btnMoveNext As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents grpUnits As GroupBox
    Friend WithEvents cboWindSpdUnits As ComboBox
    Friend WithEvents cboVisibilityUnits As ComboBox
    Friend WithEvents cboCloudheightUnits As ComboBox
    Friend WithEvents cboPrecipUnits As ComboBox
    Friend WithEvents cboTempUnits As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents lblVisibility As Label
    Friend WithEvents LblCloudheight As Label
    Friend WithEvents lblPrecip As Label
    Friend WithEvents lblTemperature As Label
    Friend WithEvents lblInsDel As Label
    Friend WithEvents btnPush As Button
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents lblInvaliDate As Label
End Class
