<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formElement
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
        Dim CodeLabel As System.Windows.Forms.Label
        Dim AbbreviationLabel As System.Windows.Forms.Label
        Dim ElementNameLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim ElementScaleLabel As System.Windows.Forms.Label
        Dim UpperLimitLabel As System.Windows.Forms.Label
        Dim LowerLimitLabel As System.Windows.Forms.Label
        Dim UnitsLabel As System.Windows.Forms.Label
        Dim ElementtypeLabel As System.Windows.Forms.Label
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.AbbreviationTextBox = New System.Windows.Forms.TextBox()
        Me.ElementNameTextBox = New System.Windows.Forms.TextBox()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ElementScaleTextBox = New System.Windows.Forms.TextBox()
        Me.UpperLimitTextBox = New System.Windows.Forms.TextBox()
        Me.LowerLimitTextBox = New System.Windows.Forms.TextBox()
        Me.UnitsTextBox = New System.Windows.Forms.TextBox()
        Me.ElementtypeTextBox = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
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
        Me.btnHelp = New System.Windows.Forms.Button()
        CodeLabel = New System.Windows.Forms.Label()
        AbbreviationLabel = New System.Windows.Forms.Label()
        ElementNameLabel = New System.Windows.Forms.Label()
        DescriptionLabel = New System.Windows.Forms.Label()
        ElementScaleLabel = New System.Windows.Forms.Label()
        UpperLimitLabel = New System.Windows.Forms.Label()
        LowerLimitLabel = New System.Windows.Forms.Label()
        UnitsLabel = New System.Windows.Forms.Label()
        ElementtypeLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CodeLabel
        '
        CodeLabel.AutoSize = True
        CodeLabel.Location = New System.Drawing.Point(83, 40)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Size = New System.Drawing.Size(62, 13)
        CodeLabel.TabIndex = 1
        CodeLabel.Text = "Element ID:"
        '
        'AbbreviationLabel
        '
        AbbreviationLabel.AutoSize = True
        AbbreviationLabel.Location = New System.Drawing.Point(297, 43)
        AbbreviationLabel.Name = "AbbreviationLabel"
        AbbreviationLabel.Size = New System.Drawing.Size(69, 13)
        AbbreviationLabel.TabIndex = 3
        AbbreviationLabel.Text = "Abbreviation:"
        '
        'ElementNameLabel
        '
        ElementNameLabel.AutoSize = True
        ElementNameLabel.Location = New System.Drawing.Point(82, 81)
        ElementNameLabel.Name = "ElementNameLabel"
        ElementNameLabel.Size = New System.Drawing.Size(79, 13)
        ElementNameLabel.TabIndex = 5
        ElementNameLabel.Text = "Element Name:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(83, 121)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(63, 13)
        DescriptionLabel.TabIndex = 7
        DescriptionLabel.Text = "Description:"
        '
        'ElementScaleLabel
        '
        ElementScaleLabel.AutoSize = True
        ElementScaleLabel.Location = New System.Drawing.Point(297, 205)
        ElementScaleLabel.Name = "ElementScaleLabel"
        ElementScaleLabel.Size = New System.Drawing.Size(78, 13)
        ElementScaleLabel.TabIndex = 9
        ElementScaleLabel.Text = "Element Scale:"
        '
        'UpperLimitLabel
        '
        UpperLimitLabel.AutoSize = True
        UpperLimitLabel.Location = New System.Drawing.Point(296, 161)
        UpperLimitLabel.Name = "UpperLimitLabel"
        UpperLimitLabel.Size = New System.Drawing.Size(63, 13)
        UpperLimitLabel.TabIndex = 11
        UpperLimitLabel.Text = "Upper Limit:"
        '
        'LowerLimitLabel
        '
        LowerLimitLabel.AutoSize = True
        LowerLimitLabel.Location = New System.Drawing.Point(82, 161)
        LowerLimitLabel.Name = "LowerLimitLabel"
        LowerLimitLabel.Size = New System.Drawing.Size(63, 13)
        LowerLimitLabel.TabIndex = 13
        LowerLimitLabel.Text = "Lower Limit:"
        '
        'UnitsLabel
        '
        UnitsLabel.AutoSize = True
        UnitsLabel.Location = New System.Drawing.Point(83, 205)
        UnitsLabel.Name = "UnitsLabel"
        UnitsLabel.Size = New System.Drawing.Size(34, 13)
        UnitsLabel.TabIndex = 15
        UnitsLabel.Text = "Units:"
        '
        'ElementtypeLabel
        '
        ElementtypeLabel.AutoSize = True
        ElementtypeLabel.Location = New System.Drawing.Point(83, 241)
        ElementtypeLabel.Name = "ElementtypeLabel"
        ElementtypeLabel.Size = New System.Drawing.Size(75, 13)
        ElementtypeLabel.TabIndex = 17
        ElementtypeLabel.Text = "Element Type:"
        '
        'CodeTextBox
        '
        Me.CodeTextBox.Location = New System.Drawing.Point(166, 37)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeTextBox.TabIndex = 2
        '
        'AbbreviationTextBox
        '
        Me.AbbreviationTextBox.Location = New System.Drawing.Point(380, 40)
        Me.AbbreviationTextBox.Name = "AbbreviationTextBox"
        Me.AbbreviationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AbbreviationTextBox.TabIndex = 4
        '
        'ElementNameTextBox
        '
        Me.ElementNameTextBox.Location = New System.Drawing.Point(166, 78)
        Me.ElementNameTextBox.Name = "ElementNameTextBox"
        Me.ElementNameTextBox.Size = New System.Drawing.Size(314, 20)
        Me.ElementNameTextBox.TabIndex = 6
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Location = New System.Drawing.Point(166, 118)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(314, 20)
        Me.DescriptionTextBox.TabIndex = 8
        '
        'ElementScaleTextBox
        '
        Me.ElementScaleTextBox.Location = New System.Drawing.Point(380, 202)
        Me.ElementScaleTextBox.Name = "ElementScaleTextBox"
        Me.ElementScaleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementScaleTextBox.TabIndex = 10
        '
        'UpperLimitTextBox
        '
        Me.UpperLimitTextBox.Location = New System.Drawing.Point(380, 158)
        Me.UpperLimitTextBox.Name = "UpperLimitTextBox"
        Me.UpperLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UpperLimitTextBox.TabIndex = 12
        '
        'LowerLimitTextBox
        '
        Me.LowerLimitTextBox.Location = New System.Drawing.Point(166, 158)
        Me.LowerLimitTextBox.Name = "LowerLimitTextBox"
        Me.LowerLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LowerLimitTextBox.TabIndex = 14
        '
        'UnitsTextBox
        '
        Me.UnitsTextBox.Location = New System.Drawing.Point(166, 202)
        Me.UnitsTextBox.Name = "UnitsTextBox"
        Me.UnitsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UnitsTextBox.TabIndex = 16
        '
        'ElementtypeTextBox
        '
        Me.ElementtypeTextBox.Location = New System.Drawing.Point(166, 238)
        Me.ElementtypeTextBox.Name = "ElementtypeTextBox"
        Me.ElementtypeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementtypeTextBox.TabIndex = 18
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(438, 319)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(357, 319)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 53
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(110, 319)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 52
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(272, 319)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 51
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(29, 319)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 50
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(191, 319)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 49
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(195, 281)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 48
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(148, 281)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 47
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(438, 281)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(35, 23)
        Me.btnMoveLast.TabIndex = 46
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(247, 283)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 45
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(394, 281)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 44
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(519, 319)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 54
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'formElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 363)
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
        Me.Controls.Add(ElementtypeLabel)
        Me.Controls.Add(Me.ElementtypeTextBox)
        Me.Controls.Add(UnitsLabel)
        Me.Controls.Add(Me.UnitsTextBox)
        Me.Controls.Add(LowerLimitLabel)
        Me.Controls.Add(Me.LowerLimitTextBox)
        Me.Controls.Add(UpperLimitLabel)
        Me.Controls.Add(Me.UpperLimitTextBox)
        Me.Controls.Add(ElementScaleLabel)
        Me.Controls.Add(Me.ElementScaleTextBox)
        Me.Controls.Add(DescriptionLabel)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(ElementNameLabel)
        Me.Controls.Add(Me.ElementNameTextBox)
        Me.Controls.Add(AbbreviationLabel)
        Me.Controls.Add(Me.AbbreviationTextBox)
        Me.Controls.Add(CodeLabel)
        Me.Controls.Add(Me.CodeTextBox)
        Me.MaximizeBox = False
        Me.Name = "formElement"
        Me.Text = "Element Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AbbreviationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementScaleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UpperLimitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LowerLimitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementtypeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
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
    Friend WithEvents btnHelp As System.Windows.Forms.Button
End Class
