<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.menuStripMain = New System.Windows.Forms.MenuStrip()
        Me.mnuInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInputKeyEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInputPaperArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessories = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessoriesDewPointRH = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessoriesXMLOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserRecordsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProducts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdministration = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetadataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataFormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateObservationsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpeartionsMonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmptyKeyEntryTablesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateModifyKeyEntryFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeOwnPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsModifyForms = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectLanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerlSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SequencerConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.seqDailyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.seqHourlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.seqMonthlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.seqHourly2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormHourlyTimeSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormSynopticTimeSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSStationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationForTDCFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateScriptToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpContents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMainClose = New System.Windows.Forms.Button()
        Me.btnMainSettingsAWS = New System.Windows.Forms.Button()
        Me.btnMainMetadata = New System.Windows.Forms.Button()
        Me.btnMainUserManagement = New System.Windows.Forms.Button()
        Me.btnMainProducts = New System.Windows.Forms.Button()
        Me.btnMainQC = New System.Windows.Forms.Button()
        Me.btnMainDataTransfer = New System.Windows.Forms.Button()
        Me.btnMainPaperArchive = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMainDataEntry = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.menuStripMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStripMain
        '
        Me.menuStripMain.AllowItemReorder = True
        Me.menuStripMain.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.menuStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInput, Me.mnuAccessories, Me.mnuProducts, Me.mnuQC, Me.mnuAdministration, Me.ChangeOwnPasswordToolStripMenuItem, Me.mnuTools, Me.mnuHelp})
        Me.menuStripMain.Location = New System.Drawing.Point(0, 0)
        Me.menuStripMain.Name = "menuStripMain"
        Me.menuStripMain.ShowItemToolTips = True
        Me.menuStripMain.Size = New System.Drawing.Size(931, 27)
        Me.menuStripMain.TabIndex = 7
        Me.menuStripMain.Text = "Main Menu"
        '
        'mnuInput
        '
        Me.mnuInput.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInputKeyEntry, Me.mnuInputPaperArchive})
        Me.mnuInput.Name = "mnuInput"
        Me.mnuInput.ShortcutKeyDisplayString = ""
        Me.mnuInput.Size = New System.Drawing.Size(54, 23)
        Me.mnuInput.Tag = "Input"
        Me.mnuInput.Text = "Input"
        '
        'mnuInputKeyEntry
        '
        Me.mnuInputKeyEntry.Name = "mnuInputKeyEntry"
        Me.mnuInputKeyEntry.Size = New System.Drawing.Size(162, 24)
        Me.mnuInputKeyEntry.Tag = "Key_Entry"
        Me.mnuInputKeyEntry.Text = "Key Entry"
        '
        'mnuInputPaperArchive
        '
        Me.mnuInputPaperArchive.Name = "mnuInputPaperArchive"
        Me.mnuInputPaperArchive.Size = New System.Drawing.Size(162, 24)
        Me.mnuInputPaperArchive.Tag = "Paper_Archive"
        Me.mnuInputPaperArchive.Text = "Paper Archive"
        '
        'mnuAccessories
        '
        Me.mnuAccessories.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccessoriesDewPointRH, Me.mnuAccessoriesXMLOutput, Me.UserRecordsToolStripMenuItem1, Me.MnuInventory})
        Me.mnuAccessories.Name = "mnuAccessories"
        Me.mnuAccessories.Size = New System.Drawing.Size(90, 23)
        Me.mnuAccessories.Tag = "Accessories"
        Me.mnuAccessories.Text = "Accessories"
        '
        'mnuAccessoriesDewPointRH
        '
        Me.mnuAccessoriesDewPointRH.Name = "mnuAccessoriesDewPointRH"
        Me.mnuAccessoriesDewPointRH.Size = New System.Drawing.Size(274, 24)
        Me.mnuAccessoriesDewPointRH.Tag = "Calculation_of_dew_Point_and_RH"
        Me.mnuAccessoriesDewPointRH.Text = "Calculation of dew Point and RH"
        '
        'mnuAccessoriesXMLOutput
        '
        Me.mnuAccessoriesXMLOutput.Name = "mnuAccessoriesXMLOutput"
        Me.mnuAccessoriesXMLOutput.Size = New System.Drawing.Size(274, 24)
        Me.mnuAccessoriesXMLOutput.Tag = "Generate_XML_Output"
        Me.mnuAccessoriesXMLOutput.Text = "Generate XML Output"
        Me.mnuAccessoriesXMLOutput.Visible = False
        '
        'UserRecordsToolStripMenuItem1
        '
        Me.UserRecordsToolStripMenuItem1.Name = "UserRecordsToolStripMenuItem1"
        Me.UserRecordsToolStripMenuItem1.Size = New System.Drawing.Size(274, 24)
        Me.UserRecordsToolStripMenuItem1.Text = "User Records"
        '
        'MnuInventory
        '
        Me.MnuInventory.Name = "MnuInventory"
        Me.MnuInventory.Size = New System.Drawing.Size(274, 24)
        Me.MnuInventory.Text = "Inventory"
        '
        'mnuProducts
        '
        Me.mnuProducts.Name = "mnuProducts"
        Me.mnuProducts.Size = New System.Drawing.Size(75, 23)
        Me.mnuProducts.Tag = "Products"
        Me.mnuProducts.Text = "Products"
        '
        'mnuQC
        '
        Me.mnuQC.Name = "mnuQC"
        Me.mnuQC.Size = New System.Drawing.Size(41, 23)
        Me.mnuQC.Tag = "QC"
        Me.mnuQC.Text = "QC"
        '
        'mnuAdministration
        '
        Me.mnuAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserAdminToolStripMenuItem, Me.MetadataToolStripMenuItem, Me.PasswordToolStripMenuItem, Me.DataFormsToolStripMenuItem, Me.UpdateElementsToolStripMenuItem, Me.UpdateObservationsToolStripMenuItem1, Me.OpeartionsMonitoringToolStripMenuItem, Me.EmptyKeyEntryTablesToolStripMenuItem, Me.CreateModifyKeyEntryFormToolStripMenuItem})
        Me.mnuAdministration.Name = "mnuAdministration"
        Me.mnuAdministration.Size = New System.Drawing.Size(111, 23)
        Me.mnuAdministration.Tag = "Administration"
        Me.mnuAdministration.Text = "Administration"
        '
        'UserAdminToolStripMenuItem
        '
        Me.UserAdminToolStripMenuItem.Name = "UserAdminToolStripMenuItem"
        Me.UserAdminToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.UserAdminToolStripMenuItem.Tag = "User_Admin"
        Me.UserAdminToolStripMenuItem.Text = "User Admin"
        '
        'MetadataToolStripMenuItem
        '
        Me.MetadataToolStripMenuItem.Name = "MetadataToolStripMenuItem"
        Me.MetadataToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.MetadataToolStripMenuItem.Tag = "Metadata"
        Me.MetadataToolStripMenuItem.Text = "Metadata"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.PasswordToolStripMenuItem.Text = "Change Password"
        '
        'DataFormsToolStripMenuItem
        '
        Me.DataFormsToolStripMenuItem.Name = "DataFormsToolStripMenuItem"
        Me.DataFormsToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.DataFormsToolStripMenuItem.Tag = "Data_Forms"
        Me.DataFormsToolStripMenuItem.Text = "Data Forms"
        '
        'UpdateElementsToolStripMenuItem
        '
        Me.UpdateElementsToolStripMenuItem.Name = "UpdateElementsToolStripMenuItem"
        Me.UpdateElementsToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.UpdateElementsToolStripMenuItem.Tag = "Update_Element_Limits"
        Me.UpdateElementsToolStripMenuItem.Text = "Update Element Limits"
        Me.UpdateElementsToolStripMenuItem.Visible = False
        '
        'UpdateObservationsToolStripMenuItem1
        '
        Me.UpdateObservationsToolStripMenuItem1.Name = "UpdateObservationsToolStripMenuItem1"
        Me.UpdateObservationsToolStripMenuItem1.Size = New System.Drawing.Size(264, 24)
        Me.UpdateObservationsToolStripMenuItem1.Text = "Update Observations"
        '
        'OpeartionsMonitoringToolStripMenuItem
        '
        Me.OpeartionsMonitoringToolStripMenuItem.Name = "OpeartionsMonitoringToolStripMenuItem"
        Me.OpeartionsMonitoringToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.OpeartionsMonitoringToolStripMenuItem.Text = "Operations Monitoring"
        '
        'EmptyKeyEntryTablesToolStripMenuItem
        '
        Me.EmptyKeyEntryTablesToolStripMenuItem.Name = "EmptyKeyEntryTablesToolStripMenuItem"
        Me.EmptyKeyEntryTablesToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.EmptyKeyEntryTablesToolStripMenuItem.Text = "Empty Key Entry Forms"
        '
        'CreateModifyKeyEntryFormToolStripMenuItem
        '
        Me.CreateModifyKeyEntryFormToolStripMenuItem.Name = "CreateModifyKeyEntryFormToolStripMenuItem"
        Me.CreateModifyKeyEntryFormToolStripMenuItem.Size = New System.Drawing.Size(264, 24)
        Me.CreateModifyKeyEntryFormToolStripMenuItem.Text = "Create/Modify Key Entry Form"
        '
        'ChangeOwnPasswordToolStripMenuItem
        '
        Me.ChangeOwnPasswordToolStripMenuItem.Name = "ChangeOwnPasswordToolStripMenuItem"
        Me.ChangeOwnPasswordToolStripMenuItem.Size = New System.Drawing.Size(160, 23)
        Me.ChangeOwnPasswordToolStripMenuItem.Text = "Change own password"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsModifyForms, Me.SelectLanguageToolStripMenuItem, Me.GenerlSettingsToolStripMenuItem, Me.SequencerConfigurationToolStripMenuItem, Me.FormHourlyTimeSelectionToolStripMenuItem, Me.FormSynopticTimeSelectionToolStripMenuItem, Me.AWSToolStripMenuItem, Me.ConfigurationForTDCFToolStripMenuItem, Me.UpdateScriptToolStripMenuItem1})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(52, 23)
        Me.mnuTools.Tag = "Tools"
        Me.mnuTools.Text = "Tools"
        '
        'mnuToolsModifyForms
        '
        Me.mnuToolsModifyForms.Name = "mnuToolsModifyForms"
        Me.mnuToolsModifyForms.Size = New System.Drawing.Size(250, 24)
        Me.mnuToolsModifyForms.Tag = "Modify_Forms"
        Me.mnuToolsModifyForms.Text = "Modify Forms"
        Me.mnuToolsModifyForms.Visible = False
        '
        'SelectLanguageToolStripMenuItem
        '
        Me.SelectLanguageToolStripMenuItem.Name = "SelectLanguageToolStripMenuItem"
        Me.SelectLanguageToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.SelectLanguageToolStripMenuItem.Tag = "Select_Language"
        Me.SelectLanguageToolStripMenuItem.Text = "Select Language"
        '
        'GenerlSettingsToolStripMenuItem
        '
        Me.GenerlSettingsToolStripMenuItem.Name = "GenerlSettingsToolStripMenuItem"
        Me.GenerlSettingsToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.GenerlSettingsToolStripMenuItem.Text = "General Settings"
        '
        'SequencerConfigurationToolStripMenuItem
        '
        Me.SequencerConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.seqDailyToolStripMenuItem, Me.seqHourlyToolStripMenuItem, Me.seqMonthlyToolStripMenuItem, Me.seqHourly2ToolStripMenuItem})
        Me.SequencerConfigurationToolStripMenuItem.Name = "SequencerConfigurationToolStripMenuItem"
        Me.SequencerConfigurationToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.SequencerConfigurationToolStripMenuItem.Text = "Sequencer Configuration"
        '
        'seqDailyToolStripMenuItem
        '
        Me.seqDailyToolStripMenuItem.Name = "seqDailyToolStripMenuItem"
        Me.seqDailyToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.seqDailyToolStripMenuItem.Text = "Daily"
        '
        'seqHourlyToolStripMenuItem
        '
        Me.seqHourlyToolStripMenuItem.Name = "seqHourlyToolStripMenuItem"
        Me.seqHourlyToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.seqHourlyToolStripMenuItem.Text = "Hourly"
        '
        'seqMonthlyToolStripMenuItem
        '
        Me.seqMonthlyToolStripMenuItem.Name = "seqMonthlyToolStripMenuItem"
        Me.seqMonthlyToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.seqMonthlyToolStripMenuItem.Text = "Monthly"
        '
        'seqHourly2ToolStripMenuItem
        '
        Me.seqHourly2ToolStripMenuItem.Name = "seqHourly2ToolStripMenuItem"
        Me.seqHourly2ToolStripMenuItem.Size = New System.Drawing.Size(130, 24)
        Me.seqHourly2ToolStripMenuItem.Text = "Hourly2"
        '
        'FormHourlyTimeSelectionToolStripMenuItem
        '
        Me.FormHourlyTimeSelectionToolStripMenuItem.Name = "FormHourlyTimeSelectionToolStripMenuItem"
        Me.FormHourlyTimeSelectionToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.FormHourlyTimeSelectionToolStripMenuItem.Text = "FormHourly Time Selection"
        '
        'FormSynopticTimeSelectionToolStripMenuItem
        '
        Me.FormSynopticTimeSelectionToolStripMenuItem.Name = "FormSynopticTimeSelectionToolStripMenuItem"
        Me.FormSynopticTimeSelectionToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.FormSynopticTimeSelectionToolStripMenuItem.Text = "FormSynoptic Hours Setting"
        '
        'AWSToolStripMenuItem
        '
        Me.AWSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AWSElementsToolStripMenuItem, Me.AWSStationsToolStripMenuItem})
        Me.AWSToolStripMenuItem.Name = "AWSToolStripMenuItem"
        Me.AWSToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.AWSToolStripMenuItem.Text = "AWS"
        Me.AWSToolStripMenuItem.Visible = False
        '
        'AWSElementsToolStripMenuItem
        '
        Me.AWSElementsToolStripMenuItem.Name = "AWSElementsToolStripMenuItem"
        Me.AWSElementsToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.AWSElementsToolStripMenuItem.Text = "AWS Elements"
        '
        'AWSStationsToolStripMenuItem
        '
        Me.AWSStationsToolStripMenuItem.Name = "AWSStationsToolStripMenuItem"
        Me.AWSStationsToolStripMenuItem.Size = New System.Drawing.Size(165, 24)
        Me.AWSStationsToolStripMenuItem.Text = "AWS Stations"
        '
        'ConfigurationForTDCFToolStripMenuItem
        '
        Me.ConfigurationForTDCFToolStripMenuItem.Name = "ConfigurationForTDCFToolStripMenuItem"
        Me.ConfigurationForTDCFToolStripMenuItem.Size = New System.Drawing.Size(250, 24)
        Me.ConfigurationForTDCFToolStripMenuItem.Text = "TDCF Settings"
        '
        'UpdateScriptToolStripMenuItem1
        '
        Me.UpdateScriptToolStripMenuItem1.Name = "UpdateScriptToolStripMenuItem1"
        Me.UpdateScriptToolStripMenuItem1.Size = New System.Drawing.Size(250, 24)
        Me.UpdateScriptToolStripMenuItem1.Text = "Update db with Script File"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpContents, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(49, 23)
        Me.mnuHelp.Tag = "Help"
        Me.mnuHelp.Text = "Help"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Name = "mnuHelpContents"
        Me.mnuHelpContents.Size = New System.Drawing.Size(180, 24)
        Me.mnuHelpContents.Tag = "Contents"
        Me.mnuHelpContents.Text = "Contents"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(180, 24)
        Me.mnuHelpAbout.Tag = "About"
        Me.mnuHelpAbout.Text = "About"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Linen
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnMainClose)
        Me.Panel1.Controls.Add(Me.btnMainSettingsAWS)
        Me.Panel1.Controls.Add(Me.btnMainMetadata)
        Me.Panel1.Controls.Add(Me.btnMainUserManagement)
        Me.Panel1.Controls.Add(Me.btnMainProducts)
        Me.Panel1.Controls.Add(Me.btnMainQC)
        Me.Panel1.Controls.Add(Me.btnMainDataTransfer)
        Me.Panel1.Controls.Add(Me.btnMainPaperArchive)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnMainDataEntry)
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(931, 558)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(381, 471)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 40)
        Me.Label5.TabIndex = 36
        Me.Label5.Tag = "Close"
        Me.Label5.Text = "Close"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(400, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 25)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Welcome"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(165, 471)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 78)
        Me.Label9.TabIndex = 33
        Me.Label9.Tag = "AWS_Real_Time_Processing"
        Me.Label9.Text = "AWS Real Time Processing"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(588, 471)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(176, 40)
        Me.Label8.TabIndex = 32
        Me.Label8.Tag = "Metadata_Information"
        Me.Label8.Text = "Metadata Information"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(162, 350)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 40)
        Me.Label7.TabIndex = 31
        Me.Label7.Tag = "Users_Administration"
        Me.Label7.Text = "Users Administration"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(588, 349)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 40)
        Me.Label6.TabIndex = 30
        Me.Label6.Tag = "Climate_Products"
        Me.Label6.Text = "Climate Products"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(588, 226)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 40)
        Me.Label4.TabIndex = 28
        Me.Label4.Tag = "Quality_Control_Checks"
        Me.Label4.Text = "Quality Control Checks"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(162, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(176, 40)
        Me.Label3.TabIndex = 27
        Me.Label3.Tag = "Data_Transfer"
        Me.Label3.Text = "Data Transfer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(588, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 40)
        Me.Label2.TabIndex = 26
        Me.Label2.Tag = "Archive_Paper_Image"
        Me.Label2.Text = "Archive Paper Image"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnMainClose
        '
        Me.btnMainClose.BackgroundImage = CType(resources.GetObject("btnMainClose.BackgroundImage"), System.Drawing.Image)
        Me.btnMainClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainClose.FlatAppearance.BorderSize = 4
        Me.btnMainClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainClose.Location = New System.Drawing.Point(420, 399)
        Me.btnMainClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainClose.Name = "btnMainClose"
        Me.btnMainClose.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainClose.Size = New System.Drawing.Size(96, 69)
        Me.btnMainClose.TabIndex = 25
        Me.btnMainClose.UseCompatibleTextRendering = True
        Me.btnMainClose.UseVisualStyleBackColor = True
        '
        'btnMainSettingsAWS
        '
        Me.btnMainSettingsAWS.BackgroundImage = CType(resources.GetObject("btnMainSettingsAWS.BackgroundImage"), System.Drawing.Image)
        Me.btnMainSettingsAWS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainSettingsAWS.FlatAppearance.BorderSize = 4
        Me.btnMainSettingsAWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainSettingsAWS.ForeColor = System.Drawing.Color.Red
        Me.btnMainSettingsAWS.Location = New System.Drawing.Point(187, 395)
        Me.btnMainSettingsAWS.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainSettingsAWS.Name = "btnMainSettingsAWS"
        Me.btnMainSettingsAWS.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainSettingsAWS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainSettingsAWS.Size = New System.Drawing.Size(126, 76)
        Me.btnMainSettingsAWS.TabIndex = 24
        Me.btnMainSettingsAWS.UseCompatibleTextRendering = True
        Me.btnMainSettingsAWS.UseVisualStyleBackColor = True
        '
        'btnMainMetadata
        '
        Me.btnMainMetadata.BackgroundImage = CType(resources.GetObject("btnMainMetadata.BackgroundImage"), System.Drawing.Image)
        Me.btnMainMetadata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainMetadata.FlatAppearance.BorderSize = 4
        Me.btnMainMetadata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainMetadata.ForeColor = System.Drawing.Color.Red
        Me.btnMainMetadata.Location = New System.Drawing.Point(610, 395)
        Me.btnMainMetadata.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainMetadata.Name = "btnMainMetadata"
        Me.btnMainMetadata.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainMetadata.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainMetadata.Size = New System.Drawing.Size(126, 76)
        Me.btnMainMetadata.TabIndex = 23
        Me.btnMainMetadata.UseCompatibleTextRendering = True
        Me.btnMainMetadata.UseVisualStyleBackColor = True
        '
        'btnMainUserManagement
        '
        Me.btnMainUserManagement.BackgroundImage = CType(resources.GetObject("btnMainUserManagement.BackgroundImage"), System.Drawing.Image)
        Me.btnMainUserManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainUserManagement.FlatAppearance.BorderSize = 4
        Me.btnMainUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainUserManagement.ForeColor = System.Drawing.Color.Red
        Me.btnMainUserManagement.Location = New System.Drawing.Point(187, 274)
        Me.btnMainUserManagement.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainUserManagement.Name = "btnMainUserManagement"
        Me.btnMainUserManagement.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainUserManagement.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainUserManagement.Size = New System.Drawing.Size(126, 76)
        Me.btnMainUserManagement.TabIndex = 22
        Me.btnMainUserManagement.UseCompatibleTextRendering = True
        Me.btnMainUserManagement.UseVisualStyleBackColor = True
        '
        'btnMainProducts
        '
        Me.btnMainProducts.BackgroundImage = CType(resources.GetObject("btnMainProducts.BackgroundImage"), System.Drawing.Image)
        Me.btnMainProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainProducts.FlatAppearance.BorderSize = 4
        Me.btnMainProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainProducts.ForeColor = System.Drawing.Color.Red
        Me.btnMainProducts.Location = New System.Drawing.Point(610, 273)
        Me.btnMainProducts.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainProducts.Name = "btnMainProducts"
        Me.btnMainProducts.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainProducts.Size = New System.Drawing.Size(126, 76)
        Me.btnMainProducts.TabIndex = 21
        Me.btnMainProducts.UseCompatibleTextRendering = True
        Me.btnMainProducts.UseVisualStyleBackColor = True
        '
        'btnMainQC
        '
        Me.btnMainQC.BackgroundImage = CType(resources.GetObject("btnMainQC.BackgroundImage"), System.Drawing.Image)
        Me.btnMainQC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainQC.FlatAppearance.BorderSize = 4
        Me.btnMainQC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainQC.ForeColor = System.Drawing.Color.Red
        Me.btnMainQC.Location = New System.Drawing.Point(611, 152)
        Me.btnMainQC.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainQC.Name = "btnMainQC"
        Me.btnMainQC.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainQC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainQC.Size = New System.Drawing.Size(126, 76)
        Me.btnMainQC.TabIndex = 20
        Me.btnMainQC.UseCompatibleTextRendering = True
        Me.btnMainQC.UseVisualStyleBackColor = True
        '
        'btnMainDataTransfer
        '
        Me.btnMainDataTransfer.BackgroundImage = CType(resources.GetObject("btnMainDataTransfer.BackgroundImage"), System.Drawing.Image)
        Me.btnMainDataTransfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainDataTransfer.FlatAppearance.BorderSize = 4
        Me.btnMainDataTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainDataTransfer.ForeColor = System.Drawing.Color.Red
        Me.btnMainDataTransfer.Location = New System.Drawing.Point(187, 152)
        Me.btnMainDataTransfer.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainDataTransfer.Name = "btnMainDataTransfer"
        Me.btnMainDataTransfer.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainDataTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainDataTransfer.Size = New System.Drawing.Size(126, 76)
        Me.btnMainDataTransfer.TabIndex = 19
        Me.btnMainDataTransfer.UseCompatibleTextRendering = True
        Me.btnMainDataTransfer.UseVisualStyleBackColor = True
        '
        'btnMainPaperArchive
        '
        Me.btnMainPaperArchive.BackgroundImage = CType(resources.GetObject("btnMainPaperArchive.BackgroundImage"), System.Drawing.Image)
        Me.btnMainPaperArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainPaperArchive.FlatAppearance.BorderSize = 4
        Me.btnMainPaperArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainPaperArchive.ForeColor = System.Drawing.Color.Red
        Me.btnMainPaperArchive.Location = New System.Drawing.Point(611, 25)
        Me.btnMainPaperArchive.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMainPaperArchive.Name = "btnMainPaperArchive"
        Me.btnMainPaperArchive.Padding = New System.Windows.Forms.Padding(5)
        Me.btnMainPaperArchive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnMainPaperArchive.Size = New System.Drawing.Size(126, 76)
        Me.btnMainPaperArchive.TabIndex = 5
        Me.btnMainPaperArchive.UseCompatibleTextRendering = True
        Me.btnMainPaperArchive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(162, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 40)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = "Data_Entry"
        Me.Label1.Text = "Data Entry"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnMainDataEntry
        '
        Me.btnMainDataEntry.AutoEllipsis = True
        Me.btnMainDataEntry.BackgroundImage = CType(resources.GetObject("btnMainDataEntry.BackgroundImage"), System.Drawing.Image)
        Me.btnMainDataEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainDataEntry.FlatAppearance.BorderSize = 10
        Me.btnMainDataEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMainDataEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMainDataEntry.ForeColor = System.Drawing.Color.Red
        Me.btnMainDataEntry.Location = New System.Drawing.Point(187, 25)
        Me.btnMainDataEntry.Name = "btnMainDataEntry"
        Me.btnMainDataEntry.Size = New System.Drawing.Size(126, 76)
        Me.btnMainDataEntry.TabIndex = 3
        Me.btnMainDataEntry.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnMainDataEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnMainDataEntry.UseVisualStyleBackColor = True
        '
        'HelpProvider1
        '
        Me.HelpProvider1.HelpNamespace = "climsoft4.chm"
        '
        'frmMainMenu
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(931, 585)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.menuStripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.IsMdiContainer = True
        Me.Name = "frmMainMenu"
        Me.Tag = "Main_Menu"
        Me.Text = "Main Menu"
        Me.menuStripMain.ResumeLayout(False)
        Me.menuStripMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuStripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuInput As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInputKeyEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInputPaperArchive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccessories As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccessoriesDewPointRH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAccessoriesXMLOutput As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuQC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProducts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAdministration As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserAdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetadataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataFormsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateElementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToolsModifyForms As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpContents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMainClose As System.Windows.Forms.Button
    Friend WithEvents btnMainSettingsAWS As System.Windows.Forms.Button
    Friend WithEvents btnMainMetadata As System.Windows.Forms.Button
    Friend WithEvents btnMainUserManagement As System.Windows.Forms.Button
    Friend WithEvents btnMainProducts As System.Windows.Forms.Button
    Friend WithEvents btnMainQC As System.Windows.Forms.Button
    Friend WithEvents btnMainDataTransfer As System.Windows.Forms.Button
    Friend WithEvents btnMainPaperArchive As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnMainDataEntry As System.Windows.Forms.Button
    Friend WithEvents SelectLanguageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerlSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SequencerConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents seqDailyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents seqHourlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormHourlyTimeSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeOwnPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSElementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSStationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigurationForTDCFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateObservationsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpeartionsMonitoringToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserRecordsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents seqMonthlyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmptyKeyEntryTablesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreateModifyKeyEntryFormToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents FormSynopticTimeSelectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MnuInventory As ToolStripMenuItem
    Friend WithEvents UpdateScriptToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents seqHourly2ToolStripMenuItem As ToolStripMenuItem
End Class
