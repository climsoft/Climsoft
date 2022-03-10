Public Class frmUserManagement

    Private Sub frmUserManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateUsersListView()
        ClsTranslations.TranslateForm(Me)
    End Sub

    Private Sub lstViewUsers_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lstViewUsers.ItemSelectionChanged
        linkUpdateUser.Enabled = lstViewUsers.SelectedItems.Count > 0
        linkDeleteUser.Enabled = lstViewUsers.SelectedItems.Count > 0
    End Sub

    Private Sub linkAddNewUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkAddNewUser.LinkClicked
        frmUser.SetupNewUser()
        frmUser.ShowDialog(Me)
        PopulateUsersListView()
    End Sub

    Private Sub linkUpdateUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkUpdateUser.LinkClicked
        If lstViewUsers.SelectedItems.Count > 0 Then
            frmUser.SetupExistingUser(lstViewUsers.SelectedItems.Item(0).Text)
            frmUser.ShowDialog(Me)
            PopulateUsersListView()
        End If
    End Sub

    Private Sub linkDeleteUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkDeleteUser.LinkClicked
        Try

            If DialogResult.Yes = MessageBox.Show(Me,
                               ClsTranslations.GetTranslation("Selecte user(s) will be deleted, do you still wish to proceed?"),
                               ClsTranslations.GetTranslation("Delete User(s)"),
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then

                For i As Integer = 0 To lstViewUsers.SelectedItems.Count - 1
                    Dim userName As String = lstViewUsers.SelectedItems.Item(i).Text
                    'delete user in [mysql.user] table
                    Using objCmd As New MySql.Data.MySqlClient.MySqlCommand("DROP USER '" & userName & "'@'%'", clsDataConnection.GetOpenedConnection)
                        objCmd.ExecuteNonQuery()
                    End Using

                    'delete user in climsoftusers table   
                    Using cmdDelete As New MySql.Data.MySqlClient.MySqlCommand("DELETE FROM climsoftusers WHERE userName = @user_name", clsDataConnection.GetOpenedConnection)
                        cmdDelete.Parameters.Add(New MySql.Data.MySqlClient.MySqlParameter("user_name", userName))
                        cmdDelete.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show(Me, ClsTranslations.GetTranslation("User(s) deleted"),
                                  ClsTranslations.GetTranslation("Delete User(s)"),
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)

                PopulateUsersListView()

            End If
        Catch ex As Exception
            MessageBox.Show(Me, ClsTranslations.GetTranslation("Error") & ": " & ex.Message,
                            ClsTranslations.GetTranslation("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub linkHelp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkHelp.LinkClicked
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "usersmanagement.htm#useraccount")
    End Sub

    Private Sub linkClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkClose.LinkClicked
        Me.Close()
    End Sub

    Private Sub PopulateUsersListView()
        Try
            Dim dataCall As New DataCall
            Dim dataTable As DataTable
            lstViewUsers.Items.Clear()
            'set the database name and columns, set the key field for updating, then add the retrieved data to the listview
            dataCall.SetTableNameAndFields("climsoftusers", {"userName", "userRole"})
            dataTable = dataCall.GetDataTable()
            For Each row As DataRow In dataTable.Rows
                lstViewUsers.Items.Add(New ListViewItem({row.Item("userName"), row.Item("userRole")}))
            Next

            linkUpdateUser.Enabled = lstViewUsers.SelectedItems.Count > 0
            linkDeleteUser.Enabled = lstViewUsers.SelectedItems.Count > 0

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message)
        End Try
    End Sub

    'todo. this sub has 4 references in 4 different dialogs. Once those references are removed, it should be delated
    'its being used by those dialogs to get the name of the database connected.
    'A functionality that's already built in clsDataConnection class.
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