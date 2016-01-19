<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formProductsSelectCriteria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formProductsSelectCriteria))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenListToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlStationsElements = New System.Windows.Forms.Panel()
        Me.pnlSummary = New System.Windows.Forms.Panel()
        Me.optTotal = New System.Windows.Forms.RadioButton()
        Me.optMean = New System.Windows.Forms.RadioButton()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.cmdDelStation = New System.Windows.Forms.Button()
        Me.cmdDelElement = New System.Windows.Forms.Button()
        Me.lblProductType = New System.Windows.Forms.Label()
        Me.chkAdvancedSelection = New System.Windows.Forms.CheckBox()
        Me.lstvElements = New System.Windows.Forms.ListView()
        Me.lstvStations = New System.Windows.Forms.ListView()
        Me.lblProducts = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.txtMinuteEnd = New System.Windows.Forms.ComboBox()
        Me.txtMinuteStart = New System.Windows.Forms.ComboBox()
        Me.txtHourEnd = New System.Windows.Forms.ComboBox()
        Me.txtHourStart = New System.Windows.Forms.ComboBox()
        Me.txtSminute = New System.Windows.Forms.Label()
        Me.lblHourEnd = New System.Windows.Forms.Label()
        Me.lblHourBegin = New System.Windows.Forms.Label()
        Me.dateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.pnlStation = New System.Windows.Forms.Panel()
        Me.lblRadius = New System.Windows.Forms.Label()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.TxtLongitude = New System.Windows.Forms.TextBox()
        Me.txtLatitude = New System.Windows.Forms.TextBox()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.OptGeography = New System.Windows.Forms.RadioButton()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.optBasin = New System.Windows.Forms.RadioButton()
        Me.lstRegion = New System.Windows.Forms.ListBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.lstAuthority = New System.Windows.Forms.ListBox()
        Me.optAuthority = New System.Windows.Forms.RadioButton()
        Me.lblStations = New System.Windows.Forms.Label()
        Me.chkelement = New System.Windows.Forms.CheckBox()
        Me.chksatation = New System.Windows.Forms.CheckBox()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.prgrbProducts = New System.Windows.Forms.ToolStripProgressBar()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.MenuStrip1.SuspendLayout()
        Me.pnlStationsElements.SuspendLayout()
        Me.pnlSummary.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.pnlStation.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(893, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenListToolStripMenuItem, Me.ToolStripMenuItem2, Me.OpenListToolStripMenuItem1, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenListToolStripMenuItem
        '
        Me.OpenListToolStripMenuItem.Name = "OpenListToolStripMenuItem"
        Me.OpenListToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.OpenListToolStripMenuItem.Text = "Save Specifications"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(179, 22)
        Me.ToolStripMenuItem2.Text = "Open Specifications"
        '
        'OpenListToolStripMenuItem1
        '
        Me.OpenListToolStripMenuItem1.Name = "OpenListToolStripMenuItem1"
        Me.OpenListToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.OpenListToolStripMenuItem1.Text = "Add New Product"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'pnlStationsElements
        '
        Me.pnlStationsElements.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlStationsElements.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlStationsElements.Controls.Add(Me.pnlSummary)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelStation)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelElement)
        Me.pnlStationsElements.Controls.Add(Me.lblProductType)
        Me.pnlStationsElements.Controls.Add(Me.chkAdvancedSelection)
        Me.pnlStationsElements.Controls.Add(Me.lstvElements)
        Me.pnlStationsElements.Controls.Add(Me.lstvStations)
        Me.pnlStationsElements.Controls.Add(Me.lblProducts)
        Me.pnlStationsElements.Controls.Add(Me.lblElement)
        Me.pnlStationsElements.Controls.Add(Me.lblStation)
        Me.pnlStationsElements.Controls.Add(Me.pnlPeriod)
        Me.pnlStationsElements.Controls.Add(Me.pnlStation)
        Me.pnlStationsElements.Controls.Add(Me.chkelement)
        Me.pnlStationsElements.Controls.Add(Me.chksatation)
        Me.pnlStationsElements.Controls.Add(Me.cmbElement)
        Me.pnlStationsElements.Controls.Add(Me.cmbstation)
        Me.pnlStationsElements.Location = New System.Drawing.Point(0, 52)
        Me.pnlStationsElements.Name = "pnlStationsElements"
        Me.pnlStationsElements.Size = New System.Drawing.Size(883, 395)
        Me.pnlStationsElements.TabIndex = 4
        '
        'pnlSummary
        '
        Me.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSummary.Controls.Add(Me.optTotal)
        Me.pnlSummary.Controls.Add(Me.optMean)
        Me.pnlSummary.Controls.Add(Me.lblSummary)
        Me.pnlSummary.Location = New System.Drawing.Point(541, 7)
        Me.pnlSummary.Name = "pnlSummary"
        Me.pnlSummary.Size = New System.Drawing.Size(329, 48)
        Me.pnlSummary.TabIndex = 23
        '
        'optTotal
        '
        Me.optTotal.AutoSize = True
        Me.optTotal.Location = New System.Drawing.Point(205, 26)
        Me.optTotal.Name = "optTotal"
        Me.optTotal.Size = New System.Drawing.Size(49, 17)
        Me.optTotal.TabIndex = 2
        Me.optTotal.Text = "Total"
        Me.optTotal.UseVisualStyleBackColor = True
        '
        'optMean
        '
        Me.optMean.AutoSize = True
        Me.optMean.Checked = True
        Me.optMean.Location = New System.Drawing.Point(104, 26)
        Me.optMean.Name = "optMean"
        Me.optMean.Size = New System.Drawing.Size(52, 17)
        Me.optMean.TabIndex = 1
        Me.optMean.TabStop = True
        Me.optMean.Text = "Mean"
        Me.optMean.UseVisualStyleBackColor = True
        '
        'lblSummary
        '
        Me.lblSummary.AutoSize = True
        Me.lblSummary.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSummary.Location = New System.Drawing.Point(0, 0)
        Me.lblSummary.Name = "lblSummary"
        Me.lblSummary.Size = New System.Drawing.Size(89, 13)
        Me.lblSummary.TabIndex = 0
        Me.lblSummary.Text = "Summary Type"
        '
        'cmdDelStation
        '
        Me.cmdDelStation.Location = New System.Drawing.Point(80, 348)
        Me.cmdDelStation.Name = "cmdDelStation"
        Me.cmdDelStation.Size = New System.Drawing.Size(135, 27)
        Me.cmdDelStation.TabIndex = 22
        Me.cmdDelStation.Text = "Delete Selected Station"
        Me.cmdDelStation.UseVisualStyleBackColor = True
        '
        'cmdDelElement
        '
        Me.cmdDelElement.Location = New System.Drawing.Point(354, 348)
        Me.cmdDelElement.Name = "cmdDelElement"
        Me.cmdDelElement.Size = New System.Drawing.Size(143, 27)
        Me.cmdDelElement.TabIndex = 21
        Me.cmdDelElement.Text = "Delete Selected Element"
        Me.cmdDelElement.UseVisualStyleBackColor = True
        '
        'lblProductType
        '
        Me.lblProductType.AutoSize = True
        Me.lblProductType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductType.Location = New System.Drawing.Point(254, 7)
        Me.lblProductType.Name = "lblProductType"
        Me.lblProductType.Size = New System.Drawing.Size(31, 15)
        Me.lblProductType.TabIndex = 20
        Me.lblProductType.Text = "      "
        '
        'chkAdvancedSelection
        '
        Me.chkAdvancedSelection.AutoSize = True
        Me.chkAdvancedSelection.Location = New System.Drawing.Point(542, 182)
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
        Me.lstvElements.Location = New System.Drawing.Point(270, 57)
        Me.lstvElements.Name = "lstvElements"
        Me.lstvElements.RightToLeftLayout = True
        Me.lstvElements.Size = New System.Drawing.Size(266, 291)
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
        Me.lstvStations.Location = New System.Drawing.Point(5, 57)
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.RightToLeftLayout = True
        Me.lstvStations.Size = New System.Drawing.Size(257, 289)
        Me.lstvStations.TabIndex = 17
        Me.lstvStations.UseCompatibleStateImageBehavior = False
        Me.lstvStations.View = System.Windows.Forms.View.Details
        '
        'lblProducts
        '
        Me.lblProducts.AutoSize = True
        Me.lblProducts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducts.Location = New System.Drawing.Point(874, 57)
        Me.lblProducts.Name = "lblProducts"
        Me.lblProducts.Size = New System.Drawing.Size(17, 16)
        Me.lblProducts.TabIndex = 8
        Me.lblProducts.Text = "   "
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(268, 34)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 9
        Me.lblElement.Text = "Select Element"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(10, 34)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 8
        Me.lblStation.Text = "Select Station"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPeriod.Controls.Add(Me.txtMinuteEnd)
        Me.pnlPeriod.Controls.Add(Me.txtMinuteStart)
        Me.pnlPeriod.Controls.Add(Me.txtHourEnd)
        Me.pnlPeriod.Controls.Add(Me.txtHourStart)
        Me.pnlPeriod.Controls.Add(Me.txtSminute)
        Me.pnlPeriod.Controls.Add(Me.lblHourEnd)
        Me.pnlPeriod.Controls.Add(Me.lblHourBegin)
        Me.pnlPeriod.Controls.Add(Me.dateTo)
        Me.pnlPeriod.Controls.Add(Me.lblTo)
        Me.pnlPeriod.Controls.Add(Me.dateFrom)
        Me.pnlPeriod.Controls.Add(Me.lblFrom)
        Me.pnlPeriod.Controls.Add(Me.lblPeriod)
        Me.pnlPeriod.Location = New System.Drawing.Point(542, 61)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(330, 97)
        Me.pnlPeriod.TabIndex = 7
        '
        'txtMinuteEnd
        '
        Me.txtMinuteEnd.FormattingEnabled = True
        Me.txtMinuteEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59"})
        Me.txtMinuteEnd.Location = New System.Drawing.Point(279, 67)
        Me.txtMinuteEnd.Name = "txtMinuteEnd"
        Me.txtMinuteEnd.Size = New System.Drawing.Size(40, 21)
        Me.txtMinuteEnd.TabIndex = 15
        Me.txtMinuteEnd.Text = "00"
        '
        'txtMinuteStart
        '
        Me.txtMinuteStart.FormattingEnabled = True
        Me.txtMinuteStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59", "60"})
        Me.txtMinuteStart.Location = New System.Drawing.Point(279, 33)
        Me.txtMinuteStart.Name = "txtMinuteStart"
        Me.txtMinuteStart.Size = New System.Drawing.Size(40, 21)
        Me.txtMinuteStart.TabIndex = 14
        Me.txtMinuteStart.Text = "00"
        '
        'txtHourEnd
        '
        Me.txtHourEnd.FormattingEnabled = True
        Me.txtHourEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHourEnd.Location = New System.Drawing.Point(233, 68)
        Me.txtHourEnd.Name = "txtHourEnd"
        Me.txtHourEnd.Size = New System.Drawing.Size(40, 21)
        Me.txtHourEnd.TabIndex = 13
        Me.txtHourEnd.Text = "23"
        '
        'txtHourStart
        '
        Me.txtHourStart.FormattingEnabled = True
        Me.txtHourStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHourStart.Location = New System.Drawing.Point(233, 34)
        Me.txtHourStart.Name = "txtHourStart"
        Me.txtHourStart.Size = New System.Drawing.Size(40, 21)
        Me.txtHourStart.TabIndex = 12
        Me.txtHourStart.Text = "00"
        '
        'txtSminute
        '
        Me.txtSminute.AutoSize = True
        Me.txtSminute.Location = New System.Drawing.Point(280, 18)
        Me.txtSminute.Name = "txtSminute"
        Me.txtSminute.Size = New System.Drawing.Size(39, 13)
        Me.txtSminute.TabIndex = 9
        Me.txtSminute.Text = "Minute"
        '
        'lblHourEnd
        '
        Me.lblHourEnd.AutoSize = True
        Me.lblHourEnd.Location = New System.Drawing.Point(236, 18)
        Me.lblHourEnd.Name = "lblHourEnd"
        Me.lblHourEnd.Size = New System.Drawing.Size(30, 13)
        Me.lblHourEnd.TabIndex = 7
        Me.lblHourEnd.Text = "Hour"
        '
        'lblHourBegin
        '
        Me.lblHourBegin.AutoSize = True
        Me.lblHourBegin.Location = New System.Drawing.Point(89, 18)
        Me.lblHourBegin.Name = "lblHourBegin"
        Me.lblHourBegin.Size = New System.Drawing.Size(30, 13)
        Me.lblHourBegin.TabIndex = 5
        Me.lblHourBegin.Text = "Date"
        '
        'dateTo
        '
        Me.dateTo.Location = New System.Drawing.Point(63, 68)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(164, 20)
        Me.dateTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(7, 72)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(52, 13)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "End Date"
        '
        'dateFrom
        '
        Me.dateFrom.Location = New System.Drawing.Point(63, 33)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(164, 20)
        Me.dateFrom.TabIndex = 2
        Me.dateFrom.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(7, 37)
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
        'pnlStation
        '
        Me.pnlStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStation.Controls.Add(Me.lblRadius)
        Me.pnlStation.Controls.Add(Me.lblLongitude)
        Me.pnlStation.Controls.Add(Me.txtRadius)
        Me.pnlStation.Controls.Add(Me.TxtLongitude)
        Me.pnlStation.Controls.Add(Me.txtLatitude)
        Me.pnlStation.Controls.Add(Me.lblLatitude)
        Me.pnlStation.Controls.Add(Me.OptGeography)
        Me.pnlStation.Controls.Add(Me.ListBox1)
        Me.pnlStation.Controls.Add(Me.optBasin)
        Me.pnlStation.Controls.Add(Me.lstRegion)
        Me.pnlStation.Controls.Add(Me.RadioButton1)
        Me.pnlStation.Controls.Add(Me.lstAuthority)
        Me.pnlStation.Controls.Add(Me.optAuthority)
        Me.pnlStation.Controls.Add(Me.lblStations)
        Me.pnlStation.Location = New System.Drawing.Point(542, 212)
        Me.pnlStation.Name = "pnlStation"
        Me.pnlStation.Size = New System.Drawing.Size(330, 152)
        Me.pnlStation.TabIndex = 6
        Me.pnlStation.Visible = False
        '
        'lblRadius
        '
        Me.lblRadius.AutoSize = True
        Me.lblRadius.Location = New System.Drawing.Point(203, 101)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(69, 13)
        Me.lblRadius.TabIndex = 13
        Me.lblRadius.Text = "Radiuds (km)"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(146, 101)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 12
        Me.lblLongitude.Text = "Longitude"
        '
        'txtRadius
        '
        Me.txtRadius.Location = New System.Drawing.Point(212, 116)
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(53, 20)
        Me.txtRadius.TabIndex = 11
        '
        'TxtLongitude
        '
        Me.TxtLongitude.Location = New System.Drawing.Point(152, 116)
        Me.TxtLongitude.Name = "TxtLongitude"
        Me.TxtLongitude.Size = New System.Drawing.Size(53, 20)
        Me.TxtLongitude.TabIndex = 10
        '
        'txtLatitude
        '
        Me.txtLatitude.Location = New System.Drawing.Point(92, 116)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(53, 20)
        Me.txtLatitude.TabIndex = 9
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(91, 101)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 8
        Me.lblLatitude.Text = "Latitude"
        '
        'OptGeography
        '
        Me.OptGeography.AutoSize = True
        Me.OptGeography.Location = New System.Drawing.Point(3, 97)
        Me.OptGeography.Name = "OptGeography"
        Me.OptGeography.Size = New System.Drawing.Size(88, 17)
        Me.OptGeography.TabIndex = 7
        Me.OptGeography.TabStop = True
        Me.OptGeography.Text = "Geographical"
        Me.OptGeography.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(97, 74)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(158, 17)
        Me.ListBox1.TabIndex = 6
        '
        'optBasin
        '
        Me.optBasin.AutoSize = True
        Me.optBasin.Location = New System.Drawing.Point(3, 74)
        Me.optBasin.Name = "optBasin"
        Me.optBasin.Size = New System.Drawing.Size(97, 17)
        Me.optBasin.TabIndex = 5
        Me.optBasin.TabStop = True
        Me.optBasin.Text = "Drainage Basin"
        Me.optBasin.UseVisualStyleBackColor = True
        '
        'lstRegion
        '
        Me.lstRegion.FormattingEnabled = True
        Me.lstRegion.Location = New System.Drawing.Point(97, 51)
        Me.lstRegion.Name = "lstRegion"
        Me.lstRegion.Size = New System.Drawing.Size(158, 17)
        Me.lstRegion.TabIndex = 4
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(3, 51)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(59, 17)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Region"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'lstAuthority
        '
        Me.lstAuthority.FormattingEnabled = True
        Me.lstAuthority.Location = New System.Drawing.Point(97, 28)
        Me.lstAuthority.Name = "lstAuthority"
        Me.lstAuthority.Size = New System.Drawing.Size(158, 17)
        Me.lstAuthority.TabIndex = 2
        '
        'optAuthority
        '
        Me.optAuthority.AutoSize = True
        Me.optAuthority.Location = New System.Drawing.Point(3, 28)
        Me.optAuthority.Name = "optAuthority"
        Me.optAuthority.Size = New System.Drawing.Size(66, 17)
        Me.optAuthority.TabIndex = 1
        Me.optAuthority.TabStop = True
        Me.optAuthority.Text = "Authority"
        Me.optAuthority.UseVisualStyleBackColor = True
        '
        'lblStations
        '
        Me.lblStations.AutoSize = True
        Me.lblStations.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblStations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStations.Location = New System.Drawing.Point(0, 0)
        Me.lblStations.Name = "lblStations"
        Me.lblStations.Size = New System.Drawing.Size(121, 13)
        Me.lblStations.TabIndex = 0
        Me.lblStations.Text = "Advanced Selection"
        '
        'chkelement
        '
        Me.chkelement.AutoSize = True
        Me.chkelement.Location = New System.Drawing.Point(270, 354)
        Me.chkelement.Name = "chkelement"
        Me.chkelement.Size = New System.Drawing.Size(69, 17)
        Me.chkelement.TabIndex = 5
        Me.chkelement.Text = "Clear List"
        Me.chkelement.UseVisualStyleBackColor = True
        '
        'chksatation
        '
        Me.chksatation.AutoSize = True
        Me.chksatation.Location = New System.Drawing.Point(5, 353)
        Me.chksatation.Name = "chksatation"
        Me.chksatation.Size = New System.Drawing.Size(69, 17)
        Me.chksatation.TabIndex = 4
        Me.chksatation.Text = "Clear List"
        Me.chksatation.UseVisualStyleBackColor = True
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(352, 30)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(182, 21)
        Me.cmbElement.TabIndex = 3
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(84, 30)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(178, 21)
        Me.cmbstation.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.prgrbProducts})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 450)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(893, 25)
        Me.ToolStrip2.TabIndex = 9
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(99, 22)
        Me.ToolStripButton1.Text = "Start Extraction"
        '
        'prgrbProducts
        '
        Me.prgrbProducts.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.prgrbProducts.Name = "prgrbProducts"
        Me.prgrbProducts.Size = New System.Drawing.Size(100, 22)
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.toolStripSeparator1, Me.HelpToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(893, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'formProductsSelectCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(893, 475)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.pnlStationsElements)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "formProductsSelectCriteria"
        Me.Text = "Data Selection"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnlStationsElements.ResumeLayout(False)
        Me.pnlStationsElements.PerformLayout()
        Me.pnlSummary.ResumeLayout(False)
        Me.pnlSummary.PerformLayout()
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.pnlStation.ResumeLayout(False)
        Me.pnlStation.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents pnlStationsElements As System.Windows.Forms.Panel
    Friend WithEvents cmbElement As System.Windows.Forms.ComboBox
    Friend WithEvents cmbstation As System.Windows.Forms.ComboBox
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenListToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkelement As System.Windows.Forms.CheckBox
    Friend WithEvents chksatation As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTo As System.Windows.Forms.Label
    Friend WithEvents dateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFrom As System.Windows.Forms.Label
    Friend WithEvents lblPeriod As System.Windows.Forms.Label
    Friend WithEvents pnlStation As System.Windows.Forms.Panel
    Friend WithEvents lblRadius As System.Windows.Forms.Label
    Friend WithEvents lblLongitude As System.Windows.Forms.Label
    Friend WithEvents txtRadius As System.Windows.Forms.TextBox
    Friend WithEvents TxtLongitude As System.Windows.Forms.TextBox
    Friend WithEvents txtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents lblLatitude As System.Windows.Forms.Label
    Friend WithEvents OptGeography As System.Windows.Forms.RadioButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents optBasin As System.Windows.Forms.RadioButton
    Friend WithEvents lstRegion As System.Windows.Forms.ListBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents lstAuthority As System.Windows.Forms.ListBox
    Friend WithEvents optAuthority As System.Windows.Forms.RadioButton
    Friend WithEvents lblStations As System.Windows.Forms.Label
    Friend WithEvents lblProducts As System.Windows.Forms.Label
    Friend WithEvents lblElement As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents prgrbProducts As System.Windows.Forms.ToolStripProgressBar
    Public WithEvents lstvStations As System.Windows.Forms.ListView
    Public WithEvents lstvElements As System.Windows.Forms.ListView
    Friend WithEvents chkAdvancedSelection As System.Windows.Forms.CheckBox
    Friend WithEvents lblProductType As System.Windows.Forms.Label
    Friend WithEvents lblHourEnd As System.Windows.Forms.Label
    Friend WithEvents lblHourBegin As System.Windows.Forms.Label
    Friend WithEvents cmdDelStation As System.Windows.Forms.Button
    Friend WithEvents cmdDelElement As System.Windows.Forms.Button
    Friend WithEvents txtSminute As System.Windows.Forms.Label
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents txtHourStart As System.Windows.Forms.ComboBox
    Friend WithEvents txtMinuteStart As System.Windows.Forms.ComboBox
    Friend WithEvents txtHourEnd As System.Windows.Forms.ComboBox
    Friend WithEvents txtMinuteEnd As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSummary As System.Windows.Forms.Panel
    Friend WithEvents optTotal As System.Windows.Forms.RadioButton
    Friend WithEvents optMean As System.Windows.Forms.RadioButton
    Friend WithEvents lblSummary As System.Windows.Forms.Label
End Class
