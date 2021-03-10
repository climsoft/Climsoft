Public Class frmCreateEntryForm
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim qry As MySql.Data.MySqlClient.MySqlCommand

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim frm As String

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        conn.Close()
        Me.Close()
    End Sub

    Private Sub frmCreateEntryForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            myConnectionString = frmLogin.txtusrpwd.Text
            conn.ConnectionString = myConnectionString
            conn.Open()

            ' load forms
            sql = "SELECT form_name, description FROM data_forms where form_name = 'form_daily1';"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            With ds.Tables("data_forms")
                For i = 0 To .Rows.Count - 1
                    lstForms.Items.Add(.Rows(i).Item("description"))
                Next
            End With

            'Load elements
            sql = "SELECT elementId, description FROM obselement;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "elements")

            With ds.Tables("elements")
                For i = 0 To .Rows.Count - 1
                    cboElements.Items.Add(ds.Tables("elements").Rows(i).Item("description"))
                Next
            End With

            'Set Header for Elements list view
            lstvElements.Columns.Clear()
            lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Description", 500, HorizontalAlignment.Left)


        Catch ex As Exception
            MsgBox(ex.Message)
            conn.Close()
        End Try
    End Sub

    Private Sub cboElements_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboElements.SelectedIndexChanged

        If cboElements.Text <> "" Then add_Element("Name", cboElements.SelectedItem)

    End Sub


    Sub add_Element(idType As String, dat As String)
        Dim maxRows As Integer
        Dim ItmExist As Boolean

        Try
            Select Case idType
            '    Case "Name"
                '        sql = "SELECT elementId, description FROM obselement WHERE description ='" & cboElements.SelectedItem & "';"
                '    Case "ID"
                '        sql = "SELECT elementId, description FROM obselement WHERE elementId ='" & cboElements.Text & "';"
                'End Select

                Case "Name"
                    sql = "SELECT elementId, description FROM obselement WHERE description ='" & dat & "';"
                Case "ID"
                    sql = "SELECT elementId, description FROM obselement WHERE elementId ='" & dat & "';"
            End Select

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)

            If maxRows > 0 Then cboElements.BackColor = Color.White

            Dim str(2) As String
            Dim itm = New ListViewItem

            'For i = 0 To maxRows - 1
            str(0) = ds.Tables("obselement").Rows(0).Item("elementId")
            str(1) = ds.Tables("obselement").Rows(0).Item("description")
            itm = New ListViewItem(str)

            ItmExist = False
            If lstvElements.Items.Count = 0 Then ' Always add the first selected item 
                lstvElements.Items.Add(itm)
            Else
                For j = 0 To lstvElements.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstvElements.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                If Not ItmExist Then lstvElements.Items.Add(itm)
            End If

        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cboElements_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboElements.KeyPress
        If Asc(e.KeyChar) = 13 And IsNumeric(cboElements.Text) Then
            add_Element("ID", cboElements.Text)
            cboElements.Text = ""
        End If
    End Sub

    Private Sub lstvElements_KeyDown(sender As Object, e As KeyEventArgs) Handles lstvElements.KeyDown
        If e.KeyCode = 46 Then
            'lstvElements.SelectedItems.Clear()
            'lstvElements.Refresh()
            For i = 0 To lstvElements.Items.Count - 1
                If lstvElements.Items(i).Selected Then
                    lstvElements.Items(i).Remove()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmdFinish_Click(sender As Object, e As EventArgs) Handles cmdFinish.Click


        Dim sql, tblSQL, idxSQL, valSQL, flgSQL, xtSQL, pryKySQL As String

        tblSQL = "DROP TABLE IF EXISTS `form_daily1`; CREATE TABLE IF NOT EXISTS `form_daily1` ( "
        idxSQL = "`stationId` varchar(50) NOT NULL DEFAULT '', `yyyy` int(11) NOT NULL, `mm` int(11) NOT NULL, `dd` int(11) NOT NULL, `hh` int(11) NOT NULL, "
        xtSQL = "`signature` varchar(45) DEFAULT NULL, `entryDatetime` datetime DEFAULT NULL, "
        pryKySQL = "PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`));"

        With lstvElements
            valSQL = ""
            flgSQL = ""
            For i = 0 To .Items.Count - 1
                valSQL = valSQL + "`Val_Elem" & .Items(i).SubItems(0).Text.PadLeft(3, "0"c) & "` varchar(6) DEFAULT NULL, "
                flgSQL = flgSQL + "`Flag" & .Items(i).SubItems(0).Text.PadLeft(3, "0"c) & "` varchar(1) DEFAULT NULL, "
            Next
        End With

        sql = tblSQL & idxSQL & valSQL & flgSQL & xtSQL & pryKySQL

        If Not Update_DataForms() Then Exit Sub

        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            MsgBox("Form customization successful")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub butClear_Click(sender As Object, e As EventArgs) Handles butClear.Click
        lstvElements.Items.Clear()
    End Sub

    Private Sub lstForms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstForms.SelectedIndexChanged
        Dim col As String

        sql = "SELECT form_name, description FROM data_forms where description = '" & lstForms.SelectedItem & "';"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "forms")

        Try
            frm = ds.Tables("forms").Rows(0).Item(0)
            sql = "SELECT * FROM " & frm & ";"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "frm")
        Catch x As Exception
            If x.HResult = -2147467259 Then
                MsgBox("Table for the selected form does not exist. Create the table by selecting the observation elements required for the form from the Elements list box. Click 'Finish' when done.")
                cboElements.Focus()
                Exit Sub
            End If
            MsgBox(x.HResult & " " & x.Message)
        End Try

        Try
            With ds.Tables("frm")
                For i = 0 To .Columns.Count - 1
                    col = .Columns(i).ColumnName
                    If Strings.Left(col, 3) = "Val" Then
                        add_Element("ID", CInt(Strings.Right(col, 3)))
                    End If
                Next

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Update_DataForms() As Boolean
        Dim stat, ed As Integer

        stat = 5
        ed = stat + lstvElements.Items.Count - 1
        sql = "update data_forms set val_start_position = " & stat & ", val_end_position =  " & ed & " where form_name = 'form_daily1';"
        Try
            qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
            qry.CommandTimeout = 0
            qry.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

End Class
