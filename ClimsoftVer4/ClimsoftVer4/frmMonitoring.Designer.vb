﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonitoring
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
        Me.TabMonitoring = New System.Windows.Forms.TabControl()
        Me.TabUsrRecords = New System.Windows.Forms.TabPage()
        Me.grpUsers = New System.Windows.Forms.GroupBox()
        Me.cmdSave2 = New System.Windows.Forms.Button()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.optAll = New System.Windows.Forms.RadioButton()
        Me.optUsers = New System.Windows.Forms.RadioButton()
        Me.TabPerformance = New System.Windows.Forms.TabPage()
        Me.grpPerformance = New System.Windows.Forms.GroupBox()
        Me.cmdSave1 = New System.Windows.Forms.Button()
        Me.DataGridPerform = New System.Windows.Forms.DataGridView()
        Me.cmdRetrieve = New System.Windows.Forms.Button()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblTo1 = New System.Windows.Forms.Label()
        Me.lblFrom1 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.optRange = New System.Windows.Forms.RadioButton()
        Me.OptMonthly = New System.Windows.Forms.RadioButton()
        Me.TabEntryVerify = New System.Windows.Forms.TabPage()
        Me.grpVerify = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.optNotEntered = New System.Windows.Forms.RadioButton()
        Me.optNotVerified = New System.Windows.Forms.RadioButton()
        Me.optVerified = New System.Windows.Forms.RadioButton()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdExtarct = New System.Windows.Forms.Button()
        Me.txtYear2 = New System.Windows.Forms.TextBox()
        Me.txtYear1 = New System.Windows.Forms.TextBox()
        Me.txtMonth2 = New System.Windows.Forms.TextBox()
        Me.txtMonth1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.optKeyEntryForm = New System.Windows.Forms.RadioButton()
        Me.optAllForms = New System.Windows.Forms.RadioButton()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.cboForms = New System.Windows.Forms.ComboBox()
        Me.TabSettings = New System.Windows.Forms.TabPage()
        Me.grpSettings = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.optUsersStatus = New System.Windows.Forms.RadioButton()
        Me.lblDoubleEntryMode = New System.Windows.Forms.Label()
        Me.lblSingleEntryMode = New System.Windows.Forms.Label()
        Me.optEntryMode = New System.Windows.Forms.RadioButton()
        Me.optTargets = New System.Windows.Forms.RadioButton()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdretrieve1 = New System.Windows.Forms.Button()
        Me.dataGridSettings = New System.Windows.Forms.DataGridView()
        Me.listViewRecs = New System.Windows.Forms.ListView()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.lblTrecs = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.TabMonitoring.SuspendLayout()
        Me.TabUsrRecords.SuspendLayout()
        Me.grpUsers.SuspendLayout()
        Me.TabPerformance.SuspendLayout()
        Me.grpPerformance.SuspendLayout()
        CType(Me.DataGridPerform, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabEntryVerify.SuspendLayout()
        Me.grpVerify.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabSettings.SuspendLayout()
        Me.grpSettings.SuspendLayout()
        CType(Me.dataGridSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMonitoring
        '
        Me.TabMonitoring.Controls.Add(Me.TabUsrRecords)
        Me.TabMonitoring.Controls.Add(Me.TabPerformance)
        Me.TabMonitoring.Controls.Add(Me.TabEntryVerify)
        Me.TabMonitoring.Controls.Add(Me.TabSettings)
        Me.TabMonitoring.Location = New System.Drawing.Point(9, 12)
        Me.TabMonitoring.Name = "TabMonitoring"
        Me.TabMonitoring.SelectedIndex = 0
        Me.TabMonitoring.Size = New System.Drawing.Size(673, 255)
        Me.TabMonitoring.TabIndex = 0
        '
        'TabUsrRecords
        '
        Me.TabUsrRecords.Controls.Add(Me.grpUsers)
        Me.TabUsrRecords.Location = New System.Drawing.Point(4, 22)
        Me.TabUsrRecords.Name = "TabUsrRecords"
        Me.TabUsrRecords.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUsrRecords.Size = New System.Drawing.Size(665, 229)
        Me.TabUsrRecords.TabIndex = 0
        Me.TabUsrRecords.Text = "Users Records"
        Me.TabUsrRecords.UseVisualStyleBackColor = True
        '
        'grpUsers
        '
        Me.grpUsers.Controls.Add(Me.cmdSave2)
        Me.grpUsers.Controls.Add(Me.cmdView)
        Me.grpUsers.Controls.Add(Me.lblEndDate)
        Me.grpUsers.Controls.Add(Me.lblStartDate)
        Me.grpUsers.Controls.Add(Me.dtpEndDate)
        Me.grpUsers.Controls.Add(Me.dtpStartDate)
        Me.grpUsers.Controls.Add(Me.cboUser)
        Me.grpUsers.Controls.Add(Me.optAll)
        Me.grpUsers.Controls.Add(Me.optUsers)
        Me.grpUsers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpUsers.Location = New System.Drawing.Point(13, 18)
        Me.grpUsers.Name = "grpUsers"
        Me.grpUsers.Size = New System.Drawing.Size(631, 142)
        Me.grpUsers.TabIndex = 0
        Me.grpUsers.TabStop = False
        Me.grpUsers.Text = "Users Records"
        '
        'cmdSave2
        '
        Me.cmdSave2.Enabled = False
        Me.cmdSave2.Location = New System.Drawing.Point(354, 108)
        Me.cmdSave2.Name = "cmdSave2"
        Me.cmdSave2.Size = New System.Drawing.Size(136, 28)
        Me.cmdSave2.TabIndex = 21
        Me.cmdSave2.Text = "Save Output"
        Me.cmdSave2.UseVisualStyleBackColor = True
        '
        'cmdView
        '
        Me.cmdView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdView.ForeColor = System.Drawing.Color.Black
        Me.cmdView.Location = New System.Drawing.Point(102, 108)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(189, 28)
        Me.cmdView.TabIndex = 10
        Me.cmdView.Text = "View Records"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(354, 68)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(58, 15)
        Me.lblEndDate.TabIndex = 7
        Me.lblEndDate.Text = "End Date"
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(351, 29)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(61, 15)
        Me.lblStartDate.TabIndex = 6
        Me.lblStartDate.Text = "Start Date"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(434, 65)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(155, 21)
        Me.dtpEndDate.TabIndex = 5
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(434, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(155, 21)
        Me.dtpStartDate.TabIndex = 4
        '
        'cboUser
        '
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(120, 27)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.Size = New System.Drawing.Size(149, 23)
        Me.cboUser.TabIndex = 3
        '
        'optAll
        '
        Me.optAll.AutoSize = True
        Me.optAll.Location = New System.Drawing.Point(30, 68)
        Me.optAll.Name = "optAll"
        Me.optAll.Size = New System.Drawing.Size(73, 19)
        Me.optAll.TabIndex = 2
        Me.optAll.Text = "All Users"
        Me.optAll.UseVisualStyleBackColor = True
        '
        'optUsers
        '
        Me.optUsers.AutoSize = True
        Me.optUsers.Checked = True
        Me.optUsers.Location = New System.Drawing.Point(30, 27)
        Me.optUsers.Name = "optUsers"
        Me.optUsers.Size = New System.Drawing.Size(51, 19)
        Me.optUsers.TabIndex = 1
        Me.optUsers.TabStop = True
        Me.optUsers.Text = "User"
        Me.optUsers.UseVisualStyleBackColor = True
        '
        'TabPerformance
        '
        Me.TabPerformance.Controls.Add(Me.grpPerformance)
        Me.TabPerformance.Location = New System.Drawing.Point(4, 22)
        Me.TabPerformance.Name = "TabPerformance"
        Me.TabPerformance.Size = New System.Drawing.Size(665, 229)
        Me.TabPerformance.TabIndex = 2
        Me.TabPerformance.Text = "Performance Monitoring"
        Me.TabPerformance.UseVisualStyleBackColor = True
        '
        'grpPerformance
        '
        Me.grpPerformance.Controls.Add(Me.cmdSave1)
        Me.grpPerformance.Controls.Add(Me.DataGridPerform)
        Me.grpPerformance.Controls.Add(Me.cmdRetrieve)
        Me.grpPerformance.Controls.Add(Me.lblYear)
        Me.grpPerformance.Controls.Add(Me.txtYear)
        Me.grpPerformance.Controls.Add(Me.lblMonth)
        Me.grpPerformance.Controls.Add(Me.lblTo1)
        Me.grpPerformance.Controls.Add(Me.lblFrom1)
        Me.grpPerformance.Controls.Add(Me.dtpTo)
        Me.grpPerformance.Controls.Add(Me.dtpFrom)
        Me.grpPerformance.Controls.Add(Me.cboMonth)
        Me.grpPerformance.Controls.Add(Me.optRange)
        Me.grpPerformance.Controls.Add(Me.OptMonthly)
        Me.grpPerformance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPerformance.Location = New System.Drawing.Point(11, 13)
        Me.grpPerformance.Name = "grpPerformance"
        Me.grpPerformance.Size = New System.Drawing.Size(651, 158)
        Me.grpPerformance.TabIndex = 2
        Me.grpPerformance.TabStop = False
        Me.grpPerformance.Text = "Users Performance Monitoring"
        '
        'cmdSave1
        '
        Me.cmdSave1.Location = New System.Drawing.Point(332, 120)
        Me.cmdSave1.Name = "cmdSave1"
        Me.cmdSave1.Size = New System.Drawing.Size(127, 32)
        Me.cmdSave1.TabIndex = 20
        Me.cmdSave1.Text = "Save Output"
        Me.cmdSave1.UseVisualStyleBackColor = True
        '
        'DataGridPerform
        '
        Me.DataGridPerform.AllowUserToOrderColumns = True
        Me.DataGridPerform.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridPerform.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridPerform.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridPerform.Location = New System.Drawing.Point(635, 11)
        Me.DataGridPerform.Name = "DataGridPerform"
        Me.DataGridPerform.Size = New System.Drawing.Size(10, 141)
        Me.DataGridPerform.TabIndex = 19
        Me.DataGridPerform.Visible = False
        '
        'cmdRetrieve
        '
        Me.cmdRetrieve.Location = New System.Drawing.Point(124, 120)
        Me.cmdRetrieve.Name = "cmdRetrieve"
        Me.cmdRetrieve.Size = New System.Drawing.Size(172, 32)
        Me.cmdRetrieve.TabIndex = 18
        Me.cmdRetrieve.Text = "Compute Performance"
        Me.cmdRetrieve.UseVisualStyleBackColor = True
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(353, 36)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 15)
        Me.lblYear.TabIndex = 17
        Me.lblYear.Text = "Year"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(413, 34)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(58, 21)
        Me.txtYear.TabIndex = 16
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(135, 34)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(42, 15)
        Me.lblMonth.TabIndex = 15
        Me.lblMonth.Text = "Month"
        '
        'lblTo1
        '
        Me.lblTo1.AutoSize = True
        Me.lblTo1.Location = New System.Drawing.Point(353, 82)
        Me.lblTo1.Name = "lblTo1"
        Me.lblTo1.Size = New System.Drawing.Size(21, 15)
        Me.lblTo1.TabIndex = 14
        Me.lblTo1.Text = "To"
        '
        'lblFrom1
        '
        Me.lblFrom1.AutoSize = True
        Me.lblFrom1.Location = New System.Drawing.Point(135, 77)
        Me.lblFrom1.Name = "lblFrom1"
        Me.lblFrom1.Size = New System.Drawing.Size(36, 15)
        Me.lblFrom1.TabIndex = 13
        Me.lblFrom1.Text = "From"
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(413, 82)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(158, 21)
        Me.dtpTo.TabIndex = 12
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(177, 75)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(158, 21)
        Me.dtpFrom.TabIndex = 11
        Me.dtpFrom.Value = New Date(2018, 6, 21, 16, 47, 50, 0)
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(177, 31)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(51, 23)
        Me.cboMonth.TabIndex = 10
        '
        'optRange
        '
        Me.optRange.AutoSize = True
        Me.optRange.Location = New System.Drawing.Point(40, 77)
        Me.optRange.Name = "optRange"
        Me.optRange.Size = New System.Drawing.Size(62, 19)
        Me.optRange.TabIndex = 9
        Me.optRange.Text = "Range"
        Me.optRange.UseVisualStyleBackColor = True
        '
        'OptMonthly
        '
        Me.OptMonthly.AutoSize = True
        Me.OptMonthly.Checked = True
        Me.OptMonthly.Location = New System.Drawing.Point(40, 32)
        Me.OptMonthly.Name = "OptMonthly"
        Me.OptMonthly.Size = New System.Drawing.Size(68, 19)
        Me.OptMonthly.TabIndex = 8
        Me.OptMonthly.TabStop = True
        Me.OptMonthly.Text = "Monthly"
        Me.OptMonthly.UseVisualStyleBackColor = True
        '
        'TabEntryVerify
        '
        Me.TabEntryVerify.Controls.Add(Me.grpVerify)
        Me.TabEntryVerify.Location = New System.Drawing.Point(4, 22)
        Me.TabEntryVerify.Name = "TabEntryVerify"
        Me.TabEntryVerify.Padding = New System.Windows.Forms.Padding(3)
        Me.TabEntryVerify.Size = New System.Drawing.Size(665, 229)
        Me.TabEntryVerify.TabIndex = 1
        Me.TabEntryVerify.Text = "Key Entry Monitoring"
        Me.TabEntryVerify.UseVisualStyleBackColor = True
        '
        'grpVerify
        '
        Me.grpVerify.Controls.Add(Me.GroupBox2)
        Me.grpVerify.Controls.Add(Me.cmdSave)
        Me.grpVerify.Controls.Add(Me.cmdExtarct)
        Me.grpVerify.Controls.Add(Me.txtYear2)
        Me.grpVerify.Controls.Add(Me.txtYear1)
        Me.grpVerify.Controls.Add(Me.txtMonth2)
        Me.grpVerify.Controls.Add(Me.txtMonth1)
        Me.grpVerify.Controls.Add(Me.Label2)
        Me.grpVerify.Controls.Add(Me.Label1)
        Me.grpVerify.Controls.Add(Me.optKeyEntryForm)
        Me.grpVerify.Controls.Add(Me.optAllForms)
        Me.grpVerify.Controls.Add(Me.lblTo)
        Me.grpVerify.Controls.Add(Me.lblFrom)
        Me.grpVerify.Controls.Add(Me.cboForms)
        Me.grpVerify.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpVerify.Location = New System.Drawing.Point(9, 20)
        Me.grpVerify.Name = "grpVerify"
        Me.grpVerify.Size = New System.Drawing.Size(641, 163)
        Me.grpVerify.TabIndex = 1
        Me.grpVerify.TabStop = False
        Me.grpVerify.Text = "Monitoring Options"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optNotEntered)
        Me.GroupBox2.Controls.Add(Me.optNotVerified)
        Me.GroupBox2.Controls.Add(Me.optVerified)
        Me.GroupBox2.Location = New System.Drawing.Point(428, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 94)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Records Status"
        '
        'optNotEntered
        '
        Me.optNotEntered.AutoSize = True
        Me.optNotEntered.Location = New System.Drawing.Point(10, 69)
        Me.optNotEntered.Name = "optNotEntered"
        Me.optNotEntered.Size = New System.Drawing.Size(144, 20)
        Me.optNotEntered.TabIndex = 2
        Me.optNotEntered.Text = "Records NOT Entered"
        Me.optNotEntered.UseCompatibleTextRendering = True
        Me.optNotEntered.UseVisualStyleBackColor = True
        '
        'optNotVerified
        '
        Me.optNotVerified.AutoSize = True
        Me.optNotVerified.Checked = True
        Me.optNotVerified.Location = New System.Drawing.Point(10, 21)
        Me.optNotVerified.Name = "optNotVerified"
        Me.optNotVerified.Size = New System.Drawing.Size(146, 19)
        Me.optNotVerified.TabIndex = 1
        Me.optNotVerified.TabStop = True
        Me.optNotVerified.Text = "Records NOT Verified "
        Me.optNotVerified.UseVisualStyleBackColor = True
        '
        'optVerified
        '
        Me.optVerified.AutoSize = True
        Me.optVerified.Location = New System.Drawing.Point(10, 45)
        Me.optVerified.Name = "optVerified"
        Me.optVerified.Size = New System.Drawing.Size(115, 19)
        Me.optVerified.TabIndex = 0
        Me.optVerified.Text = "Verified Records"
        Me.optVerified.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(531, 122)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(92, 25)
        Me.cmdSave.TabIndex = 32
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdExtarct
        '
        Me.cmdExtarct.Location = New System.Drawing.Point(428, 122)
        Me.cmdExtarct.Name = "cmdExtarct"
        Me.cmdExtarct.Size = New System.Drawing.Size(97, 25)
        Me.cmdExtarct.TabIndex = 31
        Me.cmdExtarct.Text = "Retrieve"
        Me.cmdExtarct.UseVisualStyleBackColor = True
        '
        'txtYear2
        '
        Me.txtYear2.Location = New System.Drawing.Point(187, 122)
        Me.txtYear2.Name = "txtYear2"
        Me.txtYear2.Size = New System.Drawing.Size(42, 21)
        Me.txtYear2.TabIndex = 30
        '
        'txtYear1
        '
        Me.txtYear1.Location = New System.Drawing.Point(187, 87)
        Me.txtYear1.Name = "txtYear1"
        Me.txtYear1.Size = New System.Drawing.Size(42, 21)
        Me.txtYear1.TabIndex = 29
        '
        'txtMonth2
        '
        Me.txtMonth2.Location = New System.Drawing.Point(340, 122)
        Me.txtMonth2.Name = "txtMonth2"
        Me.txtMonth2.Size = New System.Drawing.Size(28, 21)
        Me.txtMonth2.TabIndex = 28
        Me.txtMonth2.Text = "12"
        '
        'txtMonth1
        '
        Me.txtMonth1.Location = New System.Drawing.Point(340, 87)
        Me.txtMonth1.Name = "txtMonth1"
        Me.txtMonth1.Size = New System.Drawing.Size(28, 21)
        Me.txtMonth1.TabIndex = 27
        Me.txtMonth1.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "End Month"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "End Year"
        '
        'optKeyEntryForm
        '
        Me.optKeyEntryForm.AutoSize = True
        Me.optKeyEntryForm.Checked = True
        Me.optKeyEntryForm.Location = New System.Drawing.Point(29, 28)
        Me.optKeyEntryForm.Name = "optKeyEntryForm"
        Me.optKeyEntryForm.Size = New System.Drawing.Size(107, 19)
        Me.optKeyEntryForm.TabIndex = 24
        Me.optKeyEntryForm.TabStop = True
        Me.optKeyEntryForm.Text = "Key Entry Form"
        Me.optKeyEntryForm.UseVisualStyleBackColor = True
        '
        'optAllForms
        '
        Me.optAllForms.AutoSize = True
        Me.optAllForms.Location = New System.Drawing.Point(29, 56)
        Me.optAllForms.Name = "optAllForms"
        Me.optAllForms.Size = New System.Drawing.Size(76, 19)
        Me.optAllForms.TabIndex = 23
        Me.optAllForms.Text = "All Forms"
        Me.optAllForms.UseVisualStyleBackColor = True
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(261, 90)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(77, 15)
        Me.lblTo.TabIndex = 21
        Me.lblTo.Text = "Begin Month"
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(104, 90)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(67, 15)
        Me.lblFrom.TabIndex = 20
        Me.lblFrom.Text = "Begin Year"
        '
        'cboForms
        '
        Me.cboForms.FormattingEnabled = True
        Me.cboForms.Location = New System.Drawing.Point(137, 26)
        Me.cboForms.Name = "cboForms"
        Me.cboForms.Size = New System.Drawing.Size(230, 23)
        Me.cboForms.TabIndex = 16
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.grpSettings)
        Me.TabSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.Size = New System.Drawing.Size(665, 229)
        Me.TabSettings.TabIndex = 3
        Me.TabSettings.Text = "Settings"
        Me.TabSettings.UseVisualStyleBackColor = True
        '
        'grpSettings
        '
        Me.grpSettings.Controls.Add(Me.Label3)
        Me.grpSettings.Controls.Add(Me.Label4)
        Me.grpSettings.Controls.Add(Me.optUsersStatus)
        Me.grpSettings.Controls.Add(Me.lblDoubleEntryMode)
        Me.grpSettings.Controls.Add(Me.lblSingleEntryMode)
        Me.grpSettings.Controls.Add(Me.optEntryMode)
        Me.grpSettings.Controls.Add(Me.optTargets)
        Me.grpSettings.Controls.Add(Me.cmdUpdate)
        Me.grpSettings.Controls.Add(Me.cmdretrieve1)
        Me.grpSettings.Controls.Add(Me.dataGridSettings)
        Me.grpSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSettings.Location = New System.Drawing.Point(8, 3)
        Me.grpSettings.Name = "grpSettings"
        Me.grpSettings.Size = New System.Drawing.Size(654, 219)
        Me.grpSettings.TabIndex = 2
        Me.grpSettings.TabStop = False
        Me.grpSettings.Text = "Settings"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "1 for Double Key Entry "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "0 for Single Data Entry "
        '
        'optUsersStatus
        '
        Me.optUsersStatus.AutoSize = True
        Me.optUsersStatus.Location = New System.Drawing.Point(6, 115)
        Me.optUsersStatus.Name = "optUsersStatus"
        Me.optUsersStatus.Size = New System.Drawing.Size(124, 19)
        Me.optUsersStatus.TabIndex = 16
        Me.optUsersStatus.Text = "Users Entry Status"
        Me.optUsersStatus.UseVisualStyleBackColor = True
        '
        'lblDoubleEntryMode
        '
        Me.lblDoubleEntryMode.AutoSize = True
        Me.lblDoubleEntryMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoubleEntryMode.Location = New System.Drawing.Point(29, 93)
        Me.lblDoubleEntryMode.Name = "lblDoubleEntryMode"
        Me.lblDoubleEntryMode.Size = New System.Drawing.Size(116, 13)
        Me.lblDoubleEntryMode.TabIndex = 15
        Me.lblDoubleEntryMode.Text = "1 for Double Key Entry "
        '
        'lblSingleEntryMode
        '
        Me.lblSingleEntryMode.AutoSize = True
        Me.lblSingleEntryMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSingleEntryMode.Location = New System.Drawing.Point(29, 76)
        Me.lblSingleEntryMode.Name = "lblSingleEntryMode"
        Me.lblSingleEntryMode.Size = New System.Drawing.Size(116, 13)
        Me.lblSingleEntryMode.TabIndex = 14
        Me.lblSingleEntryMode.Text = "0 for Single Data Entry "
        '
        'optEntryMode
        '
        Me.optEntryMode.AutoSize = True
        Me.optEntryMode.Location = New System.Drawing.Point(7, 56)
        Me.optEntryMode.Name = "optEntryMode"
        Me.optEntryMode.Size = New System.Drawing.Size(116, 19)
        Me.optEntryMode.TabIndex = 6
        Me.optEntryMode.Text = "Data Entry Mode"
        Me.optEntryMode.UseVisualStyleBackColor = True
        '
        'optTargets
        '
        Me.optTargets.AutoSize = True
        Me.optTargets.Checked = True
        Me.optTargets.Location = New System.Drawing.Point(6, 30)
        Me.optTargets.Name = "optTargets"
        Me.optTargets.Size = New System.Drawing.Size(115, 19)
        Me.optTargets.TabIndex = 5
        Me.optTargets.TabStop = True
        Me.optTargets.Text = "Targets Records"
        Me.optTargets.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(98, 187)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(96, 24)
        Me.cmdUpdate.TabIndex = 2
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdretrieve1
        '
        Me.cmdretrieve1.Location = New System.Drawing.Point(7, 187)
        Me.cmdretrieve1.Name = "cmdretrieve1"
        Me.cmdretrieve1.Size = New System.Drawing.Size(85, 25)
        Me.cmdretrieve1.TabIndex = 1
        Me.cmdretrieve1.Text = "View"
        Me.cmdretrieve1.UseVisualStyleBackColor = True
        '
        'dataGridSettings
        '
        Me.dataGridSettings.AllowUserToOrderColumns = True
        Me.dataGridSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridSettings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dataGridSettings.Location = New System.Drawing.Point(200, 11)
        Me.dataGridSettings.Name = "dataGridSettings"
        Me.dataGridSettings.Size = New System.Drawing.Size(448, 200)
        Me.dataGridSettings.TabIndex = 0
        '
        'listViewRecs
        '
        Me.listViewRecs.GridLines = True
        Me.listViewRecs.HideSelection = False
        Me.listViewRecs.Location = New System.Drawing.Point(9, 286)
        Me.listViewRecs.Name = "listViewRecs"
        Me.listViewRecs.Size = New System.Drawing.Size(670, 282)
        Me.listViewRecs.TabIndex = 10
        Me.listViewRecs.UseCompatibleStateImageBehavior = False
        Me.listViewRecs.View = System.Windows.Forms.View.Details
        '
        'lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Location = New System.Drawing.Point(270, 270)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(89, 13)
        Me.lblRecords.TabIndex = 11
        Me.lblRecords.Text = "Total Records  = "
        '
        'lblTrecs
        '
        Me.lblTrecs.AutoSize = True
        Me.lblTrecs.Location = New System.Drawing.Point(377, 270)
        Me.lblTrecs.Name = "lblTrecs"
        Me.lblTrecs.Size = New System.Drawing.Size(13, 13)
        Me.lblTrecs.TabIndex = 12
        Me.lblTrecs.Text = "0"
        Me.lblTrecs.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(13, 265)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(86, 20)
        Me.cmdClose.TabIndex = 13
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(597, 265)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(78, 20)
        Me.cmdHelp.TabIndex = 14
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'frmMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 583)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.lblTrecs)
        Me.Controls.Add(Me.lblRecords)
        Me.Controls.Add(Me.listViewRecs)
        Me.Controls.Add(Me.TabMonitoring)
        Me.Name = "frmMonitoring"
        Me.Text = "Operations Monitoring"
        Me.TabMonitoring.ResumeLayout(False)
        Me.TabUsrRecords.ResumeLayout(False)
        Me.grpUsers.ResumeLayout(False)
        Me.grpUsers.PerformLayout()
        Me.TabPerformance.ResumeLayout(False)
        Me.grpPerformance.ResumeLayout(False)
        Me.grpPerformance.PerformLayout()
        CType(Me.DataGridPerform, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabEntryVerify.ResumeLayout(False)
        Me.grpVerify.ResumeLayout(False)
        Me.grpVerify.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabSettings.ResumeLayout(False)
        Me.grpSettings.ResumeLayout(False)
        Me.grpSettings.PerformLayout()
        CType(Me.dataGridSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabMonitoring As System.Windows.Forms.TabControl
    Friend WithEvents TabUsrRecords As System.Windows.Forms.TabPage
    Friend WithEvents TabEntryVerify As System.Windows.Forms.TabPage
    Friend WithEvents grpUsers As System.Windows.Forms.GroupBox
    Friend WithEvents grpVerify As System.Windows.Forms.GroupBox
    Friend WithEvents TabPerformance As System.Windows.Forms.TabPage
    Friend WithEvents grpPerformance As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboUser As System.Windows.Forms.ComboBox
    Friend WithEvents optAll As System.Windows.Forms.RadioButton
    Friend WithEvents optUsers As System.Windows.Forms.RadioButton
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblTo1 As System.Windows.Forms.Label
    Friend WithEvents lblFrom1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents optRange As System.Windows.Forms.RadioButton
    Friend WithEvents OptMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents cboForms As System.Windows.Forms.ComboBox
    Friend WithEvents TabSettings As System.Windows.Forms.TabPage
    Friend WithEvents grpSettings As System.Windows.Forms.GroupBox
    Friend WithEvents listViewRecs As System.Windows.Forms.ListView
    Friend WithEvents lblRecords As System.Windows.Forms.Label
    Friend WithEvents lblTrecs As System.Windows.Forms.Label
    Friend WithEvents cmdRetrieve As System.Windows.Forms.Button
    Friend WithEvents DataGridPerform As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSave1 As System.Windows.Forms.Button
    Friend WithEvents cmdretrieve1 As System.Windows.Forms.Button
    Friend WithEvents dataGridSettings As System.Windows.Forms.DataGridView
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExtarct As System.Windows.Forms.Button
    Friend WithEvents txtYear2 As System.Windows.Forms.TextBox
    Friend WithEvents txtYear1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optKeyEntryForm As System.Windows.Forms.RadioButton
    Friend WithEvents optAllForms As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optNotVerified As System.Windows.Forms.RadioButton
    Friend WithEvents optVerified As System.Windows.Forms.RadioButton
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents optEntryMode As System.Windows.Forms.RadioButton
    Friend WithEvents optTargets As System.Windows.Forms.RadioButton
    Friend WithEvents lblDoubleEntryMode As System.Windows.Forms.Label
    Friend WithEvents lblSingleEntryMode As System.Windows.Forms.Label
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents optUsersStatus As RadioButton
    Friend WithEvents cmdSave2 As Button
    Friend WithEvents optNotEntered As RadioButton
End Class
