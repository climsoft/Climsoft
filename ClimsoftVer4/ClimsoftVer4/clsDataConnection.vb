Public Class clsDataConnection
    Public Shared db As New mariadb_climsoft_test_db_v4Entities

    Public Shared Sub SaveUpdate(Optional bSilent As Boolean = False)
        Try
            db.SaveChanges()
            If Not bSilent Then
                MessageBox.Show("Record has been saved", "Saving Record")
            End If
        Catch
            If Not bSilent Then
                MessageBox.Show("Record has not been saved", "Saving Record")
            End If
        End Try
    End Sub


End Class
