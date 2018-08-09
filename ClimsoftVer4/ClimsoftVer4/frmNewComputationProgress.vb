
Imports System.ComponentModel

Public Class frmNewComputationProgress
    Private bShowResultMessage As Boolean = False

    Private Sub frmNewComputationProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backgroundWorker.WorkerReportsProgress = True
        backgroundWorker.WorkerSupportsCancellation = True
        lblProgress.Text = ""
        lblResultMessage.Visible = False
        btnClose.Visible = False
    End Sub

    Private Sub backgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
        progressBar.Increment(e.ProgressPercentage)
        lblProgress.Text = (progressBar.Value / progressBar.Maximum) * 100 & "% completed"
        Me.Text = (progressBar.Value / progressBar.Maximum) * 100 & "% completed"
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted

        If bShowResultMessage Then
            btnCancel.Visible = False
            lblResultMessage.Text = e.Result.ToString()
            lblResultMessage.Visible = True
            btnClose.Visible = True
            'MessageBox.Show(Me, e.Result.ToString(), lblHeader.Text, MessageBoxButtons.OK)
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        lblProgress.Text = "cancelled"
        backgroundWorker.CancelAsync()
        'backgroundWorker.Dispose()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub SetProgressMaximum(iMax As Integer)
        If progressBar.InvokeRequired Then
            progressBar.Invoke(Sub() SetProgressMaximum(iMax))
        Else
            progressBar.Maximum = iMax
        End If
    End Sub

    Public Sub SetHeader(strHeader As String)
        lblHeader.Text = strHeader
    End Sub

    Public Sub ShowResultMessage(bShow As Boolean)
        Me.bShowResultMessage = bShow
    End Sub




End Class