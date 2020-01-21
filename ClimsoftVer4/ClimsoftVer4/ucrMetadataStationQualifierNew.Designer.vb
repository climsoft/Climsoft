<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationQualifierNew
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
        Me.lblStationQualifier = New System.Windows.Forms.Label()
        Me.lblQualifier = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewQualifier = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblStationID = New System.Windows.Forms.Label()
        Me.UcrComboboxNew1 = New ClimsoftVer4.ucrComboboxNew()
        Me.lblBeginDate = New System.Windows.Forms.Label()
        Me.ucrDatePickerNewBeginDate = New ClimsoftVer4.ucrDatePickerNew()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.ucrDatePickerNewEndDate = New ClimsoftVer4.ucrDatePickerNew()
        Me.lblTimeZone = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewTimeZone = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblNetworkType = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewNetworkType = New ClimsoftVer4.ucrTextBoxNew()
        Me.grpCommand2 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.UcrNavigator1 = New ClimsoftVer4.ucrNavigator()
        Me.grpCommand2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStationQualifier
        '
        Me.lblStationQualifier.AutoSize = True
        Me.lblStationQualifier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationQualifier.Location = New System.Drawing.Point(375, 37)
        Me.lblStationQualifier.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationQualifier.Name = "lblStationQualifier"
        Me.lblStationQualifier.Size = New System.Drawing.Size(146, 20)
        Me.lblStationQualifier.TabIndex = 1
        Me.lblStationQualifier.Text = "Station Qualifier"
        '
        'lblQualifier
        '
        Me.lblQualifier.AutoSize = True
        Me.lblQualifier.Location = New System.Drawing.Point(299, 110)
        Me.lblQualifier.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQualifier.Name = "lblQualifier"
        Me.lblQualifier.Size = New System.Drawing.Size(61, 17)
        Me.lblQualifier.TabIndex = 2
        Me.lblQualifier.Text = "Qualifier"
        '
        'ucrTextBoxNewQualifier
        '
        Me.ucrTextBoxNewQualifier.Location = New System.Drawing.Point(401, 110)
        Me.ucrTextBoxNewQualifier.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewQualifier.Name = "ucrTextBoxNewQualifier"
        Me.ucrTextBoxNewQualifier.Size = New System.Drawing.Size(205, 25)
        Me.ucrTextBoxNewQualifier.TabIndex = 3
        Me.ucrTextBoxNewQualifier.TextboxValue = ""
        '
        'lblStationID
        '
        Me.lblStationID.AutoSize = True
        Me.lblStationID.Location = New System.Drawing.Point(299, 155)
        Me.lblStationID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationID.Name = "lblStationID"
        Me.lblStationID.Size = New System.Drawing.Size(69, 17)
        Me.lblStationID.TabIndex = 4
        Me.lblStationID.Text = "Station ID"
        '
        'UcrComboboxNew1
        '
        Me.UcrComboboxNew1.Location = New System.Drawing.Point(401, 155)
        Me.UcrComboboxNew1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.UcrComboboxNew1.Name = "UcrComboboxNew1"
        Me.UcrComboboxNew1.Size = New System.Drawing.Size(207, 30)
        Me.UcrComboboxNew1.TabIndex = 5
        '
        'lblBeginDate
        '
        Me.lblBeginDate.AutoSize = True
        Me.lblBeginDate.Location = New System.Drawing.Point(299, 202)
        Me.lblBeginDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBeginDate.Name = "lblBeginDate"
        Me.lblBeginDate.Size = New System.Drawing.Size(78, 17)
        Me.lblBeginDate.TabIndex = 6
        Me.lblBeginDate.Text = "Begin Date"
        '
        'ucrDatePickerNewBeginDate
        '
        Me.ucrDatePickerNewBeginDate.Location = New System.Drawing.Point(401, 197)
        Me.ucrDatePickerNewBeginDate.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrDatePickerNewBeginDate.Name = "ucrDatePickerNewBeginDate"
        Me.ucrDatePickerNewBeginDate.Size = New System.Drawing.Size(207, 26)
        Me.ucrDatePickerNewBeginDate.TabIndex = 7
        '
        'lblEndDate
        '
        Me.lblEndDate.AutoSize = True
        Me.lblEndDate.Location = New System.Drawing.Point(299, 247)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(67, 17)
        Me.lblEndDate.TabIndex = 8
        Me.lblEndDate.Text = "End Date"
        '
        'ucrDatePickerNewEndDate
        '
        Me.ucrDatePickerNewEndDate.Location = New System.Drawing.Point(401, 241)
        Me.ucrDatePickerNewEndDate.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrDatePickerNewEndDate.Name = "ucrDatePickerNewEndDate"
        Me.ucrDatePickerNewEndDate.Size = New System.Drawing.Size(207, 26)
        Me.ucrDatePickerNewEndDate.TabIndex = 9
        '
        'lblTimeZone
        '
        Me.lblTimeZone.AutoSize = True
        Me.lblTimeZone.Location = New System.Drawing.Point(299, 293)
        Me.lblTimeZone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTimeZone.Name = "lblTimeZone"
        Me.lblTimeZone.Size = New System.Drawing.Size(76, 17)
        Me.lblTimeZone.TabIndex = 10
        Me.lblTimeZone.Text = "Time Zone"
        '
        'ucrTextBoxNewTimeZone
        '
        Me.ucrTextBoxNewTimeZone.Location = New System.Drawing.Point(401, 292)
        Me.ucrTextBoxNewTimeZone.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewTimeZone.Name = "ucrTextBoxNewTimeZone"
        Me.ucrTextBoxNewTimeZone.Size = New System.Drawing.Size(205, 25)
        Me.ucrTextBoxNewTimeZone.TabIndex = 11
        Me.ucrTextBoxNewTimeZone.TextboxValue = ""
        '
        'lblNetworkType
        '
        Me.lblNetworkType.AutoSize = True
        Me.lblNetworkType.Location = New System.Drawing.Point(299, 338)
        Me.lblNetworkType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNetworkType.Name = "lblNetworkType"
        Me.lblNetworkType.Size = New System.Drawing.Size(95, 17)
        Me.lblNetworkType.TabIndex = 12
        Me.lblNetworkType.Text = "Network Type"
        '
        'ucrTextBoxNewNetworkType
        '
        Me.ucrTextBoxNewNetworkType.Location = New System.Drawing.Point(401, 337)
        Me.ucrTextBoxNewNetworkType.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewNetworkType.Name = "ucrTextBoxNewNetworkType"
        Me.ucrTextBoxNewNetworkType.Size = New System.Drawing.Size(205, 25)
        Me.ucrTextBoxNewNetworkType.TabIndex = 13
        Me.ucrTextBoxNewNetworkType.TextboxValue = ""
        '
        'grpCommand2
        '
        Me.grpCommand2.Controls.Add(Me.btnClear)
        Me.grpCommand2.Controls.Add(Me.btnAddNew)
        Me.grpCommand2.Controls.Add(Me.btnView)
        Me.grpCommand2.Controls.Add(Me.btnDelete)
        Me.grpCommand2.Controls.Add(Me.btnUpdate)
        Me.grpCommand2.Controls.Add(Me.btnSave)
        Me.grpCommand2.Location = New System.Drawing.Point(4, 412)
        Me.grpCommand2.Margin = New System.Windows.Forms.Padding(4)
        Me.grpCommand2.Name = "grpCommand2"
        Me.grpCommand2.Padding = New System.Windows.Forms.Padding(4)
        Me.grpCommand2.Size = New System.Drawing.Size(893, 38)
        Me.grpCommand2.TabIndex = 14
        Me.grpCommand2.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(621, 7)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 28)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(24, 5)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(100, 28)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(771, 6)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 28)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(472, 6)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 28)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(323, 6)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(100, 28)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(173, 6)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 28)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'UcrNavigator1
        '
        Me.UcrNavigator1.Location = New System.Drawing.Point(229, 462)
        Me.UcrNavigator1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UcrNavigator1.Name = "UcrNavigator1"
        Me.UcrNavigator1.Size = New System.Drawing.Size(448, 31)
        Me.UcrNavigator1.TabIndex = 15
        '
        'ucrMetadataStationQualifierNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcrNavigator1)
        Me.Controls.Add(Me.grpCommand2)
        Me.Controls.Add(Me.ucrTextBoxNewNetworkType)
        Me.Controls.Add(Me.lblNetworkType)
        Me.Controls.Add(Me.ucrTextBoxNewTimeZone)
        Me.Controls.Add(Me.lblTimeZone)
        Me.Controls.Add(Me.ucrDatePickerNewEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.ucrDatePickerNewBeginDate)
        Me.Controls.Add(Me.lblBeginDate)
        Me.Controls.Add(Me.UcrComboboxNew1)
        Me.Controls.Add(Me.lblStationID)
        Me.Controls.Add(Me.ucrTextBoxNewQualifier)
        Me.Controls.Add(Me.lblQualifier)
        Me.Controls.Add(Me.lblStationQualifier)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "ucrMetadataStationQualifierNew"
        Me.Size = New System.Drawing.Size(907, 495)
        Me.grpCommand2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblStationQualifier As Label
    Friend WithEvents lblQualifier As Label
    Friend WithEvents ucrTextBoxNewQualifier As ucrTextBoxNew
    Friend WithEvents lblStationID As Label
    Friend WithEvents UcrComboboxNew1 As ucrComboboxNew
    Friend WithEvents lblBeginDate As Label
    Friend WithEvents ucrDatePickerNewBeginDate As ucrDatePickerNew
    Friend WithEvents lblEndDate As Label
    Friend WithEvents ucrDatePickerNewEndDate As ucrDatePickerNew
    Friend WithEvents lblTimeZone As Label
    Friend WithEvents ucrTextBoxNewTimeZone As ucrTextBoxNew
    Friend WithEvents lblNetworkType As Label
    Friend WithEvents ucrTextBoxNewNetworkType As ucrTextBoxNew
    Friend WithEvents grpCommand2 As GroupBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents UcrNavigator1 As ucrNavigator
End Class
