<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplashScreen
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
        Me.components = New System.ComponentModel.Container()
        Dim lblWait As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplashScreen))
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ApplicationTitle = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblDescription = New System.Windows.Forms.Label()
        lblWait = New System.Windows.Forms.Label()
        Me.MainLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblWait
        '
        resources.ApplyResources(lblWait, "lblWait")
        lblWait.BackColor = System.Drawing.Color.Transparent
        lblWait.Name = "lblWait"
        lblWait.Tag = "Please_Wait"
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MainLayoutPanel, "MainLayoutPanel")
        Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 1, 0)
        Me.MainLayoutPanel.Controls.Add(Me.lblVersion, 0, 1)
        Me.MainLayoutPanel.Controls.Add(lblWait, 0, 2)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        '
        'ApplicationTitle
        '
        resources.ApplyResources(Me.ApplicationTitle, "ApplicationTitle")
        Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.ApplicationTitle.Name = "ApplicationTitle"
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Name = "lblVersion"
        '
        'Timer1
        '
        '
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.BackColor = System.Drawing.Color.Transparent
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Tag = "Climate_Data_Management_System"
        '
        'frmSplashScreen
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplashScreen"
        Me.ShowInTaskbar = False
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Public WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblVersion As System.Windows.Forms.Label

End Class
