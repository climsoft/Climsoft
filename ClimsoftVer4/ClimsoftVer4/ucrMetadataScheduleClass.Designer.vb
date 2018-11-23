<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataScheduleClass
    Inherits ClimsoftVer4.ucrBaseDataLink

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
        Me.lblScheduleClass = New System.Windows.Forms.Label()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblClass = New System.Windows.Forms.Label()
        Me.ucrTextBoxClass = New ClimsoftVer4.ucrTextBox()
        Me.ucrStationSelectorStationID = New ClimsoftVer4.ucrStationSelector()
        Me.ucrTextBoxDescription = New ClimsoftVer4.ucrTextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.cmdViewScheduleClass = New System.Windows.Forms.Button()
        Me.cmdDeleteScheduleClass = New System.Windows.Forms.Button()
        Me.cmdUpdateScheduleClass = New System.Windows.Forms.Button()
        Me.cmdAddScheduleClass = New System.Windows.Forms.Button()
        Me.cmdClearClass = New System.Windows.Forms.Button()
        Me.ucrNavigationScheduleClass = New ClimsoftVer4.ucrNavigation()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblScheduleClass
        '
        Me.lblScheduleClass.AutoSize = True
        Me.lblScheduleClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScheduleClass.Location = New System.Drawing.Point(207, 20)
        Me.lblScheduleClass.Name = "lblScheduleClass"
        Me.lblScheduleClass.Size = New System.Drawing.Size(116, 16)
        Me.lblScheduleClass.TabIndex = 15
        Me.lblScheduleClass.Text = "Schedule Class"
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(156, 133)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 17
        Me.lblStationID.Text = "Station ID"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(156, 176)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 18
        Me.lblDescription.Text = "Description"
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(156, 96)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(32, 13)
        Me.lblClass.TabIndex = 16
        Me.lblClass.Text = "Class"
        '
        'ucrTextBoxClass
        '
        Me.ucrTextBoxClass.Location = New System.Drawing.Point(220, 96)
        Me.ucrTextBoxClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxClass.Name = "ucrTextBoxClass"
        Me.ucrTextBoxClass.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxClass.TabIndex = 19
        Me.ucrTextBoxClass.TextboxValue = ""
        '
        'ucrStationSelectorStationID
        '
        Me.ucrStationSelectorStationID.Location = New System.Drawing.Point(220, 133)
        Me.ucrStationSelectorStationID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelectorStationID.Name = "ucrStationSelectorStationID"
        Me.ucrStationSelectorStationID.Size = New System.Drawing.Size(154, 24)
        Me.ucrStationSelectorStationID.TabIndex = 20
        '
        'ucrTextBoxDescription
        '
        Me.ucrTextBoxDescription.Location = New System.Drawing.Point(220, 176)
        Me.ucrTextBoxDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDescription.Name = "ucrTextBoxDescription"
        Me.ucrTextBoxDescription.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextBoxDescription.TabIndex = 21
        Me.ucrTextBoxDescription.TextboxValue = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdViewScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdDeleteScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdUpdateScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdAddScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdClearClass)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 277)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(519, 34)
        Me.GroupBox13.TabIndex = 22
        Me.GroupBox13.TabStop = False
        '
        'cmdViewScheduleClass
        '
        Me.cmdViewScheduleClass.Location = New System.Drawing.Point(420, 6)
        Me.cmdViewScheduleClass.Name = "cmdViewScheduleClass"
        Me.cmdViewScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdViewScheduleClass.TabIndex = 8
        Me.cmdViewScheduleClass.Text = "View"
        Me.cmdViewScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdDeleteScheduleClass
        '
        Me.cmdDeleteScheduleClass.Location = New System.Drawing.Point(318, 6)
        Me.cmdDeleteScheduleClass.Name = "cmdDeleteScheduleClass"
        Me.cmdDeleteScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdDeleteScheduleClass.TabIndex = 7
        Me.cmdDeleteScheduleClass.Text = "Delete"
        Me.cmdDeleteScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdUpdateScheduleClass
        '
        Me.cmdUpdateScheduleClass.Location = New System.Drawing.Point(216, 6)
        Me.cmdUpdateScheduleClass.Name = "cmdUpdateScheduleClass"
        Me.cmdUpdateScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdUpdateScheduleClass.TabIndex = 6
        Me.cmdUpdateScheduleClass.Text = "Update"
        Me.cmdUpdateScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdAddScheduleClass
        '
        Me.cmdAddScheduleClass.Location = New System.Drawing.Point(114, 7)
        Me.cmdAddScheduleClass.Name = "cmdAddScheduleClass"
        Me.cmdAddScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdAddScheduleClass.TabIndex = 5
        Me.cmdAddScheduleClass.Text = "Save"
        Me.cmdAddScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdClearClass
        '
        Me.cmdClearClass.Location = New System.Drawing.Point(12, 5)
        Me.cmdClearClass.Name = "cmdClearClass"
        Me.cmdClearClass.Size = New System.Drawing.Size(81, 27)
        Me.cmdClearClass.TabIndex = 4
        Me.cmdClearClass.Text = "AddNew"
        Me.cmdClearClass.UseVisualStyleBackColor = True
        '
        'ucrNavigationScheduleClass
        '
        Me.ucrNavigationScheduleClass.Location = New System.Drawing.Point(95, 319)
        Me.ucrNavigationScheduleClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationScheduleClass.Name = "ucrNavigationScheduleClass"
        Me.ucrNavigationScheduleClass.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationScheduleClass.TabIndex = 96
        '
        'ucrMetadataScheduleClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrNavigationScheduleClass)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrTextBoxDescription)
        Me.Controls.Add(Me.ucrStationSelectorStationID)
        Me.Controls.Add(Me.ucrTextBoxClass)
        Me.Controls.Add(Me.lblScheduleClass)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblClass)
        Me.Name = "ucrMetadataScheduleClass"
        Me.Size = New System.Drawing.Size(530, 349)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblScheduleClass As Label
    Friend WithEvents lblStationID As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblClass As Label
    Friend WithEvents ucrTextBoxClass As ucrTextBox
    Friend WithEvents ucrStationSelectorStationID As ucrStationSelector
    Friend WithEvents ucrTextBoxDescription As ucrTextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents cmdViewScheduleClass As Button
    Friend WithEvents cmdDeleteScheduleClass As Button
    Friend WithEvents cmdUpdateScheduleClass As Button
    Friend WithEvents cmdAddScheduleClass As Button
    Friend WithEvents cmdClearClass As Button
    Friend WithEvents ucrNavigationScheduleClass As ucrNavigation
End Class
