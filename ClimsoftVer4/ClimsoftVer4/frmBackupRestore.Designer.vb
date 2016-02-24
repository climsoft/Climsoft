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
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
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
        'lblfile
        '
        resources.ApplyResources(Me.lblfile, "lblfile")
        Me.lblfile.Name = "lblfile"
        '
        'txtFile
        '
        resources.ApplyResources(Me.txtFile, "txtFile")
        Me.txtFile.Name = "txtFile"
        '
        'cmdCSV
        '
        resources.ApplyResources(Me.cmdCSV, "cmdCSV")
        Me.cmdCSV.Name = "cmdCSV"
        Me.cmdCSV.UseVisualStyleBackColor = True
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
        'dlgRestore
        '
        Me.dlgRestore.FileName = "dlgResore"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtDb
        '
        resources.ApplyResources(Me.txtDb, "txtDb")
        Me.txtDb.Name = "txtDb"
        '
        'frmBackupRestore
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
