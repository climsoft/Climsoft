﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataPhysicalFeature
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
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.lblFeatureImageFile = New System.Windows.Forms.Label()
        Me.lblFeaturePicture = New System.Windows.Forms.Label()
        Me.pbFeaturePicture = New System.Windows.Forms.PictureBox()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.lblFeatureDescription = New System.Windows.Forms.Label()
        Me.lblFeatureClass = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblBeginDate = New System.Windows.Forms.Label()
        Me.lblPhysicalFeature = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.ucrNavigationPhysicalFeature = New ClimsoftVer4.ucrNavigation()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrTextBoxFeatureDescription = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxFeatureClass = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxFeatureImageFile = New ClimsoftVer4.ucrTextBox()
        Me.ucrDatePickerBeginDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerEndDate = New ClimsoftVer4.ucrDatePicker()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbFeaturePicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(326, 295)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(49, 27)
        Me.btnOpenFile.TabIndex = 15
        Me.btnOpenFile.Text = "Open"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'lblFeatureImageFile
        '
        Me.lblFeatureImageFile.AutoSize = True
        Me.lblFeatureImageFile.Location = New System.Drawing.Point(41, 304)
        Me.lblFeatureImageFile.Name = "lblFeatureImageFile"
        Me.lblFeatureImageFile.Size = New System.Drawing.Size(94, 13)
        Me.lblFeatureImageFile.TabIndex = 13
        Me.lblFeatureImageFile.Text = "Feature Image File"
        '
        'lblFeaturePicture
        '
        Me.lblFeaturePicture.AutoSize = True
        Me.lblFeaturePicture.Location = New System.Drawing.Point(471, 321)
        Me.lblFeaturePicture.Name = "lblFeaturePicture"
        Me.lblFeaturePicture.Size = New System.Drawing.Size(79, 13)
        Me.lblFeaturePicture.TabIndex = 16
        Me.lblFeaturePicture.Text = "Feature Picture"
        '
        'pbFeaturePicture
        '
        Me.pbFeaturePicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFeaturePicture.BackColor = System.Drawing.Color.Ivory
        Me.pbFeaturePicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbFeaturePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbFeaturePicture.ImageLocation = ""
        Me.pbFeaturePicture.InitialImage = Nothing
        Me.pbFeaturePicture.Location = New System.Drawing.Point(377, 93)
        Me.pbFeaturePicture.Name = "pbFeaturePicture"
        Me.pbFeaturePicture.Size = New System.Drawing.Size(258, 227)
        Me.pbFeaturePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbFeaturePicture.TabIndex = 80
        Me.pbFeaturePicture.TabStop = False
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(40, 117)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 1
        Me.lblStationID.Text = "Station ID"
        '
        'lblFeatureDescription
        '
        Me.lblFeatureDescription.AutoSize = True
        Me.lblFeatureDescription.Location = New System.Drawing.Point(39, 211)
        Me.lblFeatureDescription.Name = "lblFeatureDescription"
        Me.lblFeatureDescription.Size = New System.Drawing.Size(99, 13)
        Me.lblFeatureDescription.TabIndex = 7
        Me.lblFeatureDescription.Text = "Feature Description"
        '
        'lblFeatureClass
        '
        Me.lblFeatureClass.AutoSize = True
        Me.lblFeatureClass.Location = New System.Drawing.Point(41, 242)
        Me.lblFeatureClass.Name = "lblFeatureClass"
        Me.lblFeatureClass.Size = New System.Drawing.Size(71, 13)
        Me.lblFeatureClass.TabIndex = 9
        Me.lblFeatureClass.Text = "Feature Class"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(39, 180)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(52, 13)
        Me.lblEndDate.TabIndex = 5
        Me.lblEndDate.Text = "End Date"
        '
        'lblBeginDate
        '
        Me.lblBeginDate.AutoSize = True
        Me.lblBeginDate.Location = New System.Drawing.Point(39, 149)
        Me.lblBeginDate.Name = "lblBeginDate"
        Me.lblBeginDate.Size = New System.Drawing.Size(60, 13)
        Me.lblBeginDate.TabIndex = 3
        Me.lblBeginDate.Text = "Begin Date"
        '
        'lblPhysicalFeature
        '
        Me.lblPhysicalFeature.AutoSize = True
        Me.lblPhysicalFeature.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhysicalFeature.Location = New System.Drawing.Point(269, 15)
        Me.lblPhysicalFeature.Name = "lblPhysicalFeature"
        Me.lblPhysicalFeature.Size = New System.Drawing.Size(123, 16)
        Me.lblPhysicalFeature.TabIndex = 0
        Me.lblPhysicalFeature.Text = "Physical Feature"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(3, 352)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(611, 34)
        Me.GroupBox13.TabIndex = 17
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(398, 7)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(93, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(497, 7)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(93, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(299, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(93, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(200, 7)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(93, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(101, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(93, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(6, 7)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(89, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrNavigationPhysicalFeature
        '
        Me.ucrNavigationPhysicalFeature.Location = New System.Drawing.Point(163, 397)
        Me.ucrNavigationPhysicalFeature.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationPhysicalFeature.Name = "ucrNavigationPhysicalFeature"
        Me.ucrNavigationPhysicalFeature.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationPhysicalFeature.TabIndex = 18
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "associatedWith"
        Me.ucrStationSelector.KeyControl = False
        Me.ucrStationSelector.Location = New System.Drawing.Point(141, 106)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(154, 24)
        Me.ucrStationSelector.TabIndex = 2
        Me.ucrStationSelector.Tag = "associatedWith"
        '
        'ucrTextBoxFeatureDescription
        '
        Me.ucrTextBoxFeatureDescription.FieldName = "description"
        Me.ucrTextBoxFeatureDescription.KeyControl = False
        Me.ucrTextBoxFeatureDescription.Location = New System.Drawing.Point(141, 204)
        Me.ucrTextBoxFeatureDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureDescription.Name = "ucrTextBoxFeatureDescription"
        Me.ucrTextBoxFeatureDescription.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxFeatureDescription.TabIndex = 8
        Me.ucrTextBoxFeatureDescription.Tag = "description"
        Me.ucrTextBoxFeatureDescription.TextboxValue = ""
        '
        'ucrTextBoxFeatureClass
        '
        Me.ucrTextBoxFeatureClass.FieldName = "classifiedInto"
        Me.ucrTextBoxFeatureClass.KeyControl = False
        Me.ucrTextBoxFeatureClass.Location = New System.Drawing.Point(141, 234)
        Me.ucrTextBoxFeatureClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureClass.Name = "ucrTextBoxFeatureClass"
        Me.ucrTextBoxFeatureClass.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxFeatureClass.TabIndex = 10
        Me.ucrTextBoxFeatureClass.Tag = "classifiedInto"
        Me.ucrTextBoxFeatureClass.TextboxValue = ""
        '
        'ucrTextBoxFeatureImageFile
        '
        Me.ucrTextBoxFeatureImageFile.FieldName = "image"
        Me.ucrTextBoxFeatureImageFile.KeyControl = False
        Me.ucrTextBoxFeatureImageFile.Location = New System.Drawing.Point(141, 300)
        Me.ucrTextBoxFeatureImageFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFeatureImageFile.Name = "ucrTextBoxFeatureImageFile"
        Me.ucrTextBoxFeatureImageFile.Size = New System.Drawing.Size(180, 20)
        Me.ucrTextBoxFeatureImageFile.TabIndex = 14
        Me.ucrTextBoxFeatureImageFile.Tag = "image"
        Me.ucrTextBoxFeatureImageFile.TextboxValue = ""
        '
        'ucrDatePickerBeginDate
        '
        Me.ucrDatePickerBeginDate.FieldName = "beginDate"
        Me.ucrDatePickerBeginDate.KeyControl = False
        Me.ucrDatePickerBeginDate.Location = New System.Drawing.Point(141, 140)
        Me.ucrDatePickerBeginDate.Name = "ucrDatePickerBeginDate"
        Me.ucrDatePickerBeginDate.Size = New System.Drawing.Size(154, 21)
        Me.ucrDatePickerBeginDate.TabIndex = 4
        Me.ucrDatePickerBeginDate.Tag = "beginDate"
        '
        'ucrDatePickerEndDate
        '
        Me.ucrDatePickerEndDate.FieldName = "endDate"
        Me.ucrDatePickerEndDate.KeyControl = False
        Me.ucrDatePickerEndDate.Location = New System.Drawing.Point(141, 171)
        Me.ucrDatePickerEndDate.Name = "ucrDatePickerEndDate"
        Me.ucrDatePickerEndDate.Size = New System.Drawing.Size(154, 21)
        Me.ucrDatePickerEndDate.TabIndex = 6
        Me.ucrDatePickerEndDate.Tag = "endDate"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'ucrMetadataPhysicalFeature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDatePickerEndDate)
        Me.Controls.Add(Me.ucrDatePickerBeginDate)
        Me.Controls.Add(Me.ucrTextBoxFeatureImageFile)
        Me.Controls.Add(Me.ucrTextBoxFeatureClass)
        Me.Controls.Add(Me.ucrTextBoxFeatureDescription)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrNavigationPhysicalFeature)
        Me.Controls.Add(Me.lblPhysicalFeature)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.lblFeatureImageFile)
        Me.Controls.Add(Me.lblFeaturePicture)
        Me.Controls.Add(Me.pbFeaturePicture)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.lblFeatureDescription)
        Me.Controls.Add(Me.lblFeatureClass)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblBeginDate)
        Me.Name = "ucrMetadataPhysicalFeature"
        Me.Size = New System.Drawing.Size(662, 427)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbFeaturePicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOpenFile As Button
    Friend WithEvents lblFeatureImageFile As Label
    Friend WithEvents lblFeaturePicture As Label
    Friend WithEvents pbFeaturePicture As PictureBox
    Friend WithEvents lblStationID As Label
    Friend WithEvents lblFeatureDescription As Label
    Friend WithEvents lblFeatureClass As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents lblBeginDate As Label
    Friend WithEvents lblPhysicalFeature As Label
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents ucrNavigationPhysicalFeature As ucrNavigation
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrTextBoxFeatureDescription As ucrTextBox
    Friend WithEvents ucrTextBoxFeatureClass As ucrTextBox
    Friend WithEvents ucrTextBoxFeatureImageFile As ucrTextBox
    Friend WithEvents ucrDatePickerBeginDate As ucrDatePicker
    Friend WithEvents ucrDatePickerEndDate As ucrDatePicker
    Friend WithEvents btnClear As Button
    Friend WithEvents OpenFileDialog As OpenFileDialog
End Class
