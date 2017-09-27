﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConversionDewPointRh
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
        Me.drybulb = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblTT = New System.Windows.Forms.Label()
        Me.humidity = New System.Windows.Forms.TextBox()
        Me.wetbulb = New System.Windows.Forms.TextBox()
        Me.dewpoint = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTw = New System.Windows.Forms.Label()
        Me.lblTd = New System.Windows.Forms.Label()
        Me.lblRH = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'drybulb
        '
        Me.drybulb.Location = New System.Drawing.Point(12, 65)
        Me.drybulb.Name = "drybulb"
        Me.drybulb.Size = New System.Drawing.Size(75, 20)
        Me.drybulb.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(109, 112)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblTT
        '
        Me.lblTT.AutoSize = True
        Me.lblTT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTT.Location = New System.Drawing.Point(12, 38)
        Me.lblTT.Name = "lblTT"
        Me.lblTT.Size = New System.Drawing.Size(45, 15)
        Me.lblTT.TabIndex = 2
        Me.lblTT.Text = "TT (°C)"
        '
        'humidity
        '
        Me.humidity.Location = New System.Drawing.Point(316, 65)
        Me.humidity.Name = "humidity"
        Me.humidity.Size = New System.Drawing.Size(75, 20)
        Me.humidity.TabIndex = 3
        '
        'wetbulb
        '
        Me.wetbulb.Location = New System.Drawing.Point(109, 65)
        Me.wetbulb.Name = "wetbulb"
        Me.wetbulb.Size = New System.Drawing.Size(75, 20)
        Me.wetbulb.TabIndex = 4
        '
        'dewpoint
        '
        Me.dewpoint.Location = New System.Drawing.Point(216, 65)
        Me.dewpoint.Name = "dewpoint"
        Me.dewpoint.Size = New System.Drawing.Size(75, 20)
        Me.dewpoint.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(221, 112)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTw
        '
        Me.lblTw.AutoSize = True
        Me.lblTw.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTw.Location = New System.Drawing.Point(106, 38)
        Me.lblTw.Name = "lblTw"
        Me.lblTw.Size = New System.Drawing.Size(47, 15)
        Me.lblTw.TabIndex = 7
        Me.lblTw.Text = "Tw (°C)"
        '
        'lblTd
        '
        Me.lblTd.AutoSize = True
        Me.lblTd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTd.Location = New System.Drawing.Point(213, 38)
        Me.lblTd.Name = "lblTd"
        Me.lblTd.Size = New System.Drawing.Size(45, 15)
        Me.lblTd.TabIndex = 8
        Me.lblTd.Text = "Td (°C)"
        '
        'lblRH
        '
        Me.lblRH.AutoSize = True
        Me.lblRH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRH.Location = New System.Drawing.Point(313, 38)
        Me.lblRH.Name = "lblRH"
        Me.lblRH.Size = New System.Drawing.Size(47, 15)
        Me.lblRH.TabIndex = 9
        Me.lblRH.Text = "RH (%)"
        '
        'FrmConversionDewPointRh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 178)
        Me.Controls.Add(Me.lblRH)
        Me.Controls.Add(Me.lblTd)
        Me.Controls.Add(Me.lblTw)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dewpoint)
        Me.Controls.Add(Me.wetbulb)
        Me.Controls.Add(Me.humidity)
        Me.Controls.Add(Me.lblTT)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.drybulb)
        Me.Name = "FrmConversionDewPointRh"
        Me.Text = "Calculation of Dew Point and Relative Humidity"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents drybulb As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents lblTT As Label
    Friend WithEvents humidity As TextBox
    Friend WithEvents wetbulb As TextBox
    Friend WithEvents dewpoint As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTw As Label
    Friend WithEvents lblTd As Label
    Friend WithEvents lblRH As Label
End Class
