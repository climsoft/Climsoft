<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formOptions
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
        Me.TabOptions = New System.Windows.Forms.TabControl()
        Me.tabDataEntry = New System.Windows.Forms.TabPage()
        Me.grpBoxEntryMode = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.groupEntryForms = New System.Windows.Forms.GroupBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tabdatabase = New System.Windows.Forms.TabPage()
        Me.grpBoxdb = New System.Windows.Forms.GroupBox()
        Me.cmdChangePassword = New System.Windows.Forms.Button()
        Me.lblDelimiter = New System.Windows.Forms.Label()
        Me.txtDelimiter = New System.Windows.Forms.TextBox()
        Me.tabMessageHeaders = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCrexEditionsNumber = New System.Windows.Forms.Label()
        Me.txtCREXEditionNumber = New System.Windows.Forms.TextBox()
        Me.lblLocalTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtLocalTableversionNumber = New System.Windows.Forms.TextBox()
        Me.lblInternationalDataSubCategory = New System.Windows.Forms.Label()
        Me.chkOptionalSequenceInclusion = New System.Windows.Forms.CheckBox()
        Me.lblMastersTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtMasterTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblLocalDataSubCateory = New System.Windows.Forms.Label()
        Me.txtLocalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.txtInternationalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.lblDataCategory = New System.Windows.Forms.Label()
        Me.txtDataCategory = New System.Windows.Forms.TextBox()
        Me.lblOptionalSequenceInclusion = New System.Windows.Forms.Label()
        Me.lblGeneratingSubCentre = New System.Windows.Forms.Label()
        Me.txtGeneratingSubCentre = New System.Windows.Forms.TextBox()
        Me.lblCrexTableVersionNumber = New System.Windows.Forms.Label()
        Me.lblOriginatingCentre = New System.Windows.Forms.Label()
        Me.txtCREXTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.txtGeneratingCentre = New System.Windows.Forms.TextBox()
        Me.lblBUFREditionNumber = New System.Windows.Forms.Label()
        Me.txtBUFREditionNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dataGridViewMsgHeaders = New System.Windows.Forms.DataGridView()
        Me.CodeType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainHour = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OthorHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabObservations = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtMSLElevation = New System.Windows.Forms.TextBox()
        Me.txtStandardPressureLevel = New System.Windows.Forms.TextBox()
        Me.txtObsTime = New System.Windows.Forms.TextBox()
        Me.lblMSLPressureElevation = New System.Windows.Forms.Label()
        Me.lblStandardPressureLevel = New System.Windows.Forms.Label()
        Me.lblObsTime = New System.Windows.Forms.Label()
        Me.groupBoxCommands = New System.Windows.Forms.GroupBox()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.TabOptions.SuspendLayout()
        Me.tabDataEntry.SuspendLayout()
        Me.grpBoxEntryMode.SuspendLayout()
        Me.groupEntryForms.SuspendLayout()
        Me.tabdatabase.SuspendLayout()
        Me.grpBoxdb.SuspendLayout()
        Me.tabMessageHeaders.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dataGridViewMsgHeaders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabObservations.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.groupBoxCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabOptions
        '
        Me.TabOptions.Controls.Add(Me.tabDataEntry)
        Me.TabOptions.Controls.Add(Me.tabdatabase)
        Me.TabOptions.Controls.Add(Me.tabMessageHeaders)
        Me.TabOptions.Controls.Add(Me.tabObservations)
        Me.TabOptions.Location = New System.Drawing.Point(14, 18)
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.SelectedIndex = 0
        Me.TabOptions.Size = New System.Drawing.Size(673, 359)
        Me.TabOptions.TabIndex = 0
        '
        'tabDataEntry
        '
        Me.tabDataEntry.BackColor = System.Drawing.Color.OldLace
        Me.tabDataEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabDataEntry.Controls.Add(Me.grpBoxEntryMode)
        Me.tabDataEntry.Controls.Add(Me.groupEntryForms)
        Me.tabDataEntry.Location = New System.Drawing.Point(4, 22)
        Me.tabDataEntry.Name = "tabDataEntry"
        Me.tabDataEntry.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDataEntry.Size = New System.Drawing.Size(665, 333)
        Me.tabDataEntry.TabIndex = 0
        Me.tabDataEntry.Text = "Data Entry"
        '
        'grpBoxEntryMode
        '
        Me.grpBoxEntryMode.Controls.Add(Me.ComboBox1)
        Me.grpBoxEntryMode.Controls.Add(Me.Label1)
        Me.grpBoxEntryMode.Controls.Add(Me.RadioButton2)
        Me.grpBoxEntryMode.Controls.Add(Me.RadioButton1)
        Me.grpBoxEntryMode.Location = New System.Drawing.Point(288, 37)
        Me.grpBoxEntryMode.Name = "grpBoxEntryMode"
        Me.grpBoxEntryMode.Size = New System.Drawing.Size(356, 245)
        Me.grpBoxEntryMode.TabIndex = 1
        Me.grpBoxEntryMode.TabStop = False
        Me.grpBoxEntryMode.Text = "Data Key Entry Mode"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(141, 126)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(199, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select Reference Table"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(18, 88)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(107, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Double Key Entry"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(18, 46)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(102, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Single Key Entry"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'groupEntryForms
        '
        Me.groupEntryForms.Controls.Add(Me.CheckBox2)
        Me.groupEntryForms.Controls.Add(Me.CheckBox1)
        Me.groupEntryForms.Location = New System.Drawing.Point(19, 37)
        Me.groupEntryForms.Name = "groupEntryForms"
        Me.groupEntryForms.Size = New System.Drawing.Size(256, 245)
        Me.groupEntryForms.TabIndex = 0
        Me.groupEntryForms.TabStop = False
        Me.groupEntryForms.Text = "Data Entry Form Options"
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(10, 104)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(227, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Clear data in key entry form after uploading"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 45)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(203, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Retain data values in the form header"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'tabdatabase
        '
        Me.tabdatabase.BackColor = System.Drawing.Color.Cornsilk
        Me.tabdatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabdatabase.Controls.Add(Me.grpBoxdb)
        Me.tabdatabase.Location = New System.Drawing.Point(4, 22)
        Me.tabdatabase.Name = "tabdatabase"
        Me.tabdatabase.Padding = New System.Windows.Forms.Padding(3)
        Me.tabdatabase.Size = New System.Drawing.Size(665, 333)
        Me.tabdatabase.TabIndex = 1
        Me.tabdatabase.Text = "Databases"
        '
        'grpBoxdb
        '
        Me.grpBoxdb.Controls.Add(Me.cmdChangePassword)
        Me.grpBoxdb.Controls.Add(Me.lblDelimiter)
        Me.grpBoxdb.Controls.Add(Me.txtDelimiter)
        Me.grpBoxdb.Location = New System.Drawing.Point(106, 56)
        Me.grpBoxdb.Name = "grpBoxdb"
        Me.grpBoxdb.Size = New System.Drawing.Size(439, 210)
        Me.grpBoxdb.TabIndex = 3
        Me.grpBoxdb.TabStop = False
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.AutoEllipsis = True
        Me.cmdChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.cmdChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdChangePassword.Location = New System.Drawing.Point(67, 93)
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New System.Drawing.Size(181, 35)
        Me.cmdChangePassword.TabIndex = 5
        Me.cmdChangePassword.Text = "Change Password"
        Me.cmdChangePassword.UseVisualStyleBackColor = True
        '
        'lblDelimiter
        '
        Me.lblDelimiter.AutoSize = True
        Me.lblDelimiter.Location = New System.Drawing.Point(64, 52)
        Me.lblDelimiter.Name = "lblDelimiter"
        Me.lblDelimiter.Size = New System.Drawing.Size(184, 13)
        Me.lblDelimiter.TabIndex = 4
        Me.lblDelimiter.Text = "Delimiter character for text output files"
        '
        'txtDelimiter
        '
        Me.txtDelimiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelimiter.Location = New System.Drawing.Point(254, 48)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(26, 21)
        Me.txtDelimiter.TabIndex = 3
        Me.txtDelimiter.Text = ","
        Me.txtDelimiter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tabMessageHeaders
        '
        Me.tabMessageHeaders.BackColor = System.Drawing.Color.AntiqueWhite
        Me.tabMessageHeaders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabMessageHeaders.Controls.Add(Me.GroupBox2)
        Me.tabMessageHeaders.Controls.Add(Me.Label2)
        Me.tabMessageHeaders.Controls.Add(Me.dataGridViewMsgHeaders)
        Me.tabMessageHeaders.Location = New System.Drawing.Point(4, 22)
        Me.tabMessageHeaders.Name = "tabMessageHeaders"
        Me.tabMessageHeaders.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMessageHeaders.Size = New System.Drawing.Size(665, 333)
        Me.tabMessageHeaders.TabIndex = 2
        Me.tabMessageHeaders.Text = "Message Encoding"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCrexEditionsNumber)
        Me.GroupBox2.Controls.Add(Me.txtCREXEditionNumber)
        Me.GroupBox2.Controls.Add(Me.lblLocalTableVersionNumber)
        Me.GroupBox2.Controls.Add(Me.txtLocalTableversionNumber)
        Me.GroupBox2.Controls.Add(Me.lblInternationalDataSubCategory)
        Me.GroupBox2.Controls.Add(Me.chkOptionalSequenceInclusion)
        Me.GroupBox2.Controls.Add(Me.lblMastersTableVersionNumber)
        Me.GroupBox2.Controls.Add(Me.txtMasterTableVersionNumber)
        Me.GroupBox2.Controls.Add(Me.lblLocalDataSubCateory)
        Me.GroupBox2.Controls.Add(Me.txtLocalDataSubCategory)
        Me.GroupBox2.Controls.Add(Me.txtInternationalDataSubCategory)
        Me.GroupBox2.Controls.Add(Me.lblDataCategory)
        Me.GroupBox2.Controls.Add(Me.txtDataCategory)
        Me.GroupBox2.Controls.Add(Me.lblOptionalSequenceInclusion)
        Me.GroupBox2.Controls.Add(Me.lblGeneratingSubCentre)
        Me.GroupBox2.Controls.Add(Me.txtGeneratingSubCentre)
        Me.GroupBox2.Controls.Add(Me.lblCrexTableVersionNumber)
        Me.GroupBox2.Controls.Add(Me.lblOriginatingCentre)
        Me.GroupBox2.Controls.Add(Me.txtCREXTableVersionNumber)
        Me.GroupBox2.Controls.Add(Me.txtGeneratingCentre)
        Me.GroupBox2.Controls.Add(Me.lblBUFREditionNumber)
        Me.GroupBox2.Controls.Add(Me.txtBUFREditionNumber)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GroupBox2.Location = New System.Drawing.Point(370, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(277, 284)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Section I Indicators"
        '
        'lblCrexEditionsNumber
        '
        Me.lblCrexEditionsNumber.AutoSize = True
        Me.lblCrexEditionsNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrexEditionsNumber.Location = New System.Drawing.Point(8, 214)
        Me.lblCrexEditionsNumber.Name = "lblCrexEditionsNumber"
        Me.lblCrexEditionsNumber.Size = New System.Drawing.Size(116, 13)
        Me.lblCrexEditionsNumber.TabIndex = 37
        Me.lblCrexEditionsNumber.Tag = "crex_Editions_Number"
        Me.lblCrexEditionsNumber.Text = "CREX Editions Number"
        '
        'txtCREXEditionNumber
        '
        Me.txtCREXEditionNumber.Location = New System.Drawing.Point(213, 210)
        Me.txtCREXEditionNumber.Name = "txtCREXEditionNumber"
        Me.txtCREXEditionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtCREXEditionNumber.TabIndex = 38
        '
        'lblLocalTableVersionNumber
        '
        Me.lblLocalTableVersionNumber.AutoSize = True
        Me.lblLocalTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalTableVersionNumber.Location = New System.Drawing.Point(8, 46)
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Size = New System.Drawing.Size(137, 13)
        Me.lblLocalTableVersionNumber.TabIndex = 33
        Me.lblLocalTableVersionNumber.Tag = "Local_Table_Version_Number"
        Me.lblLocalTableVersionNumber.Text = "Local table Version Number"
        '
        'txtLocalTableversionNumber
        '
        Me.txtLocalTableversionNumber.Location = New System.Drawing.Point(212, 42)
        Me.txtLocalTableversionNumber.Name = "txtLocalTableversionNumber"
        Me.txtLocalTableversionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalTableversionNumber.TabIndex = 34
        '
        'lblInternationalDataSubCategory
        '
        Me.lblInternationalDataSubCategory.AutoSize = True
        Me.lblInternationalDataSubCategory.Location = New System.Drawing.Point(8, 142)
        Me.lblInternationalDataSubCategory.Name = "lblInternationalDataSubCategory"
        Me.lblInternationalDataSubCategory.Size = New System.Drawing.Size(158, 13)
        Me.lblInternationalDataSubCategory.TabIndex = 32
        Me.lblInternationalDataSubCategory.Tag = "International-Data-Sub-Category"
        Me.lblInternationalDataSubCategory.Text = "International Data Sub-Category"
        '
        'chkOptionalSequenceInclusion
        '
        Me.chkOptionalSequenceInclusion.AutoSize = True
        Me.chkOptionalSequenceInclusion.Location = New System.Drawing.Point(213, 260)
        Me.chkOptionalSequenceInclusion.Name = "chkOptionalSequenceInclusion"
        Me.chkOptionalSequenceInclusion.Size = New System.Drawing.Size(15, 14)
        Me.chkOptionalSequenceInclusion.TabIndex = 31
        Me.chkOptionalSequenceInclusion.UseVisualStyleBackColor = True
        '
        'lblMastersTableVersionNumber
        '
        Me.lblMastersTableVersionNumber.AutoSize = True
        Me.lblMastersTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMastersTableVersionNumber.Location = New System.Drawing.Point(8, 22)
        Me.lblMastersTableVersionNumber.Name = "lblMastersTableVersionNumber"
        Me.lblMastersTableVersionNumber.Size = New System.Drawing.Size(147, 13)
        Me.lblMastersTableVersionNumber.TabIndex = 15
        Me.lblMastersTableVersionNumber.Tag = "Master_Table_Version_Number"
        Me.lblMastersTableVersionNumber.Text = "Master Table Version Number"
        '
        'txtMasterTableVersionNumber
        '
        Me.txtMasterTableVersionNumber.Location = New System.Drawing.Point(212, 18)
        Me.txtMasterTableVersionNumber.Name = "txtMasterTableVersionNumber"
        Me.txtMasterTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtMasterTableVersionNumber.TabIndex = 30
        '
        'lblLocalDataSubCateory
        '
        Me.lblLocalDataSubCateory.AutoSize = True
        Me.lblLocalDataSubCateory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalDataSubCateory.Location = New System.Drawing.Point(8, 166)
        Me.lblLocalDataSubCateory.Name = "lblLocalDataSubCateory"
        Me.lblLocalDataSubCateory.Size = New System.Drawing.Size(126, 13)
        Me.lblLocalDataSubCateory.TabIndex = 16
        Me.lblLocalDataSubCateory.Tag = "Local_Data_Sub_Cateory"
        Me.lblLocalDataSubCateory.Text = "Local Data Sub-Category"
        '
        'txtLocalDataSubCategory
        '
        Me.txtLocalDataSubCategory.Location = New System.Drawing.Point(213, 162)
        Me.txtLocalDataSubCategory.Name = "txtLocalDataSubCategory"
        Me.txtLocalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalDataSubCategory.TabIndex = 29
        '
        'txtInternationalDataSubCategory
        '
        Me.txtInternationalDataSubCategory.Location = New System.Drawing.Point(212, 138)
        Me.txtInternationalDataSubCategory.Name = "txtInternationalDataSubCategory"
        Me.txtInternationalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtInternationalDataSubCategory.TabIndex = 28
        '
        'lblDataCategory
        '
        Me.lblDataCategory.AutoSize = True
        Me.lblDataCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCategory.Location = New System.Drawing.Point(8, 118)
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Size = New System.Drawing.Size(78, 13)
        Me.lblDataCategory.TabIndex = 19
        Me.lblDataCategory.Tag = "Data_Category"
        Me.lblDataCategory.Text = "Data Category " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(212, 114)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtDataCategory.TabIndex = 27
        '
        'lblOptionalSequenceInclusion
        '
        Me.lblOptionalSequenceInclusion.AutoSize = True
        Me.lblOptionalSequenceInclusion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionalSequenceInclusion.Location = New System.Drawing.Point(8, 261)
        Me.lblOptionalSequenceInclusion.MaximumSize = New System.Drawing.Size(1000, 1100)
        Me.lblOptionalSequenceInclusion.Name = "lblOptionalSequenceInclusion"
        Me.lblOptionalSequenceInclusion.Size = New System.Drawing.Size(175, 13)
        Me.lblOptionalSequenceInclusion.TabIndex = 14
        Me.lblOptionalSequenceInclusion.Tag = "BUFR_Optional_Sequence_Inclusion"
        Me.lblOptionalSequenceInclusion.Text = "BUFR Optional Sequence Inclusion"
        '
        'lblGeneratingSubCentre
        '
        Me.lblGeneratingSubCentre.AutoSize = True
        Me.lblGeneratingSubCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneratingSubCentre.Location = New System.Drawing.Point(8, 94)
        Me.lblGeneratingSubCentre.Name = "lblGeneratingSubCentre"
        Me.lblGeneratingSubCentre.Size = New System.Drawing.Size(115, 13)
        Me.lblGeneratingSubCentre.TabIndex = 20
        Me.lblGeneratingSubCentre.Tag = "Generating_SubCentre"
        Me.lblGeneratingSubCentre.Text = "Generating Sub-Centre"
        '
        'txtGeneratingSubCentre
        '
        Me.txtGeneratingSubCentre.Location = New System.Drawing.Point(212, 90)
        Me.txtGeneratingSubCentre.Name = "txtGeneratingSubCentre"
        Me.txtGeneratingSubCentre.Size = New System.Drawing.Size(39, 20)
        Me.txtGeneratingSubCentre.TabIndex = 24
        '
        'lblCrexTableVersionNumber
        '
        Me.lblCrexTableVersionNumber.AutoSize = True
        Me.lblCrexTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCrexTableVersionNumber.Location = New System.Drawing.Point(8, 238)
        Me.lblCrexTableVersionNumber.Name = "lblCrexTableVersionNumber"
        Me.lblCrexTableVersionNumber.Size = New System.Drawing.Size(144, 13)
        Me.lblCrexTableVersionNumber.TabIndex = 4
        Me.lblCrexTableVersionNumber.Tag = "Crex_Table_Version_Number"
        Me.lblCrexTableVersionNumber.Text = "CREX Table Version Number"
        '
        'lblOriginatingCentre
        '
        Me.lblOriginatingCentre.AutoSize = True
        Me.lblOriginatingCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingCentre.Location = New System.Drawing.Point(8, 70)
        Me.lblOriginatingCentre.Name = "lblOriginatingCentre"
        Me.lblOriginatingCentre.Size = New System.Drawing.Size(93, 13)
        Me.lblOriginatingCentre.TabIndex = 17
        Me.lblOriginatingCentre.Tag = "Generating_Centre"
        Me.lblOriginatingCentre.Text = "Generating Centre"
        '
        'txtCREXTableVersionNumber
        '
        Me.txtCREXTableVersionNumber.Location = New System.Drawing.Point(212, 234)
        Me.txtCREXTableVersionNumber.Name = "txtCREXTableVersionNumber"
        Me.txtCREXTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtCREXTableVersionNumber.TabIndex = 18
        '
        'txtGeneratingCentre
        '
        Me.txtGeneratingCentre.Location = New System.Drawing.Point(212, 66)
        Me.txtGeneratingCentre.Name = "txtGeneratingCentre"
        Me.txtGeneratingCentre.Size = New System.Drawing.Size(39, 20)
        Me.txtGeneratingCentre.TabIndex = 23
        '
        'lblBUFREditionNumber
        '
        Me.lblBUFREditionNumber.AutoSize = True
        Me.lblBUFREditionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBUFREditionNumber.Location = New System.Drawing.Point(8, 190)
        Me.lblBUFREditionNumber.Name = "lblBUFREditionNumber"
        Me.lblBUFREditionNumber.Size = New System.Drawing.Size(111, 13)
        Me.lblBUFREditionNumber.TabIndex = 21
        Me.lblBUFREditionNumber.Tag = "BUFR Edition_Number"
        Me.lblBUFREditionNumber.Text = "BUFR Edition Number"
        '
        'txtBUFREditionNumber
        '
        Me.txtBUFREditionNumber.Location = New System.Drawing.Point(213, 186)
        Me.txtBUFREditionNumber.Name = "txtBUFREditionNumber"
        Me.txtBUFREditionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtBUFREditionNumber.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(132, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Message Headers"
        '
        'dataGridViewMsgHeaders
        '
        Me.dataGridViewMsgHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewMsgHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeType, Me.MainHour, Me.OthorHours})
        Me.dataGridViewMsgHeaders.Location = New System.Drawing.Point(15, 32)
        Me.dataGridViewMsgHeaders.Name = "dataGridViewMsgHeaders"
        Me.dataGridViewMsgHeaders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dataGridViewMsgHeaders.Size = New System.Drawing.Size(345, 273)
        Me.dataGridViewMsgHeaders.TabIndex = 0
        '
        'CodeType
        '
        Me.CodeType.HeaderText = "Code Type"
        Me.CodeType.Name = "CodeType"
        '
        'MainHour
        '
        Me.MainHour.HeaderText = "Main Hour"
        Me.MainHour.Name = "MainHour"
        '
        'OthorHours
        '
        Me.OthorHours.HeaderText = "Other Hours"
        Me.OthorHours.Name = "OthorHours"
        '
        'tabObservations
        '
        Me.tabObservations.BackColor = System.Drawing.Color.LemonChiffon
        Me.tabObservations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabObservations.Controls.Add(Me.GroupBox3)
        Me.tabObservations.Location = New System.Drawing.Point(4, 22)
        Me.tabObservations.Name = "tabObservations"
        Me.tabObservations.Padding = New System.Windows.Forms.Padding(3)
        Me.tabObservations.Size = New System.Drawing.Size(665, 333)
        Me.tabObservations.TabIndex = 3
        Me.tabObservations.Text = "Observations"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMSLElevation)
        Me.GroupBox3.Controls.Add(Me.txtStandardPressureLevel)
        Me.GroupBox3.Controls.Add(Me.txtObsTime)
        Me.GroupBox3.Controls.Add(Me.lblMSLPressureElevation)
        Me.GroupBox3.Controls.Add(Me.lblStandardPressureLevel)
        Me.GroupBox3.Controls.Add(Me.lblObsTime)
        Me.GroupBox3.Location = New System.Drawing.Point(117, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(401, 224)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'txtMSLElevation
        '
        Me.txtMSLElevation.Location = New System.Drawing.Point(240, 145)
        Me.txtMSLElevation.Name = "txtMSLElevation"
        Me.txtMSLElevation.Size = New System.Drawing.Size(53, 20)
        Me.txtMSLElevation.TabIndex = 5
        Me.txtMSLElevation.Text = "500"
        Me.txtMSLElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtStandardPressureLevel
        '
        Me.txtStandardPressureLevel.Location = New System.Drawing.Point(240, 94)
        Me.txtStandardPressureLevel.Name = "txtStandardPressureLevel"
        Me.txtStandardPressureLevel.Size = New System.Drawing.Size(53, 20)
        Me.txtStandardPressureLevel.TabIndex = 4
        Me.txtStandardPressureLevel.Text = "850"
        Me.txtStandardPressureLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtObsTime
        '
        Me.txtObsTime.Location = New System.Drawing.Point(240, 43)
        Me.txtObsTime.Name = "txtObsTime"
        Me.txtObsTime.Size = New System.Drawing.Size(53, 20)
        Me.txtObsTime.TabIndex = 3
        Me.txtObsTime.Text = "06:00"
        Me.txtObsTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMSLPressureElevation
        '
        Me.lblMSLPressureElevation.AutoSize = True
        Me.lblMSLPressureElevation.Location = New System.Drawing.Point(62, 149)
        Me.lblMSLPressureElevation.Name = "lblMSLPressureElevation"
        Me.lblMSLPressureElevation.Size = New System.Drawing.Size(159, 13)
        Me.lblMSLPressureElevation.TabIndex = 2
        Me.lblMSLPressureElevation.Text = "MSL Pressre threshold elevation"
        '
        'lblStandardPressureLevel
        '
        Me.lblStandardPressureLevel.AutoSize = True
        Me.lblStandardPressureLevel.Location = New System.Drawing.Point(62, 98)
        Me.lblStandardPressureLevel.Name = "lblStandardPressureLevel"
        Me.lblStandardPressureLevel.Size = New System.Drawing.Size(123, 13)
        Me.lblStandardPressureLevel.TabIndex = 1
        Me.lblStandardPressureLevel.Text = "Standard Pressure Level"
        '
        'lblObsTime
        '
        Me.lblObsTime.AutoSize = True
        Me.lblObsTime.Location = New System.Drawing.Point(62, 47)
        Me.lblObsTime.Name = "lblObsTime"
        Me.lblObsTime.Size = New System.Drawing.Size(116, 13)
        Me.lblObsTime.TabIndex = 0
        Me.lblObsTime.Text = "Daily Observation Time"
        '
        'groupBoxCommands
        '
        Me.groupBoxCommands.Controls.Add(Me.cmdHelp)
        Me.groupBoxCommands.Controls.Add(Me.cmdClose)
        Me.groupBoxCommands.Controls.Add(Me.cmdApply)
        Me.groupBoxCommands.Controls.Add(Me.cmdOk)
        Me.groupBoxCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.groupBoxCommands.Location = New System.Drawing.Point(0, 392)
        Me.groupBoxCommands.Name = "groupBoxCommands"
        Me.groupBoxCommands.Size = New System.Drawing.Size(702, 35)
        Me.groupBoxCommands.TabIndex = 1
        Me.groupBoxCommands.TabStop = False
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(528, 9)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(66, 25)
        Me.cmdHelp.TabIndex = 3
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(394, 9)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(66, 25)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        Me.cmdApply.Location = New System.Drawing.Point(260, 9)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(66, 25)
        Me.cmdApply.TabIndex = 1
        Me.cmdApply.Text = "Apply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(126, 9)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(66, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'formOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 427)
        Me.Controls.Add(Me.groupBoxCommands)
        Me.Controls.Add(Me.TabOptions)
        Me.Name = "formOptions"
        Me.Text = "Form Options"
        Me.TabOptions.ResumeLayout(False)
        Me.tabDataEntry.ResumeLayout(False)
        Me.grpBoxEntryMode.ResumeLayout(False)
        Me.grpBoxEntryMode.PerformLayout()
        Me.groupEntryForms.ResumeLayout(False)
        Me.groupEntryForms.PerformLayout()
        Me.tabdatabase.ResumeLayout(False)
        Me.grpBoxdb.ResumeLayout(False)
        Me.grpBoxdb.PerformLayout()
        Me.tabMessageHeaders.ResumeLayout(False)
        Me.tabMessageHeaders.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dataGridViewMsgHeaders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabObservations.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.groupBoxCommands.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabOptions As System.Windows.Forms.TabControl
    Friend WithEvents tabDataEntry As System.Windows.Forms.TabPage
    Friend WithEvents tabdatabase As System.Windows.Forms.TabPage
    Friend WithEvents tabMessageHeaders As System.Windows.Forms.TabPage
    Friend WithEvents tabObservations As System.Windows.Forms.TabPage
    Friend WithEvents groupBoxCommands As System.Windows.Forms.GroupBox
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents grpBoxEntryMode As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents groupEntryForms As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents dataGridViewMsgHeaders As System.Windows.Forms.DataGridView
    Friend WithEvents CodeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainHour As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OthorHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkOptionalSequenceInclusion As System.Windows.Forms.CheckBox
    Friend WithEvents lblMastersTableVersionNumber As System.Windows.Forms.Label
    Friend WithEvents txtMasterTableVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalDataSubCateory As System.Windows.Forms.Label
    Friend WithEvents txtLocalDataSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtInternationalDataSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblDataCategory As System.Windows.Forms.Label
    Friend WithEvents txtDataCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblOptionalSequenceInclusion As System.Windows.Forms.Label
    Friend WithEvents lblGeneratingSubCentre As System.Windows.Forms.Label
    Friend WithEvents txtGeneratingSubCentre As System.Windows.Forms.TextBox
    Friend WithEvents lblOriginatingCentre As System.Windows.Forms.Label
    Friend WithEvents txtGeneratingCentre As System.Windows.Forms.TextBox
    Friend WithEvents lblBUFREditionNumber As System.Windows.Forms.Label
    Friend WithEvents txtBUFREditionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblInternationalDataSubCategory As System.Windows.Forms.Label
    Friend WithEvents lblCrexEditionsNumber As System.Windows.Forms.Label
    Friend WithEvents txtCREXEditionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalTableVersionNumber As System.Windows.Forms.Label
    Friend WithEvents txtLocalTableversionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblCrexTableVersionNumber As System.Windows.Forms.Label
    Friend WithEvents txtCREXTableVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblMSLPressureElevation As System.Windows.Forms.Label
    Friend WithEvents lblStandardPressureLevel As System.Windows.Forms.Label
    Friend WithEvents lblObsTime As System.Windows.Forms.Label
    Friend WithEvents txtMSLElevation As System.Windows.Forms.TextBox
    Friend WithEvents txtStandardPressureLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtObsTime As System.Windows.Forms.TextBox
    Friend WithEvents grpBoxdb As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChangePassword As System.Windows.Forms.Button
    Friend WithEvents lblDelimiter As System.Windows.Forms.Label
    Friend WithEvents txtDelimiter As System.Windows.Forms.TextBox
End Class
