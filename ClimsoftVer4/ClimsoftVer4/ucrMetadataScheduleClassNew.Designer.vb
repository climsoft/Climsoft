<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataScheduleClassNew
    Inherits ClimsoftVer4.ucrPage

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
        Me.lblClass = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewClass = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.ucrStationSelector = New ClimsoftVer4.ucrComboboxNew()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewDescription = New ClimsoftVer4.ucrTextBoxNew()
        Me.SuspendLayout()
        '
        'lblScheduleClass
        '
        Me.lblScheduleClass.AutoSize = True
        Me.lblScheduleClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScheduleClass.Location = New System.Drawing.Point(343, 25)
        Me.lblScheduleClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblScheduleClass.Name = "lblScheduleClass"
        Me.lblScheduleClass.Size = New System.Drawing.Size(140, 20)
        Me.lblScheduleClass.TabIndex = 1
        Me.lblScheduleClass.Text = "Schedule Class"
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(275, 118)
        Me.lblClass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(42, 17)
        Me.lblClass.TabIndex = 2
        Me.lblClass.Text = "Class"
        '
        'ucrTextBoxNewClass
        '
        Me.ucrTextBoxNewClass.Location = New System.Drawing.Point(360, 118)
        Me.ucrTextBoxNewClass.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewClass.Name = "ucrTextBoxNewClass"
        Me.ucrTextBoxNewClass.Size = New System.Drawing.Size(205, 25)
        Me.ucrTextBoxNewClass.TabIndex = 3
        Me.ucrTextBoxNewClass.TextboxValue = ""
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(275, 164)
        Me.lblStationID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(69, 17)
        Me.lblStationID.TabIndex = 4
        Me.lblStationID.Text = "Station ID"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(360, 164)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(205, 30)
        Me.ucrStationSelector.TabIndex = 5
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(275, 217)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(79, 17)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description"
        '
        'ucrTextBoxNewDescription
        '
        Me.ucrTextBoxNewDescription.Location = New System.Drawing.Point(360, 217)
        Me.ucrTextBoxNewDescription.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewDescription.Name = "ucrTextBoxNewDescription"
        Me.ucrTextBoxNewDescription.Size = New System.Drawing.Size(205, 25)
        Me.ucrTextBoxNewDescription.TabIndex = 7
        Me.ucrTextBoxNewDescription.TextboxValue = ""
        '
        'ucrMetadataScheduleClassNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextBoxNewDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.ucrTextBoxNewClass)
        Me.Controls.Add(Me.lblClass)
        Me.Controls.Add(Me.lblScheduleClass)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "ucrMetadataScheduleClassNew"
        Me.Size = New System.Drawing.Size(840, 430)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblScheduleClass As Label
    Friend WithEvents lblClass As Label
    Friend WithEvents ucrTextBoxNewClass As ucrTextBoxNew
    Friend WithEvents lblStationID As Label
    Friend WithEvents ucrStationSelector As ucrComboboxNew
    Friend WithEvents lblDescription As Label
    Friend WithEvents ucrTextBoxNewDescription As ucrTextBoxNew
End Class
