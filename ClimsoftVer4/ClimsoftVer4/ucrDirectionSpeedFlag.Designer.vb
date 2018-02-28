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
        Me.ucrDD = New ClimsoftVer4.ucrTextBox()
        Me.ucrFF = New ClimsoftVer4.ucrTextBox()
        Me.ucrFlag = New ClimsoftVer4.ucrTextBox()
        Me.ucrDDFF = New ClimsoftVer4.ucrTextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ucrDD
        '
        Me.ucrDD.Location = New System.Drawing.Point(91, 0)
        Me.ucrDD.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDD.Name = "ucrDD"
        Me.ucrDD.Size = New System.Drawing.Size(82, 37)
        Me.ucrDD.TabIndex = 581
        Me.ucrDD.TextboxValue = ""
        '
        'ucrFF
        '
        Me.ucrFF.Location = New System.Drawing.Point(176, 0)
        Me.ucrFF.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrFF.Name = "ucrFF"
        Me.ucrFF.Size = New System.Drawing.Size(82, 37)
        Me.ucrFF.TabIndex = 582
        Me.ucrFF.TextboxValue = ""
        '
        'ucrFlag
        '
        Me.ucrFlag.Location = New System.Drawing.Point(261, 0)
        Me.ucrFlag.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrFlag.Name = "ucrFlag"
        Me.ucrFlag.Size = New System.Drawing.Size(82, 37)
        Me.ucrFlag.TabIndex = 583
        Me.ucrFlag.TextboxValue = ""
        '
        'ucrDDFF
        '
        Me.ucrDDFF.Location = New System.Drawing.Point(6, 0)
        Me.ucrDDFF.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrDDFF.Name = "ucrDDFF"
        Me.ucrDDFF.Size = New System.Drawing.Size(82, 37)
        Me.ucrDDFF.TabIndex = 584
        Me.ucrDDFF.TextboxValue = ""
        '
        'ucrDirectionSpeedFlag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrDDFF)
        Me.Controls.Add(Me.ucrFlag)
        Me.Controls.Add(Me.ucrFF)
        Me.Controls.Add(Me.ucrDD)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrDirectionSpeedFlag"
        Me.Size = New System.Drawing.Size(354, 40)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ucrDD As ucrTextBox
    Friend WithEvents ucrFF As ucrTextBox
    Friend WithEvents ucrFlag As ucrTextBox
    Friend WithEvents ucrDDFF As ucrTextBox
End Class
