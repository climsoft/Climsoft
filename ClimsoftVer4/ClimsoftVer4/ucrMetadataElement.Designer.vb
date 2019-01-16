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
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblSearchElement = New System.Windows.Forms.Label()
        Me.ucrDataLinkType = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.ucrTextBoxUnit = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxLowerLimit = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxUpperLimit = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxScale = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDescription = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxName = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxAbbreviation = New ClimsoftVer4.ucrTextBox()
        Me.ucrDataLinkElementID = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrNavigationElement = New ClimsoftVer4.ucrNavigation()
        Me.lblTotalRequired = New System.Windows.Forms.Label()
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
        Me.ucrCheckSelected = New ClimsoftVer4.ucrCheck()
        Me.ucrCheckTotalRequired = New ClimsoftVer4.ucrCheck()
        Me.ucrElementSelectorSearch = New ClimsoftVer4.ucrElementSelector()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElement.Location = New System.Drawing.Point(468, 20)
        Me.lblElement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(82, 22)
        Me.lblElement.TabIndex = 26
        Me.lblElement.Text = "Element"
        '
        'lblSearchElement
        '
        Me.lblSearchElement.AutoSize = True
        Me.lblSearchElement.Location = New System.Drawing.Point(578, 74)
        Me.lblSearchElement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchElement.Name = "lblSearchElement"
        Me.lblSearchElement.Size = New System.Drawing.Size(123, 20)
        Me.lblSearchElement.TabIndex = 24
        Me.lblSearchElement.Text = "Search Element"
        '
        'ucrDataLinkType
        '
        Me.ucrDataLinkType.FieldName = "elementtype"
        Me.ucrDataLinkType.Location = New System.Drawing.Point(447, 485)
        Me.ucrDataLinkType.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkType.Name = "ucrDataLinkType"
        Me.ucrDataLinkType.Size = New System.Drawing.Size(267, 32)
        Me.ucrDataLinkType.TabIndex = 17
        Me.ucrDataLinkType.Tag = "elementtype"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(26, 603)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox13.Size = New System.Drawing.Size(872, 52)
        Me.GroupBox13.TabIndex = 22
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(588, 8)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(728, 8)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(112, 35)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(448, 8)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(309, 8)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(112, 35)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(170, 8)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(30, 8)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 35)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrTextBoxUnit
        '
        Me.ucrTextBoxUnit.FieldName = "units"
        Me.ucrTextBoxUnit.Location = New System.Drawing.Point(447, 440)
        Me.ucrTextBoxUnit.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxUnit.Name = "ucrTextBoxUnit"
        Me.ucrTextBoxUnit.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxUnit.TabIndex = 15
        Me.ucrTextBoxUnit.Tag = "units"
        Me.ucrTextBoxUnit.TextboxValue = ""
        '
        'ucrTextBoxLowerLimit
        '
        Me.ucrTextBoxLowerLimit.FieldName = "lowerLimit"
        Me.ucrTextBoxLowerLimit.Location = New System.Drawing.Point(447, 398)
        Me.ucrTextBoxLowerLimit.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxLowerLimit.Name = "ucrTextBoxLowerLimit"
        Me.ucrTextBoxLowerLimit.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxLowerLimit.TabIndex = 13
        Me.ucrTextBoxLowerLimit.Tag = "lowerLimit"
        Me.ucrTextBoxLowerLimit.TextboxValue = ""
        '
        'ucrTextBoxUpperLimit
        '
        Me.ucrTextBoxUpperLimit.FieldName = "upperLimit"
        Me.ucrTextBoxUpperLimit.Location = New System.Drawing.Point(447, 360)
        Me.ucrTextBoxUpperLimit.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxUpperLimit.Name = "ucrTextBoxUpperLimit"
        Me.ucrTextBoxUpperLimit.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxUpperLimit.TabIndex = 11
        Me.ucrTextBoxUpperLimit.Tag = "upperLimit"
        Me.ucrTextBoxUpperLimit.TextboxValue = ""
        '
        'ucrTextBoxScale
        '
        Me.ucrTextBoxScale.FieldName = "elementScale"
        Me.ucrTextBoxScale.Location = New System.Drawing.Point(447, 320)
        Me.ucrTextBoxScale.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxScale.Name = "ucrTextBoxScale"
        Me.ucrTextBoxScale.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxScale.TabIndex = 9
        Me.ucrTextBoxScale.Tag = "elementScale"
        Me.ucrTextBoxScale.TextboxValue = ""
        '
        'ucrTextBoxDescription
        '
        Me.ucrTextBoxDescription.FieldName = "description"
        Me.ucrTextBoxDescription.Location = New System.Drawing.Point(447, 280)
        Me.ucrTextBoxDescription.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxDescription.Name = "ucrTextBoxDescription"
        Me.ucrTextBoxDescription.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxDescription.TabIndex = 7
        Me.ucrTextBoxDescription.Tag = "description"
        Me.ucrTextBoxDescription.TextboxValue = ""
        '
        'ucrTextBoxName
        '
        Me.ucrTextBoxName.FieldName = "elementName"
        Me.ucrTextBoxName.Location = New System.Drawing.Point(447, 238)
        Me.ucrTextBoxName.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxName.Name = "ucrTextBoxName"
        Me.ucrTextBoxName.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxName.TabIndex = 5
        Me.ucrTextBoxName.Tag = "elementName"
        Me.ucrTextBoxName.TextboxValue = ""
        '
        'ucrTextBoxAbbreviation
        '
        Me.ucrTextBoxAbbreviation.FieldName = "abbreviation"
        Me.ucrTextBoxAbbreviation.Location = New System.Drawing.Point(447, 197)
        Me.ucrTextBoxAbbreviation.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextBoxAbbreviation.Name = "ucrTextBoxAbbreviation"
        Me.ucrTextBoxAbbreviation.Size = New System.Drawing.Size(267, 31)
        Me.ucrTextBoxAbbreviation.TabIndex = 3
        Me.ucrTextBoxAbbreviation.Tag = "abbreviation"
        Me.ucrTextBoxAbbreviation.TextboxValue = ""
        '
        'ucrDataLinkElementID
        '
        Me.ucrDataLinkElementID.FieldName = "elementId"
        Me.ucrDataLinkElementID.Location = New System.Drawing.Point(447, 155)
        Me.ucrDataLinkElementID.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkElementID.Name = "ucrDataLinkElementID"
        Me.ucrDataLinkElementID.Size = New System.Drawing.Size(267, 32)
        Me.ucrDataLinkElementID.TabIndex = 1
        Me.ucrDataLinkElementID.Tag = "elementId"
        '
        'ucrNavigationElement
        '
        Me.ucrNavigationElement.Location = New System.Drawing.Point(255, 672)
        Me.ucrNavigationElement.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigationElement.Name = "ucrNavigationElement"
        Me.ucrNavigationElement.Size = New System.Drawing.Size(504, 38)
        Me.ucrNavigationElement.TabIndex = 23
        '
        'lblTotalRequired
        '
        Me.lblTotalRequired.AutoSize = True
        Me.lblTotalRequired.Location = New System.Drawing.Point(303, 567)
        Me.lblTotalRequired.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalRequired.Name = "lblTotalRequired"
        Me.lblTotalRequired.Size = New System.Drawing.Size(113, 20)
        Me.lblTotalRequired.TabIndex = 20
        Me.lblTotalRequired.Text = "Total Required"
        '
        'lblSelected
        '
        Me.lblSelected.AutoSize = True
        Me.lblSelected.Location = New System.Drawing.Point(302, 531)
        Me.lblSelected.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSelected.Name = "lblSelected"
        Me.lblSelected.Size = New System.Drawing.Size(72, 20)
        Me.lblSelected.TabIndex = 18
        Me.lblSelected.Text = "Selected"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(302, 492)
        Me.lblType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(43, 20)
        Me.lblType.TabIndex = 16
        Me.lblType.Text = "Type"
        '
        'lblUpperlimit
        '
        Me.lblUpperlimit.AutoSize = True
        Me.lblUpperlimit.Location = New System.Drawing.Point(302, 368)
        Me.lblUpperlimit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUpperlimit.Name = "lblUpperlimit"
        Me.lblUpperlimit.Size = New System.Drawing.Size(90, 20)
        Me.lblUpperlimit.TabIndex = 10
        Me.lblUpperlimit.Text = "Upper Limit"
        '
        'lblScale
        '
        Me.lblScale.AutoSize = True
        Me.lblScale.Location = New System.Drawing.Point(302, 326)
        Me.lblScale.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScale.Name = "lblScale"
        Me.lblScale.Size = New System.Drawing.Size(49, 20)
        Me.lblScale.TabIndex = 8
        Me.lblScale.Text = "Scale"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(302, 285)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(89, 20)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(302, 243)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(51, 20)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Name"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(302, 451)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(38, 20)
        Me.lblUnit.TabIndex = 14
        Me.lblUnit.Text = "Unit"
        '
        'lblLowerLimit
        '
        Me.lblLowerLimit.AutoSize = True
        Me.lblLowerLimit.Location = New System.Drawing.Point(302, 409)
        Me.lblLowerLimit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLowerLimit.Name = "lblLowerLimit"
        Me.lblLowerLimit.Size = New System.Drawing.Size(89, 20)
        Me.lblLowerLimit.TabIndex = 12
        Me.lblLowerLimit.Text = "Lower Limit"
        '
        'lblAbbreviation
        '
        Me.lblAbbreviation.AutoSize = True
        Me.lblAbbreviation.Location = New System.Drawing.Point(302, 202)
        Me.lblAbbreviation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbbreviation.Name = "lblAbbreviation"
        Me.lblAbbreviation.Size = New System.Drawing.Size(97, 20)
        Me.lblAbbreviation.TabIndex = 2
        Me.lblAbbreviation.Text = "Abbreviation"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(302, 158)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(26, 20)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID"
        '
        'ucrCheckSelected
        '
        Me.ucrCheckSelected.CheckBoxText = ""
        Me.ucrCheckSelected.FieldName = "selected"
        Me.ucrCheckSelected.Location = New System.Drawing.Point(445, 521)
        Me.ucrCheckSelected.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrCheckSelected.Name = "ucrCheckSelected"
        Me.ucrCheckSelected.Size = New System.Drawing.Size(268, 37)
        Me.ucrCheckSelected.TabIndex = 28
        Me.ucrCheckSelected.Tag = "selected"
        '
        'ucrCheckTotalRequired
        '
        Me.ucrCheckTotalRequired.CheckBoxText = ""
        Me.ucrCheckTotalRequired.FieldName = "qcTotalRequired"
        Me.ucrCheckTotalRequired.Location = New System.Drawing.Point(445, 559)
        Me.ucrCheckTotalRequired.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrCheckTotalRequired.Name = "ucrCheckTotalRequired"
        Me.ucrCheckTotalRequired.Size = New System.Drawing.Size(268, 37)
        Me.ucrCheckTotalRequired.TabIndex = 29
        Me.ucrCheckTotalRequired.Tag = "qcTotalRequired"
        '
        'ucrElementSelectorSearch
        '
        Me.ucrElementSelectorSearch.FieldName = Nothing
        Me.ucrElementSelectorSearch.Location = New System.Drawing.Point(711, 63)
        Me.ucrElementSelectorSearch.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrElementSelectorSearch.Name = "ucrElementSelectorSearch"
        Me.ucrElementSelectorSearch.Size = New System.Drawing.Size(267, 32)
        Me.ucrElementSelectorSearch.TabIndex = 30
        '
        'ucrMetadataElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrElementSelectorSearch)
        Me.Controls.Add(Me.ucrCheckTotalRequired)
        Me.Controls.Add(Me.ucrCheckSelected)
        Me.Controls.Add(Me.lblElement)
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
        Me.Controls.Add(Me.ucrDataLinkElementID)
        Me.Controls.Add(Me.ucrNavigationElement)
        Me.Controls.Add(Me.lblTotalRequired)
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
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrMetadataElement"
        Me.Size = New System.Drawing.Size(1014, 740)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTotalRequired As Label
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
    Friend WithEvents ucrDataLinkElementID As ucrDataLinkCombobox
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
    Friend WithEvents lblSearchElement As Label
    Friend WithEvents lblElement As Label
    Friend WithEvents ucrCheckSelected As ucrCheck
    Friend WithEvents ucrCheckTotalRequired As ucrCheck
    Friend WithEvents ucrElementSelectorSearch As ucrElementSelector
End Class
