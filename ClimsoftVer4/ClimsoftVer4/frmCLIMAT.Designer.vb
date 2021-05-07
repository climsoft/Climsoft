<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCLIMAT
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
        Me.lstvStations = New System.Windows.Forms.ListView()
        Me.cmbstation = New System.Windows.Forms.ComboBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.chk444 = New System.Windows.Forms.CheckBox()
        Me.chk333 = New System.Windows.Forms.CheckBox()
        Me.chk222 = New System.Windows.Forms.CheckBox()
        Me.grpStatistics = New System.Windows.Forms.GroupBox()
        Me.butStatistics = New System.Windows.Forms.Button()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.txtBeginYear = New System.Windows.Forms.TextBox()
        Me.lblBeginYear = New System.Windows.Forms.Label()
        Me.lblPeriod = New System.Windows.Forms.Label()
        Me.butEncode = New System.Windows.Forms.Button()
        Me.butClose = New System.Windows.Forms.Button()
        Me.lstMessages = New System.Windows.Forms.ListBox()
        Me.grpCLIMATMonth = New System.Windows.Forms.GroupBox()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.butClear = New System.Windows.Forms.Button()
        Me.lblCLIMATmsg = New System.Windows.Forms.Label()
        Me.txtCLIMAT = New System.Windows.Forms.TextBox()
        Me.butSend = New System.Windows.Forms.Button()
        Me.butSetting = New System.Windows.Forms.Button()
        Me.butHelp = New System.Windows.Forms.Button()
        Me.grpOptions.SuspendLayout()
        Me.grpStatistics.SuspendLayout()
        Me.grpCLIMATMonth.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstvStations
        '
        Me.lstvStations.AllowColumnReorder = True
        Me.lstvStations.AllowDrop = True
        Me.lstvStations.FullRowSelect = True
        Me.lstvStations.GridLines = True
        Me.lstvStations.HideSelection = False
        Me.lstvStations.HoverSelection = True
        Me.lstvStations.LabelEdit = True
        Me.lstvStations.Location = New System.Drawing.Point(32, 68)
        Me.lstvStations.Name = "lstvStations"
        Me.lstvStations.RightToLeftLayout = True
        Me.lstvStations.Size = New System.Drawing.Size(354, 134)
        Me.lstvStations.TabIndex = 19
        Me.lstvStations.UseCompatibleStateImageBehavior = False
        Me.lstvStations.View = System.Windows.Forms.View.Details
        '
        'cmbstation
        '
        Me.cmbstation.FormattingEnabled = True
        Me.cmbstation.ItemHeight = 13
        Me.cmbstation.Location = New System.Drawing.Point(105, 41)
        Me.cmbstation.Name = "cmbstation"
        Me.cmbstation.Size = New System.Drawing.Size(281, 21)
        Me.cmbstation.TabIndex = 18
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(26, 44)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 20
        Me.lblStation.Text = "Select Station"
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.chk444)
        Me.grpOptions.Controls.Add(Me.chk333)
        Me.grpOptions.Controls.Add(Me.chk222)
        Me.grpOptions.Location = New System.Drawing.Point(29, 238)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(345, 106)
        Me.grpOptions.TabIndex = 25
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Include Optional Sections - If sufficient climate statistics are available "
        '
        'chk444
        '
        Me.chk444.AutoSize = True
        Me.chk444.Location = New System.Drawing.Point(14, 81)
        Me.chk444.Name = "chk444"
        Me.chk444.Size = New System.Drawing.Size(204, 17)
        Me.chk444.TabIndex = 2
        Me.chk444.Text = "444 - Extreme values and frequencies"
        Me.chk444.UseVisualStyleBackColor = True
        '
        'chk333
        '
        Me.chk333.AutoSize = True
        Me.chk333.Location = New System.Drawing.Point(14, 58)
        Me.chk333.Name = "chk333"
        Me.chk333.Size = New System.Drawing.Size(278, 17)
        Me.chk333.TabIndex = 1
        Me.chk333.Text = "333 - Days with parameters beyond certain thresholds"
        Me.chk333.UseVisualStyleBackColor = True
        '
        'chk222
        '
        Me.chk222.AutoSize = True
        Me.chk222.Location = New System.Drawing.Point(14, 35)
        Me.chk222.Name = "chk222"
        Me.chk222.Size = New System.Drawing.Size(128, 17)
        Me.chk222.TabIndex = 0
        Me.chk222.Text = "222 - Climate Normals"
        Me.chk222.UseVisualStyleBackColor = True
        '
        'grpStatistics
        '
        Me.grpStatistics.Controls.Add(Me.butStatistics)
        Me.grpStatistics.Controls.Add(Me.txtEndYear)
        Me.grpStatistics.Controls.Add(Me.lblEndYear)
        Me.grpStatistics.Controls.Add(Me.txtBeginYear)
        Me.grpStatistics.Controls.Add(Me.lblBeginYear)
        Me.grpStatistics.Controls.Add(Me.lblPeriod)
        Me.grpStatistics.Location = New System.Drawing.Point(380, 229)
        Me.grpStatistics.Name = "grpStatistics"
        Me.grpStatistics.Size = New System.Drawing.Size(274, 115)
        Me.grpStatistics.TabIndex = 26
        Me.grpStatistics.TabStop = False
        Me.grpStatistics.Text = "Generate long term statistics for CLIMAT message"
        '
        'butStatistics
        '
        Me.butStatistics.Location = New System.Drawing.Point(182, 72)
        Me.butStatistics.Name = "butStatistics"
        Me.butStatistics.Size = New System.Drawing.Size(35, 22)
        Me.butStatistics.TabIndex = 29
        Me.butStatistics.Text = "OK"
        Me.butStatistics.UseVisualStyleBackColor = True
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(92, 87)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(40, 20)
        Me.txtEndYear.TabIndex = 28
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(24, 94)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(51, 13)
        Me.lblEndYear.TabIndex = 27
        Me.lblEndYear.Text = "End Year"
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(92, 61)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(40, 20)
        Me.txtBeginYear.TabIndex = 26
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(24, 65)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(59, 13)
        Me.lblBeginYear.TabIndex = 25
        Me.lblBeginYear.Text = "Begin Year"
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(23, 32)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(227, 13)
        Me.lblPeriod.TabIndex = 21
        Me.lblPeriod.Text = "Specify climate base period with sufficient data"
        '
        'butEncode
        '
        Me.butEncode.Location = New System.Drawing.Point(30, 350)
        Me.butEncode.Name = "butEncode"
        Me.butEncode.Size = New System.Drawing.Size(97, 22)
        Me.butEncode.TabIndex = 30
        Me.butEncode.Text = "Encode CLIMAT "
        Me.butEncode.UseVisualStyleBackColor = True
        '
        'butClose
        '
        Me.butClose.Location = New System.Drawing.Point(233, 350)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(51, 22)
        Me.butClose.TabIndex = 31
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'lstMessages
        '
        Me.lstMessages.FormattingEnabled = True
        Me.lstMessages.Location = New System.Drawing.Point(8, 378)
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.Size = New System.Drawing.Size(646, 108)
        Me.lstMessages.TabIndex = 32
        '
        'grpCLIMATMonth
        '
        Me.grpCLIMATMonth.Controls.Add(Me.txtMonth)
        Me.grpCLIMATMonth.Controls.Add(Me.lblMonth)
        Me.grpCLIMATMonth.Controls.Add(Me.txtYear)
        Me.grpCLIMATMonth.Controls.Add(Me.lblYear)
        Me.grpCLIMATMonth.Location = New System.Drawing.Point(407, 75)
        Me.grpCLIMATMonth.Name = "grpCLIMATMonth"
        Me.grpCLIMATMonth.Size = New System.Drawing.Size(244, 58)
        Me.grpCLIMATMonth.TabIndex = 33
        Me.grpCLIMATMonth.TabStop = False
        Me.grpCLIMATMonth.Text = "CLIMAT message period"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(182, 23)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(34, 20)
        Me.txtMonth.TabIndex = 26
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(146, 27)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 25
        Me.lblMonth.Text = "Month"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(58, 23)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(40, 20)
        Me.txtYear.TabIndex = 24
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(22, 27)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 23
        Me.lblYear.Text = "Year"
        '
        'butClear
        '
        Me.butClear.Location = New System.Drawing.Point(157, 350)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(51, 22)
        Me.butClear.TabIndex = 34
        Me.butClear.Text = "Clear"
        Me.butClear.UseVisualStyleBackColor = True
        '
        'lblCLIMATmsg
        '
        Me.lblCLIMATmsg.AutoSize = True
        Me.lblCLIMATmsg.Location = New System.Drawing.Point(5, 500)
        Me.lblCLIMATmsg.Name = "lblCLIMATmsg"
        Me.lblCLIMATmsg.Size = New System.Drawing.Size(111, 13)
        Me.lblCLIMATmsg.TabIndex = 35
        Me.lblCLIMATmsg.Text = "CLIMAT Message File"
        '
        'txtCLIMAT
        '
        Me.txtCLIMAT.Location = New System.Drawing.Point(122, 496)
        Me.txtCLIMAT.Name = "txtCLIMAT"
        Me.txtCLIMAT.Size = New System.Drawing.Size(475, 20)
        Me.txtCLIMAT.TabIndex = 36
        '
        'butSend
        '
        Me.butSend.Location = New System.Drawing.Point(600, 496)
        Me.butSend.Name = "butSend"
        Me.butSend.Size = New System.Drawing.Size(51, 21)
        Me.butSend.TabIndex = 37
        Me.butSend.Text = "Send"
        Me.butSend.UseVisualStyleBackColor = True
        Me.butSend.Visible = False
        '
        'butSetting
        '
        Me.butSetting.Location = New System.Drawing.Point(591, 350)
        Me.butSetting.Name = "butSetting"
        Me.butSetting.Size = New System.Drawing.Size(62, 22)
        Me.butSetting.TabIndex = 38
        Me.butSetting.Text = "Settings"
        Me.butSetting.UseVisualStyleBackColor = True
        '
        'butHelp
        '
        Me.butHelp.Location = New System.Drawing.Point(303, 350)
        Me.butHelp.Name = "butHelp"
        Me.butHelp.Size = New System.Drawing.Size(51, 22)
        Me.butHelp.TabIndex = 39
        Me.butHelp.Text = "Help"
        Me.butHelp.UseVisualStyleBackColor = True
        '
        'frmCLIMAT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 524)
        Me.Controls.Add(Me.butHelp)
        Me.Controls.Add(Me.butSetting)
        Me.Controls.Add(Me.butSend)
        Me.Controls.Add(Me.txtCLIMAT)
        Me.Controls.Add(Me.lblCLIMATmsg)
        Me.Controls.Add(Me.butClear)
        Me.Controls.Add(Me.grpCLIMATMonth)
        Me.Controls.Add(Me.lstMessages)
        Me.Controls.Add(Me.butClose)
        Me.Controls.Add(Me.butEncode)
        Me.Controls.Add(Me.grpStatistics)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.lstvStations)
        Me.Controls.Add(Me.cmbstation)
        Me.Name = "frmCLIMAT"
        Me.Text = "CLIMAT Message"
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.grpStatistics.ResumeLayout(False)
        Me.grpStatistics.PerformLayout()
        Me.grpCLIMATMonth.ResumeLayout(False)
        Me.grpCLIMATMonth.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public WithEvents lstvStations As ListView
    Friend WithEvents cmbstation As ComboBox
    Friend WithEvents lblStation As Label
    Friend WithEvents grpOptions As GroupBox
    Friend WithEvents grpStatistics As GroupBox
    Friend WithEvents txtEndYear As TextBox
    Friend WithEvents lblEndYear As Label
    Friend WithEvents txtBeginYear As TextBox
    Friend WithEvents lblBeginYear As Label
    Friend WithEvents lblPeriod As Label
    Friend WithEvents chk444 As CheckBox
    Friend WithEvents chk333 As CheckBox
    Friend WithEvents chk222 As CheckBox
    Friend WithEvents butStatistics As Button
    Friend WithEvents butEncode As Button
    Friend WithEvents butClose As Button
    Friend WithEvents lstMessages As ListBox
    Friend WithEvents grpCLIMATMonth As GroupBox
    Friend WithEvents txtMonth As TextBox
    Friend WithEvents lblMonth As Label
    Friend WithEvents txtYear As TextBox
    Friend WithEvents lblYear As Label
    Friend WithEvents butClear As Button
    Friend WithEvents lblCLIMATmsg As Label
    Friend WithEvents txtCLIMAT As TextBox
    Friend WithEvents butSend As Button
    Friend WithEvents butSetting As Button
    Friend WithEvents butHelp As Button
End Class
