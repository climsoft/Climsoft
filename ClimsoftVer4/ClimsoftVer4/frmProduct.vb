Public Class frmProduct

    Public Overrides Sub cmdHelp_Click(sender As Object, e As EventArgs)
        MsgBox("Product help message", MsgBoxStyle.Information)
    End Sub

    Public Overrides Sub cmdOk_Click(sender As Object, e As EventArgs)
        ' Call cmdApply and then close
        Me.cmdApply_Click(sender, e)
        Me.Close()
    End Sub

    Public Overrides Sub cmdApply_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cbo_stations_stationName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_station_stationName.SelectedIndexChanged

    End Sub

End Class
