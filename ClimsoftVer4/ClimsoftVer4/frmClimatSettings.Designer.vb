<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClimatSettings
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
        Me.TabParameters = New System.Windows.Forms.TabControl()
        Me.Parameters = New System.Windows.Forms.TabPage()
        Me.grpParameters = New System.Windows.Forms.GroupBox()
        Me.butClose = New System.Windows.Forms.Button()
        Me.butGrant = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.butUpdate = New System.Windows.Forms.Button()
        Me.DataGridViewParameters = New System.Windows.Forms.DataGridView()
        Me.FTP = New System.Windows.Forms.TabPage()
        Me.TabParameters.SuspendLayout()
        Me.Parameters.SuspendLayout()
        Me.grpParameters.SuspendLayout()
        CType(Me.DataGridViewParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabParameters
        '
        Me.TabParameters.Controls.Add(Me.Parameters)
        Me.TabParameters.Controls.Add(Me.FTP)
        Me.TabParameters.Location = New System.Drawing.Point(12, 12)
        Me.TabParameters.Name = "TabParameters"
        Me.TabParameters.SelectedIndex = 0
        Me.TabParameters.Size = New System.Drawing.Size(751, 399)
        Me.TabParameters.TabIndex = 0
        '
        'Parameters
        '
        Me.Parameters.Controls.Add(Me.grpParameters)
        Me.Parameters.Controls.Add(Me.DataGridViewParameters)
        Me.Parameters.Location = New System.Drawing.Point(4, 22)
        Me.Parameters.Name = "Parameters"
        Me.Parameters.Padding = New System.Windows.Forms.Padding(3)
        Me.Parameters.Size = New System.Drawing.Size(743, 373)
        Me.Parameters.TabIndex = 0
        Me.Parameters.Text = "Parameters"
        Me.Parameters.UseVisualStyleBackColor = True
        '
        'grpParameters
        '
        Me.grpParameters.BackColor = System.Drawing.Color.LightGray
        Me.grpParameters.Controls.Add(Me.butClose)
        Me.grpParameters.Controls.Add(Me.butGrant)
        Me.grpParameters.Controls.Add(Me.btnHelp)
        Me.grpParameters.Controls.Add(Me.butUpdate)
        Me.grpParameters.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpParameters.Location = New System.Drawing.Point(3, 337)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(737, 33)
        Me.grpParameters.TabIndex = 1
        Me.grpParameters.TabStop = False
        '
        'butClose
        '
        Me.butClose.Location = New System.Drawing.Point(308, 4)
        Me.butClose.Name = "butClose"
        Me.butClose.Size = New System.Drawing.Size(58, 23)
        Me.butClose.TabIndex = 17
        Me.butClose.Text = "Close"
        Me.butClose.UseVisualStyleBackColor = True
        '
        'butGrant
        '
        Me.butGrant.Location = New System.Drawing.Point(601, 4)
        Me.butGrant.Name = "butGrant"
        Me.butGrant.Size = New System.Drawing.Size(132, 23)
        Me.butGrant.TabIndex = 16
        Me.butGrant.Text = "Grant User Permissions"
        Me.butGrant.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(425, 4)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(58, 23)
        Me.btnHelp.TabIndex = 15
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'butUpdate
        '
        Me.butUpdate.Location = New System.Drawing.Point(199, 4)
        Me.butUpdate.Name = "butUpdate"
        Me.butUpdate.Size = New System.Drawing.Size(58, 23)
        Me.butUpdate.TabIndex = 0
        Me.butUpdate.Text = "Update"
        Me.butUpdate.UseVisualStyleBackColor = True
        '
        'DataGridViewParameters
        '
        Me.DataGridViewParameters.AllowDrop = True
        Me.DataGridViewParameters.AllowUserToAddRows = False
        Me.DataGridViewParameters.AllowUserToDeleteRows = False
        Me.DataGridViewParameters.AllowUserToResizeColumns = False
        Me.DataGridViewParameters.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow
        Me.DataGridViewParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewParameters.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewParameters.Name = "DataGridViewParameters"
        Me.DataGridViewParameters.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DataGridViewParameters.Size = New System.Drawing.Size(735, 364)
        Me.DataGridViewParameters.TabIndex = 0
        '
        'FTP
        '
        Me.FTP.Location = New System.Drawing.Point(4, 22)
        Me.FTP.Name = "FTP"
        Me.FTP.Padding = New System.Windows.Forms.Padding(3)
        Me.FTP.Size = New System.Drawing.Size(743, 373)
        Me.FTP.TabIndex = 1
        Me.FTP.Text = "FTP"
        Me.FTP.UseVisualStyleBackColor = True
        '
        'frmClimatSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 418)
        Me.Controls.Add(Me.TabParameters)
        Me.Name = "frmClimatSettings"
        Me.Text = "Climat Settings"
        Me.TabParameters.ResumeLayout(False)
        Me.Parameters.ResumeLayout(False)
        Me.grpParameters.ResumeLayout(False)
        CType(Me.DataGridViewParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabParameters As TabControl
    Friend WithEvents Parameters As TabPage
    Friend WithEvents DataGridViewParameters As DataGridView
    Friend WithEvents FTP As TabPage
    Friend WithEvents grpParameters As GroupBox
    Friend WithEvents butUpdate As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents butGrant As Button
    Friend WithEvents butClose As Button
End Class
