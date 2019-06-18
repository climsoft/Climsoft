<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class acmad_dare_consult
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim YyyyLabel As System.Windows.Forms.Label
        Me.lbpays = New System.Windows.Forms.ListBox()
        Me.Pays_ = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbtypesdesstations = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTypesdimages = New System.Windows.Forms.ListBox()
        Me.btnrecherche = New System.Windows.Forms.Button()
        Me.dgvResultat = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtYear = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboMonth = New System.Windows.Forms.ComboBox()
        Me.imageLink = New System.Windows.Forms.LinkLabel()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        YyyyLabel = New System.Windows.Forms.Label()
        CType(Me.dgvResultat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YyyyLabel
        '
        YyyyLabel.AutoSize = True
        YyyyLabel.Location = New System.Drawing.Point(588, 31)
        YyyyLabel.Name = "YyyyLabel"
        YyyyLabel.Size = New System.Drawing.Size(41, 13)
        YyyyLabel.TabIndex = 503
        YyyyLabel.Text = "Année:"
        '
        'lbpays
        '
        Me.lbpays.FormattingEnabled = True
        Me.lbpays.Location = New System.Drawing.Point(28, 46)
        Me.lbpays.Name = "lbpays"
        Me.lbpays.Size = New System.Drawing.Size(162, 147)
        Me.lbpays.TabIndex = 0
        '
        'Pays_
        '
        Me.Pays_.AutoSize = True
        Me.Pays_.Location = New System.Drawing.Point(28, 27)
        Me.Pays_.Name = "Pays_"
        Me.Pays_.Size = New System.Drawing.Size(30, 13)
        Me.Pays_.TabIndex = 1
        Me.Pays_.Text = "Pays"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Types des stations"
        '
        'lbtypesdesstations
        '
        Me.lbtypesdesstations.FormattingEnabled = True
        Me.lbtypesdesstations.Items.AddRange(New Object() {"S", "D", "R"})
        Me.lbtypesdesstations.Location = New System.Drawing.Point(216, 46)
        Me.lbtypesdesstations.Name = "lbtypesdesstations"
        Me.lbtypesdesstations.Size = New System.Drawing.Size(162, 147)
        Me.lbtypesdesstations.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(405, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Types d'images"
        '
        'lbTypesdimages
        '
        Me.lbTypesdimages.FormattingEnabled = True
        Me.lbTypesdimages.Location = New System.Drawing.Point(405, 46)
        Me.lbTypesdimages.Name = "lbTypesdimages"
        Me.lbTypesdimages.Size = New System.Drawing.Size(162, 147)
        Me.lbTypesdimages.TabIndex = 4
        '
        'btnrecherche
        '
        Me.btnrecherche.Location = New System.Drawing.Point(603, 122)
        Me.btnrecherche.Name = "btnrecherche"
        Me.btnrecherche.Size = New System.Drawing.Size(75, 23)
        Me.btnrecherche.TabIndex = 10
        Me.btnrecherche.Text = "Rechercher"
        Me.btnrecherche.UseVisualStyleBackColor = True
        '
        'dgvResultat
        '
        Me.dgvResultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultat.Location = New System.Drawing.Point(31, 244)
        Me.dgvResultat.Name = "dgvResultat"
        Me.dgvResultat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResultat.Size = New System.Drawing.Size(796, 150)
        Me.dgvResultat.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(466, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Nombre d'image  :"
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(585, 46)
        Me.txtYear.Mask = "9999"
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(67, 20)
        Me.txtYear.TabIndex = 505
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(698, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 504
        Me.Label7.Text = "Mois:"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(701, 46)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(41, 21)
        Me.cboMonth.TabIndex = 502
        '
        'imageLink
        '
        Me.imageLink.AutoSize = True
        Me.imageLink.Location = New System.Drawing.Point(294, 217)
        Me.imageLink.Name = "imageLink"
        Me.imageLink.Size = New System.Drawing.Size(154, 13)
        Me.imageLink.TabIndex = 506
        Me.imageLink.TabStop = True
        Me.imageLink.Text = "Aperçu de l'image selectionnée"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'acmad_dare_consult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 427)
        Me.Controls.Add(Me.imageLink)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(YyyyLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgvResultat)
        Me.Controls.Add(Me.btnrecherche)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbTypesdimages)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbtypesdesstations)
        Me.Controls.Add(Me.Pays_)
        Me.Controls.Add(Me.lbpays)
        Me.Name = "acmad_dare_consult"
        Me.Text = "acmad_dare_consult"
        CType(Me.dgvResultat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbpays As System.Windows.Forms.ListBox
    Friend WithEvents Pays_ As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbtypesdesstations As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbTypesdimages As System.Windows.Forms.ListBox
    Friend WithEvents btnrecherche As System.Windows.Forms.Button
    Friend WithEvents dgvResultat As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtYear As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents imageLink As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
