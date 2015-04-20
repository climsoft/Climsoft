Public Class formSynopRA1

    Private Sub Form_synoptic_2_ra1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Form_synoptic_2_ra1BindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Form_synoptic_2_ra1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Mysql_climsoft_db_v4DataSet)

    End Sub

    Private Sub formSynopRA1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Mysql_climsoft_db_v4DataSet.form_synoptic_2_ra1' table. You can move, or remove it, as needed.
        Me.Form_synoptic_2_ra1TableAdapter.Fill(Me.Mysql_climsoft_db_v4DataSet.form_synoptic_2_ra1)

    End Sub
End Class
