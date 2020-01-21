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
        'ucrMetadataStationQualifierNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
End Class
