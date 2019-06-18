Imports MySql.Data.MySqlClient
Module AcmadCrudModule
    'Setting up connection
    '
    '
    Public Function strstrconnection() As MySqlConnection
        Return New MySqlConnection(My.Settings.defaultDatabase)
    End Function
    Public strcon As MySqlConnection = strstrconnection()
    'Declaring variable
    '
    '
    Public result As String
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable

    'Inserting data in database method
    '
    '
    Public Sub create(ByVal sql As String, ByVal strSuccessMsg As String, ByVal strfailedMsg As String)
        Try
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(strfailedMsg, MsgBoxStyle.Information)
                Else
                    MsgBox(strSuccessMsg)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub
    'Retriving data in database method to datagrigView
    '
    '
    Public Sub reloadDataDvgrid(ByVal sql As String, ByVal DTG As Object)
        Try
            dt = New DataTable
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            DTG.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    Public Sub reloadDataTableWithTotal(ByVal sql As String, ByVal DTG As Object)
        Try
            dt = New DataTable
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            ' dt.Rows.Add(dt.NewRow())
            'dt.Rows.Add(dt.NewRow())
            'dt.Rows.InsertAt(dt.NewRow(), dt.Rows.Count - 1)
            'dt.Rows.InsertAt(dt.NewRow(), dt.Rows.Count - 1)
            'Dim i, j As Integer
            'i = 0
            'j = 0

            'For i = 0 To dgvNebulositeList.Columns.Count - 1
            '    Dim somme = 0
            '    For j = 0 To dgvNebulositeList.Rows.Count - 3
            '        somme = somme + dgvNebulositeList.Rows(j).Cells(i).Value
            '    Next
            '    dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 2).Cells(i).Value = somme
            '    dgvNebulositeList.Rows(dgvNebulositeList.Rows.Count - 1).Cells(i).Value = somme / dgvNebulositeList.Rows.Count - 3
            'Next


            da.Fill(dt)
            dt.Rows.Add(dt.NewRow())
            dt.Rows.Add(dt.NewRow())
            DTG.DataSource = dt


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()

    End Sub
    Public Function reloadDataTable(ByVal sql As String) As DataTable
        Try
            dt = New DataTable
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
        Return Nothing
    End Function
    'Retriving data in database method to datatable
    '
    '
    Public Function reload(ByVal sql As String)
        Try
            dt = New DataTable
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            Return dt

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        strcon.Close()
        da.Dispose()
        Return Nothing
    End Function
    'Retriving data in database method
    '
    '
    Public Sub loadCombobox(ByVal sql As String, ByVal combobox As Object, ByVal displayMember As String, ByVal valueMember As String)
        Try
            dt = New DataTable
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            'With dt.Columns
            '    .Add("key")
            '    .Add("value")
            'End With
            With combobox
                .DisplayMember = displayMember
                .ValueMember = valueMember
                .DataSource = dt
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        da.Dispose()
    End Sub
    'Updating data in database method
    '
    '
    Public Sub updates(ByVal sql As String, ByVal strSuccessMsg As String, ByVal strfailedMsg As String)
        Try
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(strfailedMsg, MsgBoxStyle.Information)
                Else
                    MsgBox(strSuccessMsg)
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub
    'Deleting data in database method
    '
    '
    Public Sub delete(ByVal sql As String, ByVal strSuccessMsg As String, ByVal strfailedMsg As String)
        Try
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MsgBox(strfailedMsg, MsgBoxStyle.Critical)
                Else
                    MsgBox(strSuccessMsg)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
    End Sub
    Public Function getLstId(ByVal sql As String)
        Dim id As Int32 = 0
        Try
            If strcon.State <> ConnectionState.Open Then
                strcon.Open()
            End If
            With cmd
                .Connection = strcon
                .CommandText = sql
                id = Convert.ToInt32(cmd.ExecuteScalar())

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        strcon.Close()
        Return id
    End Function
End Module
