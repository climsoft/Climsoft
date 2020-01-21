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
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.GroupBox13.SuspendLayout()
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
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(8, 341)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox13.Size = New System.Drawing.Size(819, 42)
        Me.GroupBox13.TabIndex = 8
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(549, 6)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(108, 33)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(680, 6)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(108, 33)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(419, 6)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(108, 33)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(288, 6)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 33)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(157, 6)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 33)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(27, 6)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 33)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrMetadataScheduleClassNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox13)
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
        Me.GroupBox13.ResumeLayout(False)
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
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
End Class
