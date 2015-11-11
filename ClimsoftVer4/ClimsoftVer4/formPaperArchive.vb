Public Class formPaperArchive
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim FileNm As String


    Private Sub cmdcloses_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    'Private Sub cmdFolder_Click(sender As Object, e As EventArgs)
    '    Dim fld As String
    '    folderPaperArchive.ShowDialog()
    '    txtSelectedFolder.Text = folderPaperArchive.SelectedPath
    '    fld = txtSelectedFolder.Text
    '    ListFiles(fld)
    'End Sub
    Sub ListFiles(flds As String)

        Try
            ' Declare and assign folder variables
            Dim f1 As New IO.DirectoryInfo(flds)
            Dim d1 As IO.FileInfo() = f1.GetFiles()
            Dim da1 As IO.FileInfo
            Dim fls As String

            lstvFiles.Columns.Add("Files", 500, HorizontalAlignment.Left)
            'list the names of all files in the specified directory
            For Each da1 In d1
                fls = da1.Name
                'listImages.Items.Add(da1)
                lstvFiles.Items.Add(fls)
            Next

            FilesListSatus(True)
        Catch ex As Exception
            ' MsgBox("the connection to the database failed ")
            MsgBox(ex.Message)
        End Try
        'chkFiles.Text = "Unselect All"
        'To filter search change f1.GetFiles() to di.GetFiles(“.extionsion”)
    End Sub


    Private Sub cmdFolder_Click_1(sender As Object, e As EventArgs) Handles cmdFolder.Click
        Dim fld As String
        folderPaperArchive.ShowDialog()
        txtSelectedFolder.Text = folderPaperArchive.SelectedPath
        fld = txtSelectedFolder.Text

        lstvFiles.Clear()
        ListFiles(fld)
    End Sub

    Private Sub chkFiles_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiles.CheckedChanged
        If chkFiles.CheckState = False Then
            FilesListSatus(False)
            chkFiles.Text = "Select All"
            'cmdArchive.Enabled = False
        Else
            chkFiles.Visible = True
            FilesListSatus(True)
            chkFiles.Text = "UnSelect All"
            cmdArchive.Enabled = True
        End If
    End Sub
    Sub FilesListSatus(sts As Boolean)
        If lstvFiles.Items.Count > 0 Then
            cmdArchive.Enabled = True
            chkFiles.Visible = True
        Else
            cmdArchive.Enabled = False
            chkFiles.Visible = False
            Exit Sub
        End If

        For i = 0 To lstvFiles.Items.Count - 1
            lstvFiles.Items(i).Checked = sts
        Next
    End Sub

    Private Sub cmdArchive_Click(sender As Object, e As EventArgs) Handles cmdArchive.Click
        Dim imgFile As String
        Try

            'Craete the images folder if it does not exist
            If Not IO.Directory.Exists("c:\images") Then
                IO.Directory.CreateDirectory("c:\images")
            End If

            For i = 0 To lstvFiles.Items.Count - 1
                imgFile = txtSelectedFolder.Text & "\" & lstvFiles.Items(i).Text
                If lstvFiles.Items(i).Checked Then
                    IO.File.Copy(imgFile, "c:\images\" & lstvFiles.Items(i).Text, True)
                    UpdateArchive(txtSelectedFolder.Text, lstvFiles.Items(i).Text)
                End If
            Next
            MsgBox("Archiving Completed")
        Catch ex As Exception
            ' MsgBox("the connection to the database failed ")
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub UpdateArchive(FilePth As String, FileNm As String)
        Dim siz, count, i As Integer
        Dim imgfile, str, stn, frm, yy, mm, dd, hh, dt, datetim As String

        imgfile = FilePth & "\" & FileNm
       
        siz = Len(FileNm)
        count = 0
        str = ""
        stn = ""
        frm = ""
        datetim = ""
        i = 1
        For i = 1 To siz
            str = str & Mid(FileNm, i, 1)
            If Mid(FileNm, i, 1) = "-" Then
                count = count + 1
                'Construct StationId string
                If count = 1 Then
                    stn = Mid(str, 1, Len(str) - 1)
                    'MsgBox(stn)
                    str = ""
                End If
                'Construct FormCode string
                If count = 2 Then
                    frm = Mid(str, 1, Len(str) - 1)
                    'MsgBox(frm)
                    str = ""
                End If
            End If
            'Construct datetime string
            If Mid(FileNm, i, 1) = "." Then
                dt = Mid(str, 1, Len(str) - 1)
                'MsgBox(dt)
                yy = Mid(dt, 1, 4)
                mm = Mid(dt, 5, 2)
                dd = Mid(dt, 7, 2)
                hh = Mid(dt, 9, 2)
                datetim = yy & "/" & mm & "/" & dd & " " & hh & ":00:00"
                'MsgBox(datetim)
                If IsDate(datetim) Then
                    'ArchiveRecord(stn, frm, yy, mm, dd, hh, imgfile)
                    ArchiveRecord(stn, frm, datetim, imgfile)
                Else
                    MsgBox("Incorrect Datetime Structure")
                End If
                Exit For
            End If
        Next

    End Sub

    Private Sub MenuPaperArchive_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuPaperArchive.ItemClicked

    End Sub

    Sub ArchiveRecord(stn As String, frm As String, frmdatetime As Date, img As String)
        On Error GoTo Err
        'On Error Resume Next

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow

        'sql = "SELECT * FROM paperarchive"
        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        'da.Fill(ds, "paperarchive")

        'MsgBox(ds.Tables("paperarchive").Rows.Count)
        'MsgBox(stn & " " & frm & " " & frmdatetime & " " & img)

        'MsgBox(stn)

        Dim recCommit As New dataEntryGlobalRoutines
        dsNewRow = ds.Tables("paperarchive").NewRow

        dsNewRow.Item("belongsTo") = stn
        dsNewRow.Item("formDatetime") = frmdatetime
        dsNewRow.Item("image") = img
        dsNewRow.Item("classifiedInto") = frm

        'dsNewRow.Item("year") = yr
        'dsNewRow.Item("month") = mn
        'dsNewRow.Item("day") = dy
        'dsNewRow.Item("hour") = hr
        'dsNewRow.Item("image") = img

        'Add a new record to the data source table
        ds.Tables("paperarchive").Rows.Add(dsNewRow)
        da.Update(ds, "paperarchive")
        'MsgBox("Record Archived")
        Exit Sub
Err:
        MsgBox(Err.Number & " : " & Err.Description)

    End Sub

    Private Sub formPaperArchive_Load(sender As Object, e As EventArgs) Handles Me.Load

        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        'sql = "SELECT * FROM paperarchive"
        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        'da.Fill(ds, "paperarchive")

        FillList(txtStationArchive, "station", "stationId")
        FillList(txtStation, "station", "stationId")
        FillList(txtForm, "paperarchivedefinition", "formId")
        FillList(txtFormId, "paperarchivedefinition", "formId")

        sql = "SELECT * FROM paperarchive"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        da.Fill(ds, "paperarchive")

    End Sub

    '    Private Sub cmdView_Click(sender As Object, e As EventArgs)
    '        On Error GoTo Err
    '        Dim stn, frm, imgfl, img As String
    '        Dim num, mxrows As Integer

    '        imgfl = txtStation.Text & "-" & txtForm.Text & "-" & txtYY.Text & Format(Val(txtMM.Text), "00") & Format(Val(txtDD.Text), "00") & Format(Val(txtHH.Text), "00")
    '        mxrows = ds.Tables("paperarchive").Rows.Count

    '        For num = 0 To mxrows
    '            stn = ds.Tables("paperarchive").Rows(num).Item("belongsTo")
    '            frm = ds.Tables("paperarchive").Rows(num).Item("classifiedInto")
    '            img = ds.Tables("paperarchive").Rows(num).Item("image")
    '            If InStr(img, imgfl) > 0 Then
    '                ShowImage(img)
    '                Exit For
    '            End If
    '        Next
    '        Exit Sub
    'Err:
    '        If Err.Number = 9 Then
    '            MsgBox("No Archived Image found")
    '            Exit Sub
    '        End If
    '        MsgBox(Err.Number & ": " & Err.Description)
    '    End Sub
    Sub ShowImage(img As String)
        System.Diagnostics.Process.Start(img)
    End Sub

    Private Sub cmdImageFile_Click(sender As Object, e As EventArgs) Handles cmdImageFile.Click
        Dim img As String

        OpenFilePaperArchive.ShowDialog()
        img = OpenFilePaperArchive.FileName
        txtImageFile.Text = img
        'dir = IO.Directory.GetParent(txtImageFile.Text).FullName
        'fld = Len(dir)
        'MsgBox(Mid(txtImageFile.Text, fld + 2, Len(txtImageFile.Text) - fld + 1))
        'xt = InStr(txtImageFile.Text, ".")
        'ext = Mid(txtImageFile.Text, xt + 1, Len(txtImageFile.Text) - 1)

        'FileNm = dir & "\" & txtStationArchive.Text & "-" & txtFormId.Text & "-" & Format(Val(txtYear.Text), "00") & Format(Val(txtMonth.Text), "00") _
        '    & Format(Val(txtDay.Text), "00") & Format(Val(txtHour.Text), "00") & "." & ext

        'y = Format(Val(txtYear.Text), "00")
        'm = Format(Val(txtDay.Text), "00")
        'd = Format(Val(txtMonth.Text), "00")
        'h = Format(Val(txtHour.Text), "00")
        'MsgBox(y & m & d & h)
    End Sub


    Private Sub cmdArchiveUnstructure_Click(sender As Object, e As EventArgs) Handles cmdArchiveUnstructure.Click
        Dim dir, ext As String
        Dim fld, xt As Integer
        Dim stn, frm, y, m, d, h As String
        Dim frmdatetime As Date

        On Error GoTo Err
        'Craete the images folder if it does not exist
        If Not IO.Directory.Exists("c:\images") Then
            IO.Directory.CreateDirectory("c:\images")
        End If

        Dir = IO.Directory.GetParent(txtImageFile.Text).FullName
        fld = Len(Dir)
        xt = InStr(txtImageFile.Text, ".")
        ext = Mid(txtImageFile.Text, xt + 1, Len(txtImageFile.Text) - 1)

        FileNm = txtStationArchive.Text & "-" & txtFormId.Text & "-" & Format(Val(txtYear.Text), "00") & Format(Val(txtMonth.Text), "00") _
            & Format(Val(txtDay.Text), "00") & Format(Val(txtHour.Text), "00") & "." & ext

        stn = txtStationArchive.Text
        frm = txtFormId.Text

        y = txtYear.Text
        m = Format(Val(txtDay.Text), "00")
        d = Format(Val(txtMonth.Text), "00")
        h = Format(Val(txtHour.Text), "00")
        frmdatetime = y & "-" & m & "-" & d & " " & h & ":00:00"

        If IsDate(frmdatetime) Then
            IO.File.Copy(txtImageFile.Text, "c:\images\" & FileNm, True)
            ArchiveRecord(stn, frm, frmdatetime, "c:\images\" & FileNm)
        Else
            MsgBox("Can't Archive Image. Invalid Datetime value")
        End If
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub
    Sub FillList(ByRef lst As ComboBox, tbl As String, idxfld As String)
        Dim dstn As New DataSet
        Dim sql As String

        On Error GoTo Err

        sql = "SELECT * FROM  " & tbl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            dstn.Clear()
            da.Fill(dstn, tbl)

            For i = 0 To dstn.Tables(tbl).Rows.Count - 1
                lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(idxfld))
            Next
        Exit Sub
Err:
        MsgBox(Err.Description)
    End Sub

    Private Sub tabImageArchives_Click(sender As Object, e As EventArgs) Handles tabImageArchives.Click

        If tabImageArchives.SelectedIndex = 2 Then

            sql = "SELECT * FROM  paperarchive"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            da.Fill(ds, "paperarchive")

            rec = 0
            Kount = ds.Tables("paperarchive").Rows.Count

            ViewImage(rec)

        End If

    End Sub

    Private Sub txtDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDay.SelectedIndexChanged

    End Sub

    Private Sub TabViewArchive_Click(sender As Object, e As EventArgs) Handles TabViewArchive.Click

    End Sub


    Private Sub cmdView_Click(sender As Object, e As EventArgs) Handles cmdView.Click
        On Error GoTo Err
        Dim stn, frm, imgfl, img As String
        Dim num, mxrows As Integer

        imgfl = txtStation.Text & "-" & txtForm.Text & "-" & txtYY.Text & Format(Val(txtMM.Text), "00") & Format(Val(txtDD.Text), "00") & Format(Val(txtHH.Text), "00")
        mxrows = ds.Tables("paperarchive").Rows.Count

        For num = 0 To mxrows
            stn = ds.Tables("paperarchive").Rows(num).Item("belongsTo")
            frm = ds.Tables("paperarchive").Rows(num).Item("classifiedInto")
            img = ds.Tables("paperarchive").Rows(num).Item("image")
            If InStr(img, imgfl) > 0 Then
                ShowImage(img)
                Exit For
            End If
        Next
        Exit Sub
Err:
        If Err.Number = 9 Then
            MsgBox("No Archived Image found")
            Exit Sub
        End If
        MsgBox(Err.Number & ": " & Err.Description)
    End Sub

    Private Sub cmdleft_Click(sender As Object, e As EventArgs) Handles cmdleft.Click

        If rec > 0 Then
            rec = rec - 1
            ViewImage(rec)
        End If
    End Sub
    Sub ViewImage(num As Integer)
        On Error GoTo Err

        txtStation.Text = ds.Tables("paperarchive").Rows(num).Item("belongsTo")
        txtForm.Text = ds.Tables("paperarchive").Rows(num).Item("classifiedInto")
        txtYY.Text = Year(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))
        txtMM.Text = Month(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))
        txtDD.Text = Strings.Left(ds.Tables("paperarchive").Rows(num).Item("formDatetime"), 2)
        txtHH.Text = Hour(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))

        txtRec.Text = rec + 1 & " of " & Kount
        Exit Sub
Err:
        MsgBox(Err.Number & ": " & Err.Description)
    End Sub

    Private Sub cmdright_Click(sender As Object, e As EventArgs) Handles cmdright.Click
        If rec < Kount - 1 Then
            rec = rec + 1
            ViewImage(rec)
        End If
    End Sub

    Private Sub cmdfirst_Click(sender As Object, e As EventArgs) Handles cmdfirst.Click
        rec = 0
        ViewImage(rec)
    End Sub

    Private Sub cmdlast_Click(sender As Object, e As EventArgs) Handles cmdlast.Click
        rec = Kount - 1
        ViewImage(rec)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub


End Class