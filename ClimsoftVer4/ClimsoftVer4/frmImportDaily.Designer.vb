<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportDaily
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.cmdOpenFile = New System.Windows.Forms.Button()
        Me.dlgOpenImportFile = New System.Windows.Forms.OpenFileDialog()
        Me.txtImportFile = New System.Windows.Forms.TextBox()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.optComma = New System.Windows.Forms.RadioButton()
        Me.OptTAB = New System.Windows.Forms.RadioButton()
        Me.OptOthers = New System.Windows.Forms.RadioButton()
        Me.txtOther = New System.Windows.Forms.TextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.lstColumn = New System.Windows.Forms.ListBox()
        Me.cmbFields = New System.Windows.Forms.ComboBox()
        Me.cmdRename = New System.Windows.Forms.Button()
        Me.lblColumns = New System.Windows.Forms.Label()
        Me.lblFieldName = New System.Windows.Forms.Label()
        Me.lblDelimiters = New System.Windows.Forms.Label()
        Me.cmdLoadData = New System.Windows.Forms.Button()
        Me.txtObsHour = New System.Windows.Forms.TextBox()
        Me.lblStartRow = New System.Windows.Forms.Label()
        Me.txtStartRow = New System.Windows.Forms.TextBox()
        Me.cmdtest = New System.Windows.Forms.Button()
        Me.chkScale = New System.Windows.Forms.CheckBox()
        Me.cmdSaveSpecs = New System.Windows.Forms.Button()
        Me.cmdLoadSpecs = New System.Windows.Forms.Button()
        Me.dlgSaveSchema = New System.Windows.Forms.SaveFileDialog()
        Me.pnlHeaders = New System.Windows.Forms.Panel()
        Me.lblColumnHeaders = New System.Windows.Forms.Label()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.txtStn = New System.Windows.Forms.TextBox()
        Me.lblStn = New System.Windows.Forms.Label()
        Me.lblDefaultObsHour = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHeaders.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(10, 181)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(948, 405)
        Me.DataGridView1.TabIndex = 0
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.Location = New System.Drawing.Point(468, 0)
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.Size = New System.Drawing.Size(69, 23)
        Me.cmdOpenFile.TabIndex = 1
        Me.cmdOpenFile.Text = "Open File"
        Me.cmdOpenFile.UseVisualStyleBackColor = True
        '
        'dlgOpenImportFile
        '
        Me.dlgOpenImportFile.FileName = "txtImport"
        '
        'txtImportFile
        '
        Me.txtImportFile.Location = New System.Drawing.Point(4, 3)
        Me.txtImportFile.Name = "txtImportFile"
        Me.txtImportFile.Size = New System.Drawing.Size(464, 20)
        Me.txtImportFile.TabIndex = 2
        '
        'cmdView
        '
        Me.cmdView.Enabled = False
        Me.cmdView.Location = New System.Drawing.Point(12, 146)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(69, 29)
        Me.cmdView.TabIndex = 3
        Me.cmdView.Text = "View Data"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'optComma
        '
        Me.optComma.AutoSize = True
        Me.optComma.Checked = True
        Me.optComma.Location = New System.Drawing.Point(82, 41)
        Me.optComma.Name = "optComma"
        Me.optComma.Size = New System.Drawing.Size(60, 17)
        Me.optComma.TabIndex = 4
        Me.optComma.TabStop = True
        Me.optComma.Text = "Comma"
        Me.optComma.UseVisualStyleBackColor = True
        '
        'OptTAB
        '
        Me.OptTAB.AutoSize = True
        Me.OptTAB.Location = New System.Drawing.Point(174, 41)
        Me.OptTAB.Name = "OptTAB"
        Me.OptTAB.Size = New System.Drawing.Size(46, 17)
        Me.OptTAB.TabIndex = 5
        Me.OptTAB.Text = "TAB"
        Me.OptTAB.UseVisualStyleBackColor = True
        '
        'OptOthers
        '
        Me.OptOthers.AutoSize = True
        Me.OptOthers.Location = New System.Drawing.Point(256, 41)
        Me.OptOthers.Name = "OptOthers"
        Me.OptOthers.Size = New System.Drawing.Size(54, 17)
        Me.OptOthers.TabIndex = 6
        Me.OptOthers.Text = "Other:"
        Me.OptOthers.UseVisualStyleBackColor = True
        '
        'txtOther
        '
        Me.txtOther.Location = New System.Drawing.Point(309, 39)
        Me.txtOther.Name = "txtOther"
        Me.txtOther.Size = New System.Drawing.Size(24, 20)
        Me.txtOther.TabIndex = 7
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(215, 148)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(62, 29)
        Me.cmdClear.TabIndex = 8
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'lstColumn
        '
        Me.lstColumn.FormattingEnabled = True
        Me.lstColumn.Location = New System.Drawing.Point(59, 53)
        Me.lstColumn.Name = "lstColumn"
        Me.lstColumn.Size = New System.Drawing.Size(86, 30)
        Me.lstColumn.TabIndex = 9
        '
        'cmbFields
        '
        Me.cmbFields.FormattingEnabled = True
        Me.cmbFields.Items.AddRange(New Object() {"station_id", "element_code", "date_time", "time", "yyyy", "mm", "dd", "hh", "value", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbFields.Location = New System.Drawing.Point(151, 55)
        Me.cmbFields.Name = "cmbFields"
        Me.cmbFields.Size = New System.Drawing.Size(147, 21)
        Me.cmbFields.TabIndex = 10
        '
        'cmdRename
        '
        Me.cmdRename.Location = New System.Drawing.Point(191, 74)
        Me.cmdRename.Name = "cmdRename"
        Me.cmdRename.Size = New System.Drawing.Size(56, 20)
        Me.cmdRename.TabIndex = 11
        Me.cmdRename.Text = "Rename"
        Me.cmdRename.UseVisualStyleBackColor = True
        Me.cmdRename.Visible = False
        '
        'lblColumns
        '
        Me.lblColumns.AutoSize = True
        Me.lblColumns.Location = New System.Drawing.Point(56, 37)
        Me.lblColumns.Name = "lblColumns"
        Me.lblColumns.Size = New System.Drawing.Size(92, 13)
        Me.lblColumns.TabIndex = 12
        Me.lblColumns.Text = "Select Column No"
        '
        'lblFieldName
        '
        Me.lblFieldName.AutoSize = True
        Me.lblFieldName.Location = New System.Drawing.Point(171, 37)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(93, 13)
        Me.lblFieldName.TabIndex = 13
        Me.lblFieldName.Text = "Select Field Name"
        '
        'lblDelimiters
        '
        Me.lblDelimiters.AutoSize = True
        Me.lblDelimiters.Location = New System.Drawing.Point(24, 43)
        Me.lblDelimiters.Name = "lblDelimiters"
        Me.lblDelimiters.Size = New System.Drawing.Size(52, 13)
        Me.lblDelimiters.TabIndex = 15
        Me.lblDelimiters.Text = "Delimiters"
        '
        'cmdLoadData
        '
        Me.cmdLoadData.Enabled = False
        Me.cmdLoadData.Location = New System.Drawing.Point(115, 148)
        Me.cmdLoadData.Name = "cmdLoadData"
        Me.cmdLoadData.Size = New System.Drawing.Size(69, 29)
        Me.cmdLoadData.TabIndex = 16
        Me.cmdLoadData.Text = "Load Data"
        Me.cmdLoadData.UseVisualStyleBackColor = True
        '
        'txtObsHour
        '
        Me.txtObsHour.Location = New System.Drawing.Point(264, 70)
        Me.txtObsHour.Name = "txtObsHour"
        Me.txtObsHour.Size = New System.Drawing.Size(23, 20)
        Me.txtObsHour.TabIndex = 18
        Me.txtObsHour.Text = "06"
        '
        'lblStartRow
        '
        Me.lblStartRow.AutoSize = True
        Me.lblStartRow.Location = New System.Drawing.Point(24, 74)
        Me.lblStartRow.Name = "lblStartRow"
        Me.lblStartRow.Size = New System.Drawing.Size(54, 13)
        Me.lblStartRow.TabIndex = 20
        Me.lblStartRow.Text = "Start Row"
        '
        'txtStartRow
        '
        Me.txtStartRow.Location = New System.Drawing.Point(87, 70)
        Me.txtStartRow.Name = "txtStartRow"
        Me.txtStartRow.Size = New System.Drawing.Size(30, 20)
        Me.txtStartRow.TabIndex = 21
        Me.txtStartRow.Text = "2"
        '
        'cmdtest
        '
        Me.cmdtest.Location = New System.Drawing.Point(680, -1)
        Me.cmdtest.Name = "cmdtest"
        Me.cmdtest.Size = New System.Drawing.Size(48, 26)
        Me.cmdtest.TabIndex = 22
        Me.cmdtest.Text = "Test"
        Me.cmdtest.UseVisualStyleBackColor = True
        Me.cmdtest.Visible = False
        '
        'chkScale
        '
        Me.chkScale.AutoSize = True
        Me.chkScale.Location = New System.Drawing.Point(27, 105)
        Me.chkScale.Name = "chkScale"
        Me.chkScale.Size = New System.Drawing.Size(104, 17)
        Me.chkScale.TabIndex = 23
        Me.chkScale.Text = "Remove Scaling"
        Me.chkScale.UseVisualStyleBackColor = True
        '
        'cmdSaveSpecs
        '
        Me.cmdSaveSpecs.Location = New System.Drawing.Point(49, 103)
        Me.cmdSaveSpecs.Name = "cmdSaveSpecs"
        Me.cmdSaveSpecs.Size = New System.Drawing.Size(111, 25)
        Me.cmdSaveSpecs.TabIndex = 24
        Me.cmdSaveSpecs.Text = "Save Header Specs"
        Me.cmdSaveSpecs.UseVisualStyleBackColor = True
        '
        'cmdLoadSpecs
        '
        Me.cmdLoadSpecs.Location = New System.Drawing.Point(176, 103)
        Me.cmdLoadSpecs.Name = "cmdLoadSpecs"
        Me.cmdLoadSpecs.Size = New System.Drawing.Size(111, 25)
        Me.cmdLoadSpecs.TabIndex = 25
        Me.cmdLoadSpecs.Text = "Load Header Specs"
        Me.cmdLoadSpecs.UseVisualStyleBackColor = True
        '
        'pnlHeaders
        '
        Me.pnlHeaders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeaders.Controls.Add(Me.lblColumnHeaders)
        Me.pnlHeaders.Controls.Add(Me.lstColumn)
        Me.pnlHeaders.Controls.Add(Me.cmdLoadSpecs)
        Me.pnlHeaders.Controls.Add(Me.cmdSaveSpecs)
        Me.pnlHeaders.Controls.Add(Me.cmbFields)
        Me.pnlHeaders.Controls.Add(Me.cmdRename)
        Me.pnlHeaders.Controls.Add(Me.lblColumns)
        Me.pnlHeaders.Controls.Add(Me.lblFieldName)
        Me.pnlHeaders.Enabled = False
        Me.pnlHeaders.Location = New System.Drawing.Point(539, 41)
        Me.pnlHeaders.Name = "pnlHeaders"
        Me.pnlHeaders.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.pnlHeaders.Size = New System.Drawing.Size(354, 134)
        Me.pnlHeaders.TabIndex = 26
        '
        'lblColumnHeaders
        '
        Me.lblColumnHeaders.AutoSize = True
        Me.lblColumnHeaders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColumnHeaders.Location = New System.Drawing.Point(125, 1)
        Me.lblColumnHeaders.Name = "lblColumnHeaders"
        Me.lblColumnHeaders.Size = New System.Drawing.Size(149, 13)
        Me.lblColumnHeaders.TabIndex = 26
        Me.lblColumnHeaders.Text = "Columns Header Settings"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripLabel1.Text = "Save Header Specifications"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(308, 148)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(57, 29)
        Me.cmdClose.TabIndex = 27
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(396, 148)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(62, 29)
        Me.cmdHelp.TabIndex = 28
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecords.ForeColor = System.Drawing.Color.Red
        Me.lblRecords.Location = New System.Drawing.Point(339, 589)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(0, 13)
        Me.lblRecords.TabIndex = 29
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(757, 11)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(0, 13)
        Me.lblType.TabIndex = 30
        '
        'txtStn
        '
        Me.txtStn.Location = New System.Drawing.Point(218, 102)
        Me.txtStn.Name = "txtStn"
        Me.txtStn.Size = New System.Drawing.Size(240, 20)
        Me.txtStn.TabIndex = 31
        '
        'lblStn
        '
        Me.lblStn.AutoSize = True
        Me.lblStn.Location = New System.Drawing.Point(158, 107)
        Me.lblStn.Name = "lblStn"
        Me.lblStn.Size = New System.Drawing.Size(54, 13)
        Me.lblStn.TabIndex = 32
        Me.lblStn.Text = "Station ID"
        '
        'lblDefaultObsHour
        '
        Me.lblDefaultObsHour.AutoSize = True
        Me.lblDefaultObsHour.Location = New System.Drawing.Point(136, 74)
        Me.lblDefaultObsHour.Name = "lblDefaultObsHour"
        Me.lblDefaultObsHour.Size = New System.Drawing.Size(127, 13)
        Me.lblDefaultObsHour.TabIndex = 33
        Me.lblDefaultObsHour.Text = "Default Observation Hour"
        '
        'frmImportDaily
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 609)
        Me.Controls.Add(Me.lblDefaultObsHour)
        Me.Controls.Add(Me.lblStn)
        Me.Controls.Add(Me.txtStn)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblRecords)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.pnlHeaders)
        Me.Controls.Add(Me.cmdtest)
        Me.Controls.Add(Me.chkScale)
        Me.Controls.Add(Me.txtStartRow)
        Me.Controls.Add(Me.lblStartRow)
        Me.Controls.Add(Me.txtObsHour)
        Me.Controls.Add(Me.cmdLoadData)
        Me.Controls.Add(Me.lblDelimiters)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtOther)
        Me.Controls.Add(Me.OptOthers)
        Me.Controls.Add(Me.OptTAB)
        Me.Controls.Add(Me.optComma)
        Me.Controls.Add(Me.cmdView)
        Me.Controls.Add(Me.txtImportFile)
        Me.Controls.Add(Me.cmdOpenFile)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "frmImportDaily"
        Me.Text = "Daily/Hourly Data"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHeaders.ResumeLayout(False)
        Me.pnlHeaders.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOpenFile As System.Windows.Forms.Button
    Friend WithEvents dlgOpenImportFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtImportFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents optComma As System.Windows.Forms.RadioButton
    Friend WithEvents OptTAB As System.Windows.Forms.RadioButton
    Friend WithEvents OptOthers As System.Windows.Forms.RadioButton
    Friend WithEvents txtOther As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents lstColumn As System.Windows.Forms.ListBox
    Friend WithEvents cmbFields As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRename As System.Windows.Forms.Button
    Friend WithEvents lblColumns As System.Windows.Forms.Label
    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents lblDelimiters As System.Windows.Forms.Label
    Friend WithEvents cmdLoadData As System.Windows.Forms.Button
    Friend WithEvents txtObsHour As System.Windows.Forms.TextBox
    Friend WithEvents lblStartRow As System.Windows.Forms.Label
    Friend WithEvents txtStartRow As System.Windows.Forms.TextBox
    Friend WithEvents cmdtest As System.Windows.Forms.Button
    Friend WithEvents chkScale As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSaveSpecs As System.Windows.Forms.Button
    Friend WithEvents cmdLoadSpecs As System.Windows.Forms.Button
    Friend WithEvents dlgSaveSchema As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlHeaders As System.Windows.Forms.Panel
    Friend WithEvents lblColumnHeaders As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents lblRecords As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtStn As System.Windows.Forms.TextBox
    Friend WithEvents lblStn As System.Windows.Forms.Label
    Friend WithEvents lblDefaultObsHour As System.Windows.Forms.Label
End Class
