<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTDCFindicators
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTemplate = New System.Windows.Forms.ComboBox()
        Me.txtMsgHeader = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.grpIndicators = New System.Windows.Forms.GroupBox()
        Me.lblInternationalDataSubCategory = New System.Windows.Forms.Label()
        Me.txtLocalTableVersionNumber = New System.Windows.Forms.TextBox()
        Me.lblLocalTableVersionNumber = New System.Windows.Forms.Label()
        Me.chkOptionalSectionInclusion = New System.Windows.Forms.CheckBox()
        Me.lblMastersTableVersionNumber = New System.Windows.Forms.Label()
        Me.txtMastersTableVersionNumber = New System.Windows.Forms.TextBox()
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
        Me.cmdUpadate = New System.Windows.Forms.Button()
        Me.cmdNew = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grpIndicators.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Controls.Add(Me.lblHeader)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboTemplate)
        Me.GroupBox1.Controls.Add(Me.txtMsgHeader)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(574, 57)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Headers"
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(329, 28)
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
        Me.Label1.Location = New System.Drawing.Point(28, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Tag = "Template"
        Me.Label1.Text = "Template"
        '
        'cboTemplate
        '
        Me.cboTemplate.FormattingEnabled = True
        Me.cboTemplate.Location = New System.Drawing.Point(96, 25)
        Me.cboTemplate.Name = "cboTemplate"
        Me.cboTemplate.Size = New System.Drawing.Size(151, 21)
        Me.cboTemplate.TabIndex = 3
        '
        'txtMsgHeader
        '
        Me.txtMsgHeader.Location = New System.Drawing.Point(445, 24)
        Me.txtMsgHeader.Name = "txtMsgHeader"
        Me.txtMsgHeader.Size = New System.Drawing.Size(113, 20)
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
        Me.grpIndicators.Controls.Add(Me.txtLocalTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.lblLocalTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.chkOptionalSectionInclusion)
        Me.grpIndicators.Controls.Add(Me.lblMastersTableVersionNumber)
        Me.grpIndicators.Controls.Add(Me.txtMastersTableVersionNumber)
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
        Me.grpIndicators.Location = New System.Drawing.Point(86, 85)
        Me.grpIndicators.Name = "grpIndicators"
        Me.grpIndicators.Size = New System.Drawing.Size(356, 321)
        Me.grpIndicators.TabIndex = 15
        Me.grpIndicators.TabStop = False
        Me.grpIndicators.Tag = "Indicators"
        Me.grpIndicators.Text = "Indicators "
        '
        'lblInternationalDataSubCategory
        '
        Me.lblInternationalDataSubCategory.AutoSize = True
        Me.lblInternationalDataSubCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternationalDataSubCategory.Location = New System.Drawing.Point(60, 193)
        Me.lblInternationalDataSubCategory.Name = "lblInternationalDataSubCategory"
        Me.lblInternationalDataSubCategory.Size = New System.Drawing.Size(161, 13)
        Me.lblInternationalDataSubCategory.TabIndex = 15
        Me.lblInternationalDataSubCategory.Tag = "Data_Category"
        Me.lblInternationalDataSubCategory.Text = "International Data Sub Category " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtLocalTableVersionNumber
        '
        Me.txtLocalTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalTableVersionNumber.Location = New System.Drawing.Point(271, 274)
        Me.txtLocalTableVersionNumber.Name = "txtLocalTableVersionNumber"
        Me.txtLocalTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalTableVersionNumber.TabIndex = 14
        '
        'lblLocalTableVersionNumber
        '
        Me.lblLocalTableVersionNumber.AutoSize = True
        Me.lblLocalTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalTableVersionNumber.Location = New System.Drawing.Point(60, 277)
        Me.lblLocalTableVersionNumber.Name = "lblLocalTableVersionNumber"
        Me.lblLocalTableVersionNumber.Size = New System.Drawing.Size(146, 13)
        Me.lblLocalTableVersionNumber.TabIndex = 11
        Me.lblLocalTableVersionNumber.Tag = "Table_Version_Number"
        Me.lblLocalTableVersionNumber.Text = "Local Tables Version Number"
        '
        'chkOptionalSectionInclusion
        '
        Me.chkOptionalSectionInclusion.AutoSize = True
        Me.chkOptionalSectionInclusion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOptionalSectionInclusion.Location = New System.Drawing.Point(271, 140)
        Me.chkOptionalSectionInclusion.Name = "chkOptionalSectionInclusion"
        Me.chkOptionalSectionInclusion.Size = New System.Drawing.Size(15, 14)
        Me.chkOptionalSectionInclusion.TabIndex = 3
        Me.chkOptionalSectionInclusion.UseVisualStyleBackColor = True
        '
        'lblMastersTableVersionNumber
        '
        Me.lblMastersTableVersionNumber.AutoSize = True
        Me.lblMastersTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMastersTableVersionNumber.Location = New System.Drawing.Point(60, 249)
        Me.lblMastersTableVersionNumber.Name = "lblMastersTableVersionNumber"
        Me.lblMastersTableVersionNumber.Size = New System.Drawing.Size(152, 13)
        Me.lblMastersTableVersionNumber.TabIndex = 1
        Me.lblMastersTableVersionNumber.Tag = "Masters_Table_Version_Number"
        Me.lblMastersTableVersionNumber.Text = "Masters Table Version Number"
        '
        'txtMastersTableVersionNumber
        '
        Me.txtMastersTableVersionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMastersTableVersionNumber.Location = New System.Drawing.Point(271, 246)
        Me.txtMastersTableVersionNumber.Name = "txtMastersTableVersionNumber"
        Me.txtMastersTableVersionNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtMastersTableVersionNumber.TabIndex = 2
        '
        'lblLocalDataSubCateory
        '
        Me.lblLocalDataSubCateory.AutoSize = True
        Me.lblLocalDataSubCateory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocalDataSubCateory.Location = New System.Drawing.Point(60, 221)
        Me.lblLocalDataSubCateory.Name = "lblLocalDataSubCateory"
        Me.lblLocalDataSubCateory.Size = New System.Drawing.Size(126, 13)
        Me.lblLocalDataSubCateory.TabIndex = 1
        Me.lblLocalDataSubCateory.Tag = "Local_Data_Sub_Cateory"
        Me.lblLocalDataSubCateory.Text = "Local Data Sub-Category"
        '
        'txtLocalDataSubCategory
        '
        Me.txtLocalDataSubCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalDataSubCategory.Location = New System.Drawing.Point(271, 218)
        Me.txtLocalDataSubCategory.Name = "txtLocalDataSubCategory"
        Me.txtLocalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtLocalDataSubCategory.TabIndex = 2
        '
        'txtInternationalDataSubCategory
        '
        Me.txtInternationalDataSubCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInternationalDataSubCategory.Location = New System.Drawing.Point(271, 190)
        Me.txtInternationalDataSubCategory.Name = "txtInternationalDataSubCategory"
        Me.txtInternationalDataSubCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtInternationalDataSubCategory.TabIndex = 2
        '
        'lblDataCategory
        '
        Me.lblDataCategory.AutoSize = True
        Me.lblDataCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDataCategory.Location = New System.Drawing.Point(60, 165)
        Me.lblDataCategory.Name = "lblDataCategory"
        Me.lblDataCategory.Size = New System.Drawing.Size(78, 13)
        Me.lblDataCategory.TabIndex = 1
        Me.lblDataCategory.Tag = "Data_Category"
        Me.lblDataCategory.Text = "Data Category " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtDataCategory
        '
        Me.txtDataCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataCategory.Location = New System.Drawing.Point(271, 162)
        Me.txtDataCategory.Name = "txtDataCategory"
        Me.txtDataCategory.Size = New System.Drawing.Size(39, 20)
        Me.txtDataCategory.TabIndex = 2
        '
        'lblOptionalSectionInclusion
        '
        Me.lblOptionalSectionInclusion.AutoSize = True
        Me.lblOptionalSectionInclusion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOptionalSectionInclusion.Location = New System.Drawing.Point(60, 140)
        Me.lblOptionalSectionInclusion.MaximumSize = New System.Drawing.Size(1000, 1100)
        Me.lblOptionalSectionInclusion.Name = "lblOptionalSectionInclusion"
        Me.lblOptionalSectionInclusion.Size = New System.Drawing.Size(130, 13)
        Me.lblOptionalSectionInclusion.TabIndex = 1
        Me.lblOptionalSectionInclusion.Tag = "Optional_Section_Inclusion"
        Me.lblOptionalSectionInclusion.Text = "Optional Section Inclusion"
        '
        'txtUpdateSequenceNumber
        '
        Me.txtUpdateSequenceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpdateSequenceNumber.Location = New System.Drawing.Point(271, 112)
        Me.txtUpdateSequenceNumber.Name = "txtUpdateSequenceNumber"
        Me.txtUpdateSequenceNumber.Size = New System.Drawing.Size(39, 20)
        Me.txtUpdateSequenceNumber.TabIndex = 2
        '
        'lblUpdateSequenceNumber
        '
        Me.lblUpdateSequenceNumber.AutoSize = True
        Me.lblUpdateSequenceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpdateSequenceNumber.Location = New System.Drawing.Point(60, 115)
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
        Me.lblOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(60, 87)
        Me.lblOriginatingGeneratingSubCentre.Name = "lblOriginatingGeneratingSubCentre"
        Me.lblOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(170, 13)
        Me.lblOriginatingGeneratingSubCentre.TabIndex = 1
        Me.lblOriginatingGeneratingSubCentre.Tag = "Originating_Generating_SubCentre"
        Me.lblOriginatingGeneratingSubCentre.Text = "Originating/Generating Sub-Centre"
        '
        'txtOriginatingGeneratingSubCentre
        '
        Me.txtOriginatingGeneratingSubCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginatingGeneratingSubCentre.Location = New System.Drawing.Point(271, 84)
        Me.txtOriginatingGeneratingSubCentre.Name = "txtOriginatingGeneratingSubCentre"
        Me.txtOriginatingGeneratingSubCentre.Size = New System.Drawing.Size(39, 20)
        Me.txtOriginatingGeneratingSubCentre.TabIndex = 2
        '
        'lblOriginatingOriginatingCentre
        '
        Me.lblOriginatingOriginatingCentre.AutoSize = True
        Me.lblOriginatingOriginatingCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOriginatingOriginatingCentre.Location = New System.Drawing.Point(60, 59)
        Me.lblOriginatingOriginatingCentre.Name = "lblOriginatingOriginatingCentre"
        Me.lblOriginatingOriginatingCentre.Size = New System.Drawing.Size(148, 13)
        Me.lblOriginatingOriginatingCentre.TabIndex = 1
        Me.lblOriginatingOriginatingCentre.Tag = "Originating_Generating_Centre"
        Me.lblOriginatingOriginatingCentre.Text = "Originating/Generating Centre"
        '
        'txtOriginatingGeneratingCentre
        '
        Me.txtOriginatingGeneratingCentre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOriginatingGeneratingCentre.Location = New System.Drawing.Point(271, 56)
        Me.txtOriginatingGeneratingCentre.Name = "txtOriginatingGeneratingCentre"
        Me.txtOriginatingGeneratingCentre.Size = New System.Drawing.Size(55, 20)
        Me.txtOriginatingGeneratingCentre.TabIndex = 2
        '
        'lblBUFREditionNumber
        '
        Me.lblBUFREditionNumber.AutoSize = True
        Me.lblBUFREditionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBUFREditionNumber.Location = New System.Drawing.Point(60, 31)
        Me.lblBUFREditionNumber.Name = "lblBUFREditionNumber"
        Me.lblBUFREditionNumber.Size = New System.Drawing.Size(110, 13)
        Me.lblBUFREditionNumber.TabIndex = 1
        Me.lblBUFREditionNumber.Tag = "BUFR_edition_Number"
        Me.lblBUFREditionNumber.Text = "BUFR edition Number"
        '
        'txtBUFREditionNumber
        '
        Me.txtBUFREditionNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBUFREditionNumber.Location = New System.Drawing.Point(272, 28)
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
        'cmdUpadate
        '
        Me.cmdUpadate.Location = New System.Drawing.Point(268, 412)
        Me.cmdUpadate.Name = "cmdUpadate"
        Me.cmdUpadate.Size = New System.Drawing.Size(93, 24)
        Me.cmdUpadate.TabIndex = 15
        Me.cmdUpadate.Text = "Update"
        Me.cmdUpadate.UseVisualStyleBackColor = True
        '
        'cmdNew
        '
        Me.cmdNew.Location = New System.Drawing.Point(86, 412)
        Me.cmdNew.Name = "cmdNew"
        Me.cmdNew.Size = New System.Drawing.Size(83, 24)
        Me.cmdNew.TabIndex = 0
        Me.cmdNew.Text = "AddNew"
        Me.cmdNew.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(175, 412)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(87, 24)
        Me.cmdSave.TabIndex = 17
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(367, 412)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 24)
        Me.cmdClose.TabIndex = 18
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmTDCFindicators
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 472)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdUpadate)
        Me.Controls.Add(Me.grpIndicators)
        Me.Controls.Add(Me.cmdNew)
        Me.Name = "frmTDCFindicators"
        Me.Text = "TDCF Indicators"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpIndicators.ResumeLayout(False)
        Me.grpIndicators.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents txtMsgHeader As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents grpIndicators As System.Windows.Forms.GroupBox
    Friend WithEvents lblInternationalDataSubCategory As System.Windows.Forms.Label
    Friend WithEvents txtLocalTableVersionNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblLocalTableVersionNumber As System.Windows.Forms.Label
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
    Friend WithEvents cmdUpadate As System.Windows.Forms.Button
    Friend WithEvents cmdNew As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
