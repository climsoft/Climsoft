<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaunchPad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaunchPad))
        Me.btnStationInformation = New System.Windows.Forms.Button()
        Me.btnElementInformation = New System.Windows.Forms.Button()
        Me.btnSynopticData = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnStationInformation
        '
        resources.ApplyResources(Me.btnStationInformation, "btnStationInformation")
        Me.btnStationInformation.Name = "btnStationInformation"
        Me.btnStationInformation.UseVisualStyleBackColor = True
        '
        'btnElementInformation
        '
        resources.ApplyResources(Me.btnElementInformation, "btnElementInformation")
        Me.btnElementInformation.Name = "btnElementInformation"
        Me.btnElementInformation.UseVisualStyleBackColor = True
        '
        'btnSynopticData
        '
        resources.ApplyResources(Me.btnSynopticData, "btnSynopticData")
        Me.btnSynopticData.Name = "btnSynopticData"
        Me.btnSynopticData.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        resources.ApplyResources(Me.btnClose, "btnClose")
        Me.btnClose.Name = "btnClose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmLaunchPad
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSynopticData)
        Me.Controls.Add(Me.btnElementInformation)
        Me.Controls.Add(Me.btnStationInformation)
        Me.MaximizeBox = False
        Me.Name = "frmLaunchPad"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnStationInformation As System.Windows.Forms.Button
    Friend WithEvents btnElementInformation As System.Windows.Forms.Button
    Friend WithEvents btnSynopticData As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
