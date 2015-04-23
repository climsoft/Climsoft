Public Class FormLaunchPad

    Private Sub btnStationInformation_Click(sender As Object, e As EventArgs) Handles btnStationInformation.Click
        formStation.Show()
    End Sub

    Private Sub btnSynopticData_Click(sender As Object, e As EventArgs) Handles btnSynopticData.Click
        formSynopRA1.Show()
    End Sub

    Private Sub btnElementInformation_Click(sender As Object, e As EventArgs) Handles btnElementInformation.Click
        formElement.Show()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class