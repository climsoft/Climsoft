﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrMonthlyData
    Inherits ClimsoftVer4.ucrTableEntry

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim lblYear As System.Windows.Forms.Label
        Me.UcrValueFlagPeriod1 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod5 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod6 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod12 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod11 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod10 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod7 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod8 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod9 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod4 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod3 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.UcrValueFlagPeriod2 = New ClimsoftVer4.ucrValueFlagPeriod()
        Me.lblFlag = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lbl12 = New System.Windows.Forms.Label()
        Me.lbl11 = New System.Windows.Forms.Label()
        Me.lbl10 = New System.Windows.Forms.Label()
        Me.lbl09 = New System.Windows.Forms.Label()
        Me.lbl08 = New System.Windows.Forms.Label()
        Me.lbl07 = New System.Windows.Forms.Label()
        Me.lbl06 = New System.Windows.Forms.Label()
        Me.lbl05 = New System.Windows.Forms.Label()
        Me.lbl04 = New System.Windows.Forms.Label()
        Me.lbl03 = New System.Windows.Forms.Label()
        Me.lbl02 = New System.Windows.Forms.Label()
        Me.lbl01 = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
        lblYear = New System.Windows.Forms.Label()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(504, 10)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 589
        lblYear.Text = "Year:"
        '
        'UcrValueFlagPeriod1
        '
        Me.UcrValueFlagPeriod1.FieldName = "01"
        Me.UcrValueFlagPeriod1.IncludePeriod = True
        Me.UcrValueFlagPeriod1.KeyControl = False
        Me.UcrValueFlagPeriod1.Location = New System.Drawing.Point(234, 91)
        Me.UcrValueFlagPeriod1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod1.Name = "UcrValueFlagPeriod1"
        Me.UcrValueFlagPeriod1.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod1.TabIndex = 4
        Me.UcrValueFlagPeriod1.Tag = "01"
        '
        'UcrValueFlagPeriod5
        '
        Me.UcrValueFlagPeriod5.FieldName = "05"
        Me.UcrValueFlagPeriod5.IncludePeriod = True
        Me.UcrValueFlagPeriod5.KeyControl = False
        Me.UcrValueFlagPeriod5.Location = New System.Drawing.Point(234, 208)
        Me.UcrValueFlagPeriod5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod5.Name = "UcrValueFlagPeriod5"
        Me.UcrValueFlagPeriod5.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod5.TabIndex = 8
        Me.UcrValueFlagPeriod5.Tag = "05"
        '
        'UcrValueFlagPeriod6
        '
        Me.UcrValueFlagPeriod6.FieldName = "06"
        Me.UcrValueFlagPeriod6.IncludePeriod = True
        Me.UcrValueFlagPeriod6.KeyControl = False
        Me.UcrValueFlagPeriod6.Location = New System.Drawing.Point(234, 238)
        Me.UcrValueFlagPeriod6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod6.Name = "UcrValueFlagPeriod6"
        Me.UcrValueFlagPeriod6.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod6.TabIndex = 9
        Me.UcrValueFlagPeriod6.Tag = "06"
        '
        'UcrValueFlagPeriod12
        '
        Me.UcrValueFlagPeriod12.FieldName = "12"
        Me.UcrValueFlagPeriod12.IncludePeriod = True
        Me.UcrValueFlagPeriod12.KeyControl = False
        Me.UcrValueFlagPeriod12.Location = New System.Drawing.Point(234, 416)
        Me.UcrValueFlagPeriod12.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod12.Name = "UcrValueFlagPeriod12"
        Me.UcrValueFlagPeriod12.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod12.TabIndex = 15
        Me.UcrValueFlagPeriod12.Tag = "12"
        '
        'UcrValueFlagPeriod11
        '
        Me.UcrValueFlagPeriod11.FieldName = "11"
        Me.UcrValueFlagPeriod11.IncludePeriod = True
        Me.UcrValueFlagPeriod11.KeyControl = False
        Me.UcrValueFlagPeriod11.Location = New System.Drawing.Point(234, 387)
        Me.UcrValueFlagPeriod11.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod11.Name = "UcrValueFlagPeriod11"
        Me.UcrValueFlagPeriod11.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod11.TabIndex = 14
        Me.UcrValueFlagPeriod11.Tag = "11"
        '
        'UcrValueFlagPeriod10
        '
        Me.UcrValueFlagPeriod10.FieldName = "10"
        Me.UcrValueFlagPeriod10.IncludePeriod = True
        Me.UcrValueFlagPeriod10.KeyControl = False
        Me.UcrValueFlagPeriod10.Location = New System.Drawing.Point(234, 357)
        Me.UcrValueFlagPeriod10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod10.Name = "UcrValueFlagPeriod10"
        Me.UcrValueFlagPeriod10.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod10.TabIndex = 13
        Me.UcrValueFlagPeriod10.Tag = "10"
        '
        'UcrValueFlagPeriod7
        '
        Me.UcrValueFlagPeriod7.FieldName = "07"
        Me.UcrValueFlagPeriod7.IncludePeriod = True
        Me.UcrValueFlagPeriod7.KeyControl = False
        Me.UcrValueFlagPeriod7.Location = New System.Drawing.Point(234, 269)
        Me.UcrValueFlagPeriod7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod7.Name = "UcrValueFlagPeriod7"
        Me.UcrValueFlagPeriod7.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod7.TabIndex = 10
        Me.UcrValueFlagPeriod7.Tag = "07"
        '
        'UcrValueFlagPeriod8
        '
        Me.UcrValueFlagPeriod8.FieldName = "08"
        Me.UcrValueFlagPeriod8.IncludePeriod = True
        Me.UcrValueFlagPeriod8.KeyControl = False
        Me.UcrValueFlagPeriod8.Location = New System.Drawing.Point(234, 297)
        Me.UcrValueFlagPeriod8.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod8.Name = "UcrValueFlagPeriod8"
        Me.UcrValueFlagPeriod8.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod8.TabIndex = 11
        Me.UcrValueFlagPeriod8.Tag = "08"
        '
        'UcrValueFlagPeriod9
        '
        Me.UcrValueFlagPeriod9.FieldName = "09"
        Me.UcrValueFlagPeriod9.IncludePeriod = True
        Me.UcrValueFlagPeriod9.KeyControl = False
        Me.UcrValueFlagPeriod9.Location = New System.Drawing.Point(234, 327)
        Me.UcrValueFlagPeriod9.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod9.Name = "UcrValueFlagPeriod9"
        Me.UcrValueFlagPeriod9.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod9.TabIndex = 12
        Me.UcrValueFlagPeriod9.Tag = "09"
        '
        'UcrValueFlagPeriod4
        '
        Me.UcrValueFlagPeriod4.FieldName = "04"
        Me.UcrValueFlagPeriod4.IncludePeriod = True
        Me.UcrValueFlagPeriod4.KeyControl = False
        Me.UcrValueFlagPeriod4.Location = New System.Drawing.Point(234, 179)
        Me.UcrValueFlagPeriod4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod4.Name = "UcrValueFlagPeriod4"
        Me.UcrValueFlagPeriod4.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod4.TabIndex = 7
        Me.UcrValueFlagPeriod4.Tag = "04"
        '
        'UcrValueFlagPeriod3
        '
        Me.UcrValueFlagPeriod3.FieldName = "03"
        Me.UcrValueFlagPeriod3.IncludePeriod = True
        Me.UcrValueFlagPeriod3.KeyControl = False
        Me.UcrValueFlagPeriod3.Location = New System.Drawing.Point(234, 152)
        Me.UcrValueFlagPeriod3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod3.Name = "UcrValueFlagPeriod3"
        Me.UcrValueFlagPeriod3.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod3.TabIndex = 6
        Me.UcrValueFlagPeriod3.Tag = "03"
        '
        'UcrValueFlagPeriod2
        '
        Me.UcrValueFlagPeriod2.FieldName = "02"
        Me.UcrValueFlagPeriod2.IncludePeriod = True
        Me.UcrValueFlagPeriod2.KeyControl = False
        Me.UcrValueFlagPeriod2.Location = New System.Drawing.Point(234, 121)
        Me.UcrValueFlagPeriod2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrValueFlagPeriod2.Name = "UcrValueFlagPeriod2"
        Me.UcrValueFlagPeriod2.Size = New System.Drawing.Size(178, 28)
        Me.UcrValueFlagPeriod2.TabIndex = 5
        Me.UcrValueFlagPeriod2.Tag = "02"
        '
        'lblFlag
        '
        Me.lblFlag.AutoSize = True
        Me.lblFlag.Location = New System.Drawing.Point(303, 75)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Size = New System.Drawing.Size(27, 13)
        Me.lblFlag.TabIndex = 572
        Me.lblFlag.Text = "Flag"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(232, 75)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(34, 13)
        Me.lblValue.TabIndex = 571
        Me.lblValue.Text = "Value"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(169, 74)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 570
        Me.lblMonth.Text = "Month"
        '
        'lbl12
        '
        Me.lbl12.AutoSize = True
        Me.lbl12.Location = New System.Drawing.Point(166, 422)
        Me.lbl12.Name = "lbl12"
        Me.lbl12.Size = New System.Drawing.Size(56, 13)
        Me.lbl12.TabIndex = 584
        Me.lbl12.Text = "December"
        '
        'lbl11
        '
        Me.lbl11.AutoSize = True
        Me.lbl11.Location = New System.Drawing.Point(166, 392)
        Me.lbl11.Name = "lbl11"
        Me.lbl11.Size = New System.Drawing.Size(62, 13)
        Me.lbl11.TabIndex = 583
        Me.lbl11.Text = "Novemeber"
        '
        'lbl10
        '
        Me.lbl10.AutoSize = True
        Me.lbl10.Location = New System.Drawing.Point(166, 362)
        Me.lbl10.Name = "lbl10"
        Me.lbl10.Size = New System.Drawing.Size(45, 13)
        Me.lbl10.TabIndex = 582
        Me.lbl10.Text = "October"
        '
        'lbl09
        '
        Me.lbl09.AutoSize = True
        Me.lbl09.Location = New System.Drawing.Point(166, 331)
        Me.lbl09.Name = "lbl09"
        Me.lbl09.Size = New System.Drawing.Size(58, 13)
        Me.lbl09.TabIndex = 581
        Me.lbl09.Text = "September"
        '
        'lbl08
        '
        Me.lbl08.AutoSize = True
        Me.lbl08.Location = New System.Drawing.Point(166, 303)
        Me.lbl08.Name = "lbl08"
        Me.lbl08.Size = New System.Drawing.Size(40, 13)
        Me.lbl08.TabIndex = 580
        Me.lbl08.Text = "August"
        '
        'lbl07
        '
        Me.lbl07.AutoSize = True
        Me.lbl07.Location = New System.Drawing.Point(166, 275)
        Me.lbl07.Name = "lbl07"
        Me.lbl07.Size = New System.Drawing.Size(25, 13)
        Me.lbl07.TabIndex = 579
        Me.lbl07.Text = "July"
        '
        'lbl06
        '
        Me.lbl06.AutoSize = True
        Me.lbl06.Location = New System.Drawing.Point(166, 245)
        Me.lbl06.Name = "lbl06"
        Me.lbl06.Size = New System.Drawing.Size(30, 13)
        Me.lbl06.TabIndex = 578
        Me.lbl06.Text = "June"
        '
        'lbl05
        '
        Me.lbl05.AutoSize = True
        Me.lbl05.Location = New System.Drawing.Point(166, 214)
        Me.lbl05.Name = "lbl05"
        Me.lbl05.Size = New System.Drawing.Size(27, 13)
        Me.lbl05.TabIndex = 577
        Me.lbl05.Text = "May"
        '
        'lbl04
        '
        Me.lbl04.AutoSize = True
        Me.lbl04.Location = New System.Drawing.Point(166, 184)
        Me.lbl04.Name = "lbl04"
        Me.lbl04.Size = New System.Drawing.Size(27, 13)
        Me.lbl04.TabIndex = 576
        Me.lbl04.Text = "April"
        '
        'lbl03
        '
        Me.lbl03.AutoSize = True
        Me.lbl03.Location = New System.Drawing.Point(166, 158)
        Me.lbl03.Name = "lbl03"
        Me.lbl03.Size = New System.Drawing.Size(37, 13)
        Me.lbl03.TabIndex = 575
        Me.lbl03.Text = "March"
        '
        'lbl02
        '
        Me.lbl02.AutoSize = True
        Me.lbl02.Location = New System.Drawing.Point(166, 128)
        Me.lbl02.Name = "lbl02"
        Me.lbl02.Size = New System.Drawing.Size(48, 13)
        Me.lbl02.TabIndex = 574
        Me.lbl02.Text = "February"
        '
        'lbl01
        '
        Me.lbl01.AutoSize = True
        Me.lbl01.Location = New System.Drawing.Point(166, 95)
        Me.lbl01.Name = "lbl01"
        Me.lbl01.Size = New System.Drawing.Size(44, 13)
        Me.lbl01.TabIndex = 573
        Me.lbl01.Text = "January"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(356, 74)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(37, 13)
        Me.lblPeriod.TabIndex = 585
        Me.lblPeriod.Text = "Period"
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.FieldName = "yyyy"
        Me.ucrYearSelector.KeyControl = True
        Me.ucrYearSelector.Location = New System.Drawing.Point(507, 26)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(85, 25)
        Me.ucrYearSelector.TabIndex = 3
        Me.ucrYearSelector.Tag = "yyyy"
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.FieldName = "elementId"
        Me.ucrElementSelector.KeyControl = True
        Me.ucrElementSelector.Location = New System.Drawing.Point(274, 26)
        Me.ucrElementSelector.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(202, 21)
        Me.ucrElementSelector.TabIndex = 2
        Me.ucrElementSelector.Tag = "elementId"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "stationId"
        Me.ucrStationSelector.KeyControl = True
        Me.ucrStationSelector.Location = New System.Drawing.Point(62, 26)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(197, 24)
        Me.ucrStationSelector.TabIndex = 1
        Me.ucrStationSelector.Tag = "stationId"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(271, 9)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(48, 13)
        Me.lblElement.TabIndex = 591
        Me.lblElement.Text = "Element:"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(59, 11)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 590
        Me.lblStation.Text = "Station:"
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(482, 544)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(83, 23)
        Me.btnUpload.TabIndex = 25
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(148, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 687
        Me.Label5.Text = "Sequencer:"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(233, 544)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.ReadOnly = True
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 686
        Me.txtSequencer.Text = "seq_monthly_element"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(399, 507)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(77, 23)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Tag = "cancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(482, 507)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 23)
        Me.btnView.TabIndex = 22
        Me.btnView.Tag = ""
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(650, 507)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(66, 23)
        Me.btnHelp.TabIndex = 24
        Me.btnHelp.Tag = ""
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(322, 507)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(71, 23)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Tag = "clear"
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(82, 507)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 23)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Tag = "save"
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(246, 507)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(70, 23)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Tag = "delete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(6, 507)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(70, 23)
        Me.btnAddNew.TabIndex = 19
        Me.btnAddNew.Tag = "add"
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(166, 507)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(74, 23)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Tag = "update"
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(571, 507)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(73, 23)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Tag = "close"
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(166, 464)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigation.TabIndex = 774
        '
        'ucrMonthlyData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrNavigation)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(lblYear)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lbl12)
        Me.Controls.Add(Me.lbl11)
        Me.Controls.Add(Me.lbl10)
        Me.Controls.Add(Me.lbl09)
        Me.Controls.Add(Me.lbl08)
        Me.Controls.Add(Me.lbl07)
        Me.Controls.Add(Me.lbl06)
        Me.Controls.Add(Me.lbl05)
        Me.Controls.Add(Me.lbl04)
        Me.Controls.Add(Me.lbl03)
        Me.Controls.Add(Me.lbl02)
        Me.Controls.Add(Me.lbl01)
        Me.Controls.Add(Me.lblFlag)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.UcrValueFlagPeriod2)
        Me.Controls.Add(Me.UcrValueFlagPeriod3)
        Me.Controls.Add(Me.UcrValueFlagPeriod4)
        Me.Controls.Add(Me.UcrValueFlagPeriod9)
        Me.Controls.Add(Me.UcrValueFlagPeriod8)
        Me.Controls.Add(Me.UcrValueFlagPeriod7)
        Me.Controls.Add(Me.UcrValueFlagPeriod10)
        Me.Controls.Add(Me.UcrValueFlagPeriod11)
        Me.Controls.Add(Me.UcrValueFlagPeriod12)
        Me.Controls.Add(Me.UcrValueFlagPeriod6)
        Me.Controls.Add(Me.UcrValueFlagPeriod5)
        Me.Controls.Add(Me.UcrValueFlagPeriod1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ucrMonthlyData"
        Me.Size = New System.Drawing.Size(796, 581)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UcrValueFlagPeriod1 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod5 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod6 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod12 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod11 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod10 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod7 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod8 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod9 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod4 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod3 As ucrValueFlagPeriod
    Friend WithEvents UcrValueFlagPeriod2 As ucrValueFlagPeriod
    Friend WithEvents lblFlag As Label
    Friend WithEvents lblValue As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lbl12 As Label
    Friend WithEvents lbl11 As Label
    Friend WithEvents lbl10 As Label
    Friend WithEvents lbl09 As Label
    Friend WithEvents lbl08 As Label
    Friend WithEvents lbl07 As Label
    Friend WithEvents lbl06 As Label
    Friend WithEvents lbl05 As Label
    Friend WithEvents lbl04 As Label
    Friend WithEvents lbl03 As Label
    Friend WithEvents lbl02 As Label
    Friend WithEvents lbl01 As Label
    Friend WithEvents lblPeriod As Label
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents ucrElementSelector As ucrElementSelector
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents lblElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents ucrNavigation As ucrNavigation
End Class
