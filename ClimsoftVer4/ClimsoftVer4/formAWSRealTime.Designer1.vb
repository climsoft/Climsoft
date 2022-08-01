<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formAWSRealTime
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formAWSRealTime))
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdMessages = New System.Windows.Forms.Button()
        Me.cmdDataStructures = New System.Windows.Forms.Button()
        Me.cmdSites = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdServers = New System.Windows.Forms.Button()
        Me.cmdProcess = New System.Windows.Forms.Button()
        Me.pnlSites = New System.Windows.Forms.Panel()
        Me.grpSites = New System.Windows.Forms.GroupBox()
        Me.DataGridViewSites = New System.Windows.Forms.DataGridView()
        Me.chkPrefix = New System.Windows.Forms.CheckBox()
        Me.txtfilePrefix = New System.Windows.Forms.TextBox()
        Me.txtGTSHeader = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.chkGTSEncode = New System.Windows.Forms.CheckBox()
        Me.txtSiteName = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.cmdViewUpdate = New System.Windows.Forms.Button()
        Me.cmdDel = New System.Windows.Forms.Button()
        Me.cmdUpdateSites = New System.Windows.Forms.Button()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.txtSitesNavigator = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.txtIP = New System.Windows.Forms.ComboBox()
        Me.txtDataStructure = New System.Windows.Forms.ComboBox()
        Me.txtFlag = New System.Windows.Forms.TextBox()
        Me.chkOperational = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInFile = New System.Windows.Forms.TextBox()
        Me.lblInfile = New System.Windows.Forms.Label()
        Me.txtSiteID = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlServers = New System.Windows.Forms.Panel()
        Me.pnlBaseStation = New System.Windows.Forms.Panel()
        Me.cmdBstAddNew = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.txtBasestationFTPMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmdPrevRecord = New System.Windows.Forms.Button()
        Me.cmdFirstRecord = New System.Windows.Forms.Button()
        Me.cmdLastRecord = New System.Windows.Forms.Button()
        Me.cmdNextRecord = New System.Windows.Forms.Button()
        Me.txtbssNavigator = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lblbaseStation = New System.Windows.Forms.Label()
        Me.cmdBstDelete = New System.Windows.Forms.Button()
        Me.cmdBsstUpdate = New System.Windows.Forms.Button()
        Me.cmdBstSave = New System.Windows.Forms.Button()
        Me.txtbaseStationPWConfirm = New System.Windows.Forms.TextBox()
        Me.txtbaseStationPW = New System.Windows.Forms.TextBox()
        Me.txtBaseStationUser = New System.Windows.Forms.TextBox()
        Me.txtBaseStationFolder = New System.Windows.Forms.TextBox()
        Me.txtBaseStationAddress = New System.Windows.Forms.TextBox()
        Me.lblConfirmInputPW = New System.Windows.Forms.Label()
        Me.lblInputPW = New System.Windows.Forms.Label()
        Me.lblInputUser = New System.Windows.Forms.Label()
        Me.lblFTPFolder = New System.Windows.Forms.Label()
        Me.lblBaseStationFTP = New System.Windows.Forms.Label()
        Me.cmdMSS = New System.Windows.Forms.Button()
        Me.cmdBaseStation = New System.Windows.Forms.Button()
        Me.pnlMSS = New System.Windows.Forms.Panel()
        Me.lstFolders = New System.Windows.Forms.ListBox()
        Me.cmdMssAddNew = New System.Windows.Forms.Button()
        Me.cmdMssRefresh = New System.Windows.Forms.Button()
        Me.cmdMssReset = New System.Windows.Forms.Button()
        Me.txtmssFTPMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdmssPrev = New System.Windows.Forms.Button()
        Me.cmdmssfirst = New System.Windows.Forms.Button()
        Me.cmdmssLast = New System.Windows.Forms.Button()
        Me.cmdmssNext = New System.Windows.Forms.Button()
        Me.txtmssNavigator = New System.Windows.Forms.TextBox()
        Me.lblFtpTransferMode = New System.Windows.Forms.Label()
        Me.lblMsgSwitch = New System.Windows.Forms.Label()
        Me.cmdMssDelete = New System.Windows.Forms.Button()
        Me.cmdMssUpdate = New System.Windows.Forms.Button()
        Me.cmdMssSave = New System.Windows.Forms.Button()
        Me.txtMSSConfirm = New System.Windows.Forms.TextBox()
        Me.txtMSSPW = New System.Windows.Forms.TextBox()
        Me.txtmssUser = New System.Windows.Forms.TextBox()
        Me.txtMSSFolder = New System.Windows.Forms.TextBox()
        Me.txtMSSAddress = New System.Windows.Forms.TextBox()
        Me.lblmssConfirmPassword = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlMsgEncoding = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgrdCodeFlag = New System.Windows.Forms.DataGridView()
        Me.grpIndicators = New System.Windows.Forms.GroupBox()
        Me.cmdDefault = New System.Windows.Forms.Button()
        Me.cmdSaves = New System.Windows.Forms.Button()
        Me.cmdUpadate = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.chkOptionalSection = New System.Windows.Forms.CheckBox()
        Me.txtLocaltableVersion = New System.Windows.Forms.TextBox()
        Me.txtMastertableVersion = New System.Windows.Forms.TextBox()
        Me.txtLocalSubcategory = New System.Windows.Forms.TextBox()
        Me.txtInternationalSubcategory = New System.Windows.Forms.TextBox()
        Me.txtDataCategory = New System.Windows.Forms.TextBox()
        Me.txtUpdateSequence = New System.Windows.Forms.TextBox()
        Me.txtOriginatingSubcentre = New System.Windows.Forms.TextBox()
        Me.txtOriginatingCentre = New System.Windows.Forms.TextBox()
        Me.txtBufrEdition = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtUpdateSequenceNumber = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingSubCentre = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingCentre = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtTemplate = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtMsgHeader = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlControl.SuspendLayout()
        Me.pnlSites.SuspendLayout()
        Me.grpSites.SuspendLayout()
        CType(Me.DataGridViewSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlServers.SuspendLayout()
        Me.pnlBaseStation.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.pnlMSS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlMsgEncoding.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgrdCodeFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIndicators.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControl
        '
        Me.pnlControl.BackColor = System.Drawing.Color.DarkSalmon
        Me.pnlControl.Controls.Add(Me.cmdHelp)
        Me.pnlControl.Controls.Add(Me.cmdMessages)
        Me.pnlControl.Controls.Add(Me.cmdDataStructures)
        Me.pnlControl.Controls.Add(Me.cmdSites)
        Me.pnlControl.Controls.Add(Me.cmdClose)
        Me.pnlControl.Controls.Add(Me.cmdServers)
        Me.pnlControl.Controls.Add(Me.cmdProcess)
        Me.pnlControl.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlControl.Location = New System.Drawing.Point(0, 0)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(191, 615)
        Me.pnlControl.TabIndex = 0
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.Color.LightSalmon
        Me.cmdHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.Location = New System.Drawing.Point(19, 431)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(141, 37)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'cmdMessages
        '
        Me.cmdMessages.BackColor = System.Drawing.Color.SeaShell
        Me.cmdMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMessages.Location = New System.Drawing.Point(19, 329)
        Me.cmdMessages.Name = "cmdMessages"
        Me.cmdMessages.Size = New System.Drawing.Size(142, 52)
        Me.cmdMessages.TabIndex = 8
        Me.cmdMessages.Text = "Encoding Options"
        Me.cmdMessages.UseVisualStyleBackColor = False
        '
        'cmdDataStructures
        '
        Me.cmdDataStructures.BackColor = System.Drawing.Color.SeaShell
        Me.cmdDataStructures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDataStructures.Location = New System.Drawing.Point(19, 255)
        Me.cmdDataStructures.Name = "cmdDataStructures"
        Me.cmdDataStructures.Size = New System.Drawing.Size(142, 52)
        Me.cmdDataStructures.TabIndex = 7
        Me.cmdDataStructures.Text = "Data Structures"
        Me.cmdDataStructures.UseVisualStyleBackColor = False
        '
        'cmdSites
        '
        Me.cmdSites.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSites.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSites.Location = New System.Drawing.Point(18, 181)
        Me.cmdSites.Name = "cmdSites"
        Me.cmdSites.Size = New System.Drawing.Size(142, 52)
        Me.cmdSites.TabIndex = 6
        Me.cmdSites.Text = "Sites"
        Me.cmdSites.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.Coral
        Me.cmdClose.Location = New System.Drawing.Point(19, 494)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(141, 37)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdServers
        '
        Me.cmdServers.BackColor = System.Drawing.Color.SeaShell
        Me.cmdServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdServers.Location = New System.Drawing.Point(17, 107)
        Me.cmdServers.Name = "cmdServers"
        Me.cmdServers.Size = New System.Drawing.Size(142, 52)
        Me.cmdServers.TabIndex = 4
        Me.cmdServers.Text = "Servers"
        Me.cmdServers.UseVisualStyleBackColor = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackColor = System.Drawing.Color.SeaShell
        Me.cmdProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(19, 32)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(142, 53)
        Me.cmdProcess.TabIndex = 3
        Me.cmdProcess.Text = "Processing"
        Me.cmdProcess.UseVisualStyleBackColor = False
        '
        'pnlSites
        '
        Me.pnlSites.AllowDrop = True
        Me.pnlSites.AutoSize = True
        Me.pnlSites.BackColor = System.Drawing.Color.Linen
        Me.pnlSites.Controls.Add(Me.grpSites)
        Me.pnlSites.Location = New System.Drawing.Point(197, 447)
        Me.pnlSites.Name = "pnlSites"
        Me.pnlSites.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSites.Size = New System.Drawing.Size(757, 389)
        Me.pnlSites.TabIndex = 3
        '
        'grpSites
        '
        Me.grpSites.Controls.Add(Me.DataGridViewSites)
        Me.grpSites.Controls.Add(Me.chkPrefix)
        Me.grpSites.Controls.Add(Me.txtfilePrefix)
        Me.grpSites.Controls.Add(Me.txtGTSHeader)
        Me.grpSites.Controls.Add(Me.Label42)
        Me.grpSites.Controls.Add(Me.chkGTSEncode)
        Me.grpSites.Controls.Add(Me.txtSiteName)
        Me.grpSites.Controls.Add(Me.Label41)
        Me.grpSites.Controls.Add(Me.cmdClear)
        Me.grpSites.Controls.Add(Me.cmdViewUpdate)
        Me.grpSites.Controls.Add(Me.cmdDel)
        Me.grpSites.Controls.Add(Me.cmdUpdateSites)
        Me.grpSites.Controls.Add(Me.cmdAdd)
        Me.grpSites.Controls.Add(Me.btnMovePrevious)
        Me.grpSites.Controls.Add(Me.btnMoveFirst)
        Me.grpSites.Controls.Add(Me.btnMoveLast)
        Me.grpSites.Controls.Add(Me.txtSitesNavigator)
        Me.grpSites.Controls.Add(Me.btnMoveNext)
        Me.grpSites.Controls.Add(Me.txtIP)
        Me.grpSites.Controls.Add(Me.txtDataStructure)
        Me.grpSites.Controls.Add(Me.txtFlag)
        Me.grpSites.Controls.Add(Me.chkOperational)
        Me.grpSites.Controls.Add(Me.Label18)
        Me.grpSites.Controls.Add(Me.Label17)
        Me.grpSites.Controls.Add(Me.Label16)
        Me.grpSites.Controls.Add(Me.txtInFile)
        Me.grpSites.Controls.Add(Me.lblInfile)
        Me.grpSites.Controls.Add(Me.txtSiteID)
        Me.grpSites.Controls.Add(Me.Label15)
        Me.grpSites.Location = New System.Drawing.Point(11, 14)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Size = New System.Drawing.Size(743, 372)
        Me.grpSites.TabIndex = 67
        Me.grpSites.TabStop = False
        '
        'DataGridViewSites
        '
        Me.DataGridViewSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSites.Location = New System.Drawing.Point(440, 203)
        Me.DataGridViewSites.Name = "DataGridViewSites"
        Me.DataGridViewSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewSites.Size = New System.Drawing.Size(241, 51)
        Me.DataGridViewSites.TabIndex = 68
        Me.DataGridViewSites.Visible = False
        '
        'chkPrefix
        '
        Me.chkPrefix.AutoSize = True
        Me.chkPrefix.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.Location = New System.Drawing.Point(442, 106)
        Me.chkPrefix.Name = "chkPrefix"
        Me.chkPrefix.Size = New System.Drawing.Size(107, 17)
        Me.chkPrefix.TabIndex = 101
        Me.chkPrefix.Text = "Files name  prefix"
        Me.chkPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.UseVisualStyleBackColor = True
        '
        'txtfilePrefix
        '
        Me.txtfilePrefix.Location = New System.Drawing.Point(594, 104)
        Me.txtfilePrefix.Name = "txtfilePrefix"
        Me.txtfilePrefix.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfilePrefix.Size = New System.Drawing.Size(140, 20)
        Me.txtfilePrefix.TabIndex = 100
        Me.txtfilePrefix.Visible = False
        '
        'txtGTSHeader
        '
        Me.txtGTSHeader.Location = New System.Drawing.Point(227, 209)
        Me.txtGTSHeader.Name = "txtGTSHeader"
        Me.txtGTSHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGTSHeader.Size = New System.Drawing.Size(135, 20)
        Me.txtGTSHeader.TabIndex = 98
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(62, 213)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(90, 13)
        Me.Label42.TabIndex = 97
        Me.Label42.Text = "GTS Msg Header"
        '
        'chkGTSEncode
        '
        Me.chkGTSEncode.AutoSize = True
        Me.chkGTSEncode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkGTSEncode.Location = New System.Drawing.Point(225, 271)
        Me.chkGTSEncode.Name = "chkGTSEncode"
        Me.chkGTSEncode.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkGTSEncode.Size = New System.Drawing.Size(109, 17)
        Me.chkGTSEncode.TabIndex = 96
        Me.chkGTSEncode.Text = "Encode for GTS  "
        Me.chkGTSEncode.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkGTSEncode.UseVisualStyleBackColor = True
        '
        'txtSiteName
        '
        Me.txtSiteName.FormattingEnabled = True
        Me.txtSiteName.Location = New System.Drawing.Point(227, 76)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteName.Size = New System.Drawing.Size(280, 21)
        Me.txtSiteName.TabIndex = 95
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(63, 80)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 13)
        Me.Label41.TabIndex = 94
        Me.Label41.Text = "Site Name"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(164, 310)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(68, 29)
        Me.cmdClear.TabIndex = 88
        Me.cmdClear.Text = "AddNew"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewUpdate
        '
        Me.cmdViewUpdate.Location = New System.Drawing.Point(508, 310)
        Me.cmdViewUpdate.Name = "cmdViewUpdate"
        Me.cmdViewUpdate.Size = New System.Drawing.Size(88, 29)
        Me.cmdViewUpdate.TabIndex = 87
        Me.cmdViewUpdate.Text = "View/Update"
        Me.cmdViewUpdate.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.Location = New System.Drawing.Point(422, 310)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(68, 29)
        Me.cmdDel.TabIndex = 86
        Me.cmdDel.Text = "Delete"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpdateSites
        '
        Me.cmdUpdateSites.Location = New System.Drawing.Point(336, 310)
        Me.cmdUpdateSites.Name = "cmdUpdateSites"
        Me.cmdUpdateSites.Size = New System.Drawing.Size(68, 29)
        Me.cmdUpdateSites.TabIndex = 85
        Me.cmdUpdateSites.Text = "Update"
        Me.cmdUpdateSites.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(250, 310)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(68, 29)
        Me.cmdAdd.TabIndex = 84
        Me.cmdAdd.Text = "Save"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.BackgroundImage = CType(resources.GetObject("btnMovePrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnMovePrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(47, 346)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(41, 23)
        Me.btnMovePrevious.TabIndex = 83
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.BackgroundImage = CType(resources.GetObject("btnMoveFirst.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(9, 346)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 82
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.BackgroundImage = CType(resources.GetObject("btnMoveLast.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(658, 346)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 81
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'txtSitesNavigator
        '
        Me.txtSitesNavigator.Location = New System.Drawing.Point(87, 347)
        Me.txtSitesNavigator.Name = "txtSitesNavigator"
        Me.txtSitesNavigator.Size = New System.Drawing.Size(536, 20)
        Me.txtSitesNavigator.TabIndex = 80
        Me.txtSitesNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMoveNext
        '
        Me.btnMoveNext.BackgroundImage = CType(resources.GetObject("btnMoveNext.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(623, 346)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveNext.TabIndex = 79
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.FormattingEnabled = True
        Me.txtIP.Location = New System.Drawing.Point(226, 182)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(135, 21)
        Me.txtIP.TabIndex = 77
        '
        'txtDataStructure
        '
        Me.txtDataStructure.FormattingEnabled = True
        Me.txtDataStructure.Location = New System.Drawing.Point(227, 129)
        Me.txtDataStructure.Name = "txtDataStructure"
        Me.txtDataStructure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataStructure.Size = New System.Drawing.Size(185, 21)
        Me.txtDataStructure.TabIndex = 76
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(227, 156)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFlag.Size = New System.Drawing.Size(135, 20)
        Me.txtFlag.TabIndex = 75
        '
        'chkOperational
        '
        Me.chkOperational.AutoSize = True
        Me.chkOperational.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOperational.Location = New System.Drawing.Point(227, 246)
        Me.chkOperational.Name = "chkOperational"
        Me.chkOperational.Size = New System.Drawing.Size(80, 17)
        Me.chkOperational.TabIndex = 74
        Me.chkOperational.Text = "Operational"
        Me.chkOperational.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkOperational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(62, 186)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "AWS Server IP"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(62, 160)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Missing Data Flag"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(62, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Data Strucure"
        '
        'txtInFile
        '
        Me.txtInFile.Location = New System.Drawing.Point(226, 103)
        Me.txtInFile.Name = "txtInFile"
        Me.txtInFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInFile.Size = New System.Drawing.Size(186, 20)
        Me.txtInFile.TabIndex = 70
        '
        'lblInfile
        '
        Me.lblInfile.AutoSize = True
        Me.lblInfile.Location = New System.Drawing.Point(62, 107)
        Me.lblInfile.Name = "lblInfile"
        Me.lblInfile.Size = New System.Drawing.Size(73, 13)
        Me.lblInfile.TabIndex = 69
        Me.lblInfile.Text = "Input Data file"
        '
        'txtSiteID
        '
        Me.txtSiteID.FormattingEnabled = True
        Me.txtSiteID.Location = New System.Drawing.Point(227, 49)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteID.Size = New System.Drawing.Size(137, 21)
        Me.txtSiteID.TabIndex = 68
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(62, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Site ID"
        '
        'pnlServers
        '
        Me.pnlServers.BackColor = System.Drawing.Color.PeachPuff
        Me.pnlServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlServers.Controls.Add(Me.pnlBaseStation)
        Me.pnlServers.Controls.Add(Me.cmdMSS)
        Me.pnlServers.Controls.Add(Me.cmdBaseStation)
        Me.pnlServers.Controls.Add(Me.pnlMSS)
        Me.pnlServers.Location = New System.Drawing.Point(206, 188)
        Me.pnlServers.Name = "pnlServers"
        Me.pnlServers.Size = New System.Drawing.Size(753, 119)
        Me.pnlServers.TabIndex = 2
        Me.pnlServers.Visible = False
        '
        'pnlBaseStation
        '
        Me.pnlBaseStation.BackColor = System.Drawing.Color.PapayaWhip
        Me.pnlBaseStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBaseStation.Controls.Add(Me.cmdBstAddNew)
        Me.pnlBaseStation.Controls.Add(Me.cmdRefresh)
        Me.pnlBaseStation.Controls.Add(Me.cmdReset)
        Me.pnlBaseStation.Controls.Add(Me.txtBasestationFTPMode)
        Me.pnlBaseStation.Controls.Add(Me.GroupBox10)
        Me.pnlBaseStation.Controls.Add(Me.Label40)
        Me.pnlBaseStation.Controls.Add(Me.lblbaseStation)
        Me.pnlBaseStation.Controls.Add(Me.cmdBstDelete)
        Me.pnlBaseStation.Controls.Add(Me.cmdBsstUpdate)
        Me.pnlBaseStation.Controls.Add(Me.cmdBstSave)
        Me.pnlBaseStation.Controls.Add(Me.txtbaseStationPWConfirm)
        Me.pnlBaseStation.Controls.Add(Me.txtbaseStationPW)
        Me.pnlBaseStation.Controls.Add(Me.txtBaseStationUser)
        Me.pnlBaseStation.Controls.Add(Me.txtBaseStationFolder)
        Me.pnlBaseStation.Controls.Add(Me.txtBaseStationAddress)
        Me.pnlBaseStation.Controls.Add(Me.lblConfirmInputPW)
        Me.pnlBaseStation.Controls.Add(Me.lblInputPW)
        Me.pnlBaseStation.Controls.Add(Me.lblInputUser)
        Me.pnlBaseStation.Controls.Add(Me.lblFTPFolder)
        Me.pnlBaseStation.Controls.Add(Me.lblBaseStationFTP)
        Me.pnlBaseStation.Enabled = False
        Me.pnlBaseStation.Location = New System.Drawing.Point(72, 91)
        Me.pnlBaseStation.Name = "pnlBaseStation"
        Me.pnlBaseStation.Size = New System.Drawing.Size(544, 296)
        Me.pnlBaseStation.TabIndex = 4
        '
        'cmdBstAddNew
        '
        Me.cmdBstAddNew.Location = New System.Drawing.Point(28, 232)
        Me.cmdBstAddNew.Name = "cmdBstAddNew"
        Me.cmdBstAddNew.Size = New System.Drawing.Size(62, 21)
        Me.cmdBstAddNew.TabIndex = 75
        Me.cmdBstAddNew.Text = "Add New"
        Me.cmdBstAddNew.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(364, 232)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(62, 21)
        Me.cmdRefresh.TabIndex = 74
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(280, 232)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(62, 21)
        Me.cmdReset.TabIndex = 13
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'txtBasestationFTPMode
        '
        Me.txtBasestationFTPMode.FormattingEnabled = True
        Me.txtBasestationFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtBasestationFTPMode.Location = New System.Drawing.Point(245, 102)
        Me.txtBasestationFTPMode.Name = "txtBasestationFTPMode"
        Me.txtBasestationFTPMode.Size = New System.Drawing.Size(116, 21)
        Me.txtBasestationFTPMode.TabIndex = 73
        Me.txtBasestationFTPMode.Text = "FTP"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdPrevRecord)
        Me.GroupBox10.Controls.Add(Me.cmdFirstRecord)
        Me.GroupBox10.Controls.Add(Me.cmdLastRecord)
        Me.GroupBox10.Controls.Add(Me.cmdNextRecord)
        Me.GroupBox10.Controls.Add(Me.txtbssNavigator)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox10.Location = New System.Drawing.Point(0, 263)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(542, 31)
        Me.GroupBox10.TabIndex = 72
        Me.GroupBox10.TabStop = False
        '
        'cmdPrevRecord
        '
        Me.cmdPrevRecord.BackgroundImage = CType(resources.GetObject("cmdPrevRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrevRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPrevRecord.Location = New System.Drawing.Point(34, 6)
        Me.cmdPrevRecord.Name = "cmdPrevRecord"
        Me.cmdPrevRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdPrevRecord.TabIndex = 4
        Me.cmdPrevRecord.UseVisualStyleBackColor = True
        '
        'cmdFirstRecord
        '
        Me.cmdFirstRecord.BackgroundImage = CType(resources.GetObject("cmdFirstRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdFirstRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFirstRecord.Location = New System.Drawing.Point(0, 6)
        Me.cmdFirstRecord.Name = "cmdFirstRecord"
        Me.cmdFirstRecord.Size = New System.Drawing.Size(35, 24)
        Me.cmdFirstRecord.TabIndex = 3
        Me.cmdFirstRecord.UseVisualStyleBackColor = True
        '
        'cmdLastRecord
        '
        Me.cmdLastRecord.BackgroundImage = CType(resources.GetObject("cmdLastRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdLastRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLastRecord.Location = New System.Drawing.Point(436, 6)
        Me.cmdLastRecord.Name = "cmdLastRecord"
        Me.cmdLastRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdLastRecord.TabIndex = 2
        Me.cmdLastRecord.UseVisualStyleBackColor = True
        '
        'cmdNextRecord
        '
        Me.cmdNextRecord.BackgroundImage = CType(resources.GetObject("cmdNextRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdNextRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNextRecord.Location = New System.Drawing.Point(401, 6)
        Me.cmdNextRecord.Name = "cmdNextRecord"
        Me.cmdNextRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdNextRecord.TabIndex = 1
        Me.cmdNextRecord.UseVisualStyleBackColor = True
        '
        'txtbssNavigator
        '
        Me.txtbssNavigator.Location = New System.Drawing.Point(70, 8)
        Me.txtbssNavigator.Name = "txtbssNavigator"
        Me.txtbssNavigator.Size = New System.Drawing.Size(333, 20)
        Me.txtbssNavigator.TabIndex = 0
        Me.txtbssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(105, 106)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(99, 13)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "FTP Transfer Mode"
        '
        'lblbaseStation
        '
        Me.lblbaseStation.AutoSize = True
        Me.lblbaseStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbaseStation.Location = New System.Drawing.Point(201, 13)
        Me.lblbaseStation.Name = "lblbaseStation"
        Me.lblbaseStation.Size = New System.Drawing.Size(79, 13)
        Me.lblbaseStation.TabIndex = 30
        Me.lblbaseStation.Text = "Base Station"
        '
        'cmdBstDelete
        '
        Me.cmdBstDelete.Location = New System.Drawing.Point(448, 232)
        Me.cmdBstDelete.Name = "cmdBstDelete"
        Me.cmdBstDelete.Size = New System.Drawing.Size(62, 21)
        Me.cmdBstDelete.TabIndex = 14
        Me.cmdBstDelete.Text = "Delete"
        Me.cmdBstDelete.UseVisualStyleBackColor = True
        '
        'cmdBsstUpdate
        '
        Me.cmdBsstUpdate.Location = New System.Drawing.Point(196, 232)
        Me.cmdBsstUpdate.Name = "cmdBsstUpdate"
        Me.cmdBsstUpdate.Size = New System.Drawing.Size(62, 21)
        Me.cmdBsstUpdate.TabIndex = 12
        Me.cmdBsstUpdate.Text = "Update"
        Me.cmdBsstUpdate.UseVisualStyleBackColor = True
        '
        'cmdBstSave
        '
        Me.cmdBstSave.Location = New System.Drawing.Point(112, 232)
        Me.cmdBstSave.Name = "cmdBstSave"
        Me.cmdBstSave.Size = New System.Drawing.Size(62, 21)
        Me.cmdBstSave.TabIndex = 11
        Me.cmdBstSave.Text = "Save"
        Me.cmdBstSave.UseVisualStyleBackColor = True
        '
        'txtbaseStationPWConfirm
        '
        Me.txtbaseStationPWConfirm.Location = New System.Drawing.Point(244, 195)
        Me.txtbaseStationPWConfirm.Name = "txtbaseStationPWConfirm"
        Me.txtbaseStationPWConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPWConfirm.Size = New System.Drawing.Size(87, 20)
        Me.txtbaseStationPWConfirm.TabIndex = 10
        '
        'txtbaseStationPW
        '
        Me.txtbaseStationPW.Location = New System.Drawing.Point(244, 164)
        Me.txtbaseStationPW.Name = "txtbaseStationPW"
        Me.txtbaseStationPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPW.Size = New System.Drawing.Size(87, 20)
        Me.txtbaseStationPW.TabIndex = 9
        '
        'txtBaseStationUser
        '
        Me.txtBaseStationUser.Location = New System.Drawing.Point(244, 133)
        Me.txtBaseStationUser.Name = "txtBaseStationUser"
        Me.txtBaseStationUser.Size = New System.Drawing.Size(87, 20)
        Me.txtBaseStationUser.TabIndex = 8
        '
        'txtBaseStationFolder
        '
        Me.txtBaseStationFolder.Location = New System.Drawing.Point(244, 71)
        Me.txtBaseStationFolder.Name = "txtBaseStationFolder"
        Me.txtBaseStationFolder.Size = New System.Drawing.Size(117, 20)
        Me.txtBaseStationFolder.TabIndex = 6
        '
        'txtBaseStationAddress
        '
        Me.txtBaseStationAddress.Location = New System.Drawing.Point(244, 40)
        Me.txtBaseStationAddress.Name = "txtBaseStationAddress"
        Me.txtBaseStationAddress.Size = New System.Drawing.Size(187, 20)
        Me.txtBaseStationAddress.TabIndex = 5
        '
        'lblConfirmInputPW
        '
        Me.lblConfirmInputPW.AutoSize = True
        Me.lblConfirmInputPW.Location = New System.Drawing.Point(105, 199)
        Me.lblConfirmInputPW.Name = "lblConfirmInputPW"
        Me.lblConfirmInputPW.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmInputPW.TabIndex = 4
        Me.lblConfirmInputPW.Text = "Confirm Password"
        '
        'lblInputPW
        '
        Me.lblInputPW.AutoSize = True
        Me.lblInputPW.Location = New System.Drawing.Point(105, 168)
        Me.lblInputPW.Name = "lblInputPW"
        Me.lblInputPW.Size = New System.Drawing.Size(56, 13)
        Me.lblInputPW.TabIndex = 3
        Me.lblInputPW.Text = "PassWord"
        '
        'lblInputUser
        '
        Me.lblInputUser.AutoSize = True
        Me.lblInputUser.Location = New System.Drawing.Point(104, 137)
        Me.lblInputUser.Name = "lblInputUser"
        Me.lblInputUser.Size = New System.Drawing.Size(60, 13)
        Me.lblInputUser.TabIndex = 2
        Me.lblInputUser.Text = "User Name"
        '
        'lblFTPFolder
        '
        Me.lblFTPFolder.AutoSize = True
        Me.lblFTPFolder.Location = New System.Drawing.Point(105, 75)
        Me.lblFTPFolder.Name = "lblFTPFolder"
        Me.lblFTPFolder.Size = New System.Drawing.Size(63, 13)
        Me.lblFTPFolder.TabIndex = 1
        Me.lblFTPFolder.Text = "Input Folder"
        '
        'lblBaseStationFTP
        '
        Me.lblBaseStationFTP.AutoSize = True
        Me.lblBaseStationFTP.Location = New System.Drawing.Point(104, 44)
        Me.lblBaseStationFTP.Name = "lblBaseStationFTP"
        Me.lblBaseStationFTP.Size = New System.Drawing.Size(68, 13)
        Me.lblBaseStationFTP.TabIndex = 0
        Me.lblBaseStationFTP.Text = "FTP Address"
        '
        'cmdMSS
        '
        Me.cmdMSS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMSS.Location = New System.Drawing.Point(341, 44)
        Me.cmdMSS.Name = "cmdMSS"
        Me.cmdMSS.Size = New System.Drawing.Size(134, 28)
        Me.cmdMSS.TabIndex = 1
        Me.cmdMSS.Text = "Message Switch"
        Me.cmdMSS.UseVisualStyleBackColor = True
        '
        'cmdBaseStation
        '
        Me.cmdBaseStation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBaseStation.Location = New System.Drawing.Point(210, 44)
        Me.cmdBaseStation.Name = "cmdBaseStation"
        Me.cmdBaseStation.Size = New System.Drawing.Size(134, 28)
        Me.cmdBaseStation.TabIndex = 0
        Me.cmdBaseStation.Text = "Base Station"
        Me.cmdBaseStation.UseVisualStyleBackColor = True
        '
        'pnlMSS
        '
        Me.pnlMSS.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlMSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSS.Controls.Add(Me.lstFolders)
        Me.pnlMSS.Controls.Add(Me.cmdMssAddNew)
        Me.pnlMSS.Controls.Add(Me.cmdMssRefresh)
        Me.pnlMSS.Controls.Add(Me.cmdMssReset)
        Me.pnlMSS.Controls.Add(Me.txtmssFTPMode)
        Me.pnlMSS.Controls.Add(Me.GroupBox1)
        Me.pnlMSS.Controls.Add(Me.lblFtpTransferMode)
        Me.pnlMSS.Controls.Add(Me.lblMsgSwitch)
        Me.pnlMSS.Controls.Add(Me.cmdMssDelete)
        Me.pnlMSS.Controls.Add(Me.cmdMssUpdate)
        Me.pnlMSS.Controls.Add(Me.cmdMssSave)
        Me.pnlMSS.Controls.Add(Me.txtMSSConfirm)
        Me.pnlMSS.Controls.Add(Me.txtMSSPW)
        Me.pnlMSS.Controls.Add(Me.txtmssUser)
        Me.pnlMSS.Controls.Add(Me.txtMSSFolder)
        Me.pnlMSS.Controls.Add(Me.txtMSSAddress)
        Me.pnlMSS.Controls.Add(Me.lblmssConfirmPassword)
        Me.pnlMSS.Controls.Add(Me.Label5)
        Me.pnlMSS.Controls.Add(Me.Label6)
        Me.pnlMSS.Controls.Add(Me.Label7)
        Me.pnlMSS.Controls.Add(Me.Label8)
        Me.pnlMSS.Enabled = False
        Me.pnlMSS.Location = New System.Drawing.Point(105, 91)
        Me.pnlMSS.Name = "pnlMSS"
        Me.pnlMSS.Size = New System.Drawing.Size(474, 287)
        Me.pnlMSS.TabIndex = 3
        '
        'lstFolders
        '
        Me.lstFolders.FormattingEnabled = True
        Me.lstFolders.Items.AddRange(New Object() {"binary", "ASC"})
        Me.lstFolders.Location = New System.Drawing.Point(317, 66)
        Me.lstFolders.Name = "lstFolders"
        Me.lstFolders.Size = New System.Drawing.Size(90, 17)
        Me.lstFolders.TabIndex = 78
        '
        'cmdMssAddNew
        '
        Me.cmdMssAddNew.Location = New System.Drawing.Point(22, 224)
        Me.cmdMssAddNew.Name = "cmdMssAddNew"
        Me.cmdMssAddNew.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssAddNew.TabIndex = 77
        Me.cmdMssAddNew.Text = "AddNew"
        Me.cmdMssAddNew.UseVisualStyleBackColor = True
        '
        'cmdMssRefresh
        '
        Me.cmdMssRefresh.Location = New System.Drawing.Point(322, 226)
        Me.cmdMssRefresh.Name = "cmdMssRefresh"
        Me.cmdMssRefresh.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssRefresh.TabIndex = 76
        Me.cmdMssRefresh.Text = "Refresh"
        Me.cmdMssRefresh.UseVisualStyleBackColor = True
        '
        'cmdMssReset
        '
        Me.cmdMssReset.Location = New System.Drawing.Point(244, 226)
        Me.cmdMssReset.Name = "cmdMssReset"
        Me.cmdMssReset.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssReset.TabIndex = 75
        Me.cmdMssReset.Text = "Reset"
        Me.cmdMssReset.UseVisualStyleBackColor = True
        '
        'txtmssFTPMode
        '
        Me.txtmssFTPMode.FormattingEnabled = True
        Me.txtmssFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtmssFTPMode.Location = New System.Drawing.Point(194, 94)
        Me.txtmssFTPMode.Name = "txtmssFTPMode"
        Me.txtmssFTPMode.Size = New System.Drawing.Size(116, 21)
        Me.txtmssFTPMode.TabIndex = 74
        Me.txtmssFTPMode.Text = "FTP"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdmssPrev)
        Me.GroupBox1.Controls.Add(Me.cmdmssfirst)
        Me.GroupBox1.Controls.Add(Me.cmdmssLast)
        Me.GroupBox1.Controls.Add(Me.cmdmssNext)
        Me.GroupBox1.Controls.Add(Me.txtmssNavigator)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 249)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 36)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'cmdmssPrev
        '
        Me.cmdmssPrev.BackgroundImage = CType(resources.GetObject("cmdmssPrev.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssPrev.Location = New System.Drawing.Point(34, 6)
        Me.cmdmssPrev.Name = "cmdmssPrev"
        Me.cmdmssPrev.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssPrev.TabIndex = 4
        Me.cmdmssPrev.UseVisualStyleBackColor = True
        '
        'cmdmssfirst
        '
        Me.cmdmssfirst.BackgroundImage = CType(resources.GetObject("cmdmssfirst.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssfirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssfirst.Location = New System.Drawing.Point(0, 6)
        Me.cmdmssfirst.Name = "cmdmssfirst"
        Me.cmdmssfirst.Size = New System.Drawing.Size(35, 24)
        Me.cmdmssfirst.TabIndex = 3
        Me.cmdmssfirst.UseVisualStyleBackColor = True
        '
        'cmdmssLast
        '
        Me.cmdmssLast.BackgroundImage = CType(resources.GetObject("cmdmssLast.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssLast.Location = New System.Drawing.Point(436, 6)
        Me.cmdmssLast.Name = "cmdmssLast"
        Me.cmdmssLast.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssLast.TabIndex = 2
        Me.cmdmssLast.UseVisualStyleBackColor = True
        '
        'cmdmssNext
        '
        Me.cmdmssNext.BackgroundImage = CType(resources.GetObject("cmdmssNext.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssNext.Location = New System.Drawing.Point(401, 6)
        Me.cmdmssNext.Name = "cmdmssNext"
        Me.cmdmssNext.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssNext.TabIndex = 1
        Me.cmdmssNext.UseVisualStyleBackColor = True
        '
        'txtmssNavigator
        '
        Me.txtmssNavigator.Location = New System.Drawing.Point(70, 8)
        Me.txtmssNavigator.Name = "txtmssNavigator"
        Me.txtmssNavigator.Size = New System.Drawing.Size(333, 20)
        Me.txtmssNavigator.TabIndex = 0
        Me.txtmssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFtpTransferMode
        '
        Me.lblFtpTransferMode.AutoSize = True
        Me.lblFtpTransferMode.Location = New System.Drawing.Point(92, 97)
        Me.lblFtpTransferMode.Name = "lblFtpTransferMode"
        Me.lblFtpTransferMode.Size = New System.Drawing.Size(99, 13)
        Me.lblFtpTransferMode.TabIndex = 14
        Me.lblFtpTransferMode.Text = "FTP Transfer Mode"
        '
        'lblMsgSwitch
        '
        Me.lblMsgSwitch.AutoSize = True
        Me.lblMsgSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgSwitch.Location = New System.Drawing.Point(202, 10)
        Me.lblMsgSwitch.Name = "lblMsgSwitch"
        Me.lblMsgSwitch.Size = New System.Drawing.Size(99, 13)
        Me.lblMsgSwitch.TabIndex = 13
        Me.lblMsgSwitch.Text = "Message Switch"
        '
        'cmdMssDelete
        '
        Me.cmdMssDelete.Location = New System.Drawing.Point(400, 226)
        Me.cmdMssDelete.Name = "cmdMssDelete"
        Me.cmdMssDelete.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssDelete.TabIndex = 12
        Me.cmdMssDelete.Text = "Delete"
        Me.cmdMssDelete.UseVisualStyleBackColor = True
        '
        'cmdMssUpdate
        '
        Me.cmdMssUpdate.Location = New System.Drawing.Point(166, 226)
        Me.cmdMssUpdate.Name = "cmdMssUpdate"
        Me.cmdMssUpdate.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssUpdate.TabIndex = 11
        Me.cmdMssUpdate.Text = "Update"
        Me.cmdMssUpdate.UseVisualStyleBackColor = True
        '
        'cmdMssSave
        '
        Me.cmdMssSave.Location = New System.Drawing.Point(90, 224)
        Me.cmdMssSave.Name = "cmdMssSave"
        Me.cmdMssSave.Size = New System.Drawing.Size(59, 21)
        Me.cmdMssSave.TabIndex = 10
        Me.cmdMssSave.Text = "Save"
        Me.cmdMssSave.UseVisualStyleBackColor = True
        '
        'txtMSSConfirm
        '
        Me.txtMSSConfirm.Location = New System.Drawing.Point(194, 180)
        Me.txtMSSConfirm.Name = "txtMSSConfirm"
        Me.txtMSSConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSConfirm.Size = New System.Drawing.Size(81, 20)
        Me.txtMSSConfirm.TabIndex = 10
        '
        'txtMSSPW
        '
        Me.txtMSSPW.Location = New System.Drawing.Point(194, 151)
        Me.txtMSSPW.Name = "txtMSSPW"
        Me.txtMSSPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSPW.Size = New System.Drawing.Size(81, 20)
        Me.txtMSSPW.TabIndex = 9
        '
        'txtmssUser
        '
        Me.txtmssUser.Location = New System.Drawing.Point(194, 122)
        Me.txtmssUser.Name = "txtmssUser"
        Me.txtmssUser.Size = New System.Drawing.Size(81, 20)
        Me.txtmssUser.TabIndex = 8
        '
        'txtMSSFolder
        '
        Me.txtMSSFolder.Location = New System.Drawing.Point(194, 64)
        Me.txtMSSFolder.Name = "txtMSSFolder"
        Me.txtMSSFolder.Size = New System.Drawing.Size(121, 20)
        Me.txtMSSFolder.TabIndex = 6
        '
        'txtMSSAddress
        '
        Me.txtMSSAddress.Location = New System.Drawing.Point(194, 35)
        Me.txtMSSAddress.Name = "txtMSSAddress"
        Me.txtMSSAddress.Size = New System.Drawing.Size(214, 20)
        Me.txtMSSAddress.TabIndex = 5
        '
        'lblmssConfirmPassword
        '
        Me.lblmssConfirmPassword.AutoSize = True
        Me.lblmssConfirmPassword.Location = New System.Drawing.Point(91, 184)
        Me.lblmssConfirmPassword.Name = "lblmssConfirmPassword"
        Me.lblmssConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblmssConfirmPassword.TabIndex = 4
        Me.lblmssConfirmPassword.Text = "Confirm Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(92, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(90, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "User Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(91, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Input Folder"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(91, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "FTP Address"
        '
        'pnlMsgEncoding
        '
        Me.pnlMsgEncoding.BackColor = System.Drawing.Color.Linen
        Me.pnlMsgEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox6)
        Me.pnlMsgEncoding.Controls.Add(Me.grpIndicators)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox5)
        Me.pnlMsgEncoding.Location = New System.Drawing.Point(203, 435)
        Me.pnlMsgEncoding.Name = "pnlMsgEncoding"
        Me.pnlMsgEncoding.Size = New System.Drawing.Size(753, 57)
        Me.pnlMsgEncoding.TabIndex = 4
        Me.pnlMsgEncoding.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgrdCodeFlag)
        Me.GroupBox6.Location = New System.Drawing.Point(333, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(413, 466)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Code and Flags"
        '
        'dgrdCodeFlag
        '
        Me.dgrdCodeFlag.BackgroundColor = System.Drawing.Color.Ivory
        Me.dgrdCodeFlag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrdCodeFlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdCodeFlag.Location = New System.Drawing.Point(3, 16)
        Me.dgrdCodeFlag.Name = "dgrdCodeFlag"
        Me.dgrdCodeFlag.Size = New System.Drawing.Size(407, 447)
        Me.dgrdCodeFlag.TabIndex = 0
        '
        'grpIndicators
        '
        Me.grpIndicators.Controls.Add(Me.cmdDefault)
        Me.grpIndicators.Controls.Add(Me.cmdSaves)
        Me.grpIndicators.Controls.Add(Me.cmdUpadate)
        Me.grpIndicators.Controls.Add(Me.cmdNew)
        Me.grpIndicators.Controls.Add(Me.chkOptionalSection)
        Me.grpIndicators.Controls.Add(Me.txtLocaltableVersion)
        Me.grpIndicators.Controls.Add(Me.txtMastertableVersion)
        Me.grpIndicators.Controls.Add(Me.txtLocalSubcategory)
        Me.grpIndicators.Controls.Add(Me.txtInternationalSubcategory)
        Me.grpIndicators.Controls.Add(Me.txtDataCategory)
        Me.grpIndicators.Controls.Add(Me.txtUpdateSequence)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingSubcentre)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingCentre)
        Me.grpIndicators.Controls.Add(Me.txtBufrEdition)
        Me.grpIndicators.Controls.Add(Me.Label25)
        Me.grpIndicators.Controls.Add(Me.Label26)
        Me.grpIndicators.Controls.Add(Me.Label27)
        Me.grpIndicators.Controls.Add(Me.Label28)
        Me.grpIndicators.Controls.Add(Me.Label29)
        Me.grpIndicators.Controls.Add(Me.txtUpdateSequenceNumber)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingSubCentre)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingCentre)
        Me.grpIndicators.Controls.Add(Me.Label34)
        Me.grpIndicators.Location = New System.Drawing.Point(9, 159)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Size = New System.Drawing.Size(321, 323)
        Me.grpIndicators.TabIndex = 1
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Text = "BUFR Section 2"
        '
        'cmdDefault
        '
        Me.cmdDefault.Location = New System.Drawing.Point(213, 291)
        Me.cmdDefault.Name = "cmdDefault"
        Me.cmdDefault.Size = New System.Drawing.Size(75, 20)
        Me.cmdDefault.TabIndex = 24
        Me.cmdDefault.Text = "Set Default"
        Me.cmdDefault.UseVisualStyleBackColor = True
        '
        'cmdSaves
        '
        Me.cmdSaves.Location = New System.Drawing.Point(75, 291)
        Me.cmdSaves.Name = "cmdSaves"
        Me.cmdSaves.Size = New System.Drawing.Size(59, 20)
        Me.cmdSaves.TabIndex = 23
        Me.cmdSaves.Text = "Save"
        Me.cmdSaves.UseVisualStyleBackColor = True
        '
        'cmdUpadate
        '
        Me.cmdUpadate.Location = New System.Drawing.Point(142, 291)
        Me.cmdUpadate.Name = "cmdUpadate"
        Me.cmdUpadate.Size = New System.Drawing.Size(63, 20)
        Me.cmdUpadate.TabIndex = 22
        Me.cmdUpadate.Text = "Update"
        Me.cmdUpadate.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(8, 291)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(59, 20)
        Me.cmdNew.TabIndex = 21
        Me.cmdNew.Text = "AddNew"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'chkOptionalSection
        '
        Me.chkOptionalSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOptionalSection.Location = New System.Drawing.Point(15, 123)
        Me.chkOptionalSection.Name = "chkOptionalSection"
        Me.chkOptionalSection.Size = New System.Drawing.Size(256, 17)
        Me.chkOptionalSection.TabIndex = 20
        Me.chkOptionalSection.Tag = "  "
        Me.chkOptionalSection.Text = "Option Section Inclusion"
        Me.chkOptionalSection.UseVisualStyleBackColor = True
        '
        'txtLocaltableVersion
        '
        Me.txtLocaltableVersion.Location = New System.Drawing.Point(256, 225)
        Me.txtLocaltableVersion.Name = "txtLocaltableVersion"
        Me.txtLocaltableVersion.Size = New System.Drawing.Size(60, 20)
        Me.txtLocaltableVersion.TabIndex = 19
        '
        'txtMastertableVersion
        '
        Me.txtMastertableVersion.Location = New System.Drawing.Point(256, 204)
        Me.txtMastertableVersion.Name = "txtMastertableVersion"
        Me.txtMastertableVersion.Size = New System.Drawing.Size(60, 20)
        Me.txtMastertableVersion.TabIndex = 18
        '
        'txtLocalSubcategory
        '
        Me.txtLocalSubcategory.Location = New System.Drawing.Point(256, 183)
        Me.txtLocalSubcategory.Name = "txtLocalSubcategory"
        Me.txtLocalSubcategory.Size = New System.Drawing.Size(60, 20)
        Me.txtLocalSubcategory.TabIndex = 17
        '
        'txtInternationalSubcategory
        '
        Me.txtInternationalSubcategory.Location = New System.Drawing.Point(256, 162)
        Me.txtInternationalSubcategory.Name = "txtInternationalSubcategory"
        Me.txtInternationalSubcategory.Size = New System.Drawing.Size(60, 20)
        Me.txtInternationalSubcategory.TabIndex = 16
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(256, 141)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(60, 20)
        Me.txtDataCategory.TabIndex = 15
        '
        'txtUpdateSequence
        '
        Me.txtUpdateSequence.Location = New System.Drawing.Point(256, 99)
        Me.txtUpdateSequence.Name = "txtUpdateSequence"
        Me.txtUpdateSequence.Size = New System.Drawing.Size(60, 20)
        Me.txtUpdateSequence.TabIndex = 13
        '
        'txtOriginatingSubcentre
        '
        Me.txtOriginatingSubcentre.Location = New System.Drawing.Point(256, 78)
        Me.txtOriginatingSubcentre.Name = "txtOriginatingSubcentre"
        Me.txtOriginatingSubcentre.Size = New System.Drawing.Size(60, 20)
        Me.txtOriginatingSubcentre.TabIndex = 12
        '
        'txtOriginatingCentre
        '
        Me.txtOriginatingCentre.Location = New System.Drawing.Point(256, 57)
        Me.txtOriginatingCentre.Name = "txtOriginatingCentre"
        Me.txtOriginatingCentre.Size = New System.Drawing.Size(60, 20)
        Me.txtOriginatingCentre.TabIndex = 11
        '
        'txtBufrEdition
        '
        Me.txtBufrEdition.Location = New System.Drawing.Point(256, 36)
        Me.txtBufrEdition.Name = "txtBufrEdition"
        Me.txtBufrEdition.Size = New System.Drawing.Size(60, 20)
        Me.txtBufrEdition.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(14, 229)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 13)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Local Table Version No."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 208)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(127, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Master Table Version No."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 187)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Local Data Sub-Category"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 166)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(158, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "International Data Sub-Category"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(15, 145)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 13)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Data Category"
        '
        'txtUpdateSequenceNumber
        '
        Me.txtUpdateSequenceNumber.AutoSize = True
        Me.txtUpdateSequenceNumber.Location = New System.Drawing.Point(15, 103)
        Me.txtUpdateSequenceNumber.Name = "txtUpdateSequenceNumber"
        Me.txtUpdateSequenceNumber.Size = New System.Drawing.Size(114, 13)
        Me.txtUpdateSequenceNumber.TabIndex = 3
        Me.txtUpdateSequenceNumber.Text = "Update Sequence No."
        '
        'txtOriginatingGeneratingSubCentre
        '
        Me.txtOriginatingGeneratingSubCentre.AutoSize = True
        Me.txtOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(15, 82)
        Me.txtOriginatingGeneratingSubCentre.Name = "txtOriginatingGeneratingSubCentre"
        Me.txtOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(170, 13)
        Me.txtOriginatingGeneratingSubCentre.TabIndex = 2
        Me.txtOriginatingGeneratingSubCentre.Text = "Originating/Generating Sub-Centre"
        '
        'txtOriginatingGeneratingCentre
        '
        Me.txtOriginatingGeneratingCentre.AutoSize = True
        Me.txtOriginatingGeneratingCentre.Location = New System.Drawing.Point(15, 61)
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        Me.txtOriginatingGeneratingCentre.Size = New System.Drawing.Size(148, 13)
        Me.txtOriginatingGeneratingCentre.TabIndex = 1
        Me.txtOriginatingGeneratingCentre.Text = "Originating/Generating Centre"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(15, 40)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(91, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "BUFR Edition No."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTemplate)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtMsgHeader)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 29)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(321, 104)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        Me.GroupBox5.Text = "Header and Templates"
        '
        'txtTemplate
        '
        Me.txtTemplate.FormattingEnabled = True
        Me.txtTemplate.Location = New System.Drawing.Point(143, 33)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(177, 21)
        Me.txtTemplate.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 13)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Encoding Template"
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(200, 67)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(117, 20)
        Me.txtMsgHeader.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(8, 71)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(160, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Message Header (TTAAii CCCC)"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'formAWSRealTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 615)
        Me.Controls.Add(Me.pnlServers)
        Me.Controls.Add(Me.pnlMsgEncoding)
        Me.Controls.Add(Me.pnlControl)
        Me.Controls.Add(Me.pnlSites)
        Me.KeyPreview = True
        Me.Name = "formAWSRealTime"
        Me.Text = "AWS Real Time"
        Me.pnlControl.ResumeLayout(False)
        Me.pnlSites.ResumeLayout(False)
        Me.grpSites.ResumeLayout(False)
        Me.grpSites.PerformLayout()
        CType(Me.DataGridViewSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlServers.ResumeLayout(False)
        Me.pnlBaseStation.ResumeLayout(False)
        Me.pnlBaseStation.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.pnlMSS.ResumeLayout(False)
        Me.pnlMSS.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlMsgEncoding.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgrdCodeFlag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIndicators.ResumeLayout(False)
        Me.grpIndicators.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlControl As System.Windows.Forms.Panel
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdServers As System.Windows.Forms.Button
    Friend WithEvents cmdProcess As System.Windows.Forms.Button
    Friend WithEvents pnlProcessing As System.Windows.Forms.Panel
    Friend WithEvents pnlServers As System.Windows.Forms.Panel
    Friend WithEvents cmdSites As System.Windows.Forms.Button
    Friend WithEvents cmdMessages As System.Windows.Forms.Button
    Friend WithEvents cmdDataStructures As System.Windows.Forms.Button
    Friend WithEvents lblErrors As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlOutput As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblInputData As System.Windows.Forms.Label
    Friend WithEvents lblInformation As System.Windows.Forms.Label
    Friend WithEvents txtInputServer As System.Windows.Forms.TextBox
    Friend WithEvents lblSever As System.Windows.Forms.Label
    Friend WithEvents txtInputfolder As System.Windows.Forms.TextBox
    Friend WithEvents lblInputFolder As System.Windows.Forms.Label
    Friend WithEvents lblInputFiles As System.Windows.Forms.Label
    Friend WithEvents lstInputFiles As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstOutputFiles As System.Windows.Forms.ListBox
    Friend WithEvents txtOutputFolder As System.Windows.Forms.TextBox
    Friend WithEvents lblOutputFolder As System.Windows.Forms.Label
    Friend WithEvents txtOutputServer As System.Windows.Forms.TextBox
    Friend WithEvents lblOutputFTP As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDateTime As System.Windows.Forms.TextBox
    Friend WithEvents lblDatetime As System.Windows.Forms.Label
    Friend WithEvents lblSatus As System.Windows.Forms.Label
    Friend WithEvents txtNxtProcess As System.Windows.Forms.TextBox
    Friend WithEvents txtNextProcess As System.Windows.Forms.Label
    Friend WithEvents txtLastProcess As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdMSS As System.Windows.Forms.Button
    Friend WithEvents cmdBaseStation As System.Windows.Forms.Button
    Friend WithEvents pnlMSS As System.Windows.Forms.Panel
    Friend WithEvents cmdMssDelete As System.Windows.Forms.Button
    Friend WithEvents cmdMssUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdMssSave As System.Windows.Forms.Button
    Friend WithEvents txtMSSConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtMSSPW As System.Windows.Forms.TextBox
    Friend WithEvents txtmssUser As System.Windows.Forms.TextBox
    Friend WithEvents txtMSSFolder As System.Windows.Forms.TextBox
    Friend WithEvents txtMSSAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblmssConfirmPassword As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlSites As System.Windows.Forms.Panel
    Friend WithEvents pnlMsgEncoding As System.Windows.Forms.Panel
    Friend WithEvents pnlDataStructures As System.Windows.Forms.Panel
    Friend WithEvents pnlBaseStation As System.Windows.Forms.Panel
    Friend WithEvents cmdBstDelete As System.Windows.Forms.Button
    Friend WithEvents cmdBsstUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdBstSave As System.Windows.Forms.Button
    Friend WithEvents txtbaseStationPWConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtbaseStationPW As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseStationUser As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseStationAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmInputPW As System.Windows.Forms.Label
    Friend WithEvents lblInputPW As System.Windows.Forms.Label
    Friend WithEvents lblInputUser As System.Windows.Forms.Label
    Friend WithEvents lblBaseStationFTP As System.Windows.Forms.Label
    Friend WithEvents grpStructures1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpStructures As System.Windows.Forms.GroupBox
    Friend WithEvents txtQualifier As System.Windows.Forms.TextBox
    Friend WithEvents txtHeaders As System.Windows.Forms.TextBox
    Friend WithEvents txtStrName As System.Windows.Forms.TextBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblStrName As System.Windows.Forms.Label
    Friend WithEvents cmbExistingStructures As System.Windows.Forms.ComboBox
    Friend WithEvents grpElements As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgrdCodeFlag As System.Windows.Forms.DataGridView
    Friend WithEvents grpIndicators As System.Windows.Forms.GroupBox
    Friend WithEvents chkOptionalSection As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocaltableVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtMastertableVersion As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalSubcategory As System.Windows.Forms.TextBox
    Friend WithEvents txtInternationalSubcategory As System.Windows.Forms.TextBox
    Friend WithEvents txtDataCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdateSequence As System.Windows.Forms.TextBox
    Friend WithEvents txtOriginatingSubcentre As System.Windows.Forms.TextBox
    Friend WithEvents txtBufrEdition As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateSequenceNumber As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingGeneratingSubCentre As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingGeneratingCentre As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtMsgHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pnlProcessSettings As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents chkDeleteFile As System.Windows.Forms.CheckBox
    Friend WithEvents txtTimeout As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents optStop As System.Windows.Forms.RadioButton
    Friend WithEvents optStart As System.Windows.Forms.RadioButton
    Friend WithEvents lblMsgSwitch As System.Windows.Forms.Label
    Friend WithEvents lblbaseStation As System.Windows.Forms.Label
    Friend WithEvents lblFtpTransferMode As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPrevRecord As System.Windows.Forms.Button
    Friend WithEvents cmdFirstRecord As System.Windows.Forms.Button
    Friend WithEvents cmdLastRecord As System.Windows.Forms.Button
    Friend WithEvents cmdNextRecord As System.Windows.Forms.Button
    Friend WithEvents txtbssNavigator As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdmssPrev As System.Windows.Forms.Button
    Friend WithEvents cmdmssfirst As System.Windows.Forms.Button
    Friend WithEvents cmdmssLast As System.Windows.Forms.Button
    Friend WithEvents cmdmssNext As System.Windows.Forms.Button
    Friend WithEvents txtmssNavigator As System.Windows.Forms.TextBox
    Friend WithEvents txtBasestationFTPMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdMssRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdMssReset As System.Windows.Forms.Button
    Friend WithEvents txtmssFTPMode As System.Windows.Forms.ComboBox
    Friend WithEvents grpSites As System.Windows.Forms.GroupBox
    Friend WithEvents txtIP As System.Windows.Forms.ComboBox
    Friend WithEvents txtDataStructure As System.Windows.Forms.ComboBox
    Friend WithEvents txtFlag As System.Windows.Forms.TextBox
    Friend WithEvents chkOperational As System.Windows.Forms.CheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtInFile As System.Windows.Forms.TextBox
    Friend WithEvents lblInfile As System.Windows.Forms.Label
    Friend WithEvents txtSiteID As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents txtSitesNavigator As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents cmdViewUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdDel As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateSites As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents txtDelimiter As System.Windows.Forms.ComboBox
    Friend WithEvents lblStructure As System.Windows.Forms.Label
    Friend WithEvents lblRecords As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Ltime As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents list_errors As System.Windows.Forms.ListBox
    Friend WithEvents DataGridViewStructures As System.Windows.Forms.DataGridView
    Friend WithEvents txtGMTDiff As System.Windows.Forms.TextBox
    Friend WithEvents lblGMT As System.Windows.Forms.Label
    Friend WithEvents txtSiteName As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewSites As System.Windows.Forms.DataGridView
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents chkGTSEncode As System.Windows.Forms.CheckBox
    Friend WithEvents txtGTSHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingCentre As System.Windows.Forms.TextBox
    Friend WithEvents txtfilePrefix As System.Windows.Forms.TextBox
    Friend WithEvents chkPrefix As System.Windows.Forms.CheckBox
    Friend WithEvents txtQC As System.Windows.Forms.TextBox
    Friend WithEvents cmdBstAddNew As Button
    Friend WithEvents cmdDefault As Button
    Friend WithEvents cmdSaves As Button
    Friend WithEvents cmdUpadate As Button
    Friend WithEvents cmdNew As Button
    Friend WithEvents cmdMssAddNew As Button
    Friend WithEvents txtBaseStationFolder As TextBox
    Friend WithEvents lblFTPFolder As Label
    Friend WithEvents lstFolders As ListBox
    Friend WithEvents lblEncodeHrs As Label
    Friend WithEvents txtEncode As TextBox
    Friend WithEvents lblEncode As Label
End Class
