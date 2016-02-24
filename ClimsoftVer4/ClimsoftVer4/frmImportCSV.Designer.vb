<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportCSV
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportCSV))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtSchemaFile = New System.Windows.Forms.TextBox()
        Me.lblSchemaFile = New System.Windows.Forms.Label()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.btnBrowseSchemaFile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOK
        '
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        resources.ApplyResources(Me.btnHelp, "btnHelp")
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'txtDataFile
        '
        resources.ApplyResources(Me.txtDataFile, "txtDataFile")
        Me.txtDataFile.Name = "txtDataFile"
        '
        'lblDataFile
        '
        resources.ApplyResources(Me.lblDataFile, "lblDataFile")
        Me.lblDataFile.Name = "lblDataFile"
        '
        'txtSchemaFile
        '
        resources.ApplyResources(Me.txtSchemaFile, "txtSchemaFile")
        Me.txtSchemaFile.Name = "txtSchemaFile"
        '
        'lblSchemaFile
        '
        resources.ApplyResources(Me.lblSchemaFile, "lblSchemaFile")
        Me.lblSchemaFile.Name = "lblSchemaFile"
        '
        'btnBrowseDataFile
        '
        resources.ApplyResources(Me.btnBrowseDataFile, "btnBrowseDataFile")
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'btnBrowseSchemaFile
        '
        resources.ApplyResources(Me.btnBrowseSchemaFile, "btnBrowseSchemaFile")
        Me.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile"
        Me.btnBrowseSchemaFile.UseVisualStyleBackColor = True
        '
        'frmImportCSV
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnBrowseSchemaFile)
        Me.Controls.Add(Me.btnBrowseDataFile)
        Me.Controls.Add(Me.lblSchemaFile)
        Me.Controls.Add(Me.txtSchemaFile)
        Me.Controls.Add(Me.lblDataFile)
        Me.Controls.Add(Me.txtDataFile)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportCSV"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtSchemaFile As System.Windows.Forms.TextBox
    Friend WithEvents lblSchemaFile As System.Windows.Forms.Label
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseSchemaFile As System.Windows.Forms.Button
End Class
