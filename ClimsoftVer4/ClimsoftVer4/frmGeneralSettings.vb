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
' along with this program.  If not, see <http://www.gnu.org/licenses/>

Public Class frmGeneralSettings
    Dim conn As New MySql.Data.MySqlClient.MySqlConnection
    Dim myConnectionString As String
    Dim usrName As String
    Dim usrPwd As String
    Dim dbServer As String
    Dim dbName As String
    Dim inc As Integer
    Dim da As MySql.Data.MySqlClient.MySqlDataAdapter
    Dim ds As New DataSet
    Dim sql As String
    Dim maxRows As Integer

    Private Sub navigateRecords()
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        'cboElement.Text = ds.Tables("form_hourly").Rows(inc).Item("elementId")
        txtKeyName.Text = ds.Tables("regkeys").Rows(inc).Item("keyName")
        txtKeyValue.Text = ds.Tables("regkeys").Rows(inc).Item("keyValue")
        txtKeyDescription.Text = ClsTranslations.GetTranslation(ds.Tables("regkeys").Rows(inc).Item("keyDescription"))

        displayRecordNumber()
    End Sub
    Private Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = ClsTranslations.GetTranslation("Record") & " " & inc + 1 & ClsTranslations.GetTranslation("of") & " " & maxRows
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmGeneralSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim loggedInUser As String
        'loggedInUser = frmLogin.txtUser.Text

        'MsgBox(loggedInUser)

        'Set TAB next to true
        myConnectionString = frmLogin.txtusrpwd.Text
        conn.ConnectionString = myConnectionString

        '' Add a record for key entry mode if not exists
        'Try
        '    Dim qry As MySql.Data.MySqlClient.MySqlCommand
        '    sql = "INSERT INTO `regkeys` (`keyName`, `keyValue`, `keyDescription`) VALUES ('key14', 'Single', 'Data entry mode. Single or Double entry');"

        '    conn.Open()
        '    qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        '    qry.CommandTimeout = 0
        '    qry.ExecuteNonQuery()

        '    conn.Close()
        'Catch ex As Exception
        '    If ex.HResult <> -2147467259 Then 'Existing record
        '        MsgBox(ex.HResult & " " & ex.Message)
        '    End If
        '    conn.Close()
        'End Try

        tabNext = True
        'Set the record index counter to the first row
        inc = 0


        Try

            conn.Open()

            'MsgBox("Connection Successful !", MsgBoxStyle.Information)

            sql = "SELECT * FROM regkeys"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.SelectCommand.CommandTimeout = 0
            ds.Clear()
            da.Fill(ds, "regkeys")

            ' Update Registry with the new values if not yet done as on 28/06/2021
            If ds.Tables("regkeys").Rows.Count < 15 Then UpdateRegistry()

            conn.Close()
            ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

            'FormLaunchPad.Show()
        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
            conn.Close()
        End Try

        maxRows = ds.Tables("regkeys").Rows.Count

        If maxRows > 0 Then
            txtKeyName.Text = ds.Tables("regkeys").Rows(inc).Item("keyName")
            txtKeyValue.Text = ds.Tables("regkeys").Rows(inc).Item("keyValue")
            txtKeyDescription.Text = ClsTranslations.GetTranslation(ds.Tables("regkeys").Rows(inc).Item("keyDescription"))

            displayRecordNumber()
        Else
            'If this is the first record
            btnAddNew.Enabled = False
            btnCommit.Enabled = True
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            btnClear.Enabled = False
            btnMoveFirst.Enabled = False
            btnMoveNext.Enabled = False
            btnMovePrevious.Enabled = False
            btnMoveLast.Enabled = False

            recNumberTextBox.Text = ClsTranslations.GetTranslation("Record") & " 1 " & ClsTranslations.GetTranslation("of") & " 1"
        End If

        ClsTranslations.TranslateForm(Me)

    End Sub

    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'In order to move to move to the first record the record index is set to zero.
        inc = 0
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noPreviousRec As New dataEntryGlobalRoutines

        If inc > 0 Then
            inc = inc - 1
            navigateRecords()
        Else
            'If the record Index is equal to zero an error message must be displayed to show that there is no more previous record.
            'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
            'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noPreviousRec.messageBoxNoPreviousRecord()
        End If
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim noNextRec As New dataEntryGlobalRoutines
        If inc < (maxRows - 1) Then
            inc = inc + 1
            'Call subroutine for record navigation
            navigateRecords()
        Else
            'If the record Index is equal to maximum number of rows minus one, an error message must be displayed to show that
            'there is no more next record.The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class
            'hence the need to instantiate the "dataEntryCommonRoutines" class in the Declaration above.
            noNextRec.messageBoxNoNextRecord()
        End If
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'The AddNew button is for the purpose of adding a new record to the DataSet and "NOT FOR ADDING A NEW RECORD TO THE DATASOURCE TABLE".
        'It is the job of the Commit button to add the new record to the datasource table.
        'On pressing the AddNew button, disable buttons for record navigation and also the buttons for deleting, updating
        'or committing a record. This means that these buttons are not required to operate at the time of adding a new record.
        'The addNew button itself should also become disabled soon after clicking it until after the newly added recorded is committed
        'to the data source table linked to the current dataset.
        'Only the Commit button should be enabled.

        'First move to the last record
        '
        'In order to move to move to the last record the record index is set to the maximum number of records minus one.
        inc = maxRows - 1
        'Call subroutine for record navigation
        navigateRecords()

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True
        
        txtKeyDescription.Text = ""
        txtKeyName.Text = ""
        txtKeyValue.Text = ""
        'Set record index to last record
        inc = maxRows

        'Display record position in record navigation Text Box
        recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

        'Set focus to texbox for station level pressure
        txtKeyName.Focus()
        '----------------------------------------
    End Sub

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
       
            '---------------------------------------
        'Confirm if you want to continue and save data to database table
            Dim msgTxtContinue As String
            msgTxtContinue = "Do you want to continue and commit to database table?"
            If MsgBox(msgTxtContinue, MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

            'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
            'must be declared for the Update method to work.
            Dim m As Integer
            'Dim ctl As Control
            Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
            Dim dsNewRow As DataRow
            'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
            Dim recCommit As New dataEntryGlobalRoutines
            'Try
        dsNewRow = ds.Tables("regkeys").NewRow
            'Add a new record to the data source table
        ds.Tables("regkeys").Rows.Add(dsNewRow)
        'Commit data to database
           
        ds.Tables("regkeys").Rows(inc).Item("keyName") = txtKeyName.Text
        ds.Tables("regkeys").Rows(inc).Item("keyValue") = txtKeyValue.Text
        ds.Tables("regkeys").Rows(inc).Item("keyDescription") = txtKeyDescription.Text

          
        da.Update(ds, "regkeys")

            'Display message for successful record commit to table
            recCommit.messageBoxCommit()

            btnAddNew.Enabled = True
            btnClear.Enabled = False
            btnCommit.Enabled = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            btnMoveFirst.Enabled = True
            btnMoveLast.Enabled = True
            btnMoveNext.Enabled = True
            btnMovePrevious.Enabled = True
        maxRows = ds.Tables("regkeys").Rows.Count
            inc = maxRows - 1

            'Call subroutine for record navigation
            navigateRecords()
            ''Catch ex As Exception
            ''    MessageBox.Show(ex.Message)
       
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        'Update header fields for form in database
        ds.Tables("regkeys").Rows(inc).Item("keyName") = txtKeyName.Text
        ds.Tables("regkeys").Rows(inc).Item("keyValue") = txtKeyValue.Text
        ds.Tables("regkeys").Rows(inc).Item("keyDescription") = txtKeyDescription.Text

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "regkeys")

        'Show message for successful updating or record.
        recUpdate.messageBoxRecordedUpdated()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recDelete As New dataEntryGlobalRoutines
        If MessageBox.Show("Do you really want to Delete this Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then

            'Display message to show that delete operation has been cancelled
            recDelete.messageBoxOperationCancelled()
            Exit Sub
        End If

        ds.Tables("regkeys").Rows(inc).Delete()
        da.Update(ds, "regkeys")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        
            'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
            'to undo the AddNew button process before the recorded can be committed to the datasource table linked to the DataSet.
            'So all the buttons that were disabled after the AddNew button was clicked should be enabled back again and the Commit button
            'disabled until the AddNew button is clicked

            btnAddNew.Enabled = True
            btnCommit.Enabled = False
            btnDelete.Enabled = True
            btnUpdate.Enabled = True
            btnMoveFirst.Enabled = True
            btnMoveLast.Enabled = True
            btnMoveNext.Enabled = True
            btnMovePrevious.Enabled = True

            'Set Record position index to first record
            inc = 0

            'Call subroutine for record navigation
            navigateRecords()
       
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        'MsgBox("Not yet implemented!", MsgBoxStyle.Information)
        Help.ShowHelp(Me, Application.StartupPath & "\climsoft4.chm", "generalsettings.htm")
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim viewRecords As New dataEntryGlobalRoutines
        Dim sql, userName As String
        dsSourceTableName = "regkeys"
        userName = frmLogin.txtUsername.Text

        formDataView.grpSearch.Visible = False
        If userGroup = "ClimsoftAdmin" Or userName = "root" Then
            sql = "SELECT * FROM regkeys ORDER by keyName;"
            viewRecords.viewTableRecords(sql, translateContents:=True)
        Else
            MsgBox(ClsTranslations.GetTranslation("You don't have permission to view the information!"), MsgBoxStyle.Exclamation)
        End If
        'MsgBox("When updating folder locations, Please keep forward slash'/' for QC output folder locations " &
        '    "and backslash for other folder locations '\'. ", MsgBoxStyle.Information, "Folder Locations")
    End Sub

    Sub UpdateRegistry()
        Dim qry As MySql.Data.MySqlClient.MySqlCommand

        sql = "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- Dumping structure for table mariadb_climsoft_test_db_v4.regkeys
DROP TABLE IF EXISTS `regkeys`;
CREATE TABLE IF NOT EXISTS `regkeys` (
  `keyName` varchar(255) NOT NULL DEFAULT '',
  `keyValue` varchar(255) DEFAULT NULL,
  `keyDescription` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`keyName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table mariadb_climsoft_test_db_v4.regkeys: ~15 rows (approximately)
/*!40000 ALTER TABLE `regkeys` DISABLE KEYS */;
INSERT INTO `regkeys` (`keyName`, `keyValue`, `keyDescription`) VALUES
	('key00', '850', 'Geopotential standard pressure level'),
	('key01', '6', 'Morning time for recording tmax,tmin,precip'),
	('key02', '18', 'Afternoon time for recording tmax'),
	('key03', '1', 'Month for starting recording of Gmin'),
	('key04', '12', 'Month for ending recording Gmin'),
	('key05', '3', 'Number of digits for wind direction'),
	('key06', '3', 'Number of digits for wind speed'),
	('key07', 'C:\\data\\QC', 'Folder for QC Reports for QC updates (Windows style)'),
	('key08', 'C:/data/QC', 'Folder for QC Reports for MariaDB output (Unix style)'),
	('key09', 'mm', 'Units for Precipitation'),
	('key10', 'Deg C', 'Units for Temperature'),
	('key11', 'feet', 'Units for Cloud hight'),
	('key12', 'C:\\images', 'Folder for Paper Archive image files'),
	('key13', 'knots', 'Units for Wind Speed'),
	('key14', 'metres', 'Units for Visibility');
/*!40000 ALTER TABLE `regkeys` ENABLE KEYS */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"

        qry = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
        qry.CommandTimeout = 0

        Try
            'Execute query
            qry.ExecuteNonQuery()

            ' Refresh the dataset with the updated data
            sql = "SELECT * FROM regkeys"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            ds.Clear()
            da.SelectCommand.CommandTimeout = 0
            da.Fill(ds, "regkeys")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class