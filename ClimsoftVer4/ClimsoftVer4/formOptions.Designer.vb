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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formOptions))
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
        resources.ApplyResources(Me.TabOptions, "TabOptions")
        Me.TabOptions.Name = "TabOptions"
        Me.TabOptions.SelectedIndex = 0
        '
        'tabDataEntry
        '
        Me.tabDataEntry.BackColor = System.Drawing.Color.OldLace
        Me.tabDataEntry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabDataEntry.Controls.Add(Me.grpBoxEntryMode)
        Me.tabDataEntry.Controls.Add(Me.groupEntryForms)
        resources.ApplyResources(Me.tabDataEntry, "tabDataEntry")
        Me.tabDataEntry.Name = "tabDataEntry"
        '
        'grpBoxEntryMode
        '
        Me.grpBoxEntryMode.Controls.Add(Me.ComboBox1)
        Me.grpBoxEntryMode.Controls.Add(Me.Label1)
        Me.grpBoxEntryMode.Controls.Add(Me.RadioButton2)
        Me.grpBoxEntryMode.Controls.Add(Me.RadioButton1)
        resources.ApplyResources(Me.grpBoxEntryMode, "grpBoxEntryMode")
        Me.grpBoxEntryMode.Name = "grpBoxEntryMode"
        Me.grpBoxEntryMode.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'groupEntryForms
        '
        Me.groupEntryForms.Controls.Add(Me.CheckBox2)
        Me.groupEntryForms.Controls.Add(Me.CheckBox1)
        resources.ApplyResources(Me.groupEntryForms, "groupEntryForms")
        Me.groupEntryForms.Name = "groupEntryForms"
        Me.groupEntryForms.TabStop = False
        '
        'CheckBox2
        '
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'tabdatabase
        '
        Me.tabdatabase.BackColor = System.Drawing.Color.Cornsilk
        Me.tabdatabase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabdatabase.Controls.Add(Me.grpBoxdb)
        resources.ApplyResources(Me.tabdatabase, "tabdatabase")
        Me.tabdatabase.Name = "tabdatabase"
        '
        'grpBoxdb
        '
        Me.grpBoxdb.Controls.Add(Me.cmdChangePassword)
        Me.grpBoxdb.Controls.Add(Me.lblDelimiter)
        Me.grpBoxdb.Controls.Add(Me.txtDelimiter)
        resources.ApplyResources(Me.grpBoxdb, "grpBoxdb")
        Me.grpBoxdb.Name = "grpBoxdb"
        Me.grpBoxdb.TabStop = False
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.AutoEllipsis = True
        Me.cmdChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.Red
        resources.ApplyResources(Me.cmdChangePassword, "cmdChangePassword")
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.UseVisualStyleBackColor = True
        '
        'lblDelimiter
        '
        resources.ApplyResources(Me.lblDelimiter, "lblDelimiter")
        Me.lblDelimiter.Name = "lblDelimiter"
        '
        'txtDelimiter
        '
        resources.ApplyResources(Me.txtDelimiter, "txtDelimiter")
        Me.txtDelimiter.Name = "txtDelimiter"
        '
        'tabMessageHeaders
        '
        Me.tabMessageHeaders.BackColor = System.Drawing.Color.AntiqueWhite
        Me.tabMessageHeaders.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabMessageHeaders.Controls.Add(Me.GroupBox2)
        Me.tabMessageHeaders.Controls.Add(Me.Label2)
        Me.tabMessageHeaders.Controls.Add(Me.dataGridViewMsgHeaders)
        resources.ApplyResources(Me.tabMessageHeaders, "tabMessageHeaders")
        Me.tabMessageHeaders.Name = "tabMessageHeaders"
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
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'lblCrexEditionsNumber
        '
        resources.ApplyResources(Me.lblCrexEditionsNumber, "lblCrexEditionsNumber")
        Me.lblCrexEditionsNumber.Name = "lblCrexEditionsNumber"
        Me.lblCrexEditionsNumber.Tag = "crex_Editions_Number"
        '
        'txtCREXEditionNumber
        '
        resources.ApplyResources(Me.txtCREXEditionNumber, "txtCREXEditionNumber")
        Me.txtCREXEditionNumber.Name = "txtCREXEditionNumber"
        '
        'lblLocalTableVersionNumber
        '
        resources.ApplyResources(Me.lblLocalTableVersionNumber, "lblLocalTableVersionNumber")
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Tag = "Local_Table_Version_Number"
        '
        'txtLocalTableversionNumber
        '
        resources.ApplyResources(Me.txtLocalTableversionNumber, "txtLocalTableversionNumber")
        Me.txtLocalTableversionNumber.Name = "txtLocalTableversionNumber"
        '
        'lblInternationalDataSubCategory
        '
        resources.ApplyResources(Me.lblInternationalDataSubCategory, "lblInternationalDataSubCategory")
        Me.lblInternationalDataSubCategory.Name = "lblInternationalDataSubCategory"
        Me.lblInternationalDataSubCategory.Tag = "International-Data-Sub-Category"
        '
        'chkOptionalSequenceInclusion
        '
        resources.ApplyResources(Me.chkOptionalSequenceInclusion, "chkOptionalSequenceInclusion")
        Me.chkOptionalSequenceInclusion.Name = "chkOptionalSequenceInclusion"
        Me.chkOptionalSequenceInclusion.UseVisualStyleBackColor = True
        '
        'lblMastersTableVersionNumber
        '
        resources.ApplyResources(Me.lblMastersTableVersionNumber, "lblMastersTableVersionNumber")
        Me.lblMastersTableVersionNumber.Name = "lblMastersTableVersionNumber"
        Me.lblMastersTableVersionNumber.Tag = "Master_Table_Version_Number"
        '
        'txtMasterTableVersionNumber
        '
        resources.ApplyResources(Me.txtMasterTableVersionNumber, "txtMasterTableVersionNumber")
        Me.txtMasterTableVersionNumber.Name = "txtMasterTableVersionNumber"
        '
        'lblLocalDataSubCateory
        '
        resources.ApplyResources(Me.lblLocalDataSubCateory, "lblLocalDataSubCateory")
        Me.lblLocalDataSubCateory.Name = "lblLocalDataSubCateory"
        Me.lblLocalDataSubCateory.Tag = "Local_Data_Sub_Cateory"
        '
        'txtLocalDataSubCategory
        '
        resources.ApplyResources(Me.txtLocalDataSubCategory, "txtLocalDataSubCategory")
        Me.txtLocalDataSubCategory.Name = "txtLocalDataSubCategory"
        '
        'txtInternationalDataSubCategory
        '
        resources.ApplyResources(Me.txtInternationalDataSubCategory, "txtInternationalDataSubCategory")
        Me.txtInternationalDataSubCategory.Name = "txtInternationalDataSubCategory"
        '
        'lblDataCategory
        '
        resources.ApplyResources(Me.lblDataCategory, "lblDataCategory")
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Tag = "Data_Category"
        '
        'txtDataCategory
        '
        resources.ApplyResources(Me.txtDataCategory, "txtDataCategory")
        Me.txtDataCategory.Name = "txtDataCategory"
        '
        'lblOptionalSequenceInclusion
        '
        resources.ApplyResources(Me.lblOptionalSequenceInclusion, "lblOptionalSequenceInclusion")
        Me.lblOptionalSequenceInclusion.Name = "lblOptionalSequenceInclusion"
        Me.lblOptionalSequenceInclusion.Tag = "BUFR_Optional_Sequence_Inclusion"
        '
        'lblGeneratingSubCentre
        '
        resources.ApplyResources(Me.lblGeneratingSubCentre, "lblGeneratingSubCentre")
        Me.lblGeneratingSubCentre.Name = "lblGeneratingSubCentre"
        Me.lblGeneratingSubCentre.Tag = "Generating_SubCentre"
        '
        'txtGeneratingSubCentre
        '
        resources.ApplyResources(Me.txtGeneratingSubCentre, "txtGeneratingSubCentre")
        Me.txtGeneratingSubCentre.Name = "txtGeneratingSubCentre"
        '
        'lblCrexTableVersionNumber
        '
        resources.ApplyResources(Me.lblCrexTableVersionNumber, "lblCrexTableVersionNumber")
        Me.lblCrexTableVersionNumber.Name = "lblCrexTableVersionNumber"
        Me.lblCrexTableVersionNumber.Tag = "Crex_Table_Version_Number"
        '
        'lblOriginatingCentre
        '
        resources.ApplyResources(Me.lblOriginatingCentre, "lblOriginatingCentre")
        Me.lblOriginatingCentre.Name = "lblOriginatingCentre"
        Me.lblOriginatingCentre.Tag = "Generating_Centre"
        '
        'txtCREXTableVersionNumber
        '
        resources.ApplyResources(Me.txtCREXTableVersionNumber, "txtCREXTableVersionNumber")
        Me.txtCREXTableVersionNumber.Name = "txtCREXTableVersionNumber"
        '
        'txtGeneratingCentre
        '
        resources.ApplyResources(Me.txtGeneratingCentre, "txtGeneratingCentre")
        Me.txtGeneratingCentre.Name = "txtGeneratingCentre"
        '
        'lblBUFREditionNumber
        '
        resources.ApplyResources(Me.lblBUFREditionNumber, "lblBUFREditionNumber")
        Me.lblBUFREditionNumber.Name = "lblBUFREditionNumber"
        Me.lblBUFREditionNumber.Tag = "BUFR Edition_Number"
        '
        'txtBUFREditionNumber
        '
        resources.ApplyResources(Me.txtBUFREditionNumber, "txtBUFREditionNumber")
        Me.txtBUFREditionNumber.Name = "txtBUFREditionNumber"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'dataGridViewMsgHeaders
        '
        Me.dataGridViewMsgHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewMsgHeaders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeType, Me.MainHour, Me.OthorHours})
        resources.ApplyResources(Me.dataGridViewMsgHeaders, "dataGridViewMsgHeaders")
        Me.dataGridViewMsgHeaders.Name = "dataGridViewMsgHeaders"
        Me.dataGridViewMsgHeaders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        '
        'CodeType
        '
        resources.ApplyResources(Me.CodeType, "CodeType")
        Me.CodeType.Name = "CodeType"
        '
        'MainHour
        '
        resources.ApplyResources(Me.MainHour, "MainHour")
        Me.MainHour.Name = "MainHour"
        '
        'OthorHours
        '
        resources.ApplyResources(Me.OthorHours, "OthorHours")
        Me.OthorHours.Name = "OthorHours"
        '
        'tabObservations
        '
        Me.tabObservations.BackColor = System.Drawing.Color.LemonChiffon
        Me.tabObservations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabObservations.Controls.Add(Me.GroupBox3)
        resources.ApplyResources(Me.tabObservations, "tabObservations")
        Me.tabObservations.Name = "tabObservations"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtMSLElevation)
        Me.GroupBox3.Controls.Add(Me.txtStandardPressureLevel)
        Me.GroupBox3.Controls.Add(Me.txtObsTime)
        Me.GroupBox3.Controls.Add(Me.lblMSLPressureElevation)
        Me.GroupBox3.Controls.Add(Me.lblStandardPressureLevel)
        Me.GroupBox3.Controls.Add(Me.lblObsTime)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'txtMSLElevation
        '
        resources.ApplyResources(Me.txtMSLElevation, "txtMSLElevation")
        Me.txtMSLElevation.Name = "txtMSLElevation"
        '
        'txtStandardPressureLevel
        '
        resources.ApplyResources(Me.txtStandardPressureLevel, "txtStandardPressureLevel")
        Me.txtStandardPressureLevel.Name = "txtStandardPressureLevel"
        '
        'txtObsTime
        '
        resources.ApplyResources(Me.txtObsTime, "txtObsTime")
        Me.txtObsTime.Name = "txtObsTime"
        '
        'lblMSLPressureElevation
        '
        resources.ApplyResources(Me.lblMSLPressureElevation, "lblMSLPressureElevation")
        Me.lblMSLPressureElevation.Name = "lblMSLPressureElevation"
        '
        'lblStandardPressureLevel
        '
        resources.ApplyResources(Me.lblStandardPressureLevel, "lblStandardPressureLevel")
        Me.lblStandardPressureLevel.Name = "lblStandardPressureLevel"
        '
        'lblObsTime
        '
        resources.ApplyResources(Me.lblObsTime, "lblObsTime")
        Me.lblObsTime.Name = "lblObsTime"
        '
        'groupBoxCommands
        '
        Me.groupBoxCommands.Controls.Add(Me.cmdHelp)
        Me.groupBoxCommands.Controls.Add(Me.cmdClose)
        Me.groupBoxCommands.Controls.Add(Me.cmdApply)
        Me.groupBoxCommands.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.groupBoxCommands, "groupBoxCommands")
        Me.groupBoxCommands.Name = "groupBoxCommands"
        Me.groupBoxCommands.TabStop = False
        '
        'cmdHelp
        '
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'formOptions
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.groupBoxCommands)
        Me.Controls.Add(Me.TabOptions)
        Me.Name = "formOptions"
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
