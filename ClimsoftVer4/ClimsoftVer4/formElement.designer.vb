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
        CodeLabel.Location = New System.Drawing.Point(47, 56)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Size = New System.Drawing.Size(62, 13)
        CodeLabel.TabIndex = 1
        CodeLabel.Text = "Element ID:"
        '
        'AbbreviationLabel
        '
        AbbreviationLabel.AutoSize = True
        AbbreviationLabel.Location = New System.Drawing.Point(47, 93)
        AbbreviationLabel.Name = "AbbreviationLabel"
        AbbreviationLabel.Size = New System.Drawing.Size(69, 13)
        AbbreviationLabel.TabIndex = 3
        AbbreviationLabel.Text = "Abbreviation:"
        '
        'ElementNameLabel
        '
        ElementNameLabel.AutoSize = True
        ElementNameLabel.Location = New System.Drawing.Point(46, 131)
        ElementNameLabel.Name = "ElementNameLabel"
        ElementNameLabel.Size = New System.Drawing.Size(79, 13)
        ElementNameLabel.TabIndex = 5
        ElementNameLabel.Text = "Element Name:"
        '
        'DescriptionLabel
        '
        DescriptionLabel.AutoSize = True
        DescriptionLabel.Location = New System.Drawing.Point(47, 171)
        DescriptionLabel.Name = "DescriptionLabel"
        DescriptionLabel.Size = New System.Drawing.Size(63, 13)
        DescriptionLabel.TabIndex = 7
        DescriptionLabel.Text = "Description:"
        '
        'ElementScaleLabel
        '
        ElementScaleLabel.AutoSize = True
        ElementScaleLabel.Location = New System.Drawing.Point(47, 211)
        ElementScaleLabel.Name = "ElementScaleLabel"
        ElementScaleLabel.Size = New System.Drawing.Size(78, 13)
        ElementScaleLabel.TabIndex = 9
        ElementScaleLabel.Text = "Element Scale:"
        '
        'UpperLimitLabel
        '
        UpperLimitLabel.AutoSize = True
        UpperLimitLabel.Location = New System.Drawing.Point(46, 251)
        UpperLimitLabel.Name = "UpperLimitLabel"
        UpperLimitLabel.Size = New System.Drawing.Size(63, 13)
        UpperLimitLabel.TabIndex = 11
        UpperLimitLabel.Text = "Upper Limit:"
        '
        'LowerLimitLabel
        '
        LowerLimitLabel.AutoSize = True
        LowerLimitLabel.Location = New System.Drawing.Point(46, 296)
        LowerLimitLabel.Name = "LowerLimitLabel"
        LowerLimitLabel.Size = New System.Drawing.Size(63, 13)
        LowerLimitLabel.TabIndex = 13
        LowerLimitLabel.Text = "Lower Limit:"
        '
        'UnitsLabel
        '
        UnitsLabel.AutoSize = True
        UnitsLabel.Location = New System.Drawing.Point(47, 333)
        UnitsLabel.Name = "UnitsLabel"
        UnitsLabel.Size = New System.Drawing.Size(34, 13)
        UnitsLabel.TabIndex = 15
        UnitsLabel.Text = "Units:"
        '
        'ElementtypeLabel
        '
        ElementtypeLabel.AutoSize = True
        ElementtypeLabel.Location = New System.Drawing.Point(47, 371)
        ElementtypeLabel.Name = "ElementtypeLabel"
        ElementtypeLabel.Size = New System.Drawing.Size(75, 13)
        ElementtypeLabel.TabIndex = 17
        ElementtypeLabel.Text = "Element Type:"
        '
        'CodeTextBox
        '
        Me.CodeTextBox.Location = New System.Drawing.Point(130, 53)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeTextBox.TabIndex = 2
        '
        'AbbreviationTextBox
        '
        Me.AbbreviationTextBox.Location = New System.Drawing.Point(130, 90)
        Me.AbbreviationTextBox.Name = "AbbreviationTextBox"
        Me.AbbreviationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AbbreviationTextBox.TabIndex = 4
        '
        'ElementNameTextBox
        '
        Me.ElementNameTextBox.Location = New System.Drawing.Point(130, 128)
        Me.ElementNameTextBox.Name = "ElementNameTextBox"
        Me.ElementNameTextBox.Size = New System.Drawing.Size(314, 20)
        Me.ElementNameTextBox.TabIndex = 6
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.Location = New System.Drawing.Point(130, 168)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(314, 20)
        Me.DescriptionTextBox.TabIndex = 8
        '
        'ElementScaleTextBox
        '
        Me.ElementScaleTextBox.Location = New System.Drawing.Point(130, 208)
        Me.ElementScaleTextBox.Name = "ElementScaleTextBox"
        Me.ElementScaleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementScaleTextBox.TabIndex = 10
        '
        'UpperLimitTextBox
        '
        Me.UpperLimitTextBox.Location = New System.Drawing.Point(130, 248)
        Me.UpperLimitTextBox.Name = "UpperLimitTextBox"
        Me.UpperLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UpperLimitTextBox.TabIndex = 12
        '
        'LowerLimitTextBox
        '
        Me.LowerLimitTextBox.Location = New System.Drawing.Point(130, 293)
        Me.LowerLimitTextBox.Name = "LowerLimitTextBox"
        Me.LowerLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LowerLimitTextBox.TabIndex = 14
        '
        'UnitsTextBox
        '
        Me.UnitsTextBox.Location = New System.Drawing.Point(130, 330)
        Me.UnitsTextBox.Name = "UnitsTextBox"
        Me.UnitsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UnitsTextBox.TabIndex = 16
        '
        'ElementtypeTextBox
        '
        Me.ElementtypeTextBox.Location = New System.Drawing.Point(130, 368)
        Me.ElementtypeTextBox.Name = "ElementtypeTextBox"
        Me.ElementtypeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementtypeTextBox.TabIndex = 18
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(359, 420)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 19
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'formElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 455)
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
        Me.Text = "formElement"
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
End Class
