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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.ucrDataLinkType = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrSearchElementcombobox = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.lblSearchElement = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkTotalRequired
        '
        Me.chkTotalRequired.AutoSize = True
        Me.chkTotalRequired.Location = New System.Drawing.Point(299, 365)
        Me.chkTotalRequired.Name = "chkTotalRequired"
        Me.chkTotalRequired.Size = New System.Drawing.Size(15, 14)
        Me.chkTotalRequired.TabIndex = 21
        Me.chkTotalRequired.Tag = "qcTotalRequired"
        Me.chkTotalRequired.UseVisualStyleBackColor = True
        '
        'lblTotalRequired
        '
        Me.lblTotalRequired.AutoSize = True
        Me.lblTotalRequired.Location = New System.Drawing.Point(202, 366)
        Me.lblTotalRequired.Name = "lblTotalRequired"
        Me.lblTotalRequired.Size = New System.Drawing.Size(77, 13)
        Me.lblTotalRequired.TabIndex = 20
        Me.lblTotalRequired.Text = "Total Required"
        '
        'chkSelected
        '
        Me.chkSelected.AutoSize = True
        Me.chkSelected.Location = New System.Drawing.Point(298, 344)
        Me.chkSelected.Name = "chkSelected"
        Me.chkSelected.Size = New System.Drawing.Size(15, 14)
        Me.chkSelected.TabIndex = 19
        Me.chkSelected.Tag = "selected"
        Me.chkSelected.UseVisualStyleBackColor = True
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(201, 345)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(49, 13)
        Me.lblSelected.TabIndex = 18
        Me.lblSelected.Text = "Selected"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(201, 320)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(31, 13)
        Me.lblType.TabIndex = 16
        Me.lblType.Text = "Type"
        '
        'lblUpperlimit
        '
        Me.lblUpperlimit.AutoSize = True
        Me.lblUpperlimit.Location = New System.Drawing.Point(201, 239)
        Me.lblUpperlimit.Name = "lblUpperlimit"
        Me.lblUpperlimit.Size = New System.Drawing.Size(60, 13)
        Me.lblUpperlimit.TabIndex = 10
        Me.lblUpperlimit.Text = "Upper Limit"
        '
        'lblScale
        '
        Me.lblScale.AutoSize = True
        Me.lblScale.Location = New System.Drawing.Point(201, 212)
        Me.lblScale.Name = "lblScale"
        Me.lblScale.Size = New System.Drawing.Size(34, 13)
        Me.lblScale.TabIndex = 8
        Me.lblScale.Text = "Scale"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(201, 185)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(201, 158)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Name"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(201, 293)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(26, 13)
        Me.lblUnit.TabIndex = 14
        Me.lblUnit.Text = "Unit"
        '
        'lblLowerLimit
        '
        Me.lblLowerLimit.AutoSize = True
        Me.lblLowerLimit.Location = New System.Drawing.Point(201, 266)
        Me.lblLowerLimit.Name = "lblLowerLimit"
        Me.lblLowerLimit.Size = New System.Drawing.Size(60, 13)
        Me.lblLowerLimit.TabIndex = 12
        Me.lblLowerLimit.Text = "Lower Limit"
        '
        'lblAbbreviation
        '
        Me.lblAbbreviation.AutoSize = True
        Me.lblAbbreviation.Location = New System.Drawing.Point(201, 131)
        Me.lblAbbreviation.Name = "lblAbbreviation"
        Me.lblAbbreviation.Size = New System.Drawing.Size(66, 13)
        Me.lblAbbreviation.TabIndex = 2
        Me.lblAbbreviation.Text = "Abbreviation"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(201, 103)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(18, 13)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID"
        '
        'ucrNavigationElement
        '
        Me.ucrNavigationElement.Location = New System.Drawing.Point(170, 437)
        Me.ucrNavigationElement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationElement.Name = "ucrNavigationElement"
        Me.ucrNavigationElement.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationElement.TabIndex = 23
        '
        'ucrDataLinkID
        '
        Me.ucrDataLinkID.FieldName = "elementId"
        Me.ucrDataLinkID.Location = New System.Drawing.Point(298, 101)
        Me.ucrDataLinkID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkID.Name = "ucrDataLinkID"
        Me.ucrDataLinkID.Size = New System.Drawing.Size(178, 21)
        Me.ucrDataLinkID.TabIndex = 1
        Me.ucrDataLinkID.Tag = "elementId"
        '
        'ucrTextBoxAbbreviation
        '
        Me.ucrTextBoxAbbreviation.FieldName = "abbreviation"
        Me.ucrTextBoxAbbreviation.Location = New System.Drawing.Point(298, 128)
        Me.ucrTextBoxAbbreviation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxAbbreviation.Name = "ucrTextBoxAbbreviation"
        Me.ucrTextBoxAbbreviation.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxAbbreviation.TabIndex = 3
        Me.ucrTextBoxAbbreviation.Tag = "abbreviation"
        Me.ucrTextBoxAbbreviation.TextboxValue = ""
        '
        'ucrTextBoxName
        '
        Me.ucrTextBoxName.FieldName = "elementName"
        Me.ucrTextBoxName.Location = New System.Drawing.Point(298, 155)
        Me.ucrTextBoxName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxName.Name = "ucrTextBoxName"
        Me.ucrTextBoxName.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxName.TabIndex = 5
        Me.ucrTextBoxName.Tag = "elementName"
        Me.ucrTextBoxName.TextboxValue = ""
        '
        'ucrTextBoxDescription
        '
        Me.ucrTextBoxDescription.FieldName = "description"
        Me.ucrTextBoxDescription.Location = New System.Drawing.Point(298, 182)
        Me.ucrTextBoxDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDescription.Name = "ucrTextBoxDescription"
        Me.ucrTextBoxDescription.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxDescription.TabIndex = 7
        Me.ucrTextBoxDescription.Tag = "description"
        Me.ucrTextBoxDescription.TextboxValue = ""
        '
        'ucrTextBoxScale
        '
        Me.ucrTextBoxScale.FieldName = "elementScale"
        Me.ucrTextBoxScale.Location = New System.Drawing.Point(298, 208)
        Me.ucrTextBoxScale.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxScale.Name = "ucrTextBoxScale"
        Me.ucrTextBoxScale.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxScale.TabIndex = 9
        Me.ucrTextBoxScale.Tag = "elementScale"
        Me.ucrTextBoxScale.TextboxValue = ""
        '
        'ucrTextBoxUpperLimit
        '
        Me.ucrTextBoxUpperLimit.FieldName = "upperLimit"
        Me.ucrTextBoxUpperLimit.Location = New System.Drawing.Point(298, 234)
        Me.ucrTextBoxUpperLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxUpperLimit.Name = "ucrTextBoxUpperLimit"
        Me.ucrTextBoxUpperLimit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxUpperLimit.TabIndex = 11
        Me.ucrTextBoxUpperLimit.Tag = "upperLimit"
        Me.ucrTextBoxUpperLimit.TextboxValue = ""
        '
        'ucrTextBoxLowerLimit
        '
        Me.ucrTextBoxLowerLimit.FieldName = "lowerLimit"
        Me.ucrTextBoxLowerLimit.Location = New System.Drawing.Point(298, 259)
        Me.ucrTextBoxLowerLimit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxLowerLimit.Name = "ucrTextBoxLowerLimit"
        Me.ucrTextBoxLowerLimit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxLowerLimit.TabIndex = 13
        Me.ucrTextBoxLowerLimit.Tag = "lowerLimit"
        Me.ucrTextBoxLowerLimit.TextboxValue = ""
        '
        'ucrTextBoxUnit
        '
        Me.ucrTextBoxUnit.FieldName = "units"
        Me.ucrTextBoxUnit.Location = New System.Drawing.Point(298, 286)
        Me.ucrTextBoxUnit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxUnit.Name = "ucrTextBoxUnit"
        Me.ucrTextBoxUnit.Size = New System.Drawing.Size(178, 20)
        Me.ucrTextBoxUnit.TabIndex = 15
        Me.ucrTextBoxUnit.Tag = "units"
        Me.ucrTextBoxUnit.TextboxValue = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(17, 392)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(581, 34)
        Me.GroupBox13.TabIndex = 22
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(392, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(485, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(299, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(206, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(113, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(20, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrDataLinkType
        '
        Me.ucrDataLinkType.FieldName = "elementtype"
        Me.ucrDataLinkType.Location = New System.Drawing.Point(298, 315)
        Me.ucrDataLinkType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkType.Name = "ucrDataLinkType"
        Me.ucrDataLinkType.Size = New System.Drawing.Size(178, 21)
        Me.ucrDataLinkType.TabIndex = 17
        Me.ucrDataLinkType.Tag = "elementtype"
        '
        'ucrSearchElementcombobox
        '
        Me.ucrSearchElementcombobox.FieldName = Nothing
        Me.ucrSearchElementcombobox.Location = New System.Drawing.Point(483, 46)
        Me.ucrSearchElementcombobox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrSearchElementcombobox.Name = "ucrSearchElementcombobox"
        Me.ucrSearchElementcombobox.Size = New System.Drawing.Size(178, 21)
        Me.ucrSearchElementcombobox.TabIndex = 25
        '
        'lblSearchElement
        '
        Me.lblSearchElement.AutoSize = True
        Me.lblSearchElement.Location = New System.Drawing.Point(385, 48)
        Me.lblSearchElement.Name = "lblSearchElement"
        Me.lblSearchElement.Size = New System.Drawing.Size(82, 13)
        Me.lblSearchElement.TabIndex = 24
        Me.lblSearchElement.Text = "Search Element"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElement.Location = New System.Drawing.Point(312, 13)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(60, 15)
        Me.lblElement.TabIndex = 26
        Me.lblElement.Text = "Element"
        '
        'ucrMetadataElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.ucrSearchElementcombobox)
        Me.Controls.Add(Me.lblSearchElement)
        Me.Controls.Add(Me.ucrDataLinkType)
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
        Me.Size = New System.Drawing.Size(676, 481)
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
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents ucrDataLinkType As ucrDataLinkCombobox
    Friend WithEvents btnClear As Button
    Friend WithEvents ucrSearchElementcombobox As ucrDataLinkCombobox
    Friend WithEvents lblSearchElement As Label
    Friend WithEvents lblElement As Label
End Class
