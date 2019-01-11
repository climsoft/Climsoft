<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataScheduleClass
    Inherits ClimsoftVer4.ucrTableEntry

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
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrTextBoxDescription = New ClimsoftVer4.ucrTextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.ucrNavigationScheduleClass = New ClimsoftVer4.ucrNavigation()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblScheduleClass
        '
        Me.lblScheduleClass.AutoSize = True
        Me.lblScheduleClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScheduleClass.Location = New System.Drawing.Point(257, 20)
        Me.lblScheduleClass.Name = "lblScheduleClass"
        Me.lblScheduleClass.Size = New System.Drawing.Size(116, 16)
        Me.lblScheduleClass.TabIndex = 0
        Me.lblScheduleClass.Text = "Schedule Class"
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(206, 133)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(54, 13)
        Me.lblStationID.TabIndex = 3
        Me.lblStationID.Text = "Station ID"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(206, 176)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(60, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Description"
        '
        'lblClass
        '
        Me.lblClass.AutoSize = True
        Me.lblClass.Location = New System.Drawing.Point(206, 96)
        Me.lblClass.Name = "lblClass"
        Me.lblClass.Size = New System.Drawing.Size(32, 13)
        Me.lblClass.TabIndex = 1
        Me.lblClass.Text = "Class"
        '
        'ucrTextBoxClass
        '
        Me.ucrTextBoxClass.FieldName = "scheduleClass"
        Me.ucrTextBoxClass.Location = New System.Drawing.Point(270, 96)
        Me.ucrTextBoxClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxClass.Name = "ucrTextBoxClass"
        Me.ucrTextBoxClass.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxClass.TabIndex = 2
        Me.ucrTextBoxClass.Tag = "scheduleClass"
        Me.ucrTextBoxClass.TextboxValue = ""
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "refersTo"
        Me.ucrStationSelector.Location = New System.Drawing.Point(270, 133)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(154, 24)
        Me.ucrStationSelector.TabIndex = 4
        Me.ucrStationSelector.Tag = "refersTo"
        '
        'ucrTextBoxDescription
        '
        Me.ucrTextBoxDescription.FieldName = "description"
        Me.ucrTextBoxDescription.Location = New System.Drawing.Point(270, 176)
        Me.ucrTextBoxDescription.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDescription.Name = "ucrTextBoxDescription"
        Me.ucrTextBoxDescription.Size = New System.Drawing.Size(154, 20)
        Me.ucrTextBoxDescription.TabIndex = 6
        Me.ucrTextBoxDescription.Tag = "description"
        Me.ucrTextBoxDescription.TextboxValue = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 277)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(614, 34)
        Me.GroupBox13.TabIndex = 7
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(412, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(81, 27)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(510, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(81, 27)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(314, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 27)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(216, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 27)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(118, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 27)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(20, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(81, 27)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrNavigationScheduleClass
        '
        Me.ucrNavigationScheduleClass.Location = New System.Drawing.Point(147, 319)
        Me.ucrNavigationScheduleClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationScheduleClass.Name = "ucrNavigationScheduleClass"
        Me.ucrNavigationScheduleClass.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationScheduleClass.TabIndex = 8
        '
        'ucrMetadataScheduleClass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrNavigationScheduleClass)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrTextBoxDescription)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrTextBoxClass)
        Me.Controls.Add(Me.lblScheduleClass)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblClass)
        Me.Name = "ucrMetadataScheduleClass"
        Me.Size = New System.Drawing.Size(630, 349)
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
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrTextBoxDescription As ucrTextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents ucrNavigationScheduleClass As ucrNavigation
    Friend WithEvents btnClear As Button
End Class
