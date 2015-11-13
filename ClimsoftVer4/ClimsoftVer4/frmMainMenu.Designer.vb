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
        Me.mnuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToolsModifyForms = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectLanguageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.MenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AllowItemReorder = True
        Me.MenuStrip2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInput, Me.mnuAccessories, Me.mnuQC, Me.mnuProducts, Me.mnuAdministration, Me.mnuTools, Me.mnuHelp})
        Me.MenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.ShowItemToolTips = True
        Me.MenuStrip2.Size = New System.Drawing.Size(784, 27)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
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
        Me.mnuAccessories.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAccessoriesDewPointRH, Me.mnuAccessoriesXMLOutput})
        Me.mnuAccessories.Name = "mnuAccessories"
        Me.mnuAccessories.Size = New System.Drawing.Size(90, 23)
        Me.mnuAccessories.Tag = "Accessories"
        Me.mnuAccessories.Text = "Accessories"
        '
        'mnuAccessoriesDewPointRH
        '
        Me.mnuAccessoriesDewPointRH.Name = "mnuAccessoriesDewPointRH"
        Me.mnuAccessoriesDewPointRH.Size = New System.Drawing.Size(275, 24)
        Me.mnuAccessoriesDewPointRH.Tag = "Calculation_of_dew_Point_and_RH"
        Me.mnuAccessoriesDewPointRH.Text = "Calculation of dew Point and RH"
        '
        'mnuAccessoriesXMLOutput
        '
        Me.mnuAccessoriesXMLOutput.Name = "mnuAccessoriesXMLOutput"
        Me.mnuAccessoriesXMLOutput.Size = New System.Drawing.Size(275, 24)
        Me.mnuAccessoriesXMLOutput.Tag = "Generate_XML_Output"
        Me.mnuAccessoriesXMLOutput.Text = "Generate XML Output"
        '
        'mnuQC
        '
        Me.mnuQC.Name = "mnuQC"
        Me.mnuQC.Size = New System.Drawing.Size(41, 23)
        Me.mnuQC.Tag = "QC"
        Me.mnuQC.Text = "QC"
        '
        'mnuProducts
        '
        Me.mnuProducts.Name = "mnuProducts"
        Me.mnuProducts.Size = New System.Drawing.Size(75, 23)
        Me.mnuProducts.Tag = "Products"
        Me.mnuProducts.Text = "Products"
        '
        'mnuAdministration
        '
        Me.mnuAdministration.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserAdminToolStripMenuItem, Me.MetadataToolStripMenuItem, Me.PasswordToolStripMenuItem, Me.DataFormsToolStripMenuItem, Me.UpdateElementsToolStripMenuItem})
        Me.mnuAdministration.Name = "mnuAdministration"
        Me.mnuAdministration.Size = New System.Drawing.Size(111, 23)
        Me.mnuAdministration.Tag = "Administration"
        Me.mnuAdministration.Text = "Administration"
        '
        'UserAdminToolStripMenuItem
        '
        Me.UserAdminToolStripMenuItem.Name = "UserAdminToolStripMenuItem"
        Me.UserAdminToolStripMenuItem.Size = New System.Drawing.Size(216, 24)
        Me.UserAdminToolStripMenuItem.Tag = "User_Admin"
        Me.UserAdminToolStripMenuItem.Text = "User Admin"
        '
        'MetadataToolStripMenuItem
        '
        Me.MetadataToolStripMenuItem.Name = "MetadataToolStripMenuItem"
        Me.MetadataToolStripMenuItem.Size = New System.Drawing.Size(216, 24)
        Me.MetadataToolStripMenuItem.Tag = "Metadata"
        Me.MetadataToolStripMenuItem.Text = "Metadata"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(216, 24)
        Me.PasswordToolStripMenuItem.Text = "Password"
        '
        'DataFormsToolStripMenuItem
        '
        Me.DataFormsToolStripMenuItem.Name = "DataFormsToolStripMenuItem"
        Me.DataFormsToolStripMenuItem.Size = New System.Drawing.Size(216, 24)
        Me.DataFormsToolStripMenuItem.Tag = "Data_Forms"
        Me.DataFormsToolStripMenuItem.Text = "Data Forms"
        '
        'UpdateElementsToolStripMenuItem
        '
        Me.UpdateElementsToolStripMenuItem.Name = "UpdateElementsToolStripMenuItem"
        Me.UpdateElementsToolStripMenuItem.Size = New System.Drawing.Size(216, 24)
        Me.UpdateElementsToolStripMenuItem.Tag = "Update_Element_Limits"
        Me.UpdateElementsToolStripMenuItem.Text = "Update Element Limits"
        '
        'mnuTools
        '
        Me.mnuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToolsOptions, Me.mnuToolsModifyForms, Me.SelectLanguageToolStripMenuItem})
        Me.mnuTools.Name = "mnuTools"
        Me.mnuTools.Size = New System.Drawing.Size(53, 23)
        Me.mnuTools.Tag = "Tools"
        Me.mnuTools.Text = "Tools"
        '
        'mnuToolsOptions
        '
        Me.mnuToolsOptions.Name = "mnuToolsOptions"
        Me.mnuToolsOptions.Size = New System.Drawing.Size(177, 24)
        Me.mnuToolsOptions.Tag = "Options"
        Me.mnuToolsOptions.Text = "Options"
        '
        'mnuToolsModifyForms
        '
        Me.mnuToolsModifyForms.Name = "mnuToolsModifyForms"
        Me.mnuToolsModifyForms.Size = New System.Drawing.Size(177, 24)
        Me.mnuToolsModifyForms.Tag = "Modify_Forms"
        Me.mnuToolsModifyForms.Text = "Modify Forms"
        '
        'SelectLanguageToolStripMenuItem
        '
        Me.SelectLanguageToolStripMenuItem.Name = "SelectLanguageToolStripMenuItem"
        Me.SelectLanguageToolStripMenuItem.Size = New System.Drawing.Size(177, 24)
        Me.SelectLanguageToolStripMenuItem.Tag = "Select_Language"
        Me.SelectLanguageToolStripMenuItem.Text = "Select Language"
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
        Me.mnuHelpContents.Size = New System.Drawing.Size(134, 24)
        Me.mnuHelpContents.Tag = "Contents"
        Me.mnuHelpContents.Text = "Contents"
        '
        'mnuHelpAbout
        '
        Me.mnuHelpAbout.Name = "mnuHelpAbout"
        Me.mnuHelpAbout.Size = New System.Drawing.Size(134, 24)
        Me.mnuHelpAbout.Tag = "About"
        Me.mnuHelpAbout.Text = "About"
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
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0, 3, 3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 521)
        Me.Panel1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(208, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 36
        Me.Label5.Tag = "Close"
        Me.Label5.Text = "Close CLIMSOFT"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(207, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 25)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Welcome"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 434)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(176, 16)
        Me.Label9.TabIndex = 33
        Me.Label9.Tag = "AWS_Real_Time_Processing"
        Me.Label9.Text = "AWS Real Time Processing"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(359, 429)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 16)
        Me.Label8.TabIndex = 32
        Me.Label8.Tag = "Metadata_Information"
        Me.Label8.Text = "Metadata Information"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 322)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 16)
        Me.Label7.TabIndex = 31
        Me.Label7.Tag = "Users_Administration"
        Me.Label7.Text = "Users Administration"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(351, 321)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 16)
        Me.Label6.TabIndex = 30
        Me.Label6.Tag = "Climate_Data_Products"
        Me.Label6.Text = "Climate Data Products"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(357, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 16)
        Me.Label4.TabIndex = 28
        Me.Label4.Tag = "Quality_Control_Checks"
        Me.Label4.Text = "Quality Control Checks"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Tag = "Data_Transfer_Operations"
        Me.Label3.Text = "Database Utilities"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(358, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Tag = "Archive_Paper_Image"
        Me.Label2.Text = "Archive Paper Image"
        '
        'cmdRedCloseButton
        '
        Me.cmdRedCloseButton.BackgroundImage = CType(resources.GetObject("cmdRedCloseButton.BackgroundImage"), System.Drawing.Image)
        Me.cmdRedCloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdRedCloseButton.FlatAppearance.BorderSize = 4
        Me.cmdRedCloseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRedCloseButton.Location = New System.Drawing.Point(224, 429)
        Me.cmdRedCloseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdRedCloseButton.Name = "cmdRedCloseButton"
        Me.cmdRedCloseButton.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdRedCloseButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRedCloseButton.Size = New System.Drawing.Size(83, 59)
        Me.cmdRedCloseButton.TabIndex = 25
        Me.cmdRedCloseButton.UseCompatibleTextRendering = True
        Me.cmdRedCloseButton.UseVisualStyleBackColor = True
        '
        'cmdSettingsAWS
        '
        Me.cmdSettingsAWS.BackgroundImage = CType(resources.GetObject("cmdSettingsAWS.BackgroundImage"), System.Drawing.Image)
        Me.cmdSettingsAWS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdSettingsAWS.FlatAppearance.BorderSize = 4
        Me.cmdSettingsAWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSettingsAWS.ForeColor = System.Drawing.Color.Red
        Me.cmdSettingsAWS.Location = New System.Drawing.Point(35, 358)
        Me.cmdSettingsAWS.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSettingsAWS.Name = "cmdSettingsAWS"
        Me.cmdSettingsAWS.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdSettingsAWS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSettingsAWS.Size = New System.Drawing.Size(126, 76)
        Me.cmdSettingsAWS.TabIndex = 24
        Me.cmdSettingsAWS.UseCompatibleTextRendering = True
        Me.cmdSettingsAWS.UseVisualStyleBackColor = True
        '
        'cmdMetadata
        '
        Me.cmdMetadata.BackgroundImage = CType(resources.GetObject("cmdMetadata.BackgroundImage"), System.Drawing.Image)
        Me.cmdMetadata.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdMetadata.FlatAppearance.BorderSize = 4
        Me.cmdMetadata.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMetadata.ForeColor = System.Drawing.Color.Red
        Me.cmdMetadata.Location = New System.Drawing.Point(360, 353)
        Me.cmdMetadata.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdMetadata.Name = "cmdMetadata"
        Me.cmdMetadata.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdMetadata.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMetadata.Size = New System.Drawing.Size(126, 76)
        Me.cmdMetadata.TabIndex = 23
        Me.cmdMetadata.UseCompatibleTextRendering = True
        Me.cmdMetadata.UseVisualStyleBackColor = True
        '
        'cmdUserManagement
        '
        Me.cmdUserManagement.BackgroundImage = CType(resources.GetObject("cmdUserManagement.BackgroundImage"), System.Drawing.Image)
        Me.cmdUserManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdUserManagement.FlatAppearance.BorderSize = 4
        Me.cmdUserManagement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUserManagement.ForeColor = System.Drawing.Color.Red
        Me.cmdUserManagement.Location = New System.Drawing.Point(35, 246)
        Me.cmdUserManagement.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdUserManagement.Name = "cmdUserManagement"
        Me.cmdUserManagement.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdUserManagement.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUserManagement.Size = New System.Drawing.Size(126, 76)
        Me.cmdUserManagement.TabIndex = 22
        Me.cmdUserManagement.UseCompatibleTextRendering = True
        Me.cmdUserManagement.UseVisualStyleBackColor = True
        '
        'cmdProducts
        '
        Me.cmdProducts.BackgroundImage = CType(resources.GetObject("cmdProducts.BackgroundImage"), System.Drawing.Image)
        Me.cmdProducts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdProducts.FlatAppearance.BorderSize = 4
        Me.cmdProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProducts.ForeColor = System.Drawing.Color.Red
        Me.cmdProducts.Location = New System.Drawing.Point(360, 245)
        Me.cmdProducts.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdProducts.Name = "cmdProducts"
        Me.cmdProducts.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdProducts.Size = New System.Drawing.Size(126, 76)
        Me.cmdProducts.TabIndex = 21
        Me.cmdProducts.UseCompatibleTextRendering = True
        Me.cmdProducts.UseVisualStyleBackColor = True
        '
        'cmdQC
        '
        Me.cmdQC.BackgroundImage = CType(resources.GetObject("cmdQC.BackgroundImage"), System.Drawing.Image)
        Me.cmdQC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdQC.FlatAppearance.BorderSize = 4
        Me.cmdQC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQC.ForeColor = System.Drawing.Color.Red
        Me.cmdQC.Location = New System.Drawing.Point(361, 141)
        Me.cmdQC.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdQC.Name = "cmdQC"
        Me.cmdQC.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdQC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdQC.Size = New System.Drawing.Size(126, 76)
        Me.cmdQC.TabIndex = 20
        Me.cmdQC.UseCompatibleTextRendering = True
        Me.cmdQC.UseVisualStyleBackColor = True
        '
        'cmdDataTransfer
        '
        Me.cmdDataTransfer.BackgroundImage = CType(resources.GetObject("cmdDataTransfer.BackgroundImage"), System.Drawing.Image)
        Me.cmdDataTransfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdDataTransfer.FlatAppearance.BorderSize = 4
        Me.cmdDataTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDataTransfer.ForeColor = System.Drawing.Color.Red
        Me.cmdDataTransfer.Location = New System.Drawing.Point(35, 141)
        Me.cmdDataTransfer.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdDataTransfer.Name = "cmdDataTransfer"
        Me.cmdDataTransfer.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdDataTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDataTransfer.Size = New System.Drawing.Size(126, 76)
        Me.cmdDataTransfer.TabIndex = 19
        Me.cmdDataTransfer.UseCompatibleTextRendering = True
        Me.cmdDataTransfer.UseVisualStyleBackColor = True
        '
        'cmdPaperArchive
        '
        Me.cmdPaperArchive.BackgroundImage = CType(resources.GetObject("cmdPaperArchive.BackgroundImage"), System.Drawing.Image)
        Me.cmdPaperArchive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPaperArchive.FlatAppearance.BorderSize = 4
        Me.cmdPaperArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPaperArchive.ForeColor = System.Drawing.Color.Red
        Me.cmdPaperArchive.Location = New System.Drawing.Point(361, 26)
        Me.cmdPaperArchive.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdPaperArchive.Name = "cmdPaperArchive"
        Me.cmdPaperArchive.Padding = New System.Windows.Forms.Padding(5)
        Me.cmdPaperArchive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPaperArchive.Size = New System.Drawing.Size(126, 76)
        Me.cmdPaperArchive.TabIndex = 5
        Me.cmdPaperArchive.UseCompatibleTextRendering = True
        Me.cmdPaperArchive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(70, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = "Data_Entry"
        Me.Label1.Text = "Data Entry"
        '
        'cmdKeyEntry
        '
        Me.cmdKeyEntry.AutoEllipsis = True
        Me.cmdKeyEntry.BackgroundImage = CType(resources.GetObject("cmdKeyEntry.BackgroundImage"), System.Drawing.Image)
        Me.cmdKeyEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdKeyEntry.FlatAppearance.BorderSize = 10
        Me.cmdKeyEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdKeyEntry.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyEntry.ForeColor = System.Drawing.Color.Red
        Me.cmdKeyEntry.Location = New System.Drawing.Point(35, 35)
        Me.cmdKeyEntry.Name = "cmdKeyEntry"
        Me.cmdKeyEntry.Size = New System.Drawing.Size(126, 76)
        Me.cmdKeyEntry.TabIndex = 3
        Me.cmdKeyEntry.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdKeyEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdKeyEntry.UseVisualStyleBackColor = True
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(784, 548)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.IsMdiContainer = True
        Me.Name = "frmMainMenu"
        Me.Tag = "Main_Menu"
        Me.Text = "Main Menu"
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
    Friend WithEvents mnuToolsOptions As System.Windows.Forms.ToolStripMenuItem
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
End Class
