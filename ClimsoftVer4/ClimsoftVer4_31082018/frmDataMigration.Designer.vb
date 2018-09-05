<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataMigration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataMigration))
        Me.grpV3MysqlDb = New System.Windows.Forms.GroupBox()
        Me.txtEyear = New System.Windows.Forms.TextBox()
        Me.txtByear = New System.Windows.Forms.TextBox()
        Me.lblEyear = New System.Windows.Forms.Label()
        Me.lblByear = New System.Windows.Forms.Label()
        Me.lblV4 = New System.Windows.Forms.Label()
        Me.txtV4db = New System.Windows.Forms.TextBox()
        Me.txtV3db = New System.Windows.Forms.TextBox()
        Me.lblV3 = New System.Windows.Forms.Label()
        Me.optSeletedRecords = New System.Windows.Forms.RadioButton()
        Me.optEntireDb = New System.Windows.Forms.RadioButton()
        Me.grpV3Backup = New System.Windows.Forms.GroupBox()
        Me.cmdCSV = New System.Windows.Forms.Button()
        Me.lblBkpFile = New System.Windows.Forms.Label()
        Me.txtBkpFile = New System.Windows.Forms.TextBox()
        Me.lstMsgs = New System.Windows.Forms.ListBox()
        Me.pnlCommands = New System.Windows.Forms.Panel()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.optV3MysqlDb = New System.Windows.Forms.RadioButton()
        Me.optV3Backup = New System.Windows.Forms.RadioButton()
        Me.lblMessages = New System.Windows.Forms.Label()
        Me.OpenFileBackup = New System.Windows.Forms.OpenFileDialog()
        Me.chkboxReplace = New System.Windows.Forms.CheckBox()
        Me.grpV3MysqlDb.SuspendLayout()
        Me.grpV3Backup.SuspendLayout()
        Me.pnlCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpV3MysqlDb
        '
        Me.grpV3MysqlDb.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpV3MysqlDb.Controls.Add(Me.txtEyear)
        Me.grpV3MysqlDb.Controls.Add(Me.txtByear)
        Me.grpV3MysqlDb.Controls.Add(Me.lblEyear)
        Me.grpV3MysqlDb.Controls.Add(Me.lblByear)
        Me.grpV3MysqlDb.Controls.Add(Me.lblV4)
        Me.grpV3MysqlDb.Controls.Add(Me.txtV4db)
        Me.grpV3MysqlDb.Controls.Add(Me.txtV3db)
        Me.grpV3MysqlDb.Controls.Add(Me.lblV3)
        Me.grpV3MysqlDb.Controls.Add(Me.optSeletedRecords)
        Me.grpV3MysqlDb.Controls.Add(Me.optEntireDb)
        Me.grpV3MysqlDb.Location = New System.Drawing.Point(24, 44)
        Me.grpV3MysqlDb.Name = "grpV3MysqlDb"
        Me.grpV3MysqlDb.Size = New System.Drawing.Size(555, 154)
        Me.grpV3MysqlDb.TabIndex = 2
        Me.grpV3MysqlDb.TabStop = False
        '
        'txtEyear
        '
        Me.txtEyear.Location = New System.Drawing.Point(345, 110)
        Me.txtEyear.Name = "txtEyear"
        Me.txtEyear.Size = New System.Drawing.Size(36, 20)
        Me.txtEyear.TabIndex = 3
        Me.txtEyear.Text = "2012"
        '
        'txtByear
        '
        Me.txtByear.Location = New System.Drawing.Point(231, 110)
        Me.txtByear.Name = "txtByear"
        Me.txtByear.Size = New System.Drawing.Size(41, 20)
        Me.txtByear.TabIndex = 2
        Me.txtByear.Text = "1900"
        '
        'lblEyear
        '
        Me.lblEyear.AutoSize = True
        Me.lblEyear.Location = New System.Drawing.Point(297, 112)
        Me.lblEyear.Name = "lblEyear"
        Me.lblEyear.Size = New System.Drawing.Size(51, 13)
        Me.lblEyear.TabIndex = 8
        Me.lblEyear.Text = "End Year"
        '
        'lblByear
        '
        Me.lblByear.AutoSize = True
        Me.lblByear.Location = New System.Drawing.Point(167, 113)
        Me.lblByear.Name = "lblByear"
        Me.lblByear.Size = New System.Drawing.Size(65, 13)
        Me.lblByear.TabIndex = 7
        Me.lblByear.Text = "Beging Year"
        '
        'lblV4
        '
        Me.lblV4.AutoSize = True
        Me.lblV4.Location = New System.Drawing.Point(306, 41)
        Me.lblV4.Name = "lblV4"
        Me.lblV4.Size = New System.Drawing.Size(35, 13)
        Me.lblV4.TabIndex = 6
        Me.lblV4.Text = "V4 db"
        '
        'txtV4db
        '
        Me.txtV4db.Location = New System.Drawing.Point(345, 37)
        Me.txtV4db.Name = "txtV4db"
        Me.txtV4db.Size = New System.Drawing.Size(185, 20)
        Me.txtV4db.TabIndex = 1
        Me.txtV4db.Text = "maria_climsoft_db_v4"
        '
        'txtV3db
        '
        Me.txtV3db.Location = New System.Drawing.Point(72, 37)
        Me.txtV3db.Name = "txtV3db"
        Me.txtV3db.Size = New System.Drawing.Size(219, 20)
        Me.txtV3db.TabIndex = 0
        Me.txtV3db.Text = "mysql_main_climsoft_database_v3"
        '
        'lblV3
        '
        Me.lblV3.AutoSize = True
        Me.lblV3.Location = New System.Drawing.Point(36, 41)
        Me.lblV3.Name = "lblV3"
        Me.lblV3.Size = New System.Drawing.Size(35, 13)
        Me.lblV3.TabIndex = 3
        Me.lblV3.Text = "V3 db"
        '
        'optSeletedRecords
        '
        Me.optSeletedRecords.AutoSize = True
        Me.optSeletedRecords.Location = New System.Drawing.Point(33, 111)
        Me.optSeletedRecords.Name = "optSeletedRecords"
        Me.optSeletedRecords.Size = New System.Drawing.Size(113, 17)
        Me.optSeletedRecords.TabIndex = 9
        Me.optSeletedRecords.TabStop = True
        Me.optSeletedRecords.Text = "Selected Records:"
        Me.optSeletedRecords.UseVisualStyleBackColor = True
        '
        'optEntireDb
        '
        Me.optEntireDb.AutoSize = True
        Me.optEntireDb.Location = New System.Drawing.Point(33, 76)
        Me.optEntireDb.Name = "optEntireDb"
        Me.optEntireDb.Size = New System.Drawing.Size(101, 17)
        Me.optEntireDb.TabIndex = 8
        Me.optEntireDb.TabStop = True
        Me.optEntireDb.Text = "Entire Database"
        Me.optEntireDb.UseVisualStyleBackColor = True
        '
        'grpV3Backup
        '
        Me.grpV3Backup.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpV3Backup.Controls.Add(Me.cmdCSV)
        Me.grpV3Backup.Controls.Add(Me.lblBkpFile)
        Me.grpV3Backup.Controls.Add(Me.txtBkpFile)
        Me.grpV3Backup.Enabled = False
        Me.grpV3Backup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpV3Backup.Location = New System.Drawing.Point(24, 236)
        Me.grpV3Backup.Name = "grpV3Backup"
        Me.grpV3Backup.Size = New System.Drawing.Size(555, 98)
        Me.grpV3Backup.TabIndex = 3
        Me.grpV3Backup.TabStop = False
        '
        'cmdCSV
        '
        Me.cmdCSV.BackgroundImage = CType(resources.GetObject("cmdCSV.BackgroundImage"), System.Drawing.Image)
        Me.cmdCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCSV.Location = New System.Drawing.Point(439, 32)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(36, 29)
        Me.cmdCSV.TabIndex = 6
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'lblBkpFile
        '
        Me.lblBkpFile.AutoSize = True
        Me.lblBkpFile.Location = New System.Drawing.Point(6, 40)
        Me.lblBkpFile.Name = "lblBkpFile"
        Me.lblBkpFile.Size = New System.Drawing.Size(63, 13)
        Me.lblBkpFile.TabIndex = 1
        Me.lblBkpFile.Text = "Backup File"
        '
        'txtBkpFile
        '
        Me.txtBkpFile.Location = New System.Drawing.Point(80, 36)
        Me.txtBkpFile.Name = "txtBkpFile"
        Me.txtBkpFile.Size = New System.Drawing.Size(362, 20)
        Me.txtBkpFile.TabIndex = 4
        '
        'lstMsgs
        '
        Me.lstMsgs.AllowDrop = True
        Me.lstMsgs.FormattingEnabled = True
        Me.lstMsgs.HorizontalScrollbar = True
        Me.lstMsgs.Location = New System.Drawing.Point(585, 44)
        Me.lstMsgs.Name = "lstMsgs"
        Me.lstMsgs.Size = New System.Drawing.Size(381, 290)
        Me.lstMsgs.TabIndex = 4
        '
        'pnlCommands
        '
        Me.pnlCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCommands.Controls.Add(Me.cmdHelp)
        Me.pnlCommands.Controls.Add(Me.cmdCancel)
        Me.pnlCommands.Controls.Add(Me.cmdStart)
        Me.pnlCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCommands.Location = New System.Drawing.Point(0, 366)
        Me.pnlCommands.Name = "pnlCommands"
        Me.pnlCommands.Size = New System.Drawing.Size(978, 31)
        Me.pnlCommands.TabIndex = 5
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(485, 3)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(71, 23)
        Me.cmdHelp.TabIndex = 7
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(368, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(231, 3)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(71, 23)
        Me.cmdStart.TabIndex = 5
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'optV3MysqlDb
        '
        Me.optV3MysqlDb.AutoSize = True
        Me.optV3MysqlDb.Checked = True
        Me.optV3MysqlDb.Location = New System.Drawing.Point(25, 23)
        Me.optV3MysqlDb.Name = "optV3MysqlDb"
        Me.optV3MysqlDb.Size = New System.Drawing.Size(301, 17)
        Me.optV3MysqlDb.TabIndex = 6
        Me.optV3MysqlDb.TabStop = True
        Me.optV3MysqlDb.Text = "CLIMSOFT V3 MySQL Database - Within the same server)"
        Me.optV3MysqlDb.UseVisualStyleBackColor = True
        '
        'optV3Backup
        '
        Me.optV3Backup.AutoSize = True
        Me.optV3Backup.Location = New System.Drawing.Point(24, 213)
        Me.optV3Backup.Name = "optV3Backup"
        Me.optV3Backup.Size = New System.Drawing.Size(134, 17)
        Me.optV3Backup.TabIndex = 7
        Me.optV3Backup.Text = "CLIMSOFT V3 Backup"
        Me.optV3Backup.UseVisualStyleBackColor = True
        '
        'lblMessages
        '
        Me.lblMessages.AutoSize = True
        Me.lblMessages.Location = New System.Drawing.Point(691, 28)
        Me.lblMessages.Name = "lblMessages"
        Me.lblMessages.Size = New System.Drawing.Size(55, 13)
        Me.lblMessages.TabIndex = 8
        Me.lblMessages.Text = "Messages"
        '
        'OpenFileBackup
        '
        Me.OpenFileBackup.FileName = "Climsoft Backup"
        '
        'chkboxReplace
        '
        Me.chkboxReplace.AutoSize = True
        Me.chkboxReplace.Location = New System.Drawing.Point(25, 340)
        Me.chkboxReplace.Name = "chkboxReplace"
        Me.chkboxReplace.Size = New System.Drawing.Size(148, 17)
        Me.chkboxReplace.TabIndex = 9
        Me.chkboxReplace.Text = "Replace Existing Records"
        Me.chkboxReplace.UseVisualStyleBackColor = True
        '
        'frmDataMigration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 397)
        Me.Controls.Add(Me.chkboxReplace)
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.optV3Backup)
        Me.Controls.Add(Me.optV3MysqlDb)
        Me.Controls.Add(Me.pnlCommands)
        Me.Controls.Add(Me.lstMsgs)
        Me.Controls.Add(Me.grpV3Backup)
        Me.Controls.Add(Me.grpV3MysqlDb)
        Me.Name = "frmDataMigration"
        Me.Text = "Data Migration"
        Me.grpV3MysqlDb.ResumeLayout(False)
        Me.grpV3MysqlDb.PerformLayout()
        Me.grpV3Backup.ResumeLayout(False)
        Me.grpV3Backup.PerformLayout()
        Me.pnlCommands.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpV3MysqlDb As System.Windows.Forms.GroupBox
    Friend WithEvents optSeletedRecords As System.Windows.Forms.RadioButton
    Friend WithEvents optEntireDb As System.Windows.Forms.RadioButton
    Friend WithEvents grpV3Backup As System.Windows.Forms.GroupBox
    Friend WithEvents lblBkpFile As System.Windows.Forms.Label
    Friend WithEvents txtBkpFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdCSV As System.Windows.Forms.Button
    Friend WithEvents lblV4 As System.Windows.Forms.Label
    Friend WithEvents txtV4db As System.Windows.Forms.TextBox
    Friend WithEvents txtV3db As System.Windows.Forms.TextBox
    Friend WithEvents lblV3 As System.Windows.Forms.Label
    Friend WithEvents txtEyear As System.Windows.Forms.TextBox
    Friend WithEvents txtByear As System.Windows.Forms.TextBox
    Friend WithEvents lblEyear As System.Windows.Forms.Label
    Friend WithEvents lblByear As System.Windows.Forms.Label
    Friend WithEvents lstMsgs As System.Windows.Forms.ListBox
    Friend WithEvents pnlCommands As System.Windows.Forms.Panel
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents optV3MysqlDb As System.Windows.Forms.RadioButton
    Friend WithEvents optV3Backup As System.Windows.Forms.RadioButton
    Friend WithEvents lblMessages As System.Windows.Forms.Label
    Friend WithEvents OpenFileBackup As System.Windows.Forms.OpenFileDialog
    Friend WithEvents chkboxReplace As System.Windows.Forms.CheckBox
End Class
