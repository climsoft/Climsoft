<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrDirectionSpeedFlag
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
        Me.ucrDirection = New ClimsoftVer4.ucrTextBox()
        Me.ucrSpeed = New ClimsoftVer4.ucrTextBox()
        Me.ucrFlag = New ClimsoftVer4.ucrTextBox()
        Me.ucrDDFF = New ClimsoftVer4.ucrTextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ucrDirection
        '
        Me.ucrDirection.Location = New System.Drawing.Point(91, 0)
        Me.ucrDirection.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDirection.Name = "ucrDirection"
        Me.ucrDirection.Size = New System.Drawing.Size(82, 37)
        Me.ucrDirection.TabIndex = 3
        Me.ucrDirection.TextboxValue = ""
        '
        'ucrSpeed
        '
        Me.ucrSpeed.Location = New System.Drawing.Point(176, 0)
        Me.ucrSpeed.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrSpeed.Name = "ucrSpeed"
        Me.ucrSpeed.Size = New System.Drawing.Size(82, 37)
        Me.ucrSpeed.TabIndex = 4
        Me.ucrSpeed.TextboxValue = ""
        '
        'ucrFlag
        '
        Me.ucrFlag.Location = New System.Drawing.Point(261, 0)
        Me.ucrFlag.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrFlag.Name = "ucrFlag"
        Me.ucrFlag.Size = New System.Drawing.Size(82, 37)
        Me.ucrFlag.TabIndex = 5
        Me.ucrFlag.TextboxValue = ""
        '
        'ucrDDFF
        '
        Me.ucrDDFF.Location = New System.Drawing.Point(6, 0)
        Me.ucrDDFF.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDDFF.Name = "ucrDDFF"
        Me.ucrDDFF.Size = New System.Drawing.Size(82, 37)
        Me.ucrDDFF.TabIndex = 2
        Me.ucrDDFF.TextboxValue = ""
        '
        'ucrDirectionSpeedFlag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDDFF)
        Me.Controls.Add(Me.ucrFlag)
        Me.Controls.Add(Me.ucrSpeed)
        Me.Controls.Add(Me.ucrDirection)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrDirectionSpeedFlag"
        Me.Size = New System.Drawing.Size(354, 40)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrDirection As ucrTextBox
    Friend WithEvents ucrSpeed As ucrTextBox
    Friend WithEvents ucrFlag As ucrTextBox
    Friend WithEvents ucrDDFF As ucrTextBox
End Class
