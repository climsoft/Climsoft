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
        Me.lblGeogLocationMethod = New System.Windows.Forms.Label()
        Me.lblElevation = New System.Windows.Forms.Label()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.lblStationType = New System.Windows.Forms.Label()
        Me.lblGeogLocationAccuracy = New System.Windows.Forms.Label()
        Me.ucrTextBoxStationType = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxGeogLocationMethod = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxGeoglocationHistory = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLatitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLongitude = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxElevation = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxAuthority = New ClimsoftVer4.ucrTextBox()
        Me.ucrDatePickerOpeningDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerCkosingDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.grpCommand2 = New System.Windows.Forms.GroupBox()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ucrNavigationStationLocationHistory = New ClimsoftVer4.ucrNavigation()
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
        Me.Label19.TabIndex = 7
        Me.Label19.Text = "Station Location History"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(143, 53)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 70
        Me.lblStation.Text = "Station"
        '
        'lblClosingDate
        '
        Me.lblClosingDate.AutoSize = True
        Me.lblClosingDate.Location = New System.Drawing.Point(143, 188)
        Me.lblClosingDate.Name = "lblClosingDate"
        Me.lblClosingDate.Size = New System.Drawing.Size(67, 13)
        Me.lblClosingDate.TabIndex = 75
        Me.lblClosingDate.Text = "Closing Date"
        '
        'lblOpeningDate
        '
        Me.lblOpeningDate.AutoSize = True
        Me.lblOpeningDate.Location = New System.Drawing.Point(143, 161)
        Me.lblOpeningDate.Name = "lblOpeningDate"
        Me.lblOpeningDate.Size = New System.Drawing.Size(73, 13)
        Me.lblOpeningDate.TabIndex = 74
        Me.lblOpeningDate.Text = "Opening Date"
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(143, 215)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 76
        Me.lblLatitude.Text = "Latitude"
        '
        'lblAuthority
        '
        Me.lblAuthority.AutoSize = True
        Me.lblAuthority.Location = New System.Drawing.Point(143, 296)
        Me.lblAuthority.Name = "lblAuthority"
        Me.lblAuthority.Size = New System.Drawing.Size(48, 13)
        Me.lblAuthority.TabIndex = 79
        Me.lblAuthority.Text = "Authority"
        '
        'lblGeogLocationMethod
        '
        Me.lblGeogLocationMethod.AutoSize = True
        Me.lblGeogLocationMethod.Location = New System.Drawing.Point(143, 107)
        Me.lblGeogLocationMethod.Name = "lblGeogLocationMethod"
        Me.lblGeogLocationMethod.Size = New System.Drawing.Size(113, 13)
        Me.lblGeogLocationMethod.TabIndex = 72
        Me.lblGeogLocationMethod.Text = "GeogLocation Method"
        '
        'lblElevation
        '
        Me.lblElevation.AutoSize = True
        Me.lblElevation.Location = New System.Drawing.Point(143, 269)
        Me.lblElevation.Name = "lblElevation"
        Me.lblElevation.Size = New System.Drawing.Size(51, 13)
        Me.lblElevation.TabIndex = 78
        Me.lblElevation.Text = "Elevation"
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(143, 242)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 77
        Me.lblLongitude.Text = "Longitude"
        '
        'lblStationType
        '
        Me.lblStationType.AutoSize = True
        Me.lblStationType.Location = New System.Drawing.Point(143, 80)
        Me.lblStationType.Name = "lblStationType"
        Me.lblStationType.Size = New System.Drawing.Size(67, 13)
        Me.lblStationType.TabIndex = 71
        Me.lblStationType.Text = "Station Type"
        '
        'lblGeogLocationAccuracy
        '
        Me.lblGeogLocationAccuracy.AutoSize = True
        Me.lblGeogLocationAccuracy.Location = New System.Drawing.Point(143, 134)
        Me.lblGeogLocationAccuracy.Name = "lblGeogLocationAccuracy"
        Me.lblGeogLocationAccuracy.Size = New System.Drawing.Size(122, 13)
        Me.lblGeogLocationAccuracy.TabIndex = 73
        Me.lblGeogLocationAccuracy.Text = "GeogLocation Accuracy"
        '
        'ucrTextBoxStationType
        '
        Me.ucrTextBoxStationType.FieldName = "stationType"
        Me.ucrTextBoxStationType.Location = New System.Drawing.Point(275, 71)
        Me.ucrTextBoxStationType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxStationType.Name = "ucrTextBoxStationType"
        Me.ucrTextBoxStationType.Size = New System.Drawing.Size(129, 20)
        Me.ucrTextBoxStationType.TabIndex = 85
        Me.ucrTextBoxStationType.Tag = "stationType"
        Me.ucrTextBoxStationType.TextboxValue = ""
        '
        'ucrTextBoxGeogLocationMethod
        '
        Me.ucrTextBoxGeogLocationMethod.FieldName = "geoLocationMethod"
        Me.ucrTextBoxGeogLocationMethod.Location = New System.Drawing.Point(275, 99)
        Me.ucrTextBoxGeogLocationMethod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeogLocationMethod.Name = "ucrTextBoxGeogLocationMethod"
        Me.ucrTextBoxGeogLocationMethod.Size = New System.Drawing.Size(129, 22)
        Me.ucrTextBoxGeogLocationMethod.TabIndex = 86
        Me.ucrTextBoxGeogLocationMethod.Tag = "geoLocationMethod"
        Me.ucrTextBoxGeogLocationMethod.TextboxValue = ""
        '
        'ucrTextBoxGeoglocationHistory
        '
        Me.ucrTextBoxGeoglocationHistory.FieldName = "geoLocationAccuracy"
        Me.ucrTextBoxGeoglocationHistory.Location = New System.Drawing.Point(275, 127)
        Me.ucrTextBoxGeoglocationHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxGeoglocationHistory.Name = "ucrTextBoxGeoglocationHistory"
        Me.ucrTextBoxGeoglocationHistory.Size = New System.Drawing.Size(129, 24)
        Me.ucrTextBoxGeoglocationHistory.TabIndex = 87
        Me.ucrTextBoxGeoglocationHistory.Tag = "geoLocationAccuracy"
        Me.ucrTextBoxGeoglocationHistory.TextboxValue = ""
        '
        'ucrTextBoxLatitude
        '
        Me.ucrTextBoxLatitude.FieldName = "latitude"
        Me.ucrTextBoxLatitude.Location = New System.Drawing.Point(275, 214)
        Me.ucrTextBoxLatitude.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLatitude.Name = "ucrTextBoxLatitude"
        Me.ucrTextBoxLatitude.Size = New System.Drawing.Size(129, 20)
        Me.ucrTextBoxLatitude.TabIndex = 90
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
        Me.ucrTextBoxLongitude.TabIndex = 91
        Me.ucrTextBoxLongitude.Tag = "longitude"
        Me.ucrTextBoxLongitude.TextboxValue = ""
        '
        'ucrTextBoxElevation
        '
        Me.ucrTextBoxElevation.FieldName = "elevation"
        Me.ucrTextBoxElevation.Location = New System.Drawing.Point(276, 267)
        Me.ucrTextBoxElevation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxElevation.Name = "ucrTextBoxElevation"
        Me.ucrTextBoxElevation.Size = New System.Drawing.Size(128, 20)
        Me.ucrTextBoxElevation.TabIndex = 92
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
        Me.ucrTextBoxAuthority.TabIndex = 93
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.FieldName = "openingDatetime"
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(275, 153)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerOpeningDate.TabIndex = 110
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrDatePickerCkosingDate
        '
        Me.ucrDatePickerCkosingDate.FieldName = "closingDatetime"
        Me.ucrDatePickerCkosingDate.Location = New System.Drawing.Point(275, 180)
        Me.ucrDatePickerCkosingDate.Name = "ucrDatePickerCkosingDate"
        Me.ucrDatePickerCkosingDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerCkosingDate.TabIndex = 111
        Me.ucrDatePickerCkosingDate.Tag = "closingDatetime"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "belongsTo"
        Me.ucrStationSelector.Location = New System.Drawing.Point(275, 39)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(219, 27)
        Me.ucrStationSelector.TabIndex = 112
        Me.ucrStationSelector.Tag = "belongsTo"
        '
        'grpCommand2
        '
        Me.grpCommand2.Controls.Add(Me.btnAddNew)
        Me.grpCommand2.Controls.Add(Me.btnView)
        Me.grpCommand2.Controls.Add(Me.btnDelete)
        Me.grpCommand2.Controls.Add(Me.btnUpdate)
        Me.grpCommand2.Controls.Add(Me.btnSave)
        Me.grpCommand2.Location = New System.Drawing.Point(37, 344)
        Me.grpCommand2.Name = "grpCommand2"
        Me.grpCommand2.Size = New System.Drawing.Size(601, 31)
        Me.grpCommand2.TabIndex = 114
        Me.grpCommand2.TabStop = False
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(15, 4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(81, 27)
        Me.btnAddNew.TabIndex = 12
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(503, 6)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(81, 25)
        Me.btnView.TabIndex = 16
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(381, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 25)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(259, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 25)
        Me.btnUpdate.TabIndex = 14
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(137, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 25)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ucrNavigationStationLocationHistory
        '
        Me.ucrNavigationStationLocationHistory.Location = New System.Drawing.Point(141, 384)
        Me.ucrNavigationStationLocationHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStationLocationHistory.Name = "ucrNavigationStationLocationHistory"
        Me.ucrNavigationStationLocationHistory.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStationLocationHistory.TabIndex = 113
        '
        'ucrMetadataStationLocationHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpCommand2)
        Me.Controls.Add(Me.ucrNavigationStationLocationHistory)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrDatePickerCkosingDate)
        Me.Controls.Add(Me.ucrDatePickerOpeningDate)
        Me.Controls.Add(Me.ucrTextBoxAuthority)
        Me.Controls.Add(Me.ucrTextBoxElevation)
        Me.Controls.Add(Me.ucrTextBoxLongitude)
        Me.Controls.Add(Me.ucrTextBoxLatitude)
        Me.Controls.Add(Me.ucrTextBoxGeoglocationHistory)
        Me.Controls.Add(Me.ucrTextBoxGeogLocationMethod)
        Me.Controls.Add(Me.ucrTextBoxStationType)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lblClosingDate)
        Me.Controls.Add(Me.lblOpeningDate)
        Me.Controls.Add(Me.lblLatitude)
        Me.Controls.Add(Me.lblAuthority)
        Me.Controls.Add(Me.lblGeogLocationMethod)
        Me.Controls.Add(Me.lblElevation)
        Me.Controls.Add(Me.lblLongitude)
        Me.Controls.Add(Me.lblStationType)
        Me.Controls.Add(Me.lblGeogLocationAccuracy)
        Me.Controls.Add(Me.Label19)
        Me.Name = "ucrMetadataStationLocationHistory"
        Me.Size = New System.Drawing.Size(674, 414)
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
    Friend WithEvents lblGeogLocationMethod As Label
    Friend WithEvents lblElevation As Label
    Friend WithEvents lblLongitude As Label
    Friend WithEvents lblStationType As Label
    Friend WithEvents lblGeogLocationAccuracy As Label
    Friend WithEvents ucrTextBoxStationType As ucrTextBox
    Friend WithEvents ucrTextBoxGeogLocationMethod As ucrTextBox
    Friend WithEvents ucrTextBoxGeoglocationHistory As ucrTextBox
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
End Class
