<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
    Inherits ClimsoftVer4.frmGeneral

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.mnuInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInputKeyEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInputPaperArchive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessories = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessoriesDewPointRH = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAccessoriesXMLOutput = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuQC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuProducts = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAdministration = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetadataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataFormsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigureDatabaseConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeOwnPasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsModifyForms = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectLanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenerlSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SequencerConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HourlyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FormHourlyTimeSelectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSElementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AWSStationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLanguageTranslation = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.cmdRedCloseButton = New System.Windows.Forms.Button()
        Me.cmdSettingsAWS = New System.Windows.Forms.Button()
        Me.cmdMetadata = New System.Windows.Forms.Button()
        Me.cmdUserManagement = New System.Windows.Forms.Button()
        Me.cmdProducts = New System.Windows.Forms.Button()
        Me.cmdQC = New System.Windows.Forms.Button()
        Me.cmdDataTransfer = New System.Windows.Forms.Button()
        Me.cmdPaperArchive = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdKeyEntry = New System.Windows.Forms.Button()
        Me.StandardProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RProductsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AllowItemReorder = True
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInput, Me.mnuAccessories, Me.mnuProducts, Me.mnuQC, Me.mnuAdministration, Me.ChangeOwnPasswordToolStripMenuItem, Me.mnuTools, Me.mnuLanguageTranslation, Me.mnuHelp})
        Me.MenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.ShowItemToolTips = True
        Me.MenuStrip2.Size = New System.Drawing.Size(849, 27)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'mnuInput
        '
        Me.mnuInput.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInputKeyEntry, Me.mnuInputPaperArchive})
        Me.mnuInput.Name = "mnuInput"
        resources.ApplyResources(Me.mnuInput, "mnuInput")
        Me.mnuInput.Tag = "Input"
        '
        'mnuInputKeyEntry
        '
        Me.mnuInputKeyEntry.Name = "mnuInputKeyEntry"
        resources.ApplyResources(Me.mnuInputKeyEntry, "mnuInputKeyEntry")
        Me.mnuInputKeyEntry.Tag = "Key_Entry"
        '
        'mnuInputPaperArchive
        '
        Me.mnuInputPaperArchive.Name = "mnuInputPaperArchive"
        resources.ApplyResources(Me.mnuInputPaperArchive, "mnuInputPaperArchive")
        Me.mnuInputPaperArchive.Tag = "Paper_Archive"
        '
        'mnuAccessories
        '
        Me.mnuAccessories.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccessoriesDewPointRH, Me.mnuAccessoriesXMLOutput})
        Me.mnuAccessories.Name = "mnuAccessories"
        resources.ApplyResources(Me.mnuAccessories, "mnuAccessories")
        Me.mnuAccessories.Tag = "Accessories"
        Me.mnuAccessories.Text = "Accessories"
        Me.mnuAccessories.Visible = False
        '
        'mnuAccessoriesDewPointRH
        '
        Me.mnuAccessoriesDewPointRH.Name = "mnuAccessoriesDewPointRH"
        resources.ApplyResources(Me.mnuAccessoriesDewPointRH, "mnuAccessoriesDewPointRH")
        Me.mnuAccessoriesDewPointRH.Tag = "Calculation_of_dew_Point_and_RH"
        '
        'mnuAccessoriesXMLOutput
        '
        Me.mnuAccessoriesXMLOutput.Name = "mnuAccessoriesXMLOutput"
        resources.ApplyResources(Me.mnuAccessoriesXMLOutput, "mnuAccessoriesXMLOutput")
        Me.mnuAccessoriesXMLOutput.Tag = "Generate_XML_Output"
        '
        'mnuQC
        '
        Me.mnuQC.Name = "mnuQC"
        resources.ApplyResources(Me.mnuQC, "mnuQC")
        Me.mnuQC.Tag = "QC"
        '
        'mnuProducts
        '
        Me.mnuProducts.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StandardProductsToolStripMenuItem, Me.RProductsToolStripMenuItem})
        Me.mnuProducts.Name = "mnuProducts"
        resources.ApplyResources(Me.mnuProducts, "mnuProducts")
        Me.mnuProducts.Tag = "Products"
        '
        'mnuAdministration
        '
        Me.mnuAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserAdminToolStripMenuItem, Me.MetadataToolStripMenuItem, Me.PasswordToolStripMenuItem, Me.DataFormsToolStripMenuItem, Me.UpdateElementsToolStripMenuItem, Me.ConfigureDatabaseConnectionToolStripMenuItem})
        Me.mnuAdministration.Name = "mnuAdministration"
        resources.ApplyResources(Me.mnuAdministration, "mnuAdministration")
        Me.mnuAdministration.Tag = "Administration"
        '
        'UserAdminToolStripMenuItem
        '
        Me.UserAdminToolStripMenuItem.Name = "UserAdminToolStripMenuItem"
        Me.UserAdminToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.UserAdminToolStripMenuItem.Tag = "User_Admin"
        '
        'MetadataToolStripMenuItem
        '
        Me.MetadataToolStripMenuItem.Name = "MetadataToolStripMenuItem"
        Me.MetadataToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.MetadataToolStripMenuItem.Tag = "Metadata"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.PasswordToolStripMenuItem.Text = "Change Password"
        '
        'DataFormsToolStripMenuItem
        '
        Me.DataFormsToolStripMenuItem.Name = "DataFormsToolStripMenuItem"
        Me.DataFormsToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.DataFormsToolStripMenuItem.Tag = "Data_Forms"
        '
        'UpdateElementsToolStripMenuItem
        '
        Me.UpdateElementsToolStripMenuItem.Name = "UpdateElementsToolStripMenuItem"
        Me.UpdateElementsToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.UpdateElementsToolStripMenuItem.Tag = "Update_Element_Limits"
        '
        'ConfigureDatabaseConnectionToolStripMenuItem
        '
        Me.ConfigureDatabaseConnectionToolStripMenuItem.Name = "ConfigureDatabaseConnectionToolStripMenuItem"
        Me.ConfigureDatabaseConnectionToolStripMenuItem.Size = New System.Drawing.Size(273, 24)
        Me.ConfigureDatabaseConnectionToolStripMenuItem.Text = "Configure Database Connection"
        '
        'ChangeOwnPasswordToolStripMenuItem
        '
        Me.ChangeOwnPasswordToolStripMenuItem.Name = "ChangeOwnPasswordToolStripMenuItem"
        Me.ChangeOwnPasswordToolStripMenuItem.Size = New System.Drawing.Size(160, 23)
        Me.ChangeOwnPasswordToolStripMenuItem.Text = "Change own password"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsModifyForms, Me.SelectLanguageToolStripMenuItem, Me.GenerlSettingsToolStripMenuItem, Me.SequencerConfigurationToolStripMenuItem, Me.FormHourlyTimeSelectionToolStripMenuItem, Me.AWSToolStripMenuItem})
        Me.mnuTools.Name = "mnuTools"
        resources.ApplyResources(Me.mnuTools, "mnuTools")
        Me.mnuTools.Tag = "Tools"
        '
        'mnuToolsModifyForms
        '
        Me.mnuToolsModifyForms.Name = "mnuToolsModifyForms"
        resources.ApplyResources(Me.mnuToolsModifyForms, "mnuToolsModifyForms")
        Me.mnuToolsModifyForms.Tag = "Modify_Forms"
        '
        'SelectLanguageToolStripMenuItem
        '
        Me.SelectLanguageToolStripMenuItem.Name = "SelectLanguageToolStripMenuItem"
        resources.ApplyResources(Me.SelectLanguageToolStripMenuItem, "SelectLanguageToolStripMenuItem")
        Me.SelectLanguageToolStripMenuItem.Tag = "Select_Language"
        '
        'GenerlSettingsToolStripMenuItem
        '
        Me.GenerlSettingsToolStripMenuItem.Name = "GenerlSettingsToolStripMenuItem"
        resources.ApplyResources(Me.GenerlSettingsToolStripMenuItem, "GenerlSettingsToolStripMenuItem")
        '
        'SequencerConfigurationToolStripMenuItem
        '
        Me.SequencerConfigurationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HourlyToolStripMenuItem, Me.DailyToolStripMenuItem})
        Me.SequencerConfigurationToolStripMenuItem.Name = "SequencerConfigurationToolStripMenuItem"
        resources.ApplyResources(Me.SequencerConfigurationToolStripMenuItem, "SequencerConfigurationToolStripMenuItem")
        '
        'HourlyToolStripMenuItem
        '
        Me.HourlyToolStripMenuItem.Name = "HourlyToolStripMenuItem"
        Me.HourlyToolStripMenuItem.Size = New System.Drawing.Size(119, 24)
        Me.HourlyToolStripMenuItem.Text = "Daily"
        '
        'DailyToolStripMenuItem
        '
        Me.DailyToolStripMenuItem.Name = "DailyToolStripMenuItem"
        Me.DailyToolStripMenuItem.Size = New System.Drawing.Size(119, 24)
        Me.DailyToolStripMenuItem.Text = "Hourly"
        '
        'FormHourlyTimeSelectionToolStripMenuItem
        '
        Me.FormHourlyTimeSelectionToolStripMenuItem.Name = "FormHourlyTimeSelectionToolStripMenuItem"
        resources.ApplyResources(Me.FormHourlyTimeSelectionToolStripMenuItem, "FormHourlyTimeSelectionToolStripMenuItem")
        '
        'AWSToolStripMenuItem
        '
        Me.AWSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AWSElementsToolStripMenuItem, Me.AWSStationsToolStripMenuItem})
        Me.AWSToolStripMenuItem.Name = "AWSToolStripMenuItem"
        Me.AWSToolStripMenuItem.Size = New System.Drawing.Size(242, 24)
        Me.AWSToolStripMenuItem.Text = "AWS"
        '
        'AWSElementsToolStripMenuItem
        '
        Me.AWSElementsToolStripMenuItem.Name = "AWSElementsToolStripMenuItem"
        Me.AWSElementsToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.AWSElementsToolStripMenuItem.Text = "AWS Elements"
        '
        'AWSStationsToolStripMenuItem
        '
        Me.AWSStationsToolStripMenuItem.Name = "AWSStationsToolStripMenuItem"
        Me.AWSStationsToolStripMenuItem.Size = New System.Drawing.Size(166, 24)
        Me.AWSStationsToolStripMenuItem.Text = "AWS Stations"
        '
        'mnuLanguageTranslation
        '
        Me.mnuLanguageTranslation.Name = "mnuLanguageTranslation"
        Me.mnuLanguageTranslation.Size = New System.Drawing.Size(152, 23)
        Me.mnuLanguageTranslation.Text = "Language Translation"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpContents, Me.mnuHelpAbout})
        Me.mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        Me.mnuHelp.Tag = "Help"
        '
        'mnuHelpContents
        '
        Me.mnuHelpContents.Name = "mnuHelpContents"
        resources.ApplyResources(Me.mnuHelpContents, "mnuHelpContents")
        Me.mnuHelpContents.Tag = "Contents"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        resources.ApplyResources(Me.mnuHelpAbout, "mnuHelpAbout")
        Me.mnuHelpAbout.Tag = "About"
        '
        'Panel1
        '
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
        Me.Panel1.Controls.Add(Me.cmdRedCloseButton)
        Me.Panel1.Controls.Add(Me.cmdSettingsAWS)
        Me.Panel1.Controls.Add(Me.cmdMetadata)
        Me.Panel1.Controls.Add(Me.cmdUserManagement)
        Me.Panel1.Controls.Add(Me.cmdProducts)
        Me.Panel1.Controls.Add(Me.cmdQC)
        Me.Panel1.Controls.Add(Me.cmdDataTransfer)
        Me.Panel1.Controls.Add(Me.cmdPaperArchive)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdKeyEntry)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(840, 521)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(388, 452)
        Me.Label5.Name = "Label5"
        Me.Label5.Tag = "Close"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(332, 7)
        Me.Label11.Name = "Label11"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(110, 436)
        Me.Label9.Name = "Label9"
        Me.Label9.Tag = "AWS_Real_Time_Processing"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(555, 431)
        Me.Label8.Name = "Label8"
        Me.Label8.Tag = "Metadata_Information"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(133, 324)
        Me.Label7.Name = "Label7"
        Me.Label7.Tag = "Users_Administration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(566, 323)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Tag = "Climate_Products"
        Me.Label6.Text = "Climate Products"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(551, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Tag = "Quality_Control_Checks"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(153, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Tag = "Data_Transfer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(556, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Tag = "Archive_Paper_Image"
        '
        'cmdRedCloseButton
        '
        resources.ApplyResources(Me.cmdRedCloseButton, "cmdRedCloseButton")
        Me.cmdRedCloseButton.FlatAppearance.BorderSize = 4
        Me.cmdRedCloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedCloseButton.Location = New System.Drawing.Point(368, 393)
        Me.cmdRedCloseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdRedCloseButton.Name = "cmdRedCloseButton"
        Me.cmdRedCloseButton.UseCompatibleTextRendering = True
        Me.cmdRedCloseButton.UseVisualStyleBackColor = True
        '
        'cmdSettingsAWS
        '
        resources.ApplyResources(Me.cmdSettingsAWS, "cmdSettingsAWS")
        Me.cmdSettingsAWS.FlatAppearance.BorderSize = 4
        Me.cmdSettingsAWS.ForeColor = System.Drawing.Color.Red
        Me.cmdSettingsAWS.Location = New System.Drawing.Point(135, 360)
        Me.cmdSettingsAWS.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSettingsAWS.Name = "cmdSettingsAWS"
        Me.cmdSettingsAWS.UseCompatibleTextRendering = True
        Me.cmdSettingsAWS.UseVisualStyleBackColor = True
        '
        'cmdMetadata
        '
        resources.ApplyResources(Me.cmdMetadata, "cmdMetadata")
        Me.cmdMetadata.FlatAppearance.BorderSize = 4
        Me.cmdMetadata.ForeColor = System.Drawing.Color.Red
        Me.cmdMetadata.Location = New System.Drawing.Point(558, 355)
        Me.cmdMetadata.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMetadata.Name = "cmdMetadata"
        Me.cmdMetadata.UseCompatibleTextRendering = True
        Me.cmdMetadata.UseVisualStyleBackColor = True
        '
        'cmdUserManagement
        '
        resources.ApplyResources(Me.cmdUserManagement, "cmdUserManagement")
        Me.cmdUserManagement.FlatAppearance.BorderSize = 4
        Me.cmdUserManagement.ForeColor = System.Drawing.Color.Red
        Me.cmdUserManagement.Location = New System.Drawing.Point(135, 248)
        Me.cmdUserManagement.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdUserManagement.Name = "cmdUserManagement"
        Me.cmdUserManagement.UseCompatibleTextRendering = True
        Me.cmdUserManagement.UseVisualStyleBackColor = True
        '
        'cmdProducts
        '
        resources.ApplyResources(Me.cmdProducts, "cmdProducts")
        Me.cmdProducts.FlatAppearance.BorderSize = 4
        Me.cmdProducts.ForeColor = System.Drawing.Color.Red
        Me.cmdProducts.Location = New System.Drawing.Point(558, 247)
        Me.cmdProducts.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdProducts.Name = "cmdProducts"
        Me.cmdProducts.UseCompatibleTextRendering = True
        Me.cmdProducts.UseVisualStyleBackColor = True
        '
        'cmdQC
        '
        resources.ApplyResources(Me.cmdQC, "cmdQC")
        Me.cmdQC.FlatAppearance.BorderSize = 4
        Me.cmdQC.ForeColor = System.Drawing.Color.Red
        Me.cmdQC.Location = New System.Drawing.Point(559, 143)
        Me.cmdQC.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdQC.Name = "cmdQC"
        Me.cmdQC.UseCompatibleTextRendering = True
        Me.cmdQC.UseVisualStyleBackColor = True
        '
        'cmdDataTransfer
        '
        resources.ApplyResources(Me.cmdDataTransfer, "cmdDataTransfer")
        Me.cmdDataTransfer.FlatAppearance.BorderSize = 4
        Me.cmdDataTransfer.ForeColor = System.Drawing.Color.Red
        Me.cmdDataTransfer.Location = New System.Drawing.Point(135, 143)
        Me.cmdDataTransfer.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdDataTransfer.Name = "cmdDataTransfer"
        Me.cmdDataTransfer.UseCompatibleTextRendering = True
        Me.cmdDataTransfer.UseVisualStyleBackColor = True
        '
        'cmdPaperArchive
        '
        resources.ApplyResources(Me.cmdPaperArchive, "cmdPaperArchive")
        Me.cmdPaperArchive.FlatAppearance.BorderSize = 4
        Me.cmdPaperArchive.ForeColor = System.Drawing.Color.Red
        Me.cmdPaperArchive.Location = New System.Drawing.Point(559, 28)
        Me.cmdPaperArchive.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdPaperArchive.Name = "cmdPaperArchive"
        Me.cmdPaperArchive.UseCompatibleTextRendering = True
        Me.cmdPaperArchive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(163, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Tag = "Data_Entry"
        '
        'cmdKeyEntry
        '
        Me.cmdKeyEntry.AutoEllipsis = True
        resources.ApplyResources(Me.cmdKeyEntry, "cmdKeyEntry")
        Me.cmdKeyEntry.FlatAppearance.BorderSize = 10
        Me.cmdKeyEntry.ForeColor = System.Drawing.Color.Red
        Me.cmdKeyEntry.Location = New System.Drawing.Point(135, 37)
        Me.cmdKeyEntry.Name = "cmdKeyEntry"
        Me.cmdKeyEntry.UseVisualStyleBackColor = True
        '
        'StandardProductsToolStripMenuItem
        '
        Me.StandardProductsToolStripMenuItem.Name = "StandardProductsToolStripMenuItem"
        resources.ApplyResources(Me.StandardProductsToolStripMenuItem, "StandardProductsToolStripMenuItem")
        '
        'RProductsToolStripMenuItem
        '
        Me.RProductsToolStripMenuItem.Name = "RProductsToolStripMenuItem"
        resources.ApplyResources(Me.RProductsToolStripMenuItem, "RProductsToolStripMenuItem")
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(849, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.Name = "frmMainMenu"
        Me.Tag = "Main_Menu"
        Me.Controls.SetChildIndex(Me.MenuStrip2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
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
    Friend WithEvents cmdRedCloseButton As System.Windows.Forms.Button
    Friend WithEvents cmdSettingsAWS As System.Windows.Forms.Button
    Friend WithEvents cmdMetadata As System.Windows.Forms.Button
    Friend WithEvents cmdUserManagement As System.Windows.Forms.Button
    Friend WithEvents cmdProducts As System.Windows.Forms.Button
    Friend WithEvents cmdQC As System.Windows.Forms.Button
    Friend WithEvents cmdDataTransfer As System.Windows.Forms.Button
    Friend WithEvents cmdPaperArchive As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdKeyEntry As System.Windows.Forms.Button
    Friend WithEvents SelectLanguageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GenerlSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SequencerConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HourlyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DailyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FormHourlyTimeSelectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeOwnPasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConfigureDatabaseConnectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLanguageTranslation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSElementsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AWSStationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
