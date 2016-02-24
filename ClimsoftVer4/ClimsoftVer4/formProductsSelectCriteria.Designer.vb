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
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenListToolStripMenuItem, Me.ToolStripMenuItem2, Me.OpenListToolStripMenuItem1, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'OpenListToolStripMenuItem
        '
        Me.OpenListToolStripMenuItem.Name = "OpenListToolStripMenuItem"
        resources.ApplyResources(Me.OpenListToolStripMenuItem, "OpenListToolStripMenuItem")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'OpenListToolStripMenuItem1
        '
        Me.OpenListToolStripMenuItem1.Name = "OpenListToolStripMenuItem1"
        resources.ApplyResources(Me.OpenListToolStripMenuItem1, "OpenListToolStripMenuItem1")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        resources.ApplyResources(Me.EditToolStripMenuItem, "EditToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
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
        resources.ApplyResources(Me.pnlStationsElements, "pnlStationsElements")
        Me.pnlStationsElements.Name = "pnlStationsElements"
        '
        'pnlSummary
        '
        Me.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSummary.Controls.Add(Me.optTotal)
        Me.pnlSummary.Controls.Add(Me.optMean)
        Me.pnlSummary.Controls.Add(Me.lblSummary)
        resources.ApplyResources(Me.pnlSummary, "pnlSummary")
        Me.pnlSummary.Name = "pnlSummary"
        '
        'optTotal
        '
        resources.ApplyResources(Me.optTotal, "optTotal")
        Me.optTotal.Name = "optTotal"
        Me.optTotal.UseVisualStyleBackColor = True
        '
        'optMean
        '
        resources.ApplyResources(Me.optMean, "optMean")
        Me.optMean.Checked = True
        Me.optMean.Name = "optMean"
        Me.optMean.TabStop = True
        Me.optMean.UseVisualStyleBackColor = True
        '
        'lblSummary
        '
        resources.ApplyResources(Me.lblSummary, "lblSummary")
        Me.lblSummary.Name = "lblSummary"
        '
        'cmdDelStation
        '
        resources.ApplyResources(Me.cmdDelStation, "cmdDelStation")
        Me.cmdDelStation.Name = "cmdDelStation"
        Me.cmdDelStation.UseVisualStyleBackColor = True
        '
        'cmdDelElement
        '
        resources.ApplyResources(Me.cmdDelElement, "cmdDelElement")
        Me.cmdDelElement.Name = "cmdDelElement"
        Me.cmdDelElement.UseVisualStyleBackColor = True
        '
        'lblProductType
        '
        resources.ApplyResources(Me.lblProductType, "lblProductType")
        Me.lblProductType.Name = "lblProductType"
        '
        'chkAdvancedSelection
        '
        resources.ApplyResources(Me.chkAdvancedSelection, "chkAdvancedSelection")
        Me.chkAdvancedSelection.Name = "chkAdvancedSelection"
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
        resources.ApplyResources(Me.lstvElements, "lstvElements")
        Me.lstvElements.Name = "lstvElements"
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
        resources.ApplyResources(Me.lstvStations, "lstvStations")
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.UseCompatibleStateImageBehavior = False
        Me.lstvStations.View = System.Windows.Forms.View.Details
        '
        'lblProducts
        '
        resources.ApplyResources(Me.lblProducts, "lblProducts")
        Me.lblProducts.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblProducts.Name = "lblProducts"
        '
        'lblElement
        '
        resources.ApplyResources(Me.lblElement, "lblElement")
        Me.lblElement.Name = "lblElement"
        '
        'lblStation
        '
        resources.ApplyResources(Me.lblStation, "lblStation")
        Me.lblStation.Name = "lblStation"
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
        resources.ApplyResources(Me.pnlPeriod, "pnlPeriod")
        Me.pnlPeriod.Name = "pnlPeriod"
        '
        'txtMinuteEnd
        '
        Me.txtMinuteEnd.FormattingEnabled = True
        Me.txtMinuteEnd.Items.AddRange(New Object() {resources.GetString("txtMinuteEnd.Items"), resources.GetString("txtMinuteEnd.Items1"), resources.GetString("txtMinuteEnd.Items2"), resources.GetString("txtMinuteEnd.Items3"), resources.GetString("txtMinuteEnd.Items4"), resources.GetString("txtMinuteEnd.Items5"), resources.GetString("txtMinuteEnd.Items6"), resources.GetString("txtMinuteEnd.Items7"), resources.GetString("txtMinuteEnd.Items8"), resources.GetString("txtMinuteEnd.Items9"), resources.GetString("txtMinuteEnd.Items10"), resources.GetString("txtMinuteEnd.Items11"), resources.GetString("txtMinuteEnd.Items12"), resources.GetString("txtMinuteEnd.Items13"), resources.GetString("txtMinuteEnd.Items14"), resources.GetString("txtMinuteEnd.Items15"), resources.GetString("txtMinuteEnd.Items16"), resources.GetString("txtMinuteEnd.Items17"), resources.GetString("txtMinuteEnd.Items18"), resources.GetString("txtMinuteEnd.Items19"), resources.GetString("txtMinuteEnd.Items20"), resources.GetString("txtMinuteEnd.Items21"), resources.GetString("txtMinuteEnd.Items22"), resources.GetString("txtMinuteEnd.Items23"), resources.GetString("txtMinuteEnd.Items24"), resources.GetString("txtMinuteEnd.Items25"), resources.GetString("txtMinuteEnd.Items26"), resources.GetString("txtMinuteEnd.Items27"), resources.GetString("txtMinuteEnd.Items28"), resources.GetString("txtMinuteEnd.Items29"), resources.GetString("txtMinuteEnd.Items30"), resources.GetString("txtMinuteEnd.Items31"), resources.GetString("txtMinuteEnd.Items32"), resources.GetString("txtMinuteEnd.Items33"), resources.GetString("txtMinuteEnd.Items34"), resources.GetString("txtMinuteEnd.Items35"), resources.GetString("txtMinuteEnd.Items36"), resources.GetString("txtMinuteEnd.Items37"), resources.GetString("txtMinuteEnd.Items38"), resources.GetString("txtMinuteEnd.Items39"), resources.GetString("txtMinuteEnd.Items40"), resources.GetString("txtMinuteEnd.Items41"), resources.GetString("txtMinuteEnd.Items42"), resources.GetString("txtMinuteEnd.Items43"), resources.GetString("txtMinuteEnd.Items44"), resources.GetString("txtMinuteEnd.Items45"), resources.GetString("txtMinuteEnd.Items46"), resources.GetString("txtMinuteEnd.Items47"), resources.GetString("txtMinuteEnd.Items48"), resources.GetString("txtMinuteEnd.Items49"), resources.GetString("txtMinuteEnd.Items50"), resources.GetString("txtMinuteEnd.Items51"), resources.GetString("txtMinuteEnd.Items52"), resources.GetString("txtMinuteEnd.Items53"), resources.GetString("txtMinuteEnd.Items54"), resources.GetString("txtMinuteEnd.Items55"), resources.GetString("txtMinuteEnd.Items56"), resources.GetString("txtMinuteEnd.Items57"), resources.GetString("txtMinuteEnd.Items58"), resources.GetString("txtMinuteEnd.Items59")})
        resources.ApplyResources(Me.txtMinuteEnd, "txtMinuteEnd")
        Me.txtMinuteEnd.Name = "txtMinuteEnd"
        '
        'txtMinuteStart
        '
        Me.txtMinuteStart.FormattingEnabled = True
        Me.txtMinuteStart.Items.AddRange(New Object() {resources.GetString("txtMinuteStart.Items"), resources.GetString("txtMinuteStart.Items1"), resources.GetString("txtMinuteStart.Items2"), resources.GetString("txtMinuteStart.Items3"), resources.GetString("txtMinuteStart.Items4"), resources.GetString("txtMinuteStart.Items5"), resources.GetString("txtMinuteStart.Items6"), resources.GetString("txtMinuteStart.Items7"), resources.GetString("txtMinuteStart.Items8"), resources.GetString("txtMinuteStart.Items9"), resources.GetString("txtMinuteStart.Items10"), resources.GetString("txtMinuteStart.Items11"), resources.GetString("txtMinuteStart.Items12"), resources.GetString("txtMinuteStart.Items13"), resources.GetString("txtMinuteStart.Items14"), resources.GetString("txtMinuteStart.Items15"), resources.GetString("txtMinuteStart.Items16"), resources.GetString("txtMinuteStart.Items17"), resources.GetString("txtMinuteStart.Items18"), resources.GetString("txtMinuteStart.Items19"), resources.GetString("txtMinuteStart.Items20"), resources.GetString("txtMinuteStart.Items21"), resources.GetString("txtMinuteStart.Items22"), resources.GetString("txtMinuteStart.Items23"), resources.GetString("txtMinuteStart.Items24"), resources.GetString("txtMinuteStart.Items25"), resources.GetString("txtMinuteStart.Items26"), resources.GetString("txtMinuteStart.Items27"), resources.GetString("txtMinuteStart.Items28"), resources.GetString("txtMinuteStart.Items29"), resources.GetString("txtMinuteStart.Items30"), resources.GetString("txtMinuteStart.Items31"), resources.GetString("txtMinuteStart.Items32"), resources.GetString("txtMinuteStart.Items33"), resources.GetString("txtMinuteStart.Items34"), resources.GetString("txtMinuteStart.Items35"), resources.GetString("txtMinuteStart.Items36"), resources.GetString("txtMinuteStart.Items37"), resources.GetString("txtMinuteStart.Items38"), resources.GetString("txtMinuteStart.Items39"), resources.GetString("txtMinuteStart.Items40"), resources.GetString("txtMinuteStart.Items41"), resources.GetString("txtMinuteStart.Items42"), resources.GetString("txtMinuteStart.Items43"), resources.GetString("txtMinuteStart.Items44"), resources.GetString("txtMinuteStart.Items45"), resources.GetString("txtMinuteStart.Items46"), resources.GetString("txtMinuteStart.Items47"), resources.GetString("txtMinuteStart.Items48"), resources.GetString("txtMinuteStart.Items49"), resources.GetString("txtMinuteStart.Items50"), resources.GetString("txtMinuteStart.Items51"), resources.GetString("txtMinuteStart.Items52"), resources.GetString("txtMinuteStart.Items53"), resources.GetString("txtMinuteStart.Items54"), resources.GetString("txtMinuteStart.Items55"), resources.GetString("txtMinuteStart.Items56"), resources.GetString("txtMinuteStart.Items57"), resources.GetString("txtMinuteStart.Items58"), resources.GetString("txtMinuteStart.Items59"), resources.GetString("txtMinuteStart.Items60")})
        resources.ApplyResources(Me.txtMinuteStart, "txtMinuteStart")
        Me.txtMinuteStart.Name = "txtMinuteStart"
        '
        'txtHourEnd
        '
        Me.txtHourEnd.FormattingEnabled = True
        Me.txtHourEnd.Items.AddRange(New Object() {resources.GetString("txtHourEnd.Items"), resources.GetString("txtHourEnd.Items1"), resources.GetString("txtHourEnd.Items2"), resources.GetString("txtHourEnd.Items3"), resources.GetString("txtHourEnd.Items4"), resources.GetString("txtHourEnd.Items5"), resources.GetString("txtHourEnd.Items6"), resources.GetString("txtHourEnd.Items7"), resources.GetString("txtHourEnd.Items8"), resources.GetString("txtHourEnd.Items9"), resources.GetString("txtHourEnd.Items10"), resources.GetString("txtHourEnd.Items11"), resources.GetString("txtHourEnd.Items12"), resources.GetString("txtHourEnd.Items13"), resources.GetString("txtHourEnd.Items14"), resources.GetString("txtHourEnd.Items15"), resources.GetString("txtHourEnd.Items16"), resources.GetString("txtHourEnd.Items17"), resources.GetString("txtHourEnd.Items18"), resources.GetString("txtHourEnd.Items19"), resources.GetString("txtHourEnd.Items20"), resources.GetString("txtHourEnd.Items21"), resources.GetString("txtHourEnd.Items22"), resources.GetString("txtHourEnd.Items23")})
        resources.ApplyResources(Me.txtHourEnd, "txtHourEnd")
        Me.txtHourEnd.Name = "txtHourEnd"
        '
        'txtHourStart
        '
        Me.txtHourStart.FormattingEnabled = True
        Me.txtHourStart.Items.AddRange(New Object() {resources.GetString("txtHourStart.Items"), resources.GetString("txtHourStart.Items1"), resources.GetString("txtHourStart.Items2"), resources.GetString("txtHourStart.Items3"), resources.GetString("txtHourStart.Items4"), resources.GetString("txtHourStart.Items5"), resources.GetString("txtHourStart.Items6"), resources.GetString("txtHourStart.Items7"), resources.GetString("txtHourStart.Items8"), resources.GetString("txtHourStart.Items9"), resources.GetString("txtHourStart.Items10"), resources.GetString("txtHourStart.Items11"), resources.GetString("txtHourStart.Items12"), resources.GetString("txtHourStart.Items13"), resources.GetString("txtHourStart.Items14"), resources.GetString("txtHourStart.Items15"), resources.GetString("txtHourStart.Items16"), resources.GetString("txtHourStart.Items17"), resources.GetString("txtHourStart.Items18"), resources.GetString("txtHourStart.Items19"), resources.GetString("txtHourStart.Items20"), resources.GetString("txtHourStart.Items21"), resources.GetString("txtHourStart.Items22"), resources.GetString("txtHourStart.Items23")})
        resources.ApplyResources(Me.txtHourStart, "txtHourStart")
        Me.txtHourStart.Name = "txtHourStart"
        '
        'txtSminute
        '
        resources.ApplyResources(Me.txtSminute, "txtSminute")
        Me.txtSminute.Name = "txtSminute"
        '
        'lblHourEnd
        '
        resources.ApplyResources(Me.lblHourEnd, "lblHourEnd")
        Me.lblHourEnd.Name = "lblHourEnd"
        '
        'lblHourBegin
        '
        resources.ApplyResources(Me.lblHourBegin, "lblHourBegin")
        Me.lblHourBegin.Name = "lblHourBegin"
        '
        'dateTo
        '
        resources.ApplyResources(Me.dateTo, "dateTo")
        Me.dateTo.Name = "dateTo"
        '
        'lblTo
        '
        resources.ApplyResources(Me.lblTo, "lblTo")
        Me.lblTo.Name = "lblTo"
        '
        'dateFrom
        '
        resources.ApplyResources(Me.dateFrom, "dateFrom")
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'lblFrom
        '
        resources.ApplyResources(Me.lblFrom, "lblFrom")
        Me.lblFrom.Name = "lblFrom"
        '
        'lblPeriod
        '
        resources.ApplyResources(Me.lblPeriod, "lblPeriod")
        Me.lblPeriod.Name = "lblPeriod"
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
        resources.ApplyResources(Me.pnlStation, "pnlStation")
        Me.pnlStation.Name = "pnlStation"
        '
        'lblRadius
        '
        resources.ApplyResources(Me.lblRadius, "lblRadius")
        Me.lblRadius.Name = "lblRadius"
        '
        'lblLongitude
        '
        resources.ApplyResources(Me.lblLongitude, "lblLongitude")
        Me.lblLongitude.Name = "lblLongitude"
        '
        'txtRadius
        '
        resources.ApplyResources(Me.txtRadius, "txtRadius")
        Me.txtRadius.Name = "txtRadius"
        '
        'TxtLongitude
        '
        resources.ApplyResources(Me.TxtLongitude, "TxtLongitude")
        Me.TxtLongitude.Name = "TxtLongitude"
        '
        'txtLatitude
        '
        resources.ApplyResources(Me.txtLatitude, "txtLatitude")
        Me.txtLatitude.Name = "txtLatitude"
        '
        'lblLatitude
        '
        resources.ApplyResources(Me.lblLatitude, "lblLatitude")
        Me.lblLatitude.Name = "lblLatitude"
        '
        'OptGeography
        '
        resources.ApplyResources(Me.OptGeography, "OptGeography")
        Me.OptGeography.Name = "OptGeography"
        Me.OptGeography.TabStop = True
        Me.OptGeography.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.Name = "ListBox1"
        '
        'optBasin
        '
        resources.ApplyResources(Me.optBasin, "optBasin")
        Me.optBasin.Name = "optBasin"
        Me.optBasin.TabStop = True
        Me.optBasin.UseVisualStyleBackColor = True
        '
        'lstRegion
        '
        Me.lstRegion.FormattingEnabled = True
        resources.ApplyResources(Me.lstRegion, "lstRegion")
        Me.lstRegion.Name = "lstRegion"
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'lstAuthority
        '
        Me.lstAuthority.FormattingEnabled = True
        resources.ApplyResources(Me.lstAuthority, "lstAuthority")
        Me.lstAuthority.Name = "lstAuthority"
        '
        'optAuthority
        '
        resources.ApplyResources(Me.optAuthority, "optAuthority")
        Me.optAuthority.Name = "optAuthority"
        Me.optAuthority.TabStop = True
        Me.optAuthority.UseVisualStyleBackColor = True
        '
        'lblStations
        '
        resources.ApplyResources(Me.lblStations, "lblStations")
        Me.lblStations.Name = "lblStations"
        '
        'chkelement
        '
        resources.ApplyResources(Me.chkelement, "chkelement")
        Me.chkelement.Name = "chkelement"
        Me.chkelement.UseVisualStyleBackColor = True
        '
        'chksatation
        '
        resources.ApplyResources(Me.chksatation, "chksatation")
        Me.chksatation.Name = "chksatation"
        Me.chksatation.UseVisualStyleBackColor = True
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        resources.ApplyResources(Me.cmbElement, "cmbElement")
        Me.cmbElement.Name = "cmbElement"
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        resources.ApplyResources(Me.cmbstation, "cmbstation")
        Me.cmbstation.Name = "cmbstation"
        '
        'ToolStrip2
        '
        resources.ApplyResources(Me.ToolStrip2, "ToolStrip2")
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.prgrbProducts})
        Me.ToolStrip2.Name = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'prgrbProducts
        '
        Me.prgrbProducts.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.prgrbProducts.Name = "prgrbProducts"
        resources.ApplyResources(Me.prgrbProducts, "prgrbProducts")
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        resources.ApplyResources(Me.toolStripSeparator, "toolStripSeparator")
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.HelpToolStripButton, "HelpToolStripButton")
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.toolStripSeparator1, Me.HelpToolStripButton})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'formProductsSelectCriteria
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.pnlStationsElements)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "formProductsSelectCriteria"
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
