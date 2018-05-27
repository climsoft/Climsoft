Public Class frmElementSequencerHourly
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim sql As String


    Private Sub frmElementSequencer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        On Error GoTo Err
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        sql = "select * from seq_element"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "seqElement")
        Me.DataGridView1.DataSource = ds.Tables(0)
        'Me.DataGridView1.
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Try
            da.Update(ds, "seqElement")
            ' MsgBox("Base sequencer table updated!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '-----------------
        'Update sequencer tables
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        'Clear sequencer table for non-leap year
        sql = "delete from seq_month_day_element"
               
                    ' Create the Command for executing query and set its properties
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    Try
                        'Execute query
            objCmd.ExecuteNonQuery()
            'MsgBox("Old sequencer records for non-leap year deleted!", MsgBoxStyle.Information)
                        ' Catch ex As MySql.Data.MySqlClient.MySqlException
                        'Ignore expected error i.e. error of Duplicates in MySqlException
                    Catch ex As Exception
                        'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                        MsgBox(ex.Message)
        End Try

        'Append new sequencer records for non-leap year
        sql = "insert ignore into seq_month_day_element (mm,dd,elementId) SELECT mm, dd, element_code FROM seq_element, seq_day, seq_month,seq_year WHERE not isnull(date(convert(STR_TO_DATE(concat('',dd,',',mm,',',yyyy,''),'%d,%m,%Y'),char))) GROUP BY mm, dd, seq;"

        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Try
            'Execute query
            objCmd.ExecuteNonQuery()

            ' MsgBox("Sequencer records for non-leap year updated!", MsgBoxStyle.Information)
            ' Catch ex As MySql.Data.MySqlClient.MySqlException
            'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        'Clear sequencer records for leap year
        sql = "delete from seq_month_day_element_leap_yr"
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Try
            'Execute query
            objCmd.ExecuteNonQuery()
            'MsgBox("Old sequencer records for leap year deleted!", MsgBoxStyle.Information)
            ' Catch ex As MySql.Data.MySqlClient.MySqlException
            'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        'Append new sequencer records for leap year
        sql = "insert ignore into seq_month_day_element_leap_yr (mm,dd,elementId) SELECT mm, dd, element_code FROM seq_element, seq_day, seq_month,seq_leap_year WHERE not isnull(date(convert(STR_TO_DATE(concat('',dd,',',mm,',',yyyy,''),'%d,%m,%Y'),char))) GROUP BY mm, dd, seq;"
        ' Create the Command for executing query and set its properties
        objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        Try
            'Execute query
            objCmd.ExecuteNonQuery()
            'MsgBox("Sequencer records for leap year updated!", MsgBoxStyle.Information)
            ' Catch ex As MySql.Data.MySqlClient.MySqlException
            'Ignore expected error i.e. error of Duplicates in MySqlException
        Catch ex As Exception
            'Dispaly error message if it is different from the one trapped in 'Catch' execption above
            MsgBox(ex.Message)
        End Try

        MsgBox("Sequencer records updated successfully!", MsgBoxStyle.Information)
        '-----------------
        conn.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Me.DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

            da.Update(ds, "seqElement")
            MsgBox("Record Deleted!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "hourlydata.htm")
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class