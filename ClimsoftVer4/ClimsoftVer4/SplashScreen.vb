Public NotInheritable Class SplashScreen
    Public DelayPeriod As Integer = 0
    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then

            'ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ' ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        Timer1.Start()

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        ' Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        'Copyright.Text = My.Application.Info.Copyright
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DelayPeriod = DelayPeriod + 1
        'lblTimer.Text = DelayPeriod
        If DelayPeriod = 60 Then ' Delay for some Seconds
            Timer1.Stop()
            frmMainMenu.Show()
            Me.Hide()
        End If

    End Sub


    Private Sub lblwait_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MainLayoutPanel_Paint(sender As Object, e As PaintEventArgs) Handles MainLayoutPanel.Paint

    End Sub
End Class
