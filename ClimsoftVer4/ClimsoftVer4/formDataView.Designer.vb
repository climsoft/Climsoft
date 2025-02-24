<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formDataView
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
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboYear = New System.Windows.Forms.ComboBox()
        Me.cboStnId = New System.Windows.Forms.ComboBox()
        Me.cboStName = New System.Windows.Forms.ComboBox()
        Me.lblStName = New System.Windows.Forms.Label()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblStnId = New System.Windows.Forms.Label()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.dlgImportFile = New System.Windows.Forms.OpenFileDialog()
        Me.dlgExportFile = New System.Windows.Forms.SaveFileDialog()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView
        '
        Me.DataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Location = New System.Drawing.Point(3, 52)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.Size = New System.Drawing.Size(836, 412)
        Me.DataGridView.TabIndex = 0
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(758, 475)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(73, 23)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(7, 475)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(98, 475)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(82, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(668, 475)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(86, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(184, 475)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(84, 23)
        Me.cmdExport.TabIndex = 9
        Me.cmdExport.Text = "Backup"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(460, 475)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(127, 23)
        Me.cmdEdit.TabIndex = 10
        Me.cmdEdit.Text = "Edit Mode"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.cboMonth)
        Me.grpSearch.Controls.Add(Me.cboYear)
        Me.grpSearch.Controls.Add(Me.cboStnId)
        Me.grpSearch.Controls.Add(Me.cboStName)
        Me.grpSearch.Controls.Add(Me.lblStName)
        Me.grpSearch.Controls.Add(Me.cmdSearch)
        Me.grpSearch.Controls.Add(Me.lblMonth)
        Me.grpSearch.Controls.Add(Me.lblYear)
        Me.grpSearch.Controls.Add(Me.lblStnId)
        Me.grpSearch.Location = New System.Drawing.Point(3, 5)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(833, 44)
        Me.grpSearch.TabIndex = 17
        Me.grpSearch.TabStop = False
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(539, 16)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(51, 21)
        Me.cboMonth.TabIndex = 35
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(480, 16)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(52, 21)
        Me.cboYear.TabIndex = 34
        '
        'cboStnId
        '
        Me.cboStnId.FormattingEnabled = True
        Me.cboStnId.Location = New System.Drawing.Point(387, 16)
        Me.cboStnId.Name = "cboStnId"
        Me.cboStnId.Size = New System.Drawing.Size(87, 21)
        Me.cboStnId.TabIndex = 33
        '
        'cboStName
        '
        Me.cboStName.FormattingEnabled = True
        Me.cboStName.Location = New System.Drawing.Point(9, 16)
        Me.cboStName.Name = "cboStName"
        Me.cboStName.Size = New System.Drawing.Size(359, 21)
        Me.cboStName.TabIndex = 32
        '
        'lblStName
        '
        Me.lblStName.AutoSize = True
        Me.lblStName.Location = New System.Drawing.Point(71, 2)
        Me.lblStName.Name = "lblStName"
        Me.lblStName.Size = New System.Drawing.Size(71, 13)
        Me.lblStName.TabIndex = 31
        Me.lblStName.Text = "Station Name"
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(742, 13)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(76, 26)
        Me.cmdSearch.TabIndex = 30
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(547, 2)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 25
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(488, 2)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 24
        Me.lblYear.Text = "Year"
        '
        'lblStnId
        '
        Me.lblStnId.AutoSize = True
        Me.lblStnId.Location = New System.Drawing.Point(388, 2)
        Me.lblStnId.Name = "lblStnId"
        Me.lblStnId.Size = New System.Drawing.Size(52, 13)
        Me.lblStnId.TabIndex = 23
        Me.lblStnId.Text = "Station Id"
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(359, 475)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(97, 23)
        Me.cmdImport.TabIndex = 18
        Me.cmdImport.Text = "Import"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(591, 475)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(73, 23)
        Me.btRefresh.TabIndex = 19
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(272, 475)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(83, 24)
        Me.btnExport.TabIndex = 1190
        Me.btnExport.Text = "Export Plus"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'formDataView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 510)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.cmdImport)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.cmdEdit)
        Me.Controls.Add(Me.cmdExport)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.DataGridView)
        Me.Name = "formDataView"
        Me.Text = "Data View"
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents cmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdEdit As System.Windows.Forms.Button
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblStnId As System.Windows.Forms.Label
    Friend WithEvents cmdImport As Button
    Friend WithEvents dlgImportFile As OpenFileDialog
    Friend WithEvents dlgExportFile As SaveFileDialog
    Friend WithEvents cboStName As ComboBox
    Friend WithEvents lblStName As Label
    Friend WithEvents cboStnId As ComboBox
    Friend WithEvents cboYear As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents btRefresh As Button
    Friend WithEvents btnExport As Button
End Class
