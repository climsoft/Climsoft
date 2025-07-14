<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formUpperAir
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
        Me.grpHeaders = New System.Windows.Forms.GroupBox()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.cboLevel = New System.Windows.Forms.ComboBox()
        Me.cboHour = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lbStation = New System.Windows.Forms.Label()
        Me.grpData = New System.Windows.Forms.GroupBox()
        Me.txtFlag313Field026 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem313Field013 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFlag312Field031 = New System.Windows.Forms.TextBox()
        Me.txtFlag308Field030 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem308Field017 = New System.Windows.Forms.TextBox()
        Me.txtFlag307Field029 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem307Field016 = New System.Windows.Forms.TextBox()
        Me.txtFlag306Field028 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem306Field015 = New System.Windows.Forms.TextBox()
        Me.txtFlag305Field027 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem305Field014 = New System.Windows.Forms.TextBox()
        Me.txtFlag304Field025 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem304Field012 = New System.Windows.Forms.TextBox()
        Me.txtFlag303Field024 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem303Field011 = New System.Windows.Forms.TextBox()
        Me.txtFlag302Field023 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem302Field010 = New System.Windows.Forms.TextBox()
        Me.txtFlag301Field022 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem301Field009 = New System.Windows.Forms.TextBox()
        Me.txtFlag310Field021 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem310Field008 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem312Field018 = New System.Windows.Forms.TextBox()
        Me.txtFlag309Field020 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem309Field007 = New System.Windows.Forms.TextBox()
        Me.lblFlag = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtFlag311Field019 = New System.Windows.Forms.TextBox()
        Me.txtVal_Elem311Field006 = New System.Windows.Forms.TextBox()
        Me.lblVerSig = New System.Windows.Forms.Label()
        Me.lblWindShrA = New System.Windows.Forms.Label()
        Me.lblWindShrB = New System.Windows.Forms.Label()
        Me.lblWindspd = New System.Windows.Forms.Label()
        Me.lblWinddir = New System.Windows.Forms.Label()
        Me.lblDPT = New System.Windows.Forms.Label()
        Me.lblDBT = New System.Windows.Forms.Label()
        Me.lblGeop = New System.Windows.Forms.Label()
        Me.lblPress = New System.Windows.Forms.Label()
        Me.lblLonDisp = New System.Windows.Forms.Label()
        Me.lblLatdisp = New System.Windows.Forms.Label()
        Me.lblTimeDisp = New System.Windows.Forms.Label()
        Me.pnlConmmand = New System.Windows.Forms.Panel()
        Me.chkRepeatEntry = New System.Windows.Forms.CheckBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPush = New System.Windows.Forms.Button()
        Me.grpHeaders.SuspendLayout()
        Me.grpData.SuspendLayout()
        Me.pnlConmmand.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpHeaders
        '
        Me.grpHeaders.Controls.Add(Me.cboStation)
        Me.grpHeaders.Controls.Add(Me.cboLevel)
        Me.grpHeaders.Controls.Add(Me.cboHour)
        Me.grpHeaders.Controls.Add(Me.cboMonth)
        Me.grpHeaders.Controls.Add(Me.cboDay)
        Me.grpHeaders.Controls.Add(Me.txtYear)
        Me.grpHeaders.Controls.Add(Me.lblLevel)
        Me.grpHeaders.Controls.Add(Me.lblHour)
        Me.grpHeaders.Controls.Add(Me.lblDay)
        Me.grpHeaders.Controls.Add(Me.lblMonth)
        Me.grpHeaders.Controls.Add(Me.lblYear)
        Me.grpHeaders.Controls.Add(Me.lbStation)
        Me.grpHeaders.Location = New System.Drawing.Point(8, 14)
        Me.grpHeaders.Name = "grpHeaders"
        Me.grpHeaders.Size = New System.Drawing.Size(642, 90)
        Me.grpHeaders.TabIndex = 0
        Me.grpHeaders.TabStop = False
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Items.AddRange(New Object() {"Surface", "1000", "925", "850", "700", "500", "400", "300", "250", "200", "150", "100", "70", "50", "30", "20", "10"})
        Me.cboStation.Location = New System.Drawing.Point(162, 16)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(392, 21)
        Me.cboStation.TabIndex = 0
        '
        'cboLevel
        '
        Me.cboLevel.FormattingEnabled = True
        Me.cboLevel.Items.AddRange(New Object() {"Surface", "1000", "925", "850", "700", "500", "400", "300", "250", "200", "150", "100", "70", "50", "30", "20", "10"})
        Me.cboLevel.Location = New System.Drawing.Point(497, 56)
        Me.cboLevel.Name = "cboLevel"
        Me.cboLevel.Size = New System.Drawing.Size(106, 21)
        Me.cboLevel.TabIndex = 5
        '
        'cboHour
        '
        Me.cboHour.FormattingEnabled = True
        Me.cboHour.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboHour.Location = New System.Drawing.Point(390, 56)
        Me.cboHour.Name = "cboHour"
        Me.cboHour.Size = New System.Drawing.Size(36, 21)
        Me.cboHour.TabIndex = 4
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(199, 56)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(36, 21)
        Me.cboMonth.TabIndex = 2
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(289, 56)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(36, 21)
        Me.cboDay.TabIndex = 3
        Me.cboDay.Tag = ""
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(85, 56)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(38, 20)
        Me.txtYear.TabIndex = 1
        '
        'lblLevel
        '
        Me.lblLevel.Location = New System.Drawing.Point(437, 61)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(54, 13)
        Me.lblLevel.TabIndex = 6
        Me.lblLevel.Text = "Level"
        Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblHour
        '
        Me.lblHour.Location = New System.Drawing.Point(331, 61)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(53, 13)
        Me.lblHour.TabIndex = 5
        Me.lblHour.Text = "Hour"
        Me.lblHour.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblDay
        '
        Me.lblDay.Location = New System.Drawing.Point(250, 61)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(33, 13)
        Me.lblDay.TabIndex = 4
        Me.lblDay.Text = "Day"
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMonth
        '
        Me.lblMonth.Location = New System.Drawing.Point(150, 60)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(44, 13)
        Me.lblMonth.TabIndex = 3
        Me.lblMonth.Text = "Month"
        Me.lblMonth.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblYear
        '
        Me.lblYear.Location = New System.Drawing.Point(32, 60)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(47, 13)
        Me.lblYear.TabIndex = 2
        Me.lblYear.Text = "Year"
        Me.lblYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbStation
        '
        Me.lbStation.Location = New System.Drawing.Point(6, 22)
        Me.lbStation.Name = "lbStation"
        Me.lbStation.Size = New System.Drawing.Size(150, 13)
        Me.lbStation.TabIndex = 0
        Me.lbStation.Text = "Station Name/ID"
        Me.lbStation.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'grpData
        '
        Me.grpData.Controls.Add(Me.txtFlag313Field026)
        Me.grpData.Controls.Add(Me.txtVal_Elem313Field013)
        Me.grpData.Controls.Add(Me.Label1)
        Me.grpData.Controls.Add(Me.txtFlag312Field031)
        Me.grpData.Controls.Add(Me.txtFlag308Field030)
        Me.grpData.Controls.Add(Me.txtVal_Elem308Field017)
        Me.grpData.Controls.Add(Me.txtFlag307Field029)
        Me.grpData.Controls.Add(Me.txtVal_Elem307Field016)
        Me.grpData.Controls.Add(Me.txtFlag306Field028)
        Me.grpData.Controls.Add(Me.txtVal_Elem306Field015)
        Me.grpData.Controls.Add(Me.txtFlag305Field027)
        Me.grpData.Controls.Add(Me.txtVal_Elem305Field014)
        Me.grpData.Controls.Add(Me.txtFlag304Field025)
        Me.grpData.Controls.Add(Me.txtVal_Elem304Field012)
        Me.grpData.Controls.Add(Me.txtFlag303Field024)
        Me.grpData.Controls.Add(Me.txtVal_Elem303Field011)
        Me.grpData.Controls.Add(Me.txtFlag302Field023)
        Me.grpData.Controls.Add(Me.txtVal_Elem302Field010)
        Me.grpData.Controls.Add(Me.txtFlag301Field022)
        Me.grpData.Controls.Add(Me.txtVal_Elem301Field009)
        Me.grpData.Controls.Add(Me.txtFlag310Field021)
        Me.grpData.Controls.Add(Me.txtVal_Elem310Field008)
        Me.grpData.Controls.Add(Me.txtVal_Elem312Field018)
        Me.grpData.Controls.Add(Me.txtFlag309Field020)
        Me.grpData.Controls.Add(Me.txtVal_Elem309Field007)
        Me.grpData.Controls.Add(Me.lblFlag)
        Me.grpData.Controls.Add(Me.lblValue)
        Me.grpData.Controls.Add(Me.txtFlag311Field019)
        Me.grpData.Controls.Add(Me.txtVal_Elem311Field006)
        Me.grpData.Controls.Add(Me.lblVerSig)
        Me.grpData.Controls.Add(Me.lblWindShrA)
        Me.grpData.Controls.Add(Me.lblWindShrB)
        Me.grpData.Controls.Add(Me.lblWindspd)
        Me.grpData.Controls.Add(Me.lblWinddir)
        Me.grpData.Controls.Add(Me.lblDPT)
        Me.grpData.Controls.Add(Me.lblDBT)
        Me.grpData.Controls.Add(Me.lblGeop)
        Me.grpData.Controls.Add(Me.lblPress)
        Me.grpData.Controls.Add(Me.lblLonDisp)
        Me.grpData.Controls.Add(Me.lblLatdisp)
        Me.grpData.Controls.Add(Me.lblTimeDisp)
        Me.grpData.Location = New System.Drawing.Point(103, 124)
        Me.grpData.Name = "grpData"
        Me.grpData.Size = New System.Drawing.Size(419, 377)
        Me.grpData.TabIndex = 1
        Me.grpData.TabStop = False
        '
        'txtFlag313Field026
        '
        Me.txtFlag313Field026.Location = New System.Drawing.Point(342, 214)
        Me.txtFlag313Field026.Name = "txtFlag313Field026"
        Me.txtFlag313Field026.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag313Field026.TabIndex = 38
        Me.txtFlag313Field026.TabStop = False
        '
        'txtVal_Elem313Field013
        '
        Me.txtVal_Elem313Field013.Location = New System.Drawing.Point(279, 214)
        Me.txtVal_Elem313Field013.Name = "txtVal_Elem313Field013"
        Me.txtVal_Elem313Field013.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem313Field013.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(40, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Relative Humidity"
        '
        'txtFlag312Field031
        '
        Me.txtFlag312Field031.Location = New System.Drawing.Point(342, 344)
        Me.txtFlag312Field031.Name = "txtFlag312Field031"
        Me.txtFlag312Field031.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag312Field031.TabIndex = 43
        Me.txtFlag312Field031.TabStop = False
        '
        'txtFlag308Field030
        '
        Me.txtFlag308Field030.Location = New System.Drawing.Point(342, 318)
        Me.txtFlag308Field030.Name = "txtFlag308Field030"
        Me.txtFlag308Field030.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag308Field030.TabIndex = 42
        Me.txtFlag308Field030.TabStop = False
        '
        'txtVal_Elem308Field017
        '
        Me.txtVal_Elem308Field017.Location = New System.Drawing.Point(279, 318)
        Me.txtVal_Elem308Field017.Name = "txtVal_Elem308Field017"
        Me.txtVal_Elem308Field017.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem308Field017.TabIndex = 17
        '
        'txtFlag307Field029
        '
        Me.txtFlag307Field029.Location = New System.Drawing.Point(342, 292)
        Me.txtFlag307Field029.Name = "txtFlag307Field029"
        Me.txtFlag307Field029.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag307Field029.TabIndex = 41
        Me.txtFlag307Field029.TabStop = False
        '
        'txtVal_Elem307Field016
        '
        Me.txtVal_Elem307Field016.Location = New System.Drawing.Point(279, 292)
        Me.txtVal_Elem307Field016.Name = "txtVal_Elem307Field016"
        Me.txtVal_Elem307Field016.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem307Field016.TabIndex = 16
        '
        'txtFlag306Field028
        '
        Me.txtFlag306Field028.Location = New System.Drawing.Point(342, 266)
        Me.txtFlag306Field028.Name = "txtFlag306Field028"
        Me.txtFlag306Field028.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag306Field028.TabIndex = 40
        Me.txtFlag306Field028.TabStop = False
        '
        'txtVal_Elem306Field015
        '
        Me.txtVal_Elem306Field015.Location = New System.Drawing.Point(279, 266)
        Me.txtVal_Elem306Field015.Name = "txtVal_Elem306Field015"
        Me.txtVal_Elem306Field015.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem306Field015.TabIndex = 15
        '
        'txtFlag305Field027
        '
        Me.txtFlag305Field027.Location = New System.Drawing.Point(342, 240)
        Me.txtFlag305Field027.Name = "txtFlag305Field027"
        Me.txtFlag305Field027.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag305Field027.TabIndex = 39
        Me.txtFlag305Field027.TabStop = False
        '
        'txtVal_Elem305Field014
        '
        Me.txtVal_Elem305Field014.Location = New System.Drawing.Point(279, 240)
        Me.txtVal_Elem305Field014.Name = "txtVal_Elem305Field014"
        Me.txtVal_Elem305Field014.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem305Field014.TabIndex = 14
        '
        'txtFlag304Field025
        '
        Me.txtFlag304Field025.Location = New System.Drawing.Point(342, 188)
        Me.txtFlag304Field025.Name = "txtFlag304Field025"
        Me.txtFlag304Field025.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag304Field025.TabIndex = 37
        Me.txtFlag304Field025.TabStop = False
        '
        'txtVal_Elem304Field012
        '
        Me.txtVal_Elem304Field012.Location = New System.Drawing.Point(279, 188)
        Me.txtVal_Elem304Field012.Name = "txtVal_Elem304Field012"
        Me.txtVal_Elem304Field012.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem304Field012.TabIndex = 12
        '
        'txtFlag303Field024
        '
        Me.txtFlag303Field024.Location = New System.Drawing.Point(342, 162)
        Me.txtFlag303Field024.Name = "txtFlag303Field024"
        Me.txtFlag303Field024.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag303Field024.TabIndex = 36
        Me.txtFlag303Field024.TabStop = False
        '
        'txtVal_Elem303Field011
        '
        Me.txtVal_Elem303Field011.Location = New System.Drawing.Point(279, 162)
        Me.txtVal_Elem303Field011.Name = "txtVal_Elem303Field011"
        Me.txtVal_Elem303Field011.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem303Field011.TabIndex = 11
        '
        'txtFlag302Field023
        '
        Me.txtFlag302Field023.Location = New System.Drawing.Point(342, 136)
        Me.txtFlag302Field023.Name = "txtFlag302Field023"
        Me.txtFlag302Field023.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag302Field023.TabIndex = 35
        Me.txtFlag302Field023.TabStop = False
        '
        'txtVal_Elem302Field010
        '
        Me.txtVal_Elem302Field010.Location = New System.Drawing.Point(279, 136)
        Me.txtVal_Elem302Field010.Name = "txtVal_Elem302Field010"
        Me.txtVal_Elem302Field010.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem302Field010.TabIndex = 10
        '
        'txtFlag301Field022
        '
        Me.txtFlag301Field022.Location = New System.Drawing.Point(342, 110)
        Me.txtFlag301Field022.Name = "txtFlag301Field022"
        Me.txtFlag301Field022.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag301Field022.TabIndex = 34
        Me.txtFlag301Field022.TabStop = False
        '
        'txtVal_Elem301Field009
        '
        Me.txtVal_Elem301Field009.Location = New System.Drawing.Point(279, 110)
        Me.txtVal_Elem301Field009.Name = "txtVal_Elem301Field009"
        Me.txtVal_Elem301Field009.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem301Field009.TabIndex = 9
        '
        'txtFlag310Field021
        '
        Me.txtFlag310Field021.Location = New System.Drawing.Point(342, 84)
        Me.txtFlag310Field021.Name = "txtFlag310Field021"
        Me.txtFlag310Field021.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag310Field021.TabIndex = 33
        Me.txtFlag310Field021.TabStop = False
        '
        'txtVal_Elem310Field008
        '
        Me.txtVal_Elem310Field008.Location = New System.Drawing.Point(279, 84)
        Me.txtVal_Elem310Field008.Name = "txtVal_Elem310Field008"
        Me.txtVal_Elem310Field008.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem310Field008.TabIndex = 8
        '
        'txtVal_Elem312Field018
        '
        Me.txtVal_Elem312Field018.Location = New System.Drawing.Point(279, 344)
        Me.txtVal_Elem312Field018.Name = "txtVal_Elem312Field018"
        Me.txtVal_Elem312Field018.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem312Field018.TabIndex = 18
        '
        'txtFlag309Field020
        '
        Me.txtFlag309Field020.Location = New System.Drawing.Point(342, 58)
        Me.txtFlag309Field020.Name = "txtFlag309Field020"
        Me.txtFlag309Field020.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag309Field020.TabIndex = 32
        Me.txtFlag309Field020.TabStop = False
        '
        'txtVal_Elem309Field007
        '
        Me.txtVal_Elem309Field007.Location = New System.Drawing.Point(279, 58)
        Me.txtVal_Elem309Field007.Name = "txtVal_Elem309Field007"
        Me.txtVal_Elem309Field007.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem309Field007.TabIndex = 7
        '
        'lblFlag
        '
        Me.lblFlag.AutoSize = True
        Me.lblFlag.Location = New System.Drawing.Point(342, 16)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Size = New System.Drawing.Size(27, 13)
        Me.lblFlag.TabIndex = 15
        Me.lblFlag.Text = "Flag"
        '
        'lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(281, 16)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(34, 13)
        Me.lblValue.TabIndex = 14
        Me.lblValue.Text = "Value"
        '
        'txtFlag311Field019
        '
        Me.txtFlag311Field019.Location = New System.Drawing.Point(342, 32)
        Me.txtFlag311Field019.Name = "txtFlag311Field019"
        Me.txtFlag311Field019.Size = New System.Drawing.Size(36, 20)
        Me.txtFlag311Field019.TabIndex = 31
        Me.txtFlag311Field019.TabStop = False
        '
        'txtVal_Elem311Field006
        '
        Me.txtVal_Elem311Field006.Location = New System.Drawing.Point(279, 32)
        Me.txtVal_Elem311Field006.Name = "txtVal_Elem311Field006"
        Me.txtVal_Elem311Field006.Size = New System.Drawing.Size(56, 20)
        Me.txtVal_Elem311Field006.TabIndex = 6
        '
        'lblVerSig
        '
        Me.lblVerSig.AutoSize = True
        Me.lblVerSig.Location = New System.Drawing.Point(40, 348)
        Me.lblVerSig.Name = "lblVerSig"
        Me.lblVerSig.Size = New System.Drawing.Size(136, 13)
        Me.lblVerSig.TabIndex = 11
        Me.lblVerSig.Text = "Vertical Significance (code)"
        '
        'lblWindShrA
        '
        Me.lblWindShrA.AutoSize = True
        Me.lblWindShrA.Location = New System.Drawing.Point(40, 322)
        Me.lblWindShrA.Name = "lblWindShrA"
        Me.lblWindShrA.Size = New System.Drawing.Size(147, 13)
        Me.lblWindShrA.TabIndex = 10
        Me.lblWindShrA.Text = "Wind Sheer 1 km layer above"
        '
        'lblWindShrB
        '
        Me.lblWindShrB.AutoSize = True
        Me.lblWindShrB.Location = New System.Drawing.Point(40, 296)
        Me.lblWindShrB.Name = "lblWindShrB"
        Me.lblWindShrB.Size = New System.Drawing.Size(145, 13)
        Me.lblWindShrB.TabIndex = 9
        Me.lblWindShrB.Text = "Wind Sheer 1 km layer below"
        '
        'lblWindspd
        '
        Me.lblWindspd.AutoSize = True
        Me.lblWindspd.Location = New System.Drawing.Point(40, 270)
        Me.lblWindspd.Name = "lblWindspd"
        Me.lblWindspd.Size = New System.Drawing.Size(66, 13)
        Me.lblWindspd.TabIndex = 8
        Me.lblWindspd.Text = "Wind Speed"
        '
        'lblWinddir
        '
        Me.lblWinddir.AutoSize = True
        Me.lblWinddir.Location = New System.Drawing.Point(40, 244)
        Me.lblWinddir.Name = "lblWinddir"
        Me.lblWinddir.Size = New System.Drawing.Size(77, 13)
        Me.lblWinddir.TabIndex = 7
        Me.lblWinddir.Text = "Wind Direction"
        '
        'lblDPT
        '
        Me.lblDPT.AutoSize = True
        Me.lblDPT.Location = New System.Drawing.Point(40, 192)
        Me.lblDPT.Name = "lblDPT"
        Me.lblDPT.Size = New System.Drawing.Size(119, 13)
        Me.lblDPT.TabIndex = 6
        Me.lblDPT.Text = "Dew Point Temperature"
        '
        'lblDBT
        '
        Me.lblDBT.AutoSize = True
        Me.lblDBT.Location = New System.Drawing.Point(40, 166)
        Me.lblDBT.Name = "lblDBT"
        Me.lblDBT.Size = New System.Drawing.Size(110, 13)
        Me.lblDBT.TabIndex = 5
        Me.lblDBT.Text = "Dry Bulb Temperature"
        '
        'lblGeop
        '
        Me.lblGeop.AutoSize = True
        Me.lblGeop.Location = New System.Drawing.Point(40, 140)
        Me.lblGeop.Name = "lblGeop"
        Me.lblGeop.Size = New System.Drawing.Size(95, 13)
        Me.lblGeop.TabIndex = 4
        Me.lblGeop.Text = "Geoptential Height"
        '
        'lblPress
        '
        Me.lblPress.AutoSize = True
        Me.lblPress.Location = New System.Drawing.Point(39, 114)
        Me.lblPress.Name = "lblPress"
        Me.lblPress.Size = New System.Drawing.Size(48, 13)
        Me.lblPress.TabIndex = 3
        Me.lblPress.Text = "Pressure"
        '
        'lblLonDisp
        '
        Me.lblLonDisp.AutoSize = True
        Me.lblLonDisp.Location = New System.Drawing.Point(40, 88)
        Me.lblLonDisp.Name = "lblLonDisp"
        Me.lblLonDisp.Size = New System.Drawing.Size(148, 13)
        Me.lblLonDisp.TabIndex = 2
        Me.lblLonDisp.Text = "Longitude Displacement (deg)"
        '
        'lblLatdisp
        '
        Me.lblLatdisp.AutoSize = True
        Me.lblLatdisp.Location = New System.Drawing.Point(40, 62)
        Me.lblLatdisp.Name = "lblLatdisp"
        Me.lblLatdisp.Size = New System.Drawing.Size(139, 13)
        Me.lblLatdisp.TabIndex = 1
        Me.lblLatdisp.Text = "Latitude Displacement (deg)"
        '
        'lblTimeDisp
        '
        Me.lblTimeDisp.AutoSize = True
        Me.lblTimeDisp.Location = New System.Drawing.Point(40, 36)
        Me.lblTimeDisp.Name = "lblTimeDisp"
        Me.lblTimeDisp.Size = New System.Drawing.Size(123, 13)
        Me.lblTimeDisp.TabIndex = 0
        Me.lblTimeDisp.Text = "Time Displacement (sec)"
        '
        'pnlConmmand
        '
        Me.pnlConmmand.Controls.Add(Me.btnPush)
        Me.pnlConmmand.Controls.Add(Me.chkRepeatEntry)
        Me.pnlConmmand.Controls.Add(Me.btnView)
        Me.pnlConmmand.Controls.Add(Me.btnUpload)
        Me.pnlConmmand.Controls.Add(Me.Label5)
        Me.pnlConmmand.Controls.Add(Me.txtSequencer)
        Me.pnlConmmand.Controls.Add(Me.btnHelp)
        Me.pnlConmmand.Controls.Add(Me.btnClear)
        Me.pnlConmmand.Controls.Add(Me.btnCommit)
        Me.pnlConmmand.Controls.Add(Me.btnDelete)
        Me.pnlConmmand.Controls.Add(Me.btnAddNew)
        Me.pnlConmmand.Controls.Add(Me.btnUpdate)
        Me.pnlConmmand.Controls.Add(Me.btnMovePrevious)
        Me.pnlConmmand.Controls.Add(Me.btnMoveFirst)
        Me.pnlConmmand.Controls.Add(Me.btnMoveLast)
        Me.pnlConmmand.Controls.Add(Me.recNumberTextBox)
        Me.pnlConmmand.Controls.Add(Me.btnMoveNext)
        Me.pnlConmmand.Controls.Add(Me.btnClose)
        Me.pnlConmmand.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlConmmand.Location = New System.Drawing.Point(0, 517)
        Me.pnlConmmand.Name = "pnlConmmand"
        Me.pnlConmmand.Size = New System.Drawing.Size(690, 114)
        Me.pnlConmmand.TabIndex = 681
        '
        'chkRepeatEntry
        '
        Me.chkRepeatEntry.AutoSize = True
        Me.chkRepeatEntry.Enabled = False
        Me.chkRepeatEntry.Location = New System.Drawing.Point(12, 84)
        Me.chkRepeatEntry.Name = "chkRepeatEntry"
        Me.chkRepeatEntry.Size = New System.Drawing.Size(139, 17)
        Me.chkRepeatEntry.TabIndex = 27
        Me.chkRepeatEntry.Text = "Repeat Key Entry Mode"
        Me.chkRepeatEntry.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(383, 41)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 21
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(575, 81)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 26
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(179, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Sequencer"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label5.Visible = False
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(266, 82)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 28
        Me.txtSequencer.Text = "seq_month_day_level"
        Me.txtSequencer.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(608, 41)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 25
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(308, 41)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 23
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(83, 41)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 18
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(233, 41)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 22
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(8, 41)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 19
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(158, 41)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 20
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(208, 12)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 692
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(161, 12)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 691
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(451, 12)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 690
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(260, 14)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 689
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(407, 12)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 688
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(533, 41)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPush
        '
        Me.btnPush.Location = New System.Drawing.Point(458, 41)
        Me.btnPush.Name = "btnPush"
        Me.btnPush.Size = New System.Drawing.Size(75, 23)
        Me.btnPush.TabIndex = 1189
        Me.btnPush.Text = "Push"
        Me.btnPush.UseVisualStyleBackColor = True
        '
        'formUpperAir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 631)
        Me.Controls.Add(Me.pnlConmmand)
        Me.Controls.Add(Me.grpData)
        Me.Controls.Add(Me.grpHeaders)
        Me.KeyPreview = True
        Me.Name = "formUpperAir"
        Me.Text = "Upper air Observations"
        Me.grpHeaders.ResumeLayout(False)
        Me.grpHeaders.PerformLayout()
        Me.grpData.ResumeLayout(False)
        Me.grpData.PerformLayout()
        Me.pnlConmmand.ResumeLayout(False)
        Me.pnlConmmand.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpHeaders As GroupBox
    Friend WithEvents cboHour As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents lblLevel As Label
    Friend WithEvents lblHour As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lbStation As Label
    Friend WithEvents grpData As GroupBox
    Friend WithEvents cboLevel As ComboBox
    Friend WithEvents pnlConmmand As Panel
    Friend WithEvents chkRepeatEntry As CheckBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCommit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnMovePrevious As Button
    Friend WithEvents btnMoveFirst As Button
    Friend WithEvents btnMoveLast As Button
    Friend WithEvents recNumberTextBox As TextBox
    Friend WithEvents btnMoveNext As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblVerSig As Label
    Friend WithEvents lblWindShrA As Label
    Friend WithEvents lblWindShrB As Label
    Friend WithEvents lblWindspd As Label
    Friend WithEvents lblWinddir As Label
    Friend WithEvents lblDPT As Label
    Friend WithEvents lblDBT As Label
    Friend WithEvents lblGeop As Label
    Friend WithEvents lblPress As Label
    Friend WithEvents lblLonDisp As Label
    Friend WithEvents lblLatdisp As Label
    Friend WithEvents lblTimeDisp As Label
    Friend WithEvents txtFlag309Field020 As TextBox
    Friend WithEvents txtVal_Elem309Field007 As TextBox
    Friend WithEvents lblFlag As Label
    Friend WithEvents lblValue As Label
    Friend WithEvents txtFlag311Field019 As TextBox
    Friend WithEvents txtVal_Elem311Field006 As TextBox
    Friend WithEvents txtVal_Elem312Field018 As TextBox
    Friend WithEvents txtFlag312Field031 As TextBox
    Friend WithEvents txtFlag308Field030 As TextBox
    Friend WithEvents txtVal_Elem308Field017 As TextBox
    Friend WithEvents txtFlag307Field029 As TextBox
    Friend WithEvents txtVal_Elem307Field016 As TextBox
    Friend WithEvents txtFlag306Field028 As TextBox
    Friend WithEvents txtVal_Elem306Field015 As TextBox
    Friend WithEvents txtFlag305Field027 As TextBox
    Friend WithEvents txtVal_Elem305Field014 As TextBox
    Friend WithEvents txtFlag304Field025 As TextBox
    Friend WithEvents txtVal_Elem304Field012 As TextBox
    Friend WithEvents txtFlag303Field024 As TextBox
    Friend WithEvents txtVal_Elem303Field011 As TextBox
    Friend WithEvents txtFlag302Field023 As TextBox
    Friend WithEvents txtVal_Elem302Field010 As TextBox
    Friend WithEvents txtFlag301Field022 As TextBox
    Friend WithEvents txtVal_Elem301Field009 As TextBox
    Friend WithEvents txtFlag310Field021 As TextBox
    Friend WithEvents txtVal_Elem310Field008 As TextBox
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents txtFlag313Field026 As TextBox
    Friend WithEvents txtVal_Elem313Field013 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPush As Button
End Class
