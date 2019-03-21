<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrAgroMet
    Inherits System.Windows.Forms.UserControl

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
        Me.ucrAgrometStationSelector = New ClimsoftVer4.ucrStationSelector()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ucrAgrometStationSelector
        '
        Me.ucrAgrometStationSelector.Location = New System.Drawing.Point(65, 19)
        Me.ucrAgrometStationSelector.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrAgrometStationSelector.Name = "ucrAgrometStationSelector"
        Me.ucrAgrometStationSelector.Size = New System.Drawing.Size(253, 24)
        Me.ucrAgrometStationSelector.TabIndex = 0
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(13, 19)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(40, 13)
        Me.lblStation.TabIndex = 1
        Me.lblStation.Text = "Station"
        '
        'ucrAgroMet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblStation)
        Me.Controls.Add(Me.ucrAgrometStationSelector)
        Me.Name = "ucrAgroMet"
        Me.Size = New System.Drawing.Size(482, 402)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrAgrometStationSelector As ucrStationSelector
    Friend WithEvents lblStation As Label
End Class
