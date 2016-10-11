<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportAWS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportAWS))
        Me.btnBrowseSchemaFile = New System.Windows.Forms.Button()
        Me.btnBrowseDataFile = New System.Windows.Forms.Button()
        Me.lblSchemaFile = New System.Windows.Forms.Label()
        Me.txtSchemaFile = New System.Windows.Forms.TextBox()
        Me.lblDataFile = New System.Windows.Forms.Label()
        Me.txtDataFile = New System.Windows.Forms.TextBox()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtStationColumn = New System.Windows.Forms.TextBox()
        Me.lblStationColumn = New System.Windows.Forms.Label()
        Me.txtDateColumn = New System.Windows.Forms.TextBox()
        Me.lblDateColumn = New System.Windows.Forms.Label()
        Me.txtTimeColumn = New System.Windows.Forms.TextBox()
        Me.lblTimeColumn = New System.Windows.Forms.Label()
        Me.txtValStartColumn = New System.Windows.Forms.TextBox()
        Me.lblValStartColumn = New System.Windows.Forms.Label()
        Me.lblGuidelines = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnBrowseSchemaFile
        '
        Me.btnBrowseSchemaFile.Location = New System.Drawing.Point(531, 155)
        Me.btnBrowseSchemaFile.Name = "btnBrowseSchemaFile"
        Me.btnBrowseSchemaFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseSchemaFile.TabIndex = 21
        Me.btnBrowseSchemaFile.Text = "Browse"
        Me.btnBrowseSchemaFile.UseVisualStyleBackColor = True
        '
        'btnBrowseDataFile
        '
        Me.btnBrowseDataFile.Location = New System.Drawing.Point(531, 121)
        Me.btnBrowseDataFile.Name = "btnBrowseDataFile"
        Me.btnBrowseDataFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseDataFile.TabIndex = 20
        Me.btnBrowseDataFile.Text = "Browse"
        Me.btnBrowseDataFile.UseVisualStyleBackColor = True
        '
        'lblSchemaFile
        '
        Me.lblSchemaFile.AutoSize = True
        Me.lblSchemaFile.Location = New System.Drawing.Point(54, 161)
        Me.lblSchemaFile.Name = "lblSchemaFile"
        Me.lblSchemaFile.Size = New System.Drawing.Size(65, 13)
        Me.lblSchemaFile.TabIndex = 19
        Me.lblSchemaFile.Text = "Schema File"
        '
        'txtSchemaFile
        '
        Me.txtSchemaFile.Location = New System.Drawing.Point(157, 158)
        Me.txtSchemaFile.Name = "txtSchemaFile"
        Me.txtSchemaFile.Size = New System.Drawing.Size(355, 20)
        Me.txtSchemaFile.TabIndex = 18
        '
        'lblDataFile
        '
        Me.lblDataFile.AutoSize = True
        Me.lblDataFile.Location = New System.Drawing.Point(56, 124)
        Me.lblDataFile.Name = "lblDataFile"
        Me.lblDataFile.Size = New System.Drawing.Size(49, 13)
        Me.lblDataFile.TabIndex = 17
        Me.lblDataFile.Text = "Data File"
        '
        'txtDataFile
        '
        Me.txtDataFile.Location = New System.Drawing.Point(157, 121)
        Me.txtDataFile.Name = "txtDataFile"
        Me.txtDataFile.Size = New System.Drawing.Size(355, 20)
        Me.txtDataFile.TabIndex = 16
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(434, 288)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 23)
        Me.btnHelp.TabIndex = 15
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(335, 288)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(236, 288)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtStationColumn
        '
        Me.txtStationColumn.Location = New System.Drawing.Point(157, 199)
        Me.txtStationColumn.Name = "txtStationColumn"
        Me.txtStationColumn.Size = New System.Drawing.Size(100, 20)
        Me.txtStationColumn.TabIndex = 22
        Me.txtStationColumn.Text = "2"
        '
        'lblStationColumn
        '
        Me.lblStationColumn.AutoSize = True
        Me.lblStationColumn.Location = New System.Drawing.Point(54, 202)
        Me.lblStationColumn.Name = "lblStationColumn"
        Me.lblStationColumn.Size = New System.Drawing.Size(89, 13)
        Me.lblStationColumn.TabIndex = 23
        Me.lblStationColumn.Text = "StationID Column"
        '
        'txtDateColumn
        '
        Me.txtDateColumn.Location = New System.Drawing.Point(409, 199)
        Me.txtDateColumn.Name = "txtDateColumn"
        Me.txtDateColumn.Size = New System.Drawing.Size(100, 20)
        Me.txtDateColumn.TabIndex = 24
        Me.txtDateColumn.Text = "0"
        '
        'lblDateColumn
        '
        Me.lblDateColumn.AutoSize = True
        Me.lblDateColumn.Location = New System.Drawing.Point(324, 201)
        Me.lblDateColumn.Name = "lblDateColumn"
        Me.lblDateColumn.Size = New System.Drawing.Size(68, 13)
        Me.lblDateColumn.TabIndex = 25
        Me.lblDateColumn.Text = "Date Column"
        '
        'txtTimeColumn
        '
        Me.txtTimeColumn.Location = New System.Drawing.Point(409, 243)
        Me.txtTimeColumn.Name = "txtTimeColumn"
        Me.txtTimeColumn.Size = New System.Drawing.Size(100, 20)
        Me.txtTimeColumn.TabIndex = 26
        Me.txtTimeColumn.Text = "1"
        '
        'lblTimeColumn
        '
        Me.lblTimeColumn.AutoSize = True
        Me.lblTimeColumn.Location = New System.Drawing.Point(324, 246)
        Me.lblTimeColumn.Name = "lblTimeColumn"
        Me.lblTimeColumn.Size = New System.Drawing.Size(68, 13)
        Me.lblTimeColumn.TabIndex = 27
        Me.lblTimeColumn.Text = "Time Column"
        '
        'txtValStartColumn
        '
        Me.txtValStartColumn.Location = New System.Drawing.Point(157, 243)
        Me.txtValStartColumn.Name = "txtValStartColumn"
        Me.txtValStartColumn.Size = New System.Drawing.Size(100, 20)
        Me.txtValStartColumn.TabIndex = 28
        Me.txtValStartColumn.Text = "3"
        '
        'lblValStartColumn
        '
        Me.lblValStartColumn.AutoSize = True
        Me.lblValStartColumn.Location = New System.Drawing.Point(54, 246)
        Me.lblValStartColumn.Name = "lblValStartColumn"
        Me.lblValStartColumn.Size = New System.Drawing.Size(97, 13)
        Me.lblValStartColumn.TabIndex = 29
        Me.lblValStartColumn.Text = "Value Start Column"
        '
        'lblGuidelines
        '
        Me.lblGuidelines.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGuidelines.ForeColor = System.Drawing.Color.Red
        Me.lblGuidelines.Location = New System.Drawing.Point(59, 13)
        Me.lblGuidelines.Name = "lblGuidelines"
        Me.lblGuidelines.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblGuidelines.Size = New System.Drawing.Size(560, 91)
        Me.lblGuidelines.TabIndex = 30
        Me.lblGuidelines.Text = resources.GetString("lblGuidelines.Text")
        Me.lblGuidelines.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmImportAWS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 326)
        Me.Controls.Add(Me.lblGuidelines)
        Me.Controls.Add(Me.lblValStartColumn)
        Me.Controls.Add(Me.txtValStartColumn)
        Me.Controls.Add(Me.lblTimeColumn)
        Me.Controls.Add(Me.txtTimeColumn)
        Me.Controls.Add(Me.lblDateColumn)
        Me.Controls.Add(Me.txtDateColumn)
        Me.Controls.Add(Me.lblStationColumn)
        Me.Controls.Add(Me.txtStationColumn)
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
        Me.Name = "frmImportAWS"
        Me.Text = "frmImportAWS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowseSchemaFile As System.Windows.Forms.Button
    Friend WithEvents btnBrowseDataFile As System.Windows.Forms.Button
    Friend WithEvents lblSchemaFile As System.Windows.Forms.Label
    Friend WithEvents txtSchemaFile As System.Windows.Forms.TextBox
    Friend WithEvents lblDataFile As System.Windows.Forms.Label
    Friend WithEvents txtDataFile As System.Windows.Forms.TextBox
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtStationColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblStationColumn As System.Windows.Forms.Label
    Friend WithEvents txtDateColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblDateColumn As System.Windows.Forms.Label
    Friend WithEvents txtTimeColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblTimeColumn As System.Windows.Forms.Label
    Friend WithEvents txtValStartColumn As System.Windows.Forms.TextBox
    Friend WithEvents lblValStartColumn As System.Windows.Forms.Label
    Friend WithEvents lblGuidelines As System.Windows.Forms.Label
End Class
