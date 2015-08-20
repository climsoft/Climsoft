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
        Me.tabImageArchives = New System.Windows.Forms.TabControl()
        Me.tabStructured = New System.Windows.Forms.TabPage()
        Me.tabUnstructured = New System.Windows.Forms.TabPage()
        Me.lblFolder = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdFolder = New System.Windows.Forms.Button()
        Me.grpInformation = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblSelectedFolder = New System.Windows.Forms.Label()
        Me.lblImageFiles = New System.Windows.Forms.Label()
        Me.listImages = New System.Windows.Forms.ListBox()
        Me.cmdArchive = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblStationId = New System.Windows.Forms.Label()
        Me.txtFormId = New System.Windows.Forms.TextBox()
        Me.cmbStation = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbDay = New System.Windows.Forms.ComboBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.lblday = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.cmdHour = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdImageFile = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmdcloses = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.tabImageArchives.SuspendLayout()
        Me.tabStructured.SuspendLayout()
        Me.tabUnstructured.SuspendLayout()
        Me.grpInformation.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabImageArchives
        '
        Me.tabImageArchives.Controls.Add(Me.tabStructured)
        Me.tabImageArchives.Controls.Add(Me.tabUnstructured)
        Me.tabImageArchives.Location = New System.Drawing.Point(1, 1)
        Me.tabImageArchives.Name = "tabImageArchives"
        Me.tabImageArchives.SelectedIndex = 0
        Me.tabImageArchives.Size = New System.Drawing.Size(664, 460)
        Me.tabImageArchives.TabIndex = 2
        '
        'tabStructured
        '
        Me.tabStructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabStructured.Controls.Add(Me.cmdClose)
        Me.tabStructured.Controls.Add(Me.cmdArchive)
        Me.tabStructured.Controls.Add(Me.grpInformation)
        Me.tabStructured.Controls.Add(Me.cmdFolder)
        Me.tabStructured.Controls.Add(Me.TextBox1)
        Me.tabStructured.Controls.Add(Me.lblFolder)
        Me.tabStructured.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabStructured.Location = New System.Drawing.Point(4, 22)
        Me.tabStructured.Name = "tabStructured"
        Me.tabStructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStructured.Size = New System.Drawing.Size(656, 434)
        Me.tabStructured.TabIndex = 0
        Me.tabStructured.Text = "Structured Filenames"
        Me.tabStructured.UseVisualStyleBackColor = True
        '
        'tabUnstructured
        '
        Me.tabUnstructured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabUnstructured.Controls.Add(Me.cmdcloses)
        Me.tabUnstructured.Controls.Add(Me.Button3)
        Me.tabUnstructured.Controls.Add(Me.Button2)
        Me.tabUnstructured.Controls.Add(Me.Button1)
        Me.tabUnstructured.Controls.Add(Me.Panel1)
        Me.tabUnstructured.Location = New System.Drawing.Point(4, 22)
        Me.tabUnstructured.Name = "tabUnstructured"
        Me.tabUnstructured.Padding = New System.Windows.Forms.Padding(3)
        Me.tabUnstructured.Size = New System.Drawing.Size(656, 434)
        Me.tabUnstructured.TabIndex = 1
        Me.tabUnstructured.Text = "Unstructured Filenames"
        Me.tabUnstructured.UseVisualStyleBackColor = True
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Location = New System.Drawing.Point(19, 34)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New System.Drawing.Size(73, 13)
        Me.lblFolder.TabIndex = 0
        Me.lblFolder.Text = "Images Folder"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(92, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(476, 20)
        Me.TextBox1.TabIndex = 1
        '
        'cmdFolder
        '
        Me.cmdFolder.Location = New System.Drawing.Point(567, 30)
        Me.cmdFolder.Name = "cmdFolder"
        Me.cmdFolder.Size = New System.Drawing.Size(57, 20)
        Me.cmdFolder.TabIndex = 2
        Me.cmdFolder.Text = "Open"
        Me.cmdFolder.UseVisualStyleBackColor = True
        '
        'grpInformation
        '
        Me.grpInformation.Controls.Add(Me.listImages)
        Me.grpInformation.Controls.Add(Me.lblImageFiles)
        Me.grpInformation.Controls.Add(Me.lblSelectedFolder)
        Me.grpInformation.Controls.Add(Me.TextBox2)
        Me.grpInformation.Location = New System.Drawing.Point(22, 72)
        Me.grpInformation.Name = "grpInformation"
        Me.grpInformation.Size = New System.Drawing.Size(602, 320)
        Me.grpInformation.TabIndex = 3
        Me.grpInformation.TabStop = False
        Me.grpInformation.Text = "Information"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(93, 38)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(478, 20)
        Me.TextBox2.TabIndex = 0
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
        'lblImageFiles
        '
        Me.lblImageFiles.AutoSize = True
        Me.lblImageFiles.Location = New System.Drawing.Point(6, 81)
        Me.lblImageFiles.Name = "lblImageFiles"
        Me.lblImageFiles.Size = New System.Drawing.Size(81, 13)
        Me.lblImageFiles.TabIndex = 2
        Me.lblImageFiles.Text = "Selected Folder"
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
        'cmdArchive
        '
        Me.cmdArchive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdArchive.Location = New System.Drawing.Point(200, 398)
        Me.cmdArchive.Name = "cmdArchive"
        Me.cmdArchive.Size = New System.Drawing.Size(83, 25)
        Me.cmdArchive.TabIndex = 4
        Me.cmdArchive.Text = "Archive"
        Me.cmdArchive.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
        Me.Panel1.Location = New System.Drawing.Point(24, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(605, 219)
        Me.Panel1.TabIndex = 0
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
        'txtFormId
        '
        Me.txtFormId.Location = New System.Drawing.Point(405, 21)
        Me.txtFormId.Name = "txtFormId"
        Me.txtFormId.Size = New System.Drawing.Size(187, 20)
        Me.txtFormId.TabIndex = 1
        '
        'cmbStation
        '
        Me.cmbStation.FormattingEnabled = True
        Me.cmbStation.Location = New System.Drawing.Point(40, 17)
        Me.cmbStation.Name = "cmbStation"
        Me.cmbStation.Size = New System.Drawing.Size(215, 21)
        Me.cmbStation.TabIndex = 2
        '
        'cmbYear
        '
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(40, 73)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(40, 21)
        Me.cmbYear.TabIndex = 3
        '
        'cmbMonth
        '
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(137, 73)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(34, 21)
        Me.cmbMonth.TabIndex = 4
        '
        'cmbDay
        '
        Me.cmbDay.FormattingEnabled = True
        Me.cmbDay.Location = New System.Drawing.Point(217, 73)
        Me.cmbDay.Name = "cmbDay"
        Me.cmbDay.Size = New System.Drawing.Size(46, 21)
        Me.cmbDay.TabIndex = 5
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(10, 77)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 6
        Me.lblYear.Text = "Year"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(97, 77)
        Me.lblMonth.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 7
        Me.lblMonth.Text = "Month"
        '
        'lblday
        '
        Me.lblday.AutoSize = True
        Me.lblday.Location = New System.Drawing.Point(189, 77)
        Me.lblday.Name = "lblday"
        Me.lblday.Size = New System.Drawing.Size(26, 13)
        Me.lblday.TabIndex = 8
        Me.lblday.Text = "Day"
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(280, 77)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(30, 13)
        Me.lblHour.TabIndex = 9
        Me.lblHour.Text = "Hour"
        '
        'cmdHour
        '
        Me.cmdHour.FormattingEnabled = True
        Me.cmdHour.Location = New System.Drawing.Point(313, 73)
        Me.cmdHour.Name = "cmdHour"
        Me.cmdHour.Size = New System.Drawing.Size(34, 21)
        Me.cmdHour.TabIndex = 10
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
        'cmdImageFile
        '
        Me.cmdImageFile.Location = New System.Drawing.Point(531, 139)
        Me.cmdImageFile.Name = "cmdImageFile"
        Me.cmdImageFile.Size = New System.Drawing.Size(61, 20)
        Me.cmdImageFile.TabIndex = 14
        Me.cmdImageFile.Text = "Open"
        Me.cmdImageFile.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 139)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Image"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(45, 139)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(480, 20)
        Me.TextBox3.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 301)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 25)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Archive"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(45, 181)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(126, 17)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Restructure Filename"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(200, 301)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(88, 25)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Update"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(356, 301)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 25)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Delete"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdcloses
        '
        Me.cmdcloses.Location = New System.Drawing.Point(512, 301)
        Me.cmdcloses.Name = "cmdcloses"
        Me.cmdcloses.Size = New System.Drawing.Size(88, 25)
        Me.cmdcloses.TabIndex = 4
        Me.cmdcloses.Text = "Close"
        Me.cmdcloses.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Location = New System.Drawing.Point(354, 396)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(83, 25)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'formPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(673, 464)
        Me.Controls.Add(Me.tabImageArchives)
        Me.Name = "formPaperArchive"
        Me.Text = "Paper Archiving"
        Me.tabImageArchives.ResumeLayout(False)
        Me.tabStructured.ResumeLayout(False)
        Me.tabStructured.PerformLayout()
        Me.tabUnstructured.ResumeLayout(False)
        Me.grpInformation.ResumeLayout(False)
        Me.grpInformation.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabImageArchives As System.Windows.Forms.TabControl
    Friend WithEvents tabStructured As System.Windows.Forms.TabPage
    Friend WithEvents cmdArchive As System.Windows.Forms.Button
    Friend WithEvents grpInformation As System.Windows.Forms.GroupBox
    Friend WithEvents listImages As System.Windows.Forms.ListBox
    Friend WithEvents lblImageFiles As System.Windows.Forms.Label
    Friend WithEvents lblSelectedFolder As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdFolder As System.Windows.Forms.Button
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
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdcloses As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
