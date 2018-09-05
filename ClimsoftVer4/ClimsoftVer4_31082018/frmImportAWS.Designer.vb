<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportAWS
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportAWS))
        Me.btnBrowseSchemaFile = New System.Windows.Forms.Button()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.lblSchemaFile = New System.Windows.Forms.Label()
        Me.txtSchemaFile = New System.Windows.Forms.TextBox()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtStationColumn = New System.Windows.Forms.TextBox()
        Me.lblStationColumn = New System.Windows.Forms.Label()
        Me.txtDateColumn = New System.Windows.Forms.TextBox()
        Me.lblDateColumn = New System.Windows.Forms.Label()
        Me.txtTimeColumn = New System.Windows.Forms.TextBox()
        Me.lblTimeColumn = New System.Windows.Forms.Label()
        Me.txtValStartColumn = New System.Windows.Forms.TextBox()
        Me.lblValStartColumn = New System.Windows.Forms.Label()
        Me.lblGuidelines = New System.Windows.Forms.Label()
        Me.txtHourAdjustment = New System.Windows.Forms.TextBox()
        Me.lblTimeAdjustment = New System.Windows.Forms.Label()
        Me.lblHourAdjustment = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.frameSetSchedule = New System.Windows.Forms.GroupBox()
        Me.lblScheduleMinute = New System.Windows.Forms.Label()
        Me.lblscheduleHour = New System.Windows.Forms.Label()
        Me.txtTimerStartMinute = New System.Windows.Forms.TextBox()
        Me.txtTimerStartHour = New System.Windows.Forms.TextBox()
        Me.btnSetSchedule = New System.Windows.Forms.Button()
        Me.lblTimerActivationStatus = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.frameSetSchedule.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowseSchemaFile
        '
        Me.btnBrowseSchemaFile.Location = New System.Drawing.Point(597, 176)
        Me.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile"
        Me.btnBrowseSchemaFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseSchemaFile.TabIndex = 21
        Me.btnBrowseSchemaFile.Text = "Browse"
        Me.btnBrowseSchemaFile.UseVisualStyleBackColor = True
        '
        'btnBrowseDataFile
        '
        Me.btnBrowseDataFile.Location = New System.Drawing.Point(597, 139)
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFile.TabIndex = 20
        Me.btnBrowseDataFile.Text = "Browse"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'lblSchemaFile
        '
        Me.lblSchemaFile.AutoSize = True
        Me.lblSchemaFile.Location = New System.Drawing.Point(51, 181)
        Me.lblSchemaFile.Name = "lblSchemaFile"
        Me.lblSchemaFile.Size = New System.Drawing.Size(65, 13)
        Me.lblSchemaFile.TabIndex = 19
        Me.lblSchemaFile.Text = "Schema File"
        '
        'txtSchemaFile
        '
        Me.txtSchemaFile.Location = New System.Drawing.Point(154, 178)
        Me.txtSchemaFile.Name = "txtSchemaFile"
        Me.txtSchemaFile.Size = New System.Drawing.Size(437, 20)
        Me.txtSchemaFile.TabIndex = 18
        '
        'lblDataFile
        '
        Me.lblDataFile.AutoSize = True
        Me.lblDataFile.Location = New System.Drawing.Point(53, 144)
        Me.lblDataFile.Name = "lblDataFile"
        Me.lblDataFile.Size = New System.Drawing.Size(49, 13)
        Me.lblDataFile.TabIndex = 17
        Me.lblDataFile.Text = "Data File"
        '
        'txtDataFile
        '
        Me.txtDataFile.Location = New System.Drawing.Point(154, 141)
        Me.txtDataFile.Name = "txtDataFile"
        Me.txtDataFile.Size = New System.Drawing.Size(437, 20)
        Me.txtDataFile.TabIndex = 16
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(597, 260)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 15
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(504, 260)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(410, 260)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtStationColumn
        '
        Me.txtStationColumn.Location = New System.Drawing.Point(154, 219)
        Me.txtStationColumn.Name = "txtStationColumn"
        Me.txtStationColumn.Size = New System.Drawing.Size(42, 20)
        Me.txtStationColumn.TabIndex = 22
        Me.txtStationColumn.Text = "2"
        '
        'lblStationColumn
        '
        Me.lblStationColumn.AutoSize = True
        Me.lblStationColumn.Location = New System.Drawing.Point(51, 222)
        Me.lblStationColumn.Name = "lblStationColumn"
        Me.lblStationColumn.Size = New System.Drawing.Size(89, 13)
        Me.lblStationColumn.TabIndex = 23
        Me.lblStationColumn.Text = "StationID Column"
        '
        'txtDateColumn
        '
        Me.txtDateColumn.Location = New System.Drawing.Point(300, 219)
        Me.txtDateColumn.Name = "txtDateColumn"
        Me.txtDateColumn.Size = New System.Drawing.Size(43, 20)
        Me.txtDateColumn.TabIndex = 24
        Me.txtDateColumn.Text = "0"
        '
        'lblDateColumn
        '
        Me.lblDateColumn.AutoSize = True
        Me.lblDateColumn.Location = New System.Drawing.Point(215, 221)
        Me.lblDateColumn.Name = "lblDateColumn"
        Me.lblDateColumn.Size = New System.Drawing.Size(68, 13)
        Me.lblDateColumn.TabIndex = 25
        Me.lblDateColumn.Text = "Date Column"
        '
        'txtTimeColumn
        '
        Me.txtTimeColumn.Location = New System.Drawing.Point(300, 263)
        Me.txtTimeColumn.Name = "txtTimeColumn"
        Me.txtTimeColumn.Size = New System.Drawing.Size(43, 20)
        Me.txtTimeColumn.TabIndex = 26
        Me.txtTimeColumn.Text = "1"
        '
        'lblTimeColumn
        '
        Me.lblTimeColumn.AutoSize = True
        Me.lblTimeColumn.Location = New System.Drawing.Point(215, 265)
        Me.lblTimeColumn.Name = "lblTimeColumn"
        Me.lblTimeColumn.Size = New System.Drawing.Size(68, 13)
        Me.lblTimeColumn.TabIndex = 27
        Me.lblTimeColumn.Text = "Time Column"
        '
        'txtValStartColumn
        '
        Me.txtValStartColumn.Location = New System.Drawing.Point(154, 263)
        Me.txtValStartColumn.Name = "txtValStartColumn"
        Me.txtValStartColumn.Size = New System.Drawing.Size(42, 20)
        Me.txtValStartColumn.TabIndex = 28
        Me.txtValStartColumn.Text = "3"
        '
        'lblValStartColumn
        '
        Me.lblValStartColumn.AutoSize = True
        Me.lblValStartColumn.Location = New System.Drawing.Point(53, 266)
        Me.lblValStartColumn.Name = "lblValStartColumn"
        Me.lblValStartColumn.Size = New System.Drawing.Size(97, 13)
        Me.lblValStartColumn.TabIndex = 29
        Me.lblValStartColumn.Text = "Value Start Column"
        '
        'lblGuidelines
        '
        Me.lblGuidelines.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuidelines.ForeColor = System.Drawing.Color.Red
        Me.lblGuidelines.Location = New System.Drawing.Point(59, 13)
        Me.lblGuidelines.Name = "lblGuidelines"
        Me.lblGuidelines.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblGuidelines.Size = New System.Drawing.Size(606, 91)
        Me.lblGuidelines.TabIndex = 30
        Me.lblGuidelines.Text = resources.GetString("lblGuidelines.Text")
        Me.lblGuidelines.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtHourAdjustment
        '
        Me.txtHourAdjustment.Location = New System.Drawing.Point(442, 219)
        Me.txtHourAdjustment.Name = "txtHourAdjustment"
        Me.txtHourAdjustment.Size = New System.Drawing.Size(43, 20)
        Me.txtHourAdjustment.TabIndex = 32
        Me.txtHourAdjustment.Text = "0"
        '
        'lblTimeAdjustment
        '
        Me.lblTimeAdjustment.AutoSize = True
        Me.lblTimeAdjustment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTimeAdjustment.Location = New System.Drawing.Point(383, 222)
        Me.lblTimeAdjustment.Name = "lblTimeAdjustment"
        Me.lblTimeAdjustment.Size = New System.Drawing.Size(52, 13)
        Me.lblTimeAdjustment.TabIndex = 33
        Me.lblTimeAdjustment.Text = "Time shift"
        '
        'lblHourAdjustment
        '
        Me.lblHourAdjustment.AutoSize = True
        Me.lblHourAdjustment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblHourAdjustment.Location = New System.Drawing.Point(501, 222)
        Me.lblHourAdjustment.Name = "lblHourAdjustment"
        Me.lblHourAdjustment.Size = New System.Drawing.Size(58, 13)
        Me.lblHourAdjustment.TabIndex = 34
        Me.lblHourAdjustment.Text = "(+/-) Hours"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frameSetSchedule
        '
        Me.frameSetSchedule.Controls.Add(Me.lblScheduleMinute)
        Me.frameSetSchedule.Controls.Add(Me.lblscheduleHour)
        Me.frameSetSchedule.Controls.Add(Me.txtTimerStartMinute)
        Me.frameSetSchedule.Controls.Add(Me.txtTimerStartHour)
        Me.frameSetSchedule.Location = New System.Drawing.Point(397, 301)
        Me.frameSetSchedule.Name = "frameSetSchedule"
        Me.frameSetSchedule.Size = New System.Drawing.Size(216, 53)
        Me.frameSetSchedule.TabIndex = 35
        Me.frameSetSchedule.TabStop = False
        Me.frameSetSchedule.Text = "Set minutes past hour"
        '
        'lblScheduleMinute
        '
        Me.lblScheduleMinute.AutoSize = True
        Me.lblScheduleMinute.Location = New System.Drawing.Point(106, 24)
        Me.lblScheduleMinute.Name = "lblScheduleMinute"
        Me.lblScheduleMinute.Size = New System.Drawing.Size(50, 13)
        Me.lblScheduleMinute.TabIndex = 3
        Me.lblScheduleMinute.Text = "Minute(s)"
        '
        'lblscheduleHour
        '
        Me.lblscheduleHour.AutoSize = True
        Me.lblscheduleHour.Enabled = False
        Me.lblscheduleHour.Location = New System.Drawing.Point(9, 25)
        Me.lblscheduleHour.Name = "lblscheduleHour"
        Me.lblscheduleHour.Size = New System.Drawing.Size(30, 13)
        Me.lblscheduleHour.TabIndex = 2
        Me.lblscheduleHour.Text = "Hour"
        '
        'txtTimerStartMinute
        '
        Me.txtTimerStartMinute.Location = New System.Drawing.Point(162, 22)
        Me.txtTimerStartMinute.Name = "txtTimerStartMinute"
        Me.txtTimerStartMinute.Size = New System.Drawing.Size(45, 20)
        Me.txtTimerStartMinute.TabIndex = 1
        '
        'txtTimerStartHour
        '
        Me.txtTimerStartHour.Enabled = False
        Me.txtTimerStartHour.Location = New System.Drawing.Point(45, 22)
        Me.txtTimerStartHour.Name = "txtTimerStartHour"
        Me.txtTimerStartHour.Size = New System.Drawing.Size(40, 20)
        Me.txtTimerStartHour.TabIndex = 0
        '
        'btnSetSchedule
        '
        Me.btnSetSchedule.Enabled = False
        Me.btnSetSchedule.Location = New System.Drawing.Point(274, 320)
        Me.btnSetSchedule.Name = "btnSetSchedule"
        Me.btnSetSchedule.Size = New System.Drawing.Size(117, 23)
        Me.btnSetSchedule.TabIndex = 36
        Me.btnSetSchedule.Text = "Activate Scheduler"
        Me.btnSetSchedule.UseVisualStyleBackColor = True
        '
        'lblTimerActivationStatus
        '
        Me.lblTimerActivationStatus.AutoSize = True
        Me.lblTimerActivationStatus.ForeColor = System.Drawing.Color.Red
        Me.lblTimerActivationStatus.Location = New System.Drawing.Point(51, 322)
        Me.lblTimerActivationStatus.Name = "lblTimerActivationStatus"
        Me.lblTimerActivationStatus.Size = New System.Drawing.Size(147, 13)
        Me.lblTimerActivationStatus.TabIndex = 37
        Me.lblTimerActivationStatus.Text = "Timer scheduler not activated"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(59, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(599, 35)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Click [OK] button to start data ingestion as a once off operation. Click [Activat" & _
    "e Scheduler] to start data ingestion and repeat process every hour."
        '
        'frmImportAWS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 375)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTimerActivationStatus)
        Me.Controls.Add(Me.btnSetSchedule)
        Me.Controls.Add(Me.frameSetSchedule)
        Me.Controls.Add(Me.lblHourAdjustment)
        Me.Controls.Add(Me.lblTimeAdjustment)
        Me.Controls.Add(Me.txtHourAdjustment)
        Me.Controls.Add(Me.lblGuidelines)
        Me.Controls.Add(Me.lblValStartColumn)
        Me.Controls.Add(Me.txtValStartColumn)
        Me.Controls.Add(Me.lblTimeColumn)
        Me.Controls.Add(Me.txtTimeColumn)
        Me.Controls.Add(Me.lblDateColumn)
        Me.Controls.Add(Me.txtDateColumn)
        Me.Controls.Add(Me.lblStationColumn)
        Me.Controls.Add(Me.txtStationColumn)
        Me.Controls.Add(Me.btnBrowseSchemaFile)
        Me.Controls.Add(Me.btnBrowseDataFile)
        Me.Controls.Add(Me.lblSchemaFile)
        Me.Controls.Add(Me.txtSchemaFile)
        Me.Controls.Add(Me.lblDataFile)
        Me.Controls.Add(Me.txtDataFile)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportAWS"
        Me.Text = "frmImportAWS"
        Me.frameSetSchedule.ResumeLayout(False)
        Me.frameSetSchedule.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseSchemaFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents lblSchemaFile As System.Windows.Forms.Label
    Friend WithEvents txtSchemaFile As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtStationColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblStationColumn As System.Windows.Forms.Label
    Friend WithEvents txtDateColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblDateColumn As System.Windows.Forms.Label
    Friend WithEvents txtTimeColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblTimeColumn As System.Windows.Forms.Label
    Friend WithEvents txtValStartColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblValStartColumn As System.Windows.Forms.Label
    Friend WithEvents lblGuidelines As System.Windows.Forms.Label
    Friend WithEvents txtHourAdjustment As System.Windows.Forms.TextBox
    Friend WithEvents lblTimeAdjustment As System.Windows.Forms.Label
    Friend WithEvents lblHourAdjustment As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents frameSetSchedule As System.Windows.Forms.GroupBox
    Friend WithEvents lblScheduleMinute As System.Windows.Forms.Label
    Friend WithEvents lblscheduleHour As System.Windows.Forms.Label
    Friend WithEvents txtTimerStartMinute As System.Windows.Forms.TextBox
    Friend WithEvents txtTimerStartHour As System.Windows.Forms.TextBox
    Friend WithEvents btnSetSchedule As System.Windows.Forms.Button
    Friend WithEvents lblTimerActivationStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
