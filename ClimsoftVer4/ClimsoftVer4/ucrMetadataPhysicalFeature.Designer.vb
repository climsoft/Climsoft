<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataPhysicalFeature
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
        Me.cmdOpenFile = New System.Windows.Forms.Button()
        Me.lblClassDescription = New System.Windows.Forms.Label()
        Me.txtFeatureEdate = New System.Windows.Forms.TextBox()
        Me.txtFeatureBdate = New System.Windows.Forms.TextBox()
        Me.lblFeatureImageFile = New System.Windows.Forms.Label()
        Me.lblFeaturePicture = New System.Windows.Forms.Label()
        Me.txtFeaturePicture = New System.Windows.Forms.PictureBox()
        Me.txtFeaturedEdate = New System.Windows.Forms.DateTimePicker()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.txtFeaturedBdate = New System.Windows.Forms.DateTimePicker()
        Me.lblFeatureDescription = New System.Windows.Forms.Label()
        Me.lblFeatureClass = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblBeginDate = New System.Windows.Forms.Label()
        Me.lblPhysicalFeature = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.cmdViewScheduleClass = New System.Windows.Forms.Button()
        Me.cmdDeleteScheduleClass = New System.Windows.Forms.Button()
        Me.cmdUpdateScheduleClass = New System.Windows.Forms.Button()
        Me.cmdAddScheduleClass = New System.Windows.Forms.Button()
        Me.cmdClearClass = New System.Windows.Forms.Button()
        Me.ucrNavigationPhysicalFeature = New ClimsoftVer4.ucrNavigation()
        Me.ucrStationSelectorStation = New ClimsoftVer4.ucrStationSelector()
        Me.ucrTextBoxFeatureDescription = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxFeatureClass = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxClassDescription = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxFeatureImageFile = New ClimsoftVer4.ucrTextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFeaturePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOpenFile
        '
        Me.cmdOpenFile.Location = New System.Drawing.Point(326, 295)
        Me.cmdOpenFile.Name = "cmdOpenFile"
        Me.cmdOpenFile.Size = New System.Drawing.Size(49, 27)
        Me.cmdOpenFile.TabIndex = 86
        Me.cmdOpenFile.Text = "Open"
        Me.cmdOpenFile.UseVisualStyleBackColor = True
        '
        'lblClassDescription
        '
        Me.lblClassDescription.AutoSize = True
        Me.lblClassDescription.Location = New System.Drawing.Point(39, 273)
        Me.lblClassDescription.Name = "lblClassDescription"
        Me.lblClassDescription.Size = New System.Drawing.Size(88, 13)
        Me.lblClassDescription.TabIndex = 85
        Me.lblClassDescription.Text = "Class Description"
        '
        'txtFeatureEdate
        '
        Me.txtFeatureEdate.Location = New System.Drawing.Point(142, 176)
        Me.txtFeatureEdate.Name = "txtFeatureEdate"
        Me.txtFeatureEdate.Size = New System.Drawing.Size(137, 20)
        Me.txtFeatureEdate.TabIndex = 83
        '
        'txtFeatureBdate
        '
        Me.txtFeatureBdate.Location = New System.Drawing.Point(141, 145)
        Me.txtFeatureBdate.Name = "txtFeatureBdate"
        Me.txtFeatureBdate.Size = New System.Drawing.Size(137, 20)
        Me.txtFeatureBdate.TabIndex = 82
        '
        'lblFeatureImageFile
        '
        Me.lblFeatureImageFile.AutoSize = True
        Me.lblFeatureImageFile.Location = New System.Drawing.Point(41, 304)
        Me.lblFeatureImageFile.Name = "lblFeatureImageFile"
        Me.lblFeatureImageFile.Size = New System.Drawing.Size(94, 13)
        Me.lblFeatureImageFile.TabIndex = 79
        Me.lblFeatureImageFile.Text = "Feature Image File"
        '
        'lblFeaturePicture
        '
        Me.lblFeaturePicture.AutoSize = True
        Me.lblFeaturePicture.Location = New System.Drawing.Point(471, 321)
        Me.lblFeaturePicture.Name = "lblFeaturePicture"
        Me.lblFeaturePicture.Size = New System.Drawing.Size(79, 13)
        Me.lblFeaturePicture.TabIndex = 81
        Me.lblFeaturePicture.Text = "Feature Picture"
        '
        'txtFeaturePicture
        '
        Me.txtFeaturePicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFeaturePicture.BackColor = System.Drawing.Color.Ivory
        Me.txtFeaturePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.txtFeaturePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtFeaturePicture.ImageLocation = ""
        Me.txtFeaturePicture.InitialImage = Nothing
        Me.txtFeaturePicture.Location = New System.Drawing.Point(377, 93)
        Me.txtFeaturePicture.Name = "txtFeaturePicture"
        Me.txtFeaturePicture.Size = New System.Drawing.Size(258, 227)
        Me.txtFeaturePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.txtFeaturePicture.TabIndex = 80
        Me.txtFeaturePicture.TabStop = False
        '
        'txtFeaturedEdate
        '
        Me.txtFeaturedEdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFeaturedEdate.Location = New System.Drawing.Point(275, 176)
        Me.txtFeaturedEdate.Name = "txtFeaturedEdate"
        Me.txtFeaturedEdate.Size = New System.Drawing.Size(20, 20)
        Me.txtFeaturedEdate.TabIndex = 70
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(40, 117)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 74
        Me.lblStationID.Text = "Station ID"
        '
        'txtFeaturedBdate
        '
        Me.txtFeaturedBdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFeaturedBdate.Location = New System.Drawing.Point(275, 145)
        Me.txtFeaturedBdate.Name = "txtFeaturedBdate"
        Me.txtFeaturedBdate.Size = New System.Drawing.Size(20, 20)
        Me.txtFeaturedBdate.TabIndex = 69
        '
        'lblFeatureDescription
        '
        Me.lblFeatureDescription.AutoSize = True
        Me.lblFeatureDescription.Location = New System.Drawing.Point(39, 211)
        Me.lblFeatureDescription.Name = "lblFeatureDescription"
        Me.lblFeatureDescription.Size = New System.Drawing.Size(99, 13)
        Me.lblFeatureDescription.TabIndex = 77
        Me.lblFeatureDescription.Text = "Feature Description"
        '
        'lblFeatureClass
        '
        Me.lblFeatureClass.AutoSize = True
        Me.lblFeatureClass.Location = New System.Drawing.Point(41, 242)
        Me.lblFeatureClass.Name = "lblFeatureClass"
        Me.lblFeatureClass.Size = New System.Drawing.Size(71, 13)
        Me.lblFeatureClass.TabIndex = 78
        Me.lblFeatureClass.Text = "Feature Class"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(39, 180)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(52, 13)
        Me.lblEndDate.TabIndex = 76
        Me.lblEndDate.Text = "End Date"
        '
        'lblBeginDate
        '
        Me.lblBeginDate.AutoSize = True
        Me.lblBeginDate.Location = New System.Drawing.Point(39, 149)
        Me.lblBeginDate.Name = "lblBeginDate"
        Me.lblBeginDate.Size = New System.Drawing.Size(60, 13)
        Me.lblBeginDate.TabIndex = 75
        Me.lblBeginDate.Text = "Begin Date"
        '
        'lblPhysicalFeature
        '
        Me.lblPhysicalFeature.AutoSize = True
        Me.lblPhysicalFeature.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhysicalFeature.Location = New System.Drawing.Point(269, 15)
        Me.lblPhysicalFeature.Name = "lblPhysicalFeature"
        Me.lblPhysicalFeature.Size = New System.Drawing.Size(124, 16)
        Me.lblPhysicalFeature.TabIndex = 87
        Me.lblPhysicalFeature.Text = "Physical Feature"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdViewScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdDeleteScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdUpdateScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdAddScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdClearClass)
        Me.GroupBox13.Location = New System.Drawing.Point(72, 352)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(519, 34)
        Me.GroupBox13.TabIndex = 108
        Me.GroupBox13.TabStop = False
        '
        'cmdViewScheduleClass
        '
        Me.cmdViewScheduleClass.Location = New System.Drawing.Point(420, 6)
        Me.cmdViewScheduleClass.Name = "cmdViewScheduleClass"
        Me.cmdViewScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdViewScheduleClass.TabIndex = 8
        Me.cmdViewScheduleClass.Text = "View"
        Me.cmdViewScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdDeleteScheduleClass
        '
        Me.cmdDeleteScheduleClass.Location = New System.Drawing.Point(318, 6)
        Me.cmdDeleteScheduleClass.Name = "cmdDeleteScheduleClass"
        Me.cmdDeleteScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdDeleteScheduleClass.TabIndex = 7
        Me.cmdDeleteScheduleClass.Text = "Delete"
        Me.cmdDeleteScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdUpdateScheduleClass
        '
        Me.cmdUpdateScheduleClass.Location = New System.Drawing.Point(216, 6)
        Me.cmdUpdateScheduleClass.Name = "cmdUpdateScheduleClass"
        Me.cmdUpdateScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdUpdateScheduleClass.TabIndex = 6
        Me.cmdUpdateScheduleClass.Text = "Update"
        Me.cmdUpdateScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdAddScheduleClass
        '
        Me.cmdAddScheduleClass.Location = New System.Drawing.Point(114, 7)
        Me.cmdAddScheduleClass.Name = "cmdAddScheduleClass"
        Me.cmdAddScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdAddScheduleClass.TabIndex = 5
        Me.cmdAddScheduleClass.Text = "Save"
        Me.cmdAddScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdClearClass
        '
        Me.cmdClearClass.Location = New System.Drawing.Point(12, 5)
        Me.cmdClearClass.Name = "cmdClearClass"
        Me.cmdClearClass.Size = New System.Drawing.Size(81, 27)
        Me.cmdClearClass.TabIndex = 4
        Me.cmdClearClass.Text = "AddNew"
        Me.cmdClearClass.UseVisualStyleBackColor = True
        '
        'ucrNavigationPhysicalFeature
        '
        Me.ucrNavigationPhysicalFeature.Location = New System.Drawing.Point(163, 397)
        Me.ucrNavigationPhysicalFeature.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationPhysicalFeature.Name = "ucrNavigationPhysicalFeature"
        Me.ucrNavigationPhysicalFeature.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationPhysicalFeature.TabIndex = 107
        '
        'ucrStationSelectorStation
        '
        Me.ucrStationSelectorStation.Location = New System.Drawing.Point(141, 106)
        Me.ucrStationSelectorStation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelectorStation.Name = "ucrStationSelectorStation"
        Me.ucrStationSelectorStation.Size = New System.Drawing.Size(154, 24)
        Me.ucrStationSelectorStation.TabIndex = 9
        '
        'ucrTextBoxFeatureDescription
        '
        Me.ucrTextBoxFeatureDescription.Location = New System.Drawing.Point(141, 204)
        Me.ucrTextBoxFeatureDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureDescription.Name = "ucrTextBoxFeatureDescription"
        Me.ucrTextBoxFeatureDescription.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxFeatureDescription.TabIndex = 109
        Me.ucrTextBoxFeatureDescription.TextboxValue = ""
        '
        'ucrTextBoxFeatureClass
        '
        Me.ucrTextBoxFeatureClass.Location = New System.Drawing.Point(141, 234)
        Me.ucrTextBoxFeatureClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureClass.Name = "ucrTextBoxFeatureClass"
        Me.ucrTextBoxFeatureClass.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxFeatureClass.TabIndex = 110
        Me.ucrTextBoxFeatureClass.TextboxValue = ""
        '
        'ucrTextBoxClassDescription
        '
        Me.ucrTextBoxClassDescription.Location = New System.Drawing.Point(141, 264)
        Me.ucrTextBoxClassDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxClassDescription.Name = "ucrTextBoxClassDescription"
        Me.ucrTextBoxClassDescription.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxClassDescription.TabIndex = 111
        Me.ucrTextBoxClassDescription.TextboxValue = ""
        '
        'ucrTextBoxFeatureImageFile
        '
        Me.ucrTextBoxFeatureImageFile.Location = New System.Drawing.Point(141, 300)
        Me.ucrTextBoxFeatureImageFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureImageFile.Name = "ucrTextBoxFeatureImageFile"
        Me.ucrTextBoxFeatureImageFile.Size = New System.Drawing.Size(180, 20)
        Me.ucrTextBoxFeatureImageFile.TabIndex = 112
        Me.ucrTextBoxFeatureImageFile.TextboxValue = ""
        '
        'ucrMetadataPhysicalFeature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextBoxFeatureImageFile)
        Me.Controls.Add(Me.ucrTextBoxClassDescription)
        Me.Controls.Add(Me.ucrTextBoxFeatureClass)
        Me.Controls.Add(Me.ucrTextBoxFeatureDescription)
        Me.Controls.Add(Me.ucrStationSelectorStation)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrNavigationPhysicalFeature)
        Me.Controls.Add(Me.lblPhysicalFeature)
        Me.Controls.Add(Me.cmdOpenFile)
        Me.Controls.Add(Me.lblClassDescription)
        Me.Controls.Add(Me.txtFeatureEdate)
        Me.Controls.Add(Me.txtFeatureBdate)
        Me.Controls.Add(Me.lblFeatureImageFile)
        Me.Controls.Add(Me.lblFeaturePicture)
        Me.Controls.Add(Me.txtFeaturePicture)
        Me.Controls.Add(Me.txtFeaturedEdate)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.txtFeaturedBdate)
        Me.Controls.Add(Me.lblFeatureDescription)
        Me.Controls.Add(Me.lblFeatureClass)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblBeginDate)
        Me.Name = "ucrMetadataPhysicalFeature"
        Me.Size = New System.Drawing.Size(662, 427)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFeaturePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdOpenFile As Button
    Friend WithEvents lblClassDescription As Label
    Friend WithEvents txtFeatureEdate As TextBox
    Friend WithEvents txtFeatureBdate As TextBox
    Friend WithEvents lblFeatureImageFile As Label
    Friend WithEvents lblFeaturePicture As Label
    Friend WithEvents txtFeaturePicture As PictureBox
    Friend WithEvents txtFeaturedEdate As DateTimePicker
    Friend WithEvents lblStationID As Label
    Friend WithEvents txtFeaturedBdate As DateTimePicker
    Friend WithEvents lblFeatureDescription As Label
    Friend WithEvents lblFeatureClass As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblBeginDate As Label
    Friend WithEvents lblPhysicalFeature As Label
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents cmdViewScheduleClass As Button
    Friend WithEvents cmdDeleteScheduleClass As Button
    Friend WithEvents cmdUpdateScheduleClass As Button
    Friend WithEvents cmdAddScheduleClass As Button
    Friend WithEvents cmdClearClass As Button
    Friend WithEvents ucrNavigationPhysicalFeature As ucrNavigation
    Friend WithEvents ucrStationSelectorStation As ucrStationSelector
    Friend WithEvents ucrTextBoxFeatureDescription As ucrTextBox
    Friend WithEvents ucrTextBoxFeatureClass As ucrTextBox
    Friend WithEvents ucrTextBoxClassDescription As ucrTextBox
    Friend WithEvents ucrTextBoxFeatureImageFile As ucrTextBox
End Class
