Public Class formElement

    Private Sub ObselementBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles ObselementBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ObselementBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4DataSet2)

    End Sub

    Private Sub formElement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mysql_climsoft_db_v4DataSet2.obselement' table. You can move, or remove it, as needed.
        Me.ObselementTableAdapter.Fill(Me.Mysql_climsoft_db_v4DataSet2.obselement)

    End Sub
End Class