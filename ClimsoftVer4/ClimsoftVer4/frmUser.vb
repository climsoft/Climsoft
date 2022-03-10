Public Class frmUser

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnSave.Enabled = False

        ucrUserPasswordNew.SetValidPasswordLength(6)
        ucrUserPasswordNew.SetErorMessage("Password length must be >=6 characters!")
        ucrUserPasswordConfirm.SetErorMessage("Password must match!")
        ucrUserPasswordNew.Clear()
        ucrUserPasswordConfirm.Clear()

        ClsTranslations.TranslateForm(Me)
    End Sub

    Public Sub SetupNewUser()
        Me.Text = "New User"
        txtUserName.Text = ""
        txtUserName.ReadOnly = False
        cboUserRole.SelectedIndex = 0
    End Sub

    Public Sub SetupExistingUser(strUsername As String)
        Try
            Me.Text = "Edit User"
            txtUserName.Text = strUsername
            txtUserName.ReadOnly = True

            Dim dataCall As New DataCall
            'set the database name and columns, set the key field for updating, then add the retrieved data to the listview
            dataCall.SetTableNameAndFields("climsoftusers", {"userRole"})
            dataCall.SetFilter("userName", "=", strUsername)
            Dim dataTable As DataTable = dataCall.GetDataTable()
            If dataTable.Rows.Count > 0 Then
                cboUserRole.Text = dataTable.Rows(0).Item("userRole")
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try

    End Sub

    Private Sub ucrPassword_evtPasswordTextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged, cboUserRole.TextChanged, ucrUserPasswordNew.evtPasswordTextChanged, ucrUserPasswordConfirm.evtPasswordTextChanged
        If sender Is ucrUserPasswordNew Then
            ucrUserPasswordConfirm.SetValidPasswordText(ucrUserPasswordNew.GetPasswordText)
        End If

        btnSave.Enabled = txtUserName.Text <> "" AndAlso cboUserRole.Text <> "" AndAlso ucrUserPasswordNew.ValidPassword AndAlso ucrUserPasswordConfirm.ValidPassword
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try

            'its an update if the username text box is read only
            Dim bUpdate As Boolean = txtUserName.ReadOnly

            'if its an update, then prompt user of credential changes
            If bUpdate AndAlso DialogResult.No = MessageBox.Show(Me,
                               ClsTranslations.GetTranslation("User credential details will be changed, do you still wish to proceed"),
                               ClsTranslations.GetTranslation("User Credentials"),
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Exit Sub
            End If

            Dim paramUserName As New MySql.Data.MySqlClient.MySqlParameter("user_name", txtUserName.Text)
            Dim paramUserRole As New MySql.Data.MySqlClient.MySqlParameter("user_role", cboUserRole.Text)
            Dim sqlCommand As String


            If bUpdate Then
                'update the use password in [mysql.user] table
                'sqlCommand = "SET PASSWORD  = '" & ucrUserPasswordNew.GetPasswordText & "'"
                sqlCommand = "SET PASSWORD FOR '" & txtUserName.Text & "'@'%' = '" & ucrUserPasswordNew.GetPasswordText & "'"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCommand, clsDataConnection.GetOpenedConnection)
                    cmd.ExecuteNonQuery()
                End Using
            Else
                'Create new user in [mysql.user] table
                sqlCommand = "CREATE USER '" & txtUserName.Text & "'@'%' IDENTIFIED BY '" & ucrUserPasswordNew.GetPasswordText & "'"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sqlCommand, clsDataConnection.GetOpenedConnection)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            'delete user in climsoftusers table record if exists first 
            sqlCommand = "DELETE FROM climsoftusers WHERE userName = @user_name"
            Using cmdDelete As New MySql.Data.MySqlClient.MySqlCommand(sqlCommand, clsDataConnection.GetOpenedConnection)
                cmdDelete.Parameters.Add(paramUserName)
                cmdDelete.ExecuteNonQuery()
            End Using

            'insert user into climsoftusers table record
            sqlCommand = "INSERT INTO climsoftusers(userName,userRole) VALUES (@user_name,@user_role)"
            Using cmdInsert As New MySql.Data.MySqlClient.MySqlCommand(sqlCommand, clsDataConnection.GetOpenedConnection)
                cmdInsert.Parameters.Add(paramUserName)
                cmdInsert.Parameters.Add(paramUserRole)
                cmdInsert.ExecuteNonQuery()
            End Using

            'todo. what should we do when user privilages fail to be set successfuly?
            If Not SetPrivileges(txtUserName.Text, cboUserRole.Text) Then
                MessageBox.Show(Me, ClsTranslations.GetTranslation("Error") & ": " & "User privileges could not be set",
                            ClsTranslations.GetTranslation("User Privilages Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            If bUpdate Then
                MessageBox.Show(Me, ClsTranslations.GetTranslation("User updated successfully!"),
                  ClsTranslations.GetTranslation("User Update"),
                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(Me, ClsTranslations.GetTranslation("New user created successfully!"),
                       ClsTranslations.GetTranslation("New User"),
                       MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "usersmanagement.htm#useraccount")
    End Sub

    Private Function SetPrivileges(userName As String, userRole As String) As Boolean
        Try
            Dim databaseName As String = clsDataConnection.GetDatabaseName
            Dim lstSqlCommands As New List(Of String)

            lstSqlCommands.Add("REVOKE ALL PRIVILEGES, GRANT OPTION FROM '" & userName & "'@'%'")
            lstSqlCommands.Add("FLUSH PRIVILEGES")
            If userRole = "ClimsoftAdmin" Then
                'Admin operator
                lstSqlCommands.Add("GRANT ALL PRIVILEGES ON *.* TO '" & userName & "'@'%' WITH GRANT OPTION")
            ElseIf userRole = "ClimsoftOperator" Then
                'Climsoft Operator
                FillOperatorRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftRainfall" Then
                'Rainfall Operator
                FillRainfallRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftOperatorSupervisor" Then
                'Supervisor Operator
                FillOperatorSupervisorRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftQC" Then
                'QC Operator
                FillQCRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftMetadata" Then
                'Metadata Operator
                FillMetadataRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftProducts" Then
                'Products Operator
                FillProductsRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftDeveloper" Then
                'Developer Operator
                FillDeveloperRightsCmds(lstSqlCommands, databaseName, userName)
            ElseIf userRole = "ClimsoftTranslator" Then
                'Translator Operator
                FillTranslatorRightsCmds(lstSqlCommands, databaseName, userName)
            End If

            lstSqlCommands.Add("FLUSH PRIVILEGES")
            Using cmd As New MySql.Data.MySqlClient.MySqlCommand(String.Join(";", lstSqlCommands.ToArray()), clsDataConnection.GetOpenedConnection)
                cmd.ExecuteNonQuery()
            End Using

            Return True

        Catch ex As Exception
            MsgBox("Error Setting Privilages" & ex.Message)
            Return False
        End Try

    End Function

    Private Sub FillOperatorRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".data_forms TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_monthly_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_upperair1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_caribbean TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".form_agro1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".userrecords TO '" & userName & "'")

    End Sub

    Private Sub FillRainfallRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".data_forms TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_monthly_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE, CREATE ON " & dbnme & ".form_agro1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")

    End Sub

    Private Sub FillOperatorSupervisorRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".data_forms TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_monthly_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT INSERT,UPDATE ON " & dbnme & ".observationinitial TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_agro1 TO '" & userName & "'")

    End Sub

    Private Sub FillQCRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".data_forms TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".form_hourly_time_selection TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_daily_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_monthly_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_element_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".seq_month_day_synoptime_leap_yr TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".qc_interelement_relationship_definition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".qc_interelement_1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".qc_interelement_2 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_daily2 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_hourlywind TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_monthly TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic2_tdcf TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_synoptic_2_ra1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".observationinitial TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".form_agro1 TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON " & dbnme & ".userrecords TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE,DELETE,SELECT,INSERT,UPDATE,DROP ON " & dbnme & ".qcabslimits TO '" & userName & "'")

    End Sub

    Private Sub FillMetadataRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrument TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrumentfaultreport TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".faultresolution TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".instrumentinspection TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".observationschedule TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".obsscheduleclass TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationidalias TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationlocationhistory TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".physicalfeature TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".stationqualifier TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")

    End Sub

    Private Sub FillProductsRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".station TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obselement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationelement TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".instrument TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".obsscheduleclass TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationlocationhistory TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationlocationhistory TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".stationqualifier TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".physicalfeature TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".physicalfeatureclass TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".observationfinal TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE,DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".tblproducts TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")

    End Sub

    Private Sub FillDeveloperRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT SHOW DATABASES ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE USER ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DROP ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT RELOAD ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT GRANT OPTION ON " & dbnme & ".* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,ALTER,SELECT,INSERT,UPDATE ON " & dbnme & ".* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE,CREATE ON " & dbnme & ".userrecords TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SHOW DATABASES ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE USER ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT CREATE ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DROP ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT RELOAD ON *.* TO '" & userName & "'")
        lstSqlCommands.Add("GRANT FILE ON *.* TO '" & userName & "'")
    End Sub

    Private Sub FillTranslatorRightsCmds(lstSqlCommands As List(Of String), dbnme As String, userName As String)
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".regkeys TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".climsoftusers TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT (TagID,en,fr,de,pt) ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT UPDATE (fr,de,pt) ON " & dbnme & ".language_translation TO '" & userName & "'")
        lstSqlCommands.Add("GRANT SELECT ON " & dbnme & ".paperarchivedefinition TO '" & userName & "'")
        lstSqlCommands.Add("GRANT DELETE,SELECT,INSERT,UPDATE ON " & dbnme & ".paperarchive TO '" & userName & "'")
    End Sub




End Class