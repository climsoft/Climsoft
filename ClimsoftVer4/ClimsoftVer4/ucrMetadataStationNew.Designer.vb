<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationNew
    Inherits ClimsoftVer4.ucrPage

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.lblStationName = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.lblongitude = New System.Windows.Forms.Label()
        Me.lblElevation = New System.Windows.Forms.Label()
        Me.lblWMOid = New System.Windows.Forms.Label()
        Me.lblICAOid = New System.Windows.Forms.Label()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.lblAdmin = New System.Windows.Forms.Label()
        Me.lbldarainage = New System.Windows.Forms.Label()
        Me.ucrIDComboBox = New ClimsoftVer4.ucrComboboxNew()
        Me.ucrStationName = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxAdminRegion = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxAuthority = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxCountry = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxICAOId = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxWMOId = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxElevation = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxLongitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxLatidue = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxQualifier = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxGeographicalMethod = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxGeographicalAccuracry = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxDrainageBasin = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblSearchStation = New System.Windows.Forms.Label()
        Me.UcrComboboxStationName = New ClimsoftVer4.ucrComboboxNew()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblOpendate = New System.Windows.Forms.Label()
        Me.lblClosingdate = New System.Windows.Forms.Label()
        Me.lblGeoMethod = New System.Windows.Forms.Label()
        Me.lblGeoAccuracy = New System.Windows.Forms.Label()
        Me.lblStationOperation = New System.Windows.Forms.Label()
        Me.UcrCheckboxNew1 = New ClimsoftVer4.ucrCheckboxNew()
        Me.UcrDatePickerOpeningDate = New ClimsoftVer4.ucrDatePickerNew()
        Me.UcrDatePickerClosing = New ClimsoftVer4.ucrDatePickerNew()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.grpComputationDD = New System.Windows.Forms.GroupBox()
        Me.lblEW = New System.Windows.Forms.Label()
        Me.lblNS = New System.Windows.Forms.Label()
        Me.lblSecondsLon = New System.Windows.Forms.Label()
        Me.lblSecondsLat = New System.Windows.Forms.Label()
        Me.lblMinutesLon = New System.Windows.Forms.Label()
        Me.lblMinutesLat = New System.Windows.Forms.Label()
        Me.lblDegreesLon = New System.Windows.Forms.Label()
        Me.lblDegreesLat = New System.Windows.Forms.Label()
        Me.UcrTextBoxDegreeLatitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxMinusLongitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxSecondsLatitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxMinusLatitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.ucrTextBoxDegreeLongitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrTextBoxSecondsLongitude = New ClimsoftVer4.ucrTextBoxNew()
        Me.UcrComboboxNS = New ClimsoftVer4.ucrComboboxNew()
        Me.UcrComboboxEW = New ClimsoftVer4.ucrComboboxNew()
        Me.UcrNavigatorStation = New ClimsoftVer4.ucrNavigator()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpComputationDD.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(24, 80)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(52, 13)
        Me.lblStationId.TabIndex = 2
        Me.lblStationId.Text = "Station Id"
        '
        'lblStationName
        '
        Me.lblStationName.AutoSize = True
        Me.lblStationName.Location = New System.Drawing.Point(26, 103)
        Me.lblStationName.Name = "lblStationName"
        Me.lblStationName.Size = New System.Drawing.Size(71, 13)
        Me.lblStationName.TabIndex = 4
        Me.lblStationName.Text = "Station Name"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(24, 137)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 6
        Me.lblLatitude.Text = "Latitude"
        '
        'lblongitude
        '
        Me.lblongitude.AutoSize = True
        Me.lblongitude.Location = New System.Drawing.Point(24, 165)
        Me.lblongitude.Name = "lblongitude"
        Me.lblongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblongitude.TabIndex = 8
        Me.lblongitude.Text = "Longitude"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(24, 193)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(88, 13)
        Me.lblElevation.TabIndex = 10
        Me.lblElevation.Text = "Elevation(metres)"
        '
        'lblWMOid
        '
        Me.lblWMOid.AutoSize = True
        Me.lblWMOid.Location = New System.Drawing.Point(26, 227)
        Me.lblWMOid.Name = "lblWMOid"
        Me.lblWMOid.Size = New System.Drawing.Size(47, 13)
        Me.lblWMOid.TabIndex = 12
        Me.lblWMOid.Text = "WMO Id"
        '
        'lblICAOid
        '
        Me.lblICAOid.AutoSize = True
        Me.lblICAOid.Location = New System.Drawing.Point(27, 253)
        Me.lblICAOid.Name = "lblICAOid"
        Me.lblICAOid.Size = New System.Drawing.Size(44, 13)
        Me.lblICAOid.TabIndex = 14
        Me.lblICAOid.Text = "ICAO Id"
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(28, 279)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(43, 13)
        Me.lblCountry.TabIndex = 16
        Me.lblCountry.Text = "Country"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(27, 305)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 18
        Me.lblAuthority.Text = "Authority"
        '
        'lblAdmin
        '
        Me.lblAdmin.AutoSize = True
        Me.lblAdmin.Location = New System.Drawing.Point(27, 331)
        Me.lblAdmin.Name = "lblAdmin"
        Me.lblAdmin.Size = New System.Drawing.Size(73, 13)
        Me.lblAdmin.TabIndex = 20
        Me.lblAdmin.Text = "Admin Region"
        '
        'lbldarainage
        '
        Me.lbldarainage.AutoSize = True
        Me.lbldarainage.Location = New System.Drawing.Point(25, 357)
        Me.lbldarainage.Name = "lbldarainage"
        Me.lbldarainage.Size = New System.Drawing.Size(79, 13)
        Me.lbldarainage.TabIndex = 22
        Me.lbldarainage.Text = "Drainage Basin"
        '
        'ucrIDComboBox
        '
        Me.ucrIDComboBox.Location = New System.Drawing.Point(121, 72)
        Me.ucrIDComboBox.Name = "ucrIDComboBox"
        Me.ucrIDComboBox.Size = New System.Drawing.Size(139, 21)
        Me.ucrIDComboBox.TabIndex = 23
        '
        'ucrStationName
        '
        Me.ucrStationName.Location = New System.Drawing.Point(121, 95)
        Me.ucrStationName.Name = "ucrStationName"
        Me.ucrStationName.Size = New System.Drawing.Size(228, 21)
        Me.ucrStationName.TabIndex = 24
        Me.ucrStationName.TextboxValue = ""
        '
        'UcrTextBoxAdminRegion
        '
        Me.UcrTextBoxAdminRegion.Location = New System.Drawing.Point(121, 327)
        Me.UcrTextBoxAdminRegion.Name = "UcrTextBoxAdminRegion"
        Me.UcrTextBoxAdminRegion.Size = New System.Drawing.Size(171, 20)
        Me.UcrTextBoxAdminRegion.TabIndex = 25
        Me.UcrTextBoxAdminRegion.TextboxValue = ""
        '
        'UcrTextBoxAuthority
        '
        Me.UcrTextBoxAuthority.Location = New System.Drawing.Point(121, 303)
        Me.UcrTextBoxAuthority.Name = "UcrTextBoxAuthority"
        Me.UcrTextBoxAuthority.Size = New System.Drawing.Size(171, 20)
        Me.UcrTextBoxAuthority.TabIndex = 26
        Me.UcrTextBoxAuthority.TextboxValue = ""
        '
        'UcrTextBoxCountry
        '
        Me.UcrTextBoxCountry.Location = New System.Drawing.Point(120, 274)
        Me.UcrTextBoxCountry.Name = "UcrTextBoxCountry"
        Me.UcrTextBoxCountry.Size = New System.Drawing.Size(171, 20)
        Me.UcrTextBoxCountry.TabIndex = 27
        Me.UcrTextBoxCountry.TextboxValue = ""
        '
        'ucrTextBoxICAOId
        '
        Me.ucrTextBoxICAOId.Location = New System.Drawing.Point(120, 249)
        Me.ucrTextBoxICAOId.Name = "ucrTextBoxICAOId"
        Me.ucrTextBoxICAOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrTextBoxICAOId.TabIndex = 28
        Me.ucrTextBoxICAOId.TextboxValue = ""
        '
        'ucrTextBoxWMOId
        '
        Me.ucrTextBoxWMOId.Location = New System.Drawing.Point(121, 222)
        Me.ucrTextBoxWMOId.Name = "ucrTextBoxWMOId"
        Me.ucrTextBoxWMOId.Size = New System.Drawing.Size(102, 20)
        Me.ucrTextBoxWMOId.TabIndex = 29
        Me.ucrTextBoxWMOId.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(121, 193)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(74, 20)
        Me.ucrTextBoxElevation.TabIndex = 30
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(121, 159)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(76, 21)
        Me.ucrTextBoxLongitude.TabIndex = 31
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxLatidue
        '
        Me.ucrTextBoxLatidue.Location = New System.Drawing.Point(120, 134)
        Me.ucrTextBoxLatidue.Name = "ucrTextBoxLatidue"
        Me.ucrTextBoxLatidue.Size = New System.Drawing.Size(77, 22)
        Me.ucrTextBoxLatidue.TabIndex = 32
        Me.ucrTextBoxLatidue.TextboxValue = ""
        '
        'UcrTextBoxQualifier
        '
        Me.UcrTextBoxQualifier.Location = New System.Drawing.Point(522, 227)
        Me.UcrTextBoxQualifier.Name = "UcrTextBoxQualifier"
        Me.UcrTextBoxQualifier.Size = New System.Drawing.Size(162, 20)
        Me.UcrTextBoxQualifier.TabIndex = 33
        Me.UcrTextBoxQualifier.TextboxValue = ""
        '
        'UcrTextBoxGeographicalMethod
        '
        Me.UcrTextBoxGeographicalMethod.Location = New System.Drawing.Point(522, 303)
        Me.UcrTextBoxGeographicalMethod.Name = "UcrTextBoxGeographicalMethod"
        Me.UcrTextBoxGeographicalMethod.Size = New System.Drawing.Size(171, 20)
        Me.UcrTextBoxGeographicalMethod.TabIndex = 34
        Me.UcrTextBoxGeographicalMethod.TextboxValue = ""
        '
        'UcrTextBoxGeographicalAccuracry
        '
        Me.UcrTextBoxGeographicalAccuracry.Location = New System.Drawing.Point(522, 327)
        Me.UcrTextBoxGeographicalAccuracry.Name = "UcrTextBoxGeographicalAccuracry"
        Me.UcrTextBoxGeographicalAccuracry.Size = New System.Drawing.Size(174, 20)
        Me.UcrTextBoxGeographicalAccuracry.TabIndex = 35
        Me.UcrTextBoxGeographicalAccuracry.TextboxValue = ""
        '
        'UcrTextBoxDrainageBasin
        '
        Me.UcrTextBoxDrainageBasin.Location = New System.Drawing.Point(120, 356)
        Me.UcrTextBoxDrainageBasin.Name = "UcrTextBoxDrainageBasin"
        Me.UcrTextBoxDrainageBasin.Size = New System.Drawing.Size(171, 20)
        Me.UcrTextBoxDrainageBasin.TabIndex = 36
        Me.UcrTextBoxDrainageBasin.TextboxValue = ""
        '
        'lblSearchStation
        '
        Me.lblSearchStation.AutoSize = True
        Me.lblSearchStation.Location = New System.Drawing.Point(361, 68)
        Me.lblSearchStation.Name = "lblSearchStation"
        Me.lblSearchStation.Size = New System.Drawing.Size(108, 13)
        Me.lblSearchStation.TabIndex = 37
        Me.lblSearchStation.Text = "Search Station Name"
        '
        'UcrComboboxStationName
        '
        Me.UcrComboboxStationName.Location = New System.Drawing.Point(475, 68)
        Me.UcrComboboxStationName.Name = "UcrComboboxStationName"
        Me.UcrComboboxStationName.Size = New System.Drawing.Size(253, 24)
        Me.UcrComboboxStationName.TabIndex = 38
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(404, 227)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 13)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Qualifier"
        '
        'lblOpendate
        '
        Me.lblOpendate.AutoSize = True
        Me.lblOpendate.Location = New System.Drawing.Point(404, 253)
        Me.lblOpendate.Name = "lblOpendate"
        Me.lblOpendate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpendate.TabIndex = 40
        Me.lblOpendate.Text = "Opening Date"
        '
        'lblClosingdate
        '
        Me.lblClosingdate.AutoSize = True
        Me.lblClosingdate.Location = New System.Drawing.Point(404, 279)
        Me.lblClosingdate.Name = "lblClosingdate"
        Me.lblClosingdate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingdate.TabIndex = 41
        Me.lblClosingdate.Text = "Closing Date"
        '
        'lblGeoMethod
        '
        Me.lblGeoMethod.AutoSize = True
        Me.lblGeoMethod.Location = New System.Drawing.Point(404, 305)
        Me.lblGeoMethod.Name = "lblGeoMethod"
        Me.lblGeoMethod.Size = New System.Drawing.Size(109, 13)
        Me.lblGeoMethod.TabIndex = 42
        Me.lblGeoMethod.Tag = ""
        Me.lblGeoMethod.Text = "Geographical Method"
        '
        'lblGeoAccuracy
        '
        Me.lblGeoAccuracy.AutoSize = True
        Me.lblGeoAccuracy.Location = New System.Drawing.Point(404, 331)
        Me.lblGeoAccuracy.Name = "lblGeoAccuracy"
        Me.lblGeoAccuracy.Size = New System.Drawing.Size(118, 13)
        Me.lblGeoAccuracy.TabIndex = 43
        Me.lblGeoAccuracy.Tag = ""
        Me.lblGeoAccuracy.Text = "Geographical Accuracy"
        '
        'lblStationOperation
        '
        Me.lblStationOperation.AutoSize = True
        Me.lblStationOperation.Location = New System.Drawing.Point(404, 357)
        Me.lblStationOperation.Name = "lblStationOperation"
        Me.lblStationOperation.Size = New System.Drawing.Size(97, 13)
        Me.lblStationOperation.TabIndex = 44
        Me.lblStationOperation.Tag = ""
        Me.lblStationOperation.Text = "Station Operational"
        '
        'UcrCheckboxNew1
        '
        Me.UcrCheckboxNew1.CheckBoxText = "CheckBox1"
        Me.UcrCheckboxNew1.Location = New System.Drawing.Point(522, 350)
        Me.UcrCheckboxNew1.Name = "UcrCheckboxNew1"
        Me.UcrCheckboxNew1.Size = New System.Drawing.Size(138, 26)
        Me.UcrCheckboxNew1.TabIndex = 45
        '
        'UcrDatePickerOpeningDate
        '
        Me.UcrDatePickerOpeningDate.Location = New System.Drawing.Point(522, 249)
        Me.UcrDatePickerOpeningDate.Name = "UcrDatePickerOpeningDate"
        Me.UcrDatePickerOpeningDate.Size = New System.Drawing.Size(174, 21)
        Me.UcrDatePickerOpeningDate.TabIndex = 46
        '
        'UcrDatePickerClosing
        '
        Me.UcrDatePickerClosing.Location = New System.Drawing.Point(522, 273)
        Me.UcrDatePickerClosing.Name = "UcrDatePickerClosing"
        Me.UcrDatePickerClosing.Size = New System.Drawing.Size(174, 21)
        Me.UcrDatePickerClosing.TabIndex = 47
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.Location = New System.Drawing.Point(330, 6)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(52, 15)
        Me.lblStation.TabIndex = 48
        Me.lblStation.Text = "Station"
        '
        'grpComputationDD
        '
        Me.grpComputationDD.BackColor = System.Drawing.Color.Snow
        Me.grpComputationDD.Controls.Add(Me.UcrComboboxEW)
        Me.grpComputationDD.Controls.Add(Me.UcrComboboxNS)
        Me.grpComputationDD.Controls.Add(Me.UcrTextBoxSecondsLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxDegreeLongitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinusLatitude)
        Me.grpComputationDD.Controls.Add(Me.UcrTextBoxSecondsLatitude)
        Me.grpComputationDD.Controls.Add(Me.ucrTextBoxMinusLongitude)
        Me.grpComputationDD.Controls.Add(Me.UcrTextBoxDegreeLatitude)
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
        Me.grpComputationDD.TabIndex = 49
        Me.grpComputationDD.TabStop = False
        Me.grpComputationDD.Text = "Latitude and Longitude Decimal Degrees Computation"
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
        'UcrTextBoxDegreeLatitude
        '
        Me.UcrTextBoxDegreeLatitude.Location = New System.Drawing.Point(56, 18)
        Me.UcrTextBoxDegreeLatitude.Name = "UcrTextBoxDegreeLatitude"
        Me.UcrTextBoxDegreeLatitude.Size = New System.Drawing.Size(59, 20)
        Me.UcrTextBoxDegreeLatitude.TabIndex = 50
        Me.UcrTextBoxDegreeLatitude.TextboxValue = ""
        '
        'ucrTextBoxMinusLongitude
        '
        Me.ucrTextBoxMinusLongitude.Location = New System.Drawing.Point(173, 43)
        Me.ucrTextBoxMinusLongitude.Name = "ucrTextBoxMinusLongitude"
        Me.ucrTextBoxMinusLongitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxMinusLongitude.TabIndex = 51
        Me.ucrTextBoxMinusLongitude.TextboxValue = ""
        '
        'UcrTextBoxSecondsLatitude
        '
        Me.UcrTextBoxSecondsLatitude.Location = New System.Drawing.Point(295, 15)
        Me.UcrTextBoxSecondsLatitude.Name = "UcrTextBoxSecondsLatitude"
        Me.UcrTextBoxSecondsLatitude.Size = New System.Drawing.Size(59, 20)
        Me.UcrTextBoxSecondsLatitude.TabIndex = 52
        Me.UcrTextBoxSecondsLatitude.TextboxValue = ""
        '
        'ucrTextBoxMinusLatitude
        '
        Me.ucrTextBoxMinusLatitude.Location = New System.Drawing.Point(173, 18)
        Me.ucrTextBoxMinusLatitude.Name = "ucrTextBoxMinusLatitude"
        Me.ucrTextBoxMinusLatitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxMinusLatitude.TabIndex = 53
        Me.ucrTextBoxMinusLatitude.TextboxValue = ""
        '
        'ucrTextBoxDegreeLongitude
        '
        Me.ucrTextBoxDegreeLongitude.Location = New System.Drawing.Point(56, 44)
        Me.ucrTextBoxDegreeLongitude.Name = "ucrTextBoxDegreeLongitude"
        Me.ucrTextBoxDegreeLongitude.Size = New System.Drawing.Size(59, 20)
        Me.ucrTextBoxDegreeLongitude.TabIndex = 54
        Me.ucrTextBoxDegreeLongitude.TextboxValue = ""
        '
        'UcrTextBoxSecondsLongitude
        '
        Me.UcrTextBoxSecondsLongitude.Location = New System.Drawing.Point(295, 43)
        Me.UcrTextBoxSecondsLongitude.Name = "UcrTextBoxSecondsLongitude"
        Me.UcrTextBoxSecondsLongitude.Size = New System.Drawing.Size(59, 20)
        Me.UcrTextBoxSecondsLongitude.TabIndex = 55
        Me.UcrTextBoxSecondsLongitude.TextboxValue = ""
        '
        'UcrComboboxNS
        '
        Me.UcrComboboxNS.Location = New System.Drawing.Point(395, 15)
        Me.UcrComboboxNS.Name = "UcrComboboxNS"
        Me.UcrComboboxNS.Size = New System.Drawing.Size(53, 21)
        Me.UcrComboboxNS.TabIndex = 56
        '
        'UcrComboboxEW
        '
        Me.UcrComboboxEW.Location = New System.Drawing.Point(395, 38)
        Me.UcrComboboxEW.Name = "UcrComboboxEW"
        Me.UcrComboboxEW.Size = New System.Drawing.Size(53, 21)
        Me.UcrComboboxEW.TabIndex = 57
        '
        'UcrNavigatorStation
        '
        Me.UcrNavigatorStation.Location = New System.Drawing.Point(199, 452)
        Me.UcrNavigatorStation.Name = "UcrNavigatorStation"
        Me.UcrNavigatorStation.Size = New System.Drawing.Size(340, 30)
        Me.UcrNavigatorStation.TabIndex = 50
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
        Me.Panel2.TabIndex = 51
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(424, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
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
        'ucrMetadataStationNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.UcrNavigatorStation)
        Me.Controls.Add(Me.grpComputationDD)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.UcrDatePickerClosing)
        Me.Controls.Add(Me.UcrDatePickerOpeningDate)
        Me.Controls.Add(Me.UcrCheckboxNew1)
        Me.Controls.Add(Me.lblStationOperation)
        Me.Controls.Add(Me.lblGeoAccuracy)
        Me.Controls.Add(Me.lblGeoMethod)
        Me.Controls.Add(Me.lblClosingdate)
        Me.Controls.Add(Me.lblOpendate)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.UcrComboboxStationName)
        Me.Controls.Add(Me.lblSearchStation)
        Me.Controls.Add(Me.UcrTextBoxDrainageBasin)
        Me.Controls.Add(Me.UcrTextBoxGeographicalAccuracry)
        Me.Controls.Add(Me.UcrTextBoxGeographicalMethod)
        Me.Controls.Add(Me.UcrTextBoxQualifier)
        Me.Controls.Add(Me.ucrTextBoxLatidue)
        Me.Controls.Add(Me.ucrTextBoxLongitude)
        Me.Controls.Add(Me.ucrTextBoxElevation)
        Me.Controls.Add(Me.ucrTextBoxWMOId)
        Me.Controls.Add(Me.ucrTextBoxICAOId)
        Me.Controls.Add(Me.UcrTextBoxCountry)
        Me.Controls.Add(Me.UcrTextBoxAuthority)
        Me.Controls.Add(Me.UcrTextBoxAdminRegion)
        Me.Controls.Add(Me.ucrStationName)
        Me.Controls.Add(Me.ucrIDComboBox)
        Me.Controls.Add(Me.lbldarainage)
        Me.Controls.Add(Me.lblAdmin)
        Me.Controls.Add(Me.lblAuthority)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.lblICAOid)
        Me.Controls.Add(Me.lblWMOid)
        Me.Controls.Add(Me.lblElevation)
        Me.Controls.Add(Me.lblongitude)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.lblStationName)
        Me.Controls.Add(Me.lblStationId)
        Me.Name = "ucrMetadataStationNew"
        Me.Size = New System.Drawing.Size(734, 509)
        Me.Tag = "elevation"
        Me.grpComputationDD.ResumeLayout(False)
        Me.grpComputationDD.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStationId As Label
    Friend WithEvents lblStationName As Label
    Friend WithEvents lblLatitude As Label
    Friend WithEvents lblongitude As Label
    Friend WithEvents lblElevation As Label
    Friend WithEvents lblWMOid As Label
    Friend WithEvents lblICAOid As Label
    Friend WithEvents lblCountry As Label
    Friend WithEvents lblAuthority As Label
    Friend WithEvents lblAdmin As Label
    Friend WithEvents lbldarainage As Label
    Friend WithEvents ucrIDComboBox As ucrComboboxNew
    Friend WithEvents ucrStationName As ucrTextBoxNew
    Friend WithEvents UcrTextBoxAdminRegion As ucrTextBoxNew
    Friend WithEvents UcrTextBoxAuthority As ucrTextBoxNew
    Friend WithEvents UcrTextBoxCountry As ucrTextBoxNew
    Friend WithEvents ucrTextBoxICAOId As ucrTextBoxNew
    Friend WithEvents ucrTextBoxWMOId As ucrTextBoxNew
    Friend WithEvents ucrTextBoxElevation As ucrTextBoxNew
    Friend WithEvents ucrTextBoxLongitude As ucrTextBoxNew
    Friend WithEvents ucrTextBoxLatidue As ucrTextBoxNew
    Friend WithEvents UcrTextBoxQualifier As ucrTextBoxNew
    Friend WithEvents UcrTextBoxGeographicalMethod As ucrTextBoxNew
    Friend WithEvents UcrTextBoxGeographicalAccuracry As ucrTextBoxNew
    Friend WithEvents UcrTextBoxDrainageBasin As ucrTextBoxNew
    Friend WithEvents lblSearchStation As Label
    Friend WithEvents UcrComboboxStationName As ucrComboboxNew
    Friend WithEvents Label24 As Label
    Friend WithEvents lblOpendate As Label
    Friend WithEvents lblClosingdate As Label
    Friend WithEvents lblGeoMethod As Label
    Friend WithEvents lblGeoAccuracy As Label
    Friend WithEvents lblStationOperation As Label
    Friend WithEvents UcrCheckboxNew1 As ucrCheckboxNew
    Friend WithEvents UcrDatePickerOpeningDate As ucrDatePickerNew
    Friend WithEvents UcrDatePickerClosing As ucrDatePickerNew
    Friend WithEvents lblStation As Label
    Friend WithEvents grpComputationDD As GroupBox
    Friend WithEvents lblEW As Label
    Friend WithEvents lblNS As Label
    Friend WithEvents lblSecondsLon As Label
    Friend WithEvents lblSecondsLat As Label
    Friend WithEvents lblMinutesLon As Label
    Friend WithEvents lblMinutesLat As Label
    Friend WithEvents lblDegreesLon As Label
    Friend WithEvents lblDegreesLat As Label
    Friend WithEvents UcrTextBoxDegreeLatitude As ucrTextBoxNew
    Friend WithEvents ucrTextBoxDegreeLongitude As ucrTextBoxNew
    Friend WithEvents ucrTextBoxMinusLatitude As ucrTextBoxNew
    Friend WithEvents UcrTextBoxSecondsLatitude As ucrTextBoxNew
    Friend WithEvents ucrTextBoxMinusLongitude As ucrTextBoxNew
    Friend WithEvents UcrTextBoxSecondsLongitude As ucrTextBoxNew
    Friend WithEvents UcrComboboxNS As ucrComboboxNew
    Friend WithEvents UcrComboboxEW As ucrComboboxNew
    Friend WithEvents UcrNavigatorStation As ucrNavigator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnClear As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
End Class
