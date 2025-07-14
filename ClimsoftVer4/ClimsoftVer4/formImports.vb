' CLIMSOFT - Climate Database Management System
' Copyright (C) 2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Public Class formImports
    Dim dbcon As New MySqlConnector.MySqlConnection
    Dim dbConectionString As String
    Dim d As MySqlConnector.MySqlDataAdapter
    Dim s As New DataSet
    Dim sql1 As String
    Dim ImportFile As String

    Dim lin As Integer
    Dim currentRow As String()

    Dim row As String()
    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        On Error GoTo Err
        dbConectionString = frmLogin.txtusrpwd.Text
        dbcon.ConnectionString = dbConectionString ' & ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
        dbcon.Open()

        sql1 = "SELECT * FROM station"
        d = New MySqlConnector.MySqlDataAdapter(sql1, dbcon)
        d.Fill(s, "station")

        dbcon.Close()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentField As String

            Dim num As Integer = 1
            'Dim lin As Integer
            'Dim currentRow As String()
            'Dim currentField As String
            'Dim row As String()

            Dim cb As New MySqlConnector.MySqlCommandBuilder(d)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines

            ' Define the Data GridView Columns
            DataGridView1.ColumnCount = 2
            DataGridView1.Columns(0).Name = "Import Field No"
            DataGridView1.Columns(1).Name = "Import Field Name"

            ' Populate the Data GridView with column headers from the import station text file

            lin = MyReader.LineNumber()
            currentRow = MyReader.ReadFields()

            If lin = 1 Then ' The header row
                For Each currentField In currentRow
                    row = New String() {num, currentField}
                    DataGridView1.Rows.Add(row)
                    num = num + 1
                Next
            End If


            'End Using

            ' Populate the Data GridView with column headers from the db station table
            formMetadata.SetDataSet("station")
            Dim maxfields, mxrows As Integer
            maxfields = s.Tables("station").Columns.Count
            mxrows = DataGridView1.Rows.Count

            ' Define the new column
            Dim cmb As New DataGridViewComboBoxColumn()
            cmb.HeaderText = "Select Fields"
            cmb.Name = "cmb"
            cmb.MaxDropDownItems = maxfields

            ' Add ComboList and populate it
            cmb.Items.Add("")
            For i = 0 To maxfields - 1
                cmb.Items.Add(s.Tables("station").Columns(i).ColumnName)
            Next
            DataGridView1.Columns.Add(cmb)
            DataGridView1.Refresh()

            'Do While MyReader.EndOfData = False
            '    lin = MyReader.LineNumber()
            '    If lin > 1 Then
            '        num = 1
            '        currentRow = MyReader.ReadFields()
            '        For Each currentField In currentRow
            '            row = New String() {num, currentField}
            '            'DataGridView1.Rows.Add(row)
            '            num = num + 1

            '            'Write Code to;
            '            'loop through DatagridView column on db fields

            '            'MsgBox(DataGridView1.Rows(num).Cells(2).Value)


            '            'For each cell get the db field name and locate the field number for the corresponding field name on the import fields
            '            'From MyReader get the data value and update the corresponding db field

            '        Next
            '    End If
            'Loop

        End Using
        Exit Sub
