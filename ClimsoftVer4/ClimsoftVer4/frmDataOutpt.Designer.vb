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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDataOutpt))
        Me.pnlOutPuttype = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.optView = New System.Windows.Forms.RadioButton()
        Me.lblOutputOptions = New System.Windows.Forms.Label()
        Me.pnlLayout = New System.Windows.Forms.Panel()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.optLongFormat = New System.Windows.Forms.RadioButton()
        Me.pnlLayerout = New System.Windows.Forms.Label()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
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
        resources.ApplyResources(Me.pnlOutPuttype, "pnlOutPuttype")
        Me.pnlOutPuttype.Name = "pnlOutPuttype"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'optView
        '
        resources.ApplyResources(Me.optView, "optView")
        Me.optView.Name = "optView"
        Me.optView.TabStop = True
        Me.optView.UseVisualStyleBackColor = True
        '
        'lblOutputOptions
        '
        resources.ApplyResources(Me.lblOutputOptions, "lblOutputOptions")
        Me.lblOutputOptions.Name = "lblOutputOptions"
        '
        'pnlLayout
        '
        Me.pnlLayout.Controls.Add(Me.RadioButton4)
        Me.pnlLayout.Controls.Add(Me.optLongFormat)
        Me.pnlLayout.Controls.Add(Me.pnlLayerout)
        resources.ApplyResources(Me.pnlLayout, "pnlLayout")
        Me.pnlLayout.Name = "pnlLayout"
        '
        'RadioButton4
        '
        resources.ApplyResources(Me.RadioButton4, "RadioButton4")
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'optLongFormat
        '
        resources.ApplyResources(Me.optLongFormat, "optLongFormat")
        Me.optLongFormat.Name = "optLongFormat"
        Me.optLongFormat.TabStop = True
        Me.optLongFormat.UseVisualStyleBackColor = True
        '
        'pnlLayerout
        '
        resources.ApplyResources(Me.pnlLayerout, "pnlLayerout")
        Me.pnlLayerout.Name = "pnlLayerout"
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'frmDataOutpt
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.pnlLayout)
        Me.Controls.Add(Me.pnlOutPuttype)
        Me.Name = "frmDataOutpt"
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
