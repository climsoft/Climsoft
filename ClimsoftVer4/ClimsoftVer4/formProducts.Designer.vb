<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProducts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProducts))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenListToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblProducts = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbProductsCategory = New System.Windows.Forms.ComboBox()
        Me.lblProductsCategory = New System.Windows.Forms.Label()
        Me.lstvProducts = New System.Windows.Forms.ListView()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenListToolStripMenuItem, Me.ToolStripMenuItem2, Me.OpenListToolStripMenuItem1, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        resources.ApplyResources(Me.FileToolStripMenuItem, "FileToolStripMenuItem")
        '
        'OpenListToolStripMenuItem
        '
        Me.OpenListToolStripMenuItem.Name = "OpenListToolStripMenuItem"
        Me.OpenListToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.OpenListToolStripMenuItem.Text = "Save Specifications"
        Me.OpenListToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(179, 22)
        Me.ToolStripMenuItem2.Text = "Open Specifications"
        Me.ToolStripMenuItem2.Visible = False
        '
        'OpenListToolStripMenuItem1
        '
        Me.OpenListToolStripMenuItem1.Name = "OpenListToolStripMenuItem1"
        Me.OpenListToolStripMenuItem1.Size = New System.Drawing.Size(179, 22)
        Me.OpenListToolStripMenuItem1.Text = "Add New Product"
        Me.OpenListToolStripMenuItem1.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        Me.EditToolStripMenuItem.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'lblProducts
        '
        resources.ApplyResources(Me.lblProducts, "lblProducts")
        Me.lblProducts.Name = "lblProducts"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'ToolStrip2
        '
        resources.ApplyResources(Me.ToolStrip2, "ToolStrip2")
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1})
        Me.ToolStrip2.Name = "ToolStrip2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbProductsCategory)
        Me.Panel1.Controls.Add(Me.lblProductsCategory)
        Me.Panel1.Controls.Add(Me.lstvProducts)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'cmbProductsCategory
        '
        Me.cmbProductsCategory.FormattingEnabled = True
        resources.ApplyResources(Me.cmbProductsCategory, "cmbProductsCategory")
        Me.cmbProductsCategory.Name = "cmbProductsCategory"
        '
        'lblProductsCategory
        '
        resources.ApplyResources(Me.lblProductsCategory, "lblProductsCategory")
        Me.lblProductsCategory.Name = "lblProductsCategory"
        '
        'lstvProducts
        '
        Me.lstvProducts.AllowColumnReorder = True
        Me.lstvProducts.AllowDrop = True
        Me.lstvProducts.FullRowSelect = True
        Me.lstvProducts.GridLines = True
        Me.lstvProducts.HideSelection = False
        Me.lstvProducts.HoverSelection = True
        Me.lstvProducts.LabelEdit = True
        resources.ApplyResources(Me.lstvProducts, "lstvProducts")
        Me.lstvProducts.Name = "lstvProducts"
        Me.lstvProducts.UseCompatibleStateImageBehavior = False
        Me.lstvProducts.View = System.Windows.Forms.View.Details
        '
        'frmProducts
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.lblProducts)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmProducts"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenListToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblProducts As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents lstvProducts As System.Windows.Forms.ListView
    Friend WithEvents lblProductsCategory As System.Windows.Forms.Label
    Friend WithEvents cmbProductsCategory As System.Windows.Forms.ComboBox
End Class
