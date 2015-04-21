<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStation))
        Dim StationIdLabel As System.Windows.Forms.Label
        Dim StationNameLabel As System.Windows.Forms.Label
        Me.Mysql_climsoft_db_v4StationDataSet = New WindowsApplication1.mysql_climsoft_db_v4StationDataSet()
        Me.StationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StationTableAdapter = New WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.stationTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.TableAdapterManager()
        Me.StationBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.StationBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.StationIdTextBox = New System.Windows.Forms.TextBox()
        Me.StationNameTextBox = New System.Windows.Forms.TextBox()
        StationIdLabel = New System.Windows.Forms.Label()
        StationNameLabel = New System.Windows.Forms.Label()
        CType(Me.Mysql_climsoft_db_v4StationDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StationBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mysql_climsoft_db_v4StationDataSet
        '
        Me.Mysql_climsoft_db_v4StationDataSet.DataSetName = "mysql_climsoft_db_v4StationDataSet"
        Me.Mysql_climsoft_db_v4StationDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StationBindingSource
        '
        Me.StationBindingSource.DataMember = "station"
        Me.StationBindingSource.DataSource = Me.Mysql_climsoft_db_v4StationDataSet
        '
        'StationTableAdapter
        '
        Me.StationTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.stationTableAdapter = Me.StationTableAdapter
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'StationBindingNavigator
        '
        Me.StationBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.StationBindingNavigator.BindingSource = Me.StationBindingSource
        Me.StationBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.StationBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.StationBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.StationBindingNavigatorSaveItem})
        Me.StationBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.StationBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.StationBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.StationBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.StationBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.StationBindingNavigator.Name = "StationBindingNavigator"
        Me.StationBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.StationBindingNavigator.Size = New System.Drawing.Size(388, 25)
        Me.StationBindingNavigator.TabIndex = 0
        Me.StationBindingNavigator.Text = "BindingNavigator1"
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
        'StationBindingNavigatorSaveItem
        '
        Me.StationBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StationBindingNavigatorSaveItem.Image = CType(resources.GetObject("StationBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.StationBindingNavigatorSaveItem.Name = "StationBindingNavigatorSaveItem"
        Me.StationBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.StationBindingNavigatorSaveItem.Text = "Save Data"
        '
        'StationIdLabel
        '
        StationIdLabel.AutoSize = True
        StationIdLabel.Location = New System.Drawing.Point(116, 57)
        StationIdLabel.Name = "StationIdLabel"
        StationIdLabel.Size = New System.Drawing.Size(53, 13)
        StationIdLabel.TabIndex = 1
        StationIdLabel.Text = "station Id:"
        '
        'StationIdTextBox
        '
        Me.StationIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "stationId", True))
        Me.StationIdTextBox.Location = New System.Drawing.Point(175, 54)
        Me.StationIdTextBox.Name = "StationIdTextBox"
        Me.StationIdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationIdTextBox.TabIndex = 2
        '
        'StationNameLabel
        '
        StationNameLabel.AutoSize = True
        StationNameLabel.Location = New System.Drawing.Point(97, 103)
        StationNameLabel.Name = "StationNameLabel"
        StationNameLabel.Size = New System.Drawing.Size(72, 13)
        StationNameLabel.TabIndex = 3
        StationNameLabel.Text = "station Name:"
        '
        'StationNameTextBox
        '
        Me.StationNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "stationName", True))
        Me.StationNameTextBox.Location = New System.Drawing.Point(175, 100)
        Me.StationNameTextBox.Name = "StationNameTextBox"
        Me.StationNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationNameTextBox.TabIndex = 4
        '
        'frmStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 262)
        Me.Controls.Add(StationNameLabel)
        Me.Controls.Add(Me.StationNameTextBox)
        Me.Controls.Add(StationIdLabel)
        Me.Controls.Add(Me.StationIdTextBox)
        Me.Controls.Add(Me.StationBindingNavigator)
        Me.Name = "frmStation"
        Me.Text = "frmStation"
        CType(Me.Mysql_climsoft_db_v4StationDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StationBindingNavigator.ResumeLayout(False)
        Me.StationBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mysql_climsoft_db_v4StationDataSet As WindowsApplication1.mysql_climsoft_db_v4StationDataSet
    Friend WithEvents StationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StationTableAdapter As WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.stationTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.mysql_climsoft_db_v4StationDataSetTableAdapters.TableAdapterManager
    Friend WithEvents StationBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents StationBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents StationIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StationNameTextBox As System.Windows.Forms.TextBox
End Class
