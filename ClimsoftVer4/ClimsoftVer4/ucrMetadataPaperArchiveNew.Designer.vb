<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucrMetadataPaperArchiveNew
    Inherits ClimsoftVer4.ucrPage

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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblFormId = New System.Windows.Forms.Label()
        Me.ucrTextboxNewFormID = New ClimsoftVer4.ucrTextBoxNew()
        Me.lbldescri = New System.Windows.Forms.Label()
        Me.ucrTextBoxNewDescription = New ClimsoftVer4.ucrTextBoxNew()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.UcrNavigator1 = New ClimsoftVer4.ucrNavigator()
        Me.GroupBox13.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(299, 21)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(214, 20)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Paper Archive Definition"
        '
        'lblFormId
        '
        Me.lblFormId.AutoSize = True
        Me.lblFormId.Location = New System.Drawing.Point(269, 126)
        Me.lblFormId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFormId.Name = "lblFormId"
        Me.lblFormId.Size = New System.Drawing.Size(57, 17)
        Me.lblFormId.TabIndex = 2
        Me.lblFormId.Text = "Form ID"
        '
        'ucrTextboxNewFormID
        '
        Me.ucrTextboxNewFormID.Location = New System.Drawing.Point(371, 122)
        Me.ucrTextboxNewFormID.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextboxNewFormID.Name = "ucrTextboxNewFormID"
        Me.ucrTextboxNewFormID.Size = New System.Drawing.Size(181, 25)
        Me.ucrTextboxNewFormID.TabIndex = 3
        Me.ucrTextboxNewFormID.TextboxValue = ""
        '
        'lbldescri
        '
        Me.lbldescri.AutoSize = True
        Me.lbldescri.Location = New System.Drawing.Point(269, 176)
        Me.lbldescri.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldescri.Name = "lbldescri"
        Me.lbldescri.Size = New System.Drawing.Size(79, 17)
        Me.lbldescri.TabIndex = 4
        Me.lbldescri.Text = "Description"
        '
        'ucrTextBoxNewDescription
        '
        Me.ucrTextBoxNewDescription.Location = New System.Drawing.Point(371, 174)
        Me.ucrTextBoxNewDescription.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.ucrTextBoxNewDescription.Name = "ucrTextBoxNewDescription"
        Me.ucrTextBoxNewDescription.Size = New System.Drawing.Size(181, 25)
        Me.ucrTextBoxNewDescription.TabIndex = 5
        Me.ucrTextBoxNewDescription.TextboxValue = ""
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnClear)
        Me.GroupBox13.Controls.Add(Me.btnView)
        Me.GroupBox13.Controls.Add(Me.btnDelete)
        Me.GroupBox13.Controls.Add(Me.btnUpdate)
        Me.GroupBox13.Controls.Add(Me.btnSave)
        Me.GroupBox13.Controls.Add(Me.btnAddNew)
        Me.GroupBox13.Location = New System.Drawing.Point(8, 297)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox13.Size = New System.Drawing.Size(808, 42)
        Me.GroupBox13.TabIndex = 6
        Me.GroupBox13.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(537, 6)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(108, 33)
        Me.btnClear.TabIndex = 4
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(664, 6)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(108, 33)
        Me.btnView.TabIndex = 5
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(411, 6)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(108, 33)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(284, 6)
        Me.btnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(108, 33)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(157, 6)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 33)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(31, 6)
        Me.btnAddNew.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 33)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "AddNew"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'UcrNavigator1
        '
        Me.UcrNavigator1.Location = New System.Drawing.Point(187, 352)
        Me.UcrNavigator1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.UcrNavigator1.Name = "UcrNavigator1"
        Me.UcrNavigator1.Size = New System.Drawing.Size(448, 31)
        Me.UcrNavigator1.TabIndex = 8
        '
        'ucrMetadataPaperArchiveNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.UcrNavigator1)
        Me.Controls.Add(Me.GroupBox13)
        Me.Controls.Add(Me.ucrTextBoxNewDescription)
        Me.Controls.Add(Me.lbldescri)
        Me.Controls.Add(Me.ucrTextboxNewFormID)
        Me.Controls.Add(Me.lblFormId)
        Me.Controls.Add(Me.Label7)
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "ucrMetadataPaperArchiveNew"
        Me.Size = New System.Drawing.Size(823, 389)
        Me.GroupBox13.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label7 As Label
    Friend WithEvents lblFormId As Label
    Friend WithEvents ucrTextboxNewFormID As ucrTextBoxNew
    Friend WithEvents lbldescri As Label
    Friend WithEvents ucrTextBoxNewDescription As ucrTextBoxNew
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btnClear As Button
    Friend WithEvents btnView As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents UcrNavigator1 As ucrNavigator
End Class
