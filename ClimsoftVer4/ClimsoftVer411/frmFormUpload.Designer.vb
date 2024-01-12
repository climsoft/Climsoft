<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFormUpload
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
        Me.txtDataTransferProgress1 = New System.Windows.Forms.TextBox()
        Me.lblDataTransferProgress = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTableRecords = New System.Windows.Forms.Label()
        Me.LstViewStations = New System.Windows.Forms.ListView()
        Me.lblProcessingStatus = New System.Windows.Forms.Label()
        Me.lblEndMonth = New System.Windows.Forms.Label()
        Me.lblBeginMonth = New System.Windows.Forms.Label()
        Me.lblEndYear = New System.Windows.Forms.Label()
        Me.lblBeginYear = New System.Windows.Forms.Label()
        Me.txtEndMonth = New System.Windows.Forms.TextBox()
        Me.txtBeginMonth = New System.Windows.Forms.TextBox()
        Me.txtEndYear = New System.Windows.Forms.TextBox()
        Me.txtBeginYear = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.chkAllStations = New System.Windows.Forms.CheckBox()
        Me.frmUploadgroundWorker = New System.ComponentModel.BackgroundWorker()
        Me.chkUTC = New System.Windows.Forms.CheckBox()
        Me.txtTdiff = New System.Windows.Forms.TextBox()
        Me.lblDiff = New System.Windows.Forms.Label()
        Me.lblFormName1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDataTransferProgress1
        '
        Me.txtDataTransferProgress1.ForeColor = System.Drawing.Color.Black
        Me.txtDataTransferProgress1.Location = New System.Drawing.Point(370, 112)
        Me.txtDataTransferProgress1.Name = "txtDataTransferProgress1"
        Me.txtDataTransferProgress1.Size = New System.Drawing.Size(240, 20)
        Me.txtDataTransferProgress1.TabIndex = 0
        '
        'lblDataTransferProgress
        '
        Me.lblDataTransferProgress.AutoSize = True
        Me.lblDataTransferProgress.ForeColor = System.Drawing.Color.Black
        Me.lblDataTransferProgress.Location = New System.Drawing.Point(373, 96)
        Me.lblDataTransferProgress.Name = "lblDataTransferProgress"
        Me.lblDataTransferProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblDataTransferProgress.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(525, 158)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTableRecords
        '
        Me.lblTableRecords.AutoSize = True
        Me.lblTableRecords.Location = New System.Drawing.Point(93, 20)
        Me.lblTableRecords.Name = "lblTableRecords"
        Me.lblTableRecords.Size = New System.Drawing.Size(0, 13)
        Me.lblTableRecords.TabIndex = 4
        '
        'LstViewStations
        '
        Me.LstViewStations.CheckBoxes = True
        Me.LstViewStations.FullRowSelect = True
        Me.LstViewStations.GridLines = True
        Me.LstViewStations.HideSelection = False
        Me.LstViewStations.Location = New System.Drawing.Point(7, 10)
        Me.LstViewStations.Name = "LstViewStations"
        Me.LstViewStations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LstViewStations.RightToLeftLayout = True
        Me.LstViewStations.Size = New System.Drawing.Size(350, 166)
        Me.LstViewStations.TabIndex = 27
        Me.LstViewStations.UseCompatibleStateImageBehavior = False
        Me.LstViewStations.View = System.Windows.Forms.View.Details
        '
        'lblProcessingStatus
        '
        Me.lblProcessingStatus.AutoSize = True
        Me.lblProcessingStatus.ForeColor = System.Drawing.Color.Red
        Me.lblProcessingStatus.Location = New System.Drawing.Point(463, 44)
        Me.lblProcessingStatus.Name = "lblProcessingStatus"
        Me.lblProcessingStatus.Size = New System.Drawing.Size(0, 13)
        Me.lblProcessingStatus.TabIndex = 36
        '
        'lblEndMonth
        '
        Me.lblEndMonth.AutoSize = True
        Me.lblEndMonth.Location = New System.Drawing.Point(508, 41)
        Me.lblEndMonth.Name = "lblEndMonth"
        Me.lblEndMonth.Size = New System.Drawing.Size(59, 13)
        Me.lblEndMonth.TabIndex = 35
        Me.lblEndMonth.Text = "End Month"
        '
        'lblBeginMonth
        '
        Me.lblBeginMonth.AutoSize = True
        Me.lblBeginMonth.Location = New System.Drawing.Point(508, 15)
        Me.lblBeginMonth.Name = "lblBeginMonth"
        Me.lblBeginMonth.Size = New System.Drawing.Size(70, 13)
        Me.lblBeginMonth.TabIndex = 34
        Me.lblBeginMonth.Text = "Begin Month:"
        '
        'lblEndYear
        '
        Me.lblEndYear.AutoSize = True
        Me.lblEndYear.Location = New System.Drawing.Point(367, 41)
        Me.lblEndYear.Name = "lblEndYear"
        Me.lblEndYear.Size = New System.Drawing.Size(54, 13)
        Me.lblEndYear.TabIndex = 33
        Me.lblEndYear.Text = "End Year:"
        '
        'lblBeginYear
        '
        Me.lblBeginYear.AutoSize = True
        Me.lblBeginYear.Location = New System.Drawing.Point(367, 15)
        Me.lblBeginYear.Name = "lblBeginYear"
        Me.lblBeginYear.Size = New System.Drawing.Size(62, 13)
        Me.lblBeginYear.TabIndex = 32
        Me.lblBeginYear.Text = "Begin Year:"
        '
        'txtEndMonth
        '
        Me.txtEndMonth.Location = New System.Drawing.Point(588, 37)
        Me.txtEndMonth.Name = "txtEndMonth"
        Me.txtEndMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtEndMonth.TabIndex = 31
        Me.txtEndMonth.Text = "12"
        Me.txtEndMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBeginMonth
        '
        Me.txtBeginMonth.Location = New System.Drawing.Point(588, 11)
        Me.txtBeginMonth.Name = "txtBeginMonth"
        Me.txtBeginMonth.Size = New System.Drawing.Size(33, 20)
        Me.txtBeginMonth.TabIndex = 30
        Me.txtBeginMonth.Text = "1"
        Me.txtBeginMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEndYear
        '
        Me.txtEndYear.Location = New System.Drawing.Point(437, 37)
        Me.txtEndYear.Name = "txtEndYear"
        Me.txtEndYear.Size = New System.Drawing.Size(48, 20)
        Me.txtEndYear.TabIndex = 29
        '
        'txtBeginYear
        '
        Me.txtBeginYear.Location = New System.Drawing.Point(437, 11)
        Me.txtBeginYear.Name = "txtBeginYear"
        Me.txtBeginYear.Size = New System.Drawing.Size(48, 20)
        Me.txtBeginYear.TabIndex = 28
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(371, 158)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(77, 23)
        Me.btnStart.TabIndex = 37
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'chkAllStations
        '
        Me.chkAllStations.AutoSize = True
        Me.chkAllStations.Location = New System.Drawing.Point(7, 181)
        Me.chkAllStations.Name = "chkAllStations"
        Me.chkAllStations.Size = New System.Drawing.Size(111, 17)
        Me.chkAllStations.TabIndex = 38
        Me.chkAllStations.Text = "Select All Stations"
        Me.chkAllStations.UseVisualStyleBackColor = True
        '
        'frmUploadgroundWorker
        '
        Me.frmUploadgroundWorker.WorkerReportsProgress = True
        Me.frmUploadgroundWorker.WorkerSupportsCancellation = True
        '
        'chkUTC
        '
        Me.chkUTC.AutoSize = True
        Me.chkUTC.Location = New System.Drawing.Point(370, 72)
        Me.chkUTC.Name = "chkUTC"
        Me.chkUTC.Size = New System.Drawing.Size(100, 17)
        Me.chkUTC.TabIndex = 40
        Me.chkUTC.Text = "Convert to UTC"
        Me.chkUTC.UseVisualStyleBackColor = True
        '
        'txtTdiff
        '
        Me.txtTdiff.Location = New System.Drawing.Point(484, 69)
        Me.txtTdiff.Name = "txtTdiff"
        Me.txtTdiff.Size = New System.Drawing.Size(26, 20)
        Me.txtTdiff.TabIndex = 41
        Me.txtTdiff.Text = "0"
        Me.txtTdiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTdiff.Visible = False
        '
        'lblDiff
        '
        Me.lblDiff.AutoSize = True
        Me.lblDiff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiff.Location = New System.Drawing.Point(513, 73)
        Me.lblDiff.Name = "lblDiff"
        Me.lblDiff.Size = New System.Drawing.Size(117, 13)
        Me.lblDiff.TabIndex = 42
        Me.lblDiff.Text = "Time difference (Hours)"
        Me.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDiff.Visible = False
        '
        'lblFormName1
        '
        Me.lblFormName1.AutoSize = True
        Me.lblFormName1.Location = New System.Drawing.Point(390, 140)
        Me.lblFormName1.Name = "lblFormName1"
        Me.lblFormName1.Size = New System.Drawing.Size(0, 13)
        Me.lblFormName1.TabIndex = 43
        Me.lblFormName1.Visible = False
        '
        'frmFormUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 202)
        Me.Controls.Add(Me.lblFormName1)
        Me.Controls.Add(Me.lblDiff)
        Me.Controls.Add(Me.txtTdiff)
        Me.Controls.Add(Me.chkUTC)
        Me.Controls.Add(Me.chkAllStations)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblProcessingStatus)
        Me.Controls.Add(Me.lblEndMonth)
        Me.Controls.Add(Me.lblBeginMonth)
        Me.Controls.Add(Me.lblEndYear)
        Me.Controls.Add(Me.lblBeginYear)
        Me.Controls.Add(Me.txtEndMonth)
        Me.Controls.Add(Me.txtBeginMonth)
        Me.Controls.Add(Me.txtEndYear)
        Me.Controls.Add(Me.txtBeginYear)
        Me.Controls.Add(Me.LstViewStations)
        Me.Controls.Add(Me.lblTableRecords)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblDataTransferProgress)
        Me.Controls.Add(Me.txtDataTransferProgress1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFormUpload"
        Me.Text = "Form Data Upload"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDataTransferProgress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblDataTransferProgress As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblTableRecords As System.Windows.Forms.Label
    Public WithEvents LstViewStations As ListView
    Friend WithEvents lblProcessingStatus As Label
    Friend WithEvents lblEndMonth As Label
    Friend WithEvents lblBeginMonth As Label
    Friend WithEvents lblEndYear As Label
    Friend WithEvents lblBeginYear As Label
    Friend WithEvents txtEndMonth As TextBox
    Friend WithEvents txtBeginMonth As TextBox
    Friend WithEvents txtEndYear As TextBox
    Friend WithEvents txtBeginYear As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents chkAllStations As CheckBox
    Friend WithEvents frmUploadgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents chkUTC As CheckBox
    Friend WithEvents txtTdiff As TextBox
    Friend WithEvents lblDiff As Label
    Friend WithEvents lblFormName1 As Label
End Class
