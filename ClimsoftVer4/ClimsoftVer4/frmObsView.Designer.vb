<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmObsView
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
        Me.TabObservations = New System.Windows.Forms.TabControl()
        Me.TabSelect = New System.Windows.Forms.TabPage()
        Me.pnlStationsElements = New System.Windows.Forms.Panel()
        Me.cmdSelectAllElements = New System.Windows.Forms.Button()
        Me.cmdSelectAllStations = New System.Windows.Forms.Button()
        Me.cmdClearStations = New System.Windows.Forms.Button()
        Me.cmdClearElements = New System.Windows.Forms.Button()
        Me.pnlSummary = New System.Windows.Forms.Panel()
        Me.optFinal = New System.Windows.Forms.RadioButton()
        Me.optInitial = New System.Windows.Forms.RadioButton()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.cmdDelStation = New System.Windows.Forms.Button()
        Me.cmdDelElement = New System.Windows.Forms.Button()
        Me.chkAdvancedSelection = New System.Windows.Forms.CheckBox()
        Me.lstvElements = New System.Windows.Forms.ListView()
        Me.lstvStations = New System.Windows.Forms.ListView()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblProducts = New System.Windows.Forms.Label()
        Me.cboMinuteEnd = New System.Windows.Forms.ComboBox()
        Me.cboMinuteStart = New System.Windows.Forms.ComboBox()
        Me.cboHourEnd = New System.Windows.Forms.ComboBox()
        Me.cboHourStart = New System.Windows.Forms.ComboBox()
        Me.txtSminute = New System.Windows.Forms.Label()
        Me.lblHourEnd = New System.Windows.Forms.Label()
        Me.lblHourBegin = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.txtQualifier = New System.Windows.Forms.Panel()
        Me.lstAdmin4 = New System.Windows.Forms.ListBox()
        Me.lstAdmin3 = New System.Windows.Forms.ListBox()
        Me.lstAdmin2 = New System.Windows.Forms.ListBox()
        Me.lstAdmin1 = New System.Windows.Forms.ListBox()
        Me.lstAuthority = New System.Windows.Forms.ListBox()
        Me.lstCountry = New System.Windows.Forms.ListBox()
        Me.lstDBasin = New System.Windows.Forms.ListBox()
        Me.lstQualifier = New System.Windows.Forms.ListBox()
        Me.lblDataGroups = New System.Windows.Forms.Label()
        Me.chkAdmin4 = New System.Windows.Forms.CheckBox()
        Me.chkAuthority = New System.Windows.Forms.CheckBox()
        Me.chkAdmin3 = New System.Windows.Forms.CheckBox()
        Me.chkAdmin2 = New System.Windows.Forms.CheckBox()
        Me.chkAdmin1 = New System.Windows.Forms.CheckBox()
        Me.chkCountry = New System.Windows.Forms.CheckBox()
        Me.chkDbasin = New System.Windows.Forms.CheckBox()
        Me.lblStnGroups = New System.Windows.Forms.Label()
        Me.chkQaulifier = New System.Windows.Forms.CheckBox()
        Me.txtOtherflag = New System.Windows.Forms.TextBox()
        Me.lblOtherFlags = New System.Windows.Forms.Label()
        Me.chkForms = New System.Windows.Forms.CheckBox()
        Me.lstBoxForms = New System.Windows.Forms.ListBox()
        Me.chkAcquisitionType = New System.Windows.Forms.CheckBox()
        Me.chkFlags = New System.Windows.Forms.CheckBox()
        Me.chkQCStatus = New System.Windows.Forms.CheckBox()
        Me.lstBoxQC = New System.Windows.Forms.ListBox()
        Me.lstBoxAcquition = New System.Windows.Forms.ListBox()
        Me.lstBoxFlags = New System.Windows.Forms.ListBox()
        Me.lblStations = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.dataGridViewRecord = New System.Windows.Forms.DataGridView()
        Me.grpButtons = New System.Windows.Forms.GroupBox()
        Me.btnExpot = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.TabObservations.SuspendLayout()
        Me.TabSelect.SuspendLayout()
        Me.pnlStationsElements.SuspendLayout()
        Me.pnlSummary.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.txtQualifier.SuspendLayout()
        Me.tabView.SuspendLayout()
        CType(Me.dataGridViewRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabObservations
        '
        Me.TabObservations.Controls.Add(Me.TabSelect)
        Me.TabObservations.Controls.Add(Me.tabView)
        Me.TabObservations.Location = New System.Drawing.Point(-1, -3)
        Me.TabObservations.Name = "TabObservations"
        Me.TabObservations.SelectedIndex = 0
        Me.TabObservations.Size = New System.Drawing.Size(1215, 571)
        Me.TabObservations.TabIndex = 0
        '
        'TabSelect
        '
        Me.TabSelect.Controls.Add(Me.pnlStationsElements)
        Me.TabSelect.Location = New System.Drawing.Point(4, 22)
        Me.TabSelect.Name = "TabSelect"
        Me.TabSelect.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSelect.Size = New System.Drawing.Size(1207, 545)
        Me.TabSelect.TabIndex = 0
        Me.TabSelect.Text = "Selection Details"
        Me.TabSelect.UseVisualStyleBackColor = True
        '
        'pnlStationsElements
        '
        Me.pnlStationsElements.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlStationsElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStationsElements.Controls.Add(Me.cmdSelectAllElements)
        Me.pnlStationsElements.Controls.Add(Me.cmdSelectAllStations)
        Me.pnlStationsElements.Controls.Add(Me.cmdClearStations)
        Me.pnlStationsElements.Controls.Add(Me.cmdClearElements)
        Me.pnlStationsElements.Controls.Add(Me.pnlSummary)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelStation)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelElement)
        Me.pnlStationsElements.Controls.Add(Me.chkAdvancedSelection)
        Me.pnlStationsElements.Controls.Add(Me.lstvElements)
        Me.pnlStationsElements.Controls.Add(Me.lstvStations)
        Me.pnlStationsElements.Controls.Add(Me.lblElement)
        Me.pnlStationsElements.Controls.Add(Me.lblStation)
        Me.pnlStationsElements.Controls.Add(Me.pnlPeriod)
        Me.pnlStationsElements.Controls.Add(Me.txtQualifier)
        Me.pnlStationsElements.Controls.Add(Me.cmbElement)
        Me.pnlStationsElements.Controls.Add(Me.cmbstation)
        Me.pnlStationsElements.Location = New System.Drawing.Point(5, 31)
        Me.pnlStationsElements.Name = "pnlStationsElements"
        Me.pnlStationsElements.Size = New System.Drawing.Size(1195, 511)
        Me.pnlStationsElements.TabIndex = 5
        '
        'cmdSelectAllElements
        '
        Me.cmdSelectAllElements.Location = New System.Drawing.Point(509, 481)
        Me.cmdSelectAllElements.Name = "cmdSelectAllElements"
        Me.cmdSelectAllElements.Size = New System.Drawing.Size(113, 23)
        Me.cmdSelectAllElements.TabIndex = 29
        Me.cmdSelectAllElements.Text = "Select All"
        Me.cmdSelectAllElements.UseVisualStyleBackColor = True
        '
        'cmdSelectAllStations
        '
        Me.cmdSelectAllStations.Location = New System.Drawing.Point(147, 481)
        Me.cmdSelectAllStations.Name = "cmdSelectAllStations"
        Me.cmdSelectAllStations.Size = New System.Drawing.Size(107, 23)
        Me.cmdSelectAllStations.TabIndex = 28
        Me.cmdSelectAllStations.Text = "Select All"
        Me.cmdSelectAllStations.UseVisualStyleBackColor = True
        '
        'cmdClearStations
        '
        Me.cmdClearStations.Location = New System.Drawing.Point(260, 481)
        Me.cmdClearStations.Name = "cmdClearStations"
        Me.cmdClearStations.Size = New System.Drawing.Size(94, 23)
        Me.cmdClearStations.TabIndex = 27
        Me.cmdClearStations.Text = "Clear List"
        Me.cmdClearStations.UseVisualStyleBackColor = True
        '
        'cmdClearElements
        '
        Me.cmdClearElements.Location = New System.Drawing.Point(631, 481)
        Me.cmdClearElements.Name = "cmdClearElements"
        Me.cmdClearElements.Size = New System.Drawing.Size(96, 23)
        Me.cmdClearElements.TabIndex = 26
        Me.cmdClearElements.Text = "Clear List"
        Me.cmdClearElements.UseVisualStyleBackColor = True
        '
        'pnlSummary
        '
        Me.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSummary.Controls.Add(Me.optFinal)
        Me.pnlSummary.Controls.Add(Me.optInitial)
        Me.pnlSummary.Controls.Add(Me.lblSummary)
        Me.pnlSummary.Location = New System.Drawing.Point(743, 13)
        Me.pnlSummary.Name = "pnlSummary"
        Me.pnlSummary.Size = New System.Drawing.Size(440, 48)
        Me.pnlSummary.TabIndex = 23
        '
        'optFinal
        '
        Me.optFinal.AutoSize = True
        Me.optFinal.Location = New System.Drawing.Point(269, 20)
        Me.optFinal.Name = "optFinal"
        Me.optFinal.Size = New System.Drawing.Size(107, 17)
        Me.optFinal.TabIndex = 2
        Me.optFinal.Text = "Observation Final"
        Me.optFinal.UseVisualStyleBackColor = True
        '
        'optInitial
        '
        Me.optInitial.AutoSize = True
        Me.optInitial.Checked = True
        Me.optInitial.Location = New System.Drawing.Point(46, 19)
        Me.optInitial.Name = "optInitial"
        Me.optInitial.Size = New System.Drawing.Size(108, 17)
        Me.optInitial.TabIndex = 1
        Me.optInitial.TabStop = True
        Me.optInitial.Text = "Observation initial"
        Me.optInitial.UseVisualStyleBackColor = True
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(0, 0)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(45, 13)
        Me.lblSummary.TabIndex = 0
        Me.lblSummary.Text = "Tables"
        '
        'cmdDelStation
        '
        Me.cmdDelStation.Location = New System.Drawing.Point(14, 481)
        Me.cmdDelStation.Name = "cmdDelStation"
        Me.cmdDelStation.Size = New System.Drawing.Size(127, 23)
        Me.cmdDelStation.TabIndex = 22
        Me.cmdDelStation.Text = "Clear Selected Station"
        Me.cmdDelStation.UseVisualStyleBackColor = True
        '
        'cmdDelElement
        '
        Me.cmdDelElement.Location = New System.Drawing.Point(364, 481)
        Me.cmdDelElement.Name = "cmdDelElement"
        Me.cmdDelElement.Size = New System.Drawing.Size(139, 23)
        Me.cmdDelElement.TabIndex = 21
        Me.cmdDelElement.Text = "Clear Selected Elements"
        Me.cmdDelElement.UseVisualStyleBackColor = True
        '
        'chkAdvancedSelection
        '
        Me.chkAdvancedSelection.AutoSize = True
        Me.chkAdvancedSelection.Location = New System.Drawing.Point(747, 177)
        Me.chkAdvancedSelection.Name = "chkAdvancedSelection"
        Me.chkAdvancedSelection.Size = New System.Drawing.Size(122, 17)
        Me.chkAdvancedSelection.TabIndex = 19
        Me.chkAdvancedSelection.Text = "Advanced Selection"
        Me.chkAdvancedSelection.UseVisualStyleBackColor = True
        '
        'lstvElements
        '
        Me.lstvElements.AllowColumnReorder = True
        Me.lstvElements.AllowDrop = True
        Me.lstvElements.FullRowSelect = True
        Me.lstvElements.GridLines = True
        Me.lstvElements.HideSelection = False
        Me.lstvElements.HoverSelection = True
        Me.lstvElements.LabelEdit = True
        Me.lstvElements.Location = New System.Drawing.Point(364, 34)
        Me.lstvElements.Name = "lstvElements"
        Me.lstvElements.RightToLeftLayout = True
        Me.lstvElements.Size = New System.Drawing.Size(363, 441)
        Me.lstvElements.TabIndex = 18
        Me.lstvElements.UseCompatibleStateImageBehavior = False
        Me.lstvElements.View = System.Windows.Forms.View.Details
        '
        'lstvStations
        '
        Me.lstvStations.AllowColumnReorder = True
        Me.lstvStations.AllowDrop = True
        Me.lstvStations.FullRowSelect = True
        Me.lstvStations.GridLines = True
        Me.lstvStations.HideSelection = False
        Me.lstvStations.HoverSelection = True
        Me.lstvStations.LabelEdit = True
        Me.lstvStations.Location = New System.Drawing.Point(14, 33)
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.RightToLeftLayout = True
        Me.lstvStations.Size = New System.Drawing.Size(340, 442)
        Me.lstvStations.TabIndex = 17
        Me.lstvStations.UseCompatibleStateImageBehavior = False
        Me.lstvStations.View = System.Windows.Forms.View.Details
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(361, 17)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 9
        Me.lblElement.Text = "Select Element"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(18, 17)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 8
        Me.lblStation.Text = "Select Station"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPeriod.Controls.Add(Me.lblProducts)
        Me.pnlPeriod.Controls.Add(Me.cboMinuteEnd)
        Me.pnlPeriod.Controls.Add(Me.cboMinuteStart)
        Me.pnlPeriod.Controls.Add(Me.cboHourEnd)
        Me.pnlPeriod.Controls.Add(Me.cboHourStart)
        Me.pnlPeriod.Controls.Add(Me.txtSminute)
        Me.pnlPeriod.Controls.Add(Me.lblHourEnd)
        Me.pnlPeriod.Controls.Add(Me.lblHourBegin)
        Me.pnlPeriod.Controls.Add(Me.dtpDateTo)
        Me.pnlPeriod.Controls.Add(Me.lblTo)
        Me.pnlPeriod.Controls.Add(Me.dtpDateFrom)
        Me.pnlPeriod.Controls.Add(Me.lblFrom)
        Me.pnlPeriod.Controls.Add(Me.lblPeriod)
        Me.pnlPeriod.Location = New System.Drawing.Point(743, 73)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(440, 97)
        Me.pnlPeriod.TabIndex = 7
        '
        'lblProducts
        '
        Me.lblProducts.AutoSize = True
        Me.lblProducts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducts.Location = New System.Drawing.Point(158, -1)
        Me.lblProducts.Name = "lblProducts"
        Me.lblProducts.Size = New System.Drawing.Size(17, 16)
        Me.lblProducts.TabIndex = 8
        Me.lblProducts.Text = "   "
        '
        'cboMinuteEnd
        '
        Me.cboMinuteEnd.FormattingEnabled = True
        Me.cboMinuteEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59"})
        Me.cboMinuteEnd.Location = New System.Drawing.Point(339, 62)
        Me.cboMinuteEnd.Name = "cboMinuteEnd"
        Me.cboMinuteEnd.Size = New System.Drawing.Size(40, 21)
        Me.cboMinuteEnd.TabIndex = 15
        Me.cboMinuteEnd.Text = "00"
        '
        'cboMinuteStart
        '
        Me.cboMinuteStart.FormattingEnabled = True
        Me.cboMinuteStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59", "60"})
        Me.cboMinuteStart.Location = New System.Drawing.Point(339, 28)
        Me.cboMinuteStart.Name = "cboMinuteStart"
        Me.cboMinuteStart.Size = New System.Drawing.Size(40, 21)
        Me.cboMinuteStart.TabIndex = 14
        Me.cboMinuteStart.Text = "00"
        '
        'cboHourEnd
        '
        Me.cboHourEnd.FormattingEnabled = True
        Me.cboHourEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboHourEnd.Location = New System.Drawing.Point(293, 63)
        Me.cboHourEnd.Name = "cboHourEnd"
        Me.cboHourEnd.Size = New System.Drawing.Size(40, 21)
        Me.cboHourEnd.TabIndex = 13
        Me.cboHourEnd.Text = "23"
        '
        'cboHourStart
        '
        Me.cboHourStart.FormattingEnabled = True
        Me.cboHourStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboHourStart.Location = New System.Drawing.Point(293, 29)
        Me.cboHourStart.Name = "cboHourStart"
        Me.cboHourStart.Size = New System.Drawing.Size(40, 21)
        Me.cboHourStart.TabIndex = 12
        Me.cboHourStart.Text = "00"
        '
        'txtSminute
        '
        Me.txtSminute.AutoSize = True
        Me.txtSminute.Location = New System.Drawing.Point(340, 13)
        Me.txtSminute.Name = "txtSminute"
        Me.txtSminute.Size = New System.Drawing.Size(39, 13)
        Me.txtSminute.TabIndex = 9
        Me.txtSminute.Text = "Minute"
        '
        'lblHourEnd
        '
        Me.lblHourEnd.AutoSize = True
        Me.lblHourEnd.Location = New System.Drawing.Point(296, 13)
        Me.lblHourEnd.Name = "lblHourEnd"
        Me.lblHourEnd.Size = New System.Drawing.Size(30, 13)
        Me.lblHourEnd.TabIndex = 7
        Me.lblHourEnd.Text = "Hour"
        '
        'lblHourBegin
        '
        Me.lblHourBegin.AutoSize = True
        Me.lblHourBegin.Location = New System.Drawing.Point(128, 10)
        Me.lblHourBegin.Name = "lblHourBegin"
        Me.lblHourBegin.Size = New System.Drawing.Size(30, 13)
        Me.lblHourBegin.TabIndex = 5
        Me.lblHourBegin.Text = "Date"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Location = New System.Drawing.Point(123, 60)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(164, 20)
        Me.dtpDateTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(46, 64)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(52, 13)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "End Date"
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Location = New System.Drawing.Point(123, 25)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(164, 20)
        Me.dtpDateFrom.TabIndex = 2
        Me.dtpDateFrom.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(46, 29)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(55, 13)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "Start Date"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriod.Location = New System.Drawing.Point(0, 0)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriod.TabIndex = 0
        Me.lblPeriod.Text = "Period"
        '
        'txtQualifier
        '
        Me.txtQualifier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQualifier.Controls.Add(Me.lstAdmin4)
        Me.txtQualifier.Controls.Add(Me.lstAdmin3)
        Me.txtQualifier.Controls.Add(Me.lstAdmin2)
        Me.txtQualifier.Controls.Add(Me.lstAdmin1)
        Me.txtQualifier.Controls.Add(Me.lstAuthority)
        Me.txtQualifier.Controls.Add(Me.lstCountry)
        Me.txtQualifier.Controls.Add(Me.lstDBasin)
        Me.txtQualifier.Controls.Add(Me.lstQualifier)
        Me.txtQualifier.Controls.Add(Me.lblDataGroups)
        Me.txtQualifier.Controls.Add(Me.chkAdmin4)
        Me.txtQualifier.Controls.Add(Me.chkAuthority)
        Me.txtQualifier.Controls.Add(Me.chkAdmin3)
        Me.txtQualifier.Controls.Add(Me.chkAdmin2)
        Me.txtQualifier.Controls.Add(Me.chkAdmin1)
        Me.txtQualifier.Controls.Add(Me.chkCountry)
        Me.txtQualifier.Controls.Add(Me.chkDbasin)
        Me.txtQualifier.Controls.Add(Me.lblStnGroups)
        Me.txtQualifier.Controls.Add(Me.chkQaulifier)
        Me.txtQualifier.Controls.Add(Me.txtOtherflag)
        Me.txtQualifier.Controls.Add(Me.lblOtherFlags)
        Me.txtQualifier.Controls.Add(Me.chkForms)
        Me.txtQualifier.Controls.Add(Me.lstBoxForms)
        Me.txtQualifier.Controls.Add(Me.chkAcquisitionType)
        Me.txtQualifier.Controls.Add(Me.chkFlags)
        Me.txtQualifier.Controls.Add(Me.chkQCStatus)
        Me.txtQualifier.Controls.Add(Me.lstBoxQC)
        Me.txtQualifier.Controls.Add(Me.lstBoxAcquition)
        Me.txtQualifier.Controls.Add(Me.lstBoxFlags)
        Me.txtQualifier.Controls.Add(Me.lblStations)
        Me.txtQualifier.Location = New System.Drawing.Point(743, 200)
        Me.txtQualifier.Name = "txtQualifier"
        Me.txtQualifier.Size = New System.Drawing.Size(440, 304)
        Me.txtQualifier.TabIndex = 6
        Me.txtQualifier.Visible = False
        '
        'lstAdmin4
        '
        Me.lstAdmin4.Enabled = False
        Me.lstAdmin4.FormattingEnabled = True
        Me.lstAdmin4.Location = New System.Drawing.Point(340, 264)
        Me.lstAdmin4.Name = "lstAdmin4"
        Me.lstAdmin4.Size = New System.Drawing.Size(95, 30)
        Me.lstAdmin4.TabIndex = 60
        '
        'lstAdmin3
        '
        Me.lstAdmin3.Enabled = False
        Me.lstAdmin3.FormattingEnabled = True
        Me.lstAdmin3.Location = New System.Drawing.Point(340, 230)
        Me.lstAdmin3.Name = "lstAdmin3"
        Me.lstAdmin3.Size = New System.Drawing.Size(95, 30)
        Me.lstAdmin3.TabIndex = 59
        '
        'lstAdmin2
        '
        Me.lstAdmin2.Enabled = False
        Me.lstAdmin2.FormattingEnabled = True
        Me.lstAdmin2.Location = New System.Drawing.Point(340, 196)
        Me.lstAdmin2.Name = "lstAdmin2"
        Me.lstAdmin2.Size = New System.Drawing.Size(95, 30)
        Me.lstAdmin2.TabIndex = 58
        '
        'lstAdmin1
        '
        Me.lstAdmin1.Enabled = False
        Me.lstAdmin1.FormattingEnabled = True
        Me.lstAdmin1.Location = New System.Drawing.Point(340, 162)
        Me.lstAdmin1.Name = "lstAdmin1"
        Me.lstAdmin1.Size = New System.Drawing.Size(95, 30)
        Me.lstAdmin1.TabIndex = 57
        '
        'lstAuthority
        '
        Me.lstAuthority.Enabled = False
        Me.lstAuthority.FormattingEnabled = True
        Me.lstAuthority.Location = New System.Drawing.Point(309, 60)
        Me.lstAuthority.Name = "lstAuthority"
        Me.lstAuthority.Size = New System.Drawing.Size(126, 30)
        Me.lstAuthority.TabIndex = 56
        '
        'lstCountry
        '
        Me.lstCountry.Enabled = False
        Me.lstCountry.FormattingEnabled = True
        Me.lstCountry.Location = New System.Drawing.Point(309, 26)
        Me.lstCountry.Name = "lstCountry"
        Me.lstCountry.Size = New System.Drawing.Size(126, 30)
        Me.lstCountry.TabIndex = 55
        '
        'lstDBasin
        '
        Me.lstDBasin.Enabled = False
        Me.lstDBasin.FormattingEnabled = True
        Me.lstDBasin.Location = New System.Drawing.Point(309, 128)
        Me.lstDBasin.Name = "lstDBasin"
        Me.lstDBasin.Size = New System.Drawing.Size(126, 30)
        Me.lstDBasin.TabIndex = 54
        '
        'lstQualifier
        '
        Me.lstQualifier.Enabled = False
        Me.lstQualifier.FormattingEnabled = True
        Me.lstQualifier.Location = New System.Drawing.Point(309, 94)
        Me.lstQualifier.Name = "lstQualifier"
        Me.lstQualifier.Size = New System.Drawing.Size(126, 30)
        Me.lstQualifier.TabIndex = 53
        '
        'lblDataGroups
        '
        Me.lblDataGroups.AutoSize = True
        Me.lblDataGroups.Location = New System.Drawing.Point(11, 3)
        Me.lblDataGroups.Name = "lblDataGroups"
        Me.lblDataGroups.Size = New System.Drawing.Size(76, 13)
        Me.lblDataGroups.TabIndex = 52
        Me.lblDataGroups.Text = "Data Grouping"
        '
        'chkAdmin4
        '
        Me.chkAdmin4.AutoSize = True
        Me.chkAdmin4.Location = New System.Drawing.Point(239, 271)
        Me.chkAdmin4.Name = "chkAdmin4"
        Me.chkAdmin4.Size = New System.Drawing.Size(98, 17)
        Me.chkAdmin4.TabIndex = 51
        Me.chkAdmin4.Text = "Admin Region4"
        Me.chkAdmin4.UseVisualStyleBackColor = True
        '
        'chkAuthority
        '
        Me.chkAuthority.AutoSize = True
        Me.chkAuthority.Location = New System.Drawing.Point(239, 67)
        Me.chkAuthority.Name = "chkAuthority"
        Me.chkAuthority.Size = New System.Drawing.Size(67, 17)
        Me.chkAuthority.TabIndex = 49
        Me.chkAuthority.Text = "Authority"
        Me.chkAuthority.UseVisualStyleBackColor = True
        '
        'chkAdmin3
        '
        Me.chkAdmin3.AutoSize = True
        Me.chkAdmin3.Location = New System.Drawing.Point(239, 237)
        Me.chkAdmin3.Name = "chkAdmin3"
        Me.chkAdmin3.Size = New System.Drawing.Size(98, 17)
        Me.chkAdmin3.TabIndex = 48
        Me.chkAdmin3.Text = "Admin Region3"
        Me.chkAdmin3.UseVisualStyleBackColor = True
        '
        'chkAdmin2
        '
        Me.chkAdmin2.AutoSize = True
        Me.chkAdmin2.Location = New System.Drawing.Point(239, 203)
        Me.chkAdmin2.Name = "chkAdmin2"
        Me.chkAdmin2.Size = New System.Drawing.Size(98, 17)
        Me.chkAdmin2.TabIndex = 47
        Me.chkAdmin2.Text = "Admin Region2"
        Me.chkAdmin2.UseVisualStyleBackColor = True
        '
        'chkAdmin1
        '
        Me.chkAdmin1.AutoSize = True
        Me.chkAdmin1.Location = New System.Drawing.Point(239, 169)
        Me.chkAdmin1.Name = "chkAdmin1"
        Me.chkAdmin1.Size = New System.Drawing.Size(98, 17)
        Me.chkAdmin1.TabIndex = 46
        Me.chkAdmin1.Text = "Admin Region1"
        Me.chkAdmin1.UseVisualStyleBackColor = True
        '
        'chkCountry
        '
        Me.chkCountry.AutoSize = True
        Me.chkCountry.Location = New System.Drawing.Point(239, 33)
        Me.chkCountry.Name = "chkCountry"
        Me.chkCountry.Size = New System.Drawing.Size(62, 17)
        Me.chkCountry.TabIndex = 44
        Me.chkCountry.Text = "Country"
        Me.chkCountry.UseVisualStyleBackColor = True
        '
        'chkDbasin
        '
        Me.chkDbasin.AutoSize = True
        Me.chkDbasin.Location = New System.Drawing.Point(239, 135)
        Me.chkDbasin.Name = "chkDbasin"
        Me.chkDbasin.Size = New System.Drawing.Size(52, 17)
        Me.chkDbasin.TabIndex = 43
        Me.chkDbasin.Text = "Basin"
        Me.chkDbasin.UseVisualStyleBackColor = True
        '
        'lblStnGroups
        '
        Me.lblStnGroups.AutoSize = True
        Me.lblStnGroups.Location = New System.Drawing.Point(241, 3)
        Me.lblStnGroups.Name = "lblStnGroups"
        Me.lblStnGroups.Size = New System.Drawing.Size(91, 13)
        Me.lblStnGroups.TabIndex = 42
        Me.lblStnGroups.Text = "Stations Grouping"
        '
        'chkQaulifier
        '
        Me.chkQaulifier.AutoSize = True
        Me.chkQaulifier.Location = New System.Drawing.Point(239, 101)
        Me.chkQaulifier.Name = "chkQaulifier"
        Me.chkQaulifier.Size = New System.Drawing.Size(64, 17)
        Me.chkQaulifier.TabIndex = 41
        Me.chkQaulifier.Text = "Qualifier"
        Me.chkQaulifier.UseVisualStyleBackColor = True
        '
        'txtOtherflag
        '
        Me.txtOtherflag.Location = New System.Drawing.Point(113, 129)
        Me.txtOtherflag.Name = "txtOtherflag"
        Me.txtOtherflag.Size = New System.Drawing.Size(58, 20)
        Me.txtOtherflag.TabIndex = 23
        '
        'lblOtherFlags
        '
        Me.lblOtherFlags.AutoSize = True
        Me.lblOtherFlags.Location = New System.Drawing.Point(103, 113)
        Me.lblOtherFlags.Name = "lblOtherFlags"
        Me.lblOtherFlags.Size = New System.Drawing.Size(126, 13)
        Me.lblOtherFlags.TabIndex = 22
        Me.lblOtherFlags.Text = "Other (Specify Character)"
        '
        'chkForms
        '
        Me.chkForms.Location = New System.Drawing.Point(8, 215)
        Me.chkForms.Name = "chkForms"
        Me.chkForms.Size = New System.Drawing.Size(104, 38)
        Me.chkForms.TabIndex = 21
        Me.chkForms.Text = "Key Entry Forms"
        Me.chkForms.UseVisualStyleBackColor = True
        '
        'lstBoxForms
        '
        Me.lstBoxForms.Enabled = False
        Me.lstBoxForms.FormattingEnabled = True
        Me.lstBoxForms.Location = New System.Drawing.Point(113, 215)
        Me.lstBoxForms.Name = "lstBoxForms"
        Me.lstBoxForms.Size = New System.Drawing.Size(112, 82)
        Me.lstBoxForms.TabIndex = 20
        '
        'chkAcquisitionType
        '
        Me.chkAcquisitionType.AutoSize = True
        Me.chkAcquisitionType.Location = New System.Drawing.Point(8, 172)
        Me.chkAcquisitionType.Name = "chkAcquisitionType"
        Me.chkAcquisitionType.Size = New System.Drawing.Size(104, 17)
        Me.chkAcquisitionType.TabIndex = 19
        Me.chkAcquisitionType.Text = "Acquisition Type"
        Me.chkAcquisitionType.UseVisualStyleBackColor = True
        '
        'chkFlags
        '
        Me.chkFlags.AutoSize = True
        Me.chkFlags.Location = New System.Drawing.Point(7, 85)
        Me.chkFlags.Name = "chkFlags"
        Me.chkFlags.Size = New System.Drawing.Size(51, 17)
        Me.chkFlags.TabIndex = 18
        Me.chkFlags.Text = "Flags"
        Me.chkFlags.UseVisualStyleBackColor = True
        '
        'chkQCStatus
        '
        Me.chkQCStatus.AutoSize = True
        Me.chkQCStatus.Location = New System.Drawing.Point(7, 43)
        Me.chkQCStatus.Name = "chkQCStatus"
        Me.chkQCStatus.Size = New System.Drawing.Size(71, 17)
        Me.chkQCStatus.TabIndex = 17
        Me.chkQCStatus.Text = "QC Satus"
        Me.chkQCStatus.UseVisualStyleBackColor = True
        '
        'lstBoxQC
        '
        Me.lstBoxQC.Enabled = False
        Me.lstBoxQC.FormattingEnabled = True
        Me.lstBoxQC.Items.AddRange(New Object() {"0", "1", "2"})
        Me.lstBoxQC.Location = New System.Drawing.Point(113, 31)
        Me.lstBoxQC.Name = "lstBoxQC"
        Me.lstBoxQC.Size = New System.Drawing.Size(41, 30)
        Me.lstBoxQC.TabIndex = 15
        '
        'lstBoxAcquition
        '
        Me.lstBoxAcquition.Enabled = False
        Me.lstBoxAcquition.FormattingEnabled = True
        Me.lstBoxAcquition.Items.AddRange(New Object() {"Unknown", "Key Entry Forms", "CLICOM", "Climsoft V3", "AWS", "GTS", "Text Files"})
        Me.lstBoxAcquition.Location = New System.Drawing.Point(113, 154)
        Me.lstBoxAcquition.Name = "lstBoxAcquition"
        Me.lstBoxAcquition.Size = New System.Drawing.Size(112, 56)
        Me.lstBoxAcquition.TabIndex = 4
        '
        'lstBoxFlags
        '
        Me.lstBoxFlags.Enabled = False
        Me.lstBoxFlags.FormattingEnabled = True
        Me.lstBoxFlags.Items.AddRange(New Object() {"M Missing Data", "T Trace Rainfall", "E Estimated Value", "D Dubious or Suspect data", "G Generated or Calculated Value", "C Cummulated Data"})
        Me.lstBoxFlags.Location = New System.Drawing.Point(113, 67)
        Me.lstBoxFlags.Name = "lstBoxFlags"
        Me.lstBoxFlags.Size = New System.Drawing.Size(112, 43)
        Me.lstBoxFlags.TabIndex = 2
        '
        'lblStations
        '
        Me.lblStations.AutoSize = True
        Me.lblStations.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStations.Location = New System.Drawing.Point(0, 0)
        Me.lblStations.Name = "lblStations"
        Me.lblStations.Size = New System.Drawing.Size(0, 13)
        Me.lblStations.TabIndex = 0
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(481, 13)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(246, 21)
        Me.cmbElement.TabIndex = 3
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(126, 13)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(228, 21)
        Me.cmbstation.TabIndex = 1
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.dataGridViewRecord)
        Me.tabView.Controls.Add(Me.grpButtons)
        Me.tabView.Location = New System.Drawing.Point(4, 22)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(1207, 545)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "View Records"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'dataGridViewRecord
        '
        Me.dataGridViewRecord.AllowDrop = True
        Me.dataGridViewRecord.AllowUserToAddRows = False
        Me.dataGridViewRecord.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dataGridViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewRecord.Location = New System.Drawing.Point(3, 3)
        Me.dataGridViewRecord.Name = "dataGridViewRecord"
        Me.dataGridViewRecord.Size = New System.Drawing.Size(1107, 451)
        Me.dataGridViewRecord.TabIndex = 1
        '
        'grpButtons
        '
        Me.grpButtons.BackColor = System.Drawing.Color.Gainsboro
        Me.grpButtons.Controls.Add(Me.btnExpot)
        Me.grpButtons.Controls.Add(Me.btnDelete)
        Me.grpButtons.Controls.Add(Me.btnUpdate)
        Me.grpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpButtons.Location = New System.Drawing.Point(3, 516)
        Me.grpButtons.Name = "grpButtons"
        Me.grpButtons.Size = New System.Drawing.Size(1201, 26)
        Me.grpButtons.TabIndex = 0
        Me.grpButtons.TabStop = False
        '
        'btnExpot
        '
        Me.btnExpot.Location = New System.Drawing.Point(648, 1)
        Me.btnExpot.Name = "btnExpot"
        Me.btnExpot.Size = New System.Drawing.Size(66, 23)
        Me.btnExpot.TabIndex = 2
        Me.btnExpot.Text = "Export"
        Me.btnExpot.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(528, 1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 23)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(400, 1)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(74, 23)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(495, 574)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(66, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(637, 574)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(66, 23)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(256, 574)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(66, 23)
        Me.btnView.TabIndex = 7
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        Me.btnView.Visible = False
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(361, 574)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(108, 23)
        Me.btnBackup.TabIndex = 8
        Me.btnBackup.Text = "Backup to Remote"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'frmObsView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1218, 607)
        Me.Controls.Add(Me.btnBackup)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.TabObservations)
        Me.KeyPreview = True
        Me.Name = "frmObsView"
        Me.Text = "View and Update Observations"
        Me.TabObservations.ResumeLayout(False)
        Me.TabSelect.ResumeLayout(False)
        Me.pnlStationsElements.ResumeLayout(False)
        Me.pnlStationsElements.PerformLayout()
        Me.pnlSummary.ResumeLayout(False)
        Me.pnlSummary.PerformLayout()
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.txtQualifier.ResumeLayout(False)
        Me.txtQualifier.PerformLayout()
        Me.tabView.ResumeLayout(False)
        CType(Me.dataGridViewRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabObservations As TabControl
    Friend WithEvents TabSelect As TabPage
    Friend WithEvents tabView As TabPage
    Friend WithEvents grpButtons As GroupBox
    Friend WithEvents btnExpot As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents pnlStationsElements As Panel
    Friend WithEvents cmdSelectAllElements As Button
    Friend WithEvents cmdSelectAllStations As Button
    Friend WithEvents cmdClearStations As Button
    Friend WithEvents cmdClearElements As Button
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents optFinal As RadioButton
    Friend WithEvents optInitial As RadioButton
    Friend WithEvents lblSummary As Label
    Friend WithEvents cmdDelStation As Button
    Friend WithEvents cmdDelElement As Button
    Friend WithEvents chkAdvancedSelection As CheckBox
    Public WithEvents lstvElements As ListView
    Public WithEvents lstvStations As ListView
    Friend WithEvents lblElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents pnlPeriod As Panel
    Friend WithEvents lblProducts As Label
    Friend WithEvents cboMinuteEnd As ComboBox
    Friend WithEvents cboMinuteStart As ComboBox
    Friend WithEvents cboHourEnd As ComboBox
    Friend WithEvents cboHourStart As ComboBox
    Friend WithEvents txtSminute As Label
    Friend WithEvents lblHourEnd As Label
    Friend WithEvents lblHourBegin As Label
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblPeriod As Label
    Friend WithEvents txtQualifier As Panel
    Friend WithEvents lstBoxQC As ListBox
    Friend WithEvents lstBoxAcquition As ListBox
    Friend WithEvents lblStations As Label
    Friend WithEvents cmbElement As ComboBox
    Friend WithEvents cmbstation As ComboBox
    Friend WithEvents chkFlags As CheckBox
    Friend WithEvents chkQCStatus As CheckBox
    Friend WithEvents chkAcquisitionType As CheckBox
    Friend WithEvents dataGridViewRecord As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents chkForms As CheckBox
    Friend WithEvents lstBoxForms As ListBox
    Friend WithEvents txtOtherflag As TextBox
    Friend WithEvents lblOtherFlags As Label
    Friend WithEvents lstBoxFlags As ListBox
    Friend WithEvents btnView As Button
    Friend WithEvents chkAdmin4 As CheckBox
    Friend WithEvents chkAuthority As CheckBox
    Friend WithEvents chkAdmin3 As CheckBox
    Friend WithEvents chkAdmin2 As CheckBox
    Friend WithEvents chkAdmin1 As CheckBox
    Friend WithEvents chkCountry As CheckBox
    Friend WithEvents chkDbasin As CheckBox
    Friend WithEvents lblStnGroups As Label
    Friend WithEvents chkQaulifier As CheckBox
    Friend WithEvents lblDataGroups As Label
    Friend WithEvents lstQualifier As ListBox
    Friend WithEvents lstAdmin1 As ListBox
    Friend WithEvents lstAuthority As ListBox
    Friend WithEvents lstCountry As ListBox
    Friend WithEvents lstDBasin As ListBox
    Friend WithEvents lstAdmin4 As ListBox
    Friend WithEvents lstAdmin3 As ListBox
    Friend WithEvents lstAdmin2 As ListBox
    Friend WithEvents btnBackup As Button
End Class
