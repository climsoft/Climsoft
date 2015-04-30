<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProduct
    Inherits ClimsoftVer4.frmAction

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbo_station_stationName = New System.Windows.Forms.ComboBox()
        Me.lbl_station_stationName = New System.Windows.Forms.Label()
        Me.cbo_obsElement_elementName = New System.Windows.Forms.ComboBox()
        Me.lbl_obsElement_elementName = New System.Windows.Forms.Label()
        Me.rad_obsElement_elementtype_daily = New System.Windows.Forms.RadioButton()
        Me.rad_obsElement_elementtype_monthly = New System.Windows.Forms.RadioButton()
        Me.lbl_obsElement_elementtype = New System.Windows.Forms.Label()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.lblDateStart = New System.Windows.Forms.Label()
        Me.lblDateEnd = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbo_station_stationName
        '
        Me.cbo_station_stationName.FormattingEnabled = True
        Me.cbo_station_stationName.Location = New System.Drawing.Point(132, 41)
        Me.cbo_station_stationName.Name = "cbo_station_stationName"
        Me.cbo_station_stationName.Size = New System.Drawing.Size(276, 21)
        Me.cbo_station_stationName.TabIndex = 4
        '
        'lbl_station_stationName
        '
        Me.lbl_station_stationName.AutoSize = True
        Me.lbl_station_stationName.Location = New System.Drawing.Point(40, 44)
        Me.lbl_station_stationName.Name = "lbl_station_stationName"
        Me.lbl_station_stationName.Size = New System.Drawing.Size(71, 13)
        Me.lbl_station_stationName.TabIndex = 5
        Me.lbl_station_stationName.Text = "Station Name"
        '
        'cbo_obsElement_elementName
        '
        Me.cbo_obsElement_elementName.FormattingEnabled = True
        Me.cbo_obsElement_elementName.Location = New System.Drawing.Point(132, 93)
        Me.cbo_obsElement_elementName.Name = "cbo_obsElement_elementName"
        Me.cbo_obsElement_elementName.Size = New System.Drawing.Size(276, 21)
        Me.cbo_obsElement_elementName.TabIndex = 6
        '
        'lbl_obsElement_elementName
        '
        Me.lbl_obsElement_elementName.AutoSize = True
        Me.lbl_obsElement_elementName.Location = New System.Drawing.Point(40, 96)
        Me.lbl_obsElement_elementName.Name = "lbl_obsElement_elementName"
        Me.lbl_obsElement_elementName.Size = New System.Drawing.Size(56, 13)
        Me.lbl_obsElement_elementName.TabIndex = 7
        Me.lbl_obsElement_elementName.Text = "Element(s)"
        '
        'rad_obsElement_elementtype_daily
        '
        Me.rad_obsElement_elementtype_daily.AutoSize = True
        Me.rad_obsElement_elementtype_daily.Location = New System.Drawing.Point(132, 145)
        Me.rad_obsElement_elementtype_daily.Name = "rad_obsElement_elementtype_daily"
        Me.rad_obsElement_elementtype_daily.Size = New System.Drawing.Size(48, 17)
        Me.rad_obsElement_elementtype_daily.TabIndex = 8
        Me.rad_obsElement_elementtype_daily.TabStop = True
        Me.rad_obsElement_elementtype_daily.Text = "Daily"
        Me.rad_obsElement_elementtype_daily.UseVisualStyleBackColor = True
        '
        'rad_obsElement_elementtype_monthly
        '
        Me.rad_obsElement_elementtype_monthly.AutoSize = True
        Me.rad_obsElement_elementtype_monthly.Location = New System.Drawing.Point(216, 145)
        Me.rad_obsElement_elementtype_monthly.Name = "rad_obsElement_elementtype_monthly"
        Me.rad_obsElement_elementtype_monthly.Size = New System.Drawing.Size(62, 17)
        Me.rad_obsElement_elementtype_monthly.TabIndex = 9
        Me.rad_obsElement_elementtype_monthly.TabStop = True
        Me.rad_obsElement_elementtype_monthly.Text = "Monthly"
        Me.rad_obsElement_elementtype_monthly.UseVisualStyleBackColor = True
        '
        'lbl_obsElement_elementtype
        '
        Me.lbl_obsElement_elementtype.AutoSize = True
        Me.lbl_obsElement_elementtype.Location = New System.Drawing.Point(40, 149)
        Me.lbl_obsElement_elementtype.Name = "lbl_obsElement_elementtype"
        Me.lbl_obsElement_elementtype.Size = New System.Drawing.Size(72, 13)
        Me.lbl_obsElement_elementtype.TabIndex = 10
        Me.lbl_obsElement_elementtype.Text = "Element Type"
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Location = New System.Drawing.Point(132, 193)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(276, 20)
        Me.dtpDateStart.TabIndex = 12
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Location = New System.Drawing.Point(132, 244)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(276, 20)
        Me.dtpDateEnd.TabIndex = 13
        '
        'lblDateStart
        '
        Me.lblDateStart.AutoSize = True
        Me.lblDateStart.Location = New System.Drawing.Point(40, 199)
        Me.lblDateStart.Name = "lblDateStart"
        Me.lblDateStart.Size = New System.Drawing.Size(55, 13)
        Me.lblDateStart.TabIndex = 14
        Me.lblDateStart.Text = "Start Date"
        '
        'lblDateEnd
        '
        Me.lblDateEnd.AutoSize = True
        Me.lblDateEnd.Location = New System.Drawing.Point(40, 250)
        Me.lblDateEnd.Name = "lblDateEnd"
        Me.lblDateEnd.Size = New System.Drawing.Size(39, 13)
        Me.lblDateEnd.TabIndex = 15
        Me.lblDateEnd.Text = "Label2"
        '
        'frmProduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.lblDateEnd)
        Me.Controls.Add(Me.lblDateStart)
        Me.Controls.Add(Me.dtpDateEnd)
        Me.Controls.Add(Me.dtpDateStart)
        Me.Controls.Add(Me.lbl_obsElement_elementtype)
        Me.Controls.Add(Me.rad_obsElement_elementtype_monthly)
        Me.Controls.Add(Me.rad_obsElement_elementtype_daily)
        Me.Controls.Add(Me.lbl_obsElement_elementName)
        Me.Controls.Add(Me.cbo_obsElement_elementName)
        Me.Controls.Add(Me.lbl_station_stationName)
        Me.Controls.Add(Me.cbo_station_stationName)
        Me.Name = "frmProduct"
        Me.Text = "Generate Product Example"
        Me.Controls.SetChildIndex(Me.cbo_station_stationName, 0)
        Me.Controls.SetChildIndex(Me.lbl_station_stationName, 0)
        Me.Controls.SetChildIndex(Me.cbo_obsElement_elementName, 0)
        Me.Controls.SetChildIndex(Me.lbl_obsElement_elementName, 0)
        Me.Controls.SetChildIndex(Me.rad_obsElement_elementtype_daily, 0)
        Me.Controls.SetChildIndex(Me.rad_obsElement_elementtype_monthly, 0)
        Me.Controls.SetChildIndex(Me.lbl_obsElement_elementtype, 0)
        Me.Controls.SetChildIndex(Me.dtpDateStart, 0)
        Me.Controls.SetChildIndex(Me.dtpDateEnd, 0)
        Me.Controls.SetChildIndex(Me.lblDateStart, 0)
        Me.Controls.SetChildIndex(Me.lblDateEnd, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbo_station_stationName As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_station_stationName As System.Windows.Forms.Label
    Friend WithEvents cbo_obsElement_elementName As System.Windows.Forms.ComboBox
    Friend WithEvents lbl_obsElement_elementName As System.Windows.Forms.Label
    Friend WithEvents rad_obsElement_elementtype_daily As System.Windows.Forms.RadioButton
    Friend WithEvents rad_obsElement_elementtype_monthly As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_obsElement_elementtype As System.Windows.Forms.Label
    Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateStart As System.Windows.Forms.Label
    Friend WithEvents lblDateEnd As System.Windows.Forms.Label

End Class
