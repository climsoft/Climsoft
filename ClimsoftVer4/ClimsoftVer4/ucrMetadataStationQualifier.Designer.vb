<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationQualifier
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
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.lblNetworkType = New System.Windows.Forms.Label()
        Me.lblTimeZone = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblBeginDate = New System.Windows.Forms.Label()
        Me.lblQualifier = New System.Windows.Forms.Label()
        Me.lblStationQualifier = New System.Windows.Forms.Label()
        Me.ucrTextBoxQualifier = New ClimsoftVer4.ucrTextBox()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.grpCommand2 = New System.Windows.Forms.GroupBox()
        Me.cmdAddNewStationQualifier = New System.Windows.Forms.Button()
        Me.cmdViewStationQualifier = New System.Windows.Forms.Button()
        Me.cmdDeleteStationQualifier = New System.Windows.Forms.Button()
        Me.cmdUpdateQualifier = New System.Windows.Forms.Button()
        Me.cmdSaveStationQualifier = New System.Windows.Forms.Button()
        Me.ucrTextBoxNetworkType = New ClimsoftVer4.ucrTextBox()
        Me.ucrNavigationStationQualifier = New ClimsoftVer4.ucrNavigation()
        Me.ucrTextBoxTimeZone = New ClimsoftVer4.ucrTextBox()
        Me.ucrDatePickerBeginDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerEndDate = New ClimsoftVer4.ucrDatePicker()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCommand2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(224, 126)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 68
        Me.lblStationID.Text = "Station ID"
        '
        'lblNetworkType
        '
        Me.lblNetworkType.AutoSize = True
        Me.lblNetworkType.Location = New System.Drawing.Point(224, 275)
        Me.lblNetworkType.Name = "lblNetworkType"
        Me.lblNetworkType.Size = New System.Drawing.Size(74, 13)
        Me.lblNetworkType.TabIndex = 72
        Me.lblNetworkType.Text = "Network Type"
        '
        'lblTimeZone
        '
        Me.lblTimeZone.AutoSize = True
        Me.lblTimeZone.Location = New System.Drawing.Point(224, 238)
        Me.lblTimeZone.Name = "lblTimeZone"
        Me.lblTimeZone.Size = New System.Drawing.Size(58, 13)
        Me.lblTimeZone.TabIndex = 71
        Me.lblTimeZone.Text = "Time Zone"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(224, 201)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(52, 13)
        Me.lblEndDate.TabIndex = 70
        Me.lblEndDate.Text = "End Date"
        '
        'lblBeginDate
        '
        Me.lblBeginDate.AutoSize = True
        Me.lblBeginDate.Location = New System.Drawing.Point(224, 164)
        Me.lblBeginDate.Name = "lblBeginDate"
        Me.lblBeginDate.Size = New System.Drawing.Size(60, 13)
        Me.lblBeginDate.TabIndex = 69
        Me.lblBeginDate.Text = "Begin Date"
        '
        'lblQualifier
        '
        Me.lblQualifier.AutoSize = True
        Me.lblQualifier.Location = New System.Drawing.Point(224, 89)
        Me.lblQualifier.Name = "lblQualifier"
        Me.lblQualifier.Size = New System.Drawing.Size(45, 13)
        Me.lblQualifier.TabIndex = 67
        Me.lblQualifier.Text = "Qualifier"
        '
        'lblStationQualifier
        '
        Me.lblStationQualifier.AutoSize = True
        Me.lblStationQualifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationQualifier.Location = New System.Drawing.Point(281, 30)
        Me.lblStationQualifier.Name = "lblStationQualifier"
        Me.lblStationQualifier.Size = New System.Drawing.Size(118, 16)
        Me.lblStationQualifier.TabIndex = 75
        Me.lblStationQualifier.Text = "Station Qualifier"
        '
        'ucrTextBoxQualifier
        '
        Me.ucrTextBoxQualifier.FieldName = "qualifier"
        Me.ucrTextBoxQualifier.Location = New System.Drawing.Point(301, 89)
        Me.ucrTextBoxQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxQualifier.Name = "ucrTextBoxQualifier"
        Me.ucrTextBoxQualifier.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxQualifier.TabIndex = 76
        Me.ucrTextBoxQualifier.Tag = "qualifier"
        Me.ucrTextBoxQualifier.TextboxValue = ""
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "belongsTo"
        Me.ucrStationSelector.Location = New System.Drawing.Point(301, 126)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(155, 24)
        Me.ucrStationSelector.TabIndex = 77
        Me.ucrStationSelector.Tag = "belongsTo"
        '
        'grpCommand2
        '
        Me.grpCommand2.Controls.Add(Me.cmdAddNewStationQualifier)
        Me.grpCommand2.Controls.Add(Me.cmdViewStationQualifier)
        Me.grpCommand2.Controls.Add(Me.cmdDeleteStationQualifier)
        Me.grpCommand2.Controls.Add(Me.cmdUpdateQualifier)
        Me.grpCommand2.Controls.Add(Me.cmdSaveStationQualifier)
        Me.grpCommand2.Location = New System.Drawing.Point(3, 335)
        Me.grpCommand2.Name = "grpCommand2"
        Me.grpCommand2.Size = New System.Drawing.Size(670, 31)
        Me.grpCommand2.TabIndex = 96
        Me.grpCommand2.TabStop = False
        '
        'cmdAddNewStationQualifier
        '
        Me.cmdAddNewStationQualifier.Location = New System.Drawing.Point(95, 4)
        Me.cmdAddNewStationQualifier.Name = "cmdAddNewStationQualifier"
        Me.cmdAddNewStationQualifier.Size = New System.Drawing.Size(81, 27)
        Me.cmdAddNewStationQualifier.TabIndex = 12
        Me.cmdAddNewStationQualifier.Text = "AddNew"
        Me.cmdAddNewStationQualifier.UseVisualStyleBackColor = True
        '
        'cmdViewStationQualifier
        '
        Me.cmdViewStationQualifier.Location = New System.Drawing.Point(583, 6)
        Me.cmdViewStationQualifier.Name = "cmdViewStationQualifier"
        Me.cmdViewStationQualifier.Size = New System.Drawing.Size(81, 25)
        Me.cmdViewStationQualifier.TabIndex = 16
        Me.cmdViewStationQualifier.Text = "View"
        Me.cmdViewStationQualifier.UseVisualStyleBackColor = True
        '
        'cmdDeleteStationQualifier
        '
        Me.cmdDeleteStationQualifier.Location = New System.Drawing.Point(461, 5)
        Me.cmdDeleteStationQualifier.Name = "cmdDeleteStationQualifier"
        Me.cmdDeleteStationQualifier.Size = New System.Drawing.Size(81, 25)
        Me.cmdDeleteStationQualifier.TabIndex = 15
        Me.cmdDeleteStationQualifier.Text = "Delete"
        Me.cmdDeleteStationQualifier.UseVisualStyleBackColor = True
        '
        'cmdUpdateQualifier
        '
        Me.cmdUpdateQualifier.Location = New System.Drawing.Point(339, 5)
        Me.cmdUpdateQualifier.Name = "cmdUpdateQualifier"
        Me.cmdUpdateQualifier.Size = New System.Drawing.Size(81, 25)
        Me.cmdUpdateQualifier.TabIndex = 14
        Me.cmdUpdateQualifier.Text = "Update"
        Me.cmdUpdateQualifier.UseVisualStyleBackColor = True
        '
        'cmdSaveStationQualifier
        '
        Me.cmdSaveStationQualifier.Location = New System.Drawing.Point(217, 5)
        Me.cmdSaveStationQualifier.Name = "cmdSaveStationQualifier"
        Me.cmdSaveStationQualifier.Size = New System.Drawing.Size(81, 25)
        Me.cmdSaveStationQualifier.TabIndex = 13
        Me.cmdSaveStationQualifier.Text = "Save"
        Me.cmdSaveStationQualifier.UseVisualStyleBackColor = True
        '
        'ucrTextBoxNetworkType
        '
        Me.ucrTextBoxNetworkType.FieldName = "stationNetworkType"
        Me.ucrTextBoxNetworkType.Location = New System.Drawing.Point(301, 274)
        Me.ucrTextBoxNetworkType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxNetworkType.Name = "ucrTextBoxNetworkType"
        Me.ucrTextBoxNetworkType.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxNetworkType.TabIndex = 17
        Me.ucrTextBoxNetworkType.Tag = "stationNetworkType"
        Me.ucrTextBoxNetworkType.TextboxValue = ""
        '
        'ucrNavigationStationQualifier
        '
        Me.ucrNavigationStationQualifier.Location = New System.Drawing.Point(170, 375)
        Me.ucrNavigationStationQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStationQualifier.Name = "ucrNavigationStationQualifier"
        Me.ucrNavigationStationQualifier.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationStationQualifier.TabIndex = 95
        '
        'ucrTextBoxTimeZone
        '
        Me.ucrTextBoxTimeZone.FieldName = "stationTimeZone"
        Me.ucrTextBoxTimeZone.Location = New System.Drawing.Point(301, 237)
        Me.ucrTextBoxTimeZone.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxTimeZone.Name = "ucrTextBoxTimeZone"
        Me.ucrTextBoxTimeZone.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxTimeZone.TabIndex = 97
        Me.ucrTextBoxTimeZone.Tag = "stationTimeZone"
        Me.ucrTextBoxTimeZone.TextboxValue = ""
        '
        'ucrDatePickerBeginDate
        '
        Me.ucrDatePickerBeginDate.FieldName = "qualifierBeginDate"
        Me.ucrDatePickerBeginDate.Location = New System.Drawing.Point(301, 160)
        Me.ucrDatePickerBeginDate.Name = "ucrDatePickerBeginDate"
        Me.ucrDatePickerBeginDate.Size = New System.Drawing.Size(155, 21)
        Me.ucrDatePickerBeginDate.TabIndex = 98
        Me.ucrDatePickerBeginDate.Tag = "qualifierBeginDate"
        '
        'ucrDatePickerEndDate
        '
        Me.ucrDatePickerEndDate.FieldName = "qualifierEndDate"
        Me.ucrDatePickerEndDate.Location = New System.Drawing.Point(301, 196)
        Me.ucrDatePickerEndDate.Name = "ucrDatePickerEndDate"
        Me.ucrDatePickerEndDate.Size = New System.Drawing.Size(155, 21)
        Me.ucrDatePickerEndDate.TabIndex = 99
        Me.ucrDatePickerEndDate.Tag = "qualifierEndDate"
        '
        'ucrMetadataStationQualifier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDatePickerEndDate)
        Me.Controls.Add(Me.ucrDatePickerBeginDate)
        Me.Controls.Add(Me.ucrTextBoxTimeZone)
        Me.Controls.Add(Me.ucrTextBoxNetworkType)
        Me.Controls.Add(Me.grpCommand2)
        Me.Controls.Add(Me.ucrNavigationStationQualifier)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrTextBoxQualifier)
        Me.Controls.Add(Me.lblStationQualifier)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.lblNetworkType)
        Me.Controls.Add(Me.lblTimeZone)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblBeginDate)
        Me.Controls.Add(Me.lblQualifier)
        Me.Name = "ucrMetadataStationQualifier"
        Me.Size = New System.Drawing.Size(680, 402)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCommand2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStationID As Label
    Friend WithEvents lblNetworkType As Label
    Friend WithEvents lblTimeZone As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblBeginDate As Label
    Friend WithEvents lblQualifier As Label
    Friend WithEvents lblStationQualifier As Label
    Friend WithEvents ucrTextBoxQualifier As ucrTextBox
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents grpCommand2 As GroupBox
    Friend WithEvents cmdAddNewStationQualifier As Button
    Friend WithEvents cmdViewStationQualifier As Button
    Friend WithEvents cmdDeleteStationQualifier As Button
    Friend WithEvents cmdUpdateQualifier As Button
    Friend WithEvents cmdSaveStationQualifier As Button
    Friend WithEvents ucrNavigationStationQualifier As ucrNavigation
    Friend WithEvents ucrTextBoxNetworkType As ucrTextBox
    Friend WithEvents ucrTextBoxTimeZone As ucrTextBox
    Friend WithEvents ucrDatePickerBeginDate As ucrDatePicker
    Friend WithEvents ucrDatePickerEndDate As ucrDatePicker
End Class
