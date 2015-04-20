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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formElement))
        Dim CodeLabel As System.Windows.Forms.Label
        Dim AbbreviationLabel As System.Windows.Forms.Label
        Dim ElementNameLabel As System.Windows.Forms.Label
        Dim DescriptionLabel As System.Windows.Forms.Label
        Dim ElementScaleLabel As System.Windows.Forms.Label
        Dim UpperLimitLabel As System.Windows.Forms.Label
        Dim LowerLimitLabel As System.Windows.Forms.Label
        Dim UnitsLabel As System.Windows.Forms.Label
        Dim ElementtypeLabel As System.Windows.Forms.Label
        Me.Mysql_climsoft_db_v4DataSet2 = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet2()
        Me.ObselementBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ObselementTableAdapter = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet2TableAdapters.obselementTableAdapter()
        Me.TableAdapterManager = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet2TableAdapters.TableAdapterManager()
        Me.ObselementBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.ObselementBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.AbbreviationTextBox = New System.Windows.Forms.TextBox()
        Me.ElementNameTextBox = New System.Windows.Forms.TextBox()
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox()
        Me.ElementScaleTextBox = New System.Windows.Forms.TextBox()
        Me.UpperLimitTextBox = New System.Windows.Forms.TextBox()
        Me.LowerLimitTextBox = New System.Windows.Forms.TextBox()
        Me.UnitsTextBox = New System.Windows.Forms.TextBox()
        Me.ElementtypeTextBox = New System.Windows.Forms.TextBox()
        CodeLabel = New System.Windows.Forms.Label()
        AbbreviationLabel = New System.Windows.Forms.Label()
        ElementNameLabel = New System.Windows.Forms.Label()
        DescriptionLabel = New System.Windows.Forms.Label()
        ElementScaleLabel = New System.Windows.Forms.Label()
        UpperLimitLabel = New System.Windows.Forms.Label()
        LowerLimitLabel = New System.Windows.Forms.Label()
        UnitsLabel = New System.Windows.Forms.Label()
        ElementtypeLabel = New System.Windows.Forms.Label()
        CType(Me.Mysql_climsoft_db_v4DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObselementBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObselementBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ObselementBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mysql_climsoft_db_v4DataSet2
        '
        Me.Mysql_climsoft_db_v4DataSet2.DataSetName = "mysql_climsoft_db_v4DataSet2"
        Me.Mysql_climsoft_db_v4DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ObselementBindingSource
        '
        Me.ObselementBindingSource.DataMember = "obselement"
        Me.ObselementBindingSource.DataSource = Me.Mysql_climsoft_db_v4DataSet2
        '
        'ObselementTableAdapter
        '
        Me.ObselementTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.obselementTableAdapter = Me.ObselementTableAdapter
        Me.TableAdapterManager.UpdateOrder = ClimsoftVersion4.mysql_climsoft_db_v4DataSet2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ObselementBindingNavigator
        '
        Me.ObselementBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ObselementBindingNavigator.BindingSource = Me.ObselementBindingSource
        Me.ObselementBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ObselementBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ObselementBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ObselementBindingNavigatorSaveItem})
        Me.ObselementBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ObselementBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ObselementBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ObselementBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ObselementBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ObselementBindingNavigator.Name = "ObselementBindingNavigator"
        Me.ObselementBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ObselementBindingNavigator.Size = New System.Drawing.Size(480, 25)
        Me.ObselementBindingNavigator.TabIndex = 0
        Me.ObselementBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 15)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'ObselementBindingNavigatorSaveItem
        '
        Me.ObselementBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ObselementBindingNavigatorSaveItem.Image = CType(resources.GetObject("ObselementBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ObselementBindingNavigatorSaveItem.Name = "ObselementBindingNavigatorSaveItem"
        Me.ObselementBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.ObselementBindingNavigatorSaveItem.Text = "Save Data"
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
        'CodeTextBox
        '
        Me.CodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "code", True))
        Me.CodeTextBox.Location = New System.Drawing.Point(130, 53)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeTextBox.TabIndex = 2
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
        'AbbreviationTextBox
        '
        Me.AbbreviationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "abbreviation", True))
        Me.AbbreviationTextBox.Location = New System.Drawing.Point(130, 90)
        Me.AbbreviationTextBox.Name = "AbbreviationTextBox"
        Me.AbbreviationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AbbreviationTextBox.TabIndex = 4
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
        'ElementNameTextBox
        '
        Me.ElementNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "elementName", True))
        Me.ElementNameTextBox.Location = New System.Drawing.Point(130, 128)
        Me.ElementNameTextBox.Name = "ElementNameTextBox"
        Me.ElementNameTextBox.Size = New System.Drawing.Size(314, 20)
        Me.ElementNameTextBox.TabIndex = 6
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
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(130, 168)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.Size = New System.Drawing.Size(314, 20)
        Me.DescriptionTextBox.TabIndex = 8
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
        'ElementScaleTextBox
        '
        Me.ElementScaleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "elementScale", True))
        Me.ElementScaleTextBox.Location = New System.Drawing.Point(130, 208)
        Me.ElementScaleTextBox.Name = "ElementScaleTextBox"
        Me.ElementScaleTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementScaleTextBox.TabIndex = 10
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
        'UpperLimitTextBox
        '
        Me.UpperLimitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "upperLimit", True))
        Me.UpperLimitTextBox.Location = New System.Drawing.Point(130, 248)
        Me.UpperLimitTextBox.Name = "UpperLimitTextBox"
        Me.UpperLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UpperLimitTextBox.TabIndex = 12
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
        'LowerLimitTextBox
        '
        Me.LowerLimitTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "lowerLimit", True))
        Me.LowerLimitTextBox.Location = New System.Drawing.Point(130, 293)
        Me.LowerLimitTextBox.Name = "LowerLimitTextBox"
        Me.LowerLimitTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LowerLimitTextBox.TabIndex = 14
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
        'UnitsTextBox
        '
        Me.UnitsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "units", True))
        Me.UnitsTextBox.Location = New System.Drawing.Point(130, 330)
        Me.UnitsTextBox.Name = "UnitsTextBox"
        Me.UnitsTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UnitsTextBox.TabIndex = 16
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
        'ElementtypeTextBox
        '
        Me.ElementtypeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ObselementBindingSource, "elementtype", True))
        Me.ElementtypeTextBox.Location = New System.Drawing.Point(130, 368)
        Me.ElementtypeTextBox.Name = "ElementtypeTextBox"
        Me.ElementtypeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElementtypeTextBox.TabIndex = 18
        '
        'formElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 429)
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
        Me.Controls.Add(Me.ObselementBindingNavigator)
        Me.Name = "formElement"
        Me.Text = "formElement"
        CType(Me.Mysql_climsoft_db_v4DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObselementBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObselementBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ObselementBindingNavigator.ResumeLayout(False)
        Me.ObselementBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mysql_climsoft_db_v4DataSet2 As ClimsoftVersion4.mysql_climsoft_db_v4DataSet2
    Friend WithEvents ObselementBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ObselementTableAdapter As ClimsoftVersion4.mysql_climsoft_db_v4DataSet2TableAdapters.obselementTableAdapter
    Friend WithEvents TableAdapterManager As ClimsoftVersion4.mysql_climsoft_db_v4DataSet2TableAdapters.TableAdapterManager
    Friend WithEvents ObselementBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ObselementBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AbbreviationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementScaleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UpperLimitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LowerLimitTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UnitsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElementtypeTextBox As System.Windows.Forms.TextBox
End Class
