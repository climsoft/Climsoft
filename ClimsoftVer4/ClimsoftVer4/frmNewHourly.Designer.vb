﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewHourly
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
        Me.ucrHourly = New ClimsoftVer4.ucrHourly()
        Me.SuspendLayout()
        '
        'ucrHourly
        '
        Me.ucrHourly.Location = New System.Drawing.Point(1, 2)
        Me.ucrHourly.Margin = New System.Windows.Forms.Padding(5)
        Me.ucrHourly.Name = "ucrHourly"
        Me.ucrHourly.Size = New System.Drawing.Size(800, 635)
        Me.ucrHourly.TabIndex = 5
        '
        'frmNewHourly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 609)
        Me.Controls.Add(Me.ucrHourly)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmNewHourly"
        Me.Text = "Hourly Data"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrHourly As ucrHourly
End Class
