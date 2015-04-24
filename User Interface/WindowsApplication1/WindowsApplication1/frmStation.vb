Public Class frmStation

    Private Sub StationBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles StationBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.StationBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4StationDataSet)

    End Sub

    Private Sub frmStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mysql_climsoft_db_v4StationDataSet.station' table. You can move, or remove it, as needed.
        ' Me.StationTableAdapter.Fill(Me.Mysql_climsoft_db_v4StationDataSet.station)
        Me.StationTableAdapter.Fill(Me.Mysql_climsoft_db_v4StationDataSet.station)
    End Sub

    Private Sub frmStation_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class