Err:
        MsgBox(Err.Number & " " & Err.Description)
    End Sub


    Private Sub formImports_Load(sender As Object, e As EventArgs) Handles Me.Load
        'On Error GoTo Err

        'dbConectionString = frmLogin.txtusrpwd.Text
        'dbcon.ConnectionString = dbConectionString
        'dbcon.Open()

        'sql1 = "SELECT * FROM station"
        'd = New MySqlConnector.MySqlDataAdapter(sql1, dbcon)
        'd.Fill(s, "station")


        'Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\Climsoft Project\Climsoft V4\Data\stations.txt")
        '    MyReader.TextFieldType = FileIO.FieldType.Delimited
        '    MyReader.SetDelimiters(",")
        '    Dim num As Integer = 1
        '    Dim lin As Integer
        '    Dim currentRow As String()
        '    Dim currentField As String
        '    Dim row As String()

        '    ' Define the Data GridView Columns
        '    DataGridView1.ColumnCount = 2
        '    DataGridView1.Columns(0).Name = "Import Field No"
        '    DataGridView1.Columns(1).Name = "Import Field Name"

        '    ' Populate the Data GridView with column headers from the import station text file

        '    lin = MyReader.LineNumber()
        '    currentRow = MyReader.ReadFields()

        '    If lin = 1 Then ' The header row
        '        For Each currentField In currentRow
        '            row = New String() {num, currentField}
        '            DataGridView1.Rows.Add(row)
        '            num = num + 1
        '        Next
        '    End If


        '    'End Using

        '    ' Populate the Data GridView with column headers from the db station table
        '    formMetadata.SetDataSet("station")
        '    Dim maxfields As Integer
        '    maxfields = s.Tables("station").Columns.Count

        '    ' Define the new column
        '    Dim cmb As New DataGridViewComboBoxColumn()
        '    cmb.HeaderText = "Select Fields"
        '    cmb.Name = "cmb"
        '    cmb.MaxDropDownItems = maxfields

        '    ' Add ComboList and populate it
        '    cmb.Items.Add("")
        '    For i = 0 To maxfields - 1
        '        cmb.Items.Add(s.Tables("station").Columns(i).ColumnName)
        '    Next
        '    DataGridView1.Columns.Add(cmb)
        '    DataGridView1.Refresh()


        'End Using
        'Exit Sub
        'Err:
        'MsgBox(Err.Number & " " & Err.Description)

        'translate form controls
        ClsTranslations.TranslateForm(Me)
    End Sub
    Sub ListFields()
        Try
            dbConectionString = frmLogin.txtusrpwd.Text
            dbcon.ConnectionString = dbConectionString
            dbcon.Open()

            sql1 = "SELECT * FROM station"
            d = New MySqlConnector.MySqlDataAdapter(sql1, dbcon)
            d.Fill(s, "station")

            dbcon.Close()

            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentField As String

                Dim num As Integer = 1


                Dim cb As New MySqlConnector.MySqlCommandBuilder(d)
                Dim dsNewRow As DataRow
                'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
                Dim recCommit As New dataEntryGlobalRoutines

                ' Define the Data GridView Columns
                DataGridView1.ColumnCount = 2
                DataGridView1.Columns(0).Name = "Import Field No"
                DataGridView1.Columns(1).Name = "Import Field Name"

                ' Populate the Data GridView with column headers from the import station text file

                lin = MyReader.LineNumber()
                currentRow = MyReader.ReadFields()

                If lin = 1 Then ' The header row
                    For Each currentField In currentRow
                        row = New String() {num, currentField}
                        DataGridView1.Rows.Add(row)
                        num = num + 1
                    Next
                End If


                ' Populate the Data GridView with column headers from the db station table
                formMetadata.SetDataSet("station")
                Dim maxfields, mxrows As Integer
                maxfields = s.Tables("station").Columns.Count
                mxrows = DataGridView1.Rows.Count

                ' Define the new column
                Dim cmb As New DataGridViewComboBoxColumn()
                cmb.HeaderText = "Select Fields"
                cmb.Name = "cmb"
                cmb.MaxDropDownItems = maxfields

                ' Add ComboList and populate it
                cmb.Items.Add("")
                For i = 0 To maxfields - 1
                    cmb.Items.Add(s.Tables("station").Columns(i).ColumnName)
                Next
                DataGridView1.Columns.Add(cmb)
                DataGridView1.Refresh()

            End Using
        Catch ex As Exception
            MsgBox("No metadata file selected")
        End Try
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        'On Error GoTo Err
        'Try
        Dim fails As Long
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim nums As Integer
            Dim rows As String()
            Dim mxr As Integer = DataGridView1.Rows.Count

            Dim cb As New MySqlConnector.MySqlCommandBuilder(d)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            fails = 0
            listErrors.Items.Clear()
            Do While MyReader.EndOfData = False
                Try
                    lin = MyReader.LineNumber()

                    currentRow = MyReader.ReadFields()

                    If lin > 1 Then
                        nums = 1
                        dsNewRow = s.Tables("station").NewRow
                        For Each currentField In currentRow
                            rows = New String() {nums, currentField}

                            If Len(DataGridView1.Rows(nums - 1).Cells(2).Value) <> 0 And Len(currentField) <> 0 Then
                                'MsgBox(DataGridView1.Rows(nums - 1).Cells(2).Value & " " & currentField)
                                dsNewRow.Item(DataGridView1.Rows(nums - 1).Cells(2).Value) = currentField
                            End If
                            nums = nums + 1
                        Next
                        s.Tables("station").Rows.Add(dsNewRow)
                        d.Update(s, "station")
                    End If
                Catch ex As Exception
                    listErrors.Items.Add(lin - 1 & " " & ex.Message)
                    listErrors.Refresh()
                    fails = fails + 1
                    s.Clear()
                    'If ex.HResult <> -2147467259 Then Exit Do
                End Try
            Loop
            Me.Cursor = Windows.Forms.Cursors.Default
            lblSummary.Text = "Summary: " & lin - fails - 1 & " out of " & lin - 1 & " Records Successfully Imported"
        End Using
        Exit Sub
        'Err:
        '        MsgBox(Err.Description & " " & Err.Number)
        '        If Err.Number = 5 Then Resume Next


        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    If ex.HResult = -2147467259 Then Resume Next
        '    MsgBox(ex.HResult)
        Me.Cursor = Windows.Forms.Cursors.Default
        '    'If Err.Number = 5 Then Resume Next
        '    'MsgBox(Err.Number & " " & Err.Description)
        'End Try
    End Sub

    Private Sub cmdCSV_Click(sender As Object, e As EventArgs) Handles cmdCSV.Click

        'openFD.Title = "Open a Text File"
        'openFD.Filter = "Text Files|*.txt"
        'openFD.ShowDialog()

        OpenFileImport.Filter = "Comma Delimited|*.csv;*.txt"
        OpenFileImport.Title = "Open Import Text File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        txtCSV.Text = ImportFile
        DataGridView1.Rows.Clear()
        ListFields()
    End Sub



    Private Sub cmdReset_Click(sender As Object, e As EventArgs) Handles cmdReset.Click
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdCLIMSOFT3_Click(sender As Object, e As EventArgs)
        OpenFileImport.Filter = "CLIMSOFT database files|*.mdb"
        OpenFileImport.Title = "Open CLIMSOSFT Temporary Database File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        'txtCLIMSOFT3.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmdEXCEL_Click(sender As Object, e As EventArgs)
        OpenFileImport.Filter = "EXCEL files|*.xls;*.xlsx"
        OpenFileImport.Title = "Open EXCEL File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        'txtEXCEL.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmdACCESS_Click(sender As Object, e As EventArgs)
        OpenFileImport.Filter = "ACCESS database files|*.mdb;*.accdb"
        OpenFileImport.Title = "Open ACCESS File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        'txtACCESS.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmHelp_Click(sender As Object, e As EventArgs) Handles cmHelp.Click
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "importstations.htm")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim fails As Long
        Try
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)

                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim nums As Integer
                Dim rows As String()
                Dim mxr As Integer = DataGridView1.Rows.Count

                Dim cb As New MySqlConnector.MySqlCommandBuilder(d)
                Dim dsNewRow As DataRow

                'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
                Dim recCommit As New dataEntryGlobalRoutines

                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                'Dim stnsFile As String
                Dim fld, fldlist, vals, sql As String

                Try
                    'stnsFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Climsoft4\data\stn_metadata.csv"

                    'FileOpen(222, stnsFile, OpenMode.Output)

                    fails = 0
                    listErrors.Items.Clear()
                    fldlist = DataGridView1.Rows(0).Cells(2).Value
                    fld = "`" & DataGridView1.Rows(0).Cells(2).Value & "`"
                    For i = 1 To DataGridView1.Rows.Count - 1
                        If Len(DataGridView1.Rows(i).Cells(2).Value) <> 0 Then
                            fldlist = fldlist & "," & DataGridView1.Rows(i).Cells(2).Value
                            fld = fld & ",`" & DataGridView1.Rows(i).Cells(2).Value & "`"
                        End If
                    Next
                    'PrintLine(222, "REPLACE INTO `station` (" & fld & ") VALUES")
                    sql = "REPLACE INTO `station` (" & fld & ") VALUES"
                    If Strings.InStr(fldlist, "stationId") = 0 Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        MsgBox("StationId Required")
                        'FileClose(222)
                        Exit Sub
                    End If


                    Do While MyReader.EndOfData = False

                        lin = MyReader.LineNumber()

                        currentRow = MyReader.ReadFields()

                        If lin > 1 Then
                            nums = 1
                            dsNewRow = s.Tables("station").NewRow
                            vals = ""
                            For Each currentField In currentRow

                                rows = New String() {nums, currentField}

                                If Len(DataGridView1.Rows(nums - 1).Cells(2).Value) <> 0 Then
                                    If Len(currentField) = 0 Then
                                        dsNewRow.Item(DataGridView1.Rows(nums - 1).Cells(2).Value) = vbNull
                                    Else
                                        dsNewRow.Item(DataGridView1.Rows(nums - 1).Cells(2).Value) = currentField
                                    End If

                                    If nums = 1 Then
                                        vals = "'" & dsNewRow(0) & "'"
                                        If Len(vals) = 0 Then vals = "\N"
                                    Else
                                        If Len(currentField) = 0 Then
                                            vals = vals & ",\N" & ""
                                        Else
                                            vals = vals & ",'" & currentField & "'"
                                        End If
                                    End If
                                End If
                                nums = nums + 1
                            Next
                            'Print(222, vals)
                            If MyReader.EndOfData = True Then
                                'PrintLine(222, "(" & vals & ");")
                                sql = sql & "(" & vals & ");"
                            Else
                                sql = sql & "(" & vals & "),"
                                'PrintLine(222, "(" & vals & "),")
                            End If

                        End If
                    Loop
                    'MsgBox(sql)
                    Me.Cursor = Windows.Forms.Cursors.Default
                    'FileClose(222)

                    'If Not Load_Files(stnsFile, "station", 0, ",") Then
                    '    FileClose(222)
                    '    MsgBox("Can import file: " & stnsFile)
                    '    Exit Sub
                    'End If

                    ' Update the station metadata with data from a text file
                    Dim objCmd As MySqlConnector.MySqlCommand
                    dbConectionString = frmLogin.txtusrpwd.Text
                    dbcon.ConnectionString = dbConectionString '& ";AllowLoadLocalInfile=true;SslMode=VerifyCA"
                    dbcon.Open()

                    ' ' Convert the the path delimiter for the metadata file to SQL structure
                    ' stnsFile = Strings.Replace(stnsFile, "\", "/")

                    ' sql = "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
                    '/*!40101 SET NAMES utf8mb4 */;
                    '/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
                    '/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
                    '/*!40000 ALTER TABLE `station` DISABLE KEYS */;
                    'LOAD DATA LOCAL INFILE '" & stnsFile & "' REPLACE INTO TABLE station FIELDS TERMINATED BY ',' (" & fldlist & ");
                    '/*!40000 ALTER TABLE `station` ENABLE KEYS */;
                    '/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
                    '/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
                    '/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"
                    ' 'MsgBox(sql)

                    'Execute SQL command
                    objCmd = New MySqlConnector.MySqlCommand(sql, dbcon)
                    objCmd.ExecuteNonQuery()
                    dbcon.Close()
                    'FileClose(222)

                    Me.Cursor = Windows.Forms.Cursors.Default
                    lblSummary.Text = "Records Successfully Updated"

                Catch ex As Exception
                    dbcon.Close()
                    'FileClose(222)
                    Me.Cursor = Windows.Forms.Cursors.Default

                    If lin > 0 Then
                        listErrors.Items.Add(lin - 1 & " " & ex.Message)
                        listErrors.Refresh()
                    Else
                        MsgBox(ex.Message)
                    End If

                    'fails = fails + 1
                End Try
            End Using
        Catch x As Exception
            If x.HResult = -2147467261 Or x.HResult = -2147024894 Then
                MsgBox("No valid metadata file found")
            Else
                MsgBox(x.Message)
            End If

        End Try

    End Sub

End Class