<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSynopTDCF
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
        Dim lblYYYY As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim ListViewGroup10 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("No", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup11 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("lstIDs", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup12 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ID", System.Windows.Forms.HorizontalAlignment.Left)
        Me.TabProcessing = New System.Windows.Forms.TabControl()
        Me.TabBUFR = New System.Windows.Forms.TabPage()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.txtMsgbFile = New System.Windows.Forms.TextBox()
        Me.grpBinaryMessage = New System.Windows.Forms.GroupBox()
        Me.txtEncoded = New System.Windows.Forms.TextBox()
        Me.grpObsHeaders = New System.Windows.Forms.GroupBox()
        Me.srcTable = New System.Windows.Forms.Label()
        Me.lblBBB = New System.Windows.Forms.Label()
        Me.cboBBB = New System.Windows.Forms.ComboBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.lblHH = New System.Windows.Forms.Label()
        Me.lblDD = New System.Windows.Forms.Label()
        Me.lblMM = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.cboHour = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblEncodedFile = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdViewDecsriptors = New System.Windows.Forms.Button()
        Me.cmdEncode = New System.Windows.Forms.Button()
        Me.TabCSV = New System.Windows.Forms.TabPage()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnEncode = New System.Windows.Forms.Button()
        Me.grpRecords = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblStations = New System.Windows.Forms.Label()
        Me.cboStations = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboMonths = New System.Windows.Forms.ComboBox()
        Me.cboDays = New System.Windows.Forms.ComboBox()
        Me.cboHours = New System.Windows.Forms.ComboBox()
        Me.txtYears = New System.Windows.Forms.TextBox()
        Me.TabSettings = New System.Windows.Forms.TabPage()
        Me.grpCSV = New System.Windows.Forms.GroupBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grpMsgSwitch = New System.Windows.Forms.GroupBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.txtFolder = New System.Windows.Forms.TextBox()
        Me.cboFTP = New System.Windows.Forms.ComboBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.lblConfirmPassword = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.lblTransferMode = New System.Windows.Forms.Label()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.grpBUFR = New System.Windows.Forms.GroupBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTemplate = New System.Windows.Forms.ComboBox()
        Me.txtMsgHeader = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpIndicators = New System.Windows.Forms.GroupBox()
        Me.lblInternationalDataSubCategory = New System.Windows.Forms.Label()
        Me.cmdUpadate = New System.Windows.Forms.Button()
        Me.txtLocalTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblLocalTableVersionNumber = New System.Windows.Forms.Label()
        Me.chkOptionalSectionInclusion = New System.Windows.Forms.CheckBox()
        Me.lblMastersTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtMastersTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.lblLocalDataSubCateory = New System.Windows.Forms.Label()
        Me.txtLocalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.txtInternationalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.lblDataCategory = New System.Windows.Forms.Label()
        Me.txtDataCategory = New System.Windows.Forms.TextBox()
        Me.lblOptionalSectionInclusion = New System.Windows.Forms.Label()
        Me.txtUpdateSequenceNumber = New System.Windows.Forms.TextBox()
        Me.lblUpdateSequenceNumber = New System.Windows.Forms.Label()
        Me.lblOriginatingGeneratingSubCentre = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingSubCentre = New System.Windows.Forms.TextBox()
        Me.lblOriginatingOriginatingCentre = New System.Windows.Forms.Label()
        Me.txtOriginatingGeneratingCentre = New System.Windows.Forms.TextBox()
        Me.lblBUFREditionNumber = New System.Windows.Forms.Label()
        Me.txtBUFREditionNumber = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblBinaryBox = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.TabHelp = New System.Windows.Forms.TabPage()
        lblYYYY = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Me.TabProcessing.SuspendLayout()
        Me.TabBUFR.SuspendLayout()
        Me.grpBinaryMessage.SuspendLayout()
        Me.grpObsHeaders.SuspendLayout()
        Me.TabCSV.SuspendLayout()
        Me.grpRecords.SuspendLayout()
        Me.TabSettings.SuspendLayout()
        Me.grpCSV.SuspendLayout()
        Me.grpMsgSwitch.SuspendLayout()
        Me.grpBUFR.SuspendLayout()
        Me.grpIndicators.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblYYYY
        '
        lblYYYY.AutoSize = True
        lblYYYY.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblYYYY.Location = New System.Drawing.Point(137, 58)
        lblYYYY.Name = "lblYYYY"
        lblYYYY.Size = New System.Drawing.Size(32, 13)
        lblYYYY.TabIndex = 209
        lblYYYY.Text = "Year:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label10.Location = New System.Drawing.Point(137, 58)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(32, 13)
        Label10.TabIndex = 209
        Label10.Text = "Year:"
        '
        'TabProcessing
        '
        Me.TabProcessing.Controls.Add(Me.TabBUFR)
        Me.TabProcessing.Controls.Add(Me.TabCSV)
        Me.TabProcessing.Controls.Add(Me.TabSettings)
        Me.TabProcessing.Controls.Add(Me.TabHelp)
        Me.TabProcessing.Location = New System.Drawing.Point(-5, 2)
        Me.TabProcessing.Name = "TabProcessing"
        Me.TabProcessing.SelectedIndex = 0
        Me.TabProcessing.Size = New System.Drawing.Size(956, 487)
        Me.TabProcessing.TabIndex = 0
        '
        'TabBUFR
        '
        Me.TabBUFR.Controls.Add(Me.cmdSend)
        Me.TabBUFR.Controls.Add(Me.txtMsgbFile)
        Me.TabBUFR.Controls.Add(Me.grpBinaryMessage)
        Me.TabBUFR.Controls.Add(Me.grpObsHeaders)
        Me.TabBUFR.Controls.Add(Me.lblEncodedFile)
        Me.TabBUFR.Controls.Add(Me.cmdClose)
        Me.TabBUFR.Controls.Add(Me.cmdViewDecsriptors)
        Me.TabBUFR.Controls.Add(Me.cmdEncode)
        Me.TabBUFR.Location = New System.Drawing.Point(4, 22)
        Me.TabBUFR.Name = "TabBUFR"
        Me.TabBUFR.Padding = New System.Windows.Forms.Padding(3)
        Me.TabBUFR.Size = New System.Drawing.Size(948, 461)
        Me.TabBUFR.TabIndex = 0
        Me.TabBUFR.Text = "BUFR"
        Me.TabBUFR.UseVisualStyleBackColor = True
        '
        'cmdSend
        '
        Me.cmdSend.Location = New System.Drawing.Point(375, 424)
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Size = New System.Drawing.Size(83, 22)
        Me.cmdSend.TabIndex = 10
        Me.cmdSend.Text = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'txtMsgbFile
        '
        Me.txtMsgbFile.Location = New System.Drawing.Point(131, 380)
        Me.txtMsgbFile.Name = "txtMsgbFile"
        Me.txtMsgbFile.Size = New System.Drawing.Size(720, 20)
        Me.txtMsgbFile.TabIndex = 9
        '
        'grpBinaryMessage
        '
        Me.grpBinaryMessage.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpBinaryMessage.Controls.Add(Me.txtEncoded)
        Me.grpBinaryMessage.Location = New System.Drawing.Point(13, 102)
        Me.grpBinaryMessage.Name = "grpBinaryMessage"
        Me.grpBinaryMessage.Size = New System.Drawing.Size(838, 272)
        Me.grpBinaryMessage.TabIndex = 8
        Me.grpBinaryMessage.TabStop = False
        Me.grpBinaryMessage.Text = "Binary Message"
        '
        'txtEncoded
        '
        Me.txtEncoded.Location = New System.Drawing.Point(6, 19)
        Me.txtEncoded.Multiline = True
        Me.txtEncoded.Name = "txtEncoded"
        Me.txtEncoded.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEncoded.Size = New System.Drawing.Size(826, 247)
        Me.txtEncoded.TabIndex = 1
        '
        'grpObsHeaders
        '
        Me.grpObsHeaders.BackColor = System.Drawing.Color.Gainsboro
        Me.grpObsHeaders.Controls.Add(Me.srcTable)
        Me.grpObsHeaders.Controls.Add(Me.lblBBB)
        Me.grpObsHeaders.Controls.Add(Me.cboBBB)
        Me.grpObsHeaders.Controls.Add(Me.lblStation)
        Me.grpObsHeaders.Controls.Add(Me.cboStation)
        Me.grpObsHeaders.Controls.Add(Me.lblHH)
        Me.grpObsHeaders.Controls.Add(Me.lblDD)
        Me.grpObsHeaders.Controls.Add(Me.lblMM)
        Me.grpObsHeaders.Controls.Add(Me.cboMonth)
        Me.grpObsHeaders.Controls.Add(Me.cboDay)
        Me.grpObsHeaders.Controls.Add(Me.cboHour)
        Me.grpObsHeaders.Controls.Add(lblYYYY)
        Me.grpObsHeaders.Controls.Add(Me.txtYear)
        Me.grpObsHeaders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpObsHeaders.Location = New System.Drawing.Point(11, 11)
        Me.grpObsHeaders.Name = "grpObsHeaders"
        Me.grpObsHeaders.Size = New System.Drawing.Size(840, 85)
        Me.grpObsHeaders.TabIndex = 7
        Me.grpObsHeaders.TabStop = False
        Me.grpObsHeaders.Text = "Observation Headers"
        '
        'srcTable
        '
        Me.srcTable.AutoSize = True
        Me.srcTable.Location = New System.Drawing.Point(686, 31)
        Me.srcTable.Name = "srcTable"
        Me.srcTable.Size = New System.Drawing.Size(0, 13)
        Me.srcTable.TabIndex = 217
        Me.srcTable.Visible = False
        '
        'lblBBB
        '
        Me.lblBBB.AutoSize = True
        Me.lblBBB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBBB.Location = New System.Drawing.Point(517, 57)
        Me.lblBBB.Name = "lblBBB"
        Me.lblBBB.Size = New System.Drawing.Size(28, 13)
        Me.lblBBB.TabIndex = 216
        Me.lblBBB.Tag = "BBB"
        Me.lblBBB.Text = "BBB"
        '
        'cboBBB
        '
        Me.cboBBB.FormattingEnabled = True
        Me.cboBBB.Location = New System.Drawing.Point(549, 53)
        Me.cboBBB.Name = "cboBBB"
        Me.cboBBB.Size = New System.Drawing.Size(112, 21)
        Me.cboBBB.TabIndex = 215
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStation.Location = New System.Drawing.Point(135, 26)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 214
        Me.lblStation.Text = "Station"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Location = New System.Drawing.Point(181, 22)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(480, 21)
        Me.cboStation.TabIndex = 205
        '
        'lblHH
        '
        Me.lblHH.AutoSize = True
        Me.lblHH.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHH.Location = New System.Drawing.Point(429, 58)
        Me.lblHH.Name = "lblHH"
        Me.lblHH.Size = New System.Drawing.Size(33, 13)
        Me.lblHH.TabIndex = 213
        Me.lblHH.Text = "Hour:"
        '
        'lblDD
        '
        Me.lblDD.AutoSize = True
        Me.lblDD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDD.Location = New System.Drawing.Point(341, 58)
        Me.lblDD.Name = "lblDD"
        Me.lblDD.Size = New System.Drawing.Size(29, 13)
        Me.lblDD.TabIndex = 212
        Me.lblDD.Text = "Day:"
        '
        'lblMM
        '
        Me.lblMM.AutoSize = True
        Me.lblMM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMM.Location = New System.Drawing.Point(241, 58)
        Me.lblMM.Name = "lblMM"
        Me.lblMM.Size = New System.Drawing.Size(40, 13)
        Me.lblMM.TabIndex = 211
        Me.lblMM.Text = "Month:"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(285, 54)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(41, 21)
        Me.cboMonth.TabIndex = 207
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(374, 54)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(39, 21)
        Me.cboDay.TabIndex = 208
        '
        'cboHour
        '
        Me.cboHour.FormattingEnabled = True
        Me.cboHour.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", ""})
        Me.cboHour.Location = New System.Drawing.Point(466, 54)
        Me.cboHour.Name = "cboHour"
        Me.cboHour.Size = New System.Drawing.Size(39, 21)
        Me.cboHour.TabIndex = 210
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(181, 54)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(40, 20)
        Me.txtYear.TabIndex = 206
        '
        'lblEncodedFile
        '
        Me.lblEncodedFile.AutoSize = True
        Me.lblEncodedFile.Location = New System.Drawing.Point(8, 385)
        Me.lblEncodedFile.Name = "lblEncodedFile"
        Me.lblEncodedFile.Size = New System.Drawing.Size(115, 13)
        Me.lblEncodedFile.TabIndex = 5
        Me.lblEncodedFile.Text = "Encoded Message File"
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(479, 424)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(72, 23)
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdViewDecsriptors
        '
        Me.cmdViewDecsriptors.Enabled = False
        Me.cmdViewDecsriptors.Location = New System.Drawing.Point(249, 423)
        Me.cmdViewDecsriptors.Name = "cmdViewDecsriptors"
        Me.cmdViewDecsriptors.Size = New System.Drawing.Size(106, 23)
        Me.cmdViewDecsriptors.TabIndex = 1
        Me.cmdViewDecsriptors.Text = "View Descriptors"
        Me.cmdViewDecsriptors.UseVisualStyleBackColor = True
        '
        'cmdEncode
        '
        Me.cmdEncode.Location = New System.Drawing.Point(138, 424)
        Me.cmdEncode.Name = "cmdEncode"
        Me.cmdEncode.Size = New System.Drawing.Size(81, 23)
        Me.cmdEncode.TabIndex = 0
        Me.cmdEncode.Text = "Encode"
        Me.cmdEncode.UseVisualStyleBackColor = True
        '
        'TabCSV
        '
        Me.TabCSV.Controls.Add(Me.btnSend)
        Me.TabCSV.Controls.Add(Me.btnClose)
        Me.TabCSV.Controls.Add(Me.btnView)
        Me.TabCSV.Controls.Add(Me.btnEncode)
        Me.TabCSV.Controls.Add(Me.grpRecords)
        Me.TabCSV.Location = New System.Drawing.Point(4, 22)
        Me.TabCSV.Name = "TabCSV"
        Me.TabCSV.Size = New System.Drawing.Size(948, 461)
        Me.TabCSV.TabIndex = 3
        Me.TabCSV.Text = "CSV4WIS2BOX"
        Me.TabCSV.UseVisualStyleBackColor = True
        '
        'btnSend
        '
        Me.btnSend.Enabled = False
        Me.btnSend.Location = New System.Drawing.Point(495, 407)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(111, 22)
        Me.btnSend.TabIndex = 14
        Me.btnSend.Text = "Send to WIS2"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(601, 407)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Enabled = False
        Me.btnView.Location = New System.Drawing.Point(369, 406)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(106, 23)
        Me.btnView.TabIndex = 12
        Me.btnView.Text = "View CSV File"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnEncode
        '
        Me.btnEncode.Location = New System.Drawing.Point(223, 407)
        Me.btnEncode.Name = "btnEncode"
        Me.btnEncode.Size = New System.Drawing.Size(116, 23)
        Me.btnEncode.TabIndex = 11
        Me.btnEncode.Text = "Create CSV for WIS2"
        Me.btnEncode.UseVisualStyleBackColor = True
        '
        'grpRecords
        '
        Me.grpRecords.BackColor = System.Drawing.Color.Gainsboro
        Me.grpRecords.Controls.Add(Me.Label2)
        Me.grpRecords.Controls.Add(Me.lblStations)
        Me.grpRecords.Controls.Add(Me.cboStations)
        Me.grpRecords.Controls.Add(Me.Label6)
        Me.grpRecords.Controls.Add(Me.Label8)
        Me.grpRecords.Controls.Add(Me.Label9)
        Me.grpRecords.Controls.Add(Me.cboMonths)
        Me.grpRecords.Controls.Add(Me.cboDays)
        Me.grpRecords.Controls.Add(Me.cboHours)
        Me.grpRecords.Controls.Add(Label10)
        Me.grpRecords.Controls.Add(Me.txtYears)
        Me.grpRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRecords.Location = New System.Drawing.Point(51, 10)
        Me.grpRecords.Name = "grpRecords"
        Me.grpRecords.Size = New System.Drawing.Size(840, 85)
        Me.grpRecords.TabIndex = 8
        Me.grpRecords.TabStop = False
        Me.grpRecords.Text = "Stations"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(686, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 217
        Me.Label2.Visible = False
        '
        'lblStations
        '
        Me.lblStations.AutoSize = True
        Me.lblStations.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStations.Location = New System.Drawing.Point(135, 26)
        Me.lblStations.Name = "lblStations"
        Me.lblStations.Size = New System.Drawing.Size(40, 13)
        Me.lblStations.TabIndex = 214
        Me.lblStations.Text = "Station"
        '
        'cboStations
        '
        Me.cboStations.FormattingEnabled = True
        Me.cboStations.Location = New System.Drawing.Point(181, 22)
        Me.cboStations.Name = "cboStations"
        Me.cboStations.Size = New System.Drawing.Size(480, 21)
        Me.cboStations.TabIndex = 205
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(429, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Hour:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(341, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 212
        Me.Label8.Text = "Day:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(241, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 211
        Me.Label9.Text = "Month:"
        '
        'cboMonths
        '
        Me.cboMonths.FormattingEnabled = True
        Me.cboMonths.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonths.Location = New System.Drawing.Point(285, 54)
        Me.cboMonths.Name = "cboMonths"
        Me.cboMonths.Size = New System.Drawing.Size(41, 21)
        Me.cboMonths.TabIndex = 207
        '
        'cboDays
        '
        Me.cboDays.FormattingEnabled = True
        Me.cboDays.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDays.Location = New System.Drawing.Point(374, 54)
        Me.cboDays.Name = "cboDays"
        Me.cboDays.Size = New System.Drawing.Size(39, 21)
        Me.cboDays.TabIndex = 208
        '
        'cboHours
        '
        Me.cboHours.FormattingEnabled = True
        Me.cboHours.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", ""})
        Me.cboHours.Location = New System.Drawing.Point(466, 54)
        Me.cboHours.Name = "cboHours"
        Me.cboHours.Size = New System.Drawing.Size(39, 21)
        Me.cboHours.TabIndex = 210
        '
        'txtYears
        '
        Me.txtYears.Location = New System.Drawing.Point(181, 54)
        Me.txtYears.Name = "txtYears"
        Me.txtYears.Size = New System.Drawing.Size(40, 20)
        Me.txtYears.TabIndex = 206
        '
        'TabSettings
        '
        Me.TabSettings.Controls.Add(Me.grpCSV)
        Me.TabSettings.Controls.Add(Me.grpMsgSwitch)
        Me.TabSettings.Controls.Add(Me.grpBUFR)
        Me.TabSettings.Controls.Add(Me.grpIndicators)
        Me.TabSettings.Controls.Add(Me.lblBinaryBox)
        Me.TabSettings.Controls.Add(Me.cmdCancel)
        Me.TabSettings.Location = New System.Drawing.Point(4, 22)
        Me.TabSettings.Name = "TabSettings"
        Me.TabSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.TabSettings.Size = New System.Drawing.Size(948, 461)
        Me.TabSettings.TabIndex = 1
        Me.TabSettings.Text = "Settings"
        Me.TabSettings.UseVisualStyleBackColor = True
        '
        'grpCSV
        '
        Me.grpCSV.BackColor = System.Drawing.Color.Gainsboro
        Me.grpCSV.Controls.Add(Me.ListView1)
        Me.grpCSV.Controls.Add(Me.Label4)
        Me.grpCSV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCSV.Location = New System.Drawing.Point(255, 21)
        Me.grpCSV.Name = "grpCSV"
        Me.grpCSV.Size = New System.Drawing.Size(290, 407)
        Me.grpCSV.TabIndex = 18
        Me.grpCSV.TabStop = False
        Me.grpCSV.Text = "CSV for WIS2BOX"
        '
        'ListView1
        '
        Me.ListView1.GridLines = True
        ListViewGroup10.Header = "No"
        ListViewGroup10.Name = "lstNo"
        ListViewGroup11.Header = "lstIDs"
        ListViewGroup11.Name = "ID"
        ListViewGroup12.Header = "ID"
        ListViewGroup12.Name = "Element Abbrev"
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup10, ListViewGroup11, ListViewGroup12})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(20, 27)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(260, 341)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(988, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Tag = "Template"
        Me.Label4.Text = "Template"
        '
        'grpMsgSwitch
        '
        Me.grpMsgSwitch.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpMsgSwitch.Controls.Add(Me.lblPort)
        Me.grpMsgSwitch.Controls.Add(Me.txtPort)
        Me.grpMsgSwitch.Controls.Add(Me.cmdUpdate)
        Me.grpMsgSwitch.Controls.Add(Me.txtConfirmPassword)
        Me.grpMsgSwitch.Controls.Add(Me.txtPassword)
        Me.grpMsgSwitch.Controls.Add(Me.txtLogin)
        Me.grpMsgSwitch.Controls.Add(Me.txtFolder)
        Me.grpMsgSwitch.Controls.Add(Me.cboFTP)
        Me.grpMsgSwitch.Controls.Add(Me.txtServer)
        Me.grpMsgSwitch.Controls.Add(Me.lblConfirmPassword)
        Me.grpMsgSwitch.Controls.Add(Me.lblPassword)
        Me.grpMsgSwitch.Controls.Add(Me.lblLogin)
        Me.grpMsgSwitch.Controls.Add(Me.lblFolder)
        Me.grpMsgSwitch.Controls.Add(Me.lblTransferMode)
        Me.grpMsgSwitch.Controls.Add(Me.lblServer)
        Me.grpMsgSwitch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMsgSwitch.Location = New System.Drawing.Point(551, 14)
        Me.grpMsgSwitch.Name = "grpMsgSwitch"
        Me.grpMsgSwitch.Size = New System.Drawing.Size(394, 241)
        Me.grpMsgSwitch.TabIndex = 17
        Me.grpMsgSwitch.TabStop = False
        Me.grpMsgSwitch.Text = "Message Switch/WIS Node Details"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPort.Location = New System.Drawing.Point(203, 63)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 14
        Me.lblPort.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(235, 61)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(51, 20)
        Me.txtPort.TabIndex = 13
        Me.txtPort.Text = "21"
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(100, 208)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(103, 22)
        Me.cmdUpdate.TabIndex = 12
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(110, 182)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtConfirmPassword.TabIndex = 11
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(110, 152)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(157, 20)
        Me.txtPassword.TabIndex = 10
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(110, 122)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(157, 20)
        Me.txtLogin.TabIndex = 9
        '
        'txtFolder
        '
        Me.txtFolder.Location = New System.Drawing.Point(110, 92)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New System.Drawing.Size(258, 20)
        Me.txtFolder.TabIndex = 8
        '
        'cboFTP
        '
        Me.cboFTP.FormattingEnabled = True
        Me.cboFTP.Items.AddRange(New Object() {"FTP", "SFTP"})
        Me.cboFTP.Location = New System.Drawing.Point(110, 61)
        Me.cboFTP.Name = "cboFTP"
        Me.cboFTP.Size = New System.Drawing.Size(78, 21)
        Me.cboFTP.TabIndex = 7
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(110, 31)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(278, 20)
        Me.txtServer.TabIndex = 6
        '
        'lblConfirmPassword
        '
        Me.lblConfirmPassword.AutoSize = True
        Me.lblConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPassword.Location = New System.Drawing.Point(12, 182)
        Me.lblConfirmPassword.Name = "lblConfirmPassword"
        Me.lblConfirmPassword.Size = New System.Drawing.Size(91, 13)
        Me.lblConfirmPassword.TabIndex = 5
        Me.lblConfirmPassword.Text = "Confirm Password"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(12, 152)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password"
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(12, 122)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(60, 13)
        Me.lblLogin.TabIndex = 3
        Me.lblLogin.Text = "User Name"
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolder.Location = New System.Drawing.Point(12, 92)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(63, 13)
        Me.lblFolder.TabIndex = 2
        Me.lblFolder.Text = "Input Folder"
        '
        'lblTransferMode
        '
        Me.lblTransferMode.AutoSize = True
        Me.lblTransferMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransferMode.Location = New System.Drawing.Point(12, 61)
        Me.lblTransferMode.Name = "lblTransferMode"
        Me.lblTransferMode.Size = New System.Drawing.Size(57, 13)
        Me.lblTransferMode.TabIndex = 1
        Me.lblTransferMode.Text = "FTP Mode"
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServer.Location = New System.Drawing.Point(12, 31)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(79, 13)
        Me.lblServer.TabIndex = 0
        Me.lblServer.Text = "Server Address"
        '
        'grpBUFR
        '
        Me.grpBUFR.BackColor = System.Drawing.Color.Gainsboro
        Me.grpBUFR.Controls.Add(Me.lblHeader)
        Me.grpBUFR.Controls.Add(Me.Label1)
        Me.grpBUFR.Controls.Add(Me.cboTemplate)
        Me.grpBUFR.Controls.Add(Me.txtMsgHeader)
        Me.grpBUFR.Controls.Add(Me.Label7)
        Me.grpBUFR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBUFR.Location = New System.Drawing.Point(11, 21)
        Me.grpBUFR.Name = "grpBUFR"
        Me.grpBUFR.Size = New System.Drawing.Size(238, 88)
        Me.grpBUFR.TabIndex = 14
        Me.grpBUFR.TabStop = False
        Me.grpBUFR.Text = "BUFR"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(6, 61)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(91, 13)
        Me.lblHeader.TabIndex = 5
        Me.lblHeader.Tag = "Header"
        Me.lblHeader.Text = "Message Header "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = "Template"
        Me.Label1.Text = "Template"
        '
        'cboTemplate
        '
        Me.cboTemplate.FormattingEnabled = True
        Me.cboTemplate.Location = New System.Drawing.Point(62, 24)
        Me.cboTemplate.Name = "cboTemplate"
        Me.cboTemplate.Size = New System.Drawing.Size(151, 21)
        Me.cboTemplate.TabIndex = 3
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(101, 57)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(100, 20)
        Me.txtMsgHeader.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(988, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Tag = "Template"
        Me.Label7.Text = "Template"
        '
        'grpIndicators
        '
        Me.grpIndicators.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpIndicators.Controls.Add(Me.lblInternationalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.cmdUpadate)
        Me.grpIndicators.Controls.Add(Me.txtLocalTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.lblLocalTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.chkOptionalSectionInclusion)
        Me.grpIndicators.Controls.Add(Me.lblMastersTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtMastersTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.cmdNew)
        Me.grpIndicators.Controls.Add(Me.lblLocalDataSubCateory)
        Me.grpIndicators.Controls.Add(Me.txtLocalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.txtInternationalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.lblDataCategory)
        Me.grpIndicators.Controls.Add(Me.txtDataCategory)
        Me.grpIndicators.Controls.Add(Me.lblOptionalSectionInclusion)
        Me.grpIndicators.Controls.Add(Me.txtUpdateSequenceNumber)
        Me.grpIndicators.Controls.Add(Me.lblUpdateSequenceNumber)
        Me.grpIndicators.Controls.Add(Me.lblOriginatingGeneratingSubCentre)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingSubCentre)
        Me.grpIndicators.Controls.Add(Me.lblOriginatingOriginatingCentre)
        Me.grpIndicators.Controls.Add(Me.txtOriginatingGeneratingCentre)
        Me.grpIndicators.Controls.Add(Me.lblBUFREditionNumber)
        Me.grpIndicators.Controls.Add(Me.txtBUFREditionNumber)
        Me.grpIndicators.Controls.Add(Me.Label44)
        Me.grpIndicators.Controls.Add(Me.Label49)
        Me.grpIndicators.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpIndicators.Location = New System.Drawing.Point(12, 111)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Size = New System.Drawing.Size(238, 321)
        Me.grpIndicators.TabIndex = 13
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Tag = "Indicators"
        Me.grpIndicators.Text = "Indicators "
        '
        'lblInternationalDataSubCategory
        '
        Me.lblInternationalDataSubCategory.AutoSize = True
        Me.lblInternationalDataSubCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternationalDataSubCategory.Location = New System.Drawing.Point(9, 184)
        Me.lblInternationalDataSubCategory.Name = "lblInternationalDataSubCategory"
        Me.lblInternationalDataSubCategory.Size = New System.Drawing.Size(161, 13)
        Me.lblInternationalDataSubCategory.TabIndex = 15
        Me.lblInternationalDataSubCategory.Tag = "Data_Category"
        Me.lblInternationalDataSubCategory.Text = "International Data Sub Category " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmdUpadate
        '
        Me.cmdUpadate.Location = New System.Drawing.Point(160, 295)
        Me.cmdUpadate.Name = "cmdUpadate"
        Me.cmdUpadate.Size = New System.Drawing.Size(94, 20)
        Me.cmdUpadate.TabIndex = 15
        Me.cmdUpadate.Text = "Update"
        Me.cmdUpadate.UseVisualStyleBackColor = True
        '
        'txtLocalTableVersionNumber
        '
        Me.txtLocalTableVersionNumber.Location = New System.Drawing.Point(184, 264)
        Me.txtLocalTableVersionNumber.Name = "txtLocalTableVersionNumber"
        Me.txtLocalTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalTableVersionNumber.TabIndex = 14
        '
        'lblLocalTableVersionNumber
        '
        Me.lblLocalTableVersionNumber.AutoSize = True
        Me.lblLocalTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalTableVersionNumber.Location = New System.Drawing.Point(9, 265)
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Size = New System.Drawing.Size(146, 13)
        Me.lblLocalTableVersionNumber.TabIndex = 11
        Me.lblLocalTableVersionNumber.Tag = "Table_Version_Number"
        Me.lblLocalTableVersionNumber.Text = "Local Tables Version Number"
        '
        'chkOptionalSectionInclusion
        '
        Me.chkOptionalSectionInclusion.AutoSize = True
        Me.chkOptionalSectionInclusion.Location = New System.Drawing.Point(184, 130)
        Me.chkOptionalSectionInclusion.Name = "chkOptionalSectionInclusion"
        Me.chkOptionalSectionInclusion.Size = New System.Drawing.Size(15, 14)
        Me.chkOptionalSectionInclusion.TabIndex = 3
        Me.chkOptionalSectionInclusion.UseVisualStyleBackColor = True
        '
        'lblMastersTableVersionNumber
        '
        Me.lblMastersTableVersionNumber.AutoSize = True
        Me.lblMastersTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMastersTableVersionNumber.Location = New System.Drawing.Point(9, 238)
        Me.lblMastersTableVersionNumber.Name = "lblMastersTableVersionNumber"
        Me.lblMastersTableVersionNumber.Size = New System.Drawing.Size(152, 13)
        Me.lblMastersTableVersionNumber.TabIndex = 1
        Me.lblMastersTableVersionNumber.Tag = "Masters_Table_Version_Number"
        Me.lblMastersTableVersionNumber.Text = "Masters Table Version Number"
        '
        'txtMastersTableVersionNumber
        '
        Me.txtMastersTableVersionNumber.Location = New System.Drawing.Point(184, 236)
        Me.txtMastersTableVersionNumber.Name = "txtMastersTableVersionNumber"
        Me.txtMastersTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtMastersTableVersionNumber.TabIndex = 2
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(21, 295)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(94, 20)
        Me.cmdNew.TabIndex = 0
        Me.cmdNew.Text = "AddNew"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'lblLocalDataSubCateory
        '
        Me.lblLocalDataSubCateory.AutoSize = True
        Me.lblLocalDataSubCateory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalDataSubCateory.Location = New System.Drawing.Point(9, 211)
        Me.lblLocalDataSubCateory.Name = "lblLocalDataSubCateory"
        Me.lblLocalDataSubCateory.Size = New System.Drawing.Size(126, 13)
        Me.lblLocalDataSubCateory.TabIndex = 1
        Me.lblLocalDataSubCateory.Tag = "Local_Data_Sub_Cateory"
        Me.lblLocalDataSubCateory.Text = "Local Data Sub-Category"
        '
        'txtLocalDataSubCategory
        '
        Me.txtLocalDataSubCategory.Location = New System.Drawing.Point(184, 208)
        Me.txtLocalDataSubCategory.Name = "txtLocalDataSubCategory"
        Me.txtLocalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalDataSubCategory.TabIndex = 2
        '
        'txtInternationalDataSubCategory
        '
        Me.txtInternationalDataSubCategory.Location = New System.Drawing.Point(184, 180)
        Me.txtInternationalDataSubCategory.Name = "txtInternationalDataSubCategory"
        Me.txtInternationalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtInternationalDataSubCategory.TabIndex = 2
        '
        'lblDataCategory
        '
        Me.lblDataCategory.AutoSize = True
        Me.lblDataCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCategory.Location = New System.Drawing.Point(9, 157)
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Size = New System.Drawing.Size(78, 13)
        Me.lblDataCategory.TabIndex = 1
        Me.lblDataCategory.Tag = "Data_Category"
        Me.lblDataCategory.Text = "Data Category " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Location = New System.Drawing.Point(184, 152)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtDataCategory.TabIndex = 2
        '
        'lblOptionalSectionInclusion
        '
        Me.lblOptionalSectionInclusion.AutoSize = True
        Me.lblOptionalSectionInclusion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionalSectionInclusion.Location = New System.Drawing.Point(9, 130)
        Me.lblOptionalSectionInclusion.MaximumSize = New System.Drawing.Size(1000, 1100)
        Me.lblOptionalSectionInclusion.Name = "lblOptionalSectionInclusion"
        Me.lblOptionalSectionInclusion.Size = New System.Drawing.Size(130, 13)
        Me.lblOptionalSectionInclusion.TabIndex = 1
        Me.lblOptionalSectionInclusion.Tag = "Optional_Section_Inclusion"
        Me.lblOptionalSectionInclusion.Text = "Optional Section Inclusion"
        '
        'txtUpdateSequenceNumber
        '
        Me.txtUpdateSequenceNumber.Location = New System.Drawing.Point(184, 102)
        Me.txtUpdateSequenceNumber.Name = "txtUpdateSequenceNumber"
        Me.txtUpdateSequenceNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtUpdateSequenceNumber.TabIndex = 2
        '
        'lblUpdateSequenceNumber
        '
        Me.lblUpdateSequenceNumber.AutoSize = True
        Me.lblUpdateSequenceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateSequenceNumber.Location = New System.Drawing.Point(9, 103)
        Me.lblUpdateSequenceNumber.Name = "lblUpdateSequenceNumber"
        Me.lblUpdateSequenceNumber.Size = New System.Drawing.Size(134, 13)
        Me.lblUpdateSequenceNumber.TabIndex = 1
        Me.lblUpdateSequenceNumber.Tag = "Update_Sequence_Number"
        Me.lblUpdateSequenceNumber.Text = "Update Sequence Number"
        '
        'lblOriginatingGeneratingSubCentre
        '
        Me.lblOriginatingGeneratingSubCentre.AutoSize = True
        Me.lblOriginatingGeneratingSubCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(9, 76)
        Me.lblOriginatingGeneratingSubCentre.Name = "lblOriginatingGeneratingSubCentre"
        Me.lblOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(170, 13)
        Me.lblOriginatingGeneratingSubCentre.TabIndex = 1
        Me.lblOriginatingGeneratingSubCentre.Tag = "Originating_Generating_SubCentre"
        Me.lblOriginatingGeneratingSubCentre.Text = "Originating/Generating Sub-Centre"
        '
        'txtOriginatingGeneratingSubCentre
        '
        Me.txtOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(184, 74)
        Me.txtOriginatingGeneratingSubCentre.Name = "txtOriginatingGeneratingSubCentre"
        Me.txtOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(39, 20)
        Me.txtOriginatingGeneratingSubCentre.TabIndex = 2
        '
        'lblOriginatingOriginatingCentre
        '
        Me.lblOriginatingOriginatingCentre.AutoSize = True
        Me.lblOriginatingOriginatingCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingOriginatingCentre.Location = New System.Drawing.Point(9, 49)
        Me.lblOriginatingOriginatingCentre.Name = "lblOriginatingOriginatingCentre"
        Me.lblOriginatingOriginatingCentre.Size = New System.Drawing.Size(148, 13)
        Me.lblOriginatingOriginatingCentre.TabIndex = 1
        Me.lblOriginatingOriginatingCentre.Tag = "Originating_Generating_Centre"
        Me.lblOriginatingOriginatingCentre.Text = "Originating/Generating Centre"
        '
        'txtOriginatingGeneratingCentre
        '
        Me.txtOriginatingGeneratingCentre.Location = New System.Drawing.Point(184, 46)
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        Me.txtOriginatingGeneratingCentre.Size = New System.Drawing.Size(39, 20)
        Me.txtOriginatingGeneratingCentre.TabIndex = 2
        '
        'lblBUFREditionNumber
        '
        Me.lblBUFREditionNumber.AutoSize = True
        Me.lblBUFREditionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBUFREditionNumber.Location = New System.Drawing.Point(9, 22)
        Me.lblBUFREditionNumber.Name = "lblBUFREditionNumber"
        Me.lblBUFREditionNumber.Size = New System.Drawing.Size(110, 13)
        Me.lblBUFREditionNumber.TabIndex = 1
        Me.lblBUFREditionNumber.Tag = "BUFR_edition_Number"
        Me.lblBUFREditionNumber.Text = "BUFR edition Number"
        '
        'txtBUFREditionNumber
        '
        Me.txtBUFREditionNumber.Location = New System.Drawing.Point(185, 18)
        Me.txtBUFREditionNumber.Name = "txtBUFREditionNumber"
        Me.txtBUFREditionNumber.Size = New System.Drawing.Size(38, 20)
        Me.txtBUFREditionNumber.TabIndex = 2
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(-3, 79)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(0, 13)
        Me.Label44.TabIndex = 1
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(-3, 72)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(0, 13)
        Me.Label49.TabIndex = 1
        '
        'lblBinaryBox
        '
        Me.lblBinaryBox.AutoSize = True
        Me.lblBinaryBox.Location = New System.Drawing.Point(6, 36)
        Me.lblBinaryBox.Name = "lblBinaryBox"
        Me.lblBinaryBox.Size = New System.Drawing.Size(10, 13)
        Me.lblBinaryBox.TabIndex = 5
        Me.lblBinaryBox.Text = " "
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Location = New System.Drawing.Point(489, 435)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 20)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Close"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'TabHelp
        '
        Me.TabHelp.Location = New System.Drawing.Point(4, 22)
        Me.TabHelp.Name = "TabHelp"
        Me.TabHelp.Padding = New System.Windows.Forms.Padding(3)
        Me.TabHelp.Size = New System.Drawing.Size(948, 461)
        Me.TabHelp.TabIndex = 2
        Me.TabHelp.Text = "Help"
        Me.TabHelp.UseVisualStyleBackColor = True
        '
        'frmSynopTDCF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 493)
        Me.Controls.Add(Me.TabProcessing)
        Me.Name = "frmSynopTDCF"
        Me.Text = "TDCF BUFR Encoding"
        Me.TabProcessing.ResumeLayout(False)
        Me.TabBUFR.ResumeLayout(False)
        Me.TabBUFR.PerformLayout()
        Me.grpBinaryMessage.ResumeLayout(False)
        Me.grpBinaryMessage.PerformLayout()
        Me.grpObsHeaders.ResumeLayout(False)
        Me.grpObsHeaders.PerformLayout()
        Me.TabCSV.ResumeLayout(False)
        Me.grpRecords.ResumeLayout(False)
        Me.grpRecords.PerformLayout()
        Me.TabSettings.ResumeLayout(False)
        Me.TabSettings.PerformLayout()
        Me.grpCSV.ResumeLayout(False)
        Me.grpCSV.PerformLayout()
        Me.grpMsgSwitch.ResumeLayout(False)
        Me.grpMsgSwitch.PerformLayout()
        Me.grpBUFR.ResumeLayout(False)
        Me.grpBUFR.PerformLayout()
        Me.grpIndicators.ResumeLayout(False)
        Me.grpIndicators.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabProcessing As System.Windows.Forms.TabControl
    Friend WithEvents TabBUFR As System.Windows.Forms.TabPage
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdViewDecsriptors As System.Windows.Forms.Button
    Friend WithEvents cmdEncode As System.Windows.Forms.Button
    Friend WithEvents TabHelp As System.Windows.Forms.TabPage
    Friend WithEvents lblEncodedFile As System.Windows.Forms.Label
    Friend WithEvents TabSettings As System.Windows.Forms.TabPage
    Friend WithEvents lblBinaryBox As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents grpIndicators As System.Windows.Forms.GroupBox
    Friend WithEvents chkOptionalSectionInclusion As System.Windows.Forms.CheckBox
    Friend WithEvents lblMastersTableVersionNumber As System.Windows.Forms.Label
    Friend WithEvents txtMastersTableVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalDataSubCateory As System.Windows.Forms.Label
    Friend WithEvents txtLocalDataSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtInternationalDataSubCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblDataCategory As System.Windows.Forms.Label
    Friend WithEvents txtDataCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblOptionalSectionInclusion As System.Windows.Forms.Label
    Friend WithEvents txtUpdateSequenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblUpdateSequenceNumber As System.Windows.Forms.Label
    Friend WithEvents lblOriginatingGeneratingSubCentre As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingGeneratingSubCentre As System.Windows.Forms.TextBox
    Friend WithEvents lblOriginatingOriginatingCentre As System.Windows.Forms.Label
    Friend WithEvents txtOriginatingGeneratingCentre As System.Windows.Forms.TextBox
    Friend WithEvents lblBUFREditionNumber As System.Windows.Forms.Label
    Friend WithEvents txtBUFREditionNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblLocalTableVersionNumber As System.Windows.Forms.Label
    Friend WithEvents lblInternationalDataSubCategory As System.Windows.Forms.Label
    Friend WithEvents txtLocalTableVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents grpBUFR As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents txtMsgHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents cmdUpadate As System.Windows.Forms.Button
    Friend WithEvents grpMsgSwitch As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents txtFolder As System.Windows.Forms.TextBox
    Friend WithEvents cboFTP As System.Windows.Forms.ComboBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblFolder As System.Windows.Forms.Label
    Friend WithEvents lblTransferMode As System.Windows.Forms.Label
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents grpObsHeaders As System.Windows.Forms.GroupBox
    Friend WithEvents lblStation As System.Windows.Forms.Label
    Friend WithEvents cboStation As System.Windows.Forms.ComboBox
    Friend WithEvents lblHH As System.Windows.Forms.Label
    Friend WithEvents lblDD As System.Windows.Forms.Label
    Friend WithEvents lblMM As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cboDay As System.Windows.Forms.ComboBox
    Friend WithEvents cboHour As System.Windows.Forms.ComboBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents txtMsgbFile As System.Windows.Forms.TextBox
    Friend WithEvents grpBinaryMessage As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents lblBBB As System.Windows.Forms.Label
    Friend WithEvents cboBBB As System.Windows.Forms.ComboBox
    Friend WithEvents txtEncoded As System.Windows.Forms.TextBox
    Friend WithEvents srcTable As Label
    Friend WithEvents TabCSV As TabPage
    Friend WithEvents lblPort As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents grpCSV As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents btnSend As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnEncode As Button
    Friend WithEvents grpRecords As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblStations As Label
    Friend WithEvents cboStations As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cboMonths As ComboBox
    Friend WithEvents cboDays As ComboBox
    Friend WithEvents cboHours As ComboBox
    Friend WithEvents txtYears As TextBox
End Class
