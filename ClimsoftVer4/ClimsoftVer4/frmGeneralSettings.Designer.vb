<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGeneralSettings
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
        Me.txtKeyName = New System.Windows.Forms.TextBox()
        Me.txtKeyValue = New System.Windows.Forms.TextBox()
        Me.txtKeyDescription = New System.Windows.Forms.TextBox()
        Me.lblKeyName = New System.Windows.Forms.Label()
        Me.lblKeyValue = New System.Windows.Forms.Label()
        Me.lblKeyDescription = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.lblGuidelines = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtKeyName
        '
        Me.txtKeyName.Enabled = False
        Me.txtKeyName.Location = New System.Drawing.Point(134, 65)
        Me.txtKeyName.Name = "txtKeyName"
        Me.txtKeyName.Size = New System.Drawing.Size(80, 20)
        Me.txtKeyName.TabIndex = 0
        '
        'txtKeyValue
        '
        Me.txtKeyValue.Location = New System.Drawing.Point(317, 65)
        Me.txtKeyValue.Name = "txtKeyValue"
        Me.txtKeyValue.Size = New System.Drawing.Size(357, 20)
        Me.txtKeyValue.TabIndex = 1
        '
        'txtKeyDescription
        '
        Me.txtKeyDescription.Enabled = False
        Me.txtKeyDescription.Location = New System.Drawing.Point(134, 115)
        Me.txtKeyDescription.Name = "txtKeyDescription"
        Me.txtKeyDescription.Size = New System.Drawing.Size(540, 20)
        Me.txtKeyDescription.TabIndex = 2
        '
        'lblKeyName
        '
        Me.lblKeyName.AutoSize = True
        Me.lblKeyName.Location = New System.Drawing.Point(24, 68)
        Me.lblKeyName.Name = "lblKeyName"
        Me.lblKeyName.Size = New System.Drawing.Size(71, 13)
        Me.lblKeyName.TabIndex = 3
        Me.lblKeyName.Text = "Setting Name"
        '
        'lblKeyValue
        '
        Me.lblKeyValue.AutoSize = True
        Me.lblKeyValue.Location = New System.Drawing.Point(228, 68)
        Me.lblKeyValue.Name = "lblKeyValue"
        Me.lblKeyValue.Size = New System.Drawing.Size(70, 13)
        Me.lblKeyValue.TabIndex = 4
        Me.lblKeyValue.Text = "Setting Value"
        '
        'lblKeyDescription
        '
        Me.lblKeyDescription.AutoSize = True
        Me.lblKeyDescription.Location = New System.Drawing.Point(25, 122)
        Me.lblKeyDescription.Name = "lblKeyDescription"
        Me.lblKeyDescription.Size = New System.Drawing.Size(96, 13)
        Me.lblKeyDescription.TabIndex = 5
        Me.lblKeyDescription.Text = "Setting Description"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(599, 224)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 317
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(356, 224)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 315
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(113, 224)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 311
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(275, 224)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 314
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Location = New System.Drawing.Point(32, 224)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 312
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(194, 224)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 313
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(221, 179)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 322
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(174, 179)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 321
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(464, 179)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 320
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(273, 181)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 319
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(420, 179)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 318
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(518, 224)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 316
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(437, 224)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 662
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'lblGuidelines
        '
        Me.lblGuidelines.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuidelines.ForeColor = System.Drawing.Color.Red
        Me.lblGuidelines.Location = New System.Drawing.Point(24, 9)
        Me.lblGuidelines.Name = "lblGuidelines"
        Me.lblGuidelines.Size = New System.Drawing.Size(619, 34)
        Me.lblGuidelines.TabIndex = 663
        Me.lblGuidelines.Text = "When updating folder location for QC output, you must use forward slash '/'. For " &
    "all other folder locations use backslash '\'."
        '
        'frmGeneralSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 270)
        Me.Controls.Add(Me.lblGuidelines)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnMovePrevious)
        Me.Controls.Add(Me.btnMoveFirst)
        Me.Controls.Add(Me.btnMoveLast)
        Me.Controls.Add(Me.recNumberTextBox)
        Me.Controls.Add(Me.btnMoveNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblKeyDescription)
        Me.Controls.Add(Me.lblKeyValue)
        Me.Controls.Add(Me.lblKeyName)
        Me.Controls.Add(Me.txtKeyDescription)
        Me.Controls.Add(Me.txtKeyValue)
        Me.Controls.Add(Me.txtKeyName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeneralSettings"
        Me.Text = "General Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtKeyName As System.Windows.Forms.TextBox
    Friend WithEvents txtKeyValue As System.Windows.Forms.TextBox
    Friend WithEvents txtKeyDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblKeyName As System.Windows.Forms.Label
    Friend WithEvents lblKeyValue As System.Windows.Forms.Label
    Friend WithEvents lblKeyDescription As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnCommit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents recNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents lblGuidelines As System.Windows.Forms.Label
End Class
