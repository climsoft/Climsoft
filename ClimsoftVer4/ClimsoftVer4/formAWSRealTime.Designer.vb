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
        Me.pnlProcessing = New System.Windows.Forms.Panel()
        Me.list_errors = New System.Windows.Forms.ListBox()
        Me.pnlProcessSettings = New System.Windows.Forms.Panel()
        Me.lblEncodeHrs = New System.Windows.Forms.Label()
        Me.txtEncode = New System.Windows.Forms.TextBox()
        Me.lblEncode = New System.Windows.Forms.Label()
        Me.optStart = New System.Windows.Forms.RadioButton()
        Me.txtGMTDiff = New System.Windows.Forms.TextBox()
        Me.lblGMT = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.chkDeleteFile = New System.Windows.Forms.CheckBox()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRetrieveHrs = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOffset = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.optStop = New System.Windows.Forms.RadioButton()
        Me.Ltime = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtQC = New System.Windows.Forms.TextBox()
        Me.txtNxtProcess = New System.Windows.Forms.TextBox()
        Me.lblNextProcess = New System.Windows.Forms.Label()
        Me.txtLastProcess = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDateTime = New System.Windows.Forms.TextBox()
        Me.lblDatetime = New System.Windows.Forms.Label()
        Me.lblSatus = New System.Windows.Forms.Label()
        Me.lblErrors = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstOutputFiles = New System.Windows.Forms.ListBox()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.lblOutputFolder = New System.Windows.Forms.Label()
        Me.txtOutputServer = New System.Windows.Forms.TextBox()
        Me.lblOutputFTP = New System.Windows.Forms.Label()
        Me.pnlOutput = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblInputFiles = New System.Windows.Forms.Label()
        Me.lstInputFiles = New System.Windows.Forms.ListBox()
        Me.txtInputfolder = New System.Windows.Forms.TextBox()
        Me.lblInputFolder = New System.Windows.Forms.Label()
        Me.txtInputServer = New System.Windows.Forms.TextBox()
        Me.lblSever = New System.Windows.Forms.Label()
        Me.lblInputData = New System.Windows.Forms.Label()
        Me.lblInformation = New System.Windows.Forms.Label()
        Me.grpElements = New System.Windows.Forms.GroupBox()
        Me.pnlDataStructures = New System.Windows.Forms.Panel()
        Me.grpStructures1 = New System.Windows.Forms.GroupBox()
        Me.lblStructure = New System.Windows.Forms.Label()
        Me.grpStructures = New System.Windows.Forms.GroupBox()
        Me.cmdClone = New System.Windows.Forms.Button()
        Me.lblRecords = New System.Windows.Forms.Label()
        Me.txtDelimiter = New System.Windows.Forms.ComboBox()
        Me.txtQualifier = New System.Windows.Forms.TextBox()
        Me.txtHeaders = New System.Windows.Forms.TextBox()
        Me.txtStrName = New System.Windows.Forms.TextBox()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblStrName = New System.Windows.Forms.Label()
        Me.cmbExistingStructures = New System.Windows.Forms.ComboBox()
        Me.DataGridViewStructures = New System.Windows.Forms.DataGridView()
        Me.pnlSites = New System.Windows.Forms.Panel()
        Me.grpSites = New System.Windows.Forms.GroupBox()
        Me.optCSV = New System.Windows.Forms.RadioButton()
        Me.optBufr = New System.Windows.Forms.RadioButton()
        Me.txtUTCdiff = New System.Windows.Forms.TextBox()
        Me.lblUTCdiff = New System.Windows.Forms.Label()
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
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.txtHrs = New System.Windows.Forms.TextBox()
        Me.chkHrsAdjust = New System.Windows.Forms.CheckBox()
        Me.pnlServers = New System.Windows.Forms.Panel()
        Me.pnlBaseStation = New System.Windows.Forms.Panel()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmdPrevRecord = New System.Windows.Forms.Button()
        Me.cmdFirstRecord = New System.Windows.Forms.Button()
        Me.cmdLastRecord = New System.Windows.Forms.Button()
        Me.cmdNextRecord = New System.Windows.Forms.Button()
        Me.txtbssNavigator = New System.Windows.Forms.TextBox()
        Me.cmdBstAddNew = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.txtBasestationFTPMode = New System.Windows.Forms.ComboBox()
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
        Me.pnlMSS = New System.Windows.Forms.Panel()
        Me.lblMport = New System.Windows.Forms.Label()
        Me.txtMport = New System.Windows.Forms.TextBox()
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
        Me.cmdMSS = New System.Windows.Forms.Button()
        Me.cmdBaseStation = New System.Windows.Forms.Button()
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
        Me.lblUpdateSequenceNumber = New System.Windows.Forms.Label()
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
        Me.pnlProcessing.SuspendLayout()
        Me.pnlProcessSettings.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlDataStructures.SuspendLayout()
        Me.grpStructures1.SuspendLayout()
        Me.grpStructures.SuspendLayout()
        CType(Me.DataGridViewStructures, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlControl.Size = New System.Drawing.Size(191, 606)
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
        'pnlProcessing
        '
        Me.pnlProcessing.BackColor = System.Drawing.Color.MistyRose
        Me.pnlProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcessing.Controls.Add(Me.list_errors)
        Me.pnlProcessing.Controls.Add(Me.pnlProcessSettings)
        Me.pnlProcessing.Controls.Add(Me.Ltime)
        Me.pnlProcessing.Controls.Add(Me.Panel4)
        Me.pnlProcessing.Controls.Add(Me.lblErrors)
        Me.pnlProcessing.Controls.Add(Me.Panel1)
        Me.pnlProcessing.Controls.Add(Me.grpElements)
        Me.pnlProcessing.Location = New System.Drawing.Point(194, 11)
        Me.pnlProcessing.Name = "pnlProcessing"
        Me.pnlProcessing.Size = New System.Drawing.Size(775, 199)
        Me.pnlProcessing.TabIndex = 1
        Me.pnlProcessing.Visible = False
        '
        'list_errors
        '
        Me.list_errors.FormattingEnabled = True
        Me.list_errors.Location = New System.Drawing.Point(11, 450)
        Me.list_errors.Name = "list_errors"
        Me.list_errors.Size = New System.Drawing.Size(729, 82)
        Me.list_errors.TabIndex = 8
        '
        'pnlProcessSettings
        '
        Me.pnlProcessSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcessSettings.Controls.Add(Me.lblEncodeHrs)
        Me.pnlProcessSettings.Controls.Add(Me.txtEncode)
        Me.pnlProcessSettings.Controls.Add(Me.lblEncode)
        Me.pnlProcessSettings.Controls.Add(Me.optStart)
        Me.pnlProcessSettings.Controls.Add(Me.txtGMTDiff)
        Me.pnlProcessSettings.Controls.Add(Me.lblGMT)
        Me.pnlProcessSettings.Controls.Add(Me.Label9)
        Me.pnlProcessSettings.Controls.Add(Me.cmdSave)
        Me.pnlProcessSettings.Controls.Add(Me.chkDeleteFile)
        Me.pnlProcessSettings.Controls.Add(Me.txtTimeout)
        Me.pnlProcessSettings.Controls.Add(Me.Label10)
        Me.pnlProcessSettings.Controls.Add(Me.lblRetrieveHrs)
        Me.pnlProcessSettings.Controls.Add(Me.txtPeriod)
        Me.pnlProcessSettings.Controls.Add(Me.Label12)
        Me.pnlProcessSettings.Controls.Add(Me.txtOffset)
        Me.pnlProcessSettings.Controls.Add(Me.Label13)
        Me.pnlProcessSettings.Controls.Add(Me.txtInterval)
        Me.pnlProcessSettings.Controls.Add(Me.Label14)
        Me.pnlProcessSettings.Controls.Add(Me.optStop)
        Me.pnlProcessSettings.Location = New System.Drawing.Point(11, 5)
        Me.pnlProcessSettings.Name = "pnlProcessSettings"
        Me.pnlProcessSettings.Size = New System.Drawing.Size(749, 152)
        Me.pnlProcessSettings.TabIndex = 6
        '
        'lblEncodeHrs
        '
        Me.lblEncodeHrs.AutoSize = True
        Me.lblEncodeHrs.Location = New System.Drawing.Point(681, 70)
        Me.lblEncodeHrs.Name = "lblEncodeHrs"
        Me.lblEncodeHrs.Size = New System.Drawing.Size(35, 13)
        Me.lblEncodeHrs.TabIndex = 19
        Me.lblEncodeHrs.Text = "Hours"
        '
        'txtEncode
        '
        Me.txtEncode.Location = New System.Drawing.Point(651, 65)
        Me.txtEncode.Name = "txtEncode"
        Me.txtEncode.Size = New System.Drawing.Size(28, 20)
        Me.txtEncode.TabIndex = 18
        Me.txtEncode.Text = "6"
        Me.txtEncode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEncode
        '
        Me.lblEncode.AutoSize = True
        Me.lblEncode.Location = New System.Drawing.Point(543, 69)
        Me.lblEncode.Name = "lblEncode"
        Me.lblEncode.Size = New System.Drawing.Size(67, 13)
        Me.lblEncode.TabIndex = 17
        Me.lblEncode.Text = "Encode Last"
        '
        'optStart
        '
        Me.optStart.AutoSize = True
        Me.optStart.Location = New System.Drawing.Point(18, 26)
        Me.optStart.Name = "optStart"
        Me.optStart.Size = New System.Drawing.Size(59, 17)
        Me.optStart.TabIndex = 0
        Me.optStart.Text = "Restart"
        Me.optStart.UseVisualStyleBackColor = True
        '
        'txtGMTDiff
        '
        Me.txtGMTDiff.BackColor = System.Drawing.Color.White
        Me.txtGMTDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMTDiff.Location = New System.Drawing.Point(540, 104)
        Me.txtGMTDiff.Name = "txtGMTDiff"
        Me.txtGMTDiff.Size = New System.Drawing.Size(32, 20)
        Me.txtGMTDiff.TabIndex = 16
        Me.txtGMTDiff.Text = "0"
        Me.txtGMTDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtGMTDiff.Visible = False
        '
        'lblGMT
        '
        Me.lblGMT.AutoSize = True
        Me.lblGMT.Location = New System.Drawing.Point(444, 107)
        Me.lblGMT.Name = "lblGMT"
        Me.lblGMT.Size = New System.Drawing.Size(67, 13)
        Me.lblGMT.TabIndex = 15
        Me.lblGMT.Text = "GMT Diff +/-"
        Me.lblGMT.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(229, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 15)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Settings"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(611, 101)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 24)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Save Changes"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'chkDeleteFile
        '
        Me.chkDeleteFile.Location = New System.Drawing.Point(196, 97)
        Me.chkDeleteFile.Name = "chkDeleteFile"
        Me.chkDeleteFile.Size = New System.Drawing.Size(196, 37)
        Me.chkDeleteFile.TabIndex = 11
        Me.chkDeleteFile.Text = "Delete Input File After Processing"
        Me.chkDeleteFile.UseVisualStyleBackColor = True
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(148, 103)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(33, 20)
        Me.txtTimeout.TabIndex = 10
        Me.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Timeout Period (Seconds)"
        '
        'lblRetrieveHrs
        '
        Me.lblRetrieveHrs.AutoSize = True
        Me.lblRetrieveHrs.Location = New System.Drawing.Point(496, 69)
        Me.lblRetrieveHrs.Name = "lblRetrieveHrs"
        Me.lblRetrieveHrs.Size = New System.Drawing.Size(35, 13)
        Me.lblRetrieveHrs.TabIndex = 8
        Me.lblRetrieveHrs.Text = "Hours"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(457, 63)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(33, 20)
        Me.txtPeriod.TabIndex = 7
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(345, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Retrieve Last"
        '
        'txtOffset
        '
        Me.txtOffset.Location = New System.Drawing.Point(297, 62)
        Me.txtOffset.Name = "txtOffset"
        Me.txtOffset.Size = New System.Drawing.Size(33, 20)
        Me.txtOffset.TabIndex = 5
        Me.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(191, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 32)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Hour Offset (Minutes)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(148, 63)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(33, 20)
        Me.txtInterval.TabIndex = 3
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(13, 65)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 32)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Retrieval Interval (Minutes)"
        '
        'optStop
        '
        Me.optStop.AutoSize = True
        Me.optStop.Checked = True
        Me.optStop.Location = New System.Drawing.Point(121, 26)
        Me.optStop.Name = "optStop"
        Me.optStop.Size = New System.Drawing.Size(47, 17)
        Me.optStop.TabIndex = 1
        Me.optStop.TabStop = True
        Me.optStop.Text = "Stop"
        Me.optStop.UseVisualStyleBackColor = True
        '
        'Ltime
        '
        Me.Ltime.AutoSize = True
        Me.Ltime.BackColor = System.Drawing.Color.SeaShell
        Me.Ltime.Location = New System.Drawing.Point(165, 541)
        Me.Ltime.Name = "Ltime"
        Me.Ltime.Size = New System.Drawing.Size(16, 13)
        Me.Ltime.TabIndex = 7
        Me.Ltime.Text = "   "
        Me.Ltime.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtQC)
        Me.Panel4.Controls.Add(Me.txtNxtProcess)
        Me.Panel4.Controls.Add(Me.lblNextProcess)
        Me.Panel4.Controls.Add(Me.txtLastProcess)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.ProgressBar1)
        Me.Panel4.Controls.Add(Me.txtStatus)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtDateTime)
        Me.Panel4.Controls.Add(Me.lblDatetime)
        Me.Panel4.Controls.Add(Me.lblSatus)
        Me.Panel4.Location = New System.Drawing.Point(430, 163)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(330, 268)
        Me.Panel4.TabIndex = 4
        '
        'txtQC
        '
        Me.txtQC.BackColor = System.Drawing.Color.MistyRose
        Me.txtQC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQC.Location = New System.Drawing.Point(4, 209)
        Me.txtQC.Multiline = True
        Me.txtQC.Name = "txtQC"
        Me.txtQC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQC.Size = New System.Drawing.Size(299, 53)
        Me.txtQC.TabIndex = 21
        '
        'txtNxtProcess
        '
        Me.txtNxtProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtNxtProcess.Enabled = False
        Me.txtNxtProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNxtProcess.Location = New System.Drawing.Point(136, 107)
        Me.txtNxtProcess.Name = "txtNxtProcess"
        Me.txtNxtProcess.Size = New System.Drawing.Size(164, 20)
        Me.txtNxtProcess.TabIndex = 19
        '
        'lblNextProcess
        '
        Me.lblNextProcess.AutoSize = True
        Me.lblNextProcess.Location = New System.Drawing.Point(137, 88)
        Me.lblNextProcess.Name = "lblNextProcess"
        Me.lblNextProcess.Size = New System.Drawing.Size(84, 13)
        Me.lblNextProcess.TabIndex = 18
        Me.lblNextProcess.Text = "Next Processing"
        '
        'txtLastProcess
        '
        Me.txtLastProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtLastProcess.Enabled = False
        Me.txtLastProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastProcess.Location = New System.Drawing.Point(6, 107)
        Me.txtLastProcess.Name = "txtLastProcess"
        Me.txtLastProcess.Size = New System.Drawing.Size(124, 20)
        Me.txtLastProcess.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Last Processed"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.SeaShell
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 178)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(297, 20)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 15
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.MistyRose
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(6, 153)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(294, 20)
        Me.txtStatus.TabIndex = 10
        Me.txtStatus.Text = "Stopped"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Status"
        '
        'txtDateTime
        '
        Me.txtDateTime.BackColor = System.Drawing.Color.MistyRose
        Me.txtDateTime.Enabled = False
        Me.txtDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateTime.Location = New System.Drawing.Point(118, 48)
        Me.txtDateTime.Name = "txtDateTime"
        Me.txtDateTime.Size = New System.Drawing.Size(182, 20)
        Me.txtDateTime.TabIndex = 8
        '
        'lblDatetime
        '
        Me.lblDatetime.AutoSize = True
        Me.lblDatetime.Location = New System.Drawing.Point(0, 52)
        Me.lblDatetime.Name = "lblDatetime"
        Me.lblDatetime.Size = New System.Drawing.Size(93, 13)
        Me.lblDatetime.TabIndex = 7
        Me.lblDatetime.Text = "Current Date Time"
        '
        'lblSatus
        '
        Me.lblSatus.AutoSize = True
        Me.lblSatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSatus.Location = New System.Drawing.Point(96, 1)
        Me.lblSatus.Name = "lblSatus"
        Me.lblSatus.Size = New System.Drawing.Size(122, 15)
        Me.lblSatus.TabIndex = 1
        Me.lblSatus.Text = "Processing Status"
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(51, 434)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(80, 13)
        Me.lblErrors.TabIndex = 3
        Me.lblErrors.Text = "Error Messages"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblInformation)
        Me.Panel1.Location = New System.Drawing.Point(13, 162)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(411, 269)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lstOutputFiles)
        Me.Panel3.Controls.Add(Me.txtOutputFolder)
        Me.Panel3.Controls.Add(Me.lblOutputFolder)
        Me.Panel3.Controls.Add(Me.txtOutputServer)
        Me.Panel3.Controls.Add(Me.lblOutputFTP)
        Me.Panel3.Controls.Add(Me.pnlOutput)
        Me.Panel3.Location = New System.Drawing.Point(215, 23)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(190, 242)
        Me.Panel3.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Message Files"
        '
        'lstOutputFiles
        '
        Me.lstOutputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstOutputFiles.FormattingEnabled = True
        Me.lstOutputFiles.Location = New System.Drawing.Point(6, 101)
        Me.lstOutputFiles.MultiColumn = True
        Me.lstOutputFiles.Name = "lstOutputFiles"
        Me.lstOutputFiles.Size = New System.Drawing.Size(176, 134)
        Me.lstOutputFiles.TabIndex = 11
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.BackColor = System.Drawing.Color.MistyRose
        Me.txtOutputFolder.Enabled = False
        Me.txtOutputFolder.Location = New System.Drawing.Point(70, 51)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(109, 20)
        Me.txtOutputFolder.TabIndex = 10
        '
        'lblOutputFolder
        '
        Me.lblOutputFolder.AutoSize = True
        Me.lblOutputFolder.Location = New System.Drawing.Point(6, 53)
        Me.lblOutputFolder.Name = "lblOutputFolder"
        Me.lblOutputFolder.Size = New System.Drawing.Size(36, 13)
        Me.lblOutputFolder.TabIndex = 9
        Me.lblOutputFolder.Text = "Folder"
        '
        'txtOutputServer
        '
        Me.txtOutputServer.BackColor = System.Drawing.Color.MistyRose
        Me.txtOutputServer.Enabled = False
        Me.txtOutputServer.Location = New System.Drawing.Point(70, 22)
        Me.txtOutputServer.Name = "txtOutputServer"
        Me.txtOutputServer.Size = New System.Drawing.Size(109, 20)
        Me.txtOutputServer.TabIndex = 8
        '
        'lblOutputFTP
        '
        Me.lblOutputFTP.AutoSize = True
        Me.lblOutputFTP.Location = New System.Drawing.Point(3, 23)
        Me.lblOutputFTP.Name = "lblOutputFTP"
        Me.lblOutputFTP.Size = New System.Drawing.Size(61, 13)
        Me.lblOutputFTP.TabIndex = 7
        Me.lblOutputFTP.Text = "FTP Server"
        '
        'pnlOutput
        '
        Me.pnlOutput.AutoSize = True
        Me.pnlOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOutput.Location = New System.Drawing.Point(79, -1)
        Me.pnlOutput.Name = "pnlOutput"
        Me.pnlOutput.Size = New System.Drawing.Size(45, 13)
        Me.pnlOutput.TabIndex = 1
        Me.pnlOutput.Text = "Output"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblInputFiles)
        Me.Panel2.Controls.Add(Me.lstInputFiles)
        Me.Panel2.Controls.Add(Me.txtInputfolder)
        Me.Panel2.Controls.Add(Me.lblInputFolder)
        Me.Panel2.Controls.Add(Me.txtInputServer)
        Me.Panel2.Controls.Add(Me.lblSever)
        Me.Panel2.Controls.Add(Me.lblInputData)
        Me.Panel2.Location = New System.Drawing.Point(4, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(206, 243)
        Me.Panel2.TabIndex = 1
        '
        'lblInputFiles
        '
        Me.lblInputFiles.AutoSize = True
        Me.lblInputFiles.Location = New System.Drawing.Point(73, 87)
        Me.lblInputFiles.Name = "lblInputFiles"
        Me.lblInputFiles.Size = New System.Drawing.Size(55, 13)
        Me.lblInputFiles.TabIndex = 7
        Me.lblInputFiles.Text = "Input Files"
        '
        'lstInputFiles
        '
        Me.lstInputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstInputFiles.FormattingEnabled = True
        Me.lstInputFiles.Location = New System.Drawing.Point(6, 104)
        Me.lstInputFiles.MultiColumn = True
        Me.lstInputFiles.Name = "lstInputFiles"
        Me.lstInputFiles.Size = New System.Drawing.Size(176, 134)
        Me.lstInputFiles.TabIndex = 6
        '
        'txtInputfolder
        '
        Me.txtInputfolder.BackColor = System.Drawing.Color.MistyRose
        Me.txtInputfolder.Enabled = False
        Me.txtInputfolder.Location = New System.Drawing.Point(70, 59)
        Me.txtInputfolder.Name = "txtInputfolder"
        Me.txtInputfolder.Size = New System.Drawing.Size(109, 20)
        Me.txtInputfolder.TabIndex = 5
        '
        'lblInputFolder
        '
        Me.lblInputFolder.AutoSize = True
        Me.lblInputFolder.Location = New System.Drawing.Point(6, 61)
        Me.lblInputFolder.Name = "lblInputFolder"
        Me.lblInputFolder.Size = New System.Drawing.Size(36, 13)
        Me.lblInputFolder.TabIndex = 4
        Me.lblInputFolder.Text = "Folder"
        '
        'txtInputServer
        '
        Me.txtInputServer.BackColor = System.Drawing.Color.MistyRose
        Me.txtInputServer.Enabled = False
        Me.txtInputServer.Location = New System.Drawing.Point(70, 30)
        Me.txtInputServer.Name = "txtInputServer"
        Me.txtInputServer.Size = New System.Drawing.Size(109, 20)
        Me.txtInputServer.TabIndex = 3
        '
        'lblSever
        '
        Me.lblSever.AutoSize = True
        Me.lblSever.Location = New System.Drawing.Point(3, 31)
        Me.lblSever.Name = "lblSever"
        Me.lblSever.Size = New System.Drawing.Size(61, 13)
        Me.lblSever.TabIndex = 2
        Me.lblSever.Text = "FTP Server"
        '
        'lblInputData
        '
        Me.lblInputData.AutoSize = True
        Me.lblInputData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputData.Location = New System.Drawing.Point(92, 0)
        Me.lblInputData.Name = "lblInputData"
        Me.lblInputData.Size = New System.Drawing.Size(36, 13)
        Me.lblInputData.TabIndex = 1
        Me.lblInputData.Text = "Input"
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformation.Location = New System.Drawing.Point(149, 0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(155, 15)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Processing Information"
        '
        'grpElements
        '
        Me.grpElements.Location = New System.Drawing.Point(19, 333)
        Me.grpElements.Name = "grpElements"
        Me.grpElements.Size = New System.Drawing.Size(680, 42)
        Me.grpElements.TabIndex = 0
        Me.grpElements.TabStop = False
        Me.grpElements.Text = "Elements View/Update"
        '
        'pnlDataStructures
        '
        Me.pnlDataStructures.BackColor = System.Drawing.Color.BurlyWood
        Me.pnlDataStructures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDataStructures.Controls.Add(Me.grpStructures1)
        Me.pnlDataStructures.Controls.Add(Me.DataGridViewStructures)
        Me.pnlDataStructures.Location = New System.Drawing.Point(191, 27)
        Me.pnlDataStructures.Name = "pnlDataStructures"
        Me.pnlDataStructures.Size = New System.Drawing.Size(760, 76)
        Me.pnlDataStructures.TabIndex = 5
        Me.pnlDataStructures.Visible = False
        '
        'grpStructures1
        '
        Me.grpStructures1.Controls.Add(Me.lblStructure)
        Me.grpStructures1.Controls.Add(Me.grpStructures)
        Me.grpStructures1.Controls.Add(Me.cmbExistingStructures)
        Me.grpStructures1.Location = New System.Drawing.Point(194, 4)
        Me.grpStructures1.Name = "grpStructures1"
        Me.grpStructures1.Size = New System.Drawing.Size(389, 236)
        Me.grpStructures1.TabIndex = 1
        Me.grpStructures1.TabStop = False
        Me.grpStructures1.Text = "Data Structures"
        '
        'lblStructure
        '
        Me.lblStructure.Location = New System.Drawing.Point(11, 29)
        Me.lblStructure.Name = "lblStructure"
        Me.lblStructure.Size = New System.Drawing.Size(146, 36)
        Me.lblStructure.TabIndex = 8
        Me.lblStructure.Text = "Select Existing Data structure"
        '
        'grpStructures
        '
        Me.grpStructures.Controls.Add(Me.cmdClone)
        Me.grpStructures.Controls.Add(Me.lblRecords)
        Me.grpStructures.Controls.Add(Me.txtDelimiter)
        Me.grpStructures.Controls.Add(Me.txtQualifier)
        Me.grpStructures.Controls.Add(Me.txtHeaders)
        Me.grpStructures.Controls.Add(Me.txtStrName)
        Me.grpStructures.Controls.Add(Me.cmdDelete)
        Me.grpStructures.Controls.Add(Me.cmdUpdate)
        Me.grpStructures.Controls.Add(Me.cmdCreate)
        Me.grpStructures.Controls.Add(Me.Label21)
        Me.grpStructures.Controls.Add(Me.Label20)
        Me.grpStructures.Controls.Add(Me.Label19)
        Me.grpStructures.Controls.Add(Me.lblStrName)
        Me.grpStructures.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpStructures.Location = New System.Drawing.Point(13, 62)
        Me.grpStructures.Name = "grpStructures"
        Me.grpStructures.Size = New System.Drawing.Size(359, 149)
        Me.grpStructures.TabIndex = 7
        Me.grpStructures.TabStop = False
        '
        'cmdClone
        '
        Me.cmdClone.Location = New System.Drawing.Point(178, 120)
        Me.cmdClone.Name = "cmdClone"
        Me.cmdClone.Size = New System.Drawing.Size(71, 23)
        Me.cmdClone.TabIndex = 21
        Me.cmdClone.Text = "Clone"
        Me.cmdClone.UseVisualStyleBackColor = True
        '
        'lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Location = New System.Drawing.Point(168, 98)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(0, 13)
        Me.lblRecords.TabIndex = 20
        Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDelimiter
        '
        Me.txtDelimiter.FormattingEnabled = True
        Me.txtDelimiter.Items.AddRange(New Object() {"comma", "tab", "space"})
        Me.txtDelimiter.Location = New System.Drawing.Point(171, 33)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(168, 21)
        Me.txtDelimiter.TabIndex = 18
        '
        'txtQualifier
        '
        Me.txtQualifier.Location = New System.Drawing.Point(171, 74)
        Me.txtQualifier.Name = "txtQualifier"
        Me.txtQualifier.Size = New System.Drawing.Size(168, 20)
        Me.txtQualifier.TabIndex = 17
        '
        'txtHeaders
        '
        Me.txtHeaders.Location = New System.Drawing.Point(171, 54)
        Me.txtHeaders.Name = "txtHeaders"
        Me.txtHeaders.Size = New System.Drawing.Size(168, 20)
        Me.txtHeaders.TabIndex = 16
        '
        'txtStrName
        '
        Me.txtStrName.Location = New System.Drawing.Point(171, 13)
        Me.txtStrName.Name = "txtStrName"
        Me.txtStrName.Size = New System.Drawing.Size(168, 20)
        Me.txtStrName.TabIndex = 14
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(254, 120)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(93, 23)
        Me.cmdDelete.TabIndex = 13
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(85, 120)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(88, 23)
        Me.cmdUpdate.TabIndex = 12
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(9, 120)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(71, 23)
        Me.cmdCreate.TabIndex = 11
        Me.cmdCreate.Text = "Create"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Text Qualifier Character"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Total Header Rows"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(7, 36)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 13)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Delimiter Type"
        '
        'lblStrName
        '
        Me.lblStrName.AutoSize = True
        Me.lblStrName.Location = New System.Drawing.Point(6, 15)
        Me.lblStrName.Name = "lblStrName"
        Me.lblStrName.Size = New System.Drawing.Size(81, 13)
        Me.lblStrName.TabIndex = 7
        Me.lblStrName.Text = "Structure Name"
        '
        'cmbExistingStructures
        '
        Me.cmbExistingStructures.FormattingEnabled = True
        Me.cmbExistingStructures.Location = New System.Drawing.Point(184, 26)
        Me.cmbExistingStructures.Name = "cmbExistingStructures"
        Me.cmbExistingStructures.Size = New System.Drawing.Size(165, 21)
        Me.cmbExistingStructures.TabIndex = 1
        '
        'DataGridViewStructures
        '
        Me.DataGridViewStructures.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridViewStructures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewStructures.Location = New System.Drawing.Point(3, 242)
        Me.DataGridViewStructures.Name = "DataGridViewStructures"
        Me.DataGridViewStructures.RowHeadersWidth = 62
        Me.DataGridViewStructures.Size = New System.Drawing.Size(749, 118)
        Me.DataGridViewStructures.TabIndex = 2
        Me.DataGridViewStructures.Visible = False
        '
        'pnlSites
        '
        Me.pnlSites.AllowDrop = True
        Me.pnlSites.AutoSize = True
        Me.pnlSites.BackColor = System.Drawing.Color.Linen
        Me.pnlSites.Controls.Add(Me.grpSites)
        Me.pnlSites.Location = New System.Drawing.Point(187, -24)
        Me.pnlSites.Name = "pnlSites"
        Me.pnlSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlSites.Size = New System.Drawing.Size(785, 457)
        Me.pnlSites.TabIndex = 3
        '
        'grpSites
        '
        Me.grpSites.Controls.Add(Me.optCSV)
        Me.grpSites.Controls.Add(Me.optBufr)
        Me.grpSites.Controls.Add(Me.txtUTCdiff)
        Me.grpSites.Controls.Add(Me.lblUTCdiff)
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
        Me.grpSites.Controls.Add(Me.Label4)
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
        Me.grpSites.Controls.Add(Me.txtHrs)
        Me.grpSites.Controls.Add(Me.chkHrsAdjust)
        Me.grpSites.Location = New System.Drawing.Point(8, 50)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Size = New System.Drawing.Size(769, 378)
        Me.grpSites.TabIndex = 67
        Me.grpSites.TabStop = False
        '
        'optCSV
        '
        Me.optCSV.AutoSize = True
        Me.optCSV.Location = New System.Drawing.Point(270, 265)
        Me.optCSV.Name = "optCSV"
        Me.optCSV.Size = New System.Drawing.Size(91, 17)
        Me.optCSV.TabIndex = 108
        Me.optCSV.Text = "CSV for WIS2"
        Me.optCSV.UseVisualStyleBackColor = True
        Me.optCSV.Visible = False
        '
        'optBufr
        '
        Me.optBufr.AutoSize = True
        Me.optBufr.Checked = True
        Me.optBufr.Location = New System.Drawing.Point(186, 265)
        Me.optBufr.Name = "optBufr"
        Me.optBufr.Size = New System.Drawing.Size(54, 17)
        Me.optBufr.TabIndex = 107
        Me.optBufr.TabStop = True
        Me.optBufr.Text = "BUFR"
        Me.optBufr.UseVisualStyleBackColor = True
        Me.optBufr.Visible = False
        '
        'txtUTCdiff
        '
        Me.txtUTCdiff.BackColor = System.Drawing.Color.White
        Me.txtUTCdiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUTCdiff.Location = New System.Drawing.Point(117, 286)
        Me.txtUTCdiff.Name = "txtUTCdiff"
        Me.txtUTCdiff.Size = New System.Drawing.Size(32, 20)
        Me.txtUTCdiff.TabIndex = 103
        Me.txtUTCdiff.Text = "0"
        Me.txtUTCdiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtUTCdiff.Visible = False
        '
        'lblUTCdiff
        '
        Me.lblUTCdiff.AutoSize = True
        Me.lblUTCdiff.Location = New System.Drawing.Point(34, 290)
        Me.lblUTCdiff.Name = "lblUTCdiff"
        Me.lblUTCdiff.Size = New System.Drawing.Size(67, 13)
        Me.lblUTCdiff.TabIndex = 102
        Me.lblUTCdiff.Text = "GMT Diff +/-"
        Me.lblUTCdiff.Visible = False
        '
        'DataGridViewSites
        '
        Me.DataGridViewSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSites.Location = New System.Drawing.Point(458, 203)
        Me.DataGridViewSites.Name = "DataGridViewSites"
        Me.DataGridViewSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewSites.RowHeadersWidth = 62
        Me.DataGridViewSites.Size = New System.Drawing.Size(239, 51)
        Me.DataGridViewSites.TabIndex = 68
        Me.DataGridViewSites.Visible = False
        '
        'chkPrefix
        '
        Me.chkPrefix.AutoSize = True
        Me.chkPrefix.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.Location = New System.Drawing.Point(534, 113)
        Me.chkPrefix.Name = "chkPrefix"
        Me.chkPrefix.Size = New System.Drawing.Size(107, 17)
        Me.chkPrefix.TabIndex = 101
        Me.chkPrefix.Text = "Files name  prefix"
        Me.chkPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.UseVisualStyleBackColor = True
        '
        'txtfilePrefix
        '
        Me.txtfilePrefix.Location = New System.Drawing.Point(686, 111)
        Me.txtfilePrefix.Name = "txtfilePrefix"
        Me.txtfilePrefix.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfilePrefix.Size = New System.Drawing.Size(74, 20)
        Me.txtfilePrefix.TabIndex = 100
        Me.txtfilePrefix.Visible = False
        '
        'txtGTSHeader
        '
        Me.txtGTSHeader.Location = New System.Drawing.Point(211, 216)
        Me.txtGTSHeader.Name = "txtGTSHeader"
        Me.txtGTSHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGTSHeader.Size = New System.Drawing.Size(137, 20)
        Me.txtGTSHeader.TabIndex = 98
        Me.txtGTSHeader.Visible = False
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(32, 220)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(90, 13)
        Me.Label42.TabIndex = 97
        Me.Label42.Text = "GTS Msg Header"
        Me.Label42.Visible = False
        '
        'chkGTSEncode
        '
        Me.chkGTSEncode.AutoSize = True
        Me.chkGTSEncode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkGTSEncode.Location = New System.Drawing.Point(31, 265)
        Me.chkGTSEncode.Name = "chkGTSEncode"
        Me.chkGTSEncode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkGTSEncode.Size = New System.Drawing.Size(109, 17)
        Me.chkGTSEncode.TabIndex = 96
        Me.chkGTSEncode.Text = "Encode for GTS  "
        Me.chkGTSEncode.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkGTSEncode.UseVisualStyleBackColor = True
        '
        'txtSiteName
        '
        Me.txtSiteName.FormattingEnabled = True
        Me.txtSiteName.Location = New System.Drawing.Point(211, 83)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteName.Size = New System.Drawing.Size(315, 21)
        Me.txtSiteName.TabIndex = 95
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(32, 87)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 13)
        Me.Label41.TabIndex = 94
        Me.Label41.Text = "Site Name"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(164, 316)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(76, 24)
        Me.cmdClear.TabIndex = 88
        Me.cmdClear.Text = "AddNew"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewUpdate
        '
        Me.cmdViewUpdate.Location = New System.Drawing.Point(479, 314)
        Me.cmdViewUpdate.Name = "cmdViewUpdate"
        Me.cmdViewUpdate.Size = New System.Drawing.Size(138, 24)
        Me.cmdViewUpdate.TabIndex = 87
        Me.cmdViewUpdate.Text = "View/Update"
        Me.cmdViewUpdate.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.Location = New System.Drawing.Point(404, 315)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(70, 24)
        Me.cmdDel.TabIndex = 86
        Me.cmdDel.Text = "Delete"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpdateSites
        '
        Me.cmdUpdateSites.Location = New System.Drawing.Point(331, 316)
        Me.cmdUpdateSites.Name = "cmdUpdateSites"
        Me.cmdUpdateSites.Size = New System.Drawing.Size(68, 24)
        Me.cmdUpdateSites.TabIndex = 85
        Me.cmdUpdateSites.Text = "Update"
        Me.cmdUpdateSites.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(246, 316)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(83, 24)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(31, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Operational"
        '
        'txtIP
        '
        Me.txtIP.FormattingEnabled = True
        Me.txtIP.Location = New System.Drawing.Point(210, 191)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(137, 21)
        Me.txtIP.TabIndex = 77
        '
        'txtDataStructure
        '
        Me.txtDataStructure.FormattingEnabled = True
        Me.txtDataStructure.Location = New System.Drawing.Point(211, 138)
        Me.txtDataStructure.Name = "txtDataStructure"
        Me.txtDataStructure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataStructure.Size = New System.Drawing.Size(185, 21)
        Me.txtDataStructure.TabIndex = 76
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(211, 163)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFlag.Size = New System.Drawing.Size(137, 20)
        Me.txtFlag.TabIndex = 75
        '
        'chkOperational
        '
        Me.chkOperational.AutoSize = True
        Me.chkOperational.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOperational.Location = New System.Drawing.Point(125, 238)
        Me.chkOperational.Name = "chkOperational"
        Me.chkOperational.Size = New System.Drawing.Size(15, 14)
        Me.chkOperational.TabIndex = 74
        Me.chkOperational.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkOperational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(31, 195)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "AWS Server IP"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(31, 167)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Missing Data Flag"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(31, 142)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Data Structure"
        '
        'txtInFile
        '
        Me.txtInFile.Location = New System.Drawing.Point(210, 111)
        Me.txtInFile.Name = "txtInFile"
        Me.txtInFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInFile.Size = New System.Drawing.Size(316, 20)
        Me.txtInFile.TabIndex = 70
        '
        'lblInfile
        '
        Me.lblInfile.AutoSize = True
        Me.lblInfile.Location = New System.Drawing.Point(31, 115)
        Me.lblInfile.Name = "lblInfile"
        Me.lblInfile.Size = New System.Drawing.Size(73, 13)
        Me.lblInfile.TabIndex = 69
        Me.lblInfile.Text = "Input Data file"
        '
        'txtSiteID
        '
        Me.txtSiteID.FormattingEnabled = True
        Me.txtSiteID.Location = New System.Drawing.Point(211, 54)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteID.Size = New System.Drawing.Size(326, 21)
        Me.txtSiteID.TabIndex = 68
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(31, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Site ID"
        '
        'txtHrs
        '
        Me.txtHrs.BackColor = System.Drawing.Color.White
        Me.txtHrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHrs.Location = New System.Drawing.Point(564, 138)
        Me.txtHrs.Name = "txtHrs"
        Me.txtHrs.Size = New System.Drawing.Size(32, 20)
        Me.txtHrs.TabIndex = 105
        Me.txtHrs.Text = "0"
        Me.txtHrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtHrs.Visible = False
        '
        'chkHrsAdjust
        '
        Me.chkHrsAdjust.AutoSize = True
        Me.chkHrsAdjust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHrsAdjust.Location = New System.Drawing.Point(410, 140)
        Me.chkHrsAdjust.Name = "chkHrsAdjust"
        Me.chkHrsAdjust.Size = New System.Drawing.Size(150, 17)
        Me.chkHrsAdjust.TabIndex = 104
        Me.chkHrsAdjust.Text = "Adjust Archival Hours (+/-)"
        Me.chkHrsAdjust.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHrsAdjust.UseVisualStyleBackColor = True
        '
        'pnlServers
        '
        Me.pnlServers.BackColor = System.Drawing.Color.PeachPuff
        Me.pnlServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlServers.Controls.Add(Me.pnlBaseStation)
        Me.pnlServers.Controls.Add(Me.pnlMSS)
        Me.pnlServers.Controls.Add(Me.cmdMSS)
        Me.pnlServers.Controls.Add(Me.cmdBaseStation)
        Me.pnlServers.Location = New System.Drawing.Point(191, 374)
        Me.pnlServers.Name = "pnlServers"
        Me.pnlServers.Size = New System.Drawing.Size(778, 150)
        Me.pnlServers.TabIndex = 2
        Me.pnlServers.Visible = False
        '
        'pnlBaseStation
        '
        Me.pnlBaseStation.BackColor = System.Drawing.Color.PapayaWhip
        Me.pnlBaseStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBaseStation.Controls.Add(Me.lblPort)
        Me.pnlBaseStation.Controls.Add(Me.txtPort)
        Me.pnlBaseStation.Controls.Add(Me.GroupBox10)
        Me.pnlBaseStation.Controls.Add(Me.cmdBstAddNew)
        Me.pnlBaseStation.Controls.Add(Me.cmdRefresh)
        Me.pnlBaseStation.Controls.Add(Me.cmdReset)
        Me.pnlBaseStation.Controls.Add(Me.txtBasestationFTPMode)
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
        Me.pnlBaseStation.Location = New System.Drawing.Point(20, 130)
        Me.pnlBaseStation.Name = "pnlBaseStation"
        Me.pnlBaseStation.Size = New System.Drawing.Size(712, 287)
        Me.pnlBaseStation.TabIndex = 4
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(401, 106)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 77
        Me.lblPort.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(431, 102)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(49, 20)
        Me.txtPort.TabIndex = 76
        Me.txtPort.Text = "21"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdPrevRecord)
        Me.GroupBox10.Controls.Add(Me.cmdFirstRecord)
        Me.GroupBox10.Controls.Add(Me.cmdLastRecord)
        Me.GroupBox10.Controls.Add(Me.cmdNextRecord)
        Me.GroupBox10.Controls.Add(Me.txtbssNavigator)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox10.Location = New System.Drawing.Point(0, 254)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(710, 31)
        Me.GroupBox10.TabIndex = 72
        Me.GroupBox10.TabStop = False
        '
        'cmdPrevRecord
        '
        Me.cmdPrevRecord.BackgroundImage = CType(resources.GetObject("cmdPrevRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrevRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPrevRecord.Location = New System.Drawing.Point(123, 6)
        Me.cmdPrevRecord.Name = "cmdPrevRecord"
        Me.cmdPrevRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdPrevRecord.TabIndex = 4
        Me.cmdPrevRecord.UseVisualStyleBackColor = True
        '
        'cmdFirstRecord
        '
        Me.cmdFirstRecord.BackgroundImage = CType(resources.GetObject("cmdFirstRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdFirstRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFirstRecord.Location = New System.Drawing.Point(89, 6)
        Me.cmdFirstRecord.Name = "cmdFirstRecord"
        Me.cmdFirstRecord.Size = New System.Drawing.Size(35, 24)
        Me.cmdFirstRecord.TabIndex = 3
        Me.cmdFirstRecord.UseVisualStyleBackColor = True
        '
        'cmdLastRecord
        '
        Me.cmdLastRecord.BackgroundImage = CType(resources.GetObject("cmdLastRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdLastRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLastRecord.Location = New System.Drawing.Point(525, 6)
        Me.cmdLastRecord.Name = "cmdLastRecord"
        Me.cmdLastRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdLastRecord.TabIndex = 2
        Me.cmdLastRecord.UseVisualStyleBackColor = True
        '
        'cmdNextRecord
        '
        Me.cmdNextRecord.BackgroundImage = CType(resources.GetObject("cmdNextRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdNextRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNextRecord.Location = New System.Drawing.Point(490, 6)
        Me.cmdNextRecord.Name = "cmdNextRecord"
        Me.cmdNextRecord.Size = New System.Drawing.Size(36, 24)
        Me.cmdNextRecord.TabIndex = 1
        Me.cmdNextRecord.UseVisualStyleBackColor = True
        '
        'txtbssNavigator
        '
        Me.txtbssNavigator.Location = New System.Drawing.Point(159, 8)
        Me.txtbssNavigator.Name = "txtbssNavigator"
        Me.txtbssNavigator.Size = New System.Drawing.Size(333, 20)
        Me.txtbssNavigator.TabIndex = 0
        Me.txtbssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdBstAddNew
        '
        Me.cmdBstAddNew.Location = New System.Drawing.Point(14, 234)
        Me.cmdBstAddNew.Name = "cmdBstAddNew"
        Me.cmdBstAddNew.Size = New System.Drawing.Size(110, 21)
        Me.cmdBstAddNew.TabIndex = 75
        Me.cmdBstAddNew.Text = "Add New"
        Me.cmdBstAddNew.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(479, 234)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(110, 21)
        Me.cmdRefresh.TabIndex = 74
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(364, 234)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(110, 21)
        Me.cmdReset.TabIndex = 13
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'txtBasestationFTPMode
        '
        Me.txtBasestationFTPMode.FormattingEnabled = True
        Me.txtBasestationFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtBasestationFTPMode.Location = New System.Drawing.Point(317, 102)
        Me.txtBasestationFTPMode.Name = "txtBasestationFTPMode"
        Me.txtBasestationFTPMode.Size = New System.Drawing.Size(70, 21)
        Me.txtBasestationFTPMode.TabIndex = 73
        Me.txtBasestationFTPMode.Text = "FTP"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(169, 106)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(114, 13)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "Data Transfer Protocol"
        '
        'lblbaseStation
        '
        Me.lblbaseStation.AutoSize = True
        Me.lblbaseStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbaseStation.Location = New System.Drawing.Point(290, 13)
        Me.lblbaseStation.Name = "lblbaseStation"
        Me.lblbaseStation.Size = New System.Drawing.Size(79, 13)
        Me.lblbaseStation.TabIndex = 30
        Me.lblbaseStation.Text = "Base Station"
        '
        'cmdBstDelete
        '
        Me.cmdBstDelete.Location = New System.Drawing.Point(594, 234)
        Me.cmdBstDelete.Name = "cmdBstDelete"
        Me.cmdBstDelete.Size = New System.Drawing.Size(110, 21)
        Me.cmdBstDelete.TabIndex = 14
        Me.cmdBstDelete.Text = "Delete"
        Me.cmdBstDelete.UseVisualStyleBackColor = True
        '
        'cmdBsstUpdate
        '
        Me.cmdBsstUpdate.Location = New System.Drawing.Point(250, 234)
        Me.cmdBsstUpdate.Name = "cmdBsstUpdate"
        Me.cmdBsstUpdate.Size = New System.Drawing.Size(110, 21)
        Me.cmdBsstUpdate.TabIndex = 12
        Me.cmdBsstUpdate.Text = "Update"
        Me.cmdBsstUpdate.UseVisualStyleBackColor = True
        '
        'cmdBstSave
        '
        Me.cmdBstSave.Location = New System.Drawing.Point(134, 234)
        Me.cmdBstSave.Name = "cmdBstSave"
        Me.cmdBstSave.Size = New System.Drawing.Size(110, 21)
        Me.cmdBstSave.TabIndex = 11
        Me.cmdBstSave.Text = "Save"
        Me.cmdBstSave.UseVisualStyleBackColor = True
        '
        'txtbaseStationPWConfirm
        '
        Me.txtbaseStationPWConfirm.Location = New System.Drawing.Point(316, 195)
        Me.txtbaseStationPWConfirm.Name = "txtbaseStationPWConfirm"
        Me.txtbaseStationPWConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPWConfirm.Size = New System.Drawing.Size(168, 20)
        Me.txtbaseStationPWConfirm.TabIndex = 10
        '
        'txtbaseStationPW
        '
        Me.txtbaseStationPW.Location = New System.Drawing.Point(316, 165)
        Me.txtbaseStationPW.Name = "txtbaseStationPW"
        Me.txtbaseStationPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPW.Size = New System.Drawing.Size(168, 20)
        Me.txtbaseStationPW.TabIndex = 9
        '
        'txtBaseStationUser
        '
        Me.txtBaseStationUser.Location = New System.Drawing.Point(316, 134)
        Me.txtBaseStationUser.Name = "txtBaseStationUser"
        Me.txtBaseStationUser.Size = New System.Drawing.Size(168, 20)
        Me.txtBaseStationUser.TabIndex = 8
        '
        'txtBaseStationFolder
        '
        Me.txtBaseStationFolder.Location = New System.Drawing.Point(315, 71)
        Me.txtBaseStationFolder.Name = "txtBaseStationFolder"
        Me.txtBaseStationFolder.Size = New System.Drawing.Size(376, 20)
        Me.txtBaseStationFolder.TabIndex = 6
        '
        'txtBaseStationAddress
        '
        Me.txtBaseStationAddress.Location = New System.Drawing.Point(316, 40)
        Me.txtBaseStationAddress.Name = "txtBaseStationAddress"
        Me.txtBaseStationAddress.Size = New System.Drawing.Size(375, 20)
        Me.txtBaseStationAddress.TabIndex = 5
        '
        'lblConfirmInputPW
        '
        Me.lblConfirmInputPW.AutoSize = True
        Me.lblConfirmInputPW.Location = New System.Drawing.Point(169, 199)
        Me.lblConfirmInputPW.Name = "lblConfirmInputPW"
        Me.lblConfirmInputPW.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmInputPW.TabIndex = 4
        Me.lblConfirmInputPW.Text = "Confirm Password"
        '
        'lblInputPW
        '
        Me.lblInputPW.AutoSize = True
        Me.lblInputPW.Location = New System.Drawing.Point(169, 169)
        Me.lblInputPW.Name = "lblInputPW"
        Me.lblInputPW.Size = New System.Drawing.Size(56, 13)
        Me.lblInputPW.TabIndex = 3
        Me.lblInputPW.Text = "PassWord"
        '
        'lblInputUser
        '
        Me.lblInputUser.AutoSize = True
        Me.lblInputUser.Location = New System.Drawing.Point(168, 138)
        Me.lblInputUser.Name = "lblInputUser"
        Me.lblInputUser.Size = New System.Drawing.Size(60, 13)
        Me.lblInputUser.TabIndex = 2
        Me.lblInputUser.Text = "User Name"
        '
        'lblFTPFolder
        '
        Me.lblFTPFolder.AutoSize = True
        Me.lblFTPFolder.Location = New System.Drawing.Point(169, 75)
        Me.lblFTPFolder.Name = "lblFTPFolder"
        Me.lblFTPFolder.Size = New System.Drawing.Size(63, 13)
        Me.lblFTPFolder.TabIndex = 1
        Me.lblFTPFolder.Text = "Input Folder"
        '
        'lblBaseStationFTP
        '
        Me.lblBaseStationFTP.AutoSize = True
        Me.lblBaseStationFTP.Location = New System.Drawing.Point(168, 44)
        Me.lblBaseStationFTP.Name = "lblBaseStationFTP"
        Me.lblBaseStationFTP.Size = New System.Drawing.Size(79, 13)
        Me.lblBaseStationFTP.TabIndex = 0
        Me.lblBaseStationFTP.Text = "Server Address"
        '
        'pnlMSS
        '
        Me.pnlMSS.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlMSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSS.Controls.Add(Me.lblMport)
        Me.pnlMSS.Controls.Add(Me.txtMport)
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
        Me.pnlMSS.Location = New System.Drawing.Point(20, 129)
        Me.pnlMSS.Name = "pnlMSS"
        Me.pnlMSS.Size = New System.Drawing.Size(713, 287)
        Me.pnlMSS.TabIndex = 3
        '
        'lblMport
        '
        Me.lblMport.AutoSize = True
        Me.lblMport.Location = New System.Drawing.Point(440, 97)
        Me.lblMport.Name = "lblMport"
        Me.lblMport.Size = New System.Drawing.Size(26, 13)
        Me.lblMport.TabIndex = 80
        Me.lblMport.Text = "Port"
        '
        'txtMport
        '
        Me.txtMport.Location = New System.Drawing.Point(470, 93)
        Me.txtMport.Name = "txtMport"
        Me.txtMport.Size = New System.Drawing.Size(49, 20)
        Me.txtMport.TabIndex = 79
        Me.txtMport.Text = "21"
        Me.txtMport.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstFolders
        '
        Me.lstFolders.FormattingEnabled = True
        Me.lstFolders.Items.AddRange(New Object() {"binary", "ASC"})
        Me.lstFolders.Location = New System.Drawing.Point(588, 66)
        Me.lstFolders.Name = "lstFolders"
        Me.lstFolders.Size = New System.Drawing.Size(90, 17)
        Me.lstFolders.TabIndex = 78
        '
        'cmdMssAddNew
        '
        Me.cmdMssAddNew.Location = New System.Drawing.Point(9, 226)
        Me.cmdMssAddNew.Name = "cmdMssAddNew"
        Me.cmdMssAddNew.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssAddNew.TabIndex = 77
        Me.cmdMssAddNew.Text = "AddNew"
        Me.cmdMssAddNew.UseVisualStyleBackColor = True
        '
        'cmdMssRefresh
        '
        Me.cmdMssRefresh.Location = New System.Drawing.Point(471, 226)
        Me.cmdMssRefresh.Name = "cmdMssRefresh"
        Me.cmdMssRefresh.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssRefresh.TabIndex = 76
        Me.cmdMssRefresh.Text = "Refresh"
        Me.cmdMssRefresh.UseVisualStyleBackColor = True
        '
        'cmdMssReset
        '
        Me.cmdMssReset.Location = New System.Drawing.Point(355, 226)
        Me.cmdMssReset.Name = "cmdMssReset"
        Me.cmdMssReset.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssReset.TabIndex = 75
        Me.cmdMssReset.Text = "Reset"
        Me.cmdMssReset.UseVisualStyleBackColor = True
        '
        'txtmssFTPMode
        '
        Me.txtmssFTPMode.FormattingEnabled = True
        Me.txtmssFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtmssFTPMode.Location = New System.Drawing.Point(306, 93)
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
        Me.GroupBox1.Size = New System.Drawing.Size(711, 36)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'cmdmssPrev
        '
        Me.cmdmssPrev.BackgroundImage = CType(resources.GetObject("cmdmssPrev.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssPrev.Location = New System.Drawing.Point(120, 6)
        Me.cmdmssPrev.Name = "cmdmssPrev"
        Me.cmdmssPrev.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssPrev.TabIndex = 4
        Me.cmdmssPrev.UseVisualStyleBackColor = True
        '
        'cmdmssfirst
        '
        Me.cmdmssfirst.BackgroundImage = CType(resources.GetObject("cmdmssfirst.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssfirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssfirst.Location = New System.Drawing.Point(86, 6)
        Me.cmdmssfirst.Name = "cmdmssfirst"
        Me.cmdmssfirst.Size = New System.Drawing.Size(35, 24)
        Me.cmdmssfirst.TabIndex = 3
        Me.cmdmssfirst.UseVisualStyleBackColor = True
        '
        'cmdmssLast
        '
        Me.cmdmssLast.BackgroundImage = CType(resources.GetObject("cmdmssLast.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssLast.Location = New System.Drawing.Point(522, 6)
        Me.cmdmssLast.Name = "cmdmssLast"
        Me.cmdmssLast.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssLast.TabIndex = 2
        Me.cmdmssLast.UseVisualStyleBackColor = True
        '
        'cmdmssNext
        '
        Me.cmdmssNext.BackgroundImage = CType(resources.GetObject("cmdmssNext.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssNext.Location = New System.Drawing.Point(487, 6)
        Me.cmdmssNext.Name = "cmdmssNext"
        Me.cmdmssNext.Size = New System.Drawing.Size(36, 24)
        Me.cmdmssNext.TabIndex = 1
        Me.cmdmssNext.UseVisualStyleBackColor = True
        '
        'txtmssNavigator
        '
        Me.txtmssNavigator.Location = New System.Drawing.Point(156, 8)
        Me.txtmssNavigator.Name = "txtmssNavigator"
        Me.txtmssNavigator.Size = New System.Drawing.Size(333, 20)
        Me.txtmssNavigator.TabIndex = 0
        Me.txtmssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFtpTransferMode
        '
        Me.lblFtpTransferMode.AutoSize = True
        Me.lblFtpTransferMode.Location = New System.Drawing.Point(161, 97)
        Me.lblFtpTransferMode.Name = "lblFtpTransferMode"
        Me.lblFtpTransferMode.Size = New System.Drawing.Size(114, 13)
        Me.lblFtpTransferMode.TabIndex = 14
        Me.lblFtpTransferMode.Text = "Data Transfer Protocol"
        '
        'lblMsgSwitch
        '
        Me.lblMsgSwitch.AutoSize = True
        Me.lblMsgSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgSwitch.Location = New System.Drawing.Point(287, 10)
        Me.lblMsgSwitch.Name = "lblMsgSwitch"
        Me.lblMsgSwitch.Size = New System.Drawing.Size(99, 13)
        Me.lblMsgSwitch.TabIndex = 13
        Me.lblMsgSwitch.Text = "Message Switch"
        '
        'cmdMssDelete
        '
        Me.cmdMssDelete.Location = New System.Drawing.Point(588, 226)
        Me.cmdMssDelete.Name = "cmdMssDelete"
        Me.cmdMssDelete.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssDelete.TabIndex = 12
        Me.cmdMssDelete.Text = "Delete"
        Me.cmdMssDelete.UseVisualStyleBackColor = True
        '
        'cmdMssUpdate
        '
        Me.cmdMssUpdate.Location = New System.Drawing.Point(239, 226)
        Me.cmdMssUpdate.Name = "cmdMssUpdate"
        Me.cmdMssUpdate.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssUpdate.TabIndex = 11
        Me.cmdMssUpdate.Text = "Update"
        Me.cmdMssUpdate.UseVisualStyleBackColor = True
        '
        'cmdMssSave
        '
        Me.cmdMssSave.Location = New System.Drawing.Point(125, 226)
        Me.cmdMssSave.Name = "cmdMssSave"
        Me.cmdMssSave.Size = New System.Drawing.Size(110, 21)
        Me.cmdMssSave.TabIndex = 10
        Me.cmdMssSave.Text = "Save"
        Me.cmdMssSave.UseVisualStyleBackColor = True
        '
        'txtMSSConfirm
        '
        Me.txtMSSConfirm.Location = New System.Drawing.Point(306, 180)
        Me.txtMSSConfirm.Name = "txtMSSConfirm"
        Me.txtMSSConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSConfirm.Size = New System.Drawing.Size(116, 20)
        Me.txtMSSConfirm.TabIndex = 10
        '
        'txtMSSPW
        '
        Me.txtMSSPW.Location = New System.Drawing.Point(306, 151)
        Me.txtMSSPW.Name = "txtMSSPW"
        Me.txtMSSPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSPW.Size = New System.Drawing.Size(116, 20)
        Me.txtMSSPW.TabIndex = 9
        '
        'txtmssUser
        '
        Me.txtmssUser.Location = New System.Drawing.Point(306, 122)
        Me.txtmssUser.Name = "txtmssUser"
        Me.txtmssUser.Size = New System.Drawing.Size(116, 20)
        Me.txtmssUser.TabIndex = 8
        '
        'txtMSSFolder
        '
        Me.txtMSSFolder.Location = New System.Drawing.Point(306, 64)
        Me.txtMSSFolder.Name = "txtMSSFolder"
        Me.txtMSSFolder.Size = New System.Drawing.Size(276, 20)
        Me.txtMSSFolder.TabIndex = 6
        '
        'txtMSSAddress
        '
        Me.txtMSSAddress.Location = New System.Drawing.Point(306, 35)
        Me.txtMSSAddress.Name = "txtMSSAddress"
        Me.txtMSSAddress.Size = New System.Drawing.Size(375, 20)
        Me.txtMSSAddress.TabIndex = 5
        '
        'lblmssConfirmPassword
        '
        Me.lblmssConfirmPassword.AutoSize = True
        Me.lblmssConfirmPassword.Location = New System.Drawing.Point(159, 184)
        Me.lblmssConfirmPassword.Name = "lblmssConfirmPassword"
        Me.lblmssConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblmssConfirmPassword.TabIndex = 4
        Me.lblmssConfirmPassword.Text = "Confirm Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 155)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(159, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "User Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(159, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Input Folder"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(159, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Server Address"
        '
        'cmdMSS
        '
        Me.cmdMSS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMSS.Location = New System.Drawing.Point(347, 39)
        Me.cmdMSS.Name = "cmdMSS"
        Me.cmdMSS.Size = New System.Drawing.Size(146, 33)
        Me.cmdMSS.TabIndex = 1
        Me.cmdMSS.Text = "Message Switch"
        Me.cmdMSS.UseVisualStyleBackColor = True
        '
        'cmdBaseStation
        '
        Me.cmdBaseStation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBaseStation.Location = New System.Drawing.Point(201, 39)
        Me.cmdBaseStation.Name = "cmdBaseStation"
        Me.cmdBaseStation.Size = New System.Drawing.Size(143, 33)
        Me.cmdBaseStation.TabIndex = 0
        Me.cmdBaseStation.Text = "Base Station"
        Me.cmdBaseStation.UseVisualStyleBackColor = True
        '
        'pnlMsgEncoding
        '
        Me.pnlMsgEncoding.BackColor = System.Drawing.Color.Linen
        Me.pnlMsgEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox6)
        Me.pnlMsgEncoding.Controls.Add(Me.grpIndicators)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox5)
        Me.pnlMsgEncoding.Location = New System.Drawing.Point(203, 177)
        Me.pnlMsgEncoding.Name = "pnlMsgEncoding"
        Me.pnlMsgEncoding.Size = New System.Drawing.Size(752, 189)
        Me.pnlMsgEncoding.TabIndex = 4
        Me.pnlMsgEncoding.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgrdCodeFlag)
        Me.GroupBox6.Location = New System.Drawing.Point(349, 20)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(375, 466)
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
        Me.dgrdCodeFlag.RowHeadersWidth = 62
        Me.dgrdCodeFlag.Size = New System.Drawing.Size(369, 447)
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
        Me.grpIndicators.Controls.Add(Me.lblUpdateSequenceNumber)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingSubCentre)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingCentre)
        Me.grpIndicators.Controls.Add(Me.Label34)
        Me.grpIndicators.Location = New System.Drawing.Point(9, 159)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Size = New System.Drawing.Size(337, 327)
        Me.grpIndicators.TabIndex = 1
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Text = "BUFR Section 2"
        '
        'cmdDefault
        '
        Me.cmdDefault.Location = New System.Drawing.Point(223, 285)
        Me.cmdDefault.Name = "cmdDefault"
        Me.cmdDefault.Size = New System.Drawing.Size(108, 27)
        Me.cmdDefault.TabIndex = 24
        Me.cmdDefault.Text = "Set Default"
        Me.cmdDefault.UseVisualStyleBackColor = True
        '
        'cmdSaves
        '
        Me.cmdSaves.Location = New System.Drawing.Point(69, 284)
        Me.cmdSaves.Name = "cmdSaves"
        Me.cmdSaves.Size = New System.Drawing.Size(73, 26)
        Me.cmdSaves.TabIndex = 23
        Me.cmdSaves.Text = "Save"
        Me.cmdSaves.UseVisualStyleBackColor = True
        '
        'cmdUpadate
        '
        Me.cmdUpadate.Location = New System.Drawing.Point(147, 285)
        Me.cmdUpadate.Name = "cmdUpadate"
        Me.cmdUpadate.Size = New System.Drawing.Size(70, 26)
        Me.cmdUpadate.TabIndex = 22
        Me.cmdUpadate.Text = "Update"
        Me.cmdUpadate.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(3, 285)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(61, 25)
        Me.cmdNew.TabIndex = 21
        Me.cmdNew.Text = "AddNew"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'chkOptionalSection
        '
        Me.chkOptionalSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOptionalSection.Location = New System.Drawing.Point(15, 126)
        Me.chkOptionalSection.Name = "chkOptionalSection"
        Me.chkOptionalSection.Size = New System.Drawing.Size(267, 19)
        Me.chkOptionalSection.TabIndex = 20
        Me.chkOptionalSection.Tag = "  "
        Me.chkOptionalSection.Text = "Option Section Inclusion                      "
        Me.chkOptionalSection.UseVisualStyleBackColor = True
        '
        'txtLocaltableVersion
        '
        Me.txtLocaltableVersion.Location = New System.Drawing.Point(266, 235)
        Me.txtLocaltableVersion.Name = "txtLocaltableVersion"
        Me.txtLocaltableVersion.Size = New System.Drawing.Size(65, 20)
        Me.txtLocaltableVersion.TabIndex = 19
        '
        'txtMastertableVersion
        '
        Me.txtMastertableVersion.Location = New System.Drawing.Point(266, 214)
        Me.txtMastertableVersion.Name = "txtMastertableVersion"
        Me.txtMastertableVersion.Size = New System.Drawing.Size(65, 20)
        Me.txtMastertableVersion.TabIndex = 18
        '
        'txtLocalSubcategory
        '
        Me.txtLocalSubcategory.Location = New System.Drawing.Point(266, 193)
        Me.txtLocalSubcategory.Name = "txtLocalSubcategory"
        Me.txtLocalSubcategory.Size = New System.Drawing.Size(65, 20)
        Me.txtLocalSubcategory.TabIndex = 17
        '
        'txtInternationalSubcategory
        '
        Me.txtInternationalSubcategory.Location = New System.Drawing.Point(266, 172)
        Me.txtInternationalSubcategory.Name = "txtInternationalSubcategory"
        Me.txtInternationalSubcategory.Size = New System.Drawing.Size(65, 20)
        Me.txtInternationalSubcategory.TabIndex = 16
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(266, 151)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(65, 20)
        Me.txtDataCategory.TabIndex = 15
        '
        'txtUpdateSequence
        '
        Me.txtUpdateSequence.Location = New System.Drawing.Point(266, 100)
        Me.txtUpdateSequence.Name = "txtUpdateSequence"
        Me.txtUpdateSequence.Size = New System.Drawing.Size(65, 20)
        Me.txtUpdateSequence.TabIndex = 13
        '
        'txtOriginatingSubcentre
        '
        Me.txtOriginatingSubcentre.Location = New System.Drawing.Point(266, 79)
        Me.txtOriginatingSubcentre.Name = "txtOriginatingSubcentre"
        Me.txtOriginatingSubcentre.Size = New System.Drawing.Size(65, 20)
        Me.txtOriginatingSubcentre.TabIndex = 12
        '
        'txtOriginatingCentre
        '
        Me.txtOriginatingCentre.Location = New System.Drawing.Point(266, 58)
        Me.txtOriginatingCentre.Name = "txtOriginatingCentre"
        Me.txtOriginatingCentre.Size = New System.Drawing.Size(65, 20)
        Me.txtOriginatingCentre.TabIndex = 11
        '
        'txtBufrEdition
        '
        Me.txtBufrEdition.Location = New System.Drawing.Point(266, 37)
        Me.txtBufrEdition.Name = "txtBufrEdition"
        Me.txtBufrEdition.Size = New System.Drawing.Size(65, 20)
        Me.txtBufrEdition.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(14, 241)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 13)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Local Table Version No."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 220)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(127, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Master Table Version No."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 199)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Local Data Sub-Category"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(15, 178)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(158, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "International Data Sub-Category"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(15, 157)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 13)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Data Category"
        '
        'lblUpdateSequenceNumber
        '
        Me.lblUpdateSequenceNumber.AutoSize = True
        Me.lblUpdateSequenceNumber.Location = New System.Drawing.Point(15, 103)
        Me.lblUpdateSequenceNumber.Name = "lblUpdateSequenceNumber"
        Me.lblUpdateSequenceNumber.Size = New System.Drawing.Size(114, 13)
        Me.lblUpdateSequenceNumber.TabIndex = 3
        Me.lblUpdateSequenceNumber.Text = "Update Sequence No."
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
        Me.GroupBox5.Location = New System.Drawing.Point(9, 20)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(334, 113)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        Me.GroupBox5.Text = "Header and Templates"
        '
        'txtTemplate
        '
        Me.txtTemplate.FormattingEnabled = True
        Me.txtTemplate.Location = New System.Drawing.Point(138, 34)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(187, 21)
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
        Me.txtMsgHeader.Location = New System.Drawing.Point(195, 68)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(130, 20)
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
        Me.ClientSize = New System.Drawing.Size(976, 606)
        Me.Controls.Add(Me.pnlProcessing)
        Me.Controls.Add(Me.pnlDataStructures)
        Me.Controls.Add(Me.pnlServers)
        Me.Controls.Add(Me.pnlMsgEncoding)
        Me.Controls.Add(Me.pnlControl)
        Me.Controls.Add(Me.pnlSites)
        Me.KeyPreview = True
        Me.Name = "formAWSRealTime"
        Me.Text = "AWS Real Time"
        Me.pnlControl.ResumeLayout(False)
        Me.pnlProcessing.ResumeLayout(False)
        Me.pnlProcessing.PerformLayout()
        Me.pnlProcessSettings.ResumeLayout(False)
        Me.pnlProcessSettings.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlDataStructures.ResumeLayout(False)
        Me.grpStructures1.ResumeLayout(False)
        Me.grpStructures.ResumeLayout(False)
        Me.grpStructures.PerformLayout()
        CType(Me.DataGridViewStructures, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblNextProcess As System.Windows.Forms.Label
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
    Friend WithEvents lblUpdateSequenceNumber As System.Windows.Forms.Label
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
    Friend WithEvents lblRetrieveHrs As System.Windows.Forms.Label
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents cmdClone As Button
    Friend WithEvents txtHrs As TextBox
    Friend WithEvents chkHrsAdjust As CheckBox
    Friend WithEvents txtUTCdiff As TextBox
    Friend WithEvents lblUTCdiff As Label
    Friend WithEvents lblPort As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents lblMport As Label
    Friend WithEvents txtMport As TextBox

    Friend WithEvents optCSV As RadioButton
    Friend WithEvents optBufr As RadioButton

End Class
