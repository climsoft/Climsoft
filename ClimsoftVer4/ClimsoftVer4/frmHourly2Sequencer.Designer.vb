<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHourly2Sequencer
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
        Me.lblSequencerGuidelines = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dataGridViewHours = New System.Windows.Forms.DataGridView()
        Me.colHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dataGridViewHours, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblSequencerGuidelines
        '
        Me.lblSequencerGuidelines.ForeColor = System.Drawing.Color.Red
        Me.lblSequencerGuidelines.Location = New System.Drawing.Point(9, 9)
        Me.lblSequencerGuidelines.Name = "lblSequencerGuidelines"
        Me.lblSequencerGuidelines.Size = New System.Drawing.Size(271, 47)
        Me.lblSequencerGuidelines.TabIndex = 16
        Me.lblSequencerGuidelines.Text = "Select the hours  to be used for entering and ordering the sequence of entry of d" &
    "ata when using formHourly2. "
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(52, 343)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(143, 343)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dataGridViewHours
        '
        Me.dataGridViewHours.AllowUserToAddRows = False
        Me.dataGridViewHours.AllowUserToDeleteRows = False
        Me.dataGridViewHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewHours.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHour, Me.colSelect})
        Me.dataGridViewHours.Location = New System.Drawing.Point(12, 66)
        Me.dataGridViewHours.MultiSelect = False
        Me.dataGridViewHours.Name = "dataGridViewHours"
        Me.dataGridViewHours.Size = New System.Drawing.Size(268, 259)
        Me.dataGridViewHours.TabIndex = 12
        '
        'colHour
        '
        Me.colHour.HeaderText = "Hour"
        Me.colHour.Name = "colHour"
        Me.colHour.ReadOnly = True
        '
        'colSelect
        '
        Me.colSelect.HeaderText = "Select"
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmHourly2Sequencer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 375)
        Me.Controls.Add(Me.lblSequencerGuidelines)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dataGridViewHours)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmHourly2Sequencer"
        Me.Text = "Sequencer for hourly2"
        CType(Me.dataGridViewHours, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblSequencerGuidelines As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents dataGridViewHours As DataGridView
    Friend WithEvents colHour As DataGridViewTextBoxColumn
    Friend WithEvents colSelect As DataGridViewCheckBoxColumn
End Class
