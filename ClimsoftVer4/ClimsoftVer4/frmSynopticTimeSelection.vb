Public Class frmSynopticTimeSelection

    Dim conn As New MySqlConnector.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySqlConnector.MySqlDataAdapter
    Dim sql As String

    Private Sub frmHourlyTimeSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = frmLogin.txtusrpwd.Text
            conn.Open()
            sql = "select hh from seq_hour"
            da = New MySqlConnector.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "hours")
            Me.DataGridView1.DataSource = ds.Tables(0)
            conn.Close()
            ClsTranslations.TranslateForm(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySqlConnector.MySqlCommandBuilder(da)
        Dim objCmd As MySqlConnector.MySqlCommand
        Try


            ' Create the Command for executing query and set its properties
            conn.Open()
            With DataGridView1

                sql = "TRUNCATE `seq_hour`;"
                objCmd = New MySqlConnector.MySqlCommand(sql, conn)
                objCmd.ExecuteNonQuery()

                For i = 0 To .Rows.Count - 1
                    'MsgBox(.Rows(i).Cells(0).Value)
                    sql = "INSERT INTO seq_hour (`hh`) VALUES (" & .Rows(i).Cells(0).Value & ");"
                    objCmd = New MySqlConnector.MySqlCommand(sql, conn)
                    objCmd.ExecuteNonQuery()
                Next
            End With
            MsgBox("Update Successful")
            conn.Close()

        Catch ex As Exception
            conn.Close()
            If ex.HResult = "-2147467259" Then
                MsgBox("Update Successful")
            Else
                MsgBox(ex.HResult)
            End If
        End Try

    End Sub
End Class