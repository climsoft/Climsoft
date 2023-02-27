<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formPaperArchive
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
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
        Me.lblArchiveMsg = New System.Windows.Forms.Label()
        Me.pnlUnstructuredNames = New System.Windows.Forms.Panel()
        Me.txtFormId = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
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
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.TabViewArchive = New System.Windows.Forms.TabPage()
        Me.grpImage = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.txtRec = New System.Windows.Forms.TextBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.cmdDeleteArchiveDef = New System.Windows.Forms.Button()
        Me.cmdUpdateArchiveDef = New System.Windows.Forms.Button()
        Me.txtYY = New System.Windows.Forms.TextBox()
        Me.txtHH = New System.Windows.Forms.ComboBox()
        Me.txtDD = New System.Windows.Forms.ComboBox()
        Me.txtMM = New System.Windows.Forms.ComboBox()
        Me.txtForm = New System.Windows.Forms.ComboBox()
        Me.txtStation = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cmdList = New System.Windows.Forms.Button()
        Me.lstArchival = New System.Windows.Forms.ListView()
        Me.MenuPaperArchive = New System.Windows.Forms.MenuStrip()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.folderPaperArchive = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFilePaperArchive = New System.Windows.Forms.OpenFileDialog()
        Me.lblImagesAt = New System.Windows.Forms.Label()
        Me.lblArhiveFolder = New System.Windows.Forms.Label()
        Me.lstMessages = New System.Windows.Forms.ListBox()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.txtDefaultFolder = New System.Windows.Forms.TextBox()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.pictureBoxForm = New System.Windows.Forms.PictureBox()
        Me.lblZoomout = New System.Windows.Forms.Label()
        Me.lblImageRotate = New System.Windows.Forms.Label()
        Me.tabImageArchives.SuspendLayout()
        Me.tabStructured.SuspendLayout()
        Me.grpInformation.SuspendLayout()
        Me.grpComands.SuspendLayout()
        Me.tabUnstructured.SuspendLayout()
        Me.pnlUnstructuredNames.SuspendLayout()
        Me.TabViewArchive.SuspendLayout()
        Me.grpImage.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.MenuPaperArchive.SuspendLayout()
        CType(Me.pictureBoxForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabImageArchives
        '
        Me.tabImageArchives.Controls.Add(Me.tabStructured)
        Me.tabImageArchives.Controls.Add(Me.tabUnstructured)
        Me.tabImageArchives.Controls.Add(Me.TabViewArchive)
        Me.tabImageArchives.Controls.Add(Me.TabPage1)
        Me.tabImageArchives.Location = New System.Drawing.Point(9, 27)
        Me.tabImageArchives.Name = "tabImageArchives"
        Me.tabImageArchives.SelectedIndex = 0
        Me.tabImageArchives.Size = New System.Drawing.Size(546, 481)
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
        Me.tabStructured.Size = New System.Drawing.Size(538, 455)
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
        Me.grpInformation.Location = New System.Drawing.Point(16, 6)
        Me.grpInformation.Name = "grpInformation"
        Me.grpInformation.Size = New System.Drawing.Size(514, 440)
        Me.grpInformation.TabIndex = 3
        Me.grpInformation.TabStop = False
        Me.grpInformation.Text = "Image Files"
        '
        'lblStnFormyyyymmddhh
        '
        Me.lblStnFormyyyymmddhh.AutoSize = True
        Me.lblStnFormyyyymmddhh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStnFormyyyymmddhh.Location = New System.Drawing.Point(140, 25)
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
        Me.chkFiles.Location = New System.Drawing.Point(21, 389)
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
        Me.grpComands.Location = New System.Drawing.Point(3, 406)
        Me.grpComands.Name = "grpComands"
        Me.grpComands.Size = New System.Drawing.Size(508, 31)
        Me.grpComands.TabIndex = 18
        Me.grpComands.TabStop = False
        '
        'cmdArchive
        '
        Me.cmdArchive.Enabled = False
        Me.cmdArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArchive.Location = New System.Drawing.Point(216, 5)
        Me.cmdArchive.Name = "cmdArchive"
        Me.cmdArchive.Size = New System.Drawing.Size(133, 25)
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
        Me.lstvFiles.Location = New System.Drawing.Point(21, 98)
        Me.lstvFiles.Name = "lstvFiles"
        Me.lstvFiles.RightToLeftLayout = True
        Me.lstvFiles.Size = New System.Drawing.Size(474, 280)
        Me.lstvFiles.TabIndex = 17
        Me.lstvFiles.UseCompatibleStateImageBehavior = False
        Me.lstvFiles.View = System.Windows.Forms.View.Details
        '
        'cmdFolder
        '
        Me.cmdFolder.BackgroundImage = CType(resources.GetObject("cmdFolder.BackgroundImage"), System.Drawing.Image)
        Me.cmdFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFolder.Location = New System.Drawing.Point(468, 52)
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
        Me.txtSelectedFolder.Location = New System.Drawing.Point(141, 55)
        Me.txtSelectedFolder.Name = "txtSelectedFolder"
        Me.txtSelectedFolder.Size = New System.Drawing.Size(323, 20)
        Me.txtSelectedFolder.TabIndex = 0
        '
        'tabUnstructured
        '
        Me.tabUnstructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnstructured.Controls.Add(Me.lblArchiveMsg)
        Me.tabUnstructured.Controls.Add(Me.pnlUnstructuredNames)
        Me.tabUnstructured.Location = New System.Drawing.Point(4, 22)
        Me.tabUnstructured.Name = "tabUnstructured"
        Me.tabUnstructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnstructured.Size = New System.Drawing.Size(538, 455)
        Me.tabUnstructured.TabIndex = 1
        Me.tabUnstructured.Text = "Unstructured Filenames"
        Me.tabUnstructured.UseVisualStyleBackColor = True
        '
        'lblArchiveMsg
        '
        Me.lblArchiveMsg.AutoSize = True
        Me.lblArchiveMsg.ForeColor = System.Drawing.Color.Red
        Me.lblArchiveMsg.Location = New System.Drawing.Point(108, 396)
        Me.lblArchiveMsg.Name = "lblArchiveMsg"
        Me.lblArchiveMsg.Size = New System.Drawing.Size(0, 13)
        Me.lblArchiveMsg.TabIndex = 1
        '
        'pnlUnstructuredNames
        '
        Me.pnlUnstructuredNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUnstructuredNames.Controls.Add(Me.txtFormId)
        Me.pnlUnstructuredNames.Controls.Add(Me.txtYear)
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
        Me.pnlUnstructuredNames.Controls.Add(Me.lblStationId)
        Me.pnlUnstructuredNames.Location = New System.Drawing.Point(6, 30)
        Me.pnlUnstructuredNames.Name = "pnlUnstructuredNames"
        Me.pnlUnstructuredNames.Size = New System.Drawing.Size(521, 327)
        Me.pnlUnstructuredNames.TabIndex = 0
        '
        'txtFormId
        '
        Me.txtFormId.FormattingEnabled = True
        Me.txtFormId.Location = New System.Drawing.Point(365, 68)
        Me.txtFormId.Name = "txtFormId"
        Me.txtFormId.Size = New System.Drawing.Size(148, 21)
        Me.txtFormId.TabIndex = 2
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(101, 102)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(41, 20)
        Me.txtYear.TabIndex = 3
        '
        'cmdArchiveUnstructure
        '
        Me.cmdArchiveUnstructure.Location = New System.Drawing.Point(253, 282)
        Me.cmdArchiveUnstructure.Name = "cmdArchiveUnstructure"
        Me.cmdArchiveUnstructure.Size = New System.Drawing.Size(88, 25)
        Me.cmdArchiveUnstructure.TabIndex = 7
        Me.cmdArchiveUnstructure.Text = "Archive"
        Me.cmdArchiveUnstructure.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 290)
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
        Me.cmdImageFile.Location = New System.Drawing.Point(463, 17)
        Me.cmdImageFile.Name = "cmdImageFile"
        Me.cmdImageFile.Size = New System.Drawing.Size(30, 26)
        Me.cmdImageFile.TabIndex = 14
        Me.cmdImageFile.UseVisualStyleBackColor = True
        '
        'lblImageFile
        '
        Me.lblImageFile.AutoSize = True
        Me.lblImageFile.Location = New System.Drawing.Point(8, 24)
        Me.lblImageFile.Name = "lblImageFile"
        Me.lblImageFile.Size = New System.Drawing.Size(55, 13)
        Me.lblImageFile.TabIndex = 13
        Me.lblImageFile.Text = "Image File"
        '
        'txtImageFile
        '
        Me.txtImageFile.Location = New System.Drawing.Point(102, 20)
        Me.txtImageFile.Name = "txtImageFile"
        Me.txtImageFile.Size = New System.Drawing.Size(342, 20)
        Me.txtImageFile.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(298, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Form ID"
        '
        'txtHour
        '
        Me.txtHour.FormattingEnabled = True
        Me.txtHour.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHour.Location = New System.Drawing.Point(101, 203)
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(41, 21)
        Me.txtHour.TabIndex = 6
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(8, 207)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(30, 13)
        Me.lblHour.TabIndex = 9
        Me.lblHour.Text = "Hour"
        '
        'lblday
        '
        Me.lblday.AutoSize = True
        Me.lblday.Location = New System.Drawing.Point(8, 173)
        Me.lblday.Name = "lblday"
        Me.lblday.Size = New System.Drawing.Size(26, 13)
        Me.lblday.TabIndex = 8
        Me.lblday.Text = "Day"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(8, 139)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 7
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(8, 106)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 6
        Me.lblYear.Text = "Year"
        '
        'txtDay
        '
        Me.txtDay.FormattingEnabled = True
        Me.txtDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.txtDay.Location = New System.Drawing.Point(101, 169)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(41, 21)
        Me.txtDay.TabIndex = 5
        '
        'txtMonth
        '
        Me.txtMonth.FormattingEnabled = True
        Me.txtMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.txtMonth.Location = New System.Drawing.Point(101, 135)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(41, 21)
        Me.txtMonth.TabIndex = 4
        '
        'txtStationArchive
        '
        Me.txtStationArchive.FormattingEnabled = True
        Me.txtStationArchive.Location = New System.Drawing.Point(100, 68)
        Me.txtStationArchive.Name = "txtStationArchive"
        Me.txtStationArchive.Size = New System.Drawing.Size(173, 21)
        Me.txtStationArchive.TabIndex = 1
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(8, 72)
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
        Me.TabViewArchive.Size = New System.Drawing.Size(538, 455)
        Me.TabViewArchive.TabIndex = 2
        Me.TabViewArchive.Text = "Retrieve Images"
        Me.TabViewArchive.UseVisualStyleBackColor = True
        '
        'grpImage
        '
        Me.grpImage.Controls.Add(Me.GroupBox1)
        Me.grpImage.Controls.Add(Me.GroupBox18)
        Me.grpImage.Controls.Add(Me.txtYY)
        Me.grpImage.Controls.Add(Me.txtHH)
        Me.grpImage.Controls.Add(Me.txtDD)
        Me.grpImage.Controls.Add(Me.txtMM)
        Me.grpImage.Controls.Add(Me.txtForm)
        Me.grpImage.Controls.Add(Me.txtStation)
        Me.grpImage.Controls.Add(Me.Label8)
        Me.grpImage.Controls.Add(Me.Label7)
        Me.grpImage.Controls.Add(Me.Label6)
        Me.grpImage.Controls.Add(Me.Label4)
        Me.grpImage.Controls.Add(Me.Label3)
        Me.grpImage.Controls.Add(Me.Label2)
        Me.grpImage.Location = New System.Drawing.Point(18, 27)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.Size = New System.Drawing.Size(499, 332)
        Me.grpImage.TabIndex = 0
        Me.grpImage.TabStop = False
        Me.grpImage.Text = "Image Details"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMovePrevious)
        Me.GroupBox1.Controls.Add(Me.btnMoveFirst)
        Me.GroupBox1.Controls.Add(Me.btnLast)
        Me.GroupBox1.Controls.Add(Me.btnMoveNext)
        Me.GroupBox1.Controls.Add(Me.txtRec)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 259)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(493, 36)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.BackgroundImage = CType(resources.GetObject("btnMovePrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnMovePrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMovePrevious.Location = New System.Drawing.Point(34, 6)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(36, 24)
        Me.btnMovePrevious.TabIndex = 4
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.BackgroundImage = CType(resources.GetObject("btnMoveFirst.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveFirst.Location = New System.Drawing.Point(0, 6)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(35, 24)
        Me.btnMoveFirst.TabIndex = 3
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.BackgroundImage = CType(resources.GetObject("btnLast.BackgroundImage"), System.Drawing.Image)
        Me.btnLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLast.Location = New System.Drawing.Point(456, 6)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(36, 24)
        Me.btnLast.TabIndex = 2
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        Me.btnMoveNext.BackgroundImage = CType(resources.GetObject("btnMoveNext.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveNext.Location = New System.Drawing.Point(421, 6)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(36, 24)
        Me.btnMoveNext.TabIndex = 1
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'txtRec
        '
        Me.txtRec.Location = New System.Drawing.Point(70, 8)
        Me.txtRec.Name = "txtRec"
        Me.txtRec.Size = New System.Drawing.Size(351, 20)
        Me.txtRec.TabIndex = 0
        Me.txtRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.cmdView)
        Me.GroupBox18.Controls.Add(Me.cmdDeleteArchiveDef)
        Me.GroupBox18.Controls.Add(Me.cmdUpdateArchiveDef)
        Me.GroupBox18.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox18.Location = New System.Drawing.Point(3, 295)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(493, 34)
        Me.GroupBox18.TabIndex = 69
        Me.GroupBox18.TabStop = False
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(91, 6)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(94, 25)
        Me.cmdView.TabIndex = 16
        Me.cmdView.Text = "View Image"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdDeleteArchiveDef
        '
        Me.cmdDeleteArchiveDef.Location = New System.Drawing.Point(358, 6)
        Me.cmdDeleteArchiveDef.Name = "cmdDeleteArchiveDef"
        Me.cmdDeleteArchiveDef.Size = New System.Drawing.Size(99, 25)
        Me.cmdDeleteArchiveDef.TabIndex = 18
        Me.cmdDeleteArchiveDef.Text = "Delete"
        Me.cmdDeleteArchiveDef.UseVisualStyleBackColor = True
        '
        'cmdUpdateArchiveDef
        '
        Me.cmdUpdateArchiveDef.Location = New System.Drawing.Point(230, 6)
        Me.cmdUpdateArchiveDef.Name = "cmdUpdateArchiveDef"
        Me.cmdUpdateArchiveDef.Size = New System.Drawing.Size(100, 25)
        Me.cmdUpdateArchiveDef.TabIndex = 17
        Me.cmdUpdateArchiveDef.Text = "Update"
        Me.cmdUpdateArchiveDef.UseVisualStyleBackColor = True
        '
        'txtYY
        '
        Me.txtYY.Location = New System.Drawing.Point(157, 104)
        Me.txtYY.Name = "txtYY"
        Me.txtYY.Size = New System.Drawing.Size(41, 20)
        Me.txtYY.TabIndex = 12
        '
        'txtHH
        '
        Me.txtHH.FormattingEnabled = True
        Me.txtHH.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtHH.Location = New System.Drawing.Point(157, 194)
        Me.txtHH.Name = "txtHH"
        Me.txtHH.Size = New System.Drawing.Size(41, 21)
        Me.txtHH.TabIndex = 15
        '
        'txtDD
        '
        Me.txtDD.FormattingEnabled = True
        Me.txtDD.Items.AddRange(New Object() {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.txtDD.Location = New System.Drawing.Point(157, 164)
        Me.txtDD.Name = "txtDD"
        Me.txtDD.Size = New System.Drawing.Size(41, 21)
        Me.txtDD.TabIndex = 14
        '
        'txtMM
        '
        Me.txtMM.FormattingEnabled = True
        Me.txtMM.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.txtMM.Location = New System.Drawing.Point(157, 134)
        Me.txtMM.Name = "txtMM"
        Me.txtMM.Size = New System.Drawing.Size(41, 21)
        Me.txtMM.TabIndex = 13
        '
        'txtForm
        '
        Me.txtForm.FormattingEnabled = True
        Me.txtForm.Location = New System.Drawing.Point(157, 75)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.Size = New System.Drawing.Size(176, 21)
        Me.txtForm.TabIndex = 11
        '
        'txtStation
        '
        Me.txtStation.FormattingEnabled = True
        Me.txtStation.Location = New System.Drawing.Point(157, 42)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(176, 21)
        Me.txtStation.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(73, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Hour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Day"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(73, 138)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "FormID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Station"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmdList)
        Me.TabPage1.Controls.Add(Me.lstArchival)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(538, 455)
        Me.TabPage1.TabIndex = 3
        Me.TabPage1.Text = "Archival List"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cmdList
        '
        Me.cmdList.Location = New System.Drawing.Point(165, 428)
        Me.cmdList.Name = "cmdList"
        Me.cmdList.Size = New System.Drawing.Size(190, 24)
        Me.cmdList.TabIndex = 19
        Me.cmdList.Text = "List Image Details"
        Me.cmdList.UseVisualStyleBackColor = True
        '
        'lstArchival
        '
        Me.lstArchival.AllowColumnReorder = True
        Me.lstArchival.AllowDrop = True
        Me.lstArchival.FullRowSelect = True
        Me.lstArchival.GridLines = True
        Me.lstArchival.HideSelection = False
        Me.lstArchival.HoverSelection = True
        Me.lstArchival.LabelEdit = True
        Me.lstArchival.Location = New System.Drawing.Point(8, 28)
        Me.lstArchival.Name = "lstArchival"
        Me.lstArchival.RightToLeftLayout = True
        Me.lstArchival.Size = New System.Drawing.Size(524, 397)
        Me.lstArchival.TabIndex = 18
        Me.lstArchival.UseCompatibleStateImageBehavior = False
        Me.lstArchival.View = System.Windows.Forms.View.Details
        '
        'MenuPaperArchive
        '
        Me.MenuPaperArchive.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuPaperArchive.Location = New System.Drawing.Point(0, 0)
        Me.MenuPaperArchive.Name = "MenuPaperArchive"
        Me.MenuPaperArchive.Size = New System.Drawing.Size(1108, 24)
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
        'lblImagesAt
        '
        Me.lblImagesAt.AutoSize = True
        Me.lblImagesAt.Location = New System.Drawing.Point(12, 511)
        Me.lblImagesAt.Name = "lblImagesAt"
        Me.lblImagesAt.Size = New System.Drawing.Size(101, 13)
        Me.lblImagesAt.TabIndex = 24
        Me.lblImagesAt.Text = "Images Archived at:"
        '
        'lblArhiveFolder
        '
        Me.lblArhiveFolder.AutoSize = True
        Me.lblArhiveFolder.Location = New System.Drawing.Point(119, 511)
        Me.lblArhiveFolder.Name = "lblArhiveFolder"
        Me.lblArhiveFolder.Size = New System.Drawing.Size(0, 13)
        Me.lblArhiveFolder.TabIndex = 25
        '
        'lstMessages
        '
        Me.lstMessages.FormattingEnabled = True
        Me.lstMessages.HorizontalScrollbar = True
        Me.lstMessages.Location = New System.Drawing.Point(557, 42)
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.ScrollAlwaysVisible = True
        Me.lstMessages.Size = New System.Drawing.Size(535, 524)
        Me.lstMessages.TabIndex = 26
        '
        'lblMessages
        '
        Me.lblMessages.AutoSize = True
        Me.lblMessages.Location = New System.Drawing.Point(788, 27)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(55, 13)
        Me.lblMessages.TabIndex = 27
        Me.lblMessages.Text = "Messages"
        '
        'txtDefaultFolder
        '
        Me.txtDefaultFolder.BackColor = System.Drawing.SystemColors.Control
        Me.txtDefaultFolder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDefaultFolder.Location = New System.Drawing.Point(15, 536)
        Me.txtDefaultFolder.Multiline = True
        Me.txtDefaultFolder.Name = "txtDefaultFolder"
        Me.txtDefaultFolder.Size = New System.Drawing.Size(526, 34)
        Me.txtDefaultFolder.TabIndex = 28
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(804, 546)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(61, 20)
        Me.cmdClear.TabIndex = 29
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'pictureBoxForm
        '
        Me.pictureBoxForm.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.pictureBoxForm.BackColor = System.Drawing.SystemColors.Control
        Me.pictureBoxForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pictureBoxForm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureBoxForm.ErrorImage = Nothing
        Me.pictureBoxForm.Location = New System.Drawing.Point(557, 43)
        Me.pictureBoxForm.Name = "pictureBoxForm"
        Me.pictureBoxForm.Size = New System.Drawing.Size(535, 523)
        Me.pictureBoxForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBoxForm.TabIndex = 30
        Me.pictureBoxForm.TabStop = False
        Me.pictureBoxForm.Visible = False
        '
        'lblZoomout
        '
        Me.lblZoomout.AutoSize = True
        Me.lblZoomout.Location = New System.Drawing.Point(996, 27)
        Me.lblZoomout.Name = "lblZoomout"
        Me.lblZoomout.Size = New System.Drawing.Size(66, 13)
        Me.lblZoomout.TabIndex = 31
        Me.lblZoomout.Text = "Zoom Image"
        Me.lblZoomout.Visible = False
        '
        'lblImageRotate
        '
        Me.lblImageRotate.AutoSize = True
        Me.lblImageRotate.Location = New System.Drawing.Point(561, 28)
        Me.lblImageRotate.Name = "lblImageRotate"
        Me.lblImageRotate.Size = New System.Drawing.Size(71, 13)
        Me.lblImageRotate.TabIndex = 32
        Me.lblImageRotate.Text = "Rotate Image"
        Me.lblImageRotate.Visible = False
        '
        'formPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 582)
        Me.Controls.Add(Me.lblImageRotate)
        Me.Controls.Add(Me.lblZoomout)
        Me.Controls.Add(Me.pictureBoxForm)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtDefaultFolder)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lstMessages)
        Me.Controls.Add(Me.lblArhiveFolder)
        Me.Controls.Add(Me.lblImagesAt)
        Me.Controls.Add(Me.tabImageArchives)
        Me.Controls.Add(Me.MenuPaperArchive)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuPaperArchive
        Me.Name = "formPaperArchive"
        Me.Text = "Paper Archiving"
        Me.tabImageArchives.ResumeLayout(False)
        Me.tabStructured.ResumeLayout(False)
        Me.grpInformation.ResumeLayout(False)
        Me.grpInformation.PerformLayout()
        Me.grpComands.ResumeLayout(False)
        Me.tabUnstructured.ResumeLayout(False)
        Me.tabUnstructured.PerformLayout()
        Me.pnlUnstructuredNames.ResumeLayout(False)
        Me.pnlUnstructuredNames.PerformLayout()
        Me.TabViewArchive.ResumeLayout(False)
        Me.grpImage.ResumeLayout(False)
        Me.grpImage.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.MenuPaperArchive.ResumeLayout(False)
        Me.MenuPaperArchive.PerformLayout()
        CType(Me.pictureBoxForm, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblStationId As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents MenuPaperArchive As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdArchiveUnstructure As System.Windows.Forms.Button
    Friend WithEvents TabViewArchive As System.Windows.Forms.TabPage
    Friend WithEvents grpImage As System.Windows.Forms.GroupBox
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
    Friend WithEvents txtFormId As System.Windows.Forms.ComboBox
    Friend WithEvents txtYY As System.Windows.Forms.TextBox
    Friend WithEvents txtHH As System.Windows.Forms.ComboBox
    Friend WithEvents txtDD As System.Windows.Forms.ComboBox
    Friend WithEvents txtMM As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdDeleteArchiveDef As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateArchiveDef As System.Windows.Forms.Button
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents lblImagesAt As System.Windows.Forms.Label
    Friend WithEvents lblArhiveFolder As System.Windows.Forms.Label
    Friend WithEvents lstMessages As System.Windows.Forms.ListBox
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents lstArchival As System.Windows.Forms.ListView
    Friend WithEvents cmdList As System.Windows.Forms.Button
    Friend WithEvents pictureBoxForm As System.Windows.Forms.PictureBox
    Friend WithEvents lblZoomout As System.Windows.Forms.Label
    Friend WithEvents lblArchiveMsg As System.Windows.Forms.Label
    Friend WithEvents lblImageRotate As System.Windows.Forms.Label
End Class
