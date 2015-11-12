Public Class frmImportCSV
    Dim strFolderPath As String, strFileName As String, rec As Integer
    Dim sql As String
    Dim ds As New DataSet()
    Dim da As OleDb.OleDbDataAdapter

    Private Sub frmImportCSV_Load(sender As Object, e As EventArgs) Handles Me.Load

        ''Dim strConnString As String
        ''strFolderPath = txtFolderName.Text
        ''strFileName = txtFileName.Text
        ''strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderPath & ";Extended Properties=Text;"
        ''Dim conn1 As New OleDb.OleDbConnection
        ''rec = -1

        ' ''Try
        ''conn1.ConnectionString = strConnString
        ''conn1.Open()

        ''sql = "SELECT * FROM [" & strFileName & "]"

        ''da = New OleDb.OleDbDataAdapter(sql, conn1)
        ''da.Fill(ds, "clicomDaily")
        ''conn1.Close()
        ''MsgBox("CSV data imported into dataset !", MsgBoxStyle.Information)

        ' Catch ex As OleDb.OleDbException
        'MessageBox.Show(ex.Message)
        ' End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim strConnString As String
        Dim maxRows As Integer, stnId As String, elemCode As String, yyyymm As String, obsDate As String, obsDay As String, obsHour As String, _
            obsLevel As String, obsVal As String, obsFlag As String, qcStatus As Integer, acquisitionType As Integer, n As Integer, _
            m As Integer, j As Integer, i As Integer
        strFolderPath = txtFolderName.Text
        strFileName = txtFileName.Text
        strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFolderPath & ";Extended Properties=Text;"
        Dim conn1 As New OleDb.OleDbConnection
        'rec = -1

        'Try
        conn1.ConnectionString = strConnString
        conn1.Open()

        sql = "SELECT * FROM [" & strFileName & "]"

        da = New OleDb.OleDbDataAdapter(sql, conn1)
        da.Fill(ds, "clicomDaily")
        conn1.Close()

        maxRows = ds.Tables("clicomDaily").Rows.Count
        ' MsgBox("Number of rows: " & maxRows)
        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        connStr = frmLogin.txtusrpwd.Text

        conn.ConnectionString = connStr
        conn.Open()
        Dim ds1 As New DataSet
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim elemMaxRows As Integer, k As Integer, valScale As Single
        sql = "SELECT elementId,elementScale FROM obselement"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count

        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Loop through all rows in the input data file
        For n = 0 To maxRows - 1

            'Initialize i and j
            'j is column for value
            j = 3
            'i is column for flag
            i = 4
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows

            stnId = ds.Tables("clicomDaily").Rows(n).Item(1)
            elemCode = ds.Tables("clicomDaily").Rows(n).Item(2)
            obsLevel = "surface"
            obsVal = ""
            obsFlag = ""
            qcStatus = 0
            acquisitionType = 2
            yyyymm = ds.Tables("clicomDaily").Rows(n).Item(4)
            obsHour = " 06:00:00"
            'Get the element scale
            For k = 0 To elemMaxRows - 1
                If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
            Next k
            For m = 1 To 31
                'For each loop, initialize value and flag to zero length string (Null)
                obsVal = ""
                obsFlag = ""

                obsDay = m
                'The first column for values is 5 and the first column for flags is 6
                j = j + 2
                i = i + 2

                If Val(obsDay) < 10 Then obsDay = "0" & obsDay
                obsDate = yyyymm & "-" & obsDay & obsHour
                If Not IsDBNull(ds.Tables("clicomDaily").Rows(n).Item(j)) Then obsVal = ds.Tables("clicomDaily").Rows(n).Item(j)
                If IsNumeric(obsVal) Then obsVal = Int((obsVal / valScale) + 0.5)
                If Not IsDBNull(ds.Tables("clicomDaily").Rows(n).Item(i)) Then obsFlag = ds.Tables("clicomDaily").Rows(n).Item(i)
                'Generate SQL string for inserting data into observationinitial table
                sql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                    qcStatus & "," & acquisitionType & ")"
                If IsDate(obsDate) And Val(obsVal) > 0 Then
                    ' Create the Command for executing query and set its properties
                    objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    'Execute query
                    objCmd.ExecuteNonQuery()
                End If
                'Move to next record in dataset

            Next m
        Next n
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
    End Sub
End Class

