<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataOutpt
    Inherits ClimsoftVer4.frmAction

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlOutPuttype = New System.Windows.Forms.Panel()
        Me.lblOutputOptions = New System.Windows.Forms.Label()
        Me.pnlLayout = New System.Windows.Forms.Panel()
        Me.pnlLayerout = New System.Windows.Forms.Label()
        Me.optView = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.optLongFormat = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.pnlOutPuttype.SuspendLayout()
        Me.pnlLayout.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlOutPuttype
        '
        Me.pnlOutPuttype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOutPuttype.Controls.Add(Me.TextBox1)
        Me.pnlOutPuttype.Controls.Add(Me.RadioButton1)
        Me.pnlOutPuttype.Controls.Add(Me.optView)
        Me.pnlOutPuttype.Controls.Add(Me.lblOutputOptions)
        Me.pnlOutPuttype.Location = New System.Drawing.Point(271, 50)
        Me.pnlOutPuttype.Name = "pnlOutPuttype"
        Me.pnlOutPuttype.Size = New System.Drawing.Size(367, 234)
        Me.pnlOutPuttype.TabIndex = 4
        '
        'lblOutputOptions
        '
        Me.lblOutputOptions.AutoSize = True
        Me.lblOutputOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutputOptions.Location = New System.Drawing.Point(0, 0)
        Me.lblOutputOptions.Name = "lblOutputOptions"
        Me.lblOutputOptions.Size = New System.Drawing.Size(102, 15)
        Me.lblOutputOptions.TabIndex = 0
        Me.lblOutputOptions.Text = "Output Options"
        '
        'pnlLayout
        '
        Me.pnlLayout.Controls.Add(Me.RadioButton4)
        Me.pnlLayout.Controls.Add(Me.optLongFormat)
        Me.pnlLayout.Controls.Add(Me.pnlLayerout)
        Me.pnlLayout.Location = New System.Drawing.Point(12, 50)
        Me.pnlLayout.Name = "pnlLayout"
        Me.pnlLayout.Size = New System.Drawing.Size(164, 233)
        Me.pnlLayout.TabIndex = 5
        '
        'pnlLayerout
        '
        Me.pnlLayerout.AutoSize = True
        Me.pnlLayerout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlLayerout.Location = New System.Drawing.Point(3, 1)
        Me.pnlLayerout.Name = "pnlLayerout"
        Me.pnlLayerout.Size = New System.Drawing.Size(108, 15)
        Me.pnlLayerout.TabIndex = 1
        Me.pnlLayerout.Text = "Output Layerout"
        '
        'optView
        '
        Me.optView.AutoSize = True
        Me.optView.Location = New System.Drawing.Point(16, 44)
        Me.optView.Name = "optView"
        Me.optView.Size = New System.Drawing.Size(48, 17)
        Me.optView.TabIndex = 1
        Me.optView.TabStop = True
        Me.optView.Text = "View"
        Me.optView.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 94)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(81, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Save to File"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(111, 90)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(213, 20)
        Me.TextBox1.TabIndex = 3
        '
        'optLongFormat
        '
        Me.optLongFormat.AutoSize = True
        Me.optLongFormat.Location = New System.Drawing.Point(21, 36)
        Me.optLongFormat.Name = "optLongFormat"
        Me.optLongFormat.Size = New System.Drawing.Size(14, 13)
        Me.optLongFormat.TabIndex = 7
        Me.optLongFormat.TabStop = True
        Me.optLongFormat.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(283, 306)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton3.TabIndex = 6
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(21, 79)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(85, 17)
        Me.RadioButton4.TabIndex = 8
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Wide Format"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'frmDataOutpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(677, 349)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.pnlLayout)
        Me.Controls.Add(Me.pnlOutPuttype)
        Me.Name = "frmDataOutpt"
        Me.Text = "Data Products Output"
        Me.Controls.SetChildIndex(Me.pnlOutPuttype, 0)
        Me.Controls.SetChildIndex(Me.pnlLayout, 0)
        Me.Controls.SetChildIndex(Me.RadioButton3, 0)
        Me.pnlOutPuttype.ResumeLayout(False)
        Me.pnlOutPuttype.PerformLayout()
        Me.pnlLayout.ResumeLayout(False)
        Me.pnlLayout.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlOutPuttype As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents optView As System.Windows.Forms.RadioButton
    Friend WithEvents lblOutputOptions As System.Windows.Forms.Label
    Friend WithEvents pnlLayout As System.Windows.Forms.Panel
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents optLongFormat As System.Windows.Forms.RadioButton
    Friend WithEvents pnlLayerout As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton

End Class
