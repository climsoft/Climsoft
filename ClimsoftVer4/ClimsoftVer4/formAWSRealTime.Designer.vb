<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAWSRealTime
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
        Me.Ltime = New System.Windows.Forms.Label()
        Me.pnlProcessSettings = New System.Windows.Forms.Panel()
        Me.txtGMTDiff = New System.Windows.Forms.TextBox()
        Me.lblGMT = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.chkDeleteFile = New System.Windows.Forms.CheckBox()
        Me.txtTimeout = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPeriod = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOffset = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInterval = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.optStop = New System.Windows.Forms.RadioButton()
        Me.optStart = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtNxtProcess = New System.Windows.Forms.TextBox()
        Me.txtNextProcess = New System.Windows.Forms.Label()
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
        Me.pnlSites = New System.Windows.Forms.Panel()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.DataGridViewSites = New System.Windows.Forms.DataGridView()
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
        Me.pnlDataStructures = New System.Windows.Forms.Panel()
        Me.DataGridViewStructures = New System.Windows.Forms.DataGridView()
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
        Me.pnlServers = New System.Windows.Forms.Panel()
        Me.pnlBaseStation = New System.Windows.Forms.Panel()
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
        Me.cmdBstAddNew = New System.Windows.Forms.Button()
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
        Me.cmdmssRefresh = New System.Windows.Forms.Button()
        Me.cmdmssReset = New System.Windows.Forms.Button()
        Me.txtmssFTPMode = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdmssPrev = New System.Windows.Forms.Button()
        Me.cmdmssfirst = New System.Windows.Forms.Button()
        Me.cmdmssLast = New System.Windows.Forms.Button()
        Me.cmdmssNext = New System.Windows.Forms.Button()
        Me.txtmssNavigator = New System.Windows.Forms.TextBox()
        Me.lblFtpTransferMode = New System.Windows.Forms.Label()
        Me.lblMsgSwitch = New System.Windows.Forms.Label()
        Me.cmdMSSDelete = New System.Windows.Forms.Button()
        Me.cmdMSSUpdate = New System.Windows.Forms.Button()
        Me.cmdMSSAddNew = New System.Windows.Forms.Button()
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
        Me.lblServerSettings = New System.Windows.Forms.Label()
        Me.cmdMSS = New System.Windows.Forms.Button()
        Me.cmdBaseStation = New System.Windows.Forms.Button()
        Me.pnlMsgEncoding = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgrdCodeFlag = New System.Windows.Forms.DataGridView()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.grpSensors = New System.Windows.Forms.GroupBox()
        Me.txtWind = New System.Windows.Forms.TextBox()
        Me.txtRainfall = New System.Windows.Forms.TextBox()
        Me.txtVisibility = New System.Windows.Forms.TextBox()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.lblWind = New System.Windows.Forms.Label()
        Me.lblRainfall = New System.Windows.Forms.Label()
        Me.lblVisbility = New System.Windows.Forms.Label()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.txtPressure = New System.Windows.Forms.TextBox()
        Me.lblPressure = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.chkOptionalSection = New System.Windows.Forms.CheckBox()
        Me.LocaltableVersion = New System.Windows.Forms.TextBox()
        Me.MastertableVersion = New System.Windows.Forms.TextBox()
        Me.LocalSubcategory = New System.Windows.Forms.TextBox()
        Me.InternationalSubcategory = New System.Windows.Forms.TextBox()
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
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtTemplate = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.txtMsgHeader = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblMaster = New System.Windows.Forms.GroupBox()
        Me.chkOption = New System.Windows.Forms.CheckBox()
        Me.txtLocalTabVerNo = New System.Windows.Forms.TextBox()
        Me.txtMasterTabVerNo = New System.Windows.Forms.TextBox()
        Me.txtLocalDatSubCat = New System.Windows.Forms.TextBox()
        Me.txtIntDatSubCat = New System.Windows.Forms.TextBox()
        Me.txtDatCat = New System.Windows.Forms.TextBox()
        Me.txtUpdateSeqNo = New System.Windows.Forms.TextBox()
        Me.txtGenSubCentr = New System.Windows.Forms.TextBox()
        Me.txtGenCentr = New System.Windows.Forms.TextBox()
        Me.txtBufrNo = New System.Windows.Forms.TextBox()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblLocalCat = New System.Windows.Forms.Label()
        Me.lblSubcat = New System.Windows.Forms.Label()
        Me.lblCat = New System.Windows.Forms.Label()
        Me.lblSeq = New System.Windows.Forms.Label()
        Me.lblSubcentr = New System.Windows.Forms.Label()
        Me.lbCentr = New System.Windows.Forms.Label()
        Me.lblEd = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.lblMsgHeader = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlControl.SuspendLayout()
        Me.pnlProcessing.SuspendLayout()
        Me.pnlProcessSettings.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlSites.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.DataGridViewSites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDataStructures.SuspendLayout()
        CType(Me.DataGridViewStructures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStructures1.SuspendLayout()
        Me.grpStructures.SuspendLayout()
        Me.pnlServers.SuspendLayout()
        Me.pnlBaseStation.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.pnlMSS.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlMsgEncoding.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgrdCodeFlag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.grpSensors.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.lblMaster.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.pnlControl.Size = New System.Drawing.Size(191, 551)
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
        Me.cmdMessages.Text = "Message Encoding"
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
        Me.pnlProcessing.Controls.Add(Me.Ltime)
        Me.pnlProcessing.Controls.Add(Me.pnlProcessSettings)
        Me.pnlProcessing.Controls.Add(Me.Panel4)
        Me.pnlProcessing.Controls.Add(Me.lblErrors)
        Me.pnlProcessing.Controls.Add(Me.Panel1)
        Me.pnlProcessing.Controls.Add(Me.grpElements)
        Me.pnlProcessing.Location = New System.Drawing.Point(196, 0)
        Me.pnlProcessing.Name = "pnlProcessing"
        Me.pnlProcessing.Size = New System.Drawing.Size(734, 109)
        Me.pnlProcessing.TabIndex = 1
        Me.pnlProcessing.Visible = False
        '
        'list_errors
        '
        Me.list_errors.FormattingEnabled = True
        Me.list_errors.Location = New System.Drawing.Point(11, 450)
        Me.list_errors.Name = "list_errors"
        Me.list_errors.Size = New System.Drawing.Size(688, 95)
        Me.list_errors.TabIndex = 8
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
        '
        'pnlProcessSettings
        '
        Me.pnlProcessSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcessSettings.Controls.Add(Me.txtGMTDiff)
        Me.pnlProcessSettings.Controls.Add(Me.lblGMT)
        Me.pnlProcessSettings.Controls.Add(Me.Label9)
        Me.pnlProcessSettings.Controls.Add(Me.cmdSave)
        Me.pnlProcessSettings.Controls.Add(Me.chkDeleteFile)
        Me.pnlProcessSettings.Controls.Add(Me.txtTimeout)
        Me.pnlProcessSettings.Controls.Add(Me.Label10)
        Me.pnlProcessSettings.Controls.Add(Me.Label11)
        Me.pnlProcessSettings.Controls.Add(Me.txtPeriod)
        Me.pnlProcessSettings.Controls.Add(Me.Label12)
        Me.pnlProcessSettings.Controls.Add(Me.txtOffset)
        Me.pnlProcessSettings.Controls.Add(Me.Label13)
        Me.pnlProcessSettings.Controls.Add(Me.txtInterval)
        Me.pnlProcessSettings.Controls.Add(Me.Label14)
        Me.pnlProcessSettings.Controls.Add(Me.optStop)
        Me.pnlProcessSettings.Controls.Add(Me.optStart)
        Me.pnlProcessSettings.Location = New System.Drawing.Point(13, 14)
        Me.pnlProcessSettings.Name = "pnlProcessSettings"
        Me.pnlProcessSettings.Size = New System.Drawing.Size(685, 135)
        Me.pnlProcessSettings.TabIndex = 6
        '
        'txtGMTDiff
        '
        Me.txtGMTDiff.BackColor = System.Drawing.Color.White
        Me.txtGMTDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMTDiff.Location = New System.Drawing.Point(504, 92)
        Me.txtGMTDiff.Name = "txtGMTDiff"
        Me.txtGMTDiff.Size = New System.Drawing.Size(32, 20)
        Me.txtGMTDiff.TabIndex = 16
        Me.txtGMTDiff.Text = "0"
        Me.txtGMTDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblGMT
        '
        Me.lblGMT.AutoSize = True
        Me.lblGMT.Location = New System.Drawing.Point(426, 96)
        Me.lblGMT.Name = "lblGMT"
        Me.lblGMT.Size = New System.Drawing.Size(67, 13)
        Me.lblGMT.TabIndex = 15
        Me.lblGMT.Text = "GMT Diff +/-"
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
        Me.cmdSave.Location = New System.Drawing.Point(572, 90)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(86, 24)
        Me.cmdSave.TabIndex = 12
        Me.cmdSave.Text = "Save Changes"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'chkDeleteFile
        '
        Me.chkDeleteFile.AutoSize = True
        Me.chkDeleteFile.Location = New System.Drawing.Point(237, 94)
        Me.chkDeleteFile.Name = "chkDeleteFile"
        Me.chkDeleteFile.Size = New System.Drawing.Size(183, 17)
        Me.chkDeleteFile.TabIndex = 11
        Me.chkDeleteFile.Text = "Delete Input File After Processing"
        Me.chkDeleteFile.UseVisualStyleBackColor = True
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(182, 92)
        Me.txtTimeout.Name = "txtTimeout"
        Me.txtTimeout.Size = New System.Drawing.Size(33, 20)
        Me.txtTimeout.TabIndex = 10
        Me.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(48, 96)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(129, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Timeout Period (Seconds)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(507, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Hour"
        '
        'txtPeriod
        '
        Me.txtPeriod.Location = New System.Drawing.Point(473, 58)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(33, 20)
        Me.txtPeriod.TabIndex = 7
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(402, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Retrieve Last"
        '
        'txtOffset
        '
        Me.txtOffset.Location = New System.Drawing.Point(344, 58)
        Me.txtOffset.Name = "txtOffset"
        Me.txtOffset.Size = New System.Drawing.Size(33, 20)
        Me.txtOffset.TabIndex = 5
        Me.txtOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(234, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Hour Offset (Minutes)"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(182, 58)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(33, 20)
        Me.txtInterval.TabIndex = 3
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(48, 62)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(133, 13)
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
        'optStart
        '
        Me.optStart.AutoSize = True
        Me.optStart.Location = New System.Drawing.Point(47, 26)
        Me.optStart.Name = "optStart"
        Me.optStart.Size = New System.Drawing.Size(59, 17)
        Me.optStart.TabIndex = 0
        Me.optStart.Text = "Restart"
        Me.optStart.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.txtNxtProcess)
        Me.Panel4.Controls.Add(Me.txtNextProcess)
        Me.Panel4.Controls.Add(Me.txtLastProcess)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.ProgressBar1)
        Me.Panel4.Controls.Add(Me.txtStatus)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtDateTime)
        Me.Panel4.Controls.Add(Me.lblDatetime)
        Me.Panel4.Controls.Add(Me.lblSatus)
        Me.Panel4.Location = New System.Drawing.Point(419, 163)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(280, 268)
        Me.Panel4.TabIndex = 4
        '
        'txtNxtProcess
        '
        Me.txtNxtProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtNxtProcess.Enabled = False
        Me.txtNxtProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNxtProcess.Location = New System.Drawing.Point(136, 113)
        Me.txtNxtProcess.Name = "txtNxtProcess"
        Me.txtNxtProcess.Size = New System.Drawing.Size(139, 20)
        Me.txtNxtProcess.TabIndex = 19
        '
        'txtNextProcess
        '
        Me.txtNextProcess.AutoSize = True
        Me.txtNextProcess.Location = New System.Drawing.Point(158, 99)
        Me.txtNextProcess.Name = "txtNextProcess"
        Me.txtNextProcess.Size = New System.Drawing.Size(84, 13)
        Me.txtNextProcess.TabIndex = 18
        Me.txtNextProcess.Text = "Next Processing"
        '
        'txtLastProcess
        '
        Me.txtLastProcess.BackColor = System.Drawing.Color.MistyRose
        Me.txtLastProcess.Enabled = False
        Me.txtLastProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastProcess.Location = New System.Drawing.Point(6, 113)
        Me.txtLastProcess.Name = "txtLastProcess"
        Me.txtLastProcess.Size = New System.Drawing.Size(124, 20)
        Me.txtLastProcess.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Last Processed"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.SeaShell
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 215)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(272, 20)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 15
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.MistyRose
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(6, 165)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(269, 20)
        Me.txtStatus.TabIndex = 10
        Me.txtStatus.Text = "Stopped"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 153)
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
        Me.txtDateTime.Size = New System.Drawing.Size(157, 20)
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
        Me.lblSatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSatus.Location = New System.Drawing.Point(44, 10)
        Me.lblSatus.Name = "lblSatus"
        Me.lblSatus.Size = New System.Drawing.Size(109, 13)
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
        Me.Panel1.Size = New System.Drawing.Size(402, 269)
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
        Me.Panel3.Location = New System.Drawing.Point(199, 23)
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
        Me.Panel2.Location = New System.Drawing.Point(3, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(190, 243)
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
        Me.lblInputData.Location = New System.Drawing.Point(90, 6)
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
        Me.lblInformation.Size = New System.Drawing.Size(151, 15)
        Me.lblInformation.TabIndex = 0
        Me.lblInformation.Text = "Processinf Information"
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
        'pnlSites
        '
        Me.pnlSites.AllowDrop = True
        Me.pnlSites.AutoSize = True
        Me.pnlSites.BackColor = System.Drawing.Color.Linen
        Me.pnlSites.Controls.Add(Me.GroupBox11)
        Me.pnlSites.Location = New System.Drawing.Point(200, 273)
        Me.pnlSites.Name = "pnlSites"
        Me.pnlSites.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.pnlSites.Size = New System.Drawing.Size(721, 416)
        Me.pnlSites.TabIndex = 3
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.DataGridViewSites)
        Me.GroupBox11.Controls.Add(Me.txtSiteName)
        Me.GroupBox11.Controls.Add(Me.Label41)
        Me.GroupBox11.Controls.Add(Me.cmdClear)
        Me.GroupBox11.Controls.Add(Me.cmdViewUpdate)
        Me.GroupBox11.Controls.Add(Me.cmdDel)
        Me.GroupBox11.Controls.Add(Me.cmdUpdateSites)
        Me.GroupBox11.Controls.Add(Me.cmdAdd)
        Me.GroupBox11.Controls.Add(Me.btnMovePrevious)
        Me.GroupBox11.Controls.Add(Me.btnMoveFirst)
        Me.GroupBox11.Controls.Add(Me.btnMoveLast)
        Me.GroupBox11.Controls.Add(Me.txtSitesNavigator)
        Me.GroupBox11.Controls.Add(Me.btnMoveNext)
        Me.GroupBox11.Controls.Add(Me.Label4)
        Me.GroupBox11.Controls.Add(Me.txtIP)
        Me.GroupBox11.Controls.Add(Me.txtDataStructure)
        Me.GroupBox11.Controls.Add(Me.txtFlag)
        Me.GroupBox11.Controls.Add(Me.chkOperational)
        Me.GroupBox11.Controls.Add(Me.Label18)
        Me.GroupBox11.Controls.Add(Me.Label17)
        Me.GroupBox11.Controls.Add(Me.Label16)
        Me.GroupBox11.Controls.Add(Me.txtInFile)
        Me.GroupBox11.Controls.Add(Me.lblInfile)
        Me.GroupBox11.Controls.Add(Me.txtSiteID)
        Me.GroupBox11.Controls.Add(Me.Label15)
        Me.GroupBox11.Location = New System.Drawing.Point(2, 22)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(709, 391)
        Me.GroupBox11.TabIndex = 67
        Me.GroupBox11.TabStop = False
        '
        'DataGridViewSites
        '
        Me.DataGridViewSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSites.Location = New System.Drawing.Point(395, 203)
        Me.DataGridViewSites.Name = "DataGridViewSites"
        Me.DataGridViewSites.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewSites.Size = New System.Drawing.Size(241, 51)
        Me.DataGridViewSites.TabIndex = 68
        Me.DataGridViewSites.Visible = False
        '
        'txtSiteName
        '
        Me.txtSiteName.FormattingEnabled = True
        Me.txtSiteName.Location = New System.Drawing.Point(182, 74)
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteName.Size = New System.Drawing.Size(280, 21)
        Me.txtSiteName.TabIndex = 95
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(85, 78)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 13)
        Me.Label41.TabIndex = 94
        Me.Label41.Text = "Site Name"
        '
        'cmdClear
        '
        Me.cmdClear.Location = New System.Drawing.Point(332, 310)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(68, 29)
        Me.cmdClear.TabIndex = 88
        Me.cmdClear.Text = "Reset"
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
        Me.cmdDel.Location = New System.Drawing.Point(420, 310)
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.Size = New System.Drawing.Size(68, 29)
        Me.cmdDel.TabIndex = 86
        Me.cmdDel.Text = "Delete"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpdateSites
        '
        Me.cmdUpdateSites.Location = New System.Drawing.Point(244, 310)
        Me.cmdUpdateSites.Name = "cmdUpdateSites"
        Me.cmdUpdateSites.Size = New System.Drawing.Size(68, 29)
        Me.cmdUpdateSites.TabIndex = 85
        Me.cmdUpdateSites.Text = "Update"
        Me.cmdUpdateSites.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(156, 310)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(68, 29)
        Me.cmdAdd.TabIndex = 84
        Me.cmdAdd.Text = "AddNew"
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
        Me.Label4.Location = New System.Drawing.Point(84, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Operational"
        '
        'txtIP
        '
        Me.txtIP.FormattingEnabled = True
        Me.txtIP.Location = New System.Drawing.Point(180, 205)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIP.Size = New System.Drawing.Size(135, 21)
        Me.txtIP.TabIndex = 77
        '
        'txtDataStructure
        '
        Me.txtDataStructure.FormattingEnabled = True
        Me.txtDataStructure.Location = New System.Drawing.Point(181, 140)
        Me.txtDataStructure.Name = "txtDataStructure"
        Me.txtDataStructure.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataStructure.Size = New System.Drawing.Size(135, 21)
        Me.txtDataStructure.TabIndex = 76
        '
        'txtFlag
        '
        Me.txtFlag.Location = New System.Drawing.Point(181, 173)
        Me.txtFlag.Name = "txtFlag"
        Me.txtFlag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFlag.Size = New System.Drawing.Size(135, 20)
        Me.txtFlag.TabIndex = 75
        '
        'chkOperational
        '
        Me.chkOperational.AutoSize = True
        Me.chkOperational.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOperational.Location = New System.Drawing.Point(180, 245)
        Me.chkOperational.Name = "chkOperational"
        Me.chkOperational.Size = New System.Drawing.Size(15, 14)
        Me.chkOperational.TabIndex = 74
        Me.chkOperational.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkOperational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(84, 209)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(79, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "AWS Server IP"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(84, 177)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(91, 13)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Missing Data Flag"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(84, 144)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 13)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Data Strucure"
        '
        'txtInFile
        '
        Me.txtInFile.Location = New System.Drawing.Point(180, 108)
        Me.txtInFile.Name = "txtInFile"
        Me.txtInFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInFile.Size = New System.Drawing.Size(281, 20)
        Me.txtInFile.TabIndex = 70
        '
        'lblInfile
        '
        Me.lblInfile.AutoSize = True
        Me.lblInfile.Location = New System.Drawing.Point(84, 112)
        Me.lblInfile.Name = "lblInfile"
        Me.lblInfile.Size = New System.Drawing.Size(73, 13)
        Me.lblInfile.TabIndex = 69
        Me.lblInfile.Text = "Input Data file"
        '
        'txtSiteID
        '
        Me.txtSiteID.FormattingEnabled = True
        Me.txtSiteID.Location = New System.Drawing.Point(181, 37)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSiteID.Size = New System.Drawing.Size(137, 21)
        Me.txtSiteID.TabIndex = 68
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(84, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 67
        Me.Label15.Text = "Site ID"
        '
        'pnlDataStructures
        '
        Me.pnlDataStructures.BackColor = System.Drawing.Color.BurlyWood
        Me.pnlDataStructures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDataStructures.Controls.Add(Me.DataGridViewStructures)
        Me.pnlDataStructures.Controls.Add(Me.grpStructures1)
        Me.pnlDataStructures.Location = New System.Drawing.Point(196, 115)
        Me.pnlDataStructures.Name = "pnlDataStructures"
        Me.pnlDataStructures.Size = New System.Drawing.Size(734, 31)
        Me.pnlDataStructures.TabIndex = 5
        Me.pnlDataStructures.Visible = False
        '
        'DataGridViewStructures
        '
        Me.DataGridViewStructures.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridViewStructures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewStructures.Location = New System.Drawing.Point(3, 242)
        Me.DataGridViewStructures.Name = "DataGridViewStructures"
        Me.DataGridViewStructures.Size = New System.Drawing.Size(726, 118)
        Me.DataGridViewStructures.TabIndex = 2
        Me.DataGridViewStructures.Visible = False
        '
        'grpStructures1
        '
        Me.grpStructures1.Controls.Add(Me.lblStructure)
        Me.grpStructures1.Controls.Add(Me.grpStructures)
        Me.grpStructures1.Controls.Add(Me.cmbExistingStructures)
        Me.grpStructures1.Location = New System.Drawing.Point(192, 13)
        Me.grpStructures1.Name = "grpStructures1"
        Me.grpStructures1.Size = New System.Drawing.Size(327, 219)
        Me.grpStructures1.TabIndex = 1
        Me.grpStructures1.TabStop = False
        Me.grpStructures1.Text = "Data Structures"
        '
        'lblStructure
        '
        Me.lblStructure.AutoSize = True
        Me.lblStructure.Location = New System.Drawing.Point(22, 29)
        Me.lblStructure.Name = "lblStructure"
        Me.lblStructure.Size = New System.Drawing.Size(107, 13)
        Me.lblStructure.TabIndex = 8
        Me.lblStructure.Text = "Select Data structure"
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
        Me.grpStructures.Location = New System.Drawing.Point(13, 62)
        Me.grpStructures.Name = "grpStructures"
        Me.grpStructures.Size = New System.Drawing.Size(296, 149)
        Me.grpStructures.TabIndex = 7
        Me.grpStructures.TabStop = False
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
        Me.txtDelimiter.Location = New System.Drawing.Point(119, 31)
        Me.txtDelimiter.Name = "txtDelimiter"
        Me.txtDelimiter.Size = New System.Drawing.Size(135, 21)
        Me.txtDelimiter.TabIndex = 18
        '
        'txtQualifier
        '
        Me.txtQualifier.Location = New System.Drawing.Point(119, 72)
        Me.txtQualifier.Name = "txtQualifier"
        Me.txtQualifier.Size = New System.Drawing.Size(135, 20)
        Me.txtQualifier.TabIndex = 17
        '
        'txtHeaders
        '
        Me.txtHeaders.Location = New System.Drawing.Point(119, 52)
        Me.txtHeaders.Name = "txtHeaders"
        Me.txtHeaders.Size = New System.Drawing.Size(135, 20)
        Me.txtHeaders.TabIndex = 16
        '
        'txtStrName
        '
        Me.txtStrName.Location = New System.Drawing.Point(119, 11)
        Me.txtStrName.Name = "txtStrName"
        Me.txtStrName.Size = New System.Drawing.Size(135, 20)
        Me.txtStrName.TabIndex = 14
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(200, 118)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(62, 23)
        Me.cmdDelete.TabIndex = 13
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(117, 118)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(62, 23)
        Me.cmdUpdate.TabIndex = 12
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(34, 118)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(62, 23)
        Me.cmdCreate.TabIndex = 11
        Me.cmdCreate.Text = "Create"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(7, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(112, 13)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Text Qulifier Character"
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
        Me.cmbExistingStructures.Location = New System.Drawing.Point(132, 25)
        Me.cmbExistingStructures.Name = "cmbExistingStructures"
        Me.cmbExistingStructures.Size = New System.Drawing.Size(130, 21)
        Me.cmbExistingStructures.TabIndex = 1
        '
        'pnlServers
        '
        Me.pnlServers.BackColor = System.Drawing.Color.PeachPuff
        Me.pnlServers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlServers.Controls.Add(Me.pnlBaseStation)
        Me.pnlServers.Controls.Add(Me.pnlMSS)
        Me.pnlServers.Controls.Add(Me.lblServerSettings)
        Me.pnlServers.Controls.Add(Me.cmdMSS)
        Me.pnlServers.Controls.Add(Me.cmdBaseStation)
        Me.pnlServers.Location = New System.Drawing.Point(196, 149)
        Me.pnlServers.Name = "pnlServers"
        Me.pnlServers.Size = New System.Drawing.Size(734, 36)
        Me.pnlServers.TabIndex = 2
        '
        'pnlBaseStation
        '
        Me.pnlBaseStation.BackColor = System.Drawing.Color.PapayaWhip
        Me.pnlBaseStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBaseStation.Controls.Add(Me.cmdRefresh)
        Me.pnlBaseStation.Controls.Add(Me.cmdReset)
        Me.pnlBaseStation.Controls.Add(Me.txtBasestationFTPMode)
        Me.pnlBaseStation.Controls.Add(Me.GroupBox10)
        Me.pnlBaseStation.Controls.Add(Me.Label40)
        Me.pnlBaseStation.Controls.Add(Me.lblbaseStation)
        Me.pnlBaseStation.Controls.Add(Me.cmdBstDelete)
        Me.pnlBaseStation.Controls.Add(Me.cmdBsstUpdate)
        Me.pnlBaseStation.Controls.Add(Me.cmdBstAddNew)
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
        Me.pnlBaseStation.Location = New System.Drawing.Point(114, 96)
        Me.pnlBaseStation.Name = "pnlBaseStation"
        Me.pnlBaseStation.Size = New System.Drawing.Size(471, 285)
        Me.pnlBaseStation.TabIndex = 4
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(275, 233)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(62, 21)
        Me.cmdRefresh.TabIndex = 74
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(195, 232)
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
        Me.txtBasestationFTPMode.Location = New System.Drawing.Point(206, 102)
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
        Me.GroupBox10.Location = New System.Drawing.Point(0, 252)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(469, 31)
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
        Me.cmdBstDelete.Location = New System.Drawing.Point(349, 232)
        Me.cmdBstDelete.Name = "cmdBstDelete"
        Me.cmdBstDelete.Size = New System.Drawing.Size(62, 21)
        Me.cmdBstDelete.TabIndex = 14
        Me.cmdBstDelete.Text = "Delete"
        Me.cmdBstDelete.UseVisualStyleBackColor = True
        '
        'cmdBsstUpdate
        '
        Me.cmdBsstUpdate.Location = New System.Drawing.Point(111, 232)
        Me.cmdBsstUpdate.Name = "cmdBsstUpdate"
        Me.cmdBsstUpdate.Size = New System.Drawing.Size(62, 21)
        Me.cmdBsstUpdate.TabIndex = 12
        Me.cmdBsstUpdate.Text = "Update"
        Me.cmdBsstUpdate.UseVisualStyleBackColor = True
        '
        'cmdBstAddNew
        '
        Me.cmdBstAddNew.Location = New System.Drawing.Point(27, 232)
        Me.cmdBstAddNew.Name = "cmdBstAddNew"
        Me.cmdBstAddNew.Size = New System.Drawing.Size(62, 21)
        Me.cmdBstAddNew.TabIndex = 11
        Me.cmdBstAddNew.Text = "AddNew"
        Me.cmdBstAddNew.UseVisualStyleBackColor = True
        '
        'txtbaseStationPWConfirm
        '
        Me.txtbaseStationPWConfirm.Location = New System.Drawing.Point(205, 195)
        Me.txtbaseStationPWConfirm.Name = "txtbaseStationPWConfirm"
        Me.txtbaseStationPWConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPWConfirm.Size = New System.Drawing.Size(87, 20)
        Me.txtbaseStationPWConfirm.TabIndex = 10
        '
        'txtbaseStationPW
        '
        Me.txtbaseStationPW.Location = New System.Drawing.Point(205, 164)
        Me.txtbaseStationPW.Name = "txtbaseStationPW"
        Me.txtbaseStationPW.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPW.Size = New System.Drawing.Size(87, 20)
        Me.txtbaseStationPW.TabIndex = 9
        '
        'txtBaseStationUser
        '
        Me.txtBaseStationUser.Location = New System.Drawing.Point(205, 133)
        Me.txtBaseStationUser.Name = "txtBaseStationUser"
        Me.txtBaseStationUser.Size = New System.Drawing.Size(87, 20)
        Me.txtBaseStationUser.TabIndex = 8
        '
        'txtBaseStationFolder
        '
        Me.txtBaseStationFolder.Location = New System.Drawing.Point(205, 71)
        Me.txtBaseStationFolder.Name = "txtBaseStationFolder"
        Me.txtBaseStationFolder.Size = New System.Drawing.Size(117, 20)
        Me.txtBaseStationFolder.TabIndex = 6
        '
        'txtBaseStationAddress
        '
        Me.txtBaseStationAddress.Location = New System.Drawing.Point(205, 40)
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
        'pnlMSS
        '
        Me.pnlMSS.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.pnlMSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSS.Controls.Add(Me.cmdmssRefresh)
        Me.pnlMSS.Controls.Add(Me.cmdmssReset)
        Me.pnlMSS.Controls.Add(Me.txtmssFTPMode)
        Me.pnlMSS.Controls.Add(Me.GroupBox1)
        Me.pnlMSS.Controls.Add(Me.lblFtpTransferMode)
        Me.pnlMSS.Controls.Add(Me.lblMsgSwitch)
        Me.pnlMSS.Controls.Add(Me.cmdMSSDelete)
        Me.pnlMSS.Controls.Add(Me.cmdMSSUpdate)
        Me.pnlMSS.Controls.Add(Me.cmdMSSAddNew)
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
        Me.pnlMSS.Location = New System.Drawing.Point(113, 98)
        Me.pnlMSS.Name = "pnlMSS"
        Me.pnlMSS.Size = New System.Drawing.Size(474, 283)
        Me.pnlMSS.TabIndex = 3
        '
        'cmdmssRefresh
        '
        Me.cmdmssRefresh.Location = New System.Drawing.Point(293, 224)
        Me.cmdmssRefresh.Name = "cmdmssRefresh"
        Me.cmdmssRefresh.Size = New System.Drawing.Size(62, 21)
        Me.cmdmssRefresh.TabIndex = 76
        Me.cmdmssRefresh.Text = "Refresh"
        Me.cmdmssRefresh.UseVisualStyleBackColor = True
        '
        'cmdmssReset
        '
        Me.cmdmssReset.Location = New System.Drawing.Point(214, 224)
        Me.cmdmssReset.Name = "cmdmssReset"
        Me.cmdmssReset.Size = New System.Drawing.Size(62, 21)
        Me.cmdmssReset.TabIndex = 75
        Me.cmdmssReset.Text = "Reset"
        Me.cmdmssReset.UseVisualStyleBackColor = True
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
        Me.GroupBox1.Location = New System.Drawing.Point(0, 245)
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
        'cmdMSSDelete
        '
        Me.cmdMSSDelete.Location = New System.Drawing.Point(372, 224)
        Me.cmdMSSDelete.Name = "cmdMSSDelete"
        Me.cmdMSSDelete.Size = New System.Drawing.Size(62, 21)
        Me.cmdMSSDelete.TabIndex = 12
        Me.cmdMSSDelete.Text = "Delete"
        Me.cmdMSSDelete.UseVisualStyleBackColor = True
        '
        'cmdMSSUpdate
        '
        Me.cmdMSSUpdate.Location = New System.Drawing.Point(135, 224)
        Me.cmdMSSUpdate.Name = "cmdMSSUpdate"
        Me.cmdMSSUpdate.Size = New System.Drawing.Size(62, 21)
        Me.cmdMSSUpdate.TabIndex = 11
        Me.cmdMSSUpdate.Text = "Update"
        Me.cmdMSSUpdate.UseVisualStyleBackColor = True
        '
        'cmdMSSAddNew
        '
        Me.cmdMSSAddNew.Location = New System.Drawing.Point(56, 224)
        Me.cmdMSSAddNew.Name = "cmdMSSAddNew"
        Me.cmdMSSAddNew.Size = New System.Drawing.Size(62, 21)
        Me.cmdMSSAddNew.TabIndex = 10
        Me.cmdMSSAddNew.Text = "AddNew"
        Me.cmdMSSAddNew.UseVisualStyleBackColor = True
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
        'lblServerSettings
        '
        Me.lblServerSettings.AutoSize = True
        Me.lblServerSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServerSettings.Location = New System.Drawing.Point(243, 95)
        Me.lblServerSettings.Name = "lblServerSettings"
        Me.lblServerSettings.Size = New System.Drawing.Size(114, 16)
        Me.lblServerSettings.TabIndex = 3
        Me.lblServerSettings.Text = "Server Settings"
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
        'pnlMsgEncoding
        '
        Me.pnlMsgEncoding.BackColor = System.Drawing.Color.Linen
        Me.pnlMsgEncoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox6)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox9)
        Me.pnlMsgEncoding.Controls.Add(Me.grpSensors)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox7)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox5)
        Me.pnlMsgEncoding.Controls.Add(Me.lblMaster)
        Me.pnlMsgEncoding.Controls.Add(Me.GroupBox4)
        Me.pnlMsgEncoding.Location = New System.Drawing.Point(196, 194)
        Me.pnlMsgEncoding.Name = "pnlMsgEncoding"
        Me.pnlMsgEncoding.Size = New System.Drawing.Size(734, 48)
        Me.pnlMsgEncoding.TabIndex = 4
        Me.pnlMsgEncoding.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgrdCodeFlag)
        Me.GroupBox6.Location = New System.Drawing.Point(312, 31)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(407, 429)
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
        Me.dgrdCodeFlag.Size = New System.Drawing.Size(401, 410)
        Me.dgrdCodeFlag.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TextBox22)
        Me.GroupBox9.Controls.Add(Me.TextBox23)
        Me.GroupBox9.Controls.Add(Me.TextBox24)
        Me.GroupBox9.Controls.Add(Me.TextBox25)
        Me.GroupBox9.Controls.Add(Me.Label35)
        Me.GroupBox9.Controls.Add(Me.Label36)
        Me.GroupBox9.Controls.Add(Me.Label37)
        Me.GroupBox9.Controls.Add(Me.Label38)
        Me.GroupBox9.Controls.Add(Me.TextBox26)
        Me.GroupBox9.Controls.Add(Me.Label39)
        Me.GroupBox9.Location = New System.Drawing.Point(11, 118)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(295, 105)
        Me.GroupBox9.TabIndex = 3
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Tag = ""
        Me.GroupBox9.Text = "Sensors Height From Ground (m)"
        '
        'TextBox22
        '
        Me.TextBox22.Location = New System.Drawing.Point(212, 52)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(55, 20)
        Me.TextBox22.TabIndex = 10
        Me.TextBox22.Text = "10"
        '
        'TextBox23
        '
        Me.TextBox23.Location = New System.Drawing.Point(212, 17)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(55, 20)
        Me.TextBox23.TabIndex = 9
        Me.TextBox23.Text = "0.25"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New System.Drawing.Point(86, 64)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(55, 20)
        Me.TextBox24.TabIndex = 8
        Me.TextBox24.Text = "1.5"
        '
        'TextBox25
        '
        Me.TextBox25.Location = New System.Drawing.Point(86, 41)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(55, 20)
        Me.TextBox25.TabIndex = 7
        Me.TextBox25.Text = "1.25"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(162, 49)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(32, 13)
        Me.Label35.TabIndex = 6
        Me.Label35.Text = "Wind"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(159, 21)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(42, 13)
        Me.Label36.TabIndex = 5
        Me.Label36.Text = "Rainfall"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(19, 68)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(43, 13)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Visibility"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(18, 45)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(67, 13)
        Me.Label38.TabIndex = 2
        Me.Label38.Text = "Temperature"
        '
        'TextBox26
        '
        Me.TextBox26.Location = New System.Drawing.Point(86, 18)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(55, 20)
        Me.TextBox26.TabIndex = 1
        Me.TextBox26.Text = "1.25"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(19, 22)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(48, 13)
        Me.Label39.TabIndex = 0
        Me.Label39.Text = "Pressure"
        '
        'grpSensors
        '
        Me.grpSensors.Controls.Add(Me.txtWind)
        Me.grpSensors.Controls.Add(Me.txtRainfall)
        Me.grpSensors.Controls.Add(Me.txtVisibility)
        Me.grpSensors.Controls.Add(Me.txtTemperature)
        Me.grpSensors.Controls.Add(Me.lblWind)
        Me.grpSensors.Controls.Add(Me.lblRainfall)
        Me.grpSensors.Controls.Add(Me.lblVisbility)
        Me.grpSensors.Controls.Add(Me.lblTemp)
        Me.grpSensors.Controls.Add(Me.txtPressure)
        Me.grpSensors.Controls.Add(Me.lblPressure)
        Me.grpSensors.Location = New System.Drawing.Point(11, 118)
        Me.grpSensors.Name = "grpSensors"
        Me.grpSensors.Size = New System.Drawing.Size(295, 105)
        Me.grpSensors.TabIndex = 3
        Me.grpSensors.TabStop = False
        Me.grpSensors.Tag = ""
        Me.grpSensors.Text = "Sensors Height From Ground (m)"
        '
        'txtWind
        '
        Me.txtWind.Location = New System.Drawing.Point(212, 52)
        Me.txtWind.Name = "txtWind"
        Me.txtWind.Size = New System.Drawing.Size(55, 20)
        Me.txtWind.TabIndex = 10
        '
        'txtRainfall
        '
        Me.txtRainfall.Location = New System.Drawing.Point(212, 17)
        Me.txtRainfall.Name = "txtRainfall"
        Me.txtRainfall.Size = New System.Drawing.Size(55, 20)
        Me.txtRainfall.TabIndex = 9
        '
        'txtVisibility
        '
        Me.txtVisibility.Location = New System.Drawing.Point(86, 64)
        Me.txtVisibility.Name = "txtVisibility"
        Me.txtVisibility.Size = New System.Drawing.Size(55, 20)
        Me.txtVisibility.TabIndex = 8
        '
        'txtTemperature
        '
        Me.txtTemperature.Location = New System.Drawing.Point(86, 41)
        Me.txtTemperature.Name = "txtTemperature"
        Me.txtTemperature.Size = New System.Drawing.Size(55, 20)
        Me.txtTemperature.TabIndex = 7
        '
        'lblWind
        '
        Me.lblWind.AutoSize = True
        Me.lblWind.Location = New System.Drawing.Point(162, 49)
        Me.lblWind.Name = "lblWind"
        Me.lblWind.Size = New System.Drawing.Size(32, 13)
        Me.lblWind.TabIndex = 6
        Me.lblWind.Text = "Wind"
        Me.lblWind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRainfall
        '
        Me.lblRainfall.AutoSize = True
        Me.lblRainfall.Location = New System.Drawing.Point(159, 21)
        Me.lblRainfall.Name = "lblRainfall"
        Me.lblRainfall.Size = New System.Drawing.Size(42, 13)
        Me.lblRainfall.TabIndex = 5
        Me.lblRainfall.Text = "Rainfall"
        '
        'lblVisbility
        '
        Me.lblVisbility.AutoSize = True
        Me.lblVisbility.Location = New System.Drawing.Point(19, 68)
        Me.lblVisbility.Name = "lblVisbility"
        Me.lblVisbility.Size = New System.Drawing.Size(43, 13)
        Me.lblVisbility.TabIndex = 4
        Me.lblVisbility.Text = "Visibility"
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Location = New System.Drawing.Point(18, 45)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(67, 13)
        Me.lblTemp.TabIndex = 2
        Me.lblTemp.Text = "Temperature"
        '
        'txtPressure
        '
        Me.txtPressure.Location = New System.Drawing.Point(86, 18)
        Me.txtPressure.Name = "txtPressure"
        Me.txtPressure.Size = New System.Drawing.Size(55, 20)
        Me.txtPressure.TabIndex = 1
        '
        'lblPressure
        '
        Me.lblPressure.AutoSize = True
        Me.lblPressure.Location = New System.Drawing.Point(19, 22)
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Size = New System.Drawing.Size(48, 13)
        Me.lblPressure.TabIndex = 0
        Me.lblPressure.Text = "Pressure"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.chkOptionalSection)
        Me.GroupBox7.Controls.Add(Me.LocaltableVersion)
        Me.GroupBox7.Controls.Add(Me.MastertableVersion)
        Me.GroupBox7.Controls.Add(Me.LocalSubcategory)
        Me.GroupBox7.Controls.Add(Me.InternationalSubcategory)
        Me.GroupBox7.Controls.Add(Me.txtDataCategory)
        Me.GroupBox7.Controls.Add(Me.txtUpdateSequence)
        Me.GroupBox7.Controls.Add(Me.txtOriginatingSubcentre)
        Me.GroupBox7.Controls.Add(Me.txtOriginatingCentre)
        Me.GroupBox7.Controls.Add(Me.txtBufrEdition)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Controls.Add(Me.Label28)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.Label34)
        Me.GroupBox7.Location = New System.Drawing.Point(9, 229)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(296, 235)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "BUFR Section 2"
        '
        'chkOptionalSection
        '
        Me.chkOptionalSection.AutoSize = True
        Me.chkOptionalSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOptionalSection.Location = New System.Drawing.Point(10, 106)
        Me.chkOptionalSection.Name = "chkOptionalSection"
        Me.chkOptionalSection.Size = New System.Drawing.Size(201, 17)
        Me.chkOptionalSection.TabIndex = 20
        Me.chkOptionalSection.Tag = "  "
        Me.chkOptionalSection.Text = "Option Section Inclusion                    "
        Me.chkOptionalSection.UseVisualStyleBackColor = True
        '
        'LocaltableVersion
        '
        Me.LocaltableVersion.Location = New System.Drawing.Point(197, 208)
        Me.LocaltableVersion.Name = "LocaltableVersion"
        Me.LocaltableVersion.Size = New System.Drawing.Size(60, 20)
        Me.LocaltableVersion.TabIndex = 19
        Me.LocaltableVersion.Text = "0"
        '
        'MastertableVersion
        '
        Me.MastertableVersion.Location = New System.Drawing.Point(197, 187)
        Me.MastertableVersion.Name = "MastertableVersion"
        Me.MastertableVersion.Size = New System.Drawing.Size(60, 20)
        Me.MastertableVersion.TabIndex = 18
        Me.MastertableVersion.Text = "13"
        '
        'LocalSubcategory
        '
        Me.LocalSubcategory.Location = New System.Drawing.Point(197, 166)
        Me.LocalSubcategory.Name = "LocalSubcategory"
        Me.LocalSubcategory.Size = New System.Drawing.Size(60, 20)
        Me.LocalSubcategory.TabIndex = 17
        Me.LocalSubcategory.Text = "0"
        '
        'InternationalSubcategory
        '
        Me.InternationalSubcategory.Location = New System.Drawing.Point(197, 145)
        Me.InternationalSubcategory.Name = "InternationalSubcategory"
        Me.InternationalSubcategory.Size = New System.Drawing.Size(60, 20)
        Me.InternationalSubcategory.TabIndex = 16
        Me.InternationalSubcategory.Text = "0"
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(197, 124)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(60, 20)
        Me.txtDataCategory.TabIndex = 15
        Me.txtDataCategory.Text = "0"
        '
        'txtUpdateSequence
        '
        Me.txtUpdateSequence.Location = New System.Drawing.Point(197, 82)
        Me.txtUpdateSequence.Name = "txtUpdateSequence"
        Me.txtUpdateSequence.Size = New System.Drawing.Size(60, 20)
        Me.txtUpdateSequence.TabIndex = 13
        Me.txtUpdateSequence.Text = "0"
        '
        'txtOriginatingSubcentre
        '
        Me.txtOriginatingSubcentre.Location = New System.Drawing.Point(197, 61)
        Me.txtOriginatingSubcentre.Name = "txtOriginatingSubcentre"
        Me.txtOriginatingSubcentre.Size = New System.Drawing.Size(60, 20)
        Me.txtOriginatingSubcentre.TabIndex = 12
        Me.txtOriginatingSubcentre.Text = "0"
        '
        'txtOriginatingCentre
        '
        Me.txtOriginatingCentre.Location = New System.Drawing.Point(197, 40)
        Me.txtOriginatingCentre.Name = "txtOriginatingCentre"
        Me.txtOriginatingCentre.Size = New System.Drawing.Size(60, 20)
        Me.txtOriginatingCentre.TabIndex = 11
        Me.txtOriginatingCentre.Text = "108"
        '
        'txtBufrEdition
        '
        Me.txtBufrEdition.Location = New System.Drawing.Point(197, 19)
        Me.txtBufrEdition.Name = "txtBufrEdition"
        Me.txtBufrEdition.Size = New System.Drawing.Size(60, 20)
        Me.txtBufrEdition.TabIndex = 10
        Me.txtBufrEdition.Text = "4"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(7, 212)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(121, 13)
        Me.Label25.TabIndex = 9
        Me.Label25.Text = "Local Table Version No."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 191)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(127, 13)
        Me.Label26.TabIndex = 8
        Me.Label26.Text = "Master Table Version No."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(8, 170)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(126, 13)
        Me.Label27.TabIndex = 7
        Me.Label27.Text = "Local Data Sub-Category"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(8, 149)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(158, 13)
        Me.Label28.TabIndex = 6
        Me.Label28.Text = "International Data Sub-Category"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 128)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(75, 13)
        Me.Label29.TabIndex = 5
        Me.Label29.Text = "Data Category"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(8, 86)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(114, 13)
        Me.Label30.TabIndex = 3
        Me.Label30.Text = "Update Sequence No."
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 65)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(170, 13)
        Me.Label32.TabIndex = 2
        Me.Label32.Text = "Originating/Generating Sub-Centre"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(8, 44)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(148, 13)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "Originating/Generating Centre"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(7, 23)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(91, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "BUFR Edition No."
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTemplate)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.GroupBox8)
        Me.GroupBox5.Controls.Add(Me.txtMsgHeader)
        Me.GroupBox5.Controls.Add(Me.Label24)
        Me.GroupBox5.Location = New System.Drawing.Point(9, 31)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(296, 80)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        Me.GroupBox5.Text = "Header and Templates"
        '
        'txtTemplate
        '
        Me.txtTemplate.FormattingEnabled = True
        Me.txtTemplate.Items.AddRange(New Object() {"tm_307091"})
        Me.txtTemplate.Location = New System.Drawing.Point(102, 47)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Size = New System.Drawing.Size(184, 21)
        Me.txtTemplate.TabIndex = 3
        Me.txtTemplate.Text = "tm_307091"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(12, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(99, 13)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "Encoding Template"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.DataGridView2)
        Me.GroupBox8.Location = New System.Drawing.Point(286, 74)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(404, 429)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Code and Flags"
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.Ivory
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(398, 410)
        Me.DataGridView2.TabIndex = 0
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(169, 18)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(117, 20)
        Me.txtMsgHeader.TabIndex = 1
        Me.txtMsgHeader.Text = "ISNH01 HKNC"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(160, 13)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "Message Header (TTAAii CCCC)"
        '
        'lblMaster
        '
        Me.lblMaster.Controls.Add(Me.chkOption)
        Me.lblMaster.Controls.Add(Me.txtLocalTabVerNo)
        Me.lblMaster.Controls.Add(Me.txtMasterTabVerNo)
        Me.lblMaster.Controls.Add(Me.txtLocalDatSubCat)
        Me.lblMaster.Controls.Add(Me.txtIntDatSubCat)
        Me.lblMaster.Controls.Add(Me.txtDatCat)
        Me.lblMaster.Controls.Add(Me.txtUpdateSeqNo)
        Me.lblMaster.Controls.Add(Me.txtGenSubCentr)
        Me.lblMaster.Controls.Add(Me.txtGenCentr)
        Me.lblMaster.Controls.Add(Me.txtBufrNo)
        Me.lblMaster.Controls.Add(Me.lblVer)
        Me.lblMaster.Controls.Add(Me.Label31)
        Me.lblMaster.Controls.Add(Me.lblLocalCat)
        Me.lblMaster.Controls.Add(Me.lblSubcat)
        Me.lblMaster.Controls.Add(Me.lblCat)
        Me.lblMaster.Controls.Add(Me.lblSeq)
        Me.lblMaster.Controls.Add(Me.lblSubcentr)
        Me.lblMaster.Controls.Add(Me.lbCentr)
        Me.lblMaster.Controls.Add(Me.lblEd)
        Me.lblMaster.Location = New System.Drawing.Point(9, 229)
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.Size = New System.Drawing.Size(296, 235)
        Me.lblMaster.TabIndex = 1
        Me.lblMaster.TabStop = False
        Me.lblMaster.Text = "BUFR Section 2"
        '
        'chkOption
        '
        Me.chkOption.AutoSize = True
        Me.chkOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOption.Location = New System.Drawing.Point(10, 106)
        Me.chkOption.Name = "chkOption"
        Me.chkOption.Size = New System.Drawing.Size(201, 17)
        Me.chkOption.TabIndex = 20
        Me.chkOption.Tag = "  "
        Me.chkOption.Text = "Option Section Inclusion                    "
        Me.chkOption.UseVisualStyleBackColor = True
        '
        'txtLocalTabVerNo
        '
        Me.txtLocalTabVerNo.Location = New System.Drawing.Point(197, 208)
        Me.txtLocalTabVerNo.Name = "txtLocalTabVerNo"
        Me.txtLocalTabVerNo.Size = New System.Drawing.Size(60, 20)
        Me.txtLocalTabVerNo.TabIndex = 19
        '
        'txtMasterTabVerNo
        '
        Me.txtMasterTabVerNo.Location = New System.Drawing.Point(197, 187)
        Me.txtMasterTabVerNo.Name = "txtMasterTabVerNo"
        Me.txtMasterTabVerNo.Size = New System.Drawing.Size(60, 20)
        Me.txtMasterTabVerNo.TabIndex = 18
        '
        'txtLocalDatSubCat
        '
        Me.txtLocalDatSubCat.Location = New System.Drawing.Point(197, 166)
        Me.txtLocalDatSubCat.Name = "txtLocalDatSubCat"
        Me.txtLocalDatSubCat.Size = New System.Drawing.Size(60, 20)
        Me.txtLocalDatSubCat.TabIndex = 17
        '
        'txtIntDatSubCat
        '
        Me.txtIntDatSubCat.Location = New System.Drawing.Point(197, 145)
        Me.txtIntDatSubCat.Name = "txtIntDatSubCat"
        Me.txtIntDatSubCat.Size = New System.Drawing.Size(60, 20)
        Me.txtIntDatSubCat.TabIndex = 16
        '
        'txtDatCat
        '
        Me.txtDatCat.Location = New System.Drawing.Point(197, 124)
        Me.txtDatCat.Name = "txtDatCat"
        Me.txtDatCat.Size = New System.Drawing.Size(60, 20)
        Me.txtDatCat.TabIndex = 15
        '
        'txtUpdateSeqNo
        '
        Me.txtUpdateSeqNo.Location = New System.Drawing.Point(197, 82)
        Me.txtUpdateSeqNo.Name = "txtUpdateSeqNo"
        Me.txtUpdateSeqNo.Size = New System.Drawing.Size(60, 20)
        Me.txtUpdateSeqNo.TabIndex = 13
        '
        'txtGenSubCentr
        '
        Me.txtGenSubCentr.Location = New System.Drawing.Point(197, 61)
        Me.txtGenSubCentr.Name = "txtGenSubCentr"
        Me.txtGenSubCentr.Size = New System.Drawing.Size(60, 20)
        Me.txtGenSubCentr.TabIndex = 12
        '
        'txtGenCentr
        '
        Me.txtGenCentr.Location = New System.Drawing.Point(197, 40)
        Me.txtGenCentr.Name = "txtGenCentr"
        Me.txtGenCentr.Size = New System.Drawing.Size(60, 20)
        Me.txtGenCentr.TabIndex = 11
        '
        'txtBufrNo
        '
        Me.txtBufrNo.Location = New System.Drawing.Point(197, 19)
        Me.txtBufrNo.Name = "txtBufrNo"
        Me.txtBufrNo.Size = New System.Drawing.Size(60, 20)
        Me.txtBufrNo.TabIndex = 10
        '
        'lblVer
        '
        Me.lblVer.AutoSize = True
        Me.lblVer.Location = New System.Drawing.Point(7, 212)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(121, 13)
        Me.lblVer.TabIndex = 9
        Me.lblVer.Text = "Local Table Version No."
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(8, 191)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(127, 13)
        Me.Label31.TabIndex = 8
        Me.Label31.Text = "Master Table Version No."
        '
        'lblLocalCat
        '
        Me.lblLocalCat.AutoSize = True
        Me.lblLocalCat.Location = New System.Drawing.Point(8, 170)
        Me.lblLocalCat.Name = "lblLocalCat"
        Me.lblLocalCat.Size = New System.Drawing.Size(126, 13)
        Me.lblLocalCat.TabIndex = 7
        Me.lblLocalCat.Text = "Local Data Sub-Category"
        '
        'lblSubcat
        '
        Me.lblSubcat.AutoSize = True
        Me.lblSubcat.Location = New System.Drawing.Point(8, 149)
        Me.lblSubcat.Name = "lblSubcat"
        Me.lblSubcat.Size = New System.Drawing.Size(158, 13)
        Me.lblSubcat.TabIndex = 6
        Me.lblSubcat.Text = "International Data Sub-Category"
        '
        'lblCat
        '
        Me.lblCat.AutoSize = True
        Me.lblCat.Location = New System.Drawing.Point(8, 128)
        Me.lblCat.Name = "lblCat"
        Me.lblCat.Size = New System.Drawing.Size(75, 13)
        Me.lblCat.TabIndex = 5
        Me.lblCat.Text = "Data Category"
        '
        'lblSeq
        '
        Me.lblSeq.AutoSize = True
        Me.lblSeq.Location = New System.Drawing.Point(8, 86)
        Me.lblSeq.Name = "lblSeq"
        Me.lblSeq.Size = New System.Drawing.Size(114, 13)
        Me.lblSeq.TabIndex = 3
        Me.lblSeq.Text = "Update Sequence No."
        '
        'lblSubcentr
        '
        Me.lblSubcentr.AutoSize = True
        Me.lblSubcentr.Location = New System.Drawing.Point(8, 65)
        Me.lblSubcentr.Name = "lblSubcentr"
        Me.lblSubcentr.Size = New System.Drawing.Size(170, 13)
        Me.lblSubcentr.TabIndex = 2
        Me.lblSubcentr.Text = "Originating/Generating Sub-Centre"
        '
        'lbCentr
        '
        Me.lbCentr.AutoSize = True
        Me.lbCentr.Location = New System.Drawing.Point(8, 44)
        Me.lbCentr.Name = "lbCentr"
        Me.lbCentr.Size = New System.Drawing.Size(148, 13)
        Me.lbCentr.TabIndex = 1
        Me.lbCentr.Text = "Originating/Generating Centre"
        '
        'lblEd
        '
        Me.lblEd.AutoSize = True
        Me.lblEd.Location = New System.Drawing.Point(7, 23)
        Me.lblEd.Name = "lblEd"
        Me.lblEd.Size = New System.Drawing.Size(91, 13)
        Me.lblEd.TabIndex = 0
        Me.lblEd.Text = "BUFR Edition No."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.TextBox11)
        Me.GroupBox4.Controls.Add(Me.lblMsgHeader)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 31)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 80)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = ""
        Me.GroupBox4.Text = "Header and Templates"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(119, 47)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(167, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(12, 51)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 13)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Encoding Template"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(169, 18)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(117, 20)
        Me.TextBox11.TabIndex = 1
        '
        'lblMsgHeader
        '
        Me.lblMsgHeader.AutoSize = True
        Me.lblMsgHeader.Location = New System.Drawing.Point(11, 22)
        Me.lblMsgHeader.Name = "lblMsgHeader"
        Me.lblMsgHeader.Size = New System.Drawing.Size(160, 13)
        Me.lblMsgHeader.TabIndex = 0
        Me.lblMsgHeader.Text = "Message Header (TTAAii CCCC)"
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
        Me.ClientSize = New System.Drawing.Size(931, 551)
        Me.Controls.Add(Me.pnlDataStructures)
        Me.Controls.Add(Me.pnlProcessing)
        Me.Controls.Add(Me.pnlSites)
        Me.Controls.Add(Me.pnlServers)
        Me.Controls.Add(Me.pnlMsgEncoding)
        Me.Controls.Add(Me.pnlControl)
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
        Me.pnlSites.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.DataGridViewSites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDataStructures.ResumeLayout(False)
        CType(Me.DataGridViewStructures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStructures1.ResumeLayout(False)
        Me.grpStructures1.PerformLayout()
        Me.grpStructures.ResumeLayout(False)
        Me.grpStructures.PerformLayout()
        Me.pnlServers.ResumeLayout(False)
        Me.pnlServers.PerformLayout()
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
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.grpSensors.ResumeLayout(False)
        Me.grpSensors.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.lblMaster.ResumeLayout(False)
        Me.lblMaster.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
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
    Friend WithEvents cmdMSSDelete As System.Windows.Forms.Button
    Friend WithEvents cmdMSSUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdMSSAddNew As System.Windows.Forms.Button
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
    Friend WithEvents lblServerSettings As System.Windows.Forms.Label
    Friend WithEvents pnlSites As System.Windows.Forms.Panel
    Friend WithEvents pnlMsgEncoding As System.Windows.Forms.Panel
    Friend WithEvents pnlDataStructures As System.Windows.Forms.Panel
    Friend WithEvents pnlBaseStation As System.Windows.Forms.Panel
    Friend WithEvents cmdBstDelete As System.Windows.Forms.Button
    Friend WithEvents cmdBsstUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdBstAddNew As System.Windows.Forms.Button
    Friend WithEvents txtbaseStationPWConfirm As System.Windows.Forms.TextBox
    Friend WithEvents txtbaseStationPW As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseStationUser As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseStationFolder As System.Windows.Forms.TextBox
    Friend WithEvents txtBaseStationAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmInputPW As System.Windows.Forms.Label
    Friend WithEvents lblInputPW As System.Windows.Forms.Label
    Friend WithEvents lblInputUser As System.Windows.Forms.Label
    Friend WithEvents lblFTPFolder As System.Windows.Forms.Label
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
    Friend WithEvents grpSensors As System.Windows.Forms.GroupBox
    Friend WithEvents txtWind As System.Windows.Forms.TextBox
    Friend WithEvents txtRainfall As System.Windows.Forms.TextBox
    Friend WithEvents txtVisibility As System.Windows.Forms.TextBox
    Friend WithEvents txtTemperature As System.Windows.Forms.TextBox
    Friend WithEvents lblWind As System.Windows.Forms.Label
    Friend WithEvents lblRainfall As System.Windows.Forms.Label
    Friend WithEvents lblVisbility As System.Windows.Forms.Label
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents txtPressure As System.Windows.Forms.TextBox
    Friend WithEvents lblPressure As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dgrdCodeFlag As System.Windows.Forms.DataGridView
    Friend WithEvents lblMaster As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents lblMsgHeader As System.Windows.Forms.Label
    Friend WithEvents chkOption As System.Windows.Forms.CheckBox
    Friend WithEvents txtLocalTabVerNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMasterTabVerNo As System.Windows.Forms.TextBox
    Friend WithEvents txtLocalDatSubCat As System.Windows.Forms.TextBox
    Friend WithEvents txtIntDatSubCat As System.Windows.Forms.TextBox
    Friend WithEvents txtDatCat As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdateSeqNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGenSubCentr As System.Windows.Forms.TextBox
    Friend WithEvents txtGenCentr As System.Windows.Forms.TextBox
    Friend WithEvents txtBufrNo As System.Windows.Forms.TextBox
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblLocalCat As System.Windows.Forms.Label
    Friend WithEvents lblSubcat As System.Windows.Forms.Label
    Friend WithEvents lblCat As System.Windows.Forms.Label
    Friend WithEvents lblSeq As System.Windows.Forms.Label
    Friend WithEvents lblSubcentr As System.Windows.Forms.Label
    Friend WithEvents lbCentr As System.Windows.Forms.Label
    Friend WithEvents lblEd As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOptionalSection As System.Windows.Forms.CheckBox
    Friend WithEvents LocaltableVersion As System.Windows.Forms.TextBox
    Friend WithEvents MastertableVersion As System.Windows.Forms.TextBox
    Friend WithEvents LocalSubcategory As System.Windows.Forms.TextBox
    Friend WithEvents InternationalSubcategory As System.Windows.Forms.TextBox
    Friend WithEvents txtDataCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdateSequence As System.Windows.Forms.TextBox
    Friend WithEvents txtOriginatingSubcentre As System.Windows.Forms.TextBox
    Friend WithEvents txtOriginatingCentre As System.Windows.Forms.TextBox
    Friend WithEvents txtBufrEdition As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
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
    Friend WithEvents cmdmssRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdmssReset As System.Windows.Forms.Button
    Friend WithEvents txtmssFTPMode As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
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
End Class
