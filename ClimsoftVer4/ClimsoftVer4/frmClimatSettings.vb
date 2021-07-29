Public Class frmClimatSettings
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim qry As MySql.Data.MySqlClient.MySqlCommand
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim dbConnectionString As String


    Private Sub frmClimatSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dsp As New DataSet
        dbConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = dbConnectionString

        Try

            sql = "select * from climat_parameters order by Nos;"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            dsp.Clear()
            da.Fill(dsp, "climat_parameters")
            conn.Close()
            'MsgBox(11)
            'MsgBox(ds.Tables("climat_parameters").Rows.Count)

            If dsp.Tables("climat_parameters").Rows.Count < 15 Then
                ' Add header information
                HeaderDetails()
            End If

        Catch ex As Exception
            If ex.HResult = -2147467259 Then  ' Table does not exist
                'MsgBox(ex.Message & " at load ")
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
        'MsgBox(3)

        Try
            'MsgBox(dsp.Tables("climat_parameters").Rows.Count)
            ' Data set must be local!

            With DataGridViewParameters
                .Show()
                .DataSource = dsp.Tables(0)
                .Columns(0).Width = 30
                .Columns(1).Width = 220
                .Columns(2).Width = 140
                .Refresh()
            End With
        Catch ex As Exception
            conn.Close()
            'MsgBox(ex.Message & " at show grid table")
            MsgBox("Can't show CLIMAT parameters! Retry")
            Me.Close()
        End Try
        PopulateForms()
        'conn.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs)

        'Dim recUpdate As New dataEntryGlobalRoutines

        Try
            'dbConnectionString = frmLogin.txtusrpwd.Text
            'conn.ConnectionString = dbConnectionString
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
            'conn.Close()
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
        'dbConnectionString = frmLogin.txtusrpwd.Text
        'conn.ConnectionString = dbConnectionString

        Try

            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0

            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()

            UserPermissions()

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox(ex.Message)
            'MsgBox("Access permissions required. In the next dialog the Administrator should open Settings and then Click on Grant Permissions")
            conn.Close()
            Me.Close()
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default
        'conn.Close()

    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub butUpdate_Click(sender As Object, e As EventArgs) Handles butUpdate.Click

        'Dim recUpdate As New dataEntryGlobalRoutines

        Try
            'dbConnectionString = frmLogin.txtusrpwd.Text
            'conn.ConnectionString = dbConnectionString
            'conn.Open()

            sql = "select * from climat_parameters order by Nos;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "parameters")
            conn.Close()

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            With DataGridViewParameters
                For i = 0 To .Rows.Count - 1
                    For j = 2 To .Columns.Count - 1
                        ds.Tables("parameters").Rows(i).Item(j) = .Rows(i).Cells(j).Value
                    Next
                    da.Update(ds, "parameters")
                Next
                MsgBox("Update Successful")
            End With
        Catch ex As Exception
            'conn.Close()
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

            'dbConnectionString = frmLogin.txtusrpwd.Text
            'conn.ConnectionString = dbConnectionString
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

                ' Grant Permissions to table aws_mss to enable sending messages to GTS
                For i = 0 To .Rows.Count - 1
                    If .Rows(i).Item("userRole") = "ClimsoftProducts" Or .Rows(i).Item("userRole") = "ClimsoftQC" Then
                        sql = "GRANT SELECT ON aws_mss TO '" & .Rows(i).Item("userName") & "';"
                        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                        'execute command
                        qry.ExecuteNonQuery()
                    End If
                Next

            End With
            MsgBox("User permissions successfully granted")

        Catch ex As Exception
            MsgBox(ex.Message & " at User Permissions")
            conn.Close()
        End Try
        conn.Close()
    End Sub

    Sub PopulateForms()
        Dim kount As Integer

        Try

            ' Populate with MSS details
            sql = "SELECT * FROM aws_mss"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "aws_mss")
            conn.Close()

            kount = ds.Tables("aws_mss").Rows.Count
            For i = 0 To kount - 1
                If Not IsDBNull(ds.Tables("aws_mss").Rows(i).Item("ftpId")) Then txtServer.Text = ds.Tables("aws_mss").Rows(i).Item("ftpId")
                If Not IsDBNull(ds.Tables("aws_mss").Rows(i).Item("ftpMode")) Then cboFTP.Text = ds.Tables("aws_mss").Rows(i).Item("ftpMode")
                If Not IsDBNull(ds.Tables("aws_mss").Rows(i).Item("inputFolder")) Then txtFolder.Text = ds.Tables("aws_mss").Rows(i).Item("inputFolder")
                If Not IsDBNull(ds.Tables("aws_mss").Rows(i).Item("inputFolder")) Then txtLogin.Text = ds.Tables("aws_mss").Rows(i).Item("userName")
                If Not IsDBNull(ds.Tables("aws_mss").Rows(i).Item("password")) Then txtPassword.Text = ds.Tables("aws_mss").Rows(i).Item("password")
            Next

            ' Populate with Header
            sql = "select Element_Abbreviation, Element_Code from climat_parameters where Element_Name = 'Message Header';"
            conn.Open()
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ' Set to unlimited timeout period
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "message_header")
            conn.Close()
            If ds.Tables("message_header").Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables("message_header").Rows(0).Item(0)) Then txtMsgHeader.Text = ds.Tables("message_header").Rows(0).Item(0)
                If Not IsDBNull(ds.Tables("message_header").Rows(0).Item(1)) Then txtGTSdiff.Text = ds.Tables("message_header").Rows(0).Item(1)
            End If
            'conn.Close()

        Catch ex As Exception
            MsgBox(ex.Message & " at PopulateForms")
        End Try

    End Sub

    Private Sub TabParameters_Click(sender As Object, e As EventArgs) Handles TabParameters.Click
        btnAddNew.Visible = False
        Try
            If TabParameters.SelectedTab.Name = "FTP" Then
                sql = "SELECT * FROM aws_mss"
                'conn.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ' Set to unlimited timeout period
                da.SelectCommand.CommandTimeout = 0
                ds.Clear()
                da.Fill(ds, "aws_mss")
                'conn.Close()
                If ds.Tables("aws_mss").Rows.Count = 0 Then btnAddNew.Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " at TabParameters")
        End Try
    End Sub

    Sub HeaderDetails()

        sql = "INSERT INTO `climat_parameters` (`Nos`, `Element_Name`, `Element_Abbreviation`) VALUES (15, 'Message Header', 'CSNM40 FYWW');"
        conn.Open()

        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            'Execute query
            qry.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " at Header Details")
            conn.Close()
        End Try
    End Sub

    Private Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        ' Update message header
        Try
            sql = "update climat_parameters set Element_Abbreviation = '" & txtMsgHeader.Text & "', Element_Code = '" & txtGTSdiff.Text & "' where Element_Name = 'Message Header';"

            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            ' Update server details
            sql = "select * from aws_mss;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "mss")
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            With ds.Tables("mss")
                .Rows(0).Item("ftpId") = txtServer.Text
                .Rows(0).Item("ftpMode") = cboFTP.Text
                .Rows(0).Item("inputFolder") = txtFolder.Text
                .Rows(0).Item("userName") = txtLogin.Text
                .Rows(0).Item("password") = txtPassword.Text
            End With
            da.Update(ds, "mss")
            MsgBox("Update successful")
            'conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message & " at cmdUpdate_Click")
        End Try

    End Sub

    Private Sub btnUpdates_Click(sender As Object, e As EventArgs) Handles btnUpdates.Click
        'MsgBox(TabParameters.SelectedTab.Name)
        If TabParameters.SelectedTab.Name = "Parameters" Then
            Try
                sql = "select * from climat_parameters order by Nos;"
                conn.Open()
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds.Clear()
                da.Fill(ds, "parameters")
                conn.Close()

                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                With DataGridViewParameters
                    For i = 0 To .Rows.Count - 1
                        For j = 2 To .Columns.Count - 1
                            ds.Tables("parameters").Rows(i).Item(j) = .Rows(i).Cells(j).Value
                        Next
                        da.Update(ds, "parameters")
                    Next
                    MsgBox("Update Successful")
                End With
            Catch ex As Exception
                conn.Close()
                MsgBox(ex.Message & " at cmdUpdates_Parameters")
            End Try
        ElseIf TabParameters.SelectedTab.Name = "FTP" Then
            Try
                sql = "update climat_parameters set Element_Abbreviation = '" & txtMsgHeader.Text & "', Element_Code = '" & txtGTSdiff.Text & "' where Element_Name = 'Message Header';"
                conn.Open()
                qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                qry.CommandTimeout = 0
                qry.ExecuteNonQuery()

                ' Update server details
                sql = "select * from aws_mss;"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
                ds.Clear()
                da.Fill(ds, "mss")
                Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
                With ds.Tables("mss")
                    .Rows(0).Item("ftpId") = txtServer.Text
                    .Rows(0).Item("ftpMode") = cboFTP.Text
                    .Rows(0).Item("inputFolder") = txtFolder.Text
                    .Rows(0).Item("userName") = txtLogin.Text
                    .Rows(0).Item("password") = txtPassword.Text
                End With
                da.Update(ds, "mss")
                MsgBox("Update successful")
                conn.Close()
            Catch ex As Exception
                conn.Close()
                MsgBox(ex.Message & " at cmdUpdates_FTP")
            End Try
        End If
    End Sub

    Private Sub txtConfirmPassword_LostFocus(sender As Object, e As EventArgs) Handles txtConfirmPassword.LostFocus
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MsgBox("Password not confirmed")
            txtConfirmPassword.Text = ""
            'txtConfirmPassword.Focus()
        End If
    End Sub


    Private Sub txtServer_KeyDown(sender As Object, e As KeyEventArgs) Handles txtServer.KeyDown
        Nextbox(e)
    End Sub

    Sub Nextbox(e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            My.Computer.Keyboard.SendKeys("{TAB}")
        End If
    End Sub

    Private Sub cboFTP_KeyDown(sender As Object, e As KeyEventArgs) Handles cboFTP.KeyDown
        Nextbox(e)
    End Sub

    Private Sub txtFolder_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolder.KeyDown
        Nextbox(e)
    End Sub

    Private Sub txtLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLogin.KeyDown
        Nextbox(e)
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        Nextbox(e)
    End Sub

    Private Sub txtConfirmPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfirmPassword.KeyDown
        Nextbox(e)
    End Sub

    Function confirmPassword() As Boolean
        Try
            If txtPassword.Text <> txtConfirmPassword.Text Then
                MsgBox("Password not confirmed")
                txtConfirmPassword.Text = ""
                'txtConfirmPassword.Focus()
            End If
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'If TabParameters.SelectedTab.Name = "FTP" Then
        'btnAddNew.Visible = True
        Dim dsNewRow As DataRow
        Try
            sql = "update climat_parameters set Element_Abbreviation = '" & txtMsgHeader.Text & "', Element_Code = '" & txtGTSdiff.Text & "' where Element_Name = 'Message Header';"
            conn.Open()
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            ' Update server details
            sql = "select * from aws_mss;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "mss")
            conn.Close()

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

            With ds.Tables("mss")
                dsNewRow = .NewRow
                'Add a new record to the data source table
                .Rows.Add(dsNewRow)
                .Rows(0).Item("ftpId") = txtServer.Text
                .Rows(0).Item("ftpMode") = cboFTP.Text
                .Rows(0).Item("inputFolder") = txtFolder.Text
                .Rows(0).Item("userName") = txtLogin.Text
                .Rows(0).Item("password") = txtPassword.Text
            End With
            da.Update(ds, "mss")
            MsgBox("New Recorded Added")
            btnAddNew.Visible = False
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message & " at cmdAddNew_FTP")
        End Try
    End Sub
End Class