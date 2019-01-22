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
        Me.ucrDataLinkComboboxNS = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrDataLinkComboboxEW = New ClimsoftVer4.ucrDataLinkCombobox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpComputationDD.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrNavigationStation
        '
        Me.ucrNavigationStation.Location = New System.Drawing.Point(298, 695)
        Me.ucrNavigationStation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigationStation.Name = "ucrNavigationStation"
        Me.ucrNavigationStation.Size = New System.Drawing.Size(504, 38)
        Me.ucrNavigationStation.TabIndex = 2
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.Location = New System.Drawing.Point(495, 9)
        Me.lblStation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 22)
        Me.lblStation.TabIndex = 0
        Me.lblStation.Text = "Station"
        '
        'ucrStationName
        '
        Me.ucrStationName.FieldName = "stationName"
        Me.ucrStationName.Location = New System.Drawing.Point(182, 146)
        Me.ucrStationName.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrStationName.Name = "ucrStationName"
        Me.ucrStationName.Size = New System.Drawing.Size(342, 32)
        Me.ucrStationName.TabIndex = 76
        Me.ucrStationName.Tag = "stationName"
        Me.ucrStationName.TextboxValue = ""
        '
        'ucrDatePickerClosingDate
        '
        Me.ucrDatePickerClosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerClosingDate.Location = New System.Drawing.Point(783, 420)
        Me.ucrDatePickerClosingDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerClosingDate.Name = "ucrDatePickerClosingDate"
        Me.ucrDatePickerClosingDate.Size = New System.Drawing.Size(261, 32)
        Me.ucrDatePickerClosingDate.TabIndex = 68
        Me.ucrDatePickerClosingDate.Tag = "closingDatetime"
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(783, 383)
        Me.ucrDatePickerOpeningDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(261, 32)
        Me.ucrDatePickerOpeningDate.TabIndex = 66
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrTextBoxGeographicalAccuracy
        '
        Me.ucrTextBoxGeographicalAccuracy.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Location = New System.Drawing.Point(783, 503)
        Me.ucrTextBoxGeographicalAccuracy.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxGeographicalAccuracy.Name = "ucrTextBoxGeographicalAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Size = New System.Drawing.Size(261, 31)
        Me.ucrTextBoxGeographicalAccuracy.TabIndex = 72
        Me.ucrTextBoxGeographicalAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.TextboxValue = ""
        '
        'ucrTextBoxGraphicalMethod
        '
        Me.ucrTextBoxGraphicalMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.Location = New System.Drawing.Point(783, 466)
        Me.ucrTextBoxGraphicalMethod.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxGraphicalMethod.Name = "ucrTextBoxGraphicalMethod"
        Me.ucrTextBoxGraphicalMethod.Size = New System.Drawing.Size(261, 31)
        Me.ucrTextBoxGraphicalMethod.TabIndex = 70
        Me.ucrTextBoxGraphicalMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.TextboxValue = ""
        '
        'ucrTextBoxQualifier
        '
        Me.ucrTextBoxQualifier.FieldName = "qualifier"

        Me.ucrTextBoxQualifier.Location = New System.Drawing.Point(783, 349)
        Me.ucrTextBoxQualifier.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)

        Me.ucrTextBoxQualifier.Name = "ucrTextBoxQualifier"
        Me.ucrTextBoxQualifier.Size = New System.Drawing.Size(243, 31)
        Me.ucrTextBoxQualifier.TabIndex = 64
        Me.ucrTextBoxQualifier.Tag = "qualifier"
        Me.ucrTextBoxQualifier.TextboxValue = ""
        '
        'ucrTextBoxDrainageBasin
        '
        Me.ucrTextBoxDrainageBasin.FieldName = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.Location = New System.Drawing.Point(180, 548)
        Me.ucrTextBoxDrainageBasin.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxDrainageBasin.Name = "ucrTextBoxDrainageBasin"
        Me.ucrTextBoxDrainageBasin.Size = New System.Drawing.Size(256, 31)
        Me.ucrTextBoxDrainageBasin.TabIndex = 62
        Me.ucrTextBoxDrainageBasin.Tag = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.TextboxValue = ""
        '
        'ucrTextBoxAdminRegion
        '
        Me.ucrTextBoxAdminRegion.FieldName = "adminRegion"
        Me.ucrTextBoxAdminRegion.Location = New System.Drawing.Point(182, 503)
        Me.ucrTextBoxAdminRegion.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxAdminRegion.Name = "ucrTextBoxAdminRegion"
        Me.ucrTextBoxAdminRegion.Size = New System.Drawing.Size(256, 31)
        Me.ucrTextBoxAdminRegion.TabIndex = 60
        Me.ucrTextBoxAdminRegion.Tag = "adminRegion"
        Me.ucrTextBoxAdminRegion.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.FieldName = "authority"
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(182, 466)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(256, 31)
        Me.ucrTextBoxAuthority.TabIndex = 58
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrTextBoxCountry
        '
        Me.ucrTextBoxCountry.FieldName = "country"
        Me.ucrTextBoxCountry.Location = New System.Drawing.Point(180, 422)
        Me.ucrTextBoxCountry.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxCountry.Name = "ucrTextBoxCountry"
        Me.ucrTextBoxCountry.Size = New System.Drawing.Size(256, 31)
        Me.ucrTextBoxCountry.TabIndex = 56
        Me.ucrTextBoxCountry.Tag = "country"
        Me.ucrTextBoxCountry.TextboxValue = ""
        '
        'ucrICAOId
        '
        Me.ucrICAOId.FieldName = "icaoid"
        Me.ucrICAOId.Location = New System.Drawing.Point(180, 383)
        Me.ucrICAOId.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrICAOId.Name = "ucrICAOId"
        Me.ucrICAOId.Size = New System.Drawing.Size(153, 31)
        Me.ucrICAOId.TabIndex = 54
        Me.ucrICAOId.Tag = "icaoid"
        Me.ucrICAOId.TextboxValue = ""
        '
        'ucrTextBoxWMOId
        '
        Me.ucrTextBoxWMOId.FieldName = "wmoid"
        Me.ucrTextBoxWMOId.Location = New System.Drawing.Point(182, 342)
        Me.ucrTextBoxWMOId.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxWMOId.Name = "ucrTextBoxWMOId"
        Me.ucrTextBoxWMOId.Size = New System.Drawing.Size(153, 31)
        Me.ucrTextBoxWMOId.TabIndex = 52
        Me.ucrTextBoxWMOId.Tag = "wmoid"
        Me.ucrTextBoxWMOId.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(182, 297)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(111, 31)
        Me.ucrTextBoxElevation.TabIndex = 50
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.FieldName = "longitude"
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(182, 245)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(114, 32)
        Me.ucrTextBoxLongitude.TabIndex = 47
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(180, 206)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(116, 34)
        Me.ucrTextBoxLatitude.TabIndex = 45
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrStationIDcombobox
        '
        Me.ucrStationIDcombobox.FieldName = "stationId"

        Me.ucrStationIDcombobox.Location = New System.Drawing.Point(182, 111)
        Me.ucrStationIDcombobox.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)

        Me.ucrStationIDcombobox.Name = "ucrStationIDcombobox"
        Me.ucrStationIDcombobox.Size = New System.Drawing.Size(208, 32)
        Me.ucrStationIDcombobox.TabIndex = 40
        Me.ucrStationIDcombobox.Tag = "stationId"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(606, 349)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(67, 20)
        Me.Label24.TabIndex = 63
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
        Me.grpComputationDD.Location = New System.Drawing.Point(306, 186)
        Me.grpComputationDD.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpComputationDD.Name = "grpComputationDD"
        Me.grpComputationDD.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpComputationDD.Size = New System.Drawing.Size(682, 106)
        Me.grpComputationDD.TabIndex = 48
        Me.grpComputationDD.TabStop = False
        Me.grpComputationDD.Text = "Latitude and Longitude Decimal Degrees Computation"
        '
        'ucrTextBoxSecondsLongitude
        '
        Me.ucrTextBoxSecondsLongitude.FieldName = Nothing
        Me.ucrTextBoxSecondsLongitude.Location = New System.Drawing.Point(442, 66)
        Me.ucrTextBoxSecondsLongitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxSecondsLongitude.Name = "ucrTextBoxSecondsLongitude"
        Me.ucrTextBoxSecondsLongitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxSecondsLongitude.TabIndex = 13
        Me.ucrTextBoxSecondsLongitude.TextboxValue = ""
        '
        'ucrTextBoxSecondsLatitude
        '
        Me.ucrTextBoxSecondsLatitude.FieldName = Nothing
        Me.ucrTextBoxSecondsLatitude.Location = New System.Drawing.Point(442, 23)
        Me.ucrTextBoxSecondsLatitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxSecondsLatitude.Name = "ucrTextBoxSecondsLatitude"
        Me.ucrTextBoxSecondsLatitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxSecondsLatitude.TabIndex = 5
        Me.ucrTextBoxSecondsLatitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLongitude
        '
        Me.ucrTextBoxMinutesLongitude.FieldName = Nothing
        Me.ucrTextBoxMinutesLongitude.Location = New System.Drawing.Point(260, 66)
        Me.ucrTextBoxMinutesLongitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxMinutesLongitude.Name = "ucrTextBoxMinutesLongitude"
        Me.ucrTextBoxMinutesLongitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxMinutesLongitude.TabIndex = 11
        Me.ucrTextBoxMinutesLongitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLatitude
        '
        Me.ucrTextBoxMinutesLatitude.FieldName = Nothing
        Me.ucrTextBoxMinutesLatitude.Location = New System.Drawing.Point(260, 28)
        Me.ucrTextBoxMinutesLatitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxMinutesLatitude.Name = "ucrTextBoxMinutesLatitude"
        Me.ucrTextBoxMinutesLatitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxMinutesLatitude.TabIndex = 3
        Me.ucrTextBoxMinutesLatitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLongitude
        '
        Me.ucrTextBoxDegreesLongitude.FieldName = Nothing
        Me.ucrTextBoxDegreesLongitude.Location = New System.Drawing.Point(84, 68)
        Me.ucrTextBoxDegreesLongitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxDegreesLongitude.Name = "ucrTextBoxDegreesLongitude"
        Me.ucrTextBoxDegreesLongitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxDegreesLongitude.TabIndex = 9
        Me.ucrTextBoxDegreesLongitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLatitude
        '
        Me.ucrTextBoxDegreesLatitude.FieldName = Nothing
        Me.ucrTextBoxDegreesLatitude.Location = New System.Drawing.Point(84, 28)
        Me.ucrTextBoxDegreesLatitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxDegreesLatitude.Name = "ucrTextBoxDegreesLatitude"
        Me.ucrTextBoxDegreesLatitude.Size = New System.Drawing.Size(88, 31)
        Me.ucrTextBoxDegreesLatitude.TabIndex = 1
        Me.ucrTextBoxDegreesLatitude.TextboxValue = ""
        '
        'lblEW
        '
        Me.lblEW.AutoSize = True
        Me.lblEW.Location = New System.Drawing.Point(534, 71)
        Me.lblEW.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEW.Name = "lblEW"
        Me.lblEW.Size = New System.Drawing.Size(39, 20)
        Me.lblEW.TabIndex = 14
        Me.lblEW.Text = "E/W"
        '
        'lblNS
        '
        Me.lblNS.AutoSize = True
        Me.lblNS.Location = New System.Drawing.Point(538, 28)
        Me.lblNS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNS.Name = "lblNS"
        Me.lblNS.Size = New System.Drawing.Size(35, 20)
        Me.lblNS.TabIndex = 6
        Me.lblNS.Text = "N/S"
        '
        'lblSecondsLon
        '
        Me.lblSecondsLon.AutoSize = True
        Me.lblSecondsLon.Location = New System.Drawing.Point(363, 71)
        Me.lblSecondsLon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSecondsLon.Name = "lblSecondsLon"
        Me.lblSecondsLon.Size = New System.Drawing.Size(72, 20)
        Me.lblSecondsLon.TabIndex = 12
        Me.lblSecondsLon.Text = "Seconds"
        '
        'lblSecondsLat
        '
        Me.lblSecondsLat.AutoSize = True
        Me.lblSecondsLat.Location = New System.Drawing.Point(364, 28)
        Me.lblSecondsLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSecondsLat.Name = "lblSecondsLat"
        Me.lblSecondsLat.Size = New System.Drawing.Size(72, 20)
        Me.lblSecondsLat.TabIndex = 4
        Me.lblSecondsLat.Text = "Seconds"
        '
        'lblMinutesLon
        '
        Me.lblMinutesLon.AutoSize = True
        Me.lblMinutesLon.Location = New System.Drawing.Point(184, 71)
        Me.lblMinutesLon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMinutesLon.Name = "lblMinutesLon"
        Me.lblMinutesLon.Size = New System.Drawing.Size(65, 20)
        Me.lblMinutesLon.TabIndex = 10
        Me.lblMinutesLon.Text = "Minutes"
        '
        'lblMinutesLat
        '
        Me.lblMinutesLat.AutoSize = True
        Me.lblMinutesLat.Location = New System.Drawing.Point(186, 28)
        Me.lblMinutesLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMinutesLat.Name = "lblMinutesLat"
        Me.lblMinutesLat.Size = New System.Drawing.Size(65, 20)
        Me.lblMinutesLat.TabIndex = 2
        Me.lblMinutesLat.Text = "Minutes"
        '
        'lblDegreesLon
        '
        Me.lblDegreesLon.AutoSize = True
        Me.lblDegreesLon.Location = New System.Drawing.Point(4, 71)
        Me.lblDegreesLon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDegreesLon.Name = "lblDegreesLon"
        Me.lblDegreesLon.Size = New System.Drawing.Size(70, 20)
        Me.lblDegreesLon.TabIndex = 8
        Me.lblDegreesLon.Text = "Degrees"
        '
        'lblDegreesLat
        '
        Me.lblDegreesLat.AutoSize = True
        Me.lblDegreesLat.Location = New System.Drawing.Point(6, 28)
        Me.lblDegreesLat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDegreesLat.Name = "lblDegreesLat"
        Me.lblDegreesLat.Size = New System.Drawing.Size(70, 20)
        Me.lblDegreesLat.TabIndex = 0
        Me.lblDegreesLat.Text = "Degrees"
        '
        'lblICAOid
        '
        Me.lblICAOid.AutoSize = True
        Me.lblICAOid.Location = New System.Drawing.Point(40, 389)
        Me.lblICAOid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblICAOid.Name = "lblICAOid"
        Me.lblICAOid.Size = New System.Drawing.Size(66, 20)
        Me.lblICAOid.TabIndex = 53
        Me.lblICAOid.Text = "ICAO Id"
        '
        'lblWMOid
        '
        Me.lblWMOid.AutoSize = True
        Me.lblWMOid.Location = New System.Drawing.Point(39, 349)
        Me.lblWMOid.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblWMOid.Name = "lblWMOid"
        Me.lblWMOid.Size = New System.Drawing.Size(67, 20)
        Me.lblWMOid.TabIndex = 51
        Me.lblWMOid.Text = "WMO Id"
        '
        'lblSearchStation
        '
        Me.lblSearchStation.AutoSize = True
        Me.lblSearchStation.Location = New System.Drawing.Point(542, 105)
        Me.lblSearchStation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchStation.Name = "lblSearchStation"
        Me.lblSearchStation.Size = New System.Drawing.Size(161, 20)
        Me.lblSearchStation.TabIndex = 42
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
        Me.Panel2.Location = New System.Drawing.Point(10, 634)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1082, 45)
        Me.Panel2.TabIndex = 75
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(636, 0)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(939, 0)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(112, 35)
        Me.btnImport.TabIndex = 6
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(30, 0)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 35)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(788, 0)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(112, 35)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(484, 0)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(333, 0)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(112, 35)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(182, 0)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblStationOperation
        '
        Me.lblStationOperation.AutoSize = True
        Me.lblStationOperation.Location = New System.Drawing.Point(606, 549)
        Me.lblStationOperation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationOperation.Name = "lblStationOperation"
        Me.lblStationOperation.Size = New System.Drawing.Size(146, 20)
        Me.lblStationOperation.TabIndex = 73
        Me.lblStationOperation.Tag = ""
        Me.lblStationOperation.Text = "Station Operational"
        '
        'lbldarainage
        '
        Me.lbldarainage.AutoSize = True
        Me.lbldarainage.Location = New System.Drawing.Point(38, 549)
        Me.lbldarainage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldarainage.Name = "lbldarainage"
        Me.lbldarainage.Size = New System.Drawing.Size(118, 20)
        Me.lbldarainage.TabIndex = 61
        Me.lbldarainage.Text = "Drainage Basin"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(40, 509)
        Me.lblAdmin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(109, 20)
        Me.lblAdmin.TabIndex = 59
        Me.lblAdmin.Text = "Admin Region"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(40, 469)
        Me.lblAuthority.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(72, 20)
        Me.lblAuthority.TabIndex = 57
        Me.lblAuthority.Text = "Authority"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(42, 429)
        Me.lblCountry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(64, 20)
        Me.lblCountry.TabIndex = 55
        Me.lblCountry.Text = "Country"
        '
        'lblClosingdate
        '
        Me.lblClosingdate.AutoSize = True
        Me.lblClosingdate.Location = New System.Drawing.Point(606, 429)
        Me.lblClosingdate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClosingdate.Name = "lblClosingdate"
        Me.lblClosingdate.Size = New System.Drawing.Size(100, 20)
        Me.lblClosingdate.TabIndex = 67
        Me.lblClosingdate.Text = "Closing Date"
        '
        'lblOpendate
        '
        Me.lblOpendate.AutoSize = True
        Me.lblOpendate.Location = New System.Drawing.Point(606, 389)
        Me.lblOpendate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOpendate.Name = "lblOpendate"
        Me.lblOpendate.Size = New System.Drawing.Size(108, 20)
        Me.lblOpendate.TabIndex = 65
        Me.lblOpendate.Text = "Opening Date"
        '
        'lblGeoAccuracy
        '
        Me.lblGeoAccuracy.AutoSize = True
        Me.lblGeoAccuracy.Location = New System.Drawing.Point(606, 509)
        Me.lblGeoAccuracy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGeoAccuracy.Name = "lblGeoAccuracy"
        Me.lblGeoAccuracy.Size = New System.Drawing.Size(173, 20)
        Me.lblGeoAccuracy.TabIndex = 71
        Me.lblGeoAccuracy.Tag = ""
        Me.lblGeoAccuracy.Text = "Geographical Accuracy"
        '
        'lblGeoMethod
        '
        Me.lblGeoMethod.AutoSize = True
        Me.lblGeoMethod.Location = New System.Drawing.Point(606, 469)
        Me.lblGeoMethod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGeoMethod.Name = "lblGeoMethod"
        Me.lblGeoMethod.Size = New System.Drawing.Size(162, 20)
        Me.lblGeoMethod.TabIndex = 69
        Me.lblGeoMethod.Tag = ""
        Me.lblGeoMethod.Text = "Geographical Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(36, 297)
        Me.lblElevation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(133, 20)
        Me.lblElevation.TabIndex = 49
        Me.lblElevation.Text = "Elevation(metres)"
        '
        'lblongitude
        '
        Me.lblongitude.AutoSize = True
        Me.lblongitude.Location = New System.Drawing.Point(36, 254)
        Me.lblongitude.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblongitude.Name = "lblongitude"
        Me.lblongitude.Size = New System.Drawing.Size(80, 20)
        Me.lblongitude.TabIndex = 46
        Me.lblongitude.Text = "Longitude"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(36, 211)
        Me.lblLatitude.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(67, 20)
        Me.lblLatitude.TabIndex = 44
        Me.lblLatitude.Text = "Latitude"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Location = New System.Drawing.Point(39, 158)
        Me.lblStationName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(106, 20)
        Me.lblStationName.TabIndex = 41
        Me.lblStationName.Text = "Station Name"
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True

        Me.lblStationId.Location = New System.Drawing.Point(36, 123)
        Me.lblStationId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)

        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(78, 20)
        Me.lblStationId.TabIndex = 39
        Me.lblStationId.Text = "Station Id"
        '
        'ucrSearchStationName
        '
        Me.ucrSearchStationName.FieldName = ""
        Me.ucrSearchStationName.Location = New System.Drawing.Point(712, 105)
        Me.ucrSearchStationName.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrSearchStationName.Name = "ucrSearchStationName"
        Me.ucrSearchStationName.Size = New System.Drawing.Size(380, 37)
        Me.ucrSearchStationName.TabIndex = 77
        Me.ucrSearchStationName.Tag = ""
        '
        'ucrCheckStationOperational
        '
        Me.ucrCheckStationOperational.CheckBoxText = ""
        Me.ucrCheckStationOperational.FieldName = "stationOperational"
        Me.ucrCheckStationOperational.Location = New System.Drawing.Point(783, 542)
        Me.ucrCheckStationOperational.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrCheckStationOperational.Name = "ucrCheckStationOperational"
        Me.ucrCheckStationOperational.Size = New System.Drawing.Size(268, 37)
        Me.ucrCheckStationOperational.TabIndex = 78
        Me.ucrCheckStationOperational.Tag = "stationOperational"
        '
        'ucrDataLinkComboboxNS
        '
        Me.ucrDataLinkComboboxNS.FieldName = Nothing
        Me.ucrDataLinkComboboxNS.Location = New System.Drawing.Point(592, 23)
        Me.ucrDataLinkComboboxNS.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkComboboxNS.Name = "ucrDataLinkComboboxNS"
        Me.ucrDataLinkComboboxNS.Size = New System.Drawing.Size(80, 32)
        Me.ucrDataLinkComboboxNS.TabIndex = 16
        '
        'ucrDataLinkComboboxEW
        '
        Me.ucrDataLinkComboboxEW.FieldName = Nothing
        Me.ucrDataLinkComboboxEW.Location = New System.Drawing.Point(592, 59)
        Me.ucrDataLinkComboboxEW.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkComboboxEW.Name = "ucrDataLinkComboboxEW"
        Me.ucrDataLinkComboboxEW.Size = New System.Drawing.Size(80, 32)
        Me.ucrDataLinkComboboxEW.TabIndex = 17
        '
        'ucrMetadataStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
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
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrMetadataStation"
        Me.Size = New System.Drawing.Size(1101, 783)
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
