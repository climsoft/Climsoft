<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataStationElement
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
        Me.ucrDataLinkInstrumentID = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.ucrDataLinkElementID = New ClimsoftVer4.ucrDataLinkCombobox()
        Me.lblStationElement = New System.Windows.Forms.Label()
        Me.lblInstrumentCode = New System.Windows.Forms.Label()
        Me.lblInstumentType = New System.Windows.Forms.Label()
        Me.lblBdate = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblSchedule = New System.Windows.Forms.Label()
        Me.lblInstrument = New System.Windows.Forms.Label()
        Me.lblEdate = New System.Windows.Forms.Label()
        Me.lblElement = New System.Windows.Forms.Label()
        Me.lblstation = New System.Windows.Forms.Label()
        Me.ucrTextboxInstrumentType = New ClimsoftVer4.ucrTextBox()
        Me.ucrStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.ucrDataLinkScheduleClass = New ClimsoftVer4.ucrDataLinkCombobox()

        Me.ucrTextHeight = New ClimsoftVer4.ucrTextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()

        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ucrNavigationStationElement = New ClimsoftVer4.ucrNavigation()
        Me.ucrDatePickerBeginDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerEndDate = New ClimsoftVer4.ucrDatePicker()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrDataLinkInstrumentID
        '
        Me.ucrDataLinkInstrumentID.FieldName = "recordedWith"
        Me.ucrDataLinkInstrumentID.Location = New System.Drawing.Point(227, 92)
        Me.ucrDataLinkInstrumentID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkInstrumentID.Name = "ucrDataLinkInstrumentID"
        Me.ucrDataLinkInstrumentID.Size = New System.Drawing.Size(178, 21)
        Me.ucrDataLinkInstrumentID.TabIndex = 70
        Me.ucrDataLinkInstrumentID.Tag = "recordedWith"
        '
        'ucrDataLinkElementID
        '
        Me.ucrDataLinkElementID.FieldName = "describedBy"
        Me.ucrDataLinkElementID.Location = New System.Drawing.Point(227, 65)
        Me.ucrDataLinkElementID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkElementID.Name = "ucrDataLinkElementID"
        Me.ucrDataLinkElementID.Size = New System.Drawing.Size(180, 21)
        Me.ucrDataLinkElementID.TabIndex = 69
        Me.ucrDataLinkElementID.Tag = "describedBy"
        '
        'lblStationElement
        '
        Me.lblStationElement.AutoSize = True
        Me.lblStationElement.Location = New System.Drawing.Point(307, 8)
        Me.lblStationElement.Name = "lblStationElement"
        Me.lblStationElement.Size = New System.Drawing.Size(81, 13)
        Me.lblStationElement.TabIndex = 67
        Me.lblStationElement.Text = "Station Element"
        '
        'lblInstrumentCode
        '
        Me.lblInstrumentCode.AutoSize = True
        Me.lblInstrumentCode.Location = New System.Drawing.Point(287, 130)
        Me.lblInstrumentCode.Name = "lblInstrumentCode"
        Me.lblInstrumentCode.Size = New System.Drawing.Size(68, 13)
        Me.lblInstrumentCode.TabIndex = 66
        Me.lblInstrumentCode.Text = "(Code Table)"
        '
        'lblInstumentType
        '
        Me.lblInstumentType.AutoSize = True
        Me.lblInstumentType.Location = New System.Drawing.Point(133, 130)
        Me.lblInstumentType.Name = "lblInstumentType"
        Me.lblInstumentType.Size = New System.Drawing.Size(83, 13)
        Me.lblInstumentType.TabIndex = 64
        Me.lblInstumentType.Text = "Instrument Type"
        '
        'lblBdate
        '
        Me.lblBdate.AutoSize = True
        Me.lblBdate.Location = New System.Drawing.Point(134, 221)
        Me.lblBdate.Name = "lblBdate"
        Me.lblBdate.Size = New System.Drawing.Size(60, 13)
        Me.lblBdate.TabIndex = 58
        Me.lblBdate.Text = "Begin Date"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(133, 192)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(38, 13)
        Me.lblHeight.TabIndex = 57
        Me.lblHeight.Text = "Height"
        '
        'lblSchedule
        '
        Me.lblSchedule.AutoSize = True
        Me.lblSchedule.Location = New System.Drawing.Point(133, 161)
        Me.lblSchedule.Name = "lblSchedule"
        Me.lblSchedule.Size = New System.Drawing.Size(80, 13)
        Me.lblSchedule.TabIndex = 56
        Me.lblSchedule.Text = "Schedule Class"
        '
        'lblInstrument
        '
        Me.lblInstrument.AutoSize = True
        Me.lblInstrument.Location = New System.Drawing.Point(133, 100)
        Me.lblInstrument.Name = "lblInstrument"
        Me.lblInstrument.Size = New System.Drawing.Size(70, 13)
        Me.lblInstrument.TabIndex = 55
        Me.lblInstrument.Text = "Instrument ID"
        '
        'lblEdate
        '
        Me.lblEdate.AutoSize = True
        Me.lblEdate.Location = New System.Drawing.Point(133, 252)
        Me.lblEdate.Name = "lblEdate"
        Me.lblEdate.Size = New System.Drawing.Size(52, 13)
        Me.lblEdate.TabIndex = 59
        Me.lblEdate.Text = "End Date"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(133, 72)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(59, 13)
        Me.lblElement.TabIndex = 54
        Me.lblElement.Text = "Element ID"
        '
        'lblstation
        '
        Me.lblstation.AutoSize = True
        Me.lblstation.Location = New System.Drawing.Point(133, 40)
        Me.lblstation.Name = "lblstation"
        Me.lblstation.Size = New System.Drawing.Size(54, 13)
        Me.lblstation.TabIndex = 53
        Me.lblstation.Text = "Station ID"
        '
        'ucrTextboxInstrumentType
        '
        Me.ucrTextboxInstrumentType.FieldName = "instrumentcode"
        Me.ucrTextboxInstrumentType.Location = New System.Drawing.Point(228, 123)
        Me.ucrTextboxInstrumentType.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextboxInstrumentType.Name = "ucrTextboxInstrumentType"
        Me.ucrTextboxInstrumentType.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextboxInstrumentType.TabIndex = 71
        Me.ucrTextboxInstrumentType.Tag = "instrumentcode"
        Me.ucrTextboxInstrumentType.TextboxValue = ""
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "recordedFrom"
        Me.ucrStationSelector.Location = New System.Drawing.Point(227, 29)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(253, 24)
        Me.ucrStationSelector.TabIndex = 72
        Me.ucrStationSelector.Tag = "recordedFrom"
        '
        'ucrDataLinkScheduleClass
        '
        Me.ucrDataLinkScheduleClass.FieldName = "scheduledFor"
        Me.ucrDataLinkScheduleClass.Location = New System.Drawing.Point(227, 153)
        Me.ucrDataLinkScheduleClass.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrDataLinkScheduleClass.Name = "ucrDataLinkScheduleClass"
        Me.ucrDataLinkScheduleClass.Size = New System.Drawing.Size(178, 21)
        Me.ucrDataLinkScheduleClass.TabIndex = 73
        Me.ucrDataLinkScheduleClass.Tag = "scheduledFor"
        '
        'ucrTextHeight
        '
        Me.ucrTextHeight.FieldName = "height"
        Me.ucrTextHeight.Location = New System.Drawing.Point(227, 185)
        Me.ucrTextHeight.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextHeight.Name = "ucrTextHeight"
        Me.ucrTextHeight.Size = New System.Drawing.Size(51, 20)
        Me.ucrTextHeight.TabIndex = 74
        Me.ucrTextHeight.Tag = "height"
        Me.ucrTextHeight.TextboxValue = ""
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(137, 11)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(89, 25)
        Me.btnSave.TabIndex = 32
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(253, 10)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 25)
        Me.btnUpdate.TabIndex = 33
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(366, 10)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 25)
        Me.btnDelete.TabIndex = 34
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(479, 10)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(81, 25)
        Me.btnView.TabIndex = 35
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(22, 11)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(81, 27)
        Me.btnAddNew.TabIndex = 8
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnAddNew)
        Me.GroupBox7.Controls.Add(Me.btnView)
        Me.GroupBox7.Controls.Add(Me.btnDelete)
        Me.GroupBox7.Controls.Add(Me.btnUpdate)
        Me.GroupBox7.Controls.Add(Me.btnSave)
        Me.GroupBox7.Location = New System.Drawing.Point(0, 363)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(643, 41)
        Me.GroupBox7.TabIndex = 52
        Me.GroupBox7.TabStop = False
        '
        'ucrNavigationStationElement
        '
        Me.ucrNavigationStationElement.Location = New System.Drawing.Point(138, 412)
        Me.ucrNavigationStationElement.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationStationElement.Name = "ucrNavigationStationElement"
        Me.ucrNavigationStationElement.Size = New System.Drawing.Size(367, 25)
        Me.ucrNavigationStationElement.TabIndex = 36
        '
        'ucrDatePickerBeginDate
        '
        Me.ucrDatePickerBeginDate.FieldName = "beginDate"
        Me.ucrDatePickerBeginDate.Location = New System.Drawing.Point(227, 213)
        Me.ucrDatePickerBeginDate.Name = "ucrDatePickerBeginDate"
        Me.ucrDatePickerBeginDate.Size = New System.Drawing.Size(202, 21)
        Me.ucrDatePickerBeginDate.TabIndex = 75
        Me.ucrDatePickerBeginDate.Tag = "beginDate"
        '
        'ucrDatePickerEndDate
        '
        Me.ucrDatePickerEndDate.FieldName = "endDate"
        Me.ucrDatePickerEndDate.Location = New System.Drawing.Point(227, 244)
        Me.ucrDatePickerEndDate.Name = "ucrDatePickerEndDate"
        Me.ucrDatePickerEndDate.Size = New System.Drawing.Size(202, 21)
        Me.ucrDatePickerEndDate.TabIndex = 76
        Me.ucrDatePickerEndDate.Tag = "endDate"
        '
        'ucrMetadataStationElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDatePickerEndDate)
        Me.Controls.Add(Me.ucrDatePickerBeginDate)
        Me.Controls.Add(Me.ucrNavigationStationElement)
        Me.Controls.Add(Me.ucrTextHeight)
        Me.Controls.Add(Me.ucrDataLinkScheduleClass)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrTextboxInstrumentType)
        Me.Controls.Add(Me.ucrDataLinkInstrumentID)
        Me.Controls.Add(Me.ucrDataLinkElementID)
        Me.Controls.Add(Me.lblStationElement)
        Me.Controls.Add(Me.lblInstrumentCode)
        Me.Controls.Add(Me.lblInstumentType)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.lblBdate)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblSchedule)
        Me.Controls.Add(Me.lblInstrument)
        Me.Controls.Add(Me.lblEdate)
        Me.Controls.Add(Me.lblElement)
        Me.Controls.Add(Me.lblstation)
        Me.Name = "ucrMetadataStationElement"
        Me.Size = New System.Drawing.Size(643, 442)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrDataLinkInstrumentID As ucrDataLinkCombobox
    Friend WithEvents ucrDataLinkElementID As ucrDataLinkCombobox
    Friend WithEvents lblStationElement As Label
    Friend WithEvents lblInstrumentCode As Label
    Friend WithEvents lblInstumentType As Label
    Friend WithEvents lblBdate As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblSchedule As Label
    Friend WithEvents lblInstrument As Label
    Friend WithEvents lblEdate As Label
    Friend WithEvents lblElement As Label
    Friend WithEvents lblstation As Label
    Friend WithEvents ucrTextboxInstrumentType As ucrTextBox
    Friend WithEvents ucrStationSelector As ucrStationSelector
    Friend WithEvents ucrDataLinkScheduleClass As ucrDataLinkCombobox
    Friend WithEvents urTextHeight As ucrTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ucrNavigationStationElement As ucrNavigation
    Friend WithEvents ucrDatePickerBeginDate As ucrDatePicker
    Friend WithEvents ucrDatePickerEndDate As ucrDatePicker
End Class
