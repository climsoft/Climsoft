<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataElement
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
        Me.chkTotalRequired = New System.Windows.Forms.CheckBox()
        Me.lblTotalRequired = New System.Windows.Forms.Label()
        Me.chkSelected = New System.Windows.Forms.CheckBox()
        Me.lblSelected = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblUpperlimit = New System.Windows.Forms.Label()
        Me.lblScale = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.lblLowerLimit = New System.Windows.Forms.Label()
        Me.lblAbbreviation = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.ucrNavigationElement = New ClimsoftVer4.ucrNavigation()
        Me.ucrDataLinkID = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrTextBoxAbbreviation = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxName = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDescription = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxScale = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxUpperLimit = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLowerLimit = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxUnit = New ClimsoftVer4.ucrTextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.cmdViewScheduleClass = New System.Windows.Forms.Button()
        Me.cmdDeleteScheduleClass = New System.Windows.Forms.Button()
        Me.cmdUpdateScheduleClass = New System.Windows.Forms.Button()
        Me.cmdAddScheduleClass = New System.Windows.Forms.Button()
        Me.cmdClearClass = New System.Windows.Forms.Button()
        Me.UcrDataLinkType = New ClimsoftVer4.ucrDataLinkCombobox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkTotalRequired
        '
        Me.chkTotalRequired.AutoSize = True
        Me.chkTotalRequired.Location = New System.Drawing.Point(299, 305)
        Me.chkTotalRequired.Name = "chkTotalRequired"
        Me.chkTotalRequired.Size = New System.Drawing.Size(15, 14)
        Me.chkTotalRequired.TabIndex = 79
        Me.chkTotalRequired.Tag = "qcTotalRequired"
        Me.chkTotalRequired.UseVisualStyleBackColor = True
        '
        'lblTotalRequired
        '
        Me.lblTotalRequired.AutoSize = True
        Me.lblTotalRequired.Location = New System.Drawing.Point(202, 306)
        Me.lblTotalRequired.Name = "lblTotalRequired"
        Me.lblTotalRequired.Size = New System.Drawing.Size(77, 13)
        Me.lblTotalRequired.TabIndex = 78
        Me.lblTotalRequired.Text = "Total Required"
        '
        'chkSelected
        '
        Me.chkSelected.AutoSize = True
        Me.chkSelected.Location = New System.Drawing.Point(298, 284)
        Me.chkSelected.Name = "chkSelected"
        Me.chkSelected.Size = New System.Drawing.Size(15, 14)
        Me.chkSelected.TabIndex = 77
        Me.chkSelected.Tag = "selected"
        Me.chkSelected.UseVisualStyleBackColor = True
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(201, 285)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(49, 13)
        Me.lblSelected.TabIndex = 76
        Me.lblSelected.Text = "Selected"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(201, 260)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(31, 13)
        Me.lblType.TabIndex = 75
        Me.lblType.Text = "Type"
        '
        'lblUpperlimit
        '
        Me.lblUpperlimit.AutoSize = True
        Me.lblUpperlimit.Location = New System.Drawing.Point(201, 179)
        Me.lblUpperlimit.Name = "lblUpperlimit"
        Me.lblUpperlimit.Size = New System.Drawing.Size(60, 13)
        Me.lblUpperlimit.TabIndex = 72
        Me.lblUpperlimit.Text = "Upper Limit"
        '
        'lblScale
        '
        Me.lblScale.AutoSize = True
        Me.lblScale.Location = New System.Drawing.Point(201, 152)
        Me.lblScale.Name = "lblScale"
        Me.lblScale.Size = New System.Drawing.Size(34, 13)
        Me.lblScale.TabIndex = 71
        Me.lblScale.Text = "Scale"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(201, 125)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 70
        Me.lblDescription.Text = "Description"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(201, 98)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 69
        Me.lblName.Text = "Name"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(201, 233)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(26, 13)
        Me.lblUnit.TabIndex = 74
        Me.lblUnit.Text = "Unit"
        '
        'lblLowerLimit
        '
        Me.lblLowerLimit.AutoSize = True
        Me.lblLowerLimit.Location = New System.Drawing.Point(201, 206)
        Me.lblLowerLimit.Name = "lblLowerLimit"
        Me.lblLowerLimit.Size = New System.Drawing.Size(60, 13)
        Me.lblLowerLimit.TabIndex = 73
        Me.lblLowerLimit.Text = "Lower Limit"
        '
        'lblAbbreviation
        '
        Me.lblAbbreviation.AutoSize = True
        Me.lblAbbreviation.Location = New System.Drawing.Point(201, 71)
        Me.lblAbbreviation.Name = "lblAbbreviation"
        Me.lblAbbreviation.Size = New System.Drawing.Size(66, 13)
        Me.lblAbbreviation.TabIndex = 68
        Me.lblAbbreviation.Text = "Abbreviation"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(201, 43)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 65
        Me.lblID.Text = "ID"
        '
        'ucrNavigationElement
        '
        Me.ucrNavigationElement.Location = New System.Drawing.Point(170, 377)
        Me.ucrNavigationElement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationElement.Name = "ucrNavigationElement"
        Me.ucrNavigationElement.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationElement.TabIndex = 95
        '
        'ucrDataLinkID
        '
        Me.ucrDataLinkID.Location = New System.Drawing.Point(298, 41)
        Me.ucrDataLinkID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkID.Name = "ucrDataLinkID"
        Me.ucrDataLinkID.Size = New System.Drawing.Size(178, 21)
        Me.ucrDataLinkID.TabIndex = 17
        Me.ucrDataLinkID.Tag = "elementId"
        '
        'ucrTextBoxAbbreviation
        '
        Me.ucrTextBoxAbbreviation.Location = New System.Drawing.Point(298, 68)
        Me.ucrTextBoxAbbreviation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAbbreviation.Name = "ucrTextBoxAbbreviation"
        Me.ucrTextBoxAbbreviation.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxAbbreviation.TabIndex = 97
        Me.ucrTextBoxAbbreviation.Tag = "abbreviation"
        Me.ucrTextBoxAbbreviation.TextboxValue = ""
        '
        'ucrTextBoxName
        '
        Me.ucrTextBoxName.Location = New System.Drawing.Point(298, 95)
        Me.ucrTextBoxName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxName.Name = "ucrTextBoxName"
        Me.ucrTextBoxName.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxName.TabIndex = 98
        Me.ucrTextBoxName.Tag = "elementName"
        Me.ucrTextBoxName.TextboxValue = ""
        '
        'ucrTextBoxDescription
        '
        Me.ucrTextBoxDescription.Location = New System.Drawing.Point(298, 122)
        Me.ucrTextBoxDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDescription.Name = "ucrTextBoxDescription"
        Me.ucrTextBoxDescription.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxDescription.TabIndex = 99
        Me.ucrTextBoxDescription.Tag = "elementScale"
        Me.ucrTextBoxDescription.TextboxValue = ""
        '
        'ucrTextBoxScale
        '
        Me.ucrTextBoxScale.Location = New System.Drawing.Point(298, 148)
        Me.ucrTextBoxScale.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxScale.Name = "ucrTextBoxScale"
        Me.ucrTextBoxScale.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxScale.TabIndex = 100
        Me.ucrTextBoxScale.Tag = "elementScale"
        Me.ucrTextBoxScale.TextboxValue = ""
        '
        'ucrTextBoxUpperLimit
        '
        Me.ucrTextBoxUpperLimit.Location = New System.Drawing.Point(298, 174)
        Me.ucrTextBoxUpperLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxUpperLimit.Name = "ucrTextBoxUpperLimit"
        Me.ucrTextBoxUpperLimit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxUpperLimit.TabIndex = 101
        Me.ucrTextBoxUpperLimit.Tag = "upperLimit"
        Me.ucrTextBoxUpperLimit.TextboxValue = ""
        '
        'ucrTextBoxLowerLimit
        '
        Me.ucrTextBoxLowerLimit.Location = New System.Drawing.Point(298, 199)
        Me.ucrTextBoxLowerLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLowerLimit.Name = "ucrTextBoxLowerLimit"
        Me.ucrTextBoxLowerLimit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxLowerLimit.TabIndex = 102
        Me.ucrTextBoxLowerLimit.Tag = "lowerLimit"
        Me.ucrTextBoxLowerLimit.TextboxValue = ""
        '
        'ucrTextBoxUnit
        '
        Me.ucrTextBoxUnit.Location = New System.Drawing.Point(298, 226)
        Me.ucrTextBoxUnit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxUnit.Name = "ucrTextBoxUnit"
        Me.ucrTextBoxUnit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxUnit.TabIndex = 103
        Me.ucrTextBoxUnit.Tag = "units"
        Me.ucrTextBoxUnit.TextboxValue = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdViewScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdDeleteScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdUpdateScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdAddScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdClearClass)
        Me.GroupBox13.Location = New System.Drawing.Point(79, 332)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(519, 34)
        Me.GroupBox13.TabIndex = 104
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
        'UcrDataLinkType
        '
        Me.UcrDataLinkType.Location = New System.Drawing.Point(298, 255)
        Me.UcrDataLinkType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrDataLinkType.Name = "UcrDataLinkType"
        Me.UcrDataLinkType.Size = New System.Drawing.Size(178, 21)
        Me.UcrDataLinkType.TabIndex = 105
        Me.UcrDataLinkType.Tag = "elementtype"
        '
        'ucrMetadataElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcrDataLinkType)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrTextBoxUnit)
        Me.Controls.Add(Me.ucrTextBoxLowerLimit)
        Me.Controls.Add(Me.ucrTextBoxUpperLimit)
        Me.Controls.Add(Me.ucrTextBoxScale)
        Me.Controls.Add(Me.ucrTextBoxDescription)
        Me.Controls.Add(Me.ucrTextBoxName)
        Me.Controls.Add(Me.ucrTextBoxAbbreviation)
        Me.Controls.Add(Me.ucrDataLinkID)
        Me.Controls.Add(Me.ucrNavigationElement)
        Me.Controls.Add(Me.chkTotalRequired)
        Me.Controls.Add(Me.lblTotalRequired)
        Me.Controls.Add(Me.chkSelected)
        Me.Controls.Add(Me.lblSelected)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblUpperlimit)
        Me.Controls.Add(Me.lblScale)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.lblLowerLimit)
        Me.Controls.Add(Me.lblAbbreviation)
        Me.Controls.Add(Me.lblID)
        Me.Name = "ucrMetadataElement"
        Me.Size = New System.Drawing.Size(676, 408)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkTotalRequired As CheckBox
    Friend WithEvents lblTotalRequired As Label
    Friend WithEvents chkSelected As CheckBox
    Friend WithEvents lblSelected As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblUpperlimit As Label
    Friend WithEvents lblScale As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblUnit As Label
    Friend WithEvents lblLowerLimit As Label
    Friend WithEvents lblAbbreviation As Label
    Friend WithEvents lblID As Label
    Friend WithEvents ucrNavigationElement As ucrNavigation
    Friend WithEvents ucrDataLinkID As ucrDataLinkCombobox
    Friend WithEvents ucrTextBoxAbbreviation As ucrTextBox
    Friend WithEvents ucrTextBoxName As ucrTextBox
    Friend WithEvents ucrTextBoxDescription As ucrTextBox
    Friend WithEvents ucrTextBoxScale As ucrTextBox
    Friend WithEvents ucrTextBoxUpperLimit As ucrTextBox
    Friend WithEvents ucrTextBoxLowerLimit As ucrTextBox
    Friend WithEvents ucrTextBoxUnit As ucrTextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents cmdViewScheduleClass As Button
    Friend WithEvents cmdDeleteScheduleClass As Button
    Friend WithEvents cmdUpdateScheduleClass As Button
    Friend WithEvents cmdAddScheduleClass As Button
    Friend WithEvents cmdClearClass As Button
    Friend WithEvents UcrDataLinkType As ucrDataLinkCombobox
End Class
