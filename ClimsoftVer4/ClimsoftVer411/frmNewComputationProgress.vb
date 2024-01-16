Imports System.ComponentModel

Public Class frmNewComputationProgress
    Private bShowResultMessage As Boolean = False
    Private bShowPercentage As Boolean = True
    Private bShowNumbers As Boolean = False
    Private strPretextProgress As String = ""

    Private Sub frmNewComputationProgress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backgroundWorker.WorkerReportsProgress = True
        backgroundWorker.WorkerSupportsCancellation = True
        lblProgress.Text = ""
        txtResultMessage.Text = "Please wait..."
        txtResultMessage.Visible = False

        btnClose.Visible = False
    End Sub

    Private Sub backgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles backgroundWorker.ProgressChanged
        'progressBar.Increment(e.ProgressPercentage)

        If e.ProgressPercentage <= progressBar.Maximum Then
            progressBar.Value = e.ProgressPercentage
        End If

        If bShowNumbers Then
            lblProgress.Text = strPretextProgress & " " & progressBar.Value & " of " & progressBar.Maximum
        ElseIf bShowPercentage Then
            lblProgress.Text = strPretextProgress & " " & Math.Round((progressBar.Value / progressBar.Maximum) * 100) & "% completed"
        End If

        Me.Text = lblProgress.Text
    End Sub

    Private Sub backgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles backgroundWorker.RunWorkerCompleted

        If bShowResultMessage Then
            Try
                If e.Result IsNot Nothing Then
                    txtResultMessage.Text = e.Result.ToString()
                    txtResultMessage.SelectionStart = 0 'To remove the highlight
                    txtResultMessage.Visible = True
                End If
            Catch ex As Exception

            End Try

            lblProgress.Visible = False
            progressBar.Visible = False
            btnCancel.Visible = False
            btnClose.Visible = True
            'MessageBox.Show(Me, e.Result.ToString(), lblHeader.Text, MessageBoxButtons.OK)
        Else
            Me.Close()
        End If

    End Sub

    Private Sub frmNewComputationProgress_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If backgroundWorker.IsBusy Then
            backgroundWorker.CancelAsync()
        End If
        'backgroundWorker.Dispose()
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

    Public Sub SetPretextProgress(strNewPretextProgress As String)
        strPretextProgress = strNewPretextProgress
    End Sub

    Public Sub ShowPercentage(bNewShowPercentage As Boolean)
        bShowPercentage = bNewShowPercentage
    End Sub

    Public Sub ShowNumbers(bNewShowNumbers As Boolean)
        bShowNumbers = bNewShowNumbers
    End Sub

    Public Sub ShowResultMessage(bShow As Boolean)
        Me.bShowResultMessage = bShow
    End Sub


End Class