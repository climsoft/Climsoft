<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaunchPad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaunchPad))
        Me.btnStationInformation = New System.Windows.Forms.Button()
        Me.btnElementInformation = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.btnSynopticData = New System.Windows.Forms.Button()
        Me.lblServer = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblDatabase = New System.Windows.Forms.Label()
        Me.lblConection = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStationInformation
        '
        Me.btnStationInformation.Location = New System.Drawing.Point(131, 252)
        Me.btnStationInformation.Name = "btnStationInformation"
        Me.btnStationInformation.Size = New System.Drawing.Size(111, 23)
        Me.btnStationInformation.TabIndex = 0
        Me.btnStationInformation.Text = "Station Information"
        Me.btnStationInformation.UseVisualStyleBackColor = True
        Me.btnStationInformation.Visible = False
        '
        'btnElementInformation
        '
        Me.btnElementInformation.Location = New System.Drawing.Point(0, 252)
        Me.btnElementInformation.Name = "btnElementInformation"
        Me.btnElementInformation.Size = New System.Drawing.Size(125, 23)
        Me.btnElementInformation.TabIndex = 1
        Me.btnElementInformation.Text = "Element Information"
        Me.btnElementInformation.UseVisualStyleBackColor = True
        Me.btnElementInformation.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.btnUpdate, Me.ToolStripSeparator1, Me.btnClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 189)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(391, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(103, 22)
        Me.ToolStripLabel1.Text = "                                "
        '
        'btnUpdate
        '
        Me.btnUpdate.BackColor = System.Drawing.SystemColors.MenuBar
        Me.btnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(49, 22)
        Me.btnUpdate.Text = "Update"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripSeparator1.Text = "                  "
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.MenuBar
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 22)
        Me.btnClose.Text = "Close"
        '
        'btnSynopticData
        '
        Me.btnSynopticData.Location = New System.Drawing.Point(322, 246)
        Me.btnSynopticData.Name = "btnSynopticData"
        Me.btnSynopticData.Size = New System.Drawing.Size(54, 23)
        Me.btnSynopticData.TabIndex = 5
        Me.btnSynopticData.Text = "Update"
        Me.btnSynopticData.UseVisualStyleBackColor = True
        Me.btnSynopticData.Visible = False
        '
        'lblServer
        '
        Me.lblServer.AutoSize = True
        Me.lblServer.Location = New System.Drawing.Point(55, 46)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(38, 13)
        Me.lblServer.TabIndex = 6
        Me.lblServer.Text = "Server"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.Location = New System.Drawing.Point(55, 130)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 13)
        Me.lblPort.TabIndex = 8
        Me.lblPort.Text = "Port"
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(139, 42)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(153, 20)
        Me.txtServer.TabIndex = 9
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(139, 84)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(153, 20)
        Me.txtDatabase.TabIndex = 10
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(139, 126)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(153, 20)
        Me.txtPort.TabIndex = 11
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(55, 88)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(53, 13)
        Me.lblDatabase.TabIndex = 7
        Me.lblDatabase.Text = "Database"
        '
        'lblConection
        '
        Me.lblConection.AutoSize = True
        Me.lblConection.Location = New System.Drawing.Point(12, 166)
        Me.lblConection.Name = "lblConection"
        Me.lblConection.Size = New System.Drawing.Size(0, 13)
        Me.lblConection.TabIndex = 12
        Me.lblConection.Visible = False
        '
        'frmLaunchPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 214)
        Me.Controls.Add(Me.lblConection)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.lblDatabase)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.btnSynopticData)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnElementInformation)
        Me.Controls.Add(Me.btnStationInformation)
        Me.MaximizeBox = False
        Me.Name = "frmLaunchPad"
        Me.Text = "Database Connection Details"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStationInformation As System.Windows.Forms.Button
    Friend WithEvents btnElementInformation As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSynopticData As System.Windows.Forms.Button
    Friend WithEvents lblServer As System.Windows.Forms.Label
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtDatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents lblConection As System.Windows.Forms.Label
End Class
