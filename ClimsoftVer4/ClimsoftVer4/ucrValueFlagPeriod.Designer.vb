<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrValueFlagPeriod
    Inherits ClimsoftVer4.ucrBaseDataLink

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
        Me.ucrValue = New ClimsoftVer4.ucrTextBox()
        Me.ucrFlag = New ClimsoftVer4.ucrTextBox()
        Me.ucrPeriod = New ClimsoftVer4.ucrTextBox()
        Me.SuspendLayout()
        '
        'ucrValue
        '
        Me.ucrValue.Location = New System.Drawing.Point(0, 8)
        Me.ucrValue.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrValue.Name = "ucrValue"
        Me.ucrValue.Size = New System.Drawing.Size(86, 38)
        Me.ucrValue.TabIndex = 581
        '
        'ucrFlag
        '
        Me.ucrFlag.Location = New System.Drawing.Point(91, 8)
        Me.ucrFlag.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrFlag.Name = "ucrFlag"
        Me.ucrFlag.Size = New System.Drawing.Size(86, 38)
        Me.ucrFlag.TabIndex = 582
        '
        'ucrPeriod
        '
        Me.ucrPeriod.Location = New System.Drawing.Point(189, 8)
        Me.ucrPeriod.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrPeriod.Name = "ucrPeriod"
        Me.ucrPeriod.Size = New System.Drawing.Size(86, 38)
        Me.ucrPeriod.TabIndex = 583
        '
        'ucrValueFlagPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrPeriod)
        Me.Controls.Add(Me.ucrFlag)
        Me.Controls.Add(Me.ucrValue)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrValueFlagPeriod"
        Me.Size = New System.Drawing.Size(308, 63)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrValue As ucrTextBox
    Friend WithEvents ucrFlag As ucrTextBox
    Friend WithEvents ucrPeriod As ucrTextBox
End Class
