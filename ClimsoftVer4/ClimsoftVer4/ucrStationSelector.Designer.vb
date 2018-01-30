<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrStationSelector
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
        Me.cmsStation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsStationStationNames = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsStationIDs = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsStationIDAndStation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsStationSortByID = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsStationSortyByName = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsFilterStations = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsStation.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsStation
        '
        Me.cmsStation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsStationStationNames, Me.cmsStationIDs, Me.cmsStationIDAndStation, Me.ToolStripSeparator2, Me.cmsStationSortByID, Me.cmsStationSortyByName, Me.cmsFilterStations, Me.ToolStripSeparator1})
        Me.cmsStation.Name = "cmsStation"
        Me.cmsStation.Size = New System.Drawing.Size(187, 170)
        '
        'cmsStationStationNames
        '
        Me.cmsStationStationNames.Name = "cmsStationStationNames"
        Me.cmsStationStationNames.Size = New System.Drawing.Size(186, 22)
        Me.cmsStationStationNames.Text = "Station Names"
        '
        'cmsStationIDs
        '
        Me.cmsStationIDs.Name = "cmsStationIDs"
        Me.cmsStationIDs.Size = New System.Drawing.Size(186, 22)
        Me.cmsStationIDs.Text = "IDs"
        '
        'cmsStationIDAndStation
        '
        Me.cmsStationIDAndStation.Name = "cmsStationIDAndStation"
        Me.cmsStationIDAndStation.Size = New System.Drawing.Size(186, 22)
        Me.cmsStationIDAndStation.Text = "ID and Station"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(183, 6)
        '
        'cmsStationSortByID
        '
        Me.cmsStationSortByID.Name = "cmsStationSortByID"
        Me.cmsStationSortByID.Size = New System.Drawing.Size(186, 22)
        Me.cmsStationSortByID.Text = "Sort By ID"
        '
        'cmsStationSortyByName
        '
        Me.cmsStationSortyByName.Name = "cmsStationSortyByName"
        Me.cmsStationSortyByName.Size = New System.Drawing.Size(186, 22)
        Me.cmsStationSortyByName.Text = "Sort By Station Name"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(183, 6)
        '
        'cmsFilterStations
        '
        Me.cmsFilterStations.Name = "cmsFilterStations"
        Me.cmsFilterStations.Size = New System.Drawing.Size(186, 22)
        Me.cmsFilterStations.Text = "Filter Stations"
        '
        'ucrStationSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ContextMenuStrip = Me.cmsStation
        Me.Name = "ucrStationSelector"
        Me.Size = New System.Drawing.Size(260, 193)
        Me.cmsStation.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmsStation As ContextMenuStrip
    Friend WithEvents cmsStationStationNames As ToolStripMenuItem
    Friend WithEvents cmsStationIDs As ToolStripMenuItem
    Friend WithEvents cmsStationIDAndStation As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmsStationSortByID As ToolStripMenuItem
    Friend WithEvents cmsStationSortyByName As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmsFilterStations As ToolStripMenuItem
End Class
