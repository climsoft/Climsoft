<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrMetadataElementNew
    Inherits ClimsoftVer4.ucrPage

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ucrElementSelectorSearch = New ClimsoftVer4.ucrComboboxNew()
        Me.lblSearchElement = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.ucrDataLinkElementID = New ClimsoftVer4.ucrComboboxNew()
        Me.lblAbbreviation = New System.Windows.Forms.Label()
        Me.ucrTextboxAbbreviation = New ClimsoftVer4.ucrTextBoxNew()
        Me.lblName = New System.Windows.Forms.Label()
        Me.ucrTextboxName = New ClimsoftVer4.ucrTextBoxNew()
        Me.SuspendLayout()
        '
        'ucrElementSelectorSearch
        '
        Me.ucrElementSelectorSearch.Location = New System.Drawing.Point(632, 50)
        Me.ucrElementSelectorSearch.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrElementSelectorSearch.Name = "ucrElementSelectorSearch"
        Me.ucrElementSelectorSearch.Size = New System.Drawing.Size(237, 26)
        Me.ucrElementSelectorSearch.TabIndex = 0
        '
        'lblSearchElement
        '
        Me.lblSearchElement.AutoSize = True
        Me.lblSearchElement.Location = New System.Drawing.Point(514, 54)
        Me.lblSearchElement.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearchElement.Name = "lblSearchElement"
        Me.lblSearchElement.Size = New System.Drawing.Size(108, 17)
        Me.lblSearchElement.TabIndex = 25
        Me.lblSearchElement.Text = "Search Element"
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(268, 126)
        Me.lblID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(21, 17)
        Me.lblID.TabIndex = 26
        Me.lblID.Text = "ID"
        '
        'ucrDataLinkElementID
        '
        Me.ucrDataLinkElementID.Location = New System.Drawing.Point(397, 124)
        Me.ucrDataLinkElementID.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrDataLinkElementID.Name = "ucrDataLinkElementID"
        Me.ucrDataLinkElementID.Size = New System.Drawing.Size(237, 26)
        Me.ucrDataLinkElementID.TabIndex = 27
        '
        'lblAbbreviation
        '
        Me.lblAbbreviation.AutoSize = True
        Me.lblAbbreviation.Location = New System.Drawing.Point(268, 162)
        Me.lblAbbreviation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbbreviation.Name = "lblAbbreviation"
        Me.lblAbbreviation.Size = New System.Drawing.Size(87, 17)
        Me.lblAbbreviation.TabIndex = 28
        Me.lblAbbreviation.Text = "Abbreviation"
        '
        'ucrTextboxAbbreviation
        '
        Me.ucrTextboxAbbreviation.Location = New System.Drawing.Point(397, 158)
        Me.ucrTextboxAbbreviation.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextboxAbbreviation.Name = "ucrTextboxAbbreviation"
        Me.ucrTextboxAbbreviation.Size = New System.Drawing.Size(237, 25)
        Me.ucrTextboxAbbreviation.TabIndex = 29
        Me.ucrTextboxAbbreviation.TextboxValue = ""
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(268, 194)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(45, 17)
        Me.lblName.TabIndex = 30
        Me.lblName.Text = "Name"
        '
        'ucrTextboxName
        '
        Me.ucrTextboxName.Location = New System.Drawing.Point(397, 190)
        Me.ucrTextboxName.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextboxName.Name = "ucrTextboxName"
        Me.ucrTextboxName.Size = New System.Drawing.Size(237, 25)
        Me.ucrTextboxName.TabIndex = 31
        Me.ucrTextboxName.TextboxValue = ""
        '
        'ucrMetadataElementNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextboxName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.ucrTextboxAbbreviation)
        Me.Controls.Add(Me.lblAbbreviation)
        Me.Controls.Add(Me.ucrDataLinkElementID)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblSearchElement)
        Me.Controls.Add(Me.ucrElementSelectorSearch)
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "ucrMetadataElementNew"
        Me.Size = New System.Drawing.Size(901, 592)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrElementSelectorSearch As ucrComboboxNew
    Friend WithEvents lblSearchElement As Label
    Friend WithEvents lblID As Label
    Friend WithEvents ucrDataLinkElementID As ucrComboboxNew
    Friend WithEvents lblAbbreviation As Label
    Friend WithEvents ucrTextboxAbbreviation As ucrTextBoxNew
    Friend WithEvents lblName As Label
    Friend WithEvents ucrTextboxName As ucrTextBoxNew
End Class
