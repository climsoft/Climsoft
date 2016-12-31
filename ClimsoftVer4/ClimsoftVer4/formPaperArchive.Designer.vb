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
        Me.cmdleft = New System.Windows.Forms.Button()
        Me.cmdfirst = New System.Windows.Forms.Button()
        Me.cmdlast = New System.Windows.Forms.Button()
        Me.cmdright = New System.Windows.Forms.Button()
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
        Me.MenuPaperArchive.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabImageArchives
        '
        Me.tabImageArchives.Controls.Add(Me.tabStructured)
        Me.tabImageArchives.Controls.Add(Me.tabUnstructured)
        Me.tabImageArchives.Controls.Add(Me.TabViewArchive)
        resources.ApplyResources(Me.tabImageArchives, "tabImageArchives")
        Me.tabImageArchives.Name = "tabImageArchives"
        Me.tabImageArchives.SelectedIndex = 0
        Me.tabImageArchives.Size = New System.Drawing.Size(606, 481)
        Me.tabImageArchives.TabIndex = 2
        '
        'tabStructured
        '
        Me.tabStructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabStructured.Controls.Add(Me.grpInformation)
        resources.ApplyResources(Me.tabStructured, "tabStructured")
        Me.tabStructured.Name = "tabStructured"
        Me.tabStructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStructured.Size = New System.Drawing.Size(598, 455)
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
        Me.grpInformation.Size = New System.Drawing.Size(565, 440)
        Me.grpInformation.TabIndex = 3
        Me.grpInformation.TabStop = False
        '
        'lblStnFormyyyymmddhh
        '
        resources.ApplyResources(Me.lblStnFormyyyymmddhh, "lblStnFormyyyymmddhh")
        Me.lblStnFormyyyymmddhh.Name = "lblStnFormyyyymmddhh"
        '
        'lblFileStructure
        '
        resources.ApplyResources(Me.lblFileStructure, "lblFileStructure")
        Me.lblFileStructure.Name = "lblFileStructure"
        '
        'chkFiles
        '
        resources.ApplyResources(Me.chkFiles, "chkFiles")
        Me.chkFiles.Checked = True
        Me.chkFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFiles.Name = "chkFiles"
        Me.chkFiles.UseVisualStyleBackColor = True
        '
        'grpComands
        '
        Me.grpComands.Controls.Add(Me.cmdArchive)
        Me.grpComands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpComands.Location = New System.Drawing.Point(3, 406)
        Me.grpComands.Name = "grpComands"
        Me.grpComands.Size = New System.Drawing.Size(559, 31)
        Me.grpComands.TabIndex = 18
        Me.grpComands.TabStop = False
        '
        'cmdArchive
        '
        resources.ApplyResources(Me.cmdArchive, "cmdArchive")
        Me.cmdArchive.Name = "cmdArchive"
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
        resources.ApplyResources(Me.lstvFiles, "lstvFiles")
        Me.lstvFiles.Name = "lstvFiles"
        Me.lstvFiles.UseCompatibleStateImageBehavior = False
        Me.lstvFiles.View = System.Windows.Forms.View.Details
        '
        'cmdFolder
        '
        resources.ApplyResources(Me.cmdFolder, "cmdFolder")
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'lblImageFiles
        '
        resources.ApplyResources(Me.lblImageFiles, "lblImageFiles")
        Me.lblImageFiles.Name = "lblImageFiles"
        '
        'lblSelectedFolder
        '
        resources.ApplyResources(Me.lblSelectedFolder, "lblSelectedFolder")
        Me.lblSelectedFolder.Name = "lblSelectedFolder"
        '
        'txtSelectedFolder
        '
        Me.txtSelectedFolder.BackColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.txtSelectedFolder, "txtSelectedFolder")
        Me.txtSelectedFolder.Name = "txtSelectedFolder"
        '
        'tabUnstructured
        '
        Me.tabUnstructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnstructured.Controls.Add(Me.pnlUnstructuredNames)
        resources.ApplyResources(Me.tabUnstructured, "tabUnstructured")
        Me.tabUnstructured.Name = "tabUnstructured"
        Me.tabUnstructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnstructured.Size = New System.Drawing.Size(598, 455)
        Me.tabUnstructured.TabIndex = 1
        Me.tabUnstructured.Text = "Unstructured Filenames"
        Me.tabUnstructured.UseVisualStyleBackColor = True
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
        Me.pnlUnstructuredNames.Location = New System.Drawing.Point(12, 52)
        Me.pnlUnstructuredNames.Name = "pnlUnstructuredNames"
        Me.pnlUnstructuredNames.Size = New System.Drawing.Size(564, 327)
        Me.pnlUnstructuredNames.TabIndex = 0
        '
        'txtFormId
        '
        Me.txtFormId.FormattingEnabled = True
        resources.ApplyResources(Me.txtFormId, "txtFormId")
        Me.txtFormId.Name = "txtFormId"
        '
        'txtYear
        '
        resources.ApplyResources(Me.txtYear, "txtYear")
        Me.txtYear.Name = "txtYear"
        '
        'cmdArchiveUnstructure
        '
        Me.cmdArchiveUnstructure.Location = New System.Drawing.Point(253, 282)
        Me.cmdArchiveUnstructure.Name = "cmdArchiveUnstructure"
        Me.cmdArchiveUnstructure.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        resources.ApplyResources(Me.CheckBox1, "CheckBox1")
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdImageFile
        '
        resources.ApplyResources(Me.cmdImageFile, "cmdImageFile")
        Me.cmdImageFile.Name = "cmdImageFile"
        Me.cmdImageFile.UseVisualStyleBackColor = True
        '
        'lblImageFile
        '
        resources.ApplyResources(Me.lblImageFile, "lblImageFile")
        Me.lblImageFile.Name = "lblImageFile"
        '
        'txtImageFile
        '
        resources.ApplyResources(Me.txtImageFile, "txtImageFile")
        Me.txtImageFile.Name = "txtImageFile"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtHour
        '
        Me.txtHour.FormattingEnabled = True
        Me.txtHour.Items.AddRange(New Object() {resources.GetString("txtHour.Items"), resources.GetString("txtHour.Items1"), resources.GetString("txtHour.Items2"), resources.GetString("txtHour.Items3"), resources.GetString("txtHour.Items4"), resources.GetString("txtHour.Items5"), resources.GetString("txtHour.Items6"), resources.GetString("txtHour.Items7"), resources.GetString("txtHour.Items8"), resources.GetString("txtHour.Items9"), resources.GetString("txtHour.Items10"), resources.GetString("txtHour.Items11"), resources.GetString("txtHour.Items12"), resources.GetString("txtHour.Items13"), resources.GetString("txtHour.Items14"), resources.GetString("txtHour.Items15"), resources.GetString("txtHour.Items16"), resources.GetString("txtHour.Items17"), resources.GetString("txtHour.Items18"), resources.GetString("txtHour.Items19"), resources.GetString("txtHour.Items20"), resources.GetString("txtHour.Items21"), resources.GetString("txtHour.Items22"), resources.GetString("txtHour.Items23")})
        resources.ApplyResources(Me.txtHour, "txtHour")
        Me.txtHour.Name = "txtHour"
        '
        'lblHour
        '
        resources.ApplyResources(Me.lblHour, "lblHour")
        Me.lblHour.Name = "lblHour"
        '
        'lblday
        '
        resources.ApplyResources(Me.lblday, "lblday")
        Me.lblday.Name = "lblday"
        '
        'lblMonth
        '
        resources.ApplyResources(Me.lblMonth, "lblMonth")
        Me.lblMonth.Name = "lblMonth"
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.Name = "lblYear"
        '
        'txtDay
        '
        Me.txtDay.FormattingEnabled = True
        Me.txtDay.Items.AddRange(New Object() {resources.GetString("txtDay.Items"), resources.GetString("txtDay.Items1"), resources.GetString("txtDay.Items2"), resources.GetString("txtDay.Items3"), resources.GetString("txtDay.Items4"), resources.GetString("txtDay.Items5"), resources.GetString("txtDay.Items6"), resources.GetString("txtDay.Items7"), resources.GetString("txtDay.Items8"), resources.GetString("txtDay.Items9"), resources.GetString("txtDay.Items10"), resources.GetString("txtDay.Items11"), resources.GetString("txtDay.Items12"), resources.GetString("txtDay.Items13"), resources.GetString("txtDay.Items14"), resources.GetString("txtDay.Items15"), resources.GetString("txtDay.Items16"), resources.GetString("txtDay.Items17"), resources.GetString("txtDay.Items18"), resources.GetString("txtDay.Items19"), resources.GetString("txtDay.Items20"), resources.GetString("txtDay.Items21"), resources.GetString("txtDay.Items22"), resources.GetString("txtDay.Items23"), resources.GetString("txtDay.Items24"), resources.GetString("txtDay.Items25"), resources.GetString("txtDay.Items26"), resources.GetString("txtDay.Items27"), resources.GetString("txtDay.Items28"), resources.GetString("txtDay.Items29"), resources.GetString("txtDay.Items30")})
        resources.ApplyResources(Me.txtDay, "txtDay")
        Me.txtDay.Name = "txtDay"
        '
        'txtMonth
        '
        Me.txtMonth.FormattingEnabled = True
        Me.txtMonth.Items.AddRange(New Object() {resources.GetString("txtMonth.Items"), resources.GetString("txtMonth.Items1"), resources.GetString("txtMonth.Items2"), resources.GetString("txtMonth.Items3"), resources.GetString("txtMonth.Items4"), resources.GetString("txtMonth.Items5"), resources.GetString("txtMonth.Items6"), resources.GetString("txtMonth.Items7"), resources.GetString("txtMonth.Items8"), resources.GetString("txtMonth.Items9"), resources.GetString("txtMonth.Items10"), resources.GetString("txtMonth.Items11")})
        resources.ApplyResources(Me.txtMonth, "txtMonth")
        Me.txtMonth.Name = "txtMonth"
        '
        'txtStationArchive
        '
        Me.txtStationArchive.FormattingEnabled = True
        resources.ApplyResources(Me.txtStationArchive, "txtStationArchive")
        Me.txtStationArchive.Name = "txtStationArchive"
        '
        'lblStationId
        '
        resources.ApplyResources(Me.lblStationId, "lblStationId")
        Me.lblStationId.Name = "lblStationId"
        '
        'TabViewArchive
        '
        Me.TabViewArchive.Controls.Add(Me.grpImage)
        resources.ApplyResources(Me.TabViewArchive, "TabViewArchive")
        Me.TabViewArchive.Name = "TabViewArchive"
        Me.TabViewArchive.Padding = New System.Windows.Forms.Padding(3)
        Me.TabViewArchive.Size = New System.Drawing.Size(598, 455)
        Me.TabViewArchive.TabIndex = 2
        Me.TabViewArchive.Text = "Archived Images"
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
        Me.grpImage.Location = New System.Drawing.Point(37, 57)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdleft)
        Me.GroupBox1.Controls.Add(Me.cmdfirst)
        Me.GroupBox1.Controls.Add(Me.cmdlast)
        Me.GroupBox1.Controls.Add(Me.cmdright)
        Me.GroupBox1.Controls.Add(Me.txtRec)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'cmdleft
        '
        resources.ApplyResources(Me.cmdleft, "cmdleft")
        Me.cmdleft.Name = "cmdleft"
        Me.cmdleft.UseVisualStyleBackColor = True
        '
        'cmdfirst
        '
        resources.ApplyResources(Me.cmdfirst, "cmdfirst")
        Me.cmdfirst.Name = "cmdfirst"
        Me.cmdfirst.UseVisualStyleBackColor = True
        '
        'cmdlast
        '
        resources.ApplyResources(Me.cmdlast, "cmdlast")
        Me.cmdlast.Name = "cmdlast"
        Me.cmdlast.UseVisualStyleBackColor = True
        '
        'cmdright
        '
        resources.ApplyResources(Me.cmdright, "cmdright")
        Me.cmdright.Name = "cmdright"
        Me.cmdright.UseVisualStyleBackColor = True
        '
        'txtRec
        '
        resources.ApplyResources(Me.txtRec, "txtRec")
        Me.txtRec.Name = "txtRec"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.cmdView)
        Me.GroupBox18.Controls.Add(Me.cmdDeleteArchiveDef)
        Me.GroupBox18.Controls.Add(Me.cmdUpdateArchiveDef)
        resources.ApplyResources(Me.GroupBox18, "GroupBox18")
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.TabStop = False
        '
        'cmdView
        '
        resources.ApplyResources(Me.cmdView, "cmdView")
        Me.cmdView.Name = "cmdView"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'cmdDeleteArchiveDef
        '
        resources.ApplyResources(Me.cmdDeleteArchiveDef, "cmdDeleteArchiveDef")
        Me.cmdDeleteArchiveDef.Name = "cmdDeleteArchiveDef"
        Me.cmdDeleteArchiveDef.UseVisualStyleBackColor = True
        '
        'cmdUpdateArchiveDef
        '
        resources.ApplyResources(Me.cmdUpdateArchiveDef, "cmdUpdateArchiveDef")
        Me.cmdUpdateArchiveDef.Name = "cmdUpdateArchiveDef"
        Me.cmdUpdateArchiveDef.UseVisualStyleBackColor = True
        '
        'txtYY
        '
        resources.ApplyResources(Me.txtYY, "txtYY")
        Me.txtYY.Name = "txtYY"
        '
        'txtHH
        '
        Me.txtHH.FormattingEnabled = True
        Me.txtHH.Items.AddRange(New Object() {resources.GetString("txtHH.Items"), resources.GetString("txtHH.Items1"), resources.GetString("txtHH.Items2"), resources.GetString("txtHH.Items3"), resources.GetString("txtHH.Items4"), resources.GetString("txtHH.Items5"), resources.GetString("txtHH.Items6"), resources.GetString("txtHH.Items7"), resources.GetString("txtHH.Items8"), resources.GetString("txtHH.Items9"), resources.GetString("txtHH.Items10"), resources.GetString("txtHH.Items11"), resources.GetString("txtHH.Items12"), resources.GetString("txtHH.Items13"), resources.GetString("txtHH.Items14"), resources.GetString("txtHH.Items15"), resources.GetString("txtHH.Items16"), resources.GetString("txtHH.Items17"), resources.GetString("txtHH.Items18"), resources.GetString("txtHH.Items19"), resources.GetString("txtHH.Items20"), resources.GetString("txtHH.Items21"), resources.GetString("txtHH.Items22"), resources.GetString("txtHH.Items23")})
        resources.ApplyResources(Me.txtHH, "txtHH")
        Me.txtHH.Name = "txtHH"
        '
        'txtDD
        '
        Me.txtDD.FormattingEnabled = True
        Me.txtDD.Items.AddRange(New Object() {resources.GetString("txtDD.Items"), resources.GetString("txtDD.Items1"), resources.GetString("txtDD.Items2"), resources.GetString("txtDD.Items3"), resources.GetString("txtDD.Items4"), resources.GetString("txtDD.Items5"), resources.GetString("txtDD.Items6"), resources.GetString("txtDD.Items7"), resources.GetString("txtDD.Items8"), resources.GetString("txtDD.Items9"), resources.GetString("txtDD.Items10"), resources.GetString("txtDD.Items11"), resources.GetString("txtDD.Items12"), resources.GetString("txtDD.Items13"), resources.GetString("txtDD.Items14"), resources.GetString("txtDD.Items15"), resources.GetString("txtDD.Items16"), resources.GetString("txtDD.Items17"), resources.GetString("txtDD.Items18"), resources.GetString("txtDD.Items19"), resources.GetString("txtDD.Items20"), resources.GetString("txtDD.Items21"), resources.GetString("txtDD.Items22"), resources.GetString("txtDD.Items23")})
        resources.ApplyResources(Me.txtDD, "txtDD")
        Me.txtDD.Name = "txtDD"
        '
        'txtMM
        '
        Me.txtMM.FormattingEnabled = True
        Me.txtMM.Items.AddRange(New Object() {resources.GetString("txtMM.Items"), resources.GetString("txtMM.Items1"), resources.GetString("txtMM.Items2"), resources.GetString("txtMM.Items3"), resources.GetString("txtMM.Items4"), resources.GetString("txtMM.Items5"), resources.GetString("txtMM.Items6"), resources.GetString("txtMM.Items7"), resources.GetString("txtMM.Items8"), resources.GetString("txtMM.Items9"), resources.GetString("txtMM.Items10"), resources.GetString("txtMM.Items11"), resources.GetString("txtMM.Items12"), resources.GetString("txtMM.Items13"), resources.GetString("txtMM.Items14"), resources.GetString("txtMM.Items15"), resources.GetString("txtMM.Items16"), resources.GetString("txtMM.Items17"), resources.GetString("txtMM.Items18"), resources.GetString("txtMM.Items19"), resources.GetString("txtMM.Items20"), resources.GetString("txtMM.Items21"), resources.GetString("txtMM.Items22"), resources.GetString("txtMM.Items23"), resources.GetString("txtMM.Items24"), resources.GetString("txtMM.Items25"), resources.GetString("txtMM.Items26"), resources.GetString("txtMM.Items27"), resources.GetString("txtMM.Items28"), resources.GetString("txtMM.Items29"), resources.GetString("txtMM.Items30")})
        resources.ApplyResources(Me.txtMM, "txtMM")
        Me.txtMM.Name = "txtMM"
        '
        'txtForm
        '
        Me.txtForm.FormattingEnabled = True
        resources.ApplyResources(Me.txtForm, "txtForm")
        Me.txtForm.Name = "txtForm"
        '
        'txtStation
        '
        Me.txtStation.FormattingEnabled = True
        resources.ApplyResources(Me.txtStation, "txtStation")
        Me.txtStation.Name = "txtStation"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'MenuPaperArchive
        '
        Me.MenuPaperArchive.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.HelpToolStripMenuItem})
        resources.ApplyResources(Me.MenuPaperArchive, "MenuPaperArchive")
        Me.MenuPaperArchive.Name = "MenuPaperArchive"
        Me.MenuPaperArchive.Size = New System.Drawing.Size(926, 24)
        Me.MenuPaperArchive.TabIndex = 3
        Me.MenuPaperArchive.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
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
        Me.lstMessages.Location = New System.Drawing.Point(617, 53)
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.ScrollAlwaysVisible = True
        Me.lstMessages.Size = New System.Drawing.Size(293, 446)
        Me.lstMessages.TabIndex = 26
        '
        'lblMessages
        '
        Me.lblMessages.AutoSize = True
        Me.lblMessages.Location = New System.Drawing.Point(736, 33)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(55, 13)
        Me.lblMessages.TabIndex = 27
        Me.lblMessages.Text = "Messages"
        '
        'txtDefaultFolder
        '
        Me.txtDefaultFolder.BackColor = System.Drawing.SystemColors.Control
        Me.txtDefaultFolder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDefaultFolder.Location = New System.Drawing.Point(617, 501)
        Me.txtDefaultFolder.Multiline = True
        Me.txtDefaultFolder.Name = "txtDefaultFolder"
        Me.txtDefaultFolder.Size = New System.Drawing.Size(293, 23)
        Me.txtDefaultFolder.TabIndex = 28
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(740, 476)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(39, 20)
        Me.cmdClear.TabIndex = 29
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'formPaperArchive
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 532)
        Me.Controls.Add(Me.cmdClear)
        Me.Controls.Add(Me.txtDefaultFolder)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.lstMessages)
        Me.Controls.Add(Me.lblArhiveFolder)
        Me.Controls.Add(Me.lblImagesAt)
        Me.Controls.Add(Me.tabImageArchives)
        Me.Controls.Add(Me.MenuPaperArchive)
        Me.MainMenuStrip = Me.MenuPaperArchive
        Me.Name = "formPaperArchive"
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
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
    Friend WithEvents cmdleft As System.Windows.Forms.Button
    Friend WithEvents cmdfirst As System.Windows.Forms.Button
    Friend WithEvents cmdlast As System.Windows.Forms.Button
    Friend WithEvents cmdright As System.Windows.Forms.Button
    Friend WithEvents txtRec As System.Windows.Forms.TextBox
    Friend WithEvents lblImagesAt As System.Windows.Forms.Label
    Friend WithEvents lblArhiveFolder As System.Windows.Forms.Label
    Friend WithEvents lstMessages As System.Windows.Forms.ListBox
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
    Friend WithEvents cmdClear As System.Windows.Forms.Button
End Class
