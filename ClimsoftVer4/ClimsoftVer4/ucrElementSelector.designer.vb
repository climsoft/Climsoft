<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrElementSelector
    Inherits ClimsoftVer4.ucrDataLinkCombobox

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.cmsElement = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsElementsNames = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsElementIDs = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsElemntIDName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsElementSortByID = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsElementSortyByName = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsElementsFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsElement.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsElement
        '
        Me.cmsElement.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsElementsNames, Me.cmsElementIDs, Me.cmsElemntIDName, Me.ToolStripSeparator2, Me.cmsElementSortByID, Me.cmsElementSortyByName, Me.cmsElementsFilter, Me.ToolStripSeparator1})
        Me.cmsElement.Name = "cmsStation"
        Me.cmsElement.Size = New System.Drawing.Size(193, 148)
        '
        'cmsElementsNames
        '
        Me.cmsElementsNames.Name = "cmsElementsNames"
        Me.cmsElementsNames.Size = New System.Drawing.Size(192, 22)
        Me.cmsElementsNames.Text = "Element Names"
        '
        'cmsElementIDs
        '
        Me.cmsElementIDs.Name = "cmsElementIDs"
        Me.cmsElementIDs.Size = New System.Drawing.Size(192, 22)
        Me.cmsElementIDs.Text = "IDs"
        '
        'cmsElemntIDName
        '
        Me.cmsElemntIDName.Name = "cmsElemntIDName"
        Me.cmsElemntIDName.Size = New System.Drawing.Size(192, 22)
        Me.cmsElemntIDName.Text = "ID and Element Name"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(189, 6)
        '
        'cmsElementSortByID
        '
        Me.cmsElementSortByID.Name = "cmsElementSortByID"
        Me.cmsElementSortByID.Size = New System.Drawing.Size(192, 22)
        Me.cmsElementSortByID.Text = "Sort By ID"
        '
        'cmsElementSortyByName
        '
        Me.cmsElementSortyByName.Name = "cmsElementSortyByName"
        Me.cmsElementSortyByName.Size = New System.Drawing.Size(192, 22)
        Me.cmsElementSortyByName.Text = "Sort By Element Name"
        '
        'cmsElementsFilter
        '
        Me.cmsElementsFilter.Name = "cmsElementsFilter"
        Me.cmsElementsFilter.Size = New System.Drawing.Size(192, 22)
        Me.cmsElementsFilter.Text = "Filter Stations"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(189, 6)
        '
        'ucrElementSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "ucrElementSelector"
        Me.cmsElement.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsElement As ContextMenuStrip
    Friend WithEvents cmsElementsNames As ToolStripMenuItem
    Friend WithEvents cmsElementIDs As ToolStripMenuItem
    Friend WithEvents cmsElemntIDName As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmsElementSortByID As ToolStripMenuItem
    Friend WithEvents cmsElementSortyByName As ToolStripMenuItem
    Friend WithEvents cmsElementsFilter As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
