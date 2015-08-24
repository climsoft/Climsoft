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
        Me.cmdArchive = New System.Windows.Forms.Button()
        Me.listImages = New System.Windows.Forms.ListBox()
        Me.lblImageFiles = New System.Windows.Forms.Label()
        Me.lblSelectedFolder = New System.Windows.Forms.Label()
        Me.txtSelectedFolder = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.tabUnstructured = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.cmdImageFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdHour = New System.Windows.Forms.ComboBox()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblday = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.cmbDay = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbStation = New System.Windows.Forms.ComboBox()
        Me.txtFormId = New System.Windows.Forms.TextBox()
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.TabViewArchive = New System.Windows.Forms.TabPage()
        Me.grpImage = New System.Windows.Forms.GroupBox()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.txtHH = New System.Windows.Forms.TextBox()
        Me.txtDD = New System.Windows.Forms.TextBox()
        Me.txtMM = New System.Windows.Forms.TextBox()
        Me.txtYY = New System.Windows.Forms.TextBox()
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
        Me.cmdFolder = New System.Windows.Forms.Button()
        Me.tabImageArchives.SuspendLayout()
        Me.tabStructured.SuspendLayout()
        Me.grpInformation.SuspendLayout()
        Me.tabUnstructured.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabViewArchive.SuspendLayout()
        Me.grpImage.SuspendLayout()
        Me.MenuPaperArchive.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabImageArchives
        '
        Me.tabImageArchives.Controls.Add(Me.tabStructured)
        Me.tabImageArchives.Controls.Add(Me.tabUnstructured)
        Me.tabImageArchives.Controls.Add(Me.TabViewArchive)
        Me.tabImageArchives.Location = New System.Drawing.Point(10, 27)
        Me.tabImageArchives.Name = "tabImageArchives"
        Me.tabImageArchives.SelectedIndex = 0
        Me.tabImageArchives.Size = New System.Drawing.Size(660, 450)
        Me.tabImageArchives.TabIndex = 2
        '
        'tabStructured
        '
        Me.tabStructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabStructured.Controls.Add(Me.cmdFolder)
        Me.tabStructured.Controls.Add(Me.grpInformation)
        Me.tabStructured.Controls.Add(Me.TextBox1)
        Me.tabStructured.Controls.Add(Me.lblFolder)
        Me.tabStructured.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStructured.Location = New System.Drawing.Point(4, 22)
        Me.tabStructured.Name = "tabStructured"
        Me.tabStructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStructured.Size = New System.Drawing.Size(652, 424)
        Me.tabStructured.TabIndex = 0
        Me.tabStructured.Text = "Structured Filenames"
        Me.tabStructured.UseVisualStyleBackColor = True
        '
        'grpInformation
        '
        Me.grpInformation.Controls.Add(Me.cmdArchive)
        Me.grpInformation.Controls.Add(Me.listImages)
        Me.grpInformation.Controls.Add(Me.lblImageFiles)
        Me.grpInformation.Controls.Add(Me.lblSelectedFolder)
        Me.grpInformation.Controls.Add(Me.txtSelectedFolder)
        Me.grpInformation.Location = New System.Drawing.Point(22, 63)
        Me.grpInformation.Name = "grpInformation"
        Me.grpInformation.Size = New System.Drawing.Size(602, 345)
        Me.grpInformation.TabIndex = 3
        Me.grpInformation.TabStop = False
        Me.grpInformation.Text = "Information"
        '
        'cmdArchive
        '
        Me.cmdArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArchive.Location = New System.Drawing.Point(273, 311)
        Me.cmdArchive.Name = "cmdArchive"
        Me.cmdArchive.Size = New System.Drawing.Size(83, 25)
        Me.cmdArchive.TabIndex = 6
        Me.cmdArchive.Text = "Archive"
        Me.cmdArchive.UseVisualStyleBackColor = True
        '
        'listImages
        '
        Me.listImages.FormattingEnabled = True
        Me.listImages.HorizontalScrollbar = True
        Me.listImages.Location = New System.Drawing.Point(93, 81)
        Me.listImages.MultiColumn = True
        Me.listImages.Name = "listImages"
        Me.listImages.ScrollAlwaysVisible = True
        Me.listImages.Size = New System.Drawing.Size(478, 225)
        Me.listImages.TabIndex = 3
        '
        'lblImageFiles
        '
        Me.lblImageFiles.AutoSize = True
        Me.lblImageFiles.Location = New System.Drawing.Point(6, 81)
        Me.lblImageFiles.Name = "lblImageFiles"
        Me.lblImageFiles.Size = New System.Drawing.Size(81, 13)
        Me.lblImageFiles.TabIndex = 2
        Me.lblImageFiles.Text = "Selected Folder"
        '
        'lblSelectedFolder
        '
        Me.lblSelectedFolder.AutoSize = True
        Me.lblSelectedFolder.Location = New System.Drawing.Point(6, 42)
        Me.lblSelectedFolder.Name = "lblSelectedFolder"
        Me.lblSelectedFolder.Size = New System.Drawing.Size(81, 13)
        Me.lblSelectedFolder.TabIndex = 1
        Me.lblSelectedFolder.Text = "Selected Folder"
        '
        'txtSelectedFolder
        '
        Me.txtSelectedFolder.BackColor = System.Drawing.Color.Snow
        Me.txtSelectedFolder.Location = New System.Drawing.Point(93, 38)
        Me.txtSelectedFolder.Name = "txtSelectedFolder"
        Me.txtSelectedFolder.Size = New System.Drawing.Size(478, 20)
        Me.txtSelectedFolder.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(92, 21)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(476, 20)
        Me.TextBox1.TabIndex = 1
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Location = New System.Drawing.Point(19, 27)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(73, 13)
        Me.lblFolder.TabIndex = 0
        Me.lblFolder.Text = "Images Folder"
        '
        'tabUnstructured
        '
        Me.tabUnstructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnstructured.Controls.Add(Me.Panel1)
        Me.tabUnstructured.Location = New System.Drawing.Point(4, 22)
        Me.tabUnstructured.Name = "tabUnstructured"
        Me.tabUnstructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnstructured.Size = New System.Drawing.Size(652, 424)
        Me.tabUnstructured.TabIndex = 1
        Me.tabUnstructured.Text = "Unstructured Filenames"
        Me.tabUnstructured.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.cmdImageFile)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmdHour)
        Me.Panel1.Controls.Add(Me.lblHour)
        Me.Panel1.Controls.Add(Me.lblday)
        Me.Panel1.Controls.Add(Me.lblMonth)
        Me.Panel1.Controls.Add(Me.lblYear)
        Me.Panel1.Controls.Add(Me.cmbDay)
        Me.Panel1.Controls.Add(Me.cmbMonth)
        Me.Panel1.Controls.Add(Me.cmbYear)
        Me.Panel1.Controls.Add(Me.cmbStation)
        Me.Panel1.Controls.Add(Me.txtFormId)
        Me.Panel1.Controls.Add(Me.lblStationId)
        Me.Panel1.Location = New System.Drawing.Point(22, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(605, 297)
        Me.Panel1.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(423, 254)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 25)
        Me.Button3.TabIndex = 18
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(267, 254)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 25)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(111, 254)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 25)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Archive"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(6, 196)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(126, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Restructure Filename"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'cmdImageFile
        '
        Me.cmdImageFile.BackgroundImage = CType(resources.GetObject("cmdImageFile.BackgroundImage"), System.Drawing.Image)
        Me.cmdImageFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdImageFile.Location = New System.Drawing.Point(527, 151)
        Me.cmdImageFile.Name = "cmdImageFile"
        Me.cmdImageFile.Size = New System.Drawing.Size(30, 26)
        Me.cmdImageFile.TabIndex = 14
        Me.cmdImageFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Image"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(45, 154)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(484, 20)
        Me.TextBox3.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Form ID"
        '
        'cmdHour
        '
        Me.cmdHour.FormattingEnabled = True
        Me.cmdHour.Location = New System.Drawing.Point(313, 67)
        Me.cmdHour.Name = "cmdHour"
        Me.cmdHour.Size = New System.Drawing.Size(34, 21)
        Me.cmdHour.TabIndex = 10
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(280, 71)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(30, 13)
        Me.lblHour.TabIndex = 9
        Me.lblHour.Text = "Hour"
        '
        'lblday
        '
        Me.lblday.AutoSize = True
        Me.lblday.Location = New System.Drawing.Point(189, 71)
        Me.lblday.Name = "lblday"
        Me.lblday.Size = New System.Drawing.Size(26, 13)
        Me.lblday.TabIndex = 8
        Me.lblday.Text = "Day"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(97, 71)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 7
        Me.lblMonth.Text = "Month"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(3, 71)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 6
        Me.lblYear.Text = "Year"
        '
        'cmbDay
        '
        Me.cmbDay.FormattingEnabled = True
        Me.cmbDay.Location = New System.Drawing.Point(217, 67)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(46, 21)
        Me.cmbDay.TabIndex = 5
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(137, 67)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(34, 21)
        Me.cmbMonth.TabIndex = 4
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(40, 67)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(40, 21)
        Me.cmbYear.TabIndex = 3
        '
        'cmbStation
        '
        Me.cmbStation.FormattingEnabled = True
        Me.cmbStation.Location = New System.Drawing.Point(40, 17)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(215, 21)
        Me.cmbStation.TabIndex = 2
        '
        'txtFormId
        '
        Me.txtFormId.Location = New System.Drawing.Point(405, 21)
        Me.txtFormId.Name = "txtFormId"
        Me.txtFormId.Size = New System.Drawing.Size(187, 20)
        Me.txtFormId.TabIndex = 1
        '
        'lblStationId
        '
        Me.lblStationId.AutoSize = True
        Me.lblStationId.Location = New System.Drawing.Point(3, 21)
        Me.lblStationId.Name = "lblStationId"
        Me.lblStationId.Size = New System.Drawing.Size(40, 13)
        Me.lblStationId.TabIndex = 0
        Me.lblStationId.Text = "Station"
        '
        'TabViewArchive
        '
        Me.TabViewArchive.Controls.Add(Me.grpImage)
        Me.TabViewArchive.Location = New System.Drawing.Point(4, 22)
        Me.TabViewArchive.Name = "TabViewArchive"
        Me.TabViewArchive.Padding = New System.Windows.Forms.Padding(3)
        Me.TabViewArchive.Size = New System.Drawing.Size(652, 424)
        Me.TabViewArchive.TabIndex = 2
        Me.TabViewArchive.Text = "View Archived Image"
        Me.TabViewArchive.UseVisualStyleBackColor = True
        '
        'grpImage
        '
        Me.grpImage.Controls.Add(Me.cmdView)
        Me.grpImage.Controls.Add(Me.txtHH)
        Me.grpImage.Controls.Add(Me.txtDD)
        Me.grpImage.Controls.Add(Me.txtMM)
        Me.grpImage.Controls.Add(Me.txtYY)
        Me.grpImage.Controls.Add(Me.txtForm)
        Me.grpImage.Controls.Add(Me.txtStation)
        Me.grpImage.Controls.Add(Me.Label8)
        Me.grpImage.Controls.Add(Me.Label7)
        Me.grpImage.Controls.Add(Me.Label6)
        Me.grpImage.Controls.Add(Me.Label4)
        Me.grpImage.Controls.Add(Me.Label3)
        Me.grpImage.Controls.Add(Me.Label2)
        Me.grpImage.Location = New System.Drawing.Point(65, 71)
        Me.grpImage.Name = "grpImage"
        Me.grpImage.Size = New System.Drawing.Size(527, 267)
        Me.grpImage.TabIndex = 0
        Me.grpImage.TabStop = False
        Me.grpImage.Text = "Image Details"
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(204, 213)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.Size = New System.Drawing.Size(92, 33)
        Me.cmdView.TabIndex = 12
        Me.cmdView.Text = "View Image"
        Me.cmdView.UseVisualStyleBackColor = True
        '
        'txtHH
        '
        Me.txtHH.Location = New System.Drawing.Point(93, 189)
        Me.txtHH.Name = "txtHH"
        Me.txtHH.Size = New System.Drawing.Size(43, 20)
        Me.txtHH.TabIndex = 11
        '
        'txtDD
        '
        Me.txtDD.Location = New System.Drawing.Point(93, 159)
        Me.txtDD.Name = "txtDD"
        Me.txtDD.Size = New System.Drawing.Size(43, 20)
        Me.txtDD.TabIndex = 10
        '
        'txtMM
        '
        Me.txtMM.Location = New System.Drawing.Point(93, 129)
        Me.txtMM.Name = "txtMM"
        Me.txtMM.Size = New System.Drawing.Size(43, 20)
        Me.txtMM.TabIndex = 9
        '
        'txtYY
        '
        Me.txtYY.Location = New System.Drawing.Point(93, 99)
        Me.txtYY.Name = "txtYY"
        Me.txtYY.Size = New System.Drawing.Size(43, 20)
        Me.txtYY.TabIndex = 8
        '
        'txtForm
        '
        Me.txtForm.FormattingEnabled = True
        Me.txtForm.Location = New System.Drawing.Point(93, 70)
        Me.txtForm.Name = "txtForm"
        Me.txtForm.Size = New System.Drawing.Size(242, 21)
        Me.txtForm.TabIndex = 7
        '
        'txtStation
        '
        Me.txtStation.FormattingEnabled = True
        Me.txtStation.Location = New System.Drawing.Point(93, 37)
        Me.txtStation.Name = "txtStation"
        Me.txtStation.Size = New System.Drawing.Size(242, 21)
        Me.txtStation.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Hour"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Day"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "FormID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Station"
        '
        'MenuPaperArchive
        '
        Me.MenuPaperArchive.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuPaperArchive.Location = New System.Drawing.Point(0, 0)
        Me.MenuPaperArchive.Name = "MenuPaperArchive"
        Me.MenuPaperArchive.Size = New System.Drawing.Size(681, 24)
        Me.MenuPaperArchive.TabIndex = 3
        Me.MenuPaperArchive.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ExitToolStripMenuItem.Text = "&Close"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'cmdFolder
        '
        Me.cmdFolder.BackgroundImage = CType(resources.GetObject("cmdFolder.BackgroundImage"), System.Drawing.Image)
        Me.cmdFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdFolder.Location = New System.Drawing.Point(567, 18)
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.Size = New System.Drawing.Size(30, 26)
        Me.cmdFolder.TabIndex = 15
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'formPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 487)
        Me.Controls.Add(Me.tabImageArchives)
        Me.Controls.Add(Me.MenuPaperArchive)
        Me.MainMenuStrip = Me.MenuPaperArchive
        Me.Name = "formPaperArchive"
        Me.Text = "Paper Archiving"
        Me.tabImageArchives.ResumeLayout(False)
        Me.tabStructured.ResumeLayout(False)
        Me.tabStructured.PerformLayout()
        Me.grpInformation.ResumeLayout(False)
        Me.grpInformation.PerformLayout()
        Me.tabUnstructured.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabViewArchive.ResumeLayout(False)
        Me.grpImage.ResumeLayout(False)
        Me.grpImage.PerformLayout()
        Me.MenuPaperArchive.ResumeLayout(False)
        Me.MenuPaperArchive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabImageArchives As System.Windows.Forms.TabControl
    Friend WithEvents tabStructured As System.Windows.Forms.TabPage
    Friend WithEvents grpInformation As System.Windows.Forms.GroupBox
    Friend WithEvents listImages As System.Windows.Forms.ListBox
    Friend WithEvents lblImageFiles As System.Windows.Forms.Label
    Friend WithEvents lblSelectedFolder As System.Windows.Forms.Label
    Friend WithEvents txtSelectedFolder As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFolder As System.Windows.Forms.Label
    Friend WithEvents tabUnstructured As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdImageFile As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdHour As System.Windows.Forms.ComboBox
    Friend WithEvents lblHour As System.Windows.Forms.Label
    Friend WithEvents lblday As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents cmbDay As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmbYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStation As System.Windows.Forms.ComboBox
    Friend WithEvents txtFormId As System.Windows.Forms.TextBox
    Friend WithEvents lblStationId As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents MenuPaperArchive As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdArchive As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabViewArchive As System.Windows.Forms.TabPage
    Friend WithEvents grpImage As System.Windows.Forms.GroupBox
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents txtHH As System.Windows.Forms.TextBox
    Friend WithEvents txtDD As System.Windows.Forms.TextBox
    Friend WithEvents txtMM As System.Windows.Forms.TextBox
    Friend WithEvents txtYY As System.Windows.Forms.TextBox
    Friend WithEvents txtForm As System.Windows.Forms.ComboBox
    Friend WithEvents txtStation As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdFolder As System.Windows.Forms.Button
End Class
