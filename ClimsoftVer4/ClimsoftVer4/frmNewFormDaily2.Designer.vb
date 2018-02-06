<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewFormDaily2
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
        Me.lblStation = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrFormDaily = New ClimsoftVer4.ucrFormDaily2()
        Me.ucrYearSelector = New ClimsoftVer4.ucrYearSelector()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.UcrMonth1 = New ClimsoftVer4.ucrMonth()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.UcrHour1 = New ClimsoftVer4.ucrHour()
        Me.lblHour = New System.Windows.Forms.Label()
        Me.btnAssignSameValue = New System.Windows.Forms.Button()
        Me.UcrTextBox1 = New ClimsoftVer4.ucrTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(12, 20)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station:"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(280, 20)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(48, 13)
        Me.lblElement.TabIndex = 1
        Me.lblElement.Text = "Element:"
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.Location = New System.Drawing.Point(326, 20)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(178, 21)
        Me.ucrElementSelector.TabIndex = 2
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(69, 20)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(175, 24)
        Me.ucrStationSelector.TabIndex = 0
        '
        'ucrFormDaily
        '
        Me.ucrFormDaily.Location = New System.Drawing.Point(14, 159)
        Me.ucrFormDaily.Name = "ucrFormDaily"
        Me.ucrFormDaily.Size = New System.Drawing.Size(712, 356)
        Me.ucrFormDaily.TabIndex = 3
        '
        'ucrYearSelector
        '
        Me.ucrYearSelector.Location = New System.Drawing.Point(68, 74)
        Me.ucrYearSelector.Name = "ucrYearSelector"
        Me.ucrYearSelector.Size = New System.Drawing.Size(46, 21)
        Me.ucrYearSelector.TabIndex = 4
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Location = New System.Drawing.Point(68, 55)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(32, 13)
        Me.lblYear.TabIndex = 5
        Me.lblYear.Text = "Year:"
        '
        'UcrMonth1
        '
        Me.UcrMonth1.Location = New System.Drawing.Point(133, 73)
        Me.UcrMonth1.Name = "UcrMonth1"
        Me.UcrMonth1.Size = New System.Drawing.Size(37, 21)
        Me.UcrMonth1.TabIndex = 6
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(130, 57)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(40, 13)
        Me.lblMonth.TabIndex = 5
        Me.lblMonth.Text = "Month:"
        '
        'UcrHour1
        '
        Me.UcrHour1.Location = New System.Drawing.Point(189, 74)
        Me.UcrHour1.Name = "UcrHour1"
        Me.UcrHour1.Size = New System.Drawing.Size(36, 21)
        Me.UcrHour1.TabIndex = 7
        '
        'lblHour
        '
        Me.lblHour.AutoSize = True
        Me.lblHour.Location = New System.Drawing.Point(185, 58)
        Me.lblHour.Name = "lblHour"
        Me.lblHour.Size = New System.Drawing.Size(33, 13)
        Me.lblHour.TabIndex = 5
        Me.lblHour.Text = "Hour:"
        '
        'btnAssignSameValue
        '
        Me.btnAssignSameValue.ForeColor = System.Drawing.Color.Blue
        Me.btnAssignSameValue.Location = New System.Drawing.Point(362, 71)
        Me.btnAssignSameValue.Name = "btnAssignSameValue"
        Me.btnAssignSameValue.Size = New System.Drawing.Size(169, 23)
        Me.btnAssignSameValue.TabIndex = 8
        Me.btnAssignSameValue.Text = "Assign same value to all obs"
        Me.btnAssignSameValue.UseVisualStyleBackColor = True
        '
        'UcrTextBox1
        '
        Me.UcrTextBox1.Location = New System.Drawing.Point(577, 71)
        Me.UcrTextBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.UcrTextBox1.Name = "UcrTextBox1"
        Me.UcrTextBox1.Size = New System.Drawing.Size(58, 26)
        Me.UcrTextBox1.TabIndex = 9
        Me.UcrTextBox1.TextboxValue = ""
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Blue
        Me.Label30.Location = New System.Drawing.Point(537, 77)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(40, 13)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Value="
        '
        'frmNewFormDaily2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 565)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.UcrTextBox1)
        Me.Controls.Add(Me.btnAssignSameValue)
        Me.Controls.Add(Me.UcrHour1)
        Me.Controls.Add(Me.UcrMonth1)
        Me.Controls.Add(Me.lblHour)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.ucrYearSelector)
        Me.Controls.Add(Me.ucrFormDaily)
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Name = "frmNewFormDaily2"
        Me.Text = "frmNewFormDaily2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents lblStation As Label
    Friend WithEvents lblElement As Label
    Friend WithEvents ucrElementSelector As ucrElementSelector
    Friend WithEvents ucrFormDaily As ucrFormDaily2
    Friend WithEvents ucrYearSelector As ucrYearSelector
    Friend WithEvents lblYear As Label
    Friend WithEvents UcrMonth1 As ucrMonth
    Friend WithEvents lblMonth As Label
    Friend WithEvents UcrHour1 As ucrHour
    Friend WithEvents lblHour As Label
    Friend WithEvents btnAssignSameValue As Button
    Friend WithEvents UcrTextBox1 As ucrTextBox
    Friend WithEvents Label30 As Label
End Class
