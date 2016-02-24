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
        resources.ApplyResources(Me.grpV3MysqlDb, "grpV3MysqlDb")
        Me.grpV3MysqlDb.Name = "grpV3MysqlDb"
        Me.grpV3MysqlDb.TabStop = False
        '
        'txtEyear
        '
        resources.ApplyResources(Me.txtEyear, "txtEyear")
        Me.txtEyear.Name = "txtEyear"
        '
        'txtByear
        '
        resources.ApplyResources(Me.txtByear, "txtByear")
        Me.txtByear.Name = "txtByear"
        '
        'lblEyear
        '
        resources.ApplyResources(Me.lblEyear, "lblEyear")
        Me.lblEyear.Name = "lblEyear"
        '
        'lblByear
        '
        resources.ApplyResources(Me.lblByear, "lblByear")
        Me.lblByear.Name = "lblByear"
        '
        'lblV4
        '
        resources.ApplyResources(Me.lblV4, "lblV4")
        Me.lblV4.Name = "lblV4"
        '
        'txtV4db
        '
        resources.ApplyResources(Me.txtV4db, "txtV4db")
        Me.txtV4db.Name = "txtV4db"
        '
        'txtV3db
        '
        resources.ApplyResources(Me.txtV3db, "txtV3db")
        Me.txtV3db.Name = "txtV3db"
        '
        'lblV3
        '
        resources.ApplyResources(Me.lblV3, "lblV3")
        Me.lblV3.Name = "lblV3"
        '
        'optSeletedRecords
        '
        resources.ApplyResources(Me.optSeletedRecords, "optSeletedRecords")
        Me.optSeletedRecords.Name = "optSeletedRecords"
        Me.optSeletedRecords.TabStop = True
        Me.optSeletedRecords.UseVisualStyleBackColor = True
        '
        'optEntireDb
        '
        resources.ApplyResources(Me.optEntireDb, "optEntireDb")
        Me.optEntireDb.Name = "optEntireDb"
        Me.optEntireDb.TabStop = True
        Me.optEntireDb.UseVisualStyleBackColor = True
        '
        'grpV3Backup
        '
        Me.grpV3Backup.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.grpV3Backup.Controls.Add(Me.cmdCSV)
        Me.grpV3Backup.Controls.Add(Me.lblBkpFile)
        Me.grpV3Backup.Controls.Add(Me.txtBkpFile)
        resources.ApplyResources(Me.grpV3Backup, "grpV3Backup")
        Me.grpV3Backup.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpV3Backup.Name = "grpV3Backup"
        Me.grpV3Backup.TabStop = False
        '
        'cmdCSV
        '
        resources.ApplyResources(Me.cmdCSV, "cmdCSV")
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'lblBkpFile
        '
        resources.ApplyResources(Me.lblBkpFile, "lblBkpFile")
        Me.lblBkpFile.Name = "lblBkpFile"
        '
        'txtBkpFile
        '
        resources.ApplyResources(Me.txtBkpFile, "txtBkpFile")
        Me.txtBkpFile.Name = "txtBkpFile"
        '
        'lstMsgs
        '
        Me.lstMsgs.AllowDrop = True
        Me.lstMsgs.FormattingEnabled = True
        resources.ApplyResources(Me.lstMsgs, "lstMsgs")
        Me.lstMsgs.Name = "lstMsgs"
        '
        'pnlCommands
        '
        Me.pnlCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCommands.Controls.Add(Me.cmdHelp)
        Me.pnlCommands.Controls.Add(Me.cmdCancel)
        Me.pnlCommands.Controls.Add(Me.cmdStart)
        resources.ApplyResources(Me.pnlCommands, "pnlCommands")
        Me.pnlCommands.Name = "pnlCommands"
        '
        'cmdHelp
        '
        resources.ApplyResources(Me.cmdHelp, "cmdHelp")
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        resources.ApplyResources(Me.cmdStart, "cmdStart")
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'optV3MysqlDb
        '
        resources.ApplyResources(Me.optV3MysqlDb, "optV3MysqlDb")
        Me.optV3MysqlDb.Checked = True
        Me.optV3MysqlDb.Name = "optV3MysqlDb"
        Me.optV3MysqlDb.TabStop = True
        Me.optV3MysqlDb.UseVisualStyleBackColor = True
        '
        'optV3Backup
        '
        resources.ApplyResources(Me.optV3Backup, "optV3Backup")
        Me.optV3Backup.Name = "optV3Backup"
        Me.optV3Backup.UseVisualStyleBackColor = True
        '
        'lblMessages
        '
        resources.ApplyResources(Me.lblMessages, "lblMessages")
        Me.lblMessages.Name = "lblMessages"
        '
        'OpenFileBackup
        '
        Me.OpenFileBackup.FileName = "Climsoft Backup"
        '
        'frmDataMigration
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblMessages)
        Me.Controls.Add(Me.optV3Backup)
        Me.Controls.Add(Me.optV3MysqlDb)
        Me.Controls.Add(Me.pnlCommands)
        Me.Controls.Add(Me.lstMsgs)
        Me.Controls.Add(Me.grpV3Backup)
        Me.Controls.Add(Me.grpV3MysqlDb)
        Me.Name = "frmDataMigration"
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
End Class
