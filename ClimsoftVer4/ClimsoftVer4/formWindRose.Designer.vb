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
        Me.pnlWindrose.Location = New System.Drawing.Point(23, 54)
        Me.pnlWindrose.Name = "pnlWindrose"
        Me.pnlWindrose.Size = New System.Drawing.Size(181, 165)
        Me.pnlWindrose.TabIndex = 24
        '
        'lblPredifined
        '
        Me.lblPredifined.AutoSize = True
        Me.lblPredifined.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPredifined.Location = New System.Drawing.Point(-1, 0)
        Me.lblPredifined.Name = "lblPredifined"
        Me.lblPredifined.Size = New System.Drawing.Size(43, 13)
        Me.lblPredifined.TabIndex = 4
        Me.lblPredifined.Text = "Period"
        '
        'optYear
        '
        Me.optYear.AutoSize = True
        Me.optYear.Location = New System.Drawing.Point(14, 125)
        Me.optYear.Name = "optYear"
        Me.optYear.Size = New System.Drawing.Size(47, 17)
        Me.optYear.TabIndex = 3
        Me.optYear.TabStop = True
        Me.optYear.Text = "Year"
        Me.optYear.UseVisualStyleBackColor = True
        '
        'optSeason
        '
        Me.optSeason.AutoSize = True
        Me.optSeason.Location = New System.Drawing.Point(14, 92)
        Me.optSeason.Name = "optSeason"
        Me.optSeason.Size = New System.Drawing.Size(61, 17)
        Me.optSeason.TabIndex = 2
        Me.optSeason.TabStop = True
        Me.optSeason.Text = "Season"
        Me.optSeason.UseVisualStyleBackColor = True
        '
        'optWeekly
        '
        Me.optWeekly.AutoSize = True
        Me.optWeekly.Location = New System.Drawing.Point(14, 59)
        Me.optWeekly.Name = "optWeekly"
        Me.optWeekly.Size = New System.Drawing.Size(71, 17)
        Me.optWeekly.TabIndex = 1
        Me.optWeekly.TabStop = True
        Me.optWeekly.Text = "Weekday"
        Me.optWeekly.UseVisualStyleBackColor = True
        '
        'optsingle
        '
        Me.optsingle.AutoSize = True
        Me.optsingle.Location = New System.Drawing.Point(14, 26)
        Me.optsingle.Name = "optsingle"
        Me.optsingle.Size = New System.Drawing.Size(54, 17)
        Me.optsingle.TabIndex = 0
        Me.optsingle.TabStop = True
        Me.optsingle.Text = "Single"
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
        Me.Panel1.Location = New System.Drawing.Point(266, 54)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(368, 165)
        Me.Panel1.TabIndex = 25
        '
        'lblProvider
        '
        Me.lblProvider.AutoSize = True
        Me.lblProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvider.Location = New System.Drawing.Point(4, 95)
        Me.lblProvider.Name = "lblProvider"
        Me.lblProvider.Size = New System.Drawing.Size(59, 16)
        Me.lblProvider.TabIndex = 6
        Me.lblProvider.Text = "Provider"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(76, 91)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(270, 20)
        Me.TextBox2.TabIndex = 5
        '
        'lblTile
        '
        Me.lblTile.AutoSize = True
        Me.lblTile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTile.Location = New System.Drawing.Point(4, 45)
        Me.lblTile.Name = "lblTile"
        Me.lblTile.Size = New System.Drawing.Size(34, 16)
        Me.lblTile.TabIndex = 3
        Me.lblTile.Text = "Title"
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(76, 41)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(270, 20)
        Me.txtTitle.TabIndex = 1
        '
        'lbllabel
        '
        Me.lbllabel.AutoSize = True
        Me.lbllabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllabel.Location = New System.Drawing.Point(3, 0)
        Me.lbllabel.Name = "lbllabel"
        Me.lbllabel.Size = New System.Drawing.Size(110, 13)
        Me.lbllabel.TabIndex = 0
        Me.lbllabel.Text = "Wind Rose Labels"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(97, 244)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(69, 20)
        Me.TextBox1.TabIndex = 2
        '
        'lblThreshold
        '
        Me.lblThreshold.AutoSize = True
        Me.lblThreshold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThreshold.Location = New System.Drawing.Point(25, 245)
        Me.lblThreshold.Name = "lblThreshold"
        Me.lblThreshold.Size = New System.Drawing.Size(69, 16)
        Me.lblThreshold.TabIndex = 4
        Me.lblThreshold.Text = "Threshold"
        '
        'formWindRose
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(661, 352)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlWindrose)
        Me.Controls.Add(Me.lblThreshold)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "formWindRose"
        Me.Text = "Wind Rose Plotting"
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
