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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formElement))
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
        resources.ApplyResources(CodeLabel, "CodeLabel")
        CodeLabel.Name = "CodeLabel"
        '
        'AbbreviationLabel
        '
        resources.ApplyResources(AbbreviationLabel, "AbbreviationLabel")
        AbbreviationLabel.Name = "AbbreviationLabel"
        '
        'ElementNameLabel
        '
        resources.ApplyResources(ElementNameLabel, "ElementNameLabel")
        ElementNameLabel.Name = "ElementNameLabel"
        '
        'DescriptionLabel
        '
        resources.ApplyResources(DescriptionLabel, "DescriptionLabel")
        DescriptionLabel.Name = "DescriptionLabel"
        '
        'ElementScaleLabel
        '
        resources.ApplyResources(ElementScaleLabel, "ElementScaleLabel")
        ElementScaleLabel.Name = "ElementScaleLabel"
        '
        'UpperLimitLabel
        '
        resources.ApplyResources(UpperLimitLabel, "UpperLimitLabel")
        UpperLimitLabel.Name = "UpperLimitLabel"
        '
        'LowerLimitLabel
        '
        resources.ApplyResources(LowerLimitLabel, "LowerLimitLabel")
        LowerLimitLabel.Name = "LowerLimitLabel"
        '
        'UnitsLabel
        '
        resources.ApplyResources(UnitsLabel, "UnitsLabel")
        UnitsLabel.Name = "UnitsLabel"
        '
        'ElementtypeLabel
        '
        resources.ApplyResources(ElementtypeLabel, "ElementtypeLabel")
        ElementtypeLabel.Name = "ElementtypeLabel"
        '
        'CodeTextBox
        '
        resources.ApplyResources(Me.CodeTextBox, "CodeTextBox")
        Me.CodeTextBox.Name = "CodeTextBox"
        '
        'AbbreviationTextBox
        '
        resources.ApplyResources(Me.AbbreviationTextBox, "AbbreviationTextBox")
        Me.AbbreviationTextBox.Name = "AbbreviationTextBox"
        '
        'ElementNameTextBox
        '
        resources.ApplyResources(Me.ElementNameTextBox, "ElementNameTextBox")
        Me.ElementNameTextBox.Name = "ElementNameTextBox"
        '
        'DescriptionTextBox
        '
        resources.ApplyResources(Me.DescriptionTextBox, "DescriptionTextBox")
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        '
        'ElementScaleTextBox
        '
        resources.ApplyResources(Me.ElementScaleTextBox, "ElementScaleTextBox")
        Me.ElementScaleTextBox.Name = "ElementScaleTextBox"
        '
        'UpperLimitTextBox
        '
        resources.ApplyResources(Me.UpperLimitTextBox, "UpperLimitTextBox")
        Me.UpperLimitTextBox.Name = "UpperLimitTextBox"
        '
        'LowerLimitTextBox
        '
        resources.ApplyResources(Me.LowerLimitTextBox, "LowerLimitTextBox")
        Me.LowerLimitTextBox.Name = "LowerLimitTextBox"
        '
        'UnitsTextBox
        '
        resources.ApplyResources(Me.UnitsTextBox, "UnitsTextBox")
        Me.UnitsTextBox.Name = "UnitsTextBox"
        '
        'ElementtypeTextBox
        '
        resources.ApplyResources(Me.ElementtypeTextBox, "ElementtypeTextBox")
        Me.ElementtypeTextBox.Name = "ElementtypeTextBox"
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Name = "btnClear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        resources.ApplyResources(Me.btnCommit, "btnCommit")
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        resources.ApplyResources(Me.btnAddNew, "btnAddNew")
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        resources.ApplyResources(Me.btnUpdate, "btnUpdate")
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        resources.ApplyResources(Me.btnMovePrevious, "btnMovePrevious")
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        resources.ApplyResources(Me.btnMoveFirst, "btnMoveFirst")
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        resources.ApplyResources(Me.btnMoveLast, "btnMoveLast")
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        resources.ApplyResources(Me.recNumberTextBox, "recNumberTextBox")
        Me.recNumberTextBox.Name = "recNumberTextBox"
        '
        'btnMoveNext
        '
        resources.ApplyResources(Me.btnMoveNext, "btnMoveNext")
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        resources.ApplyResources(Me.btnHelp, "btnHelp")
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'formElement
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
