Public Class formAWSRealTime

 

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        'pnlProcessing.Visible = True
        'pnlProcessing.Dock = DockStyle.Right
        'pnlServers.Visible = False
        'pnlSites.Visible = False
        'pnlDataStructures.Visible = False
        'pnlMessagesEncoding.Visible = False
        'Me.Text = "Process Settings"

        ShowPanel(pnlProcessing, "Process Settings")
    End Sub

    Private Sub formAWSRealTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlProcessing.Dock = DockStyle.Right
        pnlProcessing.Visible = True
    End Sub

    Private Sub cmdServers_Click(sender As Object, e As EventArgs) Handles cmdServers.Click
        'pnlServers.Dock = DockStyle.Right
        'pnlServers.Visible = True
        'pnlProcessing.Visible = False
        'Me.Text = "Servers Settings"
        ShowPanel(pnlServers, "Servers Settings")
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Sub ShowPanel(pnl As Object, topic As String)
        pnlControl.Dock = DockStyle.Left
        pnlProcessing.Visible = False
        pnlServers.Visible = False
        pnlSites.Visible = False
        pnlDataStructures.Visible = False
        pnlMsgEncoding.Visible = False
        Me.Text = topic
        pnl.Visible = True
        pnl.Dock = DockStyle.Right
    End Sub

    Private Sub cmdSites_Click(sender As Object, e As EventArgs) Handles cmdSites.Click
        ShowPanel(pnlSites, "Site Settings")
    End Sub

    Private Sub cmdDataStructures_Click(sender As Object, e As EventArgs) Handles cmdDataStructures.Click
        ShowPanel(pnlDataStructures, "Data Structures Settings")

    End Sub

    Private Sub cmdMessages_Click(sender As Object, e As EventArgs) Handles cmdMessages.Click
        ShowPanel(pnlMsgEncoding, "Message Coding Settings")
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub cmdBaseStation_Click(sender As Object, e As EventArgs) Handles cmdBaseStation.Click
        pnlBaseStation.Visible = True
        pnlMSS.Visible = False
    End Sub

    Private Sub cmdMSS_Click(sender As Object, e As EventArgs) Handles cmdMSS.Click
        pnlBaseStation.Visible = False
        pnlMSS.Visible = True
    End Sub
End Class