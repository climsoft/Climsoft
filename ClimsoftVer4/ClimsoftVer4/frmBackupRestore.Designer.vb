<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackupRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackupRestore))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdHelp = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.lblfile = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.cmdCSV = New System.Windows.Forms.Button()
        Me.txtEyear = New System.Windows.Forms.TextBox()
        Me.txtByear = New System.Windows.Forms.TextBox()
        Me.lblEyear = New System.Windows.Forms.Label()
        Me.lblByear = New System.Windows.Forms.Label()
        Me.dlgRestore = New System.Windows.Forms.OpenFileDialog()
        Me.dlgBackup = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDb = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdHelp)
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdStart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 209)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(607, 26)
        Me.Panel1.TabIndex = 0
        '
        'cmdHelp
        '
        Me.cmdHelp.Location = New System.Drawing.Point(412, 2)
        Me.cmdHelp.Name = "cmdHelp"
        Me.cmdHelp.Size = New System.Drawing.Size(71, 23)
        Me.cmdHelp.TabIndex = 10
        Me.cmdHelp.Text = "Help"
        Me.cmdHelp.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(295, 2)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(71, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.Location = New System.Drawing.Point(158, 2)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(71, 23)
        Me.cmdStart.TabIndex = 8
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = True
        '
        'lblfile
        '
        Me.lblfile.AutoSize = True
        Me.lblfile.Location = New System.Drawing.Point(34, 91)
        Me.lblfile.Name = "lblfile"
        Me.lblfile.Size = New System.Drawing.Size(63, 13)
        Me.lblfile.TabIndex = 1
        Me.lblfile.Text = "Backup File"
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(127, 87)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(403, 20)
        Me.txtFile.TabIndex = 2
        '
        'cmdCSV
        '
        Me.cmdCSV.BackgroundImage = CType(resources.GetObject("cmdCSV.BackgroundImage"), System.Drawing.Image)
        Me.cmdCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdCSV.Location = New System.Drawing.Point(529, 83)
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.Size = New System.Drawing.Size(36, 29)
        Me.cmdCSV.TabIndex = 7
        Me.cmdCSV.UseVisualStyleBackColor = True
        '
        'txtEyear
        '
        Me.txtEyear.Location = New System.Drawing.Point(391, 141)
        Me.txtEyear.Name = "txtEyear"
        Me.txtEyear.Size = New System.Drawing.Size(36, 20)
        Me.txtEyear.TabIndex = 10
        Me.txtEyear.Text = "2012"
        '
        'txtByear
        '
        Me.txtByear.Location = New System.Drawing.Point(194, 138)
        Me.txtByear.Name = "txtByear"
        Me.txtByear.Size = New System.Drawing.Size(41, 20)
        Me.txtByear.TabIndex = 9
        Me.txtByear.Text = "1900"
        '
        'lblEyear
        '
        Me.lblEyear.AutoSize = True
        Me.lblEyear.Location = New System.Drawing.Point(343, 143)
        Me.lblEyear.Name = "lblEyear"
        Me.lblEyear.Size = New System.Drawing.Size(51, 13)
        Me.lblEyear.TabIndex = 12
        Me.lblEyear.Text = "End Year"
        '
        'lblByear
        '
        Me.lblByear.AutoSize = True
        Me.lblByear.Location = New System.Drawing.Point(130, 141)
        Me.lblByear.Name = "lblByear"
        Me.lblByear.Size = New System.Drawing.Size(65, 13)
        Me.lblByear.TabIndex = 11
        Me.lblByear.Text = "Beging Year"
        '
        'dlgRestore
        '
        Me.dlgRestore.FileName = "dlgResore"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Current database"
        '
        'txtDb
        '
        Me.txtDb.Location = New System.Drawing.Point(127, 40)
        Me.txtDb.Name = "txtDb"
        Me.txtDb.Size = New System.Drawing.Size(153, 20)
        Me.txtDb.TabIndex = 14
        Me.txtDb.Text = "mariadb_climsoft_db_v4"
        '
        'frmBackupRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(607, 235)
        Me.Controls.Add(Me.txtDb)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEyear)
        Me.Controls.Add(Me.txtByear)
        Me.Controls.Add(Me.lblEyear)
        Me.Controls.Add(Me.lblByear)
        Me.Controls.Add(Me.cmdCSV)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.lblfile)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBackupRestore"
        Me.Text = "Backup and Restore"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdHelp As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents lblfile As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents cmdCSV As System.Windows.Forms.Button
    Friend WithEvents txtEyear As System.Windows.Forms.TextBox
    Friend WithEvents txtByear As System.Windows.Forms.TextBox
    Friend WithEvents lblEyear As System.Windows.Forms.Label
    Friend WithEvents lblByear As System.Windows.Forms.Label
    Friend WithEvents dlgRestore As System.Windows.Forms.OpenFileDialog
    Friend WithEvents dlgBackup As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDb As System.Windows.Forms.TextBox
End Class
