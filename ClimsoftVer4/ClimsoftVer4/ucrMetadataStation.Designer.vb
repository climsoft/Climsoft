<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrMetadataStation
    Inherits ClimsoftVer4.ucrTableEntry

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
        Me.ucrNavigationStation = New ClimsoftVer4.ucrNavigation()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.ucrStationSelector = New ClimsoftVer4.ucrTextBox()
        Me.ucrDatePickerClosingDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerOpeningDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrTextBoxGeographicalAccuracy = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxGraphicalMethod = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxQualifier = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDrainageBasin = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxAdminRegion = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxAuthority = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxCountry = New ClimsoftVer4.ucrTextBox()
        Me.ucrICAOId = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxWMOId = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxElevation = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrStationIDcombobox = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.grpComputationDD = New System.Windows.Forms.GroupBox()
        Me.ucrTextBoxSecondsLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxSecondsLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxMinutesLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxMinutesLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDegreesLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDegreesLatitude = New ClimsoftVer4.ucrTextBox()
        Me.lblEW = New System.Windows.Forms.Label()
        Me.lblNS = New System.Windows.Forms.Label()
        Me.lstEW = New System.Windows.Forms.ComboBox()
        Me.lstNS = New System.Windows.Forms.ComboBox()
        Me.lblSecondsLon = New System.Windows.Forms.Label()
        Me.lblSecondsLat = New System.Windows.Forms.Label()
        Me.lblMinutesLon = New System.Windows.Forms.Label()
        Me.lblMinutesLat = New System.Windows.Forms.Label()
        Me.lblDegreesLon = New System.Windows.Forms.Label()
        Me.lblDegreesLat = New System.Windows.Forms.Label()
        Me.lblICAOid = New System.Windows.Forms.Label()
        Me.lblWMOid = New System.Windows.Forms.Label()
        Me.lblSearchStation = New System.Windows.Forms.Label()
        Me.txtStationOperation = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblStationOperation = New System.Windows.Forms.Label()
        Me.lbldarainage = New System.Windows.Forms.Label()
        Me.lblAdmin = New System.Windows.Forms.Label()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblClosingdate = New System.Windows.Forms.Label()
        Me.lblOpendate = New System.Windows.Forms.Label()
        Me.lblGeoAccuracy = New System.Windows.Forms.Label()
        Me.lblGeoMethod = New System.Windows.Forms.Label()
        Me.lblElevation = New System.Windows.Forms.Label()
        Me.lblongitude = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.lblStationName = New System.Windows.Forms.Label()
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.ucrSearchStationName = New ClimsoftVer4.ucrStationSelector()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpComputationDD.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrNavigationStation
        '
        Me.ucrNavigationStation.Location = New System.Drawing.Point(199, 452)
        Me.ucrNavigationStation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStation.Name = "ucrNavigationStation"
        Me.ucrNavigationStation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStation.TabIndex = 2
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.Location = New System.Drawing.Point(330, 6)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(52, 15)
        Me.lblStation.TabIndex = 0
        Me.lblStation.Text = "Station"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "stationName"
        Me.ucrStationSelector.Location = New System.Drawing.Point(121, 95)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(228, 21)
        Me.ucrStationSelector.TabIndex = 76
        Me.ucrStationSelector.Tag = "stationName"
        Me.ucrStationSelector.TextboxValue = ""
        '
        'ucrDatePickerClosingDate
        '
        Me.ucrDatePickerClosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerClosingDate.Location = New System.Drawing.Point(522, 273)
        Me.ucrDatePickerClosingDate.Name = "ucrDatePickerClosingDate"
        Me.ucrDatePickerClosingDate.Size = New System.Drawing.Size(174, 21)
        Me.ucrDatePickerClosingDate.TabIndex = 68
        Me.ucrDatePickerClosingDate.Tag = "closingDatetime"
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(522, 249)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(174, 21)
        Me.ucrDatePickerOpeningDate.TabIndex = 66
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrTextBoxGeographicalAccuracy
        '
        Me.ucrTextBoxGeographicalAccuracy.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Location = New System.Drawing.Point(522, 327)
        Me.ucrTextBoxGeographicalAccuracy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeographicalAccuracy.Name = "ucrTextBoxGeographicalAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Size = New System.Drawing.Size(174, 20)
        Me.ucrTextBoxGeographicalAccuracy.TabIndex = 72
        Me.ucrTextBoxGeographicalAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.TextboxValue = ""
        '
        'ucrTextBoxGraphicalMethod
        '
        Me.ucrTextBoxGraphicalMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.Location = New System.Drawing.Point(522, 303)
        Me.ucrTextBoxGraphicalMethod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGraphicalMethod.Name = "ucrTextBoxGraphicalMethod"
        Me.ucrTextBoxGraphicalMethod.Size = New System.Drawing.Size(174, 20)
        Me.ucrTextBoxGraphicalMethod.TabIndex = 70
        Me.ucrTextBoxGraphicalMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.TextboxValue = ""
        '
        'ucrTextBoxQualifier
        '
        Me.ucrTextBoxQualifier.FieldName = "qualifier"
        Me.ucrTextBoxQualifier.Location = New System.Drawing.Point(522, 223)
        Me.ucrTextBoxQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxQualifier.Name = "ucrTextBoxQualifier"
        Me.ucrTextBoxQualifier.Size = New System.Drawing.Size(162, 20)
        Me.ucrTextBoxQualifier.TabIndex = 64
        Me.ucrTextBoxQualifier.Tag = "qualifier"
        Me.ucrTextBoxQualifier.TextboxValue = ""
        '
        'ucrTextBoxDrainageBasin
        '
        Me.ucrTextBoxDrainageBasin.FieldName = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.Location = New System.Drawing.Point(120, 356)
        Me.ucrTextBoxDrainageBasin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDrainageBasin.Name = "ucrTextBoxDrainageBasin"
        Me.ucrTextBoxDrainageBasin.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxDrainageBasin.TabIndex = 62
        Me.ucrTextBoxDrainageBasin.Tag = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.TextboxValue = ""
        '
        'ucrTextBoxAdminRegion
        '
        Me.ucrTextBoxAdminRegion.FieldName = "adminRegion"
        Me.ucrTextBoxAdminRegion.Location = New System.Drawing.Point(121, 327)
        Me.ucrTextBoxAdminRegion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAdminRegion.Name = "ucrTextBoxAdminRegion"
        Me.ucrTextBoxAdminRegion.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxAdminRegion.TabIndex = 60
        Me.ucrTextBoxAdminRegion.Tag = "adminRegion"
        Me.ucrTextBoxAdminRegion.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.FieldName = "authority"
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(121, 303)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxAuthority.TabIndex = 58
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrTextBoxCountry
        '
        Me.ucrTextBoxCountry.FieldName = "country"
        Me.ucrTextBoxCountry.Location = New System.Drawing.Point(120, 274)
        Me.ucrTextBoxCountry.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxCountry.Name = "ucrTextBoxCountry"
        Me.ucrTextBoxCountry.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxCountry.TabIndex = 56
        Me.ucrTextBoxCountry.Tag = "country"
        Me.ucrTextBoxCountry.TextboxValue = ""
        '
        'ucrICAOId
        '
        Me.ucrICAOId.FieldName = "icaoid"
        Me.ucrICAOId.Location = New System.Drawing.Point(120, 249)
        Me.ucrICAOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrICAOId.Name = "ucrICAOId"
        Me.ucrICAOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrICAOId.TabIndex = 54
        Me.ucrICAOId.Tag = "icaoid"
        Me.ucrICAOId.TextboxValue = ""
        '
        'ucrTextBoxWMOId
        '
        Me.ucrTextBoxWMOId.FieldName = "wmoid"
        Me.ucrTextBoxWMOId.Location = New System.Drawing.Point(121, 222)
        Me.ucrTextBoxWMOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxWMOId.Name = "ucrTextBoxWMOId"
        Me.ucrTextBoxWMOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrTextBoxWMOId.TabIndex = 52
        Me.ucrTextBoxWMOId.Tag = "wmoid"
        Me.ucrTextBoxWMOId.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(121, 193)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(74, 20)
        Me.ucrTextBoxElevation.TabIndex = 50
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.FieldName = "longitude"
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(121, 159)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(76, 21)
        Me.ucrTextBoxLongitude.TabIndex = 47
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(120, 134)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(77, 22)
        Me.ucrTextBoxLatitude.TabIndex = 45
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrStationIDcombobox
        '
        Me.ucrStationIDcombobox.FieldName = "stationId"
        Me.ucrStationIDcombobox.Location = New System.Drawing.Point(121, 68)
        Me.ucrStationIDcombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationIDcombobox.Name = "ucrStationIDcombobox"
        Me.ucrStationIDcombobox.Size = New System.Drawing.Size(139, 21)
        Me.ucrStationIDcombobox.TabIndex = 40
        Me.ucrStationIDcombobox.Tag = "stationId"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(404, 227)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 13)
        Me.Label24.TabIndex = 63
        Me.Label24.Text = "Qualifier"
        '
        'grpComputationDD
        '
        Me.grpComputationDD.BackColor = System.Drawing.Color.Snow
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxSecondsLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxSecondsLatitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinutesLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinutesLatitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxDegreesLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxDegreesLatitude)
        Me.grpComputationDD.Controls.Add(Me.lblEW)
        Me.grpComputationDD.Controls.Add(Me.lblNS)
        Me.grpComputationDD.Controls.Add(Me.lstEW)
        Me.grpComputationDD.Controls.Add(Me.lstNS)
        Me.grpComputationDD.Controls.Add(Me.lblSecondsLon)
        Me.grpComputationDD.Controls.Add(Me.lblSecondsLat)
        Me.grpComputationDD.Controls.Add(Me.lblMinutesLon)
        Me.grpComputationDD.Controls.Add(Me.lblMinutesLat)
        Me.grpComputationDD.Controls.Add(Me.lblDegreesLon)
        Me.grpComputationDD.Controls.Add(Me.lblDegreesLat)
        Me.grpComputationDD.Location = New System.Drawing.Point(204, 121)
        Me.grpComputationDD.Name = "grpComputationDD"
        Me.grpComputationDD.Size = New System.Drawing.Size(455, 69)
        Me.grpComputationDD.TabIndex = 48
        Me.grpComputationDD.TabStop = False
        Me.grpComputationDD.Text = "Latitude and Longitude Decimal Degrees Computation"
        '
        'ucrTextBoxSecondsLongitude
        '
        Me.ucrTextBoxSecondsLongitude.FieldName = Nothing
        Me.ucrTextBoxSecondsLongitude.Location = New System.Drawing.Point(295, 43)
        Me.ucrTextBoxSecondsLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxSecondsLongitude.Name = "ucrTextBoxSecondsLongitude"
        Me.ucrTextBoxSecondsLongitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxSecondsLongitude.TabIndex = 13
        Me.ucrTextBoxSecondsLongitude.TextboxValue = ""
        '
        'ucrTextBoxSecondsLatitude
        '
        Me.ucrTextBoxSecondsLatitude.FieldName = Nothing
        Me.ucrTextBoxSecondsLatitude.Location = New System.Drawing.Point(295, 15)
        Me.ucrTextBoxSecondsLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxSecondsLatitude.Name = "ucrTextBoxSecondsLatitude"
        Me.ucrTextBoxSecondsLatitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxSecondsLatitude.TabIndex = 5
        Me.ucrTextBoxSecondsLatitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLongitude
        '
        Me.ucrTextBoxMinutesLongitude.FieldName = Nothing
        Me.ucrTextBoxMinutesLongitude.Location = New System.Drawing.Point(173, 43)
        Me.ucrTextBoxMinutesLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxMinutesLongitude.Name = "ucrTextBoxMinutesLongitude"
        Me.ucrTextBoxMinutesLongitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxMinutesLongitude.TabIndex = 11
        Me.ucrTextBoxMinutesLongitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLatitude
        '
        Me.ucrTextBoxMinutesLatitude.FieldName = Nothing
        Me.ucrTextBoxMinutesLatitude.Location = New System.Drawing.Point(173, 18)
        Me.ucrTextBoxMinutesLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxMinutesLatitude.Name = "ucrTextBoxMinutesLatitude"
        Me.ucrTextBoxMinutesLatitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxMinutesLatitude.TabIndex = 3
        Me.ucrTextBoxMinutesLatitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLongitude
        '
        Me.ucrTextBoxDegreesLongitude.FieldName = Nothing
        Me.ucrTextBoxDegreesLongitude.Location = New System.Drawing.Point(56, 44)
        Me.ucrTextBoxDegreesLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDegreesLongitude.Name = "ucrTextBoxDegreesLongitude"
        Me.ucrTextBoxDegreesLongitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxDegreesLongitude.TabIndex = 9
        Me.ucrTextBoxDegreesLongitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLatitude
        '
        Me.ucrTextBoxDegreesLatitude.FieldName = Nothing
        Me.ucrTextBoxDegreesLatitude.Location = New System.Drawing.Point(56, 18)
        Me.ucrTextBoxDegreesLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDegreesLatitude.Name = "ucrTextBoxDegreesLatitude"
        Me.ucrTextBoxDegreesLatitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxDegreesLatitude.TabIndex = 1
        Me.ucrTextBoxDegreesLatitude.TextboxValue = ""
        '
        'lblEW
        '
        Me.lblEW.AutoSize = True
        Me.lblEW.Location = New System.Drawing.Point(356, 46)
        Me.lblEW.Name = "lblEW"
        Me.lblEW.Size = New System.Drawing.Size(30, 13)
        Me.lblEW.TabIndex = 14
        Me.lblEW.Text = "E/W"
        '
        'lblNS
        '
        Me.lblNS.AutoSize = True
        Me.lblNS.Location = New System.Drawing.Point(359, 18)
        Me.lblNS.Name = "lblNS"
        Me.lblNS.Size = New System.Drawing.Size(27, 13)
        Me.lblNS.TabIndex = 6
        Me.lblNS.Text = "N/S"
        '
        'lstEW
        '
        Me.lstEW.FormattingEnabled = True
        Me.lstEW.Items.AddRange(New Object() {"E", "W"})
        Me.lstEW.Location = New System.Drawing.Point(395, 42)
        Me.lstEW.Name = "lstEW"
        Me.lstEW.Size = New System.Drawing.Size(41, 21)
        Me.lstEW.TabIndex = 15
        '
        'lstNS
        '
        Me.lstNS.FormattingEnabled = True
        Me.lstNS.Items.AddRange(New Object() {"N", "S"})
        Me.lstNS.Location = New System.Drawing.Point(395, 15)
        Me.lstNS.Name = "lstNS"
        Me.lstNS.Size = New System.Drawing.Size(41, 21)
        Me.lstNS.TabIndex = 7
        '
        'lblSecondsLon
        '
        Me.lblSecondsLon.AutoSize = True
        Me.lblSecondsLon.Location = New System.Drawing.Point(242, 46)
        Me.lblSecondsLon.Name = "lblSecondsLon"
        Me.lblSecondsLon.Size = New System.Drawing.Size(49, 13)
        Me.lblSecondsLon.TabIndex = 12
        Me.lblSecondsLon.Text = "Seconds"
        '
        'lblSecondsLat
        '
        Me.lblSecondsLat.AutoSize = True
        Me.lblSecondsLat.Location = New System.Drawing.Point(243, 18)
        Me.lblSecondsLat.Name = "lblSecondsLat"
        Me.lblSecondsLat.Size = New System.Drawing.Size(49, 13)
        Me.lblSecondsLat.TabIndex = 4
        Me.lblSecondsLat.Text = "Seconds"
        '
        'lblMinutesLon
        '
        Me.lblMinutesLon.AutoSize = True
        Me.lblMinutesLon.Location = New System.Drawing.Point(123, 46)
        Me.lblMinutesLon.Name = "lblMinutesLon"
        Me.lblMinutesLon.Size = New System.Drawing.Size(44, 13)
        Me.lblMinutesLon.TabIndex = 10
        Me.lblMinutesLon.Text = "Minutes"
        '
        'lblMinutesLat
        '
        Me.lblMinutesLat.AutoSize = True
        Me.lblMinutesLat.Location = New System.Drawing.Point(124, 18)
        Me.lblMinutesLat.Name = "lblMinutesLat"
        Me.lblMinutesLat.Size = New System.Drawing.Size(44, 13)
        Me.lblMinutesLat.TabIndex = 2
        Me.lblMinutesLat.Text = "Minutes"
        '
        'lblDegreesLon
        '
        Me.lblDegreesLon.AutoSize = True
        Me.lblDegreesLon.Location = New System.Drawing.Point(3, 46)
        Me.lblDegreesLon.Name = "lblDegreesLon"
        Me.lblDegreesLon.Size = New System.Drawing.Size(47, 13)
        Me.lblDegreesLon.TabIndex = 8
        Me.lblDegreesLon.Text = "Degrees"
        '
        'lblDegreesLat
        '
        Me.lblDegreesLat.AutoSize = True
        Me.lblDegreesLat.Location = New System.Drawing.Point(4, 18)
        Me.lblDegreesLat.Name = "lblDegreesLat"
        Me.lblDegreesLat.Size = New System.Drawing.Size(47, 13)
        Me.lblDegreesLat.TabIndex = 0
        Me.lblDegreesLat.Text = "Degrees"
        '
        'lblICAOid
        '
        Me.lblICAOid.AutoSize = True
        Me.lblICAOid.Location = New System.Drawing.Point(27, 253)
        Me.lblICAOid.Name = "lblICAOid"
        Me.lblICAOid.Size = New System.Drawing.Size(44, 13)
        Me.lblICAOid.TabIndex = 53
        Me.lblICAOid.Text = "ICAO Id"
        '
        'lblWMOid
        '
        Me.lblWMOid.AutoSize = True
        Me.lblWMOid.Location = New System.Drawing.Point(26, 227)
        Me.lblWMOid.Name = "lblWMOid"
        Me.lblWMOid.Size = New System.Drawing.Size(47, 13)
        Me.lblWMOid.TabIndex = 51
        Me.lblWMOid.Text = "WMO Id"
        '
        'lblSearchStation
        '
        Me.lblSearchStation.AutoSize = True
        Me.lblSearchStation.Location = New System.Drawing.Point(361, 68)
        Me.lblSearchStation.Name = "lblSearchStation"
        Me.lblSearchStation.Size = New System.Drawing.Size(108, 13)
        Me.lblSearchStation.TabIndex = 42
        Me.lblSearchStation.Text = "Search Station Name"
        '
        'txtStationOperation
        '
        Me.txtStationOperation.AutoSize = True
        Me.txtStationOperation.Location = New System.Drawing.Point(522, 356)
        Me.txtStationOperation.Name = "txtStationOperation"
        Me.txtStationOperation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStationOperation.Size = New System.Drawing.Size(15, 14)
        Me.txtStationOperation.TabIndex = 74
        Me.txtStationOperation.Tag = "stationOperational"
        Me.txtStationOperation.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.txtStationOperation.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.btnImport)
        Me.Panel2.Controls.Add(Me.btnAddNew)
        Me.Panel2.Controls.Add(Me.btnView)
        Me.Panel2.Controls.Add(Me.btnDelete)
        Me.Panel2.Controls.Add(Me.btnUpdate)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Location = New System.Drawing.Point(7, 412)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(721, 29)
        Me.Panel2.TabIndex = 75
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(424, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(64, 27)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(626, 0)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(20, 0)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(525, 0)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(323, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(222, 0)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(121, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblStationOperation
        '
        Me.lblStationOperation.AutoSize = True
        Me.lblStationOperation.Location = New System.Drawing.Point(404, 357)
        Me.lblStationOperation.Name = "lblStationOperation"
        Me.lblStationOperation.Size = New System.Drawing.Size(97, 13)
        Me.lblStationOperation.TabIndex = 73
        Me.lblStationOperation.Tag = ""
        Me.lblStationOperation.Text = "Station Operational"
        '
        'lbldarainage
        '
        Me.lbldarainage.AutoSize = True
        Me.lbldarainage.Location = New System.Drawing.Point(25, 357)
        Me.lbldarainage.Name = "lbldarainage"
        Me.lbldarainage.Size = New System.Drawing.Size(79, 13)
        Me.lbldarainage.TabIndex = 61
        Me.lbldarainage.Text = "Drainage Basin"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(27, 331)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(73, 13)
        Me.lblAdmin.TabIndex = 59
        Me.lblAdmin.Text = "Admin Region"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(27, 305)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 57
        Me.lblAuthority.Text = "Authority"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(28, 279)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 55
        Me.lblCountry.Text = "Country"
        '
        'lblClosingdate
        '
        Me.lblClosingdate.AutoSize = True
        Me.lblClosingdate.Location = New System.Drawing.Point(404, 279)
        Me.lblClosingdate.Name = "lblClosingdate"
        Me.lblClosingdate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingdate.TabIndex = 67
        Me.lblClosingdate.Text = "Closing Date"
        '
        'lblOpendate
        '
        Me.lblOpendate.AutoSize = True
        Me.lblOpendate.Location = New System.Drawing.Point(404, 253)
        Me.lblOpendate.Name = "lblOpendate"
        Me.lblOpendate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpendate.TabIndex = 65
        Me.lblOpendate.Text = "Opening Date"
        '
        'lblGeoAccuracy
        '
        Me.lblGeoAccuracy.AutoSize = True
        Me.lblGeoAccuracy.Location = New System.Drawing.Point(404, 331)
        Me.lblGeoAccuracy.Name = "lblGeoAccuracy"
        Me.lblGeoAccuracy.Size = New System.Drawing.Size(118, 13)
        Me.lblGeoAccuracy.TabIndex = 71
        Me.lblGeoAccuracy.Tag = ""
        Me.lblGeoAccuracy.Text = "Geographical Accuracy"
        '
        'lblGeoMethod
        '
        Me.lblGeoMethod.AutoSize = True
        Me.lblGeoMethod.Location = New System.Drawing.Point(404, 305)
        Me.lblGeoMethod.Name = "lblGeoMethod"
        Me.lblGeoMethod.Size = New System.Drawing.Size(109, 13)
        Me.lblGeoMethod.TabIndex = 69
        Me.lblGeoMethod.Tag = ""
        Me.lblGeoMethod.Text = "Geographical Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(24, 193)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(88, 13)
        Me.lblElevation.TabIndex = 49
        Me.lblElevation.Text = "Elevation(metres)"
        '
        'lblongitude
        '
        Me.lblongitude.AutoSize = True
        Me.lblongitude.Location = New System.Drawing.Point(24, 165)
        Me.lblongitude.Name = "lblongitude"
        Me.lblongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblongitude.TabIndex = 46
        Me.lblongitude.Text = "Longitude"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(24, 137)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 44
        Me.lblLatitude.Text = "Latitude"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Location = New System.Drawing.Point(26, 103)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(71, 13)
        Me.lblStationName.TabIndex = 41
        Me.lblStationName.Text = "Station Name"
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(24, 76)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(52, 13)
        Me.lblStationId.TabIndex = 39
        Me.lblStationId.Text = "Station Id"
        '
        'ucrSearchStationName
        '
        Me.ucrSearchStationName.FieldName = ""
        Me.ucrSearchStationName.Location = New System.Drawing.Point(475, 68)
        Me.ucrSearchStationName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSearchStationName.Name = "ucrSearchStationName"
        Me.ucrSearchStationName.Size = New System.Drawing.Size(253, 24)
        Me.ucrSearchStationName.TabIndex = 77
        Me.ucrSearchStationName.Tag = ""
        '
        'ucrMetadataStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrSearchStationName)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrDatePickerClosingDate)
        Me.Controls.Add(Me.ucrDatePickerOpeningDate)
        Me.Controls.Add(Me.ucrTextBoxGeographicalAccuracy)
        Me.Controls.Add(Me.ucrTextBoxGraphicalMethod)
        Me.Controls.Add(Me.ucrTextBoxQualifier)
        Me.Controls.Add(Me.ucrTextBoxDrainageBasin)
        Me.Controls.Add(Me.ucrTextBoxAdminRegion)
        Me.Controls.Add(Me.ucrTextBoxAuthority)
        Me.Controls.Add(Me.ucrTextBoxCountry)
        Me.Controls.Add(Me.ucrICAOId)
        Me.Controls.Add(Me.ucrTextBoxWMOId)
        Me.Controls.Add(Me.ucrTextBoxElevation)
        Me.Controls.Add(Me.ucrTextBoxLongitude)
        Me.Controls.Add(Me.ucrTextBoxLatitude)
        Me.Controls.Add(Me.ucrStationIDcombobox)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.grpComputationDD)
        Me.Controls.Add(Me.lblICAOid)
        Me.Controls.Add(Me.lblWMOid)
        Me.Controls.Add(Me.lblSearchStation)
        Me.Controls.Add(Me.txtStationOperation)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblStationOperation)
        Me.Controls.Add(Me.lbldarainage)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.lblAuthority)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.lblClosingdate)
        Me.Controls.Add(Me.lblOpendate)
        Me.Controls.Add(Me.lblGeoAccuracy)
        Me.Controls.Add(Me.lblGeoMethod)
        Me.Controls.Add(Me.lblElevation)
        Me.Controls.Add(Me.lblongitude)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.lblStationName)
        Me.Controls.Add(Me.lblStationId)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrNavigationStation)
        Me.Name = "ucrMetadataStation"
        Me.Size = New System.Drawing.Size(734, 509)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpComputationDD.ResumeLayout(False)
        Me.grpComputationDD.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ucrNavigationStation As ucrNavigation
    Friend WithEvents lblStation As Label
    Friend WithEvents ucrStationSelector As ucrTextBox
    Friend WithEvents ucrDatePickerClosingDate As ucrDatePicker
    Friend WithEvents ucrDatePickerOpeningDate As ucrDatePicker
    Friend WithEvents ucrTextBoxGeographicalAccuracy As ucrTextBox
    Friend WithEvents ucrTextBoxGraphicalMethod As ucrTextBox
    Friend WithEvents ucrTextBoxQualifier As ucrTextBox
    Friend WithEvents ucrTextBoxDrainageBasin As ucrTextBox
    Friend WithEvents ucrTextBoxAdminRegion As ucrTextBox
    Friend WithEvents ucrTextBoxAuthority As ucrTextBox
    Friend WithEvents ucrTextBoxCountry As ucrTextBox
    Friend WithEvents ucrICAOId As ucrTextBox
    Friend WithEvents ucrTextBoxWMOId As ucrTextBox
    Friend WithEvents ucrTextBoxElevation As ucrTextBox
    Friend WithEvents ucrTextBoxLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxLatitude As ucrTextBox
    Friend WithEvents ucrStationIDcombobox As ucrDataLinkCombobox
    Friend WithEvents Label24 As Label
    Friend WithEvents grpComputationDD As GroupBox
    Friend WithEvents ucrTextBoxSecondsLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxSecondsLatitude As ucrTextBox
    Friend WithEvents ucrTextBoxMinutesLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxMinutesLatitude As ucrTextBox
    Friend WithEvents ucrTextBoxDegreesLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxDegreesLatitude As ucrTextBox
    Friend WithEvents lblEW As Label
    Friend WithEvents lblNS As Label
    Friend WithEvents lstEW As ComboBox
    Friend WithEvents lstNS As ComboBox
    Friend WithEvents lblSecondsLon As Label
    Friend WithEvents lblSecondsLat As Label
    Friend WithEvents lblMinutesLon As Label
    Friend WithEvents lblMinutesLat As Label
    Friend WithEvents lblDegreesLon As Label
    Friend WithEvents lblDegreesLat As Label
    Friend WithEvents lblICAOid As Label
    Friend WithEvents lblWMOid As Label
    Friend WithEvents lblSearchStation As Label
    Friend WithEvents txtStationOperation As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents lblStationOperation As Label
    Friend WithEvents lbldarainage As Label
    Friend WithEvents lblAdmin As Label
    Friend WithEvents lblAuthority As Label
    Friend WithEvents lblCountry As Label
    Friend WithEvents lblClosingdate As Label
    Friend WithEvents lblOpendate As Label
    Friend WithEvents lblGeoAccuracy As Label
    Friend WithEvents lblGeoMethod As Label
    Friend WithEvents lblElevation As Label
    Friend WithEvents lblongitude As Label
    Friend WithEvents lblLatitude As Label
    Friend WithEvents lblStationName As Label
    Friend WithEvents lblStationId As Label
    Friend WithEvents ucrSearchStationName As ucrStationSelector
End Class
