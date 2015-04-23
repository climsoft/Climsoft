<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaunchPad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnStationInformation = New System.Windows.Forms.Button()
        Me.btnElementInformation = New System.Windows.Forms.Button()
        Me.btnSynopticData = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStationInformation
        '
        Me.btnStationInformation.Location = New System.Drawing.Point(128, 51)
        Me.btnStationInformation.Name = "btnStationInformation"
        Me.btnStationInformation.Size = New System.Drawing.Size(161, 23)
        Me.btnStationInformation.TabIndex = 0
        Me.btnStationInformation.Text = "Station Information"
        Me.btnStationInformation.UseVisualStyleBackColor = True
        '
        'btnElementInformation
        '
        Me.btnElementInformation.Location = New System.Drawing.Point(128, 100)
        Me.btnElementInformation.Name = "btnElementInformation"
        Me.btnElementInformation.Size = New System.Drawing.Size(161, 23)
        Me.btnElementInformation.TabIndex = 1
        Me.btnElementInformation.Text = "Element Information"
        Me.btnElementInformation.UseVisualStyleBackColor = True
        '
        'btnSynopticData
        '
        Me.btnSynopticData.Location = New System.Drawing.Point(128, 147)
        Me.btnSynopticData.Name = "btnSynopticData"
        Me.btnSynopticData.Size = New System.Drawing.Size(161, 23)
        Me.btnSynopticData.TabIndex = 2
        Me.btnSynopticData.Text = "Synoptic Data Key-entry"
        Me.btnSynopticData.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(128, 197)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(160, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FormLaunchPad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 297)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSynopticData)
        Me.Controls.Add(Me.btnElementInformation)
        Me.Controls.Add(Me.btnStationInformation)
        Me.MaximizeBox = False
        Me.Name = "FormLaunchPad"
        Me.Text = "FormLaunchPad"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStationInformation As System.Windows.Forms.Button
    Friend WithEvents btnElementInformation As System.Windows.Forms.Button
    Friend WithEvents btnSynopticData As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
