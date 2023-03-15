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
        Me.list_errors = New System.Windows.Forms.ListBox()
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
        Me.pnlControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(286, 946)
        Me.pnlControl.TabIndex = 0
        '
        'cmdHelp
        '
        Me.cmdHelp.BackColor = System.Drawing.Color.LightSalmon
        Me.cmdHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHelp.Location = New System.Drawing.Point(28, 663)
        Me.cmdHelp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(212, 57)
        Me.cmdHelp.TabIndex = 9
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = False
        '
        'cmdMessages
        '
        Me.cmdMessages.BackColor = System.Drawing.Color.SeaShell
        Me.cmdMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMessages.Location = New System.Drawing.Point(28, 506)
        Me.cmdMessages.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMessages.Name = "cmdMessages"
        Me.cmdMessages.Size = New System.Drawing.Size(213, 80)
        Me.cmdMessages.TabIndex = 8
        Me.cmdMessages.Text = "Encoding Options"
        Me.cmdMessages.UseVisualStyleBackColor = False
        '
        'cmdDataStructures
        '
        Me.cmdDataStructures.BackColor = System.Drawing.Color.SeaShell
        Me.cmdDataStructures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDataStructures.Location = New System.Drawing.Point(28, 392)
        Me.cmdDataStructures.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDataStructures.Name = "cmdDataStructures"
        Me.cmdDataStructures.Size = New System.Drawing.Size(213, 80)
        Me.cmdDataStructures.TabIndex = 7
        Me.cmdDataStructures.Text = "Data Structures"
        Me.cmdDataStructures.UseVisualStyleBackColor = False
        '
        'cmdSites
        '
        Me.cmdSites.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSites.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSites.Location = New System.Drawing.Point(27, 278)
        Me.cmdSites.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSites.Name = "cmdSites"
        Me.cmdSites.Size = New System.Drawing.Size(213, 80)
        Me.cmdSites.TabIndex = 6
        Me.cmdSites.Text = "Sites"
        Me.cmdSites.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.Coral
        Me.cmdClose.Location = New System.Drawing.Point(28, 760)
        Me.cmdClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(212, 57)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdServers
        '
        Me.cmdServers.BackColor = System.Drawing.Color.SeaShell
        Me.cmdServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdServers.Location = New System.Drawing.Point(26, 165)
        Me.cmdServers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdServers.Name = "cmdServers"
        Me.cmdServers.Size = New System.Drawing.Size(213, 80)
        Me.cmdServers.TabIndex = 4
        Me.cmdServers.Text = "Servers"
        Me.cmdServers.UseVisualStyleBackColor = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackColor = System.Drawing.Color.SeaShell
        Me.cmdProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(28, 49)
        Me.cmdProcess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdProcess.Name = "cmdProcess"
        Me.cmdProcess.Size = New System.Drawing.Size(213, 82)
        Me.cmdProcess.TabIndex = 3
        Me.cmdProcess.Text = "Processing"
        Me.cmdProcess.UseVisualStyleBackColor = False
        '
        'pnlProcessing
        '
        Me.pnlProcessing.BackColor = System.Drawing.Color.MistyRose
        Me.pnlProcessing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcessing.Controls.Add(Me.pnlProcessSettings)
        Me.pnlProcessing.Controls.Add(Me.list_errors)
        Me.pnlProcessing.Controls.Add(Me.Ltime)
        Me.pnlProcessing.Controls.Add(Me.Panel4)
        Me.pnlProcessing.Controls.Add(Me.lblErrors)
        Me.pnlProcessing.Controls.Add(Me.Panel1)
        Me.pnlProcessing.Controls.Add(Me.grpElements)
        Me.pnlProcessing.Location = New System.Drawing.Point(291, 8)
        Me.pnlProcessing.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlProcessing.Name = "pnlProcessing"
        Me.pnlProcessing.Size = New System.Drawing.Size(1134, 428)
        Me.pnlProcessing.TabIndex = 1
        Me.pnlProcessing.Visible = False
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
        Me.pnlProcessSettings.Location = New System.Drawing.Point(20, 22)
        Me.pnlProcessSettings.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlProcessSettings.Name = "pnlProcessSettings"
        Me.pnlProcessSettings.Size = New System.Drawing.Size(1090, 213)
        Me.pnlProcessSettings.TabIndex = 6
        '
        'lblEncodeHrs
        '
        Me.lblEncodeHrs.AutoSize = True
        Me.lblEncodeHrs.Location = New System.Drawing.Point(1022, 108)
        Me.lblEncodeHrs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEncodeHrs.Name = "lblEncodeHrs"
        Me.lblEncodeHrs.Size = New System.Drawing.Size(52, 20)
        Me.lblEncodeHrs.TabIndex = 19
        Me.lblEncodeHrs.Text = "Hours"
        '
        'txtEncode
        '
        Me.txtEncode.Location = New System.Drawing.Point(976, 100)
        Me.txtEncode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtEncode.Name = "txtEncode"
        Me.txtEncode.Size = New System.Drawing.Size(40, 26)
        Me.txtEncode.TabIndex = 18
        Me.txtEncode.Text = "6"
        Me.txtEncode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEncode
        '
        Me.lblEncode.AutoSize = True
        Me.lblEncode.Location = New System.Drawing.Point(814, 106)
        Me.lblEncode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEncode.Name = "lblEncode"
        Me.lblEncode.Size = New System.Drawing.Size(99, 20)
        Me.lblEncode.TabIndex = 17
        Me.lblEncode.Text = "Encode Last"
        '
        'optStart
        '
        Me.optStart.AutoSize = True
        Me.optStart.Location = New System.Drawing.Point(27, 40)
        Me.optStart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optStart.Name = "optStart"
        Me.optStart.Size = New System.Drawing.Size(87, 24)
        Me.optStart.TabIndex = 0
        Me.optStart.Text = "Restart"
        Me.optStart.UseVisualStyleBackColor = True
        '
        'txtGMTDiff
        '
        Me.txtGMTDiff.BackColor = System.Drawing.Color.White
        Me.txtGMTDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMTDiff.Location = New System.Drawing.Point(810, 160)
        Me.txtGMTDiff.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtGMTDiff.Name = "txtGMTDiff"
        Me.txtGMTDiff.Size = New System.Drawing.Size(46, 26)
        Me.txtGMTDiff.TabIndex = 16
        Me.txtGMTDiff.Text = "0"
        Me.txtGMTDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblGMT
        '
        Me.lblGMT.AutoSize = True
        Me.lblGMT.Location = New System.Drawing.Point(666, 165)
        Me.lblGMT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGMT.Name = "lblGMT"
        Me.lblGMT.Size = New System.Drawing.Size(95, 20)
        Me.lblGMT.TabIndex = 15
        Me.lblGMT.Text = "GMT Diff +/-"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(344, 12)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 22)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Settings"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(916, 155)
        Me.cmdSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(129, 37)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Save Changes"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'chkDeleteFile
        '
        Me.chkDeleteFile.Location = New System.Drawing.Point(294, 149)
        Me.chkDeleteFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkDeleteFile.Name = "chkDeleteFile"
        Me.chkDeleteFile.Size = New System.Drawing.Size(294, 57)
        Me.chkDeleteFile.TabIndex = 11
        Me.chkDeleteFile.Text = "Delete Input File After Processing"
        Me.chkDeleteFile.UseVisualStyleBackColor = True
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(222, 158)
        Me.txtTimeout.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(48, 26)
        Me.txtTimeout.TabIndex = 10
        Me.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 163)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(192, 20)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Timeout Period (Seconds)"
        '
        'lblRetrieveHrs
        '
        Me.lblRetrieveHrs.AutoSize = True
        Me.lblRetrieveHrs.Location = New System.Drawing.Point(744, 106)
        Me.lblRetrieveHrs.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRetrieveHrs.Name = "lblRetrieveHrs"
        Me.lblRetrieveHrs.Size = New System.Drawing.Size(52, 20)
        Me.lblRetrieveHrs.TabIndex = 8
        Me.lblRetrieveHrs.Text = "Hours"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(686, 97)
        Me.txtPeriod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(48, 26)
        Me.txtPeriod.TabIndex = 7
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(518, 103)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 20)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Retrieve Last"
        '
        'txtOffset
        '
        Me.txtOffset.Location = New System.Drawing.Point(446, 95)
        Me.txtOffset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOffset.Name = "txtOffset"
        Me.txtOffset.Size = New System.Drawing.Size(48, 26)
        Me.txtOffset.TabIndex = 5
        Me.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(286, 102)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 49)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Hour Offset (Minutes)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(222, 97)
        Me.txtInterval.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(48, 26)
        Me.txtInterval.TabIndex = 3
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(20, 100)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(200, 49)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Retrieval Interval (Minutes)"
        '
        'optStop
        '
        Me.optStop.AutoSize = True
        Me.optStop.Checked = True
        Me.optStop.Location = New System.Drawing.Point(182, 40)
        Me.optStop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.optStop.Name = "optStop"
        Me.optStop.Size = New System.Drawing.Size(68, 24)
        Me.optStop.TabIndex = 1
        Me.optStop.TabStop = True
        Me.optStop.Text = "Stop"
        Me.optStop.UseVisualStyleBackColor = True
        '
        'list_errors
        '
        Me.list_errors.FormattingEnabled = True
        Me.list_errors.ItemHeight = 20
        Me.list_errors.Location = New System.Drawing.Point(16, 692)
        Me.list_errors.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.list_errors.Name = "list_errors"
        Me.list_errors.Size = New System.Drawing.Size(1092, 124)
        Me.list_errors.TabIndex = 8
        '
        'Ltime
        '
        Me.Ltime.AutoSize = True
        Me.Ltime.BackColor = System.Drawing.Color.SeaShell
        Me.Ltime.Location = New System.Drawing.Point(248, 832)
        Me.Ltime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Ltime.Name = "Ltime"
        Me.Ltime.Size = New System.Drawing.Size(21, 20)
        Me.Ltime.TabIndex = 7
        Me.Ltime.Text = "   "
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
        Me.Panel4.Location = New System.Drawing.Point(628, 251)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(480, 411)
        Me.Panel4.TabIndex = 4
        '
        'txtQC
        '
        Me.txtQC.BackColor = System.Drawing.Color.MistyRose
        Me.txtQC.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtQC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQC.Location = New System.Drawing.Point(6, 322)
        Me.txtQC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtQC.Multiline = True
        Me.txtQC.Name = "txtQC"
        Me.txtQC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtQC.Size = New System.Drawing.Size(448, 82)
        Me.txtQC.TabIndex = 21
        '
        'txtNxtProcess
        '
        Me.txtNxtProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtNxtProcess.Enabled = False
        Me.txtNxtProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNxtProcess.Location = New System.Drawing.Point(204, 165)
        Me.txtNxtProcess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNxtProcess.Name = "txtNxtProcess"
        Me.txtNxtProcess.Size = New System.Drawing.Size(244, 26)
        Me.txtNxtProcess.TabIndex = 19
        '
        'lblNextProcess
        '
        Me.lblNextProcess.AutoSize = True
        Me.lblNextProcess.Location = New System.Drawing.Point(206, 135)
        Me.lblNextProcess.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNextProcess.Name = "lblNextProcess"
        Me.lblNextProcess.Size = New System.Drawing.Size(123, 20)
        Me.lblNextProcess.TabIndex = 18
        Me.lblNextProcess.Text = "Next Processing"
        '
        'txtLastProcess
        '
        Me.txtLastProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtLastProcess.Enabled = False
        Me.txtLastProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastProcess.Location = New System.Drawing.Point(9, 165)
        Me.txtLastProcess.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLastProcess.Name = "txtLastProcess"
        Me.txtLastProcess.Size = New System.Drawing.Size(184, 26)
        Me.txtLastProcess.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 135)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 20)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Last Processed"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.SeaShell
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 274)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(446, 31)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 15
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.MistyRose
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(9, 235)
        Me.txtStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(439, 26)
        Me.txtStatus.TabIndex = 10
        Me.txtStatus.Text = "Stopped"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 209)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Status"
        '
        'txtDateTime
        '
        Me.txtDateTime.BackColor = System.Drawing.Color.MistyRose
        Me.txtDateTime.Enabled = False
        Me.txtDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateTime.Location = New System.Drawing.Point(177, 74)
        Me.txtDateTime.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDateTime.Name = "txtDateTime"
        Me.txtDateTime.Size = New System.Drawing.Size(271, 26)
        Me.txtDateTime.TabIndex = 8
        '
        'lblDatetime
        '
        Me.lblDatetime.AutoSize = True
        Me.lblDatetime.Location = New System.Drawing.Point(0, 80)
        Me.lblDatetime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDatetime.Name = "lblDatetime"
        Me.lblDatetime.Size = New System.Drawing.Size(139, 20)
        Me.lblDatetime.TabIndex = 7
        Me.lblDatetime.Text = "Current Date Time"
        '
        'lblSatus
        '
        Me.lblSatus.AutoSize = True
        Me.lblSatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSatus.Location = New System.Drawing.Point(144, 2)
        Me.lblSatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSatus.Name = "lblSatus"
        Me.lblSatus.Size = New System.Drawing.Size(172, 22)
        Me.lblSatus.TabIndex = 1
        Me.lblSatus.Text = "Processing Status"
        '
        'lblErrors
        '
        Me.lblErrors.AutoSize = True
        Me.lblErrors.Location = New System.Drawing.Point(76, 668)
        Me.lblErrors.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrors.Name = "lblErrors"
        Me.lblErrors.Size = New System.Drawing.Size(121, 20)
        Me.lblErrors.TabIndex = 3
        Me.lblErrors.Text = "Error Messages"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblInformation)
        Me.Panel1.Location = New System.Drawing.Point(20, 249)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 413)
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
        Me.Panel3.Location = New System.Drawing.Point(298, 35)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(284, 371)
        Me.Panel3.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(98, 134)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Message Files"
        '
        'lstOutputFiles
        '
        Me.lstOutputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstOutputFiles.FormattingEnabled = True
        Me.lstOutputFiles.ItemHeight = 20
        Me.lstOutputFiles.Location = New System.Drawing.Point(9, 155)
        Me.lstOutputFiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstOutputFiles.MultiColumn = True
        Me.lstOutputFiles.Name = "lstOutputFiles"
        Me.lstOutputFiles.Size = New System.Drawing.Size(262, 204)
        Me.lstOutputFiles.TabIndex = 11
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.BackColor = System.Drawing.Color.MistyRose
        Me.txtOutputFolder.Enabled = False
        Me.txtOutputFolder.Location = New System.Drawing.Point(105, 78)
        Me.txtOutputFolder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(162, 26)
        Me.txtOutputFolder.TabIndex = 10
        '
        'lblOutputFolder
        '
        Me.lblOutputFolder.AutoSize = True
        Me.lblOutputFolder.Location = New System.Drawing.Point(9, 82)
        Me.lblOutputFolder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutputFolder.Name = "lblOutputFolder"
        Me.lblOutputFolder.Size = New System.Drawing.Size(54, 20)
        Me.lblOutputFolder.TabIndex = 9
        Me.lblOutputFolder.Text = "Folder"
        '
        'txtOutputServer
        '
        Me.txtOutputServer.BackColor = System.Drawing.Color.MistyRose
        Me.txtOutputServer.Enabled = False
        Me.txtOutputServer.Location = New System.Drawing.Point(105, 34)
        Me.txtOutputServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOutputServer.Name = "txtOutputServer"
        Me.txtOutputServer.Size = New System.Drawing.Size(162, 26)
        Me.txtOutputServer.TabIndex = 8
        '
        'lblOutputFTP
        '
        Me.lblOutputFTP.AutoSize = True
        Me.lblOutputFTP.Location = New System.Drawing.Point(4, 35)
        Me.lblOutputFTP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOutputFTP.Name = "lblOutputFTP"
        Me.lblOutputFTP.Size = New System.Drawing.Size(88, 20)
        Me.lblOutputFTP.TabIndex = 7
        Me.lblOutputFTP.Text = "FTP Server"
        '
        'pnlOutput
        '
        Me.pnlOutput.AutoSize = True
        Me.pnlOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOutput.Location = New System.Drawing.Point(118, -2)
        Me.pnlOutput.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.pnlOutput.Name = "pnlOutput"
        Me.pnlOutput.Size = New System.Drawing.Size(65, 20)
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
        Me.Panel2.Location = New System.Drawing.Point(4, 34)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 373)
        Me.Panel2.TabIndex = 1
        '
        'lblInputFiles
        '
        Me.lblInputFiles.AutoSize = True
        Me.lblInputFiles.Location = New System.Drawing.Point(110, 134)
        Me.lblInputFiles.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInputFiles.Name = "lblInputFiles"
        Me.lblInputFiles.Size = New System.Drawing.Size(83, 20)
        Me.lblInputFiles.TabIndex = 7
        Me.lblInputFiles.Text = "Input Files"
        '
        'lstInputFiles
        '
        Me.lstInputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstInputFiles.FormattingEnabled = True
        Me.lstInputFiles.ItemHeight = 20
        Me.lstInputFiles.Location = New System.Drawing.Point(9, 160)
        Me.lstInputFiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstInputFiles.MultiColumn = True
        Me.lstInputFiles.Name = "lstInputFiles"
        Me.lstInputFiles.Size = New System.Drawing.Size(262, 204)
        Me.lstInputFiles.TabIndex = 6
        '
        'txtInputfolder
        '
        Me.txtInputfolder.BackColor = System.Drawing.Color.MistyRose
        Me.txtInputfolder.Enabled = False
        Me.txtInputfolder.Location = New System.Drawing.Point(105, 91)
        Me.txtInputfolder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtInputfolder.Name = "txtInputfolder"
        Me.txtInputfolder.Size = New System.Drawing.Size(162, 26)
        Me.txtInputfolder.TabIndex = 5
        '
        'lblInputFolder
        '
        Me.lblInputFolder.AutoSize = True
        Me.lblInputFolder.Location = New System.Drawing.Point(9, 94)
        Me.lblInputFolder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInputFolder.Name = "lblInputFolder"
        Me.lblInputFolder.Size = New System.Drawing.Size(54, 20)
        Me.lblInputFolder.TabIndex = 4
        Me.lblInputFolder.Text = "Folder"
        '
        'txtInputServer
        '
        Me.txtInputServer.BackColor = System.Drawing.Color.MistyRose
        Me.txtInputServer.Enabled = False
        Me.txtInputServer.Location = New System.Drawing.Point(105, 46)
        Me.txtInputServer.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtInputServer.Name = "txtInputServer"
        Me.txtInputServer.Size = New System.Drawing.Size(162, 26)
        Me.txtInputServer.TabIndex = 3
        '
        'lblSever
        '
        Me.lblSever.AutoSize = True
        Me.lblSever.Location = New System.Drawing.Point(4, 48)
        Me.lblSever.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSever.Name = "lblSever"
        Me.lblSever.Size = New System.Drawing.Size(88, 20)
        Me.lblSever.TabIndex = 2
        Me.lblSever.Text = "FTP Server"
        '
        'lblInputData
        '
        Me.lblInputData.AutoSize = True
        Me.lblInputData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputData.Location = New System.Drawing.Point(138, 0)
        Me.lblInputData.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInputData.Name = "lblInputData"
        Me.lblInputData.Size = New System.Drawing.Size(50, 20)
        Me.lblInputData.TabIndex = 1
        Me.lblInputData.Text = "Input"
        '
        'lblInformation
        '
        Me.lblInformation.AutoSize = True
        Me.lblInformation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInformation.Location = New System.Drawing.Point(224, 0)
        Me.lblInformation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(214, 22)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Processing Information"
        '
        'grpElements
        '
        Me.grpElements.Location = New System.Drawing.Point(28, 512)
        Me.grpElements.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpElements.Name = "grpElements"
        Me.grpElements.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpElements.Size = New System.Drawing.Size(1020, 65)
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
        Me.pnlDataStructures.Location = New System.Drawing.Point(286, 343)
        Me.pnlDataStructures.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlDataStructures.Name = "pnlDataStructures"
        Me.pnlDataStructures.Size = New System.Drawing.Size(1139, 154)
        Me.pnlDataStructures.TabIndex = 5
        Me.pnlDataStructures.Visible = False
        '
        'grpStructures1
        '
        Me.grpStructures1.Controls.Add(Me.lblStructure)
        Me.grpStructures1.Controls.Add(Me.grpStructures)
        Me.grpStructures1.Controls.Add(Me.cmbExistingStructures)
        Me.grpStructures1.Location = New System.Drawing.Point(291, 6)
        Me.grpStructures1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStructures1.Name = "grpStructures1"
        Me.grpStructures1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStructures1.Size = New System.Drawing.Size(584, 363)
        Me.grpStructures1.TabIndex = 1
        Me.grpStructures1.TabStop = False
        Me.grpStructures1.Text = "Data Structures"
        '
        'lblStructure
        '
        Me.lblStructure.Location = New System.Drawing.Point(16, 45)
        Me.lblStructure.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStructure.Name = "lblStructure"
        Me.lblStructure.Size = New System.Drawing.Size(219, 55)
        Me.lblStructure.TabIndex = 8
        Me.lblStructure.Text = "Select Existing Data structure"
        '
        'grpStructures
        '
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
        Me.grpStructures.Location = New System.Drawing.Point(20, 95)
        Me.grpStructures.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStructures.Name = "grpStructures"
        Me.grpStructures.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpStructures.Size = New System.Drawing.Size(538, 229)
        Me.grpStructures.TabIndex = 7
        Me.grpStructures.TabStop = False
        '
        'lblRecords
        '
        Me.lblRecords.AutoSize = True
        Me.lblRecords.Location = New System.Drawing.Point(252, 151)
        Me.lblRecords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(0, 20)
        Me.lblRecords.TabIndex = 20
        Me.lblRecords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDelimiter
        '
        Me.txtDelimiter.FormattingEnabled = True
        Me.txtDelimiter.Items.AddRange(New Object() {"comma", "tab", "space"})
        Me.txtDelimiter.Location = New System.Drawing.Point(256, 51)
        Me.txtDelimiter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(250, 28)
        Me.txtDelimiter.TabIndex = 18
        '
        'txtQualifier
        '
        Me.txtQualifier.Location = New System.Drawing.Point(256, 114)
        Me.txtQualifier.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtQualifier.Name = "txtQualifier"
        Me.txtQualifier.Size = New System.Drawing.Size(250, 26)
        Me.txtQualifier.TabIndex = 17
        '
        'txtHeaders
        '
        Me.txtHeaders.Location = New System.Drawing.Point(256, 83)
        Me.txtHeaders.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtHeaders.Name = "txtHeaders"
        Me.txtHeaders.Size = New System.Drawing.Size(250, 26)
        Me.txtHeaders.TabIndex = 16
        '
        'txtStrName
        '
        Me.txtStrName.Location = New System.Drawing.Point(256, 20)
        Me.txtStrName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStrName.Name = "txtStrName"
        Me.txtStrName.Size = New System.Drawing.Size(250, 26)
        Me.txtStrName.TabIndex = 14
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(374, 185)
        Me.cmdDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(140, 35)
        Me.cmdDelete.TabIndex = 13
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(232, 185)
        Me.cmdUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(132, 35)
        Me.cmdUpdate.TabIndex = 12
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(117, 185)
        Me.cmdCreate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(106, 35)
        Me.cmdCreate.TabIndex = 11
        Me.cmdCreate.Text = "Create"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 120)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(175, 20)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Text Qualifier Character"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 88)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(145, 20)
        Me.Label20.TabIndex = 9
        Me.Label20.Text = "Total Header Rows"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(10, 55)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(109, 20)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Delimiter Type"
        '
        'lblStrName
        '
        Me.lblStrName.AutoSize = True
        Me.lblStrName.Location = New System.Drawing.Point(9, 23)
        Me.lblStrName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStrName.Name = "lblStrName"
        Me.lblStrName.Size = New System.Drawing.Size(121, 20)
        Me.lblStrName.TabIndex = 7
        Me.lblStrName.Text = "Structure Name"
        '
        'cmbExistingStructures
        '
        Me.cmbExistingStructures.FormattingEnabled = True
        Me.cmbExistingStructures.Location = New System.Drawing.Point(276, 40)
        Me.cmbExistingStructures.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbExistingStructures.Name = "cmbExistingStructures"
        Me.cmbExistingStructures.Size = New System.Drawing.Size(246, 28)
        Me.cmbExistingStructures.TabIndex = 1
        '
        'DataGridViewStructures
        '
        Me.DataGridViewStructures.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridViewStructures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewStructures.Location = New System.Drawing.Point(4, 372)
        Me.DataGridViewStructures.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridViewStructures.Name = "DataGridViewStructures"
        Me.DataGridViewStructures.RowHeadersWidth = 62
        Me.DataGridViewStructures.Size = New System.Drawing.Size(1124, 182)
        Me.DataGridViewStructures.TabIndex = 2
        Me.DataGridViewStructures.Visible = False
        '
        'pnlSites
        '
        Me.pnlSites.AllowDrop = True
        Me.pnlSites.AutoSize = True
        Me.pnlSites.BackColor = System.Drawing.Color.Linen
        Me.pnlSites.Controls.Add(Me.grpSites)
        Me.pnlSites.Location = New System.Drawing.Point(286, 217)
        Me.pnlSites.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlSites.Name = "pnlSites"
        Me.pnlSites.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSites.Size = New System.Drawing.Size(1140, 958)
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
        Me.grpSites.Location = New System.Drawing.Point(9, 151)
        Me.grpSites.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpSites.Name = "grpSites"
        Me.grpSites.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpSites.Size = New System.Drawing.Size(1098, 578)
        Me.grpSites.TabIndex = 67
        Me.grpSites.TabStop = False
        '
        'DataGridViewSites
        '
        Me.DataGridViewSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSites.Location = New System.Drawing.Point(687, 312)
        Me.DataGridViewSites.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridViewSites.Name = "DataGridViewSites"
        Me.DataGridViewSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewSites.RowHeadersWidth = 62
        Me.DataGridViewSites.Size = New System.Drawing.Size(358, 78)
        Me.DataGridViewSites.TabIndex = 68
        Me.DataGridViewSites.Visible = False
        '
        'chkPrefix
        '
        Me.chkPrefix.AutoSize = True
        Me.chkPrefix.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.Location = New System.Drawing.Point(609, 166)
        Me.chkPrefix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkPrefix.Name = "chkPrefix"
        Me.chkPrefix.Size = New System.Drawing.Size(158, 24)
        Me.chkPrefix.TabIndex = 101
        Me.chkPrefix.Text = "Files name  prefix"
        Me.chkPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPrefix.UseVisualStyleBackColor = True
        '
        'txtfilePrefix
        '
        Me.txtfilePrefix.Location = New System.Drawing.Point(828, 163)
        Me.txtfilePrefix.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtfilePrefix.Name = "txtfilePrefix"
        Me.txtfilePrefix.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtfilePrefix.Size = New System.Drawing.Size(216, 26)
        Me.txtfilePrefix.TabIndex = 100
        Me.txtfilePrefix.Visible = False
        '
        'txtGTSHeader
        '
        Me.txtGTSHeader.Location = New System.Drawing.Point(316, 329)
        Me.txtGTSHeader.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtGTSHeader.Name = "txtGTSHeader"
        Me.txtGTSHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGTSHeader.Size = New System.Drawing.Size(204, 26)
        Me.txtGTSHeader.TabIndex = 98
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(48, 338)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(133, 20)
        Me.Label42.TabIndex = 97
        Me.Label42.Text = "GTS Msg Header"
        '
        'chkGTSEncode
        '
        Me.chkGTSEncode.AutoSize = True
        Me.chkGTSEncode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkGTSEncode.Location = New System.Drawing.Point(46, 415)
        Me.chkGTSEncode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkGTSEncode.Name = "chkGTSEncode"
        Me.chkGTSEncode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkGTSEncode.Size = New System.Drawing.Size(158, 24)
        Me.chkGTSEncode.TabIndex = 96
        Me.chkGTSEncode.Text = "Encode for GTS  "
        Me.chkGTSEncode.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkGTSEncode.UseVisualStyleBackColor = True
        '
        'txtSiteName
        '
        Me.txtSiteName.FormattingEnabled = True
        Me.txtSiteName.Location = New System.Drawing.Point(316, 125)
        Me.txtSiteName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteName.Size = New System.Drawing.Size(418, 28)
        Me.txtSiteName.TabIndex = 95
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(48, 134)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(83, 20)
        Me.Label41.TabIndex = 94
        Me.Label41.Text = "Site Name"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(176, 488)
        Me.cmdClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(114, 37)
        Me.cmdClear.TabIndex = 88
        Me.cmdClear.Text = "AddNew"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewUpdate
        '
        Me.cmdViewUpdate.Location = New System.Drawing.Point(648, 485)
        Me.cmdViewUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdViewUpdate.Name = "cmdViewUpdate"
        Me.cmdViewUpdate.Size = New System.Drawing.Size(207, 37)
        Me.cmdViewUpdate.TabIndex = 87
        Me.cmdViewUpdate.Text = "View/Update"
        Me.cmdViewUpdate.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        Me.cmdDel.Location = New System.Drawing.Point(536, 486)
        Me.cmdDel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(105, 37)
        Me.cmdDel.TabIndex = 86
        Me.cmdDel.Text = "Delete"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpdateSites
        '
        Me.cmdUpdateSites.Location = New System.Drawing.Point(426, 488)
        Me.cmdUpdateSites.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdUpdateSites.Name = "cmdUpdateSites"
        Me.cmdUpdateSites.Size = New System.Drawing.Size(102, 37)
        Me.cmdUpdateSites.TabIndex = 85
        Me.cmdUpdateSites.Text = "Update"
        Me.cmdUpdateSites.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(298, 488)
        Me.cmdAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(124, 37)
        Me.cmdAdd.TabIndex = 84
        Me.cmdAdd.Text = "Save"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.BackgroundImage = CType(resources.GetObject("btnMovePrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnMovePrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(70, 532)
        Me.btnMovePrevious.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(62, 35)
        Me.btnMovePrevious.TabIndex = 83
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.BackgroundImage = CType(resources.GetObject("btnMoveFirst.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveFirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(14, 532)
        Me.btnMoveFirst.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(62, 35)
        Me.btnMoveFirst.TabIndex = 82
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.BackgroundImage = CType(resources.GetObject("btnMoveLast.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(987, 532)
        Me.btnMoveLast.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(62, 35)
        Me.btnMoveLast.TabIndex = 81
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'txtSitesNavigator
        '
        Me.txtSitesNavigator.Location = New System.Drawing.Point(130, 534)
        Me.txtSitesNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSitesNavigator.Name = "txtSitesNavigator"
        Me.txtSitesNavigator.Size = New System.Drawing.Size(802, 26)
        Me.txtSitesNavigator.TabIndex = 80
        Me.txtSitesNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMoveNext
        '
        Me.btnMoveNext.BackgroundImage = CType(resources.GetObject("btnMoveNext.BackgroundImage"), System.Drawing.Image)
        Me.btnMoveNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(934, 532)
        Me.btnMoveNext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(62, 35)
        Me.btnMoveNext.TabIndex = 79
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 383)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Operational"
        '
        'txtIP
        '
        Me.txtIP.FormattingEnabled = True
        Me.txtIP.Location = New System.Drawing.Point(315, 288)
        Me.txtIP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(204, 28)
        Me.txtIP.TabIndex = 77
        '
        'txtDataStructure
        '
        Me.txtDataStructure.FormattingEnabled = True
        Me.txtDataStructure.Location = New System.Drawing.Point(316, 206)
        Me.txtDataStructure.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDataStructure.Name = "txtDataStructure"
        Me.txtDataStructure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataStructure.Size = New System.Drawing.Size(276, 28)
        Me.txtDataStructure.TabIndex = 76
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(316, 248)
        Me.txtFlag.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFlag.Size = New System.Drawing.Size(204, 26)
        Me.txtFlag.TabIndex = 75
        '
        'chkOperational
        '
        Me.chkOperational.AutoSize = True
        Me.chkOperational.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOperational.Location = New System.Drawing.Point(188, 385)
        Me.chkOperational.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkOperational.Name = "chkOperational"
        Me.chkOperational.Size = New System.Drawing.Size(22, 21)
        Me.chkOperational.TabIndex = 74
        Me.chkOperational.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkOperational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(46, 300)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(115, 20)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "AWS Server IP"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(46, 257)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 20)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Missing Data Flag"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(46, 218)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 20)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Data Strucure"
        '
        'txtInFile
        '
        Me.txtInFile.Location = New System.Drawing.Point(315, 166)
        Me.txtInFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtInFile.Name = "txtInFile"
        Me.txtInFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInFile.Size = New System.Drawing.Size(277, 26)
        Me.txtInFile.TabIndex = 70
        '
        'lblInfile
        '
        Me.lblInfile.AutoSize = True
        Me.lblInfile.Location = New System.Drawing.Point(46, 177)
        Me.lblInfile.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInfile.Name = "lblInfile"
        Me.lblInfile.Size = New System.Drawing.Size(109, 20)
        Me.lblInfile.TabIndex = 69
        Me.lblInfile.Text = "Input Data file"
        '
        'txtSiteID
        '
        Me.txtSiteID.FormattingEnabled = True
        Me.txtSiteID.Location = New System.Drawing.Point(316, 83)
        Me.txtSiteID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteID.Size = New System.Drawing.Size(204, 28)
        Me.txtSiteID.TabIndex = 68
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(46, 85)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 20)
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
        Me.pnlServers.Location = New System.Drawing.Point(286, 489)
        Me.pnlServers.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlServers.Name = "pnlServers"
        Me.pnlServers.Size = New System.Drawing.Size(1139, 119)
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
        Me.pnlBaseStation.Location = New System.Drawing.Point(108, 140)
        Me.pnlBaseStation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlBaseStation.Name = "pnlBaseStation"
        Me.pnlBaseStation.Size = New System.Drawing.Size(815, 454)
        Me.pnlBaseStation.TabIndex = 4
        '
        'cmdBstAddNew
        '
        Me.cmdBstAddNew.Location = New System.Drawing.Point(42, 357)
        Me.cmdBstAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBstAddNew.Name = "cmdBstAddNew"
        Me.cmdBstAddNew.Size = New System.Drawing.Size(117, 32)
        Me.cmdBstAddNew.TabIndex = 75
        Me.cmdBstAddNew.Text = "Add New"
        Me.cmdBstAddNew.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(546, 357)
        Me.cmdRefresh.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(117, 32)
        Me.cmdRefresh.TabIndex = 74
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(420, 357)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(117, 32)
        Me.cmdReset.TabIndex = 13
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'txtBasestationFTPMode
        '
        Me.txtBasestationFTPMode.FormattingEnabled = True
        Me.txtBasestationFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtBasestationFTPMode.Location = New System.Drawing.Point(342, 158)
        Me.txtBasestationFTPMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBasestationFTPMode.Name = "txtBasestationFTPMode"
        Me.txtBasestationFTPMode.Size = New System.Drawing.Size(172, 28)
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
        Me.GroupBox10.Location = New System.Drawing.Point(0, 404)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Size = New System.Drawing.Size(813, 48)
        Me.GroupBox10.TabIndex = 72
        Me.GroupBox10.TabStop = False
        '
        'cmdPrevRecord
        '
        Me.cmdPrevRecord.BackgroundImage = CType(resources.GetObject("cmdPrevRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdPrevRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdPrevRecord.Location = New System.Drawing.Point(51, 9)
        Me.cmdPrevRecord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdPrevRecord.Name = "cmdPrevRecord"
        Me.cmdPrevRecord.Size = New System.Drawing.Size(54, 37)
        Me.cmdPrevRecord.TabIndex = 4
        Me.cmdPrevRecord.UseVisualStyleBackColor = True
        '
        'cmdFirstRecord
        '
        Me.cmdFirstRecord.BackgroundImage = CType(resources.GetObject("cmdFirstRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdFirstRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFirstRecord.Location = New System.Drawing.Point(0, 9)
        Me.cmdFirstRecord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdFirstRecord.Name = "cmdFirstRecord"
        Me.cmdFirstRecord.Size = New System.Drawing.Size(52, 37)
        Me.cmdFirstRecord.TabIndex = 3
        Me.cmdFirstRecord.UseVisualStyleBackColor = True
        '
        'cmdLastRecord
        '
        Me.cmdLastRecord.BackgroundImage = CType(resources.GetObject("cmdLastRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdLastRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdLastRecord.Location = New System.Drawing.Point(654, 9)
        Me.cmdLastRecord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdLastRecord.Name = "cmdLastRecord"
        Me.cmdLastRecord.Size = New System.Drawing.Size(54, 37)
        Me.cmdLastRecord.TabIndex = 2
        Me.cmdLastRecord.UseVisualStyleBackColor = True
        '
        'cmdNextRecord
        '
        Me.cmdNextRecord.BackgroundImage = CType(resources.GetObject("cmdNextRecord.BackgroundImage"), System.Drawing.Image)
        Me.cmdNextRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdNextRecord.Location = New System.Drawing.Point(602, 9)
        Me.cmdNextRecord.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdNextRecord.Name = "cmdNextRecord"
        Me.cmdNextRecord.Size = New System.Drawing.Size(54, 37)
        Me.cmdNextRecord.TabIndex = 1
        Me.cmdNextRecord.UseVisualStyleBackColor = True
        '
        'txtbssNavigator
        '
        Me.txtbssNavigator.Location = New System.Drawing.Point(105, 12)
        Me.txtbssNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbssNavigator.Name = "txtbssNavigator"
        Me.txtbssNavigator.Size = New System.Drawing.Size(498, 26)
        Me.txtbssNavigator.TabIndex = 0
        Me.txtbssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(120, 163)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(145, 20)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "FTP Transfer Mode"
        '
        'lblbaseStation
        '
        Me.lblbaseStation.AutoSize = True
        Me.lblbaseStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbaseStation.Location = New System.Drawing.Point(302, 20)
        Me.lblbaseStation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblbaseStation.Name = "lblbaseStation"
        Me.lblbaseStation.Size = New System.Drawing.Size(117, 20)
        Me.lblbaseStation.TabIndex = 30
        Me.lblbaseStation.Text = "Base Station"
        '
        'cmdBstDelete
        '
        Me.cmdBstDelete.Location = New System.Drawing.Point(672, 357)
        Me.cmdBstDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBstDelete.Name = "cmdBstDelete"
        Me.cmdBstDelete.Size = New System.Drawing.Size(104, 32)
        Me.cmdBstDelete.TabIndex = 14
        Me.cmdBstDelete.Text = "Delete"
        Me.cmdBstDelete.UseVisualStyleBackColor = True
        '
        'cmdBsstUpdate
        '
        Me.cmdBsstUpdate.Location = New System.Drawing.Point(294, 357)
        Me.cmdBsstUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBsstUpdate.Name = "cmdBsstUpdate"
        Me.cmdBsstUpdate.Size = New System.Drawing.Size(117, 32)
        Me.cmdBsstUpdate.TabIndex = 12
        Me.cmdBsstUpdate.Text = "Update"
        Me.cmdBsstUpdate.UseVisualStyleBackColor = True
        '
        'cmdBstSave
        '
        Me.cmdBstSave.Location = New System.Drawing.Point(168, 357)
        Me.cmdBstSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBstSave.Name = "cmdBstSave"
        Me.cmdBstSave.Size = New System.Drawing.Size(117, 32)
        Me.cmdBstSave.TabIndex = 11
        Me.cmdBstSave.Text = "Save"
        Me.cmdBstSave.UseVisualStyleBackColor = True
        '
        'txtbaseStationPWConfirm
        '
        Me.txtbaseStationPWConfirm.Location = New System.Drawing.Point(340, 302)
        Me.txtbaseStationPWConfirm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbaseStationPWConfirm.Name = "txtbaseStationPWConfirm"
        Me.txtbaseStationPWConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPWConfirm.Size = New System.Drawing.Size(128, 26)
        Me.txtbaseStationPWConfirm.TabIndex = 10
        '
        'txtbaseStationPW
        '
        Me.txtbaseStationPW.Location = New System.Drawing.Point(340, 254)
        Me.txtbaseStationPW.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbaseStationPW.Name = "txtbaseStationPW"
        Me.txtbaseStationPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPW.Size = New System.Drawing.Size(128, 26)
        Me.txtbaseStationPW.TabIndex = 9
        '
        'txtBaseStationUser
        '
        Me.txtBaseStationUser.Location = New System.Drawing.Point(340, 206)
        Me.txtBaseStationUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBaseStationUser.Name = "txtBaseStationUser"
        Me.txtBaseStationUser.Size = New System.Drawing.Size(128, 26)
        Me.txtBaseStationUser.TabIndex = 8
        '
        'txtBaseStationFolder
        '
        Me.txtBaseStationFolder.Location = New System.Drawing.Point(340, 111)
        Me.txtBaseStationFolder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBaseStationFolder.Name = "txtBaseStationFolder"
        Me.txtBaseStationFolder.Size = New System.Drawing.Size(174, 26)
        Me.txtBaseStationFolder.TabIndex = 6
        '
        'txtBaseStationAddress
        '
        Me.txtBaseStationAddress.Location = New System.Drawing.Point(340, 63)
        Me.txtBaseStationAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBaseStationAddress.Name = "txtBaseStationAddress"
        Me.txtBaseStationAddress.Size = New System.Drawing.Size(278, 26)
        Me.txtBaseStationAddress.TabIndex = 5
        '
        'lblConfirmInputPW
        '
        Me.lblConfirmInputPW.AutoSize = True
        Me.lblConfirmInputPW.Location = New System.Drawing.Point(120, 306)
        Me.lblConfirmInputPW.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConfirmInputPW.Name = "lblConfirmInputPW"
        Me.lblConfirmInputPW.Size = New System.Drawing.Size(137, 20)
        Me.lblConfirmInputPW.TabIndex = 4
        Me.lblConfirmInputPW.Text = "Confirm Password"
        '
        'lblInputPW
        '
        Me.lblInputPW.AutoSize = True
        Me.lblInputPW.Location = New System.Drawing.Point(120, 258)
        Me.lblInputPW.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInputPW.Name = "lblInputPW"
        Me.lblInputPW.Size = New System.Drawing.Size(82, 20)
        Me.lblInputPW.TabIndex = 3
        Me.lblInputPW.Text = "PassWord"
        '
        'lblInputUser
        '
        Me.lblInputUser.AutoSize = True
        Me.lblInputUser.Location = New System.Drawing.Point(118, 211)
        Me.lblInputUser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInputUser.Name = "lblInputUser"
        Me.lblInputUser.Size = New System.Drawing.Size(89, 20)
        Me.lblInputUser.TabIndex = 2
        Me.lblInputUser.Text = "User Name"
        '
        'lblFTPFolder
        '
        Me.lblFTPFolder.AutoSize = True
        Me.lblFTPFolder.Location = New System.Drawing.Point(120, 115)
        Me.lblFTPFolder.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFTPFolder.Name = "lblFTPFolder"
        Me.lblFTPFolder.Size = New System.Drawing.Size(95, 20)
        Me.lblFTPFolder.TabIndex = 1
        Me.lblFTPFolder.Text = "Input Folder"
        '
        'lblBaseStationFTP
        '
        Me.lblBaseStationFTP.AutoSize = True
        Me.lblBaseStationFTP.Location = New System.Drawing.Point(118, 68)
        Me.lblBaseStationFTP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBaseStationFTP.Name = "lblBaseStationFTP"
        Me.lblBaseStationFTP.Size = New System.Drawing.Size(101, 20)
        Me.lblBaseStationFTP.TabIndex = 0
        Me.lblBaseStationFTP.Text = "FTP Address"
        '
        'cmdMSS
        '
        Me.cmdMSS.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdMSS.Location = New System.Drawing.Point(520, 60)
        Me.cmdMSS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMSS.Name = "cmdMSS"
        Me.cmdMSS.Size = New System.Drawing.Size(219, 51)
        Me.cmdMSS.TabIndex = 1
        Me.cmdMSS.Text = "Message Switch"
        Me.cmdMSS.UseVisualStyleBackColor = True
        '
        'cmdBaseStation
        '
        Me.cmdBaseStation.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdBaseStation.Location = New System.Drawing.Point(302, 60)
        Me.cmdBaseStation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdBaseStation.Name = "cmdBaseStation"
        Me.cmdBaseStation.Size = New System.Drawing.Size(214, 51)
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
        Me.pnlMSS.Location = New System.Drawing.Point(158, 140)
        Me.pnlMSS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlMSS.Name = "pnlMSS"
        Me.pnlMSS.Size = New System.Drawing.Size(710, 440)
        Me.pnlMSS.TabIndex = 3
        '
        'lstFolders
        '
        Me.lstFolders.FormattingEnabled = True
        Me.lstFolders.ItemHeight = 20
        Me.lstFolders.Items.AddRange(New Object() {"binary", "ASC"})
        Me.lstFolders.Location = New System.Drawing.Point(515, 102)
        Me.lstFolders.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstFolders.Name = "lstFolders"
        Me.lstFolders.Size = New System.Drawing.Size(133, 24)
        Me.lstFolders.TabIndex = 78
        '
        'cmdMssAddNew
        '
        Me.cmdMssAddNew.Location = New System.Drawing.Point(33, 345)
        Me.cmdMssAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssAddNew.Name = "cmdMssAddNew"
        Me.cmdMssAddNew.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssAddNew.TabIndex = 77
        Me.cmdMssAddNew.Text = "AddNew"
        Me.cmdMssAddNew.UseVisualStyleBackColor = True
        '
        'cmdMssRefresh
        '
        Me.cmdMssRefresh.Location = New System.Drawing.Point(483, 348)
        Me.cmdMssRefresh.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssRefresh.Name = "cmdMssRefresh"
        Me.cmdMssRefresh.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssRefresh.TabIndex = 76
        Me.cmdMssRefresh.Text = "Refresh"
        Me.cmdMssRefresh.UseVisualStyleBackColor = True
        '
        'cmdMssReset
        '
        Me.cmdMssReset.Location = New System.Drawing.Point(366, 348)
        Me.cmdMssReset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssReset.Name = "cmdMssReset"
        Me.cmdMssReset.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssReset.TabIndex = 75
        Me.cmdMssReset.Text = "Reset"
        Me.cmdMssReset.UseVisualStyleBackColor = True
        '
        'txtmssFTPMode
        '
        Me.txtmssFTPMode.FormattingEnabled = True
        Me.txtmssFTPMode.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.txtmssFTPMode.Location = New System.Drawing.Point(330, 145)
        Me.txtmssFTPMode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtmssFTPMode.Name = "txtmssFTPMode"
        Me.txtmssFTPMode.Size = New System.Drawing.Size(172, 28)
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
        Me.GroupBox1.Location = New System.Drawing.Point(0, 383)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(708, 55)
        Me.GroupBox1.TabIndex = 71
        Me.GroupBox1.TabStop = False
        '
        'cmdmssPrev
        '
        Me.cmdmssPrev.BackgroundImage = CType(resources.GetObject("cmdmssPrev.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssPrev.Location = New System.Drawing.Point(51, 9)
        Me.cmdmssPrev.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdmssPrev.Name = "cmdmssPrev"
        Me.cmdmssPrev.Size = New System.Drawing.Size(54, 37)
        Me.cmdmssPrev.TabIndex = 4
        Me.cmdmssPrev.UseVisualStyleBackColor = True
        '
        'cmdmssfirst
        '
        Me.cmdmssfirst.BackgroundImage = CType(resources.GetObject("cmdmssfirst.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssfirst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssfirst.Location = New System.Drawing.Point(0, 9)
        Me.cmdmssfirst.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdmssfirst.Name = "cmdmssfirst"
        Me.cmdmssfirst.Size = New System.Drawing.Size(52, 37)
        Me.cmdmssfirst.TabIndex = 3
        Me.cmdmssfirst.UseVisualStyleBackColor = True
        '
        'cmdmssLast
        '
        Me.cmdmssLast.BackgroundImage = CType(resources.GetObject("cmdmssLast.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssLast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssLast.Location = New System.Drawing.Point(654, 9)
        Me.cmdmssLast.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdmssLast.Name = "cmdmssLast"
        Me.cmdmssLast.Size = New System.Drawing.Size(54, 37)
        Me.cmdmssLast.TabIndex = 2
        Me.cmdmssLast.UseVisualStyleBackColor = True
        '
        'cmdmssNext
        '
        Me.cmdmssNext.BackgroundImage = CType(resources.GetObject("cmdmssNext.BackgroundImage"), System.Drawing.Image)
        Me.cmdmssNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdmssNext.Location = New System.Drawing.Point(602, 9)
        Me.cmdmssNext.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdmssNext.Name = "cmdmssNext"
        Me.cmdmssNext.Size = New System.Drawing.Size(54, 37)
        Me.cmdmssNext.TabIndex = 1
        Me.cmdmssNext.UseVisualStyleBackColor = True
        '
        'txtmssNavigator
        '
        Me.txtmssNavigator.Location = New System.Drawing.Point(105, 12)
        Me.txtmssNavigator.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtmssNavigator.Name = "txtmssNavigator"
        Me.txtmssNavigator.Size = New System.Drawing.Size(498, 26)
        Me.txtmssNavigator.TabIndex = 0
        Me.txtmssNavigator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFtpTransferMode
        '
        Me.lblFtpTransferMode.AutoSize = True
        Me.lblFtpTransferMode.Location = New System.Drawing.Point(112, 149)
        Me.lblFtpTransferMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFtpTransferMode.Name = "lblFtpTransferMode"
        Me.lblFtpTransferMode.Size = New System.Drawing.Size(145, 20)
        Me.lblFtpTransferMode.TabIndex = 14
        Me.lblFtpTransferMode.Text = "FTP Transfer Mode"
        '
        'lblMsgSwitch
        '
        Me.lblMsgSwitch.AutoSize = True
        Me.lblMsgSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgSwitch.Location = New System.Drawing.Point(303, 15)
        Me.lblMsgSwitch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMsgSwitch.Name = "lblMsgSwitch"
        Me.lblMsgSwitch.Size = New System.Drawing.Size(146, 20)
        Me.lblMsgSwitch.TabIndex = 13
        Me.lblMsgSwitch.Text = "Message Switch"
        '
        'cmdMssDelete
        '
        Me.cmdMssDelete.Location = New System.Drawing.Point(600, 348)
        Me.cmdMssDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssDelete.Name = "cmdMssDelete"
        Me.cmdMssDelete.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssDelete.TabIndex = 12
        Me.cmdMssDelete.Text = "Delete"
        Me.cmdMssDelete.UseVisualStyleBackColor = True
        '
        'cmdMssUpdate
        '
        Me.cmdMssUpdate.Location = New System.Drawing.Point(249, 348)
        Me.cmdMssUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssUpdate.Name = "cmdMssUpdate"
        Me.cmdMssUpdate.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssUpdate.TabIndex = 11
        Me.cmdMssUpdate.Text = "Update"
        Me.cmdMssUpdate.UseVisualStyleBackColor = True
        '
        'cmdMssSave
        '
        Me.cmdMssSave.Location = New System.Drawing.Point(135, 345)
        Me.cmdMssSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdMssSave.Name = "cmdMssSave"
        Me.cmdMssSave.Size = New System.Drawing.Size(88, 32)
        Me.cmdMssSave.TabIndex = 10
        Me.cmdMssSave.Text = "Save"
        Me.cmdMssSave.UseVisualStyleBackColor = True
        '
        'txtMSSConfirm
        '
        Me.txtMSSConfirm.Location = New System.Drawing.Point(330, 277)
        Me.txtMSSConfirm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMSSConfirm.Name = "txtMSSConfirm"
        Me.txtMSSConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSConfirm.Size = New System.Drawing.Size(120, 26)
        Me.txtMSSConfirm.TabIndex = 10
        '
        'txtMSSPW
        '
        Me.txtMSSPW.Location = New System.Drawing.Point(330, 232)
        Me.txtMSSPW.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMSSPW.Name = "txtMSSPW"
        Me.txtMSSPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSPW.Size = New System.Drawing.Size(120, 26)
        Me.txtMSSPW.TabIndex = 9
        '
        'txtmssUser
        '
        Me.txtmssUser.Location = New System.Drawing.Point(330, 188)
        Me.txtmssUser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtmssUser.Name = "txtmssUser"
        Me.txtmssUser.Size = New System.Drawing.Size(120, 26)
        Me.txtmssUser.TabIndex = 8
        '
        'txtMSSFolder
        '
        Me.txtMSSFolder.Location = New System.Drawing.Point(330, 98)
        Me.txtMSSFolder.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMSSFolder.Name = "txtMSSFolder"
        Me.txtMSSFolder.Size = New System.Drawing.Size(180, 26)
        Me.txtMSSFolder.TabIndex = 6
        '
        'txtMSSAddress
        '
        Me.txtMSSAddress.Location = New System.Drawing.Point(330, 54)
        Me.txtMSSAddress.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMSSAddress.Name = "txtMSSAddress"
        Me.txtMSSAddress.Size = New System.Drawing.Size(319, 26)
        Me.txtMSSAddress.TabIndex = 5
        '
        'lblmssConfirmPassword
        '
        Me.lblmssConfirmPassword.AutoSize = True
        Me.lblmssConfirmPassword.Location = New System.Drawing.Point(110, 283)
        Me.lblmssConfirmPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmssConfirmPassword.Name = "lblmssConfirmPassword"
        Me.lblmssConfirmPassword.Size = New System.Drawing.Size(137, 20)
        Me.lblmssConfirmPassword.TabIndex = 4
        Me.lblmssConfirmPassword.Text = "Confirm Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(112, 238)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(109, 194)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "User Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(110, 105)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Input Folder"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(110, 60)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 20)
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
        Me.pnlMsgEncoding.Location = New System.Drawing.Point(304, 562)
        Me.pnlMsgEncoding.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pnlMsgEncoding.Name = "pnlMsgEncoding"
        Me.pnlMsgEncoding.Size = New System.Drawing.Size(1088, 331)
        Me.pnlMsgEncoding.TabIndex = 4
        Me.pnlMsgEncoding.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgrdCodeFlag)
        Me.GroupBox6.Location = New System.Drawing.Point(524, 31)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox6.Size = New System.Drawing.Size(562, 717)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Code and Flags"
        '
        'dgrdCodeFlag
        '
        Me.dgrdCodeFlag.BackgroundColor = System.Drawing.Color.Ivory
        Me.dgrdCodeFlag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgrdCodeFlag.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgrdCodeFlag.Location = New System.Drawing.Point(4, 24)
        Me.dgrdCodeFlag.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgrdCodeFlag.Name = "dgrdCodeFlag"
        Me.dgrdCodeFlag.RowHeadersWidth = 62
        Me.dgrdCodeFlag.Size = New System.Drawing.Size(554, 688)
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
        Me.grpIndicators.Location = New System.Drawing.Point(14, 245)
        Me.grpIndicators.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpIndicators.Size = New System.Drawing.Size(506, 503)
        Me.grpIndicators.TabIndex = 1
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Text = "BUFR Section 2"
        '
        'cmdDefault
        '
        Me.cmdDefault.Location = New System.Drawing.Point(334, 438)
        Me.cmdDefault.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdDefault.Name = "cmdDefault"
        Me.cmdDefault.Size = New System.Drawing.Size(162, 42)
        Me.cmdDefault.TabIndex = 24
        Me.cmdDefault.Text = "Set Default"
        Me.cmdDefault.UseVisualStyleBackColor = True
        '
        'cmdSaves
        '
        Me.cmdSaves.Location = New System.Drawing.Point(104, 437)
        Me.cmdSaves.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdSaves.Name = "cmdSaves"
        Me.cmdSaves.Size = New System.Drawing.Size(110, 40)
        Me.cmdSaves.TabIndex = 23
        Me.cmdSaves.Text = "Save"
        Me.cmdSaves.UseVisualStyleBackColor = True
        '
        'cmdUpadate
        '
        Me.cmdUpadate.Location = New System.Drawing.Point(220, 438)
        Me.cmdUpadate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdUpadate.Name = "cmdUpadate"
        Me.cmdUpadate.Size = New System.Drawing.Size(105, 40)
        Me.cmdUpadate.TabIndex = 22
        Me.cmdUpadate.Text = "Update"
        Me.cmdUpadate.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(4, 438)
        Me.cmdNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(92, 38)
        Me.cmdNew.TabIndex = 21
        Me.cmdNew.Text = "AddNew"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'chkOptionalSection
        '
        Me.chkOptionalSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOptionalSection.Location = New System.Drawing.Point(22, 194)
        Me.chkOptionalSection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkOptionalSection.Name = "chkOptionalSection"
        Me.chkOptionalSection.Size = New System.Drawing.Size(400, 29)
        Me.chkOptionalSection.TabIndex = 20
        Me.chkOptionalSection.Tag = "  "
        Me.chkOptionalSection.Text = "Option Section Inclusion                      "
        Me.chkOptionalSection.UseVisualStyleBackColor = True
        '
        'txtLocaltableVersion
        '
        Me.txtLocaltableVersion.Location = New System.Drawing.Point(399, 362)
        Me.txtLocaltableVersion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLocaltableVersion.Name = "txtLocaltableVersion"
        Me.txtLocaltableVersion.Size = New System.Drawing.Size(96, 26)
        Me.txtLocaltableVersion.TabIndex = 19
        '
        'txtMastertableVersion
        '
        Me.txtMastertableVersion.Location = New System.Drawing.Point(399, 329)
        Me.txtMastertableVersion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMastertableVersion.Name = "txtMastertableVersion"
        Me.txtMastertableVersion.Size = New System.Drawing.Size(96, 26)
        Me.txtMastertableVersion.TabIndex = 18
        '
        'txtLocalSubcategory
        '
        Me.txtLocalSubcategory.Location = New System.Drawing.Point(399, 297)
        Me.txtLocalSubcategory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLocalSubcategory.Name = "txtLocalSubcategory"
        Me.txtLocalSubcategory.Size = New System.Drawing.Size(96, 26)
        Me.txtLocalSubcategory.TabIndex = 17
        '
        'txtInternationalSubcategory
        '
        Me.txtInternationalSubcategory.Location = New System.Drawing.Point(399, 265)
        Me.txtInternationalSubcategory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtInternationalSubcategory.Name = "txtInternationalSubcategory"
        Me.txtInternationalSubcategory.Size = New System.Drawing.Size(96, 26)
        Me.txtInternationalSubcategory.TabIndex = 16
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(399, 232)
        Me.txtDataCategory.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(96, 26)
        Me.txtDataCategory.TabIndex = 15
        '
        'txtUpdateSequence
        '
        Me.txtUpdateSequence.Location = New System.Drawing.Point(399, 154)
        Me.txtUpdateSequence.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtUpdateSequence.Name = "txtUpdateSequence"
        Me.txtUpdateSequence.Size = New System.Drawing.Size(96, 26)
        Me.txtUpdateSequence.TabIndex = 13
        '
        'txtOriginatingSubcentre
        '
        Me.txtOriginatingSubcentre.Location = New System.Drawing.Point(399, 122)
        Me.txtOriginatingSubcentre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOriginatingSubcentre.Name = "txtOriginatingSubcentre"
        Me.txtOriginatingSubcentre.Size = New System.Drawing.Size(96, 26)
        Me.txtOriginatingSubcentre.TabIndex = 12
        '
        'txtOriginatingCentre
        '
        Me.txtOriginatingCentre.Location = New System.Drawing.Point(399, 89)
        Me.txtOriginatingCentre.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtOriginatingCentre.Name = "txtOriginatingCentre"
        Me.txtOriginatingCentre.Size = New System.Drawing.Size(96, 26)
        Me.txtOriginatingCentre.TabIndex = 11
        '
        'txtBufrEdition
        '
        Me.txtBufrEdition.Location = New System.Drawing.Point(399, 57)
        Me.txtBufrEdition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBufrEdition.Name = "txtBufrEdition"
        Me.txtBufrEdition.Size = New System.Drawing.Size(96, 26)
        Me.txtBufrEdition.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(21, 371)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(176, 20)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Local Table Version No."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(22, 338)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(187, 20)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Master Table Version No."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(22, 306)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(188, 20)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Local Data Sub-Category"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(22, 274)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(239, 20)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "International Data Sub-Category"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(22, 242)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(112, 20)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Data Category"
        '
        'txtUpdateSequenceNumber
        '
        Me.txtUpdateSequenceNumber.AutoSize = True
        Me.txtUpdateSequenceNumber.Location = New System.Drawing.Point(22, 158)
        Me.txtUpdateSequenceNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtUpdateSequenceNumber.Name = "txtUpdateSequenceNumber"
        Me.txtUpdateSequenceNumber.Size = New System.Drawing.Size(167, 20)
        Me.txtUpdateSequenceNumber.TabIndex = 3
        Me.txtUpdateSequenceNumber.Text = "Update Sequence No."
        '
        'txtOriginatingGeneratingSubCentre
        '
        Me.txtOriginatingGeneratingSubCentre.AutoSize = True
        Me.txtOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(22, 126)
        Me.txtOriginatingGeneratingSubCentre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtOriginatingGeneratingSubCentre.Name = "txtOriginatingGeneratingSubCentre"
        Me.txtOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(255, 20)
        Me.txtOriginatingGeneratingSubCentre.TabIndex = 2
        Me.txtOriginatingGeneratingSubCentre.Text = "Originating/Generating Sub-Centre"
        '
        'txtOriginatingGeneratingCentre
        '
        Me.txtOriginatingGeneratingCentre.AutoSize = True
        Me.txtOriginatingGeneratingCentre.Location = New System.Drawing.Point(22, 94)
        Me.txtOriginatingGeneratingCentre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        Me.txtOriginatingGeneratingCentre.Size = New System.Drawing.Size(221, 20)
        Me.txtOriginatingGeneratingCentre.TabIndex = 1
        Me.txtOriginatingGeneratingCentre.Text = "Originating/Generating Centre"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(22, 62)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(135, 20)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "BUFR Edition No."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTemplate)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.txtMsgHeader)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Location = New System.Drawing.Point(14, 31)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox5.Size = New System.Drawing.Size(501, 174)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        Me.GroupBox5.Text = "Header and Templates"
        '
        'txtTemplate
        '
        Me.txtTemplate.FormattingEnabled = True
        Me.txtTemplate.Location = New System.Drawing.Point(207, 52)
        Me.txtTemplate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(278, 28)
        Me.txtTemplate.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 57)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(146, 20)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Encoding Template"
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(292, 105)
        Me.txtMsgHeader.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(193, 26)
        Me.txtMsgHeader.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(12, 109)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(239, 20)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1440, 946)
        Me.Controls.Add(Me.pnlProcessing)
        Me.Controls.Add(Me.pnlDataStructures)
        Me.Controls.Add(Me.pnlServers)
        Me.Controls.Add(Me.pnlSites)
        Me.Controls.Add(Me.pnlMsgEncoding)
        Me.Controls.Add(Me.pnlControl)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
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
End Class
