<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formDataView
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
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmdExport = New System.Windows.Forms.Button()
        Me.cmdEdit = New System.Windows.Forms.Button()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtMM = New System.Windows.Forms.TextBox()
        Me.txtYY = New System.Windows.Forms.TextBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStn = New System.Windows.Forms.TextBox()
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
        Me.btnHelp.Location = New System.Drawing.Point(579, 470)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(58, 23)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(194, 472)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(58, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Enabled = False
        Me.btnUpdate.Location = New System.Drawing.Point(274, 472)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(58, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(496, 472)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmdExport
        '
        Me.cmdExport.Location = New System.Drawing.Point(354, 472)
        Me.cmdExport.Name = "cmdExport"
        Me.cmdExport.Size = New System.Drawing.Size(58, 23)
        Me.cmdExport.TabIndex = 9
        Me.cmdExport.Text = "Export"
        Me.cmdExport.UseVisualStyleBackColor = True
        '
        'cmdEdit
        '
        Me.cmdEdit.Location = New System.Drawing.Point(418, 472)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(72, 23)
        Me.cmdEdit.TabIndex = 10
        Me.cmdEdit.Text = "Edit Mode"
        Me.cmdEdit.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.cmdSearch)
        Me.grpSearch.Controls.Add(Me.txtMM)
        Me.grpSearch.Controls.Add(Me.txtYY)
        Me.grpSearch.Controls.Add(Me.lblMonth)
        Me.grpSearch.Controls.Add(Me.lblYear)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Controls.Add(Me.txtStn)
        Me.grpSearch.Location = New System.Drawing.Point(581, 5)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(255, 44)
        Me.grpSearch.TabIndex = 17
        Me.grpSearch.TabStop = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(192, 15)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(53, 20)
        Me.cmdSearch.TabIndex = 30
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtMM
        '
        Me.txtMM.Location = New System.Drawing.Point(159, 16)
        Me.txtMM.Name = "txtMM"
        Me.txtMM.Size = New System.Drawing.Size(30, 20)
        Me.txtMM.TabIndex = 28
        '
        'txtYY
        '
        Me.txtYY.Location = New System.Drawing.Point(104, 16)
        Me.txtYY.Name = "txtYY"
        Me.txtYY.Size = New System.Drawing.Size(45, 20)
        Me.txtYY.TabIndex = 27
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(156, 2)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 25
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(111, 2)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 24
        Me.lblYear.Text = "Year"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Station Id"
        '
        'txtStn
        '
        Me.txtStn.Location = New System.Drawing.Point(11, 16)
        Me.txtStn.Name = "txtStn"
        Me.txtStn.Size = New System.Drawing.Size(83, 20)
        Me.txtStn.TabIndex = 22
        '
        'formDataView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 510)
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
    Friend WithEvents txtMM As System.Windows.Forms.TextBox
    Friend WithEvents txtYY As System.Windows.Forms.TextBox
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtStn As System.Windows.Forms.TextBox
End Class
