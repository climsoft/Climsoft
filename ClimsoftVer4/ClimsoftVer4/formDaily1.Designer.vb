<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formDaily1
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
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.cboDay = New System.Windows.Forms.ComboBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboHour = New System.Windows.Forms.ComboBox()
        Me.GroupBoxCommands = New System.Windows.Forms.GroupBox()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.chkRepeatEntry = New System.Windows.Forms.CheckBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.recNumberTextBox = New System.Windows.Forms.TextBox()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.btnPush = New System.Windows.Forms.Button()
        Me.GroupBoxCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(357, 74)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(26, 13)
        Me.Label62.TabIndex = 1018
        Me.Label62.Text = "Day"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(233, 74)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(37, 13)
        Me.Label61.TabIndex = 1017
        Me.Label61.Text = "Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(124, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1016
        Me.Label2.Text = "Year"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 1015
        Me.Label1.Text = "Station Identification"
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.Location = New System.Drawing.Point(155, 28)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(424, 21)
        Me.cboStation.TabIndex = 0
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(271, 70)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(41, 21)
        Me.cboMonth.TabIndex = 2
        '
        'cboDay
        '
        Me.cboDay.FormattingEnabled = True
        Me.cboDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboDay.Location = New System.Drawing.Point(387, 70)
        Me.cboDay.Name = "cboDay"
        Me.cboDay.Size = New System.Drawing.Size(39, 21)
        Me.cboDay.TabIndex = 3
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(156, 70)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(40, 20)
        Me.txtYear.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(451, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 1020
        Me.Label3.Text = "Hour"
        '
        'cboHour
        '
        Me.cboHour.FormattingEnabled = True
        Me.cboHour.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23"})
        Me.cboHour.Location = New System.Drawing.Point(481, 70)
        Me.cboHour.Name = "cboHour"
        Me.cboHour.Size = New System.Drawing.Size(39, 21)
        Me.cboHour.TabIndex = 4
        '
        'GroupBoxCommands
        '
        Me.GroupBoxCommands.Controls.Add(Me.btnPush)
        Me.GroupBoxCommands.Controls.Add(Me.btnCommit)
        Me.GroupBoxCommands.Controls.Add(Me.chkRepeatEntry)
        Me.GroupBoxCommands.Controls.Add(Me.btnView)
        Me.GroupBoxCommands.Controls.Add(Me.btnUpload)
        Me.GroupBoxCommands.Controls.Add(Me.Label37)
        Me.GroupBoxCommands.Controls.Add(Me.txtSequencer)
        Me.GroupBoxCommands.Controls.Add(Me.btnHelp)
        Me.GroupBoxCommands.Controls.Add(Me.btnClear)
        Me.GroupBoxCommands.Controls.Add(Me.btnDelete)
        Me.GroupBoxCommands.Controls.Add(Me.btnAddNew)
        Me.GroupBoxCommands.Controls.Add(Me.btnMovePrevious)
        Me.GroupBoxCommands.Controls.Add(Me.btnUpdate)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveLast)
        Me.GroupBoxCommands.Controls.Add(Me.recNumberTextBox)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveNext)
        Me.GroupBoxCommands.Controls.Add(Me.btnClose)
        Me.GroupBoxCommands.Controls.Add(Me.btnMoveFirst)
        Me.GroupBoxCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxCommands.Location = New System.Drawing.Point(0, 355)
        Me.GroupBoxCommands.Name = "GroupBoxCommands"
        Me.GroupBoxCommands.Size = New System.Drawing.Size(624, 124)
        Me.GroupBoxCommands.TabIndex = 1171
        Me.GroupBoxCommands.TabStop = False
        '
        'btnCommit
        '
        Me.btnCommit.Enabled = False
        Me.btnCommit.Location = New System.Drawing.Point(84, 45)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(55, 23)
        Me.btnCommit.TabIndex = 1171
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'chkRepeatEntry
        '
        Me.chkRepeatEntry.AutoSize = True
        Me.chkRepeatEntry.Enabled = False
        Me.chkRepeatEntry.Location = New System.Drawing.Point(19, 89)
        Me.chkRepeatEntry.Name = "chkRepeatEntry"
        Me.chkRepeatEntry.Size = New System.Drawing.Size(139, 17)
        Me.chkRepeatEntry.TabIndex = 1187
        Me.chkRepeatEntry.Text = "Repeat Key Entry Mode"
        Me.chkRepeatEntry.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(352, 45)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(55, 23)
        Me.btnView.TabIndex = 1176
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(513, 83)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 1186
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(197, 89)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(59, 13)
        Me.Label37.TabIndex = 1185
        Me.Label37.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(262, 86)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(175, 20)
        Me.txtSequencer.TabIndex = 1184
        Me.txtSequencer.Text = "seq_month_day"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(549, 45)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(55, 23)
        Me.btnHelp.TabIndex = 1177
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(285, 45)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(55, 23)
        Me.btnClear.TabIndex = 1175
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(218, 45)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(55, 23)
        Me.btnDelete.TabIndex = 1174
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(8, 45)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(64, 23)
        Me.btnAddNew.TabIndex = 1172
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMovePrevious.Location = New System.Drawing.Point(225, 12)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(46, 23)
        Me.btnMovePrevious.TabIndex = 1183
        Me.btnMovePrevious.Text = "<<"
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(151, 45)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(55, 23)
        Me.btnUpdate.TabIndex = 1173
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveLast.Location = New System.Drawing.Point(468, 12)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveLast.TabIndex = 1181
        Me.btnMoveLast.Text = ">>|"
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'recNumberTextBox
        '
        Me.recNumberTextBox.Location = New System.Drawing.Point(277, 14)
        Me.recNumberTextBox.Name = "recNumberTextBox"
        Me.recNumberTextBox.Size = New System.Drawing.Size(141, 20)
        Me.recNumberTextBox.TabIndex = 1180
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveNext.Location = New System.Drawing.Point(424, 12)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(38, 23)
        Me.btnMoveNext.TabIndex = 1179
        Me.btnMoveNext.Text = ">>"
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(482, 45)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 23)
        Me.btnClose.TabIndex = 1178
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFirst.Location = New System.Drawing.Point(178, 12)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(41, 23)
        Me.btnMoveFirst.TabIndex = 1182
        Me.btnMoveFirst.Text = "|<<"
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'btnPush
        '
        Me.btnPush.Location = New System.Drawing.Point(419, 45)
        Me.btnPush.Name = "btnPush"
        Me.btnPush.Size = New System.Drawing.Size(51, 23)
        Me.btnPush.TabIndex = 1188
        Me.btnPush.Text = "Push"
        Me.btnPush.UseVisualStyleBackColor = True
        '
        'formDaily1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 479)
        Me.Controls.Add(Me.GroupBoxCommands)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboHour)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStation)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboDay)
        Me.Controls.Add(Me.txtYear)
        Me.KeyPreview = True
        Me.Name = "formDaily1"
        Me.Text = "Data for some elements for one day"
        Me.GroupBoxCommands.ResumeLayout(False)
        Me.GroupBoxCommands.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label62 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents cboMonth As ComboBox
    Friend WithEvents cboDay As ComboBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboHour As ComboBox
    Friend WithEvents GroupBoxCommands As GroupBox
    Friend WithEvents btnCommit As Button
    Friend WithEvents chkRepeatEntry As CheckBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label37 As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnMovePrevious As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnMoveLast As Button
    Friend WithEvents recNumberTextBox As TextBox
    Friend WithEvents btnMoveNext As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnMoveFirst As Button
    Friend WithEvents btnPush As Button
End Class
