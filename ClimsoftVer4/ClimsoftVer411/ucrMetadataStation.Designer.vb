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
        Me.ucrStationName = New ClimsoftVer4.ucrTextBox()
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
        Me.ucrDataLinkComboboxEW = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrDataLinkComboboxNS = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrTextBoxSecondsLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxSecondsLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxMinutesLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxMinutesLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDegreesLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDegreesLatitude = New ClimsoftVer4.ucrTextBox()
        Me.lblEW = New System.Windows.Forms.Label()
        Me.lblNS = New System.Windows.Forms.Label()
        Me.lblSecondsLon = New System.Windows.Forms.Label()
        Me.lblSecondsLat = New System.Windows.Forms.Label()
        Me.lblMinutesLon = New System.Windows.Forms.Label()
        Me.lblMinutesLat = New System.Windows.Forms.Label()
        Me.lblDegreesLon = New System.Windows.Forms.Label()
        Me.lblDegreesLat = New System.Windows.Forms.Label()
        Me.lblICAOid = New System.Windows.Forms.Label()
        Me.lblWMOid = New System.Windows.Forms.Label()
        Me.lblSearchStation = New System.Windows.Forms.Label()
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
        Me.ucrCheckStationOperational = New ClimsoftVer4.ucrCheck()
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
        'ucrStationName
        '
        Me.ucrStationName.FieldName = "stationName"
        Me.ucrStationName.KeyControl = False
        Me.ucrStationName.Location = New System.Drawing.Point(121, 95)
        Me.ucrStationName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationName.Name = "ucrStationName"
        Me.ucrStationName.Size = New System.Drawing.Size(228, 21)
        Me.ucrStationName.TabIndex = 4
        Me.ucrStationName.Tag = "stationName"
        Me.ucrStationName.TextboxValue = ""
        '
        'ucrDatePickerClosingDate
        '
        Me.ucrDatePickerClosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerClosingDate.KeyControl = False
        Me.ucrDatePickerClosingDate.Location = New System.Drawing.Point(522, 273)
        Me.ucrDatePickerClosingDate.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDatePickerClosingDate.Name = "ucrDatePickerClosingDate"
        Me.ucrDatePickerClosingDate.Size = New System.Drawing.Size(174, 21)
        Me.ucrDatePickerClosingDate.TabIndex = 30
        Me.ucrDatePickerClosingDate.Tag = "closingDatetime"
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.KeyControl = False
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(522, 249)
        Me.ucrDatePickerOpeningDate.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(174, 21)
        Me.ucrDatePickerOpeningDate.TabIndex = 28
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrTextBoxGeographicalAccuracy
        '
        Me.ucrTextBoxGeographicalAccuracy.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.KeyControl = False
        Me.ucrTextBoxGeographicalAccuracy.Location = New System.Drawing.Point(522, 327)
        Me.ucrTextBoxGeographicalAccuracy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeographicalAccuracy.Name = "ucrTextBoxGeographicalAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Size = New System.Drawing.Size(174, 20)
        Me.ucrTextBoxGeographicalAccuracy.TabIndex = 34
        Me.ucrTextBoxGeographicalAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.TextboxValue = ""
        '
        'ucrTextBoxGraphicalMethod
        '
        Me.ucrTextBoxGraphicalMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.KeyControl = False
        Me.ucrTextBoxGraphicalMethod.Location = New System.Drawing.Point(522, 303)
        Me.ucrTextBoxGraphicalMethod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGraphicalMethod.Name = "ucrTextBoxGraphicalMethod"
        Me.ucrTextBoxGraphicalMethod.Size = New System.Drawing.Size(174, 20)
        Me.ucrTextBoxGraphicalMethod.TabIndex = 32
        Me.ucrTextBoxGraphicalMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.TextboxValue = ""
        '
        'ucrTextBoxQualifier
        '
        Me.ucrTextBoxQualifier.FieldName = "qualifier"
        Me.ucrTextBoxQualifier.KeyControl = False
        Me.ucrTextBoxQualifier.Location = New System.Drawing.Point(522, 227)
        Me.ucrTextBoxQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxQualifier.Name = "ucrTextBoxQualifier"
        Me.ucrTextBoxQualifier.Size = New System.Drawing.Size(162, 20)
        Me.ucrTextBoxQualifier.TabIndex = 26
        Me.ucrTextBoxQualifier.Tag = "qualifier"
        Me.ucrTextBoxQualifier.TextboxValue = ""
        '
        'ucrTextBoxDrainageBasin
        '
        Me.ucrTextBoxDrainageBasin.FieldName = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.KeyControl = False
        Me.ucrTextBoxDrainageBasin.Location = New System.Drawing.Point(120, 356)
        Me.ucrTextBoxDrainageBasin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDrainageBasin.Name = "ucrTextBoxDrainageBasin"
        Me.ucrTextBoxDrainageBasin.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxDrainageBasin.TabIndex = 22
        Me.ucrTextBoxDrainageBasin.Tag = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.TextboxValue = ""
        '
        'ucrTextBoxAdminRegion
        '
        Me.ucrTextBoxAdminRegion.FieldName = "adminRegion"
        Me.ucrTextBoxAdminRegion.KeyControl = False
        Me.ucrTextBoxAdminRegion.Location = New System.Drawing.Point(121, 327)
        Me.ucrTextBoxAdminRegion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAdminRegion.Name = "ucrTextBoxAdminRegion"
        Me.ucrTextBoxAdminRegion.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxAdminRegion.TabIndex = 20
        Me.ucrTextBoxAdminRegion.Tag = "adminRegion"
        Me.ucrTextBoxAdminRegion.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.FieldName = "authority"
        Me.ucrTextBoxAuthority.KeyControl = False
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(121, 303)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxAuthority.TabIndex = 18
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrTextBoxCountry
        '
        Me.ucrTextBoxCountry.FieldName = "country"
        Me.ucrTextBoxCountry.KeyControl = False
        Me.ucrTextBoxCountry.Location = New System.Drawing.Point(120, 274)
        Me.ucrTextBoxCountry.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxCountry.Name = "ucrTextBoxCountry"
        Me.ucrTextBoxCountry.Size = New System.Drawing.Size(171, 20)
        Me.ucrTextBoxCountry.TabIndex = 16
        Me.ucrTextBoxCountry.Tag = "country"
        Me.ucrTextBoxCountry.TextboxValue = ""
        '
        'ucrICAOId
        '
        Me.ucrICAOId.FieldName = "icaoid"
        Me.ucrICAOId.KeyControl = False
        Me.ucrICAOId.Location = New System.Drawing.Point(120, 249)
        Me.ucrICAOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrICAOId.Name = "ucrICAOId"
        Me.ucrICAOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrICAOId.TabIndex = 14
        Me.ucrICAOId.Tag = "icaoid"
        Me.ucrICAOId.TextboxValue = ""
        '
        'ucrTextBoxWMOId
        '
        Me.ucrTextBoxWMOId.FieldName = "wmoid"
        Me.ucrTextBoxWMOId.KeyControl = False
        Me.ucrTextBoxWMOId.Location = New System.Drawing.Point(121, 222)
        Me.ucrTextBoxWMOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxWMOId.Name = "ucrTextBoxWMOId"
        Me.ucrTextBoxWMOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrTextBoxWMOId.TabIndex = 12
        Me.ucrTextBoxWMOId.Tag = "wmoid"
        Me.ucrTextBoxWMOId.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.KeyControl = False
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(121, 193)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(74, 20)
        Me.ucrTextBoxElevation.TabIndex = 10
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.FieldName = "longitude"
        Me.ucrTextBoxLongitude.KeyControl = False
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(121, 159)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(76, 21)
        Me.ucrTextBoxLongitude.TabIndex = 8
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.KeyControl = False
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(120, 134)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(77, 22)
        Me.ucrTextBoxLatitude.TabIndex = 6
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrStationIDcombobox
        '
        Me.ucrStationIDcombobox.FieldName = "stationId"
        Me.ucrStationIDcombobox.KeyControl = False
        Me.ucrStationIDcombobox.Location = New System.Drawing.Point(121, 72)
        Me.ucrStationIDcombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationIDcombobox.Name = "ucrStationIDcombobox"
        Me.ucrStationIDcombobox.Size = New System.Drawing.Size(139, 21)
        Me.ucrStationIDcombobox.TabIndex = 2
        Me.ucrStationIDcombobox.Tag = "stationId"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(404, 227)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 13)
        Me.Label24.TabIndex = 25
        Me.Label24.Text = "Qualifier"
        '
        'grpComputationDD
        '
        Me.grpComputationDD.BackColor = System.Drawing.Color.Snow
        Me.grpComputationDD.Controls.Add(Me.ucrDataLinkComboboxEW)
        Me.grpComputationDD.Controls.Add(Me.ucrDataLinkComboboxNS)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxSecondsLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxSecondsLatitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinutesLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinutesLatitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxDegreesLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxDegreesLatitude)
        Me.grpComputationDD.Controls.Add(Me.lblEW)
        Me.grpComputationDD.Controls.Add(Me.lblNS)
        Me.grpComputationDD.Controls.Add(Me.lblSecondsLon)
        Me.grpComputationDD.Controls.Add(Me.lblSecondsLat)
        Me.grpComputationDD.Controls.Add(Me.lblMinutesLon)
        Me.grpComputationDD.Controls.Add(Me.lblMinutesLat)
        Me.grpComputationDD.Controls.Add(Me.lblDegreesLon)
        Me.grpComputationDD.Controls.Add(Me.lblDegreesLat)
        Me.grpComputationDD.Location = New System.Drawing.Point(204, 121)
        Me.grpComputationDD.Name = "grpComputationDD"
        Me.grpComputationDD.Size = New System.Drawing.Size(455, 69)
        Me.grpComputationDD.TabIndex = 39
        Me.grpComputationDD.TabStop = False
        Me.grpComputationDD.Text = "Latitude and Longitude Decimal Degrees Computation"
        '
        'ucrDataLinkComboboxEW
        '
        Me.ucrDataLinkComboboxEW.FieldName = Nothing
        Me.ucrDataLinkComboboxEW.KeyControl = False
        Me.ucrDataLinkComboboxEW.Location = New System.Drawing.Point(395, 38)
        Me.ucrDataLinkComboboxEW.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkComboboxEW.Name = "ucrDataLinkComboboxEW"
        Me.ucrDataLinkComboboxEW.Size = New System.Drawing.Size(53, 21)
        Me.ucrDataLinkComboboxEW.TabIndex = 17
        '
        'ucrDataLinkComboboxNS
        '
        Me.ucrDataLinkComboboxNS.FieldName = Nothing
        Me.ucrDataLinkComboboxNS.KeyControl = False
        Me.ucrDataLinkComboboxNS.Location = New System.Drawing.Point(395, 15)
        Me.ucrDataLinkComboboxNS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkComboboxNS.Name = "ucrDataLinkComboboxNS"
        Me.ucrDataLinkComboboxNS.Size = New System.Drawing.Size(53, 21)
        Me.ucrDataLinkComboboxNS.TabIndex = 16
        '
        'ucrTextBoxSecondsLongitude
        '
        Me.ucrTextBoxSecondsLongitude.FieldName = Nothing
        Me.ucrTextBoxSecondsLongitude.KeyControl = False
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
        Me.ucrTextBoxSecondsLatitude.KeyControl = False
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
        Me.ucrTextBoxMinutesLongitude.KeyControl = False
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
        Me.ucrTextBoxMinutesLatitude.KeyControl = False
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
        Me.ucrTextBoxDegreesLongitude.KeyControl = False
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
        Me.ucrTextBoxDegreesLatitude.KeyControl = False
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
        Me.lblICAOid.TabIndex = 13
        Me.lblICAOid.Text = "ICAO Id"
        '
        'lblWMOid
        '
        Me.lblWMOid.AutoSize = True
        Me.lblWMOid.Location = New System.Drawing.Point(26, 227)
        Me.lblWMOid.Name = "lblWMOid"
        Me.lblWMOid.Size = New System.Drawing.Size(47, 13)
        Me.lblWMOid.TabIndex = 11
        Me.lblWMOid.Text = "WMO Id"
        '
        'lblSearchStation
        '
        Me.lblSearchStation.AutoSize = True
        Me.lblSearchStation.Location = New System.Drawing.Point(361, 68)
        Me.lblSearchStation.Name = "lblSearchStation"
        Me.lblSearchStation.Size = New System.Drawing.Size(108, 13)
        Me.lblSearchStation.TabIndex = 23
        Me.lblSearchStation.Text = "Search Station Name"
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
        Me.Panel2.TabIndex = 38
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(413, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(86, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(606, 0)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(112, 23)
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
        Me.btnView.Location = New System.Drawing.Point(505, 0)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(95, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(314, 0)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(84, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(204, 0)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(101, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(95, 23)
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
        Me.lblStationOperation.TabIndex = 35
        Me.lblStationOperation.Tag = ""
        Me.lblStationOperation.Text = "Station Operational"
        '
        'lbldarainage
        '
        Me.lbldarainage.AutoSize = True
        Me.lbldarainage.Location = New System.Drawing.Point(25, 357)
        Me.lbldarainage.Name = "lbldarainage"
        Me.lbldarainage.Size = New System.Drawing.Size(79, 13)
        Me.lbldarainage.TabIndex = 21
        Me.lbldarainage.Text = "Drainage Basin"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(27, 331)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(73, 13)
        Me.lblAdmin.TabIndex = 19
        Me.lblAdmin.Text = "Admin Region"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(27, 305)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 17
        Me.lblAuthority.Text = "Authority"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(28, 279)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 15
        Me.lblCountry.Text = "Country"
        '
        'lblClosingdate
        '
        Me.lblClosingdate.AutoSize = True
        Me.lblClosingdate.Location = New System.Drawing.Point(404, 279)
        Me.lblClosingdate.Name = "lblClosingdate"
        Me.lblClosingdate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingdate.TabIndex = 29
        Me.lblClosingdate.Text = "Closing Date"
        '
        'lblOpendate
        '
        Me.lblOpendate.AutoSize = True
        Me.lblOpendate.Location = New System.Drawing.Point(404, 253)
        Me.lblOpendate.Name = "lblOpendate"
        Me.lblOpendate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpendate.TabIndex = 27
        Me.lblOpendate.Text = "Opening Date"
        '
        'lblGeoAccuracy
        '
        Me.lblGeoAccuracy.AutoSize = True
        Me.lblGeoAccuracy.Location = New System.Drawing.Point(404, 331)
        Me.lblGeoAccuracy.Name = "lblGeoAccuracy"
        Me.lblGeoAccuracy.Size = New System.Drawing.Size(118, 13)
        Me.lblGeoAccuracy.TabIndex = 33
        Me.lblGeoAccuracy.Tag = ""
        Me.lblGeoAccuracy.Text = "Geographical Accuracy"
        '
        'lblGeoMethod
        '
        Me.lblGeoMethod.AutoSize = True
        Me.lblGeoMethod.Location = New System.Drawing.Point(404, 305)
        Me.lblGeoMethod.Name = "lblGeoMethod"
        Me.lblGeoMethod.Size = New System.Drawing.Size(109, 13)
        Me.lblGeoMethod.TabIndex = 31
        Me.lblGeoMethod.Tag = ""
        Me.lblGeoMethod.Text = "Geographical Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(24, 193)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(88, 13)
        Me.lblElevation.TabIndex = 9
        Me.lblElevation.Text = "Elevation(metres)"
        '
        'lblongitude
        '
        Me.lblongitude.AutoSize = True
        Me.lblongitude.Location = New System.Drawing.Point(24, 165)
        Me.lblongitude.Name = "lblongitude"
        Me.lblongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblongitude.TabIndex = 7
        Me.lblongitude.Text = "Longitude"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(24, 137)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 5
        Me.lblLatitude.Text = "Latitude"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Location = New System.Drawing.Point(26, 103)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(71, 13)
        Me.lblStationName.TabIndex = 3
        Me.lblStationName.Text = "Station Name"
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(24, 80)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(52, 13)
        Me.lblStationId.TabIndex = 1
        Me.lblStationId.Text = "Station Id"
        '
        'ucrSearchStationName
        '
        Me.ucrSearchStationName.FieldName = ""
        Me.ucrSearchStationName.KeyControl = False
        Me.ucrSearchStationName.Location = New System.Drawing.Point(475, 68)
        Me.ucrSearchStationName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSearchStationName.Name = "ucrSearchStationName"
        Me.ucrSearchStationName.Size = New System.Drawing.Size(253, 24)
        Me.ucrSearchStationName.TabIndex = 24
        Me.ucrSearchStationName.Tag = ""
        '
        'ucrCheckStationOperational
        '
        Me.ucrCheckStationOperational.CheckBoxText = ""
        Me.ucrCheckStationOperational.FieldName = "stationOperational"
        Me.ucrCheckStationOperational.KeyControl = False
        Me.ucrCheckStationOperational.Location = New System.Drawing.Point(522, 352)
        Me.ucrCheckStationOperational.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrCheckStationOperational.Name = "ucrCheckStationOperational"
        Me.ucrCheckStationOperational.Size = New System.Drawing.Size(179, 24)
        Me.ucrCheckStationOperational.TabIndex = 36
        Me.ucrCheckStationOperational.Tag = "stationOperational"
        '
        'ucrMetadataStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrCheckStationOperational)
        Me.Controls.Add(Me.ucrSearchStationName)
        Me.Controls.Add(Me.ucrStationName)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
    Friend WithEvents ucrStationName As ucrTextBox
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
    Friend WithEvents lblSecondsLon As Label
    Friend WithEvents lblSecondsLat As Label
    Friend WithEvents lblMinutesLon As Label
    Friend WithEvents lblMinutesLat As Label
    Friend WithEvents lblDegreesLon As Label
    Friend WithEvents lblDegreesLat As Label
    Friend WithEvents lblICAOid As Label
    Friend WithEvents lblWMOid As Label
    Friend WithEvents lblSearchStation As Label
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
    Friend WithEvents ucrCheckStationOperational As ucrCheck
    Friend WithEvents ucrDataLinkComboboxEW As ucrDataLinkCombobox
    Friend WithEvents ucrDataLinkComboboxNS As ucrDataLinkCombobox
End Class
