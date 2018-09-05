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

Public Class formStation
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Close the current form
        Me.Close()
    End Sub
    Private Sub navigateRecords()
        On Error GoTo Err

        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        StationIdTextBox.Text = ds.Tables("station").Rows(inc).Item("stationId")
        StationNameTextBox.Text = ds.Tables("station").Rows(inc).Item("stationName")
        CountryTextBox.Text = ds.Tables("station").Rows(inc).Item("country")
        LatitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("latitude")
        LongitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("longitude")
        ElevationTextBox.Text = ds.Tables("station").Rows(inc).Item("elevation")
        'OpeningDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("openingdatetime")
        'ClosingDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("closingdatetime")
        'AuthorityTextBox.Text = ds.Tables("station").Rows(inc).Item("authority")
        'AdminRegionTextBox.Text = ds.Tables("station").Rows(inc).Item("adminregion")
        'DrainageBasinTextBox.Text = ds.Tables("station").Rows(inc).Item("drainagebasin")
        'GeoLocationMethodTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationmethod")
        'GeoLocationAccuracyTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationaccuracy")
        'CptSelectionTextBox.Text = ds.Tables("station").Rows(inc).Item("cptselection")
        'StationOperationalTextBox.Text = ds.Tables("station").Rows(inc).Item("stationoperational")
        displayRecordNumber()
        Exit Sub
Err:
        If Err.Number = 13 Then Resume Next
    End Sub
    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub

    Private Sub formStation_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error GoTo Err
        'Set the record index counter to the first row
        inc = 0

        'myConnectionString = formDatabaseConnect.txtDbParameters.Text & "uid=" & formDatabaseConnect.userName.Text & ";pwd=" & formDatabaseConnect.passWord.Text & ";"
        myConnectionString = frmLogin.txtusrpwd.Text
        'Try
        conn.ConnectionString = myConnectionString
        conn.Open()

        'MsgBox("Connection Successful !", MsgBoxStyle.Information)

        sql = "SELECT * FROM station"
        da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
        da.Fill(ds, "station")
        conn.Close()
        ' MsgBox("Dataset Field !", MsgBoxStyle.Information)

        'FormLaunchPad.Show()
        ' Catch ex As MySql.Data.MySqlClient.MySqlException
        'MessageBox.Show(ex.Message)
        'End Try
        maxRows = ds.Tables("station").Rows.Count

        'OpeningDatetimeDateTimePicker.CustomFormat = "yyyy-mm-dd hh:mm"

        StationIdTextBox.Text = ds.Tables("station").Rows(inc).Item("stationId")
        StationNameTextBox.Text = ds.Tables("station").Rows(inc).Item("stationName")
        CountryTextBox.Text = ds.Tables("station").Rows(inc).Item("country")
        LatitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("latitude")
        LongitudeTextBox.Text = ds.Tables("station").Rows(inc).Item("longitude")
        ElevationTextBox.Text = ds.Tables("station").Rows(inc).Item("elevation")


        ' OpeningDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("openingdatetime")
        ' ClosingDatetimeDateTimePicker.Text = ds.Tables("station").Rows(inc).Item("closingdatetime")
        'AuthorityTextBox.Text = ds.Tables("station").Rows(inc).Item("authority")
        ' AdminRegionTextBox.Text = ds.Tables("station").Rows(inc).Item("adminregion")
        ' DrainageBasinTextBox.Text = ds.Tables("station").Rows(inc).Item("drainagebasin")
        ' GeoLocationMethodTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationmethod")
        'GeoLocationAccuracyTextBox.Text = ds.Tables("station").Rows(inc).Item("geolocationaccuracy")
        'CptSelectionTextBox.Text = ds.Tables("station").Rows(inc).Item("cptselection")
        'StationOperationalTextBox.Text = ds.Tables("station").Rows(inc).Item("stationoperational")
        'recNumberTextBox.Text = "Record 1 of " & maxRows
        displayRecordNumber()
        Exit Sub
