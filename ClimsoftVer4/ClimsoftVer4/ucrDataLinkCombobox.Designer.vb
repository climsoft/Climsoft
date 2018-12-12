<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucrDataLinkCombobox
    Inherits ClimsoftVer4.ucrValueView

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
        Me.cboValues = New System.Windows.Forms.ComboBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboValues
        '
        Me.cboValues.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboValues.FormattingEnabled = True
        Me.cboValues.Location = New System.Drawing.Point(0, 0)
        Me.cboValues.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboValues.Name = "cboValues"
        Me.cboValues.Size = New System.Drawing.Size(267, 28)
        Me.cboValues.TabIndex = 0
        '
        'ucrDataLinkCombobox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboValues)
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ucrDataLinkCombobox"
        Me.Size = New System.Drawing.Size(267, 32)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboValues As ComboBox
End Class
