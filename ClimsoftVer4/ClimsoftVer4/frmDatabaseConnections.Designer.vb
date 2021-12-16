<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDatabaseConnections
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
        Me.dataGridViewConnections = New System.Windows.Forms.DataGridView()
        Me.connection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.server = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.database = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.port = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.grpCurrentSelection = New System.Windows.Forms.GroupBox()
        Me.cmdMakeDefault = New System.Windows.Forms.Button()
        Me.cmdTest = New System.Windows.Forms.Button()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.grpConnectionExamples = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblExamplePort3308 = New System.Windows.Forms.Label()
        Me.lblExampleDabaseName2 = New System.Windows.Forms.Label()
        Me.lblExamplePort3306 = New System.Windows.Forms.Label()
        Me.lblExampleDabaseName1 = New System.Windows.Forms.Label()
        Me.lblExampleServerAddress = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.dataGridViewConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCurrentSelection.SuspendLayout()
        Me.grpConnectionExamples.SuspendLayout()
        Me.SuspendLayout()
        '
        'dataGridViewConnections
        '
        Me.dataGridViewConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewConnections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.connection, Me.server, Me.database, Me.port})
        Me.dataGridViewConnections.Location = New System.Drawing.Point(12, 12)
        Me.dataGridViewConnections.MultiSelect = False
        Me.dataGridViewConnections.Name = "dataGridViewConnections"
        Me.dataGridViewConnections.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dataGridViewConnections.Size = New System.Drawing.Size(627, 208)
        Me.dataGridViewConnections.TabIndex = 0
        '
        'connection
        '
        Me.connection.HeaderText = "Connection name"
        Me.connection.Name = "connection"
        Me.connection.Width = 150
        '
        'server
        '
        Me.server.HeaderText = "Server address"
        Me.server.Name = "server"
        Me.server.Width = 150
        '
        'database
        '
        Me.database.HeaderText = "Database name"
        Me.database.Name = "database"
        Me.database.Width = 200
        '
        'port
        '
        Me.port.HeaderText = "Port number"
        Me.port.Name = "port"
        Me.port.Width = 60
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(564, 360)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grpCurrentSelection
        '
        Me.grpCurrentSelection.Controls.Add(Me.cmdMakeDefault)
        Me.grpCurrentSelection.Controls.Add(Me.cmdTest)
        Me.grpCurrentSelection.Controls.Add(Me.cmdRemove)
        Me.grpCurrentSelection.Enabled = False
        Me.grpCurrentSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCurrentSelection.Location = New System.Drawing.Point(483, 239)
        Me.grpCurrentSelection.Name = "grpCurrentSelection"
        Me.grpCurrentSelection.Size = New System.Drawing.Size(156, 115)
        Me.grpCurrentSelection.TabIndex = 6
        Me.grpCurrentSelection.TabStop = False
        Me.grpCurrentSelection.Text = "Current selection"
        '
        'cmdMakeDefault
        '
        Me.cmdMakeDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMakeDefault.Location = New System.Drawing.Point(21, 23)
        Me.cmdMakeDefault.Name = "cmdMakeDefault"
        Me.cmdMakeDefault.Size = New System.Drawing.Size(117, 23)
        Me.cmdMakeDefault.TabIndex = 5
        Me.cmdMakeDefault.Text = "Make default"
        Me.cmdMakeDefault.UseVisualStyleBackColor = True
        '
        'cmdTest
        '
        Me.cmdTest.Enabled = False
        Me.cmdTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTest.Location = New System.Drawing.Point(21, 52)
        Me.cmdTest.Name = "cmdTest"
        Me.cmdTest.Size = New System.Drawing.Size(117, 23)
        Me.cmdTest.TabIndex = 4
        Me.cmdTest.Text = "Test connection"
        Me.cmdTest.UseVisualStyleBackColor = True
        '
        'cmdRemove
        '
        Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.Location = New System.Drawing.Point(21, 81)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(117, 23)
        Me.cmdRemove.TabIndex = 3
        Me.cmdRemove.Text = "Remove connection"
        Me.cmdRemove.UseVisualStyleBackColor = True
        '
        'grpConnectionExamples
        '
        Me.grpConnectionExamples.Controls.Add(Me.Label10)
        Me.grpConnectionExamples.Controls.Add(Me.Label9)
        Me.grpConnectionExamples.Controls.Add(Me.lblExamplePort3308)
        Me.grpConnectionExamples.Controls.Add(Me.lblExampleDabaseName2)
        Me.grpConnectionExamples.Controls.Add(Me.lblExamplePort3306)
        Me.grpConnectionExamples.Controls.Add(Me.lblExampleDabaseName1)
        Me.grpConnectionExamples.Controls.Add(Me.lblExampleServerAddress)
        Me.grpConnectionExamples.Controls.Add(Me.Label3)
        Me.grpConnectionExamples.Controls.Add(Me.Label2)
        Me.grpConnectionExamples.Controls.Add(Me.Label1)
        Me.grpConnectionExamples.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConnectionExamples.Location = New System.Drawing.Point(12, 239)
        Me.grpConnectionExamples.Name = "grpConnectionExamples"
        Me.grpConnectionExamples.Size = New System.Drawing.Size(465, 144)
        Me.grpConnectionExamples.TabIndex = 7
        Me.grpConnectionExamples.TabStop = False
        Me.grpConnectionExamples.Text = "Example connections"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(173, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "MariaDB default"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(173, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "MySQL default"
        '
        'lblExamplePort3308
        '
        Me.lblExamplePort3308.AutoSize = True
        Me.lblExamplePort3308.Location = New System.Drawing.Point(121, 120)
        Me.lblExamplePort3308.Name = "lblExamplePort3308"
        Me.lblExamplePort3308.Size = New System.Drawing.Size(35, 13)
        Me.lblExamplePort3308.TabIndex = 7
        Me.lblExamplePort3308.Text = "3308"
        '
        'lblExampleDabaseName2
        '
        Me.lblExampleDabaseName2.AutoSize = True
        Me.lblExampleDabaseName2.Location = New System.Drawing.Point(121, 74)
        Me.lblExampleDabaseName2.Name = "lblExampleDabaseName2"
        Me.lblExampleDabaseName2.Size = New System.Drawing.Size(171, 13)
        Me.lblExampleDabaseName2.TabIndex = 6
        Me.lblExampleDabaseName2.Text = "mariadb_climsoft_test_db_v4"
        '
        'lblExamplePort3306
        '
        Me.lblExamplePort3306.AutoSize = True
        Me.lblExamplePort3306.Location = New System.Drawing.Point(121, 105)
        Me.lblExamplePort3306.Name = "lblExamplePort3306"
        Me.lblExamplePort3306.Size = New System.Drawing.Size(35, 13)
        Me.lblExamplePort3306.TabIndex = 5
        Me.lblExamplePort3306.Text = "3306"
        '
        'lblExampleDabaseName1
        '
        Me.lblExampleDabaseName1.AutoSize = True
        Me.lblExampleDabaseName1.Location = New System.Drawing.Point(121, 57)
        Me.lblExampleDabaseName1.Name = "lblExampleDabaseName1"
        Me.lblExampleDabaseName1.Size = New System.Drawing.Size(143, 13)
        Me.lblExampleDabaseName1.TabIndex = 4
        Me.lblExampleDabaseName1.Text = "mariadb_climsoft_db_v4"
        '
        'lblExampleServerAddress
        '
        Me.lblExampleServerAddress.AutoSize = True
        Me.lblExampleServerAddress.Location = New System.Drawing.Point(121, 29)
        Me.lblExampleServerAddress.Name = "lblExampleServerAddress"
        Me.lblExampleServerAddress.Size = New System.Drawing.Size(61, 13)
        Me.lblExampleServerAddress.TabIndex = 3
        Me.lblExampleServerAddress.Text = "127.0.0.1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Port number"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Database name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server address"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(483, 360)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 8
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'frmDatabaseConnections
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 395)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.grpCurrentSelection)
        Me.Controls.Add(Me.grpConnectionExamples)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.dataGridViewConnections)
        Me.Name = "frmDatabaseConnections"
        Me.Text = "Database Connections"
        CType(Me.dataGridViewConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCurrentSelection.ResumeLayout(False)
        Me.grpConnectionExamples.ResumeLayout(False)
        Me.grpConnectionExamples.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dataGridViewConnections As DataGridView
    Friend WithEvents cmdCancel As Button
    Friend WithEvents connection As DataGridViewTextBoxColumn
    Friend WithEvents server As DataGridViewTextBoxColumn
    Friend WithEvents database As DataGridViewTextBoxColumn
    Friend WithEvents port As DataGridViewTextBoxColumn
    Friend WithEvents grpCurrentSelection As GroupBox
    Friend WithEvents cmdTest As Button
    Friend WithEvents cmdRemove As Button
    Friend WithEvents grpConnectionExamples As GroupBox
    Friend WithEvents lblExamplePort3306 As Label
    Friend WithEvents lblExampleDabaseName1 As Label
    Friend WithEvents lblExampleServerAddress As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblExamplePort3308 As Label
    Friend WithEvents lblExampleDabaseName2 As Label
    Friend WithEvents cmdOK As Button
    Friend WithEvents cmdMakeDefault As Button
End Class
