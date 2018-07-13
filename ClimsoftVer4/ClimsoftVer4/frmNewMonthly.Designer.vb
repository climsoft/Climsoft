<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewMonthly
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
        Dim lblYear As System.Windows.Forms.Label
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSequencer = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnCommit = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.ucrNavigation = New ClimsoftVer4.ucrNavigation()
        Me.ucrMonthlydata = New ClimsoftVer4.ucrMonthlydata()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(467, 11)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 494
        lblYear.Text = "Year:"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(264, 11)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(48, 13)
        Me.lblElement.TabIndex = 496
        Me.lblElement.Text = "Element:"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(68, 11)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 495
        Me.lblStation.Text = "Station:"
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(421, 481)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.Lime
        Me.btnUpload.Location = New System.Drawing.Point(583, 509)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 14
        Me.btnUpload.Text = "Upload"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 519)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 675
        Me.Label5.Text = "Sequencer"
        '
        'txtSequencer
        '
        Me.txtSequencer.Location = New System.Drawing.Point(245, 516)
        Me.txtSequencer.Name = "txtSequencer"
        Me.txtSequencer.Size = New System.Drawing.Size(200, 20)
        Me.txtSequencer.TabIndex = 674
        Me.txtSequencer.Text = "seq_year"
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(583, 481)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 13
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(340, 481)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnCommit
        '
        Me.btnCommit.Location = New System.Drawing.Point(97, 481)
        Me.btnCommit.Name = "btnCommit"
        Me.btnCommit.Size = New System.Drawing.Size(75, 23)
        Me.btnCommit.TabIndex = 8
        Me.btnCommit.Text = "Save"
        Me.btnCommit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(259, 481)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(16, 481)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 7
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(178, 481)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(502, 481)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ucrNavigation
        '
        Me.ucrNavigation.Location = New System.Drawing.Point(163, 442)
        Me.ucrNavigation.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigation.Name = "ucrNavigation"
        Me.ucrNavigation.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigation.TabIndex = 15
        '
        'ucrMonthlydata
        '
        Me.ucrMonthlydata.Location = New System.Drawing.Point(180, 53)
        Me.ucrMonthlydata.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrMonthlydata.Name = "ucrMonthlydata"
        Me.ucrMonthlydata.Size = New System.Drawing.Size(343, 404)
        Me.ucrMonthlydata.TabIndex = 4
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(470, 27)
        Me.ucrYearSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(85, 25)
        Me.ucrYearSelector.TabIndex = 3
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.Location = New System.Drawing.Point(267, 27)
        Me.ucrElementSelector.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(178, 21)
        Me.ucrElementSelector.TabIndex = 2
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(65, 27)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(187, 24)
        Me.ucrStationSelector.TabIndex = 1
        '
        'frmNewMonthly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 543)
        Me.Controls.Add(Me.ucrNavigation)
        Me.Controls.Add(Me.ucrMonthlydata)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSequencer)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCommit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(lblYear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewMonthly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monthly Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrElementSelector As ucrElementSelector
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents btnView As Button
    Friend WithEvents btnUpload As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSequencer As TextBox
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnCommit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents ucrMonthlydata As ucrMonthlydata
    Friend WithEvents ucrNavigation As ucrNavigation
End Class
