<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBUFR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBUFR))
        Me.txtCharacterMessage = New System.Windows.Forms.TextBox()
        Me.lblInsrumentTypeWind = New System.Windows.Forms.Label()
        Me.txtInstrumentTypesWind = New System.Windows.Forms.TextBox()
        Me.lblEvaporation = New System.Windows.Forms.Label()
        Me.txtEvaporation = New System.Windows.Forms.TextBox()
        Me.lblSensorHeightWind = New System.Windows.Forms.Label()
        Me.lblPrecipitation = New System.Windows.Forms.Label()
        Me.txtSensorHeightWind = New System.Windows.Forms.TextBox()
        Me.txtPrecipitation = New System.Windows.Forms.TextBox()
        Me.lblVisibility = New System.Windows.Forms.Label()
        Me.txtVisibility = New System.Windows.Forms.TextBox()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.cmdViewImportExport = New System.Windows.Forms.Button()
        Me.cmdEncode = New System.Windows.Forms.Button()
        Me.grpCharacterMessage = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cmdSettings = New System.Windows.Forms.Button()
        Me.cmdSend = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmdSendMail = New System.Windows.Forms.Button()
        Me.lstMailApplication = New System.Windows.Forms.ListBox()
        Me.txtTo = New System.Windows.Forms.TextBox()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.lblMailApplications = New System.Windows.Forms.Label()
        Me.chkAttachUD = New System.Windows.Forms.CheckBox()
        Me.grpSendingOptions = New System.Windows.Forms.GroupBox()
        Me.lblFTP = New System.Windows.Forms.Label()
        Me.rbFTP = New System.Windows.Forms.RadioButton()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.rbEmail = New System.Windows.Forms.RadioButton()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.grpInstrumentTypes = New System.Windows.Forms.GroupBox()
        Me.lblCodedOutput = New System.Windows.Forms.Label()
        Me.txtTemperature = New System.Windows.Forms.TextBox()
        Me.cboBBB = New System.Windows.Forms.ComboBox()
        Me.txtMinute = New System.Windows.Forms.TextBox()
        Me.txtHour = New System.Windows.Forms.TextBox()
        Me.txtDay = New System.Windows.Forms.TextBox()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.txtHeader = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblMinute = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTemplate = New System.Windows.Forms.Label()
        Me.cboTemplate = New System.Windows.Forms.ComboBox()
        Me.lblBBB = New System.Windows.Forms.Label()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.lblPressure = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.lblLocalTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtLocalTablesVersionNumber = New System.Windows.Forms.TextBox()
        Me.grpSensorsHeightFromGroundM = New System.Windows.Forms.GroupBox()
        Me.txtPressure = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.grpIndicators = New System.Windows.Forms.GroupBox()
        Me.chkOptionalSequenceInclusion = New System.Windows.Forms.CheckBox()
        Me.lblMastersTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtMastersTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblLocalDataSubCateory = New System.Windows.Forms.Label()
        Me.txtLocalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.lblInternationalDataSubCategory = New System.Windows.Forms.Label()
        Me.txtInternationalDataSubCategory = New System.Windows.Forms.TextBox()
        Me.lblDataCategory = New System.Windows.Forms.Label()
        Me.txtDataCategory = New System.Windows.Forms.TextBox()
        Me.lblOptionalSequenceInclusion = New System.Windows.Forms.Label()
        Me.lblNumberOfSubsets = New System.Windows.Forms.Label()
        Me.txtNumberOfSubsets = New System.Windows.Forms.TextBox()
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
        Me.grpBinaryMessage = New System.Windows.Forms.GroupBox()
        Me.grpCharacterMessage.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.grpSendingOptions.SuspendLayout()
        Me.grpInstrumentTypes.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpSensorsHeightFromGroundM.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpIndicators.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCharacterMessage
        '
        resources.ApplyResources(Me.txtCharacterMessage, "txtCharacterMessage")
        Me.txtCharacterMessage.Name = "txtCharacterMessage"
        '
        'lblInsrumentTypeWind
        '
        resources.ApplyResources(Me.lblInsrumentTypeWind, "lblInsrumentTypeWind")
        Me.lblInsrumentTypeWind.Name = "lblInsrumentTypeWind"
        Me.lblInsrumentTypeWind.Tag = "Wind"
        '
        'txtInstrumentTypesWind
        '
        resources.ApplyResources(Me.txtInstrumentTypesWind, "txtInstrumentTypesWind")
        Me.txtInstrumentTypesWind.Name = "txtInstrumentTypesWind"
        '
        'lblEvaporation
        '
        resources.ApplyResources(Me.lblEvaporation, "lblEvaporation")
        Me.lblEvaporation.Name = "lblEvaporation"
        Me.lblEvaporation.Tag = "Evaporation"
        '
        'txtEvaporation
        '
        resources.ApplyResources(Me.txtEvaporation, "txtEvaporation")
        Me.txtEvaporation.Name = "txtEvaporation"
        '
        'lblSensorHeightWind
        '
        resources.ApplyResources(Me.lblSensorHeightWind, "lblSensorHeightWind")
        Me.lblSensorHeightWind.Name = "lblSensorHeightWind"
        Me.lblSensorHeightWind.Tag = "Wind"
        '
        'lblPrecipitation
        '
        resources.ApplyResources(Me.lblPrecipitation, "lblPrecipitation")
        Me.lblPrecipitation.Name = "lblPrecipitation"
        Me.lblPrecipitation.Tag = "Precipitation"
        '
        'txtSensorHeightWind
        '
        resources.ApplyResources(Me.txtSensorHeightWind, "txtSensorHeightWind")
        Me.txtSensorHeightWind.Name = "txtSensorHeightWind"
        '
        'txtPrecipitation
        '
        resources.ApplyResources(Me.txtPrecipitation, "txtPrecipitation")
        Me.txtPrecipitation.Name = "txtPrecipitation"
        '
        'lblVisibility
        '
        resources.ApplyResources(Me.lblVisibility, "lblVisibility")
        Me.lblVisibility.Name = "lblVisibility"
        Me.lblVisibility.Tag = "Visibility"
        '
        'txtVisibility
        '
        resources.ApplyResources(Me.txtVisibility, "txtVisibility")
        Me.txtVisibility.Name = "txtVisibility"
        '
        'lblTemperature
        '
        resources.ApplyResources(Me.lblTemperature, "lblTemperature")
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Tag = "Temperature"
        '
        'cmdHelp
        '
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Tag = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdReset
        '
        resources.ApplyResources(Me.cmdReset, "cmdReset")
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Tag = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdViewImportExport
        '
        resources.ApplyResources(Me.cmdViewImportExport, "cmdViewImportExport")
        Me.cmdViewImportExport.Name = "cmdViewImportExport"
        Me.cmdViewImportExport.Tag = "View_Import_Export"
        Me.cmdViewImportExport.UseVisualStyleBackColor = True
        '
        'cmdEncode
        '
        resources.ApplyResources(Me.cmdEncode, "cmdEncode")
        Me.cmdEncode.Name = "cmdEncode"
        Me.cmdEncode.Tag = "Encode"
        Me.cmdEncode.UseVisualStyleBackColor = True
        '
        'grpCharacterMessage
        '
        Me.grpCharacterMessage.Controls.Add(Me.GroupBox8)
        Me.grpCharacterMessage.Controls.Add(Me.grpSendingOptions)
        Me.grpCharacterMessage.Controls.Add(Me.VScrollBar1)
        Me.grpCharacterMessage.Controls.Add(Me.txtCharacterMessage)
        resources.ApplyResources(Me.grpCharacterMessage, "grpCharacterMessage")
        Me.grpCharacterMessage.Name = "grpCharacterMessage"
        Me.grpCharacterMessage.TabStop = False
        Me.grpCharacterMessage.Tag = "Character_Message"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Controls.Add(Me.chkAttachUD)
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cmdSettings)
        Me.GroupBox9.Controls.Add(Me.cmdSend)
        resources.ApplyResources(Me.GroupBox9, "GroupBox9")
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.TabStop = False
        '
        'cmdSettings
        '
        resources.ApplyResources(Me.cmdSettings, "cmdSettings")
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Tag = "Setttings"
        Me.cmdSettings.UseVisualStyleBackColor = True
        '
        'cmdSend
        '
        resources.ApplyResources(Me.cmdSend, "cmdSend")
        Me.cmdSend.Name = "cmdSend"
        Me.cmdSend.Tag = "Send"
        Me.cmdSend.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.cmdSendMail)
        Me.GroupBox10.Controls.Add(Me.lstMailApplication)
        Me.GroupBox10.Controls.Add(Me.txtTo)
        Me.GroupBox10.Controls.Add(Me.txtSubject)
        Me.GroupBox10.Controls.Add(Me.lblTo)
        Me.GroupBox10.Controls.Add(Me.lblSubject)
        Me.GroupBox10.Controls.Add(Me.lblMailApplications)
        resources.ApplyResources(Me.GroupBox10, "GroupBox10")
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.TabStop = False
        '
        'cmdSendMail
        '
        resources.ApplyResources(Me.cmdSendMail, "cmdSendMail")
        Me.cmdSendMail.Name = "cmdSendMail"
        Me.cmdSendMail.Tag = "Send"
        Me.cmdSendMail.UseVisualStyleBackColor = True
        '
        'lstMailApplication
        '
        Me.lstMailApplication.FormattingEnabled = True
        resources.ApplyResources(Me.lstMailApplication, "lstMailApplication")
        Me.lstMailApplication.Name = "lstMailApplication"
        '
        'txtTo
        '
        resources.ApplyResources(Me.txtTo, "txtTo")
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Tag = "To"
        '
        'txtSubject
        '
        resources.ApplyResources(Me.txtSubject, "txtSubject")
        Me.txtSubject.Name = "txtSubject"
        '
        'lblTo
        '
        resources.ApplyResources(Me.lblTo, "lblTo")
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Tag = "To"
        '
        'lblSubject
        '
        resources.ApplyResources(Me.lblSubject, "lblSubject")
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Tag = "Subject"
        '
        'lblMailApplications
        '
        resources.ApplyResources(Me.lblMailApplications, "lblMailApplications")
        Me.lblMailApplications.Name = "lblMailApplications"
        Me.lblMailApplications.Tag = "Mail_Applications"
        '
        'chkAttachUD
        '
        resources.ApplyResources(Me.chkAttachUD, "chkAttachUD")
        Me.chkAttachUD.Name = "chkAttachUD"
        Me.chkAttachUD.Tag = "Attach_Uncoded_Data"
        Me.chkAttachUD.UseVisualStyleBackColor = True
        '
        'grpSendingOptions
        '
        Me.grpSendingOptions.Controls.Add(Me.lblFTP)
        Me.grpSendingOptions.Controls.Add(Me.rbFTP)
        Me.grpSendingOptions.Controls.Add(Me.lblEmail)
        Me.grpSendingOptions.Controls.Add(Me.rbEmail)
        resources.ApplyResources(Me.grpSendingOptions, "grpSendingOptions")
        Me.grpSendingOptions.Name = "grpSendingOptions"
        Me.grpSendingOptions.TabStop = False
        Me.grpSendingOptions.Tag = "Sending_Options"
        '
        'lblFTP
        '
        resources.ApplyResources(Me.lblFTP, "lblFTP")
        Me.lblFTP.Name = "lblFTP"
        Me.lblFTP.Tag = "FTP"
        '
        'rbFTP
        '
        resources.ApplyResources(Me.rbFTP, "rbFTP")
        Me.rbFTP.Name = "rbFTP"
        Me.rbFTP.TabStop = True
        Me.rbFTP.UseVisualStyleBackColor = True
        '
        'lblEmail
        '
        resources.ApplyResources(Me.lblEmail, "lblEmail")
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Tag = "Email"
        '
        'rbEmail
        '
        resources.ApplyResources(Me.rbEmail, "rbEmail")
        Me.rbEmail.Name = "rbEmail"
        Me.rbEmail.TabStop = True
        Me.rbEmail.UseVisualStyleBackColor = True
        '
        'VScrollBar1
        '
        resources.ApplyResources(Me.VScrollBar1, "VScrollBar1")
        Me.VScrollBar1.Name = "VScrollBar1"
        '
        'grpInstrumentTypes
        '
        Me.grpInstrumentTypes.Controls.Add(Me.lblInsrumentTypeWind)
        Me.grpInstrumentTypes.Controls.Add(Me.txtInstrumentTypesWind)
        Me.grpInstrumentTypes.Controls.Add(Me.lblEvaporation)
        Me.grpInstrumentTypes.Controls.Add(Me.txtEvaporation)
        resources.ApplyResources(Me.grpInstrumentTypes, "grpInstrumentTypes")
        Me.grpInstrumentTypes.Name = "grpInstrumentTypes"
        Me.grpInstrumentTypes.TabStop = False
        Me.grpInstrumentTypes.Tag = "Instrument_Types"
        '
        'lblCodedOutput
        '
        resources.ApplyResources(Me.lblCodedOutput, "lblCodedOutput")
        Me.lblCodedOutput.Name = "lblCodedOutput"
        Me.lblCodedOutput.Tag = "Coded_Output"
        '
        'txtTemperature
        '
        resources.ApplyResources(Me.txtTemperature, "txtTemperature")
        Me.txtTemperature.Name = "txtTemperature"
        '
        'cboBBB
        '
        Me.cboBBB.FormattingEnabled = True
        resources.ApplyResources(Me.cboBBB, "cboBBB")
        Me.cboBBB.Name = "cboBBB"
        '
        'txtMinute
        '
        resources.ApplyResources(Me.txtMinute, "txtMinute")
        Me.txtMinute.Name = "txtMinute"
        '
        'txtHour
        '
        resources.ApplyResources(Me.txtHour, "txtHour")
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Tag = ""
        '
        'txtDay
        '
        resources.ApplyResources(Me.txtDay, "txtDay")
        Me.txtDay.Name = "txtDay"
        '
        'txtMonth
        '
        resources.ApplyResources(Me.txtMonth, "txtMonth")
        Me.txtMonth.Name = "txtMonth"
        '
        'txtHeader
        '
        resources.ApplyResources(Me.txtHeader, "txtHeader")
        Me.txtHeader.Name = "txtHeader"
        '
        'txtYear
        '
        resources.ApplyResources(Me.txtYear, "txtYear")
        Me.txtYear.Name = "txtYear"
        '
        'lblHour
        '
        resources.ApplyResources(Me.lblHour, "lblHour")
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Tag = "Hour"
        '
        'lblMinute
        '
        resources.ApplyResources(Me.lblMinute, "lblMinute")
        Me.lblMinute.Name = "lblMinute"
        Me.lblMinute.Tag = "Minute"
        '
        'lblDay
        '
        resources.ApplyResources(Me.lblDay, "lblDay")
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Tag = "Day"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.Label7.Tag = "Template"
        '
        'lblMonth
        '
        resources.ApplyResources(Me.lblMonth, "lblMonth")
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Tag = "Month"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'TextBox15
        '
        resources.ApplyResources(Me.TextBox15, "TextBox15")
        Me.TextBox15.Name = "TextBox15"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'TextBox14
        '
        resources.ApplyResources(Me.TextBox14, "TextBox14")
        Me.TextBox14.Name = "TextBox14"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'lblHeader
        '
        resources.ApplyResources(Me.lblHeader, "lblHeader")
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Tag = "Header"
        '
        'lblYear
        '
        resources.ApplyResources(Me.lblYear, "lblYear")
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Tag = "Year"
        '
        'lblStation
        '
        resources.ApplyResources(Me.lblStation, "lblStation")
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Tag = "Station"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        resources.ApplyResources(Me.cboStation, "cboStation")
        Me.cboStation.Name = "cboStation"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTemplate)
        Me.GroupBox1.Controls.Add(Me.cboTemplate)
        Me.GroupBox1.Controls.Add(Me.cboBBB)
        Me.GroupBox1.Controls.Add(Me.txtMinute)
        Me.GroupBox1.Controls.Add(Me.txtHour)
        Me.GroupBox1.Controls.Add(Me.txtDay)
        Me.GroupBox1.Controls.Add(Me.txtMonth)
        Me.GroupBox1.Controls.Add(Me.txtHeader)
        Me.GroupBox1.Controls.Add(Me.txtYear)
        Me.GroupBox1.Controls.Add(Me.lblHour)
        Me.GroupBox1.Controls.Add(Me.lblMinute)
        Me.GroupBox1.Controls.Add(Me.lblDay)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblMonth)
        Me.GroupBox1.Controls.Add(Me.lblBBB)
        Me.GroupBox1.Controls.Add(Me.lblHeader)
        Me.GroupBox1.Controls.Add(Me.lblYear)
        Me.GroupBox1.Controls.Add(Me.lblStation)
        Me.GroupBox1.Controls.Add(Me.cboStation)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'lblTemplate
        '
        resources.ApplyResources(Me.lblTemplate, "lblTemplate")
        Me.lblTemplate.Name = "lblTemplate"
        Me.lblTemplate.Tag = "Template"
        '
        'cboTemplate
        '
        Me.cboTemplate.FormattingEnabled = True
        resources.ApplyResources(Me.cboTemplate, "cboTemplate")
        Me.cboTemplate.Name = "cboTemplate"
        '
        'lblBBB
        '
        resources.ApplyResources(Me.lblBBB, "lblBBB")
        Me.lblBBB.Name = "lblBBB"
        Me.lblBBB.Tag = "BBB"
        '
        'TextBox13
        '
        resources.ApplyResources(Me.TextBox13, "TextBox13")
        Me.TextBox13.Name = "TextBox13"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'TextBox12
        '
        resources.ApplyResources(Me.TextBox12, "TextBox12")
        Me.TextBox12.Name = "TextBox12"
        '
        'lblPressure
        '
        resources.ApplyResources(Me.lblPressure, "lblPressure")
        Me.lblPressure.Name = "lblPressure"
        Me.lblPressure.Tag = "Pressure"
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Tag = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'lblLocalTableVersionNumber
        '
        resources.ApplyResources(Me.lblLocalTableVersionNumber, "lblLocalTableVersionNumber")
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Tag = "Table_Version_Number"
        '
        'txtLocalTablesVersionNumber
        '
        resources.ApplyResources(Me.txtLocalTablesVersionNumber, "txtLocalTablesVersionNumber")
        Me.txtLocalTablesVersionNumber.Name = "txtLocalTablesVersionNumber"
        '
        'grpSensorsHeightFromGroundM
        '
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.lblSensorHeightWind)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.lblPrecipitation)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.txtSensorHeightWind)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.txtPrecipitation)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.lblVisibility)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.txtVisibility)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.lblTemperature)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.txtTemperature)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.lblPressure)
        Me.grpSensorsHeightFromGroundM.Controls.Add(Me.txtPressure)
        resources.ApplyResources(Me.grpSensorsHeightFromGroundM, "grpSensorsHeightFromGroundM")
        Me.grpSensorsHeightFromGroundM.Name = "grpSensorsHeightFromGroundM"
        Me.grpSensorsHeightFromGroundM.TabStop = False
        Me.grpSensorsHeightFromGroundM.Tag = "Sensors_Height_From_Ground_M"
        '
        'txtPressure
        '
        resources.ApplyResources(Me.txtPressure, "txtPressure")
        Me.txtPressure.Name = "txtPressure"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.TextBox15)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.TextBox14)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TextBox13)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.TextBox12)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TextBox11)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBox10)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.TextBox9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.TextBox7)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'TextBox11
        '
        resources.ApplyResources(Me.TextBox11, "TextBox11")
        Me.TextBox11.Name = "TextBox11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'TextBox10
        '
        resources.ApplyResources(Me.TextBox10, "TextBox10")
        Me.TextBox10.Name = "TextBox10"
        '
        'Label38
        '
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.Name = "Label38"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'TextBox9
        '
        resources.ApplyResources(Me.TextBox9, "TextBox9")
        Me.TextBox9.Name = "TextBox9"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'TextBox8
        '
        resources.ApplyResources(Me.TextBox8, "TextBox8")
        Me.TextBox8.Name = "TextBox8"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'TextBox7
        '
        resources.ApplyResources(Me.TextBox7, "TextBox7")
        Me.TextBox7.Name = "TextBox7"
        '
        'grpIndicators
        '
        Me.grpIndicators.Controls.Add(Me.chkOptionalSequenceInclusion)
        Me.grpIndicators.Controls.Add(Me.lblMastersTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtMastersTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.lblLocalDataSubCateory)
        Me.grpIndicators.Controls.Add(Me.txtLocalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.lblInternationalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.txtInternationalDataSubCategory)
        Me.grpIndicators.Controls.Add(Me.lblDataCategory)
        Me.grpIndicators.Controls.Add(Me.txtDataCategory)
        Me.grpIndicators.Controls.Add(Me.lblOptionalSequenceInclusion)
        Me.grpIndicators.Controls.Add(Me.lblNumberOfSubsets)
        Me.grpIndicators.Controls.Add(Me.txtNumberOfSubsets)
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
        resources.ApplyResources(Me.grpIndicators, "grpIndicators")
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Tag = "Indicators"
        '
        'chkOptionalSequenceInclusion
        '
        resources.ApplyResources(Me.chkOptionalSequenceInclusion, "chkOptionalSequenceInclusion")
        Me.chkOptionalSequenceInclusion.Name = "chkOptionalSequenceInclusion"
        Me.chkOptionalSequenceInclusion.UseVisualStyleBackColor = True
        '
        'lblMastersTableVersionNumber
        '
        resources.ApplyResources(Me.lblMastersTableVersionNumber, "lblMastersTableVersionNumber")
        Me.lblMastersTableVersionNumber.Name = "lblMastersTableVersionNumber"
        Me.lblMastersTableVersionNumber.Tag = "Masters_Table_Version_Number"
        '
        'txtMastersTableVersionNumber
        '
        resources.ApplyResources(Me.txtMastersTableVersionNumber, "txtMastersTableVersionNumber")
        Me.txtMastersTableVersionNumber.Name = "txtMastersTableVersionNumber"
        '
        'lblLocalDataSubCateory
        '
        resources.ApplyResources(Me.lblLocalDataSubCateory, "lblLocalDataSubCateory")
        Me.lblLocalDataSubCateory.Name = "lblLocalDataSubCateory"
        Me.lblLocalDataSubCateory.Tag = "Local_Data_Sub_Cateory"
        '
        'txtLocalDataSubCategory
        '
        resources.ApplyResources(Me.txtLocalDataSubCategory, "txtLocalDataSubCategory")
        Me.txtLocalDataSubCategory.Name = "txtLocalDataSubCategory"
        '
        'lblInternationalDataSubCategory
        '
        resources.ApplyResources(Me.lblInternationalDataSubCategory, "lblInternationalDataSubCategory")
        Me.lblInternationalDataSubCategory.Name = "lblInternationalDataSubCategory"
        Me.lblInternationalDataSubCategory.Tag = "International_Data_Sub_Category"
        '
        'txtInternationalDataSubCategory
        '
        resources.ApplyResources(Me.txtInternationalDataSubCategory, "txtInternationalDataSubCategory")
        Me.txtInternationalDataSubCategory.Name = "txtInternationalDataSubCategory"
        '
        'lblDataCategory
        '
        resources.ApplyResources(Me.lblDataCategory, "lblDataCategory")
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Tag = "Data_Category"
        '
        'txtDataCategory
        '
        resources.ApplyResources(Me.txtDataCategory, "txtDataCategory")
        Me.txtDataCategory.Name = "txtDataCategory"
        '
        'lblOptionalSequenceInclusion
        '
        resources.ApplyResources(Me.lblOptionalSequenceInclusion, "lblOptionalSequenceInclusion")
        Me.lblOptionalSequenceInclusion.Name = "lblOptionalSequenceInclusion"
        Me.lblOptionalSequenceInclusion.Tag = "Optional_Sequence_Inclusion"
        '
        'lblNumberOfSubsets
        '
        resources.ApplyResources(Me.lblNumberOfSubsets, "lblNumberOfSubsets")
        Me.lblNumberOfSubsets.Name = "lblNumberOfSubsets"
        Me.lblNumberOfSubsets.Tag = "Number_Of_Subsets"
        '
        'txtNumberOfSubsets
        '
        resources.ApplyResources(Me.txtNumberOfSubsets, "txtNumberOfSubsets")
        Me.txtNumberOfSubsets.Name = "txtNumberOfSubsets"
        '
        'txtUpdateSequenceNumber
        '
        resources.ApplyResources(Me.txtUpdateSequenceNumber, "txtUpdateSequenceNumber")
        Me.txtUpdateSequenceNumber.Name = "txtUpdateSequenceNumber"
        '
        'lblUpdateSequenceNumber
        '
        resources.ApplyResources(Me.lblUpdateSequenceNumber, "lblUpdateSequenceNumber")
        Me.lblUpdateSequenceNumber.Name = "lblUpdateSequenceNumber"
        Me.lblUpdateSequenceNumber.Tag = "Update_Sequence_Number"
        '
        'lblOriginatingGeneratingSubCentre
        '
        resources.ApplyResources(Me.lblOriginatingGeneratingSubCentre, "lblOriginatingGeneratingSubCentre")
        Me.lblOriginatingGeneratingSubCentre.Name = "lblOriginatingGeneratingSubCentre"
        Me.lblOriginatingGeneratingSubCentre.Tag = "Originating_Generating_SubCentre"
        '
        'txtOriginatingGeneratingSubCentre
        '
        resources.ApplyResources(Me.txtOriginatingGeneratingSubCentre, "txtOriginatingGeneratingSubCentre")
        Me.txtOriginatingGeneratingSubCentre.Name = "txtOriginatingGeneratingSubCentre"
        '
        'lblOriginatingOriginatingCentre
        '
        resources.ApplyResources(Me.lblOriginatingOriginatingCentre, "lblOriginatingOriginatingCentre")
        Me.lblOriginatingOriginatingCentre.Name = "lblOriginatingOriginatingCentre"
        Me.lblOriginatingOriginatingCentre.Tag = "Originating_Generating_Centre"
        '
        'txtOriginatingGeneratingCentre
        '
        resources.ApplyResources(Me.txtOriginatingGeneratingCentre, "txtOriginatingGeneratingCentre")
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        '
        'lblBUFREditionNumber
        '
        resources.ApplyResources(Me.lblBUFREditionNumber, "lblBUFREditionNumber")
        Me.lblBUFREditionNumber.Name = "lblBUFREditionNumber"
        Me.lblBUFREditionNumber.Tag = "BUFR_edition_Number"
        '
        'txtBUFREditionNumber
        '
        resources.ApplyResources(Me.txtBUFREditionNumber, "txtBUFREditionNumber")
        Me.txtBUFREditionNumber.Name = "txtBUFREditionNumber"
        '
        'Label44
        '
        resources.ApplyResources(Me.Label44, "Label44")
        Me.Label44.Name = "Label44"
        '
        'Label49
        '
        resources.ApplyResources(Me.Label49, "Label49")
        Me.Label49.Name = "Label49"
        '
        'grpBinaryMessage
        '
        resources.ApplyResources(Me.grpBinaryMessage, "grpBinaryMessage")
        Me.grpBinaryMessage.Name = "grpBinaryMessage"
        Me.grpBinaryMessage.TabStop = False
        Me.grpBinaryMessage.Tag = "Binary_Message"
        '
        'frmBUFR
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblLocalTableVersionNumber)
        Me.Controls.Add(Me.txtLocalTablesVersionNumber)
        Me.Controls.Add(Me.lblCodedOutput)
        Me.Controls.Add(Me.grpBinaryMessage)
        Me.Controls.Add(Me.cmdHelp)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdViewImportExport)
        Me.Controls.Add(Me.cmdEncode)
        Me.Controls.Add(Me.grpCharacterMessage)
        Me.Controls.Add(Me.grpInstrumentTypes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.grpSensorsHeightFromGroundM)
        Me.Controls.Add(Me.grpIndicators)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmBUFR"
        Me.grpCharacterMessage.ResumeLayout(False)
        Me.grpCharacterMessage.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.grpSendingOptions.ResumeLayout(False)
        Me.grpSendingOptions.PerformLayout()
        Me.grpInstrumentTypes.ResumeLayout(False)
        Me.grpInstrumentTypes.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpSensorsHeightFromGroundM.ResumeLayout(False)
        Me.grpSensorsHeightFromGroundM.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpIndicators.ResumeLayout(False)
        Me.grpIndicators.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCharacterMessage As TextBox
    Friend WithEvents lblInsrumentTypeWind As Label
    Friend WithEvents txtInstrumentTypesWind As TextBox
    Friend WithEvents lblEvaporation As Label
    Friend WithEvents txtEvaporation As TextBox
    Friend WithEvents lblSensorHeightWind As Label
    Friend WithEvents lblPrecipitation As Label
    Friend WithEvents txtSensorHeightWind As TextBox
    Friend WithEvents txtPrecipitation As TextBox
    Friend WithEvents lblVisibility As Label
    Friend WithEvents txtVisibility As TextBox
    Friend WithEvents lblTemperature As Label
    Friend WithEvents cmdHelp As Button
    Friend WithEvents cmdReset As Button
    Friend WithEvents cmdViewImportExport As Button
    Friend WithEvents cmdEncode As Button
    Friend WithEvents grpCharacterMessage As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents cmdSettings As Button
    Friend WithEvents cmdSend As Button
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents cmdSendMail As Button
    Friend WithEvents lstMailApplication As ListBox
    Friend WithEvents txtTo As TextBox
    Friend WithEvents txtSubject As TextBox
    Friend WithEvents lblTo As Label
    Friend WithEvents lblSubject As Label
    Friend WithEvents lblMailApplications As Label
    Friend WithEvents chkAttachUD As CheckBox
    Friend WithEvents grpSendingOptions As GroupBox
    Friend WithEvents lblFTP As Label
    Friend WithEvents rbFTP As RadioButton
    Friend WithEvents lblEmail As Label
    Friend WithEvents rbEmail As RadioButton
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents grpInstrumentTypes As GroupBox
    Friend WithEvents lblCodedOutput As Label
    Friend WithEvents txtTemperature As TextBox
    Friend WithEvents cboBBB As ComboBox
    Friend WithEvents txtMinute As TextBox
    Friend WithEvents txtHour As TextBox
    Friend WithEvents txtDay As TextBox
    Friend WithEvents txtMonth As TextBox
    Friend WithEvents txtHeader As TextBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents lblHour As Label
    Friend WithEvents lblMinute As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents lblYear As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboTemplate As ComboBox
    Friend WithEvents lblBBB As Label
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents lblPressure As Label
    Friend WithEvents cmdClose As Button
    Friend WithEvents lblLocalTableVersionNumber As Label
    Friend WithEvents txtLocalTablesVersionNumber As TextBox
    Friend WithEvents grpSensorsHeightFromGroundM As GroupBox
    Friend WithEvents txtPressure As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents grpIndicators As GroupBox
    Friend WithEvents lblMastersTableVersionNumber As Label
    Friend WithEvents txtMastersTableVersionNumber As TextBox
    Friend WithEvents lblLocalDataSubCateory As Label
    Friend WithEvents txtLocalDataSubCategory As TextBox
    Friend WithEvents lblInternationalDataSubCategory As Label
    Friend WithEvents txtInternationalDataSubCategory As TextBox
    Friend WithEvents lblDataCategory As Label
    Friend WithEvents txtDataCategory As TextBox
    Friend WithEvents lblOptionalSequenceInclusion As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents txtUpdateSequenceNumber As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents lblUpdateSequenceNumber As Label
    Friend WithEvents lblOriginatingGeneratingSubCentre As Label
    Friend WithEvents txtOriginatingGeneratingSubCentre As TextBox
    Friend WithEvents lblOriginatingOriginatingCentre As Label
    Friend WithEvents txtOriginatingGeneratingCentre As TextBox
    Friend WithEvents lblBUFREditionNumber As Label
    Friend WithEvents txtBUFREditionNumber As TextBox
    Friend WithEvents chkOptionalSequenceInclusion As CheckBox
    Friend WithEvents lblNumberOfSubsets As Label
    Friend WithEvents txtNumberOfSubsets As TextBox
    Friend WithEvents grpBinaryMessage As GroupBox
    Friend WithEvents lblTemplate As Label
End Class
