Public Class formPaperArchive
    Dim dbconn As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConnectionString As String
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim rec As Integer
    Dim Kount As Integer
    Dim FileNm As String
    Dim SelectedTab As Integer


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
            lstvFiles.Clear()

            lstvFiles.Columns.Add("Files", 500, HorizontalAlignment.Left)
            'list the names of all files in the specified directory
            For Each da1 In d1
                fls = da1.Name
                'listImages.Items.Add(da1)
                If InStr("jpgpngtifgifbmpemfpdf", Strings.LCase((Strings.Right(fls, 3)))) > 0 Then lstvFiles.Items.Add(fls)
            Next

            If lstvFiles.Items.Count > 0 Then
                FilesListSatus(True)
                chkFiles.Visible = True
            Else
                chkFiles.Visible = False
            End If
            'chkFiles.Text = "Unselect All"
            'To filter search change f1.GetFiles() to di.GetFiles(“.extionsion”)

        Catch ex As Exception
            MsgBox(ex.Message)
            chkFiles.Visible = False
        End Try

    End Sub


    Private Sub cmdFolder_Click(sender As Object, e As EventArgs) Handles cmdFolder.Click
        Dim fld As String
        ' Set busy Cursor pointer
        Me.Cursor = Cursors.WaitCursor
        folderPaperArchive.ShowDialog()
        txtSelectedFolder.Text = folderPaperArchive.SelectedPath
        fld = txtSelectedFolder.Text

        'lstvFiles.Clear()
        'ListFiles(fld)
        Me.Cursor = Cursors.Default
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
        Dim imgFile, imageFolder As String

        ' Set busy Cursor pointer
        Me.Cursor = Cursors.WaitCursor

        Try

            'Create the images folder if it does not exist
            imageFolder = lblArhiveFolder.Text
            If Not IO.Directory.Exists(imageFolder) Then
                IO.Directory.CreateDirectory(imageFolder)
            End If
            'MsgBox(imageFolder)
            lstMessages.Items.Clear()
            For i = 0 To lstvFiles.Items.Count - 1
                imgFile = txtSelectedFolder.Text & "\" & lstvFiles.Items(i).Text
                If lstvFiles.Items(i).Checked Then
                    IO.File.Copy(imgFile, imageFolder & "\" & lstvFiles.Items(i).Text, True)
                    'MsgBox(txtSelectedFolder.Text & " " & lstvFiles.Items(i).Text)
                    If UpdateArchive(lblArhiveFolder.Text, lstvFiles.Items(i).Text) Then lstMessages.Items.Add(lstvFiles.Items(i).Text & " " & "Archived")
                End If

            Next
            'MsgBox("Archiving Completed")
            'lstMessages.Items.Add("Archiving Completed")
        Catch ex As Exception
            'MsgBox(ex.Message)
            lstMessages.Items.Add(ex.Message)
            ' Set busy Cursor pointer
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Function UpdateArchive(FilePth As String, FileNm As String) As Boolean
        Dim siz, count, i As Integer
        Dim imgfile, str, stn, frm, yy, mm, dd, hh, dt, datetim As String
        UpdateArchive = True
        Try
            imgfile = FilePth & "\" & FileNm
            'MsgBox(imgfile)
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
                        If Not ArchiveRecord(stn, frm, datetim, imgfile) Then UpdateArchive = False
                    Else
                        'MsgBox("Incorrect Datetime Structure")
                        lstMessages.Items.Add(FileNm & " Incorrect Datetime Structure. Not archived ")
                        UpdateArchive = False
                    End If
                    Exit For
                End If
            Next
        Catch ex As Exception
            lstMessages.Items.Add(ex.Message)
            UpdateArchive = False
        End Try
    End Function


    Function ArchiveRecord(stn As String, frm As String, frmdatetime As Date, img As String) As Boolean
        'On Error GoTo Err
        'On Error Resume Next

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow

        'sql = "SELECT * FROM paperarchive"
        'da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        'da.Fill(ds, "paperarchive")

        'MsgBox(ds.Tables("paperarchive").Rows.Count)
        'MsgBox(stn & " " & frm & " " & frmdatetime & " " & img)

        'MsgBox(stn)
        'MsgBox(img)
        ArchiveRecord = True
        Dim recCommit As New dataEntryGlobalRoutines
        Try
            dsNewRow = ds.Tables("paperarchive").NewRow

            dsNewRow.Item("belongsTo") = stn
            dsNewRow.Item("formDatetime") = frmdatetime
            dsNewRow.Item("image") = img
            dsNewRow.Item("classifiedInto") = frm

            'Add a new record to the data source table
            ds.Tables("paperarchive").Rows.Add(dsNewRow)
            da.Update(ds, "paperarchive")
            'MsgBox("Record Archived")
            'Exit Function
        Catch ex As Exception
            'MsgBox(Err.Number & " : " & Err.Description)
            lstMessages.Items.Add(ex.Message)
            ArchiveRecord = False
        End Try

    End Function

    Private Sub formPaperArchive_Click(sender As Object, e As EventArgs) Handles Me.Click
        Select Case tabImageArchives.TabIndex
            Case 0
                'MsgBox("Structured")
            Case 1
            Case 2

        End Select
    End Sub

    Private Sub formPaperArchive_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'MsgBox(e.KeyCode)
        If e.KeyCode = 13 Then My.Computer.Keyboard.SendKeys("{TAB}")

    End Sub

    Private Sub formPaperArchive_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub formPaperArchive_Load(sender As Object, e As EventArgs) Handles Me.Load

        dbConnectionString = frmLogin.txtusrpwd.Text
        dbconn.ConnectionString = dbConnectionString
        dbconn.Open()

        FillList(txtStationArchive, "station", "stationId")
        FillList(txtStation, "station", "stationId")
        FillList(txtForm, "paperarchivedefinition", "formId")
        FillList(txtFormId, "paperarchivedefinition", "formId")

        sql = "SELECT * FROM paperarchive"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        da.Fill(ds, "paperarchive")

        ' Get the image archiving folder
        Dim dar As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim dsr As New DataSet
        Dim regmax As Integer
        Dim appath As String
        Dim ImagesPath As String

        sql = "SELECT * FROM regkeys"
        dar = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dar.Fill(dsr, "regkeys")
        regmax = dsr.Tables("regkeys").Rows.Count

        ' Check for the settings for the image files archive folder and display the details to the user
        For i = 0 To regmax - 1
            If dsr.Tables("regkeys").Rows(i).Item("keyName") = "key12" Then
                If IsDBNull(dsr.Tables("regkeys").Rows(i).Item("keyValue")) Or dsr.Tables("regkeys").Rows(i).Item("keyValue") = "" Then
                    appath = IO.Directory.GetParent(Application.StartupPath).FullName
                    ImagesPath = IO.Directory.GetParent(appath).FullName
                    lblArhiveFolder.Text = ImagesPath & "\images"
                    lblArhiveFolder.ForeColor = Color.Red
                    lblArhiveFolder.Font.Bold.Equals(True)
                    txtDefaultFolder.Text = "Default folder for image archiving is being used. " & _
                                            "You may go to Tools -> General Settings and choose a convinient folder for good management of image files archiving"
                Else
                    lblArhiveFolder.Text = dsr.Tables("regkeys").Rows(i).Item("keyValue")
                End If
                Exit For
            End If
        Next


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
        'System.Diagnostics.Process.Start(img)
        CommonModules.ViewFile(img)
    End Sub

    Private Sub cmdImageFile_Click(sender As Object, e As EventArgs) Handles cmdImageFile.Click
        Dim img As String

        OpenFilePaperArchive.Filter = "Image files|*.jpg;*.emf;*.jpeg;*.gif;*.tif;*.bmp;*.png;*.pdf"
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
        Dim dir, ext, ImagesPath As String
        Dim fld, xt As Integer
        Dim stn, frm, y, m, d, h As String
        Dim frmdatetime As Date

        Me.Cursor = Cursors.WaitCursor
        Try

            ' Define Images Archiving path

            ImagesPath = lblArhiveFolder.Text
            'ImagesPath = ImagesPath & "\images"
            'MsgBox(ImagesPath)
            '    GetFullPath(Application.StartupPath) & "\data"

            If Not IO.Directory.Exists(ImagesPath) Then
                IO.Directory.CreateDirectory(ImagesPath)
            End If


            'Craete the images folder if it does not exist

            'If Not IO.Directory.Exists("c:\images") Then
            '    IO.Directory.CreateDirectory("c:\images")
            'End If

            dir = IO.Directory.GetParent(txtImageFile.Text).FullName
            fld = Len(dir)
            xt = InStr(txtImageFile.Text, ".")
            ext = Mid(txtImageFile.Text, xt + 1, Len(txtImageFile.Text) - 1)

            FileNm = txtStationArchive.Text & "-" & txtFormId.Text & "-" & Format(Val(txtYear.Text), "00") & Format(Val(txtMonth.Text), "00") _
                & Format(Val(txtDay.Text), "00") & Format(Val(txtHour.Text), "00") & "." & ext

            stn = txtStationArchive.Text
            frm = txtFormId.Text

            y = txtYear.Text
            m = Format(Val(txtMonth.Text), "00")
            d = Format(Val(txtDay.Text), "00")
            h = Format(Val(txtHour.Text), "00")
            frmdatetime = y & "-" & m & "-" & d & " " & h & ":00:00"

            If IsDate(frmdatetime) Then
                'IO.File.Copy(txtImageFile.Text, "c:\images\" & FileNm, True)
                IO.File.Copy(txtImageFile.Text, ImagesPath & "\" & FileNm, True)
                If ArchiveRecord(stn, frm, frmdatetime, ImagesPath & "\" & FileNm) Then
                    lblArchiveMsg.Text = FileNm & " Archived"
                    'Clear Form
                    txtImageFile.Text = ""
                    txtStationArchive.Text = ""
                    txtFormId.Text = ""
                    txtYear.Text = ""
                    txtMonth.Text = ""
                    txtDay.Text = ""
                    txtHour.Text = ""
                Else
                    lblArchiveMsg.Text = "Invalid Entries. Not archived"
                End If
                ' lstMessages.Items.Add(FileNm & " Archived")

            Else
                'MsgBox("Can't Archive Image. Invalid Datetime value")
                'lstMessages.Items.Add("Invalid Datetime value. Not archived")

                lblArchiveMsg.Text = "Invalid Datetime value. Not archived"
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
            'lstMessages.Items.Add(ex.Message)
            lblArchiveMsg.Text = ex.Message
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Sub FillList(ByRef lst As ComboBox, tbl As String, idxfld As String)
        Dim dstn As New DataSet
        Dim sql As String
        sql = "SELECT * FROM  " & tbl
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
        dstn.Clear()
        da.Fill(dstn, tbl)

        For i = 0 To dstn.Tables(tbl).Rows.Count - 1
            lst.Items.Add(dstn.Tables(tbl).Rows(i).Item(idxfld))
        Next
    End Sub

    Private Sub tabImageArchives_Click(sender As Object, e As EventArgs) Handles tabImageArchives.Click
        SelectedTab = tabImageArchives.SelectedIndex
        'MsgBox(SelectedTab)
        Select Case SelectedTab
            Case 0 ' Structured Image Filename
                txtSelectedFolder.Text = ""
                lstvFiles.Clear()
                PicForm.Visible = False
                lstMessages.Visible = True
                lblZoomout.Visible = False
                lblImageRotate.Visible = False
                lblMessages.Visible = True
            Case 1 ' Unstructured Image Filename
                'Clear Tab
                txtImageFile.Text = ""
                txtStationArchive.Text = ""
                txtFormId.Text = ""
                txtYear.Text = ""
                txtMonth.Text = ""
                txtDay.Text = ""
                txtHour.Text = ""
                lblZoomout.Visible = True
                lblImageRotate.Visible = True
                lblMessages.Visible = False
                PicForm.Visible = True
                lstMessages.Visible = False
                ' Set Image box to Nothing
                PicForm.ImageLocation = Nothing
                PicForm.Refresh()
            Case 2 ' Retrieve Archived Images
                ''Clear Tab
                'txtStation.Text = ""
                'txtForm.Text = ""
                'txtYY.Text = ""
                'txtMM.Text = ""
                'txtDD.Text = ""
                'txtHH.Text = ""
                lblZoomout.Visible = True
                lblImageRotate.Visible = True
                lblMessages.Visible = False
                PicForm.Visible = True
                lstMessages.Visible = False
                ' Set Image box to Nothing
                PicForm.ImageLocation = Nothing
                PicForm.Refresh()

                sql = "SELECT * FROM  paperarchive"
                da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
                ds.Clear()
                da.Fill(ds, "paperarchive")

                rec = 0
                Kount = ds.Tables("paperarchive").Rows.Count

                ViewImage(rec)
                'End If
            Case 3 ' View Archived Images List
                lblZoomout.Visible = True
                lblImageRotate.Visible = True
                lblMessages.Visible = False
                PicForm.Visible = True
                lstMessages.Visible = False
                ' Set Image box to Nothing
                PicForm.ImageLocation = Nothing
                PicForm.Refresh()
        End Select
    End Sub

    Private Sub txtDay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDay.SelectedIndexChanged

    End Sub

    Private Sub TabViewArchive_Click(sender As Object, e As EventArgs) Handles TabViewArchive.Click
        lstMessages.Items.Clear()

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
                If Strings.UCase(Strings.Right(img, 3)) = "PDF" Then
                    ShowImage(img)
                Else
                    PicForm.ImageLocation = img
                    PicForm.Refresh()
                End If
                ''ShowImage(img)
                'PicForm.ImageLocation = img
                'PicForm.Refresh()
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
        Try

            If Kount < 1 Then
                ResetForm()
                Exit Sub
            End If

            txtStation.Text = ds.Tables("paperarchive").Rows(num).Item("belongsTo")
            txtForm.Text = ds.Tables("paperarchive").Rows(num).Item("classifiedInto")
            txtYY.Text = DateAndTime.Year(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))
            txtMM.Text = DateAndTime.Month(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))
            txtDD.Text = DateAndTime.Day(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))
            txtHH.Text = DateAndTime.Hour(ds.Tables("paperarchive").Rows(num).Item("formDatetime"))

            txtRec.Text = rec + 1 & " of " & Kount
        Catch ex As Exception
            MsgBox(ex.HResult & ": " & ex.Message)
        End Try

    End Sub
    Sub ResetForm()
        txtStation.Text = ""
        txtForm.Text = ""
        txtYY.Text = ""
        txtMM.Text = ""
        txtDD.Text = ""
        txtHH.Text = ""

        txtRec.Text = ""

        txtRec.Text = 0 & " of " & 0
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



    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        lstMessages.Items.Clear()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Select Case tabImageArchives.SelectedIndex
            Case 0
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "structuredfiles.htm")
            Case 1
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "unstructuredfiles.htm")
            Case 2
                Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "viewimages.htm")
        End Select

    End Sub



    Private Sub cmdDeleteArchiveDef_Click(sender As Object, e As EventArgs) Handles cmdDeleteArchiveDef.Click

        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand
        Dim stn, dt, img, frm As String

        Try
            If PicForm.ImageLocation = "" Then
                MsgBox("Can't Delete. No Image Retrieved")
                Exit Sub
            End If
            sql = "SELECT * FROM paperarchive"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "paperarchive")

            If ds.Tables("paperarchive").Rows.Count = 0 Then ' Zero records. Nothing to delete
                MsgBox("Nothing to delete")
                Exit Sub
            End If

            If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                stn = ds.Tables("PaperArchive").Rows(rec).Item(0)
                dt = ds.Tables("PaperArchive").Rows(rec).Item(1)
                img = ds.Tables("PaperArchive").Rows(rec).Item(2)
                frm = ds.Tables("PaperArchive").Rows(rec).Item(3)

                ' Change date format to yyyy-mm-dd hh:mm:ss
                dt = DateAndTime.Year(dt) & "-" & DateAndTime.Month(dt) & "-" & DateAndTime.Day(dt) & Strings.Right(dt, 9)

                ' Change the path character to mysql format
                img = Strings.Replace(img, "\", "\\")

                comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
                sql0 = "DELETE FROM `paperarchive` WHERE  `belongsTo`='" & stn & "' AND `formDatetime`='" & dt & "' AND `image`='" & img & "' AND `classifiedInto`='" & frm & "' LIMIT 1;"
                MsgBox(sql0)
                comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
                comm.ExecuteNonQuery()   ' Execute the query

                ds.Clear()
                da.Fill(ds, "paperarchive")
                Kount = ds.Tables("paperarchive").Rows.Count
                If Kount > 0 Then
                    rec = 0
                    ViewImage(0)
                Else
                    ResetForm()
                End If
                ' Set Image location to nothin
                PicForm.ImageLocation = Nothing
                PicForm.Refresh()
            End If
        Catch ex As Exception
            MsgBox(ex.HResult & " " & ex.Message)
        End Try



        '    'Display message to show that delete operation has been cancelled
        '    recDelete.messageBoxOperationCancelled()
        '    Exit Sub
        'End If
        'Try
        '    'MsgBox(rec)
        '    MsgBox(ds.Tables("paperarchive").Rows(rec).Item(2))
        '    ds.Tables("paperarchive").Rows(rec).Delete()
        '    da.Update(ds, "paperarchive")
        '    Kount = Kount - 1
        '    'inc = 0

        '    ''Call subroutine for record navigation
        '    'navigateRecords()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'If DeleteRecord("paperarchive", rec) Then


        'End If

    End Sub

    Function DeleteRecord(tbl As String, recs As Integer) As Boolean

        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim recCommit As New dataEntryGlobalRoutines
        Dim sql0 As String
        Dim comm As New MySql.Data.MySqlClient.MySqlCommand
        Dim stn, dt, img, frm As String

        DeleteRecord = True
        Try
            sql = "SELECT * FROM " & tbl
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            da.Fill(ds, tbl)

            stn = ds.Tables("PaperArchive").Rows(rec).Item(0)
            dt = ds.Tables("PaperArchive").Rows(rec).Item(1)
            img = ds.Tables("PaperArchive").Rows(rec).Item(2)
            frm = ds.Tables("PaperArchive").Rows(rec).Item(3)

            ' Change date format to yyyy-mm-dd hh:mm:ss
            dt = DateAndTime.Year(dt) & "-" & DateAndTime.Month(dt) & "-" & DateAndTime.Day(dt) & Strings.Right(dt, 9)

            ' Change the path character to mysql format
            img = Strings.Replace(img, "\", "\\")

            comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable
            sql0 = "DELETE FROM `paperarchive` WHERE  `belongsTo`='" & stn & "' AND `formDatetime`='" & dt & "' AND `image`='" & img & "' AND `classifiedInto`='" & frm & "' LIMIT 1;"
            comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
            comm.ExecuteNonQuery()   ' Execute the query

        Catch ex As Exception
            MsgBox(ex.Message)
            DeleteRecord = False
        End Try

    End Function

    Function NewString(sourcestring As String, str1 As String) As String
        Dim num As Integer
        Dim c As String

        NewString = ""
        For num = 1 To Len(sourcestring)
            c = Mid(sourcestring, num, 1)
            NewString = NewString & c
            If c = str1 Then NewString = NewString & c
        Next

    End Function

    Private Sub cmdList_Click(sender As Object, e As EventArgs) Handles cmdList.Click

        lstArchival.Columns.Clear()
        dbconn.Close()

        Try
            dbconn.ConnectionString = frmLogin.txtusrpwd.Text
            dbconn.Open()
            lstArchival.Clear()
            sql = "SELECT * FROM paperarchive ORDER BY belongsTo"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, dbconn)
            ds.Clear()
            da.Fill(ds, "paperarchive")

            Kount = ds.Tables("paperarchive").Rows.Count
            ' Set headers for the list views 
            lstArchival.Columns.Add("StaionId", 70, HorizontalAlignment.Left)
            lstArchival.Columns.Add("FormId", 75, HorizontalAlignment.Left)
            lstArchival.Columns.Add("Form Datetime", 130, HorizontalAlignment.Left)
            lstArchival.Columns.Add("Image", 300, HorizontalAlignment.Left)

            Dim img(4) As String
            Dim itms = New ListViewItem

            For i = 0 To Kount - 1

                img(0) = ds.Tables("paperarchive").Rows(i).Item("belongsTo")
                img(1) = ds.Tables("paperarchive").Rows(i).Item("classifiedInto")
                img(2) = ds.Tables("paperarchive").Rows(i).Item("formDatetime")
                img(3) = ds.Tables("paperarchive").Rows(i).Item("image")

                itms = New ListViewItem(img)
                lstArchival.Items.Add(itms)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            dbconn.Close()
        End Try
        dbconn.Close()
    End Sub

    Private Sub txtImageFile_TextChanged(sender As Object, e As EventArgs) Handles txtImageFile.TextChanged
        Try
            PicForm.ImageLocation = txtImageFile.Text

            'lblArchiveMsg.Text = ""

            If Strings.UCase(Strings.Right(txtImageFile.Text, 3)) = "PDF" Then
                ShowImage(txtImageFile.Text)
            Else
                PicForm.Refresh()
            End If
            'PicForm.Visible = True
            'lstMessages.Visible = False
            'MsgBox(PicForm.ImageLocation)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tabUnstructured_Click(sender As Object, e As EventArgs) Handles tabUnstructured.Click
        'MsgBox("Unstructured Image File")
        'PicForm.Visible = True
        'lstMessages.Visible = False
    End Sub


    Private Sub lblZoomout_Click(sender As Object, e As EventArgs) Handles lblZoomout.Click
        'frmViewImage.picView.ImageLocation = txtImageFile.Text
        'frmViewImage.picView.Refresh()
        'frmViewImage.Show()
        ShowImage(PicForm.ImageLocation)
        'ImageZoom(PicForm.ImageLocation)
    End Sub

    Private Sub lblMessages_Click(sender As Object, e As EventArgs) Handles lblMessages.Click

    End Sub

    Private Sub MenuPaperArchive_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuPaperArchive.ItemClicked

    End Sub

    Sub ImageZoom(flnm As String)
        frmViewImage.picView.ImageLocation = flnm
        frmViewImage.picView.Refresh()
        frmViewImage.Show()
    End Sub

    Private Sub lstArchival_Click(sender As Object, e As EventArgs) Handles lstArchival.Click
        'MsgBox(lstArchival.FocusedItem.SubItems(3).Text)
        Dim SelectedImage As String
        SelectedImage = lstArchival.FocusedItem.SubItems(3).Text
        If Strings.UCase(Strings.Right(SelectedImage, 3)) = "PDF" Then
            ShowImage(SelectedImage)
        Else
            PicForm.ImageLocation = SelectedImage
            PicForm.Refresh()
        End If
        'PicForm.ImageLocation = lstArchival.FocusedItem.SubItems(3).Text
    End Sub


    Private Sub cmdUpdateArchiveDef_Click(sender As Object, e As EventArgs) Handles cmdUpdateArchiveDef.Click
        If PicForm.ImageLocation = "" Then
            MsgBox("Can't Update. No Image Retrieved")
            Exit Sub
        End If
        Try
            If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim dt, img, sql0 As String
                Dim comm As New MySql.Data.MySqlClient.MySqlCommand

                img = PicForm.ImageLocation

                ' Change the path character to mysql format
                img = Strings.Replace(img, "\", "\\")
                dt = txtYY.Text & "-" & txtMM.Text & "-" & txtDD.Text & " " & txtHH.Text & ":00:00"

                comm.Connection = dbconn  ' Assign the already defined and asigned connection string to the Mysql command variable

                sql0 = "update paperarchive set belongsTo = '" & txtStation.Text & "', formDatetime='" & dt & "', classifiedInto='" & txtForm.Text & "' " & _
                       "where image ='" & img & "';"

                'MsgBox(sql0)
                comm.CommandText = sql0  ' Assign the SQL statement to the Mysql command variable
                comm.ExecuteNonQuery()   ' Execute the query
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PicForm_MouseHover(sender As Object, e As EventArgs) Handles PicForm.MouseHover

    End Sub

    Private Sub txtSelectedFolder_TextChanged(sender As Object, e As EventArgs) Handles txtSelectedFolder.TextChanged
        If IO.Directory.Exists(txtSelectedFolder.Text) Then
            ListFiles(txtSelectedFolder.Text)
        Else
            lstvFiles.Clear()
            chkFiles.Visible = False
        End If
    End Sub


    Private Sub lblImageRotate_Click(sender As Object, e As EventArgs) Handles lblImageRotate.Click
        PicForm.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        PicForm.Refresh()
    End Sub


    Private Sub lstArchival_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArchival.SelectedIndexChanged

    End Sub
End Class