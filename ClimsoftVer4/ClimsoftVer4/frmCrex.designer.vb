<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrex
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkIncludeCheckDigit = New System.Windows.Forms.CheckBox()
        Me.cboTemplate = New System.Windows.Forms.ComboBox()
        Me.cboBBB = New System.Windows.Forms.ComboBox()
        Me.txtMinute = New System.Windows.Forms.TextBox()
        Me.txtHour = New System.Windows.Forms.TextBox()
        Me.txtDay = New System.Windows.Forms.TextBox()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblMinute = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblTemplate = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblBBB = New System.Windows.Forms.Label()
        Me.lblIncludeCheckDigit = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.grpIndicators = New System.Windows.Forms.GroupBox()
        Me.lblNumberSequence = New System.Windows.Forms.Label()
        Me.txtSequenceNumber = New System.Windows.Forms.TextBox()
        Me.lblOriginatingGeneratingSubCenter = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingsubCenter = New System.Windows.Forms.TextBox()
        Me.lblOriginatingGeneratingCenter = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingCenter = New System.Windows.Forms.TextBox()
        Me.lblDataCategorySubCategory = New System.Windows.Forms.Label()
        Me.txtDataCategorySubCategory = New System.Windows.Forms.TextBox()
        Me.lblDataCategory = New System.Windows.Forms.Label()
        Me.txtDataCategory = New System.Windows.Forms.TextBox()
        Me.lblLocalTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtLocalTableversionNumber = New System.Windows.Forms.TextBox()
        Me.lblBUFRMasterTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtBUFRMasterTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblCrexTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtCREXTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblCrexEditionsNumber = New System.Windows.Forms.Label()
        Me.txtCREXEditionsNumber = New System.Windows.Forms.TextBox()
        Me.txtNumberOfSubsets = New System.Windows.Forms.TextBox()
        Me.lblNumberOfSubsets = New System.Windows.Forms.Label()
        Me.grpSensorsHeightFromGround = New System.Windows.Forms.GroupBox()
        Me.lblSensorsheightFromGroundWind = New System.Windows.Forms.Label()
        Me.lblPrecipitation = New System.Windows.Forms.Label()
        Me.txtWind = New System.Windows.Forms.TextBox()
        Me.txtPrecipitation = New System.Windows.Forms.TextBox()
        Me.lblVisibility = New System.Windows.Forms.Label()
        Me.txtVisibility = New System.Windows.Forms.TextBox()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.lblPressure = New System.Windows.Forms.Label()
        Me.txtPressure = New System.Windows.Forms.TextBox()
        Me.grpInstrumentTypes = New System.Windows.Forms.GroupBox()
        Me.lblInstrumentTypesWind = New System.Windows.Forms.Label()
        Me.txtInstrumentTypesWind = New System.Windows.Forms.TextBox()
        Me.lblEvaporation = New System.Windows.Forms.Label()
        Me.txtEvaporation = New System.Windows.Forms.TextBox()
        Me.lblCodedOutput = New System.Windows.Forms.Label()
        Me.grpCharacterMessage = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.grpMailApplications = New System.Windows.Forms.GroupBox()
        Me.btnSendMail = New System.Windows.Forms.Button()
        Me.lstMailApplications = New System.Windows.Forms.ListBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblMailApplications = New System.Windows.Forms.Label()
        Me.chkAttachUncodedData = New System.Windows.Forms.CheckBox()
        Me.grpSendingOptions = New System.Windows.Forms.GroupBox()
        Me.lblFTP = New System.Windows.Forms.Label()
        Me.rbFTP = New System.Windows.Forms.RadioButton()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.rbEmail = New System.Windows.Forms.RadioButton()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.txtCharacterMessage = New System.Windows.Forms.TextBox()
        Me.btnEncode = New System.Windows.Forms.Button()
        Me.btnViewImportExport = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grpIndicators.SuspendLayout()
        Me.grpSensorsHeightFromGround.SuspendLayout()
        Me.grpInstrumentTypes.SuspendLayout()
        Me.grpCharacterMessage.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.grpMailApplications.SuspendLayout()
        Me.grpSendingOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkIncludeCheckDigit)
        Me.GroupBox1.Controls.Add(Me.cboTemplate)
        Me.GroupBox1.Controls.Add(Me.cboBBB)
        Me.GroupBox1.Controls.Add(Me.txtMinute)
        Me.GroupBox1.Controls.Add(Me.txtHour)
        Me.GroupBox1.Controls.Add(Me.txtDay)
        Me.GroupBox1.Controls.Add(Me.txtMonth)
        Me.GroupBox1.Controls.Add(Me.txtHeader)
        Me.GroupBox1.Controls.Add(Me.txtYear)
        Me.GroupBox1.Controls.Add(Me.lblHour)
        Me.GroupBox1.Controls.Add(Me.lblMinute)
        Me.GroupBox1.Controls.Add(Me.lblDay)
        Me.GroupBox1.Controls.Add(Me.lblTemplate)
        Me.GroupBox1.Controls.Add(Me.lblMonth)
        Me.GroupBox1.Controls.Add(Me.lblBBB)
        Me.GroupBox1.Controls.Add(Me.lblIncludeCheckDigit)
        Me.GroupBox1.Controls.Add(Me.lblHeader)
        Me.GroupBox1.Controls.Add(Me.lblYear)
        Me.GroupBox1.Controls.Add(Me.lblStation)
        Me.GroupBox1.Controls.Add(Me.cboStation)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(629, 141)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkIncludeCheckDigit
        '
        Me.chkIncludeCheckDigit.AutoSize = True
        Me.chkIncludeCheckDigit.Location = New System.Drawing.Point(315, 110)
        Me.chkIncludeCheckDigit.Name = "chkIncludeCheckDigit"
        Me.chkIncludeCheckDigit.Size = New System.Drawing.Size(15, 14)
        Me.chkIncludeCheckDigit.TabIndex = 4
        Me.chkIncludeCheckDigit.UseVisualStyleBackColor = True
        '
        'cboTemplate
        '
        Me.cboTemplate.FormattingEnabled = True
        Me.cboTemplate.Location = New System.Drawing.Point(485, 110)
        Me.cboTemplate.Name = "cboTemplate"
        Me.cboTemplate.Size = New System.Drawing.Size(121, 21)
        Me.cboTemplate.TabIndex = 3
        '
        'cboBBB
        '
        Me.cboBBB.FormattingEnabled = True
        Me.cboBBB.Location = New System.Drawing.Point(105, 110)
        Me.cboBBB.Name = "cboBBB"
        Me.cboBBB.Size = New System.Drawing.Size(121, 21)
        Me.cboBBB.TabIndex = 3
        '
        'txtMinute
        '
        Me.txtMinute.Location = New System.Drawing.Point(315, 69)
        Me.txtMinute.Name = "txtMinute"
        Me.txtMinute.Size = New System.Drawing.Size(60, 20)
        Me.txtMinute.TabIndex = 2
        '
        'txtHour
        '
        Me.txtHour.Location = New System.Drawing.Point(240, 69)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(60, 20)
        Me.txtHour.TabIndex = 2
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(174, 69)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(60, 20)
        Me.txtDay.TabIndex = 2
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(103, 69)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(60, 20)
        Me.txtMonth.TabIndex = 2
        '
        'txtHeader
        '
        Me.txtHeader.Location = New System.Drawing.Point(27, 110)
        Me.txtHeader.Name = "txtHeader"
        Me.txtHeader.Size = New System.Drawing.Size(60, 20)
        Me.txtHeader.TabIndex = 2
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(27, 69)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(60, 20)
        Me.txtYear.TabIndex = 2
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(267, 53)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(33, 13)
        Me.lblHour.TabIndex = 1
        Me.lblHour.Tag = "Hour"
        Me.lblHour.Text = "Hour "
        '
        'lblMinute
        '
        Me.lblMinute.AutoSize = True
        Me.lblMinute.Location = New System.Drawing.Point(336, 53)
        Me.lblMinute.Name = "lblMinute"
        Me.lblMinute.Size = New System.Drawing.Size(39, 13)
        Me.lblMinute.TabIndex = 1
        Me.lblMinute.Tag = "Minute"
        Me.lblMinute.Text = "Minute"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(208, 52)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(26, 13)
        Me.lblDay.TabIndex = 1
        Me.lblDay.Tag = "Day"
        Me.lblDay.Text = "Day"
        '
        'lblTemplate
        '
        Me.lblTemplate.AutoSize = True
        Me.lblTemplate.Location = New System.Drawing.Point(482, 93)
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Size = New System.Drawing.Size(51, 13)
        Me.lblTemplate.TabIndex = 1
        Me.lblTemplate.Tag = "Template"
        Me.lblTemplate.Text = "Template"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(126, 53)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 1
        Me.lblMonth.Tag = "Month"
        Me.lblMonth.Text = "Month"
        '
        'lblBBB
        '
        Me.lblBBB.AutoSize = True
        Me.lblBBB.Location = New System.Drawing.Point(105, 96)
        Me.lblBBB.Name = "lblBBB"
        Me.lblBBB.Size = New System.Drawing.Size(28, 13)
        Me.lblBBB.TabIndex = 1
        Me.lblBBB.Tag = "BBB"
        Me.lblBBB.Text = "BBB"
        '
        'lblIncludeCheckDigit
        '
        Me.lblIncludeCheckDigit.AutoSize = True
        Me.lblIncludeCheckDigit.Location = New System.Drawing.Point(336, 105)
        Me.lblIncludeCheckDigit.Name = "lblIncludeCheckDigit"
        Me.lblIncludeCheckDigit.Size = New System.Drawing.Size(100, 13)
        Me.lblIncludeCheckDigit.TabIndex = 1
        Me.lblIncludeCheckDigit.Tag = "Include_Check_Digit"
        Me.lblIncludeCheckDigit.Text = "Include Check Digit"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Location = New System.Drawing.Point(24, 94)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(45, 13)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Tag = "Header"
        Me.lblHeader.Text = "Header "
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(58, 53)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 1
        Me.lblYear.Tag = "Year"
        Me.lblYear.Text = "Year"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(219, 9)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Tag = "Station"
        Me.lblStation.Text = "Station"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Location = New System.Drawing.Point(68, 28)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(403, 21)
        Me.cboStation.TabIndex = 0
        '
        'grpIndicators
        '
        Me.grpIndicators.Controls.Add(Me.lblNumberSequence)
        Me.grpIndicators.Controls.Add(Me.txtSequenceNumber)
        Me.grpIndicators.Controls.Add(Me.lblOriginatingGeneratingSubCenter)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingsubCenter)
        Me.grpIndicators.Controls.Add(Me.lblOriginatingGeneratingCenter)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingCenter)
        Me.grpIndicators.Controls.Add(Me.lblDataCategorySubCategory)
        Me.grpIndicators.Controls.Add(Me.txtDataCategorySubCategory)
        Me.grpIndicators.Controls.Add(Me.lblDataCategory)
        Me.grpIndicators.Controls.Add(Me.txtDataCategory)
        Me.grpIndicators.Controls.Add(Me.lblLocalTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtLocalTableversionNumber)
        Me.grpIndicators.Controls.Add(Me.lblBUFRMasterTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtBUFRMasterTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.lblCrexTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtCREXTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.lblCrexEditionsNumber)
        Me.grpIndicators.Controls.Add(Me.txtCREXEditionsNumber)
        Me.grpIndicators.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpIndicators.Location = New System.Drawing.Point(29, 147)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Size = New System.Drawing.Size(229, 258)
        Me.grpIndicators.TabIndex = 1
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Text = "Indicators "
        '
        'lblNumberSequence
        '
        Me.lblNumberSequence.AutoSize = True
        Me.lblNumberSequence.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumberSequence.Location = New System.Drawing.Point(1, 206)
        Me.lblNumberSequence.Name = "lblNumberSequence"
        Me.lblNumberSequence.Size = New System.Drawing.Size(96, 13)
        Me.lblNumberSequence.TabIndex = 1
        Me.lblNumberSequence.Tag = "Number_Sequence"
        Me.lblNumberSequence.Text = "Sequence Number"
        '
        'txtSequenceNumber
        '
        Me.txtSequenceNumber.Location = New System.Drawing.Point(184, 200)
        Me.txtSequenceNumber.Name = "txtSequenceNumber"
        Me.txtSequenceNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtSequenceNumber.TabIndex = 2
        '
        'lblOriginatingGeneratingSubCenter
        '
        Me.lblOriginatingGeneratingSubCenter.AutoSize = True
        Me.lblOriginatingGeneratingSubCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingGeneratingSubCenter.Location = New System.Drawing.Point(1, 184)
        Me.lblOriginatingGeneratingSubCenter.Name = "lblOriginatingGeneratingSubCenter"
        Me.lblOriginatingGeneratingSubCenter.Size = New System.Drawing.Size(170, 13)
        Me.lblOriginatingGeneratingSubCenter.TabIndex = 1
        Me.lblOriginatingGeneratingSubCenter.Tag = "Originating_Generating_Sub_Center"
        Me.lblOriginatingGeneratingSubCenter.Text = "Originating/Generating Sub Center"
        '
        'txtOriginatingGeneratingsubCenter
        '
        Me.txtOriginatingGeneratingsubCenter.Location = New System.Drawing.Point(184, 178)
        Me.txtOriginatingGeneratingsubCenter.Name = "txtOriginatingGeneratingsubCenter"
        Me.txtOriginatingGeneratingsubCenter.Size = New System.Drawing.Size(39, 20)
        Me.txtOriginatingGeneratingsubCenter.TabIndex = 2
        '
        'lblOriginatingGeneratingCenter
        '
        Me.lblOriginatingGeneratingCenter.AutoSize = True
        Me.lblOriginatingGeneratingCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingGeneratingCenter.Location = New System.Drawing.Point(1, 161)
        Me.lblOriginatingGeneratingCenter.Name = "lblOriginatingGeneratingCenter"
        Me.lblOriginatingGeneratingCenter.Size = New System.Drawing.Size(148, 13)
        Me.lblOriginatingGeneratingCenter.TabIndex = 1
        Me.lblOriginatingGeneratingCenter.Tag = "Originating_Generating_Center"
        Me.lblOriginatingGeneratingCenter.Text = "Originating/Generating Center"
        '
        'txtOriginatingGeneratingCenter
        '
        Me.txtOriginatingGeneratingCenter.Location = New System.Drawing.Point(184, 156)
        Me.txtOriginatingGeneratingCenter.Name = "txtOriginatingGeneratingCenter"
        Me.txtOriginatingGeneratingCenter.Size = New System.Drawing.Size(39, 20)
        Me.txtOriginatingGeneratingCenter.TabIndex = 2
        '
        'lblDataCategorySubCategory
        '
        Me.lblDataCategorySubCategory.AutoSize = True
        Me.lblDataCategorySubCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCategorySubCategory.Location = New System.Drawing.Point(1, 137)
        Me.lblDataCategorySubCategory.Name = "lblDataCategorySubCategory"
        Me.lblDataCategorySubCategory.Size = New System.Drawing.Size(140, 13)
        Me.lblDataCategorySubCategory.TabIndex = 1
        Me.lblDataCategorySubCategory.Tag = "Data_Category_Sub_Category"
        Me.lblDataCategorySubCategory.Text = "Data Category sub-Category"
        '
        'txtDataCategorySubCategory
        '
        Me.txtDataCategorySubCategory.Location = New System.Drawing.Point(184, 133)
        Me.txtDataCategorySubCategory.Name = "txtDataCategorySubCategory"
        Me.txtDataCategorySubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtDataCategorySubCategory.TabIndex = 2
        '
        'lblDataCategory
        '
        Me.lblDataCategory.AutoSize = True
        Me.lblDataCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCategory.Location = New System.Drawing.Point(1, 113)
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Size = New System.Drawing.Size(75, 13)
        Me.lblDataCategory.TabIndex = 1
        Me.lblDataCategory.Tag = "Data_Category"
        Me.lblDataCategory.Text = "Data Category"
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(184, 111)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtDataCategory.TabIndex = 2
        '
        'lblLocalTableVersionNumber
        '
        Me.lblLocalTableVersionNumber.AutoSize = True
        Me.lblLocalTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalTableVersionNumber.Location = New System.Drawing.Point(1, 90)
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Size = New System.Drawing.Size(137, 13)
        Me.lblLocalTableVersionNumber.TabIndex = 1
        Me.lblLocalTableVersionNumber.Tag = "Local_Table_Version_Number"
        Me.lblLocalTableVersionNumber.Text = "Local table Version Number"
        '
        'txtLocalTableversionNumber
        '
        Me.txtLocalTableversionNumber.Location = New System.Drawing.Point(184, 88)
        Me.txtLocalTableversionNumber.Name = "txtLocalTableversionNumber"
        Me.txtLocalTableversionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalTableversionNumber.TabIndex = 2
        '
        'lblBUFRMasterTableVersionNumber
        '
        Me.lblBUFRMasterTableVersionNumber.AutoSize = True
        Me.lblBUFRMasterTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBUFRMasterTableVersionNumber.Location = New System.Drawing.Point(1, 69)
        Me.lblBUFRMasterTableVersionNumber.Name = "lblBUFRMasterTableVersionNumber"
        Me.lblBUFRMasterTableVersionNumber.Size = New System.Drawing.Size(179, 13)
        Me.lblBUFRMasterTableVersionNumber.TabIndex = 1
        Me.lblBUFRMasterTableVersionNumber.Tag = "BUFR_Master_Table_Version_Number"
        Me.lblBUFRMasterTableVersionNumber.Text = "BUFR Master Table Version Number"
        '
        'txtBUFRMasterTableVersionNumber
        '
        Me.txtBUFRMasterTableVersionNumber.Location = New System.Drawing.Point(184, 65)
        Me.txtBUFRMasterTableVersionNumber.Name = "txtBUFRMasterTableVersionNumber"
        Me.txtBUFRMasterTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtBUFRMasterTableVersionNumber.TabIndex = 2
        Me.txtBUFRMasterTableVersionNumber.Tag = ""
        '
        'lblCrexTableVersionNumber
        '
        Me.lblCrexTableVersionNumber.AutoSize = True
        Me.lblCrexTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrexTableVersionNumber.Location = New System.Drawing.Point(1, 47)
        Me.lblCrexTableVersionNumber.Name = "lblCrexTableVersionNumber"
        Me.lblCrexTableVersionNumber.Size = New System.Drawing.Size(144, 13)
        Me.lblCrexTableVersionNumber.TabIndex = 1
        Me.lblCrexTableVersionNumber.Tag = "Crex_Table_Version_Number"
        Me.lblCrexTableVersionNumber.Text = "CREX Table Version Number"
        '
        'txtCREXTableVersionNumber
        '
        Me.txtCREXTableVersionNumber.Location = New System.Drawing.Point(184, 43)
        Me.txtCREXTableVersionNumber.Name = "txtCREXTableVersionNumber"
        Me.txtCREXTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtCREXTableVersionNumber.TabIndex = 2
        '
        'lblCrexEditionsNumber
        '
        Me.lblCrexEditionsNumber.AutoSize = True
        Me.lblCrexEditionsNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrexEditionsNumber.Location = New System.Drawing.Point(1, 26)
        Me.lblCrexEditionsNumber.Name = "lblCrexEditionsNumber"
        Me.lblCrexEditionsNumber.Size = New System.Drawing.Size(116, 13)
        Me.lblCrexEditionsNumber.TabIndex = 1
        Me.lblCrexEditionsNumber.Tag = "CREX_Editions_Number"
        Me.lblCrexEditionsNumber.Text = "CREX Editions Number"
        '
        'txtCREXEditionsNumber
        '
        Me.txtCREXEditionsNumber.Location = New System.Drawing.Point(184, 21)
        Me.txtCREXEditionsNumber.Name = "txtCREXEditionsNumber"
        Me.txtCREXEditionsNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtCREXEditionsNumber.TabIndex = 2
        '
        'txtNumberOfSubsets
        '
        Me.txtNumberOfSubsets.Location = New System.Drawing.Point(213, 369)
        Me.txtNumberOfSubsets.Name = "txtNumberOfSubsets"
        Me.txtNumberOfSubsets.Size = New System.Drawing.Size(39, 20)
        Me.txtNumberOfSubsets.TabIndex = 2
        '
        'lblNumberOfSubsets
        '
        Me.lblNumberOfSubsets.AutoSize = True
        Me.lblNumberOfSubsets.Location = New System.Drawing.Point(31, 373)
        Me.lblNumberOfSubsets.Name = "lblNumberOfSubsets"
        Me.lblNumberOfSubsets.Size = New System.Drawing.Size(97, 13)
        Me.lblNumberOfSubsets.TabIndex = 1
        Me.lblNumberOfSubsets.Tag = "Number_Of_Subsets"
        Me.lblNumberOfSubsets.Text = "Number of Subsets"
        '
        'grpSensorsHeightFromGround
        '
        Me.grpSensorsHeightFromGround.Controls.Add(Me.lblSensorsheightFromGroundWind)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.lblPrecipitation)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.txtWind)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.txtPrecipitation)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.lblVisibility)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.txtVisibility)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.lblTemperature)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.txtTemperature)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.lblPressure)
        Me.grpSensorsHeightFromGround.Controls.Add(Me.txtPressure)
        Me.grpSensorsHeightFromGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSensorsHeightFromGround.Location = New System.Drawing.Point(276, 147)
        Me.grpSensorsHeightFromGround.Name = "grpSensorsHeightFromGround"
        Me.grpSensorsHeightFromGround.Size = New System.Drawing.Size(201, 165)
        Me.grpSensorsHeightFromGround.TabIndex = 1
        Me.grpSensorsHeightFromGround.TabStop = False
        Me.grpSensorsHeightFromGround.Tag = "Sensors_Height_From_Ground"
        Me.grpSensorsHeightFromGround.Text = "Sensors Height From Ground(M)"
        '
        'lblSensorsheightFromGroundWind
        '
        Me.lblSensorsheightFromGroundWind.AutoSize = True
        Me.lblSensorsheightFromGroundWind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSensorsheightFromGroundWind.Location = New System.Drawing.Point(5, 113)
        Me.lblSensorsheightFromGroundWind.Name = "lblSensorsheightFromGroundWind"
        Me.lblSensorsheightFromGroundWind.Size = New System.Drawing.Size(32, 13)
        Me.lblSensorsheightFromGroundWind.TabIndex = 1
        Me.lblSensorsheightFromGroundWind.Tag = "Wind"
        Me.lblSensorsheightFromGroundWind.Text = "Wind"
        '
        'lblPrecipitation
        '
        Me.lblPrecipitation.AutoSize = True
        Me.lblPrecipitation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecipitation.Location = New System.Drawing.Point(3, 90)
        Me.lblPrecipitation.Name = "lblPrecipitation"
        Me.lblPrecipitation.Size = New System.Drawing.Size(69, 13)
        Me.lblPrecipitation.TabIndex = 1
        Me.lblPrecipitation.Tag = "Precipitation"
        Me.lblPrecipitation.Text = "Precipatation"
        '
        'txtWind
        '
        Me.txtWind.Location = New System.Drawing.Point(122, 111)
        Me.txtWind.Name = "txtWind"
        Me.txtWind.Size = New System.Drawing.Size(39, 20)
        Me.txtWind.TabIndex = 2
        '
        'txtPrecipitation
        '
        Me.txtPrecipitation.Location = New System.Drawing.Point(122, 88)
        Me.txtPrecipitation.Name = "txtPrecipitation"
        Me.txtPrecipitation.Size = New System.Drawing.Size(39, 20)
        Me.txtPrecipitation.TabIndex = 2
        '
        'lblVisibility
        '
        Me.lblVisibility.AutoSize = True
        Me.lblVisibility.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisibility.Location = New System.Drawing.Point(3, 69)
        Me.lblVisibility.Name = "lblVisibility"
        Me.lblVisibility.Size = New System.Drawing.Size(43, 13)
        Me.lblVisibility.TabIndex = 1
        Me.lblVisibility.Tag = "Visibility"
        Me.lblVisibility.Text = "Visibility"
        '
        'txtVisibility
        '
        Me.txtVisibility.Location = New System.Drawing.Point(122, 65)
        Me.txtVisibility.Name = "txtVisibility"
        Me.txtVisibility.Size = New System.Drawing.Size(39, 20)
        Me.txtVisibility.TabIndex = 2
        '
        'lblTemperature
        '
        Me.lblTemperature.AutoSize = True
        Me.lblTemperature.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperature.Location = New System.Drawing.Point(1, 47)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(67, 13)
        Me.lblTemperature.TabIndex = 1
        Me.lblTemperature.Tag = "Temperature"
        Me.lblTemperature.Text = "Temperature"
        '
        'txtTemperature
        '
        Me.txtTemperature.Location = New System.Drawing.Point(122, 43)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(39, 20)
        Me.txtTemperature.TabIndex = 2
        '
        'lblPressure
        '
        Me.lblPressure.AutoSize = True
        Me.lblPressure.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressure.Location = New System.Drawing.Point(2, 26)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Size = New System.Drawing.Size(51, 13)
        Me.lblPressure.TabIndex = 1
        Me.lblPressure.Tag = "Pressure"
        Me.lblPressure.Text = "Pressure "
        '
        'txtPressure
        '
        Me.txtPressure.Location = New System.Drawing.Point(122, 21)
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.Size = New System.Drawing.Size(39, 20)
        Me.txtPressure.TabIndex = 2
        '
        'grpInstrumentTypes
        '
        Me.grpInstrumentTypes.Controls.Add(Me.lblInstrumentTypesWind)
        Me.grpInstrumentTypes.Controls.Add(Me.txtInstrumentTypesWind)
        Me.grpInstrumentTypes.Controls.Add(Me.lblEvaporation)
        Me.grpInstrumentTypes.Controls.Add(Me.txtEvaporation)
        Me.grpInstrumentTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInstrumentTypes.Location = New System.Drawing.Point(493, 147)
        Me.grpInstrumentTypes.Name = "grpInstrumentTypes"
        Me.grpInstrumentTypes.Size = New System.Drawing.Size(165, 165)
        Me.grpInstrumentTypes.TabIndex = 1
        Me.grpInstrumentTypes.TabStop = False
        Me.grpInstrumentTypes.Tag = "Instrument_Types"
        Me.grpInstrumentTypes.Text = "Instrument Types"
        '
        'lblInstrumentTypesWind
        '
        Me.lblInstrumentTypesWind.AutoSize = True
        Me.lblInstrumentTypesWind.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstrumentTypesWind.Location = New System.Drawing.Point(5, 47)
        Me.lblInstrumentTypesWind.Name = "lblInstrumentTypesWind"
        Me.lblInstrumentTypesWind.Size = New System.Drawing.Size(32, 13)
        Me.lblInstrumentTypesWind.TabIndex = 1
        Me.lblInstrumentTypesWind.Tag = "Wind"
        Me.lblInstrumentTypesWind.Text = "Wind"
        '
        'txtInstrumentTypesWind
        '
        Me.txtInstrumentTypesWind.Location = New System.Drawing.Point(102, 49)
        Me.txtInstrumentTypesWind.Name = "txtInstrumentTypesWind"
        Me.txtInstrumentTypesWind.Size = New System.Drawing.Size(39, 20)
        Me.txtInstrumentTypesWind.TabIndex = 2
        '
        'lblEvaporation
        '
        Me.lblEvaporation.AutoSize = True
        Me.lblEvaporation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaporation.Location = New System.Drawing.Point(5, 26)
        Me.lblEvaporation.Name = "lblEvaporation"
        Me.lblEvaporation.Size = New System.Drawing.Size(67, 13)
        Me.lblEvaporation.TabIndex = 1
        Me.lblEvaporation.Tag = "Evaporation"
        Me.lblEvaporation.Text = "Evaporation "
        '
        'txtEvaporation
        '
        Me.txtEvaporation.Location = New System.Drawing.Point(102, 23)
        Me.txtEvaporation.Name = "txtEvaporation"
        Me.txtEvaporation.Size = New System.Drawing.Size(39, 20)
        Me.txtEvaporation.TabIndex = 2
        '
        'lblCodedOutput
        '
        Me.lblCodedOutput.AutoSize = True
        Me.lblCodedOutput.Location = New System.Drawing.Point(286, 362)
        Me.lblCodedOutput.Name = "lblCodedOutput"
        Me.lblCodedOutput.Size = New System.Drawing.Size(73, 13)
        Me.lblCodedOutput.TabIndex = 3
        Me.lblCodedOutput.Tag = "Coded_Output"
        Me.lblCodedOutput.Text = "Coded Output"
        '
        'grpCharacterMessage
        '
        Me.grpCharacterMessage.Controls.Add(Me.GroupBox8)
        Me.grpCharacterMessage.Controls.Add(Me.grpSendingOptions)
        Me.grpCharacterMessage.Controls.Add(Me.VScrollBar1)
        Me.grpCharacterMessage.Controls.Add(Me.txtCharacterMessage)
        Me.grpCharacterMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCharacterMessage.Location = New System.Drawing.Point(29, 423)
        Me.grpCharacterMessage.Name = "grpCharacterMessage"
        Me.grpCharacterMessage.Size = New System.Drawing.Size(629, 235)
        Me.grpCharacterMessage.TabIndex = 5
        Me.grpCharacterMessage.TabStop = False
        Me.grpCharacterMessage.Tag = "Character_Message"
        Me.grpCharacterMessage.Text = "Character Message"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.grpMailApplications)
        Me.GroupBox8.Controls.Add(Me.chkAttachUncodedData)
        Me.GroupBox8.Location = New System.Drawing.Point(136, 99)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(488, 134)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnSettings)
        Me.GroupBox9.Controls.Add(Me.btnSend)
        Me.GroupBox9.Location = New System.Drawing.Point(11, 88)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(171, 45)
        Me.GroupBox9.TabIndex = 6
        Me.GroupBox9.TabStop = False
        '
        'btnSettings
        '
        Me.btnSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.Location = New System.Drawing.Point(91, 12)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(75, 23)
        Me.btnSettings.TabIndex = 0
        Me.btnSettings.Tag = "Settings"
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.Location = New System.Drawing.Point(4, 13)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Tag = "Send"
        Me.btnSend.Text = "Send "
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'grpMailApplications
        '
        Me.grpMailApplications.Controls.Add(Me.btnSendMail)
        Me.grpMailApplications.Controls.Add(Me.lstMailApplications)
        Me.grpMailApplications.Controls.Add(Me.txtTo)
        Me.grpMailApplications.Controls.Add(Me.txtSubject)
        Me.grpMailApplications.Controls.Add(Me.lblTo)
        Me.grpMailApplications.Controls.Add(Me.Label37)
        Me.grpMailApplications.Controls.Add(Me.lblMailApplications)
        Me.grpMailApplications.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMailApplications.Location = New System.Drawing.Point(0, 2)
        Me.grpMailApplications.Name = "grpMailApplications"
        Me.grpMailApplications.Size = New System.Drawing.Size(488, 70)
        Me.grpMailApplications.TabIndex = 6
        Me.grpMailApplications.TabStop = False
        '
        'btnSendMail
        '
        Me.btnSendMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendMail.Location = New System.Drawing.Point(419, 36)
        Me.btnSendMail.Name = "btnSendMail"
        Me.btnSendMail.Size = New System.Drawing.Size(65, 23)
        Me.btnSendMail.TabIndex = 9
        Me.btnSendMail.Tag = "Send"
        Me.btnSendMail.Text = "Send"
        Me.btnSendMail.UseVisualStyleBackColor = True
        '
        'lstMailApplications
        '
        Me.lstMailApplications.FormattingEnabled = True
        Me.lstMailApplications.Location = New System.Drawing.Point(10, 25)
        Me.lstMailApplications.Name = "lstMailApplications"
        Me.lstMailApplications.Size = New System.Drawing.Size(91, 43)
        Me.lstMailApplications.TabIndex = 1
        Me.lstMailApplications.Tag = "Mail_Applications"
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(183, 17)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(231, 20)
        Me.txtTo.TabIndex = 8
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(182, 49)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(231, 20)
        Me.txtSubject.TabIndex = 8
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(147, 20)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(20, 13)
        Me.lblTo.TabIndex = 7
        Me.lblTo.Tag = "To"
        Me.lblTo.Text = "To"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(133, 49)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 13)
        Me.Label37.TabIndex = 7
        Me.Label37.Text = "Subject"
        '
        'lblMailApplications
        '
        Me.lblMailApplications.AutoSize = True
        Me.lblMailApplications.Location = New System.Drawing.Point(8, 11)
        Me.lblMailApplications.Name = "lblMailApplications"
        Me.lblMailApplications.Size = New System.Drawing.Size(103, 13)
        Me.lblMailApplications.TabIndex = 0
        Me.lblMailApplications.Tag = "Mail_Applications"
        Me.lblMailApplications.Text = "Mail Applications"
        '
        'chkAttachUncodedData
        '
        Me.chkAttachUncodedData.AutoSize = True
        Me.chkAttachUncodedData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAttachUncodedData.Location = New System.Drawing.Point(13, 74)
        Me.chkAttachUncodedData.Name = "chkAttachUncodedData"
        Me.chkAttachUncodedData.Size = New System.Drawing.Size(130, 17)
        Me.chkAttachUncodedData.TabIndex = 2
        Me.chkAttachUncodedData.Tag = "Attach_Uncoded_Data"
        Me.chkAttachUncodedData.Text = "Attach Uncoded Data"
        Me.chkAttachUncodedData.UseVisualStyleBackColor = True
        '
        'grpSendingOptions
        '
        Me.grpSendingOptions.Controls.Add(Me.lblFTP)
        Me.grpSendingOptions.Controls.Add(Me.rbFTP)
        Me.grpSendingOptions.Controls.Add(Me.lblEmail)
        Me.grpSendingOptions.Controls.Add(Me.rbEmail)
        Me.grpSendingOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSendingOptions.Location = New System.Drawing.Point(6, 101)
        Me.grpSendingOptions.Name = "grpSendingOptions"
        Me.grpSendingOptions.Size = New System.Drawing.Size(117, 75)
        Me.grpSendingOptions.TabIndex = 6
        Me.grpSendingOptions.TabStop = False
        Me.grpSendingOptions.Tag = "Sending_Options"
        Me.grpSendingOptions.Text = "Sending Options"
        '
        'lblFTP
        '
        Me.lblFTP.AutoSize = True
        Me.lblFTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTP.Location = New System.Drawing.Point(49, 47)
        Me.lblFTP.Name = "lblFTP"
        Me.lblFTP.Size = New System.Drawing.Size(27, 13)
        Me.lblFTP.TabIndex = 1
        Me.lblFTP.Tag = "FTP"
        Me.lblFTP.Text = "FTP"
        '
        'rbFTP
        '
        Me.rbFTP.AutoSize = True
        Me.rbFTP.Location = New System.Drawing.Point(18, 47)
        Me.rbFTP.Name = "rbFTP"
        Me.rbFTP.Size = New System.Drawing.Size(14, 13)
        Me.rbFTP.TabIndex = 0
        Me.rbFTP.TabStop = True
        Me.rbFTP.Tag = "FTP"
        Me.rbFTP.UseVisualStyleBackColor = True
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.Location = New System.Drawing.Point(48, 19)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(32, 13)
        Me.lblEmail.TabIndex = 1
        Me.lblEmail.Tag = "Email"
        Me.lblEmail.Text = "Email"
        '
        'rbEmail
        '
        Me.rbEmail.AutoSize = True
        Me.rbEmail.Location = New System.Drawing.Point(19, 19)
        Me.rbEmail.Name = "rbEmail"
        Me.rbEmail.Size = New System.Drawing.Size(14, 13)
        Me.rbEmail.TabIndex = 0
        Me.rbEmail.TabStop = True
        Me.rbEmail.Tag = "Email"
        Me.rbEmail.UseVisualStyleBackColor = True
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Location = New System.Drawing.Point(608, 24)
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(16, 74)
        Me.VScrollBar1.TabIndex = 1
        '
        'txtCharacterMessage
        '
        Me.txtCharacterMessage.Location = New System.Drawing.Point(4, 19)
        Me.txtCharacterMessage.Multiline = True
        Me.txtCharacterMessage.Name = "txtCharacterMessage"
        Me.txtCharacterMessage.Size = New System.Drawing.Size(601, 79)
        Me.txtCharacterMessage.TabIndex = 0
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(165, 664)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.Size = New System.Drawing.Size(75, 23)
        Me.btnEncode.TabIndex = 6
        Me.btnEncode.Tag = "Encode"
        Me.btnEncode.Text = "Encode"
        Me.btnEncode.UseVisualStyleBackColor = True
        '
        'btnViewImportExport
        '
        Me.btnViewImportExport.Location = New System.Drawing.Point(250, 664)
        Me.btnViewImportExport.Name = "btnViewImportExport"
        Me.btnViewImportExport.Size = New System.Drawing.Size(153, 23)
        Me.btnViewImportExport.TabIndex = 6
        Me.btnViewImportExport.Tag = "View_Import_Export"
        Me.btnViewImportExport.Text = "View/Import/Export"
        Me.btnViewImportExport.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(413, 664)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Tag = "Reset"
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(498, 664)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Tag = "Close"
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(583, 664)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(75, 23)
        Me.cmdHelp.TabIndex = 6
        Me.cmdHelp.Tag = "Help"
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'frmCrex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 699)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnViewImportExport)
        Me.Controls.Add(Me.btnEncode)
        Me.Controls.Add(Me.grpCharacterMessage)
        Me.Controls.Add(Me.lblCodedOutput)
        Me.Controls.Add(Me.lblNumberOfSubsets)
        Me.Controls.Add(Me.txtNumberOfSubsets)
        Me.Controls.Add(Me.grpInstrumentTypes)
        Me.Controls.Add(Me.grpSensorsHeightFromGround)
        Me.Controls.Add(Me.grpIndicators)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCrex"
        Me.Text = "CREX Synop"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpIndicators.ResumeLayout(False)
        Me.grpIndicators.PerformLayout()
        Me.grpSensorsHeightFromGround.ResumeLayout(False)
        Me.grpSensorsHeightFromGround.PerformLayout()
        Me.grpInstrumentTypes.ResumeLayout(False)
        Me.grpInstrumentTypes.PerformLayout()
        Me.grpCharacterMessage.ResumeLayout(False)
        Me.grpCharacterMessage.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.grpMailApplications.ResumeLayout(False)
        Me.grpMailApplications.PerformLayout()
        Me.grpSendingOptions.ResumeLayout(False)
        Me.grpSendingOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtMinute As TextBox
    Friend WithEvents txtHour As TextBox
    Friend WithEvents txtDay As TextBox
    Friend WithEvents txtMonth As TextBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents lblHour As Label
    Friend WithEvents lblMinute As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents cboTemplate As ComboBox
    Friend WithEvents cboBBB As ComboBox
    Friend WithEvents txtHeader As TextBox
    Friend WithEvents lblTemplate As Label
    Friend WithEvents lblBBB As Label
    Friend WithEvents lblIncludeCheckDigit As Label
    Friend WithEvents chkIncludeCheckDigit As CheckBox
    Friend WithEvents grpIndicators As GroupBox
    Friend WithEvents lblOriginatingGeneratingSubCenter As Label
    Friend WithEvents txtOriginatingGeneratingsubCenter As TextBox
    Friend WithEvents lblOriginatingGeneratingCenter As Label
    Friend WithEvents txtOriginatingGeneratingCenter As TextBox
    Friend WithEvents lblDataCategorySubCategory As Label
    Friend WithEvents txtDataCategorySubCategory As TextBox
    Friend WithEvents lblDataCategory As Label
    Friend WithEvents txtDataCategory As TextBox
    Friend WithEvents lblLocalTableVersionNumber As Label
    Friend WithEvents txtLocalTableversionNumber As TextBox
    Friend WithEvents lblBUFRMasterTableVersionNumber As Label
    Friend WithEvents txtBUFRMasterTableVersionNumber As TextBox
    Friend WithEvents lblCrexTableVersionNumber As Label
    Friend WithEvents txtCREXTableVersionNumber As TextBox
    Friend WithEvents lblCrexEditionsNumber As Label
    Friend WithEvents txtCREXEditionsNumber As TextBox
    Friend WithEvents lblNumberSequence As Label
    Friend WithEvents txtSequenceNumber As TextBox
    Friend WithEvents txtNumberOfSubsets As TextBox
    Friend WithEvents lblNumberOfSubsets As Label
    Friend WithEvents grpSensorsHeightFromGround As GroupBox
    Friend WithEvents lblSensorsheightFromGroundWind As Label
    Friend WithEvents lblPrecipitation As Label
    Friend WithEvents txtWind As TextBox
    Friend WithEvents txtPrecipitation As TextBox
    Friend WithEvents lblVisibility As Label
    Friend WithEvents txtVisibility As TextBox
    Friend WithEvents lblTemperature As Label
    Friend WithEvents txtTemperature As TextBox
    Friend WithEvents lblPressure As Label
    Friend WithEvents txtPressure As TextBox
    Friend WithEvents grpInstrumentTypes As GroupBox
    Friend WithEvents lblInstrumentTypesWind As Label
    Friend WithEvents txtInstrumentTypesWind As TextBox
    Friend WithEvents lblEvaporation As Label
    Friend WithEvents txtEvaporation As TextBox
    Friend WithEvents lblCodedOutput As Label
    Friend WithEvents grpCharacterMessage As GroupBox
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents txtCharacterMessage As TextBox
    Friend WithEvents grpSendingOptions As GroupBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents rbEmail As RadioButton
    Friend WithEvents lblFTP As Label
    Friend WithEvents rbFTP As RadioButton
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnSend As Button
    Friend WithEvents chkAttachUncodedData As CheckBox
    Friend WithEvents grpMailApplications As GroupBox
    Friend WithEvents btnSendMail As Button
    Friend WithEvents lstMailApplications As ListBox
    Friend WithEvents txtTo As TextBox
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents lblTo As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents lblMailApplications As Label
    Friend WithEvents btnEncode As Button
    Friend WithEvents btnViewImportExport As Button
    Friend WithEvents btnReset As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents cmdHelp As Button
End Class
