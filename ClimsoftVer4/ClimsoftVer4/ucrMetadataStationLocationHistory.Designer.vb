<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationLocationHistory
    Inherits ClimsoftVer4.ucrTableEntry

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
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblClosingDate = New System.Windows.Forms.Label()
        Me.lblOpeningDate = New System.Windows.Forms.Label()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.lblAuthority = New System.Windows.Forms.Label()
        Me.lblGeoLocationMethod = New System.Windows.Forms.Label()
        Me.lblElevation = New System.Windows.Forms.Label()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.lblStationType = New System.Windows.Forms.Label()
        Me.lblGeoLocationAccuracy = New System.Windows.Forms.Label()
        Me.ucrTextBoxStationType = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxGeoLocationMethod = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxGeolocationAccuracy = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxElevation = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxAuthority = New ClimsoftVer4.ucrTextBox()
        Me.ucrDatePickerOpeningDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerCkosingDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.grpCommand2 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ucrNavigationStationLocationHistory = New ClimsoftVer4.ucrNavigation()
        Me.AdministrationRegionLabel = New System.Windows.Forms.Label()
        Me.DrainageBasinLabel = New System.Windows.Forms.Label()
        Me.ucrTextBoxAdministrativeRegion = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDrainageBasin = New ClimsoftVer4.ucrTextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCommand2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(340, 14)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(224, 22)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Station Location History"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(214, 82)
        Me.lblStation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(60, 20)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station"
        '
        'lblClosingDate
        '
        Me.lblClosingDate.AutoSize = True
        Me.lblClosingDate.Location = New System.Drawing.Point(214, 289)
        Me.lblClosingDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClosingDate.Name = "lblClosingDate"
        Me.lblClosingDate.Size = New System.Drawing.Size(100, 20)
        Me.lblClosingDate.TabIndex = 11
        Me.lblClosingDate.Text = "Closing Date"
        '
        'lblOpeningDate
        '
        Me.lblOpeningDate.AutoSize = True
        Me.lblOpeningDate.Location = New System.Drawing.Point(214, 248)
        Me.lblOpeningDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOpeningDate.Name = "lblOpeningDate"
        Me.lblOpeningDate.Size = New System.Drawing.Size(108, 20)
        Me.lblOpeningDate.TabIndex = 9
        Me.lblOpeningDate.Text = "Opening Date"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(214, 331)
        Me.lblLatitude.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(67, 20)
        Me.lblLatitude.TabIndex = 13
        Me.lblLatitude.Text = "Latitude"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(214, 455)
        Me.lblAuthority.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(72, 20)
        Me.lblAuthority.TabIndex = 19
        Me.lblAuthority.Text = "Authority"
        '
        'lblGeoLocationMethod
        '
        Me.lblGeoLocationMethod.AutoSize = True
        Me.lblGeoLocationMethod.Location = New System.Drawing.Point(214, 165)
        Me.lblGeoLocationMethod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGeoLocationMethod.Name = "lblGeoLocationMethod"
        Me.lblGeoLocationMethod.Size = New System.Drawing.Size(159, 20)
        Me.lblGeoLocationMethod.TabIndex = 5
        Me.lblGeoLocationMethod.Text = "GeoLocation Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(214, 414)
        Me.lblElevation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(74, 20)
        Me.lblElevation.TabIndex = 17
        Me.lblElevation.Text = "Elevation"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(214, 372)
        Me.lblLongitude.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(80, 20)
        Me.lblLongitude.TabIndex = 15
        Me.lblLongitude.Text = "Longitude"
        '
        'lblStationType
        '
        Me.lblStationType.AutoSize = True
        Me.lblStationType.Location = New System.Drawing.Point(214, 123)
        Me.lblStationType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationType.Name = "lblStationType"
        Me.lblStationType.Size = New System.Drawing.Size(98, 20)
        Me.lblStationType.TabIndex = 3
        Me.lblStationType.Text = "Station Type"
        '
        'lblGeoLocationAccuracy
        '
        Me.lblGeoLocationAccuracy.AutoSize = True
        Me.lblGeoLocationAccuracy.Location = New System.Drawing.Point(214, 206)
        Me.lblGeoLocationAccuracy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGeoLocationAccuracy.Name = "lblGeoLocationAccuracy"
        Me.lblGeoLocationAccuracy.Size = New System.Drawing.Size(170, 20)
        Me.lblGeoLocationAccuracy.TabIndex = 7
        Me.lblGeoLocationAccuracy.Text = "GeoLocation Accuracy"
        '
        'ucrTextBoxStationType
        '
        Me.ucrTextBoxStationType.FieldName = "stationType"
        Me.ucrTextBoxStationType.Location = New System.Drawing.Point(412, 109)
        Me.ucrTextBoxStationType.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxStationType.Name = "ucrTextBoxStationType"
        Me.ucrTextBoxStationType.Size = New System.Drawing.Size(194, 31)
        Me.ucrTextBoxStationType.TabIndex = 4
        Me.ucrTextBoxStationType.Tag = "stationType"
        Me.ucrTextBoxStationType.TextboxValue = ""
        '
        'ucrTextBoxGeoLocationMethod
        '
        Me.ucrTextBoxGeoLocationMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.Location = New System.Drawing.Point(412, 152)
        Me.ucrTextBoxGeoLocationMethod.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxGeoLocationMethod.Name = "ucrTextBoxGeoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.Size = New System.Drawing.Size(194, 34)
        Me.ucrTextBoxGeoLocationMethod.TabIndex = 6
        Me.ucrTextBoxGeoLocationMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.TextboxValue = ""
        '
        'ucrTextBoxGeolocationAccuracy
        '
        Me.ucrTextBoxGeolocationAccuracy.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.Location = New System.Drawing.Point(412, 195)
        Me.ucrTextBoxGeolocationAccuracy.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxGeolocationAccuracy.Name = "ucrTextBoxGeolocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.Size = New System.Drawing.Size(194, 37)
        Me.ucrTextBoxGeolocationAccuracy.TabIndex = 8
        Me.ucrTextBoxGeolocationAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(412, 329)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(194, 31)
        Me.ucrTextBoxLatitude.TabIndex = 14
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.FieldName = "longitude"
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(414, 372)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(192, 31)
        Me.ucrTextBoxLongitude.TabIndex = 16
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(414, 411)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(75, 31)
        Me.ucrTextBoxElevation.TabIndex = 18
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.FieldName = "authority"
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(414, 451)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(192, 31)
        Me.ucrTextBoxAuthority.TabIndex = 20
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(412, 235)
        Me.ucrDatePickerOpeningDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(194, 32)
        Me.ucrDatePickerOpeningDate.TabIndex = 10
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrDatePickerCkosingDate
        '
        Me.ucrDatePickerCkosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerCkosingDate.Location = New System.Drawing.Point(412, 277)
        Me.ucrDatePickerCkosingDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerCkosingDate.Name = "ucrDatePickerCkosingDate"
        Me.ucrDatePickerCkosingDate.Size = New System.Drawing.Size(194, 32)
        Me.ucrDatePickerCkosingDate.TabIndex = 12
        Me.ucrDatePickerCkosingDate.Tag = "closingDatetime"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "belongsTo"
        Me.ucrStationSelector.Location = New System.Drawing.Point(412, 60)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(194, 42)
        Me.ucrStationSelector.TabIndex = 2
        Me.ucrStationSelector.Tag = "belongsTo"
        '
        'grpCommand2
        '
        Me.grpCommand2.Controls.Add(Me.btnClear)
        Me.grpCommand2.Controls.Add(Me.btnAddNew)
        Me.grpCommand2.Controls.Add(Me.btnView)
        Me.grpCommand2.Controls.Add(Me.btnDelete)
        Me.grpCommand2.Controls.Add(Me.btnUpdate)
        Me.grpCommand2.Controls.Add(Me.btnSave)
        Me.grpCommand2.Location = New System.Drawing.Point(56, 602)
        Me.grpCommand2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpCommand2.Name = "grpCommand2"
        Me.grpCommand2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpCommand2.Size = New System.Drawing.Size(902, 48)
        Me.grpCommand2.TabIndex = 21
        Me.grpCommand2.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(612, 9)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(30, 6)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 35)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(758, 8)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(112, 35)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(466, 8)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(321, 8)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(112, 35)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(176, 8)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ucrNavigationStationLocationHistory
        '
        Me.ucrNavigationStationLocationHistory.Location = New System.Drawing.Point(212, 674)
        Me.ucrNavigationStationLocationHistory.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigationStationLocationHistory.Name = "ucrNavigationStationLocationHistory"
        Me.ucrNavigationStationLocationHistory.Size = New System.Drawing.Size(504, 38)
        Me.ucrNavigationStationLocationHistory.TabIndex = 22
        '
        'AdministrationRegionLabel
        '
        Me.AdministrationRegionLabel.AutoSize = True
        Me.AdministrationRegionLabel.Location = New System.Drawing.Point(214, 505)
        Me.AdministrationRegionLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.AdministrationRegionLabel.Name = "AdministrationRegionLabel"
        Me.AdministrationRegionLabel.Size = New System.Drawing.Size(165, 20)
        Me.AdministrationRegionLabel.TabIndex = 21
        Me.AdministrationRegionLabel.Text = "Administration Region"
        '
        'DrainageBasinLabel
        '
        Me.DrainageBasinLabel.AutoSize = True
        Me.DrainageBasinLabel.Location = New System.Drawing.Point(214, 549)
        Me.DrainageBasinLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DrainageBasinLabel.Name = "DrainageBasinLabel"
        Me.DrainageBasinLabel.Size = New System.Drawing.Size(118, 20)
        Me.DrainageBasinLabel.TabIndex = 23
        Me.DrainageBasinLabel.Text = "Drainage Basin"
        '
        'ucrTextBoxAdministrativeRegion
        '
        Me.ucrTextBoxAdministrativeRegion.FieldName = "adminRegion"
        Me.ucrTextBoxAdministrativeRegion.Location = New System.Drawing.Point(414, 494)
        Me.ucrTextBoxAdministrativeRegion.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxAdministrativeRegion.Name = "ucrTextBoxAdministrativeRegion"
        Me.ucrTextBoxAdministrativeRegion.Size = New System.Drawing.Size(76, 31)
        Me.ucrTextBoxAdministrativeRegion.TabIndex = 22
        Me.ucrTextBoxAdministrativeRegion.Tag = "adminRegion"
        Me.ucrTextBoxAdministrativeRegion.TextboxValue = ""
        '
        'ucrTextBoxDrainageBasin
        '
        Me.ucrTextBoxDrainageBasin.FieldName = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.Location = New System.Drawing.Point(414, 545)
        Me.ucrTextBoxDrainageBasin.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxDrainageBasin.Name = "ucrTextBoxDrainageBasin"
        Me.ucrTextBoxDrainageBasin.Size = New System.Drawing.Size(76, 31)
        Me.ucrTextBoxDrainageBasin.TabIndex = 24
        Me.ucrTextBoxDrainageBasin.Tag = "drainageBasin"
        Me.ucrTextBoxDrainageBasin.TextboxValue = ""
        '
        'ucrMetadataStationLocationHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextBoxDrainageBasin)
        Me.Controls.Add(Me.ucrTextBoxAdministrativeRegion)
        Me.Controls.Add(Me.DrainageBasinLabel)
        Me.Controls.Add(Me.AdministrationRegionLabel)
        Me.Controls.Add(Me.grpCommand2)
        Me.Controls.Add(Me.ucrNavigationStationLocationHistory)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrDatePickerCkosingDate)
        Me.Controls.Add(Me.ucrDatePickerOpeningDate)
        Me.Controls.Add(Me.ucrTextBoxAuthority)
        Me.Controls.Add(Me.ucrTextBoxElevation)
        Me.Controls.Add(Me.ucrTextBoxLongitude)
        Me.Controls.Add(Me.ucrTextBoxLatitude)
        Me.Controls.Add(Me.ucrTextBoxGeolocationAccuracy)
        Me.Controls.Add(Me.ucrTextBoxGeoLocationMethod)
        Me.Controls.Add(Me.ucrTextBoxStationType)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblClosingDate)
        Me.Controls.Add(Me.lblOpeningDate)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.lblAuthority)
        Me.Controls.Add(Me.lblGeoLocationMethod)
        Me.Controls.Add(Me.lblElevation)
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.lblStationType)
        Me.Controls.Add(Me.lblGeoLocationAccuracy)
        Me.Controls.Add(Me.Label19)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrMetadataStationLocationHistory"
        Me.Size = New System.Drawing.Size(1011, 737)
        Me.Tag = ""
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCommand2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label19 As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents lblClosingDate As Label
    Friend WithEvents lblOpeningDate As Label
    Friend WithEvents lblLatitude As Label
    Friend WithEvents lblAuthority As Label
    Friend WithEvents lblGeoLocationMethod As Label
    Friend WithEvents lblElevation As Label
    Friend WithEvents lblLongitude As Label
    Friend WithEvents lblStationType As Label
    Friend WithEvents lblGeoLocationAccuracy As Label
    Friend WithEvents ucrTextBoxStationType As ucrTextBox
    Friend WithEvents ucrTextBoxGeoLocationMethod As ucrTextBox
    Friend WithEvents ucrTextBoxGeolocationAccuracy As ucrTextBox
    Friend WithEvents ucrTextBoxLatitude As ucrTextBox
    Friend WithEvents ucrTextBoxLongitude As ucrTextBox
    Friend WithEvents ucrTextBoxElevation As ucrTextBox
    Friend WithEvents ucrTextBoxAuthority As ucrTextBox
    Friend WithEvents ucrDatePickerOpeningDate As ucrDatePicker
    Friend WithEvents ucrDatePickerCkosingDate As ucrDatePicker
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents grpCommand2 As GroupBox
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents ucrNavigationStationLocationHistory As ucrNavigation
    Friend WithEvents btnClear As Button
    Friend WithEvents AdministrationRegionLabel As Label
    Friend WithEvents DrainageBasinLabel As Label
    Friend WithEvents ucrTextBoxAdministrativeRegion As ucrTextBox
    Friend WithEvents ucrTextBoxDrainageBasin As ucrTextBox
End Class
