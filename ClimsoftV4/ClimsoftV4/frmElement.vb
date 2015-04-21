Public Class frmElement

    Private Sub ObselementBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.ObselementBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4DataSet3)

    End Sub


    Private Sub ObselementBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles ObselementBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ObselementBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4DataSet3)

    End Sub

    Private Sub frmElement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mysql_climsoft_db_v4DataSet3.obselement' table. You can move, or remove it, as needed.
        Me.ObselementTableAdapter.Fill(Me.Mysql_climsoft_db_v4DataSet3.obselement)

    End Sub
End Class