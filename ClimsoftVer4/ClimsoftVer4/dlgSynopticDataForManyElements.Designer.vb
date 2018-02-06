<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgSynopticDataForManyElements
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
        Dim lblYear As System.Windows.Forms.Label
        Me.lblStationIdentifier = New System.Windows.Forms.Label()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.ucrHour = New ClimsoftVer4.ucrHour()
        Me.ucrMonth = New ClimsoftVer4.ucrMonth()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.UcrSynopticDataForManyElements1 = New ClimsoftVer4.ucrSynopticDataForManyElements()
        lblYear = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblYear
        '
        lblYear.AutoSize = True
        lblYear.Location = New System.Drawing.Point(277, 33)
        lblYear.Name = "lblYear"
        lblYear.Size = New System.Drawing.Size(32, 13)
        lblYear.TabIndex = 205
        lblYear.Text = "Year:"
        '
        'lblStationIdentifier
        '
        Me.lblStationIdentifier.AutoSize = True
        Me.lblStationIdentifier.Location = New System.Drawing.Point(8, 32)
        Me.lblStationIdentifier.Name = "lblStationIdentifier"
        Me.lblStationIdentifier.Size = New System.Drawing.Size(86, 13)
        Me.lblStationIdentifier.TabIndex = 209
        Me.lblStationIdentifier.Text = "Station Identifier:"
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(610, 33)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(33, 13)
        Me.lblHour.TabIndex = 208
        Me.lblHour.Text = "Hour:"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(501, 33)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 13)
        Me.lblDay.TabIndex = 207
        Me.lblDay.Text = "Day:"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(381, 33)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 206
        Me.lblMonth.Text = "Month:"
        '
        'ucrHour
        '
        Me.ucrHour.Location = New System.Drawing.Point(646, 28)
        Me.ucrHour.Name = "ucrHour"
        Me.ucrHour.Size = New System.Drawing.Size(62, 21)
        Me.ucrHour.TabIndex = 3
        '
        'ucrMonth
        '
        Me.ucrMonth.Location = New System.Drawing.Point(427, 28)
        Me.ucrMonth.Name = "ucrMonth"
        Me.ucrMonth.Size = New System.Drawing.Size(62, 21)
        Me.ucrMonth.TabIndex = 2
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(313, 28)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(62, 21)
        Me.ucrYearSelector.TabIndex = 1
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(94, 28)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(175, 24)
        Me.ucrStationSelector.TabIndex = 0
        '
        'UcrSynopticDataForManyElements1
        '
        Me.UcrSynopticDataForManyElements1.Location = New System.Drawing.Point(15, 61)
        Me.UcrSynopticDataForManyElements1.Name = "UcrSynopticDataForManyElements1"
        Me.UcrSynopticDataForManyElements1.Size = New System.Drawing.Size(906, 499)
        Me.UcrSynopticDataForManyElements1.TabIndex = 210
        '
        'dlgSynopticDataForManyElements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 554)
        Me.Controls.Add(Me.UcrSynopticDataForManyElements1)
        Me.Controls.Add(Me.lblStationIdentifier)
        Me.Controls.Add(Me.lblHour)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(lblYear)
        Me.Controls.Add(Me.ucrHour)
        Me.Controls.Add(Me.ucrMonth)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSynopticDataForManyElements"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Synoptic Data For Many Elements For WMO - RA1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents ucrMonth As ucrMonth
    Friend WithEvents ucrHour As ucrHour
    Friend WithEvents lblStationIdentifier As Label
    Friend WithEvents lblHour As Label
    Friend WithEvents lblDay As Label
    Friend WithEvents lblMonth As Label
    Friend WithEvents UcrSynopticDataForManyElements1 As ucrSynopticDataForManyElements
End Class
