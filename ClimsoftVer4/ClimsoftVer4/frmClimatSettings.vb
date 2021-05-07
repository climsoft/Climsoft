Public Class frmClimatSettings
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim qry As MySql.Data.MySqlClient.MySqlCommand
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim dbConnectionString As String

    Private Sub frmClimatSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim climatds As New DataSet

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = dbConnectionString
            conn.Open()

            sql = "select * from climat_parameters order by Nos;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            climatds.Clear()
            da.Fill(climatds, "climat_parameters")
            conn.Close()

        Catch ex As Exception
            If ex.HResult = -2147467259 Then  ' Table does not exist
                ' Create table for CLIMAT parameters because it does not exist in the current datbase schema
                conn.Close()
                Create_ParametersTable()
                'da.Fill(climatds, "climat_parameters")
            Else
                ' Unknown error. Close dialog
                MsgBox(ex.Message)
                conn.Close()
                Me.Close()
                Exit Sub
            End If
        End Try

        Try
            With DataGridViewParameters
                .Show()
                .DataSource = climatds.Tables(0)
                .Columns(0).Width = 30
                .Columns(1).Width = 220
                .Columns(2).Width = 140
                .Refresh()
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox("Cannot show parameters")
            Me.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)

        'Dim recUpdate As New dataEntryGlobalRoutines

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = dbConnectionString
            conn.Open()

            sql = "select * from climat_parameters order by Nos;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "parameters")
            conn.Close()

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            With DataGridViewParameters
                For i = 0 To .Rows.Count - 1
                    For j = 3 To .Columns.Count - 1
                        ds.Tables("parameters").Rows(i).Item(j) = .Rows(i).Cells(j).Value
                    Next
                    da.Update(ds, "parameters")
                Next
                MsgBox("Update Successful")
            End With
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub Create_ParametersTable()

        sql = "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
CREATE TABLE IF NOT EXISTS `climat_parameters` (
  `Nos` int(2) unsigned NOT NULL,
  `Element_Name` varchar(50),
  `Element_Abbreviation` varchar(50),
  `Element_Code` varchar(6),
  `Bufr_Element` varchar(6) DEFAULT NULL,
  `unit` varchar(15) DEFAULT NULL,
  UNIQUE KEY `Index 1` (`Nos`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=COMPACT;
DELETE FROM `climat_parameters`;
/*!40000 ALTER TABLE `climat_parameters` DISABLE KEYS */;
INSERT INTO `climat_parameters` (`Nos`, `Element_Name`, `Element_Abbreviation`, `Element_Code`, `Bufr_Element`, `unit`) VALUES
	(1, 'Pressure at station', 'PRESST', '106', '010004', 'hpa'),
	(2, 'Pressure MSL', 'PRESSL', '107', '010051', 'hpa'),
	(3, 'Geopotential height  daily average', 'GPM', '478', '010009', 'gpm'),
	(4, 'Temperature daily mean', 'TMPMN', '4', '012101', 'dec \'c'),
	(5, 'Temperature daily maximum', 'TMPMAX', '2', '012111', 'dec \'c'),
	(6, 'Temperature daily minimum', 'TMPMIN', '3', '012112', 'dec \'c'),
	(7, 'Vapour Pressure', 'VAPPSR', '166', '013004', 'hPa'),
	(8, 'Daily precipitation', 'PRECIP', '5', '013023', 'mm'),
	(9, 'Sunshine hours daily total', 'SUNSHN', '84', '014031', 'hrs'),
	(10, 'Snow depth daily total', 'SNWDEP', '50', '013013', 'mm'),
	(11, 'Wind speed daily average', 'WNDSPD', '111', '011002', 'm/s'),
	(12, 'Visibility horizontal distance', 'VISBY', '110', '020001', 'm'),
	(13, 'Thunder daily occurence', 'DYTHND', '30', '008052', 'code'),
	(14, 'Hail daily occurence', 'DYHAIL', '31', '008052', 'code');
/*!40000 ALTER TABLE `climat_parameters` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"

        Me.Cursor = Cursors.WaitCursor
        dbConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = dbConnectionString
        conn.Open()

        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MsgBox("Can't create CLIMAT parameters. Contact Administrator to start the operation, open settings and grant permissions")

            Me.Close()
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default
        conn.Close()
        UserPermissions()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub butUpdate_Click(sender As Object, e As EventArgs) Handles butUpdate.Click

        'Dim recUpdate As New dataEntryGlobalRoutines

        Try
            dbConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = dbConnectionString
            conn.Open()

            sql = "select * from climat_parameters order by Nos;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "parameters")
            conn.Close()

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            With DataGridViewParameters
                For i = 0 To .Rows.Count - 1
                    For j = 3 To .Columns.Count - 1
                        ds.Tables("parameters").Rows(i).Item(j) = .Rows(i).Cells(j).Value
                    Next
                    da.Update(ds, "parameters")
                Next
                MsgBox("Update Successful")
            End With
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub butClose_Click(sender As Object, e As EventArgs) Handles butClose.Click
        Me.Close()
    End Sub

    Private Sub butGrant_Click(sender As Object, e As EventArgs) Handles butGrant.Click

        UserPermissions()

        'sql = "select * from climsoftusers;"
        'Try

        '    dbConnectionString = frmLogin.txtusrpwd.Text
        '    conn.ConnectionString = dbConnectionString
        '    conn.Open()

        '    da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        '    ds.Clear()
        '    da.Fill(ds, "users")

        '    With ds.Tables("users")
        '        For i = 0 To .Rows.Count - 1
        '            If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
        '                sql = "GRANT SELECT ON climat_parameters TO '" & .Rows(i).Item("userName") & "';"
        '                qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        '                'execute command
        '                qry.ExecuteNonQuery()
        '            End If
        '        Next

        '    End With

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'conn.Close()
    End Sub

    Sub UserPermissions()

        sql = "select * from climsoftusers;"
        Try

            dbConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = dbConnectionString
            conn.Open()

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "users")

            With ds.Tables("users")
                ' Grant Permissions to table climat_parameters
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT ON climat_parameters TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next
                ' Grant Permissions to table normals_averages
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT,CREATE,DROP,INSERT ON normals_averages TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next

                ' Grant Permissions to table normals_totals
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT,CREATE,DROP,INSERT ON normals_totals TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next

                ' Grant Permissions to table normalyears
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT,CREATE,DROP,INSERT ON normalyears TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next

                ' Grant Permissions to table PrecipQuintiles
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT,CREATE,DROP,INSERT ON PrecipQuintiles TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next
            End With
            MsgBox("User permissions successfully granted")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub
End Class