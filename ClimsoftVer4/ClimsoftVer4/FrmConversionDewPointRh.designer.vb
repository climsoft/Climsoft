<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConversionDewPointRh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.drybuld = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblTT = New System.Windows.Forms.Label()
        Me.humidity = New System.Windows.Forms.TextBox()
        Me.wetbulb = New System.Windows.Forms.TextBox()
        Me.dewpoint = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTw = New System.Windows.Forms.Label()
        Me.lblTd = New System.Windows.Forms.Label()
        Me.lblRH = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'drybuld
        '
        Me.drybuld.Location = New System.Drawing.Point(73, 89)
        Me.drybuld.Name = "drybuld"
        Me.drybuld.Size = New System.Drawing.Size(51, 20)
        Me.drybuld.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(170, 136)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(51, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblTT
        '
        Me.lblTT.AutoSize = True
        Me.lblTT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTT.Location = New System.Drawing.Point(73, 62)
        Me.lblTT.Name = "lblTT"
        Me.lblTT.Size = New System.Drawing.Size(45, 15)
        Me.lblTT.TabIndex = 0
        Me.lblTT.Text = "TT (°C)"
        '
        'humidity
        '
        Me.humidity.Location = New System.Drawing.Point(377, 89)
        Me.humidity.Name = "humidity"
        Me.humidity.Size = New System.Drawing.Size(51, 20)
        Me.humidity.TabIndex = 8
        '
        'wetbulb
        '
        Me.wetbulb.Location = New System.Drawing.Point(170, 89)
        Me.wetbulb.Name = "wetbulb"
        Me.wetbulb.Size = New System.Drawing.Size(51, 20)
        Me.wetbulb.TabIndex = 6
        '
        'dewpoint
        '
        Me.dewpoint.Location = New System.Drawing.Point(277, 89)
        Me.dewpoint.Name = "dewpoint"
        Me.dewpoint.Size = New System.Drawing.Size(51, 20)
        Me.dewpoint.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(277, 136)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 23)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTw
        '
        Me.lblTw.AutoSize = True
        Me.lblTw.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTw.Location = New System.Drawing.Point(167, 62)
        Me.lblTw.Name = "lblTw"
        Me.lblTw.Size = New System.Drawing.Size(47, 15)
        Me.lblTw.TabIndex = 2
        Me.lblTw.Text = "Tw (°C)"
        '
        'lblTd
        '
        Me.lblTd.AutoSize = True
        Me.lblTd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTd.Location = New System.Drawing.Point(274, 62)
        Me.lblTd.Name = "lblTd"
        Me.lblTd.Size = New System.Drawing.Size(45, 15)
        Me.lblTd.TabIndex = 3
        Me.lblTd.Text = "Td (°C)"
        '
        'lblRH
        '
        Me.lblRH.AutoSize = True
        Me.lblRH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRH.Location = New System.Drawing.Point(374, 62)
        Me.lblRH.Name = "lblRH"
        Me.lblRH.Size = New System.Drawing.Size(47, 15)
        Me.lblRH.TabIndex = 4
        Me.lblRH.Text = "RH (%)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Temperature values are multiplied by 10  e.g. 23.1 should be entered as 231"
        '
        'FrmConversionDewPointRh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 195)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblRH)
        Me.Controls.Add(Me.lblTd)
        Me.Controls.Add(Me.lblTw)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dewpoint)
        Me.Controls.Add(Me.wetbulb)
        Me.Controls.Add(Me.humidity)
        Me.Controls.Add(Me.lblTT)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.drybuld)
        Me.Name = "FrmConversionDewPointRh"
        Me.Text = "Calculation of Dew Point and Relative Humidity"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents drybuld As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents lblTT As Label
    Friend WithEvents humidity As TextBox
    Friend WithEvents wetbulb As TextBox
    Friend WithEvents dewpoint As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTw As Label
    Friend WithEvents lblTd As Label
    Friend WithEvents lblRH As Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
