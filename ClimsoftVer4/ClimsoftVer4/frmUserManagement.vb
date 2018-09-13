Public Class frmUserManagement
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim connStr As String, Sql As String
    Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

    Dim ds As New DataSet
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub populateDataGrid()
        Sql = "select * from climsoftusers"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        da.Fill(ds, "climsoftusers")
        Me.DataGridView1.DataSource = ds.Tables(0)
    End Sub
    Private Sub frmUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = frmLogin.txtusrpwd.Text
        conn.Open()
        populateDataGrid()
        conn.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "usersmanagement.htm#useraccount")
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click


        connStr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = connStr
        'Open connection to database
        conn.Open()

        Dim dbnme As String
        CurrentDB(connStr, dbnme)
        'MsgBox(dbnme)
        'Exit Sub

        If Strings.Len(txtPassword.Text) >= 6 Then
            If txtPassword.Text = txtConfirmPassword.Text Then

                Try
                    'add new user to [climsoftusers] table in operational databases
                    Sql = "INSERT INTO climsoftusers(userName,userRole) VALUES ('" & txtUserName.Text & "','" & cboUserRole.Text & "'" & ")"
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                    objCmd.ExecuteNonQuery()

                    'add new user to [climsoftusers] table in test database
                    Sql = "INSERT INTO mariadb_climsoft_test_db_v4.climsoftusers(userName,userRole) VALUES ('" & txtUserName.Text & "','" & cboUserRole.Text & "'" & ")"
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                    objCmd.ExecuteNonQuery()

                Catch ex As Exception
                    If ex.HResult <> -2147467259 Then MsgBox(ex.Message)
                End Try

                Try
                        'Create new user in [mysql.user] table
                        Sql = "CREATE USER '" & txtUserName.Text & "'@'localhost' IDENTIFIED BY '" & txtPassword.Text & "';"
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                        'execute Command
                        objCmd.ExecuteNonQuery()
                        'Create new user in [mysql.user] table
                        Sql = "CREATE USER '" & txtUserName.Text & "'@'%' IDENTIFIED BY '" & txtPassword.Text & "';"
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                        'execute Command
                        objCmd.ExecuteNonQuery()

                        If cboUserRole.Text = "ClimsoftAdmin" Then
                            '1. Admin

                            Sql = "GRANT ALL PRIVILEGES ON *.* TO '" & txtUserName.Text & "'@'%' WITH GRANT OPTION;"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT ALL PRIVILEGES ON *.* TO '" & txtUserName.Text & "'@'localhost' WITH GRANT OPTION;"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            ' ''Sql = "GRANT ClimsoftAdmin TO '" & txtUserName.Text & "' WITH ADMIN OPTION;"
                            ' ''objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            '' ''execute command
                            ' ''objCmd.ExecuteNonQuery()

                            '' ''Set default role to new user
                            ' ''Sql = "SET DEFAULT ROLE " & cboUserRole.Text & " FOR '" & txtUserName.Text & "'@'localhost';"
                            ' ''objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            '' ''execute command
                            ' ''objCmd.ExecuteNonQuery()

                            '2. Operator
                        ElseIf cboUserRole.Text = "ClimsoftOperator" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            '---
                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON mariadb_climsoft_test_db_v4.userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            '----
                            '3 Rainfall
                        ElseIf cboUserRole.Text = "ClimsoftRainfall" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON mariadb_climsoft_test_db_v4.form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition To '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON mariadb_climsoft_test_db_v4.userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '4. Operator Supervisor
                        ElseIf cboUserRole.Text = "ClimsoftOperatorSupervisor" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT INSERT,UPDATE ON " & dbnme & ".observationinitial TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT INSERT,UPDATE ON mariadb_climsoft_test_db_v4.observationinitial TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON mariadb_climsoft_test_db_v4.userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '5 QC
                        ElseIf cboUserRole.Text = "ClimsoftQC" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT SELECT ON " & dbnme & ".qc_interelement_relationship_definition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".qc_interelement_1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".qc_interelement_2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".observationinitial TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON " & dbnme & ".userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.data_forms TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.form_hourly_time_selection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_daily_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_element_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.seq_month_day_synoptime_leap_yr TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.qc_interelement_relationship_definition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.qc_interelement_1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.qc_interelement_2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_daily2 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_hourlywind TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_monthly TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic2_tdcf TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_synoptic_2_ra1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.observationinitial TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.form_agro1 TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON mariadb_climsoft_test_db_v4.userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '6. Metadata
                        ElseIf cboUserRole.Text = "ClimsoftMetadata" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrument TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrumentfaultreport TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".faultresolution TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrumentinspection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".observationschedule TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".obsscheduleclass TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationidalias TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationlocationhistory TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationqualifier TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.instrument TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.instrumentfaultreport TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.faultresolution TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.instrumentinspection TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.observationschedule TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.obsscheduleclass TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.stationidalias TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.stationlocationhistory TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.stationqualifier TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '7. Products
                        ElseIf cboUserRole.Text = "ClimsoftProducts" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".observationfinal TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".tblproducts TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.station TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.obselement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.stationelement TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.observationfinal TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.tblproducts TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '8. Developer
                        ElseIf cboUserRole.Text = "ClimsoftDeveloper" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT SHOW DATABASES ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT CREATE USER ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT CREATE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DROP ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT RELOAD ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT GRANT OPTION ON " & dbnme & ".* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,ALTER,SELECT,INSERT,UPDATE ON " & dbnme & ".* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON " & dbnme & ".userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT SHOW DATABASES ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT CREATE USER ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT CREATE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DROP ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT RELOAD ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT FILE ON *.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT GRANT OPTION ON mariadb_climsoft_test_db_v4.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,ALTER,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.* TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON mariadb_climsoft_test_db_v4.userrecords TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            '9. Translator
                        ElseIf cboUserRole.Text = "ClimsoftTranslator" Then
                            'Privileges on operational CLIMSOFT V4 database
                            Sql = "GRANT SELECT ON " & dbnme & ".regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT (TagID,en,fr,de,pt) ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT UPDATE (fr,de,pt) ON " & dbnme & ".language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                            'Privileges on operational CLIMSOFT V4 test database
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.regkeys TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.climsoftusers TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT (TagID,en,fr,de,pt) ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT UPDATE (fr,de,pt) ON mariadb_climsoft_test_db_v4.language_translation TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT SELECT ON mariadb_climsoft_test_db_v4.paperarchivedefinition TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()
                            Sql = "GRANT DELETE,SELECT,INSERT,UPDATE ON mariadb_climsoft_test_db_v4.paperarchive TO '" & txtUserName.Text & "';"
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                            'execute command
                            objCmd.ExecuteNonQuery()

                        End If

                        'Flush privileges
                        Sql = "FLUSH PRIVILEGES;"
                        objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
                        'execute command
                        objCmd.ExecuteNonQuery()

                        ds.Tables.Clear()
                        populateDataGrid()

                        MsgBox("New user created successfully!", MsgBoxStyle.Information)

                        'Clear all text
                        txtConfirmPassword.Text = ""
                        txtPassword.Text = ""
                        txtUserName.Text = ""
                        cboUserRole.Text = ""

                    Catch ex As Exception
                    'Dispaly Exception error message 
                    MsgBox(ex.HResult & " " & ex.Message)
                    conn.Close()
                End Try
            Else
                MsgBox("Wrong confirmation of password!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Password length must be >=6 characters!", MsgBoxStyle.Information)
        End If

        'Close connection
        conn.Close()
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        If Strings.Len(txtConfirmPassword.Text) > 0 And Strings.Len(txtPassword.Text) > 0 And _
            Strings.Len(txtUserName.Text) > 0 And Strings.Len(cboUserRole.Text) > 0 Then
            btnAddNew.Enabled = True
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        connStr = frmLogin.txtusrpwd.Text
        conn.ConnectionString = connStr
        'Open connection to database
        conn.Open()
        Dim usrName As String
        Try
            usrName = Me.DataGridView1.CurrentCell.Value

            'Remove account name from [mysql.user] table
            Sql = "DROP USER '" & usrName & "'@'%';"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            objCmd.ExecuteNonQuery()
            Sql = "DROP USER '" & usrName & "'@'localhost';"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            objCmd.ExecuteNonQuery()

            'Delete user from [climsoftusers] table
            Sql = "DELETE FROM climsoftusers where userName='" & usrName & "';"
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(Sql, conn)
            objCmd.ExecuteNonQuery()

            ds.Tables.Clear()
            populateDataGrid()

            MsgBox("User account [" & usrName & "] has been deleted!", MsgBoxStyle.Information)

            conn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub
    Sub CurrentDB(connstr As String, ByRef dbnme As String)
        Dim Ssvr, Esvr, Sdb, Edb As Integer
        Dim svrstr, portstr As String
        ' server=127.0.0.1;database=mysql_climsoft_db_v4;port=3306;
        Ssvr = 8
        Esvr = InStr(connstr, ";database=")
        Sdb = Esvr + 10
        Edb = InStr(connstr, ";port")
        portstr = Mid(connstr, Edb + 6, 4)
        svrstr = Mid(connstr, Ssvr, Esvr - Ssvr)
        dbnme = Mid(connstr, Sdb, Edb - Sdb)

        'Svr_db_port = svrstr & "\\" & dbstr
    End Sub
End Class