Err:
        If Err.Number = 13 Then Resume Next
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        ds.Tables("station").Rows(inc).Item("stationId") = StationIdTextBox.Text
        ds.Tables("station").Rows(inc).Item("stationName") = StationNameTextBox.Text
        'ds.Tables("station").Rows(inc).Item("latitude") = StationNameTextBox.Text
        'ds.Tables("station").Rows(inc).Item("longitude") = StationNameTextBox.Text
        ds.Tables("station").Rows(inc).Item("country") = CountryTextBox.Text
        ds.Tables("station").Rows(inc).Item("authority") = AuthorityTextBox.Text
        ds.Tables("station").Rows(inc).Item("drainagebasin") = DrainageBasinTextBox.Text
        'ds.Tables("station").Rows(inc).Item("geolocationAccuracy") = GeoLocationAccuracyTextBox.Text
        'ds.Tables("station").Rows(inc).Item("geolocationMethod") = GeoLocationMethodTextBox.Text

        'The data adapter is used to update the record in the data source table
        da.Update(ds, "station")

        'Show message for successful updating or record.
        'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
        'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
        recUpdate.messageBoxRecordedUpdated()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'The AddNew button is for the purpose of adding a new record to the DataSet and "NOT FOR ADDING A NEW RECORD TO THE DATASOURCE TABLE".
        'It is the job of the Commit button to add the new record to the datasource table.
        'On pressing the AddNew button, disable buttons for record navigation and also the buttons for deleting, updating
        'or committing a record. This means that these buttons are not required to operate at the time of adding a new record.
        'The addNew button itself should also become disabled soon after clicking it until after the newly added recorded is committed
        'to the data source table linked to the current dataset.
        'Only the Commit button should be enabled.

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True
        StationIdTextBox.Clear()
        StationNameTextBox.Clear()
        CountryTextBox.Clear()
        LatitudeTextBox.Clear()
        LongitudeTextBox.Clear()
        ElevationTextBox.Clear()
        AdminRegionTextBox.Clear()
        DrainageBasinTextBox.Clear()
        GeoLocationAccuracyTextBox.Clear()
        GeoLocationMethodTextBox.Clear()

        'Set record index to last record
        inc = maxRows - 1

        'Display record position in record navigation Text Box
        recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'The "btnClear" when clicked is meant to clear the form of any new data entered after clicking the Addnew button or in other words 
        'to undo the AddNew button process before the recorded can be committed to to the datasource table linked to the DataSet.
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

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        dsNewRow = ds.Tables("station").NewRow
        dsNewRow.Item("stationId") = StationIdTextBox.Text
        dsNewRow.Item("stationName") = StationNameTextBox.Text
        dsNewRow.Item("country") = CountryTextBox.Text
        'dsNewRow.Item("latitude") = LatitudeTextBox.Text
        'dsNewRow.Item("longitude") = LongitudeTextBox.Text
        'dsNewRow.Item("elevation") = ElevationTextBox.Text
        dsNewRow.Item("adminRegion") = AdminRegionTextBox.Text
        dsNewRow.Item("authority") = AuthorityTextBox.Text
        'dsNewRow.Item("geolocationAccuracy") = GeoLocationAccuracyTextBox.Text
        'dsNewRow.Item("geolocationMethod") = GeoLocationMethodTextBox.Text

        'dsNewRow.Item("openingDate") = OpeningDatetimeDateTimePicker.Value
        'dsNewRow.Item("openingDatetime") = ClosingDatetimeDateTimePicker.Value

        'Add a new record to the data source table
        ds.Tables("station").Rows.Add(dsNewRow)
        da.Update(ds, "station")

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
        maxRows = ds.Tables("station").Rows.Count
        inc = maxRows - 1

        'Call subroutine for record navigation
        navigateRecords()

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

        ds.Tables("station").Rows(inc).Delete()
        da.Update(ds, "station")
        maxRows = maxRows - 1
        inc = 0

        'Call subroutine for record navigation
        navigateRecords()
    End Sub
End Class