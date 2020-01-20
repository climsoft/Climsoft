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
        'ucrMetadataElementNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
End Class
