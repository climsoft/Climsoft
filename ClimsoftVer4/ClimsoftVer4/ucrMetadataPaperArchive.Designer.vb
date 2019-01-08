<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataPaperArchive
    Inherits ClimsoftVer4.ucrTableEntry

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
        Me.lbldescri = New System.Windows.Forms.Label()
        Me.lblFormId = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.ucrNavigationPaperArchive = New ClimsoftVer4.ucrNavigation()
        Me.ucrTextBoxFormId = New ClimsoftVer4.ucrTextBox()
        Me.ucrTextBoxDefinition = New ClimsoftVer4.ucrTextBox()
        CType(Me.dtbRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 241)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(519, 34)
        Me.GroupBox13.TabIndex = 106
        Me.GroupBox13.TabStop = False
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(420, 6)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(81, 25)
        Me.btnView.TabIndex = 8
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(318, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(81, 25)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(216, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(81, 25)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(114, 7)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 25)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(12, 5)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(81, 27)
        Me.btnAddNew.TabIndex = 4
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'ucrNavigationPaperArchive
        '
        Me.ucrNavigationPaperArchive.Location = New System.Drawing.Point(97, 286)
        Me.ucrNavigationPaperArchive.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrNavigationPaperArchive.Name = "ucrNavigationPaperArchive"
        Me.ucrNavigationPaperArchive.Size = New System.Drawing.Size(336, 25)
        Me.ucrNavigationPaperArchive.TabIndex = 105
        '
        'ucrTextBoxFormId
        '
        Me.ucrTextBoxFormId.FieldName = "formId"
        Me.ucrTextBoxFormId.Location = New System.Drawing.Point(212, 99)
        Me.ucrTextBoxFormId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxFormId.Name = "ucrTextBoxFormId"
        Me.ucrTextBoxFormId.Size = New System.Drawing.Size(136, 20)
        Me.ucrTextBoxFormId.TabIndex = 107
        Me.ucrTextBoxFormId.Tag = "formId"
        Me.ucrTextBoxFormId.TextboxValue = ""
        '
        'ucrTextBoxDefinition
        '
        Me.ucrTextBoxDefinition.FieldName = "description"
        Me.ucrTextBoxDefinition.Location = New System.Drawing.Point(212, 141)
        Me.ucrTextBoxDefinition.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrTextBoxDefinition.Name = "ucrTextBoxDefinition"
        Me.ucrTextBoxDefinition.Size = New System.Drawing.Size(136, 20)
        Me.ucrTextBoxDefinition.TabIndex = 108
        Me.ucrTextBoxDefinition.Tag = "description"
        Me.ucrTextBoxDefinition.TextboxValue = ""
        '
        'ucrMetadataPaperArchive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ucrTextBoxDefinition)
        Me.Controls.Add(Me.ucrTextBoxFormId)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrNavigationPaperArchive)
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
    Friend WithEvents lbldescri As Label
    Friend WithEvents lblFormId As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents ucrNavigationPaperArchive As ucrNavigation
    Friend WithEvents ucrTextBoxFormId As ucrTextBox
    Friend WithEvents ucrTextBoxDefinition As ucrTextBox
End Class
