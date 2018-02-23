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
        Me.ucrValue.Location = New System.Drawing.Point(-3, -3)
        Me.ucrValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrValue.Name = "ucrValue"
        Me.ucrValue.Size = New System.Drawing.Size(55, 24)
        Me.ucrValue.TabIndex = 581
        Me.ucrValue.TextboxValue = ""
        '
        'ucrFlag
        '
        Me.ucrFlag.Location = New System.Drawing.Point(54, -3)
        Me.ucrFlag.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrFlag.Name = "ucrFlag"
        Me.ucrFlag.Size = New System.Drawing.Size(55, 24)
        Me.ucrFlag.TabIndex = 582
        Me.ucrFlag.TextboxValue = ""
        '
        'ucrPeriod
        '
        Me.ucrPeriod.Location = New System.Drawing.Point(111, -3)
        Me.ucrPeriod.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrPeriod.Name = "ucrPeriod"
        Me.ucrPeriod.Size = New System.Drawing.Size(55, 24)
        Me.ucrPeriod.TabIndex = 583
        Me.ucrPeriod.TextboxValue = ""
        '
        'ucrValueFlagPeriod
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrPeriod)
        Me.Controls.Add(Me.ucrFlag)
        Me.Controls.Add(Me.ucrValue)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ucrValueFlagPeriod"
        Me.Size = New System.Drawing.Size(165, 20)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrValue As ucrTextBox
    Friend WithEvents ucrFlag As ucrTextBox
    Friend WithEvents ucrPeriod As ucrTextBox
End Class
