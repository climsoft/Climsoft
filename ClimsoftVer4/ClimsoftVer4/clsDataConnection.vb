Public Class clsDataConnection
    Public Shared db As New mariadb_climsoft_test_db_v4Entities

    Public Shared Sub SaveUpdate()
        Try
            db.SaveChanges()
            MessageBox.Show("Record has been saved", "Saving Record")

        Catch
            MessageBox.Show("Record has been not been saved", "Saving Record")
        End Try
    End Sub


End Class
