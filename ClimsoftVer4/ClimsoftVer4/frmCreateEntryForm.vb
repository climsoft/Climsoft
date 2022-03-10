Public Class frmCreateEntryForm
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim qry As MySql.Data.MySqlClient.MySqlCommand

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim frm, tbl As String

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
            sql = "SELECT form_name, description FROM data_forms where form_name = 'form_daily1' or form_name = 'form_synoptic2_TDCF';"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "data_forms")

            With ds.Tables("data_forms")
                For i = 0 To .Rows.Count - 1
                    lstBoxForms.Items.Add(.Rows(i).Item("description"))
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
            lstViewElements.Columns.Clear()
            lstViewElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            lstViewElements.Columns.Add("Element Description", 500, HorizontalAlignment.Left)

            'conn.Close()

            ClsTranslations.TranslateForm(Me)

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
        Dim dae As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dse As New DataSet
        Dim j As Integer
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

            dae = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dse.Clear()
            dae.Fill(dse, "obselement")

            maxRows = (dse.Tables("obselement").Rows.Count)

            If maxRows > 0 Then cboElements.BackColor = Color.White

            Dim str(2) As String
            Dim itm = New ListViewItem

            'For i = 0 To maxRows - 1

            str(0) = dse.Tables("obselement").Rows(0).Item("elementId")
            str(1) = dse.Tables("obselement").Rows(0).Item("description")
            itm = New ListViewItem(str)

            ItmExist = False
            If lstViewElements.Items.Count = 0 Then ' Always add the first selected item 
                lstViewElements.Items.Add(itm)
                'lstvElements.Items.Insert(1, itm)
            Else
                For j = 0 To lstViewElements.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstViewElements.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                ''If Not ItmExist Then lstvElements.Items.Add(itm)
                ''If lstvElements.Items(j).Selected = True Then MsgBox(lstvElements.Items(j).SubItems(1).Text)
                If Not ItmExist Then InsertItem(itm)
                'If Not ItmExist Then lstvElements.Items.Insert(j, itm)
            End If

        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub cboElements_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboElements.KeyPress
        If Asc(e.KeyChar) = 13 And IsNumeric(cboElements.Text) Then
            add_Element("ID", cboElements.Text)
            cboElements.Text = ""
        End If
    End Sub

    Private Sub lstvElements_KeyDown(sender As Object, e As KeyEventArgs) Handles lstViewElements.KeyDown
        If e.KeyCode = 46 Then
            'lstvElements.SelectedItems.Clear()
            'lstvElements.Refresh()
            For i = 0 To lstViewElements.Items.Count - 1
                If lstViewElements.Items(i).Selected Then
                    lstViewElements.Items(i).Remove()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmdFinish_Click(sender As Object, e As EventArgs) Handles cmdFinish.Click
        'Dim tbl As String
        'MsgBox(lstForms.SelectedItem)
        If Not TableName(tbl) Then Exit Sub
        'MsgBox(tbl)
        'Exit Sub

        Dim sql, tblSQL, idxSQL, valSQL, flgSQL, xtSQL, pryKySQL As String

        'Select Case tbl
        '    Case "form_daily1"

        'tblSQL = "DROP TABLE IF EXISTS `form_daily1`; CREATE TABLE IF NOT EXISTS `form_daily1` ( "
        '        idxSQL = "`stationId` varchar(50) NOT NULL DEFAULT '', `yyyy` int(11) NOT NULL, `mm` int(11) NOT NULL, `dd` int(11) NOT NULL, `hh` int(11) NOT NULL, "
        '        xtSQL = "`signature` varchar(45) DEFAULT NULL, `entryDatetime` datetime DEFAULT NULL, "
        '        pryKySQL = "PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`));"

        tblSQL = "DROP TABLE IF EXISTS `" & tbl & "`; CREATE TABLE IF NOT EXISTS `" & tbl & "` ( "
        idxSQL = "`stationId` varchar(50) NOT NULL DEFAULT '', `yyyy` int(11) NOT NULL, `mm` int(11) NOT NULL, `dd` int(11) NOT NULL, `hh` int(11) NOT NULL, "
        xtSQL = "`signature` varchar(45) DEFAULT NULL, `entryDatetime` datetime DEFAULT NULL, `temperatureUnits` varchar(45) DEFAULT NULL,`precipUnits` varchar(45) DEFAULT NULL,`cloudHeightUnits` varchar(45) DEFAULT NULL,`visUnits` varchar(45) DEFAULT NULL,`windspdUnits` varchar(45) DEFAULT NULL, "
        pryKySQL = "PRIMARY KEY (`stationId`,`yyyy`,`mm`,`dd`,`hh`));"

        With lstViewElements
            valSQL = ""
            flgSQL = ""
            For i = 0 To .Items.Count - 1
                valSQL = valSQL + "`Val_Elem" & .Items(i).SubItems(0).Text.PadLeft(3, "0"c) & "` varchar(6) DEFAULT NULL, "
                flgSQL = flgSQL + "`Flag" & .Items(i).SubItems(0).Text.PadLeft(3, "0"c) & "` varchar(1) DEFAULT NULL, "
            Next
        End With

        '    Case "form_synoptic2_TDCF"
        'End Select
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
        lstViewElements.Items.Clear()
    End Sub

    Private Sub lstForms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstBoxForms.SelectedIndexChanged
        Dim col As String

        'MsgBox(lstForms.SelectedItem)
        'Clear_lstElements()

        sql = "SELECT form_name, description FROM data_forms where description = '" & lstBoxForms.SelectedItem & "';"
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
                MsgBox("Table for the selected form does not exist. Create the table by selecting the observation elements required for the form from the Elements list box. Click 'Save' when done.")
                cboElements.Focus()
                Exit Sub
            End If
            MsgBox(x.HResult & " " & x.Message)
        End Try

        Try
            With ds.Tables("frm")
                lstViewElements.Items.Clear()
                'MsgBox("cleared")
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
        ed = stat + lstViewElements.Items.Count - 1
        sql = "update data_forms set val_start_position = " & stat & ", val_end_position =  " & ed & " where form_name = '" & tbl & "';"
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
    Function TableName(ByRef tbl As String) As Boolean

        sql = "SELECT table_name FROM data_forms where description = '" & lstBoxForms.SelectedItem & "';"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "tblNm")

        If ds.Tables("tblNm").Rows.Count > 0 Then
            tbl = ds.Tables("tblNm").Rows(0).Item("table_name")
        Else
            Return False
        End If

        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Sub Clear_lstElements()
        Try
            With lstViewElements
                If .Items.Count > 0 Then
                    .Items.Clear()
                    'MsgBox("Cleared")
                    'For i = 1 To .Items.Count - 1
                    '    .Items(i - 1).Remove()
                    'Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub InsertItem(itms As ListViewItem)
        Dim k As Integer
        Dim insrt As Boolean

        insrt = False
        For k = 0 To lstViewElements.Items.Count - 1
            If lstViewElements.Items(k).Selected Then
                insrt = True
                Exit For
            End If
        Next

        If insrt = True Then
            lstViewElements.Items.Insert(k, itms)
        Else
            lstViewElements.Items.Add(itms)
        End If

    End Sub

End Class
