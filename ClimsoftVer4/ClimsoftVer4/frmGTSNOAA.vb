' CLIMSOFT - Climate Database Management System
' Copyright (C) 2015
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


Public Class frmGTSNOAA
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim strGTSDataFolder As String
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim i As Integer, j As Integer, station As String, stnId As String, elemCode As Integer, yyyymmdd As String, yyyy As String, _
            mm As String, dd As String, obsDate As String, TmeanAndCount As String, TmaxAndFlag As String, TminAndFlag As String, _
            PrecipAndFlag As String, Tmean As String, TmeanFlag As String, Tmax As String, TmaxFlag As String, Tmin As String, _
            TminFlag As String, Precip As String, PrecipFlag As String, obsVal As String, obsFlag As String, obsLevel As String, _
            qcStatus As Integer, acquisitionType As Integer, maxRows As Integer, strDataFile As String

        i = 0
        j = 0
        maxRows = 0

        strDataFile = strGTSDataFolder & "\noaa_gts.txt"


        'Copy Data file to CLICOM folder and rename the files to [clicom_daily.csv] and [schema.ini] and overwrite existing file
        My.Computer.FileSystem.CopyFile(txtDataFile.Text, strDataFile, True)

        Dim conn As New MySql.Data.MySqlClient.MySqlConnection
        Dim connStr As String, sql As String
        Dim objCmd As MySql.Data.MySqlClient.MySqlCommand

        connStr = frmLogin.txtusrpwd.Text

        conn.ConnectionString = connStr
        conn.Open()


        Using Reader As New  _
        Microsoft.VisualBasic.FileIO.TextFieldParser(strGTSDataFolder & "\noaa_gts.txt")
            Reader.TextFieldType = _
            Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            Reader.SetFieldWidths(7, 7, 8, 12, 10, 11, 11, 10, 10, 8, 8, 7, 8, 7, 8, 6)
            Dim currentRow As String()

            '-------------
            Dim lines As String() = IO.File.ReadAllLines(strGTSDataFolder & "\noaa_gts.txt")

            'MessageBox.Show("The file had " & lines.Length & " lines.")
            maxRows = lines.Length
            'MsgBox("Number of rows= " & maxRows)
            '--------------

            frmDataTransferProgress.Show()

            While Not Reader.EndOfData
                Try
                    currentRow = Reader.ReadFields()
                    i = i + 1
                    'Display progress of data transfer
                    frmDataTransferProgress.txtDataTransferProgress1.Text = " Transferring record: " & i & " of " & maxRows
                    frmDataTransferProgress.txtDataTransferProgress1.Refresh()
                    'MsgBox("Row :" & i)
                    j = 0
                    stnId = ""
                    elemCode = 0
                    obsDate = ""
                    obsLevel = "surface"
                    obsVal = ""
                    obsFlag = ""
                    qcStatus = 1
                    acquisitionType = 4
                    sql = ""
                    Dim currentField As String
                    For Each currentField In currentRow
                        j = j + 1
                        ' MsgBox("Row " & i & "field " & j & "Value: " & currentField)
                        If j = 1 And IsNumeric(currentField) Then

                            station = currentField
                            stnId = Strings.Left(station, 5)
                        ElseIf j = 3 Then
                            yyyymmdd = currentField
                            yyyy = Strings.Left(yyyymmdd, 4)
                            mm = Strings.Mid(yyyymmdd, 5, 2)
                            dd = Strings.Mid(yyyymmdd, 7, 2)


                            obsDate = yyyy & "-" & mm & "-" & dd & " 06:00:00"

                            ' MsgBox("Date=" & obsDate)

                        ElseIf j = 4 And IsDate(obsDate) Then
                            TmeanAndCount = currentField
                            Tmean = Val(Strings.Mid(TmeanAndCount, 1, 5))
                            TmeanFlag = Strings.Mid(TmeanAndCount, 6, 2)
                            elemCode = 4
                            obsVal = 5 / 9 * (Val(Tmean) - 32)
                            obsFlag = TmeanFlag

                            'Generate SQL string for inserting data into observationinitial table
                            sql = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                                qcStatus & "," & acquisitionType & ")"

                            ' MsgBox(sql)

                            ' Create the Command for executing query and set its properties
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            Try
                                'Execute query
                                objCmd.ExecuteNonQuery()
                                ' Catch ex As MySql.Data.MySqlClient.MySqlException
                                'Ignore expected error i.e. error of Duplicates in MySqlException
                            Catch ex As Exception
                                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                MsgBox(ex.Message)
                            End Try


                        ElseIf j = 12 And IsDate(obsDate) Then
                            TmaxAndFlag = currentField
                            Tmax = Val(Strings.Mid(TmaxAndFlag, 1, 6))
                            TmaxFlag = Strings.Mid(TmaxAndFlag, 5, 1)
                            elemCode = 2
                            obsVal = 5 / 9 * (Val(Tmax) - 32)
                            obsFlag = TmaxFlag

                            'Generate SQL string for inserting data into observationinitial table
                            sql = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                                qcStatus & "," & acquisitionType & ")"

                            ' Create the Command for executing query and set its properties
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            Try
                                'Execute query
                                objCmd.ExecuteNonQuery()
                                ' Catch ex As MySql.Data.MySqlClient.MySqlException
                                'Ignore expected error i.e. error of Duplicates in MySqlException
                            Catch ex As Exception
                                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                MsgBox(ex.Message)
                            End Try

                            ' MsgBox(sql)

                        ElseIf j = 13 And IsDate(obsDate) Then
                            TminAndFlag = currentField
                            Tmin = Val(Strings.Mid(TminAndFlag, 1, 6))
                            TminFlag = Strings.Mid(TminAndFlag, 5, 1)
                            elemCode = 3
                            obsVal = 5 / 9 * (Val(Tmin) - 32)
                            obsFlag = TminFlag

                            'Generate SQL string for inserting data into observationinitial table
                            sql = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                                qcStatus & "," & acquisitionType & ")"

                            ' Create the Command for executing query and set its properties
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            Try
                                'Execute query
                                objCmd.ExecuteNonQuery()
                                ' Catch ex As MySql.Data.MySqlClient.MySqlException
                                'Ignore expected error i.e. error of Duplicates in MySqlException
                            Catch ex As Exception
                                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                MsgBox(ex.Message)
                            End Try

                            ' MsgBox(sql)

                        ElseIf j = 14 And IsDate(obsDate) Then
                            PrecipAndFlag = currentField
                            Precip = Val(Strings.Mid(PrecipAndFlag, 1, 5))
                            PrecipFlag = Strings.Mid(PrecipAndFlag, 5, 1)
                            elemCode = 5
                            obsVal = 25.4 * Val(Precip)
                            obsFlag = PrecipFlag
                            'Generate SQL string for inserting data into observationinitial table
                            sql = "INSERT IGNORE INTO observationFinal(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                                "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                                qcStatus & "," & acquisitionType & ")"

                            ' Create the Command for executing query and set its properties
                            objCmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                            Try
                                'Execute query
                                objCmd.ExecuteNonQuery()
                                ' Catch ex As MySql.Data.MySqlClient.MySqlException
                                'Ignore expected error i.e. error of Duplicates in MySqlException
                            Catch ex As Exception
                                'Dispaly error message if it is different from the one trapped in 'Catch' execption above
                                MsgBox(ex.Message)
                            End Try

                            ' MsgBox(sql)

                        End If
                        '------------------------


                        ' MsgBox("Valid data record")

                        '--------------------------
                        'MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & _
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"

        conn.Close()
    End Sub

    Private Sub btnBrowseDataFile_Click(sender As Object, e As EventArgs) Handles btnBrowseDataFile.Click
        '
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C\*.*"
        'fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "Text files (*.txt)|*.txt|Text files (*.txt)|*.txt"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtDataFile.Text = fd.FileName
            'strDataFile = txtDataFile.Text
        End If
    End Sub

    Private Sub frmGTSNOAA_Load(sender As Object, e As EventArgs) Handles Me.Load
        strGTSDataFolder = dsReg.Tables("regData").Rows(11).Item("keyValue")
    End Sub

    Private Sub txtDataFile_TextChanged(sender As Object, e As EventArgs) Handles txtDataFile.TextChanged
        If Strings.Len(txtDataFile.Text) > 0 Then btnOK.Enabled = True
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#from_NOAA-NCDC")

        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "noaagts.htm")
    End Sub
End Class