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
        Me.AdministrationRegionTextBox = New System.Windows.Forms.TextBox()
        Me.AdministrationRegionLabel = New System.Windows.Forms.Label()
        Me.DrainageBasinLabel = New System.Windows.Forms.Label()
        Me.DrainageBasinTextBox = New System.Windows.Forms.TextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCommand2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(227, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(159, 15)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Station Location History"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(143, 53)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station"
        '
        'lblClosingDate
        '
        Me.lblClosingDate.AutoSize = True
        Me.lblClosingDate.Location = New System.Drawing.Point(143, 188)
        Me.lblClosingDate.Name = "lblClosingDate"
        Me.lblClosingDate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingDate.TabIndex = 11
        Me.lblClosingDate.Text = "Closing Date"
        '
        'lblOpeningDate
        '
        Me.lblOpeningDate.AutoSize = True
        Me.lblOpeningDate.Location = New System.Drawing.Point(143, 161)
        Me.lblOpeningDate.Name = "lblOpeningDate"
        Me.lblOpeningDate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpeningDate.TabIndex = 9
        Me.lblOpeningDate.Text = "Opening Date"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(143, 215)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 13
        Me.lblLatitude.Text = "Latitude"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(143, 296)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 19
        Me.lblAuthority.Text = "Authority"
        '
        'lblGeoLocationMethod
        '
        Me.lblGeoLocationMethod.AutoSize = True
        Me.lblGeoLocationMethod.Location = New System.Drawing.Point(143, 107)
        Me.lblGeoLocationMethod.Name = "lblGeoLocationMethod"
        Me.lblGeoLocationMethod.Size = New System.Drawing.Size(107, 13)
        Me.lblGeoLocationMethod.TabIndex = 5
        Me.lblGeoLocationMethod.Text = "GeoLocation Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(143, 269)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(51, 13)
        Me.lblElevation.TabIndex = 17
        Me.lblElevation.Text = "Elevation"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(143, 242)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 15
        Me.lblLongitude.Text = "Longitude"
        '
        'lblStationType
        '
        Me.lblStationType.AutoSize = True
        Me.lblStationType.Location = New System.Drawing.Point(143, 80)
        Me.lblStationType.Name = "lblStationType"
        Me.lblStationType.Size = New System.Drawing.Size(67, 13)
        Me.lblStationType.TabIndex = 3
        Me.lblStationType.Text = "Station Type"
        '
        'lblGeoLocationAccuracy
        '
        Me.lblGeoLocationAccuracy.AutoSize = True
        Me.lblGeoLocationAccuracy.Location = New System.Drawing.Point(143, 134)
        Me.lblGeoLocationAccuracy.Name = "lblGeoLocationAccuracy"
        Me.lblGeoLocationAccuracy.Size = New System.Drawing.Size(116, 13)
        Me.lblGeoLocationAccuracy.TabIndex = 7
        Me.lblGeoLocationAccuracy.Text = "GeoLocation Accuracy"
        '
        'ucrTextBoxStationType
        '
        Me.ucrTextBoxStationType.FieldName = "stationType"
        Me.ucrTextBoxStationType.Location = New System.Drawing.Point(275, 71)
        Me.ucrTextBoxStationType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxStationType.Name = "ucrTextBoxStationType"
        Me.ucrTextBoxStationType.Size = New System.Drawing.Size(129, 20)
        Me.ucrTextBoxStationType.TabIndex = 4
        Me.ucrTextBoxStationType.Tag = "stationType"
        Me.ucrTextBoxStationType.TextboxValue = ""
        '
        'ucrTextBoxGeoLocationMethod
        '
        Me.ucrTextBoxGeoLocationMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.Location = New System.Drawing.Point(275, 99)
        Me.ucrTextBoxGeoLocationMethod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeoLocationMethod.Name = "ucrTextBoxGeoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.Size = New System.Drawing.Size(129, 22)
        Me.ucrTextBoxGeoLocationMethod.TabIndex = 6
        Me.ucrTextBoxGeoLocationMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGeoLocationMethod.TextboxValue = ""
        '
        'ucrTextBoxGeolocationAccuracy
        '
        Me.ucrTextBoxGeolocationAccuracy.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.Location = New System.Drawing.Point(275, 127)
        Me.ucrTextBoxGeolocationAccuracy.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeolocationAccuracy.Name = "ucrTextBoxGeolocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.Size = New System.Drawing.Size(129, 24)
        Me.ucrTextBoxGeolocationAccuracy.TabIndex = 8
        Me.ucrTextBoxGeolocationAccuracy.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeolocationAccuracy.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(275, 214)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(129, 20)
        Me.ucrTextBoxLatitude.TabIndex = 14
        Me.ucrTextBoxLatitude.Tag = "latitude"
        Me.ucrTextBoxLatitude.TextboxValue = ""
        '
        'ucrTextBoxLongitude
        '
        Me.ucrTextBoxLongitude.FieldName = "longitude"
        Me.ucrTextBoxLongitude.Location = New System.Drawing.Point(276, 242)
        Me.ucrTextBoxLongitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLongitude.Name = "ucrTextBoxLongitude"
        Me.ucrTextBoxLongitude.Size = New System.Drawing.Size(128, 20)
        Me.ucrTextBoxLongitude.TabIndex = 16
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(276, 267)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(50, 20)
        Me.ucrTextBoxElevation.TabIndex = 18
        Me.ucrTextBoxElevation.Tag = "elevation"
        Me.ucrTextBoxElevation.TextboxValue = ""
        '
        'ucrTextBoxAuthority
        '
        Me.ucrTextBoxAuthority.FieldName = "authority"
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(276, 293)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(128, 20)
        Me.ucrTextBoxAuthority.TabIndex = 20
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(275, 153)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerOpeningDate.TabIndex = 10
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrDatePickerCkosingDate
        '
        Me.ucrDatePickerCkosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerCkosingDate.Location = New System.Drawing.Point(275, 180)
        Me.ucrDatePickerCkosingDate.Name = "ucrDatePickerCkosingDate"
        Me.ucrDatePickerCkosingDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerCkosingDate.TabIndex = 12
        Me.ucrDatePickerCkosingDate.Tag = "closingDatetime"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "belongsTo"
        Me.ucrStationSelector.Location = New System.Drawing.Point(275, 39)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(129, 27)
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
        Me.grpCommand2.Location = New System.Drawing.Point(37, 391)
        Me.grpCommand2.Name = "grpCommand2"
        Me.grpCommand2.Size = New System.Drawing.Size(601, 31)
        Me.grpCommand2.TabIndex = 21
        Me.grpCommand2.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(408, 6)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(20, 4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(505, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(311, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(214, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(117, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ucrNavigationStationLocationHistory
        '
        Me.ucrNavigationStationLocationHistory.Location = New System.Drawing.Point(141, 438)
        Me.ucrNavigationStationLocationHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStationLocationHistory.Name = "ucrNavigationStationLocationHistory"
        Me.ucrNavigationStationLocationHistory.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStationLocationHistory.TabIndex = 22
        '
        'AdministrationRegionTextBox
        '
        Me.AdministrationRegionTextBox.Location = New System.Drawing.Point(275, 321)
        Me.AdministrationRegionTextBox.Name = "AdministrationRegionTextBox"
        Me.AdministrationRegionTextBox.Size = New System.Drawing.Size(51, 20)
        Me.AdministrationRegionTextBox.TabIndex = 23
        Me.AdministrationRegionTextBox.Tag = "adminRegion"
        '
        'AdministrationRegionLabel
        '
        Me.AdministrationRegionLabel.AutoSize = True
        Me.AdministrationRegionLabel.Location = New System.Drawing.Point(143, 328)
        Me.AdministrationRegionLabel.Name = "AdministrationRegionLabel"
        Me.AdministrationRegionLabel.Size = New System.Drawing.Size(109, 13)
        Me.AdministrationRegionLabel.TabIndex = 25
        Me.AdministrationRegionLabel.Text = "Administration Region"
        '
        'DrainageBasinLabel
        '
        Me.DrainageBasinLabel.AutoSize = True
        Me.DrainageBasinLabel.Location = New System.Drawing.Point(143, 361)
        Me.DrainageBasinLabel.Name = "DrainageBasinLabel"
        Me.DrainageBasinLabel.Size = New System.Drawing.Size(79, 13)
        Me.DrainageBasinLabel.TabIndex = 26
        Me.DrainageBasinLabel.Text = "Drainage Basin"
        '
        'DrainageBasinTextBox
        '
        Me.DrainageBasinTextBox.Location = New System.Drawing.Point(275, 354)
        Me.DrainageBasinTextBox.Name = "DrainageBasinTextBox"
        Me.DrainageBasinTextBox.Size = New System.Drawing.Size(51, 20)
        Me.DrainageBasinTextBox.TabIndex = 27
        Me.DrainageBasinTextBox.Tag = "drainageBasin"
        '
        'ucrMetadataStationLocationHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DrainageBasinTextBox)
        Me.Controls.Add(Me.DrainageBasinLabel)
        Me.Controls.Add(Me.AdministrationRegionLabel)
        Me.Controls.Add(Me.AdministrationRegionTextBox)
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
        Me.Name = "ucrMetadataStationLocationHistory"
        Me.Size = New System.Drawing.Size(674, 479)
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
    Friend WithEvents AdministrationRegionTextBox As TextBox
    Friend WithEvents AdministrationRegionLabel As Label
    Friend WithEvents DrainageBasinLabel As Label
    Friend WithEvents DrainageBasinTextBox As TextBox
End Class
