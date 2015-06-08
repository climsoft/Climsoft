Public Class formElement
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
        On Error GoTo Err
        'Display the values of data fields from the dataset in the corresponding textboxes on the form.
        'The record with values to be displayed in the texboxes is determined by the value of the variable "inc"
        'which is a parameter of the "Row" attribute or property of the dataset.

        CodeTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementId")
        AbbreviationTextBox.Text = ds.Tables("obselement").Rows(inc).Item("abbreviation")
        ElementNameTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementname")
        DescriptionTextBox.Text = ds.Tables("obselement").Rows(inc).Item("description")
        ElementScaleTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementscale")
        ElementtypeTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementtype")
        UpperLimitTextBox.Text = ds.Tables("obselement").Rows(inc).Item("upperlimit")
        LowerLimitTextBox.Text = ds.Tables("obselement").Rows(inc).Item("lowerlimit")
        UnitsTextBox.Text = ds.Tables("obselement").Rows(inc).Item("units")

        'display record number
        displayRecordNumber()
        Exit Sub
Err:
        If Err.Number = 13 Then Resume Next
    End Sub
    Public Sub displayRecordNumber()
        'Display the record number in the data navigation Textbox
        recNumberTextBox.Text = "Record " & inc + 1 & " of " & maxRows
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub formElement_Load(sender As Object, e As EventArgs) Handles Me.Load

        'Set the record index counter to the first row
        inc = 0
        ' The following line was commented because the login for was changed from that designed by Albert to one designed by Samuel
        'myConnectionString = formDatabaseConnect.txtDbParameters.Text & "uid=" & formDatabaseConnect.userName.Text & ";pwd=" & formDatabaseConnect.passWord.Text & ";"
        myConnectionString = LoginForm.txtusrpwd.Text
        Try
            conn.ConnectionString = myConnectionString
            conn.Open()

            sql = "SELECT * FROM obselement"
            da = New MySql.Data.MySqlClient.MySqlDataAdapter(sql, conn)
            da.Fill(ds, "obselement")
            conn.Close()

        Catch ex As MySql.Data.MySqlClient.MySqlException
            MessageBox.Show(ex.Message)
        End Try
        maxRows = ds.Tables("obselement").Rows.Count

        CodeTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementId")
        AbbreviationTextBox.Text = ds.Tables("obselement").Rows(inc).Item("abbreviation")
        ElementNameTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementname")
        DescriptionTextBox.Text = ds.Tables("obselement").Rows(inc).Item("description")
        ElementScaleTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementscale")
        ElementtypeTextBox.Text = ds.Tables("obselement").Rows(inc).Item("elementtype")
        UpperLimitTextBox.Text = ds.Tables("obselement").Rows(inc).Item("upperlimit")
        LowerLimitTextBox.Text = ds.Tables("obselement").Rows(inc).Item("lowerlimit")
        UnitsTextBox.Text = ds.Tables("obselement").Rows(inc).Item("units")

        'Display the record number
        displayRecordNumber()

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

    Private Sub btnCommit_Click(sender As Object, e As EventArgs) Handles btnCommit.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)
        Dim dsNewRow As DataRow
        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recCommit As New dataEntryGlobalRoutines
        dsNewRow = ds.Tables("obselement").NewRow
        dsNewRow.Item("elementid") = CodeTextBox.Text
        dsNewRow.Item("elementname") = ElementNameTextBox.Text
        dsNewRow.Item("abbreviation") = AbbreviationTextBox.Text
        dsNewRow.Item("description") = DescriptionTextBox.Text
        dsNewRow.Item("elementscale") = ElementScaleTextBox.Text
        dsNewRow.Item("units") = UnitsTextBox.Text
        dsNewRow.Item("upperlimit") = UpperLimitTextBox.Text
        dsNewRow.Item("lowerlimit") = LowerLimitTextBox.Text
        dsNewRow.Item("elementtype") = ElementtypeTextBox.Text
        
        'Add a new record to the data source table
        ds.Tables("obselement").Rows.Add(dsNewRow)
        da.Update(ds, "obselement")

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
        maxRows = ds.Tables("obselement").Rows.Count
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

        ds.Tables("obselement").Rows(inc).Delete()
        da.Update(ds, "obselement")
        maxRows = maxRows - 1
        inc = 0

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

        btnMoveFirst.Enabled = False
        btnMoveLast.Enabled = False
        btnMoveNext.Enabled = False
        btnMovePrevious.Enabled = False
        btnAddNew.Enabled = False
        btnClear.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnCommit.Enabled = True

        CodeTextBox.Clear()
        AbbreviationTextBox.Clear()
        ElementNameTextBox.Clear()
        DescriptionTextBox.Clear()
        ElementScaleTextBox.Clear()
        ElementtypeTextBox.Clear()
        UnitsTextBox.Clear()
        UpperLimitTextBox.Clear()
        LowerLimitTextBox.Clear()

        'Set record index to last record
        inc = maxRows - 1

        'Display record position in record navigation Text Box
        recNumberTextBox.Text = "Record " & maxRows + 1 & " of " & maxRows + 1

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'The CommandBuilder providers the imbedded command for updating the record in the record source table. So the CommandBuilder
        'must be declared for the Update method to work.
        Dim cb As New MySql.Data.MySqlClient.MySqlCommandBuilder(da)

        'Instantiate the "dataEntryGlobalRoutines" in order to access its methods.
        Dim recUpdate As New dataEntryGlobalRoutines
        ds.Tables("obselement").Rows(inc).Item("elementId") = CodeTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("elementname") = ElementNameTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("abbreviation") = AbbreviationTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("description") = DescriptionTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("units") = UnitsTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("elementscale") = ElementScaleTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("elementtype") = ElementtypeTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("lowerlimit") = LowerLimitTextBox.Text
        ds.Tables("obselement").Rows(inc).Item("upperlimit") = UpperLimitTextBox.Text


        'The data adapter is used to update the record in the data source table
        da.Update(ds, "obselement")

        'Show message for successful updating or record.
        'The message to be displayed is provided by a subroutine in the "dataEntryCommonRoutines" class hence the need to
        'instantiate the "dataEntryCommonRoutines" class in the Declaration above.
        recUpdate.messageBoxRecordedUpdated()
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
End Class