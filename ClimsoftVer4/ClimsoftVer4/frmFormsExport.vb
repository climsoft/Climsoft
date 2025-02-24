Public Class frmFormsExport

    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim maxRows, maxColumns As Integer
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim MyConnectionString, sql As String
    Dim stnlist, elmlist, levlist, elmcolmn, sdate, edate, abbrev, WrunCode As String
    Dim ItmExist As Boolean

    Private Sub cmbstation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstation.SelectedIndexChanged
        Dim prod As String

        prod = cmbstation.Text

        sql = "SELECT stationId, stationName FROM station WHERE stationName='" & prod & "';"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        ds.Clear()
        da.Fill(ds, "station")

        maxRows = (ds.Tables("station").Rows.Count)
        If maxRows > 0 Then cmbstation.BackColor = Color.White

        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("station").Rows(kount).Item("stationId")
                str(1) = ds.Tables("station").Rows(kount).Item("stationName")
                itm = New ListViewItem(str)

                '' When only one station required
                'If lblProductType.Text = "Yearly Elements Observed" Then
                '    lstvStations.Items.Clear()
                '    lstvStations.Items.Add(itm)
                '    Exit For
                'End If

                ItmExist = False
                If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                    lstvStations.Items.Add(itm)
                Else
                    For j = 0 To lstvStations.Items.Count - 1
                        ' Check if the item has been added in the list and skip it if so
                        If str(0) = lstvStations.Items(j).Text Then
                            ItmExist = True
                            Exit For
                        End If
                    Next
                    If Not ItmExist Then lstvStations.Items.Add(itm)
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElement.SelectedIndexChanged
        Dim prod As String
        'On Error GoTo Err
        Try
            prod = cmbElement.Text

            sql = "SELECT elementId, abbreviation, elementName FROM obselement WHERE elementName ='" & prod & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            If maxRows > 0 Then cmbElement.BackColor = Color.White

            Dim str(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                str(0) = ds.Tables("obselement").Rows(kount).Item("elementId")
                str(1) = ds.Tables("obselement").Rows(kount).Item("abbreviation")
                str(2) = ds.Tables("obselement").Rows(kount).Item("elementName")
                itm = New ListViewItem(str)

                ItmExist = False
                If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
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
            Next

        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Dim kounts, code As Integer

    Private Sub cmdDelStation_Click(sender As Object, e As EventArgs) Handles cmdDelStation.Click
        For i = 0 To lstvStations.Items.Count - 1
            If lstvStations.Items(i).Selected Then
                lstvStations.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    Private Sub cmdSelectAllStations_Click(sender As Object, e As EventArgs) Handles cmdSelectAllStations.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            lstvStations.Clear()
            lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
            lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

            sql = "SELECT " & dsSourceTableName & ".stationId, stationName FROM " & dsSourceTableName & " INNER JOIN station ON station.stationId = " & dsSourceTableName & ".stationId WHERE stationName IS NOT NULL GROUP BY stationName ORDER BY stationName;"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "stations")

            maxRows = (ds.Tables("stations").Rows.Count)
            Dim strs(2) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("stations").Rows(kount).Item("stationId")
                strs(1) = ds.Tables("stations").Rows(kount).Item("stationName")
                itm = New ListViewItem(strs)
                lstvStations.Items.Add(itm)
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClearStations_Click(sender As Object, e As EventArgs) Handles cmdClearStations.Click
        lstvStations.Items.Clear()
    End Sub

    Private Sub cmdSelectAllElements_Click(sender As Object, e As EventArgs) Handles cmdSelectAllElements.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            lstvElements.Clear()
            lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
            lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

            sql = "SELECT  " & dsSourceTableName & ".elementId, elementName,description  FROM  " & dsSourceTableName & " INNER JOIN obselement ON obselement.elementId =  " & dsSourceTableName & ".elementId WHERE elementName IS NOT NULL GROUP BY elementName ORDER By " & dsSourceTableName & ".elementId;"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()

            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "Elements")

            maxRows = (ds.Tables("Elements").Rows.Count)

            Dim strs(3) As String
            Dim itm = New ListViewItem

            For kount = 0 To maxRows - 1 Step 1
                strs(0) = ds.Tables("Elements").Rows(kount).Item("elementId")
                strs(1) = ds.Tables("Elements").Rows(kount).Item("elementName")
                strs(2) = ds.Tables("Elements").Rows(kount).Item("description")

                itm = New ListViewItem(strs)
                lstvElements.Items.Add(itm)
            Next
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message & " at SelectAllElements")
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdClearElements_Click(sender As Object, e As EventArgs) Handles cmdClearElements.Click
        lstvElements.Items.Clear()
    End Sub

    Private Sub cmdDelElement_Click(sender As Object, e As EventArgs) Handles cmdDelElement.Click
        For i = 0 To lstvElements.Items.Count - 1
            If lstvElements.Items(i).Selected Then
                lstvElements.Items(i).Remove()
                Exit For
            End If
        Next
    End Sub

    'Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
    '    Dim stPos, edPos As Integer
    '    Dim elmstruc As String

    '    Try
    '        If Not Frmdetails(dsSourceTableName, stPos, edPos, elmstruc) Then Exit Sub

    '        Select Case elmstruc
    '            Case "Vertical"
    '                MsgBox(edPos - stPos & " " & elmstruc)
    '            Case "Horizontal"
    '                MsgBox(edPos - stPos & " " & elmstruc)
    '        End Select

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub frmFormsExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Set Header for Stations list view
        Me.Text = Me.Text & " - " & dsSourceTableName
        lstvStations.Columns.Clear()
        lstvStations.Columns.Add("Station Id", 80, HorizontalAlignment.Left)
        lstvStations.Columns.Add("Station Name", 400, HorizontalAlignment.Left)

        'Set Header for Elements list view
        lstvElements.Columns.Clear()
        lstvElements.Columns.Add("Element Id", 80, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Abbrev", 100, HorizontalAlignment.Left)
        lstvElements.Columns.Add("Element Details", 400, HorizontalAlignment.Left)

        MyConnectionString = frmLogin.txtusrpwd.Text
        'Try
        conn.ConnectionString = MyConnectionString
        conn.Open()

        'Populate Station list

        sql = "Select stationName FROM " & dsSourceTableName & " INNER JOIN station On " & dsSourceTableName & ".stationId = station.stationId GROUP BY stationName ORDER BY stationName;"

        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "station")
            'conn.Close()

            maxRows = ds.Tables("station").Rows.Count

            For kount = 0 To maxRows - 1 Step 1
                cmbstation.Items.Add(ds.Tables("station").Rows(kount).Item("stationName"))
            Next
        Catch ex As Exception
            conn.Close()
            Exit Sub
        End Try

        'Populate Element list
        sql = "Select elementName FROM " & dsSourceTableName & " INNER JOIN obselement On obselement.elementId =  " & dsSourceTableName & ".elementId GROUP BY elementName order BY elementName;"
        Try
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = ds.Tables("obselement").Rows.Count
            If maxRows > 0 Then lstvElements.Enabled = True
            For kount = 0 To maxRows - 1 Step 1
                cmbElement.Items.Add(ds.Tables("obselement").Rows(kount).Item("elementName"))
            Next

        Catch ex As Exception
            lstvElements.Enabled = False
            conn.Close()
            Exit Sub
        End Try

        conn.Close()

    End Sub

    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    Dim stPos, edPos, Dflds, statValues, statFlags As Integer
    '    Dim elmstruc, dtF, dtT As String


    '    Try

    '        ' Get the stations list
    '        stnlist = ""
    '        If lstvStations.Items.Count > 0 Then
    '            stnlist = "'" & lstvStations.Items(0).Text & "'"
    '            For i = 1 To lstvStations.Items.Count - 1
    '                stnlist = stnlist & " OR stationId = " & "'" & lstvStations.Items(i).Text & "'"
    '            Next
    '        End If

    '        ' Get the Element list
    '        elmlist = ""
    '        elmcolmn = ""

    '        If lstvElements.Items.Count > 0 Then
    '            elmlist = "'" & lstvElements.Items(0).Text & "'" '""""

    '            For i = 1 To lstvElements.Items.Count - 1
    '                elmlist = elmlist & " OR  elementId = " & "'" & lstvElements.Items(i).Text & "'"
    '            Next
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    '    Try

    '        If Not Frmdetails(dsSourceTableName, stPos, edPos, elmstruc) Then Exit Sub

    '        statValues = stPos
    '        statFlags = edPos + 1
    '        Dflds = (edPos - stPos)
    '        dtF = DateAndTime.Day(dateFrom.Text) & "/" & DateAndTime.Month(dateFrom.Text) & "/" & DateAndTime.Year(dateFrom.Text)
    '        dtT = DateAndTime.Day(dateTo.Text) & "/" & DateAndTime.Month(dateTo.Text) & "/" & DateAndTime.Year(dateTo.Text)

    '        Select Case elmstruc
    '            Case "Vertical"

    '                Save_Verticals(Dflds, statValues, statFlags, dtF, dtT)

    '            Case "Horizontal"
    '                'MsgBox(edPos - stPos & " " & elmstruc)
    '                Save_Horizontals(Dflds, statValues, statFlags, dtF, dtT)
    '        End Select

    '        FileClose(101)

    '    Catch ex As Exception
    '        FileClose(101)
    '        MsgBox(ex.Message & " at btnSave")
    '    End Try
    'End Sub

    'Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Me.Close()
    'End Sub

    Private Sub tStrpBtnSave_Click(sender As Object, e As EventArgs)
        Dim stPos, edPos, Dflds, statValues, statFlags As Integer
        Dim elmstruc, dtF, dtT As String


        Try

            ' Get the stations list
            stnlist = ""
            If lstvStations.Items.Count > 0 Then
                stnlist = "'" & lstvStations.Items(0).Text & "'"
                For i = 1 To lstvStations.Items.Count - 1
                    stnlist = stnlist & " OR stationId = " & "'" & lstvStations.Items(i).Text & "'"
                Next
            End If

            ' Get the Element list
            elmlist = ""
            elmcolmn = ""

            If lstvElements.Items.Count > 0 Then
                elmlist = "'" & lstvElements.Items(0).Text & "'" '""""

                For i = 1 To lstvElements.Items.Count - 1
                    elmlist = elmlist & " OR  elementId = " & "'" & lstvElements.Items(i).Text & "'"
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try

            If Not Frmdetails(dsSourceTableName, stPos, edPos, elmstruc) Then Exit Sub

            statValues = stPos
            statFlags = edPos + 1
            Dflds = (edPos - stPos)
            dtF = DateAndTime.Day(dateFrom.Text) & "/" & DateAndTime.Month(dateFrom.Text) & "/" & DateAndTime.Year(dateFrom.Text)
            dtT = DateAndTime.Day(dateTo.Text) & "/" & DateAndTime.Month(dateTo.Text) & "/" & DateAndTime.Year(dateTo.Text)

            Select Case elmstruc
                Case "Vertical"

                    Save_Verticals(Dflds, statValues, statFlags, dtF, dtT)

                Case "Horizontal"
                    'MsgBox(edPos - stPos & " " & elmstruc)
                    Save_Horizontals(Dflds, statValues, statFlags, dtF, dtT)
            End Select

            FileClose(101)

        Catch ex As Exception
            FileClose(101)
            MsgBox(ex.Message & " at btnSave")
        End Try
    End Sub

    Private Sub tlstrpBtn_Click(sender As Object, e As EventArgs) Handles tlstrpBtn.Click
        Dim stPos, edPos, Dflds, statValues, statFlags As Integer
        Dim elmstruc, dtF, dtT As String


        Try

            ' Get the stations list
            stnlist = ""
            If lstvStations.Items.Count > 0 Then
                stnlist = "'" & lstvStations.Items(0).Text & "'"
                For i = 1 To lstvStations.Items.Count - 1
                    stnlist = stnlist & " OR stationId = " & "'" & lstvStations.Items(i).Text & "'"
                Next
            End If

            ' Get the Element list
            elmlist = ""
            elmcolmn = ""

            If lstvElements.Items.Count > 0 Then
                elmlist = "'" & lstvElements.Items(0).Text & "'" '""""

                For i = 1 To lstvElements.Items.Count - 1
                    elmlist = elmlist & " OR  elementId = " & "'" & lstvElements.Items(i).Text & "'"
                Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try

            If Not Frmdetails(dsSourceTableName, stPos, edPos, elmstruc) Then Exit Sub

            statValues = stPos
            statFlags = edPos + 1
            Dflds = (edPos - stPos)
            dtF = DateAndTime.Day(dateFrom.Text) & "/" & DateAndTime.Month(dateFrom.Text) & "/" & DateAndTime.Year(dateFrom.Text)
            dtT = DateAndTime.Day(dateTo.Text) & "/" & DateAndTime.Month(dateTo.Text) & "/" & DateAndTime.Year(dateTo.Text)

            Select Case elmstruc
                Case "Vertical"

                    Save_Verticals(Dflds, statValues, statFlags, dtF, dtT)

                Case "Horizontal"
                    'MsgBox(edPos - stPos & " " & elmstruc)
                    Save_Horizontals(Dflds, statValues, statFlags, dtF, dtT)
            End Select

            FileClose(101)

        Catch ex As Exception
            FileClose(101)
            MsgBox(ex.Message & " at btnSave")
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub

    Private Sub cmbstation_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbstation.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmdSelectAllStations.Enabled = True
            add_Station(cmbstation.Text)
        End If
    End Sub

    Sub add_Station(id As String)
        Dim str(2) As String
        Dim itm = New ListViewItem

        Try
            sql = "Select stationId, stationName FROM station WHERE stationId= '" & id & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "station")

            maxRows = (ds.Tables("station").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbstation.Text = ""
                cmbstation.BackColor = Color.White
            Else
                cmbstation.BackColor = Color.Red
                Exit Sub
            End If

            str(0) = ds.Tables("station").Rows(0).Item("stationId")
            str(1) = ds.Tables("station").Rows(0).Item("stationName")

            itm = New ListViewItem(str)

            ItmExist = False
            If lstvStations.Items.Count = 0 Then ' Alawys add the first selected item 
                lstvStations.Items.Add(itm)
            Else
                For j = 0 To lstvStations.Items.Count - 1
                    ' Check if the item has been added in the list and skip it if so
                    If str(0) = lstvStations.Items(j).Text Then
                        ItmExist = True
                        Exit For
                    End If
                Next
                If Not ItmExist Then lstvStations.Items.Add(itm)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function Frmdetails(tbl As String, ByRef stat As Integer, ByRef ed As Integer, ByRef struc As String) As Boolean
        'Dim conf As New MySql.Data.MySqlClient.MySqlConnection
        'Dim daf As MySql.Data.MySqlClient.MySqlDataAdapter
        'Dim dsf As New DataSet

        Try

            'conn.ConnectionString = MyConnectionString
            conn.Open()

            sql = "SELECT TABLE_NAME AS Tname,val_start_position AS startPos,val_end_position AS endPos, elem_code_location AS Estruct FROM data_forms WHERE TABLE_NAME = '" & tbl & "';"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "forms")

            conn.Close()
            With ds.Tables("forms")
                If .Rows.Count <> 1 Then Return False
                stat = .Rows(0).Item("startPos")
                ed = .Rows(0).Item("endPos")
                struc = .Rows(0).Item("Estruct")
            End With

            Return True
        Catch ex As Exception
            conn.Close()
            Return False
        End Try
    End Function

    Function scaled(Ecode As Integer, ByRef sclfactor As String) As Boolean
        'Dim conf As New MySql.Data.MySqlClient.MySqlConnection
        Dim daf As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsf As New DataSet

        Try
            conn.Open()
            sql = "SELECT elementScale FROM obselement WHERE elementId = " & Ecode & ";"
            'MsgBox(sql)
            daf = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            dsf.Clear()
            daf.Fill(dsf, "elements")
            conn.Close()

            With dsf.Tables("elements")
                If .Rows.Count = 0 Or Not IsNumeric(.Rows(0).Item(0)) Then Return False
                sclfactor = .Rows(0).Item(0)
            End With

            Return True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message & " at ScaledValue")
            Return False
        End Try
    End Function

    Sub Save_Verticals(Vfields As Integer, statValues As Integer, statFlags As Integer, dF As String, dT As String)
        Dim Ecode, yy, mm, dd As Integer
        Dim rec, dat, fl1, hdr, obsv, scleFactr, ddate As String
        'Dflds = (edPos - stPos)

        If Vfields = 11 Then
            Save_Monthly(Vfields, statValues, statFlags, dF, dT)
            Exit Sub
        End If

        fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & dsSourceTableName & "_data.csv"

        Try
            FileOpen(101, fl1, OpenMode.Output)

            conn.Open()

            sql = "SELECT * FROM " & dsSourceTableName & " WHERE(stationId = " & stnlist & ") And (elementId = " & elmlist & ");"
            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "frmRecs")
            conn.Close()

            With ds.Tables("frmRecs")

                If .Rows.Count = 0 Then
                    FileClose(101)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor
                If Vfields = 30 Then
                    'hdr = .Columns(0).ColumnName & "," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & "," & "dd" & "," & "Value" & "," & "Flag"
                    hdr = .Columns(0).ColumnName & "," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & ",dd," & .Columns(4).ColumnName & "," & "Value" & "," & "Flag"
                ElseIf Vfields = 23 Then
                    hdr = .Columns(0).ColumnName & "," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & "," & .Columns(4).ColumnName & "," & "hh" & "," & "Value" & "," & "Flag"
                    'ElseIf Vfields = 11 Then
                    '    Save_Monthly(Vfields, statValues, statFlags, dF, dT)
                    '    Exit Sub
                Else
                    Exit Sub
                End If

                PrintLine(101, hdr)
                For j = 0 To .Rows.Count - 1
                    yy = .Rows(j).Item(2)
                    mm = .Rows(j).Item(3)
                    rec = .Rows(j).Item(0) & "," & .Rows(j).Item(1) & "," & .Rows(j).Item(2) & "," & .Rows(j).Item(3)

                    If Vfields = 23 Then
                        dd = .Rows(j).Item(4)
                        rec = .Rows(j).Item(0) & "," & .Rows(j).Item(1) & "," & .Rows(j).Item(2) & "," & .Rows(j).Item(3) & "," & .Rows(j).Item(4)
                    End If

                    Ecode = .Rows(j).Item("elementId")

                    scleFactr = 1
                    scaled(Ecode, scleFactr)
                    For i = 0 To Vfields

                        If Vfields = 30 Then dd = i + 1

                        ddate = dd & "/" & mm & "/" & yy

                        If Not IsDate(ddate) Then
                                Exit For
                            End If

                            If DateValue(ddate) >= dF And DateValue(ddate) <= dT Then
                            'If Not IsDBNull(.Rows(j).Item(statValues + i)) Then
                            '    obsv = Val(.Rows(j).Item(statValues + i)) * scleFactr
                            'ElseIf IsDBNull(.Rows(j).Item(statValues + i)) And Not IsDBNull(.Rows(j).Item(statFlags + i)) Then
                            '    obsv = ""
                            'Else
                            '    Continue For
                            'End If

                            If IsNumeric(.Rows(j).Item(statValues + i)) Then
                                obsv = Val(.Rows(j).Item(statValues + i)) * scleFactr
                            Else
                                obsv = ""
                            End If

                            dat = rec & "," & i + 1 & "," & .Rows(j).Item(4) & "," & obsv & "," & .Rows(j).Item(statFlags + i)
                            If Vfields = 23 Then dat = rec & "," & i & "," & obsv & "," & .Rows(j).Item(statFlags + i)
                            'If Vfields = 11 Then dat = rec & "," & i & "," & obsv & "," & .Rows(j).Item(statFlags + i)

                            PrintLine(101, dat)
                        End If
                    Next
                Next

                FileClose(101)
                Me.Cursor = Cursors.Default
                CommonModules.ViewFile(fl1)

            End With

        Catch ex As Exception
            FileClose(101)
        conn.Close()
        If ex.HResult = -2147467259 Then
            MsgBox("Check Selections made")
            Exit Sub
        End If
        MsgBox(ex.Message & " at Save_Horizontals")
        End Try

    End Sub

    Sub Save_Horizontals(Vfields As Integer, statValues As Integer, statFlags As Integer, dF As String, dT As String)
        Dim Ecode, yy, mm, dd, hh As Integer
        Dim dat, fl1, hdr, obsv, scleFactr, ddate As String

        Try
            If dsSourceTableName = "form_hourlywind" Then
                Save_hourlywind(Vfields, statValues, statFlags, dF, dT)
                Exit Sub
            End If

            fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & dsSourceTableName & "_data.csv"

            FileOpen(101, fl1, OpenMode.Output)

            conn.Open()

            sql = "Select * FROM " & dsSourceTableName & " WHERE (stationId = " & stnlist & ");"
            'MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "frmRecs")
            conn.Close()

            With ds.Tables("frmRecs")

                If .Rows.Count = 0 Then
                    FileClose(101)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor

                If .Columns(4).ColumnName = "hh" Then
                    hdr = .Columns(0).ColumnName & ",elementId," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & "," & .Columns(4).ColumnName & ",Value,Flag"
                Else
                    hdr = .Columns(0).ColumnName & ",elementId," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & ",Value,Flag"
                End If

                If .Columns(5).ColumnName = "levelName" Then hdr = .Columns(0).ColumnName & ",elementId," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & "," & .Columns(4).ColumnName & ",Level,Value,Flag"

                'MsgBox(hdr)

                PrintLine(101, hdr)

                For j = 0 To .Rows.Count - 1
                    yy = .Rows(j).Item("yyyy")
                    mm = .Rows(j).Item("mm")
                    dd = .Rows(j).Item("dd")
                    'hh = .Rows(j).Item("hh")

                    ddate = dd & "/" & mm & "/" & yy

                    If Not IsDate(ddate) Then
                        Continue For
                    End If

                    For i = 0 To Vfields
                        scleFactr = 1
                        Ecode = Strings.Right(.Columns(statValues + i).ColumnName, 3)
                        If Not scaled(Ecode, scleFactr) Then Continue For

                        If DateValue(ddate) >= dF And DateValue(ddate) <= dT Then
                            If IsNumeric(.Rows(j).Item(statValues + i)) Then
                                obsv = Val(.Rows(j).Item(statValues + i)) * scleFactr
                            Else
                                obsv = ""
                            End If

                            If .Columns(4).ColumnName = "hh" Then
                                dat = .Rows(j).Item(0) & "," & Ecode & "," & yy & "," & mm & "," & dd & "," & .Rows(j).Item(4) & "," & obsv & "," & .Rows(j).Item(statFlags + i)
                            Else
                                dat = .Rows(j).Item(0) & "," & Ecode & "," & yy & "," & mm & "," & dd & "," & obsv & "," & .Rows(j).Item(statFlags + i)
                            End If

                            If .Columns(5).ColumnName = "levelName" Then dat = .Rows(j).Item(0) & "," & Ecode & "," & yy & "," & mm & "," & dd & "," & .Rows(j).Item(4) & "," & .Rows(j).Item(5) & "," & obsv & "," & .Rows(j).Item(statFlags + i)

                            PrintLine(101, dat)
                                'MsgBox(dat)
                            End If
                    Next
                Next
                FileClose(101)
                Me.Cursor = Cursors.Default
                CommonModules.ViewFile(fl1)

                'MsgBox("Finished")

            End With

        Catch ex As Exception
            FileClose(101)
            conn.Close()
            If ex.HResult = -2147467259 Then
                MsgBox("Check Selections made")
                Exit Sub
            End If
            MsgBox(ex.Message & " at Save_Horizontals")
        End Try

    End Sub

    Sub Save_hourlywind(Vfields As Integer, statValues As Integer, statFlags As Integer, dF As String, dT As String)
        Dim Ecode1, Ecode2, yy, mm, dd As Integer
        Dim dat, fl1, hdr, wdir, wspd, scleFactr1, scleFactr2, ddate As String

        Try

            fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & dsSourceTableName & "_data.csv"

            FileOpen(101, fl1, OpenMode.Output)

            conn.Open()

            sql = "Select * FROM " & dsSourceTableName & " WHERE (stationId = " & stnlist & ");"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "frmRecs")
            conn.Close()

            With ds.Tables("frmRecs")

                If .Rows.Count = 0 Then
                    FileClose(101)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor

                hdr = .Columns(0).ColumnName & "," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & "," & .Columns(3).ColumnName & ",hh,DIR,SPD,Flag"

                PrintLine(101, hdr)

                For j = 0 To .Rows.Count - 1
                    yy = .Rows(j).Item("yyyy")
                    mm = .Rows(j).Item("mm")
                    dd = .Rows(j).Item("dd")

                    ddate = dd & "/" & mm & "/" & yy

                    If Not IsDate(ddate) Then
                        Continue For
                    End If

                    For i = 0 To Vfields
                        scleFactr1 = 1
                        scleFactr2 = 1

                        Ecode1 = Strings.Mid(.Columns(statValues + i).ColumnName, 6, 3)
                        Ecode2 = Strings.Mid(.Columns(statValues + 48 + i).ColumnName, 6, 3)

                        If Not scaled(Ecode1, scleFactr1) Or Not scaled(Ecode2, scleFactr2) Then Continue For

                        If DateValue(ddate) >= dF And DateValue(ddate) <= dT Then

                            ' Scaling for the wind direction values
                            If IsNumeric(.Rows(j).Item(statValues + i)) Then
                                wdir = Val(.Rows(j).Item(statValues + i)) * scleFactr1
                            Else
                                wdir = ""
                            End If

                            ' Scaling for the wind speed values
                            If IsNumeric(.Rows(j).Item(statValues + 48 + i)) Then
                                wspd = Val(.Rows(j).Item(statValues + 48 + i)) * scleFactr2
                            Else
                                wspd = ""
                            End If

                            dat = .Rows(j).Item(0) & "," & yy & "," & mm & "," & dd & "," & i & "," & wdir & "," & wspd & "," & .Rows(j).Item(statFlags + i)

                            PrintLine(101, dat)

                        End If
                    Next
                Next
                FileClose(101)
                Me.Cursor = Cursors.Default
                CommonModules.ViewFile(fl1)

            End With

        Catch ex As Exception
            FileClose(101)
            conn.Close()
            If ex.HResult = -2147467259 Then
                MsgBox("Check Selections made")
                Exit Sub
            End If
            MsgBox(ex.Message & " at Save_hourlywind")
        End Try


    End Sub

    Sub Save_Monthly(Vfields As Integer, statValues As Integer, statFlags As Integer, dF As String, dT As String)
        Dim Ecode, yy As Integer
        Dim rec, dat, fl1, hdr, obsv, scleFactr As String
        'Dflds = (edPos - stPos)

        fl1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\" & dsSourceTableName & "_data.csv"

        Try
            FileOpen(101, fl1, OpenMode.Output)

            conn.Open()

            sql = "SELECT * FROM " & dsSourceTableName & " WHERE(stationId = " & stnlist & ") And (elementId = " & elmlist & ");"
            MsgBox(sql)
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "frmRecs")
            conn.Close()

            With ds.Tables("frmRecs")

                If .Rows.Count = 0 Then
                    FileClose(101)
                    Exit Sub
                End If

                Me.Cursor = Cursors.WaitCursor

                hdr = .Columns(0).ColumnName & "," & .Columns(1).ColumnName & "," & .Columns(2).ColumnName & ",mm,Value,Flag,Period"


                PrintLine(101, hdr)
                For j = 0 To .Rows.Count - 1
                    yy = .Rows(j).Item(2)
                    rec = .Rows(j).Item(0) & "," & .Rows(j).Item(1) & "," & .Rows(j).Item(2)

                    Ecode = .Rows(j).Item("elementId")

                    scleFactr = 1
                    scaled(Ecode, scleFactr)
                    For i = 0 To Vfields

                        If yy >= DateAndTime.Year(dF) And yy <= DateAndTime.Year(dT) Then

                            If IsNumeric(.Rows(j).Item(statValues + i)) Then
                                obsv = Val(.Rows(j).Item(statValues + i)) * scleFactr
                            Else
                                obsv = ""
                            End If

                            dat = rec & "," & i + 1 & "," & obsv & "," & .Rows(j).Item(statFlags + i) & "," & .Rows(j).Item(statValues + 24 + i)

                            PrintLine(101, dat)
                        End If
                    Next
                Next

                FileClose(101)
                Me.Cursor = Cursors.Default
                CommonModules.ViewFile(fl1)

            End With

        Catch ex As Exception
            FileClose(101)
            conn.Close()
            If ex.HResult = -2147467259 Then
                MsgBox("Check Selections made")
                Exit Sub
            End If
            MsgBox(ex.Message & " at Save_Monthly")
        End Try

    End Sub
    Private Sub cmbElement_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbElement.KeyPress
        If Asc(e.KeyChar) = 13 Then add_Element(cmbElement.Text)
    End Sub

    Sub add_Element(id As String)
        Dim str(3) As String
        Dim itm = New ListViewItem

        Try

            sql = "Select elementId, abbreviation, description FROM obselement WHERE selected = '1' and elementId = '" & id & "';"

            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.Fill(ds, "obselement")

            maxRows = (ds.Tables("obselement").Rows.Count)
            'MsgBox(maxRows)
            If maxRows > 0 Then
                cmbElement.Text = ""
                cmbElement.BackColor = Color.White
            Else
                cmbElement.BackColor = Color.Red
                Exit Sub
            End If

            'For kount = 0 To maxRows - 1 Step 1

            str(0) = ds.Tables("obselement").Rows(0).Item("elementId")
            str(1) = ds.Tables("obselement").Rows(0).Item("abbreviation")
            str(2) = ds.Tables("obselement").Rows(0).Item("description")

            itm = New ListViewItem(str)

            ItmExist = False
            If lstvElements.Items.Count = 0 Then ' Alawys add the first selected item 
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
            'Next
        Catch err As Exception
            MsgBox(err.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub
End Class