<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrAgroMet
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.ucrAgrometStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.ucrAgrometYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.UcrMonth1 = New ClimsoftVer4.ucrMonth()
        Me.ucrAgrometMonthSelector = New ClimsoftVer4.ucrMonth()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ucrAgrometStationSelector
        '
        Me.ucrAgrometStationSelector.FieldName = Nothing
        Me.ucrAgrometStationSelector.Location = New System.Drawing.Point(65, 19)
        Me.ucrAgrometStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrAgrometStationSelector.Name = "ucrAgrometStationSelector"
        Me.ucrAgrometStationSelector.Size = New System.Drawing.Size(253, 24)
        Me.ucrAgrometStationSelector.TabIndex = 0
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(13, 19)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station"
        '
        'ucrAgrometYearSelector
        '
        Me.ucrAgrometYearSelector.FieldName = Nothing
        Me.ucrAgrometYearSelector.Location = New System.Drawing.Point(65, 52)
        Me.ucrAgrometYearSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrAgrometYearSelector.Name = "ucrAgrometYearSelector"
        Me.ucrAgrometYearSelector.Size = New System.Drawing.Size(85, 25)
        Me.ucrAgrometYearSelector.TabIndex = 2
        '
        'UcrMonth1
        '
        Me.UcrMonth1.FieldName = Nothing
        Me.UcrMonth1.Location = New System.Drawing.Point(208, -136)
        Me.UcrMonth1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrMonth1.Name = "UcrMonth1"
        Me.UcrMonth1.Size = New System.Drawing.Size(380, 212)
        Me.UcrMonth1.TabIndex = 3
        '
        'ucrAgrometMonthSelector
        '
        Me.ucrAgrometMonthSelector.FieldName = Nothing
        Me.ucrAgrometMonthSelector.Location = New System.Drawing.Point(279, 55)
        Me.ucrAgrometMonthSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrAgrometMonthSelector.Name = "ucrAgrometMonthSelector"
        Me.ucrAgrometMonthSelector.Size = New System.Drawing.Size(48, 22)
        Me.ucrAgrometMonthSelector.TabIndex = 4
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(13, 62)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(29, 13)
        Me.lblYear.TabIndex = 5
        Me.lblYear.Text = "Year"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(233, 62)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(37, 13)
        Me.lblMonth.TabIndex = 6
        Me.lblMonth.Text = "Month"
        '
        'ucrAgroMet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.ucrAgrometMonthSelector)
        Me.Controls.Add(Me.UcrMonth1)
        Me.Controls.Add(Me.ucrAgrometYearSelector)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrAgrometStationSelector)
        Me.Name = "ucrAgroMet"
        Me.Size = New System.Drawing.Size(482, 402)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrAgrometStationSelector As ucrStationSelector
    Friend WithEvents lblStation As Label
    Friend WithEvents ucrAgrometYearSelector As ucrYearSelector
    Friend WithEvents UcrMonth1 As ucrMonth
    Friend WithEvents ucrAgrometMonthSelector As ucrMonth
    Friend WithEvents lblYear As Label
    Friend WithEvents lblMonth As Label
End Class
