Public Class formStation

    Private Sub StationBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles StationBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.StationBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4DataSet1)

    End Sub

    Private Sub station_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mysql_climsoft_db_v4DataSet1.station' table. You can move, or remove it, as needed.
        Me.StationTableAdapter.Fill(Me.Mysql_climsoft_db_v4DataSet1.station)

    End Sub
End Class