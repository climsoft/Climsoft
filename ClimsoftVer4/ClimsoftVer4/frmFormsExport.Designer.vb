<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFormsExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFormsExport))
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dateFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.cmdSelectAllElements = New System.Windows.Forms.Button()
        Me.cmdSelectAllStations = New System.Windows.Forms.Button()
        Me.cmdClearStations = New System.Windows.Forms.Button()
        Me.cmdClearElements = New System.Windows.Forms.Button()
        Me.cmdDelStation = New System.Windows.Forms.Button()
        Me.cmdDelElement = New System.Windows.Forms.Button()
        Me.lstvElements = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lstvStations = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cmbElement = New System.Windows.Forms.ComboBox()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.tlstrpButtom = New System.Windows.Forms.ToolStrip()
        Me.tlstrpBtn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlPeriod.SuspendLayout()
        Me.tlstrpButtom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPeriod
        '
        Me.pnlPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPeriod.Controls.Add(Me.dateTo)
        Me.pnlPeriod.Controls.Add(Me.lblTo)
        Me.pnlPeriod.Controls.Add(Me.dateFrom)
        Me.pnlPeriod.Controls.Add(Me.lblFrom)
        Me.pnlPeriod.Controls.Add(Me.lblPeriod)
        Me.pnlPeriod.Location = New System.Drawing.Point(23, 2)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(641, 35)
        Me.pnlPeriod.TabIndex = 8
        '
        'dateTo
        '
        Me.dateTo.Location = New System.Drawing.Point(410, 7)
        Me.dateTo.Name = "dateTo"
        Me.dateTo.Size = New System.Drawing.Size(223, 20)
        Me.dateTo.TabIndex = 4
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(379, 11)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(20, 13)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "To"
        '
        'dateFrom
        '
        Me.dateFrom.Location = New System.Drawing.Point(104, 7)
        Me.dateFrom.Name = "dateFrom"
        Me.dateFrom.Size = New System.Drawing.Size(195, 20)
        Me.dateFrom.TabIndex = 2
        Me.dateFrom.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(59, 11)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(30, 13)
        Me.lblFrom.TabIndex = 1
        Me.lblFrom.Text = "From"
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
        'cmdSelectAllElements
        '
        Me.cmdSelectAllElements.Location = New System.Drawing.Point(478, 361)
        Me.cmdSelectAllElements.Name = "cmdSelectAllElements"
        Me.cmdSelectAllElements.Size = New System.Drawing.Size(90, 35)
        Me.cmdSelectAllElements.TabIndex = 41
        Me.cmdSelectAllElements.Text = "Select All"
        Me.cmdSelectAllElements.UseVisualStyleBackColor = True
        '
        'cmdSelectAllStations
        '
        Me.cmdSelectAllStations.Location = New System.Drawing.Point(149, 360)
        Me.cmdSelectAllStations.Name = "cmdSelectAllStations"
        Me.cmdSelectAllStations.Size = New System.Drawing.Size(90, 36)
        Me.cmdSelectAllStations.TabIndex = 40
        Me.cmdSelectAllStations.Text = "Select All"
        Me.cmdSelectAllStations.UseVisualStyleBackColor = True
        '
        'cmdClearStations
        '
        Me.cmdClearStations.Location = New System.Drawing.Point(245, 361)
        Me.cmdClearStations.Name = "cmdClearStations"
        Me.cmdClearStations.Size = New System.Drawing.Size(82, 35)
        Me.cmdClearStations.TabIndex = 39
        Me.cmdClearStations.Text = "Clear List"
        Me.cmdClearStations.UseVisualStyleBackColor = True
        '
        'cmdClearElements
        '
        Me.cmdClearElements.Location = New System.Drawing.Point(574, 361)
        Me.cmdClearElements.Name = "cmdClearElements"
        Me.cmdClearElements.Size = New System.Drawing.Size(94, 35)
        Me.cmdClearElements.TabIndex = 38
        Me.cmdClearElements.Text = "Clear List"
        Me.cmdClearElements.UseVisualStyleBackColor = True
        '
        'cmdDelStation
        '
        Me.cmdDelStation.Location = New System.Drawing.Point(23, 360)
        Me.cmdDelStation.Name = "cmdDelStation"
        Me.cmdDelStation.Size = New System.Drawing.Size(125, 36)
        Me.cmdDelStation.TabIndex = 37
        Me.cmdDelStation.Text = "Clear Selected Station"
        Me.cmdDelStation.UseVisualStyleBackColor = True
        '
        'cmdDelElement
        '
        Me.cmdDelElement.Location = New System.Drawing.Point(333, 361)
        Me.cmdDelElement.Name = "cmdDelElement"
        Me.cmdDelElement.Size = New System.Drawing.Size(139, 35)
        Me.cmdDelElement.TabIndex = 36
        Me.cmdDelElement.Text = "Clear Selected Elements"
        Me.cmdDelElement.UseVisualStyleBackColor = True
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
        Me.lstvElements.Location = New System.Drawing.Point(329, 71)
        Me.lstvElements.Name = "lstvElements"
        Me.lstvElements.RightToLeftLayout = True
        Me.lstvElements.Size = New System.Drawing.Size(335, 289)
        Me.lstvElements.TabIndex = 35
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
        Me.lstvStations.Location = New System.Drawing.Point(24, 70)
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.RightToLeftLayout = True
        Me.lstvStations.Size = New System.Drawing.Size(303, 289)
        Me.lstvStations.TabIndex = 34
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
        Me.lblElement.Location = New System.Drawing.Point(336, 50)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 33
        Me.lblElement.Text = "Select Element"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(26, 47)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 32
        Me.lblStation.Text = "Select Station"
        '
        'cmbElement
        '
        Me.cmbElement.FormattingEnabled = True
        Me.cmbElement.ItemHeight = 13
        Me.cmbElement.Location = New System.Drawing.Point(482, 45)
        Me.cmbElement.Name = "cmbElement"
        Me.cmbElement.Size = New System.Drawing.Size(143, 21)
        Me.cmbElement.TabIndex = 31
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(149, 43)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(150, 21)
        Me.cmbstation.TabIndex = 30
        '
        'tlstrpButtom
        '
        Me.tlstrpButtom.AutoSize = False
        Me.tlstrpButtom.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tlstrpButtom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlstrpButtom.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.tlstrpBtn, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.tlstrpButtom.Location = New System.Drawing.Point(0, 428)
        Me.tlstrpButtom.Name = "tlstrpButtom"
        Me.tlstrpButtom.Size = New System.Drawing.Size(681, 25)
        Me.tlstrpButtom.Stretch = True
        Me.tlstrpButtom.TabIndex = 44
        Me.tlstrpButtom.Text = "ToolStrip1"
        '
        'tlstrpBtn
        '
        Me.tlstrpBtn.AutoSize = False
        Me.tlstrpBtn.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.tlstrpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tlstrpBtn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tlstrpBtn.Name = "tlstrpBtn"
        Me.tlstrpBtn.Size = New System.Drawing.Size(82, 22)
        Me.tlstrpBtn.Text = "&Export"
        Me.tlstrpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.tlstrpBtn.ToolTipText = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(12, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(50, 22)
        Me.ToolStripButton2.Text = "&Close"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(12, 25)
        '
        'frmFormsExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 453)
        Me.Controls.Add(Me.tlstrpButtom)
        Me.Controls.Add(Me.cmdSelectAllElements)
        Me.Controls.Add(Me.cmdSelectAllStations)
        Me.Controls.Add(Me.cmdClearStations)
        Me.Controls.Add(Me.cmdClearElements)
        Me.Controls.Add(Me.cmdDelStation)
        Me.Controls.Add(Me.cmdDelElement)
        Me.Controls.Add(Me.lstvElements)
        Me.Controls.Add(Me.lstvStations)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cmbElement)
        Me.Controls.Add(Me.cmbstation)
        Me.Controls.Add(Me.pnlPeriod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmFormsExport"
        Me.Text = "Forms Data Export"
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.tlstrpButtom.ResumeLayout(False)
        Me.tlstrpButtom.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlPeriod As Panel
    Friend WithEvents dateTo As DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dateFrom As DateTimePicker
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblPeriod As Label
    Friend WithEvents cmdSelectAllElements As Button
    Friend WithEvents cmdSelectAllStations As Button
    Friend WithEvents cmdClearStations As Button
    Friend WithEvents cmdClearElements As Button
    Friend WithEvents cmdDelStation As Button
    Friend WithEvents cmdDelElement As Button
    Public WithEvents lstvElements As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Public WithEvents lstvStations As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents lblElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents cmbElement As ComboBox
    Friend WithEvents cmbstation As ComboBox
    Friend WithEvents tlstrpButtom As ToolStrip
    Friend WithEvents tlstrpBtn As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
