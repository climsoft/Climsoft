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
        Me.btnClear = New System.Windows.Forms.Button()
        Me.ucrNavigationStationElement = New ClimsoftVer4.ucrNavigation()
        Me.ucrDatePickerBeginDate = New ClimsoftVer4.ucrDatePicker()
        Me.ucrDatePickerEndDate = New ClimsoftVer4.ucrDatePicker()
        Me.lblStationElement = New System.Windows.Forms.Label()
        Me.ucrElementSelector = New ClimsoftVer4.ucrElementSelector()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ucrDataLinkInstrumentID
        '
        Me.ucrDataLinkInstrumentID.FieldName = "recordedWith"
        Me.ucrDataLinkInstrumentID.Location = New System.Drawing.Point(363, 215)
        Me.ucrDataLinkInstrumentID.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkInstrumentID.Name = "ucrDataLinkInstrumentID"
        Me.ucrDataLinkInstrumentID.Size = New System.Drawing.Size(267, 32)
        Me.ucrDataLinkInstrumentID.TabIndex = 6
        Me.ucrDataLinkInstrumentID.Tag = "recordedWith"
        '
        'lblInstrumentCode
        '
        Me.lblInstrumentCode.AutoSize = True
        Me.lblInstrumentCode.Location = New System.Drawing.Point(453, 274)
        Me.lblInstrumentCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstrumentCode.Name = "lblInstrumentCode"
        Me.lblInstrumentCode.Size = New System.Drawing.Size(100, 20)
        Me.lblInstrumentCode.TabIndex = 9
        Me.lblInstrumentCode.Text = "(Code Table)"
        '
        'lblInstumentType
        '
        Me.lblInstumentType.AutoSize = True
        Me.lblInstumentType.Location = New System.Drawing.Point(222, 274)
        Me.lblInstumentType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstumentType.Name = "lblInstumentType"
        Me.lblInstumentType.Size = New System.Drawing.Size(124, 20)
        Me.lblInstumentType.TabIndex = 7
        Me.lblInstumentType.Text = "Instrument Type"
        '
        'lblBdate
        '
        Me.lblBdate.AutoSize = True
        Me.lblBdate.Location = New System.Drawing.Point(224, 414)
        Me.lblBdate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBdate.Name = "lblBdate"
        Me.lblBdate.Size = New System.Drawing.Size(89, 20)
        Me.lblBdate.TabIndex = 14
        Me.lblBdate.Text = "Begin Date"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(222, 369)
        Me.lblHeight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(56, 20)
        Me.lblHeight.TabIndex = 12
        Me.lblHeight.Text = "Height"
        '
        'lblSchedule
        '
        Me.lblSchedule.AutoSize = True
        Me.lblSchedule.Location = New System.Drawing.Point(222, 322)
        Me.lblSchedule.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSchedule.Name = "lblSchedule"
        Me.lblSchedule.Size = New System.Drawing.Size(119, 20)
        Me.lblSchedule.TabIndex = 10
        Me.lblSchedule.Text = "Schedule Class"
        '
        'lblInstrument
        '
        Me.lblInstrument.AutoSize = True
        Me.lblInstrument.Location = New System.Drawing.Point(222, 228)
        Me.lblInstrument.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstrument.Name = "lblInstrument"
        Me.lblInstrument.Size = New System.Drawing.Size(107, 20)
        Me.lblInstrument.TabIndex = 5
        Me.lblInstrument.Text = "Instrument ID"
        '
        'lblEdate
        '
        Me.lblEdate.AutoSize = True
        Me.lblEdate.Location = New System.Drawing.Point(222, 462)
        Me.lblEdate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEdate.Name = "lblEdate"
        Me.lblEdate.Size = New System.Drawing.Size(77, 20)
        Me.lblEdate.TabIndex = 16
        Me.lblEdate.Text = "End Date"
        '
        'lblElement
        '
        Me.lblElement.AutoSize = True
        Me.lblElement.Location = New System.Drawing.Point(222, 185)
        Me.lblElement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblElement.Name = "lblElement"
        Me.lblElement.Size = New System.Drawing.Size(89, 20)
        Me.lblElement.TabIndex = 3
        Me.lblElement.Text = "Element ID"
        '
        'lblstation
        '
        Me.lblstation.AutoSize = True
        Me.lblstation.Location = New System.Drawing.Point(222, 135)
        Me.lblstation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblstation.Name = "lblstation"
        Me.lblstation.Size = New System.Drawing.Size(81, 20)
        Me.lblstation.TabIndex = 1
        Me.lblstation.Text = "Station ID"
        '
        'ucrTextboxInstrumentType
        '
        Me.ucrTextboxInstrumentType.FieldName = "instrumentcode"
        Me.ucrTextboxInstrumentType.Location = New System.Drawing.Point(364, 263)
        Me.ucrTextboxInstrumentType.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextboxInstrumentType.Name = "ucrTextboxInstrumentType"
        Me.ucrTextboxInstrumentType.Size = New System.Drawing.Size(76, 31)
        Me.ucrTextboxInstrumentType.TabIndex = 8
        Me.ucrTextboxInstrumentType.Tag = "instrumentcode"
        Me.ucrTextboxInstrumentType.TextboxValue = ""
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.FieldName = "recordedFrom"
        Me.ucrStationSelector.Location = New System.Drawing.Point(363, 128)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(267, 37)
        Me.ucrStationSelector.TabIndex = 2
        Me.ucrStationSelector.Tag = "recordedFrom"
        '
        'ucrDataLinkScheduleClass
        '
        Me.ucrDataLinkScheduleClass.FieldName = "scheduledFor"
        Me.ucrDataLinkScheduleClass.Location = New System.Drawing.Point(363, 309)
        Me.ucrDataLinkScheduleClass.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDataLinkScheduleClass.Name = "ucrDataLinkScheduleClass"
        Me.ucrDataLinkScheduleClass.Size = New System.Drawing.Size(267, 32)
        Me.ucrDataLinkScheduleClass.TabIndex = 11
        Me.ucrDataLinkScheduleClass.Tag = "scheduledFor"
        '
        'ucrTextHeight
        '
        Me.ucrTextHeight.FieldName = "height"
        Me.ucrTextHeight.Location = New System.Drawing.Point(363, 358)
        Me.ucrTextHeight.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrTextHeight.Name = "ucrTextHeight"
        Me.ucrTextHeight.Size = New System.Drawing.Size(76, 31)
        Me.ucrTextHeight.TabIndex = 13
        Me.ucrTextHeight.Tag = "height"
        Me.ucrTextHeight.TextboxValue = ""
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(188, 15)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 35)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(346, 15)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(112, 35)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(506, 15)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(112, 35)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(824, 15)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(112, 35)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(28, 15)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(112, 35)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnClear)
        Me.GroupBox7.Controls.Add(Me.btnAddNew)
        Me.GroupBox7.Controls.Add(Me.btnView)
        Me.GroupBox7.Controls.Add(Me.btnDelete)
        Me.GroupBox7.Controls.Add(Me.btnUpdate)
        Me.GroupBox7.Controls.Add(Me.btnSave)
        Me.GroupBox7.Location = New System.Drawing.Point(0, 558)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox7.Size = New System.Drawing.Size(964, 63)
        Me.GroupBox7.TabIndex = 18
        Me.GroupBox7.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(664, 15)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(112, 35)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'ucrNavigationStationElement
        '
        Me.ucrNavigationStationElement.Location = New System.Drawing.Point(207, 634)
        Me.ucrNavigationStationElement.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrNavigationStationElement.Name = "ucrNavigationStationElement"
        Me.ucrNavigationStationElement.Size = New System.Drawing.Size(550, 38)
        Me.ucrNavigationStationElement.TabIndex = 19
        '
        'ucrDatePickerBeginDate
        '
        Me.ucrDatePickerBeginDate.FieldName = "beginDate"
        Me.ucrDatePickerBeginDate.Location = New System.Drawing.Point(363, 402)
        Me.ucrDatePickerBeginDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerBeginDate.Name = "ucrDatePickerBeginDate"
        Me.ucrDatePickerBeginDate.Size = New System.Drawing.Size(267, 32)
        Me.ucrDatePickerBeginDate.TabIndex = 15
        Me.ucrDatePickerBeginDate.Tag = "beginDate"
        '
        'ucrDatePickerEndDate
        '
        Me.ucrDatePickerEndDate.FieldName = "endDate"
        Me.ucrDatePickerEndDate.Location = New System.Drawing.Point(363, 449)
        Me.ucrDatePickerEndDate.Margin = New System.Windows.Forms.Padding(9, 12, 9, 12)
        Me.ucrDatePickerEndDate.Name = "ucrDatePickerEndDate"
        Me.ucrDatePickerEndDate.Size = New System.Drawing.Size(267, 32)
        Me.ucrDatePickerEndDate.TabIndex = 17
        Me.ucrDatePickerEndDate.Tag = "endDate"
        '
        'lblStationElement
        '
        Me.lblStationElement.AutoSize = True
        Me.lblStationElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStationElement.Location = New System.Drawing.Point(442, 32)
        Me.lblStationElement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStationElement.Name = "lblStationElement"
        Me.lblStationElement.Size = New System.Drawing.Size(151, 22)
        Me.lblStationElement.TabIndex = 20
        Me.lblStationElement.Text = "Station Element"
        '
        'ucrElementSelector
        '
        Me.ucrElementSelector.FieldName = "describedBy"
        Me.ucrElementSelector.Location = New System.Drawing.Point(363, 173)
        Me.ucrElementSelector.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrElementSelector.Name = "ucrElementSelector"
        Me.ucrElementSelector.Size = New System.Drawing.Size(267, 32)
        Me.ucrElementSelector.TabIndex = 21
        Me.ucrElementSelector.Tag = "describedBy"
        '
        'ucrMetadataStationElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrElementSelector)
        Me.Controls.Add(Me.lblStationElement)
        Me.Controls.Add(Me.ucrDatePickerEndDate)
        Me.Controls.Add(Me.ucrDatePickerBeginDate)
        Me.Controls.Add(Me.ucrNavigationStationElement)
        Me.Controls.Add(Me.ucrTextHeight)
        Me.Controls.Add(Me.ucrDataLinkScheduleClass)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.ucrTextboxInstrumentType)
        Me.Controls.Add(Me.ucrDataLinkInstrumentID)
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
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrMetadataStationElement"
        Me.Size = New System.Drawing.Size(964, 680)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrDataLinkInstrumentID As ucrDataLinkCombobox
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
    Friend WithEvents ucrTextHeight As ucrTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents ucrNavigationStationElement As ucrNavigation
    Friend WithEvents ucrDatePickerBeginDate As ucrDatePicker
    Friend WithEvents ucrDatePickerEndDate As ucrDatePicker
    Friend WithEvents btnClear As Button
    Friend WithEvents lblStationElement As Label
    Friend WithEvents ucrElementSelector As ucrElementSelector
End Class
