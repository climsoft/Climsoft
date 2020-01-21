<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataInstrumentNew
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
        Me.lblInstrumentID = New System.Windows.Forms.Label()
        Me.ucrDatalinkInstrument = New ClimsoftVer4.ucrComboboxNew()
        Me.lblInstrumentName = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewInstrumentName = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblInstrumentAbbreviation = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewAbbreviation = New ClimsoftVer4.ucrTextBoxNew()
        Me.lbStationID = New System.Windows.Forms.Label()
        Me.ucrStationSelector = New ClimsoftVer4.ucrComboboxNew()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewSerialNumber = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewModel = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewManufacturer = New ClimsoftVer4.ucrTextBoxNew()
        Me.SuspendLayout()
        '
        'lblInstrumentID
        '
        Me.lblInstrumentID.AutoSize = True
        Me.lblInstrumentID.Location = New System.Drawing.Point(39, 66)
        Me.lblInstrumentID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstrumentID.Name = "lblInstrumentID"
        Me.lblInstrumentID.Size = New System.Drawing.Size(91, 17)
        Me.lblInstrumentID.TabIndex = 2
        Me.lblInstrumentID.Text = "Instrument ID"
        '
        'ucrDatalinkInstrument
        '
        Me.ucrDatalinkInstrument.Location = New System.Drawing.Point(176, 57)
        Me.ucrDatalinkInstrument.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrDatalinkInstrument.Name = "ucrDatalinkInstrument"
        Me.ucrDatalinkInstrument.Size = New System.Drawing.Size(185, 26)
        Me.ucrDatalinkInstrument.TabIndex = 3
        '
        'lblInstrumentName
        '
        Me.lblInstrumentName.AutoSize = True
        Me.lblInstrumentName.Location = New System.Drawing.Point(39, 101)
        Me.lblInstrumentName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstrumentName.Name = "lblInstrumentName"
        Me.lblInstrumentName.Size = New System.Drawing.Size(45, 17)
        Me.lblInstrumentName.TabIndex = 4
        Me.lblInstrumentName.Text = "Name"
        '
        'ucrTextBoxNewInstrumentName
        '
        Me.ucrTextBoxNewInstrumentName.Location = New System.Drawing.Point(176, 92)
        Me.ucrTextBoxNewInstrumentName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewInstrumentName.Name = "ucrTextBoxNewInstrumentName"
        Me.ucrTextBoxNewInstrumentName.Size = New System.Drawing.Size(185, 25)
        Me.ucrTextBoxNewInstrumentName.TabIndex = 5
        Me.ucrTextBoxNewInstrumentName.TextboxValue = ""
        '
        'lblInstrumentAbbreviation
        '
        Me.lblInstrumentAbbreviation.AutoSize = True
        Me.lblInstrumentAbbreviation.Location = New System.Drawing.Point(39, 135)
        Me.lblInstrumentAbbreviation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInstrumentAbbreviation.Name = "lblInstrumentAbbreviation"
        Me.lblInstrumentAbbreviation.Size = New System.Drawing.Size(87, 17)
        Me.lblInstrumentAbbreviation.TabIndex = 6
        Me.lblInstrumentAbbreviation.Text = "Abbreviation"
        '
        'ucrTextBoxNewAbbreviation
        '
        Me.ucrTextBoxNewAbbreviation.Location = New System.Drawing.Point(176, 133)
        Me.ucrTextBoxNewAbbreviation.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewAbbreviation.Name = "ucrTextBoxNewAbbreviation"
        Me.ucrTextBoxNewAbbreviation.Size = New System.Drawing.Size(185, 25)
        Me.ucrTextBoxNewAbbreviation.TabIndex = 7
        Me.ucrTextBoxNewAbbreviation.TextboxValue = ""
        '
        'lbStationID
        '
        Me.lbStationID.AutoSize = True
        Me.lbStationID.Location = New System.Drawing.Point(39, 170)
        Me.lbStationID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbStationID.Name = "lbStationID"
        Me.lbStationID.Size = New System.Drawing.Size(69, 17)
        Me.lbStationID.TabIndex = 8
        Me.lbStationID.Text = "Station ID"
        '
        'ucrStationSelector
        '
        Me.ucrStationSelector.Location = New System.Drawing.Point(176, 170)
        Me.ucrStationSelector.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrStationSelector.Name = "ucrStationSelector"
        Me.ucrStationSelector.Size = New System.Drawing.Size(185, 26)
        Me.ucrStationSelector.TabIndex = 9
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Location = New System.Drawing.Point(39, 204)
        Me.lblSerialNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(98, 17)
        Me.lblSerialNumber.TabIndex = 10
        Me.lblSerialNumber.Text = "Serial Number"
        '
        'ucrTextBoxNewSerialNumber
        '
        Me.ucrTextBoxNewSerialNumber.Location = New System.Drawing.Point(176, 204)
        Me.ucrTextBoxNewSerialNumber.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewSerialNumber.Name = "ucrTextBoxNewSerialNumber"
        Me.ucrTextBoxNewSerialNumber.Size = New System.Drawing.Size(185, 25)
        Me.ucrTextBoxNewSerialNumber.TabIndex = 11
        Me.ucrTextBoxNewSerialNumber.TextboxValue = ""
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(39, 239)
        Me.lblModel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(46, 17)
        Me.lblModel.TabIndex = 12
        Me.lblModel.Text = "Model"
        '
        'ucrTextBoxNewModel
        '
        Me.ucrTextBoxNewModel.Location = New System.Drawing.Point(176, 239)
        Me.ucrTextBoxNewModel.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewModel.Name = "ucrTextBoxNewModel"
        Me.ucrTextBoxNewModel.Size = New System.Drawing.Size(185, 25)
        Me.ucrTextBoxNewModel.TabIndex = 13
        Me.ucrTextBoxNewModel.TextboxValue = ""
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Location = New System.Drawing.Point(39, 273)
        Me.lblManufacturer.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(92, 17)
        Me.lblManufacturer.TabIndex = 14
        Me.lblManufacturer.Text = "Manufacturer"
        '
        'ucrTextBoxNewManufacturer
        '
        Me.ucrTextBoxNewManufacturer.Location = New System.Drawing.Point(176, 273)
        Me.ucrTextBoxNewManufacturer.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewManufacturer.Name = "ucrTextBoxNewManufacturer"
        Me.ucrTextBoxNewManufacturer.Size = New System.Drawing.Size(185, 25)
        Me.ucrTextBoxNewManufacturer.TabIndex = 15
        Me.ucrTextBoxNewManufacturer.TextboxValue = ""
        '
        'ucrMetadataInstrumentNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextBoxNewManufacturer)
        Me.Controls.Add(Me.lblManufacturer)
        Me.Controls.Add(Me.ucrTextBoxNewModel)
        Me.Controls.Add(Me.lblModel)
        Me.Controls.Add(Me.ucrTextBoxNewSerialNumber)
        Me.Controls.Add(Me.lblSerialNumber)
        Me.Controls.Add(Me.ucrStationSelector)
        Me.Controls.Add(Me.lbStationID)
        Me.Controls.Add(Me.ucrTextBoxNewAbbreviation)
        Me.Controls.Add(Me.lblInstrumentAbbreviation)
        Me.Controls.Add(Me.ucrTextBoxNewInstrumentName)
        Me.Controls.Add(Me.lblInstrumentName)
        Me.Controls.Add(Me.ucrDatalinkInstrument)
        Me.Controls.Add(Me.lblInstrumentID)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "ucrMetadataInstrumentNew"
        Me.Size = New System.Drawing.Size(901, 588)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblInstrumentID As Label
    Friend WithEvents ucrDatalinkInstrument As ucrComboboxNew
    Friend WithEvents lblInstrumentName As Label
    Friend WithEvents ucrTextBoxNewInstrumentName As ucrTextBoxNew
    Friend WithEvents lblInstrumentAbbreviation As Label
    Friend WithEvents ucrTextBoxNewAbbreviation As ucrTextBoxNew
    Friend WithEvents lbStationID As Label
    Friend WithEvents ucrStationSelector As ucrComboboxNew
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents ucrTextBoxNewSerialNumber As ucrTextBoxNew
    Friend WithEvents lblModel As Label
    Friend WithEvents ucrTextBoxNewModel As ucrTextBoxNew
    Friend WithEvents lblManufacturer As Label
    Friend WithEvents ucrTextBoxNewManufacturer As ucrTextBoxNew
End Class
