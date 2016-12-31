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
        resources.ApplyResources(Me.pnlControl, "pnlControl")
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
        Me.cmdMessages.UseVisualStyleBackColor = False
        '
        'cmdDataStructures
        '
        Me.cmdDataStructures.BackColor = System.Drawing.Color.SeaShell
        Me.cmdDataStructures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDataStructures.Location = New System.Drawing.Point(19, 255)
        Me.cmdDataStructures.Name = "cmdDataStructures"
        Me.cmdDataStructures.UseVisualStyleBackColor = False
        '
        'cmdSites
        '
        Me.cmdSites.BackColor = System.Drawing.Color.SeaShell
        Me.cmdSites.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSites.Location = New System.Drawing.Point(18, 181)
        Me.cmdSites.Name = "cmdSites"
        Me.cmdSites.UseVisualStyleBackColor = False
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.Color.Coral
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'cmdServers
        '
        Me.cmdServers.BackColor = System.Drawing.Color.SeaShell
        Me.cmdServers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdServers.Location = New System.Drawing.Point(17, 107)
        Me.cmdServers.Name = "cmdServers"
        Me.cmdServers.UseVisualStyleBackColor = False
        '
        'cmdProcess
        '
        Me.cmdProcess.BackColor = System.Drawing.Color.SeaShell
        Me.cmdProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProcess.Location = New System.Drawing.Point(19, 32)
        Me.cmdProcess.Name = "cmdProcess"
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
        resources.ApplyResources(Me.pnlProcessing, "pnlProcessing")
        Me.pnlProcessing.Name = "pnlProcessing"
        Me.pnlProcessing.Size = New System.Drawing.Size(734, 109)
        Me.pnlProcessing.TabIndex = 1
        Me.pnlProcessing.Visible = False
        '
        'list_errors
        '
        Me.list_errors.FormattingEnabled = True
        resources.ApplyResources(Me.list_errors, "list_errors")
        Me.list_errors.Name = "list_errors"
        '
        'Ltime
        '
        resources.ApplyResources(Me.Ltime, "Ltime")
        Me.Ltime.BackColor = System.Drawing.Color.SeaShell
        Me.Ltime.Name = "Ltime"
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
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(572, 90)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'chkDeleteFile
        '
        Me.chkDeleteFile.AutoSize = True
        Me.chkDeleteFile.Location = New System.Drawing.Point(237, 94)
        Me.chkDeleteFile.Name = "chkDeleteFile"
        Me.chkDeleteFile.UseVisualStyleBackColor = True
        '
        'txtTimeout
        '
        Me.txtTimeout.Location = New System.Drawing.Point(182, 92)
        Me.txtTimeout.Name = "txtTimeout"
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
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'txtPeriod
        '
        resources.ApplyResources(Me.txtPeriod, "txtPeriod")
        Me.txtPeriod.Name = "txtPeriod"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'txtOffset
        '
        resources.ApplyResources(Me.txtOffset, "txtOffset")
        Me.txtOffset.Name = "txtOffset"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'txtInterval
        '
        resources.ApplyResources(Me.txtInterval, "txtInterval")
        Me.txtInterval.Name = "txtInterval"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
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
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'txtNxtProcess
        '
        Me.txtNxtProcess.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtNxtProcess, "txtNxtProcess")
        Me.txtNxtProcess.Name = "txtNxtProcess"
        '
        'txtNextProcess
        '
        resources.ApplyResources(Me.txtNextProcess, "txtNextProcess")
        Me.txtNextProcess.Name = "txtNextProcess"
        '
        'txtLastProcess
        '
        Me.txtLastProcess.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtLastProcess, "txtLastProcess")
        Me.txtLastProcess.Name = "txtLastProcess"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.SeaShell
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtStatus, "txtStatus")
        Me.txtStatus.Name = "txtStatus"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtDateTime
        '
        Me.txtDateTime.BackColor = System.Drawing.Color.MistyRose
        Me.txtDateTime.Enabled = False
        Me.txtDateTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateTime.Location = New System.Drawing.Point(118, 48)
        Me.txtDateTime.Name = "txtDateTime"
        '
        'lblDatetime
        '
        Me.lblDatetime.AutoSize = True
        Me.lblDatetime.Location = New System.Drawing.Point(0, 52)
        Me.lblDatetime.Name = "lblDatetime"
        '
        'lblSatus
        '
        resources.ApplyResources(Me.lblSatus, "lblSatus")
        Me.lblSatus.Name = "lblSatus"
        '
        'lblErrors
        '
        resources.ApplyResources(Me.lblErrors, "lblErrors")
        Me.lblErrors.Name = "lblErrors"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblInformation)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
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
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'lstOutputFiles
        '
        Me.lstOutputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstOutputFiles.FormattingEnabled = True
        resources.ApplyResources(Me.lstOutputFiles, "lstOutputFiles")
        Me.lstOutputFiles.MultiColumn = True
        Me.lstOutputFiles.Name = "lstOutputFiles"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtOutputFolder, "txtOutputFolder")
        Me.txtOutputFolder.Name = "txtOutputFolder"
        '
        'lblOutputFolder
        '
        resources.ApplyResources(Me.lblOutputFolder, "lblOutputFolder")
        Me.lblOutputFolder.Name = "lblOutputFolder"
        '
        'txtOutputServer
        '
        Me.txtOutputServer.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtOutputServer, "txtOutputServer")
        Me.txtOutputServer.Name = "txtOutputServer"
        '
        'lblOutputFTP
        '
        resources.ApplyResources(Me.lblOutputFTP, "lblOutputFTP")
        Me.lblOutputFTP.Name = "lblOutputFTP"
        '
        'pnlOutput
        '
        resources.ApplyResources(Me.pnlOutput, "pnlOutput")
        Me.pnlOutput.Name = "pnlOutput"
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
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'lblInputFiles
        '
        resources.ApplyResources(Me.lblInputFiles, "lblInputFiles")
        Me.lblInputFiles.Name = "lblInputFiles"
        '
        'lstInputFiles
        '
        Me.lstInputFiles.BackColor = System.Drawing.Color.SeaShell
        Me.lstInputFiles.FormattingEnabled = True
        resources.ApplyResources(Me.lstInputFiles, "lstInputFiles")
        Me.lstInputFiles.MultiColumn = True
        Me.lstInputFiles.Name = "lstInputFiles"
        '
        'txtInputfolder
        '
        Me.txtInputfolder.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtInputfolder, "txtInputfolder")
        Me.txtInputfolder.Name = "txtInputfolder"
        '
        'lblInputFolder
        '
        resources.ApplyResources(Me.lblInputFolder, "lblInputFolder")
        Me.lblInputFolder.Name = "lblInputFolder"
        '
        'txtInputServer
        '
        Me.txtInputServer.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.txtInputServer, "txtInputServer")
        Me.txtInputServer.Name = "txtInputServer"
        '
        'lblSever
        '
        resources.ApplyResources(Me.lblSever, "lblSever")
        Me.lblSever.Name = "lblSever"
        '
        'lblInputData
        '
        resources.ApplyResources(Me.lblInputData, "lblInputData")
        Me.lblInputData.Name = "lblInputData"
        '
        'lblInformation
        '
        resources.ApplyResources(Me.lblInformation, "lblInformation")
        Me.lblInformation.Name = "lblInformation"
        '
        'grpElements
        '
        resources.ApplyResources(Me.grpElements, "grpElements")
        Me.grpElements.Name = "grpElements"
        Me.grpElements.TabStop = False
        '
        'pnlSites
        '
        Me.pnlSites.AllowDrop = True
        resources.ApplyResources(Me.pnlSites, "pnlSites")
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
        resources.ApplyResources(Me.cmdClear, "cmdClear")
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'cmdViewUpdate
        '
        resources.ApplyResources(Me.cmdViewUpdate, "cmdViewUpdate")
        Me.cmdViewUpdate.Name = "cmdViewUpdate"
        Me.cmdViewUpdate.UseVisualStyleBackColor = True
        '
        'cmdDel
        '
        resources.ApplyResources(Me.cmdDel, "cmdDel")
        Me.cmdDel.Name = "cmdDel"
        Me.cmdDel.UseVisualStyleBackColor = True
        '
        'cmdUpdateSites
        '
        resources.ApplyResources(Me.cmdUpdateSites, "cmdUpdateSites")
        Me.cmdUpdateSites.Name = "cmdUpdateSites"
        Me.cmdUpdateSites.UseVisualStyleBackColor = True
        '
        'cmdAdd
        '
        resources.ApplyResources(Me.cmdAdd, "cmdAdd")
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        resources.ApplyResources(Me.btnMovePrevious, "btnMovePrevious")
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        resources.ApplyResources(Me.btnMoveFirst, "btnMoveFirst")
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        resources.ApplyResources(Me.btnMoveLast, "btnMoveLast")
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'txtSitesNavigator
        '
        resources.ApplyResources(Me.txtSitesNavigator, "txtSitesNavigator")
        Me.txtSitesNavigator.Name = "txtSitesNavigator"
        '
        'btnMoveNext
        '
        resources.ApplyResources(Me.btnMoveNext, "btnMoveNext")
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtIP
        '
        Me.txtIP.FormattingEnabled = True
        resources.ApplyResources(Me.txtIP, "txtIP")
        Me.txtIP.Name = "txtIP"
        '
        'txtDataStructure
        '
        Me.txtDataStructure.FormattingEnabled = True
        resources.ApplyResources(Me.txtDataStructure, "txtDataStructure")
        Me.txtDataStructure.Name = "txtDataStructure"
        '
        'txtFlag
        '
        resources.ApplyResources(Me.txtFlag, "txtFlag")
        Me.txtFlag.Name = "txtFlag"
        '
        'chkOperational
        '
        resources.ApplyResources(Me.chkOperational, "chkOperational")
        Me.chkOperational.Name = "chkOperational"
        Me.chkOperational.UseVisualStyleBackColor = True
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'txtInFile
        '
        resources.ApplyResources(Me.txtInFile, "txtInFile")
        Me.txtInFile.Name = "txtInFile"
        '
        'lblInfile
        '
        resources.ApplyResources(Me.lblInfile, "lblInfile")
        Me.lblInfile.Name = "lblInfile"
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
        Me.pnlDataStructures.Size = New System.Drawing.Size(734, 240)
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
        '
        'lblStructure
        '
        resources.ApplyResources(Me.lblStructure, "lblStructure")
        Me.lblStructure.Name = "lblStructure"
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
        resources.ApplyResources(Me.lblRecords, "lblRecords")
        Me.lblRecords.Name = "lblRecords"
        '
        'txtDelimiter
        '
        Me.txtDelimiter.FormattingEnabled = True
        Me.txtDelimiter.Items.AddRange(New Object() {"comma", "tab", "space"})
        Me.txtDelimiter.Location = New System.Drawing.Point(119, 31)
        Me.txtDelimiter.Name = "txtDelimiter"
        '
        'txtQualifier
        '
        resources.ApplyResources(Me.txtQualifier, "txtQualifier")
        Me.txtQualifier.Name = "txtQualifier"
        '
        'txtHeaders
        '
        resources.ApplyResources(Me.txtHeaders, "txtHeaders")
        Me.txtHeaders.Name = "txtHeaders"
        '
        'txtStrName
        '
        resources.ApplyResources(Me.txtStrName, "txtStrName")
        Me.txtStrName.Name = "txtStrName"
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(200, 118)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(117, 118)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdCreate
        '
        Me.cmdCreate.Location = New System.Drawing.Point(34, 118)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'lblStrName
        '
        resources.ApplyResources(Me.lblStrName, "lblStrName")
        Me.lblStrName.Name = "lblStrName"
        '
        'cmbExistingStructures
        '
        Me.cmbExistingStructures.FormattingEnabled = True
        resources.ApplyResources(Me.cmbExistingStructures, "cmbExistingStructures")
        Me.cmbExistingStructures.Name = "cmbExistingStructures"
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
        '
        'cmdRefresh
        '
        resources.ApplyResources(Me.cmdRefresh, "cmdRefresh")
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        resources.ApplyResources(Me.cmdReset, "cmdReset")
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'txtBasestationFTPMode
        '
        Me.txtBasestationFTPMode.FormattingEnabled = True
        Me.txtBasestationFTPMode.Items.AddRange(New Object() {resources.GetString("txtBasestationFTPMode.Items"), resources.GetString("txtBasestationFTPMode.Items1")})
        resources.ApplyResources(Me.txtBasestationFTPMode, "txtBasestationFTPMode")
        Me.txtBasestationFTPMode.Name = "txtBasestationFTPMode"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdPrevRecord)
        Me.GroupBox10.Controls.Add(Me.cmdFirstRecord)
        Me.GroupBox10.Controls.Add(Me.cmdLastRecord)
        Me.GroupBox10.Controls.Add(Me.cmdNextRecord)
        Me.GroupBox10.Controls.Add(Me.txtbssNavigator)
        resources.ApplyResources(Me.GroupBox10, "GroupBox10")
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.TabStop = False
        '
        'cmdPrevRecord
        '
        resources.ApplyResources(Me.cmdPrevRecord, "cmdPrevRecord")
        Me.cmdPrevRecord.Name = "cmdPrevRecord"
        Me.cmdPrevRecord.UseVisualStyleBackColor = True
        '
        'cmdFirstRecord
        '
        resources.ApplyResources(Me.cmdFirstRecord, "cmdFirstRecord")
        Me.cmdFirstRecord.Name = "cmdFirstRecord"
        Me.cmdFirstRecord.UseVisualStyleBackColor = True
        '
        'cmdLastRecord
        '
        resources.ApplyResources(Me.cmdLastRecord, "cmdLastRecord")
        Me.cmdLastRecord.Name = "cmdLastRecord"
        Me.cmdLastRecord.UseVisualStyleBackColor = True
        '
        'cmdNextRecord
        '
        resources.ApplyResources(Me.cmdNextRecord, "cmdNextRecord")
        Me.cmdNextRecord.Name = "cmdNextRecord"
        Me.cmdNextRecord.UseVisualStyleBackColor = True
        '
        'txtbssNavigator
        '
        resources.ApplyResources(Me.txtbssNavigator, "txtbssNavigator")
        Me.txtbssNavigator.Name = "txtbssNavigator"
        '
        'Label40
        '
        resources.ApplyResources(Me.Label40, "Label40")
        Me.Label40.Name = "Label40"
        '
        'lblbaseStation
        '
        resources.ApplyResources(Me.lblbaseStation, "lblbaseStation")
        Me.lblbaseStation.Name = "lblbaseStation"
        '
        'cmdBstDelete
        '
        resources.ApplyResources(Me.cmdBstDelete, "cmdBstDelete")
        Me.cmdBstDelete.Name = "cmdBstDelete"
        Me.cmdBstDelete.UseVisualStyleBackColor = True
        '
        'cmdBsstUpdate
        '
        resources.ApplyResources(Me.cmdBsstUpdate, "cmdBsstUpdate")
        Me.cmdBsstUpdate.Name = "cmdBsstUpdate"
        Me.cmdBsstUpdate.UseVisualStyleBackColor = True
        '
        'cmdBstAddNew
        '
        resources.ApplyResources(Me.cmdBstAddNew, "cmdBstAddNew")
        Me.cmdBstAddNew.Name = "cmdBstAddNew"
        Me.cmdBstAddNew.UseVisualStyleBackColor = True
        '
        'txtbaseStationPWConfirm
        '
        resources.ApplyResources(Me.txtbaseStationPWConfirm, "txtbaseStationPWConfirm")
        Me.txtbaseStationPWConfirm.Name = "txtbaseStationPWConfirm"
        Me.txtbaseStationPWConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtbaseStationPWConfirm.Size = New System.Drawing.Size(87, 20)
        Me.txtbaseStationPWConfirm.TabIndex = 10
        '
        'txtbaseStationPW
        '
        resources.ApplyResources(Me.txtbaseStationPW, "txtbaseStationPW")
        Me.txtbaseStationPW.Name = "txtbaseStationPW"
        '
        'txtBaseStationUser
        '
        resources.ApplyResources(Me.txtBaseStationUser, "txtBaseStationUser")
        Me.txtBaseStationUser.Name = "txtBaseStationUser"
        '
        'txtBaseStationFolder
        '
        resources.ApplyResources(Me.txtBaseStationFolder, "txtBaseStationFolder")
        Me.txtBaseStationFolder.Name = "txtBaseStationFolder"
        '
        'txtBaseStationAddress
        '
        resources.ApplyResources(Me.txtBaseStationAddress, "txtBaseStationAddress")
        Me.txtBaseStationAddress.Name = "txtBaseStationAddress"
        '
        'lblConfirmInputPW
        '
        resources.ApplyResources(Me.lblConfirmInputPW, "lblConfirmInputPW")
        Me.lblConfirmInputPW.Name = "lblConfirmInputPW"
        Me.lblConfirmInputPW.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmInputPW.TabIndex = 4
        Me.lblConfirmInputPW.Text = "Confirm Password"
        '
        'lblInputPW
        '
        resources.ApplyResources(Me.lblInputPW, "lblInputPW")
        Me.lblInputPW.Name = "lblInputPW"
        '
        'lblInputUser
        '
        resources.ApplyResources(Me.lblInputUser, "lblInputUser")
        Me.lblInputUser.Name = "lblInputUser"
        '
        'lblFTPFolder
        '
        resources.ApplyResources(Me.lblFTPFolder, "lblFTPFolder")
        Me.lblFTPFolder.Name = "lblFTPFolder"
        '
        'lblBaseStationFTP
        '
        resources.ApplyResources(Me.lblBaseStationFTP, "lblBaseStationFTP")
        Me.lblBaseStationFTP.Name = "lblBaseStationFTP"
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
        '
        'cmdmssRefresh
        '
        resources.ApplyResources(Me.cmdmssRefresh, "cmdmssRefresh")
        Me.cmdmssRefresh.Name = "cmdmssRefresh"
        Me.cmdmssRefresh.UseVisualStyleBackColor = True
        '
        'cmdmssReset
        '
        resources.ApplyResources(Me.cmdmssReset, "cmdmssReset")
        Me.cmdmssReset.Name = "cmdmssReset"
        Me.cmdmssReset.UseVisualStyleBackColor = True
        '
        'txtmssFTPMode
        '
        Me.txtmssFTPMode.FormattingEnabled = True
        Me.txtmssFTPMode.Items.AddRange(New Object() {resources.GetString("txtmssFTPMode.Items"), resources.GetString("txtmssFTPMode.Items1")})
        resources.ApplyResources(Me.txtmssFTPMode, "txtmssFTPMode")
        Me.txtmssFTPMode.Name = "txtmssFTPMode"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdmssPrev)
        Me.GroupBox1.Controls.Add(Me.cmdmssfirst)
        Me.GroupBox1.Controls.Add(Me.cmdmssLast)
        Me.GroupBox1.Controls.Add(Me.cmdmssNext)
        Me.GroupBox1.Controls.Add(Me.txtmssNavigator)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'cmdmssPrev
        '
        resources.ApplyResources(Me.cmdmssPrev, "cmdmssPrev")
        Me.cmdmssPrev.Name = "cmdmssPrev"
        Me.cmdmssPrev.UseVisualStyleBackColor = True
        '
        'cmdmssfirst
        '
        resources.ApplyResources(Me.cmdmssfirst, "cmdmssfirst")
        Me.cmdmssfirst.Name = "cmdmssfirst"
        Me.cmdmssfirst.UseVisualStyleBackColor = True
        '
        'cmdmssLast
        '
        resources.ApplyResources(Me.cmdmssLast, "cmdmssLast")
        Me.cmdmssLast.Name = "cmdmssLast"
        Me.cmdmssLast.UseVisualStyleBackColor = True
        '
        'cmdmssNext
        '
        resources.ApplyResources(Me.cmdmssNext, "cmdmssNext")
        Me.cmdmssNext.Name = "cmdmssNext"
        Me.cmdmssNext.UseVisualStyleBackColor = True
        '
        'txtmssNavigator
        '
        resources.ApplyResources(Me.txtmssNavigator, "txtmssNavigator")
        Me.txtmssNavigator.Name = "txtmssNavigator"
        '
        'lblFtpTransferMode
        '
        resources.ApplyResources(Me.lblFtpTransferMode, "lblFtpTransferMode")
        Me.lblFtpTransferMode.Name = "lblFtpTransferMode"
        '
        'lblMsgSwitch
        '
        resources.ApplyResources(Me.lblMsgSwitch, "lblMsgSwitch")
        Me.lblMsgSwitch.Name = "lblMsgSwitch"
        '
        'cmdMSSDelete
        '
        resources.ApplyResources(Me.cmdMSSDelete, "cmdMSSDelete")
        Me.cmdMSSDelete.Name = "cmdMSSDelete"
        Me.cmdMSSDelete.UseVisualStyleBackColor = True
        '
        'cmdMSSUpdate
        '
        resources.ApplyResources(Me.cmdMSSUpdate, "cmdMSSUpdate")
        Me.cmdMSSUpdate.Name = "cmdMSSUpdate"
        Me.cmdMSSUpdate.UseVisualStyleBackColor = True
        '
        'cmdMSSAddNew
        '
        resources.ApplyResources(Me.cmdMSSAddNew, "cmdMSSAddNew")
        Me.cmdMSSAddNew.Name = "cmdMSSAddNew"
        Me.cmdMSSAddNew.UseVisualStyleBackColor = True
        '
        'txtMSSConfirm
        '
        resources.ApplyResources(Me.txtMSSConfirm, "txtMSSConfirm")
        Me.txtMSSConfirm.Name = "txtMSSConfirm"
        Me.txtMSSConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtMSSConfirm.Size = New System.Drawing.Size(81, 20)
        Me.txtMSSConfirm.TabIndex = 10
        '
        'txtMSSPW
        '
        resources.ApplyResources(Me.txtMSSPW, "txtMSSPW")
        Me.txtMSSPW.Name = "txtMSSPW"
        '
        'txtmssUser
        '
        resources.ApplyResources(Me.txtmssUser, "txtmssUser")
        Me.txtmssUser.Name = "txtmssUser"
        '
        'txtMSSFolder
        '
        resources.ApplyResources(Me.txtMSSFolder, "txtMSSFolder")
        Me.txtMSSFolder.Name = "txtMSSFolder"
        '
        'txtMSSAddress
        '
        resources.ApplyResources(Me.txtMSSAddress, "txtMSSAddress")
        Me.txtMSSAddress.Name = "txtMSSAddress"
        '
        'lblmssConfirmPassword
        '
        resources.ApplyResources(Me.lblmssConfirmPassword, "lblmssConfirmPassword")
        Me.lblmssConfirmPassword.Name = "lblmssConfirmPassword"
        Me.lblmssConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblmssConfirmPassword.TabIndex = 4
        Me.lblmssConfirmPassword.Text = "Confirm Password"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
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
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgrdCodeFlag)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'dgrdCodeFlag
        '
        Me.dgrdCodeFlag.BackgroundColor = System.Drawing.Color.Ivory
        Me.dgrdCodeFlag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgrdCodeFlag, "dgrdCodeFlag")
        Me.dgrdCodeFlag.Name = "dgrdCodeFlag"
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
        resources.ApplyResources(Me.GroupBox9, "GroupBox9")
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Tag = ""
        '
        'TextBox22
        '
        resources.ApplyResources(Me.TextBox22, "TextBox22")
        Me.TextBox22.Name = "TextBox22"
        '
        'TextBox23
        '
        resources.ApplyResources(Me.TextBox23, "TextBox23")
        Me.TextBox23.Name = "TextBox23"
        '
        'TextBox24
        '
        resources.ApplyResources(Me.TextBox24, "TextBox24")
        Me.TextBox24.Name = "TextBox24"
        '
        'TextBox25
        '
        resources.ApplyResources(Me.TextBox25, "TextBox25")
        Me.TextBox25.Name = "TextBox25"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.Name = "Label35"
        '
        'Label36
        '
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.Name = "Label36"
        '
        'Label37
        '
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.Name = "Label37"
        '
        'Label38
        '
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.Name = "Label38"
        '
        'TextBox26
        '
        resources.ApplyResources(Me.TextBox26, "TextBox26")
        Me.TextBox26.Name = "TextBox26"
        '
        'Label39
        '
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.Name = "Label39"
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
        resources.ApplyResources(Me.grpSensors, "grpSensors")
        Me.grpSensors.Name = "grpSensors"
        Me.grpSensors.TabStop = False
        Me.grpSensors.Tag = ""
        '
        'txtWind
        '
        resources.ApplyResources(Me.txtWind, "txtWind")
        Me.txtWind.Name = "txtWind"
        '
        'txtRainfall
        '
        resources.ApplyResources(Me.txtRainfall, "txtRainfall")
        Me.txtRainfall.Name = "txtRainfall"
        '
        'txtVisibility
        '
        resources.ApplyResources(Me.txtVisibility, "txtVisibility")
        Me.txtVisibility.Name = "txtVisibility"
        '
        'txtTemperature
        '
        resources.ApplyResources(Me.txtTemperature, "txtTemperature")
        Me.txtTemperature.Name = "txtTemperature"
        '
        'lblWind
        '
        resources.ApplyResources(Me.lblWind, "lblWind")
        Me.lblWind.Name = "lblWind"
        '
        'lblRainfall
        '
        resources.ApplyResources(Me.lblRainfall, "lblRainfall")
        Me.lblRainfall.Name = "lblRainfall"
        '
        'lblVisbility
        '
        resources.ApplyResources(Me.lblVisbility, "lblVisbility")
        Me.lblVisbility.Name = "lblVisbility"
        '
        'lblTemp
        '
        resources.ApplyResources(Me.lblTemp, "lblTemp")
        Me.lblTemp.Name = "lblTemp"
        '
        'txtPressure
        '
        resources.ApplyResources(Me.txtPressure, "txtPressure")
        Me.txtPressure.Name = "txtPressure"
        '
        'lblPressure
        '
        resources.ApplyResources(Me.lblPressure, "lblPressure")
        Me.lblPressure.Name = "lblPressure"
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
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'chkOptionalSection
        '
        resources.ApplyResources(Me.chkOptionalSection, "chkOptionalSection")
        Me.chkOptionalSection.Name = "chkOptionalSection"
        Me.chkOptionalSection.Tag = "  "
        Me.chkOptionalSection.UseVisualStyleBackColor = True
        '
        'LocaltableVersion
        '
        resources.ApplyResources(Me.LocaltableVersion, "LocaltableVersion")
        Me.LocaltableVersion.Name = "LocaltableVersion"
        '
        'MastertableVersion
        '
        resources.ApplyResources(Me.MastertableVersion, "MastertableVersion")
        Me.MastertableVersion.Name = "MastertableVersion"
        '
        'LocalSubcategory
        '
        resources.ApplyResources(Me.LocalSubcategory, "LocalSubcategory")
        Me.LocalSubcategory.Name = "LocalSubcategory"
        '
        'InternationalSubcategory
        '
        resources.ApplyResources(Me.InternationalSubcategory, "InternationalSubcategory")
        Me.InternationalSubcategory.Name = "InternationalSubcategory"
        '
        'txtDataCategory
        '
        resources.ApplyResources(Me.txtDataCategory, "txtDataCategory")
        Me.txtDataCategory.Name = "txtDataCategory"
        '
        'txtUpdateSequence
        '
        resources.ApplyResources(Me.txtUpdateSequence, "txtUpdateSequence")
        Me.txtUpdateSequence.Name = "txtUpdateSequence"
        '
        'txtOriginatingSubcentre
        '
        resources.ApplyResources(Me.txtOriginatingSubcentre, "txtOriginatingSubcentre")
        Me.txtOriginatingSubcentre.Name = "txtOriginatingSubcentre"
        '
        'txtOriginatingCentre
        '
        resources.ApplyResources(Me.txtOriginatingCentre, "txtOriginatingCentre")
        Me.txtOriginatingCentre.Name = "txtOriginatingCentre"
        '
        'txtBufrEdition
        '
        resources.ApplyResources(Me.txtBufrEdition, "txtBufrEdition")
        Me.txtBufrEdition.Name = "txtBufrEdition"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.Name = "Label33"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.Name = "Label34"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtTemplate)
        Me.GroupBox5.Controls.Add(Me.Label23)
        Me.GroupBox5.Controls.Add(Me.GroupBox8)
        Me.GroupBox5.Controls.Add(Me.txtMsgHeader)
        Me.GroupBox5.Controls.Add(Me.Label24)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Tag = ""
        '
        'txtTemplate
        '
        Me.txtTemplate.FormattingEnabled = True
        Me.txtTemplate.Items.AddRange(New Object() {resources.GetString("txtTemplate.Items")})
        resources.ApplyResources(Me.txtTemplate, "txtTemplate")
        Me.txtTemplate.Name = "txtTemplate"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.DataGridView2)
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.Ivory
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.DataGridView2, "DataGridView2")
        Me.DataGridView2.Name = "DataGridView2"
        '
        'txtMsgHeader
        '
        resources.ApplyResources(Me.txtMsgHeader, "txtMsgHeader")
        Me.txtMsgHeader.Name = "txtMsgHeader"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
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
        resources.ApplyResources(Me.lblMaster, "lblMaster")
        Me.lblMaster.Name = "lblMaster"
        Me.lblMaster.TabStop = False
        '
        'chkOption
        '
        resources.ApplyResources(Me.chkOption, "chkOption")
        Me.chkOption.Name = "chkOption"
        Me.chkOption.Tag = "  "
        Me.chkOption.UseVisualStyleBackColor = True
        '
        'txtLocalTabVerNo
        '
        resources.ApplyResources(Me.txtLocalTabVerNo, "txtLocalTabVerNo")
        Me.txtLocalTabVerNo.Name = "txtLocalTabVerNo"
        '
        'txtMasterTabVerNo
        '
        resources.ApplyResources(Me.txtMasterTabVerNo, "txtMasterTabVerNo")
        Me.txtMasterTabVerNo.Name = "txtMasterTabVerNo"
        '
        'txtLocalDatSubCat
        '
        resources.ApplyResources(Me.txtLocalDatSubCat, "txtLocalDatSubCat")
        Me.txtLocalDatSubCat.Name = "txtLocalDatSubCat"
        '
        'txtIntDatSubCat
        '
        resources.ApplyResources(Me.txtIntDatSubCat, "txtIntDatSubCat")
        Me.txtIntDatSubCat.Name = "txtIntDatSubCat"
        '
        'txtDatCat
        '
        resources.ApplyResources(Me.txtDatCat, "txtDatCat")
        Me.txtDatCat.Name = "txtDatCat"
        '
        'txtUpdateSeqNo
        '
        resources.ApplyResources(Me.txtUpdateSeqNo, "txtUpdateSeqNo")
        Me.txtUpdateSeqNo.Name = "txtUpdateSeqNo"
        '
        'txtGenSubCentr
        '
        resources.ApplyResources(Me.txtGenSubCentr, "txtGenSubCentr")
        Me.txtGenSubCentr.Name = "txtGenSubCentr"
        '
        'txtGenCentr
        '
        resources.ApplyResources(Me.txtGenCentr, "txtGenCentr")
        Me.txtGenCentr.Name = "txtGenCentr"
        '
        'txtBufrNo
        '
        resources.ApplyResources(Me.txtBufrNo, "txtBufrNo")
        Me.txtBufrNo.Name = "txtBufrNo"
        '
        'lblVer
        '
        resources.ApplyResources(Me.lblVer, "lblVer")
        Me.lblVer.Name = "lblVer"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'lblLocalCat
        '
        resources.ApplyResources(Me.lblLocalCat, "lblLocalCat")
        Me.lblLocalCat.Name = "lblLocalCat"
        '
        'lblSubcat
        '
        resources.ApplyResources(Me.lblSubcat, "lblSubcat")
        Me.lblSubcat.Name = "lblSubcat"
        '
        'lblCat
        '
        resources.ApplyResources(Me.lblCat, "lblCat")
        Me.lblCat.Name = "lblCat"
        '
        'lblSeq
        '
        resources.ApplyResources(Me.lblSeq, "lblSeq")
        Me.lblSeq.Name = "lblSeq"
        '
        'lblSubcentr
        '
        resources.ApplyResources(Me.lblSubcentr, "lblSubcentr")
        Me.lblSubcentr.Name = "lblSubcentr"
        '
        'lbCentr
        '
        resources.ApplyResources(Me.lbCentr, "lbCentr")
        Me.lbCentr.Name = "lbCentr"
        '
        'lblEd
        '
        resources.ApplyResources(Me.lblEd, "lblEd")
        Me.lblEd.Name = "lblEd"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.TextBox11)
        Me.GroupBox4.Controls.Add(Me.lblMsgHeader)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = ""
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        resources.ApplyResources(Me.ComboBox1, "ComboBox1")
        Me.ComboBox1.Name = "ComboBox1"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'TextBox11
        '
        resources.ApplyResources(Me.TextBox11, "TextBox11")
        Me.TextBox11.Name = "TextBox11"
        '
        'lblMsgHeader
        '
        resources.ApplyResources(Me.lblMsgHeader, "lblMsgHeader")
        Me.lblMsgHeader.Name = "lblMsgHeader"
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
        resources.ApplyResources(Me, "$this")
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
