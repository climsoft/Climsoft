<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrTextBox
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
        Me.txtBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtBox
        '
        Me.txtBox.Location = New System.Drawing.Point(4, 5)
        Me.txtBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBox.Name = "txtBox"
        Me.txtBox.Size = New System.Drawing.Size(74, 26)
        Me.txtBox.TabIndex = 578
        '
        'ucrTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtBox)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrTextBox"
        Me.Size = New System.Drawing.Size(87, 40)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBox As TextBox
End Class
