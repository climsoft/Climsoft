Public Class frmUploadToObsFinal
    Dim msgTxtNotYetImplemented As String
    Dim MyConnectionString As String, sql As String, conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'msgTxtNotYetImplemented = "Not yet implemented!"
        'MsgBox(msgTxtNotYetImplemented)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "qcchecks.htm#updateobsfinal")

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Open form for displaying data transfer progress
        frmDataTransferProgress.Show()

        'Upload data to observationInitial table
        Dim strSQL As String, stnId As String, elemCode As Integer, obsDate As String, obsVal As String, obsFlag, mark1 As String, _
            qcStatus As Integer, acquisitionType As Integer, obsLevel As String, yyyy As Integer, mm As String, dd As String, hh As String

        Dim ds As New DataSet
        Dim maxRows As Integer
        Dim beginYear As Integer, endYear As Integer, beginMonth As Integer, endMonth As Integer

        beginYear = Val(txtBeginYear.Text)
        endYear = Val(txtEndYear.Text)
        beginMonth = Val(txtBeginMonth.Text)
        endMonth = Val(txtEndMonth.Text)

        '------
        ds.Clear()
        MyConnectionString = frmLogin.txtusrpwd.Text
        ' conn.Close()
        conn.ConnectionString = MyConnectionString
        conn.Open()
        'First upload records with QC status =1
        sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType,mark " & _
            "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear & _
            " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=1"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)
        da.Fill(ds, "obsInitial")
        ''conn.Close() '
        ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter

        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand
        maxRows = ds.Tables("obsInitial").Rows.Count

        Dim ds1 As New DataSet
        Dim da1 As MySql.Data.MySqlClient.MySqlDataAdapter
        Dim elemMaxRows As Integer, k As Integer, valScale As Single
        Sql = "SELECT elementId,elementScale FROM obselement"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(Sql, conn)

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count
        'MsgBox("Number of elements: " & elemMaxRows)

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            frmDataTransferProgress.lblTableRecords.Text = "Uploading records with qcStatus=1"
            frmDataTransferProgress.lblTableRecords.Refresh()
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows
            frmDataTransferProgress.txtDataTransferProgress.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table

            dd = ""
            hh = ""
            yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            If Val(mm) < 10 Then mm = "0" & mm
            If Val(dd) < 10 Then dd = "0" & dd
            If Val(hh) < 10 Then hh = "0" & hh
            dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"
            stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
            elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")
            mark1 = ds.Tables("obsInitial").Rows(n).Item("mark")
            'Get the element scale
            Try
                For k = 0 To elemMaxRows - 1
                    If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
                Next k

                obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
                obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
                obsVal = obsVal * valScale
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("flag")) Then obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("qcStatus")) Then qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
                If Not IsDBNull(ds.Tables("obsInitial").Rows(n).Item("acquisitionType")) Then acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")

                'Generate SQL string for inserting data into observationFinal table
                strSQL = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType,mark) " & _
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                    qcStatus & "," & acquisitionType & "," & mark1 & ")"

                ' Create the Command for executing query and set its properties
                objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)


                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception

                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)

            End Try

            'Move to next record in dataset
        Next n

        conn.Close()
        '------
        ds.Clear()
        MyConnectionString = frmLogin.txtusrpwd.Text
        ' conn.Close()
        conn.ConnectionString = MyConnectionString
        conn.Open()

        'Next upload records with QC status =2
        sql = "SELECT recordedFrom,describedBy,obsdatetime,obsLevel,obsValue,flag,qcStatus,acquisitionType " & _
            "FROM observationInitial WHERE year(obsDateTime) between " & beginYear & " AND " & endYear & _
            " AND month(obsDatetime) between " & beginMonth & " AND " & endMonth & " AND qcStatus=2"

        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "obsInitial")
        ''conn.Close() '
        ' Dim dsObsInitial As New MySql.Data.MySqlClient.MySqlDataAdapter


        maxRows = ds.Tables("obsInitial").Rows.Count

        sql = "SELECT elementId,elementScale FROM obselement"
        da1 = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)

        da1.Fill(ds1, "elemScale")
        elemMaxRows = ds1.Tables("elemScale").Rows.Count
        'MsgBox("Number of elements: " & elemMaxRows)

        'Loop through all records in dataset
        For n = 0 To maxRows - 1
            frmDataTransferProgress.lblTableRecords.Text = "Uploading records with qcStatus=2"
            frmDataTransferProgress.lblTableRecords.Refresh()
            'Display progress of data transfer
            frmDataTransferProgress.txtDataTransferProgress.Text = "      Transferring record: " & n + 1 & " of " & maxRows

            frmDataTransferProgress.txtDataTransferProgress.Refresh()
            'Loop through all observation fields adding observation records to observationInitial table

            dd = ""
            hh = ""
            yyyy = DateAndTime.Year(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            mm = Month(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            If Val(mm) < 10 Then mm = "0" & mm
            If Val(dd) < 10 Then dd = "0" & dd
            If Val(hh) < 10 Then hh = "0" & hh
            dd = Microsoft.VisualBasic.DateAndTime.Day(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            hh = Hour(ds.Tables("obsInitial").Rows(n).Item("obsDatetime"))
            obsDate = yyyy & "-" & mm & "-" & dd & " " & hh & ":00:00"
            stnId = ds.Tables("obsInitial").Rows(n).Item("recordedFrom")
            elemCode = ds.Tables("obsInitial").Rows(n).Item("describedBy")

            'Get the element scale
            For k = 0 To elemMaxRows - 1
                If elemCode = ds1.Tables("elemScale").Rows(k).Item("elementId") Then valScale = ds1.Tables("elemScale").Rows(k).Item("elementScale")
            Next k

            obsLevel = ds.Tables("obsInitial").Rows(n).Item("obslevel")
            obsVal = ds.Tables("obsInitial").Rows(n).Item("obsValue")
            obsVal = obsVal * valScale
            obsFlag = ds.Tables("obsInitial").Rows(n).Item("flag")
            qcStatus = ds.Tables("obsInitial").Rows(n).Item("qcStatus")
            acquisitionType = ds.Tables("obsInitial").Rows(n).Item("acquisitionType")

            'Generate SQL string for replacing existing records of same Key with records with qcStatus 2
            strSQL = "REPLACE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                qcStatus & "," & acquisitionType & ")"

            ' Create the Command for executing query and set its properties
            objCmd = New MySql.Data.MySqlClient.MySqlCommand(strSQL, conn)

            Try
                'Execute query
                objCmd.ExecuteNonQuery()
                'Catch ex As MySql.Data.MySqlClient.MySqlException
                '    'Ignore expected error i.e. error of Duplicates in MySqlException
            Catch ex As Exception
                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                MsgBox(ex.Message)
            End Try

            'Move to next record in dataset
        Next n

        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

    End Sub

    Private Sub txtEndMonth_TextChanged(sender As Object, e As EventArgs) Handles txtEndMonth.TextChanged
        If Strings.Len(txtBeginMonth.Text) > 0 And Strings.Len(txtBeginYear.Text) > 0 And Strings.Len(txtEndMonth.Text) > 0 And Strings.Len(txtEndYear.Text) > 0 Then
            btnOK.Enabled = True
        End If
    End Sub
End Class