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
        Me.grpStation = New System.Windows.Forms.GroupBox()
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
        Me.ucrSearchStationNamecombobox = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrStationNamecombobox = New ClimsoftVer4.ucrDataLinkCombobox()
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
        Me.txtClosingDate = New System.Windows.Forms.TextBox()
        Me.txtOpeningDate = New System.Windows.Forms.TextBox()
        Me.lblICAOid = New System.Windows.Forms.Label()
        Me.lblWMOid = New System.Windows.Forms.Label()
        Me.lblSearchStation = New System.Windows.Forms.Label()
        Me.txtStationOperation = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdImport = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdViewStation = New System.Windows.Forms.Button()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdAddNew = New System.Windows.Forms.Button()
        Me.ClosingDate = New System.Windows.Forms.DateTimePicker()
        Me.OpenDate = New System.Windows.Forms.DateTimePicker()
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
        Me.ucrNavigationStation = New ClimsoftVer4.ucrNavigation()
        Me.lblStations = New System.Windows.Forms.Label()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStation.SuspendLayout()
        Me.grpComputationDD.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpStation
        '
        Me.grpStation.Controls.Add(Me.ucrTextBoxGeographicalAccuracy)
        Me.grpStation.Controls.Add(Me.ucrTextBoxGraphicalMethod)
        Me.grpStation.Controls.Add(Me.ucrTextBoxQualifier)
        Me.grpStation.Controls.Add(Me.ucrTextBoxDrainageBasin)
        Me.grpStation.Controls.Add(Me.ucrTextBoxAdminRegion)
        Me.grpStation.Controls.Add(Me.ucrTextBoxAuthority)
        Me.grpStation.Controls.Add(Me.ucrTextBoxCountry)
        Me.grpStation.Controls.Add(Me.ucrICAOId)
        Me.grpStation.Controls.Add(Me.ucrTextBoxWMOId)
        Me.grpStation.Controls.Add(Me.ucrTextBoxElevation)
        Me.grpStation.Controls.Add(Me.ucrTextBoxLongitude)
        Me.grpStation.Controls.Add(Me.ucrTextBoxLatitude)
        Me.grpStation.Controls.Add(Me.ucrSearchStationNamecombobox)
        Me.grpStation.Controls.Add(Me.ucrStationNamecombobox)
        Me.grpStation.Controls.Add(Me.ucrStationIDcombobox)
        Me.grpStation.Controls.Add(Me.Label24)
        Me.grpStation.Controls.Add(Me.grpComputationDD)
        Me.grpStation.Controls.Add(Me.txtClosingDate)
        Me.grpStation.Controls.Add(Me.txtOpeningDate)
        Me.grpStation.Controls.Add(Me.lblICAOid)
        Me.grpStation.Controls.Add(Me.lblWMOid)
        Me.grpStation.Controls.Add(Me.lblSearchStation)
        Me.grpStation.Controls.Add(Me.txtStationOperation)
        Me.grpStation.Controls.Add(Me.Panel2)
        Me.grpStation.Controls.Add(Me.ClosingDate)
        Me.grpStation.Controls.Add(Me.OpenDate)
        Me.grpStation.Controls.Add(Me.lblStationOperation)
        Me.grpStation.Controls.Add(Me.lbldarainage)
        Me.grpStation.Controls.Add(Me.lblAdmin)
        Me.grpStation.Controls.Add(Me.lblAuthority)
        Me.grpStation.Controls.Add(Me.lblCountry)
        Me.grpStation.Controls.Add(Me.lblClosingdate)
        Me.grpStation.Controls.Add(Me.lblOpendate)
        Me.grpStation.Controls.Add(Me.lblGeoAccuracy)
        Me.grpStation.Controls.Add(Me.lblGeoMethod)
        Me.grpStation.Controls.Add(Me.lblElevation)
        Me.grpStation.Controls.Add(Me.lblongitude)
        Me.grpStation.Controls.Add(Me.lblLatitude)
        Me.grpStation.Controls.Add(Me.lblStationName)
        Me.grpStation.Controls.Add(Me.lblStationId)
        Me.grpStation.Location = New System.Drawing.Point(4, 29)
        Me.grpStation.Name = "grpStation"
        Me.grpStation.Size = New System.Drawing.Size(727, 392)
        Me.grpStation.TabIndex = 15
        Me.grpStation.TabStop = False
        Me.grpStation.Text = "Station Details"
        '
        'ucrTextBoxGeographicalAccuracy
        '
        Me.ucrTextBoxGeographicalAccuracy.Location = New System.Drawing.Point(518, 275)
        Me.ucrTextBoxGeographicalAccuracy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeographicalAccuracy.Name = "ucrTextBoxGeographicalAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxGeographicalAccuracy.TabIndex = 80
        Me.ucrTextBoxGeographicalAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeographicalAccuracy.TextboxValue = ""
        '
        'ucrTextBoxGraphicalMethod
        '
        Me.ucrTextBoxGraphicalMethod.Location = New System.Drawing.Point(518, 251)
        Me.ucrTextBoxGraphicalMethod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGraphicalMethod.Name = "ucrTextBoxGraphicalMethod"
        Me.ucrTextBoxGraphicalMethod.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxGraphicalMethod.TabIndex = 79
        Me.ucrTextBoxGraphicalMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGraphicalMethod.TextboxValue = ""
        '
        'ucrTextBoxQualifier
        '
        Me.ucrTextBoxQualifier.Location = New System.Drawing.Point(481, 170)
        Me.ucrTextBoxQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxQualifier.Name = "ucrTextBoxQualifier"
        Me.ucrTextBoxQualifier.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxQualifier.TabIndex = 78
        Me.ucrTextBoxQualifier.Tag = "qualifier"
        Me.ucrTextBoxQualifier.TextboxValue = ""
        '
        'ucrTextBoxDrainageBasin
        '
        Me.ucrTextBoxDrainageBasin.Location = New System.Drawing.Point(116, 304)
        Me.ucrTextBoxDrainageBasin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDrainageBasin.Name = "ucrTextBoxDrainageBasin"
        Me.ucrTextBoxDrainageBasin.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxDrainageBasin.TabIndex = 77
        Me.ucrTextBoxDrainageBasin.Tag = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.TextboxValue = ""
        '
        'ucrTextBoxAdminRegion
        '
        Me.ucrTextBoxAdminRegion.Location = New System.Drawing.Point(117, 275)
        Me.ucrTextBoxAdminRegion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAdminRegion.Name = "ucrTextBoxAdminRegion"
        Me.ucrTextBoxAdminRegion.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxAdminRegion.TabIndex = 76
        Me.ucrTextBoxAdminRegion.Tag = "adminRegion"
        Me.ucrTextBoxAdminRegion.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(117, 251)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxAuthority.TabIndex = 75
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrTextBoxCountry
        '
        Me.ucrTextBoxCountry.Location = New System.Drawing.Point(116, 222)
        Me.ucrTextBoxCountry.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxCountry.Name = "ucrTextBoxCountry"
        Me.ucrTextBoxCountry.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxCountry.TabIndex = 74
        Me.ucrTextBoxCountry.Tag = "country"
        Me.ucrTextBoxCountry.TextboxValue = ""
        '
        'ucrICAOId
        '
        Me.ucrICAOId.Location = New System.Drawing.Point(116, 197)
        Me.ucrICAOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrICAOId.Name = "ucrICAOId"
        Me.ucrICAOId.Size = New System.Drawing.Size(51, 20)
        Me.ucrICAOId.TabIndex = 73
        Me.ucrICAOId.Tag = "icaoid"
        Me.ucrICAOId.TextboxValue = ""
        '
        'ucrTextBoxWMOId
        '
        Me.ucrTextBoxWMOId.Location = New System.Drawing.Point(117, 170)
        Me.ucrTextBoxWMOId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxWMOId.Name = "ucrTextBoxWMOId"
        Me.ucrTextBoxWMOId.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxWMOId.TabIndex = 72
        Me.ucrTextBoxWMOId.Tag = "wmoid"
        Me.ucrTextBoxWMOId.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(117, 141)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxElevation.TabIndex = 71
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(117, 107)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(76, 21)
        Me.ucrTextBoxLongitude.TabIndex = 70
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(116, 82)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(77, 18)
        Me.ucrTextBoxLatitude.TabIndex = 69
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrSearchStationNamecombobox
        '
        Me.ucrSearchStationNamecombobox.Location = New System.Drawing.Point(477, 16)
        Me.ucrSearchStationNamecombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSearchStationNamecombobox.Name = "ucrSearchStationNamecombobox"
        Me.ucrSearchStationNamecombobox.Size = New System.Drawing.Size(178, 21)
        Me.ucrSearchStationNamecombobox.TabIndex = 68
        '
        'ucrStationNamecombobox
        '
        Me.ucrStationNamecombobox.Location = New System.Drawing.Point(117, 43)
        Me.ucrStationNamecombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationNamecombobox.Name = "ucrStationNamecombobox"
        Me.ucrStationNamecombobox.Size = New System.Drawing.Size(178, 21)
        Me.ucrStationNamecombobox.TabIndex = 67
        Me.ucrStationNamecombobox.Tag = "stationName"
        '
        'ucrStationIDcombobox
        '
        Me.ucrStationIDcombobox.Location = New System.Drawing.Point(117, 20)
        Me.ucrStationIDcombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationIDcombobox.Name = "ucrStationIDcombobox"
        Me.ucrStationIDcombobox.Size = New System.Drawing.Size(178, 21)
        Me.ucrStationIDcombobox.TabIndex = 66
        Me.ucrStationIDcombobox.Tag = "stationId"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(400, 175)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 13)
        Me.Label24.TabIndex = 65
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
        Me.grpComputationDD.Location = New System.Drawing.Point(200, 69)
        Me.grpComputationDD.Name = "grpComputationDD"
        Me.grpComputationDD.Size = New System.Drawing.Size(455, 69)
        Me.grpComputationDD.TabIndex = 63
        Me.grpComputationDD.TabStop = False
        Me.grpComputationDD.Text = "Latitude and Longitude Decimal Degrees Computation"
        '
        'ucrTextBoxSecondsLongitude
        '
        Me.ucrTextBoxSecondsLongitude.Location = New System.Drawing.Point(295, 43)
        Me.ucrTextBoxSecondsLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxSecondsLongitude.Name = "ucrTextBoxSecondsLongitude"
        Me.ucrTextBoxSecondsLongitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxSecondsLongitude.TabIndex = 561
        Me.ucrTextBoxSecondsLongitude.TextboxValue = ""
        '
        'ucrTextBoxSecondsLatitude
        '
        Me.ucrTextBoxSecondsLatitude.Location = New System.Drawing.Point(295, 15)
        Me.ucrTextBoxSecondsLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxSecondsLatitude.Name = "ucrTextBoxSecondsLatitude"
        Me.ucrTextBoxSecondsLatitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxSecondsLatitude.TabIndex = 560
        Me.ucrTextBoxSecondsLatitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLongitude
        '
        Me.ucrTextBoxMinutesLongitude.Location = New System.Drawing.Point(173, 43)
        Me.ucrTextBoxMinutesLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxMinutesLongitude.Name = "ucrTextBoxMinutesLongitude"
        Me.ucrTextBoxMinutesLongitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxMinutesLongitude.TabIndex = 559
        Me.ucrTextBoxMinutesLongitude.TextboxValue = ""
        '
        'ucrTextBoxMinutesLatitude
        '
        Me.ucrTextBoxMinutesLatitude.Location = New System.Drawing.Point(173, 18)
        Me.ucrTextBoxMinutesLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxMinutesLatitude.Name = "ucrTextBoxMinutesLatitude"
        Me.ucrTextBoxMinutesLatitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxMinutesLatitude.TabIndex = 558
        Me.ucrTextBoxMinutesLatitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLongitude
        '
        Me.ucrTextBoxDegreesLongitude.Location = New System.Drawing.Point(56, 44)
        Me.ucrTextBoxDegreesLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDegreesLongitude.Name = "ucrTextBoxDegreesLongitude"
        Me.ucrTextBoxDegreesLongitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxDegreesLongitude.TabIndex = 557
        Me.ucrTextBoxDegreesLongitude.TextboxValue = ""
        '
        'ucrTextBoxDegreesLatitude
        '
        Me.ucrTextBoxDegreesLatitude.Location = New System.Drawing.Point(56, 18)
        Me.ucrTextBoxDegreesLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDegreesLatitude.Name = "ucrTextBoxDegreesLatitude"
        Me.ucrTextBoxDegreesLatitude.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxDegreesLatitude.TabIndex = 556
        Me.ucrTextBoxDegreesLatitude.TextboxValue = ""
        '
        'lblEW
        '
        Me.lblEW.AutoSize = True
        Me.lblEW.Location = New System.Drawing.Point(356, 46)
        Me.lblEW.Name = "lblEW"
        Me.lblEW.Size = New System.Drawing.Size(30, 13)
        Me.lblEW.TabIndex = 65
        Me.lblEW.Text = "E/W"
        '
        'lblNS
        '
        Me.lblNS.AutoSize = True
        Me.lblNS.Location = New System.Drawing.Point(359, 18)
        Me.lblNS.Name = "lblNS"
        Me.lblNS.Size = New System.Drawing.Size(27, 13)
        Me.lblNS.TabIndex = 64
        Me.lblNS.Text = "N/S"
        '
        'lstEW
        '
        Me.lstEW.FormattingEnabled = True
        Me.lstEW.Items.AddRange(New Object() {"E", "W"})
        Me.lstEW.Location = New System.Drawing.Point(395, 42)
        Me.lstEW.Name = "lstEW"
        Me.lstEW.Size = New System.Drawing.Size(41, 21)
        Me.lstEW.TabIndex = 57
        '
        'lstNS
        '
        Me.lstNS.FormattingEnabled = True
        Me.lstNS.Items.AddRange(New Object() {"N", "S"})
        Me.lstNS.Location = New System.Drawing.Point(395, 15)
        Me.lstNS.Name = "lstNS"
        Me.lstNS.Size = New System.Drawing.Size(41, 21)
        Me.lstNS.TabIndex = 53
        '
        'lblSecondsLon
        '
        Me.lblSecondsLon.AutoSize = True
        Me.lblSecondsLon.Location = New System.Drawing.Point(242, 46)
        Me.lblSecondsLon.Name = "lblSecondsLon"
        Me.lblSecondsLon.Size = New System.Drawing.Size(49, 13)
        Me.lblSecondsLon.TabIndex = 61
        Me.lblSecondsLon.Text = "Seconds"
        '
        'lblSecondsLat
        '
        Me.lblSecondsLat.AutoSize = True
        Me.lblSecondsLat.Location = New System.Drawing.Point(243, 18)
        Me.lblSecondsLat.Name = "lblSecondsLat"
        Me.lblSecondsLat.Size = New System.Drawing.Size(49, 13)
        Me.lblSecondsLat.TabIndex = 59
        Me.lblSecondsLat.Text = "Seconds"
        '
        'lblMinutesLon
        '
        Me.lblMinutesLon.AutoSize = True
        Me.lblMinutesLon.Location = New System.Drawing.Point(123, 46)
        Me.lblMinutesLon.Name = "lblMinutesLon"
        Me.lblMinutesLon.Size = New System.Drawing.Size(44, 13)
        Me.lblMinutesLon.TabIndex = 57
        Me.lblMinutesLon.Text = "Minutes"
        '
        'lblMinutesLat
        '
        Me.lblMinutesLat.AutoSize = True
        Me.lblMinutesLat.Location = New System.Drawing.Point(124, 18)
        Me.lblMinutesLat.Name = "lblMinutesLat"
        Me.lblMinutesLat.Size = New System.Drawing.Size(44, 13)
        Me.lblMinutesLat.TabIndex = 555
        Me.lblMinutesLat.Text = "Minutes"
        '
        'lblDegreesLon
        '
        Me.lblDegreesLon.AutoSize = True
        Me.lblDegreesLon.Location = New System.Drawing.Point(3, 46)
        Me.lblDegreesLon.Name = "lblDegreesLon"
        Me.lblDegreesLon.Size = New System.Drawing.Size(47, 13)
        Me.lblDegreesLon.TabIndex = 533
        Me.lblDegreesLon.Text = "Degrees"
        '
        'lblDegreesLat
        '
        Me.lblDegreesLat.AutoSize = True
        Me.lblDegreesLat.Location = New System.Drawing.Point(4, 18)
        Me.lblDegreesLat.Name = "lblDegreesLat"
        Me.lblDegreesLat.Size = New System.Drawing.Size(47, 13)
        Me.lblDegreesLat.TabIndex = 511
        Me.lblDegreesLat.Text = "Degrees"
        '
        'txtClosingDate
        '
        Me.txtClosingDate.Location = New System.Drawing.Point(518, 223)
        Me.txtClosingDate.Name = "txtClosingDate"
        Me.txtClosingDate.Size = New System.Drawing.Size(162, 20)
        Me.txtClosingDate.TabIndex = 13
        Me.txtClosingDate.Tag = "closingDatetime"
        '
        'txtOpeningDate
        '
        Me.txtOpeningDate.Location = New System.Drawing.Point(518, 197)
        Me.txtOpeningDate.Name = "txtOpeningDate"
        Me.txtOpeningDate.Size = New System.Drawing.Size(162, 20)
        Me.txtOpeningDate.TabIndex = 12
        Me.txtOpeningDate.Tag = "openingDatetime"
        '
        'lblICAOid
        '
        Me.lblICAOid.AutoSize = True
        Me.lblICAOid.Location = New System.Drawing.Point(23, 201)
        Me.lblICAOid.Name = "lblICAOid"
        Me.lblICAOid.Size = New System.Drawing.Size(44, 13)
        Me.lblICAOid.TabIndex = 55
        Me.lblICAOid.Text = "ICAO Id"
        '
        'lblWMOid
        '
        Me.lblWMOid.AutoSize = True
        Me.lblWMOid.Location = New System.Drawing.Point(22, 175)
        Me.lblWMOid.Name = "lblWMOid"
        Me.lblWMOid.Size = New System.Drawing.Size(47, 13)
        Me.lblWMOid.TabIndex = 54
        Me.lblWMOid.Text = "WMO Id"
        '
        'lblSearchStation
        '
        Me.lblSearchStation.AutoSize = True
        Me.lblSearchStation.Location = New System.Drawing.Point(357, 16)
        Me.lblSearchStation.Name = "lblSearchStation"
        Me.lblSearchStation.Size = New System.Drawing.Size(108, 13)
        Me.lblSearchStation.TabIndex = 39
        Me.lblSearchStation.Text = "Search Station Name"
        '
        'txtStationOperation
        '
        Me.txtStationOperation.AutoSize = True
        Me.txtStationOperation.Location = New System.Drawing.Point(518, 304)
        Me.txtStationOperation.Name = "txtStationOperation"
        Me.txtStationOperation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStationOperation.Size = New System.Drawing.Size(15, 14)
        Me.txtStationOperation.TabIndex = 16
        Me.txtStationOperation.Tag = "stationOperational"
        Me.txtStationOperation.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.txtStationOperation.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.cmdImport)
        Me.Panel2.Controls.Add(Me.cmdClear)
        Me.Panel2.Controls.Add(Me.cmdViewStation)
        Me.Panel2.Controls.Add(Me.cmdDelete)
        Me.Panel2.Controls.Add(Me.cmdUpdate)
        Me.Panel2.Controls.Add(Me.cmdAddNew)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 360)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(721, 29)
        Me.Panel2.TabIndex = 37
        '
        'cmdImport
        '
        Me.cmdImport.Location = New System.Drawing.Point(597, 0)
        Me.cmdImport.Name = "cmdImport"
        Me.cmdImport.Size = New System.Drawing.Size(64, 27)
        Me.cmdImport.TabIndex = 20
        Me.cmdImport.Text = "Import"
        Me.cmdImport.UseVisualStyleBackColor = True
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(47, 0)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(64, 27)
        Me.cmdClear.TabIndex = 15
        Me.cmdClear.Text = "AddNew"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewStation
        '
        Me.cmdViewStation.Location = New System.Drawing.Point(487, 0)
        Me.cmdViewStation.Name = "cmdViewStation"
        Me.cmdViewStation.Size = New System.Drawing.Size(64, 27)
        Me.cmdViewStation.TabIndex = 19
        Me.cmdViewStation.Text = "View"
        Me.cmdViewStation.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(377, 0)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(64, 27)
        Me.cmdDelete.TabIndex = 18
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(267, 0)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(64, 27)
        Me.cmdUpdate.TabIndex = 17
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdAddNew
        '
        Me.cmdAddNew.Location = New System.Drawing.Point(157, 0)
        Me.cmdAddNew.Name = "cmdAddNew"
        Me.cmdAddNew.Size = New System.Drawing.Size(64, 27)
        Me.cmdAddNew.TabIndex = 17
        Me.cmdAddNew.Text = "Save"
        Me.cmdAddNew.UseVisualStyleBackColor = True
        '
        'ClosingDate
        '
        Me.ClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ClosingDate.Location = New System.Drawing.Point(673, 223)
        Me.ClosingDate.Name = "ClosingDate"
        Me.ClosingDate.Size = New System.Drawing.Size(27, 20)
        Me.ClosingDate.TabIndex = 22
        '
        'OpenDate
        '
        Me.OpenDate.Checked = False
        Me.OpenDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.OpenDate.Location = New System.Drawing.Point(673, 197)
        Me.OpenDate.Name = "OpenDate"
        Me.OpenDate.Size = New System.Drawing.Size(27, 20)
        Me.OpenDate.TabIndex = 21
        '
        'lblStationOperation
        '
        Me.lblStationOperation.AutoSize = True
        Me.lblStationOperation.Location = New System.Drawing.Point(400, 305)
        Me.lblStationOperation.Name = "lblStationOperation"
        Me.lblStationOperation.Size = New System.Drawing.Size(97, 13)
        Me.lblStationOperation.TabIndex = 48
        Me.lblStationOperation.Tag = ""
        Me.lblStationOperation.Text = "Station Operational"
        '
        'lbldarainage
        '
        Me.lbldarainage.AutoSize = True
        Me.lbldarainage.Location = New System.Drawing.Point(21, 305)
        Me.lbldarainage.Name = "lbldarainage"
        Me.lbldarainage.Size = New System.Drawing.Size(79, 13)
        Me.lbldarainage.TabIndex = 45
        Me.lbldarainage.Text = "Drainage Basin"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(23, 279)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(73, 13)
        Me.lblAdmin.TabIndex = 44
        Me.lblAdmin.Text = "Admin Region"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(23, 253)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 43
        Me.lblAuthority.Text = "Authority"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(24, 227)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 42
        Me.lblCountry.Text = "Country"
        '
        'lblClosingdate
        '
        Me.lblClosingdate.AutoSize = True
        Me.lblClosingdate.Location = New System.Drawing.Point(400, 227)
        Me.lblClosingdate.Name = "lblClosingdate"
        Me.lblClosingdate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingdate.TabIndex = 47
        Me.lblClosingdate.Text = "Closing Date"
        '
        'lblOpendate
        '
        Me.lblOpendate.AutoSize = True
        Me.lblOpendate.Location = New System.Drawing.Point(400, 201)
        Me.lblOpendate.Name = "lblOpendate"
        Me.lblOpendate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpendate.TabIndex = 46
        Me.lblOpendate.Text = "Opening Date"
        '
        'lblGeoAccuracy
        '
        Me.lblGeoAccuracy.AutoSize = True
        Me.lblGeoAccuracy.Location = New System.Drawing.Point(400, 279)
        Me.lblGeoAccuracy.Name = "lblGeoAccuracy"
        Me.lblGeoAccuracy.Size = New System.Drawing.Size(118, 13)
        Me.lblGeoAccuracy.TabIndex = 53
        Me.lblGeoAccuracy.Tag = ""
        Me.lblGeoAccuracy.Text = "Geographical Accuracy"
        '
        'lblGeoMethod
        '
        Me.lblGeoMethod.AutoSize = True
        Me.lblGeoMethod.Location = New System.Drawing.Point(400, 253)
        Me.lblGeoMethod.Name = "lblGeoMethod"
        Me.lblGeoMethod.Size = New System.Drawing.Size(109, 13)
        Me.lblGeoMethod.TabIndex = 52
        Me.lblGeoMethod.Tag = ""
        Me.lblGeoMethod.Text = "Geographical Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(20, 141)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(88, 13)
        Me.lblElevation.TabIndex = 51
        Me.lblElevation.Text = "Elevation(metres)"
        '
        'lblongitude
        '
        Me.lblongitude.AutoSize = True
        Me.lblongitude.Location = New System.Drawing.Point(20, 113)
        Me.lblongitude.Name = "lblongitude"
        Me.lblongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblongitude.TabIndex = 50
        Me.lblongitude.Text = "Longitude"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(20, 85)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 49
        Me.lblLatitude.Text = "Latitude"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Location = New System.Drawing.Point(22, 51)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(71, 13)
        Me.lblStationName.TabIndex = 41
        Me.lblStationName.Text = "Station Name"
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(20, 28)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(52, 13)
        Me.lblStationId.TabIndex = 40
        Me.lblStationId.Text = "Station Id"
        '
        'ucrNavigationStation
        '
        Me.ucrNavigationStation.Location = New System.Drawing.Point(164, 428)
        Me.ucrNavigationStation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStation.Name = "ucrNavigationStation"
        Me.ucrNavigationStation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStation.TabIndex = 16
        '
        'lblStations
        '
        Me.lblStations.AutoSize = True
        Me.lblStations.Location = New System.Drawing.Point(311, 0)
        Me.lblStations.Name = "lblStations"
        Me.lblStations.Size = New System.Drawing.Size(45, 13)
        Me.lblStations.TabIndex = 17
        Me.lblStations.Text = "Stations"
        '
        'ucrMetadataStation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblStations)
        Me.Controls.Add(Me.ucrNavigationStation)
        Me.Controls.Add(Me.grpStation)
        Me.Name = "ucrMetadataStation"
        Me.Size = New System.Drawing.Size(734, 451)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStation.ResumeLayout(False)
        Me.grpStation.PerformLayout()
        Me.grpComputationDD.ResumeLayout(False)
        Me.grpComputationDD.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpStation As GroupBox
    Friend WithEvents Label24 As Label
    Friend WithEvents grpComputationDD As GroupBox
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
    Friend WithEvents txtClosingDate As TextBox
    Friend WithEvents txtOpeningDate As TextBox
    Friend WithEvents lblICAOid As Label
    Friend WithEvents lblWMOid As Label
    Friend WithEvents lblSearchStation As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmdImport As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents cmdViewStation As Button
    Friend WithEvents cmdDelete As Button
    Friend WithEvents cmdUpdate As Button
    Friend WithEvents cmdAddNew As Button
    Friend WithEvents ClosingDate As DateTimePicker
    Friend WithEvents OpenDate As DateTimePicker
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
    Friend WithEvents ucrTextBoxWMOId As ucrTextBox
    Friend WithEvents ucrTextBoxElevation As ucrTextBox
    Friend WithEvents ucrTextBoxLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxLatitude As ucrTextBox
    Friend WithEvents ucrSearchStationNamecombobox As ucrDataLinkCombobox
    Friend WithEvents ucrStationNamecombobox As ucrDataLinkCombobox
    Friend WithEvents ucrStationIDcombobox As ucrDataLinkCombobox
    Friend WithEvents ucrTextBoxQualifier As ucrTextBox
    Friend WithEvents ucrTextBoxDrainageBasin As ucrTextBox
    Friend WithEvents ucrTextBoxAdminRegion As ucrTextBox
    Friend WithEvents ucrTextBoxAuthority As ucrTextBox
    Friend WithEvents ucrTextBoxCountry As ucrTextBox
    Friend WithEvents ucrICAOId As ucrTextBox
    Friend WithEvents ucrTextBoxSecondsLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxSecondsLatitude As ucrTextBox
    Friend WithEvents ucrTextBoxMinutesLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxMinutesLatitude As ucrTextBox
    Friend WithEvents ucrTextBoxDegreesLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxDegreesLatitude As ucrTextBox
    Friend WithEvents ucrNavigationStation As ucrNavigation
    Friend WithEvents ucrTextBoxGeographicalAccuracy As ucrTextBox
    Friend WithEvents ucrTextBoxGraphicalMethod As ucrTextBox
    Friend WithEvents txtStationOperation As CheckBox
    Friend WithEvents lblStations As Label
End Class
