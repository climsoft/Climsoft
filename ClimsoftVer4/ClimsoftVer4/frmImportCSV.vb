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

Public Class frmImportCSV
    Dim strFolderPath As String, strFileName As String, rec As Integer
    Dim sql As String
    Dim ds As New DataSet()
    Dim da As OleDb.OleDbDataAdapter
    Dim fd As OpenFileDialog = New OpenFileDialog()
    Dim strDataFile As String, strSchemaFile As String, strClicomDataFolder As String
    Dim messageName As String, messageBoxAlert As String

    Private Sub frmImportCSV_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' New language translation approach proposed as an alternative to using the Multilanguage tool provided by Microsoft. 20160206, ASM.
        'Additional inline documentation is contained in the Class developed.
        'New Class [clsLanguageTranslation] and Function [translateText] have been developed for translation. 201606, ASM

        Dim ctrl As Control, TranslationInputText As String
        Dim objTranslate As New clsLanguageTranslation

        'Translate text for form title
        TranslationInputText = Me.Tag
        Me.Text = objTranslate.translateText(TranslationInputText)

        'Translate text for lables and command buttons
        For Each ctrl In Me.Controls      
            If Strings.Left(ctrl.Name, 3) = "lbl" Or Strings.Left(ctrl.Name, 3) = "btn" Then
                TranslationInputText = ctrl.Tag
                ctrl.Text = objTranslate.translateText(TranslationInputText)
            End If
        Next ctrl

        messageName = "msgNotYetImplemented"
        'Translate message
        TranslationInputText = messageName
        messageBoxAlert = objTranslate.translateText(TranslationInputText)

        'Get CLICOM data folder from dataset for [regkeys] table 
        strClicomDataFolder = dsReg.Tables("regData").Rows(9).Item("keyValue")
        
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim strConnString As String
        Dim maxRows As Integer, stnId As String, elemCode As String, yyyymm As String, obsDate As String, obsDay As String, obsHour As String, _
            obsLevel As String, obsVal As String, obsFlag As String, qcStatus As Integer, acquisitionType As Integer, n As Integer, _
            m As Integer, j As Integer, i As Integer
        'strFolderPath = txtFolderName.Text
        'strFileName = txtFileName.Text

        'strDataFile = System.IO.Path.GetFileName(txtDataFile.Text)
        ' strSchemaFile = System.IO.Path.GetFileName(txtSchemaFile.Text)
        ' strFolderPath = System.IO.Path.GetDirectoryName(txtDataFile.Text)

        strDataFile = strClicomDataFolder & "\clicom_daily.csv"
        strSchemaFile = strClicomDataFolder & "\schema.ini"

        'Copy Data file to CLICOM folder and rename the files to [clicom_daily.csv] and [schema.ini] and overwrite existing file
        My.Computer.FileSystem.CopyFile(txtDataFile.Text, strDataFile, True)

        'Copy schema file to CLICOM folder and rename the files to [schema.ini] and [schema.ini] and overwrite existing file
        My.Computer.FileSystem.CopyFile(txtSchemaFile.Text, strSchemaFile, True)

        '   MsgBox("Files copied successfully!")

        'strFolderPath = System.IO.Path.GetDirectoryName(txtQCReportOriginal.Text)
        strConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strClicomDataFolder & ";Extended Properties=Text;"
        Dim conn1 As New OleDb.OleDbConnection
        'rec = -1

        'Try
        conn1.ConnectionString = strConnString
        conn1.Open()

        sql = "SELECT * FROM [" & "clicom_daily.csv" & "]"

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
            frmDataTransferProgress.txtDataTransferProgress1.Text = "      Transferring record: " & n + 1 & " of " & maxRows
            frmDataTransferProgress.txtDataTransferProgress1.Refresh()
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
                sql = "INSERT IGNORE INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                    "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                    qcStatus & "," & acquisitionType & ")"

                ' ''sql = "INSERT INTO observationInitial(recordedFrom,describedBy,obsDatetime,obsLevel,obsValue,Flag,qcStatus,acquisitionType) " & _
                ' ''   "VALUES ('" & stnId & "'," & elemCode & ",'" & obsDate & "','" & obsLevel & "'," & obsVal & ",'" & obsFlag & "'," & _
                ' ''   qcStatus & "," & acquisitionType & ")" & "ON DUPLICATE KEY UPDATE obsValue=" & obsVal 

                If IsDate(obsDate) And Val(obsVal) > 0 Then
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
                End If
                'Move to next record in dataset

            Next m
        Next n
        conn.Close()
        frmDataTransferProgress.lblDataTransferProgress.ForeColor = Color.Red
        frmDataTransferProgress.lblDataTransferProgress.Text = "Data transfer complete !"
    End Sub

    Private Sub btnBrowseDataFile_Click(sender As Object, e As EventArgs) Handles btnBrowseDataFile.Click
        '
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C\*.*"
        'fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "CSV files (*.csv)|*.csv|CSV files (*.csv)|*.csv"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtDataFile.Text = fd.FileName
            strDataFile = txtDataFile.Text
        End If
    End Sub

    Private Sub btnBrowseSchemaFile_Click(sender As Object, e As EventArgs) Handles btnBrowseSchemaFile.Click
        '
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = "C:\*.*"
        'fd.InitialDirectory = dsReg.Tables("regData").Rows(7).Item("keyValue")
        fd.Filter = "Schema files (*.ini)|*.ini|Schema files (*.ini)|*.ini"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True
        '
        If fd.ShowDialog() = DialogResult.OK Then
            txtSchemaFile.Text = fd.FileName
            strSchemaFile = txtSchemaFile.Text
        End If
    End Sub

    Private Sub txtSchemaFile_TextChanged(sender As Object, e As EventArgs) Handles txtSchemaFile.TextChanged
        If Strings.Right(txtSchemaFile.Text, 4) = ".ini" And Strings.Right(txtDataFile.Text, 4) = ".csv" Then
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'MsgBox(messageBoxAlert, MsgBoxStyle.Information)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "datatransfers.htm#from_CLICOM")
    End Sub

End Class

