<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formStation))
        Dim StationIdLabel As System.Windows.Forms.Label
        Dim StationNameLabel As System.Windows.Forms.Label
        Dim LatitudeLabel As System.Windows.Forms.Label
        Dim LongitudeLabel As System.Windows.Forms.Label
        Dim ElevationLabel As System.Windows.Forms.Label
        Dim GeoLocationMethodLabel As System.Windows.Forms.Label
        Dim GeoLocationAccuracyLabel As System.Windows.Forms.Label
        Dim OpeningDatetimeLabel As System.Windows.Forms.Label
        Dim ClosingDatetimeLabel As System.Windows.Forms.Label
        Dim CountryLabel As System.Windows.Forms.Label
        Dim AuthorityLabel As System.Windows.Forms.Label
        Dim AdminRegionLabel As System.Windows.Forms.Label
        Dim DrainageBasinLabel As System.Windows.Forms.Label
        Dim CptSelectionLabel As System.Windows.Forms.Label
        Dim StationOperationalLabel As System.Windows.Forms.Label
        Me.Mysql_climsoft_db_v4DataSet1 = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet1()
        Me.StationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StationTableAdapter = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet1TableAdapters.stationTableAdapter()
        Me.TableAdapterManager = New ClimsoftVersion4.mysql_climsoft_db_v4DataSet1TableAdapters.TableAdapterManager()
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
        Me.LatitudeTextBox = New System.Windows.Forms.TextBox()
        Me.LongitudeTextBox = New System.Windows.Forms.TextBox()
        Me.ElevationTextBox = New System.Windows.Forms.TextBox()
        Me.GeoLocationMethodTextBox = New System.Windows.Forms.TextBox()
        Me.GeoLocationAccuracyTextBox = New System.Windows.Forms.TextBox()
        Me.OpeningDatetimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.ClosingDatetimeDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.CountryTextBox = New System.Windows.Forms.TextBox()
        Me.AuthorityTextBox = New System.Windows.Forms.TextBox()
        Me.AdminRegionTextBox = New System.Windows.Forms.TextBox()
        Me.DrainageBasinTextBox = New System.Windows.Forms.TextBox()
        Me.CptSelectionTextBox = New System.Windows.Forms.TextBox()
        Me.StationOperationalTextBox = New System.Windows.Forms.TextBox()
        StationIdLabel = New System.Windows.Forms.Label()
        StationNameLabel = New System.Windows.Forms.Label()
        LatitudeLabel = New System.Windows.Forms.Label()
        LongitudeLabel = New System.Windows.Forms.Label()
        ElevationLabel = New System.Windows.Forms.Label()
        GeoLocationMethodLabel = New System.Windows.Forms.Label()
        GeoLocationAccuracyLabel = New System.Windows.Forms.Label()
        OpeningDatetimeLabel = New System.Windows.Forms.Label()
        ClosingDatetimeLabel = New System.Windows.Forms.Label()
        CountryLabel = New System.Windows.Forms.Label()
        AuthorityLabel = New System.Windows.Forms.Label()
        AdminRegionLabel = New System.Windows.Forms.Label()
        DrainageBasinLabel = New System.Windows.Forms.Label()
        CptSelectionLabel = New System.Windows.Forms.Label()
        StationOperationalLabel = New System.Windows.Forms.Label()
        CType(Me.Mysql_climsoft_db_v4DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StationBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mysql_climsoft_db_v4DataSet1
        '
        Me.Mysql_climsoft_db_v4DataSet1.DataSetName = "mysql_climsoft_db_v4DataSet1"
        Me.Mysql_climsoft_db_v4DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StationBindingSource
        '
        Me.StationBindingSource.DataMember = "station"
        Me.StationBindingSource.DataSource = Me.Mysql_climsoft_db_v4DataSet1
        '
        'StationTableAdapter
        '
        Me.StationTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.stationTableAdapter = Me.StationTableAdapter
        Me.TableAdapterManager.UpdateOrder = ClimsoftVersion4.mysql_climsoft_db_v4DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.StationBindingNavigator.Size = New System.Drawing.Size(779, 25)
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
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'StationBindingNavigatorSaveItem
        '
        Me.StationBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.StationBindingNavigatorSaveItem.Image = CType(resources.GetObject("StationBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.StationBindingNavigatorSaveItem.Name = "StationBindingNavigatorSaveItem"
        Me.StationBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.StationBindingNavigatorSaveItem.Text = "Save Data"
        '
        'StationIdLabel
        '
        StationIdLabel.AutoSize = True
        StationIdLabel.Location = New System.Drawing.Point(75, 50)
        StationIdLabel.Name = "StationIdLabel"
        StationIdLabel.Size = New System.Drawing.Size(55, 13)
        StationIdLabel.TabIndex = 1
        StationIdLabel.Text = "Station Id:"
        '
        'StationIdTextBox
        '
        Me.StationIdTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.StationIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "stationId", True))
        Me.StationIdTextBox.Location = New System.Drawing.Point(140, 47)
        Me.StationIdTextBox.Name = "StationIdTextBox"
        Me.StationIdTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationIdTextBox.TabIndex = 2
        '
        'StationNameLabel
        '
        StationNameLabel.AutoSize = True
        StationNameLabel.Location = New System.Drawing.Point(289, 53)
        StationNameLabel.Name = "StationNameLabel"
        StationNameLabel.Size = New System.Drawing.Size(74, 13)
        StationNameLabel.TabIndex = 3
        StationNameLabel.Text = "Station Name:"
        '
        'StationNameTextBox
        '
        Me.StationNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "stationName", True))
        Me.StationNameTextBox.Location = New System.Drawing.Point(367, 50)
        Me.StationNameTextBox.Name = "StationNameTextBox"
        Me.StationNameTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationNameTextBox.TabIndex = 4
        '
        'LatitudeLabel
        '
        LatitudeLabel.AutoSize = True
        LatitudeLabel.Location = New System.Drawing.Point(84, 97)
        LatitudeLabel.Name = "LatitudeLabel"
        LatitudeLabel.Size = New System.Drawing.Size(48, 13)
        LatitudeLabel.TabIndex = 5
        LatitudeLabel.Text = "Latitude:"
        '
        'LatitudeTextBox
        '
        Me.LatitudeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "latitude", True))
        Me.LatitudeTextBox.Location = New System.Drawing.Point(140, 94)
        Me.LatitudeTextBox.Name = "LatitudeTextBox"
        Me.LatitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LatitudeTextBox.TabIndex = 6
        '
        'LongitudeLabel
        '
        LongitudeLabel.AutoSize = True
        LongitudeLabel.Location = New System.Drawing.Point(308, 97)
        LongitudeLabel.Name = "LongitudeLabel"
        LongitudeLabel.Size = New System.Drawing.Size(57, 13)
        LongitudeLabel.TabIndex = 7
        LongitudeLabel.Text = "Longitude:"
        '
        'LongitudeTextBox
        '
        Me.LongitudeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "longitude", True))
        Me.LongitudeTextBox.Location = New System.Drawing.Point(367, 94)
        Me.LongitudeTextBox.Name = "LongitudeTextBox"
        Me.LongitudeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LongitudeTextBox.TabIndex = 8
        '
        'ElevationLabel
        '
        ElevationLabel.AutoSize = True
        ElevationLabel.Location = New System.Drawing.Point(556, 100)
        ElevationLabel.Name = "ElevationLabel"
        ElevationLabel.Size = New System.Drawing.Size(54, 13)
        ElevationLabel.TabIndex = 9
        ElevationLabel.Text = "Elevation:"
        '
        'ElevationTextBox
        '
        Me.ElevationTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "elevation", True))
        Me.ElevationTextBox.Location = New System.Drawing.Point(615, 97)
        Me.ElevationTextBox.Name = "ElevationTextBox"
        Me.ElevationTextBox.Size = New System.Drawing.Size(100, 20)
        Me.ElevationTextBox.TabIndex = 10
        '
        'GeoLocationMethodLabel
        '
        GeoLocationMethodLabel.AutoSize = True
        GeoLocationMethodLabel.Location = New System.Drawing.Point(23, 271)
        GeoLocationMethodLabel.Name = "GeoLocationMethodLabel"
        GeoLocationMethodLabel.Size = New System.Drawing.Size(113, 13)
        GeoLocationMethodLabel.TabIndex = 11
        GeoLocationMethodLabel.Text = "Geo Location Method:"
        '
        'GeoLocationMethodTextBox
        '
        Me.GeoLocationMethodTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "geoLocationMethod", True))
        Me.GeoLocationMethodTextBox.Location = New System.Drawing.Point(140, 268)
        Me.GeoLocationMethodTextBox.Name = "GeoLocationMethodTextBox"
        Me.GeoLocationMethodTextBox.Size = New System.Drawing.Size(100, 20)
        Me.GeoLocationMethodTextBox.TabIndex = 12
        '
        'GeoLocationAccuracyLabel
        '
        GeoLocationAccuracyLabel.AutoSize = True
        GeoLocationAccuracyLabel.Location = New System.Drawing.Point(323, 271)
        GeoLocationAccuracyLabel.Name = "GeoLocationAccuracyLabel"
        GeoLocationAccuracyLabel.Size = New System.Drawing.Size(122, 13)
        GeoLocationAccuracyLabel.TabIndex = 13
        GeoLocationAccuracyLabel.Text = "Geo Location Accuracy:"
        '
        'GeoLocationAccuracyTextBox
        '
        Me.GeoLocationAccuracyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "geoLocationAccuracy", True))
        Me.GeoLocationAccuracyTextBox.Location = New System.Drawing.Point(458, 268)
        Me.GeoLocationAccuracyTextBox.Name = "GeoLocationAccuracyTextBox"
        Me.GeoLocationAccuracyTextBox.Size = New System.Drawing.Size(109, 20)
        Me.GeoLocationAccuracyTextBox.TabIndex = 14
        '
        'OpeningDatetimeLabel
        '
        OpeningDatetimeLabel.AutoSize = True
        OpeningDatetimeLabel.Location = New System.Drawing.Point(251, 183)
        OpeningDatetimeLabel.Name = "OpeningDatetimeLabel"
        OpeningDatetimeLabel.Size = New System.Drawing.Size(95, 13)
        OpeningDatetimeLabel.TabIndex = 15
        OpeningDatetimeLabel.Text = "Opening Datetime:"
        '
        'OpeningDatetimeDateTimePicker
        '
        Me.OpeningDatetimeDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.StationBindingSource, "openingDatetime", True))
        Me.OpeningDatetimeDateTimePicker.Location = New System.Drawing.Point(367, 179)
        Me.OpeningDatetimeDateTimePicker.Name = "OpeningDatetimeDateTimePicker"
        Me.OpeningDatetimeDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.OpeningDatetimeDateTimePicker.TabIndex = 16
        '
        'ClosingDatetimeLabel
        '
        ClosingDatetimeLabel.AutoSize = True
        ClosingDatetimeLabel.Location = New System.Drawing.Point(251, 223)
        ClosingDatetimeLabel.Name = "ClosingDatetimeLabel"
        ClosingDatetimeLabel.Size = New System.Drawing.Size(89, 13)
        ClosingDatetimeLabel.TabIndex = 17
        ClosingDatetimeLabel.Text = "Closing Datetime:"
        '
        'ClosingDatetimeDateTimePicker
        '
        Me.ClosingDatetimeDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.StationBindingSource, "closingDatetime", True))
        Me.ClosingDatetimeDateTimePicker.Location = New System.Drawing.Point(367, 219)
        Me.ClosingDatetimeDateTimePicker.Name = "ClosingDatetimeDateTimePicker"
        Me.ClosingDatetimeDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.ClosingDatetimeDateTimePicker.TabIndex = 18
        '
        'CountryLabel
        '
        CountryLabel.AutoSize = True
        CountryLabel.Location = New System.Drawing.Point(564, 56)
        CountryLabel.Name = "CountryLabel"
        CountryLabel.Size = New System.Drawing.Size(46, 13)
        CountryLabel.TabIndex = 19
        CountryLabel.Text = "Country:"
        '
        'CountryTextBox
        '
        Me.CountryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "country", True))
        Me.CountryTextBox.Location = New System.Drawing.Point(615, 53)
        Me.CountryTextBox.Name = "CountryTextBox"
        Me.CountryTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CountryTextBox.TabIndex = 20
        '
        'AuthorityLabel
        '
        AuthorityLabel.AutoSize = True
        AuthorityLabel.Location = New System.Drawing.Point(84, 137)
        AuthorityLabel.Name = "AuthorityLabel"
        AuthorityLabel.Size = New System.Drawing.Size(51, 13)
        AuthorityLabel.TabIndex = 21
        AuthorityLabel.Text = "Authority:"
        '
        'AuthorityTextBox
        '
        Me.AuthorityTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "authority", True))
        Me.AuthorityTextBox.Location = New System.Drawing.Point(140, 134)
        Me.AuthorityTextBox.Name = "AuthorityTextBox"
        Me.AuthorityTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AuthorityTextBox.TabIndex = 22
        '
        'AdminRegionLabel
        '
        AdminRegionLabel.AutoSize = True
        AdminRegionLabel.Location = New System.Drawing.Point(286, 140)
        AdminRegionLabel.Name = "AdminRegionLabel"
        AdminRegionLabel.Size = New System.Drawing.Size(76, 13)
        AdminRegionLabel.TabIndex = 23
        AdminRegionLabel.Text = "Admin Region:"
        '
        'AdminRegionTextBox
        '
        Me.AdminRegionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "adminRegion", True))
        Me.AdminRegionTextBox.Location = New System.Drawing.Point(367, 137)
        Me.AdminRegionTextBox.Name = "AdminRegionTextBox"
        Me.AdminRegionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AdminRegionTextBox.TabIndex = 24
        '
        'DrainageBasinLabel
        '
        DrainageBasinLabel.AutoSize = True
        DrainageBasinLabel.Location = New System.Drawing.Point(499, 137)
        DrainageBasinLabel.Name = "DrainageBasinLabel"
        DrainageBasinLabel.Size = New System.Drawing.Size(82, 13)
        DrainageBasinLabel.TabIndex = 25
        DrainageBasinLabel.Text = "Drainage Basin:"
        '
        'DrainageBasinTextBox
        '
        Me.DrainageBasinTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "drainageBasin", True))
        Me.DrainageBasinTextBox.Location = New System.Drawing.Point(615, 134)
        Me.DrainageBasinTextBox.Name = "DrainageBasinTextBox"
        Me.DrainageBasinTextBox.Size = New System.Drawing.Size(100, 20)
        Me.DrainageBasinTextBox.TabIndex = 26
        '
        'CptSelectionLabel
        '
        CptSelectionLabel.AutoSize = True
        CptSelectionLabel.Location = New System.Drawing.Point(62, 226)
        CptSelectionLabel.Name = "CptSelectionLabel"
        CptSelectionLabel.Size = New System.Drawing.Size(78, 13)
        CptSelectionLabel.TabIndex = 29
        CptSelectionLabel.Text = "CPT Selection:"
        '
        'CptSelectionTextBox
        '
        Me.CptSelectionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "cptSelection", True))
        Me.CptSelectionTextBox.Location = New System.Drawing.Point(140, 223)
        Me.CptSelectionTextBox.Name = "CptSelectionTextBox"
        Me.CptSelectionTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CptSelectionTextBox.TabIndex = 30
        '
        'StationOperationalLabel
        '
        StationOperationalLabel.AutoSize = True
        StationOperationalLabel.Location = New System.Drawing.Point(36, 186)
        StationOperationalLabel.Name = "StationOperationalLabel"
        StationOperationalLabel.Size = New System.Drawing.Size(100, 13)
        StationOperationalLabel.TabIndex = 31
        StationOperationalLabel.Text = "Station Operational:"
        '
        'StationOperationalTextBox
        '
        Me.StationOperationalTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StationBindingSource, "stationOperational", True))
        Me.StationOperationalTextBox.Location = New System.Drawing.Point(140, 183)
        Me.StationOperationalTextBox.Name = "StationOperationalTextBox"
        Me.StationOperationalTextBox.Size = New System.Drawing.Size(100, 20)
        Me.StationOperationalTextBox.TabIndex = 32
        '
        'station
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 347)
        Me.Controls.Add(StationOperationalLabel)
        Me.Controls.Add(Me.StationOperationalTextBox)
        Me.Controls.Add(CptSelectionLabel)
        Me.Controls.Add(Me.CptSelectionTextBox)
        Me.Controls.Add(DrainageBasinLabel)
        Me.Controls.Add(Me.DrainageBasinTextBox)
        Me.Controls.Add(AdminRegionLabel)
        Me.Controls.Add(Me.AdminRegionTextBox)
        Me.Controls.Add(AuthorityLabel)
        Me.Controls.Add(Me.AuthorityTextBox)
        Me.Controls.Add(CountryLabel)
        Me.Controls.Add(Me.CountryTextBox)
        Me.Controls.Add(ClosingDatetimeLabel)
        Me.Controls.Add(Me.ClosingDatetimeDateTimePicker)
        Me.Controls.Add(OpeningDatetimeLabel)
        Me.Controls.Add(Me.OpeningDatetimeDateTimePicker)
        Me.Controls.Add(GeoLocationAccuracyLabel)
        Me.Controls.Add(Me.GeoLocationAccuracyTextBox)
        Me.Controls.Add(GeoLocationMethodLabel)
        Me.Controls.Add(Me.GeoLocationMethodTextBox)
        Me.Controls.Add(ElevationLabel)
        Me.Controls.Add(Me.ElevationTextBox)
        Me.Controls.Add(LongitudeLabel)
        Me.Controls.Add(Me.LongitudeTextBox)
        Me.Controls.Add(LatitudeLabel)
        Me.Controls.Add(Me.LatitudeTextBox)
        Me.Controls.Add(StationNameLabel)
        Me.Controls.Add(Me.StationNameTextBox)
        Me.Controls.Add(StationIdLabel)
        Me.Controls.Add(Me.StationIdTextBox)
        Me.Controls.Add(Me.StationBindingNavigator)
        Me.Name = "station"
        Me.Text = "Station Information"
        CType(Me.Mysql_climsoft_db_v4DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StationBindingNavigator.ResumeLayout(False)
        Me.StationBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mysql_climsoft_db_v4DataSet1 As ClimsoftVersion4.mysql_climsoft_db_v4DataSet1
    Friend WithEvents StationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StationTableAdapter As ClimsoftVersion4.mysql_climsoft_db_v4DataSet1TableAdapters.stationTableAdapter
    Friend WithEvents TableAdapterManager As ClimsoftVersion4.mysql_climsoft_db_v4DataSet1TableAdapters.TableAdapterManager
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
    Friend WithEvents LatitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LongitudeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ElevationTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GeoLocationMethodTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GeoLocationAccuracyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpeningDatetimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents ClosingDatetimeDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents CountryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AuthorityTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AdminRegionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DrainageBasinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CptSelectionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StationOperationalTextBox As System.Windows.Forms.TextBox
End Class
