<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationLocationHistory
    Inherits ClimsoftVer4.ucrBaseDataLink

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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ucrNavigationStationLocationHistory = New ClimsoftVer4.ucrNavigation()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmdViewHistory = New System.Windows.Forms.Button()
        Me.cmdDeleteHistory = New System.Windows.Forms.Button()
        Me.cmdUpdateHistory = New System.Windows.Forms.Button()
        Me.cmdAddHistory = New System.Windows.Forms.Button()
        Me.cmdClearHistory = New System.Windows.Forms.Button()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrDatePickerOpeningDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerCkosingDate = New ClimsoftVer4.ucrDatePicker()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
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
        Me.ucrTextBoxAuthority.Location = New System.Drawing.Point(276, 293)
        Me.ucrTextBoxAuthority.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAuthority.Name = "ucrTextBoxAuthority"
        Me.ucrTextBoxAuthority.Size = New System.Drawing.Size(128, 20)
        Me.ucrTextBoxAuthority.TabIndex = 93
        Me.ucrTextBoxAuthority.Tag = "authority"
        Me.ucrTextBoxAuthority.TextboxValue = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(737, 335)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 106
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ucrNavigationStationLocationHistory
        '
        Me.ucrNavigationStationLocationHistory.Location = New System.Drawing.Point(132, 332)
        Me.ucrNavigationStationLocationHistory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStationLocationHistory.Name = "ucrNavigationStationLocationHistory"
        Me.ucrNavigationStationLocationHistory.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStationLocationHistory.TabIndex = 107
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdViewHistory)
        Me.GroupBox10.Controls.Add(Me.cmdDeleteHistory)
        Me.GroupBox10.Controls.Add(Me.cmdUpdateHistory)
        Me.GroupBox10.Controls.Add(Me.cmdAddHistory)
        Me.GroupBox10.Controls.Add(Me.cmdClearHistory)
        Me.GroupBox10.Location = New System.Drawing.Point(3, 365)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(589, 34)
        Me.GroupBox10.TabIndex = 108
        Me.GroupBox10.TabStop = False
        '
        'cmdViewHistory
        '
        Me.cmdViewHistory.Location = New System.Drawing.Point(499, 7)
        Me.cmdViewHistory.Name = "cmdViewHistory"
        Me.cmdViewHistory.Size = New System.Drawing.Size(81, 25)
        Me.cmdViewHistory.TabIndex = 20
        Me.cmdViewHistory.Text = "View"
        Me.cmdViewHistory.UseVisualStyleBackColor = True
        '
        'cmdDeleteHistory
        '
        Me.cmdDeleteHistory.Location = New System.Drawing.Point(387, 8)
        Me.cmdDeleteHistory.Name = "cmdDeleteHistory"
        Me.cmdDeleteHistory.Size = New System.Drawing.Size(81, 25)
        Me.cmdDeleteHistory.TabIndex = 19
        Me.cmdDeleteHistory.Text = "Delete"
        Me.cmdDeleteHistory.UseVisualStyleBackColor = True
        '
        'cmdUpdateHistory
        '
        Me.cmdUpdateHistory.Location = New System.Drawing.Point(275, 8)
        Me.cmdUpdateHistory.Name = "cmdUpdateHistory"
        Me.cmdUpdateHistory.Size = New System.Drawing.Size(81, 25)
        Me.cmdUpdateHistory.TabIndex = 18
        Me.cmdUpdateHistory.Text = "Update"
        Me.cmdUpdateHistory.UseVisualStyleBackColor = True
        '
        'cmdAddHistory
        '
        Me.cmdAddHistory.Location = New System.Drawing.Point(163, 8)
        Me.cmdAddHistory.Name = "cmdAddHistory"
        Me.cmdAddHistory.Size = New System.Drawing.Size(81, 25)
        Me.cmdAddHistory.TabIndex = 17
        Me.cmdAddHistory.Text = "Save"
        Me.cmdAddHistory.UseVisualStyleBackColor = True
        '
        'cmdClearHistory
        '
        Me.cmdClearHistory.Location = New System.Drawing.Point(51, 7)
        Me.cmdClearHistory.Name = "cmdClearHistory"
        Me.cmdClearHistory.Size = New System.Drawing.Size(81, 27)
        Me.cmdClearHistory.TabIndex = 16
        Me.cmdClearHistory.Text = "AddNew"
        Me.cmdClearHistory.UseVisualStyleBackColor = True
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(275, 46)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(253, 24)
        Me.ucrStationSelector.TabIndex = 109
        Me.ucrStationSelector.Tag = "station"
        '
        'ucrDatePickerOpeningDate
        '
        Me.ucrDatePickerOpeningDate.Location = New System.Drawing.Point(275, 153)
        Me.ucrDatePickerOpeningDate.Name = "ucrDatePickerOpeningDate"
        Me.ucrDatePickerOpeningDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerOpeningDate.TabIndex = 110
        Me.ucrDatePickerOpeningDate.Tag = "openingDatetime"
        '
        'ucrDatePickerCkosingDate
        '
        Me.ucrDatePickerCkosingDate.Location = New System.Drawing.Point(275, 180)
        Me.ucrDatePickerCkosingDate.Name = "ucrDatePickerCkosingDate"
        Me.ucrDatePickerCkosingDate.Size = New System.Drawing.Size(129, 21)
        Me.ucrDatePickerCkosingDate.TabIndex = 111
        Me.ucrDatePickerCkosingDate.Tag = "closingDatetime"
        '
        'ucrMetadataStationLocationHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDatePickerCkosingDate)
        Me.Controls.Add(Me.ucrDatePickerOpeningDate)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.ucrNavigationStationLocationHistory)
        Me.Controls.Add(Me.Button1)
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
        Me.Size = New System.Drawing.Size(601, 414)
        Me.Tag = ""
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
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
    Friend WithEvents Button1 As Button
    Friend WithEvents ucrNavigationStationLocationHistory As ucrNavigation
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents cmdViewHistory As Button
    Friend WithEvents cmdDeleteHistory As Button
    Friend WithEvents cmdUpdateHistory As Button
    Friend WithEvents cmdAddHistory As Button
    Friend WithEvents cmdClearHistory As Button
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrDatePickerOpeningDate As ucrDatePicker
    Friend WithEvents ucrDatePickerCkosingDate As ucrDatePicker
End Class
