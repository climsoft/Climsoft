<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataSelector
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
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.cboElement = New System.Windows.Forms.ComboBox()
        Me.cboStation = New System.Windows.Forms.ComboBox()
        Me.lvwStation = New System.Windows.Forms.ListView()
        Me.lvwElement = New System.Windows.Forms.ListView()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cmdClearAllStation = New System.Windows.Forms.Button()
        Me.cmdClearAllElement = New System.Windows.Forms.Button()
        Me.cmdDeleteStation = New System.Windows.Forms.Button()
        Me.cmdDeleteElement = New System.Windows.Forms.Button()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(348, 40)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(78, 13)
        Me.lblElement.TabIndex = 13
        Me.lblElement.Text = "Select Element"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(34, 40)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(73, 13)
        Me.lblStation.TabIndex = 12
        Me.lblStation.Text = "Select Station"
        '
        'cboElement
        '
        Me.cboElement.FormattingEnabled = True
        Me.cboElement.ItemHeight = 13
        Me.cboElement.Location = New System.Drawing.Point(441, 36)
        Me.cboElement.Name = "cboElement"
        Me.cboElement.Size = New System.Drawing.Size(178, 21)
        Me.cboElement.TabIndex = 11
        '
        'cboStation
        '
        Me.cboStation.FormattingEnabled = True
        Me.cboStation.ItemHeight = 13
        Me.cboStation.Location = New System.Drawing.Point(127, 36)
        Me.cboStation.Name = "cboStation"
        Me.cboStation.Size = New System.Drawing.Size(178, 21)
        Me.cboStation.TabIndex = 10
        '
        'lvwStation
        '
        Me.lvwStation.FullRowSelect = True
        Me.lvwStation.Location = New System.Drawing.Point(37, 96)
        Me.lvwStation.Name = "lvwStation"
        Me.lvwStation.Size = New System.Drawing.Size(268, 143)
        Me.lvwStation.TabIndex = 14
        Me.lvwStation.UseCompatibleStateImageBehavior = False
        Me.lvwStation.View = System.Windows.Forms.View.Details
        '
        'lvwElement
        '
        Me.lvwElement.FullRowSelect = True
        Me.lvwElement.Location = New System.Drawing.Point(351, 96)
        Me.lvwElement.Name = "lvwElement"
        Me.lvwElement.Size = New System.Drawing.Size(268, 143)
        Me.lvwElement.TabIndex = 15
        Me.lvwElement.UseCompatibleStateImageBehavior = False
        Me.lvwElement.View = System.Windows.Forms.View.Details
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStartDate.Location = New System.Drawing.Point(105, 292)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 16
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEndDate.Location = New System.Drawing.Point(419, 293)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 17
        '
        'cmdClearAllStation
        '
        Me.cmdClearAllStation.Location = New System.Drawing.Point(230, 245)
        Me.cmdClearAllStation.Name = "cmdClearAllStation"
        Me.cmdClearAllStation.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearAllStation.TabIndex = 18
        Me.cmdClearAllStation.Text = "Clear All"
        Me.cmdClearAllStation.UseVisualStyleBackColor = True
        '
        'cmdClearAllElement
        '
        Me.cmdClearAllElement.Location = New System.Drawing.Point(544, 245)
        Me.cmdClearAllElement.Name = "cmdClearAllElement"
        Me.cmdClearAllElement.Size = New System.Drawing.Size(75, 23)
        Me.cmdClearAllElement.TabIndex = 19
        Me.cmdClearAllElement.Text = "Clear All"
        Me.cmdClearAllElement.UseVisualStyleBackColor = True
        '
        'cmdDeleteStation
        '
        Me.cmdDeleteStation.Location = New System.Drawing.Point(116, 245)
        Me.cmdDeleteStation.Name = "cmdDeleteStation"
        Me.cmdDeleteStation.Size = New System.Drawing.Size(108, 23)
        Me.cmdDeleteStation.TabIndex = 20
        Me.cmdDeleteStation.Text = "Delete Selected"
        Me.cmdDeleteStation.UseVisualStyleBackColor = True
        '
        'cmdDeleteElement
        '
        Me.cmdDeleteElement.Location = New System.Drawing.Point(430, 245)
        Me.cmdDeleteElement.Name = "cmdDeleteElement"
        Me.cmdDeleteElement.Size = New System.Drawing.Size(108, 23)
        Me.cmdDeleteElement.TabIndex = 21
        Me.cmdDeleteElement.Text = "Delete Selected"
        Me.cmdDeleteElement.UseVisualStyleBackColor = True
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(34, 298)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(53, 13)
        Me.lblStartDate.TabIndex = 22
        Me.lblStartDate.Text = "Start date"
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(348, 298)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(50, 13)
        Me.lblEndDate.TabIndex = 23
        Me.lblEndDate.Text = "End date"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(454, 359)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 24
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(544, 359)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 25
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'frmDataSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 400)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.cmdDeleteElement)
        Me.Controls.Add(Me.cmdDeleteStation)
        Me.Controls.Add(Me.cmdClearAllElement)
        Me.Controls.Add(Me.cmdClearAllStation)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lvwElement)
        Me.Controls.Add(Me.lvwStation)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.cboElement)
        Me.Controls.Add(Me.cboStation)
        Me.Name = "frmDataSelector"
        Me.Text = "Data Selector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblElement As Label
    Friend WithEvents lblStation As Label
    Friend WithEvents cboElement As ComboBox
    Friend WithEvents cboStation As ComboBox
    Friend WithEvents lvwStation As ListView
    Friend WithEvents lvwElement As ListView
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents cmdClearAllStation As Button
    Friend WithEvents cmdClearAllElement As Button
    Friend WithEvents cmdDeleteStation As Button
    Friend WithEvents cmdDeleteElement As Button
    Friend WithEvents lblStartDate As Label
    Friend WithEvents lblEndDate As Label
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdCancel As Button
End Class
