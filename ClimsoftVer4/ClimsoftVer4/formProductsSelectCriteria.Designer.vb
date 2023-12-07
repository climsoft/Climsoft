<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formProductsSelectCriteria
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
        Me.pnlExtremes = New System.Windows.Forms.Panel()
        Me.btnMinDate = New System.Windows.Forms.RadioButton()
        Me.btnMaxDate = New System.Windows.Forms.RadioButton()
        Me.btnLowHigh = New System.Windows.Forms.RadioButton()
        Me.lblXtyp = New System.Windows.Forms.Label()
        Me.pnlLevels = New System.Windows.Forms.Panel()
        Me.lblLevels = New System.Windows.Forms.Label()
        Me.lstvLevels = New System.Windows.Forms.ListView()
        Me.txttest = New System.Windows.Forms.TextBox()
        Me.cmdSelectAllElements = New System.Windows.Forms.Button()
        Me.cmdSelectAllStations = New System.Windows.Forms.Button()
        Me.cmdClearStations = New System.Windows.Forms.Button()
        Me.cmdClearElements = New System.Windows.Forms.Button()
        Me.chkTranspose = New System.Windows.Forms.CheckBox()
        Me.pnlSummary = New System.Windows.Forms.Panel()
        Me.lblDaysMissing = New System.Windows.Forms.Label()
        Me.txtMissingDays = New System.Windows.Forms.TextBox()
        Me.optTotal = New System.Windows.Forms.RadioButton()
        Me.optMean = New System.Windows.Forms.RadioButton()
        Me.lblSummary = New System.Windows.Forms.Label()
        Me.cmdDelStation = New System.Windows.Forms.Button()
        Me.cmdDelElement = New System.Windows.Forms.Button()
        Me.lblProductType = New System.Windows.Forms.Label()
        Me.chkAdvancedSelection = New System.Windows.Forms.CheckBox()
        Me.lstvElements = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstvStations = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblProducts = New System.Windows.Forms.Label()
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
        Me.butFill = New System.Windows.Forms.Button()
        Me.lstQualifier = New System.Windows.Forms.ListBox()
        Me.optqualifier = New System.Windows.Forms.RadioButton()
        Me.lblRadius = New System.Windows.Forms.Label()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.TxtLongitude = New System.Windows.Forms.TextBox()
        Me.txtLatitude = New System.Windows.Forms.TextBox()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.OptGeography = New System.Windows.Forms.RadioButton()
        Me.lstBasin = New System.Windows.Forms.ListBox()
        Me.optBasin = New System.Windows.Forms.RadioButton()
        Me.lstRegion = New System.Windows.Forms.ListBox()
        Me.optRegion = New System.Windows.Forms.RadioButton()
        Me.lstAuthority = New System.Windows.Forms.ListBox()
        Me.optAuthority = New System.Windows.Forms.RadioButton()
        Me.lblStations = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.chkOutputElements = New System.Windows.Forms.CheckBox()
        Me.chkOutputStations = New System.Windows.Forms.CheckBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdExtract = New System.Windows.Forms.ToolStripButton()
        Me.prgrbProducts = New System.Windows.Forms.ToolStripProgressBar()
        Me.cmdCancel = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.MenuStrip1.SuspendLayout()
        Me.pnlStationsElements.SuspendLayout()
        Me.pnlExtremes.SuspendLayout()
        Me.pnlLevels.SuspendLayout()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(1058, 24)
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
        Me.pnlStationsElements.Controls.Add(Me.pnlExtremes)
        Me.pnlStationsElements.Controls.Add(Me.pnlLevels)
        Me.pnlStationsElements.Controls.Add(Me.txttest)
        Me.pnlStationsElements.Controls.Add(Me.cmdSelectAllElements)
        Me.pnlStationsElements.Controls.Add(Me.cmdSelectAllStations)
        Me.pnlStationsElements.Controls.Add(Me.cmdClearStations)
        Me.pnlStationsElements.Controls.Add(Me.cmdClearElements)
        Me.pnlStationsElements.Controls.Add(Me.chkTranspose)
        Me.pnlStationsElements.Controls.Add(Me.pnlSummary)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelStation)
        Me.pnlStationsElements.Controls.Add(Me.cmdDelElement)
        Me.pnlStationsElements.Controls.Add(Me.lblProductType)
        Me.pnlStationsElements.Controls.Add(Me.chkAdvancedSelection)
        Me.pnlStationsElements.Controls.Add(Me.lstvElements)
        Me.pnlStationsElements.Controls.Add(Me.lstvStations)
        Me.pnlStationsElements.Controls.Add(Me.lblElement)
        Me.pnlStationsElements.Controls.Add(Me.lblStation)
        Me.pnlStationsElements.Controls.Add(Me.pnlPeriod)
        Me.pnlStationsElements.Controls.Add(Me.pnlStation)
        Me.pnlStationsElements.Controls.Add(Me.cmbElement)
        Me.pnlStationsElements.Controls.Add(Me.cmbstation)
        Me.pnlStationsElements.Controls.Add(Me.chkOutputElements)
        Me.pnlStationsElements.Controls.Add(Me.chkOutputStations)
        Me.pnlStationsElements.Location = New System.Drawing.Point(0, 52)
        Me.pnlStationsElements.Name = "pnlStationsElements"
        Me.pnlStationsElements.Size = New System.Drawing.Size(1058, 429)
        Me.pnlStationsElements.TabIndex = 4
        '
        'pnlExtremes
        '
        Me.pnlExtremes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlExtremes.Controls.Add(Me.btnMinDate)
        Me.pnlExtremes.Controls.Add(Me.btnMaxDate)
        Me.pnlExtremes.Controls.Add(Me.btnLowHigh)
        Me.pnlExtremes.Controls.Add(Me.lblXtyp)
        Me.pnlExtremes.Location = New System.Drawing.Point(648, 7)
        Me.pnlExtremes.Name = "pnlExtremes"
        Me.pnlExtremes.Size = New System.Drawing.Size(403, 61)
        Me.pnlExtremes.TabIndex = 24
        Me.pnlExtremes.Visible = False
        '
        'btnMinDate
        '
        Me.btnMinDate.Location = New System.Drawing.Point(286, 20)
        Me.btnMinDate.Name = "btnMinDate"
        Me.btnMinDate.Size = New System.Drawing.Size(104, 36)
        Me.btnMinDate.TabIndex = 3
        Me.btnMinDate.Text = "Lowest and date"
        Me.btnMinDate.UseVisualStyleBackColor = True
        '
        'btnMaxDate
        '
        Me.btnMaxDate.Location = New System.Drawing.Point(154, 20)
        Me.btnMaxDate.Name = "btnMaxDate"
        Me.btnMaxDate.Size = New System.Drawing.Size(100, 36)
        Me.btnMaxDate.TabIndex = 2
        Me.btnMaxDate.Text = "Higest and date"
        Me.btnMaxDate.UseVisualStyleBackColor = True
        '
        'btnLowHigh
        '
        Me.btnLowHigh.Checked = True
        Me.btnLowHigh.Location = New System.Drawing.Point(3, 20)
        Me.btnLowHigh.Name = "btnLowHigh"
        Me.btnLowHigh.Size = New System.Drawing.Size(131, 36)
        Me.btnLowHigh.TabIndex = 1
        Me.btnLowHigh.TabStop = True
        Me.btnLowHigh.Text = "Higest and Lowest"
        Me.btnLowHigh.UseVisualStyleBackColor = True
        '
        'lblXtyp
        '
        Me.lblXtyp.AutoSize = True
        Me.lblXtyp.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblXtyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXtyp.Location = New System.Drawing.Point(0, 0)
        Me.lblXtyp.Name = "lblXtyp"
        Me.lblXtyp.Size = New System.Drawing.Size(84, 13)
        Me.lblXtyp.TabIndex = 0
        Me.lblXtyp.Text = "Extreme Type"
        '
        'pnlLevels
        '
        Me.pnlLevels.Controls.Add(Me.lblLevels)
        Me.pnlLevels.Controls.Add(Me.lstvLevels)
        Me.pnlLevels.Location = New System.Drawing.Point(654, 3)
        Me.pnlLevels.Name = "pnlLevels"
        Me.pnlLevels.Size = New System.Drawing.Size(397, 68)
        Me.pnlLevels.TabIndex = 30
        Me.pnlLevels.Visible = False
        '
        'lblLevels
        '
        Me.lblLevels.AutoSize = True
        Me.lblLevels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevels.Location = New System.Drawing.Point(20, 24)
        Me.lblLevels.Name = "lblLevels"
        Me.lblLevels.Size = New System.Drawing.Size(139, 15)
        Me.lblLevels.TabIndex = 8
        Me.lblLevels.Text = "Select Levels (Click box)"
        '
        'lstvLevels
        '
        Me.lstvLevels.AllowColumnReorder = True
        Me.lstvLevels.AllowDrop = True
        Me.lstvLevels.CheckBoxes = True
        Me.lstvLevels.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstvLevels.FullRowSelect = True
        Me.lstvLevels.GridLines = True
        Me.lstvLevels.HideSelection = False
        Me.lstvLevels.HoverSelection = True
        Me.lstvLevels.LabelEdit = True
        Me.lstvLevels.Location = New System.Drawing.Point(172, -5)
        Me.lstvLevels.Name = "lstvLevels"
        Me.lstvLevels.RightToLeftLayout = True
        Me.lstvLevels.Size = New System.Drawing.Size(156, 73)
        Me.lstvLevels.TabIndex = 7
        Me.lstvLevels.UseCompatibleStateImageBehavior = False
        Me.lstvLevels.View = System.Windows.Forms.View.Details
        '
        'txttest
        '
        Me.txttest.Location = New System.Drawing.Point(5, 396)
        Me.txttest.Name = "txttest"
        Me.txttest.Size = New System.Drawing.Size(592, 20)
        Me.txttest.TabIndex = 31
        Me.txttest.Visible = False
        '
        'cmdSelectAllElements
        '
        Me.cmdSelectAllElements.Location = New System.Drawing.Point(459, 348)
        Me.cmdSelectAllElements.Name = "cmdSelectAllElements"
        Me.cmdSelectAllElements.Size = New System.Drawing.Size(90, 35)
        Me.cmdSelectAllElements.TabIndex = 29
        Me.cmdSelectAllElements.Text = "Select All"
        Me.cmdSelectAllElements.UseVisualStyleBackColor = True
        '
        'cmdSelectAllStations
        '
        Me.cmdSelectAllStations.Location = New System.Drawing.Point(130, 347)
        Me.cmdSelectAllStations.Name = "cmdSelectAllStations"
        Me.cmdSelectAllStations.Size = New System.Drawing.Size(90, 36)
        Me.cmdSelectAllStations.TabIndex = 28
        Me.cmdSelectAllStations.Text = "Select All"
        Me.cmdSelectAllStations.UseVisualStyleBackColor = True
        '
        'cmdClearStations
        '
        Me.cmdClearStations.Location = New System.Drawing.Point(226, 348)
        Me.cmdClearStations.Name = "cmdClearStations"
        Me.cmdClearStations.Size = New System.Drawing.Size(82, 35)
        Me.cmdClearStations.TabIndex = 27
        Me.cmdClearStations.Text = "Clear List"
        Me.cmdClearStations.UseVisualStyleBackColor = True
        '
        'cmdClearElements
        '
        Me.cmdClearElements.Location = New System.Drawing.Point(555, 348)
        Me.cmdClearElements.Name = "cmdClearElements"
        Me.cmdClearElements.Size = New System.Drawing.Size(94, 35)
        Me.cmdClearElements.TabIndex = 26
        Me.cmdClearElements.Text = "Clear List"
        Me.cmdClearElements.UseVisualStyleBackColor = True
        '
        'chkTranspose
        '
        Me.chkTranspose.AutoSize = True
        Me.chkTranspose.Location = New System.Drawing.Point(658, 178)
        Me.chkTranspose.Name = "chkTranspose"
        Me.chkTranspose.Size = New System.Drawing.Size(111, 17)
        Me.chkTranspose.TabIndex = 25
        Me.chkTranspose.Text = "Transpose Values"
        Me.chkTranspose.UseVisualStyleBackColor = True
        '
        'pnlSummary
        '
        Me.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSummary.Controls.Add(Me.lblDaysMissing)
        Me.pnlSummary.Controls.Add(Me.txtMissingDays)
        Me.pnlSummary.Controls.Add(Me.optTotal)
        Me.pnlSummary.Controls.Add(Me.optMean)
        Me.pnlSummary.Controls.Add(Me.lblSummary)
        Me.pnlSummary.Location = New System.Drawing.Point(650, 3)
        Me.pnlSummary.Name = "pnlSummary"
        Me.pnlSummary.Size = New System.Drawing.Size(398, 48)
        Me.pnlSummary.TabIndex = 23
        '
        'lblDaysMissing
        '
        Me.lblDaysMissing.AutoSize = True
        Me.lblDaysMissing.Location = New System.Drawing.Point(244, 28)
        Me.lblDaysMissing.Name = "lblDaysMissing"
        Me.lblDaysMissing.Size = New System.Drawing.Size(149, 13)
        Me.lblDaysMissing.TabIndex = 4
        Me.lblDaysMissing.Text = "Monthly Missing Days Allowed"
        Me.lblDaysMissing.Visible = False
        '
        'txtMissingDays
        '
        Me.txtMissingDays.Location = New System.Drawing.Point(211, 24)
        Me.txtMissingDays.Name = "txtMissingDays"
        Me.txtMissingDays.Size = New System.Drawing.Size(30, 20)
        Me.txtMissingDays.TabIndex = 3
        Me.txtMissingDays.Text = "0"
        Me.txtMissingDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMissingDays.Visible = False
        '
        'optTotal
        '
        Me.optTotal.AutoSize = True
        Me.optTotal.Location = New System.Drawing.Point(131, 26)
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
        Me.optMean.Location = New System.Drawing.Point(28, 26)
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
        Me.cmdDelStation.Location = New System.Drawing.Point(4, 347)
        Me.cmdDelStation.Name = "cmdDelStation"
        Me.cmdDelStation.Size = New System.Drawing.Size(125, 36)
        Me.cmdDelStation.TabIndex = 22
        Me.cmdDelStation.Text = "Clear Selected Station"
        Me.cmdDelStation.UseVisualStyleBackColor = True
        '
        'cmdDelElement
        '
        Me.cmdDelElement.Location = New System.Drawing.Point(314, 348)
        Me.cmdDelElement.Name = "cmdDelElement"
        Me.cmdDelElement.Size = New System.Drawing.Size(139, 35)
        Me.cmdDelElement.TabIndex = 21
        Me.cmdDelElement.Text = "Clear Selected Elements"
        Me.cmdDelElement.UseVisualStyleBackColor = True
        '
        'lblProductType
        '
        Me.lblProductType.AutoSize = True
        Me.lblProductType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductType.Location = New System.Drawing.Point(254, 7)
        Me.lblProductType.Name = "lblProductType"
        Me.lblProductType.Size = New System.Drawing.Size(90, 15)
        Me.lblProductType.TabIndex = 20
        Me.lblProductType.Text = "Product Type"
        '
        'chkAdvancedSelection
        '
        Me.chkAdvancedSelection.AutoSize = True
        Me.chkAdvancedSelection.Location = New System.Drawing.Point(658, 204)
        Me.chkAdvancedSelection.Name = "chkAdvancedSelection"
        Me.chkAdvancedSelection.Size = New System.Drawing.Size(167, 17)
        Me.chkAdvancedSelection.TabIndex = 19
        Me.chkAdvancedSelection.Text = "Advanced Products Selection"
        Me.chkAdvancedSelection.UseVisualStyleBackColor = True
        '
        'lstvElements
        '
        Me.lstvElements.AllowColumnReorder = True
        Me.lstvElements.AllowDrop = True
        Me.lstvElements.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lstvElements.FullRowSelect = True
        Me.lstvElements.GridLines = True
        Me.lstvElements.HideSelection = False
        Me.lstvElements.HoverSelection = True
        Me.lstvElements.LabelEdit = True
        Me.lstvElements.Location = New System.Drawing.Point(310, 58)
        Me.lstvElements.Name = "lstvElements"
        Me.lstvElements.RightToLeftLayout = True
        Me.lstvElements.Size = New System.Drawing.Size(335, 289)
        Me.lstvElements.TabIndex = 18
        Me.lstvElements.UseCompatibleStateImageBehavior = False
        Me.lstvElements.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Element Id"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Element Abbreviation"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Element Name"
        Me.ColumnHeader5.Width = 400
        '
        'lstvStations
        '
        Me.lstvStations.AllowColumnReorder = True
        Me.lstvStations.AllowDrop = True
        Me.lstvStations.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lstvStations.FullRowSelect = True
        Me.lstvStations.GridLines = True
        Me.lstvStations.HideSelection = False
        Me.lstvStations.HoverSelection = True
        Me.lstvStations.LabelEdit = True
        Me.lstvStations.Location = New System.Drawing.Point(5, 57)
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.RightToLeftLayout = True
        Me.lstvStations.Size = New System.Drawing.Size(303, 289)
        Me.lstvStations.TabIndex = 17
        Me.lstvStations.UseCompatibleStateImageBehavior = False
        Me.lstvStations.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Station Id"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Station Name"
        Me.ColumnHeader2.Width = 400
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(317, 37)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 9
        Me.lblElement.Text = "Select Element"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(7, 34)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 8
        Me.lblStation.Text = "Select Station"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPeriod.Controls.Add(Me.lblProducts)
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
        Me.pnlPeriod.Location = New System.Drawing.Point(655, 76)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(396, 97)
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
        'txtMinuteEnd
        '
        Me.txtMinuteEnd.FormattingEnabled = True
        Me.txtMinuteEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59"})
        Me.txtMinuteEnd.Location = New System.Drawing.Point(348, 68)
        Me.txtMinuteEnd.Name = "txtMinuteEnd"
        Me.txtMinuteEnd.Size = New System.Drawing.Size(40, 21)
        Me.txtMinuteEnd.TabIndex = 15
        Me.txtMinuteEnd.Text = "59"
        '
        'txtMinuteStart
        '
        Me.txtMinuteStart.FormattingEnabled = True
        Me.txtMinuteStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "67", "58", "59", "60"})
        Me.txtMinuteStart.Location = New System.Drawing.Point(348, 33)
        Me.txtMinuteStart.Name = "txtMinuteStart"
        Me.txtMinuteStart.Size = New System.Drawing.Size(40, 21)
        Me.txtMinuteStart.TabIndex = 14
        Me.txtMinuteStart.Text = "00"
        '
        'txtHourEnd
        '
        Me.txtHourEnd.FormattingEnabled = True
        Me.txtHourEnd.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHourEnd.Location = New System.Drawing.Point(306, 68)
        Me.txtHourEnd.Name = "txtHourEnd"
        Me.txtHourEnd.Size = New System.Drawing.Size(40, 21)
        Me.txtHourEnd.TabIndex = 13
        Me.txtHourEnd.Text = "23"
        '
        'txtHourStart
        '
        Me.txtHourStart.FormattingEnabled = True
        Me.txtHourStart.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHourStart.Location = New System.Drawing.Point(306, 33)
        Me.txtHourStart.Name = "txtHourStart"
        Me.txtHourStart.Size = New System.Drawing.Size(40, 21)
        Me.txtHourStart.TabIndex = 12
        Me.txtHourStart.Text = "00"
        '
        'txtSminute
        '
        Me.txtSminute.AutoSize = True
        Me.txtSminute.Location = New System.Drawing.Point(348, 17)
        Me.txtSminute.Name = "txtSminute"
        Me.txtSminute.Size = New System.Drawing.Size(39, 13)
        Me.txtSminute.TabIndex = 9
        Me.txtSminute.Text = "Minute"
        '
        'lblHourEnd
        '
        Me.lblHourEnd.AutoSize = True
        Me.lblHourEnd.Location = New System.Drawing.Point(302, 17)
        Me.lblHourEnd.Name = "lblHourEnd"
        Me.lblHourEnd.Size = New System.Drawing.Size(30, 13)
        Me.lblHourEnd.TabIndex = 7
        Me.lblHourEnd.Text = "Hour"
        '
        'lblHourBegin
        '
        Me.lblHourBegin.AutoSize = True
        Me.lblHourBegin.Location = New System.Drawing.Point(108, 17)
        Me.lblHourBegin.Name = "lblHourBegin"
        Me.lblHourBegin.Size = New System.Drawing.Size(30, 13)
        Me.lblHourBegin.TabIndex = 5
        Me.lblHourBegin.Text = "Date"
        '
        'dateTo
        '
        Me.dateTo.Location = New System.Drawing.Point(108, 68)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(195, 20)
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
        Me.dateFrom.Location = New System.Drawing.Point(108, 33)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(195, 20)
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
        Me.pnlStation.Controls.Add(Me.butFill)
        Me.pnlStation.Controls.Add(Me.lstQualifier)
        Me.pnlStation.Controls.Add(Me.optqualifier)
        Me.pnlStation.Controls.Add(Me.lblRadius)
        Me.pnlStation.Controls.Add(Me.lblLongitude)
        Me.pnlStation.Controls.Add(Me.txtRadius)
        Me.pnlStation.Controls.Add(Me.TxtLongitude)
        Me.pnlStation.Controls.Add(Me.txtLatitude)
        Me.pnlStation.Controls.Add(Me.lblLatitude)
        Me.pnlStation.Controls.Add(Me.OptGeography)
        Me.pnlStation.Controls.Add(Me.lstBasin)
        Me.pnlStation.Controls.Add(Me.optBasin)
        Me.pnlStation.Controls.Add(Me.lstRegion)
        Me.pnlStation.Controls.Add(Me.optRegion)
        Me.pnlStation.Controls.Add(Me.lstAuthority)
        Me.pnlStation.Controls.Add(Me.optAuthority)
        Me.pnlStation.Controls.Add(Me.lblStations)
        Me.pnlStation.Location = New System.Drawing.Point(655, 241)
        Me.pnlStation.Name = "pnlStation"
        Me.pnlStation.Size = New System.Drawing.Size(396, 170)
        Me.pnlStation.TabIndex = 6
        Me.pnlStation.Visible = False
        '
        'butFill
        '
        Me.butFill.Location = New System.Drawing.Point(329, 138)
        Me.butFill.Name = "butFill"
        Me.butFill.Size = New System.Drawing.Size(59, 21)
        Me.butFill.TabIndex = 16
        Me.butFill.Text = "compute"
        Me.butFill.UseVisualStyleBackColor = True
        '
        'lstQualifier
        '
        Me.lstQualifier.FormattingEnabled = True
        Me.lstQualifier.Location = New System.Drawing.Point(148, 24)
        Me.lstQualifier.Name = "lstQualifier"
        Me.lstQualifier.Size = New System.Drawing.Size(158, 17)
        Me.lstQualifier.TabIndex = 15
        '
        'optqualifier
        '
        Me.optqualifier.AutoSize = True
        Me.optqualifier.Location = New System.Drawing.Point(7, 24)
        Me.optqualifier.Name = "optqualifier"
        Me.optqualifier.Size = New System.Drawing.Size(63, 17)
        Me.optqualifier.TabIndex = 14
        Me.optqualifier.TabStop = True
        Me.optqualifier.Text = "Qualifier"
        Me.optqualifier.UseVisualStyleBackColor = True
        '
        'lblRadius
        '
        Me.lblRadius.AutoSize = True
        Me.lblRadius.Location = New System.Drawing.Point(282, 123)
        Me.lblRadius.Name = "lblRadius"
        Me.lblRadius.Size = New System.Drawing.Size(63, 13)
        Me.lblRadius.TabIndex = 13
        Me.lblRadius.Text = "Radius (km)"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(216, 123)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 12
        Me.lblLongitude.Text = "Longitude"
        '
        'txtRadius
        '
        Me.txtRadius.Enabled = False
        Me.txtRadius.Location = New System.Drawing.Point(288, 138)
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(35, 20)
        Me.txtRadius.TabIndex = 11
        '
        'TxtLongitude
        '
        Me.TxtLongitude.Enabled = False
        Me.TxtLongitude.Location = New System.Drawing.Point(222, 138)
        Me.TxtLongitude.Name = "TxtLongitude"
        Me.TxtLongitude.Size = New System.Drawing.Size(48, 20)
        Me.TxtLongitude.TabIndex = 10
        '
        'txtLatitude
        '
        Me.txtLatitude.Enabled = False
        Me.txtLatitude.Location = New System.Drawing.Point(152, 138)
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(44, 20)
        Me.txtLatitude.TabIndex = 9
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(151, 123)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 8
        Me.lblLatitude.Text = "Latitude"
        '
        'OptGeography
        '
        Me.OptGeography.AutoSize = True
        Me.OptGeography.Location = New System.Drawing.Point(7, 119)
        Me.OptGeography.Name = "OptGeography"
        Me.OptGeography.Size = New System.Drawing.Size(88, 17)
        Me.OptGeography.TabIndex = 7
        Me.OptGeography.TabStop = True
        Me.OptGeography.Text = "Geographical"
        Me.OptGeography.UseVisualStyleBackColor = True
        '
        'lstBasin
        '
        Me.lstBasin.FormattingEnabled = True
        Me.lstBasin.Location = New System.Drawing.Point(148, 94)
        Me.lstBasin.Name = "lstBasin"
        Me.lstBasin.Size = New System.Drawing.Size(158, 17)
        Me.lstBasin.TabIndex = 6
        '
        'optBasin
        '
        Me.optBasin.AutoSize = True
        Me.optBasin.Location = New System.Drawing.Point(7, 94)
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
        Me.lstRegion.Location = New System.Drawing.Point(148, 71)
        Me.lstRegion.Name = "lstRegion"
        Me.lstRegion.Size = New System.Drawing.Size(158, 17)
        Me.lstRegion.TabIndex = 4
        '
        'optRegion
        '
        Me.optRegion.AutoSize = True
        Me.optRegion.Location = New System.Drawing.Point(7, 71)
        Me.optRegion.Name = "optRegion"
        Me.optRegion.Size = New System.Drawing.Size(59, 17)
        Me.optRegion.TabIndex = 3
        Me.optRegion.TabStop = True
        Me.optRegion.Text = "Region"
        Me.optRegion.UseVisualStyleBackColor = True
        '
        'lstAuthority
        '
        Me.lstAuthority.FormattingEnabled = True
        Me.lstAuthority.Location = New System.Drawing.Point(148, 48)
        Me.lstAuthority.Name = "lstAuthority"
        Me.lstAuthority.Size = New System.Drawing.Size(158, 17)
        Me.lstAuthority.TabIndex = 2
        '
        'optAuthority
        '
        Me.optAuthority.AutoSize = True
        Me.optAuthority.Location = New System.Drawing.Point(7, 48)
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
        Me.lblStations.Size = New System.Drawing.Size(152, 13)
        Me.lblStations.TabIndex = 0
        Me.lblStations.Text = "Group Stations Selection "
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(463, 32)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(143, 21)
        Me.cmbElement.TabIndex = 3
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(130, 30)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(150, 21)
        Me.cmbstation.TabIndex = 1
        '
        'chkOutputElements
        '
        Me.chkOutputElements.AutoSize = True
        Me.chkOutputElements.Checked = True
        Me.chkOutputElements.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOutputElements.Location = New System.Drawing.Point(782, 242)
        Me.chkOutputElements.Name = "chkOutputElements"
        Me.chkOutputElements.Size = New System.Drawing.Size(164, 17)
        Me.chkOutputElements.TabIndex = 33
        Me.chkOutputElements.Text = "Output Observation Elements"
        Me.chkOutputElements.UseVisualStyleBackColor = True
        Me.chkOutputElements.Visible = False
        '
        'chkOutputStations
        '
        Me.chkOutputStations.AutoSize = True
        Me.chkOutputStations.Checked = True
        Me.chkOutputStations.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOutputStations.Location = New System.Drawing.Point(659, 242)
        Me.chkOutputStations.Name = "chkOutputStations"
        Me.chkOutputStations.Size = New System.Drawing.Size(99, 17)
        Me.chkOutputStations.TabIndex = 32
        Me.chkOutputStations.Text = "Output Stations"
        Me.chkOutputStations.UseVisualStyleBackColor = True
        Me.chkOutputStations.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.cmdExtract, Me.prgrbProducts, Me.cmdCancel})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 482)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1058, 25)
        Me.ToolStrip2.TabIndex = 9
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdExtract
        '
        Me.cmdExtract.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdExtract.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExtract.Image = CType(resources.GetObject("cmdExtract.Image"), System.Drawing.Image)
        Me.cmdExtract.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdExtract.Name = "cmdExtract"
        Me.cmdExtract.Size = New System.Drawing.Size(99, 22)
        Me.cmdExtract.Text = "Start Extraction"
        '
        'prgrbProducts
        '
        Me.prgrbProducts.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.prgrbProducts.Name = "prgrbProducts"
        Me.prgrbProducts.Size = New System.Drawing.Size(100, 22)
        '
        'cmdCancel
        '
        Me.cmdCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmdCancel.Image = CType(resources.GetObject("cmdCancel.Image"), System.Drawing.Image)
        Me.cmdCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(47, 22)
        Me.cmdCancel.Text = "Cancel"
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1058, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'formProductsSelectCriteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 507)
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
        Me.pnlExtremes.ResumeLayout(False)
        Me.pnlExtremes.PerformLayout()
        Me.pnlLevels.ResumeLayout(False)
        Me.pnlLevels.PerformLayout()
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
    Friend WithEvents lstBasin As System.Windows.Forms.ListBox
    Friend WithEvents optBasin As System.Windows.Forms.RadioButton
    Friend WithEvents lstRegion As System.Windows.Forms.ListBox
    Friend WithEvents optRegion As System.Windows.Forms.RadioButton
    Friend WithEvents lstAuthority As System.Windows.Forms.ListBox
    Friend WithEvents optAuthority As System.Windows.Forms.RadioButton
    Friend WithEvents lblStations As System.Windows.Forms.Label
    Friend WithEvents lblProducts As System.Windows.Forms.Label
    Friend WithEvents lblElement As System.Windows.Forms.Label
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdExtract As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents cmdCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlExtremes As System.Windows.Forms.Panel
    Friend WithEvents btnMinDate As System.Windows.Forms.RadioButton
    Friend WithEvents btnMaxDate As System.Windows.Forms.RadioButton
    Friend WithEvents btnLowHigh As System.Windows.Forms.RadioButton
    Friend WithEvents lblXtyp As System.Windows.Forms.Label
    Friend WithEvents chkTranspose As System.Windows.Forms.CheckBox
    Friend WithEvents cmdClearElements As System.Windows.Forms.Button
    Friend WithEvents cmdClearStations As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAllElements As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAllStations As System.Windows.Forms.Button
    Friend WithEvents pnlLevels As Panel
    Public WithEvents lstvLevels As ListView
    Friend WithEvents lblLevels As Label
    Friend WithEvents lstQualifier As ListBox
    Friend WithEvents optqualifier As RadioButton
    Friend WithEvents butFill As Button
    Friend WithEvents txttest As TextBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents lblDaysMissing As Label
    Friend WithEvents txtMissingDays As TextBox
    Friend WithEvents chkOutputElements As CheckBox
    Friend WithEvents chkOutputStations As CheckBox
End Class
