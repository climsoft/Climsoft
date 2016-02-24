<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formWindRose
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formWindRose))
        Me.pnlWindrose = New System.Windows.Forms.Panel()
        Me.lblPredifined = New System.Windows.Forms.Label()
        Me.optYear = New System.Windows.Forms.RadioButton()
        Me.optSeason = New System.Windows.Forms.RadioButton()
        Me.optWeekly = New System.Windows.Forms.RadioButton()
        Me.optsingle = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblProvider = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.lblTile = New System.Windows.Forms.Label()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.lbllabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lblThreshold = New System.Windows.Forms.Label()
        Me.pnlWindrose.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlWindrose
        '
        Me.pnlWindrose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWindrose.Controls.Add(Me.lblPredifined)
        Me.pnlWindrose.Controls.Add(Me.optYear)
        Me.pnlWindrose.Controls.Add(Me.optSeason)
        Me.pnlWindrose.Controls.Add(Me.optWeekly)
        Me.pnlWindrose.Controls.Add(Me.optsingle)
        resources.ApplyResources(Me.pnlWindrose, "pnlWindrose")
        Me.pnlWindrose.Name = "pnlWindrose"
        '
        'lblPredifined
        '
        resources.ApplyResources(Me.lblPredifined, "lblPredifined")
        Me.lblPredifined.Name = "lblPredifined"
        '
        'optYear
        '
        resources.ApplyResources(Me.optYear, "optYear")
        Me.optYear.Name = "optYear"
        Me.optYear.TabStop = True
        Me.optYear.UseVisualStyleBackColor = True
        '
        'optSeason
        '
        resources.ApplyResources(Me.optSeason, "optSeason")
        Me.optSeason.Name = "optSeason"
        Me.optSeason.TabStop = True
        Me.optSeason.UseVisualStyleBackColor = True
        '
        'optWeekly
        '
        resources.ApplyResources(Me.optWeekly, "optWeekly")
        Me.optWeekly.Name = "optWeekly"
        Me.optWeekly.TabStop = True
        Me.optWeekly.UseVisualStyleBackColor = True
        '
        'optsingle
        '
        resources.ApplyResources(Me.optsingle, "optsingle")
        Me.optsingle.Name = "optsingle"
        Me.optsingle.TabStop = True
        Me.optsingle.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblProvider)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.lblTile)
        Me.Panel1.Controls.Add(Me.txtTitle)
        Me.Panel1.Controls.Add(Me.lbllabel)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'lblProvider
        '
        resources.ApplyResources(Me.lblProvider, "lblProvider")
        Me.lblProvider.Name = "lblProvider"
        '
        'TextBox2
        '
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.Name = "TextBox2"
        '
        'lblTile
        '
        resources.ApplyResources(Me.lblTile, "lblTile")
        Me.lblTile.Name = "lblTile"
        '
        'txtTitle
        '
        resources.ApplyResources(Me.txtTitle, "txtTitle")
        Me.txtTitle.Name = "txtTitle"
        '
        'lbllabel
        '
        resources.ApplyResources(Me.lbllabel, "lbllabel")
        Me.lbllabel.Name = "lbllabel"
        '
        'TextBox1
        '
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'lblThreshold
        '
        resources.ApplyResources(Me.lblThreshold, "lblThreshold")
        Me.lblThreshold.Name = "lblThreshold"
        '
        'formWindRose
        '
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlWindrose)
        Me.Controls.Add(Me.lblThreshold)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "formWindRose"
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.lblThreshold, 0)
        Me.Controls.SetChildIndex(Me.pnlWindrose, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.pnlWindrose.ResumeLayout(False)
        Me.pnlWindrose.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlWindrose As System.Windows.Forms.Panel
    Friend WithEvents lblPredifined As System.Windows.Forms.Label
    Friend WithEvents optYear As System.Windows.Forms.RadioButton
    Friend WithEvents optSeason As System.Windows.Forms.RadioButton
    Friend WithEvents optWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents optsingle As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents lblThreshold As System.Windows.Forms.Label
    Friend WithEvents lblTile As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents lbllabel As System.Windows.Forms.Label

End Class
