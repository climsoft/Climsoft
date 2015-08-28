<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formPaperArchive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formPaperArchive))
        Me.tabImageArchives = New System.Windows.Forms.TabControl()
        Me.tabStructured = New System.Windows.Forms.TabPage()
        Me.grpInformation = New System.Windows.Forms.GroupBox()
        Me.lblStnFormyyyymmddhh = New System.Windows.Forms.Label()
        Me.lblFileStructure = New System.Windows.Forms.Label()
        Me.chkFiles = New System.Windows.Forms.CheckBox()
        Me.grpComands = New System.Windows.Forms.GroupBox()
        Me.cmdArchive = New System.Windows.Forms.Button()
        Me.lstvFiles = New System.Windows.Forms.ListView()
        Me.cmdFolder = New System.Windows.Forms.Button()
        Me.lblImageFiles = New System.Windows.Forms.Label()
        Me.lblSelectedFolder = New System.Windows.Forms.Label()
        Me.txtSelectedFolder = New System.Windows.Forms.TextBox()
        Me.tabUnstructured = New System.Windows.Forms.TabPage()
        Me.pnlUnstructuredNames = New System.Windows.Forms.Panel()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdArchiveUnstructure = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdImageFile = New System.Windows.Forms.Button()
        Me.lblImageFile = New System.Windows.Forms.Label()
        Me.txtImageFile = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHour = New System.Windows.Forms.ComboBox()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblday = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.txtDay = New System.Windows.Forms.ComboBox()
        Me.txtMonth = New System.Windows.Forms.ComboBox()
        Me.txtStationArchive = New System.Windows.Forms.ComboBox()
        Me.txtFormId = New System.Windows.Forms.TextBox()
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.TabViewArchive = New System.Windows.Forms.TabPage()
        Me.grpImage = New System.Windows.Forms.GroupBox()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.txtHH = New System.Windows.Forms.TextBox()
        Me.txtDD = New System.Windows.Forms.TextBox()
        Me.txtMM = New System.Windows.Forms.TextBox()
        Me.txtYY = New System.Windows.Forms.TextBox()
        Me.txtForm = New System.Windows.Forms.ComboBox()
        Me.txtStation = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuPaperArchive = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.folderPaperArchive = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFilePaperArchive = New System.Windows.Forms.OpenFileDialog()
        Me.tabImageArchives.SuspendLayout()
        Me.tabStructured.SuspendLayout()
        Me.grpInformation.SuspendLayout()
        Me.grpComands.SuspendLayout()
        Me.tabUnstructured.SuspendLayout()
        Me.pnlUnstructuredNames.SuspendLayout()
        Me.TabViewArchive.SuspendLayout()
        Me.grpImage.SuspendLayout()
        Me.MenuPaperArchive.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabImageArchives
        '
        Me.tabImageArchives.Controls.Add(Me.tabStructured)
        Me.tabImageArchives.Controls.Add(Me.tabUnstructured)
        Me.tabImageArchives.Controls.Add(Me.TabViewArchive)
        Me.tabImageArchives.Location = New System.Drawing.Point(10, 27)
        Me.tabImageArchives.Name = "tabImageArchives"
        Me.tabImageArchives.SelectedIndex = 0
        Me.tabImageArchives.Size = New System.Drawing.Size(660, 477)
        Me.tabImageArchives.TabIndex = 2
        '
        'tabStructured
        '
        Me.tabStructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabStructured.Controls.Add(Me.grpInformation)
        Me.tabStructured.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStructured.Location = New System.Drawing.Point(4, 22)
        Me.tabStructured.Name = "tabStructured"
        Me.tabStructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStructured.Size = New System.Drawing.Size(652, 451)
        Me.tabStructured.TabIndex = 0
        Me.tabStructured.Text = "Structured Filenames"
        Me.tabStructured.UseVisualStyleBackColor = True
        '
        'grpInformation
        '
        Me.grpInformation.Controls.Add(Me.lblStnFormyyyymmddhh)
        Me.grpInformation.Controls.Add(Me.lblFileStructure)
        Me.grpInformation.Controls.Add(Me.chkFiles)
        Me.grpInformation.Controls.Add(Me.grpComands)
        Me.grpInformation.Controls.Add(Me.lstvFiles)
        Me.grpInformation.Controls.Add(Me.cmdFolder)
        Me.grpInformation.Controls.Add(Me.lblImageFiles)
        Me.grpInformation.Controls.Add(Me.lblSelectedFolder)
        Me.grpInformation.Controls.Add(Me.txtSelectedFolder)
        Me.grpInformation.Location = New System.Drawing.Point(22, 6)
        Me.grpInformation.Name = "grpInformation"
        Me.grpInformation.Size = New System.Drawing.Size(602, 437)
        Me.grpInformation.TabIndex = 3
        Me.grpInformation.TabStop = False
        Me.grpInformation.Text = "Image Files"
        '
        'lblStnFormyyyymmddhh
        '
        Me.lblStnFormyyyymmddhh.AutoSize = True
        Me.lblStnFormyyyymmddhh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStnFormyyyymmddhh.Location = New System.Drawing.Point(101, 25)
        Me.lblStnFormyyyymmddhh.Name = "lblStnFormyyyymmddhh"
        Me.lblStnFormyyyymmddhh.Size = New System.Drawing.Size(175, 13)
        Me.lblStnFormyyyymmddhh.TabIndex = 21
        Me.lblStnFormyyyymmddhh.Text = "StnID-FormID-YYYYMMDDHH"
        '
        'lblFileStructure
        '
        Me.lblFileStructure.AutoSize = True
        Me.lblFileStructure.Location = New System.Drawing.Point(6, 25)
        Me.lblFileStructure.Name = "lblFileStructure"
        Me.lblFileStructure.Size = New System.Drawing.Size(69, 13)
        Me.lblFileStructure.TabIndex = 20
        Me.lblFileStructure.Text = "File Structure"
        '
        'chkFiles
        '
        Me.chkFiles.AutoSize = True
        Me.chkFiles.Checked = True
        Me.chkFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFiles.Location = New System.Drawing.Point(104, 378)
        Me.chkFiles.Name = "chkFiles"
        Me.chkFiles.Size = New System.Drawing.Size(82, 17)
        Me.chkFiles.TabIndex = 19
        Me.chkFiles.Text = "Unselect All"
        Me.chkFiles.UseVisualStyleBackColor = True
        Me.chkFiles.Visible = False
        '
        'grpComands
        '
        Me.grpComands.Controls.Add(Me.cmdArchive)
        Me.grpComands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpComands.Location = New System.Drawing.Point(3, 403)
        Me.grpComands.Name = "grpComands"
        Me.grpComands.Size = New System.Drawing.Size(596, 31)
        Me.grpComands.TabIndex = 18
        Me.grpComands.TabStop = False
        '
        'cmdArchive
        '
        Me.cmdArchive.Enabled = False
        Me.cmdArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArchive.Location = New System.Drawing.Point(257, 5)
        Me.cmdArchive.Name = "cmdArchive"
        Me.cmdArchive.Size = New System.Drawing.Size(83, 25)
        Me.cmdArchive.TabIndex = 7
        Me.cmdArchive.Text = "Archive"
        Me.cmdArchive.UseVisualStyleBackColor = True
        '
        'lstvFiles
        '
        Me.lstvFiles.AllowColumnReorder = True
        Me.lstvFiles.AllowDrop = True
        Me.lstvFiles.CheckBoxes = True
        Me.lstvFiles.FullRowSelect = True
        Me.lstvFiles.GridLines = True
        Me.lstvFiles.HideSelection = False
        Me.lstvFiles.HoverSelection = True
        Me.lstvFiles.LabelEdit = True
        Me.lstvFiles.Location = New System.Drawing.Point(104, 96)
        Me.lstvFiles.Name = "lstvFiles"
        Me.lstvFiles.RightToLeftLayout = True
        Me.lstvFiles.Size = New System.Drawing.Size(423, 280)
        Me.lstvFiles.TabIndex = 17
        Me.lstvFiles.UseCompatibleStateImageBehavior = False
        Me.lstvFiles.View = System.Windows.Forms.View.Details
        '
        'cmdFolder
        '
        Me.cmdFolder.BackgroundImage = CType(resources.GetObject("cmdFolder.BackgroundImage"), System.Drawing.Image)
        Me.cmdFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFolder.Location = New System.Drawing.Point(492, 52)
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.Size = New System.Drawing.Size(35, 26)
        Me.cmdFolder.TabIndex = 16
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'lblImageFiles
        '
        Me.lblImageFiles.AutoSize = True
        Me.lblImageFiles.Location = New System.Drawing.Point(270, 81)
        Me.lblImageFiles.Name = "lblImageFiles"
        Me.lblImageFiles.Size = New System.Drawing.Size(60, 13)
        Me.lblImageFiles.TabIndex = 2
        Me.lblImageFiles.Text = "Image Files"
        '
        'lblSelectedFolder
        '
        Me.lblSelectedFolder.AutoSize = True
        Me.lblSelectedFolder.Location = New System.Drawing.Point(6, 59)
        Me.lblSelectedFolder.Name = "lblSelectedFolder"
        Me.lblSelectedFolder.Size = New System.Drawing.Size(97, 13)
        Me.lblSelectedFolder.TabIndex = 1
        Me.lblSelectedFolder.Text = "Open Image Folder"
        '
        'txtSelectedFolder
        '
        Me.txtSelectedFolder.BackColor = System.Drawing.Color.Snow
        Me.txtSelectedFolder.Location = New System.Drawing.Point(104, 55)
        Me.txtSelectedFolder.Name = "txtSelectedFolder"
        Me.txtSelectedFolder.Size = New System.Drawing.Size(390, 20)
        Me.txtSelectedFolder.TabIndex = 0
        '
        'tabUnstructured
        '
        Me.tabUnstructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnstructured.Controls.Add(Me.pnlUnstructuredNames)
        Me.tabUnstructured.Location = New System.Drawing.Point(4, 22)
        Me.tabUnstructured.Name = "tabUnstructured"
        Me.tabUnstructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnstructured.Size = New System.Drawing.Size(652, 451)
        Me.tabUnstructured.TabIndex = 1
        Me.tabUnstructured.Text = "Unstructured Filenames"
        Me.tabUnstructured.UseVisualStyleBackColor = True
        '
        'pnlUnstructuredNames
        '
        Me.pnlUnstructuredNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUnstructuredNames.Controls.Add(Me.txtYear)
        Me.pnlUnstructuredNames.Controls.Add(Me.Button3)
        Me.pnlUnstructuredNames.Controls.Add(Me.Button2)
        Me.pnlUnstructuredNames.Controls.Add(Me.cmdArchiveUnstructure)
        Me.pnlUnstructuredNames.Controls.Add(Me.CheckBox1)
        Me.pnlUnstructuredNames.Controls.Add(Me.cmdImageFile)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblImageFile)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtImageFile)
        Me.pnlUnstructuredNames.Controls.Add(Me.Label5)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtHour)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblHour)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblday)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblMonth)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblYear)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtDay)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtMonth)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtStationArchive)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtFormId)
        Me.pnlUnstructuredNames.Controls.Add(Me.lblStationId)
        Me.pnlUnstructuredNames.Location = New System.Drawing.Point(43, 66)
        Me.pnlUnstructuredNames.Name = "pnlUnstructuredNames"
        Me.pnlUnstructuredNames.Size = New System.Drawing.Size(564, 302)
        Me.pnlUnstructuredNames.TabIndex = 0
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(67, 56)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(41, 20)
        Me.txtYear.TabIndex = 19
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(386, 254)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 25)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(230, 254)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 25)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdArchiveUnstructure
        '
        Me.cmdArchiveUnstructure.Location = New System.Drawing.Point(74, 254)
        Me.cmdArchiveUnstructure.Name = "cmdArchiveUnstructure"
        Me.cmdArchiveUnstructure.Size = New System.Drawing.Size(88, 25)
        Me.cmdArchiveUnstructure.TabIndex = 16
        Me.cmdArchiveUnstructure.Text = "Archive"
        Me.cmdArchiveUnstructure.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(36, 225)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(126, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Restructure Filename"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'cmdImageFile
        '
        Me.cmdImageFile.BackgroundImage = CType(resources.GetObject("cmdImageFile.BackgroundImage"), System.Drawing.Image)
        Me.cmdImageFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdImageFile.Location = New System.Drawing.Point(519, 187)
        Me.cmdImageFile.Name = "cmdImageFile"
        Me.cmdImageFile.Size = New System.Drawing.Size(30, 26)
        Me.cmdImageFile.TabIndex = 14
        Me.cmdImageFile.UseVisualStyleBackColor = True
        '
        'lblImageFile
        '
        Me.lblImageFile.AutoSize = True
        Me.lblImageFile.Location = New System.Drawing.Point(12, 194)
        Me.lblImageFile.Name = "lblImageFile"
        Me.lblImageFile.Size = New System.Drawing.Size(55, 13)
        Me.lblImageFile.TabIndex = 13
        Me.lblImageFile.Text = "Image File"
        '
        'txtImageFile
        '
        Me.txtImageFile.Location = New System.Drawing.Point(67, 190)
        Me.txtImageFile.Name = "txtImageFile"
        Me.txtImageFile.Size = New System.Drawing.Size(456, 20)
        Me.txtImageFile.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(351, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Form ID"
        '
        'txtHour
        '
        Me.txtHour.FormattingEnabled = True
        Me.txtHour.Location = New System.Drawing.Point(67, 157)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(41, 21)
        Me.txtHour.TabIndex = 10
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(12, 161)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(30, 13)
        Me.lblHour.TabIndex = 9
        Me.lblHour.Text = "Hour"
        '
        'lblday
        '
        Me.lblday.AutoSize = True
        Me.lblday.Location = New System.Drawing.Point(12, 127)
        Me.lblday.Name = "lblday"
        Me.lblday.Size = New System.Drawing.Size(26, 13)
        Me.lblday.TabIndex = 8
        Me.lblday.Text = "Day"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(12, 93)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 7
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(12, 60)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 6
        Me.lblYear.Text = "Year"
        '
        'txtDay
        '
        Me.txtDay.FormattingEnabled = True
        Me.txtDay.Location = New System.Drawing.Point(67, 123)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(41, 21)
        Me.txtDay.TabIndex = 5
        '
        'txtMonth
        '
        Me.txtMonth.FormattingEnabled = True
        Me.txtMonth.Location = New System.Drawing.Point(67, 89)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(41, 21)
        Me.txtMonth.TabIndex = 4
        '
        'txtStationArchive
        '
        Me.txtStationArchive.FormattingEnabled = True
        Me.txtStationArchive.Location = New System.Drawing.Point(67, 22)
        Me.txtStationArchive.Name = "txtStationArchive"
        Me.txtStationArchive.Size = New System.Drawing.Size(210, 21)
        Me.txtStationArchive.TabIndex = 2
        '
        'txtFormId
        '
        Me.txtFormId.Location = New System.Drawing.Point(400, 22)
        Me.txtFormId.Name = "txtFormId"
        Me.txtFormId.Size = New System.Drawing.Size(149, 20)
        Me.txtFormId.TabIndex = 1
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(12, 26)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(51, 13)
        Me.lblStationId.TabIndex = 0
        Me.lblStationId.Text = "StationID"
        '
        'TabViewArchive
        '
        Me.TabViewArchive.Controls.Add(Me.grpImage)
        Me.TabViewArchive.Location = New System.Drawing.Point(4, 22)
        Me.TabViewArchive.Name = "TabViewArchive"
        Me.TabViewArchive.Padding = New System.Windows.Forms.Padding(3)
        Me.TabViewArchive.Size = New System.Drawing.Size(652, 451)
        Me.TabViewArchive.TabIndex = 2
        Me.TabViewArchive.Text = "View Archived Image"
        Me.TabViewArchive.UseVisualStyleBackColor = True
        '
        'grpImage
        '
        Me.grpImage.Controls.Add(Me.cmdView)
        Me.grpImage.Controls.Add(Me.txtHH)
        Me.grpImage.Controls.Add(Me.txtDD)
        Me.grpImage.Controls.Add(Me.txtMM)
        Me.grpImage.Controls.Add(Me.txtYY)
        Me.grpImage.Controls.Add(Me.txtForm)
        Me.grpImage.Controls.Add(Me.txtStation)
        Me.grpImage.Controls.Add(Me.Label8)
        Me.grpImage.Controls.Add(Me.Label7)
        Me.grpImage.Controls.Add(Me.Label6)
        Me.grpImage.Controls.Add(Me.Label4)
        Me.grpImage.Controls.Add(Me.Label3)
        Me.grpImage.Controls.Add(Me.Label2)
        Me.grpImage.Location = New System.Drawing.Point(65, 71)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.Size = New System.Drawing.Size(527, 267)
        Me.grpImage.TabIndex = 0
        Me.grpImage.TabStop = False
        Me.grpImage.Text = "Image Details"
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(204, 213)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(92, 33)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View Image"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'txtHH
        '
        Me.txtHH.Location = New System.Drawing.Point(93, 189)
        Me.txtHH.Name = "txtHH"
        Me.txtHH.Size = New System.Drawing.Size(43, 20)
        Me.txtHH.TabIndex = 11
        '
        'txtDD
        '
        Me.txtDD.Location = New System.Drawing.Point(93, 159)
        Me.txtDD.Name = "txtDD"
        Me.txtDD.Size = New System.Drawing.Size(43, 20)
        Me.txtDD.TabIndex = 10
        '
        'txtMM
        '
        Me.txtMM.Location = New System.Drawing.Point(93, 129)
        Me.txtMM.Name = "txtMM"
        Me.txtMM.Size = New System.Drawing.Size(43, 20)
        Me.txtMM.TabIndex = 9
        '
        'txtYY
        '
        Me.txtYY.Location = New System.Drawing.Point(93, 99)
        Me.txtYY.Name = "txtYY"
        Me.txtYY.Size = New System.Drawing.Size(43, 20)
        Me.txtYY.TabIndex = 8
        '
        'txtForm
        '
        Me.txtForm.FormattingEnabled = True
        Me.txtForm.Location = New System.Drawing.Point(93, 70)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.Size = New System.Drawing.Size(242, 21)
        Me.txtForm.TabIndex = 7
        '
        'txtStation
        '
        Me.txtStation.FormattingEnabled = True
        Me.txtStation.Location = New System.Drawing.Point(93, 37)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(242, 21)
        Me.txtStation.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Hour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Day"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "FormID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Station"
        '
        'MenuPaperArchive
        '
        Me.MenuPaperArchive.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuPaperArchive.Location = New System.Drawing.Point(0, 0)
        Me.MenuPaperArchive.Name = "MenuPaperArchive"
        Me.MenuPaperArchive.Size = New System.Drawing.Size(681, 24)
        Me.MenuPaperArchive.TabIndex = 3
        Me.MenuPaperArchive.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ExitToolStripMenuItem.Text = "&Close"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'OpenFilePaperArchive
        '
        Me.OpenFilePaperArchive.FileName = "OpenFilePaperArchive"
        '
        'formPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 505)
        Me.Controls.Add(Me.tabImageArchives)
        Me.Controls.Add(Me.MenuPaperArchive)
        Me.MainMenuStrip = Me.MenuPaperArchive
        Me.Name = "formPaperArchive"
        Me.Text = "Paper Archiving"
        Me.tabImageArchives.ResumeLayout(False)
        Me.tabStructured.ResumeLayout(False)
        Me.grpInformation.ResumeLayout(False)
        Me.grpInformation.PerformLayout()
        Me.grpComands.ResumeLayout(False)
        Me.tabUnstructured.ResumeLayout(False)
        Me.pnlUnstructuredNames.ResumeLayout(False)
        Me.pnlUnstructuredNames.PerformLayout()
        Me.TabViewArchive.ResumeLayout(False)
        Me.grpImage.ResumeLayout(False)
        Me.grpImage.PerformLayout()
        Me.MenuPaperArchive.ResumeLayout(False)
        Me.MenuPaperArchive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabImageArchives As System.Windows.Forms.TabControl
    Friend WithEvents tabStructured As System.Windows.Forms.TabPage
    Friend WithEvents grpInformation As System.Windows.Forms.GroupBox
    Friend WithEvents lblImageFiles As System.Windows.Forms.Label
    Friend WithEvents lblSelectedFolder As System.Windows.Forms.Label
    Friend WithEvents txtSelectedFolder As System.Windows.Forms.TextBox
    Friend WithEvents tabUnstructured As System.Windows.Forms.TabPage
    Friend WithEvents pnlUnstructuredNames As System.Windows.Forms.Panel
    Friend WithEvents cmdImageFile As System.Windows.Forms.Button
    Friend WithEvents lblImageFile As System.Windows.Forms.Label
    Friend WithEvents txtImageFile As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHour As System.Windows.Forms.ComboBox
    Friend WithEvents lblHour As System.Windows.Forms.Label
    Friend WithEvents lblday As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.ComboBox
    Friend WithEvents txtMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtStationArchive As System.Windows.Forms.ComboBox
    Friend WithEvents txtFormId As System.Windows.Forms.TextBox
    Friend WithEvents lblStationId As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents MenuPaperArchive As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdArchiveUnstructure As System.Windows.Forms.Button
    Friend WithEvents TabViewArchive As System.Windows.Forms.TabPage
    Friend WithEvents grpImage As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents txtHH As System.Windows.Forms.TextBox
    Friend WithEvents txtDD As System.Windows.Forms.TextBox
    Friend WithEvents txtMM As System.Windows.Forms.TextBox
    Friend WithEvents txtYY As System.Windows.Forms.TextBox
    Friend WithEvents txtForm As System.Windows.Forms.ComboBox
    Friend WithEvents txtStation As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents folderPaperArchive As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cmdFolder As System.Windows.Forms.Button
    Public WithEvents lstvFiles As System.Windows.Forms.ListView
    Friend WithEvents chkFiles As System.Windows.Forms.CheckBox
    Friend WithEvents grpComands As System.Windows.Forms.GroupBox
    Friend WithEvents cmdArchive As System.Windows.Forms.Button
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents lblStnFormyyyymmddhh As System.Windows.Forms.Label
    Friend WithEvents lblFileStructure As System.Windows.Forms.Label
    Friend WithEvents OpenFilePaperArchive As System.Windows.Forms.OpenFileDialog
End Class
