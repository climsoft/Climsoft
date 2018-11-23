<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataPaperArchive
    Inherits ClimsoftVer4.ucrBaseDataLink

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtFormDescription = New System.Windows.Forms.TextBox()
        Me.txtFormId = New System.Windows.Forms.TextBox()
        Me.lbldescri = New System.Windows.Forms.Label()
        Me.lblFormId = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.cmdViewScheduleClass = New System.Windows.Forms.Button()
        Me.cmdDeleteScheduleClass = New System.Windows.Forms.Button()
        Me.cmdUpdateScheduleClass = New System.Windows.Forms.Button()
        Me.cmdAddScheduleClass = New System.Windows.Forms.Button()
        Me.cmdClearClass = New System.Windows.Forms.Button()
        Me.ucrNavigationPaperArchive = New ClimsoftVer4.ucrNavigation()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFormDescription
        '
        Me.txtFormDescription.Location = New System.Drawing.Point(200, 139)
        Me.txtFormDescription.Name = "txtFormDescription"
        Me.txtFormDescription.Size = New System.Drawing.Size(154, 20)
        Me.txtFormDescription.TabIndex = 13
        '
        'txtFormId
        '
        Me.txtFormId.Location = New System.Drawing.Point(200, 98)
        Me.txtFormId.Name = "txtFormId"
        Me.txtFormId.Size = New System.Drawing.Size(152, 20)
        Me.txtFormId.TabIndex = 12
        '
        'lbldescri
        '
        Me.lbldescri.AutoSize = True
        Me.lbldescri.Location = New System.Drawing.Point(136, 143)
        Me.lbldescri.Name = "lbldescri"
        Me.lbldescri.Size = New System.Drawing.Size(60, 13)
        Me.lbldescri.TabIndex = 15
        Me.lbldescri.Text = "Description"
        '
        'lblFormId
        '
        Me.lblFormId.AutoSize = True
        Me.lblFormId.Location = New System.Drawing.Point(136, 102)
        Me.lblFormId.Name = "lblFormId"
        Me.lblFormId.Size = New System.Drawing.Size(44, 13)
        Me.lblFormId.TabIndex = 14
        Me.lblFormId.Text = "Form ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(158, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(175, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Paper Archive Definition"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.cmdViewScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdDeleteScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdUpdateScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdAddScheduleClass)
        Me.GroupBox13.Controls.Add(Me.cmdClearClass)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 241)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(519, 34)
        Me.GroupBox13.TabIndex = 106
        Me.GroupBox13.TabStop = False
        '
        'cmdViewScheduleClass
        '
        Me.cmdViewScheduleClass.Location = New System.Drawing.Point(420, 6)
        Me.cmdViewScheduleClass.Name = "cmdViewScheduleClass"
        Me.cmdViewScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdViewScheduleClass.TabIndex = 8
        Me.cmdViewScheduleClass.Text = "View"
        Me.cmdViewScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdDeleteScheduleClass
        '
        Me.cmdDeleteScheduleClass.Location = New System.Drawing.Point(318, 6)
        Me.cmdDeleteScheduleClass.Name = "cmdDeleteScheduleClass"
        Me.cmdDeleteScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdDeleteScheduleClass.TabIndex = 7
        Me.cmdDeleteScheduleClass.Text = "Delete"
        Me.cmdDeleteScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdUpdateScheduleClass
        '
        Me.cmdUpdateScheduleClass.Location = New System.Drawing.Point(216, 6)
        Me.cmdUpdateScheduleClass.Name = "cmdUpdateScheduleClass"
        Me.cmdUpdateScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdUpdateScheduleClass.TabIndex = 6
        Me.cmdUpdateScheduleClass.Text = "Update"
        Me.cmdUpdateScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdAddScheduleClass
        '
        Me.cmdAddScheduleClass.Location = New System.Drawing.Point(114, 7)
        Me.cmdAddScheduleClass.Name = "cmdAddScheduleClass"
        Me.cmdAddScheduleClass.Size = New System.Drawing.Size(81, 25)
        Me.cmdAddScheduleClass.TabIndex = 5
        Me.cmdAddScheduleClass.Text = "Save"
        Me.cmdAddScheduleClass.UseVisualStyleBackColor = True
        '
        'cmdClearClass
        '
        Me.cmdClearClass.Location = New System.Drawing.Point(12, 5)
        Me.cmdClearClass.Name = "cmdClearClass"
        Me.cmdClearClass.Size = New System.Drawing.Size(81, 27)
        Me.cmdClearClass.TabIndex = 4
        Me.cmdClearClass.Text = "AddNew"
        Me.cmdClearClass.UseVisualStyleBackColor = True
        '
        'ucrNavigationPaperArchive
        '
        Me.ucrNavigationPaperArchive.Location = New System.Drawing.Point(97, 286)
        Me.ucrNavigationPaperArchive.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationPaperArchive.Name = "ucrNavigationPaperArchive"
        Me.ucrNavigationPaperArchive.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationPaperArchive.TabIndex = 105
        '
        'ucrMetadataPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrNavigationPaperArchive)
        Me.Controls.Add(Me.txtFormDescription)
        Me.Controls.Add(Me.txtFormId)
        Me.Controls.Add(Me.lbldescri)
        Me.Controls.Add(Me.lblFormId)
        Me.Controls.Add(Me.Label7)
        Me.Name = "ucrMetadataPaperArchive"
        Me.Size = New System.Drawing.Size(531, 316)
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFormDescription As TextBox
    Friend WithEvents txtFormId As TextBox
    Friend WithEvents lbldescri As Label
    Friend WithEvents lblFormId As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents cmdViewScheduleClass As Button
    Friend WithEvents cmdDeleteScheduleClass As Button
    Friend WithEvents cmdUpdateScheduleClass As Button
    Friend WithEvents cmdAddScheduleClass As Button
    Friend WithEvents cmdClearClass As Button
    Friend WithEvents ucrNavigationPaperArchive As ucrNavigation
End Class
