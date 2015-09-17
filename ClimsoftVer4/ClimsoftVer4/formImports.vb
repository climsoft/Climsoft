Public Class formImports
    Dim dbcon As New MySql.Data.MySqlClient.MySqlConnection
    Dim dbConectionString As String
    Dim d As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim s As New DataSet
    Dim sql1 As String
    Dim ImportFile As String

    Dim lin As Integer
    Dim currentRow As String()

    Dim row As String()
    Private Sub cmdStart_Click(sender As Object, e As EventArgs) Handles cmdStart.Click
        On Error GoTo Err
        dbConectionString = frmLogin.txtusrpwd.Text
        dbcon.ConnectionString = dbConectionString
        dbcon.Open()

        sql1 = "SELECT * FROM station"
        d = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, dbcon)
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

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(d)
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
        On Error GoTo Err

        'dbConectionString = frmLogin.txtusrpwd.Text
        'dbcon.ConnectionString = dbConectionString
        'dbcon.Open()

        'sql1 = "SELECT * FROM station"
        'd = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, dbcon)
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
        Exit Sub
Err:
        MsgBox(Err.Number & " " & Err.Description)
    End Sub
    Sub ListFields()
        On Error GoTo Err
        dbConectionString = frmLogin.txtusrpwd.Text
        dbcon.ConnectionString = dbConectionString
        dbcon.Open()

        sql1 = "SELECT * FROM station"
        d = New MySql.Data.MySqlClient.MySqlDataAdapter(sql1, dbcon)
        d.Fill(s, "station")

        dbcon.Close()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentField As String

            Dim num As Integer = 1
     

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(d)
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
        Exit Sub
Err:
        MsgBox(Err.Number & " " & Err.Description)
    End Sub

    Private Sub cmdProcess_Click(sender As Object, e As EventArgs) Handles cmdProcess.Click
        On Error GoTo Err
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(ImportFile)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim nums As Integer
            Dim rows As String()
            Dim mxr As Integer = DataGridView1.Rows.Count

            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(d)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines


            Do While MyReader.EndOfData = False
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
            Loop
            MsgBox("Data successfully imported")
        End Using
        Exit Sub
Err:
        'If Err.Number = 5 Then Resume
        MsgBox(Err.Number & " " & Err.Description)
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

    Private Sub cmdACCESS_Click(sender As Object, e As EventArgs) Handles cmdACCESS.Click
        OpenFileImport.Filter = "ACCESS Files|*.mdb;*.accdb"
        OpenFileImport.Title = "Open IACCESSFile"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        txtACCESS.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmdCLIMSOFT3_Click(sender As Object, e As EventArgs) Handles cmdCLIMSOFT3.Click
        OpenFileImport.Filter = "CLIMSOFT Database Files|*.mdb"
        OpenFileImport.Title = "Open CLIMSOFT Temporary File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        txtCLIMSOFT3.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdEXCEL_Click(sender As Object, e As EventArgs) Handles cmdEXCEL.Click
        OpenFileImport.Filter = "EXCEL Files|*.xls;*.xlsx"
        OpenFileImport.Title = "Open EXCEL File"
        OpenFileImport.ShowDialog()

        ImportFile = OpenFileImport.FileName
        txtEXCEL.Text = ImportFile
        DataGridView1.Rows.Clear()
    End Sub
End Class